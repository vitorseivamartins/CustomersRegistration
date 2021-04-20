using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Customer
    {
        public Customer() { }

        public long idCustomer { get; set; }
        public string Name { get; set; }
        public DateTime BirthdayDate { get; set; }
        public IList<Number> Numbers { get; set; }
        public IList<Address> Addresses { get; set; }
        public IList<SocialMedia> SocialMedias { get; set; }
        public string CpfNumber { get; set; }
        public string RgNumber { get; set; }
    }
}
