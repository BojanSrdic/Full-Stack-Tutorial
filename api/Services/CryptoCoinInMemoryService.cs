using Api.Data;
using Api.Models;

namespace Api.Services
{
	public class CryptoCoinInMemoryService : ICryptoCoinService
	{
		private readonly DbConnection _context;

		public CryptoCoinInMemoryService(DbConnection context)
		{
			_context = context;
		}

		public void CreateCryptoCoin(CryptoCoin model)
		{
			// Todo: Mapp domain models and data transfer objects
			var item = new CryptoCoin
			{
				Name = model.Name,
				Amount = model.Amount,
				CurrentPrice = model.CurrentPrice
			};

			// Todo: Add new models to tables in db and save changes
			_context.CryptoCoins.Add(item);
			_context.SaveChanges();
		}

		public void DeleteCryptoCoin(int id)
		{
			var item = _context.CryptoCoins.Find(id);

			// Todo: throw exception if user doesn't exist before deleting
			if (item is null)
				throw new KeyNotFoundException("Item not found");
			
			_context.CryptoCoins.Remove(item);
			_context.SaveChanges();
		}

		public CryptoCoin GetCryptoCoin(int id)
		{
			return _context.CryptoCoins.Find(id);
		}

		public List<CryptoCoin> GetCryptoCoins()
		{
			return _context.CryptoCoins.ToList();
		}

		public void UpdataCryptoCoin(CryptoCoin model)
		{
			throw new NotImplementedException();
		}
	}
}