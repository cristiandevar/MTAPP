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
   public class purchaseordergeneral : GXWebComponent
   {
      public purchaseordergeneral( )
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

      public purchaseordergeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_PurchaseOrderId )
      {
         this.A50PurchaseOrderId = aP0_PurchaseOrderId;
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
         cmbavState = new GXCombobox();
         chkPurchaseOrderWasPaid = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "PurchaseOrderId");
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
                  A50PurchaseOrderId = (int)(Math.Round(NumberUtil.Val( GetPar( "PurchaseOrderId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A50PurchaseOrderId", StringUtil.LTrimStr( (decimal)(A50PurchaseOrderId), 6, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(int)A50PurchaseOrderId});
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
                  gxfirstwebparm = GetFirstPar( "PurchaseOrderId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "PurchaseOrderId");
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
            PA132( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV16Pgmname = "PurchaseOrderGeneral";
               context.Gx_err = 0;
               cmbavState.Enabled = 0;
               AssignProp(sPrefix, false, cmbavState_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavState.Enabled), 5, 0), true);
               WS132( ) ;
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
            context.SendWebValue( "Purchase Order General") ;
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("purchaseordergeneral.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A50PurchaseOrderId,6,0))}, new string[] {"PurchaseOrderId"}) +"\">") ;
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
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"PurchaseOrderGeneral");
         forbiddenHiddens.Add("PurchaseOrderClosedDate", context.localUtil.Format(A66PurchaseOrderClosedDate, "99/99/99"));
         forbiddenHiddens.Add("PurchaseOrderActive", StringUtil.BoolToStr( A79PurchaseOrderActive));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("purchaseordergeneral:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA50PurchaseOrderId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA50PurchaseOrderId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"PURCHASEORDERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A50PurchaseOrderId), 6, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm132( )
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
         return "PurchaseOrderGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "Purchase Order General" ;
      }

      protected void WB130( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "purchaseordergeneral.aspx");
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
            ClassString = "Button button-tertiary";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnviewvoucher_Internalname, "", "Voucher", bttBtnviewvoucher_Jsonclick, 7, "Voucher", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e11131_client"+"'", TempTags, "", 2, "HLP_PurchaseOrderGeneral.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPurchaseOrderCreatedDate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtPurchaseOrderCreatedDate_Internalname, "Created Date", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtPurchaseOrderCreatedDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtPurchaseOrderCreatedDate_Internalname, context.localUtil.Format(A52PurchaseOrderCreatedDate, "99/99/99"), context.localUtil.Format( A52PurchaseOrderCreatedDate, "99/99/99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPurchaseOrderCreatedDate_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtPurchaseOrderCreatedDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "PurchaseOrderDate", "right", false, "", "HLP_PurchaseOrderGeneral.htm");
            GxWebStd.gx_bitmap( context, edtPurchaseOrderCreatedDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPurchaseOrderCreatedDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_PurchaseOrderGeneral.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSupplierName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSupplierName_Internalname, "Supplier Name", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtSupplierName_Internalname, A5SupplierName, StringUtil.RTrim( context.localUtil.Format( A5SupplierName, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierName_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtSupplierName_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Name", "left", true, "", "HLP_PurchaseOrderGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPurchaseOrderTotalPaid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtPurchaseOrderTotalPaid_Internalname, "Total Paid", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtPurchaseOrderTotalPaid_Internalname, StringUtil.LTrim( StringUtil.NToC( A78PurchaseOrderTotalPaid, 18, 2, ".", "")), StringUtil.LTrim( ((edtPurchaseOrderTotalPaid_Enabled!=0) ? context.localUtil.Format( A78PurchaseOrderTotalPaid, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A78PurchaseOrderTotalPaid, "ZZZZZZZZZZZZZZ9.99"))), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPurchaseOrderTotalPaid_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtPurchaseOrderTotalPaid_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Price", "right", false, "", "HLP_PurchaseOrderGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPurchaseOrderClosedDate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtPurchaseOrderClosedDate_Internalname, "Closed Date", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtPurchaseOrderClosedDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtPurchaseOrderClosedDate_Internalname, context.localUtil.Format(A66PurchaseOrderClosedDate, "99/99/99"), context.localUtil.Format( A66PurchaseOrderClosedDate, "99/99/99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPurchaseOrderClosedDate_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtPurchaseOrderClosedDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "PurchaseOrderDate", "right", false, "", "HLP_PurchaseOrderGeneral.htm");
            GxWebStd.gx_bitmap( context, edtPurchaseOrderClosedDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPurchaseOrderClosedDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_PurchaseOrderGeneral.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavState_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavState_Internalname, "States", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavState, cmbavState_Internalname, StringUtil.RTrim( AV12State), 1, cmbavState_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavState.Enabled, 0, 0, 0, "em", 0, "", "", "ReadonlyAttribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "", true, 0, "HLP_PurchaseOrderGeneral.htm");
            cmbavState.CurrentValue = StringUtil.RTrim( AV12State);
            AssignProp(sPrefix, false, cmbavState_Internalname, "Values", (string)(cmbavState.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPurchaseOrderConfirmatedDate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtPurchaseOrderConfirmatedDate_Internalname, "Confirmated Date", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtPurchaseOrderConfirmatedDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtPurchaseOrderConfirmatedDate_Internalname, context.localUtil.Format(A135PurchaseOrderConfirmatedDate, "99/99/99"), context.localUtil.Format( A135PurchaseOrderConfirmatedDate, "99/99/99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPurchaseOrderConfirmatedDate_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtPurchaseOrderConfirmatedDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_PurchaseOrderGeneral.htm");
            GxWebStd.gx_bitmap( context, edtPurchaseOrderConfirmatedDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPurchaseOrderConfirmatedDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_PurchaseOrderGeneral.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPurchaseOrderCanceledDescripti_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtPurchaseOrderCanceledDescripti_Internalname, "Canceled Description", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtPurchaseOrderCanceledDescripti_Internalname, A136PurchaseOrderCanceledDescripti, "", "", 0, 1, edtPurchaseOrderCanceledDescripti_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "GeneXusUnanimo\\Description", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_PurchaseOrderGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkPurchaseOrderWasPaid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkPurchaseOrderWasPaid_Internalname, "Was Paid", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkPurchaseOrderWasPaid_Internalname, StringUtil.BoolToStr( A138PurchaseOrderWasPaid), "", "Was Paid", 1, chkPurchaseOrderWasPaid.Enabled, "true", "", StyleString, ClassString, "", "", "");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPurchaseOrderPaidDate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtPurchaseOrderPaidDate_Internalname, "Paid Date", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtPurchaseOrderPaidDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtPurchaseOrderPaidDate_Internalname, context.localUtil.Format(A139PurchaseOrderPaidDate, "99/99/99"), context.localUtil.Format( A139PurchaseOrderPaidDate, "99/99/99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPurchaseOrderPaidDate_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtPurchaseOrderPaidDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_PurchaseOrderGeneral.htm");
            GxWebStd.gx_bitmap( context, edtPurchaseOrderPaidDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPurchaseOrderPaidDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_PurchaseOrderGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtPurchaseOrderModifiedDate_Internalname, "Purchase Order Modified Date", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtPurchaseOrderModifiedDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtPurchaseOrderModifiedDate_Internalname, context.localUtil.Format(A53PurchaseOrderModifiedDate, "99/99/99"), context.localUtil.Format( A53PurchaseOrderModifiedDate, "99/99/99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPurchaseOrderModifiedDate_Jsonclick, 0, "Attribute", "", "", "", "", edtPurchaseOrderModifiedDate_Visible, edtPurchaseOrderModifiedDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_PurchaseOrderGeneral.htm");
            GxWebStd.gx_bitmap( context, edtPurchaseOrderModifiedDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((edtPurchaseOrderModifiedDate_Visible==0)||(edtPurchaseOrderModifiedDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_PurchaseOrderGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtPurchaseOrderActive_Internalname, "Purchase Order Active", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtPurchaseOrderActive_Internalname, StringUtil.BoolToStr( A79PurchaseOrderActive), StringUtil.BoolToStr( A79PurchaseOrderActive), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPurchaseOrderActive_Jsonclick, 0, "Attribute", "", "", "", "", edtPurchaseOrderActive_Visible, edtPurchaseOrderActive_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, 0, 0, true, "", "right", false, "", "HLP_PurchaseOrderGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START132( )
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
               Form.Meta.addItem("description", "Purchase Order General", 0) ;
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
               STRUP130( ) ;
            }
         }
      }

      protected void WS132( )
      {
         START132( ) ;
         EVT132( ) ;
      }

      protected void EVT132( )
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
                                 STRUP130( ) ;
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
                                 STRUP130( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E12132 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP130( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E13132 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP130( ) ;
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
                                 STRUP130( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = cmbavState_Internalname;
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

      protected void WE132( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm132( ) ;
            }
         }
      }

      protected void PA132( )
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
               GX_FocusControl = cmbavState_Internalname;
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
         if ( cmbavState.ItemCount > 0 )
         {
            AV12State = cmbavState.getValidValue(AV12State);
            AssignAttri(sPrefix, false, "AV12State", AV12State);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavState.CurrentValue = StringUtil.RTrim( AV12State);
            AssignProp(sPrefix, false, cmbavState_Internalname, "Values", cmbavState.ToJavascriptSource(), true);
         }
         A138PurchaseOrderWasPaid = StringUtil.StrToBool( StringUtil.BoolToStr( A138PurchaseOrderWasPaid));
         n138PurchaseOrderWasPaid = false;
         AssignAttri(sPrefix, false, "A138PurchaseOrderWasPaid", A138PurchaseOrderWasPaid);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF132( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV16Pgmname = "PurchaseOrderGeneral";
         context.Gx_err = 0;
         cmbavState.Enabled = 0;
         AssignProp(sPrefix, false, cmbavState_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavState.Enabled), 5, 0), true);
      }

      protected void RF132( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H00132 */
            pr_default.execute(0, new Object[] {A50PurchaseOrderId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A4SupplierId = H00132_A4SupplierId[0];
               A79PurchaseOrderActive = H00132_A79PurchaseOrderActive[0];
               AssignAttri(sPrefix, false, "A79PurchaseOrderActive", A79PurchaseOrderActive);
               A53PurchaseOrderModifiedDate = H00132_A53PurchaseOrderModifiedDate[0];
               n53PurchaseOrderModifiedDate = H00132_n53PurchaseOrderModifiedDate[0];
               AssignAttri(sPrefix, false, "A53PurchaseOrderModifiedDate", context.localUtil.Format(A53PurchaseOrderModifiedDate, "99/99/99"));
               A139PurchaseOrderPaidDate = H00132_A139PurchaseOrderPaidDate[0];
               n139PurchaseOrderPaidDate = H00132_n139PurchaseOrderPaidDate[0];
               AssignAttri(sPrefix, false, "A139PurchaseOrderPaidDate", context.localUtil.Format(A139PurchaseOrderPaidDate, "99/99/99"));
               A138PurchaseOrderWasPaid = H00132_A138PurchaseOrderWasPaid[0];
               n138PurchaseOrderWasPaid = H00132_n138PurchaseOrderWasPaid[0];
               AssignAttri(sPrefix, false, "A138PurchaseOrderWasPaid", A138PurchaseOrderWasPaid);
               A136PurchaseOrderCanceledDescripti = H00132_A136PurchaseOrderCanceledDescripti[0];
               n136PurchaseOrderCanceledDescripti = H00132_n136PurchaseOrderCanceledDescripti[0];
               AssignAttri(sPrefix, false, "A136PurchaseOrderCanceledDescripti", A136PurchaseOrderCanceledDescripti);
               A135PurchaseOrderConfirmatedDate = H00132_A135PurchaseOrderConfirmatedDate[0];
               n135PurchaseOrderConfirmatedDate = H00132_n135PurchaseOrderConfirmatedDate[0];
               AssignAttri(sPrefix, false, "A135PurchaseOrderConfirmatedDate", context.localUtil.Format(A135PurchaseOrderConfirmatedDate, "99/99/99"));
               A66PurchaseOrderClosedDate = H00132_A66PurchaseOrderClosedDate[0];
               n66PurchaseOrderClosedDate = H00132_n66PurchaseOrderClosedDate[0];
               AssignAttri(sPrefix, false, "A66PurchaseOrderClosedDate", context.localUtil.Format(A66PurchaseOrderClosedDate, "99/99/99"));
               A78PurchaseOrderTotalPaid = H00132_A78PurchaseOrderTotalPaid[0];
               n78PurchaseOrderTotalPaid = H00132_n78PurchaseOrderTotalPaid[0];
               AssignAttri(sPrefix, false, "A78PurchaseOrderTotalPaid", StringUtil.LTrimStr( A78PurchaseOrderTotalPaid, 18, 2));
               A5SupplierName = H00132_A5SupplierName[0];
               AssignAttri(sPrefix, false, "A5SupplierName", A5SupplierName);
               A52PurchaseOrderCreatedDate = H00132_A52PurchaseOrderCreatedDate[0];
               AssignAttri(sPrefix, false, "A52PurchaseOrderCreatedDate", context.localUtil.Format(A52PurchaseOrderCreatedDate, "99/99/99"));
               A5SupplierName = H00132_A5SupplierName[0];
               AssignAttri(sPrefix, false, "A5SupplierName", A5SupplierName);
               /* Execute user event: Load */
               E13132 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB130( ) ;
         }
      }

      protected void send_integrity_lvl_hashes132( )
      {
      }

      protected void before_start_formulas( )
      {
         AV16Pgmname = "PurchaseOrderGeneral";
         context.Gx_err = 0;
         cmbavState.Enabled = 0;
         AssignProp(sPrefix, false, cmbavState_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavState.Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP130( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E12132 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA50PurchaseOrderId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA50PurchaseOrderId"), ".", ","), 18, MidpointRounding.ToEven));
            A50PurchaseOrderId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"PURCHASEORDERID"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            A52PurchaseOrderCreatedDate = context.localUtil.CToD( cgiGet( edtPurchaseOrderCreatedDate_Internalname), 1);
            AssignAttri(sPrefix, false, "A52PurchaseOrderCreatedDate", context.localUtil.Format(A52PurchaseOrderCreatedDate, "99/99/99"));
            A5SupplierName = cgiGet( edtSupplierName_Internalname);
            AssignAttri(sPrefix, false, "A5SupplierName", A5SupplierName);
            A78PurchaseOrderTotalPaid = context.localUtil.CToN( cgiGet( edtPurchaseOrderTotalPaid_Internalname), ".", ",");
            n78PurchaseOrderTotalPaid = false;
            AssignAttri(sPrefix, false, "A78PurchaseOrderTotalPaid", StringUtil.LTrimStr( A78PurchaseOrderTotalPaid, 18, 2));
            A66PurchaseOrderClosedDate = context.localUtil.CToD( cgiGet( edtPurchaseOrderClosedDate_Internalname), 1);
            n66PurchaseOrderClosedDate = false;
            AssignAttri(sPrefix, false, "A66PurchaseOrderClosedDate", context.localUtil.Format(A66PurchaseOrderClosedDate, "99/99/99"));
            cmbavState.CurrentValue = cgiGet( cmbavState_Internalname);
            AV12State = cgiGet( cmbavState_Internalname);
            AssignAttri(sPrefix, false, "AV12State", AV12State);
            A135PurchaseOrderConfirmatedDate = context.localUtil.CToD( cgiGet( edtPurchaseOrderConfirmatedDate_Internalname), 1);
            n135PurchaseOrderConfirmatedDate = false;
            AssignAttri(sPrefix, false, "A135PurchaseOrderConfirmatedDate", context.localUtil.Format(A135PurchaseOrderConfirmatedDate, "99/99/99"));
            A136PurchaseOrderCanceledDescripti = cgiGet( edtPurchaseOrderCanceledDescripti_Internalname);
            n136PurchaseOrderCanceledDescripti = false;
            AssignAttri(sPrefix, false, "A136PurchaseOrderCanceledDescripti", A136PurchaseOrderCanceledDescripti);
            A138PurchaseOrderWasPaid = StringUtil.StrToBool( cgiGet( chkPurchaseOrderWasPaid_Internalname));
            n138PurchaseOrderWasPaid = false;
            AssignAttri(sPrefix, false, "A138PurchaseOrderWasPaid", A138PurchaseOrderWasPaid);
            A139PurchaseOrderPaidDate = context.localUtil.CToD( cgiGet( edtPurchaseOrderPaidDate_Internalname), 1);
            n139PurchaseOrderPaidDate = false;
            AssignAttri(sPrefix, false, "A139PurchaseOrderPaidDate", context.localUtil.Format(A139PurchaseOrderPaidDate, "99/99/99"));
            A53PurchaseOrderModifiedDate = context.localUtil.CToD( cgiGet( edtPurchaseOrderModifiedDate_Internalname), 1);
            n53PurchaseOrderModifiedDate = false;
            AssignAttri(sPrefix, false, "A53PurchaseOrderModifiedDate", context.localUtil.Format(A53PurchaseOrderModifiedDate, "99/99/99"));
            A79PurchaseOrderActive = StringUtil.StrToBool( cgiGet( edtPurchaseOrderActive_Internalname));
            AssignAttri(sPrefix, false, "A79PurchaseOrderActive", A79PurchaseOrderActive);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"PurchaseOrderGeneral");
            A66PurchaseOrderClosedDate = context.localUtil.CToD( cgiGet( edtPurchaseOrderClosedDate_Internalname), 1);
            n66PurchaseOrderClosedDate = false;
            AssignAttri(sPrefix, false, "A66PurchaseOrderClosedDate", context.localUtil.Format(A66PurchaseOrderClosedDate, "99/99/99"));
            forbiddenHiddens.Add("PurchaseOrderClosedDate", context.localUtil.Format(A66PurchaseOrderClosedDate, "99/99/99"));
            A79PurchaseOrderActive = StringUtil.StrToBool( cgiGet( edtPurchaseOrderActive_Internalname));
            AssignAttri(sPrefix, false, "A79PurchaseOrderActive", A79PurchaseOrderActive);
            forbiddenHiddens.Add("PurchaseOrderActive", StringUtil.BoolToStr( A79PurchaseOrderActive));
            hsh = cgiGet( sPrefix+"hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("purchaseordergeneral:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               return  ;
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
         E12132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E12132( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV16Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV16Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E13132( )
      {
         /* Load Routine */
         returnInSub = false;
         edtPurchaseOrderModifiedDate_Visible = 0;
         AssignProp(sPrefix, false, edtPurchaseOrderModifiedDate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderModifiedDate_Visible), 5, 0), true);
         edtPurchaseOrderActive_Visible = 0;
         AssignProp(sPrefix, false, edtPurchaseOrderActive_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderActive_Visible), 5, 0), true);
         if ( ! A79PurchaseOrderActive )
         {
            AV12State = "Canceled";
            AssignAttri(sPrefix, false, "AV12State", AV12State);
         }
         else if ( A79PurchaseOrderActive && ( (DateTime.MinValue==A66PurchaseOrderClosedDate) || (DateTime.MinValue==A66PurchaseOrderClosedDate) || ( DateTimeUtil.ResetTime ( A66PurchaseOrderClosedDate ) == DateTimeUtil.ResetTime ( DateTime.MinValue ) ) || (DateTime.MinValue==A66PurchaseOrderClosedDate) ) )
         {
            AV12State = "Pending";
            AssignAttri(sPrefix, false, "AV12State", AV12State);
         }
         else if ( A79PurchaseOrderActive && ! ( (DateTime.MinValue==A66PurchaseOrderClosedDate) || (DateTime.MinValue==A66PurchaseOrderClosedDate) || ( DateTimeUtil.ResetTime ( A66PurchaseOrderClosedDate ) == DateTimeUtil.ResetTime ( DateTime.MinValue ) ) || (DateTime.MinValue==A66PurchaseOrderClosedDate) ) )
         {
            AV12State = "Received";
            AssignAttri(sPrefix, false, "AV12State", AV12State);
         }
         else
         {
            AV12State = "";
            AssignAttri(sPrefix, false, "AV12State", AV12State);
         }
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV7TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV7TrnContext.gxTpr_Callerobject = AV16Pgmname;
         AV7TrnContext.gxTpr_Callerondelete = false;
         AV7TrnContext.gxTpr_Callerurl = AV10HTTPRequest.ScriptName+"?"+AV10HTTPRequest.QueryString;
         AV7TrnContext.gxTpr_Transactionname = "PurchaseOrder";
         AV8TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         AV8TrnContextAtt.gxTpr_Attributename = "PurchaseOrderId";
         AV8TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV6PurchaseOrderId), 6, 0);
         AV7TrnContext.gxTpr_Attributes.Add(AV8TrnContextAtt, 0);
         AV9Session.Set("TrnContext", AV7TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A50PurchaseOrderId = Convert.ToInt32(getParm(obj,0));
         AssignAttri(sPrefix, false, "A50PurchaseOrderId", StringUtil.LTrimStr( (decimal)(A50PurchaseOrderId), 6, 0));
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
         PA132( ) ;
         WS132( ) ;
         WE132( ) ;
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
         sCtrlA50PurchaseOrderId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA132( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "purchaseordergeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA132( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A50PurchaseOrderId = Convert.ToInt32(getParm(obj,2));
            AssignAttri(sPrefix, false, "A50PurchaseOrderId", StringUtil.LTrimStr( (decimal)(A50PurchaseOrderId), 6, 0));
         }
         wcpOA50PurchaseOrderId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA50PurchaseOrderId"), ".", ","), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( A50PurchaseOrderId != wcpOA50PurchaseOrderId ) ) )
         {
            setjustcreated();
         }
         wcpOA50PurchaseOrderId = A50PurchaseOrderId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA50PurchaseOrderId = cgiGet( sPrefix+"A50PurchaseOrderId_CTRL");
         if ( StringUtil.Len( sCtrlA50PurchaseOrderId) > 0 )
         {
            A50PurchaseOrderId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlA50PurchaseOrderId), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A50PurchaseOrderId", StringUtil.LTrimStr( (decimal)(A50PurchaseOrderId), 6, 0));
         }
         else
         {
            A50PurchaseOrderId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"A50PurchaseOrderId_PARM"), ".", ","), 18, MidpointRounding.ToEven));
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
         PA132( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS132( ) ;
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
         WS132( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A50PurchaseOrderId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A50PurchaseOrderId), 6, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA50PurchaseOrderId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A50PurchaseOrderId_CTRL", StringUtil.RTrim( sCtrlA50PurchaseOrderId));
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
         WE132( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024121203813", true, true);
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
         context.AddJavascriptSource("purchaseordergeneral.js", "?2024121203813", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavState.Name = "vSTATE";
         cmbavState.WebTags = "";
         cmbavState.addItem("Pending", "Pending", 0);
         cmbavState.addItem("Canceled", "Canceled", 0);
         cmbavState.addItem("Received", "Received", 0);
         if ( cmbavState.ItemCount > 0 )
         {
         }
         chkPurchaseOrderWasPaid.Name = "PURCHASEORDERWASPAID";
         chkPurchaseOrderWasPaid.WebTags = "";
         chkPurchaseOrderWasPaid.Caption = "";
         AssignProp(sPrefix, false, chkPurchaseOrderWasPaid_Internalname, "TitleCaption", chkPurchaseOrderWasPaid.Caption, true);
         chkPurchaseOrderWasPaid.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtnviewvoucher_Internalname = sPrefix+"BTNVIEWVOUCHER";
         edtPurchaseOrderCreatedDate_Internalname = sPrefix+"PURCHASEORDERCREATEDDATE";
         edtSupplierName_Internalname = sPrefix+"SUPPLIERNAME";
         edtPurchaseOrderTotalPaid_Internalname = sPrefix+"PURCHASEORDERTOTALPAID";
         edtPurchaseOrderClosedDate_Internalname = sPrefix+"PURCHASEORDERCLOSEDDATE";
         cmbavState_Internalname = sPrefix+"vSTATE";
         edtPurchaseOrderConfirmatedDate_Internalname = sPrefix+"PURCHASEORDERCONFIRMATEDDATE";
         edtPurchaseOrderCanceledDescripti_Internalname = sPrefix+"PURCHASEORDERCANCELEDDESCRIPTI";
         chkPurchaseOrderWasPaid_Internalname = sPrefix+"PURCHASEORDERWASPAID";
         edtPurchaseOrderPaidDate_Internalname = sPrefix+"PURCHASEORDERPAIDDATE";
         divAttributestable_Internalname = sPrefix+"ATTRIBUTESTABLE";
         edtPurchaseOrderModifiedDate_Internalname = sPrefix+"PURCHASEORDERMODIFIEDDATE";
         edtPurchaseOrderActive_Internalname = sPrefix+"PURCHASEORDERACTIVE";
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
         chkPurchaseOrderWasPaid.Caption = "Was Paid";
         edtPurchaseOrderActive_Jsonclick = "";
         edtPurchaseOrderActive_Enabled = 0;
         edtPurchaseOrderActive_Visible = 1;
         edtPurchaseOrderModifiedDate_Jsonclick = "";
         edtPurchaseOrderModifiedDate_Enabled = 0;
         edtPurchaseOrderModifiedDate_Visible = 1;
         edtPurchaseOrderPaidDate_Jsonclick = "";
         edtPurchaseOrderPaidDate_Enabled = 0;
         chkPurchaseOrderWasPaid.Enabled = 0;
         edtPurchaseOrderCanceledDescripti_Enabled = 0;
         edtPurchaseOrderConfirmatedDate_Jsonclick = "";
         edtPurchaseOrderConfirmatedDate_Enabled = 0;
         cmbavState_Jsonclick = "";
         cmbavState.Enabled = 1;
         edtPurchaseOrderClosedDate_Jsonclick = "";
         edtPurchaseOrderClosedDate_Enabled = 0;
         edtPurchaseOrderTotalPaid_Jsonclick = "";
         edtPurchaseOrderTotalPaid_Enabled = 0;
         edtSupplierName_Jsonclick = "";
         edtSupplierName_Enabled = 0;
         edtPurchaseOrderCreatedDate_Jsonclick = "";
         edtPurchaseOrderCreatedDate_Enabled = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A50PurchaseOrderId',fld:'PURCHASEORDERID',pic:'ZZZZZ9'},{av:'A138PurchaseOrderWasPaid',fld:'PURCHASEORDERWASPAID',pic:''},{av:'A66PurchaseOrderClosedDate',fld:'PURCHASEORDERCLOSEDDATE',pic:''},{av:'A79PurchaseOrderActive',fld:'PURCHASEORDERACTIVE',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOVIEWVOUCHER'","{handler:'E11131',iparms:[{av:'A50PurchaseOrderId',fld:'PURCHASEORDERID',pic:'ZZZZZ9'}]");
         setEventMetadata("'DOVIEWVOUCHER'",",oparms:[]}");
         setEventMetadata("VALIDV_STATE","{handler:'Validv_State',iparms:[]");
         setEventMetadata("VALIDV_STATE",",oparms:[]}");
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
         AV16Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         forbiddenHiddens = new GXProperties();
         A66PurchaseOrderClosedDate = DateTime.MinValue;
         GX_FocusControl = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnviewvoucher_Jsonclick = "";
         A52PurchaseOrderCreatedDate = DateTime.MinValue;
         A5SupplierName = "";
         AV12State = "";
         A135PurchaseOrderConfirmatedDate = DateTime.MinValue;
         A136PurchaseOrderCanceledDescripti = "";
         A139PurchaseOrderPaidDate = DateTime.MinValue;
         A53PurchaseOrderModifiedDate = DateTime.MinValue;
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         scmdbuf = "";
         H00132_A4SupplierId = new int[1] ;
         H00132_A50PurchaseOrderId = new int[1] ;
         H00132_A79PurchaseOrderActive = new bool[] {false} ;
         H00132_A53PurchaseOrderModifiedDate = new DateTime[] {DateTime.MinValue} ;
         H00132_n53PurchaseOrderModifiedDate = new bool[] {false} ;
         H00132_A139PurchaseOrderPaidDate = new DateTime[] {DateTime.MinValue} ;
         H00132_n139PurchaseOrderPaidDate = new bool[] {false} ;
         H00132_A138PurchaseOrderWasPaid = new bool[] {false} ;
         H00132_n138PurchaseOrderWasPaid = new bool[] {false} ;
         H00132_A136PurchaseOrderCanceledDescripti = new string[] {""} ;
         H00132_n136PurchaseOrderCanceledDescripti = new bool[] {false} ;
         H00132_A135PurchaseOrderConfirmatedDate = new DateTime[] {DateTime.MinValue} ;
         H00132_n135PurchaseOrderConfirmatedDate = new bool[] {false} ;
         H00132_A66PurchaseOrderClosedDate = new DateTime[] {DateTime.MinValue} ;
         H00132_n66PurchaseOrderClosedDate = new bool[] {false} ;
         H00132_A78PurchaseOrderTotalPaid = new decimal[1] ;
         H00132_n78PurchaseOrderTotalPaid = new bool[] {false} ;
         H00132_A5SupplierName = new string[] {""} ;
         H00132_A52PurchaseOrderCreatedDate = new DateTime[] {DateTime.MinValue} ;
         hsh = "";
         AV7TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10HTTPRequest = new GxHttpRequest( context);
         AV8TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         AV9Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA50PurchaseOrderId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.purchaseordergeneral__default(),
            new Object[][] {
                new Object[] {
               H00132_A4SupplierId, H00132_A50PurchaseOrderId, H00132_A79PurchaseOrderActive, H00132_A53PurchaseOrderModifiedDate, H00132_n53PurchaseOrderModifiedDate, H00132_A139PurchaseOrderPaidDate, H00132_n139PurchaseOrderPaidDate, H00132_A138PurchaseOrderWasPaid, H00132_n138PurchaseOrderWasPaid, H00132_A136PurchaseOrderCanceledDescripti,
               H00132_n136PurchaseOrderCanceledDescripti, H00132_A135PurchaseOrderConfirmatedDate, H00132_n135PurchaseOrderConfirmatedDate, H00132_A66PurchaseOrderClosedDate, H00132_n66PurchaseOrderClosedDate, H00132_A78PurchaseOrderTotalPaid, H00132_n78PurchaseOrderTotalPaid, H00132_A5SupplierName, H00132_A52PurchaseOrderCreatedDate
               }
            }
         );
         AV16Pgmname = "PurchaseOrderGeneral";
         /* GeneXus formulas. */
         AV16Pgmname = "PurchaseOrderGeneral";
         context.Gx_err = 0;
         cmbavState.Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int A50PurchaseOrderId ;
      private int wcpOA50PurchaseOrderId ;
      private int edtPurchaseOrderCreatedDate_Enabled ;
      private int edtSupplierName_Enabled ;
      private int edtPurchaseOrderTotalPaid_Enabled ;
      private int edtPurchaseOrderClosedDate_Enabled ;
      private int edtPurchaseOrderConfirmatedDate_Enabled ;
      private int edtPurchaseOrderCanceledDescripti_Enabled ;
      private int edtPurchaseOrderPaidDate_Enabled ;
      private int edtPurchaseOrderModifiedDate_Visible ;
      private int edtPurchaseOrderModifiedDate_Enabled ;
      private int edtPurchaseOrderActive_Visible ;
      private int edtPurchaseOrderActive_Enabled ;
      private int A4SupplierId ;
      private int AV6PurchaseOrderId ;
      private int idxLst ;
      private decimal A78PurchaseOrderTotalPaid ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV16Pgmname ;
      private string cmbavState_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnviewvoucher_Internalname ;
      private string bttBtnviewvoucher_Jsonclick ;
      private string divAttributestable_Internalname ;
      private string edtPurchaseOrderCreatedDate_Internalname ;
      private string edtPurchaseOrderCreatedDate_Jsonclick ;
      private string edtSupplierName_Internalname ;
      private string edtSupplierName_Jsonclick ;
      private string edtPurchaseOrderTotalPaid_Internalname ;
      private string edtPurchaseOrderTotalPaid_Jsonclick ;
      private string edtPurchaseOrderClosedDate_Internalname ;
      private string edtPurchaseOrderClosedDate_Jsonclick ;
      private string cmbavState_Jsonclick ;
      private string edtPurchaseOrderConfirmatedDate_Internalname ;
      private string edtPurchaseOrderConfirmatedDate_Jsonclick ;
      private string edtPurchaseOrderCanceledDescripti_Internalname ;
      private string chkPurchaseOrderWasPaid_Internalname ;
      private string edtPurchaseOrderPaidDate_Internalname ;
      private string edtPurchaseOrderPaidDate_Jsonclick ;
      private string edtPurchaseOrderModifiedDate_Internalname ;
      private string edtPurchaseOrderModifiedDate_Jsonclick ;
      private string edtPurchaseOrderActive_Internalname ;
      private string edtPurchaseOrderActive_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string scmdbuf ;
      private string hsh ;
      private string sCtrlA50PurchaseOrderId ;
      private DateTime A66PurchaseOrderClosedDate ;
      private DateTime A52PurchaseOrderCreatedDate ;
      private DateTime A135PurchaseOrderConfirmatedDate ;
      private DateTime A139PurchaseOrderPaidDate ;
      private DateTime A53PurchaseOrderModifiedDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool A79PurchaseOrderActive ;
      private bool wbLoad ;
      private bool A138PurchaseOrderWasPaid ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n138PurchaseOrderWasPaid ;
      private bool gxdyncontrolsrefreshing ;
      private bool n53PurchaseOrderModifiedDate ;
      private bool n139PurchaseOrderPaidDate ;
      private bool n136PurchaseOrderCanceledDescripti ;
      private bool n135PurchaseOrderConfirmatedDate ;
      private bool n66PurchaseOrderClosedDate ;
      private bool n78PurchaseOrderTotalPaid ;
      private bool returnInSub ;
      private string A5SupplierName ;
      private string AV12State ;
      private string A136PurchaseOrderCanceledDescripti ;
      private GXProperties forbiddenHiddens ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavState ;
      private GXCheckbox chkPurchaseOrderWasPaid ;
      private IDataStoreProvider pr_default ;
      private int[] H00132_A4SupplierId ;
      private int[] H00132_A50PurchaseOrderId ;
      private bool[] H00132_A79PurchaseOrderActive ;
      private DateTime[] H00132_A53PurchaseOrderModifiedDate ;
      private bool[] H00132_n53PurchaseOrderModifiedDate ;
      private DateTime[] H00132_A139PurchaseOrderPaidDate ;
      private bool[] H00132_n139PurchaseOrderPaidDate ;
      private bool[] H00132_A138PurchaseOrderWasPaid ;
      private bool[] H00132_n138PurchaseOrderWasPaid ;
      private string[] H00132_A136PurchaseOrderCanceledDescripti ;
      private bool[] H00132_n136PurchaseOrderCanceledDescripti ;
      private DateTime[] H00132_A135PurchaseOrderConfirmatedDate ;
      private bool[] H00132_n135PurchaseOrderConfirmatedDate ;
      private DateTime[] H00132_A66PurchaseOrderClosedDate ;
      private bool[] H00132_n66PurchaseOrderClosedDate ;
      private decimal[] H00132_A78PurchaseOrderTotalPaid ;
      private bool[] H00132_n78PurchaseOrderTotalPaid ;
      private string[] H00132_A5SupplierName ;
      private DateTime[] H00132_A52PurchaseOrderCreatedDate ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV10HTTPRequest ;
      private IGxSession AV9Session ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV7TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV8TrnContextAtt ;
   }

   public class purchaseordergeneral__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH00132;
          prmH00132 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00132", "SELECT T1.[SupplierId], T1.[PurchaseOrderId], T1.[PurchaseOrderActive], T1.[PurchaseOrderModifiedDate], T1.[PurchaseOrderPaidDate], T1.[PurchaseOrderWasPaid], T1.[PurchaseOrderCanceledDescripti], T1.[PurchaseOrderConfirmatedDate], T1.[PurchaseOrderClosedDate], T1.[PurchaseOrderTotalPaid], T2.[SupplierName], T1.[PurchaseOrderCreatedDate] FROM ([PurchaseOrder] T1 INNER JOIN [Supplier] T2 ON T2.[SupplierId] = T1.[SupplierId]) WHERE T1.[PurchaseOrderId] = @PurchaseOrderId ORDER BY T1.[PurchaseOrderId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00132,1, GxCacheFrequency.OFF ,true,true )
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
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((bool[]) buf[7])[0] = rslt.getBool(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((string[]) buf[9])[0] = rslt.getVarchar(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(8);
                ((bool[]) buf[12])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(9);
                ((bool[]) buf[14])[0] = rslt.wasNull(9);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(10);
                ((bool[]) buf[16])[0] = rslt.wasNull(10);
                ((string[]) buf[17])[0] = rslt.getVarchar(11);
                ((DateTime[]) buf[18])[0] = rslt.getGXDate(12);
                return;
       }
    }

 }

}
