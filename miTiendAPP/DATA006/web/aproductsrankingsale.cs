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
   public class aproductsrankingsale : GXWebProcedure
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
            gxfirstwebparm = GetFirstPar( "Name");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV16Name = gxfirstwebparm;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV10SupplierId = (int)(Math.Round(NumberUtil.Val( GetPar( "SupplierId"), "."), 18, MidpointRounding.ToEven));
                  AV11SectorId = (int)(Math.Round(NumberUtil.Val( GetPar( "SectorId"), "."), 18, MidpointRounding.ToEven));
                  AV15BrandId = (int)(Math.Round(NumberUtil.Val( GetPar( "BrandId"), "."), 18, MidpointRounding.ToEven));
                  AV17FromDate = context.localUtil.ParseDateParm( GetPar( "FromDate"));
                  AV18ToDate = context.localUtil.ParseDateParm( GetPar( "ToDate"));
                  AV20Order = (short)(Math.Round(NumberUtil.Val( GetPar( "Order"), "."), 18, MidpointRounding.ToEven));
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

      public aproductsrankingsale( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public aproductsrankingsale( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Name ,
                           ref int aP1_SupplierId ,
                           ref int aP2_SectorId ,
                           ref int aP3_BrandId ,
                           ref DateTime aP4_FromDate ,
                           ref DateTime aP5_ToDate ,
                           ref short aP6_Order )
      {
         this.AV16Name = aP0_Name;
         this.AV10SupplierId = aP1_SupplierId;
         this.AV11SectorId = aP2_SectorId;
         this.AV15BrandId = aP3_BrandId;
         this.AV17FromDate = aP4_FromDate;
         this.AV18ToDate = aP5_ToDate;
         this.AV20Order = aP6_Order;
         initialize();
         executePrivate();
         aP1_SupplierId=this.AV10SupplierId;
         aP2_SectorId=this.AV11SectorId;
         aP3_BrandId=this.AV15BrandId;
         aP4_FromDate=this.AV17FromDate;
         aP5_ToDate=this.AV18ToDate;
         aP6_Order=this.AV20Order;
      }

      public short executeUdp( string aP0_Name ,
                               ref int aP1_SupplierId ,
                               ref int aP2_SectorId ,
                               ref int aP3_BrandId ,
                               ref DateTime aP4_FromDate ,
                               ref DateTime aP5_ToDate )
      {
         execute(aP0_Name, ref aP1_SupplierId, ref aP2_SectorId, ref aP3_BrandId, ref aP4_FromDate, ref aP5_ToDate, ref aP6_Order);
         return AV20Order ;
      }

      public void executeSubmit( string aP0_Name ,
                                 ref int aP1_SupplierId ,
                                 ref int aP2_SectorId ,
                                 ref int aP3_BrandId ,
                                 ref DateTime aP4_FromDate ,
                                 ref DateTime aP5_ToDate ,
                                 ref short aP6_Order )
      {
         aproductsrankingsale objaproductsrankingsale;
         objaproductsrankingsale = new aproductsrankingsale();
         objaproductsrankingsale.AV16Name = aP0_Name;
         objaproductsrankingsale.AV10SupplierId = aP1_SupplierId;
         objaproductsrankingsale.AV11SectorId = aP2_SectorId;
         objaproductsrankingsale.AV15BrandId = aP3_BrandId;
         objaproductsrankingsale.AV17FromDate = aP4_FromDate;
         objaproductsrankingsale.AV18ToDate = aP5_ToDate;
         objaproductsrankingsale.AV20Order = aP6_Order;
         objaproductsrankingsale.context.SetSubmitInitialConfig(context);
         objaproductsrankingsale.initialize();
         Submit( executePrivateCatch,objaproductsrankingsale);
         aP1_SupplierId=this.AV10SupplierId;
         aP2_SectorId=this.AV11SectorId;
         aP3_BrandId=this.AV15BrandId;
         aP4_FromDate=this.AV17FromDate;
         aP5_ToDate=this.AV18ToDate;
         aP6_Order=this.AV20Order;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((aproductsrankingsale)stateInfo).executePrivate();
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
            new getcontext(context ).execute( out  AV24Context, ref  AV25AllOk) ;
            if ( ! AV25AllOk )
            {
               CallWebObject(formatLink("wplogin.aspx") );
               context.wjLocDisableFrm = 1;
            }
            GXt_objcol_SdtSDTRankingProducts_SDTRankingProductsItem1 = AV8Products;
            new dpproductsrankingsales(context ).execute(  AV16Name,  AV10SupplierId,  AV11SectorId,  AV15BrandId, out  GXt_objcol_SdtSDTRankingProducts_SDTRankingProductsItem1) ;
            AV8Products = GXt_objcol_SdtSDTRankingProducts_SDTRankingProductsItem1;
            if ( ! (DateTime.MinValue==AV17FromDate) || ! (DateTime.MinValue==AV18ToDate) )
            {
               AV28GXV1 = 1;
               while ( AV28GXV1 <= AV8Products.Count )
               {
                  AV9OneProduct = ((SdtSDTRankingProducts_SDTRankingProductsItem)AV8Products.Item(AV28GXV1));
                  AV21Count = 0;
                  AV22Units = 0;
                  AV23Subtotal = 0;
                  pr_default.dynParam(0, new Object[]{ new Object[]{
                                                       AV17FromDate ,
                                                       AV18ToDate ,
                                                       A38InvoiceCreatedDate ,
                                                       AV9OneProduct.gxTpr_Id ,
                                                       A15ProductId } ,
                                                       new int[]{
                                                       TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT
                                                       }
                  });
                  /* Using cursor P000O2 */
                  pr_default.execute(0, new Object[] {AV9OneProduct.gxTpr_Id, AV17FromDate, AV18ToDate});
                  while ( (pr_default.getStatus(0) != 101) )
                  {
                     A20InvoiceId = P000O2_A20InvoiceId[0];
                     A38InvoiceCreatedDate = P000O2_A38InvoiceCreatedDate[0];
                     A15ProductId = P000O2_A15ProductId[0];
                     A26InvoiceDetailQuantity = P000O2_A26InvoiceDetailQuantity[0];
                     A65InvoiceDetailHistoricPrice = P000O2_A65InvoiceDetailHistoricPrice[0];
                     A25InvoiceDetailId = P000O2_A25InvoiceDetailId[0];
                     A38InvoiceCreatedDate = P000O2_A38InvoiceCreatedDate[0];
                     AV23Subtotal = (decimal)(AV23Subtotal+A65InvoiceDetailHistoricPrice*A26InvoiceDetailQuantity);
                     AV21Count = (int)(AV21Count+1);
                     AV22Units = (int)(AV22Units+A26InvoiceDetailQuantity);
                     pr_default.readNext(0);
                  }
                  pr_default.close(0);
                  AV9OneProduct.gxTpr_Quantitysales = AV21Count;
                  AV9OneProduct.gxTpr_Quantityunitssale = AV22Units;
                  AV9OneProduct.gxTpr_Subtotal = AV23Subtotal;
                  AV28GXV1 = (int)(AV28GXV1+1);
               }
            }
            if ( ! (0==AV20Order) )
            {
               if ( AV20Order == 1 )
               {
                  AV8Products.Sort("[QuantitySales]");
               }
               else
               {
                  if ( AV20Order == 2 )
                  {
                     AV8Products.Sort("[QuantityUnitsSale]");
                  }
                  else
                  {
                     AV8Products.Sort("[Subtotal]");
                  }
               }
            }
            else
            {
               AV8Products.Sort("[QuantitySales]");
            }
            AV14Total = 0;
            AV30GXV2 = 1;
            while ( AV30GXV2 <= AV8Products.Count )
            {
               AV9OneProduct = ((SdtSDTRankingProducts_SDTRankingProductsItem)AV8Products.Item(AV30GXV2));
               AV14Total = (decimal)(AV14Total+AV9OneProduct.gxTpr_Subtotal);
               AV30GXV2 = (int)(AV30GXV2+1);
            }
            AV34GXV3 = 1;
            while ( AV34GXV3 <= AV8Products.Count )
            {
               AV9OneProduct = ((SdtSDTRankingProducts_SDTRankingProductsItem)AV8Products.Item(AV34GXV3));
               H0O0( false, 100) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(AV9OneProduct.gxTpr_Name, 13, Gx_line+27, 246, Gx_line+67, 0, 0, 0, 1) ;
               getPrinter().GxDrawText(context.localUtil.Format( (decimal)(AV9OneProduct.gxTpr_Quantitysales), "ZZZZZ9"), 260, Gx_line+40, 360, Gx_line+55, 0, 0, 0, 1) ;
               getPrinter().GxDrawText(context.localUtil.Format( (decimal)(AV9OneProduct.gxTpr_Quantityunitssale), "ZZZZZ9"), 493, Gx_line+40, 580, Gx_line+55, 0, 0, 0, 1) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV9OneProduct.gxTpr_Subtotal, "ZZZZZZZZZZZZZZ9.99"), 707, Gx_line+40, 814, Gx_line+55, 0, 0, 0, 1) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+100);
               AV34GXV3 = (int)(AV34GXV3+1);
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H0O0( true, 0) ;
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

      protected void H0O0( bool bFoot ,
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
               if ( (0==AV10SupplierId) && (0==AV11SectorId) && (0==AV15BrandId) && (DateTime.MinValue==AV17FromDate) && (DateTime.MinValue==AV18ToDate) )
               {
                  getPrinter().GxDrawLine(13, Gx_line+160, 813, Gx_line+160, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Total Raised", 700, Gx_line+120, 807, Gx_line+147, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("Units Sold", 487, Gx_line+120, 567, Gx_line+147, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("No. Sales", 253, Gx_line+120, 366, Gx_line+147, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("Name", 13, Gx_line+120, 93, Gx_line+147, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 15, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Ranking Products", 13, Gx_line+0, 326, Gx_line+46, 1, 0, 0, 1) ;
                  getPrinter().GxDrawText("No.  of Sales", 13, Gx_line+46, 326, Gx_line+92, 1, 0, 0, 1) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV14Total, "ZZZZZZ9.99")), 680, Gx_line+67, 744, Gx_line+94, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText("Total In :", 587, Gx_line+67, 667, Gx_line+94, 2, 0, 0, 1) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+173);
               }
               else
               {
                  /* Using cursor P000O3 */
                  pr_default.execute(1, new Object[] {AV10SupplierId});
                  while ( (pr_default.getStatus(1) != 101) )
                  {
                     A4SupplierId = P000O3_A4SupplierId[0];
                     A5SupplierName = P000O3_A5SupplierName[0];
                     AV12SupplierName = A5SupplierName;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(1);
                  /* Using cursor P000O4 */
                  pr_default.execute(2, new Object[] {AV11SectorId});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A9SectorId = P000O4_A9SectorId[0];
                     A10SectorName = P000O4_A10SectorName[0];
                     AV13SectorName = A10SectorName;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(2);
                  /* Using cursor P000O5 */
                  pr_default.execute(3, new Object[] {AV15BrandId});
                  while ( (pr_default.getStatus(3) != 101) )
                  {
                     A1BrandId = P000O5_A1BrandId[0];
                     A2BrandName = P000O5_A2BrandName[0];
                     AV19BrandName = A2BrandName;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(3);
                  getPrinter().GxAttris("Microsoft Sans Serif", 15, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Ranking Products", 7, Gx_line+27, 327, Gx_line+73, 1, 0, 0, 1) ;
                  getPrinter().GxDrawText("No.  of Sales", 7, Gx_line+73, 327, Gx_line+119, 1, 0, 0, 1) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Name", 13, Gx_line+147, 93, Gx_line+174, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("No. Sales", 253, Gx_line+147, 366, Gx_line+174, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("Units Sold", 487, Gx_line+147, 567, Gx_line+174, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("Total Raised", 700, Gx_line+147, 807, Gx_line+174, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19BrandName, "")), 453, Gx_line+93, 566, Gx_line+121, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV17FromDate, "99/99/99"), 673, Gx_line+13, 793, Gx_line+41, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText("Brand :", 360, Gx_line+93, 440, Gx_line+120, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("From Date", 580, Gx_line+13, 660, Gx_line+26, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText(" :", 580, Gx_line+26, 660, Gx_line+39, 2, 0, 0, 1) ;
                  getPrinter().GxDrawLine(13, Gx_line+187, 813, Gx_line+187, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("Total In :", 580, Gx_line+93, 660, Gx_line+120, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV14Total, "ZZZZZZ9.99")), 673, Gx_line+93, 737, Gx_line+120, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText("Sector :", 360, Gx_line+53, 440, Gx_line+80, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("Supplier : ", 360, Gx_line+13, 440, Gx_line+40, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13SectorName, "")), 453, Gx_line+53, 573, Gx_line+81, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12SupplierName, "")), 453, Gx_line+13, 566, Gx_line+41, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText("To Date :", 580, Gx_line+53, 660, Gx_line+80, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV18ToDate, "99/99/99"), 673, Gx_line+53, 793, Gx_line+81, 0, 0, 0, 1) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+201);
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
      }

      protected void add_metrics0( )
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
         AV24Context = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         AV8Products = new GXBaseCollection<SdtSDTRankingProducts_SDTRankingProductsItem>( context, "SDTRankingProductsItem", "mtaKB");
         GXt_objcol_SdtSDTRankingProducts_SDTRankingProductsItem1 = new GXBaseCollection<SdtSDTRankingProducts_SDTRankingProductsItem>( context, "SDTRankingProductsItem", "mtaKB");
         AV9OneProduct = new SdtSDTRankingProducts_SDTRankingProductsItem(context);
         scmdbuf = "";
         A38InvoiceCreatedDate = DateTime.MinValue;
         P000O2_A20InvoiceId = new int[1] ;
         P000O2_A38InvoiceCreatedDate = new DateTime[] {DateTime.MinValue} ;
         P000O2_A15ProductId = new int[1] ;
         P000O2_A26InvoiceDetailQuantity = new int[1] ;
         P000O2_A65InvoiceDetailHistoricPrice = new decimal[1] ;
         P000O2_A25InvoiceDetailId = new int[1] ;
         P000O3_A4SupplierId = new int[1] ;
         P000O3_A5SupplierName = new string[] {""} ;
         A5SupplierName = "";
         AV12SupplierName = "";
         P000O4_A9SectorId = new int[1] ;
         P000O4_A10SectorName = new string[] {""} ;
         A10SectorName = "";
         AV13SectorName = "";
         P000O5_A1BrandId = new int[1] ;
         P000O5_A2BrandName = new string[] {""} ;
         A2BrandName = "";
         AV19BrandName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aproductsrankingsale__default(),
            new Object[][] {
                new Object[] {
               P000O2_A20InvoiceId, P000O2_A38InvoiceCreatedDate, P000O2_A15ProductId, P000O2_A26InvoiceDetailQuantity, P000O2_A65InvoiceDetailHistoricPrice, P000O2_A25InvoiceDetailId
               }
               , new Object[] {
               P000O3_A4SupplierId, P000O3_A5SupplierName
               }
               , new Object[] {
               P000O4_A9SectorId, P000O4_A10SectorName
               }
               , new Object[] {
               P000O5_A1BrandId, P000O5_A2BrandName
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short AV20Order ;
      private short GxWebError ;
      private int AV10SupplierId ;
      private int AV11SectorId ;
      private int AV15BrandId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int AV28GXV1 ;
      private int AV21Count ;
      private int AV22Units ;
      private int AV9OneProduct_gxTpr_Id ;
      private int A15ProductId ;
      private int A20InvoiceId ;
      private int A26InvoiceDetailQuantity ;
      private int A25InvoiceDetailId ;
      private int AV30GXV2 ;
      private int AV34GXV3 ;
      private int Gx_OldLine ;
      private int A4SupplierId ;
      private int A9SectorId ;
      private int A1BrandId ;
      private decimal AV23Subtotal ;
      private decimal A65InvoiceDetailHistoricPrice ;
      private decimal AV14Total ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private DateTime AV17FromDate ;
      private DateTime AV18ToDate ;
      private DateTime A38InvoiceCreatedDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV25AllOk ;
      private string AV16Name ;
      private string A5SupplierName ;
      private string AV12SupplierName ;
      private string A10SectorName ;
      private string AV13SectorName ;
      private string A2BrandName ;
      private string AV19BrandName ;
      private IGxDataStore dsDefault ;
      private int aP1_SupplierId ;
      private int aP2_SectorId ;
      private int aP3_BrandId ;
      private DateTime aP4_FromDate ;
      private DateTime aP5_ToDate ;
      private short aP6_Order ;
      private IDataStoreProvider pr_default ;
      private int[] P000O2_A20InvoiceId ;
      private DateTime[] P000O2_A38InvoiceCreatedDate ;
      private int[] P000O2_A15ProductId ;
      private int[] P000O2_A26InvoiceDetailQuantity ;
      private decimal[] P000O2_A65InvoiceDetailHistoricPrice ;
      private int[] P000O2_A25InvoiceDetailId ;
      private int[] P000O3_A4SupplierId ;
      private string[] P000O3_A5SupplierName ;
      private int[] P000O4_A9SectorId ;
      private string[] P000O4_A10SectorName ;
      private int[] P000O5_A1BrandId ;
      private string[] P000O5_A2BrandName ;
      private GXBaseCollection<SdtSDTRankingProducts_SDTRankingProductsItem> AV8Products ;
      private GXBaseCollection<SdtSDTRankingProducts_SDTRankingProductsItem> GXt_objcol_SdtSDTRankingProducts_SDTRankingProductsItem1 ;
      private SdtSDTRankingProducts_SDTRankingProductsItem AV9OneProduct ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession AV24Context ;
   }

   public class aproductsrankingsale__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P000O2( IGxContext context ,
                                             DateTime AV17FromDate ,
                                             DateTime AV18ToDate ,
                                             DateTime A38InvoiceCreatedDate ,
                                             int AV9OneProduct_gxTpr_Id ,
                                             int A15ProductId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[3];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[InvoiceId], T2.[InvoiceCreatedDate], T1.[ProductId], T1.[InvoiceDetailQuantity], T1.[InvoiceDetailHistoricPrice], T1.[InvoiceDetailId] FROM ([InvoiceDetail] T1 INNER JOIN [Invoice] T2 ON T2.[InvoiceId] = T1.[InvoiceId])";
         AddWhere(sWhereString, "(T1.[ProductId] = @AV9OneProduct__Id)");
         if ( ! (DateTime.MinValue==AV17FromDate) )
         {
            AddWhere(sWhereString, "(T2.[InvoiceCreatedDate] >= @AV17FromDate)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV18ToDate) )
         {
            AddWhere(sWhereString, "(T2.[InvoiceCreatedDate] <= @AV18ToDate)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProductId]";
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
                     return conditional_P000O2(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000O3;
          prmP000O3 = new Object[] {
          new ParDef("@AV10SupplierId",GXType.Int32,6,0)
          };
          Object[] prmP000O4;
          prmP000O4 = new Object[] {
          new ParDef("@AV11SectorId",GXType.Int32,6,0)
          };
          Object[] prmP000O5;
          prmP000O5 = new Object[] {
          new ParDef("@AV15BrandId",GXType.Int32,6,0)
          };
          Object[] prmP000O2;
          prmP000O2 = new Object[] {
          new ParDef("@AV9OneProduct__Id",GXType.Int32,6,0) ,
          new ParDef("@AV17FromDate",GXType.Date,8,0) ,
          new ParDef("@AV18ToDate",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000O2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000O2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P000O3", "SELECT [SupplierId], [SupplierName] FROM [Supplier] WHERE [SupplierId] = @AV10SupplierId ORDER BY [SupplierId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000O3,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P000O4", "SELECT [SectorId], [SectorName] FROM [Sector] WHERE [SectorId] = @AV11SectorId ORDER BY [SectorId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000O4,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P000O5", "SELECT [BrandId], [BrandName] FROM [Brand] WHERE [BrandId] = @AV15BrandId ORDER BY [BrandId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000O5,1, GxCacheFrequency.OFF ,true,true )
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
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
