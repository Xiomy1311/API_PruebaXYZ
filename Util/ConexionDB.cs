using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace API_Usuarios_XYZ.Util
{
    public class ConexionDB
    {
        private IConfiguration _configuration;

        public ConexionDB()
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _configuration = builder.Build();

        }

        /// <summary>
        /// get data SP
        /// </summary>
        /// <param name="sp"></param>
        /// <param name="parameters"></param>
        /// <returns>DataTable</returns>
        public DataTable GetData(string sp, Dictionary<string, string>? parameters = null)
        {

            using SqlConnection conn = new(_configuration.GetConnectionString("ConexionBD").ToString());
            conn.Open();
            SqlCommand cmd = new(sp, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            if (parameters != null)
            {
                foreach (KeyValuePair<string, string> item in parameters)
                {
                    cmd.Parameters.AddWithValue(Convert.ToString(item.Key), Convert.ToString(item.Value));
                }
            }

            DataTable dt = new();
            try
            {
                new SqlDataAdapter(cmd).Fill(dt);
            }
            catch (Exception)
            {

                throw;
            }

            conn.Close();
            return dt;


        }

        /// <summary>
        /// Execute actions Insert, Update, Delete
        /// </summary>
        /// <param name="sp"></param>
        /// <param name="parameters"></param>
        /// <returns>Int</returns>
        public int ExcuteInsDelUp(string sp, Dictionary<string, string>? parameters = null)
        {
            using SqlConnection conn = new(_configuration.GetConnectionString("ConexionBD").ToString());
            conn.Open();
            SqlCommand cmd = new(sp, conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            if (parameters != null)
            {
                foreach (KeyValuePair<string, string> item in parameters)
                {
                    cmd.Parameters.AddWithValue(Convert.ToString(item.Key), Convert.ToString(item.Value));
                }
            }


            int result;
            try
            {
                result = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception)
            {

                throw;
            }
            conn.Close();
            return result;


        }


        public string ExcuteInsertMassive(string tableName, DataTable dtName, Dictionary<string, string>? parameters = null)
        {
            using SqlConnection conn = new(_configuration.GetConnectionString("ConexionBD").ToString());

            SqlBulkCopy bulkCopy= new(conn);
            Stopwatch stopwatch = new();

            bulkCopy.DestinationTableName= tableName;

            string result;

            conn.Open();


            try
            {
             
                stopwatch.Start();
                bulkCopy.WriteToServer(dtName);
                result= "tiempo: "+ stopwatch.ElapsedMilliseconds/1000;
            }
            catch (Exception)
            {

                throw;
            }
            stopwatch.Stop();
            conn.Close();
            return result;


        }
    }
}

