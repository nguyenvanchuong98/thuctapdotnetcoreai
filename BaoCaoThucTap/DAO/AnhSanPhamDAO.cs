using BaoCaoThucTap.Context;
using BaoCaoThucTap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaoCaoThucTap.DAO
{
    public class AnhSanPhamDAO
    {
        WebContext db;
        public AnhSanPhamDAO(WebContext _db)
        {
            db = _db;
        }

        public AnhSanPhamDAO()
        {
        }

        public List<AnhSanPham> ListAllAnh()
        {
            List<AnhSanPham> ls = new List<AnhSanPham>();
            ls = db.anhSanPhams.ToList();
            return ls;
        }
        public List<AnhSanPham> FindAnh(int id)
        {
            return db.anhSanPhams.Where(x=>x.masp.Equals(id)).ToList();
        }
        public string FindFirstAnh(int id)
        {
            return db.anhSanPhams.FirstOrDefault(x=>x.masp==id).urlAnh;
        }
    }
}
