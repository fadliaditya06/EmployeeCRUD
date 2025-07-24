using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeCRUD.Models
{
    public class EmployeeFormModel
    {
        [Column("SESA ID")]
        [Required(ErrorMessage = "SESA ID wajib diisi.")]
        public string SESA_ID { get; set; }

        [Required(ErrorMessage = "Nama wajib diisi.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Tanggal Lahir wajib diisi.")]
        public DateTime Birth_date { get; set; }

        [Required(ErrorMessage = "Gender wajib dipilih.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Departemen wajib dipilih.")]
        public string Department_code { get; set; }
    }
}