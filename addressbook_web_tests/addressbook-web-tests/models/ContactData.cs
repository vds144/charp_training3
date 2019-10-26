using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
	public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
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

        public string Firstname { get; set; }

		public string Middlename { get; set; }


		public string Lastname { get; set; }


        public string Id { get; set; }
    }
    }
	

