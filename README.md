# CMPS378 Midterm: Rigby Restaurant
### Submitted By: J-Zach Loke

# Description
Mimics a POS system that can handle purchases, return, add inventory, and view reports.

# Features
* Allows customers to buy and return items.
* Allows management to add and remove items from the inventory.
* Display a report on the number of customers and running profit total.

# How to Run
Compile `main.cs` using a C# compiler (preferrably Visual Studio's compiler). I specificually used `Microsoft (R) Visual C# Compiler version 4.8.3752.0`.

# Test Inputs & Outputs
The following is all in one run of the program. It is not

### Adding items into the inventory
```
Welcome to Target! Choose the following options:
1) Make a Purchase
2) Make a Return
3) Manage Inventory
4) View Report
Choose: 3

The following items are currently stored in the system:
Item Name           Price

1) Add New Item
2) Remove Item
3) Main Menu
Choose: 1
Add Item:
        Item Name: Star Wars Lego
        Item Price: 25
Added Successfully!!
Continue? Y

-----------------------------------------------------------------------------------

Welcome to Target! Choose the following options:
1) Make a Purchase
2) Make a Return
3) Manage Inventory
4) View Report
Choose: 3

The following items are currently stored in the system:
Item Name           Price
Star Wars Lego      $25

1) Add New Item
2) Remove Item
3) Main Menu
Choose: 1
Add Item:
        Item Name: Cookie
        Item Price: 5
Added Successfully!!
Continue? Y

-----------------------------------------------------------------------------------

Welcome to Target! Choose the following options:
1) Make a Purchase
2) Make a Return
3) Manage Inventory
4) View Report
Choose: 3

The following items are currently stored in the system:
Item Name           Price
Star Wars Lego      $25
Cookie              $5

1) Add New Item
2) Remove Item
3) Main Menu
Choose: 1
Add Item:
        Item Name: Lorem Ipsum
        Item Price: 100
Added Successfully!!
Continue? Y

-----------------------------------------------------------------------------------
```

### Making purchases
```
Welcome to Target! Choose the following options:
1) Make a Purchase
2) Make a Return
3) Manage Inventory
4) View Report
Choose: 1

Which product would you like to purchase?
Item Name           Price
Star Wars Lego      $25
Cookie              $5
Lorem Ipsum         $100

Which item would you like to buy? Star Wars Lego
Anything else? Y

Which product would you like to purchase?
Item Name           Price
Star Wars Lego      $25
Cookie              $5
Lorem Ipsum         $100

Which item would you like to buy? Cookie
Anything else? Y

Which product would you like to purchase?
Item Name           Price
Star Wars Lego      $25
Cookie              $5
Lorem Ipsum         $100

Which item would you like to buy? Lorem Ipsum
Anything else? N
Your Total is $130
Thank you for shopping at Target!
Continue? Y

-----------------------------------------------------------------------------------
```

### Removing items from the inventory
```
Welcome to Target! Choose the following options:
1) Make a Purchase
2) Make a Return
3) Manage Inventory
4) View Report
Choose: 3

The following items are currently stored in the system:
Item Name           Price
Star Wars Lego      $25
Cookie              $5
Lorem Ipsum         $100

1) Add New Item
2) Remove Item
3) Main Menu
Choose: 2
Remove Item:
        Item Name: Lorem Ipsum
Continue? Y

-----------------------------------------------------------------------------------
```

### Making returns
Notice that the removed item (Lorem Ipsum) still shows up since a customer purchased it before it was removed from the inventory.
```
Welcome to Target! Choose the following options:
1) Make a Purchase
2) Make a Return
3) Manage Inventory
4) View Report
Choose: 2

Which product would you like to return?
Item Name           Price
Star Wars Lego      $25
Cookie              $5
Lorem Ipsum         $100

Which item would you like to return? Lorem Ipsum
Anything else? N
Your Refund total is $100
Thank you for shopping at Target!
Continue? Y

-----------------------------------------------------------------------------------
```

### Making more purchases
Notice that Lorem Ipsum is no longer purchaseable since it was removed.
```
Welcome to Target! Choose the following options:
1) Make a Purchase
2) Make a Return
3) Manage Inventory
4) View Report
Choose: 1

Which product would you like to purchase?
Item Name           Price
Star Wars Lego      $25
Cookie              $5

Which item would you like to buy? Cookie
Anything else? N
Your Total is $5
Thank you for shopping at Target!
Continue? Y

-----------------------------------------------------------------------------------
```

### Generating reports
Notice that there are only two customers even though there have been 4 total items purchased because one customer purchased 3 items.

Furthermore, notice that the profit counts only the sold items that have not been returned (1 Star Wars Lego @ $25 and 2 Cookies @ $5)
```
Welcome to Target! Choose the following options:
1) Make a Purchase
2) Make a Return
3) Manage Inventory
4) View Report
Choose: 4

Reports:
        Total Customers: 2
        Total Profit: 35
Continue? N
```