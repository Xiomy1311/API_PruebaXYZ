using API_Usuarios_XYZ.Modules;
using API_Usuarios_XYZ.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace API_Usuarios_XYZ.Controllers
{
    public class PostsController : Controller
    {
        private readonly IRepPosts _repPosts;
       

        public PostsController(IRepPosts repPosts)
        {

            _repPosts = repPosts;

            
        }

        [HttpPost("Ingresar Posts")]
        public ActionResult InsertPosts()
        {

            var result = _repPosts.InsertPosts();

            if (string.IsNullOrEmpty(result))
            {
                return BadRequest("Error inesperado");
            }

            else
            {
                return Ok(" insercion ok");
            }


        }


        [HttpGet("Get Posts")]
        public ActionResult GetPosts()
        {

            List<ModPosts>? listModPosts = _repPosts.GetPosts();


            if (listModPosts?.Count > 0)
            {
                return Ok(listModPosts);
                
            }

            else
            {
                return BadRequest("No se encontraron registros");
            }


        }

     
        [HttpPut("Actualizar posts")]
        public ActionResult UpdatPosts(ModPosts modPosts)
        {

            int result = _repPosts.UpdatedPosts(modPosts);

            if (result == -1)
            {
                return BadRequest("Error inesperado");
            }

            else
            {
                return Ok("post actualizado");
            }


        }

      
        [HttpDelete("Eliminar posts")]
        public ActionResult DeletePosts(string id)
        {
            if (Convert.ToInt32(id) <= 0) { return BadRequest("Id post incorrecto"); }

            int result = _repPosts.DeletePosts(id);

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
