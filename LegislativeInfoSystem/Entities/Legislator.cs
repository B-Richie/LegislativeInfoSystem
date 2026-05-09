namespace LegislativeInfoSystem.Entities
{
    public class Legislator
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Hometown { get; set; }

        public ICollection<Legislation>? Legislation { get; set; }
    }
}
