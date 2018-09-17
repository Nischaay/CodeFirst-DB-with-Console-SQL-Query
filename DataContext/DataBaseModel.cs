using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace DataContext
{
    public class DataBaseModel
    {
        public DataBaseModel()
        {
            DataTable = new DataTable();
            Exceptions = new List<Exception>();
        }
        public DataTable DataTable { get; set; }
        public List<Exception> Exceptions { get; set; }

        public override string ToString()
        {
            if (DataTable.HasErrors) return null;
            var result = new StringBuilder();

            if (Exceptions.Any())
            {
                result.AppendLine("!!Error!!");
                foreach (var e in Exceptions)
                {
                    result.AppendLine(e.Message);
                }
                return result.ToString();
            }
            foreach (DataRow dataRow in this.DataTable.Rows)
            {
                foreach (var item in dataRow.ItemArray)
                {
                    result.Append($"{item + " ",10}");
                }
                result.AppendLine();
            }
            return result.ToString();
        }
    }
}
