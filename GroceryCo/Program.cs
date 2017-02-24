using System;
using GroceryCo.DataReader;
using GroceryCo.Display;

namespace GroceryCo
{
	class MainClass
	{
		/// <summary>
		/// In this section I call 2 seperate methods which collect initial information, the first GetInventory obtains all of the 
		/// inventory informatio which is saved in a CSV file and populates the inventory. The second method obtains all of the items
		/// that are in the 'shopping basket' which is saved in a textfile.
		/// </summary>
		public static void Main(string[] args)
		{
			try
			{
				Inventory inventory = InventoryReader.GetInventory();

				ReceiptDislplay receiptPrinter = new ReceiptDislplay();

				var receipt = ShopingBasketReader.GetShoppingBasketInfo(inventory);

				receiptPrinter.PrintReciept(receipt);
			}
			catch (ApplicationException a)
			{
				Console.WriteLine(a.Message);
			}
		}
	}
}

