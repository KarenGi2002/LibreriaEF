
using System.Net;
using System.ComponentModel.DataAnnotations;
namespace libreria.Models;

public class Libro{
[Key]
public Guid LibroId{get; set;}

[Required]
[MaxLength(100)]
public String? Nombre{get; set;}
[Required]
[MaxLength(100)]
public int? Edicion{get; set;}

[Required]
[MaxLength()]
public int? Paginas{get;set;}


}