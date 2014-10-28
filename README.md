![Battlelogium](http://battlelogium.github.io/Battlelogium/images/Battlelogium.Logo.Full.png "Battlelogium")
=========================

Battlelogium is a [Battlelog](http://battlelog.battlefield.com/) client that wraps Battlelog, Origin, and Battlelog-powered games into one neat package. It enables Steam features such as the overlay and In-Home Streaming for all Battlelog-powered games.

Features
--------
 
* Supports Battlefield 3, Medal of Honor: Warfighter, **Battlefield 4 and Battlefield Hardline**
* Powered by [CEFSharp](http://github.com/cefsharp/CEFSharp/) 
* Built with aesthetics in mind
* Wraps Battlefield and Battlelog in one neat package
* **Steam Overlay support*** for all supported games
* Steam **In-Home Streaming** for all supported games
* Start campaign with Steam support if Battlelog is not available
* Does not modify or affect any Battlefield or Origin files  
* Open source and licensed under [GNU GPL v3](http://www.gnu.org/licenses/gpl.html)
 
_*_Due to error logging changes in recent Origin updates, you must disable Origin In-Game while using Battlelogium through Steam or Battlefield will not be playable.
Development Builds
------------------
[![Build status](https://ci.appveyor.com/api/projects/status/ebr664a5y6bhvrfl?svg=true)](https://ci.appveyor.com/project/RonnChyran/battlelogium)

 
Development builds are made every time a commit is made to the repository. They may contain unfinished or broken features.

If you choose to use these builds, download from the Release branch [here](https://ci.appveyor.com/project/ron975/battlelogium)
Configuration Options
---------------------
 
Most configuration options are accessible through the settings editor where the Battlelog profile settings are. Settings are saved and read from `%APPDATA%\Battlelogium\config.ini`.

### General Options
* `manageOrigin` toggles whether Battlelogium will create a new, managed instance of Origin so that Steam is aware of any child processes that Origin starts and therefore will attempt to hook the Steam overlay. Unless you are using a [.par file patch](http://par.nofate.me/) or [Outcome](http://outcome.nofate.me/), this should be set to true. **Battlelogium does not come with included installs for either Outcome or .par file patches since version 2.0**

* `waitTimeToKillOrigin` specifies in seconds how long to wait before a managed instance of Origin is closed, for the purposes of allowing cloud sync. By default this value is 10 seconds to allow Origin to sync to the cloud before closing. **This setting is not available from the settings editor and must be changed manually in the configuration file**

* `checkUpdates` toggles whether to check for updates to Battlelogium. Updates are retrieved from this GitHub repository and can be downloaded and installed. It is recommended that you check for any updates in case of bugfixes.

### Window Settings
* `fullscreenMode` toggles whether Battlelogium will start in a borderless fullscreen window, covering the whole screen, including the taskbar. Window modes are toggle-able with **Alt-Enter**.

* `disableHardwareAccel` disables hardware acceleration on the main Battlelogium window, forcing the window to render in software (CPU) mode. While this disables the Steam overlay being able to render on the Battlelogium window (**Steam overlay will still work in-game**) and thus fixing issues that pop up relating to the Steam overlay's incompatibility with WPF, rendering with the CPU causes a significant drop in smoothness and performance and may effect in-game performance, it is recommended that hardware accelerate be kept on.

* `windowHeight` and `windowWidth` specify the forced height and width of the window respectively. If either is set to 0, Battlelogium will resume your previous window size and position, else, if both a width and height are set, it will always start the window with those dimensions.

* `rightClickDrag` enables the legacy behavior of dragging around the borderless window* by holding down the right mouse button. This is no longer needed, simply drag the top of the window as you would normally using the left mouse button to move the window. However, if some users have gotten used to that behavior they may wish to enable it again.

_*Since Battlelogium 2.0, the option to have a window with a border chrome on it has been removed, therefore, the `noBorder` setting is no longer available. A borderless window is the default, and only windowed mode behavior_

Bug reports
-----------
 
You may submit a bug report through this GitHub repo, or through our [Steam Group](http://steamcommunity.com/groups/Battlelogium)
 
Building
--------
Build using Visual Studio 2013 or [Visual Studio Express 2013](http://www.visualstudio.com/downloads/download-visual-studio-vs#d-express-windows-desktop). Dependencies are handled by NuGet and do not have to manually installed.

Building `Battlelogium.ThirdParty.SteamShortcutManager` (forked from [scottrice/SteamShortcutManager](https://github.com/scottrice/SteamShortcutManager) required Python 2.7 and PyInstaller to be installed. Run `build.py` to build a windows executable. Visual Studio will not build SteamShortcutManager as part of the solution build process, it must be built manually.

 
Changelog
----------
###Release 2.1.0.0
>* User Experience
>  - **Added Battlefield Hardline Beta support**
>  - **Added Medal of Honor: Warfighter support**
>  - Battlelog Web Plugins are now updatable in-interface
>  - Improved installer to be more flexible 
>  - Added an uninstaller*
>  - Added entries for Battlelogium in Control Panel program list*
>  - Added Start Menu icons*
>  - Added a way to force update
>  - Added a maximize/restore window button
>
>*_If updating from 2.0.1.0 you will need to force update after 2.1.0.0 has been installed to gain these features_
>* Code
>  - Updated to CEFSHarp 1.25.7
>  - Presence of installer executable now no longer crucial for update. The updater/installer will be redownloaded every time. 

###Release 2.0.1.0
>* User Experience
>  - Fixed crashes due to insufficient permissions when writing to config
>  - Fixed cache not saving due to insufficient permissions

###Release 2.0.0.0
>* User Experience 
>  - **Reduced CPU usage compared to version 1.4.0.4**
>  - **Added Battlefield 4 support** 
>  - Added a redesigned settings editor to make it easier to understand.
>  - Added settings options links in the Battlelog profile settings page.
>  - Added scroll bars styled to fit with the website.
>  - Added proper loading sprite to each respective Battlelog, rather than mimicking effect.
>  - Added the ability to restore window size and location from last start.
>  - Added the ability to force window size in config.
>  - Added extended player statistics from BF3Stats and BF4Stats ported from BetterBattlelog.
>  - Added a drop shadow and a window drag area on Borderless window mode.
>  - Added the option to restore right click window drag behaviour in configuration.
>  - Added an installer to easily install the latest version of Battlelogium.
>  - Added a redesigned updater to provide an easy way of updating Battlelogium.
>  - Added a window to indicate running in Offline campaign only mode
>  - Removed campaign auto-starting, except if Battlelog is unavailable or offline.
>  - Removed custom Javascript and CSS support.
>  - Removed bordered-window mode (only borderless window and fullscreen mode available).
>  - Removed support for installing .par files due to updates to Origin that render the fix useless without [Outcome](http://outcome.nofate.me/).
>  - Removed hotkeys for starting campaign, quick match, etc.
>  - Removed background fade effects when loading Battlelog.
>  - Removed tooltips on playbar buttons in the Battlefield 3 Battlelog.
>  - Removed old settings dialog for settings access,
>  - Removed right click window drag by default.
>
>* Code
>  - Completely rewritten using .NET 4.5.
>  - Replaced Awesomium with CefSharp
>  - Removed costly logging functions. Logging turned out to be rarely useful 
>  - Removed buggy dialog API, notifications are handled by Battlelog showReceipt() method
>  - External dependencies are all managed by NuGet.
>  - Shared UI code is located in the Battlelogium.Core namespace.
>  - Individual Battlelogium UIs are located in the Battlelogium.UI namespace.
>  - Third party code is located in the Battlelogium.ThirdParty namespace.
>  - JavaScript is now hosted on GitHub Pages rather than locally, and is not included with the installation. 
>  - Javascript is minimized before being served.
>  - Javascript is separated into different files instead of serving one huge file.

###Release 1.4.0.4
>* Code
>  - Update to Awesomium 1.7.3

###Release 1.4.0.3
>* User Experience
>  - Disable settings dialog on Battlefield 4 and MOHW
>  - Fix Quick Match tooltips not showing in some cases
>  - Suppress flashes of the Quick Match tooltips when setting them
 
###Release 1.4.0.1
>* User Experience
>	- Added an option in the settings menu in which the requirement for Origin to be running while playing Battlefield 3 can be removed
>	- If `handleOrigin` is false and the Origin requirement was removed, going directly to campaign will not require logging into Origin
>	- Removed the "Quit" button on the play bar in favour of the faux window chrome buttons on the top menubar of Battlelog
>	- Moved the "Settings" button on to the secondary Battlelog nav bar
>	- Settings can also be accessed through the "Settings" link under the profile dropdown menu on the top menubar.
>	- Added an option to access Battlelog profile settings in the Battlelogium settings dialog
>	- Added an Alt+Enter functionality to toggle between fullscreen and windowed mode
>	- Added F5 to reload the page
>	- Battlelog dialogs created by Battlelogium now use the new overlay and fade in and out over 400 ms.
>	- New loading background 
>	- Added a version indicator on the bottom left of the loading screen
>	- Removed the flashing "LOADING" text when loading
>	- Added a Battlelog style flashing blue blink to replace "LOADING" text
>	- Removed BF4 Pre-Order and purchase ads
>	- There is no longer a need to mark output. Simply submit battlelogium.log
>	- Added hotkeys to start game modes quickly 
>		- Alt+C to start Campaign Mode
>		- Alt+P to start Co-Op Mode
>		- Alt+Q to start Quick Match
>		- Alt+S to go to the Server Browser
>		- Alt+H to go back to Battlelog Home
>
>* Code
>	- Upgraded to Awesomium 1.7.2
> 	- The Battlelog dialog API now has a C# wrapper for easy manipulation in C# code.
>	- Ported the dialog API to jQuery for shorter and more readable code
>	- Added "ParManager" to handle `bf3.par` file
>	- Refactored Origin handling to `ManagedOrigin.cs`
>	- Added `SetWindowed()` and `SetFullScreen()` to set between fullscreen and windowed mode
>	- Added css and icons for faux window chrome buttons
>	- Utilities.Log() now writes to a file for logging.
>	- Reverted all event handlers to standard conventions 
>	- Various bug fixes
 
###Release 1.3
>* User Experience
>	- Now supports going directly to campaign with Steam Overlay support. 
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
>	- Refactored much of the original code
>	- Delegates are used more frequently, replacing one or 2 lined event handlers.
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

###Release 1.21
>* User Experience
>	- Steam Overlay now works again in Battlefield 3
>	- Changed waitTimeToCloseOrigin config name to waitTimeToHideOrigin
>	- Added config waitTimeToKillOrigin
>	- Now waits a configurable amount of time before killing Origin and ESNSonar, to allow Origin to sync saves with cloud
>
>* Code
>	- All timers now use delegates for cleaner code.
>	- Changed some comments to be more descriptive
>	- Changed AssemblyFileVersion to 1.2.1
> 	- Updated README.md to reflect config changes
>	- Removed SendKeys() method, is no longer needed.
>	- Wrapper will sleep for 5 seconds more than waitTimeToKillOrigin on closing to allow origin kill thread to, well, kill Origin

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

### Valve
> © 2013 Valve Corporation. Valve, the Valve logo, Half-Life, the Half-Life logo, the Lambda logo, Steam, the Steam logo, Team Fortress, the Team Fortress logo, Opposing Force, Day of Defeat, the Day of Defeat logo, Counter-Strike, the Counter-Strike logo, Source, the Source logo, Counter-Strike: Condition Zero, Portal, the Portal logo, Dota, the Dota 2 logo, and Defense of the Ancients are trademarks and/or registered trademarks of Valve Corporation. 
 
### Awesomium
> © 2013 Awesomium Technologies LLC. Awesomium, the Awesomium logo, the Awesomium libraries, the Awesomium.NET libraries, the Awesomium runtime are trademarks and/or registered trademarks of Awesomium Technologies LLC
 
### Chromium 
> © 2012 Google Inc. All rights reserved. Chromium™ open source project is a trademark of Google Inc.
 
_All other trademarks are property of their respective owners._
 
 
 
 
