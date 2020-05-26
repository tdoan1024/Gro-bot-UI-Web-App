using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gro_bot.Models
{
    public class PlantType
    {
        public List<object> _PlantTypeList { get; set; }
    }
    
    public class waterDay
    {
        public int wDay { get; set; }
    }

    public class today
    {
        public int? currentDay { get; set; }
        public int? currentTime { get; set; }
    }
    public class fertilizingDay
    {
        public int fDay { get; set; }
    }

    public class scheduleObject
    {
        public List<int> waterDay { get; set; }
        public List<int> ferDay { get; set; }
        public int waterTime { get; set; }
        public int ferTime { get; set; }

    }
    public class Garden
    {
        public List<PlantTypeObj> _PlantTypeList { get; set; }
        public int gardenID { get; set; }
        public string gardenName { get; set; }
        public int plantTypeID { get; set; }
        public string plantTypeName { get; set; }
        public string plantTypeCycle { get; set; }
        public string plantTypeRecWaterSchedule { get; set; }
        public string plantTypeRecFertSchedule { get; set; }

        public int featureID { get; set; }
        public string featureName { get; set; }
        public string Value { get; set; }
        public string StartDate { get; set; }

    }

    public class ExistingGarden
    {
        public int? gardenID { get; set; }
        public string gardenName { get; set; }
        public int plantTypeID { get; set; }
        public string plantTypeName { get; set; }
        public string plantTypeCycle { get; set; }
        public int? currentDay { get; set; }
        public double progress { get; set; }
        public int light { get; set; }
        public int moisture { get; set; }
        public int temperature { get; set; }
        public int? lowestTemp { get; set; }
        public int? highestTemp { get; set; }
        public string lowestMoisture { get; set; }
        public string highestMoisture { get; set; }
    }

    public class PlantTypeObj
    {
        public int plantTypeID { get; set; }
        public string plantTypeName { get; set; }
        public int? plantTypeCycle { get; set; }
    }

    public class FeatureObj
    {
        public int temp { get; set; }
        public int moisture { get; set; }
        public int light { get; set; }
    }
    public class PlantTypeList
    {
        public List<PlantTypeObj> _PlantTypeList { get; set; }
    }
}