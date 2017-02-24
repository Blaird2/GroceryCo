using System;
namespace GroceryCo
{	
		/// <summary>
		/// Created an interface for extendability purposes.
		/// </summary>
		public interface IReceipt
		{
			void AddReceiptItem(ProductInformation Item);
			decimal CalculateTotal();
		}

}
