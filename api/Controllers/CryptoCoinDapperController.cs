using Api.Models;
using Api.Services.DapperPoc;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
	[Route("api/crypto-coins-dapper")]
	[ApiController]
	public class CryptoCoinDapperController : ControllerBase
    {
	 	private readonly ICryptoCoinDapperService _cryptoCoinService;

		public CryptoCoinDapperController(ICryptoCoinDapperService cryptoCoinService)
		{
			_cryptoCoinService = cryptoCoinService;
		}

		// POST: api/crypto-coins-dapper
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CryptoCoin model)
        {
            await _cryptoCoinService.CreateCryptoCoinAsync(model);

            return Ok(new { message = "Crypto coin created successfully!" });
        }

		// DELETE: api/crypto-coins-dapper/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _cryptoCoinService.GetCryptoCoinAsync(id);

            if (item == null)
                return NotFound("Crypto coin doesn't exist");

            await _cryptoCoinService.DeleteCryptoCoinAsync(item.Id);

            return Ok(new { message = "Crypto coin deleted successfully!" });
        }

		// GET: api/crypto-coins-dapper
		[HttpGet]
        public async Task<IActionResult> GetList()
        {
            var coins = await _cryptoCoinService.GetCryptoCoinsAsync();
            return Ok(coins);
        }

		// GET: api/crypto-coins/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _cryptoCoinService.GetCryptoCoinAsync(id);

            if (item == null)
                return NotFound("Crypto coin doesn't exist");

            // var read = new CryptoCoin { Name = item.Name, Amount = item.Amount };

            return Ok(item);
        }
	}
}