using Backend_MusicTime.Review.Domain.Model.Queries;
using Backend_MusicTime.Review.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Backend_MusicTime.Review.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class CommentsController(
    ICommentCommandService commentCommandService,
    ICommentQueryService commentQueryService)
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllComments()
    {
        var getAllCommentsQuery = new GetAllCommentsQuery();
        var comments = await commentQueryService.Handle(getAllCommentsQuery);
        return Ok(comments);
    }
    [HttpGet("{commentId:int}")]
    public async Task<IActionResult> GetCommentById(int commentId)
    {
        var getCommentById = new GetCommentByIdQuery(commentId);
        var comment = await commentQueryService.Handle(getCommentById);
        if(comment is null) return NotFound();
        return Ok(comment);
    }
}
