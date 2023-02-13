using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessInterFaces;

namespace DataAccessFakes
{
    public class PlayerAccessorFake : IPlayerAccessor
    {
        List<Defense> defense = new List<Defense>();
        List<DefensiveLinemen> defensiveLinemen = new List<DefensiveLinemen>();
        List<Kicker> kickers = new List<Kicker>();
        List<Linebacker> lineBackers = new List<Linebacker>();
        List<Quarterback> quarterBacks = new List<Quarterback>();
        List<Runningback> runningBacks = new List<Runningback>();
        List<TideEnd> tideEnds = new List<TideEnd>();
        List<WideReceiver> wideRecivers = new List<WideReceiver>();


        public PlayerAccessorFake()
        {
            defense.Add(new Defense
            {
                DefenseID = 999998,
                Team = "Bears"
            });
            defensiveLinemen.Add(new DefensiveLinemen
            {
                DefensiveLinemenID = 999997,
                DLName = "Test Player",
                Team = "Bears",
                Status = "Active",
                PlayerExp = "R",
                College = "University of Iowa"
            });
            kickers.Add(new Kicker
            {
                KickerID = 999996,
                KName = "Test Player",
                Team = "Bears",
                Status = "Active",
                PlayerExp = "R",
                College = "University of Iowa"
            });
            lineBackers.Add(new Linebacker
            {
                LinebackerID = 999995,
                LBName = "Test Player",
                Team = "Bears",
                Status = "Active",
                PlayerExp = "R",
                College = "University of Iowa"
            });
            quarterBacks.Add(new Quarterback
            {
                QuarterBackID = 999994,
                QBName = "Test Player",
                Team = "Bears",
                Status = "Active",
                PlayerExp = "R",
                College = "University of Iowa"
            });
            runningBacks.Add(new Runningback
            {
                RunningBackID = 999993,
                RBName = "Test Player",
                Team = "Bears",
                Status = "Active",
                PlayerExp = "R",
                College = "University of Iowa"
            });
            tideEnds.Add(new TideEnd
            {
                TideEndID = 999992,
                TEName = "Test Player",
                Team = "Bears",
                Status = "Active",
                PlayerExp = "R",
                College = "University of Iowa"
            });
            wideRecivers.Add(new WideReceiver
            {
                WideReceiverID = 999991,
                WRName = "Test Player",
                Team = "Bears",
                Status = "Active",
                PlayerExp = "R",
                College = "University of Iowa"
            });
        }

        public List<Defense> SelectDefense()
        {
            return defense.ToList();
        }

        public List<DefensiveLinemen> SelectDefensiveLinemen()
        {
            return defensiveLinemen.ToList();
        }

        public List<Kicker> SelectKickers()
        {
            return kickers.ToList();
        }

        public List<Linebacker> SelectLinebackers()
        {
            return lineBackers.ToList();
        }

        public List<Quarterback> SelectQuarterBacks()
        {
            return quarterBacks.ToList();
        }

        public List<Runningback> SelectRunningBacks()
        {
            return runningBacks.ToList();
        }

        public List<TideEnd> SelectTideEnds()
        {
            return tideEnds.ToList();
        }

        public List<WideReceiver> SelectWideRecivers()
        {
            return wideRecivers.ToList();
        }
    }
}
