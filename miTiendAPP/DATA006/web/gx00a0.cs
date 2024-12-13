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
   public class gx00a0 : GXDataArea
   {
      public gx00a0( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public gx00a0( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out int aP0_pPurchaseOrderId )
      {
         this.AV13pPurchaseOrderId = 0 ;
         executePrivate();
         aP0_pPurchaseOrderId=this.AV13pPurchaseOrderId;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkavCpurchaseorderactive = new GXCheckbox();
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
               AV13pPurchaseOrderId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV13pPurchaseOrderId", StringUtil.LTrimStr( (decimal)(AV13pPurchaseOrderId), 6, 0));
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
         AV6cPurchaseOrderId = (int)(Math.Round(NumberUtil.Val( GetPar( "cPurchaseOrderId"), "."), 18, MidpointRounding.ToEven));
         AV7cSupplierId = (int)(Math.Round(NumberUtil.Val( GetPar( "cSupplierId"), "."), 18, MidpointRounding.ToEven));
         AV8cPurchaseOrderCreatedDate = context.localUtil.ParseDateParm( GetPar( "cPurchaseOrderCreatedDate"));
         AV9cPurchaseOrderModifiedDate = context.localUtil.ParseDateParm( GetPar( "cPurchaseOrderModifiedDate"));
         AV10cPurchaseOrderClosedDate = context.localUtil.ParseDateParm( GetPar( "cPurchaseOrderClosedDate"));
         AV11cPurchaseOrderTotalPaid = NumberUtil.Val( GetPar( "cPurchaseOrderTotalPaid"), ".");
         AV12cPurchaseOrderActive = StringUtil.StrToBool( GetPar( "cPurchaseOrderActive"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cPurchaseOrderId, AV7cSupplierId, AV8cPurchaseOrderCreatedDate, AV9cPurchaseOrderModifiedDate, AV10cPurchaseOrderClosedDate, AV11cPurchaseOrderTotalPaid, AV12cPurchaseOrderActive) ;
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
         PA2H2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2H2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx00a0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pPurchaseOrderId,6,0))}, new string[] {"pPurchaseOrderId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCPURCHASEORDERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cPurchaseOrderId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCSUPPLIERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cSupplierId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCPURCHASEORDERCREATEDDATE", context.localUtil.Format(AV8cPurchaseOrderCreatedDate, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vCPURCHASEORDERMODIFIEDDATE", context.localUtil.Format(AV9cPurchaseOrderModifiedDate, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vCPURCHASEORDERCLOSEDDATE", context.localUtil.Format(AV10cPurchaseOrderClosedDate, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vCPURCHASEORDERTOTALPAID", StringUtil.LTrim( StringUtil.NToC( AV11cPurchaseOrderTotalPaid, 18, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCPURCHASEORDERACTIVE", StringUtil.BoolToStr( AV12cPurchaseOrderActive));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPPURCHASEORDERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pPurchaseOrderId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "PURCHASEORDERIDFILTERCONTAINER_Class", StringUtil.RTrim( divPurchaseorderidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "SUPPLIERIDFILTERCONTAINER_Class", StringUtil.RTrim( divSupplieridfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PURCHASEORDERCREATEDDATEFILTERCONTAINER_Class", StringUtil.RTrim( divPurchaseordercreateddatefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PURCHASEORDERMODIFIEDDATEFILTERCONTAINER_Class", StringUtil.RTrim( divPurchaseordermodifieddatefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PURCHASEORDERCLOSEDDATEFILTERCONTAINER_Class", StringUtil.RTrim( divPurchaseordercloseddatefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PURCHASEORDERTOTALPAIDFILTERCONTAINER_Class", StringUtil.RTrim( divPurchaseordertotalpaidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PURCHASEORDERACTIVEFILTERCONTAINER_Class", StringUtil.RTrim( divPurchaseorderactivefiltercontainer_Class));
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
            WE2H2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2H2( ) ;
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
         return formatLink("gx00a0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pPurchaseOrderId,6,0))}, new string[] {"pPurchaseOrderId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx00A0" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List Purchase Order" ;
      }

      protected void WB2H0( )
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
            GxWebStd.gx_div_start( context, divPurchaseorderidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divPurchaseorderidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblpurchaseorderidfilter_Internalname, "Purchase Order Id", "", "", lblLblpurchaseorderidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e112h1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00A0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCpurchaseorderid_Internalname, "Purchase Order Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCpurchaseorderid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cPurchaseOrderId), 6, 0, ".", "")), StringUtil.LTrim( ((edtavCpurchaseorderid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cPurchaseOrderId), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV6cPurchaseOrderId), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpurchaseorderid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCpurchaseorderid_Visible, edtavCpurchaseorderid_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00A0.htm");
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
            GxWebStd.gx_div_start( context, divSupplieridfiltercontainer_Internalname, 1, 0, "px", 0, "px", divSupplieridfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsupplieridfilter_Internalname, "Supplier Id", "", "", lblLblsupplieridfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e122h1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00A0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsupplierid_Internalname, "Supplier Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCsupplierid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cSupplierId), 6, 0, ".", "")), StringUtil.LTrim( ((edtavCsupplierid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV7cSupplierId), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV7cSupplierId), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCsupplierid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCsupplierid_Visible, edtavCsupplierid_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00A0.htm");
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
            GxWebStd.gx_div_start( context, divPurchaseordercreateddatefiltercontainer_Internalname, 1, 0, "px", 0, "px", divPurchaseordercreateddatefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblpurchaseordercreateddatefilter_Internalname, "Purchase Order Created Date", "", "", lblLblpurchaseordercreateddatefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e132h1_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00A0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCpurchaseordercreateddate_Internalname, "Purchase Order Created Date", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCpurchaseordercreateddate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCpurchaseordercreateddate_Internalname, context.localUtil.Format(AV8cPurchaseOrderCreatedDate, "99/99/99"), context.localUtil.Format( AV8cPurchaseOrderCreatedDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpurchaseordercreateddate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCpurchaseordercreateddate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00A0.htm");
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
            GxWebStd.gx_div_start( context, divPurchaseordermodifieddatefiltercontainer_Internalname, 1, 0, "px", 0, "px", divPurchaseordermodifieddatefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblpurchaseordermodifieddatefilter_Internalname, "Purchase Order Modified Date", "", "", lblLblpurchaseordermodifieddatefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e142h1_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00A0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCpurchaseordermodifieddate_Internalname, "Purchase Order Modified Date", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCpurchaseordermodifieddate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCpurchaseordermodifieddate_Internalname, context.localUtil.Format(AV9cPurchaseOrderModifiedDate, "99/99/99"), context.localUtil.Format( AV9cPurchaseOrderModifiedDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpurchaseordermodifieddate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCpurchaseordermodifieddate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00A0.htm");
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
            GxWebStd.gx_div_start( context, divPurchaseordercloseddatefiltercontainer_Internalname, 1, 0, "px", 0, "px", divPurchaseordercloseddatefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblpurchaseordercloseddatefilter_Internalname, "Purchase Order Closed Date", "", "", lblLblpurchaseordercloseddatefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e152h1_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00A0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCpurchaseordercloseddate_Internalname, "Purchase Order Closed Date", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCpurchaseordercloseddate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCpurchaseordercloseddate_Internalname, context.localUtil.Format(AV10cPurchaseOrderClosedDate, "99/99/99"), context.localUtil.Format( AV10cPurchaseOrderClosedDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpurchaseordercloseddate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCpurchaseordercloseddate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00A0.htm");
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
            GxWebStd.gx_div_start( context, divPurchaseordertotalpaidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divPurchaseordertotalpaidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblpurchaseordertotalpaidfilter_Internalname, "Purchase Order Total Paid", "", "", lblLblpurchaseordertotalpaidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e162h1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00A0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCpurchaseordertotalpaid_Internalname, "Purchase Order Total Paid", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCpurchaseordertotalpaid_Internalname, StringUtil.LTrim( StringUtil.NToC( AV11cPurchaseOrderTotalPaid, 18, 2, ".", "")), StringUtil.LTrim( ((edtavCpurchaseordertotalpaid_Enabled!=0) ? context.localUtil.Format( AV11cPurchaseOrderTotalPaid, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV11cPurchaseOrderTotalPaid, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpurchaseordertotalpaid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCpurchaseordertotalpaid_Visible, edtavCpurchaseordertotalpaid_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00A0.htm");
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
            GxWebStd.gx_div_start( context, divPurchaseorderactivefiltercontainer_Internalname, 1, 0, "px", 0, "px", divPurchaseorderactivefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblpurchaseorderactivefilter_Internalname, "Purchase Order Active", "", "", lblLblpurchaseorderactivefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e172h1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00A0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavCpurchaseorderactive_Internalname, "Purchase Order Active", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCpurchaseorderactive_Internalname, StringUtil.BoolToStr( AV12cPurchaseOrderActive), "", "Purchase Order Active", chkavCpurchaseorderactive.Visible, chkavCpurchaseorderactive.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(76, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,76);\"");
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e182h1_client"+"'", TempTags, "", 2, "HLP_Gx00A0.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx00A0.htm");
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

      protected void START2H2( )
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
            Form.Meta.addItem("description", "Selection List Purchase Order", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2H0( ) ;
      }

      protected void WS2H2( )
      {
         START2H2( ) ;
         EVT2H2( ) ;
      }

      protected void EVT2H2( )
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
                              A50PurchaseOrderId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPurchaseOrderId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A4SupplierId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtSupplierId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A52PurchaseOrderCreatedDate = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtPurchaseOrderCreatedDate_Internalname), 0));
                              A53PurchaseOrderModifiedDate = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtPurchaseOrderModifiedDate_Internalname), 0));
                              n53PurchaseOrderModifiedDate = false;
                              A66PurchaseOrderClosedDate = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtPurchaseOrderClosedDate_Internalname), 0));
                              n66PurchaseOrderClosedDate = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E192H2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E202H2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cpurchaseorderid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPURCHASEORDERID"), ".", ",") != Convert.ToDecimal( AV6cPurchaseOrderId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Csupplierid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCSUPPLIERID"), ".", ",") != Convert.ToDecimal( AV7cSupplierId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cpurchaseordercreateddate Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCPURCHASEORDERCREATEDDATE"), 0) != AV8cPurchaseOrderCreatedDate )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cpurchaseordermodifieddate Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCPURCHASEORDERMODIFIEDDATE"), 0) != AV9cPurchaseOrderModifiedDate )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cpurchaseordercloseddate Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCPURCHASEORDERCLOSEDDATE"), 0) != AV10cPurchaseOrderClosedDate )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cpurchaseordertotalpaid Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCPURCHASEORDERTOTALPAID"), ".", ",") != AV11cPurchaseOrderTotalPaid )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cpurchaseorderactive Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vCPURCHASEORDERACTIVE")) != AV12cPurchaseOrderActive )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E212H2 ();
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

      protected void WE2H2( )
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

      protected void PA2H2( )
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
                                        int AV6cPurchaseOrderId ,
                                        int AV7cSupplierId ,
                                        DateTime AV8cPurchaseOrderCreatedDate ,
                                        DateTime AV9cPurchaseOrderModifiedDate ,
                                        DateTime AV10cPurchaseOrderClosedDate ,
                                        decimal AV11cPurchaseOrderTotalPaid ,
                                        bool AV12cPurchaseOrderActive )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF2H2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PURCHASEORDERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A50PurchaseOrderId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "PURCHASEORDERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A50PurchaseOrderId), 6, 0, ".", "")));
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
         AV12cPurchaseOrderActive = StringUtil.StrToBool( StringUtil.BoolToStr( AV12cPurchaseOrderActive));
         AssignAttri("", false, "AV12cPurchaseOrderActive", AV12cPurchaseOrderActive);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF2H2( ) ;
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

      protected void RF2H2( )
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
                                                 AV7cSupplierId ,
                                                 AV8cPurchaseOrderCreatedDate ,
                                                 AV9cPurchaseOrderModifiedDate ,
                                                 AV10cPurchaseOrderClosedDate ,
                                                 AV11cPurchaseOrderTotalPaid ,
                                                 AV12cPurchaseOrderActive ,
                                                 A4SupplierId ,
                                                 A52PurchaseOrderCreatedDate ,
                                                 A53PurchaseOrderModifiedDate ,
                                                 A66PurchaseOrderClosedDate ,
                                                 A78PurchaseOrderTotalPaid ,
                                                 A79PurchaseOrderActive ,
                                                 AV6cPurchaseOrderId } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                                 TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT
                                                 }
            });
            /* Using cursor H002H2 */
            pr_default.execute(0, new Object[] {AV6cPurchaseOrderId, AV7cSupplierId, AV8cPurchaseOrderCreatedDate, AV9cPurchaseOrderModifiedDate, AV10cPurchaseOrderClosedDate, AV11cPurchaseOrderTotalPaid, AV12cPurchaseOrderActive, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A79PurchaseOrderActive = H002H2_A79PurchaseOrderActive[0];
               A78PurchaseOrderTotalPaid = H002H2_A78PurchaseOrderTotalPaid[0];
               n78PurchaseOrderTotalPaid = H002H2_n78PurchaseOrderTotalPaid[0];
               A66PurchaseOrderClosedDate = H002H2_A66PurchaseOrderClosedDate[0];
               n66PurchaseOrderClosedDate = H002H2_n66PurchaseOrderClosedDate[0];
               A53PurchaseOrderModifiedDate = H002H2_A53PurchaseOrderModifiedDate[0];
               n53PurchaseOrderModifiedDate = H002H2_n53PurchaseOrderModifiedDate[0];
               A52PurchaseOrderCreatedDate = H002H2_A52PurchaseOrderCreatedDate[0];
               A4SupplierId = H002H2_A4SupplierId[0];
               A50PurchaseOrderId = H002H2_A50PurchaseOrderId[0];
               /* Execute user event: Load */
               E202H2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB2H0( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2H2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PURCHASEORDERID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A50PurchaseOrderId), "ZZZZZ9"), context));
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
                                              AV7cSupplierId ,
                                              AV8cPurchaseOrderCreatedDate ,
                                              AV9cPurchaseOrderModifiedDate ,
                                              AV10cPurchaseOrderClosedDate ,
                                              AV11cPurchaseOrderTotalPaid ,
                                              AV12cPurchaseOrderActive ,
                                              A4SupplierId ,
                                              A52PurchaseOrderCreatedDate ,
                                              A53PurchaseOrderModifiedDate ,
                                              A66PurchaseOrderClosedDate ,
                                              A78PurchaseOrderTotalPaid ,
                                              A79PurchaseOrderActive ,
                                              AV6cPurchaseOrderId } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         /* Using cursor H002H3 */
         pr_default.execute(1, new Object[] {AV6cPurchaseOrderId, AV7cSupplierId, AV8cPurchaseOrderCreatedDate, AV9cPurchaseOrderModifiedDate, AV10cPurchaseOrderClosedDate, AV11cPurchaseOrderTotalPaid, AV12cPurchaseOrderActive});
         GRID1_nRecordCount = H002H3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cPurchaseOrderId, AV7cSupplierId, AV8cPurchaseOrderCreatedDate, AV9cPurchaseOrderModifiedDate, AV10cPurchaseOrderClosedDate, AV11cPurchaseOrderTotalPaid, AV12cPurchaseOrderActive) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cPurchaseOrderId, AV7cSupplierId, AV8cPurchaseOrderCreatedDate, AV9cPurchaseOrderModifiedDate, AV10cPurchaseOrderClosedDate, AV11cPurchaseOrderTotalPaid, AV12cPurchaseOrderActive) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cPurchaseOrderId, AV7cSupplierId, AV8cPurchaseOrderCreatedDate, AV9cPurchaseOrderModifiedDate, AV10cPurchaseOrderClosedDate, AV11cPurchaseOrderTotalPaid, AV12cPurchaseOrderActive) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cPurchaseOrderId, AV7cSupplierId, AV8cPurchaseOrderCreatedDate, AV9cPurchaseOrderModifiedDate, AV10cPurchaseOrderClosedDate, AV11cPurchaseOrderTotalPaid, AV12cPurchaseOrderActive) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cPurchaseOrderId, AV7cSupplierId, AV8cPurchaseOrderCreatedDate, AV9cPurchaseOrderModifiedDate, AV10cPurchaseOrderClosedDate, AV11cPurchaseOrderTotalPaid, AV12cPurchaseOrderActive) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2H0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E192H2 ();
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCpurchaseorderid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCpurchaseorderid_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCPURCHASEORDERID");
               GX_FocusControl = edtavCpurchaseorderid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cPurchaseOrderId = 0;
               AssignAttri("", false, "AV6cPurchaseOrderId", StringUtil.LTrimStr( (decimal)(AV6cPurchaseOrderId), 6, 0));
            }
            else
            {
               AV6cPurchaseOrderId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCpurchaseorderid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV6cPurchaseOrderId", StringUtil.LTrimStr( (decimal)(AV6cPurchaseOrderId), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCsupplierid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCsupplierid_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCSUPPLIERID");
               GX_FocusControl = edtavCsupplierid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cSupplierId = 0;
               AssignAttri("", false, "AV7cSupplierId", StringUtil.LTrimStr( (decimal)(AV7cSupplierId), 6, 0));
            }
            else
            {
               AV7cSupplierId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCsupplierid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7cSupplierId", StringUtil.LTrimStr( (decimal)(AV7cSupplierId), 6, 0));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCpurchaseordercreateddate_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Purchase Order Created Date"}), 1, "vCPURCHASEORDERCREATEDDATE");
               GX_FocusControl = edtavCpurchaseordercreateddate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cPurchaseOrderCreatedDate = DateTime.MinValue;
               AssignAttri("", false, "AV8cPurchaseOrderCreatedDate", context.localUtil.Format(AV8cPurchaseOrderCreatedDate, "99/99/99"));
            }
            else
            {
               AV8cPurchaseOrderCreatedDate = context.localUtil.CToD( cgiGet( edtavCpurchaseordercreateddate_Internalname), 1);
               AssignAttri("", false, "AV8cPurchaseOrderCreatedDate", context.localUtil.Format(AV8cPurchaseOrderCreatedDate, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCpurchaseordermodifieddate_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Purchase Order Modified Date"}), 1, "vCPURCHASEORDERMODIFIEDDATE");
               GX_FocusControl = edtavCpurchaseordermodifieddate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9cPurchaseOrderModifiedDate = DateTime.MinValue;
               AssignAttri("", false, "AV9cPurchaseOrderModifiedDate", context.localUtil.Format(AV9cPurchaseOrderModifiedDate, "99/99/99"));
            }
            else
            {
               AV9cPurchaseOrderModifiedDate = context.localUtil.CToD( cgiGet( edtavCpurchaseordermodifieddate_Internalname), 1);
               AssignAttri("", false, "AV9cPurchaseOrderModifiedDate", context.localUtil.Format(AV9cPurchaseOrderModifiedDate, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCpurchaseordercloseddate_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Purchase Order Closed Date"}), 1, "vCPURCHASEORDERCLOSEDDATE");
               GX_FocusControl = edtavCpurchaseordercloseddate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cPurchaseOrderClosedDate = DateTime.MinValue;
               AssignAttri("", false, "AV10cPurchaseOrderClosedDate", context.localUtil.Format(AV10cPurchaseOrderClosedDate, "99/99/99"));
            }
            else
            {
               AV10cPurchaseOrderClosedDate = context.localUtil.CToD( cgiGet( edtavCpurchaseordercloseddate_Internalname), 1);
               AssignAttri("", false, "AV10cPurchaseOrderClosedDate", context.localUtil.Format(AV10cPurchaseOrderClosedDate, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCpurchaseordertotalpaid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCpurchaseordertotalpaid_Internalname), ".", ",") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCPURCHASEORDERTOTALPAID");
               GX_FocusControl = edtavCpurchaseordertotalpaid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cPurchaseOrderTotalPaid = 0;
               AssignAttri("", false, "AV11cPurchaseOrderTotalPaid", StringUtil.LTrimStr( AV11cPurchaseOrderTotalPaid, 18, 2));
            }
            else
            {
               AV11cPurchaseOrderTotalPaid = context.localUtil.CToN( cgiGet( edtavCpurchaseordertotalpaid_Internalname), ".", ",");
               AssignAttri("", false, "AV11cPurchaseOrderTotalPaid", StringUtil.LTrimStr( AV11cPurchaseOrderTotalPaid, 18, 2));
            }
            AV12cPurchaseOrderActive = StringUtil.StrToBool( cgiGet( chkavCpurchaseorderactive_Internalname));
            AssignAttri("", false, "AV12cPurchaseOrderActive", AV12cPurchaseOrderActive);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPURCHASEORDERID"), ".", ",") != Convert.ToDecimal( AV6cPurchaseOrderId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCSUPPLIERID"), ".", ",") != Convert.ToDecimal( AV7cSupplierId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCPURCHASEORDERCREATEDDATE"), 1) ) != DateTimeUtil.ResetTime ( AV8cPurchaseOrderCreatedDate ) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCPURCHASEORDERMODIFIEDDATE"), 1) ) != DateTimeUtil.ResetTime ( AV9cPurchaseOrderModifiedDate ) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCPURCHASEORDERCLOSEDDATE"), 1) ) != DateTimeUtil.ResetTime ( AV10cPurchaseOrderClosedDate ) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCPURCHASEORDERTOTALPAID"), ".", ",") != AV11cPurchaseOrderTotalPaid )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vCPURCHASEORDERACTIVE")) != AV12cPurchaseOrderActive )
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
         E192H2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E192H2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Selection List %1", "Purchase Order", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E202H2( )
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
         E212H2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E212H2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pPurchaseOrderId = A50PurchaseOrderId;
         AssignAttri("", false, "AV13pPurchaseOrderId", StringUtil.LTrimStr( (decimal)(AV13pPurchaseOrderId), 6, 0));
         context.setWebReturnParms(new Object[] {(int)AV13pPurchaseOrderId});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pPurchaseOrderId"});
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
         AV13pPurchaseOrderId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV13pPurchaseOrderId", StringUtil.LTrimStr( (decimal)(AV13pPurchaseOrderId), 6, 0));
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
         PA2H2( ) ;
         WS2H2( ) ;
         WE2H2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202411242340516", true, true);
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
         context.AddJavascriptSource("gx00a0.js", "?202411242340518", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtPurchaseOrderId_Internalname = "PURCHASEORDERID_"+sGXsfl_84_idx;
         edtSupplierId_Internalname = "SUPPLIERID_"+sGXsfl_84_idx;
         edtPurchaseOrderCreatedDate_Internalname = "PURCHASEORDERCREATEDDATE_"+sGXsfl_84_idx;
         edtPurchaseOrderModifiedDate_Internalname = "PURCHASEORDERMODIFIEDDATE_"+sGXsfl_84_idx;
         edtPurchaseOrderClosedDate_Internalname = "PURCHASEORDERCLOSEDDATE_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtPurchaseOrderId_Internalname = "PURCHASEORDERID_"+sGXsfl_84_fel_idx;
         edtSupplierId_Internalname = "SUPPLIERID_"+sGXsfl_84_fel_idx;
         edtPurchaseOrderCreatedDate_Internalname = "PURCHASEORDERCREATEDDATE_"+sGXsfl_84_fel_idx;
         edtPurchaseOrderModifiedDate_Internalname = "PURCHASEORDERMODIFIEDDATE_"+sGXsfl_84_fel_idx;
         edtPurchaseOrderClosedDate_Internalname = "PURCHASEORDERCLOSEDDATE_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         SubsflControlProps_842( ) ;
         WB2H0( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A50PurchaseOrderId), 6, 0, ".", "")))+"'"+"]);";
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
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPurchaseOrderId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A50PurchaseOrderId), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A50PurchaseOrderId), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPurchaseOrderId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A4SupplierId), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A4SupplierId), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtPurchaseOrderCreatedDate_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A50PurchaseOrderId), 6, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtPurchaseOrderCreatedDate_Internalname, "Link", edtPurchaseOrderCreatedDate_Link, !bGXsfl_84_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPurchaseOrderCreatedDate_Internalname,context.localUtil.Format(A52PurchaseOrderCreatedDate, "99/99/99"),context.localUtil.Format( A52PurchaseOrderCreatedDate, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtPurchaseOrderCreatedDate_Link,(string)"",(string)"",(string)"",(string)edtPurchaseOrderCreatedDate_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"PurchaseOrderDate",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPurchaseOrderModifiedDate_Internalname,context.localUtil.Format(A53PurchaseOrderModifiedDate, "99/99/99"),context.localUtil.Format( A53PurchaseOrderModifiedDate, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPurchaseOrderModifiedDate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPurchaseOrderClosedDate_Internalname,context.localUtil.Format(A66PurchaseOrderClosedDate, "99/99/99"),context.localUtil.Format( A66PurchaseOrderClosedDate, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPurchaseOrderClosedDate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"PurchaseOrderDate",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes2H2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         /* End function sendrow_842 */
      }

      protected void init_web_controls( )
      {
         chkavCpurchaseorderactive.Name = "vCPURCHASEORDERACTIVE";
         chkavCpurchaseorderactive.WebTags = "";
         chkavCpurchaseorderactive.Caption = "";
         AssignProp("", false, chkavCpurchaseorderactive_Internalname, "TitleCaption", chkavCpurchaseorderactive.Caption, true);
         chkavCpurchaseorderactive.CheckedValue = "false";
         AV12cPurchaseOrderActive = StringUtil.StrToBool( StringUtil.BoolToStr( AV12cPurchaseOrderActive));
         AssignAttri("", false, "AV12cPurchaseOrderActive", AV12cPurchaseOrderActive);
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
            context.SendWebValue( "Order Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Supplier Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Created Date") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Modified Date") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Closed Date") ;
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
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A50PurchaseOrderId), 6, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A4SupplierId), 6, 0, ".", ""))));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A52PurchaseOrderCreatedDate, "99/99/99")));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtPurchaseOrderCreatedDate_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A53PurchaseOrderModifiedDate, "99/99/99")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A66PurchaseOrderClosedDate, "99/99/99")));
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
         lblLblpurchaseorderidfilter_Internalname = "LBLPURCHASEORDERIDFILTER";
         edtavCpurchaseorderid_Internalname = "vCPURCHASEORDERID";
         divPurchaseorderidfiltercontainer_Internalname = "PURCHASEORDERIDFILTERCONTAINER";
         lblLblsupplieridfilter_Internalname = "LBLSUPPLIERIDFILTER";
         edtavCsupplierid_Internalname = "vCSUPPLIERID";
         divSupplieridfiltercontainer_Internalname = "SUPPLIERIDFILTERCONTAINER";
         lblLblpurchaseordercreateddatefilter_Internalname = "LBLPURCHASEORDERCREATEDDATEFILTER";
         edtavCpurchaseordercreateddate_Internalname = "vCPURCHASEORDERCREATEDDATE";
         divPurchaseordercreateddatefiltercontainer_Internalname = "PURCHASEORDERCREATEDDATEFILTERCONTAINER";
         lblLblpurchaseordermodifieddatefilter_Internalname = "LBLPURCHASEORDERMODIFIEDDATEFILTER";
         edtavCpurchaseordermodifieddate_Internalname = "vCPURCHASEORDERMODIFIEDDATE";
         divPurchaseordermodifieddatefiltercontainer_Internalname = "PURCHASEORDERMODIFIEDDATEFILTERCONTAINER";
         lblLblpurchaseordercloseddatefilter_Internalname = "LBLPURCHASEORDERCLOSEDDATEFILTER";
         edtavCpurchaseordercloseddate_Internalname = "vCPURCHASEORDERCLOSEDDATE";
         divPurchaseordercloseddatefiltercontainer_Internalname = "PURCHASEORDERCLOSEDDATEFILTERCONTAINER";
         lblLblpurchaseordertotalpaidfilter_Internalname = "LBLPURCHASEORDERTOTALPAIDFILTER";
         edtavCpurchaseordertotalpaid_Internalname = "vCPURCHASEORDERTOTALPAID";
         divPurchaseordertotalpaidfiltercontainer_Internalname = "PURCHASEORDERTOTALPAIDFILTERCONTAINER";
         lblLblpurchaseorderactivefilter_Internalname = "LBLPURCHASEORDERACTIVEFILTER";
         chkavCpurchaseorderactive_Internalname = "vCPURCHASEORDERACTIVE";
         divPurchaseorderactivefiltercontainer_Internalname = "PURCHASEORDERACTIVEFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtPurchaseOrderId_Internalname = "PURCHASEORDERID";
         edtSupplierId_Internalname = "SUPPLIERID";
         edtPurchaseOrderCreatedDate_Internalname = "PURCHASEORDERCREATEDDATE";
         edtPurchaseOrderModifiedDate_Internalname = "PURCHASEORDERMODIFIEDDATE";
         edtPurchaseOrderClosedDate_Internalname = "PURCHASEORDERCLOSEDDATE";
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
         chkavCpurchaseorderactive.Caption = "Purchase Order Active";
         edtPurchaseOrderClosedDate_Jsonclick = "";
         edtPurchaseOrderModifiedDate_Jsonclick = "";
         edtPurchaseOrderCreatedDate_Jsonclick = "";
         edtPurchaseOrderCreatedDate_Link = "";
         edtSupplierId_Jsonclick = "";
         edtPurchaseOrderId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         chkavCpurchaseorderactive.Enabled = 1;
         chkavCpurchaseorderactive.Visible = 1;
         edtavCpurchaseordertotalpaid_Jsonclick = "";
         edtavCpurchaseordertotalpaid_Enabled = 1;
         edtavCpurchaseordertotalpaid_Visible = 1;
         edtavCpurchaseordercloseddate_Jsonclick = "";
         edtavCpurchaseordercloseddate_Enabled = 1;
         edtavCpurchaseordermodifieddate_Jsonclick = "";
         edtavCpurchaseordermodifieddate_Enabled = 1;
         edtavCpurchaseordercreateddate_Jsonclick = "";
         edtavCpurchaseordercreateddate_Enabled = 1;
         edtavCsupplierid_Jsonclick = "";
         edtavCsupplierid_Enabled = 1;
         edtavCsupplierid_Visible = 1;
         edtavCpurchaseorderid_Jsonclick = "";
         edtavCpurchaseorderid_Enabled = 1;
         edtavCpurchaseorderid_Visible = 1;
         divPurchaseorderactivefiltercontainer_Class = "AdvancedContainerItem";
         divPurchaseordertotalpaidfiltercontainer_Class = "AdvancedContainerItem";
         divPurchaseordercloseddatefiltercontainer_Class = "AdvancedContainerItem";
         divPurchaseordermodifieddatefiltercontainer_Class = "AdvancedContainerItem";
         divPurchaseordercreateddatefiltercontainer_Class = "AdvancedContainerItem";
         divSupplieridfiltercontainer_Class = "AdvancedContainerItem";
         divPurchaseorderidfiltercontainer_Class = "AdvancedContainerItem";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List Purchase Order";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cPurchaseOrderId',fld:'vCPURCHASEORDERID',pic:'ZZZZZ9'},{av:'AV7cSupplierId',fld:'vCSUPPLIERID',pic:'ZZZZZ9'},{av:'AV8cPurchaseOrderCreatedDate',fld:'vCPURCHASEORDERCREATEDDATE',pic:''},{av:'AV9cPurchaseOrderModifiedDate',fld:'vCPURCHASEORDERMODIFIEDDATE',pic:''},{av:'AV10cPurchaseOrderClosedDate',fld:'vCPURCHASEORDERCLOSEDDATE',pic:''},{av:'AV11cPurchaseOrderTotalPaid',fld:'vCPURCHASEORDERTOTALPAID',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV12cPurchaseOrderActive',fld:'vCPURCHASEORDERACTIVE',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E182H1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLPURCHASEORDERIDFILTER.CLICK","{handler:'E112H1',iparms:[{av:'divPurchaseorderidfiltercontainer_Class',ctrl:'PURCHASEORDERIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPURCHASEORDERIDFILTER.CLICK",",oparms:[{av:'divPurchaseorderidfiltercontainer_Class',ctrl:'PURCHASEORDERIDFILTERCONTAINER',prop:'Class'},{av:'edtavCpurchaseorderid_Visible',ctrl:'vCPURCHASEORDERID',prop:'Visible'}]}");
         setEventMetadata("LBLSUPPLIERIDFILTER.CLICK","{handler:'E122H1',iparms:[{av:'divSupplieridfiltercontainer_Class',ctrl:'SUPPLIERIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLSUPPLIERIDFILTER.CLICK",",oparms:[{av:'divSupplieridfiltercontainer_Class',ctrl:'SUPPLIERIDFILTERCONTAINER',prop:'Class'},{av:'edtavCsupplierid_Visible',ctrl:'vCSUPPLIERID',prop:'Visible'}]}");
         setEventMetadata("LBLPURCHASEORDERCREATEDDATEFILTER.CLICK","{handler:'E132H1',iparms:[{av:'divPurchaseordercreateddatefiltercontainer_Class',ctrl:'PURCHASEORDERCREATEDDATEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPURCHASEORDERCREATEDDATEFILTER.CLICK",",oparms:[{av:'divPurchaseordercreateddatefiltercontainer_Class',ctrl:'PURCHASEORDERCREATEDDATEFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLPURCHASEORDERMODIFIEDDATEFILTER.CLICK","{handler:'E142H1',iparms:[{av:'divPurchaseordermodifieddatefiltercontainer_Class',ctrl:'PURCHASEORDERMODIFIEDDATEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPURCHASEORDERMODIFIEDDATEFILTER.CLICK",",oparms:[{av:'divPurchaseordermodifieddatefiltercontainer_Class',ctrl:'PURCHASEORDERMODIFIEDDATEFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLPURCHASEORDERCLOSEDDATEFILTER.CLICK","{handler:'E152H1',iparms:[{av:'divPurchaseordercloseddatefiltercontainer_Class',ctrl:'PURCHASEORDERCLOSEDDATEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPURCHASEORDERCLOSEDDATEFILTER.CLICK",",oparms:[{av:'divPurchaseordercloseddatefiltercontainer_Class',ctrl:'PURCHASEORDERCLOSEDDATEFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLPURCHASEORDERTOTALPAIDFILTER.CLICK","{handler:'E162H1',iparms:[{av:'divPurchaseordertotalpaidfiltercontainer_Class',ctrl:'PURCHASEORDERTOTALPAIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPURCHASEORDERTOTALPAIDFILTER.CLICK",",oparms:[{av:'divPurchaseordertotalpaidfiltercontainer_Class',ctrl:'PURCHASEORDERTOTALPAIDFILTERCONTAINER',prop:'Class'},{av:'edtavCpurchaseordertotalpaid_Visible',ctrl:'vCPURCHASEORDERTOTALPAID',prop:'Visible'}]}");
         setEventMetadata("LBLPURCHASEORDERACTIVEFILTER.CLICK","{handler:'E172H1',iparms:[{av:'divPurchaseorderactivefiltercontainer_Class',ctrl:'PURCHASEORDERACTIVEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPURCHASEORDERACTIVEFILTER.CLICK",",oparms:[{av:'divPurchaseorderactivefiltercontainer_Class',ctrl:'PURCHASEORDERACTIVEFILTERCONTAINER',prop:'Class'},{av:'chkavCpurchaseorderactive.Visible',ctrl:'vCPURCHASEORDERACTIVE',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E212H2',iparms:[{av:'A50PurchaseOrderId',fld:'PURCHASEORDERID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pPurchaseOrderId',fld:'vPPURCHASEORDERID',pic:'ZZZZZ9'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cPurchaseOrderId',fld:'vCPURCHASEORDERID',pic:'ZZZZZ9'},{av:'AV7cSupplierId',fld:'vCSUPPLIERID',pic:'ZZZZZ9'},{av:'AV8cPurchaseOrderCreatedDate',fld:'vCPURCHASEORDERCREATEDDATE',pic:''},{av:'AV9cPurchaseOrderModifiedDate',fld:'vCPURCHASEORDERMODIFIEDDATE',pic:''},{av:'AV10cPurchaseOrderClosedDate',fld:'vCPURCHASEORDERCLOSEDDATE',pic:''},{av:'AV11cPurchaseOrderTotalPaid',fld:'vCPURCHASEORDERTOTALPAID',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV12cPurchaseOrderActive',fld:'vCPURCHASEORDERACTIVE',pic:''}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cPurchaseOrderId',fld:'vCPURCHASEORDERID',pic:'ZZZZZ9'},{av:'AV7cSupplierId',fld:'vCSUPPLIERID',pic:'ZZZZZ9'},{av:'AV8cPurchaseOrderCreatedDate',fld:'vCPURCHASEORDERCREATEDDATE',pic:''},{av:'AV9cPurchaseOrderModifiedDate',fld:'vCPURCHASEORDERMODIFIEDDATE',pic:''},{av:'AV10cPurchaseOrderClosedDate',fld:'vCPURCHASEORDERCLOSEDDATE',pic:''},{av:'AV11cPurchaseOrderTotalPaid',fld:'vCPURCHASEORDERTOTALPAID',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV12cPurchaseOrderActive',fld:'vCPURCHASEORDERACTIVE',pic:''}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cPurchaseOrderId',fld:'vCPURCHASEORDERID',pic:'ZZZZZ9'},{av:'AV7cSupplierId',fld:'vCSUPPLIERID',pic:'ZZZZZ9'},{av:'AV8cPurchaseOrderCreatedDate',fld:'vCPURCHASEORDERCREATEDDATE',pic:''},{av:'AV9cPurchaseOrderModifiedDate',fld:'vCPURCHASEORDERMODIFIEDDATE',pic:''},{av:'AV10cPurchaseOrderClosedDate',fld:'vCPURCHASEORDERCLOSEDDATE',pic:''},{av:'AV11cPurchaseOrderTotalPaid',fld:'vCPURCHASEORDERTOTALPAID',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV12cPurchaseOrderActive',fld:'vCPURCHASEORDERACTIVE',pic:''}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cPurchaseOrderId',fld:'vCPURCHASEORDERID',pic:'ZZZZZ9'},{av:'AV7cSupplierId',fld:'vCSUPPLIERID',pic:'ZZZZZ9'},{av:'AV8cPurchaseOrderCreatedDate',fld:'vCPURCHASEORDERCREATEDDATE',pic:''},{av:'AV9cPurchaseOrderModifiedDate',fld:'vCPURCHASEORDERMODIFIEDDATE',pic:''},{av:'AV10cPurchaseOrderClosedDate',fld:'vCPURCHASEORDERCLOSEDDATE',pic:''},{av:'AV11cPurchaseOrderTotalPaid',fld:'vCPURCHASEORDERTOTALPAID',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV12cPurchaseOrderActive',fld:'vCPURCHASEORDERACTIVE',pic:''}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CPURCHASEORDERCREATEDDATE","{handler:'Validv_Cpurchaseordercreateddate',iparms:[]");
         setEventMetadata("VALIDV_CPURCHASEORDERCREATEDDATE",",oparms:[]}");
         setEventMetadata("VALIDV_CPURCHASEORDERMODIFIEDDATE","{handler:'Validv_Cpurchaseordermodifieddate',iparms:[]");
         setEventMetadata("VALIDV_CPURCHASEORDERMODIFIEDDATE",",oparms:[]}");
         setEventMetadata("VALIDV_CPURCHASEORDERCLOSEDDATE","{handler:'Validv_Cpurchaseordercloseddate',iparms:[]");
         setEventMetadata("VALIDV_CPURCHASEORDERCLOSEDDATE",",oparms:[]}");
         setEventMetadata("VALIDV_CPURCHASEORDERTOTALPAID","{handler:'Validv_Cpurchaseordertotalpaid',iparms:[]");
         setEventMetadata("VALIDV_CPURCHASEORDERTOTALPAID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Purchaseordercloseddate',iparms:[]");
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
         AV8cPurchaseOrderCreatedDate = DateTime.MinValue;
         AV9cPurchaseOrderModifiedDate = DateTime.MinValue;
         AV10cPurchaseOrderClosedDate = DateTime.MinValue;
         AV12cPurchaseOrderActive = true;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblpurchaseorderidfilter_Jsonclick = "";
         TempTags = "";
         lblLblsupplieridfilter_Jsonclick = "";
         lblLblpurchaseordercreateddatefilter_Jsonclick = "";
         lblLblpurchaseordermodifieddatefilter_Jsonclick = "";
         lblLblpurchaseordercloseddatefilter_Jsonclick = "";
         lblLblpurchaseordertotalpaidfilter_Jsonclick = "";
         lblLblpurchaseorderactivefilter_Jsonclick = "";
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
         A52PurchaseOrderCreatedDate = DateTime.MinValue;
         A53PurchaseOrderModifiedDate = DateTime.MinValue;
         A66PurchaseOrderClosedDate = DateTime.MinValue;
         scmdbuf = "";
         H002H2_A79PurchaseOrderActive = new bool[] {false} ;
         H002H2_A78PurchaseOrderTotalPaid = new decimal[1] ;
         H002H2_n78PurchaseOrderTotalPaid = new bool[] {false} ;
         H002H2_A66PurchaseOrderClosedDate = new DateTime[] {DateTime.MinValue} ;
         H002H2_n66PurchaseOrderClosedDate = new bool[] {false} ;
         H002H2_A53PurchaseOrderModifiedDate = new DateTime[] {DateTime.MinValue} ;
         H002H2_n53PurchaseOrderModifiedDate = new bool[] {false} ;
         H002H2_A52PurchaseOrderCreatedDate = new DateTime[] {DateTime.MinValue} ;
         H002H2_A4SupplierId = new int[1] ;
         H002H2_A50PurchaseOrderId = new int[1] ;
         H002H3_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx00a0__default(),
            new Object[][] {
                new Object[] {
               H002H2_A79PurchaseOrderActive, H002H2_A78PurchaseOrderTotalPaid, H002H2_n78PurchaseOrderTotalPaid, H002H2_A66PurchaseOrderClosedDate, H002H2_n66PurchaseOrderClosedDate, H002H2_A53PurchaseOrderModifiedDate, H002H2_n53PurchaseOrderModifiedDate, H002H2_A52PurchaseOrderCreatedDate, H002H2_A4SupplierId, H002H2_A50PurchaseOrderId
               }
               , new Object[] {
               H002H3_AGRID1_nRecordCount
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
      private int AV13pPurchaseOrderId ;
      private int nRC_GXsfl_84 ;
      private int subGrid1_Rows ;
      private int nGXsfl_84_idx=1 ;
      private int AV6cPurchaseOrderId ;
      private int AV7cSupplierId ;
      private int edtavCpurchaseorderid_Enabled ;
      private int edtavCpurchaseorderid_Visible ;
      private int edtavCsupplierid_Enabled ;
      private int edtavCsupplierid_Visible ;
      private int edtavCpurchaseordercreateddate_Enabled ;
      private int edtavCpurchaseordermodifieddate_Enabled ;
      private int edtavCpurchaseordercloseddate_Enabled ;
      private int edtavCpurchaseordertotalpaid_Enabled ;
      private int edtavCpurchaseordertotalpaid_Visible ;
      private int A50PurchaseOrderId ;
      private int A4SupplierId ;
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
      private decimal AV11cPurchaseOrderTotalPaid ;
      private decimal A78PurchaseOrderTotalPaid ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divPurchaseorderidfiltercontainer_Class ;
      private string divSupplieridfiltercontainer_Class ;
      private string divPurchaseordercreateddatefiltercontainer_Class ;
      private string divPurchaseordermodifieddatefiltercontainer_Class ;
      private string divPurchaseordercloseddatefiltercontainer_Class ;
      private string divPurchaseordertotalpaidfiltercontainer_Class ;
      private string divPurchaseorderactivefiltercontainer_Class ;
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
      private string divPurchaseorderidfiltercontainer_Internalname ;
      private string lblLblpurchaseorderidfilter_Internalname ;
      private string lblLblpurchaseorderidfilter_Jsonclick ;
      private string edtavCpurchaseorderid_Internalname ;
      private string TempTags ;
      private string edtavCpurchaseorderid_Jsonclick ;
      private string divSupplieridfiltercontainer_Internalname ;
      private string lblLblsupplieridfilter_Internalname ;
      private string lblLblsupplieridfilter_Jsonclick ;
      private string edtavCsupplierid_Internalname ;
      private string edtavCsupplierid_Jsonclick ;
      private string divPurchaseordercreateddatefiltercontainer_Internalname ;
      private string lblLblpurchaseordercreateddatefilter_Internalname ;
      private string lblLblpurchaseordercreateddatefilter_Jsonclick ;
      private string edtavCpurchaseordercreateddate_Internalname ;
      private string edtavCpurchaseordercreateddate_Jsonclick ;
      private string divPurchaseordermodifieddatefiltercontainer_Internalname ;
      private string lblLblpurchaseordermodifieddatefilter_Internalname ;
      private string lblLblpurchaseordermodifieddatefilter_Jsonclick ;
      private string edtavCpurchaseordermodifieddate_Internalname ;
      private string edtavCpurchaseordermodifieddate_Jsonclick ;
      private string divPurchaseordercloseddatefiltercontainer_Internalname ;
      private string lblLblpurchaseordercloseddatefilter_Internalname ;
      private string lblLblpurchaseordercloseddatefilter_Jsonclick ;
      private string edtavCpurchaseordercloseddate_Internalname ;
      private string edtavCpurchaseordercloseddate_Jsonclick ;
      private string divPurchaseordertotalpaidfiltercontainer_Internalname ;
      private string lblLblpurchaseordertotalpaidfilter_Internalname ;
      private string lblLblpurchaseordertotalpaidfilter_Jsonclick ;
      private string edtavCpurchaseordertotalpaid_Internalname ;
      private string edtavCpurchaseordertotalpaid_Jsonclick ;
      private string divPurchaseorderactivefiltercontainer_Internalname ;
      private string lblLblpurchaseorderactivefilter_Internalname ;
      private string lblLblpurchaseorderactivefilter_Jsonclick ;
      private string chkavCpurchaseorderactive_Internalname ;
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
      private string edtPurchaseOrderId_Internalname ;
      private string edtSupplierId_Internalname ;
      private string edtPurchaseOrderCreatedDate_Internalname ;
      private string edtPurchaseOrderModifiedDate_Internalname ;
      private string edtPurchaseOrderClosedDate_Internalname ;
      private string scmdbuf ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtPurchaseOrderId_Jsonclick ;
      private string edtSupplierId_Jsonclick ;
      private string edtPurchaseOrderCreatedDate_Link ;
      private string edtPurchaseOrderCreatedDate_Jsonclick ;
      private string edtPurchaseOrderModifiedDate_Jsonclick ;
      private string edtPurchaseOrderClosedDate_Jsonclick ;
      private string subGrid1_Header ;
      private DateTime AV8cPurchaseOrderCreatedDate ;
      private DateTime AV9cPurchaseOrderModifiedDate ;
      private DateTime AV10cPurchaseOrderClosedDate ;
      private DateTime A52PurchaseOrderCreatedDate ;
      private DateTime A53PurchaseOrderModifiedDate ;
      private DateTime A66PurchaseOrderClosedDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV12cPurchaseOrderActive ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool n53PurchaseOrderModifiedDate ;
      private bool n66PurchaseOrderClosedDate ;
      private bool gxdyncontrolsrefreshing ;
      private bool A79PurchaseOrderActive ;
      private bool n78PurchaseOrderTotalPaid ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV17Linkselection_GXI ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavCpurchaseorderactive ;
      private IDataStoreProvider pr_default ;
      private bool[] H002H2_A79PurchaseOrderActive ;
      private decimal[] H002H2_A78PurchaseOrderTotalPaid ;
      private bool[] H002H2_n78PurchaseOrderTotalPaid ;
      private DateTime[] H002H2_A66PurchaseOrderClosedDate ;
      private bool[] H002H2_n66PurchaseOrderClosedDate ;
      private DateTime[] H002H2_A53PurchaseOrderModifiedDate ;
      private bool[] H002H2_n53PurchaseOrderModifiedDate ;
      private DateTime[] H002H2_A52PurchaseOrderCreatedDate ;
      private int[] H002H2_A4SupplierId ;
      private int[] H002H2_A50PurchaseOrderId ;
      private long[] H002H3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private int aP0_pPurchaseOrderId ;
      private GXWebForm Form ;
   }

   public class gx00a0__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002H2( IGxContext context ,
                                             int AV7cSupplierId ,
                                             DateTime AV8cPurchaseOrderCreatedDate ,
                                             DateTime AV9cPurchaseOrderModifiedDate ,
                                             DateTime AV10cPurchaseOrderClosedDate ,
                                             decimal AV11cPurchaseOrderTotalPaid ,
                                             bool AV12cPurchaseOrderActive ,
                                             int A4SupplierId ,
                                             DateTime A52PurchaseOrderCreatedDate ,
                                             DateTime A53PurchaseOrderModifiedDate ,
                                             DateTime A66PurchaseOrderClosedDate ,
                                             decimal A78PurchaseOrderTotalPaid ,
                                             bool A79PurchaseOrderActive ,
                                             int AV6cPurchaseOrderId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [PurchaseOrderActive], [PurchaseOrderTotalPaid], [PurchaseOrderClosedDate], [PurchaseOrderModifiedDate], [PurchaseOrderCreatedDate], [SupplierId], [PurchaseOrderId]";
         sFromString = " FROM [PurchaseOrder]";
         sOrderString = "";
         AddWhere(sWhereString, "([PurchaseOrderId] >= @AV6cPurchaseOrderId)");
         if ( ! (0==AV7cSupplierId) )
         {
            AddWhere(sWhereString, "([SupplierId] >= @AV7cSupplierId)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV8cPurchaseOrderCreatedDate) )
         {
            AddWhere(sWhereString, "([PurchaseOrderCreatedDate] >= @AV8cPurchaseOrderCreatedDate)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV9cPurchaseOrderModifiedDate) )
         {
            AddWhere(sWhereString, "([PurchaseOrderModifiedDate] >= @AV9cPurchaseOrderModifiedDate)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV10cPurchaseOrderClosedDate) )
         {
            AddWhere(sWhereString, "([PurchaseOrderClosedDate] >= @AV10cPurchaseOrderClosedDate)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV11cPurchaseOrderTotalPaid) )
         {
            AddWhere(sWhereString, "([PurchaseOrderTotalPaid] >= @AV11cPurchaseOrderTotalPaid)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (false==AV12cPurchaseOrderActive) )
         {
            AddWhere(sWhereString, "([PurchaseOrderActive] >= @AV12cPurchaseOrderActive)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [PurchaseOrderId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H002H3( IGxContext context ,
                                             int AV7cSupplierId ,
                                             DateTime AV8cPurchaseOrderCreatedDate ,
                                             DateTime AV9cPurchaseOrderModifiedDate ,
                                             DateTime AV10cPurchaseOrderClosedDate ,
                                             decimal AV11cPurchaseOrderTotalPaid ,
                                             bool AV12cPurchaseOrderActive ,
                                             int A4SupplierId ,
                                             DateTime A52PurchaseOrderCreatedDate ,
                                             DateTime A53PurchaseOrderModifiedDate ,
                                             DateTime A66PurchaseOrderClosedDate ,
                                             decimal A78PurchaseOrderTotalPaid ,
                                             bool A79PurchaseOrderActive ,
                                             int AV6cPurchaseOrderId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [PurchaseOrder]";
         AddWhere(sWhereString, "([PurchaseOrderId] >= @AV6cPurchaseOrderId)");
         if ( ! (0==AV7cSupplierId) )
         {
            AddWhere(sWhereString, "([SupplierId] >= @AV7cSupplierId)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV8cPurchaseOrderCreatedDate) )
         {
            AddWhere(sWhereString, "([PurchaseOrderCreatedDate] >= @AV8cPurchaseOrderCreatedDate)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV9cPurchaseOrderModifiedDate) )
         {
            AddWhere(sWhereString, "([PurchaseOrderModifiedDate] >= @AV9cPurchaseOrderModifiedDate)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV10cPurchaseOrderClosedDate) )
         {
            AddWhere(sWhereString, "([PurchaseOrderClosedDate] >= @AV10cPurchaseOrderClosedDate)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV11cPurchaseOrderTotalPaid) )
         {
            AddWhere(sWhereString, "([PurchaseOrderTotalPaid] >= @AV11cPurchaseOrderTotalPaid)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (false==AV12cPurchaseOrderActive) )
         {
            AddWhere(sWhereString, "([PurchaseOrderActive] >= @AV12cPurchaseOrderActive)");
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
                     return conditional_H002H2(context, (int)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (decimal)dynConstraints[4] , (bool)dynConstraints[5] , (int)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (decimal)dynConstraints[10] , (bool)dynConstraints[11] , (int)dynConstraints[12] );
               case 1 :
                     return conditional_H002H3(context, (int)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (decimal)dynConstraints[4] , (bool)dynConstraints[5] , (int)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (decimal)dynConstraints[10] , (bool)dynConstraints[11] , (int)dynConstraints[12] );
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
          Object[] prmH002H2;
          prmH002H2 = new Object[] {
          new ParDef("@AV6cPurchaseOrderId",GXType.Int32,6,0) ,
          new ParDef("@AV7cSupplierId",GXType.Int32,6,0) ,
          new ParDef("@AV8cPurchaseOrderCreatedDate",GXType.Date,8,0) ,
          new ParDef("@AV9cPurchaseOrderModifiedDate",GXType.Date,8,0) ,
          new ParDef("@AV10cPurchaseOrderClosedDate",GXType.Date,8,0) ,
          new ParDef("@AV11cPurchaseOrderTotalPaid",GXType.Decimal,18,2) ,
          new ParDef("@AV12cPurchaseOrderActive",GXType.Boolean,4,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH002H3;
          prmH002H3 = new Object[] {
          new ParDef("@AV6cPurchaseOrderId",GXType.Int32,6,0) ,
          new ParDef("@AV7cSupplierId",GXType.Int32,6,0) ,
          new ParDef("@AV8cPurchaseOrderCreatedDate",GXType.Date,8,0) ,
          new ParDef("@AV9cPurchaseOrderModifiedDate",GXType.Date,8,0) ,
          new ParDef("@AV10cPurchaseOrderClosedDate",GXType.Date,8,0) ,
          new ParDef("@AV11cPurchaseOrderTotalPaid",GXType.Decimal,18,2) ,
          new ParDef("@AV12cPurchaseOrderActive",GXType.Boolean,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002H2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002H2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H002H3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002H3,1, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(5);
                ((int[]) buf[8])[0] = rslt.getInt(6);
                ((int[]) buf[9])[0] = rslt.getInt(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
