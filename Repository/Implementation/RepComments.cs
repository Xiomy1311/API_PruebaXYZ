using API_Usuarios_XYZ.Entities;
using API_Usuarios_XYZ.Modules;
using API_Usuarios_XYZ.Repository.Interfaces;
using API_Usuarios_XYZ.Util;
using System.Collections.Generic;
using System.Data;
using System.Text.Json;


namespace API_Usuarios_XYZ.Repository.Implementation
{
    public class RepComments : IRepComments
    {
        readonly ConexionDB repConexionDB;
        readonly Dictionary<string, string> paremeters;

        public RepComments()
        {
            repConexionDB = new ConexionDB();
            paremeters = new Dictionary<string, string>();


        }


        public string InsertComments()
        {
            var result = "";

            DataTable dt_Comments = new();

            List<ModComments>? modComments = GetCommentsUrl()?.Result;

            dt_Comments.Columns.Add(new DataColumn("PostId", typeof(int)));
            dt_Comments.Columns.Add(new DataColumn("Id", typeof(int)));
            dt_Comments.Columns.Add(new DataColumn("Name", typeof(string)));
            dt_Comments.Columns.Add(new DataColumn("Email", typeof(string)));
            dt_Comments.Columns.Add(new DataColumn("Body", typeof(string)));
     

            if (modComments?.Count>0)
            {

                for (int i = 0; i < modComments?.Count; i++)
                {
                    DataRow dr = dt_Comments.NewRow();
                    dr["PostId"]= modComments[i]?.postId;
                    dr["Id"] = modComments[i]?.id;
                    dr["Name"] = modComments[i]?.name;
                    dr["Email"] = modComments[i]?.email;
                    dr["Body"] = modComments[i]?.body;

                    dt_Comments.Rows.Add(dr);

                }

                result = repConexionDB.ExcuteInsertMassive("dt_Comments", dt_Comments);
            }

            return result;
        }

        public int UpdatedComments(ModComments? modComments)
        {
            var result = -1;

            if (modComments.id.ToString().Length != 0)
            {

                paremeters.Add("@Id", Convert.ToString(modComments.id));
                paremeters.Add("@Name", modComments.name.Trim());
                paremeters.Add("@Email", modComments.email.Trim());
                paremeters.Add("@Body", modComments.body.Trim());


                result = repConexionDB.ExcuteInsDelUp("UpdateComments", paremeters);
            }

            return result;
        }

        public int DeleteComments(string id)
        {
            var result = -1;

            if (id.Length != 0)
            {

                paremeters.Add("@Id", id);


                result = repConexionDB.ExcuteInsDelUp("DeleteComments", paremeters);
            }

            return result;
        }

        public List<ModComments>? GetComments()
        {
            DataTable dt = repConexionDB.GetData("GetComments");

            if (dt.Rows.Count == 0)
            {
                return null;
            }

            List<ModComments> listModCommentss = new();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ModComments modComments = new()
                {

                    id = Convert.ToInt32(dt.Rows[i]["Id"].ToString()),
                    postId = Convert.ToInt32(dt.Rows[i]["PostId"].ToString()),
                    name = dt.Rows[i]["Name"].ToString(),
                    email= dt.Rows[i]["Email"].ToString(),
                    body = dt.Rows[i]["Body"].ToString(),


                };

                listModCommentss.Add(modComments);

            }

            return listModCommentss;
        }

        static async Task<List<ModComments>?> GetCommentsUrl()
        {
            List<ModComments>? listComments = null;

            string url = "https://jsonplaceholder.typicode.com/comments";

            HttpClient client = new();

            var result = await client.GetAsync(url);

            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                listComments = JsonSerializer.Deserialize<List<ModComments>>(content);

            }

            return listComments;


        }
    }
}


