# XamarinWebAPI
### Author(s): Dave Voyles | [@DaveVoyles](http://www.twitter.com/DaveVoyles)
### URL: [www.DavidVoyles.wordpress.com][1]

Sample project for using ASP.NET Web API in Xamarin iOS apps
----------
### Objective

This lab goes through the process of creating an ASP.NET Web API project in Visual Studio,
and then writing an iOS app using Xamarin to consume the API. With these tools though, you can just as easily write an 
application that works for iOS, Andriod and Windows Phone.

By the end of this lab you will be able to:

- Create an ASP.NET MVC & Web API Project
- Create an iOS app using Xamarin

This application can also work for Windows Phone or Android by creating a different UI for those platforms. Xamarin has a number of tutorials on how to do this.

With this app, we'll be able to add "People" to our database hosted in Azure by using our the MVC part of our Web API project, and we'll be able to view the "People" from our Xamarin iOS app. 

We'll also be able to use the Star Wars API to return information from their database.
 
### Description
This open source Xamarin app was written using Xamarin, which runs on OS X and Windows.  

[Xamarin](http://xamarin.com/download) is a set of tools that allows developers to write mobile applications using C# and .NET.

With the [Visual Studio Community Edition](http://www.visualstudio.com/en-us/products/visual-studio-community-vs.aspx), you can write applications in a variety of languages for both devices and web sites. Any individual developer can use Visual Studio Community to create their own free or paid apps.

Use this as a template to get started with your own application. Remove some bits of code, and add your own. 


### Features
 - The mobile applications runs on iOS, while the ASP.NET project is a website
 - [Web API](http://www.asp.net/web-api) to perform CRUD operations on our iOS app from the cloud
 - [ASP.NET MVC](http://www.asp.net/mvc) to perform CRUD operations from the browser
 - Building, emulating and testing of dozens of deviecs from within Xamarin (iOS, Windows Phone, Android)
 - Deploy to your phone with one click
 - Use the [Star Wars API](http://swapi.co/) to access a database of information about that universe 
 - Utilizes [Restharp](http://restsharp.org/), which is a simple REST and HTTP API Client for .NET

### Requirements
- You can use Xamarin tools on either Windows or OS X
- PC for the Visual Studio (ASP.NET parts)
- Mac for the iOS parts


### Setup

 1.  Download the source [from GitHub](https://github.com/DaveVoyles/XamarinWebAPI/)
 2.  Download & install the [Visual Studio Community Edition](http://www.visualstudio.com/en-us/products/visual-studio-community-vs.aspx) (this may take a while)
 3.  Download & Install [Xamarin tools](http://xamarin.com/download). This will install a number of components for you, including: Xamarin.iOS, Xamarin.Android, Xamarin.Mac, & Xamarin Studio



### Opening the project
This project contains Two (2) solutions:

1. XamarinWebAPI
This is the Visual Studio Solution where we create our ASP.NET MVC and Web API content. Later, we push it to Azure so that we can access it from our device. We use MVC to create so that we can view and edit our database from the browser. 

2. Xamarin_Web_API_iOS
This is our mobile application which consumes the Web API project. 

## Starting the Web API project
1. Step-by-step instructions are included in this web camp lab I taught across the US in the spring of 2015. 
2. Cick on te DEMO.html file, which opens the tutorial. It will have you creating an MVC and Web API project.

You'll need an Azure account to host your project in the cloud and have your application access it. You can sign up for BizSpark by [sending me an e-mail](mailto:Dvoyles@microsoft.com), or grabbing a [one month day trial from here.](http://azure.microsoft.com/en-us/pricing/free-trial/)

3. Once completed, [push your Web API project to Azure](http://www.asp.net/web-api/overview/data/using-web-api-with-entity-framework/part-10).


## Using the Web API project 
At any point, you can open the solution I've created view the source so that you can step through that and have a better understanding of how the project works.

We now have an API that we can hit from any app or website, by navigating to [xamarinwebapi.azurewebsites.net](xamarinwebapi.azurewebsites.net).

If you want to make changes to the database, you can navigate to the MVC controller for People by going here: [xamarinwebapi.azurewebsites.net/person](xamarinwebapi.azurewebsites.net/api/apiperson)

If you want to view the people in our database, you can navigate to the Web API by poiting your browser or app towards [xamarinwebapi.azurewebsites.net/api/apiperson](xamarinwebapi.azurewebsites.net/api/apiperson)


### Starting the iOS project 
We can access our people database from the cloud, but now we need to create an application to consume this API.

Using the Xamarin IDE, open the **XamarinWebAPI_iOS.sln** file, which utilizes everything within the Xamarin_Web_API_iOS folder.

 ![4](https://onedrive.live.com/redir?resid=51CCFDB424CB429E!300009&authkey=!AHTQ-p99tnhk7ao&v=3&ithint=photo%2cpng)

#### iOS Project Overview 
You'll see that this is comprised of several parts:
-**References folder:** This is where files for the source code, resources, user interface, and assembly references are managed. 
-**Components folder:**  Components are a powerful feature that allows user interface components as well as libraries and themes to easily be added to a project. This is where we'll add [RestSharp](https://github.com/restsharp/RestSharp/wiki) to our project.

Take a look at **TableSource.cs**. This can use any data structure, from a simple string array, to a List <> or other collection. The implementation of UITableViewSource methods isolates the table from the underlying data structure. [Find more info on it here.](http://developer.xamarin.com/guides/ios/user_interface/tables/part_2_-_populating_a_table_with_data/)

We also have **Main.cs**, which is the entry point for our application. We won't be making any changes here. 

The **Person.cs** class is where we create a model to map the information from our Web API. If you look at the Web API project, you'll see that we also have a Person.cs model there too. 

Inside that class, we are utilzing a feature of RestSharp, to normalize the JSON that we're returning from the API. **	[RestSharp.Serializers.SerializeAs(Name = "name")]** Depending on the API we are getting our information from, we may be returning a on object with a property of "Name" or "name". Because JSON is case sensative, we need to make sure that we can accept either spelling. 

![Star Wars API][2]
The Star Wars API uses "name" in its API, while we use "Name" in our API. 

**HomeScreen.cs** is where all of our magic is happening. We'll be drawing text to the screen and parsing the APIs from here.

#### Open the **HomeScreen.cs** file and explore that. 

The first thing we do here is load our page in the **ViewDidLoad()** function. This calls our other funcitons, and the apporipriate API. 

The **BuildTable()** function is called first, which creates a table on the home screen. We are also creating an event handler, called **tableSource.OnRowSelected**. When a user touches a row, we have an alert window pop-up, with the information from the home screen.

#### Looking at the LoadFromStarWarsAPI() function

This is what actually calls the Star Wars API. We're creating a request object, which states that we want to access the database, and start within the "Results" path of the JSON object that is returned.  The **resource** property appends **/people/** onto our call, which we'll go over in a minute. 

Next up, we create a client object, which contains the web address for the HTTP request. The address we are trying to hit is **http://swapi.co/api**. When we make our call, we now append the resource property to it, so our actual request is to **http://swapi.co/api/people/**.

The lambda expression which follows, populates a table with the information from our database, then reloads the table with the new information we just received from the API. 

#### Looking at the LoadFromWebAPI() function

This is nearly identical to the LoadFromStarWarsAPI function. All that we're changing here is the address we are making a request to.

#### Deploying to the iOS simulator

We can only have one of these Load functions active at each time. Comment out one of them in your **BuildTable()** function.

In the top-left corner of the Xamarin IDE, press the Debug button (triangle), and your iOS simulator should appear shortly. 

**NOTE:** If you haven't used your Web API in a while, it may take a few seconds for that virtual machine to spin up, so the time it takes to return your Person results may be a few moments.



----------
## Resources

- [Video: Creating your first iOS app using Xamarin](https://www.youtube.com/watch?v=RnW7m0acxg0)
- [BizSpark, for free MSFT dev licenses and web hosting](http://davevoyles.azurewebsites.net/bizspark-free-software-cloud-services-o/)
- [E-mail me with questions](mailto:Dvoyles@microsoft.com "Dvoyles@microsoft.com")

----------

##Change Log
###v1.0.0
Initial build of the app


  [1]: http://www.davidvoyles.wordpress.com "My website"
  [Xamarin]: https://onedrive.live.com/redir?resid=51CCFDB424CB429E!300009&authkey=!AHTQ-p99tnhk7ao&v=3&ithint=photo%2cpng "Xamarin"
  [Star Wars]: https://onedrive.live.com/redir?resid=51CCFDB424CB429E!300010&authkey=!AMuP4Dt0oJuqdrA&v=3&ithint=photo%2cpng "Star Wars API"

