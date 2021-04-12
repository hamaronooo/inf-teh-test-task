﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using InfTeh_test.DataContexts;
using InfTeh_test.Models;
using InfTeh_test.Models.DataContext;

namespace InfTeh_test.Controllers
{
    public class NavigationController : Controller
    {
        DataContext dc = new DataContext();
        public ActionResult GetChildren(int? parentFolderid)
        {
            NavigationModel model = new NavigationModel();

            if (parentFolderid != null)
            {
                model.ParentFolder = dc.Folders.FirstOrDefault(m => m.folderid == parentFolderid);
                model.Folders = dc.Folders.Where(m => m.parent_folderid == parentFolderid);
            }
            else
            {
                model.ParentFolder = new Folder(){ folderid = 0 };
                model.Folders = dc.Folders.Where(m => m.parent_folderid == null);
            }
            
            model.Files = dc.Files
                .Where(m => m.folderid == parentFolderid)
                .Include(m=>m.FileExtension);

            return PartialView("NavigationBlock", model);
        }
    }
}