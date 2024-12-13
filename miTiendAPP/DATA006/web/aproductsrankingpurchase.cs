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
   public class aproductsrankingpurchase : GXWebProcedure
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
                  AV11SupplierId = (int)(Math.Round(NumberUtil.Val( GetPar( "SupplierId"), "."), 18, MidpointRounding.ToEven));
                  AV12SectorId = (int)(Math.Round(NumberUtil.Val( GetPar( "SectorId"), "."), 18, MidpointRounding.ToEven));
                  AV17BrandId = (int)(Math.Round(NumberUtil.Val( GetPar( "BrandId"), "."), 18, MidpointRounding.ToEven));
                  AV18FromDate = context.localUtil.ParseDateParm( GetPar( "FromDate"));
                  AV19ToDate = context.localUtil.ParseDateParm( GetPar( "ToDate"));
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

      public aproductsrankingpurchase( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public aproductsrankingpurchase( IGxContext context )
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
         this.AV11SupplierId = aP1_SupplierId;
         this.AV12SectorId = aP2_SectorId;
         this.AV17BrandId = aP3_BrandId;
         this.AV18FromDate = aP4_FromDate;
         this.AV19ToDate = aP5_ToDate;
         this.AV20Order = aP6_Order;
         initialize();
         executePrivate();
         aP1_SupplierId=this.AV11SupplierId;
         aP2_SectorId=this.AV12SectorId;
         aP3_BrandId=this.AV17BrandId;
         aP4_FromDate=this.AV18FromDate;
         aP5_ToDate=this.AV19ToDate;
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
         aproductsrankingpurchase objaproductsrankingpurchase;
         objaproductsrankingpurchase = new aproductsrankingpurchase();
         objaproductsrankingpurchase.AV16Name = aP0_Name;
         objaproductsrankingpurchase.AV11SupplierId = aP1_SupplierId;
         objaproductsrankingpurchase.AV12SectorId = aP2_SectorId;
         objaproductsrankingpurchase.AV17BrandId = aP3_BrandId;
         objaproductsrankingpurchase.AV18FromDate = aP4_FromDate;
         objaproductsrankingpurchase.AV19ToDate = aP5_ToDate;
         objaproductsrankingpurchase.AV20Order = aP6_Order;
         objaproductsrankingpurchase.context.SetSubmitInitialConfig(context);
         objaproductsrankingpurchase.initialize();
         Submit( executePrivateCatch,objaproductsrankingpurchase);
         aP1_SupplierId=this.AV11SupplierId;
         aP2_SectorId=this.AV12SectorId;
         aP3_BrandId=this.AV17BrandId;
         aP4_FromDate=this.AV18FromDate;
         aP5_ToDate=this.AV19ToDate;
         aP6_Order=this.AV20Order;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((aproductsrankingpurchase)stateInfo).executePrivate();
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
            new getcontext(context ).execute( out  AV25Context, ref  AV26AllOk) ;
            if ( ! AV26AllOk )
            {
               CallWebObject(formatLink("wplogin.aspx") );
               context.wjLocDisableFrm = 1;
            }
            GXt_objcol_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem1 = AV9Products;
            new dpproductsrankingpurchases(context ).execute(  AV16Name,  AV11SupplierId,  AV12SectorId,  AV17BrandId, out  GXt_objcol_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem1) ;
            AV9Products = GXt_objcol_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem1;
            if ( ! (DateTime.MinValue==AV18FromDate) || ! (DateTime.MinValue==AV19ToDate) )
            {
               AV29GXV1 = 1;
               while ( AV29GXV1 <= AV9Products.Count )
               {
                  AV8OneProduct = ((SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem)AV9Products.Item(AV29GXV1));
                  AV22Count = 0;
                  AV23Units = 0;
                  AV24Subtotal = 0;
                  /* Optimized group. */
                  pr_default.dynParam(0, new Object[]{ new Object[]{
                                                       AV18FromDate ,
                                                       AV19ToDate ,
                                                       A52PurchaseOrderCreatedDate ,
                                                       AV8OneProduct.gxTpr_Id } ,
                                                       new int[]{
                                                       TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT
                                                       }
                  });
                  /* Using cursor P000Q2 */
                  pr_default.execute(0, new Object[] {AV8OneProduct.gxTpr_Id, AV18FromDate, AV19ToDate});
                  c78PurchaseOrderTotalPaid = P000Q2_A78PurchaseOrderTotalPaid[0];
                  n78PurchaseOrderTotalPaid = P000Q2_n78PurchaseOrderTotalPaid[0];
                  cV22Count = P000Q2_AV22Count[0];
                  c77PurchaseOrderDetailQuantityRec = P000Q2_A77PurchaseOrderDetailQuantityRec[0];
                  pr_default.close(0);
                  AV24Subtotal = (decimal)(AV24Subtotal+c78PurchaseOrderTotalPaid);
                  AV22Count = (int)(AV22Count+cV22Count*1);
                  AV23Units = (int)(AV23Units+c77PurchaseOrderDetailQuantityRec);
                  /* End optimized group. */
                  AV8OneProduct.gxTpr_Quantitypurchases = (short)(AV22Count);
                  AV8OneProduct.gxTpr_Quantityunitspurchases = (short)(AV23Units);
                  AV8OneProduct.gxTpr_Total = AV24Subtotal;
                  AV29GXV1 = (int)(AV29GXV1+1);
               }
            }
            if ( ! (0==AV20Order) )
            {
               if ( AV20Order == 1 )
               {
                  AV9Products.Sort("[QuantityPurchases]");
               }
               else
               {
                  if ( AV20Order == 2 )
                  {
                     AV9Products.Sort("[QuantityUnitsPurchases]");
                  }
                  else
                  {
                     AV9Products.Sort("[Total]");
                  }
               }
            }
            else
            {
               AV9Products.Sort("[QuantityPurchases]");
            }
            AV10Total = 0;
            AV31GXV2 = 1;
            while ( AV31GXV2 <= AV9Products.Count )
            {
               AV8OneProduct = ((SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem)AV9Products.Item(AV31GXV2));
               AV10Total = (decimal)(AV10Total+AV8OneProduct.gxTpr_Total);
               AV31GXV2 = (int)(AV31GXV2+1);
            }
            AV35GXV3 = 1;
            while ( AV35GXV3 <= AV9Products.Count )
            {
               AV8OneProduct = ((SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem)AV9Products.Item(AV35GXV3));
               H0Q0( false, 67) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(AV8OneProduct.gxTpr_Name, 7, Gx_line+13, 220, Gx_line+53, 0, 0, 0, 1) ;
               getPrinter().GxDrawText(context.localUtil.Format( (decimal)(AV8OneProduct.gxTpr_Stock), "ZZZZZ9"), 233, Gx_line+27, 360, Gx_line+42, 0, 0, 0, 1) ;
               getPrinter().GxDrawText(context.localUtil.Format( (decimal)(AV8OneProduct.gxTpr_Quantitypurchases), "ZZZ9"), 367, Gx_line+26, 527, Gx_line+41, 0, 0, 0, 1) ;
               getPrinter().GxDrawText(context.localUtil.Format( (decimal)(AV8OneProduct.gxTpr_Quantityunitspurchases), "ZZZ9"), 533, Gx_line+26, 664, Gx_line+41, 0, 0, 0, 1) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV8OneProduct.gxTpr_Total, "ZZZZZZ9.99"), 693, Gx_line+26, 813, Gx_line+41, 0, 0, 0, 1) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+67);
               AV35GXV3 = (int)(AV35GXV3+1);
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H0Q0( true, 0) ;
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

      protected void H0Q0( bool bFoot ,
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
               if ( (0==AV11SupplierId) && (0==AV12SectorId) && (0==AV17BrandId) && (DateTime.MinValue==AV18FromDate) && (DateTime.MinValue==AV19ToDate) )
               {
                  getPrinter().GxAttris("Microsoft Sans Serif", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Total Paid", 693, Gx_line+147, 820, Gx_line+174, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText("Units Purchases", 533, Gx_line+147, 660, Gx_line+174, 0, 0, 0, 1) ;
                  getPrinter().GxDrawLine(7, Gx_line+187, 827, Gx_line+187, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("No. Purchases", 373, Gx_line+147, 520, Gx_line+174, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText("Stock", 233, Gx_line+147, 353, Gx_line+174, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText("Name", 7, Gx_line+147, 67, Gx_line+174, 0, 0, 0, 1) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 15, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Ranking Products", 13, Gx_line+13, 286, Gx_line+47, 1, 0, 0, 1) ;
                  getPrinter().GxDrawText("Purchase Orders", 13, Gx_line+47, 286, Gx_line+81, 1, 0, 0, 1) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV10Total, "ZZZZZZ9.99")), 713, Gx_line+67, 793, Gx_line+94, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText("Total Out: ", 593, Gx_line+67, 686, Gx_line+94, 2, 0, 0, 1) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+188);
               }
               else
               {
                  /* Using cursor P000Q3 */
                  pr_default.execute(1, new Object[] {AV11SupplierId});
                  while ( (pr_default.getStatus(1) != 101) )
                  {
                     A4SupplierId = P000Q3_A4SupplierId[0];
                     A5SupplierName = P000Q3_A5SupplierName[0];
                     AV13SupplierName = A5SupplierName;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(1);
                  /* Using cursor P000Q4 */
                  pr_default.execute(2, new Object[] {AV12SectorId});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A9SectorId = P000Q4_A9SectorId[0];
                     A10SectorName = P000Q4_A10SectorName[0];
                     AV14SectorName = A10SectorName;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(2);
                  /* Using cursor P000Q5 */
                  pr_default.execute(3, new Object[] {AV17BrandId});
                  while ( (pr_default.getStatus(3) != 101) )
                  {
                     A1BrandId = P000Q5_A1BrandId[0];
                     A2BrandName = P000Q5_A2BrandName[0];
                     AV21BrandName = A2BrandName;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(3);
                  getPrinter().GxAttris("Microsoft Sans Serif", 15, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Ranking Products", 7, Gx_line+33, 280, Gx_line+67, 1, 0, 0, 1) ;
                  getPrinter().GxDrawText("Purchase Orders", 7, Gx_line+67, 280, Gx_line+101, 1, 0, 0, 1) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Name", 13, Gx_line+160, 73, Gx_line+187, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText("Stock", 227, Gx_line+160, 347, Gx_line+187, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText("No. Purchases", 367, Gx_line+160, 514, Gx_line+187, 0, 0, 0, 1) ;
                  getPrinter().GxDrawLine(0, Gx_line+200, 820, Gx_line+200, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("Units Purchases", 527, Gx_line+160, 654, Gx_line+187, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText("Total Paid", 687, Gx_line+160, 814, Gx_line+187, 0, 0, 0, 1) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("From Date: ", 593, Gx_line+13, 686, Gx_line+40, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("To Date: ", 593, Gx_line+53, 686, Gx_line+80, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("Total Out: ", 593, Gx_line+93, 686, Gx_line+120, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV18FromDate, "99/99/99"), 713, Gx_line+13, 793, Gx_line+40, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV19ToDate, "99/99/99"), 713, Gx_line+53, 793, Gx_line+80, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV10Total, "ZZZZZZ9.99")), 713, Gx_line+93, 793, Gx_line+120, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21BrandName, "")), 447, Gx_line+93, 587, Gx_line+120, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14SectorName, "")), 447, Gx_line+53, 587, Gx_line+80, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13SupplierName, "")), 447, Gx_line+13, 587, Gx_line+40, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText("Brand: ", 327, Gx_line+93, 420, Gx_line+120, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("Sector: ", 327, Gx_line+53, 420, Gx_line+80, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("Supplier: ", 327, Gx_line+13, 420, Gx_line+40, 2, 0, 0, 1) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+206);
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
         AV25Context = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         AV9Products = new GXBaseCollection<SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem>( context, "SDTProductsRankingPurchasesItem", "mtaKB");
         GXt_objcol_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem1 = new GXBaseCollection<SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem>( context, "SDTProductsRankingPurchasesItem", "mtaKB");
         AV8OneProduct = new SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem(context);
         scmdbuf = "";
         A52PurchaseOrderCreatedDate = DateTime.MinValue;
         P000Q2_A78PurchaseOrderTotalPaid = new decimal[1] ;
         P000Q2_n78PurchaseOrderTotalPaid = new bool[] {false} ;
         P000Q2_AV22Count = new int[1] ;
         P000Q2_A77PurchaseOrderDetailQuantityRec = new int[1] ;
         P000Q3_A4SupplierId = new int[1] ;
         P000Q3_A5SupplierName = new string[] {""} ;
         A5SupplierName = "";
         AV13SupplierName = "";
         P000Q4_A9SectorId = new int[1] ;
         P000Q4_A10SectorName = new string[] {""} ;
         A10SectorName = "";
         AV14SectorName = "";
         P000Q5_A1BrandId = new int[1] ;
         P000Q5_A2BrandName = new string[] {""} ;
         A2BrandName = "";
         AV21BrandName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aproductsrankingpurchase__default(),
            new Object[][] {
                new Object[] {
               P000Q2_A78PurchaseOrderTotalPaid, P000Q2_n78PurchaseOrderTotalPaid, P000Q2_AV22Count, P000Q2_A77PurchaseOrderDetailQuantityRec
               }
               , new Object[] {
               P000Q3_A4SupplierId, P000Q3_A5SupplierName
               }
               , new Object[] {
               P000Q4_A9SectorId, P000Q4_A10SectorName
               }
               , new Object[] {
               P000Q5_A1BrandId, P000Q5_A2BrandName
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
      private int AV11SupplierId ;
      private int AV12SectorId ;
      private int AV17BrandId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int AV29GXV1 ;
      private int AV22Count ;
      private int AV23Units ;
      private int c77PurchaseOrderDetailQuantityRec ;
      private int AV8OneProduct_gxTpr_Id ;
      private int cV22Count ;
      private int AV31GXV2 ;
      private int AV35GXV3 ;
      private int Gx_OldLine ;
      private int A4SupplierId ;
      private int A9SectorId ;
      private int A1BrandId ;
      private decimal AV24Subtotal ;
      private decimal c78PurchaseOrderTotalPaid ;
      private decimal AV10Total ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private DateTime AV18FromDate ;
      private DateTime AV19ToDate ;
      private DateTime A52PurchaseOrderCreatedDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV26AllOk ;
      private bool n78PurchaseOrderTotalPaid ;
      private string AV16Name ;
      private string A5SupplierName ;
      private string AV13SupplierName ;
      private string A10SectorName ;
      private string AV14SectorName ;
      private string A2BrandName ;
      private string AV21BrandName ;
      private IGxDataStore dsDefault ;
      private int aP1_SupplierId ;
      private int aP2_SectorId ;
      private int aP3_BrandId ;
      private DateTime aP4_FromDate ;
      private DateTime aP5_ToDate ;
      private short aP6_Order ;
      private IDataStoreProvider pr_default ;
      private decimal[] P000Q2_A78PurchaseOrderTotalPaid ;
      private bool[] P000Q2_n78PurchaseOrderTotalPaid ;
      private int[] P000Q2_AV22Count ;
      private int[] P000Q2_A77PurchaseOrderDetailQuantityRec ;
      private int[] P000Q3_A4SupplierId ;
      private string[] P000Q3_A5SupplierName ;
      private int[] P000Q4_A9SectorId ;
      private string[] P000Q4_A10SectorName ;
      private int[] P000Q5_A1BrandId ;
      private string[] P000Q5_A2BrandName ;
      private GXBaseCollection<SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem> AV9Products ;
      private GXBaseCollection<SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem> GXt_objcol_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem1 ;
      private SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem AV8OneProduct ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession AV25Context ;
   }

   public class aproductsrankingpurchase__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P000Q2( IGxContext context ,
                                             DateTime AV18FromDate ,
                                             DateTime AV19ToDate ,
                                             DateTime A52PurchaseOrderCreatedDate ,
                                             int AV8OneProduct_gxTpr_Id )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[3];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT SUM(T2.[PurchaseOrderTotalPaid]), COUNT(*), SUM(T1.[PurchaseOrderDetailQuantityRec]) FROM ([PurchaseOrderDetail] T1 INNER JOIN [PurchaseOrder] T2 ON T2.[PurchaseOrderId] = T1.[PurchaseOrderId])";
         AddWhere(sWhereString, "(T1.[ProductId] = @AV8OneProduct__Id)");
         if ( ! (DateTime.MinValue==AV18FromDate) )
         {
            AddWhere(sWhereString, "(T2.[PurchaseOrderCreatedDate] >= @AV18FromDate)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV19ToDate) )
         {
            AddWhere(sWhereString, "(T2.[PurchaseOrderCreatedDate] <= @AV19ToDate)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         scmdbuf += sWhereString;
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
                     return conditional_P000Q2(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (int)dynConstraints[3] );
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
          Object[] prmP000Q3;
          prmP000Q3 = new Object[] {
          new ParDef("@AV11SupplierId",GXType.Int32,6,0)
          };
          Object[] prmP000Q4;
          prmP000Q4 = new Object[] {
          new ParDef("@AV12SectorId",GXType.Int32,6,0)
          };
          Object[] prmP000Q5;
          prmP000Q5 = new Object[] {
          new ParDef("@AV17BrandId",GXType.Int32,6,0)
          };
          Object[] prmP000Q2;
          prmP000Q2 = new Object[] {
          new ParDef("@AV8OneProduct__Id",GXType.Int32,6,0) ,
          new ParDef("@AV18FromDate",GXType.Date,8,0) ,
          new ParDef("@AV19ToDate",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000Q2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000Q2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P000Q3", "SELECT [SupplierId], [SupplierName] FROM [Supplier] WHERE [SupplierId] = @AV11SupplierId ORDER BY [SupplierId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000Q3,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P000Q4", "SELECT [SectorId], [SectorName] FROM [Sector] WHERE [SectorId] = @AV12SectorId ORDER BY [SectorId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000Q4,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P000Q5", "SELECT [BrandId], [BrandName] FROM [Brand] WHERE [BrandId] = @AV17BrandId ORDER BY [BrandId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000Q5,1, GxCacheFrequency.OFF ,true,true )
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
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
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
