using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Robot.Library
{
    public class DataProvider
    {
        private SqlConnection _connection;

        // constructor
        public DataProvider(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        // destructor
        ~DataProvider()
        {
            _connection.Close();
        }

        public string GetRobots()
        {
            if (!IsOpened())
                return null;

            SqlCommand command = new SqlCommand();
            command.Connection = _connection;
            command.CommandText = "SELECT * FROM Robot";

            // 1. varianta
            /*
            var reader = command.ExecuteReader();

            string returnValue = String.Empty;
            while(reader.Read())
            {
                returnValue += reader["Identification"].ToString().TrimEnd();
            }
             */

            // 2. varianta
            StringBuilder stringer = new StringBuilder();
            DataSet dataSet = new DataSet();

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataSet);

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                stringer.AppendFormat("robot s názvem {0} je na místě {1}",
                    row["Identification"].ToString().TrimEnd(),
                    row["Place"].ToString().TrimEnd());
                stringer.AppendLine();
            }

            return stringer.ToString();
        }

        private bool IsOpened()
        {
            bool isOpened = false;
            if (_connection.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    _connection.Open();
                    isOpened = true;
                }
                catch (Exception ex)
                {
                    //TODO: Write sql exception to log
                }
            }
            else
                isOpened = true;

            return isOpened;
        }
    }
}