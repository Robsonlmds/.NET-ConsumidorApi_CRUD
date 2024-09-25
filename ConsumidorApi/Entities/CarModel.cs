
namespace ConsumidorApi.Entities
{

        public class CarModel
        {
            public Guid Id { get; set; }
            public string Name { get; set; }

            public bool verificacao = false;


            public Guid StaffId { get; set; }
            public StaffModel Staff { get; set; } // Referência ao Staff
        }

    }



