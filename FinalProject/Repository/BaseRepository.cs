using System.Collections.Generic;
using System.Data;
using System.Linq;

using DataContext;
using FinalProject.Models;

namespace FinalProject.Repository
{
    public class BaseRepository
    {
        private readonly EFDataContext.DataContext _context;
        private readonly AdoDataContext _adoDataContext;

        public BaseRepository(EFDataContext.DataContext context, AdoDataContext adoDataContext)
        {
            _context = context;
            _adoDataContext = adoDataContext;
        }

        public IEnumerable<T> ExecuteCommand<T>(string userSqlCommand) where T : BaseModel
        {  
            using (_context)
                return _context.Database.SqlQuery<T>(userSqlCommand).ToList();
        }
        public DataBaseModel ExecuteCommandAdo(string userSqlCommand)
        {
            return _adoDataContext.ExecuteCommand(userSqlCommand);
        }
    }
}

