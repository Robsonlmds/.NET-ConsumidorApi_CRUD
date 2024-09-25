using ConsumidorApi.Entities;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using System.Text;

namespace ConsumidorApi.Services.Car
{
    internal class CarServices
    {
        public async Task<CarModel> Integracao(Guid id)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"https://localhost:44375/api/Car/BuscarCarPorId/{id}");

            var jsonString = await response.Content.ReadAsStringAsync();

            var jsonObject = JsonConvert.DeserializeObject<ResponseModel<CarModel>>(jsonString);

            if (jsonObject != null)
            {
                return jsonObject.Dados;
            }
            else
            {
                return new CarModel
                {
                    verificacao = true
                };
            }
        }
        public async Task<List<CarModel>> IntegracaoListaCar()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://localhost:44375/api/Car/ListarCar");

            var jsonString = await response.Content.ReadAsStringAsync();

            var jsonObject = JsonConvert.DeserializeObject<ResponseModel<List<CarModel>>>(jsonString);

            if (jsonObject != null)
            {
                return jsonObject.Dados;
            }
            else
            {
                return new List<CarModel>();
            }
        }

        public async Task<List<CarModel>> IntegracaoCriarCar()
        {
            HttpClient httpClient = new HttpClient();

            Console.WriteLine("Diga o nome do Carro: ");
            string carroInput = Console.ReadLine();

            Console.WriteLine("Diga o id da Staff: ");
            Guid.TryParse(Console.ReadLine(), out Guid staffIdInput);

            try
            {
                CarAddDTO newCar = new CarAddDTO
                {
                    Name = carroInput,
                    Staff = new BetweenDTO { Id = staffIdInput }
                };

                var carJson = JsonConvert.SerializeObject(newCar);
                Console.WriteLine("Dados enviados para API: " + carJson);

                var httpContent = new StringContent(carJson, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync("https://localhost:44375/api/Car/CriarCar", httpContent);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var listResult = JsonConvert.DeserializeObject<ResponseModel<List<CarModel>>>(result);

                    return listResult.Dados;
                }
                else
                {
                    Console.WriteLine($"Erro ao criar o carro. Status code: {response.StatusCode}");
                    return new List<CarModel>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao criar o carro: {ex.Message}");
                return new List<CarModel>();
            }
        }

        public async Task<List<CarModel>> IntegracaoBuscarCarPorStaffId(Guid idStaff)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"https://localhost:44375/api/Car/BuscarCarPorIdStaff/{idStaff}");

            var jsonString = await response.Content.ReadAsStringAsync();

            var jsonObject = JsonConvert.DeserializeObject<ResponseModel<List<CarModel>>>(jsonString);

            if (jsonObject != null)
            {
                return jsonObject.Dados;
            }
            else
            {
                Console.WriteLine($"Erro ao criar o carro. Status code: {response.StatusCode}");
                return new List<CarModel>();
            }

        }

        public async Task<List<CarModel>> IntegracaoDeletarCar(Guid id)
        {
            HttpClient httpsClient = new HttpClient();
            var response = await httpsClient.DeleteAsync($"https://localhost:44375/api/Car/DeletarCar/{id}");

            var jsonString = await response.Content.ReadAsStringAsync();

            var jsonObject = JsonConvert.DeserializeObject<ResponseModel<List<CarModel>>>(jsonString);

            if (jsonObject != null) 
            {
                return jsonObject.Dados;
            }
            else
            {
                Console.WriteLine($"Erro ao criar o carro. Status code: {response.StatusCode}");
                return new List<CarModel>();
            }
        }

    }
}

