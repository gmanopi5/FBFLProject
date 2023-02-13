using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class Player
    {
        public int QuarterBackID { get; set; }
        public string QBName { get; set; }
        public int DefenseID { get; set; }
        public int DefensiveLinemenID { get; set; }
        public string DLName { get; set; }
        public int KickerID { get; set; }
        public string KName { get; set; }
        public int LinebackerID { get; set; }
        public string LBName { get; set; }
        public int RunningBackID { get; set; }
        public string RBName { get; set; }
        public int TideEndID { get; set; }
        public string TEName { get; set; }
        public int WideReceiverID { get; set; }
        public string WRName { get; set; }
        public string Team { get; set; }
        public string Status { get; set; }
        public string PlayerExp { get; set; }
        public string College { get; set; }
    }

    public class Defense
    {
        public int DefenseID { get; set; }

        public string Team { get; set; }
    }

    public class DefensiveLinemen
    {
        public int DefensiveLinemenID { get; set; }
        public string DLName { get; set; }
        public string Team { get; set; }
        public string Status { get; set; }
        public string PlayerExp { get; set; }
        public string College { get; set; }
    }

    public class Kicker
    {
        public int KickerID { get; set; }
        public string KName { get; set; }
        public string Team { get; set; }
        public string Status { get; set; }
        public string PlayerExp { get; set; }
        public string College { get; set; }
    }

    public class Linebacker
    {
        public int LinebackerID { get; set; }
        public string LBName { get; set; }
        public string Team { get; set; }
        public string Status { get; set; }
        public string PlayerExp { get; set; }
        public string College { get; set; }
    }

    public class Quarterback
    {
        public int QuarterBackID { get; set; }
        public string QBName { get; set; }
        public string Team { get; set; }
        public string Status { get; set; }
        public string PlayerExp { get; set; }
        public string College { get; set; }
    }

    public class Runningback
    {
        public int RunningBackID { get; set; }
        public string RBName { get; set; }
        public string Team { get; set; }
        public string Status { get; set; }
        public string PlayerExp { get; set; }
        public string College { get; set; }
    }

    public class TideEnd
    {
        public int TideEndID { get; set; }
        public string TEName { get; set; }
        public string Team { get; set; }
        public string Status { get; set; }
        public string PlayerExp { get; set; }
        public string College { get; set; }
    }

    public class WideReceiver
    {
        public int WideReceiverID { get; set; }
        public string WRName { get; set; }
        public string Team { get; set; }
        public string Status { get; set; }
        public string PlayerExp { get; set; }
        public string College { get; set; }
    }
}
