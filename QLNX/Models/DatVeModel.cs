using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QLNX.DB;
using System.ComponentModel.DataAnnotations;

namespace QLNX.Models
{
    public class DatVeModel
    {
        // table phôi xe
        public string MAPHOI { get; set; }
        public string TRANGTHAIPHOI { get; set; }
        public DateTime NGAYDATVE { get; set; }


        //talbe xe
        public int MAXE { get; set; }
        public decimal GIAVE { get; set; }

        //table lịch
        public string MALICH { get; set; }

        
        //table ghế
        public int MAGHE { get; set; }
        public string TENGHE { get; set; }
        public int HANG { get; set; }
        public int COT { get; set; }

        public string chuoiId { get; set; }
        public string ghedachon { get; set; }
        public decimal tongtien { get; set; }

    }
    
        
}