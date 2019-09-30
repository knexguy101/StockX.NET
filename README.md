Welcome! This project is a simple SDK that allows users to interface with StockX API without having to scrape for their endpoints and structures.

This project is free and can be used however and wherever, but I am not responsible for anything that happens with it. Use is up to the developer that downloads this project at the end of the day.

TODO:
- Buy and Sell Abilities

FUNCTIONS:
SearchProducts:
-Condition- the search string, the function will automatically URL encode this
-Proxy- the optional proxy that can be used to contact the server with
Returns a list of products that match the search string by mimicing the search function on StockX

ListProducts:
-PageAmount- the number of pages the function will pull data from
-Type- The Type of item the function will pull from StockX
-Proxy- the optional proxy that can be used to contact the server with
Returns a list of products that are on each page within the range of 0 to PageAmount

ListSales:
-ProductID- the ID of the product, this can be pulled from the Product Class
-PagesOfSales- the number of pages of sales that will be pulled on that item
-Proxy- the optional proxy that can be used to contact the server with
Returns a list of sales associated with the product ID, Sales will contain the Date, Price, and Size
