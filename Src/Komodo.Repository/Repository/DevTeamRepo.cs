using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class DevTeamRepo
    {

        private readonly List<DevTeam> _devTeamDirectory = new List<DevTeam>();
           private int _count;
    // ? Create
        public bool AddTeamToDir(DevTeam team)
        {
            if(team != null)
            {
                _devTeamDirectory.Add(team);
                return true;
            }
            return null;
        }
    // ?Read All
        public List<DevTeam> GetTeams()
        {
            return _devTeamDirectory;
        }
    // ? Read by ID
        public DevTeam GetTeamByID(int id)
        {
            foreach(DevTeam dt in _devTeamDirectory)
            {
                if(dt.ID == id)
                {
                    return dt;
                }
            }
            return null;
        }
    // ? Update-By ID
        public bool UpdateTeamByID(int id, DevTeam newTeam)
        {
            var team = GetTeamByID(id);

            if(team != null)
            {
                team.ID = newTeam.ID;
                team.TeamName = newTeam.TeamName;
                team.Developers = newTeam.Developers;
                return true;
            }
            else
            {
                return false;
            }
        }
    // ? Delete-By ID
        public bool RemoveTeamByID(int id)
        {
            var team = GetTeamByID(id);
            if(team != null)
            {
                _devTeamDirectory.Remove(team);
                return true;
            }
            else
            {return false;}
        }
    }
