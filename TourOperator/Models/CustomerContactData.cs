using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class CustomerContactData: IModel
    {
        [ForeignKey("CustomerPersonalDataId")]
        public int Id { get; set; }

        public string BirthPlace { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
        public string Email { get; set; }

        public virtual CustomerPersonalData CustomerPersonalData { get; set; }
    }
}
