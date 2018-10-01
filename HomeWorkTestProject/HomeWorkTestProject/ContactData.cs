using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_WebAddressbookTests
{
    class ContactData
    {
        private string firstname;
        private string middlename;
        private string lastname;
        private string nickname;
        private string photo;
        private string title;
        private string company;
        private string asddress;
        // telephon;
        private string hometel;
        private string mobiletel;
        private string worktel;
        private string fax;
        private string e_mail;
        private string e_mail2;
        private string e_mail3;
        private string homepage;
        private string birthday;
        private string anniversary;
        private string group;
        // Secondary;
        private string address;
        private string home;
        private string notes;

        public string Firstname
        {
            get
            {
                return firstname;
            }
            set => firstname = value;
        }

        public string Middlename
        {
            get
            {
                return middlename;
            }
            set => middlename = value;
        }
    }

}
