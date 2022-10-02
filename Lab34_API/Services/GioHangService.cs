using Data.DatabaseContext;
using Data.DomainClass;
using Data.Repositories.Interfaces;

namespace Lab34_API.Services
{
    public class GioHangService
    {
        private readonly Lab34Context context;
        private readonly IRepositories<KhachHang> repositories;
        public GioHangService(IRepositories<KhachHang> repositories,
            Lab34Context context)
        {
            this.repositories = repositories;
            this.context = context;
        }

        public Task<IEnumerable<KhachHang>> GetAllSanPham() // Lấy tất
        {
            return repositories.GetAllAsync();
        }
        public Task<KhachHang> GetSanPhamByID(Guid id) // Lấy theo ID
        {
            return repositories.GetAsync(id);
        }
        public async Task<IEnumerable<KhachHang>> SearchSanphamByTen(string name)
        {
            var result = GetAllSanPham().Result.Where(c => c.Ten.Contains(name));
            return result.ToList();
        }

        public async Task<IEnumerable<KhachHang>> SearchSanphamKhoangGia(long min, long max)
        {
            var result = GetAllSanPham().Result;
            return result.ToList();
        }

        public bool AddNewSanpham(KhachHang khachHang)
        {
            try
            {
                repositories.AddOneAsyn(khachHang);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public bool AddListSanpham(IEnumerable<KhachHang> khachHangs)
        {
            try
            {
                repositories.AddManyAsyn(khachHangs);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool UpdateSanpham(KhachHang khachHang)
        {
            try
            {
                repositories.UpdateOneAsyn(khachHang);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public bool UpdateManySanpham(IEnumerable<KhachHang> khachHangs)
        {
            try
            {
                repositories.UpdateManyAsyn(khachHangs);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool UpdateTrangthaiSanpham(Guid id)
        {
            try
            {
                var sanpham = context.KhachHangs.Find(id);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool DeleteSanpham(Guid id)
        {
            try
            {
                var sanpham = repositories.GetAsync(id).Result;
                if (sanpham == null) return false;
                repositories.DeleteOneAsyn(sanpham);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteNhieuSanpham(IEnumerable<KhachHang> sanphams)
        {
            try
            {
                repositories.DeleteManyAsyn(sanphams);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
