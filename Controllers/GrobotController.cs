using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Firebase.Database;
using Firebase.Database.Query;
using System.Threading.Tasks;
using Gro_bot.Models;

namespace Gro_bot.Controllers
{
    public class GrobotController : Controller
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public ActionResult CreateGarden()
        {
            var myModel = TempData["myModel"] as Garden ?? new Garden
            {

            };

            var myPlant = (from t in db.PlantTypes
                               select new Garden
                               {
                                   plantTypeID = t.typeID,
                                   plantTypeName = t.typeName,


                               });

            return View(myModel);
        }

        public ActionResult ManageGarden()
        {
            var myModel = TempData["myModel"] as Garden ?? new Garden
            {

            };

            return View(myModel);
        }
    }
}
