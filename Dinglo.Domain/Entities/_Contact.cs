namespace Dinglo.Domain.Entities
{
    public abstract class Contact
    {
        public string Fullname { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public bool IsPrincipal { get; set; }
    }
}