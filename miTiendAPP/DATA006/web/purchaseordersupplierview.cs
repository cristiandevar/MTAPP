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
   public class purchaseordersupplierview : GXDataArea
   {
      public purchaseordersupplierview( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public purchaseordersupplierview( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_PurchaseOrderId ,
                           ref string aP1_MesaggeError )
      {
         this.AV12PurchaseOrderId = aP0_PurchaseOrderId;
         this.AV25MesaggeError = aP1_MesaggeError;
         executePrivate();
         aP1_MesaggeError=this.AV25MesaggeError;
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridpurchaseorderdetails") == 0 )
            {
               gxnrGridpurchaseorderdetails_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridpurchaseorderdetails") == 0 )
            {
               gxgrGridpurchaseorderdetails_refresh_invoke( ) ;
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
               AV12PurchaseOrderId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12PurchaseOrderId", StringUtil.LTrimStr( (decimal)(AV12PurchaseOrderId), 6, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vPURCHASEORDERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12PurchaseOrderId), "ZZZZZ9"), context));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV25MesaggeError = GetPar( "MesaggeError");
                  AssignAttri("", false, "AV25MesaggeError", AV25MesaggeError);
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

      protected void gxnrGridpurchaseorderdetails_newrow_invoke( )
      {
         nRC_GXsfl_31 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_31"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_31_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_31_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_31_idx = GetPar( "sGXsfl_31_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridpurchaseorderdetails_newrow( ) ;
         /* End function gxnrGridpurchaseorderdetails_newrow_invoke */
      }

      protected void gxgrGridpurchaseorderdetails_refresh_invoke( )
      {
         ajax_req_read_hidden_sdt(GetNextPar( ), AV37SDTPurchaseOrderDetails);
         AV12PurchaseOrderId = (int)(Math.Round(NumberUtil.Val( GetPar( "PurchaseOrderId"), "."), 18, MidpointRounding.ToEven));
         AV18MeEmail = GetPar( "MeEmail");
         AV15SupplierName = GetPar( "SupplierName");
         AV16PurchaseOrderCreatedDate = context.localUtil.ParseDateParm( GetPar( "PurchaseOrderCreatedDate"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridpurchaseorderdetails_refresh( AV37SDTPurchaseOrderDetails, AV12PurchaseOrderId, AV18MeEmail, AV15SupplierName, AV16PurchaseOrderCreatedDate) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridpurchaseorderdetails_refresh_invoke */
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("general.ui.masterguest", "GeneXus.Programs.general.ui.masterguest", new Object[] {context});
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
         PA3K2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3K2( ) ;
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
         context.AddJavascriptSource("UserControls/UCProbamosLoaderRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("purchaseordersupplierview.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV12PurchaseOrderId,6,0)),UrlEncode(StringUtil.RTrim(AV25MesaggeError))}, new string[] {"PurchaseOrderId","MesaggeError"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vMEEMAIL", AV18MeEmail);
         GxWebStd.gx_hidden_field( context, "gxhash_vMEEMAIL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV18MeEmail, "")), context));
         GxWebStd.gx_hidden_field( context, "vSUPPLIERNAME", AV15SupplierName);
         GxWebStd.gx_hidden_field( context, "gxhash_vSUPPLIERNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV15SupplierName, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vPURCHASEORDERCREATEDDATE", GetSecureSignedToken( "", AV16PurchaseOrderCreatedDate, context));
         GxWebStd.gx_hidden_field( context, "vPURCHASEORDERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12PurchaseOrderId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPURCHASEORDERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12PurchaseOrderId), "ZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"PurchaseOrderSupplierView");
         forbiddenHiddens.Add("PurchaseOrderCreatedDate", context.localUtil.Format(AV16PurchaseOrderCreatedDate, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("purchaseordersupplierview:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Sdtpurchaseorderdetails", AV37SDTPurchaseOrderDetails);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Sdtpurchaseorderdetails", AV37SDTPurchaseOrderDetails);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_31", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_31), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTPURCHASEORDERDETAILS", AV37SDTPurchaseOrderDetails);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTPURCHASEORDERDETAILS", AV37SDTPurchaseOrderDetails);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vCONTROLPASSED", AV42ControlPassed);
         GxWebStd.gx_hidden_field( context, "vPURCHASEORDERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12PurchaseOrderId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPURCHASEORDERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12PurchaseOrderId), "ZZZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vNAMESOFATTACHS", AV20NamesOfAttachs);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vNAMESOFATTACHS", AV20NamesOfAttachs);
         }
         GxWebStd.gx_hidden_field( context, "vEMAILTITLE", AV49EmailTitle);
         GxWebStd.gx_hidden_field( context, "vEMAILSUBTITLE", AV50EmailSubtitle);
         GxWebStd.gx_hidden_field( context, "vMEEMAIL", AV18MeEmail);
         GxWebStd.gx_hidden_field( context, "gxhash_vMEEMAIL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV18MeEmail, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vALLOK", AV21AllOk);
         GxWebStd.gx_hidden_field( context, "PURCHASEORDERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A50PurchaseOrderId), 6, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, "PURCHASEORDERACTIVE", A79PurchaseOrderActive);
         GxWebStd.gx_hidden_field( context, "vSUPPLIERNAME", AV15SupplierName);
         GxWebStd.gx_hidden_field( context, "gxhash_vSUPPLIERNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV15SupplierName, "")), context));
         GxWebStd.gx_hidden_field( context, "vEMAILBODY", AV14EmailBody);
         GxWebStd.gx_hidden_field( context, "vMESAGGEERROR", AV25MesaggeError);
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
            WE3K2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3K2( ) ;
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
         return formatLink("purchaseordersupplierview.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV12PurchaseOrderId,6,0)),UrlEncode(StringUtil.RTrim(AV25MesaggeError))}, new string[] {"PurchaseOrderId","MesaggeError"})  ;
      }

      public override string GetPgmname( )
      {
         return "PurchaseOrderSupplierView" ;
      }

      public override string GetPgmdesc( )
      {
         return "Purchase Order Supplier View" ;
      }

      protected void WB3K0( )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable2_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTitletext_Internalname, lblTitletext_Caption, "", "", lblTitletext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_PurchaseOrderSupplierView.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            context.WriteHtmlText( "<hr/>") ;
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
            GxWebStd.gx_div_start( context, divTableorderconfirm_Internalname, divTableorderconfirm_Visible, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavPurchaseordercreateddate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPurchaseordercreateddate_Internalname, "Created Date", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'" + sGXsfl_31_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavPurchaseordercreateddate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavPurchaseordercreateddate_Internalname, context.localUtil.Format(AV16PurchaseOrderCreatedDate, "99/99/99"), context.localUtil.Format( AV16PurchaseOrderCreatedDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,19);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPurchaseordercreateddate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavPurchaseordercreateddate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_PurchaseOrderSupplierView.htm");
            GxWebStd.gx_bitmap( context, edtavPurchaseordercreateddate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavPurchaseordercreateddate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_PurchaseOrderSupplierView.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavTotalprojected_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTotalprojected_Internalname, "Total Projected", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'" + sGXsfl_31_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTotalprojected_Internalname, StringUtil.LTrim( StringUtil.NToC( AV41TotalProjected, 18, 2, ".", "")), StringUtil.LTrim( ((edtavTotalprojected_Enabled!=0) ? context.localUtil.Format( AV41TotalProjected, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV41TotalProjected, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,23);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTotalprojected_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTotalprojected_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Price", "right", false, "", "HLP_PurchaseOrderSupplierView.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttConfirmorder_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(31), 2, 0)+","+"null"+");", "Confirm Order", bttConfirmorder_Jsonclick, 5, "Confirm Order", "", StyleString, ClassString, bttConfirmorder_Visible, bttConfirmorder_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CONFIRMORDER\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_PurchaseOrderSupplierView.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "ww__grid-container", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridpurchaseorderdetailsContainer.SetWrapped(nGXWrapped);
            StartGridControl31( ) ;
         }
         if ( wbEnd == 31 )
         {
            wbEnd = 0;
            nRC_GXsfl_31 = (int)(nGXsfl_31_idx-1);
            if ( GridpurchaseorderdetailsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV60GXV1 = nGXsfl_31_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridpurchaseorderdetailsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridpurchaseorderdetails", GridpurchaseorderdetailsContainer, subGridpurchaseorderdetails_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridpurchaseorderdetailsContainerData", GridpurchaseorderdetailsContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridpurchaseorderdetailsContainerData"+"V", GridpurchaseorderdetailsContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridpurchaseorderdetailsContainerData"+"V"+"\" value='"+GridpurchaseorderdetailsContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            GxWebStd.gx_div_start( context, divTableorderconfirmed_Internalname, divTableorderconfirmed_Visible, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Order Confirmated successfully", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextblockMedium", 0, "", 1, 1, 0, 0, "HLP_PurchaseOrderSupplierView.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Thank you for Confirm the order, an email was send to notify desicion", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-02", 0, "", 1, 1, 0, 0, "HLP_PurchaseOrderSupplierView.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttOrderconfirmatedexit_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(31), 2, 0)+","+"null"+");", "Exit", bttOrderconfirmatedexit_Jsonclick, 7, "Exit", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e113k1_client"+"'", TempTags, "", 2, "HLP_PurchaseOrderSupplierView.htm");
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
            GxWebStd.gx_div_start( context, divTableordercancel_Internalname, divTableordercancel_Visible, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'" + sGXsfl_31_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavPurchaseordercanceleddescription_Internalname, AV44PurchaseOrderCanceledDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,65);\"", 0, 1, edtavPurchaseordercanceleddescription_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "Reason for cancellation", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_PurchaseOrderSupplierView.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCancelorder_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(31), 2, 0)+","+"null"+");", "Cancel Order", bttCancelorder_Jsonclick, 5, "Cancel Order", "", StyleString, ClassString, bttCancelorder_Visible, bttCancelorder_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CANCELORDER\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_PurchaseOrderSupplierView.htm");
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
            GxWebStd.gx_div_start( context, divTableordercanceled_Internalname, divTableordercanceled_Visible, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Order Canceled successfully", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextblockMedium", 0, "", 1, 1, 0, 0, "HLP_PurchaseOrderSupplierView.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Thank you for notify us the cancelation of this Order.", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-02", 0, "", 1, 1, 0, 0, "HLP_PurchaseOrderSupplierView.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttOrdercanceledexit_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(31), 2, 0)+","+"null"+");", "Exit", bttOrdercanceledexit_Jsonclick, 7, "Exit", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e123k1_client"+"'", TempTags, "", 2, "HLP_PurchaseOrderSupplierView.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucUcprobamosloader1.Render(context, "ucprobamosloader", Ucprobamosloader1_Internalname, "UCPROBAMOSLOADER1Container");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 31 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridpurchaseorderdetailsContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV60GXV1 = nGXsfl_31_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridpurchaseorderdetailsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridpurchaseorderdetails", GridpurchaseorderdetailsContainer, subGridpurchaseorderdetails_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridpurchaseorderdetailsContainerData", GridpurchaseorderdetailsContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridpurchaseorderdetailsContainerData"+"V", GridpurchaseorderdetailsContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridpurchaseorderdetailsContainerData"+"V"+"\" value='"+GridpurchaseorderdetailsContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START3K2( )
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
            Form.Meta.addItem("description", "Purchase Order Supplier View", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3K0( ) ;
      }

      protected void WS3K2( )
      {
         START3K2( ) ;
         EVT3K2( ) ;
      }

      protected void EVT3K2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "'CANCELORDER'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'CancelOrder' */
                              E133K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CONFIRMORDER'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'ConfirmOrder' */
                              E143K2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 32), "GRIDPURCHASEORDERDETAILS.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 29), "GRIDPURCHASEORDERDETAILS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_31_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_31_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_31_idx), 4, 0), 4, "0");
                              SubsflControlProps_312( ) ;
                              AV60GXV1 = nGXsfl_31_idx;
                              if ( ( AV37SDTPurchaseOrderDetails.Count >= AV60GXV1 ) && ( AV60GXV1 > 0 ) )
                              {
                                 AV37SDTPurchaseOrderDetails.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV37SDTPurchaseOrderDetails.Item(AV60GXV1));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E153K2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDPURCHASEORDERDETAILS.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E163K2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDPURCHASEORDERDETAILS.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E173K2 ();
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

      protected void WE3K2( )
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

      protected void PA3K2( )
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
               GX_FocusControl = edtavPurchaseordercreateddate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridpurchaseorderdetails_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_312( ) ;
         while ( nGXsfl_31_idx <= nRC_GXsfl_31 )
         {
            sendrow_312( ) ;
            nGXsfl_31_idx = ((subGridpurchaseorderdetails_Islastpage==1)&&(nGXsfl_31_idx+1>subGridpurchaseorderdetails_fnc_Recordsperpage( )) ? 1 : nGXsfl_31_idx+1);
            sGXsfl_31_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_31_idx), 4, 0), 4, "0");
            SubsflControlProps_312( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridpurchaseorderdetailsContainer)) ;
         /* End function gxnrGridpurchaseorderdetails_newrow */
      }

      protected void gxgrGridpurchaseorderdetails_refresh( GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem> AV37SDTPurchaseOrderDetails ,
                                                           int AV12PurchaseOrderId ,
                                                           string AV18MeEmail ,
                                                           string AV15SupplierName ,
                                                           DateTime AV16PurchaseOrderCreatedDate )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDPURCHASEORDERDETAILS_nCurrentRecord = 0;
         RF3K2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"PurchaseOrderSupplierView");
         forbiddenHiddens.Add("PurchaseOrderCreatedDate", context.localUtil.Format(AV16PurchaseOrderCreatedDate, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("purchaseordersupplierview:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
         /* End function gxgrGridpurchaseorderdetails_refresh */
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
         RF3K2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavPurchaseordercreateddate_Enabled = 0;
         AssignProp("", false, edtavPurchaseordercreateddate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPurchaseordercreateddate_Enabled), 5, 0), true);
         edtavTotalprojected_Enabled = 0;
         AssignProp("", false, edtavTotalprojected_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTotalprojected_Enabled), 5, 0), true);
         edtavCtlcode_Enabled = 0;
         AssignProp("", false, edtavCtlcode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcode_Enabled), 5, 0), !bGXsfl_31_Refreshing);
         edtavCtlname_Enabled = 0;
         AssignProp("", false, edtavCtlname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname_Enabled), 5, 0), !bGXsfl_31_Refreshing);
         edtavCtlquantityordered_Enabled = 0;
         AssignProp("", false, edtavCtlquantityordered_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlquantityordered_Enabled), 5, 0), !bGXsfl_31_Refreshing);
         edtavCtlproductcostprice_Enabled = 0;
         AssignProp("", false, edtavCtlproductcostprice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlproductcostprice_Enabled), 5, 0), !bGXsfl_31_Refreshing);
         edtavCtlsubtotal_Enabled = 0;
         AssignProp("", false, edtavCtlsubtotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsubtotal_Enabled), 5, 0), !bGXsfl_31_Refreshing);
      }

      protected void RF3K2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridpurchaseorderdetailsContainer.ClearRows();
         }
         wbStart = 31;
         E163K2 ();
         nGXsfl_31_idx = 1;
         sGXsfl_31_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_31_idx), 4, 0), 4, "0");
         SubsflControlProps_312( ) ;
         bGXsfl_31_Refreshing = true;
         GridpurchaseorderdetailsContainer.AddObjectProperty("GridName", "Gridpurchaseorderdetails");
         GridpurchaseorderdetailsContainer.AddObjectProperty("CmpContext", "");
         GridpurchaseorderdetailsContainer.AddObjectProperty("InMasterPage", "false");
         GridpurchaseorderdetailsContainer.AddObjectProperty("Class", "PromptGrid");
         GridpurchaseorderdetailsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridpurchaseorderdetailsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridpurchaseorderdetailsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpurchaseorderdetails_Backcolorstyle), 1, 0, ".", "")));
         GridpurchaseorderdetailsContainer.PageSize = subGridpurchaseorderdetails_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_312( ) ;
            E173K2 ();
            wbEnd = 31;
            WB3K0( ) ;
         }
         bGXsfl_31_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3K2( )
      {
         GxWebStd.gx_hidden_field( context, "vMEEMAIL", AV18MeEmail);
         GxWebStd.gx_hidden_field( context, "gxhash_vMEEMAIL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV18MeEmail, "")), context));
         GxWebStd.gx_hidden_field( context, "vSUPPLIERNAME", AV15SupplierName);
         GxWebStd.gx_hidden_field( context, "gxhash_vSUPPLIERNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV15SupplierName, "")), context));
      }

      protected int subGridpurchaseorderdetails_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGridpurchaseorderdetails_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGridpurchaseorderdetails_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGridpurchaseorderdetails_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavPurchaseordercreateddate_Enabled = 0;
         AssignProp("", false, edtavPurchaseordercreateddate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavPurchaseordercreateddate_Enabled), 5, 0), true);
         edtavTotalprojected_Enabled = 0;
         AssignProp("", false, edtavTotalprojected_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTotalprojected_Enabled), 5, 0), true);
         edtavCtlcode_Enabled = 0;
         AssignProp("", false, edtavCtlcode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcode_Enabled), 5, 0), !bGXsfl_31_Refreshing);
         edtavCtlname_Enabled = 0;
         AssignProp("", false, edtavCtlname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname_Enabled), 5, 0), !bGXsfl_31_Refreshing);
         edtavCtlquantityordered_Enabled = 0;
         AssignProp("", false, edtavCtlquantityordered_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlquantityordered_Enabled), 5, 0), !bGXsfl_31_Refreshing);
         edtavCtlproductcostprice_Enabled = 0;
         AssignProp("", false, edtavCtlproductcostprice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlproductcostprice_Enabled), 5, 0), !bGXsfl_31_Refreshing);
         edtavCtlsubtotal_Enabled = 0;
         AssignProp("", false, edtavCtlsubtotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsubtotal_Enabled), 5, 0), !bGXsfl_31_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3K0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E153K2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Sdtpurchaseorderdetails"), AV37SDTPurchaseOrderDetails);
            /* Read saved values. */
            nRC_GXsfl_31 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_31"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_31 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_31"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_31_fel_idx = 0;
            while ( nGXsfl_31_fel_idx < nRC_GXsfl_31 )
            {
               nGXsfl_31_fel_idx = ((subGridpurchaseorderdetails_Islastpage==1)&&(nGXsfl_31_fel_idx+1>subGridpurchaseorderdetails_fnc_Recordsperpage( )) ? 1 : nGXsfl_31_fel_idx+1);
               sGXsfl_31_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_31_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_312( ) ;
               AV60GXV1 = nGXsfl_31_fel_idx;
               if ( ( AV37SDTPurchaseOrderDetails.Count >= AV60GXV1 ) && ( AV60GXV1 > 0 ) )
               {
                  AV37SDTPurchaseOrderDetails.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV37SDTPurchaseOrderDetails.Item(AV60GXV1));
               }
            }
            if ( nGXsfl_31_fel_idx == 0 )
            {
               nGXsfl_31_idx = 1;
               sGXsfl_31_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_31_idx), 4, 0), 4, "0");
               SubsflControlProps_312( ) ;
            }
            nGXsfl_31_fel_idx = 1;
            /* Read variables values. */
            if ( context.localUtil.VCDate( cgiGet( edtavPurchaseordercreateddate_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Purchase Order Created Date"}), 1, "vPURCHASEORDERCREATEDDATE");
               GX_FocusControl = edtavPurchaseordercreateddate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV16PurchaseOrderCreatedDate = DateTime.MinValue;
               AssignAttri("", false, "AV16PurchaseOrderCreatedDate", context.localUtil.Format(AV16PurchaseOrderCreatedDate, "99/99/99"));
               GxWebStd.gx_hidden_field( context, "gxhash_vPURCHASEORDERCREATEDDATE", GetSecureSignedToken( "", AV16PurchaseOrderCreatedDate, context));
            }
            else
            {
               AV16PurchaseOrderCreatedDate = context.localUtil.CToD( cgiGet( edtavPurchaseordercreateddate_Internalname), 1);
               AssignAttri("", false, "AV16PurchaseOrderCreatedDate", context.localUtil.Format(AV16PurchaseOrderCreatedDate, "99/99/99"));
               GxWebStd.gx_hidden_field( context, "gxhash_vPURCHASEORDERCREATEDDATE", GetSecureSignedToken( "", AV16PurchaseOrderCreatedDate, context));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTotalprojected_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTotalprojected_Internalname), ".", ",") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTOTALPROJECTED");
               GX_FocusControl = edtavTotalprojected_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV41TotalProjected = 0;
               AssignAttri("", false, "AV41TotalProjected", StringUtil.LTrimStr( AV41TotalProjected, 18, 2));
            }
            else
            {
               AV41TotalProjected = context.localUtil.CToN( cgiGet( edtavTotalprojected_Internalname), ".", ",");
               AssignAttri("", false, "AV41TotalProjected", StringUtil.LTrimStr( AV41TotalProjected, 18, 2));
            }
            AV44PurchaseOrderCanceledDescription = cgiGet( edtavPurchaseordercanceleddescription_Internalname);
            AssignAttri("", false, "AV44PurchaseOrderCanceledDescription", AV44PurchaseOrderCanceledDescription);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"PurchaseOrderSupplierView");
            AV16PurchaseOrderCreatedDate = context.localUtil.CToD( cgiGet( edtavPurchaseordercreateddate_Internalname), 1);
            AssignAttri("", false, "AV16PurchaseOrderCreatedDate", context.localUtil.Format(AV16PurchaseOrderCreatedDate, "99/99/99"));
            GxWebStd.gx_hidden_field( context, "gxhash_vPURCHASEORDERCREATEDDATE", GetSecureSignedToken( "", AV16PurchaseOrderCreatedDate, context));
            forbiddenHiddens.Add("PurchaseOrderCreatedDate", context.localUtil.Format(AV16PurchaseOrderCreatedDate, "99/99/99"));
            hsh = cgiGet( "hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("purchaseordersupplierview:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               return  ;
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
         E153K2 ();
         if (returnInSub) return;
      }

      protected void E153K2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV68GXLvl3 = 0;
         /* Using cursor H003K2 */
         pr_default.execute(0, new Object[] {AV12PurchaseOrderId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A79PurchaseOrderActive = H003K2_A79PurchaseOrderActive[0];
            A50PurchaseOrderId = H003K2_A50PurchaseOrderId[0];
            AV68GXLvl3 = 1;
            AV10Exists = true;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV68GXLvl3 == 0 )
         {
            AV10Exists = false;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV25MesaggeError)) || ( StringUtil.StrCmp(AV25MesaggeError, "") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( AV25MesaggeError)) ) )
         {
            GX_msglist.addItem(AV25MesaggeError);
         }
         AV14EmailBody = "";
         AssignAttri("", false, "AV14EmailBody", AV14EmailBody);
         AV18MeEmail = "mtappcontact@gmail.com";
         AssignAttri("", false, "AV18MeEmail", AV18MeEmail);
         GxWebStd.gx_hidden_field( context, "gxhash_vMEEMAIL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV18MeEmail, "")), context));
         AV23AnswerCancel = false;
         AV24AnswerConfirm = false;
         bttCancelorder_Jsonclick = "confirm('Are you sure to Cancel Order?')";
         AssignProp("", false, bttCancelorder_Internalname, "Jsonclick", bttCancelorder_Jsonclick, true);
         bttConfirmorder_Jsonclick = "confirm('Are you sure to Confirm Order?')";
         AssignProp("", false, bttConfirmorder_Internalname, "Jsonclick", bttConfirmorder_Jsonclick, true);
         if ( AV10Exists )
         {
            /* Execute user subroutine: 'CHARGESDT' */
            S112 ();
            if (returnInSub) return;
            /* Execute user subroutine: 'HIDETABLES' */
            S122 ();
            if (returnInSub) return;
            divTableordercancel_Visible = 1;
            AssignProp("", false, divTableordercancel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableordercancel_Visible), 5, 0), true);
            divTableorderconfirm_Visible = 1;
            AssignProp("", false, divTableorderconfirm_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableorderconfirm_Visible), 5, 0), true);
         }
         else
         {
            CallWebObject(formatLink("wplogin.aspx") );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void E163K2( )
      {
         AV60GXV1 = nGXsfl_31_idx;
         if ( ( AV60GXV1 > 0 ) && ( AV37SDTPurchaseOrderDetails.Count >= AV60GXV1 ) )
         {
            AV37SDTPurchaseOrderDetails.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV37SDTPurchaseOrderDetails.Item(AV60GXV1));
         }
         /* Gridpurchaseorderdetails_Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CALCULATETOTAL' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV37SDTPurchaseOrderDetails", AV37SDTPurchaseOrderDetails);
      }

      protected void E133K2( )
      {
         AV60GXV1 = nGXsfl_31_idx;
         if ( ( AV60GXV1 > 0 ) && ( AV37SDTPurchaseOrderDetails.Count >= AV60GXV1 ) )
         {
            AV37SDTPurchaseOrderDetails.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV37SDTPurchaseOrderDetails.Item(AV60GXV1));
         }
         /* 'CancelOrder' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CONTROLCANCEL' */
         S142 ();
         if (returnInSub) return;
         if ( AV42ControlPassed )
         {
            /* Execute user subroutine: 'DISABLEDBUTTONS' */
            S152 ();
            if (returnInSub) return;
            /* Execute user subroutine: 'HIDETABLES' */
            S122 ();
            if (returnInSub) return;
            AV14EmailBody = "";
            AssignAttri("", false, "AV14EmailBody", AV14EmailBody);
            AV48Answer = false;
            /* Execute user subroutine: 'CREATEBOBYEMAILCANCEL' */
            S162 ();
            if (returnInSub) return;
            AV39Option = false;
            new purchaseordermodifybysupplier(context ).execute(  AV12PurchaseOrderId,  AV39Option,  AV37SDTPurchaseOrderDetails,  AV44PurchaseOrderCanceledDescription) ;
            AV19URLs = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV19URLs.Add(formatLink("apurchaseordervoucher.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV12PurchaseOrderId,6,0))}, new string[] {"PurchaseOrderId"}) , 0);
            AV20NamesOfAttachs.Add("Voucher_"+StringUtil.Str( (decimal)(AV12PurchaseOrderId), 6, 0)+".pdf", 0);
            new sendemailprepareheader(context ).execute(  AV49EmailTitle,  AV50EmailSubtitle,  AV14EmailBody, out  AV56EmailBodyAux) ;
            AV14EmailBody = AV56EmailBodyAux;
            AssignAttri("", false, "AV14EmailBody", AV14EmailBody);
            GXt_char1 = "Order Canceled";
            new sendemail(context ).execute(  AV18MeEmail, ref  AV14EmailBody, ref  GXt_char1, ref  AV19URLs, ref  AV20NamesOfAttachs, ref  AV21AllOk) ;
            AssignAttri("", false, "AV14EmailBody", AV14EmailBody);
            AssignAttri("", false, "AV21AllOk", AV21AllOk);
            /* Execute user subroutine: 'HIDETABLES' */
            S122 ();
            if (returnInSub) return;
            divTableordercanceled_Visible = 1;
            AssignProp("", false, divTableordercanceled_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableordercanceled_Visible), 5, 0), true);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20NamesOfAttachs", AV20NamesOfAttachs);
      }

      protected void E143K2( )
      {
         AV60GXV1 = nGXsfl_31_idx;
         if ( ( AV60GXV1 > 0 ) && ( AV37SDTPurchaseOrderDetails.Count >= AV60GXV1 ) )
         {
            AV37SDTPurchaseOrderDetails.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV37SDTPurchaseOrderDetails.Item(AV60GXV1));
         }
         /* 'ConfirmOrder' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CONTROLCONFIRM' */
         S172 ();
         if (returnInSub) return;
         if ( AV42ControlPassed )
         {
            /* Execute user subroutine: 'DISABLEDBUTTONS' */
            S152 ();
            if (returnInSub) return;
            /* Execute user subroutine: 'HIDETABLES' */
            S122 ();
            if (returnInSub) return;
            /* Execute user subroutine: 'CREATEBODYEMAILCONFIRM' */
            S182 ();
            if (returnInSub) return;
            AV19URLs = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV39Option = true;
            new purchaseordermodifybysupplier(context ).execute(  AV12PurchaseOrderId,  AV39Option,  AV37SDTPurchaseOrderDetails,  AV44PurchaseOrderCanceledDescription) ;
            AV19URLs.Add(formatLink("apurchaseordervoucher.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV12PurchaseOrderId,6,0))}, new string[] {"PurchaseOrderId"}) , 0);
            AV20NamesOfAttachs.Add("Voucher_"+StringUtil.Str( (decimal)(AV12PurchaseOrderId), 6, 0)+".pdf", 0);
            new sendemailprepareheader(context ).execute(  AV49EmailTitle,  AV50EmailSubtitle,  AV14EmailBody, out  AV56EmailBodyAux) ;
            AV14EmailBody = AV56EmailBodyAux;
            AssignAttri("", false, "AV14EmailBody", AV14EmailBody);
            GXt_char1 = "Order Confirmed";
            new sendemail(context ).execute(  AV18MeEmail, ref  AV14EmailBody, ref  GXt_char1, ref  AV19URLs, ref  AV20NamesOfAttachs, ref  AV21AllOk) ;
            AssignAttri("", false, "AV14EmailBody", AV14EmailBody);
            AssignAttri("", false, "AV21AllOk", AV21AllOk);
            divTableorderconfirmed_Visible = 1;
            AssignProp("", false, divTableorderconfirmed_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableorderconfirmed_Visible), 5, 0), true);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20NamesOfAttachs", AV20NamesOfAttachs);
      }

      protected void S112( )
      {
         /* 'CHARGESDT' Routine */
         returnInSub = false;
         /* Using cursor H003K3 */
         pr_default.execute(1, new Object[] {AV12PurchaseOrderId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A4SupplierId = H003K3_A4SupplierId[0];
            A50PurchaseOrderId = H003K3_A50PurchaseOrderId[0];
            A52PurchaseOrderCreatedDate = H003K3_A52PurchaseOrderCreatedDate[0];
            A5SupplierName = H003K3_A5SupplierName[0];
            A5SupplierName = H003K3_A5SupplierName[0];
            AV16PurchaseOrderCreatedDate = A52PurchaseOrderCreatedDate;
            AssignAttri("", false, "AV16PurchaseOrderCreatedDate", context.localUtil.Format(AV16PurchaseOrderCreatedDate, "99/99/99"));
            GxWebStd.gx_hidden_field( context, "gxhash_vPURCHASEORDERCREATEDDATE", GetSecureSignedToken( "", AV16PurchaseOrderCreatedDate, context));
            AV15SupplierName = A5SupplierName;
            AssignAttri("", false, "AV15SupplierName", AV15SupplierName);
            GxWebStd.gx_hidden_field( context, "gxhash_vSUPPLIERNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV15SupplierName, "")), context));
            Form.Caption = context.localUtil.DToC( AV16PurchaseOrderCreatedDate, 1, "/");
            AssignProp("", false, "FORM", "Caption", Form.Caption, true);
            lblTitletext_Caption = "Purchase Order N° "+StringUtil.Str( (decimal)(AV12PurchaseOrderId), 6, 0)+" to "+AV15SupplierName;
            AssignProp("", false, lblTitletext_Internalname, "Caption", lblTitletext_Caption, true);
            lblTitletext_Caption = StringUtil.Upper( lblTitletext_Caption);
            AssignProp("", false, lblTitletext_Internalname, "Caption", lblTitletext_Caption, true);
            AV37SDTPurchaseOrderDetails = new GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem>( context, "SDTPurchaseOrderDetailsItem", "mtaKB");
            gx_BV31 = true;
            /* Using cursor H003K4 */
            pr_default.execute(2, new Object[] {A50PurchaseOrderId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A15ProductId = H003K4_A15ProductId[0];
               A55ProductCode = H003K4_A55ProductCode[0];
               n55ProductCode = H003K4_n55ProductCode[0];
               A85ProductCostPrice = H003K4_A85ProductCostPrice[0];
               n85ProductCostPrice = H003K4_n85ProductCostPrice[0];
               A16ProductName = H003K4_A16ProductName[0];
               A76PurchaseOrderDetailQuantityOrd = H003K4_A76PurchaseOrderDetailQuantityOrd[0];
               A55ProductCode = H003K4_A55ProductCode[0];
               n55ProductCode = H003K4_n55ProductCode[0];
               A85ProductCostPrice = H003K4_A85ProductCostPrice[0];
               n85ProductCostPrice = H003K4_n85ProductCostPrice[0];
               A16ProductName = H003K4_A16ProductName[0];
               AV35SDTPurchaseOrderDetailsItem = new SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem(context);
               AV35SDTPurchaseOrderDetailsItem.gxTpr_Id = A15ProductId;
               AV35SDTPurchaseOrderDetailsItem.gxTpr_Code = A55ProductCode;
               AV35SDTPurchaseOrderDetailsItem.gxTpr_Productcostprice = A85ProductCostPrice;
               AV35SDTPurchaseOrderDetailsItem.gxTpr_Newcostprice = A85ProductCostPrice;
               AV35SDTPurchaseOrderDetailsItem.gxTpr_Name = A16ProductName;
               AV35SDTPurchaseOrderDetailsItem.gxTpr_Quantityordered = A76PurchaseOrderDetailQuantityOrd;
               AV35SDTPurchaseOrderDetailsItem.gxTpr_Quantityreceived = A76PurchaseOrderDetailQuantityOrd;
               AV37SDTPurchaseOrderDetails.Add(AV35SDTPurchaseOrderDetailsItem, 0);
               gx_BV31 = true;
               pr_default.readNext(2);
            }
            pr_default.close(2);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
      }

      protected void S172( )
      {
         /* 'CONTROLCONFIRM' Routine */
         returnInSub = false;
         AV42ControlPassed = false;
         AssignAttri("", false, "AV42ControlPassed", AV42ControlPassed);
         AV71GXV9 = 1;
         while ( AV71GXV9 <= AV37SDTPurchaseOrderDetails.Count )
         {
            AV35SDTPurchaseOrderDetailsItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV37SDTPurchaseOrderDetails.Item(AV71GXV9));
            if ( AV35SDTPurchaseOrderDetailsItem.gxTpr_Quantityreceived > 0 )
            {
               AV42ControlPassed = true;
               AssignAttri("", false, "AV42ControlPassed", AV42ControlPassed);
            }
            AV71GXV9 = (int)(AV71GXV9+1);
         }
         if ( ! AV42ControlPassed )
         {
            GX_msglist.addItem("If you want Confirm this order, must be indicate at least one quantity available distinct at zero");
         }
         if ( AV42ControlPassed )
         {
            AV72GXV10 = 1;
            while ( AV72GXV10 <= AV37SDTPurchaseOrderDetails.Count )
            {
               AV35SDTPurchaseOrderDetailsItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV37SDTPurchaseOrderDetails.Item(AV72GXV10));
               if ( AV35SDTPurchaseOrderDetailsItem.gxTpr_Quantityreceived < 0 )
               {
                  AV42ControlPassed = false;
                  AssignAttri("", false, "AV42ControlPassed", AV42ControlPassed);
               }
               AV72GXV10 = (int)(AV72GXV10+1);
            }
         }
         if ( ! AV42ControlPassed )
         {
            GX_msglist.addItem("Quantities available must be equal or higher than zero");
         }
      }

      protected void S142( )
      {
         /* 'CONTROLCANCEL' Routine */
         returnInSub = false;
         AV42ControlPassed = false;
         AssignAttri("", false, "AV42ControlPassed", AV42ControlPassed);
         /* Using cursor H003K5 */
         pr_default.execute(3, new Object[] {AV12PurchaseOrderId});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A79PurchaseOrderActive = H003K5_A79PurchaseOrderActive[0];
            A50PurchaseOrderId = H003K5_A50PurchaseOrderId[0];
            AV42ControlPassed = true;
            AssignAttri("", false, "AV42ControlPassed", AV42ControlPassed);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(3);
         if ( ! AV42ControlPassed )
         {
            GX_msglist.addItem("Cancel Order Failed");
         }
         AV44PurchaseOrderCanceledDescription = StringUtil.LTrim( StringUtil.RTrim( AV44PurchaseOrderCanceledDescription));
         AssignAttri("", false, "AV44PurchaseOrderCanceledDescription", AV44PurchaseOrderCanceledDescription);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44PurchaseOrderCanceledDescription)) )
         {
            GX_msglist.addItem("To Cancel the order, must be indicate a reason");
            AV42ControlPassed = false;
            AssignAttri("", false, "AV42ControlPassed", AV42ControlPassed);
         }
      }

      protected void S122( )
      {
         /* 'HIDETABLES' Routine */
         returnInSub = false;
         divTableorderconfirm_Visible = 0;
         AssignProp("", false, divTableorderconfirm_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableorderconfirm_Visible), 5, 0), true);
         divTableorderconfirmed_Visible = 0;
         AssignProp("", false, divTableorderconfirmed_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableorderconfirmed_Visible), 5, 0), true);
         divTableordercancel_Visible = 0;
         AssignProp("", false, divTableordercancel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableordercancel_Visible), 5, 0), true);
         divTableordercanceled_Visible = 0;
         AssignProp("", false, divTableordercanceled_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableordercanceled_Visible), 5, 0), true);
      }

      protected void S132( )
      {
         /* 'CALCULATETOTAL' Routine */
         returnInSub = false;
         AV41TotalProjected = 0;
         AssignAttri("", false, "AV41TotalProjected", StringUtil.LTrimStr( AV41TotalProjected, 18, 2));
         AV74GXV11 = 1;
         while ( AV74GXV11 <= AV37SDTPurchaseOrderDetails.Count )
         {
            AV35SDTPurchaseOrderDetailsItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV37SDTPurchaseOrderDetails.Item(AV74GXV11));
            AV57CostPriceAux = ((AV35SDTPurchaseOrderDetailsItem.gxTpr_Newcostprice!=Convert.ToDecimal(0))&&!(Convert.ToDecimal(0)==AV35SDTPurchaseOrderDetailsItem.gxTpr_Newcostprice) ? AV35SDTPurchaseOrderDetailsItem.gxTpr_Newcostprice : AV35SDTPurchaseOrderDetailsItem.gxTpr_Productcostprice);
            AV35SDTPurchaseOrderDetailsItem.gxTpr_Subtotal = (decimal)(AV57CostPriceAux*AV35SDTPurchaseOrderDetailsItem.gxTpr_Quantityreceived);
            AV41TotalProjected = (decimal)(AV41TotalProjected+(AV35SDTPurchaseOrderDetailsItem.gxTpr_Subtotal));
            AssignAttri("", false, "AV41TotalProjected", StringUtil.LTrimStr( AV41TotalProjected, 18, 2));
            AV74GXV11 = (int)(AV74GXV11+1);
         }
      }

      protected void S152( )
      {
         /* 'DISABLEDBUTTONS' Routine */
         returnInSub = false;
         bttCancelorder_Enabled = 0;
         AssignProp("", false, bttCancelorder_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttCancelorder_Enabled), 5, 0), true);
         bttCancelorder_Visible = 0;
         AssignProp("", false, bttCancelorder_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttCancelorder_Visible), 5, 0), true);
         bttConfirmorder_Enabled = 0;
         AssignProp("", false, bttConfirmorder_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttConfirmorder_Enabled), 5, 0), true);
         bttConfirmorder_Visible = 0;
         AssignProp("", false, bttConfirmorder_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttConfirmorder_Visible), 5, 0), true);
      }

      protected void S182( )
      {
         /* 'CREATEBODYEMAILCONFIRM' Routine */
         returnInSub = false;
         AV49EmailTitle = "Order Confirmated";
         AssignAttri("", false, "AV49EmailTitle", AV49EmailTitle);
         AV50EmailSubtitle = AV15SupplierName + " has been confirm an Order";
         AssignAttri("", false, "AV50EmailSubtitle", AV50EmailSubtitle);
         AV17ConfirmedDate = DateTimeUtil.ServerDate( context, pr_default);
         AV14EmailBody = "                <table class=\"table table-border table-striped\">";
         AssignAttri("", false, "AV14EmailBody", AV14EmailBody);
         AV14EmailBody += "                    <tr>";
         AssignAttri("", false, "AV14EmailBody", AV14EmailBody);
         AV14EmailBody += "                        <td style=\"text-align:left;\"><strong>Nro Order</strong></td>";
         AssignAttri("", false, "AV14EmailBody", AV14EmailBody);
         AV14EmailBody += "                        <td>" + StringUtil.Str( (decimal)(AV12PurchaseOrderId), 6, 0) + "</td>";
         AssignAttri("", false, "AV14EmailBody", AV14EmailBody);
         AV14EmailBody += "                    </tr>";
         AssignAttri("", false, "AV14EmailBody", AV14EmailBody);
         AV14EmailBody += "                    <tr>";
         AssignAttri("", false, "AV14EmailBody", AV14EmailBody);
         AV14EmailBody += "                        <td style=\"text-align:left;\"><strong>Created Date</strong></td>";
         AssignAttri("", false, "AV14EmailBody", AV14EmailBody);
         AV14EmailBody += "                        <td>";
         AssignAttri("", false, "AV14EmailBody", AV14EmailBody);
         AV14EmailBody += context.localUtil.Format( AV16PurchaseOrderCreatedDate, "99/99/99");
         AssignAttri("", false, "AV14EmailBody", AV14EmailBody);
         AV14EmailBody += "					</td>";
         AssignAttri("", false, "AV14EmailBody", AV14EmailBody);
         AV14EmailBody += "                    </tr>";
         AssignAttri("", false, "AV14EmailBody", AV14EmailBody);
         AV14EmailBody += "                    <tr>";
         AssignAttri("", false, "AV14EmailBody", AV14EmailBody);
         AV14EmailBody += "                        <td style=\"text-align:left;\"><strong>Confirmated Date</strong></td>";
         AssignAttri("", false, "AV14EmailBody", AV14EmailBody);
         AV14EmailBody += "                        <td>";
         AssignAttri("", false, "AV14EmailBody", AV14EmailBody);
         AV14EmailBody += context.localUtil.Format( AV17ConfirmedDate, "99/99/9999");
         AssignAttri("", false, "AV14EmailBody", AV14EmailBody);
         AV14EmailBody += "					</td>";
         AssignAttri("", false, "AV14EmailBody", AV14EmailBody);
         AV14EmailBody += "                    </tr>";
         AssignAttri("", false, "AV14EmailBody", AV14EmailBody);
         AV14EmailBody += "                </table>";
         AssignAttri("", false, "AV14EmailBody", AV14EmailBody);
      }

      protected void S162( )
      {
         /* 'CREATEBOBYEMAILCANCEL' Routine */
         returnInSub = false;
         AV49EmailTitle = "Order Canceled";
         AssignAttri("", false, "AV49EmailTitle", AV49EmailTitle);
         AV50EmailSubtitle = AV15SupplierName + " has canceled an Order";
         AssignAttri("", false, "AV50EmailSubtitle", AV50EmailSubtitle);
         AV46CanceledDate = DateTimeUtil.ServerDate( context, pr_default);
         AV14EmailBody = "                <table class=\"table table-border table-striped\">";
         AssignAttri("", false, "AV14EmailBody", AV14EmailBody);
         AV14EmailBody += "                    <tr>";
         AssignAttri("", false, "AV14EmailBody", AV14EmailBody);
         AV14EmailBody += "                        <td style=\"text-align:left;\"><strong>Nro Order</strong></td>";
         AssignAttri("", false, "AV14EmailBody", AV14EmailBody);
         AV14EmailBody += "                        <td>" + StringUtil.Str( (decimal)(AV12PurchaseOrderId), 6, 0) + "</td>";
         AssignAttri("", false, "AV14EmailBody", AV14EmailBody);
         AV14EmailBody += "                    </tr>";
         AssignAttri("", false, "AV14EmailBody", AV14EmailBody);
         AV14EmailBody += "                    <tr>";
         AssignAttri("", false, "AV14EmailBody", AV14EmailBody);
         AV14EmailBody += "                        <td style=\"text-align:left;\"><strong>Created Date</strong></td>";
         AssignAttri("", false, "AV14EmailBody", AV14EmailBody);
         AV14EmailBody += "                        <td>";
         AssignAttri("", false, "AV14EmailBody", AV14EmailBody);
         AV14EmailBody += context.localUtil.Format( AV16PurchaseOrderCreatedDate, "99/99/99");
         AssignAttri("", false, "AV14EmailBody", AV14EmailBody);
         AV14EmailBody += "					</td>";
         AssignAttri("", false, "AV14EmailBody", AV14EmailBody);
         AV14EmailBody += "                    </tr>";
         AssignAttri("", false, "AV14EmailBody", AV14EmailBody);
         AV14EmailBody += "                    <tr>";
         AssignAttri("", false, "AV14EmailBody", AV14EmailBody);
         AV14EmailBody += "                        <td style=\"text-align:left;\"><strong>Canceled Date</strong></td>";
         AssignAttri("", false, "AV14EmailBody", AV14EmailBody);
         AV14EmailBody += "                        <td>";
         AssignAttri("", false, "AV14EmailBody", AV14EmailBody);
         AV14EmailBody += context.localUtil.Format( AV46CanceledDate, "99/99/99");
         AssignAttri("", false, "AV14EmailBody", AV14EmailBody);
         AV14EmailBody += "					</td>";
         AssignAttri("", false, "AV14EmailBody", AV14EmailBody);
         AV14EmailBody += "                    </tr>";
         AssignAttri("", false, "AV14EmailBody", AV14EmailBody);
         AV14EmailBody += "                    <tr>";
         AssignAttri("", false, "AV14EmailBody", AV14EmailBody);
         AV14EmailBody += "                        <td style=\"text-align:left;\"><strong>Reason</strong></td>";
         AssignAttri("", false, "AV14EmailBody", AV14EmailBody);
         AV14EmailBody += "                        <td>" + AV44PurchaseOrderCanceledDescription + "</td>";
         AssignAttri("", false, "AV14EmailBody", AV14EmailBody);
         AV14EmailBody += "                    </tr>";
         AssignAttri("", false, "AV14EmailBody", AV14EmailBody);
         AV14EmailBody += "                </table>";
         AssignAttri("", false, "AV14EmailBody", AV14EmailBody);
      }

      private void E173K2( )
      {
         /* Gridpurchaseorderdetails_Load Routine */
         returnInSub = false;
         AV60GXV1 = 1;
         while ( AV60GXV1 <= AV37SDTPurchaseOrderDetails.Count )
         {
            AV37SDTPurchaseOrderDetails.CurrentItem = ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV37SDTPurchaseOrderDetails.Item(AV60GXV1));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 31;
            }
            sendrow_312( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_31_Refreshing )
            {
               DoAjaxLoad(31, GridpurchaseorderdetailsRow);
            }
            AV60GXV1 = (int)(AV60GXV1+1);
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV12PurchaseOrderId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV12PurchaseOrderId", StringUtil.LTrimStr( (decimal)(AV12PurchaseOrderId), 6, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vPURCHASEORDERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12PurchaseOrderId), "ZZZZZ9"), context));
         AV25MesaggeError = (string)getParm(obj,1);
         AssignAttri("", false, "AV25MesaggeError", AV25MesaggeError);
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
         PA3K2( ) ;
         WS3K2( ) ;
         WE3K2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20241292465765", true, true);
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
         context.AddJavascriptSource("purchaseordersupplierview.js", "?20241292465765", false, true);
         context.AddJavascriptSource("UserControls/UCProbamosLoaderRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_312( )
      {
         edtavCtlcode_Internalname = "CTLCODE_"+sGXsfl_31_idx;
         edtavCtlname_Internalname = "CTLNAME_"+sGXsfl_31_idx;
         edtavCtlquantityordered_Internalname = "CTLQUANTITYORDERED_"+sGXsfl_31_idx;
         edtavCtlquantityreceived_Internalname = "CTLQUANTITYRECEIVED_"+sGXsfl_31_idx;
         edtavCtlproductcostprice_Internalname = "CTLPRODUCTCOSTPRICE_"+sGXsfl_31_idx;
         edtavCtlnewcostprice_Internalname = "CTLNEWCOSTPRICE_"+sGXsfl_31_idx;
         edtavCtlsubtotal_Internalname = "CTLSUBTOTAL_"+sGXsfl_31_idx;
      }

      protected void SubsflControlProps_fel_312( )
      {
         edtavCtlcode_Internalname = "CTLCODE_"+sGXsfl_31_fel_idx;
         edtavCtlname_Internalname = "CTLNAME_"+sGXsfl_31_fel_idx;
         edtavCtlquantityordered_Internalname = "CTLQUANTITYORDERED_"+sGXsfl_31_fel_idx;
         edtavCtlquantityreceived_Internalname = "CTLQUANTITYRECEIVED_"+sGXsfl_31_fel_idx;
         edtavCtlproductcostprice_Internalname = "CTLPRODUCTCOSTPRICE_"+sGXsfl_31_fel_idx;
         edtavCtlnewcostprice_Internalname = "CTLNEWCOSTPRICE_"+sGXsfl_31_fel_idx;
         edtavCtlsubtotal_Internalname = "CTLSUBTOTAL_"+sGXsfl_31_fel_idx;
      }

      protected void sendrow_312( )
      {
         SubsflControlProps_312( ) ;
         WB3K0( ) ;
         GridpurchaseorderdetailsRow = GXWebRow.GetNew(context,GridpurchaseorderdetailsContainer);
         if ( subGridpurchaseorderdetails_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridpurchaseorderdetails_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridpurchaseorderdetails_Class, "") != 0 )
            {
               subGridpurchaseorderdetails_Linesclass = subGridpurchaseorderdetails_Class+"Odd";
            }
         }
         else if ( subGridpurchaseorderdetails_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridpurchaseorderdetails_Backstyle = 0;
            subGridpurchaseorderdetails_Backcolor = subGridpurchaseorderdetails_Allbackcolor;
            if ( StringUtil.StrCmp(subGridpurchaseorderdetails_Class, "") != 0 )
            {
               subGridpurchaseorderdetails_Linesclass = subGridpurchaseorderdetails_Class+"Uniform";
            }
         }
         else if ( subGridpurchaseorderdetails_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridpurchaseorderdetails_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridpurchaseorderdetails_Class, "") != 0 )
            {
               subGridpurchaseorderdetails_Linesclass = subGridpurchaseorderdetails_Class+"Odd";
            }
            subGridpurchaseorderdetails_Backcolor = (int)(0x0);
         }
         else if ( subGridpurchaseorderdetails_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridpurchaseorderdetails_Backstyle = 1;
            if ( ((int)((nGXsfl_31_idx) % (2))) == 0 )
            {
               subGridpurchaseorderdetails_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridpurchaseorderdetails_Class, "") != 0 )
               {
                  subGridpurchaseorderdetails_Linesclass = subGridpurchaseorderdetails_Class+"Even";
               }
            }
            else
            {
               subGridpurchaseorderdetails_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridpurchaseorderdetails_Class, "") != 0 )
               {
                  subGridpurchaseorderdetails_Linesclass = subGridpurchaseorderdetails_Class+"Odd";
               }
            }
         }
         if ( GridpurchaseorderdetailsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr ") ;
            context.WriteHtmlText( " class=\""+"PromptGrid"+"\" style=\""+""+"\"") ;
            context.WriteHtmlText( " gxrow=\""+sGXsfl_31_idx+"\">") ;
         }
         /* Subfile cell */
         if ( GridpurchaseorderdetailsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridpurchaseorderdetailsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcode_Internalname,((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV37SDTPurchaseOrderDetails.Item(AV60GXV1)).gxTpr_Code,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcode_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlcode_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)31,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridpurchaseorderdetailsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridpurchaseorderdetailsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname_Internalname,((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV37SDTPurchaseOrderDetails.Item(AV60GXV1)).gxTpr_Name,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)31,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridpurchaseorderdetailsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridpurchaseorderdetailsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlquantityordered_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV37SDTPurchaseOrderDetails.Item(AV60GXV1)).gxTpr_Quantityordered), 6, 0, ".", "")),StringUtil.LTrim( ((edtavCtlquantityordered_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV37SDTPurchaseOrderDetails.Item(AV60GXV1)).gxTpr_Quantityordered), "ZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV37SDTPurchaseOrderDetails.Item(AV60GXV1)).gxTpr_Quantityordered), "ZZZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlquantityordered_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlquantityordered_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)31,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( GridpurchaseorderdetailsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavCtlquantityreceived_Enabled!=0)&&(edtavCtlquantityreceived_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 35,'',false,'"+sGXsfl_31_idx+"',31)\"" : " ");
         ROClassString = "Attribute";
         GridpurchaseorderdetailsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlquantityreceived_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV37SDTPurchaseOrderDetails.Item(AV60GXV1)).gxTpr_Quantityreceived), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV37SDTPurchaseOrderDetails.Item(AV60GXV1)).gxTpr_Quantityreceived), "ZZZZZ9"))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+((edtavCtlquantityreceived_Enabled!=0)&&(edtavCtlquantityreceived_Visible!=0) ? " onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,35);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlquantityreceived_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)1,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)31,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( GridpurchaseorderdetailsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridpurchaseorderdetailsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlproductcostprice_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV37SDTPurchaseOrderDetails.Item(AV60GXV1)).gxTpr_Productcostprice, 18, 2, ".", "")),StringUtil.LTrim( ((edtavCtlproductcostprice_Enabled!=0) ? context.localUtil.Format( ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV37SDTPurchaseOrderDetails.Item(AV60GXV1)).gxTpr_Productcostprice, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV37SDTPurchaseOrderDetails.Item(AV60GXV1)).gxTpr_Productcostprice, "ZZZZZZZZZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlproductcostprice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlproductcostprice_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)31,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( GridpurchaseorderdetailsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavCtlnewcostprice_Enabled!=0)&&(edtavCtlnewcostprice_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 37,'',false,'"+sGXsfl_31_idx+"',31)\"" : " ");
         ROClassString = "Attribute";
         GridpurchaseorderdetailsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlnewcostprice_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV37SDTPurchaseOrderDetails.Item(AV60GXV1)).gxTpr_Newcostprice, 18, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV37SDTPurchaseOrderDetails.Item(AV60GXV1)).gxTpr_Newcostprice, "ZZZZZZZZZZZZZZ9.99")),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+((edtavCtlnewcostprice_Enabled!=0)&&(edtavCtlnewcostprice_Visible!=0) ? " onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,37);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlnewcostprice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)1,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)31,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( GridpurchaseorderdetailsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridpurchaseorderdetailsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsubtotal_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV37SDTPurchaseOrderDetails.Item(AV60GXV1)).gxTpr_Subtotal, 18, 2, ".", "")),StringUtil.LTrim( ((edtavCtlsubtotal_Enabled!=0) ? context.localUtil.Format( ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV37SDTPurchaseOrderDetails.Item(AV60GXV1)).gxTpr_Subtotal, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem)AV37SDTPurchaseOrderDetails.Item(AV60GXV1)).gxTpr_Subtotal, "ZZZZZZZZZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlsubtotal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlsubtotal_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)31,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         send_integrity_lvl_hashes3K2( ) ;
         GridpurchaseorderdetailsContainer.AddRow(GridpurchaseorderdetailsRow);
         nGXsfl_31_idx = ((subGridpurchaseorderdetails_Islastpage==1)&&(nGXsfl_31_idx+1>subGridpurchaseorderdetails_fnc_Recordsperpage( )) ? 1 : nGXsfl_31_idx+1);
         sGXsfl_31_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_31_idx), 4, 0), 4, "0");
         SubsflControlProps_312( ) ;
         /* End function sendrow_312 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl31( )
      {
         if ( GridpurchaseorderdetailsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridpurchaseorderdetailsContainer"+"DivS\" data-gxgridid=\"31\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridpurchaseorderdetails_Internalname, subGridpurchaseorderdetails_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGridpurchaseorderdetails_Backcolorstyle == 0 )
            {
               subGridpurchaseorderdetails_Titlebackstyle = 0;
               if ( StringUtil.Len( subGridpurchaseorderdetails_Class) > 0 )
               {
                  subGridpurchaseorderdetails_Linesclass = subGridpurchaseorderdetails_Class+"Title";
               }
            }
            else
            {
               subGridpurchaseorderdetails_Titlebackstyle = 1;
               if ( subGridpurchaseorderdetails_Backcolorstyle == 1 )
               {
                  subGridpurchaseorderdetails_Titlebackcolor = subGridpurchaseorderdetails_Allbackcolor;
                  if ( StringUtil.Len( subGridpurchaseorderdetails_Class) > 0 )
                  {
                     subGridpurchaseorderdetails_Linesclass = subGridpurchaseorderdetails_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGridpurchaseorderdetails_Class) > 0 )
                  {
                     subGridpurchaseorderdetails_Linesclass = subGridpurchaseorderdetails_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Code") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Quantity Ordered") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Quantity Available") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Current Cost Price") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Price Suggest") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Subtotal") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridpurchaseorderdetailsContainer.AddObjectProperty("GridName", "Gridpurchaseorderdetails");
         }
         else
         {
            GridpurchaseorderdetailsContainer.AddObjectProperty("GridName", "Gridpurchaseorderdetails");
            GridpurchaseorderdetailsContainer.AddObjectProperty("Header", subGridpurchaseorderdetails_Header);
            GridpurchaseorderdetailsContainer.AddObjectProperty("Class", "PromptGrid");
            GridpurchaseorderdetailsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridpurchaseorderdetailsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridpurchaseorderdetailsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpurchaseorderdetails_Backcolorstyle), 1, 0, ".", "")));
            GridpurchaseorderdetailsContainer.AddObjectProperty("CmpContext", "");
            GridpurchaseorderdetailsContainer.AddObjectProperty("InMasterPage", "false");
            GridpurchaseorderdetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridpurchaseorderdetailsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlcode_Enabled), 5, 0, ".", "")));
            GridpurchaseorderdetailsContainer.AddColumnProperties(GridpurchaseorderdetailsColumn);
            GridpurchaseorderdetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridpurchaseorderdetailsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlname_Enabled), 5, 0, ".", "")));
            GridpurchaseorderdetailsContainer.AddColumnProperties(GridpurchaseorderdetailsColumn);
            GridpurchaseorderdetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridpurchaseorderdetailsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlquantityordered_Enabled), 5, 0, ".", "")));
            GridpurchaseorderdetailsContainer.AddColumnProperties(GridpurchaseorderdetailsColumn);
            GridpurchaseorderdetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridpurchaseorderdetailsContainer.AddColumnProperties(GridpurchaseorderdetailsColumn);
            GridpurchaseorderdetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridpurchaseorderdetailsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlproductcostprice_Enabled), 5, 0, ".", "")));
            GridpurchaseorderdetailsContainer.AddColumnProperties(GridpurchaseorderdetailsColumn);
            GridpurchaseorderdetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridpurchaseorderdetailsContainer.AddColumnProperties(GridpurchaseorderdetailsColumn);
            GridpurchaseorderdetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridpurchaseorderdetailsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlsubtotal_Enabled), 5, 0, ".", "")));
            GridpurchaseorderdetailsContainer.AddColumnProperties(GridpurchaseorderdetailsColumn);
            GridpurchaseorderdetailsContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpurchaseorderdetails_Selectedindex), 4, 0, ".", "")));
            GridpurchaseorderdetailsContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpurchaseorderdetails_Allowselection), 1, 0, ".", "")));
            GridpurchaseorderdetailsContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpurchaseorderdetails_Selectioncolor), 9, 0, ".", "")));
            GridpurchaseorderdetailsContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpurchaseorderdetails_Allowhovering), 1, 0, ".", "")));
            GridpurchaseorderdetailsContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpurchaseorderdetails_Hoveringcolor), 9, 0, ".", "")));
            GridpurchaseorderdetailsContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpurchaseorderdetails_Allowcollapsing), 1, 0, ".", "")));
            GridpurchaseorderdetailsContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpurchaseorderdetails_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblTitletext_Internalname = "TITLETEXT";
         divTable2_Internalname = "TABLE2";
         edtavPurchaseordercreateddate_Internalname = "vPURCHASEORDERCREATEDDATE";
         edtavTotalprojected_Internalname = "vTOTALPROJECTED";
         bttConfirmorder_Internalname = "CONFIRMORDER";
         edtavCtlcode_Internalname = "CTLCODE";
         edtavCtlname_Internalname = "CTLNAME";
         edtavCtlquantityordered_Internalname = "CTLQUANTITYORDERED";
         edtavCtlquantityreceived_Internalname = "CTLQUANTITYRECEIVED";
         edtavCtlproductcostprice_Internalname = "CTLPRODUCTCOSTPRICE";
         edtavCtlnewcostprice_Internalname = "CTLNEWCOSTPRICE";
         edtavCtlsubtotal_Internalname = "CTLSUBTOTAL";
         divTable1_Internalname = "TABLE1";
         divTableorderconfirm_Internalname = "TABLEORDERCONFIRM";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         bttOrderconfirmatedexit_Internalname = "ORDERCONFIRMATEDEXIT";
         divTableorderconfirmed_Internalname = "TABLEORDERCONFIRMED";
         edtavPurchaseordercanceleddescription_Internalname = "vPURCHASEORDERCANCELEDDESCRIPTION";
         bttCancelorder_Internalname = "CANCELORDER";
         divTableordercancel_Internalname = "TABLEORDERCANCEL";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         bttOrdercanceledexit_Internalname = "ORDERCANCELEDEXIT";
         divTableordercanceled_Internalname = "TABLEORDERCANCELED";
         Ucprobamosloader1_Internalname = "UCPROBAMOSLOADER1";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGridpurchaseorderdetails_Internalname = "GRIDPURCHASEORDERDETAILS";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("mtaKB", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridpurchaseorderdetails_Allowcollapsing = 0;
         subGridpurchaseorderdetails_Allowselection = 0;
         subGridpurchaseorderdetails_Header = "";
         edtavCtlsubtotal_Jsonclick = "";
         edtavCtlsubtotal_Enabled = 0;
         edtavCtlnewcostprice_Jsonclick = "";
         edtavCtlnewcostprice_Visible = -1;
         edtavCtlnewcostprice_Enabled = 1;
         edtavCtlproductcostprice_Jsonclick = "";
         edtavCtlproductcostprice_Enabled = 0;
         edtavCtlquantityreceived_Jsonclick = "";
         edtavCtlquantityreceived_Visible = -1;
         edtavCtlquantityreceived_Enabled = 1;
         edtavCtlquantityordered_Jsonclick = "";
         edtavCtlquantityordered_Enabled = 0;
         edtavCtlname_Jsonclick = "";
         edtavCtlname_Enabled = 0;
         edtavCtlcode_Jsonclick = "";
         edtavCtlcode_Enabled = 0;
         subGridpurchaseorderdetails_Class = "PromptGrid";
         subGridpurchaseorderdetails_Backcolorstyle = 0;
         edtavCtlsubtotal_Enabled = -1;
         edtavCtlproductcostprice_Enabled = -1;
         edtavCtlquantityordered_Enabled = -1;
         edtavCtlname_Enabled = -1;
         edtavCtlcode_Enabled = -1;
         divTableordercanceled_Visible = 1;
         bttCancelorder_Enabled = 1;
         bttCancelorder_Visible = 1;
         edtavPurchaseordercanceleddescription_Enabled = 1;
         divTableordercancel_Visible = 1;
         divTableorderconfirmed_Visible = 1;
         bttConfirmorder_Enabled = 1;
         bttConfirmorder_Visible = 1;
         edtavTotalprojected_Jsonclick = "";
         edtavTotalprojected_Enabled = 1;
         edtavPurchaseordercreateddate_Jsonclick = "";
         edtavPurchaseordercreateddate_Enabled = 1;
         divTableorderconfirm_Visible = 1;
         lblTitletext_Caption = "Purchase Order to";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Purchase Order Supplier View";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRIDPURCHASEORDERDETAILS_nFirstRecordOnPage'},{av:'GRIDPURCHASEORDERDETAILS_nEOF'},{av:'AV37SDTPurchaseOrderDetails',fld:'vSDTPURCHASEORDERDETAILS',grid:31,pic:''},{av:'nGXsfl_31_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:31},{av:'nRC_GXsfl_31',ctrl:'GRIDPURCHASEORDERDETAILS',prop:'GridRC',grid:31},{av:'AV12PurchaseOrderId',fld:'vPURCHASEORDERID',pic:'ZZZZZ9',hsh:true},{av:'AV18MeEmail',fld:'vMEEMAIL',pic:'',hsh:true},{av:'AV15SupplierName',fld:'vSUPPLIERNAME',pic:'',hsh:true},{av:'AV16PurchaseOrderCreatedDate',fld:'vPURCHASEORDERCREATEDDATE',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("GRIDPURCHASEORDERDETAILS.REFRESH","{handler:'E163K2',iparms:[{av:'AV37SDTPurchaseOrderDetails',fld:'vSDTPURCHASEORDERDETAILS',grid:31,pic:''},{av:'nGXsfl_31_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:31},{av:'GRIDPURCHASEORDERDETAILS_nFirstRecordOnPage'},{av:'nRC_GXsfl_31',ctrl:'GRIDPURCHASEORDERDETAILS',prop:'GridRC',grid:31},{av:'GRIDPURCHASEORDERDETAILS_nEOF'},{av:'AV12PurchaseOrderId',fld:'vPURCHASEORDERID',pic:'ZZZZZ9',hsh:true},{av:'AV18MeEmail',fld:'vMEEMAIL',pic:'',hsh:true},{av:'AV15SupplierName',fld:'vSUPPLIERNAME',pic:'',hsh:true},{av:'AV16PurchaseOrderCreatedDate',fld:'vPURCHASEORDERCREATEDDATE',pic:'',hsh:true}]");
         setEventMetadata("GRIDPURCHASEORDERDETAILS.REFRESH",",oparms:[{av:'AV41TotalProjected',fld:'vTOTALPROJECTED',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV37SDTPurchaseOrderDetails',fld:'vSDTPURCHASEORDERDETAILS',grid:31,pic:''},{av:'nGXsfl_31_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:31},{av:'GRIDPURCHASEORDERDETAILS_nFirstRecordOnPage'},{av:'nRC_GXsfl_31',ctrl:'GRIDPURCHASEORDERDETAILS',prop:'GridRC',grid:31}]}");
         setEventMetadata("'CANCELORDER'","{handler:'E133K2',iparms:[{av:'AV42ControlPassed',fld:'vCONTROLPASSED',pic:''},{av:'AV12PurchaseOrderId',fld:'vPURCHASEORDERID',pic:'ZZZZZ9',hsh:true},{av:'AV37SDTPurchaseOrderDetails',fld:'vSDTPURCHASEORDERDETAILS',grid:31,pic:''},{av:'nGXsfl_31_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:31},{av:'GRIDPURCHASEORDERDETAILS_nFirstRecordOnPage'},{av:'nRC_GXsfl_31',ctrl:'GRIDPURCHASEORDERDETAILS',prop:'GridRC',grid:31},{av:'AV44PurchaseOrderCanceledDescription',fld:'vPURCHASEORDERCANCELEDDESCRIPTION',pic:''},{av:'AV20NamesOfAttachs',fld:'vNAMESOFATTACHS',pic:''},{av:'AV49EmailTitle',fld:'vEMAILTITLE',pic:''},{av:'AV50EmailSubtitle',fld:'vEMAILSUBTITLE',pic:''},{av:'AV18MeEmail',fld:'vMEEMAIL',pic:'',hsh:true},{av:'AV21AllOk',fld:'vALLOK',pic:''},{av:'A50PurchaseOrderId',fld:'PURCHASEORDERID',pic:'ZZZZZ9'},{av:'A79PurchaseOrderActive',fld:'PURCHASEORDERACTIVE',pic:''},{av:'AV15SupplierName',fld:'vSUPPLIERNAME',pic:'',hsh:true},{av:'AV16PurchaseOrderCreatedDate',fld:'vPURCHASEORDERCREATEDDATE',pic:'',hsh:true}]");
         setEventMetadata("'CANCELORDER'",",oparms:[{av:'AV14EmailBody',fld:'vEMAILBODY',pic:''},{av:'AV20NamesOfAttachs',fld:'vNAMESOFATTACHS',pic:''},{av:'AV21AllOk',fld:'vALLOK',pic:''},{av:'divTableordercanceled_Visible',ctrl:'TABLEORDERCANCELED',prop:'Visible'},{av:'AV42ControlPassed',fld:'vCONTROLPASSED',pic:''},{av:'AV44PurchaseOrderCanceledDescription',fld:'vPURCHASEORDERCANCELEDDESCRIPTION',pic:''},{ctrl:'CANCELORDER',prop:'Enabled'},{ctrl:'CANCELORDER',prop:'Visible'},{ctrl:'CONFIRMORDER',prop:'Enabled'},{ctrl:'CONFIRMORDER',prop:'Visible'},{av:'divTableorderconfirm_Visible',ctrl:'TABLEORDERCONFIRM',prop:'Visible'},{av:'divTableorderconfirmed_Visible',ctrl:'TABLEORDERCONFIRMED',prop:'Visible'},{av:'divTableordercancel_Visible',ctrl:'TABLEORDERCANCEL',prop:'Visible'},{av:'AV49EmailTitle',fld:'vEMAILTITLE',pic:''},{av:'AV50EmailSubtitle',fld:'vEMAILSUBTITLE',pic:''}]}");
         setEventMetadata("'CONFIRMORDER'","{handler:'E143K2',iparms:[{av:'AV42ControlPassed',fld:'vCONTROLPASSED',pic:''},{av:'AV12PurchaseOrderId',fld:'vPURCHASEORDERID',pic:'ZZZZZ9',hsh:true},{av:'AV37SDTPurchaseOrderDetails',fld:'vSDTPURCHASEORDERDETAILS',grid:31,pic:''},{av:'nGXsfl_31_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:31},{av:'GRIDPURCHASEORDERDETAILS_nFirstRecordOnPage'},{av:'nRC_GXsfl_31',ctrl:'GRIDPURCHASEORDERDETAILS',prop:'GridRC',grid:31},{av:'AV44PurchaseOrderCanceledDescription',fld:'vPURCHASEORDERCANCELEDDESCRIPTION',pic:''},{av:'AV20NamesOfAttachs',fld:'vNAMESOFATTACHS',pic:''},{av:'AV49EmailTitle',fld:'vEMAILTITLE',pic:''},{av:'AV50EmailSubtitle',fld:'vEMAILSUBTITLE',pic:''},{av:'AV14EmailBody',fld:'vEMAILBODY',pic:''},{av:'AV18MeEmail',fld:'vMEEMAIL',pic:'',hsh:true},{av:'AV21AllOk',fld:'vALLOK',pic:''},{av:'AV15SupplierName',fld:'vSUPPLIERNAME',pic:'',hsh:true},{av:'AV16PurchaseOrderCreatedDate',fld:'vPURCHASEORDERCREATEDDATE',pic:'',hsh:true}]");
         setEventMetadata("'CONFIRMORDER'",",oparms:[{av:'AV20NamesOfAttachs',fld:'vNAMESOFATTACHS',pic:''},{av:'AV14EmailBody',fld:'vEMAILBODY',pic:''},{av:'AV21AllOk',fld:'vALLOK',pic:''},{av:'divTableorderconfirmed_Visible',ctrl:'TABLEORDERCONFIRMED',prop:'Visible'},{av:'AV42ControlPassed',fld:'vCONTROLPASSED',pic:''},{ctrl:'CANCELORDER',prop:'Enabled'},{ctrl:'CANCELORDER',prop:'Visible'},{ctrl:'CONFIRMORDER',prop:'Enabled'},{ctrl:'CONFIRMORDER',prop:'Visible'},{av:'divTableorderconfirm_Visible',ctrl:'TABLEORDERCONFIRM',prop:'Visible'},{av:'divTableordercancel_Visible',ctrl:'TABLEORDERCANCEL',prop:'Visible'},{av:'divTableordercanceled_Visible',ctrl:'TABLEORDERCANCELED',prop:'Visible'},{av:'AV49EmailTitle',fld:'vEMAILTITLE',pic:''},{av:'AV50EmailSubtitle',fld:'vEMAILSUBTITLE',pic:''}]}");
         setEventMetadata("'ORDERCONFIRMATEDEXIT'","{handler:'E113K1',iparms:[]");
         setEventMetadata("'ORDERCONFIRMATEDEXIT'",",oparms:[]}");
         setEventMetadata("'ORDERCANCELEDEXIT'","{handler:'E123K1',iparms:[]");
         setEventMetadata("'ORDERCANCELEDEXIT'",",oparms:[]}");
         setEventMetadata("VALIDV_PURCHASEORDERCREATEDDATE","{handler:'Validv_Purchaseordercreateddate',iparms:[]");
         setEventMetadata("VALIDV_PURCHASEORDERCREATEDDATE",",oparms:[]}");
         setEventMetadata("VALIDV_TOTALPROJECTED","{handler:'Validv_Totalprojected',iparms:[]");
         setEventMetadata("VALIDV_TOTALPROJECTED",",oparms:[]}");
         setEventMetadata("VALIDV_GXV6","{handler:'Validv_Gxv6',iparms:[]");
         setEventMetadata("VALIDV_GXV6",",oparms:[]}");
         setEventMetadata("VALIDV_GXV7","{handler:'Validv_Gxv7',iparms:[]");
         setEventMetadata("VALIDV_GXV7",",oparms:[]}");
         setEventMetadata("VALIDV_GXV8","{handler:'Validv_Gxv8',iparms:[]");
         setEventMetadata("VALIDV_GXV8",",oparms:[]}");
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
         wcpOAV25MesaggeError = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV37SDTPurchaseOrderDetails = new GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem>( context, "SDTPurchaseOrderDetailsItem", "mtaKB");
         AV18MeEmail = "";
         AV15SupplierName = "";
         AV16PurchaseOrderCreatedDate = DateTime.MinValue;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         forbiddenHiddens = new GXProperties();
         AV20NamesOfAttachs = new GxSimpleCollection<string>();
         AV49EmailTitle = "";
         AV50EmailSubtitle = "";
         AV14EmailBody = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTitletext_Jsonclick = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttConfirmorder_Jsonclick = "";
         GridpurchaseorderdetailsContainer = new GXWebGrid( context);
         sStyleString = "";
         lblTextblock1_Jsonclick = "";
         lblTextblock3_Jsonclick = "";
         bttOrderconfirmatedexit_Jsonclick = "";
         AV44PurchaseOrderCanceledDescription = "";
         bttCancelorder_Jsonclick = "";
         lblTextblock2_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         bttOrdercanceledexit_Jsonclick = "";
         ucUcprobamosloader1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         hsh = "";
         scmdbuf = "";
         H003K2_A79PurchaseOrderActive = new bool[] {false} ;
         H003K2_A50PurchaseOrderId = new int[1] ;
         AV19URLs = new GxSimpleCollection<string>();
         AV56EmailBodyAux = "";
         GXt_char1 = "";
         H003K3_A4SupplierId = new int[1] ;
         H003K3_A50PurchaseOrderId = new int[1] ;
         H003K3_A52PurchaseOrderCreatedDate = new DateTime[] {DateTime.MinValue} ;
         H003K3_A5SupplierName = new string[] {""} ;
         A52PurchaseOrderCreatedDate = DateTime.MinValue;
         A5SupplierName = "";
         H003K4_A61PurchaseOrderDetailId = new int[1] ;
         H003K4_A50PurchaseOrderId = new int[1] ;
         H003K4_A15ProductId = new int[1] ;
         H003K4_A55ProductCode = new string[] {""} ;
         H003K4_n55ProductCode = new bool[] {false} ;
         H003K4_A85ProductCostPrice = new decimal[1] ;
         H003K4_n85ProductCostPrice = new bool[] {false} ;
         H003K4_A16ProductName = new string[] {""} ;
         H003K4_A76PurchaseOrderDetailQuantityOrd = new int[1] ;
         A55ProductCode = "";
         A16ProductName = "";
         AV35SDTPurchaseOrderDetailsItem = new SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem(context);
         H003K5_A79PurchaseOrderActive = new bool[] {false} ;
         H003K5_A50PurchaseOrderId = new int[1] ;
         AV17ConfirmedDate = DateTime.MinValue;
         AV46CanceledDate = DateTime.MinValue;
         GridpurchaseorderdetailsRow = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGridpurchaseorderdetails_Linesclass = "";
         ROClassString = "";
         GridpurchaseorderdetailsColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.purchaseordersupplierview__default(),
            new Object[][] {
                new Object[] {
               H003K2_A79PurchaseOrderActive, H003K2_A50PurchaseOrderId
               }
               , new Object[] {
               H003K3_A4SupplierId, H003K3_A50PurchaseOrderId, H003K3_A52PurchaseOrderCreatedDate, H003K3_A5SupplierName
               }
               , new Object[] {
               H003K4_A61PurchaseOrderDetailId, H003K4_A50PurchaseOrderId, H003K4_A15ProductId, H003K4_A55ProductCode, H003K4_n55ProductCode, H003K4_A85ProductCostPrice, H003K4_n85ProductCostPrice, H003K4_A16ProductName, H003K4_A76PurchaseOrderDetailQuantityOrd
               }
               , new Object[] {
               H003K5_A79PurchaseOrderActive, H003K5_A50PurchaseOrderId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavPurchaseordercreateddate_Enabled = 0;
         edtavTotalprojected_Enabled = 0;
         edtavCtlcode_Enabled = 0;
         edtavCtlname_Enabled = 0;
         edtavCtlquantityordered_Enabled = 0;
         edtavCtlproductcostprice_Enabled = 0;
         edtavCtlsubtotal_Enabled = 0;
      }

      private short nRcdExists_6 ;
      private short nIsMod_6 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
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
      private short subGridpurchaseorderdetails_Backcolorstyle ;
      private short AV68GXLvl3 ;
      private short GRIDPURCHASEORDERDETAILS_nEOF ;
      private short nGXWrapped ;
      private short subGridpurchaseorderdetails_Backstyle ;
      private short subGridpurchaseorderdetails_Titlebackstyle ;
      private short subGridpurchaseorderdetails_Allowselection ;
      private short subGridpurchaseorderdetails_Allowhovering ;
      private short subGridpurchaseorderdetails_Allowcollapsing ;
      private short subGridpurchaseorderdetails_Collapsed ;
      private int AV12PurchaseOrderId ;
      private int wcpOAV12PurchaseOrderId ;
      private int nRC_GXsfl_31 ;
      private int nGXsfl_31_idx=1 ;
      private int A50PurchaseOrderId ;
      private int divTableorderconfirm_Visible ;
      private int edtavPurchaseordercreateddate_Enabled ;
      private int edtavTotalprojected_Enabled ;
      private int bttConfirmorder_Visible ;
      private int bttConfirmorder_Enabled ;
      private int AV60GXV1 ;
      private int divTableorderconfirmed_Visible ;
      private int divTableordercancel_Visible ;
      private int edtavPurchaseordercanceleddescription_Enabled ;
      private int bttCancelorder_Visible ;
      private int bttCancelorder_Enabled ;
      private int divTableordercanceled_Visible ;
      private int subGridpurchaseorderdetails_Islastpage ;
      private int edtavCtlcode_Enabled ;
      private int edtavCtlname_Enabled ;
      private int edtavCtlquantityordered_Enabled ;
      private int edtavCtlproductcostprice_Enabled ;
      private int edtavCtlsubtotal_Enabled ;
      private int nGXsfl_31_fel_idx=1 ;
      private int A4SupplierId ;
      private int A15ProductId ;
      private int A76PurchaseOrderDetailQuantityOrd ;
      private int AV71GXV9 ;
      private int AV72GXV10 ;
      private int AV74GXV11 ;
      private int idxLst ;
      private int subGridpurchaseorderdetails_Backcolor ;
      private int subGridpurchaseorderdetails_Allbackcolor ;
      private int edtavCtlquantityreceived_Enabled ;
      private int edtavCtlquantityreceived_Visible ;
      private int edtavCtlnewcostprice_Enabled ;
      private int edtavCtlnewcostprice_Visible ;
      private int subGridpurchaseorderdetails_Titlebackcolor ;
      private int subGridpurchaseorderdetails_Selectedindex ;
      private int subGridpurchaseorderdetails_Selectioncolor ;
      private int subGridpurchaseorderdetails_Hoveringcolor ;
      private long GRIDPURCHASEORDERDETAILS_nCurrentRecord ;
      private long GRIDPURCHASEORDERDETAILS_nFirstRecordOnPage ;
      private decimal AV41TotalProjected ;
      private decimal A85ProductCostPrice ;
      private decimal AV57CostPriceAux ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_31_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divTable2_Internalname ;
      private string lblTitletext_Internalname ;
      private string lblTitletext_Caption ;
      private string lblTitletext_Jsonclick ;
      private string divTableorderconfirm_Internalname ;
      private string edtavPurchaseordercreateddate_Internalname ;
      private string TempTags ;
      private string edtavPurchaseordercreateddate_Jsonclick ;
      private string edtavTotalprojected_Internalname ;
      private string edtavTotalprojected_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string bttConfirmorder_Internalname ;
      private string bttConfirmorder_Jsonclick ;
      private string divTable1_Internalname ;
      private string sStyleString ;
      private string subGridpurchaseorderdetails_Internalname ;
      private string divTableorderconfirmed_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string bttOrderconfirmatedexit_Internalname ;
      private string bttOrderconfirmatedexit_Jsonclick ;
      private string divTableordercancel_Internalname ;
      private string edtavPurchaseordercanceleddescription_Internalname ;
      private string bttCancelorder_Internalname ;
      private string bttCancelorder_Jsonclick ;
      private string divTableordercanceled_Internalname ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string bttOrdercanceledexit_Internalname ;
      private string bttOrdercanceledexit_Jsonclick ;
      private string Ucprobamosloader1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavCtlcode_Internalname ;
      private string edtavCtlname_Internalname ;
      private string edtavCtlquantityordered_Internalname ;
      private string edtavCtlproductcostprice_Internalname ;
      private string edtavCtlsubtotal_Internalname ;
      private string sGXsfl_31_fel_idx="0001" ;
      private string hsh ;
      private string scmdbuf ;
      private string GXt_char1 ;
      private string edtavCtlquantityreceived_Internalname ;
      private string edtavCtlnewcostprice_Internalname ;
      private string subGridpurchaseorderdetails_Class ;
      private string subGridpurchaseorderdetails_Linesclass ;
      private string ROClassString ;
      private string edtavCtlcode_Jsonclick ;
      private string edtavCtlname_Jsonclick ;
      private string edtavCtlquantityordered_Jsonclick ;
      private string edtavCtlquantityreceived_Jsonclick ;
      private string edtavCtlproductcostprice_Jsonclick ;
      private string edtavCtlnewcostprice_Jsonclick ;
      private string edtavCtlsubtotal_Jsonclick ;
      private string subGridpurchaseorderdetails_Header ;
      private DateTime AV16PurchaseOrderCreatedDate ;
      private DateTime A52PurchaseOrderCreatedDate ;
      private DateTime AV17ConfirmedDate ;
      private DateTime AV46CanceledDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV42ControlPassed ;
      private bool AV21AllOk ;
      private bool A79PurchaseOrderActive ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_31_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV10Exists ;
      private bool AV23AnswerCancel ;
      private bool AV24AnswerConfirm ;
      private bool AV48Answer ;
      private bool AV39Option ;
      private bool gx_BV31 ;
      private bool n55ProductCode ;
      private bool n85ProductCostPrice ;
      private string AV25MesaggeError ;
      private string wcpOAV25MesaggeError ;
      private string AV18MeEmail ;
      private string AV15SupplierName ;
      private string AV49EmailTitle ;
      private string AV50EmailSubtitle ;
      private string AV14EmailBody ;
      private string AV44PurchaseOrderCanceledDescription ;
      private string AV56EmailBodyAux ;
      private string A5SupplierName ;
      private string A55ProductCode ;
      private string A16ProductName ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid GridpurchaseorderdetailsContainer ;
      private GXWebRow GridpurchaseorderdetailsRow ;
      private GXWebColumn GridpurchaseorderdetailsColumn ;
      private GXUserControl ucUcprobamosloader1 ;
      private IGxDataStore dsDefault ;
      private string aP1_MesaggeError ;
      private IDataStoreProvider pr_default ;
      private bool[] H003K2_A79PurchaseOrderActive ;
      private int[] H003K2_A50PurchaseOrderId ;
      private int[] H003K3_A4SupplierId ;
      private int[] H003K3_A50PurchaseOrderId ;
      private DateTime[] H003K3_A52PurchaseOrderCreatedDate ;
      private string[] H003K3_A5SupplierName ;
      private int[] H003K4_A61PurchaseOrderDetailId ;
      private int[] H003K4_A50PurchaseOrderId ;
      private int[] H003K4_A15ProductId ;
      private string[] H003K4_A55ProductCode ;
      private bool[] H003K4_n55ProductCode ;
      private decimal[] H003K4_A85ProductCostPrice ;
      private bool[] H003K4_n85ProductCostPrice ;
      private string[] H003K4_A16ProductName ;
      private int[] H003K4_A76PurchaseOrderDetailQuantityOrd ;
      private bool[] H003K5_A79PurchaseOrderActive ;
      private int[] H003K5_A50PurchaseOrderId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxSimpleCollection<string> AV20NamesOfAttachs ;
      private GxSimpleCollection<string> AV19URLs ;
      private GXBaseCollection<SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem> AV37SDTPurchaseOrderDetails ;
      private GXWebForm Form ;
      private SdtSDTPurchaseOrderDetails_SDTPurchaseOrderDetailsItem AV35SDTPurchaseOrderDetailsItem ;
   }

   public class purchaseordersupplierview__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH003K2;
          prmH003K2 = new Object[] {
          new ParDef("@AV12PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmH003K3;
          prmH003K3 = new Object[] {
          new ParDef("@AV12PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmH003K4;
          prmH003K4 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmH003K5;
          prmH003K5 = new Object[] {
          new ParDef("@AV12PurchaseOrderId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("H003K2", "SELECT TOP 1 [PurchaseOrderActive], [PurchaseOrderId] FROM [PurchaseOrder] WHERE ([PurchaseOrderId] = @AV12PurchaseOrderId) AND ([PurchaseOrderActive] = 1) ORDER BY [PurchaseOrderId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003K2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H003K3", "SELECT TOP 1 T1.[SupplierId], T1.[PurchaseOrderId], T1.[PurchaseOrderCreatedDate], T2.[SupplierName] FROM ([PurchaseOrder] T1 INNER JOIN [Supplier] T2 ON T2.[SupplierId] = T1.[SupplierId]) WHERE T1.[PurchaseOrderId] = @AV12PurchaseOrderId ORDER BY T1.[PurchaseOrderId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003K3,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H003K4", "SELECT T1.[PurchaseOrderDetailId], T1.[PurchaseOrderId], T1.[ProductId], T2.[ProductCode], T2.[ProductCostPrice], T2.[ProductName], T1.[PurchaseOrderDetailQuantityOrd] FROM ([PurchaseOrderDetail] T1 INNER JOIN [Product] T2 ON T2.[ProductId] = T1.[ProductId]) WHERE T1.[PurchaseOrderId] = @PurchaseOrderId ORDER BY T1.[PurchaseOrderId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003K4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H003K5", "SELECT [PurchaseOrderActive], [PurchaseOrderId] FROM [PurchaseOrder] WHERE ([PurchaseOrderId] = @AV12PurchaseOrderId) AND ([PurchaseOrderActive] = 1) ORDER BY [PurchaseOrderId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003K5,1, GxCacheFrequency.OFF ,false,true )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                ((int[]) buf[8])[0] = rslt.getInt(7);
                return;
             case 3 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
       }
    }

 }

}
