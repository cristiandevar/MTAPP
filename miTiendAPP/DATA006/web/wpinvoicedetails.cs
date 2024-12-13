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
   public class wpinvoicedetails : GXDataArea
   {
      public wpinvoicedetails( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public wpinvoicedetails( IGxContext context )
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

      protected override void createObjects( )
      {
         cmbavType = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
            {
               gxnrGrid1_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid1") == 0 )
            {
               gxgrGrid1_refresh_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid2") == 0 )
            {
               gxnrGrid2_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid2") == 0 )
            {
               gxgrGrid2_refresh_invoke( ) ;
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
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               A20InvoiceId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A20InvoiceId", StringUtil.LTrimStr( (decimal)(A20InvoiceId), 6, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_INVOICEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A20InvoiceId), "ZZZZZ9"), context));
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

      protected void gxnrGrid1_newrow_invoke( )
      {
         nRC_GXsfl_36 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_36"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_36_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_36_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_36_idx = GetPar( "sGXsfl_36_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid1_newrow( ) ;
         /* End function gxnrGrid1_newrow_invoke */
      }

      protected void gxgrGrid1_refresh_invoke( )
      {
         A20InvoiceId = (int)(Math.Round(NumberUtil.Val( GetPar( "InvoiceId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( A20InvoiceId) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid1_refresh_invoke */
      }

      protected void gxnrGrid2_newrow_invoke( )
      {
         nRC_GXsfl_52 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_52"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_52_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_52_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_52_idx = GetPar( "sGXsfl_52_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid2_newrow( ) ;
         /* End function gxnrGrid2_newrow_invoke */
      }

      protected void gxgrGrid2_refresh_invoke( )
      {
         A20InvoiceId = (int)(Math.Round(NumberUtil.Val( GetPar( "InvoiceId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid2_refresh( A20InvoiceId) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid2_refresh_invoke */
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
         PA3Q2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3Q2( ) ;
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1853160), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1853160), false, true);
         context.AddJavascriptSource("calendar-en.js", "?"+context.GetBuildNumber( 1853160), false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpinvoicedetails.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A20InvoiceId,6,0))}, new string[] {"InvoiceId"}) +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         }
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_INVOICEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A20InvoiceId), "ZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_36", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_36), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_52", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_52), 8, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, "INVOICEDETAILISWHOLESALE", A98InvoiceDetailIsWholesale);
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "</form>") ;
         }
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
            WE3Q2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3Q2( ) ;
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
         return formatLink("wpinvoicedetails.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A20InvoiceId,6,0))}, new string[] {"InvoiceId"})  ;
      }

      public override string GetPgmname( )
      {
         return "WPInvoiceDetails" ;
      }

      public override string GetPgmdesc( )
      {
         return "Details of Sale" ;
      }

      protected void WB3Q0( )
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Right", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttTicket_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(36), 2, 0)+","+"null"+");", "Ticket", bttTicket_Jsonclick, 7, "View Ticket", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e113q1_client"+"'", TempTags, "", 2, "HLP_WPInvoiceDetails.htm");
            GxWebStd.gx_div_end( context, "Right", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            context.WriteHtmlText( "<hr/>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Sale's Info", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-03", 0, "", 1, 1, 0, 0, "HLP_WPInvoiceDetails.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            context.WriteHtmlText( "<hr/>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtInvoiceId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtInvoiceId_Internalname, "Sale Nro", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtInvoiceId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A20InvoiceId), 6, 0, ".", "")), StringUtil.LTrim( ((edtInvoiceId_Enabled!=0) ? context.localUtil.Format( (decimal)(A20InvoiceId), "ZZZZZ9") : context.localUtil.Format( (decimal)(A20InvoiceId), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtInvoiceId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtInvoiceId_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_WPInvoiceDetails.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtInvoiceTotalReceivable_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtInvoiceTotalReceivable_Internalname, "Total Receivable", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtInvoiceTotalReceivable_Internalname, StringUtil.LTrim( StringUtil.NToC( A80InvoiceTotalReceivable, 18, 2, ".", "")), StringUtil.LTrim( ((edtInvoiceTotalReceivable_Enabled!=0) ? context.localUtil.Format( A80InvoiceTotalReceivable, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A80InvoiceTotalReceivable, "ZZZZZZZZZZZZZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtInvoiceTotalReceivable_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtInvoiceTotalReceivable_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Price", "right", false, "", "HLP_WPInvoiceDetails.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtInvoiceCreatedDate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtInvoiceCreatedDate_Internalname, "Date", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtInvoiceCreatedDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtInvoiceCreatedDate_Internalname, context.localUtil.Format(A38InvoiceCreatedDate, "99/99/99"), context.localUtil.Format( A38InvoiceCreatedDate, "99/99/99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtInvoiceCreatedDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtInvoiceCreatedDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_WPInvoiceDetails.htm");
            GxWebStd.gx_bitmap( context, edtInvoiceCreatedDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtInvoiceCreatedDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WPInvoiceDetails.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            context.WriteHtmlText( "<hr/>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Details", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-03", 0, "", 1, 1, 0, 0, "HLP_WPInvoiceDetails.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            context.WriteHtmlText( "<hr/>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl36( ) ;
         }
         if ( wbEnd == 36 )
         {
            wbEnd = 0;
            nRC_GXsfl_36 = (int)(nGXsfl_36_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            context.WriteHtmlText( "<hr/>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Payment Methods", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-03", 0, "", 1, 1, 0, 0, "HLP_WPInvoiceDetails.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            context.WriteHtmlText( "<hr/>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid2Container.SetWrapped(nGXWrapped);
            StartGridControl52( ) ;
         }
         if ( wbEnd == 52 )
         {
            wbEnd = 0;
            nRC_GXsfl_52 = (int)(nGXsfl_52_idx-1);
            if ( Grid2Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid2Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid2", Grid2Container, subGrid2_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid2ContainerData", Grid2Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid2ContainerData"+"V", Grid2Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid2ContainerData"+"V"+"\" value='"+Grid2Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 36 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         if ( wbEnd == 52 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid2Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid2Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid2", Grid2Container, subGrid2_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid2ContainerData", Grid2Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid2ContainerData"+"V", Grid2Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid2ContainerData"+"V"+"\" value='"+Grid2Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START3Q2( )
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
            Form.Meta.addItem("description", "Details of Sale", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3Q0( ) ;
      }

      protected void WS3Q2( )
      {
         START3Q2( ) ;
         EVT3Q2( ) ;
      }

      protected void EVT3Q2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRID2.LOAD") == 0 )
                           {
                              nGXsfl_52_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_52_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_52_idx), 4, 0), 4, "0");
                              SubsflControlProps_523( ) ;
                              A115PaymentMethodId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPaymentMethodId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              n115PaymentMethodId = false;
                              A116PaymentMethodDescription = cgiGet( edtPaymentMethodDescription_Internalname);
                              A120InvoicePaymentMethodImport = context.localUtil.CToN( cgiGet( edtInvoicePaymentMethodImport_Internalname), ".", ",");
                              n120InvoicePaymentMethodImport = false;
                              A133InvoicePaymentMethodDiscountIm = context.localUtil.CToN( cgiGet( edtInvoicePaymentMethodDiscountIm_Internalname), ".", ",");
                              n133InvoicePaymentMethodDiscountIm = false;
                              A132InvoicePaymentMethodRechargeIm = context.localUtil.CToN( cgiGet( edtInvoicePaymentMethodRechargeIm_Internalname), ".", ",");
                              n132InvoicePaymentMethodRechargeIm = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "GRID2.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E123Q3 ();
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
                           else if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRID1.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_36_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_36_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_36_idx), 4, 0), 4, "0");
                              SubsflControlProps_362( ) ;
                              A15ProductId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtProductId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A55ProductCode = cgiGet( edtProductCode_Internalname);
                              n55ProductCode = false;
                              A16ProductName = cgiGet( edtProductName_Internalname);
                              A26InvoiceDetailQuantity = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtInvoiceDetailQuantity_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A65InvoiceDetailHistoricPrice = context.localUtil.CToN( cgiGet( edtInvoiceDetailHistoricPrice_Internalname), ".", ",");
                              cmbavType.Name = cmbavType_Internalname;
                              cmbavType.CurrentValue = cgiGet( cmbavType_Internalname);
                              AV8Type = cgiGet( cmbavType_Internalname);
                              AssignAttri("", false, cmbavType_Internalname, AV8Type);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E133Q2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID1.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E143Q2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
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

      protected void WE3Q2( )
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

      protected void PA3Q2( )
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
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_362( ) ;
         while ( nGXsfl_36_idx <= nRC_GXsfl_36 )
         {
            sendrow_362( ) ;
            nGXsfl_36_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_36_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_36_idx+1);
            sGXsfl_36_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_36_idx), 4, 0), 4, "0");
            SubsflControlProps_362( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxnrGrid2_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_523( ) ;
         while ( nGXsfl_52_idx <= nRC_GXsfl_52 )
         {
            sendrow_523( ) ;
            nGXsfl_52_idx = ((subGrid2_Islastpage==1)&&(nGXsfl_52_idx+1>subGrid2_fnc_Recordsperpage( )) ? 1 : nGXsfl_52_idx+1);
            sGXsfl_52_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_52_idx), 4, 0), 4, "0");
            SubsflControlProps_523( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid2Container)) ;
         /* End function gxnrGrid2_newrow */
      }

      protected void gxgrGrid1_refresh( int A20InvoiceId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF3Q2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void gxgrGrid2_refresh( int A20InvoiceId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID2_nCurrentRecord = 0;
         RF3Q3( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid2_refresh */
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF3Q2( ) ;
         RF3Q3( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         cmbavType.Enabled = 0;
         AssignProp("", false, cmbavType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavType.Enabled), 5, 0), !bGXsfl_36_Refreshing);
      }

      protected void RF3Q2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 36;
         nGXsfl_36_idx = 1;
         sGXsfl_36_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_36_idx), 4, 0), 4, "0");
         SubsflControlProps_362( ) ;
         bGXsfl_36_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "PromptGrid");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_362( ) ;
            /* Using cursor H003Q5 */
            pr_default.execute(0, new Object[] {A20InvoiceId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A98InvoiceDetailIsWholesale = H003Q5_A98InvoiceDetailIsWholesale[0];
               A65InvoiceDetailHistoricPrice = H003Q5_A65InvoiceDetailHistoricPrice[0];
               A26InvoiceDetailQuantity = H003Q5_A26InvoiceDetailQuantity[0];
               A16ProductName = H003Q5_A16ProductName[0];
               A55ProductCode = H003Q5_A55ProductCode[0];
               n55ProductCode = H003Q5_n55ProductCode[0];
               A15ProductId = H003Q5_A15ProductId[0];
               A80InvoiceTotalReceivable = H003Q5_A80InvoiceTotalReceivable[0];
               n80InvoiceTotalReceivable = H003Q5_n80InvoiceTotalReceivable[0];
               AssignAttri("", false, "A80InvoiceTotalReceivable", StringUtil.LTrimStr( A80InvoiceTotalReceivable, 18, 2));
               A16ProductName = H003Q5_A16ProductName[0];
               A55ProductCode = H003Q5_A55ProductCode[0];
               n55ProductCode = H003Q5_n55ProductCode[0];
               A80InvoiceTotalReceivable = H003Q5_A80InvoiceTotalReceivable[0];
               n80InvoiceTotalReceivable = H003Q5_n80InvoiceTotalReceivable[0];
               AssignAttri("", false, "A80InvoiceTotalReceivable", StringUtil.LTrimStr( A80InvoiceTotalReceivable, 18, 2));
               E143Q2 ();
               pr_default.readNext(0);
            }
            pr_default.close(0);
            wbEnd = 36;
            WB3Q0( ) ;
         }
         bGXsfl_36_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3Q2( )
      {
      }

      protected void RF3Q3( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid2Container.ClearRows();
         }
         wbStart = 52;
         nGXsfl_52_idx = 1;
         sGXsfl_52_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_52_idx), 4, 0), 4, "0");
         SubsflControlProps_523( ) ;
         bGXsfl_52_Refreshing = true;
         Grid2Container.AddObjectProperty("GridName", "Grid2");
         Grid2Container.AddObjectProperty("CmpContext", "");
         Grid2Container.AddObjectProperty("InMasterPage", "false");
         Grid2Container.AddObjectProperty("Class", "PromptGrid");
         Grid2Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid2Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid2Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Backcolorstyle), 1, 0, ".", "")));
         Grid2Container.PageSize = subGrid2_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_523( ) ;
            /* Using cursor H003Q6 */
            pr_default.execute(1, new Object[] {A20InvoiceId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A132InvoicePaymentMethodRechargeIm = H003Q6_A132InvoicePaymentMethodRechargeIm[0];
               n132InvoicePaymentMethodRechargeIm = H003Q6_n132InvoicePaymentMethodRechargeIm[0];
               A133InvoicePaymentMethodDiscountIm = H003Q6_A133InvoicePaymentMethodDiscountIm[0];
               n133InvoicePaymentMethodDiscountIm = H003Q6_n133InvoicePaymentMethodDiscountIm[0];
               A120InvoicePaymentMethodImport = H003Q6_A120InvoicePaymentMethodImport[0];
               n120InvoicePaymentMethodImport = H003Q6_n120InvoicePaymentMethodImport[0];
               A116PaymentMethodDescription = H003Q6_A116PaymentMethodDescription[0];
               A115PaymentMethodId = H003Q6_A115PaymentMethodId[0];
               n115PaymentMethodId = H003Q6_n115PaymentMethodId[0];
               A116PaymentMethodDescription = H003Q6_A116PaymentMethodDescription[0];
               E123Q3 ();
               pr_default.readNext(1);
            }
            pr_default.close(1);
            wbEnd = 52;
            WB3Q0( ) ;
         }
         bGXsfl_52_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3Q3( )
      {
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected int subGrid2_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid2_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid2_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGrid2_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         cmbavType.Enabled = 0;
         AssignProp("", false, cmbavType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavType.Enabled), 5, 0), !bGXsfl_36_Refreshing);
         /* Using cursor H003Q7 */
         pr_default.execute(2, new Object[] {A20InvoiceId});
         A38InvoiceCreatedDate = H003Q7_A38InvoiceCreatedDate[0];
         AssignAttri("", false, "A38InvoiceCreatedDate", context.localUtil.Format(A38InvoiceCreatedDate, "99/99/99"));
         pr_default.close(2);
         /* Using cursor H003Q11 */
         pr_default.execute(3, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            A80InvoiceTotalReceivable = H003Q11_A80InvoiceTotalReceivable[0];
            n80InvoiceTotalReceivable = H003Q11_n80InvoiceTotalReceivable[0];
            AssignAttri("", false, "A80InvoiceTotalReceivable", StringUtil.LTrimStr( A80InvoiceTotalReceivable, 18, 2));
         }
         else
         {
            A80InvoiceTotalReceivable = 0;
            n80InvoiceTotalReceivable = false;
            AssignAttri("", false, "A80InvoiceTotalReceivable", StringUtil.LTrimStr( A80InvoiceTotalReceivable, 18, 2));
         }
         pr_default.close(3);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3Q0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E133Q2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_36 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_36"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_52 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_52"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            A80InvoiceTotalReceivable = context.localUtil.CToN( cgiGet( edtInvoiceTotalReceivable_Internalname), ".", ",");
            n80InvoiceTotalReceivable = false;
            AssignAttri("", false, "A80InvoiceTotalReceivable", StringUtil.LTrimStr( A80InvoiceTotalReceivable, 18, 2));
            A38InvoiceCreatedDate = context.localUtil.CToD( cgiGet( edtInvoiceCreatedDate_Internalname), 1);
            AssignAttri("", false, "A38InvoiceCreatedDate", context.localUtil.Format(A38InvoiceCreatedDate, "99/99/99"));
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
         E133Q2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E133Q2( )
      {
         /* Start Routine */
         returnInSub = false;
         new getcontext(context ).execute( out  AV5Context, ref  AV6AllOk) ;
         AssignAttri("", false, "AV6AllOk", AV6AllOk);
         if ( ! AV6AllOk )
         {
            AV7WebSession.Set("SecLogIn", "Error");
            CallWebObject(formatLink("wplogin.aspx") );
            context.wjLocDisableFrm = 1;
         }
      }

      private void E143Q2( )
      {
         /* Grid1_Load Routine */
         returnInSub = false;
         if ( A98InvoiceDetailIsWholesale )
         {
            AV8Type = "Wholesale";
            AssignAttri("", false, cmbavType_Internalname, AV8Type);
         }
         else
         {
            AV8Type = "Retail";
            AssignAttri("", false, cmbavType_Internalname, AV8Type);
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 36;
         }
         sendrow_362( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_36_Refreshing )
         {
            DoAjaxLoad(36, Grid1Row);
         }
         /*  Sending Event outputs  */
         cmbavType.CurrentValue = StringUtil.RTrim( AV8Type);
      }

      private void E123Q3( )
      {
         /* Grid2_Load Routine */
         returnInSub = false;
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 52;
         }
         sendrow_523( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_52_Refreshing )
         {
            DoAjaxLoad(52, Grid2Row);
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A20InvoiceId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "A20InvoiceId", StringUtil.LTrimStr( (decimal)(A20InvoiceId), 6, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_INVOICEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A20InvoiceId), "ZZZZZ9"), context));
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
         PA3Q2( ) ;
         WS3Q2( ) ;
         WE3Q2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202411210565514", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("messages.eng.js", "?"+GetCacheInvalidationToken( ), false, true);
            context.AddJavascriptSource("gxdec.js", "?"+context.GetBuildNumber( 1853160), false, true);
            context.AddJavascriptSource("wpinvoicedetails.js", "?202411210565514", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_362( )
      {
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_36_idx;
         edtProductCode_Internalname = "PRODUCTCODE_"+sGXsfl_36_idx;
         edtProductName_Internalname = "PRODUCTNAME_"+sGXsfl_36_idx;
         edtInvoiceDetailQuantity_Internalname = "INVOICEDETAILQUANTITY_"+sGXsfl_36_idx;
         edtInvoiceDetailHistoricPrice_Internalname = "INVOICEDETAILHISTORICPRICE_"+sGXsfl_36_idx;
         cmbavType_Internalname = "vTYPE_"+sGXsfl_36_idx;
      }

      protected void SubsflControlProps_fel_362( )
      {
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_36_fel_idx;
         edtProductCode_Internalname = "PRODUCTCODE_"+sGXsfl_36_fel_idx;
         edtProductName_Internalname = "PRODUCTNAME_"+sGXsfl_36_fel_idx;
         edtInvoiceDetailQuantity_Internalname = "INVOICEDETAILQUANTITY_"+sGXsfl_36_fel_idx;
         edtInvoiceDetailHistoricPrice_Internalname = "INVOICEDETAILHISTORICPRICE_"+sGXsfl_36_fel_idx;
         cmbavType_Internalname = "vTYPE_"+sGXsfl_36_fel_idx;
      }

      protected void sendrow_362( )
      {
         SubsflControlProps_362( ) ;
         WB3Q0( ) ;
         Grid1Row = GXWebRow.GetNew(context,Grid1Container);
         if ( subGrid1_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGrid1_Backstyle = 0;
            if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
            {
               subGrid1_Linesclass = subGrid1_Class+"Odd";
            }
         }
         else if ( subGrid1_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGrid1_Backstyle = 0;
            subGrid1_Backcolor = subGrid1_Allbackcolor;
            if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
            {
               subGrid1_Linesclass = subGrid1_Class+"Uniform";
            }
         }
         else if ( subGrid1_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGrid1_Backstyle = 1;
            if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
            {
               subGrid1_Linesclass = subGrid1_Class+"Odd";
            }
            subGrid1_Backcolor = (int)(0x0);
         }
         else if ( subGrid1_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGrid1_Backstyle = 1;
            if ( ((int)((nGXsfl_36_idx) % (2))) == 0 )
            {
               subGrid1_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Even";
               }
            }
            else
            {
               subGrid1_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
         }
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr ") ;
            context.WriteHtmlText( " class=\""+"PromptGrid"+"\" style=\""+""+"\"") ;
            context.WriteHtmlText( " gxrow=\""+sGXsfl_36_idx+"\">") ;
         }
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A15ProductId), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)36,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductCode_Internalname,(string)A55ProductCode,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductCode_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)36,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusUnanimo\\Code",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductName_Internalname,(string)A16ProductName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)36,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInvoiceDetailQuantity_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A26InvoiceDetailQuantity), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A26InvoiceDetailQuantity), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInvoiceDetailQuantity_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)36,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInvoiceDetailHistoricPrice_Internalname,StringUtil.LTrim( StringUtil.NToC( A65InvoiceDetailHistoricPrice, 18, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A65InvoiceDetailHistoricPrice, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInvoiceDetailHistoricPrice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)36,(short)0,(short)-1,(short)0,(bool)true,(string)"Price",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         if ( ( cmbavType.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "vTYPE_" + sGXsfl_36_idx;
            cmbavType.Name = GXCCtl;
            cmbavType.WebTags = "";
            cmbavType.addItem("Wholesale", "Wholesale", 0);
            cmbavType.addItem("Retail", "Retail", 0);
            if ( cmbavType.ItemCount > 0 )
            {
               AV8Type = cmbavType.getValidValue(AV8Type);
               AssignAttri("", false, cmbavType_Internalname, AV8Type);
            }
         }
         /* ComboBox */
         Grid1Row.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavType,(string)cmbavType_Internalname,StringUtil.RTrim( AV8Type),(short)1,(string)cmbavType_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"Type of Sale",(short)-1,cmbavType.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"",(string)"",(string)"",(string)"",(bool)true,(short)0});
         cmbavType.CurrentValue = StringUtil.RTrim( AV8Type);
         AssignProp("", false, cmbavType_Internalname, "Values", (string)(cmbavType.ToJavascriptSource()), !bGXsfl_36_Refreshing);
         send_integrity_lvl_hashes3Q2( ) ;
         Grid1Container.AddRow(Grid1Row);
         nGXsfl_36_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_36_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_36_idx+1);
         sGXsfl_36_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_36_idx), 4, 0), 4, "0");
         SubsflControlProps_362( ) ;
         /* End function sendrow_362 */
      }

      protected void SubsflControlProps_523( )
      {
         edtPaymentMethodId_Internalname = "PAYMENTMETHODID_"+sGXsfl_52_idx;
         edtPaymentMethodDescription_Internalname = "PAYMENTMETHODDESCRIPTION_"+sGXsfl_52_idx;
         edtInvoicePaymentMethodImport_Internalname = "INVOICEPAYMENTMETHODIMPORT_"+sGXsfl_52_idx;
         edtInvoicePaymentMethodDiscountIm_Internalname = "INVOICEPAYMENTMETHODDISCOUNTIM_"+sGXsfl_52_idx;
         edtInvoicePaymentMethodRechargeIm_Internalname = "INVOICEPAYMENTMETHODRECHARGEIM_"+sGXsfl_52_idx;
      }

      protected void SubsflControlProps_fel_523( )
      {
         edtPaymentMethodId_Internalname = "PAYMENTMETHODID_"+sGXsfl_52_fel_idx;
         edtPaymentMethodDescription_Internalname = "PAYMENTMETHODDESCRIPTION_"+sGXsfl_52_fel_idx;
         edtInvoicePaymentMethodImport_Internalname = "INVOICEPAYMENTMETHODIMPORT_"+sGXsfl_52_fel_idx;
         edtInvoicePaymentMethodDiscountIm_Internalname = "INVOICEPAYMENTMETHODDISCOUNTIM_"+sGXsfl_52_fel_idx;
         edtInvoicePaymentMethodRechargeIm_Internalname = "INVOICEPAYMENTMETHODRECHARGEIM_"+sGXsfl_52_fel_idx;
      }

      protected void sendrow_523( )
      {
         SubsflControlProps_523( ) ;
         WB3Q0( ) ;
         Grid2Row = GXWebRow.GetNew(context,Grid2Container);
         if ( subGrid2_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGrid2_Backstyle = 0;
            if ( StringUtil.StrCmp(subGrid2_Class, "") != 0 )
            {
               subGrid2_Linesclass = subGrid2_Class+"Odd";
            }
         }
         else if ( subGrid2_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGrid2_Backstyle = 0;
            subGrid2_Backcolor = subGrid2_Allbackcolor;
            if ( StringUtil.StrCmp(subGrid2_Class, "") != 0 )
            {
               subGrid2_Linesclass = subGrid2_Class+"Uniform";
            }
         }
         else if ( subGrid2_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGrid2_Backstyle = 1;
            if ( StringUtil.StrCmp(subGrid2_Class, "") != 0 )
            {
               subGrid2_Linesclass = subGrid2_Class+"Odd";
            }
            subGrid2_Backcolor = (int)(0x0);
         }
         else if ( subGrid2_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGrid2_Backstyle = 1;
            if ( ((int)((nGXsfl_52_idx) % (2))) == 0 )
            {
               subGrid2_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGrid2_Class, "") != 0 )
               {
                  subGrid2_Linesclass = subGrid2_Class+"Even";
               }
            }
            else
            {
               subGrid2_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGrid2_Class, "") != 0 )
               {
                  subGrid2_Linesclass = subGrid2_Class+"Odd";
               }
            }
         }
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr ") ;
            context.WriteHtmlText( " class=\""+"PromptGrid"+"\" style=\""+""+"\"") ;
            context.WriteHtmlText( " gxrow=\""+sGXsfl_52_idx+"\">") ;
         }
         /* Subfile cell */
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPaymentMethodId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A115PaymentMethodId), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A115PaymentMethodId), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPaymentMethodId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)52,(short)0,(short)-1,(short)0,(bool)false,(string)"Id",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPaymentMethodDescription_Internalname,(string)A116PaymentMethodDescription,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPaymentMethodDescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)52,(short)0,(short)-1,(short)-1,(bool)false,(string)"GeneXusUnanimo\\Description",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInvoicePaymentMethodImport_Internalname,StringUtil.LTrim( StringUtil.NToC( A120InvoicePaymentMethodImport, 18, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A120InvoicePaymentMethodImport, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInvoicePaymentMethodImport_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)52,(short)0,(short)-1,(short)0,(bool)false,(string)"Price",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInvoicePaymentMethodDiscountIm_Internalname,StringUtil.LTrim( StringUtil.NToC( A133InvoicePaymentMethodDiscountIm, 18, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A133InvoicePaymentMethodDiscountIm, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInvoicePaymentMethodDiscountIm_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)52,(short)0,(short)-1,(short)0,(bool)false,(string)"Price",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInvoicePaymentMethodRechargeIm_Internalname,StringUtil.LTrim( StringUtil.NToC( A132InvoicePaymentMethodRechargeIm, 18, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A132InvoicePaymentMethodRechargeIm, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInvoicePaymentMethodRechargeIm_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)52,(short)0,(short)-1,(short)0,(bool)false,(string)"Price",(string)"right",(bool)false,(string)""});
         send_integrity_lvl_hashes3Q3( ) ;
         Grid2Container.AddRow(Grid2Row);
         nGXsfl_52_idx = ((subGrid2_Islastpage==1)&&(nGXsfl_52_idx+1>subGrid2_fnc_Recordsperpage( )) ? 1 : nGXsfl_52_idx+1);
         sGXsfl_52_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_52_idx), 4, 0), 4, "0");
         SubsflControlProps_523( ) ;
         /* End function sendrow_523 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "vTYPE_" + sGXsfl_36_idx;
         cmbavType.Name = GXCCtl;
         cmbavType.WebTags = "";
         cmbavType.addItem("Wholesale", "Wholesale", 0);
         cmbavType.addItem("Retail", "Retail", 0);
         if ( cmbavType.ItemCount > 0 )
         {
            AV8Type = cmbavType.getValidValue(AV8Type);
            AssignAttri("", false, cmbavType_Internalname, AV8Type);
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl36( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"36\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid1_Backcolorstyle == 0 )
            {
               subGrid1_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid1_Class) > 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Title";
               }
            }
            else
            {
               subGrid1_Titlebackstyle = 1;
               if ( subGrid1_Backcolorstyle == 1 )
               {
                  subGrid1_Titlebackcolor = subGrid1_Allbackcolor;
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Product Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Code") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Product") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Quantity") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Price") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Sale Type") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Grid1Container.AddObjectProperty("GridName", "Grid1");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               Grid1Container = new GXWebGrid( context);
            }
            else
            {
               Grid1Container.Clear();
            }
            Grid1Container.SetWrapped(nGXWrapped);
            Grid1Container.AddObjectProperty("GridName", "Grid1");
            Grid1Container.AddObjectProperty("Header", subGrid1_Header);
            Grid1Container.AddObjectProperty("Class", "PromptGrid");
            Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("CmpContext", "");
            Grid1Container.AddObjectProperty("InMasterPage", "false");
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A55ProductCode));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( A16ProductName));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A26InvoiceDetailQuantity), 6, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A65InvoiceDetailHistoricPrice, 18, 2, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( AV8Type));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavType.Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectedindex), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowselection), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectioncolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowhovering), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Hoveringcolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowcollapsing), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void StartGridControl52( )
      {
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid2Container"+"DivS\" data-gxgridid=\"52\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid2_Internalname, subGrid2_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid2_Backcolorstyle == 0 )
            {
               subGrid2_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid2_Class) > 0 )
               {
                  subGrid2_Linesclass = subGrid2_Class+"Title";
               }
            }
            else
            {
               subGrid2_Titlebackstyle = 1;
               if ( subGrid2_Backcolorstyle == 1 )
               {
                  subGrid2_Titlebackcolor = subGrid2_Allbackcolor;
                  if ( StringUtil.Len( subGrid2_Class) > 0 )
                  {
                     subGrid2_Linesclass = subGrid2_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid2_Class) > 0 )
                  {
                     subGrid2_Linesclass = subGrid2_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Payment Method Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Method") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Import") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Discount") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Recharge") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Grid2Container.AddObjectProperty("GridName", "Grid2");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               Grid2Container = new GXWebGrid( context);
            }
            else
            {
               Grid2Container.Clear();
            }
            Grid2Container.SetWrapped(nGXWrapped);
            Grid2Container.AddObjectProperty("GridName", "Grid2");
            Grid2Container.AddObjectProperty("Header", subGrid2_Header);
            Grid2Container.AddObjectProperty("Class", "PromptGrid");
            Grid2Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid2Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid2Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Backcolorstyle), 1, 0, ".", "")));
            Grid2Container.AddObjectProperty("CmpContext", "");
            Grid2Container.AddObjectProperty("InMasterPage", "false");
            Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid2Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A115PaymentMethodId), 6, 0, ".", ""))));
            Grid2Container.AddColumnProperties(Grid2Column);
            Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid2Column.AddObjectProperty("Value", GXUtil.ValueEncode( A116PaymentMethodDescription));
            Grid2Container.AddColumnProperties(Grid2Column);
            Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid2Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A120InvoicePaymentMethodImport, 18, 2, ".", ""))));
            Grid2Container.AddColumnProperties(Grid2Column);
            Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid2Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A133InvoicePaymentMethodDiscountIm, 18, 2, ".", ""))));
            Grid2Container.AddColumnProperties(Grid2Column);
            Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid2Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A132InvoicePaymentMethodRechargeIm, 18, 2, ".", ""))));
            Grid2Container.AddColumnProperties(Grid2Column);
            Grid2Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Selectedindex), 4, 0, ".", "")));
            Grid2Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Allowselection), 1, 0, ".", "")));
            Grid2Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Selectioncolor), 9, 0, ".", "")));
            Grid2Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Allowhovering), 1, 0, ".", "")));
            Grid2Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Hoveringcolor), 9, 0, ".", "")));
            Grid2Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Allowcollapsing), 1, 0, ".", "")));
            Grid2Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         bttTicket_Internalname = "TICKET";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtInvoiceId_Internalname = "INVOICEID";
         edtInvoiceTotalReceivable_Internalname = "INVOICETOTALRECEIVABLE";
         edtInvoiceCreatedDate_Internalname = "INVOICECREATEDDATE";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         edtProductId_Internalname = "PRODUCTID";
         edtProductCode_Internalname = "PRODUCTCODE";
         edtProductName_Internalname = "PRODUCTNAME";
         edtInvoiceDetailQuantity_Internalname = "INVOICEDETAILQUANTITY";
         edtInvoiceDetailHistoricPrice_Internalname = "INVOICEDETAILHISTORICPRICE";
         cmbavType_Internalname = "vTYPE";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtPaymentMethodId_Internalname = "PAYMENTMETHODID";
         edtPaymentMethodDescription_Internalname = "PAYMENTMETHODDESCRIPTION";
         edtInvoicePaymentMethodImport_Internalname = "INVOICEPAYMENTMETHODIMPORT";
         edtInvoicePaymentMethodDiscountIm_Internalname = "INVOICEPAYMENTMETHODDISCOUNTIM";
         edtInvoicePaymentMethodRechargeIm_Internalname = "INVOICEPAYMENTMETHODRECHARGEIM";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGrid1_Internalname = "GRID1";
         subGrid2_Internalname = "GRID2";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("mtaKB", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid2_Allowcollapsing = 0;
         subGrid2_Allowselection = 0;
         subGrid2_Header = "";
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         subGrid1_Header = "";
         edtInvoicePaymentMethodRechargeIm_Jsonclick = "";
         edtInvoicePaymentMethodDiscountIm_Jsonclick = "";
         edtInvoicePaymentMethodImport_Jsonclick = "";
         edtPaymentMethodDescription_Jsonclick = "";
         edtPaymentMethodId_Jsonclick = "";
         subGrid2_Class = "PromptGrid";
         subGrid2_Backcolorstyle = 0;
         cmbavType_Jsonclick = "";
         cmbavType.Enabled = 0;
         edtInvoiceDetailHistoricPrice_Jsonclick = "";
         edtInvoiceDetailQuantity_Jsonclick = "";
         edtProductName_Jsonclick = "";
         edtProductCode_Jsonclick = "";
         edtProductId_Jsonclick = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtInvoiceCreatedDate_Jsonclick = "";
         edtInvoiceCreatedDate_Enabled = 0;
         edtInvoiceTotalReceivable_Jsonclick = "";
         edtInvoiceTotalReceivable_Enabled = 0;
         edtInvoiceId_Jsonclick = "";
         edtInvoiceId_Enabled = 0;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Details of Sale";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'GRID2_nFirstRecordOnPage'},{av:'GRID2_nEOF'},{av:'A20InvoiceId',fld:'INVOICEID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("GRID1.LOAD","{handler:'E143Q2',iparms:[{av:'A98InvoiceDetailIsWholesale',fld:'INVOICEDETAILISWHOLESALE',pic:''}]");
         setEventMetadata("GRID1.LOAD",",oparms:[{av:'cmbavType'},{av:'AV8Type',fld:'vTYPE',pic:''}]}");
         setEventMetadata("'TICKET'","{handler:'E113Q1',iparms:[{av:'A20InvoiceId',fld:'INVOICEID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("'TICKET'",",oparms:[]}");
         setEventMetadata("VALID_INVOICEID","{handler:'Valid_Invoiceid',iparms:[]");
         setEventMetadata("VALID_INVOICEID",",oparms:[]}");
         setEventMetadata("VALID_PRODUCTID","{handler:'Valid_Productid',iparms:[]");
         setEventMetadata("VALID_PRODUCTID",",oparms:[]}");
         setEventMetadata("VALIDV_TYPE","{handler:'Validv_Type',iparms:[]");
         setEventMetadata("VALIDV_TYPE",",oparms:[]}");
         setEventMetadata("VALID_PAYMENTMETHODID","{handler:'Valid_Paymentmethodid',iparms:[]");
         setEventMetadata("VALID_PAYMENTMETHODID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Invoicepaymentmethodrechargeim',iparms:[]");
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
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttTicket_Jsonclick = "";
         lblTextblock3_Jsonclick = "";
         A38InvoiceCreatedDate = DateTime.MinValue;
         lblTextblock1_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         lblTextblock2_Jsonclick = "";
         Grid2Container = new GXWebGrid( context);
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A116PaymentMethodDescription = "";
         A55ProductCode = "";
         A16ProductName = "";
         AV8Type = "";
         scmdbuf = "";
         H003Q5_A25InvoiceDetailId = new int[1] ;
         H003Q5_A20InvoiceId = new int[1] ;
         H003Q5_A98InvoiceDetailIsWholesale = new bool[] {false} ;
         H003Q5_A38InvoiceCreatedDate = new DateTime[] {DateTime.MinValue} ;
         H003Q5_A65InvoiceDetailHistoricPrice = new decimal[1] ;
         H003Q5_A26InvoiceDetailQuantity = new int[1] ;
         H003Q5_A16ProductName = new string[] {""} ;
         H003Q5_A55ProductCode = new string[] {""} ;
         H003Q5_n55ProductCode = new bool[] {false} ;
         H003Q5_A15ProductId = new int[1] ;
         H003Q5_A80InvoiceTotalReceivable = new decimal[1] ;
         H003Q5_n80InvoiceTotalReceivable = new bool[] {false} ;
         H003Q6_A118InvoicePaymentMethodId = new int[1] ;
         H003Q6_A20InvoiceId = new int[1] ;
         H003Q6_A132InvoicePaymentMethodRechargeIm = new decimal[1] ;
         H003Q6_n132InvoicePaymentMethodRechargeIm = new bool[] {false} ;
         H003Q6_A133InvoicePaymentMethodDiscountIm = new decimal[1] ;
         H003Q6_n133InvoicePaymentMethodDiscountIm = new bool[] {false} ;
         H003Q6_A120InvoicePaymentMethodImport = new decimal[1] ;
         H003Q6_n120InvoicePaymentMethodImport = new bool[] {false} ;
         H003Q6_A116PaymentMethodDescription = new string[] {""} ;
         H003Q6_A115PaymentMethodId = new int[1] ;
         H003Q6_n115PaymentMethodId = new bool[] {false} ;
         H003Q7_A38InvoiceCreatedDate = new DateTime[] {DateTime.MinValue} ;
         H003Q11_A80InvoiceTotalReceivable = new decimal[1] ;
         H003Q11_n80InvoiceTotalReceivable = new bool[] {false} ;
         AV5Context = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         AV7WebSession = context.GetSession();
         Grid1Row = new GXWebRow();
         Grid2Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         subGrid2_Linesclass = "";
         Grid1Column = new GXWebColumn();
         Grid2Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpinvoicedetails__default(),
            new Object[][] {
                new Object[] {
               H003Q5_A25InvoiceDetailId, H003Q5_A20InvoiceId, H003Q5_A98InvoiceDetailIsWholesale, H003Q5_A38InvoiceCreatedDate, H003Q5_A65InvoiceDetailHistoricPrice, H003Q5_A26InvoiceDetailQuantity, H003Q5_A16ProductName, H003Q5_A55ProductCode, H003Q5_n55ProductCode, H003Q5_A15ProductId,
               H003Q5_A80InvoiceTotalReceivable, H003Q5_n80InvoiceTotalReceivable
               }
               , new Object[] {
               H003Q6_A118InvoicePaymentMethodId, H003Q6_A20InvoiceId, H003Q6_A132InvoicePaymentMethodRechargeIm, H003Q6_n132InvoicePaymentMethodRechargeIm, H003Q6_A133InvoicePaymentMethodDiscountIm, H003Q6_n133InvoicePaymentMethodDiscountIm, H003Q6_A120InvoicePaymentMethodImport, H003Q6_n120InvoicePaymentMethodImport, H003Q6_A116PaymentMethodDescription, H003Q6_A115PaymentMethodId,
               H003Q6_n115PaymentMethodId
               }
               , new Object[] {
               H003Q7_A38InvoiceCreatedDate
               }
               , new Object[] {
               H003Q11_A80InvoiceTotalReceivable, H003Q11_n80InvoiceTotalReceivable
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         cmbavType.Enabled = 0;
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid1_Backcolorstyle ;
      private short subGrid2_Backcolorstyle ;
      private short subGrid1_Backstyle ;
      private short subGrid2_Backstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private short subGrid2_Titlebackstyle ;
      private short subGrid2_Allowselection ;
      private short subGrid2_Allowhovering ;
      private short subGrid2_Allowcollapsing ;
      private short subGrid2_Collapsed ;
      private short GRID1_nEOF ;
      private short GRID2_nEOF ;
      private int A20InvoiceId ;
      private int wcpOA20InvoiceId ;
      private int nRC_GXsfl_36 ;
      private int nRC_GXsfl_52 ;
      private int nGXsfl_36_idx=1 ;
      private int nGXsfl_52_idx=1 ;
      private int edtInvoiceId_Enabled ;
      private int edtInvoiceTotalReceivable_Enabled ;
      private int edtInvoiceCreatedDate_Enabled ;
      private int A115PaymentMethodId ;
      private int A15ProductId ;
      private int A26InvoiceDetailQuantity ;
      private int subGrid1_Islastpage ;
      private int subGrid2_Islastpage ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid2_Backcolor ;
      private int subGrid2_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private int subGrid2_Titlebackcolor ;
      private int subGrid2_Selectedindex ;
      private int subGrid2_Selectioncolor ;
      private int subGrid2_Hoveringcolor ;
      private long GRID1_nCurrentRecord ;
      private long GRID2_nCurrentRecord ;
      private long GRID1_nFirstRecordOnPage ;
      private long GRID2_nFirstRecordOnPage ;
      private decimal A80InvoiceTotalReceivable ;
      private decimal A120InvoicePaymentMethodImport ;
      private decimal A133InvoicePaymentMethodDiscountIm ;
      private decimal A132InvoicePaymentMethodRechargeIm ;
      private decimal A65InvoiceDetailHistoricPrice ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_36_idx="0001" ;
      private string sGXsfl_52_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttTicket_Internalname ;
      private string bttTicket_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtInvoiceId_Internalname ;
      private string edtInvoiceId_Jsonclick ;
      private string edtInvoiceTotalReceivable_Internalname ;
      private string edtInvoiceTotalReceivable_Jsonclick ;
      private string edtInvoiceCreatedDate_Internalname ;
      private string edtInvoiceCreatedDate_Jsonclick ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string subGrid2_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtPaymentMethodId_Internalname ;
      private string edtPaymentMethodDescription_Internalname ;
      private string edtInvoicePaymentMethodImport_Internalname ;
      private string edtInvoicePaymentMethodDiscountIm_Internalname ;
      private string edtInvoicePaymentMethodRechargeIm_Internalname ;
      private string edtProductId_Internalname ;
      private string edtProductCode_Internalname ;
      private string edtProductName_Internalname ;
      private string edtInvoiceDetailQuantity_Internalname ;
      private string edtInvoiceDetailHistoricPrice_Internalname ;
      private string cmbavType_Internalname ;
      private string scmdbuf ;
      private string sGXsfl_36_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string ROClassString ;
      private string edtProductId_Jsonclick ;
      private string edtProductCode_Jsonclick ;
      private string edtProductName_Jsonclick ;
      private string edtInvoiceDetailQuantity_Jsonclick ;
      private string edtInvoiceDetailHistoricPrice_Jsonclick ;
      private string GXCCtl ;
      private string cmbavType_Jsonclick ;
      private string sGXsfl_52_fel_idx="0001" ;
      private string subGrid2_Class ;
      private string subGrid2_Linesclass ;
      private string edtPaymentMethodId_Jsonclick ;
      private string edtPaymentMethodDescription_Jsonclick ;
      private string edtInvoicePaymentMethodImport_Jsonclick ;
      private string edtInvoicePaymentMethodDiscountIm_Jsonclick ;
      private string edtInvoicePaymentMethodRechargeIm_Jsonclick ;
      private string subGrid1_Header ;
      private string subGrid2_Header ;
      private DateTime A38InvoiceCreatedDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool A98InvoiceDetailIsWholesale ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n115PaymentMethodId ;
      private bool n120InvoicePaymentMethodImport ;
      private bool n133InvoicePaymentMethodDiscountIm ;
      private bool n132InvoicePaymentMethodRechargeIm ;
      private bool n55ProductCode ;
      private bool bGXsfl_36_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool n80InvoiceTotalReceivable ;
      private bool bGXsfl_52_Refreshing=false ;
      private bool returnInSub ;
      private bool AV6AllOk ;
      private string A116PaymentMethodDescription ;
      private string A55ProductCode ;
      private string A16ProductName ;
      private string AV8Type ;
      private GXWebGrid Grid1Container ;
      private GXWebGrid Grid2Container ;
      private GXWebRow Grid1Row ;
      private GXWebRow Grid2Row ;
      private GXWebColumn Grid1Column ;
      private GXWebColumn Grid2Column ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavType ;
      private IDataStoreProvider pr_default ;
      private int[] H003Q5_A25InvoiceDetailId ;
      private int[] H003Q5_A20InvoiceId ;
      private bool[] H003Q5_A98InvoiceDetailIsWholesale ;
      private DateTime[] H003Q5_A38InvoiceCreatedDate ;
      private decimal[] H003Q5_A65InvoiceDetailHistoricPrice ;
      private int[] H003Q5_A26InvoiceDetailQuantity ;
      private string[] H003Q5_A16ProductName ;
      private string[] H003Q5_A55ProductCode ;
      private bool[] H003Q5_n55ProductCode ;
      private int[] H003Q5_A15ProductId ;
      private decimal[] H003Q5_A80InvoiceTotalReceivable ;
      private bool[] H003Q5_n80InvoiceTotalReceivable ;
      private int[] H003Q6_A118InvoicePaymentMethodId ;
      private int[] H003Q6_A20InvoiceId ;
      private decimal[] H003Q6_A132InvoicePaymentMethodRechargeIm ;
      private bool[] H003Q6_n132InvoicePaymentMethodRechargeIm ;
      private decimal[] H003Q6_A133InvoicePaymentMethodDiscountIm ;
      private bool[] H003Q6_n133InvoicePaymentMethodDiscountIm ;
      private decimal[] H003Q6_A120InvoicePaymentMethodImport ;
      private bool[] H003Q6_n120InvoicePaymentMethodImport ;
      private string[] H003Q6_A116PaymentMethodDescription ;
      private int[] H003Q6_A115PaymentMethodId ;
      private bool[] H003Q6_n115PaymentMethodId ;
      private DateTime[] H003Q7_A38InvoiceCreatedDate ;
      private decimal[] H003Q11_A80InvoiceTotalReceivable ;
      private bool[] H003Q11_n80InvoiceTotalReceivable ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IGxSession AV7WebSession ;
      private GXWebForm Form ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession AV5Context ;
   }

   public class wpinvoicedetails__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmH003Q5;
          prmH003Q5 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmH003Q6;
          prmH003Q6 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmH003Q7;
          prmH003Q7 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmH003Q11;
          prmH003Q11 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("H003Q5", "SELECT T1.[InvoiceDetailId], T1.[InvoiceId], T1.[InvoiceDetailIsWholesale], T3.[InvoiceCreatedDate], T1.[InvoiceDetailHistoricPrice], T1.[InvoiceDetailQuantity], T2.[ProductName], T2.[ProductCode], T1.[ProductId], COALESCE( T4.[InvoiceTotalReceivable], 0) AS InvoiceTotalReceivable FROM ((([InvoiceDetail] T1 INNER JOIN [Product] T2 ON T2.[ProductId] = T1.[ProductId]) INNER JOIN [Invoice] T3 ON T3.[InvoiceId] = T1.[InvoiceId]) INNER JOIN (SELECT COALESCE( T7.[GXC1], 0) - COALESCE( T6.[GXC2], 0) + COALESCE( T6.[GXC3], 0) AS InvoiceTotalReceivable, T5.[InvoiceId] FROM (([Invoice] T5 LEFT JOIN (SELECT SUM([InvoicePaymentMethodDiscountIm]) AS GXC2, [InvoiceId], SUM([InvoicePaymentMethodRechargeIm]) AS GXC3 FROM [InvoicePaymentMethod] GROUP BY [InvoiceId] ) T6 ON T6.[InvoiceId] = T5.[InvoiceId]) LEFT JOIN (SELECT SUM([InvoiceDetailQuantity] * CAST([InvoiceDetailHistoricPrice] AS decimal( 28, 10))) AS GXC1, [InvoiceId] FROM [InvoiceDetail] GROUP BY [InvoiceId] ) T7 ON T7.[InvoiceId] = T5.[InvoiceId]) ) T4 ON T4.[InvoiceId] = T1.[InvoiceId]) WHERE T1.[InvoiceId] = @InvoiceId ORDER BY T1.[InvoiceId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003Q5,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H003Q6", "SELECT T1.[InvoicePaymentMethodId], T1.[InvoiceId], T1.[InvoicePaymentMethodRechargeIm], T1.[InvoicePaymentMethodDiscountIm], T1.[InvoicePaymentMethodImport], T2.[PaymentMethodDescription], T1.[PaymentMethodId] FROM ([InvoicePaymentMethod] T1 LEFT JOIN [PaymentMethod] T2 ON T2.[PaymentMethodId] = T1.[PaymentMethodId]) WHERE T1.[InvoiceId] = @InvoiceId ORDER BY T1.[InvoiceId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003Q6,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H003Q7", "SELECT [InvoiceCreatedDate] FROM [Invoice] WHERE [InvoiceId] = @InvoiceId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003Q7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H003Q11", "SELECT COALESCE( T1.[InvoiceTotalReceivable], 0) AS InvoiceTotalReceivable FROM (SELECT COALESCE( T4.[GXC1], 0) - COALESCE( T3.[GXC2], 0) + COALESCE( T3.[GXC3], 0) AS InvoiceTotalReceivable, T2.[InvoiceId] FROM (([Invoice] T2 LEFT JOIN (SELECT SUM([InvoicePaymentMethodDiscountIm]) AS GXC2, [InvoiceId], SUM([InvoicePaymentMethodRechargeIm]) AS GXC3 FROM [InvoicePaymentMethod] GROUP BY [InvoiceId] ) T3 ON T3.[InvoiceId] = T2.[InvoiceId]) LEFT JOIN (SELECT SUM([InvoiceDetailQuantity] * CAST([InvoiceDetailHistoricPrice] AS decimal( 28, 10))) AS GXC1, [InvoiceId] FROM [InvoiceDetail] GROUP BY [InvoiceId] ) T4 ON T4.[InvoiceId] = T2.[InvoiceId]) ) T1 WHERE T1.[InvoiceId] = @InvoiceId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003Q11,1, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((int[]) buf[9])[0] = rslt.getInt(9);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(10);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((string[]) buf[8])[0] = rslt.getVarchar(6);
                ((int[]) buf[9])[0] = rslt.getInt(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                return;
             case 2 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                return;
             case 3 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
       }
    }

 }

}
