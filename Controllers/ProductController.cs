using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCQRS.Models;

namespace WebApiCQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //Inyectó una instancia del mediador
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Metodo de accion para obtener listado de productos
        [HttpGet] 
        public async Task<IEnumerable<Product>> GetProducts() => await _mediator.Send(new GetProducts.Query());
    }
}
