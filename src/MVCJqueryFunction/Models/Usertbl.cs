using System;
using System.Collections.Generic;

namespace MVCJqueryFunction.Models
{
    public partial class Usertbl
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
    }
}
