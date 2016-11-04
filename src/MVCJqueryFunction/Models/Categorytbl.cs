using System;
using System.Collections.Generic;

namespace MVCJqueryFunction.Models
{
    public partial class Categorytbl
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
