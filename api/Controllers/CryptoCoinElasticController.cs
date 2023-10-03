using Api.Dto;
using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;
using Nest;

namespace Api.Controllers
{
	[Route("api/crypto-coins-elastic")]
	[ApiController]
	public class CryptoCoinElasticController : ControllerBase
	{
		private readonly IElasticClient _elasticClient;
		private readonly ILogger<CryptoCoinElasticController> _logger;

		public CryptoCoinElasticController(IElasticClient elasticClient, ILogger<CryptoCoinElasticController> logger)
		{
			_elasticClient = elasticClient;
			_logger = logger;
		}

		// // POST: api/crypto-coins
		// [HttpPost]
		// public IActionResult Create([FromBody] CreateNewCryptoCoin model)
		// {
		// 	_cryptoCoinService.CreateCryptoCoin(model);

		// 	return Ok(new { message = "Crypto coin created successfully!" });
		// }

		// // DELETE: api/crypto-coins/id
		// [HttpDelete("{id}")]
		// public IActionResult Delete(int id)
		// {
		// 	var item = _cryptoCoinService.GetCryptoCoin(id);

		// 	if (item == null)
		// 		return NotFound("Crypto coin doesn't exist");


		// 	_cryptoCoinService.DeleteCryptoCoin(item.Id);

		// 	return Ok(new { message = "Crypto coin deleted successfully!" });
		// }

		// // GET: api/crypto-coins
		// [HttpGet]
		// public IActionResult GetList()
		// {
		// 	return Ok(_cryptoCoinService.GetCryptoCoins());
		// }

		// GET: api/crypto-coins/id
		[HttpGet("{keword}")]
		public async Task<IActionResult> GetById(string keword)
		{
			var item = await _elasticClient.SearchAsync<CryptoCoin>(s => s.Query(d => d.QueryString(d => d.Query('*'+keword+'*'))).Size(1000));

			if(item == null)
				return NotFound("Crypto coin doesn't exist");

			// var read = new ReadCryptoCoin { Name = item.Name, Amount = item.Amount };	// add prop "profit"

			return Ok(item);
		}
	}
}