
using Api.Dto;
using Api.Models;

namespace Api.Services
{
	public interface ICryptoCoinService
	{
		CryptoCoin GetCryptoCoin(int id);
		List<CryptoCoin> GetCryptoCoins();
		void CreateCryptoCoin(CreateNewCryptoCoin model);
		void UpdataCryptoCoin(CryptoCoin model);
		void DeleteCryptoCoin(int id);
	}
}