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
            var myModel = TempData["myModel"] as ExistingGarden ?? new ExistingGarden
            {
                
            };

            var myGarden = (from g in db.GardenBeds
                            select g).FirstOrDefault();

            myModel.gardenID = myGarden.bedID;
            myModel.gardenName = myGarden.bedName;

            var myFeedback = (from f in db.BedFeedbackValues
                              where f.bedID == myGarden.bedID
                              select f).FirstOrDefault();

            myModel.light = myFeedback.light;
            myModel.moisture = myFeedback.moisture;
            myModel.temperature = myFeedback.temperature;
            myModel.currentDay = myFeedback.currentDay;

            var myThreshold = (from t in db.PlantTypes
                               where t.typeID == myGarden.typeID
                               select t).FirstOrDefault();

            myModel.plantTypeID = myThreshold.typeID;
            myModel.plantTypeName = myThreshold.typeName;
            myModel.plantTypeCycle = myThreshold.cycle.ToString();
            myModel.highestTemp = myThreshold.highestTemp;
            myModel.lowestTemp = myThreshold.lowestTemp;
            myModel.highestMoisture = myThreshold.highestMoisture;
            myModel.lowestMoisture = myThreshold.lowestMoisture;

            myModel.progress = Convert.ToDouble((myModel.currentDay*100)/Convert.ToInt32(myModel.plantTypeCycle));

            return View(myModel);
        }
    }
}
