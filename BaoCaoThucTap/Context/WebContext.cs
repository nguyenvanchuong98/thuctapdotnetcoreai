using BaoCaoThucTap.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace BaoCaoThucTap.Context
{
    public class WebContext:DbContext
    {
        public WebContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<SanPham> sanPhams { get; set; }
        public DbSet<AnhSanPham> anhSanPhams { get; set; }
    }
}
