using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Daze.Data
{
    public class HashTag
    {
        [Key]
        public int HashTagId { get; set; }
        public string Tag { get; set; }
        [ForeignKey("PostId")]
        public int PostId { get; set; }
        public virtual IEnumerable<Post> Posts { get; set; }
    }
}