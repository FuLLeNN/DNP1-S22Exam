using Entities;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ImagesController : ControllerBase
{

    private readonly IDataAccess dataAccess;
    public ImagesController(IDataAccess dataAccess)
    {
        this.dataAccess = dataAccess;
    }

    [HttpGet, Route("filter")]
    public async Task<ActionResult<ICollection<Image>>> GetImages(string albumCreator = null, string topic = null)
    {
        try
        {
            ICollection<Image> created = await dataAccess.GetImagesAsync(albumCreator,topic);
            return Ok(created);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
}