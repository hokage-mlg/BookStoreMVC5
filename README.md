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

<div align="center">
<img src="https://github.com/hokage-mlg/BookStoreMVC5/blob/master/Screenshots/MainWindow.png">
</div>

The application also partially supports use via mobile devices (tested on Pixel 2). This is how the main window on the phones looks:

<div align="center">
<img src="https://github.com/hokage-mlg/BookStoreMVC5/blob/master/Screenshots/MainWindowMobile.png">
</div>

Book search example:

<div align="center">
<img src="https://github.com/hokage-mlg/BookStoreMVC5/blob/master/Screenshots/Search.png">
</div>

## Registration, authentication and authorization

The user can either create or enter into an already created profile.

Register window:

<div align="center">
<img src="https://github.com/hokage-mlg/BookStoreMVC5/blob/master/Screenshots/Register.png">
</div>

Login window:

<div align="center">
<img src="https://github.com/hokage-mlg/BookStoreMVC5/blob/master/Screenshots/Login.png">
</div>

>Yes, the book logo rotates, thanks to <a href="https://fontawesome.com/">fontawesome</a> ❤️

After entering the personal account, the user has the default user role, 
and by default there is one administrator who can both promote ordinary users to the administrator and lower them to users.
