using System.ComponentModel.DataAnnotations;

namespace ProGestor.Common.Entities;

public class ProjectType:BaseEntity
{
    [Required(ErrorMessage = "Debe agregar el tipo")]
    public string name { get; set; }
    [Required(ErrorMessage = "Debe agregar una breve descripción")]
    public string description { get; set; }
    public bool Status { get; set; }
    public ICollection<Project> Projects { get; set; }
}