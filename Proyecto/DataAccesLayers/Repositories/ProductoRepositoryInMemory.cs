using Proyecto.Models;

namespace ConsoleApp1;

public class ProductoRepositoryInMemory : IProductoRepository {

private static readonly List<Producto> _productos = new List<Producto>();
private static int _nextId = 1;
public List<Producto> ListaProductos{ get; private set; }

public ProductoRepositoryInMemory() {
    ListaProductos = new List<Producto>();
}

public void AgregarProducto(Producto p_producto) {
    this.ListaProductos.Add(p_producto);
}
public void quitrarProducto(Producto p_producto) {
    this.ListaProductos.Remove(p_producto);
}

public List<Producto> ObtenerTodos() {
    return this.ListaProductos;
}

public Producto ObtenerPorId(int id) {
    Producto auxProducto = this.ListaProductos.FirstOrDefault(p => p.Id == id);

    if(auxProducto == null) {
        //keyNotFoundException es una excepción que se lanza cuando no se encuentra un 
        // elemento en una colección basandose en el ide
        throw new KeyNotFoundException($"No se encontró un producto con el id {id}");
    }
    return auxProducto;
}

public List<Producto> BuscarPorCategoria(string categoria) {
    return this.ListaProductos.Where(p => p.Descripcion == categoria).ToList();
}

public void ActualizarProducto(Producto producto) {
    var productoExistente = ObtenerPorId(producto.Id);
    if (productoExistente != null) {
        quitrarProducto(productoExistente);
        AgregarProducto(producto);
    } else {
        throw new KeyNotFoundException($"No se encontró un producto con el id {producto.Id}");
    }
}

public bool EliminarProducto(int id) {
    var productoExistente = ObtenerPorId(id);
    if (productoExistente != null) {
        quitrarProducto(productoExistente);
        return true;
    } else {
        return false;
    }

}

}