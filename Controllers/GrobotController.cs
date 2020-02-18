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
        public ActionResult CreateGarden(string plantTypeID = null)
        {
            var myModel = TempData["myModel"] as Garden ?? new Garden
            {

            };

            var myTypes = (from t in db.PlantTypes
                               select new PlantTypeObj
                               {
                                   plantTypeID = t.typeID,
                                   plantTypeName = t.typeName,
                                   plantTypeCycle = t.cycle
                               }).ToList();
            if (myTypes.Any())
            {
                myModel._PlantTypeList = myTypes;
            }

            if (plantTypeID != null && plantTypeID != "" && plantTypeID != "0" && plantTypeID != "null")
            {
                int myPlantTypeID;
                bool result = Int32.TryParse(plantTypeID, out myPlantTypeID);
                if (result)
                {
                    var myCycle = (from t in db.PlantTypes
                                   where t.typeID == myPlantTypeID
                                   select t.cycle).First().ToString();
                    var myRecWaterSchedule = (from t in db.PlantTypes
                                   where t.typeID == myPlantTypeID
                                   select t.recWaterPerDay).First().ToString();
                    var myRecFertSchedule = (from t in db.PlantTypes
                                   where t.typeID == myPlantTypeID
                                   select t.recFertilizerPerMonth).First().ToString();

                    myModel.plantTypeCycle = myCycle;
                    myModel.plantTypeRecWaterSchedule = myRecWaterSchedule;
                    myModel.plantTypeRecFertSchedule = myRecFertSchedule;
                }
            }

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
