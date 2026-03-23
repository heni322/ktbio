namespace KTBioAPI.Models
{
    public class Etat
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public List<string> Familles { get; set; } = new();
        public List<string> Utilisateurs { get; set; } = new();
        public List<int> Depots { get; set; } = new();
    }

    public class CreateEtatRequest
    {
        public string Nom { get; set; } = string.Empty;
        public List<string> Familles { get; set; } = new();
        public List<string> Utilisateurs { get; set; } = new();
        public List<int> Depots { get; set; } = new();
    }
}
