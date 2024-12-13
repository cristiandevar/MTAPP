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
   public class aproductsrankingpurchasesubtotal : GXWebProcedure
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
            gxfirstwebparm = GetFirstPar( "SupplierId");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV11SupplierId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV10SectorId = (int)(Math.Round(NumberUtil.Val( GetPar( "SectorId"), "."), 18, MidpointRounding.ToEven));
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

      public aproductsrankingpurchasesubtotal( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public aproductsrankingpurchasesubtotal( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_SupplierId ,
                           ref int aP1_SectorId )
      {
         this.AV11SupplierId = aP0_SupplierId;
         this.AV10SectorId = aP1_SectorId;
         initialize();
         executePrivate();
         aP1_SectorId=this.AV10SectorId;
      }

      public int executeUdp( int aP0_SupplierId )
      {
         execute(aP0_SupplierId, ref aP1_SectorId);
         return AV10SectorId ;
      }

      public void executeSubmit( int aP0_SupplierId ,
                                 ref int aP1_SectorId )
      {
         aproductsrankingpurchasesubtotal objaproductsrankingpurchasesubtotal;
         objaproductsrankingpurchasesubtotal = new aproductsrankingpurchasesubtotal();
         objaproductsrankingpurchasesubtotal.AV11SupplierId = aP0_SupplierId;
         objaproductsrankingpurchasesubtotal.AV10SectorId = aP1_SectorId;
         objaproductsrankingpurchasesubtotal.context.SetSubmitInitialConfig(context);
         objaproductsrankingpurchasesubtotal.initialize();
         Submit( executePrivateCatch,objaproductsrankingpurchasesubtotal);
         aP1_SectorId=this.AV10SectorId;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((aproductsrankingpurchasesubtotal)stateInfo).executePrivate();
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
            GXt_objcol_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem1 = AV9Products;
            new dpproductsrankingpurchases(context ).execute(  AV15Name,  AV11SupplierId,  AV10SectorId,  AV16BrandId, out  GXt_objcol_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem1) ;
            AV9Products = GXt_objcol_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem1;
            AV9Products.Sort("[Total]");
            /* Using cursor P000T2 */
            pr_default.execute(0, new Object[] {AV11SupplierId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A4SupplierId = P000T2_A4SupplierId[0];
               A5SupplierName = P000T2_A5SupplierName[0];
               AV13SupplierName = A5SupplierName;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P000T3 */
            pr_default.execute(1, new Object[] {AV10SectorId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A9SectorId = P000T3_A9SectorId[0];
               A10SectorName = P000T3_A10SectorName[0];
               AV12SectorName = A10SectorName;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            AV14Total = 0;
            if ( (0==AV11SupplierId) && (0==AV10SectorId) )
            {
               AV21GXV1 = 1;
               while ( AV21GXV1 <= AV9Products.Count )
               {
                  AV8OneProduct = ((SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem)AV9Products.Item(AV21GXV1));
                  AV14Total = (decimal)(AV14Total+AV8OneProduct.gxTpr_Total);
                  H0T0( false, 69) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(AV8OneProduct.gxTpr_Name, 0, Gx_line+0, 247, Gx_line+40, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText(context.localUtil.Format( (decimal)(AV8OneProduct.gxTpr_Stock), "ZZZZZ9"), 260, Gx_line+13, 387, Gx_line+28, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText(context.localUtil.Format( (decimal)(AV8OneProduct.gxTpr_Quantitypurchases), "ZZZ9"), 393, Gx_line+13, 553, Gx_line+28, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV8OneProduct.gxTpr_Total, "ZZZZZZ9.99"), 713, Gx_line+13, 820, Gx_line+28, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText(context.localUtil.Format( (decimal)(AV8OneProduct.gxTpr_Quantityunitspurchases), "ZZZ9"), 560, Gx_line+13, 700, Gx_line+28, 0, 0, 0, 1) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+69);
                  AV21GXV1 = (int)(AV21GXV1+1);
               }
            }
            else
            {
               if ( (0==AV11SupplierId) || (0==AV10SectorId) )
               {
                  if ( (0==AV11SupplierId) )
                  {
                     AV22GXV2 = 1;
                     while ( AV22GXV2 <= AV9Products.Count )
                     {
                        AV8OneProduct = ((SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem)AV9Products.Item(AV22GXV2));
                        if ( AV8OneProduct.gxTpr_Sector == AV10SectorId )
                        {
                           AV14Total = (decimal)(AV14Total+AV8OneProduct.gxTpr_Total);
                           H0T0( false, 69) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(AV8OneProduct.gxTpr_Name, 0, Gx_line+0, 247, Gx_line+40, 0, 0, 0, 1) ;
                           getPrinter().GxDrawText(context.localUtil.Format( (decimal)(AV8OneProduct.gxTpr_Stock), "ZZZZZ9"), 260, Gx_line+13, 387, Gx_line+28, 0, 0, 0, 1) ;
                           getPrinter().GxDrawText(context.localUtil.Format( (decimal)(AV8OneProduct.gxTpr_Quantitypurchases), "ZZZ9"), 393, Gx_line+13, 553, Gx_line+28, 0, 0, 0, 1) ;
                           getPrinter().GxDrawText(context.localUtil.Format( AV8OneProduct.gxTpr_Total, "ZZZZZZ9.99"), 713, Gx_line+13, 820, Gx_line+28, 0, 0, 0, 1) ;
                           getPrinter().GxDrawText(context.localUtil.Format( (decimal)(AV8OneProduct.gxTpr_Quantityunitspurchases), "ZZZ9"), 560, Gx_line+13, 700, Gx_line+28, 0, 0, 0, 1) ;
                           Gx_OldLine = Gx_line;
                           Gx_line = (int)(Gx_line+69);
                        }
                        AV22GXV2 = (int)(AV22GXV2+1);
                     }
                  }
                  else
                  {
                     AV23GXV3 = 1;
                     while ( AV23GXV3 <= AV9Products.Count )
                     {
                        AV8OneProduct = ((SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem)AV9Products.Item(AV23GXV3));
                        if ( AV8OneProduct.gxTpr_Supplier == AV11SupplierId )
                        {
                           AV14Total = (decimal)(AV14Total+AV8OneProduct.gxTpr_Total);
                           H0T0( false, 69) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(AV8OneProduct.gxTpr_Name, 0, Gx_line+0, 247, Gx_line+40, 0, 0, 0, 1) ;
                           getPrinter().GxDrawText(context.localUtil.Format( (decimal)(AV8OneProduct.gxTpr_Stock), "ZZZZZ9"), 260, Gx_line+13, 387, Gx_line+28, 0, 0, 0, 1) ;
                           getPrinter().GxDrawText(context.localUtil.Format( (decimal)(AV8OneProduct.gxTpr_Quantitypurchases), "ZZZ9"), 393, Gx_line+13, 553, Gx_line+28, 0, 0, 0, 1) ;
                           getPrinter().GxDrawText(context.localUtil.Format( AV8OneProduct.gxTpr_Total, "ZZZZZZ9.99"), 713, Gx_line+13, 820, Gx_line+28, 0, 0, 0, 1) ;
                           getPrinter().GxDrawText(context.localUtil.Format( (decimal)(AV8OneProduct.gxTpr_Quantityunitspurchases), "ZZZ9"), 560, Gx_line+13, 700, Gx_line+28, 0, 0, 0, 1) ;
                           Gx_OldLine = Gx_line;
                           Gx_line = (int)(Gx_line+69);
                        }
                        AV23GXV3 = (int)(AV23GXV3+1);
                     }
                  }
               }
               else
               {
                  AV24GXV4 = 1;
                  while ( AV24GXV4 <= AV9Products.Count )
                  {
                     AV8OneProduct = ((SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem)AV9Products.Item(AV24GXV4));
                     if ( ( AV8OneProduct.gxTpr_Sector == AV10SectorId ) && ( AV8OneProduct.gxTpr_Supplier == AV11SupplierId ) )
                     {
                        AV14Total = (decimal)(AV14Total+AV8OneProduct.gxTpr_Total);
                        H0T0( false, 69) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(AV8OneProduct.gxTpr_Name, 0, Gx_line+0, 247, Gx_line+40, 0, 0, 0, 1) ;
                        getPrinter().GxDrawText(context.localUtil.Format( (decimal)(AV8OneProduct.gxTpr_Stock), "ZZZZZ9"), 260, Gx_line+13, 387, Gx_line+28, 0, 0, 0, 1) ;
                        getPrinter().GxDrawText(context.localUtil.Format( (decimal)(AV8OneProduct.gxTpr_Quantitypurchases), "ZZZ9"), 393, Gx_line+13, 553, Gx_line+28, 0, 0, 0, 1) ;
                        getPrinter().GxDrawText(context.localUtil.Format( AV8OneProduct.gxTpr_Total, "ZZZZZZ9.99"), 713, Gx_line+13, 820, Gx_line+28, 0, 0, 0, 1) ;
                        getPrinter().GxDrawText(context.localUtil.Format( (decimal)(AV8OneProduct.gxTpr_Quantityunitspurchases), "ZZZ9"), 560, Gx_line+13, 700, Gx_line+28, 0, 0, 0, 1) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+69);
                     }
                     AV24GXV4 = (int)(AV24GXV4+1);
                  }
               }
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H0T0( true, 0) ;
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

      protected void H0T0( bool bFoot ,
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
               getPrinter().GxDrawText("Ranking Products", 93, Gx_line+33, 440, Gx_line+66, 1, 0, 0, 1) ;
               getPrinter().GxDrawText("Total Paid", 93, Gx_line+66, 440, Gx_line+99, 1, 0, 0, 1) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Name", 0, Gx_line+147, 107, Gx_line+174, 0, 0, 0, 1) ;
               getPrinter().GxDrawText("Stock", 260, Gx_line+147, 387, Gx_line+174, 0, 0, 0, 1) ;
               getPrinter().GxDrawText("Quantity Purchases", 393, Gx_line+147, 540, Gx_line+174, 0, 0, 0, 1) ;
               getPrinter().GxDrawLine(0, Gx_line+187, 820, Gx_line+187, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13SupplierName, "")), 673, Gx_line+13, 793, Gx_line+40, 0, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12SectorName, "")), 673, Gx_line+53, 793, Gx_line+80, 0, 0, 0, 1) ;
               getPrinter().GxDrawText("Supplier:", 553, Gx_line+13, 646, Gx_line+40, 2, 0, 0, 1) ;
               getPrinter().GxDrawText("Sector:", 553, Gx_line+53, 646, Gx_line+80, 2, 0, 0, 1) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Total Paid", 713, Gx_line+147, 813, Gx_line+174, 0, 0, 0, 1) ;
               getPrinter().GxDrawText("Units Purchased", 567, Gx_line+147, 700, Gx_line+174, 0, 0, 0, 1) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Total Out:", 553, Gx_line+93, 646, Gx_line+120, 2, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV14Total, "ZZZZZZ9.99")), 673, Gx_line+93, 793, Gx_line+120, 0, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12SectorName, "")), 673, Gx_line+53, 793, Gx_line+80, 0, 0, 0, 1) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+196);
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
         AV9Products = new GXBaseCollection<SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem>( context, "SDTProductsRankingPurchasesItem", "mtaKB");
         GXt_objcol_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem1 = new GXBaseCollection<SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem>( context, "SDTProductsRankingPurchasesItem", "mtaKB");
         AV15Name = "";
         scmdbuf = "";
         P000T2_A4SupplierId = new int[1] ;
         P000T2_A5SupplierName = new string[] {""} ;
         A5SupplierName = "";
         AV13SupplierName = "";
         P000T3_A9SectorId = new int[1] ;
         P000T3_A10SectorName = new string[] {""} ;
         A10SectorName = "";
         AV12SectorName = "";
         AV8OneProduct = new SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aproductsrankingpurchasesubtotal__default(),
            new Object[][] {
                new Object[] {
               P000T2_A4SupplierId, P000T2_A5SupplierName
               }
               , new Object[] {
               P000T3_A9SectorId, P000T3_A10SectorName
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
      private int AV11SupplierId ;
      private int AV10SectorId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int AV16BrandId ;
      private int A4SupplierId ;
      private int A9SectorId ;
      private int AV21GXV1 ;
      private int Gx_OldLine ;
      private int AV22GXV2 ;
      private int AV23GXV3 ;
      private int AV24GXV4 ;
      private decimal AV14Total ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private string AV15Name ;
      private string A5SupplierName ;
      private string AV13SupplierName ;
      private string A10SectorName ;
      private string AV12SectorName ;
      private IGxDataStore dsDefault ;
      private int aP1_SectorId ;
      private IDataStoreProvider pr_default ;
      private int[] P000T2_A4SupplierId ;
      private string[] P000T2_A5SupplierName ;
      private int[] P000T3_A9SectorId ;
      private string[] P000T3_A10SectorName ;
      private GXBaseCollection<SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem> AV9Products ;
      private GXBaseCollection<SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem> GXt_objcol_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem1 ;
      private SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem AV8OneProduct ;
   }

   public class aproductsrankingpurchasesubtotal__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000T2;
          prmP000T2 = new Object[] {
          new ParDef("@AV11SupplierId",GXType.Int32,6,0)
          };
          Object[] prmP000T3;
          prmP000T3 = new Object[] {
          new ParDef("@AV10SectorId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000T2", "SELECT [SupplierId], [SupplierName] FROM [Supplier] WHERE [SupplierId] = @AV11SupplierId ORDER BY [SupplierId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000T2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P000T3", "SELECT [SectorId], [SectorName] FROM [Sector] WHERE [SectorId] = @AV10SectorId ORDER BY [SectorId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000T3,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
