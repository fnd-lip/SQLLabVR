# SQL Lab VR

## Nome do aluno

Felipe Barbosa

## Apresentação do Projeto

O **SQL Lab VR** é uma experiência interativa criada no Unity com foco em realidade virtual e educação.

O projeto representa um laboratório de treinamento em SQL, onde o usuário pode explorar uma sala virtual com mesas, cadeiras, notebooks, servidor, roteador, painéis de banco de dados, botão interativo **SELECT** e um mini quiz educativo.

A ideia principal é transformar um conteúdo teórico como consultas SQL, em uma experiência visual e interativa dentro de um ambiente virtual.

## Contexto e Objetivo

O projeto está relacionado ao uso do **Metaverso aplicado à educação**.

O objetivo é apresentar de forma simples e visual, como conceitos básicos de SQL podem ser representados em um ambiente VR. Em vez de mostrar apenas código em uma tela comum, o usuário entra em uma sala de laboratório e interage com elementos que representam tabelas, consultas, resultados e perguntas de aprendizado.

O ambiente funciona como uma pequena sala de treinamento virtual, onde o usuário pode observar os painéis, executar uma consulta SQL e responder a um quiz sobre comandos SQL.

## Ambiente Virtual

A cena foi construída como uma sala/laboratório de SQL. O ambiente possui:

- chão e paredes;
- skybox customizado;
- mesas de laboratório;
- cadeiras;
- notebooks;
- servidor;
- roteador;
- extintor;
- copo de café;
- painéis com tabelas SQL;
- painel com consulta `SELECT`;
- painel de resultado da consulta;
- painel de mini quiz SQL;
- botões interativos para resposta do quiz.

Também foram utilizados assets importados para deixar o cenário mais completo e parecido com um laboratório de tecnologia.

## Interações Implementadas

O projeto possui interações funcionais feitas em C#.

### Botão SELECT

Ao clicar no botão **SELECT**:

- o botão muda de cor;
- a tabela `usuarios` fica destacada;
- aparece um painel com o resultado fictício da consulta SQL;
- a luz do servidor acende em verde, simulando o processamento da consulta pelo banco de dados.

Consulta representada:

```sql
SELECT * FROM usuarios;
```

### Luz de status do servidor

Foi adicionada uma luz de status no servidor.

Quando a consulta SQL é executada, a luz do servidor acende em verde, representando que o banco de dados recebeu e processou a consulta.

### Mini Quiz SQL

Também foi criado um mini quiz SQL com três opções de resposta:

- `SELECT`;
- `INSERT`;
- `DELETE`.

A pergunta do quiz é:

```text
Qual comando SQL busca dados?
```

Ao clicar na resposta correta, o sistema exibe uma mensagem de acerto. Ao clicar em uma resposta incorreta, o sistema exibe uma mensagem para tentar novamente.

Essa interação reforça o objetivo educacional do projeto, pois ajuda o usuário a associar o comando `SELECT` à ação de buscar dados em uma tabela.

### Grab Interaction

O objeto `Copo_Cafe_01` foi configurado com **Grab Interaction** usando o Meta XR Interaction SDK, para representar uma interação de pegar objetos em VR.

## Controles

- `W` — andar para frente;
- `S` — andar para trás;
- `A` — mover para a esquerda;
- `D` — mover para a direita;
- Mouse — olhar ao redor;
- `Esc` — liberar o cursor;
- Clique no botão `SELECT` — executar a consulta SQL;
- Clique nos botões do quiz — responder à pergunta;
- `Ctrl + P` — iniciar ou parar o Play Mode no Unity.

## Configuração Técnica

O projeto foi configurado com:

- Unity 6.3 LTS;
- Meta XR All-in-One SDK;
- OpenXR ativado;
- XR Plug-in Management configurado;
- Meta Quest Support habilitado;
- Build Profile configurado para Android;
- Meta XR Simulator testado no Editor;
- cena `SalaSQLVR` configurada no projeto;
- movimentação funcionando no Editor do Unity.

## Organização da Cena

A Hierarchy foi organizada com GameObjects vazios para separar os elementos principais da cena:

- `Ambiente`;
- `Objetos_SQL`;
- `Interacao`;
- `UI`;
- `Player`;
- `Iluminacao`;
- `Player_MetaRig`;
- `SQL_Paineis`;
- `Laboratorio_Assets`.

Essa organização facilita a manutenção do projeto e deixa os objetos mais fáceis de localizar.

Alguns objetos importantes da cena são:

- `Botao_SELECT`;
- `Servidor_SQL_01`;
- `Luz_Status_Servidor`;
- `Painel_Quiz_SQL`;
- `Botao_Quiz_SELECT`;
- `Botao_Quiz_INSERT`;
- `Botao_Quiz_DELETE`;
- `Texto_Resultado_Quiz`.

## Processo de Criação e Dificuldades

Durante o desenvolvimento, a principal dificuldade foi transformar SQL que é um assunto mais teórico em algo visual dentro de um ambiente virtual.

Para resolver isso, a consulta SQL foi representada por meio de painéis, tabelas e um botão interativo. Assim, o usuário consegue visualizar a ideia de executar uma consulta e receber um resultado.

Depois, o projeto foi melhorado com uma luz de status no servidor para dar feedback visual quando a consulta é executada. Também foi criado um mini quiz SQL para reforçar o lado educacional da experiência.

Outra dificuldade foi a configuração do Meta XR SDK, OpenXR e Meta XR Simulator. O simulador foi testado no Editor e reconheceu o ambiente VR, os controles virtuais e o Camera Rig da Meta.

Também houve ajustes de posicionamento, escala, colisores e textos para deixar os objetos mais organizados e funcionais dentro da cena.

## Tecnologias Utilizadas

- Unity;
- C#;
- TextMeshPro;
- Meta XR SDK;
- Meta XR Interaction SDK;
- OpenXR;
- Meta XR Simulator;
- Git e GitHub.

## Como Executar

1. Baixe ou clone este repositório.
2. Abra o projeto no Unity.
3. Abra a cena `SalaSQLVR`.
4. Verifique se o Build Profile está configurado para Android.
5. Aperte Play no Unity.
6. Use WASD e mouse para se movimentar.
7. Clique no botão `SELECT` para executar a consulta SQL.
8. Observe o painel de resultado e a luz verde do servidor.
9. Use os botões do mini quiz para responder à pergunta sobre SQL.

## Observação

O projeto foi desenvolvido como uma experiência VR interativa inicial. O foco principal foi criar um ambiente simples, organizado e funcional, utilizando Unity, Meta XR SDK e interações básicas em realidade virtual.

O **SQL Lab VR** representa um ambiente educacional no contexto do Metaverso com o objetivo de tornar o aprendizado de SQL mais visual, interativo e acessível.