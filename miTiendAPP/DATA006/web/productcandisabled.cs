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
   public class productcandisabled : GXProcedure
   {
      public productcandisabled( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public productcandisabled( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_ProductId ,
                           out bool aP1_CanDisabled ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_CanMessages )
      {
         this.AV8ProductId = aP0_ProductId;
         this.AV9CanDisabled = false ;
         this.AV10CanMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         initialize();
         executePrivate();
         aP1_CanDisabled=this.AV9CanDisabled;
         aP2_CanMessages=this.AV10CanMessages;
      }

      public GXBaseCollection<GeneXus.Utils.SdtMessages_Message> executeUdp( int aP0_ProductId ,
                                                                             out bool aP1_CanDisabled )
      {
         execute(aP0_ProductId, out aP1_CanDisabled, out aP2_CanMessages);
         return AV10CanMessages ;
      }

      public void executeSubmit( int aP0_ProductId ,
                                 out bool aP1_CanDisabled ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_CanMessages )
      {
         productcandisabled objproductcandisabled;
         objproductcandisabled = new productcandisabled();
         objproductcandisabled.AV8ProductId = aP0_ProductId;
         objproductcandisabled.AV9CanDisabled = false ;
         objproductcandisabled.AV10CanMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         objproductcandisabled.context.SetSubmitInitialConfig(context);
         objproductcandisabled.initialize();
         Submit( executePrivateCatch,objproductcandisabled);
         aP1_CanDisabled=this.AV9CanDisabled;
         aP2_CanMessages=this.AV10CanMessages;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((productcandisabled)stateInfo).executePrivate();
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
         AV9CanDisabled = true;
         /* Using cursor P002D2 */
         pr_default.execute(0, new Object[] {AV8ProductId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A15ProductId = P002D2_A15ProductId[0];
            A17ProductStock = P002D2_A17ProductStock[0];
            n17ProductStock = P002D2_n17ProductStock[0];
            if ( A17ProductStock > 0 )
            {
               AV9CanDisabled = false;
               AV11Message.gxTpr_Id = "Stock";
               AV11Message.gxTpr_Description = "Exist stock of product";
               AV10CanMessages.Add(AV11Message, 0);
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( AV9CanDisabled )
            {
               /* Using cursor P002D3 */
               pr_default.execute(1, new Object[] {A15ProductId});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A66PurchaseOrderClosedDate = P002D3_A66PurchaseOrderClosedDate[0];
                  n66PurchaseOrderClosedDate = P002D3_n66PurchaseOrderClosedDate[0];
                  A79PurchaseOrderActive = P002D3_A79PurchaseOrderActive[0];
                  A50PurchaseOrderId = P002D3_A50PurchaseOrderId[0];
                  A61PurchaseOrderDetailId = P002D3_A61PurchaseOrderDetailId[0];
                  A66PurchaseOrderClosedDate = P002D3_A66PurchaseOrderClosedDate[0];
                  n66PurchaseOrderClosedDate = P002D3_n66PurchaseOrderClosedDate[0];
                  A79PurchaseOrderActive = P002D3_A79PurchaseOrderActive[0];
                  AV9CanDisabled = false;
                  AV11Message.gxTpr_Id = "Detail";
                  AV11Message.gxTpr_Description = "Purchase order nro "+StringUtil.Str( (decimal)(A50PurchaseOrderId), 6, 0)+" pending with this product in their details";
                  AV10CanMessages.Add(AV11Message, 0);
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
                  pr_default.readNext(1);
               }
               pr_default.close(1);
            }
            else
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
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
         AV10CanMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         scmdbuf = "";
         P002D2_A15ProductId = new int[1] ;
         P002D2_A17ProductStock = new int[1] ;
         P002D2_n17ProductStock = new bool[] {false} ;
         AV11Message = new GeneXus.Utils.SdtMessages_Message(context);
         P002D3_A15ProductId = new int[1] ;
         P002D3_A66PurchaseOrderClosedDate = new DateTime[] {DateTime.MinValue} ;
         P002D3_n66PurchaseOrderClosedDate = new bool[] {false} ;
         P002D3_A79PurchaseOrderActive = new bool[] {false} ;
         P002D3_A50PurchaseOrderId = new int[1] ;
         P002D3_A61PurchaseOrderDetailId = new int[1] ;
         A66PurchaseOrderClosedDate = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.productcandisabled__default(),
            new Object[][] {
                new Object[] {
               P002D2_A15ProductId, P002D2_A17ProductStock, P002D2_n17ProductStock
               }
               , new Object[] {
               P002D3_A15ProductId, P002D3_A66PurchaseOrderClosedDate, P002D3_n66PurchaseOrderClosedDate, P002D3_A79PurchaseOrderActive, P002D3_A50PurchaseOrderId, P002D3_A61PurchaseOrderDetailId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV8ProductId ;
      private int A15ProductId ;
      private int A17ProductStock ;
      private int A50PurchaseOrderId ;
      private int A61PurchaseOrderDetailId ;
      private string scmdbuf ;
      private DateTime A66PurchaseOrderClosedDate ;
      private bool AV9CanDisabled ;
      private bool n17ProductStock ;
      private bool n66PurchaseOrderClosedDate ;
      private bool A79PurchaseOrderActive ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P002D2_A15ProductId ;
      private int[] P002D2_A17ProductStock ;
      private bool[] P002D2_n17ProductStock ;
      private int[] P002D3_A15ProductId ;
      private DateTime[] P002D3_A66PurchaseOrderClosedDate ;
      private bool[] P002D3_n66PurchaseOrderClosedDate ;
      private bool[] P002D3_A79PurchaseOrderActive ;
      private int[] P002D3_A50PurchaseOrderId ;
      private int[] P002D3_A61PurchaseOrderDetailId ;
      private bool aP1_CanDisabled ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_CanMessages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV10CanMessages ;
      private GeneXus.Utils.SdtMessages_Message AV11Message ;
   }

   public class productcandisabled__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP002D2;
          prmP002D2 = new Object[] {
          new ParDef("@AV8ProductId",GXType.Int32,6,0)
          };
          Object[] prmP002D3;
          prmP002D3 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002D2", "SELECT [ProductId], [ProductStock] FROM [Product] WHERE [ProductId] = @AV8ProductId ORDER BY [ProductId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002D2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P002D3", "SELECT TOP 1 T1.[ProductId], T2.[PurchaseOrderClosedDate], T2.[PurchaseOrderActive], T1.[PurchaseOrderId], T1.[PurchaseOrderDetailId] FROM ([PurchaseOrderDetail] T1 INNER JOIN [PurchaseOrder] T2 ON T2.[PurchaseOrderId] = T1.[PurchaseOrderId]) WHERE (T1.[ProductId] = @ProductId) AND (T2.[PurchaseOrderActive] = 1) AND (( T2.[PurchaseOrderClosedDate] IS NULL or (T2.[PurchaseOrderClosedDate] = convert( DATETIME, '17530101', 112 )) or T2.[PurchaseOrderClosedDate] = convert( DATETIME, '17530101', 112 ) or (T2.[PurchaseOrderClosedDate] = convert( DATETIME, '17530101', 112 )))) ORDER BY T1.[ProductId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002D3,1, GxCacheFrequency.OFF ,false,true )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((int[]) buf[4])[0] = rslt.getInt(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                return;
       }
    }

 }

}
