namespace LegislativeInfoSystem.Entities
{
    public class Legislation
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? LegislationText { get; set; }

        public ICollection<Legislator>? Sponsors { get; set; }
    }
}
