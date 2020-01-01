using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDI_suppliers.Data
{
    public class ConnectionEdi
    {
        public string Id { get; set; }
        public string Plant { get; set; }
        public Boolean Edi { get; set; }
        public string ConnectionType { get; set; }

        public Boolean Calloff { get; set; }
        public Boolean Asn { get; set; }
        public Boolean SettingMfg { get; set; }
        public Boolean SettingEdi { get; set; }
        public string Remark { get; set; }
        public string NameEdi { get; set; }
        public Boolean Gateway { get; set; }
        public string SSID { get; set; }
        public string SFID { get; set; }
    }
}
