using API_Usuarios_XYZ.Entities;
using API_Usuarios_XYZ.Modules;
using API_Usuarios_XYZ.Repository.Interfaces;
using API_Usuarios_XYZ.Util;
using System.Data;


namespace API_Usuarios_XYZ.Repository.Implementation
{
    public class RepFamilyGroup: IRepGroupFamily
    {
        readonly ConexionDB repConexionDB;
        readonly Dictionary<string, string> paremeters;

        public RepFamilyGroup()
        {
            repConexionDB = new ConexionDB();
            paremeters = new Dictionary<string, string>();


        }


        public int InsertFamilyGroup(ModFamilyGroup modFamilyGroup)
        {
            var result = -1;

            if (modFamilyGroup.UserId.ToString().Length != 0)
            {

                paremeters.Add("@UserID", Convert.ToString(modFamilyGroup.UserId));
                paremeters.Add("@Indetification ", modFamilyGroup.Indetification.Trim());
                paremeters.Add("@Name", modFamilyGroup.Name.Trim());
                paremeters.Add("@LastName", modFamilyGroup.LastName.Trim());
                paremeters.Add("@Gender", modFamilyGroup.Gender.Trim());
                paremeters.Add("@Relationship", modFamilyGroup.Relationship.Trim());
                paremeters.Add("@Age", Convert.ToString(modFamilyGroup.Age));
                paremeters.Add("@Younger", Convert.ToString(ValidateYounger(modFamilyGroup.Age)));
                paremeters.Add("@Birthdate", modFamilyGroup.Birthdate.Trim());


                result = repConexionDB.ExcuteInsDelUp("InsertFamilyGroupByUser", paremeters);
            }

            return result;
        }

        public int UpdatedFamilyGroup(ModFamilyGroup modFamilyGroup)
        {
            var result = -1;

            if (modFamilyGroup.UserId.ToString().Length != 0)
            {

                paremeters.Add("@UserID", Convert.ToString(modFamilyGroup.UserId));
                paremeters.Add("@Gender", modFamilyGroup.Gender.Trim());
                paremeters.Add("@Relationship", modFamilyGroup.Relationship.Trim());
                paremeters.Add("@Age", Convert.ToString(modFamilyGroup.Age));

                result = repConexionDB.ExcuteInsDelUp("UpdateFamilyGroupByUser", paremeters);
            }

            return result;
        }

        public int DeleteFamilyGroup(string UserId)
        {
            var result = -1;

            if (UserId.Length != 0)
            {

                paremeters.Add("@UserID", UserId);


                result = repConexionDB.ExcuteInsDelUp("DeleteFamilyGroupByUser", paremeters);
            }

            return result;
        }

        public List<ModFamilyGroup>? GetUserFamily()
        {
            DataTable dt = repConexionDB.GetData("GetUsersFamily");

            if (dt.Rows.Count == 0)
            {
                return null;
            }

            List<ModFamilyGroup> listModFamilyGroup = new();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ModFamilyGroup modFamilyGroup = new()
                {

                    UserId = Convert.ToInt32(dt.Rows[i]["UserId"].ToString()),
                    FamilyId = Convert.ToInt32(dt.Rows[i]["FamilyID"].ToString()),
                    Indetification= dt.Rows[i]["Indetification"].ToString(),
                    Name = dt.Rows[i]["Name"].ToString(),
                    LastName = dt.Rows[i]["Name"].ToString(),
                    Gender = dt.Rows[i]["Gender"].ToString(),
                    Relationship = dt.Rows[i]["Relationship"].ToString(),
                    Age = Convert.ToInt32(dt.Rows[i]["Age"].ToString()),
                    Younger = Convert.ToBoolean(dt.Rows[i]["Younger"].ToString()),
                    Birthdate = dt.Rows[i]["Birthdate"].ToString(),
                    Date= Convert.ToDateTime(dt.Rows[i]["Date"].ToString())

                };

                listModFamilyGroup.Add(modFamilyGroup);

            }

            return listModFamilyGroup;
        }

        private static bool ValidateYounger(int age)
        {
            bool isYounger = age < 18;

            return isYounger;

        }

    }
}


