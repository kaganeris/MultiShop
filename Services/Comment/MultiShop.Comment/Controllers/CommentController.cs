using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Comment.Context;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class CommentController : ControllerBase
    {
        private readonly CommentContext context;

        public CommentController(CommentContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult CommentList()
        {
           var values = context.UserComments.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateComment(UserComment userComment)
        {
            context.UserComments.Add(userComment);
            context.SaveChanges();
            return Ok("Yorum başarıyla eklendi");
        }

        [HttpPut]
        public IActionResult UpdateComment(UserComment userComment)
        {
            context.UserComments.Update(userComment);
            context.SaveChanges();
            return Ok("Yorum başarıyla güncellendi");
        }

        [HttpDelete]
        public IActionResult DeleteComment(int id)
        {
            var value = context.UserComments.Find(id);
            context.UserComments.Remove(value);
            context.SaveChanges();
            return Ok("Yorum başarıyla silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetCommentById(int id)
        {
            var value = context.UserComments.Find(id);
            return Ok(value);
        }
    }
}
