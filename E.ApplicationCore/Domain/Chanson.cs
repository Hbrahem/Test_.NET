using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.ApplicationCore.Domain
{
    public class Chanson
    {
        public int ChansonId { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateSortie { get; set; }
        [Range(0,int.MaxValue,ErrorMessage ="Duree dit être positive")]
        public int Duree { get; set; }
        public StyleMusical StyleMusical { get; set; }
        [MinLength(3)]
        [MaxLength(12)]
        public string Titre { get; set; }
        public int VuesYoutube { get; set; }
        [ForeignKey(nameof(ArtisteFk))]
        public Artiste Artiste { get; set; }
        public int ArtisteFk { get; set; }
    }
}
