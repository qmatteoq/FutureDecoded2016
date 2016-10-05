# Launching a UWP component from a Win32 app

To open this solution you need:

- [Visual Studio 15 Preview](https://www.visualstudio.com/visual-studio-pre-release-downloads/)
- [Desktop to UWP Packaging Project extension](https://visualstudiogallery.msdn.microsoft.com/c71521f1-3c73-49e8-b1a4-70e958f179ba)

To test the app:

1) Deploy the <b>Component.UWP</b> project
2) Rebuild the <b>Component.WindowsForms</b> project. The project contains a set of post-build commands that will copy the Win32 executables in the proper folder
3) Uninstall the <b>Component.UWP</b> app you have previously deployed
4) Go to the folder <b>\Component\Component.UWP\bin\x86\Debug\AppX</b> and edit the file <b>AppxManifest.xml</b>
5) Uncomment the following piece of code:

```
<Application Id="Component.WindowsForms" Executable="Component.WindowsForms.exe" EntryPoint="Windows.FullTrustApplication">
      <uap:VisualElements DisplayName="Component.WindowsForms" Description="Component.WindowsForms" BackgroundColor="#777777"
                          Square150x150Logo="Assets\SampleAppx.150x150.png" Square44x44Logo="Assets\SampleAppx.44x44.png" >
        <uap:DefaultTile Wide310x150Logo="Assets\SampleAppx.150x150.png" />
      </uap:VisualElements>
</Application>
```

6) Install the application by opening a Powershell console on the folder <b>\Component\Component.UWP\bin\x86\Debug\AppX</b> and running the following command:

```
Add-AppxPackage -Register ".\AppxManifest.xml"
```

7) Launch from the Start menu the application called <b>Component.WindowsForms</b>
