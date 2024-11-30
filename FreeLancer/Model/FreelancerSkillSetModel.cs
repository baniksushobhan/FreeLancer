using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//public class FreelancerSkillsetModel
//{
//    [Key]
//    public int FreelancerSkillSetId { get; set; }

//    // Corrected ForeignKey usage
//    [ForeignKey("Freelancer")]
//    public int FreelancerId { get; set; }

//    public FreelancerModel Freelancer { get; set; }

//    // Corrected ForeignKey usage
//    [ForeignKey("Skillset")]
//    public int SkillsetId { get; set; }

//    public SkillsetModel Skillset { get; set; }
//}

public class FreelancerSkillsetModel
{
    [Key]
    public int Id { get; set; }
    public string SkillName { get; set; }

    public int FreelancerId { get; set; }
    public FreelancerModel Freelancer { get; set; }
}
