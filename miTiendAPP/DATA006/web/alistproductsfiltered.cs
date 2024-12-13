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
   public class alistproductsfiltered : GXWebProcedure
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
               AV11Name = gxfirstwebparm;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV16SupplierId = (int)(Math.Round(NumberUtil.Val( GetPar( "SupplierId"), "."), 18, MidpointRounding.ToEven));
                  AV14SectorId = (int)(Math.Round(NumberUtil.Val( GetPar( "SectorId"), "."), 18, MidpointRounding.ToEven));
                  AV8BrandId = (int)(Math.Round(NumberUtil.Val( GetPar( "BrandId"), "."), 18, MidpointRounding.ToEven));
                  AV25StockFrom = (short)(Math.Round(NumberUtil.Val( GetPar( "StockFrom"), "."), 18, MidpointRounding.ToEven));
                  AV26StockTo = (short)(Math.Round(NumberUtil.Val( GetPar( "StockTo"), "."), 18, MidpointRounding.ToEven));
                  AV27PriceFrom = (short)(Math.Round(NumberUtil.Val( GetPar( "PriceFrom"), "."), 18, MidpointRounding.ToEven));
                  AV28PriceTo = (short)(Math.Round(NumberUtil.Val( GetPar( "PriceTo"), "."), 18, MidpointRounding.ToEven));
                  AV20Order = (short)(Math.Round(NumberUtil.Val( GetPar( "Order"), "."), 18, MidpointRounding.ToEven));
                  AV29Descending = StringUtil.StrToBool( GetPar( "Descending"));
                  AV34Active = (short)(Math.Round(NumberUtil.Val( GetPar( "Active"), "."), 18, MidpointRounding.ToEven));
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

      public alistproductsfiltered( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public alistproductsfiltered( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Name ,
                           ref int aP1_SupplierId ,
                           ref int aP2_SectorId ,
                           ref int aP3_BrandId ,
                           ref short aP4_StockFrom ,
                           ref short aP5_StockTo ,
                           ref short aP6_PriceFrom ,
                           ref short aP7_PriceTo ,
                           ref short aP8_Order ,
                           ref bool aP9_Descending ,
                           ref short aP10_Active )
      {
         this.AV11Name = aP0_Name;
         this.AV16SupplierId = aP1_SupplierId;
         this.AV14SectorId = aP2_SectorId;
         this.AV8BrandId = aP3_BrandId;
         this.AV25StockFrom = aP4_StockFrom;
         this.AV26StockTo = aP5_StockTo;
         this.AV27PriceFrom = aP6_PriceFrom;
         this.AV28PriceTo = aP7_PriceTo;
         this.AV20Order = aP8_Order;
         this.AV29Descending = aP9_Descending;
         this.AV34Active = aP10_Active;
         initialize();
         executePrivate();
         aP1_SupplierId=this.AV16SupplierId;
         aP2_SectorId=this.AV14SectorId;
         aP3_BrandId=this.AV8BrandId;
         aP4_StockFrom=this.AV25StockFrom;
         aP5_StockTo=this.AV26StockTo;
         aP6_PriceFrom=this.AV27PriceFrom;
         aP7_PriceTo=this.AV28PriceTo;
         aP8_Order=this.AV20Order;
         aP9_Descending=this.AV29Descending;
         aP10_Active=this.AV34Active;
      }

      public short executeUdp( string aP0_Name ,
                               ref int aP1_SupplierId ,
                               ref int aP2_SectorId ,
                               ref int aP3_BrandId ,
                               ref short aP4_StockFrom ,
                               ref short aP5_StockTo ,
                               ref short aP6_PriceFrom ,
                               ref short aP7_PriceTo ,
                               ref short aP8_Order ,
                               ref bool aP9_Descending )
      {
         execute(aP0_Name, ref aP1_SupplierId, ref aP2_SectorId, ref aP3_BrandId, ref aP4_StockFrom, ref aP5_StockTo, ref aP6_PriceFrom, ref aP7_PriceTo, ref aP8_Order, ref aP9_Descending, ref aP10_Active);
         return AV34Active ;
      }

      public void executeSubmit( string aP0_Name ,
                                 ref int aP1_SupplierId ,
                                 ref int aP2_SectorId ,
                                 ref int aP3_BrandId ,
                                 ref short aP4_StockFrom ,
                                 ref short aP5_StockTo ,
                                 ref short aP6_PriceFrom ,
                                 ref short aP7_PriceTo ,
                                 ref short aP8_Order ,
                                 ref bool aP9_Descending ,
                                 ref short aP10_Active )
      {
         alistproductsfiltered objalistproductsfiltered;
         objalistproductsfiltered = new alistproductsfiltered();
         objalistproductsfiltered.AV11Name = aP0_Name;
         objalistproductsfiltered.AV16SupplierId = aP1_SupplierId;
         objalistproductsfiltered.AV14SectorId = aP2_SectorId;
         objalistproductsfiltered.AV8BrandId = aP3_BrandId;
         objalistproductsfiltered.AV25StockFrom = aP4_StockFrom;
         objalistproductsfiltered.AV26StockTo = aP5_StockTo;
         objalistproductsfiltered.AV27PriceFrom = aP6_PriceFrom;
         objalistproductsfiltered.AV28PriceTo = aP7_PriceTo;
         objalistproductsfiltered.AV20Order = aP8_Order;
         objalistproductsfiltered.AV29Descending = aP9_Descending;
         objalistproductsfiltered.AV34Active = aP10_Active;
         objalistproductsfiltered.context.SetSubmitInitialConfig(context);
         objalistproductsfiltered.initialize();
         Submit( executePrivateCatch,objalistproductsfiltered);
         aP1_SupplierId=this.AV16SupplierId;
         aP2_SectorId=this.AV14SectorId;
         aP3_BrandId=this.AV8BrandId;
         aP4_StockFrom=this.AV25StockFrom;
         aP5_StockTo=this.AV26StockTo;
         aP6_PriceFrom=this.AV27PriceFrom;
         aP7_PriceTo=this.AV28PriceTo;
         aP8_Order=this.AV20Order;
         aP9_Descending=this.AV29Descending;
         aP10_Active=this.AV34Active;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((alistproductsfiltered)stateInfo).executePrivate();
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
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 17539, 0, 1, 1, 0, 1, 1) )
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
            new getcontext(context ).execute( out  AV32Context, ref  AV33AllOk) ;
            if ( ! AV33AllOk )
            {
               CallWebObject(formatLink("wplogin.aspx") );
               context.wjLocDisableFrm = 1;
            }
            AV30OrderBy = gxdomainorderoptionsearchproducts.getDescription(context,AV20Order);
            if ( AV29Descending )
            {
               AV31OrderType = "Descending";
            }
            else
            {
               AV31OrderType = "Ascending";
            }
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV16SupplierId ,
                                                 AV14SectorId ,
                                                 AV8BrandId ,
                                                 AV11Name ,
                                                 AV24Code ,
                                                 AV25StockFrom ,
                                                 AV26StockTo ,
                                                 AV27PriceFrom ,
                                                 AV28PriceTo ,
                                                 AV34Active ,
                                                 A4SupplierId ,
                                                 A9SectorId ,
                                                 A1BrandId ,
                                                 A16ProductName ,
                                                 A55ProductCode ,
                                                 A17ProductStock ,
                                                 A85ProductCostPrice ,
                                                 A110ProductActive ,
                                                 AV20Order ,
                                                 AV29Descending } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT,
                                                 TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV11Name = StringUtil.Concat( StringUtil.RTrim( AV11Name), "%", "");
            lV24Code = StringUtil.Concat( StringUtil.RTrim( AV24Code), "%", "");
            /* Using cursor P000Y2 */
            pr_default.execute(0, new Object[] {AV16SupplierId, AV14SectorId, AV8BrandId, lV11Name, lV24Code, AV25StockFrom, AV26StockTo, AV27PriceFrom, AV28PriceTo});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A110ProductActive = P000Y2_A110ProductActive[0];
               n110ProductActive = P000Y2_n110ProductActive[0];
               A17ProductStock = P000Y2_A17ProductStock[0];
               n17ProductStock = P000Y2_n17ProductStock[0];
               A55ProductCode = P000Y2_A55ProductCode[0];
               n55ProductCode = P000Y2_n55ProductCode[0];
               A16ProductName = P000Y2_A16ProductName[0];
               A1BrandId = P000Y2_A1BrandId[0];
               n1BrandId = P000Y2_n1BrandId[0];
               A9SectorId = P000Y2_A9SectorId[0];
               n9SectorId = P000Y2_n9SectorId[0];
               A4SupplierId = P000Y2_A4SupplierId[0];
               A93ProductMiniumQuantityWholesale = P000Y2_A93ProductMiniumQuantityWholesale[0];
               n93ProductMiniumQuantityWholesale = P000Y2_n93ProductMiniumQuantityWholesale[0];
               A28ProductCreatedDate = P000Y2_A28ProductCreatedDate[0];
               A10SectorName = P000Y2_A10SectorName[0];
               A2BrandName = P000Y2_A2BrandName[0];
               A5SupplierName = P000Y2_A5SupplierName[0];
               A89ProductRetailProfit = P000Y2_A89ProductRetailProfit[0];
               n89ProductRetailProfit = P000Y2_n89ProductRetailProfit[0];
               A85ProductCostPrice = P000Y2_A85ProductCostPrice[0];
               n85ProductCostPrice = P000Y2_n85ProductCostPrice[0];
               A87ProductWholesaleProfit = P000Y2_A87ProductWholesaleProfit[0];
               n87ProductWholesaleProfit = P000Y2_n87ProductWholesaleProfit[0];
               A15ProductId = P000Y2_A15ProductId[0];
               A2BrandName = P000Y2_A2BrandName[0];
               A10SectorName = P000Y2_A10SectorName[0];
               A5SupplierName = P000Y2_A5SupplierName[0];
               GXt_decimal1 = A88ProductWholesalePrice;
               new roundvalue(context ).execute(  A85ProductCostPrice*(1+A87ProductWholesaleProfit/ (decimal)(100)), out  GXt_decimal1) ;
               GXt_decimal2 = A88ProductWholesalePrice;
               new roundvalue(context ).execute(  A85ProductCostPrice*(1+A87ProductWholesaleProfit/ (decimal)(100)), out  GXt_decimal2) ;
               GXt_decimal3 = A88ProductWholesalePrice;
               new roundvalue(context ).execute(  A85ProductCostPrice, out  GXt_decimal3) ;
               A88ProductWholesalePrice = ((A87ProductWholesaleProfit!=Convert.ToDecimal(0)) ? GXt_decimal2 : GXt_decimal3);
               GXt_decimal3 = A90ProductRetailPrice;
               new roundvalue(context ).execute(  A85ProductCostPrice*(1+A89ProductRetailProfit/ (decimal)(100)), out  GXt_decimal3) ;
               GXt_decimal2 = A90ProductRetailPrice;
               new roundvalue(context ).execute(  A85ProductCostPrice*(1+A89ProductRetailProfit/ (decimal)(100)), out  GXt_decimal2) ;
               GXt_decimal1 = A90ProductRetailPrice;
               new roundvalue(context ).execute(  A85ProductCostPrice, out  GXt_decimal1) ;
               A90ProductRetailPrice = ((A89ProductRetailProfit!=Convert.ToDecimal(0)) ? GXt_decimal2 : GXt_decimal1);
               H0Y0( false, 17) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A16ProductName, "")), 20, Gx_line+2, 213, Gx_line+17, 0, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A5SupplierName, "")), 220, Gx_line+2, 387, Gx_line+17, 0, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2BrandName, "")), 407, Gx_line+2, 527, Gx_line+17, 0, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A10SectorName, "")), 547, Gx_line+2, 674, Gx_line+17, 0, 0, 0, 1) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A17ProductStock), "ZZZZZ9")), 672, Gx_line+3, 747, Gx_line+16, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A85ProductCostPrice, "ZZZZZZZZZZZZZZ9.99")), 752, Gx_line+2, 867, Gx_line+17, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A90ProductRetailPrice, "ZZZZZZZZZZZZZZ9.99")), 864, Gx_line+2, 979, Gx_line+17, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A88ProductWholesalePrice, "ZZZZZZZZZZZZZZ9.99")), 983, Gx_line+2, 1098, Gx_line+17, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A93ProductMiniumQuantityWholesale), "ZZZ9")), 1104, Gx_line+2, 1206, Gx_line+17, 2, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+17);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H0Y0( true, 0) ;
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

      protected void H0Y0( bool bFoot ,
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
               if ( (0==AV16SupplierId) && (0==AV14SectorId) && (0==AV8BrandId) && (0==AV25StockFrom) && (0==AV26StockTo) && (0==AV27PriceFrom) && (0==AV28PriceTo) )
               {
                  getPrinter().GxDrawLine(20, Gx_line+176, 1227, Gx_line+176, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 15, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("List of Products", 227, Gx_line+26, 454, Gx_line+119, 1, 0, 0, 1) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Cost Price", 780, Gx_line+147, 867, Gx_line+174, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText("Sector", 547, Gx_line+147, 605, Gx_line+174, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("Stock", 680, Gx_line+147, 747, Gx_line+174, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText("Brand", 407, Gx_line+147, 465, Gx_line+174, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("Supplier", 220, Gx_line+147, 292, Gx_line+174, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("Name", 20, Gx_line+147, 79, Gx_line+174, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Order :", 920, Gx_line+92, 1000, Gx_line+119, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31OrderType, "")), 1133, Gx_line+92, 1200, Gx_line+119, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText("-", 1093, Gx_line+92, 1120, Gx_line+119, 1, 0, 0, 1) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV30OrderBy, "")), 1013, Gx_line+92, 1080, Gx_line+119, 0, 0, 0, 1) ;
                  getPrinter().GxDrawRect(20, Gx_line+0, 1213, Gx_line+132, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Qty W.", 1119, Gx_line+147, 1206, Gx_line+174, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText("W. Price", 1011, Gx_line+147, 1098, Gx_line+174, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText("R. Price", 892, Gx_line+147, 979, Gx_line+174, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+182);
               }
               else
               {
                  /* Using cursor P000Y3 */
                  pr_default.execute(1, new Object[] {AV16SupplierId});
                  while ( (pr_default.getStatus(1) != 101) )
                  {
                     A4SupplierId = P000Y3_A4SupplierId[0];
                     A5SupplierName = P000Y3_A5SupplierName[0];
                     AV17SupplierName = A5SupplierName;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(1);
                  /* Using cursor P000Y4 */
                  pr_default.execute(2, new Object[] {AV14SectorId});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A9SectorId = P000Y4_A9SectorId[0];
                     n9SectorId = P000Y4_n9SectorId[0];
                     A10SectorName = P000Y4_A10SectorName[0];
                     AV15SectorName = A10SectorName;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(2);
                  /* Using cursor P000Y5 */
                  pr_default.execute(3, new Object[] {AV8BrandId});
                  while ( (pr_default.getStatus(3) != 101) )
                  {
                     A1BrandId = P000Y5_A1BrandId[0];
                     n1BrandId = P000Y5_n1BrandId[0];
                     A2BrandName = P000Y5_A2BrandName[0];
                     AV9BrandName = A2BrandName;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(3);
                  getPrinter().GxAttris("Microsoft Sans Serif", 15, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("List of Products", 227, Gx_line+26, 454, Gx_line+119, 1, 0, 0, 1) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Name", 20, Gx_line+147, 100, Gx_line+174, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("Supplier", 220, Gx_line+147, 333, Gx_line+174, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("Brand", 407, Gx_line+147, 487, Gx_line+174, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("Stock", 680, Gx_line+147, 747, Gx_line+174, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV9BrandName, "")), 760, Gx_line+92, 900, Gx_line+120, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText("Brand :", 667, Gx_line+92, 747, Gx_line+119, 2, 0, 0, 1) ;
                  getPrinter().GxDrawLine(13, Gx_line+177, 1212, Gx_line+177, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("Sector :", 667, Gx_line+58, 747, Gx_line+85, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("Supplier : ", 667, Gx_line+27, 747, Gx_line+54, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15SectorName, "")), 760, Gx_line+58, 900, Gx_line+86, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17SupplierName, "")), 760, Gx_line+27, 900, Gx_line+55, 0, 0, 0, 1) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Sector", 547, Gx_line+147, 627, Gx_line+174, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("Cost Price", 780, Gx_line+147, 867, Gx_line+174, 2, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Stock: ", 920, Gx_line+27, 1000, Gx_line+54, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText("Price :", 920, Gx_line+58, 1000, Gx_line+85, 2, 0, 0, 1) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV25StockFrom), "ZZZ9")), 1013, Gx_line+27, 1080, Gx_line+54, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText("-", 1093, Gx_line+27, 1120, Gx_line+54, 1, 0, 0, 1) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV26StockTo), "ZZZ9")), 1133, Gx_line+27, 1200, Gx_line+54, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV28PriceTo), "ZZZ9")), 1133, Gx_line+58, 1200, Gx_line+85, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText("-", 1093, Gx_line+58, 1120, Gx_line+85, 1, 0, 0, 1) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV27PriceFrom), "ZZZ9")), 1013, Gx_line+58, 1080, Gx_line+85, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV30OrderBy, "")), 1013, Gx_line+92, 1080, Gx_line+119, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText("-", 1093, Gx_line+92, 1120, Gx_line+119, 1, 0, 0, 1) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31OrderType, "")), 1133, Gx_line+92, 1200, Gx_line+119, 0, 0, 0, 1) ;
                  getPrinter().GxDrawText("Order :", 920, Gx_line+92, 1000, Gx_line+119, 2, 0, 0, 1) ;
                  getPrinter().GxDrawRect(20, Gx_line+2, 1213, Gx_line+134, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("R. Price", 892, Gx_line+147, 979, Gx_line+174, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText("W. Price", 1011, Gx_line+147, 1098, Gx_line+174, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText("Qty W.", 1119, Gx_line+147, 1206, Gx_line+174, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+182);
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
         AV32Context = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         AV30OrderBy = "";
         AV31OrderType = "";
         scmdbuf = "";
         lV11Name = "";
         lV24Code = "";
         AV24Code = "";
         A16ProductName = "";
         A55ProductCode = "";
         P000Y2_A110ProductActive = new bool[] {false} ;
         P000Y2_n110ProductActive = new bool[] {false} ;
         P000Y2_A17ProductStock = new int[1] ;
         P000Y2_n17ProductStock = new bool[] {false} ;
         P000Y2_A55ProductCode = new string[] {""} ;
         P000Y2_n55ProductCode = new bool[] {false} ;
         P000Y2_A16ProductName = new string[] {""} ;
         P000Y2_A1BrandId = new int[1] ;
         P000Y2_n1BrandId = new bool[] {false} ;
         P000Y2_A9SectorId = new int[1] ;
         P000Y2_n9SectorId = new bool[] {false} ;
         P000Y2_A4SupplierId = new int[1] ;
         P000Y2_A93ProductMiniumQuantityWholesale = new short[1] ;
         P000Y2_n93ProductMiniumQuantityWholesale = new bool[] {false} ;
         P000Y2_A28ProductCreatedDate = new DateTime[] {DateTime.MinValue} ;
         P000Y2_A10SectorName = new string[] {""} ;
         P000Y2_A2BrandName = new string[] {""} ;
         P000Y2_A5SupplierName = new string[] {""} ;
         P000Y2_A89ProductRetailProfit = new decimal[1] ;
         P000Y2_n89ProductRetailProfit = new bool[] {false} ;
         P000Y2_A85ProductCostPrice = new decimal[1] ;
         P000Y2_n85ProductCostPrice = new bool[] {false} ;
         P000Y2_A87ProductWholesaleProfit = new decimal[1] ;
         P000Y2_n87ProductWholesaleProfit = new bool[] {false} ;
         P000Y2_A15ProductId = new int[1] ;
         A28ProductCreatedDate = DateTime.MinValue;
         A10SectorName = "";
         A2BrandName = "";
         A5SupplierName = "";
         P000Y3_A4SupplierId = new int[1] ;
         P000Y3_A5SupplierName = new string[] {""} ;
         AV17SupplierName = "";
         P000Y4_A9SectorId = new int[1] ;
         P000Y4_n9SectorId = new bool[] {false} ;
         P000Y4_A10SectorName = new string[] {""} ;
         AV15SectorName = "";
         P000Y5_A1BrandId = new int[1] ;
         P000Y5_n1BrandId = new bool[] {false} ;
         P000Y5_A2BrandName = new string[] {""} ;
         AV9BrandName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.alistproductsfiltered__default(),
            new Object[][] {
                new Object[] {
               P000Y2_A110ProductActive, P000Y2_n110ProductActive, P000Y2_A17ProductStock, P000Y2_n17ProductStock, P000Y2_A55ProductCode, P000Y2_n55ProductCode, P000Y2_A16ProductName, P000Y2_A1BrandId, P000Y2_n1BrandId, P000Y2_A9SectorId,
               P000Y2_n9SectorId, P000Y2_A4SupplierId, P000Y2_A93ProductMiniumQuantityWholesale, P000Y2_n93ProductMiniumQuantityWholesale, P000Y2_A28ProductCreatedDate, P000Y2_A10SectorName, P000Y2_A2BrandName, P000Y2_A5SupplierName, P000Y2_A89ProductRetailProfit, P000Y2_n89ProductRetailProfit,
               P000Y2_A85ProductCostPrice, P000Y2_n85ProductCostPrice, P000Y2_A87ProductWholesaleProfit, P000Y2_n87ProductWholesaleProfit, P000Y2_A15ProductId
               }
               , new Object[] {
               P000Y3_A4SupplierId, P000Y3_A5SupplierName
               }
               , new Object[] {
               P000Y4_A9SectorId, P000Y4_A10SectorName
               }
               , new Object[] {
               P000Y5_A1BrandId, P000Y5_A2BrandName
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short AV25StockFrom ;
      private short AV26StockTo ;
      private short AV27PriceFrom ;
      private short AV28PriceTo ;
      private short AV20Order ;
      private short AV34Active ;
      private short GxWebError ;
      private short A93ProductMiniumQuantityWholesale ;
      private int AV16SupplierId ;
      private int AV14SectorId ;
      private int AV8BrandId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A4SupplierId ;
      private int A9SectorId ;
      private int A1BrandId ;
      private int A17ProductStock ;
      private int A15ProductId ;
      private int Gx_OldLine ;
      private decimal A85ProductCostPrice ;
      private decimal A89ProductRetailProfit ;
      private decimal A87ProductWholesaleProfit ;
      private decimal A88ProductWholesalePrice ;
      private decimal A90ProductRetailPrice ;
      private decimal GXt_decimal3 ;
      private decimal GXt_decimal2 ;
      private decimal GXt_decimal1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV30OrderBy ;
      private string AV31OrderType ;
      private string scmdbuf ;
      private DateTime A28ProductCreatedDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV29Descending ;
      private bool AV33AllOk ;
      private bool A110ProductActive ;
      private bool n110ProductActive ;
      private bool n17ProductStock ;
      private bool n55ProductCode ;
      private bool n1BrandId ;
      private bool n9SectorId ;
      private bool n93ProductMiniumQuantityWholesale ;
      private bool n89ProductRetailProfit ;
      private bool n85ProductCostPrice ;
      private bool n87ProductWholesaleProfit ;
      private string AV11Name ;
      private string lV11Name ;
      private string lV24Code ;
      private string AV24Code ;
      private string A16ProductName ;
      private string A55ProductCode ;
      private string A10SectorName ;
      private string A2BrandName ;
      private string A5SupplierName ;
      private string AV17SupplierName ;
      private string AV15SectorName ;
      private string AV9BrandName ;
      private IGxDataStore dsDefault ;
      private int aP1_SupplierId ;
      private int aP2_SectorId ;
      private int aP3_BrandId ;
      private short aP4_StockFrom ;
      private short aP5_StockTo ;
      private short aP6_PriceFrom ;
      private short aP7_PriceTo ;
      private short aP8_Order ;
      private bool aP9_Descending ;
      private short aP10_Active ;
      private IDataStoreProvider pr_default ;
      private bool[] P000Y2_A110ProductActive ;
      private bool[] P000Y2_n110ProductActive ;
      private int[] P000Y2_A17ProductStock ;
      private bool[] P000Y2_n17ProductStock ;
      private string[] P000Y2_A55ProductCode ;
      private bool[] P000Y2_n55ProductCode ;
      private string[] P000Y2_A16ProductName ;
      private int[] P000Y2_A1BrandId ;
      private bool[] P000Y2_n1BrandId ;
      private int[] P000Y2_A9SectorId ;
      private bool[] P000Y2_n9SectorId ;
      private int[] P000Y2_A4SupplierId ;
      private short[] P000Y2_A93ProductMiniumQuantityWholesale ;
      private bool[] P000Y2_n93ProductMiniumQuantityWholesale ;
      private DateTime[] P000Y2_A28ProductCreatedDate ;
      private string[] P000Y2_A10SectorName ;
      private string[] P000Y2_A2BrandName ;
      private string[] P000Y2_A5SupplierName ;
      private decimal[] P000Y2_A89ProductRetailProfit ;
      private bool[] P000Y2_n89ProductRetailProfit ;
      private decimal[] P000Y2_A85ProductCostPrice ;
      private bool[] P000Y2_n85ProductCostPrice ;
      private decimal[] P000Y2_A87ProductWholesaleProfit ;
      private bool[] P000Y2_n87ProductWholesaleProfit ;
      private int[] P000Y2_A15ProductId ;
      private int[] P000Y3_A4SupplierId ;
      private string[] P000Y3_A5SupplierName ;
      private int[] P000Y4_A9SectorId ;
      private bool[] P000Y4_n9SectorId ;
      private string[] P000Y4_A10SectorName ;
      private int[] P000Y5_A1BrandId ;
      private bool[] P000Y5_n1BrandId ;
      private string[] P000Y5_A2BrandName ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession AV32Context ;
   }

   public class alistproductsfiltered__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P000Y2( IGxContext context ,
                                             int AV16SupplierId ,
                                             int AV14SectorId ,
                                             int AV8BrandId ,
                                             string AV11Name ,
                                             string AV24Code ,
                                             short AV25StockFrom ,
                                             short AV26StockTo ,
                                             short AV27PriceFrom ,
                                             short AV28PriceTo ,
                                             short AV34Active ,
                                             int A4SupplierId ,
                                             int A9SectorId ,
                                             int A1BrandId ,
                                             string A16ProductName ,
                                             string A55ProductCode ,
                                             int A17ProductStock ,
                                             decimal A85ProductCostPrice ,
                                             bool A110ProductActive ,
                                             short AV20Order ,
                                             bool AV29Descending )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[9];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[ProductActive], T1.[ProductStock], T1.[ProductCode], T1.[ProductName], T1.[BrandId], T1.[SectorId], T1.[SupplierId], T1.[ProductMiniumQuantityWholesale], T1.[ProductCreatedDate], T3.[SectorName], T2.[BrandName], T4.[SupplierName], T1.[ProductRetailProfit], T1.[ProductCostPrice], T1.[ProductWholesaleProfit], T1.[ProductId] FROM ((([Product] T1 LEFT JOIN [Brand] T2 ON T2.[BrandId] = T1.[BrandId]) LEFT JOIN [Sector] T3 ON T3.[SectorId] = T1.[SectorId]) INNER JOIN [Supplier] T4 ON T4.[SupplierId] = T1.[SupplierId])";
         if ( ! (0==AV16SupplierId) )
         {
            AddWhere(sWhereString, "(T1.[SupplierId] = @AV16SupplierId)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ! (0==AV14SectorId) )
         {
            AddWhere(sWhereString, "(T1.[SectorId] = @AV14SectorId)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ! (0==AV8BrandId) )
         {
            AddWhere(sWhereString, "(T1.[BrandId] = @AV8BrandId)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11Name)) )
         {
            AddWhere(sWhereString, "(T1.[ProductName] like @lV11Name)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24Code)) )
         {
            AddWhere(sWhereString, "(T1.[ProductCode] like @lV24Code)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! (0==AV25StockFrom) )
         {
            AddWhere(sWhereString, "(T1.[ProductStock] >= @AV25StockFrom)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! (0==AV26StockTo) )
         {
            AddWhere(sWhereString, "(T1.[ProductStock] <= @AV26StockTo)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! (0==AV27PriceFrom) )
         {
            AddWhere(sWhereString, "(T1.[ProductCostPrice] >= @AV27PriceFrom)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! (0==AV28PriceTo) )
         {
            AddWhere(sWhereString, "(T1.[ProductCostPrice] <= @AV28PriceTo)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! (0==AV34Active) && ( AV34Active == 1 ) )
         {
            AddWhere(sWhereString, "(T1.[ProductActive] = 1)");
         }
         if ( ! (0==AV34Active) && ( AV34Active == 2 ) )
         {
            AddWhere(sWhereString, "(Not T1.[ProductActive] = 1)");
         }
         scmdbuf += sWhereString;
         if ( ! (0==AV20Order) && ( AV20Order == 1 ) && ! AV29Descending )
         {
            scmdbuf += " ORDER BY T1.[ProductName]";
         }
         else if ( ! (0==AV20Order) && ( AV20Order == 1 ) && AV29Descending )
         {
            scmdbuf += " ORDER BY T1.[ProductName] DESC";
         }
         else if ( ! (0==AV20Order) && ( AV20Order == 2 ) && ! AV29Descending )
         {
            scmdbuf += " ORDER BY T4.[SupplierName]";
         }
         else if ( ! (0==AV20Order) && ( AV20Order == 2 ) && AV29Descending )
         {
            scmdbuf += " ORDER BY T4.[SupplierName] DESC";
         }
         else if ( ! (0==AV20Order) && ( AV20Order == 3 ) && ! AV29Descending )
         {
            scmdbuf += " ORDER BY T2.[BrandName]";
         }
         else if ( ! (0==AV20Order) && ( AV20Order == 3 ) && AV29Descending )
         {
            scmdbuf += " ORDER BY T2.[BrandName] DESC";
         }
         else if ( ! (0==AV20Order) && ( AV20Order == 4 ) && ! AV29Descending )
         {
            scmdbuf += " ORDER BY T3.[SectorName]";
         }
         else if ( ! (0==AV20Order) && ( AV20Order == 4 ) && AV29Descending )
         {
            scmdbuf += " ORDER BY T3.[SectorName] DESC";
         }
         else if ( ! (0==AV20Order) && ( AV20Order == 5 ) && ! AV29Descending )
         {
            scmdbuf += " ORDER BY T1.[ProductStock]";
         }
         else if ( ! (0==AV20Order) && ( AV20Order == 5 ) && AV29Descending )
         {
            scmdbuf += " ORDER BY T1.[ProductStock] DESC";
         }
         else if ( ! (0==AV20Order) && ( AV20Order == 6 ) && ! AV29Descending )
         {
            scmdbuf += " ORDER BY T1.[ProductCostPrice]";
         }
         else if ( ! (0==AV20Order) && ( AV20Order == 6 ) && AV29Descending )
         {
            scmdbuf += " ORDER BY T1.[ProductCostPrice] DESC";
         }
         else if ( ! (0==AV20Order) && ( AV20Order == 9 ) && ! AV29Descending )
         {
            scmdbuf += " ORDER BY T1.[ProductCreatedDate]";
         }
         else if ( ! (0==AV20Order) && ( AV20Order == 9 ) && AV29Descending )
         {
            scmdbuf += " ORDER BY T1.[ProductCreatedDate] DESC";
         }
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P000Y2(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (int)dynConstraints[15] , (decimal)dynConstraints[16] , (bool)dynConstraints[17] , (short)dynConstraints[18] , (bool)dynConstraints[19] );
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
          Object[] prmP000Y3;
          prmP000Y3 = new Object[] {
          new ParDef("@AV16SupplierId",GXType.Int32,6,0)
          };
          Object[] prmP000Y4;
          prmP000Y4 = new Object[] {
          new ParDef("@AV14SectorId",GXType.Int32,6,0)
          };
          Object[] prmP000Y5;
          prmP000Y5 = new Object[] {
          new ParDef("@AV8BrandId",GXType.Int32,6,0)
          };
          Object[] prmP000Y2;
          prmP000Y2 = new Object[] {
          new ParDef("@AV16SupplierId",GXType.Int32,6,0) ,
          new ParDef("@AV14SectorId",GXType.Int32,6,0) ,
          new ParDef("@AV8BrandId",GXType.Int32,6,0) ,
          new ParDef("@lV11Name",GXType.NVarChar,60,0) ,
          new ParDef("@lV24Code",GXType.NVarChar,100,0) ,
          new ParDef("@AV25StockFrom",GXType.Int16,4,0) ,
          new ParDef("@AV26StockTo",GXType.Int16,4,0) ,
          new ParDef("@AV27PriceFrom",GXType.Int16,4,0) ,
          new ParDef("@AV28PriceTo",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000Y2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000Y2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P000Y3", "SELECT [SupplierId], [SupplierName] FROM [Supplier] WHERE [SupplierId] = @AV16SupplierId ORDER BY [SupplierId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000Y3,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P000Y4", "SELECT [SectorId], [SectorName] FROM [Sector] WHERE [SectorId] = @AV14SectorId ORDER BY [SectorId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000Y4,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P000Y5", "SELECT [BrandId], [BrandName] FROM [Brand] WHERE [BrandId] = @AV8BrandId ORDER BY [BrandId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000Y5,1, GxCacheFrequency.OFF ,true,true )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((short[]) buf[12])[0] = rslt.getShort(8);
                ((bool[]) buf[13])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(9);
                ((string[]) buf[15])[0] = rslt.getVarchar(10);
                ((string[]) buf[16])[0] = rslt.getVarchar(11);
                ((string[]) buf[17])[0] = rslt.getVarchar(12);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(13);
                ((bool[]) buf[19])[0] = rslt.wasNull(13);
                ((decimal[]) buf[20])[0] = rslt.getDecimal(14);
                ((bool[]) buf[21])[0] = rslt.wasNull(14);
                ((decimal[]) buf[22])[0] = rslt.getDecimal(15);
                ((bool[]) buf[23])[0] = rslt.wasNull(15);
                ((int[]) buf[24])[0] = rslt.getInt(16);
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
