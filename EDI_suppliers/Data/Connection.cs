using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EDI_suppliers.Data
{
    public enum Type
    {
        WebEDI,EDI,email
    }
    public class Connection
    {
        [Key]
        public string Id { get; set; }
        [Required(ErrorMessage = "Hodnota musí být zadána")]
        [Display(Name = "Typ spojeni")]
        public Type Type { get; set; }
        [Required(ErrorMessage = "Hodnota musí být zadána")]
        [Display(Name = "Odvolavky")]
        public Boolean Calloff { get; set; }
        [Required(ErrorMessage = "Hodnota musí být zadána")]
        [Display(Name = "ASN")]
        public Boolean Asn { get; set; }
        [Required(ErrorMessage = "Hodnota musí být zadána")]
        [Display(Name = "Nastaveni v MFG")]
        public Boolean SettingMfg { get; set; }
        [Required(ErrorMessage = "Hodnota musí být zadána")]
        [Display(Name = "Nastaveni EDI")]
        public Boolean SettingEdi { get; set; }
        public Supplier Supplier { get; set; }
        public Partner Partner { get; set; }

    }
}
