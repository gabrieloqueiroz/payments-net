using Payments.Domain.validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Payments.Domain.entities
{
    public class Purchase {
        public int Id { get; private set; }
        public int ProdcutId { get; private set; }
        public int PersonId { get; private set; }
        public DateTime Date { get; private set; }
        public Person Person { get; private set; }
        public Product Product { get; private set; }

        public Purchase(int productId, int personId, DateTime? dateTime) { 
            Validation(productId, personId, dateTime);
        }

        public Purchase(int id, int productId, int personId, DateTime? dateTime)
        {
            DomainValidationException.When(id < 0, "Product Id is invalid");
            Validation(productId, personId, dateTime);
            Id = id;
        }

        private void Validation(int productId, int personId, DateTime? dateTime)
        {
            DomainValidationException.When(productId < 0, "Product Id is invalid");
            DomainValidationException.When(personId < 0, "Person Id is invalid");
            DomainValidationException.When(!dateTime.HasValue, "Date should be informed");
            
            ProdcutId= productId;
            PersonId= personId;
            Date = dateTime.Value;
        }

    }
}
