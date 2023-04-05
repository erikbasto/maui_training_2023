# NET MAUI Training 2023

Small app created as part of NET MAUI Training. Includes the following sections:
* **Login**: It consumes a service to get the access token based on the credentials.
* **About**: It validates if the access token is part of Preferences. If this value is missing, it will redirect to LoginPage.    
* **Sales Dashboard**: Get sales from SQLite and display few stats.
* **Property Sales** : Includes search capability, display list of categories and trending properties (This section uses a service to get/store information)
   - The search will make a request to the server every time the search field has more than 3 characters and 1 second has passed since the user stopped typing. This optimizes the number of requests to the service.
   - When selecting a category, the app redirects to the property listing page following the master-detail approach (using IQueryAttributable)
   - When selecting a listing property, the app will display the property details and the option to bookmark the property and call/message the owner.
   - It includes a tab with the list of bookmarks. Selecting one of them displays the details and options to call/send a message to the owner. It followw the master-detail approach.
* **Shop Settings** : It uses a InMemory context to get clients, products and categories for the shop. Its a Tabbed Page.
* **Store** : It uses a SQLite and InMemory context to purchase products. 
