using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Helpers
{
    public static class DataTableHelper
    {
        public static IEnumerable<T> ToList<T>(this DataTable dataTable) where T:class, new()
        {
            List<T> list = new List<T>();
            foreach (var row in dataTable.AsEnumerable())
            {
                T obj = new T();
                foreach (var prop in obj.GetType().GetProperties())
                {
                    try
                    {
                        PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                        propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                    }
                    catch(Exception e)
                    {
                        Debug.WriteLine("DTH25:26\n"+e.StackTrace);
                    }
                }
                list.Add(obj);
            }
            return list;
        }

        public static List<Dictionary<string,string>> ToListOfDictionary(this DataTable dataTable) 
        {
            if (dataTable == null || dataTable.HasErrors)
            {
                return null;
            }

            var result = new List<Dictionary<string,string>>();
            foreach (var row in dataTable.AsEnumerable())
            {
                var dict = new Dictionary<string, string>();
                foreach (var currentCol in from object col in dataTable.Columns select col.ToString())
                {
                    try
                    {
                        dict.Add(currentCol, row[currentCol].ToString());
                    }
                    catch
                    {
                        continue;
                    }
                }
                result.Add(dict);
            }
            return result;
        }
    }
}
