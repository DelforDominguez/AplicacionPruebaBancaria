using AplicacionPruebaBancaria.Modelos.ListarVentasCAB;
using AplicacionPruebaBancaria.Modelos.ListarVentasDET;
using AplicacionPruebaBancaria.Modelos.Parametos;
using AplicacionPruebaBancaria.Modelos.Utilitarios;
using AplicacionPruebaBancaria.Modelos.VentasCAB;

namespace AplicacionPruebaBancaria.ServiciosAPI
{
    public interface IServicioAPI
    {
        Task<List<VentasCAB>> ListarVentasCAB(string iIdVenta25);

        Task<List<VentasDET>> ListarVentasDET(string iIdVenta25);

        Task<RespuestaGenerica> ModificarCAB(RegVentasCab regVentasCab);

        Task<RespuestaGenerica> ModificarDET(RegVentasDet regVentasDet);

        Task<RespuestaGenerica> EliminarDET(string iIdVenta25);
    }
}
