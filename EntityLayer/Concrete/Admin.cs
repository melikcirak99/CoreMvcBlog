using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        [StringLength(50)]
        public string AdminFirstName { get; set; }
        [StringLength(50)]
        public string AdminLastName { get; set; }
        [StringLength(150)]
        public string AdminMail { get; set; }
        [StringLength(25)]
        public string AdminPassword { get; set; }
    }
}
