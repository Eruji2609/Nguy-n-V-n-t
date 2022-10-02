using Data.DomainClass;
using Data.Repositories.Interfaces;
using Lab34_API.Services;
using Microsoft.AspNetCore.Mvc;
using Data.DatabaseContext;
using Data.Repositories.Implementations;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lab34_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        // GET: api/<KhachHangController>
        [HttpGet]
        [Route("-get-all-khachHang")]
        public IEnumerable<KhachHang> Get()
        {
            /*GioHangService gioHangService = new GioHangService(new AllRepositories<KhachHang>() , new Lab34Context())*/
            ;
            List<SanPham> sanPhams = new List<SanPham>()
            {
                new SanPham(){Id = Guid.NewGuid(),Anh="123",Gia=1000000,MaSP="SP1",Ten="IPhone"},
                new SanPham(){Id = Guid.NewGuid(),Anh="123",Gia=2000000,MaSP="SP2",Ten="Oppo"},
                new SanPham(){Id = Guid.NewGuid(),Anh="123",Gia=3000000,MaSP="SP3",Ten="Samsung"},
                new SanPham(){Id = Guid.NewGuid(),Anh="123",Gia=4000000,MaSP="SP4",Ten="XiaoMi"},
                new SanPham(){Id = Guid.NewGuid(),Anh="123",Gia=5000000,MaSP="SP5",Ten="Nokia"}
            };
            List<KhachHang> khachHangs = new List<KhachHang>()
            {
                new KhachHang(){Id=Guid.NewGuid(),MaKH="KH1",Ten= "Tạ Duy Tùng",Sdt= "0976909517"},
                new KhachHang(){Id=Guid.NewGuid(),MaKH="KH2",Ten= "Phan Văn Ngọc",Sdt= "0976909517"},
                new KhachHang(){Id=Guid.NewGuid(),MaKH="KH3",Ten= "Trần Minh Quân",Sdt= "0976909517"},
                new KhachHang(){Id=Guid.NewGuid(),MaKH="KH4",Ten= "Nguyễn Thị Vân Anh",Sdt= "0976909517"},
                new KhachHang(){Id=Guid.NewGuid(),MaKH="KH5",Ten= "Trần THị Ánh Mây",Sdt= "0976909517"}
            };
            List<GioHangChiTiet> gioHangChiTiets = new List<GioHangChiTiet>()
            {
                new GioHangChiTiet(){KhachHangId=khachHangs[0].Id,SanPhamId=sanPhams[0].Id,SoLuong=1},
                new GioHangChiTiet(){KhachHangId=khachHangs[0].Id,SanPhamId=sanPhams[1].Id,SoLuong=3},
                new GioHangChiTiet(){KhachHangId=khachHangs[0].Id,SanPhamId=sanPhams[2].Id,SoLuong=4},
                new GioHangChiTiet(){KhachHangId=khachHangs[0].Id,SanPhamId=sanPhams[3].Id,SoLuong=5},
                new GioHangChiTiet(){KhachHangId=khachHangs[0].Id,SanPhamId=sanPhams[4].Id,SoLuong=6},
                new GioHangChiTiet(){KhachHangId=khachHangs[1].Id,SanPhamId=sanPhams[4].Id,SoLuong=7},
                new GioHangChiTiet(){KhachHangId=khachHangs[1].Id,SanPhamId=sanPhams[3].Id,SoLuong=8},
                new GioHangChiTiet(){KhachHangId=khachHangs[1].Id,SanPhamId=sanPhams[2].Id,SoLuong=9},
                new GioHangChiTiet(){KhachHangId=khachHangs[1].Id,SanPhamId=sanPhams[1].Id,SoLuong=10},
                new GioHangChiTiet(){KhachHangId=khachHangs[2].Id,SanPhamId=sanPhams[0].Id,SoLuong=5},
                new GioHangChiTiet(){KhachHangId=khachHangs[2].Id,SanPhamId=sanPhams[1].Id,SoLuong=4},
                new GioHangChiTiet(){KhachHangId=khachHangs[2].Id,SanPhamId=sanPhams[2].Id,SoLuong=3},
                new GioHangChiTiet(){KhachHangId=khachHangs[3].Id,SanPhamId=sanPhams[1].Id,SoLuong=2},
                new GioHangChiTiet(){KhachHangId=khachHangs[3].Id,SanPhamId=sanPhams[0].Id,SoLuong=1},
                new GioHangChiTiet(){KhachHangId=khachHangs[4].Id,SanPhamId=sanPhams[1].Id,SoLuong=7},
            };
            foreach (var x in khachHangs)
            {
                x.gioHangChiTiets = (from a in gioHangChiTiets
                                     where a.KhachHangId == x.Id
                                     join b in sanPhams on a.SanPhamId equals b.Id
                                     select new GioHangChiTiet()
                                     {
                                         KhachHangId = a.KhachHangId,
                                         SanPhamId = a.SanPhamId,
                                         SanPham = b,
                                         SoLuong = a.SoLuong
                                     }).ToList();
            }
            return khachHangs;
        }

        // GET api/<KhachHangController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<KhachHangController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<KhachHangController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<KhachHangController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
