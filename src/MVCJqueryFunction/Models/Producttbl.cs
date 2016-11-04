using System;
using System.Collections.Generic;

namespace MVCJqueryFunction.Models
{
    public partial class Producttbl
    {
        public int Id { get; set; }
        public int ParentCategory { get; set; }
        public int SubCategory { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductPrice { get; set; }
        public string PrductImage { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
