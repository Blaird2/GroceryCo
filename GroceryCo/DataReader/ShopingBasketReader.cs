using System.IO;
using System.Reflection;

namespace GroceryCo.DataReader
{
	public class ShopingBasketReader
	{
		/// <summary>
		/// Reads in items line by line and determines if the item that was just read in has the same name as an 
		/// existing item in inventory.
		/// </summary>
		/// <returns>The shopping basket info.</returns>
		/// <param name="inventory">Inventory.</param>
		public static Receipt GetShoppingBasketInfo(Inventory inventory)
		{
			var receipt = new Receipt();

			var _assembly = Assembly.GetExecutingAssembly();
			using (var reader = new StreamReader(_assembly.GetManifestResourceStream("GroceryCo.Data.ShoppingBasket.txt")))
			{
				while (!reader.EndOfStream)
				{
					var line = reader.ReadLine();
					ProductInformation NewProduct = inventory.FindItem(line);
					// check if item is in fact an item.
					receipt.AddReceiptItem(NewProduct);
				}
			}
			return receipt;
		}
	}
}
		