using MediatR;
using WebApiCQRS.Models;
using System.Threading.Tasks;
using System.Threading;
using WebApiCQRS.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApiCQRS.Controllers
{

    public class GetProducts
    {
        //Clases anidadas - Contorlador de consultas

        //Implementa la interfaz de solicitud
        public class Query : IRequest<IEnumerable<Product>>
        {
    

            //Clase de controlador de consultas que implementa la Interfaz del Controlador de Solicitud
            //1° parametro recibe el tipo de solicitud que manejara
            //2° parametro el tipo de resultado a devolver
            public class QueryHandler : IRequestHandler<Query, IEnumerable<Product>>
            {
                //Instancia de la DB
                private readonly ApplicationDbContext _db;
                public QueryHandler(ApplicationDbContext db) => this._db = db;                   
                
                public async Task<IEnumerable<Product>> Handle(Query request, CancellationToken cancellationToken)
                {
                    //Usando el DbContext lo usamos para recuperar los Productos de la DB
                    return await _db.Products.ToListAsync(cancellationToken);
                }
            }
        }
    }
}
