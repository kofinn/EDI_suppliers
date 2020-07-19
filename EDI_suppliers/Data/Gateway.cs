using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EDI_suppliers.Data
{
    public class Gateway
    {
        [Key]
        public int GatewayId { get; set; }
        public string Name { get; set; }
        public string SSID { get; set; }
        [Display(Name = "Typ EDI spojení")]
        [Required(ErrorMessage = "Hodnota musí být zadána")]
        public EdiType EdiType { get; set; }
        public List<Partner> Partner { get; set; }
    }
}
