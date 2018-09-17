using System.Collections.Generic;
using DataContext;
using FinalProject.Models;
using FinalProject.Repository;
using Helpers;
using SQLParser;

namespace FinalProject.Service
{
    public class BaseService
    {
        private BaseRepository _repo;

        public BaseService()
        {
            //abs
            _repo = new BaseRepository(new EFDataContext.DataContext(), new AdoDataContext());
        }
        public IEnumerable<BaseModel> ExecuteSqlCommand(TableNameWithColumn tableProperties, string query)
        {
            switch (tableProperties.Tablename)
            {
                case TableNames.Courses:
                    return _repo.ExecuteCommand<Course>(query);
                case TableNames.CoursesTaken:
                    return _repo.ExecuteCommand<CourseTaken>(query);
                case TableNames.Semester:
                    return _repo.ExecuteCommand<Semester>(query);
                case TableNames.Students:
                    return _repo.ExecuteCommand<Student>(query);
                default:
                    return null;
            }
        }
        public string ExecuteSqlCommand_Ado(string query)
        {
           return _repo.ExecuteCommandAdo(query).ToString();
        }
    
    }
}
