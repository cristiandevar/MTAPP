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
   public class asupplieractivedeactive : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("mtaKB", true);
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "SupplierId");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV8SupplierId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV10Active = StringUtil.StrToBool( GetPar( "Active"));
                  AV11AllOk = StringUtil.StrToBool( GetPar( "AllOk"));
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV9ErrorMessages);
               }
            }
            if ( toggleJsOutput )
            {
            }
         }
         if ( GxWebError == 0 )
         {
            executePrivate();
         }
         cleanup();
      }

      public asupplieractivedeactive( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public asupplieractivedeactive( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_SupplierId ,
                           bool aP1_Active ,
                           out bool aP2_AllOk ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP3_ErrorMessages )
      {
         this.AV8SupplierId = aP0_SupplierId;
         this.AV10Active = aP1_Active;
         this.AV11AllOk = false ;
         this.AV9ErrorMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         initialize();
         executePrivate();
         aP2_AllOk=this.AV11AllOk;
         aP3_ErrorMessages=this.AV9ErrorMessages;
      }

      public GXBaseCollection<GeneXus.Utils.SdtMessages_Message> executeUdp( int aP0_SupplierId ,
                                                                             bool aP1_Active ,
                                                                             out bool aP2_AllOk )
      {
         execute(aP0_SupplierId, aP1_Active, out aP2_AllOk, out aP3_ErrorMessages);
         return AV9ErrorMessages ;
      }

      public void executeSubmit( int aP0_SupplierId ,
                                 bool aP1_Active ,
                                 out bool aP2_AllOk ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP3_ErrorMessages )
      {
         asupplieractivedeactive objasupplieractivedeactive;
         objasupplieractivedeactive = new asupplieractivedeactive();
         objasupplieractivedeactive.AV8SupplierId = aP0_SupplierId;
         objasupplieractivedeactive.AV10Active = aP1_Active;
         objasupplieractivedeactive.AV11AllOk = false ;
         objasupplieractivedeactive.AV9ErrorMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         objasupplieractivedeactive.context.SetSubmitInitialConfig(context);
         objasupplieractivedeactive.initialize();
         Submit( executePrivateCatch,objasupplieractivedeactive);
         aP2_AllOk=this.AV11AllOk;
         aP3_ErrorMessages=this.AV9ErrorMessages;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((asupplieractivedeactive)stateInfo).executePrivate();
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
         AV12Supplier.Load(AV8SupplierId);
         AV12Supplier.gxTpr_Supplieractive = AV10Active;
         AV12Supplier.Update();
         if ( AV12Supplier.Success() )
         {
            AV11AllOk = true;
            context.CommitDataStores("supplieractivedeactive",pr_default);
         }
         else
         {
            AV11AllOk = false;
            AV9ErrorMessages = AV12Supplier.GetMessages();
            context.RollbackDataStores("supplieractivedeactive",pr_default);
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         base.cleanup();
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
         GXKey = "";
         gxfirstwebparm = "";
         AV12Supplier = new SdtSupplier(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.asupplieractivedeactive__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private int AV8SupplierId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV10Active ;
      private bool AV11AllOk ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private bool aP2_AllOk ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP3_ErrorMessages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV9ErrorMessages ;
      private SdtSupplier AV12Supplier ;
   }

   public class asupplieractivedeactive__default : DataStoreHelperBase, IDataStoreHelper
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
