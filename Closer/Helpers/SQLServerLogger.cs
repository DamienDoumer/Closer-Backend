using Closer.DataService.EF;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Closer.Helpers
{
    public class SQLServerLogger : ILogger
    {
        CloserContext _context;

        public SQLServerLogger(CloserContext context)
        {
            _context = context;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state,
            Exception exception, Func<TState, Exception, string> formatter)
        {
            _context.EventLogs.Add(new Entities.EventLog
            {
                Message = $"Event Name : {eventId.Name} ::: {formatter(state, exception)}",
                Source = typeof(TState).ToString(),
                CreatedTime = DateTime.Now,
                EventID = eventId.Id,
                LogLevel = logLevel.ToString()
            });
        }
    }
}
