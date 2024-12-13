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
   public class apurchaseordervoucher : GXWebProcedure
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
               AV21PurchaseOrderId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
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

      public apurchaseordervoucher( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public apurchaseordervoucher( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_PurchaseOrderId )
      {
         this.AV21PurchaseOrderId = aP0_PurchaseOrderId;
         initialize();
         executePrivate();
      }

      public void executeSubmit( int aP0_PurchaseOrderId )
      {
         apurchaseordervoucher objapurchaseordervoucher;
         objapurchaseordervoucher = new apurchaseordervoucher();
         objapurchaseordervoucher.AV21PurchaseOrderId = aP0_PurchaseOrderId;
         objapurchaseordervoucher.context.SetSubmitInitialConfig(context);
         objapurchaseordervoucher.initialize();
         Submit( executePrivateCatch,objapurchaseordervoucher);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((apurchaseordervoucher)stateInfo).executePrivate();
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
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 11952, 0, 1, 1, 0, 1, 1) )
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
            AV8FileName = "Voucher_" + StringUtil.Str( (decimal)(A50PurchaseOrderId), 6, 0) + ".pdf";
            /* Execute user subroutine: 'DETERMINESTATE' */
            S151 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            GxHdr2 = true;
            /* Using cursor P00322 */
            pr_default.execute(0, new Object[] {AV21PurchaseOrderId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A4SupplierId = P00322_A4SupplierId[0];
               A50PurchaseOrderId = P00322_A50PurchaseOrderId[0];
               A136PurchaseOrderCanceledDescripti = P00322_A136PurchaseOrderCanceledDescripti[0];
               n136PurchaseOrderCanceledDescripti = P00322_n136PurchaseOrderCanceledDescripti[0];
               A52PurchaseOrderCreatedDate = P00322_A52PurchaseOrderCreatedDate[0];
               A5SupplierName = P00322_A5SupplierName[0];
               A53PurchaseOrderModifiedDate = P00322_A53PurchaseOrderModifiedDate[0];
               n53PurchaseOrderModifiedDate = P00322_n53PurchaseOrderModifiedDate[0];
               A66PurchaseOrderClosedDate = P00322_A66PurchaseOrderClosedDate[0];
               n66PurchaseOrderClosedDate = P00322_n66PurchaseOrderClosedDate[0];
               A78PurchaseOrderTotalPaid = P00322_A78PurchaseOrderTotalPaid[0];
               n78PurchaseOrderTotalPaid = P00322_n78PurchaseOrderTotalPaid[0];
               A135PurchaseOrderConfirmatedDate = P00322_A135PurchaseOrderConfirmatedDate[0];
               n135PurchaseOrderConfirmatedDate = P00322_n135PurchaseOrderConfirmatedDate[0];
               A5SupplierName = P00322_A5SupplierName[0];
               if ( StringUtil.StrCmp(AV23State, "Pending") == 0 )
               {
                  /* Execute user subroutine: 'CALCULATETOTALPROJECTEDPENDING' */
                  S171 ();
                  if ( returnInSub )
                  {
                     pr_default.close(0);
                     this.cleanup();
                     if (true) return;
                  }
               }
               else if ( StringUtil.StrCmp(AV23State, "Confirmated") == 0 )
               {
                  /* Execute user subroutine: 'CALCULATETOTALPROJECTEDCONFIRM' */
                  S161 ();
                  if ( returnInSub )
                  {
                     pr_default.close(0);
                     this.cleanup();
                     if (true) return;
                  }
               }
               else
               {
               }
               if ( StringUtil.StrCmp(AV23State, "Canceled") == 0 )
               {
                  H320( false, 21) ;
                  getPrinter().GxDrawRect(13, Gx_line+0, 813, Gx_line+21, 1, 0, 0, 0, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Product", 20, Gx_line+0, 87, Gx_line+15, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText("Qty Required", 333, Gx_line+0, 426, Gx_line+15, 2, 0, 0, 1) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+21);
                  /* Execute user subroutine: 'VOUCHERCANCELED' */
                  S111 ();
                  if ( returnInSub )
                  {
                     pr_default.close(0);
                     this.cleanup();
                     if (true) return;
                  }
                  H320( false, 80) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Reason:", 20, Gx_line+10, 85, Gx_line+30, 2, 0, 0, 0) ;
                  getPrinter().GxDrawRect(13, Gx_line+0, 813, Gx_line+80, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A136PurchaseOrderCanceledDescripti, "")), 90, Gx_line+10, 750, Gx_line+80, 0+16, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+80);
               }
               else if ( StringUtil.StrCmp(AV23State, "Received") == 0 )
               {
                  H320( false, 25) ;
                  getPrinter().GxDrawRect(13, Gx_line+0, 813, Gx_line+25, 1, 0, 0, 0, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Price", 574, Gx_line+5, 674, Gx_line+20, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("Product", 20, Gx_line+5, 87, Gx_line+20, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText("Qty Required", 333, Gx_line+5, 426, Gx_line+20, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("Qty Received", 440, Gx_line+5, 540, Gx_line+20, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("(*) Subtotal", 707, Gx_line+6, 802, Gx_line+21, 2, 0, 0, 1) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+25);
                  /* Execute user subroutine: 'VOUCHERRECEIVED' */
                  S131 ();
                  if ( returnInSub )
                  {
                     pr_default.close(0);
                     this.cleanup();
                     if (true) return;
                  }
                  H320( false, 54) ;
                  getPrinter().GxDrawRect(13, Gx_line+0, 813, Gx_line+25, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Totals", 20, Gx_line+8, 87, Gx_line+23, 0, 0, 0, 1) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV19PurchaseOrderDetailTotal, "ZZZZZZZZZZZZZZ9.99")), 608, Gx_line+8, 802, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV16QuantityTotalRequired), "ZZZZZ9")), 340, Gx_line+8, 426, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV17QuantityTotalReceived), "ZZZZZ9")), 460, Gx_line+8, 540, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 5, true, true, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("(*) The subtotal is calculated with the product's suggested price.", 13, Gx_line+34, 813, Gx_line+41, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+54);
               }
               else if ( StringUtil.StrCmp(AV23State, "Pending") == 0 )
               {
                  H320( false, 22) ;
                  getPrinter().GxDrawRect(13, Gx_line+0, 813, Gx_line+21, 1, 0, 0, 0, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("(*) Subtotal", 693, Gx_line+0, 793, Gx_line+15, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("Qty. Ordered", 453, Gx_line+0, 553, Gx_line+15, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("Product", 20, Gx_line+0, 87, Gx_line+15, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText("Current Stock", 320, Gx_line+0, 427, Gx_line+15, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("Current Price", 573, Gx_line+0, 673, Gx_line+15, 2, 0, 0, 1) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+22);
                  /* Execute user subroutine: 'VOUCHERPENDING' */
                  S121 ();
                  if ( returnInSub )
                  {
                     pr_default.close(0);
                     this.cleanup();
                     if (true) return;
                  }
                  H320( false, 25) ;
                  getPrinter().GxDrawRect(13, Gx_line+0, 813, Gx_line+5, 1, 0, 0, 0, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 5, true, true, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("(*) The subtotal is calculated with the current price of the product.", 13, Gx_line+13, 813, Gx_line+20, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+25);
               }
               else if ( StringUtil.StrCmp(AV23State, "Confirmated") == 0 )
               {
                  H320( false, 25) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("(*) Subtotal", 700, Gx_line+7, 800, Gx_line+22, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText("Qty Available", 440, Gx_line+7, 540, Gx_line+22, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("Qty Required", 333, Gx_line+7, 426, Gx_line+22, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("Product", 20, Gx_line+7, 87, Gx_line+22, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText("Sugg. Price", 573, Gx_line+7, 673, Gx_line+22, 2, 0, 0, 1) ;
                  getPrinter().GxDrawRect(13, Gx_line+0, 813, Gx_line+25, 1, 0, 0, 0, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+25);
                  /* Execute user subroutine: 'VOUCHERCONFIRM' */
                  S141 ();
                  if ( returnInSub )
                  {
                     pr_default.close(0);
                     this.cleanup();
                     if (true) return;
                  }
                  H320( false, 25) ;
                  getPrinter().GxDrawRect(13, Gx_line+0, 813, Gx_line+5, 1, 0, 0, 0, 0, 255, 255, 255, 1, 0, 0, 0, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 5, true, true, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("(*) The subtotal is calculated with the current price of the product or the suggested price, depending on whether the suggested price is greater than zero.", 13, Gx_line+13, 813, Gx_line+20, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+25);
               }
               else
               {
               }
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            GxHdr2 = false;
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H320( true, 0) ;
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

      protected void S111( )
      {
         /* 'VOUCHERCANCELED' Routine */
         returnInSub = false;
         /* Using cursor P00323 */
         pr_default.execute(1, new Object[] {AV21PurchaseOrderId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A15ProductId = P00323_A15ProductId[0];
            A50PurchaseOrderId = P00323_A50PurchaseOrderId[0];
            A16ProductName = P00323_A16ProductName[0];
            A76PurchaseOrderDetailQuantityOrd = P00323_A76PurchaseOrderDetailQuantityOrd[0];
            A61PurchaseOrderDetailId = P00323_A61PurchaseOrderDetailId[0];
            A16ProductName = P00323_A16ProductName[0];
            H320( false, 16) ;
            getPrinter().GxDrawRect(13, Gx_line+0, 813, Gx_line+16, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A76PurchaseOrderDetailQuantityOrd), "ZZZZZ9")), 339, Gx_line+0, 426, Gx_line+15, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A16ProductName, "")), 20, Gx_line+0, 334, Gx_line+15, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+16);
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void S121( )
      {
         /* 'VOUCHERPENDING' Routine */
         returnInSub = false;
         /* Using cursor P00324 */
         pr_default.execute(2, new Object[] {AV21PurchaseOrderId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A15ProductId = P00324_A15ProductId[0];
            A50PurchaseOrderId = P00324_A50PurchaseOrderId[0];
            A85ProductCostPrice = P00324_A85ProductCostPrice[0];
            n85ProductCostPrice = P00324_n85ProductCostPrice[0];
            A76PurchaseOrderDetailQuantityOrd = P00324_A76PurchaseOrderDetailQuantityOrd[0];
            A17ProductStock = P00324_A17ProductStock[0];
            n17ProductStock = P00324_n17ProductStock[0];
            A16ProductName = P00324_A16ProductName[0];
            A61PurchaseOrderDetailId = P00324_A61PurchaseOrderDetailId[0];
            A85ProductCostPrice = P00324_A85ProductCostPrice[0];
            n85ProductCostPrice = P00324_n85ProductCostPrice[0];
            A17ProductStock = P00324_A17ProductStock[0];
            n17ProductStock = P00324_n17ProductStock[0];
            A16ProductName = P00324_A16ProductName[0];
            AV18PurchaseOrderDetailSubtotal = (decimal)(A76PurchaseOrderDetailQuantityOrd*A85ProductCostPrice);
            H320( false, 17) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV18PurchaseOrderDetailSubtotal, "ZZZZZZZZZZZZZZ9.99")), 700, Gx_line+0, 793, Gx_line+15, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A16ProductName, "")), 20, Gx_line+0, 334, Gx_line+15, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A17ProductStock), "ZZZZZ9")), 339, Gx_line+0, 426, Gx_line+15, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A76PurchaseOrderDetailQuantityOrd), "ZZZZZ9")), 466, Gx_line+0, 553, Gx_line+15, 2, 0, 0, 0) ;
            getPrinter().GxDrawRect(13, Gx_line+0, 813, Gx_line+16, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A85ProductCostPrice, "ZZZZZZZZZZZZZZ9.99")), 587, Gx_line+0, 674, Gx_line+15, 2, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+17);
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void S131( )
      {
         /* 'VOUCHERRECEIVED' Routine */
         returnInSub = false;
         AV17QuantityTotalReceived = 0;
         AV16QuantityTotalRequired = 0;
         AV19PurchaseOrderDetailTotal = 0;
         /* Using cursor P00325 */
         pr_default.execute(3, new Object[] {AV21PurchaseOrderId});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A15ProductId = P00325_A15ProductId[0];
            A50PurchaseOrderId = P00325_A50PurchaseOrderId[0];
            A134PurchaseOrderDetailSuggestedPr = P00325_A134PurchaseOrderDetailSuggestedPr[0];
            n134PurchaseOrderDetailSuggestedPr = P00325_n134PurchaseOrderDetailSuggestedPr[0];
            A77PurchaseOrderDetailQuantityRec = P00325_A77PurchaseOrderDetailQuantityRec[0];
            A16ProductName = P00325_A16ProductName[0];
            A76PurchaseOrderDetailQuantityOrd = P00325_A76PurchaseOrderDetailQuantityOrd[0];
            A61PurchaseOrderDetailId = P00325_A61PurchaseOrderDetailId[0];
            A16ProductName = P00325_A16ProductName[0];
            AV26PurchaseOrderDetailPrice = A134PurchaseOrderDetailSuggestedPr;
            AV18PurchaseOrderDetailSubtotal = (decimal)(A77PurchaseOrderDetailQuantityRec*AV26PurchaseOrderDetailPrice);
            H320( false, 16) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV26PurchaseOrderDetailPrice, "ZZZZZZZZZZZZZZ9.99")), 587, Gx_line+0, 674, Gx_line+15, 2, 0, 0, 0) ;
            getPrinter().GxDrawRect(13, Gx_line+0, 813, Gx_line+16, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A77PurchaseOrderDetailQuantityRec), "ZZZZZ9")), 453, Gx_line+0, 540, Gx_line+15, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A76PurchaseOrderDetailQuantityOrd), "ZZZZZ9")), 339, Gx_line+0, 426, Gx_line+15, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A16ProductName, "")), 20, Gx_line+0, 334, Gx_line+15, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV18PurchaseOrderDetailSubtotal, "ZZZZZZZZZZZZZZ9.99")), 696, Gx_line+0, 810, Gx_line+15, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+16);
            AV17QuantityTotalReceived = (int)(AV17QuantityTotalReceived+A77PurchaseOrderDetailQuantityRec);
            AV16QuantityTotalRequired = (int)(AV16QuantityTotalRequired+A76PurchaseOrderDetailQuantityOrd);
            AV19PurchaseOrderDetailTotal = (decimal)(AV19PurchaseOrderDetailTotal+AV18PurchaseOrderDetailSubtotal);
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void S141( )
      {
         /* 'VOUCHERCONFIRM' Routine */
         returnInSub = false;
         /* Using cursor P00326 */
         pr_default.execute(4, new Object[] {AV21PurchaseOrderId});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A15ProductId = P00326_A15ProductId[0];
            A50PurchaseOrderId = P00326_A50PurchaseOrderId[0];
            A134PurchaseOrderDetailSuggestedPr = P00326_A134PurchaseOrderDetailSuggestedPr[0];
            n134PurchaseOrderDetailSuggestedPr = P00326_n134PurchaseOrderDetailSuggestedPr[0];
            A77PurchaseOrderDetailQuantityRec = P00326_A77PurchaseOrderDetailQuantityRec[0];
            A76PurchaseOrderDetailQuantityOrd = P00326_A76PurchaseOrderDetailQuantityOrd[0];
            A16ProductName = P00326_A16ProductName[0];
            A61PurchaseOrderDetailId = P00326_A61PurchaseOrderDetailId[0];
            A16ProductName = P00326_A16ProductName[0];
            AV18PurchaseOrderDetailSubtotal = (decimal)(A77PurchaseOrderDetailQuantityRec*A134PurchaseOrderDetailSuggestedPr);
            H320( false, 16) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV18PurchaseOrderDetailSubtotal, "ZZZZZZZZZZZZZZ9.99")), 693, Gx_line+0, 807, Gx_line+15, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A16ProductName, "")), 20, Gx_line+0, 334, Gx_line+15, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A76PurchaseOrderDetailQuantityOrd), "ZZZZZ9")), 340, Gx_line+0, 427, Gx_line+15, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A77PurchaseOrderDetailQuantityRec), "ZZZZZ9")), 453, Gx_line+0, 540, Gx_line+15, 2, 0, 0, 0) ;
            getPrinter().GxDrawRect(13, Gx_line+0, 813, Gx_line+16, 1, 0, 0, 0, 0, 255, 255, 255, 1, 1, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A134PurchaseOrderDetailSuggestedPr, "ZZZZZZZZZZZZZZ9.99")), 587, Gx_line+0, 674, Gx_line+15, 2, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+16);
            pr_default.readNext(4);
         }
         pr_default.close(4);
      }

      protected void S151( )
      {
         /* 'DETERMINESTATE' Routine */
         returnInSub = false;
         AV22Determined = false;
         AV23State = "";
         /* Using cursor P00327 */
         pr_default.execute(5, new Object[] {AV21PurchaseOrderId});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A50PurchaseOrderId = P00327_A50PurchaseOrderId[0];
            A79PurchaseOrderActive = P00327_A79PurchaseOrderActive[0];
            A66PurchaseOrderClosedDate = P00327_A66PurchaseOrderClosedDate[0];
            n66PurchaseOrderClosedDate = P00327_n66PurchaseOrderClosedDate[0];
            A135PurchaseOrderConfirmatedDate = P00327_A135PurchaseOrderConfirmatedDate[0];
            n135PurchaseOrderConfirmatedDate = P00327_n135PurchaseOrderConfirmatedDate[0];
            if ( ! A79PurchaseOrderActive )
            {
               AV22Determined = true;
               AV23State = "Canceled";
            }
            if ( ! AV22Determined && ( P00327_n66PurchaseOrderClosedDate[0] || (DateTime.MinValue==A66PurchaseOrderClosedDate) || ( DateTimeUtil.ResetTime ( A66PurchaseOrderClosedDate ) == DateTimeUtil.ResetTime ( DateTime.MinValue ) ) || (DateTime.MinValue==A66PurchaseOrderClosedDate) ) )
            {
               if ( P00327_n135PurchaseOrderConfirmatedDate[0] || (DateTime.MinValue==A135PurchaseOrderConfirmatedDate) || ( DateTimeUtil.ResetTime ( A135PurchaseOrderConfirmatedDate ) == DateTimeUtil.ResetTime ( DateTime.MinValue ) ) || (DateTime.MinValue==A135PurchaseOrderConfirmatedDate) )
               {
                  AV22Determined = true;
                  AV23State = "Pending";
               }
               else
               {
                  AV22Determined = true;
                  AV23State = "Confirmated";
               }
            }
            if ( ! AV22Determined && ! ( P00327_n66PurchaseOrderClosedDate[0] || (DateTime.MinValue==A66PurchaseOrderClosedDate) || ( DateTimeUtil.ResetTime ( A66PurchaseOrderClosedDate ) == DateTimeUtil.ResetTime ( DateTime.MinValue ) ) || (DateTime.MinValue==A66PurchaseOrderClosedDate) ) )
            {
               AV22Determined = true;
               AV23State = "Received";
            }
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(5);
      }

      protected void S161( )
      {
         /* 'CALCULATETOTALPROJECTEDCONFIRM' Routine */
         returnInSub = false;
         AV19PurchaseOrderDetailTotal = 0;
         /* Using cursor P00328 */
         pr_default.execute(6, new Object[] {AV21PurchaseOrderId});
         while ( (pr_default.getStatus(6) != 101) )
         {
            A50PurchaseOrderId = P00328_A50PurchaseOrderId[0];
            A134PurchaseOrderDetailSuggestedPr = P00328_A134PurchaseOrderDetailSuggestedPr[0];
            n134PurchaseOrderDetailSuggestedPr = P00328_n134PurchaseOrderDetailSuggestedPr[0];
            A77PurchaseOrderDetailQuantityRec = P00328_A77PurchaseOrderDetailQuantityRec[0];
            A61PurchaseOrderDetailId = P00328_A61PurchaseOrderDetailId[0];
            AV19PurchaseOrderDetailTotal = (decimal)(AV19PurchaseOrderDetailTotal+(A77PurchaseOrderDetailQuantityRec*A134PurchaseOrderDetailSuggestedPr));
            pr_default.readNext(6);
         }
         pr_default.close(6);
      }

      protected void S171( )
      {
         /* 'CALCULATETOTALPROJECTEDPENDING' Routine */
         returnInSub = false;
         AV19PurchaseOrderDetailTotal = 0;
         /* Using cursor P00329 */
         pr_default.execute(7, new Object[] {AV21PurchaseOrderId});
         while ( (pr_default.getStatus(7) != 101) )
         {
            A15ProductId = P00329_A15ProductId[0];
            A50PurchaseOrderId = P00329_A50PurchaseOrderId[0];
            A85ProductCostPrice = P00329_A85ProductCostPrice[0];
            n85ProductCostPrice = P00329_n85ProductCostPrice[0];
            A76PurchaseOrderDetailQuantityOrd = P00329_A76PurchaseOrderDetailQuantityOrd[0];
            A61PurchaseOrderDetailId = P00329_A61PurchaseOrderDetailId[0];
            A85ProductCostPrice = P00329_A85ProductCostPrice[0];
            n85ProductCostPrice = P00329_n85ProductCostPrice[0];
            AV26PurchaseOrderDetailPrice = A85ProductCostPrice;
            AV19PurchaseOrderDetailTotal = (decimal)(AV19PurchaseOrderDetailTotal+(A76PurchaseOrderDetailQuantityOrd*AV26PurchaseOrderDetailPrice));
            pr_default.readNext(7);
         }
         pr_default.close(7);
      }

      protected void H320( bool bFoot ,
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
                  if ( StringUtil.StrCmp(AV23State, "Canceled") == 0 )
                  {
                     getPrinter().GxDrawRect(646, Gx_line+5, 803, Gx_line+62, 4, 255, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 7, 7, 7, 7) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(context.localUtil.Format( A53PurchaseOrderModifiedDate, "99/99/99"), 649, Gx_line+86, 749, Gx_line+101, 0, 0, 0, 1) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText("Canceled", 576, Gx_line+86, 641, Gx_line+101, 2, 0, 0, 1) ;
                     getPrinter().GxDrawRect(13, Gx_line+0, 813, Gx_line+133, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText("Supplier:", 22, Gx_line+86, 82, Gx_line+101, 2, 0, 0, 1) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A5SupplierName, "")), 82, Gx_line+86, 333, Gx_line+101, 0, 0, 0, 1) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 14, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A50PurchaseOrderId), "ZZZZZ9")), 386, Gx_line+13, 553, Gx_line+53, 0, 0, 0, 1) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText("Generated:", 356, Gx_line+86, 428, Gx_line+101, 2, 0, 0, 1) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(context.localUtil.Format( A52PurchaseOrderCreatedDate, "99/99/99"), 429, Gx_line+86, 529, Gx_line+101, 0, 0, 0, 1) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 14, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText("Voucher Nro: ", 213, Gx_line+13, 383, Gx_line+53, 2, 0, 0, 1) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 14, true, false, false, false, 0, 255, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText("CANCELED", 653, Gx_line+13, 796, Gx_line+53, 1, 0, 0, 1) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+133);
                  }
                  else if ( StringUtil.StrCmp(AV23State, "Received") == 0 )
                  {
                     getPrinter().GxAttris("Microsoft Sans Serif", 14, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A50PurchaseOrderId), "ZZZZZ9")), 386, Gx_line+13, 613, Gx_line+53, 0, 0, 0, 1) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 14, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText("Voucher Nro: ", 213, Gx_line+13, 383, Gx_line+53, 2, 0, 0, 1) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A78PurchaseOrderTotalPaid, "ZZZZZZZZZZZZZZ9.99")), 627, Gx_line+80, 727, Gx_line+95, 0, 0, 0, 1) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText("Paid:", 587, Gx_line+80, 624, Gx_line+95, 2, 0, 0, 1) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(context.localUtil.Format( A66PurchaseOrderClosedDate, "99/99/99"), 431, Gx_line+107, 531, Gx_line+122, 0, 0, 0, 1) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText("Received:", 360, Gx_line+107, 425, Gx_line+122, 2, 0, 0, 1) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23State, "")), 84, Gx_line+107, 157, Gx_line+122, 0, 0, 0, 1) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText("State:", 40, Gx_line+107, 80, Gx_line+122, 2, 0, 0, 1) ;
                     getPrinter().GxDrawRect(13, Gx_line+0, 813, Gx_line+133, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText("Supplier:", 20, Gx_line+80, 80, Gx_line+95, 2, 0, 0, 1) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A5SupplierName, "")), 84, Gx_line+80, 335, Gx_line+95, 0, 0, 0, 1) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText("Generated:", 353, Gx_line+80, 425, Gx_line+95, 2, 0, 0, 1) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(context.localUtil.Format( A52PurchaseOrderCreatedDate, "99/99/99"), 431, Gx_line+80, 531, Gx_line+95, 0, 0, 0, 1) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+133);
                  }
                  else if ( StringUtil.StrCmp(AV23State, "Pending") == 0 )
                  {
                     getPrinter().GxDrawRect(13, Gx_line+0, 813, Gx_line+133, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 14, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText("Voucher Nro: ", 213, Gx_line+13, 383, Gx_line+53, 2, 0, 0, 1) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 14, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A50PurchaseOrderId), "ZZZZZ9")), 386, Gx_line+13, 613, Gx_line+53, 0, 0, 0, 1) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A5SupplierName, "")), 84, Gx_line+80, 335, Gx_line+95, 0, 0, 0, 1) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText("Supplier:", 20, Gx_line+80, 80, Gx_line+95, 2, 0, 0, 1) ;
                     getPrinter().GxDrawText("State:", 40, Gx_line+107, 80, Gx_line+122, 2, 0, 0, 1) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23State, "")), 84, Gx_line+107, 157, Gx_line+122, 0, 0, 0, 1) ;
                     getPrinter().GxDrawText(context.localUtil.Format( A52PurchaseOrderCreatedDate, "99/99/99"), 431, Gx_line+80, 531, Gx_line+95, 0, 0, 0, 1) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText("Generated:", 353, Gx_line+80, 425, Gx_line+95, 2, 0, 0, 1) ;
                     getPrinter().GxDrawText("Total Projected", 307, Gx_line+107, 425, Gx_line+122, 2, 0, 0, 1) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV25PurchaseOrderTotalProjected, "ZZZZZZZZZZZZZZ9.99")), 431, Gx_line+107, 531, Gx_line+122, 0, 0, 0, 1) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+133);
                  }
                  else if ( StringUtil.StrCmp(AV23State, "Confirmated") == 0 )
                  {
                     getPrinter().GxAttris("Microsoft Sans Serif", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText("Generated:", 353, Gx_line+80, 425, Gx_line+95, 2, 0, 0, 1) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(context.localUtil.Format( A52PurchaseOrderCreatedDate, "99/99/99"), 433, Gx_line+80, 533, Gx_line+95, 2, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23State, "")), 87, Gx_line+107, 160, Gx_line+122, 0, 0, 0, 1) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText("State:", 40, Gx_line+107, 80, Gx_line+122, 2, 0, 0, 1) ;
                     getPrinter().GxDrawText("Supplier:", 20, Gx_line+80, 80, Gx_line+95, 2, 0, 0, 1) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A5SupplierName, "")), 87, Gx_line+80, 338, Gx_line+95, 0, 0, 0, 1) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 14, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A50PurchaseOrderId), "ZZZZZ9")), 387, Gx_line+13, 614, Gx_line+53, 0, 0, 0, 1) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 14, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText("Voucher Nro: ", 213, Gx_line+13, 383, Gx_line+53, 2, 0, 0, 1) ;
                     getPrinter().GxDrawRect(13, Gx_line+0, 813, Gx_line+133, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText("Confirmated:", 333, Gx_line+107, 425, Gx_line+122, 2, 0, 0, 1) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(context.localUtil.Format( A135PurchaseOrderConfirmatedDate, "99/99/99"), 433, Gx_line+107, 533, Gx_line+121, 2, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV25PurchaseOrderTotalProjected, "ZZZZZZZZZZZZZZ9.99")), 673, Gx_line+80, 773, Gx_line+95, 2, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText("Total Projected", 567, Gx_line+80, 665, Gx_line+95, 2, 0, 0, 1) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+133);
                  }
                  else
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
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15PurchaseOrderState, "")), 265, Gx_line+86, 338, Gx_line+101, 0, 0, 0, 1) ;
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
         add_metrics2( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      protected void add_metrics2( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", true, true, 58, 14, 72, 123,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 18, 21, 30, 35, 35, 55, 45, 14, 21, 21, 25, 37, 18, 21, 18, 18, 35, 35, 35, 35, 35, 35, 35, 35, 35, 35, 21, 21, 37, 37, 37, 38, 61, 45, 45, 45, 45, 42, 38, 49, 45, 17, 35, 45, 38, 52, 45, 49, 42, 49, 45, 42, 38, 45, 42, 59, 42, 42, 38, 21, 18, 23, 37, 35, 21, 35, 38, 35, 38, 35, 21, 38, 38, 18, 18, 35, 18, 56, 38, 38, 38, 38, 25, 35, 21, 38, 35, 49, 35, 35, 32, 25, 17, 25, 37, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 18, 21, 36, 35, 35, 35, 17, 35, 21, 46, 23, 35, 37, 21, 46, 35, 25, 35, 21, 21, 21, 36, 35, 21, 21, 21, 23, 35, 53, 53, 53, 38, 45, 45, 45, 45, 45, 45, 63, 45, 42, 42, 42, 42, 18, 18, 18, 18, 45, 45, 49, 49, 49, 49, 49, 37, 49, 45, 45, 45, 45, 42, 42, 38, 35, 35, 35, 35, 35, 35, 56, 35, 35, 35, 35, 35, 18, 18, 18, 18, 38, 38, 38, 38, 38, 38, 38, 35, 38, 38, 38, 38, 38, 35, 38, 35}) ;
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
         AV8FileName = "";
         scmdbuf = "";
         P00322_A4SupplierId = new int[1] ;
         P00322_A50PurchaseOrderId = new int[1] ;
         P00322_A136PurchaseOrderCanceledDescripti = new string[] {""} ;
         P00322_n136PurchaseOrderCanceledDescripti = new bool[] {false} ;
         P00322_A52PurchaseOrderCreatedDate = new DateTime[] {DateTime.MinValue} ;
         P00322_A5SupplierName = new string[] {""} ;
         P00322_A53PurchaseOrderModifiedDate = new DateTime[] {DateTime.MinValue} ;
         P00322_n53PurchaseOrderModifiedDate = new bool[] {false} ;
         P00322_A66PurchaseOrderClosedDate = new DateTime[] {DateTime.MinValue} ;
         P00322_n66PurchaseOrderClosedDate = new bool[] {false} ;
         P00322_A78PurchaseOrderTotalPaid = new decimal[1] ;
         P00322_n78PurchaseOrderTotalPaid = new bool[] {false} ;
         P00322_A135PurchaseOrderConfirmatedDate = new DateTime[] {DateTime.MinValue} ;
         P00322_n135PurchaseOrderConfirmatedDate = new bool[] {false} ;
         A136PurchaseOrderCanceledDescripti = "";
         A52PurchaseOrderCreatedDate = DateTime.MinValue;
         A5SupplierName = "";
         A53PurchaseOrderModifiedDate = DateTime.MinValue;
         A66PurchaseOrderClosedDate = DateTime.MinValue;
         A135PurchaseOrderConfirmatedDate = DateTime.MinValue;
         AV23State = "";
         P00323_A15ProductId = new int[1] ;
         P00323_A50PurchaseOrderId = new int[1] ;
         P00323_A16ProductName = new string[] {""} ;
         P00323_A76PurchaseOrderDetailQuantityOrd = new int[1] ;
         P00323_A61PurchaseOrderDetailId = new int[1] ;
         A16ProductName = "";
         P00324_A15ProductId = new int[1] ;
         P00324_A50PurchaseOrderId = new int[1] ;
         P00324_A85ProductCostPrice = new decimal[1] ;
         P00324_n85ProductCostPrice = new bool[] {false} ;
         P00324_A76PurchaseOrderDetailQuantityOrd = new int[1] ;
         P00324_A17ProductStock = new int[1] ;
         P00324_n17ProductStock = new bool[] {false} ;
         P00324_A16ProductName = new string[] {""} ;
         P00324_A61PurchaseOrderDetailId = new int[1] ;
         P00325_A15ProductId = new int[1] ;
         P00325_A50PurchaseOrderId = new int[1] ;
         P00325_A134PurchaseOrderDetailSuggestedPr = new decimal[1] ;
         P00325_n134PurchaseOrderDetailSuggestedPr = new bool[] {false} ;
         P00325_A77PurchaseOrderDetailQuantityRec = new int[1] ;
         P00325_A16ProductName = new string[] {""} ;
         P00325_A76PurchaseOrderDetailQuantityOrd = new int[1] ;
         P00325_A61PurchaseOrderDetailId = new int[1] ;
         P00326_A15ProductId = new int[1] ;
         P00326_A50PurchaseOrderId = new int[1] ;
         P00326_A134PurchaseOrderDetailSuggestedPr = new decimal[1] ;
         P00326_n134PurchaseOrderDetailSuggestedPr = new bool[] {false} ;
         P00326_A77PurchaseOrderDetailQuantityRec = new int[1] ;
         P00326_A76PurchaseOrderDetailQuantityOrd = new int[1] ;
         P00326_A16ProductName = new string[] {""} ;
         P00326_A61PurchaseOrderDetailId = new int[1] ;
         P00327_A50PurchaseOrderId = new int[1] ;
         P00327_A79PurchaseOrderActive = new bool[] {false} ;
         P00327_A66PurchaseOrderClosedDate = new DateTime[] {DateTime.MinValue} ;
         P00327_n66PurchaseOrderClosedDate = new bool[] {false} ;
         P00327_A135PurchaseOrderConfirmatedDate = new DateTime[] {DateTime.MinValue} ;
         P00327_n135PurchaseOrderConfirmatedDate = new bool[] {false} ;
         P00328_A50PurchaseOrderId = new int[1] ;
         P00328_A134PurchaseOrderDetailSuggestedPr = new decimal[1] ;
         P00328_n134PurchaseOrderDetailSuggestedPr = new bool[] {false} ;
         P00328_A77PurchaseOrderDetailQuantityRec = new int[1] ;
         P00328_A61PurchaseOrderDetailId = new int[1] ;
         P00329_A15ProductId = new int[1] ;
         P00329_A50PurchaseOrderId = new int[1] ;
         P00329_A85ProductCostPrice = new decimal[1] ;
         P00329_n85ProductCostPrice = new bool[] {false} ;
         P00329_A76PurchaseOrderDetailQuantityOrd = new int[1] ;
         P00329_A61PurchaseOrderDetailId = new int[1] ;
         AV15PurchaseOrderState = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apurchaseordervoucher__default(),
            new Object[][] {
                new Object[] {
               P00322_A4SupplierId, P00322_A50PurchaseOrderId, P00322_A136PurchaseOrderCanceledDescripti, P00322_n136PurchaseOrderCanceledDescripti, P00322_A52PurchaseOrderCreatedDate, P00322_A5SupplierName, P00322_A53PurchaseOrderModifiedDate, P00322_n53PurchaseOrderModifiedDate, P00322_A66PurchaseOrderClosedDate, P00322_n66PurchaseOrderClosedDate,
               P00322_A78PurchaseOrderTotalPaid, P00322_n78PurchaseOrderTotalPaid, P00322_A135PurchaseOrderConfirmatedDate, P00322_n135PurchaseOrderConfirmatedDate
               }
               , new Object[] {
               P00323_A15ProductId, P00323_A50PurchaseOrderId, P00323_A16ProductName, P00323_A76PurchaseOrderDetailQuantityOrd, P00323_A61PurchaseOrderDetailId
               }
               , new Object[] {
               P00324_A15ProductId, P00324_A50PurchaseOrderId, P00324_A85ProductCostPrice, P00324_n85ProductCostPrice, P00324_A76PurchaseOrderDetailQuantityOrd, P00324_A17ProductStock, P00324_n17ProductStock, P00324_A16ProductName, P00324_A61PurchaseOrderDetailId
               }
               , new Object[] {
               P00325_A15ProductId, P00325_A50PurchaseOrderId, P00325_A134PurchaseOrderDetailSuggestedPr, P00325_n134PurchaseOrderDetailSuggestedPr, P00325_A77PurchaseOrderDetailQuantityRec, P00325_A16ProductName, P00325_A76PurchaseOrderDetailQuantityOrd, P00325_A61PurchaseOrderDetailId
               }
               , new Object[] {
               P00326_A15ProductId, P00326_A50PurchaseOrderId, P00326_A134PurchaseOrderDetailSuggestedPr, P00326_n134PurchaseOrderDetailSuggestedPr, P00326_A77PurchaseOrderDetailQuantityRec, P00326_A76PurchaseOrderDetailQuantityOrd, P00326_A16ProductName, P00326_A61PurchaseOrderDetailId
               }
               , new Object[] {
               P00327_A50PurchaseOrderId, P00327_A79PurchaseOrderActive, P00327_A66PurchaseOrderClosedDate, P00327_n66PurchaseOrderClosedDate, P00327_A135PurchaseOrderConfirmatedDate, P00327_n135PurchaseOrderConfirmatedDate
               }
               , new Object[] {
               P00328_A50PurchaseOrderId, P00328_A134PurchaseOrderDetailSuggestedPr, P00328_n134PurchaseOrderDetailSuggestedPr, P00328_A77PurchaseOrderDetailQuantityRec, P00328_A61PurchaseOrderDetailId
               }
               , new Object[] {
               P00329_A15ProductId, P00329_A50PurchaseOrderId, P00329_A85ProductCostPrice, P00329_n85ProductCostPrice, P00329_A76PurchaseOrderDetailQuantityOrd, P00329_A61PurchaseOrderDetailId
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
      private int AV21PurchaseOrderId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A50PurchaseOrderId ;
      private int A4SupplierId ;
      private int Gx_OldLine ;
      private int AV16QuantityTotalRequired ;
      private int AV17QuantityTotalReceived ;
      private int A15ProductId ;
      private int A76PurchaseOrderDetailQuantityOrd ;
      private int A61PurchaseOrderDetailId ;
      private int A17ProductStock ;
      private int A77PurchaseOrderDetailQuantityRec ;
      private decimal A78PurchaseOrderTotalPaid ;
      private decimal AV19PurchaseOrderDetailTotal ;
      private decimal A85ProductCostPrice ;
      private decimal AV18PurchaseOrderDetailSubtotal ;
      private decimal A134PurchaseOrderDetailSuggestedPr ;
      private decimal AV26PurchaseOrderDetailPrice ;
      private decimal AV25PurchaseOrderTotalProjected ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private DateTime A52PurchaseOrderCreatedDate ;
      private DateTime A53PurchaseOrderModifiedDate ;
      private DateTime A66PurchaseOrderClosedDate ;
      private DateTime A135PurchaseOrderConfirmatedDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool GxHdr2 ;
      private bool n136PurchaseOrderCanceledDescripti ;
      private bool n53PurchaseOrderModifiedDate ;
      private bool n66PurchaseOrderClosedDate ;
      private bool n78PurchaseOrderTotalPaid ;
      private bool n135PurchaseOrderConfirmatedDate ;
      private bool n85ProductCostPrice ;
      private bool n17ProductStock ;
      private bool n134PurchaseOrderDetailSuggestedPr ;
      private bool AV22Determined ;
      private bool A79PurchaseOrderActive ;
      private string AV8FileName ;
      private string A136PurchaseOrderCanceledDescripti ;
      private string A5SupplierName ;
      private string AV23State ;
      private string A16ProductName ;
      private string AV15PurchaseOrderState ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00322_A4SupplierId ;
      private int[] P00322_A50PurchaseOrderId ;
      private string[] P00322_A136PurchaseOrderCanceledDescripti ;
      private bool[] P00322_n136PurchaseOrderCanceledDescripti ;
      private DateTime[] P00322_A52PurchaseOrderCreatedDate ;
      private string[] P00322_A5SupplierName ;
      private DateTime[] P00322_A53PurchaseOrderModifiedDate ;
      private bool[] P00322_n53PurchaseOrderModifiedDate ;
      private DateTime[] P00322_A66PurchaseOrderClosedDate ;
      private bool[] P00322_n66PurchaseOrderClosedDate ;
      private decimal[] P00322_A78PurchaseOrderTotalPaid ;
      private bool[] P00322_n78PurchaseOrderTotalPaid ;
      private DateTime[] P00322_A135PurchaseOrderConfirmatedDate ;
      private bool[] P00322_n135PurchaseOrderConfirmatedDate ;
      private int[] P00323_A15ProductId ;
      private int[] P00323_A50PurchaseOrderId ;
      private string[] P00323_A16ProductName ;
      private int[] P00323_A76PurchaseOrderDetailQuantityOrd ;
      private int[] P00323_A61PurchaseOrderDetailId ;
      private int[] P00324_A15ProductId ;
      private int[] P00324_A50PurchaseOrderId ;
      private decimal[] P00324_A85ProductCostPrice ;
      private bool[] P00324_n85ProductCostPrice ;
      private int[] P00324_A76PurchaseOrderDetailQuantityOrd ;
      private int[] P00324_A17ProductStock ;
      private bool[] P00324_n17ProductStock ;
      private string[] P00324_A16ProductName ;
      private int[] P00324_A61PurchaseOrderDetailId ;
      private int[] P00325_A15ProductId ;
      private int[] P00325_A50PurchaseOrderId ;
      private decimal[] P00325_A134PurchaseOrderDetailSuggestedPr ;
      private bool[] P00325_n134PurchaseOrderDetailSuggestedPr ;
      private int[] P00325_A77PurchaseOrderDetailQuantityRec ;
      private string[] P00325_A16ProductName ;
      private int[] P00325_A76PurchaseOrderDetailQuantityOrd ;
      private int[] P00325_A61PurchaseOrderDetailId ;
      private int[] P00326_A15ProductId ;
      private int[] P00326_A50PurchaseOrderId ;
      private decimal[] P00326_A134PurchaseOrderDetailSuggestedPr ;
      private bool[] P00326_n134PurchaseOrderDetailSuggestedPr ;
      private int[] P00326_A77PurchaseOrderDetailQuantityRec ;
      private int[] P00326_A76PurchaseOrderDetailQuantityOrd ;
      private string[] P00326_A16ProductName ;
      private int[] P00326_A61PurchaseOrderDetailId ;
      private int[] P00327_A50PurchaseOrderId ;
      private bool[] P00327_A79PurchaseOrderActive ;
      private DateTime[] P00327_A66PurchaseOrderClosedDate ;
      private bool[] P00327_n66PurchaseOrderClosedDate ;
      private DateTime[] P00327_A135PurchaseOrderConfirmatedDate ;
      private bool[] P00327_n135PurchaseOrderConfirmatedDate ;
      private int[] P00328_A50PurchaseOrderId ;
      private decimal[] P00328_A134PurchaseOrderDetailSuggestedPr ;
      private bool[] P00328_n134PurchaseOrderDetailSuggestedPr ;
      private int[] P00328_A77PurchaseOrderDetailQuantityRec ;
      private int[] P00328_A61PurchaseOrderDetailId ;
      private int[] P00329_A15ProductId ;
      private int[] P00329_A50PurchaseOrderId ;
      private decimal[] P00329_A85ProductCostPrice ;
      private bool[] P00329_n85ProductCostPrice ;
      private int[] P00329_A76PurchaseOrderDetailQuantityOrd ;
      private int[] P00329_A61PurchaseOrderDetailId ;
   }

   public class apurchaseordervoucher__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00322;
          prmP00322 = new Object[] {
          new ParDef("@AV21PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmP00323;
          prmP00323 = new Object[] {
          new ParDef("@AV21PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmP00324;
          prmP00324 = new Object[] {
          new ParDef("@AV21PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmP00325;
          prmP00325 = new Object[] {
          new ParDef("@AV21PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmP00326;
          prmP00326 = new Object[] {
          new ParDef("@AV21PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmP00327;
          prmP00327 = new Object[] {
          new ParDef("@AV21PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmP00328;
          prmP00328 = new Object[] {
          new ParDef("@AV21PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmP00329;
          prmP00329 = new Object[] {
          new ParDef("@AV21PurchaseOrderId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00322", "SELECT T1.[SupplierId], T1.[PurchaseOrderId], T1.[PurchaseOrderCanceledDescripti], T1.[PurchaseOrderCreatedDate], T2.[SupplierName], T1.[PurchaseOrderModifiedDate], T1.[PurchaseOrderClosedDate], T1.[PurchaseOrderTotalPaid], T1.[PurchaseOrderConfirmatedDate] FROM ([PurchaseOrder] T1 INNER JOIN [Supplier] T2 ON T2.[SupplierId] = T1.[SupplierId]) WHERE T1.[PurchaseOrderId] = @AV21PurchaseOrderId ORDER BY T1.[PurchaseOrderId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00322,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00323", "SELECT T1.[ProductId], T1.[PurchaseOrderId], T2.[ProductName], T1.[PurchaseOrderDetailQuantityOrd], T1.[PurchaseOrderDetailId] FROM ([PurchaseOrderDetail] T1 INNER JOIN [Product] T2 ON T2.[ProductId] = T1.[ProductId]) WHERE T1.[PurchaseOrderId] = @AV21PurchaseOrderId ORDER BY T1.[PurchaseOrderId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00323,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00324", "SELECT T1.[ProductId], T1.[PurchaseOrderId], T2.[ProductCostPrice], T1.[PurchaseOrderDetailQuantityOrd], T2.[ProductStock], T2.[ProductName], T1.[PurchaseOrderDetailId] FROM ([PurchaseOrderDetail] T1 INNER JOIN [Product] T2 ON T2.[ProductId] = T1.[ProductId]) WHERE T1.[PurchaseOrderId] = @AV21PurchaseOrderId ORDER BY T1.[PurchaseOrderId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00324,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00325", "SELECT T1.[ProductId], T1.[PurchaseOrderId], T1.[PurchaseOrderDetailSuggestedPr], T1.[PurchaseOrderDetailQuantityRec], T2.[ProductName], T1.[PurchaseOrderDetailQuantityOrd], T1.[PurchaseOrderDetailId] FROM ([PurchaseOrderDetail] T1 INNER JOIN [Product] T2 ON T2.[ProductId] = T1.[ProductId]) WHERE T1.[PurchaseOrderId] = @AV21PurchaseOrderId ORDER BY T1.[PurchaseOrderId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00325,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00326", "SELECT T1.[ProductId], T1.[PurchaseOrderId], T1.[PurchaseOrderDetailSuggestedPr], T1.[PurchaseOrderDetailQuantityRec], T1.[PurchaseOrderDetailQuantityOrd], T2.[ProductName], T1.[PurchaseOrderDetailId] FROM ([PurchaseOrderDetail] T1 INNER JOIN [Product] T2 ON T2.[ProductId] = T1.[ProductId]) WHERE T1.[PurchaseOrderId] = @AV21PurchaseOrderId ORDER BY T1.[PurchaseOrderId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00326,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00327", "SELECT TOP 1 [PurchaseOrderId], [PurchaseOrderActive], [PurchaseOrderClosedDate], [PurchaseOrderConfirmatedDate] FROM [PurchaseOrder] WHERE [PurchaseOrderId] = @AV21PurchaseOrderId ORDER BY [PurchaseOrderId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00327,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00328", "SELECT [PurchaseOrderId], [PurchaseOrderDetailSuggestedPr], [PurchaseOrderDetailQuantityRec], [PurchaseOrderDetailId] FROM [PurchaseOrderDetail] WHERE [PurchaseOrderId] = @AV21PurchaseOrderId ORDER BY [PurchaseOrderId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00328,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00329", "SELECT T1.[ProductId], T1.[PurchaseOrderId], T2.[ProductCostPrice], T1.[PurchaseOrderDetailQuantityOrd], T1.[PurchaseOrderDetailId] FROM ([PurchaseOrderDetail] T1 INNER JOIN [Product] T2 ON T2.[ProductId] = T1.[ProductId]) WHERE T1.[PurchaseOrderId] = @AV21PurchaseOrderId ORDER BY T1.[PurchaseOrderId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00329,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(7);
                ((bool[]) buf[9])[0] = rslt.wasNull(7);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(8);
                ((bool[]) buf[11])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(9);
                ((bool[]) buf[13])[0] = rslt.wasNull(9);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((int[]) buf[4])[0] = rslt.getInt(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                ((int[]) buf[8])[0] = rslt.getInt(7);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((int[]) buf[4])[0] = rslt.getInt(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((int[]) buf[4])[0] = rslt.getInt(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((int[]) buf[4])[0] = rslt.getInt(4);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((int[]) buf[4])[0] = rslt.getInt(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                return;
       }
    }

 }

}
