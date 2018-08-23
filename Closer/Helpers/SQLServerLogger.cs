using Closer.DataService.EF;
using Closer.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Closer.Helpers
{
    public class SQLServerLogger : ILogger
    {
        SQLHelper _sqlHelper;

        public SQLServerLogger(string conString)
        {
            _sqlHelper = new SQLHelper(conString);
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel > LogLevel.None;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state,
            Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel)) return;

            _sqlHelper.InsertLog(new EventLog
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
