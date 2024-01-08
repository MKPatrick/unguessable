using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Unguessable.DTO;
using Unguessable.Services;

namespace Unguessable.Controllers
{
	[Route("api/Words")]
	[ApiController]
	public class WordController : ControllerBase
	{
		private readonly IWordService wordService;

		public WordController(IWordService wordService)
		{
			this.wordService = wordService;
		}

		[HttpGet()]
		public async Task<ActionResult<IEnumerable<GetWordDTOResponse>>> GetAllWords()
		{
			return Ok(await wordService.GetAllWords());
		}

		[HttpPost("WordsByCategory")]
		public async Task<ActionResult<IEnumerable<GetWordDTOResponse>>> WordsByCategory([FromBody] GetWordDTOResquest getWordDTOResquest)
		{
			return Ok(await wordService.GetWordsByCategories(getWordDTOResquest.categoriesID,getWordDTOResquest.wordAmount));
		}

	}
}
