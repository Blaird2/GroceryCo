using System;
namespace GroceryCo.Model
{
	/// <summary>
	/// Created an interface for extendability purposes.
	/// </summary>
	public interface IProductInformation
	{
		decimal GetSalePrice();
		decimal GetRegularPrice();
		string GetName();
	}
}
