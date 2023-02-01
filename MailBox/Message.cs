using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MailBox
{
    internal class Message
    {
        public string Theme { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string AddressName { get; set; }
        public Message(string theme, string content, DateTime date, string adressName)
        {
            Theme = theme;
            Content = content;
            Date = date;
            AddressName = adressname;
        }
    }
}
