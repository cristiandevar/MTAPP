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
   public class supplieractivedeactive : GXProcedure
   {
      public supplieractivedeactive( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public supplieractivedeactive( IGxContext context )
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
         this.AV9SupplierId = aP0_SupplierId;
         this.AV10Active = aP1_Active;
         this.AV11AllOk = false ;
         this.AV12ErrorMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         initialize();
         executePrivate();
         aP2_AllOk=this.AV11AllOk;
         aP3_ErrorMessages=this.AV12ErrorMessages;
      }

      public GXBaseCollection<GeneXus.Utils.SdtMessages_Message> executeUdp( int aP0_SupplierId ,
                                                                             bool aP1_Active ,
                                                                             out bool aP2_AllOk )
      {
         execute(aP0_SupplierId, aP1_Active, out aP2_AllOk, out aP3_ErrorMessages);
         return AV12ErrorMessages ;
      }

      public void executeSubmit( int aP0_SupplierId ,
                                 bool aP1_Active ,
                                 out bool aP2_AllOk ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP3_ErrorMessages )
      {
         supplieractivedeactive objsupplieractivedeactive;
         objsupplieractivedeactive = new supplieractivedeactive();
         objsupplieractivedeactive.AV9SupplierId = aP0_SupplierId;
         objsupplieractivedeactive.AV10Active = aP1_Active;
         objsupplieractivedeactive.AV11AllOk = false ;
         objsupplieractivedeactive.AV12ErrorMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         objsupplieractivedeactive.context.SetSubmitInitialConfig(context);
         objsupplieractivedeactive.initialize();
         Submit( executePrivateCatch,objsupplieractivedeactive);
         aP2_AllOk=this.AV11AllOk;
         aP3_ErrorMessages=this.AV12ErrorMessages;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((supplieractivedeactive)stateInfo).executePrivate();
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
         AV8Supplier.Load(AV9SupplierId);
         AV8Supplier.gxTpr_Supplieractive = AV10Active;
         AV8Supplier.Update();
         if ( AV8Supplier.Success() )
         {
            AV11AllOk = true;
            context.CommitDataStores("supplieractivedeactive",pr_default);
         }
         else
         {
            AV11AllOk = false;
            AV12ErrorMessages = AV8Supplier.GetMessages();
            context.RollbackDataStores("supplieractivedeactive",pr_default);
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
         AV12ErrorMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV8Supplier = new SdtSupplier(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.supplieractivedeactive__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV9SupplierId ;
      private bool AV10Active ;
      private bool AV11AllOk ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private bool aP2_AllOk ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP3_ErrorMessages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV12ErrorMessages ;
      private SdtSupplier AV8Supplier ;
   }

   public class supplieractivedeactive__default : DataStoreHelperBase, IDataStoreHelper
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
