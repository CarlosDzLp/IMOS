using System;
using System.Collections.Generic;
using System.Text;

namespace IMOS.Models
{
    //
    public class MenuLateral
    {
        public int ItemId { get; set; }
        public string ItemTitle { get; set; }
        public bool Validate { get; set; }
        public Category Category { get; set; }
    }
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryTitle { get; set; }
    }
}
