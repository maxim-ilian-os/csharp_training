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
        private string middlename ;
        private string lastname;
        private string nickname ;
        //private string photo;
        private string title ;
        private string company ;
        private string address ;
        // telephon;
        private string hometel = "";
        private string mobiletel;
        private string worktel ="";
        //private string fax;
        private string e_mail ="";
        //private string e_mail2;
        //private string e_mail3;
        private string homepage ="";
        // birthday;
        private string bday;
        private string bmonth;
        private string byear;
        //anniversary;
        private string aday = "";
        private string amounth = "";
        private string ayear = "";
        private string group = "";
        // Secondary;
        private string secaddress ="";
        private string sechome ="";
        private string notes = "";

        public ContactData(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }

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
       
        public string Group { get => group; set => group = value; }
        public string Secaddress { get => secaddress; set => secaddress = value; }
        public string Sechome { get => sechome; set => sechome = value; }
        public string Notes { get => notes; set => notes = value; }
        public string Bday { get => bday; set => bday = value; }
        public string Bmouth { get => bmonth; set => bmonth = value; }
        public string Byear { get => byear; set => byear = value; }
        public string Aday { get => aday; set => aday = value; }
        public string Amounth { get => amounth; set => amounth = value; }
        public string Ayear { get => ayear; set => ayear = value; }
    }
}