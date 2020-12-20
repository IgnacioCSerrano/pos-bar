using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBar
{
    internal class Email
    {
        private string sender;
        private string receiver;
        private string subject;
        private string body;
        private string attachment;

        public Email(string sender, string receiver, string subject, string body, string attachment)
        {
            this.sender = sender;
            this.receiver = receiver;
            this.subject = subject;
            this.body = body;
            this.attachment = attachment;
        }

        public string Sender
        {
            get
            {
                return sender;
            }

            set
            {
                sender = value;
            }
        }

        public string Receiver
        {
            get
            {
                return receiver;
            }

            set
            {
                receiver = value;
            }
        }

        public string Subject
        {
            get
            {
                return subject;
            }

            set
            {
                subject = value;
            }
        }

        public string Body
        {
            get
            {
                return body;
            }

            set
            {
                body = value;
            }
        }

        public string Attachment
        {
            get
            {
                return attachment;
            }

            set
            {
                attachment = value;
            }
        }
    }
}
