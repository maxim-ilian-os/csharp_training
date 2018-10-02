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
        //private string photo;
        private string title;
        private string company;
        private string address;
        // telephon;
        private string hometel;
        private string mobiletel;
        private string worktel;
        //private string fax;
        private string e_mail;
        //private string e_mail2;
        //private string e_mail3;
        private string homepage;
        private string birthday;
        private string anniversary;
        private string group;
        // Secondary;
        private string secaddress;
        private string sechome;
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

        public string Lastname
        {
            get
            {
                return lastname;
            }
            set => lastname = value;
        }
        public string Nickname
        {
            get
            {
                return nickname;
            }
            set => nickname = value;
        }
        public string Title
        {
            get
            {
                return title;
            }
            set => title = value;
        }
        public string Company
        {
            get
            {
                return company;
            }
            set => company = value;
        }
        public string Address
        {
            get
            {
                return address;
            }
            set => address = value;
        }
        public string Hometel
        {
            get
            {
                return hometel;
            }
            set => hometel = value;
        }
        public string Mobiletel
        {
            get
            {
                return mobiletel;
            }
            set => mobiletel = value;
        }
        public string Worktel
        {
            get
            {
                return worktel;
            }
            set => worktel = value;
        }
        public string E_mail
        {
            get
            {
                return e_mail;
            }
            set => e_mail = value;
        }

        public string Homepage
        {
            get
            {
                return homepage;
            }
            set => homepage = value;
        }
       
        public string Birthday { get => birthday; set => birthday = value; }
        public string Anniversary { get => anniversary; set => anniversary = value; }
        public string Group { get => group; set => group = value; }
        public string Secaddress { get => secaddress; set => secaddress = value; }
        public string Sechome { get => sechome; set => sechome = value; }
        public string Notes { get => notes; set => notes = value; }
    }

}
