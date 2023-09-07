using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusiqueBOL
{
    public enum GenreMusique
    {
        Hip_Hop,
        Classique,

    };

    public enum TypeExtension
    {
        aif,
        mp3,
        flac,
    };

    public class Musique
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Artiste { get; set; }
        public DateTime DateSortie { get; set; }
        public GenreMusique? Genre { get; set; }
        public long Taille {  get; set; }
        public int Duree { get; set; }
        public TypeExtension TypeExtension { get; set; }
        public string Path { get; set; }
        public List<Album> Albums { get; set; }
    }
}
