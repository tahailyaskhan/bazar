using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bazar.DAL.Data
{
    public class cart
    {
        public int ids { get; set; }
        public int quantity { get; set; }

        public int userid { get; set; }

        public int price { get; set; }

        public string size { get; set; }
        public string pic1 { get; set; }
      
        public string clothname { get; set; }
        


    }
}