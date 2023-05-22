using Microsoft.AspNetCore.Mvc;
using libreria.Models;
using libreria.Services;

namespace libreria.Controllers;


//ATRIBUTOS CONTROLER
[ApiController]
[Route("api/[Controller]")]

public class LibroController: ControllerBase{
ILibroService libroService;

public LibroController(ILibroService serviceLibro){
    libroService=serviceLibro;
}

    //CRUD API
    //ATRIBUTOS DE ENDPOINTS
    //CREATE
    [HttpPost]
    public async Task <IActionResult> ingresarLibros([FromBody] Libro nuevoLibro){
     await libroService.insertar(nuevoLibro);
    return Ok("Datos Ingresados");
    }

    [HttpGet]
     public IActionResult mostrarLibros(){
    return Ok(libroService.obtener());
    }
    //UPDATE
    [HttpPut("{id}")]
      public async Task <IActionResult> actualizarLibros([FromBody] Libro libroActualizar, Guid id){
       await libroService.actualizar(id,libroActualizar);
        return Ok("Datos Actualizados");
    }

    //DELETE
    [HttpDelete]
    public IActionResult eliminarLibros(Guid id){
        libroService.eliminar(id);
        return Ok();

    }
}
