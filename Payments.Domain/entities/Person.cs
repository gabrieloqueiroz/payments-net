using Payments.Domain.validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Domain.entities
{
    public sealed class Person {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public string Phone { get; private set; }
        public ICollection<Purchase> Purchases { get; set; }

        public Person(string document, string name, string phone) {
            Validation(document, name, phone);
        }

        public Person(int id, string name, string document, string phone)
        {
            DomainValidationException.When(id < 0 , "id invalid");
            Validation(document, name, phone);
            Id = id;
        }   

        private void Validation(string document, string name, string phone) {
            DomainValidationException.When(string.IsNullOrEmpty(document), "document should be informed");
            DomainValidationException.When(string.IsNullOrEmpty(name), "name should be informed");
            DomainValidationException.When(string.IsNullOrEmpty(phone), "phone should be informed");

            Name = name;
            Document = document;
            Phone = phone;
        }

    }
}
