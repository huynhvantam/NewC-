using System;
using System.Collections.Generic;
using System.Text;

namespace QLV.Domain.Response
{
   public class PhongBan
    {
        // khi truy van thi sẽ sử dụng phòng ban
        public int ID { get; set; }
        public string MaPhongBan { get; set; }
        public string TenPhongBan { get; set; }

    }
}
