namespace ProGestor.Common.Dtos;

public class ProjectDTO
{
    public int Id { get; set; }
    public string ProjectTypeName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateProjectStart { get; set; }
    public DateTime DateProjectEnd { get; set; }
    public string StatusProjectName { get; set; }
    public double Quoter { get; set; }
    public bool Status { get; set; }
}