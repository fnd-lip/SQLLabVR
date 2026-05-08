# SQL Lab VR

## Nome do aluno

Felipe Barbosa

## Apresentando o Projeto

O SQL Lab VR é uma experiência interativa criada no Unity.

O projeto representa uma sala simples de treinamento em SQL com chão, paredes, mesa, tela, objetos que representam tabelas de banco de dados e um botão SELECT.

Ao clicar no botão SELECT, aparece uma consulta SQL com um resultado fictício.

## Contexto e Objetivos

O projeto está relacionado ao Metaverso aplicado a educação.

O objetivo é mostrar de forma visual e interativa, como uma consulta SQL pode ser representada em um ambiente virtual.

## Interação Implementada

A interação foi feita em C#.

Ao clicar no botão SELECT:

- o botão muda de cor;
- a tabela `usuarios` fica destacada;
- aparece o resultado da consulta SQL.

Consulta representada:

```sql
SELECT * FROM usuarios;
```

## Controles

- `W` — andar para frente;
- `S` — andar para trás;
- `A` — mover para a esquerda;
- `D` — mover para a direita;
- Mouse — olhar ao redor;
- `Esc` — liberar o cursor;
- Clique no botão `SELECT` — executar a consulta;
- `Ctrl + P` — iniciar ou parar o Play no Unity.

## Configuração Técnica

- Unity 6.3 LTS
- Meta XR SDK instalado
- XR Plugin Management configurado
- OpenXR ativado
- Build Profile configurado para Android
- Cena `SalaSQLVR` adicionada na lista de build

## Processo de Criação e Dificuldades

A cena foi criada com objetos 3D básicos do Unity como cubos para chão, paredes, mesa, botão e tabelas.

A principal dificuldade foi transformar SQL que é um assunto teórico em algo visual. Para resolver isso a consulta foi representada por um botão interativo e um painel de resultado.

## Tecnologias Utilizadas

- Unity
- C#
- TextMeshPro
- Meta XR SDK
- OpenXR


## Como Executar

1. Baixe ou clone este repositório.
2. Abra o projeto no Unity.
3. Abra a cena `SalaSQLVR`.
4. Aperte Play.
5. Use WASD e mouse para se movimentar.
6. Clique no botão SELECT para executar a interação.
