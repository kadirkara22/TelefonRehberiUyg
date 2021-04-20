using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Entities
{
   public class Kulllanici
    {
        public Guid KullaniciID { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string SifreTekrar { get; set; }
        public string Soru { get; set; }
        public string Cevap { get; set; }


    }
}
