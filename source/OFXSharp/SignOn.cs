using System;
using System.Xml;

namespace OFXSharp
{
    public class SignOn
    {
        public string StatusSeverity { get; set; }

        public DateTime DTServer { get; set; }

        public int StatusCode { get; set; }

        public string Language { get; set; }

        public string IntuBid { get; set; }

        public SignOn(XmlNode node)
        {
            StatusCode = Convert.ToInt32(node.GetValue("//CODE"));
            StatusSeverity = node.GetValue("//SEVERITY");
            DTServer = GetDtServer(node.GetValue("//DTSERVER"));
            Language = node.GetValue("//LANGUAGE");
            IntuBid = node.GetValue("//INTU.BID");
        }

        /// <summary>
        /// Some banks sends 000000000 as DTServer
        /// </summary>
        private DateTime GetDtServer(string value)
        {
            if (string.IsNullOrEmpty(value?.Trim('0', ' ')))
            {
                return DateTime.MinValue;
            }

            return value.ToDate();
        }
    }
}