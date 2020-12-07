using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace ITProgExam
{
    class MethCalls
    {

        public static void InitializeDB()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = Varcalls.SERVER;
            builder.UserID = Varcalls.UID;
            builder.Password = Varcalls.PASSWORD;
            builder.Database = Varcalls.DATABASE;

            String connString = builder.ToString();

            builder = null;

            Console.WriteLine(connString);
            //MessageBox.Show(connString);

            Varcalls.dbConn = new MySqlConnection(connString);

            Application.ApplicationExit += (sender, args) =>
            {
                if (Varcalls.dbConn != null)
                {
                    Varcalls.dbConn.Dispose();
                    Varcalls.dbConn = null;
                }
            };
        }

      
    }
}
