using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [StringLength(25)]
        public string UserFirstName { get; set; }
        [StringLength(25)]
        public string UserLastName { get; set; }
        [StringLength(100)]
        public string UserMail { get; set; }
        [StringLength(20)]
        public string UserPassword { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Comment> Comments { get; set; }


    }
}
