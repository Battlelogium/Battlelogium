![Battlelogium for Steam](https://raw.github.com/ron975/Battlelogium/master/BF3WrapperWPF/images/BattlelogiumLogoInline.png "Battlelogium for Steam")
=========================

Battlelogium is a [Battlefield 3 Battlelog](http://battlelog.battlefield.com/) wrapper to allow better integration with Steam, inspired by [Battlelog on Steam](http://forums.steampowered.com/forums/showthread.php?t=2289393)


Installation
------------

1. Battlelogium requires [.NET Framework 4](http://www.microsoft.com/en-ca/download/details.aspx?id=17851). This should have already been installed if you are on Windows Vista or later and have Windows Update enabled.
2. Install Origin. You can disable starting at launch, but this is not required, as Battlelogium will close all Origin processes before starting Origin again.
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

* `config.ini` is a simple configuration file with a few configurable options
    
	-   General Options
	    -  `waitTimeToKillOrigin` is the amount of time in seconds to wait to kill Origin after the wrapper has closed. Increase if BF3 saves aren't syncing.
	
        -  `customJsEnabled` should be true if you wish to use custom Javascript in the customjs.js file. It will run at the `LoadingFrameComplete` event.

	    -  `directToCampaign` should be true if you want to skip Battlelog and go directly to campaign mode. If no internet connection is detected, this will also be the default behaviour
	 
	    -  `checkUpdates` should be true if you want Battlelogium to check for updates, and notify you of them.
		
		-  `useSoftwareRender` should be true if you want WPF to render without hardware acceleration. This is useful if the Steam Overlay is causing problems in Battlelogium, as it will disable it in. **The Steam Overlay in Battlefield 3 will still work with this on**
	
		-  `handleOrigin` should only be false if you have the "par fix" installed and so Origin does need to be running while playing Battlefield 3. See [BattlelogiumParManager](#BattlelogiumParManager)
	-   Window Options
	
	    -  `windowedMode` should be true if you want to run Battlelogium in a window instead of fullscreen.
	
	    -  `startMaximized` The window by maximized by default if this is true. This only applies when `windowedMode` is true
		
		-  `noBorder` There won't be a border or title bar on the window. This means you will not be able to resize the window. You can drag the window around with rightclick, however
		
		-  `windowHeight` is the height of the window in pixels at the start. 
		
		-  `windowWidth` is the width of the window in pixels at the start.

The default windowHeight and windowWidth are 720p (1280x720). You are able to drag and move the window with a rightclick anywhere on the window.

BattlelogiumParManager
----------------------
`BattlelogiumParManager.exe` is a helper application to modify the Origin Parameter file for Battlefield 3 (`bf3.par`). A file sourced from http://par.nofate.me has been hard-coded into the application. This file removes the requirement for Origin to be running while playing Battlefield 3. If installed, it is recommended that `handleOrigin` be set to false. 

To access this feature, there is an option in the Battlelogium settings menu that can be accessed by going to Settings -> Battlelogium Settings -> Remove Origin Requirement, or manually by starting `BattlelogiumParManager.exe remove` and then changing `handleOrigin` to false.
Bug reports
-----------

Bug reports and support will only given if 3 things are provided.
* A copy of your config.ini
* A copy of your style.css  
* A copy of a fresh battlelogium.log. **Delete any existing log file and run Battlelogium fresh to generate a new log file before submitting**

Building
--------

1. It is recommended that you download the [Awesomium SDK](http://awesomium.com/download/). Be sure to install the .NET wrappers, be sure to reference Awesomium.Core and Awesomium.Windows.Controls.

2. Build using Visual Studio 2010 or [Visual C# Express](http://www.microsoft.com/visualstudio/eng/downloads#d-csharp-2010-express)


Changelogs
----------

###Release 1.21
>* User Experience
>    - Steam Overlay now works again in Battlefield 3
>    - Changed waitTimeToCloseOrigin config name to waitTimeToHideOrigin
>    - Added config waitTimeToKillOrigin
>    - Now waits a configurable amount of time before killing Origin and ESNSonar, to allow Origin to sync saves with cloud
>
>* Code
>    - All timers now use delegates for cleaner code.
>    - Changed some comments to be more descriptive
>    - Changed AssemblyFileVersion to 1.2.1
>    - Updated README.md to reflect config changes
>    - Removed SendKeys() method, is no longer needed.
>    - Wrapper will sleep for 5 seconds more than waitTimeToKillOrigin on closing to allow origin kill thread to, well, kill Origin

###Release 1.3
>* User Experience
>   - Now supports going directly to campaign with Steam Overlay support. 
>	- Will ask if you want to go to campaign if a connection to Battlelog is unable to be estalblished.
>	- Uses Origin's `/StartClientMinimized` commandline parameter instead of timers to keep Origin in the background
>	- Added a windowed mode
>	- Added a borderless window mode
>	- Added the ability to force rendering using software (CPU) renderer to disable Steam Overlay in Battlelogium
>	- Added the ability to clear the cache
>	- Changed cache location to Battlelogium's start directory
>	- Added a user friendly settings editor 
>	- Changed configuration format to an easier to use INI-type format
>	- Added update notifications
>	- Shortened the default playbar buttons, i.e "Play Campaign" to simply "Campaign"
>	- Added minimize and close buttons to Battlelog
>	- Removed "for Steam" in the splash screen.
>	- Automatically restart Origin if it's already running before Battlelogium starts
>	- Remove quitting by escape key
>	- Will now prompt before quitting using the quit button.
>
>* Code
>   - Refactored much of the original code
>   - Delegates are used more frequently, replacing one or 2 lined event handlers.
>	- Utilities has been moved into their own classes
>	- Created a Configuration API to separate settings from UI code.
>	- Removed useless wrapper functions in BattlelogiumMain() constructor
>	- Removed most docstrings. They clutter the code that was pretty self-explanatory anyways.
>	- MessageBoxes use a custom class using WPF to enable verbs instead of "OK" and "Cancel"
>	- Logging reflects the method calls the code makes more accurately
>	- Refactored adding playbar buttons into a resuable method
>	- Created a rudimentary hacky API to create dialogs in Battlelog DOM. It's not the best code, but it's what I can make do with Battlelog's ugly mess of a web page.
>	- Changed some method names to be more clear.
>	- Sorted out code #regions

###Pre-Release 1.4
>* User Experience
>   - Added an option in the settings menu in which the requirement for Origin to be running while playing Battlefield 3 can be removed
>	- If `handleOrigin` is false and the Origin requirement was removed, going directly to campaign will not require logging into Origin
>	- Removed the "Quit" button on the play bar in favour of the faux window chrome buttons on the top menubar of Battlelog
>	- Moved the "Settings" button on to the secondary Battlelog nav bar
>	- Settings can also be accessed through the "Settings" link under the profile dropdown menu on the top menubar.
>   - Added an option to access Battlelog profile settings in the Battlelogium settings dialog
>	- Added an Alt+Enter functionality to toggle between fullscreen and windowed mode
>	- Battlelog dialogs created by Battlelogium now use the new overlay and fade in and out over 400 ms.
>	- New loading background 
>	- Added a version indicator on the bottom left of the loading screen
>	- Removed the flashing "LOADING" text when loading
>	- Added a Battlelog style flashing blue blink to replace "LOADING" text
>	- Removed BF4 Pre-Order ads
>   - There is no longer a need to mark output. Simply submit battlelogium.log
>   - Added hotkeys to start game modes quickly
>      - Alt+C to start Campaign Mode
>      - Alt+P to start Co-Op Mode
>      - Alt+Q to start Quick Match
>
>* Code
>   - Upgraded to Awesomium 1.7.2
>   - The Battlelog dialog API now has a C# wrapper for easy manipulation in C# code.
>	- Ported the dialog API to jQuery for shorter and more readable code
>	- Added "ParManager" to handle `bf3.par` file
>	- Refactored Origin handling to `ManagedOrigin.cs`
>	- Added `SetWindowed()` and `SetFullScreen()` to set between fullscreen and windowed mode
>	- Added css and icons for faux window chrome buttons
>   - Utilities.Log() now writes to a file for logging.
	
Special thanks
--------------

Thanks to..
* [JJBoonie](http://steamcommunity.com/id/JJBoonie/) for suggestions and testing
* [ProfDoctorMrSaibot](http://steamcommunity.com/id/ProfDoctorMrSaibot) for many sugguestions and testing
* [Frohman :D](http://forums.steampowered.com/forums/member.php?u=974602) for the original _Battlelog on STEAM_

_Find me on [Steam](http://steamcommunity.com/id/ron975/home/) or on GitHub and offer feature or bug requests!_
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




