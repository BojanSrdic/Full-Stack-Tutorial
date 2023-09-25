
using System.ComponentModel.DataAnnotations;

namespace Api.Dto
{
	public class CreateNewCryptoCoin
	{
		[Required]
		public string Name { get; set; }
		[Required]
		public double Amount { get; set; }
		[Required]
		public double BuyPrice { get; set; }
	}
}