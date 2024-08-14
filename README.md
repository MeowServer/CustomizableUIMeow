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
CustomizableUIMeow provides a way to design UI for your players without any programming efforts.
Here's a tutorial for you to design your UI
1. Install the plugin
2. [Create elements](./Tutorial/CreateElements.md)
3. [Create templates](./Tutorial/CreateTemplates.md)
4. Restart your server

# For Developers
1. Extend Tags
You can extend tags easily by adding TagParser attribute onto your own method. Here's an example
```Csharp
[TagParser("PNickname")]
public string Nickname(TagParserParameter parameter) => PlayerGetter.GetPlayer(parameter).Nickname;
```
This method add a tag named "PNickname" which returns the nickname of the player. 
If you want to use TagParserParameter.Arguments. You must use Arguments.Dequeue method rather than get the argument directly.
2. Extend condition
Extend condition is similar to extending tags. Here's an example
```Csharp
[ConditionParser("RIsEnded")]
public bool IsEnded() => Exiled.API.Features.Round.IsEnded;
```
This method add a condition named "RIsEnded" which returns true when round is ended.