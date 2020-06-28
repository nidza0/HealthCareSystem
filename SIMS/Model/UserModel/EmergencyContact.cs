using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Model.UserModel
{
    public class EmergencyContact
    {
        private string _name;
        private string _surname;
        private string _email;
        private string _phoneNumber;

        public EmergencyContact(string name, string surname, string email, string phoneNumber)
        {
            _name = name;
            _surname = surname;
            _email = email;
            _phoneNumber = phoneNumber;
        }

        public EmergencyContact() { }

        public string Name { get => _name; set => _name = value; }
        public string Surname { get => _surname; set => _surname = value; }
        public string Email { get => _email; set => _email = value; }
        public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }

    }
}
