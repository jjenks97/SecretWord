using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Secret_Words.Models
{
    public class WordModel
    {
        public int ID { get; set; }
        public string Word { get; set; }
        public DateTime Time { get; set; }
        public string UserName { get; set; }
    }
}
