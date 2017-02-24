﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using GroceryCo.DataReader;

namespace GroceryCo
{
	class MainClass
	{

		public static void Main(string[] args)
		{
			try
			{
				var inventory = InventoryReader.GetInventory();
				ReceiptPrinter receiptPrinter = new ReceiptPrinter();
				Receipt receipt = new Receipt();
			

				//var receipt = new ReceiptFactory().GetReceiptObject();
			

				var _assembly = Assembly.GetExecutingAssembly();
				using (var reader = new StreamReader(_assembly.GetManifestResourceStream("GroceryCo.Data.ShoppingBasket.txt")))
				{
					while (!reader.EndOfStream)
					{
						var line = reader.ReadLine();
						ProductInformation NewProduct = inventory.FindItem(line);
						// check if item is in fact an item.
						receipt.AddReceiptItem(NewProduct);
					}
				}
				receiptPrinter.PrintReciept(receipt);
		
		
			}
			catch (ApplicationException a) {
				Console.WriteLine(a.Message);
			}

		}
	}

	public class ReceiptPrinter
	{
		public void PrintReciept(Receipt receipt)
		{
			//Prints the Receipt
			Console.WriteLine("+++++++++++++++++++++ WELCOME TO BRUCE'S SUPERMARKET +++++++++++++++++++++");
			string HorizontalBorder = "++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++";
			string VerticalBorder = "++                                                                      ++";
			Console.WriteLine(HorizontalBorder);

			Console.WriteLine("++ \t\t\t   Ingredients for Life \t\t\t++");
			Console.WriteLine(HorizontalBorder);

			Console.WriteLine(VerticalBorder);
			Console.WriteLine("++  Quantity \tItem   TwoForOne \tRegular Price \tSale Price\t++");
			Console.WriteLine(VerticalBorder);
			Console.Write(receipt.toSString());
			Console.WriteLine(VerticalBorder);
			string ReceiptTotal = Convert.ToString(receipt.CalculateTotal());
			Console.WriteLine("++ \t\t\t\t\tTotal: " + ReceiptTotal + "\t\t\t++");
			Console.WriteLine(VerticalBorder);
			Console.WriteLine(HorizontalBorder);
			Console.WriteLine(HorizontalBorder);
		}
			
	}

	public class InventoryFactory
	{
		public IInventory GetInventoryObject()
		{
			return new Inventory();
		}

	}

	public class ReceiptFactory
	{
		public IReceipt GetReceiptObject()
		{
			return new Receipt();
		}
	}

	public interface IProductInformation
	{
		//DO I HAVE TO PUT CONSTRUCTORS HERE?
		decimal GetSalePrice();
		decimal GetRegularPrice();
		string getName();
		decimal getDiscount();
		string toSString();

	}

	public class ProductInformation : IProductInformation
	{
		private readonly string _itemName;
		private readonly decimal _regularPrice;
		private readonly decimal _sale;
		private readonly bool _twoForOne;

		public ProductInformation()
		{
		}

		public ProductInformation(string itemName, decimal regularPrice, decimal salePrice, Boolean twoForOne)
		{
			_itemName = itemName;
			_regularPrice = regularPrice;
			_sale = salePrice;
			_twoForOne = twoForOne;
		}

		public decimal GetSalePrice()
		{
			return _sale; //should get lines be on the same line?
		}

		public decimal GetRegularPrice()
		{
			return _regularPrice;
		}

		public string getName()
		{
			return _itemName;
		}

		public decimal getDiscount()
		{
			if (_regularPrice - _sale == _regularPrice)
			{
				return _regularPrice;
			}

			return _sale;
		}

		public string TwoForOneToString()
		{
			string Final;
			if (_twoForOne)
			{
				Final = "Yes";
				return Final;
			}
			else
			{
				Final = "";
				return Final;
			}
		}

		public string toSString()
		{
			string final = _itemName + "\t" + TwoForOneToString() + "\t\t" + _regularPrice + "\t\t" + getDiscount() + "\t\t++";
			return final;
		}

		public bool getTwoForOne()
		{
			return _twoForOne;
		}
	}

	public interface IReceiptItem
	{
		void IncrementQuantity();

		decimal QuantMultByCorrectPrice();
		string toSString();
	}

	public class ReceiptItem : IReceiptItem
	{
		private ProductInformation ProductInformation; //is this is a problem? does it break dependency inversion principle? 
													   //https://www.codeproject.com/Tips/1033646/SOLID-Principle-with-Csharp-Example bottom of page
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

		/// <summary>
		/// This will return the quantity of an item multiplied by either the sales price if there is one or the regular price.
		/// </summary>
		public decimal QuantMultByCorrectPrice()
		{
			decimal QuantityTimesItemPrice;
			decimal QuantityInDec = (decimal)Quantity;
			if (ProductInformation.getTwoForOne() == true)
			{
				var DivideQuantBy2 = Decimal.Floor(QuantityInDec / 2);
				var FindQuant2 = QuantityInDec - (DivideQuantBy2 * 2);
				decimal AdjustedQuant = DivideQuantBy2 + FindQuant2;
				QuantityTimesItemPrice = (AdjustedQuant * ProductInformation.GetRegularPrice());
				return QuantityTimesItemPrice;
			}

			if (ProductInformation.GetSalePrice() == 0)
			{
				QuantityTimesItemPrice = (QuantityInDec * ProductInformation.GetRegularPrice());
				return QuantityTimesItemPrice;
			}
			else //should I be removing these kinds of elses?
			{
				QuantityTimesItemPrice = (QuantityInDec * ProductInformation.GetSalePrice());
				return QuantityTimesItemPrice;
			}
		}

		public string toSString()
		{
			string result = "++  " + Quantity + "\t\t" + ProductInformation.toSString();
			return result;
		}
	}

	public interface IInventory
	{
		void AddItem(ProductInformation product);
		ProductInformation FindItem(string name);
	}


	public class Inventory : IInventory
	{
		private Dictionary<string, ProductInformation> Items;

		public Inventory()
		{
			Items = new Dictionary<string, ProductInformation>();
		}

		public void AddItem(ProductInformation product)
		{
			Items.Add(product.getName(), product);
		}

		public ProductInformation FindItem(string name)
		{
			if (Items.ContainsKey(name))
			{
				return Items[name];
			}
			throw new ApplicationException($"Sorry, but {name} does not exist in this store.  Nice try."); 
		}
	}

	public interface IReceipt
	{
		void AddReceiptItem(ProductInformation Item);
		decimal CalculateTotal();
		string toSString();
	}


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
			if (ReceiptItems.ContainsKey(Item.getName()))
			{
				ReceiptItems[Item.getName()].IncrementQuantity();
			}
			else
			{
				ReceiptItems.Add(Item.getName(), new ReceiptItem(Item));
			}
		}

		public decimal CalculateTotal()
		{
			decimal Total = 0;
			foreach (KeyValuePair<string, ReceiptItem> entry in ReceiptItems)
			{
				Total += entry.Value.QuantMultByCorrectPrice();
			}

			return Total;
		}
		public string toSString()
		{
			string final = "";
			foreach (KeyValuePair<string, ReceiptItem> entry in ReceiptItems)
			{
				final += entry.Value.toSString() + "\n";
			}
			return final;

		}
	}
}






