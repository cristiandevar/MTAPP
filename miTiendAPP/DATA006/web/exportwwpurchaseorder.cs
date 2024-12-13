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
   public class exportwwpurchaseorder : GXProcedure
   {
      public exportwwpurchaseorder( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public exportwwpurchaseorder( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_PurchaseOrderId ,
                           int aP1_SupplierId ,
                           string aP2_PurchaseOrderState ,
                           DateTime aP3_CreatedDateFrom ,
                           DateTime aP4_CreatedDateTo ,
                           DateTime aP5_ClosedDateFrom ,
                           DateTime aP6_ClosedDateTo ,
                           short aP7_OrderedBy ,
                           out string aP8_Filename ,
                           out string aP9_ErrorMessage )
      {
         this.AV39PurchaseOrderId = aP0_PurchaseOrderId;
         this.AV40SupplierId = aP1_SupplierId;
         this.AV19PurchaseOrderState = aP2_PurchaseOrderState;
         this.AV21CreatedDateFrom = aP3_CreatedDateFrom;
         this.AV22CreatedDateTo = aP4_CreatedDateTo;
         this.AV23ClosedDateFrom = aP5_ClosedDateFrom;
         this.AV24ClosedDateTo = aP6_ClosedDateTo;
         this.AV20OrderedBy = aP7_OrderedBy;
         this.AV10Filename = "" ;
         this.AV11ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP8_Filename=this.AV10Filename;
         aP9_ErrorMessage=this.AV11ErrorMessage;
      }

      public string executeUdp( int aP0_PurchaseOrderId ,
                                int aP1_SupplierId ,
                                string aP2_PurchaseOrderState ,
                                DateTime aP3_CreatedDateFrom ,
                                DateTime aP4_CreatedDateTo ,
                                DateTime aP5_ClosedDateFrom ,
                                DateTime aP6_ClosedDateTo ,
                                short aP7_OrderedBy ,
                                out string aP8_Filename )
      {
         execute(aP0_PurchaseOrderId, aP1_SupplierId, aP2_PurchaseOrderState, aP3_CreatedDateFrom, aP4_CreatedDateTo, aP5_ClosedDateFrom, aP6_ClosedDateTo, aP7_OrderedBy, out aP8_Filename, out aP9_ErrorMessage);
         return AV11ErrorMessage ;
      }

      public void executeSubmit( int aP0_PurchaseOrderId ,
                                 int aP1_SupplierId ,
                                 string aP2_PurchaseOrderState ,
                                 DateTime aP3_CreatedDateFrom ,
                                 DateTime aP4_CreatedDateTo ,
                                 DateTime aP5_ClosedDateFrom ,
                                 DateTime aP6_ClosedDateTo ,
                                 short aP7_OrderedBy ,
                                 out string aP8_Filename ,
                                 out string aP9_ErrorMessage )
      {
         exportwwpurchaseorder objexportwwpurchaseorder;
         objexportwwpurchaseorder = new exportwwpurchaseorder();
         objexportwwpurchaseorder.AV39PurchaseOrderId = aP0_PurchaseOrderId;
         objexportwwpurchaseorder.AV40SupplierId = aP1_SupplierId;
         objexportwwpurchaseorder.AV19PurchaseOrderState = aP2_PurchaseOrderState;
         objexportwwpurchaseorder.AV21CreatedDateFrom = aP3_CreatedDateFrom;
         objexportwwpurchaseorder.AV22CreatedDateTo = aP4_CreatedDateTo;
         objexportwwpurchaseorder.AV23ClosedDateFrom = aP5_ClosedDateFrom;
         objexportwwpurchaseorder.AV24ClosedDateTo = aP6_ClosedDateTo;
         objexportwwpurchaseorder.AV20OrderedBy = aP7_OrderedBy;
         objexportwwpurchaseorder.AV10Filename = "" ;
         objexportwwpurchaseorder.AV11ErrorMessage = "" ;
         objexportwwpurchaseorder.context.SetSubmitInitialConfig(context);
         objexportwwpurchaseorder.initialize();
         Submit( executePrivateCatch,objexportwwpurchaseorder);
         aP8_Filename=this.AV10Filename;
         aP9_ErrorMessage=this.AV11ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((exportwwpurchaseorder)stateInfo).executePrivate();
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
         /* Execute user subroutine: 'OPENDOCUMENT' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV12CellRow = 1;
         AV13FirstColumn = 1;
         /* Execute user subroutine: 'WRITETITLE' */
         S141 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV12CellRow = (int)(AV12CellRow+3);
         /* Execute user subroutine: 'WRITEFILTERS' */
         S131 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( AV12CellRow > 4 )
         {
            AV12CellRow = (int)(AV12CellRow+1);
         }
         /* Execute user subroutine: 'WRITECOLUMNS' */
         S151 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV12CellRow = (int)(AV12CellRow+1);
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV19PurchaseOrderState ,
                                              AV21CreatedDateFrom ,
                                              AV22CreatedDateTo ,
                                              AV23ClosedDateFrom ,
                                              AV24ClosedDateTo ,
                                              AV39PurchaseOrderId ,
                                              AV40SupplierId ,
                                              A79PurchaseOrderActive ,
                                              A66PurchaseOrderClosedDate ,
                                              A52PurchaseOrderCreatedDate ,
                                              A50PurchaseOrderId ,
                                              A4SupplierId ,
                                              AV20OrderedBy ,
                                              AV38OrderBy } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P001U3 */
         pr_default.execute(0, new Object[] {AV21CreatedDateFrom, AV22CreatedDateTo, AV23ClosedDateFrom, AV24ClosedDateTo, AV39PurchaseOrderId, AV40SupplierId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A50PurchaseOrderId = P001U3_A50PurchaseOrderId[0];
            A4SupplierId = P001U3_A4SupplierId[0];
            A52PurchaseOrderCreatedDate = P001U3_A52PurchaseOrderCreatedDate[0];
            A66PurchaseOrderClosedDate = P001U3_A66PurchaseOrderClosedDate[0];
            n66PurchaseOrderClosedDate = P001U3_n66PurchaseOrderClosedDate[0];
            A79PurchaseOrderActive = P001U3_A79PurchaseOrderActive[0];
            A78PurchaseOrderTotalPaid = P001U3_A78PurchaseOrderTotalPaid[0];
            n78PurchaseOrderTotalPaid = P001U3_n78PurchaseOrderTotalPaid[0];
            A5SupplierName = P001U3_A5SupplierName[0];
            A67PurchaseOrderDetailsQuantity = P001U3_A67PurchaseOrderDetailsQuantity[0];
            n67PurchaseOrderDetailsQuantity = P001U3_n67PurchaseOrderDetailsQuantity[0];
            A67PurchaseOrderDetailsQuantity = P001U3_A67PurchaseOrderDetailsQuantity[0];
            n67PurchaseOrderDetailsQuantity = P001U3_n67PurchaseOrderDetailsQuantity[0];
            A5SupplierName = P001U3_A5SupplierName[0];
            if ( ! A79PurchaseOrderActive )
            {
               AV26State = "Canceled";
            }
            else if ( A79PurchaseOrderActive && ( P001U3_n66PurchaseOrderClosedDate[0] || (DateTime.MinValue==A66PurchaseOrderClosedDate) || ( DateTimeUtil.ResetTime ( A66PurchaseOrderClosedDate ) == DateTimeUtil.ResetTime ( DateTime.MinValue ) ) || (DateTime.MinValue==A66PurchaseOrderClosedDate) ) )
            {
               AV26State = "Pending";
            }
            else if ( A79PurchaseOrderActive && ! ( P001U3_n66PurchaseOrderClosedDate[0] || (DateTime.MinValue==A66PurchaseOrderClosedDate) || ( DateTimeUtil.ResetTime ( A66PurchaseOrderClosedDate ) == DateTimeUtil.ResetTime ( DateTime.MinValue ) ) || (DateTime.MinValue==A66PurchaseOrderClosedDate) ) )
            {
               AV26State = "Received";
            }
            else
            {
               AV26State = "";
            }
            AV27PurchaseOrderCreatedDate = A52PurchaseOrderCreatedDate;
            AV37SupplierNameAux = A5SupplierName;
            AV29PurchaseOrderTotalPaid = A78PurchaseOrderTotalPaid;
            AV30PurchaseOrderClosedDate = A66PurchaseOrderClosedDate;
            AV31PurchaseOrderDetailsQuantity = A67PurchaseOrderDetailsQuantity;
            AV32StateDescription = gxdomainpurchaseorderstate.getDescription(context,AV26State);
            /* Execute user subroutine: 'WRITEDATA1' */
            S161 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            AV12CellRow = (int)(AV12CellRow+1);
            /* Using cursor P001U4 */
            pr_default.execute(1, new Object[] {A50PurchaseOrderId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A15ProductId = P001U4_A15ProductId[0];
               A16ProductName = P001U4_A16ProductName[0];
               A76PurchaseOrderDetailQuantityOrd = P001U4_A76PurchaseOrderDetailQuantityOrd[0];
               A77PurchaseOrderDetailQuantityRec = P001U4_A77PurchaseOrderDetailQuantityRec[0];
               A61PurchaseOrderDetailId = P001U4_A61PurchaseOrderDetailId[0];
               A16ProductName = P001U4_A16ProductName[0];
               AV33ProductName = A16ProductName;
               AV35PurchaseOrderDetailQuantityOrdered = A76PurchaseOrderDetailQuantityOrd;
               AV36PurchaseOrderDetailQuantityReceived = A77PurchaseOrderDetailQuantityRec;
               /* Execute user subroutine: 'WRITEDATA2' */
               S171 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  this.cleanup();
                  if (true) return;
               }
               AV12CellRow = (int)(AV12CellRow+1);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV9ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
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
         /* 'OPENDOCUMENT' Routine */
         returnInSub = false;
         AV14Random = (int)(NumberUtil.Random( )*10000);
         AV10Filename = "Purchase Orders - " + StringUtil.Trim( StringUtil.Str( (decimal)(AV14Random), 8, 0)) + ".xlsx";
         AV9ExcelDocument.Open(AV10Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV9ExcelDocument.Clear();
      }

      protected void S121( )
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

      protected void S131( )
      {
         /* 'WRITEFILTERS' Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19PurchaseOrderState)) )
         {
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+0, 1, 1).Bold = 1;
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+0, 1, 1).Text = "State:";
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+1, 1, 1).Text = gxdomainpurchaseorderstate.getDescription(context,AV19PurchaseOrderState);
            AV12CellRow = (int)(AV12CellRow+1);
         }
         if ( ! (DateTime.MinValue==AV21CreatedDateFrom) )
         {
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+0, 1, 1).Bold = 1;
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+0, 1, 1).Text = "Created From:";
            GXt_dtime1 = DateTimeUtil.ResetTime( AV21CreatedDateFrom ) ;
            AV9ExcelDocument.SetDateFormat(context, 8, 5, 1, 2, "/", ":", " ");
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+1, 1, 1).Date = GXt_dtime1;
            AV12CellRow = (int)(AV12CellRow+1);
         }
         if ( ! (DateTime.MinValue==AV22CreatedDateTo) )
         {
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+0, 1, 1).Bold = 1;
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+0, 1, 1).Text = "Created To:";
            GXt_dtime1 = DateTimeUtil.ResetTime( AV22CreatedDateTo ) ;
            AV9ExcelDocument.SetDateFormat(context, 8, 5, 1, 2, "/", ":", " ");
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+1, 1, 1).Date = GXt_dtime1;
            AV12CellRow = (int)(AV12CellRow+1);
         }
         if ( ! (DateTime.MinValue==AV23ClosedDateFrom) )
         {
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+0, 1, 1).Bold = 1;
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+0, 1, 1).Text = "Closed From:";
            GXt_dtime1 = DateTimeUtil.ResetTime( AV23ClosedDateFrom ) ;
            AV9ExcelDocument.SetDateFormat(context, 8, 5, 1, 2, "/", ":", " ");
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+1, 1, 1).Date = GXt_dtime1;
            AV12CellRow = (int)(AV12CellRow+1);
         }
         if ( ! (DateTime.MinValue==AV24ClosedDateTo) )
         {
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+0, 1, 1).Bold = 1;
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+0, 1, 1).Text = "Closed To:";
            GXt_dtime1 = DateTimeUtil.ResetTime( AV24ClosedDateTo ) ;
            AV9ExcelDocument.SetDateFormat(context, 8, 5, 1, 2, "/", ":", " ");
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+1, 1, 1).Date = GXt_dtime1;
            AV12CellRow = (int)(AV12CellRow+1);
         }
         AV12CellRow = (int)(AV12CellRow+1);
      }

      protected void S141( )
      {
         /* 'WRITETITLE' Routine */
         returnInSub = false;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+4, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+4, 1, 1).Size = 16;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+4, 1, 1).Text = "Purchase Order List";
      }

      protected void S151( )
      {
         /* 'WRITECOLUMNS' Routine */
         returnInSub = false;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+0, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+0, 1, 1).Text = "Created Date";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+1, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+1, 1, 1).Text = "Supplier";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+2, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+2, 1, 1).Text = "Total Paid";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+3, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+3, 1, 1).Text = "Closed Date";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+4, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+4, 1, 1).Text = "State";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+5, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+5, 1, 1).Text = "Product";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+6, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+6, 1, 1).Text = "Quantity Ordered";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+7, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+7, 1, 1).Text = "Quantity Received";
      }

      protected void S161( )
      {
         /* 'WRITEDATA1' Routine */
         returnInSub = false;
         GXt_dtime1 = DateTimeUtil.ResetTime( AV27PurchaseOrderCreatedDate ) ;
         AV9ExcelDocument.SetDateFormat(context, 8, 5, 1, 2, "/", ":", " ");
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+0, 1, 1).Date = GXt_dtime1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+1, 1, 1).Text = AV37SupplierNameAux;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+2, 1, 1).Number = (double)(AV29PurchaseOrderTotalPaid);
         GXt_dtime1 = DateTimeUtil.ResetTime( AV30PurchaseOrderClosedDate ) ;
         AV9ExcelDocument.SetDateFormat(context, 8, 5, 1, 2, "/", ":", " ");
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+3, 1, 1).Date = GXt_dtime1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+4, 1, 1).Number = AV31PurchaseOrderDetailsQuantity;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+5, 1, 1).Text = AV32StateDescription;
      }

      protected void S171( )
      {
         /* 'WRITEDATA2' Routine */
         returnInSub = false;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+6, 1, 1).Text = AV33ProductName;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+7, 1, 1).Number = AV35PurchaseOrderDetailQuantityOrdered;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+8, 1, 1).Number = AV36PurchaseOrderDetailQuantityReceived;
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
         scmdbuf = "";
         A66PurchaseOrderClosedDate = DateTime.MinValue;
         A52PurchaseOrderCreatedDate = DateTime.MinValue;
         P001U3_A50PurchaseOrderId = new int[1] ;
         P001U3_A4SupplierId = new int[1] ;
         P001U3_A52PurchaseOrderCreatedDate = new DateTime[] {DateTime.MinValue} ;
         P001U3_A66PurchaseOrderClosedDate = new DateTime[] {DateTime.MinValue} ;
         P001U3_n66PurchaseOrderClosedDate = new bool[] {false} ;
         P001U3_A79PurchaseOrderActive = new bool[] {false} ;
         P001U3_A78PurchaseOrderTotalPaid = new decimal[1] ;
         P001U3_n78PurchaseOrderTotalPaid = new bool[] {false} ;
         P001U3_A5SupplierName = new string[] {""} ;
         P001U3_A67PurchaseOrderDetailsQuantity = new short[1] ;
         P001U3_n67PurchaseOrderDetailsQuantity = new bool[] {false} ;
         A5SupplierName = "";
         AV26State = "";
         AV27PurchaseOrderCreatedDate = DateTime.MinValue;
         AV37SupplierNameAux = "";
         AV30PurchaseOrderClosedDate = DateTime.MinValue;
         AV32StateDescription = "";
         P001U4_A15ProductId = new int[1] ;
         P001U4_A50PurchaseOrderId = new int[1] ;
         P001U4_A16ProductName = new string[] {""} ;
         P001U4_A76PurchaseOrderDetailQuantityOrd = new int[1] ;
         P001U4_A77PurchaseOrderDetailQuantityRec = new int[1] ;
         P001U4_A61PurchaseOrderDetailId = new int[1] ;
         A16ProductName = "";
         AV33ProductName = "";
         AV9ExcelDocument = new ExcelDocumentI();
         AV15File = new GxFile(context.GetPhysicalPath());
         AV17Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV16StorageProvider = new GxStorageProvider();
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.exportwwpurchaseorder__default(),
            new Object[][] {
                new Object[] {
               P001U3_A50PurchaseOrderId, P001U3_A4SupplierId, P001U3_A52PurchaseOrderCreatedDate, P001U3_A66PurchaseOrderClosedDate, P001U3_n66PurchaseOrderClosedDate, P001U3_A79PurchaseOrderActive, P001U3_A78PurchaseOrderTotalPaid, P001U3_n78PurchaseOrderTotalPaid, P001U3_A5SupplierName, P001U3_A67PurchaseOrderDetailsQuantity,
               P001U3_n67PurchaseOrderDetailsQuantity
               }
               , new Object[] {
               P001U4_A15ProductId, P001U4_A50PurchaseOrderId, P001U4_A16ProductName, P001U4_A76PurchaseOrderDetailQuantityOrd, P001U4_A77PurchaseOrderDetailQuantityRec, P001U4_A61PurchaseOrderDetailId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV20OrderedBy ;
      private short AV38OrderBy ;
      private short A67PurchaseOrderDetailsQuantity ;
      private short AV31PurchaseOrderDetailsQuantity ;
      private int AV39PurchaseOrderId ;
      private int AV40SupplierId ;
      private int AV12CellRow ;
      private int AV13FirstColumn ;
      private int A50PurchaseOrderId ;
      private int A4SupplierId ;
      private int A15ProductId ;
      private int A76PurchaseOrderDetailQuantityOrd ;
      private int A77PurchaseOrderDetailQuantityRec ;
      private int A61PurchaseOrderDetailId ;
      private int AV35PurchaseOrderDetailQuantityOrdered ;
      private int AV36PurchaseOrderDetailQuantityReceived ;
      private int AV14Random ;
      private decimal A78PurchaseOrderTotalPaid ;
      private decimal AV29PurchaseOrderTotalPaid ;
      private string scmdbuf ;
      private DateTime GXt_dtime1 ;
      private DateTime AV21CreatedDateFrom ;
      private DateTime AV22CreatedDateTo ;
      private DateTime AV23ClosedDateFrom ;
      private DateTime AV24ClosedDateTo ;
      private DateTime A66PurchaseOrderClosedDate ;
      private DateTime A52PurchaseOrderCreatedDate ;
      private DateTime AV27PurchaseOrderCreatedDate ;
      private DateTime AV30PurchaseOrderClosedDate ;
      private bool returnInSub ;
      private bool A79PurchaseOrderActive ;
      private bool n66PurchaseOrderClosedDate ;
      private bool n78PurchaseOrderTotalPaid ;
      private bool n67PurchaseOrderDetailsQuantity ;
      private string AV19PurchaseOrderState ;
      private string AV10Filename ;
      private string AV11ErrorMessage ;
      private string A5SupplierName ;
      private string AV26State ;
      private string AV37SupplierNameAux ;
      private string AV32StateDescription ;
      private string A16ProductName ;
      private string AV33ProductName ;
      private GxStorageProvider AV16StorageProvider ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P001U3_A50PurchaseOrderId ;
      private int[] P001U3_A4SupplierId ;
      private DateTime[] P001U3_A52PurchaseOrderCreatedDate ;
      private DateTime[] P001U3_A66PurchaseOrderClosedDate ;
      private bool[] P001U3_n66PurchaseOrderClosedDate ;
      private bool[] P001U3_A79PurchaseOrderActive ;
      private decimal[] P001U3_A78PurchaseOrderTotalPaid ;
      private bool[] P001U3_n78PurchaseOrderTotalPaid ;
      private string[] P001U3_A5SupplierName ;
      private short[] P001U3_A67PurchaseOrderDetailsQuantity ;
      private bool[] P001U3_n67PurchaseOrderDetailsQuantity ;
      private int[] P001U4_A15ProductId ;
      private int[] P001U4_A50PurchaseOrderId ;
      private string[] P001U4_A16ProductName ;
      private int[] P001U4_A76PurchaseOrderDetailQuantityOrd ;
      private int[] P001U4_A77PurchaseOrderDetailQuantityRec ;
      private int[] P001U4_A61PurchaseOrderDetailId ;
      private string aP8_Filename ;
      private string aP9_ErrorMessage ;
      private ExcelDocumentI AV9ExcelDocument ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV17Messages ;
      private GxFile AV15File ;
   }

   public class exportwwpurchaseorder__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P001U3( IGxContext context ,
                                             string AV19PurchaseOrderState ,
                                             DateTime AV21CreatedDateFrom ,
                                             DateTime AV22CreatedDateTo ,
                                             DateTime AV23ClosedDateFrom ,
                                             DateTime AV24ClosedDateTo ,
                                             int AV39PurchaseOrderId ,
                                             int AV40SupplierId ,
                                             bool A79PurchaseOrderActive ,
                                             DateTime A66PurchaseOrderClosedDate ,
                                             DateTime A52PurchaseOrderCreatedDate ,
                                             int A50PurchaseOrderId ,
                                             int A4SupplierId ,
                                             short AV20OrderedBy ,
                                             short AV38OrderBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[6];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[PurchaseOrderId], T1.[SupplierId], T1.[PurchaseOrderCreatedDate], T1.[PurchaseOrderClosedDate], T1.[PurchaseOrderActive], T1.[PurchaseOrderTotalPaid], T3.[SupplierName], COALESCE( T2.[PurchaseOrderDetailsQuantity], 0) AS PurchaseOrderDetailsQuantity FROM (([PurchaseOrder] T1 LEFT JOIN (SELECT COUNT(*) AS PurchaseOrderDetailsQuantity, [PurchaseOrderId] FROM [PurchaseOrderDetail] GROUP BY [PurchaseOrderId] ) T2 ON T2.[PurchaseOrderId] = T1.[PurchaseOrderId]) INNER JOIN [Supplier] T3 ON T3.[SupplierId] = T1.[SupplierId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19PurchaseOrderState)) && ( StringUtil.StrCmp(AV19PurchaseOrderState, "Canceled") == 0 ) )
         {
            AddWhere(sWhereString, "(( Not T1.[PurchaseOrderActive] = 1))");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19PurchaseOrderState)) && ( StringUtil.StrCmp(AV19PurchaseOrderState, "Pending") == 0 ) )
         {
            AddWhere(sWhereString, "(( T1.[PurchaseOrderActive] = 1 and ( T1.[PurchaseOrderClosedDate] IS NULL or (T1.[PurchaseOrderClosedDate] = convert( DATETIME, '17530101', 112 )) or T1.[PurchaseOrderClosedDate] = convert( DATETIME, '17530101', 112 ))))");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19PurchaseOrderState)) && ( StringUtil.StrCmp(AV19PurchaseOrderState, "Received") == 0 ) )
         {
            AddWhere(sWhereString, "(( T1.[PurchaseOrderActive] = 1 and Not ( T1.[PurchaseOrderClosedDate] IS NULL or (T1.[PurchaseOrderClosedDate] = convert( DATETIME, '17530101', 112 )) or T1.[PurchaseOrderClosedDate] = convert( DATETIME, '17530101', 112 ))))");
         }
         if ( ! (DateTime.MinValue==AV21CreatedDateFrom) )
         {
            AddWhere(sWhereString, "(T1.[PurchaseOrderCreatedDate] >= @AV21CreatedDateFrom)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV22CreatedDateTo) )
         {
            AddWhere(sWhereString, "(T1.[PurchaseOrderCreatedDate] <= @AV22CreatedDateTo)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV23ClosedDateFrom) )
         {
            AddWhere(sWhereString, "(T1.[PurchaseOrderClosedDate] >= @AV23ClosedDateFrom)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV24ClosedDateTo) )
         {
            AddWhere(sWhereString, "(T1.[PurchaseOrderClosedDate] <= @AV24ClosedDateTo)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! (0==AV39PurchaseOrderId) )
         {
            AddWhere(sWhereString, "(T1.[PurchaseOrderId] <= @AV39PurchaseOrderId)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! (0==AV40SupplierId) )
         {
            AddWhere(sWhereString, "(T1.[SupplierId] = @AV40SupplierId)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV20OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.[PurchaseOrderCreatedDate]";
         }
         else if ( AV20OrderedBy == 2 )
         {
            scmdbuf += " ORDER BY T1.[PurchaseOrderCreatedDate] DESC";
         }
         else if ( AV20OrderedBy == 3 )
         {
            scmdbuf += " ORDER BY T1.[PurchaseOrderClosedDate]";
         }
         else if ( AV20OrderedBy == 4 )
         {
            scmdbuf += " ORDER BY T1.[PurchaseOrderClosedDate] DESC";
         }
         else if ( AV38OrderBy == 5 )
         {
            scmdbuf += " ORDER BY T3.[SupplierName]";
         }
         else if ( AV38OrderBy == 6 )
         {
            scmdbuf += " ORDER BY T3.[SupplierName] DESC";
         }
         else if ( AV38OrderBy == 7 )
         {
            scmdbuf += " ORDER BY T1.[PurchaseOrderId]";
         }
         else if ( AV38OrderBy == 8 )
         {
            scmdbuf += " ORDER BY T1.[PurchaseOrderId] DESC";
         }
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P001U3(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (bool)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (short)dynConstraints[12] , (short)dynConstraints[13] );
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
          Object[] prmP001U4;
          prmP001U4 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmP001U3;
          prmP001U3 = new Object[] {
          new ParDef("@AV21CreatedDateFrom",GXType.Date,8,0) ,
          new ParDef("@AV22CreatedDateTo",GXType.Date,8,0) ,
          new ParDef("@AV23ClosedDateFrom",GXType.Date,8,0) ,
          new ParDef("@AV24ClosedDateTo",GXType.Date,8,0) ,
          new ParDef("@AV39PurchaseOrderId",GXType.Int32,6,0) ,
          new ParDef("@AV40SupplierId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P001U3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001U3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P001U4", "SELECT T1.[ProductId], T1.[PurchaseOrderId], T2.[ProductName], T1.[PurchaseOrderDetailQuantityOrd], T1.[PurchaseOrderDetailQuantityRec], T1.[PurchaseOrderDetailId] FROM ([PurchaseOrderDetail] T1 INNER JOIN [Product] T2 ON T2.[ProductId] = T1.[ProductId]) WHERE T1.[PurchaseOrderId] = @PurchaseOrderId ORDER BY T1.[PurchaseOrderId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001U4,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((bool[]) buf[5])[0] = rslt.getBool(5);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((string[]) buf[8])[0] = rslt.getVarchar(7);
                ((short[]) buf[9])[0] = rslt.getShort(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                return;
       }
    }

 }

}
