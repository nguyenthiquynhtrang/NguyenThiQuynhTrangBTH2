using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace NguyenThiQuynhTrangBTH2.Models;

    public class Employee
    {
        //Khai bao cac thuoc tinh 
        [Key]
        [Required(ErrorMessage = "Mã nhân viên không được để trống")]
        public string EmployeeID { get; set; }
        [Required(ErrorMessage = "Họ tên nhân viên không được để trống")]
        [MinLength(3)]
        public string EmployeeName { get; set; }
    }
      