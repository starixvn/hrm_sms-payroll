using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

/// <summary>
/// Smtp mail library .
/// </summary>
public class Mail {
    private string g_MailFrom = "";
    private string[] g_MailTo = null;
    private string[] g_Cc = null;
    private string[] g_Bcc = null;
    private string g_Subject = "";
    private string g_Body = "";
    private string g_Host = "";
    private int g_Port = 25;
    private string _userName = "";
    private string _userPassword = "";

    private System.Net.Mail.MailMessage xMsg = new System.Net.Mail.MailMessage();
    /// <summary>
    /// Constructor.
    /// </summary>
    public Mail() {

    }
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="nHost">Smtp host address .</param>
    public Mail(string nHost) {
        g_Host = nHost;
    }
    /// <summary>
    /// Destructor .
    /// </summary>
    ~Mail() {
        xMsg.Dispose();
        xMsg = null;
    }
    /// <summary>
    /// Add attachment in mail .
    /// </summary>
    /// <param name="nFilePath">Attachment file path .</param>
    public void AddAttachmentFile(string nFilePath) {
        try {
            Attachment attachmentFile = new Attachment(nFilePath);
            this.xMsg.Attachments.Add(attachmentFile);
        } catch (Exception) {
            throw;
        }
    }
    /// <summary>
    /// Add attachment in mail .
    /// </summary>
    /// <param name="attachment">Attachment file stream .</param>
    /// <param name="fileName">Attachment file name .</param>
    public void AddAttachmentFile(Stream attachment, string fileName) {
        try {
            Attachment attachmentFile = new Attachment(attachment, fileName);
            this.xMsg.Attachments.Add(attachmentFile);
        } catch (Exception) {
            throw;
        }
    }

    public string UserName {
        set { _userName = value; }
    }
    public string Password {
        set { _userPassword = value; }
    }

    /// <summary>
    /// Send smtp mail action .
    /// </summary>
    public void Send() {
        SmtpClient xSender = new SmtpClient();
        try {
            //Send Mail
            xMsg.From = new MailAddress(this.g_MailFrom);
           
            if (this.g_MailTo != null) {
                for (int i = 0; i < this.g_MailTo.Length; i++) {
                    if (!string.IsNullOrEmpty(this.g_MailTo[i])) {
                        xMsg.To.Add(new MailAddress(this.g_MailTo[i]));
                    }
                }
            }
            if (this.g_Cc != null) {
                for (int i = 0; i < this.g_Cc.Length; i++) {
                    if (!string.IsNullOrEmpty(this.g_Cc[i])) {
                        xMsg.CC.Add(new MailAddress(this.g_Cc[i]));
                    }
                }
            }
            if (this.g_Bcc != null) {
                for (int i = 0; i < this.g_Bcc.Length; i++) {
                    if (!string.IsNullOrEmpty(this.g_Bcc[i])) {
                        xMsg.Bcc.Add(new MailAddress(this.g_Bcc[i]));
                    }
                }
            }
            xMsg.Subject = this.g_Subject;
            xMsg.Body = this.g_Body;
            xMsg.IsBodyHtml = true;
            xMsg.BodyEncoding = System.Text.Encoding.UTF8;
            xSender.Host = this.g_Host;
            if (_userName != "") {
                //System.Net.NetworkCredential nc = new System.Net.NetworkCredential("Jacob.Hsieh", "adodoxxx");
                System.Net.NetworkCredential nc = new System.Net.NetworkCredential(_userName, _userPassword);
                xSender.Credentials = nc;
            } else {
                xSender.Credentials = CredentialCache.DefaultNetworkCredentials;
            }
            
            xSender.Port = this.Port;
            xSender.Send(xMsg);

        } catch (Exception) {
            throw;
        } finally {
            xSender = null;
        }
    }

       
    /// <summary>
    /// Mail to address collection .
    /// </summary>
    public string[] MailTo {
        get {
            return this.g_MailTo;
        }
        set {
            this.g_MailTo = value;
        }
    }
    public string MailOne {
        get {
            return this.g_MailTo[0];
        }
        set {
            string[] onePeopel = {value};
            this.g_MailTo = onePeopel;
        }
    }
    /// <summary>
    /// Mail cc address collection .
    /// </summary>
    public string[] Cc {
        get {
            return this.g_Cc;
        }
        set {
            this.g_Cc = value;
        }
    }
    /// <summary>
    /// Mail Bcc address collection .
    /// </summary>
    public string[] Bcc {
        get {
            return this.g_Bcc;
        }
        set {
            this.g_Bcc = value;
        }
    }
    /// <summary>
    /// Mail from address .
    /// </summary>
    public string From {
        get {
            return this.g_MailFrom;
        }
        set {
            this.g_MailFrom = value;
        }
    }
    /// <summary>
    /// Smtp host address .
    /// </summary>
    public string Host {
        get {
            return this.g_Host;
        }
        set {
            this.g_Host = value;
        }
    }
    public int Port {
        get {
            return this.g_Port;
        }
        set {
            this.g_Port = value;
        }
    }
    /// <summary>
    /// Mail Subject .
    /// </summary>
    public string Subject {
        get {
            return this.g_Subject;
        }
        set {
            this.g_Subject = value;
        }
    }
    /// <summary>
    /// Mail body .
    /// </summary>
    public string Body {
        get {
            return this.g_Body;
        }
        set {
            this.g_Body = value;
        }
    }


}
