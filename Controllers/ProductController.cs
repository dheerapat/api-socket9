using prod.Models;
using prod.Services;
using Microsoft.AspNetCore.Mvc;
using prod.ViewModel;

namespace prod.Controllers;

[ApiController]
[Route("[controller]")]
public class prodController : ControllerBase
{
    prodService _service;
    
    public prodController(prodService service)
    {
        _service = service;
    }

    [HttpGet]
    public List<Product> GetAll()
    {
        return _service.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<Product> GetById(int id)
    {
        var product = _service.GetById(id);

        if(product is not null)
        {
            return product;
        }
        else
        {
            return NotFound();
        }
    }


    [HttpPost]
    public IActionResult Create([FromBody]ProductRequestViewModel newProduct)
    {
        var product = _service.Create(newProduct);
        return Ok(product);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, ProductRequestViewModel Product)
    {
        var productToUpdate = _service.GetById(id);

        if(productToUpdate is not null)
        {
            _service.Update(id, Product);
            return NoContent();
        }
        else
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var product = _service.GetById(id);

        if(product is not null)
        {
            _service.Delete(id);
            return Ok();
        }
        else
        {
            return NotFound();
        }
    }
}