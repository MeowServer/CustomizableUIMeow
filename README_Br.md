- [English](README.md)
- [中文(施工中...)](README_Zh.md)
- [Português](https://github.com/MeowServer/CustomizableUIMeow/blob/main/README_Br.md)
# CustomizableUIMeow
 Um sistema de interface do SCP: SL que permite que você desenvolva uma interface personalizada para seus jogadores
#  Configuração
Antes de instalar esse plug-in, você deve primeiro instalar [HintServiceMeow](https://github.com/MeowServer/HintServiceMeow)
    
Após instalar os plug-ins mencionados, siga os seguintes passos para instalar o plug-in.
1.	Vá até a página de lançamento na parte direita dessa página e baixe o arquivo .dll mais novo fornecido.
2.	Cole esse arquivo na pasta Exiled/Plugins.
3.	Reinicie seu servidor

# Customização
O CustomizableUIMeow permite que você desenvolva uma interface para seus jogadores sem ter que se esforçar com programação.
Aqui vai um tutorial para você de como desenvolver sua interface
1. Instale o plug-in
2. [Crie elementos](./Tutorial/CreateElements.md)
3. [Crie templates](./Tutorial/CreateTemplates.md)
4. Reinicie seu servidor

# Para Desenvolvedores
Você pode registrar sua tag e condição usando CustomizableUIMeow.API.Features. No entanto, se você não quiser que seu plug-in dependa do CustomizableUIMeow, você pode usar reflexão (reflection) ao invés de chamar a API diretamente.
Aqui vai um exemplo simples de como registrar sua tag sem um problema de referência.
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
### Parâmetros
Você pode usar Dictionary<string, object> ou dynamic como seu parâmetro de analisador (parser). Aqui está a estrutura dos parâmetros:

A estrutura do dicionário de parâmetros da tag de analisador (parser):
```Csharp
{
    { "Player", Player },//Player
    { "TagName", TagName },//string
    { "Arguments", Arguments }//Queue<string>
}
```
Aqui está a estrutura do parâmetro da tag de analisador (parser):
```Csharp
public readonly string TagName;
public readonly Player Player;
public readonly Queue<string> Arguments;
```

Para condições:
```Csharp
{
    {"Player", Player }//Player
}
```
```Csharp
public Player Player { get; }
```
