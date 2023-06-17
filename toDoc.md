## Para documentação


## Resumo sobre a API

```
API em C# que lida com operações CRUD (Create, Read, Update, Delete) em uma entidade "Pessoa" em um banco de dados MySQL.

A classe "PeopleController" é responsável por gerenciar as requisições HTTP relacionadas às pessoas. A rota principal da API é definida como "/person" usando o atributo [Route].

O método GET é responsável por retornar todas as pessoas cadastradas no banco de dados. Ele estabelece uma conexão com o banco de dados, executa uma consulta SQL para selecionar todas as linhas da tabela "Pessoa" e mapeia os resultados para objetos do tipo "Person". Em seguida, retorna uma resposta HTTP com os objetos "Person" em formato JSON.

O método POST é responsável por criar uma nova pessoa no banco de dados. Ele recebe um objeto "Person" como parâmetro e utiliza os dados desse objeto para executar uma instrução SQL de inserção no banco de dados.

O método PUT é responsável por atualizar os dados de uma pessoa existente no banco de dados. Ele recebe o ID da pessoa a ser atualizada e um objeto "Person" contendo os novos dados. O método verifica cada propriedade do objeto "Person" e, se for diferente de nulo ou vazio, adiciona a respectiva coluna na instrução SQL de atualização.

O método DELETE é responsável por excluir uma pessoa do banco de dados. Ele recebe o ID da pessoa a ser excluída e executa uma instrução SQL de exclusão com base nesse ID.

Os métodos fazem uso da biblioteca MySql.Data para estabelecer a conexão com o banco de dados e executar as consultas SQL.

Em caso de erros durante as operações, as exceções são capturadas e uma resposta HTTP com status apropriado e uma mensagem de erro é retornada.

A classe "Person" define a estrutura dos objetos que representam uma pessoa, com as propriedades "Id", "Name" e "Age".

Essa API permite criar, ler, atualizar e excluir pessoas no banco de dados MySQL de forma segura e eficiente.
```


## Metódo GET

```
método GET em uma API em C# que recupera informações de pessoas cadastradas em um banco de dados MySQL utilizando a biblioteca MySql.Data.

Primeiramente, é criada uma lista vazia chamada "people" para armazenar as informações das pessoas recuperadas do banco de dados.

Em seguida, é criada uma conexão com o banco de dados MySQL utilizando a string de conexão fornecida. Em seguida, é definida uma consulta SQL para selecionar todos os registros da tabela "Pessoa".

É criado um objeto MySqlCommand com a consulta SQL e a conexão, e em seguida é aberto um leitor de dados (MySqlDataReader) para executar a consulta e ler os resultados.

Dentro de um loop while, o leitor de dados lê cada linha retornada pela consulta e recupera os valores de cada coluna correspondente ao "Id", "Nome" e "CPF". Esses valores são convertidos para os tipos de dados adequados.

Uma instância de objeto Person é criada com os valores recuperados do banco de dados e adicionada à lista "people".

Após o término do loop, a conexão com o banco de dados é fechada e a lista "people" é retornada como resposta da requisição GET.

Se ocorrer algum erro durante o processo, é capturada uma exceção e uma resposta de erro com status 500 é retornada, exibindo a mensagem de erro correspondente.

O objetivo do código é recuperar as pessoas cadastradas no banco de dados e retorná-las como resposta da requisição GET na API.
```

## Metódo POST

```
No exemplo acima, o método CreatePerson é um rota POST que recebe um objeto da interface Person como parâmetro. Ele cria uma conexão com o banco de dados MySQL usando a string de conexão fornecida e executa um comando de inserção na tabela "Pessoa" com os valores do objeto Person. Se ocorrer algum erro durante o processo, ele retorna uma resposta de erro com a mensagem correspondente.


```

## Metódo PUT

```
No exemplo acima, o método UpdatePerson é uma rota PUT que recebe o ID da pessoa a ser atualizada e um objeto da interface Person com os campos a serem atualizados. Ele cria uma conexão com o banco de dados MySQL usando a string de conexão fornecida e constrói a consulta de atualização dinamicamente com base nos campos que foram enviados.

Ele verifica se cada campo não é nulo e, se não for, adiciona a coluna e o parâmetro correspondente à consulta. Se o campo for uma string vazia, ele atualiza o campo com uma string vazia no banco de dados.

Em seguida, ele executa o comando de atualização no banco de dados com os parâmetros fornecidos. Se ocorrer algum erro durante o processo, ele retorna uma resposta de erro com a mensagem correspondente.
```


## Metódo DELETE

```
No exemplo acima, o método DeletePerson é uma rota DELETE que recebe o ID da pessoa a ser removida. Ele verifica se o campo "id" é diferente de zero (ou nulo, caso o campo seja do tipo int?) antes de realizar a exclusão. Caso o ID seja inválido, ele retorna uma resposta de erro com a mensagem correspondente.

Em seguida, ele cria uma conexão com o banco de dados MySQL usando a string de conexão fornecida e executa um comando de exclusão na tabela "Pessoa" com o ID fornecido como parâmetro.

Se a exclusão for bem-sucedida, ele retorna uma resposta de sucesso. Caso ocorra algum erro durante o processo, ele retorna uma resposta de erro com a mensagem correspondente.
```




## Criação dos testes


<h5> Testes automatizados. </h5>

<p>

Peço desculpas novamente pelo equívoco. Parece que o pacote `Microsoft.VisualStudio.TestTools.UnitTesting` não está disponível para o .NET 6.0.

No .NET 6.0, o framework de teste recomendado é o xUnit. A seguir estão os passos para configurar e executar testes usando o xUnit:

1. Certifique-se de estar no diretório raiz do seu projeto WebAPI no terminal ou prompt de comando.

2. Execute o seguinte comando para adicionar uma referência ao pacote xUnit:

   ```shell
   dotnet add package Xunit
   ```

   Isso adicionará o pacote necessário para criar testes usando o xUnit.

3. Crie um novo diretório para os testes, executando o seguinte comando:

   ```shell
   mkdir Testes
   ```

4. Navegue para o diretório de testes:

   ```shell
   cd Testes
   ```

5. Execute o seguinte comando para criar um novo projeto de testes usando o xUnit:

   ```shell
   dotnet new xunit
   ```

   Isso criará um projeto de testes com a estrutura necessária usando o xUnit.

6. Volte ao diretório raiz do seu projeto WebAPI:

   ```shell
   cd ..
   ```

7. Adicione uma referência ao projeto principal ao projeto de testes, executando o seguinte comando:

   ```shell
   dotnet add Testes/Testes.csproj reference NomeDoProjeto.csproj
   ```

   Certifique-se de substituir "NomeDoProjeto.csproj" pelo nome do arquivo do projeto WebAPI.

8. Abra o arquivo `Testes/UnitTest1.cs` (ou qualquer outro arquivo de teste gerado) em um editor de código e remova o código de exemplo gerado.

9. Escreva seus próprios testes dentro desse arquivo, utilizando as classes de teste, métodos de teste e asserções apropriadas para validar o comportamento da sua WebAPI.

10. No terminal ou prompt de comando, execute o seguinte comando para compilar e executar os testes:

    ```shell
    dotnet test
    ```

    Isso compilará os testes e executará todos os casos de teste definidos usando o xUnit.

Esses são os passos para criar e executar testes para um projeto C# WebAPI no .NET 6.0 usando o xUnit. Lembre-se de que você pode adicionar mais testes, personalizar a configuração dos testes e explorar recursos avançados fornecidos pelo xUnit, como teorias e fatores de dados para testes parametrizados.

</p>