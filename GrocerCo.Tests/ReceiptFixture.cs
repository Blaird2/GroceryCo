using NUnit.Framework;
using GroceryCo;

namespace GrocerCo.Tests
{
	[TestFixture()]
	public class ReceiptFixture
	{

		/// <summary>
		/// This test is showing that a new product will not be made, if two of the same types of products are added
		/// then the quantity should increase not the number of objects in receipt, so I am adding two apples and 
		/// expecting that there is still only one object.
		/// </summary>
		[Test()]
		public void AddTwoItemsToReceipt_ShouldAddOnlyOneObject()
		{
			// Setup
			var receipt = new Receipt();

			// Act 
			receipt.AddReceiptItem(new ProductInformation("apple", 1, 1, true));
			receipt.AddReceiptItem(new ProductInformation("apple", 1, 1, true));

			// Assert
			Assert.That(receipt.ReceiptItems.Count, Is.EqualTo(1));
		}



		/// <summary>
		/// This test is making sure that if two grocery items will appear as two seperate objects. Basically I wanted
		/// to test the if else statement within AddReceiptItem separately.
		/// </summary>

		[Test()]
		public void AddReceiptItem_ShouldAddToQuantity()
		{
			// Setup
			var receipt = new Receipt();

			// Act
			receipt.AddReceiptItem(new ProductInformation("apple", 4, 1, true));
			receipt.AddReceiptItem(new ProductInformation("orange", 3, 1, true));

			// Assert
			Assert.That(receipt.ReceiptItems.Count, Is.EqualTo(2));
		}








	}
}
