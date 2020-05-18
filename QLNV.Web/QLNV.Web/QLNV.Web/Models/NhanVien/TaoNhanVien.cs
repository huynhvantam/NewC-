using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLNV.Web.Models.NhanVien
{
    public class TaoNhanVien
    {
       
        [Display(Name = "Họ")]
        [Required(ErrorMessage = "Required Bạn phải nhập Họ")]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = " Họ phải có 50 ký tự")]
        public string Ho { get; set; }

        [Display(Name = "Tên")]
        [Required(ErrorMessage = "Required Bạn phải nhập Tên")]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Tên phải có 50 ký tự")]
        public string Ten { get; set; }
        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Required Bạn phải nhập Địa chỉ")]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Địa chỉ phải có 50 ký tự")]
        public string DiaChi { get; set; }
        [Display(Name = "Điện thoại")]
        [Required(ErrorMessage = "Required Bạn phải nhập Điện thoại")]
        [Phone(ErrorMessage ="không hợp lệ")]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = " Điện thoại phải có 50 ký tự")]
        public string DienThoai { get; set; }
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage ="Email không đúng định dạng")]
        public string Email { get; set; }
        [Display(Name = "Phòng ban ID")]
        public int PhongBanId { get; set; }
    }
}
