using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ScintillaNET;

namespace DBDiff.Front
{
    public partial class ProjectManageForm : Form
    {
        private FolderBrowserDialog folderDialog;
        private readonly string ConnectionString;
        public ProjectManageForm(string _ConnectionString)
        {
            InitializeComponent();

            ConnectionString = _ConnectionString;

            txtObject.ConfigurationManager.Language = "mssql";
            txtObject.IsReadOnly = false;
            txtObject.Styles.LineNumber.BackColor = Color.White;
            txtObject.Styles.LineNumber.IsVisible = false;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0xA1 && m.WParam.ToInt32() == 2)
                return;
            base.WndProc(ref m);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (folderDialog == null)
            {
                folderDialog = new FolderBrowserDialog();
                folderDialog.Description = "请选择SQL文件所在目录";
                folderDialog.RootFolder = Environment.SpecialFolder.Desktop;
                folderDialog.ShowNewFolderButton = false;
            }
            var dialogResult = folderDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                textBoxSelect.Text = folderDialog.SelectedPath;
                PaintTreeView(treeViewFile, folderDialog.SelectedPath);
                treeViewFile.ExpandAll();
            }
        }

        private void treeViewFile_DoubleClick(object sender, EventArgs e)
        {
            var node = treeViewFile.SelectedNode;
            if (node != null && !string.IsNullOrEmpty(node.Name))
            {
                scintillaLog.IsReadOnly = false;
                txtObject.Text = File.ReadAllText(node.Name, System.Text.Encoding.UTF8);
                scintillaLog.IsReadOnly = true;
            }
        }

        private void treeViewFile_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            e.DrawDefault = true;

            if ((e.State & TreeNodeStates.Selected) != 0)
            {
                e.Graphics.FillRectangle(Brushes.DarkBlue, e.Node.Bounds);
                Font nodeFont = e.Node.NodeFont;
                if (nodeFont == null) nodeFont = ((TreeView)sender).Font;
                e.Graphics.DrawString(e.Node.Text, nodeFont, Brushes.White, Rectangle.Inflate(e.Bounds, 2, 0));
            }
            else
            {
                e.DrawDefault = true;
            }


            if ((e.State & TreeNodeStates.Focused) != 0)
            {
                using (Pen focusPen = new Pen(Color.Black))
                {
                    focusPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                    Rectangle focusBounds = e.Node.Bounds;
                    focusBounds.Size = new Size(focusBounds.Width - 1,
                    focusBounds.Height - 1);
                    e.Graphics.DrawRectangle(focusPen, focusBounds);
                }
            }


        }

        private void PaintTreeView(TreeView treeView, string fullPath)
        {
            try
            {
                treeView.Nodes.Clear(); //清空TreeView

                var dirs = new DirectoryInfo(fullPath);
                var dir = dirs.GetDirectories();
                var file = dirs.GetFiles("*.SQL");
                int dircount = dir.Count();
                int filecount = file.Count();

                //循环文件夹
                for (int i = 0; i < dircount; i++)
                {
                    treeView.Nodes.Add(dir[i].Name);
                    string pathNode = fullPath + "\\" + dir[i].Name;
                    GetMultiNode(treeView.Nodes[i], pathNode);
                }

                //循环文件
                for (int j = 0; j < filecount; j++)
                {
                    treeView.Nodes.Add(file[j].FullName, file[j].Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool GetMultiNode(TreeNode treeNode, string path)
        {
            if (Directory.Exists(path) == false)
            {
                return false;
            }

            DirectoryInfo dirs = new DirectoryInfo(path);
            DirectoryInfo[] dir = dirs.GetDirectories();
            FileInfo[] file = dirs.GetFiles("*.SQL");
            int dircount = dir.Count();
            int filecount = file.Count();
            int sumcount = dircount + filecount;

            if (sumcount == 0)
            {
                return false;
            }

            //循环文件夹
            for (int j = 0; j < dircount; j++)
            {
                treeNode.Nodes.Add(dir[j].Name);
                string pathNodeB = path + "\\" + dir[j].Name;
                GetMultiNode(treeNode.Nodes[j], pathNodeB);
            }


            //循环文件
            for (int j = 0; j < filecount; j++)
            {
                treeNode.Nodes.Add(file[j].FullName, file[j].Name);
            }
            return true;
        }

        private void btn_Exec_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtObject.Text))
            {
                scintillaLog.AppendText($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}：[脚本内容为空]\n");
                return;
            }
            var message = Updater.ExecSQL(txtObject.Text, ConnectionString);
            scintillaLog.IsReadOnly = false;
            scintillaLog.AppendText($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}：[{(message == "" ? "成功" : message)}]\n");
            scintillaLog.IsReadOnly = true;
        }
    }
}