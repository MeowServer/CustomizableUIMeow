# Create Custom Tag
The only custom tag supported now is custom hint tag. You can create a custom hint tag by add a .yml file in UI Templates\CustomTags folder
Here's a example for custom hint file
```yml
tagName: RespawnHints
switchInterval: 10
tagContent:
- Some hint
- Some other hint
```
After adding the file, you can use it in element by using the "[CustomHint|YourTagName]" Tag. Here's a example of custom tag:
[CustomHint|RespawnHints]