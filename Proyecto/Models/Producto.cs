using System;

namespace ConsoleApp1;

public class Producto {


//por temas de doble encapsulamiento
public int Id { get; private set; }
public string Nombre { get; private set; }
public decimal Precio { get; private set; }
public string Descripcion { get; private set; }
public bool Activo { get; private set; }

public Producto(int id, string nombre, decimal precio, string descripcion, bool activo)
{
    Id = id;
    Nombre = nombre;
    Precio = precio;
    Descripcion = descripcion;
    Activo = activo;
}
}