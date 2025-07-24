using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeCRUD.Models
{
    public class EmployeeViewModel
    {
        [Column("SESA ID")]
        public string SESA_ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public DateTime Birth_date { get; set; }
    }
}