using Project.Pos.Pizzeria.WebApi.Common;
using Project.Pos.Pizzeria.WebApi.Entities;
using Project.Pos.Pizzeria.WebApi.Repository;

namespace Project.Pos.Pizzeria.WebApi.Domain;

public class ProductosDomain
{
    readonly ProductosRepository _productosRepository;
    public ProductosDomain(ProductosRepository productosRepository)
    {
        this._productosRepository = productosRepository;
    }

    public async Task<StatusDomain> CreateProduct(Productos entity)
    {
        var getCustomer = await _productosRepository.GetProductByCode(entity);
        if (getCustomer != null) return StatusDomain.ProductExist;
        entity.Codigo = await LastCodeProduct();
        var insert = await _productosRepository.InsertProduct(entity);
        return insert == 0 ? StatusDomain.ProductCreateError : StatusDomain.ProductCreate;
    }

    public async Task<string> LastCodeProduct()
    {
        var getAllProducts = await _productosRepository.GetProductAll();
        if (getAllProducts.Count() > 0)
        {
            string lastCode = getAllProducts.OrderByDescending(x => x.Codigo).FirstOrDefault().Codigo;
            int nextCode = int.Parse(lastCode.Substring(1)) + 1;
            return nextCode.ToString().PadLeft(3, '0');
        }
        else
        {
            return "001";
        }
    }

    public async Task<StatusDomain> UpdateProduct(Productos entity)
    {
        var getProduct = await _productosRepository.GetProductByCode(entity);
        if (getProduct == null) return StatusDomain.ProductNotExist;
        entity.Codigo = getProduct.Codigo;
        var update = await _productosRepository.UpdateProduct(entity);
        return update == 0 ? StatusDomain.ProductUpdateError : StatusDomain.ProductUpdate;
    }

    public async Task<StatusDomain> DeleteProduct(Productos entity)
    {
        var getProduct = await _productosRepository.GetProductByCode(entity);
        if (getProduct == null) return StatusDomain.ProductNotExist;
        var delete = await _productosRepository.DeleteProduct(getProduct);
        return delete == 0 ? StatusDomain.CustomerDeleteError : StatusDomain.CustomerDelete;
    }
}
