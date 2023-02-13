using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessInterFaces
{
    public interface IPlayerAccessor
    {
        List<Quarterback> SelectQuarterBacks();
        List<Defense> SelectDefense();
        List<DefensiveLinemen> SelectDefensiveLinemen();
        List<Kicker> SelectKickers();
        List<Linebacker> SelectLinebackers();
        List<Runningback> SelectRunningBacks();
        List<TideEnd> SelectTideEnds();
        List<WideReceiver> SelectWideRecivers();
    }
}
