using Logik.Helpers;
using Microsoft.AspNetCore.Http;

namespace Logik.Services
{
    public class SessionController<T> : ISessionController<T> where T: new()
    {
        readonly ISession _session;
        public SessionController(IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
        }

        public T LoadOrCreate(string key)
        {
            T result = _session.Get<T>(key);
            if (result == null) result = new T();
            return result;
        }

        public void Save(string key, T data)
        {
            _session.Set(key, data);
        }
    }
}
