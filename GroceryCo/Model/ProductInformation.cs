using System;
using GroceryCo.Model;

namespace GroceryCo
{
	/// <summary>
	/// For the most part this class is used to obtain information by making use of get methods.
	/// </summary>
	public class ProductInformation : IProductInformation
	{
		private readonly string _itemName;
		private readonly decimal _regularPrice;
		private readonly decimal _salePrice;
		private readonly bool _isTwoForOne;

		public ProductInformation(string itemName, decimal regularPrice, decimal SalePrice, Boolean IsTwoForOne)
		{
			_itemName = itemName;
			_regularPrice = regularPrice;
			_salePrice = SalePrice;
			_isTwoForOne = IsTwoForOne;
		}

		public decimal GetSalePrice()
		{
			return _salePrice;
		}

		public decimal GetRegularPrice()
		{
			return _regularPrice;
		}

		public string GetName()
		{
			return _itemName;
		}

		/// <summary>
		/// This function determines whether a discount price needs to be printed, if there is no discount then it will
		/// return an empty string.
		/// </summary>
		/// <returns>The print discount.</returns>
		public string GetPrintDiscount()
		{
			string final = "";
			if ((_salePrice != 0) & (!GetTwoForOne()))
			{
				return final = Convert.ToString(_salePrice);
			}
			else
			{
				return final;
			}
		}

		/// <summary>
		/// This is the beginning of collecting a string with all the information that is needed for 1 object to be 
		/// printed. The remaining parts will be obtained in ReceiptItem.
		/// </summary>
		public string toString()
		{
			var final = _regularPrice + "\t\t" + GetPrintDiscount();
			return final;
		}

		public bool GetTwoForOne()
		{
			return _isTwoForOne;
		}


	}
}
