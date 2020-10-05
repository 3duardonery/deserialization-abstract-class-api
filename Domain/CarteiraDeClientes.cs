using Newtonsoft.Json;
using System.Collections.Generic;

namespace Domain
{
    [JsonObject(ItemTypeNameHandling = TypeNameHandling.Objects)]
    public sealed class CarteiraDeClientes
    {
        public string CarteiraId { get; set; }
        public IEnumerable<Pessoa> Clientes { get; set; }
    }
}
