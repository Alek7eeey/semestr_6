﻿using Microsoft.AspNetCore.Mvc;

namespace Lab_2b.Controllers
{
	public class MResearchController : Controller
	{
		[HttpGet, Route("/MView", Order = 2)]
		public IActionResult MView()
		{
			return View();
		}
		public IActionResult M01(string? str)
		{
			return Ok($"GET:M01 {(str is not null ? $"| string - {str}" : "")}");
		}

		public IActionResult M02(string? str)
		{
			return Ok($"GET:M02 {(str is not null ? $"| string - {str}" : "")}");
		}

		public IActionResult M03(string? str)
		{
			return Ok($"GET:M03 {(str is not null ? $"| string - {str}" : "")}");
		}

		public IActionResult MXX()
		{
			return Ok("GET:MXX");
		}

	}
}
