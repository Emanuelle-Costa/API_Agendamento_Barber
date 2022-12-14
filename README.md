<h1 align="center"> Barber Shop </h1>

<p align="center">
<img src="http://img.shields.io/static/v1?label=STATUS&message=EM%20DESENVOLVIMENTO&color=GREEN&style=for-the-badge"/>
</p> 

<h2>Sobre o Projeto:</h2>
<p>O projeto tem a proposta de ser uma Web API para agendamento de serviços de Barbearia.</p>
<br>
<p>O projeto está em desevolvimento e até o momento foram implementadas as funcionalidades:</p>
<p>-Listar Profissionais;</p>
<p>-Adicionar Profissional;</p>
<p>-Alterar(editar) Profissional;</p>
<p>-Deletar Profissional;</p>
<p>-Filtrar Profissional pelo nome.</p>
<br>
<hr>

<h2>Linguagens e ferramentas utilizadas:</h2>
<p>O projeto foi criado utilizando Dontnet 6.0.403 e Angular 14.2.0</p>
<p>No front-end foi utulizada a ferramenta Bootstrap</p>
<p>O banco de dados utilizado foi o MySQL versão 8.0.29</p>
<br>
<hr>

<h2>O que você vai precisar para rodar o projeto na sua máquina?</h2>
<p><b>1-</b> Ao Baixar o projeto abra-o no Visual Studio Code importe as seguintes ferramentas na versão 6.0.10:</p>
<p>-Microsoft.entityframeworkcore;</p>
<p>-Microsoft.entityframeworkcore.Desing;</p>
<p>-Microsoft.entityframeworkcore.Tools;</p>
<p>-Microsoft.AspNetCore.Mvc.NewtonsoftJson.</p>
<br>
<p><b>2-</b>Localize dentro da Pasta Back o arquivo "appsettings.json" e altere o "Server, Uid e Pwd" de acordo com a sua conexão local MySQL;</p>
<br>
<p><b>3-</b> Abra um terminal na pasta que você clonou o projeto e caminhe até a pasta BarberShop  (cd Back\src\BarberShop);</p>
<br>
<p><b>4-</b>Execute o comando: dotnet ef migrations add inicial -o Data/Migrations;</p>
<br>
<p><b>5-</b>Em seguida execute o comando: dotnet ef database update;</p>
<br>
<p><b>6-</b> Execute o comando dotnet watch run;</p>
<br>
<p><b>7-</b> Abra um novo terminal na pasta que você clonou o projeto e caminhe até ProjetoAPI (cd Front\ProjetoAPI);</p>
<br>
<p><b>8-</b> Execute o comando npm install e em seguida o comando ng serve;</p>
<br>
<p><b>9-</b> Abra em seu navegador o link http gerado pelo comando ng serve (http://localhost:4200).</p>
<br>
<h3>Prontinho! O projeto já deve rodar em sua máquina.</h3>
<br>
<hr>
<h2>Telas Funcionais da aplicação:</h2>
<br>
<p>Listagem dos Profissionais Cadastrados:</p>

![Listagem dos Profissionais Cadastrados](https://i.imgur.com/99fQytW.png)
<br>
<hr>

<p>Ao clicar em editar abre uma página com os campos preenchidos com as informações atuais do Profissional:</p>

![Editar](https://i.imgur.com/fGI9gie.png)

<p>Basta atualizar a informação desejada, clicar em Salvar e em seguida Listar Profissionais.</p>
<br>
<hr>


<p>Ao Passar o mouse na foto é possível visualizar o Id do profissional:</p>

![Id](https://i.imgur.com/NFqlImC.png)
<br>
<hr>

<p>Ao clicar em +Novo abre uma página com os campos a serem preenchidos:</p>

![Adicionar](https://i.imgur.com/k1O9K8Q.png)

<br>
<hr>

<p>Filtrar (buscar) profissional pelo nome:</p>

![Filtro](https://i.imgur.com/4OGgQ0s.png)
<br>
<hr>

<p>Ao clicar em Excluir a seguinte mensagem é mostrada:</p>

![Excluir](https://i.imgur.com/c3jU3aD.png)

<br>
<hr>

<p>Clicando em Sim para confirmar a exclusão é apresentado um tooltip com mensagem de sucesso:</p>

![Excluir](https://i.imgur.com/7P1G0I7.png)
<br>

