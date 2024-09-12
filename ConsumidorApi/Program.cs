using ConsumidorApi.Entities;
using ConsumidorApi.Entities.Services;
using ConsumindoApiAluno.Entities.Services;

namespace ConsumindoApi
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var key = true;

            while (key == true)
            {
                Console.WriteLine("Informe a escolha: ");
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Entrada inválida, insira um número.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        await buscarStaff(); // Utilizando await
                        break;
                    case 2:
                        // code block
                        break;
                    case 3:
                        key = false;
                        break;
                    default:
                        Console.WriteLine("Resposta inválida.");
                        break;
                }
            }
        }

        public static async Task buscarStaff() // async Task para assíncrono correto
        {
            Console.WriteLine("Informe o ID: ");
            if (!Guid.TryParse(Console.ReadLine(), out Guid Id))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            StaffServices staffServices = new StaffServices();

            StaffModel staffEncontrado = await staffServices.Integracao(Id);

            if (staffEncontrado != null && !staffEncontrado.verificacao)
            {
                Console.WriteLine("Staff Encontrada");
                Console.WriteLine("Nome: " + staffEncontrado.Name);
                Console.WriteLine("Endereço: " + staffEncontrado.Address);
            }
            else
            {
                Console.WriteLine("Staff não encontrada!");
            }
        }
    }
}
