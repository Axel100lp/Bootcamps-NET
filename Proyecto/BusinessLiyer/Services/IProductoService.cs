
using Proyecto.DTOs;
using Proyecto.Models;

namespace Proyecto.Services;

    public interface IProductoService {
    public ProductoDto AgregarProducto(CreateProductoDTO productoDTO);
    public List<ProductoDto> ObtenerTodos();
    public ProductoDto ObtenerPorId(int id);
    public void actualizarProducto(ProductoDto productoDTO);
    public void EliminarProducto(int id);
}
    