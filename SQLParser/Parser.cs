using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SQLParser
{
    public class Parser
    {
        public TableNameWithColumn Parse(string query)
        {
            var item = query.CleanString();
            var tableProperties = new TableNameWithColumn();
            tableProperties.ActionName = ParseActionName(item);
            if (isValidAction(tableProperties.ActionName))
            {
                tableProperties.Tablename = ParseTableName(item, tableProperties.ActionName);
                tableProperties.ColumnNames = ParseColumnNames(item);
                tableProperties.ErrorList = HasErrors_Properties(tableProperties.Tablename, tableProperties.ColumnNames);
            }
            else
            {
                tableProperties.ErrorList.Add("Invalid action");
            }
            return tableProperties;
        }
        private static string ParseActionName(string item)
        {
            return item.Split(' ').First().Trim();
        }
        private static string ParseTableName(string query,string action)
        {
            if (String.IsNullOrEmpty(query)) return null;
            if (action.Equals(Actions.Update))
            {
                try
                {
                    return query.Split(' ')[1];
                }
                catch
                {
                    return null;
                }
            }
            var indexWhere = query.IndexOf("where", StringComparison.Ordinal);
            if (query.Contains("where"))
            {
                return query.Substring(query.IndexOf("from", StringComparison.Ordinal) + 4, indexWhere).Trim();
            }
            return query.Substring(query.IndexOf("from", StringComparison.Ordinal) + 4).Trim();
        }
        private static List<string> ParseColumnNames(string query)
        {
            var regex = new Regex("select(.*)from");
            var columnNames = regex.Match(query).Groups[1].ToString();
            if (HasErrors_Column(columnNames)) return null;
            columnNames = Regex.Replace(columnNames, @"\s+", "");           
            return columnNames.Contains(',') ? columnNames.Split(',').ToList():
                new List<string> { columnNames };
        }
        private static List<string> HasErrors_Properties(string actionName, List<string> columns )
        {
            var errorsList =new List<string>();
            if (actionName.Equals("select") && columns == null)
            {
                errorsList.Add("Select statement with no column selector");
            }
             else if (actionName.Equals("delete") && columns != null)
            {
                errorsList.Add("Delete statement with column field");
            }
            else if (actionName.Equals("update") && columns != null)
            {
                errorsList.Add("Update statement with column field");
            }
            return errorsList.Any()? errorsList : null;
        }
        private static bool HasErrors_Column(string item)
        {
            var currentItem = item.Trim();
            if (currentItem.Length < 1) return true;
            return currentItem.Contains("*") && currentItem.Length > 1;
        }

        private static bool isValidAction(string action)
        {
            return action != null && (action.Equals(Actions.Select)
                                      || action.Equals(Actions.Create)
                                      || action.Equals(Actions.Update)
                                      || action.Equals(Actions.Delete));
        }
    }
}

