using System;

namespace Rbi.Monitoring.Graphite
{
    public struct Key
    {
        public const string Root = "stat";
        public const string RollupRoot = "roll";

        public string Product { get; set; }
        public string DataCentre { get; set; }
        public string Server { get; set; }
        public string Stat { get; set; }

        public string FullKeyName
        {
            get { return String.Format("{0}.{1}.{2}.{3}.{4}", Root, Product, DataCentre, Server, Stat); }
        }
    }
}
