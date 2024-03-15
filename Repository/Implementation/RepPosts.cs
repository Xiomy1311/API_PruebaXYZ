using API_Usuarios_XYZ.Entities;
using API_Usuarios_XYZ.Modules;
using API_Usuarios_XYZ.Repository.Interfaces;
using API_Usuarios_XYZ.Util;
using System.Collections.Generic;
using System.Data;
using System.Text.Json;


namespace API_Usuarios_XYZ.Repository.Implementation
{
    public class RepPosts: IRepPosts
    {
        readonly ConexionDB repConexionDB;
        readonly Dictionary<string, string> paremeters;

        public RepPosts()
        {
            repConexionDB = new ConexionDB();
            paremeters = new Dictionary<string, string>();


        }


        public string InsertPosts()
        {
            var result = "";

            DataTable dt_Posts = new();

            List<ModPosts>? modPosts = GetPostsUrl()?.Result;

            dt_Posts.Columns.Add(new DataColumn("UserID", typeof(int)));
            dt_Posts.Columns.Add(new DataColumn("Id", typeof(int)));
            dt_Posts.Columns.Add(new DataColumn("Tittle", typeof(string)));
            dt_Posts.Columns.Add(new DataColumn("Body", typeof(string)));
     

            if (modPosts?.Count>0)
            {

                for (int i = 0; i < modPosts?.Count; i++)
                {
                    DataRow dr = dt_Posts.NewRow();
                    dr["UserID"]= modPosts[i]?.userId;
                    dr["Id"] = modPosts[i]?.id;
                    dr["Tittle"] = modPosts[i]?.title;
                    dr["Body"] = modPosts[i]?.body;

                    dt_Posts.Rows.Add(dr);

                }

                result = repConexionDB.ExcuteInsertMassive("dt_Posts", dt_Posts);
            }

            return result;
        }



        public int UpdatedPosts(ModPosts modPosts)
        {
            var result = -1;

            if (modPosts.id.ToString().Length != 0)
            {
         
                paremeters.Add("@Id", Convert.ToString(modPosts.id));
                paremeters.Add("@Tittle", modPosts.title.Trim());
                paremeters.Add("@Body", modPosts.body.Trim());
                

                result = repConexionDB.ExcuteInsDelUp("UpdatePosts", paremeters);
            }

            return result;
        }

        public int DeletePosts(string id)
        {
            var result = -1;

            if (id.Length != 0)
            {

                paremeters.Add("@Id", id);


                result = repConexionDB.ExcuteInsDelUp("DeletePosts", paremeters);
            }

            return result;
        }

        public List<ModPosts>? GetPosts()
        {
            DataTable dt = repConexionDB.GetData("GetPosts");

            if (dt.Rows.Count == 0)
            {
                return null;
            }

            List<ModPosts> listModPosts = new();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ModPosts modPosts = new()
                {

                    id = Convert.ToInt32(dt.Rows[i]["Id"].ToString()),
                    userId = Convert.ToInt32(dt.Rows[i]["UserId"].ToString()),
                    title = dt.Rows[i]["Tittle"].ToString(),
                    body = dt.Rows[i]["Body"].ToString(),
                   

                };

                listModPosts.Add(modPosts);

            }

            return listModPosts;
        }



        static  async Task<List<ModPosts>?> GetPostsUrl()
        {
            List<ModPosts>? posts = null;

            string url = "https://jsonplaceholder.typicode.com/posts";

            HttpClient client = new();

            var result = await client.GetAsync(url);

            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                posts= JsonSerializer.Deserialize<List<ModPosts>>(content);


            }

            return posts;


        }
    }
}


