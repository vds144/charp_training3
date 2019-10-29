using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private String allEmails;
        // private string AllPhones;

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }





        public string Firstname { get; set; }

        public string Middlename { get; set; }


        public string Lastname { get; set; }


        public string Id { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    // return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                    return (ClenupPhone(HomePhone) + ClenupPhone(MobilePhone) + ClenupPhone(WorkPhone)).Trim();
                }


            }
            set
            {
                AllPhones = value;
            }
        }


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
                    return (ClenupEmail(Email1) + ClenupEmail(Email2) + ClenupEmail(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        private string ClenupPhone(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        }

        private string ClenupEmail(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return email.Replace(" ", "") + "\r\n";
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
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
            return Firstname == other.Firstname && Lastname == other.Lastname;
        }


        public override int GetHashCode()
        {
            return Firstname.GetHashCode();
        }


        public override string ToString()
        {
            return "firstname = " + Firstname + ", " + "lastname = " + Lastname;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            int compareResultL = Lastname.CompareTo(other.Lastname);

            if (compareResultL == 0)
            {
                return Firstname.CompareTo(other.Firstname);

            }
            else
            {
                return compareResultL;
            }
        }

    }
    
 }
	

