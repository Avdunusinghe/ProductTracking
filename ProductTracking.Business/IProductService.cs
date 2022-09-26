using ProductTracking.DTO;
using ProductTracking.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTracking.Business
{
    public interface IProductService
    {
        Task<ResultDTO> SaveProduct(ProductDTO model);
        Task<List<BasicProductDTO>> GetAllProducts();
        Task<ResultDTO> DeleteProduct(long id);
        Task<ProductDTO> GetProductById(long id);

    }
}
