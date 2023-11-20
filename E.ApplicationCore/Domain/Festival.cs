using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.ApplicationCore.Domain
{
    public class Festival
    {
        public int Capacite { get; set; }
        public int FestivalId { get; set; }
        public string Label { get; set; }
        public string Ville { get; set; }
        public virtual IList<Concert> Concerts { get; set; }
    }
}
