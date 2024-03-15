using API_Usuarios_XYZ.Entities;
using API_Usuarios_XYZ.Modules;

namespace API_Usuarios_XYZ.Repository.Interfaces
{
    public interface IRepPosts
    {

        /// <summary>
        /// insert posts
        /// </summary>
        /// <returns>string</returns>
        public string InsertPosts();

        /// <summary>
        /// update posts
        /// </summary>
        /// <param name="modPosts"></param>
        /// <returns>int</returns>
        public int UpdatedPosts(ModPosts modPosts);

        /// <summary>
        /// delete posts
        /// </summary>
        /// <param name="id"></param>
        /// <returns>int</returns>
        public int DeletePosts(string id);

        /// <summary>
        /// get posts
        /// </summary>
        /// <returns>lists</returns>
        public List<ModPosts>? GetPosts();


    }
}
