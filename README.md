# DotNetAIVoiceTranscription API - Transcrição de Voz com OpenAI Whisper

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT) 
![.NET Core](https://img.shields.io/badge/.NET-512BD4?style=flat&logo=dotnet&logoColor=white)
![HTML5](https://img.shields.io/badge/HTML5-E34F26?style=flat&logo=html5&logoColor=white)
![CSS3](https://img.shields.io/badge/CSS3-1572B6?style=flat&logo=css3&logoColor=white)
![TypeScript](https://img.shields.io/badge/TypeScript-007ACC?style=flat&logo=typescript&logoColor=white)
![Visual Studio](https://img.shields.io/badge/Visual_Studio-5C2D91?style=flat&logo=visual-studio&logoColor=white)
![VS Code](https://img.shields.io/badge/VS_Code-007ACC?style=flat&logo=visual-studio-code&logoColor=white)
![Git](https://img.shields.io/badge/GIT-F05032?style=flat&logo=git&logoColor=white)
![GitHub](https://img.shields.io/badge/GitHub-181717?style=flat&logo=github&logoColor=white)
![Postman](https://img.shields.io/badge/Postman-FF6C37?style=flat&logo=postman&logoColor=white)

## ✨ O frontend (React) do projeto se encontra no link:

[https://github.com/marcelogmoura/DotNetAIVoiceTranscription.UI](https://github.com/marcelogmoura/DotNetAIVoiceTranscription.UI)

Uma API em ASP.NET Core desenvolvida para expor um serviço de Transcrição de Voz utilizando o modelo **Whisper** do SDK da OpenAI. A aplicação salva o arquivo de áudio temporariamente para o processamento da transcrição e garante sua exclusão posterior.

## 🚀 Recursos Principais

A API oferece o seguinte endpoint principal, centralizado no `TranscriptionController.cs`:

### 🎤 Serviço de Transcrição de Voz
* **Transcrição de Áudio:** Recebe um arquivo de áudio (ex: MP3, WAV, etc.) via *form-data* e retorna o texto transcrito.
* O serviço utiliza o modelo **`whisper-1`** por padrão e está configurado para solicitar a transcrição no idioma **Português (`pt`)**.

## 🛠️ Tecnologias

* **.NET 10.0**
* **ASP.NET Core Web API**
* **OpenAI SDK** (Versão `2.2.0-beta.4`)
* **OpenAI Whisper Model**
* **Swagger/OpenAPI** para documentação da API.

## ⚙️ Configuração do Projeto

### Pré-requisitos
* .NET SDK (versão 10.0 ou superior)
* Uma chave válida com créditos de API da OpenAI.

### Variáveis de Ambiente
É necessário configurar sua chave da OpenAI e o nome do modelo de áudio no seu arquivo `appsettings.json` ou variáveis de ambiente.

| Chave | Descrição | Valor Padrão (Fallback) |
| :--- | :--- | :--- |
| `OpenAi:Key` | Sua chave de API da OpenAI. | N/A |
| `OpenAi:AudioModel` | Modelo usado para transcrição de áudio. | `whisper-1` |

### Como Rodar Localmente

1.  Clone o repositório.
2.  Navegue até o diretório do projeto:
    ```bash
    cd DotNetAIVoiceTranscription.API
    ```
3.  Execute o projeto:
    ```bash
    dotnet run
    ```
4.  A API estará acessível em `http://localhost:5000` (ou porta configurada).
5.  A documentação interativa (Swagger UI) estará disponível em `/swagger`.

## 🌐 Endpoints da API

Todos os endpoints estão prefixados com `/ai`.

### 1. Transcrição de Áudio

`POST /ai/transcribe`

| Parâmetro | Tipo | Descrição | Obrigatório |
| :--- | :--- | :--- | :--- |
| `file` | `IFormFile` (form-data) | O arquivo de áudio a ser transcrito (máximo 25MB). | Sim |

**Exemplo (Via cURL):**

```bash
curl -X POST "http://localhost:5000/ai/transcribe" \
     -H "Content-Type: multipart/form-data" \
     -F "file=@/caminho/para/seu/arquivo.mp3"
```


## 📄 Licença

Este projeto está licenciado sob a Licença MIT - veja o arquivo `LICENSE` para detalhes.
* Termos de Serviço: [https://dotnetai.dev/terms](https://dotnetai.dev/terms).


👨‍💻 **Autor:** Marcelo Moura 

📧 **Email:** [mgmoura@gmail.com](mailto:mgmoura@gmail.com)   
📧 **Email:** [admin@allriders.com.br](mailto:admin@allriders.com.br)   
🐱 **GitHub:** [github.com/marcelogmoura](https://github.com/marcelogmoura)   
🔗 **LinkedIn:** [linkedin.com/in/marcelogmoura](https://www.linkedin.com/in/marcelogmoura/)   
