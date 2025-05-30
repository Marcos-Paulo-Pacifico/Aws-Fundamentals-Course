using System.Net;
using Amazon.S3;
using Customers.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Customers.Api.Controllers;

[ApiController]
public class CustomerImageController : ControllerBase
{
    private readonly ICustomerImageService _imageService;

    public CustomerImageController(ICustomerImageService imageService)
    {
        _imageService = imageService;
    }

    [HttpPost("customers/{id:guid}/image")]
    public async Task<IActionResult> Upload([FromRoute] Guid id, 
        [FromForm(Name = "Data")]IFormFile file)
    {
        var response = await _imageService.UploadImageAsync(id, file);
        if(response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            return Ok();
        
        return BadRequest(response.HttpStatusCode);
    }
    
    [HttpGet("customers/{id:guid}/image")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        try
        {
            var response = await _imageService.GetImageAsync(id);
            return File(response.ResponseStream, response.Headers.ContentType);
        }
        catch (AmazonS3Exception ex) when (ex.Message is "The specified key does not exist")
        {
            return NotFound();
        }
    }
    
    [HttpDelete("customers/{id:guid}/image")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var response = await _imageService.DeleteImageAsync(id);

        return response.HttpStatusCode switch
        {
            HttpStatusCode.NoContent => Ok(),
            HttpStatusCode.NotFound => NotFound(),
            _ => BadRequest(),
        };
    }
}
