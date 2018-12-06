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
        //private string firstname;
        //private string middlename = "";
        //private string lastname = "";
        //private string nickname = "";
        private string photo = "";
        private string title = "";
        private string company = "";
        private string address = "";
        private string hometel = "";
        private string mobiletel = "";
        private string worktel = "";
        private string allPhones;
        private string fax = "Type \"fax number\" here";
        private string e_mail = "";
        private string e_mail2 = "Type \"E-mail2\" here";
        private string e_mail3 = "Type \"E-mail3\" here";
        private string homepage = "";
        private string bday = "22";
        private string bmonth = "June";
        private string byear = "2012";
        private string aday = "";
        private string amonth = "";
        private string ayear = "";
        private string group = "";
        private string secaddress = "";
        private string sechome = "";
        private string notes = "";
        private string allEmails;
     

        public ContactData()
        {
        }

        public ContactData(String name)
        {
            Firstname = name;
            Lastname = "";
            MobileTel = "";
        }

        public ContactData(string firstname, string lastname)
        {
            //this.firstname = firstname;
            Firstname = firstname;
            Lastname = lastname;
        }

        public String GetFullString()
        {
            return FullName + Address + AllPhones + AllEmails;
        }



        //public string Firstname { get => firstname; set => firstname = value; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Nickname { get; set; }
        public string FullName { get; set; }

        public string Homepage { get; set; }

        public string Group { get; set; }

        public string Secaddress { get; set; }
        public string Sechome { get; set; }

        public string Notes { get; set; }

        public string Bday { get; set; }
        public string Bmonth { get; set; }
        public string Byear { get; set; }
        public string Aday { get; set; }
        public string Amonth { get; set; }
        public string Ayear { get; set; }

        public string E_mail { get; set; }
        public string E_mail2 { get; set; }
        public string E_mail3 { get; set; }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    string result = "";
                    if (E_mail != null && E_mail != "") { result += E_mail + "\r\n"; }
                    if (E_mail2 != null && E_mail2 != "") { result += E_mail2 + "\r\n"; }
                    if (E_mail3 != null && E_mail3 != "") { result += E_mail3; }
                    return result.Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        public string Photo { get; set; }
        public string Photo1 { get; set; }

        public string Title { get; set; }
        public string Company { get; set; }

        public string Address { get; set; }
        public string Address2 { get; set; }

        public string HomeTel { get; set; }
        public string MobileTel { get; set; }
        public string WorkTel { get; set; }
        public string Fax { get; set; }

        public string AllPhones
        {
            get
            {
                if (AllPhones != null)
                {
                    return AllPhones;
                }
                else
                {
                    return (CleanUp(HomeTel) + CleanUp(MobileTel) + CleanUp(WorkTel)).Trim();
                }

            }
            set
            {
                AllPhones = value;
            }
        }

        private string CleanUp(string val)
        {
            if (val == null || val == "")
            {
                return "";
            }
            return val.Replace(":", "").Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
            //return Regex.Replace(phone, "[ -()]", "") + "\r\n";
            //return Regex.Replace(phone, "[ H-M:-MHW:-()]", "") + "\r\n";
        }

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
            //return "Firstname = " + Firstname + ", Lastname = " + Lastname;
            string val = "";
            if (Firstname != "") { val += "firstname: " + Firstname; }
            if (Middlename != "") { val += "\nmiddlename " + Middlename; }
            if (Lastname != "") { val += "\nlastname " + Lastname; }
            if (Nickname != "") { val += "\nnickname: " + Nickname; }
            if (Title != "") { val += "\ntitle: " + Title; }
            if (Company != "") { val += "\ncompany: " + Company; }
            if (Address != "") { val += "\naddress: " + Address; }
            if (HomeTel != "") { val += "\nhome: " + HomeTel; }
            if (MobileTel != "") { val += "\nmobile " + MobileTel; }
            if (WorkTel != "") { val += "\nwork " + WorkTel; }
            if (Fax != "") { val += "\nfax " + Fax; }
            if (E_mail != "") { val += "\nemail1: " + E_mail; }
            if (E_mail2 != "") { val += "\nemail2: " + E_mail2; }
            if (E_mail3 != "") { val += "\nemail3: " + E_mail3; }
            if (Homepage != "") { val += "\nhomepage: " + Homepage; }
            if (Bday != null) { val += "\nbday: " + Bday; }
            if (Bmonth != null) { val += "\nbmonth: " + Bmonth; }
            if (Byear != null) { val += "\nbyear: " + Byear; }
            if (Aday != null) { val += "\naday: " + Aday; }
            if (Amonth != null) { val += "\namonth: " + Amonth; }
            if (Ayear != null) { val += "\nbyear: " + Ayear; }
            if (Address2 != "") { val += "\naddress2: " + Address2; }
            if (Notes != "") { val += "\nnotes: " + Notes; }

            return val;
        }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode() + Lastname.GetHashCode();
        }
    }
}