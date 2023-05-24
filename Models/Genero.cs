
using System.Net;
using System.ComponentModel.DataAnnotations;
namespace libreria.Models;

public class Genero{

[Key]
public Guid GeneroId{get;set;}
[Required]
public String? Nombre{get;set;}

public virtual Libro? Libro {get;set;}
}