using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ParryTrainerApi.Contracts.Comment;

namespace ParryTrainerApi.Controllers;


[ApiController]
[Route("[controller]")]
public class CommentsController (ICommentsService commentsService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<CommentsResponse>> Get(Guid profileId)
    {
        var comments = await commentsService.Get(profileId);
        
        return Ok(comments);
    }

    [HttpPost]
    public async Task<ActionResult<CommentsResponse>> Post([FromBody] CommentsRequest request)
    {
        var (comment, error) = Comments.CreateComments(request.UserId, request.ProfileId, request.CommentId, request.Username,
            request.Text);
        if (string.IsNullOrEmpty(error))
        {
            return BadRequest(error);
        }
        
        await commentsService.Post(comment);
        return Ok(comment);
    }

    [HttpDelete]
    public async Task<ActionResult<Guid>> Delete([FromBody] CommentsRequest request)
    {
        await commentsService.Delete(request.ProfileId, request.CommentId);
        return Ok();
    }
}