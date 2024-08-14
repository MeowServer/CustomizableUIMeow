## Create a template
Templates is a set of elements that will be display to a player.  You can create a template by create new .yml file in UI Templates\Templates folder.
Here's the example for yml file:
```yml
appliedRole:
- Scp173
- ClassD
elements:
- Your element name
- Another element name
```
This will apply the elements with name "Your element name" and "Another element name" to players with SCP-173 and Class D role.
Here's the Parameters you can use when creating a template
[Template Parameters](./Resources/TemplateParameters.md)

## Advanced
Template also provides ways to apply an element in certain condition.
Here's an example of how to create a template that change based on conditions
```yml
appliedRole:
- Spectator
elements:
- RespawnHint
- "REIsRespawning":
  - RespawningTimer
- "!REIsRespawning":
  - RespawnTimer
  ```
  In this example, "RespawningTimer" will apply only when the condition "REIsRespawning" is true. "RespawnTimer" will apply only when the condition "REIsRespawning" is false.
  You can find all the available conditions here:
  [Conditions](./Resources/Conditions.md)