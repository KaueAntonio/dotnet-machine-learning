
# Dotnet Machine Learning

Este repositório contém um projeto que combina técnicas de identificação de documentos e reconhecimento facial.

![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
![TypeScript](https://img.shields.io/badge/typescript-%23007ACC.svg?style=for-the-badge&logo=typescript&logoColor=white)
![Aspire](https://img.shields.io/badge/Aspire-9933CC?style=for-the-badge&logo=.net&logoColor=white)
![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![ML.Net](https://img.shields.io/badge/ML.NET-5C2D45?style=for-the-badge&logo=.net&logoColor=white)

| Feature           | Status         |
| ----------------- | -------------- |
| API               | Completed ✔️   |
| Aspire Service    | Completed ✔️   |
| Image Classification Service    | Completed ✔️   |
| Facial Recognition Service | Pending ⏳   |

## Documentação da API

#### Retorna o objeto identificado na imagem

```http
  POST /predict
  BODY: ImageTraningModel
```
#### ImageTraningModel

| Nome   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `Label`      | `string` | **Obrigatório**. Nome da imagem.|
| `ImageSource`      | `byte[]` | **Obrigatório**. Base64 da imagem. |


## Como rodar o projeto?

Vá para a pasta DotnetLearning.AppHost dentro de src

```bash
  cd src/DotnetLearning.AppHost
```
Inicie o App
```bash
  dotnet run
```
## Referência

 - [.NET Aspire](https://learn.microsoft.com/en-us/dotnet/aspire/get-started/aspire-overview)
 - [ML.NET](https://learn.microsoft.com/en-us/dotnet/machine-learning/how-does-mldotnet-work)
