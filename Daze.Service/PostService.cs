using Daze.Data;
using Daze.Models.Post_Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using Daze.WebMVC.Data;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;

namespace Daze.Service
{
    public class PostService : Controller
    {
        private readonly Guid _userId;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext dbContext;
        public PostService(Guid userId, IWebHostEnvironment hostEnvironment, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userId = userId;
            webHostEnvironment = hostEnvironment;
            _userManager = userManager;
            dbContext = context;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public bool CreatePost(PostCreate model)
        {
            string uniqueFileName = UploadedVideo(model);
            string uniqueFileName2 = UploadedImage(model);
            string uniqueFileName3 = UploadedAudio(model);
            string hashtags = Hashtagger(model.Content);
            int hashlength = HashTagLength(model.Content);
            int hashindex = HashTagIndexer(model.Content);
            int hashcount = HashTagCounter(model.Content);
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            HashTag hashTag = new HashTag {Tag = hashtags};
            dbContext.HashTags.Add(hashTag);
                var entity =
                new Post
                {
                    UserId = _userId,
                    Alt = model.Alt,
                    GreyScale = model.GreyScale,
                    Brightness = model.Brightness,
                    Contrast = model.Contrast,
                    Saturation = model.Saturation,
                    Content = model.Content,
                    Tag = 
                    CreatedUtc = DateTimeOffset.Now,
                    Image = uniqueFileName2,
                    Video = uniqueFileName3,
                    UserName = user.UserName,
                };
                dbContext.Posts.Add(entity);
                return dbContext.SaveChanges() == 2;
        }
        private string UploadedVideo(PostCreate model)
        {
            string uniqueFileName = null;
            if (model.Video != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "audios");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Video.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Video.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        private string UploadedImage(PostCreate model)
        {
            string uniqueFileName2 = null;
            if (model.Image != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName2 = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName2);
                using var fileStream = new FileStream(filePath, FileMode.Create);
                model.Image.CopyTo(fileStream);
            }
            return uniqueFileName2;
        }
        public string Hashtagger(string content)
        {
            int maxtags = 10;
            var rx = new Regex("#+[a-zA-Z0-9(_)]{1,}", RegexOptions.Compiled);
            MatchCollection matches = rx.Matches(content);
            if (matches != null && matches.Count == 1)
            {
                return matches[0].Value;
            }
            else
            if (matches != null && matches.Count == 2)
            {
                return $"{matches[0].Value} {matches[1].Value}";
            }
            else
            if (matches != null && matches.Count == 3)
            {
                return $"{matches[0].Value} {matches[1].Value} {matches[2].Value}";
            }
            else
            if (matches != null && matches.Count == 4)
            {
                return $"{matches[0].Value} {matches[1].Value} {matches[2].Value} {matches[3].Value}";
            }
            else
            if (matches != null && matches.Count == 5)
            {
                return $"{matches[0].Value} {matches[1].Value} {matches[2].Value} {matches[3].Value} {matches[4].Value}";
            }
            else
            if (matches != null && matches.Count == 6)
            {
                return $"{matches[0].Value} {matches[1].Value} {matches[2].Value} {matches[3].Value} {matches[4].Value} {matches[5].Value}";
            }
            else
            if (matches != null && matches.Count == 7)
            {
                return $"{matches[0].Value} {matches[1].Value} {matches[2].Value} {matches[3].Value} {matches[4].Value} {matches[5].Value} {matches[6].Value}";
            }
            else
            if (matches != null && matches.Count == 8)
            {
                return $"{matches[0].Value} {matches[1].Value} {matches[2].Value} {matches[3].Value} {matches[4].Value} {matches[5].Value} {matches[6].Value} {matches[7].Value}";
            }
            else
            if (matches != null && matches.Count == 9)
            {
                return $"{matches[0].Value} {matches[1].Value} {matches[2].Value} {matches[3].Value} {matches[4].Value} {matches[5].Value} {matches[6].Value} {matches[7].Value} {matches[8].Value}";
            }
            else
            if (matches != null && matches.Count == maxtags)
            {
                return $"{matches[0].Value} {matches[1].Value} {matches[2].Value} {matches[3].Value} {matches[4].Value} {matches[5].Value} {matches[6].Value} {matches[7].Value} {matches[8].Value} {matches[9].Value}";
            }
            else
            if (matches != null && matches.Count > maxtags)
            {
                ValidationProblemDetails problemDetails = new ValidationProblemDetails();
                return problemDetails.Detail = "Please limit hashtags t0 10";
            }
            else
                return "";
        }
    }
}