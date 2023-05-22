
using System.Net;
using System.ComponentModel.DataAnnotations;
namespace libreria.Models;

public class Autor{
    [Key]
    public Guid AutorId{get;set;} 

[Required]
[MaxLength(250)]
    public String? nombre{get;set;}

[MaxLength(250)]
 public String? apellido{get;set;}

[MaxLength(100)]
public String? nacionalidad{get;set;}

    
}