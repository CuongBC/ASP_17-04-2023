using BuiChiCuong.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuiChiCuong.Areas.Admin.Models
{
    public class DetailOrder
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}