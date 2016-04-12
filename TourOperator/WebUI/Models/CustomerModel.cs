using System;

namespace WebUI.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }

        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }

        public string Birthdate { get; set; }
        public string Sex { get; set; }
         
        public string PassportCode { get; set; }
        public string PassportNumber { get; set; }
        public string PassportIssuePlace { get; set; }
        public string PassportIssueDate { get; set; }
        public string PassportId { get; set; }

        public string BirthPlace { get; set; }

        public string City { get; set; }
        public string Address { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
        public string Email { get; set; }

        public string MaritalStatus { get; set; }
        public string Citizenship { get; set; }
        public string Disability { get; set; }
        public bool Pensioner { get; set; }
        public bool Reservist { get; set; }

        public decimal Salary { get; set; }

    }
}