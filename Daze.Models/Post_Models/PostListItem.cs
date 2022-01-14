using Daze.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Daze.Models.Post
{
    public class PostListItem
    {
        //Instagram doesn't show comments, they show content as a comment instead to give the illusion of comments.
        //Show comments in post detail
        public int PostId { get; set; }
        public string Content { get; set; }
        public int Brightness { get; set; }
        public int Contrast { get; set; }
        public int Saturation { get; set; }
        public int GreyScale { get; set; }
        public string Alt { get; set; }
        public virtual IEnumerable<HashTag> HashTags { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public IFormFile Image { get; set; }
        public IFormFile Video { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string ProfilePicture { get; set; }
        public ApplicationUser User { get; set; }
    }
}
