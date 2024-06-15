// En esta clase estamos creando las propiedades que va a tener las tablas
using AppCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace AppCrud.Data;

public class AppDBContext : DbContext
{
  // para crear rapido ctor
  public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
  {

  }

  public DbSet<Empleado> Empleados { get; set; }

  // para crear rapido override On
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    // base.OnModelCreating(modelBuilder);

    // Crea la config de la tabla
    modelBuilder.Entity<Empleado>(tb =>
    {
      // indica que en la col(columna) la llave primaria es IdEmpleado
      tb.HasKey(col => col.IdEmpleado);

      // indica que tiene la propiedad identity que es autoincrementable
      tb.Property(col => col.IdEmpleado)
      .UseIdentityColumn()
      .ValueGeneratedOnAdd();

      tb.Property(col => col.NombreCompleto).HasMaxLength(50);
      tb.Property(col => col.Correo).HasMaxLength(55);
        });

    modelBuilder.Entity<Empleado>().ToTable("Empleado");
  }
}


// Este es para SQLSERVER CON PROGRAMA SQLEXPRESS
// "Data Source = (localhost)//SQLEXPRESS; Initial Catalog = DBCrud; Integrated Security = True; Trusted_Connection = True; TrustServerCertificate = True;"