using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeCRUD.Models
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public string Department_code { get; set; }

        [Column("Department")]
        public string Department_Name { get; set; }
    }
}