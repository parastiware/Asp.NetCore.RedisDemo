using Newtonsoft.Json;
using StackExchange.Redis;

namespace RedisTest.Helpers
{
    public  class CacheData
    {
        private static ConnectionMultiplexer _redis; 
        private static IDatabase _redisDatabse;
        private static string SessionKey = "TestredisKey";//new Guid().ToString();

        public  CacheData()
        {
            init();
        }
         void init()
        {
            _redis= ConnectionMultiplexer.Connect("localhost");
            _redisDatabse = _redis.GetDatabase();
        }

        public static bool HasData<T>(T Object)
        {
            var key = Object.GetType();
            if (_redisDatabse.KeyExists(SessionKey+key))
            {
                return true;
            }
            else
            {
                return false;
            }

        }


       

        public static string IsNuLL<T>(T firstValue, T secondValue)
        {
            if (firstValue == null)
                return secondValue.ToString();

            return firstValue.ToString();
        }

       
        public  bool SetData<T>(T data,TimeSpan timeOut)
        {
            if (data == null)
                return false;
            try
            {
                var key = SessionKey + data.GetType();
                var value = JsonConvert.SerializeObject(data);
                _redisDatabse.StringSet(key, value, timeOut);
                return true;
            }
            catch(Exception)
            {
                _redis.Close();
                return false;

            }
           
        }

        public  T GetData<T>(T Object)
        {
            
                try
                {
                    var key = SessionKey + Object.GetType(); 
                    var res = _redisDatabse.StringGet(key);
                    if (res.IsNull)
                        return default(T);
                    else
                        return JsonConvert.DeserializeObject<T>(res);
                }
                catch
                {
                    return default(T);
                }

            
        }

    }
}
