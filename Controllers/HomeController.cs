using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NataliRecords.DB_Data;
using NataliRecords.Models;
using NataliRecords.Utility;
using System.Diagnostics;
using X.PagedList;



namespace NataliRecords.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _db;
        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }


        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();

        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //public IActionResult Records(int? page)
        //{
        //    return View(_db.Records.ToList().ToPagedList(page ?? 1, 9));
        //}


        //public IActionResult Subscribe()
        //{
        //    return View();
        //}
        //public IActionResult ContactUs()
        //{
        //    return View();
        //}


        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}


        //public ActionResult Detail(int? id)
        //{

        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var record = _db.Records.FirstOrDefault(c => c.Id == id);
        //    if (record == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(record);
        //}

        //POST product detail action method
        //[HttpPost]
        //[ActionName("Detail")]
        //public ActionResult RecordDetail(int? id)
        //{
        //    List<Record> records = new List<Record>();
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var record = _db.Records.FirstOrDefault(c => c.Id == id);
        //    if (record == null)
        //    {
        //        return NotFound();
        //    }

        //    records = HttpContext.Session.Get<List<Record>>("records");
        //    if (records == null)
        //    {
        //        records = new List<Record>();
        //    }
        //    records.Add(record);
        //    HttpContext.Session.Set("records", records);
        //    return RedirectToAction(nameof(Record));
        //}
        //GET Remove action methdo
        //[ActionName("Remove")]
        //public IActionResult RemoveToCart(int? id)
        //{
        //    List<Record> records = HttpContext.Session.Get<List<Record>>("Records");
        //    if (records != null)
        //    {
        //        var record = records.FirstOrDefault(c => c.Id == id);
        //        if (record != null)
        //        {
        //            records.Remove(record);
        //            HttpContext.Session.Set("records", records);
        //        }
        //    }
        //    return RedirectToAction(nameof(Cart));
        //}

        //[HttpPost]

        //public IActionResult Remove(int? id)
        //{
        //    List<Record> records = HttpContext.Session.Get<List<Record>>("records");
        //    if (records != null)
        //    {
        //        var record = records.FirstOrDefault(c => c.Id == id);
        //        if (record != null)
        //        {
        //            records.Remove(record);
        //            HttpContext.Session.Set("records", records);
        //        }
        //    }
        //    return RedirectToAction(nameof(Record));
        //}

        //GET product Cart action method

        //public IActionResult Cart()
        //{
        //    List<Record> records = HttpContext.Session.Get<List<Record>>("records");
        //    if (records == null)
        //    {
        //        records = new List<Record>();
        //    }
        //    return View(records);
        //}



        //public IActionResult Check()
        //{
        //    return View();
        //}
    }
}
