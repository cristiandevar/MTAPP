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
   public class wwpurchaseorder : GXDataArea
   {
      public wwpurchaseorder( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public wwpurchaseorder( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavPurchaseorderstate = new GXCombobox();
         dynavFiltersupplier = new GXCombobox();
         cmbavFilterstate = new GXCombobox();
         cmbavFilterorder = new GXCombobox();
         chkavFilterorderdesc = new GXCheckbox();
         chkPurchaseOrderActive = new GXCheckbox();
         chkPurchaseOrderWasPaid = new GXCheckbox();
         cmbavState = new GXCombobox();
         cmbavOrderedby = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vFILTERSUPPLIER") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvFILTERSUPPLIER122( ) ;
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
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
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
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_70 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_70"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_70_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_70_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_70_idx = GetPar( "sGXsfl_70_idx");
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
         cmbavPurchaseorderstate.FromJSonString( GetNextPar( ));
         AV18PurchaseOrderState = GetPar( "PurchaseOrderState");
         cmbavOrderedby.FromJSonString( GetNextPar( ));
         AV19OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV20CreatedDateFrom = context.localUtil.ParseDateParm( GetPar( "CreatedDateFrom"));
         AV21CreatedDateTo = context.localUtil.ParseDateParm( GetPar( "CreatedDateTo"));
         AV22ClosedDateFrom = context.localUtil.ParseDateParm( GetPar( "ClosedDateFrom"));
         AV23ClosedDateTo = context.localUtil.ParseDateParm( GetPar( "ClosedDateTo"));
         dynavFiltersupplier.FromJSonString( GetNextPar( ));
         AV37FilterSupplier = (int)(Math.Round(NumberUtil.Val( GetPar( "FilterSupplier"), "."), 18, MidpointRounding.ToEven));
         AV35FilterOrderDesc = StringUtil.StrToBool( GetPar( "FilterOrderDesc"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV18PurchaseOrderState, AV19OrderedBy, AV20CreatedDateFrom, AV21CreatedDateTo, AV22ClosedDateFrom, AV23ClosedDateTo, AV37FilterSupplier, AV35FilterOrderDesc) ;
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
         PA122( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START122( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpurchaseorder.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vPURCHASEORDERSTATE", AV18PurchaseOrderState);
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCREATEDDATEFROM", context.localUtil.Format(AV20CreatedDateFrom, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vCREATEDDATETO", context.localUtil.Format(AV21CreatedDateTo, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vCLOSEDDATEFROM", context.localUtil.Format(AV22ClosedDateFrom, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vCLOSEDDATETO", context.localUtil.Format(AV23ClosedDateTo, "99/99/99"));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_70", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_70), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPURCHASEORDERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40PurchaseOrderId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vSUPPLIERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV41SupplierId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FILTERSCONTAINER_Class", StringUtil.RTrim( divFilterscontainer_Class));
         GxWebStd.gx_hidden_field( context, "CREATEDDATEFROMFILTERCONTAINER_Class", StringUtil.RTrim( divCreateddatefromfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CREATEDDATETOFILTERCONTAINER_Class", StringUtil.RTrim( divCreateddatetofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CLOSEDDATEFROMFILTERCONTAINER_Class", StringUtil.RTrim( divCloseddatefromfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CLOSEDDATETOFILTERCONTAINER_Class", StringUtil.RTrim( divCloseddatetofiltercontainer_Class));
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
            WE122( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT122( ) ;
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
         return formatLink("wwpurchaseorder.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPurchaseOrder" ;
      }

      public override string GetPgmdesc( )
      {
         return "Work With Purchase Order" ;
      }

      protected void WB120( )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "body-container", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcell_Internalname, 1, 0, "px", 0, "px", divGridcell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "container-fluid container-advanced", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabletop_Internalname, 1, 0, "px", 0, "px", "Flex ww__actions-container", "left", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ww__title-cell", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTitletext_Internalname, "Purchase Orders", "", "", lblTitletext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WWPurchaseOrder.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ww__actions-cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 15,'',false,'',0)\"";
            ClassString = "Button button-tertiary";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(70), 2, 0)+","+"null"+");", "Export", bttBtnexport_Jsonclick, 5, "Export to Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPurchaseOrder.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ww__filter-cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavPurchaseorderstate_Internalname, "Purchase Order State", "gx-form-item attribute-searchLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'" + sGXsfl_70_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavPurchaseorderstate, cmbavPurchaseorderstate_Internalname, StringUtil.RTrim( AV18PurchaseOrderState), 1, cmbavPurchaseorderstate_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", cmbavPurchaseorderstate.Visible, cmbavPurchaseorderstate.Enabled, 1, 0, 0, "em", 0, "", "", "attribute-search", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,18);\"", "", true, 0, "HLP_WWPurchaseOrder.htm");
            cmbavPurchaseorderstate.CurrentValue = StringUtil.RTrim( AV18PurchaseOrderState);
            AssignProp("", false, cmbavPurchaseorderstate_Internalname, "Values", (string)(cmbavPurchaseorderstate.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ww__toggle-cell", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(70), 2, 0)+","+"null"+");", bttBtntoggle_Caption, bttBtntoggle_Jsonclick, 5, bttBtntoggle_Tooltiptext, "", StyleString, ClassString, bttBtntoggle_Visible, bttBtntoggle_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"E\\'OTHER\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPurchaseOrder.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavFilternro_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilternro_Internalname, "Nro", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'" + sGXsfl_70_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilternro_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV39FilterNro), 6, 0, ".", "")), StringUtil.LTrim( ((edtavFilternro_Enabled!=0) ? context.localUtil.Format( (decimal)(AV39FilterNro), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV39FilterNro), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFilternro_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilternro_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_WWPurchaseOrder.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavFiltercreatedfrom_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFiltercreatedfrom_Internalname, "Created From", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'" + sGXsfl_70_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFiltercreatedfrom_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFiltercreatedfrom_Internalname, context.localUtil.Format(AV30FilterCreatedFrom, "99/99/99"), context.localUtil.Format( AV30FilterCreatedFrom, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFiltercreatedfrom_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFiltercreatedfrom_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_WWPurchaseOrder.htm");
            GxWebStd.gx_bitmap( context, edtavFiltercreatedfrom_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavFiltercreatedfrom_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPurchaseOrder.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavFiltercreatedto_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFiltercreatedto_Internalname, "Created To", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_70_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFiltercreatedto_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFiltercreatedto_Internalname, context.localUtil.Format(AV31FilterCreatedTo, "99/99/99"), context.localUtil.Format( AV31FilterCreatedTo, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFiltercreatedto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFiltercreatedto_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_WWPurchaseOrder.htm");
            GxWebStd.gx_bitmap( context, edtavFiltercreatedto_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavFiltercreatedto_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPurchaseOrder.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavFilterclosedfrom_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilterclosedfrom_Internalname, "Closed From", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'" + sGXsfl_70_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFilterclosedfrom_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFilterclosedfrom_Internalname, context.localUtil.Format(AV32FilterClosedFrom, "99/99/99"), context.localUtil.Format( AV32FilterClosedFrom, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFilterclosedfrom_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterclosedfrom_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_WWPurchaseOrder.htm");
            GxWebStd.gx_bitmap( context, edtavFilterclosedfrom_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavFilterclosedfrom_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPurchaseOrder.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavFilterclosedto_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilterclosedto_Internalname, "Closed To", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'" + sGXsfl_70_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFilterclosedto_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFilterclosedto_Internalname, context.localUtil.Format(AV33FilterClosedTo, "99/99/99"), context.localUtil.Format( AV33FilterClosedTo, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFilterclosedto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterclosedto_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_WWPurchaseOrder.htm");
            GxWebStd.gx_bitmap( context, edtavFilterclosedto_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavFilterclosedto_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPurchaseOrder.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavFiltersupplier_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavFiltersupplier_Internalname, "Supplier", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'" + sGXsfl_70_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavFiltersupplier, dynavFiltersupplier_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV37FilterSupplier), 6, 0)), 1, dynavFiltersupplier_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavFiltersupplier.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 0, "HLP_WWPurchaseOrder.htm");
            dynavFiltersupplier.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV37FilterSupplier), 6, 0));
            AssignProp("", false, dynavFiltersupplier_Internalname, "Values", (string)(dynavFiltersupplier.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavFilterstate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavFilterstate_Internalname, "State", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'" + sGXsfl_70_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavFilterstate, cmbavFilterstate_Internalname, StringUtil.RTrim( AV29FilterState), 1, cmbavFilterstate_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavFilterstate.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "", true, 0, "HLP_WWPurchaseOrder.htm");
            cmbavFilterstate.CurrentValue = StringUtil.RTrim( AV29FilterState);
            AssignProp("", false, cmbavFilterstate_Internalname, "Values", (string)(cmbavFilterstate.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavFilterorder_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavFilterorder_Internalname, "Order By", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'" + sGXsfl_70_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavFilterorder, cmbavFilterorder_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV34FilterOrder), 4, 0)), 1, cmbavFilterorder_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavFilterorder.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", "", true, 0, "HLP_WWPurchaseOrder.htm");
            cmbavFilterorder.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV34FilterOrder), 4, 0));
            AssignProp("", false, cmbavFilterorder_Internalname, "Values", (string)(cmbavFilterorder.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavFilterorderdesc_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavFilterorderdesc_Internalname, "Desc.", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'" + sGXsfl_70_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavFilterorderdesc_Internalname, StringUtil.BoolToStr( AV35FilterOrderDesc), "", "Desc.", 1, chkavFilterorderdesc.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(61, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,61);\"");
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
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
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
            StartGridControl70( ) ;
         }
         if ( wbEnd == 70 )
         {
            wbEnd = 0;
            nRC_GXsfl_70 = (int)(nGXsfl_70_idx-1);
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
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 col-md-2 ww__filters-cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFilterscontainer_Internalname, 1, 0, "px", 0, "px", divFilterscontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Right", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'',0)\"";
            ClassString = "filters-container__close";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggleontable_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(70), 2, 0)+","+"null"+");", "Hide Filters", bttBtntoggleontable_Jsonclick, 7, "Hide Filters", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e11121_client"+"'", TempTags, "", 2, "HLP_WWPurchaseOrder.htm");
            GxWebStd.gx_div_end( context, "Right", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavOrderedby_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavOrderedby_Internalname, "Ordered By", "col-xs-12 attribute-comboLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'" + sGXsfl_70_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavOrderedby, cmbavOrderedby_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV19OrderedBy), 4, 0)), 1, cmbavOrderedby_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavOrderedby.Enabled, 0, 0, 0, "em", 0, "", "", "attribute-combo", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,90);\"", "", true, 0, "HLP_WWPurchaseOrder.htm");
            cmbavOrderedby.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19OrderedBy), 4, 0));
            AssignProp("", false, cmbavOrderedby_Internalname, "Values", (string)(cmbavOrderedby.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCreateddatefromfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCreateddatefromfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcreateddatefromfilter_Internalname, "Created From", "", "", lblLblcreateddatefromfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12121_client"+"'", "", "filter-item__label", 7, "", 1, 1, 0, 1, "HLP_WWPurchaseOrder.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCreateddatefrom_Internalname, "Created Date From", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'" + sGXsfl_70_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCreateddatefrom_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCreateddatefrom_Internalname, context.localUtil.Format(AV20CreatedDateFrom, "99/99/99"), context.localUtil.Format( AV20CreatedDateFrom, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,100);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCreateddatefrom_Jsonclick, 0, "Attribute", "", "", "", "", edtavCreateddatefrom_Visible, edtavCreateddatefrom_Enabled, 1, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "PurchaseOrderDate", "right", false, "", "HLP_WWPurchaseOrder.htm");
            GxWebStd.gx_bitmap( context, edtavCreateddatefrom_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((edtavCreateddatefrom_Visible==0)||(edtavCreateddatefrom_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPurchaseOrder.htm");
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
            GxWebStd.gx_div_start( context, divCreateddatetofiltercontainer_Internalname, 1, 0, "px", 0, "px", divCreateddatetofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcreateddatetofilter_Internalname, "Created To", "", "", lblLblcreateddatetofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13121_client"+"'", "", "filter-item__label", 7, "", 1, 1, 0, 1, "HLP_WWPurchaseOrder.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 filter-item__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCreateddateto_Internalname, "Created Date To", "col-sm-3 attribute-comboLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'',false,'" + sGXsfl_70_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCreateddateto_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCreateddateto_Internalname, context.localUtil.Format(AV21CreatedDateTo, "99/99/99"), context.localUtil.Format( AV21CreatedDateTo, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,110);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCreateddateto_Jsonclick, 0, "attribute-combo", "", "", "", "", edtavCreateddateto_Visible, edtavCreateddateto_Enabled, 1, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "PurchaseOrderDate", "right", false, "", "HLP_WWPurchaseOrder.htm");
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
            GxWebStd.gx_div_start( context, divCloseddatefromfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCloseddatefromfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcloseddatefromfilter_Internalname, "Closed From", "", "", lblLblcloseddatefromfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14121_client"+"'", "", "filter-item__label", 7, "", 1, 1, 0, 1, "HLP_WWPurchaseOrder.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 filter-item__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCloseddatefrom_Internalname, "Closed Date From", "col-sm-3 attribute-comboLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'',false,'" + sGXsfl_70_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCloseddatefrom_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCloseddatefrom_Internalname, context.localUtil.Format(AV22ClosedDateFrom, "99/99/99"), context.localUtil.Format( AV22ClosedDateFrom, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,120);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCloseddatefrom_Jsonclick, 0, "attribute-combo", "", "", "", "", edtavCloseddatefrom_Visible, edtavCloseddatefrom_Enabled, 1, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "PurchaseOrderDate", "right", false, "", "HLP_WWPurchaseOrder.htm");
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
            GxWebStd.gx_div_start( context, divCloseddatetofiltercontainer_Internalname, 1, 0, "px", 0, "px", divCloseddatetofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcloseddatetofilter_Internalname, "Closed To", "", "", lblLblcloseddatetofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15121_client"+"'", "", "filter-item__label", 7, "", 1, 1, 0, 1, "HLP_WWPurchaseOrder.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 filter-item__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCloseddateto_Internalname, "Closed Date To", "col-sm-3 attribute-comboLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 130,'',false,'" + sGXsfl_70_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCloseddateto_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCloseddateto_Internalname, context.localUtil.Format(AV23ClosedDateTo, "99/99/99"), context.localUtil.Format( AV23ClosedDateTo, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,130);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCloseddateto_Jsonclick, 0, "attribute-combo", "", "", "", "", edtavCloseddateto_Visible, edtavCloseddateto_Enabled, 1, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "PurchaseOrderDate", "right", false, "", "HLP_WWPurchaseOrder.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 70 )
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
                  context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START122( )
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
            Form.Meta.addItem("description", "Work With Purchase Order", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP120( ) ;
      }

      protected void WS122( )
      {
         START122( ) ;
         EVT122( ) ;
      }

      protected void EVT122( )
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
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E16122 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VFILTERSTATE.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E17122 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VFILTERCREATEDFROM.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E18122 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VFILTERCREATEDTO.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E19122 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VFILTERCLOSEDFROM.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E20122 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VFILTERCLOSEDTO.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E21122 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VFILTERORDER.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E22122 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VFILTERORDERDESC.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E23122 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VFILTERSUPPLIER.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E24122 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VFILTERNRO.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E25122 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'OTHER'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRIDPAGING");
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_70_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_70_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_70_idx), 4, 0), 4, "0");
                              SubsflControlProps_702( ) ;
                              A50PurchaseOrderId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPurchaseOrderId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A52PurchaseOrderCreatedDate = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtPurchaseOrderCreatedDate_Internalname), 0));
                              A5SupplierName = cgiGet( edtSupplierName_Internalname);
                              A78PurchaseOrderTotalPaid = context.localUtil.CToN( cgiGet( edtPurchaseOrderTotalPaid_Internalname), ".", ",");
                              n78PurchaseOrderTotalPaid = false;
                              A66PurchaseOrderClosedDate = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtPurchaseOrderClosedDate_Internalname), 0));
                              n66PurchaseOrderClosedDate = false;
                              A79PurchaseOrderActive = StringUtil.StrToBool( cgiGet( chkPurchaseOrderActive_Internalname));
                              A138PurchaseOrderWasPaid = StringUtil.StrToBool( cgiGet( chkPurchaseOrderWasPaid_Internalname));
                              n138PurchaseOrderWasPaid = false;
                              A67PurchaseOrderDetailsQuantity = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPurchaseOrderDetailsQuantity_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              n67PurchaseOrderDetailsQuantity = false;
                              cmbavState.Name = cmbavState_Internalname;
                              cmbavState.CurrentValue = cgiGet( cmbavState_Internalname);
                              AV28State = cgiGet( cmbavState_Internalname);
                              AssignAttri("", false, cmbavState_Internalname, AV28State);
                              AV27Details = cgiGet( edtavDetails_Internalname);
                              AssignAttri("", false, edtavDetails_Internalname, AV27Details);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E26122 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E27122 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E28122 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Purchaseorderstate Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPURCHASEORDERSTATE"), AV18PurchaseOrderState) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ".", ",") != Convert.ToDecimal( AV19OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Createddatefrom Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCREATEDDATEFROM"), 0) != AV20CreatedDateFrom )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Createddateto Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCREATEDDATETO"), 0) != AV21CreatedDateTo )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Closeddatefrom Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCLOSEDDATEFROM"), 0) != AV22ClosedDateFrom )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Closeddateto Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCLOSEDDATETO"), 0) != AV23ClosedDateTo )
                                       {
                                          Rfr0gs = true;
                                       }
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

      protected void WE122( )
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

      protected void PA122( )
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
               GX_FocusControl = cmbavPurchaseorderstate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVvFILTERSUPPLIER122( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvFILTERSUPPLIER_data122( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXVvFILTERSUPPLIER_html122( )
      {
         int gxdynajaxvalue;
         GXDLVvFILTERSUPPLIER_data122( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavFiltersupplier.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavFiltersupplier.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 6, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvFILTERSUPPLIER_data122( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(all)");
         /* Using cursor H00122 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00122_A4SupplierId[0]), 6, 0, ".", "")));
            gxdynajaxctrldescr.Add(H00122_A5SupplierName[0]);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_702( ) ;
         while ( nGXsfl_70_idx <= nRC_GXsfl_70 )
         {
            sendrow_702( ) ;
            nGXsfl_70_idx = ((subGrid_Islastpage==1)&&(nGXsfl_70_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_70_idx+1);
            sGXsfl_70_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_70_idx), 4, 0), 4, "0");
            SubsflControlProps_702( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV18PurchaseOrderState ,
                                       short AV19OrderedBy ,
                                       DateTime AV20CreatedDateFrom ,
                                       DateTime AV21CreatedDateTo ,
                                       DateTime AV22ClosedDateFrom ,
                                       DateTime AV23ClosedDateTo ,
                                       int AV37FilterSupplier ,
                                       bool AV35FilterOrderDesc )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF122( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
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
            GXVvFILTERSUPPLIER_html122( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( cmbavPurchaseorderstate.ItemCount > 0 )
         {
            AV18PurchaseOrderState = cmbavPurchaseorderstate.getValidValue(AV18PurchaseOrderState);
            AssignAttri("", false, "AV18PurchaseOrderState", AV18PurchaseOrderState);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavPurchaseorderstate.CurrentValue = StringUtil.RTrim( AV18PurchaseOrderState);
            AssignProp("", false, cmbavPurchaseorderstate_Internalname, "Values", cmbavPurchaseorderstate.ToJavascriptSource(), true);
         }
         if ( dynavFiltersupplier.ItemCount > 0 )
         {
            AV37FilterSupplier = (int)(Math.Round(NumberUtil.Val( dynavFiltersupplier.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV37FilterSupplier), 6, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV37FilterSupplier", StringUtil.LTrimStr( (decimal)(AV37FilterSupplier), 6, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavFiltersupplier.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV37FilterSupplier), 6, 0));
            AssignProp("", false, dynavFiltersupplier_Internalname, "Values", dynavFiltersupplier.ToJavascriptSource(), true);
         }
         if ( cmbavFilterstate.ItemCount > 0 )
         {
            AV29FilterState = cmbavFilterstate.getValidValue(AV29FilterState);
            AssignAttri("", false, "AV29FilterState", AV29FilterState);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavFilterstate.CurrentValue = StringUtil.RTrim( AV29FilterState);
            AssignProp("", false, cmbavFilterstate_Internalname, "Values", cmbavFilterstate.ToJavascriptSource(), true);
         }
         if ( cmbavFilterorder.ItemCount > 0 )
         {
            AV34FilterOrder = (short)(Math.Round(NumberUtil.Val( cmbavFilterorder.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV34FilterOrder), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV34FilterOrder", StringUtil.LTrimStr( (decimal)(AV34FilterOrder), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavFilterorder.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV34FilterOrder), 4, 0));
            AssignProp("", false, cmbavFilterorder_Internalname, "Values", cmbavFilterorder.ToJavascriptSource(), true);
         }
         AV35FilterOrderDesc = StringUtil.StrToBool( StringUtil.BoolToStr( AV35FilterOrderDesc));
         AssignAttri("", false, "AV35FilterOrderDesc", AV35FilterOrderDesc);
         if ( cmbavOrderedby.ItemCount > 0 )
         {
            AV19OrderedBy = (short)(Math.Round(NumberUtil.Val( cmbavOrderedby.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV19OrderedBy), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV19OrderedBy", StringUtil.LTrimStr( (decimal)(AV19OrderedBy), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavOrderedby.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19OrderedBy), 4, 0));
            AssignProp("", false, cmbavOrderedby_Internalname, "Values", cmbavOrderedby.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF122( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV44Pgmname = "WWPurchaseOrder";
         context.Gx_err = 0;
         cmbavState.Enabled = 0;
         AssignProp("", false, cmbavState_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavState.Enabled), 5, 0), !bGXsfl_70_Refreshing);
         edtavDetails_Enabled = 0;
         AssignProp("", false, edtavDetails_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDetails_Enabled), 5, 0), !bGXsfl_70_Refreshing);
      }

      protected void RF122( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 70;
         /* Execute user event: Refresh */
         E27122 ();
         nGXsfl_70_idx = 1;
         sGXsfl_70_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_70_idx), 4, 0), 4, "0");
         SubsflControlProps_702( ) ;
         bGXsfl_70_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "ww__grid");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_702( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV18PurchaseOrderState ,
                                                 AV20CreatedDateFrom ,
                                                 AV21CreatedDateTo ,
                                                 AV22ClosedDateFrom ,
                                                 AV23ClosedDateTo ,
                                                 AV41SupplierId ,
                                                 AV40PurchaseOrderId ,
                                                 A79PurchaseOrderActive ,
                                                 A66PurchaseOrderClosedDate ,
                                                 A52PurchaseOrderCreatedDate ,
                                                 A4SupplierId ,
                                                 A50PurchaseOrderId ,
                                                 AV19OrderedBy } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE,
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT
                                                 }
            });
            /* Using cursor H00124 */
            pr_default.execute(1, new Object[] {AV20CreatedDateFrom, AV21CreatedDateTo, AV22ClosedDateFrom, AV23ClosedDateTo, AV41SupplierId, AV40PurchaseOrderId, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_70_idx = 1;
            sGXsfl_70_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_70_idx), 4, 0), 4, "0");
            SubsflControlProps_702( ) ;
            while ( ( (pr_default.getStatus(1) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A4SupplierId = H00124_A4SupplierId[0];
               A138PurchaseOrderWasPaid = H00124_A138PurchaseOrderWasPaid[0];
               n138PurchaseOrderWasPaid = H00124_n138PurchaseOrderWasPaid[0];
               A79PurchaseOrderActive = H00124_A79PurchaseOrderActive[0];
               A66PurchaseOrderClosedDate = H00124_A66PurchaseOrderClosedDate[0];
               n66PurchaseOrderClosedDate = H00124_n66PurchaseOrderClosedDate[0];
               A78PurchaseOrderTotalPaid = H00124_A78PurchaseOrderTotalPaid[0];
               n78PurchaseOrderTotalPaid = H00124_n78PurchaseOrderTotalPaid[0];
               A5SupplierName = H00124_A5SupplierName[0];
               A52PurchaseOrderCreatedDate = H00124_A52PurchaseOrderCreatedDate[0];
               A50PurchaseOrderId = H00124_A50PurchaseOrderId[0];
               A67PurchaseOrderDetailsQuantity = H00124_A67PurchaseOrderDetailsQuantity[0];
               n67PurchaseOrderDetailsQuantity = H00124_n67PurchaseOrderDetailsQuantity[0];
               A5SupplierName = H00124_A5SupplierName[0];
               A67PurchaseOrderDetailsQuantity = H00124_A67PurchaseOrderDetailsQuantity[0];
               n67PurchaseOrderDetailsQuantity = H00124_n67PurchaseOrderDetailsQuantity[0];
               E28122 ();
               pr_default.readNext(1);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(1) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(1);
            wbEnd = 70;
            WB120( ) ;
         }
         bGXsfl_70_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes122( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PURCHASEORDERID"+"_"+sGXsfl_70_idx, GetSecureSignedToken( sGXsfl_70_idx, context.localUtil.Format( (decimal)(A50PurchaseOrderId), "ZZZZZ9"), context));
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
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV18PurchaseOrderState ,
                                              AV20CreatedDateFrom ,
                                              AV21CreatedDateTo ,
                                              AV22ClosedDateFrom ,
                                              AV23ClosedDateTo ,
                                              AV41SupplierId ,
                                              AV40PurchaseOrderId ,
                                              A79PurchaseOrderActive ,
                                              A66PurchaseOrderClosedDate ,
                                              A52PurchaseOrderCreatedDate ,
                                              A4SupplierId ,
                                              A50PurchaseOrderId ,
                                              AV19OrderedBy } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor H00126 */
         pr_default.execute(2, new Object[] {AV20CreatedDateFrom, AV21CreatedDateTo, AV22ClosedDateFrom, AV23ClosedDateTo, AV41SupplierId, AV40PurchaseOrderId});
         GRID_nRecordCount = H00126_AGRID_nRecordCount[0];
         pr_default.close(2);
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV18PurchaseOrderState, AV19OrderedBy, AV20CreatedDateFrom, AV21CreatedDateTo, AV22ClosedDateFrom, AV23ClosedDateTo, AV37FilterSupplier, AV35FilterOrderDesc) ;
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV18PurchaseOrderState, AV19OrderedBy, AV20CreatedDateFrom, AV21CreatedDateTo, AV22ClosedDateFrom, AV23ClosedDateTo, AV37FilterSupplier, AV35FilterOrderDesc) ;
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV18PurchaseOrderState, AV19OrderedBy, AV20CreatedDateFrom, AV21CreatedDateTo, AV22ClosedDateFrom, AV23ClosedDateTo, AV37FilterSupplier, AV35FilterOrderDesc) ;
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV18PurchaseOrderState, AV19OrderedBy, AV20CreatedDateFrom, AV21CreatedDateTo, AV22ClosedDateFrom, AV23ClosedDateTo, AV37FilterSupplier, AV35FilterOrderDesc) ;
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV18PurchaseOrderState, AV19OrderedBy, AV20CreatedDateFrom, AV21CreatedDateTo, AV22ClosedDateFrom, AV23ClosedDateTo, AV37FilterSupplier, AV35FilterOrderDesc) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void subgrid_varsfromstate( )
      {
         if ( GridState.FilterCount >= 1 )
         {
            AV18PurchaseOrderState = GridState.FilterValues("Purchaseorderstate");
            AssignAttri("", false, "AV18PurchaseOrderState", AV18PurchaseOrderState);
            AV20CreatedDateFrom = context.localUtil.CToD( GridState.FilterValues("Createddatefrom"), 1);
            AssignAttri("", false, "AV20CreatedDateFrom", context.localUtil.Format(AV20CreatedDateFrom, "99/99/99"));
            AV21CreatedDateTo = context.localUtil.CToD( GridState.FilterValues("Createddateto"), 1);
            AssignAttri("", false, "AV21CreatedDateTo", context.localUtil.Format(AV21CreatedDateTo, "99/99/99"));
            AV22ClosedDateFrom = context.localUtil.CToD( GridState.FilterValues("Closeddatefrom"), 1);
            AssignAttri("", false, "AV22ClosedDateFrom", context.localUtil.Format(AV22ClosedDateFrom, "99/99/99"));
            AV23ClosedDateTo = context.localUtil.CToD( GridState.FilterValues("Closeddateto"), 1);
            AssignAttri("", false, "AV23ClosedDateTo", context.localUtil.Format(AV23ClosedDateTo, "99/99/99"));
         }
         if ( GridState.OrderedBy != 0 )
         {
            AV19OrderedBy = GridState.OrderedBy;
            AssignAttri("", false, "AV19OrderedBy", StringUtil.LTrimStr( (decimal)(AV19OrderedBy), 4, 0));
         }
         if ( GridState.CurrentPage > 0 )
         {
            GridPageCount = subGrid_fnc_Pagecount( );
            if ( ( GridPageCount > 0 ) && ( GridPageCount < GridState.CurrentPage ) )
            {
               subgrid_gotopage( GridPageCount) ;
            }
            else
            {
               subgrid_gotopage( ((GridPageCount<0) ? 0 : GridState.CurrentPage)) ;
            }
         }
      }

      protected void subgrid_varstostate( )
      {
         GridState.CurrentPage = subGrid_fnc_Currentpage( );
         GridState.OrderedBy = AV19OrderedBy;
         GridState.ClearFilterValues();
         GridState.AddFilterValue("PurchaseOrderState", AV18PurchaseOrderState);
         GridState.AddFilterValue("CreatedDateFrom", context.localUtil.Format(AV20CreatedDateFrom, "99/99/99"));
         GridState.AddFilterValue("CreatedDateTo", context.localUtil.Format(AV21CreatedDateTo, "99/99/99"));
         GridState.AddFilterValue("ClosedDateFrom", context.localUtil.Format(AV22ClosedDateFrom, "99/99/99"));
         GridState.AddFilterValue("ClosedDateTo", context.localUtil.Format(AV23ClosedDateTo, "99/99/99"));
      }

      protected void before_start_formulas( )
      {
         AV44Pgmname = "WWPurchaseOrder";
         context.Gx_err = 0;
         cmbavState.Enabled = 0;
         AssignProp("", false, cmbavState_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavState.Enabled), 5, 0), !bGXsfl_70_Refreshing);
         edtavDetails_Enabled = 0;
         AssignProp("", false, edtavDetails_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDetails_Enabled), 5, 0), !bGXsfl_70_Refreshing);
         GXVvFILTERSUPPLIER_html122( ) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP120( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E26122 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_70 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_70"), ".", ","), 18, MidpointRounding.ToEven));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            cmbavPurchaseorderstate.Name = cmbavPurchaseorderstate_Internalname;
            cmbavPurchaseorderstate.CurrentValue = cgiGet( cmbavPurchaseorderstate_Internalname);
            AV18PurchaseOrderState = cgiGet( cmbavPurchaseorderstate_Internalname);
            AssignAttri("", false, "AV18PurchaseOrderState", AV18PurchaseOrderState);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavFilternro_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavFilternro_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vFILTERNRO");
               GX_FocusControl = edtavFilternro_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV39FilterNro = 0;
               AssignAttri("", false, "AV39FilterNro", StringUtil.LTrimStr( (decimal)(AV39FilterNro), 6, 0));
            }
            else
            {
               AV39FilterNro = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavFilternro_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV39FilterNro", StringUtil.LTrimStr( (decimal)(AV39FilterNro), 6, 0));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavFiltercreatedfrom_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Created From"}), 1, "vFILTERCREATEDFROM");
               GX_FocusControl = edtavFiltercreatedfrom_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV30FilterCreatedFrom = DateTime.MinValue;
               AssignAttri("", false, "AV30FilterCreatedFrom", context.localUtil.Format(AV30FilterCreatedFrom, "99/99/99"));
            }
            else
            {
               AV30FilterCreatedFrom = context.localUtil.CToD( cgiGet( edtavFiltercreatedfrom_Internalname), 1);
               AssignAttri("", false, "AV30FilterCreatedFrom", context.localUtil.Format(AV30FilterCreatedFrom, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavFiltercreatedto_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Created To"}), 1, "vFILTERCREATEDTO");
               GX_FocusControl = edtavFiltercreatedto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV31FilterCreatedTo = DateTime.MinValue;
               AssignAttri("", false, "AV31FilterCreatedTo", context.localUtil.Format(AV31FilterCreatedTo, "99/99/99"));
            }
            else
            {
               AV31FilterCreatedTo = context.localUtil.CToD( cgiGet( edtavFiltercreatedto_Internalname), 1);
               AssignAttri("", false, "AV31FilterCreatedTo", context.localUtil.Format(AV31FilterCreatedTo, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavFilterclosedfrom_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Closed From"}), 1, "vFILTERCLOSEDFROM");
               GX_FocusControl = edtavFilterclosedfrom_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV32FilterClosedFrom = DateTime.MinValue;
               AssignAttri("", false, "AV32FilterClosedFrom", context.localUtil.Format(AV32FilterClosedFrom, "99/99/99"));
            }
            else
            {
               AV32FilterClosedFrom = context.localUtil.CToD( cgiGet( edtavFilterclosedfrom_Internalname), 1);
               AssignAttri("", false, "AV32FilterClosedFrom", context.localUtil.Format(AV32FilterClosedFrom, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavFilterclosedto_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Closed To"}), 1, "vFILTERCLOSEDTO");
               GX_FocusControl = edtavFilterclosedto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV33FilterClosedTo = DateTime.MinValue;
               AssignAttri("", false, "AV33FilterClosedTo", context.localUtil.Format(AV33FilterClosedTo, "99/99/99"));
            }
            else
            {
               AV33FilterClosedTo = context.localUtil.CToD( cgiGet( edtavFilterclosedto_Internalname), 1);
               AssignAttri("", false, "AV33FilterClosedTo", context.localUtil.Format(AV33FilterClosedTo, "99/99/99"));
            }
            dynavFiltersupplier.Name = dynavFiltersupplier_Internalname;
            dynavFiltersupplier.CurrentValue = cgiGet( dynavFiltersupplier_Internalname);
            AV37FilterSupplier = (int)(Math.Round(NumberUtil.Val( cgiGet( dynavFiltersupplier_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV37FilterSupplier", StringUtil.LTrimStr( (decimal)(AV37FilterSupplier), 6, 0));
            cmbavFilterstate.Name = cmbavFilterstate_Internalname;
            cmbavFilterstate.CurrentValue = cgiGet( cmbavFilterstate_Internalname);
            AV29FilterState = cgiGet( cmbavFilterstate_Internalname);
            AssignAttri("", false, "AV29FilterState", AV29FilterState);
            cmbavFilterorder.Name = cmbavFilterorder_Internalname;
            cmbavFilterorder.CurrentValue = cgiGet( cmbavFilterorder_Internalname);
            AV34FilterOrder = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavFilterorder_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV34FilterOrder", StringUtil.LTrimStr( (decimal)(AV34FilterOrder), 4, 0));
            AV35FilterOrderDesc = StringUtil.StrToBool( cgiGet( chkavFilterorderdesc_Internalname));
            AssignAttri("", false, "AV35FilterOrderDesc", AV35FilterOrderDesc);
            cmbavOrderedby.Name = cmbavOrderedby_Internalname;
            cmbavOrderedby.CurrentValue = cgiGet( cmbavOrderedby_Internalname);
            AV19OrderedBy = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavOrderedby_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV19OrderedBy", StringUtil.LTrimStr( (decimal)(AV19OrderedBy), 4, 0));
            if ( context.localUtil.VCDate( cgiGet( edtavCreateddatefrom_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Created Date From"}), 1, "vCREATEDDATEFROM");
               GX_FocusControl = edtavCreateddatefrom_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV20CreatedDateFrom = DateTime.MinValue;
               AssignAttri("", false, "AV20CreatedDateFrom", context.localUtil.Format(AV20CreatedDateFrom, "99/99/99"));
            }
            else
            {
               AV20CreatedDateFrom = context.localUtil.CToD( cgiGet( edtavCreateddatefrom_Internalname), 1);
               AssignAttri("", false, "AV20CreatedDateFrom", context.localUtil.Format(AV20CreatedDateFrom, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCreateddateto_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Created Date To"}), 1, "vCREATEDDATETO");
               GX_FocusControl = edtavCreateddateto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV21CreatedDateTo = DateTime.MinValue;
               AssignAttri("", false, "AV21CreatedDateTo", context.localUtil.Format(AV21CreatedDateTo, "99/99/99"));
            }
            else
            {
               AV21CreatedDateTo = context.localUtil.CToD( cgiGet( edtavCreateddateto_Internalname), 1);
               AssignAttri("", false, "AV21CreatedDateTo", context.localUtil.Format(AV21CreatedDateTo, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCloseddatefrom_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Closed Date From"}), 1, "vCLOSEDDATEFROM");
               GX_FocusControl = edtavCloseddatefrom_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV22ClosedDateFrom = DateTime.MinValue;
               AssignAttri("", false, "AV22ClosedDateFrom", context.localUtil.Format(AV22ClosedDateFrom, "99/99/99"));
            }
            else
            {
               AV22ClosedDateFrom = context.localUtil.CToD( cgiGet( edtavCloseddatefrom_Internalname), 1);
               AssignAttri("", false, "AV22ClosedDateFrom", context.localUtil.Format(AV22ClosedDateFrom, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCloseddateto_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Closed Date To"}), 1, "vCLOSEDDATETO");
               GX_FocusControl = edtavCloseddateto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV23ClosedDateTo = DateTime.MinValue;
               AssignAttri("", false, "AV23ClosedDateTo", context.localUtil.Format(AV23ClosedDateTo, "99/99/99"));
            }
            else
            {
               AV23ClosedDateTo = context.localUtil.CToD( cgiGet( edtavCloseddateto_Internalname), 1);
               AssignAttri("", false, "AV23ClosedDateTo", context.localUtil.Format(AV23ClosedDateTo, "99/99/99"));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPURCHASEORDERSTATE"), AV18PurchaseOrderState) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ".", ",") != Convert.ToDecimal( AV19OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCREATEDDATEFROM"), 1) ) != DateTimeUtil.ResetTime ( AV20CreatedDateFrom ) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCREATEDDATETO"), 1) ) != DateTimeUtil.ResetTime ( AV21CreatedDateTo ) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCLOSEDDATEFROM"), 1) ) != DateTimeUtil.ResetTime ( AV22ClosedDateFrom ) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCLOSEDDATETO"), 1) ) != DateTimeUtil.ResetTime ( AV23ClosedDateTo ) )
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
         E26122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E26122( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtSDTContextSession1 = new GeneXus.Programs.general.ui.SdtSDTContextSession();
         new checkauthentication(context ).execute( out  GXt_SdtSDTContextSession1) ;
         if ( ! new haspermission(context).executeUdp(  "purchaseorder view") )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV44Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV44Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV44Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         AV19OrderedBy = 1;
         AssignAttri("", false, "AV19OrderedBy", StringUtil.LTrimStr( (decimal)(AV19OrderedBy), 4, 0));
         Form.Caption = "Purchase Orders";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         GridState.LoadGridState();
         bttBtntoggle_Visible = 0;
         AssignProp("", false, bttBtntoggle_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntoggle_Visible), 5, 0), true);
         bttBtntoggle_Enabled = 0;
         AssignProp("", false, bttBtntoggle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntoggle_Enabled), 5, 0), true);
         cmbavPurchaseorderstate.Visible = 0;
         AssignProp("", false, cmbavPurchaseorderstate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavPurchaseorderstate.Visible), 5, 0), true);
         cmbavPurchaseorderstate.Enabled = 0;
         AssignProp("", false, cmbavPurchaseorderstate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavPurchaseorderstate.Enabled), 5, 0), true);
         edtavCreateddatefrom_Visible = 0;
         AssignProp("", false, edtavCreateddatefrom_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCreateddatefrom_Visible), 5, 0), true);
         edtavCreateddatefrom_Enabled = 0;
         AssignProp("", false, edtavCreateddatefrom_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCreateddatefrom_Enabled), 5, 0), true);
         edtavCreateddateto_Visible = 0;
         AssignProp("", false, edtavCreateddateto_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCreateddateto_Visible), 5, 0), true);
         edtavCreateddateto_Enabled = 0;
         AssignProp("", false, edtavCreateddateto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCreateddateto_Enabled), 5, 0), true);
         edtavCloseddatefrom_Visible = 0;
         AssignProp("", false, edtavCloseddatefrom_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCloseddatefrom_Visible), 5, 0), true);
         edtavCloseddatefrom_Enabled = 0;
         AssignProp("", false, edtavCloseddatefrom_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCloseddatefrom_Enabled), 5, 0), true);
         edtavCloseddateto_Visible = 0;
         AssignProp("", false, edtavCloseddateto_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCloseddateto_Visible), 5, 0), true);
         edtavCloseddateto_Enabled = 0;
         AssignProp("", false, edtavCloseddateto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCloseddateto_Enabled), 5, 0), true);
      }

      protected void E27122( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         GridState.SaveGridState();
      }

      private void E28122( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         if ( ! A79PurchaseOrderActive )
         {
            AV28State = "Canceled";
            AssignAttri("", false, cmbavState_Internalname, AV28State);
         }
         else if ( A79PurchaseOrderActive && ( (DateTime.MinValue==A66PurchaseOrderClosedDate) || (DateTime.MinValue==A66PurchaseOrderClosedDate) || ( DateTimeUtil.ResetTime ( A66PurchaseOrderClosedDate ) == DateTimeUtil.ResetTime ( DateTime.MinValue ) ) || (DateTime.MinValue==A66PurchaseOrderClosedDate) ) )
         {
            AV28State = "Pending";
            AssignAttri("", false, cmbavState_Internalname, AV28State);
         }
         else if ( A79PurchaseOrderActive && ! ( (DateTime.MinValue==A66PurchaseOrderClosedDate) || (DateTime.MinValue==A66PurchaseOrderClosedDate) || ( DateTimeUtil.ResetTime ( A66PurchaseOrderClosedDate ) == DateTimeUtil.ResetTime ( DateTime.MinValue ) ) || (DateTime.MinValue==A66PurchaseOrderClosedDate) ) )
         {
            AV28State = "Received";
            AssignAttri("", false, cmbavState_Internalname, AV28State);
         }
         else
         {
            AV28State = "";
            AssignAttri("", false, cmbavState_Internalname, AV28State);
         }
         AV27Details = "Details";
         AssignAttri("", false, edtavDetails_Internalname, AV27Details);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 70;
         }
         sendrow_702( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_70_Refreshing )
         {
            DoAjaxLoad(70, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavState.CurrentValue = StringUtil.RTrim( AV28State);
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV44Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "PurchaseOrder";
         AV6Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      protected void E16122( )
      {
         /* 'DoExport' Routine */
         returnInSub = false;
         new exportwwpurchaseorder(context ).execute(  AV40PurchaseOrderId,  AV41SupplierId,  AV18PurchaseOrderState,  AV20CreatedDateFrom,  AV21CreatedDateTo,  AV22ClosedDateFrom,  AV23ClosedDateTo,  AV19OrderedBy, out  AV24ExcelFilename, out  AV25ErrorMessage) ;
         if ( StringUtil.StrCmp(AV24ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV24ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV25ErrorMessage);
         }
      }

      protected void E17122( )
      {
         /* Filterstate_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'UPDVARIABLES' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavPurchaseorderstate.CurrentValue = StringUtil.RTrim( AV18PurchaseOrderState);
         AssignProp("", false, cmbavPurchaseorderstate_Internalname, "Values", cmbavPurchaseorderstate.ToJavascriptSource(), true);
         cmbavOrderedby.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19OrderedBy), 4, 0));
         AssignProp("", false, cmbavOrderedby_Internalname, "Values", cmbavOrderedby.ToJavascriptSource(), true);
      }

      protected void E18122( )
      {
         /* Filtercreatedfrom_Controlvaluechanged Routine */
         returnInSub = false;
         if ( ! (DateTime.MinValue==AV30FilterCreatedFrom) )
         {
            if ( ( ! (DateTime.MinValue==AV31FilterCreatedTo) ) && ( DateTimeUtil.ResetTime ( AV30FilterCreatedFrom ) > DateTimeUtil.ResetTime ( AV31FilterCreatedTo ) ) )
            {
               AV30FilterCreatedFrom = AV31FilterCreatedTo;
               AssignAttri("", false, "AV30FilterCreatedFrom", context.localUtil.Format(AV30FilterCreatedFrom, "99/99/99"));
            }
         }
         /* Execute user subroutine: 'UPDVARIABLES' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavPurchaseorderstate.CurrentValue = StringUtil.RTrim( AV18PurchaseOrderState);
         AssignProp("", false, cmbavPurchaseorderstate_Internalname, "Values", cmbavPurchaseorderstate.ToJavascriptSource(), true);
         cmbavOrderedby.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19OrderedBy), 4, 0));
         AssignProp("", false, cmbavOrderedby_Internalname, "Values", cmbavOrderedby.ToJavascriptSource(), true);
      }

      protected void E19122( )
      {
         /* Filtercreatedto_Controlvaluechanged Routine */
         returnInSub = false;
         if ( ! (DateTime.MinValue==AV31FilterCreatedTo) )
         {
            if ( ( ! (DateTime.MinValue==AV30FilterCreatedFrom) ) && ( DateTimeUtil.ResetTime ( AV30FilterCreatedFrom ) > DateTimeUtil.ResetTime ( AV31FilterCreatedTo ) ) )
            {
               AV31FilterCreatedTo = AV30FilterCreatedFrom;
               AssignAttri("", false, "AV31FilterCreatedTo", context.localUtil.Format(AV31FilterCreatedTo, "99/99/99"));
            }
         }
         /* Execute user subroutine: 'UPDVARIABLES' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavPurchaseorderstate.CurrentValue = StringUtil.RTrim( AV18PurchaseOrderState);
         AssignProp("", false, cmbavPurchaseorderstate_Internalname, "Values", cmbavPurchaseorderstate.ToJavascriptSource(), true);
         cmbavOrderedby.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19OrderedBy), 4, 0));
         AssignProp("", false, cmbavOrderedby_Internalname, "Values", cmbavOrderedby.ToJavascriptSource(), true);
      }

      protected void E20122( )
      {
         /* Filterclosedfrom_Controlvaluechanged Routine */
         returnInSub = false;
         if ( ! (DateTime.MinValue==AV32FilterClosedFrom) )
         {
            if ( ( ! (DateTime.MinValue==AV33FilterClosedTo) ) && ( DateTimeUtil.ResetTime ( AV32FilterClosedFrom ) > DateTimeUtil.ResetTime ( AV33FilterClosedTo ) ) )
            {
               AV32FilterClosedFrom = AV33FilterClosedTo;
               AssignAttri("", false, "AV32FilterClosedFrom", context.localUtil.Format(AV32FilterClosedFrom, "99/99/99"));
            }
         }
         /* Execute user subroutine: 'UPDVARIABLES' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavPurchaseorderstate.CurrentValue = StringUtil.RTrim( AV18PurchaseOrderState);
         AssignProp("", false, cmbavPurchaseorderstate_Internalname, "Values", cmbavPurchaseorderstate.ToJavascriptSource(), true);
         cmbavOrderedby.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19OrderedBy), 4, 0));
         AssignProp("", false, cmbavOrderedby_Internalname, "Values", cmbavOrderedby.ToJavascriptSource(), true);
      }

      protected void E21122( )
      {
         /* Filterclosedto_Controlvaluechanged Routine */
         returnInSub = false;
         if ( ! (DateTime.MinValue==AV33FilterClosedTo) )
         {
            if ( ( ! (DateTime.MinValue==AV32FilterClosedFrom) ) && ( DateTimeUtil.ResetTime ( AV32FilterClosedFrom ) > DateTimeUtil.ResetTime ( AV33FilterClosedTo ) ) )
            {
               AV33FilterClosedTo = AV32FilterClosedFrom;
               AssignAttri("", false, "AV33FilterClosedTo", context.localUtil.Format(AV33FilterClosedTo, "99/99/99"));
            }
         }
         /* Execute user subroutine: 'UPDVARIABLES' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavPurchaseorderstate.CurrentValue = StringUtil.RTrim( AV18PurchaseOrderState);
         AssignProp("", false, cmbavPurchaseorderstate_Internalname, "Values", cmbavPurchaseorderstate.ToJavascriptSource(), true);
         cmbavOrderedby.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19OrderedBy), 4, 0));
         AssignProp("", false, cmbavOrderedby_Internalname, "Values", cmbavOrderedby.ToJavascriptSource(), true);
      }

      protected void E22122( )
      {
         /* Filterorder_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'UPDVARIABLES' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavPurchaseorderstate.CurrentValue = StringUtil.RTrim( AV18PurchaseOrderState);
         AssignProp("", false, cmbavPurchaseorderstate_Internalname, "Values", cmbavPurchaseorderstate.ToJavascriptSource(), true);
         cmbavOrderedby.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19OrderedBy), 4, 0));
         AssignProp("", false, cmbavOrderedby_Internalname, "Values", cmbavOrderedby.ToJavascriptSource(), true);
      }

      protected void E23122( )
      {
         /* Filterorderdesc_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'UPDVARIABLES' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavPurchaseorderstate.CurrentValue = StringUtil.RTrim( AV18PurchaseOrderState);
         AssignProp("", false, cmbavPurchaseorderstate_Internalname, "Values", cmbavPurchaseorderstate.ToJavascriptSource(), true);
         cmbavOrderedby.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19OrderedBy), 4, 0));
         AssignProp("", false, cmbavOrderedby_Internalname, "Values", cmbavOrderedby.ToJavascriptSource(), true);
      }

      protected void E24122( )
      {
         /* Filtersupplier_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'UPDVARIABLES' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavPurchaseorderstate.CurrentValue = StringUtil.RTrim( AV18PurchaseOrderState);
         AssignProp("", false, cmbavPurchaseorderstate_Internalname, "Values", cmbavPurchaseorderstate.ToJavascriptSource(), true);
         cmbavOrderedby.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19OrderedBy), 4, 0));
         AssignProp("", false, cmbavOrderedby_Internalname, "Values", cmbavOrderedby.ToJavascriptSource(), true);
      }

      protected void E25122( )
      {
         /* Filternro_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'UPDVARIABLES' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavPurchaseorderstate.CurrentValue = StringUtil.RTrim( AV18PurchaseOrderState);
         AssignProp("", false, cmbavPurchaseorderstate_Internalname, "Values", cmbavPurchaseorderstate.ToJavascriptSource(), true);
         cmbavOrderedby.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19OrderedBy), 4, 0));
         AssignProp("", false, cmbavOrderedby_Internalname, "Values", cmbavOrderedby.ToJavascriptSource(), true);
      }

      protected void S122( )
      {
         /* 'UPDVARIABLES' Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29FilterState)) )
         {
            AV18PurchaseOrderState = AV29FilterState;
            AssignAttri("", false, "AV18PurchaseOrderState", AV18PurchaseOrderState);
         }
         else
         {
            AV18PurchaseOrderState = "";
            AssignAttri("", false, "AV18PurchaseOrderState", AV18PurchaseOrderState);
         }
         if ( ! (DateTime.MinValue==AV30FilterCreatedFrom) )
         {
            AV20CreatedDateFrom = context.localUtil.CToD( context.localUtil.DToC( AV30FilterCreatedFrom, 1, "/"), 1);
            AssignAttri("", false, "AV20CreatedDateFrom", context.localUtil.Format(AV20CreatedDateFrom, "99/99/99"));
         }
         else
         {
            AV20CreatedDateFrom = DateTime.MinValue;
            AssignAttri("", false, "AV20CreatedDateFrom", context.localUtil.Format(AV20CreatedDateFrom, "99/99/99"));
         }
         if ( ! (DateTime.MinValue==AV31FilterCreatedTo) )
         {
            AV21CreatedDateTo = context.localUtil.CToD( context.localUtil.DToC( AV31FilterCreatedTo, 1, "/"), 1);
            AssignAttri("", false, "AV21CreatedDateTo", context.localUtil.Format(AV21CreatedDateTo, "99/99/99"));
         }
         else
         {
            AV23ClosedDateTo = DateTime.MinValue;
            AssignAttri("", false, "AV23ClosedDateTo", context.localUtil.Format(AV23ClosedDateTo, "99/99/99"));
         }
         if ( ! (DateTime.MinValue==AV32FilterClosedFrom) )
         {
            AV22ClosedDateFrom = context.localUtil.CToD( context.localUtil.DToC( AV32FilterClosedFrom, 1, "/"), 1);
            AssignAttri("", false, "AV22ClosedDateFrom", context.localUtil.Format(AV22ClosedDateFrom, "99/99/99"));
         }
         else
         {
            AV22ClosedDateFrom = DateTime.MinValue;
            AssignAttri("", false, "AV22ClosedDateFrom", context.localUtil.Format(AV22ClosedDateFrom, "99/99/99"));
         }
         if ( ! (DateTime.MinValue==AV33FilterClosedTo) )
         {
            AV23ClosedDateTo = context.localUtil.CToD( context.localUtil.DToC( AV33FilterClosedTo, 1, "/"), 1);
            AssignAttri("", false, "AV23ClosedDateTo", context.localUtil.Format(AV23ClosedDateTo, "99/99/99"));
         }
         else
         {
            AV23ClosedDateTo = DateTime.MinValue;
            AssignAttri("", false, "AV23ClosedDateTo", context.localUtil.Format(AV23ClosedDateTo, "99/99/99"));
         }
         if ( AV34FilterOrder == 1 )
         {
            if ( ! AV35FilterOrderDesc )
            {
               AV19OrderedBy = 1;
               AssignAttri("", false, "AV19OrderedBy", StringUtil.LTrimStr( (decimal)(AV19OrderedBy), 4, 0));
            }
            else
            {
               AV19OrderedBy = 2;
               AssignAttri("", false, "AV19OrderedBy", StringUtil.LTrimStr( (decimal)(AV19OrderedBy), 4, 0));
            }
         }
         else if ( AV34FilterOrder == 2 )
         {
            if ( ! AV35FilterOrderDesc )
            {
               AV19OrderedBy = 3;
               AssignAttri("", false, "AV19OrderedBy", StringUtil.LTrimStr( (decimal)(AV19OrderedBy), 4, 0));
            }
            else
            {
               AV19OrderedBy = 4;
               AssignAttri("", false, "AV19OrderedBy", StringUtil.LTrimStr( (decimal)(AV19OrderedBy), 4, 0));
            }
         }
         else if ( AV34FilterOrder == 3 )
         {
            if ( ! AV35FilterOrderDesc )
            {
               AV19OrderedBy = 5;
               AssignAttri("", false, "AV19OrderedBy", StringUtil.LTrimStr( (decimal)(AV19OrderedBy), 4, 0));
            }
            else
            {
               AV19OrderedBy = 6;
               AssignAttri("", false, "AV19OrderedBy", StringUtil.LTrimStr( (decimal)(AV19OrderedBy), 4, 0));
            }
         }
         else if ( AV34FilterOrder == 4 )
         {
            if ( ! AV35FilterOrderDesc )
            {
               AV19OrderedBy = 7;
               AssignAttri("", false, "AV19OrderedBy", StringUtil.LTrimStr( (decimal)(AV19OrderedBy), 4, 0));
            }
            else
            {
               AV19OrderedBy = 8;
               AssignAttri("", false, "AV19OrderedBy", StringUtil.LTrimStr( (decimal)(AV19OrderedBy), 4, 0));
            }
         }
         if ( ! (0==AV37FilterSupplier) )
         {
            AV41SupplierId = AV37FilterSupplier;
            AssignAttri("", false, "AV41SupplierId", StringUtil.LTrimStr( (decimal)(AV41SupplierId), 6, 0));
         }
         else
         {
            AV41SupplierId = 0;
            AssignAttri("", false, "AV41SupplierId", StringUtil.LTrimStr( (decimal)(AV41SupplierId), 6, 0));
         }
         if ( ! (0==AV39FilterNro) )
         {
            AV40PurchaseOrderId = AV39FilterNro;
            AssignAttri("", false, "AV40PurchaseOrderId", StringUtil.LTrimStr( (decimal)(AV40PurchaseOrderId), 6, 0));
         }
         else
         {
            AV40PurchaseOrderId = 0;
            AssignAttri("", false, "AV40PurchaseOrderId", StringUtil.LTrimStr( (decimal)(AV40PurchaseOrderId), 6, 0));
         }
         subgrid_firstpage( ) ;
         gxgrGrid_refresh( subGrid_Rows, AV18PurchaseOrderState, AV19OrderedBy, AV20CreatedDateFrom, AV21CreatedDateTo, AV22ClosedDateFrom, AV23ClosedDateTo, AV37FilterSupplier, AV35FilterOrderDesc) ;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
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
         PA122( ) ;
         WS122( ) ;
         WE122( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20241281641891", true, true);
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
         context.AddJavascriptSource("wwpurchaseorder.js", "?20241281641891", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_702( )
      {
         edtPurchaseOrderId_Internalname = "PURCHASEORDERID_"+sGXsfl_70_idx;
         edtPurchaseOrderCreatedDate_Internalname = "PURCHASEORDERCREATEDDATE_"+sGXsfl_70_idx;
         edtSupplierName_Internalname = "SUPPLIERNAME_"+sGXsfl_70_idx;
         edtPurchaseOrderTotalPaid_Internalname = "PURCHASEORDERTOTALPAID_"+sGXsfl_70_idx;
         edtPurchaseOrderClosedDate_Internalname = "PURCHASEORDERCLOSEDDATE_"+sGXsfl_70_idx;
         chkPurchaseOrderActive_Internalname = "PURCHASEORDERACTIVE_"+sGXsfl_70_idx;
         chkPurchaseOrderWasPaid_Internalname = "PURCHASEORDERWASPAID_"+sGXsfl_70_idx;
         edtPurchaseOrderDetailsQuantity_Internalname = "PURCHASEORDERDETAILSQUANTITY_"+sGXsfl_70_idx;
         cmbavState_Internalname = "vSTATE_"+sGXsfl_70_idx;
         edtavDetails_Internalname = "vDETAILS_"+sGXsfl_70_idx;
      }

      protected void SubsflControlProps_fel_702( )
      {
         edtPurchaseOrderId_Internalname = "PURCHASEORDERID_"+sGXsfl_70_fel_idx;
         edtPurchaseOrderCreatedDate_Internalname = "PURCHASEORDERCREATEDDATE_"+sGXsfl_70_fel_idx;
         edtSupplierName_Internalname = "SUPPLIERNAME_"+sGXsfl_70_fel_idx;
         edtPurchaseOrderTotalPaid_Internalname = "PURCHASEORDERTOTALPAID_"+sGXsfl_70_fel_idx;
         edtPurchaseOrderClosedDate_Internalname = "PURCHASEORDERCLOSEDDATE_"+sGXsfl_70_fel_idx;
         chkPurchaseOrderActive_Internalname = "PURCHASEORDERACTIVE_"+sGXsfl_70_fel_idx;
         chkPurchaseOrderWasPaid_Internalname = "PURCHASEORDERWASPAID_"+sGXsfl_70_fel_idx;
         edtPurchaseOrderDetailsQuantity_Internalname = "PURCHASEORDERDETAILSQUANTITY_"+sGXsfl_70_fel_idx;
         cmbavState_Internalname = "vSTATE_"+sGXsfl_70_fel_idx;
         edtavDetails_Internalname = "vDETAILS_"+sGXsfl_70_fel_idx;
      }

      protected void sendrow_702( )
      {
         SubsflControlProps_702( ) ;
         WB120( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_70_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_70_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " class=\""+"ww__grid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_70_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPurchaseOrderId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A50PurchaseOrderId), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A50PurchaseOrderId), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPurchaseOrderId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)70,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "attribute-description";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPurchaseOrderCreatedDate_Internalname,context.localUtil.Format(A52PurchaseOrderCreatedDate, "99/99/99"),context.localUtil.Format( A52PurchaseOrderCreatedDate, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPurchaseOrderCreatedDate_Jsonclick,(short)0,(string)"attribute-description",(string)"",(string)ROClassString,(string)"column",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)70,(short)0,(short)-1,(short)0,(bool)true,(string)"PurchaseOrderDate",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierName_Internalname,(string)A5SupplierName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)70,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPurchaseOrderTotalPaid_Internalname,StringUtil.LTrim( StringUtil.NToC( A78PurchaseOrderTotalPaid, 18, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A78PurchaseOrderTotalPaid, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPurchaseOrderTotalPaid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)70,(short)0,(short)-1,(short)0,(bool)true,(string)"Price",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPurchaseOrderClosedDate_Internalname,context.localUtil.Format(A66PurchaseOrderClosedDate, "99/99/99"),context.localUtil.Format( A66PurchaseOrderClosedDate, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPurchaseOrderClosedDate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)70,(short)0,(short)-1,(short)0,(bool)true,(string)"PurchaseOrderDate",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "PURCHASEORDERACTIVE_" + sGXsfl_70_idx;
            chkPurchaseOrderActive.Name = GXCCtl;
            chkPurchaseOrderActive.WebTags = "";
            chkPurchaseOrderActive.Caption = "";
            AssignProp("", false, chkPurchaseOrderActive_Internalname, "TitleCaption", chkPurchaseOrderActive.Caption, !bGXsfl_70_Refreshing);
            chkPurchaseOrderActive.CheckedValue = "false";
            A79PurchaseOrderActive = StringUtil.StrToBool( StringUtil.BoolToStr( A79PurchaseOrderActive));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkPurchaseOrderActive_Internalname,StringUtil.BoolToStr( A79PurchaseOrderActive),(string)"",(string)"",(short)0,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"column WWOptionalColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "PURCHASEORDERWASPAID_" + sGXsfl_70_idx;
            chkPurchaseOrderWasPaid.Name = GXCCtl;
            chkPurchaseOrderWasPaid.WebTags = "";
            chkPurchaseOrderWasPaid.Caption = "";
            AssignProp("", false, chkPurchaseOrderWasPaid_Internalname, "TitleCaption", chkPurchaseOrderWasPaid.Caption, !bGXsfl_70_Refreshing);
            chkPurchaseOrderWasPaid.CheckedValue = "false";
            A138PurchaseOrderWasPaid = StringUtil.StrToBool( StringUtil.BoolToStr( A138PurchaseOrderWasPaid));
            n138PurchaseOrderWasPaid = false;
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkPurchaseOrderWasPaid_Internalname,StringUtil.BoolToStr( A138PurchaseOrderWasPaid),(string)"",(string)"",(short)-1,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"column WWOptionalColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPurchaseOrderDetailsQuantity_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A67PurchaseOrderDetailsQuantity), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPurchaseOrderDetailsQuantity_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column WWOptionalColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)70,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = " " + ((cmbavState.Enabled!=0)&&(cmbavState.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 79,'',false,'"+sGXsfl_70_idx+"',70)\"" : " ");
            if ( ( cmbavState.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vSTATE_" + sGXsfl_70_idx;
               cmbavState.Name = GXCCtl;
               cmbavState.WebTags = "";
               cmbavState.addItem("Pending", "Pending", 0);
               cmbavState.addItem("Canceled", "Canceled", 0);
               cmbavState.addItem("Received", "Received", 0);
               if ( cmbavState.ItemCount > 0 )
               {
                  AV28State = cmbavState.getValidValue(AV28State);
                  AssignAttri("", false, cmbavState_Internalname, AV28State);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavState,(string)cmbavState_Internalname,StringUtil.RTrim( AV28State),(short)1,(string)cmbavState_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"svchar",(string)"",(short)-1,cmbavState.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"column WWOptionalColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((cmbavState.Enabled!=0)&&(cmbavState.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,79);\"" : " "),(string)"",(bool)true,(short)0});
            cmbavState.CurrentValue = StringUtil.RTrim( AV28State);
            AssignProp("", false, cmbavState_Internalname, "Values", (string)(cmbavState.ToJavascriptSource()), !bGXsfl_70_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavDetails_Enabled!=0)&&(edtavDetails_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 80,'',false,'"+sGXsfl_70_idx+"',70)\"" : " ");
            ROClassString = "TextActionAttribute TextLikeLink";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDetails_Internalname,(string)AV27Details,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavDetails_Enabled!=0)&&(edtavDetails_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,80);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+"e29122_client"+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDetails_Jsonclick,(short)7,(string)"TextActionAttribute TextLikeLink",(string)"",(string)ROClassString,(string)"WWTextActionColumn",(string)"",(short)-1,(int)edtavDetails_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)70,(short)0,(short)-1,(short)-1,(bool)true,(string)"PurchaseOrderDetailsLink",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes122( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_70_idx = ((subGrid_Islastpage==1)&&(nGXsfl_70_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_70_idx+1);
            sGXsfl_70_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_70_idx), 4, 0), 4, "0");
            SubsflControlProps_702( ) ;
         }
         /* End function sendrow_702 */
      }

      protected void init_web_controls( )
      {
         cmbavPurchaseorderstate.Name = "vPURCHASEORDERSTATE";
         cmbavPurchaseorderstate.WebTags = "";
         cmbavPurchaseorderstate.addItem("", "(None)", 0);
         cmbavPurchaseorderstate.addItem("Pending", "Pending", 0);
         cmbavPurchaseorderstate.addItem("Canceled", "Canceled", 0);
         cmbavPurchaseorderstate.addItem("Received", "Received", 0);
         if ( cmbavPurchaseorderstate.ItemCount > 0 )
         {
            AV18PurchaseOrderState = cmbavPurchaseorderstate.getValidValue(AV18PurchaseOrderState);
            AssignAttri("", false, "AV18PurchaseOrderState", AV18PurchaseOrderState);
         }
         dynavFiltersupplier.Name = "vFILTERSUPPLIER";
         dynavFiltersupplier.WebTags = "";
         cmbavFilterstate.Name = "vFILTERSTATE";
         cmbavFilterstate.WebTags = "";
         cmbavFilterstate.addItem("", "(None)", 0);
         cmbavFilterstate.addItem("Pending", "Pending", 0);
         cmbavFilterstate.addItem("Canceled", "Canceled", 0);
         cmbavFilterstate.addItem("Received", "Received", 0);
         if ( cmbavFilterstate.ItemCount > 0 )
         {
            AV29FilterState = cmbavFilterstate.getValidValue(AV29FilterState);
            AssignAttri("", false, "AV29FilterState", AV29FilterState);
         }
         cmbavFilterorder.Name = "vFILTERORDER";
         cmbavFilterorder.WebTags = "";
         cmbavFilterorder.addItem("1", "Created Date", 0);
         cmbavFilterorder.addItem("2", "Closed Date", 0);
         cmbavFilterorder.addItem("3", "Supplier", 0);
         cmbavFilterorder.addItem("4", "Nro", 0);
         if ( cmbavFilterorder.ItemCount > 0 )
         {
            AV34FilterOrder = (short)(Math.Round(NumberUtil.Val( cmbavFilterorder.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV34FilterOrder), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV34FilterOrder", StringUtil.LTrimStr( (decimal)(AV34FilterOrder), 4, 0));
         }
         chkavFilterorderdesc.Name = "vFILTERORDERDESC";
         chkavFilterorderdesc.WebTags = "";
         chkavFilterorderdesc.Caption = "";
         AssignProp("", false, chkavFilterorderdesc_Internalname, "TitleCaption", chkavFilterorderdesc.Caption, true);
         chkavFilterorderdesc.CheckedValue = "false";
         AV35FilterOrderDesc = StringUtil.StrToBool( StringUtil.BoolToStr( AV35FilterOrderDesc));
         AssignAttri("", false, "AV35FilterOrderDesc", AV35FilterOrderDesc);
         GXCCtl = "PURCHASEORDERACTIVE_" + sGXsfl_70_idx;
         chkPurchaseOrderActive.Name = GXCCtl;
         chkPurchaseOrderActive.WebTags = "";
         chkPurchaseOrderActive.Caption = "";
         AssignProp("", false, chkPurchaseOrderActive_Internalname, "TitleCaption", chkPurchaseOrderActive.Caption, !bGXsfl_70_Refreshing);
         chkPurchaseOrderActive.CheckedValue = "false";
         A79PurchaseOrderActive = StringUtil.StrToBool( StringUtil.BoolToStr( A79PurchaseOrderActive));
         GXCCtl = "PURCHASEORDERWASPAID_" + sGXsfl_70_idx;
         chkPurchaseOrderWasPaid.Name = GXCCtl;
         chkPurchaseOrderWasPaid.WebTags = "";
         chkPurchaseOrderWasPaid.Caption = "";
         AssignProp("", false, chkPurchaseOrderWasPaid_Internalname, "TitleCaption", chkPurchaseOrderWasPaid.Caption, !bGXsfl_70_Refreshing);
         chkPurchaseOrderWasPaid.CheckedValue = "false";
         A138PurchaseOrderWasPaid = StringUtil.StrToBool( StringUtil.BoolToStr( A138PurchaseOrderWasPaid));
         n138PurchaseOrderWasPaid = false;
         GXCCtl = "vSTATE_" + sGXsfl_70_idx;
         cmbavState.Name = GXCCtl;
         cmbavState.WebTags = "";
         cmbavState.addItem("Pending", "Pending", 0);
         cmbavState.addItem("Canceled", "Canceled", 0);
         cmbavState.addItem("Received", "Received", 0);
         if ( cmbavState.ItemCount > 0 )
         {
            AV28State = cmbavState.getValidValue(AV28State);
            AssignAttri("", false, cmbavState_Internalname, AV28State);
         }
         cmbavOrderedby.Name = "vORDEREDBY";
         cmbavOrderedby.WebTags = "";
         cmbavOrderedby.addItem("1", "Created Date Asc.", 0);
         cmbavOrderedby.addItem("2", "Created Date Desc.", 0);
         cmbavOrderedby.addItem("3", "Closed Date Asc.", 0);
         cmbavOrderedby.addItem("4", "Closed Date Desc.", 0);
         cmbavOrderedby.addItem("5", "Supplier Asc", 0);
         cmbavOrderedby.addItem("6", "Supplier Desc", 0);
         cmbavOrderedby.addItem("7", "Nro Asc", 0);
         cmbavOrderedby.addItem("8", "Nro Desc", 0);
         if ( cmbavOrderedby.ItemCount > 0 )
         {
            AV19OrderedBy = (short)(Math.Round(NumberUtil.Val( cmbavOrderedby.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV19OrderedBy), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV19OrderedBy", StringUtil.LTrimStr( (decimal)(AV19OrderedBy), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl70( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"70\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "ww__grid", 0, "", "", 1, 2, sStyleString, "", "", 0);
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
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Nro") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"attribute-description"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Created Date") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Supplier") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Total Paid") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Closed Date") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Order Active") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Paid") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Details Quantity") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "State") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"TextActionAttribute TextLikeLink"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Detail") ;
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
            GridContainer.AddObjectProperty("Class", "ww__grid");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A50PurchaseOrderId), 6, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A52PurchaseOrderCreatedDate, "99/99/99")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A5SupplierName));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A78PurchaseOrderTotalPaid, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A66PurchaseOrderClosedDate, "99/99/99")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A79PurchaseOrderActive)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A138PurchaseOrderWasPaid)));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV28State));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavState.Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV27Details));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDetails_Enabled), 5, 0, ".", "")));
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
         lblTitletext_Internalname = "TITLETEXT";
         bttBtnexport_Internalname = "BTNEXPORT";
         cmbavPurchaseorderstate_Internalname = "vPURCHASEORDERSTATE";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         divTabletop_Internalname = "TABLETOP";
         edtavFilternro_Internalname = "vFILTERNRO";
         edtavFiltercreatedfrom_Internalname = "vFILTERCREATEDFROM";
         edtavFiltercreatedto_Internalname = "vFILTERCREATEDTO";
         edtavFilterclosedfrom_Internalname = "vFILTERCLOSEDFROM";
         edtavFilterclosedto_Internalname = "vFILTERCLOSEDTO";
         dynavFiltersupplier_Internalname = "vFILTERSUPPLIER";
         cmbavFilterstate_Internalname = "vFILTERSTATE";
         cmbavFilterorder_Internalname = "vFILTERORDER";
         chkavFilterorderdesc_Internalname = "vFILTERORDERDESC";
         divTable1_Internalname = "TABLE1";
         edtPurchaseOrderId_Internalname = "PURCHASEORDERID";
         edtPurchaseOrderCreatedDate_Internalname = "PURCHASEORDERCREATEDDATE";
         edtSupplierName_Internalname = "SUPPLIERNAME";
         edtPurchaseOrderTotalPaid_Internalname = "PURCHASEORDERTOTALPAID";
         edtPurchaseOrderClosedDate_Internalname = "PURCHASEORDERCLOSEDDATE";
         chkPurchaseOrderActive_Internalname = "PURCHASEORDERACTIVE";
         chkPurchaseOrderWasPaid_Internalname = "PURCHASEORDERWASPAID";
         edtPurchaseOrderDetailsQuantity_Internalname = "PURCHASEORDERDETAILSQUANTITY";
         cmbavState_Internalname = "vSTATE";
         edtavDetails_Internalname = "vDETAILS";
         divGridcontainer_Internalname = "GRIDCONTAINER";
         divGridtable_Internalname = "GRIDTABLE";
         divGridcell_Internalname = "GRIDCELL";
         bttBtntoggleontable_Internalname = "BTNTOGGLEONTABLE";
         cmbavOrderedby_Internalname = "vORDEREDBY";
         lblLblcreateddatefromfilter_Internalname = "LBLCREATEDDATEFROMFILTER";
         edtavCreateddatefrom_Internalname = "vCREATEDDATEFROM";
         divCreateddatefromfiltercontainer_Internalname = "CREATEDDATEFROMFILTERCONTAINER";
         lblLblcreateddatetofilter_Internalname = "LBLCREATEDDATETOFILTER";
         edtavCreateddateto_Internalname = "vCREATEDDATETO";
         divCreateddatetofiltercontainer_Internalname = "CREATEDDATETOFILTERCONTAINER";
         lblLblcloseddatefromfilter_Internalname = "LBLCLOSEDDATEFROMFILTER";
         edtavCloseddatefrom_Internalname = "vCLOSEDDATEFROM";
         divCloseddatefromfiltercontainer_Internalname = "CLOSEDDATEFROMFILTERCONTAINER";
         lblLblcloseddatetofilter_Internalname = "LBLCLOSEDDATETOFILTER";
         edtavCloseddateto_Internalname = "vCLOSEDDATETO";
         divCloseddatetofiltercontainer_Internalname = "CLOSEDDATETOFILTERCONTAINER";
         divFilterscontainer_Internalname = "FILTERSCONTAINER";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGrid_Internalname = "GRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("mtaKB", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         chkavFilterorderdesc.Caption = "Desc.";
         edtavDetails_Jsonclick = "";
         edtavDetails_Visible = -1;
         edtavDetails_Enabled = 1;
         cmbavState_Jsonclick = "";
         cmbavState.Visible = -1;
         cmbavState.Enabled = 1;
         edtPurchaseOrderDetailsQuantity_Jsonclick = "";
         chkPurchaseOrderWasPaid.Caption = "";
         chkPurchaseOrderActive.Caption = "";
         edtPurchaseOrderClosedDate_Jsonclick = "";
         edtPurchaseOrderTotalPaid_Jsonclick = "";
         edtSupplierName_Jsonclick = "";
         edtPurchaseOrderCreatedDate_Jsonclick = "";
         edtPurchaseOrderId_Jsonclick = "";
         subGrid_Class = "ww__grid";
         subGrid_Backcolorstyle = 0;
         edtavCloseddateto_Jsonclick = "";
         edtavCloseddateto_Enabled = 1;
         edtavCloseddateto_Visible = 1;
         edtavCloseddatefrom_Jsonclick = "";
         edtavCloseddatefrom_Enabled = 1;
         edtavCloseddatefrom_Visible = 1;
         edtavCreateddateto_Jsonclick = "";
         edtavCreateddateto_Enabled = 1;
         edtavCreateddateto_Visible = 1;
         edtavCreateddatefrom_Jsonclick = "";
         edtavCreateddatefrom_Enabled = 1;
         edtavCreateddatefrom_Visible = 1;
         cmbavOrderedby_Jsonclick = "";
         cmbavOrderedby.Enabled = 1;
         chkavFilterorderdesc.Enabled = 1;
         cmbavFilterorder_Jsonclick = "";
         cmbavFilterorder.Enabled = 1;
         cmbavFilterstate_Jsonclick = "";
         cmbavFilterstate.Enabled = 1;
         dynavFiltersupplier_Jsonclick = "";
         dynavFiltersupplier.Enabled = 1;
         edtavFilterclosedto_Jsonclick = "";
         edtavFilterclosedto_Enabled = 1;
         edtavFilterclosedfrom_Jsonclick = "";
         edtavFilterclosedfrom_Enabled = 1;
         edtavFiltercreatedto_Jsonclick = "";
         edtavFiltercreatedto_Enabled = 1;
         edtavFiltercreatedfrom_Jsonclick = "";
         edtavFiltercreatedfrom_Enabled = 1;
         edtavFilternro_Jsonclick = "";
         edtavFilternro_Enabled = 1;
         bttBtntoggle_Class = "ww__button-filters--hide";
         bttBtntoggle_Tooltiptext = "Show Filters";
         bttBtntoggle_Caption = "Show Filters";
         bttBtntoggle_Enabled = 1;
         bttBtntoggle_Visible = 1;
         cmbavPurchaseorderstate_Jsonclick = "";
         cmbavPurchaseorderstate.Visible = 1;
         cmbavPurchaseorderstate.Enabled = 1;
         divGridcell_Class = "col-xs-12 col-sm-9 col-md-10 ww__grid-cell--expanded";
         divCloseddatetofiltercontainer_Class = "filters-container__item";
         divCloseddatefromfiltercontainer_Class = "filters-container__item";
         divCreateddatetofiltercontainer_Class = "filters-container__item";
         divCreateddatefromfiltercontainer_Class = "filters-container__item";
         divFilterscontainer_Class = "filters-container";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Work With Purchase Order";
         subGrid_Rows = 10;
         context.GX_msglist.DisplayMode = 1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavPurchaseorderstate'},{av:'AV18PurchaseOrderState',fld:'vPURCHASEORDERSTATE',pic:''},{av:'cmbavOrderedby'},{av:'AV19OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV20CreatedDateFrom',fld:'vCREATEDDATEFROM',pic:''},{av:'AV21CreatedDateTo',fld:'vCREATEDDATETO',pic:''},{av:'AV22ClosedDateFrom',fld:'vCLOSEDDATEFROM',pic:''},{av:'AV23ClosedDateTo',fld:'vCLOSEDDATETO',pic:''},{av:'dynavFiltersupplier'},{av:'AV37FilterSupplier',fld:'vFILTERSUPPLIER',pic:'ZZZZZ9'},{av:'AV35FilterOrderDesc',fld:'vFILTERORDERDESC',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E11121',iparms:[{av:'divFilterscontainer_Class',ctrl:'FILTERSCONTAINER',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divFilterscontainer_Class',ctrl:'FILTERSCONTAINER',prop:'Class'},{av:'divGridcell_Class',ctrl:'GRIDCELL',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Caption'},{ctrl:'BTNTOGGLE',prop:'Tooltiptext'}]}");
         setEventMetadata("LBLCREATEDDATEFROMFILTER.CLICK","{handler:'E12121',iparms:[{av:'divCreateddatefromfiltercontainer_Class',ctrl:'CREATEDDATEFROMFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCREATEDDATEFROMFILTER.CLICK",",oparms:[{av:'divCreateddatefromfiltercontainer_Class',ctrl:'CREATEDDATEFROMFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLCREATEDDATETOFILTER.CLICK","{handler:'E13121',iparms:[{av:'divCreateddatetofiltercontainer_Class',ctrl:'CREATEDDATETOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCREATEDDATETOFILTER.CLICK",",oparms:[{av:'divCreateddatetofiltercontainer_Class',ctrl:'CREATEDDATETOFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLCLOSEDDATEFROMFILTER.CLICK","{handler:'E14121',iparms:[{av:'divCloseddatefromfiltercontainer_Class',ctrl:'CLOSEDDATEFROMFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCLOSEDDATEFROMFILTER.CLICK",",oparms:[{av:'divCloseddatefromfiltercontainer_Class',ctrl:'CLOSEDDATEFROMFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLCLOSEDDATETOFILTER.CLICK","{handler:'E15121',iparms:[{av:'divCloseddatetofiltercontainer_Class',ctrl:'CLOSEDDATETOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCLOSEDDATETOFILTER.CLICK",",oparms:[{av:'divCloseddatetofiltercontainer_Class',ctrl:'CLOSEDDATETOFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E28122',iparms:[{av:'A79PurchaseOrderActive',fld:'PURCHASEORDERACTIVE',pic:''},{av:'A66PurchaseOrderClosedDate',fld:'PURCHASEORDERCLOSEDDATE',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'cmbavState'},{av:'AV28State',fld:'vSTATE',pic:''},{av:'AV27Details',fld:'vDETAILS',pic:''}]}");
         setEventMetadata("'DOEXPORT'","{handler:'E16122',iparms:[{av:'AV40PurchaseOrderId',fld:'vPURCHASEORDERID',pic:'ZZZZZ9'},{av:'AV41SupplierId',fld:'vSUPPLIERID',pic:'ZZZZZ9'},{av:'cmbavPurchaseorderstate'},{av:'AV18PurchaseOrderState',fld:'vPURCHASEORDERSTATE',pic:''},{av:'AV20CreatedDateFrom',fld:'vCREATEDDATEFROM',pic:''},{av:'AV21CreatedDateTo',fld:'vCREATEDDATETO',pic:''},{av:'AV22ClosedDateFrom',fld:'vCLOSEDDATEFROM',pic:''},{av:'AV23ClosedDateTo',fld:'vCLOSEDDATETO',pic:''},{av:'cmbavOrderedby'},{av:'AV19OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'}]");
         setEventMetadata("'DOEXPORT'",",oparms:[]}");
         setEventMetadata("VDETAILS.CLICK","{handler:'E29122',iparms:[{av:'A50PurchaseOrderId',fld:'PURCHASEORDERID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("VDETAILS.CLICK",",oparms:[]}");
         setEventMetadata("VFILTERSTATE.CONTROLVALUECHANGED","{handler:'E17122',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavPurchaseorderstate'},{av:'AV18PurchaseOrderState',fld:'vPURCHASEORDERSTATE',pic:''},{av:'cmbavOrderedby'},{av:'AV19OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV20CreatedDateFrom',fld:'vCREATEDDATEFROM',pic:''},{av:'AV21CreatedDateTo',fld:'vCREATEDDATETO',pic:''},{av:'AV22ClosedDateFrom',fld:'vCLOSEDDATEFROM',pic:''},{av:'AV23ClosedDateTo',fld:'vCLOSEDDATETO',pic:''},{av:'dynavFiltersupplier'},{av:'AV37FilterSupplier',fld:'vFILTERSUPPLIER',pic:'ZZZZZ9'},{av:'AV35FilterOrderDesc',fld:'vFILTERORDERDESC',pic:''},{av:'cmbavFilterstate'},{av:'AV29FilterState',fld:'vFILTERSTATE',pic:''},{av:'AV30FilterCreatedFrom',fld:'vFILTERCREATEDFROM',pic:''},{av:'AV31FilterCreatedTo',fld:'vFILTERCREATEDTO',pic:''},{av:'AV32FilterClosedFrom',fld:'vFILTERCLOSEDFROM',pic:''},{av:'AV33FilterClosedTo',fld:'vFILTERCLOSEDTO',pic:''},{av:'cmbavFilterorder'},{av:'AV34FilterOrder',fld:'vFILTERORDER',pic:'ZZZ9'},{av:'AV39FilterNro',fld:'vFILTERNRO',pic:'ZZZZZ9'}]");
         setEventMetadata("VFILTERSTATE.CONTROLVALUECHANGED",",oparms:[{av:'cmbavPurchaseorderstate'},{av:'AV18PurchaseOrderState',fld:'vPURCHASEORDERSTATE',pic:''},{av:'AV20CreatedDateFrom',fld:'vCREATEDDATEFROM',pic:''},{av:'AV21CreatedDateTo',fld:'vCREATEDDATETO',pic:''},{av:'AV23ClosedDateTo',fld:'vCLOSEDDATETO',pic:''},{av:'AV22ClosedDateFrom',fld:'vCLOSEDDATEFROM',pic:''},{av:'cmbavOrderedby'},{av:'AV19OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV41SupplierId',fld:'vSUPPLIERID',pic:'ZZZZZ9'},{av:'AV40PurchaseOrderId',fld:'vPURCHASEORDERID',pic:'ZZZZZ9'}]}");
         setEventMetadata("VFILTERCREATEDFROM.CONTROLVALUECHANGED","{handler:'E18122',iparms:[{av:'AV30FilterCreatedFrom',fld:'vFILTERCREATEDFROM',pic:''},{av:'AV31FilterCreatedTo',fld:'vFILTERCREATEDTO',pic:''},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavPurchaseorderstate'},{av:'AV18PurchaseOrderState',fld:'vPURCHASEORDERSTATE',pic:''},{av:'cmbavOrderedby'},{av:'AV19OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV20CreatedDateFrom',fld:'vCREATEDDATEFROM',pic:''},{av:'AV21CreatedDateTo',fld:'vCREATEDDATETO',pic:''},{av:'AV22ClosedDateFrom',fld:'vCLOSEDDATEFROM',pic:''},{av:'AV23ClosedDateTo',fld:'vCLOSEDDATETO',pic:''},{av:'dynavFiltersupplier'},{av:'AV37FilterSupplier',fld:'vFILTERSUPPLIER',pic:'ZZZZZ9'},{av:'AV35FilterOrderDesc',fld:'vFILTERORDERDESC',pic:''},{av:'cmbavFilterstate'},{av:'AV29FilterState',fld:'vFILTERSTATE',pic:''},{av:'AV32FilterClosedFrom',fld:'vFILTERCLOSEDFROM',pic:''},{av:'AV33FilterClosedTo',fld:'vFILTERCLOSEDTO',pic:''},{av:'cmbavFilterorder'},{av:'AV34FilterOrder',fld:'vFILTERORDER',pic:'ZZZ9'},{av:'AV39FilterNro',fld:'vFILTERNRO',pic:'ZZZZZ9'}]");
         setEventMetadata("VFILTERCREATEDFROM.CONTROLVALUECHANGED",",oparms:[{av:'AV30FilterCreatedFrom',fld:'vFILTERCREATEDFROM',pic:''},{av:'cmbavPurchaseorderstate'},{av:'AV18PurchaseOrderState',fld:'vPURCHASEORDERSTATE',pic:''},{av:'AV20CreatedDateFrom',fld:'vCREATEDDATEFROM',pic:''},{av:'AV21CreatedDateTo',fld:'vCREATEDDATETO',pic:''},{av:'AV23ClosedDateTo',fld:'vCLOSEDDATETO',pic:''},{av:'AV22ClosedDateFrom',fld:'vCLOSEDDATEFROM',pic:''},{av:'cmbavOrderedby'},{av:'AV19OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV41SupplierId',fld:'vSUPPLIERID',pic:'ZZZZZ9'},{av:'AV40PurchaseOrderId',fld:'vPURCHASEORDERID',pic:'ZZZZZ9'}]}");
         setEventMetadata("VFILTERCREATEDTO.CONTROLVALUECHANGED","{handler:'E19122',iparms:[{av:'AV31FilterCreatedTo',fld:'vFILTERCREATEDTO',pic:''},{av:'AV30FilterCreatedFrom',fld:'vFILTERCREATEDFROM',pic:''},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavPurchaseorderstate'},{av:'AV18PurchaseOrderState',fld:'vPURCHASEORDERSTATE',pic:''},{av:'cmbavOrderedby'},{av:'AV19OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV20CreatedDateFrom',fld:'vCREATEDDATEFROM',pic:''},{av:'AV21CreatedDateTo',fld:'vCREATEDDATETO',pic:''},{av:'AV22ClosedDateFrom',fld:'vCLOSEDDATEFROM',pic:''},{av:'AV23ClosedDateTo',fld:'vCLOSEDDATETO',pic:''},{av:'dynavFiltersupplier'},{av:'AV37FilterSupplier',fld:'vFILTERSUPPLIER',pic:'ZZZZZ9'},{av:'AV35FilterOrderDesc',fld:'vFILTERORDERDESC',pic:''},{av:'cmbavFilterstate'},{av:'AV29FilterState',fld:'vFILTERSTATE',pic:''},{av:'AV32FilterClosedFrom',fld:'vFILTERCLOSEDFROM',pic:''},{av:'AV33FilterClosedTo',fld:'vFILTERCLOSEDTO',pic:''},{av:'cmbavFilterorder'},{av:'AV34FilterOrder',fld:'vFILTERORDER',pic:'ZZZ9'},{av:'AV39FilterNro',fld:'vFILTERNRO',pic:'ZZZZZ9'}]");
         setEventMetadata("VFILTERCREATEDTO.CONTROLVALUECHANGED",",oparms:[{av:'AV31FilterCreatedTo',fld:'vFILTERCREATEDTO',pic:''},{av:'cmbavPurchaseorderstate'},{av:'AV18PurchaseOrderState',fld:'vPURCHASEORDERSTATE',pic:''},{av:'AV20CreatedDateFrom',fld:'vCREATEDDATEFROM',pic:''},{av:'AV21CreatedDateTo',fld:'vCREATEDDATETO',pic:''},{av:'AV23ClosedDateTo',fld:'vCLOSEDDATETO',pic:''},{av:'AV22ClosedDateFrom',fld:'vCLOSEDDATEFROM',pic:''},{av:'cmbavOrderedby'},{av:'AV19OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV41SupplierId',fld:'vSUPPLIERID',pic:'ZZZZZ9'},{av:'AV40PurchaseOrderId',fld:'vPURCHASEORDERID',pic:'ZZZZZ9'}]}");
         setEventMetadata("VFILTERCLOSEDFROM.CONTROLVALUECHANGED","{handler:'E20122',iparms:[{av:'AV32FilterClosedFrom',fld:'vFILTERCLOSEDFROM',pic:''},{av:'AV33FilterClosedTo',fld:'vFILTERCLOSEDTO',pic:''},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavPurchaseorderstate'},{av:'AV18PurchaseOrderState',fld:'vPURCHASEORDERSTATE',pic:''},{av:'cmbavOrderedby'},{av:'AV19OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV20CreatedDateFrom',fld:'vCREATEDDATEFROM',pic:''},{av:'AV21CreatedDateTo',fld:'vCREATEDDATETO',pic:''},{av:'AV22ClosedDateFrom',fld:'vCLOSEDDATEFROM',pic:''},{av:'AV23ClosedDateTo',fld:'vCLOSEDDATETO',pic:''},{av:'dynavFiltersupplier'},{av:'AV37FilterSupplier',fld:'vFILTERSUPPLIER',pic:'ZZZZZ9'},{av:'AV35FilterOrderDesc',fld:'vFILTERORDERDESC',pic:''},{av:'cmbavFilterstate'},{av:'AV29FilterState',fld:'vFILTERSTATE',pic:''},{av:'AV30FilterCreatedFrom',fld:'vFILTERCREATEDFROM',pic:''},{av:'AV31FilterCreatedTo',fld:'vFILTERCREATEDTO',pic:''},{av:'cmbavFilterorder'},{av:'AV34FilterOrder',fld:'vFILTERORDER',pic:'ZZZ9'},{av:'AV39FilterNro',fld:'vFILTERNRO',pic:'ZZZZZ9'}]");
         setEventMetadata("VFILTERCLOSEDFROM.CONTROLVALUECHANGED",",oparms:[{av:'AV32FilterClosedFrom',fld:'vFILTERCLOSEDFROM',pic:''},{av:'cmbavPurchaseorderstate'},{av:'AV18PurchaseOrderState',fld:'vPURCHASEORDERSTATE',pic:''},{av:'AV20CreatedDateFrom',fld:'vCREATEDDATEFROM',pic:''},{av:'AV21CreatedDateTo',fld:'vCREATEDDATETO',pic:''},{av:'AV23ClosedDateTo',fld:'vCLOSEDDATETO',pic:''},{av:'AV22ClosedDateFrom',fld:'vCLOSEDDATEFROM',pic:''},{av:'cmbavOrderedby'},{av:'AV19OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV41SupplierId',fld:'vSUPPLIERID',pic:'ZZZZZ9'},{av:'AV40PurchaseOrderId',fld:'vPURCHASEORDERID',pic:'ZZZZZ9'}]}");
         setEventMetadata("VFILTERCLOSEDTO.CONTROLVALUECHANGED","{handler:'E21122',iparms:[{av:'AV33FilterClosedTo',fld:'vFILTERCLOSEDTO',pic:''},{av:'AV32FilterClosedFrom',fld:'vFILTERCLOSEDFROM',pic:''},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavPurchaseorderstate'},{av:'AV18PurchaseOrderState',fld:'vPURCHASEORDERSTATE',pic:''},{av:'cmbavOrderedby'},{av:'AV19OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV20CreatedDateFrom',fld:'vCREATEDDATEFROM',pic:''},{av:'AV21CreatedDateTo',fld:'vCREATEDDATETO',pic:''},{av:'AV22ClosedDateFrom',fld:'vCLOSEDDATEFROM',pic:''},{av:'AV23ClosedDateTo',fld:'vCLOSEDDATETO',pic:''},{av:'dynavFiltersupplier'},{av:'AV37FilterSupplier',fld:'vFILTERSUPPLIER',pic:'ZZZZZ9'},{av:'AV35FilterOrderDesc',fld:'vFILTERORDERDESC',pic:''},{av:'cmbavFilterstate'},{av:'AV29FilterState',fld:'vFILTERSTATE',pic:''},{av:'AV30FilterCreatedFrom',fld:'vFILTERCREATEDFROM',pic:''},{av:'AV31FilterCreatedTo',fld:'vFILTERCREATEDTO',pic:''},{av:'cmbavFilterorder'},{av:'AV34FilterOrder',fld:'vFILTERORDER',pic:'ZZZ9'},{av:'AV39FilterNro',fld:'vFILTERNRO',pic:'ZZZZZ9'}]");
         setEventMetadata("VFILTERCLOSEDTO.CONTROLVALUECHANGED",",oparms:[{av:'AV33FilterClosedTo',fld:'vFILTERCLOSEDTO',pic:''},{av:'cmbavPurchaseorderstate'},{av:'AV18PurchaseOrderState',fld:'vPURCHASEORDERSTATE',pic:''},{av:'AV20CreatedDateFrom',fld:'vCREATEDDATEFROM',pic:''},{av:'AV21CreatedDateTo',fld:'vCREATEDDATETO',pic:''},{av:'AV23ClosedDateTo',fld:'vCLOSEDDATETO',pic:''},{av:'AV22ClosedDateFrom',fld:'vCLOSEDDATEFROM',pic:''},{av:'cmbavOrderedby'},{av:'AV19OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV41SupplierId',fld:'vSUPPLIERID',pic:'ZZZZZ9'},{av:'AV40PurchaseOrderId',fld:'vPURCHASEORDERID',pic:'ZZZZZ9'}]}");
         setEventMetadata("VFILTERORDER.CONTROLVALUECHANGED","{handler:'E22122',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavPurchaseorderstate'},{av:'AV18PurchaseOrderState',fld:'vPURCHASEORDERSTATE',pic:''},{av:'cmbavOrderedby'},{av:'AV19OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV20CreatedDateFrom',fld:'vCREATEDDATEFROM',pic:''},{av:'AV21CreatedDateTo',fld:'vCREATEDDATETO',pic:''},{av:'AV22ClosedDateFrom',fld:'vCLOSEDDATEFROM',pic:''},{av:'AV23ClosedDateTo',fld:'vCLOSEDDATETO',pic:''},{av:'dynavFiltersupplier'},{av:'AV37FilterSupplier',fld:'vFILTERSUPPLIER',pic:'ZZZZZ9'},{av:'AV35FilterOrderDesc',fld:'vFILTERORDERDESC',pic:''},{av:'cmbavFilterstate'},{av:'AV29FilterState',fld:'vFILTERSTATE',pic:''},{av:'AV30FilterCreatedFrom',fld:'vFILTERCREATEDFROM',pic:''},{av:'AV31FilterCreatedTo',fld:'vFILTERCREATEDTO',pic:''},{av:'AV32FilterClosedFrom',fld:'vFILTERCLOSEDFROM',pic:''},{av:'AV33FilterClosedTo',fld:'vFILTERCLOSEDTO',pic:''},{av:'cmbavFilterorder'},{av:'AV34FilterOrder',fld:'vFILTERORDER',pic:'ZZZ9'},{av:'AV39FilterNro',fld:'vFILTERNRO',pic:'ZZZZZ9'}]");
         setEventMetadata("VFILTERORDER.CONTROLVALUECHANGED",",oparms:[{av:'cmbavPurchaseorderstate'},{av:'AV18PurchaseOrderState',fld:'vPURCHASEORDERSTATE',pic:''},{av:'AV20CreatedDateFrom',fld:'vCREATEDDATEFROM',pic:''},{av:'AV21CreatedDateTo',fld:'vCREATEDDATETO',pic:''},{av:'AV23ClosedDateTo',fld:'vCLOSEDDATETO',pic:''},{av:'AV22ClosedDateFrom',fld:'vCLOSEDDATEFROM',pic:''},{av:'cmbavOrderedby'},{av:'AV19OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV41SupplierId',fld:'vSUPPLIERID',pic:'ZZZZZ9'},{av:'AV40PurchaseOrderId',fld:'vPURCHASEORDERID',pic:'ZZZZZ9'}]}");
         setEventMetadata("VFILTERORDERDESC.CONTROLVALUECHANGED","{handler:'E23122',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavPurchaseorderstate'},{av:'AV18PurchaseOrderState',fld:'vPURCHASEORDERSTATE',pic:''},{av:'cmbavOrderedby'},{av:'AV19OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV20CreatedDateFrom',fld:'vCREATEDDATEFROM',pic:''},{av:'AV21CreatedDateTo',fld:'vCREATEDDATETO',pic:''},{av:'AV22ClosedDateFrom',fld:'vCLOSEDDATEFROM',pic:''},{av:'AV23ClosedDateTo',fld:'vCLOSEDDATETO',pic:''},{av:'dynavFiltersupplier'},{av:'AV37FilterSupplier',fld:'vFILTERSUPPLIER',pic:'ZZZZZ9'},{av:'AV35FilterOrderDesc',fld:'vFILTERORDERDESC',pic:''},{av:'cmbavFilterstate'},{av:'AV29FilterState',fld:'vFILTERSTATE',pic:''},{av:'AV30FilterCreatedFrom',fld:'vFILTERCREATEDFROM',pic:''},{av:'AV31FilterCreatedTo',fld:'vFILTERCREATEDTO',pic:''},{av:'AV32FilterClosedFrom',fld:'vFILTERCLOSEDFROM',pic:''},{av:'AV33FilterClosedTo',fld:'vFILTERCLOSEDTO',pic:''},{av:'cmbavFilterorder'},{av:'AV34FilterOrder',fld:'vFILTERORDER',pic:'ZZZ9'},{av:'AV39FilterNro',fld:'vFILTERNRO',pic:'ZZZZZ9'}]");
         setEventMetadata("VFILTERORDERDESC.CONTROLVALUECHANGED",",oparms:[{av:'cmbavPurchaseorderstate'},{av:'AV18PurchaseOrderState',fld:'vPURCHASEORDERSTATE',pic:''},{av:'AV20CreatedDateFrom',fld:'vCREATEDDATEFROM',pic:''},{av:'AV21CreatedDateTo',fld:'vCREATEDDATETO',pic:''},{av:'AV23ClosedDateTo',fld:'vCLOSEDDATETO',pic:''},{av:'AV22ClosedDateFrom',fld:'vCLOSEDDATEFROM',pic:''},{av:'cmbavOrderedby'},{av:'AV19OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV41SupplierId',fld:'vSUPPLIERID',pic:'ZZZZZ9'},{av:'AV40PurchaseOrderId',fld:'vPURCHASEORDERID',pic:'ZZZZZ9'}]}");
         setEventMetadata("VFILTERSUPPLIER.CONTROLVALUECHANGED","{handler:'E24122',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavPurchaseorderstate'},{av:'AV18PurchaseOrderState',fld:'vPURCHASEORDERSTATE',pic:''},{av:'cmbavOrderedby'},{av:'AV19OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV20CreatedDateFrom',fld:'vCREATEDDATEFROM',pic:''},{av:'AV21CreatedDateTo',fld:'vCREATEDDATETO',pic:''},{av:'AV22ClosedDateFrom',fld:'vCLOSEDDATEFROM',pic:''},{av:'AV23ClosedDateTo',fld:'vCLOSEDDATETO',pic:''},{av:'dynavFiltersupplier'},{av:'AV37FilterSupplier',fld:'vFILTERSUPPLIER',pic:'ZZZZZ9'},{av:'AV35FilterOrderDesc',fld:'vFILTERORDERDESC',pic:''},{av:'cmbavFilterstate'},{av:'AV29FilterState',fld:'vFILTERSTATE',pic:''},{av:'AV30FilterCreatedFrom',fld:'vFILTERCREATEDFROM',pic:''},{av:'AV31FilterCreatedTo',fld:'vFILTERCREATEDTO',pic:''},{av:'AV32FilterClosedFrom',fld:'vFILTERCLOSEDFROM',pic:''},{av:'AV33FilterClosedTo',fld:'vFILTERCLOSEDTO',pic:''},{av:'cmbavFilterorder'},{av:'AV34FilterOrder',fld:'vFILTERORDER',pic:'ZZZ9'},{av:'AV39FilterNro',fld:'vFILTERNRO',pic:'ZZZZZ9'}]");
         setEventMetadata("VFILTERSUPPLIER.CONTROLVALUECHANGED",",oparms:[{av:'cmbavPurchaseorderstate'},{av:'AV18PurchaseOrderState',fld:'vPURCHASEORDERSTATE',pic:''},{av:'AV20CreatedDateFrom',fld:'vCREATEDDATEFROM',pic:''},{av:'AV21CreatedDateTo',fld:'vCREATEDDATETO',pic:''},{av:'AV23ClosedDateTo',fld:'vCLOSEDDATETO',pic:''},{av:'AV22ClosedDateFrom',fld:'vCLOSEDDATEFROM',pic:''},{av:'cmbavOrderedby'},{av:'AV19OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV41SupplierId',fld:'vSUPPLIERID',pic:'ZZZZZ9'},{av:'AV40PurchaseOrderId',fld:'vPURCHASEORDERID',pic:'ZZZZZ9'}]}");
         setEventMetadata("VFILTERNRO.CONTROLVALUECHANGED","{handler:'E25122',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavPurchaseorderstate'},{av:'AV18PurchaseOrderState',fld:'vPURCHASEORDERSTATE',pic:''},{av:'cmbavOrderedby'},{av:'AV19OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV20CreatedDateFrom',fld:'vCREATEDDATEFROM',pic:''},{av:'AV21CreatedDateTo',fld:'vCREATEDDATETO',pic:''},{av:'AV22ClosedDateFrom',fld:'vCLOSEDDATEFROM',pic:''},{av:'AV23ClosedDateTo',fld:'vCLOSEDDATETO',pic:''},{av:'dynavFiltersupplier'},{av:'AV37FilterSupplier',fld:'vFILTERSUPPLIER',pic:'ZZZZZ9'},{av:'AV35FilterOrderDesc',fld:'vFILTERORDERDESC',pic:''},{av:'cmbavFilterstate'},{av:'AV29FilterState',fld:'vFILTERSTATE',pic:''},{av:'AV30FilterCreatedFrom',fld:'vFILTERCREATEDFROM',pic:''},{av:'AV31FilterCreatedTo',fld:'vFILTERCREATEDTO',pic:''},{av:'AV32FilterClosedFrom',fld:'vFILTERCLOSEDFROM',pic:''},{av:'AV33FilterClosedTo',fld:'vFILTERCLOSEDTO',pic:''},{av:'cmbavFilterorder'},{av:'AV34FilterOrder',fld:'vFILTERORDER',pic:'ZZZ9'},{av:'AV39FilterNro',fld:'vFILTERNRO',pic:'ZZZZZ9'}]");
         setEventMetadata("VFILTERNRO.CONTROLVALUECHANGED",",oparms:[{av:'cmbavPurchaseorderstate'},{av:'AV18PurchaseOrderState',fld:'vPURCHASEORDERSTATE',pic:''},{av:'AV20CreatedDateFrom',fld:'vCREATEDDATEFROM',pic:''},{av:'AV21CreatedDateTo',fld:'vCREATEDDATETO',pic:''},{av:'AV23ClosedDateTo',fld:'vCLOSEDDATETO',pic:''},{av:'AV22ClosedDateFrom',fld:'vCLOSEDDATEFROM',pic:''},{av:'cmbavOrderedby'},{av:'AV19OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV41SupplierId',fld:'vSUPPLIERID',pic:'ZZZZZ9'},{av:'AV40PurchaseOrderId',fld:'vPURCHASEORDERID',pic:'ZZZZZ9'}]}");
         setEventMetadata("GRID_FIRSTPAGE","{handler:'subgrid_firstpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavPurchaseorderstate'},{av:'AV18PurchaseOrderState',fld:'vPURCHASEORDERSTATE',pic:''},{av:'cmbavOrderedby'},{av:'AV19OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV20CreatedDateFrom',fld:'vCREATEDDATEFROM',pic:''},{av:'AV21CreatedDateTo',fld:'vCREATEDDATETO',pic:''},{av:'AV22ClosedDateFrom',fld:'vCLOSEDDATEFROM',pic:''},{av:'AV23ClosedDateTo',fld:'vCLOSEDDATETO',pic:''},{av:'dynavFiltersupplier'},{av:'AV37FilterSupplier',fld:'vFILTERSUPPLIER',pic:'ZZZZZ9'},{av:'AV35FilterOrderDesc',fld:'vFILTERORDERDESC',pic:''}]");
         setEventMetadata("GRID_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID_PREVPAGE","{handler:'subgrid_previouspage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavPurchaseorderstate'},{av:'AV18PurchaseOrderState',fld:'vPURCHASEORDERSTATE',pic:''},{av:'cmbavOrderedby'},{av:'AV19OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV20CreatedDateFrom',fld:'vCREATEDDATEFROM',pic:''},{av:'AV21CreatedDateTo',fld:'vCREATEDDATETO',pic:''},{av:'AV22ClosedDateFrom',fld:'vCLOSEDDATEFROM',pic:''},{av:'AV23ClosedDateTo',fld:'vCLOSEDDATETO',pic:''},{av:'dynavFiltersupplier'},{av:'AV37FilterSupplier',fld:'vFILTERSUPPLIER',pic:'ZZZZZ9'},{av:'AV35FilterOrderDesc',fld:'vFILTERORDERDESC',pic:''}]");
         setEventMetadata("GRID_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID_NEXTPAGE","{handler:'subgrid_nextpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavPurchaseorderstate'},{av:'AV18PurchaseOrderState',fld:'vPURCHASEORDERSTATE',pic:''},{av:'cmbavOrderedby'},{av:'AV19OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV20CreatedDateFrom',fld:'vCREATEDDATEFROM',pic:''},{av:'AV21CreatedDateTo',fld:'vCREATEDDATETO',pic:''},{av:'AV22ClosedDateFrom',fld:'vCLOSEDDATEFROM',pic:''},{av:'AV23ClosedDateTo',fld:'vCLOSEDDATETO',pic:''},{av:'dynavFiltersupplier'},{av:'AV37FilterSupplier',fld:'vFILTERSUPPLIER',pic:'ZZZZZ9'},{av:'AV35FilterOrderDesc',fld:'vFILTERORDERDESC',pic:''}]");
         setEventMetadata("GRID_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID_LASTPAGE","{handler:'subgrid_lastpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'cmbavPurchaseorderstate'},{av:'AV18PurchaseOrderState',fld:'vPURCHASEORDERSTATE',pic:''},{av:'cmbavOrderedby'},{av:'AV19OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV20CreatedDateFrom',fld:'vCREATEDDATEFROM',pic:''},{av:'AV21CreatedDateTo',fld:'vCREATEDDATETO',pic:''},{av:'AV22ClosedDateFrom',fld:'vCLOSEDDATEFROM',pic:''},{av:'AV23ClosedDateTo',fld:'vCLOSEDDATETO',pic:''},{av:'dynavFiltersupplier'},{av:'AV37FilterSupplier',fld:'vFILTERSUPPLIER',pic:'ZZZZZ9'},{av:'AV35FilterOrderDesc',fld:'vFILTERORDERDESC',pic:''}]");
         setEventMetadata("GRID_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_PURCHASEORDERSTATE","{handler:'Validv_Purchaseorderstate',iparms:[]");
         setEventMetadata("VALIDV_PURCHASEORDERSTATE",",oparms:[]}");
         setEventMetadata("VALIDV_FILTERCREATEDFROM","{handler:'Validv_Filtercreatedfrom',iparms:[]");
         setEventMetadata("VALIDV_FILTERCREATEDFROM",",oparms:[]}");
         setEventMetadata("VALIDV_FILTERCREATEDTO","{handler:'Validv_Filtercreatedto',iparms:[]");
         setEventMetadata("VALIDV_FILTERCREATEDTO",",oparms:[]}");
         setEventMetadata("VALIDV_FILTERCLOSEDFROM","{handler:'Validv_Filterclosedfrom',iparms:[]");
         setEventMetadata("VALIDV_FILTERCLOSEDFROM",",oparms:[]}");
         setEventMetadata("VALIDV_FILTERCLOSEDTO","{handler:'Validv_Filterclosedto',iparms:[]");
         setEventMetadata("VALIDV_FILTERCLOSEDTO",",oparms:[]}");
         setEventMetadata("VALIDV_FILTERSTATE","{handler:'Validv_Filterstate',iparms:[]");
         setEventMetadata("VALIDV_FILTERSTATE",",oparms:[]}");
         setEventMetadata("VALIDV_CREATEDDATEFROM","{handler:'Validv_Createddatefrom',iparms:[]");
         setEventMetadata("VALIDV_CREATEDDATEFROM",",oparms:[]}");
         setEventMetadata("VALIDV_CREATEDDATETO","{handler:'Validv_Createddateto',iparms:[]");
         setEventMetadata("VALIDV_CREATEDDATETO",",oparms:[]}");
         setEventMetadata("VALIDV_CLOSEDDATEFROM","{handler:'Validv_Closeddatefrom',iparms:[]");
         setEventMetadata("VALIDV_CLOSEDDATEFROM",",oparms:[]}");
         setEventMetadata("VALIDV_CLOSEDDATETO","{handler:'Validv_Closeddateto',iparms:[]");
         setEventMetadata("VALIDV_CLOSEDDATETO",",oparms:[]}");
         setEventMetadata("VALID_PURCHASEORDERID","{handler:'Valid_Purchaseorderid',iparms:[]");
         setEventMetadata("VALID_PURCHASEORDERID",",oparms:[]}");
         setEventMetadata("VALIDV_STATE","{handler:'Validv_State',iparms:[]");
         setEventMetadata("VALIDV_STATE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Details',iparms:[]");
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
         AV18PurchaseOrderState = "";
         AV20CreatedDateFrom = DateTime.MinValue;
         AV21CreatedDateTo = DateTime.MinValue;
         AV22ClosedDateFrom = DateTime.MinValue;
         AV23ClosedDateTo = DateTime.MinValue;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTitletext_Jsonclick = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnexport_Jsonclick = "";
         bttBtntoggle_Jsonclick = "";
         AV30FilterCreatedFrom = DateTime.MinValue;
         AV31FilterCreatedTo = DateTime.MinValue;
         AV32FilterClosedFrom = DateTime.MinValue;
         AV33FilterClosedTo = DateTime.MinValue;
         AV29FilterState = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         bttBtntoggleontable_Jsonclick = "";
         lblLblcreateddatefromfilter_Jsonclick = "";
         lblLblcreateddatetofilter_Jsonclick = "";
         lblLblcloseddatefromfilter_Jsonclick = "";
         lblLblcloseddatetofilter_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A52PurchaseOrderCreatedDate = DateTime.MinValue;
         A5SupplierName = "";
         A66PurchaseOrderClosedDate = DateTime.MinValue;
         AV28State = "";
         AV27Details = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         scmdbuf = "";
         H00122_A4SupplierId = new int[1] ;
         H00122_A5SupplierName = new string[] {""} ;
         AV44Pgmname = "";
         GridState = new GXGridStateHandler(context,"Grid",GetPgmname(),subgrid_varsfromstate,subgrid_varstostate);
         H00124_A4SupplierId = new int[1] ;
         H00124_A138PurchaseOrderWasPaid = new bool[] {false} ;
         H00124_n138PurchaseOrderWasPaid = new bool[] {false} ;
         H00124_A79PurchaseOrderActive = new bool[] {false} ;
         H00124_A66PurchaseOrderClosedDate = new DateTime[] {DateTime.MinValue} ;
         H00124_n66PurchaseOrderClosedDate = new bool[] {false} ;
         H00124_A78PurchaseOrderTotalPaid = new decimal[1] ;
         H00124_n78PurchaseOrderTotalPaid = new bool[] {false} ;
         H00124_A5SupplierName = new string[] {""} ;
         H00124_A52PurchaseOrderCreatedDate = new DateTime[] {DateTime.MinValue} ;
         H00124_A50PurchaseOrderId = new int[1] ;
         H00124_A67PurchaseOrderDetailsQuantity = new short[1] ;
         H00124_n67PurchaseOrderDetailsQuantity = new bool[] {false} ;
         H00126_AGRID_nRecordCount = new long[1] ;
         GXt_SdtSDTContextSession1 = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         AV14ADVANCED_LABEL_TEMPLATE = "";
         GridRow = new GXWebRow();
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV7HTTPRequest = new GxHttpRequest( context);
         AV6Session = context.GetSession();
         AV24ExcelFilename = "";
         AV25ErrorMessage = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpurchaseorder__default(),
            new Object[][] {
                new Object[] {
               H00122_A4SupplierId, H00122_A5SupplierName
               }
               , new Object[] {
               H00124_A4SupplierId, H00124_A138PurchaseOrderWasPaid, H00124_n138PurchaseOrderWasPaid, H00124_A79PurchaseOrderActive, H00124_A66PurchaseOrderClosedDate, H00124_n66PurchaseOrderClosedDate, H00124_A78PurchaseOrderTotalPaid, H00124_n78PurchaseOrderTotalPaid, H00124_A5SupplierName, H00124_A52PurchaseOrderCreatedDate,
               H00124_A50PurchaseOrderId, H00124_A67PurchaseOrderDetailsQuantity, H00124_n67PurchaseOrderDetailsQuantity
               }
               , new Object[] {
               H00126_AGRID_nRecordCount
               }
            }
         );
         AV44Pgmname = "WWPurchaseOrder";
         /* GeneXus formulas. */
         AV44Pgmname = "WWPurchaseOrder";
         context.Gx_err = 0;
         cmbavState.Enabled = 0;
         edtavDetails_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV19OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV34FilterOrder ;
      private short A67PurchaseOrderDetailsQuantity ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int nRC_GXsfl_70 ;
      private int subGrid_Rows ;
      private int nGXsfl_70_idx=1 ;
      private int AV37FilterSupplier ;
      private int AV40PurchaseOrderId ;
      private int AV41SupplierId ;
      private int bttBtntoggle_Visible ;
      private int bttBtntoggle_Enabled ;
      private int AV39FilterNro ;
      private int edtavFilternro_Enabled ;
      private int edtavFiltercreatedfrom_Enabled ;
      private int edtavFiltercreatedto_Enabled ;
      private int edtavFilterclosedfrom_Enabled ;
      private int edtavFilterclosedto_Enabled ;
      private int edtavCreateddatefrom_Visible ;
      private int edtavCreateddatefrom_Enabled ;
      private int edtavCreateddateto_Visible ;
      private int edtavCreateddateto_Enabled ;
      private int edtavCloseddatefrom_Visible ;
      private int edtavCloseddatefrom_Enabled ;
      private int edtavCloseddateto_Visible ;
      private int edtavCloseddateto_Enabled ;
      private int A50PurchaseOrderId ;
      private int gxdynajaxindex ;
      private int subGrid_Islastpage ;
      private int edtavDetails_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A4SupplierId ;
      private int GridPageCount ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int edtavDetails_Visible ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal A78PurchaseOrderTotalPaid ;
      private string divFilterscontainer_Class ;
      private string divCreateddatefromfiltercontainer_Class ;
      private string divCreateddatetofiltercontainer_Class ;
      private string divCloseddatefromfiltercontainer_Class ;
      private string divCloseddatetofiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_70_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divGridcell_Internalname ;
      private string divGridcell_Class ;
      private string divGridtable_Internalname ;
      private string divTabletop_Internalname ;
      private string lblTitletext_Internalname ;
      private string lblTitletext_Jsonclick ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnexport_Internalname ;
      private string bttBtnexport_Jsonclick ;
      private string cmbavPurchaseorderstate_Internalname ;
      private string cmbavPurchaseorderstate_Jsonclick ;
      private string bttBtntoggle_Class ;
      private string bttBtntoggle_Internalname ;
      private string bttBtntoggle_Caption ;
      private string bttBtntoggle_Jsonclick ;
      private string bttBtntoggle_Tooltiptext ;
      private string divTable1_Internalname ;
      private string edtavFilternro_Internalname ;
      private string edtavFilternro_Jsonclick ;
      private string edtavFiltercreatedfrom_Internalname ;
      private string edtavFiltercreatedfrom_Jsonclick ;
      private string edtavFiltercreatedto_Internalname ;
      private string edtavFiltercreatedto_Jsonclick ;
      private string edtavFilterclosedfrom_Internalname ;
      private string edtavFilterclosedfrom_Jsonclick ;
      private string edtavFilterclosedto_Internalname ;
      private string edtavFilterclosedto_Jsonclick ;
      private string dynavFiltersupplier_Internalname ;
      private string dynavFiltersupplier_Jsonclick ;
      private string cmbavFilterstate_Internalname ;
      private string cmbavFilterstate_Jsonclick ;
      private string cmbavFilterorder_Internalname ;
      private string cmbavFilterorder_Jsonclick ;
      private string chkavFilterorderdesc_Internalname ;
      private string divGridcontainer_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string divFilterscontainer_Internalname ;
      private string bttBtntoggleontable_Internalname ;
      private string bttBtntoggleontable_Jsonclick ;
      private string cmbavOrderedby_Internalname ;
      private string cmbavOrderedby_Jsonclick ;
      private string divCreateddatefromfiltercontainer_Internalname ;
      private string lblLblcreateddatefromfilter_Internalname ;
      private string lblLblcreateddatefromfilter_Jsonclick ;
      private string edtavCreateddatefrom_Internalname ;
      private string edtavCreateddatefrom_Jsonclick ;
      private string divCreateddatetofiltercontainer_Internalname ;
      private string lblLblcreateddatetofilter_Internalname ;
      private string lblLblcreateddatetofilter_Jsonclick ;
      private string edtavCreateddateto_Internalname ;
      private string edtavCreateddateto_Jsonclick ;
      private string divCloseddatefromfiltercontainer_Internalname ;
      private string lblLblcloseddatefromfilter_Internalname ;
      private string lblLblcloseddatefromfilter_Jsonclick ;
      private string edtavCloseddatefrom_Internalname ;
      private string edtavCloseddatefrom_Jsonclick ;
      private string divCloseddatetofiltercontainer_Internalname ;
      private string lblLblcloseddatetofilter_Internalname ;
      private string lblLblcloseddatetofilter_Jsonclick ;
      private string edtavCloseddateto_Internalname ;
      private string edtavCloseddateto_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtPurchaseOrderId_Internalname ;
      private string edtPurchaseOrderCreatedDate_Internalname ;
      private string edtSupplierName_Internalname ;
      private string edtPurchaseOrderTotalPaid_Internalname ;
      private string edtPurchaseOrderClosedDate_Internalname ;
      private string chkPurchaseOrderActive_Internalname ;
      private string chkPurchaseOrderWasPaid_Internalname ;
      private string edtPurchaseOrderDetailsQuantity_Internalname ;
      private string cmbavState_Internalname ;
      private string edtavDetails_Internalname ;
      private string gxwrpcisep ;
      private string scmdbuf ;
      private string AV44Pgmname ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string sGXsfl_70_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtPurchaseOrderId_Jsonclick ;
      private string edtPurchaseOrderCreatedDate_Jsonclick ;
      private string edtSupplierName_Jsonclick ;
      private string edtPurchaseOrderTotalPaid_Jsonclick ;
      private string edtPurchaseOrderClosedDate_Jsonclick ;
      private string GXCCtl ;
      private string edtPurchaseOrderDetailsQuantity_Jsonclick ;
      private string cmbavState_Jsonclick ;
      private string edtavDetails_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV20CreatedDateFrom ;
      private DateTime AV21CreatedDateTo ;
      private DateTime AV22ClosedDateFrom ;
      private DateTime AV23ClosedDateTo ;
      private DateTime AV30FilterCreatedFrom ;
      private DateTime AV31FilterCreatedTo ;
      private DateTime AV32FilterClosedFrom ;
      private DateTime AV33FilterClosedTo ;
      private DateTime A52PurchaseOrderCreatedDate ;
      private DateTime A66PurchaseOrderClosedDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV35FilterOrderDesc ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n78PurchaseOrderTotalPaid ;
      private bool n66PurchaseOrderClosedDate ;
      private bool A79PurchaseOrderActive ;
      private bool A138PurchaseOrderWasPaid ;
      private bool n138PurchaseOrderWasPaid ;
      private bool n67PurchaseOrderDetailsQuantity ;
      private bool gxdyncontrolsrefreshing ;
      private bool bGXsfl_70_Refreshing=false ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV18PurchaseOrderState ;
      private string AV29FilterState ;
      private string A5SupplierName ;
      private string AV28State ;
      private string AV27Details ;
      private string AV24ExcelFilename ;
      private string AV25ErrorMessage ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid GridContainer ;
      private GXGridStateHandler GridState ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavPurchaseorderstate ;
      private GXCombobox dynavFiltersupplier ;
      private GXCombobox cmbavFilterstate ;
      private GXCombobox cmbavFilterorder ;
      private GXCheckbox chkavFilterorderdesc ;
      private GXCheckbox chkPurchaseOrderActive ;
      private GXCheckbox chkPurchaseOrderWasPaid ;
      private GXCombobox cmbavState ;
      private GXCombobox cmbavOrderedby ;
      private IDataStoreProvider pr_default ;
      private int[] H00122_A4SupplierId ;
      private string[] H00122_A5SupplierName ;
      private int[] H00124_A4SupplierId ;
      private bool[] H00124_A138PurchaseOrderWasPaid ;
      private bool[] H00124_n138PurchaseOrderWasPaid ;
      private bool[] H00124_A79PurchaseOrderActive ;
      private DateTime[] H00124_A66PurchaseOrderClosedDate ;
      private bool[] H00124_n66PurchaseOrderClosedDate ;
      private decimal[] H00124_A78PurchaseOrderTotalPaid ;
      private bool[] H00124_n78PurchaseOrderTotalPaid ;
      private string[] H00124_A5SupplierName ;
      private DateTime[] H00124_A52PurchaseOrderCreatedDate ;
      private int[] H00124_A50PurchaseOrderId ;
      private short[] H00124_A67PurchaseOrderDetailsQuantity ;
      private bool[] H00124_n67PurchaseOrderDetailsQuantity ;
      private long[] H00126_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV7HTTPRequest ;
      private IGxSession AV6Session ;
      private GXWebForm Form ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession GXt_SdtSDTContextSession1 ;
   }

   public class wwpurchaseorder__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00124( IGxContext context ,
                                             string AV18PurchaseOrderState ,
                                             DateTime AV20CreatedDateFrom ,
                                             DateTime AV21CreatedDateTo ,
                                             DateTime AV22ClosedDateFrom ,
                                             DateTime AV23ClosedDateTo ,
                                             int AV41SupplierId ,
                                             int AV40PurchaseOrderId ,
                                             bool A79PurchaseOrderActive ,
                                             DateTime A66PurchaseOrderClosedDate ,
                                             DateTime A52PurchaseOrderCreatedDate ,
                                             int A4SupplierId ,
                                             int A50PurchaseOrderId ,
                                             short AV19OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[9];
         Object[] GXv_Object3 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[SupplierId], T1.[PurchaseOrderWasPaid], T1.[PurchaseOrderActive], T1.[PurchaseOrderClosedDate], T1.[PurchaseOrderTotalPaid], T2.[SupplierName], T1.[PurchaseOrderCreatedDate], T1.[PurchaseOrderId], COALESCE( T3.[PurchaseOrderDetailsQuantity], 0) AS PurchaseOrderDetailsQuantity";
         sFromString = " FROM (([PurchaseOrder] T1 INNER JOIN [Supplier] T2 ON T2.[SupplierId] = T1.[SupplierId]) LEFT JOIN (SELECT COUNT(*) AS PurchaseOrderDetailsQuantity, [PurchaseOrderId] FROM [PurchaseOrderDetail] GROUP BY [PurchaseOrderId] ) T3 ON T3.[PurchaseOrderId] = T1.[PurchaseOrderId])";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18PurchaseOrderState)) && ( StringUtil.StrCmp(AV18PurchaseOrderState, "Canceled") == 0 ) )
         {
            AddWhere(sWhereString, "(( Not T1.[PurchaseOrderActive] = 1))");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18PurchaseOrderState)) && ( StringUtil.StrCmp(AV18PurchaseOrderState, "Pending") == 0 ) )
         {
            AddWhere(sWhereString, "(( T1.[PurchaseOrderActive] = 1 and ( T1.[PurchaseOrderClosedDate] IS NULL or (T1.[PurchaseOrderClosedDate] = convert( DATETIME, '17530101', 112 )) or T1.[PurchaseOrderClosedDate] = convert( DATETIME, '17530101', 112 ))))");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18PurchaseOrderState)) && ( StringUtil.StrCmp(AV18PurchaseOrderState, "Received") == 0 ) )
         {
            AddWhere(sWhereString, "(( T1.[PurchaseOrderActive] = 1 and Not ( T1.[PurchaseOrderClosedDate] IS NULL or (T1.[PurchaseOrderClosedDate] = convert( DATETIME, '17530101', 112 )) or T1.[PurchaseOrderClosedDate] = convert( DATETIME, '17530101', 112 ))))");
         }
         if ( ! (DateTime.MinValue==AV20CreatedDateFrom) )
         {
            AddWhere(sWhereString, "(T1.[PurchaseOrderCreatedDate] >= @AV20CreatedDateFrom)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV21CreatedDateTo) )
         {
            AddWhere(sWhereString, "(T1.[PurchaseOrderCreatedDate] <= @AV21CreatedDateTo)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV22ClosedDateFrom) )
         {
            AddWhere(sWhereString, "(T1.[PurchaseOrderClosedDate] >= @AV22ClosedDateFrom)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV23ClosedDateTo) )
         {
            AddWhere(sWhereString, "(T1.[PurchaseOrderClosedDate] <= @AV23ClosedDateTo)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! (0==AV41SupplierId) )
         {
            AddWhere(sWhereString, "(T1.[SupplierId] = @AV41SupplierId)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! (0==AV40PurchaseOrderId) )
         {
            AddWhere(sWhereString, "(T1.[PurchaseOrderId] = @AV40PurchaseOrderId)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( AV19OrderedBy == 1 )
         {
            sOrderString += " ORDER BY T1.[PurchaseOrderCreatedDate]";
         }
         else if ( AV19OrderedBy == 2 )
         {
            sOrderString += " ORDER BY T1.[PurchaseOrderCreatedDate] DESC";
         }
         else if ( AV19OrderedBy == 3 )
         {
            sOrderString += " ORDER BY T1.[PurchaseOrderClosedDate]";
         }
         else if ( AV19OrderedBy == 4 )
         {
            sOrderString += " ORDER BY T1.[PurchaseOrderClosedDate] DESC";
         }
         else if ( AV19OrderedBy == 5 )
         {
            sOrderString += " ORDER BY T2.[SupplierName]";
         }
         else if ( AV19OrderedBy == 6 )
         {
            sOrderString += " ORDER BY T2.[SupplierName] DESC";
         }
         else if ( AV19OrderedBy == 7 )
         {
            sOrderString += " ORDER BY T1.[PurchaseOrderId]";
         }
         else if ( AV19OrderedBy == 8 )
         {
            sOrderString += " ORDER BY T1.[PurchaseOrderId] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.[PurchaseOrderId]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_H00126( IGxContext context ,
                                             string AV18PurchaseOrderState ,
                                             DateTime AV20CreatedDateFrom ,
                                             DateTime AV21CreatedDateTo ,
                                             DateTime AV22ClosedDateFrom ,
                                             DateTime AV23ClosedDateTo ,
                                             int AV41SupplierId ,
                                             int AV40PurchaseOrderId ,
                                             bool A79PurchaseOrderActive ,
                                             DateTime A66PurchaseOrderClosedDate ,
                                             DateTime A52PurchaseOrderCreatedDate ,
                                             int A4SupplierId ,
                                             int A50PurchaseOrderId ,
                                             short AV19OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[6];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (([PurchaseOrder] T1 INNER JOIN [Supplier] T2 ON T2.[SupplierId] = T1.[SupplierId]) LEFT JOIN (SELECT COUNT(*) AS PurchaseOrderDetailsQuantity, [PurchaseOrderId] FROM [PurchaseOrderDetail] GROUP BY [PurchaseOrderId] ) T3 ON T3.[PurchaseOrderId] = T1.[PurchaseOrderId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18PurchaseOrderState)) && ( StringUtil.StrCmp(AV18PurchaseOrderState, "Canceled") == 0 ) )
         {
            AddWhere(sWhereString, "(( Not T1.[PurchaseOrderActive] = 1))");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18PurchaseOrderState)) && ( StringUtil.StrCmp(AV18PurchaseOrderState, "Pending") == 0 ) )
         {
            AddWhere(sWhereString, "(( T1.[PurchaseOrderActive] = 1 and ( T1.[PurchaseOrderClosedDate] IS NULL or (T1.[PurchaseOrderClosedDate] = convert( DATETIME, '17530101', 112 )) or T1.[PurchaseOrderClosedDate] = convert( DATETIME, '17530101', 112 ))))");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18PurchaseOrderState)) && ( StringUtil.StrCmp(AV18PurchaseOrderState, "Received") == 0 ) )
         {
            AddWhere(sWhereString, "(( T1.[PurchaseOrderActive] = 1 and Not ( T1.[PurchaseOrderClosedDate] IS NULL or (T1.[PurchaseOrderClosedDate] = convert( DATETIME, '17530101', 112 )) or T1.[PurchaseOrderClosedDate] = convert( DATETIME, '17530101', 112 ))))");
         }
         if ( ! (DateTime.MinValue==AV20CreatedDateFrom) )
         {
            AddWhere(sWhereString, "(T1.[PurchaseOrderCreatedDate] >= @AV20CreatedDateFrom)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV21CreatedDateTo) )
         {
            AddWhere(sWhereString, "(T1.[PurchaseOrderCreatedDate] <= @AV21CreatedDateTo)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV22ClosedDateFrom) )
         {
            AddWhere(sWhereString, "(T1.[PurchaseOrderClosedDate] >= @AV22ClosedDateFrom)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV23ClosedDateTo) )
         {
            AddWhere(sWhereString, "(T1.[PurchaseOrderClosedDate] <= @AV23ClosedDateTo)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! (0==AV41SupplierId) )
         {
            AddWhere(sWhereString, "(T1.[SupplierId] = @AV41SupplierId)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! (0==AV40PurchaseOrderId) )
         {
            AddWhere(sWhereString, "(T1.[PurchaseOrderId] = @AV40PurchaseOrderId)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV19OrderedBy == 1 )
         {
            scmdbuf += "";
         }
         else if ( AV19OrderedBy == 2 )
         {
            scmdbuf += "";
         }
         else if ( AV19OrderedBy == 3 )
         {
            scmdbuf += "";
         }
         else if ( AV19OrderedBy == 4 )
         {
            scmdbuf += "";
         }
         else if ( AV19OrderedBy == 5 )
         {
            scmdbuf += "";
         }
         else if ( AV19OrderedBy == 6 )
         {
            scmdbuf += "";
         }
         else if ( AV19OrderedBy == 7 )
         {
            scmdbuf += "";
         }
         else if ( AV19OrderedBy == 8 )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_H00124(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (bool)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (short)dynConstraints[12] );
               case 2 :
                     return conditional_H00126(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (bool)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (short)dynConstraints[12] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00122;
          prmH00122 = new Object[] {
          };
          Object[] prmH00124;
          prmH00124 = new Object[] {
          new ParDef("@AV20CreatedDateFrom",GXType.Date,8,0) ,
          new ParDef("@AV21CreatedDateTo",GXType.Date,8,0) ,
          new ParDef("@AV22ClosedDateFrom",GXType.Date,8,0) ,
          new ParDef("@AV23ClosedDateTo",GXType.Date,8,0) ,
          new ParDef("@AV41SupplierId",GXType.Int32,6,0) ,
          new ParDef("@AV40PurchaseOrderId",GXType.Int32,6,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00126;
          prmH00126 = new Object[] {
          new ParDef("@AV20CreatedDateFrom",GXType.Date,8,0) ,
          new ParDef("@AV21CreatedDateTo",GXType.Date,8,0) ,
          new ParDef("@AV22ClosedDateFrom",GXType.Date,8,0) ,
          new ParDef("@AV23ClosedDateTo",GXType.Date,8,0) ,
          new ParDef("@AV41SupplierId",GXType.Int32,6,0) ,
          new ParDef("@AV40PurchaseOrderId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00122", "SELECT [SupplierId], [SupplierName] FROM [Supplier] ORDER BY [SupplierName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00122,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00124", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00124,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00126", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00126,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((string[]) buf[8])[0] = rslt.getVarchar(6);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(7);
                ((int[]) buf[10])[0] = rslt.getInt(8);
                ((short[]) buf[11])[0] = rslt.getShort(9);
                ((bool[]) buf[12])[0] = rslt.wasNull(9);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
