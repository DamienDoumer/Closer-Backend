using Closer.DataService.EF;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Closer.Helpers
{
    public class MyLoggerProvider : ILoggerProvider
    {
        private readonly ConcurrentDictionary<string, SQLServerLogger> _loggers = new ConcurrentDictionary<string, SQLServerLogger>();
        CloserContext _context;

        public MyLoggerProvider(CloserContext context)
        {
            _context = context;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, name => new SQLServerLogger(_context));
        }

        public void Dispose()
        {
            _loggers.Clear();
        }
    }
}
