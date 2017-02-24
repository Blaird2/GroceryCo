using NUnit.Framework;
using GroceryCo;
using System;

namespace GrocerCo.Tests
{
	[TestFixture()]
	public class InventoryFixture
	{
		[Test()]
		public void FindItem_ShouldThrowApplicationExceptionWhenItemDoesNotExist()
		{
			//setup
			var inventory = new Inventory();

			//assert
			Assert.Throws<ApplicationException>(() => inventory.FindItem("someitem"));
		}
	}
}
