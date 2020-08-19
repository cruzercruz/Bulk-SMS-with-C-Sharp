using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestSendSMSByAPI
{

    public class BulkSMSResponse
    {
        public bool Success { get; set; }
        public string ReasonPhrase { get; set; }
        public StatusCode StatusCode { get; set; }
        public BlukSMS BulkSMS { get; set; }
        public string MessageFromServer { get; set; }
        //public string AccessToken { get; set; }

        public BulkSMSResponse()
        {
            Success = false;
            ReasonPhrase = "";
            StatusCode = new StatusCode();
            BulkSMS = new BlukSMS();
            MessageFromServer = "";
            //AccessToken = "";
        }
    }

    public class StatusCode
    {
        public HttpStatusCode Code { get; set; }
        public string Text { get; set; }

        public StatusCode()
        {
            Code = HttpStatusCode.NotModified;
            Text = Code.ToString();
        }
    }

    public class BlukSMS
    {
        public MessageTag Message { get; set; }
        public string XMLResponse { get; set; }

        public BlukSMS()
        {
            Message = new MessageTag();
            XMLResponse = "";
        }
    }

    public class MessageTag
    {
        public string ID { get; set; }
        public Rsr Rsr { get; set; }
        public Destination Destination { get; set; }
        public Source Source { get; set; }
        public RsrDetail RsrDetail { get; set; }

        public MessageTag()
        {
            ID = "";
            Rsr = new Rsr();
            Destination = new Destination();
            Source = new Source();
            RsrDetail = new RsrDetail();
        }
    }

    public class Rsr
    {
        public string Type { get; set; }
        public string ServiceID { get; set; }

        public Rsr()
        {
            Type = "";
            ServiceID = "";
        }
    }

    public class RsrDetail
    {
        public string Status { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public RsrDetail()
        {
            Status = "";
            Code = "";
            Description = "";
        }
    }

    public class Destination
    {
        public string ID { get; set; }
        public Address Address { get; set; }

        public Destination()
        {
            ID = "";
            Address = new Address();
        }
    }

    public class Source
    {
        public Address Address { get; set; }

        public Source()
        {
            Address = new Address();
        }
    }

    public class Address
    {
        public string Number { get; set; }

        public Address()
        {
            Number = "";
        }
    }

}
