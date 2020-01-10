using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EDI_suppliers.Data
{
    public class ConnectionEdi
    {
        [Key]
        public string Id { get; set; }
        [Required(ErrorMessage = "Hodnota musí být zadána")]
        [Display(Name = "Typ spojeni")]
        public string ConnectionType { get; set; }
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
        [Display(Name = "Poznamka")]
        public string Remark { get; set; }
        [Display(Name = "Jmeno EDI partnera")]
        public string Name { get; set; }
        [Display(Name = "Gateway")]
        public Boolean Gateway { get; set; }
        [Display(Name = "SSID")]
        public string SSID { get; set; }
        [Display(Name = "SDIF")]
        public string SFID { get; set; }

        public virtual ICollection<SupplierMFG> SupplierMFG  { get; set; }
    }
}
