using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BicycleCheckList.Core
{
    class ServiceOptions
    {
        public static readonly JsonSerializerOptions jsonOptions = new JsonSerializerOptions { WriteIndented = true };

    }
}
