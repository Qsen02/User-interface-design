using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_project
{
    public class WeatherModel
    {
        public string Address { get; set; }
        public string Description { get; set; }
        public Dictionary<string,object> currentConditions { get; set; }
    }
}
