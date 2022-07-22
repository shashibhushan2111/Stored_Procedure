using System.ComponentModel.DataAnnotations;
namespace Stored_Procedure.Models
{
    public class Student
    {
        [Key]
        public int ID { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Div { get; set; }
    }
}
