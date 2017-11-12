using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace GreenfinchTest.Models
{
    public class CacheDictionary : Dictionary<string, object>
    {


        private static readonly Object obj = new Object();

        private readonly Dictionary<string, CancellationTokenSource> _expireTasks = new Dictionary<string, CancellationTokenSource>();
        private int _defaultExpiration;

        public CacheDictionary()
        {
            _defaultExpiration = 60 * 60;
        }

        public CacheDictionary(int defaultExpiration)
        {
            _defaultExpiration = defaultExpiration;
        }

        public T GetOrDefault<T>(string key, T createDefault)
        {
            return GetOrDefault(key, createDefault, TimeSpan.FromSeconds(_defaultExpiration));
        }

        public T Set<T>(string key, T create)
        {
            lock (obj)
            {
                return Set(key, create, TimeSpan.FromSeconds(_defaultExpiration));
            }
        }

        public T GetOrDefault<T>(string key, T createDefault, TimeSpan expireIn)
        {
            return (T)(ContainsKey(key) ? this[key] : Set(key, createDefault, expireIn));
        }


        public T Set<T>(string key, T create, TimeSpan expireIn)
        {
            lock (obj)
            {
                if (_expireTasks.ContainsKey(key))
                {
                    _expireTasks[key].Cancel();
                    _expireTasks.Remove(key);
                }

                var expirationTokenSource = new CancellationTokenSource();
                var expirationToken = expirationTokenSource.Token;

                Task.Delay(expireIn, expirationToken).ContinueWith(_ => Expire(key), expirationToken);

                _expireTasks[key] = expirationTokenSource;

                return (T)(this[key] = create);
            }
        }

        private void Expire(string key)
        {
            lock (obj)
            {
                if (_expireTasks.ContainsKey(key))
                    _expireTasks.Remove(key);

                Remove(key);
            }
        }
    }
}