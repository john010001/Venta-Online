using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VentaOnLine.UI.MVC.Hubs
{
    public class VentaHub: Hub
    {
        private static List<Despacho> Pedidos = new List<Despacho>();
        public void MonitorearPedido(int numeroVenta)
        {

            Pedidos.Add(new Despacho { Pedido = numeroVenta, Status = "Despachado" });

            Clients.All.revisarPedido(Pedidos);
        }
    }


    public class Despacho
    {
        public int Pedido { get; set; }

        public string Status { get; set; }
    }
}