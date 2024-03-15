using API_Usuarios_XYZ.Entities;
using API_Usuarios_XYZ.Modules;

namespace API_Usuarios_XYZ.Repository.Interfaces
{
    public interface IRepGroupFamily
    {

        public List<ModFamilyGroup>? GetUserFamily();

        /// <summary>
        /// Insert family group by user
        /// </summary>
        /// <param name="modFamilyGroup"></param>
        /// <returns>int</returns>
        public int InsertFamilyGroup(ModFamilyGroup modFamilyGroup);

        /// <summary>
        /// Update family group by user
        /// </summary>
        /// <param name="modFamilyGroup"></param>
        /// <returns>int</returns>
        public int UpdatedFamilyGroup(ModFamilyGroup modFamilyGroup);

        /// <summary>
        /// Delete family group by user
        /// </summary>
        /// <param name="modFamilyGroup"></param>
        /// <returns>int</returns>
        public int DeleteFamilyGroup(string UserId);

    }
}
