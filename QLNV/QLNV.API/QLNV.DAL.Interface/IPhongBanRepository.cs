using QLV.Domain;
using QLV.Domain.Request;
using QLV.Domain.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLNV.DAL.Interface
{
   public interface IPhongBanRepository
    {
        // PhongBan o trong Domain ==> muon su dung phai add lien ket
        IList<PhongBan> DanhSachPhongBan();
        // tuong tu trong SQL co 5 SP thi viet het

        // truyen Id vao phai trung KDL
        PhongBan LayPhongBanID(int Id);
        //
        int TaoPhongBan(TaoPhongBan request);
        int SuaPhongBan(SuaPhongBan request);
        bool XoaPhongBan(int Id);
    }
}
