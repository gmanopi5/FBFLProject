using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataObjects;
using DataAccessLayer;

namespace LogicLayerInterfaces
{
    public interface IPlayerManager
    {
        List<Quarterback> RetrieveQuarterBacks();
        List<Defense> RetrieveDefense();
        List<DefensiveLinemen> RetrieveDefensiveLinemen();
        List<Kicker> RetrieveKickers();
        List<Linebacker> RetrieveLinebackers();
        List<Runningback> RetrieveRunningBacks();
        List<TideEnd> RetrieveTideEnds();
        List<WideReceiver> RetrieveWideRecivers();
    }
}
