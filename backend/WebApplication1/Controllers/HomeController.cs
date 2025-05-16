using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;
using WpfApp1.Base.Entities;

namespace WebApplication1.Controllers
{
	public class HomeController : Controller
	{
		DatabaseContext db;

		public HomeController(DatabaseContext context)
		{
			this.db = context;
		}

		public IActionResult Index()
		{
			List<Room> rooms = db.Rooms.ToList();
			ViewBag.rooms = rooms;
			return View();
		}

		[HttpPost]
		public IActionResult RoomDetail(int room_id)
		{
			Room room = db.Rooms.First(r => r.Id == room_id);
			ViewBag.room = room;
			return View();
		}

		[HttpPost]
		public IActionResult CreateReserve(DetailViewModel model)
		{
			if (ModelState.IsValid)
			{
				var rand = new Random();
				string password = rand.Next(10000000, 99999999).ToString();

				db.Visitors.Add(new Visitor()
				{
					Name = model.Name,
					PhoneNumber = model.PhoneNumber,
					Password = password
				});
				db.SaveChanges();

				var Visitor = db.Visitors.First(v => v.PhoneNumber == model.PhoneNumber);

				db.Reserves.Add(new Reserve()
				{
					StartDate = model.InDate.ToString(),
					EndDate = model.OutDate.ToString(),
					RoomId = model.RoomId,
					VisitorId = Visitor.Id
				});
				db.SaveChanges();

				TempData["VisitorId"] = Visitor.Id;
				return RedirectToAction("Index");
			}
			return new NoContentResult();

		}

		[HttpGet]
		public IActionResult Reviews()
		{
			if (TempData["VisitorId"] != null)
			{
				Visitor visitor = db.Visitors.First(v => v.Id == (int)TempData["VisitorId"]);
				ViewBag.visitor = visitor;
			}

			List<Review> reviews = db.Reviews.ToList();
			List<Visitor> visitors = new List<Visitor>();

			foreach (Review review in reviews)
			{
				var vis = db.Visitors.FirstOrDefault(v => v.Id == review.VisitorId);
				visitors.Add(vis);
			}

			ViewBag.reviews = reviews;
			ViewBag.visitors = visitors;

			return View();
		}

		public IActionResult NewReview(ReviewModel model)
		{
			Review rev = new Review()
			{
				Rating = 5,
				ReviewText = model.ReviewText,
				VisitorId = model.VisitorId
			};
			db.Reviews.Add(rev);
			db.SaveChanges();

			TempData["VisitorId"] = model.VisitorId;
			return RedirectToAction("Reviews");
		}
	}
}
