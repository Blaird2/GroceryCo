using System;
using System.IO;
using System.Reflection;

namespace GroceryCo.DataReader
{
	public class InventoryReader
	{
		const string PATH_TO_STORE = "GroceryCo.Data.Store.csv";

		public static Inventory GetInventory() { 
			var inventory = new Inventory();
			var _assembly = Assembly.GetExecutingAssembly();

			// Reads in inventory list which includes ItemName, RegularPrice, SalePrice and whether a two for one special is on.
			using (var reader = new StreamReader(_assembly.GetManifestResourceStream(PATH_TO_STORE)))
			{
				while (!reader.EndOfStream)
				{
					var line = reader.ReadLine();
					var values = line.Split(',');

					ProductInformation productInformation = new ProductInformation(values[0],
																				   Convert.ToDecimal(values[1]), Convert.ToDecimal(values[2]), Convert.ToBoolean(values[3]));

					inventory.AddItem(productInformation);
				}
			}
			return inventory;
		}
	}
}
