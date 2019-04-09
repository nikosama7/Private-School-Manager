using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrivateSchoolManagerNew.Models
{
    public enum Role
    {
        Student = 1,
        Trainer,
        HeadMaster
    }

    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [MaxLength(30)]
        [Index(IsUnique = true)]
        public string Username { get; set; }
        [MaxLength(70)]
        [MinLength(8)]
        public string Password { get; set; }
        public Role Role { get; set; }

        public virtual Student Student { get; set; }
        public virtual Trainer Trainer { get; set; }

        public override string ToString()
        {
            return $"ID: {ID,3}, Username: {Username}, Role: {Role}";
        }

    }
}
