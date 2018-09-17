using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SQLParser
{
    public static class Helpers
    {
        public static IEnumerable<string> GetAllClassFieldsName<T>(this T myObject) where T: class 
        {      
            return myObject.GetType().GetFields(BindingFlags.Static | BindingFlags.Public).Select(x => x.Name);
        }

        public static string CleanString(this string sqlCommand)
        {
            return sqlCommand.ToLower().Replace("dbo.", "");
        }
    }
}
