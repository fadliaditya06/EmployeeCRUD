using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeCRUD.Models
{
    [Table("Gender")]
    public class Gender
    {
        [Key]
        [Column("Gender")]
        public string Gender_Code { get; set; }

        public string Gender_nm { get; set; }
    }
}