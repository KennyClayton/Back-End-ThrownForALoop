// See https://aka.ms/new-console-template for more information


using System.Reflection.Metadata.Ecma335;
using Microsoft.Win32.SafeHandles;

List<Product> products = new List<Product>() // Product is a custom class we created and gave the properties within each Product instance below
{
    new Product() // "the curly braces below are called the object initializer"...kind of like a "collection initializer" for List...it sets values right away at creation
    {
        Name = "Football",
        Price = 15.00M,
        Sold = false,
        Material = "leather",
        StockDate = new DateTime(2023, 8, 18),
        ManufactureYear = 2010,
        Condition = 3.2
    },
    new Product() //* this is a new "instance" of the Product class 
    {
        Name = "Hockey Stick",
        Price = 12.00M,
        Sold = true,
        Material = "polymer",
        StockDate = new DateTime(2023, 8, 10),
        ManufactureYear = 2011,
        Condition = 3.0
    },
    //* each of these is an "instance" of the Product class ... each product object is an instance of the Product class
    new Product()
    {
        Name = "Soccer Ball",
        Price = 12.00M,
        Sold = false,
        Material = "leather",
        StockDate = new DateTime(2023, 8, 1),
        ManufactureYear = 2020,
        Condition = 4.2
    },
    new Product()
    {
        Name = "Baseball",
        Price = 8.00M,
        Sold = true,
        Material = "cowhide",
        StockDate = new DateTime(2022, 4, 10),
        ManufactureYear = 2003,
        Condition = 5.0
    },
    new Product()
    {
        Name = "Basketball",
        Price = 18.00M,
        Sold = false,
        Material = "leather",
        StockDate = new DateTime(2021, 12, 18),
        ManufactureYear = 2005,
        Condition = 2.3
    },
    new Product()
    {
        Name = "Tennis Racket",
        Price = 25.00M,
        Sold = false,
        Material = "metal",
        StockDate = new DateTime(2023, 8, 8),
        ManufactureYear = 2023,
        Condition = 4.0
    }
};

// Console.WriteLine($"{i + 1}. {products[i].Name}"); //* "products[i], instead of being a string as it was before, is now an instance of Product"


DateTime now = DateTime.Now;

// Above we see that unless the declared variable is initialized, we will see an alert to indicate the variable isnt being used.
//* we initialize the greeting variable by assigning it data (a string in this case)
string greeting = @$"Welcome to Thrown for a Loop! 
Your one-stop shop for used sporting equipment. Today is {now}"; //to make a string multi-line, we can prepend the string with an @

