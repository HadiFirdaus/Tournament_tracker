using TrackerLibrary.DataAccess;
using System.Collections.Generic;

namespace TrackerLibrary
{
    public static class GlobalConfig
    {
        public static List<IDataConnection> Connections { get; private set; } = new List<IDataConnection>();

        public static void InitializeConnection(bool database, bool textFiles)
        {
            if (database)
            {
                // TODO - set the sql connector properly
                SqlConnector Sql = new SqlConnector();
                Connections.Add(Sql);
            }
            if (textFiles)
            {
                // TODO - create text file connection
                TextConnectors textfile = new TextConnectors();
                Connections.Add(textfile);
            }
        }
    }
}
