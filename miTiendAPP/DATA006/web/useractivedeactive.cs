using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
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
   public class useractivedeactive : GXProcedure
   {
      public useractivedeactive( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public useractivedeactive( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_UserId ,
                           ref bool aP1_Active ,
                           out bool aP2_AllOk ,
                           ref GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP3_ErrorMessages )
      {
         this.AV8UserId = aP0_UserId;
         this.AV11Active = aP1_Active;
         this.AV9AllOk = false ;
         this.AV10ErrorMessages = aP3_ErrorMessages;
         initialize();
         executePrivate();
         aP1_Active=this.AV11Active;
         aP2_AllOk=this.AV9AllOk;
         aP3_ErrorMessages=this.AV10ErrorMessages;
      }

      public GXBaseCollection<GeneXus.Utils.SdtMessages_Message> executeUdp( int aP0_UserId ,
                                                                             ref bool aP1_Active ,
                                                                             out bool aP2_AllOk )
      {
         execute(aP0_UserId, ref aP1_Active, out aP2_AllOk, ref aP3_ErrorMessages);
         return AV10ErrorMessages ;
      }

      public void executeSubmit( int aP0_UserId ,
                                 ref bool aP1_Active ,
                                 out bool aP2_AllOk ,
                                 ref GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP3_ErrorMessages )
      {
         useractivedeactive objuseractivedeactive;
         objuseractivedeactive = new useractivedeactive();
         objuseractivedeactive.AV8UserId = aP0_UserId;
         objuseractivedeactive.AV11Active = aP1_Active;
         objuseractivedeactive.AV9AllOk = false ;
         objuseractivedeactive.AV10ErrorMessages = aP3_ErrorMessages;
         objuseractivedeactive.context.SetSubmitInitialConfig(context);
         objuseractivedeactive.initialize();
         Submit( executePrivateCatch,objuseractivedeactive);
         aP1_Active=this.AV11Active;
         aP2_AllOk=this.AV9AllOk;
         aP3_ErrorMessages=this.AV10ErrorMessages;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((useractivedeactive)stateInfo).executePrivate();
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
         AV12User.Load(AV8UserId);
         AV12User.gxTpr_Useractive = AV11Active;
         AV12User.Update();
         if ( AV12User.Success() )
         {
            AV9AllOk = true;
            /* Execute user subroutine: 'PREPARENOTIFICATION' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'SENDNOTIFICATION' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            context.CommitDataStores("useractivedeactive",pr_default);
         }
         else
         {
            AV9AllOk = false;
            AV10ErrorMessages = AV12User.GetMessages();
            context.RollbackDataStores("useractivedeactive",pr_default);
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'SENDNOTIFICATION' Routine */
         returnInSub = false;
         new sendemailprepareheader(context ).execute(  AV20EmailTitle,  AV21EmailSubtitle,  AV22EmailBody, out  AV23EmailBodyAux) ;
         AV22EmailBody = AV23EmailBodyAux;
         AV24URLs.Clear();
         AV25Names.Clear();
         GXt_char1 = (AV12User.gxTpr_Useractive ? "User was enabled" : "User was disabled");
         new sendemail(context ).execute(  AV12User.gxTpr_Useremail, ref  AV22EmailBody, ref  GXt_char1, ref  AV24URLs, ref  AV25Names, ref  AV9AllOk) ;
      }

      protected void S121( )
      {
         /* 'PREPARENOTIFICATION' Routine */
         returnInSub = false;
         AV20EmailTitle = (AV12User.gxTpr_Useractive ? "User Enabled" : "User Disabled");
         AV21EmailSubtitle = (AV12User.gxTpr_Useractive ? "You User has been Eanbled" : "You User was Disabled") + ". The user contain the next information:";
         AV19UserModifiedDate = DateTimeUtil.ServerDate( context, pr_default);
         AV22EmailBody = "                <table class=\"table table-border table-striped\">";
         AV22EmailBody += "                    <tr>";
         AV22EmailBody += "                        <td style=\"text-align:left;\"><strong>Email</strong></td>";
         AV22EmailBody += "                        <td>" + AV12User.gxTpr_Useremail + "</td>";
         AV22EmailBody += "                    </tr>";
         AV22EmailBody += "                    <tr>";
         AV22EmailBody += "                        <td style=\"text-align:left;\"><strong>User Name</strong></td>";
         AV22EmailBody += "                        <td>" + AV12User.gxTpr_Username + "</td>";
         AV22EmailBody += "                    </tr>";
         AV22EmailBody += "                    <tr>";
         AV22EmailBody += "                        <td style=\"text-align:left;\"><strong>Created Date</strong></td>";
         AV22EmailBody += "                        <td>";
         AV22EmailBody += context.localUtil.DToC( AV12User.gxTpr_Usercreateddate, 1, "/");
         AV22EmailBody += "					</td>";
         AV22EmailBody += "                    </tr>";
         AV22EmailBody += "                    <tr>";
         AV22EmailBody += "                        <td style=\"text-align:left;\"><strong>Rol</strong></td>";
         AV22EmailBody += "                        <td>";
         AV22EmailBody += AV12User.gxTpr_Rolename;
         AV22EmailBody += "					</td>";
         AV22EmailBody += "                    </tr>";
         AV22EmailBody += "                    <tr>";
         AV22EmailBody += "                        <td style=\"text-align:left;\"><strong>State</strong></td>";
         AV22EmailBody += "                        <td>";
         AV22EmailBody += (AV12User.gxTpr_Useractive ? "Enabled" : "Disabled");
         AV22EmailBody += "					</td>";
         AV22EmailBody += "                    </tr>";
         AV22EmailBody += "                </table>";
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
         AV12User = new SdtUser(context);
         AV20EmailTitle = "";
         AV21EmailSubtitle = "";
         AV22EmailBody = "";
         AV23EmailBodyAux = "";
         AV24URLs = new GxSimpleCollection<string>();
         AV25Names = new GxSimpleCollection<string>();
         GXt_char1 = "";
         AV19UserModifiedDate = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.useractivedeactive__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV8UserId ;
      private string GXt_char1 ;
      private DateTime AV19UserModifiedDate ;
      private bool AV11Active ;
      private bool AV9AllOk ;
      private bool returnInSub ;
      private string AV20EmailTitle ;
      private string AV21EmailSubtitle ;
      private string AV22EmailBody ;
      private string AV23EmailBodyAux ;
      private IGxDataStore dsDefault ;
      private bool aP1_Active ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP3_ErrorMessages ;
      private IDataStoreProvider pr_default ;
      private bool aP2_AllOk ;
      private GxSimpleCollection<string> AV24URLs ;
      private GxSimpleCollection<string> AV25Names ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV10ErrorMessages ;
      private SdtUser AV12User ;
   }

   public class useractivedeactive__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

 }

}
