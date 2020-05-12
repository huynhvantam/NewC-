using QLNV.BAL.Interface;
using QLNV.DAL.Interface;
using QLV.Domain.Request;
using QLV.Domain.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLNV.BAL
{
    public class NhanVienService : INhanVienService
    {
        private INhanVienRepository _nhanVienRepository;
        public NhanVienService (INhanVienRepository nhanVienRepository)
        {
            _nhanVienRepository = nhanVienRepository;
        }
        public IList<NhanVien> DachSachNhanVienTheoPhongBan(int phongbanId)
        {
           return _nhanVienRepository.DanhSachNhanVienTheoPhongBan(phongbanId);
        }

        public NhanVien LayNhanVienTheoID(int maNV)
        {
            return _nhanVienRepository.LayNhanVienTheoId(maNV);
        }

        public int SuaNhanVien(SuaNhanVien request)
        {
            return _nhanVienRepository.SuaNhanVien(request);
        }

        public int TaoNhanVien(TaoNhanVien request)
        {
            return _nhanVienRepository.TaoNhanVien(request);
        }

        public bool XoaNhanVien(int maNV)
        {
            return _nhanVienRepository.XoaNhanVien(maNV);
        }
    }
}
