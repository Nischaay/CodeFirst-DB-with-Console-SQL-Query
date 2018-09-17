using System.Collections.Generic;

namespace SQLParser
{
    public class TableNameWithColumn
    {
        public TableNameWithColumn()
        {
            ErrorList = new List<string>();
            ColumnNames = new List<string>();
        }
        public string Tablename { get; set; }
        public List<string> ColumnNames { get; set; }
        public string ActionName { get; set; }
        public List<string> ErrorList { get; set; }

    }
    }

