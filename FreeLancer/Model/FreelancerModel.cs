using System.ComponentModel.DataAnnotations;
public class FreelancerModel
{
    [Key]
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsArchived { get; set; }

    public ICollection<FreelancerSkillsetModel> Skillsets { get; set; }
    public ICollection<FreelancerHobbyModel> Hobbies { get; set; }
}