using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class PatchOfLand : AbstractZone
    {
        public PatchOfLand(Location location) : base(location)
        {
        }

        public override bool TrySetContent(IZoneContent content)
        {
            throw new NotImplementedException();
        }
    }
}
