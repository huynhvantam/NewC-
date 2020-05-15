using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QLNV.Web.Models.NhanVien;

namespace QLNV.Web.Controllers
{
    public class NhanVienController : Controller
    {
        private int phongBanId = 0;
        public IActionResult Index(int id)
        {
                var nhanviens = new List<NhanVienView>();
            var url = $"{Common.Common.ApiUrl}/nhanvien/danhsachnhanvientheophongban/{id}";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "GET";
            var response = httpWebRequest.GetResponse();
            {
                string responseData;
                Stream responseStream = response.GetResponseStream();
                try
                {
                    StreamReader streamReader = new StreamReader(responseStream);
                    try
                    {
                        responseData = streamReader.ReadToEnd();
                    }
                    finally
                    {
                        ((IDisposable)streamReader).Dispose();
                    }
                }
                finally
                {
                    ((IDisposable)responseStream).Dispose();
                }
                nhanviens = JsonConvert.DeserializeObject<List<NhanVienView>>(responseData);
            }
            phongBanId = id;
            ViewBag.TenPhongBan = DanhSachPhongBan().Where(p=>p.ID==id).FirstOrDefault().TenPhongBan;
            return View(nhanviens);
        }
        public IActionResult TaoNhanVien()
        {
            return View();

        }
        private List<PhongBanItem> DanhSachPhongBan()
        {
            var phongbans = new List<PhongBanItem>();
            var url = $"{Common.Common.ApiUrl}/phongban/danhsachphongban";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "GET";
            var response = httpWebRequest.GetResponse();
            {
                string responseData;
                Stream responseStream = response.GetResponseStream();
                try
                {
                    StreamReader streamReader = new StreamReader(responseStream);
                    try
                    {
                        responseData = streamReader.ReadToEnd();
                    }
                    finally
                    {
                        ((IDisposable)streamReader).Dispose();
                    }
                }
                finally
                {
                    ((IDisposable)responseStream).Dispose();
                }
                phongbans = JsonConvert.DeserializeObject<List<PhongBanItem>>(responseData);
            }
            return phongbans;
        }
    }


}