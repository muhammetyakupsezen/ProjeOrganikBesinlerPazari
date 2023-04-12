using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YeniData
{
    public class TToken
    {
        public int KullaniciId { get; set; }
        public int KisiId { get; set; }
        public ulong Tc { get; set; }
        public DateTime ExpireMinute { get; set; }
        public Guid Guid { get; set; }

    }
}
