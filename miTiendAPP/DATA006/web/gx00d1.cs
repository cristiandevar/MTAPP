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
   public class gx00d1 : GXDataArea
   {
      public gx00d1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public gx00d1( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_pInvoiceId ,
                           out int aP1_pInvoiceDetailId )
      {
         this.AV10pInvoiceId = aP0_pInvoiceId;
         this.AV11pInvoiceDetailId = 0 ;
         executePrivate();
         aP1_pInvoiceDetailId=this.AV11pInvoiceDetailId;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkavCinvoicedetailiswholesale = new GXCheckbox();
         chkInvoiceDetailIsWholesale = new GXCheckbox();
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
               AV10pInvoiceId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV10pInvoiceId", StringUtil.LTrimStr( (decimal)(AV10pInvoiceId), 6, 0));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV11pInvoiceDetailId = (int)(Math.Round(NumberUtil.Val( GetPar( "pInvoiceDetailId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11pInvoiceDetailId", StringUtil.LTrimStr( (decimal)(AV11pInvoiceDetailId), 6, 0));
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
         AV6cInvoiceDetailId = (int)(Math.Round(NumberUtil.Val( GetPar( "cInvoiceDetailId"), "."), 18, MidpointRounding.ToEven));
         AV7cInvoiceDetailQuantity = (int)(Math.Round(NumberUtil.Val( GetPar( "cInvoiceDetailQuantity"), "."), 18, MidpointRounding.ToEven));
         AV9cProductId = (int)(Math.Round(NumberUtil.Val( GetPar( "cProductId"), "."), 18, MidpointRounding.ToEven));
         AV15cInvoiceDetailHistoricPrice = NumberUtil.Val( GetPar( "cInvoiceDetailHistoricPrice"), ".");
         AV17cInvoiceDetailIsWholesale = StringUtil.StrToBool( GetPar( "cInvoiceDetailIsWholesale"));
         AV10pInvoiceId = (int)(Math.Round(NumberUtil.Val( GetPar( "pInvoiceId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cInvoiceDetailId, AV7cInvoiceDetailQuantity, AV9cProductId, AV15cInvoiceDetailHistoricPrice, AV17cInvoiceDetailIsWholesale, AV10pInvoiceId) ;
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
         PA1K2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1K2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx00d1.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV10pInvoiceId,6,0)),UrlEncode(StringUtil.LTrimStr(AV11pInvoiceDetailId,6,0))}, new string[] {"pInvoiceId","pInvoiceDetailId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCINVOICEDETAILQUANTITY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cInvoiceDetailQuantity), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCPRODUCTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9cProductId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCINVOICEDETAILHISTORICPRICE", StringUtil.LTrim( StringUtil.NToC( AV15cInvoiceDetailHistoricPrice, 18, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCINVOICEDETAILISWHOLESALE", StringUtil.BoolToStr( AV17cInvoiceDetailIsWholesale));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_64", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_64), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPINVOICEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10pInvoiceId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPINVOICEDETAILID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11pInvoiceDetailId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "INVOICEDETAILIDFILTERCONTAINER_Class", StringUtil.RTrim( divInvoicedetailidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "INVOICEDETAILQUANTITYFILTERCONTAINER_Class", StringUtil.RTrim( divInvoicedetailquantityfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PRODUCTIDFILTERCONTAINER_Class", StringUtil.RTrim( divProductidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "INVOICEDETAILHISTORICPRICEFILTERCONTAINER_Class", StringUtil.RTrim( divInvoicedetailhistoricpricefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "INVOICEDETAILISWHOLESALEFILTERCONTAINER_Class", StringUtil.RTrim( divInvoicedetailiswholesalefiltercontainer_Class));
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
            WE1K2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1K2( ) ;
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
         return formatLink("gx00d1.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV10pInvoiceId,6,0)),UrlEncode(StringUtil.LTrimStr(AV11pInvoiceDetailId,6,0))}, new string[] {"pInvoiceId","pInvoiceDetailId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx00D1" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List Detail" ;
      }

      protected void WB1K0( )
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
            GxWebStd.gx_label_ctrl( context, lblLblinvoicedetailidfilter_Internalname, "Invoice Detail Id", "", "", lblLblinvoicedetailidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e111k1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00D1.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCinvoicedetailid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cInvoiceDetailId), 6, 0, ".", "")), StringUtil.LTrim( ((edtavCinvoicedetailid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cInvoiceDetailId), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV6cInvoiceDetailId), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCinvoicedetailid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCinvoicedetailid_Visible, edtavCinvoicedetailid_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00D1.htm");
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
            GxWebStd.gx_label_ctrl( context, lblLblinvoicedetailquantityfilter_Internalname, "Invoice Detail Quantity", "", "", lblLblinvoicedetailquantityfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e121k1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00D1.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCinvoicedetailquantity_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cInvoiceDetailQuantity), 6, 0, ".", "")), StringUtil.LTrim( ((edtavCinvoicedetailquantity_Enabled!=0) ? context.localUtil.Format( (decimal)(AV7cInvoiceDetailQuantity), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV7cInvoiceDetailQuantity), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCinvoicedetailquantity_Jsonclick, 0, "Attribute", "", "", "", "", edtavCinvoicedetailquantity_Visible, edtavCinvoicedetailquantity_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00D1.htm");
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
            GxWebStd.gx_label_ctrl( context, lblLblproductidfilter_Internalname, "Product Id", "", "", lblLblproductidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e131k1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00D1.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCproductid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9cProductId), 6, 0, ".", "")), StringUtil.LTrim( ((edtavCproductid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV9cProductId), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV9cProductId), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCproductid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCproductid_Visible, edtavCproductid_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00D1.htm");
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
            GxWebStd.gx_div_start( context, divInvoicedetailhistoricpricefiltercontainer_Internalname, 1, 0, "px", 0, "px", divInvoicedetailhistoricpricefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblinvoicedetailhistoricpricefilter_Internalname, "Invoice Detail Historic Price", "", "", lblLblinvoicedetailhistoricpricefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e141k1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00D1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCinvoicedetailhistoricprice_Internalname, "Invoice Detail Historic Price", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCinvoicedetailhistoricprice_Internalname, StringUtil.LTrim( StringUtil.NToC( AV15cInvoiceDetailHistoricPrice, 18, 2, ".", "")), StringUtil.LTrim( ((edtavCinvoicedetailhistoricprice_Enabled!=0) ? context.localUtil.Format( AV15cInvoiceDetailHistoricPrice, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV15cInvoiceDetailHistoricPrice, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCinvoicedetailhistoricprice_Jsonclick, 0, "Attribute", "", "", "", "", edtavCinvoicedetailhistoricprice_Visible, edtavCinvoicedetailhistoricprice_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00D1.htm");
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
            GxWebStd.gx_div_start( context, divInvoicedetailiswholesalefiltercontainer_Internalname, 1, 0, "px", 0, "px", divInvoicedetailiswholesalefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblinvoicedetailiswholesalefilter_Internalname, "Invoice Detail Is Wholesale", "", "", lblLblinvoicedetailiswholesalefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e151k1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00D1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavCinvoicedetailiswholesale_Internalname, "Invoice Detail Is Wholesale", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_64_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCinvoicedetailiswholesale_Internalname, StringUtil.BoolToStr( AV17cInvoiceDetailIsWholesale), "", "Invoice Detail Is Wholesale", chkavCinvoicedetailiswholesale.Visible, chkavCinvoicedetailiswholesale.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(56, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,56);\"");
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(64), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e161k1_client"+"'", TempTags, "", 2, "HLP_Gx00D1.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(64), 2, 0)+","+"null"+");", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx00D1.htm");
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

      protected void START1K2( )
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
            Form.Meta.addItem("description", "Selection List Detail", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1K0( ) ;
      }

      protected void WS1K2( )
      {
         START1K2( ) ;
         EVT1K2( ) ;
      }

      protected void EVT1K2( )
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
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV20Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_64_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A25InvoiceDetailId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtInvoiceDetailId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A26InvoiceDetailQuantity = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtInvoiceDetailQuantity_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A15ProductId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtProductId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A65InvoiceDetailHistoricPrice = context.localUtil.CToN( cgiGet( edtInvoiceDetailHistoricPrice_Internalname), ".", ",");
                              A98InvoiceDetailIsWholesale = StringUtil.StrToBool( cgiGet( chkInvoiceDetailIsWholesale_Internalname));
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
                                    E171K2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E181K2 ();
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
                                       /* Set Refresh If Cinvoicedetailquantity Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCINVOICEDETAILQUANTITY"), ".", ",") != Convert.ToDecimal( AV7cInvoiceDetailQuantity )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cproductid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPRODUCTID"), ".", ",") != Convert.ToDecimal( AV9cProductId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cinvoicedetailhistoricprice Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCINVOICEDETAILHISTORICPRICE"), ".", ",") != AV15cInvoiceDetailHistoricPrice )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cinvoicedetailiswholesale Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vCINVOICEDETAILISWHOLESALE")) != AV17cInvoiceDetailIsWholesale )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E191K2 ();
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

      protected void WE1K2( )
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

      protected void PA1K2( )
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
                                        int AV6cInvoiceDetailId ,
                                        int AV7cInvoiceDetailQuantity ,
                                        int AV9cProductId ,
                                        decimal AV15cInvoiceDetailHistoricPrice ,
                                        bool AV17cInvoiceDetailIsWholesale ,
                                        int AV10pInvoiceId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF1K2( ) ;
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
         AV17cInvoiceDetailIsWholesale = StringUtil.StrToBool( StringUtil.BoolToStr( AV17cInvoiceDetailIsWholesale));
         AssignAttri("", false, "AV17cInvoiceDetailIsWholesale", AV17cInvoiceDetailIsWholesale);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF1K2( ) ;
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

      protected void RF1K2( )
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
                                                 AV7cInvoiceDetailQuantity ,
                                                 AV9cProductId ,
                                                 AV15cInvoiceDetailHistoricPrice ,
                                                 AV17cInvoiceDetailIsWholesale ,
                                                 A26InvoiceDetailQuantity ,
                                                 A15ProductId ,
                                                 A65InvoiceDetailHistoricPrice ,
                                                 A98InvoiceDetailIsWholesale ,
                                                 AV10pInvoiceId ,
                                                 AV6cInvoiceDetailId ,
                                                 A20InvoiceId } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT,
                                                 TypeConstants.INT
                                                 }
            });
            /* Using cursor H001K2 */
            pr_default.execute(0, new Object[] {AV10pInvoiceId, AV6cInvoiceDetailId, AV7cInvoiceDetailQuantity, AV9cProductId, AV15cInvoiceDetailHistoricPrice, AV17cInvoiceDetailIsWholesale, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_64_idx = 1;
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A20InvoiceId = H001K2_A20InvoiceId[0];
               A98InvoiceDetailIsWholesale = H001K2_A98InvoiceDetailIsWholesale[0];
               A65InvoiceDetailHistoricPrice = H001K2_A65InvoiceDetailHistoricPrice[0];
               A15ProductId = H001K2_A15ProductId[0];
               A26InvoiceDetailQuantity = H001K2_A26InvoiceDetailQuantity[0];
               A25InvoiceDetailId = H001K2_A25InvoiceDetailId[0];
               /* Execute user event: Load */
               E181K2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 64;
            WB1K0( ) ;
         }
         bGXsfl_64_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes1K2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_INVOICEDETAILID"+"_"+sGXsfl_64_idx, GetSecureSignedToken( sGXsfl_64_idx, context.localUtil.Format( (decimal)(A25InvoiceDetailId), "ZZZZZ9"), context));
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
                                              AV7cInvoiceDetailQuantity ,
                                              AV9cProductId ,
                                              AV15cInvoiceDetailHistoricPrice ,
                                              AV17cInvoiceDetailIsWholesale ,
                                              A26InvoiceDetailQuantity ,
                                              A15ProductId ,
                                              A65InvoiceDetailHistoricPrice ,
                                              A98InvoiceDetailIsWholesale ,
                                              AV10pInvoiceId ,
                                              AV6cInvoiceDetailId ,
                                              A20InvoiceId } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.INT
                                              }
         });
         /* Using cursor H001K3 */
         pr_default.execute(1, new Object[] {AV10pInvoiceId, AV6cInvoiceDetailId, AV7cInvoiceDetailQuantity, AV9cProductId, AV15cInvoiceDetailHistoricPrice, AV17cInvoiceDetailIsWholesale});
         GRID1_nRecordCount = H001K3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cInvoiceDetailId, AV7cInvoiceDetailQuantity, AV9cProductId, AV15cInvoiceDetailHistoricPrice, AV17cInvoiceDetailIsWholesale, AV10pInvoiceId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cInvoiceDetailId, AV7cInvoiceDetailQuantity, AV9cProductId, AV15cInvoiceDetailHistoricPrice, AV17cInvoiceDetailIsWholesale, AV10pInvoiceId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cInvoiceDetailId, AV7cInvoiceDetailQuantity, AV9cProductId, AV15cInvoiceDetailHistoricPrice, AV17cInvoiceDetailIsWholesale, AV10pInvoiceId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cInvoiceDetailId, AV7cInvoiceDetailQuantity, AV9cProductId, AV15cInvoiceDetailHistoricPrice, AV17cInvoiceDetailIsWholesale, AV10pInvoiceId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cInvoiceDetailId, AV7cInvoiceDetailQuantity, AV9cProductId, AV15cInvoiceDetailHistoricPrice, AV17cInvoiceDetailIsWholesale, AV10pInvoiceId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP1K0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E171K2 ();
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCinvoicedetailquantity_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCinvoicedetailquantity_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCINVOICEDETAILQUANTITY");
               GX_FocusControl = edtavCinvoicedetailquantity_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cInvoiceDetailQuantity = 0;
               AssignAttri("", false, "AV7cInvoiceDetailQuantity", StringUtil.LTrimStr( (decimal)(AV7cInvoiceDetailQuantity), 6, 0));
            }
            else
            {
               AV7cInvoiceDetailQuantity = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCinvoicedetailquantity_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7cInvoiceDetailQuantity", StringUtil.LTrimStr( (decimal)(AV7cInvoiceDetailQuantity), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCproductid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCproductid_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCPRODUCTID");
               GX_FocusControl = edtavCproductid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9cProductId = 0;
               AssignAttri("", false, "AV9cProductId", StringUtil.LTrimStr( (decimal)(AV9cProductId), 6, 0));
            }
            else
            {
               AV9cProductId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCproductid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV9cProductId", StringUtil.LTrimStr( (decimal)(AV9cProductId), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCinvoicedetailhistoricprice_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCinvoicedetailhistoricprice_Internalname), ".", ",") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCINVOICEDETAILHISTORICPRICE");
               GX_FocusControl = edtavCinvoicedetailhistoricprice_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV15cInvoiceDetailHistoricPrice = 0;
               AssignAttri("", false, "AV15cInvoiceDetailHistoricPrice", StringUtil.LTrimStr( AV15cInvoiceDetailHistoricPrice, 18, 2));
            }
            else
            {
               AV15cInvoiceDetailHistoricPrice = context.localUtil.CToN( cgiGet( edtavCinvoicedetailhistoricprice_Internalname), ".", ",");
               AssignAttri("", false, "AV15cInvoiceDetailHistoricPrice", StringUtil.LTrimStr( AV15cInvoiceDetailHistoricPrice, 18, 2));
            }
            AV17cInvoiceDetailIsWholesale = StringUtil.StrToBool( cgiGet( chkavCinvoicedetailiswholesale_Internalname));
            AssignAttri("", false, "AV17cInvoiceDetailIsWholesale", AV17cInvoiceDetailIsWholesale);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCINVOICEDETAILID"), ".", ",") != Convert.ToDecimal( AV6cInvoiceDetailId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCINVOICEDETAILQUANTITY"), ".", ",") != Convert.ToDecimal( AV7cInvoiceDetailQuantity )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPRODUCTID"), ".", ",") != Convert.ToDecimal( AV9cProductId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCINVOICEDETAILHISTORICPRICE"), ".", ",") != AV15cInvoiceDetailHistoricPrice )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vCINVOICEDETAILISWHOLESALE")) != AV17cInvoiceDetailIsWholesale )
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
         E171K2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E171K2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Selection List %1", "Detail", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV12ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E181K2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "selectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV20Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )));
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
         E191K2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E191K2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV11pInvoiceDetailId = A25InvoiceDetailId;
         AssignAttri("", false, "AV11pInvoiceDetailId", StringUtil.LTrimStr( (decimal)(AV11pInvoiceDetailId), 6, 0));
         context.setWebReturnParms(new Object[] {(int)AV11pInvoiceDetailId});
         context.setWebReturnParmsMetadata(new Object[] {"AV11pInvoiceDetailId"});
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
         AV10pInvoiceId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV10pInvoiceId", StringUtil.LTrimStr( (decimal)(AV10pInvoiceId), 6, 0));
         AV11pInvoiceDetailId = Convert.ToInt32(getParm(obj,1));
         AssignAttri("", false, "AV11pInvoiceDetailId", StringUtil.LTrimStr( (decimal)(AV11pInvoiceDetailId), 6, 0));
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
         PA1K2( ) ;
         WS1K2( ) ;
         WE1K2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202411152134350", true, true);
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
         context.AddJavascriptSource("gx00d1.js", "?202411152134351", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_642( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_64_idx;
         edtInvoiceDetailId_Internalname = "INVOICEDETAILID_"+sGXsfl_64_idx;
         edtInvoiceDetailQuantity_Internalname = "INVOICEDETAILQUANTITY_"+sGXsfl_64_idx;
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_64_idx;
         edtInvoiceDetailHistoricPrice_Internalname = "INVOICEDETAILHISTORICPRICE_"+sGXsfl_64_idx;
         chkInvoiceDetailIsWholesale_Internalname = "INVOICEDETAILISWHOLESALE_"+sGXsfl_64_idx;
         edtInvoiceId_Internalname = "INVOICEID_"+sGXsfl_64_idx;
      }

      protected void SubsflControlProps_fel_642( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_64_fel_idx;
         edtInvoiceDetailId_Internalname = "INVOICEDETAILID_"+sGXsfl_64_fel_idx;
         edtInvoiceDetailQuantity_Internalname = "INVOICEDETAILQUANTITY_"+sGXsfl_64_fel_idx;
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_64_fel_idx;
         edtInvoiceDetailHistoricPrice_Internalname = "INVOICEDETAILHISTORICPRICE_"+sGXsfl_64_fel_idx;
         chkInvoiceDetailIsWholesale_Internalname = "INVOICEDETAILISWHOLESALE_"+sGXsfl_64_fel_idx;
         edtInvoiceId_Internalname = "INVOICEID_"+sGXsfl_64_fel_idx;
      }

      protected void sendrow_642( )
      {
         SubsflControlProps_642( ) ;
         WB1K0( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A25InvoiceDetailId), 6, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_64_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV20Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV20Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            edtInvoiceDetailId_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A25InvoiceDetailId), 6, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtInvoiceDetailId_Internalname, "Link", edtInvoiceDetailId_Link, !bGXsfl_64_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInvoiceDetailId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A25InvoiceDetailId), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A25InvoiceDetailId), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtInvoiceDetailId_Link,(string)"",(string)"",(string)"",(string)edtInvoiceDetailId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInvoiceDetailQuantity_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A26InvoiceDetailQuantity), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A26InvoiceDetailQuantity), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInvoiceDetailQuantity_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A15ProductId), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInvoiceDetailHistoricPrice_Internalname,StringUtil.LTrim( StringUtil.NToC( A65InvoiceDetailHistoricPrice, 18, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A65InvoiceDetailHistoricPrice, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInvoiceDetailHistoricPrice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)0,(bool)true,(string)"Price",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "INVOICEDETAILISWHOLESALE_" + sGXsfl_64_idx;
            chkInvoiceDetailIsWholesale.Name = GXCCtl;
            chkInvoiceDetailIsWholesale.WebTags = "";
            chkInvoiceDetailIsWholesale.Caption = "";
            AssignProp("", false, chkInvoiceDetailIsWholesale_Internalname, "TitleCaption", chkInvoiceDetailIsWholesale.Caption, !bGXsfl_64_Refreshing);
            chkInvoiceDetailIsWholesale.CheckedValue = "false";
            A98InvoiceDetailIsWholesale = StringUtil.StrToBool( StringUtil.BoolToStr( A98InvoiceDetailIsWholesale));
            Grid1Row.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkInvoiceDetailIsWholesale_Internalname,StringUtil.BoolToStr( A98InvoiceDetailIsWholesale),(string)"",(string)"",(short)-1,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn OptionalColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInvoiceId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A20InvoiceId), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A20InvoiceId), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInvoiceId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes1K2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_64_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_64_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_64_idx+1);
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
         }
         /* End function sendrow_642 */
      }

      protected void init_web_controls( )
      {
         chkavCinvoicedetailiswholesale.Name = "vCINVOICEDETAILISWHOLESALE";
         chkavCinvoicedetailiswholesale.WebTags = "";
         chkavCinvoicedetailiswholesale.Caption = "";
         AssignProp("", false, chkavCinvoicedetailiswholesale_Internalname, "TitleCaption", chkavCinvoicedetailiswholesale.Caption, true);
         chkavCinvoicedetailiswholesale.CheckedValue = "false";
         AV17cInvoiceDetailIsWholesale = StringUtil.StrToBool( StringUtil.BoolToStr( AV17cInvoiceDetailIsWholesale));
         AssignAttri("", false, "AV17cInvoiceDetailIsWholesale", AV17cInvoiceDetailIsWholesale);
         GXCCtl = "INVOICEDETAILISWHOLESALE_" + sGXsfl_64_idx;
         chkInvoiceDetailIsWholesale.Name = GXCCtl;
         chkInvoiceDetailIsWholesale.WebTags = "";
         chkInvoiceDetailIsWholesale.Caption = "";
         AssignProp("", false, chkInvoiceDetailIsWholesale_Internalname, "TitleCaption", chkInvoiceDetailIsWholesale.Caption, !bGXsfl_64_Refreshing);
         chkInvoiceDetailIsWholesale.CheckedValue = "false";
         A98InvoiceDetailIsWholesale = StringUtil.StrToBool( StringUtil.BoolToStr( A98InvoiceDetailIsWholesale));
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
            context.SendWebValue( "Detail Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Detail Quantity") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Product Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Historic Price") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Is Wholesale") ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A25InvoiceDetailId), 6, 0, ".", ""))));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtInvoiceDetailId_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A26InvoiceDetailQuantity), 6, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A65InvoiceDetailHistoricPrice, 18, 2, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A98InvoiceDetailIsWholesale)));
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
         lblLblinvoicedetailidfilter_Internalname = "LBLINVOICEDETAILIDFILTER";
         edtavCinvoicedetailid_Internalname = "vCINVOICEDETAILID";
         divInvoicedetailidfiltercontainer_Internalname = "INVOICEDETAILIDFILTERCONTAINER";
         lblLblinvoicedetailquantityfilter_Internalname = "LBLINVOICEDETAILQUANTITYFILTER";
         edtavCinvoicedetailquantity_Internalname = "vCINVOICEDETAILQUANTITY";
         divInvoicedetailquantityfiltercontainer_Internalname = "INVOICEDETAILQUANTITYFILTERCONTAINER";
         lblLblproductidfilter_Internalname = "LBLPRODUCTIDFILTER";
         edtavCproductid_Internalname = "vCPRODUCTID";
         divProductidfiltercontainer_Internalname = "PRODUCTIDFILTERCONTAINER";
         lblLblinvoicedetailhistoricpricefilter_Internalname = "LBLINVOICEDETAILHISTORICPRICEFILTER";
         edtavCinvoicedetailhistoricprice_Internalname = "vCINVOICEDETAILHISTORICPRICE";
         divInvoicedetailhistoricpricefiltercontainer_Internalname = "INVOICEDETAILHISTORICPRICEFILTERCONTAINER";
         lblLblinvoicedetailiswholesalefilter_Internalname = "LBLINVOICEDETAILISWHOLESALEFILTER";
         chkavCinvoicedetailiswholesale_Internalname = "vCINVOICEDETAILISWHOLESALE";
         divInvoicedetailiswholesalefiltercontainer_Internalname = "INVOICEDETAILISWHOLESALEFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtInvoiceDetailId_Internalname = "INVOICEDETAILID";
         edtInvoiceDetailQuantity_Internalname = "INVOICEDETAILQUANTITY";
         edtProductId_Internalname = "PRODUCTID";
         edtInvoiceDetailHistoricPrice_Internalname = "INVOICEDETAILHISTORICPRICE";
         chkInvoiceDetailIsWholesale_Internalname = "INVOICEDETAILISWHOLESALE";
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
         chkavCinvoicedetailiswholesale.Caption = "Invoice Detail Is Wholesale";
         edtInvoiceId_Jsonclick = "";
         chkInvoiceDetailIsWholesale.Caption = "";
         edtInvoiceDetailHistoricPrice_Jsonclick = "";
         edtProductId_Jsonclick = "";
         edtInvoiceDetailQuantity_Jsonclick = "";
         edtInvoiceDetailId_Jsonclick = "";
         edtInvoiceDetailId_Link = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         chkavCinvoicedetailiswholesale.Enabled = 1;
         chkavCinvoicedetailiswholesale.Visible = 1;
         edtavCinvoicedetailhistoricprice_Jsonclick = "";
         edtavCinvoicedetailhistoricprice_Enabled = 1;
         edtavCinvoicedetailhistoricprice_Visible = 1;
         edtavCproductid_Jsonclick = "";
         edtavCproductid_Enabled = 1;
         edtavCproductid_Visible = 1;
         edtavCinvoicedetailquantity_Jsonclick = "";
         edtavCinvoicedetailquantity_Enabled = 1;
         edtavCinvoicedetailquantity_Visible = 1;
         edtavCinvoicedetailid_Jsonclick = "";
         edtavCinvoicedetailid_Enabled = 1;
         edtavCinvoicedetailid_Visible = 1;
         divInvoicedetailiswholesalefiltercontainer_Class = "AdvancedContainerItem";
         divInvoicedetailhistoricpricefiltercontainer_Class = "AdvancedContainerItem";
         divProductidfiltercontainer_Class = "AdvancedContainerItem";
         divInvoicedetailquantityfiltercontainer_Class = "AdvancedContainerItem";
         divInvoicedetailidfiltercontainer_Class = "AdvancedContainerItem";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List Detail";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cInvoiceDetailId',fld:'vCINVOICEDETAILID',pic:'ZZZZZ9'},{av:'AV7cInvoiceDetailQuantity',fld:'vCINVOICEDETAILQUANTITY',pic:'ZZZZZ9'},{av:'AV9cProductId',fld:'vCPRODUCTID',pic:'ZZZZZ9'},{av:'AV15cInvoiceDetailHistoricPrice',fld:'vCINVOICEDETAILHISTORICPRICE',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV10pInvoiceId',fld:'vPINVOICEID',pic:'ZZZZZ9'},{av:'AV17cInvoiceDetailIsWholesale',fld:'vCINVOICEDETAILISWHOLESALE',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E161K1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLINVOICEDETAILIDFILTER.CLICK","{handler:'E111K1',iparms:[{av:'divInvoicedetailidfiltercontainer_Class',ctrl:'INVOICEDETAILIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLINVOICEDETAILIDFILTER.CLICK",",oparms:[{av:'divInvoicedetailidfiltercontainer_Class',ctrl:'INVOICEDETAILIDFILTERCONTAINER',prop:'Class'},{av:'edtavCinvoicedetailid_Visible',ctrl:'vCINVOICEDETAILID',prop:'Visible'}]}");
         setEventMetadata("LBLINVOICEDETAILQUANTITYFILTER.CLICK","{handler:'E121K1',iparms:[{av:'divInvoicedetailquantityfiltercontainer_Class',ctrl:'INVOICEDETAILQUANTITYFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLINVOICEDETAILQUANTITYFILTER.CLICK",",oparms:[{av:'divInvoicedetailquantityfiltercontainer_Class',ctrl:'INVOICEDETAILQUANTITYFILTERCONTAINER',prop:'Class'},{av:'edtavCinvoicedetailquantity_Visible',ctrl:'vCINVOICEDETAILQUANTITY',prop:'Visible'}]}");
         setEventMetadata("LBLPRODUCTIDFILTER.CLICK","{handler:'E131K1',iparms:[{av:'divProductidfiltercontainer_Class',ctrl:'PRODUCTIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPRODUCTIDFILTER.CLICK",",oparms:[{av:'divProductidfiltercontainer_Class',ctrl:'PRODUCTIDFILTERCONTAINER',prop:'Class'},{av:'edtavCproductid_Visible',ctrl:'vCPRODUCTID',prop:'Visible'}]}");
         setEventMetadata("LBLINVOICEDETAILHISTORICPRICEFILTER.CLICK","{handler:'E141K1',iparms:[{av:'divInvoicedetailhistoricpricefiltercontainer_Class',ctrl:'INVOICEDETAILHISTORICPRICEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLINVOICEDETAILHISTORICPRICEFILTER.CLICK",",oparms:[{av:'divInvoicedetailhistoricpricefiltercontainer_Class',ctrl:'INVOICEDETAILHISTORICPRICEFILTERCONTAINER',prop:'Class'},{av:'edtavCinvoicedetailhistoricprice_Visible',ctrl:'vCINVOICEDETAILHISTORICPRICE',prop:'Visible'}]}");
         setEventMetadata("LBLINVOICEDETAILISWHOLESALEFILTER.CLICK","{handler:'E151K1',iparms:[{av:'divInvoicedetailiswholesalefiltercontainer_Class',ctrl:'INVOICEDETAILISWHOLESALEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLINVOICEDETAILISWHOLESALEFILTER.CLICK",",oparms:[{av:'divInvoicedetailiswholesalefiltercontainer_Class',ctrl:'INVOICEDETAILISWHOLESALEFILTERCONTAINER',prop:'Class'},{av:'chkavCinvoicedetailiswholesale.Visible',ctrl:'vCINVOICEDETAILISWHOLESALE',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E191K2',iparms:[{av:'A25InvoiceDetailId',fld:'INVOICEDETAILID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV11pInvoiceDetailId',fld:'vPINVOICEDETAILID',pic:'ZZZZZ9'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cInvoiceDetailId',fld:'vCINVOICEDETAILID',pic:'ZZZZZ9'},{av:'AV7cInvoiceDetailQuantity',fld:'vCINVOICEDETAILQUANTITY',pic:'ZZZZZ9'},{av:'AV9cProductId',fld:'vCPRODUCTID',pic:'ZZZZZ9'},{av:'AV15cInvoiceDetailHistoricPrice',fld:'vCINVOICEDETAILHISTORICPRICE',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV10pInvoiceId',fld:'vPINVOICEID',pic:'ZZZZZ9'},{av:'AV17cInvoiceDetailIsWholesale',fld:'vCINVOICEDETAILISWHOLESALE',pic:''}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cInvoiceDetailId',fld:'vCINVOICEDETAILID',pic:'ZZZZZ9'},{av:'AV7cInvoiceDetailQuantity',fld:'vCINVOICEDETAILQUANTITY',pic:'ZZZZZ9'},{av:'AV9cProductId',fld:'vCPRODUCTID',pic:'ZZZZZ9'},{av:'AV15cInvoiceDetailHistoricPrice',fld:'vCINVOICEDETAILHISTORICPRICE',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV10pInvoiceId',fld:'vPINVOICEID',pic:'ZZZZZ9'},{av:'AV17cInvoiceDetailIsWholesale',fld:'vCINVOICEDETAILISWHOLESALE',pic:''}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cInvoiceDetailId',fld:'vCINVOICEDETAILID',pic:'ZZZZZ9'},{av:'AV7cInvoiceDetailQuantity',fld:'vCINVOICEDETAILQUANTITY',pic:'ZZZZZ9'},{av:'AV9cProductId',fld:'vCPRODUCTID',pic:'ZZZZZ9'},{av:'AV15cInvoiceDetailHistoricPrice',fld:'vCINVOICEDETAILHISTORICPRICE',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV10pInvoiceId',fld:'vPINVOICEID',pic:'ZZZZZ9'},{av:'AV17cInvoiceDetailIsWholesale',fld:'vCINVOICEDETAILISWHOLESALE',pic:''}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cInvoiceDetailId',fld:'vCINVOICEDETAILID',pic:'ZZZZZ9'},{av:'AV7cInvoiceDetailQuantity',fld:'vCINVOICEDETAILQUANTITY',pic:'ZZZZZ9'},{av:'AV9cProductId',fld:'vCPRODUCTID',pic:'ZZZZZ9'},{av:'AV15cInvoiceDetailHistoricPrice',fld:'vCINVOICEDETAILHISTORICPRICE',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV10pInvoiceId',fld:'vPINVOICEID',pic:'ZZZZZ9'},{av:'AV17cInvoiceDetailIsWholesale',fld:'vCINVOICEDETAILISWHOLESALE',pic:''}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CINVOICEDETAILHISTORICPRICE","{handler:'Validv_Cinvoicedetailhistoricprice',iparms:[]");
         setEventMetadata("VALIDV_CINVOICEDETAILHISTORICPRICE",",oparms:[]}");
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
         lblLblinvoicedetailidfilter_Jsonclick = "";
         TempTags = "";
         lblLblinvoicedetailquantityfilter_Jsonclick = "";
         lblLblproductidfilter_Jsonclick = "";
         lblLblinvoicedetailhistoricpricefilter_Jsonclick = "";
         lblLblinvoicedetailiswholesalefilter_Jsonclick = "";
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
         AV20Linkselection_GXI = "";
         scmdbuf = "";
         H001K2_A20InvoiceId = new int[1] ;
         H001K2_A98InvoiceDetailIsWholesale = new bool[] {false} ;
         H001K2_A65InvoiceDetailHistoricPrice = new decimal[1] ;
         H001K2_A15ProductId = new int[1] ;
         H001K2_A26InvoiceDetailQuantity = new int[1] ;
         H001K2_A25InvoiceDetailId = new int[1] ;
         H001K3_AGRID1_nRecordCount = new long[1] ;
         AV12ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         GXCCtl = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx00d1__default(),
            new Object[][] {
                new Object[] {
               H001K2_A20InvoiceId, H001K2_A98InvoiceDetailIsWholesale, H001K2_A65InvoiceDetailHistoricPrice, H001K2_A15ProductId, H001K2_A26InvoiceDetailQuantity, H001K2_A25InvoiceDetailId
               }
               , new Object[] {
               H001K3_AGRID1_nRecordCount
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
      private int AV10pInvoiceId ;
      private int AV11pInvoiceDetailId ;
      private int wcpOAV10pInvoiceId ;
      private int nRC_GXsfl_64 ;
      private int subGrid1_Rows ;
      private int nGXsfl_64_idx=1 ;
      private int AV6cInvoiceDetailId ;
      private int AV7cInvoiceDetailQuantity ;
      private int AV9cProductId ;
      private int edtavCinvoicedetailid_Enabled ;
      private int edtavCinvoicedetailid_Visible ;
      private int edtavCinvoicedetailquantity_Enabled ;
      private int edtavCinvoicedetailquantity_Visible ;
      private int edtavCproductid_Enabled ;
      private int edtavCproductid_Visible ;
      private int edtavCinvoicedetailhistoricprice_Enabled ;
      private int edtavCinvoicedetailhistoricprice_Visible ;
      private int A25InvoiceDetailId ;
      private int A26InvoiceDetailQuantity ;
      private int A15ProductId ;
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
      private decimal AV15cInvoiceDetailHistoricPrice ;
      private decimal A65InvoiceDetailHistoricPrice ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divInvoicedetailidfiltercontainer_Class ;
      private string divInvoicedetailquantityfiltercontainer_Class ;
      private string divProductidfiltercontainer_Class ;
      private string divInvoicedetailhistoricpricefiltercontainer_Class ;
      private string divInvoicedetailiswholesalefiltercontainer_Class ;
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
      private string divInvoicedetailidfiltercontainer_Internalname ;
      private string lblLblinvoicedetailidfilter_Internalname ;
      private string lblLblinvoicedetailidfilter_Jsonclick ;
      private string edtavCinvoicedetailid_Internalname ;
      private string TempTags ;
      private string edtavCinvoicedetailid_Jsonclick ;
      private string divInvoicedetailquantityfiltercontainer_Internalname ;
      private string lblLblinvoicedetailquantityfilter_Internalname ;
      private string lblLblinvoicedetailquantityfilter_Jsonclick ;
      private string edtavCinvoicedetailquantity_Internalname ;
      private string edtavCinvoicedetailquantity_Jsonclick ;
      private string divProductidfiltercontainer_Internalname ;
      private string lblLblproductidfilter_Internalname ;
      private string lblLblproductidfilter_Jsonclick ;
      private string edtavCproductid_Internalname ;
      private string edtavCproductid_Jsonclick ;
      private string divInvoicedetailhistoricpricefiltercontainer_Internalname ;
      private string lblLblinvoicedetailhistoricpricefilter_Internalname ;
      private string lblLblinvoicedetailhistoricpricefilter_Jsonclick ;
      private string edtavCinvoicedetailhistoricprice_Internalname ;
      private string edtavCinvoicedetailhistoricprice_Jsonclick ;
      private string divInvoicedetailiswholesalefiltercontainer_Internalname ;
      private string lblLblinvoicedetailiswholesalefilter_Internalname ;
      private string lblLblinvoicedetailiswholesalefilter_Jsonclick ;
      private string chkavCinvoicedetailiswholesale_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divGridtable_Internalname ;
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
      private string edtInvoiceDetailQuantity_Internalname ;
      private string edtProductId_Internalname ;
      private string edtInvoiceDetailHistoricPrice_Internalname ;
      private string chkInvoiceDetailIsWholesale_Internalname ;
      private string edtInvoiceId_Internalname ;
      private string scmdbuf ;
      private string AV12ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_64_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtInvoiceDetailId_Link ;
      private string edtInvoiceDetailId_Jsonclick ;
      private string edtInvoiceDetailQuantity_Jsonclick ;
      private string edtProductId_Jsonclick ;
      private string edtInvoiceDetailHistoricPrice_Jsonclick ;
      private string GXCCtl ;
      private string edtInvoiceId_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV17cInvoiceDetailIsWholesale ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_64_Refreshing=false ;
      private bool A98InvoiceDetailIsWholesale ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV20Linkselection_GXI ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavCinvoicedetailiswholesale ;
      private GXCheckbox chkInvoiceDetailIsWholesale ;
      private IDataStoreProvider pr_default ;
      private int[] H001K2_A20InvoiceId ;
      private bool[] H001K2_A98InvoiceDetailIsWholesale ;
      private decimal[] H001K2_A65InvoiceDetailHistoricPrice ;
      private int[] H001K2_A15ProductId ;
      private int[] H001K2_A26InvoiceDetailQuantity ;
      private int[] H001K2_A25InvoiceDetailId ;
      private long[] H001K3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private int aP1_pInvoiceDetailId ;
      private GXWebForm Form ;
   }

   public class gx00d1__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H001K2( IGxContext context ,
                                             int AV7cInvoiceDetailQuantity ,
                                             int AV9cProductId ,
                                             decimal AV15cInvoiceDetailHistoricPrice ,
                                             bool AV17cInvoiceDetailIsWholesale ,
                                             int A26InvoiceDetailQuantity ,
                                             int A15ProductId ,
                                             decimal A65InvoiceDetailHistoricPrice ,
                                             bool A98InvoiceDetailIsWholesale ,
                                             int AV10pInvoiceId ,
                                             int AV6cInvoiceDetailId ,
                                             int A20InvoiceId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[9];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [InvoiceId], [InvoiceDetailIsWholesale], [InvoiceDetailHistoricPrice], [ProductId], [InvoiceDetailQuantity], [InvoiceDetailId]";
         sFromString = " FROM [InvoiceDetail]";
         sOrderString = "";
         AddWhere(sWhereString, "([InvoiceId] = @AV10pInvoiceId and [InvoiceDetailId] >= @AV6cInvoiceDetailId)");
         if ( ! (0==AV7cInvoiceDetailQuantity) )
         {
            AddWhere(sWhereString, "([InvoiceDetailQuantity] >= @AV7cInvoiceDetailQuantity)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV9cProductId) )
         {
            AddWhere(sWhereString, "([ProductId] >= @AV9cProductId)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV15cInvoiceDetailHistoricPrice) )
         {
            AddWhere(sWhereString, "([InvoiceDetailHistoricPrice] >= @AV15cInvoiceDetailHistoricPrice)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (false==AV17cInvoiceDetailIsWholesale) )
         {
            AddWhere(sWhereString, "([InvoiceDetailIsWholesale] >= @AV17cInvoiceDetailIsWholesale)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         sOrderString += " ORDER BY [InvoiceId], [InvoiceDetailId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H001K3( IGxContext context ,
                                             int AV7cInvoiceDetailQuantity ,
                                             int AV9cProductId ,
                                             decimal AV15cInvoiceDetailHistoricPrice ,
                                             bool AV17cInvoiceDetailIsWholesale ,
                                             int A26InvoiceDetailQuantity ,
                                             int A15ProductId ,
                                             decimal A65InvoiceDetailHistoricPrice ,
                                             bool A98InvoiceDetailIsWholesale ,
                                             int AV10pInvoiceId ,
                                             int AV6cInvoiceDetailId ,
                                             int A20InvoiceId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [InvoiceDetail]";
         AddWhere(sWhereString, "([InvoiceId] = @AV10pInvoiceId and [InvoiceDetailId] >= @AV6cInvoiceDetailId)");
         if ( ! (0==AV7cInvoiceDetailQuantity) )
         {
            AddWhere(sWhereString, "([InvoiceDetailQuantity] >= @AV7cInvoiceDetailQuantity)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV9cProductId) )
         {
            AddWhere(sWhereString, "([ProductId] >= @AV9cProductId)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV15cInvoiceDetailHistoricPrice) )
         {
            AddWhere(sWhereString, "([InvoiceDetailHistoricPrice] >= @AV15cInvoiceDetailHistoricPrice)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (false==AV17cInvoiceDetailIsWholesale) )
         {
            AddWhere(sWhereString, "([InvoiceDetailIsWholesale] >= @AV17cInvoiceDetailIsWholesale)");
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
                     return conditional_H001K2(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (decimal)dynConstraints[2] , (bool)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (decimal)dynConstraints[6] , (bool)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] );
               case 1 :
                     return conditional_H001K3(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (decimal)dynConstraints[2] , (bool)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (decimal)dynConstraints[6] , (bool)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] );
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
          Object[] prmH001K2;
          prmH001K2 = new Object[] {
          new ParDef("@AV10pInvoiceId",GXType.Int32,6,0) ,
          new ParDef("@AV6cInvoiceDetailId",GXType.Int32,6,0) ,
          new ParDef("@AV7cInvoiceDetailQuantity",GXType.Int32,6,0) ,
          new ParDef("@AV9cProductId",GXType.Int32,6,0) ,
          new ParDef("@AV15cInvoiceDetailHistoricPrice",GXType.Decimal,18,2) ,
          new ParDef("@AV17cInvoiceDetailIsWholesale",GXType.Boolean,4,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH001K3;
          prmH001K3 = new Object[] {
          new ParDef("@AV10pInvoiceId",GXType.Int32,6,0) ,
          new ParDef("@AV6cInvoiceDetailId",GXType.Int32,6,0) ,
          new ParDef("@AV7cInvoiceDetailQuantity",GXType.Int32,6,0) ,
          new ParDef("@AV9cProductId",GXType.Int32,6,0) ,
          new ParDef("@AV15cInvoiceDetailHistoricPrice",GXType.Decimal,18,2) ,
          new ParDef("@AV17cInvoiceDetailIsWholesale",GXType.Boolean,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H001K2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001K2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H001K3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001K3,1, GxCacheFrequency.OFF ,false,false )
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
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
