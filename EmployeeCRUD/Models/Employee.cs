using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeCRUD.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        [Column("SESA ID")]
        public string SESA_ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Birth_date { get; set; }

        [Required]
        public string Gender { get; set; }
    }
}