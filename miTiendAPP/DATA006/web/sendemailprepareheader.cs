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
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class sendemailprepareheader : GXProcedure
   {
      public sendemailprepareheader( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public sendemailprepareheader( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_EmailTitle ,
                           string aP1_EmailSubtitle ,
                           string aP2_Content ,
                           out string aP3_EmailBody )
      {
         this.AV13EmailTitle = aP0_EmailTitle;
         this.AV14EmailSubtitle = aP1_EmailSubtitle;
         this.AV12Content = aP2_Content;
         this.AV11EmailBody = "" ;
         initialize();
         executePrivate();
         aP3_EmailBody=this.AV11EmailBody;
      }

      public string executeUdp( string aP0_EmailTitle ,
                                string aP1_EmailSubtitle ,
                                string aP2_Content )
      {
         execute(aP0_EmailTitle, aP1_EmailSubtitle, aP2_Content, out aP3_EmailBody);
         return AV11EmailBody ;
      }

      public void executeSubmit( string aP0_EmailTitle ,
                                 string aP1_EmailSubtitle ,
                                 string aP2_Content ,
                                 out string aP3_EmailBody )
      {
         sendemailprepareheader objsendemailprepareheader;
         objsendemailprepareheader = new sendemailprepareheader();
         objsendemailprepareheader.AV13EmailTitle = aP0_EmailTitle;
         objsendemailprepareheader.AV14EmailSubtitle = aP1_EmailSubtitle;
         objsendemailprepareheader.AV12Content = aP2_Content;
         objsendemailprepareheader.AV11EmailBody = "" ;
         objsendemailprepareheader.context.SetSubmitInitialConfig(context);
         objsendemailprepareheader.initialize();
         Submit( executePrivateCatch,objsendemailprepareheader);
         aP3_EmailBody=this.AV11EmailBody;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((sendemailprepareheader)stateInfo).executePrivate();
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
         /* Execute user subroutine: 'STARTEMAIL' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV11EmailBody += AV12Content;
         /* Execute user subroutine: 'FINISHEMAIL' */
         S121 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'STARTEMAIL' Routine */
         returnInSub = false;
         AV10BaseURL = "https://drive.google.com/uc?export=download&id=";
         AV20ImageName1 = "1wU0Q_t4LgtpiqKOVsjjUiTo0h9CSLl-0";
         AV11EmailBody = "<!DOCTYPE html>";
         AV11EmailBody += "<html lang=\"en\" xmlns=\"http://www.w3.org/1999/xhtml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\">";
         AV11EmailBody += "	<head>";
         AV11EmailBody += "    		<meta charset=\"UTF-8\">";
         AV11EmailBody += "		<meta name=\"viewport\" content=\"width=device-width,initial-scale=1\">";
         AV11EmailBody += "    <meta name=\"x-apple-disable-message-reformatting\">";
         AV11EmailBody += "    <link rel=\"stylesheet\" href=\"https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/css/bootstrap.min.css\"";
         AV11EmailBody += "        integrity=\"sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T\" crossorigin=\"anonymous\">";
         AV11EmailBody += "    <title></title>";
         AV11EmailBody += "    <!--[if mso]>";
         AV11EmailBody += "    <noscript>";
         AV11EmailBody += "    <xml>";
         AV11EmailBody += "    <o:OfficeDocumentSettings>";
         AV11EmailBody += "    <o:PixelsPerInch>96</o:PixelsPerInch>";
         AV11EmailBody += "    </o:OfficeDocumentSettings>";
         AV11EmailBody += "    </xml>";
         AV11EmailBody += "    </noscript>";
         AV11EmailBody += "    <![endif]-->";
         AV11EmailBody += "    <style>";
         AV11EmailBody += "        table,";
         AV11EmailBody += "        td,";
         AV11EmailBody += "        div,";
         AV11EmailBody += "        h1,";
         AV11EmailBody += "        p {";
         AV11EmailBody += "            font-family: Arial, sans-serif;";
         AV11EmailBody += "        }";
         AV11EmailBody += "        .content {";
         AV11EmailBody += "            width: 100%;";
         AV11EmailBody += "            max-width: 600px;";
         AV11EmailBody += "            margin: 0 auto;";
         AV11EmailBody += "            border-collapse: collapse;";
         AV11EmailBody += "        }";
         AV11EmailBody += "        .content td {";
         AV11EmailBody += "            padding: 20px;";
         AV11EmailBody += "        }";
         AV11EmailBody += "        .header {";
         AV11EmailBody += "            padding: 40px 0;";
         AV11EmailBody += "            background-color: #13142c;";
         AV11EmailBody += "            color: white;";
         AV11EmailBody += "        }";
         AV11EmailBody += "        .header img {";
         AV11EmailBody += "            height: auto;";
         AV11EmailBody += "            display: block;";
         AV11EmailBody += "            border-radius: 150px;";
         AV11EmailBody += "        }";
         AV11EmailBody += "        .main {";
         AV11EmailBody += "            background-color: #ffffff;";
         AV11EmailBody += "            padding: 36px 30px;";
         AV11EmailBody += "            color: #13142c;";
         AV11EmailBody += "        }";
         AV11EmailBody += "        .footer {";
         AV11EmailBody += "            padding: 30px;";
         AV11EmailBody += "            text-align: center;";
         AV11EmailBody += "            background-color: #13142c;";
         AV11EmailBody += "            color: white;";
         AV11EmailBody += "        }";
         AV11EmailBody += "    </style>";
         AV11EmailBody += "</head>";
         AV11EmailBody += "<body style=\"margin:0;padding:0;\">";
         AV11EmailBody += "    <table role=\"presentation\" class=\"content\" align=\"center\">";
         AV11EmailBody += "        <tr>";
         AV11EmailBody += "            <td class=\"header\" align=\"center\">";
         AV11EmailBody += "                <img src=\"" + AV10BaseURL + AV20ImageName1 + "\" alt=\"Icon App\"";
         AV11EmailBody += "                    width=\"150\" />";
         AV11EmailBody += "            </td>";
         AV11EmailBody += "        </tr>";
         AV11EmailBody += "        <tr>";
         AV11EmailBody += "            <td class=\"main\">";
         AV11EmailBody += "                <h1>" + AV13EmailTitle + "</h1>";
         AV11EmailBody += "                <p>" + AV14EmailSubtitle + "</p>";
      }

      protected void S121( )
      {
         /* 'FINISHEMAIL' Routine */
         returnInSub = false;
         AV11EmailBody += "            </td>";
         AV11EmailBody += "        </tr>";
         AV11EmailBody += "        <tr>";
         AV11EmailBody += "            <td class=\"footer\">";
         AV11EmailBody += "                &reg; MTAPP, Argentina 2024";
         AV11EmailBody += "            </td>";
         AV11EmailBody += "        </tr>";
         AV11EmailBody += "    </table>";
         AV11EmailBody += "    <script src=\"https://code.jquery.com/jquery-3.3.1.slim.min.js\"";
         AV11EmailBody += "        integrity=\"sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo\"";
         AV11EmailBody += "        crossorigin=\"anonymous\"></script>";
         AV11EmailBody += "    <script src=\"https://cdn.jsdelivr.net/npm/popper.js@1.14.7/dist/umd/popper.min.js\"";
         AV11EmailBody += "        integrity=\"sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1\"";
         AV11EmailBody += "        crossorigin=\"anonymous\"></script>";
         AV11EmailBody += "    <script src=\"https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/js/bootstrap.min.js\"";
         AV11EmailBody += "        integrity=\"sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM\"";
         AV11EmailBody += "        crossorigin=\"anonymous\"></script>";
         AV11EmailBody += "	</body>";
         AV11EmailBody += "</html>";
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
         AV11EmailBody = "";
         AV10BaseURL = "";
         AV20ImageName1 = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private bool returnInSub ;
      private string AV13EmailTitle ;
      private string AV14EmailSubtitle ;
      private string AV12Content ;
      private string AV11EmailBody ;
      private string AV10BaseURL ;
      private string AV20ImageName1 ;
      private string aP3_EmailBody ;
   }

}
