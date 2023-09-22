namespace Api.Models
{
	public class CryptoCoin
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public double Amount { get; set; }
		public double BuyPrice { get; set; }
		public double CurrentPrice { get; set; }
	}
}