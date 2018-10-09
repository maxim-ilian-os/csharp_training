using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_WebAddressbookTests
{
    public class GroupData
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
    }
}