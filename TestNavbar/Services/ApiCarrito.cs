using TestNavbar.Models.Orden;

namespace TestNavbar.Services
{
    public class ApiCarrito
    {
        //Atributos
        private static ApiCarrito _instancia;

        private HttpClient client = new HttpClient();

        private readonly string _url = "https://apirestaurantehamburguesas20231210132143.azurewebsites.net/api/Carrito";

        //Constructor
        private ApiCarrito() { }

        //Métodos
        public static ApiCarrito Singleton()
        {
            if (_instancia == null)
            {
                _instancia = new ApiCarrito();
            }
            return _instancia;
        }

        // GET: api/Carrito
        public async Task<ProductoCarrito>
            ObtenerProducto(int idProducto)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"""
                {_url}/ObtenerProducto/{idProducto}
                """);

                if (!response.IsSuccessStatusCode)
                    throw new Exception(await response.Content.ReadAsStringAsync());

                return await response.Content.ReadAsAsync<ProductoCarrito>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        // GET: api/Carrito
        public async Task<ComidaCarrito>
            ObtenerComidaCarrito(int idComidaCarrito)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"""
                {_url}/ObtenerComidaCarrito/{idComidaCarrito}
                """);

                if (!response.IsSuccessStatusCode)
                    throw new Exception(await response.Content.ReadAsStringAsync());

                return await response.Content.ReadAsAsync<ComidaCarrito>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        // GET: api/Carrito
        public async Task<ComboCarrito>
            ObtenerComboCarrito(int idComboCarrito)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"""
                {_url}/ObtenerComboCarrito/{idComboCarrito}
                """);

                if (!response.IsSuccessStatusCode)
                    throw new Exception(await response.Content.ReadAsStringAsync());

                return await response.Content.ReadAsAsync<ComboCarrito>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        // GET: api/Carrito
        public async Task<ComidaCarrito[]>
            ObtenerComidas(int idOrden)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"""
                {_url}/ObtenerComidas/{idOrden}
                """);

                if (!response.IsSuccessStatusCode)
                    throw new Exception(await response.Content.ReadAsStringAsync());

                return await response.Content.ReadAsAsync<ComidaCarrito[]>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        // GET: api/Carrito
        public async Task<ComboCarrito[]>
            ObtenerCombos(int idOrden)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"""
                {_url}/ObtenerCombos/{idOrden}
                """);

                if (!response.IsSuccessStatusCode)
                    throw new Exception(await response.Content.ReadAsStringAsync());

                return await response.Content.ReadAsAsync<ComboCarrito[]>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        // GET: api/Carrito
        public async Task<ComidaCarrito[]>
            ObtenerComidasCombo(int idCombo)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"""
                {_url}/ObtenerComidasCombo/{idCombo}
                """);

                if (!response.IsSuccessStatusCode)
                    throw new Exception(await response.Content.ReadAsStringAsync());

                return await response.Content.ReadAsAsync<ComidaCarrito[]>();
            }
            catch (Exception)
            {
                return null;
            }
        }

        // GET: api/Carrito
        public async Task<double>
            CalcularTotalCombo(int idComboCarrito)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"""
                {_url}/CalcularTotalCombo/{idComboCarrito}
                """);

                if (!response.IsSuccessStatusCode)
                    throw new Exception(await response.Content.ReadAsStringAsync());

                return await response.Content.ReadAsAsync<double>();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        // GET: api/Carrito
        public async Task<double>
            CalcularTotalComidas(int idOrden)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"""
                {_url}/CalcularTotalComidas/{idOrden}
                """);

                if (!response.IsSuccessStatusCode)
                    throw new Exception(await response.Content.ReadAsStringAsync());

                return await response.Content.ReadAsAsync<double>();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        // POST: api/Carrito
        public async Task<string>
            AgregarComboCarrito(int idOrden, int idCombo, int cantidad, int[] idComidas)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync($"""
                {_url}/AgregarComboCarrito/{idOrden},{idCombo},{cantidad}
                """, idComidas);

                if (!response.IsSuccessStatusCode)
                    throw new Exception(await response.Content.ReadAsStringAsync());

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // POST: api/Carrito
        public async Task<string>
            AgregarComidaCarrito(int idOrden, int idComida, int cantidad)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsync($"""
                {_url}/AgregarComidaCarrito/{idOrden},{idComida},{cantidad}
                """, null);

                if (!response.IsSuccessStatusCode)
                    throw new Exception(await response.Content.ReadAsStringAsync());

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // PUT: api/Carrito
        public async Task<string>
            ModificarCantidadProducto(int idProducto, int cantidad)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsync($"""
                {_url}/ModificarCantidadProducto/{idProducto},{cantidad}
                """, null);

                if (!response.IsSuccessStatusCode)
                    throw new Exception(await response.Content.ReadAsStringAsync());

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // PUT: api/Carrito
        public async Task<string>
            AumentarCantidadProducto(int idProducto)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsync($"""
                {_url}/AumentarCantidadProducto/{idProducto}
                """, null);

                if (!response.IsSuccessStatusCode)
                    throw new Exception(await response.Content.ReadAsStringAsync());

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // PUT: api/Carrito
        public async Task<string>
            DisminuirCantidadProducto(int idProducto)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsync($"""
                {_url}/DisminuirCantidadProducto/{idProducto}
                """, null);

                if (!response.IsSuccessStatusCode)
                    throw new Exception(await response.Content.ReadAsStringAsync());

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // DELETE: api/Carrito
        public async Task<string>
            EliminarComboCarrito(int idComboCarrito)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync($"""
                {_url}/EliminarComboCarrito/{idComboCarrito}
                """);

                if (!response.IsSuccessStatusCode)
                    throw new Exception(await response.Content.ReadAsStringAsync());

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // DELETE: api/Carrito
        public async Task<string>
            EliminarComidaCarrito(int idComidaCarrito)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync($"""
                {_url}/EliminarComidaCarrito/{idComidaCarrito}
                """);

                if (!response.IsSuccessStatusCode)
                    throw new Exception(await response.Content.ReadAsStringAsync());

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
