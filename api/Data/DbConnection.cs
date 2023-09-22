
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
	public class DbConnection : DbContext
	{
		public DbConnection(DbContextOptions<DbConnection> opt) : base(opt) {}

		public DbSet<CryptoCoin> CryptoCoins { get; set; }
	}
}