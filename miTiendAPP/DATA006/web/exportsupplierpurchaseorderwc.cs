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
   public class exportsupplierpurchaseorderwc : GXProcedure
   {
      public exportsupplierpurchaseorderwc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public exportsupplierpurchaseorderwc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_SupplierId ,
                           out string aP1_Filename ,
                           out string aP2_ErrorMessage )
      {
         this.AV18SupplierId = aP0_SupplierId;
         this.AV10Filename = "" ;
         this.AV11ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP1_Filename=this.AV10Filename;
         aP2_ErrorMessage=this.AV11ErrorMessage;
      }

      public string executeUdp( int aP0_SupplierId ,
                                out string aP1_Filename )
      {
         execute(aP0_SupplierId, out aP1_Filename, out aP2_ErrorMessage);
         return AV11ErrorMessage ;
      }

      public void executeSubmit( int aP0_SupplierId ,
                                 out string aP1_Filename ,
                                 out string aP2_ErrorMessage )
      {
         exportsupplierpurchaseorderwc objexportsupplierpurchaseorderwc;
         objexportsupplierpurchaseorderwc = new exportsupplierpurchaseorderwc();
         objexportsupplierpurchaseorderwc.AV18SupplierId = aP0_SupplierId;
         objexportsupplierpurchaseorderwc.AV10Filename = "" ;
         objexportsupplierpurchaseorderwc.AV11ErrorMessage = "" ;
         objexportsupplierpurchaseorderwc.context.SetSubmitInitialConfig(context);
         objexportsupplierpurchaseorderwc.initialize();
         Submit( executePrivateCatch,objexportsupplierpurchaseorderwc);
         aP1_Filename=this.AV10Filename;
         aP2_ErrorMessage=this.AV11ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((exportsupplierpurchaseorderwc)stateInfo).executePrivate();
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
         AV10Filename = "ExportSupplierPurchaseOrderWC-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV14Random), 8, 0)) + ".xlsx";
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
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+1, 1, 1).Text = "Modified Date";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+2, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+2, 1, 1).Text = "Closed Date";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+3, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+3, 1, 1).Text = "Total Paid";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+4, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+4, 1, 1).Text = "Order Active";
         /* Using cursor P001Q2 */
         pr_default.execute(0, new Object[] {AV18SupplierId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A4SupplierId = P001Q2_A4SupplierId[0];
            A52PurchaseOrderCreatedDate = P001Q2_A52PurchaseOrderCreatedDate[0];
            A53PurchaseOrderModifiedDate = P001Q2_A53PurchaseOrderModifiedDate[0];
            n53PurchaseOrderModifiedDate = P001Q2_n53PurchaseOrderModifiedDate[0];
            A66PurchaseOrderClosedDate = P001Q2_A66PurchaseOrderClosedDate[0];
            n66PurchaseOrderClosedDate = P001Q2_n66PurchaseOrderClosedDate[0];
            A78PurchaseOrderTotalPaid = P001Q2_A78PurchaseOrderTotalPaid[0];
            n78PurchaseOrderTotalPaid = P001Q2_n78PurchaseOrderTotalPaid[0];
            A79PurchaseOrderActive = P001Q2_A79PurchaseOrderActive[0];
            A50PurchaseOrderId = P001Q2_A50PurchaseOrderId[0];
            AV12CellRow = (int)(AV12CellRow+1);
            GXt_dtime1 = DateTimeUtil.ResetTime( A52PurchaseOrderCreatedDate ) ;
            AV9ExcelDocument.SetDateFormat(context, 8, 5, 1, 2, "/", ":", " ");
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+0, 1, 1).Date = GXt_dtime1;
            GXt_dtime1 = DateTimeUtil.ResetTime( A53PurchaseOrderModifiedDate ) ;
            AV9ExcelDocument.SetDateFormat(context, 8, 5, 1, 2, "/", ":", " ");
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+1, 1, 1).Date = GXt_dtime1;
            GXt_dtime1 = DateTimeUtil.ResetTime( A66PurchaseOrderClosedDate ) ;
            AV9ExcelDocument.SetDateFormat(context, 8, 5, 1, 2, "/", ":", " ");
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+2, 1, 1).Date = GXt_dtime1;
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+3, 1, 1).Number = (double)(A78PurchaseOrderTotalPaid);
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+4, 1, 1).Text = StringUtil.BoolToStr( A79PurchaseOrderActive);
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
         P001Q2_A4SupplierId = new int[1] ;
         P001Q2_A52PurchaseOrderCreatedDate = new DateTime[] {DateTime.MinValue} ;
         P001Q2_A53PurchaseOrderModifiedDate = new DateTime[] {DateTime.MinValue} ;
         P001Q2_n53PurchaseOrderModifiedDate = new bool[] {false} ;
         P001Q2_A66PurchaseOrderClosedDate = new DateTime[] {DateTime.MinValue} ;
         P001Q2_n66PurchaseOrderClosedDate = new bool[] {false} ;
         P001Q2_A78PurchaseOrderTotalPaid = new decimal[1] ;
         P001Q2_n78PurchaseOrderTotalPaid = new bool[] {false} ;
         P001Q2_A79PurchaseOrderActive = new bool[] {false} ;
         P001Q2_A50PurchaseOrderId = new int[1] ;
         A52PurchaseOrderCreatedDate = DateTime.MinValue;
         A53PurchaseOrderModifiedDate = DateTime.MinValue;
         A66PurchaseOrderClosedDate = DateTime.MinValue;
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         AV15File = new GxFile(context.GetPhysicalPath());
         AV17Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV16StorageProvider = new GxStorageProvider();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.exportsupplierpurchaseorderwc__default(),
            new Object[][] {
                new Object[] {
               P001Q2_A4SupplierId, P001Q2_A52PurchaseOrderCreatedDate, P001Q2_A53PurchaseOrderModifiedDate, P001Q2_n53PurchaseOrderModifiedDate, P001Q2_A66PurchaseOrderClosedDate, P001Q2_n66PurchaseOrderClosedDate, P001Q2_A78PurchaseOrderTotalPaid, P001Q2_n78PurchaseOrderTotalPaid, P001Q2_A79PurchaseOrderActive, P001Q2_A50PurchaseOrderId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV18SupplierId ;
      private int AV14Random ;
      private int AV12CellRow ;
      private int AV13FirstColumn ;
      private int A4SupplierId ;
      private int A50PurchaseOrderId ;
      private decimal A78PurchaseOrderTotalPaid ;
      private string scmdbuf ;
      private DateTime GXt_dtime1 ;
      private DateTime A52PurchaseOrderCreatedDate ;
      private DateTime A53PurchaseOrderModifiedDate ;
      private DateTime A66PurchaseOrderClosedDate ;
      private bool returnInSub ;
      private bool n53PurchaseOrderModifiedDate ;
      private bool n66PurchaseOrderClosedDate ;
      private bool n78PurchaseOrderTotalPaid ;
      private bool A79PurchaseOrderActive ;
      private string AV10Filename ;
      private string AV11ErrorMessage ;
      private GxStorageProvider AV16StorageProvider ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P001Q2_A4SupplierId ;
      private DateTime[] P001Q2_A52PurchaseOrderCreatedDate ;
      private DateTime[] P001Q2_A53PurchaseOrderModifiedDate ;
      private bool[] P001Q2_n53PurchaseOrderModifiedDate ;
      private DateTime[] P001Q2_A66PurchaseOrderClosedDate ;
      private bool[] P001Q2_n66PurchaseOrderClosedDate ;
      private decimal[] P001Q2_A78PurchaseOrderTotalPaid ;
      private bool[] P001Q2_n78PurchaseOrderTotalPaid ;
      private bool[] P001Q2_A79PurchaseOrderActive ;
      private int[] P001Q2_A50PurchaseOrderId ;
      private string aP1_Filename ;
      private string aP2_ErrorMessage ;
      private ExcelDocumentI AV9ExcelDocument ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV17Messages ;
      private GxFile AV15File ;
   }

   public class exportsupplierpurchaseorderwc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP001Q2;
          prmP001Q2 = new Object[] {
          new ParDef("@AV18SupplierId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P001Q2", "SELECT [SupplierId], [PurchaseOrderCreatedDate], [PurchaseOrderModifiedDate], [PurchaseOrderClosedDate], [PurchaseOrderTotalPaid], [PurchaseOrderActive], [PurchaseOrderId] FROM [PurchaseOrder] WHERE [SupplierId] = @AV18SupplierId ORDER BY [SupplierId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001Q2,100, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((bool[]) buf[8])[0] = rslt.getBool(6);
                ((int[]) buf[9])[0] = rslt.getInt(7);
                return;
       }
    }

 }

}
