using System;
using System.Collections.Generic;

namespace GroceryCo
{

	/// <summary>
	/// This class is responsible for adding items to the reciept and also adding up the amount owed.
	/// </summary>
	public class Receipt : IReceipt
	{
		/// <summary>
		/// A dictionary with the key being the product name, and the value being the receipt items
		/// </summary>
		public Dictionary<string, ReceiptItem> ReceiptItems;

		public Receipt()
		{
			ReceiptItems = new Dictionary<string, ReceiptItem>();
		}

		public void AddReceiptItem(ProductInformation Item)
		{
			if (ReceiptItems.ContainsKey(Item.GetName()))
			{
				ReceiptItems[Item.GetName()].IncrementQuantity();
			}
			else
			{
				ReceiptItems.Add(Item.GetName(), new ReceiptItem(Item));
			}
		}

		public decimal CalculateTotal()
		{
			decimal Total = 0;
			foreach (KeyValuePair<string, ReceiptItem> entry in ReceiptItems)
			{
				Total += entry.Value.MultCorrectPriceByQuant();
			}
			return Total;
		}

		public override string ToString()
		{
			var final = "";
			foreach (KeyValuePair<string, ReceiptItem> entry in ReceiptItems)
			{
				final += entry.Value.toString() + "\n";
			}
			return final;
		}
	}
}

