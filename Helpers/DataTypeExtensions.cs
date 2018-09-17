namespace Helpers
{
    public static class DataTypeExtensions
    {
        public static bool ToBoolean(this bool? item)
        {
            return item==true;
        }
    }
}
