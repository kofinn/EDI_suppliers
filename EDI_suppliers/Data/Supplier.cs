using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EDI_suppliers.Data
{
    public enum Plant
    {
        P1, P2
    }
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }
        [Required(ErrorMessage = "Hodnota musí být zadána")]
        [Display(Name = "Aktivní")]
        public bool Active { get; set; }
        [Required(ErrorMessage = "Hodnota musí být zadána")]
        [Display(Name = "Závod")]
        public Plant Plant { get; set; }
        [Required(ErrorMessage = "Hodnota musí být zadána")]
        [Display(Name = "Dodavatelské číslo MFG")]
        public string MfgId { get; set; }
        [Required(ErrorMessage = "Hodnota musí být zadána")]
        [Display(Name = "Jméno dodavatele")]
        public string Name { get; set; }
        [Display(Name = "Kontakt IT")]
        public string ContactIt { get; set; }
        [Display(Name = "Kontakt LOG")]
        public string ContactLog { get; set; }
        //public string PurchaseOrder
        //{
        //    get
        //    {
        //        return Plant + "-" + MfgId;
        //    }

        //}
        public ICollection<Connection> Connection { get; set; }
    }
}
