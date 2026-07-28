using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GOBDAT
{
    public class Pedido
    {
    public decimal Total { get; set; }
    public string MetodoNotificacion { get; set; }

    }

    public class PedidoService
{
    public void ProcesarPedido(Pedido pedido)
        {
            if (pedido.Total <= 0)
                throw new ArgumentException("Total inválido");

            using var conn = new SqlConnection("Server=...;Database=...;");
            conn.Open();
            var cmd = new SqlCommand("INSERT INTO Pedidos ...", conn);
            cmd.ExecuteNonQuery();

            EnviarNotificacion(pedido);
    }
    private void EnviarNotificacion(Pedido pedido)
    {
        switch (pedido.MetodoNotificacion)
        {
            case "email":
                Console.WriteLine("Enviando email...");
                break;
            case "sms":
                Console.WriteLine("Enviando SMS...");
                break;
        }
    }
}

}