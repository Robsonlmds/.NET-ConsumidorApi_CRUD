using ConsumidorApi.Entities;
using ConsumidorApi.Services.Car;
using ConsumidorApi.Services.Staff;
using System.Runtime.InteropServices;

namespace ConsumidorApi.Controllers.Car
{
    public class CarController
    {
        public static async Task buscarCar()
        {
            Console.WriteLine("\nInforme o ID do carro: ");
            if (!Guid.TryParse(Console.ReadLine(), out Guid Id))
            {
                Console.WriteLine("\nID inválido.");
                return;
            }

            CarServices carServices = new CarServices();

            CarModel carEncontrado = await carServices.Integracao(Id);

            if (carEncontrado != null && !carEncontrado.verificacao)
            {
                Console.WriteLine("\nStaff Encontrada");
                Console.WriteLine("Id: " + carEncontrado.Id);
                Console.WriteLine("Nome: " + carEncontrado.Name);
                Console.WriteLine("Staff ID: " + carEncontrado.Staff.Id);
                Console.WriteLine("Staff Name: " + carEncontrado.Staff.Name);
                Console.WriteLine("Staff Endereço: " + carEncontrado.Staff.Address);
            }
            else
            {
                Console.WriteLine("\nCarro não encontrado!");
            }
        }

        public static async Task CriarCar()
        {
            CarServices carServices = new CarServices();

            List<CarModel> listaCarAtualizada = await carServices.IntegracaoCriarCar();

            if (listaCarAtualizada != null && listaCarAtualizada.Count > 0)
            {
                Console.WriteLine("\nCarro criado com sucesso!");

                foreach (var car in listaCarAtualizada)
                {
                    Console.WriteLine("\nCarro Encontrado:");
                    Console.WriteLine("Id: " + car.Id);
                    Console.WriteLine("Nome: " + car.Name);
                    if (car.Staff != null)
                    {
                        Console.WriteLine("Staff Id: " + car.Staff.Id);
                        Console.WriteLine("Staff Nome: " + car.Staff.Name);
                    }
                    else
                    {
                        Console.WriteLine("Nenhum Staff atribuído.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Nenhum Carro foi encontrado ou criado.");
            }
        }

        public static async Task BuscarCarPorIdStaff()
        {
            Console.WriteLine("\nInforme o ID da staff: ");
            if (!Guid.TryParse(Console.ReadLine(), out Guid idStaff))
            {
                Console.WriteLine("\nID inválido.");
                return;
            }

            CarServices carServices = new CarServices();

            List<CarModel> carsEncontrados = await carServices.IntegracaoBuscarCarPorStaffId(idStaff);

            if (carsEncontrados != null && carsEncontrados.Count > 0)
            {
                foreach (var CarEncontrado in carsEncontrados)
                {
                    Console.WriteLine("\nCarro Encontrado");
                    Console.WriteLine("Id: " + CarEncontrado.Id);
                    Console.WriteLine("Nome: " + CarEncontrado.Name);
                    Console.WriteLine("Staff Id: " + CarEncontrado.Staff.Id);
                    Console.WriteLine("Staff Nome: " + CarEncontrado.Staff.Name);
                    Console.WriteLine("Staff Endereço: " + CarEncontrado.Staff.Address);
                }
            }
            else
            {
                Console.WriteLine("Nenhuma Carro encontrado.");
            }
        }
        public static async Task ListarCar()
        {
            CarServices staffServices = new CarServices();

            List<CarModel> listaCar = await staffServices.IntegracaoListaCar();

            if (listaCar != null && listaCar.Count > 0)
            {
                foreach (var carEncontrado in listaCar)
                {
                    Console.WriteLine("\nStaff Encontrada");
                    Console.WriteLine("Id: " + carEncontrado.Id);
                    Console.WriteLine("Nome: " + carEncontrado.Name);
                    Console.WriteLine("Staff ID: " + carEncontrado.Staff.Id);
                    Console.WriteLine("Staff Name: " + carEncontrado.Staff.Name);
                    Console.WriteLine("Staff Endereço: " + carEncontrado.Staff.Address);
                }
            }
            else
            {
                Console.WriteLine("Nenhuma staff encontrado.");
            }
        }

        public static async Task DeletarCar()
        {
            Console.WriteLine("\nInforme o ID do Carro que deseja DELETAR: ");
            if (!Guid.TryParse(Console.ReadLine(), out Guid Id))
            {
                Console.WriteLine("\nID inválido.");
                return;
            }

            Console.WriteLine("Tem certeza que deseja deletar? (Sim ou Não)");
            var resultVerificacao = Console.ReadLine()?.ToLower();

            if (resultVerificacao == "não" || resultVerificacao == "n")
            {
                Console.WriteLine("Operação cancelada.");
                return;
            }

            CarServices carServices = new CarServices();

            List<CarModel> carsEncontrados = await carServices.IntegracaoDeletarCar(Id);

            if (carsEncontrados != null && carsEncontrados.Count > 0)
            {
                foreach (var CarEncontrado in carsEncontrados)
                {
                    Console.WriteLine("\nCarro Encontrado");
                    Console.WriteLine("Id: " + CarEncontrado.Id);
                    Console.WriteLine("Nome: " + CarEncontrado.Name);
                    Console.WriteLine("Staff Id: " + CarEncontrado.StaffId);
                }
            }
            else
            {
                Console.WriteLine("Nenhuma Carro encontrado.");
            }
        }

    }
}
