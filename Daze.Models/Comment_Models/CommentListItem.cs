using Daze.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Daze.Models.Comment_Models
{
    public class CommentListItem
    {
        [MaxLength(500)]
        public string Content { get; set; }
        [Display(Name = "Created at:"), Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string ProfilePicture { get; set; }
        public ApplicationUser User { get; set; }
    }
}
