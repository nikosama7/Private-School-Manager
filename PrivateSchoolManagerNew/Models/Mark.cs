using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrivateSchoolManagerNew.Models
{
    public class Mark
    {
        [Column("Oral Mark")]
        [Range(0.0, 100.0)]
        public decimal OralMark { get; set; }
        [Column("Total Mark")]
        [Range(0.0, 100.0)]
        public decimal TotalMark { get; set; }
        public bool Submitted { get; set; }
        [Column("Submitted Date")]
        public DateTime? SubmittedDate { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentID { get; set; }
        //public virtual Student Student { get; set; }
        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AssignmentID { get; set; }
        //public virtual Assignment Assignment { get; set; }

        public string ToString(Assignment assignment)
        {
            return $"Assignment: {assignment.Title}, Total Mark: {TotalMark}, Oral mark: {OralMark}";
        }
    }
}
