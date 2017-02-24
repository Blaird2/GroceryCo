using System;
using System.Collections.Generic;

namespace GroceryCo
{
	
public class Inventory : IInventory
		{
			private Dictionary<string, ProductInformation> Items;

			public Inventory()
			{
				Items = new Dictionary<string, ProductInformation>();
			}

			public void AddItem(ProductInformation product)
			{
				Items.Add(product.GetName(), product);
			}

			/// <summary>
			/// This will deterimine if the item in shopping basket is an item which is in the inventory, if it is not
			/// then it will display an error.
			/// </summary>
			/// <returns>The item.</returns>
			/// <param name="name">Name.</param>
			public ProductInformation FindItem(string name)
			{
				if (Items.ContainsKey(name))
				{
					return Items[name];
				}
				throw new ApplicationException($"Sorry, but {name} does not exist in this store.");
			}
		}
	}
	

