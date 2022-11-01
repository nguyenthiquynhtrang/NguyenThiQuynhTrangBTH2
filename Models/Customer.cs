using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace NguyenThiQuynhTrangBTH2.Models;

    public class Customer
    {
        //Khai bao cac thuoc tinh 
        [Key]
        [Required(ErrorMessage = "Mã khách hàng không được để trống")]
        public string CustomerID { get; set;}
        [Required(ErrorMessage = "Họ tên khách hàng không được để trống")]
        [MinLength(3)]
         public string CustomerName { get; set;}
    }