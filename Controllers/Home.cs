
using libreria;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{


LibreriaContext Dbcontext;


public HomeController(LibreriaContext db){
Dbcontext = db;

}

[HttpGet]
[Route("ConnDB")]
public IActionResult ConnDB(){
Dbcontext.Database.EnsureCreated();
return Ok();

}
}