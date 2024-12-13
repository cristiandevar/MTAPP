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
   public class wwinvoice : GXDataArea
   {
      public wwinvoice( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public wwinvoice( IGxContext context )
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
         cmbavFilterstate = new GXCombobox();
         cmbavFilterorder = new GXCombobox();
         chkavFilterorderdesc = new GXCheckbox();
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
         nRC_GXsfl_62 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_62"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_62_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_62_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_62_idx = GetPar( "sGXsfl_62_idx");
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
         AV23UserName = GetPar( "UserName");
         cmbavOrderedby.FromJSonString( GetNextPar( ));
         AV24OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV32FromInvoiceCreatedDate = context.localUtil.ParseDateParm( GetPar( "FromInvoiceCreatedDate"));
         AV33ToInvoiceCreatedDate = context.localUtil.ParseDateParm( GetPar( "ToInvoiceCreatedDate"));
         AV14ADVANCED_LABEL_TEMPLATE = GetPar( "ADVANCED_LABEL_TEMPLATE");
         AV40FilterOrderDesc = StringUtil.StrToBool( GetPar( "FilterOrderDesc"));
         AV41InvoiceState = GetPar( "InvoiceState");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV23UserName, AV24OrderedBy, AV32FromInvoiceCreatedDate, AV33ToInvoiceCreatedDate, AV14ADVANCED_LABEL_TEMPLATE, AV40FilterOrderDesc, AV41InvoiceState) ;
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
         PA272( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START272( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwinvoice.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vADVANCED_LABEL_TEMPLATE", StringUtil.RTrim( AV14ADVANCED_LABEL_TEMPLATE));
         GxWebStd.gx_hidden_field( context, "gxhash_vADVANCED_LABEL_TEMPLATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14ADVANCED_LABEL_TEMPLATE, "")), context));
         GxWebStd.gx_hidden_field( context, "vINVOICESTATE", AV41InvoiceState);
         GxWebStd.gx_hidden_field( context, "gxhash_vINVOICESTATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV41InvoiceState, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vUSERNAME", AV23UserName);
         GxWebStd.gx_hidden_field( context, "GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vFROMINVOICECREATEDDATE", context.localUtil.Format(AV32FromInvoiceCreatedDate, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vTOINVOICECREATEDDATE", context.localUtil.Format(AV33ToInvoiceCreatedDate, "99/99/99"));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_62", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_62), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vADVANCED_LABEL_TEMPLATE", StringUtil.RTrim( AV14ADVANCED_LABEL_TEMPLATE));
         GxWebStd.gx_hidden_field( context, "gxhash_vADVANCED_LABEL_TEMPLATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14ADVANCED_LABEL_TEMPLATE, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "INVOICEACTIVE", A94InvoiceActive);
         GxWebStd.gx_hidden_field( context, "vINVOICEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV44InvoiceId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINVOICESTATE", AV41InvoiceState);
         GxWebStd.gx_hidden_field( context, "gxhash_vINVOICESTATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV41InvoiceState, "")), context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FILTERSCONTAINER_Class", StringUtil.RTrim( divFilterscontainer_Class));
         GxWebStd.gx_hidden_field( context, "FROMINVOICECREATEDDATEFILTERCONTAINER_Class", StringUtil.RTrim( divFrominvoicecreateddatefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TOINVOICECREATEDDATEFILTERCONTAINER_Class", StringUtil.RTrim( divToinvoicecreateddatefiltercontainer_Class));
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
            WE272( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT272( ) ;
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
         return formatLink("wwinvoice.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWInvoice" ;
      }

      public override string GetPgmdesc( )
      {
         return "Work With Invoice" ;
      }

      protected void WB270( )
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
            GxWebStd.gx_label_ctrl( context, lblTitletext_Internalname, "Sales", "", "", lblTitletext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WWInvoice.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtnexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(62), 2, 0)+","+"null"+");", "Export", bttBtnexport_Jsonclick, 5, "Export to Excel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWInvoice.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ww__filter-cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsername_Internalname, "User Name", "gx-form-item attribute-searchLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'" + sGXsfl_62_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsername_Internalname, AV23UserName, StringUtil.RTrim( context.localUtil.Format( AV23UserName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,18);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Seller Name", edtavUsername_Jsonclick, 0, "attribute-search", "", "", "", "", edtavUsername_Visible, edtavUsername_Enabled, 1, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_WWInvoice.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ww__toggle-cell", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(62), 2, 0)+","+"null"+");", bttBtntoggle_Caption, bttBtntoggle_Jsonclick, 7, bttBtntoggle_Tooltiptext, "", StyleString, ClassString, bttBtntoggle_Visible, bttBtntoggle_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"e11271_client"+"'", TempTags, "", 2, "HLP_WWInvoice.htm");
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
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavFilternro_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilternro_Internalname, "Nro", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'" + sGXsfl_62_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilternro_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43FilterNro), 6, 0, ".", "")), StringUtil.LTrim( ((edtavFilternro_Enabled!=0) ? context.localUtil.Format( (decimal)(AV43FilterNro), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV43FilterNro), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFilternro_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilternro_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_WWInvoice.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavFiltercreatedfrom_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFiltercreatedfrom_Internalname, "Created From", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'" + sGXsfl_62_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFiltercreatedfrom_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFiltercreatedfrom_Internalname, context.localUtil.Format(AV35FilterCreatedFrom, "99/99/99"), context.localUtil.Format( AV35FilterCreatedFrom, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFiltercreatedfrom_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFiltercreatedfrom_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_WWInvoice.htm");
            GxWebStd.gx_bitmap( context, edtavFiltercreatedfrom_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavFiltercreatedfrom_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWInvoice.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavFiltercreatedto_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFiltercreatedto_Internalname, "Created To", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'" + sGXsfl_62_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFiltercreatedto_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFiltercreatedto_Internalname, context.localUtil.Format(AV36FilterCreatedTo, "99/99/99"), context.localUtil.Format( AV36FilterCreatedTo, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFiltercreatedto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFiltercreatedto_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_WWInvoice.htm");
            GxWebStd.gx_bitmap( context, edtavFiltercreatedto_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavFiltercreatedto_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWInvoice.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavFilterseller_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilterseller_Internalname, "Seller", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'" + sGXsfl_62_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterseller_Internalname, AV37FilterSeller, StringUtil.RTrim( context.localUtil.Format( AV37FilterSeller, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFilterseller_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterseller_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_WWInvoice.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'" + sGXsfl_62_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavFilterstate, cmbavFilterstate_Internalname, StringUtil.RTrim( AV38FilterState), 1, cmbavFilterstate_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavFilterstate.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "", true, 0, "HLP_WWInvoice.htm");
            cmbavFilterstate.CurrentValue = StringUtil.RTrim( AV38FilterState);
            AssignProp("", false, cmbavFilterstate_Internalname, "Values", (string)(cmbavFilterstate.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavFilterorder_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavFilterorder_Internalname, "Order", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'" + sGXsfl_62_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavFilterorder, cmbavFilterorder_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV39FilterOrder), 4, 0)), 1, cmbavFilterorder_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavFilterorder.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "", true, 0, "HLP_WWInvoice.htm");
            cmbavFilterorder.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV39FilterOrder), 4, 0));
            AssignProp("", false, cmbavFilterorder_Internalname, "Values", (string)(cmbavFilterorder.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavFilterorderdesc_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavFilterorderdesc_Internalname, "Order Desc", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_62_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavFilterorderdesc_Internalname, StringUtil.BoolToStr( AV40FilterOrderDesc), "", "Order Desc", 1, chkavFilterorderdesc.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(56, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,56);\"");
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
            GxWebStd.gx_div_start( context, divGridcontainer_Internalname, 1, 0, "px", 0, "px", "ww__grid-container", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl62( ) ;
         }
         if ( wbEnd == 62 )
         {
            wbEnd = 0;
            nRC_GXsfl_62 = (int)(nGXsfl_62_idx-1);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
            ClassString = "filters-container__close";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggleontable_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(62), 2, 0)+","+"null"+");", "Hide Filters", bttBtntoggleontable_Jsonclick, 7, "Hide Filters", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e11271_client"+"'", TempTags, "", 2, "HLP_WWInvoice.htm");
            GxWebStd.gx_div_end( context, "Right", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", cmbavOrderedby.Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavOrderedby_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavOrderedby_Internalname, "Ordered By", "col-xs-12 attribute-comboLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'" + sGXsfl_62_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavOrderedby, cmbavOrderedby_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV24OrderedBy), 4, 0)), 1, cmbavOrderedby_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavOrderedby.Visible, cmbavOrderedby.Enabled, 1, 0, 0, "em", 0, "", "", "attribute-combo", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "", true, 0, "HLP_WWInvoice.htm");
            cmbavOrderedby.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24OrderedBy), 4, 0));
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
            GxWebStd.gx_div_start( context, divFrominvoicecreateddatefiltercontainer_Internalname, 1, 0, "px", 0, "px", divFrominvoicecreateddatefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblfrominvoicecreateddatefilter_Internalname, lblLblfrominvoicecreateddatefilter_Caption, "", "", lblLblfrominvoicecreateddatefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12271_client"+"'", "", "filter-item__label", 7, "", 1, 1, 0, 1, "HLP_WWInvoice.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 filter-item__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFrominvoicecreateddate_Internalname, "From Invoice Created Date", "col-sm-3 attribute-comboLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'" + sGXsfl_62_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFrominvoicecreateddate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFrominvoicecreateddate_Internalname, context.localUtil.Format(AV32FromInvoiceCreatedDate, "99/99/99"), context.localUtil.Format( AV32FromInvoiceCreatedDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFrominvoicecreateddate_Jsonclick, 0, "attribute-combo", "", "", "", "", edtavFrominvoicecreateddate_Visible, edtavFrominvoicecreateddate_Enabled, 1, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_WWInvoice.htm");
            GxWebStd.gx_bitmap( context, edtavFrominvoicecreateddate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((edtavFrominvoicecreateddate_Visible==0)||(edtavFrominvoicecreateddate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWInvoice.htm");
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
            GxWebStd.gx_div_start( context, divToinvoicecreateddatefiltercontainer_Internalname, 1, 0, "px", 0, "px", divToinvoicecreateddatefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltoinvoicecreateddatefilter_Internalname, lblLbltoinvoicecreateddatefilter_Caption, "", "", lblLbltoinvoicecreateddatefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13271_client"+"'", "", "filter-item__label", 7, "", 1, 1, 0, 1, "HLP_WWInvoice.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 filter-item__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavToinvoicecreateddate_Internalname, "To Invoice Created Date", "col-sm-3 attribute-comboLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'" + sGXsfl_62_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavToinvoicecreateddate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavToinvoicecreateddate_Internalname, context.localUtil.Format(AV33ToInvoiceCreatedDate, "99/99/99"), context.localUtil.Format( AV33ToInvoiceCreatedDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavToinvoicecreateddate_Jsonclick, 0, "attribute-combo", "", "", "", "", edtavToinvoicecreateddate_Visible, edtavToinvoicecreateddate_Enabled, 1, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_WWInvoice.htm");
            GxWebStd.gx_bitmap( context, edtavToinvoicecreateddate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((edtavToinvoicecreateddate_Visible==0)||(edtavToinvoicecreateddate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWInvoice.htm");
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
         if ( wbEnd == 62 )
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

      protected void START272( )
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
            Form.Meta.addItem("description", "Work With Invoice", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP270( ) ;
      }

      protected void WS272( )
      {
         START272( ) ;
         EVT272( ) ;
      }

      protected void EVT272( )
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
                              E14272 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VFILTERNRO.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E15272 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VFILTERSTATE.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E16272 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VFILTERSELLER.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E17272 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VFILTERCREATEDFROM.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E18272 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VFILTERCREATEDTO.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E19272 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VFILTERORDER.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E20272 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VFILTERORDERDESC.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E21272 ();
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
                              nGXsfl_62_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_62_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_62_idx), 4, 0), 4, "0");
                              SubsflControlProps_622( ) ;
                              A20InvoiceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtInvoiceId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A38InvoiceCreatedDate = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtInvoiceCreatedDate_Internalname), 0));
                              A80InvoiceTotalReceivable = context.localUtil.CToN( cgiGet( edtInvoiceTotalReceivable_Internalname), ".", ",");
                              n80InvoiceTotalReceivable = false;
                              A100UserName = cgiGet( edtUserName_Internalname);
                              AV21State = cgiGet( edtavState_Internalname);
                              AssignAttri("", false, edtavState_Internalname, AV21State);
                              AV22Details = cgiGet( edtavDetails_Internalname);
                              AssignAttri("", false, edtavDetails_Internalname, AV22Details);
                              AV45Cancel = cgiGet( edtavCancel_Internalname);
                              AssignAttri("", false, edtavCancel_Internalname, AV45Cancel);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E22272 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E23272 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E24272 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Username Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vUSERNAME"), AV23UserName) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Orderedby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ".", ",") != Convert.ToDecimal( AV24OrderedBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Frominvoicecreateddate Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vFROMINVOICECREATEDDATE"), 0) != AV32FromInvoiceCreatedDate )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Toinvoicecreateddate Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vTOINVOICECREATEDDATE"), 0) != AV33ToInvoiceCreatedDate )
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

      protected void WE272( )
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

      protected void PA272( )
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
               GX_FocusControl = edtavUsername_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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
         SubsflControlProps_622( ) ;
         while ( nGXsfl_62_idx <= nRC_GXsfl_62 )
         {
            sendrow_622( ) ;
            nGXsfl_62_idx = ((subGrid_Islastpage==1)&&(nGXsfl_62_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_62_idx+1);
            sGXsfl_62_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_62_idx), 4, 0), 4, "0");
            SubsflControlProps_622( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV23UserName ,
                                       short AV24OrderedBy ,
                                       DateTime AV32FromInvoiceCreatedDate ,
                                       DateTime AV33ToInvoiceCreatedDate ,
                                       string AV14ADVANCED_LABEL_TEMPLATE ,
                                       bool AV40FilterOrderDesc ,
                                       string AV41InvoiceState )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF272( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_INVOICEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A20InvoiceId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "INVOICEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A20InvoiceId), 6, 0, ".", "")));
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
         if ( cmbavFilterstate.ItemCount > 0 )
         {
            AV38FilterState = cmbavFilterstate.getValidValue(AV38FilterState);
            AssignAttri("", false, "AV38FilterState", AV38FilterState);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavFilterstate.CurrentValue = StringUtil.RTrim( AV38FilterState);
            AssignProp("", false, cmbavFilterstate_Internalname, "Values", cmbavFilterstate.ToJavascriptSource(), true);
         }
         if ( cmbavFilterorder.ItemCount > 0 )
         {
            AV39FilterOrder = (short)(Math.Round(NumberUtil.Val( cmbavFilterorder.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV39FilterOrder), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV39FilterOrder", StringUtil.LTrimStr( (decimal)(AV39FilterOrder), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavFilterorder.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV39FilterOrder), 4, 0));
            AssignProp("", false, cmbavFilterorder_Internalname, "Values", cmbavFilterorder.ToJavascriptSource(), true);
         }
         AV40FilterOrderDesc = StringUtil.StrToBool( StringUtil.BoolToStr( AV40FilterOrderDesc));
         AssignAttri("", false, "AV40FilterOrderDesc", AV40FilterOrderDesc);
         if ( cmbavOrderedby.ItemCount > 0 )
         {
            AV24OrderedBy = (short)(Math.Round(NumberUtil.Val( cmbavOrderedby.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV24OrderedBy), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24OrderedBy", StringUtil.LTrimStr( (decimal)(AV24OrderedBy), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavOrderedby.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24OrderedBy), 4, 0));
            AssignProp("", false, cmbavOrderedby_Internalname, "Values", cmbavOrderedby.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF272( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV49Pgmname = "WWInvoice";
         context.Gx_err = 0;
         edtavState_Enabled = 0;
         AssignProp("", false, edtavState_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavState_Enabled), 5, 0), !bGXsfl_62_Refreshing);
         edtavDetails_Enabled = 0;
         AssignProp("", false, edtavDetails_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDetails_Enabled), 5, 0), !bGXsfl_62_Refreshing);
         edtavCancel_Enabled = 0;
         AssignProp("", false, edtavCancel_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCancel_Enabled), 5, 0), !bGXsfl_62_Refreshing);
      }

      protected void RF272( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 62;
         /* Execute user event: Refresh */
         E23272 ();
         nGXsfl_62_idx = 1;
         sGXsfl_62_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_62_idx), 4, 0), 4, "0");
         SubsflControlProps_622( ) ;
         bGXsfl_62_Refreshing = true;
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
            SubsflControlProps_622( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV23UserName ,
                                                 AV32FromInvoiceCreatedDate ,
                                                 AV33ToInvoiceCreatedDate ,
                                                 AV42InvoiceStateValue ,
                                                 AV44InvoiceId ,
                                                 A100UserName ,
                                                 A38InvoiceCreatedDate ,
                                                 A94InvoiceActive ,
                                                 A20InvoiceId ,
                                                 AV24OrderedBy } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.SHORT
                                                 }
            });
            lV23UserName = StringUtil.Concat( StringUtil.RTrim( AV23UserName), "%", "");
            /* Using cursor H00275 */
            pr_default.execute(0, new Object[] {lV23UserName, AV32FromInvoiceCreatedDate, AV33ToInvoiceCreatedDate, AV44InvoiceId, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_62_idx = 1;
            sGXsfl_62_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_62_idx), 4, 0), 4, "0");
            SubsflControlProps_622( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A99UserId = H00275_A99UserId[0];
               A94InvoiceActive = H00275_A94InvoiceActive[0];
               A100UserName = H00275_A100UserName[0];
               A38InvoiceCreatedDate = H00275_A38InvoiceCreatedDate[0];
               A20InvoiceId = H00275_A20InvoiceId[0];
               A80InvoiceTotalReceivable = H00275_A80InvoiceTotalReceivable[0];
               n80InvoiceTotalReceivable = H00275_n80InvoiceTotalReceivable[0];
               A100UserName = H00275_A100UserName[0];
               A80InvoiceTotalReceivable = H00275_A80InvoiceTotalReceivable[0];
               n80InvoiceTotalReceivable = H00275_n80InvoiceTotalReceivable[0];
               E24272 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 62;
            WB270( ) ;
         }
         bGXsfl_62_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes272( )
      {
         GxWebStd.gx_hidden_field( context, "vADVANCED_LABEL_TEMPLATE", StringUtil.RTrim( AV14ADVANCED_LABEL_TEMPLATE));
         GxWebStd.gx_hidden_field( context, "gxhash_vADVANCED_LABEL_TEMPLATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14ADVANCED_LABEL_TEMPLATE, "")), context));
         GxWebStd.gx_hidden_field( context, "vINVOICESTATE", AV41InvoiceState);
         GxWebStd.gx_hidden_field( context, "gxhash_vINVOICESTATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV41InvoiceState, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_INVOICEID"+"_"+sGXsfl_62_idx, GetSecureSignedToken( sGXsfl_62_idx, context.localUtil.Format( (decimal)(A20InvoiceId), "ZZZZZ9"), context));
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
                                              AV23UserName ,
                                              AV32FromInvoiceCreatedDate ,
                                              AV33ToInvoiceCreatedDate ,
                                              AV42InvoiceStateValue ,
                                              AV44InvoiceId ,
                                              A100UserName ,
                                              A38InvoiceCreatedDate ,
                                              A94InvoiceActive ,
                                              A20InvoiceId ,
                                              AV24OrderedBy } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.SHORT
                                              }
         });
         lV23UserName = StringUtil.Concat( StringUtil.RTrim( AV23UserName), "%", "");
         /* Using cursor H00279 */
         pr_default.execute(1, new Object[] {lV23UserName, AV32FromInvoiceCreatedDate, AV33ToInvoiceCreatedDate, AV44InvoiceId});
         GRID_nRecordCount = H00279_AGRID_nRecordCount[0];
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
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV23UserName, AV24OrderedBy, AV32FromInvoiceCreatedDate, AV33ToInvoiceCreatedDate, AV14ADVANCED_LABEL_TEMPLATE, AV40FilterOrderDesc, AV41InvoiceState) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV23UserName, AV24OrderedBy, AV32FromInvoiceCreatedDate, AV33ToInvoiceCreatedDate, AV14ADVANCED_LABEL_TEMPLATE, AV40FilterOrderDesc, AV41InvoiceState) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV23UserName, AV24OrderedBy, AV32FromInvoiceCreatedDate, AV33ToInvoiceCreatedDate, AV14ADVANCED_LABEL_TEMPLATE, AV40FilterOrderDesc, AV41InvoiceState) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV23UserName, AV24OrderedBy, AV32FromInvoiceCreatedDate, AV33ToInvoiceCreatedDate, AV14ADVANCED_LABEL_TEMPLATE, AV40FilterOrderDesc, AV41InvoiceState) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV23UserName, AV24OrderedBy, AV32FromInvoiceCreatedDate, AV33ToInvoiceCreatedDate, AV14ADVANCED_LABEL_TEMPLATE, AV40FilterOrderDesc, AV41InvoiceState) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void subgrid_varsfromstate( )
      {
         if ( GridState.FilterCount >= 1 )
         {
            AV23UserName = GridState.FilterValues("Username");
            AssignAttri("", false, "AV23UserName", AV23UserName);
            AV32FromInvoiceCreatedDate = context.localUtil.CToD( GridState.FilterValues("Frominvoicecreateddate"), 1);
            AssignAttri("", false, "AV32FromInvoiceCreatedDate", context.localUtil.Format(AV32FromInvoiceCreatedDate, "99/99/99"));
            AV33ToInvoiceCreatedDate = context.localUtil.CToD( GridState.FilterValues("Toinvoicecreateddate"), 1);
            AssignAttri("", false, "AV33ToInvoiceCreatedDate", context.localUtil.Format(AV33ToInvoiceCreatedDate, "99/99/99"));
         }
         if ( GridState.OrderedBy != 0 )
         {
            AV24OrderedBy = GridState.OrderedBy;
            AssignAttri("", false, "AV24OrderedBy", StringUtil.LTrimStr( (decimal)(AV24OrderedBy), 4, 0));
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
         GridState.OrderedBy = AV24OrderedBy;
         GridState.ClearFilterValues();
         GridState.AddFilterValue("UserName", AV23UserName);
         GridState.AddFilterValue("FromInvoiceCreatedDate", context.localUtil.Format(AV32FromInvoiceCreatedDate, "99/99/99"));
         GridState.AddFilterValue("ToInvoiceCreatedDate", context.localUtil.Format(AV33ToInvoiceCreatedDate, "99/99/99"));
      }

      protected void before_start_formulas( )
      {
         AV49Pgmname = "WWInvoice";
         context.Gx_err = 0;
         edtavState_Enabled = 0;
         AssignProp("", false, edtavState_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavState_Enabled), 5, 0), !bGXsfl_62_Refreshing);
         edtavDetails_Enabled = 0;
         AssignProp("", false, edtavDetails_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDetails_Enabled), 5, 0), !bGXsfl_62_Refreshing);
         edtavCancel_Enabled = 0;
         AssignProp("", false, edtavCancel_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCancel_Enabled), 5, 0), !bGXsfl_62_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP270( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E22272 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_62 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_62"), ".", ","), 18, MidpointRounding.ToEven));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            AV23UserName = cgiGet( edtavUsername_Internalname);
            AssignAttri("", false, "AV23UserName", AV23UserName);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavFilternro_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavFilternro_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vFILTERNRO");
               GX_FocusControl = edtavFilternro_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV43FilterNro = 0;
               AssignAttri("", false, "AV43FilterNro", StringUtil.LTrimStr( (decimal)(AV43FilterNro), 6, 0));
            }
            else
            {
               AV43FilterNro = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavFilternro_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV43FilterNro", StringUtil.LTrimStr( (decimal)(AV43FilterNro), 6, 0));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavFiltercreatedfrom_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Created From"}), 1, "vFILTERCREATEDFROM");
               GX_FocusControl = edtavFiltercreatedfrom_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV35FilterCreatedFrom = DateTime.MinValue;
               AssignAttri("", false, "AV35FilterCreatedFrom", context.localUtil.Format(AV35FilterCreatedFrom, "99/99/99"));
            }
            else
            {
               AV35FilterCreatedFrom = context.localUtil.CToD( cgiGet( edtavFiltercreatedfrom_Internalname), 1);
               AssignAttri("", false, "AV35FilterCreatedFrom", context.localUtil.Format(AV35FilterCreatedFrom, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavFiltercreatedto_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Created To"}), 1, "vFILTERCREATEDTO");
               GX_FocusControl = edtavFiltercreatedto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV36FilterCreatedTo = DateTime.MinValue;
               AssignAttri("", false, "AV36FilterCreatedTo", context.localUtil.Format(AV36FilterCreatedTo, "99/99/99"));
            }
            else
            {
               AV36FilterCreatedTo = context.localUtil.CToD( cgiGet( edtavFiltercreatedto_Internalname), 1);
               AssignAttri("", false, "AV36FilterCreatedTo", context.localUtil.Format(AV36FilterCreatedTo, "99/99/99"));
            }
            AV37FilterSeller = cgiGet( edtavFilterseller_Internalname);
            AssignAttri("", false, "AV37FilterSeller", AV37FilterSeller);
            cmbavFilterstate.Name = cmbavFilterstate_Internalname;
            cmbavFilterstate.CurrentValue = cgiGet( cmbavFilterstate_Internalname);
            AV38FilterState = cgiGet( cmbavFilterstate_Internalname);
            AssignAttri("", false, "AV38FilterState", AV38FilterState);
            cmbavFilterorder.Name = cmbavFilterorder_Internalname;
            cmbavFilterorder.CurrentValue = cgiGet( cmbavFilterorder_Internalname);
            AV39FilterOrder = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavFilterorder_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV39FilterOrder", StringUtil.LTrimStr( (decimal)(AV39FilterOrder), 4, 0));
            AV40FilterOrderDesc = StringUtil.StrToBool( cgiGet( chkavFilterorderdesc_Internalname));
            AssignAttri("", false, "AV40FilterOrderDesc", AV40FilterOrderDesc);
            cmbavOrderedby.Name = cmbavOrderedby_Internalname;
            cmbavOrderedby.CurrentValue = cgiGet( cmbavOrderedby_Internalname);
            AV24OrderedBy = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavOrderedby_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24OrderedBy", StringUtil.LTrimStr( (decimal)(AV24OrderedBy), 4, 0));
            if ( context.localUtil.VCDate( cgiGet( edtavFrominvoicecreateddate_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"From Invoice Created Date"}), 1, "vFROMINVOICECREATEDDATE");
               GX_FocusControl = edtavFrominvoicecreateddate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV32FromInvoiceCreatedDate = DateTime.MinValue;
               AssignAttri("", false, "AV32FromInvoiceCreatedDate", context.localUtil.Format(AV32FromInvoiceCreatedDate, "99/99/99"));
            }
            else
            {
               AV32FromInvoiceCreatedDate = context.localUtil.CToD( cgiGet( edtavFrominvoicecreateddate_Internalname), 1);
               AssignAttri("", false, "AV32FromInvoiceCreatedDate", context.localUtil.Format(AV32FromInvoiceCreatedDate, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavToinvoicecreateddate_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"To Invoice Created Date"}), 1, "vTOINVOICECREATEDDATE");
               GX_FocusControl = edtavToinvoicecreateddate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV33ToInvoiceCreatedDate = DateTime.MinValue;
               AssignAttri("", false, "AV33ToInvoiceCreatedDate", context.localUtil.Format(AV33ToInvoiceCreatedDate, "99/99/99"));
            }
            else
            {
               AV33ToInvoiceCreatedDate = context.localUtil.CToD( cgiGet( edtavToinvoicecreateddate_Internalname), 1);
               AssignAttri("", false, "AV33ToInvoiceCreatedDate", context.localUtil.Format(AV33ToInvoiceCreatedDate, "99/99/99"));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vUSERNAME"), AV23UserName) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDEREDBY"), ".", ",") != Convert.ToDecimal( AV24OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vFROMINVOICECREATEDDATE"), 1) ) != DateTimeUtil.ResetTime ( AV32FromInvoiceCreatedDate ) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vTOINVOICECREATEDDATE"), 1) ) != DateTimeUtil.ResetTime ( AV33ToInvoiceCreatedDate ) )
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
         E22272 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E22272( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtSDTContextSession1 = new GeneXus.Programs.general.ui.SdtSDTContextSession();
         new checkauthentication(context ).execute( out  GXt_SdtSDTContextSession1) ;
         if ( ! new haspermission(context).executeUdp(  "invoice view") )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV49Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV49Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV49Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         AV24OrderedBy = 1;
         AssignAttri("", false, "AV24OrderedBy", StringUtil.LTrimStr( (decimal)(AV24OrderedBy), 4, 0));
         edtavFrominvoicecreateddate_Visible = 0;
         AssignProp("", false, edtavFrominvoicecreateddate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavFrominvoicecreateddate_Visible), 5, 0), true);
         edtavToinvoicecreateddate_Visible = 0;
         AssignProp("", false, edtavToinvoicecreateddate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavToinvoicecreateddate_Visible), 5, 0), true);
         Form.Caption = "Invoices";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
         AssignAttri("", false, "AV14ADVANCED_LABEL_TEMPLATE", AV14ADVANCED_LABEL_TEMPLATE);
         GxWebStd.gx_hidden_field( context, "gxhash_vADVANCED_LABEL_TEMPLATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14ADVANCED_LABEL_TEMPLATE, "")), context));
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
         edtavFrominvoicecreateddate_Visible = 0;
         AssignProp("", false, edtavFrominvoicecreateddate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavFrominvoicecreateddate_Visible), 5, 0), true);
         edtavFrominvoicecreateddate_Enabled = 0;
         AssignProp("", false, edtavFrominvoicecreateddate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavFrominvoicecreateddate_Enabled), 5, 0), true);
         edtavToinvoicecreateddate_Visible = 0;
         AssignProp("", false, edtavToinvoicecreateddate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavToinvoicecreateddate_Visible), 5, 0), true);
         edtavToinvoicecreateddate_Enabled = 0;
         AssignProp("", false, edtavToinvoicecreateddate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavToinvoicecreateddate_Enabled), 5, 0), true);
         edtavUsername_Visible = 0;
         AssignProp("", false, edtavUsername_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUsername_Visible), 5, 0), true);
         edtavUsername_Enabled = 0;
         AssignProp("", false, edtavUsername_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsername_Enabled), 5, 0), true);
         cmbavOrderedby.Visible = 0;
         AssignProp("", false, cmbavOrderedby_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavOrderedby.Visible), 5, 0), true);
         cmbavOrderedby.Enabled = 0;
         AssignProp("", false, cmbavOrderedby_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavOrderedby.Enabled), 5, 0), true);
      }

      protected void E23272( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         GridState.SaveGridState();
         if ( (DateTime.MinValue==AV32FromInvoiceCreatedDate) )
         {
            lblLblfrominvoicecreateddatefilter_Caption = "Date From";
            AssignProp("", false, lblLblfrominvoicecreateddatefilter_Internalname, "Caption", lblLblfrominvoicecreateddatefilter_Caption, true);
         }
         else
         {
            lblLblfrominvoicecreateddatefilter_Caption = StringUtil.Format( AV14ADVANCED_LABEL_TEMPLATE, "Date From", context.localUtil.DToC( AV32FromInvoiceCreatedDate, 0, "-"), "", "", "", "", "", "", "");
            AssignProp("", false, lblLblfrominvoicecreateddatefilter_Internalname, "Caption", lblLblfrominvoicecreateddatefilter_Caption, true);
         }
         if ( (DateTime.MinValue==AV33ToInvoiceCreatedDate) )
         {
            lblLbltoinvoicecreateddatefilter_Caption = "Date To";
            AssignProp("", false, lblLbltoinvoicecreateddatefilter_Internalname, "Caption", lblLbltoinvoicecreateddatefilter_Caption, true);
         }
         else
         {
            lblLbltoinvoicecreateddatefilter_Caption = StringUtil.Format( AV14ADVANCED_LABEL_TEMPLATE, "Date To", context.localUtil.DToC( AV33ToInvoiceCreatedDate, 0, "-"), "", "", "", "", "", "", "");
            AssignProp("", false, lblLbltoinvoicecreateddatefilter_Internalname, "Caption", lblLbltoinvoicecreateddatefilter_Caption, true);
         }
         /*  Sending Event outputs  */
      }

      private void E24272( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         if ( A94InvoiceActive )
         {
            AV21State = "Confirmated";
            AssignAttri("", false, edtavState_Internalname, AV21State);
         }
         else
         {
            AV21State = "Canceled";
            AssignAttri("", false, edtavState_Internalname, AV21State);
         }
         AV22Details = "Details";
         AssignAttri("", false, edtavDetails_Internalname, AV22Details);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 62;
         }
         sendrow_622( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_62_Refreshing )
         {
            DoAjaxLoad(62, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV49Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "Invoice";
         AV6Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      protected void E14272( )
      {
         /* 'DoExport' Routine */
         returnInSub = false;
         new exportwwinvoice(context ).execute(  AV44InvoiceId,  AV41InvoiceState,  AV23UserName,  AV32FromInvoiceCreatedDate,  AV33ToInvoiceCreatedDate,  AV24OrderedBy, out  AV19ExcelFilename, out  AV20ErrorMessage) ;
         if ( StringUtil.StrCmp(AV19ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV19ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV20ErrorMessage);
         }
      }

      protected void E15272( )
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
         cmbavOrderedby.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24OrderedBy), 4, 0));
         AssignProp("", false, cmbavOrderedby_Internalname, "Values", cmbavOrderedby.ToJavascriptSource(), true);
      }

      protected void E16272( )
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
         cmbavOrderedby.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24OrderedBy), 4, 0));
         AssignProp("", false, cmbavOrderedby_Internalname, "Values", cmbavOrderedby.ToJavascriptSource(), true);
      }

      protected void E17272( )
      {
         /* Filterseller_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'UPDVARIABLES' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavOrderedby.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24OrderedBy), 4, 0));
         AssignProp("", false, cmbavOrderedby_Internalname, "Values", cmbavOrderedby.ToJavascriptSource(), true);
      }

      protected void E18272( )
      {
         /* Filtercreatedfrom_Controlvaluechanged Routine */
         returnInSub = false;
         if ( ( ! (DateTime.MinValue==AV36FilterCreatedTo) ) && ( ( DateTimeUtil.ResetTime ( AV35FilterCreatedFrom ) <= DateTimeUtil.ResetTime ( AV36FilterCreatedTo ) ) ) )
         {
            /* Execute user subroutine: 'UPDVARIABLES' */
            S122 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else
         {
            if ( ! (DateTime.MinValue==AV36FilterCreatedTo) )
            {
               AV35FilterCreatedFrom = AV36FilterCreatedTo;
               AssignAttri("", false, "AV35FilterCreatedFrom", context.localUtil.Format(AV35FilterCreatedFrom, "99/99/99"));
            }
            else
            {
               /* Execute user subroutine: 'UPDVARIABLES' */
               S122 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
            }
         }
         /*  Sending Event outputs  */
         cmbavOrderedby.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24OrderedBy), 4, 0));
         AssignProp("", false, cmbavOrderedby_Internalname, "Values", cmbavOrderedby.ToJavascriptSource(), true);
      }

      protected void E19272( )
      {
         /* Filtercreatedto_Controlvaluechanged Routine */
         returnInSub = false;
         if ( ( ! (DateTime.MinValue==AV35FilterCreatedFrom) ) && ( ( DateTimeUtil.ResetTime ( AV35FilterCreatedFrom ) <= DateTimeUtil.ResetTime ( AV36FilterCreatedTo ) ) ) )
         {
            /* Execute user subroutine: 'UPDVARIABLES' */
            S122 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else
         {
            if ( ! (DateTime.MinValue==AV35FilterCreatedFrom) )
            {
               AV36FilterCreatedTo = AV35FilterCreatedFrom;
               AssignAttri("", false, "AV36FilterCreatedTo", context.localUtil.Format(AV36FilterCreatedTo, "99/99/99"));
            }
            else
            {
               /* Execute user subroutine: 'UPDVARIABLES' */
               S122 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
            }
         }
         /*  Sending Event outputs  */
         cmbavOrderedby.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24OrderedBy), 4, 0));
         AssignProp("", false, cmbavOrderedby_Internalname, "Values", cmbavOrderedby.ToJavascriptSource(), true);
      }

      protected void E20272( )
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
         cmbavOrderedby.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24OrderedBy), 4, 0));
         AssignProp("", false, cmbavOrderedby_Internalname, "Values", cmbavOrderedby.ToJavascriptSource(), true);
      }

      protected void E21272( )
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
         cmbavOrderedby.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24OrderedBy), 4, 0));
         AssignProp("", false, cmbavOrderedby_Internalname, "Values", cmbavOrderedby.ToJavascriptSource(), true);
      }

      protected void S122( )
      {
         /* 'UPDVARIABLES' Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38FilterState)) )
         {
            AV42InvoiceStateValue = AV38FilterState;
            AssignAttri("", false, "AV42InvoiceStateValue", AV42InvoiceStateValue);
         }
         else
         {
            AV42InvoiceStateValue = "";
            AssignAttri("", false, "AV42InvoiceStateValue", AV42InvoiceStateValue);
         }
         if ( ! (DateTime.MinValue==AV35FilterCreatedFrom) )
         {
            AV32FromInvoiceCreatedDate = context.localUtil.CToD( context.localUtil.DToC( AV35FilterCreatedFrom, 1, "/"), 1);
            AssignAttri("", false, "AV32FromInvoiceCreatedDate", context.localUtil.Format(AV32FromInvoiceCreatedDate, "99/99/99"));
         }
         else
         {
            AV32FromInvoiceCreatedDate = DateTime.MinValue;
            AssignAttri("", false, "AV32FromInvoiceCreatedDate", context.localUtil.Format(AV32FromInvoiceCreatedDate, "99/99/99"));
         }
         if ( ! (DateTime.MinValue==AV36FilterCreatedTo) )
         {
            AV33ToInvoiceCreatedDate = context.localUtil.CToD( context.localUtil.DToC( AV36FilterCreatedTo, 1, "/"), 1);
            AssignAttri("", false, "AV33ToInvoiceCreatedDate", context.localUtil.Format(AV33ToInvoiceCreatedDate, "99/99/99"));
         }
         else
         {
            AV33ToInvoiceCreatedDate = DateTime.MinValue;
            AssignAttri("", false, "AV33ToInvoiceCreatedDate", context.localUtil.Format(AV33ToInvoiceCreatedDate, "99/99/99"));
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37FilterSeller)) )
         {
            AV23UserName = AV37FilterSeller;
            AssignAttri("", false, "AV23UserName", AV23UserName);
         }
         else
         {
            AV23UserName = "";
            AssignAttri("", false, "AV23UserName", AV23UserName);
         }
         if ( ! (0==AV43FilterNro) )
         {
            AV44InvoiceId = AV43FilterNro;
            AssignAttri("", false, "AV44InvoiceId", StringUtil.LTrimStr( (decimal)(AV44InvoiceId), 6, 0));
         }
         else
         {
            AV44InvoiceId = 0;
            AssignAttri("", false, "AV44InvoiceId", StringUtil.LTrimStr( (decimal)(AV44InvoiceId), 6, 0));
         }
         if ( AV39FilterOrder == 1 )
         {
            if ( ! AV40FilterOrderDesc )
            {
               AV24OrderedBy = 1;
               AssignAttri("", false, "AV24OrderedBy", StringUtil.LTrimStr( (decimal)(AV24OrderedBy), 4, 0));
            }
            else
            {
               AV24OrderedBy = 2;
               AssignAttri("", false, "AV24OrderedBy", StringUtil.LTrimStr( (decimal)(AV24OrderedBy), 4, 0));
            }
         }
         else if ( AV39FilterOrder == 2 )
         {
            if ( ! AV40FilterOrderDesc )
            {
               AV24OrderedBy = 3;
               AssignAttri("", false, "AV24OrderedBy", StringUtil.LTrimStr( (decimal)(AV24OrderedBy), 4, 0));
            }
            else
            {
               AV24OrderedBy = 4;
               AssignAttri("", false, "AV24OrderedBy", StringUtil.LTrimStr( (decimal)(AV24OrderedBy), 4, 0));
            }
         }
         else if ( AV39FilterOrder == 3 )
         {
            if ( ! AV40FilterOrderDesc )
            {
               AV24OrderedBy = 5;
               AssignAttri("", false, "AV24OrderedBy", StringUtil.LTrimStr( (decimal)(AV24OrderedBy), 4, 0));
            }
            else
            {
               AV24OrderedBy = 6;
               AssignAttri("", false, "AV24OrderedBy", StringUtil.LTrimStr( (decimal)(AV24OrderedBy), 4, 0));
            }
         }
         subgrid_firstpage( ) ;
         gxgrGrid_refresh( subGrid_Rows, AV23UserName, AV24OrderedBy, AV32FromInvoiceCreatedDate, AV33ToInvoiceCreatedDate, AV14ADVANCED_LABEL_TEMPLATE, AV40FilterOrderDesc, AV41InvoiceState) ;
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
         PA272( ) ;
         WS272( ) ;
         WE272( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20241261111731", true, true);
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
         context.AddJavascriptSource("wwinvoice.js", "?20241261111731", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_622( )
      {
         edtInvoiceId_Internalname = "INVOICEID_"+sGXsfl_62_idx;
         edtInvoiceCreatedDate_Internalname = "INVOICECREATEDDATE_"+sGXsfl_62_idx;
         edtInvoiceTotalReceivable_Internalname = "INVOICETOTALRECEIVABLE_"+sGXsfl_62_idx;
         edtUserName_Internalname = "USERNAME_"+sGXsfl_62_idx;
         edtavState_Internalname = "vSTATE_"+sGXsfl_62_idx;
         edtavDetails_Internalname = "vDETAILS_"+sGXsfl_62_idx;
         edtavCancel_Internalname = "vCANCEL_"+sGXsfl_62_idx;
      }

      protected void SubsflControlProps_fel_622( )
      {
         edtInvoiceId_Internalname = "INVOICEID_"+sGXsfl_62_fel_idx;
         edtInvoiceCreatedDate_Internalname = "INVOICECREATEDDATE_"+sGXsfl_62_fel_idx;
         edtInvoiceTotalReceivable_Internalname = "INVOICETOTALRECEIVABLE_"+sGXsfl_62_fel_idx;
         edtUserName_Internalname = "USERNAME_"+sGXsfl_62_fel_idx;
         edtavState_Internalname = "vSTATE_"+sGXsfl_62_fel_idx;
         edtavDetails_Internalname = "vDETAILS_"+sGXsfl_62_fel_idx;
         edtavCancel_Internalname = "vCANCEL_"+sGXsfl_62_fel_idx;
      }

      protected void sendrow_622( )
      {
         SubsflControlProps_622( ) ;
         WB270( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_62_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_62_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_62_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInvoiceId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A20InvoiceId), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A20InvoiceId), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInvoiceId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)62,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInvoiceCreatedDate_Internalname,context.localUtil.Format(A38InvoiceCreatedDate, "99/99/99"),context.localUtil.Format( A38InvoiceCreatedDate, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInvoiceCreatedDate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)62,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInvoiceTotalReceivable_Internalname,StringUtil.LTrim( StringUtil.NToC( A80InvoiceTotalReceivable, 18, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A80InvoiceTotalReceivable, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInvoiceTotalReceivable_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)62,(short)0,(short)-1,(short)0,(bool)true,(string)"Price",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUserName_Internalname,(string)A100UserName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUserName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)62,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavState_Enabled!=0)&&(edtavState_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 67,'',false,'"+sGXsfl_62_idx+"',62)\"" : " ");
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavState_Internalname,(string)AV21State,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavState_Enabled!=0)&&(edtavState_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,67);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavState_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column WWOptionalColumn",(string)"",(short)-1,(int)edtavState_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)62,(short)0,(short)-1,(short)-1,(bool)true,(string)"InvoiceState",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavDetails_Enabled!=0)&&(edtavDetails_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 68,'',false,'"+sGXsfl_62_idx+"',62)\"" : " ");
            ROClassString = "TextActionAttribute TextLikeLink";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDetails_Internalname,(string)AV22Details,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavDetails_Enabled!=0)&&(edtavDetails_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,68);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+"e25272_client"+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDetails_Jsonclick,(short)7,(string)"TextActionAttribute TextLikeLink",(string)"",(string)ROClassString,(string)"WWTextActionColumn",(string)"",(short)-1,(int)edtavDetails_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)62,(short)0,(short)-1,(short)-1,(bool)true,(string)"InvoiceDetailsLink",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavCancel_Enabled!=0)&&(edtavCancel_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 69,'',false,'"+sGXsfl_62_idx+"',62)\"" : " ");
            ROClassString = "TextActionAttribute TextLikeLink";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCancel_Internalname,(string)AV45Cancel,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavCancel_Enabled!=0)&&(edtavCancel_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,69);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCancel_Jsonclick,(short)0,(string)"TextActionAttribute TextLikeLink",(string)"",(string)ROClassString,(string)"WWTextActionColumn",(string)"",(short)0,(int)edtavCancel_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)62,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes272( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_62_idx = ((subGrid_Islastpage==1)&&(nGXsfl_62_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_62_idx+1);
            sGXsfl_62_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_62_idx), 4, 0), 4, "0");
            SubsflControlProps_622( ) ;
         }
         /* End function sendrow_622 */
      }

      protected void init_web_controls( )
      {
         cmbavFilterstate.Name = "vFILTERSTATE";
         cmbavFilterstate.WebTags = "";
         cmbavFilterstate.addItem("", "(None)", 0);
         cmbavFilterstate.addItem("Confirmated", "Confirmated", 0);
         cmbavFilterstate.addItem("Canceled", "Canceled", 0);
         if ( cmbavFilterstate.ItemCount > 0 )
         {
            AV38FilterState = cmbavFilterstate.getValidValue(AV38FilterState);
            AssignAttri("", false, "AV38FilterState", AV38FilterState);
         }
         cmbavFilterorder.Name = "vFILTERORDER";
         cmbavFilterorder.WebTags = "";
         cmbavFilterorder.addItem("1", "Created Date", 0);
         cmbavFilterorder.addItem("2", "Seller", 0);
         cmbavFilterorder.addItem("3", "Received", 0);
         if ( cmbavFilterorder.ItemCount > 0 )
         {
            AV39FilterOrder = (short)(Math.Round(NumberUtil.Val( cmbavFilterorder.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV39FilterOrder), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV39FilterOrder", StringUtil.LTrimStr( (decimal)(AV39FilterOrder), 4, 0));
         }
         chkavFilterorderdesc.Name = "vFILTERORDERDESC";
         chkavFilterorderdesc.WebTags = "";
         chkavFilterorderdesc.Caption = "";
         AssignProp("", false, chkavFilterorderdesc_Internalname, "TitleCaption", chkavFilterorderdesc.Caption, true);
         chkavFilterorderdesc.CheckedValue = "false";
         AV40FilterOrderDesc = StringUtil.StrToBool( StringUtil.BoolToStr( AV40FilterOrderDesc));
         AssignAttri("", false, "AV40FilterOrderDesc", AV40FilterOrderDesc);
         cmbavOrderedby.Name = "vORDEREDBY";
         cmbavOrderedby.WebTags = "";
         cmbavOrderedby.addItem("1", "Created Date Asc", 0);
         cmbavOrderedby.addItem("2", "Created Date Desc", 0);
         cmbavOrderedby.addItem("3", "Seller Name Asc", 0);
         cmbavOrderedby.addItem("4", "Seller Name Desc", 0);
         cmbavOrderedby.addItem("5", "Total Receivable Asc", 0);
         cmbavOrderedby.addItem("6", "Total Receivable Desc", 0);
         if ( cmbavOrderedby.ItemCount > 0 )
         {
            AV24OrderedBy = (short)(Math.Round(NumberUtil.Val( cmbavOrderedby.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV24OrderedBy), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV24OrderedBy", StringUtil.LTrimStr( (decimal)(AV24OrderedBy), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl62( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"62\">") ;
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
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Created Date") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Total Receivable") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Seller") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "State") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"TextActionAttribute TextLikeLink"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"TextActionAttribute TextLikeLink"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
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
            GridContainer.AddObjectProperty("Class", "ww__grid");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A20InvoiceId), 6, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A38InvoiceCreatedDate, "99/99/99")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A80InvoiceTotalReceivable, 18, 2, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A100UserName));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV21State));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavState_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV22Details));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDetails_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV45Cancel));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCancel_Enabled), 5, 0, ".", "")));
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
         edtavUsername_Internalname = "vUSERNAME";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         divTabletop_Internalname = "TABLETOP";
         edtavFilternro_Internalname = "vFILTERNRO";
         edtavFiltercreatedfrom_Internalname = "vFILTERCREATEDFROM";
         edtavFiltercreatedto_Internalname = "vFILTERCREATEDTO";
         edtavFilterseller_Internalname = "vFILTERSELLER";
         cmbavFilterstate_Internalname = "vFILTERSTATE";
         cmbavFilterorder_Internalname = "vFILTERORDER";
         chkavFilterorderdesc_Internalname = "vFILTERORDERDESC";
         divTable1_Internalname = "TABLE1";
         edtInvoiceId_Internalname = "INVOICEID";
         edtInvoiceCreatedDate_Internalname = "INVOICECREATEDDATE";
         edtInvoiceTotalReceivable_Internalname = "INVOICETOTALRECEIVABLE";
         edtUserName_Internalname = "USERNAME";
         edtavState_Internalname = "vSTATE";
         edtavDetails_Internalname = "vDETAILS";
         edtavCancel_Internalname = "vCANCEL";
         divGridcontainer_Internalname = "GRIDCONTAINER";
         divGridtable_Internalname = "GRIDTABLE";
         divGridcell_Internalname = "GRIDCELL";
         bttBtntoggleontable_Internalname = "BTNTOGGLEONTABLE";
         cmbavOrderedby_Internalname = "vORDEREDBY";
         lblLblfrominvoicecreateddatefilter_Internalname = "LBLFROMINVOICECREATEDDATEFILTER";
         edtavFrominvoicecreateddate_Internalname = "vFROMINVOICECREATEDDATE";
         divFrominvoicecreateddatefiltercontainer_Internalname = "FROMINVOICECREATEDDATEFILTERCONTAINER";
         lblLbltoinvoicecreateddatefilter_Internalname = "LBLTOINVOICECREATEDDATEFILTER";
         edtavToinvoicecreateddate_Internalname = "vTOINVOICECREATEDDATE";
         divToinvoicecreateddatefiltercontainer_Internalname = "TOINVOICECREATEDDATEFILTERCONTAINER";
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
         chkavFilterorderdesc.Caption = "Order Desc";
         edtavCancel_Jsonclick = "";
         edtavCancel_Visible = 0;
         edtavCancel_Enabled = 1;
         edtavDetails_Jsonclick = "";
         edtavDetails_Visible = -1;
         edtavDetails_Enabled = 1;
         edtavState_Jsonclick = "";
         edtavState_Visible = -1;
         edtavState_Enabled = 1;
         edtUserName_Jsonclick = "";
         edtInvoiceTotalReceivable_Jsonclick = "";
         edtInvoiceCreatedDate_Jsonclick = "";
         edtInvoiceId_Jsonclick = "";
         subGrid_Class = "ww__grid";
         subGrid_Backcolorstyle = 0;
         edtavToinvoicecreateddate_Jsonclick = "";
         edtavToinvoicecreateddate_Enabled = 1;
         edtavToinvoicecreateddate_Visible = 1;
         lblLbltoinvoicecreateddatefilter_Caption = "Date To";
         edtavFrominvoicecreateddate_Jsonclick = "";
         edtavFrominvoicecreateddate_Enabled = 1;
         edtavFrominvoicecreateddate_Visible = 1;
         lblLblfrominvoicecreateddatefilter_Caption = "Date From";
         cmbavOrderedby_Jsonclick = "";
         cmbavOrderedby.Enabled = 1;
         cmbavOrderedby.Visible = 1;
         chkavFilterorderdesc.Enabled = 1;
         cmbavFilterorder_Jsonclick = "";
         cmbavFilterorder.Enabled = 1;
         cmbavFilterstate_Jsonclick = "";
         cmbavFilterstate.Enabled = 1;
         edtavFilterseller_Jsonclick = "";
         edtavFilterseller_Enabled = 1;
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
         edtavUsername_Jsonclick = "";
         edtavUsername_Enabled = 1;
         edtavUsername_Visible = 1;
         divGridcell_Class = "col-xs-12 col-sm-9 col-md-10 ww__grid-cell--expanded";
         divToinvoicecreateddatefiltercontainer_Class = "filters-container__item";
         divFrominvoicecreateddatefiltercontainer_Class = "filters-container__item";
         divFilterscontainer_Class = "filters-container";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Work With Invoice";
         subGrid_Rows = 6;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV23UserName',fld:'vUSERNAME',pic:''},{av:'cmbavOrderedby'},{av:'AV24OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV32FromInvoiceCreatedDate',fld:'vFROMINVOICECREATEDDATE',pic:''},{av:'AV33ToInvoiceCreatedDate',fld:'vTOINVOICECREATEDDATE',pic:''},{av:'AV40FilterOrderDesc',fld:'vFILTERORDERDESC',pic:''},{av:'AV14ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV41InvoiceState',fld:'vINVOICESTATE',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'lblLblfrominvoicecreateddatefilter_Caption',ctrl:'LBLFROMINVOICECREATEDDATEFILTER',prop:'Caption'},{av:'lblLbltoinvoicecreateddatefilter_Caption',ctrl:'LBLTOINVOICECREATEDDATEFILTER',prop:'Caption'}]}");
         setEventMetadata("'TOGGLE'","{handler:'E11271',iparms:[{av:'divFilterscontainer_Class',ctrl:'FILTERSCONTAINER',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divFilterscontainer_Class',ctrl:'FILTERSCONTAINER',prop:'Class'},{av:'divGridcell_Class',ctrl:'GRIDCELL',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Caption'},{ctrl:'BTNTOGGLE',prop:'Tooltiptext'}]}");
         setEventMetadata("LBLFROMINVOICECREATEDDATEFILTER.CLICK","{handler:'E12271',iparms:[{av:'divFrominvoicecreateddatefiltercontainer_Class',ctrl:'FROMINVOICECREATEDDATEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLFROMINVOICECREATEDDATEFILTER.CLICK",",oparms:[{av:'divFrominvoicecreateddatefiltercontainer_Class',ctrl:'FROMINVOICECREATEDDATEFILTERCONTAINER',prop:'Class'},{av:'edtavFrominvoicecreateddate_Visible',ctrl:'vFROMINVOICECREATEDDATE',prop:'Visible'}]}");
         setEventMetadata("LBLTOINVOICECREATEDDATEFILTER.CLICK","{handler:'E13271',iparms:[{av:'divToinvoicecreateddatefiltercontainer_Class',ctrl:'TOINVOICECREATEDDATEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLTOINVOICECREATEDDATEFILTER.CLICK",",oparms:[{av:'divToinvoicecreateddatefiltercontainer_Class',ctrl:'TOINVOICECREATEDDATEFILTERCONTAINER',prop:'Class'},{av:'edtavToinvoicecreateddate_Visible',ctrl:'vTOINVOICECREATEDDATE',prop:'Visible'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E24272',iparms:[{av:'A94InvoiceActive',fld:'INVOICEACTIVE',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'AV21State',fld:'vSTATE',pic:''},{av:'AV22Details',fld:'vDETAILS',pic:''}]}");
         setEventMetadata("'DOEXPORT'","{handler:'E14272',iparms:[{av:'AV44InvoiceId',fld:'vINVOICEID',pic:'ZZZZZ9'},{av:'AV41InvoiceState',fld:'vINVOICESTATE',pic:'',hsh:true},{av:'AV23UserName',fld:'vUSERNAME',pic:''},{av:'AV32FromInvoiceCreatedDate',fld:'vFROMINVOICECREATEDDATE',pic:''},{av:'AV33ToInvoiceCreatedDate',fld:'vTOINVOICECREATEDDATE',pic:''},{av:'cmbavOrderedby'},{av:'AV24OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'}]");
         setEventMetadata("'DOEXPORT'",",oparms:[]}");
         setEventMetadata("VDETAILS.CLICK","{handler:'E25272',iparms:[{av:'A20InvoiceId',fld:'INVOICEID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("VDETAILS.CLICK",",oparms:[]}");
         setEventMetadata("VFILTERNRO.CONTROLVALUECHANGED","{handler:'E15272',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV23UserName',fld:'vUSERNAME',pic:''},{av:'cmbavOrderedby'},{av:'AV24OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV32FromInvoiceCreatedDate',fld:'vFROMINVOICECREATEDDATE',pic:''},{av:'AV33ToInvoiceCreatedDate',fld:'vTOINVOICECREATEDDATE',pic:''},{av:'AV14ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV40FilterOrderDesc',fld:'vFILTERORDERDESC',pic:''},{av:'AV41InvoiceState',fld:'vINVOICESTATE',pic:'',hsh:true},{av:'cmbavFilterstate'},{av:'AV38FilterState',fld:'vFILTERSTATE',pic:''},{av:'AV35FilterCreatedFrom',fld:'vFILTERCREATEDFROM',pic:''},{av:'AV36FilterCreatedTo',fld:'vFILTERCREATEDTO',pic:''},{av:'AV37FilterSeller',fld:'vFILTERSELLER',pic:''},{av:'AV43FilterNro',fld:'vFILTERNRO',pic:'ZZZZZ9'},{av:'cmbavFilterorder'},{av:'AV39FilterOrder',fld:'vFILTERORDER',pic:'ZZZ9'}]");
         setEventMetadata("VFILTERNRO.CONTROLVALUECHANGED",",oparms:[{av:'AV42InvoiceStateValue',fld:'vINVOICESTATEVALUE',pic:''},{av:'AV32FromInvoiceCreatedDate',fld:'vFROMINVOICECREATEDDATE',pic:''},{av:'AV33ToInvoiceCreatedDate',fld:'vTOINVOICECREATEDDATE',pic:''},{av:'AV23UserName',fld:'vUSERNAME',pic:''},{av:'AV44InvoiceId',fld:'vINVOICEID',pic:'ZZZZZ9'},{av:'cmbavOrderedby'},{av:'AV24OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'lblLblfrominvoicecreateddatefilter_Caption',ctrl:'LBLFROMINVOICECREATEDDATEFILTER',prop:'Caption'},{av:'lblLbltoinvoicecreateddatefilter_Caption',ctrl:'LBLTOINVOICECREATEDDATEFILTER',prop:'Caption'}]}");
         setEventMetadata("VFILTERSTATE.CONTROLVALUECHANGED","{handler:'E16272',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV23UserName',fld:'vUSERNAME',pic:''},{av:'cmbavOrderedby'},{av:'AV24OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV32FromInvoiceCreatedDate',fld:'vFROMINVOICECREATEDDATE',pic:''},{av:'AV33ToInvoiceCreatedDate',fld:'vTOINVOICECREATEDDATE',pic:''},{av:'AV14ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV40FilterOrderDesc',fld:'vFILTERORDERDESC',pic:''},{av:'AV41InvoiceState',fld:'vINVOICESTATE',pic:'',hsh:true},{av:'cmbavFilterstate'},{av:'AV38FilterState',fld:'vFILTERSTATE',pic:''},{av:'AV35FilterCreatedFrom',fld:'vFILTERCREATEDFROM',pic:''},{av:'AV36FilterCreatedTo',fld:'vFILTERCREATEDTO',pic:''},{av:'AV37FilterSeller',fld:'vFILTERSELLER',pic:''},{av:'AV43FilterNro',fld:'vFILTERNRO',pic:'ZZZZZ9'},{av:'cmbavFilterorder'},{av:'AV39FilterOrder',fld:'vFILTERORDER',pic:'ZZZ9'}]");
         setEventMetadata("VFILTERSTATE.CONTROLVALUECHANGED",",oparms:[{av:'AV42InvoiceStateValue',fld:'vINVOICESTATEVALUE',pic:''},{av:'AV32FromInvoiceCreatedDate',fld:'vFROMINVOICECREATEDDATE',pic:''},{av:'AV33ToInvoiceCreatedDate',fld:'vTOINVOICECREATEDDATE',pic:''},{av:'AV23UserName',fld:'vUSERNAME',pic:''},{av:'AV44InvoiceId',fld:'vINVOICEID',pic:'ZZZZZ9'},{av:'cmbavOrderedby'},{av:'AV24OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'lblLblfrominvoicecreateddatefilter_Caption',ctrl:'LBLFROMINVOICECREATEDDATEFILTER',prop:'Caption'},{av:'lblLbltoinvoicecreateddatefilter_Caption',ctrl:'LBLTOINVOICECREATEDDATEFILTER',prop:'Caption'}]}");
         setEventMetadata("VFILTERSELLER.CONTROLVALUECHANGED","{handler:'E17272',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV23UserName',fld:'vUSERNAME',pic:''},{av:'cmbavOrderedby'},{av:'AV24OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV32FromInvoiceCreatedDate',fld:'vFROMINVOICECREATEDDATE',pic:''},{av:'AV33ToInvoiceCreatedDate',fld:'vTOINVOICECREATEDDATE',pic:''},{av:'AV14ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV40FilterOrderDesc',fld:'vFILTERORDERDESC',pic:''},{av:'AV41InvoiceState',fld:'vINVOICESTATE',pic:'',hsh:true},{av:'cmbavFilterstate'},{av:'AV38FilterState',fld:'vFILTERSTATE',pic:''},{av:'AV35FilterCreatedFrom',fld:'vFILTERCREATEDFROM',pic:''},{av:'AV36FilterCreatedTo',fld:'vFILTERCREATEDTO',pic:''},{av:'AV37FilterSeller',fld:'vFILTERSELLER',pic:''},{av:'AV43FilterNro',fld:'vFILTERNRO',pic:'ZZZZZ9'},{av:'cmbavFilterorder'},{av:'AV39FilterOrder',fld:'vFILTERORDER',pic:'ZZZ9'}]");
         setEventMetadata("VFILTERSELLER.CONTROLVALUECHANGED",",oparms:[{av:'AV42InvoiceStateValue',fld:'vINVOICESTATEVALUE',pic:''},{av:'AV32FromInvoiceCreatedDate',fld:'vFROMINVOICECREATEDDATE',pic:''},{av:'AV33ToInvoiceCreatedDate',fld:'vTOINVOICECREATEDDATE',pic:''},{av:'AV23UserName',fld:'vUSERNAME',pic:''},{av:'AV44InvoiceId',fld:'vINVOICEID',pic:'ZZZZZ9'},{av:'cmbavOrderedby'},{av:'AV24OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'lblLblfrominvoicecreateddatefilter_Caption',ctrl:'LBLFROMINVOICECREATEDDATEFILTER',prop:'Caption'},{av:'lblLbltoinvoicecreateddatefilter_Caption',ctrl:'LBLTOINVOICECREATEDDATEFILTER',prop:'Caption'}]}");
         setEventMetadata("VFILTERCREATEDFROM.CONTROLVALUECHANGED","{handler:'E18272',iparms:[{av:'AV35FilterCreatedFrom',fld:'vFILTERCREATEDFROM',pic:''},{av:'AV36FilterCreatedTo',fld:'vFILTERCREATEDTO',pic:''},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV23UserName',fld:'vUSERNAME',pic:''},{av:'cmbavOrderedby'},{av:'AV24OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV32FromInvoiceCreatedDate',fld:'vFROMINVOICECREATEDDATE',pic:''},{av:'AV33ToInvoiceCreatedDate',fld:'vTOINVOICECREATEDDATE',pic:''},{av:'AV14ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV40FilterOrderDesc',fld:'vFILTERORDERDESC',pic:''},{av:'AV41InvoiceState',fld:'vINVOICESTATE',pic:'',hsh:true},{av:'cmbavFilterstate'},{av:'AV38FilterState',fld:'vFILTERSTATE',pic:''},{av:'AV37FilterSeller',fld:'vFILTERSELLER',pic:''},{av:'AV43FilterNro',fld:'vFILTERNRO',pic:'ZZZZZ9'},{av:'cmbavFilterorder'},{av:'AV39FilterOrder',fld:'vFILTERORDER',pic:'ZZZ9'}]");
         setEventMetadata("VFILTERCREATEDFROM.CONTROLVALUECHANGED",",oparms:[{av:'AV35FilterCreatedFrom',fld:'vFILTERCREATEDFROM',pic:''},{av:'AV42InvoiceStateValue',fld:'vINVOICESTATEVALUE',pic:''},{av:'AV32FromInvoiceCreatedDate',fld:'vFROMINVOICECREATEDDATE',pic:''},{av:'AV33ToInvoiceCreatedDate',fld:'vTOINVOICECREATEDDATE',pic:''},{av:'AV23UserName',fld:'vUSERNAME',pic:''},{av:'AV44InvoiceId',fld:'vINVOICEID',pic:'ZZZZZ9'},{av:'cmbavOrderedby'},{av:'AV24OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'lblLblfrominvoicecreateddatefilter_Caption',ctrl:'LBLFROMINVOICECREATEDDATEFILTER',prop:'Caption'},{av:'lblLbltoinvoicecreateddatefilter_Caption',ctrl:'LBLTOINVOICECREATEDDATEFILTER',prop:'Caption'}]}");
         setEventMetadata("VFILTERCREATEDTO.CONTROLVALUECHANGED","{handler:'E19272',iparms:[{av:'AV35FilterCreatedFrom',fld:'vFILTERCREATEDFROM',pic:''},{av:'AV36FilterCreatedTo',fld:'vFILTERCREATEDTO',pic:''},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV23UserName',fld:'vUSERNAME',pic:''},{av:'cmbavOrderedby'},{av:'AV24OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV32FromInvoiceCreatedDate',fld:'vFROMINVOICECREATEDDATE',pic:''},{av:'AV33ToInvoiceCreatedDate',fld:'vTOINVOICECREATEDDATE',pic:''},{av:'AV14ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV40FilterOrderDesc',fld:'vFILTERORDERDESC',pic:''},{av:'AV41InvoiceState',fld:'vINVOICESTATE',pic:'',hsh:true},{av:'cmbavFilterstate'},{av:'AV38FilterState',fld:'vFILTERSTATE',pic:''},{av:'AV37FilterSeller',fld:'vFILTERSELLER',pic:''},{av:'AV43FilterNro',fld:'vFILTERNRO',pic:'ZZZZZ9'},{av:'cmbavFilterorder'},{av:'AV39FilterOrder',fld:'vFILTERORDER',pic:'ZZZ9'}]");
         setEventMetadata("VFILTERCREATEDTO.CONTROLVALUECHANGED",",oparms:[{av:'AV36FilterCreatedTo',fld:'vFILTERCREATEDTO',pic:''},{av:'AV42InvoiceStateValue',fld:'vINVOICESTATEVALUE',pic:''},{av:'AV32FromInvoiceCreatedDate',fld:'vFROMINVOICECREATEDDATE',pic:''},{av:'AV33ToInvoiceCreatedDate',fld:'vTOINVOICECREATEDDATE',pic:''},{av:'AV23UserName',fld:'vUSERNAME',pic:''},{av:'AV44InvoiceId',fld:'vINVOICEID',pic:'ZZZZZ9'},{av:'cmbavOrderedby'},{av:'AV24OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'lblLblfrominvoicecreateddatefilter_Caption',ctrl:'LBLFROMINVOICECREATEDDATEFILTER',prop:'Caption'},{av:'lblLbltoinvoicecreateddatefilter_Caption',ctrl:'LBLTOINVOICECREATEDDATEFILTER',prop:'Caption'}]}");
         setEventMetadata("VFILTERORDER.CONTROLVALUECHANGED","{handler:'E20272',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV23UserName',fld:'vUSERNAME',pic:''},{av:'cmbavOrderedby'},{av:'AV24OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV32FromInvoiceCreatedDate',fld:'vFROMINVOICECREATEDDATE',pic:''},{av:'AV33ToInvoiceCreatedDate',fld:'vTOINVOICECREATEDDATE',pic:''},{av:'AV14ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV40FilterOrderDesc',fld:'vFILTERORDERDESC',pic:''},{av:'AV41InvoiceState',fld:'vINVOICESTATE',pic:'',hsh:true},{av:'cmbavFilterstate'},{av:'AV38FilterState',fld:'vFILTERSTATE',pic:''},{av:'AV35FilterCreatedFrom',fld:'vFILTERCREATEDFROM',pic:''},{av:'AV36FilterCreatedTo',fld:'vFILTERCREATEDTO',pic:''},{av:'AV37FilterSeller',fld:'vFILTERSELLER',pic:''},{av:'AV43FilterNro',fld:'vFILTERNRO',pic:'ZZZZZ9'},{av:'cmbavFilterorder'},{av:'AV39FilterOrder',fld:'vFILTERORDER',pic:'ZZZ9'}]");
         setEventMetadata("VFILTERORDER.CONTROLVALUECHANGED",",oparms:[{av:'AV42InvoiceStateValue',fld:'vINVOICESTATEVALUE',pic:''},{av:'AV32FromInvoiceCreatedDate',fld:'vFROMINVOICECREATEDDATE',pic:''},{av:'AV33ToInvoiceCreatedDate',fld:'vTOINVOICECREATEDDATE',pic:''},{av:'AV23UserName',fld:'vUSERNAME',pic:''},{av:'AV44InvoiceId',fld:'vINVOICEID',pic:'ZZZZZ9'},{av:'cmbavOrderedby'},{av:'AV24OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'lblLblfrominvoicecreateddatefilter_Caption',ctrl:'LBLFROMINVOICECREATEDDATEFILTER',prop:'Caption'},{av:'lblLbltoinvoicecreateddatefilter_Caption',ctrl:'LBLTOINVOICECREATEDDATEFILTER',prop:'Caption'}]}");
         setEventMetadata("VFILTERORDERDESC.CONTROLVALUECHANGED","{handler:'E21272',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV23UserName',fld:'vUSERNAME',pic:''},{av:'cmbavOrderedby'},{av:'AV24OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV32FromInvoiceCreatedDate',fld:'vFROMINVOICECREATEDDATE',pic:''},{av:'AV33ToInvoiceCreatedDate',fld:'vTOINVOICECREATEDDATE',pic:''},{av:'AV14ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV40FilterOrderDesc',fld:'vFILTERORDERDESC',pic:''},{av:'AV41InvoiceState',fld:'vINVOICESTATE',pic:'',hsh:true},{av:'cmbavFilterstate'},{av:'AV38FilterState',fld:'vFILTERSTATE',pic:''},{av:'AV35FilterCreatedFrom',fld:'vFILTERCREATEDFROM',pic:''},{av:'AV36FilterCreatedTo',fld:'vFILTERCREATEDTO',pic:''},{av:'AV37FilterSeller',fld:'vFILTERSELLER',pic:''},{av:'AV43FilterNro',fld:'vFILTERNRO',pic:'ZZZZZ9'},{av:'cmbavFilterorder'},{av:'AV39FilterOrder',fld:'vFILTERORDER',pic:'ZZZ9'}]");
         setEventMetadata("VFILTERORDERDESC.CONTROLVALUECHANGED",",oparms:[{av:'AV42InvoiceStateValue',fld:'vINVOICESTATEVALUE',pic:''},{av:'AV32FromInvoiceCreatedDate',fld:'vFROMINVOICECREATEDDATE',pic:''},{av:'AV33ToInvoiceCreatedDate',fld:'vTOINVOICECREATEDDATE',pic:''},{av:'AV23UserName',fld:'vUSERNAME',pic:''},{av:'AV44InvoiceId',fld:'vINVOICEID',pic:'ZZZZZ9'},{av:'cmbavOrderedby'},{av:'AV24OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'lblLblfrominvoicecreateddatefilter_Caption',ctrl:'LBLFROMINVOICECREATEDDATEFILTER',prop:'Caption'},{av:'lblLbltoinvoicecreateddatefilter_Caption',ctrl:'LBLTOINVOICECREATEDDATEFILTER',prop:'Caption'}]}");
         setEventMetadata("GRID_FIRSTPAGE","{handler:'subgrid_firstpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV23UserName',fld:'vUSERNAME',pic:''},{av:'cmbavOrderedby'},{av:'AV24OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV41InvoiceState',fld:'vINVOICESTATE',pic:'',hsh:true},{av:'AV32FromInvoiceCreatedDate',fld:'vFROMINVOICECREATEDDATE',pic:''},{av:'AV14ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV33ToInvoiceCreatedDate',fld:'vTOINVOICECREATEDDATE',pic:''},{av:'AV40FilterOrderDesc',fld:'vFILTERORDERDESC',pic:''}]");
         setEventMetadata("GRID_FIRSTPAGE",",oparms:[{av:'lblLblfrominvoicecreateddatefilter_Caption',ctrl:'LBLFROMINVOICECREATEDDATEFILTER',prop:'Caption'},{av:'lblLbltoinvoicecreateddatefilter_Caption',ctrl:'LBLTOINVOICECREATEDDATEFILTER',prop:'Caption'}]}");
         setEventMetadata("GRID_PREVPAGE","{handler:'subgrid_previouspage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV23UserName',fld:'vUSERNAME',pic:''},{av:'cmbavOrderedby'},{av:'AV24OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV41InvoiceState',fld:'vINVOICESTATE',pic:'',hsh:true},{av:'AV32FromInvoiceCreatedDate',fld:'vFROMINVOICECREATEDDATE',pic:''},{av:'AV14ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV33ToInvoiceCreatedDate',fld:'vTOINVOICECREATEDDATE',pic:''},{av:'AV40FilterOrderDesc',fld:'vFILTERORDERDESC',pic:''}]");
         setEventMetadata("GRID_PREVPAGE",",oparms:[{av:'lblLblfrominvoicecreateddatefilter_Caption',ctrl:'LBLFROMINVOICECREATEDDATEFILTER',prop:'Caption'},{av:'lblLbltoinvoicecreateddatefilter_Caption',ctrl:'LBLTOINVOICECREATEDDATEFILTER',prop:'Caption'}]}");
         setEventMetadata("GRID_NEXTPAGE","{handler:'subgrid_nextpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV23UserName',fld:'vUSERNAME',pic:''},{av:'cmbavOrderedby'},{av:'AV24OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV41InvoiceState',fld:'vINVOICESTATE',pic:'',hsh:true},{av:'AV32FromInvoiceCreatedDate',fld:'vFROMINVOICECREATEDDATE',pic:''},{av:'AV14ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV33ToInvoiceCreatedDate',fld:'vTOINVOICECREATEDDATE',pic:''},{av:'AV40FilterOrderDesc',fld:'vFILTERORDERDESC',pic:''}]");
         setEventMetadata("GRID_NEXTPAGE",",oparms:[{av:'lblLblfrominvoicecreateddatefilter_Caption',ctrl:'LBLFROMINVOICECREATEDDATEFILTER',prop:'Caption'},{av:'lblLbltoinvoicecreateddatefilter_Caption',ctrl:'LBLTOINVOICECREATEDDATEFILTER',prop:'Caption'}]}");
         setEventMetadata("GRID_LASTPAGE","{handler:'subgrid_lastpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV23UserName',fld:'vUSERNAME',pic:''},{av:'cmbavOrderedby'},{av:'AV24OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV41InvoiceState',fld:'vINVOICESTATE',pic:'',hsh:true},{av:'AV32FromInvoiceCreatedDate',fld:'vFROMINVOICECREATEDDATE',pic:''},{av:'AV14ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true},{av:'AV33ToInvoiceCreatedDate',fld:'vTOINVOICECREATEDDATE',pic:''},{av:'AV40FilterOrderDesc',fld:'vFILTERORDERDESC',pic:''}]");
         setEventMetadata("GRID_LASTPAGE",",oparms:[{av:'lblLblfrominvoicecreateddatefilter_Caption',ctrl:'LBLFROMINVOICECREATEDDATEFILTER',prop:'Caption'},{av:'lblLbltoinvoicecreateddatefilter_Caption',ctrl:'LBLTOINVOICECREATEDDATEFILTER',prop:'Caption'}]}");
         setEventMetadata("VALIDV_FILTERCREATEDFROM","{handler:'Validv_Filtercreatedfrom',iparms:[]");
         setEventMetadata("VALIDV_FILTERCREATEDFROM",",oparms:[]}");
         setEventMetadata("VALIDV_FILTERCREATEDTO","{handler:'Validv_Filtercreatedto',iparms:[]");
         setEventMetadata("VALIDV_FILTERCREATEDTO",",oparms:[]}");
         setEventMetadata("VALIDV_FILTERSTATE","{handler:'Validv_Filterstate',iparms:[]");
         setEventMetadata("VALIDV_FILTERSTATE",",oparms:[]}");
         setEventMetadata("VALIDV_FROMINVOICECREATEDDATE","{handler:'Validv_Frominvoicecreateddate',iparms:[]");
         setEventMetadata("VALIDV_FROMINVOICECREATEDDATE",",oparms:[]}");
         setEventMetadata("VALIDV_TOINVOICECREATEDDATE","{handler:'Validv_Toinvoicecreateddate',iparms:[]");
         setEventMetadata("VALIDV_TOINVOICECREATEDDATE",",oparms:[]}");
         setEventMetadata("VALID_INVOICEID","{handler:'Valid_Invoiceid',iparms:[]");
         setEventMetadata("VALID_INVOICEID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Cancel',iparms:[]");
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
         AV23UserName = "";
         AV32FromInvoiceCreatedDate = DateTime.MinValue;
         AV33ToInvoiceCreatedDate = DateTime.MinValue;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         AV41InvoiceState = "";
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
         AV35FilterCreatedFrom = DateTime.MinValue;
         AV36FilterCreatedTo = DateTime.MinValue;
         AV37FilterSeller = "";
         AV38FilterState = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         bttBtntoggleontable_Jsonclick = "";
         lblLblfrominvoicecreateddatefilter_Jsonclick = "";
         lblLbltoinvoicecreateddatefilter_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A38InvoiceCreatedDate = DateTime.MinValue;
         A100UserName = "";
         AV21State = "";
         AV22Details = "";
         AV45Cancel = "";
         AV49Pgmname = "";
         GridState = new GXGridStateHandler(context,"Grid",GetPgmname(),subgrid_varsfromstate,subgrid_varstostate);
         scmdbuf = "";
         lV23UserName = "";
         AV42InvoiceStateValue = "";
         H00275_A99UserId = new int[1] ;
         H00275_A94InvoiceActive = new bool[] {false} ;
         H00275_A100UserName = new string[] {""} ;
         H00275_A38InvoiceCreatedDate = new DateTime[] {DateTime.MinValue} ;
         H00275_A20InvoiceId = new int[1] ;
         H00275_A80InvoiceTotalReceivable = new decimal[1] ;
         H00275_n80InvoiceTotalReceivable = new bool[] {false} ;
         H00279_AGRID_nRecordCount = new long[1] ;
         GXt_SdtSDTContextSession1 = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         GridRow = new GXWebRow();
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV7HTTPRequest = new GxHttpRequest( context);
         AV6Session = context.GetSession();
         AV19ExcelFilename = "";
         AV20ErrorMessage = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwinvoice__default(),
            new Object[][] {
                new Object[] {
               H00275_A99UserId, H00275_A94InvoiceActive, H00275_A100UserName, H00275_A38InvoiceCreatedDate, H00275_A20InvoiceId, H00275_A80InvoiceTotalReceivable, H00275_n80InvoiceTotalReceivable
               }
               , new Object[] {
               H00279_AGRID_nRecordCount
               }
            }
         );
         AV49Pgmname = "WWInvoice";
         /* GeneXus formulas. */
         AV49Pgmname = "WWInvoice";
         context.Gx_err = 0;
         edtavState_Enabled = 0;
         edtavDetails_Enabled = 0;
         edtavCancel_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV24OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV39FilterOrder ;
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
      private int nRC_GXsfl_62 ;
      private int subGrid_Rows ;
      private int nGXsfl_62_idx=1 ;
      private int AV44InvoiceId ;
      private int edtavUsername_Visible ;
      private int edtavUsername_Enabled ;
      private int bttBtntoggle_Visible ;
      private int bttBtntoggle_Enabled ;
      private int AV43FilterNro ;
      private int edtavFilternro_Enabled ;
      private int edtavFiltercreatedfrom_Enabled ;
      private int edtavFiltercreatedto_Enabled ;
      private int edtavFilterseller_Enabled ;
      private int edtavFrominvoicecreateddate_Visible ;
      private int edtavFrominvoicecreateddate_Enabled ;
      private int edtavToinvoicecreateddate_Visible ;
      private int edtavToinvoicecreateddate_Enabled ;
      private int A20InvoiceId ;
      private int subGrid_Islastpage ;
      private int edtavState_Enabled ;
      private int edtavDetails_Enabled ;
      private int edtavCancel_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A99UserId ;
      private int GridPageCount ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int edtavState_Visible ;
      private int edtavDetails_Visible ;
      private int edtavCancel_Visible ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal A80InvoiceTotalReceivable ;
      private string divFilterscontainer_Class ;
      private string divFrominvoicecreateddatefiltercontainer_Class ;
      private string divToinvoicecreateddatefiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_62_idx="0001" ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
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
      private string edtavUsername_Internalname ;
      private string edtavUsername_Jsonclick ;
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
      private string edtavFilterseller_Internalname ;
      private string edtavFilterseller_Jsonclick ;
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
      private string divFrominvoicecreateddatefiltercontainer_Internalname ;
      private string lblLblfrominvoicecreateddatefilter_Internalname ;
      private string lblLblfrominvoicecreateddatefilter_Caption ;
      private string lblLblfrominvoicecreateddatefilter_Jsonclick ;
      private string edtavFrominvoicecreateddate_Internalname ;
      private string edtavFrominvoicecreateddate_Jsonclick ;
      private string divToinvoicecreateddatefiltercontainer_Internalname ;
      private string lblLbltoinvoicecreateddatefilter_Internalname ;
      private string lblLbltoinvoicecreateddatefilter_Caption ;
      private string lblLbltoinvoicecreateddatefilter_Jsonclick ;
      private string edtavToinvoicecreateddate_Internalname ;
      private string edtavToinvoicecreateddate_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtInvoiceId_Internalname ;
      private string edtInvoiceCreatedDate_Internalname ;
      private string edtInvoiceTotalReceivable_Internalname ;
      private string edtUserName_Internalname ;
      private string edtavState_Internalname ;
      private string edtavDetails_Internalname ;
      private string edtavCancel_Internalname ;
      private string AV49Pgmname ;
      private string scmdbuf ;
      private string sGXsfl_62_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtInvoiceId_Jsonclick ;
      private string edtInvoiceCreatedDate_Jsonclick ;
      private string edtInvoiceTotalReceivable_Jsonclick ;
      private string edtUserName_Jsonclick ;
      private string edtavState_Jsonclick ;
      private string edtavDetails_Jsonclick ;
      private string edtavCancel_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV32FromInvoiceCreatedDate ;
      private DateTime AV33ToInvoiceCreatedDate ;
      private DateTime AV35FilterCreatedFrom ;
      private DateTime AV36FilterCreatedTo ;
      private DateTime A38InvoiceCreatedDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV40FilterOrderDesc ;
      private bool A94InvoiceActive ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n80InvoiceTotalReceivable ;
      private bool bGXsfl_62_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV23UserName ;
      private string AV41InvoiceState ;
      private string AV37FilterSeller ;
      private string AV38FilterState ;
      private string A100UserName ;
      private string AV21State ;
      private string AV22Details ;
      private string AV45Cancel ;
      private string lV23UserName ;
      private string AV42InvoiceStateValue ;
      private string AV19ExcelFilename ;
      private string AV20ErrorMessage ;
      private GXWebGrid GridContainer ;
      private GXGridStateHandler GridState ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavFilterstate ;
      private GXCombobox cmbavFilterorder ;
      private GXCheckbox chkavFilterorderdesc ;
      private GXCombobox cmbavOrderedby ;
      private IDataStoreProvider pr_default ;
      private int[] H00275_A99UserId ;
      private bool[] H00275_A94InvoiceActive ;
      private string[] H00275_A100UserName ;
      private DateTime[] H00275_A38InvoiceCreatedDate ;
      private int[] H00275_A20InvoiceId ;
      private decimal[] H00275_A80InvoiceTotalReceivable ;
      private bool[] H00275_n80InvoiceTotalReceivable ;
      private long[] H00279_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV7HTTPRequest ;
      private IGxSession AV6Session ;
      private GXWebForm Form ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession GXt_SdtSDTContextSession1 ;
   }

   public class wwinvoice__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00275( IGxContext context ,
                                             string AV23UserName ,
                                             DateTime AV32FromInvoiceCreatedDate ,
                                             DateTime AV33ToInvoiceCreatedDate ,
                                             string AV42InvoiceStateValue ,
                                             int AV44InvoiceId ,
                                             string A100UserName ,
                                             DateTime A38InvoiceCreatedDate ,
                                             bool A94InvoiceActive ,
                                             int A20InvoiceId ,
                                             short AV24OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[7];
         Object[] GXv_Object3 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[UserId], T1.[InvoiceActive], T2.[UserName], T1.[InvoiceCreatedDate], T1.[InvoiceId], COALESCE( T3.[InvoiceTotalReceivable], 0) AS InvoiceTotalReceivable";
         sFromString = " FROM (([Invoice] T1 INNER JOIN [User] T2 ON T2.[UserId] = T1.[UserId]) INNER JOIN (SELECT COALESCE( T6.[GXC1], 0) - COALESCE( T5.[GXC2], 0) + COALESCE( T5.[GXC3], 0) AS InvoiceTotalReceivable, T4.[InvoiceId] FROM (([Invoice] T4 LEFT JOIN (SELECT SUM([InvoicePaymentMethodDiscountIm]) AS GXC2, [InvoiceId], SUM([InvoicePaymentMethodRechargeIm]) AS GXC3 FROM [InvoicePaymentMethod] GROUP BY [InvoiceId] ) T5 ON T5.[InvoiceId] = T4.[InvoiceId]) LEFT JOIN (SELECT SUM([InvoiceDetailQuantity] * CAST([InvoiceDetailHistoricPrice] AS decimal( 28, 10))) AS GXC1, [InvoiceId] FROM [InvoiceDetail] GROUP BY [InvoiceId] ) T6 ON T6.[InvoiceId] = T4.[InvoiceId]) ) T3 ON T3.[InvoiceId] = T1.[InvoiceId])";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23UserName)) )
         {
            AddWhere(sWhereString, "(T2.[UserName] like '%' + @lV23UserName + '%')");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV32FromInvoiceCreatedDate) )
         {
            AddWhere(sWhereString, "(T1.[InvoiceCreatedDate] >= @AV32FromInvoiceCreatedDate)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV33ToInvoiceCreatedDate) )
         {
            AddWhere(sWhereString, "(T1.[InvoiceCreatedDate] <= @AV33ToInvoiceCreatedDate)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42InvoiceStateValue)) && ( StringUtil.StrCmp(AV42InvoiceStateValue, "Confirmated") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[InvoiceActive] = 1)");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42InvoiceStateValue)) && ( StringUtil.StrCmp(AV42InvoiceStateValue, "Canceled") == 0 ) )
         {
            AddWhere(sWhereString, "(Not T1.[InvoiceActive] = 1)");
         }
         if ( ! (0==AV44InvoiceId) )
         {
            AddWhere(sWhereString, "(T1.[InvoiceId] = @AV44InvoiceId)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV24OrderedBy == 1 )
         {
            sOrderString += " ORDER BY T1.[InvoiceCreatedDate]";
         }
         else if ( AV24OrderedBy == 2 )
         {
            sOrderString += " ORDER BY T1.[InvoiceCreatedDate] DESC";
         }
         else if ( AV24OrderedBy == 3 )
         {
            sOrderString += " ORDER BY T2.[UserName]";
         }
         else if ( AV24OrderedBy == 4 )
         {
            sOrderString += " ORDER BY T2.[UserName] DESC";
         }
         else if ( AV24OrderedBy == 5 )
         {
            sOrderString += " ORDER BY [InvoiceTotalReceivable]";
         }
         else if ( AV24OrderedBy == 6 )
         {
            sOrderString += " ORDER BY [InvoiceTotalReceivable] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.[InvoiceId]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_H00279( IGxContext context ,
                                             string AV23UserName ,
                                             DateTime AV32FromInvoiceCreatedDate ,
                                             DateTime AV33ToInvoiceCreatedDate ,
                                             string AV42InvoiceStateValue ,
                                             int AV44InvoiceId ,
                                             string A100UserName ,
                                             DateTime A38InvoiceCreatedDate ,
                                             bool A94InvoiceActive ,
                                             int A20InvoiceId ,
                                             short AV24OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[4];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (([Invoice] T1 INNER JOIN [User] T2 ON T2.[UserId] = T1.[UserId]) INNER JOIN (SELECT COALESCE( T6.[GXC1], 0) - COALESCE( T5.[GXC2], 0) + COALESCE( T5.[GXC3], 0) AS InvoiceTotalReceivable, T4.[InvoiceId] FROM (([Invoice] T4 LEFT JOIN (SELECT SUM([InvoicePaymentMethodDiscountIm]) AS GXC2, [InvoiceId], SUM([InvoicePaymentMethodRechargeIm]) AS GXC3 FROM [InvoicePaymentMethod] GROUP BY [InvoiceId] ) T5 ON T5.[InvoiceId] = T4.[InvoiceId]) LEFT JOIN (SELECT SUM([InvoiceDetailQuantity] * CAST([InvoiceDetailHistoricPrice] AS decimal( 28, 10))) AS GXC1, [InvoiceId] FROM [InvoiceDetail] GROUP BY [InvoiceId] ) T6 ON T6.[InvoiceId] = T4.[InvoiceId]) ) T3 ON T3.[InvoiceId] = T1.[InvoiceId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23UserName)) )
         {
            AddWhere(sWhereString, "(T2.[UserName] like '%' + @lV23UserName + '%')");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV32FromInvoiceCreatedDate) )
         {
            AddWhere(sWhereString, "(T1.[InvoiceCreatedDate] >= @AV32FromInvoiceCreatedDate)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV33ToInvoiceCreatedDate) )
         {
            AddWhere(sWhereString, "(T1.[InvoiceCreatedDate] <= @AV33ToInvoiceCreatedDate)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42InvoiceStateValue)) && ( StringUtil.StrCmp(AV42InvoiceStateValue, "Confirmated") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[InvoiceActive] = 1)");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42InvoiceStateValue)) && ( StringUtil.StrCmp(AV42InvoiceStateValue, "Canceled") == 0 ) )
         {
            AddWhere(sWhereString, "(Not T1.[InvoiceActive] = 1)");
         }
         if ( ! (0==AV44InvoiceId) )
         {
            AddWhere(sWhereString, "(T1.[InvoiceId] = @AV44InvoiceId)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV24OrderedBy == 1 )
         {
            scmdbuf += "";
         }
         else if ( AV24OrderedBy == 2 )
         {
            scmdbuf += "";
         }
         else if ( AV24OrderedBy == 3 )
         {
            scmdbuf += "";
         }
         else if ( AV24OrderedBy == 4 )
         {
            scmdbuf += "";
         }
         else if ( AV24OrderedBy == 5 )
         {
            scmdbuf += "";
         }
         else if ( AV24OrderedBy == 6 )
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
               case 0 :
                     return conditional_H00275(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (bool)dynConstraints[7] , (int)dynConstraints[8] , (short)dynConstraints[9] );
               case 1 :
                     return conditional_H00279(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (bool)dynConstraints[7] , (int)dynConstraints[8] , (short)dynConstraints[9] );
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
          Object[] prmH00275;
          prmH00275 = new Object[] {
          new ParDef("@lV23UserName",GXType.NVarChar,20,0) ,
          new ParDef("@AV32FromInvoiceCreatedDate",GXType.Date,8,0) ,
          new ParDef("@AV33ToInvoiceCreatedDate",GXType.Date,8,0) ,
          new ParDef("@AV44InvoiceId",GXType.Int32,6,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00279;
          prmH00279 = new Object[] {
          new ParDef("@lV23UserName",GXType.NVarChar,20,0) ,
          new ParDef("@AV32FromInvoiceCreatedDate",GXType.Date,8,0) ,
          new ParDef("@AV33ToInvoiceCreatedDate",GXType.Date,8,0) ,
          new ParDef("@AV44InvoiceId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00275", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00275,7, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00279", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00279,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
