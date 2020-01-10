using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EDI_suppliers.Data
{
    public class SupplierMFG
    {
        [Key]
        public string Id { get; set; }
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
        [Required(ErrorMessage = "Hodnota musí být zadána")]
        [Display(Name = "EDI")]
        public Boolean Edi { get; set; }
        [Display(Name = "EDI spojení")]
        public ConnectionEdi ConnectionEdi { get; set; }
    }
}
