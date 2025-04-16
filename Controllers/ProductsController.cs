namespace danone_client.Controller;

using Microsoft.AspNetCore.Mvc;
using danone_client.Models.Responses;
using danone_client.Services;
using Microsoft.OpenApi.Any;
using danone_client.Models.DTOs;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductsService _productsService;

    public ProductsController(IProductsService productsService)
    {
        _productsService = productsService;
    }

    [HttpGet]
    public ActionResult<AnyType> GetAll()
    {
        Response response = new Response();

        try
        {
            response = _productsService.GetAll();

            return new JsonResult(response);
        }
        catch (Exception e)
        {
            response.statusCode = 500;
            response.message = e.Message;
            return new JsonResult(response);
        }
    }


    [HttpGet("GetAllByBrand")]
    public ActionResult<AnyType> GetAllByBrand()
    {
        Response response = new Response();

        try
        {
            response = _productsService.GetAllByBrand();

            return new JsonResult(response);
        }
        catch (Exception e)
        {
            response.statusCode = 500;
            response.message = e.Message;
            return new JsonResult(response);
        }
    }

    [HttpPost("add")]
    public ActionResult Add([FromBody] AddProductDTO model)
    {
        Response response = new Response();

        try
        {
            response = _productsService.Add(model);
            return new JsonResult(response);
        }
        catch (Exception e)
        {
            response.statusCode = 500;
            response.message = e.Message;
            return new JsonResult(response);
        }
    }

    [HttpPost("update")]
    public ActionResult Update([FromBody] ProductDTO model)
    {
        Response response = new Response();
        try
        {
            response = _productsService.Update(model);
            return new JsonResult(response);
        }
        catch (Exception e)
        {
            response.statusCode = 500;
            response.message = e.Message;
            return new JsonResult(response);
        }
    }

    [HttpGet("delete/{id}")]
    public ActionResult Delete(int id)
    {
        Response response = new Response();
        try
        {
            response = _productsService.Delete(id);
            return new JsonResult(response);
        }
        catch (Exception e)
        {
            response.statusCode = 500;
            response.message = e.Message;
            return new JsonResult(response);
        }
    }

}