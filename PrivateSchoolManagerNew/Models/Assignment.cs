using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrivateSchoolManagerNew.Models
{
    public class Assignment
    {
        public int ID { get; set; }
        [MaxLength(30)]
        [Required]
        public string Title { get; set; }
        [MaxLength(50)]
        [DisplayFormat(NullDisplayText = "No description")]
        public string Description { get; set; }
        [Column("Submission Date")]
        public DateTime SubmissionDate { get; set; }

        [Required]
        public virtual Course Course { get; set; }
        public int CourseID { get; set; }

        public override string ToString()
        {
            return $"ID: {ID,3}, Title: {Title} for course {Course.Title}, Submission Date: {SubmissionDate: dd/MM/yyyy HH:mm:ss}";
        }

        public string ShowSubmissionDate()
        {
            return $"Title: {Title}, Submission Date: {SubmissionDate: dd/MM/yyyy HH:mm:ss}";
        }
    }
}
