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
   public class exportwwinvoice : GXProcedure
   {
      public exportwwinvoice( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public exportwwinvoice( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_InvoiceId ,
                           string aP1_InvoiceState ,
                           string aP2_UserName ,
                           DateTime aP3_DateFrom ,
                           DateTime aP4_DateTo ,
                           short aP5_OrderedBy ,
                           out string aP6_Filename ,
                           out string aP7_ErrorMessage )
      {
         this.AV32InvoiceId = aP0_InvoiceId;
         this.AV31InvoiceState = aP1_InvoiceState;
         this.AV22UserName = aP2_UserName;
         this.AV23DateFrom = aP3_DateFrom;
         this.AV24DateTo = aP4_DateTo;
         this.AV21OrderedBy = aP5_OrderedBy;
         this.AV10Filename = "" ;
         this.AV11ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP6_Filename=this.AV10Filename;
         aP7_ErrorMessage=this.AV11ErrorMessage;
      }

      public string executeUdp( int aP0_InvoiceId ,
                                string aP1_InvoiceState ,
                                string aP2_UserName ,
                                DateTime aP3_DateFrom ,
                                DateTime aP4_DateTo ,
                                short aP5_OrderedBy ,
                                out string aP6_Filename )
      {
         execute(aP0_InvoiceId, aP1_InvoiceState, aP2_UserName, aP3_DateFrom, aP4_DateTo, aP5_OrderedBy, out aP6_Filename, out aP7_ErrorMessage);
         return AV11ErrorMessage ;
      }

      public void executeSubmit( int aP0_InvoiceId ,
                                 string aP1_InvoiceState ,
                                 string aP2_UserName ,
                                 DateTime aP3_DateFrom ,
                                 DateTime aP4_DateTo ,
                                 short aP5_OrderedBy ,
                                 out string aP6_Filename ,
                                 out string aP7_ErrorMessage )
      {
         exportwwinvoice objexportwwinvoice;
         objexportwwinvoice = new exportwwinvoice();
         objexportwwinvoice.AV32InvoiceId = aP0_InvoiceId;
         objexportwwinvoice.AV31InvoiceState = aP1_InvoiceState;
         objexportwwinvoice.AV22UserName = aP2_UserName;
         objexportwwinvoice.AV23DateFrom = aP3_DateFrom;
         objexportwwinvoice.AV24DateTo = aP4_DateTo;
         objexportwwinvoice.AV21OrderedBy = aP5_OrderedBy;
         objexportwwinvoice.AV10Filename = "" ;
         objexportwwinvoice.AV11ErrorMessage = "" ;
         objexportwwinvoice.context.SetSubmitInitialConfig(context);
         objexportwwinvoice.initialize();
         Submit( executePrivateCatch,objexportwwinvoice);
         aP6_Filename=this.AV10Filename;
         aP7_ErrorMessage=this.AV11ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((exportwwinvoice)stateInfo).executePrivate();
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
         S131 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV12CellRow = (int)(AV12CellRow+3);
         /* Execute user subroutine: 'WRITEFILTERS' */
         S141 ();
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
                                              AV23DateFrom ,
                                              AV24DateTo ,
                                              AV22UserName ,
                                              AV31InvoiceState ,
                                              AV32InvoiceId ,
                                              A38InvoiceCreatedDate ,
                                              A100UserName ,
                                              A94InvoiceActive ,
                                              A20InvoiceId ,
                                              AV21OrderedBy } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.SHORT
                                              }
         });
         lV22UserName = StringUtil.Concat( StringUtil.RTrim( AV22UserName), "%", "");
         /* Using cursor P001V5 */
         pr_default.execute(0, new Object[] {AV23DateFrom, AV24DateTo, lV22UserName, AV32InvoiceId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A99UserId = P001V5_A99UserId[0];
            A20InvoiceId = P001V5_A20InvoiceId[0];
            A94InvoiceActive = P001V5_A94InvoiceActive[0];
            A100UserName = P001V5_A100UserName[0];
            A38InvoiceCreatedDate = P001V5_A38InvoiceCreatedDate[0];
            A80InvoiceTotalReceivable = P001V5_A80InvoiceTotalReceivable[0];
            n80InvoiceTotalReceivable = P001V5_n80InvoiceTotalReceivable[0];
            A100UserName = P001V5_A100UserName[0];
            A80InvoiceTotalReceivable = P001V5_A80InvoiceTotalReceivable[0];
            n80InvoiceTotalReceivable = P001V5_n80InvoiceTotalReceivable[0];
            if ( A94InvoiceActive )
            {
               AV19State = "Confirmated";
            }
            else
            {
               AV19State = "Canceled";
            }
            AV18InvoiceCreatedDate = A38InvoiceCreatedDate;
            AV26InvoiceTotalReceivable = A80InvoiceTotalReceivable;
            AV30UserNameAux = A100UserName;
            /* Execute user subroutine: 'WRITEDATA1' */
            S161 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            AV12CellRow = (int)(AV12CellRow+1);
            /* Using cursor P001V6 */
            pr_default.execute(1, new Object[] {A20InvoiceId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A15ProductId = P001V6_A15ProductId[0];
               A98InvoiceDetailIsWholesale = P001V6_A98InvoiceDetailIsWholesale[0];
               A16ProductName = P001V6_A16ProductName[0];
               A26InvoiceDetailQuantity = P001V6_A26InvoiceDetailQuantity[0];
               A65InvoiceDetailHistoricPrice = P001V6_A65InvoiceDetailHistoricPrice[0];
               A25InvoiceDetailId = P001V6_A25InvoiceDetailId[0];
               A16ProductName = P001V6_A16ProductName[0];
               if ( A98InvoiceDetailIsWholesale )
               {
                  AV25Type = "Wholesale";
               }
               else
               {
                  AV25Type = "Retail";
               }
               AV27ProductName = A16ProductName;
               AV28InvoiceDetailQuantity = A26InvoiceDetailQuantity;
               AV29InvoiceDetailHistoricPrice = A65InvoiceDetailHistoricPrice;
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
            /* Using cursor P001V7 */
            pr_default.execute(2, new Object[] {A20InvoiceId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A115PaymentMethodId = P001V7_A115PaymentMethodId[0];
               n115PaymentMethodId = P001V7_n115PaymentMethodId[0];
               A116PaymentMethodDescription = P001V7_A116PaymentMethodDescription[0];
               A120InvoicePaymentMethodImport = P001V7_A120InvoicePaymentMethodImport[0];
               n120InvoicePaymentMethodImport = P001V7_n120InvoicePaymentMethodImport[0];
               A133InvoicePaymentMethodDiscountIm = P001V7_A133InvoicePaymentMethodDiscountIm[0];
               n133InvoicePaymentMethodDiscountIm = P001V7_n133InvoicePaymentMethodDiscountIm[0];
               A132InvoicePaymentMethodRechargeIm = P001V7_A132InvoicePaymentMethodRechargeIm[0];
               n132InvoicePaymentMethodRechargeIm = P001V7_n132InvoicePaymentMethodRechargeIm[0];
               A118InvoicePaymentMethodId = P001V7_A118InvoicePaymentMethodId[0];
               A116PaymentMethodDescription = P001V7_A116PaymentMethodDescription[0];
               AV33PaymentMethodDescription = A116PaymentMethodDescription;
               AV34InvoicePaymentMethodImport = A120InvoicePaymentMethodImport;
               AV35InvoicePaymentMethodDiscountImport = A133InvoicePaymentMethodDiscountIm;
               AV36InvoicePaymentMethodRechargeImport = A132InvoicePaymentMethodRechargeIm;
               /* Execute user subroutine: 'WRITEDATA3' */
               S181 ();
               if ( returnInSub )
               {
                  pr_default.close(2);
                  this.cleanup();
                  if (true) return;
               }
               AV12CellRow = (int)(AV12CellRow+1);
               pr_default.readNext(2);
            }
            pr_default.close(2);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /* Execute user subroutine: 'CLOSEDOCUMENT' */
         S191 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'OPENDOCUMENT' Routine */
         returnInSub = false;
         AV14Random = (int)(NumberUtil.Random( )*10000);
         AV10Filename = "Sales - " + StringUtil.Trim( StringUtil.Str( (decimal)(AV14Random), 8, 0)) + ".xlsx";
         AV9ExcelDocument.Open(AV10Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV9ExcelDocument.Clear();
      }

      protected void S131( )
      {
         /* 'WRITETITLE' Routine */
         returnInSub = false;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+6, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+6, 1, 1).Size = 16;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+6, 1, 1).Text = "Sales List";
      }

      protected void S141( )
      {
         /* 'WRITEFILTERS' Routine */
         returnInSub = false;
         if ( ! (0==AV32InvoiceId) )
         {
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+0, 1, 1).Bold = 1;
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+0, 1, 1).Text = "Nro:";
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+1, 1, 1).Text = StringUtil.Str( (decimal)(AV32InvoiceId), 6, 0);
            AV12CellRow = (int)(AV12CellRow+1);
         }
         if ( ! (DateTime.MinValue==AV23DateFrom) )
         {
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+0, 1, 1).Bold = 1;
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+0, 1, 1).Text = "Created From:";
            GXt_dtime1 = DateTimeUtil.ResetTime( AV23DateFrom ) ;
            AV9ExcelDocument.SetDateFormat(context, 8, 5, 1, 2, "/", ":", " ");
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+1, 1, 1).Date = GXt_dtime1;
            AV12CellRow = (int)(AV12CellRow+1);
         }
         if ( ! (DateTime.MinValue==AV24DateTo) )
         {
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+0, 1, 1).Bold = 1;
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+0, 1, 1).Text = "Created To:";
            GXt_dtime1 = DateTimeUtil.ResetTime( AV24DateTo ) ;
            AV9ExcelDocument.SetDateFormat(context, 8, 5, 1, 2, "/", ":", " ");
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+1, 1, 1).Date = GXt_dtime1;
            AV12CellRow = (int)(AV12CellRow+1);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22UserName)) )
         {
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+0, 1, 1).Bold = 1;
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+0, 1, 1).Text = "Seller:";
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+1, 1, 1).Text = AV22UserName;
            AV12CellRow = (int)(AV12CellRow+1);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31InvoiceState)) )
         {
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+0, 1, 1).Bold = 1;
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+0, 1, 1).Text = "State:";
            AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+1, 1, 1).Text = gxdomaininvoicestatevalue.getDescription(context,AV31InvoiceState);
            AV12CellRow = (int)(AV12CellRow+1);
         }
         if ( AV12CellRow > 4 )
         {
            AV12CellRow = (int)(AV12CellRow+1);
         }
      }

      protected void S151( )
      {
         /* 'WRITECOLUMNS' Routine */
         returnInSub = false;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+0, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+0, 1, 1).Text = "Created Date";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+1, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+1, 1, 1).Text = "Total Receivable";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+2, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+2, 1, 1).Text = "Seller";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+3, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+3, 1, 1).Text = "State";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+4, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+4, 1, 1).Text = "Product";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+5, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+5, 1, 1).Text = "Quantity";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+6, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+6, 1, 1).Text = "Hist. Price";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+7, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+7, 1, 1).Text = "Type Price";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+8, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+8, 1, 1).Text = "Payment Method";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+9, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+9, 1, 1).Text = "Import";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+10, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+10, 1, 1).Text = "Discount";
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+11, 1, 1).Bold = 1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+11, 1, 1).Text = "Recharge";
      }

      protected void S161( )
      {
         /* 'WRITEDATA1' Routine */
         returnInSub = false;
         GXt_dtime1 = DateTimeUtil.ResetTime( AV18InvoiceCreatedDate ) ;
         AV9ExcelDocument.SetDateFormat(context, 8, 5, 1, 2, "/", ":", " ");
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+0, 1, 1).Date = GXt_dtime1;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+1, 1, 1).Number = (double)(AV26InvoiceTotalReceivable);
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+2, 1, 1).Text = AV30UserNameAux;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+3, 1, 1).Text = AV19State;
      }

      protected void S171( )
      {
         /* 'WRITEDATA2' Routine */
         returnInSub = false;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+4, 1, 1).Text = AV27ProductName;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+5, 1, 1).Number = AV28InvoiceDetailQuantity;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+6, 1, 1).Number = (double)(AV29InvoiceDetailHistoricPrice);
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+7, 1, 1).Text = AV25Type;
      }

      protected void S181( )
      {
         /* 'WRITEDATA3' Routine */
         returnInSub = false;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+8, 1, 1).Text = AV33PaymentMethodDescription;
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+9, 1, 1).Number = (double)(AV34InvoicePaymentMethodImport);
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+10, 1, 1).Number = (double)(AV35InvoicePaymentMethodDiscountImport);
         AV9ExcelDocument.get_Cells(AV12CellRow, AV13FirstColumn+11, 1, 1).Number = (double)(AV36InvoicePaymentMethodRechargeImport);
      }

      protected void S191( )
      {
         /* 'CLOSEDOCUMENT' Routine */
         returnInSub = false;
         AV9ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV9ExcelDocument.Close();
         if ( AV16StorageProvider.GetPrivate(AV10Filename, AV15File, 1, AV17Messages) )
         {
            AV10Filename = AV15File.GetURI();
         }
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
         lV22UserName = "";
         A38InvoiceCreatedDate = DateTime.MinValue;
         A100UserName = "";
         P001V5_A99UserId = new int[1] ;
         P001V5_A20InvoiceId = new int[1] ;
         P001V5_A94InvoiceActive = new bool[] {false} ;
         P001V5_A100UserName = new string[] {""} ;
         P001V5_A38InvoiceCreatedDate = new DateTime[] {DateTime.MinValue} ;
         P001V5_A80InvoiceTotalReceivable = new decimal[1] ;
         P001V5_n80InvoiceTotalReceivable = new bool[] {false} ;
         AV19State = "";
         AV18InvoiceCreatedDate = DateTime.MinValue;
         AV30UserNameAux = "";
         P001V6_A15ProductId = new int[1] ;
         P001V6_A20InvoiceId = new int[1] ;
         P001V6_A98InvoiceDetailIsWholesale = new bool[] {false} ;
         P001V6_A16ProductName = new string[] {""} ;
         P001V6_A26InvoiceDetailQuantity = new int[1] ;
         P001V6_A65InvoiceDetailHistoricPrice = new decimal[1] ;
         P001V6_A25InvoiceDetailId = new int[1] ;
         A16ProductName = "";
         AV25Type = "";
         AV27ProductName = "";
         P001V7_A115PaymentMethodId = new int[1] ;
         P001V7_n115PaymentMethodId = new bool[] {false} ;
         P001V7_A20InvoiceId = new int[1] ;
         P001V7_A116PaymentMethodDescription = new string[] {""} ;
         P001V7_A120InvoicePaymentMethodImport = new decimal[1] ;
         P001V7_n120InvoicePaymentMethodImport = new bool[] {false} ;
         P001V7_A133InvoicePaymentMethodDiscountIm = new decimal[1] ;
         P001V7_n133InvoicePaymentMethodDiscountIm = new bool[] {false} ;
         P001V7_A132InvoicePaymentMethodRechargeIm = new decimal[1] ;
         P001V7_n132InvoicePaymentMethodRechargeIm = new bool[] {false} ;
         P001V7_A118InvoicePaymentMethodId = new int[1] ;
         A116PaymentMethodDescription = "";
         AV33PaymentMethodDescription = "";
         AV9ExcelDocument = new ExcelDocumentI();
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         AV15File = new GxFile(context.GetPhysicalPath());
         AV17Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV16StorageProvider = new GxStorageProvider();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.exportwwinvoice__default(),
            new Object[][] {
                new Object[] {
               P001V5_A99UserId, P001V5_A20InvoiceId, P001V5_A94InvoiceActive, P001V5_A100UserName, P001V5_A38InvoiceCreatedDate, P001V5_A80InvoiceTotalReceivable, P001V5_n80InvoiceTotalReceivable
               }
               , new Object[] {
               P001V6_A15ProductId, P001V6_A20InvoiceId, P001V6_A98InvoiceDetailIsWholesale, P001V6_A16ProductName, P001V6_A26InvoiceDetailQuantity, P001V6_A65InvoiceDetailHistoricPrice, P001V6_A25InvoiceDetailId
               }
               , new Object[] {
               P001V7_A115PaymentMethodId, P001V7_n115PaymentMethodId, P001V7_A20InvoiceId, P001V7_A116PaymentMethodDescription, P001V7_A120InvoicePaymentMethodImport, P001V7_n120InvoicePaymentMethodImport, P001V7_A133InvoicePaymentMethodDiscountIm, P001V7_n133InvoicePaymentMethodDiscountIm, P001V7_A132InvoicePaymentMethodRechargeIm, P001V7_n132InvoicePaymentMethodRechargeIm,
               P001V7_A118InvoicePaymentMethodId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV21OrderedBy ;
      private int AV32InvoiceId ;
      private int AV12CellRow ;
      private int AV13FirstColumn ;
      private int A20InvoiceId ;
      private int A99UserId ;
      private int A15ProductId ;
      private int A26InvoiceDetailQuantity ;
      private int A25InvoiceDetailId ;
      private int AV28InvoiceDetailQuantity ;
      private int A115PaymentMethodId ;
      private int A118InvoicePaymentMethodId ;
      private int AV14Random ;
      private decimal A80InvoiceTotalReceivable ;
      private decimal AV26InvoiceTotalReceivable ;
      private decimal A65InvoiceDetailHistoricPrice ;
      private decimal AV29InvoiceDetailHistoricPrice ;
      private decimal A120InvoicePaymentMethodImport ;
      private decimal A133InvoicePaymentMethodDiscountIm ;
      private decimal A132InvoicePaymentMethodRechargeIm ;
      private decimal AV34InvoicePaymentMethodImport ;
      private decimal AV35InvoicePaymentMethodDiscountImport ;
      private decimal AV36InvoicePaymentMethodRechargeImport ;
      private string scmdbuf ;
      private DateTime GXt_dtime1 ;
      private DateTime AV23DateFrom ;
      private DateTime AV24DateTo ;
      private DateTime A38InvoiceCreatedDate ;
      private DateTime AV18InvoiceCreatedDate ;
      private bool returnInSub ;
      private bool A94InvoiceActive ;
      private bool n80InvoiceTotalReceivable ;
      private bool A98InvoiceDetailIsWholesale ;
      private bool n115PaymentMethodId ;
      private bool n120InvoicePaymentMethodImport ;
      private bool n133InvoicePaymentMethodDiscountIm ;
      private bool n132InvoicePaymentMethodRechargeIm ;
      private string AV31InvoiceState ;
      private string AV22UserName ;
      private string AV10Filename ;
      private string AV11ErrorMessage ;
      private string lV22UserName ;
      private string A100UserName ;
      private string AV19State ;
      private string AV30UserNameAux ;
      private string A16ProductName ;
      private string AV25Type ;
      private string AV27ProductName ;
      private string A116PaymentMethodDescription ;
      private string AV33PaymentMethodDescription ;
      private GxStorageProvider AV16StorageProvider ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P001V5_A99UserId ;
      private int[] P001V5_A20InvoiceId ;
      private bool[] P001V5_A94InvoiceActive ;
      private string[] P001V5_A100UserName ;
      private DateTime[] P001V5_A38InvoiceCreatedDate ;
      private decimal[] P001V5_A80InvoiceTotalReceivable ;
      private bool[] P001V5_n80InvoiceTotalReceivable ;
      private int[] P001V6_A15ProductId ;
      private int[] P001V6_A20InvoiceId ;
      private bool[] P001V6_A98InvoiceDetailIsWholesale ;
      private string[] P001V6_A16ProductName ;
      private int[] P001V6_A26InvoiceDetailQuantity ;
      private decimal[] P001V6_A65InvoiceDetailHistoricPrice ;
      private int[] P001V6_A25InvoiceDetailId ;
      private int[] P001V7_A115PaymentMethodId ;
      private bool[] P001V7_n115PaymentMethodId ;
      private int[] P001V7_A20InvoiceId ;
      private string[] P001V7_A116PaymentMethodDescription ;
      private decimal[] P001V7_A120InvoicePaymentMethodImport ;
      private bool[] P001V7_n120InvoicePaymentMethodImport ;
      private decimal[] P001V7_A133InvoicePaymentMethodDiscountIm ;
      private bool[] P001V7_n133InvoicePaymentMethodDiscountIm ;
      private decimal[] P001V7_A132InvoicePaymentMethodRechargeIm ;
      private bool[] P001V7_n132InvoicePaymentMethodRechargeIm ;
      private int[] P001V7_A118InvoicePaymentMethodId ;
      private string aP6_Filename ;
      private string aP7_ErrorMessage ;
      private ExcelDocumentI AV9ExcelDocument ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV17Messages ;
      private GxFile AV15File ;
   }

   public class exportwwinvoice__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P001V5( IGxContext context ,
                                             DateTime AV23DateFrom ,
                                             DateTime AV24DateTo ,
                                             string AV22UserName ,
                                             string AV31InvoiceState ,
                                             int AV32InvoiceId ,
                                             DateTime A38InvoiceCreatedDate ,
                                             string A100UserName ,
                                             bool A94InvoiceActive ,
                                             int A20InvoiceId ,
                                             short AV21OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[4];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[UserId], T1.[InvoiceId], T1.[InvoiceActive], T2.[UserName], T1.[InvoiceCreatedDate], COALESCE( T3.[InvoiceTotalReceivable], 0) AS InvoiceTotalReceivable FROM (([Invoice] T1 INNER JOIN [User] T2 ON T2.[UserId] = T1.[UserId]) INNER JOIN (SELECT COALESCE( T6.[GXC1], 0) - COALESCE( T5.[GXC2], 0) + COALESCE( T5.[GXC3], 0) AS InvoiceTotalReceivable, T4.[InvoiceId] FROM (([Invoice] T4 LEFT JOIN (SELECT SUM([InvoicePaymentMethodDiscountIm]) AS GXC2, [InvoiceId], SUM([InvoicePaymentMethodRechargeIm]) AS GXC3 FROM [InvoicePaymentMethod] GROUP BY [InvoiceId] ) T5 ON T5.[InvoiceId] = T4.[InvoiceId]) LEFT JOIN (SELECT SUM([InvoiceDetailQuantity] * CAST([InvoiceDetailHistoricPrice] AS decimal( 28, 10))) AS GXC1, [InvoiceId] FROM [InvoiceDetail] GROUP BY [InvoiceId] ) T6 ON T6.[InvoiceId] = T4.[InvoiceId]) ) T3 ON T3.[InvoiceId] = T1.[InvoiceId])";
         if ( ! (DateTime.MinValue==AV23DateFrom) )
         {
            AddWhere(sWhereString, "(T1.[InvoiceCreatedDate] >= @AV23DateFrom)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV24DateTo) )
         {
            AddWhere(sWhereString, "(T1.[InvoiceCreatedDate] <= @AV24DateTo)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22UserName)) )
         {
            AddWhere(sWhereString, "(T2.[UserName] like '%' + @lV22UserName + '%')");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31InvoiceState)) && ( StringUtil.StrCmp(AV31InvoiceState, "Confirmated") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[InvoiceActive] = 1)");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31InvoiceState)) && ( StringUtil.StrCmp(AV31InvoiceState, "Canceled") == 0 ) )
         {
            AddWhere(sWhereString, "(( Not T1.[InvoiceActive] = 1))");
         }
         if ( ! (0==AV32InvoiceId) )
         {
            AddWhere(sWhereString, "(T1.[InvoiceId] = @AV32InvoiceId)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV21OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.[InvoiceCreatedDate]";
         }
         else if ( AV21OrderedBy == 2 )
         {
            scmdbuf += " ORDER BY T1.[InvoiceCreatedDate] DESC";
         }
         else if ( AV21OrderedBy == 3 )
         {
            scmdbuf += " ORDER BY T2.[UserName]";
         }
         else if ( AV21OrderedBy == 4 )
         {
            scmdbuf += " ORDER BY T2.[UserName] DESC";
         }
         else if ( AV21OrderedBy == 5 )
         {
            scmdbuf += " ORDER BY T3.[InvoiceTotalReceivable]";
         }
         else if ( AV21OrderedBy == 6 )
         {
            scmdbuf += " ORDER BY T3.[InvoiceTotalReceivable] DESC";
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
                     return conditional_P001V5(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (DateTime)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (int)dynConstraints[8] , (short)dynConstraints[9] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP001V6;
          prmP001V6 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmP001V7;
          prmP001V7 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmP001V5;
          prmP001V5 = new Object[] {
          new ParDef("@AV23DateFrom",GXType.Date,8,0) ,
          new ParDef("@AV24DateTo",GXType.Date,8,0) ,
          new ParDef("@lV22UserName",GXType.NVarChar,20,0) ,
          new ParDef("@AV32InvoiceId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P001V5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001V5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P001V6", "SELECT T1.[ProductId], T1.[InvoiceId], T1.[InvoiceDetailIsWholesale], T2.[ProductName], T1.[InvoiceDetailQuantity], T1.[InvoiceDetailHistoricPrice], T1.[InvoiceDetailId] FROM ([InvoiceDetail] T1 INNER JOIN [Product] T2 ON T2.[ProductId] = T1.[ProductId]) WHERE T1.[InvoiceId] = @InvoiceId ORDER BY T1.[InvoiceId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001V6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P001V7", "SELECT T1.[PaymentMethodId], T1.[InvoiceId], T2.[PaymentMethodDescription], T1.[InvoicePaymentMethodImport], T1.[InvoicePaymentMethodDiscountIm], T1.[InvoicePaymentMethodRechargeIm], T1.[InvoicePaymentMethodId] FROM ([InvoicePaymentMethod] T1 LEFT JOIN [PaymentMethod] T2 ON T2.[PaymentMethodId] = T1.[PaymentMethodId]) WHERE T1.[InvoiceId] = @InvoiceId ORDER BY T1.[InvoiceId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001V7,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((int[]) buf[10])[0] = rslt.getInt(7);
                return;
       }
    }

 }

}
