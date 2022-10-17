using AplicacionPruebaBancaria.Modelos.ListarPersonaPorRol;
using AplicacionPruebaBancaria.Modelos.ListarVentasDET;
using AplicacionPruebaBancaria.Modelos.Parametos;
using AplicacionPruebaBancaria.Modelos.Producto;
using AplicacionPruebaBancaria.Modelos.Reportes;
using AplicacionPruebaBancaria.Modelos.Utilitarios;
using AplicacionPruebaBancaria.Modelos.VentasCAB;

namespace AplicacionPruebaBancaria.ServiciosAPI
{
    public interface IServicioAPI
    {
        //VENTAS
        Task<List<VentasCAB>> ListarVentasCAB(string iIdVenta25);

        Task<List<VentasDET>> ListarVentasDET(string iIdVenta25);

        Task<RespuestaGenerica> ModificarCAB(RegVentasCab regVentasCab);

        Task<RespuestaGenerica> ModificarDET(RegVentasDet regVentasDet);

        Task<RespuestaGenerica> EliminarDET(string iIdVenta25, string iIdVenta27);

        //PRODUCTOS
        Task<List<ListaProducto>> ProductoListar(string iIdProducto,string sDescripcionProducto);

        //PERSONAS
        Task<List<ListaPersonalPorRol>> ListaPersonalPorRol(string Id09, string Id08);

        //REPORTES
        Task<List<ListarReporteMetaVentas>> ReporteMetaVentas(ParamRepMetaVentas ParamRepMetaVentas);
    }
}
