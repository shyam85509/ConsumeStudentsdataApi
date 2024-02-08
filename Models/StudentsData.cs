using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ConsumeWebApi.Models
{
    public class StudentsData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int recordId { get; set; }
        public int RollNo { get; set; }
        public string Name { get; set; }
        public string EmailID { get; set; }
        public string Password { get; set; }
        public byte Age { get; set; }
        public DateTime Dob { get; set; }
        public decimal fee { get; set; }
        public string Dept { get; set; }
        public Boolean status { get; set; }
        public string role { get; set; }
    }
}
