using Closer.DataService.EF;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Closer.Helpers
{
    public class SQLServerLoggerProvider : ILoggerProvider
    {
        string _connectionString;

        public SQLServerLoggerProvider(string conString)
        {
            _connectionString = conString;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new SQLServerLogger(_connectionString);
        }

        public void Dispose()
        {
        }
    }
}
