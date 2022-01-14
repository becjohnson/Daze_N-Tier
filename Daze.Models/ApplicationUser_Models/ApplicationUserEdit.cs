using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Daze.Models.ApplicationUser_Models
{
    public class ApplicationUserEdit
    {
        public IFormFile ProfilePicture { get; set; }
        public IFormFile ProfileSong { get; set; }
    }
}
