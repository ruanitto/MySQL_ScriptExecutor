using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace MySQL_Script
{
    public class DAO
    {
        public string hostname;
        public string username;
        public string password;
        IDbConnection dbcon;

        public DAO()
        {
        }

        public DAO(string hostname, string username, string password)
        {
            this.hostname = hostname;
            this.username = username;
            this.password = password;
        }

        public Boolean Connect()
        {
            if (this.hostname == string.Empty)
            {
                throw new Exception("Digite um Host válido!");
            } else if (this.username == string.Empty)
            {
                throw new Exception("Digite um username válido!");
            } else if (this.password == string.Empty)
            {
                throw new Exception("Digite um password válido!");
            }

            string connectionString =
              "Server=" + this.hostname + ";" +
              "Database=;" +
              "User ID=" + this.username + ";" +
              "Password=" + this.password + ";" +
              "Pooling=false";

            try
            {
                this.dbcon = new MySqlConnection(connectionString);
                this.dbcon.Open();
                return true;
            } catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Erro: " + e.Message);
                return false;
            }
        }

        public void ExecCommand(string SQLCommand)
        {
            IDbCommand dbcmd = dbcon.CreateCommand();
            if (SQLCommand != string.Empty)
            {
                dbcmd.CommandText = SQLCommand;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Digite uma instrução SQL Válida");
            }
        }

        public DataTable ShowDatabases()
        {
            DataTable data = new DataTable();
            IDbCommand dbcmd = dbcon.CreateCommand();
            dbcmd.CommandText = "SHOW DATABASES;";
            try
            {
                IDataReader reader = dbcmd.ExecuteReader();
                data.Load(reader);

                return data;
            } catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Erro: " + e.Message);
                data.Clear();
                return data;
            }

        }

        public void Disconnect()
        {
            this.dbcon.Dispose();
        }
    }
}
