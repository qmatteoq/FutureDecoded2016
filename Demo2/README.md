# Integrating UWP APIs into a Win32 app

To open this solution you need:

- [Visual Studio 15 Preview](https://www.visualstudio.com/visual-studio-pre-release-downloads/)
- [Desktop to UWP Packaging Project extension](https://visualstudiogallery.msdn.microsoft.com/c71521f1-3c73-49e8-b1a4-70e958f179ba)

To test the Win32 version of the app:
1) Set <b>LiveTile.App</b> as start up project
2) Choose the Debug configuration mode
3) Press F5 in Visual Studio

To test the UWP version of the app:
1) Set <b>LiveTile.UwpDeploy</b> as startup project
2) Rebuild it, so that all the needed files from the desktop app are copied
3) Press F5 in Visual Studio
