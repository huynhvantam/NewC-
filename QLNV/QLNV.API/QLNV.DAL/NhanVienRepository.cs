using Dapper;
using QLNV.DAL.Interface;
using QLV.Domain.Request;
using QLV.Domain.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLNV.DAL
{
    public class NhanVienRepository : BaseRepository, INhanVienRepository
    {
              public IList<NhanVien> DanhSachNhanVienTheoPhongBan(int PhongBanId)
        {
            IList<NhanVien> danhSachNhanVienTheoPhongBan = SqlMapper.Query<NhanVien>(con, "DanhSachNhanVienTheoPhongBan", commandType: CommandType.StoredProcedure).ToList();
            return danhSachNhanVienTheoPhongBan;
        }

        public NhanVien LayNhanVienTheoId(int maNV)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@MaNV", maNV);
            NhanVien nhanVien = SqlMapper.Query<NhanVien>(con, "LayNhanVienTheoMaNV", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return nhanVien;
        }

        public int SuaNhanVien(SuaNhanVien request)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@MaNV", request.MaNV);
                parameters.Add("@Ho", request.Ho);
                parameters.Add("@Ten", request.Ten);
                parameters.Add("@DiaChi", request.DiaChi);
                parameters.Add("@DienThoai", request.DienThoai);
                parameters.Add("@Email", request.Email);
                parameters.Add("@PhongBanId", request.PhongBanId);
                var maNV = SqlMapper.ExecuteScalar<int>(con, "SuaNhanVien", param: parameters, commandType: CommandType.StoredProcedure);
                return maNV;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int TaoNhanVien(TaoNhanVien request)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@Ho", request.Ho);
                parameters.Add("@Ten", request.Ten);
                parameters.Add("@DiaChi", request.DiaChi);
                parameters.Add("@DienThoai", request.DienThoai);
                parameters.Add("@Email", request.Email);
                parameters.Add("@PhongBanId", request.PhongBanId);
                var maNV = SqlMapper.ExecuteScalar<int>(con, "TaoNhanVien", param: parameters, commandType: CommandType.StoredProcedure);
                return maNV;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool XoaNhanVien(int maNV)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@MaNV", maNV);
                var result = SqlMapper.ExecuteScalar<bool>(con, "XoaNhaVien", param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {

                throw ex ;
            }
        }
    }
}
