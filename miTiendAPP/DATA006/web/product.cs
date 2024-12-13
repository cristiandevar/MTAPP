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
   public class product : GXDataArea
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetFirstPar( "Mode");
         gxfirstwebparm_bkp = gxfirstwebparm;
         gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            dyncall( GetNextPar( )) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action34") == 0 )
         {
            A85ProductCostPrice = NumberUtil.Val( GetPar( "ProductCostPrice"), ".");
            n85ProductCostPrice = false;
            AssignAttri("", false, "A85ProductCostPrice", StringUtil.LTrimStr( A85ProductCostPrice, 18, 2));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_34_055( A85ProductCostPrice) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"BRANDID") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXDLABRANDID055( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"SUPPLIERID") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXDLASUPPLIERID055( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"SECTORID") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GXDLASECTORID055( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel6"+"_"+"PRODUCTRETAILPRICE") == 0 )
         {
            A89ProductRetailProfit = NumberUtil.Val( GetPar( "ProductRetailProfit"), ".");
            n89ProductRetailProfit = false;
            AssignAttri("", false, "A89ProductRetailProfit", StringUtil.LTrimStr( A89ProductRetailProfit, 8, 2));
            A85ProductCostPrice = NumberUtil.Val( GetPar( "ProductCostPrice"), ".");
            n85ProductCostPrice = false;
            AssignAttri("", false, "A85ProductCostPrice", StringUtil.LTrimStr( A85ProductCostPrice, 18, 2));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX6ASAPRODUCTRETAILPRICE055( A89ProductRetailProfit, A85ProductCostPrice) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel7"+"_"+"PRODUCTWHOLESALEPRICE") == 0 )
         {
            A87ProductWholesaleProfit = NumberUtil.Val( GetPar( "ProductWholesaleProfit"), ".");
            n87ProductWholesaleProfit = false;
            AssignAttri("", false, "A87ProductWholesaleProfit", StringUtil.LTrimStr( A87ProductWholesaleProfit, 8, 2));
            A85ProductCostPrice = NumberUtil.Val( GetPar( "ProductCostPrice"), ".");
            n85ProductCostPrice = false;
            AssignAttri("", false, "A85ProductCostPrice", StringUtil.LTrimStr( A85ProductCostPrice, 18, 2));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX7ASAPRODUCTWHOLESALEPRICE055( A87ProductWholesaleProfit, A85ProductCostPrice) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_37") == 0 )
         {
            A1BrandId = (int)(Math.Round(NumberUtil.Val( GetPar( "BrandId"), "."), 18, MidpointRounding.ToEven));
            n1BrandId = false;
            AssignAttri("", false, "A1BrandId", StringUtil.LTrimStr( (decimal)(A1BrandId), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_37( A1BrandId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_39") == 0 )
         {
            A4SupplierId = (int)(Math.Round(NumberUtil.Val( GetPar( "SupplierId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A4SupplierId", StringUtil.LTrimStr( (decimal)(A4SupplierId), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_39( A4SupplierId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_38") == 0 )
         {
            A9SectorId = (int)(Math.Round(NumberUtil.Val( GetPar( "SectorId"), "."), 18, MidpointRounding.ToEven));
            n9SectorId = false;
            AssignAttri("", false, "A9SectorId", StringUtil.LTrimStr( (decimal)(A9SectorId), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_38( A9SectorId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
         {
            setAjaxEventMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else
         {
            if ( ! IsValidAjaxCall( false) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = gxfirstwebparm_bkp;
         }
         if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            Gx_mode = gxfirstwebparm;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
            {
               AV15ProductId = (int)(Math.Round(NumberUtil.Val( GetPar( "ProductId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV15ProductId", StringUtil.LTrimStr( (decimal)(AV15ProductId), 6, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vPRODUCTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15ProductId), "ZZZZZ9"), context));
            }
         }
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_web_controls( ) ;
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_2-169539", 0) ;
            }
            Form.Meta.addItem("description", "Product", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtProductCode_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("mtaKB", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public product( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public product( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_ProductId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV15ProductId = aP1_ProductId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynBrandId = new GXCombobox();
         dynSupplierId = new GXCombobox();
         dynSectorId = new GXCombobox();
         cmbavProductstate = new GXCombobox();
         chkavProductexist = new GXCheckbox();
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("general.ui.masterunanimosidebar", "GeneXus.Programs.general.ui.masterunanimosidebar", new Object[] {context});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynBrandId.ItemCount > 0 )
         {
            A1BrandId = (int)(Math.Round(NumberUtil.Val( dynBrandId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1BrandId), 6, 0))), "."), 18, MidpointRounding.ToEven));
            n1BrandId = false;
            AssignAttri("", false, "A1BrandId", StringUtil.LTrimStr( (decimal)(A1BrandId), 6, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynBrandId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1BrandId), 6, 0));
            AssignProp("", false, dynBrandId_Internalname, "Values", dynBrandId.ToJavascriptSource(), true);
         }
         if ( dynSupplierId.ItemCount > 0 )
         {
            A4SupplierId = (int)(Math.Round(NumberUtil.Val( dynSupplierId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A4SupplierId), 6, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A4SupplierId", StringUtil.LTrimStr( (decimal)(A4SupplierId), 6, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynSupplierId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A4SupplierId), 6, 0));
            AssignProp("", false, dynSupplierId_Internalname, "Values", dynSupplierId.ToJavascriptSource(), true);
         }
         if ( dynSectorId.ItemCount > 0 )
         {
            A9SectorId = (int)(Math.Round(NumberUtil.Val( dynSectorId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A9SectorId), 6, 0))), "."), 18, MidpointRounding.ToEven));
            n9SectorId = false;
            AssignAttri("", false, "A9SectorId", StringUtil.LTrimStr( (decimal)(A9SectorId), 6, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynSectorId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A9SectorId), 6, 0));
            AssignProp("", false, dynSectorId_Internalname, "Values", dynSectorId.ToJavascriptSource(), true);
         }
         if ( cmbavProductstate.ItemCount > 0 )
         {
            AV16ProductState = cmbavProductstate.getValidValue(AV16ProductState);
            AssignAttri("", false, "AV16ProductState", AV16ProductState);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavProductstate.CurrentValue = StringUtil.RTrim( AV16ProductState);
            AssignProp("", false, cmbavProductstate_Internalname, "Values", cmbavProductstate.ToJavascriptSource(), true);
         }
         AV21ProductExist = StringUtil.StrToBool( StringUtil.BoolToStr( AV21ProductExist));
         AssignAttri("", false, "AV21ProductExist", AV21ProductExist);
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "title-container", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Product", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "form-container", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 form__toolbar-cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-first";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductCode_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductCode_Internalname, "Code", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductCode_Internalname, A55ProductCode, StringUtil.RTrim( context.localUtil.Format( A55ProductCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductCode_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductCode_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "GeneXusUnanimo\\Code", "left", true, "", "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductName_Internalname, "Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductName_Internalname, A16ProductName, StringUtil.RTrim( context.localUtil.Format( A16ProductName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductName_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Name", "left", true, "", "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductCostPrice_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductCostPrice_Internalname, "Cost Price", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductCostPrice_Internalname, StringUtil.LTrim( StringUtil.NToC( A85ProductCostPrice, 18, 2, ".", "")), StringUtil.LTrim( ((edtProductCostPrice_Enabled!=0) ? context.localUtil.Format( A85ProductCostPrice, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A85ProductCostPrice, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductCostPrice_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductCostPrice_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Price", "right", false, "", "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductRetailProfit_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductRetailProfit_Internalname, "Retail Profit", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductRetailProfit_Internalname, StringUtil.LTrim( StringUtil.NToC( A89ProductRetailProfit, 8, 2, ".", "")), StringUtil.LTrim( ((edtProductRetailProfit_Enabled!=0) ? context.localUtil.Format( A89ProductRetailProfit, "ZZZZ9.99") : context.localUtil.Format( A89ProductRetailProfit, "ZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductRetailProfit_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductRetailProfit_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "Percentage", "right", false, "", "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductRetailPrice_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductRetailPrice_Internalname, "Retail Price", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtProductRetailPrice_Internalname, StringUtil.LTrim( StringUtil.NToC( A90ProductRetailPrice, 18, 2, ".", "")), StringUtil.LTrim( ((edtProductRetailPrice_Enabled!=0) ? context.localUtil.Format( A90ProductRetailPrice, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A90ProductRetailPrice, "ZZZZZZZZZZZZZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductRetailPrice_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductRetailPrice_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Price", "right", false, "", "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductMiniumQuantityWholesale_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductMiniumQuantityWholesale_Internalname, "Min. Qty. Wholesale", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductMiniumQuantityWholesale_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A93ProductMiniumQuantityWholesale), 4, 0, ".", "")), StringUtil.LTrim( ((edtProductMiniumQuantityWholesale_Enabled!=0) ? context.localUtil.Format( (decimal)(A93ProductMiniumQuantityWholesale), "ZZZ9") : context.localUtil.Format( (decimal)(A93ProductMiniumQuantityWholesale), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductMiniumQuantityWholesale_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductMiniumQuantityWholesale_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductWholesaleProfit_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductWholesaleProfit_Internalname, "Wholesale Profit", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductWholesaleProfit_Internalname, StringUtil.LTrim( StringUtil.NToC( A87ProductWholesaleProfit, 8, 2, ".", "")), StringUtil.LTrim( ((edtProductWholesaleProfit_Enabled!=0) ? context.localUtil.Format( A87ProductWholesaleProfit, "ZZZZ9.99") : context.localUtil.Format( A87ProductWholesaleProfit, "ZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductWholesaleProfit_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductWholesaleProfit_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "Percentage", "right", false, "", "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductWholesalePrice_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductWholesalePrice_Internalname, "Wholesale Price", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtProductWholesalePrice_Internalname, StringUtil.LTrim( StringUtil.NToC( A88ProductWholesalePrice, 18, 2, ".", "")), StringUtil.LTrim( ((edtProductWholesalePrice_Enabled!=0) ? context.localUtil.Format( A88ProductWholesalePrice, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A88ProductWholesalePrice, "ZZZZZZZZZZZZZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductWholesalePrice_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductWholesalePrice_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Price", "right", false, "", "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynBrandId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynBrandId_Internalname, "Brand", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynBrandId, dynBrandId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A1BrandId), 6, 0)), 1, dynBrandId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynBrandId.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "", true, 0, "HLP_Product.htm");
         dynBrandId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1BrandId), 6, 0));
         AssignProp("", false, dynBrandId_Internalname, "Values", (string)(dynBrandId.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynSupplierId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynSupplierId_Internalname, "Supplier", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynSupplierId, dynSupplierId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A4SupplierId), 6, 0)), 1, dynSupplierId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynSupplierId.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "", true, 0, "HLP_Product.htm");
         dynSupplierId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A4SupplierId), 6, 0));
         AssignProp("", false, dynSupplierId_Internalname, "Values", (string)(dynSupplierId.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynSectorId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynSectorId_Internalname, "Sector", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynSectorId, dynSectorId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A9SectorId), 6, 0)), 1, dynSectorId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynSectorId.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "", true, 0, "HLP_Product.htm");
         dynSectorId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A9SectorId), 6, 0));
         AssignProp("", false, dynSectorId_Internalname, "Values", (string)(dynSectorId.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductStock_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductStock_Internalname, "Stock", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductStock_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A17ProductStock), 6, 0, ".", "")), StringUtil.LTrim( ((edtProductStock_Enabled!=0) ? context.localUtil.Format( (decimal)(A17ProductStock), "ZZZZZ9") : context.localUtil.Format( (decimal)(A17ProductStock), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductStock_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductStock_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Stock", "right", false, "", "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductMiniumStock_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductMiniumStock_Internalname, "Minium Stock", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductMiniumStock_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A69ProductMiniumStock), 6, 0, ".", "")), StringUtil.LTrim( ((edtProductMiniumStock_Enabled!=0) ? context.localUtil.Format( (decimal)(A69ProductMiniumStock), "ZZZZZ9") : context.localUtil.Format( (decimal)(A69ProductMiniumStock), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,94);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductMiniumStock_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductMiniumStock_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Stock", "right", false, "", "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductDescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductDescription_Internalname, "Description", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtProductDescription_Internalname, A19ProductDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,99);\"", 0, 1, edtProductDescription_Enabled, 1, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "GeneXusUnanimo\\Description", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavProductstate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbavProductstate_Internalname, "State", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbavProductstate, cmbavProductstate_Internalname, StringUtil.RTrim( AV16ProductState), 1, cmbavProductstate_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavProductstate.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", "", "", true, 0, "HLP_Product.htm");
         cmbavProductstate.CurrentValue = StringUtil.RTrim( AV16ProductState);
         AssignProp("", false, cmbavProductstate_Internalname, "Values", (string)(cmbavProductstate.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavProductexist_Internalname+"\"", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkavProductexist_Internalname, StringUtil.BoolToStr( AV21ProductExist), "", "", 1, chkavProductexist.Enabled, "true", "", StyleString, ClassString, "", "", "");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__actions--fixed", "Right", "Middle", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Deactive", bttBtn_delete_Jsonclick, 5, "Deactive Product", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "Right", "Middle", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11052 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z15ProductId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z15ProductId"), ".", ","), 18, MidpointRounding.ToEven));
               Z110ProductActive = StringUtil.StrToBool( cgiGet( "Z110ProductActive"));
               n110ProductActive = ((false==A110ProductActive) ? true : false);
               Z55ProductCode = cgiGet( "Z55ProductCode");
               n55ProductCode = (String.IsNullOrEmpty(StringUtil.RTrim( A55ProductCode)) ? true : false);
               Z16ProductName = cgiGet( "Z16ProductName");
               Z85ProductCostPrice = context.localUtil.CToN( cgiGet( "Z85ProductCostPrice"), ".", ",");
               n85ProductCostPrice = ((Convert.ToDecimal(0)==A85ProductCostPrice) ? true : false);
               Z89ProductRetailProfit = context.localUtil.CToN( cgiGet( "Z89ProductRetailProfit"), ".", ",");
               n89ProductRetailProfit = ((Convert.ToDecimal(0)==A89ProductRetailProfit) ? true : false);
               Z87ProductWholesaleProfit = context.localUtil.CToN( cgiGet( "Z87ProductWholesaleProfit"), ".", ",");
               n87ProductWholesaleProfit = ((Convert.ToDecimal(0)==A87ProductWholesaleProfit) ? true : false);
               Z17ProductStock = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z17ProductStock"), ".", ","), 18, MidpointRounding.ToEven));
               n17ProductStock = ((0==A17ProductStock) ? true : false);
               Z69ProductMiniumStock = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z69ProductMiniumStock"), ".", ","), 18, MidpointRounding.ToEven));
               n69ProductMiniumStock = ((0==A69ProductMiniumStock) ? true : false);
               Z19ProductDescription = cgiGet( "Z19ProductDescription");
               n19ProductDescription = (String.IsNullOrEmpty(StringUtil.RTrim( A19ProductDescription)) ? true : false);
               Z28ProductCreatedDate = context.localUtil.CToD( cgiGet( "Z28ProductCreatedDate"), 0);
               Z29ProductModifiedDate = context.localUtil.CToD( cgiGet( "Z29ProductModifiedDate"), 0);
               Z93ProductMiniumQuantityWholesale = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z93ProductMiniumQuantityWholesale"), ".", ","), 18, MidpointRounding.ToEven));
               n93ProductMiniumQuantityWholesale = ((0==A93ProductMiniumQuantityWholesale) ? true : false);
               Z1BrandId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z1BrandId"), ".", ","), 18, MidpointRounding.ToEven));
               n1BrandId = ((0==A1BrandId) ? true : false);
               Z9SectorId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z9SectorId"), ".", ","), 18, MidpointRounding.ToEven));
               n9SectorId = ((0==A9SectorId) ? true : false);
               Z4SupplierId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z4SupplierId"), ".", ","), 18, MidpointRounding.ToEven));
               A110ProductActive = StringUtil.StrToBool( cgiGet( "Z110ProductActive"));
               n110ProductActive = false;
               n110ProductActive = ((false==A110ProductActive) ? true : false);
               A28ProductCreatedDate = context.localUtil.CToD( cgiGet( "Z28ProductCreatedDate"), 0);
               A29ProductModifiedDate = context.localUtil.CToD( cgiGet( "Z29ProductModifiedDate"), 0);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N1BrandId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N1BrandId"), ".", ","), 18, MidpointRounding.ToEven));
               n1BrandId = ((0==A1BrandId) ? true : false);
               N4SupplierId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N4SupplierId"), ".", ","), 18, MidpointRounding.ToEven));
               N9SectorId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N9SectorId"), ".", ","), 18, MidpointRounding.ToEven));
               n9SectorId = ((0==A9SectorId) ? true : false);
               AV15ProductId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vPRODUCTID"), ".", ","), 18, MidpointRounding.ToEven));
               A15ProductId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTID"), ".", ","), 18, MidpointRounding.ToEven));
               AV11Insert_BrandId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_BRANDID"), ".", ","), 18, MidpointRounding.ToEven));
               AV13Insert_SupplierId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_SUPPLIERID"), ".", ","), 18, MidpointRounding.ToEven));
               AV12Insert_SectorId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_SECTORID"), ".", ","), 18, MidpointRounding.ToEven));
               A110ProductActive = StringUtil.StrToBool( cgiGet( "PRODUCTACTIVE"));
               n110ProductActive = ((false==A110ProductActive) ? true : false);
               Gx_date = context.localUtil.CToD( cgiGet( "vTODAY"), 0);
               A28ProductCreatedDate = context.localUtil.CToD( cgiGet( "PRODUCTCREATEDDATE"), 0);
               A29ProductModifiedDate = context.localUtil.CToD( cgiGet( "PRODUCTMODIFIEDDATE"), 0);
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","), 18, MidpointRounding.ToEven));
               A2BrandName = cgiGet( "BRANDNAME");
               A10SectorName = cgiGet( "SECTORNAME");
               A5SupplierName = cgiGet( "SUPPLIERNAME");
               AV26Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A55ProductCode = cgiGet( edtProductCode_Internalname);
               n55ProductCode = false;
               AssignAttri("", false, "A55ProductCode", A55ProductCode);
               n55ProductCode = (String.IsNullOrEmpty(StringUtil.RTrim( A55ProductCode)) ? true : false);
               A16ProductName = cgiGet( edtProductName_Internalname);
               AssignAttri("", false, "A16ProductName", A16ProductName);
               if ( ( ( context.localUtil.CToN( cgiGet( edtProductCostPrice_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProductCostPrice_Internalname), ".", ",") > 999999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODUCTCOSTPRICE");
                  AnyError = 1;
                  GX_FocusControl = edtProductCostPrice_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A85ProductCostPrice = 0;
                  n85ProductCostPrice = false;
                  AssignAttri("", false, "A85ProductCostPrice", StringUtil.LTrimStr( A85ProductCostPrice, 18, 2));
               }
               else
               {
                  A85ProductCostPrice = context.localUtil.CToN( cgiGet( edtProductCostPrice_Internalname), ".", ",");
                  n85ProductCostPrice = false;
                  AssignAttri("", false, "A85ProductCostPrice", StringUtil.LTrimStr( A85ProductCostPrice, 18, 2));
               }
               n85ProductCostPrice = ((Convert.ToDecimal(0)==A85ProductCostPrice) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtProductRetailProfit_Internalname), ".", ",") < -9999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtProductRetailProfit_Internalname), ".", ",") > 99999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODUCTRETAILPROFIT");
                  AnyError = 1;
                  GX_FocusControl = edtProductRetailProfit_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A89ProductRetailProfit = 0;
                  n89ProductRetailProfit = false;
                  AssignAttri("", false, "A89ProductRetailProfit", StringUtil.LTrimStr( A89ProductRetailProfit, 8, 2));
               }
               else
               {
                  A89ProductRetailProfit = context.localUtil.CToN( cgiGet( edtProductRetailProfit_Internalname), ".", ",");
                  n89ProductRetailProfit = false;
                  AssignAttri("", false, "A89ProductRetailProfit", StringUtil.LTrimStr( A89ProductRetailProfit, 8, 2));
               }
               n89ProductRetailProfit = ((Convert.ToDecimal(0)==A89ProductRetailProfit) ? true : false);
               A90ProductRetailPrice = context.localUtil.CToN( cgiGet( edtProductRetailPrice_Internalname), ".", ",");
               AssignAttri("", false, "A90ProductRetailPrice", StringUtil.LTrimStr( A90ProductRetailPrice, 18, 2));
               if ( ( ( context.localUtil.CToN( cgiGet( edtProductMiniumQuantityWholesale_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProductMiniumQuantityWholesale_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODUCTMINIUMQUANTITYWHOLESALE");
                  AnyError = 1;
                  GX_FocusControl = edtProductMiniumQuantityWholesale_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A93ProductMiniumQuantityWholesale = 0;
                  n93ProductMiniumQuantityWholesale = false;
                  AssignAttri("", false, "A93ProductMiniumQuantityWholesale", StringUtil.LTrimStr( (decimal)(A93ProductMiniumQuantityWholesale), 4, 0));
               }
               else
               {
                  A93ProductMiniumQuantityWholesale = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtProductMiniumQuantityWholesale_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  n93ProductMiniumQuantityWholesale = false;
                  AssignAttri("", false, "A93ProductMiniumQuantityWholesale", StringUtil.LTrimStr( (decimal)(A93ProductMiniumQuantityWholesale), 4, 0));
               }
               n93ProductMiniumQuantityWholesale = ((0==A93ProductMiniumQuantityWholesale) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtProductWholesaleProfit_Internalname), ".", ",") < -9999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtProductWholesaleProfit_Internalname), ".", ",") > 99999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODUCTWHOLESALEPROFIT");
                  AnyError = 1;
                  GX_FocusControl = edtProductWholesaleProfit_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A87ProductWholesaleProfit = 0;
                  n87ProductWholesaleProfit = false;
                  AssignAttri("", false, "A87ProductWholesaleProfit", StringUtil.LTrimStr( A87ProductWholesaleProfit, 8, 2));
               }
               else
               {
                  A87ProductWholesaleProfit = context.localUtil.CToN( cgiGet( edtProductWholesaleProfit_Internalname), ".", ",");
                  n87ProductWholesaleProfit = false;
                  AssignAttri("", false, "A87ProductWholesaleProfit", StringUtil.LTrimStr( A87ProductWholesaleProfit, 8, 2));
               }
               n87ProductWholesaleProfit = ((Convert.ToDecimal(0)==A87ProductWholesaleProfit) ? true : false);
               A88ProductWholesalePrice = context.localUtil.CToN( cgiGet( edtProductWholesalePrice_Internalname), ".", ",");
               AssignAttri("", false, "A88ProductWholesalePrice", StringUtil.LTrimStr( A88ProductWholesalePrice, 18, 2));
               dynBrandId.CurrentValue = cgiGet( dynBrandId_Internalname);
               A1BrandId = (int)(Math.Round(NumberUtil.Val( cgiGet( dynBrandId_Internalname), "."), 18, MidpointRounding.ToEven));
               n1BrandId = false;
               AssignAttri("", false, "A1BrandId", StringUtil.LTrimStr( (decimal)(A1BrandId), 6, 0));
               n1BrandId = ((0==A1BrandId) ? true : false);
               dynSupplierId.CurrentValue = cgiGet( dynSupplierId_Internalname);
               A4SupplierId = (int)(Math.Round(NumberUtil.Val( cgiGet( dynSupplierId_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A4SupplierId", StringUtil.LTrimStr( (decimal)(A4SupplierId), 6, 0));
               dynSectorId.CurrentValue = cgiGet( dynSectorId_Internalname);
               A9SectorId = (int)(Math.Round(NumberUtil.Val( cgiGet( dynSectorId_Internalname), "."), 18, MidpointRounding.ToEven));
               n9SectorId = false;
               AssignAttri("", false, "A9SectorId", StringUtil.LTrimStr( (decimal)(A9SectorId), 6, 0));
               n9SectorId = ((0==A9SectorId) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtProductStock_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProductStock_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODUCTSTOCK");
                  AnyError = 1;
                  GX_FocusControl = edtProductStock_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A17ProductStock = 0;
                  n17ProductStock = false;
                  AssignAttri("", false, "A17ProductStock", StringUtil.LTrimStr( (decimal)(A17ProductStock), 6, 0));
               }
               else
               {
                  A17ProductStock = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtProductStock_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  n17ProductStock = false;
                  AssignAttri("", false, "A17ProductStock", StringUtil.LTrimStr( (decimal)(A17ProductStock), 6, 0));
               }
               n17ProductStock = ((0==A17ProductStock) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtProductMiniumStock_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProductMiniumStock_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODUCTMINIUMSTOCK");
                  AnyError = 1;
                  GX_FocusControl = edtProductMiniumStock_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A69ProductMiniumStock = 0;
                  n69ProductMiniumStock = false;
                  AssignAttri("", false, "A69ProductMiniumStock", StringUtil.LTrimStr( (decimal)(A69ProductMiniumStock), 6, 0));
               }
               else
               {
                  A69ProductMiniumStock = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtProductMiniumStock_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  n69ProductMiniumStock = false;
                  AssignAttri("", false, "A69ProductMiniumStock", StringUtil.LTrimStr( (decimal)(A69ProductMiniumStock), 6, 0));
               }
               n69ProductMiniumStock = ((0==A69ProductMiniumStock) ? true : false);
               A19ProductDescription = cgiGet( edtProductDescription_Internalname);
               n19ProductDescription = false;
               AssignAttri("", false, "A19ProductDescription", A19ProductDescription);
               n19ProductDescription = (String.IsNullOrEmpty(StringUtil.RTrim( A19ProductDescription)) ? true : false);
               cmbavProductstate.CurrentValue = cgiGet( cmbavProductstate_Internalname);
               AV16ProductState = cgiGet( cmbavProductstate_Internalname);
               AssignAttri("", false, "AV16ProductState", AV16ProductState);
               AV21ProductExist = StringUtil.StrToBool( cgiGet( chkavProductexist_Internalname));
               AssignAttri("", false, "AV21ProductExist", AV21ProductExist);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Product");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("ProductId", context.localUtil.Format( (decimal)(A15ProductId), "ZZZZZ9"));
               forbiddenHiddens.Add("ProductCreatedDate", context.localUtil.Format(A28ProductCreatedDate, "99/99/9999"));
               forbiddenHiddens.Add("ProductModifiedDate", context.localUtil.Format(A29ProductModifiedDate, "99/99/9999"));
               hsh = cgiGet( "hsh");
               if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("product:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A15ProductId = (int)(Math.Round(NumberUtil.Val( GetPar( "ProductId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A15ProductId", StringUtil.LTrimStr( (decimal)(A15ProductId), 6, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode5 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode5;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound5 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_050( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
            sEvt = cgiGet( "_EventName");
            EvtGridId = cgiGet( "_EventGridId");
            EvtRowId = cgiGet( "_EventRowId");
            if ( StringUtil.Len( sEvt) > 0 )
            {
               sEvtType = StringUtil.Left( sEvt, 1);
               sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
               if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
               {
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E11052 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12052 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "PRODUCTCODE.CONTROLVALUECHANGED") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           E13052 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "PRODUCTCOSTPRICE.CONTROLVALUECHANGED") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           E14052 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                     }
                     else
                     {
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
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
            E12052 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll055( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
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

      protected void disable_std_buttons( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtn_delete_Visible = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtn_enter_Visible = 0;
               AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
            }
            DisableAttributes055( ) ;
         }
         AssignProp("", false, cmbavProductstate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavProductstate.Enabled), 5, 0), true);
         AssignProp("", false, chkavProductexist_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavProductexist.Enabled), 5, 0), true);
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
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
               CloseExtendedTableCursors055( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption050( )
      {
      }

      protected void E11052( )
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
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV26Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV26Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         AV11Insert_BrandId = 0;
         AssignAttri("", false, "AV11Insert_BrandId", StringUtil.LTrimStr( (decimal)(AV11Insert_BrandId), 6, 0));
         AV13Insert_SupplierId = 0;
         AssignAttri("", false, "AV13Insert_SupplierId", StringUtil.LTrimStr( (decimal)(AV13Insert_SupplierId), 6, 0));
         AV12Insert_SectorId = 0;
         AssignAttri("", false, "AV12Insert_SectorId", StringUtil.LTrimStr( (decimal)(AV12Insert_SectorId), 6, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV26Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV27GXV1 = 1;
            AssignAttri("", false, "AV27GXV1", StringUtil.LTrimStr( (decimal)(AV27GXV1), 8, 0));
            while ( AV27GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((GeneXus.Programs.general.ui.SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV27GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "BrandId") == 0 )
               {
                  AV11Insert_BrandId = (int)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_BrandId", StringUtil.LTrimStr( (decimal)(AV11Insert_BrandId), 6, 0));
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "SupplierId") == 0 )
               {
                  AV13Insert_SupplierId = (int)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13Insert_SupplierId", StringUtil.LTrimStr( (decimal)(AV13Insert_SupplierId), 6, 0));
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "SectorId") == 0 )
               {
                  AV12Insert_SectorId = (int)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV12Insert_SectorId", StringUtil.LTrimStr( (decimal)(AV12Insert_SectorId), 6, 0));
               }
               AV27GXV1 = (int)(AV27GXV1+1);
               AssignAttri("", false, "AV27GXV1", StringUtil.LTrimStr( (decimal)(AV27GXV1), 8, 0));
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV16ProductState = "Active";
            AssignAttri("", false, "AV16ProductState", AV16ProductState);
         }
      }

      protected void E12052( )
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
            AssignAttri("", false, "A85ProductCostPrice", StringUtil.LTrimStr( A85ProductCostPrice, 18, 2));
            n85ProductCostPrice = ((Convert.ToDecimal(0)==A85ProductCostPrice) ? true : false);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwproduct.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ErrorMessages", AV22ErrorMessages);
      }

      protected void E13052( )
      {
         /* ProductCode_Controlvaluechanged Routine */
         returnInSub = false;
         AV21ProductExist = false;
         AssignAttri("", false, "AV21ProductExist", AV21ProductExist);
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A55ProductCode)) || T00053_n55ProductCode[0] ) )
         {
            if ( new productexistwithcode(context).executeUdp(  A55ProductCode, out  AV18ProductIdAux) )
            {
               GX_msglist.addItem("Already exist a product with this code, ");
               AV21ProductExist = true;
               AssignAttri("", false, "AV21ProductExist", AV21ProductExist);
               new productgetdatacode(context ).execute(  A55ProductCode, out  A16ProductName, ref  A85ProductCostPrice, ref  A89ProductRetailProfit, ref  A93ProductMiniumQuantityWholesale, ref  A87ProductWholesaleProfit, ref  A1BrandId, ref  A9SectorId, ref  A69ProductMiniumStock, ref  A19ProductDescription) ;
               AssignAttri("", false, "A16ProductName", A16ProductName);
               AssignAttri("", false, "A85ProductCostPrice", StringUtil.LTrimStr( A85ProductCostPrice, 18, 2));
               AssignAttri("", false, "A89ProductRetailProfit", StringUtil.LTrimStr( A89ProductRetailProfit, 8, 2));
               AssignAttri("", false, "A93ProductMiniumQuantityWholesale", StringUtil.LTrimStr( (decimal)(A93ProductMiniumQuantityWholesale), 4, 0));
               AssignAttri("", false, "A87ProductWholesaleProfit", StringUtil.LTrimStr( A87ProductWholesaleProfit, 8, 2));
               AssignAttri("", false, "A1BrandId", StringUtil.LTrimStr( (decimal)(A1BrandId), 6, 0));
               AssignAttri("", false, "A9SectorId", StringUtil.LTrimStr( (decimal)(A9SectorId), 6, 0));
               AssignAttri("", false, "A69ProductMiniumStock", StringUtil.LTrimStr( (decimal)(A69ProductMiniumStock), 6, 0));
               AssignAttri("", false, "A19ProductDescription", A19ProductDescription);
               n85ProductCostPrice = ((Convert.ToDecimal(0)==A85ProductCostPrice) ? true : false);
               n89ProductRetailProfit = ((Convert.ToDecimal(0)==A89ProductRetailProfit) ? true : false);
               n93ProductMiniumQuantityWholesale = ((0==A93ProductMiniumQuantityWholesale) ? true : false);
               n87ProductWholesaleProfit = ((Convert.ToDecimal(0)==A87ProductWholesaleProfit) ? true : false);
               n1BrandId = ((0==A1BrandId) ? true : false);
               n9SectorId = ((0==A9SectorId) ? true : false);
               n69ProductMiniumStock = ((0==A69ProductMiniumStock) ? true : false);
               n19ProductDescription = (String.IsNullOrEmpty(StringUtil.RTrim( A19ProductDescription)) ? true : false);
               edtProductName_Enabled = 0;
               AssignProp("", false, edtProductName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductName_Enabled), 5, 0), true);
               dynBrandId.Enabled = 0;
               AssignProp("", false, dynBrandId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynBrandId.Enabled), 5, 0), true);
               dynSectorId.Enabled = 0;
               AssignProp("", false, dynSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynSectorId.Enabled), 5, 0), true);
               edtProductDescription_Enabled = 0;
               AssignProp("", false, edtProductDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductDescription_Enabled), 5, 0), true);
            }
            else
            {
               edtProductName_Enabled = 1;
               AssignProp("", false, edtProductName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductName_Enabled), 5, 0), true);
               dynBrandId.Enabled = 1;
               AssignProp("", false, dynBrandId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynBrandId.Enabled), 5, 0), true);
               dynSectorId.Enabled = 1;
               AssignProp("", false, dynSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynSectorId.Enabled), 5, 0), true);
               edtProductDescription_Enabled = 1;
               AssignProp("", false, edtProductDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductDescription_Enabled), 5, 0), true);
            }
         }
         else
         {
            edtProductName_Enabled = 1;
            AssignProp("", false, edtProductName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductName_Enabled), 5, 0), true);
            A16ProductName = "";
            AssignAttri("", false, "A16ProductName", A16ProductName);
            dynBrandId.Enabled = 1;
            AssignProp("", false, dynBrandId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynBrandId.Enabled), 5, 0), true);
            A1BrandId = 0;
            n1BrandId = false;
            AssignAttri("", false, "A1BrandId", StringUtil.LTrimStr( (decimal)(A1BrandId), 6, 0));
            dynSectorId.Enabled = 1;
            AssignProp("", false, dynSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynSectorId.Enabled), 5, 0), true);
            A9SectorId = 0;
            n9SectorId = false;
            AssignAttri("", false, "A9SectorId", StringUtil.LTrimStr( (decimal)(A9SectorId), 6, 0));
            edtProductDescription_Enabled = 1;
            AssignProp("", false, edtProductDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductDescription_Enabled), 5, 0), true);
            A19ProductDescription = "";
            n19ProductDescription = false;
            AssignAttri("", false, "A19ProductDescription", A19ProductDescription);
         }
         /*  Sending Event outputs  */
         dynSectorId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A9SectorId), 6, 0));
         AssignProp("", false, dynSectorId_Internalname, "Values", dynSectorId.ToJavascriptSource(), true);
         dynBrandId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1BrandId), 6, 0));
         AssignProp("", false, dynBrandId_Internalname, "Values", dynBrandId.ToJavascriptSource(), true);
      }

      protected void E14052( )
      {
         /* ProductCostPrice_Controlvaluechanged Routine */
         returnInSub = false;
         if ( A85ProductCostPrice != new roundvalue(context).executeUdp(  A85ProductCostPrice) )
         {
            new productcostpriceroundvalue(context ).execute( ref  A85ProductCostPrice) ;
            AssignAttri("", false, "A85ProductCostPrice", StringUtil.LTrimStr( A85ProductCostPrice, 18, 2));
            n85ProductCostPrice = ((Convert.ToDecimal(0)==A85ProductCostPrice) ? true : false);
         }
         /*  Sending Event outputs  */
      }

      protected void ZM055( short GX_JID )
      {
         if ( ( GX_JID == 35 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z110ProductActive = T00053_A110ProductActive[0];
               Z55ProductCode = T00053_A55ProductCode[0];
               Z16ProductName = T00053_A16ProductName[0];
               Z85ProductCostPrice = T00053_A85ProductCostPrice[0];
               Z89ProductRetailProfit = T00053_A89ProductRetailProfit[0];
               Z87ProductWholesaleProfit = T00053_A87ProductWholesaleProfit[0];
               Z17ProductStock = T00053_A17ProductStock[0];
               Z69ProductMiniumStock = T00053_A69ProductMiniumStock[0];
               Z19ProductDescription = T00053_A19ProductDescription[0];
               Z28ProductCreatedDate = T00053_A28ProductCreatedDate[0];
               Z29ProductModifiedDate = T00053_A29ProductModifiedDate[0];
               Z93ProductMiniumQuantityWholesale = T00053_A93ProductMiniumQuantityWholesale[0];
               Z1BrandId = T00053_A1BrandId[0];
               Z9SectorId = T00053_A9SectorId[0];
               Z4SupplierId = T00053_A4SupplierId[0];
            }
            else
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
            }
         }
         if ( GX_JID == -35 )
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
         GXABRANDID_html055( ) ;
         GXASUPPLIERID_html055( ) ;
         GXASECTORID_html055( ) ;
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         Gx_date = DateTimeUtil.Today( context);
         AssignAttri("", false, "Gx_date", context.localUtil.Format(Gx_date, "99/99/99"));
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV15ProductId) )
         {
            A15ProductId = AV15ProductId;
            AssignAttri("", false, "A15ProductId", StringUtil.LTrimStr( (decimal)(A15ProductId), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_BrandId) )
         {
            dynBrandId.Enabled = 0;
            AssignProp("", false, dynBrandId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynBrandId.Enabled), 5, 0), true);
         }
         else
         {
            dynBrandId.Enabled = 1;
            AssignProp("", false, dynBrandId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynBrandId.Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_SupplierId) )
         {
            dynSupplierId.Enabled = 0;
            AssignProp("", false, dynSupplierId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynSupplierId.Enabled), 5, 0), true);
         }
         else
         {
            dynSupplierId.Enabled = 1;
            AssignProp("", false, dynSupplierId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynSupplierId.Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_SectorId) )
         {
            dynSectorId.Enabled = 0;
            AssignProp("", false, dynSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynSectorId.Enabled), 5, 0), true);
         }
         else
         {
            dynSectorId.Enabled = 1;
            AssignProp("", false, dynSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynSectorId.Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            A110ProductActive = true;
            n110ProductActive = false;
            AssignAttri("", false, "A110ProductActive", A110ProductActive);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_SectorId) )
         {
            A9SectorId = AV12Insert_SectorId;
            n9SectorId = false;
            AssignAttri("", false, "A9SectorId", StringUtil.LTrimStr( (decimal)(A9SectorId), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_SupplierId) )
         {
            A4SupplierId = AV13Insert_SupplierId;
            AssignAttri("", false, "A4SupplierId", StringUtil.LTrimStr( (decimal)(A4SupplierId), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_BrandId) )
         {
            A1BrandId = AV11Insert_BrandId;
            n1BrandId = false;
            AssignAttri("", false, "A1BrandId", StringUtil.LTrimStr( (decimal)(A1BrandId), 6, 0));
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            A28ProductCreatedDate = Gx_date;
            AssignAttri("", false, "A28ProductCreatedDate", context.localUtil.Format(A28ProductCreatedDate, "99/99/9999"));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
         {
            A29ProductModifiedDate = Gx_date;
            AssignAttri("", false, "A29ProductModifiedDate", context.localUtil.Format(A29ProductModifiedDate, "99/99/9999"));
         }
         if ( IsIns( )  && (0==A17ProductStock) && ( Gx_BScreen == 0 ) )
         {
            A17ProductStock = 0;
            n17ProductStock = false;
            AssignAttri("", false, "A17ProductStock", StringUtil.LTrimStr( (decimal)(A17ProductStock), 6, 0));
         }
         if ( IsIns( )  && (0==A69ProductMiniumStock) && ( Gx_BScreen == 0 ) )
         {
            A69ProductMiniumStock = 0;
            n69ProductMiniumStock = false;
            AssignAttri("", false, "A69ProductMiniumStock", StringUtil.LTrimStr( (decimal)(A69ProductMiniumStock), 6, 0));
         }
         if ( IsIns( )  && (0==A93ProductMiniumQuantityWholesale) && ( Gx_BScreen == 0 ) )
         {
            A93ProductMiniumQuantityWholesale = 0;
            n93ProductMiniumQuantityWholesale = false;
            AssignAttri("", false, "A93ProductMiniumQuantityWholesale", StringUtil.LTrimStr( (decimal)(A93ProductMiniumQuantityWholesale), 4, 0));
         }
         if ( IsIns( )  && (Convert.ToDecimal(0)==A89ProductRetailProfit) && ( Gx_BScreen == 0 ) )
         {
            A89ProductRetailProfit = 0;
            n89ProductRetailProfit = false;
            AssignAttri("", false, "A89ProductRetailProfit", StringUtil.LTrimStr( A89ProductRetailProfit, 8, 2));
         }
         if ( IsIns( )  && (Convert.ToDecimal(0)==A87ProductWholesaleProfit) && ( Gx_BScreen == 0 ) )
         {
            A87ProductWholesaleProfit = 0;
            n87ProductWholesaleProfit = false;
            AssignAttri("", false, "A87ProductWholesaleProfit", StringUtil.LTrimStr( A87ProductWholesaleProfit, 8, 2));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T00054 */
            pr_default.execute(2, new Object[] {n1BrandId, A1BrandId});
            A2BrandName = T00054_A2BrandName[0];
            pr_default.close(2);
            /* Using cursor T00056 */
            pr_default.execute(4, new Object[] {A4SupplierId});
            A5SupplierName = T00056_A5SupplierName[0];
            pr_default.close(4);
            /* Using cursor T00055 */
            pr_default.execute(3, new Object[] {n9SectorId, A9SectorId});
            A10SectorName = T00055_A10SectorName[0];
            pr_default.close(3);
            AV26Pgmname = "Product";
            AssignAttri("", false, "AV26Pgmname", AV26Pgmname);
            if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && A110ProductActive )
            {
               AV16ProductState = "Enabled";
               AssignAttri("", false, "AV16ProductState", AV16ProductState);
            }
            else
            {
               if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ! A110ProductActive )
               {
                  AV16ProductState = "Disabled";
                  AssignAttri("", false, "AV16ProductState", AV16ProductState);
               }
            }
         }
      }

      protected void Load055( )
      {
         /* Using cursor T00057 */
         pr_default.execute(5, new Object[] {A15ProductId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound5 = 1;
            A110ProductActive = T00057_A110ProductActive[0];
            n110ProductActive = T00057_n110ProductActive[0];
            A55ProductCode = T00057_A55ProductCode[0];
            n55ProductCode = T00057_n55ProductCode[0];
            AssignAttri("", false, "A55ProductCode", A55ProductCode);
            A16ProductName = T00057_A16ProductName[0];
            AssignAttri("", false, "A16ProductName", A16ProductName);
            A85ProductCostPrice = T00057_A85ProductCostPrice[0];
            n85ProductCostPrice = T00057_n85ProductCostPrice[0];
            AssignAttri("", false, "A85ProductCostPrice", StringUtil.LTrimStr( A85ProductCostPrice, 18, 2));
            A89ProductRetailProfit = T00057_A89ProductRetailProfit[0];
            n89ProductRetailProfit = T00057_n89ProductRetailProfit[0];
            AssignAttri("", false, "A89ProductRetailProfit", StringUtil.LTrimStr( A89ProductRetailProfit, 8, 2));
            A87ProductWholesaleProfit = T00057_A87ProductWholesaleProfit[0];
            n87ProductWholesaleProfit = T00057_n87ProductWholesaleProfit[0];
            AssignAttri("", false, "A87ProductWholesaleProfit", StringUtil.LTrimStr( A87ProductWholesaleProfit, 8, 2));
            A2BrandName = T00057_A2BrandName[0];
            A5SupplierName = T00057_A5SupplierName[0];
            A10SectorName = T00057_A10SectorName[0];
            A17ProductStock = T00057_A17ProductStock[0];
            n17ProductStock = T00057_n17ProductStock[0];
            AssignAttri("", false, "A17ProductStock", StringUtil.LTrimStr( (decimal)(A17ProductStock), 6, 0));
            A69ProductMiniumStock = T00057_A69ProductMiniumStock[0];
            n69ProductMiniumStock = T00057_n69ProductMiniumStock[0];
            AssignAttri("", false, "A69ProductMiniumStock", StringUtil.LTrimStr( (decimal)(A69ProductMiniumStock), 6, 0));
            A19ProductDescription = T00057_A19ProductDescription[0];
            n19ProductDescription = T00057_n19ProductDescription[0];
            AssignAttri("", false, "A19ProductDescription", A19ProductDescription);
            A28ProductCreatedDate = T00057_A28ProductCreatedDate[0];
            A29ProductModifiedDate = T00057_A29ProductModifiedDate[0];
            A93ProductMiniumQuantityWholesale = T00057_A93ProductMiniumQuantityWholesale[0];
            n93ProductMiniumQuantityWholesale = T00057_n93ProductMiniumQuantityWholesale[0];
            AssignAttri("", false, "A93ProductMiniumQuantityWholesale", StringUtil.LTrimStr( (decimal)(A93ProductMiniumQuantityWholesale), 4, 0));
            A1BrandId = T00057_A1BrandId[0];
            n1BrandId = T00057_n1BrandId[0];
            AssignAttri("", false, "A1BrandId", StringUtil.LTrimStr( (decimal)(A1BrandId), 6, 0));
            A9SectorId = T00057_A9SectorId[0];
            n9SectorId = T00057_n9SectorId[0];
            AssignAttri("", false, "A9SectorId", StringUtil.LTrimStr( (decimal)(A9SectorId), 6, 0));
            A4SupplierId = T00057_A4SupplierId[0];
            AssignAttri("", false, "A4SupplierId", StringUtil.LTrimStr( (decimal)(A4SupplierId), 6, 0));
            ZM055( -35) ;
         }
         pr_default.close(5);
         OnLoadActions055( ) ;
      }

      protected void OnLoadActions055( )
      {
         AV26Pgmname = "Product";
         AssignAttri("", false, "AV26Pgmname", AV26Pgmname);
         GXt_decimal2 = A90ProductRetailPrice;
         new roundvalue(context ).execute(  A85ProductCostPrice*(1+A89ProductRetailProfit/ (decimal)(100)), out  GXt_decimal2) ;
         GXt_decimal3 = A90ProductRetailPrice;
         new roundvalue(context ).execute(  A85ProductCostPrice*(1+A89ProductRetailProfit/ (decimal)(100)), out  GXt_decimal3) ;
         GXt_decimal4 = A90ProductRetailPrice;
         new roundvalue(context ).execute(  A85ProductCostPrice, out  GXt_decimal4) ;
         A90ProductRetailPrice = ((A89ProductRetailProfit!=Convert.ToDecimal(0)) ? GXt_decimal3 : GXt_decimal4);
         AssignAttri("", false, "A90ProductRetailPrice", StringUtil.LTrimStr( A90ProductRetailPrice, 18, 2));
         GXt_decimal4 = A88ProductWholesalePrice;
         new roundvalue(context ).execute(  A85ProductCostPrice*(1+A87ProductWholesaleProfit/ (decimal)(100)), out  GXt_decimal4) ;
         GXt_decimal3 = A88ProductWholesalePrice;
         new roundvalue(context ).execute(  A85ProductCostPrice*(1+A87ProductWholesaleProfit/ (decimal)(100)), out  GXt_decimal3) ;
         GXt_decimal2 = A88ProductWholesalePrice;
         new roundvalue(context ).execute(  A85ProductCostPrice, out  GXt_decimal2) ;
         A88ProductWholesalePrice = ((A87ProductWholesaleProfit!=Convert.ToDecimal(0)) ? GXt_decimal3 : GXt_decimal2);
         AssignAttri("", false, "A88ProductWholesalePrice", StringUtil.LTrimStr( A88ProductWholesalePrice, 18, 2));
         if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && A110ProductActive )
         {
            AV16ProductState = "Enabled";
            AssignAttri("", false, "AV16ProductState", AV16ProductState);
         }
         else
         {
            if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ! A110ProductActive )
            {
               AV16ProductState = "Disabled";
               AssignAttri("", false, "AV16ProductState", AV16ProductState);
            }
         }
      }

      protected void CheckExtendedTable055( )
      {
         nIsDirty_5 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV26Pgmname = "Product";
         AssignAttri("", false, "AV26Pgmname", AV26Pgmname);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A16ProductName)) )
         {
            GX_msglist.addItem("Name is required", 1, "PRODUCTNAME");
            AnyError = 1;
            GX_FocusControl = edtProductName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( ( A85ProductCostPrice >= Convert.ToDecimal( 0 )) && ( A85ProductCostPrice <= 999999999999999.99m ) ) || (Convert.ToDecimal(0)==A85ProductCostPrice) ) )
         {
            GX_msglist.addItem("Invalid Price", "OutOfRange", 1, "PRODUCTCOSTPRICE");
            AnyError = 1;
            GX_FocusControl = edtProductCostPrice_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         nIsDirty_5 = 1;
         GXt_decimal4 = A90ProductRetailPrice;
         new roundvalue(context ).execute(  A85ProductCostPrice*(1+A89ProductRetailProfit/ (decimal)(100)), out  GXt_decimal4) ;
         GXt_decimal3 = A90ProductRetailPrice;
         new roundvalue(context ).execute(  A85ProductCostPrice*(1+A89ProductRetailProfit/ (decimal)(100)), out  GXt_decimal3) ;
         GXt_decimal2 = A90ProductRetailPrice;
         new roundvalue(context ).execute(  A85ProductCostPrice, out  GXt_decimal2) ;
         A90ProductRetailPrice = ((A89ProductRetailProfit!=Convert.ToDecimal(0)) ? GXt_decimal3 : GXt_decimal2);
         AssignAttri("", false, "A90ProductRetailPrice", StringUtil.LTrimStr( A90ProductRetailPrice, 18, 2));
         nIsDirty_5 = 1;
         GXt_decimal4 = A88ProductWholesalePrice;
         new roundvalue(context ).execute(  A85ProductCostPrice*(1+A87ProductWholesaleProfit/ (decimal)(100)), out  GXt_decimal4) ;
         GXt_decimal3 = A88ProductWholesalePrice;
         new roundvalue(context ).execute(  A85ProductCostPrice*(1+A87ProductWholesaleProfit/ (decimal)(100)), out  GXt_decimal3) ;
         GXt_decimal2 = A88ProductWholesalePrice;
         new roundvalue(context ).execute(  A85ProductCostPrice, out  GXt_decimal2) ;
         A88ProductWholesalePrice = ((A87ProductWholesaleProfit!=Convert.ToDecimal(0)) ? GXt_decimal3 : GXt_decimal2);
         AssignAttri("", false, "A88ProductWholesalePrice", StringUtil.LTrimStr( A88ProductWholesalePrice, 18, 2));
         if ( (Convert.ToDecimal(0)==A85ProductCostPrice) )
         {
            GX_msglist.addItem("Price is Required", 1, "PRODUCTCOSTPRICE");
            AnyError = 1;
            GX_FocusControl = edtProductCostPrice_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (Convert.ToDecimal(0)==A85ProductCostPrice) )
         {
            new productcostpriceroundvalue(context ).execute( ref  A85ProductCostPrice) ;
            AssignAttri("", false, "A85ProductCostPrice", StringUtil.LTrimStr( A85ProductCostPrice, 18, 2));
            n85ProductCostPrice = ((Convert.ToDecimal(0)==A85ProductCostPrice) ? true : false);
         }
         if ( ! ( ( ( A89ProductRetailProfit >= Convert.ToDecimal( -999 )) && ( A89ProductRetailProfit <= Convert.ToDecimal( 999 )) ) || (Convert.ToDecimal(0)==A89ProductRetailProfit) ) )
         {
            GX_msglist.addItem("Field Product Retail Profit is out of range", "OutOfRange", 1, "PRODUCTRETAILPROFIT");
            AnyError = 1;
            GX_FocusControl = edtProductRetailProfit_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ( A89ProductRetailProfit != A87ProductWholesaleProfit ) && (0==A93ProductMiniumQuantityWholesale) )
         {
            GX_msglist.addItem("Retail Profit and Wholesale Profit must be equals when Min. Qty. Wholesale is not defined", 1, "PRODUCTRETAILPROFIT");
            AnyError = 1;
            GX_FocusControl = edtProductRetailProfit_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( ( A87ProductWholesaleProfit >= Convert.ToDecimal( -999 )) && ( A87ProductWholesaleProfit <= Convert.ToDecimal( 999 )) ) || (Convert.ToDecimal(0)==A87ProductWholesaleProfit) ) )
         {
            GX_msglist.addItem("Field Product Wholesale Profit is out of range", "OutOfRange", 1, "PRODUCTWHOLESALEPROFIT");
            AnyError = 1;
            GX_FocusControl = edtProductWholesaleProfit_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00054 */
         pr_default.execute(2, new Object[] {n1BrandId, A1BrandId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A1BrandId) ) )
            {
               GX_msglist.addItem("No matching 'Brand'.", "ForeignKeyNotFound", 1, "BRANDID");
               AnyError = 1;
               GX_FocusControl = dynBrandId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A2BrandName = T00054_A2BrandName[0];
         pr_default.close(2);
         /* Using cursor T00056 */
         pr_default.execute(4, new Object[] {A4SupplierId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No matching 'Supplier'.", "ForeignKeyNotFound", 1, "SUPPLIERID");
            AnyError = 1;
            GX_FocusControl = dynSupplierId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A5SupplierName = T00056_A5SupplierName[0];
         pr_default.close(4);
         /* Using cursor T00055 */
         pr_default.execute(3, new Object[] {n9SectorId, A9SectorId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A9SectorId) ) )
            {
               GX_msglist.addItem("No matching 'Sector'.", "ForeignKeyNotFound", 1, "SECTORID");
               AnyError = 1;
               GX_FocusControl = dynSectorId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A10SectorName = T00055_A10SectorName[0];
         pr_default.close(3);
         if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && A110ProductActive )
         {
            AV16ProductState = "Enabled";
            AssignAttri("", false, "AV16ProductState", AV16ProductState);
         }
         else
         {
            if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ! A110ProductActive )
            {
               AV16ProductState = "Disabled";
               AssignAttri("", false, "AV16ProductState", AV16ProductState);
            }
         }
         /* Using cursor T00058 */
         pr_default.execute(6, new Object[] {A16ProductName, A4SupplierId, A15ProductId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Product Name"+","+"Supplier Id"}), 1, "PRODUCTNAME");
            AnyError = 1;
            GX_FocusControl = edtProductName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(6);
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

      protected void gxLoad_37( int A1BrandId )
      {
         /* Using cursor T00059 */
         pr_default.execute(7, new Object[] {n1BrandId, A1BrandId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A1BrandId) ) )
            {
               GX_msglist.addItem("No matching 'Brand'.", "ForeignKeyNotFound", 1, "BRANDID");
               AnyError = 1;
               GX_FocusControl = dynBrandId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A2BrandName = T00059_A2BrandName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A2BrandName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_39( int A4SupplierId )
      {
         /* Using cursor T000510 */
         pr_default.execute(8, new Object[] {A4SupplierId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No matching 'Supplier'.", "ForeignKeyNotFound", 1, "SUPPLIERID");
            AnyError = 1;
            GX_FocusControl = dynSupplierId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A5SupplierName = T000510_A5SupplierName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A5SupplierName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void gxLoad_38( int A9SectorId )
      {
         /* Using cursor T000511 */
         pr_default.execute(9, new Object[] {n9SectorId, A9SectorId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            if ( ! ( (0==A9SectorId) ) )
            {
               GX_msglist.addItem("No matching 'Sector'.", "ForeignKeyNotFound", 1, "SECTORID");
               AnyError = 1;
               GX_FocusControl = dynSectorId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A10SectorName = T000511_A10SectorName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A10SectorName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void GetKey055( )
      {
         /* Using cursor T000512 */
         pr_default.execute(10, new Object[] {A15ProductId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound5 = 1;
         }
         else
         {
            RcdFound5 = 0;
         }
         pr_default.close(10);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00053 */
         pr_default.execute(1, new Object[] {A15ProductId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM055( 35) ;
            RcdFound5 = 1;
            A15ProductId = T00053_A15ProductId[0];
            A110ProductActive = T00053_A110ProductActive[0];
            n110ProductActive = T00053_n110ProductActive[0];
            A55ProductCode = T00053_A55ProductCode[0];
            n55ProductCode = T00053_n55ProductCode[0];
            AssignAttri("", false, "A55ProductCode", A55ProductCode);
            A16ProductName = T00053_A16ProductName[0];
            AssignAttri("", false, "A16ProductName", A16ProductName);
            A85ProductCostPrice = T00053_A85ProductCostPrice[0];
            n85ProductCostPrice = T00053_n85ProductCostPrice[0];
            AssignAttri("", false, "A85ProductCostPrice", StringUtil.LTrimStr( A85ProductCostPrice, 18, 2));
            A89ProductRetailProfit = T00053_A89ProductRetailProfit[0];
            n89ProductRetailProfit = T00053_n89ProductRetailProfit[0];
            AssignAttri("", false, "A89ProductRetailProfit", StringUtil.LTrimStr( A89ProductRetailProfit, 8, 2));
            A87ProductWholesaleProfit = T00053_A87ProductWholesaleProfit[0];
            n87ProductWholesaleProfit = T00053_n87ProductWholesaleProfit[0];
            AssignAttri("", false, "A87ProductWholesaleProfit", StringUtil.LTrimStr( A87ProductWholesaleProfit, 8, 2));
            A17ProductStock = T00053_A17ProductStock[0];
            n17ProductStock = T00053_n17ProductStock[0];
            AssignAttri("", false, "A17ProductStock", StringUtil.LTrimStr( (decimal)(A17ProductStock), 6, 0));
            A69ProductMiniumStock = T00053_A69ProductMiniumStock[0];
            n69ProductMiniumStock = T00053_n69ProductMiniumStock[0];
            AssignAttri("", false, "A69ProductMiniumStock", StringUtil.LTrimStr( (decimal)(A69ProductMiniumStock), 6, 0));
            A19ProductDescription = T00053_A19ProductDescription[0];
            n19ProductDescription = T00053_n19ProductDescription[0];
            AssignAttri("", false, "A19ProductDescription", A19ProductDescription);
            A28ProductCreatedDate = T00053_A28ProductCreatedDate[0];
            A29ProductModifiedDate = T00053_A29ProductModifiedDate[0];
            A93ProductMiniumQuantityWholesale = T00053_A93ProductMiniumQuantityWholesale[0];
            n93ProductMiniumQuantityWholesale = T00053_n93ProductMiniumQuantityWholesale[0];
            AssignAttri("", false, "A93ProductMiniumQuantityWholesale", StringUtil.LTrimStr( (decimal)(A93ProductMiniumQuantityWholesale), 4, 0));
            A1BrandId = T00053_A1BrandId[0];
            n1BrandId = T00053_n1BrandId[0];
            AssignAttri("", false, "A1BrandId", StringUtil.LTrimStr( (decimal)(A1BrandId), 6, 0));
            A9SectorId = T00053_A9SectorId[0];
            n9SectorId = T00053_n9SectorId[0];
            AssignAttri("", false, "A9SectorId", StringUtil.LTrimStr( (decimal)(A9SectorId), 6, 0));
            A4SupplierId = T00053_A4SupplierId[0];
            AssignAttri("", false, "A4SupplierId", StringUtil.LTrimStr( (decimal)(A4SupplierId), 6, 0));
            Z15ProductId = A15ProductId;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load055( ) ;
            if ( AnyError == 1 )
            {
               RcdFound5 = 0;
               InitializeNonKey055( ) ;
            }
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound5 = 0;
            InitializeNonKey055( ) ;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey055( ) ;
         if ( RcdFound5 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound5 = 0;
         /* Using cursor T000513 */
         pr_default.execute(11, new Object[] {A15ProductId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T000513_A15ProductId[0] < A15ProductId ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T000513_A15ProductId[0] > A15ProductId ) ) )
            {
               A15ProductId = T000513_A15ProductId[0];
               RcdFound5 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void move_previous( )
      {
         RcdFound5 = 0;
         /* Using cursor T000514 */
         pr_default.execute(12, new Object[] {A15ProductId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            while ( (pr_default.getStatus(12) != 101) && ( ( T000514_A15ProductId[0] > A15ProductId ) ) )
            {
               pr_default.readNext(12);
            }
            if ( (pr_default.getStatus(12) != 101) && ( ( T000514_A15ProductId[0] < A15ProductId ) ) )
            {
               A15ProductId = T000514_A15ProductId[0];
               RcdFound5 = 1;
            }
         }
         pr_default.close(12);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey055( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtProductCode_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert055( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound5 == 1 )
            {
               if ( A15ProductId != Z15ProductId )
               {
                  A15ProductId = Z15ProductId;
                  AssignAttri("", false, "A15ProductId", StringUtil.LTrimStr( (decimal)(A15ProductId), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtProductCode_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update055( ) ;
                  GX_FocusControl = edtProductCode_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A15ProductId != Z15ProductId )
               {
                  /* Insert record */
                  GX_FocusControl = edtProductCode_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert055( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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
                     /* Insert record */
                     GX_FocusControl = edtProductCode_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert055( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A15ProductId != Z15ProductId )
         {
            A15ProductId = Z15ProductId;
            AssignAttri("", false, "A15ProductId", StringUtil.LTrimStr( (decimal)(A15ProductId), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "");
            AnyError = 1;
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtProductCode_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency055( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00052 */
            pr_default.execute(0, new Object[] {A15ProductId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Product"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z110ProductActive != T00052_A110ProductActive[0] ) || ( StringUtil.StrCmp(Z55ProductCode, T00052_A55ProductCode[0]) != 0 ) || ( StringUtil.StrCmp(Z16ProductName, T00052_A16ProductName[0]) != 0 ) || ( Z85ProductCostPrice != T00052_A85ProductCostPrice[0] ) || ( Z89ProductRetailProfit != T00052_A89ProductRetailProfit[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z87ProductWholesaleProfit != T00052_A87ProductWholesaleProfit[0] ) || ( Z17ProductStock != T00052_A17ProductStock[0] ) || ( Z69ProductMiniumStock != T00052_A69ProductMiniumStock[0] ) || ( StringUtil.StrCmp(Z19ProductDescription, T00052_A19ProductDescription[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z28ProductCreatedDate ) != DateTimeUtil.ResetTime ( T00052_A28ProductCreatedDate[0] ) ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( DateTimeUtil.ResetTime ( Z29ProductModifiedDate ) != DateTimeUtil.ResetTime ( T00052_A29ProductModifiedDate[0] ) ) || ( Z93ProductMiniumQuantityWholesale != T00052_A93ProductMiniumQuantityWholesale[0] ) || ( Z1BrandId != T00052_A1BrandId[0] ) || ( Z9SectorId != T00052_A9SectorId[0] ) || ( Z4SupplierId != T00052_A4SupplierId[0] ) )
            {
               if ( Z110ProductActive != T00052_A110ProductActive[0] )
               {
                  GXUtil.WriteLog("product:[seudo value changed for attri]"+"ProductActive");
                  GXUtil.WriteLogRaw("Old: ",Z110ProductActive);
                  GXUtil.WriteLogRaw("Current: ",T00052_A110ProductActive[0]);
               }
               if ( StringUtil.StrCmp(Z55ProductCode, T00052_A55ProductCode[0]) != 0 )
               {
                  GXUtil.WriteLog("product:[seudo value changed for attri]"+"ProductCode");
                  GXUtil.WriteLogRaw("Old: ",Z55ProductCode);
                  GXUtil.WriteLogRaw("Current: ",T00052_A55ProductCode[0]);
               }
               if ( StringUtil.StrCmp(Z16ProductName, T00052_A16ProductName[0]) != 0 )
               {
                  GXUtil.WriteLog("product:[seudo value changed for attri]"+"ProductName");
                  GXUtil.WriteLogRaw("Old: ",Z16ProductName);
                  GXUtil.WriteLogRaw("Current: ",T00052_A16ProductName[0]);
               }
               if ( Z85ProductCostPrice != T00052_A85ProductCostPrice[0] )
               {
                  GXUtil.WriteLog("product:[seudo value changed for attri]"+"ProductCostPrice");
                  GXUtil.WriteLogRaw("Old: ",Z85ProductCostPrice);
                  GXUtil.WriteLogRaw("Current: ",T00052_A85ProductCostPrice[0]);
               }
               if ( Z89ProductRetailProfit != T00052_A89ProductRetailProfit[0] )
               {
                  GXUtil.WriteLog("product:[seudo value changed for attri]"+"ProductRetailProfit");
                  GXUtil.WriteLogRaw("Old: ",Z89ProductRetailProfit);
                  GXUtil.WriteLogRaw("Current: ",T00052_A89ProductRetailProfit[0]);
               }
               if ( Z87ProductWholesaleProfit != T00052_A87ProductWholesaleProfit[0] )
               {
                  GXUtil.WriteLog("product:[seudo value changed for attri]"+"ProductWholesaleProfit");
                  GXUtil.WriteLogRaw("Old: ",Z87ProductWholesaleProfit);
                  GXUtil.WriteLogRaw("Current: ",T00052_A87ProductWholesaleProfit[0]);
               }
               if ( Z17ProductStock != T00052_A17ProductStock[0] )
               {
                  GXUtil.WriteLog("product:[seudo value changed for attri]"+"ProductStock");
                  GXUtil.WriteLogRaw("Old: ",Z17ProductStock);
                  GXUtil.WriteLogRaw("Current: ",T00052_A17ProductStock[0]);
               }
               if ( Z69ProductMiniumStock != T00052_A69ProductMiniumStock[0] )
               {
                  GXUtil.WriteLog("product:[seudo value changed for attri]"+"ProductMiniumStock");
                  GXUtil.WriteLogRaw("Old: ",Z69ProductMiniumStock);
                  GXUtil.WriteLogRaw("Current: ",T00052_A69ProductMiniumStock[0]);
               }
               if ( StringUtil.StrCmp(Z19ProductDescription, T00052_A19ProductDescription[0]) != 0 )
               {
                  GXUtil.WriteLog("product:[seudo value changed for attri]"+"ProductDescription");
                  GXUtil.WriteLogRaw("Old: ",Z19ProductDescription);
                  GXUtil.WriteLogRaw("Current: ",T00052_A19ProductDescription[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z28ProductCreatedDate ) != DateTimeUtil.ResetTime ( T00052_A28ProductCreatedDate[0] ) )
               {
                  GXUtil.WriteLog("product:[seudo value changed for attri]"+"ProductCreatedDate");
                  GXUtil.WriteLogRaw("Old: ",Z28ProductCreatedDate);
                  GXUtil.WriteLogRaw("Current: ",T00052_A28ProductCreatedDate[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z29ProductModifiedDate ) != DateTimeUtil.ResetTime ( T00052_A29ProductModifiedDate[0] ) )
               {
                  GXUtil.WriteLog("product:[seudo value changed for attri]"+"ProductModifiedDate");
                  GXUtil.WriteLogRaw("Old: ",Z29ProductModifiedDate);
                  GXUtil.WriteLogRaw("Current: ",T00052_A29ProductModifiedDate[0]);
               }
               if ( Z93ProductMiniumQuantityWholesale != T00052_A93ProductMiniumQuantityWholesale[0] )
               {
                  GXUtil.WriteLog("product:[seudo value changed for attri]"+"ProductMiniumQuantityWholesale");
                  GXUtil.WriteLogRaw("Old: ",Z93ProductMiniumQuantityWholesale);
                  GXUtil.WriteLogRaw("Current: ",T00052_A93ProductMiniumQuantityWholesale[0]);
               }
               if ( Z1BrandId != T00052_A1BrandId[0] )
               {
                  GXUtil.WriteLog("product:[seudo value changed for attri]"+"BrandId");
                  GXUtil.WriteLogRaw("Old: ",Z1BrandId);
                  GXUtil.WriteLogRaw("Current: ",T00052_A1BrandId[0]);
               }
               if ( Z9SectorId != T00052_A9SectorId[0] )
               {
                  GXUtil.WriteLog("product:[seudo value changed for attri]"+"SectorId");
                  GXUtil.WriteLogRaw("Old: ",Z9SectorId);
                  GXUtil.WriteLogRaw("Current: ",T00052_A9SectorId[0]);
               }
               if ( Z4SupplierId != T00052_A4SupplierId[0] )
               {
                  GXUtil.WriteLog("product:[seudo value changed for attri]"+"SupplierId");
                  GXUtil.WriteLogRaw("Old: ",Z4SupplierId);
                  GXUtil.WriteLogRaw("Current: ",T00052_A4SupplierId[0]);
               }
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
                     /* Using cursor T000515 */
                     pr_default.execute(13, new Object[] {n110ProductActive, A110ProductActive, n55ProductCode, A55ProductCode, A16ProductName, n85ProductCostPrice, A85ProductCostPrice, n89ProductRetailProfit, A89ProductRetailProfit, n87ProductWholesaleProfit, A87ProductWholesaleProfit, n17ProductStock, A17ProductStock, n69ProductMiniumStock, A69ProductMiniumStock, n19ProductDescription, A19ProductDescription, A28ProductCreatedDate, A29ProductModifiedDate, n93ProductMiniumQuantityWholesale, A93ProductMiniumQuantityWholesale, n1BrandId, A1BrandId, n9SectorId, A9SectorId, A4SupplierId});
                     A15ProductId = T000515_A15ProductId[0];
                     pr_default.close(13);
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
                           ResetCaption050( ) ;
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
                     /* Using cursor T000516 */
                     pr_default.execute(14, new Object[] {n110ProductActive, A110ProductActive, n55ProductCode, A55ProductCode, A16ProductName, n85ProductCostPrice, A85ProductCostPrice, n89ProductRetailProfit, A89ProductRetailProfit, n87ProductWholesaleProfit, A87ProductWholesaleProfit, n17ProductStock, A17ProductStock, n69ProductMiniumStock, A69ProductMiniumStock, n19ProductDescription, A19ProductDescription, A28ProductCreatedDate, A29ProductModifiedDate, n93ProductMiniumQuantityWholesale, A93ProductMiniumQuantityWholesale, n1BrandId, A1BrandId, n9SectorId, A9SectorId, A4SupplierId, A15ProductId});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("Product");
                     if ( (pr_default.getStatus(14) == 103) )
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
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
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
                  /* Using cursor T000517 */
                  pr_default.execute(15, new Object[] {A15ProductId});
                  pr_default.close(15);
                  pr_default.SmartCacheProvider.SetUpdated("Product");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( IsUpd( ) || IsDlt( ) )
                        {
                           if ( AnyError == 0 )
                           {
                              context.nUserReturn = 1;
                           }
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
         }
         sMode5 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel055( ) ;
         Gx_mode = sMode5;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls055( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV26Pgmname = "Product";
            AssignAttri("", false, "AV26Pgmname", AV26Pgmname);
            GXt_decimal4 = A90ProductRetailPrice;
            new roundvalue(context ).execute(  A85ProductCostPrice*(1+A89ProductRetailProfit/ (decimal)(100)), out  GXt_decimal4) ;
            GXt_decimal3 = A90ProductRetailPrice;
            new roundvalue(context ).execute(  A85ProductCostPrice*(1+A89ProductRetailProfit/ (decimal)(100)), out  GXt_decimal3) ;
            GXt_decimal2 = A90ProductRetailPrice;
            new roundvalue(context ).execute(  A85ProductCostPrice, out  GXt_decimal2) ;
            A90ProductRetailPrice = ((A89ProductRetailProfit!=Convert.ToDecimal(0)) ? GXt_decimal3 : GXt_decimal2);
            AssignAttri("", false, "A90ProductRetailPrice", StringUtil.LTrimStr( A90ProductRetailPrice, 18, 2));
            GXt_decimal4 = A88ProductWholesalePrice;
            new roundvalue(context ).execute(  A85ProductCostPrice*(1+A87ProductWholesaleProfit/ (decimal)(100)), out  GXt_decimal4) ;
            GXt_decimal3 = A88ProductWholesalePrice;
            new roundvalue(context ).execute(  A85ProductCostPrice*(1+A87ProductWholesaleProfit/ (decimal)(100)), out  GXt_decimal3) ;
            GXt_decimal2 = A88ProductWholesalePrice;
            new roundvalue(context ).execute(  A85ProductCostPrice, out  GXt_decimal2) ;
            A88ProductWholesalePrice = ((A87ProductWholesaleProfit!=Convert.ToDecimal(0)) ? GXt_decimal3 : GXt_decimal2);
            AssignAttri("", false, "A88ProductWholesalePrice", StringUtil.LTrimStr( A88ProductWholesalePrice, 18, 2));
            /* Using cursor T000518 */
            pr_default.execute(16, new Object[] {n1BrandId, A1BrandId});
            A2BrandName = T000518_A2BrandName[0];
            pr_default.close(16);
            /* Using cursor T000519 */
            pr_default.execute(17, new Object[] {A4SupplierId});
            A5SupplierName = T000519_A5SupplierName[0];
            pr_default.close(17);
            /* Using cursor T000520 */
            pr_default.execute(18, new Object[] {n9SectorId, A9SectorId});
            A10SectorName = T000520_A10SectorName[0];
            pr_default.close(18);
            if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && A110ProductActive )
            {
               AV16ProductState = "Enabled";
               AssignAttri("", false, "AV16ProductState", AV16ProductState);
            }
            else
            {
               if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ! A110ProductActive )
               {
                  AV16ProductState = "Disabled";
                  AssignAttri("", false, "AV16ProductState", AV16ProductState);
               }
            }
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000521 */
            pr_default.execute(19, new Object[] {A15ProductId});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detail"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
            /* Using cursor T000522 */
            pr_default.execute(20, new Object[] {A15ProductId});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detail"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
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
            pr_default.close(1);
            pr_default.close(16);
            pr_default.close(18);
            pr_default.close(17);
            context.CommitDataStores("product",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues050( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(16);
            pr_default.close(18);
            pr_default.close(17);
            context.RollbackDataStores("product",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart055( )
      {
         /* Scan By routine */
         /* Using cursor T000523 */
         pr_default.execute(21);
         RcdFound5 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound5 = 1;
            A15ProductId = T000523_A15ProductId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext055( )
      {
         /* Scan next routine */
         pr_default.readNext(21);
         RcdFound5 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound5 = 1;
            A15ProductId = T000523_A15ProductId[0];
         }
      }

      protected void ScanEnd055( )
      {
         pr_default.close(21);
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
         edtProductCode_Enabled = 0;
         AssignProp("", false, edtProductCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductCode_Enabled), 5, 0), true);
         edtProductName_Enabled = 0;
         AssignProp("", false, edtProductName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductName_Enabled), 5, 0), true);
         edtProductCostPrice_Enabled = 0;
         AssignProp("", false, edtProductCostPrice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductCostPrice_Enabled), 5, 0), true);
         edtProductRetailProfit_Enabled = 0;
         AssignProp("", false, edtProductRetailProfit_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductRetailProfit_Enabled), 5, 0), true);
         edtProductRetailPrice_Enabled = 0;
         AssignProp("", false, edtProductRetailPrice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductRetailPrice_Enabled), 5, 0), true);
         edtProductMiniumQuantityWholesale_Enabled = 0;
         AssignProp("", false, edtProductMiniumQuantityWholesale_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductMiniumQuantityWholesale_Enabled), 5, 0), true);
         edtProductWholesaleProfit_Enabled = 0;
         AssignProp("", false, edtProductWholesaleProfit_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductWholesaleProfit_Enabled), 5, 0), true);
         edtProductWholesalePrice_Enabled = 0;
         AssignProp("", false, edtProductWholesalePrice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductWholesalePrice_Enabled), 5, 0), true);
         dynBrandId.Enabled = 0;
         AssignProp("", false, dynBrandId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynBrandId.Enabled), 5, 0), true);
         dynSupplierId.Enabled = 0;
         AssignProp("", false, dynSupplierId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynSupplierId.Enabled), 5, 0), true);
         dynSectorId.Enabled = 0;
         AssignProp("", false, dynSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynSectorId.Enabled), 5, 0), true);
         edtProductStock_Enabled = 0;
         AssignProp("", false, edtProductStock_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductStock_Enabled), 5, 0), true);
         edtProductMiniumStock_Enabled = 0;
         AssignProp("", false, edtProductMiniumStock_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductMiniumStock_Enabled), 5, 0), true);
         edtProductDescription_Enabled = 0;
         AssignProp("", false, edtProductDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductDescription_Enabled), 5, 0), true);
         cmbavProductstate.Enabled = 0;
         AssignProp("", false, cmbavProductstate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavProductstate.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes055( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues050( )
      {
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         MasterPageObj.master_styles();
         CloseStyles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 1853160), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 1853160), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 1853160), false, true);
         context.AddJavascriptSource("gxcfg.js", "?"+GetCacheInvalidationToken( ), false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("product.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV15ProductId,6,0))}, new string[] {"Gx_mode","ProductId"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"Product");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("ProductId", context.localUtil.Format( (decimal)(A15ProductId), "ZZZZZ9"));
         forbiddenHiddens.Add("ProductCreatedDate", context.localUtil.Format(A28ProductCreatedDate, "99/99/9999"));
         forbiddenHiddens.Add("ProductModifiedDate", context.localUtil.Format(A29ProductModifiedDate, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("product:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z15ProductId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z15ProductId), 6, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, "Z110ProductActive", Z110ProductActive);
         GxWebStd.gx_hidden_field( context, "Z55ProductCode", Z55ProductCode);
         GxWebStd.gx_hidden_field( context, "Z16ProductName", Z16ProductName);
         GxWebStd.gx_hidden_field( context, "Z85ProductCostPrice", StringUtil.LTrim( StringUtil.NToC( Z85ProductCostPrice, 18, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z89ProductRetailProfit", StringUtil.LTrim( StringUtil.NToC( Z89ProductRetailProfit, 8, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z87ProductWholesaleProfit", StringUtil.LTrim( StringUtil.NToC( Z87ProductWholesaleProfit, 8, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z17ProductStock", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z17ProductStock), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z69ProductMiniumStock", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z69ProductMiniumStock), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z19ProductDescription", Z19ProductDescription);
         GxWebStd.gx_hidden_field( context, "Z28ProductCreatedDate", context.localUtil.DToC( Z28ProductCreatedDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z29ProductModifiedDate", context.localUtil.DToC( Z29ProductModifiedDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z93ProductMiniumQuantityWholesale", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z93ProductMiniumQuantityWholesale), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1BrandId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1BrandId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z9SectorId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9SectorId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z4SupplierId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z4SupplierId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N1BrandId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1BrandId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N4SupplierId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A4SupplierId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N9SectorId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9SectorId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vERRORMESSAGES", AV22ErrorMessages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vERRORMESSAGES", AV22ErrorMessages);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vERRORMESSAGES", GetSecureSignedToken( "", AV22ErrorMessages, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV9TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV9TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vPRODUCTIDAUX", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18ProductIdAux), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPRODUCTIDAUX", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV18ProductIdAux), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPRODUCTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15ProductId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPRODUCTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15ProductId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "PRODUCTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_BRANDID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_BrandId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_SUPPLIERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_SupplierId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_SECTORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_SectorId), 6, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, "PRODUCTACTIVE", A110ProductActive);
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "PRODUCTCREATEDDATE", context.localUtil.DToC( A28ProductCreatedDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "PRODUCTMODIFIEDDATE", context.localUtil.DToC( A29ProductModifiedDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "BRANDNAME", A2BrandName);
         GxWebStd.gx_hidden_field( context, "SECTORNAME", A10SectorName);
         GxWebStd.gx_hidden_field( context, "SUPPLIERNAME", A5SupplierName);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV26Pgmname));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("product.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV15ProductId,6,0))}, new string[] {"Gx_mode","ProductId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Product" ;
      }

      public override string GetPgmdesc( )
      {
         return "Product" ;
      }

      protected void InitializeNonKey055( )
      {
         A1BrandId = 0;
         n1BrandId = false;
         AssignAttri("", false, "A1BrandId", StringUtil.LTrimStr( (decimal)(A1BrandId), 6, 0));
         n1BrandId = ((0==A1BrandId) ? true : false);
         A4SupplierId = 0;
         AssignAttri("", false, "A4SupplierId", StringUtil.LTrimStr( (decimal)(A4SupplierId), 6, 0));
         A9SectorId = 0;
         n9SectorId = false;
         AssignAttri("", false, "A9SectorId", StringUtil.LTrimStr( (decimal)(A9SectorId), 6, 0));
         n9SectorId = ((0==A9SectorId) ? true : false);
         A110ProductActive = false;
         n110ProductActive = false;
         AssignAttri("", false, "A110ProductActive", A110ProductActive);
         A88ProductWholesalePrice = 0;
         AssignAttri("", false, "A88ProductWholesalePrice", StringUtil.LTrimStr( A88ProductWholesalePrice, 18, 2));
         A90ProductRetailPrice = 0;
         AssignAttri("", false, "A90ProductRetailPrice", StringUtil.LTrimStr( A90ProductRetailPrice, 18, 2));
         A55ProductCode = "";
         n55ProductCode = false;
         AssignAttri("", false, "A55ProductCode", A55ProductCode);
         n55ProductCode = (String.IsNullOrEmpty(StringUtil.RTrim( A55ProductCode)) ? true : false);
         A16ProductName = "";
         AssignAttri("", false, "A16ProductName", A16ProductName);
         A85ProductCostPrice = 0;
         n85ProductCostPrice = false;
         AssignAttri("", false, "A85ProductCostPrice", StringUtil.LTrimStr( A85ProductCostPrice, 18, 2));
         n85ProductCostPrice = ((Convert.ToDecimal(0)==A85ProductCostPrice) ? true : false);
         A2BrandName = "";
         AssignAttri("", false, "A2BrandName", A2BrandName);
         A5SupplierName = "";
         AssignAttri("", false, "A5SupplierName", A5SupplierName);
         A10SectorName = "";
         AssignAttri("", false, "A10SectorName", A10SectorName);
         A19ProductDescription = "";
         n19ProductDescription = false;
         AssignAttri("", false, "A19ProductDescription", A19ProductDescription);
         n19ProductDescription = (String.IsNullOrEmpty(StringUtil.RTrim( A19ProductDescription)) ? true : false);
         A28ProductCreatedDate = DateTime.MinValue;
         AssignAttri("", false, "A28ProductCreatedDate", context.localUtil.Format(A28ProductCreatedDate, "99/99/9999"));
         A29ProductModifiedDate = DateTime.MinValue;
         AssignAttri("", false, "A29ProductModifiedDate", context.localUtil.Format(A29ProductModifiedDate, "99/99/9999"));
         A89ProductRetailProfit = 0;
         n89ProductRetailProfit = false;
         AssignAttri("", false, "A89ProductRetailProfit", StringUtil.LTrimStr( A89ProductRetailProfit, 8, 2));
         A87ProductWholesaleProfit = 0;
         n87ProductWholesaleProfit = false;
         AssignAttri("", false, "A87ProductWholesaleProfit", StringUtil.LTrimStr( A87ProductWholesaleProfit, 8, 2));
         A17ProductStock = 0;
         n17ProductStock = false;
         AssignAttri("", false, "A17ProductStock", StringUtil.LTrimStr( (decimal)(A17ProductStock), 6, 0));
         A69ProductMiniumStock = 0;
         n69ProductMiniumStock = false;
         AssignAttri("", false, "A69ProductMiniumStock", StringUtil.LTrimStr( (decimal)(A69ProductMiniumStock), 6, 0));
         A93ProductMiniumQuantityWholesale = 0;
         n93ProductMiniumQuantityWholesale = false;
         AssignAttri("", false, "A93ProductMiniumQuantityWholesale", StringUtil.LTrimStr( (decimal)(A93ProductMiniumQuantityWholesale), 4, 0));
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
         AssignAttri("", false, "A15ProductId", StringUtil.LTrimStr( (decimal)(A15ProductId), 6, 0));
         InitializeNonKey055( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A17ProductStock = i17ProductStock;
         n17ProductStock = false;
         AssignAttri("", false, "A17ProductStock", StringUtil.LTrimStr( (decimal)(A17ProductStock), 6, 0));
         A69ProductMiniumStock = i69ProductMiniumStock;
         n69ProductMiniumStock = false;
         AssignAttri("", false, "A69ProductMiniumStock", StringUtil.LTrimStr( (decimal)(A69ProductMiniumStock), 6, 0));
         A93ProductMiniumQuantityWholesale = i93ProductMiniumQuantityWholesale;
         n93ProductMiniumQuantityWholesale = false;
         AssignAttri("", false, "A93ProductMiniumQuantityWholesale", StringUtil.LTrimStr( (decimal)(A93ProductMiniumQuantityWholesale), 4, 0));
         A89ProductRetailProfit = i89ProductRetailProfit;
         n89ProductRetailProfit = false;
         AssignAttri("", false, "A89ProductRetailProfit", StringUtil.LTrimStr( A89ProductRetailProfit, 8, 2));
         A87ProductWholesaleProfit = i87ProductWholesaleProfit;
         n87ProductWholesaleProfit = false;
         AssignAttri("", false, "A87ProductWholesaleProfit", StringUtil.LTrimStr( A87ProductWholesaleProfit, 8, 2));
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024112313472079", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.eng.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("gxdec.js", "?"+context.GetBuildNumber( 1853160), false, true);
         context.AddJavascriptSource("product.js", "?2024112313472079", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtProductCode_Internalname = "PRODUCTCODE";
         edtProductName_Internalname = "PRODUCTNAME";
         edtProductCostPrice_Internalname = "PRODUCTCOSTPRICE";
         edtProductRetailProfit_Internalname = "PRODUCTRETAILPROFIT";
         edtProductRetailPrice_Internalname = "PRODUCTRETAILPRICE";
         edtProductMiniumQuantityWholesale_Internalname = "PRODUCTMINIUMQUANTITYWHOLESALE";
         edtProductWholesaleProfit_Internalname = "PRODUCTWHOLESALEPROFIT";
         edtProductWholesalePrice_Internalname = "PRODUCTWHOLESALEPRICE";
         dynBrandId_Internalname = "BRANDID";
         dynSupplierId_Internalname = "SUPPLIERID";
         dynSectorId_Internalname = "SECTORID";
         edtProductStock_Internalname = "PRODUCTSTOCK";
         edtProductMiniumStock_Internalname = "PRODUCTMINIUMSTOCK";
         edtProductDescription_Internalname = "PRODUCTDESCRIPTION";
         cmbavProductstate_Internalname = "vPRODUCTSTATE";
         chkavProductexist_Internalname = "vPRODUCTEXIST";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("mtaKB", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Product";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         chkavProductexist.Enabled = 0;
         cmbavProductstate_Jsonclick = "";
         cmbavProductstate.Enabled = 0;
         edtProductDescription_Enabled = 1;
         edtProductMiniumStock_Jsonclick = "";
         edtProductMiniumStock_Enabled = 1;
         edtProductStock_Jsonclick = "";
         edtProductStock_Enabled = 1;
         dynSectorId_Jsonclick = "";
         dynSectorId.Enabled = 1;
         dynSupplierId_Jsonclick = "";
         dynSupplierId.Enabled = 1;
         dynBrandId_Jsonclick = "";
         dynBrandId.Enabled = 1;
         edtProductWholesalePrice_Jsonclick = "";
         edtProductWholesalePrice_Enabled = 0;
         edtProductWholesaleProfit_Jsonclick = "";
         edtProductWholesaleProfit_Enabled = 1;
         edtProductMiniumQuantityWholesale_Jsonclick = "";
         edtProductMiniumQuantityWholesale_Enabled = 1;
         edtProductRetailPrice_Jsonclick = "";
         edtProductRetailPrice_Enabled = 0;
         edtProductRetailProfit_Jsonclick = "";
         edtProductRetailProfit_Enabled = 1;
         edtProductCostPrice_Jsonclick = "";
         edtProductCostPrice_Enabled = 1;
         edtProductName_Jsonclick = "";
         edtProductName_Enabled = 1;
         edtProductCode_Jsonclick = "";
         edtProductCode_Enabled = 1;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLABRANDID055( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLABRANDID_data055( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXABRANDID_html055( )
      {
         int gxdynajaxvalue;
         GXDLABRANDID_data055( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynBrandId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynBrandId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 6, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLABRANDID_data055( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(None)");
         /* Using cursor T000524 */
         pr_default.execute(22);
         while ( (pr_default.getStatus(22) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000524_A1BrandId[0]), 6, 0, ".", "")));
            gxdynajaxctrldescr.Add(T000524_A2BrandName[0]);
            pr_default.readNext(22);
         }
         pr_default.close(22);
      }

      protected void GXDLASUPPLIERID055( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLASUPPLIERID_data055( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXASUPPLIERID_html055( )
      {
         int gxdynajaxvalue;
         GXDLASUPPLIERID_data055( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynSupplierId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynSupplierId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 6, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLASUPPLIERID_data055( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(None)");
         /* Using cursor T000525 */
         pr_default.execute(23);
         while ( (pr_default.getStatus(23) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000525_A4SupplierId[0]), 6, 0, ".", "")));
            gxdynajaxctrldescr.Add(T000525_A5SupplierName[0]);
            pr_default.readNext(23);
         }
         pr_default.close(23);
      }

      protected void GXDLASECTORID055( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLASECTORID_data055( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXASECTORID_html055( )
      {
         int gxdynajaxvalue;
         GXDLASECTORID_data055( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynSectorId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynSectorId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 6, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLASECTORID_data055( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(None)");
         /* Using cursor T000526 */
         pr_default.execute(24);
         while ( (pr_default.getStatus(24) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000526_A9SectorId[0]), 6, 0, ".", "")));
            gxdynajaxctrldescr.Add(T000526_A10SectorName[0]);
            pr_default.readNext(24);
         }
         pr_default.close(24);
      }

      protected void GX6ASAPRODUCTRETAILPRICE055( decimal A89ProductRetailProfit ,
                                                  decimal A85ProductCostPrice )
      {
         GXt_decimal4 = A90ProductRetailPrice;
         new roundvalue(context ).execute(  A85ProductCostPrice*(1+A89ProductRetailProfit/ (decimal)(100)), out  GXt_decimal4) ;
         GXt_decimal3 = A90ProductRetailPrice;
         new roundvalue(context ).execute(  A85ProductCostPrice*(1+A89ProductRetailProfit/ (decimal)(100)), out  GXt_decimal3) ;
         GXt_decimal2 = A90ProductRetailPrice;
         new roundvalue(context ).execute(  A85ProductCostPrice, out  GXt_decimal2) ;
         A90ProductRetailPrice = ((A89ProductRetailProfit!=Convert.ToDecimal(0)) ? GXt_decimal3 : GXt_decimal2);
         AssignAttri("", false, "A90ProductRetailPrice", StringUtil.LTrimStr( A90ProductRetailPrice, 18, 2));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A90ProductRetailPrice, 18, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX7ASAPRODUCTWHOLESALEPRICE055( decimal A87ProductWholesaleProfit ,
                                                     decimal A85ProductCostPrice )
      {
         GXt_decimal4 = A88ProductWholesalePrice;
         new roundvalue(context ).execute(  A85ProductCostPrice*(1+A87ProductWholesaleProfit/ (decimal)(100)), out  GXt_decimal4) ;
         GXt_decimal3 = A88ProductWholesalePrice;
         new roundvalue(context ).execute(  A85ProductCostPrice*(1+A87ProductWholesaleProfit/ (decimal)(100)), out  GXt_decimal3) ;
         GXt_decimal2 = A88ProductWholesalePrice;
         new roundvalue(context ).execute(  A85ProductCostPrice, out  GXt_decimal2) ;
         A88ProductWholesalePrice = ((A87ProductWholesaleProfit!=Convert.ToDecimal(0)) ? GXt_decimal3 : GXt_decimal2);
         AssignAttri("", false, "A88ProductWholesalePrice", StringUtil.LTrimStr( A88ProductWholesalePrice, 18, 2));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A88ProductWholesalePrice, 18, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_34_055( decimal A85ProductCostPrice )
      {
         if ( (Convert.ToDecimal(0)==A85ProductCostPrice) )
         {
            new productcostpriceroundvalue(context ).execute( ref  A85ProductCostPrice) ;
            AssignAttri("", false, "A85ProductCostPrice", StringUtil.LTrimStr( A85ProductCostPrice, 18, 2));
            n85ProductCostPrice = ((Convert.ToDecimal(0)==A85ProductCostPrice) ? true : false);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A85ProductCostPrice, 18, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void init_web_controls( )
      {
         dynBrandId.Name = "BRANDID";
         dynBrandId.WebTags = "";
         dynSupplierId.Name = "SUPPLIERID";
         dynSupplierId.WebTags = "";
         dynSectorId.Name = "SECTORID";
         dynSectorId.WebTags = "";
         cmbavProductstate.Name = "vPRODUCTSTATE";
         cmbavProductstate.WebTags = "";
         cmbavProductstate.addItem("Active", "Active", 0);
         cmbavProductstate.addItem("Deactive", "Deactive", 0);
         cmbavProductstate.addItem("Enabled", "Enabled", 0);
         cmbavProductstate.addItem("Disabled", "Disabled", 0);
         if ( cmbavProductstate.ItemCount > 0 )
         {
            AV16ProductState = cmbavProductstate.getValidValue(AV16ProductState);
            AssignAttri("", false, "AV16ProductState", AV16ProductState);
         }
         chkavProductexist.Name = "vPRODUCTEXIST";
         chkavProductexist.WebTags = "";
         chkavProductexist.Caption = "";
         AssignProp("", false, chkavProductexist_Internalname, "TitleCaption", chkavProductexist.Caption, true);
         chkavProductexist.CheckedValue = "false";
         AV21ProductExist = StringUtil.StrToBool( StringUtil.BoolToStr( AV21ProductExist));
         AssignAttri("", false, "AV21ProductExist", AV21ProductExist);
         /* End function init_web_controls */
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

      public void Valid_Productcostprice( )
      {
         n85ProductCostPrice = false;
         n1BrandId = false;
         A1BrandId = (int)(Math.Round(NumberUtil.Val( dynBrandId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n1BrandId = false;
         A4SupplierId = (int)(Math.Round(NumberUtil.Val( dynSupplierId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n9SectorId = false;
         A9SectorId = (int)(Math.Round(NumberUtil.Val( dynSectorId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n9SectorId = false;
         if ( ! ( ( ( A85ProductCostPrice >= Convert.ToDecimal( 0 )) && ( A85ProductCostPrice <= 999999999999999.99m ) ) || (Convert.ToDecimal(0)==A85ProductCostPrice) ) )
         {
            GX_msglist.addItem("Invalid Price", "OutOfRange", 1, "PRODUCTCOSTPRICE");
            AnyError = 1;
            GX_FocusControl = edtProductCostPrice_Internalname;
         }
         if ( (Convert.ToDecimal(0)==A85ProductCostPrice) )
         {
            GX_msglist.addItem("Price is Required", 1, "PRODUCTCOSTPRICE");
            AnyError = 1;
            GX_FocusControl = edtProductCostPrice_Internalname;
         }
         if ( (Convert.ToDecimal(0)==A85ProductCostPrice) )
         {
            new productcostpriceroundvalue(context ).execute( ref  A85ProductCostPrice) ;
            n85ProductCostPrice = ((Convert.ToDecimal(0)==A85ProductCostPrice) ? true : false);
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A85ProductCostPrice", StringUtil.LTrim( StringUtil.NToC( A85ProductCostPrice, 18, 2, ".", "")));
      }

      public void Valid_Productretailprofit( )
      {
         n89ProductRetailProfit = false;
         n85ProductCostPrice = false;
         n1BrandId = false;
         A1BrandId = (int)(Math.Round(NumberUtil.Val( dynBrandId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n1BrandId = false;
         A4SupplierId = (int)(Math.Round(NumberUtil.Val( dynSupplierId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n9SectorId = false;
         A9SectorId = (int)(Math.Round(NumberUtil.Val( dynSectorId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n9SectorId = false;
         if ( ! ( ( ( A89ProductRetailProfit >= Convert.ToDecimal( -999 )) && ( A89ProductRetailProfit <= Convert.ToDecimal( 999 )) ) || (Convert.ToDecimal(0)==A89ProductRetailProfit) ) )
         {
            GX_msglist.addItem("Field Product Retail Profit is out of range", "OutOfRange", 1, "PRODUCTRETAILPROFIT");
            AnyError = 1;
            GX_FocusControl = edtProductRetailProfit_Internalname;
         }
         GXt_decimal4 = A90ProductRetailPrice;
         new roundvalue(context ).execute(  A85ProductCostPrice*(1+A89ProductRetailProfit/ (decimal)(100)), out  GXt_decimal4) ;
         GXt_decimal3 = A90ProductRetailPrice;
         new roundvalue(context ).execute(  A85ProductCostPrice*(1+A89ProductRetailProfit/ (decimal)(100)), out  GXt_decimal3) ;
         GXt_decimal2 = A90ProductRetailPrice;
         new roundvalue(context ).execute(  A85ProductCostPrice, out  GXt_decimal2) ;
         A90ProductRetailPrice = ((A89ProductRetailProfit!=Convert.ToDecimal(0)) ? GXt_decimal3 : GXt_decimal2);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A90ProductRetailPrice", StringUtil.LTrim( StringUtil.NToC( A90ProductRetailPrice, 18, 2, ".", "")));
      }

      public void Valid_Productwholesaleprofit( )
      {
         n87ProductWholesaleProfit = false;
         n85ProductCostPrice = false;
         n89ProductRetailProfit = false;
         n93ProductMiniumQuantityWholesale = false;
         n1BrandId = false;
         A1BrandId = (int)(Math.Round(NumberUtil.Val( dynBrandId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n1BrandId = false;
         A4SupplierId = (int)(Math.Round(NumberUtil.Val( dynSupplierId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n9SectorId = false;
         A9SectorId = (int)(Math.Round(NumberUtil.Val( dynSectorId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n9SectorId = false;
         if ( ! ( ( ( A87ProductWholesaleProfit >= Convert.ToDecimal( -999 )) && ( A87ProductWholesaleProfit <= Convert.ToDecimal( 999 )) ) || (Convert.ToDecimal(0)==A87ProductWholesaleProfit) ) )
         {
            GX_msglist.addItem("Field Product Wholesale Profit is out of range", "OutOfRange", 1, "PRODUCTWHOLESALEPROFIT");
            AnyError = 1;
            GX_FocusControl = edtProductWholesaleProfit_Internalname;
         }
         GXt_decimal4 = A88ProductWholesalePrice;
         new roundvalue(context ).execute(  A85ProductCostPrice*(1+A87ProductWholesaleProfit/ (decimal)(100)), out  GXt_decimal4) ;
         GXt_decimal3 = A88ProductWholesalePrice;
         new roundvalue(context ).execute(  A85ProductCostPrice*(1+A87ProductWholesaleProfit/ (decimal)(100)), out  GXt_decimal3) ;
         GXt_decimal2 = A88ProductWholesalePrice;
         new roundvalue(context ).execute(  A85ProductCostPrice, out  GXt_decimal2) ;
         A88ProductWholesalePrice = ((A87ProductWholesaleProfit!=Convert.ToDecimal(0)) ? GXt_decimal3 : GXt_decimal2);
         if ( ( A89ProductRetailProfit != A87ProductWholesaleProfit ) && (0==A93ProductMiniumQuantityWholesale) )
         {
            GX_msglist.addItem("Retail Profit and Wholesale Profit must be equals when Min. Qty. Wholesale is not defined", 1, "PRODUCTWHOLESALEPROFIT");
            AnyError = 1;
            GX_FocusControl = edtProductWholesaleProfit_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A88ProductWholesalePrice", StringUtil.LTrim( StringUtil.NToC( A88ProductWholesalePrice, 18, 2, ".", "")));
      }

      public void Valid_Brandid( )
      {
         n1BrandId = false;
         A1BrandId = (int)(Math.Round(NumberUtil.Val( dynBrandId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n1BrandId = false;
         A4SupplierId = (int)(Math.Round(NumberUtil.Val( dynSupplierId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n9SectorId = false;
         A9SectorId = (int)(Math.Round(NumberUtil.Val( dynSectorId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n9SectorId = false;
         /* Using cursor T000527 */
         pr_default.execute(25, new Object[] {n1BrandId, A1BrandId});
         if ( (pr_default.getStatus(25) == 101) )
         {
            if ( ! ( (0==A1BrandId) ) )
            {
               GX_msglist.addItem("No matching 'Brand'.", "ForeignKeyNotFound", 1, "BRANDID");
               AnyError = 1;
               GX_FocusControl = dynBrandId_Internalname;
            }
         }
         A2BrandName = T000527_A2BrandName[0];
         pr_default.close(25);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2BrandName", A2BrandName);
      }

      public void Valid_Supplierid( )
      {
         n1BrandId = false;
         A1BrandId = (int)(Math.Round(NumberUtil.Val( dynBrandId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n1BrandId = false;
         A4SupplierId = (int)(Math.Round(NumberUtil.Val( dynSupplierId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n9SectorId = false;
         A9SectorId = (int)(Math.Round(NumberUtil.Val( dynSectorId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n9SectorId = false;
         /* Using cursor T000528 */
         pr_default.execute(26, new Object[] {A4SupplierId});
         if ( (pr_default.getStatus(26) == 101) )
         {
            GX_msglist.addItem("No matching 'Supplier'.", "ForeignKeyNotFound", 1, "SUPPLIERID");
            AnyError = 1;
            GX_FocusControl = dynSupplierId_Internalname;
         }
         A5SupplierName = T000528_A5SupplierName[0];
         pr_default.close(26);
         /* Using cursor T000529 */
         pr_default.execute(27, new Object[] {A16ProductName, A4SupplierId, A15ProductId});
         if ( (pr_default.getStatus(27) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Product Name"+","+"Supplier Id"}), 1, "PRODUCTNAME");
            AnyError = 1;
            GX_FocusControl = edtProductName_Internalname;
         }
         pr_default.close(27);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A5SupplierName", A5SupplierName);
      }

      public void Valid_Sectorid( )
      {
         n1BrandId = false;
         A1BrandId = (int)(Math.Round(NumberUtil.Val( dynBrandId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n1BrandId = false;
         A4SupplierId = (int)(Math.Round(NumberUtil.Val( dynSupplierId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n9SectorId = false;
         A9SectorId = (int)(Math.Round(NumberUtil.Val( dynSectorId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n9SectorId = false;
         /* Using cursor T000530 */
         pr_default.execute(28, new Object[] {n9SectorId, A9SectorId});
         if ( (pr_default.getStatus(28) == 101) )
         {
            if ( ! ( (0==A9SectorId) ) )
            {
               GX_msglist.addItem("No matching 'Sector'.", "ForeignKeyNotFound", 1, "SECTORID");
               AnyError = 1;
               GX_FocusControl = dynSectorId_Internalname;
            }
         }
         A10SectorName = T000530_A10SectorName[0];
         pr_default.close(28);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A10SectorName", A10SectorName);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV15ProductId',fld:'vPRODUCTID',pic:'ZZZZZ9',hsh:true},{av:'dynBrandId'},{av:'A1BrandId',fld:'BRANDID',pic:'ZZZZZ9'},{av:'dynSupplierId'},{av:'A4SupplierId',fld:'SUPPLIERID',pic:'ZZZZZ9'},{av:'dynSectorId'},{av:'A9SectorId',fld:'SECTORID',pic:'ZZZZZ9'},{av:'AV21ProductExist',fld:'vPRODUCTEXIST',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'dynBrandId'},{av:'A1BrandId',fld:'BRANDID',pic:'ZZZZZ9'},{av:'dynSupplierId'},{av:'A4SupplierId',fld:'SUPPLIERID',pic:'ZZZZZ9'},{av:'dynSectorId'},{av:'A9SectorId',fld:'SECTORID',pic:'ZZZZZ9'},{av:'AV21ProductExist',fld:'vPRODUCTEXIST',pic:''}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV22ErrorMessages',fld:'vERRORMESSAGES',pic:'',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV18ProductIdAux',fld:'vPRODUCTIDAUX',pic:'ZZZZZ9',hsh:true},{av:'AV15ProductId',fld:'vPRODUCTID',pic:'ZZZZZ9',hsh:true},{av:'A15ProductId',fld:'PRODUCTID',pic:'ZZZZZ9'},{av:'A28ProductCreatedDate',fld:'PRODUCTCREATEDDATE',pic:''},{av:'A29ProductModifiedDate',fld:'PRODUCTMODIFIEDDATE',pic:''},{av:'dynBrandId'},{av:'A1BrandId',fld:'BRANDID',pic:'ZZZZZ9'},{av:'dynSupplierId'},{av:'A4SupplierId',fld:'SUPPLIERID',pic:'ZZZZZ9'},{av:'dynSectorId'},{av:'A9SectorId',fld:'SECTORID',pic:'ZZZZZ9'},{av:'AV21ProductExist',fld:'vPRODUCTEXIST',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'dynBrandId'},{av:'A1BrandId',fld:'BRANDID',pic:'ZZZZZ9'},{av:'dynSupplierId'},{av:'A4SupplierId',fld:'SUPPLIERID',pic:'ZZZZZ9'},{av:'dynSectorId'},{av:'A9SectorId',fld:'SECTORID',pic:'ZZZZZ9'},{av:'AV21ProductExist',fld:'vPRODUCTEXIST',pic:''}]}");
         setEventMetadata("AFTER TRN","{handler:'E12052',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'A15ProductId',fld:'PRODUCTID',pic:'ZZZZZ9'},{av:'AV22ErrorMessages',fld:'vERRORMESSAGES',pic:'',hsh:true},{av:'A85ProductCostPrice',fld:'PRODUCTCOSTPRICE',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'dynBrandId'},{av:'A1BrandId',fld:'BRANDID',pic:'ZZZZZ9'},{av:'dynSupplierId'},{av:'A4SupplierId',fld:'SUPPLIERID',pic:'ZZZZZ9'},{av:'dynSectorId'},{av:'A9SectorId',fld:'SECTORID',pic:'ZZZZZ9'},{av:'AV21ProductExist',fld:'vPRODUCTEXIST',pic:''}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'AV22ErrorMessages',fld:'vERRORMESSAGES',pic:'',hsh:true},{av:'A85ProductCostPrice',fld:'PRODUCTCOSTPRICE',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'dynBrandId'},{av:'A1BrandId',fld:'BRANDID',pic:'ZZZZZ9'},{av:'dynSupplierId'},{av:'A4SupplierId',fld:'SUPPLIERID',pic:'ZZZZZ9'},{av:'dynSectorId'},{av:'A9SectorId',fld:'SECTORID',pic:'ZZZZZ9'},{av:'AV21ProductExist',fld:'vPRODUCTEXIST',pic:''}]}");
         setEventMetadata("PRODUCTCODE.CONTROLVALUECHANGED","{handler:'E13052',iparms:[{av:'A55ProductCode',fld:'PRODUCTCODE',pic:''},{av:'AV18ProductIdAux',fld:'vPRODUCTIDAUX',pic:'ZZZZZ9',hsh:true},{av:'A85ProductCostPrice',fld:'PRODUCTCOSTPRICE',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'A89ProductRetailProfit',fld:'PRODUCTRETAILPROFIT',pic:'ZZZZ9.99'},{av:'A93ProductMiniumQuantityWholesale',fld:'PRODUCTMINIUMQUANTITYWHOLESALE',pic:'ZZZ9'},{av:'A87ProductWholesaleProfit',fld:'PRODUCTWHOLESALEPROFIT',pic:'ZZZZ9.99'},{av:'A69ProductMiniumStock',fld:'PRODUCTMINIUMSTOCK',pic:'ZZZZZ9'},{av:'A19ProductDescription',fld:'PRODUCTDESCRIPTION',pic:''},{av:'dynBrandId'},{av:'A1BrandId',fld:'BRANDID',pic:'ZZZZZ9'},{av:'dynSupplierId'},{av:'A4SupplierId',fld:'SUPPLIERID',pic:'ZZZZZ9'},{av:'dynSectorId'},{av:'A9SectorId',fld:'SECTORID',pic:'ZZZZZ9'},{av:'AV21ProductExist',fld:'vPRODUCTEXIST',pic:''}]");
         setEventMetadata("PRODUCTCODE.CONTROLVALUECHANGED",",oparms:[{av:'A19ProductDescription',fld:'PRODUCTDESCRIPTION',pic:''},{av:'A69ProductMiniumStock',fld:'PRODUCTMINIUMSTOCK',pic:'ZZZZZ9'},{av:'A87ProductWholesaleProfit',fld:'PRODUCTWHOLESALEPROFIT',pic:'ZZZZ9.99'},{av:'A93ProductMiniumQuantityWholesale',fld:'PRODUCTMINIUMQUANTITYWHOLESALE',pic:'ZZZ9'},{av:'A89ProductRetailProfit',fld:'PRODUCTRETAILPROFIT',pic:'ZZZZ9.99'},{av:'A85ProductCostPrice',fld:'PRODUCTCOSTPRICE',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'A16ProductName',fld:'PRODUCTNAME',pic:''},{av:'edtProductName_Enabled',ctrl:'PRODUCTNAME',prop:'Enabled'},{av:'edtProductDescription_Enabled',ctrl:'PRODUCTDESCRIPTION',prop:'Enabled'},{av:'dynBrandId'},{av:'A1BrandId',fld:'BRANDID',pic:'ZZZZZ9'},{av:'dynSupplierId'},{av:'A4SupplierId',fld:'SUPPLIERID',pic:'ZZZZZ9'},{av:'dynSectorId'},{av:'A9SectorId',fld:'SECTORID',pic:'ZZZZZ9'},{av:'AV21ProductExist',fld:'vPRODUCTEXIST',pic:''}]}");
         setEventMetadata("PRODUCTCOSTPRICE.CONTROLVALUECHANGED","{handler:'E14052',iparms:[{av:'A85ProductCostPrice',fld:'PRODUCTCOSTPRICE',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'dynBrandId'},{av:'A1BrandId',fld:'BRANDID',pic:'ZZZZZ9'},{av:'dynSupplierId'},{av:'A4SupplierId',fld:'SUPPLIERID',pic:'ZZZZZ9'},{av:'dynSectorId'},{av:'A9SectorId',fld:'SECTORID',pic:'ZZZZZ9'},{av:'AV21ProductExist',fld:'vPRODUCTEXIST',pic:''}]");
         setEventMetadata("PRODUCTCOSTPRICE.CONTROLVALUECHANGED",",oparms:[{av:'A85ProductCostPrice',fld:'PRODUCTCOSTPRICE',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'dynBrandId'},{av:'A1BrandId',fld:'BRANDID',pic:'ZZZZZ9'},{av:'dynSupplierId'},{av:'A4SupplierId',fld:'SUPPLIERID',pic:'ZZZZZ9'},{av:'dynSectorId'},{av:'A9SectorId',fld:'SECTORID',pic:'ZZZZZ9'},{av:'AV21ProductExist',fld:'vPRODUCTEXIST',pic:''}]}");
         setEventMetadata("VALID_PRODUCTNAME","{handler:'Valid_Productname',iparms:[{av:'dynBrandId'},{av:'A1BrandId',fld:'BRANDID',pic:'ZZZZZ9'},{av:'dynSupplierId'},{av:'A4SupplierId',fld:'SUPPLIERID',pic:'ZZZZZ9'},{av:'dynSectorId'},{av:'A9SectorId',fld:'SECTORID',pic:'ZZZZZ9'},{av:'AV21ProductExist',fld:'vPRODUCTEXIST',pic:''}]");
         setEventMetadata("VALID_PRODUCTNAME",",oparms:[{av:'dynBrandId'},{av:'A1BrandId',fld:'BRANDID',pic:'ZZZZZ9'},{av:'dynSupplierId'},{av:'A4SupplierId',fld:'SUPPLIERID',pic:'ZZZZZ9'},{av:'dynSectorId'},{av:'A9SectorId',fld:'SECTORID',pic:'ZZZZZ9'},{av:'AV21ProductExist',fld:'vPRODUCTEXIST',pic:''}]}");
         setEventMetadata("VALID_PRODUCTCOSTPRICE","{handler:'Valid_Productcostprice',iparms:[{av:'A85ProductCostPrice',fld:'PRODUCTCOSTPRICE',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'dynBrandId'},{av:'A1BrandId',fld:'BRANDID',pic:'ZZZZZ9'},{av:'dynSupplierId'},{av:'A4SupplierId',fld:'SUPPLIERID',pic:'ZZZZZ9'},{av:'dynSectorId'},{av:'A9SectorId',fld:'SECTORID',pic:'ZZZZZ9'},{av:'AV21ProductExist',fld:'vPRODUCTEXIST',pic:''}]");
         setEventMetadata("VALID_PRODUCTCOSTPRICE",",oparms:[{av:'A85ProductCostPrice',fld:'PRODUCTCOSTPRICE',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'dynBrandId'},{av:'A1BrandId',fld:'BRANDID',pic:'ZZZZZ9'},{av:'dynSupplierId'},{av:'A4SupplierId',fld:'SUPPLIERID',pic:'ZZZZZ9'},{av:'dynSectorId'},{av:'A9SectorId',fld:'SECTORID',pic:'ZZZZZ9'},{av:'AV21ProductExist',fld:'vPRODUCTEXIST',pic:''}]}");
         setEventMetadata("VALID_PRODUCTRETAILPROFIT","{handler:'Valid_Productretailprofit',iparms:[{av:'A89ProductRetailProfit',fld:'PRODUCTRETAILPROFIT',pic:'ZZZZ9.99'},{av:'A85ProductCostPrice',fld:'PRODUCTCOSTPRICE',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'A90ProductRetailPrice',fld:'PRODUCTRETAILPRICE',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'dynBrandId'},{av:'A1BrandId',fld:'BRANDID',pic:'ZZZZZ9'},{av:'dynSupplierId'},{av:'A4SupplierId',fld:'SUPPLIERID',pic:'ZZZZZ9'},{av:'dynSectorId'},{av:'A9SectorId',fld:'SECTORID',pic:'ZZZZZ9'},{av:'AV21ProductExist',fld:'vPRODUCTEXIST',pic:''}]");
         setEventMetadata("VALID_PRODUCTRETAILPROFIT",",oparms:[{av:'A90ProductRetailPrice',fld:'PRODUCTRETAILPRICE',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'dynBrandId'},{av:'A1BrandId',fld:'BRANDID',pic:'ZZZZZ9'},{av:'dynSupplierId'},{av:'A4SupplierId',fld:'SUPPLIERID',pic:'ZZZZZ9'},{av:'dynSectorId'},{av:'A9SectorId',fld:'SECTORID',pic:'ZZZZZ9'},{av:'AV21ProductExist',fld:'vPRODUCTEXIST',pic:''}]}");
         setEventMetadata("VALID_PRODUCTMINIUMQUANTITYWHOLESALE","{handler:'Valid_Productminiumquantitywholesale',iparms:[{av:'dynBrandId'},{av:'A1BrandId',fld:'BRANDID',pic:'ZZZZZ9'},{av:'dynSupplierId'},{av:'A4SupplierId',fld:'SUPPLIERID',pic:'ZZZZZ9'},{av:'dynSectorId'},{av:'A9SectorId',fld:'SECTORID',pic:'ZZZZZ9'},{av:'AV21ProductExist',fld:'vPRODUCTEXIST',pic:''}]");
         setEventMetadata("VALID_PRODUCTMINIUMQUANTITYWHOLESALE",",oparms:[{av:'dynBrandId'},{av:'A1BrandId',fld:'BRANDID',pic:'ZZZZZ9'},{av:'dynSupplierId'},{av:'A4SupplierId',fld:'SUPPLIERID',pic:'ZZZZZ9'},{av:'dynSectorId'},{av:'A9SectorId',fld:'SECTORID',pic:'ZZZZZ9'},{av:'AV21ProductExist',fld:'vPRODUCTEXIST',pic:''}]}");
         setEventMetadata("VALID_PRODUCTWHOLESALEPROFIT","{handler:'Valid_Productwholesaleprofit',iparms:[{av:'A87ProductWholesaleProfit',fld:'PRODUCTWHOLESALEPROFIT',pic:'ZZZZ9.99'},{av:'A85ProductCostPrice',fld:'PRODUCTCOSTPRICE',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'A89ProductRetailProfit',fld:'PRODUCTRETAILPROFIT',pic:'ZZZZ9.99'},{av:'A93ProductMiniumQuantityWholesale',fld:'PRODUCTMINIUMQUANTITYWHOLESALE',pic:'ZZZ9'},{av:'A88ProductWholesalePrice',fld:'PRODUCTWHOLESALEPRICE',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'dynBrandId'},{av:'A1BrandId',fld:'BRANDID',pic:'ZZZZZ9'},{av:'dynSupplierId'},{av:'A4SupplierId',fld:'SUPPLIERID',pic:'ZZZZZ9'},{av:'dynSectorId'},{av:'A9SectorId',fld:'SECTORID',pic:'ZZZZZ9'},{av:'AV21ProductExist',fld:'vPRODUCTEXIST',pic:''}]");
         setEventMetadata("VALID_PRODUCTWHOLESALEPROFIT",",oparms:[{av:'A88ProductWholesalePrice',fld:'PRODUCTWHOLESALEPRICE',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'dynBrandId'},{av:'A1BrandId',fld:'BRANDID',pic:'ZZZZZ9'},{av:'dynSupplierId'},{av:'A4SupplierId',fld:'SUPPLIERID',pic:'ZZZZZ9'},{av:'dynSectorId'},{av:'A9SectorId',fld:'SECTORID',pic:'ZZZZZ9'},{av:'AV21ProductExist',fld:'vPRODUCTEXIST',pic:''}]}");
         setEventMetadata("VALID_BRANDID","{handler:'Valid_Brandid',iparms:[{av:'A2BrandName',fld:'BRANDNAME',pic:''},{av:'dynBrandId'},{av:'A1BrandId',fld:'BRANDID',pic:'ZZZZZ9'},{av:'dynSupplierId'},{av:'A4SupplierId',fld:'SUPPLIERID',pic:'ZZZZZ9'},{av:'dynSectorId'},{av:'A9SectorId',fld:'SECTORID',pic:'ZZZZZ9'},{av:'AV21ProductExist',fld:'vPRODUCTEXIST',pic:''}]");
         setEventMetadata("VALID_BRANDID",",oparms:[{av:'A2BrandName',fld:'BRANDNAME',pic:''},{av:'dynBrandId'},{av:'A1BrandId',fld:'BRANDID',pic:'ZZZZZ9'},{av:'dynSupplierId'},{av:'A4SupplierId',fld:'SUPPLIERID',pic:'ZZZZZ9'},{av:'dynSectorId'},{av:'A9SectorId',fld:'SECTORID',pic:'ZZZZZ9'},{av:'AV21ProductExist',fld:'vPRODUCTEXIST',pic:''}]}");
         setEventMetadata("VALID_SUPPLIERID","{handler:'Valid_Supplierid',iparms:[{av:'A16ProductName',fld:'PRODUCTNAME',pic:''},{av:'A15ProductId',fld:'PRODUCTID',pic:'ZZZZZ9'},{av:'A5SupplierName',fld:'SUPPLIERNAME',pic:''},{av:'dynBrandId'},{av:'A1BrandId',fld:'BRANDID',pic:'ZZZZZ9'},{av:'dynSupplierId'},{av:'A4SupplierId',fld:'SUPPLIERID',pic:'ZZZZZ9'},{av:'dynSectorId'},{av:'A9SectorId',fld:'SECTORID',pic:'ZZZZZ9'},{av:'AV21ProductExist',fld:'vPRODUCTEXIST',pic:''}]");
         setEventMetadata("VALID_SUPPLIERID",",oparms:[{av:'A5SupplierName',fld:'SUPPLIERNAME',pic:''},{av:'dynBrandId'},{av:'A1BrandId',fld:'BRANDID',pic:'ZZZZZ9'},{av:'dynSupplierId'},{av:'A4SupplierId',fld:'SUPPLIERID',pic:'ZZZZZ9'},{av:'dynSectorId'},{av:'A9SectorId',fld:'SECTORID',pic:'ZZZZZ9'},{av:'AV21ProductExist',fld:'vPRODUCTEXIST',pic:''}]}");
         setEventMetadata("VALID_SECTORID","{handler:'Valid_Sectorid',iparms:[{av:'A10SectorName',fld:'SECTORNAME',pic:''},{av:'dynBrandId'},{av:'A1BrandId',fld:'BRANDID',pic:'ZZZZZ9'},{av:'dynSupplierId'},{av:'A4SupplierId',fld:'SUPPLIERID',pic:'ZZZZZ9'},{av:'dynSectorId'},{av:'A9SectorId',fld:'SECTORID',pic:'ZZZZZ9'},{av:'AV21ProductExist',fld:'vPRODUCTEXIST',pic:''}]");
         setEventMetadata("VALID_SECTORID",",oparms:[{av:'A10SectorName',fld:'SECTORNAME',pic:''},{av:'dynBrandId'},{av:'A1BrandId',fld:'BRANDID',pic:'ZZZZZ9'},{av:'dynSupplierId'},{av:'A4SupplierId',fld:'SUPPLIERID',pic:'ZZZZZ9'},{av:'dynSectorId'},{av:'A9SectorId',fld:'SECTORID',pic:'ZZZZZ9'},{av:'AV21ProductExist',fld:'vPRODUCTEXIST',pic:''}]}");
         return  ;
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
         pr_default.close(25);
         pr_default.close(16);
         pr_default.close(28);
         pr_default.close(18);
         pr_default.close(26);
         pr_default.close(17);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z55ProductCode = "";
         Z16ProductName = "";
         Z19ProductDescription = "";
         Z28ProductCreatedDate = DateTime.MinValue;
         Z29ProductModifiedDate = DateTime.MinValue;
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         AV16ProductState = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A55ProductCode = "";
         A16ProductName = "";
         A19ProductDescription = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         A28ProductCreatedDate = DateTime.MinValue;
         A29ProductModifiedDate = DateTime.MinValue;
         Gx_date = DateTime.MinValue;
         A2BrandName = "";
         A10SectorName = "";
         A5SupplierName = "";
         AV26Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode5 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXt_SdtSDTContextSession1 = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV14TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         AV22ErrorMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         T00053_n55ProductCode = new bool[] {false} ;
         Z2BrandName = "";
         Z5SupplierName = "";
         Z10SectorName = "";
         T00054_A2BrandName = new string[] {""} ;
         T00056_A5SupplierName = new string[] {""} ;
         T00055_A10SectorName = new string[] {""} ;
         T00057_A15ProductId = new int[1] ;
         T00057_A110ProductActive = new bool[] {false} ;
         T00057_n110ProductActive = new bool[] {false} ;
         T00057_A55ProductCode = new string[] {""} ;
         T00057_n55ProductCode = new bool[] {false} ;
         T00057_A16ProductName = new string[] {""} ;
         T00057_A85ProductCostPrice = new decimal[1] ;
         T00057_n85ProductCostPrice = new bool[] {false} ;
         T00057_A89ProductRetailProfit = new decimal[1] ;
         T00057_n89ProductRetailProfit = new bool[] {false} ;
         T00057_A87ProductWholesaleProfit = new decimal[1] ;
         T00057_n87ProductWholesaleProfit = new bool[] {false} ;
         T00057_A2BrandName = new string[] {""} ;
         T00057_A5SupplierName = new string[] {""} ;
         T00057_A10SectorName = new string[] {""} ;
         T00057_A17ProductStock = new int[1] ;
         T00057_n17ProductStock = new bool[] {false} ;
         T00057_A69ProductMiniumStock = new int[1] ;
         T00057_n69ProductMiniumStock = new bool[] {false} ;
         T00057_A19ProductDescription = new string[] {""} ;
         T00057_n19ProductDescription = new bool[] {false} ;
         T00057_A28ProductCreatedDate = new DateTime[] {DateTime.MinValue} ;
         T00057_A29ProductModifiedDate = new DateTime[] {DateTime.MinValue} ;
         T00057_A93ProductMiniumQuantityWholesale = new short[1] ;
         T00057_n93ProductMiniumQuantityWholesale = new bool[] {false} ;
         T00057_A1BrandId = new int[1] ;
         T00057_n1BrandId = new bool[] {false} ;
         T00057_A9SectorId = new int[1] ;
         T00057_n9SectorId = new bool[] {false} ;
         T00057_A4SupplierId = new int[1] ;
         T00058_A16ProductName = new string[] {""} ;
         T00059_A2BrandName = new string[] {""} ;
         T000510_A5SupplierName = new string[] {""} ;
         T000511_A10SectorName = new string[] {""} ;
         T000512_A15ProductId = new int[1] ;
         T00053_A15ProductId = new int[1] ;
         T00053_A110ProductActive = new bool[] {false} ;
         T00053_n110ProductActive = new bool[] {false} ;
         T00053_A55ProductCode = new string[] {""} ;
         T00053_A16ProductName = new string[] {""} ;
         T00053_A85ProductCostPrice = new decimal[1] ;
         T00053_n85ProductCostPrice = new bool[] {false} ;
         T00053_A89ProductRetailProfit = new decimal[1] ;
         T00053_n89ProductRetailProfit = new bool[] {false} ;
         T00053_A87ProductWholesaleProfit = new decimal[1] ;
         T00053_n87ProductWholesaleProfit = new bool[] {false} ;
         T00053_A17ProductStock = new int[1] ;
         T00053_n17ProductStock = new bool[] {false} ;
         T00053_A69ProductMiniumStock = new int[1] ;
         T00053_n69ProductMiniumStock = new bool[] {false} ;
         T00053_A19ProductDescription = new string[] {""} ;
         T00053_n19ProductDescription = new bool[] {false} ;
         T00053_A28ProductCreatedDate = new DateTime[] {DateTime.MinValue} ;
         T00053_A29ProductModifiedDate = new DateTime[] {DateTime.MinValue} ;
         T00053_A93ProductMiniumQuantityWholesale = new short[1] ;
         T00053_n93ProductMiniumQuantityWholesale = new bool[] {false} ;
         T00053_A1BrandId = new int[1] ;
         T00053_n1BrandId = new bool[] {false} ;
         T00053_A9SectorId = new int[1] ;
         T00053_n9SectorId = new bool[] {false} ;
         T00053_A4SupplierId = new int[1] ;
         T000513_A15ProductId = new int[1] ;
         T000514_A15ProductId = new int[1] ;
         T00052_A15ProductId = new int[1] ;
         T00052_A110ProductActive = new bool[] {false} ;
         T00052_n110ProductActive = new bool[] {false} ;
         T00052_A55ProductCode = new string[] {""} ;
         T00052_n55ProductCode = new bool[] {false} ;
         T00052_A16ProductName = new string[] {""} ;
         T00052_A85ProductCostPrice = new decimal[1] ;
         T00052_n85ProductCostPrice = new bool[] {false} ;
         T00052_A89ProductRetailProfit = new decimal[1] ;
         T00052_n89ProductRetailProfit = new bool[] {false} ;
         T00052_A87ProductWholesaleProfit = new decimal[1] ;
         T00052_n87ProductWholesaleProfit = new bool[] {false} ;
         T00052_A17ProductStock = new int[1] ;
         T00052_n17ProductStock = new bool[] {false} ;
         T00052_A69ProductMiniumStock = new int[1] ;
         T00052_n69ProductMiniumStock = new bool[] {false} ;
         T00052_A19ProductDescription = new string[] {""} ;
         T00052_n19ProductDescription = new bool[] {false} ;
         T00052_A28ProductCreatedDate = new DateTime[] {DateTime.MinValue} ;
         T00052_A29ProductModifiedDate = new DateTime[] {DateTime.MinValue} ;
         T00052_A93ProductMiniumQuantityWholesale = new short[1] ;
         T00052_n93ProductMiniumQuantityWholesale = new bool[] {false} ;
         T00052_A1BrandId = new int[1] ;
         T00052_n1BrandId = new bool[] {false} ;
         T00052_A9SectorId = new int[1] ;
         T00052_n9SectorId = new bool[] {false} ;
         T00052_A4SupplierId = new int[1] ;
         T000515_A15ProductId = new int[1] ;
         T000518_A2BrandName = new string[] {""} ;
         T000519_A5SupplierName = new string[] {""} ;
         T000520_A10SectorName = new string[] {""} ;
         T000521_A20InvoiceId = new int[1] ;
         T000521_A25InvoiceDetailId = new int[1] ;
         T000522_A50PurchaseOrderId = new int[1] ;
         T000522_A61PurchaseOrderDetailId = new int[1] ;
         T000523_A15ProductId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T000524_A1BrandId = new int[1] ;
         T000524_n1BrandId = new bool[] {false} ;
         T000524_A2BrandName = new string[] {""} ;
         T000525_A4SupplierId = new int[1] ;
         T000525_A5SupplierName = new string[] {""} ;
         T000526_A9SectorId = new int[1] ;
         T000526_n9SectorId = new bool[] {false} ;
         T000526_A10SectorName = new string[] {""} ;
         T000527_A2BrandName = new string[] {""} ;
         T000528_A5SupplierName = new string[] {""} ;
         T000529_A16ProductName = new string[] {""} ;
         T000530_A10SectorName = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.product__default(),
            new Object[][] {
                new Object[] {
               T00052_A15ProductId, T00052_A110ProductActive, T00052_n110ProductActive, T00052_A55ProductCode, T00052_n55ProductCode, T00052_A16ProductName, T00052_A85ProductCostPrice, T00052_n85ProductCostPrice, T00052_A89ProductRetailProfit, T00052_n89ProductRetailProfit,
               T00052_A87ProductWholesaleProfit, T00052_n87ProductWholesaleProfit, T00052_A17ProductStock, T00052_n17ProductStock, T00052_A69ProductMiniumStock, T00052_n69ProductMiniumStock, T00052_A19ProductDescription, T00052_n19ProductDescription, T00052_A28ProductCreatedDate, T00052_A29ProductModifiedDate,
               T00052_A93ProductMiniumQuantityWholesale, T00052_n93ProductMiniumQuantityWholesale, T00052_A1BrandId, T00052_n1BrandId, T00052_A9SectorId, T00052_n9SectorId, T00052_A4SupplierId
               }
               , new Object[] {
               T00053_A15ProductId, T00053_A110ProductActive, T00053_n110ProductActive, T00053_A55ProductCode, T00053_n55ProductCode, T00053_A16ProductName, T00053_A85ProductCostPrice, T00053_n85ProductCostPrice, T00053_A89ProductRetailProfit, T00053_n89ProductRetailProfit,
               T00053_A87ProductWholesaleProfit, T00053_n87ProductWholesaleProfit, T00053_A17ProductStock, T00053_n17ProductStock, T00053_A69ProductMiniumStock, T00053_n69ProductMiniumStock, T00053_A19ProductDescription, T00053_n19ProductDescription, T00053_A28ProductCreatedDate, T00053_A29ProductModifiedDate,
               T00053_A93ProductMiniumQuantityWholesale, T00053_n93ProductMiniumQuantityWholesale, T00053_A1BrandId, T00053_n1BrandId, T00053_A9SectorId, T00053_n9SectorId, T00053_A4SupplierId
               }
               , new Object[] {
               T00054_A2BrandName
               }
               , new Object[] {
               T00055_A10SectorName
               }
               , new Object[] {
               T00056_A5SupplierName
               }
               , new Object[] {
               T00057_A15ProductId, T00057_A110ProductActive, T00057_n110ProductActive, T00057_A55ProductCode, T00057_n55ProductCode, T00057_A16ProductName, T00057_A85ProductCostPrice, T00057_n85ProductCostPrice, T00057_A89ProductRetailProfit, T00057_n89ProductRetailProfit,
               T00057_A87ProductWholesaleProfit, T00057_n87ProductWholesaleProfit, T00057_A2BrandName, T00057_A5SupplierName, T00057_A10SectorName, T00057_A17ProductStock, T00057_n17ProductStock, T00057_A69ProductMiniumStock, T00057_n69ProductMiniumStock, T00057_A19ProductDescription,
               T00057_n19ProductDescription, T00057_A28ProductCreatedDate, T00057_A29ProductModifiedDate, T00057_A93ProductMiniumQuantityWholesale, T00057_n93ProductMiniumQuantityWholesale, T00057_A1BrandId, T00057_n1BrandId, T00057_A9SectorId, T00057_n9SectorId, T00057_A4SupplierId
               }
               , new Object[] {
               T00058_A16ProductName
               }
               , new Object[] {
               T00059_A2BrandName
               }
               , new Object[] {
               T000510_A5SupplierName
               }
               , new Object[] {
               T000511_A10SectorName
               }
               , new Object[] {
               T000512_A15ProductId
               }
               , new Object[] {
               T000513_A15ProductId
               }
               , new Object[] {
               T000514_A15ProductId
               }
               , new Object[] {
               T000515_A15ProductId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000518_A2BrandName
               }
               , new Object[] {
               T000519_A5SupplierName
               }
               , new Object[] {
               T000520_A10SectorName
               }
               , new Object[] {
               T000521_A20InvoiceId, T000521_A25InvoiceDetailId
               }
               , new Object[] {
               T000522_A50PurchaseOrderId, T000522_A61PurchaseOrderDetailId
               }
               , new Object[] {
               T000523_A15ProductId
               }
               , new Object[] {
               T000524_A1BrandId, T000524_A2BrandName
               }
               , new Object[] {
               T000525_A4SupplierId, T000525_A5SupplierName
               }
               , new Object[] {
               T000526_A9SectorId, T000526_A10SectorName
               }
               , new Object[] {
               T000527_A2BrandName
               }
               , new Object[] {
               T000528_A5SupplierName
               }
               , new Object[] {
               T000529_A16ProductName
               }
               , new Object[] {
               T000530_A10SectorName
               }
            }
         );
         AV26Pgmname = "Product";
         Z87ProductWholesaleProfit = 0;
         n87ProductWholesaleProfit = false;
         i87ProductWholesaleProfit = 0;
         n87ProductWholesaleProfit = false;
         A87ProductWholesaleProfit = 0;
         n87ProductWholesaleProfit = false;
         Z89ProductRetailProfit = 0;
         n89ProductRetailProfit = false;
         i89ProductRetailProfit = 0;
         n89ProductRetailProfit = false;
         A89ProductRetailProfit = 0;
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
      }

      private short Z93ProductMiniumQuantityWholesale ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A93ProductMiniumQuantityWholesale ;
      private short Gx_BScreen ;
      private short RcdFound5 ;
      private short GX_JID ;
      private short nIsDirty_5 ;
      private short gxajaxcallmode ;
      private short i93ProductMiniumQuantityWholesale ;
      private int wcpOAV15ProductId ;
      private int Z15ProductId ;
      private int Z17ProductStock ;
      private int Z69ProductMiniumStock ;
      private int Z1BrandId ;
      private int Z9SectorId ;
      private int Z4SupplierId ;
      private int N1BrandId ;
      private int N4SupplierId ;
      private int N9SectorId ;
      private int A1BrandId ;
      private int A4SupplierId ;
      private int A9SectorId ;
      private int AV15ProductId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtProductCode_Enabled ;
      private int edtProductName_Enabled ;
      private int edtProductCostPrice_Enabled ;
      private int edtProductRetailProfit_Enabled ;
      private int edtProductRetailPrice_Enabled ;
      private int edtProductMiniumQuantityWholesale_Enabled ;
      private int edtProductWholesaleProfit_Enabled ;
      private int edtProductWholesalePrice_Enabled ;
      private int A17ProductStock ;
      private int edtProductStock_Enabled ;
      private int A69ProductMiniumStock ;
      private int edtProductMiniumStock_Enabled ;
      private int edtProductDescription_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int A15ProductId ;
      private int AV11Insert_BrandId ;
      private int AV13Insert_SupplierId ;
      private int AV12Insert_SectorId ;
      private int AV27GXV1 ;
      private int AV18ProductIdAux ;
      private int i17ProductStock ;
      private int i69ProductMiniumStock ;
      private int idxLst ;
      private int gxdynajaxindex ;
      private decimal Z85ProductCostPrice ;
      private decimal Z89ProductRetailProfit ;
      private decimal Z87ProductWholesaleProfit ;
      private decimal A85ProductCostPrice ;
      private decimal A89ProductRetailProfit ;
      private decimal A87ProductWholesaleProfit ;
      private decimal A90ProductRetailPrice ;
      private decimal A88ProductWholesalePrice ;
      private decimal i89ProductRetailProfit ;
      private decimal i87ProductWholesaleProfit ;
      private decimal Z90ProductRetailPrice ;
      private decimal GXt_decimal4 ;
      private decimal GXt_decimal3 ;
      private decimal GXt_decimal2 ;
      private decimal Z88ProductWholesalePrice ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtProductCode_Internalname ;
      private string dynBrandId_Internalname ;
      private string dynSupplierId_Internalname ;
      private string dynSectorId_Internalname ;
      private string cmbavProductstate_Internalname ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string divToolbarcell_Internalname ;
      private string TempTags ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string edtProductCode_Jsonclick ;
      private string edtProductName_Internalname ;
      private string edtProductName_Jsonclick ;
      private string edtProductCostPrice_Internalname ;
      private string edtProductCostPrice_Jsonclick ;
      private string edtProductRetailProfit_Internalname ;
      private string edtProductRetailProfit_Jsonclick ;
      private string edtProductRetailPrice_Internalname ;
      private string edtProductRetailPrice_Jsonclick ;
      private string edtProductMiniumQuantityWholesale_Internalname ;
      private string edtProductMiniumQuantityWholesale_Jsonclick ;
      private string edtProductWholesaleProfit_Internalname ;
      private string edtProductWholesaleProfit_Jsonclick ;
      private string edtProductWholesalePrice_Internalname ;
      private string edtProductWholesalePrice_Jsonclick ;
      private string dynBrandId_Jsonclick ;
      private string dynSupplierId_Jsonclick ;
      private string dynSectorId_Jsonclick ;
      private string edtProductStock_Internalname ;
      private string edtProductStock_Jsonclick ;
      private string edtProductMiniumStock_Internalname ;
      private string edtProductMiniumStock_Jsonclick ;
      private string edtProductDescription_Internalname ;
      private string cmbavProductstate_Jsonclick ;
      private string chkavProductexist_Internalname ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV26Pgmname ;
      private string hsh ;
      private string sMode5 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string gxwrpcisep ;
      private DateTime Z28ProductCreatedDate ;
      private DateTime Z29ProductModifiedDate ;
      private DateTime A28ProductCreatedDate ;
      private DateTime A29ProductModifiedDate ;
      private DateTime Gx_date ;
      private bool Z110ProductActive ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n85ProductCostPrice ;
      private bool n89ProductRetailProfit ;
      private bool n87ProductWholesaleProfit ;
      private bool n1BrandId ;
      private bool n9SectorId ;
      private bool wbErr ;
      private bool AV21ProductExist ;
      private bool n110ProductActive ;
      private bool A110ProductActive ;
      private bool n55ProductCode ;
      private bool n17ProductStock ;
      private bool n69ProductMiniumStock ;
      private bool n19ProductDescription ;
      private bool n93ProductMiniumQuantityWholesale ;
      private bool returnInSub ;
      private bool AV23AllOk ;
      private bool Gx_longc ;
      private bool gxdyncontrolsrefreshing ;
      private string Z55ProductCode ;
      private string Z16ProductName ;
      private string Z19ProductDescription ;
      private string AV16ProductState ;
      private string A55ProductCode ;
      private string A16ProductName ;
      private string A19ProductDescription ;
      private string A2BrandName ;
      private string A10SectorName ;
      private string A5SupplierName ;
      private string Z2BrandName ;
      private string Z5SupplierName ;
      private string Z10SectorName ;
      private IGxSession AV10WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynBrandId ;
      private GXCombobox dynSupplierId ;
      private GXCombobox dynSectorId ;
      private GXCombobox cmbavProductstate ;
      private GXCheckbox chkavProductexist ;
      private bool[] T00053_n55ProductCode ;
      private IDataStoreProvider pr_default ;
      private string[] T00054_A2BrandName ;
      private string[] T00056_A5SupplierName ;
      private string[] T00055_A10SectorName ;
      private int[] T00057_A15ProductId ;
      private bool[] T00057_A110ProductActive ;
      private bool[] T00057_n110ProductActive ;
      private string[] T00057_A55ProductCode ;
      private bool[] T00057_n55ProductCode ;
      private string[] T00057_A16ProductName ;
      private decimal[] T00057_A85ProductCostPrice ;
      private bool[] T00057_n85ProductCostPrice ;
      private decimal[] T00057_A89ProductRetailProfit ;
      private bool[] T00057_n89ProductRetailProfit ;
      private decimal[] T00057_A87ProductWholesaleProfit ;
      private bool[] T00057_n87ProductWholesaleProfit ;
      private string[] T00057_A2BrandName ;
      private string[] T00057_A5SupplierName ;
      private string[] T00057_A10SectorName ;
      private int[] T00057_A17ProductStock ;
      private bool[] T00057_n17ProductStock ;
      private int[] T00057_A69ProductMiniumStock ;
      private bool[] T00057_n69ProductMiniumStock ;
      private string[] T00057_A19ProductDescription ;
      private bool[] T00057_n19ProductDescription ;
      private DateTime[] T00057_A28ProductCreatedDate ;
      private DateTime[] T00057_A29ProductModifiedDate ;
      private short[] T00057_A93ProductMiniumQuantityWholesale ;
      private bool[] T00057_n93ProductMiniumQuantityWholesale ;
      private int[] T00057_A1BrandId ;
      private bool[] T00057_n1BrandId ;
      private int[] T00057_A9SectorId ;
      private bool[] T00057_n9SectorId ;
      private int[] T00057_A4SupplierId ;
      private string[] T00058_A16ProductName ;
      private string[] T00059_A2BrandName ;
      private string[] T000510_A5SupplierName ;
      private string[] T000511_A10SectorName ;
      private int[] T000512_A15ProductId ;
      private int[] T00053_A15ProductId ;
      private bool[] T00053_A110ProductActive ;
      private bool[] T00053_n110ProductActive ;
      private string[] T00053_A55ProductCode ;
      private string[] T00053_A16ProductName ;
      private decimal[] T00053_A85ProductCostPrice ;
      private bool[] T00053_n85ProductCostPrice ;
      private decimal[] T00053_A89ProductRetailProfit ;
      private bool[] T00053_n89ProductRetailProfit ;
      private decimal[] T00053_A87ProductWholesaleProfit ;
      private bool[] T00053_n87ProductWholesaleProfit ;
      private int[] T00053_A17ProductStock ;
      private bool[] T00053_n17ProductStock ;
      private int[] T00053_A69ProductMiniumStock ;
      private bool[] T00053_n69ProductMiniumStock ;
      private string[] T00053_A19ProductDescription ;
      private bool[] T00053_n19ProductDescription ;
      private DateTime[] T00053_A28ProductCreatedDate ;
      private DateTime[] T00053_A29ProductModifiedDate ;
      private short[] T00053_A93ProductMiniumQuantityWholesale ;
      private bool[] T00053_n93ProductMiniumQuantityWholesale ;
      private int[] T00053_A1BrandId ;
      private bool[] T00053_n1BrandId ;
      private int[] T00053_A9SectorId ;
      private bool[] T00053_n9SectorId ;
      private int[] T00053_A4SupplierId ;
      private int[] T000513_A15ProductId ;
      private int[] T000514_A15ProductId ;
      private int[] T00052_A15ProductId ;
      private bool[] T00052_A110ProductActive ;
      private bool[] T00052_n110ProductActive ;
      private string[] T00052_A55ProductCode ;
      private bool[] T00052_n55ProductCode ;
      private string[] T00052_A16ProductName ;
      private decimal[] T00052_A85ProductCostPrice ;
      private bool[] T00052_n85ProductCostPrice ;
      private decimal[] T00052_A89ProductRetailProfit ;
      private bool[] T00052_n89ProductRetailProfit ;
      private decimal[] T00052_A87ProductWholesaleProfit ;
      private bool[] T00052_n87ProductWholesaleProfit ;
      private int[] T00052_A17ProductStock ;
      private bool[] T00052_n17ProductStock ;
      private int[] T00052_A69ProductMiniumStock ;
      private bool[] T00052_n69ProductMiniumStock ;
      private string[] T00052_A19ProductDescription ;
      private bool[] T00052_n19ProductDescription ;
      private DateTime[] T00052_A28ProductCreatedDate ;
      private DateTime[] T00052_A29ProductModifiedDate ;
      private short[] T00052_A93ProductMiniumQuantityWholesale ;
      private bool[] T00052_n93ProductMiniumQuantityWholesale ;
      private int[] T00052_A1BrandId ;
      private bool[] T00052_n1BrandId ;
      private int[] T00052_A9SectorId ;
      private bool[] T00052_n9SectorId ;
      private int[] T00052_A4SupplierId ;
      private int[] T000515_A15ProductId ;
      private string[] T000518_A2BrandName ;
      private string[] T000519_A5SupplierName ;
      private string[] T000520_A10SectorName ;
      private int[] T000521_A20InvoiceId ;
      private int[] T000521_A25InvoiceDetailId ;
      private int[] T000522_A50PurchaseOrderId ;
      private int[] T000522_A61PurchaseOrderDetailId ;
      private int[] T000523_A15ProductId ;
      private int[] T000524_A1BrandId ;
      private bool[] T000524_n1BrandId ;
      private string[] T000524_A2BrandName ;
      private int[] T000525_A4SupplierId ;
      private string[] T000525_A5SupplierName ;
      private int[] T000526_A9SectorId ;
      private bool[] T000526_n9SectorId ;
      private string[] T000526_A10SectorName ;
      private string[] T000527_A2BrandName ;
      private string[] T000528_A5SupplierName ;
      private string[] T000529_A16ProductName ;
      private string[] T000530_A10SectorName ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV22ErrorMessages ;
      private GXWebForm Form ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV14TrnContextAtt ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession GXt_SdtSDTContextSession1 ;
   }

   public class product__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new UpdateCursor(def[14])
         ,new UpdateCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new ForEachCursor(def[24])
         ,new ForEachCursor(def[25])
         ,new ForEachCursor(def[26])
         ,new ForEachCursor(def[27])
         ,new ForEachCursor(def[28])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00057;
          prmT00057 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmT00054;
          prmT00054 = new Object[] {
          new ParDef("@BrandId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT00056;
          prmT00056 = new Object[] {
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          Object[] prmT00055;
          prmT00055 = new Object[] {
          new ParDef("@SectorId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT00058;
          prmT00058 = new Object[] {
          new ParDef("@ProductName",GXType.NVarChar,60,0) ,
          new ParDef("@SupplierId",GXType.Int32,6,0) ,
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmT00059;
          prmT00059 = new Object[] {
          new ParDef("@BrandId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000510;
          prmT000510 = new Object[] {
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          Object[] prmT000511;
          prmT000511 = new Object[] {
          new ParDef("@SectorId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000512;
          prmT000512 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmT00053;
          prmT00053 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmT000513;
          prmT000513 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmT000514;
          prmT000514 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmT00052;
          prmT00052 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmT000515;
          prmT000515 = new Object[] {
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
          Object[] prmT000516;
          prmT000516 = new Object[] {
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
          Object[] prmT000517;
          prmT000517 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmT000518;
          prmT000518 = new Object[] {
          new ParDef("@BrandId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000519;
          prmT000519 = new Object[] {
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          Object[] prmT000520;
          prmT000520 = new Object[] {
          new ParDef("@SectorId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000521;
          prmT000521 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmT000522;
          prmT000522 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmT000523;
          prmT000523 = new Object[] {
          };
          Object[] prmT000524;
          prmT000524 = new Object[] {
          };
          Object[] prmT000525;
          prmT000525 = new Object[] {
          };
          Object[] prmT000526;
          prmT000526 = new Object[] {
          };
          Object[] prmT000527;
          prmT000527 = new Object[] {
          new ParDef("@BrandId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000528;
          prmT000528 = new Object[] {
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          Object[] prmT000529;
          prmT000529 = new Object[] {
          new ParDef("@ProductName",GXType.NVarChar,60,0) ,
          new ParDef("@SupplierId",GXType.Int32,6,0) ,
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmT000530;
          prmT000530 = new Object[] {
          new ParDef("@SectorId",GXType.Int32,6,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T00052", "SELECT [ProductId], [ProductActive], [ProductCode], [ProductName], [ProductCostPrice], [ProductRetailProfit], [ProductWholesaleProfit], [ProductStock], [ProductMiniumStock], [ProductDescription], [ProductCreatedDate], [ProductModifiedDate], [ProductMiniumQuantityWholesale], [BrandId], [SectorId], [SupplierId] FROM [Product] WITH (UPDLOCK) WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00052,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00053", "SELECT [ProductId], [ProductActive], [ProductCode], [ProductName], [ProductCostPrice], [ProductRetailProfit], [ProductWholesaleProfit], [ProductStock], [ProductMiniumStock], [ProductDescription], [ProductCreatedDate], [ProductModifiedDate], [ProductMiniumQuantityWholesale], [BrandId], [SectorId], [SupplierId] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00053,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00054", "SELECT [BrandName] FROM [Brand] WHERE [BrandId] = @BrandId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00054,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00055", "SELECT [SectorName] FROM [Sector] WHERE [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00055,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00056", "SELECT [SupplierName] FROM [Supplier] WHERE [SupplierId] = @SupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00056,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00057", "SELECT TM1.[ProductId], TM1.[ProductActive], TM1.[ProductCode], TM1.[ProductName], TM1.[ProductCostPrice], TM1.[ProductRetailProfit], TM1.[ProductWholesaleProfit], T2.[BrandName], T3.[SupplierName], T4.[SectorName], TM1.[ProductStock], TM1.[ProductMiniumStock], TM1.[ProductDescription], TM1.[ProductCreatedDate], TM1.[ProductModifiedDate], TM1.[ProductMiniumQuantityWholesale], TM1.[BrandId], TM1.[SectorId], TM1.[SupplierId] FROM ((([Product] TM1 LEFT JOIN [Brand] T2 ON T2.[BrandId] = TM1.[BrandId]) INNER JOIN [Supplier] T3 ON T3.[SupplierId] = TM1.[SupplierId]) LEFT JOIN [Sector] T4 ON T4.[SectorId] = TM1.[SectorId]) WHERE TM1.[ProductId] = @ProductId ORDER BY TM1.[ProductId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00057,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00058", "SELECT [ProductName] FROM [Product] WHERE ([ProductName] = @ProductName AND [SupplierId] = @SupplierId) AND (Not ( [ProductId] = @ProductId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT00058,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00059", "SELECT [BrandName] FROM [Brand] WHERE [BrandId] = @BrandId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00059,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000510", "SELECT [SupplierName] FROM [Supplier] WHERE [SupplierId] = @SupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000510,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000511", "SELECT [SectorName] FROM [Sector] WHERE [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000511,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000512", "SELECT [ProductId] FROM [Product] WHERE [ProductId] = @ProductId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000512,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000513", "SELECT TOP 1 [ProductId] FROM [Product] WHERE ( [ProductId] > @ProductId) ORDER BY [ProductId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000513,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000514", "SELECT TOP 1 [ProductId] FROM [Product] WHERE ( [ProductId] < @ProductId) ORDER BY [ProductId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000514,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000515", "INSERT INTO [Product]([ProductActive], [ProductCode], [ProductName], [ProductCostPrice], [ProductRetailProfit], [ProductWholesaleProfit], [ProductStock], [ProductMiniumStock], [ProductDescription], [ProductCreatedDate], [ProductModifiedDate], [ProductMiniumQuantityWholesale], [BrandId], [SectorId], [SupplierId]) VALUES(@ProductActive, @ProductCode, @ProductName, @ProductCostPrice, @ProductRetailProfit, @ProductWholesaleProfit, @ProductStock, @ProductMiniumStock, @ProductDescription, @ProductCreatedDate, @ProductModifiedDate, @ProductMiniumQuantityWholesale, @BrandId, @SectorId, @SupplierId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000515,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000516", "UPDATE [Product] SET [ProductActive]=@ProductActive, [ProductCode]=@ProductCode, [ProductName]=@ProductName, [ProductCostPrice]=@ProductCostPrice, [ProductRetailProfit]=@ProductRetailProfit, [ProductWholesaleProfit]=@ProductWholesaleProfit, [ProductStock]=@ProductStock, [ProductMiniumStock]=@ProductMiniumStock, [ProductDescription]=@ProductDescription, [ProductCreatedDate]=@ProductCreatedDate, [ProductModifiedDate]=@ProductModifiedDate, [ProductMiniumQuantityWholesale]=@ProductMiniumQuantityWholesale, [BrandId]=@BrandId, [SectorId]=@SectorId, [SupplierId]=@SupplierId  WHERE [ProductId] = @ProductId", GxErrorMask.GX_NOMASK,prmT000516)
             ,new CursorDef("T000517", "DELETE FROM [Product]  WHERE [ProductId] = @ProductId", GxErrorMask.GX_NOMASK,prmT000517)
             ,new CursorDef("T000518", "SELECT [BrandName] FROM [Brand] WHERE [BrandId] = @BrandId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000518,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000519", "SELECT [SupplierName] FROM [Supplier] WHERE [SupplierId] = @SupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000519,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000520", "SELECT [SectorName] FROM [Sector] WHERE [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000520,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000521", "SELECT TOP 1 [InvoiceId], [InvoiceDetailId] FROM [InvoiceDetail] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000521,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000522", "SELECT TOP 1 [PurchaseOrderId], [PurchaseOrderDetailId] FROM [PurchaseOrderDetail] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000522,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000523", "SELECT [ProductId] FROM [Product] ORDER BY [ProductId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000523,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000524", "SELECT [BrandId], [BrandName] FROM [Brand] ORDER BY [BrandName] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000524,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000525", "SELECT [SupplierId], [SupplierName] FROM [Supplier] ORDER BY [SupplierName] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000525,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000526", "SELECT [SectorId], [SectorName] FROM [Sector] ORDER BY [SectorName] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000526,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000527", "SELECT [BrandName] FROM [Brand] WHERE [BrandId] = @BrandId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000527,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000528", "SELECT [SupplierName] FROM [Supplier] WHERE [SupplierId] = @SupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000528,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000529", "SELECT [ProductName] FROM [Product] WHERE ([ProductName] = @ProductName AND [SupplierId] = @SupplierId) AND (Not ( [ProductId] = @ProductId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000529,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000530", "SELECT [SectorName] FROM [Sector] WHERE [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000530,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 16 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 17 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 18 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 19 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 20 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 21 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 22 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 23 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 24 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 25 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 26 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 27 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 28 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
       }
    }

 }

}
