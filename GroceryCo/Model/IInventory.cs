using System;
namespace GroceryCo
{
	/// <summary>
	/// Created an interface for extendability purposes.
	/// </summary>
	public interface IInventory
	{
		void AddItem(ProductInformation product);
		ProductInformation FindItem(string name);
	}
}
