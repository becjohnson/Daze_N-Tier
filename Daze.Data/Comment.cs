using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Daze.Data
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [MaxLength(500)]
        public string Content { get; set; }
        [Display(Name = "Created at:"), Required]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified at:"), Editable(true)]
        public DateTimeOffset? ModifiedUtc { get; set; }
        [ForeignKey("ReplyId")]
        public IEnumerable<Reply> Replies { get; set; }
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public ApplicationUser User { get; set; }
    }
}