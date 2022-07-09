using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public static class GlobalConfig
    {
        public static List<iDataConnection> Connections { get; private set; } = new List<iDataConnection>();

        public static void InitializeConnections(bool database, bool textfiles)
        {
            if (database)
            {
                // feature
                SqlConnector sql = new SqlConnector();
                Connections.Add(sql);
            }
            if (textfiles)
            {
                // feature
                TextConnector text = new TextConnector();
                Connections.Add(text);
            }
        }
    }
}
