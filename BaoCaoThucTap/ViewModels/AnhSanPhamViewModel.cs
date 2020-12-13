using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BaoCaoThucTap.ViewModels
{
    public class AnhSanPhamViewModel
    {
        public int maanh { get; set; }
        public string urlAnh { get; set; }
        public int masp { get; set; }
        [DisplayName("Các ảnh sản phẩm")]
        public IFormFile[] FileAnh { get; set; }
        public List<SanPhamViewModel> SanPhamModel { get; set; }
    }
}
