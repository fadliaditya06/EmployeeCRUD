using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeCRUD.Models
{
    [Table("Employee_dept")]
    public class EmployeeDept
    {
        [Key]
        [Column("SESA ID")]
        public string SESA_ID { get; set; }

        public string Department_code { get; set; }
    }
}