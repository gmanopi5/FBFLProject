using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using LogicLayerInterfaces;
using DataAccessInterFaces;

namespace LogicLayer
{
    public class PlayerManager : IPlayerManager
    {
        private IPlayerAccessor _playerAccessor = null;

        public PlayerManager()
        {
            _playerAccessor = new DataAccessLayer.PlayerAccessor();
        }

        public PlayerManager(IPlayerAccessor playerAccessor)
        {
            _playerAccessor = playerAccessor;
        }

        public List<Defense> RetrieveDefense()
        {
            List<Defense> defense = null;

            try
            {
                defense = _playerAccessor.SelectDefense();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }

            return defense;
        }

        public List<DefensiveLinemen> RetrieveDefensiveLinemen()
        {
            List<DefensiveLinemen> defensiveLinemen = null;

            try
            {
                defensiveLinemen = _playerAccessor.SelectDefensiveLinemen();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }

            return defensiveLinemen;
        }

        public List<Kicker> RetrieveKickers()
        {
            List<Kicker> kickers = null;

            try
            {
                kickers = _playerAccessor.SelectKickers();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }

            return kickers;
        }

        public List<Linebacker> RetrieveLinebackers()
        {
            List<Linebacker> linebackers = null;

            try
            {
                linebackers = _playerAccessor.SelectLinebackers();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }

            return linebackers;
        }

        public List<Quarterback> RetrieveQuarterBacks()
        {
            List<Quarterback> quarterBacks = null;

            try
            {
                quarterBacks = _playerAccessor.SelectQuarterBacks();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }

            return quarterBacks;
        }

        public List<Runningback> RetrieveRunningBacks()
        {
            List<Runningback> runningBacks = null;

            try
            {
                runningBacks = _playerAccessor.SelectRunningBacks();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }

            return runningBacks;
        }

        public List<TideEnd> RetrieveTideEnds()
        {
            List<TideEnd> tideEnds = null;

            try
            {
                tideEnds = _playerAccessor.SelectTideEnds();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }

            return tideEnds;
        }

        public List<WideReceiver> RetrieveWideRecivers()
        {
            List<WideReceiver> wideRecivers = null;

            try
            {
                wideRecivers = _playerAccessor.SelectWideRecivers();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }

            return wideRecivers;
        }
    }
}
