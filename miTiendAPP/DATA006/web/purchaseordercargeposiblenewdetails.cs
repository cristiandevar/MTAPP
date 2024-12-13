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
   public class purchaseordercargeposiblenewdetails : GXProcedure
   {
      public purchaseordercargeposiblenewdetails( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public purchaseordercargeposiblenewdetails( IGxContext context )
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
         purchaseordercargeposiblenewdetails objpurchaseordercargeposiblenewdetails;
         objpurchaseordercargeposiblenewdetails = new purchaseordercargeposiblenewdetails();
         objpurchaseordercargeposiblenewdetails.A50PurchaseOrderId = aP0_PurchaseOrderId;
         objpurchaseordercargeposiblenewdetails.AV8Details = new GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem>( context, "SDTPurchaseOrderDetailsItem", "mtaKB") ;
         objpurchaseordercargeposiblenewdetails.context.SetSubmitInitialConfig(context);
         objpurchaseordercargeposiblenewdetails.initialize();
         Submit( executePrivateCatch,objpurchaseordercargeposiblenewdetails);
         aP1_Details=this.AV8Details;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((purchaseordercargeposiblenewdetails)stateInfo).executePrivate();
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
         new getcontext(context ).execute( out  AV13Context, ref  AV14AllOk) ;
         if ( ! AV14AllOk )
         {
            CallWebObject(formatLink("wplogin.aspx") );
            context.wjLocDisableFrm = 1;
         }
         /* Using cursor P001B2 */
         pr_default.execute(0, new Object[] {A50PurchaseOrderId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A15ProductId = P001B2_A15ProductId[0];
            A61PurchaseOrderDetailId = P001B2_A61PurchaseOrderDetailId[0];
            AV10ProductId = A15ProductId;
            AV11ProductIds.Add(AV10ProductId, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV12PurchaseOrder = new SdtPurchaseOrder(context);
         AV12PurchaseOrder.Load(A50PurchaseOrderId);
         AV8Details = new GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem>( context, "SDTPurchaseOrderDetailsItem", "mtaKB");
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A15ProductId ,
                                              AV11ProductIds ,
                                              AV12PurchaseOrder.gxTpr_Supplierid ,
                                              A4SupplierId } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         /* Using cursor P001B3 */
         pr_default.execute(1, new Object[] {AV12PurchaseOrder.gxTpr_Supplierid});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A15ProductId = P001B3_A15ProductId[0];
            A4SupplierId = P001B3_A4SupplierId[0];
            A55ProductCode = P001B3_A55ProductCode[0];
            n55ProductCode = P001B3_n55ProductCode[0];
            A16ProductName = P001B3_A16ProductName[0];
            A17ProductStock = P001B3_A17ProductStock[0];
            n17ProductStock = P001B3_n17ProductStock[0];
            A69ProductMiniumStock = P001B3_A69ProductMiniumStock[0];
            n69ProductMiniumStock = P001B3_n69ProductMiniumStock[0];
            AV9OneDetail = new SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem(context);
            AV9OneDetail.gxTpr_Id = A15ProductId;
            AV9OneDetail.gxTpr_Code = A55ProductCode;
            AV9OneDetail.gxTpr_Name = A16ProductName;
            AV9OneDetail.gxTpr_Currentstock = A17ProductStock;
            AV9OneDetail.gxTpr_Miniumstock = A69ProductMiniumStock;
            AV9OneDetail.gxTpr_Quantityordered = A69ProductMiniumStock;
            AV9OneDetail.gxTpr_Quantityreceived = 0;
            AV9OneDetail.gxTpr_Subtotal = (decimal)(0);
            AV8Details.Add(AV9OneDetail, 0);
            pr_default.readNext(1);
         }
         pr_default.close(1);
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
         AV8Details = new GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem>( context, "SDTPurchaseOrderDetailsItem", "mtaKB");
         AV13Context = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         scmdbuf = "";
         P001B2_A50PurchaseOrderId = new int[1] ;
         P001B2_A15ProductId = new int[1] ;
         P001B2_A61PurchaseOrderDetailId = new int[1] ;
         AV11ProductIds = new GxSimpleCollection<int>();
         AV12PurchaseOrder = new SdtPurchaseOrder(context);
         P001B3_A15ProductId = new int[1] ;
         P001B3_A4SupplierId = new int[1] ;
         P001B3_A55ProductCode = new string[] {""} ;
         P001B3_n55ProductCode = new bool[] {false} ;
         P001B3_A16ProductName = new string[] {""} ;
         P001B3_A17ProductStock = new int[1] ;
         P001B3_n17ProductStock = new bool[] {false} ;
         P001B3_A69ProductMiniumStock = new int[1] ;
         P001B3_n69ProductMiniumStock = new bool[] {false} ;
         A55ProductCode = "";
         A16ProductName = "";
         AV9OneDetail = new SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.purchaseordercargeposiblenewdetails__default(),
            new Object[][] {
                new Object[] {
               P001B2_A50PurchaseOrderId, P001B2_A15ProductId, P001B2_A61PurchaseOrderDetailId
               }
               , new Object[] {
               P001B3_A15ProductId, P001B3_A4SupplierId, P001B3_A55ProductCode, P001B3_n55ProductCode, P001B3_A16ProductName, P001B3_A17ProductStock, P001B3_n17ProductStock, P001B3_A69ProductMiniumStock, P001B3_n69ProductMiniumStock
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int A50PurchaseOrderId ;
      private int A15ProductId ;
      private int A61PurchaseOrderDetailId ;
      private int AV10ProductId ;
      private int AV12PurchaseOrder_gxTpr_Supplierid ;
      private int A4SupplierId ;
      private int A17ProductStock ;
      private int A69ProductMiniumStock ;
      private string scmdbuf ;
      private bool AV14AllOk ;
      private bool n55ProductCode ;
      private bool n17ProductStock ;
      private bool n69ProductMiniumStock ;
      private string A55ProductCode ;
      private string A16ProductName ;
      private GxSimpleCollection<int> AV11ProductIds ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P001B2_A50PurchaseOrderId ;
      private int[] P001B2_A15ProductId ;
      private int[] P001B2_A61PurchaseOrderDetailId ;
      private int[] P001B3_A15ProductId ;
      private int[] P001B3_A4SupplierId ;
      private string[] P001B3_A55ProductCode ;
      private bool[] P001B3_n55ProductCode ;
      private string[] P001B3_A16ProductName ;
      private int[] P001B3_A17ProductStock ;
      private bool[] P001B3_n17ProductStock ;
      private int[] P001B3_A69ProductMiniumStock ;
      private bool[] P001B3_n69ProductMiniumStock ;
      private GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem> aP1_Details ;
      private GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem> AV8Details ;
      private SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem AV9OneDetail ;
      private SdtPurchaseOrder AV12PurchaseOrder ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession AV13Context ;
   }

   public class purchaseordercargeposiblenewdetails__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P001B3( IGxContext context ,
                                             int A15ProductId ,
                                             GxSimpleCollection<int> AV11ProductIds ,
                                             int AV12PurchaseOrder_gxTpr_Supplierid ,
                                             int A4SupplierId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [ProductId], [SupplierId], [ProductCode], [ProductName], [ProductStock], [ProductMiniumStock] FROM [Product]";
         AddWhere(sWhereString, "([SupplierId] = @AV12PurchaseOrder__Supplierid)");
         AddWhere(sWhereString, "(Not "+new GxDbmsUtils( new GxSqlServer()).ValueList(AV11ProductIds, "[ProductId] IN (", ")")+")");
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [SupplierId]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_P001B3(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmP001B2;
          prmP001B2 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmP001B3;
          prmP001B3 = new Object[] {
          new ParDef("@AV12PurchaseOrder__Supplierid",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P001B2", "SELECT [PurchaseOrderId], [ProductId], [PurchaseOrderDetailId] FROM [PurchaseOrderDetail] WHERE [PurchaseOrderId] = @PurchaseOrderId ORDER BY [PurchaseOrderId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001B2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P001B3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001B3,100, GxCacheFrequency.OFF ,false,false )
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
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((int[]) buf[7])[0] = rslt.getInt(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                return;
       }
    }

 }

}
