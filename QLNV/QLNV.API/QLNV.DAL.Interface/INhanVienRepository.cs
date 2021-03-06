﻿using QLV.Domain.Request;
using QLV.Domain.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLNV.DAL.Interface
{
   public interface INhanVienRepository
    {
        IList<NhanVien> DanhSachNhanVienTheoPhongBan(int phongBanId);
        NhanVien LayNhanVienTheoID(int maNV);
        int TaoNhanVien(TaoNhanVien request);
        int SuaNhanVien(SuaNhanVien request);
        bool XoaNhanVien(int maNV);
    }
}
