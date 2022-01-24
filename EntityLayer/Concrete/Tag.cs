using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Tag
    {
        public int TagId { get; set; }
        public string TagName { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        
    }
}
