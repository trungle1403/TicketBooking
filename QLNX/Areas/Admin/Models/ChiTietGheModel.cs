using QLNX.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace QLNX.Areas.Admin.Models
{
    public partial class ChiTietGheModel
    {
        quanlynhaxeEntities db = new quanlynhaxeEntities();
        SqlConnection con = new SqlConnection("data source=TRUNGPC;initial catalog=quanlynhaxe;user id=sa;password=123456;integrated security = SSPI;");
        SqlCommand cmd = new SqlCommand();
        public string MAPHOI { get; set; }
        public int MAGHE { get; set; }

        public void CreateChiTietGhe(string maPhoi, int maGhe)
        {
            db.Database.SqlQuery<ChiTietGheModel>(
                "INSERT INTO CHITIETGHE(MAPHOI, MAGHE) VALUES (@maphoi,@maghe)",
                new SqlParameter("@maphoi", maPhoi),
                new SqlParameter("@maghe", maGhe)
            ).FirstOrDefault();
        }


    }
}