using MediatR;
using WebApiCQRS.Data;
using WebApiCQRS.Models;

namespace WebApiCQRS.Controllers
{
    public class AddProduct
    {
        //Devuelve el ID del Producto insertado en la base
        public class Command : IRequest<int>
        {
           //Proporcionar campos para setear en la DB
            public String Name { get; set; }
            public String Description { get; set; }
        }

        //Creo el controlador de comandos
        public class CommandHandler : IRequestHandler<Command, int>
        {
            //Instancio la DB
            private readonly ApplicationDbContext _db;
            public CommandHandler(ApplicationDbContext db) => _db = db;
            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                //Crear instancia del Producto
                var entity = new Product
                {
                    Name = request.Name,
                    Description = request.Description,
                };
                await _db.Products.AddAsync(entity, cancellationToken);
                await _db.SaveChangesAsync(cancellationToken);
                return entity.Id;
            }
        }
    }
}
