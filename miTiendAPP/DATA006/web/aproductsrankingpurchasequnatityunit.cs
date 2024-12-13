using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
   public class aproductsrankingpurchasequnatityunit : GXWebProcedure
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
            gxfirstwebparm = GetNextPar( );
            toggleJsOutput = isJsOutputEnabled( );
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

      public aproductsrankingpurchasequnatityunit( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public aproductsrankingpurchasequnatityunit( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      public void executeSubmit( )
      {
         aproductsrankingpurchasequnatityunit objaproductsrankingpurchasequnatityunit;
         objaproductsrankingpurchasequnatityunit = new aproductsrankingpurchasequnatityunit();
         objaproductsrankingpurchasequnatityunit.context.SetSubmitInitialConfig(context);
         objaproductsrankingpurchasequnatityunit.initialize();
         Submit( executePrivateCatch,objaproductsrankingpurchasequnatityunit);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((aproductsrankingpurchasequnatityunit)stateInfo).executePrivate();
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
            new dpproductsrankingpurchases(context ).execute( out  GXt_objcol_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem1) ;
            AV9Products = GXt_objcol_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem1;
            AV9Products.Sort("[QuantityUnitsPurchases]");
            AV12GXV1 = 1;
            while ( AV12GXV1 <= AV9Products.Count )
            {
               AV8OneProduct = ((SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem)AV9Products.Item(AV12GXV1));
               H0Q0( false, 50) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(AV8OneProduct.gxTpr_Name, 13, Gx_line+13, 327, Gx_line+28, 0+256, 0, 0, 1) ;
               getPrinter().GxDrawText(context.localUtil.Format( (decimal)(AV8OneProduct.gxTpr_Stock), "ZZZZZ9"), 227, Gx_line+13, 354, Gx_line+28, 0, 0, 0, 1) ;
               getPrinter().GxDrawText(context.localUtil.Format( (decimal)(AV8OneProduct.gxTpr_Quantitypurchases), "ZZZ9"), 427, Gx_line+13, 587, Gx_line+28, 0, 0, 0, 1) ;
               getPrinter().GxDrawText(context.localUtil.Format( (decimal)(AV8OneProduct.gxTpr_Quantitypurchases), "ZZZ9"), 633, Gx_line+13, 793, Gx_line+28, 0, 0, 0, 1) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+50);
               AV12GXV1 = (int)(AV12GXV1+1);
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
               getPrinter().GxAttris("Microsoft Sans Serif", 15, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Ranking Products Purchases", 253, Gx_line+13, 560, Gx_line+54, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Name", 13, Gx_line+93, 200, Gx_line+120, 0, 0, 0, 1) ;
               getPrinter().GxDrawText("Stock", 220, Gx_line+93, 407, Gx_line+120, 0, 0, 0, 1) ;
               getPrinter().GxDrawText("Quantity Purchase", 420, Gx_line+93, 607, Gx_line+120, 0, 0, 0, 1) ;
               getPrinter().GxDrawLine(0, Gx_line+133, 820, Gx_line+133, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Units Purchases", 627, Gx_line+93, 814, Gx_line+120, 0, 0, 0, 1) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+151);
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
         AV8OneProduct = new SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem(context);
         /* GeneXus formulas. */
         Gx_line = 0;
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int AV12GXV1 ;
      private int Gx_OldLine ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private GXBaseCollection<SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem> AV9Products ;
      private GXBaseCollection<SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem> GXt_objcol_SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem1 ;
      private SdtSDTProductsRankingPurchases_SDTProductsRankingPurchasesItem AV8OneProduct ;
   }

}
