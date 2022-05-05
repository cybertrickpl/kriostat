﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace kriostat.pl.Pages
{
    public class LogInModel : PageModel
    {
        private readonly ILogger<LogInModel> _logger;

        public LogInModel(ILogger<LogInModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}