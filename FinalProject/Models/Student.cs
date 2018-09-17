using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Helpers;

namespace FinalProject.Models
{
    public class Student: BaseModel
    {
       
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        [Column("WNumber")]
        [MinLength(7)]
        public string WNumber { get; set; }

        [Column("DOB")]
        public DateTime DOB { get; set; }
        public string Major { get; set; }
        public string DegreeProgram { get; set; }
        public bool IsGraduate { get; set; }

        public override string ToString()
        {
            {
                return this.FirstName + " " + MiddleName + " " + LastName + " " + WNumber + " " + DOB + " " + Major +
                       " " + DegreeProgram + " " + (IsGraduate ? "Graduate": "Undergraduate") + "\n";
            }
        }
    }
}

