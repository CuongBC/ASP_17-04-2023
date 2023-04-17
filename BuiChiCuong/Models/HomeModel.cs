using BuiChiCuong.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuiChiCuong.Models
{
    public class HomeModel
    {
        public List<Product> listProduct { get; set; }

        public List<Category> listCategory { get; set; }
        public List<Brand> listBrand { get; set; }
    }
}