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
   public class sendemail : GXProcedure
   {
      public sendemail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public sendemail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_ToEmail ,
                           ref string aP1_BodyMsg ,
                           ref string aP2_Subject ,
                           ref GxSimpleCollection<string> aP3_URLs ,
                           ref GxSimpleCollection<string> aP4_NamesOfAttachs ,
                           ref bool aP5_AllOk )
      {
         this.AV9ToEmail = aP0_ToEmail;
         this.AV21BodyMsg = aP1_BodyMsg;
         this.AV15Subject = aP2_Subject;
         this.AV12URLs = aP3_URLs;
         this.AV13NamesOfAttachs = aP4_NamesOfAttachs;
         this.AV14AllOk = aP5_AllOk;
         initialize();
         executePrivate();
         aP1_BodyMsg=this.AV21BodyMsg;
         aP2_Subject=this.AV15Subject;
         aP3_URLs=this.AV12URLs;
         aP4_NamesOfAttachs=this.AV13NamesOfAttachs;
         aP5_AllOk=this.AV14AllOk;
      }

      public bool executeUdp( string aP0_ToEmail ,
                              ref string aP1_BodyMsg ,
                              ref string aP2_Subject ,
                              ref GxSimpleCollection<string> aP3_URLs ,
                              ref GxSimpleCollection<string> aP4_NamesOfAttachs )
      {
         execute(aP0_ToEmail, ref aP1_BodyMsg, ref aP2_Subject, ref aP3_URLs, ref aP4_NamesOfAttachs, ref aP5_AllOk);
         return AV14AllOk ;
      }

      public void executeSubmit( string aP0_ToEmail ,
                                 ref string aP1_BodyMsg ,
                                 ref string aP2_Subject ,
                                 ref GxSimpleCollection<string> aP3_URLs ,
                                 ref GxSimpleCollection<string> aP4_NamesOfAttachs ,
                                 ref bool aP5_AllOk )
      {
         sendemail objsendemail;
         objsendemail = new sendemail();
         objsendemail.AV9ToEmail = aP0_ToEmail;
         objsendemail.AV21BodyMsg = aP1_BodyMsg;
         objsendemail.AV15Subject = aP2_Subject;
         objsendemail.AV12URLs = aP3_URLs;
         objsendemail.AV13NamesOfAttachs = aP4_NamesOfAttachs;
         objsendemail.AV14AllOk = aP5_AllOk;
         objsendemail.context.SetSubmitInitialConfig(context);
         objsendemail.initialize();
         Submit( executePrivateCatch,objsendemail);
         aP1_BodyMsg=this.AV21BodyMsg;
         aP2_Subject=this.AV15Subject;
         aP3_URLs=this.AV12URLs;
         aP4_NamesOfAttachs=this.AV13NamesOfAttachs;
         aP5_AllOk=this.AV14AllOk;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((sendemail)stateInfo).executePrivate();
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
         AV14AllOk = true;
         AV8SMTPSession.Host = "smtp.gmail.com";
         AV8SMTPSession.Port = 587;
         AV8SMTPSession.Authentication = 1;
         AV8SMTPSession.Secure = 1;
         AV8SMTPSession.UserName = "mtappcontact@gmail.com";
         AV8SMTPSession.Password = "anct gxgb sdkt viep";
         AV8SMTPSession.Sender.Address = "mtappcontact@gmail.com";
         AV8SMTPSession.Sender.Name = "MTAPP";
         AV8SMTPSession.Timeout = 240;
         context.Gx_err = AV8SMTPSession.Login();
         if ( ( ( context.Gx_err != 0 ) ) && ( ( context.Gx_err != 1 ) ) )
         {
            GX_msglist.addItem("Error de servidor SMTP: Cod: "+StringUtil.Str( (decimal)(context.Gx_err), 3, 0)+" - "+AV8SMTPSession.ErrDescription);
            AV14AllOk = false;
         }
         else
         {
            AV17MailMessage.Clear();
            AV17MailMessage.Subject = AV15Subject;
            AV19Count = 1;
            AV27GXV1 = 1;
            while ( AV27GXV1 <= AV12URLs.Count )
            {
               AV16URL = ((string)AV12URLs.Item(AV27GXV1));
               AV20HttpClient.Host = AV23HttpRequest.ServerHost;
               AV20HttpClient.BaseURL = AV23HttpRequest.ScriptPath;
               AV20HttpClient.Port = AV23HttpRequest.ServerPort;
               AV20HttpClient.Execute("GET", AV16URL);
               AV24Path = "PublicTempStorage/" + ((string)AV13NamesOfAttachs.Item(AV19Count));
               AV20HttpClient.ToFile(AV24Path);
               AV17MailMessage.Attachments.Add(AV24Path);
               AV19Count = (short)(AV19Count+1);
               AV27GXV1 = (int)(AV27GXV1+1);
            }
            AV17MailMessage.HTMLText = StringUtil.Trim( AV21BodyMsg);
            AV22MailRecipient.Address = AV9ToEmail;
            AV22MailRecipient.Name = "To Email";
            AV17MailMessage.To.Add(AV22MailRecipient);
            context.Gx_err = AV8SMTPSession.Send(AV17MailMessage);
            if ( ( ( context.Gx_err != 0 ) ) && ( ( context.Gx_err != 1 ) ) )
            {
               GX_msglist.addItem("Error to send email. Cod.: "+StringUtil.Str( (decimal)(context.Gx_err), 3, 0)+" - "+AV8SMTPSession.ErrDescription);
               AV14AllOk = false;
            }
            AV8SMTPSession.Logout();
         }
         this.cleanup();
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
         AV17MailMessage = new GeneXus.Mail.GXMailMessage();
         AV16URL = "";
         AV20HttpClient = new GxHttpClient( context);
         AV23HttpRequest = new GxHttpRequest( context);
         AV24Path = "";
         AV22MailRecipient = new GeneXus.Mail.GXMailRecipient();
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV19Count ;
      private int AV27GXV1 ;
      private bool AV14AllOk ;
      private string AV9ToEmail ;
      private string AV21BodyMsg ;
      private string AV15Subject ;
      private string AV16URL ;
      private string AV24Path ;
      private string aP1_BodyMsg ;
      private string aP2_Subject ;
      private GxSimpleCollection<string> aP3_URLs ;
      private GxSimpleCollection<string> aP4_NamesOfAttachs ;
      private bool aP5_AllOk ;
      private GxHttpClient AV20HttpClient ;
      private GxHttpRequest AV23HttpRequest ;
      private GeneXus.Mail.GXMailMessage AV17MailMessage ;
      private GeneXus.Mail.GXMailRecipient AV22MailRecipient ;
      private GeneXus.Mail.GXSMTPSession AV8SMTPSession ;
      private GxSimpleCollection<string> AV12URLs ;
      private GxSimpleCollection<string> AV13NamesOfAttachs ;
   }

}
