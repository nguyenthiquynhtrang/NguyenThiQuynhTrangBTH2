using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace NguyenThiQuynhTrangBTH2.Models;

    public class Student
    {
        //Khai bao cac thuoc tinh 
        [Key]
        [Required(ErrorMessage = "Mã sinh viên không được để trống")]
        public string StudentID { get; set;}
        [Required(ErrorMessage = "Họ tên sinh viên không được để trống")]
        [MinLength(3)]
        public string StudentName { get; set;}
    }
    
