using ProductTracking.Data.Data;
using ProductTracking.DTO;
using ProductTracking.DTO.Common;
using ProductTracking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTracking.Business
{
    public class ProductService : IProductService
    {
        private readonly ProductTrackingDbContext _db;

        public ProductService(ProductTrackingDbContext db)
        {
            this._db = db;
        }

        public async Task<ResultDTO> DeleteProduct(long id)
        {
            var response = new ResultDTO();

            try
            {
                var product = _db.Products.FirstOrDefault(p => p.Id == id);

                if(product == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Product Not Found";
                }
                else
                {
                    product.IsActive = false;
                    _db.Update(product);

                    response.IsSuccess = true;
                    response.Message = "Product has been delete Successfully";

                }

               await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                response.IsSuccess = false;
                response.Message = "Error has been occred please try again";
            }

            return response;
        }


        #region Business Service Methods

        public async Task<List<BasicProductDTO>> GetAllProducts()
        {
            var products = new List<BasicProductDTO>();

            var productData =  _db.Products.Where(x=>x.IsActive == true).ToList();

            foreach (var item in productData)
            {
                var product = new BasicProductDTO()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Quntity = item.Quntity,
                    Price = item.Price,
                    Category = item.Category,
                    IsActive = item.IsActive,
                    Created = item.Created,
                    Updated = item.Updated,
                };

                products.Add(product);
            }

            return products;
        }

        public async Task<ProductDTO> GetProductById(long id)
        {
            var productData = _db.Products.Where(x => x.Id == id).FirstOrDefault();

            var product = new ProductDTO()
            {
                Id = productData.Id,
                Name = productData.Name,
                Category = productData.Category,
                Quntity = productData.Quntity,
                Price = productData.Price,
            };

            return product;

        }

        public async Task<ResultDTO> SaveProduct(ProductDTO model)
        {
            var response = new ResultDTO();

            try
            {
                var product = _db.Products.FirstOrDefault(x => x.Id == model.Id);

                if (product == null)
                {
                    product = new Product()
                    {
                        Name = model.Name,
                        Category = model.Category,
                        Price = model.Price,
                        Quntity = model.Quntity,
                        IsActive = true,
                        Created = DateTime.UtcNow,
                        Updated = DateTime.UtcNow,
                    };

                    _db.Products.Add(product);

                    response.IsSuccess = true;
                    response.Message = " Product has been save Successfully";
                }
                else
                {
                    product.Name = model.Name;
                    product.Category = model.Category;
                    product.Price = model.Price;
                    product.Quntity = model.Quntity;
                    product.Updated = DateTime.UtcNow;

                    _db.Products.Update(product);

                    response.IsSuccess = true;
                    response.Message = "Product has been update Successfully";

                }

                await _db.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                response.IsSuccess = true;
                response.Message = "Error has been occred please try again";
            }

            return response;
        } 
        #endregion
    }
}
