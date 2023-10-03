using Api.Dto;
using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	[Route("api/crypto-coins")]
	[ApiController]
	public class CryptoCoinController : ControllerBase
	{
		private readonly ICryptoCoinService _cryptoCoinService;
		private readonly ILogger<CryptoCoinController> _logger;

		public CryptoCoinController(ICryptoCoinService cryptoCoinService, ILogger<CryptoCoinController> logger)
		{
			_cryptoCoinService = cryptoCoinService;
			_logger = logger;
		}

		// POST: api/crypto-coins
		[HttpPost]
		public IActionResult Create([FromBody] CreateNewCryptoCoin model)
		{
			_cryptoCoinService.CreateCryptoCoin(model);

			return Ok(new { message = "Crypto coin created successfully!" });
		}

		// DELETE: api/crypto-coins/id
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var item = _cryptoCoinService.GetCryptoCoin(id);

			if (item == null)
				return NotFound("Crypto coin doesn't exist");


			_cryptoCoinService.DeleteCryptoCoin(item.Id);

			return Ok(new { message = "Crypto coin deleted successfully!" });
		}

		// GET: api/crypto-coins
		[HttpGet]
		public IActionResult GetList()
		{
			_logger.LogInformation("Log testing");
			return Ok(_cryptoCoinService.GetCryptoCoins());
		}

		// GET: api/crypto-coins/id
		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var item = _cryptoCoinService.GetCryptoCoin(id);

			if(item == null)
				return NotFound("Crypto coin doesn't exist");

			var read = new ReadCryptoCoin { Name = item.Name, Amount = item.Amount };	// add prop "profit"

			return Ok(read);
		}
	}
}