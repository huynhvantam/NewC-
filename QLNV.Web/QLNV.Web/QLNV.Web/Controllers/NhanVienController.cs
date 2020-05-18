﻿using System;
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
        private static int phongBanId = 0;
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
            ViewBag.TenPhongBan = DanhSachPhongBan().Where(p => p.ID == id).FirstOrDefault().TenPhongBan;
            return View(nhanviens);
        }
        public IActionResult TaoNhanVien()
        {
            ViewBag.PhongBans = DanhSachPhongBan();
            ViewBag.PhongBanId = phongBanId;
            return View();
        }

        [HttpPost]
        public IActionResult TaoNhanVien(TaoNhanVien model)
        {
            int ketQua = 0;
            var url = $"{Common.Common.ApiUrl}/nhanvien/taonhanvien";

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWrite = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(model);
                streamWrite.Write(json);
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var resKetQua = streamReader.ReadToEnd();
                ketQua = int.Parse(resKetQua);
            }
            if (ketQua > 0)
            {
                TempData["ThanhCong"] = "TeamData-đã tạo thành công";
            }
            ModelState.Clear();
            ViewBag.PhongBans = DanhSachPhongBan();
            ViewBag.PhongBanId = phongBanId;
            return View(new TaoNhanVien() { });

        }

        public IActionResult SuaNhanVien(int id)
        {
            var nhanvien = new SuaNhanVien();
            var url = $"{Common.Common.ApiUrl}/nhanvien/laynhanvien/{id}";
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
                nhanvien = JsonConvert.DeserializeObject<SuaNhanVien>(responseData);
            }
            ViewBag.PhongBans = DanhSachPhongBan();
            ViewBag.PhongBanId = phongBanId;
            TempData["ThanhCong"] = null;
            TempData["Loi"] = null;

            return View(nhanvien);
        }
        [HttpPost]
        public IActionResult SuaNhanVien(SuaNhanVien model)
        {
            int editResult = 0;
            //var url = $"{Common.Common.ApiUrl}/phongban/suaphongban";

            //HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            var httpWebRequest = (HttpWebRequest)WebRequest.Create($"{Common.Common.ApiUrl}/nhanvien/suanhanvien");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";
            using (var streamWrite = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(model);
                streamWrite.Write(json);
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                editResult = int.Parse(result);
            }
            ViewBag.PhongBans = DanhSachPhongBan();
            ViewBag.PhongBanId = phongBanId;
            if (editResult <= 0)
            {
                TempData["Loi"] = "TeamData sửa  KHÔNG thành công";
                return View(model);
            }
            else
            {
                TempData["ThanhCong"] = "TeamData-đã sửa thành công";
                ModelState.Clear();
                return View(new SuaNhanVien() { PhongBanId = phongBanId });
            }

        }
        public IActionResult XoaNhanVien(int id)
        {
            var ketQua = false;
            var url = $"{Common.Common.ApiUrl}/nhanvien/xoanhanvien/{id}";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "DELETE";
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
                ketQua = JsonConvert.DeserializeObject<bool>(responseData);
            }
            return RedirectToAction("Index", "NhanVien", new { id = phongBanId });

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