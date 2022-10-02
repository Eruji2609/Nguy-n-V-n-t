using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DomainClass
{
    public class GioHangChiTiet
    {
        public Guid SanPhamId { get; set; }
        public SanPham SanPham { get; set; }
        public Guid KhachHangId { get; set; }
        public KhachHang KhachHang { get; set; }
        public int SoLuong { get;set; } 
    }
}
