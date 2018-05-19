using System.Collections.Generic;

namespace CommonLibrary.Database
{
    public class Settings
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
        public List<string> CollectionsName { get; set; }
    }
}
