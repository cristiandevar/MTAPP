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
   public class productactivedeactive : GXProcedure
   {
      public productactivedeactive( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public productactivedeactive( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_ProductId ,
                           bool aP1_Active ,
                           out bool aP2_AllOk ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP3_ErrorMessagges )
      {
         this.AV8ProductId = aP0_ProductId;
         this.AV9Active = aP1_Active;
         this.AV10AllOk = false ;
         this.AV14ErrorMessagges = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         initialize();
         executePrivate();
         aP2_AllOk=this.AV10AllOk;
         aP3_ErrorMessagges=this.AV14ErrorMessagges;
      }

      public GXBaseCollection<GeneXus.Utils.SdtMessages_Message> executeUdp( int aP0_ProductId ,
                                                                             bool aP1_Active ,
                                                                             out bool aP2_AllOk )
      {
         execute(aP0_ProductId, aP1_Active, out aP2_AllOk, out aP3_ErrorMessagges);
         return AV14ErrorMessagges ;
      }

      public void executeSubmit( int aP0_ProductId ,
                                 bool aP1_Active ,
                                 out bool aP2_AllOk ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP3_ErrorMessagges )
      {
         productactivedeactive objproductactivedeactive;
         objproductactivedeactive = new productactivedeactive();
         objproductactivedeactive.AV8ProductId = aP0_ProductId;
         objproductactivedeactive.AV9Active = aP1_Active;
         objproductactivedeactive.AV10AllOk = false ;
         objproductactivedeactive.AV14ErrorMessagges = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         objproductactivedeactive.context.SetSubmitInitialConfig(context);
         objproductactivedeactive.initialize();
         Submit( executePrivateCatch,objproductactivedeactive);
         aP2_AllOk=this.AV10AllOk;
         aP3_ErrorMessagges=this.AV14ErrorMessagges;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((productactivedeactive)stateInfo).executePrivate();
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
         AV11Product.Load(AV8ProductId);
         AV11Product.gxTpr_Productactive = AV9Active;
         AV11Product.Update();
         if ( AV11Product.Success() )
         {
            context.CommitDataStores("productactivedeactive",pr_default);
            AV10AllOk = true;
         }
         else
         {
            context.RollbackDataStores("productactivedeactive",pr_default);
            AV10AllOk = false;
            AV14ErrorMessagges = AV11Product.GetMessages();
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
         AV14ErrorMessagges = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV11Product = new SdtProduct(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.productactivedeactive__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV8ProductId ;
      private bool AV9Active ;
      private bool AV10AllOk ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private bool aP2_AllOk ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP3_ErrorMessagges ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV14ErrorMessagges ;
      private SdtProduct AV11Product ;
   }

   public class productactivedeactive__default : DataStoreHelperBase, IDataStoreHelper
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
