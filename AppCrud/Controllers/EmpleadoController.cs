using Microsoft.AspNetCore.Mvc;
using AppCrud.Data;
using AppCrud.Models;
using Microsoft.EntityFrameworkCore;
using Azure.Core;

namespace AppCrud.Controllers;

public class EmpleadoController : Controller
{
  private readonly AppDBContext _appDBContext;

  public EmpleadoController(AppDBContext appDBContext)
  {
    _appDBContext = appDBContext;
  }

  [HttpGet]
  public async Task<IActionResult> Lista()
  {
    List<Empleado> lista = await _appDBContext.Empleados.ToListAsync();
    return View(lista);
  }

  [HttpGet]
  public IActionResult Nuevo()
  {
    return View();
  }

  [HttpPost]
  public async Task<IActionResult> Nuevo(Empleado empleado)
  {
    await _appDBContext.Empleados.AddAsync(empleado); // agrega
    await _appDBContext.SaveChangesAsync();  // guarda los cambios
    return RedirectToAction(nameof(Lista)); // redirecciona al metodo que muestra la lista 
  }

  [HttpGet]
  public async Task<IActionResult> Editar(int id)
  {
    Empleado empleado = await _appDBContext.Empleados.FirstAsync(e => e.IdEmpleado == id);
    return View(empleado);
  }

  [HttpPost]
  public async Task<IActionResult> Editar(Empleado empleado)
  {
    _appDBContext.Empleados.Update(empleado); // actualiza 
    await _appDBContext.SaveChangesAsync();  // guarda los cambios
    return RedirectToAction(nameof(Lista)); // redirecciona al metodo que muestra la lista 
  }

  [HttpGet]
  public async Task<IActionResult> Eliminar(int id)
  {
    Empleado empleado = await _appDBContext.Empleados.FirstAsync(e => e.IdEmpleado == id);

    _appDBContext.Empleados.Remove(empleado); // elimina
    await _appDBContext.SaveChangesAsync();  // guarda los cambios
    return RedirectToAction(nameof(Lista)); // redirecciona al metodo que muestra la lista
  }
}
