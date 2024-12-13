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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class wwproduct : GXDataArea
   {
      public wwproduct( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public wwproduct( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavFilterorder = new GXCombobox();
         chkavFilterorderdesc = new GXCheckbox();
         chkProductActive = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
            {
               gxnrGrid_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
            {
               gxgrGrid_refresh_invoke( ) ;
               return  ;
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
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_52 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_52"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_52_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_52_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_52_idx = GetPar( "sGXsfl_52_idx");
         edtavDelete_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_52_Refreshing);
         edtavDelete_Enabled = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_52_Refreshing);
         AV13Delete = GetPar( "Delete");
         edtavUpdate_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_52_Refreshing);
         edtavUpdate_Enabled = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_52_Refreshing);
         AV12Update = GetPar( "Update");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid_newrow( ) ;
         /* End function gxnrGrid_newrow_invoke */
      }

      protected void gxgrGrid_refresh_invoke( )
      {
         subGrid_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid_Rows"), "."), 18, MidpointRounding.ToEven));
         AV19ProductName = GetPar( "ProductName");
         AV15OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV16SupplierName = GetPar( "SupplierName");
         AV14ADVANCED_LABEL_TEMPLATE = GetPar( "ADVANCED_LABEL_TEMPLATE");
         AV17BrandName = GetPar( "BrandName");
         edtavDelete_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_52_Refreshing);
         edtavDelete_Enabled = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_52_Refreshing);
         AV13Delete = GetPar( "Delete");
         edtavUpdate_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_52_Refreshing);
         edtavUpdate_Enabled = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp("", false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_52_Refreshing);
         AV12Update = GetPar( "Update");
         AV25FilterOrderDesc = StringUtil.StrToBool( GetPar( "FilterOrderDesc"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV31Message);
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV19ProductName, AV15OrderedBy, AV16SupplierName, AV14ADVANCED_LABEL_TEMPLATE, AV17BrandName, AV13Delete, AV12Update, AV25FilterOrderDesc, AV31Message) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
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

      public override short ExecuteStartEvent( )
      {
         PA0X2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0X2( ) ;
         }
         return gxajaxcallmode ;
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
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
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
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwproduct.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vADVANCED_LABEL_TEMPLATE", StringUtil.RTrim( AV14ADVANCED_LABEL_TEMPLATE));
         GxWebStd.gx_hidden_field( context, "gxhash_vADVANCED_LABEL_TEMPLATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14ADVANCED_LABEL_TEMPLATE, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMESSAGE", AV31Message);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMESSAGE", AV31Message);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vMESSAGE", GetSecureSignedToken( "", AV31Message, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vPRODUCTNAME", AV19ProductName);
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15OrderedBy), 4, 0, ".", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_52", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_52), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vADVANCED_LABEL_TEMPLATE", StringUtil.RTrim( AV14ADVANCED_LABEL_TEMPLATE));
         GxWebStd.gx_hidden_field( context, "gxhash_vADVANCED_LABEL_TEMPLATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14ADVANCED_LABEL_TEMPLATE, "")), context));
         GxWebStd.gx_hidden_field( context, "SUPPLIERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A4SupplierId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "BRANDID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1BrandId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "SECTORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9SectorId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPRODUCTCODE", AV27ProductCode);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMESSAGE", AV31Message);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMESSAGE", AV31Message);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vMESSAGE", GetSecureSignedToken( "", AV31Message, context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTRETAILPROFIT", StringUtil.LTrim( StringUtil.NToC( A89ProductRetailProfit, 8, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTWHOLESALEPROFIT", StringUtil.LTrim( StringUtil.NToC( A87ProductWholesaleProfit, 8, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FILTERSCONTAINER_Class", StringUtil.RTrim( divFilterscontainer_Class));
         GxWebStd.gx_hidden_field( context, "SUPPLIERNAMEFILTERCONTAINER_Class", StringUtil.RTrim( divSuppliernamefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "BRANDNAMEFILTERCONTAINER_Class", StringUtil.RTrim( divBrandnamefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "vDELETE_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vDELETE_Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vUPDATE_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vUPDATE_Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
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

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE0X2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0X2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("wwproduct.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWProduct" ;
      }

      public override string GetPgmdesc( )
      {
         return "Work With Product" ;
      }

      protected void WB0X0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "body-container", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcell_Internalname, 1, 0, "px", 0, "px", divGridcell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "container-fluid container-advanced", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabletop_Internalname, 1, 0, "px", 0, "px", "Flex ww__actions-container", "left", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ww__title-cell", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTitletext_Internalname, "Products", "", "", lblTitletext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WWProduct.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ww__actions-cell", "left", "top", "", "", "div");
            context.WriteHtmlText( "<nav class=\"navbar navbar-default gx-navbar  ActionGroup\" data-gx-actiongroup-type=\"menu\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "container-fluid", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "navbar-header", "left", "top", "", "", "div");
            context.WriteHtmlText( "<button type=\"button\" class=\"navbar-toggle collapsed gx-navbar-toggle\" data-toggle=\"collapse\" aria-expanded=\"false\">") ;
            context.WriteHtmlText( "<span class=\"icon-bar\"></span>") ;
            context.WriteHtmlText( "<span class=\"icon-bar\"></span>") ;
            context.WriteHtmlText( "<span class=\"icon-bar\"></span>") ;
            context.WriteHtmlText( "</button>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lbllbl15_Internalname, "", "", "", lbllbl15_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "navbar-brand", 0, "", 1, 1, 0, 0, "HLP_WWProduct.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divActions_inner_Internalname, 1, 0, "px", 0, "px", "collapse navbar-collapse gx-navbar-inner", "left", "top", "", "", "div");
            context.WriteHtmlText( "<ul class=\"nav navbar-nav\">") ;
            context.WriteHtmlText( "<li>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"";
            ClassString = "Button button-primary";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(52), 2, 0)+","+"null"+");", "Insert", bttBtninsert_Jsonclick, 5, "Insert", "", StyleString, ClassString, bttBtninsert_Visible, bttBtninsert_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWProduct.htm");
            context.WriteHtmlText( "</li>") ;
            context.WriteHtmlText( "<li>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
            ClassString = "Button button-tertiary";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(52), 2, 0)+","+"null"+");", "Export", bttBtnexport_Jsonclick, 5, "Export to Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWProduct.htm");
            context.WriteHtmlText( "</li>") ;
            context.WriteHtmlText( "</ul>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</nav>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ww__filter-cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProductname_Internalname, "Product Name", "gx-form-item attribute-searchLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'" + sGXsfl_52_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProductname_Internalname, AV19ProductName, StringUtil.RTrim( context.localUtil.Format( AV19ProductName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Name", edtavProductname_Jsonclick, 0, "attribute-search", "", "", "", "", edtavProductname_Visible, edtavProductname_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_WWProduct.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ww__toggle-cell", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(52), 2, 0)+","+"null"+");", bttBtntoggle_Caption, bttBtntoggle_Jsonclick, 5, bttBtntoggle_Tooltiptext, "", StyleString, ClassString, bttBtntoggle_Visible, bttBtntoggle_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"E\\'OTRO\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWProduct.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavFiltercode_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFiltercode_Internalname, "Code", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'" + sGXsfl_52_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFiltercode_Internalname, AV22FilterCode, StringUtil.RTrim( context.localUtil.Format( AV22FilterCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFiltercode_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFiltercode_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_WWProduct.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavFiltername_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFiltername_Internalname, "Name", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'" + sGXsfl_52_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFiltername_Internalname, AV23FilterName, StringUtil.RTrim( context.localUtil.Format( AV23FilterName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFiltername_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFiltername_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_WWProduct.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavFilterorder_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavFilterorder_Internalname, "Order", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'" + sGXsfl_52_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavFilterorder, cmbavFilterorder_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV24FilterOrder), 4, 0)), 1, cmbavFilterorder_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavFilterorder.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "", true, 0, "HLP_WWProduct.htm");
            cmbavFilterorder.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24FilterOrder), 4, 0));
            AssignProp("", false, cmbavFilterorder_Internalname, "Values", (string)(cmbavFilterorder.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavFilterorderdesc_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavFilterorderdesc_Internalname, "Order Desc", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_52_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavFilterorderdesc_Internalname, StringUtil.BoolToStr( AV25FilterOrderDesc), "", "Order Desc", 1, chkavFilterorderdesc.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(46, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,46);\"");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcontainer_Internalname, 1, 0, "px", 0, "px", "ww__grid-container", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl52( ) ;
         }
         if ( wbEnd == 52 )
         {
            wbEnd = 0;
            nRC_GXsfl_52 = (int)(nGXsfl_52_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
               GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 col-md-2 ww__filters-cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFilterscontainer_Internalname, 1, 0, "px", 0, "px", divFilterscontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Right", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
            ClassString = "filters-container__close";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggleontable_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(52), 2, 0)+","+"null"+");", "Hide Filters", bttBtntoggleontable_Jsonclick, 7, "Hide Filters", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e110x1_client"+"'", TempTags, "", 2, "HLP_WWProduct.htm");
            GxWebStd.gx_div_end( context, "Right", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavOrderedby_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavOrderedby_Internalname, "Ordered By", "col-xs-12 attribute-comboLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_52_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavOrderedby_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15OrderedBy), 4, 0, ".", "")), StringUtil.LTrim( ((edtavOrderedby_Enabled!=0) ? context.localUtil.Format( (decimal)(AV15OrderedBy), "ZZZ9") : context.localUtil.Format( (decimal)(AV15OrderedBy), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavOrderedby_Jsonclick, 0, "attribute-combo", "", "", "", "", 1, edtavOrderedby_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_WWProduct.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSuppliernamefiltercontainer_Internalname, 1, 0, "px", 0, "px", divSuppliernamefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsuppliernamefilter_Internalname, lblLblsuppliernamefilter_Caption, "", "", lblLblsuppliernamefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e120x1_client"+"'", "", "filter-item__label", 7, "", 1, 1, 0, 1, "HLP_WWProduct.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 filter-item__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSuppliername_Internalname, "Supplier Name", "col-sm-3 attribute-comboLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'" + sGXsfl_52_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavSuppliername_Internalname, AV16SupplierName, StringUtil.RTrim( context.localUtil.Format( AV16SupplierName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavSuppliername_Jsonclick, 0, "attribute-combo", "", "", "", "", edtavSuppliername_Visible, edtavSuppliername_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_WWProduct.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            GxWebStd.gx_div_start( context, divBrandnamefiltercontainer_Internalname, 1, 0, "px", 0, "px", divBrandnamefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblbrandnamefilter_Internalname, lblLblbrandnamefilter_Caption, "", "", lblLblbrandnamefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e130x1_client"+"'", "", "filter-item__label", 7, "", 1, 1, 0, 1, "HLP_WWProduct.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 filter-item__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavBrandname_Internalname, "Brand Name", "col-sm-3 attribute-comboLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'" + sGXsfl_52_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavBrandname_Internalname, AV17BrandName, StringUtil.RTrim( context.localUtil.Format( AV17BrandName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavBrandname_Jsonclick, 0, "attribute-combo", "", "", "", "", edtavBrandname_Visible, edtavBrandname_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_WWProduct.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 52 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
                  GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0X2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_2-169539", 0) ;
            }
            Form.Meta.addItem("description", "Work With Product", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0X0( ) ;
      }

      protected void WS0X2( )
      {
         START0X2( ) ;
         EVT0X2( ) ;
      }

      protected void EVT0X2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
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
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E140X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E150X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VFILTERNAME.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E160X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VFILTERCODE.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E170X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VFILTERORDER.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E180X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VFILTERORDERDESC.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E190X2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'OTRO'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRIDPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "VDELETE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "VDELETE.CLICK") == 0 ) )
                           {
                              nGXsfl_52_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_52_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_52_idx), 4, 0), 4, "0");
                              SubsflControlProps_522( ) ;
                              A15ProductId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtProductId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A55ProductCode = cgiGet( edtProductCode_Internalname);
                              n55ProductCode = false;
                              A16ProductName = cgiGet( edtProductName_Internalname);
                              A17ProductStock = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtProductStock_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              n17ProductStock = false;
                              A85ProductCostPrice = context.localUtil.CToN( cgiGet( edtProductCostPrice_Internalname), ".", ",");
                              n85ProductCostPrice = false;
                              A90ProductRetailPrice = context.localUtil.CToN( cgiGet( edtProductRetailPrice_Internalname), ".", ",");
                              A88ProductWholesalePrice = context.localUtil.CToN( cgiGet( edtProductWholesalePrice_Internalname), ".", ",");
                              A93ProductMiniumQuantityWholesale = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtProductMiniumQuantityWholesale_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              n93ProductMiniumQuantityWholesale = false;
                              A5SupplierName = cgiGet( edtSupplierName_Internalname);
                              A2BrandName = cgiGet( edtBrandName_Internalname);
                              A10SectorName = cgiGet( edtSectorName_Internalname);
                              A110ProductActive = StringUtil.StrToBool( cgiGet( chkProductActive_Internalname));
                              n110ProductActive = false;
                              AV12Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV12Update);
                              AV13Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri("", false, edtavDelete_Internalname, AV13Delete);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E200X2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E210X2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E220X2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VDELETE.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E230X2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Productname Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPRODUCTNAME"), AV19ProductName) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ".", ",") != Convert.ToDecimal( AV15OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0X2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA0X2( )
      {
         if ( nDonePA == 0 )
         {
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
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavProductname_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_522( ) ;
         while ( nGXsfl_52_idx <= nRC_GXsfl_52 )
         {
            sendrow_522( ) ;
            nGXsfl_52_idx = ((subGrid_Islastpage==1)&&(nGXsfl_52_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_52_idx+1);
            sGXsfl_52_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_52_idx), 4, 0), 4, "0");
            SubsflControlProps_522( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV19ProductName ,
                                       short AV15OrderedBy ,
                                       string AV16SupplierName ,
                                       string AV14ADVANCED_LABEL_TEMPLATE ,
                                       string AV17BrandName ,
                                       string AV13Delete ,
                                       string AV12Update ,
                                       bool AV25FilterOrderDesc ,
                                       GeneXus.Utils.SdtMessages_Message AV31Message )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF0X2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUCTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A15ProductId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "PRODUCTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUCTACTIVE", GetSecureSignedToken( "", A110ProductActive, context));
         GxWebStd.gx_hidden_field( context, "PRODUCTACTIVE", StringUtil.BoolToStr( A110ProductActive));
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( cmbavFilterorder.ItemCount > 0 )
         {
            AV24FilterOrder = (short)(Math.Round(NumberUtil.Val( cmbavFilterorder.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV24FilterOrder), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24FilterOrder", StringUtil.LTrimStr( (decimal)(AV24FilterOrder), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavFilterorder.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24FilterOrder), 4, 0));
            AssignProp("", false, cmbavFilterorder_Internalname, "Values", cmbavFilterorder.ToJavascriptSource(), true);
         }
         AV25FilterOrderDesc = StringUtil.StrToBool( StringUtil.BoolToStr( AV25FilterOrderDesc));
         AssignAttri("", false, "AV25FilterOrderDesc", AV25FilterOrderDesc);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0X2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV34Pgmname = "WWProduct";
         context.Gx_err = 0;
         edtavUpdate_Enabled = 0;
         AssignProp("", false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_52_Refreshing);
         edtavDelete_Enabled = 0;
         AssignProp("", false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_52_Refreshing);
      }

      protected void RF0X2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 52;
         /* Execute user event: Refresh */
         E210X2 ();
         nGXsfl_52_idx = 1;
         sGXsfl_52_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_52_idx), 4, 0), 4, "0");
         SubsflControlProps_522( ) ;
         bGXsfl_52_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "ww__grid");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_522( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV19ProductName ,
                                                 AV27ProductCode ,
                                                 A16ProductName ,
                                                 A55ProductCode ,
                                                 AV15OrderedBy } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT
                                                 }
            });
            lV19ProductName = StringUtil.Concat( StringUtil.RTrim( AV19ProductName), "%", "");
            lV27ProductCode = StringUtil.Concat( StringUtil.RTrim( AV27ProductCode), "%", "");
            /* Using cursor H000X2 */
            pr_default.execute(0, new Object[] {lV19ProductName, lV27ProductCode, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_52_idx = 1;
            sGXsfl_52_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_52_idx), 4, 0), 4, "0");
            SubsflControlProps_522( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A4SupplierId = H000X2_A4SupplierId[0];
               A1BrandId = H000X2_A1BrandId[0];
               n1BrandId = H000X2_n1BrandId[0];
               A9SectorId = H000X2_A9SectorId[0];
               n9SectorId = H000X2_n9SectorId[0];
               A110ProductActive = H000X2_A110ProductActive[0];
               n110ProductActive = H000X2_n110ProductActive[0];
               A10SectorName = H000X2_A10SectorName[0];
               A2BrandName = H000X2_A2BrandName[0];
               A5SupplierName = H000X2_A5SupplierName[0];
               A93ProductMiniumQuantityWholesale = H000X2_A93ProductMiniumQuantityWholesale[0];
               n93ProductMiniumQuantityWholesale = H000X2_n93ProductMiniumQuantityWholesale[0];
               A17ProductStock = H000X2_A17ProductStock[0];
               n17ProductStock = H000X2_n17ProductStock[0];
               A16ProductName = H000X2_A16ProductName[0];
               A55ProductCode = H000X2_A55ProductCode[0];
               n55ProductCode = H000X2_n55ProductCode[0];
               A15ProductId = H000X2_A15ProductId[0];
               A89ProductRetailProfit = H000X2_A89ProductRetailProfit[0];
               n89ProductRetailProfit = H000X2_n89ProductRetailProfit[0];
               A85ProductCostPrice = H000X2_A85ProductCostPrice[0];
               n85ProductCostPrice = H000X2_n85ProductCostPrice[0];
               A87ProductWholesaleProfit = H000X2_A87ProductWholesaleProfit[0];
               n87ProductWholesaleProfit = H000X2_n87ProductWholesaleProfit[0];
               A5SupplierName = H000X2_A5SupplierName[0];
               A2BrandName = H000X2_A2BrandName[0];
               A10SectorName = H000X2_A10SectorName[0];
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
               E220X2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 52;
            WB0X0( ) ;
         }
         bGXsfl_52_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0X2( )
      {
         GxWebStd.gx_hidden_field( context, "vADVANCED_LABEL_TEMPLATE", StringUtil.RTrim( AV14ADVANCED_LABEL_TEMPLATE));
         GxWebStd.gx_hidden_field( context, "gxhash_vADVANCED_LABEL_TEMPLATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14ADVANCED_LABEL_TEMPLATE, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUCTID"+"_"+sGXsfl_52_idx, GetSecureSignedToken( sGXsfl_52_idx, context.localUtil.Format( (decimal)(A15ProductId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUCTACTIVE"+"_"+sGXsfl_52_idx, GetSecureSignedToken( sGXsfl_52_idx, A110ProductActive, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMESSAGE", AV31Message);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMESSAGE", AV31Message);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vMESSAGE", GetSecureSignedToken( "", AV31Message, context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV19ProductName ,
                                              AV27ProductCode ,
                                              A16ProductName ,
                                              A55ProductCode ,
                                              AV15OrderedBy } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT
                                              }
         });
         lV19ProductName = StringUtil.Concat( StringUtil.RTrim( AV19ProductName), "%", "");
         lV27ProductCode = StringUtil.Concat( StringUtil.RTrim( AV27ProductCode), "%", "");
         /* Using cursor H000X3 */
         pr_default.execute(1, new Object[] {lV19ProductName, lV27ProductCode});
         GRID_nRecordCount = H000X3_AGRID_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID_nRecordCount) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV19ProductName, AV15OrderedBy, AV16SupplierName, AV14ADVANCED_LABEL_TEMPLATE, AV17BrandName, AV13Delete, AV12Update, AV25FilterOrderDesc, AV31Message) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV19ProductName, AV15OrderedBy, AV16SupplierName, AV14ADVANCED_LABEL_TEMPLATE, AV17BrandName, AV13Delete, AV12Update, AV25FilterOrderDesc, AV31Message) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV19ProductName, AV15OrderedBy, AV16SupplierName, AV14ADVANCED_LABEL_TEMPLATE, AV17BrandName, AV13Delete, AV12Update, AV25FilterOrderDesc, AV31Message) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV19ProductName, AV15OrderedBy, AV16SupplierName, AV14ADVANCED_LABEL_TEMPLATE, AV17BrandName, AV13Delete, AV12Update, AV25FilterOrderDesc, AV31Message) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV19ProductName, AV15OrderedBy, AV16SupplierName, AV14ADVANCED_LABEL_TEMPLATE, AV17BrandName, AV13Delete, AV12Update, AV25FilterOrderDesc, AV31Message) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void subgrid_varsfromstate( )
      {
         if ( GridState.FilterCount >= 1 )
         {
            AV19ProductName = GridState.FilterValues("Productname");
            AssignAttri("", false, "AV19ProductName", AV19ProductName);
         }
         if ( GridState.OrderedBy != 0 )
         {
            AV15OrderedBy = GridState.OrderedBy;
            AssignAttri("", false, "AV15OrderedBy", StringUtil.LTrimStr( (decimal)(AV15OrderedBy), 4, 0));
         }
         if ( GridState.CurrentPage > 0 )
         {
            GridPageCount = subGrid_fnc_Pagecount( );
            if ( ( GridPageCount > 0 ) && ( GridPageCount < GridState.CurrentPage ) )
            {
               subgrid_gotopage( GridPageCount) ;
            }
            else
            {
               subgrid_gotopage( ((GridPageCount<0) ? 0 : GridState.CurrentPage)) ;
            }
         }
      }

      protected void subgrid_varstostate( )
      {
         GridState.CurrentPage = subGrid_fnc_Currentpage( );
         GridState.OrderedBy = AV15OrderedBy;
         GridState.ClearFilterValues();
         GridState.AddFilterValue("ProductName", AV19ProductName);
      }

      protected void before_start_formulas( )
      {
         AV34Pgmname = "WWProduct";
         context.Gx_err = 0;
         edtavUpdate_Enabled = 0;
         AssignProp("", false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_52_Refreshing);
         edtavDelete_Enabled = 0;
         AssignProp("", false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_52_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0X0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E200X2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_52 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_52"), ".", ","), 18, MidpointRounding.ToEven));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV19ProductName = cgiGet( edtavProductname_Internalname);
            AssignAttri("", false, "AV19ProductName", AV19ProductName);
            AV22FilterCode = cgiGet( edtavFiltercode_Internalname);
            AssignAttri("", false, "AV22FilterCode", AV22FilterCode);
            AV23FilterName = cgiGet( edtavFiltername_Internalname);
            AssignAttri("", false, "AV23FilterName", AV23FilterName);
            cmbavFilterorder.Name = cmbavFilterorder_Internalname;
            cmbavFilterorder.CurrentValue = cgiGet( cmbavFilterorder_Internalname);
            AV24FilterOrder = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavFilterorder_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24FilterOrder", StringUtil.LTrimStr( (decimal)(AV24FilterOrder), 4, 0));
            AV25FilterOrderDesc = StringUtil.StrToBool( cgiGet( chkavFilterorderdesc_Internalname));
            AssignAttri("", false, "AV25FilterOrderDesc", AV25FilterOrderDesc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavOrderedby_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavOrderedby_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vORDEREDBY");
               GX_FocusControl = edtavOrderedby_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV15OrderedBy = 0;
               AssignAttri("", false, "AV15OrderedBy", StringUtil.LTrimStr( (decimal)(AV15OrderedBy), 4, 0));
            }
            else
            {
               AV15OrderedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavOrderedby_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV15OrderedBy", StringUtil.LTrimStr( (decimal)(AV15OrderedBy), 4, 0));
            }
            AV16SupplierName = cgiGet( edtavSuppliername_Internalname);
            AssignAttri("", false, "AV16SupplierName", AV16SupplierName);
            AV17BrandName = cgiGet( edtavBrandname_Internalname);
            AssignAttri("", false, "AV17BrandName", AV17BrandName);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPRODUCTNAME"), AV19ProductName) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ".", ",") != Convert.ToDecimal( AV15OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E200X2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E200X2( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtSDTContextSession4 = new GeneXus.Programs.general.ui.SdtSDTContextSession();
         new checkauthentication(context ).execute( out  GXt_SdtSDTContextSession4) ;
         if ( ! new haspermission(context).executeUdp(  "product view") )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV34Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         if ( ! new haspermission(context).executeUdp(  "product insert") )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
            bttBtninsert_Enabled = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtninsert_Enabled), 5, 0), true);
         }
         if ( ! new haspermission(context).executeUdp(  "product delete") )
         {
            edtavDelete_Visible = 0;
            AssignProp("", false, edtavDelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDelete_Visible), 5, 0), !bGXsfl_52_Refreshing);
            edtavDelete_Enabled = 0;
            AssignProp("", false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_52_Refreshing);
         }
         else
         {
            AV13Delete = "Delete";
            AssignAttri("", false, edtavDelete_Internalname, AV13Delete);
         }
         if ( ! new haspermission(context).executeUdp(  "product update") )
         {
            edtavUpdate_Visible = 0;
            AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_52_Refreshing);
            edtavUpdate_Enabled = 0;
            AssignProp("", false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_52_Refreshing);
         }
         else
         {
            AV12Update = "Update";
            AssignAttri("", false, edtavUpdate_Internalname, AV12Update);
         }
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         AV15OrderedBy = 1;
         AssignAttri("", false, "AV15OrderedBy", StringUtil.LTrimStr( (decimal)(AV15OrderedBy), 4, 0));
         edtavSuppliername_Visible = 0;
         AssignProp("", false, edtavSuppliername_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSuppliername_Visible), 5, 0), true);
         edtavBrandname_Visible = 0;
         AssignProp("", false, edtavBrandname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavBrandname_Visible), 5, 0), true);
         Form.Caption = "Products";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
         AssignAttri("", false, "AV14ADVANCED_LABEL_TEMPLATE", AV14ADVANCED_LABEL_TEMPLATE);
         GxWebStd.gx_hidden_field( context, "gxhash_vADVANCED_LABEL_TEMPLATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14ADVANCED_LABEL_TEMPLATE, "")), context));
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         GridState.LoadGridState();
         bttBtntoggle_Visible = 0;
         AssignProp("", false, bttBtntoggle_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntoggle_Visible), 5, 0), true);
         bttBtntoggle_Enabled = 0;
         AssignProp("", false, bttBtntoggle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntoggle_Enabled), 5, 0), true);
         edtavProductname_Visible = 0;
         AssignProp("", false, edtavProductname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavProductname_Visible), 5, 0), true);
         edtavProductname_Enabled = 0;
         AssignProp("", false, edtavProductname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavProductname_Enabled), 5, 0), true);
         AV15OrderedBy = 1;
         AssignAttri("", false, "AV15OrderedBy", StringUtil.LTrimStr( (decimal)(AV15OrderedBy), 4, 0));
      }

      protected void E210X2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         GridState.SaveGridState();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16SupplierName)) )
         {
            lblLblsuppliernamefilter_Caption = "Supplier";
            AssignProp("", false, lblLblsuppliernamefilter_Internalname, "Caption", lblLblsuppliernamefilter_Caption, true);
         }
         else
         {
            lblLblsuppliernamefilter_Caption = StringUtil.Format( AV14ADVANCED_LABEL_TEMPLATE, "Supplier", AV16SupplierName, "", "", "", "", "", "", "");
            AssignProp("", false, lblLblsuppliernamefilter_Internalname, "Caption", lblLblsuppliernamefilter_Caption, true);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17BrandName)) )
         {
            lblLblbrandnamefilter_Caption = "Brand";
            AssignProp("", false, lblLblbrandnamefilter_Internalname, "Caption", lblLblbrandnamefilter_Caption, true);
         }
         else
         {
            lblLblbrandnamefilter_Caption = StringUtil.Format( AV14ADVANCED_LABEL_TEMPLATE, "Brand", AV17BrandName, "", "", "", "", "", "", "");
            AssignProp("", false, lblLblbrandnamefilter_Internalname, "Caption", lblLblbrandnamefilter_Caption, true);
         }
         /*  Sending Event outputs  */
      }

      private void E220X2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         edtavUpdate_Link = formatLink("product.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.LTrimStr(A15ProductId,6,0))}, new string[] {"Mode","ProductId"}) ;
         if ( A110ProductActive )
         {
            AV13Delete = "Deactive";
            AssignAttri("", false, edtavDelete_Internalname, AV13Delete);
            edtavDelete_Jsonclick = "confirm('Are you sure to Deactive Product?')";
         }
         else
         {
            AV13Delete = "Active";
            AssignAttri("", false, edtavDelete_Internalname, AV13Delete);
            edtavDelete_Jsonclick = "confirm('Are you sure to Active Product?')";
         }
         edtProductName_Link = formatLink("viewproduct.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A15ProductId,6,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"ProductId","TabCode"}) ;
         if ( new haspermission(context).executeUdp(  "supplier view") )
         {
            edtSupplierName_Link = formatLink("viewsupplier.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A4SupplierId,6,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"SupplierId","TabCode"}) ;
         }
         if ( new haspermission(context).executeUdp(  "brand view") )
         {
            edtBrandName_Link = formatLink("viewbrand.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A1BrandId,6,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"BrandId","TabCode"}) ;
         }
         if ( new haspermission(context).executeUdp(  "sector name") )
         {
            edtSectorName_Link = formatLink("viewsector.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A9SectorId,6,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"SectorId","TabCode"}) ;
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 52;
         }
         sendrow_522( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_52_Refreshing )
         {
            DoAjaxLoad(52, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E140X2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         CallWebObject(formatLink("product.aspx", new object[] {UrlEncode(StringUtil.RTrim("INS")),UrlEncode(StringUtil.LTrimStr(0,1,0))}, new string[] {"Mode","ProductId"}) );
         context.wjLocDisableFrm = 1;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV34Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "Product";
         AV6Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      protected void E150X2( )
      {
         /* 'DoExport' Routine */
         returnInSub = false;
         new exportwwproduct(context ).execute(  AV19ProductName,  AV27ProductCode,  AV15OrderedBy, out  AV20ExcelFilename, out  AV21ErrorMessage) ;
         if ( StringUtil.StrCmp(AV20ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV20ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV21ErrorMessage);
         }
      }

      protected void E160X2( )
      {
         /* Filtername_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'UPDVARIABLES' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E170X2( )
      {
         /* Filtercode_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'UPDVARIABLES' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E180X2( )
      {
         /* Filterorder_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'UPDVARIABLES' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E190X2( )
      {
         /* Filterorderdesc_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'UPDVARIABLES' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E230X2( )
      {
         /* Delete_Click Routine */
         returnInSub = false;
         new productcandisabled(context ).execute(  A15ProductId, out  AV30CanDisabled, out  AV28ErrorMessages) ;
         if ( AV30CanDisabled )
         {
            if ( new haspermission(context).executeUdp(  "product delete") )
            {
               if ( A110ProductActive )
               {
                  new productactivedeactive(context ).execute(  A15ProductId,  false, out  AV29AllOk, out  AV28ErrorMessages) ;
                  if ( ! AV29AllOk )
                  {
                     GX_msglist.addItem("Error deactivating product"+AV28ErrorMessages.ToJSonString(false));
                  }
                  else
                  {
                     GX_msglist.addItem("Product deactived succesfully");
                     gxgrGrid_refresh( subGrid_Rows, AV19ProductName, AV15OrderedBy, AV16SupplierName, AV14ADVANCED_LABEL_TEMPLATE, AV17BrandName, AV13Delete, AV12Update, AV25FilterOrderDesc, AV31Message) ;
                  }
               }
               else
               {
                  new productactivedeactive(context ).execute(  A15ProductId,  true, out  AV29AllOk, out  AV28ErrorMessages) ;
                  if ( ! AV29AllOk )
                  {
                     GX_msglist.addItem("Error activating product"+AV28ErrorMessages.ToJSonString(false));
                  }
                  else
                  {
                     GX_msglist.addItem("Product actived succesfully");
                     gxgrGrid_refresh( subGrid_Rows, AV19ProductName, AV15OrderedBy, AV16SupplierName, AV14ADVANCED_LABEL_TEMPLATE, AV17BrandName, AV13Delete, AV12Update, AV25FilterOrderDesc, AV31Message) ;
                  }
               }
            }
         }
         else
         {
            GX_msglist.addItem("Product cant disable, "+AV31Message.gxTpr_Description);
         }
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'UPDVARIABLES' Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22FilterCode)) )
         {
            AV27ProductCode = AV22FilterCode;
            AssignAttri("", false, "AV27ProductCode", AV27ProductCode);
         }
         else
         {
            AV27ProductCode = "";
            AssignAttri("", false, "AV27ProductCode", AV27ProductCode);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23FilterName)) )
         {
            AV19ProductName = AV23FilterName;
            AssignAttri("", false, "AV19ProductName", AV19ProductName);
         }
         else
         {
            AV19ProductName = "";
            AssignAttri("", false, "AV19ProductName", AV19ProductName);
         }
         if ( AV24FilterOrder == 1 )
         {
            if ( ! AV25FilterOrderDesc )
            {
               AV15OrderedBy = 1;
               AssignAttri("", false, "AV15OrderedBy", StringUtil.LTrimStr( (decimal)(AV15OrderedBy), 4, 0));
            }
            else
            {
               AV15OrderedBy = 2;
               AssignAttri("", false, "AV15OrderedBy", StringUtil.LTrimStr( (decimal)(AV15OrderedBy), 4, 0));
            }
         }
         else if ( AV24FilterOrder == 2 )
         {
            if ( ! AV25FilterOrderDesc )
            {
               AV15OrderedBy = 3;
               AssignAttri("", false, "AV15OrderedBy", StringUtil.LTrimStr( (decimal)(AV15OrderedBy), 4, 0));
            }
            else
            {
               AV15OrderedBy = 4;
               AssignAttri("", false, "AV15OrderedBy", StringUtil.LTrimStr( (decimal)(AV15OrderedBy), 4, 0));
            }
         }
         else if ( AV24FilterOrder == 3 )
         {
            if ( ! AV25FilterOrderDesc )
            {
               AV15OrderedBy = 5;
               AssignAttri("", false, "AV15OrderedBy", StringUtil.LTrimStr( (decimal)(AV15OrderedBy), 4, 0));
            }
            else
            {
               AV15OrderedBy = 6;
               AssignAttri("", false, "AV15OrderedBy", StringUtil.LTrimStr( (decimal)(AV15OrderedBy), 4, 0));
            }
         }
         subgrid_firstpage( ) ;
         gxgrGrid_refresh( subGrid_Rows, AV19ProductName, AV15OrderedBy, AV16SupplierName, AV14ADVANCED_LABEL_TEMPLATE, AV17BrandName, AV13Delete, AV12Update, AV25FilterOrderDesc, AV31Message) ;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA0X2( ) ;
         WS0X2( ) ;
         WE0X2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20241222303185", true, true);
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
         context.AddJavascriptSource("wwproduct.js", "?20241222303185", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_522( )
      {
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_52_idx;
         edtProductCode_Internalname = "PRODUCTCODE_"+sGXsfl_52_idx;
         edtProductName_Internalname = "PRODUCTNAME_"+sGXsfl_52_idx;
         edtProductStock_Internalname = "PRODUCTSTOCK_"+sGXsfl_52_idx;
         edtProductCostPrice_Internalname = "PRODUCTCOSTPRICE_"+sGXsfl_52_idx;
         edtProductRetailPrice_Internalname = "PRODUCTRETAILPRICE_"+sGXsfl_52_idx;
         edtProductWholesalePrice_Internalname = "PRODUCTWHOLESALEPRICE_"+sGXsfl_52_idx;
         edtProductMiniumQuantityWholesale_Internalname = "PRODUCTMINIUMQUANTITYWHOLESALE_"+sGXsfl_52_idx;
         edtSupplierName_Internalname = "SUPPLIERNAME_"+sGXsfl_52_idx;
         edtBrandName_Internalname = "BRANDNAME_"+sGXsfl_52_idx;
         edtSectorName_Internalname = "SECTORNAME_"+sGXsfl_52_idx;
         chkProductActive_Internalname = "PRODUCTACTIVE_"+sGXsfl_52_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_52_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_52_idx;
      }

      protected void SubsflControlProps_fel_522( )
      {
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_52_fel_idx;
         edtProductCode_Internalname = "PRODUCTCODE_"+sGXsfl_52_fel_idx;
         edtProductName_Internalname = "PRODUCTNAME_"+sGXsfl_52_fel_idx;
         edtProductStock_Internalname = "PRODUCTSTOCK_"+sGXsfl_52_fel_idx;
         edtProductCostPrice_Internalname = "PRODUCTCOSTPRICE_"+sGXsfl_52_fel_idx;
         edtProductRetailPrice_Internalname = "PRODUCTRETAILPRICE_"+sGXsfl_52_fel_idx;
         edtProductWholesalePrice_Internalname = "PRODUCTWHOLESALEPRICE_"+sGXsfl_52_fel_idx;
         edtProductMiniumQuantityWholesale_Internalname = "PRODUCTMINIUMQUANTITYWHOLESALE_"+sGXsfl_52_fel_idx;
         edtSupplierName_Internalname = "SUPPLIERNAME_"+sGXsfl_52_fel_idx;
         edtBrandName_Internalname = "BRANDNAME_"+sGXsfl_52_fel_idx;
         edtSectorName_Internalname = "SECTORNAME_"+sGXsfl_52_fel_idx;
         chkProductActive_Internalname = "PRODUCTACTIVE_"+sGXsfl_52_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_52_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_52_fel_idx;
      }

      protected void sendrow_522( )
      {
         SubsflControlProps_522( ) ;
         WB0X0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_52_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0x0);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_52_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"ww__grid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_52_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A15ProductId), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)52,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductCode_Internalname,(string)A55ProductCode,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductCode_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)52,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusUnanimo\\Code",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "attribute-description";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductName_Internalname,(string)A16ProductName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtProductName_Link,(string)"",(string)"",(string)"",(string)edtProductName_Jsonclick,(short)0,(string)"attribute-description",(string)"",(string)ROClassString,(string)"column",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)52,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductStock_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A17ProductStock), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A17ProductStock), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductStock_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)52,(short)0,(short)-1,(short)0,(bool)true,(string)"Stock",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductCostPrice_Internalname,StringUtil.LTrim( StringUtil.NToC( A85ProductCostPrice, 18, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A85ProductCostPrice, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductCostPrice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column WWOptionalColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)52,(short)0,(short)-1,(short)0,(bool)true,(string)"Price",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductRetailPrice_Internalname,StringUtil.LTrim( StringUtil.NToC( A90ProductRetailPrice, 18, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A90ProductRetailPrice, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductRetailPrice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)52,(short)0,(short)-1,(short)0,(bool)true,(string)"Price",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductWholesalePrice_Internalname,StringUtil.LTrim( StringUtil.NToC( A88ProductWholesalePrice, 18, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A88ProductWholesalePrice, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductWholesalePrice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)52,(short)0,(short)-1,(short)0,(bool)true,(string)"Price",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductMiniumQuantityWholesale_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A93ProductMiniumQuantityWholesale), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A93ProductMiniumQuantityWholesale), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductMiniumQuantityWholesale_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)52,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierName_Internalname,(string)A5SupplierName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtSupplierName_Link,(string)"",(string)"",(string)"",(string)edtSupplierName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column WWOptionalColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)52,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtBrandName_Internalname,(string)A2BrandName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtBrandName_Link,(string)"",(string)"",(string)"",(string)edtBrandName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column WWOptionalColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)52,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSectorName_Internalname,(string)A10SectorName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtSectorName_Link,(string)"",(string)"",(string)"",(string)edtSectorName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column WWOptionalColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)52,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "PRODUCTACTIVE_" + sGXsfl_52_idx;
            chkProductActive.Name = GXCCtl;
            chkProductActive.WebTags = "";
            chkProductActive.Caption = "";
            AssignProp("", false, chkProductActive_Internalname, "TitleCaption", chkProductActive.Caption, !bGXsfl_52_Refreshing);
            chkProductActive.CheckedValue = "false";
            A110ProductActive = StringUtil.StrToBool( StringUtil.BoolToStr( A110ProductActive));
            n110ProductActive = false;
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkProductActive_Internalname,StringUtil.BoolToStr( A110ProductActive),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavUpdate_Enabled!=0)&&(edtavUpdate_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 65,'',false,'"+sGXsfl_52_idx+"',52)\"" : " ");
            ROClassString = "TextActionAttribute TextLikeLink";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV12Update),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavUpdate_Enabled!=0)&&(edtavUpdate_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,65);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",(string)"",(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"TextActionAttribute TextLikeLink",(string)"",(string)ROClassString,(string)"WWTextActionColumn",(string)"",(int)edtavUpdate_Visible,(int)edtavUpdate_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)52,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavDelete_Enabled!=0)&&(edtavDelete_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 66,'',false,'"+sGXsfl_52_idx+"',52)\"" : " ");
            ROClassString = "TextActionAttribute TextLikeLink";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV13Delete),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavDelete_Enabled!=0)&&(edtavDelete_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,66);\"" : " "),"'"+""+"'"+",false,"+"'"+"EVDELETE.CLICK."+sGXsfl_52_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDelete_Jsonclick,(short)5,(string)"TextActionAttribute TextLikeLink",(string)"",(string)ROClassString,(string)"WWTextActionColumn",(string)"",(int)edtavDelete_Visible,(int)edtavDelete_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)52,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes0X2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_52_idx = ((subGrid_Islastpage==1)&&(nGXsfl_52_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_52_idx+1);
            sGXsfl_52_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_52_idx), 4, 0), 4, "0");
            SubsflControlProps_522( ) ;
         }
         /* End function sendrow_522 */
      }

      protected void init_web_controls( )
      {
         cmbavFilterorder.Name = "vFILTERORDER";
         cmbavFilterorder.WebTags = "";
         cmbavFilterorder.addItem("1", "Name", 0);
         cmbavFilterorder.addItem("2", "Code", 0);
         cmbavFilterorder.addItem("3", "Stock", 0);
         if ( cmbavFilterorder.ItemCount > 0 )
         {
            AV24FilterOrder = (short)(Math.Round(NumberUtil.Val( cmbavFilterorder.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV24FilterOrder), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24FilterOrder", StringUtil.LTrimStr( (decimal)(AV24FilterOrder), 4, 0));
         }
         chkavFilterorderdesc.Name = "vFILTERORDERDESC";
         chkavFilterorderdesc.WebTags = "";
         chkavFilterorderdesc.Caption = "";
         AssignProp("", false, chkavFilterorderdesc_Internalname, "TitleCaption", chkavFilterorderdesc.Caption, true);
         chkavFilterorderdesc.CheckedValue = "false";
         AV25FilterOrderDesc = StringUtil.StrToBool( StringUtil.BoolToStr( AV25FilterOrderDesc));
         AssignAttri("", false, "AV25FilterOrderDesc", AV25FilterOrderDesc);
         GXCCtl = "PRODUCTACTIVE_" + sGXsfl_52_idx;
         chkProductActive.Name = GXCCtl;
         chkProductActive.WebTags = "";
         chkProductActive.Caption = "";
         AssignProp("", false, chkProductActive_Internalname, "TitleCaption", chkProductActive.Caption, !bGXsfl_52_Refreshing);
         chkProductActive.CheckedValue = "false";
         A110ProductActive = StringUtil.StrToBool( StringUtil.BoolToStr( A110ProductActive));
         n110ProductActive = false;
         /* End function init_web_controls */
      }

      protected void StartGridControl52( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"52\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "ww__grid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid_Backcolorstyle == 0 )
            {
               subGrid_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid_Class) > 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Title";
               }
            }
            else
            {
               subGrid_Titlebackstyle = 1;
               if ( subGrid_Backcolorstyle == 1 )
               {
                  subGrid_Titlebackcolor = subGrid_Allbackcolor;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Product Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Code") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"attribute-description"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "C. Stock") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Cost Price") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "R. Price") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "W. Price") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Qty. Wholesale") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Supplier") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Brand") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Sector") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Active") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"TextActionAttribute TextLikeLink"+"\" "+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"TextActionAttribute TextLikeLink"+"\" "+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridContainer = new GXWebGrid( context);
            }
            else
            {
               GridContainer.Clear();
            }
            GridContainer.SetWrapped(nGXWrapped);
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", "ww__grid");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A55ProductCode));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A16ProductName));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtProductName_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A17ProductStock), 6, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A85ProductCostPrice, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A90ProductRetailPrice, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A88ProductWholesalePrice, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A93ProductMiniumQuantityWholesale), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A5SupplierName));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtSupplierName_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A2BrandName));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtBrandName_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A10SectorName));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtSectorName_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A110ProductActive)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV12Update)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV13Delete)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Visible), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Jsonclick", StringUtil.RTrim( edtavDelete_Jsonclick));
            GridContainer.AddColumnProperties(GridColumn);
            GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblTitletext_Internalname = "TITLETEXT";
         lbllbl15_Internalname = "LBL15";
         bttBtninsert_Internalname = "BTNINSERT";
         bttBtnexport_Internalname = "BTNEXPORT";
         divActions_inner_Internalname = "ACTIONS_INNER";
         edtavProductname_Internalname = "vPRODUCTNAME";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         divTabletop_Internalname = "TABLETOP";
         edtavFiltercode_Internalname = "vFILTERCODE";
         edtavFiltername_Internalname = "vFILTERNAME";
         cmbavFilterorder_Internalname = "vFILTERORDER";
         chkavFilterorderdesc_Internalname = "vFILTERORDERDESC";
         divTable1_Internalname = "TABLE1";
         edtProductId_Internalname = "PRODUCTID";
         edtProductCode_Internalname = "PRODUCTCODE";
         edtProductName_Internalname = "PRODUCTNAME";
         edtProductStock_Internalname = "PRODUCTSTOCK";
         edtProductCostPrice_Internalname = "PRODUCTCOSTPRICE";
         edtProductRetailPrice_Internalname = "PRODUCTRETAILPRICE";
         edtProductWholesalePrice_Internalname = "PRODUCTWHOLESALEPRICE";
         edtProductMiniumQuantityWholesale_Internalname = "PRODUCTMINIUMQUANTITYWHOLESALE";
         edtSupplierName_Internalname = "SUPPLIERNAME";
         edtBrandName_Internalname = "BRANDNAME";
         edtSectorName_Internalname = "SECTORNAME";
         chkProductActive_Internalname = "PRODUCTACTIVE";
         edtavUpdate_Internalname = "vUPDATE";
         edtavDelete_Internalname = "vDELETE";
         divGridcontainer_Internalname = "GRIDCONTAINER";
         divGridtable_Internalname = "GRIDTABLE";
         divGridcell_Internalname = "GRIDCELL";
         bttBtntoggleontable_Internalname = "BTNTOGGLEONTABLE";
         edtavOrderedby_Internalname = "vORDEREDBY";
         lblLblsuppliernamefilter_Internalname = "LBLSUPPLIERNAMEFILTER";
         edtavSuppliername_Internalname = "vSUPPLIERNAME";
         divSuppliernamefiltercontainer_Internalname = "SUPPLIERNAMEFILTERCONTAINER";
         lblLblbrandnamefilter_Internalname = "LBLBRANDNAMEFILTER";
         edtavBrandname_Internalname = "vBRANDNAME";
         divBrandnamefiltercontainer_Internalname = "BRANDNAMEFILTERCONTAINER";
         divFilterscontainer_Internalname = "FILTERSCONTAINER";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGrid_Internalname = "GRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("mtaKB", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         chkavFilterorderdesc.Caption = "Order Desc";
         edtavDelete_Jsonclick = "";
         edtavUpdate_Jsonclick = "";
         edtavUpdate_Link = "";
         chkProductActive.Caption = "";
         edtSectorName_Jsonclick = "";
         edtSectorName_Link = "";
         edtBrandName_Jsonclick = "";
         edtBrandName_Link = "";
         edtSupplierName_Jsonclick = "";
         edtSupplierName_Link = "";
         edtProductMiniumQuantityWholesale_Jsonclick = "";
         edtProductWholesalePrice_Jsonclick = "";
         edtProductRetailPrice_Jsonclick = "";
         edtProductCostPrice_Jsonclick = "";
         edtProductStock_Jsonclick = "";
         edtProductName_Jsonclick = "";
         edtProductName_Link = "";
         edtProductCode_Jsonclick = "";
         edtProductId_Jsonclick = "";
         subGrid_Class = "ww__grid";
         subGrid_Backcolorstyle = 0;
         edtavBrandname_Jsonclick = "";
         edtavBrandname_Enabled = 1;
         edtavBrandname_Visible = 1;
         lblLblbrandnamefilter_Caption = "Brand";
         edtavSuppliername_Jsonclick = "";
         edtavSuppliername_Enabled = 1;
         edtavSuppliername_Visible = 1;
         lblLblsuppliernamefilter_Caption = "Supplier";
         edtavOrderedby_Jsonclick = "";
         edtavOrderedby_Enabled = 1;
         chkavFilterorderdesc.Enabled = 1;
         cmbavFilterorder_Jsonclick = "";
         cmbavFilterorder.Enabled = 1;
         edtavFiltername_Jsonclick = "";
         edtavFiltername_Enabled = 1;
         edtavFiltercode_Jsonclick = "";
         edtavFiltercode_Enabled = 1;
         bttBtntoggle_Class = "ww__button-filters--hide";
         bttBtntoggle_Tooltiptext = "Show Filters";
         bttBtntoggle_Caption = "Show Filters";
         bttBtntoggle_Enabled = 1;
         bttBtntoggle_Visible = 1;
         edtavProductname_Jsonclick = "";
         edtavProductname_Enabled = 1;
         edtavProductname_Visible = 1;
         bttBtninsert_Enabled = 1;
         bttBtninsert_Visible = 1;
         divGridcell_Class = "col-xs-12 col-sm-9 col-md-10 ww__grid-cell--expanded";
         divBrandnamefiltercontainer_Class = "filters-container__item";
         divSuppliernamefiltercontainer_Class = "filters-container__item";
         divFilterscontainer_Class = "filters-container";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Work With Product";
         edtavUpdate_Enabled = 1;
         edtavUpdate_Visible = -1;
         edtavDelete_Enabled = 1;
         edtavDelete_Visible = -1;
         subGrid_Rows = 8;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV19ProductName',fld:'vPRODUCTNAME',pic:''},{av:'AV15OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'edtavDelete_Enabled',ctrl:'vDELETE',prop:'Enabled'},{av:'AV13Delete',fld:'vDELETE',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavUpdate_Enabled',ctrl:'vUPDATE',prop:'Enabled'},{av:'AV12Update',fld:'vUPDATE',pic:''},{av:'AV16SupplierName',fld:'vSUPPLIERNAME',pic:''},{av:'AV17BrandName',fld:'vBRANDNAME',pic:''},{av:'AV25FilterOrderDesc',fld:'vFILTERORDERDESC',pic:''},{av:'AV14ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV31Message',fld:'vMESSAGE',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'lblLblsuppliernamefilter_Caption',ctrl:'LBLSUPPLIERNAMEFILTER',prop:'Caption'},{av:'lblLblbrandnamefilter_Caption',ctrl:'LBLBRANDNAMEFILTER',prop:'Caption'}]}");
         setEventMetadata("'TOGGLE'","{handler:'E110X1',iparms:[{av:'divFilterscontainer_Class',ctrl:'FILTERSCONTAINER',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divFilterscontainer_Class',ctrl:'FILTERSCONTAINER',prop:'Class'},{av:'divGridcell_Class',ctrl:'GRIDCELL',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Caption'},{ctrl:'BTNTOGGLE',prop:'Tooltiptext'}]}");
         setEventMetadata("LBLSUPPLIERNAMEFILTER.CLICK","{handler:'E120X1',iparms:[{av:'divSuppliernamefiltercontainer_Class',ctrl:'SUPPLIERNAMEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLSUPPLIERNAMEFILTER.CLICK",",oparms:[{av:'divSuppliernamefiltercontainer_Class',ctrl:'SUPPLIERNAMEFILTERCONTAINER',prop:'Class'},{av:'edtavSuppliername_Visible',ctrl:'vSUPPLIERNAME',prop:'Visible'}]}");
         setEventMetadata("LBLBRANDNAMEFILTER.CLICK","{handler:'E130X1',iparms:[{av:'divBrandnamefiltercontainer_Class',ctrl:'BRANDNAMEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLBRANDNAMEFILTER.CLICK",",oparms:[{av:'divBrandnamefiltercontainer_Class',ctrl:'BRANDNAMEFILTERCONTAINER',prop:'Class'},{av:'edtavBrandname_Visible',ctrl:'vBRANDNAME',prop:'Visible'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E220X2',iparms:[{av:'A15ProductId',fld:'PRODUCTID',pic:'ZZZZZ9',hsh:true},{av:'A110ProductActive',fld:'PRODUCTACTIVE',pic:'',hsh:true},{av:'A4SupplierId',fld:'SUPPLIERID',pic:'ZZZZZ9'},{av:'A1BrandId',fld:'BRANDID',pic:'ZZZZZ9'},{av:'A9SectorId',fld:'SECTORID',pic:'ZZZZZ9'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'edtavUpdate_Link',ctrl:'vUPDATE',prop:'Link'},{av:'AV13Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Jsonclick',ctrl:'vDELETE',prop:'Jsonclick'},{av:'edtProductName_Link',ctrl:'PRODUCTNAME',prop:'Link'},{av:'edtSupplierName_Link',ctrl:'SUPPLIERNAME',prop:'Link'},{av:'edtBrandName_Link',ctrl:'BRANDNAME',prop:'Link'},{av:'edtSectorName_Link',ctrl:'SECTORNAME',prop:'Link'}]}");
         setEventMetadata("'DOINSERT'","{handler:'E140X2',iparms:[{av:'A15ProductId',fld:'PRODUCTID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("'DOEXPORT'","{handler:'E150X2',iparms:[{av:'AV19ProductName',fld:'vPRODUCTNAME',pic:''},{av:'AV27ProductCode',fld:'vPRODUCTCODE',pic:''},{av:'AV15OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'}]");
         setEventMetadata("'DOEXPORT'",",oparms:[]}");
         setEventMetadata("VFILTERNAME.CONTROLVALUECHANGED","{handler:'E160X2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV19ProductName',fld:'vPRODUCTNAME',pic:''},{av:'AV15OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV16SupplierName',fld:'vSUPPLIERNAME',pic:''},{av:'AV14ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV17BrandName',fld:'vBRANDNAME',pic:''},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'edtavDelete_Enabled',ctrl:'vDELETE',prop:'Enabled'},{av:'AV13Delete',fld:'vDELETE',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavUpdate_Enabled',ctrl:'vUPDATE',prop:'Enabled'},{av:'AV12Update',fld:'vUPDATE',pic:''},{av:'AV25FilterOrderDesc',fld:'vFILTERORDERDESC',pic:''},{av:'AV31Message',fld:'vMESSAGE',pic:'',hsh:true},{av:'AV22FilterCode',fld:'vFILTERCODE',pic:''},{av:'AV23FilterName',fld:'vFILTERNAME',pic:''},{av:'cmbavFilterorder'},{av:'AV24FilterOrder',fld:'vFILTERORDER',pic:'ZZZ9'}]");
         setEventMetadata("VFILTERNAME.CONTROLVALUECHANGED",",oparms:[{av:'AV27ProductCode',fld:'vPRODUCTCODE',pic:''},{av:'AV19ProductName',fld:'vPRODUCTNAME',pic:''},{av:'AV15OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'lblLblsuppliernamefilter_Caption',ctrl:'LBLSUPPLIERNAMEFILTER',prop:'Caption'},{av:'lblLblbrandnamefilter_Caption',ctrl:'LBLBRANDNAMEFILTER',prop:'Caption'}]}");
         setEventMetadata("VFILTERCODE.CONTROLVALUECHANGED","{handler:'E170X2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV19ProductName',fld:'vPRODUCTNAME',pic:''},{av:'AV15OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV16SupplierName',fld:'vSUPPLIERNAME',pic:''},{av:'AV14ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV17BrandName',fld:'vBRANDNAME',pic:''},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'edtavDelete_Enabled',ctrl:'vDELETE',prop:'Enabled'},{av:'AV13Delete',fld:'vDELETE',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavUpdate_Enabled',ctrl:'vUPDATE',prop:'Enabled'},{av:'AV12Update',fld:'vUPDATE',pic:''},{av:'AV25FilterOrderDesc',fld:'vFILTERORDERDESC',pic:''},{av:'AV31Message',fld:'vMESSAGE',pic:'',hsh:true},{av:'AV22FilterCode',fld:'vFILTERCODE',pic:''},{av:'AV23FilterName',fld:'vFILTERNAME',pic:''},{av:'cmbavFilterorder'},{av:'AV24FilterOrder',fld:'vFILTERORDER',pic:'ZZZ9'}]");
         setEventMetadata("VFILTERCODE.CONTROLVALUECHANGED",",oparms:[{av:'AV27ProductCode',fld:'vPRODUCTCODE',pic:''},{av:'AV19ProductName',fld:'vPRODUCTNAME',pic:''},{av:'AV15OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'lblLblsuppliernamefilter_Caption',ctrl:'LBLSUPPLIERNAMEFILTER',prop:'Caption'},{av:'lblLblbrandnamefilter_Caption',ctrl:'LBLBRANDNAMEFILTER',prop:'Caption'}]}");
         setEventMetadata("VFILTERORDER.CONTROLVALUECHANGED","{handler:'E180X2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV19ProductName',fld:'vPRODUCTNAME',pic:''},{av:'AV15OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV16SupplierName',fld:'vSUPPLIERNAME',pic:''},{av:'AV14ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV17BrandName',fld:'vBRANDNAME',pic:''},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'edtavDelete_Enabled',ctrl:'vDELETE',prop:'Enabled'},{av:'AV13Delete',fld:'vDELETE',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavUpdate_Enabled',ctrl:'vUPDATE',prop:'Enabled'},{av:'AV12Update',fld:'vUPDATE',pic:''},{av:'AV25FilterOrderDesc',fld:'vFILTERORDERDESC',pic:''},{av:'AV31Message',fld:'vMESSAGE',pic:'',hsh:true},{av:'AV22FilterCode',fld:'vFILTERCODE',pic:''},{av:'AV23FilterName',fld:'vFILTERNAME',pic:''},{av:'cmbavFilterorder'},{av:'AV24FilterOrder',fld:'vFILTERORDER',pic:'ZZZ9'}]");
         setEventMetadata("VFILTERORDER.CONTROLVALUECHANGED",",oparms:[{av:'AV27ProductCode',fld:'vPRODUCTCODE',pic:''},{av:'AV19ProductName',fld:'vPRODUCTNAME',pic:''},{av:'AV15OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'lblLblsuppliernamefilter_Caption',ctrl:'LBLSUPPLIERNAMEFILTER',prop:'Caption'},{av:'lblLblbrandnamefilter_Caption',ctrl:'LBLBRANDNAMEFILTER',prop:'Caption'}]}");
         setEventMetadata("VFILTERORDERDESC.CONTROLVALUECHANGED","{handler:'E190X2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV19ProductName',fld:'vPRODUCTNAME',pic:''},{av:'AV15OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV16SupplierName',fld:'vSUPPLIERNAME',pic:''},{av:'AV14ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV17BrandName',fld:'vBRANDNAME',pic:''},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'edtavDelete_Enabled',ctrl:'vDELETE',prop:'Enabled'},{av:'AV13Delete',fld:'vDELETE',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavUpdate_Enabled',ctrl:'vUPDATE',prop:'Enabled'},{av:'AV12Update',fld:'vUPDATE',pic:''},{av:'AV25FilterOrderDesc',fld:'vFILTERORDERDESC',pic:''},{av:'AV31Message',fld:'vMESSAGE',pic:'',hsh:true},{av:'AV22FilterCode',fld:'vFILTERCODE',pic:''},{av:'AV23FilterName',fld:'vFILTERNAME',pic:''},{av:'cmbavFilterorder'},{av:'AV24FilterOrder',fld:'vFILTERORDER',pic:'ZZZ9'}]");
         setEventMetadata("VFILTERORDERDESC.CONTROLVALUECHANGED",",oparms:[{av:'AV27ProductCode',fld:'vPRODUCTCODE',pic:''},{av:'AV19ProductName',fld:'vPRODUCTNAME',pic:''},{av:'AV15OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'lblLblsuppliernamefilter_Caption',ctrl:'LBLSUPPLIERNAMEFILTER',prop:'Caption'},{av:'lblLblbrandnamefilter_Caption',ctrl:'LBLBRANDNAMEFILTER',prop:'Caption'}]}");
         setEventMetadata("VDELETE.CLICK","{handler:'E230X2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV19ProductName',fld:'vPRODUCTNAME',pic:''},{av:'AV15OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV16SupplierName',fld:'vSUPPLIERNAME',pic:''},{av:'AV14ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV17BrandName',fld:'vBRANDNAME',pic:''},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'edtavDelete_Enabled',ctrl:'vDELETE',prop:'Enabled'},{av:'AV13Delete',fld:'vDELETE',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavUpdate_Enabled',ctrl:'vUPDATE',prop:'Enabled'},{av:'AV12Update',fld:'vUPDATE',pic:''},{av:'AV25FilterOrderDesc',fld:'vFILTERORDERDESC',pic:''},{av:'AV31Message',fld:'vMESSAGE',pic:'',hsh:true},{av:'A15ProductId',fld:'PRODUCTID',pic:'ZZZZZ9',hsh:true},{av:'A110ProductActive',fld:'PRODUCTACTIVE',pic:'',hsh:true}]");
         setEventMetadata("VDELETE.CLICK",",oparms:[{av:'lblLblsuppliernamefilter_Caption',ctrl:'LBLSUPPLIERNAMEFILTER',prop:'Caption'},{av:'lblLblbrandnamefilter_Caption',ctrl:'LBLBRANDNAMEFILTER',prop:'Caption'}]}");
         setEventMetadata("GRID_FIRSTPAGE","{handler:'subgrid_firstpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV19ProductName',fld:'vPRODUCTNAME',pic:''},{av:'AV15OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'edtavDelete_Enabled',ctrl:'vDELETE',prop:'Enabled'},{av:'AV13Delete',fld:'vDELETE',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavUpdate_Enabled',ctrl:'vUPDATE',prop:'Enabled'},{av:'AV12Update',fld:'vUPDATE',pic:''},{av:'AV31Message',fld:'vMESSAGE',pic:'',hsh:true},{av:'AV16SupplierName',fld:'vSUPPLIERNAME',pic:''},{av:'AV14ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV17BrandName',fld:'vBRANDNAME',pic:''},{av:'AV25FilterOrderDesc',fld:'vFILTERORDERDESC',pic:''}]");
         setEventMetadata("GRID_FIRSTPAGE",",oparms:[{av:'lblLblsuppliernamefilter_Caption',ctrl:'LBLSUPPLIERNAMEFILTER',prop:'Caption'},{av:'lblLblbrandnamefilter_Caption',ctrl:'LBLBRANDNAMEFILTER',prop:'Caption'}]}");
         setEventMetadata("GRID_PREVPAGE","{handler:'subgrid_previouspage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV19ProductName',fld:'vPRODUCTNAME',pic:''},{av:'AV15OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'edtavDelete_Enabled',ctrl:'vDELETE',prop:'Enabled'},{av:'AV13Delete',fld:'vDELETE',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavUpdate_Enabled',ctrl:'vUPDATE',prop:'Enabled'},{av:'AV12Update',fld:'vUPDATE',pic:''},{av:'AV31Message',fld:'vMESSAGE',pic:'',hsh:true},{av:'AV16SupplierName',fld:'vSUPPLIERNAME',pic:''},{av:'AV14ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV17BrandName',fld:'vBRANDNAME',pic:''},{av:'AV25FilterOrderDesc',fld:'vFILTERORDERDESC',pic:''}]");
         setEventMetadata("GRID_PREVPAGE",",oparms:[{av:'lblLblsuppliernamefilter_Caption',ctrl:'LBLSUPPLIERNAMEFILTER',prop:'Caption'},{av:'lblLblbrandnamefilter_Caption',ctrl:'LBLBRANDNAMEFILTER',prop:'Caption'}]}");
         setEventMetadata("GRID_NEXTPAGE","{handler:'subgrid_nextpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV19ProductName',fld:'vPRODUCTNAME',pic:''},{av:'AV15OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'edtavDelete_Enabled',ctrl:'vDELETE',prop:'Enabled'},{av:'AV13Delete',fld:'vDELETE',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavUpdate_Enabled',ctrl:'vUPDATE',prop:'Enabled'},{av:'AV12Update',fld:'vUPDATE',pic:''},{av:'AV31Message',fld:'vMESSAGE',pic:'',hsh:true},{av:'AV16SupplierName',fld:'vSUPPLIERNAME',pic:''},{av:'AV14ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV17BrandName',fld:'vBRANDNAME',pic:''},{av:'AV25FilterOrderDesc',fld:'vFILTERORDERDESC',pic:''}]");
         setEventMetadata("GRID_NEXTPAGE",",oparms:[{av:'lblLblsuppliernamefilter_Caption',ctrl:'LBLSUPPLIERNAMEFILTER',prop:'Caption'},{av:'lblLblbrandnamefilter_Caption',ctrl:'LBLBRANDNAMEFILTER',prop:'Caption'}]}");
         setEventMetadata("GRID_LASTPAGE","{handler:'subgrid_lastpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV19ProductName',fld:'vPRODUCTNAME',pic:''},{av:'AV15OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'edtavDelete_Enabled',ctrl:'vDELETE',prop:'Enabled'},{av:'AV13Delete',fld:'vDELETE',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavUpdate_Enabled',ctrl:'vUPDATE',prop:'Enabled'},{av:'AV12Update',fld:'vUPDATE',pic:''},{av:'AV31Message',fld:'vMESSAGE',pic:'',hsh:true},{av:'AV16SupplierName',fld:'vSUPPLIERNAME',pic:''},{av:'AV14ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV17BrandName',fld:'vBRANDNAME',pic:''},{av:'AV25FilterOrderDesc',fld:'vFILTERORDERDESC',pic:''}]");
         setEventMetadata("GRID_LASTPAGE",",oparms:[{av:'lblLblsuppliernamefilter_Caption',ctrl:'LBLSUPPLIERNAMEFILTER',prop:'Caption'},{av:'lblLblbrandnamefilter_Caption',ctrl:'LBLBRANDNAMEFILTER',prop:'Caption'}]}");
         setEventMetadata("VALID_PRODUCTCOSTPRICE","{handler:'Valid_Productcostprice',iparms:[]");
         setEventMetadata("VALID_PRODUCTCOSTPRICE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Delete',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
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
      }

      public override void initialize( )
      {
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV13Delete = "";
         AV12Update = "";
         AV19ProductName = "";
         AV16SupplierName = "";
         AV14ADVANCED_LABEL_TEMPLATE = "";
         AV17BrandName = "";
         AV31Message = new GeneXus.Utils.SdtMessages_Message(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV27ProductCode = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTitletext_Jsonclick = "";
         lbllbl15_Jsonclick = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtninsert_Jsonclick = "";
         bttBtnexport_Jsonclick = "";
         bttBtntoggle_Jsonclick = "";
         AV22FilterCode = "";
         AV23FilterName = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         bttBtntoggleontable_Jsonclick = "";
         lblLblsuppliernamefilter_Jsonclick = "";
         lblLblbrandnamefilter_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A55ProductCode = "";
         A16ProductName = "";
         A5SupplierName = "";
         A2BrandName = "";
         A10SectorName = "";
         AV34Pgmname = "";
         GridState = new GXGridStateHandler(context,"Grid",GetPgmname(),subgrid_varsfromstate,subgrid_varstostate);
         scmdbuf = "";
         lV19ProductName = "";
         lV27ProductCode = "";
         H000X2_A4SupplierId = new int[1] ;
         H000X2_A1BrandId = new int[1] ;
         H000X2_n1BrandId = new bool[] {false} ;
         H000X2_A9SectorId = new int[1] ;
         H000X2_n9SectorId = new bool[] {false} ;
         H000X2_A110ProductActive = new bool[] {false} ;
         H000X2_n110ProductActive = new bool[] {false} ;
         H000X2_A10SectorName = new string[] {""} ;
         H000X2_A2BrandName = new string[] {""} ;
         H000X2_A5SupplierName = new string[] {""} ;
         H000X2_A93ProductMiniumQuantityWholesale = new short[1] ;
         H000X2_n93ProductMiniumQuantityWholesale = new bool[] {false} ;
         H000X2_A17ProductStock = new int[1] ;
         H000X2_n17ProductStock = new bool[] {false} ;
         H000X2_A16ProductName = new string[] {""} ;
         H000X2_A55ProductCode = new string[] {""} ;
         H000X2_n55ProductCode = new bool[] {false} ;
         H000X2_A15ProductId = new int[1] ;
         H000X2_A89ProductRetailProfit = new decimal[1] ;
         H000X2_n89ProductRetailProfit = new bool[] {false} ;
         H000X2_A85ProductCostPrice = new decimal[1] ;
         H000X2_n85ProductCostPrice = new bool[] {false} ;
         H000X2_A87ProductWholesaleProfit = new decimal[1] ;
         H000X2_n87ProductWholesaleProfit = new bool[] {false} ;
         H000X3_AGRID_nRecordCount = new long[1] ;
         GXt_SdtSDTContextSession4 = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         GridRow = new GXWebRow();
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV7HTTPRequest = new GxHttpRequest( context);
         AV6Session = context.GetSession();
         AV20ExcelFilename = "";
         AV21ErrorMessage = "";
         AV28ErrorMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwproduct__default(),
            new Object[][] {
                new Object[] {
               H000X2_A4SupplierId, H000X2_A1BrandId, H000X2_n1BrandId, H000X2_A9SectorId, H000X2_n9SectorId, H000X2_A110ProductActive, H000X2_n110ProductActive, H000X2_A10SectorName, H000X2_A2BrandName, H000X2_A5SupplierName,
               H000X2_A93ProductMiniumQuantityWholesale, H000X2_n93ProductMiniumQuantityWholesale, H000X2_A17ProductStock, H000X2_n17ProductStock, H000X2_A16ProductName, H000X2_A55ProductCode, H000X2_n55ProductCode, H000X2_A15ProductId, H000X2_A89ProductRetailProfit, H000X2_n89ProductRetailProfit,
               H000X2_A85ProductCostPrice, H000X2_n85ProductCostPrice, H000X2_A87ProductWholesaleProfit, H000X2_n87ProductWholesaleProfit
               }
               , new Object[] {
               H000X3_AGRID_nRecordCount
               }
            }
         );
         AV34Pgmname = "WWProduct";
         /* GeneXus formulas. */
         AV34Pgmname = "WWProduct";
         context.Gx_err = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV15OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV24FilterOrder ;
      private short A93ProductMiniumQuantityWholesale ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int edtavDelete_Visible ;
      private int edtavDelete_Enabled ;
      private int edtavUpdate_Visible ;
      private int edtavUpdate_Enabled ;
      private int nRC_GXsfl_52 ;
      private int subGrid_Rows ;
      private int nGXsfl_52_idx=1 ;
      private int A4SupplierId ;
      private int A1BrandId ;
      private int A9SectorId ;
      private int bttBtninsert_Visible ;
      private int bttBtninsert_Enabled ;
      private int edtavProductname_Visible ;
      private int edtavProductname_Enabled ;
      private int bttBtntoggle_Visible ;
      private int bttBtntoggle_Enabled ;
      private int edtavFiltercode_Enabled ;
      private int edtavFiltername_Enabled ;
      private int edtavOrderedby_Enabled ;
      private int edtavSuppliername_Visible ;
      private int edtavSuppliername_Enabled ;
      private int edtavBrandname_Visible ;
      private int edtavBrandname_Enabled ;
      private int A15ProductId ;
      private int A17ProductStock ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int GridPageCount ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal A89ProductRetailProfit ;
      private decimal A87ProductWholesaleProfit ;
      private decimal A85ProductCostPrice ;
      private decimal A90ProductRetailPrice ;
      private decimal A88ProductWholesalePrice ;
      private decimal GXt_decimal3 ;
      private decimal GXt_decimal2 ;
      private decimal GXt_decimal1 ;
      private string divFilterscontainer_Class ;
      private string divSuppliernamefiltercontainer_Class ;
      private string divBrandnamefiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_52_idx="0001" ;
      private string edtavDelete_Internalname ;
      private string AV13Delete ;
      private string edtavUpdate_Internalname ;
      private string AV12Update ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divGridcell_Internalname ;
      private string divGridcell_Class ;
      private string divGridtable_Internalname ;
      private string divTabletop_Internalname ;
      private string lblTitletext_Internalname ;
      private string lblTitletext_Jsonclick ;
      private string lbllbl15_Internalname ;
      private string lbllbl15_Jsonclick ;
      private string divActions_inner_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Jsonclick ;
      private string bttBtnexport_Internalname ;
      private string bttBtnexport_Jsonclick ;
      private string edtavProductname_Internalname ;
      private string edtavProductname_Jsonclick ;
      private string bttBtntoggle_Class ;
      private string bttBtntoggle_Internalname ;
      private string bttBtntoggle_Caption ;
      private string bttBtntoggle_Jsonclick ;
      private string bttBtntoggle_Tooltiptext ;
      private string divTable1_Internalname ;
      private string edtavFiltercode_Internalname ;
      private string edtavFiltercode_Jsonclick ;
      private string edtavFiltername_Internalname ;
      private string edtavFiltername_Jsonclick ;
      private string cmbavFilterorder_Internalname ;
      private string cmbavFilterorder_Jsonclick ;
      private string chkavFilterorderdesc_Internalname ;
      private string divGridcontainer_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string divFilterscontainer_Internalname ;
      private string bttBtntoggleontable_Internalname ;
      private string bttBtntoggleontable_Jsonclick ;
      private string edtavOrderedby_Internalname ;
      private string edtavOrderedby_Jsonclick ;
      private string divSuppliernamefiltercontainer_Internalname ;
      private string lblLblsuppliernamefilter_Internalname ;
      private string lblLblsuppliernamefilter_Caption ;
      private string lblLblsuppliernamefilter_Jsonclick ;
      private string edtavSuppliername_Internalname ;
      private string edtavSuppliername_Jsonclick ;
      private string divBrandnamefiltercontainer_Internalname ;
      private string lblLblbrandnamefilter_Internalname ;
      private string lblLblbrandnamefilter_Caption ;
      private string lblLblbrandnamefilter_Jsonclick ;
      private string edtavBrandname_Internalname ;
      private string edtavBrandname_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtProductId_Internalname ;
      private string edtProductCode_Internalname ;
      private string edtProductName_Internalname ;
      private string edtProductStock_Internalname ;
      private string edtProductCostPrice_Internalname ;
      private string edtProductRetailPrice_Internalname ;
      private string edtProductWholesalePrice_Internalname ;
      private string edtProductMiniumQuantityWholesale_Internalname ;
      private string edtSupplierName_Internalname ;
      private string edtBrandName_Internalname ;
      private string edtSectorName_Internalname ;
      private string chkProductActive_Internalname ;
      private string AV34Pgmname ;
      private string scmdbuf ;
      private string edtavUpdate_Link ;
      private string edtavDelete_Jsonclick ;
      private string edtProductName_Link ;
      private string edtSupplierName_Link ;
      private string edtBrandName_Link ;
      private string edtSectorName_Link ;
      private string sGXsfl_52_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtProductId_Jsonclick ;
      private string edtProductCode_Jsonclick ;
      private string edtProductName_Jsonclick ;
      private string edtProductStock_Jsonclick ;
      private string edtProductCostPrice_Jsonclick ;
      private string edtProductRetailPrice_Jsonclick ;
      private string edtProductWholesalePrice_Jsonclick ;
      private string edtProductMiniumQuantityWholesale_Jsonclick ;
      private string edtSupplierName_Jsonclick ;
      private string edtBrandName_Jsonclick ;
      private string edtSectorName_Jsonclick ;
      private string GXCCtl ;
      private string edtavUpdate_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_52_Refreshing=false ;
      private bool AV25FilterOrderDesc ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n55ProductCode ;
      private bool n17ProductStock ;
      private bool n85ProductCostPrice ;
      private bool n93ProductMiniumQuantityWholesale ;
      private bool A110ProductActive ;
      private bool n110ProductActive ;
      private bool gxdyncontrolsrefreshing ;
      private bool n1BrandId ;
      private bool n9SectorId ;
      private bool n89ProductRetailProfit ;
      private bool n87ProductWholesaleProfit ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV30CanDisabled ;
      private bool AV29AllOk ;
      private string AV19ProductName ;
      private string AV16SupplierName ;
      private string AV17BrandName ;
      private string AV27ProductCode ;
      private string AV22FilterCode ;
      private string AV23FilterName ;
      private string A55ProductCode ;
      private string A16ProductName ;
      private string A5SupplierName ;
      private string A2BrandName ;
      private string A10SectorName ;
      private string lV19ProductName ;
      private string lV27ProductCode ;
      private string AV20ExcelFilename ;
      private string AV21ErrorMessage ;
      private GXWebGrid GridContainer ;
      private GXGridStateHandler GridState ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavFilterorder ;
      private GXCheckbox chkavFilterorderdesc ;
      private GXCheckbox chkProductActive ;
      private IDataStoreProvider pr_default ;
      private int[] H000X2_A4SupplierId ;
      private int[] H000X2_A1BrandId ;
      private bool[] H000X2_n1BrandId ;
      private int[] H000X2_A9SectorId ;
      private bool[] H000X2_n9SectorId ;
      private bool[] H000X2_A110ProductActive ;
      private bool[] H000X2_n110ProductActive ;
      private string[] H000X2_A10SectorName ;
      private string[] H000X2_A2BrandName ;
      private string[] H000X2_A5SupplierName ;
      private short[] H000X2_A93ProductMiniumQuantityWholesale ;
      private bool[] H000X2_n93ProductMiniumQuantityWholesale ;
      private int[] H000X2_A17ProductStock ;
      private bool[] H000X2_n17ProductStock ;
      private string[] H000X2_A16ProductName ;
      private string[] H000X2_A55ProductCode ;
      private bool[] H000X2_n55ProductCode ;
      private int[] H000X2_A15ProductId ;
      private decimal[] H000X2_A89ProductRetailProfit ;
      private bool[] H000X2_n89ProductRetailProfit ;
      private decimal[] H000X2_A85ProductCostPrice ;
      private bool[] H000X2_n85ProductCostPrice ;
      private decimal[] H000X2_A87ProductWholesaleProfit ;
      private bool[] H000X2_n87ProductWholesaleProfit ;
      private long[] H000X3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV7HTTPRequest ;
      private IGxSession AV6Session ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV28ErrorMessages ;
      private GXWebForm Form ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private GeneXus.Utils.SdtMessages_Message AV31Message ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession GXt_SdtSDTContextSession4 ;
   }

   public class wwproduct__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000X2( IGxContext context ,
                                             string AV19ProductName ,
                                             string AV27ProductCode ,
                                             string A16ProductName ,
                                             string A55ProductCode ,
                                             short AV15OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[5];
         Object[] GXv_Object6 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[SupplierId], T1.[BrandId], T1.[SectorId], T1.[ProductActive], T4.[SectorName], T3.[BrandName], T2.[SupplierName], T1.[ProductMiniumQuantityWholesale], T1.[ProductStock], T1.[ProductName], T1.[ProductCode], T1.[ProductId], T1.[ProductRetailProfit], T1.[ProductCostPrice], T1.[ProductWholesaleProfit]";
         sFromString = " FROM ((([Product] T1 INNER JOIN [Supplier] T2 ON T2.[SupplierId] = T1.[SupplierId]) LEFT JOIN [Brand] T3 ON T3.[BrandId] = T1.[BrandId]) LEFT JOIN [Sector] T4 ON T4.[SectorId] = T1.[SectorId])";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19ProductName)) )
         {
            AddWhere(sWhereString, "(T1.[ProductName] like '%' + @lV19ProductName + '%')");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27ProductCode)) )
         {
            AddWhere(sWhereString, "(T1.[ProductCode] like '%' + @lV27ProductCode + '%')");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( AV15OrderedBy == 1 )
         {
            sOrderString += " ORDER BY T1.[ProductName]";
         }
         else if ( AV15OrderedBy == 2 )
         {
            sOrderString += " ORDER BY T1.[ProductName] DESC";
         }
         else if ( AV15OrderedBy == 3 )
         {
            sOrderString += " ORDER BY T1.[ProductCode]";
         }
         else if ( AV15OrderedBy == 4 )
         {
            sOrderString += " ORDER BY T1.[ProductCode] DESC";
         }
         else if ( AV15OrderedBy == 5 )
         {
            sOrderString += " ORDER BY T1.[ProductStock]";
         }
         else if ( AV15OrderedBy == 6 )
         {
            sOrderString += " ORDER BY T1.[ProductStock] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.[ProductId]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_H000X3( IGxContext context ,
                                             string AV19ProductName ,
                                             string AV27ProductCode ,
                                             string A16ProductName ,
                                             string A55ProductCode ,
                                             short AV15OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[2];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ((([Product] T1 INNER JOIN [Supplier] T4 ON T4.[SupplierId] = T1.[SupplierId]) LEFT JOIN [Brand] T2 ON T2.[BrandId] = T1.[BrandId]) LEFT JOIN [Sector] T3 ON T3.[SectorId] = T1.[SectorId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19ProductName)) )
         {
            AddWhere(sWhereString, "(T1.[ProductName] like '%' + @lV19ProductName + '%')");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27ProductCode)) )
         {
            AddWhere(sWhereString, "(T1.[ProductCode] like '%' + @lV27ProductCode + '%')");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV15OrderedBy == 1 )
         {
            scmdbuf += "";
         }
         else if ( AV15OrderedBy == 2 )
         {
            scmdbuf += "";
         }
         else if ( AV15OrderedBy == 3 )
         {
            scmdbuf += "";
         }
         else if ( AV15OrderedBy == 4 )
         {
            scmdbuf += "";
         }
         else if ( AV15OrderedBy == 5 )
         {
            scmdbuf += "";
         }
         else if ( AV15OrderedBy == 6 )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H000X2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] );
               case 1 :
                     return conditional_H000X3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmH000X2;
          prmH000X2 = new Object[] {
          new ParDef("@lV19ProductName",GXType.NVarChar,60,0) ,
          new ParDef("@lV27ProductCode",GXType.NVarChar,100,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH000X3;
          prmH000X3 = new Object[] {
          new ParDef("@lV19ProductName",GXType.NVarChar,60,0) ,
          new ParDef("@lV27ProductCode",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000X2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000X2,9, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000X3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000X3,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((string[]) buf[8])[0] = rslt.getVarchar(6);
                ((string[]) buf[9])[0] = rslt.getVarchar(7);
                ((short[]) buf[10])[0] = rslt.getShort(8);
                ((bool[]) buf[11])[0] = rslt.wasNull(8);
                ((int[]) buf[12])[0] = rslt.getInt(9);
                ((bool[]) buf[13])[0] = rslt.wasNull(9);
                ((string[]) buf[14])[0] = rslt.getVarchar(10);
                ((string[]) buf[15])[0] = rslt.getVarchar(11);
                ((bool[]) buf[16])[0] = rslt.wasNull(11);
                ((int[]) buf[17])[0] = rslt.getInt(12);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(13);
                ((bool[]) buf[19])[0] = rslt.wasNull(13);
                ((decimal[]) buf[20])[0] = rslt.getDecimal(14);
                ((bool[]) buf[21])[0] = rslt.wasNull(14);
                ((decimal[]) buf[22])[0] = rslt.getDecimal(15);
                ((bool[]) buf[23])[0] = rslt.wasNull(15);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
