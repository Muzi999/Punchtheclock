using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPIT.ClockIn.Web.ViewModel
{
    public class CardViewModel
    {
        public string C_Name { get; set; }
        public DateTime C_AddTime { get; set; }
        public DateTime C_EndTime { get; set; }
        public string C_Task { get; set; }
        public string C_Evaluate { get; set; }
        public int page { get; set; }
        public int limit { get; set; }
  
    }
}