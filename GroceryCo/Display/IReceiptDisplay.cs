using System;
namespace GroceryCo.Display
{
	/// <summary>
	/// This was made with extensibility in mind, for instance instead of having it print to console, this function 
	/// could be replaced with a GUI setup
	/// </summary>
	public interface IPrintReciept
	{
		void PrintReciept(Receipt receipt);
	}
}
