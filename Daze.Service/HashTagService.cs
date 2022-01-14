using Daze.Data;
using Daze.Models.Post;
using Daze.WebMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Daze.Service
{
    public class HashTagService
    {
        private readonly Guid _userId;
        private readonly ApplicationDbContext dbContext;
        public HashTagService(Guid userId, ApplicationDbContext context)
        {
            _userId = userId;
            dbContext = context;
        }
        //List just the picture, use details to see the details of the post
        public IEnumerable<PostListItem> GetPostsByHashTagId(int hashTagId)
        {
            var query =
                    dbContext
                    .Posts
                    .Where(e => e.HashTagId == hashTagId)
                    .Select(
                        e =>
            new PostListItem
            {
                OwnerId = _userId,
                UserName = e.UserName,
                Alt = e.Alt,
                GreyScale = e.GreyScale,
                Brightness = e.Brightness,
                Contrast = e.Contrast,
                Saturation = e.Saturation,
                Content = e.Content,
                CreatedUtc = DateTimeOffset.Now,
                Video = e.Video,
                Image = e.Image,
            });
            return query;
        }
        public PostDetail GetSinglePostByHashTagId(int hashTagId, int postId)
        {
            var e =
                    dbContext
                    .Posts
                    .Single(e => e.PostId == postId && e.HashTagId == hashTagId);
            return
                new PostDetail
                {
                    OwnerId = _userId,
                    UserName = e.UserName,
                    Alt = e.Alt,
                    GreyScale = e.GreyScale,
                    Brightness = e.Brightness,
                    Contrast = e.Contrast,
                    Saturation = e.Saturation,
                    Content = e.Content,
                    CreatedUtc = DateTimeOffset.Now,
                    VideoLocation = e.Video,
                    ImageLocation = e.Image,
                };
        }
    }
}
