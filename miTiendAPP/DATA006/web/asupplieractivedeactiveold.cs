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
   public class asupplieractivedeactiveold : GXProcedure
   {
      public static int Main( string[] args )
      {
         try
         {
            GeneXus.Configuration.Config.ParseArgs(ref args);
            return new asupplieractivedeactiveold().executeCmdLine(args); ;
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Upgrades for Version1", e);
            throw;
            return 1 ;
         }
      }

      public int executeCmdLine( string[] args )
      {
         context.StatusMessage( "Command line using complex types not supported." );
         return GX.GXRuntime.ExitCode ;
      }

      public asupplieractivedeactiveold( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public asupplieractivedeactiveold( IGxContext context )
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
         asupplieractivedeactiveold objasupplieractivedeactiveold;
         objasupplieractivedeactiveold = new asupplieractivedeactiveold();
         objasupplieractivedeactiveold.AV8SupplierId = aP0_SupplierId;
         objasupplieractivedeactiveold.AV10Active = aP1_Active;
         objasupplieractivedeactiveold.AV11AllOk = false ;
         objasupplieractivedeactiveold.AV9ErrorMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         objasupplieractivedeactiveold.context.SetSubmitInitialConfig(context);
         objasupplieractivedeactiveold.initialize();
         Submit( executePrivateCatch,objasupplieractivedeactiveold);
         aP2_AllOk=this.AV11AllOk;
         aP3_ErrorMessages=this.AV9ErrorMessages;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((asupplieractivedeactiveold)stateInfo).executePrivate();
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
            context.CommitDataStores("supplieractivedeactiveold",pr_default);
         }
         else
         {
            AV11AllOk = false;
            AV9ErrorMessages = AV12Supplier.GetMessages();
            context.RollbackDataStores("supplieractivedeactiveold",pr_default);
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
         AV9ErrorMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV12Supplier = new SdtSupplier(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.asupplieractivedeactiveold__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV8SupplierId ;
      private bool AV10Active ;
      private bool AV11AllOk ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private bool aP2_AllOk ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP3_ErrorMessages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV9ErrorMessages ;
      private SdtSupplier AV12Supplier ;
   }

   public class asupplieractivedeactiveold__default : DataStoreHelperBase, IDataStoreHelper
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
