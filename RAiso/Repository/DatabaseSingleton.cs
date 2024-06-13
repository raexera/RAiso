using RAiso.Model;
using System;

namespace RAiso.Repository
{
    public class DatabaseSingleton
    {
        private static readonly Lazy<DatabaseEntities> lazyInstance = new Lazy<DatabaseEntities>(() => new DatabaseEntities());

        public static DatabaseEntities GetInstance()
        {
            return lazyInstance.Value;
        }
    }
}
