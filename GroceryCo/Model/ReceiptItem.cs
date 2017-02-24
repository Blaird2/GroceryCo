using System;
namespace GroceryCo
{
	/// <summary>
	/// Receipt item is where quantity is added which is needed in the receipt and the label for the type of price
	/// each item will have is done. This label will also be used in the receipt.
	/// </summary>
	public class ReceiptItem : IReceiptItem
	{
		private ProductInformation ProductInformation;
		private int Quantity;

		public ReceiptItem(ProductInformation ProductInfo)
		{
			ProductInformation = ProductInfo;
			Quantity = 1;
		}

		public void IncrementQuantity()
		{
			Quantity++;
		}
		public int GetQuantity()
		{
			return Quantity;
		}
		public string DetermineTypeOfSale()
		{
			string result;
			if ((ProductInformation.GetTwoForOne() == true) & (Quantity >= 2))
				result = "2FOR1";
			else if (ProductInformation.GetSalePrice() == 0)
				result = "REG";
			else
				result = "SALE";
			return result;
		}

		/// <summary>
		/// This will return the quantity of an item multiplied by either the sales price if there is one or the regular
		/// price, this function also makes sure to take into account the buy one get one deal, so it may remove some 
		/// quantity to account for this.
		/// </summary>
		public decimal MultCorrectPriceByQuant()
		{
			decimal QuantityTimesItemPrice;
			decimal QuantityInDec = (decimal)Quantity;
			if (ProductInformation.GetTwoForOne() == true)
			{
				var DivideQuantBy2 = Decimal.Floor(QuantityInDec / 2);
				var FindQuant2 = QuantityInDec - (DivideQuantBy2 * 2);
				var AdjustedQuant = DivideQuantBy2 + FindQuant2;
				QuantityTimesItemPrice = (AdjustedQuant * ProductInformation.GetRegularPrice());
			}

			else if (ProductInformation.GetSalePrice() == 0)
			{
				QuantityTimesItemPrice = (QuantityInDec * ProductInformation.GetRegularPrice());
			}
			else
			{
				QuantityTimesItemPrice = (QuantityInDec * ProductInformation.GetSalePrice());
			}
			return QuantityTimesItemPrice;
		}

		public string toString()
		{
			var result = "++  \t" + ProductInformation.GetName() + "\t   " + ProductInformation.toString() + "\t  " +
									Quantity + "\t" + DetermineTypeOfSale() + "\t" + MultCorrectPriceByQuant() + "\t\t++";
			return result;
		}
	}
	}

