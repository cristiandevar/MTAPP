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
   public class aproductsrankingsaleunits : GXWebProcedure
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
               AV10SupplierId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV11SectorId = (int)(Math.Round(NumberUtil.Val( GetPar( "SectorId"), "."), 18, MidpointRounding.ToEven));
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

      public aproductsrankingsaleunits( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public aproductsrankingsaleunits( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_SupplierId ,
                           ref int aP1_SectorId )
      {
         this.AV10SupplierId = aP0_SupplierId;
         this.AV11SectorId = aP1_SectorId;
         initialize();
         executePrivate();
         aP1_SectorId=this.AV11SectorId;
      }

      public int executeUdp( int aP0_SupplierId )
      {
         execute(aP0_SupplierId, ref aP1_SectorId);
         return AV11SectorId ;
      }

      public void executeSubmit( int aP0_SupplierId ,
                                 ref int aP1_SectorId )
      {
         aproductsrankingsaleunits objaproductsrankingsaleunits;
         objaproductsrankingsaleunits = new aproductsrankingsaleunits();
         objaproductsrankingsaleunits.AV10SupplierId = aP0_SupplierId;
         objaproductsrankingsaleunits.AV11SectorId = aP1_SectorId;
         objaproductsrankingsaleunits.context.SetSubmitInitialConfig(context);
         objaproductsrankingsaleunits.initialize();
         Submit( executePrivateCatch,objaproductsrankingsaleunits);
         aP1_SectorId=this.AV11SectorId;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((aproductsrankingsaleunits)stateInfo).executePrivate();
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
            GXt_objcol_SdtSDTProductsRankingSale_SDTProductsRankingSaleItem1 = AV8Products;
            new dpproductsrankingsale(context ).execute( out  GXt_objcol_SdtSDTProductsRankingSale_SDTProductsRankingSaleItem1) ;
            AV8Products = GXt_objcol_SdtSDTProductsRankingSale_SDTProductsRankingSaleItem1;
            AV8Products.Sort("[QuantityUnitsSale]");
            /* Using cursor P000V2 */
            pr_default.execute(0, new Object[] {AV10SupplierId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A4SupplierId = P000V2_A4SupplierId[0];
               A5SupplierName = P000V2_A5SupplierName[0];
               AV12SupplierName = A5SupplierName;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P000V3 */
            pr_default.execute(1, new Object[] {AV11SectorId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A9SectorId = P000V3_A9SectorId[0];
               A10SectorName = P000V3_A10SectorName[0];
               AV13SectorName = A10SectorName;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            AV14Total = 0;
            if ( (0==AV10SupplierId) && (0==AV11SectorId) )
            {
               AV19GXV1 = 1;
               while ( AV19GXV1 <= AV8Products.Count )
               {
                  AV9OneProduct = ((SdtSDTProductsRankingSale_SDTProductsRankingSaleItem)AV8Products.Item(AV19GXV1));
                  AV14Total = (decimal)(AV14Total+AV9OneProduct.gxTpr_Subtotal);
                  H0V0( false, 100) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.localUtil.Format( (decimal)(AV9OneProduct.gxTpr_Quantitysales), "ZZZ9"), 253, Gx_line+27, 373, Gx_line+42, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText(AV9OneProduct.gxTpr_Name, 13, Gx_line+27, 180, Gx_line+42, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText(context.localUtil.Format( (decimal)(AV9OneProduct.gxTpr_Quantityunitssale), "ZZZ9"), 487, Gx_line+27, 574, Gx_line+42, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV9OneProduct.gxTpr_Subtotal, "ZZZZZZ9.99"), 707, Gx_line+27, 780, Gx_line+42, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+100);
                  AV19GXV1 = (int)(AV19GXV1+1);
               }
            }
            else
            {
               if ( (0==AV10SupplierId) || (0==AV11SectorId) )
               {
                  if ( (0==AV10SupplierId) )
                  {
                     AV20GXV2 = 1;
                     while ( AV20GXV2 <= AV8Products.Count )
                     {
                        AV9OneProduct = ((SdtSDTProductsRankingSale_SDTProductsRankingSaleItem)AV8Products.Item(AV20GXV2));
                        if ( AV9OneProduct.gxTpr_Sector == AV11SectorId )
                        {
                           AV14Total = (decimal)(AV14Total+AV9OneProduct.gxTpr_Subtotal);
                           H0V0( false, 100) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(context.localUtil.Format( (decimal)(AV9OneProduct.gxTpr_Quantitysales), "ZZZ9"), 253, Gx_line+27, 373, Gx_line+42, 0, 0, 0, 1) ;
                           getPrinter().GxDrawText(AV9OneProduct.gxTpr_Name, 13, Gx_line+27, 180, Gx_line+42, 0, 0, 0, 1) ;
                           getPrinter().GxDrawText(context.localUtil.Format( (decimal)(AV9OneProduct.gxTpr_Quantityunitssale), "ZZZ9"), 487, Gx_line+27, 574, Gx_line+42, 0, 0, 0, 1) ;
                           getPrinter().GxDrawText(context.localUtil.Format( AV9OneProduct.gxTpr_Subtotal, "ZZZZZZ9.99"), 707, Gx_line+27, 780, Gx_line+42, 2, 0, 0, 0) ;
                           Gx_OldLine = Gx_line;
                           Gx_line = (int)(Gx_line+100);
                        }
                        AV20GXV2 = (int)(AV20GXV2+1);
                     }
                  }
                  else
                  {
                     AV21GXV3 = 1;
                     while ( AV21GXV3 <= AV8Products.Count )
                     {
                        AV9OneProduct = ((SdtSDTProductsRankingSale_SDTProductsRankingSaleItem)AV8Products.Item(AV21GXV3));
                        if ( AV9OneProduct.gxTpr_Supplier == AV10SupplierId )
                        {
                           AV14Total = (decimal)(AV14Total+AV9OneProduct.gxTpr_Subtotal);
                           H0V0( false, 100) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(context.localUtil.Format( (decimal)(AV9OneProduct.gxTpr_Quantitysales), "ZZZ9"), 253, Gx_line+27, 373, Gx_line+42, 0, 0, 0, 1) ;
                           getPrinter().GxDrawText(AV9OneProduct.gxTpr_Name, 13, Gx_line+27, 180, Gx_line+42, 0, 0, 0, 1) ;
                           getPrinter().GxDrawText(context.localUtil.Format( (decimal)(AV9OneProduct.gxTpr_Quantityunitssale), "ZZZ9"), 487, Gx_line+27, 574, Gx_line+42, 0, 0, 0, 1) ;
                           getPrinter().GxDrawText(context.localUtil.Format( AV9OneProduct.gxTpr_Subtotal, "ZZZZZZ9.99"), 707, Gx_line+27, 780, Gx_line+42, 2, 0, 0, 0) ;
                           Gx_OldLine = Gx_line;
                           Gx_line = (int)(Gx_line+100);
                        }
                        AV21GXV3 = (int)(AV21GXV3+1);
                     }
                  }
               }
               else
               {
                  AV22GXV4 = 1;
                  while ( AV22GXV4 <= AV8Products.Count )
                  {
                     AV9OneProduct = ((SdtSDTProductsRankingSale_SDTProductsRankingSaleItem)AV8Products.Item(AV22GXV4));
                     if ( ( AV9OneProduct.gxTpr_Sector == AV11SectorId ) && ( AV9OneProduct.gxTpr_Supplier == AV10SupplierId ) )
                     {
                        AV14Total = (decimal)(AV14Total+AV9OneProduct.gxTpr_Subtotal);
                        H0V0( false, 100) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(context.localUtil.Format( (decimal)(AV9OneProduct.gxTpr_Quantitysales), "ZZZ9"), 253, Gx_line+27, 373, Gx_line+42, 0, 0, 0, 1) ;
                        getPrinter().GxDrawText(AV9OneProduct.gxTpr_Name, 13, Gx_line+27, 180, Gx_line+42, 0, 0, 0, 1) ;
                        getPrinter().GxDrawText(context.localUtil.Format( (decimal)(AV9OneProduct.gxTpr_Quantityunitssale), "ZZZ9"), 487, Gx_line+27, 574, Gx_line+42, 0, 0, 0, 1) ;
                        getPrinter().GxDrawText(context.localUtil.Format( AV9OneProduct.gxTpr_Subtotal, "ZZZZZZ9.99"), 707, Gx_line+27, 780, Gx_line+42, 2, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+100);
                     }
                     AV22GXV4 = (int)(AV22GXV4+1);
                  }
               }
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H0V0( true, 0) ;
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

      protected void H0V0( bool bFoot ,
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
               getPrinter().GxAttris("Microsoft Sans Serif", 18, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Ranking Products ", 73, Gx_line+20, 446, Gx_line+66, 1, 0, 0, 1) ;
               getPrinter().GxDrawText("No.  of Sales", 73, Gx_line+66, 446, Gx_line+112, 1, 0, 0, 1) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Name", 13, Gx_line+147, 93, Gx_line+174, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Quantity Sales", 253, Gx_line+147, 366, Gx_line+174, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Units Sold", 487, Gx_line+147, 567, Gx_line+174, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Subtotal", 700, Gx_line+147, 780, Gx_line+174, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12SupplierName, "")), 660, Gx_line+13, 773, Gx_line+41, 0, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13SectorName, "")), 660, Gx_line+53, 780, Gx_line+81, 0, 0, 0, 1) ;
               getPrinter().GxDrawText("Supplier: ", 567, Gx_line+13, 647, Gx_line+40, 2, 0, 0, 1) ;
               getPrinter().GxDrawText("Sector:", 567, Gx_line+53, 647, Gx_line+80, 2, 0, 0, 1) ;
               getPrinter().GxDrawLine(13, Gx_line+187, 813, Gx_line+187, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Total In", 567, Gx_line+93, 647, Gx_line+120, 2, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV14Total, "ZZZZZZ9.99")), 660, Gx_line+93, 724, Gx_line+120, 0, 0, 0, 1) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+200);
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
         AV8Products = new GXBaseCollection<SdtSDTProductsRankingSale_SDTProductsRankingSaleItem>( context, "SDTProductsRankingSaleItem", "mtaKB");
         GXt_objcol_SdtSDTProductsRankingSale_SDTProductsRankingSaleItem1 = new GXBaseCollection<SdtSDTProductsRankingSale_SDTProductsRankingSaleItem>( context, "SDTProductsRankingSaleItem", "mtaKB");
         scmdbuf = "";
         P000V2_A4SupplierId = new int[1] ;
         P000V2_A5SupplierName = new string[] {""} ;
         A5SupplierName = "";
         AV12SupplierName = "";
         P000V3_A9SectorId = new int[1] ;
         P000V3_A10SectorName = new string[] {""} ;
         A10SectorName = "";
         AV13SectorName = "";
         AV9OneProduct = new SdtSDTProductsRankingSale_SDTProductsRankingSaleItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aproductsrankingsaleunits__default(),
            new Object[][] {
                new Object[] {
               P000V2_A4SupplierId, P000V2_A5SupplierName
               }
               , new Object[] {
               P000V3_A9SectorId, P000V3_A10SectorName
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
      private int AV10SupplierId ;
      private int AV11SectorId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A4SupplierId ;
      private int A9SectorId ;
      private int AV19GXV1 ;
      private int Gx_OldLine ;
      private int AV20GXV2 ;
      private int AV21GXV3 ;
      private int AV22GXV4 ;
      private decimal AV14Total ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private string A5SupplierName ;
      private string AV12SupplierName ;
      private string A10SectorName ;
      private string AV13SectorName ;
      private IGxDataStore dsDefault ;
      private int aP1_SectorId ;
      private IDataStoreProvider pr_default ;
      private int[] P000V2_A4SupplierId ;
      private string[] P000V2_A5SupplierName ;
      private int[] P000V3_A9SectorId ;
      private string[] P000V3_A10SectorName ;
      private GXBaseCollection<SdtSDTProductsRankingSale_SDTProductsRankingSaleItem> AV8Products ;
      private GXBaseCollection<SdtSDTProductsRankingSale_SDTProductsRankingSaleItem> GXt_objcol_SdtSDTProductsRankingSale_SDTProductsRankingSaleItem1 ;
      private SdtSDTProductsRankingSale_SDTProductsRankingSaleItem AV9OneProduct ;
   }

   public class aproductsrankingsaleunits__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP000V2;
          prmP000V2 = new Object[] {
          new ParDef("@AV10SupplierId",GXType.Int32,6,0)
          };
          Object[] prmP000V3;
          prmP000V3 = new Object[] {
          new ParDef("@AV11SectorId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000V2", "SELECT [SupplierId], [SupplierName] FROM [Supplier] WHERE [SupplierId] = @AV10SupplierId ORDER BY [SupplierId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000V2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P000V3", "SELECT [SectorId], [SectorName] FROM [Sector] WHERE [SectorId] = @AV11SectorId ORDER BY [SectorId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000V3,1, GxCacheFrequency.OFF ,false,true )
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
