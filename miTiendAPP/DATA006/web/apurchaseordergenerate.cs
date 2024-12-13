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
   public class apurchaseordergenerate : GXWebProcedure
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
            gxfirstwebparm = GetFirstPar( "PurchaseOrderId");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               A50PurchaseOrderId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
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

      public apurchaseordergenerate( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public apurchaseordergenerate( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_PurchaseOrderId )
      {
         this.A50PurchaseOrderId = aP0_PurchaseOrderId;
         initialize();
         executePrivate();
      }

      public void executeSubmit( int aP0_PurchaseOrderId )
      {
         apurchaseordergenerate objapurchaseordergenerate;
         objapurchaseordergenerate = new apurchaseordergenerate();
         objapurchaseordergenerate.A50PurchaseOrderId = aP0_PurchaseOrderId;
         objapurchaseordergenerate.context.SetSubmitInitialConfig(context);
         objapurchaseordergenerate.initialize();
         Submit( executePrivateCatch,objapurchaseordergenerate);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((apurchaseordergenerate)stateInfo).executePrivate();
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
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 11923, 0, 1, 1, 0, 1, 1) )
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
            AV9FileName = "Voucher_" + StringUtil.Str( (decimal)(A50PurchaseOrderId), 6, 0) + ".pdf";
            GxHdr2 = true;
            /* Using cursor P00122 */
            pr_default.execute(0, new Object[] {A50PurchaseOrderId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A4SupplierId = P00122_A4SupplierId[0];
               A79PurchaseOrderActive = P00122_A79PurchaseOrderActive[0];
               A78PurchaseOrderTotalPaid = P00122_A78PurchaseOrderTotalPaid[0];
               n78PurchaseOrderTotalPaid = P00122_n78PurchaseOrderTotalPaid[0];
               A66PurchaseOrderClosedDate = P00122_A66PurchaseOrderClosedDate[0];
               n66PurchaseOrderClosedDate = P00122_n66PurchaseOrderClosedDate[0];
               A5SupplierName = P00122_A5SupplierName[0];
               A52PurchaseOrderCreatedDate = P00122_A52PurchaseOrderCreatedDate[0];
               A5SupplierName = P00122_A5SupplierName[0];
               if ( ! A79PurchaseOrderActive )
               {
                  AV16PurchaseOrderState = "Canceled";
               }
               else
               {
                  if ( P00122_n66PurchaseOrderClosedDate[0] || (DateTime.MinValue==A66PurchaseOrderClosedDate) || ( DateTimeUtil.ResetTime ( A66PurchaseOrderClosedDate ) == DateTimeUtil.ResetTime ( DateTime.MinValue ) ) )
                  {
                     AV16PurchaseOrderState = "Pending";
                  }
                  else
                  {
                     AV16PurchaseOrderState = "Received";
                  }
               }
               AV17QuantityTotalRequired = 0;
               AV18QuantityTotalReceived = 0;
               /* Using cursor P00123 */
               pr_default.execute(1, new Object[] {A50PurchaseOrderId});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A15ProductId = P00123_A15ProductId[0];
                  A134PurchaseOrderDetailSuggestedPr = P00123_A134PurchaseOrderDetailSuggestedPr[0];
                  n134PurchaseOrderDetailSuggestedPr = P00123_n134PurchaseOrderDetailSuggestedPr[0];
                  A85ProductCostPrice = P00123_A85ProductCostPrice[0];
                  n85ProductCostPrice = P00123_n85ProductCostPrice[0];
                  A77PurchaseOrderDetailQuantityRec = P00123_A77PurchaseOrderDetailQuantityRec[0];
                  A76PurchaseOrderDetailQuantityOrd = P00123_A76PurchaseOrderDetailQuantityOrd[0];
                  A16ProductName = P00123_A16ProductName[0];
                  A61PurchaseOrderDetailId = P00123_A61PurchaseOrderDetailId[0];
                  A85ProductCostPrice = P00123_A85ProductCostPrice[0];
                  n85ProductCostPrice = P00123_n85ProductCostPrice[0];
                  A16ProductName = P00123_A16ProductName[0];
                  H120( false, 16) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A16ProductName, "")), 19, Gx_line+1, 333, Gx_line+16, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A76PurchaseOrderDetailQuantityOrd), "ZZZZZ9")), 336, Gx_line+1, 423, Gx_line+16, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A77PurchaseOrderDetailQuantityRec), "ZZZZZ9")), 583, Gx_line+1, 670, Gx_line+16, 2, 0, 0, 0) ;
                  getPrinter().GxDrawRect(13, Gx_line+0, 813, Gx_line+16, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A85ProductCostPrice, "ZZZZZZZZZZZZZZ9.99")), 463, Gx_line+0, 550, Gx_line+15, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A134PurchaseOrderDetailSuggestedPr, "ZZZZZZZZZZZZZZ9.99")), 703, Gx_line+0, 790, Gx_line+15, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+16);
                  AV17QuantityTotalRequired = (int)(AV17QuantityTotalRequired+A76PurchaseOrderDetailQuantityOrd);
                  AV18QuantityTotalReceived = (int)(AV18QuantityTotalReceived+A77PurchaseOrderDetailQuantityRec);
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               H120( false, 25) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Required:", 247, Gx_line+1, 319, Gx_line+21, 0, 0, 0, 1) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV17QuantityTotalRequired), "ZZZZZ9")), 323, Gx_line+4, 423, Gx_line+19, 2, 0, 0, 0) ;
               getPrinter().GxDrawRect(13, Gx_line+0, 813, Gx_line+22, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV18QuantityTotalReceived), "ZZZZZ9")), 570, Gx_line+4, 670, Gx_line+19, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Received:", 493, Gx_line+0, 565, Gx_line+20, 0, 0, 0, 1) ;
               getPrinter().GxDrawText("Total Quantities", 19, Gx_line+0, 131, Gx_line+20, 0, 0, 0, 1) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+25);
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            GxHdr2 = false;
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H120( true, 0) ;
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

      protected void H120( bool bFoot ,
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
                  getPrinter().GxDrawLine(13, Gx_line+0, 813, Gx_line+0, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Voucher generated by", 21, Gx_line+3, 128, Gx_line+18, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("miTiendAPP", 128, Gx_line+3, 241, Gx_line+18, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+21);
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
               if ( GxHdr2 )
               {
                  getPrinter().GxAttris("Microsoft Sans Serif", 14, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Voucher Nro: ", 213, Gx_line+13, 383, Gx_line+53, 2, 0, 0, 1) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A52PurchaseOrderCreatedDate, "99/99/99"), 95, Gx_line+86, 195, Gx_line+101, 0, 0, 0, 1) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Generated:", 22, Gx_line+86, 94, Gx_line+101, 2, 0, 0, 1) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Qty Received", 570, Gx_line+138, 670, Gx_line+153, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("Qty Required", 330, Gx_line+138, 423, Gx_line+153, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("Product", 19, Gx_line+138, 86, Gx_line+153, 0, 0, 0, 1) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 14, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A50PurchaseOrderId), "ZZZZZ9")), 382, Gx_line+13, 609, Gx_line+53, 0, 0, 0, 1) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A5SupplierName, "")), 95, Gx_line+107, 346, Gx_line+122, 0, 0, 0, 1) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Supplier:", 34, Gx_line+107, 94, Gx_line+122, 2, 0, 0, 1) ;
                  getPrinter().GxDrawRect(13, Gx_line+0, 813, Gx_line+133, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("State:", 224, Gx_line+86, 264, Gx_line+101, 2, 0, 0, 1) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16PurchaseOrderState, "")), 265, Gx_line+86, 338, Gx_line+101, 0, 0, 0, 1) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Received:", 375, Gx_line+86, 440, Gx_line+101, 2, 0, 0, 1) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A66PurchaseOrderClosedDate, "99/99/99"), 444, Gx_line+86, 544, Gx_line+101, 0, 0, 0, 1) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Paid:", 583, Gx_line+86, 620, Gx_line+101, 2, 0, 0, 1) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A78PurchaseOrderTotalPaid, "ZZZZZZZZZZZZZZ9.99")), 624, Gx_line+86, 724, Gx_line+101, 0, 0, 0, 1) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Current Price", 450, Gx_line+138, 550, Gx_line+153, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("Sugg. Price", 690, Gx_line+138, 790, Gx_line+153, 2, 0, 0, 1) ;
                  getPrinter().GxDrawRect(13, Gx_line+133, 813, Gx_line+154, 1, 0, 0, 0, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+154);
               }
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
         AV9FileName = "";
         scmdbuf = "";
         P00122_A4SupplierId = new int[1] ;
         P00122_A50PurchaseOrderId = new int[1] ;
         P00122_A79PurchaseOrderActive = new bool[] {false} ;
         P00122_A78PurchaseOrderTotalPaid = new decimal[1] ;
         P00122_n78PurchaseOrderTotalPaid = new bool[] {false} ;
         P00122_A66PurchaseOrderClosedDate = new DateTime[] {DateTime.MinValue} ;
         P00122_n66PurchaseOrderClosedDate = new bool[] {false} ;
         P00122_A5SupplierName = new string[] {""} ;
         P00122_A52PurchaseOrderCreatedDate = new DateTime[] {DateTime.MinValue} ;
         A66PurchaseOrderClosedDate = DateTime.MinValue;
         A5SupplierName = "";
         A52PurchaseOrderCreatedDate = DateTime.MinValue;
         AV16PurchaseOrderState = "";
         P00123_A15ProductId = new int[1] ;
         P00123_A50PurchaseOrderId = new int[1] ;
         P00123_A134PurchaseOrderDetailSuggestedPr = new decimal[1] ;
         P00123_n134PurchaseOrderDetailSuggestedPr = new bool[] {false} ;
         P00123_A85ProductCostPrice = new decimal[1] ;
         P00123_n85ProductCostPrice = new bool[] {false} ;
         P00123_A77PurchaseOrderDetailQuantityRec = new int[1] ;
         P00123_A76PurchaseOrderDetailQuantityOrd = new int[1] ;
         P00123_A16ProductName = new string[] {""} ;
         P00123_A61PurchaseOrderDetailId = new int[1] ;
         A16ProductName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apurchaseordergenerate__default(),
            new Object[][] {
                new Object[] {
               P00122_A4SupplierId, P00122_A50PurchaseOrderId, P00122_A79PurchaseOrderActive, P00122_A78PurchaseOrderTotalPaid, P00122_n78PurchaseOrderTotalPaid, P00122_A66PurchaseOrderClosedDate, P00122_n66PurchaseOrderClosedDate, P00122_A5SupplierName, P00122_A52PurchaseOrderCreatedDate
               }
               , new Object[] {
               P00123_A15ProductId, P00123_A50PurchaseOrderId, P00123_A134PurchaseOrderDetailSuggestedPr, P00123_n134PurchaseOrderDetailSuggestedPr, P00123_A85ProductCostPrice, P00123_n85ProductCostPrice, P00123_A77PurchaseOrderDetailQuantityRec, P00123_A76PurchaseOrderDetailQuantityOrd, P00123_A16ProductName, P00123_A61PurchaseOrderDetailId
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private int A50PurchaseOrderId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A4SupplierId ;
      private int AV17QuantityTotalRequired ;
      private int AV18QuantityTotalReceived ;
      private int A15ProductId ;
      private int A77PurchaseOrderDetailQuantityRec ;
      private int A76PurchaseOrderDetailQuantityOrd ;
      private int A61PurchaseOrderDetailId ;
      private int Gx_OldLine ;
      private decimal A78PurchaseOrderTotalPaid ;
      private decimal A134PurchaseOrderDetailSuggestedPr ;
      private decimal A85ProductCostPrice ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private DateTime A66PurchaseOrderClosedDate ;
      private DateTime A52PurchaseOrderCreatedDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool GxHdr2 ;
      private bool A79PurchaseOrderActive ;
      private bool n78PurchaseOrderTotalPaid ;
      private bool n66PurchaseOrderClosedDate ;
      private bool n134PurchaseOrderDetailSuggestedPr ;
      private bool n85ProductCostPrice ;
      private string AV9FileName ;
      private string A5SupplierName ;
      private string AV16PurchaseOrderState ;
      private string A16ProductName ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00122_A4SupplierId ;
      private int[] P00122_A50PurchaseOrderId ;
      private bool[] P00122_A79PurchaseOrderActive ;
      private decimal[] P00122_A78PurchaseOrderTotalPaid ;
      private bool[] P00122_n78PurchaseOrderTotalPaid ;
      private DateTime[] P00122_A66PurchaseOrderClosedDate ;
      private bool[] P00122_n66PurchaseOrderClosedDate ;
      private string[] P00122_A5SupplierName ;
      private DateTime[] P00122_A52PurchaseOrderCreatedDate ;
      private int[] P00123_A15ProductId ;
      private int[] P00123_A50PurchaseOrderId ;
      private decimal[] P00123_A134PurchaseOrderDetailSuggestedPr ;
      private bool[] P00123_n134PurchaseOrderDetailSuggestedPr ;
      private decimal[] P00123_A85ProductCostPrice ;
      private bool[] P00123_n85ProductCostPrice ;
      private int[] P00123_A77PurchaseOrderDetailQuantityRec ;
      private int[] P00123_A76PurchaseOrderDetailQuantityOrd ;
      private string[] P00123_A16ProductName ;
      private int[] P00123_A61PurchaseOrderDetailId ;
   }

   public class apurchaseordergenerate__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00122;
          prmP00122 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmP00123;
          prmP00123 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00122", "SELECT T1.[SupplierId], T1.[PurchaseOrderId], T1.[PurchaseOrderActive], T1.[PurchaseOrderTotalPaid], T1.[PurchaseOrderClosedDate], T2.[SupplierName], T1.[PurchaseOrderCreatedDate] FROM ([PurchaseOrder] T1 INNER JOIN [Supplier] T2 ON T2.[SupplierId] = T1.[SupplierId]) WHERE T1.[PurchaseOrderId] = @PurchaseOrderId ORDER BY T1.[PurchaseOrderId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00122,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00123", "SELECT T1.[ProductId], T1.[PurchaseOrderId], T1.[PurchaseOrderDetailSuggestedPr], T2.[ProductCostPrice], T1.[PurchaseOrderDetailQuantityRec], T1.[PurchaseOrderDetailQuantityOrd], T2.[ProductName], T1.[PurchaseOrderDetailId] FROM ([PurchaseOrderDetail] T1 INNER JOIN [Product] T2 ON T2.[ProductId] = T1.[ProductId]) WHERE T1.[PurchaseOrderId] = @PurchaseOrderId ORDER BY T1.[PurchaseOrderId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00123,100, GxCacheFrequency.OFF ,false,false )
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
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(7);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((int[]) buf[6])[0] = rslt.getInt(5);
                ((int[]) buf[7])[0] = rslt.getInt(6);
                ((string[]) buf[8])[0] = rslt.getVarchar(7);
                ((int[]) buf[9])[0] = rslt.getInt(8);
                return;
       }
    }

 }

}
