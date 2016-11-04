using System;
using System.Collections.Generic;

namespace MVCJqueryFunction.Models
{
    public partial class Subcategorytbl
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string SubcategoryName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
