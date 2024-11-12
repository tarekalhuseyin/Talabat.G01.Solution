using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.DTOs;
using Talabat.APIs.Errors;
using Talabat.APIs.Helpers;
using Talabat.Cor.Entites;
using Talabat.Cor.Repositories;
using Talabat.Cor.Specifications;

namespace Talabat.APIs.Controllers
{
	
	public class ProductsController : APIBaseController
	{
		private readonly IGenericRepository<Product> _productrepo;
		private readonly IMapper _mapper;
		private readonly IGenericRepository<ProductType> _typeRepo;
		private readonly IGenericRepository<ProductBrand> _brandRepo;

		public ProductsController(IGenericRepository<Product> Productrepo ,
			IMapper mapper,
			IGenericRepository<ProductType> TypeRepo,
			IGenericRepository<ProductBrand> BrandRepo)
        {
			_productrepo = Productrepo;
			_mapper = mapper;
			_typeRepo = TypeRepo;
			_brandRepo = BrandRepo;
		}

		[Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
		[HttpGet]
		public async Task<ActionResult<Pagination<ProductToReturnDto>>>  GetProducts([FromQuery]ProductSpecParams Params)
		{
			var Spec = new ProductWithBrandAndTypeSpecifications (Params);
			var Products = await _productrepo.GetallWithSpecAsync(Spec);
			var MappedProducts=_mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductToReturnDto>>(Products);
			var CountSpec =new ProductWithFiltrationForAsync(Params);
			 var Count =await _productrepo.GetCountWithSpecAsync(CountSpec);
			return Ok(new Pagination<ProductToReturnDto>(Params.PageInsex,Params.PageSize,MappedProducts, Count));
		}
		[HttpGet("{id}")]
		[ProducesResponseType(typeof(ProductToReturnDto),200)]
		[ProducesResponseType(typeof(ApiResponse),StatusCodes.Status404NotFound)]
		 
		public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id )
		{
			var Spec = new ProductWithBrandAndTypeSpecifications(id);
			var Product = await _productrepo.GetByIdWithSpecAsync(Spec);
			if (Product == null)
			{
				return NotFound(new ApiResponse(404));
			};
				var MappedProduct=_mapper.Map<Product,ProductToReturnDto>(Product);
			return Ok(MappedProduct);
		}


		//GET ALL TYPES
		[HttpGet("Types")]
		public async Task<ActionResult<IReadOnlyList<ProductType>>> GetTypes()
		
		{
			var Types=await _typeRepo.GetAllAsync();
			return Ok(Types);
		}


		//GET ALL BRANDES


		[HttpGet("Brands")]
		public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetBrands()

		{
			var Brands = await _brandRepo.GetAllAsync();
			return Ok(Brands);
		}

	}
}
