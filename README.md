# SQL Lab VR

## Nome do aluno

Felipe Barbosa

## Apresentação do Projeto

O **SQL Lab VR** é uma experiência interativa criada no Unity com foco em realidade virtual e educação.

O projeto representa um laboratório de treinamento em SQL onde o usuário pode explorar uma sala virtual com mesas, cadeiras, notebooks, servidor, painéis de banco de dados e um botão interativo chamado **SELECT**.

A ideia principal é transformar um conteúdo teórico, como uma consulta SQL em uma experiência visual e interativa dentro de um ambiente virtual.

## Contexto e Objetivo

O projeto está relacionado ao uso do **Metaverso aplicado à educação**.

O objetivo é apresentar de forma simples e visual, como uma consulta SQL pode ser representada em um ambiente VR. Em vez de mostrar apenas o código em uma tela comum, o usuário entra em uma sala de laboratório e interage com elementos que representam tabelas, consultas e resultados de banco de dados.

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
- painel de resultado da consulta.

Também foram utilizados assets importados para deixar o cenário mais completo e parecido com um laboratório de tecnologia.

## Interação Implementada

A interação principal foi feita em C#.

Ao clicar no botão **SELECT**:

- o botão muda de cor
- a tabela `usuarios` fica destacada
- aparece um painel com o resultado fictício da consulta SQL

Consulta representada:

```sql
SELECT * FROM usuarios;
```

Além disso, o objeto `Copo_Cafe_01` foi configurado com **Grab Interaction** usando o Meta XR Interaction SDK para representar uma interação de pegar objetos em VR.

## Controles

- `W` — andar para frente;
- `S` — andar para trás;
- `A` — mover para a esquerda;
- `D` — mover para a direita;
- Mouse — olhar ao redor;
- `Esc` — liberar o cursor;
- Clique no botão `SELECT` — executar a consulta SQL;
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
- cena `SalaSQLVR` configurada no projeto.

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

## Processo de Criação e Dificuldades

Durante o desenvolvimento, a principal dificuldade foi transformar SQL que é um assunto mais teórico em algo visual dentro de um ambiente virtual.

Para resolver isso, a consulta SQL foi representada por meio de painéis, tabelas e um botão interativo. Assim, o usuário consegue visualizar a ideia de executar uma consulta e receber um resultado.

Também houve dificuldade na configuração do Meta XR SDK, OpenXR e Meta XR Simulator. O simulador foi testado no Editor e reconheceu o ambiente VR, os controles virtuais e o Camera Rig da Meta.

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
7. Clique no botão `SELECT` para executar a interação SQL.

## Observação

O projeto foi desenvolvido como uma primeira experiência VR interativa. O foco principal foi criar um ambiente simples, organizado e funcional, utilizando Unity, Meta XR SDK e interações básicas em realidade virtual.
