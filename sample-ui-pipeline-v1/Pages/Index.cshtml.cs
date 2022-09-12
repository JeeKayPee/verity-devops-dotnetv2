using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using sample_ui_pipeline_v1.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sample_ui_pipeline_v1.Pages
{
	
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;

		public IndexModel(ILogger<IndexModel> logger)
		{
			_logger = logger;
		}

		public void OnGet()
		{
			Response.Headers.Add("Access-Control-Allow-Credentials", "false");

			/** Sonar Vulnerability*/
			//Response.Headers.Add("Access-Control-Allow-Origin", "*");
		}
	}
}
