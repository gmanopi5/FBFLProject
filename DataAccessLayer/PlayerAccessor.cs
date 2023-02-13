using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using System.Data;
using System.Data.SqlClient;
using DataAccessInterFaces;

namespace DataAccessLayer
{
    public class PlayerAccessor : IPlayerAccessor
    {
        public List<Defense> SelectDefense()
        {
            List<Defense> defense = new List<Defense>();

            var connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            var cmdText = "sp_select_all_defenseteams";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var player = new Defense();
                        player.DefenseID = reader.GetInt32(0);
                        player.Team = reader.GetString(1);
                        defense.Add(player);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return defense;
        }

        public List<DefensiveLinemen> SelectDefensiveLinemen()
        {
            List<DefensiveLinemen> defensiveLinemen = new List<DefensiveLinemen>();

            var connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            var cmdText = "sp_select_all_defensivelinemen";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;


            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var player = new DefensiveLinemen();
                        player.DefensiveLinemenID = reader.GetInt32(0);
                        player.DLName = reader.GetString(1);
                        player.Team = reader.GetString(2);
                        player.Status = reader.GetString(3);
                        player.PlayerExp = reader.GetString(4);
                        player.College = reader.GetString(5);
                        defensiveLinemen.Add(player);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return defensiveLinemen;
        }

        public List<Kicker> SelectKickers()
        {
            List<Kicker> kickers = new List<Kicker>();

            var connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            var cmdText = "sp_select_all_kickers";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;


            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var player = new Kicker();
                        player.KickerID = reader.GetInt32(0);
                        player.KName = reader.GetString(1);
                        player.Team = reader.GetString(2);
                        player.Status = reader.GetString(3);
                        player.PlayerExp = reader.GetString(4);
                        player.College = reader.GetString(5);
                        kickers.Add(player);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return kickers;
        }

        public List<Linebacker> SelectLinebackers()
        {
            List<Linebacker> lineBackers = new List<Linebacker>();

            var connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            var cmdText = "sp_select_all_linebackers";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;


            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var player = new Linebacker();
                        player.LinebackerID = reader.GetInt32(0);
                        player.LBName = reader.GetString(1);
                        player.Team = reader.GetString(2);
                        player.Status = reader.GetString(3);
                        player.PlayerExp = reader.GetString(4);
                        player.College = reader.GetString(5);
                        lineBackers.Add(player);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return lineBackers;
        }

        public List<Quarterback> SelectQuarterBacks()
        {
            List<Quarterback> quarterBacks = new List<Quarterback>();

            var connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            var cmdText = "sp_select_all_quarterbacks";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var player = new Quarterback();
                        player.QuarterBackID = reader.GetInt32(0);
                        player.QBName = reader.GetString(1);
                        player.Team = reader.GetString(2);
                        player.Status = reader.GetString(3);
                        player.PlayerExp = reader.GetString(4);
                        player.College = reader.GetString(5);
                        quarterBacks.Add(player);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return quarterBacks;
        }

        public List<Runningback> SelectRunningBacks()
        {
            List<Runningback> runningBacks = new List<Runningback>();

            var connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            var cmdText = "sp_select_all_runningbacks";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;


            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var player = new Runningback();
                        player.RunningBackID = reader.GetInt32(0);
                        player.RBName = reader.GetString(1);
                        player.Team = reader.GetString(2);
                        player.Status = reader.GetString(3);
                        player.PlayerExp = reader.GetString(4);
                        player.College = reader.GetString(5);
                        runningBacks.Add(player);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return runningBacks;
        }

        public List<TideEnd> SelectTideEnds()
        {
            List<TideEnd> tideEnds = new List<TideEnd>();

            var connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            var cmdText = "sp_select_all_tideends";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;


            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var player = new TideEnd();
                        player.TideEndID = reader.GetInt32(0);
                        player.TEName = reader.GetString(1);
                        player.Team = reader.GetString(2);
                        player.Status = reader.GetString(3);
                        player.PlayerExp = reader.GetString(4);
                        player.College = reader.GetString(5);
                        tideEnds.Add(player);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return tideEnds;
        }

        public List<WideReceiver> SelectWideRecivers()
        {
            List<WideReceiver> wideRecivers = new List<WideReceiver>();

            var connectionFactory = new DBConnection();
            var conn = connectionFactory.GetDBConnection();

            var cmdText = "sp_select_all_widereceivers";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;


            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var player = new WideReceiver();
                        player.WideReceiverID = reader.GetInt32(0);
                        player.WRName = reader.GetString(1);
                        player.Team = reader.GetString(2);
                        player.Status = reader.GetString(3);
                        player.PlayerExp = reader.GetString(4);
                        player.College = reader.GetString(5);
                        wideRecivers.Add(player);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return wideRecivers;
        }
    }
}
