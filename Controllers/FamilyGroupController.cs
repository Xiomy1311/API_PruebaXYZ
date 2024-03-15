
using API_Usuarios_XYZ.Modules;
using API_Usuarios_XYZ.Repository.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection.Metadata.Ecma335;


namespace API_Usuarios_XYZ.Controllers
{
    [ApiController]
    [Route("api/family")]
    public class FamilyGroupController : ControllerBase
    {

        private readonly IRepGroupFamily _repGroupFamily;
        private readonly IValidator<ModFamilyGroup> _validator;

        public FamilyGroupController( IRepGroupFamily repGroupFamily,   IValidator<ModFamilyGroup>  validator)
        {

            _repGroupFamily = repGroupFamily;
            _validator = validator;
        }


        [Authorize]
        [HttpPost("Ingresar grupo familiar")]
        public ActionResult InsertFamilyGroup(ModFamilyGroup modFamilyGroup)
        {
            ValidationResult validationResult =  _validator.Validate(modFamilyGroup);

            if (validationResult.IsValid)
            {

                var result = _repGroupFamily.InsertFamilyGroup(modFamilyGroup);

                if (result == -1)
                {
                    return BadRequest("Error inesperado");
                }

                else
                {
                    return Ok("familia registrada");
                }
            }

            else
            {
                return BadRequest(validationResult.Errors);
            }


        }

        [Authorize]
        [HttpPut("Actualizar grupo familiar")]
        public ActionResult UpdatFamilyGroup(ModFamilyGroup modFamilyGroup)
        {

            int result = _repGroupFamily.UpdatedFamilyGroup(modFamilyGroup);

            if (result == -1)
            {
                return BadRequest("Error inesperado");
            }

            else
            {
                return Ok("familia actualizada");
            }


        }

        [Authorize]
        [HttpDelete("Eliminar grupo familiar")]
        public ActionResult DeleteFamilyGroup(string userId)
        {
            if (Convert.ToInt32(userId) <= 0) { return BadRequest("Id usuario incorrecto"); }

            int result = _repGroupFamily.DeleteFamilyGroup(userId);

            if (result == -1)
            {
                return BadRequest("Error inesperado");
            }

            else
            {
                return Ok("registro eliminado");
            }


        }

        [Authorize]
        [HttpGet("GetFamily")]
        public ActionResult GetFamily()
        {

            List<ModFamilyGroup>? ListFamilyGroup = new();

            ListFamilyGroup = _repGroupFamily.GetUserFamily();


            if (ListFamilyGroup?.Count > 0)
            {

                return Ok(ListFamilyGroup);

            }

            else
            {
                return BadRequest("No se encontraron registros");

            }

        }
    }
}
