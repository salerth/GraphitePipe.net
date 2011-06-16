namespace Rbi.Monitoring.Graphite
{
    public struct Key
    {
        public const string RollupRoot = "roll";

        public string Vertical { get; set; }
        public string DataCentre { get; set; }
        public string Server { get; set; }
        public string Stat { get; set; }

        public string FullKeyName
        {
            get { return string.Format("{0}.{1}.{2}.{3}", Vertical, DataCentre, Server, Stat); }
        }

        public string DataCentreKeyName
        {
            get { return string.Format("{0}.{1}.{2}.{3}", RollupRoot, Vertical, DataCentre, Stat); }
        }

        public string VerticalKeyName
        {
            get { return string.Format("{0}.{1}.{2}", RollupRoot, Vertical, Stat); }
        }
    }
}
