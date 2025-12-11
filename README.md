# Big Tree

Big Tree é um programa console que converte estruturas JSON hierárquicas em arquivos TXT formatados em leiautes específicos.  
O projeto é extensível e foi desenhado seguindo princípios de Clean Architecture, permitindo acoplamento de novos tipos de dados e variações de leiaute por meio de atributos e reflexão.

---

## Tecnologias Utilizadas

- .NET Framework 4.8  
- C#  
- Console Application  
- Microsoft.Extensions.DependencyInjection (Injeção de Dependência)  
- Newtonsoft.Json (Leitura e deserialização de JSON)  
- Reflection (para descoberta dinâmica de tipos e regras de leiaute)  
- Moq (para testes unitários)  
- NUnit
- Arquivos JSON como fonte configurável

---

## Como Instalar e Usar

### 1. Clonar o repositório
```bash
git clone https://github.com/seu-usuario/big-tree.git
```
### 2. Restaurar dependências
Via CLI:
```bash
dotnet restore
dotnet build
```
### 3. Configurar o arquivo app.config
O programa utiliza dois caminhos configuráveis:
- Caminho para o arquivo JSON de entrada
- Caminho da pasta de saída para os arquivos TXT

Esses valores podem ser definidos: diretamente no app.config, ou através do próprio programa (Menu > Configurar Caminhos)

<img width="761" height="297" alt="image" src="https://github.com/user-attachments/assets/2dd664f6-9d90-4bab-8882-ea9081613c2f" />

>  This is a challenge by [Coodesh](https://coodesh.com/)
