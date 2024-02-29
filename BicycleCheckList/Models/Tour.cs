using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleCheckList.Models
{
    public class Tour
    {
        public required string Name { get;  set; }
        public DateTime? From { get; private set; }
        public DateTime? To { get; private set; }
        public required List<CheckItem> CheckItems { get; set; }
    }
}
