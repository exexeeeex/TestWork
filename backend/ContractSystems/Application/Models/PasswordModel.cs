using System.Text.Json.Serialization;
using Domain.Entities;

namespace Application.Models 
{
    public class PasswordModel : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Value { get; set; } = null!;
        public string CreateDate { get; set; } = null!;

        [JsonIgnore]
        public Guid PasswordTypeId { get; set; }
    }
}