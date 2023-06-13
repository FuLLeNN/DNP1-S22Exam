using Entities;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AlbumsController : ControllerBase
{

    private readonly IDataAccess dataAccess;
    public AlbumsController(IDataAccess dataAccess)
    {
        this.dataAccess = dataAccess;
    }

    [HttpPost, Route("add")]
    public async Task<ActionResult<Album>> CreateAlbum([FromBody] Album album)
    {
        try
        {
            Album created = await dataAccess.AddAlbumAsync(album);
            return Ok(created);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet, Route("")]
    public async Task<ActionResult<ICollection<string>>> GetTitles()
    {
        try
        {
            ICollection<string> created = await dataAccess.GetAlbumTitlesAsync();
            return Ok(created);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost, Route("AddImageToAlbum")]
    public async Task<ActionResult> AddImageToAlbum([FromBody] Image image, string title)
    {
        try
        {
            await dataAccess.AddImageToAlbum(image, title);
            return Ok("Created");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}