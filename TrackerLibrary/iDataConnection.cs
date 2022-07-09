using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public interface iDataConnection
    {
        PrizeModel CreatePrize(PrizeModel model);
    }
}
