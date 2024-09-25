using ConsumidorApi.Entities;
using ConsumidorApi.Services.Car;
using ConsumidorApi.Services.Staff;
using System.Collections.Generic;

namespace ConsumidorApi.Controllers
{
    public class StaffController
    {
        public static async Task buscarStaff()
        {
            Console.WriteLine("\nInforme o ID da staff: ");
            if (!Guid.TryParse(Console.ReadLine(), out Guid Id))
            {
                Console.WriteLine("\nID inválido.");
                return;
            }

            StaffServices staffServices = new StaffServices();

            StaffModel staffEncontrado = await staffServices.Integracao(Id);

            if (staffEncontrado != null && !staffEncontrado.verificacao)
            {
                Console.WriteLine("\nStaff Encontrada");
                Console.WriteLine("Nome: " + staffEncontrado.Name);
                Console.WriteLine("Endereço: " + staffEncontrado.Address);
            }
            else
            {
                Console.WriteLine("\nStaff não encontrada!");
            }
        }

        public static async Task ListarStaff()
        {
            StaffServices staffServices = new StaffServices();

            List<StaffModel> listaStaff = await staffServices.IntegracaoListaStaff();

            if (listaStaff != null && listaStaff.Count > 0)
            {
                foreach (var staffEncontrado in listaStaff)
                {
                    Console.WriteLine("\nStaff Encontrada");
                    Console.WriteLine("Id: " + staffEncontrado.Id);
                    Console.WriteLine("Nome: " + staffEncontrado.Name);
                    Console.WriteLine("Endereço: " + staffEncontrado.Address);
                }
            }
            else
            {
                Console.WriteLine("Nenhuma staff encontrado.");
            }
        }


        public static async Task CriarStaff()
        {
            StaffServices staffServices = new StaffServices();

            List<StaffModel> listaStaffAtualizada = await staffServices.IntegracaoCriarStaff();

            if (listaStaffAtualizada != null && listaStaffAtualizada.Count > 0)
            {
                Console.WriteLine("\nstaff criada com sucesso!");

                foreach (var staff in listaStaffAtualizada)
                {
                    Console.WriteLine("\nstaff Encontrada:");
                    Console.WriteLine("Id: " + staff.Id);
                    Console.WriteLine("Nome: " + staff.Name);
                    Console.WriteLine("Nome: " + staff.Address);
                }
            }
            else
            {
                Console.WriteLine("Nenhuma Staff foi encontrada ou criada.");
            }
        }

        public static async Task BuscarStaffPorIdCar()
        {
            Console.WriteLine("\nInforme o ID do carro, para pesquisar a STAFF: ");
            if (!Guid.TryParse(Console.ReadLine(), out Guid IdCar))
            {
                Console.WriteLine("\nID inválido.");
                return;
            }

            StaffServices staffServices = new StaffServices();

            StaffModel staffencontrada = await staffServices.IntegracaoBuscarStaffIdCar(IdCar);

            if (staffencontrada != null)
            {

                Console.WriteLine("\nStaff Encontrado");
                Console.WriteLine("Id: " + staffencontrada.Id);
                Console.WriteLine("Nome: " + staffencontrada.Name);
                Console.WriteLine("Endereço: " + staffencontrada.Address);

            }
            else
            {
                Console.WriteLine("Nenhuma staff encontrada.");
            }
        }

        public static async Task DeletarStaff()
        {
            Console.WriteLine("\nInforme o ID da staff que deseja DELETAR: ");
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

            StaffServices staffServices = new StaffServices();

            List<StaffModel> listaStaff = await staffServices.IntegracaoDeletarStaff(Id);
            Console.WriteLine("\nStaff DELETADA");

            if (listaStaff != null && listaStaff.Count > 0)
            {
                foreach (var staffEncontrado in listaStaff)
                {
                    Console.WriteLine("\nStaff restante");
                    Console.WriteLine("Id: " + staffEncontrado.Id);
                    Console.WriteLine("Nome: " + staffEncontrado.Name);
                    Console.WriteLine("Endereço: " + staffEncontrado.Address);
                }
            }
        }






    }
}
