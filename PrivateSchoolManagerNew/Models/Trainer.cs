using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrivateSchoolManagerNew.Models
{
    public class Trainer
    {
        [ForeignKey("User")]        
        public int ID { get; set; }
        [MaxLength(30)]
        [Required]
        public string FirstName { get; set; }
        [MaxLength(30)]
        [Required]
        public string LastName { get; set; }
        [MaxLength(40)]
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "No subject given")]
        public string Subject { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual User User { get; set; }

        public override string ToString()
        {
            return $"ID: {ID,3}, Name: {LastName} {FirstName}";
        }
    }
}
