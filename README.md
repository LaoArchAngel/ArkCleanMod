# ArkCleanMod
Application that ensures all mod updates for Ark are "clean" updates.
Eventually this application will turn into a fully-featured mod manager for Ark.

## Features

### Clean Mod Downloads
Currently, whenever a mod is downloaded, they are stored in two locations.  
One is where mods are downloaded, the other where they are installed.
These two locations are not completely isolated from each other, unfortunately.
Attempting to delete the "download" version of the mod will cause the mod to uninstall itself from the game, even though the game
doesn't actually use the download-version files during gameplay.  
When a user keeps a large number of mods on their drive (especially maps), the download folder can start eating up drive space.
This application deletes all of the unessential files and only keeps the mod identifying files.
This saves 99% of the space consumed by mods, while also ensuring that the space is clean and ready for the next update,
helping prevent any (unlikely) conflict.

Several mods recommend that you delete folders from this download section to avoid problems.
This application ensures you never have to do that manually again.
**Note:** This does not prevent download corruption.  In other words, it does not prevent corruption should a bit or bites to download
completely / accurately.

### Clean Mod Install
Rumor on the internet is that mod updates do not fully "clean" the install path of mods.
This can, theoretically, lead to conflicts and mod bugs.
It is commonly instructed in some mods to delete the mod install folder before updating,
as well as unsubscribing / subscribing in order to ensure an appropriate update.

This application will determine when an update has been downloaded and (when the game isn't running),
will delete the mod `.info` file and install folder.
This ensures that when Ark is run again and installs the new version of the mod,
the update is completely clean with no possibility of conflict.

## Planned Features

### Mod Re-install
Upon request, remove all traces of a mod and re-download it from the workshop into a clean folder in such a way that it installs property
the next time Ark is run.
Completely remove all need to ubsubscribe / subscribe from a mod to force a clean mod install,
even when due to download corruption.

### Activate / De-active mods
Filterable, sortable, cleaner.

### Active Mod Order manager
An easy way to change the install order of your mods.

## Possible Features *(much further down the line)*

### Full Config Manager
An easy place to make changes to any and all game settings.

### Full Self-Hosted Web Application
Manage your remote Ark server or local game using the same, simple application.  OS-agnostic.

### Save Backups / Restore
Provide access to save backups created by my [ArkBackup utility](https://github.com/LaoArchAngel/ArkBackup).
Easily download and restore saves.

### Server Management Utility
Provide easy, secure RCon access to a server, as well as shareable admin priviledges.
Allow your server moderators to restart / update the server without giving full access.

### Automatic Server Restarts / Updates
Detect mod updates and perform automatic delayed and warned restarts.
