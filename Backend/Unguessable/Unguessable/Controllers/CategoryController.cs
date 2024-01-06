using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Unguessable.DTO;
using Unguessable.Services;

namespace Unguessable.Controllers
{
	[Route("api/Categories")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly ICategoryService categoryService;

		public CategoryController(ICategoryService categoryService)
		{
			this.categoryService = categoryService;
		}

		[HttpGet()]
		public async Task<ActionResult<IEnumerable<GetCategoriesDTOResponse>>> Categories()
		{
			return Ok(await categoryService.GetCategories());
		}
	}
}
