using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Setting
    {
        [Key]
        public int SettingId { get; set; }

        [StringLength(50)]
        public string SettingName { get; set; }

        [StringLength(50)]
        public string SettingValue { get; set; }

    }
}
