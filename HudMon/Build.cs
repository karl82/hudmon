
namespace HudMon
{
    namespace Hudson
    {
        public class Build
        {
            public uint Number
            {
                get;
                set;
            }

            public string Url
            {
                get;
                set;
            }

            public override string ToString()
            {
                return Number.ToString();
            }
        }
    }
}
