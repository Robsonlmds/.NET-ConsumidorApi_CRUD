using System.Numerics;
using System.Text.Json.Serialization;

namespace ConsumidorApi.Entities
{
    public class StaffModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public bool verificacao = false;

        [JsonIgnore]
        public ICollection<CarModel> Cars { get; set; }
    }
}
