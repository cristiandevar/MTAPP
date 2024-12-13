using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Mail;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class emailsend : GXProcedure
   {
      public emailsend( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public emailsend( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      public void executeSubmit( )
      {
         emailsend objemailsend;
         objemailsend = new emailsend();
         objemailsend.context.SetSubmitInitialConfig(context);
         objemailsend.initialize();
         Submit( executePrivateCatch,objemailsend);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((emailsend)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Upgrades for Version1", e);
            throw;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV23AllOk = true;
         AV8SMTPSession.Host = "smtp.gmail.com";
         AV8SMTPSession.Port = 587;
         AV8SMTPSession.Authentication = 1;
         AV8SMTPSession.Secure = 1;
         AV8SMTPSession.UserName = "cristianprogramadorunsa@gmail.com";
         AV8SMTPSession.Password = "vqzz mnxc rqah ooyu";
         AV8SMTPSession.Sender.Address = "cristianprogramadorunsa@gmail.com";
         AV8SMTPSession.Sender.Name = "MTAPP";
         AV8SMTPSession.Timeout = 240;
         context.Gx_err = AV8SMTPSession.Login();
         if ( ( ( context.Gx_err != 0 ) ) && ( ( context.Gx_err != 1 ) ) )
         {
            GX_msglist.addItem("Error de servidor SMTP: Cod: "+StringUtil.Str( (decimal)(context.Gx_err), 3, 0)+" - "+AV8SMTPSession.ErrDescription);
            AV23AllOk = false;
         }
         else
         {
            AV12MailMessage.Clear();
            AV12MailMessage.Subject = "Probando email MiTiendAPP";
            AV15URL = formatLink("ainvoiceregisterattach.aspx", new object[] {GXUtil.UrlEncode(StringUtil.LTrimStr(1,1,0))}, new string[] {"InvoiceId"}) ;
            AV13HttpClient.Host = AV14HttpRequest.ServerHost;
            AV13HttpClient.BaseURL = AV14HttpRequest.ScriptPath;
            AV13HttpClient.Port = AV14HttpRequest.ServerPort;
            AV13HttpClient.Execute("GET", AV15URL);
            AV24Ruta = "PublicTempStorage/Ticket_1.pdf";
            AV13HttpClient.ToFile(AV24Ruta);
            AV12MailMessage.Attachments.Add(AV24Ruta);
            /* Execute user subroutine: 'EMAILBODY' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            AV12MailMessage.HTMLText = StringUtil.Trim( AV21CuerpoMail);
            AV22MailRecipient.Address = "cristianprogramadorunsa@gmail.com";
            AV22MailRecipient.Name = "receptor email";
            AV12MailMessage.To.Add(AV22MailRecipient);
            context.Gx_err = AV8SMTPSession.Send(AV12MailMessage);
            if ( ( ( context.Gx_err != 0 ) ) && ( ( context.Gx_err != 1 ) ) )
            {
               GX_msglist.addItem("Error en el envío del mail. Cod.: "+StringUtil.Str( (decimal)(context.Gx_err), 3, 0)+" - "+AV8SMTPSession.ErrDescription);
               AV23AllOk = false;
            }
            AV8SMTPSession.Logout();
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'EMAILBODY' Routine */
         returnInSub = false;
         AV21CuerpoMail = "<p>Estimado:</p>";
         AV21CuerpoMail += "<p>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;";
         AV21CuerpoMail += "(0387) 4123456/ 5678<br />";
         AV21CuerpoMail += "0800-111-1111<br />";
         AV21CuerpoMail += "MAIL: <a href=\"mailto:cristianprogramadorunsa@gmail.com\">cristianprogramadorunsa@gmail.com</a></p>";
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         AV8SMTPSession = new GeneXus.Mail.GXSMTPSession(context.GetPhysicalPath());
         AV12MailMessage = new GeneXus.Mail.GXMailMessage();
         AV15URL = "";
         AV13HttpClient = new GxHttpClient( context);
         AV14HttpRequest = new GxHttpRequest( context);
         AV24Ruta = "";
         AV21CuerpoMail = "";
         AV22MailRecipient = new GeneXus.Mail.GXMailRecipient();
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private bool AV23AllOk ;
      private bool returnInSub ;
      private string AV15URL ;
      private string AV24Ruta ;
      private string AV21CuerpoMail ;
      private GxHttpClient AV13HttpClient ;
      private GxHttpRequest AV14HttpRequest ;
      private GeneXus.Mail.GXMailMessage AV12MailMessage ;
      private GeneXus.Mail.GXMailRecipient AV22MailRecipient ;
      private GeneXus.Mail.GXSMTPSession AV8SMTPSession ;
   }

}
