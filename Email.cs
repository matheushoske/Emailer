// <copyright file="Email.cs" company="matheushoske">
// Copyright (c) 2021 All Rights Reserved
// </copyright>
// <author>Matheus Hoskes</author>
// <date>18/03/2022 07:48:58 AM </date>
// <summary>Class created to simplify email sending in .NET</summary>
//---------------------------------------------------------------------
// More info About the Project: https://github.com/matheushoske/Emailer
// Be Welcome to Fork with this project
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace Emailer
{
    public class Email
    {
        #region Public parameters
        #region Enums
        public enum smtps
        {
            Gmail = 1,
            Outlook = 2,
            Office365 = 3,
            Hotmail = 4,
            Yahoo = 5,
            Uol = 6,
            Terra = 7,
            Hostinger = 8,
            Titan = 9
        }
        #endregion
        public static string EmailFrom;
        public static string NameFrom = "";
        public static string EmailPassword;
        public static smtps SmtpServer = 0;
        public static bool Smtpssl = true;

        public static bool CustomSmtp = false;
        public static string CustomSmtpAddress = "";
        public static int CustomSmtpPort = 0;
        
        #endregion

        #region Private parameters
        private readonly string emailTo;
        private readonly string nameTo;
        private static string host;
        private static int port;
        private static List<string> CCemailTo;
        #endregion

        #region Constructor
        public Email(string emailToAddress, string _nameTo = "", List<string> CCemailToAddress = null)
        {
            if (EmailFrom == default || EmailPassword == default || (SmtpServer == 0 && !CustomSmtp))
            {
                if (EmailFrom == default)
                    throw new Exception("EmailFrom value need to be assigned");
                else if (EmailPassword == default)
                    throw new Exception("EmailPassword value need to be assigned");
                else if (SmtpServer == 0 && !CustomSmtp)
                    throw new Exception("SmtpServer value need to be assigned");
                return;
            }
            nameTo = _nameTo;
            emailTo = emailToAddress;
            CCemailTo = CCemailToAddress;
        }
        #endregion

        #region Public Methods
        public bool Send(string assunto, string texto, bool ssl = true, bool IsBodyHtml = true)
        {
            CheckSmtp();
            var fromAddress =  new MailAddress(EmailFrom, NameFrom);
            var toAddress = nameTo == "" ? new MailAddress(emailTo) : new MailAddress(emailTo, nameTo);
            string fromPassword = EmailPassword;
            string subject = assunto;
            string body = texto;
            
            var client = new SmtpClient
            {
                
                Host = host,
                Port = port,
                EnableSsl = ssl,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = IsBodyHtml,

            })
            {
                client.Send(message);
                return true;
            }
        }
        #endregion

        #region Private Methods
        private MailAddressCollection GetCCEmails() 
        {
            var col = new MailAddressCollection();
            if (CCemailTo != null) { 
            foreach (var item in CCemailTo)
            {
                col.Add(item);
            }
            }
            return col;
            
        }
        private void CheckSmtp() 
        {
            if (CustomSmtp)
            {
                host = CustomSmtpAddress;
                port = CustomSmtpPort;
                return;
            }
            switch (SmtpServer)
            {
                case smtps.Gmail:
                    host = "smtp.gmail.com";
                    port = 587;
                    break;
                case smtps.Outlook:
                    host = "smtp.live.com";
                    port = 587;
                    break;
                case smtps.Office365:
                    host = "smtp.office365.com";
                    port = 587;
                    break;
                case smtps.Hotmail:
                    host = "smtp.live.com";
                    port = 465;
                    break;
                case smtps.Yahoo:
                    host = "smtp.mail.yahoo.com";
                    port = 465;
                    break;
                case smtps.Uol:
                    host = "smtps.uol.com.br﻿";
                    port = 587;
                    break;
                case smtps.Terra:
                    host = "smtp.terra.com.br";
                    port = 587;
                    break;
                case smtps.Hostinger:
                    host = "smtp.hostinger.com";
                    port = 587;
                    break;
                case smtps.Titan:
                     host = "smtp.titan.email";
                    port = 587;
                    break;
                default:
                    throw new Exception("smtp value not found. Try using a custom SMTP");
                    break;
            }
        }
        #endregion
    }
}
