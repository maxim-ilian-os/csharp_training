using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_WebAddressbookTests
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        //private string gname; private string gheader =""; private string gfooter ="";

        public GroupData(string gname)
        {
            Gname = gname; //this.gname = gname;
        }

        public GroupData()
        {
            
        }

        //public string Gname { get => gname; set => gname = value; }
        public string Gname { get; set; }
        public string Gheader { get; set; }
        public string Gfooter { get; set; }
        public string Id { get; set; }

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

        public override int GetHashCode()
        {
            return Gname.GetHashCode();
        }

        public int CompareTo(GroupData other)
        {
            if(Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return 0;
            }
            return Gname.CompareTo(other.Gname);
        }
        
        public override string ToString()
        {
            return "Name= " + Gname + "\nHeader= " + Gheader + "\nFooter= " + Gfooter;
        }
    }
}