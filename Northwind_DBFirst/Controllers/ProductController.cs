using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind_DBFirst.Contexts;
using Northwind_DBFirst.Entities;
using Northwind_DBFirst.RequestModels;
using Northwind_DBFirst.ResponseModels;

namespace Northwind_DBFirst.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        NorthwindContext _dB;
        public ProductController(NorthwindContext context)
        {
            _dB = context;
        }
        private List<ProductResponseModel> ListProducts()
        {
            return _dB.Products.Select(x => new ProductResponseModel
            {
                ID = x.ProductId,
                ProductName = x.ProductName,
                UnitsInStock = x.UnitsInStock,
                UnitPrice = x.UnitPrice

            }).ToList();
        }

        [HttpGet]
        public List<ProductResponseModel> BringProducts() 
        { 
            return ListProducts();
        }

        [HttpGet("id:int")]
        public ProductResponseModel GetProduct(int id)
        {
            return _dB.Products.Where(x => x.ProductId == id).Select(x => new ProductResponseModel
            {
                ID = x.ProductId,
                ProductName = x.ProductName,
                UnitsInStock = x.UnitsInStock,
                UnitPrice = x.UnitPrice
            }).FirstOrDefault();
        }

        [HttpPost("item:ProductCreateRequestModel")]
        public List<ProductResponseModel> AddProduct(ProductCreateRequestModel item)
        {
            Product c = new Product
            {
                ProductName = item.ProductName,
                UnitsInStock = item.UnitsInStock,
                UnitPrice = item.UnitPrice
            };
            _dB.Products.Add(c);
            _dB.SaveChanges();
            return ListProducts();
        }


        [HttpPut]
        public List<ProductResponseModel> UpdateProduct(ProductUpdateRequestModel item)
        {
            Product guncellenecek = _dB.Products.Find(item.ID); ;
            guncellenecek.UnitsInStock = item.UnitsInStock;
            guncellenecek.UnitPrice = item.UnitPrice;
            _dB.SaveChanges();
            return ListProducts();
        }


        [HttpDelete("int:id")]
        public List<ProductResponseModel> DeleteProduct(int id)
        {
            
            _dB.Products.Remove(_dB.Products.Find(id));
            _dB.SaveChanges();
            return ListProducts();
        }

        [HttpGet("string:item")]
        public List<ProductResponseModel> SearchProduct(string item)
        {
            return _dB.Products.Where(x => x.ProductName.Contains(item)).Select(x => new ProductResponseModel
            {
                ProductName = x.ProductName,
                UnitsInStock = x.UnitsInStock,
                ID = x.ProductId,
                UnitPrice = x.UnitPrice
            }).ToList();
        }
    }
}
