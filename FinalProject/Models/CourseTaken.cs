using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class CourseTaken: BaseModel
    {

        public int StudentId { get; set; }
        public int CourseId { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }

        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }

        public int GradeId { get; set; }

        [ForeignKey("GradeId")]
        public virtual Grades Grade { get; set; }

        public int SemesterId { get; set; }

        [ForeignKey("SemesterId")]
        public virtual Semester Semester { get; set; }
    }
}
