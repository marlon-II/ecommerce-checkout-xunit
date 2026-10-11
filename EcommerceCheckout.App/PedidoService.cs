using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceCheckout.App
{
    public class PedidoService
    {
        public string GerarCodigoRastreio(string regiao, int numeroPedido)
        {
            return $"{regiao.ToUpper()}-{numeroPedido:D4}";
        }

        public int CalcularPontosFidelidade(int valorTotal)
        {
            int pontos = (valorTotal / 10) * 2;
            return pontos;
        }

        public bool TemDireitoAFreteGratis(int valorTotal, bool ClienteVIP)
        {
            if(valorTotal >= 200 || ClienteVIP == true){
                return true;
            }else
            {
                return false;
            }

        }
    }
}