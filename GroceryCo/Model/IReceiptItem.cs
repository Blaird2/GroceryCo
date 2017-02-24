using System;
namespace GroceryCo
{
	/// <summary>
	/// Created an interface for extendability purposes.
	/// </summary>
	public interface IReceiptItem
	{
		void IncrementQuantity();
		decimal MultCorrectPriceByQuant();
	}
}
