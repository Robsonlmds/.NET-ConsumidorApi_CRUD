using Newtonsoft.Json;
using ConsumidorApi.Entities;
using System.Text;

namespace ConsumidorApi.Services.Staff
{
    internal class StaffServices
    {
        public async Task<StaffModel> Integracao(Guid id)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"https://localhost:44375/api/Staff/BuscarStaffPorId/{id}");

            var jsonString = await response.Content.ReadAsStringAsync();

            var jsonObject = JsonConvert.DeserializeObject<ResponseModel<StaffModel>>(jsonString);

            if (jsonObject != null)
            {
                return jsonObject.Dados;
            }
            else
            {
                return new StaffModel
                {
                    verificacao = true
                };
            }
        }

        public async Task<List<StaffModel>> IntegracaoListaStaff()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://localhost:44375/api/Staff/ListarStaff");

            var jsonString = await response.Content.ReadAsStringAsync();

            var jsonObject = JsonConvert.DeserializeObject<ResponseModel<List<StaffModel>>>(jsonString);

            if (jsonObject != null)
            {
                return jsonObject.Dados;
            }
            else
            {
                return new List<StaffModel>();
            }
        }

        public async Task<List<StaffModel>> IntegracaoCriarStaff()
        {
            HttpClient httpClient = new HttpClient();

            Console.WriteLine("Diga o nome da Staff: ");
            string carroInput = Console.ReadLine();

            Console.WriteLine("Diga o Endereço do Staff: ");
            string addressInput = Console.ReadLine();

            try
            {
                StaffAddDTO newStaff = new StaffAddDTO
                {
                    Name = carroInput,
                    Address = addressInput
                };

                var staff = JsonConvert.SerializeObject(newStaff);

                var http = new StringContent(staff, Encoding.UTF8, "application/json");

                var response = httpClient.PostAsync("https://localhost:44375/api/Staff/CriarStaff", http).Result;

                if (response.IsSuccessStatusCode)
                {

                    var result = await response.Content.ReadAsStringAsync();

                    var listResult = JsonConvert.DeserializeObject<ResponseModel<List<StaffModel>>>(result);

                    return listResult.Dados;
                }
                else
                {
                    Console.WriteLine($"Erro ao criar a Staff. Status code: {response.StatusCode}");
                    return new List<StaffModel>();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao criar a Staff: {ex.Message}");
                return new List<StaffModel>();
            }
        }

        public async Task<StaffModel> IntegracaoBuscarStaffIdCar(Guid idCar)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"https://localhost:44375/api/Staff/BuscarStaffPorIdCarro/{idCar}");

            var jsonString = await response.Content.ReadAsStringAsync();

            var jsonObject = JsonConvert.DeserializeObject<ResponseModel<StaffModel>>(jsonString);

            if (jsonObject != null)
            {
                return jsonObject.Dados;
                Console.WriteLine("Deu errado, nada foi pego da API");
            }
            else
            {
                Console.WriteLine($"Erro ao buscra a staff. Status code: {response.StatusCode}");
                return new StaffModel();
            }

        }

        public async Task<List<StaffModel>> IntegracaoDeletarStaff(Guid id)
        {
            HttpClient httpsClient = new HttpClient();
            var response = await httpsClient.DeleteAsync($"https://localhost:44375/api/Staff/DeletarStaff/{id}");

            var jsonString = await response.Content.ReadAsStringAsync();

            var jsonObject = JsonConvert.DeserializeObject<ResponseModel<List<StaffModel>>>(jsonString);

            if (jsonObject != null)
            {
                return jsonObject.Dados;
            }
            else
            {
                Console.WriteLine($"Erro ao criar o carro. Status code: {response.StatusCode}");
                return new List<StaffModel>();
            }
        }

    }
}

