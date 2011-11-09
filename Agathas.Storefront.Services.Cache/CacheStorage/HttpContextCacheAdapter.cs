using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Agathas.Storefront.Services.Cache.CacheStorage
{
    public class HttpContextCacheAdapter : ICacheStorage
    {        
        public void Remove(string key)
        {
            HttpContext.Current.Cache.Remove(key);   
        }

        public void Store(string key, object data)
        {
            HttpContext.Current.Cache.Insert(key, data);    
        }

        public T Retrieve<T>(string key)
        {
            T itemStored = (T)HttpContext.Current.Cache.Get(key);
            if (itemStored == null)
                itemStored = default(T);

            return itemStored;       
        }       
    }
}
