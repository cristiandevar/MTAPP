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
using GeneXus.Printer;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class alistproductssales : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("mtaKB", true);
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "Supplier");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV8Supplier = (short)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV9DateFrom = context.localUtil.ParseDateParm( GetPar( "DateFrom"));
                  AV10DateTo = context.localUtil.ParseDateParm( GetPar( "DateTo"));
               }
            }
            if ( toggleJsOutput )
            {
            }
         }
         if ( GxWebError == 0 )
         {
            executePrivate();
         }
         cleanup();
      }

      public alistproductssales( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public alistproductssales( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_Supplier ,
                           DateTime aP1_DateFrom ,
                           DateTime aP2_DateTo )
      {
         this.AV8Supplier = aP0_Supplier;
         this.AV9DateFrom = aP1_DateFrom;
         this.AV10DateTo = aP2_DateTo;
         initialize();
         executePrivate();
      }

      public void executeSubmit( short aP0_Supplier ,
                                 DateTime aP1_DateFrom ,
                                 DateTime aP2_DateTo )
      {
         alistproductssales objalistproductssales;
         objalistproductssales = new alistproductssales();
         objalistproductssales.AV8Supplier = aP0_Supplier;
         objalistproductssales.AV9DateFrom = aP1_DateFrom;
         objalistproductssales.AV10DateTo = aP2_DateTo;
         objalistproductssales.context.SetSubmitInitialConfig(context);
         objalistproductssales.initialize();
         Submit( executePrivateCatch,objalistproductssales);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((alistproductssales)stateInfo).executePrivate();
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
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         getPrinter().GxSetDocName("") ;
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 11909, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV8Supplier ,
                                                 AV9DateFrom ,
                                                 AV10DateTo ,
                                                 A4SupplierId ,
                                                 A28ProductCreatedDate } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE
                                                 }
            });
            /* Using cursor P000M3 */
            pr_default.execute(0, new Object[] {AV8Supplier, AV9DateFrom, AV10DateTo});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A15ProductId = P000M3_A15ProductId[0];
               A28ProductCreatedDate = P000M3_A28ProductCreatedDate[0];
               A4SupplierId = P000M3_A4SupplierId[0];
               A5SupplierName = P000M3_A5SupplierName[0];
               A18ProductPrice = P000M3_A18ProductPrice[0];
               A17ProductStock = P000M3_A17ProductStock[0];
               A55ProductCode = P000M3_A55ProductCode[0];
               n55ProductCode = P000M3_n55ProductCode[0];
               A16ProductName = P000M3_A16ProductName[0];
               A40000GXC1 = P000M3_A40000GXC1[0];
               n40000GXC1 = P000M3_n40000GXC1[0];
               A40001GXC2 = P000M3_A40001GXC2[0];
               n40001GXC2 = P000M3_n40001GXC2[0];
               A40002GXC3 = P000M3_A40002GXC3[0];
               n40002GXC3 = P000M3_n40002GXC3[0];
               A40000GXC1 = P000M3_A40000GXC1[0];
               n40000GXC1 = P000M3_n40000GXC1[0];
               A40001GXC2 = P000M3_A40001GXC2[0];
               n40001GXC2 = P000M3_n40001GXC2[0];
               A40002GXC3 = P000M3_A40002GXC3[0];
               n40002GXC3 = P000M3_n40002GXC3[0];
               A5SupplierName = P000M3_A5SupplierName[0];
               AV11Sale = A40000GXC1;
               AV12UnitsSold = A40001GXC2;
               AV13Subtotal = A40002GXC3;
               AV14SupplierName = A5SupplierName;
               H0M0( false, 100) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A55ProductCode, "")), 0, Gx_line+27, 107, Gx_line+37, 1, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A16ProductName, "")), 100, Gx_line+27, 207, Gx_line+37, 1, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A17ProductStock), "ZZZZZ9")), 207, Gx_line+27, 314, Gx_line+37, 1, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A18ProductPrice, "ZZZZZZ9.99")), 313, Gx_line+27, 420, Gx_line+37, 1, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV11Sale), "ZZZZZ9")), 420, Gx_line+27, 527, Gx_line+37, 1, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV12UnitsSold), "ZZZZZ9")), 527, Gx_line+27, 634, Gx_line+37, 1, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV13Subtotal, "ZZZZZZ9.99")), 633, Gx_line+27, 740, Gx_line+37, 1, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14SupplierName, "")), 720, Gx_line+27, 827, Gx_line+37, 1, 0, 0, 1) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+100);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H0M0( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException  )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException  )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      protected void H0M0( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               getPrinter().GxAttris("Microsoft Sans Serif", 15, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Products to Purchase", 20, Gx_line+13, 327, Gx_line+54, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(0, Gx_line+107, 827, Gx_line+107, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Code", 0, Gx_line+120, 73, Gx_line+147, 1, 0, 0, 1) ;
               getPrinter().GxDrawText("Name", 100, Gx_line+120, 173, Gx_line+147, 1, 0, 0, 1) ;
               getPrinter().GxDrawText("Curr. Stock", 207, Gx_line+120, 300, Gx_line+147, 1, 0, 0, 1) ;
               getPrinter().GxDrawLine(0, Gx_line+160, 827, Gx_line+160, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Date From :", 600, Gx_line+53, 687, Gx_line+81, 0, 0, 0, 1) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV9DateFrom, "99/99/99"), 693, Gx_line+53, 793, Gx_line+80, 0, 0, 0, 1) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Price", 313, Gx_line+120, 406, Gx_line+147, 1, 0, 0, 1) ;
               getPrinter().GxDrawText("Sales", 420, Gx_line+120, 513, Gx_line+147, 1, 0, 0, 1) ;
               getPrinter().GxDrawText("Units Sold", 527, Gx_line+120, 620, Gx_line+147, 1, 0, 0, 1) ;
               getPrinter().GxDrawText("Subtotal", 633, Gx_line+120, 726, Gx_line+147, 1, 0, 0, 1) ;
               getPrinter().GxDrawText("Supplier", 733, Gx_line+120, 826, Gx_line+147, 1, 0, 0, 1) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV10DateTo, "99/99/99"), 493, Gx_line+53, 593, Gx_line+80, 0, 0, 0, 1) ;
               getPrinter().GxDrawText("Date To :", 400, Gx_line+53, 487, Gx_line+81, 0, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV8Supplier), "ZZZ9")), 493, Gx_line+13, 593, Gx_line+40, 0, 0, 0, 1) ;
               getPrinter().GxDrawText("Supplier :", 400, Gx_line+13, 487, Gx_line+41, 0, 0, 0, 1) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+177);
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
         add_metrics1( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if (IsMain)	waitPrinterEnd();
         base.cleanup();
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
         GXKey = "";
         gxfirstwebparm = "";
         scmdbuf = "";
         A28ProductCreatedDate = DateTime.MinValue;
         P000M3_A15ProductId = new int[1] ;
         P000M3_A28ProductCreatedDate = new DateTime[] {DateTime.MinValue} ;
         P000M3_A4SupplierId = new int[1] ;
         P000M3_A5SupplierName = new string[] {""} ;
         P000M3_A18ProductPrice = new decimal[1] ;
         P000M3_A17ProductStock = new int[1] ;
         P000M3_A55ProductCode = new string[] {""} ;
         P000M3_n55ProductCode = new bool[] {false} ;
         P000M3_A16ProductName = new string[] {""} ;
         P000M3_A40000GXC1 = new int[1] ;
         P000M3_n40000GXC1 = new bool[] {false} ;
         P000M3_A40001GXC2 = new int[1] ;
         P000M3_n40001GXC2 = new bool[] {false} ;
         P000M3_A40002GXC3 = new decimal[1] ;
         P000M3_n40002GXC3 = new bool[] {false} ;
         A5SupplierName = "";
         A55ProductCode = "";
         A16ProductName = "";
         AV14SupplierName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.alistproductssales__default(),
            new Object[][] {
                new Object[] {
               P000M3_A15ProductId, P000M3_A28ProductCreatedDate, P000M3_A4SupplierId, P000M3_A5SupplierName, P000M3_A18ProductPrice, P000M3_A17ProductStock, P000M3_A55ProductCode, P000M3_n55ProductCode, P000M3_A16ProductName, P000M3_A40000GXC1,
               P000M3_n40000GXC1, P000M3_A40001GXC2, P000M3_n40001GXC2, P000M3_A40002GXC3, P000M3_n40002GXC3
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short AV8Supplier ;
      private short GxWebError ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A4SupplierId ;
      private int A15ProductId ;
      private int A17ProductStock ;
      private int A40000GXC1 ;
      private int A40001GXC2 ;
      private int AV11Sale ;
      private int AV12UnitsSold ;
      private int Gx_OldLine ;
      private decimal A18ProductPrice ;
      private decimal A40002GXC3 ;
      private decimal AV13Subtotal ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private DateTime AV9DateFrom ;
      private DateTime AV10DateTo ;
      private DateTime A28ProductCreatedDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n55ProductCode ;
      private bool n40000GXC1 ;
      private bool n40001GXC2 ;
      private bool n40002GXC3 ;
      private string A5SupplierName ;
      private string A55ProductCode ;
      private string A16ProductName ;
      private string AV14SupplierName ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P000M3_A15ProductId ;
      private DateTime[] P000M3_A28ProductCreatedDate ;
      private int[] P000M3_A4SupplierId ;
      private string[] P000M3_A5SupplierName ;
      private decimal[] P000M3_A18ProductPrice ;
      private int[] P000M3_A17ProductStock ;
      private string[] P000M3_A55ProductCode ;
      private bool[] P000M3_n55ProductCode ;
      private string[] P000M3_A16ProductName ;
      private int[] P000M3_A40000GXC1 ;
      private bool[] P000M3_n40000GXC1 ;
      private int[] P000M3_A40001GXC2 ;
      private bool[] P000M3_n40001GXC2 ;
      private decimal[] P000M3_A40002GXC3 ;
      private bool[] P000M3_n40002GXC3 ;
   }

   public class alistproductssales__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P000M3( IGxContext context ,
                                             short AV8Supplier ,
                                             DateTime AV9DateFrom ,
                                             DateTime AV10DateTo ,
                                             int A4SupplierId ,
                                             DateTime A28ProductCreatedDate )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[3];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[ProductId], T1.[ProductCreatedDate], T1.[SupplierId], T3.[SupplierName], T1.[ProductPrice], T1.[ProductStock], T1.[ProductCode], T1.[ProductName], COALESCE( T2.[GXC1], 0) AS GXC1, COALESCE( T2.[GXC2], 0) AS GXC2, COALESCE( T2.[GXC3], 0) AS GXC3 FROM (([Product] T1 LEFT JOIN (SELECT COUNT(*) AS GXC1, [ProductId], SUM([InvoiceDetailQuantity]) AS GXC2, SUM([InvoiceDetailHistoricPrice] * CAST([InvoiceDetailQuantity] AS decimal( 20, 10))) AS GXC3 FROM [InvoiceDetail] GROUP BY [ProductId] ) T2 ON T2.[ProductId] = T1.[ProductId]) INNER JOIN [Supplier] T3 ON T3.[SupplierId] = T1.[SupplierId])";
         if ( ! (0==AV8Supplier) )
         {
            AddWhere(sWhereString, "(T1.[SupplierId] = @AV8Supplier)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV9DateFrom) )
         {
            AddWhere(sWhereString, "(T1.[ProductCreatedDate] >= @AV9DateFrom)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV10DateTo) )
         {
            AddWhere(sWhereString, "(T1.[ProductCreatedDate] <= @AV10DateTo)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProductName], T1.[ProductCode]";
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
               case 0 :
                     return conditional_P000M3(context, (short)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (int)dynConstraints[3] , (DateTime)dynConstraints[4] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmP000M3;
          prmP000M3 = new Object[] {
          new ParDef("@AV8Supplier",GXType.Int16,4,0) ,
          new ParDef("@AV9DateFrom",GXType.Date,8,0) ,
          new ParDef("@AV10DateTo",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000M3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000M3,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((int[]) buf[9])[0] = rslt.getInt(9);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((int[]) buf[11])[0] = rslt.getInt(10);
                ((bool[]) buf[12])[0] = rslt.wasNull(10);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(11);
                ((bool[]) buf[14])[0] = rslt.wasNull(11);
                return;
       }
    }

 }

}
