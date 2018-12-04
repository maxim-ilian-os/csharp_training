using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HW_WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstname;
        private string middlename = "";
        private string lastname = "";
        //private string nickname = "";
        private string photo ="";
        private string title = "";
        private string company = "";
        private string address ="";
        private string hometel = "";
        private string mobiletel = "";
        private string worktel ="";
        private string allPhones;
        private string fax = "Type \"fax number\" here";
        private string e_mail ="";
        private string e_mail2 = "Type \"E-mail2\" here";
        private string e_mail3 = "Type \"E-mail3\" here";
        private string homepage ="";
        private string bday = "22";
        private string bmonth = "June";
        private string byear = "2012";
        private string aday = "";
        private string amounth = "";
        private string ayear = "";
        private string group = "";
        private string secaddress ="";
        private string sechome ="";
        private string notes = "";

        
        public ContactData(string firstname, string lastname)
        {
            //this.firstname = firstname;
            Firstname = firstname;
            Lastname = lastname;
        }

        //public string Firstname { get => firstname; set => firstname = value; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Nickname { get ; set ; }

        public string Homepage { get; set; }
       
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
        public string E_mail2 { get => e_mail2; set => e_mail2 = value; }
        public string E_mail3 { get => e_mail3; set => e_mail3 = value; }
        public string Fax { get => fax; set => fax = value; }
        public string Photo { get => Photo1; set => Photo1 = value; }
        
        public string Photo1 { get => photo; set => photo = value; }
        public string Title { get => title; set => title = value; }
        public string Company { get => company; set => company = value; }

        public string Address { get; set; }

        public string Hometel { get; set ; }
        public string Mobiletel { get ; set ; }
        public string Worktel { get; set; }

        public string AllTel
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones; 
                }
                else
                {
                    return (CleanUp(Hometel) + CleanUp(Mobiletel) + CleanUp(Worktel)).Trim();
                }

            }
            set
            {
                allPhones = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            //return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }


        public string E_mail { get => E_mail1; set => E_mail1 = value; }
        public string E_mail1 { get => e_mail; set => e_mail = value; }
        

        public int CompareTo(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }

            if (Lastname.CompareTo(other.Lastname) == 0)
            {
                if (Firstname.CompareTo(other.Firstname) == 0)
                {
                    //System.Diagnostics.Debug.WriteLine("LastName -  OK;  Firstname - OK");
                    return Lastname.CompareTo(other.Lastname) + Firstname.CompareTo(other.Firstname);
                }
            }
            //System.Diagnostics.Debug.WriteLine("LastName -  OK;   Firstname - IS NOT OK");
            return Lastname.CompareTo(other.Lastname);
        }

       public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Lastname == other.Lastname && Firstname == other.Firstname;
            
           // return this.firstname == other.firstname;
        }

        public override string ToString()
        {
            return "Firstname = " + Firstname + ", Lastname = " + Lastname;
        }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode() + Lastname.GetHashCode();
        }         
    }
}