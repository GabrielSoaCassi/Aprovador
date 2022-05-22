# Desafio

Este projeto tem como objetivo testar o conhecimento adquirido com os estudos durante esses 3 mêses de estágio , onde avancei um pouco mais com o C# POO , e a utilização do angular.

# A Aplicação

É possível cadastrar processos,reclamantes e escritórios. Alterar suas informações e listar a mesma.

# Tecnologias Utilizadas

1. • Angular
2. • API Rest C#
3. • Testes automatizados em back-end
4. • Persistência em banco de dados (SQL Server)

# Utilizando a aplicação

    1. Clonar o Repositório
    2. Abrir a solução no Visual Studio e Baixar as Dependências.
    3. Abrir a pasta `Aprovacao` em seu diretório para rodar o comando `npm i` para baixar as dependências do angular.
    4. Para Executar o Projeto Rode o comando `ng s -o`.
    5. Inicie a execução do back-end pelo Visual Studio abrindo a solution na pasta `BackEndAprovacao` .
    6. Para rodar os teste do back end utilize o comando `CTRL + R, A` ou vá até o menu "Teste" e execute os testes.

# Info importantes

- Só é possível cadastrar um processo se houver escritório e reclamante cadastrados
- Utilizar o menu de cadastrar reclamante e escritório, para ter dados de reclamante/escritórios no banco.
- Utilizar o menu de cadastrar processo para cadastrar um processo.

# Reclamante
  ## Cadastrando um reclamante/escritório 
- Acessar o menu reclamante/escritório no topo da página, com isso irá abrir uma lista de ações possíveis como, cadastrar e editar.
- Acessar a opção cadastrar inserir um nome para o reclamante.
  ## Editando um reclamant/escritório
  - Acessar o menu reclamante/escritório no topo da página, com isso irá abrir uma lista de ações possíveis como, cadastrar e editar.
  - Acessar a opção editar.
  - Na opção de seleção `nome antigo` escolha o nome atual do reclamante/escritório
  - Na caixa de entrar de dados digite o novo nome.

  Obs: Reclamante não possui limite minímo de nome porém aceita no maxímo 100 characteres, e escritório possui um tamanho minímo de 5 characteres

# Processo 
  ## Cadastrando um processo
Seguindo a mesma lógica que os menus anteriores de reclamante/escritório, porém com um detalhe muito importante antes de cadastrar um processo, devemos cadastrar um reclamante e um escritório. Após o cadastro dos mesmo podemos partir para o cadastro do processo onde temos algumas particularidades, sendo elas os dados necessários para cadastrar um processo

- O nº do processo 
- valor da causa > R$ 30.000,00
- escritório
- reclamante
  ## Editando um processo
  - Acessar a opção de editar no menu de processos
  - Escolher o id do processo
  - Digitar um valor da causa > R$ 30.000,00 ou manter o valor atual , sendo necessário digitar o valor atual
  - manter o mesmo reclamante ou atualizar o reclamante, sendo necessário escolher o reclamante 
  - manter o mesmo escritório ou atualizar o escritório, sendo necessário escolher o escritório
  - Atualizar a situação do processo
  - Atualizar se o mesmo deve ser inativo ou permanecer ativo

# Imagens da aplicação

Tela inicial
![Tela inicial](https://i.ibb.co/Jxx5vxd/image.png)
Lista de escritório
![Tela de escritórios](https://i.ibb.co/Z1z5ZsK/image.png)
Cadastro de escritórios
![Tela de cadastro de escritórios](https://i.ibb.co/kS8m55t/image.png)
Cadastro de processos
![Tela de cadastro de processos](https://i.ibb.co/yfC3Tdc/image.png)
Cadastro de reclamante
![Tela de cadastro de reclamante](https://i.ibb.co/tm1wBKg/image.png)
