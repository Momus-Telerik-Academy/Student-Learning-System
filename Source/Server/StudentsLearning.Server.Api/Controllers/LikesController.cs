﻿namespace StudentsLearning.Server.Api.Controllers
{
    using System.Web.Http;
    using Services.Data.Contracts;
    using Microsoft.AspNet.Identity;

    public class LikesController : ApiController
    {
        private readonly ILikesService likesService;

        public LikesController(ILikesService likesService)
        {
            this.likesService = likesService;
        }

        [Authorize]
        public IHttpActionResult Post(int id)
        {
            var userId = this.User.Identity.GetUserId();

            if (this.likesService.CommentIsLikedByUser(id, userId))
            {
                return this.BadRequest("You already have liked this comment.");
            }

            this.likesService.LikeComment(id, userId);
            return this.Ok();
        }
    }
}
