using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace EventAndDelegate.App
{
    public class CacheService
    {
        private ConnectionMultiplexer connectionMultiplexer;

        public CacheService()
        {
            connectionMultiplexer.ConnectionFailed += ConnectionMultiplexer_ConnectionFailed;

            connectionMultiplexer.ErrorMessage += ConnectionMultiplexer_ErrorMessage;
            connectionMultiplexer.ErrorMessage += ConnectionMultiplexer_ErrorMessage1;
            connectionMultiplexer.ErrorMessage -= ConnectionMultiplexer_ErrorMessage1;
            connectionMultiplexer = ConnectionMultiplexer.Connect("http://localhost:6227");
        }

        private void ConnectionMultiplexer_ErrorMessage1(object? sender, RedisErrorEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ConnectionMultiplexer_ErrorMessage(object? sender, RedisErrorEventArgs e)
        {
        }

        private void ConnectionMultiplexer_ConnectionFailed(object? sender, ConnectionFailedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Set(string key, string value)
        {
            var db = connectionMultiplexer.GetDatabase();
            db.StringSet(key, value);
        }
    }
}