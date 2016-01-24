using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using IAI.Commands;
using IAI.CommandService;

namespace IAI.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ICommandService _commandService;

        public AccountController(ICommandService commandService)
        {
            _commandService = commandService;
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Authentication(LoginCommand command)
        {
            _commandService.Excute(command);
            return new HttpStatusCodeResult(200);
        }
    }
}