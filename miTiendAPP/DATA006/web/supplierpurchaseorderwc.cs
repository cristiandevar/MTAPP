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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class supplierpurchaseorderwc : GXWebComponent
   {
      public supplierpurchaseorderwc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("mtaKB", true);
         }
      }

      public supplierpurchaseorderwc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_SupplierId )
      {
         this.AV6SupplierId = aP0_SupplierId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
         cmbavPurchaseorderstate = new GXCombobox();
         cmbavOrderby = new GXCombobox();
         chkavOrderbydesc = new GXCheckbox();
         chkPurchaseOrderActive = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "SupplierId");
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  AV6SupplierId = (int)(Math.Round(NumberUtil.Val( GetPar( "SupplierId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV6SupplierId", StringUtil.LTrimStr( (decimal)(AV6SupplierId), 6, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(int)AV6SupplierId});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
                  gxfirstwebparm = GetFirstPar( "SupplierId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "SupplierId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
               {
                  gxnrGrid_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
               {
                  gxgrGrid_refresh_invoke( ) ;
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
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_46 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_46"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_46_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_46_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_46_idx = GetPar( "sGXsfl_46_idx");
         sPrefix = GetPar( "sPrefix");
         AV17Detail = GetPar( "Detail");
         edtavDetail_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavDetail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDetail_Visible), 5, 0), !bGXsfl_46_Refreshing);
         edtavDetail_Enabled = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavDetail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDetail_Enabled), 5, 0), !bGXsfl_46_Refreshing);
         AV22Voucher = GetPar( "Voucher");
         edtavVoucher_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavVoucher_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavVoucher_Visible), 5, 0), !bGXsfl_46_Refreshing);
         edtavVoucher_Enabled = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavVoucher_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavVoucher_Enabled), 5, 0), !bGXsfl_46_Refreshing);
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid_newrow( ) ;
         /* End function gxnrGrid_newrow_invoke */
      }

      protected void gxgrGrid_refresh_invoke( )
      {
         subGrid_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid_Rows"), "."), 18, MidpointRounding.ToEven));
         AV19PurchaseOrderId = (int)(Math.Round(NumberUtil.Val( GetPar( "PurchaseOrderId"), "."), 18, MidpointRounding.ToEven));
         cmbavPurchaseorderstate.FromJSonString( GetNextPar( ));
         AV20PurchaseOrderState = GetPar( "PurchaseOrderState");
         cmbavOrderby.FromJSonString( GetNextPar( ));
         AV23OrderBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderBy"), "."), 18, MidpointRounding.ToEven));
         AV24OrderByDesc = StringUtil.StrToBool( GetPar( "OrderByDesc"));
         AV6SupplierId = (int)(Math.Round(NumberUtil.Val( GetPar( "SupplierId"), "."), 18, MidpointRounding.ToEven));
         AV17Detail = GetPar( "Detail");
         edtavDetail_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavDetail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDetail_Visible), 5, 0), !bGXsfl_46_Refreshing);
         edtavDetail_Enabled = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavDetail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDetail_Enabled), 5, 0), !bGXsfl_46_Refreshing);
         AV22Voucher = GetPar( "Voucher");
         edtavVoucher_Visible = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavVoucher_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavVoucher_Visible), 5, 0), !bGXsfl_46_Refreshing);
         edtavVoucher_Enabled = (int)(Math.Round(NumberUtil.Val( GetNextPar( ), "."), 18, MidpointRounding.ToEven));
         AssignProp(sPrefix, false, edtavVoucher_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavVoucher_Enabled), 5, 0), !bGXsfl_46_Refreshing);
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV19PurchaseOrderId, AV20PurchaseOrderState, AV23OrderBy, AV24OrderByDesc, AV6SupplierId, AV17Detail, AV22Voucher, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
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
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA1D2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV27Pgmname = "SupplierPurchaseOrderWC";
               context.Gx_err = 0;
               edtavState_Enabled = 0;
               AssignProp(sPrefix, false, edtavState_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavState_Enabled), 5, 0), !bGXsfl_46_Refreshing);
               edtavDetail_Enabled = 0;
               AssignProp(sPrefix, false, edtavDetail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDetail_Enabled), 5, 0), !bGXsfl_46_Refreshing);
               edtavVoucher_Enabled = 0;
               AssignProp(sPrefix, false, edtavVoucher_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavVoucher_Enabled), 5, 0), !bGXsfl_46_Refreshing);
               WS1D2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( "Supplier Purchase Order WC") ;
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
         }
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
            context.WriteHtmlText( "<body ") ;
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            if ( nGXWrapped != 1 )
            {
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("supplierpurchaseorderwc.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV6SupplierId,6,0))}, new string[] {"SupplierId"}) +"\">") ;
               GxWebStd.gx_hidden_field( context, "_EventName", "");
               GxWebStd.gx_hidden_field( context, "_EventGridId", "");
               GxWebStd.gx_hidden_field( context, "_EventRowId", "");
               context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
               AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
            }
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vPURCHASEORDERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19PurchaseOrderId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vPURCHASEORDERSTATE", AV20PurchaseOrderState);
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDERBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23OrderBy), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDERBYDESC", StringUtil.BoolToStr( AV24OrderByDesc));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_46", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_46), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6SupplierId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV6SupplierId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSUPPLIERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6SupplierId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDETAIL_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDetail_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDETAIL_Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDetail_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vVOUCHER_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavVoucher_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vVOUCHER_Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavVoucher_Enabled), 5, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm1D2( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "SupplierPurchaseOrderWC" ;
      }

      public override string GetPgmdesc( )
      {
         return "Supplier Purchase Order WC" ;
      }

      protected void WB1D0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "supplierpurchaseorderwc.aspx");
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "ww__view__grid-table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 ww__grid-cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabletop_Internalname, 1, 0, "px", 0, "px", "Flex ww__actions-container", "left", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ww__view__grid__actions-cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ww__view__actions", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 13,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button button-tertiary";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(46), 2, 0)+","+"null"+");", "Export", bttBtnexport_Jsonclick, 5, "Export to Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_SupplierPurchaseOrderWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 15,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button button-tertiary";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnstatistic_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(46), 2, 0)+","+"null"+");", "Statistic", bttBtnstatistic_Jsonclick, 7, "Statistic", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e111d1_client"+"'", TempTags, "", 2, "HLP_SupplierPurchaseOrderWC.htm");
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
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavPurchaseorderid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPurchaseorderid_Internalname, "Nro", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'" + sPrefix + "',false,'" + sGXsfl_46_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPurchaseorderid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19PurchaseOrderId), 6, 0, ".", "")), StringUtil.LTrim( ((edtavPurchaseorderid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV19PurchaseOrderId), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV19PurchaseOrderId), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,26);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPurchaseorderid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavPurchaseorderid_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_SupplierPurchaseOrderWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavPurchaseorderstate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavPurchaseorderstate_Internalname, "State", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'" + sPrefix + "',false,'" + sGXsfl_46_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavPurchaseorderstate, cmbavPurchaseorderstate_Internalname, StringUtil.RTrim( AV20PurchaseOrderState), 1, cmbavPurchaseorderstate_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavPurchaseorderstate.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "", true, 0, "HLP_SupplierPurchaseOrderWC.htm");
            cmbavPurchaseorderstate.CurrentValue = StringUtil.RTrim( AV20PurchaseOrderState);
            AssignProp(sPrefix, false, cmbavPurchaseorderstate_Internalname, "Values", (string)(cmbavPurchaseorderstate.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavOrderby_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavOrderby_Internalname, "Order By", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'" + sPrefix + "',false,'" + sGXsfl_46_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavOrderby, cmbavOrderby_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV23OrderBy), 4, 0)), 1, cmbavOrderby_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavOrderby.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "", true, 0, "HLP_SupplierPurchaseOrderWC.htm");
            cmbavOrderby.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23OrderBy), 4, 0));
            AssignProp(sPrefix, false, cmbavOrderby_Internalname, "Values", (string)(cmbavOrderby.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavOrderbydesc_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavOrderbydesc_Internalname, "Desc", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'" + sPrefix + "',false,'" + sGXsfl_46_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavOrderbydesc_Internalname, StringUtil.BoolToStr( AV24OrderByDesc), "", "Desc", 1, chkavOrderbydesc.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(38, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,38);\"");
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
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcontainer_Internalname, 1, 0, "px", 0, "px", "ww__grid-container", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl46( ) ;
         }
         if ( wbEnd == 46 )
         {
            wbEnd = 0;
            nRC_GXsfl_46 = (int)(nGXsfl_46_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
               GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSupplierId_Internalname, "Supplier Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtSupplierId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A4SupplierId), 6, 0, ".", "")), StringUtil.LTrim( ((edtSupplierId_Enabled!=0) ? context.localUtil.Format( (decimal)(A4SupplierId), "ZZZZZ9") : context.localUtil.Format( (decimal)(A4SupplierId), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierId_Jsonclick, 0, "Attribute", "", "", "", "", edtSupplierId_Visible, edtSupplierId_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_SupplierPurchaseOrderWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 46 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
                  GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START1D2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET 18_0_2-169539", 0) ;
               }
               Form.Meta.addItem("description", "Supplier Purchase Order WC", 0) ;
            }
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP1D0( ) ;
            }
         }
      }

      protected void WS1D2( )
      {
         START1D2( ) ;
         EVT1D2( ) ;
      }

      protected void EVT1D2( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP1D0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP1D0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoExport' */
                                    E121D2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP1D0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavState_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP1D0( ) ;
                              }
                              sEvt = cgiGet( sPrefix+"GRIDPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP1D0( ) ;
                              }
                              nGXsfl_46_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_46_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_46_idx), 4, 0), 4, "0");
                              SubsflControlProps_462( ) ;
                              A50PurchaseOrderId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPurchaseOrderId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A52PurchaseOrderCreatedDate = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtPurchaseOrderCreatedDate_Internalname), 0));
                              A53PurchaseOrderModifiedDate = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtPurchaseOrderModifiedDate_Internalname), 0));
                              n53PurchaseOrderModifiedDate = false;
                              A66PurchaseOrderClosedDate = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtPurchaseOrderClosedDate_Internalname), 0));
                              n66PurchaseOrderClosedDate = false;
                              A78PurchaseOrderTotalPaid = context.localUtil.CToN( cgiGet( edtPurchaseOrderTotalPaid_Internalname), ".", ",");
                              n78PurchaseOrderTotalPaid = false;
                              AV21State = cgiGet( edtavState_Internalname);
                              AssignAttri(sPrefix, false, edtavState_Internalname, AV21State);
                              A79PurchaseOrderActive = StringUtil.StrToBool( cgiGet( chkPurchaseOrderActive_Internalname));
                              AV17Detail = cgiGet( edtavDetail_Internalname);
                              AssignAttri(sPrefix, false, edtavDetail_Internalname, AV17Detail);
                              AV22Voucher = cgiGet( edtavVoucher_Internalname);
                              AssignAttri(sPrefix, false, edtavVoucher_Internalname, AV22Voucher);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavState_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E131D2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavState_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E141D2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          if ( ! wbErr )
                                          {
                                             Rfr0gs = false;
                                             /* Set Refresh If Purchaseorderid Changed */
                                             if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vPURCHASEORDERID"), ".", ",") != Convert.ToDecimal( AV19PurchaseOrderId )) )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Purchaseorderstate Changed */
                                             if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vPURCHASEORDERSTATE"), AV20PurchaseOrderState) != 0 )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Orderby Changed */
                                             if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vORDERBY"), ".", ",") != Convert.ToDecimal( AV23OrderBy )) )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Orderbydesc Changed */
                                             if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDERBYDESC")) != AV24OrderByDesc )
                                             {
                                                Rfr0gs = true;
                                             }
                                             if ( ! Rfr0gs )
                                             {
                                             }
                                             dynload_actions( ) ;
                                          }
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP1D0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = edtavState_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                       }
                                    }
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

      protected void WE1D2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm1D2( ) ;
            }
         }
      }

      protected void PA1D2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavPurchaseorderid_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_462( ) ;
         while ( nGXsfl_46_idx <= nRC_GXsfl_46 )
         {
            sendrow_462( ) ;
            nGXsfl_46_idx = ((subGrid_Islastpage==1)&&(nGXsfl_46_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_46_idx+1);
            sGXsfl_46_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_46_idx), 4, 0), 4, "0");
            SubsflControlProps_462( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       int AV19PurchaseOrderId ,
                                       string AV20PurchaseOrderState ,
                                       short AV23OrderBy ,
                                       bool AV24OrderByDesc ,
                                       int AV6SupplierId ,
                                       string AV17Detail ,
                                       string AV22Voucher ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF1D2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_PURCHASEORDERID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A50PurchaseOrderId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"PURCHASEORDERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A50PurchaseOrderId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_PURCHASEORDERCREATEDDATE", GetSecureSignedToken( sPrefix, A52PurchaseOrderCreatedDate, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"PURCHASEORDERCREATEDDATE", context.localUtil.Format(A52PurchaseOrderCreatedDate, "99/99/99"));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_PURCHASEORDERCLOSEDDATE", GetSecureSignedToken( sPrefix, A66PurchaseOrderClosedDate, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"PURCHASEORDERCLOSEDDATE", context.localUtil.Format(A66PurchaseOrderClosedDate, "99/99/99"));
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
         if ( cmbavPurchaseorderstate.ItemCount > 0 )
         {
            AV20PurchaseOrderState = cmbavPurchaseorderstate.getValidValue(AV20PurchaseOrderState);
            AssignAttri(sPrefix, false, "AV20PurchaseOrderState", AV20PurchaseOrderState);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavPurchaseorderstate.CurrentValue = StringUtil.RTrim( AV20PurchaseOrderState);
            AssignProp(sPrefix, false, cmbavPurchaseorderstate_Internalname, "Values", cmbavPurchaseorderstate.ToJavascriptSource(), true);
         }
         if ( cmbavOrderby.ItemCount > 0 )
         {
            AV23OrderBy = (short)(Math.Round(NumberUtil.Val( cmbavOrderby.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV23OrderBy), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV23OrderBy", StringUtil.LTrimStr( (decimal)(AV23OrderBy), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavOrderby.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23OrderBy), 4, 0));
            AssignProp(sPrefix, false, cmbavOrderby_Internalname, "Values", cmbavOrderby.ToJavascriptSource(), true);
         }
         AV24OrderByDesc = StringUtil.StrToBool( StringUtil.BoolToStr( AV24OrderByDesc));
         AssignAttri(sPrefix, false, "AV24OrderByDesc", AV24OrderByDesc);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF1D2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV27Pgmname = "SupplierPurchaseOrderWC";
         context.Gx_err = 0;
         edtavState_Enabled = 0;
         AssignProp(sPrefix, false, edtavState_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavState_Enabled), 5, 0), !bGXsfl_46_Refreshing);
         edtavDetail_Enabled = 0;
         AssignProp(sPrefix, false, edtavDetail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDetail_Enabled), 5, 0), !bGXsfl_46_Refreshing);
         edtavVoucher_Enabled = 0;
         AssignProp(sPrefix, false, edtavVoucher_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavVoucher_Enabled), 5, 0), !bGXsfl_46_Refreshing);
      }

      protected void RF1D2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 46;
         nGXsfl_46_idx = 1;
         sGXsfl_46_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_46_idx), 4, 0), 4, "0");
         SubsflControlProps_462( ) ;
         bGXsfl_46_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", sPrefix);
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "ViewGrid");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_462( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV19PurchaseOrderId ,
                                                 AV20PurchaseOrderState ,
                                                 A50PurchaseOrderId ,
                                                 A79PurchaseOrderActive ,
                                                 A66PurchaseOrderClosedDate ,
                                                 AV23OrderBy ,
                                                 AV24OrderByDesc ,
                                                 AV6SupplierId ,
                                                 A4SupplierId } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT
                                                 }
            });
            /* Using cursor H001D2 */
            pr_default.execute(0, new Object[] {AV6SupplierId, AV19PurchaseOrderId, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_46_idx = 1;
            sGXsfl_46_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_46_idx), 4, 0), 4, "0");
            SubsflControlProps_462( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A4SupplierId = H001D2_A4SupplierId[0];
               AssignAttri(sPrefix, false, "A4SupplierId", StringUtil.LTrimStr( (decimal)(A4SupplierId), 6, 0));
               A79PurchaseOrderActive = H001D2_A79PurchaseOrderActive[0];
               A78PurchaseOrderTotalPaid = H001D2_A78PurchaseOrderTotalPaid[0];
               n78PurchaseOrderTotalPaid = H001D2_n78PurchaseOrderTotalPaid[0];
               A66PurchaseOrderClosedDate = H001D2_A66PurchaseOrderClosedDate[0];
               n66PurchaseOrderClosedDate = H001D2_n66PurchaseOrderClosedDate[0];
               A53PurchaseOrderModifiedDate = H001D2_A53PurchaseOrderModifiedDate[0];
               n53PurchaseOrderModifiedDate = H001D2_n53PurchaseOrderModifiedDate[0];
               A52PurchaseOrderCreatedDate = H001D2_A52PurchaseOrderCreatedDate[0];
               A50PurchaseOrderId = H001D2_A50PurchaseOrderId[0];
               E141D2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 46;
            WB1D0( ) ;
         }
         bGXsfl_46_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes1D2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_PURCHASEORDERID"+"_"+sGXsfl_46_idx, GetSecureSignedToken( sPrefix+sGXsfl_46_idx, context.localUtil.Format( (decimal)(A50PurchaseOrderId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_PURCHASEORDERCREATEDDATE"+"_"+sGXsfl_46_idx, GetSecureSignedToken( sPrefix+sGXsfl_46_idx, A52PurchaseOrderCreatedDate, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_PURCHASEORDERCLOSEDDATE"+"_"+sGXsfl_46_idx, GetSecureSignedToken( sPrefix+sGXsfl_46_idx, A66PurchaseOrderClosedDate, context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV19PurchaseOrderId ,
                                              AV20PurchaseOrderState ,
                                              A50PurchaseOrderId ,
                                              A79PurchaseOrderActive ,
                                              A66PurchaseOrderClosedDate ,
                                              AV23OrderBy ,
                                              AV24OrderByDesc ,
                                              AV6SupplierId ,
                                              A4SupplierId } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         /* Using cursor H001D3 */
         pr_default.execute(1, new Object[] {AV6SupplierId, AV19PurchaseOrderId});
         GRID_nRecordCount = H001D3_AGRID_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID_nRecordCount) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV19PurchaseOrderId, AV20PurchaseOrderState, AV23OrderBy, AV24OrderByDesc, AV6SupplierId, AV17Detail, AV22Voucher, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV19PurchaseOrderId, AV20PurchaseOrderState, AV23OrderBy, AV24OrderByDesc, AV6SupplierId, AV17Detail, AV22Voucher, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV19PurchaseOrderId, AV20PurchaseOrderState, AV23OrderBy, AV24OrderByDesc, AV6SupplierId, AV17Detail, AV22Voucher, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV19PurchaseOrderId, AV20PurchaseOrderState, AV23OrderBy, AV24OrderByDesc, AV6SupplierId, AV17Detail, AV22Voucher, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV19PurchaseOrderId, AV20PurchaseOrderState, AV23OrderBy, AV24OrderByDesc, AV6SupplierId, AV17Detail, AV22Voucher, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV27Pgmname = "SupplierPurchaseOrderWC";
         context.Gx_err = 0;
         edtavState_Enabled = 0;
         AssignProp(sPrefix, false, edtavState_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavState_Enabled), 5, 0), !bGXsfl_46_Refreshing);
         edtavDetail_Enabled = 0;
         AssignProp(sPrefix, false, edtavDetail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDetail_Enabled), 5, 0), !bGXsfl_46_Refreshing);
         edtavVoucher_Enabled = 0;
         AssignProp(sPrefix, false, edtavVoucher_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavVoucher_Enabled), 5, 0), !bGXsfl_46_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP1D0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E131D2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_46 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_46"), ".", ","), 18, MidpointRounding.ToEven));
            wcpOAV6SupplierId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV6SupplierId"), ".", ","), 18, MidpointRounding.ToEven));
            AV6SupplierId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vSUPPLIERID"), ".", ","), 18, MidpointRounding.ToEven));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPurchaseorderid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPurchaseorderid_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPURCHASEORDERID");
               GX_FocusControl = edtavPurchaseorderid_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV19PurchaseOrderId = 0;
               AssignAttri(sPrefix, false, "AV19PurchaseOrderId", StringUtil.LTrimStr( (decimal)(AV19PurchaseOrderId), 6, 0));
            }
            else
            {
               AV19PurchaseOrderId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavPurchaseorderid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri(sPrefix, false, "AV19PurchaseOrderId", StringUtil.LTrimStr( (decimal)(AV19PurchaseOrderId), 6, 0));
            }
            cmbavPurchaseorderstate.Name = cmbavPurchaseorderstate_Internalname;
            cmbavPurchaseorderstate.CurrentValue = cgiGet( cmbavPurchaseorderstate_Internalname);
            AV20PurchaseOrderState = cgiGet( cmbavPurchaseorderstate_Internalname);
            AssignAttri(sPrefix, false, "AV20PurchaseOrderState", AV20PurchaseOrderState);
            cmbavOrderby.Name = cmbavOrderby_Internalname;
            cmbavOrderby.CurrentValue = cgiGet( cmbavOrderby_Internalname);
            AV23OrderBy = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavOrderby_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV23OrderBy", StringUtil.LTrimStr( (decimal)(AV23OrderBy), 4, 0));
            AV24OrderByDesc = StringUtil.StrToBool( cgiGet( chkavOrderbydesc_Internalname));
            AssignAttri(sPrefix, false, "AV24OrderByDesc", AV24OrderByDesc);
            A4SupplierId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtSupplierId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A4SupplierId", StringUtil.LTrimStr( (decimal)(A4SupplierId), 6, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vPURCHASEORDERID"), ".", ",") != Convert.ToDecimal( AV19PurchaseOrderId )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( sPrefix+"GXH_vPURCHASEORDERSTATE"), AV20PurchaseOrderState) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vORDERBY"), ".", ",") != Convert.ToDecimal( AV23OrderBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDERBYDESC")) != AV24OrderByDesc )
            {
               GRID_nFirstRecordOnPage = 0;
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
         E131D2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E131D2( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtSDTContextSession1 = new GeneXus.Programs.general.ui.SdtSDTContextSession();
         new checkauthentication(context ).execute( out  GXt_SdtSDTContextSession1) ;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV27Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV27Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         subGrid_Rows = 6;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         edtSupplierId_Visible = 0;
         AssignProp(sPrefix, false, edtSupplierId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtSupplierId_Visible), 5, 0), true);
         if ( new haspermission(context).executeUdp(  "purchaseorder view") )
         {
            AV17Detail = "Details";
            AssignAttri(sPrefix, false, edtavDetail_Internalname, AV17Detail);
            edtavDetail_Visible = 1;
            AssignProp(sPrefix, false, edtavDetail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDetail_Visible), 5, 0), !bGXsfl_46_Refreshing);
            edtavDetail_Enabled = 1;
            AssignProp(sPrefix, false, edtavDetail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDetail_Enabled), 5, 0), !bGXsfl_46_Refreshing);
            AV22Voucher = "Voucher";
            AssignAttri(sPrefix, false, edtavVoucher_Internalname, AV22Voucher);
            edtavVoucher_Visible = 1;
            AssignProp(sPrefix, false, edtavVoucher_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavVoucher_Visible), 5, 0), !bGXsfl_46_Refreshing);
            edtavVoucher_Enabled = 1;
            AssignProp(sPrefix, false, edtavVoucher_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavVoucher_Enabled), 5, 0), !bGXsfl_46_Refreshing);
         }
         else
         {
            AV17Detail = "";
            AssignAttri(sPrefix, false, edtavDetail_Internalname, AV17Detail);
            edtavDetail_Visible = 0;
            AssignProp(sPrefix, false, edtavDetail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDetail_Visible), 5, 0), !bGXsfl_46_Refreshing);
            edtavDetail_Enabled = 0;
            AssignProp(sPrefix, false, edtavDetail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDetail_Enabled), 5, 0), !bGXsfl_46_Refreshing);
            AV22Voucher = "";
            AssignAttri(sPrefix, false, edtavVoucher_Internalname, AV22Voucher);
            edtavVoucher_Visible = 0;
            AssignProp(sPrefix, false, edtavVoucher_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavVoucher_Visible), 5, 0), !bGXsfl_46_Refreshing);
            edtavVoucher_Enabled = 0;
            AssignProp(sPrefix, false, edtavVoucher_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavVoucher_Enabled), 5, 0), !bGXsfl_46_Refreshing);
         }
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      private void E141D2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         GXt_char2 = AV21State;
         new purchaseordergetstate(context ).execute(  A50PurchaseOrderId, out  GXt_char2) ;
         AV21State = GXt_char2;
         AssignAttri(sPrefix, false, edtavState_Internalname, AV21State);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 46;
         }
         sendrow_462( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_46_Refreshing )
         {
            DoAjaxLoad(46, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV10TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10TrnContext.gxTpr_Callerobject = AV27Pgmname;
         AV10TrnContext.gxTpr_Callerondelete = true;
         AV10TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV10TrnContext.gxTpr_Transactionname = "PurchaseOrder";
         AV11TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         AV11TrnContextAtt.gxTpr_Attributename = "SupplierId";
         AV11TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV6SupplierId), 6, 0);
         AV10TrnContext.gxTpr_Attributes.Add(AV11TrnContextAtt, 0);
         AV7Session.Set("TrnContext", AV10TrnContext.ToXml(false, true, "", ""));
      }

      protected void E121D2( )
      {
         /* 'DoExport' Routine */
         returnInSub = false;
         new exportwwpurchaseorder(context ).execute(  0,  AV6SupplierId,  AV20PurchaseOrderState,  DateTime.MinValue,  DateTime.MinValue,  DateTime.MinValue,  DateTime.MinValue,  0, out  AV15ExcelFilename, out  AV16ErrorMessage) ;
         if ( StringUtil.StrCmp(AV15ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV15ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV16ErrorMessage);
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV6SupplierId = Convert.ToInt32(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV6SupplierId", StringUtil.LTrimStr( (decimal)(AV6SupplierId), 6, 0));
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
         PA1D2( ) ;
         WS1D2( ) ;
         WE1D2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlAV6SupplierId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA1D2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "supplierpurchaseorderwc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA1D2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV6SupplierId = Convert.ToInt32(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV6SupplierId", StringUtil.LTrimStr( (decimal)(AV6SupplierId), 6, 0));
         }
         wcpOAV6SupplierId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV6SupplierId"), ".", ","), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( AV6SupplierId != wcpOAV6SupplierId ) ) )
         {
            setjustcreated();
         }
         wcpOAV6SupplierId = AV6SupplierId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV6SupplierId = cgiGet( sPrefix+"AV6SupplierId_CTRL");
         if ( StringUtil.Len( sCtrlAV6SupplierId) > 0 )
         {
            AV6SupplierId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV6SupplierId), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV6SupplierId", StringUtil.LTrimStr( (decimal)(AV6SupplierId), 6, 0));
         }
         else
         {
            AV6SupplierId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV6SupplierId_PARM"), ".", ","), 18, MidpointRounding.ToEven));
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA1D2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS1D2( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS1D2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV6SupplierId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6SupplierId), 6, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV6SupplierId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV6SupplierId_CTRL", StringUtil.RTrim( sCtrlAV6SupplierId));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE1D2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20241129225638", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         CloseStyles();
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("supplierpurchaseorderwc.js", "?20241129225638", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_462( )
      {
         edtPurchaseOrderId_Internalname = sPrefix+"PURCHASEORDERID_"+sGXsfl_46_idx;
         edtPurchaseOrderCreatedDate_Internalname = sPrefix+"PURCHASEORDERCREATEDDATE_"+sGXsfl_46_idx;
         edtPurchaseOrderModifiedDate_Internalname = sPrefix+"PURCHASEORDERMODIFIEDDATE_"+sGXsfl_46_idx;
         edtPurchaseOrderClosedDate_Internalname = sPrefix+"PURCHASEORDERCLOSEDDATE_"+sGXsfl_46_idx;
         edtPurchaseOrderTotalPaid_Internalname = sPrefix+"PURCHASEORDERTOTALPAID_"+sGXsfl_46_idx;
         edtavState_Internalname = sPrefix+"vSTATE_"+sGXsfl_46_idx;
         chkPurchaseOrderActive_Internalname = sPrefix+"PURCHASEORDERACTIVE_"+sGXsfl_46_idx;
         edtavDetail_Internalname = sPrefix+"vDETAIL_"+sGXsfl_46_idx;
         edtavVoucher_Internalname = sPrefix+"vVOUCHER_"+sGXsfl_46_idx;
      }

      protected void SubsflControlProps_fel_462( )
      {
         edtPurchaseOrderId_Internalname = sPrefix+"PURCHASEORDERID_"+sGXsfl_46_fel_idx;
         edtPurchaseOrderCreatedDate_Internalname = sPrefix+"PURCHASEORDERCREATEDDATE_"+sGXsfl_46_fel_idx;
         edtPurchaseOrderModifiedDate_Internalname = sPrefix+"PURCHASEORDERMODIFIEDDATE_"+sGXsfl_46_fel_idx;
         edtPurchaseOrderClosedDate_Internalname = sPrefix+"PURCHASEORDERCLOSEDDATE_"+sGXsfl_46_fel_idx;
         edtPurchaseOrderTotalPaid_Internalname = sPrefix+"PURCHASEORDERTOTALPAID_"+sGXsfl_46_fel_idx;
         edtavState_Internalname = sPrefix+"vSTATE_"+sGXsfl_46_fel_idx;
         chkPurchaseOrderActive_Internalname = sPrefix+"PURCHASEORDERACTIVE_"+sGXsfl_46_fel_idx;
         edtavDetail_Internalname = sPrefix+"vDETAIL_"+sGXsfl_46_fel_idx;
         edtavVoucher_Internalname = sPrefix+"vVOUCHER_"+sGXsfl_46_fel_idx;
      }

      protected void sendrow_462( )
      {
         SubsflControlProps_462( ) ;
         WB1D0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_46_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0x0);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_46_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"ViewGrid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_46_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "attribute-description";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPurchaseOrderId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A50PurchaseOrderId), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A50PurchaseOrderId), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPurchaseOrderId_Jsonclick,(short)0,(string)"attribute-description",(string)"",(string)ROClassString,(string)"column",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)46,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPurchaseOrderCreatedDate_Internalname,context.localUtil.Format(A52PurchaseOrderCreatedDate, "99/99/99"),context.localUtil.Format( A52PurchaseOrderCreatedDate, "99/99/99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPurchaseOrderCreatedDate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)46,(short)0,(short)-1,(short)0,(bool)true,(string)"PurchaseOrderDate",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPurchaseOrderModifiedDate_Internalname,context.localUtil.Format(A53PurchaseOrderModifiedDate, "99/99/99"),context.localUtil.Format( A53PurchaseOrderModifiedDate, "99/99/99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPurchaseOrderModifiedDate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)46,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPurchaseOrderClosedDate_Internalname,context.localUtil.Format(A66PurchaseOrderClosedDate, "99/99/99"),context.localUtil.Format( A66PurchaseOrderClosedDate, "99/99/99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPurchaseOrderClosedDate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)46,(short)0,(short)-1,(short)0,(bool)true,(string)"PurchaseOrderDate",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPurchaseOrderTotalPaid_Internalname,StringUtil.LTrim( StringUtil.NToC( A78PurchaseOrderTotalPaid, 18, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A78PurchaseOrderTotalPaid, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPurchaseOrderTotalPaid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)46,(short)0,(short)-1,(short)0,(bool)true,(string)"Price",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavState_Enabled!=0)&&(edtavState_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 52,'"+sPrefix+"',false,'"+sGXsfl_46_idx+"',46)\"" : " ");
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavState_Internalname,(string)AV21State,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavState_Enabled!=0)&&(edtavState_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,52);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavState_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column WWOptionalColumn",(string)"",(short)-1,(int)edtavState_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)46,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "PURCHASEORDERACTIVE_" + sGXsfl_46_idx;
            chkPurchaseOrderActive.Name = GXCCtl;
            chkPurchaseOrderActive.WebTags = "";
            chkPurchaseOrderActive.Caption = "";
            AssignProp(sPrefix, false, chkPurchaseOrderActive_Internalname, "TitleCaption", chkPurchaseOrderActive.Caption, !bGXsfl_46_Refreshing);
            chkPurchaseOrderActive.CheckedValue = "false";
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkPurchaseOrderActive_Internalname,StringUtil.BoolToStr( A79PurchaseOrderActive),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"column WWOptionalColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavDetail_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavDetail_Enabled!=0)&&(edtavDetail_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 54,'"+sPrefix+"',false,'"+sGXsfl_46_idx+"',46)\"" : " ");
            ROClassString = "TextActionAttribute TextLikeLink";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDetail_Internalname,(string)AV17Detail,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavDetail_Enabled!=0)&&(edtavDetail_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,54);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+"e151d2_client"+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDetail_Jsonclick,(short)7,(string)"TextActionAttribute TextLikeLink",(string)"",(string)ROClassString,(string)"WWTextActionColumn",(string)"",(int)edtavDetail_Visible,(int)edtavDetail_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)46,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtavVoucher_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavVoucher_Enabled!=0)&&(edtavVoucher_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 55,'"+sPrefix+"',false,'"+sGXsfl_46_idx+"',46)\"" : " ");
            ROClassString = "TextActionAttribute TextLikeLink";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavVoucher_Internalname,(string)AV22Voucher,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavVoucher_Enabled!=0)&&(edtavVoucher_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,55);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+"e161d2_client"+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavVoucher_Jsonclick,(short)7,(string)"TextActionAttribute TextLikeLink",(string)"",(string)ROClassString,(string)"WWTextActionColumn",(string)"",(int)edtavVoucher_Visible,(int)edtavVoucher_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)46,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes1D2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_46_idx = ((subGrid_Islastpage==1)&&(nGXsfl_46_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_46_idx+1);
            sGXsfl_46_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_46_idx), 4, 0), 4, "0");
            SubsflControlProps_462( ) ;
         }
         /* End function sendrow_462 */
      }

      protected void init_web_controls( )
      {
         cmbavPurchaseorderstate.Name = "vPURCHASEORDERSTATE";
         cmbavPurchaseorderstate.WebTags = "";
         cmbavPurchaseorderstate.addItem("", "(all)", 0);
         cmbavPurchaseorderstate.addItem("Pending", "Pending", 0);
         cmbavPurchaseorderstate.addItem("Canceled", "Canceled", 0);
         cmbavPurchaseorderstate.addItem("Received", "Received", 0);
         if ( cmbavPurchaseorderstate.ItemCount > 0 )
         {
         }
         cmbavOrderby.Name = "vORDERBY";
         cmbavOrderby.WebTags = "";
         cmbavOrderby.addItem("1", "Nro", 0);
         cmbavOrderby.addItem("2", "Created", 0);
         cmbavOrderby.addItem("3", "Closed", 0);
         cmbavOrderby.addItem("4", "Total Paid", 0);
         if ( cmbavOrderby.ItemCount > 0 )
         {
         }
         chkavOrderbydesc.Name = "vORDERBYDESC";
         chkavOrderbydesc.WebTags = "";
         chkavOrderbydesc.Caption = "";
         AssignProp(sPrefix, false, chkavOrderbydesc_Internalname, "TitleCaption", chkavOrderbydesc.Caption, true);
         chkavOrderbydesc.CheckedValue = "false";
         GXCCtl = "PURCHASEORDERACTIVE_" + sGXsfl_46_idx;
         chkPurchaseOrderActive.Name = GXCCtl;
         chkPurchaseOrderActive.WebTags = "";
         chkPurchaseOrderActive.Caption = "";
         AssignProp(sPrefix, false, chkPurchaseOrderActive_Internalname, "TitleCaption", chkPurchaseOrderActive.Caption, !bGXsfl_46_Refreshing);
         chkPurchaseOrderActive.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void StartGridControl46( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"46\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "ViewGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid_Backcolorstyle == 0 )
            {
               subGrid_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid_Class) > 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Title";
               }
            }
            else
            {
               subGrid_Titlebackstyle = 1;
               if ( subGrid_Backcolorstyle == 1 )
               {
                  subGrid_Titlebackcolor = subGrid_Allbackcolor;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"attribute-description"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Nro") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Created") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Modified") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Closed Date") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Total Paid") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "State") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Order Active") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"TextActionAttribute TextLikeLink"+"\" "+" style=\""+((edtavDetail_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"TextActionAttribute TextLikeLink"+"\" "+" style=\""+((edtavVoucher_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridContainer = new GXWebGrid( context);
            }
            else
            {
               GridContainer.Clear();
            }
            GridContainer.SetWrapped(nGXWrapped);
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", "ViewGrid");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", sPrefix);
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A50PurchaseOrderId), 6, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A52PurchaseOrderCreatedDate, "99/99/99")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A53PurchaseOrderModifiedDate, "99/99/99")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A66PurchaseOrderClosedDate, "99/99/99")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A78PurchaseOrderTotalPaid, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV21State));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavState_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A79PurchaseOrderActive)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV17Detail));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDetail_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDetail_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV22Voucher));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavVoucher_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavVoucher_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         bttBtnexport_Internalname = sPrefix+"BTNEXPORT";
         bttBtnstatistic_Internalname = sPrefix+"BTNSTATISTIC";
         divTabletop_Internalname = sPrefix+"TABLETOP";
         edtavPurchaseorderid_Internalname = sPrefix+"vPURCHASEORDERID";
         cmbavPurchaseorderstate_Internalname = sPrefix+"vPURCHASEORDERSTATE";
         cmbavOrderby_Internalname = sPrefix+"vORDERBY";
         chkavOrderbydesc_Internalname = sPrefix+"vORDERBYDESC";
         divTable1_Internalname = sPrefix+"TABLE1";
         edtPurchaseOrderId_Internalname = sPrefix+"PURCHASEORDERID";
         edtPurchaseOrderCreatedDate_Internalname = sPrefix+"PURCHASEORDERCREATEDDATE";
         edtPurchaseOrderModifiedDate_Internalname = sPrefix+"PURCHASEORDERMODIFIEDDATE";
         edtPurchaseOrderClosedDate_Internalname = sPrefix+"PURCHASEORDERCLOSEDDATE";
         edtPurchaseOrderTotalPaid_Internalname = sPrefix+"PURCHASEORDERTOTALPAID";
         edtavState_Internalname = sPrefix+"vSTATE";
         chkPurchaseOrderActive_Internalname = sPrefix+"PURCHASEORDERACTIVE";
         edtavDetail_Internalname = sPrefix+"vDETAIL";
         edtavVoucher_Internalname = sPrefix+"vVOUCHER";
         divGridcontainer_Internalname = sPrefix+"GRIDCONTAINER";
         divGridtable_Internalname = sPrefix+"GRIDTABLE";
         divGridcell_Internalname = sPrefix+"GRIDCELL";
         edtSupplierId_Internalname = sPrefix+"SUPPLIERID";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGrid_Internalname = sPrefix+"GRID";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("mtaKB", true);
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         chkavOrderbydesc.Caption = "Desc";
         edtavVoucher_Jsonclick = "";
         edtavDetail_Jsonclick = "";
         chkPurchaseOrderActive.Caption = "";
         edtavState_Jsonclick = "";
         edtavState_Visible = -1;
         edtavState_Enabled = 1;
         edtPurchaseOrderTotalPaid_Jsonclick = "";
         edtPurchaseOrderClosedDate_Jsonclick = "";
         edtPurchaseOrderModifiedDate_Jsonclick = "";
         edtPurchaseOrderCreatedDate_Jsonclick = "";
         edtPurchaseOrderId_Jsonclick = "";
         subGrid_Class = "ViewGrid";
         subGrid_Backcolorstyle = 0;
         edtSupplierId_Jsonclick = "";
         edtSupplierId_Enabled = 0;
         edtSupplierId_Visible = 1;
         chkavOrderbydesc.Enabled = 1;
         cmbavOrderby_Jsonclick = "";
         cmbavOrderby.Enabled = 1;
         cmbavPurchaseorderstate_Jsonclick = "";
         cmbavPurchaseorderstate.Enabled = 1;
         edtavPurchaseorderid_Jsonclick = "";
         edtavPurchaseorderid_Enabled = 1;
         edtavVoucher_Enabled = 1;
         edtavVoucher_Visible = -1;
         edtavDetail_Enabled = 1;
         edtavDetail_Visible = -1;
         subGrid_Rows = 0;
         context.GX_msglist.DisplayMode = 1;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV19PurchaseOrderId',fld:'vPURCHASEORDERID',pic:'ZZZZZ9'},{av:'cmbavPurchaseorderstate'},{av:'AV20PurchaseOrderState',fld:'vPURCHASEORDERSTATE',pic:''},{av:'cmbavOrderby'},{av:'AV23OrderBy',fld:'vORDERBY',pic:'ZZZ9'},{av:'AV6SupplierId',fld:'vSUPPLIERID',pic:'ZZZZZ9'},{av:'AV17Detail',fld:'vDETAIL',pic:''},{av:'edtavDetail_Visible',ctrl:'vDETAIL',prop:'Visible'},{av:'edtavDetail_Enabled',ctrl:'vDETAIL',prop:'Enabled'},{av:'AV22Voucher',fld:'vVOUCHER',pic:''},{av:'edtavVoucher_Visible',ctrl:'vVOUCHER',prop:'Visible'},{av:'edtavVoucher_Enabled',ctrl:'vVOUCHER',prop:'Enabled'},{av:'sPrefix'},{av:'AV24OrderByDesc',fld:'vORDERBYDESC',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("GRID.LOAD","{handler:'E141D2',iparms:[{av:'A50PurchaseOrderId',fld:'PURCHASEORDERID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'AV21State',fld:'vSTATE',pic:''}]}");
         setEventMetadata("'DETAILS'","{handler:'E151D2',iparms:[{av:'A50PurchaseOrderId',fld:'PURCHASEORDERID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("'DETAILS'",",oparms:[]}");
         setEventMetadata("'DOEXPORT'","{handler:'E121D2',iparms:[{av:'A50PurchaseOrderId',fld:'PURCHASEORDERID',pic:'ZZZZZ9',hsh:true},{av:'AV6SupplierId',fld:'vSUPPLIERID',pic:'ZZZZZ9'},{av:'cmbavPurchaseorderstate'},{av:'AV20PurchaseOrderState',fld:'vPURCHASEORDERSTATE',pic:''},{av:'A52PurchaseOrderCreatedDate',fld:'PURCHASEORDERCREATEDDATE',pic:'',hsh:true},{av:'A66PurchaseOrderClosedDate',fld:'PURCHASEORDERCLOSEDDATE',pic:'',hsh:true}]");
         setEventMetadata("'DOEXPORT'",",oparms:[]}");
         setEventMetadata("'VOUCHER'","{handler:'E161D2',iparms:[{av:'A50PurchaseOrderId',fld:'PURCHASEORDERID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("'VOUCHER'",",oparms:[]}");
         setEventMetadata("'STATISTIC'","{handler:'E111D1',iparms:[{av:'AV6SupplierId',fld:'vSUPPLIERID',pic:'ZZZZZ9'}]");
         setEventMetadata("'STATISTIC'",",oparms:[]}");
         setEventMetadata("GRID_FIRSTPAGE","{handler:'subgrid_firstpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV19PurchaseOrderId',fld:'vPURCHASEORDERID',pic:'ZZZZZ9'},{av:'cmbavPurchaseorderstate'},{av:'AV20PurchaseOrderState',fld:'vPURCHASEORDERSTATE',pic:''},{av:'cmbavOrderby'},{av:'AV23OrderBy',fld:'vORDERBY',pic:'ZZZ9'},{av:'AV6SupplierId',fld:'vSUPPLIERID',pic:'ZZZZZ9'},{av:'AV17Detail',fld:'vDETAIL',pic:''},{av:'edtavDetail_Visible',ctrl:'vDETAIL',prop:'Visible'},{av:'edtavDetail_Enabled',ctrl:'vDETAIL',prop:'Enabled'},{av:'AV22Voucher',fld:'vVOUCHER',pic:''},{av:'edtavVoucher_Visible',ctrl:'vVOUCHER',prop:'Visible'},{av:'edtavVoucher_Enabled',ctrl:'vVOUCHER',prop:'Enabled'},{av:'sPrefix'},{av:'AV24OrderByDesc',fld:'vORDERBYDESC',pic:''}]");
         setEventMetadata("GRID_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID_PREVPAGE","{handler:'subgrid_previouspage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV19PurchaseOrderId',fld:'vPURCHASEORDERID',pic:'ZZZZZ9'},{av:'cmbavPurchaseorderstate'},{av:'AV20PurchaseOrderState',fld:'vPURCHASEORDERSTATE',pic:''},{av:'cmbavOrderby'},{av:'AV23OrderBy',fld:'vORDERBY',pic:'ZZZ9'},{av:'AV6SupplierId',fld:'vSUPPLIERID',pic:'ZZZZZ9'},{av:'AV17Detail',fld:'vDETAIL',pic:''},{av:'edtavDetail_Visible',ctrl:'vDETAIL',prop:'Visible'},{av:'edtavDetail_Enabled',ctrl:'vDETAIL',prop:'Enabled'},{av:'AV22Voucher',fld:'vVOUCHER',pic:''},{av:'edtavVoucher_Visible',ctrl:'vVOUCHER',prop:'Visible'},{av:'edtavVoucher_Enabled',ctrl:'vVOUCHER',prop:'Enabled'},{av:'sPrefix'},{av:'AV24OrderByDesc',fld:'vORDERBYDESC',pic:''}]");
         setEventMetadata("GRID_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID_NEXTPAGE","{handler:'subgrid_nextpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV19PurchaseOrderId',fld:'vPURCHASEORDERID',pic:'ZZZZZ9'},{av:'cmbavPurchaseorderstate'},{av:'AV20PurchaseOrderState',fld:'vPURCHASEORDERSTATE',pic:''},{av:'cmbavOrderby'},{av:'AV23OrderBy',fld:'vORDERBY',pic:'ZZZ9'},{av:'AV6SupplierId',fld:'vSUPPLIERID',pic:'ZZZZZ9'},{av:'AV17Detail',fld:'vDETAIL',pic:''},{av:'edtavDetail_Visible',ctrl:'vDETAIL',prop:'Visible'},{av:'edtavDetail_Enabled',ctrl:'vDETAIL',prop:'Enabled'},{av:'AV22Voucher',fld:'vVOUCHER',pic:''},{av:'edtavVoucher_Visible',ctrl:'vVOUCHER',prop:'Visible'},{av:'edtavVoucher_Enabled',ctrl:'vVOUCHER',prop:'Enabled'},{av:'sPrefix'},{av:'AV24OrderByDesc',fld:'vORDERBYDESC',pic:''}]");
         setEventMetadata("GRID_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID_LASTPAGE","{handler:'subgrid_lastpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV19PurchaseOrderId',fld:'vPURCHASEORDERID',pic:'ZZZZZ9'},{av:'cmbavPurchaseorderstate'},{av:'AV20PurchaseOrderState',fld:'vPURCHASEORDERSTATE',pic:''},{av:'cmbavOrderby'},{av:'AV23OrderBy',fld:'vORDERBY',pic:'ZZZ9'},{av:'AV6SupplierId',fld:'vSUPPLIERID',pic:'ZZZZZ9'},{av:'AV17Detail',fld:'vDETAIL',pic:''},{av:'edtavDetail_Visible',ctrl:'vDETAIL',prop:'Visible'},{av:'edtavDetail_Enabled',ctrl:'vDETAIL',prop:'Enabled'},{av:'AV22Voucher',fld:'vVOUCHER',pic:''},{av:'edtavVoucher_Visible',ctrl:'vVOUCHER',prop:'Visible'},{av:'edtavVoucher_Enabled',ctrl:'vVOUCHER',prop:'Enabled'},{av:'sPrefix'},{av:'AV24OrderByDesc',fld:'vORDERBYDESC',pic:''}]");
         setEventMetadata("GRID_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_PURCHASEORDERSTATE","{handler:'Validv_Purchaseorderstate',iparms:[]");
         setEventMetadata("VALIDV_PURCHASEORDERSTATE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Voucher',iparms:[]");
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
         sPrefix = "";
         AV17Detail = "";
         AV22Voucher = "";
         AV20PurchaseOrderState = "";
         AV27Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnexport_Jsonclick = "";
         bttBtnstatistic_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A52PurchaseOrderCreatedDate = DateTime.MinValue;
         A53PurchaseOrderModifiedDate = DateTime.MinValue;
         A66PurchaseOrderClosedDate = DateTime.MinValue;
         AV21State = "";
         scmdbuf = "";
         H001D2_A4SupplierId = new int[1] ;
         H001D2_A79PurchaseOrderActive = new bool[] {false} ;
         H001D2_A78PurchaseOrderTotalPaid = new decimal[1] ;
         H001D2_n78PurchaseOrderTotalPaid = new bool[] {false} ;
         H001D2_A66PurchaseOrderClosedDate = new DateTime[] {DateTime.MinValue} ;
         H001D2_n66PurchaseOrderClosedDate = new bool[] {false} ;
         H001D2_A53PurchaseOrderModifiedDate = new DateTime[] {DateTime.MinValue} ;
         H001D2_n53PurchaseOrderModifiedDate = new bool[] {false} ;
         H001D2_A52PurchaseOrderCreatedDate = new DateTime[] {DateTime.MinValue} ;
         H001D2_A50PurchaseOrderId = new int[1] ;
         H001D3_AGRID_nRecordCount = new long[1] ;
         GXt_SdtSDTContextSession1 = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         GXt_char2 = "";
         GridRow = new GXWebRow();
         AV10TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV8HTTPRequest = new GxHttpRequest( context);
         AV11TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         AV7Session = context.GetSession();
         AV15ExcelFilename = "";
         AV16ErrorMessage = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV6SupplierId = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.supplierpurchaseorderwc__default(),
            new Object[][] {
                new Object[] {
               H001D2_A4SupplierId, H001D2_A79PurchaseOrderActive, H001D2_A78PurchaseOrderTotalPaid, H001D2_n78PurchaseOrderTotalPaid, H001D2_A66PurchaseOrderClosedDate, H001D2_n66PurchaseOrderClosedDate, H001D2_A53PurchaseOrderModifiedDate, H001D2_n53PurchaseOrderModifiedDate, H001D2_A52PurchaseOrderCreatedDate, H001D2_A50PurchaseOrderId
               }
               , new Object[] {
               H001D3_AGRID_nRecordCount
               }
            }
         );
         AV27Pgmname = "SupplierPurchaseOrderWC";
         /* GeneXus formulas. */
         AV27Pgmname = "SupplierPurchaseOrderWC";
         context.Gx_err = 0;
         edtavState_Enabled = 0;
         edtavDetail_Enabled = 0;
         edtavVoucher_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV23OrderBy ;
      private short initialized ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int AV6SupplierId ;
      private int wcpOAV6SupplierId ;
      private int edtavDetail_Visible ;
      private int edtavDetail_Enabled ;
      private int edtavVoucher_Visible ;
      private int edtavVoucher_Enabled ;
      private int nRC_GXsfl_46 ;
      private int subGrid_Rows ;
      private int nGXsfl_46_idx=1 ;
      private int AV19PurchaseOrderId ;
      private int edtavState_Enabled ;
      private int edtavPurchaseorderid_Enabled ;
      private int A4SupplierId ;
      private int edtSupplierId_Enabled ;
      private int edtSupplierId_Visible ;
      private int A50PurchaseOrderId ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int edtavState_Visible ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal A78PurchaseOrderTotalPaid ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_46_idx="0001" ;
      private string edtavDetail_Internalname ;
      private string edtavVoucher_Internalname ;
      private string AV27Pgmname ;
      private string edtavState_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
      private string divGridcell_Internalname ;
      private string divGridtable_Internalname ;
      private string divTabletop_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnexport_Internalname ;
      private string bttBtnexport_Jsonclick ;
      private string bttBtnstatistic_Internalname ;
      private string bttBtnstatistic_Jsonclick ;
      private string divTable1_Internalname ;
      private string edtavPurchaseorderid_Internalname ;
      private string edtavPurchaseorderid_Jsonclick ;
      private string cmbavPurchaseorderstate_Internalname ;
      private string cmbavPurchaseorderstate_Jsonclick ;
      private string cmbavOrderby_Internalname ;
      private string cmbavOrderby_Jsonclick ;
      private string chkavOrderbydesc_Internalname ;
      private string divGridcontainer_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string edtSupplierId_Internalname ;
      private string edtSupplierId_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtPurchaseOrderId_Internalname ;
      private string edtPurchaseOrderCreatedDate_Internalname ;
      private string edtPurchaseOrderModifiedDate_Internalname ;
      private string edtPurchaseOrderClosedDate_Internalname ;
      private string edtPurchaseOrderTotalPaid_Internalname ;
      private string chkPurchaseOrderActive_Internalname ;
      private string scmdbuf ;
      private string GXt_char2 ;
      private string sCtrlAV6SupplierId ;
      private string sGXsfl_46_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtPurchaseOrderId_Jsonclick ;
      private string edtPurchaseOrderCreatedDate_Jsonclick ;
      private string edtPurchaseOrderModifiedDate_Jsonclick ;
      private string edtPurchaseOrderClosedDate_Jsonclick ;
      private string edtPurchaseOrderTotalPaid_Jsonclick ;
      private string edtavState_Jsonclick ;
      private string GXCCtl ;
      private string edtavDetail_Jsonclick ;
      private string edtavVoucher_Jsonclick ;
      private string subGrid_Header ;
      private DateTime A52PurchaseOrderCreatedDate ;
      private DateTime A53PurchaseOrderModifiedDate ;
      private DateTime A66PurchaseOrderClosedDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_46_Refreshing=false ;
      private bool AV24OrderByDesc ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n53PurchaseOrderModifiedDate ;
      private bool n66PurchaseOrderClosedDate ;
      private bool n78PurchaseOrderTotalPaid ;
      private bool A79PurchaseOrderActive ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV17Detail ;
      private string AV22Voucher ;
      private string AV20PurchaseOrderState ;
      private string AV21State ;
      private string AV15ExcelFilename ;
      private string AV16ErrorMessage ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavPurchaseorderstate ;
      private GXCombobox cmbavOrderby ;
      private GXCheckbox chkavOrderbydesc ;
      private GXCheckbox chkPurchaseOrderActive ;
      private IDataStoreProvider pr_default ;
      private int[] H001D2_A4SupplierId ;
      private bool[] H001D2_A79PurchaseOrderActive ;
      private decimal[] H001D2_A78PurchaseOrderTotalPaid ;
      private bool[] H001D2_n78PurchaseOrderTotalPaid ;
      private DateTime[] H001D2_A66PurchaseOrderClosedDate ;
      private bool[] H001D2_n66PurchaseOrderClosedDate ;
      private DateTime[] H001D2_A53PurchaseOrderModifiedDate ;
      private bool[] H001D2_n53PurchaseOrderModifiedDate ;
      private DateTime[] H001D2_A52PurchaseOrderCreatedDate ;
      private int[] H001D2_A50PurchaseOrderId ;
      private long[] H001D3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV8HTTPRequest ;
      private IGxSession AV7Session ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV10TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV11TrnContextAtt ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession GXt_SdtSDTContextSession1 ;
   }

   public class supplierpurchaseorderwc__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H001D2( IGxContext context ,
                                             int AV19PurchaseOrderId ,
                                             string AV20PurchaseOrderState ,
                                             int A50PurchaseOrderId ,
                                             bool A79PurchaseOrderActive ,
                                             DateTime A66PurchaseOrderClosedDate ,
                                             short AV23OrderBy ,
                                             bool AV24OrderByDesc ,
                                             int AV6SupplierId ,
                                             int A4SupplierId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[5];
         Object[] GXv_Object4 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [SupplierId], [PurchaseOrderActive], [PurchaseOrderTotalPaid], [PurchaseOrderClosedDate], [PurchaseOrderModifiedDate], [PurchaseOrderCreatedDate], [PurchaseOrderId]";
         sFromString = " FROM [PurchaseOrder]";
         sOrderString = "";
         AddWhere(sWhereString, "([SupplierId] = @AV6SupplierId)");
         if ( ! (0==AV19PurchaseOrderId) )
         {
            AddWhere(sWhereString, "([PurchaseOrderId] = @AV19PurchaseOrderId)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20PurchaseOrderState)) && ( StringUtil.StrCmp(AV20PurchaseOrderState, "Canceled") == 0 ) )
         {
            AddWhere(sWhereString, "(( Not [PurchaseOrderActive] = 1))");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20PurchaseOrderState)) && ( StringUtil.StrCmp(AV20PurchaseOrderState, "Pending") == 0 ) )
         {
            AddWhere(sWhereString, "(( [PurchaseOrderActive] = 1 and ( [PurchaseOrderClosedDate] IS NULL or ([PurchaseOrderClosedDate] = convert( DATETIME, '17530101', 112 )) or [PurchaseOrderClosedDate] = convert( DATETIME, '17530101', 112 ))))");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20PurchaseOrderState)) && ( StringUtil.StrCmp(AV20PurchaseOrderState, "Received") == 0 ) )
         {
            AddWhere(sWhereString, "(( [PurchaseOrderActive] = 1 and Not ( [PurchaseOrderClosedDate] IS NULL or ([PurchaseOrderClosedDate] = convert( DATETIME, '17530101', 112 )) or [PurchaseOrderClosedDate] = convert( DATETIME, '17530101', 112 ))))");
         }
         if ( ( AV23OrderBy == 1 ) && ! AV24OrderByDesc )
         {
            sOrderString += " ORDER BY [PurchaseOrderId]";
         }
         else if ( ( AV23OrderBy == 1 ) && AV24OrderByDesc )
         {
            sOrderString += " ORDER BY [PurchaseOrderId] DESC";
         }
         else if ( ( AV23OrderBy == 2 ) && ! AV24OrderByDesc )
         {
            sOrderString += " ORDER BY [PurchaseOrderCreatedDate]";
         }
         else if ( ( AV23OrderBy == 2 ) && AV24OrderByDesc )
         {
            sOrderString += " ORDER BY [PurchaseOrderCreatedDate] DESC";
         }
         else if ( ( AV23OrderBy == 3 ) && ! AV24OrderByDesc )
         {
            sOrderString += " ORDER BY [PurchaseOrderClosedDate]";
         }
         else if ( ( AV23OrderBy == 3 ) && AV24OrderByDesc )
         {
            sOrderString += " ORDER BY [PurchaseOrderClosedDate] DESC";
         }
         else if ( ( AV23OrderBy == 3 ) && ! AV24OrderByDesc )
         {
            sOrderString += " ORDER BY [PurchaseOrderTotalPaid]";
         }
         else if ( ( AV23OrderBy == 3 ) && AV24OrderByDesc )
         {
            sOrderString += " ORDER BY [PurchaseOrderTotalPaid] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY [PurchaseOrderId]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_H001D3( IGxContext context ,
                                             int AV19PurchaseOrderId ,
                                             string AV20PurchaseOrderState ,
                                             int A50PurchaseOrderId ,
                                             bool A79PurchaseOrderActive ,
                                             DateTime A66PurchaseOrderClosedDate ,
                                             short AV23OrderBy ,
                                             bool AV24OrderByDesc ,
                                             int AV6SupplierId ,
                                             int A4SupplierId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[2];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [PurchaseOrder]";
         AddWhere(sWhereString, "([SupplierId] = @AV6SupplierId)");
         if ( ! (0==AV19PurchaseOrderId) )
         {
            AddWhere(sWhereString, "([PurchaseOrderId] = @AV19PurchaseOrderId)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20PurchaseOrderState)) && ( StringUtil.StrCmp(AV20PurchaseOrderState, "Canceled") == 0 ) )
         {
            AddWhere(sWhereString, "(( Not [PurchaseOrderActive] = 1))");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20PurchaseOrderState)) && ( StringUtil.StrCmp(AV20PurchaseOrderState, "Pending") == 0 ) )
         {
            AddWhere(sWhereString, "(( [PurchaseOrderActive] = 1 and ( [PurchaseOrderClosedDate] IS NULL or ([PurchaseOrderClosedDate] = convert( DATETIME, '17530101', 112 )) or [PurchaseOrderClosedDate] = convert( DATETIME, '17530101', 112 ))))");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20PurchaseOrderState)) && ( StringUtil.StrCmp(AV20PurchaseOrderState, "Received") == 0 ) )
         {
            AddWhere(sWhereString, "(( [PurchaseOrderActive] = 1 and Not ( [PurchaseOrderClosedDate] IS NULL or ([PurchaseOrderClosedDate] = convert( DATETIME, '17530101', 112 )) or [PurchaseOrderClosedDate] = convert( DATETIME, '17530101', 112 ))))");
         }
         scmdbuf += sWhereString;
         if ( ( AV23OrderBy == 1 ) && ! AV24OrderByDesc )
         {
            scmdbuf += "";
         }
         else if ( ( AV23OrderBy == 1 ) && AV24OrderByDesc )
         {
            scmdbuf += "";
         }
         else if ( ( AV23OrderBy == 2 ) && ! AV24OrderByDesc )
         {
            scmdbuf += "";
         }
         else if ( ( AV23OrderBy == 2 ) && AV24OrderByDesc )
         {
            scmdbuf += "";
         }
         else if ( ( AV23OrderBy == 3 ) && ! AV24OrderByDesc )
         {
            scmdbuf += "";
         }
         else if ( ( AV23OrderBy == 3 ) && AV24OrderByDesc )
         {
            scmdbuf += "";
         }
         else if ( ( AV23OrderBy == 3 ) && ! AV24OrderByDesc )
         {
            scmdbuf += "";
         }
         else if ( ( AV23OrderBy == 3 ) && AV24OrderByDesc )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H001D2(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (bool)dynConstraints[3] , (DateTime)dynConstraints[4] , (short)dynConstraints[5] , (bool)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] );
               case 1 :
                     return conditional_H001D3(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (bool)dynConstraints[3] , (DateTime)dynConstraints[4] , (short)dynConstraints[5] , (bool)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] );
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
          Object[] prmH001D2;
          prmH001D2 = new Object[] {
          new ParDef("@AV6SupplierId",GXType.Int32,6,0) ,
          new ParDef("@AV19PurchaseOrderId",GXType.Int32,6,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH001D3;
          prmH001D3 = new Object[] {
          new ParDef("@AV6SupplierId",GXType.Int32,6,0) ,
          new ParDef("@AV19PurchaseOrderId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("H001D2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001D2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H001D3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001D3,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(6);
                ((int[]) buf[9])[0] = rslt.getInt(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
