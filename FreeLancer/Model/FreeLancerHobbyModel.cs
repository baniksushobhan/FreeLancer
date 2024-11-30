using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



public class FreelancerHobbyModel
{
    [Key]
    public int Id { get; set; }
    public string HobbyName { get; set; }

    public int FreelancerId { get; set; }
    public FreelancerModel Freelancer { get; set; }
}