using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrivateSchoolManagerNew.Models
{
    public enum Type
    {
        Full = 1,
        Part
    }

    public enum Stream
    {
        Java = 1,
        Csharp
    }

    public class Course
    {
        public int ID { get; set; }
        [MaxLength(40)]
        [Required]
        public string Title { get; set; }
        [Column("Start Date", TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Column("End Date", TypeName = "date")]
        public DateTime EndDate { get; set; }
        public Stream Stream { get; set; }
        public Type Type { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Trainer> Trainers { get; set; }


        public override string ToString()
        {
            return $"ID: {ID,3}, Title: {Title}, Start Date: {StartDate:dd/MM/yyyy}, End Date: {EndDate:dd/MM/yyyy}, Stream {Stream}, Type: {Type}";
        }

        public string ToStringForDailySchedule()
        {
            return $"Title: {Title}, Stream {Stream}, Type: {Type}";
        }
    }
}
