
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

            // override object.Equals
            public override bool Equals(object obj)
            {
                //       
                // See the full list of guidelines at
                //   http://go.microsoft.com/fwlink/?LinkID=85237  
                // and also the guidance for operator== at
                //   http://go.microsoft.com/fwlink/?LinkId=85238
                //

                if (obj == null || GetType() != obj.GetType())
                {
                    return false;
                }

                return Number.Equals(((Build)obj).Number);
            }

            // override object.GetHashCode
            public override int GetHashCode()
            {
                return Number.GetHashCode();
            }
        }
    }
}
