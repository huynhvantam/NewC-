using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QLNV.Web.Common;
using QLNV.Web.Models;
using QLNV.Web.Models.PhongBan;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace QLNV.Web.Controllers
{
    public class PhongBanController : Controller
    {
        public IActionResult Index()
        {
            var phongbans = new List<PhongBanView>();
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
                phongbans = JsonConvert.DeserializeObject<List<PhongBanView>>(responseData);
            }
            return View(phongbans);

        }

        public IActionResult TaoPhongBan()
        {
            TempData["ThanhCong"] = null;
            return View();
        }
        public IActionResult TaoPhongBan(TaoPhongBan model)
        {
            int ketQua = 0;
            var url = $"{Common.Common.ApiUrl}/phongban/taophongban";

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWrite = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(model);
                streamWrite.Write(json);
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var resKetQua = streamReader.ReadToEnd();
                    ketQua = int.Parse(resKetQua);
                }
                if (ketQua > 0)
                {
                    TempData["ThanhCong"] = "TeamData-đã tạo thành công";
                }
                return View(new TaoPhongBan() { });
            }
        }
    }
}
