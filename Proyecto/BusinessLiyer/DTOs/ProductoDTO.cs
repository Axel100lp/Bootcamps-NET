namespace Proyecto.DTOs;

public class Producto {


//por temas de doble encapsulamiento
public int Id { get; private set; }
public string Nombre { get; private set; }
public decimal Precio { get; private set; }
public string Descripcion { get; private set; }
public bool Activo { get; private set; }

}