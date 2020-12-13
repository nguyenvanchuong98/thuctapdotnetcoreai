using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BaoCaoThucTap.Context;
using BaoCaoThucTap.Models;
using BaoCaoThucTap.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using BaoCaoThucTap.DAO;

namespace BaoCaoThucTap.Controllers
{
    public class SanPhamsController : Controller
    {
        private readonly WebContext _context;
        private readonly IWebHostEnvironment _webHotEnviroment;
        public SanPhamsController(WebContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _webHotEnviroment = hostEnvironment;
        }
        // GET: SanPhams
        public async Task<IActionResult> Index()
        {
            List<string> dsurlanh = new List<string>(); 
            List<SanPham> dssp = new List<SanPham>();
            dssp = await _context.sanPhams.ToListAsync();
            foreach(var a in dssp)
            {
                dsurlanh.Add(_context.anhSanPhams.FirstOrDefault(x => x.masp == a.masp).urlAnh);
            }
            ViewBag.dsanh = dsurlanh ;
            //return View(await _context.sanPhams.ToListAsync());
            return View(dssp);
        }
        //[HttpPost]
        //public async Task<IActionResult> Index(SanPham sp)
        //{
        //    ViewBag.anhspview = new AnhSanPhamDAO().FindFirt(sp.masp);
        //    return View();
        //}
        // GET: SanPhams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            List<AnhSanPham> lstanhsp = new List<AnhSanPham>();
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.sanPhams
                .FirstOrDefaultAsync(m => m.masp == id);
            if (sanPham == null)
            {
                return NotFound();
            }
            lstanhsp=_context.anhSanPhams.Where(u=>u.masp==id).ToList();
            ViewBag.lstanhsp = lstanhsp;
            return View(sanPham);
        }
        private List<string> UploadedFile(IFormFile[] filedata)
        {
            List<string> uniqueFileName=new List<string>();

            if (filedata != null)
            {
                int i = 0;
                foreach(var item in filedata )
                {
                    string uploadsFolder = Path.Combine(_webHotEnviroment.WebRootPath, "images");
                    uniqueFileName.Add(Guid.NewGuid().ToString() + "_" + item.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName[i]);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                       item.CopyTo(fileStream);
                    }
                    i++;
                    
                    //var file = Path.Combine(_webHotEnviroment.WebRootPath, "images",item.FileName);
                    //using (var fileStream = new FileStream(file, FileMode.Create))
                    //{
                    //    item.CopyTo(fileStream);
                    //}
                    //uniqueFileName.Add(/*Guid.NewGuid().ToString() + "_" +*/ item.FileName);
                    //i++;
                }    
            }
            return uniqueFileName;
        }
        // GET: SanPhams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SanPhamViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.urlAnh = UploadedFile(model.FileAnh);
                SanPham sp = new SanPham
                {
                    tensp = model.tensp,
                    ngaynhap = DateTime.Now,
                    giasp = model.giasp,
                    motasp = model.motasp
                };
                _context.Add(sp);
                await _context.SaveChangesAsync();
                foreach (string item in model.urlAnh)
                {
                    AnhSanPham anhsp = new AnhSanPham
                    {
                        masp = sp.masp,
                        urlAnh=item,
                    };
                    _context.Add(anhsp);
                    await _context.SaveChangesAsync();
                }    
                
                return RedirectToAction(nameof(Create));
            }
            return View();
        }


        // GET: SanPhams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sanPham = await _context.sanPhams.FindAsync(id);
            if (sanPham == null)
            {
                return NotFound();
            }
            SanPhamViewModel model = new SanPhamViewModel
            {
                masp=sanPham.masp,
                tensp=sanPham.tensp,
                ngaynhap=sanPham.ngaynhap,
                giasp=sanPham.giasp,
                motasp=sanPham.motasp,
            };
            return View(model);
        }

        // POST: SanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SanPhamViewModel model)
        {
            if (_context.sanPhams.FirstOrDefault(d=>d.masp.Equals(model.masp))==null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                SanPham sp = await _context.sanPhams.FindAsync(model.masp);
                try
                {
                    sp.tensp = model.tensp;
                    sp.ngaynhap = model.ngaynhap;
                    //if (model.productImage != null)
                    //    sp.urlImage = UploadedFile(model);
                    //else
                    //    sp.urlImage = model.urlImage;
                    sp.giasp = model.giasp;
                    sp.motasp = model.motasp;
                    _context.Update(sp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanPhamExists(sp.masp))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: SanPhams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.sanPhams
                .FirstOrDefaultAsync(m => m.masp == id);
            if (sanPham == null)
            {
                return NotFound();
            }
            _context.sanPhams.Remove(sanPham);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: SanPhams/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var sanPham = await _context.sanPhams.FindAsync(id);
        //    _context.sanPhams.Remove(sanPham);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool SanPhamExists(int id)
        {
            return _context.sanPhams.Any(e => e.masp == id);
        }
    }
}
