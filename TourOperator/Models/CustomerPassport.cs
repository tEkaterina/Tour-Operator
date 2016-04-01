using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class CustomerPassport: IModel
    {
        [ForeignKey("CustomerPersonalDataId")]
        public int Id { get; set; }

        public string PassportCode { get; set; }
        public string PassportNumber { get; set; }
        public string PassportIssuePlace { get; set; }
        public DateTime? PassportIssueDate { get; set; }
        public string PersonalId { get; set; }

        public virtual CustomerPersonalData CustomerPersonalData { get; set; }
    }
}
