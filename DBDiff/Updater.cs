using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DBDiff.Schema;
using DBDiff.Schema.Model;
using DBDiff.Schema.SQLServer.Generates.Model;

namespace DBDiff
{
    /// <summary>
    /// Handles the SQL update queries
    /// </summary>
    static class Updater
    {
        public static string createNew(ISchemaBase target, string connectionString)
        {
            string script = target.ToSql();
            script = script.Replace("GO", "");
            string result = string.Empty;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(script, connection);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                result = e.Message + "\n";
            }
            return result;
        }

        public static string addNew(ISchemaBase target, string connectionString)
        {
            string result = string.Empty;
            string script = target.ToSqlAdd();
            script = script.Replace("GO", "");
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(script, connection);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                result = e.Message + "\n";
            }
            return result;
        }

        public static DataTable getData(ISchemaBase selected, string connectionString)
        {
            DataTable data = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM " + selected.FullName;

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader(CommandBehavior.KeyInfo);
                    data.Load(reader);
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return data;
        }

        public static string alter(ISchemaBase target, string connectionString)
        {
            var db = target.RootParent as Database;
            SqlConnection connection = new SqlConnection(connectionString);
            if (db != null && DialogResult.Yes != MessageBox.Show(String.Format("确认修改 {0} {1} 在 {2}.{3}?\n",
                    target.ObjectType,
                    target.Name,
                    connection.DataSource,
                    connection.Database), "修改提示", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2))
            {
                return "取消操作.";
            }

            string result = string.Empty;
            SQLScriptList SqlDiff = target.ToSqlDiff();
            string[] splitOn = { "GO" };
            string[] tempList = SqlDiff.ToSQL().Split(splitOn, StringSplitOptions.RemoveEmptyEntries);
            List<string> scripts = new List<string>(tempList);

            foreach (string sql in scripts)
            {
                string script = sql;
                if (target.ObjectType == Enums.ObjectType.StoredProcedure)
                {
                    script = sql.Replace("CREATE PROCEDURE", "ALTER PROCEDURE");
                }
                SqlCommand command = new SqlCommand(script, connection);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception e)
                {
                    result += target.Name + ": " + e.Message + "\n\n";
                    connection.Close();
                }
            }
            return result;
        }

        public static string rebuild(ISchemaBase target, string connectionString)
        {
            SQLScriptList SqlDiff = target.ToSqlDiff();
            string[] splitOn = { "GO" };
            string[] tempList = SqlDiff.ToSQL().Split(splitOn, StringSplitOptions.RemoveEmptyEntries);
            List<string> scripts = new List<string>(tempList);
            string result = string.Empty;
            string script = scripts[0];
            if (target.ObjectType == Enums.ObjectType.Table)
            {
                script = script.Replace("CREATE TABLE", "ALTER TABLE");
            }
            MessageBox.Show(script);
            return result;
        }

        public static bool CommitTable(DataTable table, string tableFullName, string ConnectionString)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand("SELECT * FROM " + tableFullName, connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            try
            {
                using (SqlCommandBuilder builder = new SqlCommandBuilder(da))
                {
                    connection.Open();
                    da.Update(table);
                    connection.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        #region 自定义方法
        public static string ExecSQL(string script, string connectionString)
        {
            script = script.Replace("GO", "");
            string result = string.Empty;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(script, connection);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            return result;
        }

        public static string ReadSQLBackupPath(string connectionString)
        {

            var sqlScript = "DECLARE @BackupDirectory NVARCHAR(260) " +
                "EXEC master.dbo.xp_instance_regread " +
                "@rootkey = 'HKEY_LOCAL_MACHINE', " +
                @"@key = 'SOFTWARE\Microsoft\MSSQLServer\MSSQLServer', " +
                "@value_name = 'BackupDirectory', " +
                "@BackupDirectory = @BackupDirectory " +
                "OUTPUT SELECT @BackupDirectory";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(sqlScript, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader[0].ToString();
                        }
                    }
                }
            }
            return "";
        }
        #endregion
    }
}
