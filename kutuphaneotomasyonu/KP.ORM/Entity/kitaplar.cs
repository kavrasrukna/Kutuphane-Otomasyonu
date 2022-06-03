using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KP.ORM.Entity
{
    public class kitaplar
    {
        public int kitapno { get; set; }
        public string kitapadi { get; set; }
        public string yazaradi { get; set; }
        public string tür { get; set; }
        public int kitapsayfasayisi { get; set; }
        public string kitapbasimyili { get; set; }
        public string kitapyayinevi { get; set; }
        public int kitapadet { get; set; }
    }
}
