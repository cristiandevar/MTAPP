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
   public class gx0080 : GXDataArea
   {
      public gx0080( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public gx0080( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out int aP0_pInvoiceDetailId )
      {
         this.AV13pInvoiceDetailId = 0 ;
         executePrivate();
         aP0_pInvoiceDetailId=this.AV13pInvoiceDetailId;
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
            gxfirstwebparm = GetFirstPar( "pInvoiceDetailId");
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
               gxfirstwebparm = GetFirstPar( "pInvoiceDetailId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pInvoiceDetailId");
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
               AV13pInvoiceDetailId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV13pInvoiceDetailId", StringUtil.LTrimStr( (decimal)(AV13pInvoiceDetailId), 6, 0));
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
         nRC_GXsfl_84 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_84"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_84_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_84_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_84_idx = GetPar( "sGXsfl_84_idx");
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
         AV6cInvoiceDetailId = (int)(Math.Round(NumberUtil.Val( GetPar( "cInvoiceDetailId"), "."), 18, MidpointRounding.ToEven));
         AV7cInvoiceId = (int)(Math.Round(NumberUtil.Val( GetPar( "cInvoiceId"), "."), 18, MidpointRounding.ToEven));
         AV8cProductId = (int)(Math.Round(NumberUtil.Val( GetPar( "cProductId"), "."), 18, MidpointRounding.ToEven));
         AV9cInvoiceDetailQuantity = (int)(Math.Round(NumberUtil.Val( GetPar( "cInvoiceDetailQuantity"), "."), 18, MidpointRounding.ToEven));
         AV10cInvoiceDetailHistoricalPrice = NumberUtil.Val( GetPar( "cInvoiceDetailHistoricalPrice"), ".");
         AV11cInvoiceDetailCreatedDate = context.localUtil.ParseDateParm( GetPar( "cInvoiceDetailCreatedDate"));
         AV12cInvoiceDetailModifiedDate = context.localUtil.ParseDateParm( GetPar( "cInvoiceDetailModifiedDate"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cInvoiceDetailId, AV7cInvoiceId, AV8cProductId, AV9cInvoiceDetailQuantity, AV10cInvoiceDetailHistoricalPrice, AV11cInvoiceDetailCreatedDate, AV12cInvoiceDetailModifiedDate) ;
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
         PA0A2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0A2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0080.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pInvoiceDetailId,6,0))}, new string[] {"pInvoiceDetailId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCINVOICEDETAILID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cInvoiceDetailId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCINVOICEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cInvoiceId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCPRODUCTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cProductId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCINVOICEDETAILQUANTITY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9cInvoiceDetailQuantity), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCINVOICEDETAILHISTORICALPRICE", StringUtil.LTrim( StringUtil.NToC( AV10cInvoiceDetailHistoricalPrice, 10, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCINVOICEDETAILCREATEDDATE", context.localUtil.Format(AV11cInvoiceDetailCreatedDate, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vCINVOICEDETAILMODIFIEDDATE", context.localUtil.Format(AV12cInvoiceDetailModifiedDate, "99/99/99"));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPINVOICEDETAILID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pInvoiceDetailId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "INVOICEDETAILIDFILTERCONTAINER_Class", StringUtil.RTrim( divInvoicedetailidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "INVOICEIDFILTERCONTAINER_Class", StringUtil.RTrim( divInvoiceidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PRODUCTIDFILTERCONTAINER_Class", StringUtil.RTrim( divProductidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "INVOICEDETAILQUANTITYFILTERCONTAINER_Class", StringUtil.RTrim( divInvoicedetailquantityfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "INVOICEDETAILHISTORICALPRICEFILTERCONTAINER_Class", StringUtil.RTrim( divInvoicedetailhistoricalpricefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "INVOICEDETAILCREATEDDATEFILTERCONTAINER_Class", StringUtil.RTrim( divInvoicedetailcreateddatefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "INVOICEDETAILMODIFIEDDATEFILTERCONTAINER_Class", StringUtil.RTrim( divInvoicedetailmodifieddatefiltercontainer_Class));
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
            WE0A2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0A2( ) ;
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
         return formatLink("gx0080.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pInvoiceDetailId,6,0))}, new string[] {"pInvoiceDetailId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx0080" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List Invoice Detail" ;
      }

      protected void WB0A0( )
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
            GxWebStd.gx_div_start( context, divInvoicedetailidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divInvoicedetailidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblinvoicedetailidfilter_Internalname, "Invoice Detail Id", "", "", lblLblinvoicedetailidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e110a1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0080.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCinvoicedetailid_Internalname, "Invoice Detail Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCinvoicedetailid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cInvoiceDetailId), 6, 0, ".", "")), StringUtil.LTrim( ((edtavCinvoicedetailid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cInvoiceDetailId), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV6cInvoiceDetailId), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCinvoicedetailid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCinvoicedetailid_Visible, edtavCinvoicedetailid_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx0080.htm");
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
            GxWebStd.gx_div_start( context, divInvoiceidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divInvoiceidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblinvoiceidfilter_Internalname, "Invoice Id", "", "", lblLblinvoiceidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e120a1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0080.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCinvoiceid_Internalname, "Invoice Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCinvoiceid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cInvoiceId), 6, 0, ".", "")), StringUtil.LTrim( ((edtavCinvoiceid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV7cInvoiceId), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV7cInvoiceId), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCinvoiceid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCinvoiceid_Visible, edtavCinvoiceid_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx0080.htm");
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
            GxWebStd.gx_div_start( context, divProductidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divProductidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblproductidfilter_Internalname, "Product Id", "", "", lblLblproductidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e130a1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0080.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCproductid_Internalname, "Product Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCproductid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cProductId), 6, 0, ".", "")), StringUtil.LTrim( ((edtavCproductid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV8cProductId), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV8cProductId), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCproductid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCproductid_Visible, edtavCproductid_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx0080.htm");
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
            GxWebStd.gx_div_start( context, divInvoicedetailquantityfiltercontainer_Internalname, 1, 0, "px", 0, "px", divInvoicedetailquantityfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblinvoicedetailquantityfilter_Internalname, "Invoice Detail Quantity", "", "", lblLblinvoicedetailquantityfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e140a1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0080.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCinvoicedetailquantity_Internalname, "Invoice Detail Quantity", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCinvoicedetailquantity_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9cInvoiceDetailQuantity), 6, 0, ".", "")), StringUtil.LTrim( ((edtavCinvoicedetailquantity_Enabled!=0) ? context.localUtil.Format( (decimal)(AV9cInvoiceDetailQuantity), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV9cInvoiceDetailQuantity), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCinvoicedetailquantity_Jsonclick, 0, "Attribute", "", "", "", "", edtavCinvoicedetailquantity_Visible, edtavCinvoicedetailquantity_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx0080.htm");
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
            GxWebStd.gx_div_start( context, divInvoicedetailhistoricalpricefiltercontainer_Internalname, 1, 0, "px", 0, "px", divInvoicedetailhistoricalpricefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblinvoicedetailhistoricalpricefilter_Internalname, "Invoice Detail Historical Price", "", "", lblLblinvoicedetailhistoricalpricefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e150a1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0080.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCinvoicedetailhistoricalprice_Internalname, "Invoice Detail Historical Price", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCinvoicedetailhistoricalprice_Internalname, StringUtil.LTrim( StringUtil.NToC( AV10cInvoiceDetailHistoricalPrice, 10, 2, ".", "")), StringUtil.LTrim( ((edtavCinvoicedetailhistoricalprice_Enabled!=0) ? context.localUtil.Format( AV10cInvoiceDetailHistoricalPrice, "ZZZZZZ9.99") : context.localUtil.Format( AV10cInvoiceDetailHistoricalPrice, "ZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCinvoicedetailhistoricalprice_Jsonclick, 0, "Attribute", "", "", "", "", edtavCinvoicedetailhistoricalprice_Visible, edtavCinvoicedetailhistoricalprice_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx0080.htm");
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
            GxWebStd.gx_div_start( context, divInvoicedetailcreateddatefiltercontainer_Internalname, 1, 0, "px", 0, "px", divInvoicedetailcreateddatefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblinvoicedetailcreateddatefilter_Internalname, "Invoice Detail Created Date", "", "", lblLblinvoicedetailcreateddatefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e160a1_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0080.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCinvoicedetailcreateddate_Internalname, "Invoice Detail Created Date", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCinvoicedetailcreateddate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCinvoicedetailcreateddate_Internalname, context.localUtil.Format(AV11cInvoiceDetailCreatedDate, "99/99/99"), context.localUtil.Format( AV11cInvoiceDetailCreatedDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCinvoicedetailcreateddate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCinvoicedetailcreateddate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx0080.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            GxWebStd.gx_div_start( context, divInvoicedetailmodifieddatefiltercontainer_Internalname, 1, 0, "px", 0, "px", divInvoicedetailmodifieddatefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblinvoicedetailmodifieddatefilter_Internalname, "Invoice Detail Modified Date", "", "", lblLblinvoicedetailmodifieddatefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e170a1_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0080.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCinvoicedetailmodifieddate_Internalname, "Invoice Detail Modified Date", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCinvoicedetailmodifieddate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCinvoicedetailmodifieddate_Internalname, context.localUtil.Format(AV12cInvoiceDetailModifiedDate, "99/99/99"), context.localUtil.Format( AV12cInvoiceDetailModifiedDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCinvoicedetailmodifieddate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCinvoicedetailmodifieddate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx0080.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e180a1_client"+"'", TempTags, "", 2, "HLP_Gx0080.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl84( ) ;
         }
         if ( wbEnd == 84 )
         {
            wbEnd = 0;
            nRC_GXsfl_84 = (int)(nGXsfl_84_idx-1);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0080.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 84 )
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

      protected void START0A2( )
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
            Form.Meta.addItem("description", "Selection List Invoice Detail", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0A0( ) ;
      }

      protected void WS0A2( )
      {
         START0A2( ) ;
         EVT0A2( ) ;
      }

      protected void EVT0A2( )
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
                              nGXsfl_84_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
                              SubsflControlProps_842( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV17Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_84_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A25InvoiceDetailId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtInvoiceDetailId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A20InvoiceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtInvoiceId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A15ProductId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtProductId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A26InvoiceDetailQuantity = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtInvoiceDetailQuantity_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A27InvoiceDetailHistoricalPrice = context.localUtil.CToN( cgiGet( edtInvoiceDetailHistoricalPrice_Internalname), ".", ",");
                              A42InvoiceDetailCreatedDate = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtInvoiceDetailCreatedDate_Internalname), 0));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E190A2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E200A2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cinvoicedetailid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCINVOICEDETAILID"), ".", ",") != Convert.ToDecimal( AV6cInvoiceDetailId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cinvoiceid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCINVOICEID"), ".", ",") != Convert.ToDecimal( AV7cInvoiceId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cproductid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPRODUCTID"), ".", ",") != Convert.ToDecimal( AV8cProductId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cinvoicedetailquantity Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCINVOICEDETAILQUANTITY"), ".", ",") != Convert.ToDecimal( AV9cInvoiceDetailQuantity )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cinvoicedetailhistoricalprice Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCINVOICEDETAILHISTORICALPRICE"), ".", ",") != AV10cInvoiceDetailHistoricalPrice )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cinvoicedetailcreateddate Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCINVOICEDETAILCREATEDDATE"), 0) != AV11cInvoiceDetailCreatedDate )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cinvoicedetailmodifieddate Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCINVOICEDETAILMODIFIEDDATE"), 0) != AV12cInvoiceDetailModifiedDate )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E210A2 ();
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

      protected void WE0A2( )
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

      protected void PA0A2( )
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
         SubsflControlProps_842( ) ;
         while ( nGXsfl_84_idx <= nRC_GXsfl_84 )
         {
            sendrow_842( ) ;
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        int AV6cInvoiceDetailId ,
                                        int AV7cInvoiceId ,
                                        int AV8cProductId ,
                                        int AV9cInvoiceDetailQuantity ,
                                        decimal AV10cInvoiceDetailHistoricalPrice ,
                                        DateTime AV11cInvoiceDetailCreatedDate ,
                                        DateTime AV12cInvoiceDetailModifiedDate )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF0A2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_INVOICEDETAILID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A25InvoiceDetailId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "INVOICEDETAILID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A25InvoiceDetailId), 6, 0, ".", "")));
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
         RF0A2( ) ;
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

      protected void RF0A2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 84;
         nGXsfl_84_idx = 1;
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         bGXsfl_84_Refreshing = true;
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
            SubsflControlProps_842( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV7cInvoiceId ,
                                                 AV8cProductId ,
                                                 AV9cInvoiceDetailQuantity ,
                                                 AV10cInvoiceDetailHistoricalPrice ,
                                                 AV11cInvoiceDetailCreatedDate ,
                                                 AV12cInvoiceDetailModifiedDate ,
                                                 A20InvoiceId ,
                                                 A15ProductId ,
                                                 A26InvoiceDetailQuantity ,
                                                 A27InvoiceDetailHistoricalPrice ,
                                                 A42InvoiceDetailCreatedDate ,
                                                 A43InvoiceDetailModifiedDate ,
                                                 AV6cInvoiceDetailId } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DECIMAL,
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT
                                                 }
            });
            /* Using cursor H000A2 */
            pr_default.execute(0, new Object[] {AV6cInvoiceDetailId, AV7cInvoiceId, AV8cProductId, AV9cInvoiceDetailQuantity, AV10cInvoiceDetailHistoricalPrice, AV11cInvoiceDetailCreatedDate, AV12cInvoiceDetailModifiedDate, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A43InvoiceDetailModifiedDate = H000A2_A43InvoiceDetailModifiedDate[0];
               A42InvoiceDetailCreatedDate = H000A2_A42InvoiceDetailCreatedDate[0];
               A27InvoiceDetailHistoricalPrice = H000A2_A27InvoiceDetailHistoricalPrice[0];
               A26InvoiceDetailQuantity = H000A2_A26InvoiceDetailQuantity[0];
               A15ProductId = H000A2_A15ProductId[0];
               A20InvoiceId = H000A2_A20InvoiceId[0];
               A25InvoiceDetailId = H000A2_A25InvoiceDetailId[0];
               /* Execute user event: Load */
               E200A2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB0A0( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0A2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_INVOICEDETAILID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A25InvoiceDetailId), "ZZZZZ9"), context));
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
                                              AV7cInvoiceId ,
                                              AV8cProductId ,
                                              AV9cInvoiceDetailQuantity ,
                                              AV10cInvoiceDetailHistoricalPrice ,
                                              AV11cInvoiceDetailCreatedDate ,
                                              AV12cInvoiceDetailModifiedDate ,
                                              A20InvoiceId ,
                                              A15ProductId ,
                                              A26InvoiceDetailQuantity ,
                                              A27InvoiceDetailHistoricalPrice ,
                                              A42InvoiceDetailCreatedDate ,
                                              A43InvoiceDetailModifiedDate ,
                                              AV6cInvoiceDetailId } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DECIMAL,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT
                                              }
         });
         /* Using cursor H000A3 */
         pr_default.execute(1, new Object[] {AV6cInvoiceDetailId, AV7cInvoiceId, AV8cProductId, AV9cInvoiceDetailQuantity, AV10cInvoiceDetailHistoricalPrice, AV11cInvoiceDetailCreatedDate, AV12cInvoiceDetailModifiedDate});
         GRID1_nRecordCount = H000A3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cInvoiceDetailId, AV7cInvoiceId, AV8cProductId, AV9cInvoiceDetailQuantity, AV10cInvoiceDetailHistoricalPrice, AV11cInvoiceDetailCreatedDate, AV12cInvoiceDetailModifiedDate) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cInvoiceDetailId, AV7cInvoiceId, AV8cProductId, AV9cInvoiceDetailQuantity, AV10cInvoiceDetailHistoricalPrice, AV11cInvoiceDetailCreatedDate, AV12cInvoiceDetailModifiedDate) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cInvoiceDetailId, AV7cInvoiceId, AV8cProductId, AV9cInvoiceDetailQuantity, AV10cInvoiceDetailHistoricalPrice, AV11cInvoiceDetailCreatedDate, AV12cInvoiceDetailModifiedDate) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cInvoiceDetailId, AV7cInvoiceId, AV8cProductId, AV9cInvoiceDetailQuantity, AV10cInvoiceDetailHistoricalPrice, AV11cInvoiceDetailCreatedDate, AV12cInvoiceDetailModifiedDate) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cInvoiceDetailId, AV7cInvoiceId, AV8cProductId, AV9cInvoiceDetailQuantity, AV10cInvoiceDetailHistoricalPrice, AV11cInvoiceDetailCreatedDate, AV12cInvoiceDetailModifiedDate) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0A0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E190A2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_84 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_84"), ".", ","), 18, MidpointRounding.ToEven));
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCinvoicedetailid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCinvoicedetailid_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCINVOICEDETAILID");
               GX_FocusControl = edtavCinvoicedetailid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cInvoiceDetailId = 0;
               AssignAttri("", false, "AV6cInvoiceDetailId", StringUtil.LTrimStr( (decimal)(AV6cInvoiceDetailId), 6, 0));
            }
            else
            {
               AV6cInvoiceDetailId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCinvoicedetailid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cInvoiceDetailId", StringUtil.LTrimStr( (decimal)(AV6cInvoiceDetailId), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCinvoiceid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCinvoiceid_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCINVOICEID");
               GX_FocusControl = edtavCinvoiceid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cInvoiceId = 0;
               AssignAttri("", false, "AV7cInvoiceId", StringUtil.LTrimStr( (decimal)(AV7cInvoiceId), 6, 0));
            }
            else
            {
               AV7cInvoiceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCinvoiceid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7cInvoiceId", StringUtil.LTrimStr( (decimal)(AV7cInvoiceId), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCproductid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCproductid_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCPRODUCTID");
               GX_FocusControl = edtavCproductid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cProductId = 0;
               AssignAttri("", false, "AV8cProductId", StringUtil.LTrimStr( (decimal)(AV8cProductId), 6, 0));
            }
            else
            {
               AV8cProductId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCproductid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV8cProductId", StringUtil.LTrimStr( (decimal)(AV8cProductId), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCinvoicedetailquantity_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCinvoicedetailquantity_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCINVOICEDETAILQUANTITY");
               GX_FocusControl = edtavCinvoicedetailquantity_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9cInvoiceDetailQuantity = 0;
               AssignAttri("", false, "AV9cInvoiceDetailQuantity", StringUtil.LTrimStr( (decimal)(AV9cInvoiceDetailQuantity), 6, 0));
            }
            else
            {
               AV9cInvoiceDetailQuantity = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCinvoicedetailquantity_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV9cInvoiceDetailQuantity", StringUtil.LTrimStr( (decimal)(AV9cInvoiceDetailQuantity), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCinvoicedetailhistoricalprice_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCinvoicedetailhistoricalprice_Internalname), ".", ",") > 9999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCINVOICEDETAILHISTORICALPRICE");
               GX_FocusControl = edtavCinvoicedetailhistoricalprice_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cInvoiceDetailHistoricalPrice = 0;
               AssignAttri("", false, "AV10cInvoiceDetailHistoricalPrice", StringUtil.LTrimStr( AV10cInvoiceDetailHistoricalPrice, 10, 2));
            }
            else
            {
               AV10cInvoiceDetailHistoricalPrice = context.localUtil.CToN( cgiGet( edtavCinvoicedetailhistoricalprice_Internalname), ".", ",");
               AssignAttri("", false, "AV10cInvoiceDetailHistoricalPrice", StringUtil.LTrimStr( AV10cInvoiceDetailHistoricalPrice, 10, 2));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCinvoicedetailcreateddate_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Invoice Detail Created Date"}), 1, "vCINVOICEDETAILCREATEDDATE");
               GX_FocusControl = edtavCinvoicedetailcreateddate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cInvoiceDetailCreatedDate = DateTime.MinValue;
               AssignAttri("", false, "AV11cInvoiceDetailCreatedDate", context.localUtil.Format(AV11cInvoiceDetailCreatedDate, "99/99/99"));
            }
            else
            {
               AV11cInvoiceDetailCreatedDate = context.localUtil.CToD( cgiGet( edtavCinvoicedetailcreateddate_Internalname), 1);
               AssignAttri("", false, "AV11cInvoiceDetailCreatedDate", context.localUtil.Format(AV11cInvoiceDetailCreatedDate, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCinvoicedetailmodifieddate_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Invoice Detail Modified Date"}), 1, "vCINVOICEDETAILMODIFIEDDATE");
               GX_FocusControl = edtavCinvoicedetailmodifieddate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12cInvoiceDetailModifiedDate = DateTime.MinValue;
               AssignAttri("", false, "AV12cInvoiceDetailModifiedDate", context.localUtil.Format(AV12cInvoiceDetailModifiedDate, "99/99/99"));
            }
            else
            {
               AV12cInvoiceDetailModifiedDate = context.localUtil.CToD( cgiGet( edtavCinvoicedetailmodifieddate_Internalname), 1);
               AssignAttri("", false, "AV12cInvoiceDetailModifiedDate", context.localUtil.Format(AV12cInvoiceDetailModifiedDate, "99/99/99"));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCINVOICEDETAILID"), ".", ",") != Convert.ToDecimal( AV6cInvoiceDetailId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCINVOICEID"), ".", ",") != Convert.ToDecimal( AV7cInvoiceId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPRODUCTID"), ".", ",") != Convert.ToDecimal( AV8cProductId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCINVOICEDETAILQUANTITY"), ".", ",") != Convert.ToDecimal( AV9cInvoiceDetailQuantity )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCINVOICEDETAILHISTORICALPRICE"), ".", ",") != AV10cInvoiceDetailHistoricalPrice )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCINVOICEDETAILCREATEDDATE"), 1) ) != DateTimeUtil.ResetTime ( AV11cInvoiceDetailCreatedDate ) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCINVOICEDETAILMODIFIEDDATE"), 1) ) != DateTimeUtil.ResetTime ( AV12cInvoiceDetailModifiedDate ) )
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
         E190A2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E190A2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Selection List %1", "Invoice Detail", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E200A2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "selectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV17Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )));
         sendrow_842( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_84_Refreshing )
         {
            DoAjaxLoad(84, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E210A2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E210A2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pInvoiceDetailId = A25InvoiceDetailId;
         AssignAttri("", false, "AV13pInvoiceDetailId", StringUtil.LTrimStr( (decimal)(AV13pInvoiceDetailId), 6, 0));
         context.setWebReturnParms(new Object[] {(int)AV13pInvoiceDetailId});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pInvoiceDetailId"});
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
         AV13pInvoiceDetailId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV13pInvoiceDetailId", StringUtil.LTrimStr( (decimal)(AV13pInvoiceDetailId), 6, 0));
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
         PA0A2( ) ;
         WS0A2( ) ;
         WE0A2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20231122039176", true, true);
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
         context.AddJavascriptSource("gx0080.js", "?20231122039177", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtInvoiceDetailId_Internalname = "INVOICEDETAILID_"+sGXsfl_84_idx;
         edtInvoiceId_Internalname = "INVOICEID_"+sGXsfl_84_idx;
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_84_idx;
         edtInvoiceDetailQuantity_Internalname = "INVOICEDETAILQUANTITY_"+sGXsfl_84_idx;
         edtInvoiceDetailHistoricalPrice_Internalname = "INVOICEDETAILHISTORICALPRICE_"+sGXsfl_84_idx;
         edtInvoiceDetailCreatedDate_Internalname = "INVOICEDETAILCREATEDDATE_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtInvoiceDetailId_Internalname = "INVOICEDETAILID_"+sGXsfl_84_fel_idx;
         edtInvoiceId_Internalname = "INVOICEID_"+sGXsfl_84_fel_idx;
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_84_fel_idx;
         edtInvoiceDetailQuantity_Internalname = "INVOICEDETAILQUANTITY_"+sGXsfl_84_fel_idx;
         edtInvoiceDetailHistoricalPrice_Internalname = "INVOICEDETAILHISTORICALPRICE_"+sGXsfl_84_fel_idx;
         edtInvoiceDetailCreatedDate_Internalname = "INVOICEDETAILCREATEDDATE_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         SubsflControlProps_842( ) ;
         WB0A0( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_84_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_84_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_84_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A25InvoiceDetailId), 6, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_84_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV17Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV17Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInvoiceDetailId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A25InvoiceDetailId), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A25InvoiceDetailId), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInvoiceDetailId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInvoiceId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A20InvoiceId), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A20InvoiceId), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInvoiceId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A15ProductId), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtInvoiceDetailQuantity_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A25InvoiceDetailId), 6, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtInvoiceDetailQuantity_Internalname, "Link", edtInvoiceDetailQuantity_Link, !bGXsfl_84_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInvoiceDetailQuantity_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A26InvoiceDetailQuantity), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A26InvoiceDetailQuantity), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtInvoiceDetailQuantity_Link,(string)"",(string)"",(string)"",(string)edtInvoiceDetailQuantity_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInvoiceDetailHistoricalPrice_Internalname,StringUtil.LTrim( StringUtil.NToC( A27InvoiceDetailHistoricalPrice, 10, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A27InvoiceDetailHistoricalPrice, "ZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInvoiceDetailHistoricalPrice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"Price",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInvoiceDetailCreatedDate_Internalname,context.localUtil.Format(A42InvoiceDetailCreatedDate, "99/99/99"),context.localUtil.Format( A42InvoiceDetailCreatedDate, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInvoiceDetailCreatedDate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes0A2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         /* End function sendrow_842 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl84( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"84\">") ;
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
            context.SendWebValue( "Detail Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Invoice Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Product Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Detail Quantity") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Historical Price") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Created Date") ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A25InvoiceDetailId), 6, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A20InvoiceId), 6, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A26InvoiceDetailQuantity), 6, 0, ".", ""))));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtInvoiceDetailQuantity_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A27InvoiceDetailHistoricalPrice, 10, 2, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A42InvoiceDetailCreatedDate, "99/99/99")));
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
         lblLblinvoicedetailidfilter_Internalname = "LBLINVOICEDETAILIDFILTER";
         edtavCinvoicedetailid_Internalname = "vCINVOICEDETAILID";
         divInvoicedetailidfiltercontainer_Internalname = "INVOICEDETAILIDFILTERCONTAINER";
         lblLblinvoiceidfilter_Internalname = "LBLINVOICEIDFILTER";
         edtavCinvoiceid_Internalname = "vCINVOICEID";
         divInvoiceidfiltercontainer_Internalname = "INVOICEIDFILTERCONTAINER";
         lblLblproductidfilter_Internalname = "LBLPRODUCTIDFILTER";
         edtavCproductid_Internalname = "vCPRODUCTID";
         divProductidfiltercontainer_Internalname = "PRODUCTIDFILTERCONTAINER";
         lblLblinvoicedetailquantityfilter_Internalname = "LBLINVOICEDETAILQUANTITYFILTER";
         edtavCinvoicedetailquantity_Internalname = "vCINVOICEDETAILQUANTITY";
         divInvoicedetailquantityfiltercontainer_Internalname = "INVOICEDETAILQUANTITYFILTERCONTAINER";
         lblLblinvoicedetailhistoricalpricefilter_Internalname = "LBLINVOICEDETAILHISTORICALPRICEFILTER";
         edtavCinvoicedetailhistoricalprice_Internalname = "vCINVOICEDETAILHISTORICALPRICE";
         divInvoicedetailhistoricalpricefiltercontainer_Internalname = "INVOICEDETAILHISTORICALPRICEFILTERCONTAINER";
         lblLblinvoicedetailcreateddatefilter_Internalname = "LBLINVOICEDETAILCREATEDDATEFILTER";
         edtavCinvoicedetailcreateddate_Internalname = "vCINVOICEDETAILCREATEDDATE";
         divInvoicedetailcreateddatefiltercontainer_Internalname = "INVOICEDETAILCREATEDDATEFILTERCONTAINER";
         lblLblinvoicedetailmodifieddatefilter_Internalname = "LBLINVOICEDETAILMODIFIEDDATEFILTER";
         edtavCinvoicedetailmodifieddate_Internalname = "vCINVOICEDETAILMODIFIEDDATE";
         divInvoicedetailmodifieddatefiltercontainer_Internalname = "INVOICEDETAILMODIFIEDDATEFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtInvoiceDetailId_Internalname = "INVOICEDETAILID";
         edtInvoiceId_Internalname = "INVOICEID";
         edtProductId_Internalname = "PRODUCTID";
         edtInvoiceDetailQuantity_Internalname = "INVOICEDETAILQUANTITY";
         edtInvoiceDetailHistoricalPrice_Internalname = "INVOICEDETAILHISTORICALPRICE";
         edtInvoiceDetailCreatedDate_Internalname = "INVOICEDETAILCREATEDDATE";
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
         edtInvoiceDetailCreatedDate_Jsonclick = "";
         edtInvoiceDetailHistoricalPrice_Jsonclick = "";
         edtInvoiceDetailQuantity_Jsonclick = "";
         edtInvoiceDetailQuantity_Link = "";
         edtProductId_Jsonclick = "";
         edtInvoiceId_Jsonclick = "";
         edtInvoiceDetailId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCinvoicedetailmodifieddate_Jsonclick = "";
         edtavCinvoicedetailmodifieddate_Enabled = 1;
         edtavCinvoicedetailcreateddate_Jsonclick = "";
         edtavCinvoicedetailcreateddate_Enabled = 1;
         edtavCinvoicedetailhistoricalprice_Jsonclick = "";
         edtavCinvoicedetailhistoricalprice_Enabled = 1;
         edtavCinvoicedetailhistoricalprice_Visible = 1;
         edtavCinvoicedetailquantity_Jsonclick = "";
         edtavCinvoicedetailquantity_Enabled = 1;
         edtavCinvoicedetailquantity_Visible = 1;
         edtavCproductid_Jsonclick = "";
         edtavCproductid_Enabled = 1;
         edtavCproductid_Visible = 1;
         edtavCinvoiceid_Jsonclick = "";
         edtavCinvoiceid_Enabled = 1;
         edtavCinvoiceid_Visible = 1;
         edtavCinvoicedetailid_Jsonclick = "";
         edtavCinvoicedetailid_Enabled = 1;
         edtavCinvoicedetailid_Visible = 1;
         divInvoicedetailmodifieddatefiltercontainer_Class = "AdvancedContainerItem";
         divInvoicedetailcreateddatefiltercontainer_Class = "AdvancedContainerItem";
         divInvoicedetailhistoricalpricefiltercontainer_Class = "AdvancedContainerItem";
         divInvoicedetailquantityfiltercontainer_Class = "AdvancedContainerItem";
         divProductidfiltercontainer_Class = "AdvancedContainerItem";
         divInvoiceidfiltercontainer_Class = "AdvancedContainerItem";
         divInvoicedetailidfiltercontainer_Class = "AdvancedContainerItem";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List Invoice Detail";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cInvoiceDetailId',fld:'vCINVOICEDETAILID',pic:'ZZZZZ9'},{av:'AV7cInvoiceId',fld:'vCINVOICEID',pic:'ZZZZZ9'},{av:'AV8cProductId',fld:'vCPRODUCTID',pic:'ZZZZZ9'},{av:'AV9cInvoiceDetailQuantity',fld:'vCINVOICEDETAILQUANTITY',pic:'ZZZZZ9'},{av:'AV10cInvoiceDetailHistoricalPrice',fld:'vCINVOICEDETAILHISTORICALPRICE',pic:'ZZZZZZ9.99'},{av:'AV11cInvoiceDetailCreatedDate',fld:'vCINVOICEDETAILCREATEDDATE',pic:''},{av:'AV12cInvoiceDetailModifiedDate',fld:'vCINVOICEDETAILMODIFIEDDATE',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E180A1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLINVOICEDETAILIDFILTER.CLICK","{handler:'E110A1',iparms:[{av:'divInvoicedetailidfiltercontainer_Class',ctrl:'INVOICEDETAILIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLINVOICEDETAILIDFILTER.CLICK",",oparms:[{av:'divInvoicedetailidfiltercontainer_Class',ctrl:'INVOICEDETAILIDFILTERCONTAINER',prop:'Class'},{av:'edtavCinvoicedetailid_Visible',ctrl:'vCINVOICEDETAILID',prop:'Visible'}]}");
         setEventMetadata("LBLINVOICEIDFILTER.CLICK","{handler:'E120A1',iparms:[{av:'divInvoiceidfiltercontainer_Class',ctrl:'INVOICEIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLINVOICEIDFILTER.CLICK",",oparms:[{av:'divInvoiceidfiltercontainer_Class',ctrl:'INVOICEIDFILTERCONTAINER',prop:'Class'},{av:'edtavCinvoiceid_Visible',ctrl:'vCINVOICEID',prop:'Visible'}]}");
         setEventMetadata("LBLPRODUCTIDFILTER.CLICK","{handler:'E130A1',iparms:[{av:'divProductidfiltercontainer_Class',ctrl:'PRODUCTIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPRODUCTIDFILTER.CLICK",",oparms:[{av:'divProductidfiltercontainer_Class',ctrl:'PRODUCTIDFILTERCONTAINER',prop:'Class'},{av:'edtavCproductid_Visible',ctrl:'vCPRODUCTID',prop:'Visible'}]}");
         setEventMetadata("LBLINVOICEDETAILQUANTITYFILTER.CLICK","{handler:'E140A1',iparms:[{av:'divInvoicedetailquantityfiltercontainer_Class',ctrl:'INVOICEDETAILQUANTITYFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLINVOICEDETAILQUANTITYFILTER.CLICK",",oparms:[{av:'divInvoicedetailquantityfiltercontainer_Class',ctrl:'INVOICEDETAILQUANTITYFILTERCONTAINER',prop:'Class'},{av:'edtavCinvoicedetailquantity_Visible',ctrl:'vCINVOICEDETAILQUANTITY',prop:'Visible'}]}");
         setEventMetadata("LBLINVOICEDETAILHISTORICALPRICEFILTER.CLICK","{handler:'E150A1',iparms:[{av:'divInvoicedetailhistoricalpricefiltercontainer_Class',ctrl:'INVOICEDETAILHISTORICALPRICEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLINVOICEDETAILHISTORICALPRICEFILTER.CLICK",",oparms:[{av:'divInvoicedetailhistoricalpricefiltercontainer_Class',ctrl:'INVOICEDETAILHISTORICALPRICEFILTERCONTAINER',prop:'Class'},{av:'edtavCinvoicedetailhistoricalprice_Visible',ctrl:'vCINVOICEDETAILHISTORICALPRICE',prop:'Visible'}]}");
         setEventMetadata("LBLINVOICEDETAILCREATEDDATEFILTER.CLICK","{handler:'E160A1',iparms:[{av:'divInvoicedetailcreateddatefiltercontainer_Class',ctrl:'INVOICEDETAILCREATEDDATEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLINVOICEDETAILCREATEDDATEFILTER.CLICK",",oparms:[{av:'divInvoicedetailcreateddatefiltercontainer_Class',ctrl:'INVOICEDETAILCREATEDDATEFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLINVOICEDETAILMODIFIEDDATEFILTER.CLICK","{handler:'E170A1',iparms:[{av:'divInvoicedetailmodifieddatefiltercontainer_Class',ctrl:'INVOICEDETAILMODIFIEDDATEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLINVOICEDETAILMODIFIEDDATEFILTER.CLICK",",oparms:[{av:'divInvoicedetailmodifieddatefiltercontainer_Class',ctrl:'INVOICEDETAILMODIFIEDDATEFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("ENTER","{handler:'E210A2',iparms:[{av:'A25InvoiceDetailId',fld:'INVOICEDETAILID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pInvoiceDetailId',fld:'vPINVOICEDETAILID',pic:'ZZZZZ9'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cInvoiceDetailId',fld:'vCINVOICEDETAILID',pic:'ZZZZZ9'},{av:'AV7cInvoiceId',fld:'vCINVOICEID',pic:'ZZZZZ9'},{av:'AV8cProductId',fld:'vCPRODUCTID',pic:'ZZZZZ9'},{av:'AV9cInvoiceDetailQuantity',fld:'vCINVOICEDETAILQUANTITY',pic:'ZZZZZ9'},{av:'AV10cInvoiceDetailHistoricalPrice',fld:'vCINVOICEDETAILHISTORICALPRICE',pic:'ZZZZZZ9.99'},{av:'AV11cInvoiceDetailCreatedDate',fld:'vCINVOICEDETAILCREATEDDATE',pic:''},{av:'AV12cInvoiceDetailModifiedDate',fld:'vCINVOICEDETAILMODIFIEDDATE',pic:''}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cInvoiceDetailId',fld:'vCINVOICEDETAILID',pic:'ZZZZZ9'},{av:'AV7cInvoiceId',fld:'vCINVOICEID',pic:'ZZZZZ9'},{av:'AV8cProductId',fld:'vCPRODUCTID',pic:'ZZZZZ9'},{av:'AV9cInvoiceDetailQuantity',fld:'vCINVOICEDETAILQUANTITY',pic:'ZZZZZ9'},{av:'AV10cInvoiceDetailHistoricalPrice',fld:'vCINVOICEDETAILHISTORICALPRICE',pic:'ZZZZZZ9.99'},{av:'AV11cInvoiceDetailCreatedDate',fld:'vCINVOICEDETAILCREATEDDATE',pic:''},{av:'AV12cInvoiceDetailModifiedDate',fld:'vCINVOICEDETAILMODIFIEDDATE',pic:''}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cInvoiceDetailId',fld:'vCINVOICEDETAILID',pic:'ZZZZZ9'},{av:'AV7cInvoiceId',fld:'vCINVOICEID',pic:'ZZZZZ9'},{av:'AV8cProductId',fld:'vCPRODUCTID',pic:'ZZZZZ9'},{av:'AV9cInvoiceDetailQuantity',fld:'vCINVOICEDETAILQUANTITY',pic:'ZZZZZ9'},{av:'AV10cInvoiceDetailHistoricalPrice',fld:'vCINVOICEDETAILHISTORICALPRICE',pic:'ZZZZZZ9.99'},{av:'AV11cInvoiceDetailCreatedDate',fld:'vCINVOICEDETAILCREATEDDATE',pic:''},{av:'AV12cInvoiceDetailModifiedDate',fld:'vCINVOICEDETAILMODIFIEDDATE',pic:''}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cInvoiceDetailId',fld:'vCINVOICEDETAILID',pic:'ZZZZZ9'},{av:'AV7cInvoiceId',fld:'vCINVOICEID',pic:'ZZZZZ9'},{av:'AV8cProductId',fld:'vCPRODUCTID',pic:'ZZZZZ9'},{av:'AV9cInvoiceDetailQuantity',fld:'vCINVOICEDETAILQUANTITY',pic:'ZZZZZ9'},{av:'AV10cInvoiceDetailHistoricalPrice',fld:'vCINVOICEDETAILHISTORICALPRICE',pic:'ZZZZZZ9.99'},{av:'AV11cInvoiceDetailCreatedDate',fld:'vCINVOICEDETAILCREATEDDATE',pic:''},{av:'AV12cInvoiceDetailModifiedDate',fld:'vCINVOICEDETAILMODIFIEDDATE',pic:''}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CINVOICEDETAILCREATEDDATE","{handler:'Validv_Cinvoicedetailcreateddate',iparms:[]");
         setEventMetadata("VALIDV_CINVOICEDETAILCREATEDDATE",",oparms:[]}");
         setEventMetadata("VALIDV_CINVOICEDETAILMODIFIEDDATE","{handler:'Validv_Cinvoicedetailmodifieddate',iparms:[]");
         setEventMetadata("VALIDV_CINVOICEDETAILMODIFIEDDATE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Invoicedetailcreateddate',iparms:[]");
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
         AV11cInvoiceDetailCreatedDate = DateTime.MinValue;
         AV12cInvoiceDetailModifiedDate = DateTime.MinValue;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblinvoicedetailidfilter_Jsonclick = "";
         TempTags = "";
         lblLblinvoiceidfilter_Jsonclick = "";
         lblLblproductidfilter_Jsonclick = "";
         lblLblinvoicedetailquantityfilter_Jsonclick = "";
         lblLblinvoicedetailhistoricalpricefilter_Jsonclick = "";
         lblLblinvoicedetailcreateddatefilter_Jsonclick = "";
         lblLblinvoicedetailmodifieddatefilter_Jsonclick = "";
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
         AV17Linkselection_GXI = "";
         A42InvoiceDetailCreatedDate = DateTime.MinValue;
         scmdbuf = "";
         A43InvoiceDetailModifiedDate = DateTime.MinValue;
         H000A2_A43InvoiceDetailModifiedDate = new DateTime[] {DateTime.MinValue} ;
         H000A2_A42InvoiceDetailCreatedDate = new DateTime[] {DateTime.MinValue} ;
         H000A2_A27InvoiceDetailHistoricalPrice = new decimal[1] ;
         H000A2_A26InvoiceDetailQuantity = new int[1] ;
         H000A2_A15ProductId = new int[1] ;
         H000A2_A20InvoiceId = new int[1] ;
         H000A2_A25InvoiceDetailId = new int[1] ;
         H000A3_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0080__default(),
            new Object[][] {
                new Object[] {
               H000A2_A43InvoiceDetailModifiedDate, H000A2_A42InvoiceDetailCreatedDate, H000A2_A27InvoiceDetailHistoricalPrice, H000A2_A26InvoiceDetailQuantity, H000A2_A15ProductId, H000A2_A20InvoiceId, H000A2_A25InvoiceDetailId
               }
               , new Object[] {
               H000A3_AGRID1_nRecordCount
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
      private int AV13pInvoiceDetailId ;
      private int nRC_GXsfl_84 ;
      private int subGrid1_Rows ;
      private int nGXsfl_84_idx=1 ;
      private int AV6cInvoiceDetailId ;
      private int AV7cInvoiceId ;
      private int AV8cProductId ;
      private int AV9cInvoiceDetailQuantity ;
      private int edtavCinvoicedetailid_Enabled ;
      private int edtavCinvoicedetailid_Visible ;
      private int edtavCinvoiceid_Enabled ;
      private int edtavCinvoiceid_Visible ;
      private int edtavCproductid_Enabled ;
      private int edtavCproductid_Visible ;
      private int edtavCinvoicedetailquantity_Enabled ;
      private int edtavCinvoicedetailquantity_Visible ;
      private int edtavCinvoicedetailhistoricalprice_Enabled ;
      private int edtavCinvoicedetailhistoricalprice_Visible ;
      private int edtavCinvoicedetailcreateddate_Enabled ;
      private int edtavCinvoicedetailmodifieddate_Enabled ;
      private int A25InvoiceDetailId ;
      private int A20InvoiceId ;
      private int A15ProductId ;
      private int A26InvoiceDetailQuantity ;
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
      private decimal AV10cInvoiceDetailHistoricalPrice ;
      private decimal A27InvoiceDetailHistoricalPrice ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divInvoicedetailidfiltercontainer_Class ;
      private string divInvoiceidfiltercontainer_Class ;
      private string divProductidfiltercontainer_Class ;
      private string divInvoicedetailquantityfiltercontainer_Class ;
      private string divInvoicedetailhistoricalpricefiltercontainer_Class ;
      private string divInvoicedetailcreateddatefiltercontainer_Class ;
      private string divInvoicedetailmodifieddatefiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_84_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divInvoicedetailidfiltercontainer_Internalname ;
      private string lblLblinvoicedetailidfilter_Internalname ;
      private string lblLblinvoicedetailidfilter_Jsonclick ;
      private string edtavCinvoicedetailid_Internalname ;
      private string TempTags ;
      private string edtavCinvoicedetailid_Jsonclick ;
      private string divInvoiceidfiltercontainer_Internalname ;
      private string lblLblinvoiceidfilter_Internalname ;
      private string lblLblinvoiceidfilter_Jsonclick ;
      private string edtavCinvoiceid_Internalname ;
      private string edtavCinvoiceid_Jsonclick ;
      private string divProductidfiltercontainer_Internalname ;
      private string lblLblproductidfilter_Internalname ;
      private string lblLblproductidfilter_Jsonclick ;
      private string edtavCproductid_Internalname ;
      private string edtavCproductid_Jsonclick ;
      private string divInvoicedetailquantityfiltercontainer_Internalname ;
      private string lblLblinvoicedetailquantityfilter_Internalname ;
      private string lblLblinvoicedetailquantityfilter_Jsonclick ;
      private string edtavCinvoicedetailquantity_Internalname ;
      private string edtavCinvoicedetailquantity_Jsonclick ;
      private string divInvoicedetailhistoricalpricefiltercontainer_Internalname ;
      private string lblLblinvoicedetailhistoricalpricefilter_Internalname ;
      private string lblLblinvoicedetailhistoricalpricefilter_Jsonclick ;
      private string edtavCinvoicedetailhistoricalprice_Internalname ;
      private string edtavCinvoicedetailhistoricalprice_Jsonclick ;
      private string divInvoicedetailcreateddatefiltercontainer_Internalname ;
      private string lblLblinvoicedetailcreateddatefilter_Internalname ;
      private string lblLblinvoicedetailcreateddatefilter_Jsonclick ;
      private string edtavCinvoicedetailcreateddate_Internalname ;
      private string edtavCinvoicedetailcreateddate_Jsonclick ;
      private string divInvoicedetailmodifieddatefiltercontainer_Internalname ;
      private string lblLblinvoicedetailmodifieddatefilter_Internalname ;
      private string lblLblinvoicedetailmodifieddatefilter_Jsonclick ;
      private string edtavCinvoicedetailmodifieddate_Internalname ;
      private string edtavCinvoicedetailmodifieddate_Jsonclick ;
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
      private string edtInvoiceDetailId_Internalname ;
      private string edtInvoiceId_Internalname ;
      private string edtProductId_Internalname ;
      private string edtInvoiceDetailQuantity_Internalname ;
      private string edtInvoiceDetailHistoricalPrice_Internalname ;
      private string edtInvoiceDetailCreatedDate_Internalname ;
      private string scmdbuf ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtInvoiceDetailId_Jsonclick ;
      private string edtInvoiceId_Jsonclick ;
      private string edtProductId_Jsonclick ;
      private string edtInvoiceDetailQuantity_Link ;
      private string edtInvoiceDetailQuantity_Jsonclick ;
      private string edtInvoiceDetailHistoricalPrice_Jsonclick ;
      private string edtInvoiceDetailCreatedDate_Jsonclick ;
      private string subGrid1_Header ;
      private DateTime AV11cInvoiceDetailCreatedDate ;
      private DateTime AV12cInvoiceDetailModifiedDate ;
      private DateTime A42InvoiceDetailCreatedDate ;
      private DateTime A43InvoiceDetailModifiedDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV17Linkselection_GXI ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] H000A2_A43InvoiceDetailModifiedDate ;
      private DateTime[] H000A2_A42InvoiceDetailCreatedDate ;
      private decimal[] H000A2_A27InvoiceDetailHistoricalPrice ;
      private int[] H000A2_A26InvoiceDetailQuantity ;
      private int[] H000A2_A15ProductId ;
      private int[] H000A2_A20InvoiceId ;
      private int[] H000A2_A25InvoiceDetailId ;
      private long[] H000A3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private int aP0_pInvoiceDetailId ;
      private GXWebForm Form ;
   }

   public class gx0080__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000A2( IGxContext context ,
                                             int AV7cInvoiceId ,
                                             int AV8cProductId ,
                                             int AV9cInvoiceDetailQuantity ,
                                             decimal AV10cInvoiceDetailHistoricalPrice ,
                                             DateTime AV11cInvoiceDetailCreatedDate ,
                                             DateTime AV12cInvoiceDetailModifiedDate ,
                                             int A20InvoiceId ,
                                             int A15ProductId ,
                                             int A26InvoiceDetailQuantity ,
                                             decimal A27InvoiceDetailHistoricalPrice ,
                                             DateTime A42InvoiceDetailCreatedDate ,
                                             DateTime A43InvoiceDetailModifiedDate ,
                                             int AV6cInvoiceDetailId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [InvoiceDetailModifiedDate], [InvoiceDetailCreatedDate], [InvoiceDetailHistoricalPrice], [InvoiceDetailQuantity], [ProductId], [InvoiceId], [InvoiceDetailId]";
         sFromString = " FROM [InvoiceDetail]";
         sOrderString = "";
         AddWhere(sWhereString, "([InvoiceDetailId] >= @AV6cInvoiceDetailId)");
         if ( ! (0==AV7cInvoiceId) )
         {
            AddWhere(sWhereString, "([InvoiceId] >= @AV7cInvoiceId)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV8cProductId) )
         {
            AddWhere(sWhereString, "([ProductId] >= @AV8cProductId)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV9cInvoiceDetailQuantity) )
         {
            AddWhere(sWhereString, "([InvoiceDetailQuantity] >= @AV9cInvoiceDetailQuantity)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV10cInvoiceDetailHistoricalPrice) )
         {
            AddWhere(sWhereString, "([InvoiceDetailHistoricalPrice] >= @AV10cInvoiceDetailHistoricalPrice)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV11cInvoiceDetailCreatedDate) )
         {
            AddWhere(sWhereString, "([InvoiceDetailCreatedDate] >= @AV11cInvoiceDetailCreatedDate)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV12cInvoiceDetailModifiedDate) )
         {
            AddWhere(sWhereString, "([InvoiceDetailModifiedDate] >= @AV12cInvoiceDetailModifiedDate)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [InvoiceDetailId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H000A3( IGxContext context ,
                                             int AV7cInvoiceId ,
                                             int AV8cProductId ,
                                             int AV9cInvoiceDetailQuantity ,
                                             decimal AV10cInvoiceDetailHistoricalPrice ,
                                             DateTime AV11cInvoiceDetailCreatedDate ,
                                             DateTime AV12cInvoiceDetailModifiedDate ,
                                             int A20InvoiceId ,
                                             int A15ProductId ,
                                             int A26InvoiceDetailQuantity ,
                                             decimal A27InvoiceDetailHistoricalPrice ,
                                             DateTime A42InvoiceDetailCreatedDate ,
                                             DateTime A43InvoiceDetailModifiedDate ,
                                             int AV6cInvoiceDetailId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [InvoiceDetail]";
         AddWhere(sWhereString, "([InvoiceDetailId] >= @AV6cInvoiceDetailId)");
         if ( ! (0==AV7cInvoiceId) )
         {
            AddWhere(sWhereString, "([InvoiceId] >= @AV7cInvoiceId)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (0==AV8cProductId) )
         {
            AddWhere(sWhereString, "([ProductId] >= @AV8cProductId)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV9cInvoiceDetailQuantity) )
         {
            AddWhere(sWhereString, "([InvoiceDetailQuantity] >= @AV9cInvoiceDetailQuantity)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV10cInvoiceDetailHistoricalPrice) )
         {
            AddWhere(sWhereString, "([InvoiceDetailHistoricalPrice] >= @AV10cInvoiceDetailHistoricalPrice)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV11cInvoiceDetailCreatedDate) )
         {
            AddWhere(sWhereString, "([InvoiceDetailCreatedDate] >= @AV11cInvoiceDetailCreatedDate)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV12cInvoiceDetailModifiedDate) )
         {
            AddWhere(sWhereString, "([InvoiceDetailModifiedDate] >= @AV12cInvoiceDetailModifiedDate)");
         }
         else
         {
            GXv_int3[6] = 1;
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
                     return conditional_H000A2(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (decimal)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (decimal)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (int)dynConstraints[12] );
               case 1 :
                     return conditional_H000A3(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (decimal)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (decimal)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (int)dynConstraints[12] );
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
          Object[] prmH000A2;
          prmH000A2 = new Object[] {
          new ParDef("@AV6cInvoiceDetailId",GXType.Int32,6,0) ,
          new ParDef("@AV7cInvoiceId",GXType.Int32,6,0) ,
          new ParDef("@AV8cProductId",GXType.Int32,6,0) ,
          new ParDef("@AV9cInvoiceDetailQuantity",GXType.Int32,6,0) ,
          new ParDef("@AV10cInvoiceDetailHistoricalPrice",GXType.Decimal,10,2) ,
          new ParDef("@AV11cInvoiceDetailCreatedDate",GXType.Date,8,0) ,
          new ParDef("@AV12cInvoiceDetailModifiedDate",GXType.Date,8,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH000A3;
          prmH000A3 = new Object[] {
          new ParDef("@AV6cInvoiceDetailId",GXType.Int32,6,0) ,
          new ParDef("@AV7cInvoiceId",GXType.Int32,6,0) ,
          new ParDef("@AV8cProductId",GXType.Int32,6,0) ,
          new ParDef("@AV9cInvoiceDetailQuantity",GXType.Int32,6,0) ,
          new ParDef("@AV10cInvoiceDetailHistoricalPrice",GXType.Decimal,10,2) ,
          new ParDef("@AV11cInvoiceDetailCreatedDate",GXType.Date,8,0) ,
          new ParDef("@AV12cInvoiceDetailModifiedDate",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000A2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000A2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H000A3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000A3,1, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
