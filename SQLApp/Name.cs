using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLApp {
    public class Name {

        public string PrimaryName { get; set; }
        public short? BirthYear { get; set; }
        public short? DeathYear { get; set; }
        public Name( string primaryName, short? birthYear, short? deathYear)
        {
            PrimaryName = primaryName;
            BirthYear = birthYear;
            DeathYear = deathYear;
        }
    }
}
