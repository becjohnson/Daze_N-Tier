using Daze.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Daze.Models.Post
{
    public class PostDetail
    {
        public int PostId { get; set; }
        public string Content { get; set; }
        public int Brightness { get; set; }
        public int Contrast { get; set; }
        public int Saturation { get; set; }
        public int GreyScale { get; set; }
        public string Alt { get; set; }
        public virtual IEnumerable<HashTag> HashTags { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        public IFormFile Image { get; set; }
        public IFormFile Video { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public IFormFile ProfilePicture { get; set; }
        public ApplicationUser User { get; set; }
        public virtual IEnumerable<Comment> Comments { get; set; }
    }
}
