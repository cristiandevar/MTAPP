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
   public class purchaseorderregister : GXProcedure
   {
      public purchaseorderregister( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public purchaseorderregister( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_PurchaseOrderId ,
                           ref decimal aP1_TotalPaid ,
                           ref GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem> aP2_DetailsRegister ,
                           ref bool aP3_IsOwed ,
                           out bool aP4_AllOk )
      {
         this.A50PurchaseOrderId = aP0_PurchaseOrderId;
         this.AV9TotalPaid = aP1_TotalPaid;
         this.AV10DetailsRegister = aP2_DetailsRegister;
         this.AV16IsOwed = aP3_IsOwed;
         this.AV8AllOk = false ;
         initialize();
         executePrivate();
         aP1_TotalPaid=this.AV9TotalPaid;
         aP2_DetailsRegister=this.AV10DetailsRegister;
         aP3_IsOwed=this.AV16IsOwed;
         aP4_AllOk=this.AV8AllOk;
      }

      public bool executeUdp( int aP0_PurchaseOrderId ,
                              ref decimal aP1_TotalPaid ,
                              ref GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem> aP2_DetailsRegister ,
                              ref bool aP3_IsOwed )
      {
         execute(aP0_PurchaseOrderId, ref aP1_TotalPaid, ref aP2_DetailsRegister, ref aP3_IsOwed, out aP4_AllOk);
         return AV8AllOk ;
      }

      public void executeSubmit( int aP0_PurchaseOrderId ,
                                 ref decimal aP1_TotalPaid ,
                                 ref GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem> aP2_DetailsRegister ,
                                 ref bool aP3_IsOwed ,
                                 out bool aP4_AllOk )
      {
         purchaseorderregister objpurchaseorderregister;
         objpurchaseorderregister = new purchaseorderregister();
         objpurchaseorderregister.A50PurchaseOrderId = aP0_PurchaseOrderId;
         objpurchaseorderregister.AV9TotalPaid = aP1_TotalPaid;
         objpurchaseorderregister.AV10DetailsRegister = aP2_DetailsRegister;
         objpurchaseorderregister.AV16IsOwed = aP3_IsOwed;
         objpurchaseorderregister.AV8AllOk = false ;
         objpurchaseorderregister.context.SetSubmitInitialConfig(context);
         objpurchaseorderregister.initialize();
         Submit( executePrivateCatch,objpurchaseorderregister);
         aP1_TotalPaid=this.AV9TotalPaid;
         aP2_DetailsRegister=this.AV10DetailsRegister;
         aP3_IsOwed=this.AV16IsOwed;
         aP4_AllOk=this.AV8AllOk;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((purchaseorderregister)stateInfo).executePrivate();
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
         new getcontext(context ).execute( out  AV15Context, ref  AV8AllOk) ;
         if ( ! AV8AllOk )
         {
            CallWebObject(formatLink("wplogin.aspx") );
            context.wjLocDisableFrm = 1;
         }
         AV8AllOk = true;
         /* Using cursor P001D2 */
         pr_default.execute(0, new Object[] {A50PurchaseOrderId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A78PurchaseOrderTotalPaid = P001D2_A78PurchaseOrderTotalPaid[0];
            n78PurchaseOrderTotalPaid = P001D2_n78PurchaseOrderTotalPaid[0];
            A66PurchaseOrderClosedDate = P001D2_A66PurchaseOrderClosedDate[0];
            n66PurchaseOrderClosedDate = P001D2_n66PurchaseOrderClosedDate[0];
            A138PurchaseOrderWasPaid = P001D2_A138PurchaseOrderWasPaid[0];
            n138PurchaseOrderWasPaid = P001D2_n138PurchaseOrderWasPaid[0];
            A78PurchaseOrderTotalPaid = AV9TotalPaid;
            n78PurchaseOrderTotalPaid = false;
            A66PurchaseOrderClosedDate = Gx_date;
            n66PurchaseOrderClosedDate = false;
            A138PurchaseOrderWasPaid = (bool)(!(AV16IsOwed));
            n138PurchaseOrderWasPaid = false;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            /* Using cursor P001D3 */
            pr_default.execute(1, new Object[] {n78PurchaseOrderTotalPaid, A78PurchaseOrderTotalPaid, n66PurchaseOrderClosedDate, A66PurchaseOrderClosedDate, n138PurchaseOrderWasPaid, A138PurchaseOrderWasPaid, A50PurchaseOrderId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("PurchaseOrder");
            if (true) break;
            /* Using cursor P001D4 */
            pr_default.execute(2, new Object[] {n78PurchaseOrderTotalPaid, A78PurchaseOrderTotalPaid, n66PurchaseOrderClosedDate, A66PurchaseOrderClosedDate, n138PurchaseOrderWasPaid, A138PurchaseOrderWasPaid, A50PurchaseOrderId});
            pr_default.close(2);
            pr_default.SmartCacheProvider.SetUpdated("PurchaseOrder");
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         /* Using cursor P001D5 */
         pr_default.execute(3, new Object[] {A50PurchaseOrderId});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A61PurchaseOrderDetailId = P001D5_A61PurchaseOrderDetailId[0];
            A77PurchaseOrderDetailQuantityRec = P001D5_A77PurchaseOrderDetailQuantityRec[0];
            A134PurchaseOrderDetailSuggestedPr = P001D5_A134PurchaseOrderDetailSuggestedPr[0];
            n134PurchaseOrderDetailSuggestedPr = P001D5_n134PurchaseOrderDetailSuggestedPr[0];
            AV11PurchaseOrderDetailId = A61PurchaseOrderDetailId;
            AV12OneDetail = new SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem(context);
            /* Execute user subroutine: 'OBTAINDETAILINFO' */
            S121 ();
            if ( returnInSub )
            {
               pr_default.close(3);
               this.cleanup();
               if (true) return;
            }
            A77PurchaseOrderDetailQuantityRec = AV12OneDetail.gxTpr_Quantityreceived;
            A134PurchaseOrderDetailSuggestedPr = ((AV12OneDetail.gxTpr_Newcostprice>Convert.ToDecimal(0)) ? AV12OneDetail.gxTpr_Newcostprice : AV12OneDetail.gxTpr_Productcostprice);
            n134PurchaseOrderDetailSuggestedPr = false;
            /* Execute user subroutine: 'IMPACTPRODUCT' */
            S111 ();
            if ( returnInSub )
            {
               pr_default.close(3);
               this.cleanup();
               if (true) return;
            }
            /* Using cursor P001D6 */
            pr_default.execute(4, new Object[] {A77PurchaseOrderDetailQuantityRec, n134PurchaseOrderDetailSuggestedPr, A134PurchaseOrderDetailSuggestedPr, A50PurchaseOrderId, A61PurchaseOrderDetailId});
            pr_default.close(4);
            pr_default.SmartCacheProvider.SetUpdated("PurchaseOrderDetail");
            pr_default.readNext(3);
         }
         pr_default.close(3);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'IMPACTPRODUCT' Routine */
         returnInSub = false;
         /* Using cursor P001D7 */
         pr_default.execute(5, new Object[] {AV12OneDetail.gxTpr_Id});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A15ProductId = P001D7_A15ProductId[0];
            A85ProductCostPrice = P001D7_A85ProductCostPrice[0];
            n85ProductCostPrice = P001D7_n85ProductCostPrice[0];
            A17ProductStock = P001D7_A17ProductStock[0];
            n17ProductStock = P001D7_n17ProductStock[0];
            if ( A85ProductCostPrice < AV12OneDetail.gxTpr_Newcostprice )
            {
               A85ProductCostPrice = AV12OneDetail.gxTpr_Newcostprice;
               n85ProductCostPrice = false;
            }
            A17ProductStock = (int)(A17ProductStock+(AV12OneDetail.gxTpr_Quantityreceived));
            n17ProductStock = false;
            /* Using cursor P001D8 */
            pr_default.execute(6, new Object[] {n85ProductCostPrice, A85ProductCostPrice, n17ProductStock, A17ProductStock, A15ProductId});
            pr_default.close(6);
            pr_default.SmartCacheProvider.SetUpdated("Product");
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(5);
      }

      protected void S121( )
      {
         /* 'OBTAINDETAILINFO' Routine */
         returnInSub = false;
         AV23GXV1 = 1;
         while ( AV23GXV1 <= AV10DetailsRegister.Count )
         {
            AV14OneAuxDetail = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV10DetailsRegister.Item(AV23GXV1));
            if ( AV14OneAuxDetail.gxTpr_Purchaseorderdetailid == AV11PurchaseOrderDetailId )
            {
               AV12OneDetail = AV14OneAuxDetail;
               if (true) break;
            }
            AV23GXV1 = (int)(AV23GXV1+1);
         }
      }

      public override void cleanup( )
      {
         context.CommitDataStores("purchaseorderregister",pr_default);
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
         AV15Context = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         scmdbuf = "";
         P001D2_A50PurchaseOrderId = new int[1] ;
         P001D2_A78PurchaseOrderTotalPaid = new decimal[1] ;
         P001D2_n78PurchaseOrderTotalPaid = new bool[] {false} ;
         P001D2_A66PurchaseOrderClosedDate = new DateTime[] {DateTime.MinValue} ;
         P001D2_n66PurchaseOrderClosedDate = new bool[] {false} ;
         P001D2_A138PurchaseOrderWasPaid = new bool[] {false} ;
         P001D2_n138PurchaseOrderWasPaid = new bool[] {false} ;
         A66PurchaseOrderClosedDate = DateTime.MinValue;
         Gx_date = DateTime.MinValue;
         P001D5_A50PurchaseOrderId = new int[1] ;
         P001D5_A61PurchaseOrderDetailId = new int[1] ;
         P001D5_A77PurchaseOrderDetailQuantityRec = new int[1] ;
         P001D5_A134PurchaseOrderDetailSuggestedPr = new decimal[1] ;
         P001D5_n134PurchaseOrderDetailSuggestedPr = new bool[] {false} ;
         AV12OneDetail = new SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem(context);
         P001D7_A15ProductId = new int[1] ;
         P001D7_A85ProductCostPrice = new decimal[1] ;
         P001D7_n85ProductCostPrice = new bool[] {false} ;
         P001D7_A17ProductStock = new int[1] ;
         P001D7_n17ProductStock = new bool[] {false} ;
         AV14OneAuxDetail = new SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.purchaseorderregister__default(),
            new Object[][] {
                new Object[] {
               P001D2_A50PurchaseOrderId, P001D2_A78PurchaseOrderTotalPaid, P001D2_n78PurchaseOrderTotalPaid, P001D2_A66PurchaseOrderClosedDate, P001D2_n66PurchaseOrderClosedDate, P001D2_A138PurchaseOrderWasPaid, P001D2_n138PurchaseOrderWasPaid
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               P001D5_A50PurchaseOrderId, P001D5_A61PurchaseOrderDetailId, P001D5_A77PurchaseOrderDetailQuantityRec, P001D5_A134PurchaseOrderDetailSuggestedPr, P001D5_n134PurchaseOrderDetailSuggestedPr
               }
               , new Object[] {
               }
               , new Object[] {
               P001D7_A15ProductId, P001D7_A85ProductCostPrice, P001D7_n85ProductCostPrice, P001D7_A17ProductStock, P001D7_n17ProductStock
               }
               , new Object[] {
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
         context.Gx_err = 0;
      }

      private int A50PurchaseOrderId ;
      private int A61PurchaseOrderDetailId ;
      private int A77PurchaseOrderDetailQuantityRec ;
      private int AV11PurchaseOrderDetailId ;
      private int A15ProductId ;
      private int A17ProductStock ;
      private int AV23GXV1 ;
      private decimal AV9TotalPaid ;
      private decimal A78PurchaseOrderTotalPaid ;
      private decimal A134PurchaseOrderDetailSuggestedPr ;
      private decimal A85ProductCostPrice ;
      private string scmdbuf ;
      private DateTime A66PurchaseOrderClosedDate ;
      private DateTime Gx_date ;
      private bool AV16IsOwed ;
      private bool AV8AllOk ;
      private bool n78PurchaseOrderTotalPaid ;
      private bool n66PurchaseOrderClosedDate ;
      private bool A138PurchaseOrderWasPaid ;
      private bool n138PurchaseOrderWasPaid ;
      private bool n134PurchaseOrderDetailSuggestedPr ;
      private bool returnInSub ;
      private bool n85ProductCostPrice ;
      private bool n17ProductStock ;
      private IGxDataStore dsDefault ;
      private decimal aP1_TotalPaid ;
      private GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem> aP2_DetailsRegister ;
      private bool aP3_IsOwed ;
      private IDataStoreProvider pr_default ;
      private int[] P001D2_A50PurchaseOrderId ;
      private decimal[] P001D2_A78PurchaseOrderTotalPaid ;
      private bool[] P001D2_n78PurchaseOrderTotalPaid ;
      private DateTime[] P001D2_A66PurchaseOrderClosedDate ;
      private bool[] P001D2_n66PurchaseOrderClosedDate ;
      private bool[] P001D2_A138PurchaseOrderWasPaid ;
      private bool[] P001D2_n138PurchaseOrderWasPaid ;
      private int[] P001D5_A50PurchaseOrderId ;
      private int[] P001D5_A61PurchaseOrderDetailId ;
      private int[] P001D5_A77PurchaseOrderDetailQuantityRec ;
      private decimal[] P001D5_A134PurchaseOrderDetailSuggestedPr ;
      private bool[] P001D5_n134PurchaseOrderDetailSuggestedPr ;
      private int[] P001D7_A15ProductId ;
      private decimal[] P001D7_A85ProductCostPrice ;
      private bool[] P001D7_n85ProductCostPrice ;
      private int[] P001D7_A17ProductStock ;
      private bool[] P001D7_n17ProductStock ;
      private bool aP4_AllOk ;
      private GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem> AV10DetailsRegister ;
      private SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem AV12OneDetail ;
      private SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem AV14OneAuxDetail ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession AV15Context ;
   }

   public class purchaseorderregister__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
         ,new UpdateCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new UpdateCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new UpdateCursor(def[6])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP001D2;
          prmP001D2 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmP001D3;
          prmP001D3 = new Object[] {
          new ParDef("@PurchaseOrderTotalPaid",GXType.Decimal,18,2){Nullable=true} ,
          new ParDef("@PurchaseOrderClosedDate",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@PurchaseOrderWasPaid",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmP001D4;
          prmP001D4 = new Object[] {
          new ParDef("@PurchaseOrderTotalPaid",GXType.Decimal,18,2){Nullable=true} ,
          new ParDef("@PurchaseOrderClosedDate",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@PurchaseOrderWasPaid",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmP001D5;
          prmP001D5 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmP001D6;
          prmP001D6 = new Object[] {
          new ParDef("@PurchaseOrderDetailQuantityRec",GXType.Int32,6,0) ,
          new ParDef("@PurchaseOrderDetailSuggestedPr",GXType.Decimal,18,2){Nullable=true} ,
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0) ,
          new ParDef("@PurchaseOrderDetailId",GXType.Int32,6,0)
          };
          Object[] prmP001D7;
          prmP001D7 = new Object[] {
          new ParDef("@AV12OneDetail__Id",GXType.Int32,6,0)
          };
          Object[] prmP001D8;
          prmP001D8 = new Object[] {
          new ParDef("@ProductCostPrice",GXType.Decimal,18,2){Nullable=true} ,
          new ParDef("@ProductStock",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P001D2", "SELECT TOP 1 [PurchaseOrderId], [PurchaseOrderTotalPaid], [PurchaseOrderClosedDate], [PurchaseOrderWasPaid] FROM [PurchaseOrder] WITH (UPDLOCK) WHERE [PurchaseOrderId] = @PurchaseOrderId ORDER BY [PurchaseOrderId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001D2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P001D3", "UPDATE [PurchaseOrder] SET [PurchaseOrderTotalPaid]=@PurchaseOrderTotalPaid, [PurchaseOrderClosedDate]=@PurchaseOrderClosedDate, [PurchaseOrderWasPaid]=@PurchaseOrderWasPaid  WHERE [PurchaseOrderId] = @PurchaseOrderId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP001D3)
             ,new CursorDef("P001D4", "UPDATE [PurchaseOrder] SET [PurchaseOrderTotalPaid]=@PurchaseOrderTotalPaid, [PurchaseOrderClosedDate]=@PurchaseOrderClosedDate, [PurchaseOrderWasPaid]=@PurchaseOrderWasPaid  WHERE [PurchaseOrderId] = @PurchaseOrderId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP001D4)
             ,new CursorDef("P001D5", "SELECT [PurchaseOrderId], [PurchaseOrderDetailId], [PurchaseOrderDetailQuantityRec], [PurchaseOrderDetailSuggestedPr] FROM [PurchaseOrderDetail] WITH (UPDLOCK) WHERE [PurchaseOrderId] = @PurchaseOrderId ORDER BY [PurchaseOrderId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001D5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P001D6", "UPDATE [PurchaseOrderDetail] SET [PurchaseOrderDetailQuantityRec]=@PurchaseOrderDetailQuantityRec, [PurchaseOrderDetailSuggestedPr]=@PurchaseOrderDetailSuggestedPr  WHERE [PurchaseOrderId] = @PurchaseOrderId AND [PurchaseOrderDetailId] = @PurchaseOrderDetailId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP001D6)
             ,new CursorDef("P001D7", "SELECT [ProductId], [ProductCostPrice], [ProductStock] FROM [Product] WITH (UPDLOCK) WHERE [ProductId] = @AV12OneDetail__Id ORDER BY [ProductId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001D7,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P001D8", "UPDATE [Product] SET [ProductCostPrice]=@ProductCostPrice, [ProductStock]=@ProductStock  WHERE [ProductId] = @ProductId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP001D8)
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
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
       }
    }

 }

}
