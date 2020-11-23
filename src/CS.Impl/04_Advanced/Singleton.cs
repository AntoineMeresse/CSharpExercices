using System;

namespace CS.Impl._04_Advanced
{
    public class Singleton
    {
        private static Singleton instance = null;

        private Singleton()
        {
        }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
    }

    public interface IMySingleton { }
    public class MySingleton : IMySingleton { }
}