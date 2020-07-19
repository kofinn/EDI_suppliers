using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EDI_suppliers.Data
{
    public enum EdiType
    {
        OFTP2, ISDN
    }
    public class Partner
    {
        [Key]
        public int PartnerId { get; set; }
        [Display(Name = "Jmeno EDI partnera")]
        [Required(ErrorMessage = "Hodnota musí být zadána")]
        public string Name { get; set; }
        [Display(Name = "Typ EDI spojení")]
        [Required(ErrorMessage = "Hodnota musí být zadána")]
        public EdiType EdiType { get; set; }
        [Display(Name = "Gateway")]
        public Boolean GatewayT { get; set; }
        [Display(Name = "Jméno Gateway")]
        public Gateway Gateway { get; set; }
        [Display(Name = "SSID")]
        public string SSID
        {
            //set
            //{
            //    if (this.Gateway != null)
            //    {
            //        this.SSID = Gateway.SSID;
            //    }
            //    else
            //    {

            //    }
            //}   
            get; set;
        }
        [Display(Name = "SFID")]
        public string SFID { get; set; }
        [Display(Name = "Poznamka")]
        public string Remark { get; set; }
        [Display(Name = "Certifikat")]
        public string Cert { get; set; }
        [Display(Name = "Vypršení Certifikátu")]
        public DateTime CertDate { get; set; }
        public ICollection<Connection> Connections { get; set; }
    }
}
