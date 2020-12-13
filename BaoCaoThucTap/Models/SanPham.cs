using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BaoCaoThucTap.Models
{
    public class SanPham
    {
        [Key]
        [DisplayName("Mã sản phẩm")]
        public int masp {get;set;}
        [Required(ErrorMessage ="Vui lòng nhập tên sản phẩm")]
        [DisplayName("Tên sản phẩm")]
        public string tensp { get; set; }
        [DisplayName("Ngày nhập")]
        public DateTime ngaynhap { get; set; }
        //[DisplayName("Ảnh sản phẩm")]
        //public string urlImage { get; set; }    
        [DisplayName("Giá")]
        public double giasp { get; set; }
        [DisplayName("Mô tả sp")]
        public string motasp { get; set; }
    }
}
