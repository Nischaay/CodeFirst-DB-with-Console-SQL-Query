using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Helpers
{
   public static class ReflectionHelper
    {
        public static IEnumerable<string> GetAllClassFieldsName<T>(this T myObject) where T : class
        {
            return myObject.GetType().GetFields(BindingFlags.Static | BindingFlags.Public).Select(x => x.Name);
        }
    }
}
