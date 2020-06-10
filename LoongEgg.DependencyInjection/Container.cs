using System;
using System.Collections.Concurrent;

namespace LoongEgg.DependencyInjection
{
    /// <summary>
    /// 依赖注入容器
    /// </summary>
    public class Container
    {
        public ConcurrentDictionary<Type, object> Instances => _Instances;
        private readonly ConcurrentDictionary<Type, object> _Instances = new ConcurrentDictionary<Type, object>();

        /// <summary>
        /// 增加或者更新指定的单一实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance">待增加或者更新的实例</param> 
        public void AddOrUpdate<T>(T instance)
        {
            Type type = typeof(T);
            lock (this)
            {
                if (_Instances.ContainsKey(type))
                    _Instances[type] = instance;
                else
                    _Instances.TryAdd(typeof(T), instance);
            }
        }

        /// <summary>
        /// 在容器中获取指定类型的实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Get<T>() => (T)_Instances[typeof(T)];
    }
}
