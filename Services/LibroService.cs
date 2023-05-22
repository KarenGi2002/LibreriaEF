using libreria.Models;
namespace libreria.Services;

public class libroService: ILibroService{
    //inyeccion dependencias

   LibreriaContext context;

    public libroService(LibreriaContext dbContext){
context= dbContext;
    }

    //CRUD
    //CREATE
    //ASYNC

    public async Task insertar(Libro inputLibro){
        inputLibro.LibroId=Guid.NewGuid();
        await context.AddAsync(inputLibro);
        await context.SaveChangesAsync();

    }

    public IEnumerable<Libro>? obtener(){
        return context.Libro;
    
    }
    public async Task actualizar (Guid id, Libro inputLibro){
        var libro=  context.Libro?.Find(id);
        if(libro != null){
            libro.LibroId=inputLibro.LibroId;
            libro.Nombre=inputLibro.Nombre;
            libro.Edicion= inputLibro.Edicion;
            libro.Paginas=inputLibro.Paginas;

            await context.SaveChangesAsync();
        }
    }

    public async Task eliminar(Guid id){
        var libro=context.Libro?.Find(id);
        if(libro!= null){
            context.Remove(libro);
            await context.SaveChangesAsync();
        }
    }

}

public interface ILibroService{
    Task insertar(Libro inputLibro);
    IEnumerable<Libro>? obtener();
    Task actualizar (Guid id, Libro libro);
    Task eliminar(Guid id);
    
}