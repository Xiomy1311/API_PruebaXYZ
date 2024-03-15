using API_Usuarios_XYZ.Modules;

namespace API_Usuarios_XYZ.Repository.Interfaces
{
    public interface IRepComments
    {
        /// <summary>
        /// insert commments
        /// </summary>
        /// <returns>string</returns>
        public string InsertComments();

        /// <summary>
        /// update comments
        /// </summary>
        /// <param name="modComments"></param>
        /// <returns>int</returns>
        public int UpdatedComments(ModComments modComments);

        /// <summary>
        /// delete comments
        /// </summary>
        /// <param name="id"></param>
        /// <returns>int</returns>
        public int DeleteComments(string id);
        /// <summary>
        /// get comments
        /// </summary>
        /// <returns>list</returns>
        public List<ModComments>? GetComments();
    }
}
