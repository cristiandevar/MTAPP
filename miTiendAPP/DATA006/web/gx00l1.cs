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
   public class gx00l1 : GXDataArea
   {
      public gx00l1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public gx00l1( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_pInvoiceId ,
                           out int aP1_pInvoicePaymentMethodId )
      {
         this.AV11pInvoiceId = aP0_pInvoiceId;
         this.AV12pInvoicePaymentMethodId = 0 ;
         executePrivate();
         aP1_pInvoicePaymentMethodId=this.AV12pInvoicePaymentMethodId;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pInvoiceId");
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
               gxfirstwebparm = GetFirstPar( "pInvoiceId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pInvoiceId");
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
               AV11pInvoiceId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11pInvoiceId", StringUtil.LTrimStr( (decimal)(AV11pInvoiceId), 6, 0));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV12pInvoicePaymentMethodId = (int)(Math.Round(NumberUtil.Val( GetPar( "pInvoicePaymentMethodId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV12pInvoicePaymentMethodId", StringUtil.LTrimStr( (decimal)(AV12pInvoicePaymentMethodId), 6, 0));
               }
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
         nRC_GXsfl_64 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_64"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_64_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_64_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_64_idx = GetPar( "sGXsfl_64_idx");
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
         subGrid1_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid1_Rows"), "."), 18, MidpointRounding.ToEven));
         AV6cInvoicePaymentMethodId = (int)(Math.Round(NumberUtil.Val( GetPar( "cInvoicePaymentMethodId"), "."), 18, MidpointRounding.ToEven));
         AV7cPaymentMethodId = (int)(Math.Round(NumberUtil.Val( GetPar( "cPaymentMethodId"), "."), 18, MidpointRounding.ToEven));
         AV8cInvoicePaymentMethodImport = NumberUtil.Val( GetPar( "cInvoicePaymentMethodImport"), ".");
         AV14cInvoicePaymentMethodRechargeImport = NumberUtil.Val( GetPar( "cInvoicePaymentMethodRechargeImport"), ".");
         AV15cInvoicePaymentMethodDiscountImport = NumberUtil.Val( GetPar( "cInvoicePaymentMethodDiscountImport"), ".");
         AV11pInvoiceId = (int)(Math.Round(NumberUtil.Val( GetPar( "pInvoiceId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cInvoicePaymentMethodId, AV7cPaymentMethodId, AV8cInvoicePaymentMethodImport, AV14cInvoicePaymentMethodRechargeImport, AV15cInvoicePaymentMethodDiscountImport, AV11pInvoiceId) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid1_refresh_invoke */
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("general.ui.masterprompt", "GeneXus.Programs.general.ui.masterprompt", new Object[] {context});
            MasterPageObj.setDataArea(this,true);
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
         PA492( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START492( ) ;
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
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx00l1.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV11pInvoiceId,6,0)),UrlEncode(StringUtil.LTrimStr(AV12pInvoicePaymentMethodId,6,0))}, new string[] {"pInvoiceId","pInvoicePaymentMethodId"}) +"\">") ;
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
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vCINVOICEPAYMENTMETHODID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cInvoicePaymentMethodId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCPAYMENTMETHODID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cPaymentMethodId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCINVOICEPAYMENTMETHODIMPORT", StringUtil.LTrim( StringUtil.NToC( AV8cInvoicePaymentMethodImport, 18, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCINVOICEPAYMENTMETHODRECHARGEIMPORT", StringUtil.LTrim( StringUtil.NToC( AV14cInvoicePaymentMethodRechargeImport, 18, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCINVOICEPAYMENTMETHODDISCOUNTIMPORT", StringUtil.LTrim( StringUtil.NToC( AV15cInvoicePaymentMethodDiscountImport, 18, 2, ".", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_64", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_64), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPINVOICEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11pInvoiceId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPINVOICEPAYMENTMETHODID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12pInvoicePaymentMethodId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "INVOICEPAYMENTMETHODIDFILTERCONTAINER_Class", StringUtil.RTrim( divInvoicepaymentmethodidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PAYMENTMETHODIDFILTERCONTAINER_Class", StringUtil.RTrim( divPaymentmethodidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "INVOICEPAYMENTMETHODIMPORTFILTERCONTAINER_Class", StringUtil.RTrim( divInvoicepaymentmethodimportfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "INVOICEPAYMENTMETHODRECHARGEIMPORTFILTERCONTAINER_Class", StringUtil.RTrim( divInvoicepaymentmethodrechargeimportfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "INVOICEPAYMENTMETHODDISCOUNTIMPORTFILTERCONTAINER_Class", StringUtil.RTrim( divInvoicepaymentmethoddiscountimportfiltercontainer_Class));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", "notset");
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
            WE492( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT492( ) ;
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
         return formatLink("gx00l1.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV11pInvoiceId,6,0)),UrlEncode(StringUtil.LTrimStr(AV12pInvoicePaymentMethodId,6,0))}, new string[] {"pInvoiceId","pInvoicePaymentMethodId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx00L1" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List Payment Method" ;
      }

      protected void WB490( )
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
            GxWebStd.gx_div_start( context, divMain_Internalname, 1, 0, "px", 0, "px", "ContainerFluid PromptContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 PromptAdvancedBarCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAdvancedcontainer_Internalname, 1, 0, "px", 0, "px", divAdvancedcontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divInvoicepaymentmethodidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divInvoicepaymentmethodidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblinvoicepaymentmethodidfilter_Internalname, "Invoice Payment Method Id", "", "", lblLblinvoicepaymentmethodidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11491_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00L1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCinvoicepaymentmethodid_Internalname, "Invoice Payment Method Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCinvoicepaymentmethodid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cInvoicePaymentMethodId), 6, 0, ".", "")), StringUtil.LTrim( ((edtavCinvoicepaymentmethodid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cInvoicePaymentMethodId), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV6cInvoicePaymentMethodId), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCinvoicepaymentmethodid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCinvoicepaymentmethodid_Visible, edtavCinvoicepaymentmethodid_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00L1.htm");
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
            GxWebStd.gx_div_start( context, divPaymentmethodidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divPaymentmethodidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblpaymentmethodidfilter_Internalname, "Payment Method Id", "", "", lblLblpaymentmethodidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12491_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00L1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCpaymentmethodid_Internalname, "Payment Method Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCpaymentmethodid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cPaymentMethodId), 6, 0, ".", "")), StringUtil.LTrim( ((edtavCpaymentmethodid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV7cPaymentMethodId), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV7cPaymentMethodId), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpaymentmethodid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCpaymentmethodid_Visible, edtavCpaymentmethodid_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00L1.htm");
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
            GxWebStd.gx_div_start( context, divInvoicepaymentmethodimportfiltercontainer_Internalname, 1, 0, "px", 0, "px", divInvoicepaymentmethodimportfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblinvoicepaymentmethodimportfilter_Internalname, "Invoice Payment Method Import", "", "", lblLblinvoicepaymentmethodimportfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13491_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00L1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCinvoicepaymentmethodimport_Internalname, "Invoice Payment Method Import", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCinvoicepaymentmethodimport_Internalname, StringUtil.LTrim( StringUtil.NToC( AV8cInvoicePaymentMethodImport, 18, 2, ".", "")), StringUtil.LTrim( ((edtavCinvoicepaymentmethodimport_Enabled!=0) ? context.localUtil.Format( AV8cInvoicePaymentMethodImport, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV8cInvoicePaymentMethodImport, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCinvoicepaymentmethodimport_Jsonclick, 0, "Attribute", "", "", "", "", edtavCinvoicepaymentmethodimport_Visible, edtavCinvoicepaymentmethodimport_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00L1.htm");
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
            GxWebStd.gx_div_start( context, divInvoicepaymentmethodrechargeimportfiltercontainer_Internalname, 1, 0, "px", 0, "px", divInvoicepaymentmethodrechargeimportfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblinvoicepaymentmethodrechargeimportfilter_Internalname, "Invoice Payment Method Recharge Import", "", "", lblLblinvoicepaymentmethodrechargeimportfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14491_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00L1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCinvoicepaymentmethodrechargeimport_Internalname, "Invoice Payment Method Recharge Import", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCinvoicepaymentmethodrechargeimport_Internalname, StringUtil.LTrim( StringUtil.NToC( AV14cInvoicePaymentMethodRechargeImport, 18, 2, ".", "")), StringUtil.LTrim( ((edtavCinvoicepaymentmethodrechargeimport_Enabled!=0) ? context.localUtil.Format( AV14cInvoicePaymentMethodRechargeImport, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV14cInvoicePaymentMethodRechargeImport, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCinvoicepaymentmethodrechargeimport_Jsonclick, 0, "Attribute", "", "", "", "", edtavCinvoicepaymentmethodrechargeimport_Visible, edtavCinvoicepaymentmethodrechargeimport_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00L1.htm");
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
            GxWebStd.gx_div_start( context, divInvoicepaymentmethoddiscountimportfiltercontainer_Internalname, 1, 0, "px", 0, "px", divInvoicepaymentmethoddiscountimportfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblinvoicepaymentmethoddiscountimportfilter_Internalname, "Invoice Payment Method Discount Import", "", "", lblLblinvoicepaymentmethoddiscountimportfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15491_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00L1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCinvoicepaymentmethoddiscountimport_Internalname, "Invoice Payment Method Discount Import", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCinvoicepaymentmethoddiscountimport_Internalname, StringUtil.LTrim( StringUtil.NToC( AV15cInvoicePaymentMethodDiscountImport, 18, 2, ".", "")), StringUtil.LTrim( ((edtavCinvoicepaymentmethoddiscountimport_Enabled!=0) ? context.localUtil.Format( AV15cInvoicePaymentMethodDiscountImport, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV15cInvoicePaymentMethodDiscountImport, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCinvoicepaymentmethoddiscountimport_Jsonclick, 0, "Attribute", "", "", "", "", edtavCinvoicepaymentmethoddiscountimport_Visible, edtavCinvoicepaymentmethoddiscountimport_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00L1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 WWGridCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-sm hidden-md hidden-lg ToggleCell", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(64), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e16491_client"+"'", TempTags, "", 2, "HLP_Gx00L1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl64( ) ;
         }
         if ( wbEnd == 64 )
         {
            wbEnd = 0;
            nRC_GXsfl_64 = (int)(nGXsfl_64_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
               Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(64), 2, 0)+","+"null"+");", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx00L1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 64 )
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
                  Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
                  Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
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
         wbLoad = true;
      }

      protected void START492( )
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
            Form.Meta.addItem("description", "Selection List Payment Method", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP490( ) ;
      }

      protected void WS492( )
      {
         START492( ) ;
         EVT492( ) ;
      }

      protected void EVT492( )
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
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRID1PAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRID1PAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid1_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid1_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid1_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid1_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 4), "LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) )
                           {
                              nGXsfl_64_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
                              SubsflControlProps_642( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV18Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_64_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A118InvoicePaymentMethodId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtInvoicePaymentMethodId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A115PaymentMethodId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPaymentMethodId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              n115PaymentMethodId = false;
                              A120InvoicePaymentMethodImport = context.localUtil.CToN( cgiGet( edtInvoicePaymentMethodImport_Internalname), ".", ",");
                              n120InvoicePaymentMethodImport = false;
                              A132InvoicePaymentMethodRechargeIm = context.localUtil.CToN( cgiGet( edtInvoicePaymentMethodRechargeIm_Internalname), ".", ",");
                              n132InvoicePaymentMethodRechargeIm = false;
                              A20InvoiceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtInvoiceId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E17492 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E18492 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cinvoicepaymentmethodid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCINVOICEPAYMENTMETHODID"), ".", ",") != Convert.ToDecimal( AV6cInvoicePaymentMethodId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cpaymentmethodid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPAYMENTMETHODID"), ".", ",") != Convert.ToDecimal( AV7cPaymentMethodId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cinvoicepaymentmethodimport Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCINVOICEPAYMENTMETHODIMPORT"), ".", ",") != AV8cInvoicePaymentMethodImport )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cinvoicepaymentmethodrechargeimport Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCINVOICEPAYMENTMETHODRECHARGEIMPORT"), ".", ",") != AV14cInvoicePaymentMethodRechargeImport )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cinvoicepaymentmethoddiscountimport Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCINVOICEPAYMENTMETHODDISCOUNTIMPORT"), ".", ",") != AV15cInvoicePaymentMethodDiscountImport )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E19492 ();
                                       }
                                       dynload_actions( ) ;
                                    }
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

      protected void WE492( )
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

      protected void PA492( )
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
         SubsflControlProps_642( ) ;
         while ( nGXsfl_64_idx <= nRC_GXsfl_64 )
         {
            sendrow_642( ) ;
            nGXsfl_64_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_64_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_64_idx+1);
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        int AV6cInvoicePaymentMethodId ,
                                        int AV7cPaymentMethodId ,
                                        decimal AV8cInvoicePaymentMethodImport ,
                                        decimal AV14cInvoicePaymentMethodRechargeImport ,
                                        decimal AV15cInvoicePaymentMethodDiscountImport ,
                                        int AV11pInvoiceId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF492( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_INVOICEPAYMENTMETHODID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A118InvoicePaymentMethodId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "INVOICEPAYMENTMETHODID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A118InvoicePaymentMethodId), 6, 0, ".", "")));
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
         RF492( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      protected void RF492( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 64;
         nGXsfl_64_idx = 1;
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
         SubsflControlProps_642( ) ;
         bGXsfl_64_Refreshing = true;
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
            SubsflControlProps_642( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV7cPaymentMethodId ,
                                                 AV8cInvoicePaymentMethodImport ,
                                                 AV14cInvoicePaymentMethodRechargeImport ,
                                                 AV15cInvoicePaymentMethodDiscountImport ,
                                                 A115PaymentMethodId ,
                                                 A120InvoicePaymentMethodImport ,
                                                 A132InvoicePaymentMethodRechargeIm ,
                                                 A133InvoicePaymentMethodDiscountIm ,
                                                 AV11pInvoiceId ,
                                                 AV6cInvoicePaymentMethodId ,
                                                 A20InvoiceId } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                                 TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                                 }
            });
            /* Using cursor H00492 */
            pr_default.execute(0, new Object[] {AV11pInvoiceId, AV6cInvoicePaymentMethodId, AV7cPaymentMethodId, AV8cInvoicePaymentMethodImport, AV14cInvoicePaymentMethodRechargeImport, AV15cInvoicePaymentMethodDiscountImport, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_64_idx = 1;
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A133InvoicePaymentMethodDiscountIm = H00492_A133InvoicePaymentMethodDiscountIm[0];
               n133InvoicePaymentMethodDiscountIm = H00492_n133InvoicePaymentMethodDiscountIm[0];
               A20InvoiceId = H00492_A20InvoiceId[0];
               A132InvoicePaymentMethodRechargeIm = H00492_A132InvoicePaymentMethodRechargeIm[0];
               n132InvoicePaymentMethodRechargeIm = H00492_n132InvoicePaymentMethodRechargeIm[0];
               A120InvoicePaymentMethodImport = H00492_A120InvoicePaymentMethodImport[0];
               n120InvoicePaymentMethodImport = H00492_n120InvoicePaymentMethodImport[0];
               A115PaymentMethodId = H00492_A115PaymentMethodId[0];
               n115PaymentMethodId = H00492_n115PaymentMethodId[0];
               A118InvoicePaymentMethodId = H00492_A118InvoicePaymentMethodId[0];
               /* Execute user event: Load */
               E18492 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 64;
            WB490( ) ;
         }
         bGXsfl_64_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes492( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_INVOICEPAYMENTMETHODID"+"_"+sGXsfl_64_idx, GetSecureSignedToken( sGXsfl_64_idx, context.localUtil.Format( (decimal)(A118InvoicePaymentMethodId), "ZZZZZ9"), context));
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV7cPaymentMethodId ,
                                              AV8cInvoicePaymentMethodImport ,
                                              AV14cInvoicePaymentMethodRechargeImport ,
                                              AV15cInvoicePaymentMethodDiscountImport ,
                                              A115PaymentMethodId ,
                                              A120InvoicePaymentMethodImport ,
                                              A132InvoicePaymentMethodRechargeIm ,
                                              A133InvoicePaymentMethodDiscountIm ,
                                              AV11pInvoiceId ,
                                              AV6cInvoicePaymentMethodId ,
                                              A20InvoiceId } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         /* Using cursor H00493 */
         pr_default.execute(1, new Object[] {AV11pInvoiceId, AV6cInvoicePaymentMethodId, AV7cPaymentMethodId, AV8cInvoicePaymentMethodImport, AV14cInvoicePaymentMethodRechargeImport, AV15cInvoicePaymentMethodDiscountImport});
         GRID1_nRecordCount = H00493_AGRID1_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID1_nRecordCount) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         return (int)(10*1) ;
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID1_nFirstRecordOnPage/ (decimal)(subGrid1_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid1_firstpage( )
      {
         GRID1_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cInvoicePaymentMethodId, AV7cPaymentMethodId, AV8cInvoicePaymentMethodImport, AV14cInvoicePaymentMethodRechargeImport, AV15cInvoicePaymentMethodDiscountImport, AV11pInvoiceId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_nextpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ( GRID1_nRecordCount >= subGrid1_fnc_Recordsperpage( ) ) && ( GRID1_nEOF == 0 ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage+subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cInvoicePaymentMethodId, AV7cPaymentMethodId, AV8cInvoicePaymentMethodImport, AV14cInvoicePaymentMethodRechargeImport, AV15cInvoicePaymentMethodDiscountImport, AV11pInvoiceId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID1_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid1_previouspage( )
      {
         if ( GRID1_nFirstRecordOnPage >= subGrid1_fnc_Recordsperpage( ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage-subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cInvoicePaymentMethodId, AV7cPaymentMethodId, AV8cInvoicePaymentMethodImport, AV14cInvoicePaymentMethodRechargeImport, AV15cInvoicePaymentMethodDiscountImport, AV11pInvoiceId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_lastpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( GRID1_nRecordCount > subGrid1_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-subGrid1_fnc_Recordsperpage( ));
            }
            else
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cInvoicePaymentMethodId, AV7cPaymentMethodId, AV8cInvoicePaymentMethodImport, AV14cInvoicePaymentMethodRechargeImport, AV15cInvoicePaymentMethodDiscountImport, AV11pInvoiceId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid1_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(subGrid1_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cInvoicePaymentMethodId, AV7cPaymentMethodId, AV8cInvoicePaymentMethodImport, AV14cInvoicePaymentMethodRechargeImport, AV15cInvoicePaymentMethodDiscountImport, AV11pInvoiceId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP490( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E17492 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_64 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_64"), ".", ","), 18, MidpointRounding.ToEven));
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCinvoicepaymentmethodid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCinvoicepaymentmethodid_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCINVOICEPAYMENTMETHODID");
               GX_FocusControl = edtavCinvoicepaymentmethodid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cInvoicePaymentMethodId = 0;
               AssignAttri("", false, "AV6cInvoicePaymentMethodId", StringUtil.LTrimStr( (decimal)(AV6cInvoicePaymentMethodId), 6, 0));
            }
            else
            {
               AV6cInvoicePaymentMethodId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCinvoicepaymentmethodid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cInvoicePaymentMethodId", StringUtil.LTrimStr( (decimal)(AV6cInvoicePaymentMethodId), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCpaymentmethodid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCpaymentmethodid_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCPAYMENTMETHODID");
               GX_FocusControl = edtavCpaymentmethodid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cPaymentMethodId = 0;
               AssignAttri("", false, "AV7cPaymentMethodId", StringUtil.LTrimStr( (decimal)(AV7cPaymentMethodId), 6, 0));
            }
            else
            {
               AV7cPaymentMethodId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCpaymentmethodid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7cPaymentMethodId", StringUtil.LTrimStr( (decimal)(AV7cPaymentMethodId), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCinvoicepaymentmethodimport_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCinvoicepaymentmethodimport_Internalname), ".", ",") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCINVOICEPAYMENTMETHODIMPORT");
               GX_FocusControl = edtavCinvoicepaymentmethodimport_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cInvoicePaymentMethodImport = 0;
               AssignAttri("", false, "AV8cInvoicePaymentMethodImport", StringUtil.LTrimStr( AV8cInvoicePaymentMethodImport, 18, 2));
            }
            else
            {
               AV8cInvoicePaymentMethodImport = context.localUtil.CToN( cgiGet( edtavCinvoicepaymentmethodimport_Internalname), ".", ",");
               AssignAttri("", false, "AV8cInvoicePaymentMethodImport", StringUtil.LTrimStr( AV8cInvoicePaymentMethodImport, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCinvoicepaymentmethodrechargeimport_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCinvoicepaymentmethodrechargeimport_Internalname), ".", ",") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCINVOICEPAYMENTMETHODRECHARGEIMPORT");
               GX_FocusControl = edtavCinvoicepaymentmethodrechargeimport_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV14cInvoicePaymentMethodRechargeImport = 0;
               AssignAttri("", false, "AV14cInvoicePaymentMethodRechargeImport", StringUtil.LTrimStr( AV14cInvoicePaymentMethodRechargeImport, 18, 2));
            }
            else
            {
               AV14cInvoicePaymentMethodRechargeImport = context.localUtil.CToN( cgiGet( edtavCinvoicepaymentmethodrechargeimport_Internalname), ".", ",");
               AssignAttri("", false, "AV14cInvoicePaymentMethodRechargeImport", StringUtil.LTrimStr( AV14cInvoicePaymentMethodRechargeImport, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCinvoicepaymentmethoddiscountimport_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCinvoicepaymentmethoddiscountimport_Internalname), ".", ",") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCINVOICEPAYMENTMETHODDISCOUNTIMPORT");
               GX_FocusControl = edtavCinvoicepaymentmethoddiscountimport_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV15cInvoicePaymentMethodDiscountImport = 0;
               AssignAttri("", false, "AV15cInvoicePaymentMethodDiscountImport", StringUtil.LTrimStr( AV15cInvoicePaymentMethodDiscountImport, 18, 2));
            }
            else
            {
               AV15cInvoicePaymentMethodDiscountImport = context.localUtil.CToN( cgiGet( edtavCinvoicepaymentmethoddiscountimport_Internalname), ".", ",");
               AssignAttri("", false, "AV15cInvoicePaymentMethodDiscountImport", StringUtil.LTrimStr( AV15cInvoicePaymentMethodDiscountImport, 18, 2));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCINVOICEPAYMENTMETHODID"), ".", ",") != Convert.ToDecimal( AV6cInvoicePaymentMethodId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPAYMENTMETHODID"), ".", ",") != Convert.ToDecimal( AV7cPaymentMethodId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCINVOICEPAYMENTMETHODIMPORT"), ".", ",") != AV8cInvoicePaymentMethodImport )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCINVOICEPAYMENTMETHODRECHARGEIMPORT"), ".", ",") != AV14cInvoicePaymentMethodRechargeImport )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCINVOICEPAYMENTMETHODDISCOUNTIMPORT"), ".", ",") != AV15cInvoicePaymentMethodDiscountImport )
            {
               GRID1_nFirstRecordOnPage = 0;
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
         E17492 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E17492( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Selection List %1", "Payment Method", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV13ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E18492( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "selectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV18Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )));
         sendrow_642( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_64_Refreshing )
         {
            DoAjaxLoad(64, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E19492 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E19492( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV12pInvoicePaymentMethodId = A118InvoicePaymentMethodId;
         AssignAttri("", false, "AV12pInvoicePaymentMethodId", StringUtil.LTrimStr( (decimal)(AV12pInvoicePaymentMethodId), 6, 0));
         context.setWebReturnParms(new Object[] {(int)AV12pInvoicePaymentMethodId});
         context.setWebReturnParmsMetadata(new Object[] {"AV12pInvoicePaymentMethodId"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV11pInvoiceId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV11pInvoiceId", StringUtil.LTrimStr( (decimal)(AV11pInvoiceId), 6, 0));
         AV12pInvoicePaymentMethodId = Convert.ToInt32(getParm(obj,1));
         AssignAttri("", false, "AV12pInvoicePaymentMethodId", StringUtil.LTrimStr( (decimal)(AV12pInvoicePaymentMethodId), 6, 0));
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
         PA492( ) ;
         WS492( ) ;
         WE492( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024112023525085", true, true);
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
         context.AddJavascriptSource("gx00l1.js", "?2024112023525086", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_642( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_64_idx;
         edtInvoicePaymentMethodId_Internalname = "INVOICEPAYMENTMETHODID_"+sGXsfl_64_idx;
         edtPaymentMethodId_Internalname = "PAYMENTMETHODID_"+sGXsfl_64_idx;
         edtInvoicePaymentMethodImport_Internalname = "INVOICEPAYMENTMETHODIMPORT_"+sGXsfl_64_idx;
         edtInvoicePaymentMethodRechargeIm_Internalname = "INVOICEPAYMENTMETHODRECHARGEIM_"+sGXsfl_64_idx;
         edtInvoiceId_Internalname = "INVOICEID_"+sGXsfl_64_idx;
      }

      protected void SubsflControlProps_fel_642( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_64_fel_idx;
         edtInvoicePaymentMethodId_Internalname = "INVOICEPAYMENTMETHODID_"+sGXsfl_64_fel_idx;
         edtPaymentMethodId_Internalname = "PAYMENTMETHODID_"+sGXsfl_64_fel_idx;
         edtInvoicePaymentMethodImport_Internalname = "INVOICEPAYMENTMETHODIMPORT_"+sGXsfl_64_fel_idx;
         edtInvoicePaymentMethodRechargeIm_Internalname = "INVOICEPAYMENTMETHODRECHARGEIM_"+sGXsfl_64_fel_idx;
         edtInvoiceId_Internalname = "INVOICEID_"+sGXsfl_64_fel_idx;
      }

      protected void sendrow_642( )
      {
         SubsflControlProps_642( ) ;
         WB490( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_64_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
         {
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
               if ( ((int)((nGXsfl_64_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_64_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A118InvoicePaymentMethodId), 6, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_64_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV18Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV18Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInvoicePaymentMethodId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A118InvoicePaymentMethodId), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A118InvoicePaymentMethodId), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInvoicePaymentMethodId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPaymentMethodId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A115PaymentMethodId), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A115PaymentMethodId), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPaymentMethodId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtInvoicePaymentMethodImport_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A118InvoicePaymentMethodId), 6, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtInvoicePaymentMethodImport_Internalname, "Link", edtInvoicePaymentMethodImport_Link, !bGXsfl_64_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInvoicePaymentMethodImport_Internalname,StringUtil.LTrim( StringUtil.NToC( A120InvoicePaymentMethodImport, 18, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A120InvoicePaymentMethodImport, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtInvoicePaymentMethodImport_Link,(string)"",(string)"",(string)"",(string)edtInvoicePaymentMethodImport_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)0,(bool)true,(string)"Price",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInvoicePaymentMethodRechargeIm_Internalname,StringUtil.LTrim( StringUtil.NToC( A132InvoicePaymentMethodRechargeIm, 18, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A132InvoicePaymentMethodRechargeIm, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInvoicePaymentMethodRechargeIm_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)0,(bool)true,(string)"Price",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInvoiceId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A20InvoiceId), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A20InvoiceId), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInvoiceId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes492( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_64_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_64_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_64_idx+1);
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
         }
         /* End function sendrow_642 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl64( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"64\">") ;
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
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"SelectionAttribute"+" "+((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class")+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Method Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Payment Method Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Method Import") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Recharge Import") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Invoice Id") ;
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
            Grid1Column.AddObjectProperty("Value", context.convertURL( AV5LinkSelection));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtavLinkselection_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A118InvoicePaymentMethodId), 6, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A115PaymentMethodId), 6, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A120InvoicePaymentMethodImport, 18, 2, ".", ""))));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtInvoicePaymentMethodImport_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A132InvoicePaymentMethodRechargeIm, 18, 2, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A20InvoiceId), 6, 0, ".", ""))));
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

      protected void init_default_properties( )
      {
         lblLblinvoicepaymentmethodidfilter_Internalname = "LBLINVOICEPAYMENTMETHODIDFILTER";
         edtavCinvoicepaymentmethodid_Internalname = "vCINVOICEPAYMENTMETHODID";
         divInvoicepaymentmethodidfiltercontainer_Internalname = "INVOICEPAYMENTMETHODIDFILTERCONTAINER";
         lblLblpaymentmethodidfilter_Internalname = "LBLPAYMENTMETHODIDFILTER";
         edtavCpaymentmethodid_Internalname = "vCPAYMENTMETHODID";
         divPaymentmethodidfiltercontainer_Internalname = "PAYMENTMETHODIDFILTERCONTAINER";
         lblLblinvoicepaymentmethodimportfilter_Internalname = "LBLINVOICEPAYMENTMETHODIMPORTFILTER";
         edtavCinvoicepaymentmethodimport_Internalname = "vCINVOICEPAYMENTMETHODIMPORT";
         divInvoicepaymentmethodimportfiltercontainer_Internalname = "INVOICEPAYMENTMETHODIMPORTFILTERCONTAINER";
         lblLblinvoicepaymentmethodrechargeimportfilter_Internalname = "LBLINVOICEPAYMENTMETHODRECHARGEIMPORTFILTER";
         edtavCinvoicepaymentmethodrechargeimport_Internalname = "vCINVOICEPAYMENTMETHODRECHARGEIMPORT";
         divInvoicepaymentmethodrechargeimportfiltercontainer_Internalname = "INVOICEPAYMENTMETHODRECHARGEIMPORTFILTERCONTAINER";
         lblLblinvoicepaymentmethoddiscountimportfilter_Internalname = "LBLINVOICEPAYMENTMETHODDISCOUNTIMPORTFILTER";
         edtavCinvoicepaymentmethoddiscountimport_Internalname = "vCINVOICEPAYMENTMETHODDISCOUNTIMPORT";
         divInvoicepaymentmethoddiscountimportfiltercontainer_Internalname = "INVOICEPAYMENTMETHODDISCOUNTIMPORTFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtInvoicePaymentMethodId_Internalname = "INVOICEPAYMENTMETHODID";
         edtPaymentMethodId_Internalname = "PAYMENTMETHODID";
         edtInvoicePaymentMethodImport_Internalname = "INVOICEPAYMENTMETHODIMPORT";
         edtInvoicePaymentMethodRechargeIm_Internalname = "INVOICEPAYMENTMETHODRECHARGEIM";
         edtInvoiceId_Internalname = "INVOICEID";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         divGridtable_Internalname = "GRIDTABLE";
         divMain_Internalname = "MAIN";
         Form.Internalname = "FORM";
         subGrid1_Internalname = "GRID1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("mtaKB", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         subGrid1_Header = "";
         edtInvoiceId_Jsonclick = "";
         edtInvoicePaymentMethodRechargeIm_Jsonclick = "";
         edtInvoicePaymentMethodImport_Jsonclick = "";
         edtInvoicePaymentMethodImport_Link = "";
         edtPaymentMethodId_Jsonclick = "";
         edtInvoicePaymentMethodId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCinvoicepaymentmethoddiscountimport_Jsonclick = "";
         edtavCinvoicepaymentmethoddiscountimport_Enabled = 1;
         edtavCinvoicepaymentmethoddiscountimport_Visible = 1;
         edtavCinvoicepaymentmethodrechargeimport_Jsonclick = "";
         edtavCinvoicepaymentmethodrechargeimport_Enabled = 1;
         edtavCinvoicepaymentmethodrechargeimport_Visible = 1;
         edtavCinvoicepaymentmethodimport_Jsonclick = "";
         edtavCinvoicepaymentmethodimport_Enabled = 1;
         edtavCinvoicepaymentmethodimport_Visible = 1;
         edtavCpaymentmethodid_Jsonclick = "";
         edtavCpaymentmethodid_Enabled = 1;
         edtavCpaymentmethodid_Visible = 1;
         edtavCinvoicepaymentmethodid_Jsonclick = "";
         edtavCinvoicepaymentmethodid_Enabled = 1;
         edtavCinvoicepaymentmethodid_Visible = 1;
         divInvoicepaymentmethoddiscountimportfiltercontainer_Class = "AdvancedContainerItem";
         divInvoicepaymentmethodrechargeimportfiltercontainer_Class = "AdvancedContainerItem";
         divInvoicepaymentmethodimportfiltercontainer_Class = "AdvancedContainerItem";
         divPaymentmethodidfiltercontainer_Class = "AdvancedContainerItem";
         divInvoicepaymentmethodidfiltercontainer_Class = "AdvancedContainerItem";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List Payment Method";
         subGrid1_Rows = 10;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cInvoicePaymentMethodId',fld:'vCINVOICEPAYMENTMETHODID',pic:'ZZZZZ9'},{av:'AV7cPaymentMethodId',fld:'vCPAYMENTMETHODID',pic:'ZZZZZ9'},{av:'AV8cInvoicePaymentMethodImport',fld:'vCINVOICEPAYMENTMETHODIMPORT',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV14cInvoicePaymentMethodRechargeImport',fld:'vCINVOICEPAYMENTMETHODRECHARGEIMPORT',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV15cInvoicePaymentMethodDiscountImport',fld:'vCINVOICEPAYMENTMETHODDISCOUNTIMPORT',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV11pInvoiceId',fld:'vPINVOICEID',pic:'ZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E16491',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLINVOICEPAYMENTMETHODIDFILTER.CLICK","{handler:'E11491',iparms:[{av:'divInvoicepaymentmethodidfiltercontainer_Class',ctrl:'INVOICEPAYMENTMETHODIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLINVOICEPAYMENTMETHODIDFILTER.CLICK",",oparms:[{av:'divInvoicepaymentmethodidfiltercontainer_Class',ctrl:'INVOICEPAYMENTMETHODIDFILTERCONTAINER',prop:'Class'},{av:'edtavCinvoicepaymentmethodid_Visible',ctrl:'vCINVOICEPAYMENTMETHODID',prop:'Visible'}]}");
         setEventMetadata("LBLPAYMENTMETHODIDFILTER.CLICK","{handler:'E12491',iparms:[{av:'divPaymentmethodidfiltercontainer_Class',ctrl:'PAYMENTMETHODIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPAYMENTMETHODIDFILTER.CLICK",",oparms:[{av:'divPaymentmethodidfiltercontainer_Class',ctrl:'PAYMENTMETHODIDFILTERCONTAINER',prop:'Class'},{av:'edtavCpaymentmethodid_Visible',ctrl:'vCPAYMENTMETHODID',prop:'Visible'}]}");
         setEventMetadata("LBLINVOICEPAYMENTMETHODIMPORTFILTER.CLICK","{handler:'E13491',iparms:[{av:'divInvoicepaymentmethodimportfiltercontainer_Class',ctrl:'INVOICEPAYMENTMETHODIMPORTFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLINVOICEPAYMENTMETHODIMPORTFILTER.CLICK",",oparms:[{av:'divInvoicepaymentmethodimportfiltercontainer_Class',ctrl:'INVOICEPAYMENTMETHODIMPORTFILTERCONTAINER',prop:'Class'},{av:'edtavCinvoicepaymentmethodimport_Visible',ctrl:'vCINVOICEPAYMENTMETHODIMPORT',prop:'Visible'}]}");
         setEventMetadata("LBLINVOICEPAYMENTMETHODRECHARGEIMPORTFILTER.CLICK","{handler:'E14491',iparms:[{av:'divInvoicepaymentmethodrechargeimportfiltercontainer_Class',ctrl:'INVOICEPAYMENTMETHODRECHARGEIMPORTFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLINVOICEPAYMENTMETHODRECHARGEIMPORTFILTER.CLICK",",oparms:[{av:'divInvoicepaymentmethodrechargeimportfiltercontainer_Class',ctrl:'INVOICEPAYMENTMETHODRECHARGEIMPORTFILTERCONTAINER',prop:'Class'},{av:'edtavCinvoicepaymentmethodrechargeimport_Visible',ctrl:'vCINVOICEPAYMENTMETHODRECHARGEIMPORT',prop:'Visible'}]}");
         setEventMetadata("LBLINVOICEPAYMENTMETHODDISCOUNTIMPORTFILTER.CLICK","{handler:'E15491',iparms:[{av:'divInvoicepaymentmethoddiscountimportfiltercontainer_Class',ctrl:'INVOICEPAYMENTMETHODDISCOUNTIMPORTFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLINVOICEPAYMENTMETHODDISCOUNTIMPORTFILTER.CLICK",",oparms:[{av:'divInvoicepaymentmethoddiscountimportfiltercontainer_Class',ctrl:'INVOICEPAYMENTMETHODDISCOUNTIMPORTFILTERCONTAINER',prop:'Class'},{av:'edtavCinvoicepaymentmethoddiscountimport_Visible',ctrl:'vCINVOICEPAYMENTMETHODDISCOUNTIMPORT',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E19492',iparms:[{av:'A118InvoicePaymentMethodId',fld:'INVOICEPAYMENTMETHODID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV12pInvoicePaymentMethodId',fld:'vPINVOICEPAYMENTMETHODID',pic:'ZZZZZ9'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cInvoicePaymentMethodId',fld:'vCINVOICEPAYMENTMETHODID',pic:'ZZZZZ9'},{av:'AV7cPaymentMethodId',fld:'vCPAYMENTMETHODID',pic:'ZZZZZ9'},{av:'AV8cInvoicePaymentMethodImport',fld:'vCINVOICEPAYMENTMETHODIMPORT',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV14cInvoicePaymentMethodRechargeImport',fld:'vCINVOICEPAYMENTMETHODRECHARGEIMPORT',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV15cInvoicePaymentMethodDiscountImport',fld:'vCINVOICEPAYMENTMETHODDISCOUNTIMPORT',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV11pInvoiceId',fld:'vPINVOICEID',pic:'ZZZZZ9'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cInvoicePaymentMethodId',fld:'vCINVOICEPAYMENTMETHODID',pic:'ZZZZZ9'},{av:'AV7cPaymentMethodId',fld:'vCPAYMENTMETHODID',pic:'ZZZZZ9'},{av:'AV8cInvoicePaymentMethodImport',fld:'vCINVOICEPAYMENTMETHODIMPORT',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV14cInvoicePaymentMethodRechargeImport',fld:'vCINVOICEPAYMENTMETHODRECHARGEIMPORT',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV15cInvoicePaymentMethodDiscountImport',fld:'vCINVOICEPAYMENTMETHODDISCOUNTIMPORT',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV11pInvoiceId',fld:'vPINVOICEID',pic:'ZZZZZ9'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cInvoicePaymentMethodId',fld:'vCINVOICEPAYMENTMETHODID',pic:'ZZZZZ9'},{av:'AV7cPaymentMethodId',fld:'vCPAYMENTMETHODID',pic:'ZZZZZ9'},{av:'AV8cInvoicePaymentMethodImport',fld:'vCINVOICEPAYMENTMETHODIMPORT',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV14cInvoicePaymentMethodRechargeImport',fld:'vCINVOICEPAYMENTMETHODRECHARGEIMPORT',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV15cInvoicePaymentMethodDiscountImport',fld:'vCINVOICEPAYMENTMETHODDISCOUNTIMPORT',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV11pInvoiceId',fld:'vPINVOICEID',pic:'ZZZZZ9'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cInvoicePaymentMethodId',fld:'vCINVOICEPAYMENTMETHODID',pic:'ZZZZZ9'},{av:'AV7cPaymentMethodId',fld:'vCPAYMENTMETHODID',pic:'ZZZZZ9'},{av:'AV8cInvoicePaymentMethodImport',fld:'vCINVOICEPAYMENTMETHODIMPORT',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV14cInvoicePaymentMethodRechargeImport',fld:'vCINVOICEPAYMENTMETHODRECHARGEIMPORT',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV15cInvoicePaymentMethodDiscountImport',fld:'vCINVOICEPAYMENTMETHODDISCOUNTIMPORT',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV11pInvoiceId',fld:'vPINVOICEID',pic:'ZZZZZ9'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CINVOICEPAYMENTMETHODIMPORT","{handler:'Validv_Cinvoicepaymentmethodimport',iparms:[]");
         setEventMetadata("VALIDV_CINVOICEPAYMENTMETHODIMPORT",",oparms:[]}");
         setEventMetadata("VALIDV_CINVOICEPAYMENTMETHODRECHARGEIMPORT","{handler:'Validv_Cinvoicepaymentmethodrechargeimport',iparms:[]");
         setEventMetadata("VALIDV_CINVOICEPAYMENTMETHODRECHARGEIMPORT",",oparms:[]}");
         setEventMetadata("VALIDV_CINVOICEPAYMENTMETHODDISCOUNTIMPORT","{handler:'Validv_Cinvoicepaymentmethoddiscountimport',iparms:[]");
         setEventMetadata("VALIDV_CINVOICEPAYMENTMETHODDISCOUNTIMPORT",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Invoiceid',iparms:[]");
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
         lblLblinvoicepaymentmethodidfilter_Jsonclick = "";
         TempTags = "";
         lblLblpaymentmethodidfilter_Jsonclick = "";
         lblLblinvoicepaymentmethodimportfilter_Jsonclick = "";
         lblLblinvoicepaymentmethodrechargeimportfilter_Jsonclick = "";
         lblLblinvoicepaymentmethoddiscountimportfilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV5LinkSelection = "";
         AV18Linkselection_GXI = "";
         scmdbuf = "";
         H00492_A133InvoicePaymentMethodDiscountIm = new decimal[1] ;
         H00492_n133InvoicePaymentMethodDiscountIm = new bool[] {false} ;
         H00492_A20InvoiceId = new int[1] ;
         H00492_A132InvoicePaymentMethodRechargeIm = new decimal[1] ;
         H00492_n132InvoicePaymentMethodRechargeIm = new bool[] {false} ;
         H00492_A120InvoicePaymentMethodImport = new decimal[1] ;
         H00492_n120InvoicePaymentMethodImport = new bool[] {false} ;
         H00492_A115PaymentMethodId = new int[1] ;
         H00492_n115PaymentMethodId = new bool[] {false} ;
         H00492_A118InvoicePaymentMethodId = new int[1] ;
         H00493_AGRID1_nRecordCount = new long[1] ;
         AV13ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx00l1__default(),
            new Object[][] {
                new Object[] {
               H00492_A133InvoicePaymentMethodDiscountIm, H00492_n133InvoicePaymentMethodDiscountIm, H00492_A20InvoiceId, H00492_A132InvoicePaymentMethodRechargeIm, H00492_n132InvoicePaymentMethodRechargeIm, H00492_A120InvoicePaymentMethodImport, H00492_n120InvoicePaymentMethodImport, H00492_A115PaymentMethodId, H00492_n115PaymentMethodId, H00492_A118InvoicePaymentMethodId
               }
               , new Object[] {
               H00493_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid1_Backcolorstyle ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private int AV11pInvoiceId ;
      private int AV12pInvoicePaymentMethodId ;
      private int wcpOAV11pInvoiceId ;
      private int nRC_GXsfl_64 ;
      private int subGrid1_Rows ;
      private int nGXsfl_64_idx=1 ;
      private int AV6cInvoicePaymentMethodId ;
      private int AV7cPaymentMethodId ;
      private int edtavCinvoicepaymentmethodid_Enabled ;
      private int edtavCinvoicepaymentmethodid_Visible ;
      private int edtavCpaymentmethodid_Enabled ;
      private int edtavCpaymentmethodid_Visible ;
      private int edtavCinvoicepaymentmethodimport_Enabled ;
      private int edtavCinvoicepaymentmethodimport_Visible ;
      private int edtavCinvoicepaymentmethodrechargeimport_Enabled ;
      private int edtavCinvoicepaymentmethodrechargeimport_Visible ;
      private int edtavCinvoicepaymentmethoddiscountimport_Enabled ;
      private int edtavCinvoicepaymentmethoddiscountimport_Visible ;
      private int A118InvoicePaymentMethodId ;
      private int A115PaymentMethodId ;
      private int A20InvoiceId ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long GRID1_nFirstRecordOnPage ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private decimal AV8cInvoicePaymentMethodImport ;
      private decimal AV14cInvoicePaymentMethodRechargeImport ;
      private decimal AV15cInvoicePaymentMethodDiscountImport ;
      private decimal A120InvoicePaymentMethodImport ;
      private decimal A132InvoicePaymentMethodRechargeIm ;
      private decimal A133InvoicePaymentMethodDiscountIm ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divInvoicepaymentmethodidfiltercontainer_Class ;
      private string divPaymentmethodidfiltercontainer_Class ;
      private string divInvoicepaymentmethodimportfiltercontainer_Class ;
      private string divInvoicepaymentmethodrechargeimportfiltercontainer_Class ;
      private string divInvoicepaymentmethoddiscountimportfiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_64_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divInvoicepaymentmethodidfiltercontainer_Internalname ;
      private string lblLblinvoicepaymentmethodidfilter_Internalname ;
      private string lblLblinvoicepaymentmethodidfilter_Jsonclick ;
      private string edtavCinvoicepaymentmethodid_Internalname ;
      private string TempTags ;
      private string edtavCinvoicepaymentmethodid_Jsonclick ;
      private string divPaymentmethodidfiltercontainer_Internalname ;
      private string lblLblpaymentmethodidfilter_Internalname ;
      private string lblLblpaymentmethodidfilter_Jsonclick ;
      private string edtavCpaymentmethodid_Internalname ;
      private string edtavCpaymentmethodid_Jsonclick ;
      private string divInvoicepaymentmethodimportfiltercontainer_Internalname ;
      private string lblLblinvoicepaymentmethodimportfilter_Internalname ;
      private string lblLblinvoicepaymentmethodimportfilter_Jsonclick ;
      private string edtavCinvoicepaymentmethodimport_Internalname ;
      private string edtavCinvoicepaymentmethodimport_Jsonclick ;
      private string divInvoicepaymentmethodrechargeimportfiltercontainer_Internalname ;
      private string lblLblinvoicepaymentmethodrechargeimportfilter_Internalname ;
      private string lblLblinvoicepaymentmethodrechargeimportfilter_Jsonclick ;
      private string edtavCinvoicepaymentmethodrechargeimport_Internalname ;
      private string edtavCinvoicepaymentmethodrechargeimport_Jsonclick ;
      private string divInvoicepaymentmethoddiscountimportfiltercontainer_Internalname ;
      private string lblLblinvoicepaymentmethoddiscountimportfilter_Internalname ;
      private string lblLblinvoicepaymentmethoddiscountimportfilter_Jsonclick ;
      private string edtavCinvoicepaymentmethoddiscountimport_Internalname ;
      private string edtavCinvoicepaymentmethoddiscountimport_Jsonclick ;
      private string divGridtable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtntoggle_Internalname ;
      private string bttBtntoggle_Jsonclick ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavLinkselection_Internalname ;
      private string edtInvoicePaymentMethodId_Internalname ;
      private string edtPaymentMethodId_Internalname ;
      private string edtInvoicePaymentMethodImport_Internalname ;
      private string edtInvoicePaymentMethodRechargeIm_Internalname ;
      private string edtInvoiceId_Internalname ;
      private string scmdbuf ;
      private string AV13ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_64_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtInvoicePaymentMethodId_Jsonclick ;
      private string edtPaymentMethodId_Jsonclick ;
      private string edtInvoicePaymentMethodImport_Link ;
      private string edtInvoicePaymentMethodImport_Jsonclick ;
      private string edtInvoicePaymentMethodRechargeIm_Jsonclick ;
      private string edtInvoiceId_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_64_Refreshing=false ;
      private bool n115PaymentMethodId ;
      private bool n120InvoicePaymentMethodImport ;
      private bool n132InvoicePaymentMethodRechargeIm ;
      private bool gxdyncontrolsrefreshing ;
      private bool n133InvoicePaymentMethodDiscountIm ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV18Linkselection_GXI ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private decimal[] H00492_A133InvoicePaymentMethodDiscountIm ;
      private bool[] H00492_n133InvoicePaymentMethodDiscountIm ;
      private int[] H00492_A20InvoiceId ;
      private decimal[] H00492_A132InvoicePaymentMethodRechargeIm ;
      private bool[] H00492_n132InvoicePaymentMethodRechargeIm ;
      private decimal[] H00492_A120InvoicePaymentMethodImport ;
      private bool[] H00492_n120InvoicePaymentMethodImport ;
      private int[] H00492_A115PaymentMethodId ;
      private bool[] H00492_n115PaymentMethodId ;
      private int[] H00492_A118InvoicePaymentMethodId ;
      private long[] H00493_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private int aP1_pInvoicePaymentMethodId ;
      private GXWebForm Form ;
   }

   public class gx00l1__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00492( IGxContext context ,
                                             int AV7cPaymentMethodId ,
                                             decimal AV8cInvoicePaymentMethodImport ,
                                             decimal AV14cInvoicePaymentMethodRechargeImport ,
                                             decimal AV15cInvoicePaymentMethodDiscountImport ,
                                             int A115PaymentMethodId ,
                                             decimal A120InvoicePaymentMethodImport ,
                                             decimal A132InvoicePaymentMethodRechargeIm ,
                                             decimal A133InvoicePaymentMethodDiscountIm ,
                                             int AV11pInvoiceId ,
                                             int AV6cInvoicePaymentMethodId ,
                                             int A20InvoiceId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[9];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [InvoicePaymentMethodDiscountIm], [InvoiceId], [InvoicePaymentMethodRechargeIm], [InvoicePaymentMethodImport], [PaymentMethodId], [InvoicePaymentMethodId]";
         sFromString = " FROM [InvoicePaymentMethod]";
         sOrderString = "";
         AddWhere(sWhereString, "([InvoiceId] = @AV11pInvoiceId and [InvoicePaymentMethodId] >= @AV6cInvoicePaymentMethodId)");
         if ( ! (0==AV7cPaymentMethodId) )
         {
            AddWhere(sWhereString, "([PaymentMethodId] >= @AV7cPaymentMethodId)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV8cInvoicePaymentMethodImport) )
         {
            AddWhere(sWhereString, "([InvoicePaymentMethodImport] >= @AV8cInvoicePaymentMethodImport)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV14cInvoicePaymentMethodRechargeImport) )
         {
            AddWhere(sWhereString, "([InvoicePaymentMethodRechargeIm] >= @AV14cInvoicePaymentMethodRechargeImport)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV15cInvoicePaymentMethodDiscountImport) )
         {
            AddWhere(sWhereString, "([InvoicePaymentMethodDiscountIm] >= @AV15cInvoicePaymentMethodDiscountImport)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         sOrderString += " ORDER BY [InvoiceId], [InvoicePaymentMethodId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00493( IGxContext context ,
                                             int AV7cPaymentMethodId ,
                                             decimal AV8cInvoicePaymentMethodImport ,
                                             decimal AV14cInvoicePaymentMethodRechargeImport ,
                                             decimal AV15cInvoicePaymentMethodDiscountImport ,
                                             int A115PaymentMethodId ,
                                             decimal A120InvoicePaymentMethodImport ,
                                             decimal A132InvoicePaymentMethodRechargeIm ,
                                             decimal A133InvoicePaymentMethodDiscountIm ,
                                             int AV11pInvoiceId ,
                                             int AV6cInvoicePaymentMethodId ,
                                             int A20InvoiceId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [InvoicePaymentMethod]";
         AddWhere(sWhereString, "([InvoiceId] = @AV11pInvoiceId and [InvoicePaymentMethodId] >= @AV6cInvoicePaymentMethodId)");
         if ( ! (0==AV7cPaymentMethodId) )
         {
            AddWhere(sWhereString, "([PaymentMethodId] >= @AV7cPaymentMethodId)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV8cInvoicePaymentMethodImport) )
         {
            AddWhere(sWhereString, "([InvoicePaymentMethodImport] >= @AV8cInvoicePaymentMethodImport)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV14cInvoicePaymentMethodRechargeImport) )
         {
            AddWhere(sWhereString, "([InvoicePaymentMethodRechargeIm] >= @AV14cInvoicePaymentMethodRechargeImport)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV15cInvoicePaymentMethodDiscountImport) )
         {
            AddWhere(sWhereString, "([InvoicePaymentMethodDiscountIm] >= @AV15cInvoicePaymentMethodDiscountImport)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         scmdbuf += sWhereString;
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00492(context, (int)dynConstraints[0] , (decimal)dynConstraints[1] , (decimal)dynConstraints[2] , (decimal)dynConstraints[3] , (int)dynConstraints[4] , (decimal)dynConstraints[5] , (decimal)dynConstraints[6] , (decimal)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] );
               case 1 :
                     return conditional_H00493(context, (int)dynConstraints[0] , (decimal)dynConstraints[1] , (decimal)dynConstraints[2] , (decimal)dynConstraints[3] , (int)dynConstraints[4] , (decimal)dynConstraints[5] , (decimal)dynConstraints[6] , (decimal)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] );
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
          Object[] prmH00492;
          prmH00492 = new Object[] {
          new ParDef("@AV11pInvoiceId",GXType.Int32,6,0) ,
          new ParDef("@AV6cInvoicePaymentMethodId",GXType.Int32,6,0) ,
          new ParDef("@AV7cPaymentMethodId",GXType.Int32,6,0) ,
          new ParDef("@AV8cInvoicePaymentMethodImport",GXType.Decimal,18,2) ,
          new ParDef("@AV14cInvoicePaymentMethodRechargeImport",GXType.Decimal,18,2) ,
          new ParDef("@AV15cInvoicePaymentMethodDiscountImport",GXType.Decimal,18,2) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00493;
          prmH00493 = new Object[] {
          new ParDef("@AV11pInvoiceId",GXType.Int32,6,0) ,
          new ParDef("@AV6cInvoicePaymentMethodId",GXType.Int32,6,0) ,
          new ParDef("@AV7cPaymentMethodId",GXType.Int32,6,0) ,
          new ParDef("@AV8cInvoicePaymentMethodImport",GXType.Decimal,18,2) ,
          new ParDef("@AV14cInvoicePaymentMethodRechargeImport",GXType.Decimal,18,2) ,
          new ParDef("@AV15cInvoicePaymentMethodDiscountImport",GXType.Decimal,18,2)
          };
          def= new CursorDef[] {
              new CursorDef("H00492", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00492,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00493", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00493,1, GxCacheFrequency.OFF ,false,false )
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
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
