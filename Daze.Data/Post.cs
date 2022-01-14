using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Daze.Data
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string Content { get; set; }
        public int Brightness { get; set; }
        public int Contrast { get; set; }
        public int Saturation { get; set; }
        public int GreyScale { get; set; }
        public string Alt { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        public string Image { get; set; }
        public string Video { get; set; }

        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string ProfilePicture { get; set; }
        public ApplicationUser User { get; set; }

        [ForeignKey("CommentId")]
        public virtual IEnumerable<Comment> Comments { get; set; }
        [ForeignKey("HashTagId")]
        public int HashTagId { get; set; }
        public HashTag HashTag { get; set; }
        public virtual IEnumerable<HashTag> HashTags { get; set; }
    }
}