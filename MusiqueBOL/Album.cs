namespace MusiqueBOL
{
    public class Album
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Artiste { get; set; }
        public DateTime DateSortie { get; set; }
        public GenreMusique? Genre { get; set; }
        public long Taille { get; set; }
        public int Duree { get; set; }
        public string Path { get; set; }
        public List<Musique> Musiques { get; set; }

    }
}