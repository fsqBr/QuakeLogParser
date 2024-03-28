using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuakeLogParser.Domain.Entities
{

    public class GameMatch
    {
        public Guid Id { get; set; }        
        public string Player { get; set; }
        public TypeActionEnum Action { get; set; }
        public string Weppon { get; set; }
        public bool IsPlayer { get; set; }        

    }
}
