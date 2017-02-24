using NUnit.Framework;
using GroceryCo;

namespace GrocerCo.Tests
{
	[TestFixture()]
	public class ReceiptFixture
	{
		[Test()]
		public void AddReceiptItem_ShouldAddToReceiptItems()
		{
			//setup
			var receipt = new Receipt();

			//act 
			receipt.AddReceiptItem(new ProductInformation("apple",1,1,true));

			//assert
			Assert.That(receipt.ReceiptItems.Count, Is.EqualTo(1));
		}
	}
}
