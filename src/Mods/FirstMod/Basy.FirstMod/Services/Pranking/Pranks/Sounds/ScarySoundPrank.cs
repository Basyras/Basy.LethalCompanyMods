using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasyFirstMod.Services.Pranking.Pranks.Sounds
{
    public class ScarySoundPrank : PrankBase
    {
        public override void Start()
        {
            BasySoundManager.Instance.PlaySoundAsync(1);
            base.Start();
        }
    }
}
