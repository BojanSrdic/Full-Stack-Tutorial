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

		public CryptoCoinController(ICryptoCoinService cryptoCoinService)
		{
			_cryptoCoinService = cryptoCoinService;
		}

		// POST: api/crypto-coins
		[HttpPost]
		public IActionResult Create([FromBody] CryptoCoin model)
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
			return Ok(_cryptoCoinService.GetCryptoCoins());
		}

		// GET: api/crypto-coins/id
		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var item = _cryptoCoinService.GetCryptoCoin(id);

			if(item == null)
				return NotFound("Crypto coin doesn't exist");

			var read = new CryptoCoin { Name = item.Name, Amount = item.Amount };

			return Ok(read);
		}
	}
}