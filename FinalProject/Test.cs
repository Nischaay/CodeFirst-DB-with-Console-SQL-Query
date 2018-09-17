using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Models;

namespace FinalProject
{
    public class Test
    {
        private DataContext.DataContext _dataContext;

        public Test()
        {
            _dataContext = new DataContext.DataContext();
        }

        public void AddToCourses(Course course)
        {
            _dataContext.Courses.SqlQuery("");
        }
    }
}
