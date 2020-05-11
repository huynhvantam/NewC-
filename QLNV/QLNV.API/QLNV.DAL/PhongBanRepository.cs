using Dapper;
using QLNV.DAL.Interface;
using QLV.Domain;
using QLV.Domain.Request;
using QLV.Domain.Response;
using System;
using System.Collections.Generic;

namespace QLNV.DAL
{
    // su dung da ke thua de them cac Interface vao
    public class PhongBanRepository : BaseRepository, IPhongBanRepository
    {
        // duong dan ket noi CSDL
        public IList<PhongBan> DanhSachPhongBan()
        {
            try
            {
                // DynamicParameters de truyen soure
                DynamicParameters
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public PhongBan LayPhongBanID(int Id)
        {
            throw new NotImplementedException();
        }

        public int SuaPhongBan(SuaPhongBan request)
        {
            throw new NotImplementedException();
        }

        public int TaoPhongBan(TaoPhongBan request)
        {
            throw new NotImplementedException();
        }

        public bool XoaPhongBan(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
