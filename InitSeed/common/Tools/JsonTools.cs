using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Newtonsoft.Json;

namespace InitSeed.Common.Tools
{
    public static class JsonTools 
    {
        /// <summary>
        /// 把对象转换为JSON字符串
        /// </summary>
        /// <param name="o">对象</param>
        /// <returns>JSON字符串</returns>
        public static string ToJSON(this object o)
        {
            if (o == null)
            {
                return null;
            }
            return JsonConvert.SerializeObject(o);
        }


        /// <summary>
        /// 把Json文本转为实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static T FromJSON<T>(this string input)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(input);
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        public static string test()
        { 
            User user = new User();
            user.UserName = "tom";
            user.Age = 22;
            user.Sex = 1;
            user.Like = "PLAY";

            var json = ToJSON(user);//对象转为Json 
            return json;
        }
        public static object test2(string json)
        { 
            string user = "{\"UserName\":\"tom\",\"Age\":22,\"Sex\":1,\"Like\":\"PLAY\"}";//这里使用转义符
            var entity = user.FromJSON<User>();//Json转为实体对象
            User entity2 = user.FromJSON<User>();//Json转为实体对象
            return entity;
        }
        class User
        {
            public int Age, Sex;
            public string UserName, Like;
        }
    }
}