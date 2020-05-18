using DBDiff.Schema;
using DBDiff.Schema.Misc;
using DBDiff.Schema.Model;
using DBDiff.Schema.SQLServer.Generates.Front;
using DBDiff.Schema.SQLServer.Generates.Generates;
using DBDiff.Schema.SQLServer.Generates.Model;
using DBDiff.Schema.SQLServer.Generates.Options;
using DBDiff.Settings;
using DiffPlex;
using DiffPlex.DiffBuilder;
using DiffPlex.DiffBuilder.Model;
using ScintillaNET;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DBDiff.Front
{
    public partial class PrincipalForm : Form
    {
        private Project ActiveProject;
        private IFront mySqlConnectFront1;
        private IFront mySqlConnectFront2;
        private readonly SqlOption SqlFilter = new SqlOption();
        private List<ISchemaBase> _selectedSchemas = new List<ISchemaBase>();

        #region 自定义脚本操作
        private string FolderPath;
        private string InitScript;
        private string ClearScript;
        private string OptimizeScript;
        private string BackupPath;
        private FolderBrowserDialog folderDialog;
        private Thread thread;
        #endregion

        public PrincipalForm()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0xA1 && m.WParam.ToInt32() == 2)
                return;
            base.WndProc(ref m);
        }

        private void ProcessSQL2005()
        {
            ProgressForm progress = null;
            string errorLocation = null;
            try
            {
                Database origin;
                Database destination;

                if ((!String.IsNullOrEmpty(mySqlConnectFront1.DatabaseName) &&
                     (!String.IsNullOrEmpty(mySqlConnectFront2.DatabaseName))))
                {
                    Generate sql1 = new Generate();
                    Generate sql2 = new Generate();

                    sql1.ConnectionString = mySqlConnectFront1.ConnectionString;
                    sql1.Options = SqlFilter;

                    sql2.ConnectionString = mySqlConnectFront2.ConnectionString;
                    sql2.Options = SqlFilter;

                    progress = new ProgressForm("目标数据库", "参考数据库", sql2, sql1);
                    progress.ShowDialog(this);
                    if (progress.Error != null)
                    {
                        throw new SchemaException(progress.Error.Message, progress.Error);
                    }

                    origin = progress.Source;
                    destination = progress.Destination;

                    txtSyncScript.ConfigurationManager.Language = "mssql";
                    txtSyncScript.IsReadOnly = false;
                    txtSyncScript.Styles.LineNumber.BackColor = Color.White;
                    txtSyncScript.Styles.LineNumber.IsVisible = false;
                    errorLocation = "Generating Synchronized Script";
                    txtSyncScript.Text = destination.ToSqlDiff(_selectedSchemas).ToSQL();
                    txtSyncScript.IsReadOnly = true;
                    schemaTreeView1.DatabaseSource = destination;
                    schemaTreeView1.DatabaseDestination = origin;
                    schemaTreeView1.OnSelectItem += new SchemaTreeView.SchemaHandler(schemaTreeView1_OnSelectItem);
                    schemaTreeView1_OnSelectItem(schemaTreeView1.SelectedNode);

                    btnCopy.Enabled = true;
                    btnSaveAs.Enabled = true;
                    btnUpdateAll.Enabled = true;
                }
                else
                    MessageBox.Show(Owner, "请选择一个有效的连接字符串。", "错误", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                if (errorLocation == null && progress != null)
                {
                    errorLocation = String.Format("{0} (while {1})", progress.ErrorLocation, progress.ErrorMostRecentProgress ?? "initializing");
                }

                throw new SchemaException("Error " + (errorLocation ?? " Comparing Databases"), ex);
            }
        }

        private void schemaTreeView1_OnSelectItem(string ObjectFullName)
        {
            if (ObjectFullName == null) return;

            txtNewObject.IsReadOnly = false;
            txtOldObject.IsReadOnly = false;
            txtNewObject.Text = "";
            txtOldObject.Text = "";

            Database database = (Database)schemaTreeView1.DatabaseSource;
            if (database.Find(ObjectFullName) != null)
            {
                if (database.Find(ObjectFullName).Status != Enums.ObjectStatusType.DropStatus)
                {
                    txtNewObject.Text = database.Find(ObjectFullName).ToSql();
                    if (database.Find(ObjectFullName).Status == Enums.ObjectStatusType.OriginalStatus)
                    {
                        btnUpdate.Enabled = false;
                    }
                    else
                    {
                        btnUpdate.Enabled = true;
                    }
                    if (database.Find(ObjectFullName).ObjectType == Enums.ObjectType.Table)
                    {
                        btnCompareTableData.Enabled = true;
                    }
                    else
                    {
                        btnCompareTableData.Enabled = false;
                    }
                }
            }

            database = (Database)schemaTreeView1.DatabaseDestination;
            if (database.Find(ObjectFullName) != null)
            {
                if (database.Find(ObjectFullName).Status != Enums.ObjectStatusType.CreateStatus)
                    txtOldObject.Text = database.Find(ObjectFullName).ToSql();
            }
            txtNewObject.IsReadOnly = true;
            txtOldObject.IsReadOnly = true;

            var diff = (new SideBySideDiffBuilder(new Differ())).BuildDiffModel(txtOldObject.Text, txtNewObject.Text);

            var sb = new StringBuilder();
            DiffPiece newLine, oldLine;
            var markers = new Marker[] { txtDiff.Markers[0], txtDiff.Markers[1], txtDiff.Markers[2], txtDiff.Markers[3] };
            foreach (var marker in markers) marker.Symbol = MarkerSymbol.Background;
            markers[0].BackColor = Color.LightGreen;
            markers[1].BackColor = Color.LightCyan;
            markers[2].BackColor = Color.LightSalmon;
            markers[3].BackColor = Color.PeachPuff;

            var indexes = new List<int>[] { new List<int>(), new List<int>(), new List<int>(), new List<int>() };
            var index = 0;
            for (var i = 0; i < Math.Max(diff.NewText.Lines.Count, diff.OldText.Lines.Count); i++)
            {
                newLine = i < diff.NewText.Lines.Count ? diff.NewText.Lines[i] : null;
                oldLine = i < diff.OldText.Lines.Count ? diff.OldText.Lines[i] : null;
                if (oldLine.Type == ChangeType.Inserted)
                {
                    sb.AppendLine(" " + oldLine.Text);
                }
                else if (oldLine.Type == ChangeType.Deleted)
                {
                    sb.AppendLine("- " + oldLine.Text);
                    indexes[2].Add(index);
                }
                else if (oldLine.Type == ChangeType.Modified)
                {
                    sb.AppendLine("* " + newLine.Text);
                    indexes[1].Add(index++);
                    sb.AppendLine("* " + oldLine.Text);
                    indexes[3].Add(index);
                }
                else if (oldLine.Type == ChangeType.Imaginary)
                {
                    sb.AppendLine("+ " + newLine.Text);
                    indexes[0].Add(index);
                }
                else if (oldLine.Type == ChangeType.Unchanged)
                {
                    sb.AppendLine("  " + oldLine.Text);
                }
                index++;
            }
            txtDiff.Text = sb.ToString();
            for (var i = 0; i < 4; i++)
            {
                foreach (var ind in indexes[i])
                {
                    txtDiff.Lines[ind].AddMarker(markers[i]);
                }
            }
        }

        void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Refresh script when tab is shown
            if (tabControl1.SelectedIndex != 1)
            {
                return;
            }

            var db = schemaTreeView1.DatabaseSource as Database;
            if (db != null)
            {
                this._selectedSchemas = this.schemaTreeView1.GetCheckedSchemas();
                this.txtSyncScript.IsReadOnly = false;
                this.txtSyncScript.Text = db.ToSqlDiff(this._selectedSchemas).ToSQL();
                this.txtSyncScript.IsReadOnly = false;
            }
        }

        private void btnCompareTableData_Click(object sender, EventArgs e)
        {
            TreeView tree = (TreeView)schemaTreeView1.Controls.Find("treeView1", true)[0];
            ISchemaBase selected = (ISchemaBase)tree.SelectedNode.Tag;
            DataCompareForm dataCompare = new DataCompareForm(selected, mySqlConnectFront1.ConnectionString, mySqlConnectFront2.ConnectionString);
            dataCompare.Show();
        }
        private void btnCompare_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;

            string errorLocation = "Processing Compare";
            try
            {
                Cursor = Cursors.WaitCursor;
                _selectedSchemas = schemaTreeView1.GetCheckedSchemas();
                ProcessSQL2005();
                schemaTreeView1.SetCheckedSchemas(_selectedSchemas);
                errorLocation = "Saving Connections";
                Project.SaveLastConfiguration(mySqlConnectFront1.ConnectionString, mySqlConnectFront2.ConnectionString);
            }
            catch (Exception ex)
            {
                var exceptionList = new List<Exception>();
                exceptionList.Add(ex);
                var innerException = ex.InnerException;
                while (innerException != null)
                {
                    exceptionList.Insert(0, innerException);
                    innerException = innerException.InnerException;
                }

                var exceptionMsg = new StringBuilder();
                var prevMessage = exceptionList[0].Message;
                exceptionMsg.Append(this.Text);
                for (int i = 1; i < exceptionList.Count; ++i)
                {
                    if (exceptionList[i].Message != prevMessage)
                    {
                        exceptionMsg.AppendFormat("\r\n{0}", exceptionList[i].Message);
                        prevMessage = exceptionList[i].Message;
                    }
                }

                var ignoreSystem = new Regex(@"   at System\.[^\r\n]+\r\n|C:\\dev\\open-dbdiff\\");
                exceptionMsg.AppendFormat("\r\n{0}: {1}\r\n{2}", exceptionList[0].GetType().Name, exceptionList[0].Message, ignoreSystem.Replace(exceptionList[0].StackTrace, String.Empty));

                var ignoreChunks = new Regex(@": \[[^\)]*\)|\.\.\.\)|\'[^\']*\'|\([^\)]*\)|\" + '"' + @"[^\" + '"' + @"]*\" + '"' + @"|Source|Destination");
                var searchableError = ignoreChunks.Replace(exceptionMsg.ToString(), String.Empty);
                var searchableErrorBytes = Encoding.UTF8.GetBytes(searchableError);
                searchableErrorBytes = new MD5CryptoServiceProvider().ComputeHash(searchableErrorBytes);
                var searchHash = BitConverter.ToString(searchableErrorBytes).Replace("-", String.Empty);
                exceptionMsg.AppendFormat("\r\n\r\n{0}", searchHash);
                MessageBox.Show(Owner, "在处理过程中发生意外错误:" + exceptionMsg.ToString(), "错误 " + errorLocation, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void ShowSQL2005()
        {
            mySqlConnectFront2 = new SqlServerConnectFront();
            mySqlConnectFront1 = new SqlServerConnectFront();
            mySqlConnectFront1.Location = new Point(1, 1);
            mySqlConnectFront1.Name = "mySqlConnectFront1";
            mySqlConnectFront1.Anchor =
                (AnchorStyles)((int)AnchorStyles.Bottom + (int)AnchorStyles.Left + (int)AnchorStyles.Right);

            mySqlConnectFront1.TabIndex = 10;
            mySqlConnectFront1.Text = "参考数据库:";
            mySqlConnectFront2.Location = new Point(1, 1);
            mySqlConnectFront2.Name = "mySqlConnectFront2";
            mySqlConnectFront2.Anchor =
                (AnchorStyles)((int)AnchorStyles.Bottom + (int)AnchorStyles.Left + (int)AnchorStyles.Right);
            mySqlConnectFront2.TabIndex = 10;
            mySqlConnectFront1.Visible = true;
            mySqlConnectFront2.Visible = true;
            mySqlConnectFront2.Text = "目标数据库:";
            ((SqlServerConnectFront)mySqlConnectFront1).UserName = "sa";
            ((SqlServerConnectFront)mySqlConnectFront1).Password = "";
            ((SqlServerConnectFront)mySqlConnectFront1).ServerName = "(local)";
            ((SqlServerConnectFront)mySqlConnectFront2).UserName = "sa";
            ((SqlServerConnectFront)mySqlConnectFront2).Password = "";
            ((SqlServerConnectFront)mySqlConnectFront2).ServerName = "(local)";
            ((SqlServerConnectFront)mySqlConnectFront1).DatabaseIndex = 1;
            ((SqlServerConnectFront)mySqlConnectFront2).DatabaseIndex = 2;
            PanelDestination.Controls.Add((Control)mySqlConnectFront2);
            PanelSource.Controls.Add((Control)mySqlConnectFront1);
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;

            try
            {
                if (!string.IsNullOrEmpty(saveFileDialog1.FileName) && !string.IsNullOrEmpty(Path.GetDirectoryName(saveFileDialog1.FileName)))
                {
                    saveFileDialog1.InitialDirectory = Path.GetDirectoryName(saveFileDialog1.FileName);
                    saveFileDialog1.FileName = Path.GetFileName(saveFileDialog1.FileName);
                }
                saveFileDialog1.ShowDialog(this);
                if (!String.IsNullOrEmpty(saveFileDialog1.FileName))
                {
                    var db = schemaTreeView1.DatabaseSource as Database;
                    if (db != null)
                    {
                        using (StreamWriter writer = new StreamWriter(saveFileDialog1.FileName, false, Encoding.UTF8))
                        {
                            this._selectedSchemas = this.schemaTreeView1.GetCheckedSchemas();
                            writer.Write(db.ToSqlDiff(this._selectedSchemas).ToSQL());
                            writer.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;

            try
            {
                System.Windows.Forms.Clipboard.SetText(txtSyncScript.Text);
            }
            finally
            {
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;

            TreeView tree = (TreeView)schemaTreeView1.Controls.Find("treeView1", true)[0];
            TreeNode dbArm = tree.Nodes[0];
            string result = "";

            foreach (TreeNode node in dbArm.Nodes)
            {
                if (node.Nodes.Count != 0)
                {
                    foreach (TreeNode subnode in node.Nodes)
                    {
                        if (subnode.Checked)
                        {
                            ISchemaBase selected = (ISchemaBase)subnode.Tag;

                            Database database = (Database)schemaTreeView1.DatabaseSource;

                            if (database.Find(selected.FullName) != null)
                            {
                                switch (selected.ObjectType)
                                {
                                    case Enums.ObjectType.Table:
                                        {
                                            switch (selected.Status)
                                            {
                                                case Enums.ObjectStatusType.CreateStatus: result += Updater.createNew(selected, mySqlConnectFront2.ConnectionString); break;
                                                case Enums.ObjectStatusType.AlterStatus: result += Updater.alter(selected, mySqlConnectFront2.ConnectionString); break;
                                                case Enums.ObjectStatusType.AlterWhitespaceStatus: result += Updater.alter(selected, mySqlConnectFront2.ConnectionString); break;
                                                default: result += "没有找到跟表 " + selected.Name + " 相关的.\r\n"; break;
                                            }
                                        }
                                        break;
                                    case Enums.ObjectType.StoredProcedure:
                                        {
                                            switch (selected.Status)
                                            {
                                                case Enums.ObjectStatusType.CreateStatus: result += Updater.createNew(selected, mySqlConnectFront2.ConnectionString); break;
                                                case Enums.ObjectStatusType.AlterStatus: result += Updater.alter(selected, mySqlConnectFront2.ConnectionString); break;
                                                case Enums.ObjectStatusType.AlterWhitespaceStatus: result += Updater.alter(selected, mySqlConnectFront2.ConnectionString); break;
                                                default: result += "没有找到跟存储过程 " + selected.Name + " 相关的.\r\n"; break;
                                            }
                                        }
                                        break;
                                    case Enums.ObjectType.Function:
                                        {
                                            switch (selected.Status)
                                            {
                                                case Enums.ObjectStatusType.CreateStatus: result += Updater.createNew(selected, mySqlConnectFront2.ConnectionString); break;
                                                case Enums.ObjectStatusType.AlterStatus: result += Updater.alter(selected, mySqlConnectFront2.ConnectionString); break;
                                                case Enums.ObjectStatusType.AlterWhitespaceStatus: result += Updater.alter(selected, mySqlConnectFront2.ConnectionString); break;
                                                case Enums.ObjectStatusType.AlterStatus | Enums.ObjectStatusType.AlterBodyStatus: result += Updater.alter(selected, mySqlConnectFront2.ConnectionString); break;
                                                default: result += "没有找到跟函数 " + selected.Name + " 相关的.\r\n"; break;
                                            }
                                        }
                                        break;
                                    case Enums.ObjectType.View:
                                        {
                                            switch (selected.Status)
                                            {
                                                case Enums.ObjectStatusType.CreateStatus: result += Updater.createNew(selected, mySqlConnectFront2.ConnectionString); break;
                                                case Enums.ObjectStatusType.AlterStatus: result += Updater.alter(selected, mySqlConnectFront2.ConnectionString); break;
                                                case Enums.ObjectStatusType.AlterWhitespaceStatus: result += Updater.alter(selected, mySqlConnectFront2.ConnectionString); break;
                                                case Enums.ObjectStatusType.AlterStatus | Enums.ObjectStatusType.AlterBodyStatus: result += Updater.alter(selected, mySqlConnectFront2.ConnectionString); break;
                                                default: result += "没有找到跟视图 " + selected.Name + " 相关的.\r\n"; break;
                                            }
                                        }
                                        break;
                                    default:
                                        {
                                            switch (selected.Status)
                                            {
                                                case Enums.ObjectStatusType.CreateStatus: result += Updater.addNew(selected, mySqlConnectFront2.ConnectionString); break;
                                                default: result += "没有找到跟 " + selected.Name + " 相关的.\r\n"; break;
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                    }
                }
            }

            if (result == string.Empty)
            {
                result = "更新完成！";
            }
            MessageBox.Show(result);

            if (SqlFilter.Comparison.ReloadComparisonOnUpdate)
            {
                ProcessSQL2005();
            }

            btnUpdate.Enabled = false;
        }

        private void btnUpdateAll_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;

            if (MessageBox.Show("你确定要更新全部吗？", "更新确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                TreeView tree = (TreeView)schemaTreeView1.Controls.Find("treeView1", true)[0];
                TreeNode database = tree.Nodes[0];
                string result = "";
                foreach (TreeNode tn in database.Nodes)
                {
                    foreach (TreeNode inner in tn.Nodes)
                    {
                        if (inner.Tag != null)
                        {
                            ISchemaBase item = (ISchemaBase)inner.Tag;
                            switch (item.Status)
                            {
                                case Enums.ObjectStatusType.CreateStatus: result += Updater.createNew(item, mySqlConnectFront2.ConnectionString); break;
                                case Enums.ObjectStatusType.AlterStatus: result += Updater.alter(item, mySqlConnectFront2.ConnectionString); break;
                            }
                        }
                    }
                }
                if (result == string.Empty)
                {
                    result = "更新完成！";
                }
                MessageBox.Show(result);
                ProcessSQL2005();
            }
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;

            OptionForm form = new OptionForm();
            form.Show(Owner, SqlFilter);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowSQL2005();
            txtNewObject.ConfigurationManager.Language = "mssql";
            txtNewObject.IsReadOnly = false;
            txtNewObject.Styles.LineNumber.BackColor = Color.White;
            txtNewObject.Styles.LineNumber.IsVisible = false;
            txtOldObject.ConfigurationManager.Language = "mssql";
            txtOldObject.IsReadOnly = false;
            txtOldObject.Styles.LineNumber.BackColor = Color.White;
            txtOldObject.Styles.LineNumber.IsVisible = false;
            txtDiff.ConfigurationManager.Language = "mssql";
            txtDiff.IsReadOnly = false;
            txtDiff.Styles.LineNumber.IsVisible = false;
            txtDiff.Margins[0].Width = 20;
            Project LastConfiguration = Project.GetLastConfiguration();
            if (LastConfiguration != null)
            {
                mySqlConnectFront1.ConnectionString = LastConfiguration.ConnectionStringSource;
                mySqlConnectFront2.ConnectionString = LastConfiguration.ConnectionStringDestination;
            }

            txtSyncScript.Text = "";

            #region 自定义脚本操作
            FolderPath = ConfigurationManager.AppSettings["FolderPath"];
            InitScript = ConfigurationManager.AppSettings["InitScript"];
            ClearScript = ConfigurationManager.AppSettings["ClearScript"];
            OptimizeScript = ConfigurationManager.AppSettings["OptimizeScript"];
            BackupPath = ConfigurationManager.AppSettings["BackupPath"];

            scintillaLog.ConfigurationManager.Language = "mssql";
            scintillaLog.IsReadOnly = true;
            scintillaLog.Styles.LineNumber.BackColor = Color.White;
            scintillaLog.Styles.LineNumber.IsVisible = false;
            #endregion
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ActiveProject == null)
                {
                    ActiveProject = new Project
                    {
                        ConnectionStringSource = mySqlConnectFront1.ConnectionString,
                        ConnectionStringDestination = mySqlConnectFront2.ConnectionString,
                        Name = String.Format("[{0}].[{1}] - [{2}].[{3}]",
                                                        ((SqlServerConnectFront)mySqlConnectFront1).ServerName,
                                                        mySqlConnectFront1.DatabaseName,
                                                        ((SqlServerConnectFront)mySqlConnectFront2).ServerName,
                                                        mySqlConnectFront2.DatabaseName),
                        Type = Project.ProjectType.SQLServer
                    };
                }
                ActiveProject.Id = Project.Save(ActiveProject);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProject_Click(object sender, EventArgs e)
        {
            try
            {
                ListProjectsForm form = new ListProjectsForm(Project.GetAll());
                form.OnSelect += new ListProjectHandler(form_OnSelect);
                form.OnDelete += new ListProjectHandler(form_OnDelete);
                form.OnRename += new ListProjectHandler(form_OnRename);
                form.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void form_OnRename(Project itemSelected)
        {
            try
            {
                Project.Save(itemSelected);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void form_OnDelete(Project itemSelected)
        {
            try
            {
                Project.Delete(itemSelected.Id);
                if (ActiveProject != null)
                {
                    if (ActiveProject.Id == itemSelected.Id)
                    {
                        ActiveProject = null;
                        mySqlConnectFront1.ConnectionString = "";
                        mySqlConnectFront2.ConnectionString = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void form_OnSelect(Project itemSelected)
        {
            try
            {
                if (itemSelected != null)
                {
                    ActiveProject = itemSelected;
                    mySqlConnectFront1.ConnectionString = itemSelected.ConnectionStringSource;
                    mySqlConnectFront2.ConnectionString = itemSelected.ConnectionStringDestination;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNewProject_Click(object sender, EventArgs e)
        {
            mySqlConnectFront1.ConnectionString = "";
            mySqlConnectFront2.ConnectionString = "";
            ActiveProject = null;
        }

        #region 自定义脚本操作
        /// <summary>
        /// 高级脚本管理
        /// </summary>
        private void btn_ProjectManage_Click(object sender, EventArgs e)
        {
            if (!mySqlConnectFront2.TestConnection())
            {
                MessageBox.Show(this, "目标数据库连接失败!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ProjectManageForm form = new ProjectManageForm(mySqlConnectFront2.ConnectionString);
            form.ShowDialog();
        }

        /// <summary>
        /// 选择文件夹
        /// </summary>
        private void buttonSelect_Click(object sender, EventArgs e)
        {
            scintillaLog.IsReadOnly = false;
            tabControl1.SelectedIndex = 2;
            scintillaLog.AppendText($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}：开始选择脚本所在文件夹\n");
            if (folderDialog == null)
            {
                folderDialog = new FolderBrowserDialog();
                folderDialog.Description = "请选择SQL文件目录";
                //folderDialog.RootFolder = Environment.SpecialFolder.Desktop;
                folderDialog.ShowNewFolderButton = false;
                folderDialog.SelectedPath = FolderPath;
            }
            var dialogResult = folderDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                FolderPath = folderDialog.SelectedPath;
                scintillaLog.AppendText($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}：已选择脚本所在文件夹为[{FolderPath}]\n");
            }
            else
            {
                scintillaLog.AppendText($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}：取消选择脚本所在文件夹\n");
            }
            scintillaLog.IsReadOnly = true;
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void buttonInit_Click(object sender, EventArgs e)
        {
            scintillaLog.IsReadOnly = false;
            tabControl1.SelectedIndex = 2;

            if (!mySqlConnectFront2.TestConnection())
            {
                scintillaLog.AppendText($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}：'目标数据库连接失败!'\n");
                return;
            }

            if (string.IsNullOrEmpty(FolderPath))
            {
                scintillaLog.AppendText($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}：'请选择文件夹[1.选择文件夹]'\n");
                return;
            }

            scintillaLog.AppendText($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}：初始化脚本执行的数据库为[{mySqlConnectFront2.DatabaseName}]\n");

            var initPath = $"{FolderPath}\\{InitScript}";
            if (!File.Exists(initPath))
            {
                scintillaLog.AppendText($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}：'初始化脚本不存在[{initPath}]'\n");
                return;
            }
            var sqlScript = File.ReadAllText(initPath, System.Text.Encoding.UTF8);
            if (string.IsNullOrEmpty(sqlScript))
            {
                scintillaLog.AppendText($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}：'初始化脚本内容为空[{initPath}]'\n");
                return;
            }
            scintillaLog.IsReadOnly = true;

            if (thread != null)
            {
                thread.Abort();
                thread = null;
            }

            var connectionString = mySqlConnectFront2.ConnectionString;

            thread = new Thread(new ThreadStart(() => ThreadFunc(this, sqlScript, connectionString, (message) =>
            {
                scintillaLog.IsReadOnly = false;
                scintillaLog.AppendText($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}：初始化脚本执行结果[{(message == "" ? "成功" : message)}]\n");
                scintillaLog.IsReadOnly = true;
            })))
            {
                IsBackground = true
            };
            thread.Start();
        }

        /// <summary>
        /// 清理数据
        /// </summary>
        private void buttonClear_Click(object sender, EventArgs e)
        {
            scintillaLog.IsReadOnly = false;
            tabControl1.SelectedIndex = 2;

            if (!mySqlConnectFront2.TestConnection())
            {
                scintillaLog.AppendText($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}：'目标数据库连接失败!'\n");
                return;
            }

            if (string.IsNullOrEmpty(FolderPath))
            {
                scintillaLog.AppendText($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}：'请选择文件夹[1.选择文件夹]'\n");
                return;
            }

            scintillaLog.AppendText($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}：清理脚本执行的数据库为[{mySqlConnectFront2.DatabaseName}]\n");

            var clearPath = $"{FolderPath}\\{ClearScript}";
            if (!File.Exists(clearPath))
            {
                scintillaLog.AppendText($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}：'清理脚本不存在[{clearPath}]'\n");
                return;
            }
            var sqlScript = File.ReadAllText(clearPath, System.Text.Encoding.UTF8);
            if (string.IsNullOrEmpty(sqlScript))
            {
                scintillaLog.AppendText($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}：'清理脚本内容为空[{clearPath}]'\n");
                return;
            }
            var message = Updater.ExecSQL(sqlScript, mySqlConnectFront2.ConnectionString);
            scintillaLog.AppendText($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}：清理脚本执行结果[{(message == "" ? "成功" : message)}]\n");
            scintillaLog.IsReadOnly = true;
        }

        /// <summary>
        /// 优化操作
        /// </summary>
        private void buttonOptimize_Click(object sender, EventArgs e)
        {
            scintillaLog.IsReadOnly = false;
            tabControl1.SelectedIndex = 2;

            if (!mySqlConnectFront2.TestConnection())
            {
                scintillaLog.AppendText($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}：'目标数据库连接失败!'\n");
                return;
            }

            if (string.IsNullOrEmpty(FolderPath))
            {
                scintillaLog.AppendText($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}：'请选择文件夹[1.选择文件夹]'\n");
                return;
            }

            scintillaLog.AppendText($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}：优化脚本执行的数据库为[{mySqlConnectFront2.DatabaseName}]\n");

            var optimizePath = $"{FolderPath}\\{OptimizeScript}";
            if (!File.Exists(optimizePath))
            {
                scintillaLog.AppendText($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}：'优化脚本不存在[{optimizePath}]'\n");
                return;
            }
            var sqlScript = File.ReadAllText(optimizePath, System.Text.Encoding.UTF8);
            if (string.IsNullOrEmpty(sqlScript))
            {
                scintillaLog.AppendText($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}：'优化脚本内容为空[{optimizePath}]'\n");
                return;
            }
            var message = Updater.ExecSQL(sqlScript, mySqlConnectFront2.ConnectionString);
            scintillaLog.AppendText($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}：优化脚本执行结果[{(message == "" ? "成功" : message)}]\n");
            scintillaLog.IsReadOnly = true;
        }

        /// <summary>
        /// 备份数据库
        /// </summary>
        private void buttonBackup_Click(object sender, EventArgs e)
        {
            scintillaLog.IsReadOnly = false;
            tabControl1.SelectedIndex = 2;

            if (!mySqlConnectFront2.TestConnection())
            {
                scintillaLog.AppendText($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}：'目标数据库连接失败!'\n");
                return;
            }
            scintillaLog.AppendText($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}：备份执行的数据库为[{mySqlConnectFront2.DatabaseName}]\n");

            scintillaLog.AppendText($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}：数据库备份目录为(自选)[{BackupPath}]\n");

            if (string.IsNullOrEmpty(BackupPath))
            {
                BackupPath = Updater.ReadSQLBackupPath(mySqlConnectFront2.ConnectionString);
                scintillaLog.AppendText($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}：数据库备份目录为(默认)[{BackupPath}]\n");
            }

            //scintillaLog.AppendText($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}：数据库备份目录为(执行)[{BackupPath}]\n");

            var backupName = $"{mySqlConnectFront2.DatabaseName}_{DateTime.Now:yyyyMMddHHmmss}.bak";
            var _backupPath = $"{BackupPath}\\{backupName}";

            scintillaLog.AppendText($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}：数据库备份路径为[{_backupPath}]\n");

            scintillaLog.AppendText($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}：数据库备份开始...\n");
            scintillaLog.IsReadOnly = true;

            if (thread != null)
            {
                thread.Abort();
                thread = null;
            }

            var sqlScript = $"BACKUP DATABASE [{mySqlConnectFront2.DatabaseName}] " +
                            $"TO DISK = N'{_backupPath}' " +
                            $"WITH NAME = N'{backupName}',NOFORMAT, NOINIT, SKIP, STATS = 10";
            var connectionString = mySqlConnectFront2.ConnectionString;

            thread = new Thread(new ThreadStart(() => ThreadFunc(this, sqlScript, connectionString, (message) =>
            {
                scintillaLog.IsReadOnly = false;
                scintillaLog.AppendText($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}：数据库备份执行结果[{(message == "" ? "成功" : message)}]\n");
                scintillaLog.IsReadOnly = true;
                //if (string.IsNullOrEmpty(message))
                //{
                //    System.Diagnostics.Process.Start("Explorer.exe", BackupPath);
                //}
            })))
            {
                IsBackground = true
            };
            thread.Start();
        }

        /// <summary>
        /// 由于数据库备份时长不定，特引入异步操作
        /// </summary>
        private void ThreadFunc(Control main, string sqlScript, string connectionString, Action<string> action)
        {
            var message = "";
            try
            {
                message = Updater.ExecSQL(sqlScript, connectionString);
            }
            catch (Exception error)
            {
                message = error.Message;
            }
            finally
            {
                main.Invoke(new Action(delegate { action(message); }));
            }
        }
        #endregion
    }
}
