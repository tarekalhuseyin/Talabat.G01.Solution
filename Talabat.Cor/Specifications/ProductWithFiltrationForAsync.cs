using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Cor.Entites;

namespace Talabat.Cor.Specifications
{
	public class ProductWithFiltrationForAsync:BaseSpecifiations<Product>
	{
        public ProductWithFiltrationForAsync(ProductSpecParams Params)
            :base(P=>(string.IsNullOrEmpty(Params.Search)||P.Name.ToLower().Contains(Params.Search))
            &&
            (!Params.BrandId.HasValue||P.ProductBrandId==Params.BrandId)
            &&
            (!Params.TypeId.HasValue||P.ProductTypeId==Params.TypeId))
        {

            
        }
    }
}
