using Logik.Helpers;
using Microsoft.AspNetCore.Http;
using System;

namespace Logik.Services
{
    public class SessionController<T> : ISessionController<T>/* where T: new()*/
    {
        readonly ISession _session;
        public SessionController(IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
        }

        public T LoadOrCreate(string key)
        {
            T result = _session.Get<T>(key);
            if (typeof(T).IsClass && result == default) result = (T)Activator.CreateInstance(typeof(T));
            return result;
        }

        public void Save(string key, T data)
        {
            _session.Set(key, data);
        }
    }
}
