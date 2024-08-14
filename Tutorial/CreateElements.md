## Create an element
Elements are "a line of text" that appears on player's screen. You can create a element by create new .yml file in UI Templates\Elements folder. UI Templates folder can be find in your server's plugin config folder.
Here's the example for yml file:
```yml
text: "Hello! [PNickname]"
name: Your element name
xCoordinate: 0
yCoordinate: 700
alignment: Center
size: 20
updateRate: Normal
```
This will show "HI!" followed by player's nickname on player's screen. 
Here's a explanation for several properties
| Property | Usage |
| - | - |
| xCoordiante | The X coordinate represent the horizontal offset of the element on player's screen. THe high X coordinate will make the element shows on the right side of the screen.|
| yCoordinate | The y coordinate represent the vertical position of the element. Higher the y coordinate, lower the position of the element|
| updateRate | Available: Fastest, Fast, Normal, Slow, UnSync. Faster the update rate, the lower the delay on element's update |
| alignment | Available: Left, Right, Center |

## Tags
In element's text, you can include tags that will be replaced by contents. Here's are all the supported tags:
[Simple Tag](./Resources/SimpleTags.md)
[Count Tag](./Resources/CountTag.md)
[Helper Tag](./Resources/HelperTag.md)
[Custom Tag](.CreateCustomTags.md)
To add parameter to a tag, you can do it in the following way:
[TagName|parameter1|parameter2......]
