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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class product_bc : GxSilentTrn, IGxSilentTrn
   {
      public product_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public product_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow055( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey055( ) ;
         standaloneModal( ) ;
         AddRow055( ) ;
         Gx_mode = "INS";
         return  ;
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E11052 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z15ProductId = A15ProductId;
               SetMode( "UPD") ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_050( )
      {
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls055( ) ;
            }
            else
            {
               CheckExtendedTable055( ) ;
               if ( AnyError == 0 )
               {
                  ZM055( 24) ;
                  ZM055( 25) ;
                  ZM055( 26) ;
               }
               CloseExtendedTableCursors055( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E12052( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtSDTContextSession1 = new GeneXus.Programs.general.ui.SdtSDTContextSession();
         new checkauthentication(context ).execute( out  GXt_SdtSDTContextSession1) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && ! new haspermission(context).executeUdp(  "product view") )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV26Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         else if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! new haspermission(context).executeUdp(  "product insert") )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV26Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         else if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ! new haspermission(context).executeUdp(  "product update") )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV26Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         else if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! new haspermission(context).executeUdp(  "product delete") )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV26Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV16ProductState = "Active";
         }
      }

      protected void E11052( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
         {
            if ( AV21ProductExist )
            {
               new productupdatesamecode(context ).execute(  A15ProductId, out  AV23AllOk, ref  AV22ErrorMessages) ;
            }
            new productcostpriceroundvalue(context ).execute( ref  A85ProductCostPrice) ;
            n85ProductCostPrice = ((Convert.ToDecimal(0)==A85ProductCostPrice) ? true : false);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ErrorMessages", AV22ErrorMessages);
      }

      protected void E13052( )
      {
         /* ProductCode_Controlvaluechanged Routine */
         returnInSub = false;
         AV21ProductExist = false;
         /*  Sending Event outputs  */
      }

      protected void E14052( )
      {
         /* ProductCostPrice_Controlvaluechanged Routine */
         returnInSub = false;
      }

      protected void ZM055( short GX_JID )
      {
         if ( ( GX_JID == 22 ) || ( GX_JID == 0 ) )
         {
            Z110ProductActive = A110ProductActive;
            Z55ProductCode = A55ProductCode;
            Z16ProductName = A16ProductName;
            Z85ProductCostPrice = A85ProductCostPrice;
            Z89ProductRetailProfit = A89ProductRetailProfit;
            Z87ProductWholesaleProfit = A87ProductWholesaleProfit;
            Z17ProductStock = A17ProductStock;
            Z69ProductMiniumStock = A69ProductMiniumStock;
            Z19ProductDescription = A19ProductDescription;
            Z28ProductCreatedDate = A28ProductCreatedDate;
            Z29ProductModifiedDate = A29ProductModifiedDate;
            Z93ProductMiniumQuantityWholesale = A93ProductMiniumQuantityWholesale;
            Z1BrandId = A1BrandId;
            Z9SectorId = A9SectorId;
            Z4SupplierId = A4SupplierId;
            Z90ProductRetailPrice = A90ProductRetailPrice;
            Z88ProductWholesalePrice = A88ProductWholesalePrice;
         }
         if ( ( GX_JID == 24 ) || ( GX_JID == 0 ) )
         {
            Z2BrandName = A2BrandName;
            Z90ProductRetailPrice = A90ProductRetailPrice;
            Z88ProductWholesalePrice = A88ProductWholesalePrice;
         }
         if ( ( GX_JID == 25 ) || ( GX_JID == 0 ) )
         {
            Z10SectorName = A10SectorName;
            Z90ProductRetailPrice = A90ProductRetailPrice;
            Z88ProductWholesalePrice = A88ProductWholesalePrice;
         }
         if ( ( GX_JID == 26 ) || ( GX_JID == 0 ) )
         {
            Z5SupplierName = A5SupplierName;
            Z90ProductRetailPrice = A90ProductRetailPrice;
            Z88ProductWholesalePrice = A88ProductWholesalePrice;
         }
         if ( GX_JID == -22 )
         {
            Z15ProductId = A15ProductId;
            Z110ProductActive = A110ProductActive;
            Z55ProductCode = A55ProductCode;
            Z16ProductName = A16ProductName;
            Z85ProductCostPrice = A85ProductCostPrice;
            Z89ProductRetailProfit = A89ProductRetailProfit;
            Z87ProductWholesaleProfit = A87ProductWholesaleProfit;
            Z17ProductStock = A17ProductStock;
            Z69ProductMiniumStock = A69ProductMiniumStock;
            Z19ProductDescription = A19ProductDescription;
            Z28ProductCreatedDate = A28ProductCreatedDate;
            Z29ProductModifiedDate = A29ProductModifiedDate;
            Z93ProductMiniumQuantityWholesale = A93ProductMiniumQuantityWholesale;
            Z1BrandId = A1BrandId;
            Z9SectorId = A9SectorId;
            Z4SupplierId = A4SupplierId;
            Z2BrandName = A2BrandName;
            Z5SupplierName = A5SupplierName;
            Z10SectorName = A10SectorName;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         Gx_date = DateTimeUtil.Today( context);
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            A110ProductActive = true;
            n110ProductActive = false;
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            A28ProductCreatedDate = Gx_date;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
         {
            A29ProductModifiedDate = Gx_date;
         }
         if ( IsIns( )  && (0==A17ProductStock) && ( Gx_BScreen == 0 ) )
         {
            A17ProductStock = 0;
            n17ProductStock = false;
         }
         if ( IsIns( )  && (0==A69ProductMiniumStock) && ( Gx_BScreen == 0 ) )
         {
            A69ProductMiniumStock = 0;
            n69ProductMiniumStock = false;
         }
         if ( IsIns( )  && (0==A93ProductMiniumQuantityWholesale) && ( Gx_BScreen == 0 ) )
         {
            A93ProductMiniumQuantityWholesale = 0;
            n93ProductMiniumQuantityWholesale = false;
         }
         if ( IsIns( )  && (Convert.ToDecimal(0)==A89ProductRetailProfit) && ( Gx_BScreen == 0 ) )
         {
            A89ProductRetailProfit = 0;
            n89ProductRetailProfit = false;
         }
         if ( IsIns( )  && (Convert.ToDecimal(0)==A87ProductWholesaleProfit) && ( Gx_BScreen == 0 ) )
         {
            A87ProductWholesaleProfit = 0;
            n87ProductWholesaleProfit = false;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV26Pgmname = "Product_BC";
            if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && A110ProductActive )
            {
               AV16ProductState = "Enabled";
            }
            else
            {
               if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ! A110ProductActive )
               {
                  AV16ProductState = "Disabled";
               }
            }
         }
      }

      protected void Load055( )
      {
         /* Using cursor BC00057 */
         pr_default.execute(5, new Object[] {A15ProductId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound5 = 1;
            A110ProductActive = BC00057_A110ProductActive[0];
            n110ProductActive = BC00057_n110ProductActive[0];
            A55ProductCode = BC00057_A55ProductCode[0];
            n55ProductCode = BC00057_n55ProductCode[0];
            A16ProductName = BC00057_A16ProductName[0];
            A85ProductCostPrice = BC00057_A85ProductCostPrice[0];
            n85ProductCostPrice = BC00057_n85ProductCostPrice[0];
            A89ProductRetailProfit = BC00057_A89ProductRetailProfit[0];
            n89ProductRetailProfit = BC00057_n89ProductRetailProfit[0];
            A87ProductWholesaleProfit = BC00057_A87ProductWholesaleProfit[0];
            n87ProductWholesaleProfit = BC00057_n87ProductWholesaleProfit[0];
            A2BrandName = BC00057_A2BrandName[0];
            A5SupplierName = BC00057_A5SupplierName[0];
            A10SectorName = BC00057_A10SectorName[0];
            A17ProductStock = BC00057_A17ProductStock[0];
            n17ProductStock = BC00057_n17ProductStock[0];
            A69ProductMiniumStock = BC00057_A69ProductMiniumStock[0];
            n69ProductMiniumStock = BC00057_n69ProductMiniumStock[0];
            A19ProductDescription = BC00057_A19ProductDescription[0];
            n19ProductDescription = BC00057_n19ProductDescription[0];
            A28ProductCreatedDate = BC00057_A28ProductCreatedDate[0];
            A29ProductModifiedDate = BC00057_A29ProductModifiedDate[0];
            A93ProductMiniumQuantityWholesale = BC00057_A93ProductMiniumQuantityWholesale[0];
            n93ProductMiniumQuantityWholesale = BC00057_n93ProductMiniumQuantityWholesale[0];
            A1BrandId = BC00057_A1BrandId[0];
            n1BrandId = BC00057_n1BrandId[0];
            A9SectorId = BC00057_A9SectorId[0];
            n9SectorId = BC00057_n9SectorId[0];
            A4SupplierId = BC00057_A4SupplierId[0];
            ZM055( -22) ;
         }
         pr_default.close(5);
         OnLoadActions055( ) ;
      }

      protected void OnLoadActions055( )
      {
         AV26Pgmname = "Product_BC";
         GXt_decimal2 = A90ProductRetailPrice;
         new roundvalue(context ).execute(  A85ProductCostPrice*(1+A89ProductRetailProfit/ (decimal)(100)), out  GXt_decimal2) ;
         GXt_decimal3 = A90ProductRetailPrice;
         new roundvalue(context ).execute(  A85ProductCostPrice*(1+A89ProductRetailProfit/ (decimal)(100)), out  GXt_decimal3) ;
         GXt_decimal4 = A90ProductRetailPrice;
         new roundvalue(context ).execute(  A85ProductCostPrice, out  GXt_decimal4) ;
         A90ProductRetailPrice = ((A89ProductRetailProfit!=Convert.ToDecimal(0)) ? GXt_decimal3 : GXt_decimal4);
         GXt_decimal4 = A88ProductWholesalePrice;
         new roundvalue(context ).execute(  A85ProductCostPrice*(1+A87ProductWholesaleProfit/ (decimal)(100)), out  GXt_decimal4) ;
         GXt_decimal3 = A88ProductWholesalePrice;
         new roundvalue(context ).execute(  A85ProductCostPrice*(1+A87ProductWholesaleProfit/ (decimal)(100)), out  GXt_decimal3) ;
         GXt_decimal2 = A88ProductWholesalePrice;
         new roundvalue(context ).execute(  A85ProductCostPrice, out  GXt_decimal2) ;
         A88ProductWholesalePrice = ((A87ProductWholesaleProfit!=Convert.ToDecimal(0)) ? GXt_decimal3 : GXt_decimal2);
         if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && A110ProductActive )
         {
            AV16ProductState = "Enabled";
         }
         else
         {
            if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ! A110ProductActive )
            {
               AV16ProductState = "Disabled";
            }
         }
      }

      protected void CheckExtendedTable055( )
      {
         nIsDirty_5 = 0;
         standaloneModal( ) ;
         AV26Pgmname = "Product_BC";
         /* Using cursor BC00058 */
         pr_default.execute(6, new Object[] {A16ProductName, A4SupplierId, A15ProductId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Product Name"+","+"Supplier Id"}), 1, "");
            AnyError = 1;
         }
         pr_default.close(6);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A16ProductName)) )
         {
            GX_msglist.addItem("Name is required", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( ( A85ProductCostPrice >= Convert.ToDecimal( 0 )) && ( A85ProductCostPrice <= 999999999999999.99m ) ) || (Convert.ToDecimal(0)==A85ProductCostPrice) ) )
         {
            GX_msglist.addItem("Invalid Price", "OutOfRange", 1, "");
            AnyError = 1;
         }
         nIsDirty_5 = 1;
         GXt_decimal4 = A90ProductRetailPrice;
         new roundvalue(context ).execute(  A85ProductCostPrice*(1+A89ProductRetailProfit/ (decimal)(100)), out  GXt_decimal4) ;
         GXt_decimal3 = A90ProductRetailPrice;
         new roundvalue(context ).execute(  A85ProductCostPrice*(1+A89ProductRetailProfit/ (decimal)(100)), out  GXt_decimal3) ;
         GXt_decimal2 = A90ProductRetailPrice;
         new roundvalue(context ).execute(  A85ProductCostPrice, out  GXt_decimal2) ;
         A90ProductRetailPrice = ((A89ProductRetailProfit!=Convert.ToDecimal(0)) ? GXt_decimal3 : GXt_decimal2);
         nIsDirty_5 = 1;
         GXt_decimal4 = A88ProductWholesalePrice;
         new roundvalue(context ).execute(  A85ProductCostPrice*(1+A87ProductWholesaleProfit/ (decimal)(100)), out  GXt_decimal4) ;
         GXt_decimal3 = A88ProductWholesalePrice;
         new roundvalue(context ).execute(  A85ProductCostPrice*(1+A87ProductWholesaleProfit/ (decimal)(100)), out  GXt_decimal3) ;
         GXt_decimal2 = A88ProductWholesalePrice;
         new roundvalue(context ).execute(  A85ProductCostPrice, out  GXt_decimal2) ;
         A88ProductWholesalePrice = ((A87ProductWholesaleProfit!=Convert.ToDecimal(0)) ? GXt_decimal3 : GXt_decimal2);
         if ( (Convert.ToDecimal(0)==A85ProductCostPrice) )
         {
            GX_msglist.addItem("Price is Required", 1, "");
            AnyError = 1;
         }
         if ( (Convert.ToDecimal(0)==A85ProductCostPrice) )
         {
            new productcostpriceroundvalue(context ).execute( ref  A85ProductCostPrice) ;
            n85ProductCostPrice = ((Convert.ToDecimal(0)==A85ProductCostPrice) ? true : false);
         }
         if ( ! ( ( ( A89ProductRetailProfit >= Convert.ToDecimal( -999 )) && ( A89ProductRetailProfit <= Convert.ToDecimal( 999 )) ) || (Convert.ToDecimal(0)==A89ProductRetailProfit) ) )
         {
            GX_msglist.addItem("Field Product Retail Profit is out of range", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ( A89ProductRetailProfit != A87ProductWholesaleProfit ) && (0==A93ProductMiniumQuantityWholesale) )
         {
            GX_msglist.addItem("Retail Profit and Wholesale Profit must be equals when Min. Qty. Wholesale is not defined", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( ( A87ProductWholesaleProfit >= Convert.ToDecimal( -999 )) && ( A87ProductWholesaleProfit <= Convert.ToDecimal( 999 )) ) || (Convert.ToDecimal(0)==A87ProductWholesaleProfit) ) )
         {
            GX_msglist.addItem("Field Product Wholesale Profit is out of range", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00054 */
         pr_default.execute(2, new Object[] {n1BrandId, A1BrandId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A1BrandId) ) )
            {
               GX_msglist.addItem("No matching 'Brand'.", "ForeignKeyNotFound", 1, "BRANDID");
               AnyError = 1;
            }
         }
         A2BrandName = BC00054_A2BrandName[0];
         pr_default.close(2);
         /* Using cursor BC00056 */
         pr_default.execute(4, new Object[] {A4SupplierId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No matching 'Supplier'.", "ForeignKeyNotFound", 1, "SUPPLIERID");
            AnyError = 1;
         }
         A5SupplierName = BC00056_A5SupplierName[0];
         pr_default.close(4);
         /* Using cursor BC00055 */
         pr_default.execute(3, new Object[] {n9SectorId, A9SectorId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A9SectorId) ) )
            {
               GX_msglist.addItem("No matching 'Sector'.", "ForeignKeyNotFound", 1, "SECTORID");
               AnyError = 1;
            }
         }
         A10SectorName = BC00055_A10SectorName[0];
         pr_default.close(3);
         if ( ! ( (DateTime.MinValue==A28ProductCreatedDate) || ( DateTimeUtil.ResetTime ( A28ProductCreatedDate ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Product Created Date is out of range", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A29ProductModifiedDate) || ( DateTimeUtil.ResetTime ( A29ProductModifiedDate ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Product Modified Date is out of range", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && A110ProductActive )
         {
            AV16ProductState = "Enabled";
         }
         else
         {
            if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ! A110ProductActive )
            {
               AV16ProductState = "Disabled";
            }
         }
      }

      protected void CloseExtendedTableCursors055( )
      {
         pr_default.close(2);
         pr_default.close(4);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey055( )
      {
         /* Using cursor BC00059 */
         pr_default.execute(7, new Object[] {A15ProductId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound5 = 1;
         }
         else
         {
            RcdFound5 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00053 */
         pr_default.execute(1, new Object[] {A15ProductId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM055( 22) ;
            RcdFound5 = 1;
            A15ProductId = BC00053_A15ProductId[0];
            A110ProductActive = BC00053_A110ProductActive[0];
            n110ProductActive = BC00053_n110ProductActive[0];
            A55ProductCode = BC00053_A55ProductCode[0];
            n55ProductCode = BC00053_n55ProductCode[0];
            A16ProductName = BC00053_A16ProductName[0];
            A85ProductCostPrice = BC00053_A85ProductCostPrice[0];
            n85ProductCostPrice = BC00053_n85ProductCostPrice[0];
            A89ProductRetailProfit = BC00053_A89ProductRetailProfit[0];
            n89ProductRetailProfit = BC00053_n89ProductRetailProfit[0];
            A87ProductWholesaleProfit = BC00053_A87ProductWholesaleProfit[0];
            n87ProductWholesaleProfit = BC00053_n87ProductWholesaleProfit[0];
            A17ProductStock = BC00053_A17ProductStock[0];
            n17ProductStock = BC00053_n17ProductStock[0];
            A69ProductMiniumStock = BC00053_A69ProductMiniumStock[0];
            n69ProductMiniumStock = BC00053_n69ProductMiniumStock[0];
            A19ProductDescription = BC00053_A19ProductDescription[0];
            n19ProductDescription = BC00053_n19ProductDescription[0];
            A28ProductCreatedDate = BC00053_A28ProductCreatedDate[0];
            A29ProductModifiedDate = BC00053_A29ProductModifiedDate[0];
            A93ProductMiniumQuantityWholesale = BC00053_A93ProductMiniumQuantityWholesale[0];
            n93ProductMiniumQuantityWholesale = BC00053_n93ProductMiniumQuantityWholesale[0];
            A1BrandId = BC00053_A1BrandId[0];
            n1BrandId = BC00053_n1BrandId[0];
            A9SectorId = BC00053_A9SectorId[0];
            n9SectorId = BC00053_n9SectorId[0];
            A4SupplierId = BC00053_A4SupplierId[0];
            Z15ProductId = A15ProductId;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load055( ) ;
            if ( AnyError == 1 )
            {
               RcdFound5 = 0;
               InitializeNonKey055( ) ;
            }
            Gx_mode = sMode5;
         }
         else
         {
            RcdFound5 = 0;
            InitializeNonKey055( ) ;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode5;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey055( ) ;
         if ( RcdFound5 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_050( ) ;
         IsConfirmed = 0;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency055( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00052 */
            pr_default.execute(0, new Object[] {A15ProductId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Product"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z110ProductActive != BC00052_A110ProductActive[0] ) || ( StringUtil.StrCmp(Z55ProductCode, BC00052_A55ProductCode[0]) != 0 ) || ( StringUtil.StrCmp(Z16ProductName, BC00052_A16ProductName[0]) != 0 ) || ( Z85ProductCostPrice != BC00052_A85ProductCostPrice[0] ) || ( Z89ProductRetailProfit != BC00052_A89ProductRetailProfit[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z87ProductWholesaleProfit != BC00052_A87ProductWholesaleProfit[0] ) || ( Z17ProductStock != BC00052_A17ProductStock[0] ) || ( Z69ProductMiniumStock != BC00052_A69ProductMiniumStock[0] ) || ( StringUtil.StrCmp(Z19ProductDescription, BC00052_A19ProductDescription[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z28ProductCreatedDate ) != DateTimeUtil.ResetTime ( BC00052_A28ProductCreatedDate[0] ) ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( DateTimeUtil.ResetTime ( Z29ProductModifiedDate ) != DateTimeUtil.ResetTime ( BC00052_A29ProductModifiedDate[0] ) ) || ( Z93ProductMiniumQuantityWholesale != BC00052_A93ProductMiniumQuantityWholesale[0] ) || ( Z1BrandId != BC00052_A1BrandId[0] ) || ( Z9SectorId != BC00052_A9SectorId[0] ) || ( Z4SupplierId != BC00052_A4SupplierId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Product"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert055( )
      {
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable055( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM055( 0) ;
            CheckOptimisticConcurrency055( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm055( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert055( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000510 */
                     pr_default.execute(8, new Object[] {n110ProductActive, A110ProductActive, n55ProductCode, A55ProductCode, A16ProductName, n85ProductCostPrice, A85ProductCostPrice, n89ProductRetailProfit, A89ProductRetailProfit, n87ProductWholesaleProfit, A87ProductWholesaleProfit, n17ProductStock, A17ProductStock, n69ProductMiniumStock, A69ProductMiniumStock, n19ProductDescription, A19ProductDescription, A28ProductCreatedDate, A29ProductModifiedDate, n93ProductMiniumQuantityWholesale, A93ProductMiniumQuantityWholesale, n1BrandId, A1BrandId, n9SectorId, A9SectorId, A4SupplierId});
                     A15ProductId = BC000510_A15ProductId[0];
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Product");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load055( ) ;
            }
            EndLevel055( ) ;
         }
         CloseExtendedTableCursors055( ) ;
      }

      protected void Update055( )
      {
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable055( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency055( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm055( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate055( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000511 */
                     pr_default.execute(9, new Object[] {n110ProductActive, A110ProductActive, n55ProductCode, A55ProductCode, A16ProductName, n85ProductCostPrice, A85ProductCostPrice, n89ProductRetailProfit, A89ProductRetailProfit, n87ProductWholesaleProfit, A87ProductWholesaleProfit, n17ProductStock, A17ProductStock, n69ProductMiniumStock, A69ProductMiniumStock, n19ProductDescription, A19ProductDescription, A28ProductCreatedDate, A29ProductModifiedDate, n93ProductMiniumQuantityWholesale, A93ProductMiniumQuantityWholesale, n1BrandId, A1BrandId, n9SectorId, A9SectorId, A4SupplierId, A15ProductId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Product");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Product"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate055( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel055( ) ;
         }
         CloseExtendedTableCursors055( ) ;
      }

      protected void DeferredUpdate055( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency055( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls055( ) ;
            AfterConfirm055( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete055( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000512 */
                  pr_default.execute(10, new Object[] {A15ProductId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("Product");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode5 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel055( ) ;
         Gx_mode = sMode5;
      }

      protected void OnDeleteControls055( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV26Pgmname = "Product_BC";
            GXt_decimal4 = A90ProductRetailPrice;
            new roundvalue(context ).execute(  A85ProductCostPrice*(1+A89ProductRetailProfit/ (decimal)(100)), out  GXt_decimal4) ;
            GXt_decimal3 = A90ProductRetailPrice;
            new roundvalue(context ).execute(  A85ProductCostPrice*(1+A89ProductRetailProfit/ (decimal)(100)), out  GXt_decimal3) ;
            GXt_decimal2 = A90ProductRetailPrice;
            new roundvalue(context ).execute(  A85ProductCostPrice, out  GXt_decimal2) ;
            A90ProductRetailPrice = ((A89ProductRetailProfit!=Convert.ToDecimal(0)) ? GXt_decimal3 : GXt_decimal2);
            GXt_decimal4 = A88ProductWholesalePrice;
            new roundvalue(context ).execute(  A85ProductCostPrice*(1+A87ProductWholesaleProfit/ (decimal)(100)), out  GXt_decimal4) ;
            GXt_decimal3 = A88ProductWholesalePrice;
            new roundvalue(context ).execute(  A85ProductCostPrice*(1+A87ProductWholesaleProfit/ (decimal)(100)), out  GXt_decimal3) ;
            GXt_decimal2 = A88ProductWholesalePrice;
            new roundvalue(context ).execute(  A85ProductCostPrice, out  GXt_decimal2) ;
            A88ProductWholesalePrice = ((A87ProductWholesaleProfit!=Convert.ToDecimal(0)) ? GXt_decimal3 : GXt_decimal2);
            /* Using cursor BC000513 */
            pr_default.execute(11, new Object[] {n1BrandId, A1BrandId});
            A2BrandName = BC000513_A2BrandName[0];
            pr_default.close(11);
            /* Using cursor BC000514 */
            pr_default.execute(12, new Object[] {A4SupplierId});
            A5SupplierName = BC000514_A5SupplierName[0];
            pr_default.close(12);
            /* Using cursor BC000515 */
            pr_default.execute(13, new Object[] {n9SectorId, A9SectorId});
            A10SectorName = BC000515_A10SectorName[0];
            pr_default.close(13);
            if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && A110ProductActive )
            {
               AV16ProductState = "Enabled";
            }
            else
            {
               if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ! A110ProductActive )
               {
                  AV16ProductState = "Disabled";
               }
            }
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000516 */
            pr_default.execute(14, new Object[] {A15ProductId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detail"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor BC000517 */
            pr_default.execute(15, new Object[] {A15ProductId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detail"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
         }
      }

      protected void EndLevel055( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete055( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart055( )
      {
         /* Scan By routine */
         /* Using cursor BC000518 */
         pr_default.execute(16, new Object[] {A15ProductId});
         RcdFound5 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound5 = 1;
            A15ProductId = BC000518_A15ProductId[0];
            A110ProductActive = BC000518_A110ProductActive[0];
            n110ProductActive = BC000518_n110ProductActive[0];
            A55ProductCode = BC000518_A55ProductCode[0];
            n55ProductCode = BC000518_n55ProductCode[0];
            A16ProductName = BC000518_A16ProductName[0];
            A85ProductCostPrice = BC000518_A85ProductCostPrice[0];
            n85ProductCostPrice = BC000518_n85ProductCostPrice[0];
            A89ProductRetailProfit = BC000518_A89ProductRetailProfit[0];
            n89ProductRetailProfit = BC000518_n89ProductRetailProfit[0];
            A87ProductWholesaleProfit = BC000518_A87ProductWholesaleProfit[0];
            n87ProductWholesaleProfit = BC000518_n87ProductWholesaleProfit[0];
            A2BrandName = BC000518_A2BrandName[0];
            A5SupplierName = BC000518_A5SupplierName[0];
            A10SectorName = BC000518_A10SectorName[0];
            A17ProductStock = BC000518_A17ProductStock[0];
            n17ProductStock = BC000518_n17ProductStock[0];
            A69ProductMiniumStock = BC000518_A69ProductMiniumStock[0];
            n69ProductMiniumStock = BC000518_n69ProductMiniumStock[0];
            A19ProductDescription = BC000518_A19ProductDescription[0];
            n19ProductDescription = BC000518_n19ProductDescription[0];
            A28ProductCreatedDate = BC000518_A28ProductCreatedDate[0];
            A29ProductModifiedDate = BC000518_A29ProductModifiedDate[0];
            A93ProductMiniumQuantityWholesale = BC000518_A93ProductMiniumQuantityWholesale[0];
            n93ProductMiniumQuantityWholesale = BC000518_n93ProductMiniumQuantityWholesale[0];
            A1BrandId = BC000518_A1BrandId[0];
            n1BrandId = BC000518_n1BrandId[0];
            A9SectorId = BC000518_A9SectorId[0];
            n9SectorId = BC000518_n9SectorId[0];
            A4SupplierId = BC000518_A4SupplierId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext055( )
      {
         /* Scan next routine */
         pr_default.readNext(16);
         RcdFound5 = 0;
         ScanKeyLoad055( ) ;
      }

      protected void ScanKeyLoad055( )
      {
         sMode5 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound5 = 1;
            A15ProductId = BC000518_A15ProductId[0];
            A110ProductActive = BC000518_A110ProductActive[0];
            n110ProductActive = BC000518_n110ProductActive[0];
            A55ProductCode = BC000518_A55ProductCode[0];
            n55ProductCode = BC000518_n55ProductCode[0];
            A16ProductName = BC000518_A16ProductName[0];
            A85ProductCostPrice = BC000518_A85ProductCostPrice[0];
            n85ProductCostPrice = BC000518_n85ProductCostPrice[0];
            A89ProductRetailProfit = BC000518_A89ProductRetailProfit[0];
            n89ProductRetailProfit = BC000518_n89ProductRetailProfit[0];
            A87ProductWholesaleProfit = BC000518_A87ProductWholesaleProfit[0];
            n87ProductWholesaleProfit = BC000518_n87ProductWholesaleProfit[0];
            A2BrandName = BC000518_A2BrandName[0];
            A5SupplierName = BC000518_A5SupplierName[0];
            A10SectorName = BC000518_A10SectorName[0];
            A17ProductStock = BC000518_A17ProductStock[0];
            n17ProductStock = BC000518_n17ProductStock[0];
            A69ProductMiniumStock = BC000518_A69ProductMiniumStock[0];
            n69ProductMiniumStock = BC000518_n69ProductMiniumStock[0];
            A19ProductDescription = BC000518_A19ProductDescription[0];
            n19ProductDescription = BC000518_n19ProductDescription[0];
            A28ProductCreatedDate = BC000518_A28ProductCreatedDate[0];
            A29ProductModifiedDate = BC000518_A29ProductModifiedDate[0];
            A93ProductMiniumQuantityWholesale = BC000518_A93ProductMiniumQuantityWholesale[0];
            n93ProductMiniumQuantityWholesale = BC000518_n93ProductMiniumQuantityWholesale[0];
            A1BrandId = BC000518_A1BrandId[0];
            n1BrandId = BC000518_n1BrandId[0];
            A9SectorId = BC000518_A9SectorId[0];
            n9SectorId = BC000518_n9SectorId[0];
            A4SupplierId = BC000518_A4SupplierId[0];
         }
         Gx_mode = sMode5;
      }

      protected void ScanKeyEnd055( )
      {
         pr_default.close(16);
      }

      protected void AfterConfirm055( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert055( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate055( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete055( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete055( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate055( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes055( )
      {
      }

      protected void send_integrity_lvl_hashes055( )
      {
      }

      protected void AddRow055( )
      {
         VarsToRow5( bcProduct) ;
      }

      protected void ReadRow055( )
      {
         RowToVars5( bcProduct, 1) ;
      }

      protected void InitializeNonKey055( )
      {
         A110ProductActive = false;
         n110ProductActive = false;
         A88ProductWholesalePrice = 0;
         A90ProductRetailPrice = 0;
         A55ProductCode = "";
         n55ProductCode = false;
         A16ProductName = "";
         A85ProductCostPrice = 0;
         n85ProductCostPrice = false;
         A1BrandId = 0;
         n1BrandId = false;
         A2BrandName = "";
         A4SupplierId = 0;
         A5SupplierName = "";
         A9SectorId = 0;
         n9SectorId = false;
         A10SectorName = "";
         A19ProductDescription = "";
         n19ProductDescription = false;
         A28ProductCreatedDate = DateTime.MinValue;
         A29ProductModifiedDate = DateTime.MinValue;
         A89ProductRetailProfit = 0;
         n89ProductRetailProfit = false;
         A87ProductWholesaleProfit = 0;
         n87ProductWholesaleProfit = false;
         A17ProductStock = 0;
         n17ProductStock = false;
         A69ProductMiniumStock = 0;
         n69ProductMiniumStock = false;
         A93ProductMiniumQuantityWholesale = 0;
         n93ProductMiniumQuantityWholesale = false;
         Z110ProductActive = false;
         Z55ProductCode = "";
         Z16ProductName = "";
         Z85ProductCostPrice = 0;
         Z89ProductRetailProfit = 0;
         Z87ProductWholesaleProfit = 0;
         Z17ProductStock = 0;
         Z69ProductMiniumStock = 0;
         Z19ProductDescription = "";
         Z28ProductCreatedDate = DateTime.MinValue;
         Z29ProductModifiedDate = DateTime.MinValue;
         Z93ProductMiniumQuantityWholesale = 0;
         Z1BrandId = 0;
         Z9SectorId = 0;
         Z4SupplierId = 0;
      }

      protected void InitAll055( )
      {
         A15ProductId = 0;
         InitializeNonKey055( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A17ProductStock = i17ProductStock;
         n17ProductStock = false;
         A69ProductMiniumStock = i69ProductMiniumStock;
         n69ProductMiniumStock = false;
         A93ProductMiniumQuantityWholesale = i93ProductMiniumQuantityWholesale;
         n93ProductMiniumQuantityWholesale = false;
         A89ProductRetailProfit = i89ProductRetailProfit;
         n89ProductRetailProfit = false;
         A87ProductWholesaleProfit = i87ProductWholesaleProfit;
         n87ProductWholesaleProfit = false;
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void VarsToRow5( SdtProduct obj5 )
      {
         obj5.gxTpr_Mode = Gx_mode;
         obj5.gxTpr_Productactive = A110ProductActive;
         obj5.gxTpr_Productwholesaleprice = A88ProductWholesalePrice;
         obj5.gxTpr_Productretailprice = A90ProductRetailPrice;
         obj5.gxTpr_Productcode = A55ProductCode;
         obj5.gxTpr_Productname = A16ProductName;
         obj5.gxTpr_Productcostprice = A85ProductCostPrice;
         obj5.gxTpr_Brandid = A1BrandId;
         obj5.gxTpr_Brandname = A2BrandName;
         obj5.gxTpr_Supplierid = A4SupplierId;
         obj5.gxTpr_Suppliername = A5SupplierName;
         obj5.gxTpr_Sectorid = A9SectorId;
         obj5.gxTpr_Sectorname = A10SectorName;
         obj5.gxTpr_Productdescription = A19ProductDescription;
         obj5.gxTpr_Productcreateddate = A28ProductCreatedDate;
         obj5.gxTpr_Productmodifieddate = A29ProductModifiedDate;
         obj5.gxTpr_Productretailprofit = A89ProductRetailProfit;
         obj5.gxTpr_Productwholesaleprofit = A87ProductWholesaleProfit;
         obj5.gxTpr_Productstock = A17ProductStock;
         obj5.gxTpr_Productminiumstock = A69ProductMiniumStock;
         obj5.gxTpr_Productminiumquantitywholesale = A93ProductMiniumQuantityWholesale;
         obj5.gxTpr_Productid = A15ProductId;
         obj5.gxTpr_Productid_Z = Z15ProductId;
         obj5.gxTpr_Productcode_Z = Z55ProductCode;
         obj5.gxTpr_Productname_Z = Z16ProductName;
         obj5.gxTpr_Productcostprice_Z = Z85ProductCostPrice;
         obj5.gxTpr_Productretailprofit_Z = Z89ProductRetailProfit;
         obj5.gxTpr_Productretailprice_Z = Z90ProductRetailPrice;
         obj5.gxTpr_Productwholesaleprofit_Z = Z87ProductWholesaleProfit;
         obj5.gxTpr_Productwholesaleprice_Z = Z88ProductWholesalePrice;
         obj5.gxTpr_Brandid_Z = Z1BrandId;
         obj5.gxTpr_Brandname_Z = Z2BrandName;
         obj5.gxTpr_Supplierid_Z = Z4SupplierId;
         obj5.gxTpr_Suppliername_Z = Z5SupplierName;
         obj5.gxTpr_Sectorid_Z = Z9SectorId;
         obj5.gxTpr_Sectorname_Z = Z10SectorName;
         obj5.gxTpr_Productstock_Z = Z17ProductStock;
         obj5.gxTpr_Productminiumstock_Z = Z69ProductMiniumStock;
         obj5.gxTpr_Productdescription_Z = Z19ProductDescription;
         obj5.gxTpr_Productcreateddate_Z = Z28ProductCreatedDate;
         obj5.gxTpr_Productmodifieddate_Z = Z29ProductModifiedDate;
         obj5.gxTpr_Productminiumquantitywholesale_Z = Z93ProductMiniumQuantityWholesale;
         obj5.gxTpr_Productactive_Z = Z110ProductActive;
         obj5.gxTpr_Productcode_N = (short)(Convert.ToInt16(n55ProductCode));
         obj5.gxTpr_Productcostprice_N = (short)(Convert.ToInt16(n85ProductCostPrice));
         obj5.gxTpr_Productretailprofit_N = (short)(Convert.ToInt16(n89ProductRetailProfit));
         obj5.gxTpr_Productwholesaleprofit_N = (short)(Convert.ToInt16(n87ProductWholesaleProfit));
         obj5.gxTpr_Brandid_N = (short)(Convert.ToInt16(n1BrandId));
         obj5.gxTpr_Sectorid_N = (short)(Convert.ToInt16(n9SectorId));
         obj5.gxTpr_Productstock_N = (short)(Convert.ToInt16(n17ProductStock));
         obj5.gxTpr_Productminiumstock_N = (short)(Convert.ToInt16(n69ProductMiniumStock));
         obj5.gxTpr_Productdescription_N = (short)(Convert.ToInt16(n19ProductDescription));
         obj5.gxTpr_Productminiumquantitywholesale_N = (short)(Convert.ToInt16(n93ProductMiniumQuantityWholesale));
         obj5.gxTpr_Productactive_N = (short)(Convert.ToInt16(n110ProductActive));
         obj5.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow5( SdtProduct obj5 )
      {
         obj5.gxTpr_Productid = A15ProductId;
         return  ;
      }

      public void RowToVars5( SdtProduct obj5 ,
                              int forceLoad )
      {
         Gx_mode = obj5.gxTpr_Mode;
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) || ( forceLoad == 1 ) )
         {
            A110ProductActive = obj5.gxTpr_Productactive;
            n110ProductActive = false;
         }
         A88ProductWholesalePrice = obj5.gxTpr_Productwholesaleprice;
         A90ProductRetailPrice = obj5.gxTpr_Productretailprice;
         A55ProductCode = obj5.gxTpr_Productcode;
         n55ProductCode = false;
         A16ProductName = obj5.gxTpr_Productname;
         A85ProductCostPrice = obj5.gxTpr_Productcostprice;
         n85ProductCostPrice = false;
         A1BrandId = obj5.gxTpr_Brandid;
         n1BrandId = false;
         A2BrandName = obj5.gxTpr_Brandname;
         A4SupplierId = obj5.gxTpr_Supplierid;
         A5SupplierName = obj5.gxTpr_Suppliername;
         A9SectorId = obj5.gxTpr_Sectorid;
         n9SectorId = false;
         A10SectorName = obj5.gxTpr_Sectorname;
         A19ProductDescription = obj5.gxTpr_Productdescription;
         n19ProductDescription = false;
         A28ProductCreatedDate = obj5.gxTpr_Productcreateddate;
         A29ProductModifiedDate = obj5.gxTpr_Productmodifieddate;
         A89ProductRetailProfit = obj5.gxTpr_Productretailprofit;
         n89ProductRetailProfit = false;
         A87ProductWholesaleProfit = obj5.gxTpr_Productwholesaleprofit;
         n87ProductWholesaleProfit = false;
         A17ProductStock = obj5.gxTpr_Productstock;
         n17ProductStock = false;
         A69ProductMiniumStock = obj5.gxTpr_Productminiumstock;
         n69ProductMiniumStock = false;
         A93ProductMiniumQuantityWholesale = obj5.gxTpr_Productminiumquantitywholesale;
         n93ProductMiniumQuantityWholesale = false;
         A15ProductId = obj5.gxTpr_Productid;
         Z15ProductId = obj5.gxTpr_Productid_Z;
         Z55ProductCode = obj5.gxTpr_Productcode_Z;
         Z16ProductName = obj5.gxTpr_Productname_Z;
         Z85ProductCostPrice = obj5.gxTpr_Productcostprice_Z;
         Z89ProductRetailProfit = obj5.gxTpr_Productretailprofit_Z;
         Z90ProductRetailPrice = obj5.gxTpr_Productretailprice_Z;
         Z87ProductWholesaleProfit = obj5.gxTpr_Productwholesaleprofit_Z;
         Z88ProductWholesalePrice = obj5.gxTpr_Productwholesaleprice_Z;
         Z1BrandId = obj5.gxTpr_Brandid_Z;
         Z2BrandName = obj5.gxTpr_Brandname_Z;
         Z4SupplierId = obj5.gxTpr_Supplierid_Z;
         Z5SupplierName = obj5.gxTpr_Suppliername_Z;
         Z9SectorId = obj5.gxTpr_Sectorid_Z;
         Z10SectorName = obj5.gxTpr_Sectorname_Z;
         Z17ProductStock = obj5.gxTpr_Productstock_Z;
         Z69ProductMiniumStock = obj5.gxTpr_Productminiumstock_Z;
         Z19ProductDescription = obj5.gxTpr_Productdescription_Z;
         Z28ProductCreatedDate = obj5.gxTpr_Productcreateddate_Z;
         Z29ProductModifiedDate = obj5.gxTpr_Productmodifieddate_Z;
         Z93ProductMiniumQuantityWholesale = obj5.gxTpr_Productminiumquantitywholesale_Z;
         Z110ProductActive = obj5.gxTpr_Productactive_Z;
         n55ProductCode = (bool)(Convert.ToBoolean(obj5.gxTpr_Productcode_N));
         n85ProductCostPrice = (bool)(Convert.ToBoolean(obj5.gxTpr_Productcostprice_N));
         n89ProductRetailProfit = (bool)(Convert.ToBoolean(obj5.gxTpr_Productretailprofit_N));
         n87ProductWholesaleProfit = (bool)(Convert.ToBoolean(obj5.gxTpr_Productwholesaleprofit_N));
         n1BrandId = (bool)(Convert.ToBoolean(obj5.gxTpr_Brandid_N));
         n9SectorId = (bool)(Convert.ToBoolean(obj5.gxTpr_Sectorid_N));
         n17ProductStock = (bool)(Convert.ToBoolean(obj5.gxTpr_Productstock_N));
         n69ProductMiniumStock = (bool)(Convert.ToBoolean(obj5.gxTpr_Productminiumstock_N));
         n19ProductDescription = (bool)(Convert.ToBoolean(obj5.gxTpr_Productdescription_N));
         n93ProductMiniumQuantityWholesale = (bool)(Convert.ToBoolean(obj5.gxTpr_Productminiumquantitywholesale_N));
         n110ProductActive = (bool)(Convert.ToBoolean(obj5.gxTpr_Productactive_N));
         Gx_mode = obj5.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A15ProductId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey055( ) ;
         ScanKeyStart055( ) ;
         if ( RcdFound5 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z15ProductId = A15ProductId;
         }
         ZM055( -22) ;
         OnLoadActions055( ) ;
         AddRow055( ) ;
         ScanKeyEnd055( ) ;
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars5( bcProduct, 0) ;
         ScanKeyStart055( ) ;
         if ( RcdFound5 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z15ProductId = A15ProductId;
         }
         ZM055( -22) ;
         OnLoadActions055( ) ;
         AddRow055( ) ;
         ScanKeyEnd055( ) ;
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey055( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert055( ) ;
         }
         else
         {
            if ( RcdFound5 == 1 )
            {
               if ( A15ProductId != Z15ProductId )
               {
                  A15ProductId = Z15ProductId;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update055( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( A15ProductId != Z15ProductId )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert055( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert055( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars5( bcProduct, 1) ;
         SaveImpl( ) ;
         VarsToRow5( bcProduct) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars5( bcProduct, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert055( ) ;
         AfterTrn( ) ;
         VarsToRow5( bcProduct) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow5( bcProduct) ;
         }
         else
         {
            SdtProduct auxBC = new SdtProduct(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A15ProductId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcProduct);
               auxBC.Save();
               bcProduct.Copy((GxSilentTrnSdt)(auxBC));
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars5( bcProduct, 1) ;
         UpdateImpl( ) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars5( bcProduct, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert055( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
            else
            {
               VarsToRow5( bcProduct) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow5( bcProduct) ;
         }
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars5( bcProduct, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey055( ) ;
         if ( RcdFound5 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A15ProductId != Z15ProductId )
            {
               A15ProductId = Z15ProductId;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( A15ProductId != Z15ProductId )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         pr_default.close(1);
         pr_default.close(11);
         pr_default.close(13);
         pr_default.close(12);
         context.RollbackDataStores("product_bc",pr_default);
         VarsToRow5( bcProduct) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public string GetMode( )
      {
         Gx_mode = bcProduct.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcProduct.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcProduct )
         {
            bcProduct = (SdtProduct)(sdt);
            if ( StringUtil.StrCmp(bcProduct.gxTpr_Mode, "") == 0 )
            {
               bcProduct.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow5( bcProduct) ;
            }
            else
            {
               RowToVars5( bcProduct, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcProduct.gxTpr_Mode, "") == 0 )
            {
               bcProduct.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars5( bcProduct, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtProduct Product_BC
      {
         get {
            return bcProduct ;
         }

      }

      public void webExecute( )
      {
         createObjects();
         initialize();
      }

      protected void createObjects( )
      {
      }

      protected void Process( )
      {
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
         pr_default.close(1);
         pr_default.close(11);
         pr_default.close(13);
         pr_default.close(12);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXt_SdtSDTContextSession1 = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         AV26Pgmname = "";
         AV16ProductState = "";
         AV22ErrorMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         Z55ProductCode = "";
         A55ProductCode = "";
         Z16ProductName = "";
         A16ProductName = "";
         Z19ProductDescription = "";
         A19ProductDescription = "";
         Z28ProductCreatedDate = DateTime.MinValue;
         A28ProductCreatedDate = DateTime.MinValue;
         Z29ProductModifiedDate = DateTime.MinValue;
         A29ProductModifiedDate = DateTime.MinValue;
         Z2BrandName = "";
         A2BrandName = "";
         Z10SectorName = "";
         A10SectorName = "";
         Z5SupplierName = "";
         A5SupplierName = "";
         Gx_date = DateTime.MinValue;
         BC00057_A15ProductId = new int[1] ;
         BC00057_A110ProductActive = new bool[] {false} ;
         BC00057_n110ProductActive = new bool[] {false} ;
         BC00057_A55ProductCode = new string[] {""} ;
         BC00057_n55ProductCode = new bool[] {false} ;
         BC00057_A16ProductName = new string[] {""} ;
         BC00057_A85ProductCostPrice = new decimal[1] ;
         BC00057_n85ProductCostPrice = new bool[] {false} ;
         BC00057_A89ProductRetailProfit = new decimal[1] ;
         BC00057_n89ProductRetailProfit = new bool[] {false} ;
         BC00057_A87ProductWholesaleProfit = new decimal[1] ;
         BC00057_n87ProductWholesaleProfit = new bool[] {false} ;
         BC00057_A2BrandName = new string[] {""} ;
         BC00057_A5SupplierName = new string[] {""} ;
         BC00057_A10SectorName = new string[] {""} ;
         BC00057_A17ProductStock = new int[1] ;
         BC00057_n17ProductStock = new bool[] {false} ;
         BC00057_A69ProductMiniumStock = new int[1] ;
         BC00057_n69ProductMiniumStock = new bool[] {false} ;
         BC00057_A19ProductDescription = new string[] {""} ;
         BC00057_n19ProductDescription = new bool[] {false} ;
         BC00057_A28ProductCreatedDate = new DateTime[] {DateTime.MinValue} ;
         BC00057_A29ProductModifiedDate = new DateTime[] {DateTime.MinValue} ;
         BC00057_A93ProductMiniumQuantityWholesale = new short[1] ;
         BC00057_n93ProductMiniumQuantityWholesale = new bool[] {false} ;
         BC00057_A1BrandId = new int[1] ;
         BC00057_n1BrandId = new bool[] {false} ;
         BC00057_A9SectorId = new int[1] ;
         BC00057_n9SectorId = new bool[] {false} ;
         BC00057_A4SupplierId = new int[1] ;
         BC00058_A16ProductName = new string[] {""} ;
         BC00054_A2BrandName = new string[] {""} ;
         BC00056_A5SupplierName = new string[] {""} ;
         BC00055_A10SectorName = new string[] {""} ;
         BC00059_A15ProductId = new int[1] ;
         BC00053_A15ProductId = new int[1] ;
         BC00053_A110ProductActive = new bool[] {false} ;
         BC00053_n110ProductActive = new bool[] {false} ;
         BC00053_A55ProductCode = new string[] {""} ;
         BC00053_n55ProductCode = new bool[] {false} ;
         BC00053_A16ProductName = new string[] {""} ;
         BC00053_A85ProductCostPrice = new decimal[1] ;
         BC00053_n85ProductCostPrice = new bool[] {false} ;
         BC00053_A89ProductRetailProfit = new decimal[1] ;
         BC00053_n89ProductRetailProfit = new bool[] {false} ;
         BC00053_A87ProductWholesaleProfit = new decimal[1] ;
         BC00053_n87ProductWholesaleProfit = new bool[] {false} ;
         BC00053_A17ProductStock = new int[1] ;
         BC00053_n17ProductStock = new bool[] {false} ;
         BC00053_A69ProductMiniumStock = new int[1] ;
         BC00053_n69ProductMiniumStock = new bool[] {false} ;
         BC00053_A19ProductDescription = new string[] {""} ;
         BC00053_n19ProductDescription = new bool[] {false} ;
         BC00053_A28ProductCreatedDate = new DateTime[] {DateTime.MinValue} ;
         BC00053_A29ProductModifiedDate = new DateTime[] {DateTime.MinValue} ;
         BC00053_A93ProductMiniumQuantityWholesale = new short[1] ;
         BC00053_n93ProductMiniumQuantityWholesale = new bool[] {false} ;
         BC00053_A1BrandId = new int[1] ;
         BC00053_n1BrandId = new bool[] {false} ;
         BC00053_A9SectorId = new int[1] ;
         BC00053_n9SectorId = new bool[] {false} ;
         BC00053_A4SupplierId = new int[1] ;
         sMode5 = "";
         BC00052_A15ProductId = new int[1] ;
         BC00052_A110ProductActive = new bool[] {false} ;
         BC00052_n110ProductActive = new bool[] {false} ;
         BC00052_A55ProductCode = new string[] {""} ;
         BC00052_n55ProductCode = new bool[] {false} ;
         BC00052_A16ProductName = new string[] {""} ;
         BC00052_A85ProductCostPrice = new decimal[1] ;
         BC00052_n85ProductCostPrice = new bool[] {false} ;
         BC00052_A89ProductRetailProfit = new decimal[1] ;
         BC00052_n89ProductRetailProfit = new bool[] {false} ;
         BC00052_A87ProductWholesaleProfit = new decimal[1] ;
         BC00052_n87ProductWholesaleProfit = new bool[] {false} ;
         BC00052_A17ProductStock = new int[1] ;
         BC00052_n17ProductStock = new bool[] {false} ;
         BC00052_A69ProductMiniumStock = new int[1] ;
         BC00052_n69ProductMiniumStock = new bool[] {false} ;
         BC00052_A19ProductDescription = new string[] {""} ;
         BC00052_n19ProductDescription = new bool[] {false} ;
         BC00052_A28ProductCreatedDate = new DateTime[] {DateTime.MinValue} ;
         BC00052_A29ProductModifiedDate = new DateTime[] {DateTime.MinValue} ;
         BC00052_A93ProductMiniumQuantityWholesale = new short[1] ;
         BC00052_n93ProductMiniumQuantityWholesale = new bool[] {false} ;
         BC00052_A1BrandId = new int[1] ;
         BC00052_n1BrandId = new bool[] {false} ;
         BC00052_A9SectorId = new int[1] ;
         BC00052_n9SectorId = new bool[] {false} ;
         BC00052_A4SupplierId = new int[1] ;
         BC000510_A15ProductId = new int[1] ;
         BC000513_A2BrandName = new string[] {""} ;
         BC000514_A5SupplierName = new string[] {""} ;
         BC000515_A10SectorName = new string[] {""} ;
         BC000516_A20InvoiceId = new int[1] ;
         BC000516_A25InvoiceDetailId = new int[1] ;
         BC000517_A50PurchaseOrderId = new int[1] ;
         BC000517_A61PurchaseOrderDetailId = new int[1] ;
         BC000518_A15ProductId = new int[1] ;
         BC000518_A110ProductActive = new bool[] {false} ;
         BC000518_n110ProductActive = new bool[] {false} ;
         BC000518_A55ProductCode = new string[] {""} ;
         BC000518_n55ProductCode = new bool[] {false} ;
         BC000518_A16ProductName = new string[] {""} ;
         BC000518_A85ProductCostPrice = new decimal[1] ;
         BC000518_n85ProductCostPrice = new bool[] {false} ;
         BC000518_A89ProductRetailProfit = new decimal[1] ;
         BC000518_n89ProductRetailProfit = new bool[] {false} ;
         BC000518_A87ProductWholesaleProfit = new decimal[1] ;
         BC000518_n87ProductWholesaleProfit = new bool[] {false} ;
         BC000518_A2BrandName = new string[] {""} ;
         BC000518_A5SupplierName = new string[] {""} ;
         BC000518_A10SectorName = new string[] {""} ;
         BC000518_A17ProductStock = new int[1] ;
         BC000518_n17ProductStock = new bool[] {false} ;
         BC000518_A69ProductMiniumStock = new int[1] ;
         BC000518_n69ProductMiniumStock = new bool[] {false} ;
         BC000518_A19ProductDescription = new string[] {""} ;
         BC000518_n19ProductDescription = new bool[] {false} ;
         BC000518_A28ProductCreatedDate = new DateTime[] {DateTime.MinValue} ;
         BC000518_A29ProductModifiedDate = new DateTime[] {DateTime.MinValue} ;
         BC000518_A93ProductMiniumQuantityWholesale = new short[1] ;
         BC000518_n93ProductMiniumQuantityWholesale = new bool[] {false} ;
         BC000518_A1BrandId = new int[1] ;
         BC000518_n1BrandId = new bool[] {false} ;
         BC000518_A9SectorId = new int[1] ;
         BC000518_n9SectorId = new bool[] {false} ;
         BC000518_A4SupplierId = new int[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.product_bc__default(),
            new Object[][] {
                new Object[] {
               BC00052_A15ProductId, BC00052_A110ProductActive, BC00052_n110ProductActive, BC00052_A55ProductCode, BC00052_n55ProductCode, BC00052_A16ProductName, BC00052_A85ProductCostPrice, BC00052_n85ProductCostPrice, BC00052_A89ProductRetailProfit, BC00052_n89ProductRetailProfit,
               BC00052_A87ProductWholesaleProfit, BC00052_n87ProductWholesaleProfit, BC00052_A17ProductStock, BC00052_n17ProductStock, BC00052_A69ProductMiniumStock, BC00052_n69ProductMiniumStock, BC00052_A19ProductDescription, BC00052_n19ProductDescription, BC00052_A28ProductCreatedDate, BC00052_A29ProductModifiedDate,
               BC00052_A93ProductMiniumQuantityWholesale, BC00052_n93ProductMiniumQuantityWholesale, BC00052_A1BrandId, BC00052_n1BrandId, BC00052_A9SectorId, BC00052_n9SectorId, BC00052_A4SupplierId
               }
               , new Object[] {
               BC00053_A15ProductId, BC00053_A110ProductActive, BC00053_n110ProductActive, BC00053_A55ProductCode, BC00053_n55ProductCode, BC00053_A16ProductName, BC00053_A85ProductCostPrice, BC00053_n85ProductCostPrice, BC00053_A89ProductRetailProfit, BC00053_n89ProductRetailProfit,
               BC00053_A87ProductWholesaleProfit, BC00053_n87ProductWholesaleProfit, BC00053_A17ProductStock, BC00053_n17ProductStock, BC00053_A69ProductMiniumStock, BC00053_n69ProductMiniumStock, BC00053_A19ProductDescription, BC00053_n19ProductDescription, BC00053_A28ProductCreatedDate, BC00053_A29ProductModifiedDate,
               BC00053_A93ProductMiniumQuantityWholesale, BC00053_n93ProductMiniumQuantityWholesale, BC00053_A1BrandId, BC00053_n1BrandId, BC00053_A9SectorId, BC00053_n9SectorId, BC00053_A4SupplierId
               }
               , new Object[] {
               BC00054_A2BrandName
               }
               , new Object[] {
               BC00055_A10SectorName
               }
               , new Object[] {
               BC00056_A5SupplierName
               }
               , new Object[] {
               BC00057_A15ProductId, BC00057_A110ProductActive, BC00057_n110ProductActive, BC00057_A55ProductCode, BC00057_n55ProductCode, BC00057_A16ProductName, BC00057_A85ProductCostPrice, BC00057_n85ProductCostPrice, BC00057_A89ProductRetailProfit, BC00057_n89ProductRetailProfit,
               BC00057_A87ProductWholesaleProfit, BC00057_n87ProductWholesaleProfit, BC00057_A2BrandName, BC00057_A5SupplierName, BC00057_A10SectorName, BC00057_A17ProductStock, BC00057_n17ProductStock, BC00057_A69ProductMiniumStock, BC00057_n69ProductMiniumStock, BC00057_A19ProductDescription,
               BC00057_n19ProductDescription, BC00057_A28ProductCreatedDate, BC00057_A29ProductModifiedDate, BC00057_A93ProductMiniumQuantityWholesale, BC00057_n93ProductMiniumQuantityWholesale, BC00057_A1BrandId, BC00057_n1BrandId, BC00057_A9SectorId, BC00057_n9SectorId, BC00057_A4SupplierId
               }
               , new Object[] {
               BC00058_A16ProductName
               }
               , new Object[] {
               BC00059_A15ProductId
               }
               , new Object[] {
               BC000510_A15ProductId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000513_A2BrandName
               }
               , new Object[] {
               BC000514_A5SupplierName
               }
               , new Object[] {
               BC000515_A10SectorName
               }
               , new Object[] {
               BC000516_A20InvoiceId, BC000516_A25InvoiceDetailId
               }
               , new Object[] {
               BC000517_A50PurchaseOrderId, BC000517_A61PurchaseOrderDetailId
               }
               , new Object[] {
               BC000518_A15ProductId, BC000518_A110ProductActive, BC000518_n110ProductActive, BC000518_A55ProductCode, BC000518_n55ProductCode, BC000518_A16ProductName, BC000518_A85ProductCostPrice, BC000518_n85ProductCostPrice, BC000518_A89ProductRetailProfit, BC000518_n89ProductRetailProfit,
               BC000518_A87ProductWholesaleProfit, BC000518_n87ProductWholesaleProfit, BC000518_A2BrandName, BC000518_A5SupplierName, BC000518_A10SectorName, BC000518_A17ProductStock, BC000518_n17ProductStock, BC000518_A69ProductMiniumStock, BC000518_n69ProductMiniumStock, BC000518_A19ProductDescription,
               BC000518_n19ProductDescription, BC000518_A28ProductCreatedDate, BC000518_A29ProductModifiedDate, BC000518_A93ProductMiniumQuantityWholesale, BC000518_n93ProductMiniumQuantityWholesale, BC000518_A1BrandId, BC000518_n1BrandId, BC000518_A9SectorId, BC000518_n9SectorId, BC000518_A4SupplierId
               }
            }
         );
         AV26Pgmname = "Product_BC";
         Z87ProductWholesaleProfit = 0;
         n87ProductWholesaleProfit = false;
         A87ProductWholesaleProfit = 0;
         n87ProductWholesaleProfit = false;
         i87ProductWholesaleProfit = 0;
         n87ProductWholesaleProfit = false;
         Z89ProductRetailProfit = 0;
         n89ProductRetailProfit = false;
         A89ProductRetailProfit = 0;
         n89ProductRetailProfit = false;
         i89ProductRetailProfit = 0;
         n89ProductRetailProfit = false;
         Z93ProductMiniumQuantityWholesale = 0;
         n93ProductMiniumQuantityWholesale = false;
         A93ProductMiniumQuantityWholesale = 0;
         n93ProductMiniumQuantityWholesale = false;
         i93ProductMiniumQuantityWholesale = 0;
         n93ProductMiniumQuantityWholesale = false;
         Z69ProductMiniumStock = 0;
         n69ProductMiniumStock = false;
         A69ProductMiniumStock = 0;
         n69ProductMiniumStock = false;
         i69ProductMiniumStock = 0;
         n69ProductMiniumStock = false;
         Z17ProductStock = 0;
         n17ProductStock = false;
         A17ProductStock = 0;
         n17ProductStock = false;
         i17ProductStock = 0;
         n17ProductStock = false;
         Gx_date = DateTimeUtil.Today( context);
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12052 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Z93ProductMiniumQuantityWholesale ;
      private short A93ProductMiniumQuantityWholesale ;
      private short Gx_BScreen ;
      private short RcdFound5 ;
      private short nIsDirty_5 ;
      private short i93ProductMiniumQuantityWholesale ;
      private int trnEnded ;
      private int Z15ProductId ;
      private int A15ProductId ;
      private int Z17ProductStock ;
      private int A17ProductStock ;
      private int Z69ProductMiniumStock ;
      private int A69ProductMiniumStock ;
      private int Z1BrandId ;
      private int A1BrandId ;
      private int Z9SectorId ;
      private int A9SectorId ;
      private int Z4SupplierId ;
      private int A4SupplierId ;
      private int i17ProductStock ;
      private int i69ProductMiniumStock ;
      private decimal A85ProductCostPrice ;
      private decimal Z85ProductCostPrice ;
      private decimal Z89ProductRetailProfit ;
      private decimal A89ProductRetailProfit ;
      private decimal Z87ProductWholesaleProfit ;
      private decimal A87ProductWholesaleProfit ;
      private decimal Z90ProductRetailPrice ;
      private decimal A90ProductRetailPrice ;
      private decimal Z88ProductWholesalePrice ;
      private decimal A88ProductWholesalePrice ;
      private decimal GXt_decimal4 ;
      private decimal GXt_decimal3 ;
      private decimal GXt_decimal2 ;
      private decimal i89ProductRetailProfit ;
      private decimal i87ProductWholesaleProfit ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV26Pgmname ;
      private string sMode5 ;
      private DateTime Z28ProductCreatedDate ;
      private DateTime A28ProductCreatedDate ;
      private DateTime Z29ProductModifiedDate ;
      private DateTime A29ProductModifiedDate ;
      private DateTime Gx_date ;
      private bool returnInSub ;
      private bool AV21ProductExist ;
      private bool AV23AllOk ;
      private bool n85ProductCostPrice ;
      private bool Z110ProductActive ;
      private bool A110ProductActive ;
      private bool n110ProductActive ;
      private bool n17ProductStock ;
      private bool n69ProductMiniumStock ;
      private bool n93ProductMiniumQuantityWholesale ;
      private bool n89ProductRetailProfit ;
      private bool n87ProductWholesaleProfit ;
      private bool n55ProductCode ;
      private bool n19ProductDescription ;
      private bool n1BrandId ;
      private bool n9SectorId ;
      private bool Gx_longc ;
      private bool N110ProductActive ;
      private bool mustCommit ;
      private string AV16ProductState ;
      private string Z55ProductCode ;
      private string A55ProductCode ;
      private string Z16ProductName ;
      private string A16ProductName ;
      private string Z19ProductDescription ;
      private string A19ProductDescription ;
      private string Z2BrandName ;
      private string A2BrandName ;
      private string Z10SectorName ;
      private string A10SectorName ;
      private string Z5SupplierName ;
      private string A5SupplierName ;
      private SdtProduct bcProduct ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC00057_A15ProductId ;
      private bool[] BC00057_A110ProductActive ;
      private bool[] BC00057_n110ProductActive ;
      private string[] BC00057_A55ProductCode ;
      private bool[] BC00057_n55ProductCode ;
      private string[] BC00057_A16ProductName ;
      private decimal[] BC00057_A85ProductCostPrice ;
      private bool[] BC00057_n85ProductCostPrice ;
      private decimal[] BC00057_A89ProductRetailProfit ;
      private bool[] BC00057_n89ProductRetailProfit ;
      private decimal[] BC00057_A87ProductWholesaleProfit ;
      private bool[] BC00057_n87ProductWholesaleProfit ;
      private string[] BC00057_A2BrandName ;
      private string[] BC00057_A5SupplierName ;
      private string[] BC00057_A10SectorName ;
      private int[] BC00057_A17ProductStock ;
      private bool[] BC00057_n17ProductStock ;
      private int[] BC00057_A69ProductMiniumStock ;
      private bool[] BC00057_n69ProductMiniumStock ;
      private string[] BC00057_A19ProductDescription ;
      private bool[] BC00057_n19ProductDescription ;
      private DateTime[] BC00057_A28ProductCreatedDate ;
      private DateTime[] BC00057_A29ProductModifiedDate ;
      private short[] BC00057_A93ProductMiniumQuantityWholesale ;
      private bool[] BC00057_n93ProductMiniumQuantityWholesale ;
      private int[] BC00057_A1BrandId ;
      private bool[] BC00057_n1BrandId ;
      private int[] BC00057_A9SectorId ;
      private bool[] BC00057_n9SectorId ;
      private int[] BC00057_A4SupplierId ;
      private string[] BC00058_A16ProductName ;
      private string[] BC00054_A2BrandName ;
      private string[] BC00056_A5SupplierName ;
      private string[] BC00055_A10SectorName ;
      private int[] BC00059_A15ProductId ;
      private int[] BC00053_A15ProductId ;
      private bool[] BC00053_A110ProductActive ;
      private bool[] BC00053_n110ProductActive ;
      private string[] BC00053_A55ProductCode ;
      private bool[] BC00053_n55ProductCode ;
      private string[] BC00053_A16ProductName ;
      private decimal[] BC00053_A85ProductCostPrice ;
      private bool[] BC00053_n85ProductCostPrice ;
      private decimal[] BC00053_A89ProductRetailProfit ;
      private bool[] BC00053_n89ProductRetailProfit ;
      private decimal[] BC00053_A87ProductWholesaleProfit ;
      private bool[] BC00053_n87ProductWholesaleProfit ;
      private int[] BC00053_A17ProductStock ;
      private bool[] BC00053_n17ProductStock ;
      private int[] BC00053_A69ProductMiniumStock ;
      private bool[] BC00053_n69ProductMiniumStock ;
      private string[] BC00053_A19ProductDescription ;
      private bool[] BC00053_n19ProductDescription ;
      private DateTime[] BC00053_A28ProductCreatedDate ;
      private DateTime[] BC00053_A29ProductModifiedDate ;
      private short[] BC00053_A93ProductMiniumQuantityWholesale ;
      private bool[] BC00053_n93ProductMiniumQuantityWholesale ;
      private int[] BC00053_A1BrandId ;
      private bool[] BC00053_n1BrandId ;
      private int[] BC00053_A9SectorId ;
      private bool[] BC00053_n9SectorId ;
      private int[] BC00053_A4SupplierId ;
      private int[] BC00052_A15ProductId ;
      private bool[] BC00052_A110ProductActive ;
      private bool[] BC00052_n110ProductActive ;
      private string[] BC00052_A55ProductCode ;
      private bool[] BC00052_n55ProductCode ;
      private string[] BC00052_A16ProductName ;
      private decimal[] BC00052_A85ProductCostPrice ;
      private bool[] BC00052_n85ProductCostPrice ;
      private decimal[] BC00052_A89ProductRetailProfit ;
      private bool[] BC00052_n89ProductRetailProfit ;
      private decimal[] BC00052_A87ProductWholesaleProfit ;
      private bool[] BC00052_n87ProductWholesaleProfit ;
      private int[] BC00052_A17ProductStock ;
      private bool[] BC00052_n17ProductStock ;
      private int[] BC00052_A69ProductMiniumStock ;
      private bool[] BC00052_n69ProductMiniumStock ;
      private string[] BC00052_A19ProductDescription ;
      private bool[] BC00052_n19ProductDescription ;
      private DateTime[] BC00052_A28ProductCreatedDate ;
      private DateTime[] BC00052_A29ProductModifiedDate ;
      private short[] BC00052_A93ProductMiniumQuantityWholesale ;
      private bool[] BC00052_n93ProductMiniumQuantityWholesale ;
      private int[] BC00052_A1BrandId ;
      private bool[] BC00052_n1BrandId ;
      private int[] BC00052_A9SectorId ;
      private bool[] BC00052_n9SectorId ;
      private int[] BC00052_A4SupplierId ;
      private int[] BC000510_A15ProductId ;
      private string[] BC000513_A2BrandName ;
      private string[] BC000514_A5SupplierName ;
      private string[] BC000515_A10SectorName ;
      private int[] BC000516_A20InvoiceId ;
      private int[] BC000516_A25InvoiceDetailId ;
      private int[] BC000517_A50PurchaseOrderId ;
      private int[] BC000517_A61PurchaseOrderDetailId ;
      private int[] BC000518_A15ProductId ;
      private bool[] BC000518_A110ProductActive ;
      private bool[] BC000518_n110ProductActive ;
      private string[] BC000518_A55ProductCode ;
      private bool[] BC000518_n55ProductCode ;
      private string[] BC000518_A16ProductName ;
      private decimal[] BC000518_A85ProductCostPrice ;
      private bool[] BC000518_n85ProductCostPrice ;
      private decimal[] BC000518_A89ProductRetailProfit ;
      private bool[] BC000518_n89ProductRetailProfit ;
      private decimal[] BC000518_A87ProductWholesaleProfit ;
      private bool[] BC000518_n87ProductWholesaleProfit ;
      private string[] BC000518_A2BrandName ;
      private string[] BC000518_A5SupplierName ;
      private string[] BC000518_A10SectorName ;
      private int[] BC000518_A17ProductStock ;
      private bool[] BC000518_n17ProductStock ;
      private int[] BC000518_A69ProductMiniumStock ;
      private bool[] BC000518_n69ProductMiniumStock ;
      private string[] BC000518_A19ProductDescription ;
      private bool[] BC000518_n19ProductDescription ;
      private DateTime[] BC000518_A28ProductCreatedDate ;
      private DateTime[] BC000518_A29ProductModifiedDate ;
      private short[] BC000518_A93ProductMiniumQuantityWholesale ;
      private bool[] BC000518_n93ProductMiniumQuantityWholesale ;
      private int[] BC000518_A1BrandId ;
      private bool[] BC000518_n1BrandId ;
      private int[] BC000518_A9SectorId ;
      private bool[] BC000518_n9SectorId ;
      private int[] BC000518_A4SupplierId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV22ErrorMessages ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession GXt_SdtSDTContextSession1 ;
   }

   public class product_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[8])
         ,new UpdateCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00057;
          prmBC00057 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmBC00058;
          prmBC00058 = new Object[] {
          new ParDef("@ProductName",GXType.NVarChar,60,0) ,
          new ParDef("@SupplierId",GXType.Int32,6,0) ,
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmBC00054;
          prmBC00054 = new Object[] {
          new ParDef("@BrandId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC00056;
          prmBC00056 = new Object[] {
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          Object[] prmBC00055;
          prmBC00055 = new Object[] {
          new ParDef("@SectorId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC00059;
          prmBC00059 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmBC00053;
          prmBC00053 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmBC00052;
          prmBC00052 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmBC000510;
          prmBC000510 = new Object[] {
          new ParDef("@ProductActive",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@ProductCode",GXType.NVarChar,100,0){Nullable=true} ,
          new ParDef("@ProductName",GXType.NVarChar,60,0) ,
          new ParDef("@ProductCostPrice",GXType.Decimal,18,2){Nullable=true} ,
          new ParDef("@ProductRetailProfit",GXType.Decimal,8,2){Nullable=true} ,
          new ParDef("@ProductWholesaleProfit",GXType.Decimal,8,2){Nullable=true} ,
          new ParDef("@ProductStock",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("@ProductMiniumStock",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("@ProductDescription",GXType.NVarChar,200,0){Nullable=true} ,
          new ParDef("@ProductCreatedDate",GXType.Date,8,0) ,
          new ParDef("@ProductModifiedDate",GXType.Date,8,0) ,
          new ParDef("@ProductMiniumQuantityWholesale",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@BrandId",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("@SectorId",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          Object[] prmBC000511;
          prmBC000511 = new Object[] {
          new ParDef("@ProductActive",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@ProductCode",GXType.NVarChar,100,0){Nullable=true} ,
          new ParDef("@ProductName",GXType.NVarChar,60,0) ,
          new ParDef("@ProductCostPrice",GXType.Decimal,18,2){Nullable=true} ,
          new ParDef("@ProductRetailProfit",GXType.Decimal,8,2){Nullable=true} ,
          new ParDef("@ProductWholesaleProfit",GXType.Decimal,8,2){Nullable=true} ,
          new ParDef("@ProductStock",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("@ProductMiniumStock",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("@ProductDescription",GXType.NVarChar,200,0){Nullable=true} ,
          new ParDef("@ProductCreatedDate",GXType.Date,8,0) ,
          new ParDef("@ProductModifiedDate",GXType.Date,8,0) ,
          new ParDef("@ProductMiniumQuantityWholesale",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@BrandId",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("@SectorId",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("@SupplierId",GXType.Int32,6,0) ,
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmBC000512;
          prmBC000512 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmBC000513;
          prmBC000513 = new Object[] {
          new ParDef("@BrandId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC000514;
          prmBC000514 = new Object[] {
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          Object[] prmBC000515;
          prmBC000515 = new Object[] {
          new ParDef("@SectorId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC000516;
          prmBC000516 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmBC000517;
          prmBC000517 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmBC000518;
          prmBC000518 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00052", "SELECT [ProductId], [ProductActive], [ProductCode], [ProductName], [ProductCostPrice], [ProductRetailProfit], [ProductWholesaleProfit], [ProductStock], [ProductMiniumStock], [ProductDescription], [ProductCreatedDate], [ProductModifiedDate], [ProductMiniumQuantityWholesale], [BrandId], [SectorId], [SupplierId] FROM [Product] WITH (UPDLOCK) WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00052,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00053", "SELECT [ProductId], [ProductActive], [ProductCode], [ProductName], [ProductCostPrice], [ProductRetailProfit], [ProductWholesaleProfit], [ProductStock], [ProductMiniumStock], [ProductDescription], [ProductCreatedDate], [ProductModifiedDate], [ProductMiniumQuantityWholesale], [BrandId], [SectorId], [SupplierId] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00053,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00054", "SELECT [BrandName] FROM [Brand] WHERE [BrandId] = @BrandId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00054,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00055", "SELECT [SectorName] FROM [Sector] WHERE [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00055,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00056", "SELECT [SupplierName] FROM [Supplier] WHERE [SupplierId] = @SupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00056,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00057", "SELECT TM1.[ProductId], TM1.[ProductActive], TM1.[ProductCode], TM1.[ProductName], TM1.[ProductCostPrice], TM1.[ProductRetailProfit], TM1.[ProductWholesaleProfit], T2.[BrandName], T3.[SupplierName], T4.[SectorName], TM1.[ProductStock], TM1.[ProductMiniumStock], TM1.[ProductDescription], TM1.[ProductCreatedDate], TM1.[ProductModifiedDate], TM1.[ProductMiniumQuantityWholesale], TM1.[BrandId], TM1.[SectorId], TM1.[SupplierId] FROM ((([Product] TM1 LEFT JOIN [Brand] T2 ON T2.[BrandId] = TM1.[BrandId]) INNER JOIN [Supplier] T3 ON T3.[SupplierId] = TM1.[SupplierId]) LEFT JOIN [Sector] T4 ON T4.[SectorId] = TM1.[SectorId]) WHERE TM1.[ProductId] = @ProductId ORDER BY TM1.[ProductId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00057,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00058", "SELECT [ProductName] FROM [Product] WHERE ([ProductName] = @ProductName AND [SupplierId] = @SupplierId) AND (Not ( [ProductId] = @ProductId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00058,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00059", "SELECT [ProductId] FROM [Product] WHERE [ProductId] = @ProductId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00059,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000510", "INSERT INTO [Product]([ProductActive], [ProductCode], [ProductName], [ProductCostPrice], [ProductRetailProfit], [ProductWholesaleProfit], [ProductStock], [ProductMiniumStock], [ProductDescription], [ProductCreatedDate], [ProductModifiedDate], [ProductMiniumQuantityWholesale], [BrandId], [SectorId], [SupplierId]) VALUES(@ProductActive, @ProductCode, @ProductName, @ProductCostPrice, @ProductRetailProfit, @ProductWholesaleProfit, @ProductStock, @ProductMiniumStock, @ProductDescription, @ProductCreatedDate, @ProductModifiedDate, @ProductMiniumQuantityWholesale, @BrandId, @SectorId, @SupplierId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC000510,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000511", "UPDATE [Product] SET [ProductActive]=@ProductActive, [ProductCode]=@ProductCode, [ProductName]=@ProductName, [ProductCostPrice]=@ProductCostPrice, [ProductRetailProfit]=@ProductRetailProfit, [ProductWholesaleProfit]=@ProductWholesaleProfit, [ProductStock]=@ProductStock, [ProductMiniumStock]=@ProductMiniumStock, [ProductDescription]=@ProductDescription, [ProductCreatedDate]=@ProductCreatedDate, [ProductModifiedDate]=@ProductModifiedDate, [ProductMiniumQuantityWholesale]=@ProductMiniumQuantityWholesale, [BrandId]=@BrandId, [SectorId]=@SectorId, [SupplierId]=@SupplierId  WHERE [ProductId] = @ProductId", GxErrorMask.GX_NOMASK,prmBC000511)
             ,new CursorDef("BC000512", "DELETE FROM [Product]  WHERE [ProductId] = @ProductId", GxErrorMask.GX_NOMASK,prmBC000512)
             ,new CursorDef("BC000513", "SELECT [BrandName] FROM [Brand] WHERE [BrandId] = @BrandId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000513,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000514", "SELECT [SupplierName] FROM [Supplier] WHERE [SupplierId] = @SupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000514,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000515", "SELECT [SectorName] FROM [Sector] WHERE [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000515,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000516", "SELECT TOP 1 [InvoiceId], [InvoiceDetailId] FROM [InvoiceDetail] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000516,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000517", "SELECT TOP 1 [PurchaseOrderId], [PurchaseOrderDetailId] FROM [PurchaseOrderDetail] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000517,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000518", "SELECT TM1.[ProductId], TM1.[ProductActive], TM1.[ProductCode], TM1.[ProductName], TM1.[ProductCostPrice], TM1.[ProductRetailProfit], TM1.[ProductWholesaleProfit], T2.[BrandName], T3.[SupplierName], T4.[SectorName], TM1.[ProductStock], TM1.[ProductMiniumStock], TM1.[ProductDescription], TM1.[ProductCreatedDate], TM1.[ProductModifiedDate], TM1.[ProductMiniumQuantityWholesale], TM1.[BrandId], TM1.[SectorId], TM1.[SupplierId] FROM ((([Product] TM1 LEFT JOIN [Brand] T2 ON T2.[BrandId] = TM1.[BrandId]) INNER JOIN [Supplier] T3 ON T3.[SupplierId] = TM1.[SupplierId]) LEFT JOIN [Sector] T4 ON T4.[SectorId] = TM1.[SectorId]) WHERE TM1.[ProductId] = @ProductId ORDER BY TM1.[ProductId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000518,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((int[]) buf[12])[0] = rslt.getInt(8);
                ((bool[]) buf[13])[0] = rslt.wasNull(8);
                ((int[]) buf[14])[0] = rslt.getInt(9);
                ((bool[]) buf[15])[0] = rslt.wasNull(9);
                ((string[]) buf[16])[0] = rslt.getVarchar(10);
                ((bool[]) buf[17])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[18])[0] = rslt.getGXDate(11);
                ((DateTime[]) buf[19])[0] = rslt.getGXDate(12);
                ((short[]) buf[20])[0] = rslt.getShort(13);
                ((bool[]) buf[21])[0] = rslt.wasNull(13);
                ((int[]) buf[22])[0] = rslt.getInt(14);
                ((bool[]) buf[23])[0] = rslt.wasNull(14);
                ((int[]) buf[24])[0] = rslt.getInt(15);
                ((bool[]) buf[25])[0] = rslt.wasNull(15);
                ((int[]) buf[26])[0] = rslt.getInt(16);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((int[]) buf[12])[0] = rslt.getInt(8);
                ((bool[]) buf[13])[0] = rslt.wasNull(8);
                ((int[]) buf[14])[0] = rslt.getInt(9);
                ((bool[]) buf[15])[0] = rslt.wasNull(9);
                ((string[]) buf[16])[0] = rslt.getVarchar(10);
                ((bool[]) buf[17])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[18])[0] = rslt.getGXDate(11);
                ((DateTime[]) buf[19])[0] = rslt.getGXDate(12);
                ((short[]) buf[20])[0] = rslt.getShort(13);
                ((bool[]) buf[21])[0] = rslt.wasNull(13);
                ((int[]) buf[22])[0] = rslt.getInt(14);
                ((bool[]) buf[23])[0] = rslt.wasNull(14);
                ((int[]) buf[24])[0] = rslt.getInt(15);
                ((bool[]) buf[25])[0] = rslt.wasNull(15);
                ((int[]) buf[26])[0] = rslt.getInt(16);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((string[]) buf[12])[0] = rslt.getVarchar(8);
                ((string[]) buf[13])[0] = rslt.getVarchar(9);
                ((string[]) buf[14])[0] = rslt.getVarchar(10);
                ((int[]) buf[15])[0] = rslt.getInt(11);
                ((bool[]) buf[16])[0] = rslt.wasNull(11);
                ((int[]) buf[17])[0] = rslt.getInt(12);
                ((bool[]) buf[18])[0] = rslt.wasNull(12);
                ((string[]) buf[19])[0] = rslt.getVarchar(13);
                ((bool[]) buf[20])[0] = rslt.wasNull(13);
                ((DateTime[]) buf[21])[0] = rslt.getGXDate(14);
                ((DateTime[]) buf[22])[0] = rslt.getGXDate(15);
                ((short[]) buf[23])[0] = rslt.getShort(16);
                ((bool[]) buf[24])[0] = rslt.wasNull(16);
                ((int[]) buf[25])[0] = rslt.getInt(17);
                ((bool[]) buf[26])[0] = rslt.wasNull(17);
                ((int[]) buf[27])[0] = rslt.getInt(18);
                ((bool[]) buf[28])[0] = rslt.wasNull(18);
                ((int[]) buf[29])[0] = rslt.getInt(19);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 12 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 13 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 14 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 15 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 16 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((string[]) buf[12])[0] = rslt.getVarchar(8);
                ((string[]) buf[13])[0] = rslt.getVarchar(9);
                ((string[]) buf[14])[0] = rslt.getVarchar(10);
                ((int[]) buf[15])[0] = rslt.getInt(11);
                ((bool[]) buf[16])[0] = rslt.wasNull(11);
                ((int[]) buf[17])[0] = rslt.getInt(12);
                ((bool[]) buf[18])[0] = rslt.wasNull(12);
                ((string[]) buf[19])[0] = rslt.getVarchar(13);
                ((bool[]) buf[20])[0] = rslt.wasNull(13);
                ((DateTime[]) buf[21])[0] = rslt.getGXDate(14);
                ((DateTime[]) buf[22])[0] = rslt.getGXDate(15);
                ((short[]) buf[23])[0] = rslt.getShort(16);
                ((bool[]) buf[24])[0] = rslt.wasNull(16);
                ((int[]) buf[25])[0] = rslt.getInt(17);
                ((bool[]) buf[26])[0] = rslt.wasNull(17);
                ((int[]) buf[27])[0] = rslt.getInt(18);
                ((bool[]) buf[28])[0] = rslt.wasNull(18);
                ((int[]) buf[29])[0] = rslt.getInt(19);
                return;
       }
    }

 }

}
