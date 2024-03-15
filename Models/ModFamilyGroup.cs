using FluentValidation;
using System;

namespace API_Usuarios_XYZ.Modules
{
    public class ModFamilyGroup
    {
        public int FamilyId { get; set; }
        public int UserId { get; set; }
        public string? Indetification { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public string? Relationship { get; set; }
        public int Age { get; set; }
        public bool Younger { get; set; }
        public string? Birthdate { get; set; }
        public DateTime? Date { get; set; }
    }


    public  class ModFamilyGroupValidator : AbstractValidator<ModFamilyGroup>
    {
        public  ModFamilyGroupValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty();
            RuleFor(x => x.Indetification).NotNull().NotEmpty();
            RuleFor(x => x.Name).Length(0, 15).NotNull().NotEmpty();
            RuleFor(x => x.LastName).Length(0, 15).NotNull().NotEmpty();
            RuleFor(x => x.Age).NotNull().NotEmpty();
        }
    }
}
