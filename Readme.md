# Emailer Class Library

Welcome to the Emailer Class C# Project. A simplyfied way to Send Emails in .NET.

No needing to manually configure your SMTPs servers.

# Default SMTPs

We already have default configuration for the most Famous STMPS:
* Gmail
* Outlook
* Office365
* Hotmail
* Uol
* Terra
* Hostinger
* Titan

[Customized SMTP](#sending-email-with-a-custom-smtp)If yours isn't there, you can manually add your customized SMTP

## Setup

# Setup with Project

Clone the project to your local machine
````
$git clone https://github.com/matheushoske/Emailer.git
````

Add the Emailer project to your solution.
Visual studio:
````
Right Click Solution > Add > Project
````

Reference the emailer Project into your project
````
Right Click Project references > Add Reference > Project > Emailer
````
Then it´s done!

# Setup with Dll
Download the [Latest Release](https://github.com/matheushoske/Emailer/releases/latest) of the dll
Reference the dll into your project
Visual studio:
````
Right Click Project references > Add Reference > Browse > Select the Emailer.dll
````

Then it´s done!

### How to work with it

##Referencing

After setting up your project correctly,

Add the Emailer Library reference to your project: 
```csharp
using Emailer;
```

##Sending email with existing SMTP
Let's suppose that you have a Gmail, and want to send an email to your friend Michael. 
Look how easy it is:

```csharp
//Varibles for our message
string subject = "Here is my Subject!";
string body = "Here is the body of my email \n Regardings, Matheus Hoske"
//Setting up the static parameters like sender info and SMTP
Email.EmailFrom = "youremail@gmail.com";
Email.EmailPassword = "MyPassword";
Email.EmailPassword = "MyPassword";
Email.SmtpServer = Email.smtps.Gmail;

//Creating a new instance for the Email Object adding the receiver email
Email email = new Email("michael@anydomain.com");
//Sending the Email
email.Send(subject,body);
```

##Sending email with a custom SMTP
Now let's suppose that you want to use a SMTP server that aren't listed on our default SMTPs, and wanna send an email to your friend Richard. 
It's easy too, take a look:
```csharp
//Varibles for our message
string subject = "Here is my Subject!";
string body = "Here is the body of my email \n Regardings, Matheus Hoske"
//Setting up the static parameters of the sender info and the custom SMTP Address and port
Email.EmailFrom = "youremail@gmail.com";
Email.EmailPassword = "MyPassword";
Email.EmailPassword = "MyPassword";
Email.CustomSmtp = true;
Email.CustomSmtpAddress = "stmtp.example.com";
Email.CustomSmtpPort = 587;

//Creating a new instance for the Email Object adding the receiver email
Email email = new Email("richard@anydomain.com");
//Sending the Email
email.Send(subject,body);
```

It's easy, no? Yes, I know, but you can add a new [Issue](https://github.com/matheushoske/Emailer/issues) for us, asking for the addition of a new configured SMTP.


### Example application

If you have any doubts about how Emailer works, check our project that consumes Emailer.dll:

[Emailer Example](https://github.com/matheushoske/EmailerExample)

Hope you like it :)