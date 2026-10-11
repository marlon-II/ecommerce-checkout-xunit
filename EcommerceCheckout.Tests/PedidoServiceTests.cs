using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceCheckout.App;

namespace EcommerceCheckout.Tests
{
    public class PedidoServiceTests
    {[Fact]
    public void Teste1_GerarCodigoRastreio()
    {
        PedidoService servico = new PedidoService();
        
        string resultado = servico.GerarCodigoRastreio("sudeste", 42);
        
        Assert.Equal("SUDESTE-0042", resultado);
    }

    [Fact]
    public void Teste2_CalcularPontosFidelidade()
    {
        PedidoService servico = new PedidoService();
        
        int resultado = servico.CalcularPontosFidelidade(150);
        
        Assert.Equal(30, resultado);
    }

    [Fact]
    public void Teste3_ClienteVIPAbaixoDe200_TemFreteGratis()
    {
        PedidoService servico = new PedidoService();
        
        bool resultado = servico.TemDireitoAFreteGratis(150, true);
        
        Assert.True(resultado);
    }

    [Fact]
    public void Teste4_ClienteNaoVIPAbaixoDe200_NaoTemFreteGratis()
    {
        PedidoService servico = new PedidoService();
        
        bool resultado = servico.TemDireitoAFreteGratis(150, false);
        
        Assert.False(resultado);
    }
    }
}