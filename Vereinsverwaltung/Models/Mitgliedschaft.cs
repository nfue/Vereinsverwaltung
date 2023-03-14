namespace Vereinsverwaltung.Models
{
    public class Mitgliedschaft
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int IdInteressengruppe { get; set; }
    }
}
