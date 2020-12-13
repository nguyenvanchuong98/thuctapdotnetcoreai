using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BaoCaoThucTap.Models
{
    public class AnhSanPham
    {
        [Key]
        public int maanh { get; set; }
        public string urlAnh { get; set; }
        public int masp { get; set; }
        [ForeignKey("masp")]
        public SanPham SanPham { get; set; }
    }
}
