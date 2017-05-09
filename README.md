

# Brief Description
<p>This repository contains the following assignment for:<br>
<strong>ErhvervsAkademi Sjælland: ASP.NET Core MVC</strong> <br>
lecturer and supervisor: <strong>Zuhair Haroon Khan</strong> (Adjunkt / Assistant Professor)</p>

## Requirements passed as per below:

<ul>
<li>Two factor Authentication via Twillio </li><br>
<img src="https://cdn.worldvectorlogo.com/logos/twilio-2.svg" height="50" width="auto"><br>
<li>External Authentication Factor via Facebook, Twitter, Microsoft, Google</li><br>
<span>
<img src="https://cdn.worldvectorlogo.com/logos/facebook.svg" height="50" width="auto">
<img src="https://upload.wikimedia.org/wikipedia/en/thumb/4/47/Twitter_2010_logo_-_from_Commons.svg/798px-Twitter_2010_logo_-_from_Commons.svg.png" height="50" width="auto">
<img src="https://cdn.worldvectorlogo.com/logos/microsoft.svg" height="50" width="auto">
<img src="https://cdn.worldvectorlogo.com/logos/google-2015.svg" height="50" width="auto"></span>
<br>
<li>Email address validation upon new user registration and password resets</li><br>
<img src="https://cdn.worldvectorlogo.com/logos/sendgrid.svg" height="50" width="auto"><br>
<li>Auth-Auth: ASP.NET Core MVC: <strong>Authentication</strong> and Role Based <strong>Authorisation</strong> with Identity</li>
<li>ASP.NET Core WebAPI with Entity Framework Core, full CRUD operations</li>
<li>Self-Signed SSL certificate and HTTPS</li>
<li>Live help chat with a fake customer service chatbot (to be implemented...)</li>
<li>Basic Bootstrap from Bootswatch and Font Awesome</li>
</ul>

# Ok, now tell me What does it do?
## The happy-path:
<ul>
<li>New users can register with their email address or with one of them popular social media accounts</li>
<li>If it's just a plain email address, they need to validate their account prior to login with the confirmation email</li>
<li>During registration they can select the required user roles and permissions to the app</li>
<li>Optional Two Factor Authentication (2FA) set up with mobile phone number via SMS</li>
<li>A "Customer" users can browse the webshop, add products to the shopping cart and proceed to checkout</li>
<li>During the checkout process they fill out a delivery form and confirm their order</li>
<li>The "Employee" users can check the orders and "ship" the products also "Create, Read, Update, Delete" the Products database</li>
<li>The "Admin" users can do all the above, in addition they have full CRUD controll over the Users and Permissions database</li>
</ul>

## Wuold be nice to have, later on might be implemented:
<ul>
<li>Connection between user accounts and order history</li>
<li>Marketing email to users by price changes (discounts)</li>
<li>Confirmation email or SMS if the order is shipped</li>
<li>Many more to get closer to a real e-commerce site...</li>
<li>Connect the API to make the prodeuct more light-weight</li>
<li>Change SQL to MongoDB</li>
</ul>

# How to Run & Deploy
<ul>
<li>
  <p>You need to restore the .NET Core packages which stored in the <code>.csproj</code> file<p>
  <p>Open a terminal or relevant command line tool from the project folder, which consists the file above</p>
  <pre>
  dotnet restore
  npm install
  bower install
  dotnet ef database update
  dotnet run
  </pre>
</li>
<li>Preferred IDE: Visual Studio 2017</li><br>
<li>Since <img src="https://cdn.worldvectorlogo.com/logos/google-chrome-1.svg" height="20" width="auto"> version 58 and higher <strong>does not</strong> support self signed certificates, I strongly recommend to use <img src="https://cdn.worldvectorlogo.com/logos/microsoft-edge.svg" height="20" width="auto"> browser for this project</li>
</ul>

### btw, GitHub now supports emojis...
:octocat: :alien: :see_no_evil: :hear_no_evil: :speak_no_evil: :rage2: :man_with_turban:
