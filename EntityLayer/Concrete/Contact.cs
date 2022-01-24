using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        [StringLength(25)]
        public string ContactName { get; set; }
        [StringLength(50)]
        public string ContactMail { get; set; }
        [StringLength(250)]
        public string ContactMessage { get; set; }
        public bool IsRead { get; set; }

    }
}
