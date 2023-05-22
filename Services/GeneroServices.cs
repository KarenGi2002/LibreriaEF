using libreria;
using libreria.Models;
namespace libreria.Services;

public class GeneroService: IGeneroService
{ 
    //Inyeccion de dependencias
    LibreriaContext context;
    public GeneroService(LibreriaContext DbContext){
        context=DbContext;
    }

    //CRUDs
    //CREATE - insertar a la BD
    // async await
    public async Task insertar(Genero inputGenero){
        inputGenero.GeneroId= Guid.NewGuid();
        await context.AddAsync(inputGenero);
        await context.SaveChangesAsync();
    }

    //READ - Obtener de la DB
    public IEnumerable<Genero>? obtener(){
        return context.Genero;
    }

    //UPDATE
    public async Task actualizar(Guid id, Genero inputGenero){
        var genero = context.Genero?.Find(id);
        if(genero != null){
            genero.Nombre=inputGenero.Nombre;
            
            await context.SaveChangesAsync();
        }
    }

    //DELETE
    public async Task eliminar(Guid id){
        var genero = context.Genero?.Find(id);
        if(genero != null){
            context.Remove(genero);
            await context.SaveChangesAsync();
        }
    }
}

public interface IGeneroService{
    Task insertar(Genero inputGenero);
    IEnumerable<Genero>? obtener();
    Task actualizar(Guid id, Genero genero);
    Task eliminar(Guid id);
}