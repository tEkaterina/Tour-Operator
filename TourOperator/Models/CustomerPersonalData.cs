using System;

namespace Models
{
    public class CustomerPersonalData: IModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Sex { get; set; }

        public string MaritalStatus { get; set; }
        public string Citizenship { get; set; }
        public string Disability { get; set; }
        public bool Pensioner { get; set; }
        public bool Reservist { get; set; }

        public decimal Salary { get; set; }

        public virtual CustomerPassport CustomerPassport { get; set; }
        public virtual CustomerContactData CustomerContactData { get; set; }
    }
}
