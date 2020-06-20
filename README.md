# Online bookstore via **ASP.NET MVC 5**
> Warning! The content presented in the application is written in Russian.

Hi everyone! I present to you my first ASP.NET MVC 5 project.
It is an online bookstore that allows you to select, search, order books, monitor order status and much more.
There is also an admin panel with which you can manage the store and customer profiles, you can add administrators and much more.
This file will describe the main features that are available to users and administrators. Screenshots are attached.
## Description
### Main Window
On the main window, the user can select the section of the site he needs, select the book genre that interests him,
find the book by author or title, go to his personal account and so on. Thus, the main window on the desktop computer looks like this:

<p align="center">
<img src="https://github.com/hokage-mlg/BookStoreMVC5/blob/master/Screenshots/MainWindow.png">
</p>

The application also partially supports use via mobile devices (tested on Pixel 2). This is how the main window on the phones looks:

<p align="center">
<img src="https://github.com/hokage-mlg/BookStoreMVC5/blob/master/Screenshots/MainWindowMobile.png">
</p>

Book search example:

<p align="center">
<img src="https://github.com/hokage-mlg/BookStoreMVC5/blob/master/Screenshots/Search.png">
</p>

### Registration, Authentication and Authorization

The user can either create or enter into an already created profile.

Register window:

<p align="center">
<img src="https://github.com/hokage-mlg/BookStoreMVC5/blob/master/Screenshots/Register.png">
</p>

Login window:

<p align="center">
<img src="https://github.com/hokage-mlg/BookStoreMVC5/blob/master/Screenshots/Login.png">
</p>

>Yes, the book logo rotates, thanks to <a href="https://fontawesome.com/">fontawesome</a> ❤️

After entering the personal account, the user has the default user role, 
and by default there is one administrator who can both promote ordinary users to the administrator and lower them to users.

### User Account

The user can change the data of his account, change the password, monitor the status of the order, view information about books purchased and delivery information, confirm receipt of goods.

This is what the main user account window looks like:

<p align="center">
<img src="https://github.com/hokage-mlg/BookStoreMVC5/blob/master/Screenshots/Profile.png">
</p>

This is how the user info change window looks:

<p align="center">
<img src="https://github.com/hokage-mlg/BookStoreMVC5/blob/master/Screenshots/EditProfile.png">
</p>

This is how the user password change window looks:

<p align="center">
<img src="https://github.com/hokage-mlg/BookStoreMVC5/blob/master/Screenshots/EditPassword.png">
</p>

Here is the user's shopping cart:

<p align="center">
<img src="https://github.com/hokage-mlg/BookStoreMVC5/blob/master/Screenshots/Cart.png">
</p>

This is how the window for filling out delivery information looks like:

<p align="center">
<img src="https://github.com/hokage-mlg/BookStoreMVC5/blob/master/Screenshots/EditDeliveryInfo.png">
</p>

This is the window for viewing user orders:

<p align="center">
<img src="https://github.com/hokage-mlg/BookStoreMVC5/blob/master/Screenshots/OrderList.png">
</p>

### Admin Account

The administrator can view information about books, change their properties, add new books, view information about users, change their roles, change delivery status, view detailed information about orders and delivery details.

The main window of the admin panel:

<p align="center">
<img src="https://github.com/hokage-mlg/BookStoreMVC5/blob/master/Screenshots/AdminPanel1.png">
<img src="https://github.com/hokage-mlg/BookStoreMVC5/blob/master/Screenshots/AdminPanel2.png">
</p>

This is how the book editing window looks:

<p align="center">
<img src="https://github.com/hokage-mlg/BookStoreMVC5/blob/master/Screenshots/EditBook.png">
</p>

## Programming Languages

- JS
- C#
- Html and CSS
- SQL

## Architecture

- DAL (Data Access Layer) via MS SQL
- BLL (Business Logic Layer)
- PL (Presentation Layer)

## Technology

- bootstrap
- FontAwesome
- EntityFramework
- jQuery
- jQuery.Validation
- Microsoft.AspNet.Mvc
- Microsoft.AspNet.Providers.Core
- Microsoft.AspNet.Providers.LocalDB
- Microsoft.AspNet.Razor
- Microsoft.AspNet.Web.Optimization
- Microsoft.AspNet.WebPages
- Microsoft.jQuery.Unobtrusive.Ajax
- Microsoft.jQuery.Unobtrusive.Validation
- Microsoft.Web.Infrastructure
- Modernizr
- Moq
- Newtonsoft.Json
- Ninject
- popper.js
- WebActivator
- WebGrease

## Future
Perhaps in the future I will add new functions for the application, change its structure, fully adapt it for smartphones, change the authorization and authentication system, and so on.

## License

[![License](http://img.shields.io/:license-mit-blue.svg?style=flat-square)](http://badges.mit-license.org)

[MIT](https://choosealicense.com/licenses/mit/)
