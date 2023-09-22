
using Api.Models;

namespace Api.Services.DapperPoc
{
	public interface ICryptoCoinDapperService
	{
		Task<IEnumerable<CryptoCoin>> GetCryptoCoinsAsync();
		Task<CryptoCoin> GetCryptoCoinAsync(int id);
		Task<int> CreateCryptoCoinAsync(CryptoCoin coin);
		Task<bool> UpdataCryptoCoinAsync(CryptoCoin coin);
		Task<bool> DeleteCryptoCoinAsync(int id);
	}
}