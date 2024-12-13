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
   public class purchaseordercargedetails : GXProcedure
   {
      public purchaseordercargedetails( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public purchaseordercargedetails( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_PurchaseOrderId ,
                           out GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem> aP1_Details )
      {
         this.A50PurchaseOrderId = aP0_PurchaseOrderId;
         this.AV8Details = new GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem>( context, "SDTPurchaseOrderDetailsItem", "mtaKB") ;
         initialize();
         executePrivate();
         aP1_Details=this.AV8Details;
      }

      public GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem> executeUdp( int aP0_PurchaseOrderId )
      {
         execute(aP0_PurchaseOrderId, out aP1_Details);
         return AV8Details ;
      }

      public void executeSubmit( int aP0_PurchaseOrderId ,
                                 out GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem> aP1_Details )
      {
         purchaseordercargedetails objpurchaseordercargedetails;
         objpurchaseordercargedetails = new purchaseordercargedetails();
         objpurchaseordercargedetails.A50PurchaseOrderId = aP0_PurchaseOrderId;
         objpurchaseordercargedetails.AV8Details = new GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem>( context, "SDTPurchaseOrderDetailsItem", "mtaKB") ;
         objpurchaseordercargedetails.context.SetSubmitInitialConfig(context);
         objpurchaseordercargedetails.initialize();
         Submit( executePrivateCatch,objpurchaseordercargedetails);
         aP1_Details=this.AV8Details;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((purchaseordercargedetails)stateInfo).executePrivate();
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
         new getcontext(context ).execute( out  AV14Context, ref  AV15AllOk) ;
         if ( ! AV15AllOk )
         {
            CallWebObject(formatLink("wplogin.aspx") );
            context.wjLocDisableFrm = 1;
         }
         AV8Details = new GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem>( context, "SDTPurchaseOrderDetailsItem", "mtaKB");
         /* Using cursor P001A2 */
         pr_default.execute(0, new Object[] {A50PurchaseOrderId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A76PurchaseOrderDetailQuantityOrd = P001A2_A76PurchaseOrderDetailQuantityOrd[0];
            A61PurchaseOrderDetailId = P001A2_A61PurchaseOrderDetailId[0];
            A15ProductId = P001A2_A15ProductId[0];
            A135PurchaseOrderConfirmatedDate = P001A2_A135PurchaseOrderConfirmatedDate[0];
            n135PurchaseOrderConfirmatedDate = P001A2_n135PurchaseOrderConfirmatedDate[0];
            A66PurchaseOrderClosedDate = P001A2_A66PurchaseOrderClosedDate[0];
            n66PurchaseOrderClosedDate = P001A2_n66PurchaseOrderClosedDate[0];
            A77PurchaseOrderDetailQuantityRec = P001A2_A77PurchaseOrderDetailQuantityRec[0];
            A134PurchaseOrderDetailSuggestedPr = P001A2_A134PurchaseOrderDetailSuggestedPr[0];
            n134PurchaseOrderDetailSuggestedPr = P001A2_n134PurchaseOrderDetailSuggestedPr[0];
            A135PurchaseOrderConfirmatedDate = P001A2_A135PurchaseOrderConfirmatedDate[0];
            n135PurchaseOrderConfirmatedDate = P001A2_n135PurchaseOrderConfirmatedDate[0];
            A66PurchaseOrderClosedDate = P001A2_A66PurchaseOrderClosedDate[0];
            n66PurchaseOrderClosedDate = P001A2_n66PurchaseOrderClosedDate[0];
            AV11OneDetail = new SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem(context);
            AV11OneDetail.gxTpr_Quantityordered = A76PurchaseOrderDetailQuantityOrd;
            AV11OneDetail.gxTpr_Purchaseorderdetailid = A61PurchaseOrderDetailId;
            AV13ProductId = A15ProductId;
            /* Execute user subroutine: 'GETPRODUCTINFO' */
            S111 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            if ( P001A2_n135PurchaseOrderConfirmatedDate[0] || ( DateTimeUtil.ResetTime ( A135PurchaseOrderConfirmatedDate ) == DateTimeUtil.ResetTime ( DateTime.MinValue ) ) || (DateTime.MinValue==A135PurchaseOrderConfirmatedDate) || (DateTime.MinValue==A135PurchaseOrderConfirmatedDate) )
            {
               if ( P001A2_n66PurchaseOrderClosedDate[0] || ( DateTimeUtil.ResetTime ( A66PurchaseOrderClosedDate ) == DateTimeUtil.ResetTime ( DateTime.MinValue ) ) || (DateTime.MinValue==A66PurchaseOrderClosedDate) || (DateTime.MinValue==A66PurchaseOrderClosedDate) )
               {
                  AV11OneDetail.gxTpr_Quantityreceived = A76PurchaseOrderDetailQuantityOrd;
                  AV11OneDetail.gxTpr_Newcostprice = AV11OneDetail.gxTpr_Productcostprice;
               }
               else
               {
                  AV11OneDetail.gxTpr_Quantityreceived = A77PurchaseOrderDetailQuantityRec;
                  AV11OneDetail.gxTpr_Newcostprice = A134PurchaseOrderDetailSuggestedPr;
               }
            }
            else
            {
               AV11OneDetail.gxTpr_Quantityreceived = A77PurchaseOrderDetailQuantityRec;
               AV11OneDetail.gxTpr_Newcostprice = A134PurchaseOrderDetailSuggestedPr;
            }
            AV11OneDetail.gxTpr_Subtotal = (decimal)(AV11OneDetail.gxTpr_Newcostprice*AV11OneDetail.gxTpr_Quantityreceived);
            AV8Details.Add(AV11OneDetail, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'GETPRODUCTINFO' Routine */
         returnInSub = false;
         /* Using cursor P001A3 */
         pr_default.execute(1, new Object[] {AV13ProductId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A15ProductId = P001A3_A15ProductId[0];
            A55ProductCode = P001A3_A55ProductCode[0];
            n55ProductCode = P001A3_n55ProductCode[0];
            A17ProductStock = P001A3_A17ProductStock[0];
            n17ProductStock = P001A3_n17ProductStock[0];
            A69ProductMiniumStock = P001A3_A69ProductMiniumStock[0];
            n69ProductMiniumStock = P001A3_n69ProductMiniumStock[0];
            A16ProductName = P001A3_A16ProductName[0];
            A85ProductCostPrice = P001A3_A85ProductCostPrice[0];
            n85ProductCostPrice = P001A3_n85ProductCostPrice[0];
            AV11OneDetail.gxTpr_Code = A55ProductCode;
            AV11OneDetail.gxTpr_Id = A15ProductId;
            AV11OneDetail.gxTpr_Currentstock = A17ProductStock;
            AV11OneDetail.gxTpr_Miniumstock = A69ProductMiniumStock;
            AV11OneDetail.gxTpr_Name = A16ProductName;
            AV11OneDetail.gxTpr_Productcostprice = A85ProductCostPrice;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
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
         AV8Details = new GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem>( context, "SDTPurchaseOrderDetailsItem", "mtaKB");
         AV14Context = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         scmdbuf = "";
         P001A2_A50PurchaseOrderId = new int[1] ;
         P001A2_A76PurchaseOrderDetailQuantityOrd = new int[1] ;
         P001A2_A61PurchaseOrderDetailId = new int[1] ;
         P001A2_A15ProductId = new int[1] ;
         P001A2_A135PurchaseOrderConfirmatedDate = new DateTime[] {DateTime.MinValue} ;
         P001A2_n135PurchaseOrderConfirmatedDate = new bool[] {false} ;
         P001A2_A66PurchaseOrderClosedDate = new DateTime[] {DateTime.MinValue} ;
         P001A2_n66PurchaseOrderClosedDate = new bool[] {false} ;
         P001A2_A77PurchaseOrderDetailQuantityRec = new int[1] ;
         P001A2_A134PurchaseOrderDetailSuggestedPr = new decimal[1] ;
         P001A2_n134PurchaseOrderDetailSuggestedPr = new bool[] {false} ;
         A135PurchaseOrderConfirmatedDate = DateTime.MinValue;
         A66PurchaseOrderClosedDate = DateTime.MinValue;
         AV11OneDetail = new SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem(context);
         P001A3_A15ProductId = new int[1] ;
         P001A3_A55ProductCode = new string[] {""} ;
         P001A3_n55ProductCode = new bool[] {false} ;
         P001A3_A17ProductStock = new int[1] ;
         P001A3_n17ProductStock = new bool[] {false} ;
         P001A3_A69ProductMiniumStock = new int[1] ;
         P001A3_n69ProductMiniumStock = new bool[] {false} ;
         P001A3_A16ProductName = new string[] {""} ;
         P001A3_A85ProductCostPrice = new decimal[1] ;
         P001A3_n85ProductCostPrice = new bool[] {false} ;
         A55ProductCode = "";
         A16ProductName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.purchaseordercargedetails__default(),
            new Object[][] {
                new Object[] {
               P001A2_A50PurchaseOrderId, P001A2_A76PurchaseOrderDetailQuantityOrd, P001A2_A61PurchaseOrderDetailId, P001A2_A15ProductId, P001A2_A135PurchaseOrderConfirmatedDate, P001A2_n135PurchaseOrderConfirmatedDate, P001A2_A66PurchaseOrderClosedDate, P001A2_n66PurchaseOrderClosedDate, P001A2_A77PurchaseOrderDetailQuantityRec, P001A2_A134PurchaseOrderDetailSuggestedPr,
               P001A2_n134PurchaseOrderDetailSuggestedPr
               }
               , new Object[] {
               P001A3_A15ProductId, P001A3_A55ProductCode, P001A3_n55ProductCode, P001A3_A17ProductStock, P001A3_n17ProductStock, P001A3_A69ProductMiniumStock, P001A3_n69ProductMiniumStock, P001A3_A16ProductName, P001A3_A85ProductCostPrice, P001A3_n85ProductCostPrice
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int A50PurchaseOrderId ;
      private int A76PurchaseOrderDetailQuantityOrd ;
      private int A61PurchaseOrderDetailId ;
      private int A15ProductId ;
      private int A77PurchaseOrderDetailQuantityRec ;
      private int AV13ProductId ;
      private int A17ProductStock ;
      private int A69ProductMiniumStock ;
      private decimal A134PurchaseOrderDetailSuggestedPr ;
      private decimal A85ProductCostPrice ;
      private string scmdbuf ;
      private DateTime A135PurchaseOrderConfirmatedDate ;
      private DateTime A66PurchaseOrderClosedDate ;
      private bool AV15AllOk ;
      private bool n135PurchaseOrderConfirmatedDate ;
      private bool n66PurchaseOrderClosedDate ;
      private bool n134PurchaseOrderDetailSuggestedPr ;
      private bool returnInSub ;
      private bool n55ProductCode ;
      private bool n17ProductStock ;
      private bool n69ProductMiniumStock ;
      private bool n85ProductCostPrice ;
      private string A55ProductCode ;
      private string A16ProductName ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P001A2_A50PurchaseOrderId ;
      private int[] P001A2_A76PurchaseOrderDetailQuantityOrd ;
      private int[] P001A2_A61PurchaseOrderDetailId ;
      private int[] P001A2_A15ProductId ;
      private DateTime[] P001A2_A135PurchaseOrderConfirmatedDate ;
      private bool[] P001A2_n135PurchaseOrderConfirmatedDate ;
      private DateTime[] P001A2_A66PurchaseOrderClosedDate ;
      private bool[] P001A2_n66PurchaseOrderClosedDate ;
      private int[] P001A2_A77PurchaseOrderDetailQuantityRec ;
      private decimal[] P001A2_A134PurchaseOrderDetailSuggestedPr ;
      private bool[] P001A2_n134PurchaseOrderDetailSuggestedPr ;
      private int[] P001A3_A15ProductId ;
      private string[] P001A3_A55ProductCode ;
      private bool[] P001A3_n55ProductCode ;
      private int[] P001A3_A17ProductStock ;
      private bool[] P001A3_n17ProductStock ;
      private int[] P001A3_A69ProductMiniumStock ;
      private bool[] P001A3_n69ProductMiniumStock ;
      private string[] P001A3_A16ProductName ;
      private decimal[] P001A3_A85ProductCostPrice ;
      private bool[] P001A3_n85ProductCostPrice ;
      private GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem> aP1_Details ;
      private GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem> AV8Details ;
      private SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem AV11OneDetail ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession AV14Context ;
   }

   public class purchaseordercargedetails__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP001A2;
          prmP001A2 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmP001A3;
          prmP001A3 = new Object[] {
          new ParDef("@AV13ProductId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P001A2", "SELECT T1.[PurchaseOrderId], T1.[PurchaseOrderDetailQuantityOrd], T1.[PurchaseOrderDetailId], T1.[ProductId], T2.[PurchaseOrderConfirmatedDate], T2.[PurchaseOrderClosedDate], T1.[PurchaseOrderDetailQuantityRec], T1.[PurchaseOrderDetailSuggestedPr] FROM ([PurchaseOrderDetail] T1 INNER JOIN [PurchaseOrder] T2 ON T2.[PurchaseOrderId] = T1.[PurchaseOrderId]) WHERE T1.[PurchaseOrderId] = @PurchaseOrderId ORDER BY T1.[PurchaseOrderId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001A2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P001A3", "SELECT [ProductId], [ProductCode], [ProductStock], [ProductMiniumStock], [ProductName], [ProductCostPrice] FROM [Product] WHERE [ProductId] = @AV13ProductId ORDER BY [ProductId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001A3,1, GxCacheFrequency.OFF ,false,true )
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
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((int[]) buf[8])[0] = rslt.getInt(7);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                return;
       }
    }

 }

}
