
using System.ComponentModel.DataAnnotations;

namespace Api.Dto
{
	public class ReadCryptoCoin
	{
		[Required]
		public string Name { get; set; }
		[Required]
		public double Amount { get; set; }
		[Required]
		public double BuyPrice { get; set; }
		[Required]
		public double CurrentPrice { get; set; }
	}
}