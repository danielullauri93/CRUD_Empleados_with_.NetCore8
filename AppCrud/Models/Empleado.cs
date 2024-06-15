// En esta clase creamos las tablas, propiedades
namespace AppCrud.Models;

public class Empleado
{
  // para crear rapido tecleamos prop 
  public int IdEmpleado { get; set; }

  public string NombreCompleto { get; set; }

  public string Correo { get; set; }

  public DateOnly FechaContrato { get; set; }

  public bool Activo { get; set; }

}
