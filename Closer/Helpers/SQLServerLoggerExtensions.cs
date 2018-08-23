using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Closer.Helpers
{
    static public class SQLServerLoggerExtensions
    {
        public static ILoggerFactory AddSQLServerLogger(this ILoggerFactory factory,
        Func<string, LogLevel, bool> filter = null, string connectionStr = null)
        {
            factory.AddProvider(new SQLServerLoggerProvider(filter, connectionStr));
            return factory;
        }

        public static ILoggerFactory AddSQLServerLogger(this ILoggerFactory factory, LogLevel minLevel, string connectionStr)
        {
            return AddSQLServerLogger(
                factory,
                (_, logLevel) => logLevel >= minLevel, connectionStr);
        }
    }
}
