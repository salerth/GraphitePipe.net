using System;

namespace Rbi.Monitoring.Graphite
{
    public struct Key
    {
        public const string Root = "stat";
        public const string RollupRoot = "roll";

        public string Vertical { get; set; }
        public string DataCentre { get; set; }
        public string Server { get; set; }
        public string Stat { get; set; }

        public string FullKeyName
        {
            get { return  String.Format("{0}.{1}.{2}.{3}.{4}", Root, Vertical, DataCentre, Server, Stat); }
        }

        public string DataCentreKeyName
        {
            get { return String.Format("{0}.{1}.{2}.{3}.{4}", Root, RollupRoot, Vertical, DataCentre, Stat); }
        }

        public string VerticalKeyName
        {
            get { return String.Format("{0}.{1}.{2}.{3}", Root, RollupRoot, Vertical, Stat); }
        }
    }
}
