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
   public class gx00c1 : GXDataArea
   {
      public gx00c1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public gx00c1( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_pPurchaseOrderId ,
                           out int aP1_pPurchaseOrderDetailId )
      {
         this.AV11pPurchaseOrderId = aP0_pPurchaseOrderId;
         this.AV12pPurchaseOrderDetailId = 0 ;
         executePrivate();
         aP1_pPurchaseOrderDetailId=this.AV12pPurchaseOrderDetailId;
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
            gxfirstwebparm = GetFirstPar( "pPurchaseOrderId");
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
               gxfirstwebparm = GetFirstPar( "pPurchaseOrderId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pPurchaseOrderId");
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
               AV11pPurchaseOrderId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11pPurchaseOrderId", StringUtil.LTrimStr( (decimal)(AV11pPurchaseOrderId), 6, 0));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV12pPurchaseOrderDetailId = (int)(Math.Round(NumberUtil.Val( GetPar( "pPurchaseOrderDetailId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV12pPurchaseOrderDetailId", StringUtil.LTrimStr( (decimal)(AV12pPurchaseOrderDetailId), 6, 0));
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
         AV6cPurchaseOrderDetailId = (int)(Math.Round(NumberUtil.Val( GetPar( "cPurchaseOrderDetailId"), "."), 18, MidpointRounding.ToEven));
         AV7cPurchaseOrderDetailQuantity = (short)(Math.Round(NumberUtil.Val( GetPar( "cPurchaseOrderDetailQuantity"), "."), 18, MidpointRounding.ToEven));
         AV8cProductId = (int)(Math.Round(NumberUtil.Val( GetPar( "cProductId"), "."), 18, MidpointRounding.ToEven));
         AV9cPurchaseOrderDetailCurrentPrice = NumberUtil.Val( GetPar( "cPurchaseOrderDetailCurrentPrice"), ".");
         AV10cPurchaseOrderDetailSuggestedPrice = NumberUtil.Val( GetPar( "cPurchaseOrderDetailSuggestedPrice"), ".");
         AV11pPurchaseOrderId = (int)(Math.Round(NumberUtil.Val( GetPar( "pPurchaseOrderId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cPurchaseOrderDetailId, AV7cPurchaseOrderDetailQuantity, AV8cProductId, AV9cPurchaseOrderDetailCurrentPrice, AV10cPurchaseOrderDetailSuggestedPrice, AV11pPurchaseOrderId) ;
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
         PA1J2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1J2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx00c1.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV11pPurchaseOrderId,6,0)),UrlEncode(StringUtil.LTrimStr(AV12pPurchaseOrderDetailId,6,0))}, new string[] {"pPurchaseOrderId","pPurchaseOrderDetailId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCPURCHASEORDERDETAILID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cPurchaseOrderDetailId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCPURCHASEORDERDETAILQUANTITY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cPurchaseOrderDetailQuantity), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCPRODUCTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cProductId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCPURCHASEORDERDETAILCURRENTPRICE", StringUtil.LTrim( StringUtil.NToC( AV9cPurchaseOrderDetailCurrentPrice, 10, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCPURCHASEORDERDETAILSUGGESTEDPRICE", StringUtil.LTrim( StringUtil.NToC( AV10cPurchaseOrderDetailSuggestedPrice, 10, 2, ".", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_64", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_64), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPPURCHASEORDERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11pPurchaseOrderId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPPURCHASEORDERDETAILID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12pPurchaseOrderDetailId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "PURCHASEORDERDETAILIDFILTERCONTAINER_Class", StringUtil.RTrim( divPurchaseorderdetailidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PURCHASEORDERDETAILQUANTITYFILTERCONTAINER_Class", StringUtil.RTrim( divPurchaseorderdetailquantityfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PRODUCTIDFILTERCONTAINER_Class", StringUtil.RTrim( divProductidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PURCHASEORDERDETAILCURRENTPRICEFILTERCONTAINER_Class", StringUtil.RTrim( divPurchaseorderdetailcurrentpricefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PURCHASEORDERDETAILSUGGESTEDPRICEFILTERCONTAINER_Class", StringUtil.RTrim( divPurchaseorderdetailsuggestedpricefiltercontainer_Class));
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
            WE1J2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1J2( ) ;
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
         return formatLink("gx00c1.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV11pPurchaseOrderId,6,0)),UrlEncode(StringUtil.LTrimStr(AV12pPurchaseOrderDetailId,6,0))}, new string[] {"pPurchaseOrderId","pPurchaseOrderDetailId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx00C1" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List Detail" ;
      }

      protected void WB1J0( )
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
            GxWebStd.gx_div_start( context, divPurchaseorderdetailidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divPurchaseorderdetailidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblpurchaseorderdetailidfilter_Internalname, "Purchase Order Detail Id", "", "", lblLblpurchaseorderdetailidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e111j1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00C1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCpurchaseorderdetailid_Internalname, "Purchase Order Detail Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCpurchaseorderdetailid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cPurchaseOrderDetailId), 6, 0, ".", "")), StringUtil.LTrim( ((edtavCpurchaseorderdetailid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cPurchaseOrderDetailId), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV6cPurchaseOrderDetailId), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpurchaseorderdetailid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCpurchaseorderdetailid_Visible, edtavCpurchaseorderdetailid_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00C1.htm");
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
            GxWebStd.gx_div_start( context, divPurchaseorderdetailquantityfiltercontainer_Internalname, 1, 0, "px", 0, "px", divPurchaseorderdetailquantityfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblpurchaseorderdetailquantityfilter_Internalname, "Purchase Order Detail Quantity", "", "", lblLblpurchaseorderdetailquantityfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e121j1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00C1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCpurchaseorderdetailquantity_Internalname, "Purchase Order Detail Quantity", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCpurchaseorderdetailquantity_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cPurchaseOrderDetailQuantity), 4, 0, ".", "")), StringUtil.LTrim( ((edtavCpurchaseorderdetailquantity_Enabled!=0) ? context.localUtil.Format( (decimal)(AV7cPurchaseOrderDetailQuantity), "ZZZ9") : context.localUtil.Format( (decimal)(AV7cPurchaseOrderDetailQuantity), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpurchaseorderdetailquantity_Jsonclick, 0, "Attribute", "", "", "", "", edtavCpurchaseorderdetailquantity_Visible, edtavCpurchaseorderdetailquantity_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00C1.htm");
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
            GxWebStd.gx_label_ctrl( context, lblLblproductidfilter_Internalname, "Product Id", "", "", lblLblproductidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e131j1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00C1.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavCproductid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8cProductId), 6, 0, ".", "")), StringUtil.LTrim( ((edtavCproductid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV8cProductId), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV8cProductId), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCproductid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCproductid_Visible, edtavCproductid_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00C1.htm");
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
            GxWebStd.gx_div_start( context, divPurchaseorderdetailcurrentpricefiltercontainer_Internalname, 1, 0, "px", 0, "px", divPurchaseorderdetailcurrentpricefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblpurchaseorderdetailcurrentpricefilter_Internalname, "Purchase Order Detail Current Price", "", "", lblLblpurchaseorderdetailcurrentpricefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e141j1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00C1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCpurchaseorderdetailcurrentprice_Internalname, "Purchase Order Detail Current Price", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCpurchaseorderdetailcurrentprice_Internalname, StringUtil.LTrim( StringUtil.NToC( AV9cPurchaseOrderDetailCurrentPrice, 10, 2, ".", "")), StringUtil.LTrim( ((edtavCpurchaseorderdetailcurrentprice_Enabled!=0) ? context.localUtil.Format( AV9cPurchaseOrderDetailCurrentPrice, "ZZZZZZ9.99") : context.localUtil.Format( AV9cPurchaseOrderDetailCurrentPrice, "ZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpurchaseorderdetailcurrentprice_Jsonclick, 0, "Attribute", "", "", "", "", edtavCpurchaseorderdetailcurrentprice_Visible, edtavCpurchaseorderdetailcurrentprice_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00C1.htm");
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
            GxWebStd.gx_div_start( context, divPurchaseorderdetailsuggestedpricefiltercontainer_Internalname, 1, 0, "px", 0, "px", divPurchaseorderdetailsuggestedpricefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblpurchaseorderdetailsuggestedpricefilter_Internalname, "Purchase Order Detail Suggested Price", "", "", lblLblpurchaseorderdetailsuggestedpricefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e151j1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00C1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCpurchaseorderdetailsuggestedprice_Internalname, "Purchase Order Detail Suggested Price", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_64_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCpurchaseorderdetailsuggestedprice_Internalname, StringUtil.LTrim( StringUtil.NToC( AV10cPurchaseOrderDetailSuggestedPrice, 10, 2, ".", "")), StringUtil.LTrim( ((edtavCpurchaseorderdetailsuggestedprice_Enabled!=0) ? context.localUtil.Format( AV10cPurchaseOrderDetailSuggestedPrice, "ZZZZZZ9.99") : context.localUtil.Format( AV10cPurchaseOrderDetailSuggestedPrice, "ZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpurchaseorderdetailsuggestedprice_Jsonclick, 0, "Attribute", "", "", "", "", edtavCpurchaseorderdetailsuggestedprice_Visible, edtavCpurchaseorderdetailsuggestedprice_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00C1.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(64), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e161j1_client"+"'", TempTags, "", 2, "HLP_Gx00C1.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(64), 2, 0)+","+"null"+");", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx00C1.htm");
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

      protected void START1J2( )
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
         STRUP1J0( ) ;
      }

      protected void WS1J2( )
      {
         START1J2( ) ;
         EVT1J2( ) ;
      }

      protected void EVT1J2( )
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
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV16Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_64_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A61PurchaseOrderDetailId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPurchaseOrderDetailId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A62PurchaseOrderDetailQuantity = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPurchaseOrderDetailQuantity_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A15ProductId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtProductId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A63PurchaseOrderDetailCurrentPric = context.localUtil.CToN( cgiGet( edtPurchaseOrderDetailCurrentPric_Internalname), ".", ",");
                              A50PurchaseOrderId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPurchaseOrderId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E171J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E181J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cpurchaseorderdetailid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPURCHASEORDERDETAILID"), ".", ",") != Convert.ToDecimal( AV6cPurchaseOrderDetailId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cpurchaseorderdetailquantity Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPURCHASEORDERDETAILQUANTITY"), ".", ",") != Convert.ToDecimal( AV7cPurchaseOrderDetailQuantity )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cproductid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPRODUCTID"), ".", ",") != Convert.ToDecimal( AV8cProductId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cpurchaseorderdetailcurrentprice Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCPURCHASEORDERDETAILCURRENTPRICE"), ".", ",") != AV9cPurchaseOrderDetailCurrentPrice )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cpurchaseorderdetailsuggestedprice Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCPURCHASEORDERDETAILSUGGESTEDPRICE"), ".", ",") != AV10cPurchaseOrderDetailSuggestedPrice )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E191J2 ();
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

      protected void WE1J2( )
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

      protected void PA1J2( )
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
                                        int AV6cPurchaseOrderDetailId ,
                                        short AV7cPurchaseOrderDetailQuantity ,
                                        int AV8cProductId ,
                                        decimal AV9cPurchaseOrderDetailCurrentPrice ,
                                        decimal AV10cPurchaseOrderDetailSuggestedPrice ,
                                        int AV11pPurchaseOrderId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF1J2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PURCHASEORDERDETAILID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A61PurchaseOrderDetailId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "PURCHASEORDERDETAILID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A61PurchaseOrderDetailId), 6, 0, ".", "")));
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
         RF1J2( ) ;
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

      protected void RF1J2( )
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
                                                 AV7cPurchaseOrderDetailQuantity ,
                                                 AV8cProductId ,
                                                 AV9cPurchaseOrderDetailCurrentPrice ,
                                                 AV10cPurchaseOrderDetailSuggestedPrice ,
                                                 A62PurchaseOrderDetailQuantity ,
                                                 A15ProductId ,
                                                 A63PurchaseOrderDetailCurrentPric ,
                                                 A64PurchaseOrderDetailSuggestedPr ,
                                                 AV11pPurchaseOrderId ,
                                                 AV6cPurchaseOrderDetailId ,
                                                 A50PurchaseOrderId } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.INT,
                                                 TypeConstants.INT
                                                 }
            });
            /* Using cursor H001J2 */
            pr_default.execute(0, new Object[] {AV11pPurchaseOrderId, AV6cPurchaseOrderDetailId, AV7cPurchaseOrderDetailQuantity, AV8cProductId, AV9cPurchaseOrderDetailCurrentPrice, AV10cPurchaseOrderDetailSuggestedPrice, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_64_idx = 1;
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_642( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A64PurchaseOrderDetailSuggestedPr = H001J2_A64PurchaseOrderDetailSuggestedPr[0];
               A50PurchaseOrderId = H001J2_A50PurchaseOrderId[0];
               A63PurchaseOrderDetailCurrentPric = H001J2_A63PurchaseOrderDetailCurrentPric[0];
               A15ProductId = H001J2_A15ProductId[0];
               A62PurchaseOrderDetailQuantity = H001J2_A62PurchaseOrderDetailQuantity[0];
               A61PurchaseOrderDetailId = H001J2_A61PurchaseOrderDetailId[0];
               /* Execute user event: Load */
               E181J2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 64;
            WB1J0( ) ;
         }
         bGXsfl_64_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes1J2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PURCHASEORDERDETAILID"+"_"+sGXsfl_64_idx, GetSecureSignedToken( sGXsfl_64_idx, context.localUtil.Format( (decimal)(A61PurchaseOrderDetailId), "ZZZZZ9"), context));
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
                                              AV7cPurchaseOrderDetailQuantity ,
                                              AV8cProductId ,
                                              AV9cPurchaseOrderDetailCurrentPrice ,
                                              AV10cPurchaseOrderDetailSuggestedPrice ,
                                              A62PurchaseOrderDetailQuantity ,
                                              A15ProductId ,
                                              A63PurchaseOrderDetailCurrentPric ,
                                              A64PurchaseOrderDetailSuggestedPr ,
                                              AV11pPurchaseOrderId ,
                                              AV6cPurchaseOrderDetailId ,
                                              A50PurchaseOrderId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.INT
                                              }
         });
         /* Using cursor H001J3 */
         pr_default.execute(1, new Object[] {AV11pPurchaseOrderId, AV6cPurchaseOrderDetailId, AV7cPurchaseOrderDetailQuantity, AV8cProductId, AV9cPurchaseOrderDetailCurrentPrice, AV10cPurchaseOrderDetailSuggestedPrice});
         GRID1_nRecordCount = H001J3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cPurchaseOrderDetailId, AV7cPurchaseOrderDetailQuantity, AV8cProductId, AV9cPurchaseOrderDetailCurrentPrice, AV10cPurchaseOrderDetailSuggestedPrice, AV11pPurchaseOrderId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cPurchaseOrderDetailId, AV7cPurchaseOrderDetailQuantity, AV8cProductId, AV9cPurchaseOrderDetailCurrentPrice, AV10cPurchaseOrderDetailSuggestedPrice, AV11pPurchaseOrderId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cPurchaseOrderDetailId, AV7cPurchaseOrderDetailQuantity, AV8cProductId, AV9cPurchaseOrderDetailCurrentPrice, AV10cPurchaseOrderDetailSuggestedPrice, AV11pPurchaseOrderId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cPurchaseOrderDetailId, AV7cPurchaseOrderDetailQuantity, AV8cProductId, AV9cPurchaseOrderDetailCurrentPrice, AV10cPurchaseOrderDetailSuggestedPrice, AV11pPurchaseOrderId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cPurchaseOrderDetailId, AV7cPurchaseOrderDetailQuantity, AV8cProductId, AV9cPurchaseOrderDetailCurrentPrice, AV10cPurchaseOrderDetailSuggestedPrice, AV11pPurchaseOrderId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP1J0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E171J2 ();
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCpurchaseorderdetailid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCpurchaseorderdetailid_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCPURCHASEORDERDETAILID");
               GX_FocusControl = edtavCpurchaseorderdetailid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cPurchaseOrderDetailId = 0;
               AssignAttri("", false, "AV6cPurchaseOrderDetailId", StringUtil.LTrimStr( (decimal)(AV6cPurchaseOrderDetailId), 6, 0));
            }
            else
            {
               AV6cPurchaseOrderDetailId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCpurchaseorderdetailid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cPurchaseOrderDetailId", StringUtil.LTrimStr( (decimal)(AV6cPurchaseOrderDetailId), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCpurchaseorderdetailquantity_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCpurchaseorderdetailquantity_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCPURCHASEORDERDETAILQUANTITY");
               GX_FocusControl = edtavCpurchaseorderdetailquantity_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cPurchaseOrderDetailQuantity = 0;
               AssignAttri("", false, "AV7cPurchaseOrderDetailQuantity", StringUtil.LTrimStr( (decimal)(AV7cPurchaseOrderDetailQuantity), 4, 0));
            }
            else
            {
               AV7cPurchaseOrderDetailQuantity = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCpurchaseorderdetailquantity_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7cPurchaseOrderDetailQuantity", StringUtil.LTrimStr( (decimal)(AV7cPurchaseOrderDetailQuantity), 4, 0));
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCpurchaseorderdetailcurrentprice_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCpurchaseorderdetailcurrentprice_Internalname), ".", ",") > 9999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCPURCHASEORDERDETAILCURRENTPRICE");
               GX_FocusControl = edtavCpurchaseorderdetailcurrentprice_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9cPurchaseOrderDetailCurrentPrice = 0;
               AssignAttri("", false, "AV9cPurchaseOrderDetailCurrentPrice", StringUtil.LTrimStr( AV9cPurchaseOrderDetailCurrentPrice, 10, 2));
            }
            else
            {
               AV9cPurchaseOrderDetailCurrentPrice = context.localUtil.CToN( cgiGet( edtavCpurchaseorderdetailcurrentprice_Internalname), ".", ",");
               AssignAttri("", false, "AV9cPurchaseOrderDetailCurrentPrice", StringUtil.LTrimStr( AV9cPurchaseOrderDetailCurrentPrice, 10, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCpurchaseorderdetailsuggestedprice_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCpurchaseorderdetailsuggestedprice_Internalname), ".", ",") > 9999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCPURCHASEORDERDETAILSUGGESTEDPRICE");
               GX_FocusControl = edtavCpurchaseorderdetailsuggestedprice_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cPurchaseOrderDetailSuggestedPrice = 0;
               AssignAttri("", false, "AV10cPurchaseOrderDetailSuggestedPrice", StringUtil.LTrimStr( AV10cPurchaseOrderDetailSuggestedPrice, 10, 2));
            }
            else
            {
               AV10cPurchaseOrderDetailSuggestedPrice = context.localUtil.CToN( cgiGet( edtavCpurchaseorderdetailsuggestedprice_Internalname), ".", ",");
               AssignAttri("", false, "AV10cPurchaseOrderDetailSuggestedPrice", StringUtil.LTrimStr( AV10cPurchaseOrderDetailSuggestedPrice, 10, 2));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPURCHASEORDERDETAILID"), ".", ",") != Convert.ToDecimal( AV6cPurchaseOrderDetailId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPURCHASEORDERDETAILQUANTITY"), ".", ",") != Convert.ToDecimal( AV7cPurchaseOrderDetailQuantity )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPRODUCTID"), ".", ",") != Convert.ToDecimal( AV8cProductId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCPURCHASEORDERDETAILCURRENTPRICE"), ".", ",") != AV9cPurchaseOrderDetailCurrentPrice )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCPURCHASEORDERDETAILSUGGESTEDPRICE"), ".", ",") != AV10cPurchaseOrderDetailSuggestedPrice )
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
         E171J2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E171J2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Selection List %1", "Detail", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV13ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E181J2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "selectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV16Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )));
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
         E191J2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E191J2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV12pPurchaseOrderDetailId = A61PurchaseOrderDetailId;
         AssignAttri("", false, "AV12pPurchaseOrderDetailId", StringUtil.LTrimStr( (decimal)(AV12pPurchaseOrderDetailId), 6, 0));
         context.setWebReturnParms(new Object[] {(int)AV12pPurchaseOrderDetailId});
         context.setWebReturnParmsMetadata(new Object[] {"AV12pPurchaseOrderDetailId"});
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
         AV11pPurchaseOrderId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV11pPurchaseOrderId", StringUtil.LTrimStr( (decimal)(AV11pPurchaseOrderId), 6, 0));
         AV12pPurchaseOrderDetailId = Convert.ToInt32(getParm(obj,1));
         AssignAttri("", false, "AV12pPurchaseOrderDetailId", StringUtil.LTrimStr( (decimal)(AV12pPurchaseOrderDetailId), 6, 0));
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
         PA1J2( ) ;
         WS1J2( ) ;
         WE1J2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202311222274942", true, true);
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
         context.AddJavascriptSource("gx00c1.js", "?202311222274942", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_642( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_64_idx;
         edtPurchaseOrderDetailId_Internalname = "PURCHASEORDERDETAILID_"+sGXsfl_64_idx;
         edtPurchaseOrderDetailQuantity_Internalname = "PURCHASEORDERDETAILQUANTITY_"+sGXsfl_64_idx;
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_64_idx;
         edtPurchaseOrderDetailCurrentPric_Internalname = "PURCHASEORDERDETAILCURRENTPRIC_"+sGXsfl_64_idx;
         edtPurchaseOrderId_Internalname = "PURCHASEORDERID_"+sGXsfl_64_idx;
      }

      protected void SubsflControlProps_fel_642( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_64_fel_idx;
         edtPurchaseOrderDetailId_Internalname = "PURCHASEORDERDETAILID_"+sGXsfl_64_fel_idx;
         edtPurchaseOrderDetailQuantity_Internalname = "PURCHASEORDERDETAILQUANTITY_"+sGXsfl_64_fel_idx;
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_64_fel_idx;
         edtPurchaseOrderDetailCurrentPric_Internalname = "PURCHASEORDERDETAILCURRENTPRIC_"+sGXsfl_64_fel_idx;
         edtPurchaseOrderId_Internalname = "PURCHASEORDERID_"+sGXsfl_64_fel_idx;
      }

      protected void sendrow_642( )
      {
         SubsflControlProps_642( ) ;
         WB1J0( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A61PurchaseOrderDetailId), 6, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_64_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV16Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV16Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPurchaseOrderDetailId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A61PurchaseOrderDetailId), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A61PurchaseOrderDetailId), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPurchaseOrderDetailId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtPurchaseOrderDetailQuantity_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A61PurchaseOrderDetailId), 6, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtPurchaseOrderDetailQuantity_Internalname, "Link", edtPurchaseOrderDetailQuantity_Link, !bGXsfl_64_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPurchaseOrderDetailQuantity_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A62PurchaseOrderDetailQuantity), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A62PurchaseOrderDetailQuantity), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtPurchaseOrderDetailQuantity_Link,(string)"",(string)"",(string)"",(string)edtPurchaseOrderDetailQuantity_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
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
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPurchaseOrderDetailCurrentPric_Internalname,StringUtil.LTrim( StringUtil.NToC( A63PurchaseOrderDetailCurrentPric, 10, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A63PurchaseOrderDetailCurrentPric, "ZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPurchaseOrderDetailCurrentPric_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)0,(bool)true,(string)"Price",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPurchaseOrderId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A50PurchaseOrderId), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A50PurchaseOrderId), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPurchaseOrderId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes1J2( ) ;
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
            context.SendWebValue( "Detail Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Detail Quantity") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Product Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Current Price") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Purchase Order Id") ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A61PurchaseOrderDetailId), 6, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A62PurchaseOrderDetailQuantity), 4, 0, ".", ""))));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtPurchaseOrderDetailQuantity_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A63PurchaseOrderDetailCurrentPric, 10, 2, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A50PurchaseOrderId), 6, 0, ".", ""))));
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
         lblLblpurchaseorderdetailidfilter_Internalname = "LBLPURCHASEORDERDETAILIDFILTER";
         edtavCpurchaseorderdetailid_Internalname = "vCPURCHASEORDERDETAILID";
         divPurchaseorderdetailidfiltercontainer_Internalname = "PURCHASEORDERDETAILIDFILTERCONTAINER";
         lblLblpurchaseorderdetailquantityfilter_Internalname = "LBLPURCHASEORDERDETAILQUANTITYFILTER";
         edtavCpurchaseorderdetailquantity_Internalname = "vCPURCHASEORDERDETAILQUANTITY";
         divPurchaseorderdetailquantityfiltercontainer_Internalname = "PURCHASEORDERDETAILQUANTITYFILTERCONTAINER";
         lblLblproductidfilter_Internalname = "LBLPRODUCTIDFILTER";
         edtavCproductid_Internalname = "vCPRODUCTID";
         divProductidfiltercontainer_Internalname = "PRODUCTIDFILTERCONTAINER";
         lblLblpurchaseorderdetailcurrentpricefilter_Internalname = "LBLPURCHASEORDERDETAILCURRENTPRICEFILTER";
         edtavCpurchaseorderdetailcurrentprice_Internalname = "vCPURCHASEORDERDETAILCURRENTPRICE";
         divPurchaseorderdetailcurrentpricefiltercontainer_Internalname = "PURCHASEORDERDETAILCURRENTPRICEFILTERCONTAINER";
         lblLblpurchaseorderdetailsuggestedpricefilter_Internalname = "LBLPURCHASEORDERDETAILSUGGESTEDPRICEFILTER";
         edtavCpurchaseorderdetailsuggestedprice_Internalname = "vCPURCHASEORDERDETAILSUGGESTEDPRICE";
         divPurchaseorderdetailsuggestedpricefiltercontainer_Internalname = "PURCHASEORDERDETAILSUGGESTEDPRICEFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtPurchaseOrderDetailId_Internalname = "PURCHASEORDERDETAILID";
         edtPurchaseOrderDetailQuantity_Internalname = "PURCHASEORDERDETAILQUANTITY";
         edtProductId_Internalname = "PRODUCTID";
         edtPurchaseOrderDetailCurrentPric_Internalname = "PURCHASEORDERDETAILCURRENTPRIC";
         edtPurchaseOrderId_Internalname = "PURCHASEORDERID";
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
         edtPurchaseOrderId_Jsonclick = "";
         edtPurchaseOrderDetailCurrentPric_Jsonclick = "";
         edtProductId_Jsonclick = "";
         edtPurchaseOrderDetailQuantity_Jsonclick = "";
         edtPurchaseOrderDetailQuantity_Link = "";
         edtPurchaseOrderDetailId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCpurchaseorderdetailsuggestedprice_Jsonclick = "";
         edtavCpurchaseorderdetailsuggestedprice_Enabled = 1;
         edtavCpurchaseorderdetailsuggestedprice_Visible = 1;
         edtavCpurchaseorderdetailcurrentprice_Jsonclick = "";
         edtavCpurchaseorderdetailcurrentprice_Enabled = 1;
         edtavCpurchaseorderdetailcurrentprice_Visible = 1;
         edtavCproductid_Jsonclick = "";
         edtavCproductid_Enabled = 1;
         edtavCproductid_Visible = 1;
         edtavCpurchaseorderdetailquantity_Jsonclick = "";
         edtavCpurchaseorderdetailquantity_Enabled = 1;
         edtavCpurchaseorderdetailquantity_Visible = 1;
         edtavCpurchaseorderdetailid_Jsonclick = "";
         edtavCpurchaseorderdetailid_Enabled = 1;
         edtavCpurchaseorderdetailid_Visible = 1;
         divPurchaseorderdetailsuggestedpricefiltercontainer_Class = "AdvancedContainerItem";
         divPurchaseorderdetailcurrentpricefiltercontainer_Class = "AdvancedContainerItem";
         divProductidfiltercontainer_Class = "AdvancedContainerItem";
         divPurchaseorderdetailquantityfiltercontainer_Class = "AdvancedContainerItem";
         divPurchaseorderdetailidfiltercontainer_Class = "AdvancedContainerItem";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cPurchaseOrderDetailId',fld:'vCPURCHASEORDERDETAILID',pic:'ZZZZZ9'},{av:'AV7cPurchaseOrderDetailQuantity',fld:'vCPURCHASEORDERDETAILQUANTITY',pic:'ZZZ9'},{av:'AV8cProductId',fld:'vCPRODUCTID',pic:'ZZZZZ9'},{av:'AV9cPurchaseOrderDetailCurrentPrice',fld:'vCPURCHASEORDERDETAILCURRENTPRICE',pic:'ZZZZZZ9.99'},{av:'AV10cPurchaseOrderDetailSuggestedPrice',fld:'vCPURCHASEORDERDETAILSUGGESTEDPRICE',pic:'ZZZZZZ9.99'},{av:'AV11pPurchaseOrderId',fld:'vPPURCHASEORDERID',pic:'ZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E161J1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLPURCHASEORDERDETAILIDFILTER.CLICK","{handler:'E111J1',iparms:[{av:'divPurchaseorderdetailidfiltercontainer_Class',ctrl:'PURCHASEORDERDETAILIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPURCHASEORDERDETAILIDFILTER.CLICK",",oparms:[{av:'divPurchaseorderdetailidfiltercontainer_Class',ctrl:'PURCHASEORDERDETAILIDFILTERCONTAINER',prop:'Class'},{av:'edtavCpurchaseorderdetailid_Visible',ctrl:'vCPURCHASEORDERDETAILID',prop:'Visible'}]}");
         setEventMetadata("LBLPURCHASEORDERDETAILQUANTITYFILTER.CLICK","{handler:'E121J1',iparms:[{av:'divPurchaseorderdetailquantityfiltercontainer_Class',ctrl:'PURCHASEORDERDETAILQUANTITYFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPURCHASEORDERDETAILQUANTITYFILTER.CLICK",",oparms:[{av:'divPurchaseorderdetailquantityfiltercontainer_Class',ctrl:'PURCHASEORDERDETAILQUANTITYFILTERCONTAINER',prop:'Class'},{av:'edtavCpurchaseorderdetailquantity_Visible',ctrl:'vCPURCHASEORDERDETAILQUANTITY',prop:'Visible'}]}");
         setEventMetadata("LBLPRODUCTIDFILTER.CLICK","{handler:'E131J1',iparms:[{av:'divProductidfiltercontainer_Class',ctrl:'PRODUCTIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPRODUCTIDFILTER.CLICK",",oparms:[{av:'divProductidfiltercontainer_Class',ctrl:'PRODUCTIDFILTERCONTAINER',prop:'Class'},{av:'edtavCproductid_Visible',ctrl:'vCPRODUCTID',prop:'Visible'}]}");
         setEventMetadata("LBLPURCHASEORDERDETAILCURRENTPRICEFILTER.CLICK","{handler:'E141J1',iparms:[{av:'divPurchaseorderdetailcurrentpricefiltercontainer_Class',ctrl:'PURCHASEORDERDETAILCURRENTPRICEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPURCHASEORDERDETAILCURRENTPRICEFILTER.CLICK",",oparms:[{av:'divPurchaseorderdetailcurrentpricefiltercontainer_Class',ctrl:'PURCHASEORDERDETAILCURRENTPRICEFILTERCONTAINER',prop:'Class'},{av:'edtavCpurchaseorderdetailcurrentprice_Visible',ctrl:'vCPURCHASEORDERDETAILCURRENTPRICE',prop:'Visible'}]}");
         setEventMetadata("LBLPURCHASEORDERDETAILSUGGESTEDPRICEFILTER.CLICK","{handler:'E151J1',iparms:[{av:'divPurchaseorderdetailsuggestedpricefiltercontainer_Class',ctrl:'PURCHASEORDERDETAILSUGGESTEDPRICEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPURCHASEORDERDETAILSUGGESTEDPRICEFILTER.CLICK",",oparms:[{av:'divPurchaseorderdetailsuggestedpricefiltercontainer_Class',ctrl:'PURCHASEORDERDETAILSUGGESTEDPRICEFILTERCONTAINER',prop:'Class'},{av:'edtavCpurchaseorderdetailsuggestedprice_Visible',ctrl:'vCPURCHASEORDERDETAILSUGGESTEDPRICE',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E191J2',iparms:[{av:'A61PurchaseOrderDetailId',fld:'PURCHASEORDERDETAILID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV12pPurchaseOrderDetailId',fld:'vPPURCHASEORDERDETAILID',pic:'ZZZZZ9'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cPurchaseOrderDetailId',fld:'vCPURCHASEORDERDETAILID',pic:'ZZZZZ9'},{av:'AV7cPurchaseOrderDetailQuantity',fld:'vCPURCHASEORDERDETAILQUANTITY',pic:'ZZZ9'},{av:'AV8cProductId',fld:'vCPRODUCTID',pic:'ZZZZZ9'},{av:'AV9cPurchaseOrderDetailCurrentPrice',fld:'vCPURCHASEORDERDETAILCURRENTPRICE',pic:'ZZZZZZ9.99'},{av:'AV10cPurchaseOrderDetailSuggestedPrice',fld:'vCPURCHASEORDERDETAILSUGGESTEDPRICE',pic:'ZZZZZZ9.99'},{av:'AV11pPurchaseOrderId',fld:'vPPURCHASEORDERID',pic:'ZZZZZ9'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cPurchaseOrderDetailId',fld:'vCPURCHASEORDERDETAILID',pic:'ZZZZZ9'},{av:'AV7cPurchaseOrderDetailQuantity',fld:'vCPURCHASEORDERDETAILQUANTITY',pic:'ZZZ9'},{av:'AV8cProductId',fld:'vCPRODUCTID',pic:'ZZZZZ9'},{av:'AV9cPurchaseOrderDetailCurrentPrice',fld:'vCPURCHASEORDERDETAILCURRENTPRICE',pic:'ZZZZZZ9.99'},{av:'AV10cPurchaseOrderDetailSuggestedPrice',fld:'vCPURCHASEORDERDETAILSUGGESTEDPRICE',pic:'ZZZZZZ9.99'},{av:'AV11pPurchaseOrderId',fld:'vPPURCHASEORDERID',pic:'ZZZZZ9'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cPurchaseOrderDetailId',fld:'vCPURCHASEORDERDETAILID',pic:'ZZZZZ9'},{av:'AV7cPurchaseOrderDetailQuantity',fld:'vCPURCHASEORDERDETAILQUANTITY',pic:'ZZZ9'},{av:'AV8cProductId',fld:'vCPRODUCTID',pic:'ZZZZZ9'},{av:'AV9cPurchaseOrderDetailCurrentPrice',fld:'vCPURCHASEORDERDETAILCURRENTPRICE',pic:'ZZZZZZ9.99'},{av:'AV10cPurchaseOrderDetailSuggestedPrice',fld:'vCPURCHASEORDERDETAILSUGGESTEDPRICE',pic:'ZZZZZZ9.99'},{av:'AV11pPurchaseOrderId',fld:'vPPURCHASEORDERID',pic:'ZZZZZ9'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cPurchaseOrderDetailId',fld:'vCPURCHASEORDERDETAILID',pic:'ZZZZZ9'},{av:'AV7cPurchaseOrderDetailQuantity',fld:'vCPURCHASEORDERDETAILQUANTITY',pic:'ZZZ9'},{av:'AV8cProductId',fld:'vCPRODUCTID',pic:'ZZZZZ9'},{av:'AV9cPurchaseOrderDetailCurrentPrice',fld:'vCPURCHASEORDERDETAILCURRENTPRICE',pic:'ZZZZZZ9.99'},{av:'AV10cPurchaseOrderDetailSuggestedPrice',fld:'vCPURCHASEORDERDETAILSUGGESTEDPRICE',pic:'ZZZZZZ9.99'},{av:'AV11pPurchaseOrderId',fld:'vPPURCHASEORDERID',pic:'ZZZZZ9'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Purchaseorderid',iparms:[]");
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
         lblLblpurchaseorderdetailidfilter_Jsonclick = "";
         TempTags = "";
         lblLblpurchaseorderdetailquantityfilter_Jsonclick = "";
         lblLblproductidfilter_Jsonclick = "";
         lblLblpurchaseorderdetailcurrentpricefilter_Jsonclick = "";
         lblLblpurchaseorderdetailsuggestedpricefilter_Jsonclick = "";
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
         AV16Linkselection_GXI = "";
         scmdbuf = "";
         H001J2_A64PurchaseOrderDetailSuggestedPr = new decimal[1] ;
         H001J2_A50PurchaseOrderId = new int[1] ;
         H001J2_A63PurchaseOrderDetailCurrentPric = new decimal[1] ;
         H001J2_A15ProductId = new int[1] ;
         H001J2_A62PurchaseOrderDetailQuantity = new short[1] ;
         H001J2_A61PurchaseOrderDetailId = new int[1] ;
         H001J3_AGRID1_nRecordCount = new long[1] ;
         AV13ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx00c1__default(),
            new Object[][] {
                new Object[] {
               H001J2_A64PurchaseOrderDetailSuggestedPr, H001J2_A50PurchaseOrderId, H001J2_A63PurchaseOrderDetailCurrentPric, H001J2_A15ProductId, H001J2_A62PurchaseOrderDetailQuantity, H001J2_A61PurchaseOrderDetailId
               }
               , new Object[] {
               H001J3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV7cPurchaseOrderDetailQuantity ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A62PurchaseOrderDetailQuantity ;
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
      private int AV11pPurchaseOrderId ;
      private int AV12pPurchaseOrderDetailId ;
      private int wcpOAV11pPurchaseOrderId ;
      private int nRC_GXsfl_64 ;
      private int subGrid1_Rows ;
      private int nGXsfl_64_idx=1 ;
      private int AV6cPurchaseOrderDetailId ;
      private int AV8cProductId ;
      private int edtavCpurchaseorderdetailid_Enabled ;
      private int edtavCpurchaseorderdetailid_Visible ;
      private int edtavCpurchaseorderdetailquantity_Enabled ;
      private int edtavCpurchaseorderdetailquantity_Visible ;
      private int edtavCproductid_Enabled ;
      private int edtavCproductid_Visible ;
      private int edtavCpurchaseorderdetailcurrentprice_Enabled ;
      private int edtavCpurchaseorderdetailcurrentprice_Visible ;
      private int edtavCpurchaseorderdetailsuggestedprice_Enabled ;
      private int edtavCpurchaseorderdetailsuggestedprice_Visible ;
      private int A61PurchaseOrderDetailId ;
      private int A15ProductId ;
      private int A50PurchaseOrderId ;
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
      private decimal AV9cPurchaseOrderDetailCurrentPrice ;
      private decimal AV10cPurchaseOrderDetailSuggestedPrice ;
      private decimal A63PurchaseOrderDetailCurrentPric ;
      private decimal A64PurchaseOrderDetailSuggestedPr ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divPurchaseorderdetailidfiltercontainer_Class ;
      private string divPurchaseorderdetailquantityfiltercontainer_Class ;
      private string divProductidfiltercontainer_Class ;
      private string divPurchaseorderdetailcurrentpricefiltercontainer_Class ;
      private string divPurchaseorderdetailsuggestedpricefiltercontainer_Class ;
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
      private string divPurchaseorderdetailidfiltercontainer_Internalname ;
      private string lblLblpurchaseorderdetailidfilter_Internalname ;
      private string lblLblpurchaseorderdetailidfilter_Jsonclick ;
      private string edtavCpurchaseorderdetailid_Internalname ;
      private string TempTags ;
      private string edtavCpurchaseorderdetailid_Jsonclick ;
      private string divPurchaseorderdetailquantityfiltercontainer_Internalname ;
      private string lblLblpurchaseorderdetailquantityfilter_Internalname ;
      private string lblLblpurchaseorderdetailquantityfilter_Jsonclick ;
      private string edtavCpurchaseorderdetailquantity_Internalname ;
      private string edtavCpurchaseorderdetailquantity_Jsonclick ;
      private string divProductidfiltercontainer_Internalname ;
      private string lblLblproductidfilter_Internalname ;
      private string lblLblproductidfilter_Jsonclick ;
      private string edtavCproductid_Internalname ;
      private string edtavCproductid_Jsonclick ;
      private string divPurchaseorderdetailcurrentpricefiltercontainer_Internalname ;
      private string lblLblpurchaseorderdetailcurrentpricefilter_Internalname ;
      private string lblLblpurchaseorderdetailcurrentpricefilter_Jsonclick ;
      private string edtavCpurchaseorderdetailcurrentprice_Internalname ;
      private string edtavCpurchaseorderdetailcurrentprice_Jsonclick ;
      private string divPurchaseorderdetailsuggestedpricefiltercontainer_Internalname ;
      private string lblLblpurchaseorderdetailsuggestedpricefilter_Internalname ;
      private string lblLblpurchaseorderdetailsuggestedpricefilter_Jsonclick ;
      private string edtavCpurchaseorderdetailsuggestedprice_Internalname ;
      private string edtavCpurchaseorderdetailsuggestedprice_Jsonclick ;
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
      private string edtPurchaseOrderDetailId_Internalname ;
      private string edtPurchaseOrderDetailQuantity_Internalname ;
      private string edtProductId_Internalname ;
      private string edtPurchaseOrderDetailCurrentPric_Internalname ;
      private string edtPurchaseOrderId_Internalname ;
      private string scmdbuf ;
      private string AV13ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_64_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtPurchaseOrderDetailId_Jsonclick ;
      private string edtPurchaseOrderDetailQuantity_Link ;
      private string edtPurchaseOrderDetailQuantity_Jsonclick ;
      private string edtProductId_Jsonclick ;
      private string edtPurchaseOrderDetailCurrentPric_Jsonclick ;
      private string edtPurchaseOrderId_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_64_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV16Linkselection_GXI ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private decimal[] H001J2_A64PurchaseOrderDetailSuggestedPr ;
      private int[] H001J2_A50PurchaseOrderId ;
      private decimal[] H001J2_A63PurchaseOrderDetailCurrentPric ;
      private int[] H001J2_A15ProductId ;
      private short[] H001J2_A62PurchaseOrderDetailQuantity ;
      private int[] H001J2_A61PurchaseOrderDetailId ;
      private long[] H001J3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private int aP1_pPurchaseOrderDetailId ;
      private GXWebForm Form ;
   }

   public class gx00c1__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H001J2( IGxContext context ,
                                             short AV7cPurchaseOrderDetailQuantity ,
                                             int AV8cProductId ,
                                             decimal AV9cPurchaseOrderDetailCurrentPrice ,
                                             decimal AV10cPurchaseOrderDetailSuggestedPrice ,
                                             short A62PurchaseOrderDetailQuantity ,
                                             int A15ProductId ,
                                             decimal A63PurchaseOrderDetailCurrentPric ,
                                             decimal A64PurchaseOrderDetailSuggestedPr ,
                                             int AV11pPurchaseOrderId ,
                                             int AV6cPurchaseOrderDetailId ,
                                             int A50PurchaseOrderId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[9];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [PurchaseOrderDetailSuggestedPr], [PurchaseOrderId], [PurchaseOrderDetailCurrentPric], [ProductId], [PurchaseOrderDetailQuantity], [PurchaseOrderDetailId]";
         sFromString = " FROM [PurchaseOrderDetail]";
         sOrderString = "";
         AddWhere(sWhereString, "([PurchaseOrderId] = @AV11pPurchaseOrderId and [PurchaseOrderDetailId] >= @AV6cPurchaseOrderDetailId)");
         if ( ! (0==AV7cPurchaseOrderDetailQuantity) )
         {
            AddWhere(sWhereString, "([PurchaseOrderDetailQuantity] >= @AV7cPurchaseOrderDetailQuantity)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV8cProductId) )
         {
            AddWhere(sWhereString, "([ProductId] >= @AV8cProductId)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV9cPurchaseOrderDetailCurrentPrice) )
         {
            AddWhere(sWhereString, "([PurchaseOrderDetailCurrentPric] >= @AV9cPurchaseOrderDetailCurrentPrice)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV10cPurchaseOrderDetailSuggestedPrice) )
         {
            AddWhere(sWhereString, "([PurchaseOrderDetailSuggestedPr] >= @AV10cPurchaseOrderDetailSuggestedPrice)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         sOrderString += " ORDER BY [PurchaseOrderId], [PurchaseOrderDetailId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H001J3( IGxContext context ,
                                             short AV7cPurchaseOrderDetailQuantity ,
                                             int AV8cProductId ,
                                             decimal AV9cPurchaseOrderDetailCurrentPrice ,
                                             decimal AV10cPurchaseOrderDetailSuggestedPrice ,
                                             short A62PurchaseOrderDetailQuantity ,
                                             int A15ProductId ,
                                             decimal A63PurchaseOrderDetailCurrentPric ,
                                             decimal A64PurchaseOrderDetailSuggestedPr ,
                                             int AV11pPurchaseOrderId ,
                                             int AV6cPurchaseOrderDetailId ,
                                             int A50PurchaseOrderId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [PurchaseOrderDetail]";
         AddWhere(sWhereString, "([PurchaseOrderId] = @AV11pPurchaseOrderId and [PurchaseOrderDetailId] >= @AV6cPurchaseOrderDetailId)");
         if ( ! (0==AV7cPurchaseOrderDetailQuantity) )
         {
            AddWhere(sWhereString, "([PurchaseOrderDetailQuantity] >= @AV7cPurchaseOrderDetailQuantity)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV8cProductId) )
         {
            AddWhere(sWhereString, "([ProductId] >= @AV8cProductId)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV9cPurchaseOrderDetailCurrentPrice) )
         {
            AddWhere(sWhereString, "([PurchaseOrderDetailCurrentPric] >= @AV9cPurchaseOrderDetailCurrentPrice)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV10cPurchaseOrderDetailSuggestedPrice) )
         {
            AddWhere(sWhereString, "([PurchaseOrderDetailSuggestedPr] >= @AV10cPurchaseOrderDetailSuggestedPrice)");
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
                     return conditional_H001J2(context, (short)dynConstraints[0] , (int)dynConstraints[1] , (decimal)dynConstraints[2] , (decimal)dynConstraints[3] , (short)dynConstraints[4] , (int)dynConstraints[5] , (decimal)dynConstraints[6] , (decimal)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] );
               case 1 :
                     return conditional_H001J3(context, (short)dynConstraints[0] , (int)dynConstraints[1] , (decimal)dynConstraints[2] , (decimal)dynConstraints[3] , (short)dynConstraints[4] , (int)dynConstraints[5] , (decimal)dynConstraints[6] , (decimal)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] );
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
          Object[] prmH001J2;
          prmH001J2 = new Object[] {
          new ParDef("@AV11pPurchaseOrderId",GXType.Int32,6,0) ,
          new ParDef("@AV6cPurchaseOrderDetailId",GXType.Int32,6,0) ,
          new ParDef("@AV7cPurchaseOrderDetailQuantity",GXType.Int16,4,0) ,
          new ParDef("@AV8cProductId",GXType.Int32,6,0) ,
          new ParDef("@AV9cPurchaseOrderDetailCurrentPrice",GXType.Decimal,10,2) ,
          new ParDef("@AV10cPurchaseOrderDetailSuggestedPrice",GXType.Decimal,10,2) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH001J3;
          prmH001J3 = new Object[] {
          new ParDef("@AV11pPurchaseOrderId",GXType.Int32,6,0) ,
          new ParDef("@AV6cPurchaseOrderDetailId",GXType.Int32,6,0) ,
          new ParDef("@AV7cPurchaseOrderDetailQuantity",GXType.Int16,4,0) ,
          new ParDef("@AV8cProductId",GXType.Int32,6,0) ,
          new ParDef("@AV9cPurchaseOrderDetailCurrentPrice",GXType.Decimal,10,2) ,
          new ParDef("@AV10cPurchaseOrderDetailSuggestedPrice",GXType.Decimal,10,2)
          };
          def= new CursorDef[] {
              new CursorDef("H001J2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001J2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H001J3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001J3,1, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
