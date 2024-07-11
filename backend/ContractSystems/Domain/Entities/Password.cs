using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Password : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Value { get; set; } = null!;
        public DateTime CreateDate { get; set; }

        public Guid PasswordTypeId { get; set; }
        [JsonIgnore]
        public PasswordType? PasswordType { get; set; }
    }
}