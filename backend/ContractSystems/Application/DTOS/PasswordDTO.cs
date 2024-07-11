namespace Application.DTOS
{
    public class PasswordDTO
    {
        public string Name { get; set; } = null!;
        public string Value { get; set; } = null!; 
        public Guid PasswordTypeId { get; set; }  
    }
}