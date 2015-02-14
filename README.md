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
 
### Description
This open source Xamarin app was written using Xamarin, which runs on OS X and Windows.  

[Xamarin(http://xamarin.com/download) is a a set of tools that allows developers to write mobile applications using C# and .NET.

With the [Intel XDK](http://xdk-software.intel.com/), you can write for, test, and deploy to many devices without having to ever install Visual Studio xCode, or Eclipse.

Use this as a template to get started with your own application. Remove some bits of code, and add your own. 


### Features
 - Runs on Win8, Win Phone 8, iOS, Android, & Browsers
 - [jQuery](http://jquerymobile.com/) mobile for speed and navigation between pages
 - [Bootstrap](http://getbootstrap.com) for responsive web design
 - [Single page application](http://en.wikipedia.org/wiki/Single-page_application)
 - No need for multiple IDEs 
 - Emulating and testing of dozens of deviecs from within the IDE
 - Deploy to your phone with one click

### Requirements
- You can use any Cordova tool for this, but I prefer the [Intel XDK](http://xdk-software.intel.com/), as it works on a Mac or Windows. 
- PC or Mac


### Setup

 1.  Download the source [from GitHub][3] ![1](http://phlcollective.azurewebsites.net/img/Intel%20XDK%20Instructions/1.png)
 2.  Unzip the folder, and put the *Ska-Studios* folder on your desktop.
 3.  Download & install the [Intel XDK](http://xdk-software.intel.com/) (this may take a while)
 3.  Launch Intel XDK and In the top-right corner, log-in or create a new Intel account.
 ![2](http://phlcollective.azurewebsites.net/img/Intel%20XDK%20Instructions/3.gif)
 4.  On your phone, download the **Intel App Preview** app from your device's marketplace *(Apple App Store, Google Play, Windows Store).*

### Opening the project
 3. Launch the XDK. In the top-left corner, look for *Projects -> New Project*
 ![4](http://phlcollective.azurewebsites.net/img/Intel%20XDK%20Instructions/4.gif)
 4. Click on *Import an Existing App*
 
 ![5](http://phlcollective.azurewebsites.net/img/Intel%20XDK%20Instructions/5.gif)
 5. Open the Ska-Studios folder on your desktop
 ![6](http://phlcollective.azurewebsites.net/img/Intel%20XDK%20Instructions/6.gif)
 6. Name the project
 7. You will now have a working project to build from. Start with Index.html
![7](http://phlcollective.azurewebsites.net/img/Intel%20XDK%20Instructions/7.gif)

### Emulating the app in other devices
1. With your code open, on the top of the screen look for the Emulate tab
![13](http://phlcollective.azurewebsites.net/img/Intel%20XDK%20Instructions/13.gif)
2. You can select the **device type** in the top-left corner to change for the device you want to test on

### Debugging the app on a physical device
1.  With the IDE open, click on the **TEST** Tab on the top of the screen
(add TEST screen shot here)
2.  You will be asked to sync with the server. Click *Sync.*
![14](http://phlcollective.azurewebsites.net/img/Intel%20XDK%20Instructions/14.gif)
3.  Scan the QR code on your computer, using your phone. This will automatically open the Intel App on your phone, and point it towards the URL that your app is hosted at.

![15](http://phlcollective.azurewebsites.net/img/Intel%20XDK%20Instructions/15.gif)
4. Give it a few moments to open the app, download your file, and open the file.

### Building for a device
1. With the IDE open, click on the **BUILD** tab
2. Select the device that you want to build for
![8](http://phlcollective.azurewebsites.net/img/Intel%20XDK%20Instructions/8.gif)
3. It will upload your project to the Intel servers
![9](http://phlcollective.azurewebsites.net/img/Intel%20XDK%20Instructions/9.gif)
4. Follow the instructions for each platform, and include the appropriate image sizes. ![10](http://phlcollective.azurewebsites.net/img/Intel%20XDK%20Instructions/10.gif)
![11](http://phlcollective.azurewebsites.net/img/Intel%20XDK%20Instructions/11.gif)



----------

## FAQ
**Why do I need to create an account?**

Your app is stored locally on your own machine, as well as Intel's servers. When you deploy your app to a physical device, it is connecting via a URL, which is a link to your app on Intel's servers.


**When I try to open an external web page (ie - one that I did not write), a new window pops up within emulator.**

This is a bug. On your physical device, it will load within your application. On the emulator though, it creates a new window.

**What is the purpose of the Intel App Preview app?**

This creates a debug container which points to your app stored on Intel's servers, and is used for testing. 

**There is so much JavaScript -- where do I start?**

The only .js file that I had to write for this project was *ska.js*. It's very well documented. Make any changes that you need in there. 


**Who is Ska Studios?**

Some friends in Seattle who make awesome video games. [Check out their titles](http://ska-studios.com/) on XBLA and XBLIG, as well as their upcoming game Salt and Sanctuary on PS4.

----------
## Resources

- [Power Point: How to build cross platform mobile apps](http://davevoyles.azurewebsites.net/speaking-engagements-power-points/)
- [BizSpark, for free MSFT dev licenses and web hosting](http://davevoyles.azurewebsites.net/bizspark-free-software-cloud-services-o/)
- [Windows store image generator](http://wat-docs.azurewebsites.net/Tools)
- [E-mail me with questions](mailto:Dvoyles@microsoft.com "Dvoyles@microsoft.com")
- [ jQuery mobile documentation](http://api.jquerymobile.com/)

----------

##Change Log
###v1.0.0
Initial build of the app


  [1]: http://www.davidvoyles.wordpress.com "My website "
  [2]: http://xdk-software.intel.com/
  [3]: https://github.com/DaveVoyles/Ska-Studios-Xplatform
