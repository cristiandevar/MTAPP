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
   public class invoicegeneral : GXWebComponent
   {
      public invoicegeneral( )
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

      public invoicegeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_InvoiceId )
      {
         this.A20InvoiceId = aP0_InvoiceId;
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
         cmbavInvoicestatevalue = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "InvoiceId");
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
                  A20InvoiceId = (int)(Math.Round(NumberUtil.Val( GetPar( "InvoiceId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A20InvoiceId", StringUtil.LTrimStr( (decimal)(A20InvoiceId), 6, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(int)A20InvoiceId});
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
                  gxfirstwebparm = GetFirstPar( "InvoiceId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "InvoiceId");
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
            PA282( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV15Pgmname = "InvoiceGeneral";
               context.Gx_err = 0;
               cmbavInvoicestatevalue.Enabled = 0;
               AssignProp(sPrefix, false, cmbavInvoicestatevalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavInvoicestatevalue.Enabled), 5, 0), true);
               /* Using cursor H00283 */
               pr_default.execute(0, new Object[] {A20InvoiceId});
               if ( (pr_default.getStatus(0) != 101) )
               {
                  A131InvoiceLastPaymentMethodId = H00283_A131InvoiceLastPaymentMethodId[0];
                  n131InvoiceLastPaymentMethodId = H00283_n131InvoiceLastPaymentMethodId[0];
                  AssignAttri(sPrefix, false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
               }
               else
               {
                  A131InvoiceLastPaymentMethodId = 0;
                  n131InvoiceLastPaymentMethodId = false;
                  AssignAttri(sPrefix, false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
               }
               pr_default.close(0);
               /* Using cursor H00285 */
               pr_default.execute(1, new Object[] {A20InvoiceId});
               if ( (pr_default.getStatus(1) != 101) )
               {
                  A68InvoiceProductQuantity = H00285_A68InvoiceProductQuantity[0];
                  n68InvoiceProductQuantity = H00285_n68InvoiceProductQuantity[0];
                  AssignAttri(sPrefix, false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
               }
               else
               {
                  A68InvoiceProductQuantity = 0;
                  n68InvoiceProductQuantity = false;
                  AssignAttri(sPrefix, false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
               }
               pr_default.close(1);
               /* Using cursor H00289 */
               pr_default.execute(2, new Object[] {A20InvoiceId});
               if ( (pr_default.getStatus(2) != 101) )
               {
                  A80InvoiceTotalReceivable = H00289_A80InvoiceTotalReceivable[0];
                  n80InvoiceTotalReceivable = H00289_n80InvoiceTotalReceivable[0];
                  AssignAttri(sPrefix, false, "A80InvoiceTotalReceivable", StringUtil.LTrimStr( A80InvoiceTotalReceivable, 18, 2));
               }
               else
               {
                  A80InvoiceTotalReceivable = 0;
                  n80InvoiceTotalReceivable = false;
                  AssignAttri(sPrefix, false, "A80InvoiceTotalReceivable", StringUtil.LTrimStr( A80InvoiceTotalReceivable, 18, 2));
               }
               pr_default.close(2);
               WS282( ) ;
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
            context.SendWebValue( "Invoice General") ;
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("invoicegeneral.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A20InvoiceId,6,0))}, new string[] {"InvoiceId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA20InvoiceId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA20InvoiceId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"INVOICEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A20InvoiceId), 6, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm282( )
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
         return "InvoiceGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "Invoice General" ;
      }

      protected void WB280( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "invoicegeneral.aspx");
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
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnviewticket_Internalname, "", "View Ticket", bttBtnviewticket_Jsonclick, 7, "View Ticket", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e11281_client"+"'", TempTags, "", 2, "HLP_InvoiceGeneral.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtInvoiceCreatedDate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtInvoiceCreatedDate_Internalname, "Created Date", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtInvoiceCreatedDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtInvoiceCreatedDate_Internalname, context.localUtil.Format(A38InvoiceCreatedDate, "99/99/99"), context.localUtil.Format( A38InvoiceCreatedDate, "99/99/99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtInvoiceCreatedDate_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtInvoiceCreatedDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_InvoiceGeneral.htm");
            GxWebStd.gx_bitmap( context, edtInvoiceCreatedDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtInvoiceCreatedDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_InvoiceGeneral.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtInvoiceTotalReceivable_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtInvoiceTotalReceivable_Internalname, "Total Receivable", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtInvoiceTotalReceivable_Internalname, StringUtil.LTrim( StringUtil.NToC( A80InvoiceTotalReceivable, 18, 2, ".", "")), StringUtil.LTrim( ((edtInvoiceTotalReceivable_Enabled!=0) ? context.localUtil.Format( A80InvoiceTotalReceivable, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A80InvoiceTotalReceivable, "ZZZZZZZZZZZZZZ9.99"))), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtInvoiceTotalReceivable_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtInvoiceTotalReceivable_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Price", "right", false, "", "HLP_InvoiceGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtInvoiceProductQuantity_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtInvoiceProductQuantity_Internalname, "Product Quantity", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtInvoiceProductQuantity_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A68InvoiceProductQuantity), 4, 0, ".", "")), StringUtil.LTrim( ((edtInvoiceProductQuantity_Enabled!=0) ? context.localUtil.Format( (decimal)(A68InvoiceProductQuantity), "ZZZ9") : context.localUtil.Format( (decimal)(A68InvoiceProductQuantity), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtInvoiceProductQuantity_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtInvoiceProductQuantity_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_InvoiceGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUserName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtUserName_Internalname, "Seller Name", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtUserName_Internalname, A100UserName, StringUtil.RTrim( context.localUtil.Format( A100UserName, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUserName_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtUserName_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_InvoiceGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtInvoiceModifiedDate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtInvoiceModifiedDate_Internalname, "Modified Date", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtInvoiceModifiedDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtInvoiceModifiedDate_Internalname, context.localUtil.Format(A39InvoiceModifiedDate, "99/99/99"), context.localUtil.Format( A39InvoiceModifiedDate, "99/99/99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtInvoiceModifiedDate_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtInvoiceModifiedDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_InvoiceGeneral.htm");
            GxWebStd.gx_bitmap( context, edtInvoiceModifiedDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtInvoiceModifiedDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_InvoiceGeneral.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavInvoicestatevalue_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavInvoicestatevalue_Internalname, "States", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavInvoicestatevalue, cmbavInvoicestatevalue_Internalname, StringUtil.RTrim( AV11InvoiceStateValue), 1, cmbavInvoicestatevalue_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavInvoicestatevalue.Enabled, 0, 0, 0, "em", 0, "", "", "ReadonlyAttribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "", true, 0, "HLP_InvoiceGeneral.htm");
            cmbavInvoicestatevalue.CurrentValue = StringUtil.RTrim( AV11InvoiceStateValue);
            AssignProp(sPrefix, false, cmbavInvoicestatevalue_Internalname, "Values", (string)(cmbavInvoicestatevalue.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtInvoiceLastPaymentMethodId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtInvoiceLastPaymentMethodId_Internalname, "Method Id", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtInvoiceLastPaymentMethodId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0, ".", "")), StringUtil.LTrim( ((edtInvoiceLastPaymentMethodId_Enabled!=0) ? context.localUtil.Format( (decimal)(A131InvoiceLastPaymentMethodId), "ZZZZZ9") : context.localUtil.Format( (decimal)(A131InvoiceLastPaymentMethodId), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtInvoiceLastPaymentMethodId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtInvoiceLastPaymentMethodId_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_InvoiceGeneral.htm");
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

      protected void START282( )
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
               Form.Meta.addItem("description", "Invoice General", 0) ;
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
               STRUP280( ) ;
            }
         }
      }

      protected void WS282( )
      {
         START282( ) ;
         EVT282( ) ;
      }

      protected void EVT282( )
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
                                 STRUP280( ) ;
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
                                 STRUP280( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E12282 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP280( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E13282 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP280( ) ;
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
                                 STRUP280( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = cmbavInvoicestatevalue_Internalname;
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

      protected void WE282( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm282( ) ;
            }
         }
      }

      protected void PA282( )
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
               GX_FocusControl = cmbavInvoicestatevalue_Internalname;
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
         if ( cmbavInvoicestatevalue.ItemCount > 0 )
         {
            AV11InvoiceStateValue = cmbavInvoicestatevalue.getValidValue(AV11InvoiceStateValue);
            AssignAttri(sPrefix, false, "AV11InvoiceStateValue", AV11InvoiceStateValue);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavInvoicestatevalue.CurrentValue = StringUtil.RTrim( AV11InvoiceStateValue);
            AssignProp(sPrefix, false, cmbavInvoicestatevalue_Internalname, "Values", cmbavInvoicestatevalue.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF282( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV15Pgmname = "InvoiceGeneral";
         context.Gx_err = 0;
         cmbavInvoicestatevalue.Enabled = 0;
         AssignProp(sPrefix, false, cmbavInvoicestatevalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavInvoicestatevalue.Enabled), 5, 0), true);
      }

      protected void RF282( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H002815 */
            pr_default.execute(3, new Object[] {A20InvoiceId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A99UserId = H002815_A99UserId[0];
               A94InvoiceActive = H002815_A94InvoiceActive[0];
               A39InvoiceModifiedDate = H002815_A39InvoiceModifiedDate[0];
               n39InvoiceModifiedDate = H002815_n39InvoiceModifiedDate[0];
               AssignAttri(sPrefix, false, "A39InvoiceModifiedDate", context.localUtil.Format(A39InvoiceModifiedDate, "99/99/99"));
               A100UserName = H002815_A100UserName[0];
               AssignAttri(sPrefix, false, "A100UserName", A100UserName);
               A38InvoiceCreatedDate = H002815_A38InvoiceCreatedDate[0];
               AssignAttri(sPrefix, false, "A38InvoiceCreatedDate", context.localUtil.Format(A38InvoiceCreatedDate, "99/99/99"));
               A131InvoiceLastPaymentMethodId = H002815_A131InvoiceLastPaymentMethodId[0];
               n131InvoiceLastPaymentMethodId = H002815_n131InvoiceLastPaymentMethodId[0];
               AssignAttri(sPrefix, false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
               A68InvoiceProductQuantity = H002815_A68InvoiceProductQuantity[0];
               n68InvoiceProductQuantity = H002815_n68InvoiceProductQuantity[0];
               AssignAttri(sPrefix, false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
               A80InvoiceTotalReceivable = H002815_A80InvoiceTotalReceivable[0];
               n80InvoiceTotalReceivable = H002815_n80InvoiceTotalReceivable[0];
               AssignAttri(sPrefix, false, "A80InvoiceTotalReceivable", StringUtil.LTrimStr( A80InvoiceTotalReceivable, 18, 2));
               A100UserName = H002815_A100UserName[0];
               AssignAttri(sPrefix, false, "A100UserName", A100UserName);
               A131InvoiceLastPaymentMethodId = H002815_A131InvoiceLastPaymentMethodId[0];
               n131InvoiceLastPaymentMethodId = H002815_n131InvoiceLastPaymentMethodId[0];
               AssignAttri(sPrefix, false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
               A68InvoiceProductQuantity = H002815_A68InvoiceProductQuantity[0];
               n68InvoiceProductQuantity = H002815_n68InvoiceProductQuantity[0];
               AssignAttri(sPrefix, false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
               A80InvoiceTotalReceivable = H002815_A80InvoiceTotalReceivable[0];
               n80InvoiceTotalReceivable = H002815_n80InvoiceTotalReceivable[0];
               AssignAttri(sPrefix, false, "A80InvoiceTotalReceivable", StringUtil.LTrimStr( A80InvoiceTotalReceivable, 18, 2));
               /* Execute user event: Load */
               E13282 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(3);
            WB280( ) ;
         }
      }

      protected void send_integrity_lvl_hashes282( )
      {
      }

      protected void before_start_formulas( )
      {
         AV15Pgmname = "InvoiceGeneral";
         context.Gx_err = 0;
         cmbavInvoicestatevalue.Enabled = 0;
         AssignProp(sPrefix, false, cmbavInvoicestatevalue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavInvoicestatevalue.Enabled), 5, 0), true);
         /* Using cursor H002817 */
         pr_default.execute(4, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            A131InvoiceLastPaymentMethodId = H002817_A131InvoiceLastPaymentMethodId[0];
            n131InvoiceLastPaymentMethodId = H002817_n131InvoiceLastPaymentMethodId[0];
            AssignAttri(sPrefix, false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
         }
         else
         {
            A131InvoiceLastPaymentMethodId = 0;
            n131InvoiceLastPaymentMethodId = false;
            AssignAttri(sPrefix, false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
         }
         pr_default.close(4);
         /* Using cursor H002819 */
         pr_default.execute(5, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            A68InvoiceProductQuantity = H002819_A68InvoiceProductQuantity[0];
            n68InvoiceProductQuantity = H002819_n68InvoiceProductQuantity[0];
            AssignAttri(sPrefix, false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
         }
         else
         {
            A68InvoiceProductQuantity = 0;
            n68InvoiceProductQuantity = false;
            AssignAttri(sPrefix, false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
         }
         pr_default.close(5);
         /* Using cursor H002823 */
         pr_default.execute(6, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            A80InvoiceTotalReceivable = H002823_A80InvoiceTotalReceivable[0];
            n80InvoiceTotalReceivable = H002823_n80InvoiceTotalReceivable[0];
            AssignAttri(sPrefix, false, "A80InvoiceTotalReceivable", StringUtil.LTrimStr( A80InvoiceTotalReceivable, 18, 2));
         }
         else
         {
            A80InvoiceTotalReceivable = 0;
            n80InvoiceTotalReceivable = false;
            AssignAttri(sPrefix, false, "A80InvoiceTotalReceivable", StringUtil.LTrimStr( A80InvoiceTotalReceivable, 18, 2));
         }
         pr_default.close(6);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP280( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E12282 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA20InvoiceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA20InvoiceId"), ".", ","), 18, MidpointRounding.ToEven));
            A20InvoiceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"INVOICEID"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            A38InvoiceCreatedDate = context.localUtil.CToD( cgiGet( edtInvoiceCreatedDate_Internalname), 1);
            AssignAttri(sPrefix, false, "A38InvoiceCreatedDate", context.localUtil.Format(A38InvoiceCreatedDate, "99/99/99"));
            A80InvoiceTotalReceivable = context.localUtil.CToN( cgiGet( edtInvoiceTotalReceivable_Internalname), ".", ",");
            n80InvoiceTotalReceivable = false;
            AssignAttri(sPrefix, false, "A80InvoiceTotalReceivable", StringUtil.LTrimStr( A80InvoiceTotalReceivable, 18, 2));
            A68InvoiceProductQuantity = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtInvoiceProductQuantity_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            n68InvoiceProductQuantity = false;
            AssignAttri(sPrefix, false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
            A100UserName = cgiGet( edtUserName_Internalname);
            AssignAttri(sPrefix, false, "A100UserName", A100UserName);
            A39InvoiceModifiedDate = context.localUtil.CToD( cgiGet( edtInvoiceModifiedDate_Internalname), 1);
            n39InvoiceModifiedDate = false;
            AssignAttri(sPrefix, false, "A39InvoiceModifiedDate", context.localUtil.Format(A39InvoiceModifiedDate, "99/99/99"));
            cmbavInvoicestatevalue.CurrentValue = cgiGet( cmbavInvoicestatevalue_Internalname);
            AV11InvoiceStateValue = cgiGet( cmbavInvoicestatevalue_Internalname);
            AssignAttri(sPrefix, false, "AV11InvoiceStateValue", AV11InvoiceStateValue);
            A131InvoiceLastPaymentMethodId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtInvoiceLastPaymentMethodId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            n131InvoiceLastPaymentMethodId = false;
            AssignAttri(sPrefix, false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
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
         E12282 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E12282( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV15Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV15Pgmname))}, new string[] {"GxObject"}) );
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

      protected void E13282( )
      {
         /* Load Routine */
         returnInSub = false;
         if ( A94InvoiceActive )
         {
            AV11InvoiceStateValue = "Confirmated";
            AssignAttri(sPrefix, false, "AV11InvoiceStateValue", AV11InvoiceStateValue);
         }
         else
         {
            AV11InvoiceStateValue = "Canceled";
            AssignAttri(sPrefix, false, "AV11InvoiceStateValue", AV11InvoiceStateValue);
         }
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV7TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV7TrnContext.gxTpr_Callerobject = AV15Pgmname;
         AV7TrnContext.gxTpr_Callerondelete = false;
         AV7TrnContext.gxTpr_Callerurl = AV10HTTPRequest.ScriptName+"?"+AV10HTTPRequest.QueryString;
         AV7TrnContext.gxTpr_Transactionname = "Invoice";
         AV8TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         AV8TrnContextAtt.gxTpr_Attributename = "InvoiceId";
         AV8TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV6InvoiceId), 6, 0);
         AV7TrnContext.gxTpr_Attributes.Add(AV8TrnContextAtt, 0);
         AV9Session.Set("TrnContext", AV7TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A20InvoiceId = Convert.ToInt32(getParm(obj,0));
         AssignAttri(sPrefix, false, "A20InvoiceId", StringUtil.LTrimStr( (decimal)(A20InvoiceId), 6, 0));
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
         PA282( ) ;
         WS282( ) ;
         WE282( ) ;
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
         sCtrlA20InvoiceId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA282( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "invoicegeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA282( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A20InvoiceId = Convert.ToInt32(getParm(obj,2));
            AssignAttri(sPrefix, false, "A20InvoiceId", StringUtil.LTrimStr( (decimal)(A20InvoiceId), 6, 0));
         }
         wcpOA20InvoiceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA20InvoiceId"), ".", ","), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( A20InvoiceId != wcpOA20InvoiceId ) ) )
         {
            setjustcreated();
         }
         wcpOA20InvoiceId = A20InvoiceId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA20InvoiceId = cgiGet( sPrefix+"A20InvoiceId_CTRL");
         if ( StringUtil.Len( sCtrlA20InvoiceId) > 0 )
         {
            A20InvoiceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlA20InvoiceId), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A20InvoiceId", StringUtil.LTrimStr( (decimal)(A20InvoiceId), 6, 0));
         }
         else
         {
            A20InvoiceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"A20InvoiceId_PARM"), ".", ","), 18, MidpointRounding.ToEven));
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
         PA282( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS282( ) ;
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
         WS282( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A20InvoiceId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A20InvoiceId), 6, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA20InvoiceId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A20InvoiceId_CTRL", StringUtil.RTrim( sCtrlA20InvoiceId));
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
         WE282( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20241261104940", true, true);
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
         context.AddJavascriptSource("invoicegeneral.js", "?20241261104940", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavInvoicestatevalue.Name = "vINVOICESTATEVALUE";
         cmbavInvoicestatevalue.WebTags = "";
         cmbavInvoicestatevalue.addItem("Confirmated", "Confirmated", 0);
         cmbavInvoicestatevalue.addItem("Canceled", "Canceled", 0);
         if ( cmbavInvoicestatevalue.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtnviewticket_Internalname = sPrefix+"BTNVIEWTICKET";
         edtInvoiceCreatedDate_Internalname = sPrefix+"INVOICECREATEDDATE";
         edtInvoiceTotalReceivable_Internalname = sPrefix+"INVOICETOTALRECEIVABLE";
         edtInvoiceProductQuantity_Internalname = sPrefix+"INVOICEPRODUCTQUANTITY";
         edtUserName_Internalname = sPrefix+"USERNAME";
         edtInvoiceModifiedDate_Internalname = sPrefix+"INVOICEMODIFIEDDATE";
         cmbavInvoicestatevalue_Internalname = sPrefix+"vINVOICESTATEVALUE";
         edtInvoiceLastPaymentMethodId_Internalname = sPrefix+"INVOICELASTPAYMENTMETHODID";
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
         edtInvoiceLastPaymentMethodId_Jsonclick = "";
         edtInvoiceLastPaymentMethodId_Enabled = 0;
         cmbavInvoicestatevalue_Jsonclick = "";
         cmbavInvoicestatevalue.Enabled = 1;
         edtInvoiceModifiedDate_Jsonclick = "";
         edtInvoiceModifiedDate_Enabled = 0;
         edtUserName_Jsonclick = "";
         edtUserName_Enabled = 0;
         edtInvoiceProductQuantity_Jsonclick = "";
         edtInvoiceProductQuantity_Enabled = 0;
         edtInvoiceTotalReceivable_Jsonclick = "";
         edtInvoiceTotalReceivable_Enabled = 0;
         edtInvoiceCreatedDate_Jsonclick = "";
         edtInvoiceCreatedDate_Enabled = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A20InvoiceId',fld:'INVOICEID',pic:'ZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOVIEWTICKET'","{handler:'E11281',iparms:[{av:'A20InvoiceId',fld:'INVOICEID',pic:'ZZZZZ9'}]");
         setEventMetadata("'DOVIEWTICKET'",",oparms:[]}");
         setEventMetadata("VALIDV_INVOICESTATEVALUE","{handler:'Validv_Invoicestatevalue',iparms:[]");
         setEventMetadata("VALIDV_INVOICESTATEVALUE",",oparms:[]}");
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
         AV15Pgmname = "";
         scmdbuf = "";
         H00283_A131InvoiceLastPaymentMethodId = new int[1] ;
         H00283_n131InvoiceLastPaymentMethodId = new bool[] {false} ;
         H00285_A68InvoiceProductQuantity = new short[1] ;
         H00285_n68InvoiceProductQuantity = new bool[] {false} ;
         H00289_A80InvoiceTotalReceivable = new decimal[1] ;
         H00289_n80InvoiceTotalReceivable = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnviewticket_Jsonclick = "";
         A38InvoiceCreatedDate = DateTime.MinValue;
         A100UserName = "";
         A39InvoiceModifiedDate = DateTime.MinValue;
         AV11InvoiceStateValue = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         H002815_A99UserId = new int[1] ;
         H002815_A20InvoiceId = new int[1] ;
         H002815_A94InvoiceActive = new bool[] {false} ;
         H002815_A39InvoiceModifiedDate = new DateTime[] {DateTime.MinValue} ;
         H002815_n39InvoiceModifiedDate = new bool[] {false} ;
         H002815_A100UserName = new string[] {""} ;
         H002815_A38InvoiceCreatedDate = new DateTime[] {DateTime.MinValue} ;
         H002815_A131InvoiceLastPaymentMethodId = new int[1] ;
         H002815_n131InvoiceLastPaymentMethodId = new bool[] {false} ;
         H002815_A68InvoiceProductQuantity = new short[1] ;
         H002815_n68InvoiceProductQuantity = new bool[] {false} ;
         H002815_A80InvoiceTotalReceivable = new decimal[1] ;
         H002815_n80InvoiceTotalReceivable = new bool[] {false} ;
         H002817_A131InvoiceLastPaymentMethodId = new int[1] ;
         H002817_n131InvoiceLastPaymentMethodId = new bool[] {false} ;
         H002819_A68InvoiceProductQuantity = new short[1] ;
         H002819_n68InvoiceProductQuantity = new bool[] {false} ;
         H002823_A80InvoiceTotalReceivable = new decimal[1] ;
         H002823_n80InvoiceTotalReceivable = new bool[] {false} ;
         AV7TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10HTTPRequest = new GxHttpRequest( context);
         AV8TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         AV9Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA20InvoiceId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.invoicegeneral__default(),
            new Object[][] {
                new Object[] {
               H00283_A131InvoiceLastPaymentMethodId, H00283_n131InvoiceLastPaymentMethodId
               }
               , new Object[] {
               H00285_A68InvoiceProductQuantity, H00285_n68InvoiceProductQuantity
               }
               , new Object[] {
               H00289_A80InvoiceTotalReceivable, H00289_n80InvoiceTotalReceivable
               }
               , new Object[] {
               H002815_A99UserId, H002815_A20InvoiceId, H002815_A94InvoiceActive, H002815_A39InvoiceModifiedDate, H002815_n39InvoiceModifiedDate, H002815_A100UserName, H002815_A38InvoiceCreatedDate, H002815_A131InvoiceLastPaymentMethodId, H002815_n131InvoiceLastPaymentMethodId, H002815_A68InvoiceProductQuantity,
               H002815_n68InvoiceProductQuantity, H002815_A80InvoiceTotalReceivable, H002815_n80InvoiceTotalReceivable
               }
               , new Object[] {
               H002817_A131InvoiceLastPaymentMethodId, H002817_n131InvoiceLastPaymentMethodId
               }
               , new Object[] {
               H002819_A68InvoiceProductQuantity, H002819_n68InvoiceProductQuantity
               }
               , new Object[] {
               H002823_A80InvoiceTotalReceivable, H002823_n80InvoiceTotalReceivable
               }
            }
         );
         AV15Pgmname = "InvoiceGeneral";
         /* GeneXus formulas. */
         AV15Pgmname = "InvoiceGeneral";
         context.Gx_err = 0;
         cmbavInvoicestatevalue.Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short A68InvoiceProductQuantity ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int A20InvoiceId ;
      private int wcpOA20InvoiceId ;
      private int A131InvoiceLastPaymentMethodId ;
      private int edtInvoiceCreatedDate_Enabled ;
      private int edtInvoiceTotalReceivable_Enabled ;
      private int edtInvoiceProductQuantity_Enabled ;
      private int edtUserName_Enabled ;
      private int edtInvoiceModifiedDate_Enabled ;
      private int edtInvoiceLastPaymentMethodId_Enabled ;
      private int A99UserId ;
      private int AV6InvoiceId ;
      private int idxLst ;
      private decimal A80InvoiceTotalReceivable ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV15Pgmname ;
      private string cmbavInvoicestatevalue_Internalname ;
      private string scmdbuf ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnviewticket_Internalname ;
      private string bttBtnviewticket_Jsonclick ;
      private string divAttributestable_Internalname ;
      private string edtInvoiceCreatedDate_Internalname ;
      private string edtInvoiceCreatedDate_Jsonclick ;
      private string edtInvoiceTotalReceivable_Internalname ;
      private string edtInvoiceTotalReceivable_Jsonclick ;
      private string edtInvoiceProductQuantity_Internalname ;
      private string edtInvoiceProductQuantity_Jsonclick ;
      private string edtUserName_Internalname ;
      private string edtUserName_Jsonclick ;
      private string edtInvoiceModifiedDate_Internalname ;
      private string edtInvoiceModifiedDate_Jsonclick ;
      private string cmbavInvoicestatevalue_Jsonclick ;
      private string edtInvoiceLastPaymentMethodId_Internalname ;
      private string edtInvoiceLastPaymentMethodId_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string sCtrlA20InvoiceId ;
      private DateTime A38InvoiceCreatedDate ;
      private DateTime A39InvoiceModifiedDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n131InvoiceLastPaymentMethodId ;
      private bool n68InvoiceProductQuantity ;
      private bool n80InvoiceTotalReceivable ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool A94InvoiceActive ;
      private bool n39InvoiceModifiedDate ;
      private bool returnInSub ;
      private string A100UserName ;
      private string AV11InvoiceStateValue ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavInvoicestatevalue ;
      private IDataStoreProvider pr_default ;
      private int[] H00283_A131InvoiceLastPaymentMethodId ;
      private bool[] H00283_n131InvoiceLastPaymentMethodId ;
      private short[] H00285_A68InvoiceProductQuantity ;
      private bool[] H00285_n68InvoiceProductQuantity ;
      private decimal[] H00289_A80InvoiceTotalReceivable ;
      private bool[] H00289_n80InvoiceTotalReceivable ;
      private int[] H002815_A99UserId ;
      private int[] H002815_A20InvoiceId ;
      private bool[] H002815_A94InvoiceActive ;
      private DateTime[] H002815_A39InvoiceModifiedDate ;
      private bool[] H002815_n39InvoiceModifiedDate ;
      private string[] H002815_A100UserName ;
      private DateTime[] H002815_A38InvoiceCreatedDate ;
      private int[] H002815_A131InvoiceLastPaymentMethodId ;
      private bool[] H002815_n131InvoiceLastPaymentMethodId ;
      private short[] H002815_A68InvoiceProductQuantity ;
      private bool[] H002815_n68InvoiceProductQuantity ;
      private decimal[] H002815_A80InvoiceTotalReceivable ;
      private bool[] H002815_n80InvoiceTotalReceivable ;
      private int[] H002817_A131InvoiceLastPaymentMethodId ;
      private bool[] H002817_n131InvoiceLastPaymentMethodId ;
      private short[] H002819_A68InvoiceProductQuantity ;
      private bool[] H002819_n68InvoiceProductQuantity ;
      private decimal[] H002823_A80InvoiceTotalReceivable ;
      private bool[] H002823_n80InvoiceTotalReceivable ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV10HTTPRequest ;
      private IGxSession AV9Session ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV7TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV8TrnContextAtt ;
   }

   public class invoicegeneral__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00283;
          prmH00283 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmH00285;
          prmH00285 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmH00289;
          prmH00289 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmH002815;
          prmH002815 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmH002817;
          prmH002817 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmH002819;
          prmH002819 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmH002823;
          prmH002823 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00283", "SELECT COALESCE( T1.[InvoiceLastPaymentMethodId], 0) AS InvoiceLastPaymentMethodId FROM (SELECT MAX([InvoicePaymentMethodId]) AS InvoiceLastPaymentMethodId, [InvoiceId] FROM [InvoicePaymentMethod] GROUP BY [InvoiceId] ) T1 WHERE T1.[InvoiceId] = @InvoiceId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00283,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H00285", "SELECT COALESCE( T1.[InvoiceProductQuantity], 0) AS InvoiceProductQuantity FROM (SELECT COUNT(*) AS InvoiceProductQuantity, [InvoiceId] FROM [InvoiceDetail] GROUP BY [InvoiceId] ) T1 WHERE T1.[InvoiceId] = @InvoiceId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00285,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H00289", "SELECT COALESCE( T1.[InvoiceTotalReceivable], 0) AS InvoiceTotalReceivable FROM (SELECT COALESCE( T4.[GXC1], 0) - COALESCE( T3.[GXC2], 0) + COALESCE( T3.[GXC3], 0) AS InvoiceTotalReceivable, T2.[InvoiceId] FROM (([Invoice] T2 LEFT JOIN (SELECT SUM([InvoicePaymentMethodDiscountIm]) AS GXC2, [InvoiceId], SUM([InvoicePaymentMethodRechargeIm]) AS GXC3 FROM [InvoicePaymentMethod] GROUP BY [InvoiceId] ) T3 ON T3.[InvoiceId] = T2.[InvoiceId]) LEFT JOIN (SELECT SUM([InvoiceDetailQuantity] * CAST([InvoiceDetailHistoricPrice] AS decimal( 28, 10))) AS GXC1, [InvoiceId] FROM [InvoiceDetail] GROUP BY [InvoiceId] ) T4 ON T4.[InvoiceId] = T2.[InvoiceId]) ) T1 WHERE T1.[InvoiceId] = @InvoiceId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00289,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H002815", "SELECT T1.[UserId], T1.[InvoiceId], T1.[InvoiceActive], T1.[InvoiceModifiedDate], T2.[UserName], T1.[InvoiceCreatedDate], COALESCE( T3.[InvoiceLastPaymentMethodId], 0) AS InvoiceLastPaymentMethodId, COALESCE( T4.[InvoiceProductQuantity], 0) AS InvoiceProductQuantity, COALESCE( T5.[InvoiceTotalReceivable], 0) AS InvoiceTotalReceivable FROM (((([Invoice] T1 INNER JOIN [User] T2 ON T2.[UserId] = T1.[UserId]) LEFT JOIN (SELECT MAX([InvoicePaymentMethodId]) AS InvoiceLastPaymentMethodId, [InvoiceId] FROM [InvoicePaymentMethod] GROUP BY [InvoiceId] ) T3 ON T3.[InvoiceId] = T1.[InvoiceId]) LEFT JOIN (SELECT COUNT(*) AS InvoiceProductQuantity, [InvoiceId] FROM [InvoiceDetail] GROUP BY [InvoiceId] ) T4 ON T4.[InvoiceId] = T1.[InvoiceId]) INNER JOIN (SELECT COALESCE( T8.[GXC1], 0) - COALESCE( T7.[GXC2], 0) + COALESCE( T7.[GXC3], 0) AS InvoiceTotalReceivable, T6.[InvoiceId] FROM (([Invoice] T6 LEFT JOIN (SELECT SUM([InvoicePaymentMethodDiscountIm]) AS GXC2, [InvoiceId], SUM([InvoicePaymentMethodRechargeIm]) AS GXC3 FROM [InvoicePaymentMethod] GROUP BY [InvoiceId] ) T7 ON T7.[InvoiceId] = T6.[InvoiceId]) LEFT JOIN (SELECT SUM([InvoiceDetailQuantity] * CAST([InvoiceDetailHistoricPrice] AS decimal( 28, 10))) AS GXC1, [InvoiceId] FROM [InvoiceDetail] GROUP BY [InvoiceId] ) T8 ON T8.[InvoiceId] = T6.[InvoiceId]) ) T5 ON T5.[InvoiceId] = T1.[InvoiceId]) WHERE T1.[InvoiceId] = @InvoiceId ORDER BY T1.[InvoiceId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002815,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H002817", "SELECT COALESCE( T1.[InvoiceLastPaymentMethodId], 0) AS InvoiceLastPaymentMethodId FROM (SELECT MAX([InvoicePaymentMethodId]) AS InvoiceLastPaymentMethodId, [InvoiceId] FROM [InvoicePaymentMethod] GROUP BY [InvoiceId] ) T1 WHERE T1.[InvoiceId] = @InvoiceId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002817,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H002819", "SELECT COALESCE( T1.[InvoiceProductQuantity], 0) AS InvoiceProductQuantity FROM (SELECT COUNT(*) AS InvoiceProductQuantity, [InvoiceId] FROM [InvoiceDetail] GROUP BY [InvoiceId] ) T1 WHERE T1.[InvoiceId] = @InvoiceId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002819,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H002823", "SELECT COALESCE( T1.[InvoiceTotalReceivable], 0) AS InvoiceTotalReceivable FROM (SELECT COALESCE( T4.[GXC1], 0) - COALESCE( T3.[GXC2], 0) + COALESCE( T3.[GXC3], 0) AS InvoiceTotalReceivable, T2.[InvoiceId] FROM (([Invoice] T2 LEFT JOIN (SELECT SUM([InvoicePaymentMethodDiscountIm]) AS GXC2, [InvoiceId], SUM([InvoicePaymentMethodRechargeIm]) AS GXC3 FROM [InvoicePaymentMethod] GROUP BY [InvoiceId] ) T3 ON T3.[InvoiceId] = T2.[InvoiceId]) LEFT JOIN (SELECT SUM([InvoiceDetailQuantity] * CAST([InvoiceDetailHistoricPrice] AS decimal( 28, 10))) AS GXC1, [InvoiceId] FROM [InvoiceDetail] GROUP BY [InvoiceId] ) T4 ON T4.[InvoiceId] = T2.[InvoiceId]) ) T1 WHERE T1.[InvoiceId] = @InvoiceId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002823,1, GxCacheFrequency.OFF ,true,true )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 2 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((short[]) buf[9])[0] = rslt.getShort(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(9);
                ((bool[]) buf[12])[0] = rslt.wasNull(9);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 6 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
       }
    }

 }

}
