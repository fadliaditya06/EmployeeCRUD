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

        [Required] public string Name { get; set; }
        [Required][DataType(DataType.Date)] public DateTime Birth_date { get; set; }
        [Required] public string Gender { get; set; }
    }

    [Table("Department")]
    public class Department
    {
        [Key] public string Department_code { get; set; }
        [Column("Department")]
        public string Department_Name { get; set; }
    }

    [Table("Gender")]
    public class Gender
    {
        [Key]
        [Column("Gender")]
        public string Gender_Code { get; set; }
        public string Gender_nm { get; set; }
    }

    [Table("Employee_dept")]
    public class EmployeeDept
    {
        [Key]
        [Column("SESA ID")] 
        public string SESA_ID { get; set; }
        public string Department_code { get; set; }
    }

    public class EmployeeViewModel
    {
        [Column("SESA ID")] 
        public string SESA_ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public DateTime Birth_date { get; set; }
    }

    public class EmployeeFormModel
    {
        [Column("SESA ID")] 
        [Required(ErrorMessage = "SESA ID wajib diisi.")]
        public string SESA_ID { get; set; }

        [Required(ErrorMessage = "Nama wajib diisi.")] public string Name { get; set; }
        [Required(ErrorMessage = "Tanggal Lahir wajib diisi.")] public DateTime Birth_date { get; set; }
        [Required(ErrorMessage = "Gender wajib dipilih.")] public string Gender { get; set; }
        [Required(ErrorMessage = "Departemen wajib dipilih.")] public string Department_code { get; set; }
    }
}