using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace JianJian.EasyRedis.Base.Interface
{
    /// <summary>
    /// Redis database provider.
    /// </summary>
    public interface IRedisDatabaseProvider
    {
        /// <summary>
        /// Gets the database.
        /// </summary>
        /// <returns>The database.</returns>
        IDatabase GetDatabase();

        /// <summary>
        /// Gets the server list.
        /// </summary>
        /// <returns>The server list.</returns>
        IEnumerable<IServer> GetServerList();

        ConnectionMultiplexer GetConnectionMultiplexer();
    }
}
