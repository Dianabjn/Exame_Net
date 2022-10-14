using System.Text.Json.Serialization;

namespace Eval_proy.Entities
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UsTyClass
    {
        Admin = 1,
        General = 2
    }
}