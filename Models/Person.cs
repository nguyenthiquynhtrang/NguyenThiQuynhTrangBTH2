using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace NguyenThiQuynhTrangBTH2.Models;

    public class Person
    {
        //Khai bao cac thuoc tinh 
        [Key]
        [Required(ErrorMessage = "ID không được để trống")]
        public string PersonID { get; set;}
        [Required(ErrorMessage = "Họ tên không được để trống")]
        [MinLength(3)]
        public string PersonName { get; set;}
    }