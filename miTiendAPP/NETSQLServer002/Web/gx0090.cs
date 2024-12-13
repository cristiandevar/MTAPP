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
   public class gx0090 : GXDataArea
   {
      public gx0090( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public gx0090( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out int aP0_pOrderDetailId )
      {
         this.AV13pOrderDetailId = 0 ;
         executePrivate();
         aP0_pOrderDetailId=this.AV13pOrderDetailId;
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
            gxfirstwebparm = GetFirstPar( "pOrderDetailId");
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
               gxfirstwebparm = GetFirstPar( "pOrderDetailId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pOrderDetailId");
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
               AV13pOrderDetailId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV13pOrderDetailId", StringUtil.LTrimStr( (decimal)(AV13pOrderDetailId), 6, 0));
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
         AV6cOrderDetailId = (int)(Math.Round(NumberUtil.Val( GetPar( "cOrderDetailId"), "."), 18, MidpointRounding.ToEven));
         AV7cProductId = (int)(Math.Round(NumberUtil.Val( GetPar( "cProductId"), "."), 18, MidpointRounding.ToEven));
         AV8cOrderDetailQuantity = (int)(Math.Round(NumberUtil.Val( GetPar( "cOrderDetailQuantity"), "."), 18, MidpointRounding.ToEven));
         AV9cOrderDetailCurrentPrice = NumberUtil.Val( GetPar( "cOrderDetailCurrentPrice"), ".");
         AV10cOrderDetailSuggestedPrice = NumberUtil.Val( GetPar( "cOrderDetailSuggestedPrice"), ".");
         AV11cOrderDetailCreatedDate = context.localUtil.ParseDateParm( GetPar( "cOrderDetailCreatedDate"));
         AV12cOrderDetailModifiedDate = context.localUtil.ParseDateParm( GetPar( "cOrderDetailModifiedDate"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cOrderDetailId, AV7cProductId, AV8cOrderDetailQuantity, AV9cOrderDetailCurrentPrice, AV10cOrderDetailSuggestedPrice, AV11cOrderDetailCreatedDate, AV12cOrderDetailModifiedDate) ;
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
         PA0C2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0C2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0090.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pOrderDetailId,6,0))}, new string[] {"pOrderDetailId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCORDERDETAILID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cOrderDetailId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCPRODUCTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cProductId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCORDERDETAILQUANTITY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cOrderDetailQuantity), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCORDERDETAILCURRENTPRICE", StringUtil.LTrim( StringUtil.NToC( AV9cOrderDetailCurrentPrice, 10, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCORDERDETAILSUGGESTEDPRICE", StringUtil.LTrim( StringUtil.NToC( AV10cOrderDetailSuggestedPrice, 10, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCORDERDETAILCREATEDDATE", context.localUtil.Format(AV11cOrderDetailCreatedDate, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vCORDERDETAILMODIFIEDDATE", context.localUtil.Format(AV12cOrderDetailModifiedDate, "99/99/99"));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPORDERDETAILID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pOrderDetailId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "ORDERDETAILIDFILTERCONTAINER_Class", StringUtil.RTrim( divOrderdetailidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PRODUCTIDFILTERCONTAINER_Class", StringUtil.RTrim( divProductidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ORDERDETAILQUANTITYFILTERCONTAINER_Class", StringUtil.RTrim( divOrderdetailquantityfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ORDERDETAILCURRENTPRICEFILTERCONTAINER_Class", StringUtil.RTrim( divOrderdetailcurrentpricefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ORDERDETAILSUGGESTEDPRICEFILTERCONTAINER_Class", StringUtil.RTrim( divOrderdetailsuggestedpricefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ORDERDETAILCREATEDDATEFILTERCONTAINER_Class", StringUtil.RTrim( divOrderdetailcreateddatefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ORDERDETAILMODIFIEDDATEFILTERCONTAINER_Class", StringUtil.RTrim( divOrderdetailmodifieddatefiltercontainer_Class));
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
            WE0C2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0C2( ) ;
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
         return formatLink("gx0090.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pOrderDetailId,6,0))}, new string[] {"pOrderDetailId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx0090" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List Order Detail" ;
      }

      protected void WB0C0( )
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
            GxWebStd.gx_div_start( context, divOrderdetailidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divOrderdetailidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblorderdetailidfilter_Internalname, "Order Detail Id", "", "", lblLblorderdetailidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e110c1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCorderdetailid_Internalname, "Order Detail Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCorderdetailid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cOrderDetailId), 6, 0, ".", "")), StringUtil.LTrim( ((edtavCorderdetailid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cOrderDetailId), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV6cOrderDetailId), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCorderdetailid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCorderdetailid_Visible, edtavCorderdetailid_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx0090.htm");
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
            GxWebStd.gx_label_ctrl( context, lblLblproductidfilter_Internalname, "Product Id", "", "", lblLblproductidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e120c1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0090.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCproductid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cProductId), 6, 0, ".", "")), StringUtil.LTrim( ((edtavCproductid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV7cProductId), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV7cProductId), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCproductid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCproductid_Visible, edtavCproductid_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx0090.htm");
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
            GxWebStd.gx_div_start( context, divOrderdetailquantityfiltercontainer_Internalname, 1, 0, "px", 0, "px", divOrderdetailquantityfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblorderdetailquantityfilter_Internalname, "Order Detail Quantity", "", "", lblLblorderdetailquantityfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e130c1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCorderdetailquantity_Internalname, "Order Detail Quantity", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCorderdetailquantity_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cOrderDetailQuantity), 6, 0, ".", "")), StringUtil.LTrim( ((edtavCorderdetailquantity_Enabled!=0) ? context.localUtil.Format( (decimal)(AV8cOrderDetailQuantity), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV8cOrderDetailQuantity), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCorderdetailquantity_Jsonclick, 0, "Attribute", "", "", "", "", edtavCorderdetailquantity_Visible, edtavCorderdetailquantity_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx0090.htm");
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
            GxWebStd.gx_div_start( context, divOrderdetailcurrentpricefiltercontainer_Internalname, 1, 0, "px", 0, "px", divOrderdetailcurrentpricefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblorderdetailcurrentpricefilter_Internalname, "Order Detail Current Price", "", "", lblLblorderdetailcurrentpricefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e140c1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCorderdetailcurrentprice_Internalname, "Order Detail Current Price", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCorderdetailcurrentprice_Internalname, StringUtil.LTrim( StringUtil.NToC( AV9cOrderDetailCurrentPrice, 10, 2, ".", "")), StringUtil.LTrim( ((edtavCorderdetailcurrentprice_Enabled!=0) ? context.localUtil.Format( AV9cOrderDetailCurrentPrice, "ZZZZZZ9.99") : context.localUtil.Format( AV9cOrderDetailCurrentPrice, "ZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCorderdetailcurrentprice_Jsonclick, 0, "Attribute", "", "", "", "", edtavCorderdetailcurrentprice_Visible, edtavCorderdetailcurrentprice_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx0090.htm");
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
            GxWebStd.gx_div_start( context, divOrderdetailsuggestedpricefiltercontainer_Internalname, 1, 0, "px", 0, "px", divOrderdetailsuggestedpricefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblorderdetailsuggestedpricefilter_Internalname, "Order Detail Suggested Price", "", "", lblLblorderdetailsuggestedpricefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e150c1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCorderdetailsuggestedprice_Internalname, "Order Detail Suggested Price", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCorderdetailsuggestedprice_Internalname, StringUtil.LTrim( StringUtil.NToC( AV10cOrderDetailSuggestedPrice, 10, 2, ".", "")), StringUtil.LTrim( ((edtavCorderdetailsuggestedprice_Enabled!=0) ? context.localUtil.Format( AV10cOrderDetailSuggestedPrice, "ZZZZZZ9.99") : context.localUtil.Format( AV10cOrderDetailSuggestedPrice, "ZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCorderdetailsuggestedprice_Jsonclick, 0, "Attribute", "", "", "", "", edtavCorderdetailsuggestedprice_Visible, edtavCorderdetailsuggestedprice_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx0090.htm");
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
            GxWebStd.gx_div_start( context, divOrderdetailcreateddatefiltercontainer_Internalname, 1, 0, "px", 0, "px", divOrderdetailcreateddatefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblorderdetailcreateddatefilter_Internalname, "Order Detail Created Date", "", "", lblLblorderdetailcreateddatefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e160c1_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCorderdetailcreateddate_Internalname, "Order Detail Created Date", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCorderdetailcreateddate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCorderdetailcreateddate_Internalname, context.localUtil.Format(AV11cOrderDetailCreatedDate, "99/99/99"), context.localUtil.Format( AV11cOrderDetailCreatedDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCorderdetailcreateddate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCorderdetailcreateddate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx0090.htm");
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
            GxWebStd.gx_div_start( context, divOrderdetailmodifieddatefiltercontainer_Internalname, 1, 0, "px", 0, "px", divOrderdetailmodifieddatefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblorderdetailmodifieddatefilter_Internalname, "Order Detail Modified Date", "", "", lblLblorderdetailmodifieddatefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e170c1_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCorderdetailmodifieddate_Internalname, "Order Detail Modified Date", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCorderdetailmodifieddate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCorderdetailmodifieddate_Internalname, context.localUtil.Format(AV12cOrderDetailModifiedDate, "99/99/99"), context.localUtil.Format( AV12cOrderDetailModifiedDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCorderdetailmodifieddate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCorderdetailmodifieddate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx0090.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e180c1_client"+"'", TempTags, "", 2, "HLP_Gx0090.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0090.htm");
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

      protected void START0C2( )
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
            Form.Meta.addItem("description", "Selection List Order Detail", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0C0( ) ;
      }

      protected void WS0C2( )
      {
         START0C2( ) ;
         EVT0C2( ) ;
      }

      protected void EVT0C2( )
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
                              A44OrderDetailId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtOrderDetailId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A15ProductId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtProductId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A45OrderDetailQuantity = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtOrderDetailQuantity_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A46OrderDetailCurrentPrice = context.localUtil.CToN( cgiGet( edtOrderDetailCurrentPrice_Internalname), ".", ",");
                              A47OrderDetailSuggestedPrice = context.localUtil.CToN( cgiGet( edtOrderDetailSuggestedPrice_Internalname), ".", ",");
                              n47OrderDetailSuggestedPrice = false;
                              A48OrderDetailCreatedDate = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtOrderDetailCreatedDate_Internalname), 0));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E190C2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E200C2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Corderdetailid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCORDERDETAILID"), ".", ",") != Convert.ToDecimal( AV6cOrderDetailId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cproductid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPRODUCTID"), ".", ",") != Convert.ToDecimal( AV7cProductId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Corderdetailquantity Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCORDERDETAILQUANTITY"), ".", ",") != Convert.ToDecimal( AV8cOrderDetailQuantity )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Corderdetailcurrentprice Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCORDERDETAILCURRENTPRICE"), ".", ",") != AV9cOrderDetailCurrentPrice )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Corderdetailsuggestedprice Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCORDERDETAILSUGGESTEDPRICE"), ".", ",") != AV10cOrderDetailSuggestedPrice )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Corderdetailcreateddate Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCORDERDETAILCREATEDDATE"), 0) != AV11cOrderDetailCreatedDate )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Corderdetailmodifieddate Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCORDERDETAILMODIFIEDDATE"), 0) != AV12cOrderDetailModifiedDate )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E210C2 ();
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

      protected void WE0C2( )
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

      protected void PA0C2( )
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
                                        int AV6cOrderDetailId ,
                                        int AV7cProductId ,
                                        int AV8cOrderDetailQuantity ,
                                        decimal AV9cOrderDetailCurrentPrice ,
                                        decimal AV10cOrderDetailSuggestedPrice ,
                                        DateTime AV11cOrderDetailCreatedDate ,
                                        DateTime AV12cOrderDetailModifiedDate )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF0C2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_ORDERDETAILID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A44OrderDetailId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "ORDERDETAILID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A44OrderDetailId), 6, 0, ".", "")));
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
         RF0C2( ) ;
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

      protected void RF0C2( )
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
                                                 AV7cProductId ,
                                                 AV8cOrderDetailQuantity ,
                                                 AV9cOrderDetailCurrentPrice ,
                                                 AV10cOrderDetailSuggestedPrice ,
                                                 AV11cOrderDetailCreatedDate ,
                                                 AV12cOrderDetailModifiedDate ,
                                                 A15ProductId ,
                                                 A45OrderDetailQuantity ,
                                                 A46OrderDetailCurrentPrice ,
                                                 A47OrderDetailSuggestedPrice ,
                                                 A48OrderDetailCreatedDate ,
                                                 A49OrderDetailModifiedDate ,
                                                 AV6cOrderDetailId } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                                 TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT
                                                 }
            });
            /* Using cursor H000C2 */
            pr_default.execute(0, new Object[] {AV6cOrderDetailId, AV7cProductId, AV8cOrderDetailQuantity, AV9cOrderDetailCurrentPrice, AV10cOrderDetailSuggestedPrice, AV11cOrderDetailCreatedDate, AV12cOrderDetailModifiedDate, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A49OrderDetailModifiedDate = H000C2_A49OrderDetailModifiedDate[0];
               n49OrderDetailModifiedDate = H000C2_n49OrderDetailModifiedDate[0];
               A48OrderDetailCreatedDate = H000C2_A48OrderDetailCreatedDate[0];
               A47OrderDetailSuggestedPrice = H000C2_A47OrderDetailSuggestedPrice[0];
               n47OrderDetailSuggestedPrice = H000C2_n47OrderDetailSuggestedPrice[0];
               A46OrderDetailCurrentPrice = H000C2_A46OrderDetailCurrentPrice[0];
               A45OrderDetailQuantity = H000C2_A45OrderDetailQuantity[0];
               A15ProductId = H000C2_A15ProductId[0];
               A44OrderDetailId = H000C2_A44OrderDetailId[0];
               /* Execute user event: Load */
               E200C2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB0C0( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0C2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_ORDERDETAILID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A44OrderDetailId), "ZZZZZ9"), context));
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
                                              AV7cProductId ,
                                              AV8cOrderDetailQuantity ,
                                              AV9cOrderDetailCurrentPrice ,
                                              AV10cOrderDetailSuggestedPrice ,
                                              AV11cOrderDetailCreatedDate ,
                                              AV12cOrderDetailModifiedDate ,
                                              A15ProductId ,
                                              A45OrderDetailQuantity ,
                                              A46OrderDetailCurrentPrice ,
                                              A47OrderDetailSuggestedPrice ,
                                              A48OrderDetailCreatedDate ,
                                              A49OrderDetailModifiedDate ,
                                              AV6cOrderDetailId } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         /* Using cursor H000C3 */
         pr_default.execute(1, new Object[] {AV6cOrderDetailId, AV7cProductId, AV8cOrderDetailQuantity, AV9cOrderDetailCurrentPrice, AV10cOrderDetailSuggestedPrice, AV11cOrderDetailCreatedDate, AV12cOrderDetailModifiedDate});
         GRID1_nRecordCount = H000C3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cOrderDetailId, AV7cProductId, AV8cOrderDetailQuantity, AV9cOrderDetailCurrentPrice, AV10cOrderDetailSuggestedPrice, AV11cOrderDetailCreatedDate, AV12cOrderDetailModifiedDate) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cOrderDetailId, AV7cProductId, AV8cOrderDetailQuantity, AV9cOrderDetailCurrentPrice, AV10cOrderDetailSuggestedPrice, AV11cOrderDetailCreatedDate, AV12cOrderDetailModifiedDate) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cOrderDetailId, AV7cProductId, AV8cOrderDetailQuantity, AV9cOrderDetailCurrentPrice, AV10cOrderDetailSuggestedPrice, AV11cOrderDetailCreatedDate, AV12cOrderDetailModifiedDate) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cOrderDetailId, AV7cProductId, AV8cOrderDetailQuantity, AV9cOrderDetailCurrentPrice, AV10cOrderDetailSuggestedPrice, AV11cOrderDetailCreatedDate, AV12cOrderDetailModifiedDate) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cOrderDetailId, AV7cProductId, AV8cOrderDetailQuantity, AV9cOrderDetailCurrentPrice, AV10cOrderDetailSuggestedPrice, AV11cOrderDetailCreatedDate, AV12cOrderDetailModifiedDate) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0C0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E190C2 ();
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCorderdetailid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCorderdetailid_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCORDERDETAILID");
               GX_FocusControl = edtavCorderdetailid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cOrderDetailId = 0;
               AssignAttri("", false, "AV6cOrderDetailId", StringUtil.LTrimStr( (decimal)(AV6cOrderDetailId), 6, 0));
            }
            else
            {
               AV6cOrderDetailId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCorderdetailid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cOrderDetailId", StringUtil.LTrimStr( (decimal)(AV6cOrderDetailId), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCproductid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCproductid_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCPRODUCTID");
               GX_FocusControl = edtavCproductid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cProductId = 0;
               AssignAttri("", false, "AV7cProductId", StringUtil.LTrimStr( (decimal)(AV7cProductId), 6, 0));
            }
            else
            {
               AV7cProductId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCproductid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7cProductId", StringUtil.LTrimStr( (decimal)(AV7cProductId), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCorderdetailquantity_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCorderdetailquantity_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCORDERDETAILQUANTITY");
               GX_FocusControl = edtavCorderdetailquantity_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cOrderDetailQuantity = 0;
               AssignAttri("", false, "AV8cOrderDetailQuantity", StringUtil.LTrimStr( (decimal)(AV8cOrderDetailQuantity), 6, 0));
            }
            else
            {
               AV8cOrderDetailQuantity = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCorderdetailquantity_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV8cOrderDetailQuantity", StringUtil.LTrimStr( (decimal)(AV8cOrderDetailQuantity), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCorderdetailcurrentprice_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCorderdetailcurrentprice_Internalname), ".", ",") > 9999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCORDERDETAILCURRENTPRICE");
               GX_FocusControl = edtavCorderdetailcurrentprice_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9cOrderDetailCurrentPrice = 0;
               AssignAttri("", false, "AV9cOrderDetailCurrentPrice", StringUtil.LTrimStr( AV9cOrderDetailCurrentPrice, 10, 2));
            }
            else
            {
               AV9cOrderDetailCurrentPrice = context.localUtil.CToN( cgiGet( edtavCorderdetailcurrentprice_Internalname), ".", ",");
               AssignAttri("", false, "AV9cOrderDetailCurrentPrice", StringUtil.LTrimStr( AV9cOrderDetailCurrentPrice, 10, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCorderdetailsuggestedprice_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCorderdetailsuggestedprice_Internalname), ".", ",") > 9999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCORDERDETAILSUGGESTEDPRICE");
               GX_FocusControl = edtavCorderdetailsuggestedprice_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cOrderDetailSuggestedPrice = 0;
               AssignAttri("", false, "AV10cOrderDetailSuggestedPrice", StringUtil.LTrimStr( AV10cOrderDetailSuggestedPrice, 10, 2));
            }
            else
            {
               AV10cOrderDetailSuggestedPrice = context.localUtil.CToN( cgiGet( edtavCorderdetailsuggestedprice_Internalname), ".", ",");
               AssignAttri("", false, "AV10cOrderDetailSuggestedPrice", StringUtil.LTrimStr( AV10cOrderDetailSuggestedPrice, 10, 2));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCorderdetailcreateddate_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Order Detail Created Date"}), 1, "vCORDERDETAILCREATEDDATE");
               GX_FocusControl = edtavCorderdetailcreateddate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cOrderDetailCreatedDate = DateTime.MinValue;
               AssignAttri("", false, "AV11cOrderDetailCreatedDate", context.localUtil.Format(AV11cOrderDetailCreatedDate, "99/99/99"));
            }
            else
            {
               AV11cOrderDetailCreatedDate = context.localUtil.CToD( cgiGet( edtavCorderdetailcreateddate_Internalname), 1);
               AssignAttri("", false, "AV11cOrderDetailCreatedDate", context.localUtil.Format(AV11cOrderDetailCreatedDate, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCorderdetailmodifieddate_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Order Detail Modified Date"}), 1, "vCORDERDETAILMODIFIEDDATE");
               GX_FocusControl = edtavCorderdetailmodifieddate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12cOrderDetailModifiedDate = DateTime.MinValue;
               AssignAttri("", false, "AV12cOrderDetailModifiedDate", context.localUtil.Format(AV12cOrderDetailModifiedDate, "99/99/99"));
            }
            else
            {
               AV12cOrderDetailModifiedDate = context.localUtil.CToD( cgiGet( edtavCorderdetailmodifieddate_Internalname), 1);
               AssignAttri("", false, "AV12cOrderDetailModifiedDate", context.localUtil.Format(AV12cOrderDetailModifiedDate, "99/99/99"));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCORDERDETAILID"), ".", ",") != Convert.ToDecimal( AV6cOrderDetailId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPRODUCTID"), ".", ",") != Convert.ToDecimal( AV7cProductId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCORDERDETAILQUANTITY"), ".", ",") != Convert.ToDecimal( AV8cOrderDetailQuantity )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCORDERDETAILCURRENTPRICE"), ".", ",") != AV9cOrderDetailCurrentPrice )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCORDERDETAILSUGGESTEDPRICE"), ".", ",") != AV10cOrderDetailSuggestedPrice )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCORDERDETAILCREATEDDATE"), 1) ) != DateTimeUtil.ResetTime ( AV11cOrderDetailCreatedDate ) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCORDERDETAILMODIFIEDDATE"), 1) ) != DateTimeUtil.ResetTime ( AV12cOrderDetailModifiedDate ) )
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
         E190C2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E190C2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Selection List %1", "Order Detail", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E200C2( )
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
         E210C2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E210C2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pOrderDetailId = A44OrderDetailId;
         AssignAttri("", false, "AV13pOrderDetailId", StringUtil.LTrimStr( (decimal)(AV13pOrderDetailId), 6, 0));
         context.setWebReturnParms(new Object[] {(int)AV13pOrderDetailId});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pOrderDetailId"});
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
         AV13pOrderDetailId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV13pOrderDetailId", StringUtil.LTrimStr( (decimal)(AV13pOrderDetailId), 6, 0));
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
         PA0C2( ) ;
         WS0C2( ) ;
         WE0C2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202311220391629", true, true);
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
         context.AddJavascriptSource("gx0090.js", "?202311220391629", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtOrderDetailId_Internalname = "ORDERDETAILID_"+sGXsfl_84_idx;
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_84_idx;
         edtOrderDetailQuantity_Internalname = "ORDERDETAILQUANTITY_"+sGXsfl_84_idx;
         edtOrderDetailCurrentPrice_Internalname = "ORDERDETAILCURRENTPRICE_"+sGXsfl_84_idx;
         edtOrderDetailSuggestedPrice_Internalname = "ORDERDETAILSUGGESTEDPRICE_"+sGXsfl_84_idx;
         edtOrderDetailCreatedDate_Internalname = "ORDERDETAILCREATEDDATE_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtOrderDetailId_Internalname = "ORDERDETAILID_"+sGXsfl_84_fel_idx;
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_84_fel_idx;
         edtOrderDetailQuantity_Internalname = "ORDERDETAILQUANTITY_"+sGXsfl_84_fel_idx;
         edtOrderDetailCurrentPrice_Internalname = "ORDERDETAILCURRENTPRICE_"+sGXsfl_84_fel_idx;
         edtOrderDetailSuggestedPrice_Internalname = "ORDERDETAILSUGGESTEDPRICE_"+sGXsfl_84_fel_idx;
         edtOrderDetailCreatedDate_Internalname = "ORDERDETAILCREATEDDATE_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         SubsflControlProps_842( ) ;
         WB0C0( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A44OrderDetailId), 6, 0, ".", "")))+"'"+"]);";
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
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOrderDetailId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A44OrderDetailId), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A44OrderDetailId), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOrderDetailId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
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
            edtOrderDetailQuantity_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A44OrderDetailId), 6, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtOrderDetailQuantity_Internalname, "Link", edtOrderDetailQuantity_Link, !bGXsfl_84_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOrderDetailQuantity_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A45OrderDetailQuantity), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A45OrderDetailQuantity), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtOrderDetailQuantity_Link,(string)"",(string)"",(string)"",(string)edtOrderDetailQuantity_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOrderDetailCurrentPrice_Internalname,StringUtil.LTrim( StringUtil.NToC( A46OrderDetailCurrentPrice, 10, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A46OrderDetailCurrentPrice, "ZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOrderDetailCurrentPrice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"Price",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOrderDetailSuggestedPrice_Internalname,StringUtil.LTrim( StringUtil.NToC( A47OrderDetailSuggestedPrice, 10, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A47OrderDetailSuggestedPrice, "ZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOrderDetailSuggestedPrice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"Price",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtOrderDetailCreatedDate_Internalname,context.localUtil.Format(A48OrderDetailCreatedDate, "99/99/99"),context.localUtil.Format( A48OrderDetailCreatedDate, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtOrderDetailCreatedDate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes0C2( ) ;
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
            context.SendWebValue( "Product Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Detail Quantity") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Current Price") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Suggested Price") ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A44OrderDetailId), 6, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A45OrderDetailQuantity), 6, 0, ".", ""))));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtOrderDetailQuantity_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A46OrderDetailCurrentPrice, 10, 2, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A47OrderDetailSuggestedPrice, 10, 2, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A48OrderDetailCreatedDate, "99/99/99")));
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
         lblLblorderdetailidfilter_Internalname = "LBLORDERDETAILIDFILTER";
         edtavCorderdetailid_Internalname = "vCORDERDETAILID";
         divOrderdetailidfiltercontainer_Internalname = "ORDERDETAILIDFILTERCONTAINER";
         lblLblproductidfilter_Internalname = "LBLPRODUCTIDFILTER";
         edtavCproductid_Internalname = "vCPRODUCTID";
         divProductidfiltercontainer_Internalname = "PRODUCTIDFILTERCONTAINER";
         lblLblorderdetailquantityfilter_Internalname = "LBLORDERDETAILQUANTITYFILTER";
         edtavCorderdetailquantity_Internalname = "vCORDERDETAILQUANTITY";
         divOrderdetailquantityfiltercontainer_Internalname = "ORDERDETAILQUANTITYFILTERCONTAINER";
         lblLblorderdetailcurrentpricefilter_Internalname = "LBLORDERDETAILCURRENTPRICEFILTER";
         edtavCorderdetailcurrentprice_Internalname = "vCORDERDETAILCURRENTPRICE";
         divOrderdetailcurrentpricefiltercontainer_Internalname = "ORDERDETAILCURRENTPRICEFILTERCONTAINER";
         lblLblorderdetailsuggestedpricefilter_Internalname = "LBLORDERDETAILSUGGESTEDPRICEFILTER";
         edtavCorderdetailsuggestedprice_Internalname = "vCORDERDETAILSUGGESTEDPRICE";
         divOrderdetailsuggestedpricefiltercontainer_Internalname = "ORDERDETAILSUGGESTEDPRICEFILTERCONTAINER";
         lblLblorderdetailcreateddatefilter_Internalname = "LBLORDERDETAILCREATEDDATEFILTER";
         edtavCorderdetailcreateddate_Internalname = "vCORDERDETAILCREATEDDATE";
         divOrderdetailcreateddatefiltercontainer_Internalname = "ORDERDETAILCREATEDDATEFILTERCONTAINER";
         lblLblorderdetailmodifieddatefilter_Internalname = "LBLORDERDETAILMODIFIEDDATEFILTER";
         edtavCorderdetailmodifieddate_Internalname = "vCORDERDETAILMODIFIEDDATE";
         divOrderdetailmodifieddatefiltercontainer_Internalname = "ORDERDETAILMODIFIEDDATEFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtOrderDetailId_Internalname = "ORDERDETAILID";
         edtProductId_Internalname = "PRODUCTID";
         edtOrderDetailQuantity_Internalname = "ORDERDETAILQUANTITY";
         edtOrderDetailCurrentPrice_Internalname = "ORDERDETAILCURRENTPRICE";
         edtOrderDetailSuggestedPrice_Internalname = "ORDERDETAILSUGGESTEDPRICE";
         edtOrderDetailCreatedDate_Internalname = "ORDERDETAILCREATEDDATE";
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
         edtOrderDetailCreatedDate_Jsonclick = "";
         edtOrderDetailSuggestedPrice_Jsonclick = "";
         edtOrderDetailCurrentPrice_Jsonclick = "";
         edtOrderDetailQuantity_Jsonclick = "";
         edtOrderDetailQuantity_Link = "";
         edtProductId_Jsonclick = "";
         edtOrderDetailId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCorderdetailmodifieddate_Jsonclick = "";
         edtavCorderdetailmodifieddate_Enabled = 1;
         edtavCorderdetailcreateddate_Jsonclick = "";
         edtavCorderdetailcreateddate_Enabled = 1;
         edtavCorderdetailsuggestedprice_Jsonclick = "";
         edtavCorderdetailsuggestedprice_Enabled = 1;
         edtavCorderdetailsuggestedprice_Visible = 1;
         edtavCorderdetailcurrentprice_Jsonclick = "";
         edtavCorderdetailcurrentprice_Enabled = 1;
         edtavCorderdetailcurrentprice_Visible = 1;
         edtavCorderdetailquantity_Jsonclick = "";
         edtavCorderdetailquantity_Enabled = 1;
         edtavCorderdetailquantity_Visible = 1;
         edtavCproductid_Jsonclick = "";
         edtavCproductid_Enabled = 1;
         edtavCproductid_Visible = 1;
         edtavCorderdetailid_Jsonclick = "";
         edtavCorderdetailid_Enabled = 1;
         edtavCorderdetailid_Visible = 1;
         divOrderdetailmodifieddatefiltercontainer_Class = "AdvancedContainerItem";
         divOrderdetailcreateddatefiltercontainer_Class = "AdvancedContainerItem";
         divOrderdetailsuggestedpricefiltercontainer_Class = "AdvancedContainerItem";
         divOrderdetailcurrentpricefiltercontainer_Class = "AdvancedContainerItem";
         divOrderdetailquantityfiltercontainer_Class = "AdvancedContainerItem";
         divProductidfiltercontainer_Class = "AdvancedContainerItem";
         divOrderdetailidfiltercontainer_Class = "AdvancedContainerItem";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List Order Detail";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cOrderDetailId',fld:'vCORDERDETAILID',pic:'ZZZZZ9'},{av:'AV7cProductId',fld:'vCPRODUCTID',pic:'ZZZZZ9'},{av:'AV8cOrderDetailQuantity',fld:'vCORDERDETAILQUANTITY',pic:'ZZZZZ9'},{av:'AV9cOrderDetailCurrentPrice',fld:'vCORDERDETAILCURRENTPRICE',pic:'ZZZZZZ9.99'},{av:'AV10cOrderDetailSuggestedPrice',fld:'vCORDERDETAILSUGGESTEDPRICE',pic:'ZZZZZZ9.99'},{av:'AV11cOrderDetailCreatedDate',fld:'vCORDERDETAILCREATEDDATE',pic:''},{av:'AV12cOrderDetailModifiedDate',fld:'vCORDERDETAILMODIFIEDDATE',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E180C1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLORDERDETAILIDFILTER.CLICK","{handler:'E110C1',iparms:[{av:'divOrderdetailidfiltercontainer_Class',ctrl:'ORDERDETAILIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLORDERDETAILIDFILTER.CLICK",",oparms:[{av:'divOrderdetailidfiltercontainer_Class',ctrl:'ORDERDETAILIDFILTERCONTAINER',prop:'Class'},{av:'edtavCorderdetailid_Visible',ctrl:'vCORDERDETAILID',prop:'Visible'}]}");
         setEventMetadata("LBLPRODUCTIDFILTER.CLICK","{handler:'E120C1',iparms:[{av:'divProductidfiltercontainer_Class',ctrl:'PRODUCTIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPRODUCTIDFILTER.CLICK",",oparms:[{av:'divProductidfiltercontainer_Class',ctrl:'PRODUCTIDFILTERCONTAINER',prop:'Class'},{av:'edtavCproductid_Visible',ctrl:'vCPRODUCTID',prop:'Visible'}]}");
         setEventMetadata("LBLORDERDETAILQUANTITYFILTER.CLICK","{handler:'E130C1',iparms:[{av:'divOrderdetailquantityfiltercontainer_Class',ctrl:'ORDERDETAILQUANTITYFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLORDERDETAILQUANTITYFILTER.CLICK",",oparms:[{av:'divOrderdetailquantityfiltercontainer_Class',ctrl:'ORDERDETAILQUANTITYFILTERCONTAINER',prop:'Class'},{av:'edtavCorderdetailquantity_Visible',ctrl:'vCORDERDETAILQUANTITY',prop:'Visible'}]}");
         setEventMetadata("LBLORDERDETAILCURRENTPRICEFILTER.CLICK","{handler:'E140C1',iparms:[{av:'divOrderdetailcurrentpricefiltercontainer_Class',ctrl:'ORDERDETAILCURRENTPRICEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLORDERDETAILCURRENTPRICEFILTER.CLICK",",oparms:[{av:'divOrderdetailcurrentpricefiltercontainer_Class',ctrl:'ORDERDETAILCURRENTPRICEFILTERCONTAINER',prop:'Class'},{av:'edtavCorderdetailcurrentprice_Visible',ctrl:'vCORDERDETAILCURRENTPRICE',prop:'Visible'}]}");
         setEventMetadata("LBLORDERDETAILSUGGESTEDPRICEFILTER.CLICK","{handler:'E150C1',iparms:[{av:'divOrderdetailsuggestedpricefiltercontainer_Class',ctrl:'ORDERDETAILSUGGESTEDPRICEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLORDERDETAILSUGGESTEDPRICEFILTER.CLICK",",oparms:[{av:'divOrderdetailsuggestedpricefiltercontainer_Class',ctrl:'ORDERDETAILSUGGESTEDPRICEFILTERCONTAINER',prop:'Class'},{av:'edtavCorderdetailsuggestedprice_Visible',ctrl:'vCORDERDETAILSUGGESTEDPRICE',prop:'Visible'}]}");
         setEventMetadata("LBLORDERDETAILCREATEDDATEFILTER.CLICK","{handler:'E160C1',iparms:[{av:'divOrderdetailcreateddatefiltercontainer_Class',ctrl:'ORDERDETAILCREATEDDATEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLORDERDETAILCREATEDDATEFILTER.CLICK",",oparms:[{av:'divOrderdetailcreateddatefiltercontainer_Class',ctrl:'ORDERDETAILCREATEDDATEFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLORDERDETAILMODIFIEDDATEFILTER.CLICK","{handler:'E170C1',iparms:[{av:'divOrderdetailmodifieddatefiltercontainer_Class',ctrl:'ORDERDETAILMODIFIEDDATEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLORDERDETAILMODIFIEDDATEFILTER.CLICK",",oparms:[{av:'divOrderdetailmodifieddatefiltercontainer_Class',ctrl:'ORDERDETAILMODIFIEDDATEFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("ENTER","{handler:'E210C2',iparms:[{av:'A44OrderDetailId',fld:'ORDERDETAILID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pOrderDetailId',fld:'vPORDERDETAILID',pic:'ZZZZZ9'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cOrderDetailId',fld:'vCORDERDETAILID',pic:'ZZZZZ9'},{av:'AV7cProductId',fld:'vCPRODUCTID',pic:'ZZZZZ9'},{av:'AV8cOrderDetailQuantity',fld:'vCORDERDETAILQUANTITY',pic:'ZZZZZ9'},{av:'AV9cOrderDetailCurrentPrice',fld:'vCORDERDETAILCURRENTPRICE',pic:'ZZZZZZ9.99'},{av:'AV10cOrderDetailSuggestedPrice',fld:'vCORDERDETAILSUGGESTEDPRICE',pic:'ZZZZZZ9.99'},{av:'AV11cOrderDetailCreatedDate',fld:'vCORDERDETAILCREATEDDATE',pic:''},{av:'AV12cOrderDetailModifiedDate',fld:'vCORDERDETAILMODIFIEDDATE',pic:''}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cOrderDetailId',fld:'vCORDERDETAILID',pic:'ZZZZZ9'},{av:'AV7cProductId',fld:'vCPRODUCTID',pic:'ZZZZZ9'},{av:'AV8cOrderDetailQuantity',fld:'vCORDERDETAILQUANTITY',pic:'ZZZZZ9'},{av:'AV9cOrderDetailCurrentPrice',fld:'vCORDERDETAILCURRENTPRICE',pic:'ZZZZZZ9.99'},{av:'AV10cOrderDetailSuggestedPrice',fld:'vCORDERDETAILSUGGESTEDPRICE',pic:'ZZZZZZ9.99'},{av:'AV11cOrderDetailCreatedDate',fld:'vCORDERDETAILCREATEDDATE',pic:''},{av:'AV12cOrderDetailModifiedDate',fld:'vCORDERDETAILMODIFIEDDATE',pic:''}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cOrderDetailId',fld:'vCORDERDETAILID',pic:'ZZZZZ9'},{av:'AV7cProductId',fld:'vCPRODUCTID',pic:'ZZZZZ9'},{av:'AV8cOrderDetailQuantity',fld:'vCORDERDETAILQUANTITY',pic:'ZZZZZ9'},{av:'AV9cOrderDetailCurrentPrice',fld:'vCORDERDETAILCURRENTPRICE',pic:'ZZZZZZ9.99'},{av:'AV10cOrderDetailSuggestedPrice',fld:'vCORDERDETAILSUGGESTEDPRICE',pic:'ZZZZZZ9.99'},{av:'AV11cOrderDetailCreatedDate',fld:'vCORDERDETAILCREATEDDATE',pic:''},{av:'AV12cOrderDetailModifiedDate',fld:'vCORDERDETAILMODIFIEDDATE',pic:''}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cOrderDetailId',fld:'vCORDERDETAILID',pic:'ZZZZZ9'},{av:'AV7cProductId',fld:'vCPRODUCTID',pic:'ZZZZZ9'},{av:'AV8cOrderDetailQuantity',fld:'vCORDERDETAILQUANTITY',pic:'ZZZZZ9'},{av:'AV9cOrderDetailCurrentPrice',fld:'vCORDERDETAILCURRENTPRICE',pic:'ZZZZZZ9.99'},{av:'AV10cOrderDetailSuggestedPrice',fld:'vCORDERDETAILSUGGESTEDPRICE',pic:'ZZZZZZ9.99'},{av:'AV11cOrderDetailCreatedDate',fld:'vCORDERDETAILCREATEDDATE',pic:''},{av:'AV12cOrderDetailModifiedDate',fld:'vCORDERDETAILMODIFIEDDATE',pic:''}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CORDERDETAILCREATEDDATE","{handler:'Validv_Corderdetailcreateddate',iparms:[]");
         setEventMetadata("VALIDV_CORDERDETAILCREATEDDATE",",oparms:[]}");
         setEventMetadata("VALIDV_CORDERDETAILMODIFIEDDATE","{handler:'Validv_Corderdetailmodifieddate',iparms:[]");
         setEventMetadata("VALIDV_CORDERDETAILMODIFIEDDATE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Orderdetailcreateddate',iparms:[]");
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
         AV11cOrderDetailCreatedDate = DateTime.MinValue;
         AV12cOrderDetailModifiedDate = DateTime.MinValue;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblorderdetailidfilter_Jsonclick = "";
         TempTags = "";
         lblLblproductidfilter_Jsonclick = "";
         lblLblorderdetailquantityfilter_Jsonclick = "";
         lblLblorderdetailcurrentpricefilter_Jsonclick = "";
         lblLblorderdetailsuggestedpricefilter_Jsonclick = "";
         lblLblorderdetailcreateddatefilter_Jsonclick = "";
         lblLblorderdetailmodifieddatefilter_Jsonclick = "";
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
         A48OrderDetailCreatedDate = DateTime.MinValue;
         scmdbuf = "";
         A49OrderDetailModifiedDate = DateTime.MinValue;
         H000C2_A49OrderDetailModifiedDate = new DateTime[] {DateTime.MinValue} ;
         H000C2_n49OrderDetailModifiedDate = new bool[] {false} ;
         H000C2_A48OrderDetailCreatedDate = new DateTime[] {DateTime.MinValue} ;
         H000C2_A47OrderDetailSuggestedPrice = new decimal[1] ;
         H000C2_n47OrderDetailSuggestedPrice = new bool[] {false} ;
         H000C2_A46OrderDetailCurrentPrice = new decimal[1] ;
         H000C2_A45OrderDetailQuantity = new int[1] ;
         H000C2_A15ProductId = new int[1] ;
         H000C2_A44OrderDetailId = new int[1] ;
         H000C3_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0090__default(),
            new Object[][] {
                new Object[] {
               H000C2_A49OrderDetailModifiedDate, H000C2_n49OrderDetailModifiedDate, H000C2_A48OrderDetailCreatedDate, H000C2_A47OrderDetailSuggestedPrice, H000C2_n47OrderDetailSuggestedPrice, H000C2_A46OrderDetailCurrentPrice, H000C2_A45OrderDetailQuantity, H000C2_A15ProductId, H000C2_A44OrderDetailId
               }
               , new Object[] {
               H000C3_AGRID1_nRecordCount
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
      private int AV13pOrderDetailId ;
      private int nRC_GXsfl_84 ;
      private int subGrid1_Rows ;
      private int nGXsfl_84_idx=1 ;
      private int AV6cOrderDetailId ;
      private int AV7cProductId ;
      private int AV8cOrderDetailQuantity ;
      private int edtavCorderdetailid_Enabled ;
      private int edtavCorderdetailid_Visible ;
      private int edtavCproductid_Enabled ;
      private int edtavCproductid_Visible ;
      private int edtavCorderdetailquantity_Enabled ;
      private int edtavCorderdetailquantity_Visible ;
      private int edtavCorderdetailcurrentprice_Enabled ;
      private int edtavCorderdetailcurrentprice_Visible ;
      private int edtavCorderdetailsuggestedprice_Enabled ;
      private int edtavCorderdetailsuggestedprice_Visible ;
      private int edtavCorderdetailcreateddate_Enabled ;
      private int edtavCorderdetailmodifieddate_Enabled ;
      private int A44OrderDetailId ;
      private int A15ProductId ;
      private int A45OrderDetailQuantity ;
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
      private decimal AV9cOrderDetailCurrentPrice ;
      private decimal AV10cOrderDetailSuggestedPrice ;
      private decimal A46OrderDetailCurrentPrice ;
      private decimal A47OrderDetailSuggestedPrice ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divOrderdetailidfiltercontainer_Class ;
      private string divProductidfiltercontainer_Class ;
      private string divOrderdetailquantityfiltercontainer_Class ;
      private string divOrderdetailcurrentpricefiltercontainer_Class ;
      private string divOrderdetailsuggestedpricefiltercontainer_Class ;
      private string divOrderdetailcreateddatefiltercontainer_Class ;
      private string divOrderdetailmodifieddatefiltercontainer_Class ;
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
      private string divOrderdetailidfiltercontainer_Internalname ;
      private string lblLblorderdetailidfilter_Internalname ;
      private string lblLblorderdetailidfilter_Jsonclick ;
      private string edtavCorderdetailid_Internalname ;
      private string TempTags ;
      private string edtavCorderdetailid_Jsonclick ;
      private string divProductidfiltercontainer_Internalname ;
      private string lblLblproductidfilter_Internalname ;
      private string lblLblproductidfilter_Jsonclick ;
      private string edtavCproductid_Internalname ;
      private string edtavCproductid_Jsonclick ;
      private string divOrderdetailquantityfiltercontainer_Internalname ;
      private string lblLblorderdetailquantityfilter_Internalname ;
      private string lblLblorderdetailquantityfilter_Jsonclick ;
      private string edtavCorderdetailquantity_Internalname ;
      private string edtavCorderdetailquantity_Jsonclick ;
      private string divOrderdetailcurrentpricefiltercontainer_Internalname ;
      private string lblLblorderdetailcurrentpricefilter_Internalname ;
      private string lblLblorderdetailcurrentpricefilter_Jsonclick ;
      private string edtavCorderdetailcurrentprice_Internalname ;
      private string edtavCorderdetailcurrentprice_Jsonclick ;
      private string divOrderdetailsuggestedpricefiltercontainer_Internalname ;
      private string lblLblorderdetailsuggestedpricefilter_Internalname ;
      private string lblLblorderdetailsuggestedpricefilter_Jsonclick ;
      private string edtavCorderdetailsuggestedprice_Internalname ;
      private string edtavCorderdetailsuggestedprice_Jsonclick ;
      private string divOrderdetailcreateddatefiltercontainer_Internalname ;
      private string lblLblorderdetailcreateddatefilter_Internalname ;
      private string lblLblorderdetailcreateddatefilter_Jsonclick ;
      private string edtavCorderdetailcreateddate_Internalname ;
      private string edtavCorderdetailcreateddate_Jsonclick ;
      private string divOrderdetailmodifieddatefiltercontainer_Internalname ;
      private string lblLblorderdetailmodifieddatefilter_Internalname ;
      private string lblLblorderdetailmodifieddatefilter_Jsonclick ;
      private string edtavCorderdetailmodifieddate_Internalname ;
      private string edtavCorderdetailmodifieddate_Jsonclick ;
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
      private string edtOrderDetailId_Internalname ;
      private string edtProductId_Internalname ;
      private string edtOrderDetailQuantity_Internalname ;
      private string edtOrderDetailCurrentPrice_Internalname ;
      private string edtOrderDetailSuggestedPrice_Internalname ;
      private string edtOrderDetailCreatedDate_Internalname ;
      private string scmdbuf ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtOrderDetailId_Jsonclick ;
      private string edtProductId_Jsonclick ;
      private string edtOrderDetailQuantity_Link ;
      private string edtOrderDetailQuantity_Jsonclick ;
      private string edtOrderDetailCurrentPrice_Jsonclick ;
      private string edtOrderDetailSuggestedPrice_Jsonclick ;
      private string edtOrderDetailCreatedDate_Jsonclick ;
      private string subGrid1_Header ;
      private DateTime AV11cOrderDetailCreatedDate ;
      private DateTime AV12cOrderDetailModifiedDate ;
      private DateTime A48OrderDetailCreatedDate ;
      private DateTime A49OrderDetailModifiedDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool n47OrderDetailSuggestedPrice ;
      private bool gxdyncontrolsrefreshing ;
      private bool n49OrderDetailModifiedDate ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV17Linkselection_GXI ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] H000C2_A49OrderDetailModifiedDate ;
      private bool[] H000C2_n49OrderDetailModifiedDate ;
      private DateTime[] H000C2_A48OrderDetailCreatedDate ;
      private decimal[] H000C2_A47OrderDetailSuggestedPrice ;
      private bool[] H000C2_n47OrderDetailSuggestedPrice ;
      private decimal[] H000C2_A46OrderDetailCurrentPrice ;
      private int[] H000C2_A45OrderDetailQuantity ;
      private int[] H000C2_A15ProductId ;
      private int[] H000C2_A44OrderDetailId ;
      private long[] H000C3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private int aP0_pOrderDetailId ;
      private GXWebForm Form ;
   }

   public class gx0090__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000C2( IGxContext context ,
                                             int AV7cProductId ,
                                             int AV8cOrderDetailQuantity ,
                                             decimal AV9cOrderDetailCurrentPrice ,
                                             decimal AV10cOrderDetailSuggestedPrice ,
                                             DateTime AV11cOrderDetailCreatedDate ,
                                             DateTime AV12cOrderDetailModifiedDate ,
                                             int A15ProductId ,
                                             int A45OrderDetailQuantity ,
                                             decimal A46OrderDetailCurrentPrice ,
                                             decimal A47OrderDetailSuggestedPrice ,
                                             DateTime A48OrderDetailCreatedDate ,
                                             DateTime A49OrderDetailModifiedDate ,
                                             int AV6cOrderDetailId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [OrderDetailModifiedDate], [OrderDetailCreatedDate], [OrderDetailSuggestedPrice], [OrderDetailCurrentPrice], [OrderDetailQuantity], [ProductId], [OrderDetailId]";
         sFromString = " FROM [OrderDetail]";
         sOrderString = "";
         AddWhere(sWhereString, "([OrderDetailId] >= @AV6cOrderDetailId)");
         if ( ! (0==AV7cProductId) )
         {
            AddWhere(sWhereString, "([ProductId] >= @AV7cProductId)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV8cOrderDetailQuantity) )
         {
            AddWhere(sWhereString, "([OrderDetailQuantity] >= @AV8cOrderDetailQuantity)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV9cOrderDetailCurrentPrice) )
         {
            AddWhere(sWhereString, "([OrderDetailCurrentPrice] >= @AV9cOrderDetailCurrentPrice)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV10cOrderDetailSuggestedPrice) )
         {
            AddWhere(sWhereString, "([OrderDetailSuggestedPrice] >= @AV10cOrderDetailSuggestedPrice)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV11cOrderDetailCreatedDate) )
         {
            AddWhere(sWhereString, "([OrderDetailCreatedDate] >= @AV11cOrderDetailCreatedDate)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV12cOrderDetailModifiedDate) )
         {
            AddWhere(sWhereString, "([OrderDetailModifiedDate] >= @AV12cOrderDetailModifiedDate)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [OrderDetailId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H000C3( IGxContext context ,
                                             int AV7cProductId ,
                                             int AV8cOrderDetailQuantity ,
                                             decimal AV9cOrderDetailCurrentPrice ,
                                             decimal AV10cOrderDetailSuggestedPrice ,
                                             DateTime AV11cOrderDetailCreatedDate ,
                                             DateTime AV12cOrderDetailModifiedDate ,
                                             int A15ProductId ,
                                             int A45OrderDetailQuantity ,
                                             decimal A46OrderDetailCurrentPrice ,
                                             decimal A47OrderDetailSuggestedPrice ,
                                             DateTime A48OrderDetailCreatedDate ,
                                             DateTime A49OrderDetailModifiedDate ,
                                             int AV6cOrderDetailId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [OrderDetail]";
         AddWhere(sWhereString, "([OrderDetailId] >= @AV6cOrderDetailId)");
         if ( ! (0==AV7cProductId) )
         {
            AddWhere(sWhereString, "([ProductId] >= @AV7cProductId)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (0==AV8cOrderDetailQuantity) )
         {
            AddWhere(sWhereString, "([OrderDetailQuantity] >= @AV8cOrderDetailQuantity)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV9cOrderDetailCurrentPrice) )
         {
            AddWhere(sWhereString, "([OrderDetailCurrentPrice] >= @AV9cOrderDetailCurrentPrice)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV10cOrderDetailSuggestedPrice) )
         {
            AddWhere(sWhereString, "([OrderDetailSuggestedPrice] >= @AV10cOrderDetailSuggestedPrice)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV11cOrderDetailCreatedDate) )
         {
            AddWhere(sWhereString, "([OrderDetailCreatedDate] >= @AV11cOrderDetailCreatedDate)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV12cOrderDetailModifiedDate) )
         {
            AddWhere(sWhereString, "([OrderDetailModifiedDate] >= @AV12cOrderDetailModifiedDate)");
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
                     return conditional_H000C2(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (decimal)dynConstraints[2] , (decimal)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (decimal)dynConstraints[8] , (decimal)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (int)dynConstraints[12] );
               case 1 :
                     return conditional_H000C3(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (decimal)dynConstraints[2] , (decimal)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (decimal)dynConstraints[8] , (decimal)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (int)dynConstraints[12] );
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
          Object[] prmH000C2;
          prmH000C2 = new Object[] {
          new ParDef("@AV6cOrderDetailId",GXType.Int32,6,0) ,
          new ParDef("@AV7cProductId",GXType.Int32,6,0) ,
          new ParDef("@AV8cOrderDetailQuantity",GXType.Int32,6,0) ,
          new ParDef("@AV9cOrderDetailCurrentPrice",GXType.Decimal,10,2) ,
          new ParDef("@AV10cOrderDetailSuggestedPrice",GXType.Decimal,10,2) ,
          new ParDef("@AV11cOrderDetailCreatedDate",GXType.Date,8,0) ,
          new ParDef("@AV12cOrderDetailModifiedDate",GXType.Date,8,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH000C3;
          prmH000C3 = new Object[] {
          new ParDef("@AV6cOrderDetailId",GXType.Int32,6,0) ,
          new ParDef("@AV7cProductId",GXType.Int32,6,0) ,
          new ParDef("@AV8cOrderDetailQuantity",GXType.Int32,6,0) ,
          new ParDef("@AV9cOrderDetailCurrentPrice",GXType.Decimal,10,2) ,
          new ParDef("@AV10cOrderDetailSuggestedPrice",GXType.Decimal,10,2) ,
          new ParDef("@AV11cOrderDetailCreatedDate",GXType.Date,8,0) ,
          new ParDef("@AV12cOrderDetailModifiedDate",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000C2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000C2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H000C3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000C3,1, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((int[]) buf[6])[0] = rslt.getInt(5);
                ((int[]) buf[7])[0] = rslt.getInt(6);
                ((int[]) buf[8])[0] = rslt.getInt(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
