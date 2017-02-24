using NUnit.Framework;
using GroceryCo;

namespace GrocerCo.Tests
{
	[TestFixture()]
	public class ReceiptItemFixture

	{
		private ProductInformation ProductInformation;
		[Test()]
		public void AddReceiptItem_ShouldIncrementQuantity()
		{
			//setup
			var receiptItem = new ReceiptItem(ProductInformation );


			//act 
			receiptItem(new ProductInformation("apple",1,1,true));

			//assert
			Assert.That(receipt.ReceiptItems.Count, Is.EqualTo(1));
		}
	}
}
