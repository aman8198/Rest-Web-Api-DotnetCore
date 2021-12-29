using System;
using System.Collections.Generic;
using System.Linq;
using RestCorewebapi.Models;

namespace RestCorewebapi.Data
{
    public class SqlTechnologyRepo : ITechnologyRepo
    {
        private readonly TechnologyContext _context;
        public SqlTechnologyRepo(TechnologyContext context)
        {
          _context = context;   
        }
        public void CreateTechnology(technologies tech)
        {
            if(tech == null)
            {
                throw new ArgumentNullException(nameof(tech));
            }
            _context.Technology.Add(tech);
        }

        public void DeleteTechnology(technologies tech)
        {
            if(tech == null)
            {
                throw new ArgumentNullException(nameof(tech));
            }
            _context.Technology.Remove(tech);
        }

        public IEnumerable<technologies> GetAllTechnologies()
        {
         return _context.Technology.ToList();
        }

        public technologies GetTechnologyById(int id)
        {
            return _context.Technology.FirstOrDefault(p=>p.Id==id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >=0);
        }

        public void UpdateTechnology(technologies tech)
        {
         
        }
    }

}