namespace SQLParser
{
     public enum TableType
    {
         Courses =1,
         Students = 2,
         CoursesTaken=3,
         Semester = 4
    }

    public enum ActionsType
    {
        Delete = 1,
        Update = 2,
        Select = 3,
        Create = 4,
        Join = 5
    }
}
