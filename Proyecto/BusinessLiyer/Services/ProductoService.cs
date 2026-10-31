using Proyecto.Repositories;
using Proyecto.DTOs;
using Proyecto.Models;
using System.Collections.Generic;

namespace Proyecto.Services;

public class ProductoService : IProductoService {


    private readonly IProductoRepository _productoRepository;

    public ProductoService(IProductoRepository productoRepository) {
        _productoRepository = productoRepository;
    }

    public void AgregarProducto(CreateProductoDTO productoDTO) {

        if (productoDTO == null) {
            throw new ArgumentException("El producto no puede ser nulo");
        }

        var producto = new Producto {
            Nombre = productoDTO.Nombre,
            Precio = productoDTO.Precio,
            Descripcion = productoDTO.Descripcion,
            Activo = productoDTO.Activo
        };
        _productoRepository.AgregarProducto(producto);
    }

    public List<Producto> ObtenerTodos() {
        var productos = _productoRepository.ObtenerTodos();
        var ProductoDtos = productos.Select(p => new ProductoDto {
            Id = p.Id,
            Nombre = p.Nombre,
            Precio = p.Precio,
            Descripcion = p.Descripcion,
            Activo = p.Activo
        }).ToList();

        return ProductoDtos;
    }

    public ProductoDto ObtenerPorId(int id) {
        
        if(id <= 0) {
            throw new ArgumentException("El id del producto debe ser mayor a cero");
        }

        var producto = _productoRepository.ObtenerPorId(id);
        if (producto == null) {
            throw new KeyNotFoundException($"No existe el producto con el id {id}");
        }
    
        var productoDto = new ProductoDto {
            Id = producto.Id,
            Nombre = producto.Nombre,
            Precio = producto.Precio,
            Descripcion = producto.Descripcion,
            Activo = producto.Activo
        };
        return productoDto;
    }

    public void actualizarProducto(ProductoDto productoDto) {
        if (productoDto == null) {
            throw new ArgumentException("El producto no puede ser nulo");
        }

        var productoActualizado = _productoRepository.ObtenerPorId(productoDto.Id);
        if (productoActualizado == null) {
            throw new KeyNotFoundException($"No existe el producto con el id {productoDto.Id}");
        }

        productoActualizado.Nombre = productoDto.Nombre;
        productoActualizado.Precio = productoDto.Precio;
        productoActualizado.Descripcion = productoDto.Descripcion;
        productoActualizado.Activo = productoDto.Activo;

        _productoRepository.ActualizarProducto(productoActualizado);


    }

    public void EliminarProducto(int id) {

        if (id <= 0) {
            throw new ArgumentException("El id del producto debe ser mayor a cero");
        }

       var producto = _productoRepository.ObtenerPorId(id);
       if (producto == null) {
            throw new KeyNotFoundException($"No existe el producto con el id {id}");
        }
        _productoRepository.EliminarProducto(id);
    }
}