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
   public class wppurchaseorderdetails : GXDataArea
   {
      public wppurchaseorderdetails( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public wppurchaseorderdetails( IGxContext context )
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

      protected override void createObjects( )
      {
         chkavIsowed = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Griddetails") == 0 )
            {
               gxnrGriddetails_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Griddetails") == 0 )
            {
               gxgrGriddetails_refresh_invoke( ) ;
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
               A50PurchaseOrderId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A50PurchaseOrderId", StringUtil.LTrimStr( (decimal)(A50PurchaseOrderId), 6, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_PURCHASEORDERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A50PurchaseOrderId), "ZZZZZ9"), context));
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

      protected void gxnrGriddetails_newrow_invoke( )
      {
         nRC_GXsfl_38 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_38"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_38_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_38_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_38_idx = GetPar( "sGXsfl_38_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGriddetails_newrow( ) ;
         /* End function gxnrGriddetails_newrow_invoke */
      }

      protected void gxgrGriddetails_refresh_invoke( )
      {
         subGriddetails_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGriddetails_Rows"), "."), 18, MidpointRounding.ToEven));
         A50PurchaseOrderId = (int)(Math.Round(NumberUtil.Val( GetPar( "PurchaseOrderId"), "."), 18, MidpointRounding.ToEven));
         AV14IsOwed = StringUtil.StrToBool( GetPar( "IsOwed"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGriddetails_refresh( subGriddetails_Rows, A50PurchaseOrderId, AV14IsOwed) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGriddetails_refresh_invoke */
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
         PA2N2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2N2( ) ;
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
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wppurchaseorderdetails.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A50PurchaseOrderId,6,0))}, new string[] {"PurchaseOrderId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "PURCHASEORDERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A50PurchaseOrderId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_PURCHASEORDERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A50PurchaseOrderId), "ZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_38", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_38), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PURCHASEORDERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A50PurchaseOrderId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_PURCHASEORDERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A50PurchaseOrderId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "GRIDDETAILS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDDETAILS_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDDETAILS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDDETAILS_nEOF), 1, 0, ".", "")));
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
            WE2N2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2N2( ) ;
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
         return formatLink("wppurchaseorderdetails.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A50PurchaseOrderId,6,0))}, new string[] {"PurchaseOrderId"})  ;
      }

      public override string GetPgmname( )
      {
         return "WPPurchaseOrderDetails" ;
      }

      public override string GetPgmdesc( )
      {
         return "Details" ;
      }

      protected void WB2N0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttVoucher_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(38), 2, 0)+","+"null"+");", "Voucher", bttVoucher_Jsonclick, 7, "Voucher", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e112n1_client"+"'", TempTags, "", 2, "HLP_WPPurchaseOrderDetails.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4 col-sm-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPurchaseOrderCreatedDate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtPurchaseOrderCreatedDate_Internalname, "Created", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtPurchaseOrderCreatedDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtPurchaseOrderCreatedDate_Internalname, context.localUtil.Format(A52PurchaseOrderCreatedDate, "99/99/99"), context.localUtil.Format( A52PurchaseOrderCreatedDate, "99/99/99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPurchaseOrderCreatedDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPurchaseOrderCreatedDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "PurchaseOrderDate", "right", false, "", "HLP_WPPurchaseOrderDetails.htm");
            GxWebStd.gx_bitmap( context, edtPurchaseOrderCreatedDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPurchaseOrderCreatedDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WPPurchaseOrderDetails.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4 col-sm-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtPurchaseOrderClosedDate_Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPurchaseOrderClosedDate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtPurchaseOrderClosedDate_Internalname, "Closed", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtPurchaseOrderClosedDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtPurchaseOrderClosedDate_Internalname, context.localUtil.Format(A66PurchaseOrderClosedDate, "99/99/99"), context.localUtil.Format( A66PurchaseOrderClosedDate, "99/99/99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPurchaseOrderClosedDate_Jsonclick, 0, "Attribute", "", "", "", "", edtPurchaseOrderClosedDate_Visible, edtPurchaseOrderClosedDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "PurchaseOrderDate", "right", false, "", "HLP_WPPurchaseOrderDetails.htm");
            GxWebStd.gx_bitmap( context, edtPurchaseOrderClosedDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((edtPurchaseOrderClosedDate_Visible==0)||(edtPurchaseOrderClosedDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WPPurchaseOrderDetails.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4 col-sm-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavPurhcaseorderstate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPurhcaseorderstate_Internalname, "State", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'" + sGXsfl_38_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPurhcaseorderstate_Internalname, AV13PurhcaseOrderState, StringUtil.RTrim( context.localUtil.Format( AV13PurhcaseOrderState, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPurhcaseorderstate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavPurhcaseorderstate_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_WPPurchaseOrderDetails.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4 col-sm-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", chkavIsowed.Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavIsowed_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavIsowed_Internalname, "Owed", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'" + sGXsfl_38_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavIsowed_Internalname, StringUtil.BoolToStr( AV14IsOwed), "", "Owed", chkavIsowed.Visible, chkavIsowed.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(25, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,25);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4 col-sm-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtPurchaseOrderTotalPaid_Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPurchaseOrderTotalPaid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtPurchaseOrderTotalPaid_Internalname, "Total Paid", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtPurchaseOrderTotalPaid_Internalname, StringUtil.LTrim( StringUtil.NToC( A78PurchaseOrderTotalPaid, 18, 2, ".", "")), StringUtil.LTrim( ((edtPurchaseOrderTotalPaid_Enabled!=0) ? context.localUtil.Format( A78PurchaseOrderTotalPaid, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A78PurchaseOrderTotalPaid, "ZZZZZZZZZZZZZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPurchaseOrderTotalPaid_Jsonclick, 0, "Attribute", "", "", "", "", edtPurchaseOrderTotalPaid_Visible, edtPurchaseOrderTotalPaid_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Price", "right", false, "", "HLP_WPPurchaseOrderDetails.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4 col-sm-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavPurchaseordertotalprojected_Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavPurchaseordertotalprojected_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPurchaseordertotalprojected_Internalname, "Total Projected", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'" + sGXsfl_38_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPurchaseordertotalprojected_Internalname, StringUtil.LTrim( StringUtil.NToC( AV10PurchaseOrderTotalProjected, 18, 2, ".", "")), StringUtil.LTrim( ((edtavPurchaseordertotalprojected_Enabled!=0) ? context.localUtil.Format( AV10PurchaseOrderTotalProjected, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV10PurchaseOrderTotalProjected, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPurchaseordertotalprojected_Jsonclick, 0, "Attribute", "", "", "", "", edtavPurchaseordertotalprojected_Visible, edtavPurchaseordertotalprojected_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Price", "right", false, "", "HLP_WPPurchaseOrderDetails.htm");
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
            /*  Grid Control  */
            GriddetailsContainer.SetWrapped(nGXWrapped);
            StartGridControl38( ) ;
         }
         if ( wbEnd == 38 )
         {
            wbEnd = 0;
            nRC_GXsfl_38 = (int)(nGXsfl_38_idx-1);
            if ( GriddetailsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GriddetailsContainer.AddObjectProperty("GRIDDETAILS_nEOF", GRIDDETAILS_nEOF);
               GriddetailsContainer.AddObjectProperty("GRIDDETAILS_nFirstRecordOnPage", GRIDDETAILS_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GriddetailsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Griddetails", GriddetailsContainer, subGriddetails_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GriddetailsContainerData", GriddetailsContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GriddetailsContainerData"+"V", GriddetailsContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GriddetailsContainerData"+"V"+"\" value='"+GriddetailsContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 38 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GriddetailsContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  GriddetailsContainer.AddObjectProperty("GRIDDETAILS_nEOF", GRIDDETAILS_nEOF);
                  GriddetailsContainer.AddObjectProperty("GRIDDETAILS_nFirstRecordOnPage", GRIDDETAILS_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GriddetailsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Griddetails", GriddetailsContainer, subGriddetails_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GriddetailsContainerData", GriddetailsContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GriddetailsContainerData"+"V", GriddetailsContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GriddetailsContainerData"+"V"+"\" value='"+GriddetailsContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START2N2( )
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
            Form.Meta.addItem("description", "Details", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2N0( ) ;
      }

      protected void WS2N2( )
      {
         START2N2( ) ;
         EVT2N2( ) ;
      }

      protected void EVT2N2( )
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
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDDETAILSPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRIDDETAILSPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgriddetails_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgriddetails_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgriddetails_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgriddetails_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "GRIDDETAILS.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 16), "GRIDDETAILS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_38_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
                              SubsflControlProps_382( ) ;
                              A15ProductId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtProductId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A55ProductCode = cgiGet( edtProductCode_Internalname);
                              n55ProductCode = false;
                              A16ProductName = cgiGet( edtProductName_Internalname);
                              A17ProductStock = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtProductStock_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              n17ProductStock = false;
                              A69ProductMiniumStock = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtProductMiniumStock_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              n69ProductMiniumStock = false;
                              A76PurchaseOrderDetailQuantityOrd = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPurchaseOrderDetailQuantityOrd_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A85ProductCostPrice = context.localUtil.CToN( cgiGet( edtProductCostPrice_Internalname), ".", ",");
                              n85ProductCostPrice = false;
                              A77PurchaseOrderDetailQuantityRec = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPurchaseOrderDetailQuantityRec_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A134PurchaseOrderDetailSuggestedPr = context.localUtil.CToN( cgiGet( edtPurchaseOrderDetailSuggestedPr_Internalname), ".", ",");
                              n134PurchaseOrderDetailSuggestedPr = false;
                              AV9PurchaseOrderDetailSubtotal = context.localUtil.CToN( cgiGet( edtavPurchaseorderdetailsubtotal_Internalname), ".", ",");
                              AssignAttri("", false, edtavPurchaseorderdetailsubtotal_Internalname, StringUtil.LTrimStr( AV9PurchaseOrderDetailSubtotal, 15, 2));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E122N2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDDETAILS.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E132N2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDDETAILS.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E142N2 ();
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

      protected void WE2N2( )
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

      protected void PA2N2( )
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
               GX_FocusControl = edtavPurhcaseorderstate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGriddetails_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_382( ) ;
         while ( nGXsfl_38_idx <= nRC_GXsfl_38 )
         {
            sendrow_382( ) ;
            nGXsfl_38_idx = ((subGriddetails_Islastpage==1)&&(nGXsfl_38_idx+1>subGriddetails_fnc_Recordsperpage( )) ? 1 : nGXsfl_38_idx+1);
            sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
            SubsflControlProps_382( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GriddetailsContainer)) ;
         /* End function gxnrGriddetails_newrow */
      }

      protected void gxgrGriddetails_refresh( int subGriddetails_Rows ,
                                              int A50PurchaseOrderId ,
                                              bool AV14IsOwed )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDDETAILS_nCurrentRecord = 0;
         RF2N2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGriddetails_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PURCHASEORDERDETAILQUANTITYREC", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A77PurchaseOrderDetailQuantityRec), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "PURCHASEORDERDETAILQUANTITYREC", StringUtil.LTrim( StringUtil.NToC( (decimal)(A77PurchaseOrderDetailQuantityRec), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_PURCHASEORDERDETAILQUANTITYORD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A76PurchaseOrderDetailQuantityOrd), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "PURCHASEORDERDETAILQUANTITYORD", StringUtil.LTrim( StringUtil.NToC( (decimal)(A76PurchaseOrderDetailQuantityOrd), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_PURCHASEORDERDETAILSUGGESTEDPR", GetSecureSignedToken( "", context.localUtil.Format( A134PurchaseOrderDetailSuggestedPr, "ZZZZZZZZZZZZZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "PURCHASEORDERDETAILSUGGESTEDPR", StringUtil.LTrim( StringUtil.NToC( A134PurchaseOrderDetailSuggestedPr, 18, 2, ".", "")));
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
         AV14IsOwed = StringUtil.StrToBool( StringUtil.BoolToStr( AV14IsOwed));
         AssignAttri("", false, "AV14IsOwed", AV14IsOwed);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF2N2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavPurhcaseorderstate_Enabled = 0;
         AssignProp("", false, edtavPurhcaseorderstate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPurhcaseorderstate_Enabled), 5, 0), true);
         chkavIsowed.Enabled = 0;
         AssignProp("", false, chkavIsowed_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavIsowed.Enabled), 5, 0), true);
         edtavPurchaseordertotalprojected_Enabled = 0;
         AssignProp("", false, edtavPurchaseordertotalprojected_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPurchaseordertotalprojected_Enabled), 5, 0), true);
         edtavPurchaseorderdetailsubtotal_Enabled = 0;
         AssignProp("", false, edtavPurchaseorderdetailsubtotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPurchaseorderdetailsubtotal_Enabled), 5, 0), !bGXsfl_38_Refreshing);
      }

      protected void RF2N2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GriddetailsContainer.ClearRows();
         }
         wbStart = 38;
         E132N2 ();
         nGXsfl_38_idx = 1;
         sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
         SubsflControlProps_382( ) ;
         bGXsfl_38_Refreshing = true;
         GriddetailsContainer.AddObjectProperty("GridName", "Griddetails");
         GriddetailsContainer.AddObjectProperty("CmpContext", "");
         GriddetailsContainer.AddObjectProperty("InMasterPage", "false");
         GriddetailsContainer.AddObjectProperty("Class", "PromptGrid");
         GriddetailsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GriddetailsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GriddetailsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddetails_Backcolorstyle), 1, 0, ".", "")));
         GriddetailsContainer.PageSize = subGriddetails_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_382( ) ;
            GXPagingFrom2 = (int)(GRIDDETAILS_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGriddetails_fnc_Recordsperpage( )+1);
            /* Using cursor H002N2 */
            pr_default.execute(0, new Object[] {A50PurchaseOrderId, GXPagingFrom2, GXPagingTo2});
            nGXsfl_38_idx = 1;
            sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
            SubsflControlProps_382( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRIDDETAILS_nCurrentRecord < subGriddetails_fnc_Recordsperpage( ) ) ) )
            {
               A134PurchaseOrderDetailSuggestedPr = H002N2_A134PurchaseOrderDetailSuggestedPr[0];
               n134PurchaseOrderDetailSuggestedPr = H002N2_n134PurchaseOrderDetailSuggestedPr[0];
               A77PurchaseOrderDetailQuantityRec = H002N2_A77PurchaseOrderDetailQuantityRec[0];
               A85ProductCostPrice = H002N2_A85ProductCostPrice[0];
               n85ProductCostPrice = H002N2_n85ProductCostPrice[0];
               A76PurchaseOrderDetailQuantityOrd = H002N2_A76PurchaseOrderDetailQuantityOrd[0];
               A69ProductMiniumStock = H002N2_A69ProductMiniumStock[0];
               n69ProductMiniumStock = H002N2_n69ProductMiniumStock[0];
               A17ProductStock = H002N2_A17ProductStock[0];
               n17ProductStock = H002N2_n17ProductStock[0];
               A16ProductName = H002N2_A16ProductName[0];
               A55ProductCode = H002N2_A55ProductCode[0];
               n55ProductCode = H002N2_n55ProductCode[0];
               A15ProductId = H002N2_A15ProductId[0];
               A85ProductCostPrice = H002N2_A85ProductCostPrice[0];
               n85ProductCostPrice = H002N2_n85ProductCostPrice[0];
               A69ProductMiniumStock = H002N2_A69ProductMiniumStock[0];
               n69ProductMiniumStock = H002N2_n69ProductMiniumStock[0];
               A17ProductStock = H002N2_A17ProductStock[0];
               n17ProductStock = H002N2_n17ProductStock[0];
               A16ProductName = H002N2_A16ProductName[0];
               A55ProductCode = H002N2_A55ProductCode[0];
               n55ProductCode = H002N2_n55ProductCode[0];
               E142N2 ();
               pr_default.readNext(0);
            }
            GRIDDETAILS_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRIDDETAILS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDDETAILS_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 38;
            WB2N0( ) ;
         }
         bGXsfl_38_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2N2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PURCHASEORDERDETAILQUANTITYREC"+"_"+sGXsfl_38_idx, GetSecureSignedToken( sGXsfl_38_idx, context.localUtil.Format( (decimal)(A77PurchaseOrderDetailQuantityRec), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_PURCHASEORDERDETAILQUANTITYORD"+"_"+sGXsfl_38_idx, GetSecureSignedToken( sGXsfl_38_idx, context.localUtil.Format( (decimal)(A76PurchaseOrderDetailQuantityOrd), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_PURCHASEORDERDETAILSUGGESTEDPR"+"_"+sGXsfl_38_idx, GetSecureSignedToken( sGXsfl_38_idx, context.localUtil.Format( A134PurchaseOrderDetailSuggestedPr, "ZZZZZZZZZZZZZZ9.99"), context));
      }

      protected int subGriddetails_fnc_Pagecount( )
      {
         GRIDDETAILS_nRecordCount = subGriddetails_fnc_Recordcount( );
         if ( ((int)((GRIDDETAILS_nRecordCount) % (subGriddetails_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRIDDETAILS_nRecordCount/ (decimal)(subGriddetails_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDDETAILS_nRecordCount/ (decimal)(subGriddetails_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGriddetails_fnc_Recordcount( )
      {
         /* Using cursor H002N3 */
         pr_default.execute(1, new Object[] {A50PurchaseOrderId});
         GRIDDETAILS_nRecordCount = H002N3_AGRIDDETAILS_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRIDDETAILS_nRecordCount) ;
      }

      protected int subGriddetails_fnc_Recordsperpage( )
      {
         return (int)(5*1) ;
      }

      protected int subGriddetails_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDDETAILS_nFirstRecordOnPage/ (decimal)(subGriddetails_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgriddetails_firstpage( )
      {
         GRIDDETAILS_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRIDDETAILS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDDETAILS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGriddetails_refresh( subGriddetails_Rows, A50PurchaseOrderId, AV14IsOwed) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgriddetails_nextpage( )
      {
         GRIDDETAILS_nRecordCount = subGriddetails_fnc_Recordcount( );
         if ( ( GRIDDETAILS_nRecordCount >= subGriddetails_fnc_Recordsperpage( ) ) && ( GRIDDETAILS_nEOF == 0 ) )
         {
            GRIDDETAILS_nFirstRecordOnPage = (long)(GRIDDETAILS_nFirstRecordOnPage+subGriddetails_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDDETAILS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDDETAILS_nFirstRecordOnPage), 15, 0, ".", "")));
         GriddetailsContainer.AddObjectProperty("GRIDDETAILS_nFirstRecordOnPage", GRIDDETAILS_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGriddetails_refresh( subGriddetails_Rows, A50PurchaseOrderId, AV14IsOwed) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRIDDETAILS_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgriddetails_previouspage( )
      {
         if ( GRIDDETAILS_nFirstRecordOnPage >= subGriddetails_fnc_Recordsperpage( ) )
         {
            GRIDDETAILS_nFirstRecordOnPage = (long)(GRIDDETAILS_nFirstRecordOnPage-subGriddetails_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDDETAILS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDDETAILS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGriddetails_refresh( subGriddetails_Rows, A50PurchaseOrderId, AV14IsOwed) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgriddetails_lastpage( )
      {
         GRIDDETAILS_nRecordCount = subGriddetails_fnc_Recordcount( );
         if ( GRIDDETAILS_nRecordCount > subGriddetails_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRIDDETAILS_nRecordCount) % (subGriddetails_fnc_Recordsperpage( )))) == 0 )
            {
               GRIDDETAILS_nFirstRecordOnPage = (long)(GRIDDETAILS_nRecordCount-subGriddetails_fnc_Recordsperpage( ));
            }
            else
            {
               GRIDDETAILS_nFirstRecordOnPage = (long)(GRIDDETAILS_nRecordCount-((int)((GRIDDETAILS_nRecordCount) % (subGriddetails_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRIDDETAILS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDDETAILS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDDETAILS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGriddetails_refresh( subGriddetails_Rows, A50PurchaseOrderId, AV14IsOwed) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgriddetails_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRIDDETAILS_nFirstRecordOnPage = (long)(subGriddetails_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRIDDETAILS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDDETAILS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDDETAILS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGriddetails_refresh( subGriddetails_Rows, A50PurchaseOrderId, AV14IsOwed) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavPurhcaseorderstate_Enabled = 0;
         AssignProp("", false, edtavPurhcaseorderstate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPurhcaseorderstate_Enabled), 5, 0), true);
         chkavIsowed.Enabled = 0;
         AssignProp("", false, chkavIsowed_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavIsowed.Enabled), 5, 0), true);
         edtavPurchaseordertotalprojected_Enabled = 0;
         AssignProp("", false, edtavPurchaseordertotalprojected_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPurchaseordertotalprojected_Enabled), 5, 0), true);
         edtavPurchaseorderdetailsubtotal_Enabled = 0;
         AssignProp("", false, edtavPurchaseorderdetailsubtotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPurchaseorderdetailsubtotal_Enabled), 5, 0), !bGXsfl_38_Refreshing);
         /* Using cursor H002N4 */
         pr_default.execute(2, new Object[] {A50PurchaseOrderId});
         A79PurchaseOrderActive = H002N4_A79PurchaseOrderActive[0];
         A138PurchaseOrderWasPaid = H002N4_A138PurchaseOrderWasPaid[0];
         n138PurchaseOrderWasPaid = H002N4_n138PurchaseOrderWasPaid[0];
         A52PurchaseOrderCreatedDate = H002N4_A52PurchaseOrderCreatedDate[0];
         AssignAttri("", false, "A52PurchaseOrderCreatedDate", context.localUtil.Format(A52PurchaseOrderCreatedDate, "99/99/99"));
         A66PurchaseOrderClosedDate = H002N4_A66PurchaseOrderClosedDate[0];
         n66PurchaseOrderClosedDate = H002N4_n66PurchaseOrderClosedDate[0];
         AssignAttri("", false, "A66PurchaseOrderClosedDate", context.localUtil.Format(A66PurchaseOrderClosedDate, "99/99/99"));
         A78PurchaseOrderTotalPaid = H002N4_A78PurchaseOrderTotalPaid[0];
         n78PurchaseOrderTotalPaid = H002N4_n78PurchaseOrderTotalPaid[0];
         AssignAttri("", false, "A78PurchaseOrderTotalPaid", StringUtil.LTrimStr( A78PurchaseOrderTotalPaid, 18, 2));
         pr_default.close(2);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2N0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E122N2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_38 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_38"), ".", ","), 18, MidpointRounding.ToEven));
            A50PurchaseOrderId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PURCHASEORDERID"), ".", ","), 18, MidpointRounding.ToEven));
            GRIDDETAILS_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDDETAILS_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRIDDETAILS_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDDETAILS_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            A52PurchaseOrderCreatedDate = context.localUtil.CToD( cgiGet( edtPurchaseOrderCreatedDate_Internalname), 1);
            AssignAttri("", false, "A52PurchaseOrderCreatedDate", context.localUtil.Format(A52PurchaseOrderCreatedDate, "99/99/99"));
            A66PurchaseOrderClosedDate = context.localUtil.CToD( cgiGet( edtPurchaseOrderClosedDate_Internalname), 1);
            n66PurchaseOrderClosedDate = false;
            AssignAttri("", false, "A66PurchaseOrderClosedDate", context.localUtil.Format(A66PurchaseOrderClosedDate, "99/99/99"));
            AV13PurhcaseOrderState = cgiGet( edtavPurhcaseorderstate_Internalname);
            AssignAttri("", false, "AV13PurhcaseOrderState", AV13PurhcaseOrderState);
            AV14IsOwed = StringUtil.StrToBool( cgiGet( chkavIsowed_Internalname));
            AssignAttri("", false, "AV14IsOwed", AV14IsOwed);
            A78PurchaseOrderTotalPaid = context.localUtil.CToN( cgiGet( edtPurchaseOrderTotalPaid_Internalname), ".", ",");
            n78PurchaseOrderTotalPaid = false;
            AssignAttri("", false, "A78PurchaseOrderTotalPaid", StringUtil.LTrimStr( A78PurchaseOrderTotalPaid, 18, 2));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPurchaseordertotalprojected_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPurchaseordertotalprojected_Internalname), ".", ",") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPURCHASEORDERTOTALPROJECTED");
               GX_FocusControl = edtavPurchaseordertotalprojected_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10PurchaseOrderTotalProjected = 0;
               AssignAttri("", false, "AV10PurchaseOrderTotalProjected", StringUtil.LTrimStr( AV10PurchaseOrderTotalProjected, 18, 2));
            }
            else
            {
               AV10PurchaseOrderTotalProjected = context.localUtil.CToN( cgiGet( edtavPurchaseordertotalprojected_Internalname), ".", ",");
               AssignAttri("", false, "AV10PurchaseOrderTotalProjected", StringUtil.LTrimStr( AV10PurchaseOrderTotalProjected, 18, 2));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E122N2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E122N2( )
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
         if ( ! A79PurchaseOrderActive )
         {
            AV13PurhcaseOrderState = "Canceled";
            AssignAttri("", false, "AV13PurhcaseOrderState", AV13PurhcaseOrderState);
         }
         else if ( A79PurchaseOrderActive && ( (DateTime.MinValue==A66PurchaseOrderClosedDate) || (DateTime.MinValue==A66PurchaseOrderClosedDate) || ( DateTimeUtil.ResetTime ( A66PurchaseOrderClosedDate ) == DateTimeUtil.ResetTime ( DateTime.MinValue ) ) || (DateTime.MinValue==A66PurchaseOrderClosedDate) ) )
         {
            AV13PurhcaseOrderState = "Pending";
            AssignAttri("", false, "AV13PurhcaseOrderState", AV13PurhcaseOrderState);
         }
         else if ( A79PurchaseOrderActive && ! ( (DateTime.MinValue==A66PurchaseOrderClosedDate) || (DateTime.MinValue==A66PurchaseOrderClosedDate) || ( DateTimeUtil.ResetTime ( A66PurchaseOrderClosedDate ) == DateTimeUtil.ResetTime ( DateTime.MinValue ) ) || (DateTime.MinValue==A66PurchaseOrderClosedDate) ) )
         {
            AV13PurhcaseOrderState = "Received";
            AssignAttri("", false, "AV13PurhcaseOrderState", AV13PurhcaseOrderState);
         }
         else
         {
            AV13PurhcaseOrderState = "";
            AssignAttri("", false, "AV13PurhcaseOrderState", AV13PurhcaseOrderState);
         }
         if ( StringUtil.StrCmp(AV13PurhcaseOrderState, "Canceled") == 0 )
         {
            edtavPurchaseordertotalprojected_Visible = 0;
            AssignProp("", false, edtavPurchaseordertotalprojected_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPurchaseordertotalprojected_Visible), 5, 0), true);
            edtPurchaseOrderTotalPaid_Visible = 0;
            AssignProp("", false, edtPurchaseOrderTotalPaid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderTotalPaid_Visible), 5, 0), true);
            edtPurchaseOrderClosedDate_Visible = 0;
            AssignProp("", false, edtPurchaseOrderClosedDate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderClosedDate_Visible), 5, 0), true);
            chkavIsowed.Visible = 0;
            AssignProp("", false, chkavIsowed_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavIsowed.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV13PurhcaseOrderState, "Pending") == 0 )
         {
            edtavPurchaseordertotalprojected_Visible = 1;
            AssignProp("", false, edtavPurchaseordertotalprojected_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPurchaseordertotalprojected_Visible), 5, 0), true);
            edtPurchaseOrderTotalPaid_Visible = 0;
            AssignProp("", false, edtPurchaseOrderTotalPaid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderTotalPaid_Visible), 5, 0), true);
            edtPurchaseOrderClosedDate_Visible = 0;
            AssignProp("", false, edtPurchaseOrderClosedDate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderClosedDate_Visible), 5, 0), true);
            chkavIsowed.Visible = 0;
            AssignProp("", false, chkavIsowed_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavIsowed.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV13PurhcaseOrderState, "Received") == 0 )
         {
            edtavPurchaseordertotalprojected_Visible = 0;
            AssignProp("", false, edtavPurchaseordertotalprojected_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavPurchaseordertotalprojected_Visible), 5, 0), true);
            edtPurchaseOrderClosedDate_Visible = 1;
            AssignProp("", false, edtPurchaseOrderClosedDate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderClosedDate_Visible), 5, 0), true);
            if ( A138PurchaseOrderWasPaid )
            {
               edtPurchaseOrderTotalPaid_Visible = 1;
               AssignProp("", false, edtPurchaseOrderTotalPaid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderTotalPaid_Visible), 5, 0), true);
               AV14IsOwed = false;
               AssignAttri("", false, "AV14IsOwed", AV14IsOwed);
               chkavIsowed.Visible = 0;
               AssignProp("", false, chkavIsowed_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavIsowed.Visible), 5, 0), true);
            }
            else
            {
               edtPurchaseOrderTotalPaid_Visible = 1;
               AssignProp("", false, edtPurchaseOrderTotalPaid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderTotalPaid_Visible), 5, 0), true);
               AV14IsOwed = true;
               AssignAttri("", false, "AV14IsOwed", AV14IsOwed);
               chkavIsowed.Visible = 1;
               AssignProp("", false, chkavIsowed_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavIsowed.Visible), 5, 0), true);
            }
         }
         else
         {
         }
      }

      protected void E132N2( )
      {
         /* Griddetails_Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CALCULATETOTAL' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      private void E142N2( )
      {
         /* Griddetails_Load Routine */
         returnInSub = false;
         AV11PurchaseOrderDetailQuantity = A77PurchaseOrderDetailQuantityRec;
         AV12PurchaseOrderDetailPrice = ((A134PurchaseOrderDetailSuggestedPr>Convert.ToDecimal(0)) ? A134PurchaseOrderDetailSuggestedPr : A85ProductCostPrice);
         AV9PurchaseOrderDetailSubtotal = (decimal)(AV11PurchaseOrderDetailQuantity*AV12PurchaseOrderDetailPrice);
         AssignAttri("", false, edtavPurchaseorderdetailsubtotal_Internalname, StringUtil.LTrimStr( AV9PurchaseOrderDetailSubtotal, 15, 2));
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 38;
         }
         sendrow_382( ) ;
         GRIDDETAILS_nCurrentRecord = (long)(GRIDDETAILS_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_38_Refreshing )
         {
            DoAjaxLoad(38, GriddetailsRow);
         }
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'CALCULATETOTAL' Routine */
         returnInSub = false;
         AV10PurchaseOrderTotalProjected = 0;
         AssignAttri("", false, "AV10PurchaseOrderTotalProjected", StringUtil.LTrimStr( AV10PurchaseOrderTotalProjected, 18, 2));
         /* Using cursor H002N5 */
         pr_default.execute(3, new Object[] {A50PurchaseOrderId});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A15ProductId = H002N5_A15ProductId[0];
            A76PurchaseOrderDetailQuantityOrd = H002N5_A76PurchaseOrderDetailQuantityOrd[0];
            A77PurchaseOrderDetailQuantityRec = H002N5_A77PurchaseOrderDetailQuantityRec[0];
            A85ProductCostPrice = H002N5_A85ProductCostPrice[0];
            n85ProductCostPrice = H002N5_n85ProductCostPrice[0];
            A134PurchaseOrderDetailSuggestedPr = H002N5_A134PurchaseOrderDetailSuggestedPr[0];
            n134PurchaseOrderDetailSuggestedPr = H002N5_n134PurchaseOrderDetailSuggestedPr[0];
            A85ProductCostPrice = H002N5_A85ProductCostPrice[0];
            n85ProductCostPrice = H002N5_n85ProductCostPrice[0];
            AV11PurchaseOrderDetailQuantity = ((A77PurchaseOrderDetailQuantityRec>0) ? A77PurchaseOrderDetailQuantityRec : A76PurchaseOrderDetailQuantityOrd);
            AV12PurchaseOrderDetailPrice = ((A134PurchaseOrderDetailSuggestedPr>Convert.ToDecimal(0)) ? A134PurchaseOrderDetailSuggestedPr : A85ProductCostPrice);
            AV10PurchaseOrderTotalProjected = (decimal)(AV10PurchaseOrderTotalProjected+(AV11PurchaseOrderDetailQuantity*AV12PurchaseOrderDetailPrice));
            AssignAttri("", false, "AV10PurchaseOrderTotalProjected", StringUtil.LTrimStr( AV10PurchaseOrderTotalProjected, 18, 2));
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A50PurchaseOrderId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "A50PurchaseOrderId", StringUtil.LTrimStr( (decimal)(A50PurchaseOrderId), 6, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_PURCHASEORDERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A50PurchaseOrderId), "ZZZZZ9"), context));
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
         PA2N2( ) ;
         WS2N2( ) ;
         WE2N2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20241291345271", true, true);
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
         context.AddJavascriptSource("wppurchaseorderdetails.js", "?20241291345271", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_382( )
      {
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_38_idx;
         edtProductCode_Internalname = "PRODUCTCODE_"+sGXsfl_38_idx;
         edtProductName_Internalname = "PRODUCTNAME_"+sGXsfl_38_idx;
         edtProductStock_Internalname = "PRODUCTSTOCK_"+sGXsfl_38_idx;
         edtProductMiniumStock_Internalname = "PRODUCTMINIUMSTOCK_"+sGXsfl_38_idx;
         edtPurchaseOrderDetailQuantityOrd_Internalname = "PURCHASEORDERDETAILQUANTITYORD_"+sGXsfl_38_idx;
         edtProductCostPrice_Internalname = "PRODUCTCOSTPRICE_"+sGXsfl_38_idx;
         edtPurchaseOrderDetailQuantityRec_Internalname = "PURCHASEORDERDETAILQUANTITYREC_"+sGXsfl_38_idx;
         edtPurchaseOrderDetailSuggestedPr_Internalname = "PURCHASEORDERDETAILSUGGESTEDPR_"+sGXsfl_38_idx;
         edtavPurchaseorderdetailsubtotal_Internalname = "vPURCHASEORDERDETAILSUBTOTAL_"+sGXsfl_38_idx;
      }

      protected void SubsflControlProps_fel_382( )
      {
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_38_fel_idx;
         edtProductCode_Internalname = "PRODUCTCODE_"+sGXsfl_38_fel_idx;
         edtProductName_Internalname = "PRODUCTNAME_"+sGXsfl_38_fel_idx;
         edtProductStock_Internalname = "PRODUCTSTOCK_"+sGXsfl_38_fel_idx;
         edtProductMiniumStock_Internalname = "PRODUCTMINIUMSTOCK_"+sGXsfl_38_fel_idx;
         edtPurchaseOrderDetailQuantityOrd_Internalname = "PURCHASEORDERDETAILQUANTITYORD_"+sGXsfl_38_fel_idx;
         edtProductCostPrice_Internalname = "PRODUCTCOSTPRICE_"+sGXsfl_38_fel_idx;
         edtPurchaseOrderDetailQuantityRec_Internalname = "PURCHASEORDERDETAILQUANTITYREC_"+sGXsfl_38_fel_idx;
         edtPurchaseOrderDetailSuggestedPr_Internalname = "PURCHASEORDERDETAILSUGGESTEDPR_"+sGXsfl_38_fel_idx;
         edtavPurchaseorderdetailsubtotal_Internalname = "vPURCHASEORDERDETAILSUBTOTAL_"+sGXsfl_38_fel_idx;
      }

      protected void sendrow_382( )
      {
         SubsflControlProps_382( ) ;
         WB2N0( ) ;
         if ( ( 5 * 1 == 0 ) || ( nGXsfl_38_idx <= subGriddetails_fnc_Recordsperpage( ) * 1 ) )
         {
            GriddetailsRow = GXWebRow.GetNew(context,GriddetailsContainer);
            if ( subGriddetails_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGriddetails_Backstyle = 0;
               if ( StringUtil.StrCmp(subGriddetails_Class, "") != 0 )
               {
                  subGriddetails_Linesclass = subGriddetails_Class+"Odd";
               }
            }
            else if ( subGriddetails_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGriddetails_Backstyle = 0;
               subGriddetails_Backcolor = subGriddetails_Allbackcolor;
               if ( StringUtil.StrCmp(subGriddetails_Class, "") != 0 )
               {
                  subGriddetails_Linesclass = subGriddetails_Class+"Uniform";
               }
            }
            else if ( subGriddetails_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGriddetails_Backstyle = 1;
               if ( StringUtil.StrCmp(subGriddetails_Class, "") != 0 )
               {
                  subGriddetails_Linesclass = subGriddetails_Class+"Odd";
               }
               subGriddetails_Backcolor = (int)(0x0);
            }
            else if ( subGriddetails_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGriddetails_Backstyle = 1;
               if ( ((int)((nGXsfl_38_idx) % (2))) == 0 )
               {
                  subGriddetails_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGriddetails_Class, "") != 0 )
                  {
                     subGriddetails_Linesclass = subGriddetails_Class+"Even";
                  }
               }
               else
               {
                  subGriddetails_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGriddetails_Class, "") != 0 )
                  {
                     subGriddetails_Linesclass = subGriddetails_Class+"Odd";
                  }
               }
            }
            if ( GriddetailsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"PromptGrid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_38_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GriddetailsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GriddetailsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A15ProductId), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GriddetailsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GriddetailsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductCode_Internalname,(string)A55ProductCode,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductCode_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusUnanimo\\Code",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GriddetailsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GriddetailsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductName_Internalname,(string)A16ProductName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GriddetailsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GriddetailsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductStock_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A17ProductStock), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A17ProductStock), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductStock_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)0,(bool)true,(string)"Stock",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GriddetailsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GriddetailsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductMiniumStock_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A69ProductMiniumStock), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A69ProductMiniumStock), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductMiniumStock_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)0,(bool)true,(string)"Stock",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GriddetailsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GriddetailsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPurchaseOrderDetailQuantityOrd_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A76PurchaseOrderDetailQuantityOrd), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A76PurchaseOrderDetailQuantityOrd), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPurchaseOrderDetailQuantityOrd_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GriddetailsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GriddetailsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductCostPrice_Internalname,StringUtil.LTrim( StringUtil.NToC( A85ProductCostPrice, 18, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A85ProductCostPrice, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductCostPrice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)0,(bool)true,(string)"Price",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GriddetailsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GriddetailsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPurchaseOrderDetailQuantityRec_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A77PurchaseOrderDetailQuantityRec), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A77PurchaseOrderDetailQuantityRec), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPurchaseOrderDetailQuantityRec_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GriddetailsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GriddetailsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPurchaseOrderDetailSuggestedPr_Internalname,StringUtil.LTrim( StringUtil.NToC( A134PurchaseOrderDetailSuggestedPr, 18, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A134PurchaseOrderDetailSuggestedPr, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPurchaseOrderDetailSuggestedPr_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)0,(bool)true,(string)"Price",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GriddetailsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GriddetailsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavPurchaseorderdetailsubtotal_Internalname,StringUtil.LTrim( StringUtil.NToC( AV9PurchaseOrderDetailSubtotal, 15, 2, ".", "")),StringUtil.LTrim( ((edtavPurchaseorderdetailsubtotal_Enabled!=0) ? context.localUtil.Format( AV9PurchaseOrderDetailSubtotal, "ZZZZZZZZZZZ9.99") : context.localUtil.Format( AV9PurchaseOrderDetailSubtotal, "ZZZZZZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavPurchaseorderdetailsubtotal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavPurchaseorderdetailsubtotal_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)15,(short)0,(short)0,(short)38,(short)0,(short)-1,(short)0,(bool)true,(string)"Subtotal",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes2N2( ) ;
            GriddetailsContainer.AddRow(GriddetailsRow);
            nGXsfl_38_idx = ((subGriddetails_Islastpage==1)&&(nGXsfl_38_idx+1>subGriddetails_fnc_Recordsperpage( )) ? 1 : nGXsfl_38_idx+1);
            sGXsfl_38_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_38_idx), 4, 0), 4, "0");
            SubsflControlProps_382( ) ;
         }
         /* End function sendrow_382 */
      }

      protected void init_web_controls( )
      {
         chkavIsowed.Name = "vISOWED";
         chkavIsowed.WebTags = "";
         chkavIsowed.Caption = "";
         AssignProp("", false, chkavIsowed_Internalname, "TitleCaption", chkavIsowed.Caption, true);
         chkavIsowed.CheckedValue = "false";
         AV14IsOwed = StringUtil.StrToBool( StringUtil.BoolToStr( AV14IsOwed));
         AssignAttri("", false, "AV14IsOwed", AV14IsOwed);
         /* End function init_web_controls */
      }

      protected void StartGridControl38( )
      {
         if ( GriddetailsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GriddetailsContainer"+"DivS\" data-gxgridid=\"38\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGriddetails_Internalname, subGriddetails_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGriddetails_Backcolorstyle == 0 )
            {
               subGriddetails_Titlebackstyle = 0;
               if ( StringUtil.Len( subGriddetails_Class) > 0 )
               {
                  subGriddetails_Linesclass = subGriddetails_Class+"Title";
               }
            }
            else
            {
               subGriddetails_Titlebackstyle = 1;
               if ( subGriddetails_Backcolorstyle == 1 )
               {
                  subGriddetails_Titlebackcolor = subGriddetails_Allbackcolor;
                  if ( StringUtil.Len( subGriddetails_Class) > 0 )
                  {
                     subGriddetails_Linesclass = subGriddetails_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGriddetails_Class) > 0 )
                  {
                     subGriddetails_Linesclass = subGriddetails_Class+"Title";
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
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Current Stock") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Min. Stock") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Qty. Ordered") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Cost Price") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Qty. Received") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Suggested Price") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Subtotal") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GriddetailsContainer.AddObjectProperty("GridName", "Griddetails");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GriddetailsContainer = new GXWebGrid( context);
            }
            else
            {
               GriddetailsContainer.Clear();
            }
            GriddetailsContainer.SetWrapped(nGXWrapped);
            GriddetailsContainer.AddObjectProperty("GridName", "Griddetails");
            GriddetailsContainer.AddObjectProperty("Header", subGriddetails_Header);
            GriddetailsContainer.AddObjectProperty("Class", "PromptGrid");
            GriddetailsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GriddetailsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GriddetailsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddetails_Backcolorstyle), 1, 0, ".", "")));
            GriddetailsContainer.AddObjectProperty("CmpContext", "");
            GriddetailsContainer.AddObjectProperty("InMasterPage", "false");
            GriddetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddetailsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", ""))));
            GriddetailsContainer.AddColumnProperties(GriddetailsColumn);
            GriddetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddetailsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A55ProductCode));
            GriddetailsContainer.AddColumnProperties(GriddetailsColumn);
            GriddetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddetailsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A16ProductName));
            GriddetailsContainer.AddColumnProperties(GriddetailsColumn);
            GriddetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddetailsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A17ProductStock), 6, 0, ".", ""))));
            GriddetailsContainer.AddColumnProperties(GriddetailsColumn);
            GriddetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddetailsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A69ProductMiniumStock), 6, 0, ".", ""))));
            GriddetailsContainer.AddColumnProperties(GriddetailsColumn);
            GriddetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddetailsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A76PurchaseOrderDetailQuantityOrd), 6, 0, ".", ""))));
            GriddetailsContainer.AddColumnProperties(GriddetailsColumn);
            GriddetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddetailsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A85ProductCostPrice, 18, 2, ".", ""))));
            GriddetailsContainer.AddColumnProperties(GriddetailsColumn);
            GriddetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddetailsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A77PurchaseOrderDetailQuantityRec), 6, 0, ".", ""))));
            GriddetailsContainer.AddColumnProperties(GriddetailsColumn);
            GriddetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddetailsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A134PurchaseOrderDetailSuggestedPr, 18, 2, ".", ""))));
            GriddetailsContainer.AddColumnProperties(GriddetailsColumn);
            GriddetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GriddetailsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( AV9PurchaseOrderDetailSubtotal, 15, 2, ".", ""))));
            GriddetailsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavPurchaseorderdetailsubtotal_Enabled), 5, 0, ".", "")));
            GriddetailsContainer.AddColumnProperties(GriddetailsColumn);
            GriddetailsContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddetails_Selectedindex), 4, 0, ".", "")));
            GriddetailsContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddetails_Allowselection), 1, 0, ".", "")));
            GriddetailsContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddetails_Selectioncolor), 9, 0, ".", "")));
            GriddetailsContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddetails_Allowhovering), 1, 0, ".", "")));
            GriddetailsContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddetails_Hoveringcolor), 9, 0, ".", "")));
            GriddetailsContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddetails_Allowcollapsing), 1, 0, ".", "")));
            GriddetailsContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGriddetails_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         bttVoucher_Internalname = "VOUCHER";
         edtPurchaseOrderCreatedDate_Internalname = "PURCHASEORDERCREATEDDATE";
         edtPurchaseOrderClosedDate_Internalname = "PURCHASEORDERCLOSEDDATE";
         edtavPurhcaseorderstate_Internalname = "vPURHCASEORDERSTATE";
         chkavIsowed_Internalname = "vISOWED";
         edtPurchaseOrderTotalPaid_Internalname = "PURCHASEORDERTOTALPAID";
         edtavPurchaseordertotalprojected_Internalname = "vPURCHASEORDERTOTALPROJECTED";
         edtProductId_Internalname = "PRODUCTID";
         edtProductCode_Internalname = "PRODUCTCODE";
         edtProductName_Internalname = "PRODUCTNAME";
         edtProductStock_Internalname = "PRODUCTSTOCK";
         edtProductMiniumStock_Internalname = "PRODUCTMINIUMSTOCK";
         edtPurchaseOrderDetailQuantityOrd_Internalname = "PURCHASEORDERDETAILQUANTITYORD";
         edtProductCostPrice_Internalname = "PRODUCTCOSTPRICE";
         edtPurchaseOrderDetailQuantityRec_Internalname = "PURCHASEORDERDETAILQUANTITYREC";
         edtPurchaseOrderDetailSuggestedPr_Internalname = "PURCHASEORDERDETAILSUGGESTEDPR";
         edtavPurchaseorderdetailsubtotal_Internalname = "vPURCHASEORDERDETAILSUBTOTAL";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGriddetails_Internalname = "GRIDDETAILS";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("mtaKB", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGriddetails_Allowcollapsing = 0;
         subGriddetails_Allowselection = 0;
         subGriddetails_Header = "";
         chkavIsowed.Caption = "Owed";
         edtavPurchaseorderdetailsubtotal_Jsonclick = "";
         edtavPurchaseorderdetailsubtotal_Enabled = 0;
         edtPurchaseOrderDetailSuggestedPr_Jsonclick = "";
         edtPurchaseOrderDetailQuantityRec_Jsonclick = "";
         edtProductCostPrice_Jsonclick = "";
         edtPurchaseOrderDetailQuantityOrd_Jsonclick = "";
         edtProductMiniumStock_Jsonclick = "";
         edtProductStock_Jsonclick = "";
         edtProductName_Jsonclick = "";
         edtProductCode_Jsonclick = "";
         edtProductId_Jsonclick = "";
         subGriddetails_Class = "PromptGrid";
         subGriddetails_Backcolorstyle = 0;
         edtavPurchaseordertotalprojected_Jsonclick = "";
         edtavPurchaseordertotalprojected_Enabled = 1;
         edtavPurchaseordertotalprojected_Visible = 1;
         edtPurchaseOrderTotalPaid_Jsonclick = "";
         edtPurchaseOrderTotalPaid_Enabled = 0;
         edtPurchaseOrderTotalPaid_Visible = 1;
         chkavIsowed.Enabled = 1;
         chkavIsowed.Visible = 1;
         edtavPurhcaseorderstate_Jsonclick = "";
         edtavPurhcaseorderstate_Enabled = 1;
         edtPurchaseOrderClosedDate_Jsonclick = "";
         edtPurchaseOrderClosedDate_Enabled = 0;
         edtPurchaseOrderClosedDate_Visible = 1;
         edtPurchaseOrderCreatedDate_Jsonclick = "";
         edtPurchaseOrderCreatedDate_Enabled = 0;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Details";
         subGriddetails_Rows = 5;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRIDDETAILS_nFirstRecordOnPage'},{av:'GRIDDETAILS_nEOF'},{av:'subGriddetails_Rows',ctrl:'GRIDDETAILS',prop:'Rows'},{av:'AV14IsOwed',fld:'vISOWED',pic:''},{av:'A50PurchaseOrderId',fld:'PURCHASEORDERID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'VOUCHER'","{handler:'E112N1',iparms:[{av:'A50PurchaseOrderId',fld:'PURCHASEORDERID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("'VOUCHER'",",oparms:[]}");
         setEventMetadata("GRIDDETAILS.REFRESH","{handler:'E132N2',iparms:[{av:'A77PurchaseOrderDetailQuantityRec',fld:'PURCHASEORDERDETAILQUANTITYREC',pic:'ZZZZZ9',hsh:true},{av:'A76PurchaseOrderDetailQuantityOrd',fld:'PURCHASEORDERDETAILQUANTITYORD',pic:'ZZZZZ9',hsh:true},{av:'A134PurchaseOrderDetailSuggestedPr',fld:'PURCHASEORDERDETAILSUGGESTEDPR',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true},{av:'A85ProductCostPrice',fld:'PRODUCTCOSTPRICE',pic:'ZZZZZZZZZZZZZZ9.99'}]");
         setEventMetadata("GRIDDETAILS.REFRESH",",oparms:[{av:'AV10PurchaseOrderTotalProjected',fld:'vPURCHASEORDERTOTALPROJECTED',pic:'ZZZZZZZZZZZZZZ9.99'}]}");
         setEventMetadata("GRIDDETAILS.LOAD","{handler:'E142N2',iparms:[{av:'A77PurchaseOrderDetailQuantityRec',fld:'PURCHASEORDERDETAILQUANTITYREC',pic:'ZZZZZ9',hsh:true},{av:'A134PurchaseOrderDetailSuggestedPr',fld:'PURCHASEORDERDETAILSUGGESTEDPR',pic:'ZZZZZZZZZZZZZZ9.99',hsh:true},{av:'A85ProductCostPrice',fld:'PRODUCTCOSTPRICE',pic:'ZZZZZZZZZZZZZZ9.99'}]");
         setEventMetadata("GRIDDETAILS.LOAD",",oparms:[{av:'AV9PurchaseOrderDetailSubtotal',fld:'vPURCHASEORDERDETAILSUBTOTAL',pic:'ZZZZZZZZZZZ9.99'}]}");
         setEventMetadata("GRIDDETAILS_FIRSTPAGE","{handler:'subgriddetails_firstpage',iparms:[{av:'GRIDDETAILS_nFirstRecordOnPage'},{av:'GRIDDETAILS_nEOF'},{av:'subGriddetails_Rows',ctrl:'GRIDDETAILS',prop:'Rows'},{av:'A50PurchaseOrderId',fld:'PURCHASEORDERID',pic:'ZZZZZ9',hsh:true},{av:'AV14IsOwed',fld:'vISOWED',pic:''}]");
         setEventMetadata("GRIDDETAILS_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRIDDETAILS_PREVPAGE","{handler:'subgriddetails_previouspage',iparms:[{av:'GRIDDETAILS_nFirstRecordOnPage'},{av:'GRIDDETAILS_nEOF'},{av:'subGriddetails_Rows',ctrl:'GRIDDETAILS',prop:'Rows'},{av:'A50PurchaseOrderId',fld:'PURCHASEORDERID',pic:'ZZZZZ9',hsh:true},{av:'AV14IsOwed',fld:'vISOWED',pic:''}]");
         setEventMetadata("GRIDDETAILS_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRIDDETAILS_NEXTPAGE","{handler:'subgriddetails_nextpage',iparms:[{av:'GRIDDETAILS_nFirstRecordOnPage'},{av:'GRIDDETAILS_nEOF'},{av:'subGriddetails_Rows',ctrl:'GRIDDETAILS',prop:'Rows'},{av:'A50PurchaseOrderId',fld:'PURCHASEORDERID',pic:'ZZZZZ9',hsh:true},{av:'AV14IsOwed',fld:'vISOWED',pic:''}]");
         setEventMetadata("GRIDDETAILS_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRIDDETAILS_LASTPAGE","{handler:'subgriddetails_lastpage',iparms:[{av:'GRIDDETAILS_nFirstRecordOnPage'},{av:'GRIDDETAILS_nEOF'},{av:'subGriddetails_Rows',ctrl:'GRIDDETAILS',prop:'Rows'},{av:'A50PurchaseOrderId',fld:'PURCHASEORDERID',pic:'ZZZZZ9',hsh:true},{av:'AV14IsOwed',fld:'vISOWED',pic:''}]");
         setEventMetadata("GRIDDETAILS_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_PURCHASEORDERTOTALPROJECTED","{handler:'Validv_Purchaseordertotalprojected',iparms:[]");
         setEventMetadata("VALIDV_PURCHASEORDERTOTALPROJECTED",",oparms:[]}");
         setEventMetadata("VALID_PRODUCTID","{handler:'Valid_Productid',iparms:[]");
         setEventMetadata("VALID_PRODUCTID",",oparms:[]}");
         setEventMetadata("VALIDV_PURCHASEORDERDETAILSUBTOTAL","{handler:'Validv_Purchaseorderdetailsubtotal',iparms:[]");
         setEventMetadata("VALIDV_PURCHASEORDERDETAILSUBTOTAL",",oparms:[]}");
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
         bttVoucher_Jsonclick = "";
         A52PurchaseOrderCreatedDate = DateTime.MinValue;
         A66PurchaseOrderClosedDate = DateTime.MinValue;
         AV13PurhcaseOrderState = "";
         GriddetailsContainer = new GXWebGrid( context);
         sStyleString = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A55ProductCode = "";
         A16ProductName = "";
         scmdbuf = "";
         H002N2_A61PurchaseOrderDetailId = new int[1] ;
         H002N2_A50PurchaseOrderId = new int[1] ;
         H002N2_A79PurchaseOrderActive = new bool[] {false} ;
         H002N2_A138PurchaseOrderWasPaid = new bool[] {false} ;
         H002N2_n138PurchaseOrderWasPaid = new bool[] {false} ;
         H002N2_A52PurchaseOrderCreatedDate = new DateTime[] {DateTime.MinValue} ;
         H002N2_A66PurchaseOrderClosedDate = new DateTime[] {DateTime.MinValue} ;
         H002N2_n66PurchaseOrderClosedDate = new bool[] {false} ;
         H002N2_A78PurchaseOrderTotalPaid = new decimal[1] ;
         H002N2_n78PurchaseOrderTotalPaid = new bool[] {false} ;
         H002N2_A134PurchaseOrderDetailSuggestedPr = new decimal[1] ;
         H002N2_n134PurchaseOrderDetailSuggestedPr = new bool[] {false} ;
         H002N2_A77PurchaseOrderDetailQuantityRec = new int[1] ;
         H002N2_A85ProductCostPrice = new decimal[1] ;
         H002N2_n85ProductCostPrice = new bool[] {false} ;
         H002N2_A76PurchaseOrderDetailQuantityOrd = new int[1] ;
         H002N2_A69ProductMiniumStock = new int[1] ;
         H002N2_n69ProductMiniumStock = new bool[] {false} ;
         H002N2_A17ProductStock = new int[1] ;
         H002N2_n17ProductStock = new bool[] {false} ;
         H002N2_A16ProductName = new string[] {""} ;
         H002N2_A55ProductCode = new string[] {""} ;
         H002N2_n55ProductCode = new bool[] {false} ;
         H002N2_A15ProductId = new int[1] ;
         H002N3_AGRIDDETAILS_nRecordCount = new long[1] ;
         H002N4_A79PurchaseOrderActive = new bool[] {false} ;
         H002N4_A138PurchaseOrderWasPaid = new bool[] {false} ;
         H002N4_n138PurchaseOrderWasPaid = new bool[] {false} ;
         H002N4_A52PurchaseOrderCreatedDate = new DateTime[] {DateTime.MinValue} ;
         H002N4_A66PurchaseOrderClosedDate = new DateTime[] {DateTime.MinValue} ;
         H002N4_n66PurchaseOrderClosedDate = new bool[] {false} ;
         H002N4_A78PurchaseOrderTotalPaid = new decimal[1] ;
         H002N4_n78PurchaseOrderTotalPaid = new bool[] {false} ;
         AV5Context = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         AV7WebSession = context.GetSession();
         GriddetailsRow = new GXWebRow();
         H002N5_A61PurchaseOrderDetailId = new int[1] ;
         H002N5_A15ProductId = new int[1] ;
         H002N5_A50PurchaseOrderId = new int[1] ;
         H002N5_A76PurchaseOrderDetailQuantityOrd = new int[1] ;
         H002N5_A77PurchaseOrderDetailQuantityRec = new int[1] ;
         H002N5_A85ProductCostPrice = new decimal[1] ;
         H002N5_n85ProductCostPrice = new bool[] {false} ;
         H002N5_A134PurchaseOrderDetailSuggestedPr = new decimal[1] ;
         H002N5_n134PurchaseOrderDetailSuggestedPr = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGriddetails_Linesclass = "";
         ROClassString = "";
         GriddetailsColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wppurchaseorderdetails__default(),
            new Object[][] {
                new Object[] {
               H002N2_A61PurchaseOrderDetailId, H002N2_A50PurchaseOrderId, H002N2_A79PurchaseOrderActive, H002N2_A138PurchaseOrderWasPaid, H002N2_n138PurchaseOrderWasPaid, H002N2_A52PurchaseOrderCreatedDate, H002N2_A66PurchaseOrderClosedDate, H002N2_n66PurchaseOrderClosedDate, H002N2_A78PurchaseOrderTotalPaid, H002N2_n78PurchaseOrderTotalPaid,
               H002N2_A134PurchaseOrderDetailSuggestedPr, H002N2_n134PurchaseOrderDetailSuggestedPr, H002N2_A77PurchaseOrderDetailQuantityRec, H002N2_A85ProductCostPrice, H002N2_n85ProductCostPrice, H002N2_A76PurchaseOrderDetailQuantityOrd, H002N2_A69ProductMiniumStock, H002N2_n69ProductMiniumStock, H002N2_A17ProductStock, H002N2_n17ProductStock,
               H002N2_A16ProductName, H002N2_A55ProductCode, H002N2_n55ProductCode, H002N2_A15ProductId
               }
               , new Object[] {
               H002N3_AGRIDDETAILS_nRecordCount
               }
               , new Object[] {
               H002N4_A79PurchaseOrderActive, H002N4_A138PurchaseOrderWasPaid, H002N4_n138PurchaseOrderWasPaid, H002N4_A52PurchaseOrderCreatedDate, H002N4_A66PurchaseOrderClosedDate, H002N4_n66PurchaseOrderClosedDate, H002N4_A78PurchaseOrderTotalPaid, H002N4_n78PurchaseOrderTotalPaid
               }
               , new Object[] {
               H002N5_A61PurchaseOrderDetailId, H002N5_A15ProductId, H002N5_A50PurchaseOrderId, H002N5_A76PurchaseOrderDetailQuantityOrd, H002N5_A77PurchaseOrderDetailQuantityRec, H002N5_A85ProductCostPrice, H002N5_n85ProductCostPrice, H002N5_A134PurchaseOrderDetailSuggestedPr, H002N5_n134PurchaseOrderDetailSuggestedPr
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavPurhcaseorderstate_Enabled = 0;
         chkavIsowed.Enabled = 0;
         edtavPurchaseordertotalprojected_Enabled = 0;
         edtavPurchaseorderdetailsubtotal_Enabled = 0;
      }

      private short GRIDDETAILS_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGriddetails_Backcolorstyle ;
      private short nGXWrapped ;
      private short subGriddetails_Backstyle ;
      private short subGriddetails_Titlebackstyle ;
      private short subGriddetails_Allowselection ;
      private short subGriddetails_Allowhovering ;
      private short subGriddetails_Allowcollapsing ;
      private short subGriddetails_Collapsed ;
      private int A50PurchaseOrderId ;
      private int wcpOA50PurchaseOrderId ;
      private int nRC_GXsfl_38 ;
      private int subGriddetails_Rows ;
      private int nGXsfl_38_idx=1 ;
      private int edtPurchaseOrderCreatedDate_Enabled ;
      private int edtPurchaseOrderClosedDate_Visible ;
      private int edtPurchaseOrderClosedDate_Enabled ;
      private int edtavPurhcaseorderstate_Enabled ;
      private int edtPurchaseOrderTotalPaid_Visible ;
      private int edtPurchaseOrderTotalPaid_Enabled ;
      private int edtavPurchaseordertotalprojected_Visible ;
      private int edtavPurchaseordertotalprojected_Enabled ;
      private int A15ProductId ;
      private int A17ProductStock ;
      private int A69ProductMiniumStock ;
      private int A76PurchaseOrderDetailQuantityOrd ;
      private int A77PurchaseOrderDetailQuantityRec ;
      private int subGriddetails_Islastpage ;
      private int edtavPurchaseorderdetailsubtotal_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV11PurchaseOrderDetailQuantity ;
      private int idxLst ;
      private int subGriddetails_Backcolor ;
      private int subGriddetails_Allbackcolor ;
      private int subGriddetails_Titlebackcolor ;
      private int subGriddetails_Selectedindex ;
      private int subGriddetails_Selectioncolor ;
      private int subGriddetails_Hoveringcolor ;
      private long GRIDDETAILS_nFirstRecordOnPage ;
      private long GRIDDETAILS_nCurrentRecord ;
      private long GRIDDETAILS_nRecordCount ;
      private decimal A78PurchaseOrderTotalPaid ;
      private decimal AV10PurchaseOrderTotalProjected ;
      private decimal A85ProductCostPrice ;
      private decimal A134PurchaseOrderDetailSuggestedPr ;
      private decimal AV9PurchaseOrderDetailSubtotal ;
      private decimal AV12PurchaseOrderDetailPrice ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_38_idx="0001" ;
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
      private string bttVoucher_Internalname ;
      private string bttVoucher_Jsonclick ;
      private string edtPurchaseOrderCreatedDate_Internalname ;
      private string edtPurchaseOrderCreatedDate_Jsonclick ;
      private string edtPurchaseOrderClosedDate_Internalname ;
      private string edtPurchaseOrderClosedDate_Jsonclick ;
      private string edtavPurhcaseorderstate_Internalname ;
      private string edtavPurhcaseorderstate_Jsonclick ;
      private string chkavIsowed_Internalname ;
      private string edtPurchaseOrderTotalPaid_Internalname ;
      private string edtPurchaseOrderTotalPaid_Jsonclick ;
      private string edtavPurchaseordertotalprojected_Internalname ;
      private string edtavPurchaseordertotalprojected_Jsonclick ;
      private string sStyleString ;
      private string subGriddetails_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtProductId_Internalname ;
      private string edtProductCode_Internalname ;
      private string edtProductName_Internalname ;
      private string edtProductStock_Internalname ;
      private string edtProductMiniumStock_Internalname ;
      private string edtPurchaseOrderDetailQuantityOrd_Internalname ;
      private string edtProductCostPrice_Internalname ;
      private string edtPurchaseOrderDetailQuantityRec_Internalname ;
      private string edtPurchaseOrderDetailSuggestedPr_Internalname ;
      private string edtavPurchaseorderdetailsubtotal_Internalname ;
      private string scmdbuf ;
      private string sGXsfl_38_fel_idx="0001" ;
      private string subGriddetails_Class ;
      private string subGriddetails_Linesclass ;
      private string ROClassString ;
      private string edtProductId_Jsonclick ;
      private string edtProductCode_Jsonclick ;
      private string edtProductName_Jsonclick ;
      private string edtProductStock_Jsonclick ;
      private string edtProductMiniumStock_Jsonclick ;
      private string edtPurchaseOrderDetailQuantityOrd_Jsonclick ;
      private string edtProductCostPrice_Jsonclick ;
      private string edtPurchaseOrderDetailQuantityRec_Jsonclick ;
      private string edtPurchaseOrderDetailSuggestedPr_Jsonclick ;
      private string edtavPurchaseorderdetailsubtotal_Jsonclick ;
      private string subGriddetails_Header ;
      private DateTime A52PurchaseOrderCreatedDate ;
      private DateTime A66PurchaseOrderClosedDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14IsOwed ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n55ProductCode ;
      private bool n17ProductStock ;
      private bool n69ProductMiniumStock ;
      private bool n85ProductCostPrice ;
      private bool n134PurchaseOrderDetailSuggestedPr ;
      private bool bGXsfl_38_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool A79PurchaseOrderActive ;
      private bool A138PurchaseOrderWasPaid ;
      private bool n138PurchaseOrderWasPaid ;
      private bool n66PurchaseOrderClosedDate ;
      private bool n78PurchaseOrderTotalPaid ;
      private bool returnInSub ;
      private bool AV6AllOk ;
      private string AV13PurhcaseOrderState ;
      private string A55ProductCode ;
      private string A16ProductName ;
      private GXWebGrid GriddetailsContainer ;
      private GXWebRow GriddetailsRow ;
      private GXWebColumn GriddetailsColumn ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavIsowed ;
      private IDataStoreProvider pr_default ;
      private int[] H002N2_A61PurchaseOrderDetailId ;
      private int[] H002N2_A50PurchaseOrderId ;
      private bool[] H002N2_A79PurchaseOrderActive ;
      private bool[] H002N2_A138PurchaseOrderWasPaid ;
      private bool[] H002N2_n138PurchaseOrderWasPaid ;
      private DateTime[] H002N2_A52PurchaseOrderCreatedDate ;
      private DateTime[] H002N2_A66PurchaseOrderClosedDate ;
      private bool[] H002N2_n66PurchaseOrderClosedDate ;
      private decimal[] H002N2_A78PurchaseOrderTotalPaid ;
      private bool[] H002N2_n78PurchaseOrderTotalPaid ;
      private decimal[] H002N2_A134PurchaseOrderDetailSuggestedPr ;
      private bool[] H002N2_n134PurchaseOrderDetailSuggestedPr ;
      private int[] H002N2_A77PurchaseOrderDetailQuantityRec ;
      private decimal[] H002N2_A85ProductCostPrice ;
      private bool[] H002N2_n85ProductCostPrice ;
      private int[] H002N2_A76PurchaseOrderDetailQuantityOrd ;
      private int[] H002N2_A69ProductMiniumStock ;
      private bool[] H002N2_n69ProductMiniumStock ;
      private int[] H002N2_A17ProductStock ;
      private bool[] H002N2_n17ProductStock ;
      private string[] H002N2_A16ProductName ;
      private string[] H002N2_A55ProductCode ;
      private bool[] H002N2_n55ProductCode ;
      private int[] H002N2_A15ProductId ;
      private long[] H002N3_AGRIDDETAILS_nRecordCount ;
      private bool[] H002N4_A79PurchaseOrderActive ;
      private bool[] H002N4_A138PurchaseOrderWasPaid ;
      private bool[] H002N4_n138PurchaseOrderWasPaid ;
      private DateTime[] H002N4_A52PurchaseOrderCreatedDate ;
      private DateTime[] H002N4_A66PurchaseOrderClosedDate ;
      private bool[] H002N4_n66PurchaseOrderClosedDate ;
      private decimal[] H002N4_A78PurchaseOrderTotalPaid ;
      private bool[] H002N4_n78PurchaseOrderTotalPaid ;
      private int[] H002N5_A61PurchaseOrderDetailId ;
      private int[] H002N5_A15ProductId ;
      private int[] H002N5_A50PurchaseOrderId ;
      private int[] H002N5_A76PurchaseOrderDetailQuantityOrd ;
      private int[] H002N5_A77PurchaseOrderDetailQuantityRec ;
      private decimal[] H002N5_A85ProductCostPrice ;
      private bool[] H002N5_n85ProductCostPrice ;
      private decimal[] H002N5_A134PurchaseOrderDetailSuggestedPr ;
      private bool[] H002N5_n134PurchaseOrderDetailSuggestedPr ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IGxSession AV7WebSession ;
      private GXWebForm Form ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession AV5Context ;
   }

   public class wppurchaseorderdetails__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH002N2;
          prmH002N2 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH002N3;
          prmH002N3 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmH002N4;
          prmH002N4 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmH002N5;
          prmH002N5 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002N2", "SELECT T1.[PurchaseOrderDetailId], T1.[PurchaseOrderId], T3.[PurchaseOrderActive], T3.[PurchaseOrderWasPaid], T3.[PurchaseOrderCreatedDate], T3.[PurchaseOrderClosedDate], T3.[PurchaseOrderTotalPaid], T1.[PurchaseOrderDetailSuggestedPr], T1.[PurchaseOrderDetailQuantityRec], T2.[ProductCostPrice], T1.[PurchaseOrderDetailQuantityOrd], T2.[ProductMiniumStock], T2.[ProductStock], T2.[ProductName], T2.[ProductCode], T1.[ProductId] FROM (([PurchaseOrderDetail] T1 INNER JOIN [Product] T2 ON T2.[ProductId] = T1.[ProductId]) INNER JOIN [PurchaseOrder] T3 ON T3.[PurchaseOrderId] = T1.[PurchaseOrderId]) WHERE T1.[PurchaseOrderId] = @PurchaseOrderId ORDER BY T1.[PurchaseOrderId]  OFFSET @GXPagingFrom2 ROWS FETCH NEXT CAST((SELECT CASE WHEN @GXPagingTo2 > 0 THEN @GXPagingTo2 ELSE 1e9 END) AS INTEGER) ROWS ONLY",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002N2,6, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002N3", "SELECT COUNT(*) FROM (([PurchaseOrderDetail] T1 INNER JOIN [Product] T3 ON T3.[ProductId] = T1.[ProductId]) INNER JOIN [PurchaseOrder] T2 ON T2.[PurchaseOrderId] = T1.[PurchaseOrderId]) WHERE T1.[PurchaseOrderId] = @PurchaseOrderId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002N3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002N4", "SELECT [PurchaseOrderActive], [PurchaseOrderWasPaid], [PurchaseOrderCreatedDate], [PurchaseOrderClosedDate], [PurchaseOrderTotalPaid] FROM [PurchaseOrder] WHERE [PurchaseOrderId] = @PurchaseOrderId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002N4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002N5", "SELECT T1.[PurchaseOrderDetailId], T1.[ProductId], T1.[PurchaseOrderId], T1.[PurchaseOrderDetailQuantityOrd], T1.[PurchaseOrderDetailQuantityRec], T2.[ProductCostPrice], T1.[PurchaseOrderDetailSuggestedPr] FROM ([PurchaseOrderDetail] T1 INNER JOIN [Product] T2 ON T2.[ProductId] = T1.[ProductId]) WHERE T1.[PurchaseOrderId] = @PurchaseOrderId ORDER BY T1.[PurchaseOrderId]  OPTION (FAST 6)",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002N5,6, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(7);
                ((bool[]) buf[9])[0] = rslt.wasNull(7);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(8);
                ((bool[]) buf[11])[0] = rslt.wasNull(8);
                ((int[]) buf[12])[0] = rslt.getInt(9);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(10);
                ((bool[]) buf[14])[0] = rslt.wasNull(10);
                ((int[]) buf[15])[0] = rslt.getInt(11);
                ((int[]) buf[16])[0] = rslt.getInt(12);
                ((bool[]) buf[17])[0] = rslt.wasNull(12);
                ((int[]) buf[18])[0] = rslt.getInt(13);
                ((bool[]) buf[19])[0] = rslt.wasNull(13);
                ((string[]) buf[20])[0] = rslt.getVarchar(14);
                ((string[]) buf[21])[0] = rslt.getVarchar(15);
                ((bool[]) buf[22])[0] = rslt.wasNull(15);
                ((int[]) buf[23])[0] = rslt.getInt(16);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 2 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                return;
       }
    }

 }

}
