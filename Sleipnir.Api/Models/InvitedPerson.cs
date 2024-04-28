namespace Sleipnir.Api.Models
{
    public class InvitedPerson
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public bool CanChange { get; set; }
    }
}
