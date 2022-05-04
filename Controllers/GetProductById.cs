using MediatR;
using WebApiCQRS.Data;
using WebApiCQRS.Models;

namespace WebApiCQRS.Controllers
{
    public class GetProductById
    {
        public class Query : IRequest<Product>
        {
            //Debe proporcionar el Id del Producto
            public int Id { get; set; }
        } 
        //Controlador de consultas
        public class QueryHandler: IRequestHandler <Query, Product>
        {
            //Instancio la DB
            private readonly ApplicationDbContext _db;           
            public QueryHandler(ApplicationDbContext db) => _db = db;

            public async Task<Product> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _db.Products.FindAsync(request.Id);
            }
        }
    }
}
