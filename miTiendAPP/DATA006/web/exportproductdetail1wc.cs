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
   public class exportproductdetail1wc : GXProcedure
   {
      public exportproductdetail1wc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public exportproductdetail1wc( IGxContext context )
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
         exportproductdetail1wc objexportproductdetail1wc;
         objexportproductdetail1wc = new exportproductdetail1wc();
         objexportproductdetail1wc.AV18ProductId = aP0_ProductId;
         objexportproductdetail1wc.AV10Filename = "" ;
         objexportproductdetail1wc.AV11ErrorMessage = "" ;
         objexportproductdetail1wc.context.SetSubmitInitialConfig(context);
         objexportproductdetail1wc.initialize();
         Submit( executePrivateCatch,objexportproductdetail1wc);
         aP1_Filename=this.AV10Filename;
         aP2_ErrorMessage=this.AV11ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((exportproductdetail1wc)stateInfo).executePrivate();
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
         AV10Filename = "ExportProductDetail1WC-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV14Random), 8, 0)) + ".xlsx";
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
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+0, 1, 1).Text = "Created Date";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+1, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+1, 1, 1).Text = "User Name";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+2, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+2, 1, 1).Text = "Modified Date";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+3, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+3, 1, 1).Text = "Active";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+4, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+4, 1, 1).Text = "Total Receivable";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+5, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+5, 1, 1).Text = "Product Quantity";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+6, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+6, 1, 1).Text = "Method Id";
         /* Using cursor P001P7 */
         pr_default.execute(0, new Object[] {AV18ProductId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A20InvoiceId = P001P7_A20InvoiceId[0];
            A99UserId = P001P7_A99UserId[0];
            A15ProductId = P001P7_A15ProductId[0];
            A38InvoiceCreatedDate = P001P7_A38InvoiceCreatedDate[0];
            A100UserName = P001P7_A100UserName[0];
            A39InvoiceModifiedDate = P001P7_A39InvoiceModifiedDate[0];
            n39InvoiceModifiedDate = P001P7_n39InvoiceModifiedDate[0];
            A94InvoiceActive = P001P7_A94InvoiceActive[0];
            A80InvoiceTotalReceivable = P001P7_A80InvoiceTotalReceivable[0];
            n80InvoiceTotalReceivable = P001P7_n80InvoiceTotalReceivable[0];
            A68InvoiceProductQuantity = P001P7_A68InvoiceProductQuantity[0];
            n68InvoiceProductQuantity = P001P7_n68InvoiceProductQuantity[0];
            A131InvoiceLastPaymentMethodId = P001P7_A131InvoiceLastPaymentMethodId[0];
            n131InvoiceLastPaymentMethodId = P001P7_n131InvoiceLastPaymentMethodId[0];
            A25InvoiceDetailId = P001P7_A25InvoiceDetailId[0];
            A99UserId = P001P7_A99UserId[0];
            A38InvoiceCreatedDate = P001P7_A38InvoiceCreatedDate[0];
            A39InvoiceModifiedDate = P001P7_A39InvoiceModifiedDate[0];
            n39InvoiceModifiedDate = P001P7_n39InvoiceModifiedDate[0];
            A94InvoiceActive = P001P7_A94InvoiceActive[0];
            A100UserName = P001P7_A100UserName[0];
            A80InvoiceTotalReceivable = P001P7_A80InvoiceTotalReceivable[0];
            n80InvoiceTotalReceivable = P001P7_n80InvoiceTotalReceivable[0];
            A68InvoiceProductQuantity = P001P7_A68InvoiceProductQuantity[0];
            n68InvoiceProductQuantity = P001P7_n68InvoiceProductQuantity[0];
            A131InvoiceLastPaymentMethodId = P001P7_A131InvoiceLastPaymentMethodId[0];
            n131InvoiceLastPaymentMethodId = P001P7_n131InvoiceLastPaymentMethodId[0];
            AV12CellRow = (int)(AV12CellRow+1);
            GXt_dtime1 = DateTimeUtil.ResetTime( A38InvoiceCreatedDate ) ;
            AV9ExcelDocument.SetDateFormat(context, 8, 5, 1, 2, "/", ":", " ");
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+0, 1, 1).Date = GXt_dtime1;
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+1, 1, 1).Text = A100UserName;
            GXt_dtime1 = DateTimeUtil.ResetTime( A39InvoiceModifiedDate ) ;
            AV9ExcelDocument.SetDateFormat(context, 8, 5, 1, 2, "/", ":", " ");
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+2, 1, 1).Date = GXt_dtime1;
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+3, 1, 1).Text = StringUtil.BoolToStr( A94InvoiceActive);
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+4, 1, 1).Number = (double)(A80InvoiceTotalReceivable);
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+5, 1, 1).Number = A68InvoiceProductQuantity;
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+6, 1, 1).Number = A131InvoiceLastPaymentMethodId;
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
         P001P7_A20InvoiceId = new int[1] ;
         P001P7_A99UserId = new int[1] ;
         P001P7_A15ProductId = new int[1] ;
         P001P7_A38InvoiceCreatedDate = new DateTime[] {DateTime.MinValue} ;
         P001P7_A100UserName = new string[] {""} ;
         P001P7_A39InvoiceModifiedDate = new DateTime[] {DateTime.MinValue} ;
         P001P7_n39InvoiceModifiedDate = new bool[] {false} ;
         P001P7_A94InvoiceActive = new bool[] {false} ;
         P001P7_A80InvoiceTotalReceivable = new decimal[1] ;
         P001P7_n80InvoiceTotalReceivable = new bool[] {false} ;
         P001P7_A68InvoiceProductQuantity = new short[1] ;
         P001P7_n68InvoiceProductQuantity = new bool[] {false} ;
         P001P7_A131InvoiceLastPaymentMethodId = new int[1] ;
         P001P7_n131InvoiceLastPaymentMethodId = new bool[] {false} ;
         P001P7_A25InvoiceDetailId = new int[1] ;
         A38InvoiceCreatedDate = DateTime.MinValue;
         A100UserName = "";
         A39InvoiceModifiedDate = DateTime.MinValue;
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         AV15File = new GxFile(context.GetPhysicalPath());
         AV17Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV16StorageProvider = new GxStorageProvider();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.exportproductdetail1wc__default(),
            new Object[][] {
                new Object[] {
               P001P7_A20InvoiceId, P001P7_A99UserId, P001P7_A15ProductId, P001P7_A38InvoiceCreatedDate, P001P7_A100UserName, P001P7_A39InvoiceModifiedDate, P001P7_n39InvoiceModifiedDate, P001P7_A94InvoiceActive, P001P7_A80InvoiceTotalReceivable, P001P7_n80InvoiceTotalReceivable,
               P001P7_A68InvoiceProductQuantity, P001P7_n68InvoiceProductQuantity, P001P7_A131InvoiceLastPaymentMethodId, P001P7_n131InvoiceLastPaymentMethodId, P001P7_A25InvoiceDetailId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A68InvoiceProductQuantity ;
      private int AV18ProductId ;
      private int AV14Random ;
      private int AV12CellRow ;
      private int AV13FirstColumn ;
      private int A20InvoiceId ;
      private int A99UserId ;
      private int A15ProductId ;
      private int A131InvoiceLastPaymentMethodId ;
      private int A25InvoiceDetailId ;
      private decimal A80InvoiceTotalReceivable ;
      private string scmdbuf ;
      private DateTime GXt_dtime1 ;
      private DateTime A38InvoiceCreatedDate ;
      private DateTime A39InvoiceModifiedDate ;
      private bool returnInSub ;
      private bool n39InvoiceModifiedDate ;
      private bool A94InvoiceActive ;
      private bool n80InvoiceTotalReceivable ;
      private bool n68InvoiceProductQuantity ;
      private bool n131InvoiceLastPaymentMethodId ;
      private string AV10Filename ;
      private string AV11ErrorMessage ;
      private string A100UserName ;
      private GxStorageProvider AV16StorageProvider ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P001P7_A20InvoiceId ;
      private int[] P001P7_A99UserId ;
      private int[] P001P7_A15ProductId ;
      private DateTime[] P001P7_A38InvoiceCreatedDate ;
      private string[] P001P7_A100UserName ;
      private DateTime[] P001P7_A39InvoiceModifiedDate ;
      private bool[] P001P7_n39InvoiceModifiedDate ;
      private bool[] P001P7_A94InvoiceActive ;
      private decimal[] P001P7_A80InvoiceTotalReceivable ;
      private bool[] P001P7_n80InvoiceTotalReceivable ;
      private short[] P001P7_A68InvoiceProductQuantity ;
      private bool[] P001P7_n68InvoiceProductQuantity ;
      private int[] P001P7_A131InvoiceLastPaymentMethodId ;
      private bool[] P001P7_n131InvoiceLastPaymentMethodId ;
      private int[] P001P7_A25InvoiceDetailId ;
      private string aP1_Filename ;
      private string aP2_ErrorMessage ;
      private ExcelDocumentI AV9ExcelDocument ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV17Messages ;
      private GxFile AV15File ;
   }

   public class exportproductdetail1wc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP001P7;
          prmP001P7 = new Object[] {
          new ParDef("@AV18ProductId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P001P7", "SELECT T1.[InvoiceId], T2.[UserId], T1.[ProductId], T2.[InvoiceCreatedDate], T3.[UserName], T2.[InvoiceModifiedDate], T2.[InvoiceActive], COALESCE( T4.[InvoiceTotalReceivable], 0) AS InvoiceTotalReceivable, COALESCE( T5.[InvoiceProductQuantity], 0) AS InvoiceProductQuantity, COALESCE( T6.[InvoiceLastPaymentMethodId], 0) AS InvoiceLastPaymentMethodId, T1.[InvoiceDetailId] FROM ((((([InvoiceDetail] T1 INNER JOIN [Invoice] T2 ON T2.[InvoiceId] = T1.[InvoiceId]) INNER JOIN [User] T3 ON T3.[UserId] = T2.[UserId]) INNER JOIN (SELECT COALESCE( T9.[GXC1], 0) - COALESCE( T8.[GXC2], 0) + COALESCE( T8.[GXC3], 0) AS InvoiceTotalReceivable, T7.[InvoiceId] FROM (([Invoice] T7 LEFT JOIN (SELECT SUM([InvoicePaymentMethodDiscountIm]) AS GXC2, [InvoiceId], SUM([InvoicePaymentMethodRechargeIm]) AS GXC3 FROM [InvoicePaymentMethod] GROUP BY [InvoiceId] ) T8 ON T8.[InvoiceId] = T7.[InvoiceId]) LEFT JOIN (SELECT SUM([InvoiceDetailQuantity] * CAST([InvoiceDetailHistoricPrice] AS decimal( 28, 10))) AS GXC1, [InvoiceId] FROM [InvoiceDetail] GROUP BY [InvoiceId] ) T9 ON T9.[InvoiceId] = T7.[InvoiceId]) ) T4 ON T4.[InvoiceId] = T1.[InvoiceId]) LEFT JOIN (SELECT COUNT(*) AS InvoiceProductQuantity, [InvoiceId] FROM [InvoiceDetail] GROUP BY [InvoiceId] ) T5 ON T5.[InvoiceId] = T1.[InvoiceId]) LEFT JOIN (SELECT MAX([InvoicePaymentMethodId]) AS InvoiceLastPaymentMethodId, [InvoiceId] FROM [InvoicePaymentMethod] GROUP BY [InvoiceId] ) T6 ON T6.[InvoiceId] = T1.[InvoiceId]) WHERE T1.[ProductId] = @AV18ProductId ORDER BY T1.[ProductId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001P7,100, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((bool[]) buf[7])[0] = rslt.getBool(7);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((short[]) buf[10])[0] = rslt.getShort(9);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((int[]) buf[12])[0] = rslt.getInt(10);
                ((bool[]) buf[13])[0] = rslt.wasNull(10);
                ((int[]) buf[14])[0] = rslt.getInt(11);
                return;
       }
    }

 }

}
