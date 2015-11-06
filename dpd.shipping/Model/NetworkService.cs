using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dpd.shipping.Model
{
    //TODO. Handle all service types
    public enum NetworkService
    {
        [Description("1^12")]
        DPDNextDay = 0,
        [Description("1^19")]
        EuropeanRoad = 1,
        [Description("1^60")]
        AirClassic = 2
    }
}
