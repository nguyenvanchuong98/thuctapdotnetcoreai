using BaoCaoThucTap.Context;
using BaoCaoThucTap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaoCaoThucTap.DAO
{
    public class SanPhamDAO
    {
        WebContext db;
        public SanPhamDAO(WebContext _db)
        {
            db = _db;
        }

        public List<SanPham> ListAllSp()
        {
            return db.sanPhams.ToList();
        }
    }
}
