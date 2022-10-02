using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DomainClass
{
    public class KhachHang
    {
        public Guid Id { get; set; }
        public string MaKH { get; set; }
        public string Ten { get; set; }
        public string Sdt { get; set; }
        public IEnumerable<GioHangChiTiet> gioHangChiTiets { get; set; }
    }
}
