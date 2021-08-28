using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccese.MailServices
{
    class SystemSuportMail:MasterMailServer
    {
        public SystemSuportMail()
        {
            senderMail = "itslBancaProyect@gmail.com";
            password = "BancaProyect";
            host = "smtp.gmail.com";
            port = 587;
            ssl = true;
            initializeSmtpClient();
        }
    }
}
