﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InfTeh_test.Controllers
{
    public class ModalController : Controller
    {
        public ActionResult GetModal()
        {
            return PartialView("_PartialModal");
        }
    }
}