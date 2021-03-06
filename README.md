# Gundam Led Web API Controller

A Web API created in ASP .NET Core with an Angular frontend designed to control RGB light values over the browser.

Featuring the ugliest interface in the world:

![interface](/images/interface.png)

Heres what the LED looks like in Gundam:

![white](/images/white.png)

![green](/images/green.png)

## Hardware
This project runs entirely on a [Raspberry Pi](https://www.raspberrypi.org/) in order to make use of its GPIO pins.

GPIO Wiring:

![fritzing](/images/fritzingsketch.png)

## Dependencies
This project made use of the Web API/Angular template on Visual Studio 2019.
To control the Pi's GPIO pins I used the Nuget package manager to install the System.Device.Gpio and Iot.Device.Bindings packages. I also include Swashbuckle.AspNetCore for Web Api debugging.

## Building
I developed the entirety of this application on my desktop so to run it on the Pi I had to do a couple extra steps:

command to publish:

 ```dotnet publish -r linux-arm ```

and then used scp to push the app onto the pi:

``` scp -r /publish-location/* pi@raspberrypi:/home/pi/deployment-location/```

These are steps outlined in [Microsofts official IOT documentation](https://docs.microsoft.com/en-us/dotnet/iot/deployment)
I then ssh into the pi and run ```chmod +x ./RGB``` within the deployment folder.

I also make sure to tell the program to run it on all url's so I can connect to the site on my desktop, far away from the pi.

```./RGB --urls https://*:<PORT> ```

## Future work
I think this program is pretty much finished for my personal Gundam build but I would like to add a Feature that allows me to modify the brightness of the led by pushing a string to the api. Something similar to [Quake's light animation](https://github.com/id-Software/Quake/blob/bf4ac424ce754894ac8f1dae6a3981954bc9852d/qw-qc/world.qc#L328-L372)

Another thing I need to do is to put some actual effort into the Angular side of things and make the interface look presentable.