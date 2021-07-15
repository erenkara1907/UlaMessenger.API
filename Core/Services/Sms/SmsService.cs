using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using MesajPaneli.Business;
using MesajPaneli.Models;
using MesajPaneli.Models.JsonPostModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;

namespace Service
{
    public class SmsService
    {
        private readonly IConfiguration _config;

        public SmsService(IConfiguration config)
        {
            _config = config;
        }

        public bool Send(string GSMNumber, string Message)
        {
            bool ReturnedObject = false;
            try
            {
                if (string.IsNullOrEmpty(GSMNumber) || string.IsNullOrEmpty(Message))
                    return ReturnedObject;

                string Username = _config["raysoft"]; // todo
                string Password = _config["Mykhut2525"]; //todo
                string SenderTitle = _config["0850"]; ; //todo

                smsData MesajPaneli = new smsData();
                MesajPaneli.user = new UserInfo(Username, Password);

                if (string.IsNullOrEmpty(SenderTitle))
                    MesajPaneli.msgBaslik = "0850";
                else
                    MesajPaneli.msgBaslik = SenderTitle;

                MesajPaneli.msgData.Add(new msgdata(GSMNumber, Message)); // burası

                ReturnValue ReturnData = MesajPaneli.DoPost("http://api.mesajpaneli.com/json_api/", true, true);

                if (ReturnData.status)
                {
                    ReturnedObject = true;

                    // Rapor Referans Numarası : ReturnData.Ref
                    // Gönderim Durumu : ReturnData.status
                    // Hesaptan Düşülen Kredi : ReturnData.amount
                    // Gönderim Tipi ( Numeric[Numara] / Alphanumeric[Başlık] ) : ReturnData.type
                    // Gönderim Sonrası Hesapta Kalan Kredi : ReturnData.credits
                }
            }
            catch
            {
                ReturnedObject = false;
            }

            return ReturnedObject;
        }

        public static void Report()
        {

        }
    }
}