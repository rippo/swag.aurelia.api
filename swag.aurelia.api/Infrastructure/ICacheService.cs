using System;

namespace swag.aurelia.api.Infrastructure
{
    interface ICacheService
    {
        T Get<T>(string cacheId, Func<T> getItemCallback) where T : class;
        void Remove(string cacheId);
    }
}