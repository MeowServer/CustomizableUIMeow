## Create an element
Elements are "a line of text" that appears on the player's screen. You can create an element by creating a new .yml file in the UI Templates\Elements folder. UI Templates folder can be found in your server's plugin config folder.
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
This will show "HI!" followed by the player's nickname on the player's screen. 
Here's an explanation for several properties
| Property | Usage |
| - | - |
| xCoordiante | The X coordinate represents the horizontal offset of the element on the player's screen. The high X coordinate will show the element on the right side of the screen.|
| yCoordinate | The y coordinate represents the vertical position of the element. The higher the y coordinate, the lower the position of the element|
| updateRate | Available: Fastest, Fast, Normal, Slow, UnSync. The faster the update rate, the lower the delay on the element's update |
| alignment | Available: Left, Right, Center |

## Tags
In element's text, you can include tags that will be replaced by contents. Please check Customizable UI Tag List in release for supported tags

### Tag Parameters
To add a parameter to a tag, you can do it in the following way:

[TagName|parameter1|parameter2......]
