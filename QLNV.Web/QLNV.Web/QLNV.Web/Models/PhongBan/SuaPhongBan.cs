using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLNV.Web.Models.PhongBan
{
    public class SuaPhongBan
    {
        public int ID { get; set; }
        [Display(Name = "Display Mã Phòng Ban")]
        [Required(ErrorMessage = "Required Bạn phải nhập mã Phòng Ban")]
        [StringLength(maximumLength: 5, MinimumLength = 5, ErrorMessage = "mã phải có 5 ký tự")]
        [ReadOnly(true)]
        public string MaPhongBan { get; set; }

        [Display(Name = "Tên Phòng Ban")]
        [Required(ErrorMessage = "chưa nhập")]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "lỗi")]
        public string TenPhongBan { get; set; }
    }
}
