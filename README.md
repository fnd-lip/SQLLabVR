# SQL Lab VR

## Nome do aluno

Felipe Barbosa

## Apresentando o Projeto

O SQL Lab VR é uma experiência interativa criada no Unity.

O projeto representa uma sala simples de treinamento em SQL. A cena possui chão, paredes, mesa, tela, objetos que representam tabelas de banco de dados e um botão chamado SELECT.

Ao clicar no botão SELECT, aparece um painel com uma consulta SQL e um resultado fictício.

## Contexto e Objetivos

O projeto está relacionado ao Metaverso aplicado a educação.

A ideia é mostrar como um ambiente virtual pode ser usado para ensinar conceitos básicos de banco de dados de forma visual e interativa.

O objetivo principal é criar uma sala VR simples onde o usuário possa se movimentar, observar os objetos da cena e interagir com um comando SQL.

## Interação Implementada

A interação foi feita em C#.

Ao clicar no botão SELECT:

- o botão muda de cor;
- a tabela `usuarios` fica destacada;
- aparece um painel com o resultado da consulta.

Consulta representada:

```sql
SELECT * FROM usuarios;