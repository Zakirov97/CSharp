using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpWeekFourCompleted.YourCode
{
    public enum DayPart
    {
        Morning, // 06 - 12
        Midday,  // 12 - 18
        Evening, // 18 - 22
        Night // 22 - 06
    }
    public class ReportManager
    {
        public Dictionary<DayPart, int> GetActiveUserStatisticPerDayTime()
        {
            return null;
        }
        public Dictionary<DayPart, int> GetActiveUserStatisticPerDayTime(string userId)
        {
            return null;
        }

        public Dictionary<string, int> GetNumberOfMessagesSent(DateTime startPeriod, DateTime finishPeriod, string userId)
        {
            return null;
        }

        public Dictionary<string, int> GetNumberOfMessagesSent(string userId)
        {
            return null;
        }

        public List<string> RecommendUsersToFriendBasedOnLocation(string userId)
        {
            return null;
        }
    }
}
