using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLNV.BAL;
using QLNV.BAL.Interface;
using QLV.Domain.Request;
using QLV.Domain.Response;

namespace QLNV.API.Controllers
{

    [ApiController]
    public class PhongBanController : ControllerBase
    {
        private readonly IPhongBanService _phongBanService;
        public PhongBanController(IPhongBanService phongBanService)
        {
            _phongBanService = phongBanService;
        }
        /// <summary>
        /// aaaaaa
        /// </summary>
        /// <returns></returns>
        // GET: api/PhongBan
        [HttpGet]
        [Route("api/phongban/danhsachphongban")]
        public IEnumerable<PhongBan> DanhSachPhongBan()
        {
            return _phongBanService.DanhSachPhongBan();
        }

        /// <summary>
        /// bbbbbbbbb
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/PhongBan/5
        [HttpGet]
        [Route("api/phongban/layphongban/{id}")]
        public PhongBan LayPhongBanID(int id)
        {
            return _phongBanService.LayPhongBanID(id);
        }
        /// <summary>
        /// cccccccc
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        // POST: api/PhongBan
        [HttpPost]
        [Route("api/phongban/taophongban")]
        public int TaoPhongBan([FromBody] TaoPhongBan request)
        {
            return _phongBanService.TaoPhongBan(request);
        }
        /// <summary>
        /// dddddd
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        // PUT: api/PhongBan/5
        [HttpPut]
        [Route("api/phongban/suaphongban")]
        public int SuaPhongBan([FromBody] SuaPhongBan request)
        {
            return _phongBanService.SuaPhongBan(request);
        }
        /// <summary>
        /// eeeeeeee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        [Route("api/phongban/xoaphongban/{id}")]
        public bool XoaPhongBan(int id)
        {
            return _phongBanService.XoaPhongBan(id);
        }
    }
}
