using MediatR;
using WebApiCQRS.Data;

namespace WebApiCQRS.Controllers
{
    public class DeleteProduct
    {
        public class Command : IRequest
        {
            public int Id { get; set; }
        }
        //Como no hay nada que devolver, el segundo parametro tiene la Unidad (no podemos devolver vacio).
        //Los tipos de unidades provienen del mediador.
        public class CommandHandler : IRequestHandler<Command, Unit>
        {
            private readonly ApplicationDbContext _db;

            public CommandHandler(ApplicationDbContext db) => _db = db;

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var product = await _db.Products.FindAsync(request.Id); //recupero el producto con el id.
                // si existe, lo elimino.
                if (product == null) {
                    return Unit.Value; 
                }

                _db.Products.Remove(product);
                await _db.SaveChangesAsync(cancellationToken);

                return Unit.Value; // No tengo nada que devolver; devuelvo el valor de la Unit
            }
        }

    }
}
