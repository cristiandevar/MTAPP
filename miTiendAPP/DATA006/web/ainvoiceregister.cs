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
   public class ainvoiceregister : GXWebProcedure
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
            gxfirstwebparm = GetFirstPar( "InvoiceId");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV21InvoiceId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV15AllOk = StringUtil.StrToBool( GetPar( "AllOk"));
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

      public ainvoiceregister( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public ainvoiceregister( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_InvoiceId ,
                           out bool aP1_AllOk )
      {
         this.AV21InvoiceId = aP0_InvoiceId;
         this.AV15AllOk = false ;
         initialize();
         executePrivate();
         aP1_AllOk=this.AV15AllOk;
      }

      public bool executeUdp( int aP0_InvoiceId )
      {
         execute(aP0_InvoiceId, out aP1_AllOk);
         return AV15AllOk ;
      }

      public void executeSubmit( int aP0_InvoiceId ,
                                 out bool aP1_AllOk )
      {
         ainvoiceregister objainvoiceregister;
         objainvoiceregister = new ainvoiceregister();
         objainvoiceregister.AV21InvoiceId = aP0_InvoiceId;
         objainvoiceregister.AV15AllOk = false ;
         objainvoiceregister.context.SetSubmitInitialConfig(context);
         objainvoiceregister.initialize();
         Submit( executePrivateCatch,objainvoiceregister);
         aP1_AllOk=this.AV15AllOk;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((ainvoiceregister)stateInfo).executePrivate();
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
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 12413, 0, 1, 1, 0, 1, 1) )
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
            new getcontext(context ).execute( out  AV14Context, ref  AV15AllOk) ;
            if ( ! AV15AllOk )
            {
               CallWebObject(formatLink("wplogin.aspx") );
               context.wjLocDisableFrm = 1;
            }
            AV11FileName = "Ticket_" + StringUtil.Str( (decimal)(A20InvoiceId), 6, 0) + ".pdf";
            AV18ProductCodeChange = false;
            GxHdr2 = true;
            /* Using cursor P00112 */
            pr_default.execute(0, new Object[] {AV21InvoiceId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A99UserId = P00112_A99UserId[0];
               A20InvoiceId = P00112_A20InvoiceId[0];
               A100UserName = P00112_A100UserName[0];
               A38InvoiceCreatedDate = P00112_A38InvoiceCreatedDate[0];
               A100UserName = P00112_A100UserName[0];
               H110( false, 23) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Type", 773, Gx_line+6, 813, Gx_line+21, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(13, Gx_line+22, 846, Gx_line+22, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Product", 27, Gx_line+6, 94, Gx_line+21, 0, 0, 0, 1) ;
               getPrinter().GxDrawText("Unit Price", 347, Gx_line+6, 434, Gx_line+21, 2, 0, 0, 1) ;
               getPrinter().GxDrawText("Quantity", 493, Gx_line+6, 580, Gx_line+21, 2, 0, 0, 1) ;
               getPrinter().GxDrawText("Subtotal", 640, Gx_line+6, 727, Gx_line+21, 2, 0, 0, 1) ;
               getPrinter().GxDrawLine(13, Gx_line+0, 13, Gx_line+22, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(846, Gx_line+0, 846, Gx_line+22, 1, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+23);
               AV10Total = 0;
               /* Using cursor P00113 */
               pr_default.execute(1, new Object[] {A20InvoiceId});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A98InvoiceDetailIsWholesale = P00113_A98InvoiceDetailIsWholesale[0];
                  A15ProductId = P00113_A15ProductId[0];
                  A26InvoiceDetailQuantity = P00113_A26InvoiceDetailQuantity[0];
                  A65InvoiceDetailHistoricPrice = P00113_A65InvoiceDetailHistoricPrice[0];
                  A16ProductName = P00113_A16ProductName[0];
                  A25InvoiceDetailId = P00113_A25InvoiceDetailId[0];
                  A16ProductName = P00113_A16ProductName[0];
                  if ( A98InvoiceDetailIsWholesale )
                  {
                     AV16Type = "Wholesale";
                  }
                  else
                  {
                     AV16Type = "Retail";
                  }
                  AV17Product.Load(A15ProductId);
                  if ( ! new productexistothersamecode(context).executeUdp(  AV17Product.gxTpr_Productid,  AV17Product.gxTpr_Productcode) )
                  {
                     AV19InvoiceDetailQuantity = A26InvoiceDetailQuantity;
                     AV9Subtotal = (decimal)(A65InvoiceDetailHistoricPrice*A26InvoiceDetailQuantity);
                     AV10Total = (decimal)(AV10Total+AV9Subtotal);
                     H110( false, 19) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A16ProductName, "")), 27, Gx_line+5, 341, Gx_line+20, 0+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A65InvoiceDetailHistoricPrice, "ZZZZZZZZZZZZZZ9.99")), 347, Gx_line+5, 434, Gx_line+20, 2, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV19InvoiceDetailQuantity), "ZZZZZ9")), 493, Gx_line+5, 580, Gx_line+20, 2, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV9Subtotal, "ZZZZZZZZZZZZZZ9.99")), 647, Gx_line+5, 727, Gx_line+20, 2, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16Type, "")), 773, Gx_line+5, 833, Gx_line+20, 0, 0, 0, 0) ;
                     getPrinter().GxDrawLine(13, Gx_line+0, 13, Gx_line+19, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawLine(846, Gx_line+0, 846, Gx_line+19, 1, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+19);
                  }
                  else
                  {
                     if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20ProductCode)) || ( StringUtil.StrCmp(AV20ProductCode, AV17Product.gxTpr_Productcode) != 0 ) )
                     {
                        AV20ProductCode = AV17Product.gxTpr_Productcode;
                        /* Execute user subroutine: 'CALCULATEQUANTITY' */
                        S111 ();
                        if ( returnInSub )
                        {
                           pr_default.close(1);
                           this.cleanup();
                           if (true) return;
                        }
                        AV9Subtotal = (decimal)(A65InvoiceDetailHistoricPrice*AV19InvoiceDetailQuantity);
                        AV10Total = (decimal)(AV10Total+AV9Subtotal);
                        H110( false, 19) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A16ProductName, "")), 27, Gx_line+5, 341, Gx_line+20, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A65InvoiceDetailHistoricPrice, "ZZZZZZZZZZZZZZ9.99")), 347, Gx_line+5, 434, Gx_line+20, 2, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV19InvoiceDetailQuantity), "ZZZZZ9")), 493, Gx_line+5, 580, Gx_line+20, 2, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV9Subtotal, "ZZZZZZZZZZZZZZ9.99")), 647, Gx_line+5, 727, Gx_line+20, 2, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16Type, "")), 773, Gx_line+5, 833, Gx_line+20, 0, 0, 0, 0) ;
                        getPrinter().GxDrawLine(13, Gx_line+0, 13, Gx_line+19, 1, 0, 0, 0, 0) ;
                        getPrinter().GxDrawLine(846, Gx_line+0, 846, Gx_line+19, 1, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+19);
                     }
                  }
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               H110( false, 28) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Total Details:", 473, Gx_line+6, 580, Gx_line+21, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV10Total, "ZZZZZZZZZZZZZZ9.99")), 627, Gx_line+6, 727, Gx_line+21, 2, 0, 0, 0) ;
               getPrinter().GxDrawLine(420, Gx_line+0, 847, Gx_line+0, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(13, Gx_line+27, 846, Gx_line+27, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(13, Gx_line+0, 13, Gx_line+27, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(846, Gx_line+0, 846, Gx_line+27, 1, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+28);
               H110( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Payment Method", 27, Gx_line+2, 154, Gx_line+17, 0, 0, 0, 1) ;
               getPrinter().GxDrawLine(13, Gx_line+19, 846, Gx_line+19, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Import", 284, Gx_line+2, 337, Gx_line+17, 0, 0, 0, 1) ;
               getPrinter().GxDrawText("Discount", 451, Gx_line+2, 524, Gx_line+17, 0, 0, 0, 1) ;
               getPrinter().GxDrawText("Recarge", 617, Gx_line+2, 687, Gx_line+17, 0, 0, 0, 1) ;
               getPrinter().GxDrawText("Subtotal", 760, Gx_line+2, 830, Gx_line+17, 0, 0, 0, 1) ;
               getPrinter().GxDrawLine(13, Gx_line+0, 13, Gx_line+19, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(846, Gx_line+0, 846, Gx_line+19, 1, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
               AV25PaymentMethodTotal = 0;
               AV24PaymentMethodSubtotal = 0;
               /* Using cursor P00114 */
               pr_default.execute(2, new Object[] {A20InvoiceId});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A115PaymentMethodId = P00114_A115PaymentMethodId[0];
                  n115PaymentMethodId = P00114_n115PaymentMethodId[0];
                  A132InvoicePaymentMethodRechargeIm = P00114_A132InvoicePaymentMethodRechargeIm[0];
                  n132InvoicePaymentMethodRechargeIm = P00114_n132InvoicePaymentMethodRechargeIm[0];
                  A133InvoicePaymentMethodDiscountIm = P00114_A133InvoicePaymentMethodDiscountIm[0];
                  n133InvoicePaymentMethodDiscountIm = P00114_n133InvoicePaymentMethodDiscountIm[0];
                  A120InvoicePaymentMethodImport = P00114_A120InvoicePaymentMethodImport[0];
                  n120InvoicePaymentMethodImport = P00114_n120InvoicePaymentMethodImport[0];
                  A116PaymentMethodDescription = P00114_A116PaymentMethodDescription[0];
                  A118InvoicePaymentMethodId = P00114_A118InvoicePaymentMethodId[0];
                  A116PaymentMethodDescription = P00114_A116PaymentMethodDescription[0];
                  AV24PaymentMethodSubtotal = (decimal)((A120InvoicePaymentMethodImport-A133InvoicePaymentMethodDiscountIm+A132InvoicePaymentMethodRechargeIm));
                  AV25PaymentMethodTotal = (decimal)(AV25PaymentMethodTotal+AV24PaymentMethodSubtotal);
                  H110( false, 19) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A116PaymentMethodDescription, "")), 27, Gx_line+5, 177, Gx_line+20, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A133InvoicePaymentMethodDiscountIm, "ZZZZZZZZZZZZZZ9.99")), 374, Gx_line+5, 524, Gx_line+20, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A132InvoicePaymentMethodRechargeIm, "ZZZZZZZZZZZZZZ9.99")), 537, Gx_line+5, 687, Gx_line+20, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A120InvoicePaymentMethodImport, "ZZZZZZZZZZZZZZ9.99")), 187, Gx_line+5, 337, Gx_line+20, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV24PaymentMethodSubtotal, "ZZZZZZZZZZZZZZ9.99")), 724, Gx_line+5, 838, Gx_line+20, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawLine(13, Gx_line+0, 13, Gx_line+19, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(846, Gx_line+0, 846, Gx_line+19, 1, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+19);
                  pr_default.readNext(2);
               }
               pr_default.close(2);
               H110( false, 28) ;
               getPrinter().GxDrawLine(420, Gx_line+0, 847, Gx_line+0, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV25PaymentMethodTotal, "ZZZZZZZZZZZZZZ9.99")), 730, Gx_line+6, 830, Gx_line+21, 2, 0, 0, 0) ;
               getPrinter().GxDrawText("Total Receivable:", 567, Gx_line+6, 714, Gx_line+21, 2, 0, 0, 0) ;
               getPrinter().GxDrawLine(846, Gx_line+0, 846, Gx_line+27, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(13, Gx_line+0, 13, Gx_line+27, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(13, Gx_line+27, 846, Gx_line+27, 1, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+28);
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            GxHdr2 = false;
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H110( true, 0) ;
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
         /* 'CALCULATEQUANTITY' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GETIDSSAMECODE' */
         S121 ();
         if (returnInSub) return;
         AV19InvoiceDetailQuantity = 0;
         /* Optimized group. */
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A15ProductId ,
                                              AV22SameCodeIds ,
                                              AV21InvoiceId } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT
                                              }
         });
         /* Using cursor P00115 */
         pr_default.execute(3, new Object[] {AV21InvoiceId});
         c26InvoiceDetailQuantity = P00115_A26InvoiceDetailQuantity[0];
         pr_default.close(3);
         AV19InvoiceDetailQuantity = (int)(AV19InvoiceDetailQuantity+c26InvoiceDetailQuantity);
         /* End optimized group. */
      }

      protected void S121( )
      {
         /* 'GETIDSSAMECODE' Routine */
         returnInSub = false;
         AV22SameCodeIds = (GxSimpleCollection<int>)(new GxSimpleCollection<int>());
         /* Using cursor P00116 */
         pr_default.execute(4, new Object[] {AV21InvoiceId});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A20InvoiceId = P00116_A20InvoiceId[0];
            A15ProductId = P00116_A15ProductId[0];
            A25InvoiceDetailId = P00116_A25InvoiceDetailId[0];
            AV23ProductAux.Load(A15ProductId);
            if ( StringUtil.StrCmp(AV20ProductCode, AV23ProductAux.gxTpr_Productcode) == 0 )
            {
               AV22SameCodeIds.Add(AV23ProductAux.gxTpr_Productid, 0);
            }
            pr_default.readNext(4);
         }
         pr_default.close(4);
      }

      protected void H110( bool bFoot ,
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
                  getPrinter().GxDrawLine(13, Gx_line+0, 846, Gx_line+0, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("miTiendAPP", 133, Gx_line+0, 246, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Ticket registered by", 27, Gx_line+0, 134, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+22);
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
                  getPrinter().GxDrawText("Ticket Nro.", 293, Gx_line+13, 433, Gx_line+43, 2, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 14, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A20InvoiceId), "ZZZZZ9")), 440, Gx_line+13, 540, Gx_line+43, 0, 0, 0, 0) ;
                  getPrinter().GxDrawRect(13, Gx_line+2, 846, Gx_line+135, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Registered:", 22, Gx_line+86, 94, Gx_line+101, 2, 0, 0, 1) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A38InvoiceCreatedDate, "99/99/99"), 97, Gx_line+86, 197, Gx_line+101, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A100UserName, "")), 97, Gx_line+112, 197, Gx_line+127, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Seller:", 20, Gx_line+112, 92, Gx_line+127, 2, 0, 0, 1) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+135);
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
         getPrinter().setMetrics("Microsoft Sans Serif", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
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
         AV14Context = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         AV11FileName = "";
         scmdbuf = "";
         P00112_A99UserId = new int[1] ;
         P00112_A20InvoiceId = new int[1] ;
         P00112_A100UserName = new string[] {""} ;
         P00112_A38InvoiceCreatedDate = new DateTime[] {DateTime.MinValue} ;
         A100UserName = "";
         A38InvoiceCreatedDate = DateTime.MinValue;
         P00113_A20InvoiceId = new int[1] ;
         P00113_A98InvoiceDetailIsWholesale = new bool[] {false} ;
         P00113_A15ProductId = new int[1] ;
         P00113_A26InvoiceDetailQuantity = new int[1] ;
         P00113_A65InvoiceDetailHistoricPrice = new decimal[1] ;
         P00113_A16ProductName = new string[] {""} ;
         P00113_A25InvoiceDetailId = new int[1] ;
         A16ProductName = "";
         AV16Type = "";
         AV17Product = new SdtProduct(context);
         AV20ProductCode = "";
         P00114_A115PaymentMethodId = new int[1] ;
         P00114_n115PaymentMethodId = new bool[] {false} ;
         P00114_A20InvoiceId = new int[1] ;
         P00114_A132InvoicePaymentMethodRechargeIm = new decimal[1] ;
         P00114_n132InvoicePaymentMethodRechargeIm = new bool[] {false} ;
         P00114_A133InvoicePaymentMethodDiscountIm = new decimal[1] ;
         P00114_n133InvoicePaymentMethodDiscountIm = new bool[] {false} ;
         P00114_A120InvoicePaymentMethodImport = new decimal[1] ;
         P00114_n120InvoicePaymentMethodImport = new bool[] {false} ;
         P00114_A116PaymentMethodDescription = new string[] {""} ;
         P00114_A118InvoicePaymentMethodId = new int[1] ;
         A116PaymentMethodDescription = "";
         AV22SameCodeIds = new GxSimpleCollection<int>();
         P00115_A26InvoiceDetailQuantity = new int[1] ;
         P00116_A20InvoiceId = new int[1] ;
         P00116_A15ProductId = new int[1] ;
         P00116_A25InvoiceDetailId = new int[1] ;
         AV23ProductAux = new SdtProduct(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ainvoiceregister__default(),
            new Object[][] {
                new Object[] {
               P00112_A99UserId, P00112_A20InvoiceId, P00112_A100UserName, P00112_A38InvoiceCreatedDate
               }
               , new Object[] {
               P00113_A20InvoiceId, P00113_A98InvoiceDetailIsWholesale, P00113_A15ProductId, P00113_A26InvoiceDetailQuantity, P00113_A65InvoiceDetailHistoricPrice, P00113_A16ProductName, P00113_A25InvoiceDetailId
               }
               , new Object[] {
               P00114_A115PaymentMethodId, P00114_n115PaymentMethodId, P00114_A20InvoiceId, P00114_A132InvoicePaymentMethodRechargeIm, P00114_n132InvoicePaymentMethodRechargeIm, P00114_A133InvoicePaymentMethodDiscountIm, P00114_n133InvoicePaymentMethodDiscountIm, P00114_A120InvoicePaymentMethodImport, P00114_n120InvoicePaymentMethodImport, P00114_A116PaymentMethodDescription,
               P00114_A118InvoicePaymentMethodId
               }
               , new Object[] {
               P00115_A26InvoiceDetailQuantity
               }
               , new Object[] {
               P00116_A20InvoiceId, P00116_A15ProductId, P00116_A25InvoiceDetailId
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
      private int AV21InvoiceId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A20InvoiceId ;
      private int A99UserId ;
      private int Gx_OldLine ;
      private int A15ProductId ;
      private int A26InvoiceDetailQuantity ;
      private int A25InvoiceDetailId ;
      private int AV19InvoiceDetailQuantity ;
      private int A115PaymentMethodId ;
      private int A118InvoicePaymentMethodId ;
      private int c26InvoiceDetailQuantity ;
      private decimal AV10Total ;
      private decimal A65InvoiceDetailHistoricPrice ;
      private decimal AV9Subtotal ;
      private decimal AV25PaymentMethodTotal ;
      private decimal AV24PaymentMethodSubtotal ;
      private decimal A132InvoicePaymentMethodRechargeIm ;
      private decimal A133InvoicePaymentMethodDiscountIm ;
      private decimal A120InvoicePaymentMethodImport ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private DateTime A38InvoiceCreatedDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15AllOk ;
      private bool AV18ProductCodeChange ;
      private bool GxHdr2 ;
      private bool A98InvoiceDetailIsWholesale ;
      private bool returnInSub ;
      private bool n115PaymentMethodId ;
      private bool n132InvoicePaymentMethodRechargeIm ;
      private bool n133InvoicePaymentMethodDiscountIm ;
      private bool n120InvoicePaymentMethodImport ;
      private string AV11FileName ;
      private string A100UserName ;
      private string A16ProductName ;
      private string AV16Type ;
      private string AV20ProductCode ;
      private string A116PaymentMethodDescription ;
      private GxSimpleCollection<int> AV22SameCodeIds ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00112_A99UserId ;
      private int[] P00112_A20InvoiceId ;
      private string[] P00112_A100UserName ;
      private DateTime[] P00112_A38InvoiceCreatedDate ;
      private int[] P00113_A20InvoiceId ;
      private bool[] P00113_A98InvoiceDetailIsWholesale ;
      private int[] P00113_A15ProductId ;
      private int[] P00113_A26InvoiceDetailQuantity ;
      private decimal[] P00113_A65InvoiceDetailHistoricPrice ;
      private string[] P00113_A16ProductName ;
      private int[] P00113_A25InvoiceDetailId ;
      private int[] P00114_A115PaymentMethodId ;
      private bool[] P00114_n115PaymentMethodId ;
      private int[] P00114_A20InvoiceId ;
      private decimal[] P00114_A132InvoicePaymentMethodRechargeIm ;
      private bool[] P00114_n132InvoicePaymentMethodRechargeIm ;
      private decimal[] P00114_A133InvoicePaymentMethodDiscountIm ;
      private bool[] P00114_n133InvoicePaymentMethodDiscountIm ;
      private decimal[] P00114_A120InvoicePaymentMethodImport ;
      private bool[] P00114_n120InvoicePaymentMethodImport ;
      private string[] P00114_A116PaymentMethodDescription ;
      private int[] P00114_A118InvoicePaymentMethodId ;
      private int[] P00115_A26InvoiceDetailQuantity ;
      private int[] P00116_A20InvoiceId ;
      private int[] P00116_A15ProductId ;
      private int[] P00116_A25InvoiceDetailId ;
      private bool aP1_AllOk ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession AV14Context ;
      private SdtProduct AV17Product ;
      private SdtProduct AV23ProductAux ;
   }

   public class ainvoiceregister__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00115( IGxContext context ,
                                             int A15ProductId ,
                                             GxSimpleCollection<int> AV22SameCodeIds ,
                                             int AV21InvoiceId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT SUM([InvoiceDetailQuantity]) FROM [InvoiceDetail]";
         AddWhere(sWhereString, "([InvoiceId] = @AV21InvoiceId)");
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV22SameCodeIds, "[ProductId] IN (", ")")+")");
         scmdbuf += sWhereString;
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
               case 3 :
                     return conditional_P00115(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (int)dynConstraints[2] );
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
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00112;
          prmP00112 = new Object[] {
          new ParDef("@AV21InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmP00113;
          prmP00113 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmP00114;
          prmP00114 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmP00116;
          prmP00116 = new Object[] {
          new ParDef("@AV21InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmP00115;
          prmP00115 = new Object[] {
          new ParDef("@AV21InvoiceId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00112", "SELECT T1.[UserId], T1.[InvoiceId], T2.[UserName], T1.[InvoiceCreatedDate] FROM ([Invoice] T1 INNER JOIN [User] T2 ON T2.[UserId] = T1.[UserId]) WHERE T1.[InvoiceId] = @AV21InvoiceId ORDER BY T1.[InvoiceId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00112,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00113", "SELECT T1.[InvoiceId], T1.[InvoiceDetailIsWholesale], T1.[ProductId], T1.[InvoiceDetailQuantity], T1.[InvoiceDetailHistoricPrice], T2.[ProductName], T1.[InvoiceDetailId] FROM ([InvoiceDetail] T1 INNER JOIN [Product] T2 ON T2.[ProductId] = T1.[ProductId]) WHERE T1.[InvoiceId] = @InvoiceId ORDER BY T1.[InvoiceId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00113,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00114", "SELECT T1.[PaymentMethodId], T1.[InvoiceId], T1.[InvoicePaymentMethodRechargeIm], T1.[InvoicePaymentMethodDiscountIm], T1.[InvoicePaymentMethodImport], T2.[PaymentMethodDescription], T1.[InvoicePaymentMethodId] FROM ([InvoicePaymentMethod] T1 LEFT JOIN [PaymentMethod] T2 ON T2.[PaymentMethodId] = T1.[PaymentMethodId]) WHERE T1.[InvoiceId] = @InvoiceId ORDER BY T1.[InvoiceId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00114,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00115", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00115,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00116", "SELECT [InvoiceId], [ProductId], [InvoiceDetailId] FROM [InvoiceDetail] WHERE [InvoiceId] = @AV21InvoiceId ORDER BY [InvoiceId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00116,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((int[]) buf[10])[0] = rslt.getInt(7);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
       }
    }

 }

}
