using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EDI_suppliers.Data
{
    //public enum EdiType
    //{
        //OFTP2, ISDN
    //}
    public class Partner
    {
        [Key]
        public int PartnerId { get; set; }
        [Display(Name = "Jmeno EDI partnera")]
        [Required(ErrorMessage = "Hodnota musí být zadána")]
        public string Name { get; set; }
        [Display(Name = "Typ EDI spojení")]
        [Required(ErrorMessage = "Hodnota musí být zadána")]
        public string EdiType { get; set; }
        [Display(Name = "Gateway")]
        public Boolean Gateway { get; set; }
        [Display(Name = "SSID")]
        public string SSID { get; set; }
        [Display(Name = "SFID")]
        public string SFID { get; set; }
        [Display(Name = "Poznamka")]
        public string Remark { get; set; }
        public ICollection<Connection> Connections { get; set; }
    }
}