//* we reference the greeting variable here when we ask WriteLine to console it for us
Console.WriteLine(greeting);
string choice = null;
while (choice != "0")
{
    Console.WriteLine(@"Choose an option:
                        0. Exit
                        1. View All Products
                        2. View Product Details
                        3. View Latest Additions");
    choice = Console.ReadLine();
    if (choice == "0")
    {
        Console.WriteLine("Goodbye!");
    }
    else if (choice == "1")
    {
        ListProducts();
    }
    else if (choice == "2")
    {
        ViewProductDetails();
    }
    else if (choice == "3")
    {
        ViewLatestProducts();
    }
}



void ViewProductDetails() //^ this is a method that acts like a function. We can wrap code inside of it so we can use it mutliple times. Originally the code was outside of this method veriable and it only ran once when a user selected a product. 
{
    // add the prices of all products in the inventory
ListProducts(); //We call the ListProducts method here. This method is defined below and it displays total inventory value and the list of Products we've been seeing displayed 



//^1 NEW - Below code replaced the commented code below it

Product chosenProduct = null; // Product is the type of variable; chosenProduct is the variable name; null is a placeholder instead of an empty string or other defined data type

while (chosenProduct == null) // while is a loop; so while chosenProduct is equal to null in two ways...
{
    Console.WriteLine("Please enter a product number: "); //...while chosenProduct is null, display this prompt to enter a product number...
    try // 
    {
        int response = int.Parse(Console.ReadLine().Trim()); //response is an integer variable...whose value is whatever the user input (ie Read the Line), trimmed so no extra spaces display.
        chosenProduct = products[response - 1]; //...chosenProduct is the product whose index value is whatever integer the user input minus 1. 
        //& So if the user input 4 into the ReadLine (as a way of speaking)...
        //& ...this while function will trim any excess spaces, parse it into an integer and store it into the "response" variable...
        //& ...then, the integer stored in "response" (in this exampled it's 4) is subtracted by one which equals 3. 
        //& ...then, "products" index 3 is stored into the "chosenProduct" variable.
    }
    catch (FormatException)
    {
        Console.WriteLine("Please type only integers!");
    }
    catch (ArgumentOutOfRangeException)
    {
        Console.WriteLine("Please choose an existing item only!");
    }
    catch (Exception ex) //*  If any of the code inside the try part throws an Exception, instead of shutting down the program, it runs the code in the catch section instead.
    {
        Console.WriteLine(ex); // this lets us see the error. We can capture the Exception value in the catch with this code and adding (Exception ex) as a ... parameter?
        Console.WriteLine("Do better!"); //so this will display if the user enters something other than an integer or a blank
    }
}


//^1 OLD START - Below code commented out and replaced with above code
// Console.WriteLine("Please enter a product number: ");

// // null (the default value for a string)
// int response = int.Parse(Console.ReadLine().Trim()); //? What does it mean for a function to return a value, and how is that working in the line
// //* the ReadLine function is returning to us (displaying) the input from the user (the value). So the user is defining the value of the input when the user types...we just gave them a space to do it.
// //ReadLine is a method. It returns a value. 
// //When ReadLine is called, the program will wait for the user to type text and press Enter
// //* "This (Trim) will turn any whitespace-only answers into empty answers, and will also trim any valid answers with whitespace on the ends"

// //* "In C#, the expression inside the parentheses after if must evaluate to true or false"
// //IsNullOrEmpty returns a boolean
// // while (string.IsNullOrEmpty(response)) // if the string is empty or null (and remember to reference "response" somewhere below) and write that the user didn't choose anything.
// while (response > products.Count || response < 1) // products.count instead of a specific number there so it can auto-fill whatever the count is
// {
//     Console.WriteLine($"Choose a number between 1 and {products.Count}"); // if the above while is true, then WRITE this message to the terminal and run "response" which will give the user another input opportunity to write some characters there...
//     response = int.Parse(Console.ReadLine().Trim()); // "we can reassign response, similar to a variable declared with let in Javascript"
// }
//  // otherwise, if the string is NOT empty or null, reference the response variable to do this...

// Product chosenProduct = products[response - 1]; // Why do we subtract one here? "We need to subtract 1 from the user's answer (if they chose option 3, that will correspond to index 2 in the List)."
//^1 OLD END - Above code commented out and replaced



// DateTime now = DateTime.Now;

TimeSpan timeInStock = now - chosenProduct.StockDate;
Console.WriteLine(@$"You chose a {chosenProduct.Material} {chosenProduct.Name} that's rated {chosenProduct.Condition} / 5 condition. That's gonna run you about {chosenProduct.Price} dollars. It's {now.Year - chosenProduct.ManufactureYear} years old and {(chosenProduct.Sold ? "not available." : $"has been in stock for {timeInStock.Days} days.")}"); //ternary - if chosen product boolean of "sold" is true, then it isn't available...otherwise it's been in stock for x days.

}

void ListProducts()
{
    decimal totalValue = 0.0M; //the totalValue variable type is "decimal" and it quals zero for now...always add "M" to end so compiler doesn't think it's a double
    foreach (Product product in products) //for each product of the product list (and remember these products are in a class called Product)...
    {
        if (!product.Sold) //...if the product Sold value is NOT true...meaning if the product sold is false, there is still inventory of that product...then...
        {
            totalValue += product.Price; //...then tally that product and all other products using their Price value...
        }
    }
    Console.WriteLine($"Total inventory value: ${totalValue}"); //...and then display this message with that total value...
    Console.WriteLine("Products:"); //... and then display a Products list by using below code which says...
    for (int i = 0; i < products.Count; i++) //...starting at zero, for as long as i is less than the number of products in our product list, increment by one and loop through again...
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}"); //...at each product being looped over... if i is index zero, then this would read: "1. Football" since football is the first product in the product List (array)....and so on.
    }
}

void ViewLatestProducts() //this function will allow the user to view 
{
    // create a new empty List to store the latest products
    List<Product> latestProducts = new List<Product>(); // List is the variable "type" and Product is the class. "latestProducts" is the variable name. and the key word "new" says to create a new Instance o the product list.
    // Calculate a DateTime 90 days in the past
    DateTime threeMonthsAgo = DateTime.Now - TimeSpan.FromDays(90); // DateTime is calculated by looking at now (DateTime.now) and subtracting 90 days from now...
    //loop through the products
    foreach (Product product in products) //now we'll implement our variable...for each Product class product in our products list...
    {
        //Add a product to latestProducts if it fits the criteria
        if (product.StockDate > threeMonthsAgo && !product.Sold) // ...if the stock date is more than our 90 days variableAND not yet sold out...
        {
            latestProducts.Add(product); //...then ADD those latest products to the product list 
        }
    }
    // print out the latest products to the console 
    for (int i = 0; i < latestProducts.Count; i++) // for every instance of a product...
    {
        Console.WriteLine($"{i + 1}. {latestProducts[i].Name}"); //...display the number and then the product name by index
    }
}