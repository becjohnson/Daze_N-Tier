using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Daze.Data
{
    public class Profile : ApplicationUser
    {
        [Key]
        public int ProfileId { get; set; }
    }
}
