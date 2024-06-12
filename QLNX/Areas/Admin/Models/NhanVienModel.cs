using QLNX.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
namespace QLNX.Areas.Admin.Models
{
    public class NhanVienModel
    {
        //public class listNhanVien
        //{
        //    public List<NhanVienModel> getNhanVien(string str)
        //    {
        //        string sql;
        //        if (string.IsNullOrEmpty(str))
        //        {
        //            sql = "Select * from NHANVIEN";
        //        }
        //        else
        //        {
        //            sql = "Select * from NHANVIEN where MANV =" + str;
        //        }
        //        List<NhanVienModel> strList = new List<NhanVienModel>();
        //        SqlConnection con = db.getConnection();
        //        SqlDataAdapter cmd = new SqlDataAdapter(sql, con);
        //        DataTable dt = new DataTable();
        //        //mở kết nối
        //        con.Open();
        //        cmd.Fill(dt);
        //        //đóng kết nối
        //        cmd.Dispose();
        //        con.Close();

        //        NhanVienModel strNV;
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            strNV = new NhanVienModel();
        //            strNV.id = dt.Rows[i]["MANV"].ToString();
        //            strNV.hoTen = dt.Rows[i]["HOTENNV"].ToString();
        //            strNV.soDienThoai = dt.Rows[i]["SDTNV"].ToString();
        //            strNV.chucVu = dt.Rows[i]["CHUCVU"].ToString();
        //            strNV.cmnd = dt.Rows[i]["CMND"].ToString();
        //            strNV.trangThai = dt.Rows[i]["TRANGTHAINV"].ToString();

        //            strList.Add(strNV);
        //        }
        //        return strList;
        //    }
        //}

    }
}