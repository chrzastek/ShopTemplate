Web application "ShopTemplate" made in ASP.NET Core 2.1

Purpose is to project an application that allows to set up and configure own web shop. It requires two main app components:
-end user panel: piece of application that exposes its features and is accessible to everyone (finished and working)
-administrator panel: will be accessible only for app administrators. Place where almost every element of the app can be configured (not exists yet)

features:
-user accounts: logging, google account authorisation, password reseting, user address, e-mail confirmation links and notifications
-paging and filtering products (price, category, name)
-cart: adding products to cart, removing products, computing cart total, cart details
-orders: placing orders, displaying user orders, filtering orders (date, name, total, state), order summary e-mail notifications, 
         order state tracking, order details
-product rates: adding product review and stars after purchasing, displaying item reviews per user
-contact: sending messages as user or anonymous to app owner

used technologies:
-ASP.NET Core MVC
-Entity Framework Core
-ASP.NET Core Identity
-MS SQL DB
-Dependency Injection
-AutoMapper
-Unit Tests + mocking (Moq)
-Razor Pages
-HTML
-Bootstrap
