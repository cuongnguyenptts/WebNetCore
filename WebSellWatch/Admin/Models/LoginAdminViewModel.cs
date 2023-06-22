using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebSellWatch.Areas.Admin.Models
{
    public class LoginAdminViewModel
    {
        [Key]
        [MaxLength(100)]
        [Required(ErrorMessage = ("Vui lòng nhập Email"))]
        [Display(Name = "Địa chỉ Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Sai định dạng Email")]
        public string UserName { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [MinLength(6, ErrorMessage = "Bạn cần đặt mật khẩu tối thiểu 6 ký tự")]
        public string Password { get; set; }
    }
}
