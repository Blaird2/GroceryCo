using System;
namespace GroceryCo.Display
{
	public class ReceiptDislplay : IPrintReciept
	{

		/// <summary>
		/// Resonsible for all the printing.
		/// </summary>
		/// <param name="receipt">Receipt.</param>
		public void PrintReciept(Receipt receipt)
		{
			//Prints the Receipt
			Console.WriteLine("+++++++++++++++++++++ WELCOME TO BRUCE'S SUPERMARKET +++++++++++++++++++++");
			var HorizontalBorder = "++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++";
			var VerticalBorder = "++                                                                      ++";
			Console.WriteLine(HorizontalBorder);

			Console.WriteLine("++ \t\t\t   Ingredients for Life \t\t\t++");
			Console.WriteLine(HorizontalBorder);

			Console.WriteLine(VerticalBorder);
			Console.WriteLine("++ \tItem \t   Original \tSale \tQty.\tDisc.\tSubtotal\t++");
			Console.WriteLine("++ \t     \t   Price    \tPrice\t      \tType              \t++");
			Console.WriteLine(VerticalBorder);
			Console.Write(receipt.ToString());
			Console.WriteLine(VerticalBorder);
			var ReceiptTotal = Convert.ToString(receipt.CalculateTotal());
			Console.WriteLine("++ \t\t\t\t\t\tTotal: " + ReceiptTotal + "\t\t++");
			Console.WriteLine(VerticalBorder);
			Console.WriteLine(HorizontalBorder);
			Console.WriteLine(HorizontalBorder);
		}




	}
}
