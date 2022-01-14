using Daze.Data;
using Daze.Models.Post_Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using Daze.WebMVC.Data;
using System.Text.RegularExpressions;
using System.Linq;
using Daze.Models.Post;
using Daze.IServices;

namespace Daze.Service
{
    public class PostService : IPostService
    {
        private readonly Guid _userId;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;
        public PostService(Guid userId, IWebHostEnvironment hostEnvironment, UserManager<ApplicationUser> userManager)
        {
            _userId = userId;
            webHostEnvironment = hostEnvironment;
            _userManager = userManager;
        }
    }
}