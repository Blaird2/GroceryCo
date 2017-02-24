# GroceryCo2

Input

In this application I have embedded the two files that I make use of, I used a text file for the 'shopping bag' and a CSV file for the inventory. If I had more time I would have made use of a library to parse out the CSV file. For both files it does not matter whether they are upper or lower cased. I have implemented items being on sale in two ways: sale price and buy one get one free - for buy one get one free I am assuming that when this is applied we are making use of the regular price. If an item is on sale the sale price will be displayed, if there is no applicable sale price than that seciton will be left blank for that item. The columns for regular and sale price are displaying the price for a single item while subtotal takes into account the quantity and multiplies it by the appropriate price.



In this application I made use of an interface for the printer functionality so that it did not just have to be printed to the console in the future, for example a GUI could be made.

Assumptions: I am assuming that the CSV file has no negative product price values. I would have liked to have found a better way to collect the data, I realize that toString was not the best choice. 

Unit Test:

I know that my unit test is accessing some parts that I am not testing directly, in the future I would like to learn how to properly mock objects to avoid this. I learned how to unit test recently with this assignment in mind.


