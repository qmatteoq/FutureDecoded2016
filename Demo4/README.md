# Launching a Win32 process from a UWP app

To test the app:

1) Rebuild the <b>Migrate.WindowsForms</b> project. The project contains a set of post-build commands that will copy the Win32 executables in the proper folder.
2) Set <b>Migrate.UWP</b> project as startup project 
4) Press F5 in Visual Studio to launch the debug. Notice that the <b>Open form</b> button will be visible only if the app is launched on the desktop.
