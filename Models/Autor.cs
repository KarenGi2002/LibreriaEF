
using System.Net;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libreria.Models;

public class Autor{
    [Key]
    public Guid AutorId{get;set;} 

[Required]
[MaxLength(250)]
    public String? Nombre{get;set;}

[MaxLength(250)]
 public String? Apellido{get;set;}

[MaxLength(100)]
public String? Nacionalidad{get;set;}

public virtual Libro? Libro {get;set;}


}