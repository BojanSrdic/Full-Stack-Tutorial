using Api.Models;
using Dapper;
using System.Data;
namespace Api.Services.DapperPoc
{
    public class CryptoCoinDapperService : ICryptoCoinDapperService
    {
        private readonly IDbConnection _dbConnection;

        public CryptoCoinDapperService(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
        }

        public async Task<IEnumerable<CryptoCoin>> GetCryptoCoinsAsync()
        {
            return await _dbConnection.QueryAsync<CryptoCoin>("SELECT * FROM CryptoCoins");
        }

        public async Task<CryptoCoin> GetCryptoCoinAsync(int id)
        {
            return await _dbConnection.QuerySingleOrDefaultAsync<CryptoCoin>("SELECT * FROM CryptoCoins WHERE Id = @Id", new { Id = id });
        }

        public async Task<int> CreateCryptoCoinAsync(CryptoCoin coin)
        {
            const string sql = "INSERT INTO CryptoCoins (Name, Amount, BuyPrice, CurrentPrice) VALUES (@Name, @Amount, @BuyPrice, @CurrentPrice); SELECT SCOPE_IDENTITY();";
            return await _dbConnection.ExecuteScalarAsync<int>(sql, coin);
        }

        public async Task<bool> UpdateCryptoCoinAsync(CryptoCoin coin)
        {
            const string sql = "UPDATE CryptoCoins SET Name = @Name, Amount = @Amount, BuyPrice = @BuyPrice, CurrentPrice = @CurrentPrice WHERE Id = @Id";
            var affectedRows = await _dbConnection.ExecuteAsync(sql, coin);
            return affectedRows > 0;
        }

        public async Task<bool> DeleteCryptoCoinAsync(int id)
        {
            const string sql = "DELETE FROM CryptoCoins WHERE Id = @Id";
            var affectedRows = await _dbConnection.ExecuteAsync(sql, new { Id = id });
            return affectedRows > 0;
        }

        public Task<bool> UpdataCryptoCoinAsync(CryptoCoin coin)
        {
            throw new NotImplementedException();
        }
    }
}
