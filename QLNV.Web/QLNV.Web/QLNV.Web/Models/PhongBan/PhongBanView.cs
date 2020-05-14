using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QLNV.Web.Models.PhongBan
{
    public class PhongBanView
    {
        public int ID { get; set; }
        [Display(Name = "Mã Phòng Ban")]
        public string MaPhongBan { get; set; }

        [Display(Name = "Tên Phòng Ban")]
        public string TenPhongBan { get; set; }

        [Display(Name = "Tổng Số Nhân Viên")]
        public int TongSoNhanVien { get; set; }
    }
}
