using System;
using System.Collections.Generic;
using System.Linq;
using Lab05.Model;

namespace Lab05.Services
{
    public class FacultyService
    {
        private readonly Model1 db = new Model1();

        public List<Faculty> GetAll()
        {
            return db.Faculty.OrderBy(f => f.FacultyName).ToList();
        }
    }
}
