using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
	public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
		private string firstname;
		private string middlename = "";
		private string lastname;

		public ContactData(string firstname)
		{
			this.firstname = firstname;
        }

        public ContactData(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
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

        public string Firstname
		{
			get
			{
				return firstname;
			}
			set
			{
				firstname = value;
			}
		}

		public string Middlename
		{
			get
			{
				return middlename;
			}
			set
			{
				middlename = value;
			}
		}

		public string Lastname
		{
			get
			{
				return lastname;
			}
			set
			{
				lastname = value;
			}
		}
	
		}
	}

