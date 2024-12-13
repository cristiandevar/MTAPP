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
   public class gx00k0 : GXDataArea
   {
      public gx00k0( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public gx00k0( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out int aP0_pPaymentMethodId )
      {
         this.AV8pPaymentMethodId = 0 ;
         executePrivate();
         aP0_pPaymentMethodId=this.AV8pPaymentMethodId;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkavCpaymentmethodactive = new GXCheckbox();
         chkPaymentMethodActive = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pPaymentMethodId");
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
               gxfirstwebparm = GetFirstPar( "pPaymentMethodId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pPaymentMethodId");
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
               AV8pPaymentMethodId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV8pPaymentMethodId", StringUtil.LTrimStr( (decimal)(AV8pPaymentMethodId), 6, 0));
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
         nRC_GXsfl_54 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_54"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_54_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_54_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_54_idx = GetPar( "sGXsfl_54_idx");
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
         AV6cPaymentMethodId = (int)(Math.Round(NumberUtil.Val( GetPar( "cPaymentMethodId"), "."), 18, MidpointRounding.ToEven));
         AV7cPaymentMethodActive = StringUtil.StrToBool( GetPar( "cPaymentMethodActive"));
         AV10cPaymentMethodDiscount = NumberUtil.Val( GetPar( "cPaymentMethodDiscount"), ".");
         AV11cPaymentMethodRecarge = NumberUtil.Val( GetPar( "cPaymentMethodRecarge"), ".");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cPaymentMethodId, AV7cPaymentMethodActive, AV10cPaymentMethodDiscount, AV11cPaymentMethodRecarge) ;
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
         PA472( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START472( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx00k0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV8pPaymentMethodId,6,0))}, new string[] {"pPaymentMethodId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCPAYMENTMETHODID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cPaymentMethodId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCPAYMENTMETHODACTIVE", StringUtil.BoolToStr( AV7cPaymentMethodActive));
         GxWebStd.gx_hidden_field( context, "GXH_vCPAYMENTMETHODDISCOUNT", StringUtil.LTrim( StringUtil.NToC( AV10cPaymentMethodDiscount, 8, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCPAYMENTMETHODRECARGE", StringUtil.LTrim( StringUtil.NToC( AV11cPaymentMethodRecarge, 8, 2, ".", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_54", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_54), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPPAYMENTMETHODID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8pPaymentMethodId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "PAYMENTMETHODIDFILTERCONTAINER_Class", StringUtil.RTrim( divPaymentmethodidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PAYMENTMETHODACTIVEFILTERCONTAINER_Class", StringUtil.RTrim( divPaymentmethodactivefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PAYMENTMETHODDISCOUNTFILTERCONTAINER_Class", StringUtil.RTrim( divPaymentmethoddiscountfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PAYMENTMETHODRECARGEFILTERCONTAINER_Class", StringUtil.RTrim( divPaymentmethodrecargefiltercontainer_Class));
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
            WE472( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT472( ) ;
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
         return formatLink("gx00k0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV8pPaymentMethodId,6,0))}, new string[] {"pPaymentMethodId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx00K0" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List Payment Method of Invoices" ;
      }

      protected void WB470( )
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
            GxWebStd.gx_div_start( context, divPaymentmethodidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divPaymentmethodidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblpaymentmethodidfilter_Internalname, "Payment Method Id", "", "", lblLblpaymentmethodidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11471_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00K0.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_54_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCpaymentmethodid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cPaymentMethodId), 6, 0, ".", "")), StringUtil.LTrim( ((edtavCpaymentmethodid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cPaymentMethodId), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV6cPaymentMethodId), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpaymentmethodid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCpaymentmethodid_Visible, edtavCpaymentmethodid_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00K0.htm");
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
            GxWebStd.gx_div_start( context, divPaymentmethodactivefiltercontainer_Internalname, 1, 0, "px", 0, "px", divPaymentmethodactivefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblpaymentmethodactivefilter_Internalname, "Payment Method Active", "", "", lblLblpaymentmethodactivefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12471_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00K0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavCpaymentmethodactive_Internalname, "Payment Method Active", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_54_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCpaymentmethodactive_Internalname, StringUtil.BoolToStr( AV7cPaymentMethodActive), "", "Payment Method Active", chkavCpaymentmethodactive.Visible, chkavCpaymentmethodactive.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(26, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,26);\"");
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
            GxWebStd.gx_div_start( context, divPaymentmethoddiscountfiltercontainer_Internalname, 1, 0, "px", 0, "px", divPaymentmethoddiscountfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblpaymentmethoddiscountfilter_Internalname, "Payment Method Discount", "", "", lblLblpaymentmethoddiscountfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13471_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00K0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCpaymentmethoddiscount_Internalname, "Payment Method Discount", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_54_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCpaymentmethoddiscount_Internalname, StringUtil.LTrim( StringUtil.NToC( AV10cPaymentMethodDiscount, 8, 2, ".", "")), StringUtil.LTrim( ((edtavCpaymentmethoddiscount_Enabled!=0) ? context.localUtil.Format( AV10cPaymentMethodDiscount, "ZZZZ9.99") : context.localUtil.Format( AV10cPaymentMethodDiscount, "ZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpaymentmethoddiscount_Jsonclick, 0, "Attribute", "", "", "", "", edtavCpaymentmethoddiscount_Visible, edtavCpaymentmethoddiscount_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00K0.htm");
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
            GxWebStd.gx_div_start( context, divPaymentmethodrecargefiltercontainer_Internalname, 1, 0, "px", 0, "px", divPaymentmethodrecargefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblpaymentmethodrecargefilter_Internalname, "Payment Method Recarge", "", "", lblLblpaymentmethodrecargefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14471_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00K0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCpaymentmethodrecarge_Internalname, "Payment Method Recarge", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_54_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCpaymentmethodrecarge_Internalname, StringUtil.LTrim( StringUtil.NToC( AV11cPaymentMethodRecarge, 8, 2, ".", "")), StringUtil.LTrim( ((edtavCpaymentmethodrecarge_Enabled!=0) ? context.localUtil.Format( AV11cPaymentMethodRecarge, "ZZZZ9.99") : context.localUtil.Format( AV11cPaymentMethodRecarge, "ZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpaymentmethodrecarge_Jsonclick, 0, "Attribute", "", "", "", "", edtavCpaymentmethodrecarge_Visible, edtavCpaymentmethodrecarge_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00K0.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(54), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e15471_client"+"'", TempTags, "", 2, "HLP_Gx00K0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl54( ) ;
         }
         if ( wbEnd == 54 )
         {
            wbEnd = 0;
            nRC_GXsfl_54 = (int)(nGXsfl_54_idx-1);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(54), 2, 0)+","+"null"+");", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx00K0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 54 )
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

      protected void START472( )
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
            Form.Meta.addItem("description", "Selection List Payment Method of Invoices", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP470( ) ;
      }

      protected void WS472( )
      {
         START472( ) ;
         EVT472( ) ;
      }

      protected void EVT472( )
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
                              nGXsfl_54_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_54_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_54_idx), 4, 0), 4, "0");
                              SubsflControlProps_542( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV14Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_54_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A115PaymentMethodId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPaymentMethodId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A117PaymentMethodActive = StringUtil.StrToBool( cgiGet( chkPaymentMethodActive_Internalname));
                              A129PaymentMethodDiscount = context.localUtil.CToN( cgiGet( edtPaymentMethodDiscount_Internalname), ".", ",");
                              A130PaymentMethodRecarge = context.localUtil.CToN( cgiGet( edtPaymentMethodRecarge_Internalname), ".", ",");
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E16472 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E17472 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cpaymentmethodid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPAYMENTMETHODID"), ".", ",") != Convert.ToDecimal( AV6cPaymentMethodId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cpaymentmethodactive Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vCPAYMENTMETHODACTIVE")) != AV7cPaymentMethodActive )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cpaymentmethoddiscount Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCPAYMENTMETHODDISCOUNT"), ".", ",") != AV10cPaymentMethodDiscount )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cpaymentmethodrecarge Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCPAYMENTMETHODRECARGE"), ".", ",") != AV11cPaymentMethodRecarge )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E18472 ();
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

      protected void WE472( )
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

      protected void PA472( )
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
         SubsflControlProps_542( ) ;
         while ( nGXsfl_54_idx <= nRC_GXsfl_54 )
         {
            sendrow_542( ) ;
            nGXsfl_54_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_54_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_54_idx+1);
            sGXsfl_54_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_54_idx), 4, 0), 4, "0");
            SubsflControlProps_542( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        int AV6cPaymentMethodId ,
                                        bool AV7cPaymentMethodActive ,
                                        decimal AV10cPaymentMethodDiscount ,
                                        decimal AV11cPaymentMethodRecarge )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF472( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PAYMENTMETHODID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A115PaymentMethodId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "PAYMENTMETHODID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A115PaymentMethodId), 6, 0, ".", "")));
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
         AV7cPaymentMethodActive = StringUtil.StrToBool( StringUtil.BoolToStr( AV7cPaymentMethodActive));
         AssignAttri("", false, "AV7cPaymentMethodActive", AV7cPaymentMethodActive);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF472( ) ;
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

      protected void RF472( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 54;
         nGXsfl_54_idx = 1;
         sGXsfl_54_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_54_idx), 4, 0), 4, "0");
         SubsflControlProps_542( ) ;
         bGXsfl_54_Refreshing = true;
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
            SubsflControlProps_542( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV7cPaymentMethodActive ,
                                                 AV10cPaymentMethodDiscount ,
                                                 AV11cPaymentMethodRecarge ,
                                                 A117PaymentMethodActive ,
                                                 A129PaymentMethodDiscount ,
                                                 A130PaymentMethodRecarge ,
                                                 AV6cPaymentMethodId } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT
                                                 }
            });
            /* Using cursor H00472 */
            pr_default.execute(0, new Object[] {AV6cPaymentMethodId, AV7cPaymentMethodActive, AV10cPaymentMethodDiscount, AV11cPaymentMethodRecarge, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_54_idx = 1;
            sGXsfl_54_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_54_idx), 4, 0), 4, "0");
            SubsflControlProps_542( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A130PaymentMethodRecarge = H00472_A130PaymentMethodRecarge[0];
               A129PaymentMethodDiscount = H00472_A129PaymentMethodDiscount[0];
               A117PaymentMethodActive = H00472_A117PaymentMethodActive[0];
               A115PaymentMethodId = H00472_A115PaymentMethodId[0];
               /* Execute user event: Load */
               E17472 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 54;
            WB470( ) ;
         }
         bGXsfl_54_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes472( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PAYMENTMETHODID"+"_"+sGXsfl_54_idx, GetSecureSignedToken( sGXsfl_54_idx, context.localUtil.Format( (decimal)(A115PaymentMethodId), "ZZZZZ9"), context));
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
                                              AV7cPaymentMethodActive ,
                                              AV10cPaymentMethodDiscount ,
                                              AV11cPaymentMethodRecarge ,
                                              A117PaymentMethodActive ,
                                              A129PaymentMethodDiscount ,
                                              A130PaymentMethodRecarge ,
                                              AV6cPaymentMethodId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT
                                              }
         });
         /* Using cursor H00473 */
         pr_default.execute(1, new Object[] {AV6cPaymentMethodId, AV7cPaymentMethodActive, AV10cPaymentMethodDiscount, AV11cPaymentMethodRecarge});
         GRID1_nRecordCount = H00473_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cPaymentMethodId, AV7cPaymentMethodActive, AV10cPaymentMethodDiscount, AV11cPaymentMethodRecarge) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cPaymentMethodId, AV7cPaymentMethodActive, AV10cPaymentMethodDiscount, AV11cPaymentMethodRecarge) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cPaymentMethodId, AV7cPaymentMethodActive, AV10cPaymentMethodDiscount, AV11cPaymentMethodRecarge) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cPaymentMethodId, AV7cPaymentMethodActive, AV10cPaymentMethodDiscount, AV11cPaymentMethodRecarge) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cPaymentMethodId, AV7cPaymentMethodActive, AV10cPaymentMethodDiscount, AV11cPaymentMethodRecarge) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP470( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E16472 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_54 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_54"), ".", ","), 18, MidpointRounding.ToEven));
            GRID1_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRID1_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCpaymentmethodid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCpaymentmethodid_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCPAYMENTMETHODID");
               GX_FocusControl = edtavCpaymentmethodid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cPaymentMethodId = 0;
               AssignAttri("", false, "AV6cPaymentMethodId", StringUtil.LTrimStr( (decimal)(AV6cPaymentMethodId), 6, 0));
            }
            else
            {
               AV6cPaymentMethodId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCpaymentmethodid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cPaymentMethodId", StringUtil.LTrimStr( (decimal)(AV6cPaymentMethodId), 6, 0));
            }
            AV7cPaymentMethodActive = StringUtil.StrToBool( cgiGet( chkavCpaymentmethodactive_Internalname));
            AssignAttri("", false, "AV7cPaymentMethodActive", AV7cPaymentMethodActive);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCpaymentmethoddiscount_Internalname), ".", ",") < -9999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavCpaymentmethoddiscount_Internalname), ".", ",") > 99999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCPAYMENTMETHODDISCOUNT");
               GX_FocusControl = edtavCpaymentmethoddiscount_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cPaymentMethodDiscount = 0;
               AssignAttri("", false, "AV10cPaymentMethodDiscount", StringUtil.LTrimStr( AV10cPaymentMethodDiscount, 8, 2));
            }
            else
            {
               AV10cPaymentMethodDiscount = context.localUtil.CToN( cgiGet( edtavCpaymentmethoddiscount_Internalname), ".", ",");
               AssignAttri("", false, "AV10cPaymentMethodDiscount", StringUtil.LTrimStr( AV10cPaymentMethodDiscount, 8, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCpaymentmethodrecarge_Internalname), ".", ",") < -9999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavCpaymentmethodrecarge_Internalname), ".", ",") > 99999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCPAYMENTMETHODRECARGE");
               GX_FocusControl = edtavCpaymentmethodrecarge_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cPaymentMethodRecarge = 0;
               AssignAttri("", false, "AV11cPaymentMethodRecarge", StringUtil.LTrimStr( AV11cPaymentMethodRecarge, 8, 2));
            }
            else
            {
               AV11cPaymentMethodRecarge = context.localUtil.CToN( cgiGet( edtavCpaymentmethodrecarge_Internalname), ".", ",");
               AssignAttri("", false, "AV11cPaymentMethodRecarge", StringUtil.LTrimStr( AV11cPaymentMethodRecarge, 8, 2));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPAYMENTMETHODID"), ".", ",") != Convert.ToDecimal( AV6cPaymentMethodId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vCPAYMENTMETHODACTIVE")) != AV7cPaymentMethodActive )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCPAYMENTMETHODDISCOUNT"), ".", ",") != AV10cPaymentMethodDiscount )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCPAYMENTMETHODRECARGE"), ".", ",") != AV11cPaymentMethodRecarge )
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
         E16472 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E16472( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Selection List %1", "Payment Method of Invoices", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV9ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E17472( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "selectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV14Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )));
         sendrow_542( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_54_Refreshing )
         {
            DoAjaxLoad(54, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E18472 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E18472( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV8pPaymentMethodId = A115PaymentMethodId;
         AssignAttri("", false, "AV8pPaymentMethodId", StringUtil.LTrimStr( (decimal)(AV8pPaymentMethodId), 6, 0));
         context.setWebReturnParms(new Object[] {(int)AV8pPaymentMethodId});
         context.setWebReturnParmsMetadata(new Object[] {"AV8pPaymentMethodId"});
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
         AV8pPaymentMethodId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV8pPaymentMethodId", StringUtil.LTrimStr( (decimal)(AV8pPaymentMethodId), 6, 0));
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
         PA472( ) ;
         WS472( ) ;
         WE472( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202411210481664", true, true);
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
         context.AddJavascriptSource("gx00k0.js", "?202411210481665", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_542( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_54_idx;
         edtPaymentMethodId_Internalname = "PAYMENTMETHODID_"+sGXsfl_54_idx;
         chkPaymentMethodActive_Internalname = "PAYMENTMETHODACTIVE_"+sGXsfl_54_idx;
         edtPaymentMethodDiscount_Internalname = "PAYMENTMETHODDISCOUNT_"+sGXsfl_54_idx;
         edtPaymentMethodRecarge_Internalname = "PAYMENTMETHODRECARGE_"+sGXsfl_54_idx;
      }

      protected void SubsflControlProps_fel_542( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_54_fel_idx;
         edtPaymentMethodId_Internalname = "PAYMENTMETHODID_"+sGXsfl_54_fel_idx;
         chkPaymentMethodActive_Internalname = "PAYMENTMETHODACTIVE_"+sGXsfl_54_fel_idx;
         edtPaymentMethodDiscount_Internalname = "PAYMENTMETHODDISCOUNT_"+sGXsfl_54_fel_idx;
         edtPaymentMethodRecarge_Internalname = "PAYMENTMETHODRECARGE_"+sGXsfl_54_fel_idx;
      }

      protected void sendrow_542( )
      {
         SubsflControlProps_542( ) ;
         WB470( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_54_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_54_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_54_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A115PaymentMethodId), 6, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_54_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV14Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV14Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPaymentMethodId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A115PaymentMethodId), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A115PaymentMethodId), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPaymentMethodId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)54,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "PAYMENTMETHODACTIVE_" + sGXsfl_54_idx;
            chkPaymentMethodActive.Name = GXCCtl;
            chkPaymentMethodActive.WebTags = "";
            chkPaymentMethodActive.Caption = "";
            AssignProp("", false, chkPaymentMethodActive_Internalname, "TitleCaption", chkPaymentMethodActive.Caption, !bGXsfl_54_Refreshing);
            chkPaymentMethodActive.CheckedValue = "false";
            A117PaymentMethodActive = StringUtil.StrToBool( StringUtil.BoolToStr( A117PaymentMethodActive));
            Grid1Row.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkPaymentMethodActive_Internalname,StringUtil.BoolToStr( A117PaymentMethodActive),(string)"",(string)"",(short)-1,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn OptionalColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPaymentMethodDiscount_Internalname,StringUtil.LTrim( StringUtil.NToC( A129PaymentMethodDiscount, 8, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A129PaymentMethodDiscount, "ZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPaymentMethodDiscount_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)54,(short)0,(short)-1,(short)0,(bool)true,(string)"Percentage",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPaymentMethodRecarge_Internalname,StringUtil.LTrim( StringUtil.NToC( A130PaymentMethodRecarge, 8, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A130PaymentMethodRecarge, "ZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPaymentMethodRecarge_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)54,(short)0,(short)-1,(short)0,(bool)true,(string)"Percentage",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes472( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_54_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_54_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_54_idx+1);
            sGXsfl_54_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_54_idx), 4, 0), 4, "0");
            SubsflControlProps_542( ) ;
         }
         /* End function sendrow_542 */
      }

      protected void init_web_controls( )
      {
         chkavCpaymentmethodactive.Name = "vCPAYMENTMETHODACTIVE";
         chkavCpaymentmethodactive.WebTags = "";
         chkavCpaymentmethodactive.Caption = "";
         AssignProp("", false, chkavCpaymentmethodactive_Internalname, "TitleCaption", chkavCpaymentmethodactive.Caption, true);
         chkavCpaymentmethodactive.CheckedValue = "false";
         AV7cPaymentMethodActive = StringUtil.StrToBool( StringUtil.BoolToStr( AV7cPaymentMethodActive));
         AssignAttri("", false, "AV7cPaymentMethodActive", AV7cPaymentMethodActive);
         GXCCtl = "PAYMENTMETHODACTIVE_" + sGXsfl_54_idx;
         chkPaymentMethodActive.Name = GXCCtl;
         chkPaymentMethodActive.WebTags = "";
         chkPaymentMethodActive.Caption = "";
         AssignProp("", false, chkPaymentMethodActive_Internalname, "TitleCaption", chkPaymentMethodActive.Caption, !bGXsfl_54_Refreshing);
         chkPaymentMethodActive.CheckedValue = "false";
         A117PaymentMethodActive = StringUtil.StrToBool( StringUtil.BoolToStr( A117PaymentMethodActive));
         /* End function init_web_controls */
      }

      protected void StartGridControl54( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"54\">") ;
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
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Method Active") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Method Discount") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Method Recarge") ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A115PaymentMethodId), 6, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A117PaymentMethodActive)));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A129PaymentMethodDiscount, 8, 2, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A130PaymentMethodRecarge, 8, 2, ".", ""))));
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
         lblLblpaymentmethodidfilter_Internalname = "LBLPAYMENTMETHODIDFILTER";
         edtavCpaymentmethodid_Internalname = "vCPAYMENTMETHODID";
         divPaymentmethodidfiltercontainer_Internalname = "PAYMENTMETHODIDFILTERCONTAINER";
         lblLblpaymentmethodactivefilter_Internalname = "LBLPAYMENTMETHODACTIVEFILTER";
         chkavCpaymentmethodactive_Internalname = "vCPAYMENTMETHODACTIVE";
         divPaymentmethodactivefiltercontainer_Internalname = "PAYMENTMETHODACTIVEFILTERCONTAINER";
         lblLblpaymentmethoddiscountfilter_Internalname = "LBLPAYMENTMETHODDISCOUNTFILTER";
         edtavCpaymentmethoddiscount_Internalname = "vCPAYMENTMETHODDISCOUNT";
         divPaymentmethoddiscountfiltercontainer_Internalname = "PAYMENTMETHODDISCOUNTFILTERCONTAINER";
         lblLblpaymentmethodrecargefilter_Internalname = "LBLPAYMENTMETHODRECARGEFILTER";
         edtavCpaymentmethodrecarge_Internalname = "vCPAYMENTMETHODRECARGE";
         divPaymentmethodrecargefiltercontainer_Internalname = "PAYMENTMETHODRECARGEFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtPaymentMethodId_Internalname = "PAYMENTMETHODID";
         chkPaymentMethodActive_Internalname = "PAYMENTMETHODACTIVE";
         edtPaymentMethodDiscount_Internalname = "PAYMENTMETHODDISCOUNT";
         edtPaymentMethodRecarge_Internalname = "PAYMENTMETHODRECARGE";
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
         chkavCpaymentmethodactive.Caption = "Payment Method Active";
         edtPaymentMethodRecarge_Jsonclick = "";
         edtPaymentMethodDiscount_Jsonclick = "";
         chkPaymentMethodActive.Caption = "";
         edtPaymentMethodId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCpaymentmethodrecarge_Jsonclick = "";
         edtavCpaymentmethodrecarge_Enabled = 1;
         edtavCpaymentmethodrecarge_Visible = 1;
         edtavCpaymentmethoddiscount_Jsonclick = "";
         edtavCpaymentmethoddiscount_Enabled = 1;
         edtavCpaymentmethoddiscount_Visible = 1;
         chkavCpaymentmethodactive.Enabled = 1;
         chkavCpaymentmethodactive.Visible = 1;
         edtavCpaymentmethodid_Jsonclick = "";
         edtavCpaymentmethodid_Enabled = 1;
         edtavCpaymentmethodid_Visible = 1;
         divPaymentmethodrecargefiltercontainer_Class = "AdvancedContainerItem";
         divPaymentmethoddiscountfiltercontainer_Class = "AdvancedContainerItem";
         divPaymentmethodactivefiltercontainer_Class = "AdvancedContainerItem";
         divPaymentmethodidfiltercontainer_Class = "AdvancedContainerItem";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List Payment Method of Invoices";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cPaymentMethodId',fld:'vCPAYMENTMETHODID',pic:'ZZZZZ9'},{av:'AV10cPaymentMethodDiscount',fld:'vCPAYMENTMETHODDISCOUNT',pic:'ZZZZ9.99'},{av:'AV11cPaymentMethodRecarge',fld:'vCPAYMENTMETHODRECARGE',pic:'ZZZZ9.99'},{av:'AV7cPaymentMethodActive',fld:'vCPAYMENTMETHODACTIVE',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E15471',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLPAYMENTMETHODIDFILTER.CLICK","{handler:'E11471',iparms:[{av:'divPaymentmethodidfiltercontainer_Class',ctrl:'PAYMENTMETHODIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPAYMENTMETHODIDFILTER.CLICK",",oparms:[{av:'divPaymentmethodidfiltercontainer_Class',ctrl:'PAYMENTMETHODIDFILTERCONTAINER',prop:'Class'},{av:'edtavCpaymentmethodid_Visible',ctrl:'vCPAYMENTMETHODID',prop:'Visible'}]}");
         setEventMetadata("LBLPAYMENTMETHODACTIVEFILTER.CLICK","{handler:'E12471',iparms:[{av:'divPaymentmethodactivefiltercontainer_Class',ctrl:'PAYMENTMETHODACTIVEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPAYMENTMETHODACTIVEFILTER.CLICK",",oparms:[{av:'divPaymentmethodactivefiltercontainer_Class',ctrl:'PAYMENTMETHODACTIVEFILTERCONTAINER',prop:'Class'},{av:'chkavCpaymentmethodactive.Visible',ctrl:'vCPAYMENTMETHODACTIVE',prop:'Visible'}]}");
         setEventMetadata("LBLPAYMENTMETHODDISCOUNTFILTER.CLICK","{handler:'E13471',iparms:[{av:'divPaymentmethoddiscountfiltercontainer_Class',ctrl:'PAYMENTMETHODDISCOUNTFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPAYMENTMETHODDISCOUNTFILTER.CLICK",",oparms:[{av:'divPaymentmethoddiscountfiltercontainer_Class',ctrl:'PAYMENTMETHODDISCOUNTFILTERCONTAINER',prop:'Class'},{av:'edtavCpaymentmethoddiscount_Visible',ctrl:'vCPAYMENTMETHODDISCOUNT',prop:'Visible'}]}");
         setEventMetadata("LBLPAYMENTMETHODRECARGEFILTER.CLICK","{handler:'E14471',iparms:[{av:'divPaymentmethodrecargefiltercontainer_Class',ctrl:'PAYMENTMETHODRECARGEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPAYMENTMETHODRECARGEFILTER.CLICK",",oparms:[{av:'divPaymentmethodrecargefiltercontainer_Class',ctrl:'PAYMENTMETHODRECARGEFILTERCONTAINER',prop:'Class'},{av:'edtavCpaymentmethodrecarge_Visible',ctrl:'vCPAYMENTMETHODRECARGE',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E18472',iparms:[{av:'A115PaymentMethodId',fld:'PAYMENTMETHODID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV8pPaymentMethodId',fld:'vPPAYMENTMETHODID',pic:'ZZZZZ9'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cPaymentMethodId',fld:'vCPAYMENTMETHODID',pic:'ZZZZZ9'},{av:'AV10cPaymentMethodDiscount',fld:'vCPAYMENTMETHODDISCOUNT',pic:'ZZZZ9.99'},{av:'AV11cPaymentMethodRecarge',fld:'vCPAYMENTMETHODRECARGE',pic:'ZZZZ9.99'},{av:'AV7cPaymentMethodActive',fld:'vCPAYMENTMETHODACTIVE',pic:''}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cPaymentMethodId',fld:'vCPAYMENTMETHODID',pic:'ZZZZZ9'},{av:'AV10cPaymentMethodDiscount',fld:'vCPAYMENTMETHODDISCOUNT',pic:'ZZZZ9.99'},{av:'AV11cPaymentMethodRecarge',fld:'vCPAYMENTMETHODRECARGE',pic:'ZZZZ9.99'},{av:'AV7cPaymentMethodActive',fld:'vCPAYMENTMETHODACTIVE',pic:''}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cPaymentMethodId',fld:'vCPAYMENTMETHODID',pic:'ZZZZZ9'},{av:'AV10cPaymentMethodDiscount',fld:'vCPAYMENTMETHODDISCOUNT',pic:'ZZZZ9.99'},{av:'AV11cPaymentMethodRecarge',fld:'vCPAYMENTMETHODRECARGE',pic:'ZZZZ9.99'},{av:'AV7cPaymentMethodActive',fld:'vCPAYMENTMETHODACTIVE',pic:''}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cPaymentMethodId',fld:'vCPAYMENTMETHODID',pic:'ZZZZZ9'},{av:'AV10cPaymentMethodDiscount',fld:'vCPAYMENTMETHODDISCOUNT',pic:'ZZZZ9.99'},{av:'AV11cPaymentMethodRecarge',fld:'vCPAYMENTMETHODRECARGE',pic:'ZZZZ9.99'},{av:'AV7cPaymentMethodActive',fld:'vCPAYMENTMETHODACTIVE',pic:''}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CPAYMENTMETHODDISCOUNT","{handler:'Validv_Cpaymentmethoddiscount',iparms:[]");
         setEventMetadata("VALIDV_CPAYMENTMETHODDISCOUNT",",oparms:[]}");
         setEventMetadata("VALIDV_CPAYMENTMETHODRECARGE","{handler:'Validv_Cpaymentmethodrecarge',iparms:[]");
         setEventMetadata("VALIDV_CPAYMENTMETHODRECARGE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Paymentmethodrecarge',iparms:[]");
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
         lblLblpaymentmethodidfilter_Jsonclick = "";
         TempTags = "";
         lblLblpaymentmethodactivefilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         lblLblpaymentmethoddiscountfilter_Jsonclick = "";
         lblLblpaymentmethodrecargefilter_Jsonclick = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV5LinkSelection = "";
         AV14Linkselection_GXI = "";
         scmdbuf = "";
         H00472_A130PaymentMethodRecarge = new decimal[1] ;
         H00472_A129PaymentMethodDiscount = new decimal[1] ;
         H00472_A117PaymentMethodActive = new bool[] {false} ;
         H00472_A115PaymentMethodId = new int[1] ;
         H00473_AGRID1_nRecordCount = new long[1] ;
         AV9ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         GXCCtl = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx00k0__default(),
            new Object[][] {
                new Object[] {
               H00472_A130PaymentMethodRecarge, H00472_A129PaymentMethodDiscount, H00472_A117PaymentMethodActive, H00472_A115PaymentMethodId
               }
               , new Object[] {
               H00473_AGRID1_nRecordCount
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
      private int AV8pPaymentMethodId ;
      private int nRC_GXsfl_54 ;
      private int subGrid1_Rows ;
      private int nGXsfl_54_idx=1 ;
      private int AV6cPaymentMethodId ;
      private int edtavCpaymentmethodid_Enabled ;
      private int edtavCpaymentmethodid_Visible ;
      private int edtavCpaymentmethoddiscount_Enabled ;
      private int edtavCpaymentmethoddiscount_Visible ;
      private int edtavCpaymentmethodrecarge_Enabled ;
      private int edtavCpaymentmethodrecarge_Visible ;
      private int A115PaymentMethodId ;
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
      private decimal AV10cPaymentMethodDiscount ;
      private decimal AV11cPaymentMethodRecarge ;
      private decimal A129PaymentMethodDiscount ;
      private decimal A130PaymentMethodRecarge ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divPaymentmethodidfiltercontainer_Class ;
      private string divPaymentmethodactivefiltercontainer_Class ;
      private string divPaymentmethoddiscountfiltercontainer_Class ;
      private string divPaymentmethodrecargefiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_54_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divPaymentmethodidfiltercontainer_Internalname ;
      private string lblLblpaymentmethodidfilter_Internalname ;
      private string lblLblpaymentmethodidfilter_Jsonclick ;
      private string edtavCpaymentmethodid_Internalname ;
      private string TempTags ;
      private string edtavCpaymentmethodid_Jsonclick ;
      private string divPaymentmethodactivefiltercontainer_Internalname ;
      private string lblLblpaymentmethodactivefilter_Internalname ;
      private string lblLblpaymentmethodactivefilter_Jsonclick ;
      private string chkavCpaymentmethodactive_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divPaymentmethoddiscountfiltercontainer_Internalname ;
      private string lblLblpaymentmethoddiscountfilter_Internalname ;
      private string lblLblpaymentmethoddiscountfilter_Jsonclick ;
      private string edtavCpaymentmethoddiscount_Internalname ;
      private string edtavCpaymentmethoddiscount_Jsonclick ;
      private string divPaymentmethodrecargefiltercontainer_Internalname ;
      private string lblLblpaymentmethodrecargefilter_Internalname ;
      private string lblLblpaymentmethodrecargefilter_Jsonclick ;
      private string edtavCpaymentmethodrecarge_Internalname ;
      private string edtavCpaymentmethodrecarge_Jsonclick ;
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
      private string edtPaymentMethodId_Internalname ;
      private string chkPaymentMethodActive_Internalname ;
      private string edtPaymentMethodDiscount_Internalname ;
      private string edtPaymentMethodRecarge_Internalname ;
      private string scmdbuf ;
      private string AV9ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_54_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtPaymentMethodId_Jsonclick ;
      private string GXCCtl ;
      private string edtPaymentMethodDiscount_Jsonclick ;
      private string edtPaymentMethodRecarge_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV7cPaymentMethodActive ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_54_Refreshing=false ;
      private bool A117PaymentMethodActive ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV14Linkselection_GXI ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavCpaymentmethodactive ;
      private GXCheckbox chkPaymentMethodActive ;
      private IDataStoreProvider pr_default ;
      private decimal[] H00472_A130PaymentMethodRecarge ;
      private decimal[] H00472_A129PaymentMethodDiscount ;
      private bool[] H00472_A117PaymentMethodActive ;
      private int[] H00472_A115PaymentMethodId ;
      private long[] H00473_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private int aP0_pPaymentMethodId ;
      private GXWebForm Form ;
   }

   public class gx00k0__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00472( IGxContext context ,
                                             bool AV7cPaymentMethodActive ,
                                             decimal AV10cPaymentMethodDiscount ,
                                             decimal AV11cPaymentMethodRecarge ,
                                             bool A117PaymentMethodActive ,
                                             decimal A129PaymentMethodDiscount ,
                                             decimal A130PaymentMethodRecarge ,
                                             int AV6cPaymentMethodId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[7];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [PaymentMethodRecarge], [PaymentMethodDiscount], [PaymentMethodActive], [PaymentMethodId]";
         sFromString = " FROM [PaymentMethod]";
         sOrderString = "";
         AddWhere(sWhereString, "([PaymentMethodId] >= @AV6cPaymentMethodId)");
         if ( ! (false==AV7cPaymentMethodActive) )
         {
            AddWhere(sWhereString, "([PaymentMethodActive] >= @AV7cPaymentMethodActive)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV10cPaymentMethodDiscount) )
         {
            AddWhere(sWhereString, "([PaymentMethodDiscount] >= @AV10cPaymentMethodDiscount)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV11cPaymentMethodRecarge) )
         {
            AddWhere(sWhereString, "([PaymentMethodRecarge] >= @AV11cPaymentMethodRecarge)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         sOrderString += " ORDER BY [PaymentMethodId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00473( IGxContext context ,
                                             bool AV7cPaymentMethodActive ,
                                             decimal AV10cPaymentMethodDiscount ,
                                             decimal AV11cPaymentMethodRecarge ,
                                             bool A117PaymentMethodActive ,
                                             decimal A129PaymentMethodDiscount ,
                                             decimal A130PaymentMethodRecarge ,
                                             int AV6cPaymentMethodId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[4];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [PaymentMethod]";
         AddWhere(sWhereString, "([PaymentMethodId] >= @AV6cPaymentMethodId)");
         if ( ! (false==AV7cPaymentMethodActive) )
         {
            AddWhere(sWhereString, "([PaymentMethodActive] >= @AV7cPaymentMethodActive)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV10cPaymentMethodDiscount) )
         {
            AddWhere(sWhereString, "([PaymentMethodDiscount] >= @AV10cPaymentMethodDiscount)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV11cPaymentMethodRecarge) )
         {
            AddWhere(sWhereString, "([PaymentMethodRecarge] >= @AV11cPaymentMethodRecarge)");
         }
         else
         {
            GXv_int3[3] = 1;
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
                     return conditional_H00472(context, (bool)dynConstraints[0] , (decimal)dynConstraints[1] , (decimal)dynConstraints[2] , (bool)dynConstraints[3] , (decimal)dynConstraints[4] , (decimal)dynConstraints[5] , (int)dynConstraints[6] );
               case 1 :
                     return conditional_H00473(context, (bool)dynConstraints[0] , (decimal)dynConstraints[1] , (decimal)dynConstraints[2] , (bool)dynConstraints[3] , (decimal)dynConstraints[4] , (decimal)dynConstraints[5] , (int)dynConstraints[6] );
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
          Object[] prmH00472;
          prmH00472 = new Object[] {
          new ParDef("@AV6cPaymentMethodId",GXType.Int32,6,0) ,
          new ParDef("@AV7cPaymentMethodActive",GXType.Boolean,4,0) ,
          new ParDef("@AV10cPaymentMethodDiscount",GXType.Decimal,8,2) ,
          new ParDef("@AV11cPaymentMethodRecarge",GXType.Decimal,8,2) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00473;
          prmH00473 = new Object[] {
          new ParDef("@AV6cPaymentMethodId",GXType.Int32,6,0) ,
          new ParDef("@AV7cPaymentMethodActive",GXType.Boolean,4,0) ,
          new ParDef("@AV10cPaymentMethodDiscount",GXType.Decimal,8,2) ,
          new ParDef("@AV11cPaymentMethodRecarge",GXType.Decimal,8,2)
          };
          def= new CursorDef[] {
              new CursorDef("H00472", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00472,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00473", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00473,1, GxCacheFrequency.OFF ,false,false )
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
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
