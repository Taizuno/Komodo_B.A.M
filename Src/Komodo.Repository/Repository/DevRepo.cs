using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public class DevRepo
    {
        private readonly List<Developer> _developerDirectory = new List<Developer>();
		
		private int _count;

		public bool AddDeveloperToDirectory(Developer developer)
		{
			if(developer != null)
			{
				_count++;
				developer.ID = _count;
				_developerDirectory.Add(developer);
				return true;
			}
			else
			{
				return false;
			}
			
		}

		public List<Developer> GetAllDevelopers()
		{
			return _developerDirectory;
		}

		public Developer GetDeveloperByID(int id)
		{
			foreach(Developer d in _developerDirectory)
			{
				if(d.ID == id)
				{
					return d;
				}
			}

			return null;
		}

		public List<Developer> PluralsightLicense();
		{
			var license = new List<Developer>();
			foreach (Developer d in _developerDirectory)
			{
				if(d.PluralsightLicense == false)
				{
					license.Add(d);
				}
			}
			return license;
		}
    }