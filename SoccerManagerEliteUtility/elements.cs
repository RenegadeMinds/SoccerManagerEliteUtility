using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMElite
{
    // In pack
    public class club
    {
        public string id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
    }

    public class player
    {
        public string id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string image { get; set; }
    }

    // In wiki
    public class league
    {
        public string id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
    }

    public class stadium
    {
        public string id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
    }

    public class cup
    {
        public string id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
    }

    public class manager
    {
        public string id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string image { get; set; }
        public string xayaname { get; set; }
    }

    public class world
    {
        public string name { get; set; }
        public Dictionary<int, club> clubs { get; set; }
        public Dictionary<int, player> players { get; set; }
        public Dictionary<int, league> leagues { get; set; }
        public Dictionary<int, cup> cups { get; set; }
        public Dictionary<int, manager> managers { get; set; }
        public Dictionary<int, stadium> stadia { get; set; }
        

    }
}
