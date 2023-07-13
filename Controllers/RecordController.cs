using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NataliRecords.DB_Data;
using NataliRecords.Models;
using NataliRecords.Filters;



namespace NataliRecords.Controllers
{
    public class RecordController : Controller
    {
        private ApplicationDbContext _db;

        public RecordController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Details (int? id)
        {
            if (id == null) 
            {
                return NotFound();
            }

            var record = _db.Records.FirstOrDefault(c => c.Id == id);

            if (record == null) 
            { 
                return NotFound(); 
            }
            return View(record);
        }


        [SimpleActionFilters]
        public IActionResult Index () 
        {
            IndexViewModel model = new IndexViewModel();
            model.Records= _db.Records.ToList();
            return View(_db.Records.ToList());
        }



        [HttpPost]
        public IActionResult Index (string name)
        {

            var records = _db.Records
                .Where(c => c.Name.Trim().Contains(name) || c.Title.Trim().Contains(name)).ToList();
            
            if (name==null)
            {
                records = _db.Records.ToList();
            }
            return View(records);

        }


        //Get Create method
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        //Post Create method
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Record record)
        {
            if (ModelState.IsValid)
            {
                //var searchProduct = _db.Products.FirstOrDefault(c => c.Name == product.Name);
                //if (searchProduct != null)
                //{
                //    ViewBag.message = "This product is already exist";
                //    return View(product);
                //}

                //if (image == null)
                //{
                //    product.ImageName = "Images/noimage.PNG";
                //}

                _db.Records.Add(record);
                _db.SaveChanges();
                //await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Update(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var record = _db.Records
                .FirstOrDefault(c => c.Id == id);
            if (record == null)
            {
                return NotFound();
            }
            return View(record);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Record record)
        {

            _db.Records.Update(record);
            await _db.SaveChangesAsync();
            return View(record);
        }




        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var record = _db.Records.FirstOrDefault(c => c.Id == id);
            _db.Records.Remove(record);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }



       
    }
}
