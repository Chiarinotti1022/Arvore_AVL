# 🌳 Projeto - Árvore AVL em C#

## 📄 Descrição

Este projeto consiste na implementação de uma **Árvore AVL** em **C#**, desenvolvido como parte da disciplina de **APOOI (Análise e Projeto Orientado a Objetos I)**.  
A Árvore AVL é uma estrutura de dados balanceada que garante operações eficientes de **inserção, remoção e busca**, mantendo o balanceamento automático após cada operação.

---

## ⚙️ Funcionalidades

O programa executa as seguintes operações na árvore AVL, de acordo com comandos lidos de um arquivo `.txt`:

- 🔢 **Inserção (`I valor`)** – Insere um valor na árvore.
- ❌ **Remoção (`R valor`)** – Remove um valor da árvore, se existir.
- 🔍 **Busca (`B valor`)** – Verifica se um valor está presente na árvore e retorna:
  - `Valor encontrado`
  - `Valor não encontrado`
- 🧠 **Impressão em Pré-Ordem (`P`)** – Exibe a árvore percorrida em pré-ordem.
- ⚖️ **Fatores de Balanceamento (`F`)** – Mostra o fator de balanceamento de cada nó.
- 📏 **Altura da Árvore (`H`)** – Mostra a altura atual da árvore.

---

## 📑 Funcionamento do Arquivo de Entrada

- O programa solicita que o usuário informe o **caminho completo do arquivo `.txt`** contendo os comandos.
- O caminho deve ser informado **sem aspas**.
- Foi implementado um **loop de validação**, onde o programa **não inicia enquanto o arquivo não for localizado corretamente**.

### 🔗 Exemplo de Caminho Válido no Windows:

```C:\Users\SeuUsuario\Documents\comandos.txt```

---

## 🏗️ Formato dos Comandos no Arquivo

Cada linha do arquivo deve conter um comando, seguido ou não de um valor:

| Comando | Ação                              |
|---------|------------------------------------|
| I X     | Insere o valor X na árvore         |
| R X     | Remove o valor X da árvore         |
| B X     | Busca o valor X na árvore          |
| P       | Imprime a árvore em pré-ordem      |
| F       | Mostra fatores de balanceamento    |
| H       | Mostra a altura atual da árvore    |

### 🔥 Exemplo de Arquivo de Entrada

```
I 10
I 20
I 30
P
I 15
P
R 20
P
B 15
B 25
F
H
```

---

## 🖨️ Saída Esperada

O programa imprime no console os resultados das operações, exemplo:

```
Árvore em pré-ordem: 10 20 30
Árvore em pré-ordem: 10 15 20 30
Árvore em pré-ordem: 10 15 30
Valor encontrado
Valor não encontrado
Fatores de balanceamento:
Nó 10: Fator de balanceamento 1
Nó 15: Fator de balanceamento 0
Nó 30: Fator de balanceamento 0
Altura da árvore: 2
```

---

## 🚩 Observações Importantes

- ✔️ Projeto desenvolvido totalmente em **C#**, utilizando **Programação Orientada a Objetos (POO)**.
- ✔️ O programa valida o caminho do arquivo antes de executar os comandos.
- ✔️ **Todos os testes foram realizados e nenhum bug foi identificado até o momento.**

---

## 💻 Como Executar

1. Clone este repositório.
2. Compile o projeto utilizando uma IDE como Visual Studio ou Visual Studio Code.
3. Execute o programa.
4. Insira o caminho completo do arquivo `.txt` com os comandos quando solicitado.
5. Acompanhe a execução diretamente pelo console.

---


