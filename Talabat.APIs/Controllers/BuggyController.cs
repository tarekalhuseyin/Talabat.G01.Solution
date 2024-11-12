using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.Errors;
using Talabat.Repository.Data;

namespace Talabat.APIs.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BuggyController : APIBaseController
	{
		private readonly StoreContext _dbContext;

		public BuggyController(StoreContext dbContext)
        {
			_dbContext = dbContext;
		}
		[HttpGet("NotFound")]
		public ActionResult GetNotFoundRequest()
		{
			var product = _dbContext.Products.Find(100);
			if (product == null) { return NotFound(new ApiResponse(404));
				
			}return Ok(product);
		}

		[HttpGet("ServerError")]
		public ActionResult GetServerError()
		{
			var product = _dbContext.Products.Find(100);
			var ProductToReturn = product.ToString();
			return Ok(ProductToReturn);
		}

		[HttpGet("BadRequest")]
		public ActionResult GetBadRequest() 
		{
			return BadRequest();
		}

		[HttpGet("BadRequest/{id}")]
		public ActionResult GetBadRequest(int id )
		{
			return Ok();
		}
	}
}
