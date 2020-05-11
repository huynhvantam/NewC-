using System;

namespace QLV.Domain.Request
{
    public class TaoPhongBan
    {
        // khi tạo mới phòng ban
        //trong SP có bao nhiêu thông số thì khai báo cho bằng
        public int ID { get; set; }
        public string MaPhongBan { get; set; }
        public string TenPhong { get; set; }
    }
}
