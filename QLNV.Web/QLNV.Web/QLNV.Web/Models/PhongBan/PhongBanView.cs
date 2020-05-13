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
        [Display(Name = "Ma Phong ban")]
        public string MaPhongBan { get; set; }
        public string TenPhongBan { get; set; }
        public int TongSoNhanVien { get; set; }
    }
}
