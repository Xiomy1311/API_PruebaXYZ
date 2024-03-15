using API_Usuarios_XYZ.Entities;
using API_Usuarios_XYZ.Repository.Interfaces;
using API_Usuarios_XYZ.Util;
using System.Data;

namespace API_Usuarios_XYZ.Repository.Implementation
{
    public class RepUsers : IRepUsers

    {
        readonly ConexionDB repConexionDB;
        readonly Dictionary<string, string> paremeters;

        public RepUsers()
        {
            repConexionDB = new ConexionDB();
            paremeters = new Dictionary<string, string>();


        }

        public bool GetUserByUserName(string userName, string passWord)
        {
            paremeters.Add("@UserName", userName);
            paremeters.Add("@Pass", passWord);

            DataTable dt = repConexionDB.GetData("GetUserByUserName", paremeters);

            return dt.Rows.Count > 0;

        }




    }
}
