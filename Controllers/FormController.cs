﻿using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using SeminarieEnquete.Models;
using System.Threading.Tasks;

namespace SeminarieEnquete.Controllers
{
	[Route("api/forms")]
	public class FormController : Controller
	{
		private IMongoCollection<Form> _formsColl = DbConnection.Db.GetCollection<Form>("forms");

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var forms = await _formsColl.Find(f => true).ToListAsync();

			return Json(forms);
		}

		[HttpPost]
		public async Task PostForm([FromBody]Form data)
		{
			await _formsColl.InsertOneAsync(data);
		}
	}
}
