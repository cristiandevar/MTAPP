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
   public class purchaseorderactivedeactive : GXProcedure
   {
      public purchaseorderactivedeactive( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public purchaseorderactivedeactive( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_PurchaseOrderId ,
                           out bool aP1_AllOk )
      {
         this.AV8PurchaseOrderId = aP0_PurchaseOrderId;
         this.AV10AllOk = false ;
         initialize();
         executePrivate();
         aP1_AllOk=this.AV10AllOk;
      }

      public bool executeUdp( int aP0_PurchaseOrderId )
      {
         execute(aP0_PurchaseOrderId, out aP1_AllOk);
         return AV10AllOk ;
      }

      public void executeSubmit( int aP0_PurchaseOrderId ,
                                 out bool aP1_AllOk )
      {
         purchaseorderactivedeactive objpurchaseorderactivedeactive;
         objpurchaseorderactivedeactive = new purchaseorderactivedeactive();
         objpurchaseorderactivedeactive.AV8PurchaseOrderId = aP0_PurchaseOrderId;
         objpurchaseorderactivedeactive.AV10AllOk = false ;
         objpurchaseorderactivedeactive.context.SetSubmitInitialConfig(context);
         objpurchaseorderactivedeactive.initialize();
         Submit( executePrivateCatch,objpurchaseorderactivedeactive);
         aP1_AllOk=this.AV10AllOk;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((purchaseorderactivedeactive)stateInfo).executePrivate();
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
         /* Using cursor P00242 */
         pr_default.execute(0, new Object[] {AV8PurchaseOrderId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A50PurchaseOrderId = P00242_A50PurchaseOrderId[0];
            A79PurchaseOrderActive = P00242_A79PurchaseOrderActive[0];
            AV9ValueBoolean = (bool)(!(A79PurchaseOrderActive));
            A79PurchaseOrderActive = AV9ValueBoolean;
            /* Using cursor P00243 */
            pr_default.execute(1, new Object[] {A79PurchaseOrderActive, A50PurchaseOrderId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("PurchaseOrder");
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("purchaseorderactivedeactive",pr_default);
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
         scmdbuf = "";
         P00242_A50PurchaseOrderId = new int[1] ;
         P00242_A79PurchaseOrderActive = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.purchaseorderactivedeactive__default(),
            new Object[][] {
                new Object[] {
               P00242_A50PurchaseOrderId, P00242_A79PurchaseOrderActive
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV8PurchaseOrderId ;
      private int A50PurchaseOrderId ;
      private string scmdbuf ;
      private bool AV10AllOk ;
      private bool A79PurchaseOrderActive ;
      private bool AV9ValueBoolean ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00242_A50PurchaseOrderId ;
      private bool[] P00242_A79PurchaseOrderActive ;
      private bool aP1_AllOk ;
   }

   public class purchaseorderactivedeactive__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00242;
          prmP00242 = new Object[] {
          new ParDef("@AV8PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmP00243;
          prmP00243 = new Object[] {
          new ParDef("@PurchaseOrderActive",GXType.Boolean,4,0) ,
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00242", "SELECT [PurchaseOrderId], [PurchaseOrderActive] FROM [PurchaseOrder] WITH (UPDLOCK) WHERE [PurchaseOrderId] = @AV8PurchaseOrderId ORDER BY [PurchaseOrderId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00242,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00243", "UPDATE [PurchaseOrder] SET [PurchaseOrderActive]=@PurchaseOrderActive  WHERE [PurchaseOrderId] = @PurchaseOrderId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00243)
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                return;
       }
    }

 }

}
