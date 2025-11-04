using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLApp {
    public class Title {
        public int TypeId { get; set; }
        public string PrimaryTitle { get; set; }
       public string? OriginalTitle { get; set; }
        public bool IsAdult { get; set; }
        public short? StartYear { get; set; }
        public short? EndYear { get; set; }
        public int? RuntimeMinutes { get; set; }



        public Title(int typeId, string primaryTitle, string? originalTitle, bool isAdult, short? startyear, short? endyear, int? runtime ) 
        {
            TypeId = typeId;
            PrimaryTitle = primaryTitle;
            OriginalTitle = originalTitle;
            IsAdult = isAdult;
            StartYear = startyear;
            EndYear = endyear;
            RuntimeMinutes = runtime;
        }
    }
}
