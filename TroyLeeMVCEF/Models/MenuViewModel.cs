using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TroyLeeMVCEF.Models
{
    public class MenuViewModel
    {
        public Guid MenuID { get; set; }
        public string MenuName { get; set; }
        public string Url { get; set; }
        public int OrderID { get; set; }
        public bool IsDeleted { get; set; }
        public Guid ParentID { get; set; }
    }
}