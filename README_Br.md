- [English](README.md)
- [中文(施工中...)](README_Zh.md)
# CustomizableUIMeow
 A SCP: SL UI system that allows you to design a customized UI for your players
#  Configuration
Before installing this plugin, you must first install [HintServiceMeow](https://github.com/MeowServer/HintServiceMeow)
    
After installing the plugins mentioned above, follow the following steps to install the plugin.
1.	Go to release on the right of this page, and download the newest dll file provided.
2.	Paste this file into the Exiled/Plugins folder.
3.	Restart your server

# Customization
CustomizableUIMeow allows you to design UI for your players without any programming efforts.
Here's a tutorial for you to design your UI
1. Install the plugin
2. [Create elements](./Tutorial/CreateElements.md)
3. [Create templates](./Tutorial/CreateTemplates.md)
4. Restart your server

# For Developers
You can register your tag and condition using CustomizableUIMeow.API.Features. However, if you do not want your plugin to depend on CustomizableUIMeow, you can use reflection rather than calling the API directly.
Here's a simple example of how to register your tag without a reference issue
```Csharp
//Try find type
string typeName = "CustomizableUIMeow.API.Features.TagParser, CustomizableUIMeow";
Type tagParserType = Type.GetType(typeName, throwOnError: false);
if (tagParserType == null)
{
    return;
}

// Try find method
Type[] paramTypes = { typeof(string), typeof(Func<Dictionary<string, object>, object>) };
MethodInfo methodInfo = tagParserType.GetMethod("RegisterTagParser", BindingFlags.Public | BindingFlags.Static, null, paramTypes, null);
if (methodInfo == null)
{
    return;
}

//Create parser delegate
Func<Dictionary<string, object>, object> parser = parameter =>
{
    return "Hello World " + ((Player)parameter["Player"]).Nickname; //Use parameter to get player
};

//Register tag
methodInfo.Invoke(null, new object[] { "YourTagName", parser });
```
### Parameters
You can use Dictionary<string, object> or dynamic as your parser's parameter. Here's the structure of the parameters:

The structure of the tag parser parameter dictionary:
```Csharp
{
    { "Player", Player },//Player
    { "TagName", TagName },//string
    { "Arguments", Arguments }//Queue<string>
}
```
Here's the structure of the tag parser parameter:
```Csharp
public readonly string TagName;
public readonly Player Player;
public readonly Queue<string> Arguments;
```

For conditions:
```Csharp
{
    {"Player", Player }//Player
}
```
```Csharp
public Player Player { get; }
```
