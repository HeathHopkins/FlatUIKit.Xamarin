FlatUIKit.Xamarin
=================

Partial C# port of [FlatUIKit](https://github.com/Grouper/FlatUIKit) for Xamarin.iOS

![Demo Screen](/Screenshots/demo-01.png "Demo Screen")

Currently has:
 - Flat UINavigationBar
 - Flat UIBarButtonItems including BackButtonItem
 - Flat UIButtons
 - FlatUI Colors from http://flatuicolors.com/

Instructions:

1. Set appearance changes in FlatUI.Apply() then call it in your AppDelegate.FinishedLaunching()
2. FlatUI Colors are in FlatUI.Color
3. Create Flat UIButtons with
```csharp
new FUIButton(yourRectangle, FlatUI.Color.PeterRiver, FlatUI.Color.BelizeHole);
```
