using AplicacionPruebaBancaria.Modelos.ListarVentasCAB;
using AplicacionPruebaBancaria.Modelos.ListarVentasDET;
using AplicacionPruebaBancaria.Modelos.Parametos;
using AplicacionPruebaBancaria.Modelos.Producto;
using AplicacionPruebaBancaria.Modelos.Utilitarios;
using AplicacionPruebaBancaria.Modelos.VentasCAB;
using Newtonsoft.Json;
using System;
using System.Net.Http.Headers;
using System.Text;

namespace AplicacionPruebaBancaria.ServiciosAPI
{
    public class ServicioAPI : IServicioAPI
    {
        private static string _usuario = "ddominguez";
        private static string _clave = "1234";
        private static string _baseUrl = "https://localhost:7058/";
        private static string _token = "";

        public ServicioAPI()
        {
            //var buldier = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("").Build();
            _usuario = "ddominguez";
            _clave = "1234";
            _baseUrl = "https://localhost:7058/";
        }

        public async Task Autentificar()
        {
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var credenciales = new user() { usuario = _usuario, password = _clave };

            var content = new StringContent(JsonConvert.SerializeObject(credenciales), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync("Usuario/Login", content);
            var json_respuesta = await response.Content.ReadAsStringAsync();

            var resultado = JsonConvert.DeserializeObject<RespuestaGenerica>(json_respuesta);
            _token = resultado.data;
        }

        public async Task<List<VentasCAB>> ListarVentasCAB(string iIdVenta25)
        {
            List<VentasCAB> lista = new List<VentasCAB>();

            await Autentificar();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            var response = await cliente.GetAsync("Ventas/ListarVentasCAB/?iIdVenta25="+ iIdVenta25);

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ListarVentasCAB>(json_respuesta);
                lista = resultado.data.ventasCAB;
                Console.Write(resultado);
            }

            return lista;
        }

        public async Task<List<VentasDET>> ListarVentasDET(string iIdVenta25)
        {
            List<VentasDET> lista = new List<VentasDET>();

            await Autentificar();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            var response = await cliente.GetAsync("Ventas/ListarVentasDET/?iIdVenta25=" + iIdVenta25);

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ListarVentasDET>(json_respuesta);
                lista = resultado.data.ventasDET;
                Console.Write(resultado);
            }

            return lista;
        }

        public async Task<RespuestaGenerica> ModificarCAB(RegVentasCab regVentasCab)
        {
            RespuestaGenerica respuestaGenerica = new RespuestaGenerica();  

            await Autentificar();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            var content = new StringContent(JsonConvert.SerializeObject(regVentasCab), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync("Ventas/ModificarCAB/", content);

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<RespuestaGenerica>(json_respuesta);
                respuestaGenerica = resultado;
            }

            return respuestaGenerica;
        }

        public async Task<RespuestaGenerica> ModificarDET(RegVentasDet regVentasDet)
        {
            RespuestaGenerica respuestaGenerica = new RespuestaGenerica();

            await Autentificar();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            var content = new StringContent(JsonConvert.SerializeObject(regVentasDet), Encoding.UTF8, "application/json");
            var response = await cliente.PostAsync("Ventas/ModificarDET/", content);

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<RespuestaGenerica>(json_respuesta);
                respuestaGenerica = resultado;
            }

            return respuestaGenerica;
        }
        public async Task<RespuestaGenerica> EliminarDET(string iIdVenta25,string iIdVenta27)
        {
            RespuestaGenerica respuestaGenerica = new RespuestaGenerica();
            await Autentificar();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            var response = await cliente.DeleteAsync("Ventas/EliminarDET/?id25=" + iIdVenta25+ "&?id27="+ iIdVenta27) ;

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<RespuestaGenerica>(json_respuesta);
                respuestaGenerica = resultado;
            }
            return respuestaGenerica;
        }

        //PRODUCTOS
        public async Task<List<ListaProducto>> ProductoListar(string iIdProducto, string sDescripcionProducto)
        {
            List<ListaProducto> lista = new List<ListaProducto>();

            await Autentificar();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            var response = await cliente.GetAsync("Producto/Listar/?iIdProducto=" + iIdProducto + "&sDescripcionProducto=" + sDescripcionProducto);

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ProductoLista>(json_respuesta);
                lista = resultado.data.listaProducto;
                Console.Write(resultado);
            }

            return lista;
        }
    }
}
