using NUnit.Framework;
using GroceryCo;
using System;

namespace GrocerCo.Tests
{
	[TestFixture()]
	public class InventoryFixture
	{
		/// <summary>
		/// Makes sure that that an expection will be thrown when an item that does not exist in inventory is
		/// attempting to be found. 
		/// </summary>
		[Test()]
		public void FindItem_ShouldThrowApplicationExceptionWhenItemDoesNotExist()
		{
			// Setup
			var inventory = new Inventory();

			// Assert
			Assert.Throws<ApplicationException>(() => inventory.FindItem("someitem"));
		}
	}
}
