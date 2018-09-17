namespace FinalProject.Models
{
    public class Course: BaseModel
    {
     
        public string Abbreviation { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public int CreditHours { get; set; }

        public override string ToString()
        {
            return this.Abbreviation +" " + Name + " " + Number + " " + Description + " " + CreditHours + " " + "\n";
        }
    }
}
