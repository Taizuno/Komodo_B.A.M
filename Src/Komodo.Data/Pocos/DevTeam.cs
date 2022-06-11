using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public class DevTeam
    {
        public DevTeam(){}
        public DevTeam(string teamname)
        {
            TeamName = teamname;
        }
        public int ID {get; set;}
        public string TeamName{get;set;}
        public List<Developer> Developers {get; set;}= new List<Developer>();
    }