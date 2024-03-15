
using API_Usuarios_XYZ.Modules;
using API_Usuarios_XYZ.Repository.Implementation;
using API_Usuarios_XYZ.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace API_Usuarios_XYZ.Controllers
{
    public class CommentsController : Controller
    {
        
        private readonly IRepComments _repComments;

        public CommentsController(IRepComments repComments)
        {

            _repComments= repComments;
        }

    

        [HttpPost("Ingresar Comments")]
        public ActionResult InsertComments()
        {

            var result = _repComments.InsertComments();

            if (string.IsNullOrEmpty(result))
            {
                return BadRequest("Error inesperado");
            }

            else
            {
                return Ok(" insercion ok");
            }


        }

        [HttpGet("Get Comments")]
        public ActionResult GetComments()
        {

            List<ModComments>? listModPosts = _repComments.GetComments();


            if (listModPosts?.Count > 0)
            {
                return Ok(listModPosts);

            }

            else
            {
                return BadRequest("No se encontraron registros");
            }


        }


        [HttpPut("Actualizar comments")]
        public ActionResult UpdatedComments(ModComments modComments)
        {

            int result = _repComments.UpdatedComments(modComments);

            if (result == -1)
            {
                return BadRequest("Error inesperado");
            }

            else
            {
                return Ok("post actualizado");
            }


        }


        [HttpDelete("Eliminar comments")]
        public ActionResult DeleteComments(string id)
        {
            if (Convert.ToInt32(id) <= 0) { return BadRequest("Id comment incorrecto"); }

            int result = _repComments.DeleteComments(id);

            if (result == -1)
            {
                return BadRequest("Error inesperado");
            }

            else
            {
                return Ok("registro eliminado");
            }


        }


    }
}
