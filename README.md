# EcommerceCheckout

Solução .NET 10 criada via terminal para gerenciar o cálculo de código de rastreio, pontos de fidelidade e frete grátis de uma loja online. Os métodos são cobertos por testes unitários com **xUnit**.

## Tecnologias

- C# / .NET 10
- xUnit
- .NET CLI
- Git e GitHub

## Métodos implementados

Todos os métodos estão na classe `PedidoService` (`EcommerceCheckout.App/PedidoService.cs`).

| Método | Retorno | Descrição | Exemplo |
|--------|---------|-----------|---------|
| `GerarCodigoRastreio(string regiao, int numeroPedido)` | `string` | Une a região em maiúsculas com o número do pedido preenchido com zeros à esquerda (4 dígitos). | `"sudeste"`, `42` → `"SUDESTE-0042"` |
| `CalcularPontosFidelidade(int valorTotal)` | `int` | A cada R$ 10 em compras, o cliente ganha 2 pontos. | `150` → `30` |
| `TemDireitoAFreteGratis(int valorTotal, bool clienteVIP)` | `bool` | O frete é grátis se o valor total for maior ou igual a R$ 200 **ou** se o cliente for VIP. | `150`, `true` → `true` / `150`, `false` → `false` |

### Exemplo de uso

```csharp
var servico = new PedidoService();

string codigo = servico.GerarCodigoRastreio("sudeste", 42);   // "SUDESTE-0042"
int pontos = servico.CalcularPontosFidelidade(150);           // 30
bool frete = servico.TemDireitoAFreteGratis(150, true);       // true
```

## Cobertura dos testes

Os testes ficam em `EcommerceCheckout.Tests/PedidoServiceTests.cs` e usam o atributo `[Fact]`.

| Teste | Método testado | Cenário | Asserção |
|-------|----------------|---------|----------|
| `Teste1_GerarCodigoRastreio` | `GerarCodigoRastreio` | Região `"sudeste"` e pedido `42` | `Assert.Equal("SUDESTE-0042", resultado)` |
| `Teste2_CalcularPontosFidelidade` | `CalcularPontosFidelidade` | Valor total `150` | `Assert.Equal(30, resultado)` |
| `Teste3_ClienteVIPAbaixoDe200_TemFreteGratis` | `TemDireitoAFreteGratis` | Cliente VIP com compra de `150` | `Assert.True(resultado)` |
| `Teste4_ClienteNaoVIPAbaixoDe200_NaoTemFreteGratis` | `TemDireitoAFreteGratis` | Cliente não VIP com compra de `150` | `Assert.False(resultado)` |

Os três tipos de retorno (`string`, `int` e `bool`) são cobertos, assim como os dois resultados possíveis da regra de frete grátis (verdadeiro e falso).

## Como executar

### Pré-requisitos

- [.NET SDK 10](https://dotnet.microsoft.com/download)
- Git

### Clonar o repositório

```bash
git clone https://github.com/marlon-II/ecommerce-checkout-xunit.git
cd ecommerce-checkout-xunit
```

### Executar os testes

```bash
dotnet test
```

## Como a solução foi criada

```bash
# 1. Cria a solução
dotnet new sln -n EcommerceCheckout

# 2. Cria o projeto da aplicação (código de produção)
dotnet new console -n EcommerceCheckout.App -f net10.0

# 3. Cria o projeto de testes unitários com xUnit
dotnet new xunit -n EcommerceCheckout.Tests -f net10.0

# 4. Adiciona ambos os projetos à solução
dotnet sln add EcommerceCheckout.App/EcommerceCheckout.App.csproj
dotnet sln add EcommerceCheckout.Tests/EcommerceCheckout.Tests.csproj

# 5. Adiciona a referência do projeto de produção no projeto de testes
dotnet add EcommerceCheckout.Tests/EcommerceCheckout.Tests.csproj reference EcommerceCheckout.App/EcommerceCheckout.App.csproj
```

## Autor

**Marlon Andrade Bartoli**

**RA: 4251920432**

