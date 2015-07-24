using System;
using System.Linq;

namespace AutoMapper
{
    public static class AutoMap
    {
        public interface IMappable
        { }

        public static IMappable Map(this IMappable sourceMap, IMappable destMap)
        {
            destMap.GetType().GetFields().ToList().ForEach(
                            f =>
                            {
                                f.SetValue(destMap, sourceMap.GetType().GetField(f.Name)?.GetValue(sourceMap));
                            }
                );

            destMap.GetType().GetProperties().ToList().ForEach(
                            p =>
                            {
                                p.SetValue(destMap, sourceMap.GetType().GetProperty(p.Name)?.GetValue(sourceMap));
                            }
                );

            return destMap;
        }

        public static void ContinueWith(this IMappable source, Action<IMappable> action)
        {
            action?.Invoke(source);
        }
    }
}
