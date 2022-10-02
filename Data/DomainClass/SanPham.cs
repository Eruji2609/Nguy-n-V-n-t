using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DomainClass
{
    public class SanPham
    {
        public Guid Id { get; set; }
        public string MaSP { get; set; }
        public string Ten { get; set; }
        public decimal Gia { get; set; }
        public string Anh { get; set; }
        public IEnumerable<GioHangChiTiet> gioHangChiTiets { get; set; }

    }
}
