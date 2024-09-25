using ConsumidorApi.Controllers;
using ConsumidorApi.Controllers.Car;

namespace ConsumidorApi
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var key = true;

            while (key == true)
            {
                Console.WriteLine("\nInforme a escolha: ");
                Console.WriteLine("1 - Buscar Staff ");
                Console.WriteLine("2 - Buscar Carro: ");
                Console.WriteLine("3 - Listar Staffs: ");
                Console.WriteLine("4 - Listar Carro: ");
                Console.WriteLine("5 - Criar Car: ");
                Console.WriteLine("6 - Criar Staff: ");
                Console.WriteLine("7 - Buscar Carro por Id da Staff: ");
                Console.WriteLine("8 - Buscar Staff por Id da Carro: ");
                Console.WriteLine("9 - DELETAR Staff por Id: ");
                Console.WriteLine("10 - DELETAR Carro por Id: ");
                Console.WriteLine("\n0 - Sair");


                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("\nEntrada inválida, insira um número.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        await StaffController.buscarStaff();
                        break;
                    case 2:
                        await CarController.buscarCar();
                        break;
                    case 3:
                        await StaffController.ListarStaff();
                        break;
                    case 4:
                        await CarController.ListarCar();
                        break; 
                    case 5:
                        await CarController.CriarCar();
                        break;
                    case 6:
                        await StaffController.CriarStaff(); 
                        break;  
                    case 7:
                        await CarController.BuscarCarPorIdStaff(); 
                        break;
                    case 8:
                        await StaffController.BuscarStaffPorIdCar(); 
                        break;
                    case 9:
                        await StaffController.DeletarStaff();
                        break;
                    case 10:
                        await CarController.DeletarCar();
                        break;

                    case 0:
                        key = false;
                        break;

                    default:
                        Console.WriteLine("\nResposta inválida.");
                        break;
                }
            }
        }

    }
}

