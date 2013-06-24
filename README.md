![Battlelogium for Steam](https://raw.github.com/ron975/Battlelogium/master/BF3WrapperWPF/images/BattlelogiumLogoInline.png "Battlelogium for Steam")
=========================

Battlelogium is a [Battlefield 3 Battlelog](http://battlelog.battlefield.com/) wrapper to allow better integration with Steam, inspired by [Battlelog on Steam](http://forums.steampowered.com/forums/showthread.php?t=2289393)


Installation
------------

1. Battlelogium requires [.NET Framework 4](http://www.microsoft.com/en-ca/download/details.aspx?id=17851). This should have already been installed if you are on Windows Vista or later and have Windows Update enabled.
2. Install Origin. You can disable starting at launch, but this is not required, ans Battlelogium will close all Origin processes before starting Origin again.
3. Install the [latest Battlefield 3 Web Plugins](http://battlelog-cdn.battlefield.com/public/download/battlelog-web-plugins_2.1.7_115.exe)
4. If you have downloaded the package from [my website](http://punyman.com/projects/Battlelogium.zip), simply unzip to any folder along with the supplied Awesomium runtime libraries
5. Add Battlelogium.exe to Steam as a Non-Steam Game. You may change the configuration options listed below

Features
--------

* Powered by [Awesomium](http://awesomium.com/) and [Chromium](http://www.chromium.org/)
* Built with aesthetics in mind, many details have been fine-tuned to provide the best experience possible. Attention has been paid to the smallest details, such as removing the advertisements and integrating the quit button with the Battlelog webpage through Javascript.
* Written in C# with .NET 4 and WPF technologies
* Works seamlessly with Steam, closes Origin and Battlelog's ESNHost on quit so that one doesn't stay in-game even while Battlefield 3 is closed. The Steam Overlay also shows in-game in Battlefield 3.
* Easy installation, just unzip the contents to any directory and add to Steam.
* Page modifications such as removing advertisements can be changed or added through custom CSS styling of the Battlelog web page
* Open source and licensed under [GNU GPL v3](http://www.gnu.org/licenses/gpl.html)


Configuration Options
---------------------

* `style.css` is the CSS that is applied to the Battlelog web page when loaded. By default, it removes footers and advertisements as well as the scrollbar. Any modifications you make to this file will be applied to Battlelog's CSS.

* `config.properties` is a simple configuration file with a few configurable options
    - `waitTimeToCloseOrigin` is the amount of time in seconds to wait for Origin's start window to pop up and then close it. Adjust this if Origin pops up in front of the main Battlelog window and doesn't go bad automatically. Increasing it will make Battlelogium wait for a longer time before closing Origin's window, however, decreasing it by too much might attempt to close Origin's main window before it pops up if you do not have startTopmost set to true.If you have startTopmost set to true, increasing the delay will also make you unable to Alt-Tab out of Battlelogium for the duration of the delay. This is needed because Origin always stays on top of a window unless it is forced own and ignores messages telling it to start minimized. [Bug EA to include a silent launch mode](http://forum.ea.com/eaforum/posts/list/7393477.page).

    -  `startTopmost` is simply whether to start as the topmost window or not. If set to false, when Origin starts, it will most likely go on top of the wrapper for a bit, depending on what `waitTimeToCloseOrigin` has been set to.
    
The default configuration options should be fine for normal use

Bug reports
-----------

Bug reports and support will only given if 3 things are provided.
* A copy of your config.properties 
* A copy of your style.css  
* A copy of the debug output. To get debug output on Windows 7:
    1. Shift-Rightclick where Battlelogium.exe is located, and click on **_Open Command Window Here_**, or open a Command Prompt and `cd` into where Battlelogium.exe is located.
    2. Type `Battlelogium.exe`
    3. The Battlelogium will run, when it quits, the debug output will be shown on the command prompt window.
    4. Right-click and select **_Mark_**
    5. Drag all over the output, everythiing from `!---Begin Log---!` to `!---End Log---!`.
    6. Paste it somewhere. I recommend [Github Gists](gists.github.com) as you can paste multiple files in one gist. 
    7. Now that your config.properties, style.css and debug output is in a gist, send me the link.

Building
--------

1. Download the [Awesomium SDK](http://awesomium.com/download/). Be sure to install the .NET wrappers, alternatively, though not recommended, copy the files from the libs folder of the project directory from this repo to the bin/Debug and bin/Release folders. Be sure to reference Awesomium.Core and Awesomium.Windows.Controls.

2. Build using Visual Studio 2010 or [Visual C# Express](http://www.microsoft.com/visualstudio/eng/downloads#d-csharp-2010-express)

___

Licensing
---------

_Battlelogium is licensed under [GNU GPL v3](http://www.gnu.org/licenses/gpl.html), and the source code is available at [GitHub](https://github.com/ron975/Battlelogium-for-Steam)_

> This program is free software: you can redistribute it and/or modify
> it under the terms of the GNU General Public License as published by
> the Free Software Foundation, either version 3 of the License, or
> (at your option) any later version.
>  
> This program is distributed in the hope that it will be useful,
> but WITHOUT ANY WARRANTY; without even the implied warranty of
> MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
> GNU General Public License for more details.
> 
> You should have received a copy of the GNU General Public License
> along with this program.  If not, see <http://www.gnu.org/licenses/>.

Legal
-----

### EA

> ©2011 Electronic Arts Inc. Battlefield 3, Frostbite and the DICE logo are trademarks of EA Digital Illusions CE AB. 
> EA, the EA logo, EA SPORTS, the EA SPORTS logo, Pogo, Origin and the Origin logo are trademarks of Electronic Arts Inc.
> Battlelog (http://battlelog.battlefield.com) © 2013 EA DIGITAL ILLUSIONS CE AB

### Valve
> © 2013 Valve Corporation. Valve, the Valve logo, Half-Life, the Half-Life logo, the Lambda logo, Steam, the Steam logo, Team Fortress, the Team Fortress logo, Opposing Force, Day of Defeat, the Day of Defeat logo, Counter-Strike, the Counter-Strike logo, Source, the Source logo, Counter-Strike: Condition Zero, Portal, the Portal logo, Dota, the Dota 2 logo, and Defense of the Ancients are trademarks and/or registered trademarks of Valve Corporation. 

### Awesomium
> © 2013 Awesomium Technologies LLC. Awesomium, the Awesomium logo, the Awesomium libraries, the Awesomium.NET libraries, the Awesomium runtime are trademarks and/or registered trademarks of Awesomium Technologies LLC

### Chromium 
> © 2012 Google Inc. All rights reserved. Chromium™ open source project is a trademark of Google Inc.

_All other trademarks are property of their respective owners._




