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
        private string allEmails;
        private string allData;
       

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public ContactData(string allData)
        {
            this.allData = allData;
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

        public string AllData
        {
            get
            {
                if (allData != null)
                {
                    return allData;
                }
                else
                {
                    string s = " ";
                    string s1 = " ";
                    string s2 = " ";
                    string s3 = " ";
                    string s4 = " ";
                    string p1 = " ";
                    string p2 = " ";
                    string p3 = " ";

                    if (Firstname != "")
                    {
                        s = Firstname;
                    }
                    if (Lastname != "")
                    {
                        s1 = " " + Lastname + " \r\n";
                    }
                    if (Address != "")
                    {
                        s2 = Address + " \r\n";
                    }
                    if (HomePhone != "")
                    {
                        p1 = "H: " + HomePhone + " \r\n";
                    }
                    if (MobilePhone != "")
                    {
                        p2 = "M: " + MobilePhone + " \r\n";
                    }
                    if (WorkPhone != "")
                    {
                        p3 = "W: " + WorkPhone;
                    }
                    if (AllPhones != "")
                    {
                        s3 = "\r\n" + p1 + p2 + p3 + "\r\n";
                    }
                    if (AllEmails != "")
                    {
                        s4 = AllEmails + " \r\n\r\n";
                    }
                    if (s + s1 + s2 + s3 + s4 == "")
                    {
                        return " \r\n\r\n";
                    }
                    else
                    {
                        if (AllEmails != "" && AllPhones != "")
                        {
                            return s + s1 + s2 + s3 + "\r\n" + s4;
                        }
                    }
                    return s + s1 + s2 + s3 + s4;
                }
            }
            set
            {
                allData = value;
            }
        }

    }
    
 }
	

