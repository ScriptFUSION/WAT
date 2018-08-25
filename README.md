
Warframe Alert Tracker (WAT)
============================

WAT shows notifications when something interesting happens in the [Warframe][Warframe] world. You choose what defines *interesting* by creating alert rules to match your interests.

Contents
--------

  1. [Usage](#usage)
  2. [Download](#download)
  3. [Requirements](#requirements)
  4. [Contributing](#contributing)

Usage
-----

### Dashboard

When WAT is first run we see the world state dashboard. This is your window into the world of Warframe (although it currently only shows fissures!).

If any fissures match our rules (without being excluded by any exclusion rules), they will show up with a blue tint on our dashboard. We don't have any alert rules yet, so let's create some.

![][Dashboard]

### Alert rules

To create some alert rules, click the *alerts* menu option and the alerts setup dialogue appears. Any number of rules can be added to create complex rule sets.

Let's suppose we want to receive notifications about all excavation fissures and defense fissures, but no Lith or Meso tier fissures. First we select the *excavation* mission type and click *include* to create an inclusive rule. We do the same for the *defense* mission type. Then we create two more rules: one for *Lith* and one for the *Meso* tier and click *exclude* to create a two exclusion rules.

![][Alerts]

With this rule configuration we will always receive alerts for excavation and defense missions unless they're Lith or Meso tier. We could further restrict the exclusion rules to only apply to defense missions, so we still get alerts about Lith and Meso excavations. If any rules currently match, the match column will display *Yes*.

> Tip: To remove a rule, right click it. To temporarily disable a rule without removing it, uncheck it by clicking the tick mark.

### Notifications

![][Notification]

Any new fissures that match our rules will cause a popup notification to be displayed, like the one shown above. The notification appears at the centre of the right-hand edge of the monitor the app is running on. To test this functionality click the *options* menu option, then the *notifications* tab and finally the notification preview area. The notification display time can be adjusted using the up/down control.

> Please note the notification will not display over full screen programs. To see notification popups whilst playing Warframe, choose *windowed* or *borderless fullscreen* display modes in the game options.

### Options

WAT minimizes to the system tray because it is intended to keep out of the way and continue running in the background most of the time. To make this easier, it is recommended to enable the *load at system start-up* option to save having to remember to start it manually each time the computer reboots.

![][Options]

Download
--------

See the [latest release][Latest release] to download the Windows installer (`.exe`), compiled binaries (`.zip`) or source code. It is recommended to use the installer because it installing dependencies automatically and upgrades any previous installations in-place.

Requirements
------------

UpDown Meter requires [.NET Framework 4.5.1][.NET Framework], which ships with Windows 8.1 and later, but can be installed on earlier versions of Windows. The installer will automatically install .NET Framework if needed.

Contributing
------------

The best way to get your idea into the program is to code it! Everyone is welcome to contribute anything, from [ideas][Issues] and [issues][Issues] to graphics to documentation to [code][PRs]! C# is an easy language to learn: if you can concatenate *hello* to *world* you can probably figure out how to add the feature you want.

Compiling the code is as easy as cloning the source code and running it in [Visual Studio][Visual Studio] or [Visual Studio Code][VS Code] by clicking *start* or pressing *F5*. 

### Getting into the code

There are four main code areas to be familiar with.

  1. UI – Presentation classes are found in the `Forms`, `Controls` and `Drawing` namespaces.
  1. Alerts – Internally, *alerts* refers to the alert rules specified by the user that determine what they want to be notified about, located in the `Alerts` namespace.
  1. World state – Warframe world state downloading and parsing is located in the `Warframe` namespace.
  1. Settings – Setting persistence in text files is located in the `Properties` namespace whilst registry persistence is located in the `Registry` namespace. All settings are stored in plain text whenever possible.

Some miscellaneous and uncategorised classes are stored in the root project namespace.


  [Latest release]: https://github.com/ScriptFUSION/WAT/releases/latest
  [Issues]: https://github.com/ScriptFUSION/WAT/issues
  [PRs]: https://github.com/ScriptFUSION/WAT/pulls
  
  [Dashboard]: Screenshots/dashboard.png
  [Alerts]: Screenshots/alerts.png
  [Notification]: Screenshots/notification.png
  [Options]: Screenshots/options.png

  [.NET Framework]: http://go.microsoft.com/fwlink/p/?LinkId=310159
  [Visual Studio]: https://visualstudio.microsoft.com/
  [VS Code]: https://code.visualstudio.com/
  [Warframe]: https://www.warframe.com/
