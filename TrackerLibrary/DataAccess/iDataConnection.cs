using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    public interface iDataConnection
    {
        PrizeModel CreatePrize(PrizeModel model);
    }
}
