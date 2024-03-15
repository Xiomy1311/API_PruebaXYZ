using API_Usuarios_XYZ.Entities;

namespace API_Usuarios_XYZ.Repository.Interfaces
{
    public interface IRepUsers
    {

        /// <summary>
        /// Get users by user name and pass
        /// </summary>
        /// <returns>bool</returns>
        public bool GetUserByUserName(string userName, string passWord);
    }
}
