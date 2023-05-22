using libreria;
using libreria.Models;
namespace libreria.Services;

public class AutorService: IAutorService
{ 
    //Inyeccion de dependencias
    LibreriaContext context;
    public AutorService(LibreriaContext DbContext){
        context=DbContext;
    }

    //CRUD
    //CREATE - insertar a la BD
    // async await
    public async Task insertar(Autor inputAutor){
        inputAutor.AutorId= Guid.NewGuid();
        await context.AddAsync(inputAutor);
        await context.SaveChangesAsync();
    }

    //READ - Obtener de la DB
    public IEnumerable<Autor>? obtener(){
        return context.Autor;
    }

    //UPDATE
    public async Task actualizar(Guid id, Autor inputAutor){
        var autor = context.Autor?.Find(id);
        if(autor != null){
            autor.nombre=inputAutor.nombre;
            autor.apellido=inputAutor.apellido;
            autor.nacionalidad=inputAutor.nacionalidad;

            await context.SaveChangesAsync();
        }
    }

    //DELETE
    public async Task eliminar(Guid id){
        var autor = context.Autor?.Find(id);
        if(autor != null){
            context.Remove(autor);
            await context.SaveChangesAsync();
        }
    }
}

public interface IAutorService{
    Task insertar(Autor inputAutor);
    IEnumerable<Autor>? obtener();
    Task actualizar(Guid id, Autor autor);
    Task eliminar(Guid id);
}