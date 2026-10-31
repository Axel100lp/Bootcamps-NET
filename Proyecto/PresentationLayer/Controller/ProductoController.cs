using Proyecto.Services;
using Proyecto.DTOs;

namespace Proyecto.Controller
{
    [ApiController]
    [Route("api/productos")]
public class ProductoController : ControllerBase {

    private readonly ProductoService _productoService;

    public ProductoController(ProductoService productoService) {
        _productoService = productoService;
    }


    [HttpGet]
    public IActionResult ObtenerTodos() {
        var productos = _productoService.ObtenerTodos();
        return Ok(productos);
    }

    [HttpGet("{id:int}")]
    public IActionResult ObtenerPorId(int id) {
        ProductoDto producto;
        try
        {
            producto = _productoService.ObtenerPorId(id);
        }
        catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        catch (KeyNotFoundException ex)
            {
                return NotFound(new {message = ex.Message});
            }
        catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return Ok(producto);
    }

    [HttpPut("{id:int}")]
    public IActionResult ActualizarProducto(int id, [FromBody] Producto producto) {
        
        if(producto == null) {
            return BadRequest("El producto no puede ser nulo");
        }else if(id != producto.Id) {
            return BadRequest("El id del producto no coincide con el id de la ruta");
        }
        
        try {
            _productoService.ActualizarProducto(producto);
        }
        catch (ArgumentException ex) {
                return BadRequest(ex.Message);
            }
        catch (KeyNotFoundException ex) {
                return NotFound(new {message = ex.Message});
            }
        catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }

    }

    [HttpDelete("{id:int}")]
    public IActionResult EliminarProducto(int id) {
        try {
            _productoService.EliminarProducto(id);
            return NoContent();
        }
        catch (ArgumentException ex) {
            return BadRequest(ex.Message);
        }
        catch (KeyNotFoundException ex) {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpPost]
    public IActionResult CrearProducto([FromBody] Producto producto) {
        if(producto == null) {
            return BadRequest("El producto no puede ser nulo");
        }
        try {
            _productoService.AgregarProducto(producto);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = producto.Id }, producto);
        }
        catch (ArgumentException ex) {
            return BadRequest(ex.Message);
        }
    }

}

}