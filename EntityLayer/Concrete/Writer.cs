using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Writer
    {
        [Key]
        public int WriterId { get; set; }
        [StringLength(25)]
        public string WriterFirstName { get; set; }
        [StringLength(25)]
        public string WriterLastName { get; set; }
        [StringLength(100)]
        public string WriterMail { get; set; }
        [StringLength(25)]
        public string WriterPassword { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Post> Posts { get; set; }

    }
}
