using Newtonsoft.Json;
using ConsumidorApi.Entities;

namespace ConsumindoApiAluno.Entities.Services
{
    internal class StaffServices
    {
        public async Task<StaffModel> Integracao(Guid id)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"https://localhost:7276/api/Staff/BuscarStaffPorId/{id}");

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
    }
}

/*
namespace ConsumindoApiAluno.Entities.Services
{
    internal class StaffServices
    {
        public async Task<StaffModel> Integracao(Guid id)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"https://localhost:7276/api/Staff/BuscarStaffPorId/{id}");

            if (!response.IsSuccessStatusCode)
            {
                // Tratar erro ou lançar exceção dependendo do caso
                return new StaffModel
                {
                    verificacao = true
                };
            }

            var jsonString = await response.Content.ReadAsStringAsync();

            var jsonObject = JsonConvert.DeserializeObject<ResponseModel<StaffModel>>(jsonString);

            if (jsonObject != null && jsonObject.Dados != null)
            {
                return jsonObject.Dados; // Acessando o objeto StaffModel dentro de ResponseModel
            }
            else
            {
                return new StaffModel
                {
                    verificacao = true
                };
            }
        }
    }
}*/