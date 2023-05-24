using Microsoft.AspNetCore.Mvc;
using libreria.Models;
using libreria.Services;

namespace libreria.Controllers;


//ATRIBUTOS CONTROLLER
[ApiController]
[Route("[controller]")]
public class AutorController: ControllerBase
{

    IAutorService autorService;
    public AutorController(IAutorService serviceAutor) => autorService = serviceAutor;
    

    //CRUD API
    //ATRIBUTOS DE ENDPOINTS
    //CREATE
    [HttpPost]
    public async Task <IActionResult> ingresarAutores([FromBody] Autor nuevoAutor){
        await autorService.insertar(nuevoAutor);
        var c= nuevoAutor.AutorId;
        return Ok();
    }

    //READ
    [HttpGet]
    public IActionResult mostrarAutores(){
        return Ok(autorService.obtener());
    }

    //UPDATE
    [HttpPut("{id}")]
    public async Task <IActionResult> actualizarAutores([FromBody] Autor autorActualizar, Guid id){
        await autorService.actualizar(id,autorActualizar);
        return Ok();
    }

    //DELETE
    [HttpDelete("{id}")]
    public IActionResult eliminarAutores(Guid id){
        autorService.eliminar(id);
        return Ok();
    }
}