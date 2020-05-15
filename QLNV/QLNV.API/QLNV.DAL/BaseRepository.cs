using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace QLNV.DAL
{
    public class BaseRepository
    {
        //lay duong dan het noi du lieu vao trong nay
        // protected de hieu chi su dung cho nhung bien KE THUA
        protected IDbConnection con;
        public BaseRepository()
        {
<<<<<<< HEAD
            //hello world
=======

>>>>>>> master
            string connectString = @" Data Source = YOH\SQLEXPRESS; Initial Catalog = QuanLyNhanVien; Integrated Security = True";
            //string connectString = @"Data Source=H-AITD202003001\SQLEXPRESS;Initial Catalog=QuanLyNhanVien;Integrated Security=True";
            con = new SqlConnection(connectString);
        }
    }
}
