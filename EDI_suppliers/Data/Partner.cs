﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public string Id { get; set; }

        [Display(Name = "Jmeno EDI partnera")]
        public string Name { get; set; }
        [Display(Name = "Typ EDI spojení")]
        public EdiType EdiType { get; set; }
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
