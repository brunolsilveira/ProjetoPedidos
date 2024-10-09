using System.Text.Json.Serialization;

namespace ProjPedidos.Domain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Role
{
    Admin,
    User
}
