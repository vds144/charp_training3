using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
	public class ContactData : IEquatable<ContactData>
    {
		private string firstname;
		private string middlename = "";
		private string lastname;

		public ContactData(string firstname)
		{
			this.firstname = firstname;
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
            return Lastname == other.Lastname;
        }

        public bool Equal(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == other.Firstname;
        }

        public int GetHashCode()
        {
            return Lastname.GetHashCode();
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

