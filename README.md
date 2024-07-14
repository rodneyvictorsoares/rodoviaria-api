# Rodoviaria.API

## Descrição

Rodoviaria.API é uma API desenvolvida em ASP.NET Core para gerenciar passagens e viagens de rodoviária , criada para ilustar e exemplificar os tópicos das aulas ministradas para o curso de Análise e Desenvolvimento de Sistemas na Disciplina Programação Orientada a Objetos I. Esta API fornece endpoints para operações CRUD em passagens, viagens e outras entidades relacionadas, facilitando a integração com sistemas front-end como o Rodoviaria.WEB.

## Índice

- [Descrição](#descrição)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Funcionalidades](#funcionalidades)
- [Instalação](#instalação)
- [Uso](#uso)
- [Contribuição](#contribuição)
- [Licença](#licença)
- [Contato](#contato)

## Tecnologias Utilizadas

- ASP.NET Core 6
- Entity Framework Core
- Swagger
- SQL Server
- Git

## Funcionalidades

- **CRUD de Passagens**: Criação, leitura, atualização e exclusão de passagens.
- **CRUD de Viagens**: Criação, leitura, atualização e exclusão de viagens.
- **Documentação com Swagger**: Documentação automática e interativa da API.
- **Injeção de Dependência**: Facilita a manutenção e testabilidade do código.
- **Redirecionamento HTTPS**: Garante que todas as requisições sejam seguras.
- **Tratamento de Exceções**: Feedback detalhado em ambiente de desenvolvimento.

## Instalação

### Pré-requisitos

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) ou [Visual Studio Code](https://code.visualstudio.com/)
- [SQL Server](https://www.microsoft.com/sql-server)

### Passos

1. Clone o repositório:
    ```bash
    git clone https://github.com/seu-usuario/Rodoviaria.API.git
    cd Rodoviaria.API
    ```

2. Restaure as dependências do projeto:
    ```bash
    dotnet restore
    ```

3. Configure a string de conexão com o SQL Server no arquivo `appsettings.json`:
    ```json
    "ConnectionStrings": {
        "DefaultConnection": "Server=SEU_SERVIDOR;Database=RodoviariaDB;User Id=SEU_USUARIO;Password=SUA_SENHA;"
    }
    ```

4. Atualize o banco de dados:
    ```bash
    dotnet ef database update
    ```

5. Execute a aplicação:
    ```bash
    dotnet run
    ```

## Uso

Após seguir os passos de instalação, a API estará disponível em `https://localhost:5001/swagger`. Navegue até esta URL no seu navegador para acessar a documentação interativa da API.

### Endpoints Principais

- **Passagens**:
  - `GET /api/passagens`: Lista todas as passagens.
  - `POST /api/passagens`: Cria uma nova passagem.
  - `GET /api/passagens/{id}`: Obtém uma passagem por ID.
  - `PUT /api/passagens/{id}`: Atualiza uma passagem por ID.
  - `DELETE /api/passagens/{id}`: Exclui uma passagem por ID.

- **Viagens**:
  - `GET /api/viagens`: Lista todas as viagens.
  - `POST /api/viagens`: Cria uma nova viagem.
  - `GET /api/viagens/{id}`: Obtém uma viagem por ID.
  - `PUT /api/viagens/{id}`: Atualiza uma viagem por ID.
  - `DELETE /api/viagens/{id}`: Exclui uma viagem por ID.

## Contribuição

Contribuições são bem-vindas! Siga os passos abaixo para contribuir:

1. Fork o repositório
2. Crie um branch para sua feature (`git checkout -b feature/nova-feature`)
3. Commit suas mudanças (`git commit -m 'Adiciona nova feature'`)
4. Faça o push para o branch (`git push origin feature/nova-feature`)
5. Abra um Pull Request

## Licença

Este projeto está licenciado sob a Licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

## Contato

- **Seu Nome** - ordabelem@hotmail.com
- **GitHub** - rodneyvictorsoares

---

<p align="center">
  <img src="https://img.shields.io/badge/Made_with-ASP.NET_Core-1f425f.svg" alt="Feito com ASP.NET Core">
  <img src="https://img.shields.io/badge/Deployed_on-GitHub_Pages-1f425f.svg" alt="Deploy no GitHub Pages">
</p>
