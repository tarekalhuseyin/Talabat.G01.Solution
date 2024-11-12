﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Cor.Entites;

namespace Talabat.Cor.Specifications
{
	public class ProductWithBrandAndTypeSpecifications:BaseSpecifiations<Product>
	{
        public ProductWithBrandAndTypeSpecifications(ProductSpecParams Params)
            :base(P=>(!Params.BrandId.HasValue||P.ProductBrandId==Params.BrandId)
            &&
            (!Params.TypeId.HasValue||P.ProductTypeId==Params.TypeId))
        {
            Includes.Add(P => P.ProductType);
            Includes.Add(P => P.ProductBrand);
            if (!string.IsNullOrEmpty(Params.Sort))
            {
                switch (Params.Sort) 
                {
                    case "PriceAsc":
                        AddOrderBy(P=>P.Price); 
                        break;
                    case "PriceDesc":
                        AddOrderBy(P=>P.Price); 
                        break;
                    default:
                        AddOrderBy(P=>P.Name);
                        break;
                
                }
            }

            ApplyPagination(Params.PageSize*(Params.PageInsex-1),Params.PageSize);
        }
        public ProductWithBrandAndTypeSpecifications(int id):base(P=>P.Id==id)
        {
			Includes.Add(P => P.ProductType);
			Includes.Add(P => P.ProductBrand);

		}

    }
}
