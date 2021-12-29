using System.Collections.Generic;
using RestCorewebapi.Models;

namespace RestCorewebapi.Data
{
    public interface ITechnologyRepo
    {
        bool SaveChanges();
        IEnumerable<technologies> GetAllTechnologies();
        technologies GetTechnologyById(int id);
        void CreateTechnology(technologies tech);
        void UpdateTechnology(technologies tech);
        void DeleteTechnology(technologies tech);
        
    }
}