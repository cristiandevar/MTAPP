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
   public class productgeneral : GXWebComponent
   {
      public productgeneral( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("mtaKB", true);
         }
      }

      public productgeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_ProductId )
      {
         this.A15ProductId = aP0_ProductId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
         cmbavProductstate = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "ProductId");
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  A15ProductId = (int)(Math.Round(NumberUtil.Val( GetPar( "ProductId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A15ProductId", StringUtil.LTrimStr( (decimal)(A15ProductId), 6, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(int)A15ProductId});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
                  gxfirstwebparm = GetFirstPar( "ProductId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "ProductId");
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
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
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
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA2S2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV17Pgmname = "ProductGeneral";
               context.Gx_err = 0;
               cmbavProductstate.Enabled = 0;
               AssignProp(sPrefix, false, cmbavProductstate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavProductstate.Enabled), 5, 0), true);
               WS2S2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( "Product General") ;
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
         }
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1853160), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1853160), false, true);
         context.AddJavascriptSource("calendar-en.js", "?"+context.GetBuildNumber( 1853160), false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
            context.WriteHtmlText( "<body ") ;
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("productgeneral.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A15ProductId,6,0))}, new string[] {"ProductId"}) +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA15ProductId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA15ProductId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"PRODUCTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm2S2( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "ProductGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "Product General" ;
      }

      protected void WB2S0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "productgeneral.aspx");
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 ww__view__actions-cell", "Right", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ww__view__actions", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button button-primary";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", "Update", bttBtnupdate_Jsonclick, 7, "Update", "", StyleString, ClassString, bttBtnupdate_Visible, bttBtnupdate_Enabled, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e112s1_client"+"'", TempTags, "", 2, "HLP_ProductGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 10,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button button-tertiary";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndeactive_Internalname, "", "Deactive", bttBtndeactive_Jsonclick, 5, "Deactive Product", "", StyleString, ClassString, bttBtndeactive_Visible, bttBtndeactive_Enabled, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DODEACTIVE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProductGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Right", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributestable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductCode_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProductCode_Internalname, "Code", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtProductCode_Internalname, A55ProductCode, StringUtil.RTrim( context.localUtil.Format( A55ProductCode, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductCode_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtProductCode_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "GeneXusUnanimo\\Code", "left", true, "", "HLP_ProductGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtProductName_Internalname, "Name", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtProductName_Internalname, A16ProductName, StringUtil.RTrim( context.localUtil.Format( A16ProductName, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductName_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtProductName_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Name", "left", true, "", "HLP_ProductGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtProductCostPrice_Internalname, "Cost Price", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtProductCostPrice_Internalname, StringUtil.LTrim( StringUtil.NToC( A85ProductCostPrice, 18, 2, ".", "")), StringUtil.LTrim( ((edtProductCostPrice_Enabled!=0) ? context.localUtil.Format( A85ProductCostPrice, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A85ProductCostPrice, "ZZZZZZZZZZZZZZ9.99"))), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductCostPrice_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtProductCostPrice_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Price", "right", false, "", "HLP_ProductGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtProductRetailProfit_Internalname, "Retail Profit", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtProductRetailProfit_Internalname, StringUtil.LTrim( StringUtil.NToC( A89ProductRetailProfit, 8, 2, ".", "")), StringUtil.LTrim( ((edtProductRetailProfit_Enabled!=0) ? context.localUtil.Format( A89ProductRetailProfit, "ZZZZ9.99") : context.localUtil.Format( A89ProductRetailProfit, "ZZZZ9.99"))), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductRetailProfit_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtProductRetailProfit_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "Percentage", "right", false, "", "HLP_ProductGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtProductRetailPrice_Internalname, "Retail Price", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtProductRetailPrice_Internalname, StringUtil.LTrim( StringUtil.NToC( A90ProductRetailPrice, 18, 2, ".", "")), StringUtil.LTrim( ((edtProductRetailPrice_Enabled!=0) ? context.localUtil.Format( A90ProductRetailPrice, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A90ProductRetailPrice, "ZZZZZZZZZZZZZZ9.99"))), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductRetailPrice_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtProductRetailPrice_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Price", "right", false, "", "HLP_ProductGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtProductWholesaleProfit_Internalname, "Wholesale Profit", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtProductWholesaleProfit_Internalname, StringUtil.LTrim( StringUtil.NToC( A87ProductWholesaleProfit, 8, 2, ".", "")), StringUtil.LTrim( ((edtProductWholesaleProfit_Enabled!=0) ? context.localUtil.Format( A87ProductWholesaleProfit, "ZZZZ9.99") : context.localUtil.Format( A87ProductWholesaleProfit, "ZZZZ9.99"))), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductWholesaleProfit_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtProductWholesaleProfit_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "Percentage", "right", false, "", "HLP_ProductGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtProductWholesalePrice_Internalname, "Wholesale Price", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtProductWholesalePrice_Internalname, StringUtil.LTrim( StringUtil.NToC( A88ProductWholesalePrice, 18, 2, ".", "")), StringUtil.LTrim( ((edtProductWholesalePrice_Enabled!=0) ? context.localUtil.Format( A88ProductWholesalePrice, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A88ProductWholesalePrice, "ZZZZZZZZZZZZZZ9.99"))), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductWholesalePrice_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtProductWholesalePrice_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Price", "right", false, "", "HLP_ProductGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductMiniumQuantityWholesale_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProductMiniumQuantityWholesale_Internalname, "Quantity Wholesale", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtProductMiniumQuantityWholesale_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A93ProductMiniumQuantityWholesale), 4, 0, ".", "")), StringUtil.LTrim( ((edtProductMiniumQuantityWholesale_Enabled!=0) ? context.localUtil.Format( (decimal)(A93ProductMiniumQuantityWholesale), "ZZZ9") : context.localUtil.Format( (decimal)(A93ProductMiniumQuantityWholesale), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductMiniumQuantityWholesale_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtProductMiniumQuantityWholesale_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_ProductGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtBrandName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtBrandName_Internalname, "Brand", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtBrandName_Internalname, A2BrandName, StringUtil.RTrim( context.localUtil.Format( A2BrandName, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtBrandName_Link, "", "", "", edtBrandName_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtBrandName_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Name", "left", true, "", "HLP_ProductGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSupplierName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSupplierName_Internalname, "Supplier", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtSupplierName_Internalname, A5SupplierName, StringUtil.RTrim( context.localUtil.Format( A5SupplierName, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtSupplierName_Link, "", "", "", edtSupplierName_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtSupplierName_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Name", "left", true, "", "HLP_ProductGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSectorName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSectorName_Internalname, "Sector", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtSectorName_Internalname, A10SectorName, StringUtil.RTrim( context.localUtil.Format( A10SectorName, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtSectorName_Link, "", "", "", edtSectorName_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtSectorName_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Name", "left", true, "", "HLP_ProductGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtProductStock_Internalname, "Stock", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtProductStock_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A17ProductStock), 6, 0, ".", "")), StringUtil.LTrim( ((edtProductStock_Enabled!=0) ? context.localUtil.Format( (decimal)(A17ProductStock), "ZZZZZ9") : context.localUtil.Format( (decimal)(A17ProductStock), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductStock_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtProductStock_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Stock", "right", false, "", "HLP_ProductGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtProductMiniumStock_Internalname, "Minium Stock", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtProductMiniumStock_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A69ProductMiniumStock), 6, 0, ".", "")), StringUtil.LTrim( ((edtProductMiniumStock_Enabled!=0) ? context.localUtil.Format( (decimal)(A69ProductMiniumStock), "ZZZZZ9") : context.localUtil.Format( (decimal)(A69ProductMiniumStock), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductMiniumStock_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtProductMiniumStock_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Stock", "right", false, "", "HLP_ProductGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtProductDescription_Internalname, "Description", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtProductDescription_Internalname, A19ProductDescription, "", "", 0, 1, edtProductDescription_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "GeneXusUnanimo\\Description", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_ProductGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductCreatedDate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProductCreatedDate_Internalname, "Created", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtProductCreatedDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtProductCreatedDate_Internalname, context.localUtil.Format(A28ProductCreatedDate, "99/99/9999"), context.localUtil.Format( A28ProductCreatedDate, "99/99/9999"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductCreatedDate_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtProductCreatedDate_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "MyDate", "right", false, "", "HLP_ProductGeneral.htm");
            GxWebStd.gx_bitmap( context, edtProductCreatedDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtProductCreatedDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ProductGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductModifiedDate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProductModifiedDate_Internalname, "Modified", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtProductModifiedDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtProductModifiedDate_Internalname, context.localUtil.Format(A29ProductModifiedDate, "99/99/9999"), context.localUtil.Format( A29ProductModifiedDate, "99/99/9999"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductModifiedDate_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtProductModifiedDate_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "MyDate", "right", false, "", "HLP_ProductGeneral.htm");
            GxWebStd.gx_bitmap( context, edtProductModifiedDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtProductModifiedDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ProductGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavProductstate, cmbavProductstate_Internalname, StringUtil.RTrim( AV14ProductState), 1, cmbavProductstate_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavProductstate.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,98);\"", "", true, 0, "HLP_ProductGeneral.htm");
            cmbavProductstate.CurrentValue = StringUtil.RTrim( AV14ProductState);
            AssignProp(sPrefix, false, cmbavProductstate_Internalname, "Values", (string)(cmbavProductstate.ToJavascriptSource()), true);
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
         wbLoad = true;
      }

      protected void START2S2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET 18_0_2-169539", 0) ;
               }
               Form.Meta.addItem("description", "Product General", 0) ;
            }
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP2S0( ) ;
            }
         }
      }

      protected void WS2S2( )
      {
         START2S2( ) ;
         EVT2S2( ) ;
      }

      protected void EVT2S2( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2S0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2S0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E122S2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2S0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E132S2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DODEACTIVE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2S0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoDeactive' */
                                    E142S2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2S0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2S0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = cmbavProductstate_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                              dynload_actions( ) ;
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
      }

      protected void WE2S2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm2S2( ) ;
            }
         }
      }

      protected void PA2S2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = cmbavProductstate_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void send_integrity_hashes( )
      {
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
         if ( cmbavProductstate.ItemCount > 0 )
         {
            AV14ProductState = cmbavProductstate.getValidValue(AV14ProductState);
            AssignAttri(sPrefix, false, "AV14ProductState", AV14ProductState);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavProductstate.CurrentValue = StringUtil.RTrim( AV14ProductState);
            AssignProp(sPrefix, false, cmbavProductstate_Internalname, "Values", cmbavProductstate.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF2S2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV17Pgmname = "ProductGeneral";
         context.Gx_err = 0;
         cmbavProductstate.Enabled = 0;
         AssignProp(sPrefix, false, cmbavProductstate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavProductstate.Enabled), 5, 0), true);
      }

      protected void RF2S2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H002S2 */
            pr_default.execute(0, new Object[] {A15ProductId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A110ProductActive = H002S2_A110ProductActive[0];
               n110ProductActive = H002S2_n110ProductActive[0];
               A1BrandId = H002S2_A1BrandId[0];
               n1BrandId = H002S2_n1BrandId[0];
               A4SupplierId = H002S2_A4SupplierId[0];
               A9SectorId = H002S2_A9SectorId[0];
               n9SectorId = H002S2_n9SectorId[0];
               A29ProductModifiedDate = H002S2_A29ProductModifiedDate[0];
               AssignAttri(sPrefix, false, "A29ProductModifiedDate", context.localUtil.Format(A29ProductModifiedDate, "99/99/9999"));
               A28ProductCreatedDate = H002S2_A28ProductCreatedDate[0];
               AssignAttri(sPrefix, false, "A28ProductCreatedDate", context.localUtil.Format(A28ProductCreatedDate, "99/99/9999"));
               A19ProductDescription = H002S2_A19ProductDescription[0];
               n19ProductDescription = H002S2_n19ProductDescription[0];
               AssignAttri(sPrefix, false, "A19ProductDescription", A19ProductDescription);
               A69ProductMiniumStock = H002S2_A69ProductMiniumStock[0];
               n69ProductMiniumStock = H002S2_n69ProductMiniumStock[0];
               AssignAttri(sPrefix, false, "A69ProductMiniumStock", StringUtil.LTrimStr( (decimal)(A69ProductMiniumStock), 6, 0));
               A17ProductStock = H002S2_A17ProductStock[0];
               n17ProductStock = H002S2_n17ProductStock[0];
               AssignAttri(sPrefix, false, "A17ProductStock", StringUtil.LTrimStr( (decimal)(A17ProductStock), 6, 0));
               A10SectorName = H002S2_A10SectorName[0];
               AssignAttri(sPrefix, false, "A10SectorName", A10SectorName);
               A5SupplierName = H002S2_A5SupplierName[0];
               AssignAttri(sPrefix, false, "A5SupplierName", A5SupplierName);
               A2BrandName = H002S2_A2BrandName[0];
               AssignAttri(sPrefix, false, "A2BrandName", A2BrandName);
               A93ProductMiniumQuantityWholesale = H002S2_A93ProductMiniumQuantityWholesale[0];
               n93ProductMiniumQuantityWholesale = H002S2_n93ProductMiniumQuantityWholesale[0];
               AssignAttri(sPrefix, false, "A93ProductMiniumQuantityWholesale", StringUtil.LTrimStr( (decimal)(A93ProductMiniumQuantityWholesale), 4, 0));
               A16ProductName = H002S2_A16ProductName[0];
               AssignAttri(sPrefix, false, "A16ProductName", A16ProductName);
               A55ProductCode = H002S2_A55ProductCode[0];
               n55ProductCode = H002S2_n55ProductCode[0];
               AssignAttri(sPrefix, false, "A55ProductCode", A55ProductCode);
               A89ProductRetailProfit = H002S2_A89ProductRetailProfit[0];
               n89ProductRetailProfit = H002S2_n89ProductRetailProfit[0];
               AssignAttri(sPrefix, false, "A89ProductRetailProfit", StringUtil.LTrimStr( A89ProductRetailProfit, 8, 2));
               A85ProductCostPrice = H002S2_A85ProductCostPrice[0];
               n85ProductCostPrice = H002S2_n85ProductCostPrice[0];
               AssignAttri(sPrefix, false, "A85ProductCostPrice", StringUtil.LTrimStr( A85ProductCostPrice, 18, 2));
               A87ProductWholesaleProfit = H002S2_A87ProductWholesaleProfit[0];
               n87ProductWholesaleProfit = H002S2_n87ProductWholesaleProfit[0];
               AssignAttri(sPrefix, false, "A87ProductWholesaleProfit", StringUtil.LTrimStr( A87ProductWholesaleProfit, 8, 2));
               A2BrandName = H002S2_A2BrandName[0];
               AssignAttri(sPrefix, false, "A2BrandName", A2BrandName);
               A5SupplierName = H002S2_A5SupplierName[0];
               AssignAttri(sPrefix, false, "A5SupplierName", A5SupplierName);
               A10SectorName = H002S2_A10SectorName[0];
               AssignAttri(sPrefix, false, "A10SectorName", A10SectorName);
               GXt_decimal1 = A88ProductWholesalePrice;
               new roundvalue(context ).execute(  A85ProductCostPrice*(1+A87ProductWholesaleProfit/ (decimal)(100)), out  GXt_decimal1) ;
               GXt_decimal2 = A88ProductWholesalePrice;
               new roundvalue(context ).execute(  A85ProductCostPrice*(1+A87ProductWholesaleProfit/ (decimal)(100)), out  GXt_decimal2) ;
               GXt_decimal3 = A88ProductWholesalePrice;
               new roundvalue(context ).execute(  A85ProductCostPrice, out  GXt_decimal3) ;
               A88ProductWholesalePrice = ((A87ProductWholesaleProfit!=Convert.ToDecimal(0)) ? GXt_decimal2 : GXt_decimal3);
               AssignAttri(sPrefix, false, "A88ProductWholesalePrice", StringUtil.LTrimStr( A88ProductWholesalePrice, 18, 2));
               GXt_decimal3 = A90ProductRetailPrice;
               new roundvalue(context ).execute(  A85ProductCostPrice*(1+A89ProductRetailProfit/ (decimal)(100)), out  GXt_decimal3) ;
               GXt_decimal2 = A90ProductRetailPrice;
               new roundvalue(context ).execute(  A85ProductCostPrice*(1+A89ProductRetailProfit/ (decimal)(100)), out  GXt_decimal2) ;
               GXt_decimal1 = A90ProductRetailPrice;
               new roundvalue(context ).execute(  A85ProductCostPrice, out  GXt_decimal1) ;
               A90ProductRetailPrice = ((A89ProductRetailProfit!=Convert.ToDecimal(0)) ? GXt_decimal2 : GXt_decimal1);
               AssignAttri(sPrefix, false, "A90ProductRetailPrice", StringUtil.LTrimStr( A90ProductRetailPrice, 18, 2));
               /* Execute user event: Load */
               E132S2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB2S0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes2S2( )
      {
      }

      protected void before_start_formulas( )
      {
         AV17Pgmname = "ProductGeneral";
         context.Gx_err = 0;
         cmbavProductstate.Enabled = 0;
         AssignProp(sPrefix, false, cmbavProductstate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavProductstate.Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2S0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E122S2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA15ProductId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA15ProductId"), ".", ","), 18, MidpointRounding.ToEven));
            A15ProductId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"PRODUCTID"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            A55ProductCode = cgiGet( edtProductCode_Internalname);
            n55ProductCode = false;
            AssignAttri(sPrefix, false, "A55ProductCode", A55ProductCode);
            A16ProductName = cgiGet( edtProductName_Internalname);
            AssignAttri(sPrefix, false, "A16ProductName", A16ProductName);
            A85ProductCostPrice = context.localUtil.CToN( cgiGet( edtProductCostPrice_Internalname), ".", ",");
            n85ProductCostPrice = false;
            AssignAttri(sPrefix, false, "A85ProductCostPrice", StringUtil.LTrimStr( A85ProductCostPrice, 18, 2));
            A89ProductRetailProfit = context.localUtil.CToN( cgiGet( edtProductRetailProfit_Internalname), ".", ",");
            n89ProductRetailProfit = false;
            AssignAttri(sPrefix, false, "A89ProductRetailProfit", StringUtil.LTrimStr( A89ProductRetailProfit, 8, 2));
            A90ProductRetailPrice = context.localUtil.CToN( cgiGet( edtProductRetailPrice_Internalname), ".", ",");
            AssignAttri(sPrefix, false, "A90ProductRetailPrice", StringUtil.LTrimStr( A90ProductRetailPrice, 18, 2));
            A87ProductWholesaleProfit = context.localUtil.CToN( cgiGet( edtProductWholesaleProfit_Internalname), ".", ",");
            n87ProductWholesaleProfit = false;
            AssignAttri(sPrefix, false, "A87ProductWholesaleProfit", StringUtil.LTrimStr( A87ProductWholesaleProfit, 8, 2));
            A88ProductWholesalePrice = context.localUtil.CToN( cgiGet( edtProductWholesalePrice_Internalname), ".", ",");
            AssignAttri(sPrefix, false, "A88ProductWholesalePrice", StringUtil.LTrimStr( A88ProductWholesalePrice, 18, 2));
            A93ProductMiniumQuantityWholesale = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtProductMiniumQuantityWholesale_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            n93ProductMiniumQuantityWholesale = false;
            AssignAttri(sPrefix, false, "A93ProductMiniumQuantityWholesale", StringUtil.LTrimStr( (decimal)(A93ProductMiniumQuantityWholesale), 4, 0));
            A2BrandName = cgiGet( edtBrandName_Internalname);
            AssignAttri(sPrefix, false, "A2BrandName", A2BrandName);
            A5SupplierName = cgiGet( edtSupplierName_Internalname);
            AssignAttri(sPrefix, false, "A5SupplierName", A5SupplierName);
            A10SectorName = cgiGet( edtSectorName_Internalname);
            AssignAttri(sPrefix, false, "A10SectorName", A10SectorName);
            A17ProductStock = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtProductStock_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            n17ProductStock = false;
            AssignAttri(sPrefix, false, "A17ProductStock", StringUtil.LTrimStr( (decimal)(A17ProductStock), 6, 0));
            A69ProductMiniumStock = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtProductMiniumStock_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            n69ProductMiniumStock = false;
            AssignAttri(sPrefix, false, "A69ProductMiniumStock", StringUtil.LTrimStr( (decimal)(A69ProductMiniumStock), 6, 0));
            A19ProductDescription = cgiGet( edtProductDescription_Internalname);
            n19ProductDescription = false;
            AssignAttri(sPrefix, false, "A19ProductDescription", A19ProductDescription);
            A28ProductCreatedDate = context.localUtil.CToD( cgiGet( edtProductCreatedDate_Internalname), 1);
            AssignAttri(sPrefix, false, "A28ProductCreatedDate", context.localUtil.Format(A28ProductCreatedDate, "99/99/9999"));
            A29ProductModifiedDate = context.localUtil.CToD( cgiGet( edtProductModifiedDate_Internalname), 1);
            AssignAttri(sPrefix, false, "A29ProductModifiedDate", context.localUtil.Format(A29ProductModifiedDate, "99/99/9999"));
            cmbavProductstate.CurrentValue = cgiGet( cmbavProductstate_Internalname);
            AV14ProductState = cgiGet( cmbavProductstate_Internalname);
            AssignAttri(sPrefix, false, "AV14ProductState", AV14ProductState);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E122S2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E122S2( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV17Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV17Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         if ( ! new haspermission(context).executeUdp(  "product update") )
         {
            bttBtnupdate_Visible = 0;
            AssignProp(sPrefix, false, bttBtnupdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnupdate_Visible), 5, 0), true);
            bttBtnupdate_Enabled = 0;
            AssignProp(sPrefix, false, bttBtnupdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtnupdate_Enabled), 5, 0), true);
         }
         if ( ! new haspermission(context).executeUdp(  "product delete") )
         {
            bttBtndeactive_Visible = 0;
            AssignProp(sPrefix, false, bttBtndeactive_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtndeactive_Visible), 5, 0), true);
            bttBtndeactive_Enabled = 0;
            AssignProp(sPrefix, false, bttBtndeactive_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtndeactive_Enabled), 5, 0), true);
         }
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( A110ProductActive )
         {
            AV14ProductState = "Active";
            AssignAttri(sPrefix, false, "AV14ProductState", AV14ProductState);
         }
         else
         {
            AV14ProductState = "Deactive";
            AssignAttri(sPrefix, false, "AV14ProductState", AV14ProductState);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E132S2( )
      {
         /* Load Routine */
         returnInSub = false;
         if ( new haspermission(context).executeUdp(  "brand view") )
         {
            edtBrandName_Link = formatLink("viewbrand.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A1BrandId,6,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"BrandId","TabCode"}) ;
            AssignProp(sPrefix, false, edtBrandName_Internalname, "Link", edtBrandName_Link, true);
         }
         if ( new haspermission(context).executeUdp(  "supplier view") )
         {
            edtSupplierName_Link = formatLink("viewsupplier.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A4SupplierId,6,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"SupplierId","TabCode"}) ;
            AssignProp(sPrefix, false, edtSupplierName_Internalname, "Link", edtSupplierName_Link, true);
         }
         if ( new haspermission(context).executeUdp(  "sector view") )
         {
            edtSectorName_Link = formatLink("viewsector.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A9SectorId,6,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"SectorId","TabCode"}) ;
            AssignProp(sPrefix, false, edtSectorName_Internalname, "Link", edtSectorName_Link, true);
         }
      }

      protected void E142S2( )
      {
         /* 'DoDeactive' Routine */
         returnInSub = false;
         if ( new haspermission(context).executeUdp(  "product delete") )
         {
            new productactivedeactive(context ).execute(  A15ProductId,  false, out  AV11AllOk, out  AV12ErrorMessages) ;
            if ( ! AV11AllOk )
            {
               GX_msglist.addItem("Delete Product Failed"+AV12ErrorMessages.ToJSonString(false));
            }
            else
            {
               GX_msglist.addItem("Delete Product was succesfully");
            }
         }
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV7TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV7TrnContext.gxTpr_Callerobject = AV17Pgmname;
         AV7TrnContext.gxTpr_Callerondelete = false;
         AV7TrnContext.gxTpr_Callerurl = AV10HTTPRequest.ScriptName+"?"+AV10HTTPRequest.QueryString;
         AV7TrnContext.gxTpr_Transactionname = "Product";
         AV8TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         AV8TrnContextAtt.gxTpr_Attributename = "ProductId";
         AV8TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV6ProductId), 6, 0);
         AV7TrnContext.gxTpr_Attributes.Add(AV8TrnContextAtt, 0);
         AV9Session.Set("TrnContext", AV7TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A15ProductId = Convert.ToInt32(getParm(obj,0));
         AssignAttri(sPrefix, false, "A15ProductId", StringUtil.LTrimStr( (decimal)(A15ProductId), 6, 0));
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
         PA2S2( ) ;
         WS2S2( ) ;
         WE2S2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlA15ProductId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA2S2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "productgeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA2S2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A15ProductId = Convert.ToInt32(getParm(obj,2));
            AssignAttri(sPrefix, false, "A15ProductId", StringUtil.LTrimStr( (decimal)(A15ProductId), 6, 0));
         }
         wcpOA15ProductId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA15ProductId"), ".", ","), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( A15ProductId != wcpOA15ProductId ) ) )
         {
            setjustcreated();
         }
         wcpOA15ProductId = A15ProductId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA15ProductId = cgiGet( sPrefix+"A15ProductId_CTRL");
         if ( StringUtil.Len( sCtrlA15ProductId) > 0 )
         {
            A15ProductId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlA15ProductId), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A15ProductId", StringUtil.LTrimStr( (decimal)(A15ProductId), 6, 0));
         }
         else
         {
            A15ProductId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"A15ProductId_PARM"), ".", ","), 18, MidpointRounding.ToEven));
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA2S2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS2S2( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS2S2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A15ProductId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA15ProductId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A15ProductId_CTRL", StringUtil.RTrim( sCtrlA15ProductId));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE2S2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202411222332746", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         CloseStyles();
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("productgeneral.js", "?202411222332747", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavProductstate.Name = "vPRODUCTSTATE";
         cmbavProductstate.WebTags = "";
         cmbavProductstate.addItem("Active", "Active", 0);
         cmbavProductstate.addItem("Deactive", "Deactive", 0);
         cmbavProductstate.addItem("Enabled", "Enabled", 0);
         cmbavProductstate.addItem("Disabled", "Disabled", 0);
         if ( cmbavProductstate.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtndeactive_Internalname = sPrefix+"BTNDEACTIVE";
         edtProductCode_Internalname = sPrefix+"PRODUCTCODE";
         edtProductName_Internalname = sPrefix+"PRODUCTNAME";
         edtProductCostPrice_Internalname = sPrefix+"PRODUCTCOSTPRICE";
         edtProductRetailProfit_Internalname = sPrefix+"PRODUCTRETAILPROFIT";
         edtProductRetailPrice_Internalname = sPrefix+"PRODUCTRETAILPRICE";
         edtProductWholesaleProfit_Internalname = sPrefix+"PRODUCTWHOLESALEPROFIT";
         edtProductWholesalePrice_Internalname = sPrefix+"PRODUCTWHOLESALEPRICE";
         edtProductMiniumQuantityWholesale_Internalname = sPrefix+"PRODUCTMINIUMQUANTITYWHOLESALE";
         edtBrandName_Internalname = sPrefix+"BRANDNAME";
         edtSupplierName_Internalname = sPrefix+"SUPPLIERNAME";
         edtSectorName_Internalname = sPrefix+"SECTORNAME";
         edtProductStock_Internalname = sPrefix+"PRODUCTSTOCK";
         edtProductMiniumStock_Internalname = sPrefix+"PRODUCTMINIUMSTOCK";
         edtProductDescription_Internalname = sPrefix+"PRODUCTDESCRIPTION";
         edtProductCreatedDate_Internalname = sPrefix+"PRODUCTCREATEDDATE";
         edtProductModifiedDate_Internalname = sPrefix+"PRODUCTMODIFIEDDATE";
         cmbavProductstate_Internalname = sPrefix+"vPRODUCTSTATE";
         divAttributestable_Internalname = sPrefix+"ATTRIBUTESTABLE";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
         Form.Internalname = sPrefix+"FORM";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("mtaKB", true);
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         cmbavProductstate_Jsonclick = "";
         cmbavProductstate.Enabled = 1;
         edtProductModifiedDate_Jsonclick = "";
         edtProductModifiedDate_Enabled = 0;
         edtProductCreatedDate_Jsonclick = "";
         edtProductCreatedDate_Enabled = 0;
         edtProductDescription_Enabled = 0;
         edtProductMiniumStock_Jsonclick = "";
         edtProductMiniumStock_Enabled = 0;
         edtProductStock_Jsonclick = "";
         edtProductStock_Enabled = 0;
         edtSectorName_Jsonclick = "";
         edtSectorName_Link = "";
         edtSectorName_Enabled = 0;
         edtSupplierName_Jsonclick = "";
         edtSupplierName_Link = "";
         edtSupplierName_Enabled = 0;
         edtBrandName_Jsonclick = "";
         edtBrandName_Link = "";
         edtBrandName_Enabled = 0;
         edtProductMiniumQuantityWholesale_Jsonclick = "";
         edtProductMiniumQuantityWholesale_Enabled = 0;
         edtProductWholesalePrice_Jsonclick = "";
         edtProductWholesalePrice_Enabled = 0;
         edtProductWholesaleProfit_Jsonclick = "";
         edtProductWholesaleProfit_Enabled = 0;
         edtProductRetailPrice_Jsonclick = "";
         edtProductRetailPrice_Enabled = 0;
         edtProductRetailProfit_Jsonclick = "";
         edtProductRetailProfit_Enabled = 0;
         edtProductCostPrice_Jsonclick = "";
         edtProductCostPrice_Enabled = 0;
         edtProductName_Jsonclick = "";
         edtProductName_Enabled = 0;
         edtProductCode_Jsonclick = "";
         edtProductCode_Enabled = 0;
         bttBtndeactive_Enabled = 1;
         bttBtndeactive_Visible = 1;
         bttBtnupdate_Enabled = 1;
         bttBtnupdate_Visible = 1;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A15ProductId',fld:'PRODUCTID',pic:'ZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUPDATE'","{handler:'E112S1',iparms:[{av:'A15ProductId',fld:'PRODUCTID',pic:'ZZZZZ9'}]");
         setEventMetadata("'DOUPDATE'",",oparms:[]}");
         setEventMetadata("'DODEACTIVE'","{handler:'E142S2',iparms:[{av:'A15ProductId',fld:'PRODUCTID',pic:'ZZZZZ9'}]");
         setEventMetadata("'DODEACTIVE'",",oparms:[]}");
         setEventMetadata("VALID_PRODUCTCOSTPRICE","{handler:'Valid_Productcostprice',iparms:[]");
         setEventMetadata("VALID_PRODUCTCOSTPRICE",",oparms:[]}");
         setEventMetadata("VALID_PRODUCTRETAILPROFIT","{handler:'Valid_Productretailprofit',iparms:[]");
         setEventMetadata("VALID_PRODUCTRETAILPROFIT",",oparms:[]}");
         setEventMetadata("VALID_PRODUCTWHOLESALEPROFIT","{handler:'Valid_Productwholesaleprofit',iparms:[]");
         setEventMetadata("VALID_PRODUCTWHOLESALEPROFIT",",oparms:[]}");
         setEventMetadata("VALIDV_PRODUCTSTATE","{handler:'Validv_Productstate',iparms:[]");
         setEventMetadata("VALIDV_PRODUCTSTATE",",oparms:[]}");
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
         sPrefix = "";
         AV17Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnupdate_Jsonclick = "";
         bttBtndeactive_Jsonclick = "";
         A55ProductCode = "";
         A16ProductName = "";
         A2BrandName = "";
         A5SupplierName = "";
         A10SectorName = "";
         A19ProductDescription = "";
         A28ProductCreatedDate = DateTime.MinValue;
         A29ProductModifiedDate = DateTime.MinValue;
         AV14ProductState = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         scmdbuf = "";
         H002S2_A15ProductId = new int[1] ;
         H002S2_A110ProductActive = new bool[] {false} ;
         H002S2_n110ProductActive = new bool[] {false} ;
         H002S2_A1BrandId = new int[1] ;
         H002S2_n1BrandId = new bool[] {false} ;
         H002S2_A4SupplierId = new int[1] ;
         H002S2_A9SectorId = new int[1] ;
         H002S2_n9SectorId = new bool[] {false} ;
         H002S2_A29ProductModifiedDate = new DateTime[] {DateTime.MinValue} ;
         H002S2_A28ProductCreatedDate = new DateTime[] {DateTime.MinValue} ;
         H002S2_A19ProductDescription = new string[] {""} ;
         H002S2_n19ProductDescription = new bool[] {false} ;
         H002S2_A69ProductMiniumStock = new int[1] ;
         H002S2_n69ProductMiniumStock = new bool[] {false} ;
         H002S2_A17ProductStock = new int[1] ;
         H002S2_n17ProductStock = new bool[] {false} ;
         H002S2_A10SectorName = new string[] {""} ;
         H002S2_A5SupplierName = new string[] {""} ;
         H002S2_A2BrandName = new string[] {""} ;
         H002S2_A93ProductMiniumQuantityWholesale = new short[1] ;
         H002S2_n93ProductMiniumQuantityWholesale = new bool[] {false} ;
         H002S2_A16ProductName = new string[] {""} ;
         H002S2_A55ProductCode = new string[] {""} ;
         H002S2_n55ProductCode = new bool[] {false} ;
         H002S2_A89ProductRetailProfit = new decimal[1] ;
         H002S2_n89ProductRetailProfit = new bool[] {false} ;
         H002S2_A85ProductCostPrice = new decimal[1] ;
         H002S2_n85ProductCostPrice = new bool[] {false} ;
         H002S2_A87ProductWholesaleProfit = new decimal[1] ;
         H002S2_n87ProductWholesaleProfit = new bool[] {false} ;
         AV12ErrorMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV7TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10HTTPRequest = new GxHttpRequest( context);
         AV8TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         AV9Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA15ProductId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.productgeneral__default(),
            new Object[][] {
                new Object[] {
               H002S2_A15ProductId, H002S2_A110ProductActive, H002S2_n110ProductActive, H002S2_A1BrandId, H002S2_n1BrandId, H002S2_A4SupplierId, H002S2_A9SectorId, H002S2_n9SectorId, H002S2_A29ProductModifiedDate, H002S2_A28ProductCreatedDate,
               H002S2_A19ProductDescription, H002S2_n19ProductDescription, H002S2_A69ProductMiniumStock, H002S2_n69ProductMiniumStock, H002S2_A17ProductStock, H002S2_n17ProductStock, H002S2_A10SectorName, H002S2_A5SupplierName, H002S2_A2BrandName, H002S2_A93ProductMiniumQuantityWholesale,
               H002S2_n93ProductMiniumQuantityWholesale, H002S2_A16ProductName, H002S2_A55ProductCode, H002S2_n55ProductCode, H002S2_A89ProductRetailProfit, H002S2_n89ProductRetailProfit, H002S2_A85ProductCostPrice, H002S2_n85ProductCostPrice, H002S2_A87ProductWholesaleProfit, H002S2_n87ProductWholesaleProfit
               }
            }
         );
         AV17Pgmname = "ProductGeneral";
         /* GeneXus formulas. */
         AV17Pgmname = "ProductGeneral";
         context.Gx_err = 0;
         cmbavProductstate.Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short A93ProductMiniumQuantityWholesale ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int A15ProductId ;
      private int wcpOA15ProductId ;
      private int bttBtnupdate_Visible ;
      private int bttBtnupdate_Enabled ;
      private int bttBtndeactive_Visible ;
      private int bttBtndeactive_Enabled ;
      private int edtProductCode_Enabled ;
      private int edtProductName_Enabled ;
      private int edtProductCostPrice_Enabled ;
      private int edtProductRetailProfit_Enabled ;
      private int edtProductRetailPrice_Enabled ;
      private int edtProductWholesaleProfit_Enabled ;
      private int edtProductWholesalePrice_Enabled ;
      private int edtProductMiniumQuantityWholesale_Enabled ;
      private int edtBrandName_Enabled ;
      private int edtSupplierName_Enabled ;
      private int edtSectorName_Enabled ;
      private int A17ProductStock ;
      private int edtProductStock_Enabled ;
      private int A69ProductMiniumStock ;
      private int edtProductMiniumStock_Enabled ;
      private int edtProductDescription_Enabled ;
      private int edtProductCreatedDate_Enabled ;
      private int edtProductModifiedDate_Enabled ;
      private int A1BrandId ;
      private int A4SupplierId ;
      private int A9SectorId ;
      private int AV6ProductId ;
      private int idxLst ;
      private decimal A85ProductCostPrice ;
      private decimal A89ProductRetailProfit ;
      private decimal A90ProductRetailPrice ;
      private decimal A87ProductWholesaleProfit ;
      private decimal A88ProductWholesalePrice ;
      private decimal GXt_decimal3 ;
      private decimal GXt_decimal2 ;
      private decimal GXt_decimal1 ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV17Pgmname ;
      private string cmbavProductstate_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnupdate_Internalname ;
      private string bttBtnupdate_Jsonclick ;
      private string bttBtndeactive_Internalname ;
      private string bttBtndeactive_Jsonclick ;
      private string divAttributestable_Internalname ;
      private string edtProductCode_Internalname ;
      private string edtProductCode_Jsonclick ;
      private string edtProductName_Internalname ;
      private string edtProductName_Jsonclick ;
      private string edtProductCostPrice_Internalname ;
      private string edtProductCostPrice_Jsonclick ;
      private string edtProductRetailProfit_Internalname ;
      private string edtProductRetailProfit_Jsonclick ;
      private string edtProductRetailPrice_Internalname ;
      private string edtProductRetailPrice_Jsonclick ;
      private string edtProductWholesaleProfit_Internalname ;
      private string edtProductWholesaleProfit_Jsonclick ;
      private string edtProductWholesalePrice_Internalname ;
      private string edtProductWholesalePrice_Jsonclick ;
      private string edtProductMiniumQuantityWholesale_Internalname ;
      private string edtProductMiniumQuantityWholesale_Jsonclick ;
      private string edtBrandName_Internalname ;
      private string edtBrandName_Link ;
      private string edtBrandName_Jsonclick ;
      private string edtSupplierName_Internalname ;
      private string edtSupplierName_Link ;
      private string edtSupplierName_Jsonclick ;
      private string edtSectorName_Internalname ;
      private string edtSectorName_Link ;
      private string edtSectorName_Jsonclick ;
      private string edtProductStock_Internalname ;
      private string edtProductStock_Jsonclick ;
      private string edtProductMiniumStock_Internalname ;
      private string edtProductMiniumStock_Jsonclick ;
      private string edtProductDescription_Internalname ;
      private string edtProductCreatedDate_Internalname ;
      private string edtProductCreatedDate_Jsonclick ;
      private string edtProductModifiedDate_Internalname ;
      private string edtProductModifiedDate_Jsonclick ;
      private string cmbavProductstate_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string scmdbuf ;
      private string sCtrlA15ProductId ;
      private DateTime A28ProductCreatedDate ;
      private DateTime A29ProductModifiedDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool A110ProductActive ;
      private bool n110ProductActive ;
      private bool n1BrandId ;
      private bool n9SectorId ;
      private bool n19ProductDescription ;
      private bool n69ProductMiniumStock ;
      private bool n17ProductStock ;
      private bool n93ProductMiniumQuantityWholesale ;
      private bool n55ProductCode ;
      private bool n89ProductRetailProfit ;
      private bool n85ProductCostPrice ;
      private bool n87ProductWholesaleProfit ;
      private bool returnInSub ;
      private bool AV11AllOk ;
      private string A55ProductCode ;
      private string A16ProductName ;
      private string A2BrandName ;
      private string A5SupplierName ;
      private string A10SectorName ;
      private string A19ProductDescription ;
      private string AV14ProductState ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavProductstate ;
      private IDataStoreProvider pr_default ;
      private int[] H002S2_A15ProductId ;
      private bool[] H002S2_A110ProductActive ;
      private bool[] H002S2_n110ProductActive ;
      private int[] H002S2_A1BrandId ;
      private bool[] H002S2_n1BrandId ;
      private int[] H002S2_A4SupplierId ;
      private int[] H002S2_A9SectorId ;
      private bool[] H002S2_n9SectorId ;
      private DateTime[] H002S2_A29ProductModifiedDate ;
      private DateTime[] H002S2_A28ProductCreatedDate ;
      private string[] H002S2_A19ProductDescription ;
      private bool[] H002S2_n19ProductDescription ;
      private int[] H002S2_A69ProductMiniumStock ;
      private bool[] H002S2_n69ProductMiniumStock ;
      private int[] H002S2_A17ProductStock ;
      private bool[] H002S2_n17ProductStock ;
      private string[] H002S2_A10SectorName ;
      private string[] H002S2_A5SupplierName ;
      private string[] H002S2_A2BrandName ;
      private short[] H002S2_A93ProductMiniumQuantityWholesale ;
      private bool[] H002S2_n93ProductMiniumQuantityWholesale ;
      private string[] H002S2_A16ProductName ;
      private string[] H002S2_A55ProductCode ;
      private bool[] H002S2_n55ProductCode ;
      private decimal[] H002S2_A89ProductRetailProfit ;
      private bool[] H002S2_n89ProductRetailProfit ;
      private decimal[] H002S2_A85ProductCostPrice ;
      private bool[] H002S2_n85ProductCostPrice ;
      private decimal[] H002S2_A87ProductWholesaleProfit ;
      private bool[] H002S2_n87ProductWholesaleProfit ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV10HTTPRequest ;
      private IGxSession AV9Session ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV12ErrorMessages ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV7TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV8TrnContextAtt ;
   }

   public class productgeneral__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH002S2;
          prmH002S2 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002S2", "SELECT T1.[ProductId], T1.[ProductActive], T1.[BrandId], T1.[SupplierId], T1.[SectorId], T1.[ProductModifiedDate], T1.[ProductCreatedDate], T1.[ProductDescription], T1.[ProductMiniumStock], T1.[ProductStock], T4.[SectorName], T3.[SupplierName], T2.[BrandName], T1.[ProductMiniumQuantityWholesale], T1.[ProductName], T1.[ProductCode], T1.[ProductRetailProfit], T1.[ProductCostPrice], T1.[ProductWholesaleProfit] FROM ((([Product] T1 LEFT JOIN [Brand] T2 ON T2.[BrandId] = T1.[BrandId]) INNER JOIN [Supplier] T3 ON T3.[SupplierId] = T1.[SupplierId]) LEFT JOIN [Sector] T4 ON T4.[SectorId] = T1.[SectorId]) WHERE T1.[ProductId] = @ProductId ORDER BY T1.[ProductId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002S2,1, GxCacheFrequency.OFF ,true,true )
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
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((int[]) buf[6])[0] = rslt.getInt(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(6);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(7);
                ((string[]) buf[10])[0] = rslt.getVarchar(8);
                ((bool[]) buf[11])[0] = rslt.wasNull(8);
                ((int[]) buf[12])[0] = rslt.getInt(9);
                ((bool[]) buf[13])[0] = rslt.wasNull(9);
                ((int[]) buf[14])[0] = rslt.getInt(10);
                ((bool[]) buf[15])[0] = rslt.wasNull(10);
                ((string[]) buf[16])[0] = rslt.getVarchar(11);
                ((string[]) buf[17])[0] = rslt.getVarchar(12);
                ((string[]) buf[18])[0] = rslt.getVarchar(13);
                ((short[]) buf[19])[0] = rslt.getShort(14);
                ((bool[]) buf[20])[0] = rslt.wasNull(14);
                ((string[]) buf[21])[0] = rslt.getVarchar(15);
                ((string[]) buf[22])[0] = rslt.getVarchar(16);
                ((bool[]) buf[23])[0] = rslt.wasNull(16);
                ((decimal[]) buf[24])[0] = rslt.getDecimal(17);
                ((bool[]) buf[25])[0] = rslt.wasNull(17);
                ((decimal[]) buf[26])[0] = rslt.getDecimal(18);
                ((bool[]) buf[27])[0] = rslt.wasNull(18);
                ((decimal[]) buf[28])[0] = rslt.getDecimal(19);
                ((bool[]) buf[29])[0] = rslt.wasNull(19);
                return;
       }
    }

 }

}
