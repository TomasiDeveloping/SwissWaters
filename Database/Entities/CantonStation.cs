using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities
{
    public class CantonStation
    {
        public Guid StationId { get; set; }
        public Station Station { get; set; }

        public Guid CantonId { get; set; }
        public Canton Canton { get; set; }
    }
}
