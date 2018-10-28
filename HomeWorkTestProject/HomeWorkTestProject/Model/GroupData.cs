using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_WebAddressbookTests
{
    public class GroupData : IEquatable<GroupData>
    {
        private string gname;
        private string gheader ="";
        private string gfooter ="";

        public GroupData(string gname)
        {
            this.gname = gname;
        }

        public string Gname { get => gname; set => gname = value; }
        public string Gheader { get => gheader; set => gheader = value; }
        public string Gfooter { get => gfooter; set => gfooter = value; }

        public bool Equals(GroupData other)
        {
            if(Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if(Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Gname == other.Gname;
        }

        public int GetHashCode()
        {
            return Gname.GetHashCode();
        }
    }
}