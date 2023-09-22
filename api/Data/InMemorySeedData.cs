using Api.Models;

namespace Api.Data
{
	public class InMemorySeedData
	{
		public static void AddTestDataInMemory(IServiceProvider serviceProvider)
		{
			using var scope = serviceProvider.CreateScope();
			var context = scope.ServiceProvider.GetRequiredService<DbConnection>();
			SeedData(context);
		}

		private static void SeedData(DbConnection context)
		{
			var coins = new[]
			{
				new CryptoCoin { Id = 1, Name = "BTC", Amount = 0.4, BuyPrice = 1745.43, CurrentPrice = 4010 }
			};

			context.CryptoCoins.AddRange(coins);
			context.SaveChanges();
		}
	}
}