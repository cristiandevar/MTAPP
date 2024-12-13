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
using GeneXus.Office;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class exportproductdetailwc : GXProcedure
   {
      public exportproductdetailwc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public exportproductdetailwc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_ProductId ,
                           out string aP1_Filename ,
                           out string aP2_ErrorMessage )
      {
         this.AV18ProductId = aP0_ProductId;
         this.AV10Filename = "" ;
         this.AV11ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP1_Filename=this.AV10Filename;
         aP2_ErrorMessage=this.AV11ErrorMessage;
      }

      public string executeUdp( int aP0_ProductId ,
                                out string aP1_Filename )
      {
         execute(aP0_ProductId, out aP1_Filename, out aP2_ErrorMessage);
         return AV11ErrorMessage ;
      }

      public void executeSubmit( int aP0_ProductId ,
                                 out string aP1_Filename ,
                                 out string aP2_ErrorMessage )
      {
         exportproductdetailwc objexportproductdetailwc;
         objexportproductdetailwc = new exportproductdetailwc();
         objexportproductdetailwc.AV18ProductId = aP0_ProductId;
         objexportproductdetailwc.AV10Filename = "" ;
         objexportproductdetailwc.AV11ErrorMessage = "" ;
         objexportproductdetailwc.context.SetSubmitInitialConfig(context);
         objexportproductdetailwc.initialize();
         Submit( executePrivateCatch,objexportproductdetailwc);
         aP1_Filename=this.AV10Filename;
         aP2_ErrorMessage=this.AV11ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((exportproductdetailwc)stateInfo).executePrivate();
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
         AV14Random = (int)(NumberUtil.Random( )*10000);
         AV10Filename = "ExportProductDetailWC-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV14Random), 8, 0)) + ".xlsx";
         AV9ExcelDocument.Open(AV10Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV9ExcelDocument.Clear();
         AV12CellRow = 1;
         AV13FirstColumn = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+0, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+0, 1, 1).Text = "Supplier Name";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+1, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+1, 1, 1).Text = "Created Date";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+2, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+2, 1, 1).Text = "Total Paid";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+3, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+3, 1, 1).Text = "Closed Date";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+4, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+4, 1, 1).Text = "Modified Date";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+5, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+5, 1, 1).Text = "Order Active";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+6, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+6, 1, 1).Text = "Confirmated Date";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+7, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+7, 1, 1).Text = "Canceled Description";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+8, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+8, 1, 1).Text = "Was Paid";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+9, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+9, 1, 1).Text = "Paid Date";
         /* Using cursor P001O2 */
         pr_default.execute(0, new Object[] {AV18ProductId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A50PurchaseOrderId = P001O2_A50PurchaseOrderId[0];
            A4SupplierId = P001O2_A4SupplierId[0];
            A15ProductId = P001O2_A15ProductId[0];
            A5SupplierName = P001O2_A5SupplierName[0];
            A52PurchaseOrderCreatedDate = P001O2_A52PurchaseOrderCreatedDate[0];
            A78PurchaseOrderTotalPaid = P001O2_A78PurchaseOrderTotalPaid[0];
            n78PurchaseOrderTotalPaid = P001O2_n78PurchaseOrderTotalPaid[0];
            A66PurchaseOrderClosedDate = P001O2_A66PurchaseOrderClosedDate[0];
            n66PurchaseOrderClosedDate = P001O2_n66PurchaseOrderClosedDate[0];
            A53PurchaseOrderModifiedDate = P001O2_A53PurchaseOrderModifiedDate[0];
            n53PurchaseOrderModifiedDate = P001O2_n53PurchaseOrderModifiedDate[0];
            A79PurchaseOrderActive = P001O2_A79PurchaseOrderActive[0];
            A135PurchaseOrderConfirmatedDate = P001O2_A135PurchaseOrderConfirmatedDate[0];
            n135PurchaseOrderConfirmatedDate = P001O2_n135PurchaseOrderConfirmatedDate[0];
            A136PurchaseOrderCanceledDescripti = P001O2_A136PurchaseOrderCanceledDescripti[0];
            n136PurchaseOrderCanceledDescripti = P001O2_n136PurchaseOrderCanceledDescripti[0];
            A138PurchaseOrderWasPaid = P001O2_A138PurchaseOrderWasPaid[0];
            n138PurchaseOrderWasPaid = P001O2_n138PurchaseOrderWasPaid[0];
            A139PurchaseOrderPaidDate = P001O2_A139PurchaseOrderPaidDate[0];
            n139PurchaseOrderPaidDate = P001O2_n139PurchaseOrderPaidDate[0];
            A61PurchaseOrderDetailId = P001O2_A61PurchaseOrderDetailId[0];
            A4SupplierId = P001O2_A4SupplierId[0];
            A52PurchaseOrderCreatedDate = P001O2_A52PurchaseOrderCreatedDate[0];
            A78PurchaseOrderTotalPaid = P001O2_A78PurchaseOrderTotalPaid[0];
            n78PurchaseOrderTotalPaid = P001O2_n78PurchaseOrderTotalPaid[0];
            A66PurchaseOrderClosedDate = P001O2_A66PurchaseOrderClosedDate[0];
            n66PurchaseOrderClosedDate = P001O2_n66PurchaseOrderClosedDate[0];
            A53PurchaseOrderModifiedDate = P001O2_A53PurchaseOrderModifiedDate[0];
            n53PurchaseOrderModifiedDate = P001O2_n53PurchaseOrderModifiedDate[0];
            A79PurchaseOrderActive = P001O2_A79PurchaseOrderActive[0];
            A135PurchaseOrderConfirmatedDate = P001O2_A135PurchaseOrderConfirmatedDate[0];
            n135PurchaseOrderConfirmatedDate = P001O2_n135PurchaseOrderConfirmatedDate[0];
            A136PurchaseOrderCanceledDescripti = P001O2_A136PurchaseOrderCanceledDescripti[0];
            n136PurchaseOrderCanceledDescripti = P001O2_n136PurchaseOrderCanceledDescripti[0];
            A138PurchaseOrderWasPaid = P001O2_A138PurchaseOrderWasPaid[0];
            n138PurchaseOrderWasPaid = P001O2_n138PurchaseOrderWasPaid[0];
            A139PurchaseOrderPaidDate = P001O2_A139PurchaseOrderPaidDate[0];
            n139PurchaseOrderPaidDate = P001O2_n139PurchaseOrderPaidDate[0];
            A5SupplierName = P001O2_A5SupplierName[0];
            AV12CellRow = (int)(AV12CellRow+1);
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+0, 1, 1).Text = A5SupplierName;
            GXt_dtime1 = DateTimeUtil.ResetTime( A52PurchaseOrderCreatedDate ) ;
            AV9ExcelDocument.SetDateFormat(context, 8, 5, 1, 2, "/", ":", " ");
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+1, 1, 1).Date = GXt_dtime1;
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+2, 1, 1).Number = (double)(A78PurchaseOrderTotalPaid);
            GXt_dtime1 = DateTimeUtil.ResetTime( A66PurchaseOrderClosedDate ) ;
            AV9ExcelDocument.SetDateFormat(context, 8, 5, 1, 2, "/", ":", " ");
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+3, 1, 1).Date = GXt_dtime1;
            GXt_dtime1 = DateTimeUtil.ResetTime( A53PurchaseOrderModifiedDate ) ;
            AV9ExcelDocument.SetDateFormat(context, 8, 5, 1, 2, "/", ":", " ");
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+4, 1, 1).Date = GXt_dtime1;
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+5, 1, 1).Text = StringUtil.BoolToStr( A79PurchaseOrderActive);
            GXt_dtime1 = DateTimeUtil.ResetTime( A135PurchaseOrderConfirmatedDate ) ;
            AV9ExcelDocument.SetDateFormat(context, 8, 5, 1, 2, "/", ":", " ");
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+6, 1, 1).Date = GXt_dtime1;
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+7, 1, 1).Text = A136PurchaseOrderCanceledDescripti;
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+8, 1, 1).Text = StringUtil.BoolToStr( A138PurchaseOrderWasPaid);
            GXt_dtime1 = DateTimeUtil.ResetTime( A139PurchaseOrderPaidDate ) ;
            AV9ExcelDocument.SetDateFormat(context, 8, 5, 1, 2, "/", ":", " ");
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+9, 1, 1).Date = GXt_dtime1;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV9ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV9ExcelDocument.Close();
         if ( AV16StorageProvider.GetPrivate(AV10Filename, AV15File, 1, AV17Messages) )
         {
            AV10Filename = AV15File.GetURI();
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV9ExcelDocument.ErrCode != 0 )
         {
            AV10Filename = "";
            AV11ErrorMessage = AV9ExcelDocument.ErrDescription;
            AV9ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
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
         AV10Filename = "";
         AV11ErrorMessage = "";
         AV9ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         P001O2_A50PurchaseOrderId = new int[1] ;
         P001O2_A4SupplierId = new int[1] ;
         P001O2_A15ProductId = new int[1] ;
         P001O2_A5SupplierName = new string[] {""} ;
         P001O2_A52PurchaseOrderCreatedDate = new DateTime[] {DateTime.MinValue} ;
         P001O2_A78PurchaseOrderTotalPaid = new decimal[1] ;
         P001O2_n78PurchaseOrderTotalPaid = new bool[] {false} ;
         P001O2_A66PurchaseOrderClosedDate = new DateTime[] {DateTime.MinValue} ;
         P001O2_n66PurchaseOrderClosedDate = new bool[] {false} ;
         P001O2_A53PurchaseOrderModifiedDate = new DateTime[] {DateTime.MinValue} ;
         P001O2_n53PurchaseOrderModifiedDate = new bool[] {false} ;
         P001O2_A79PurchaseOrderActive = new bool[] {false} ;
         P001O2_A135PurchaseOrderConfirmatedDate = new DateTime[] {DateTime.MinValue} ;
         P001O2_n135PurchaseOrderConfirmatedDate = new bool[] {false} ;
         P001O2_A136PurchaseOrderCanceledDescripti = new string[] {""} ;
         P001O2_n136PurchaseOrderCanceledDescripti = new bool[] {false} ;
         P001O2_A138PurchaseOrderWasPaid = new bool[] {false} ;
         P001O2_n138PurchaseOrderWasPaid = new bool[] {false} ;
         P001O2_A139PurchaseOrderPaidDate = new DateTime[] {DateTime.MinValue} ;
         P001O2_n139PurchaseOrderPaidDate = new bool[] {false} ;
         P001O2_A61PurchaseOrderDetailId = new int[1] ;
         A5SupplierName = "";
         A52PurchaseOrderCreatedDate = DateTime.MinValue;
         A66PurchaseOrderClosedDate = DateTime.MinValue;
         A53PurchaseOrderModifiedDate = DateTime.MinValue;
         A135PurchaseOrderConfirmatedDate = DateTime.MinValue;
         A136PurchaseOrderCanceledDescripti = "";
         A139PurchaseOrderPaidDate = DateTime.MinValue;
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         AV15File = new GxFile(context.GetPhysicalPath());
         AV17Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV16StorageProvider = new GxStorageProvider();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.exportproductdetailwc__default(),
            new Object[][] {
                new Object[] {
               P001O2_A50PurchaseOrderId, P001O2_A4SupplierId, P001O2_A15ProductId, P001O2_A5SupplierName, P001O2_A52PurchaseOrderCreatedDate, P001O2_A78PurchaseOrderTotalPaid, P001O2_n78PurchaseOrderTotalPaid, P001O2_A66PurchaseOrderClosedDate, P001O2_n66PurchaseOrderClosedDate, P001O2_A53PurchaseOrderModifiedDate,
               P001O2_n53PurchaseOrderModifiedDate, P001O2_A79PurchaseOrderActive, P001O2_A135PurchaseOrderConfirmatedDate, P001O2_n135PurchaseOrderConfirmatedDate, P001O2_A136PurchaseOrderCanceledDescripti, P001O2_n136PurchaseOrderCanceledDescripti, P001O2_A138PurchaseOrderWasPaid, P001O2_n138PurchaseOrderWasPaid, P001O2_A139PurchaseOrderPaidDate, P001O2_n139PurchaseOrderPaidDate,
               P001O2_A61PurchaseOrderDetailId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV18ProductId ;
      private int AV14Random ;
      private int AV12CellRow ;
      private int AV13FirstColumn ;
      private int A50PurchaseOrderId ;
      private int A4SupplierId ;
      private int A15ProductId ;
      private int A61PurchaseOrderDetailId ;
      private decimal A78PurchaseOrderTotalPaid ;
      private string scmdbuf ;
      private DateTime GXt_dtime1 ;
      private DateTime A52PurchaseOrderCreatedDate ;
      private DateTime A66PurchaseOrderClosedDate ;
      private DateTime A53PurchaseOrderModifiedDate ;
      private DateTime A135PurchaseOrderConfirmatedDate ;
      private DateTime A139PurchaseOrderPaidDate ;
      private bool returnInSub ;
      private bool n78PurchaseOrderTotalPaid ;
      private bool n66PurchaseOrderClosedDate ;
      private bool n53PurchaseOrderModifiedDate ;
      private bool A79PurchaseOrderActive ;
      private bool n135PurchaseOrderConfirmatedDate ;
      private bool n136PurchaseOrderCanceledDescripti ;
      private bool A138PurchaseOrderWasPaid ;
      private bool n138PurchaseOrderWasPaid ;
      private bool n139PurchaseOrderPaidDate ;
      private string AV10Filename ;
      private string AV11ErrorMessage ;
      private string A5SupplierName ;
      private string A136PurchaseOrderCanceledDescripti ;
      private GxStorageProvider AV16StorageProvider ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P001O2_A50PurchaseOrderId ;
      private int[] P001O2_A4SupplierId ;
      private int[] P001O2_A15ProductId ;
      private string[] P001O2_A5SupplierName ;
      private DateTime[] P001O2_A52PurchaseOrderCreatedDate ;
      private decimal[] P001O2_A78PurchaseOrderTotalPaid ;
      private bool[] P001O2_n78PurchaseOrderTotalPaid ;
      private DateTime[] P001O2_A66PurchaseOrderClosedDate ;
      private bool[] P001O2_n66PurchaseOrderClosedDate ;
      private DateTime[] P001O2_A53PurchaseOrderModifiedDate ;
      private bool[] P001O2_n53PurchaseOrderModifiedDate ;
      private bool[] P001O2_A79PurchaseOrderActive ;
      private DateTime[] P001O2_A135PurchaseOrderConfirmatedDate ;
      private bool[] P001O2_n135PurchaseOrderConfirmatedDate ;
      private string[] P001O2_A136PurchaseOrderCanceledDescripti ;
      private bool[] P001O2_n136PurchaseOrderCanceledDescripti ;
      private bool[] P001O2_A138PurchaseOrderWasPaid ;
      private bool[] P001O2_n138PurchaseOrderWasPaid ;
      private DateTime[] P001O2_A139PurchaseOrderPaidDate ;
      private bool[] P001O2_n139PurchaseOrderPaidDate ;
      private int[] P001O2_A61PurchaseOrderDetailId ;
      private string aP1_Filename ;
      private string aP2_ErrorMessage ;
      private ExcelDocumentI AV9ExcelDocument ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV17Messages ;
      private GxFile AV15File ;
   }

   public class exportproductdetailwc__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP001O2;
          prmP001O2 = new Object[] {
          new ParDef("@AV18ProductId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P001O2", "SELECT T1.[PurchaseOrderId], T2.[SupplierId], T1.[ProductId], T3.[SupplierName], T2.[PurchaseOrderCreatedDate], T2.[PurchaseOrderTotalPaid], T2.[PurchaseOrderClosedDate], T2.[PurchaseOrderModifiedDate], T2.[PurchaseOrderActive], T2.[PurchaseOrderConfirmatedDate], T2.[PurchaseOrderCanceledDescripti], T2.[PurchaseOrderWasPaid], T2.[PurchaseOrderPaidDate], T1.[PurchaseOrderDetailId] FROM (([PurchaseOrderDetail] T1 INNER JOIN [PurchaseOrder] T2 ON T2.[PurchaseOrderId] = T1.[PurchaseOrderId]) INNER JOIN [Supplier] T3 ON T3.[SupplierId] = T2.[SupplierId]) WHERE T1.[ProductId] = @AV18ProductId ORDER BY T1.[ProductId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001O2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((bool[]) buf[11])[0] = rslt.getBool(9);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(10);
                ((bool[]) buf[13])[0] = rslt.wasNull(10);
                ((string[]) buf[14])[0] = rslt.getVarchar(11);
                ((bool[]) buf[15])[0] = rslt.wasNull(11);
                ((bool[]) buf[16])[0] = rslt.getBool(12);
                ((bool[]) buf[17])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[18])[0] = rslt.getGXDate(13);
                ((bool[]) buf[19])[0] = rslt.wasNull(13);
                ((int[]) buf[20])[0] = rslt.getInt(14);
                return;
       }
    }

 }

}
