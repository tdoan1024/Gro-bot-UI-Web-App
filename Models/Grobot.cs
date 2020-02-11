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
    
    public class Garden
    {
        public int gardenID { get; set; }
        public string gardenName { get; set; }
        public int plantTypeID { get; set; }
        public string plantTypeName { get; set; }
        public int featureID { get; set; }
        public string featureName { get; set; }
        public string Value { get; set; }
    }
}