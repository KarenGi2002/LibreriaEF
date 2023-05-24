using Microsoft.AspNetCore.Mvc;
using libreria.Models;
using libreria.Services;

namespace libreria.Controllers;

//ATRIBUTOS CONTROLLER
[ApiController]
[Route("[controller]")]
public class GeneroController: ControllerBase
{

    IGeneroService generoService;
    public GeneroController(IGeneroService serviceGenero) => generoService = serviceGenero;
    

    //CRUD API
    //ATRIBUTOS DE ENDPOINTS
    //CREATE
    [HttpPost]
    public async Task <IActionResult> ingresarGeneros([FromBody] Genero nuevoGenero){
        await generoService.insertar(nuevoGenero);
        var c= nuevoGenero.GeneroId;
        return Ok();
    }

    //READ
    [HttpGet]
    public IActionResult mostrarGeneros(){
        return Ok(generoService.obtener());
    }

    //UPDATE
    [HttpPut("{id}")]
     public async Task <IActionResult>actualizarAutores([FromBody] Genero generoActualizar, Guid id){
       await generoService.actualizar(id,generoActualizar);
        return Ok();
    }

    //DELETE
    [HttpDelete("{id}")]
    public async Task <IActionResult> eliminarGeneros(Guid id){
      await  generoService.eliminar(id);
        return Ok();
    }
}