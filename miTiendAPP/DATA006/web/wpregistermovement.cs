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
   public class wpregistermovement : GXDataArea
   {
      public wpregistermovement( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public wpregistermovement( IGxContext context )
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridinvoice") == 0 )
            {
               gxnrGridinvoice_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridinvoice") == 0 )
            {
               gxgrGridinvoice_refresh_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridinvoicedetails") == 0 )
            {
               gxnrGridinvoicedetails_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridinvoicedetails") == 0 )
            {
               gxgrGridinvoicedetails_refresh_invoke( ) ;
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

      protected void gxnrGridinvoice_newrow_invoke( )
      {
         nRC_GXsfl_25 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_25"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_25_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_25_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_25_idx = GetPar( "sGXsfl_25_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridinvoice_newrow( ) ;
         /* End function gxnrGridinvoice_newrow_invoke */
      }

      protected void gxgrGridinvoice_refresh_invoke( )
      {
         subGridinvoice_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridinvoice_Rows"), "."), 18, MidpointRounding.ToEven));
         AV31FilterNro = (int)(Math.Round(NumberUtil.Val( GetPar( "FilterNro"), "."), 18, MidpointRounding.ToEven));
         AV33FilterCreatedDateFrom = context.localUtil.ParseDateParm( GetPar( "FilterCreatedDateFrom"));
         AV34FilterCreatedDateTo = context.localUtil.ParseDateParm( GetPar( "FilterCreatedDateTo"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridinvoice_refresh( subGridinvoice_Rows, AV31FilterNro, AV33FilterCreatedDateFrom, AV34FilterCreatedDateTo) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridinvoice_refresh_invoke */
      }

      protected void gxnrGridinvoicedetails_newrow_invoke( )
      {
         nRC_GXsfl_53 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_53"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_53_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_53_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_53_idx = GetPar( "sGXsfl_53_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridinvoicedetails_newrow( ) ;
         /* End function gxnrGridinvoicedetails_newrow_invoke */
      }

      protected void gxgrGridinvoicedetails_refresh_invoke( )
      {
         subGridinvoice_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridinvoice_Rows"), "."), 18, MidpointRounding.ToEven));
         AV31FilterNro = (int)(Math.Round(NumberUtil.Val( GetPar( "FilterNro"), "."), 18, MidpointRounding.ToEven));
         AV33FilterCreatedDateFrom = context.localUtil.ParseDateParm( GetPar( "FilterCreatedDateFrom"));
         AV34FilterCreatedDateTo = context.localUtil.ParseDateParm( GetPar( "FilterCreatedDateTo"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridinvoicedetails_refresh( subGridinvoice_Rows, AV31FilterNro, AV33FilterCreatedDateFrom, AV34FilterCreatedDateTo) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridinvoicedetails_refresh_invoke */
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
         PA4K2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START4K2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpregistermovement.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERNRO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31FilterNro), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERCREATEDDATEFROM", context.localUtil.Format(AV33FilterCreatedDateFrom, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERCREATEDDATETO", context.localUtil.Format(AV34FilterCreatedDateTo, "99/99/99"));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Sdtcarproducts", AV15SDTCarProducts);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Sdtcarproducts", AV15SDTCarProducts);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_25", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_25), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_53", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_53), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINVOICEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30InvoiceId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTCODE", A55ProductCode);
         GxWebStd.gx_hidden_field( context, "PRODUCTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTNAME", A16ProductName);
         GxWebStd.gx_hidden_field( context, "INVOICEDETAILQUANTITY", StringUtil.LTrim( StringUtil.NToC( (decimal)(A26InvoiceDetailQuantity), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "INVOICEDETAILHISTORICPRICE", StringUtil.LTrim( StringUtil.NToC( A65InvoiceDetailHistoricPrice, 18, 2, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vCONTROLINVOICECANCEL", AV20ControlInvoiceCancel);
         GxWebStd.gx_boolean_hidden_field( context, "vALLOK", AV6AllOk);
         GxWebStd.gx_hidden_field( context, "vERRORMESSAGE", AV7ErrorMessage);
         GxWebStd.gx_hidden_field( context, "GRIDINVOICE_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDINVOICE_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDINVOICE_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDINVOICE_nEOF), 1, 0, ".", "")));
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
            WE4K2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT4K2( ) ;
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
         return formatLink("wpregistermovement.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WPRegisterMovement" ;
      }

      public override string GetPgmdesc( )
      {
         return "Cancel Sale" ;
      }

      protected void WB4K0( )
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
            GxWebStd.gx_div_start( context, divTablefilters_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavFilternro_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilternro_Internalname, "Nro", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 11,'',false,'" + sGXsfl_25_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilternro_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31FilterNro), 6, 0, ".", "")), StringUtil.LTrim( ((edtavFilternro_Enabled!=0) ? context.localUtil.Format( (decimal)(AV31FilterNro), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV31FilterNro), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,11);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFilternro_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilternro_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_WPRegisterMovement.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavFiltercreateddatefrom_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFiltercreateddatefrom_Internalname, "Created From", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 15,'',false,'" + sGXsfl_25_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFiltercreateddatefrom_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFiltercreateddatefrom_Internalname, context.localUtil.Format(AV33FilterCreatedDateFrom, "99/99/99"), context.localUtil.Format( AV33FilterCreatedDateFrom, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,15);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFiltercreateddatefrom_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFiltercreateddatefrom_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_WPRegisterMovement.htm");
            GxWebStd.gx_bitmap( context, edtavFiltercreateddatefrom_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavFiltercreateddatefrom_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WPRegisterMovement.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavFiltercreateddateto_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFiltercreateddateto_Internalname, "Created To", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'" + sGXsfl_25_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFiltercreateddateto_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFiltercreateddateto_Internalname, context.localUtil.Format(AV34FilterCreatedDateTo, "99/99/99"), context.localUtil.Format( AV34FilterCreatedDateTo, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,19);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFiltercreateddateto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFiltercreateddateto_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_WPRegisterMovement.htm");
            GxWebStd.gx_bitmap( context, edtavFiltercreateddateto_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavFiltercreateddateto_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WPRegisterMovement.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            GxWebStd.gx_div_start( context, divTableinvoices_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridinvoiceContainer.SetWrapped(nGXWrapped);
            StartGridControl25( ) ;
         }
         if ( wbEnd == 25 )
         {
            wbEnd = 0;
            nRC_GXsfl_25 = (int)(nGXsfl_25_idx-1);
            if ( GridinvoiceContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridinvoiceContainer.AddObjectProperty("GRIDINVOICE_nEOF", GRIDINVOICE_nEOF);
               GridinvoiceContainer.AddObjectProperty("GRIDINVOICE_nFirstRecordOnPage", GRIDINVOICE_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridinvoiceContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridinvoice", GridinvoiceContainer, subGridinvoice_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridinvoiceContainerData", GridinvoiceContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridinvoiceContainerData"+"V", GridinvoiceContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridinvoiceContainerData"+"V"+"\" value='"+GridinvoiceContainer.GridValuesHidden()+"'/>") ;
               }
            }
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
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, divTablecontent_Visible, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablebuttons_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttConfirmregister_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(25), 2, 0)+","+"null"+");", "Confirm", bttConfirmregister_Jsonclick, 5, "Confirm", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CONFIRMREGISTER\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPRegisterMovement.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(25), 2, 0)+","+"null"+");", "Cancel", bttCancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPRegisterMovement.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavMovementdescription_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMovementdescription_Internalname, "Reason", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'" + sGXsfl_25_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavMovementdescription_Internalname, AV19MovementDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", 0, 1, edtavMovementdescription_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WPRegisterMovement.htm");
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
            GxWebStd.gx_div_start( context, divTableinvoicedetails_Internalname, divTableinvoicedetails_Visible, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridinvoicedetailsContainer.SetWrapped(nGXWrapped);
            StartGridControl53( ) ;
         }
         if ( wbEnd == 53 )
         {
            wbEnd = 0;
            nRC_GXsfl_53 = (int)(nGXsfl_53_idx-1);
            if ( GridinvoicedetailsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV37GXV1 = nGXsfl_53_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridinvoicedetailsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridinvoicedetails", GridinvoicedetailsContainer, subGridinvoicedetails_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridinvoicedetailsContainerData", GridinvoicedetailsContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridinvoicedetailsContainerData"+"V", GridinvoicedetailsContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridinvoicedetailsContainerData"+"V"+"\" value='"+GridinvoicedetailsContainer.GridValuesHidden()+"'/>") ;
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
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 25 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridinvoiceContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  GridinvoiceContainer.AddObjectProperty("GRIDINVOICE_nEOF", GRIDINVOICE_nEOF);
                  GridinvoiceContainer.AddObjectProperty("GRIDINVOICE_nFirstRecordOnPage", GRIDINVOICE_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridinvoiceContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridinvoice", GridinvoiceContainer, subGridinvoice_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridinvoiceContainerData", GridinvoiceContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridinvoiceContainerData"+"V", GridinvoiceContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridinvoiceContainerData"+"V"+"\" value='"+GridinvoiceContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         if ( wbEnd == 53 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridinvoicedetailsContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV37GXV1 = nGXsfl_53_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridinvoicedetailsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridinvoicedetails", GridinvoicedetailsContainer, subGridinvoicedetails_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridinvoicedetailsContainerData", GridinvoicedetailsContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridinvoicedetailsContainerData"+"V", GridinvoicedetailsContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridinvoicedetailsContainerData"+"V"+"\" value='"+GridinvoicedetailsContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START4K2( )
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
            Form.Meta.addItem("description", "Cancel Sale", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP4K0( ) ;
      }

      protected void WS4K2( )
      {
         START4K2( ) ;
         EVT4K2( ) ;
      }

      protected void EVT4K2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "VFILTERNRO.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E114K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VFILTERCREATEDDATEFROM.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E124K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VFILTERCREATEDDATETO.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E134K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CONFIRMREGISTER'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'ConfirmRegister' */
                              E144K2 ();
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDINVOICEPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRIDINVOICEPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgridinvoice_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgridinvoice_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgridinvoice_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgridinvoice_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( StringUtil.StrCmp(StringUtil.Left( sEvt, 23), "GRIDINVOICEDETAILS.LOAD") == 0 )
                           {
                              nGXsfl_53_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
                              SubsflControlProps_535( ) ;
                              AV37GXV1 = nGXsfl_53_idx;
                              if ( ( AV15SDTCarProducts.Count >= AV37GXV1 ) && ( AV37GXV1 > 0 ) )
                              {
                                 AV15SDTCarProducts.CurrentItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV15SDTCarProducts.Item(AV37GXV1));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "GRIDINVOICEDETAILS.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E154K5 ();
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
                           else if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 16), "GRIDINVOICE.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 20), "VCANCELINVOICE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 8), "'CANCEL'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 20), "VCANCELINVOICE.CLICK") == 0 ) )
                           {
                              nGXsfl_25_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_25_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_25_idx), 4, 0), 4, "0");
                              SubsflControlProps_252( ) ;
                              AV28CancelInvoice = cgiGet( edtavCancelinvoice_Internalname);
                              AssignProp("", false, edtavCancelinvoice_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV28CancelInvoice)) ? AV44Cancelinvoice_GXI : context.convertURL( context.PathToRelativeUrl( AV28CancelInvoice))), !bGXsfl_25_Refreshing);
                              AssignProp("", false, edtavCancelinvoice_Internalname, "SrcSet", context.GetImageSrcSet( AV28CancelInvoice), true);
                              A20InvoiceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtInvoiceId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A38InvoiceCreatedDate = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtInvoiceCreatedDate_Internalname), 0));
                              A80InvoiceTotalReceivable = context.localUtil.CToN( cgiGet( edtInvoiceTotalReceivable_Internalname), ".", ",");
                              n80InvoiceTotalReceivable = false;
                              A100UserName = cgiGet( edtUserName_Internalname);
                              AV26Details = cgiGet( edtavDetails_Internalname);
                              AssignAttri("", false, edtavDetails_Internalname, AV26Details);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E164K2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDINVOICE.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E174K2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VCANCELINVOICE.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E184K2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'CANCEL'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'Cancel' */
                                    E194K2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Filternro Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vFILTERNRO"), ".", ",") != Convert.ToDecimal( AV31FilterNro )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Filtercreateddatefrom Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vFILTERCREATEDDATEFROM"), 0) != AV33FilterCreatedDateFrom )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Filtercreateddateto Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vFILTERCREATEDDATETO"), 0) != AV34FilterCreatedDateTo )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
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

      protected void WE4K2( )
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

      protected void PA4K2( )
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
               GX_FocusControl = edtavFilternro_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridinvoice_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_252( ) ;
         while ( nGXsfl_25_idx <= nRC_GXsfl_25 )
         {
            sendrow_252( ) ;
            nGXsfl_25_idx = ((subGridinvoice_Islastpage==1)&&(nGXsfl_25_idx+1>subGridinvoice_fnc_Recordsperpage( )) ? 1 : nGXsfl_25_idx+1);
            sGXsfl_25_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_25_idx), 4, 0), 4, "0");
            SubsflControlProps_252( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridinvoiceContainer)) ;
         /* End function gxnrGridinvoice_newrow */
      }

      protected void gxnrGridinvoicedetails_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_535( ) ;
         while ( nGXsfl_53_idx <= nRC_GXsfl_53 )
         {
            sendrow_535( ) ;
            nGXsfl_53_idx = ((subGridinvoicedetails_Islastpage==1)&&(nGXsfl_53_idx+1>subGridinvoicedetails_fnc_Recordsperpage( )) ? 1 : nGXsfl_53_idx+1);
            sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
            SubsflControlProps_535( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridinvoicedetailsContainer)) ;
         /* End function gxnrGridinvoicedetails_newrow */
      }

      protected void gxgrGridinvoice_refresh( int subGridinvoice_Rows ,
                                              int AV31FilterNro ,
                                              DateTime AV33FilterCreatedDateFrom ,
                                              DateTime AV34FilterCreatedDateTo )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDINVOICE_nCurrentRecord = 0;
         RF4K2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridinvoice_refresh */
      }

      protected void gxgrGridinvoicedetails_refresh( int subGridinvoice_Rows ,
                                                     int AV31FilterNro ,
                                                     DateTime AV33FilterCreatedDateFrom ,
                                                     DateTime AV34FilterCreatedDateTo )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDINVOICEDETAILS_nCurrentRecord = 0;
         RF4K5( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridinvoicedetails_refresh */
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF4K2( ) ;
         RF4K5( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavDetails_Enabled = 0;
         AssignProp("", false, edtavDetails_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDetails_Enabled), 5, 0), !bGXsfl_25_Refreshing);
         edtavCtlcode_Enabled = 0;
         AssignProp("", false, edtavCtlcode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcode_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         edtavCtlname_Enabled = 0;
         AssignProp("", false, edtavCtlname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         edtavCtlquantity_Enabled = 0;
         AssignProp("", false, edtavCtlquantity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlquantity_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         edtavCtlunitprice_Enabled = 0;
         AssignProp("", false, edtavCtlunitprice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlunitprice_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         edtavCtlsubtotal_Enabled = 0;
         AssignProp("", false, edtavCtlsubtotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsubtotal_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         edtavCtlwholesaleprice_Enabled = 0;
         AssignProp("", false, edtavCtlwholesaleprice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlwholesaleprice_Enabled), 5, 0), !bGXsfl_53_Refreshing);
      }

      protected void RF4K2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridinvoiceContainer.ClearRows();
         }
         wbStart = 25;
         nGXsfl_25_idx = 1;
         sGXsfl_25_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_25_idx), 4, 0), 4, "0");
         SubsflControlProps_252( ) ;
         bGXsfl_25_Refreshing = true;
         GridinvoiceContainer.AddObjectProperty("GridName", "Gridinvoice");
         GridinvoiceContainer.AddObjectProperty("CmpContext", "");
         GridinvoiceContainer.AddObjectProperty("InMasterPage", "false");
         GridinvoiceContainer.AddObjectProperty("Class", "PromptGrid");
         GridinvoiceContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridinvoiceContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridinvoiceContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoice_Backcolorstyle), 1, 0, ".", "")));
         GridinvoiceContainer.PageSize = subGridinvoice_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_252( ) ;
            GXPagingFrom2 = (int)(GRIDINVOICE_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGridinvoice_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV31FilterNro ,
                                                 AV33FilterCreatedDateFrom ,
                                                 AV34FilterCreatedDateTo ,
                                                 A20InvoiceId ,
                                                 A38InvoiceCreatedDate ,
                                                 A94InvoiceActive } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE, TypeConstants.BOOLEAN
                                                 }
            });
            /* Using cursor H004K5 */
            pr_default.execute(0, new Object[] {AV31FilterNro, AV33FilterCreatedDateFrom, AV34FilterCreatedDateTo, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_25_idx = 1;
            sGXsfl_25_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_25_idx), 4, 0), 4, "0");
            SubsflControlProps_252( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRIDINVOICE_nCurrentRecord < subGridinvoice_fnc_Recordsperpage( ) ) ) )
            {
               A99UserId = H004K5_A99UserId[0];
               A94InvoiceActive = H004K5_A94InvoiceActive[0];
               A100UserName = H004K5_A100UserName[0];
               A38InvoiceCreatedDate = H004K5_A38InvoiceCreatedDate[0];
               A20InvoiceId = H004K5_A20InvoiceId[0];
               A80InvoiceTotalReceivable = H004K5_A80InvoiceTotalReceivable[0];
               n80InvoiceTotalReceivable = H004K5_n80InvoiceTotalReceivable[0];
               A100UserName = H004K5_A100UserName[0];
               A80InvoiceTotalReceivable = H004K5_A80InvoiceTotalReceivable[0];
               n80InvoiceTotalReceivable = H004K5_n80InvoiceTotalReceivable[0];
               E174K2 ();
               pr_default.readNext(0);
            }
            GRIDINVOICE_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRIDINVOICE_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDINVOICE_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 25;
            WB4K0( ) ;
         }
         bGXsfl_25_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes4K2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_INVOICEID"+"_"+sGXsfl_25_idx, GetSecureSignedToken( sGXsfl_25_idx, context.localUtil.Format( (decimal)(A20InvoiceId), "ZZZZZ9"), context));
      }

      protected void RF4K5( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridinvoicedetailsContainer.ClearRows();
         }
         wbStart = 53;
         nGXsfl_53_idx = 1;
         sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
         SubsflControlProps_535( ) ;
         bGXsfl_53_Refreshing = true;
         GridinvoicedetailsContainer.AddObjectProperty("GridName", "Gridinvoicedetails");
         GridinvoicedetailsContainer.AddObjectProperty("CmpContext", "");
         GridinvoicedetailsContainer.AddObjectProperty("InMasterPage", "false");
         GridinvoicedetailsContainer.AddObjectProperty("Class", "Grid");
         GridinvoicedetailsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridinvoicedetailsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridinvoicedetailsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoicedetails_Backcolorstyle), 1, 0, ".", "")));
         GridinvoicedetailsContainer.PageSize = subGridinvoicedetails_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_535( ) ;
            E154K5 ();
            wbEnd = 53;
            WB4K0( ) ;
         }
         bGXsfl_53_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes4K5( )
      {
      }

      protected int subGridinvoice_fnc_Pagecount( )
      {
         GRIDINVOICE_nRecordCount = subGridinvoice_fnc_Recordcount( );
         if ( ((int)((GRIDINVOICE_nRecordCount) % (subGridinvoice_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRIDINVOICE_nRecordCount/ (decimal)(subGridinvoice_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDINVOICE_nRecordCount/ (decimal)(subGridinvoice_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGridinvoice_fnc_Recordcount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV31FilterNro ,
                                              AV33FilterCreatedDateFrom ,
                                              AV34FilterCreatedDateTo ,
                                              A20InvoiceId ,
                                              A38InvoiceCreatedDate ,
                                              A94InvoiceActive } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor H004K9 */
         pr_default.execute(1, new Object[] {AV31FilterNro, AV33FilterCreatedDateFrom, AV34FilterCreatedDateTo});
         GRIDINVOICE_nRecordCount = H004K9_AGRIDINVOICE_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRIDINVOICE_nRecordCount) ;
      }

      protected int subGridinvoice_fnc_Recordsperpage( )
      {
         return (int)(5*1) ;
      }

      protected int subGridinvoice_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDINVOICE_nFirstRecordOnPage/ (decimal)(subGridinvoice_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgridinvoice_firstpage( )
      {
         GRIDINVOICE_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRIDINVOICE_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDINVOICE_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridinvoice_refresh( subGridinvoice_Rows, AV31FilterNro, AV33FilterCreatedDateFrom, AV34FilterCreatedDateTo) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridinvoice_nextpage( )
      {
         GRIDINVOICE_nRecordCount = subGridinvoice_fnc_Recordcount( );
         if ( ( GRIDINVOICE_nRecordCount >= subGridinvoice_fnc_Recordsperpage( ) ) && ( GRIDINVOICE_nEOF == 0 ) )
         {
            GRIDINVOICE_nFirstRecordOnPage = (long)(GRIDINVOICE_nFirstRecordOnPage+subGridinvoice_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDINVOICE_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDINVOICE_nFirstRecordOnPage), 15, 0, ".", "")));
         GridinvoiceContainer.AddObjectProperty("GRIDINVOICE_nFirstRecordOnPage", GRIDINVOICE_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGridinvoice_refresh( subGridinvoice_Rows, AV31FilterNro, AV33FilterCreatedDateFrom, AV34FilterCreatedDateTo) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRIDINVOICE_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgridinvoice_previouspage( )
      {
         if ( GRIDINVOICE_nFirstRecordOnPage >= subGridinvoice_fnc_Recordsperpage( ) )
         {
            GRIDINVOICE_nFirstRecordOnPage = (long)(GRIDINVOICE_nFirstRecordOnPage-subGridinvoice_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDINVOICE_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDINVOICE_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridinvoice_refresh( subGridinvoice_Rows, AV31FilterNro, AV33FilterCreatedDateFrom, AV34FilterCreatedDateTo) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridinvoice_lastpage( )
      {
         GRIDINVOICE_nRecordCount = subGridinvoice_fnc_Recordcount( );
         if ( GRIDINVOICE_nRecordCount > subGridinvoice_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRIDINVOICE_nRecordCount) % (subGridinvoice_fnc_Recordsperpage( )))) == 0 )
            {
               GRIDINVOICE_nFirstRecordOnPage = (long)(GRIDINVOICE_nRecordCount-subGridinvoice_fnc_Recordsperpage( ));
            }
            else
            {
               GRIDINVOICE_nFirstRecordOnPage = (long)(GRIDINVOICE_nRecordCount-((int)((GRIDINVOICE_nRecordCount) % (subGridinvoice_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRIDINVOICE_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDINVOICE_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDINVOICE_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridinvoice_refresh( subGridinvoice_Rows, AV31FilterNro, AV33FilterCreatedDateFrom, AV34FilterCreatedDateTo) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgridinvoice_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRIDINVOICE_nFirstRecordOnPage = (long)(subGridinvoice_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRIDINVOICE_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDINVOICE_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDINVOICE_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridinvoice_refresh( subGridinvoice_Rows, AV31FilterNro, AV33FilterCreatedDateFrom, AV34FilterCreatedDateTo) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected int subGridinvoicedetails_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGridinvoicedetails_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGridinvoicedetails_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGridinvoicedetails_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavDetails_Enabled = 0;
         AssignProp("", false, edtavDetails_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDetails_Enabled), 5, 0), !bGXsfl_25_Refreshing);
         edtavCtlcode_Enabled = 0;
         AssignProp("", false, edtavCtlcode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcode_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         edtavCtlname_Enabled = 0;
         AssignProp("", false, edtavCtlname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         edtavCtlquantity_Enabled = 0;
         AssignProp("", false, edtavCtlquantity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlquantity_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         edtavCtlunitprice_Enabled = 0;
         AssignProp("", false, edtavCtlunitprice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlunitprice_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         edtavCtlsubtotal_Enabled = 0;
         AssignProp("", false, edtavCtlsubtotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsubtotal_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         edtavCtlwholesaleprice_Enabled = 0;
         AssignProp("", false, edtavCtlwholesaleprice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlwholesaleprice_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4K0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E164K2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Sdtcarproducts"), AV15SDTCarProducts);
            /* Read saved values. */
            nRC_GXsfl_25 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_25"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_53 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_53"), ".", ","), 18, MidpointRounding.ToEven));
            GRIDINVOICE_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDINVOICE_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRIDINVOICE_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDINVOICE_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_53 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_53"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_53_fel_idx = 0;
            while ( nGXsfl_53_fel_idx < nRC_GXsfl_53 )
            {
               nGXsfl_53_fel_idx = ((subGridinvoicedetails_Islastpage==1)&&(nGXsfl_53_fel_idx+1>subGridinvoicedetails_fnc_Recordsperpage( )) ? 1 : nGXsfl_53_fel_idx+1);
               sGXsfl_53_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_535( ) ;
               AV37GXV1 = nGXsfl_53_fel_idx;
               if ( ( AV15SDTCarProducts.Count >= AV37GXV1 ) && ( AV37GXV1 > 0 ) )
               {
                  AV15SDTCarProducts.CurrentItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV15SDTCarProducts.Item(AV37GXV1));
               }
            }
            if ( nGXsfl_53_fel_idx == 0 )
            {
               nGXsfl_53_idx = 1;
               sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
               SubsflControlProps_535( ) ;
            }
            nGXsfl_53_fel_idx = 1;
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavFilternro_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavFilternro_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vFILTERNRO");
               GX_FocusControl = edtavFilternro_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV31FilterNro = 0;
               AssignAttri("", false, "AV31FilterNro", StringUtil.LTrimStr( (decimal)(AV31FilterNro), 6, 0));
            }
            else
            {
               AV31FilterNro = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavFilternro_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV31FilterNro", StringUtil.LTrimStr( (decimal)(AV31FilterNro), 6, 0));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavFiltercreateddatefrom_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Filter Created Date From"}), 1, "vFILTERCREATEDDATEFROM");
               GX_FocusControl = edtavFiltercreateddatefrom_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV33FilterCreatedDateFrom = DateTime.MinValue;
               AssignAttri("", false, "AV33FilterCreatedDateFrom", context.localUtil.Format(AV33FilterCreatedDateFrom, "99/99/99"));
            }
            else
            {
               AV33FilterCreatedDateFrom = context.localUtil.CToD( cgiGet( edtavFiltercreateddatefrom_Internalname), 1);
               AssignAttri("", false, "AV33FilterCreatedDateFrom", context.localUtil.Format(AV33FilterCreatedDateFrom, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavFiltercreateddateto_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Filter Created Date To"}), 1, "vFILTERCREATEDDATETO");
               GX_FocusControl = edtavFiltercreateddateto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV34FilterCreatedDateTo = DateTime.MinValue;
               AssignAttri("", false, "AV34FilterCreatedDateTo", context.localUtil.Format(AV34FilterCreatedDateTo, "99/99/99"));
            }
            else
            {
               AV34FilterCreatedDateTo = context.localUtil.CToD( cgiGet( edtavFiltercreateddateto_Internalname), 1);
               AssignAttri("", false, "AV34FilterCreatedDateTo", context.localUtil.Format(AV34FilterCreatedDateTo, "99/99/99"));
            }
            AV19MovementDescription = cgiGet( edtavMovementdescription_Internalname);
            AssignAttri("", false, "AV19MovementDescription", AV19MovementDescription);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vFILTERNRO"), ".", ",") != Convert.ToDecimal( AV31FilterNro )) )
            {
               GRIDINVOICE_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vFILTERCREATEDDATEFROM"), 1) ) != DateTimeUtil.ResetTime ( AV33FilterCreatedDateFrom ) )
            {
               GRIDINVOICE_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vFILTERCREATEDDATETO"), 1) ) != DateTimeUtil.ResetTime ( AV34FilterCreatedDateTo ) )
            {
               GRIDINVOICE_nFirstRecordOnPage = 0;
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
         E164K2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E164K2( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtSDTContextSession1 = new GeneXus.Programs.general.ui.SdtSDTContextSession();
         new checkauthentication(context ).execute( out  GXt_SdtSDTContextSession1) ;
         /* Execute user subroutine: 'HIDETABLES' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'CLEARSDT' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      private void E174K2( )
      {
         /* Gridinvoice_Load Routine */
         returnInSub = false;
         AV26Details = "Details";
         AssignAttri("", false, edtavDetails_Internalname, AV26Details);
         edtavCancelinvoice_gximage = "icon_cancel_order_enabled";
         AV28CancelInvoice = context.GetImagePath( "1403447e-77df-409a-a5f6-c34a5fd96a80", "", context.GetTheme( ));
         AssignAttri("", false, edtavCancelinvoice_Internalname, AV28CancelInvoice);
         AV44Cancelinvoice_GXI = GXDbFile.PathToUrl( context.GetImagePath( "1403447e-77df-409a-a5f6-c34a5fd96a80", "", context.GetTheme( )));
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 25;
         }
         sendrow_252( ) ;
         GRIDINVOICE_nCurrentRecord = (long)(GRIDINVOICE_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_25_Refreshing )
         {
            DoAjaxLoad(25, GridinvoiceRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E184K2( )
      {
         AV37GXV1 = nGXsfl_53_idx;
         if ( ( AV37GXV1 > 0 ) && ( AV15SDTCarProducts.Count >= AV37GXV1 ) )
         {
            AV15SDTCarProducts.CurrentItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV15SDTCarProducts.Item(AV37GXV1));
         }
         /* Cancelinvoice_Click Routine */
         returnInSub = false;
         divTablecontent_Visible = 1;
         AssignProp("", false, divTablecontent_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablecontent_Visible), 5, 0), true);
         divTableinvoicedetails_Visible = 1;
         AssignProp("", false, divTableinvoicedetails_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableinvoicedetails_Visible), 5, 0), true);
         AV30InvoiceId = A20InvoiceId;
         AssignAttri("", false, "AV30InvoiceId", StringUtil.LTrimStr( (decimal)(AV30InvoiceId), 6, 0));
         /* Execute user subroutine: 'PREPAREINVOICECANCEL' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         if ( gx_BV53 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15SDTCarProducts", AV15SDTCarProducts);
            nGXsfl_53_bak_idx = nGXsfl_53_idx;
            gxgrGridinvoicedetails_refresh( subGridinvoice_Rows, AV31FilterNro, AV33FilterCreatedDateFrom, AV34FilterCreatedDateTo) ;
            nGXsfl_53_idx = nGXsfl_53_bak_idx;
            sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
            SubsflControlProps_535( ) ;
         }
      }

      protected void E194K2( )
      {
         /* 'Cancel' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'HIDETABLES' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'CLEARSDT' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV30InvoiceId = 0;
         AssignAttri("", false, "AV30InvoiceId", StringUtil.LTrimStr( (decimal)(AV30InvoiceId), 6, 0));
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         if ( gx_BV53 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15SDTCarProducts", AV15SDTCarProducts);
            nGXsfl_53_bak_idx = nGXsfl_53_idx;
            gxgrGridinvoicedetails_refresh( subGridinvoice_Rows, AV31FilterNro, AV33FilterCreatedDateFrom, AV34FilterCreatedDateTo) ;
            nGXsfl_53_idx = nGXsfl_53_bak_idx;
            sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
            SubsflControlProps_535( ) ;
         }
      }

      protected void E114K2( )
      {
         /* Filternro_Controlvaluechanged Routine */
         returnInSub = false;
         subgridinvoice_firstpage( ) ;
         gxgrGridinvoice_refresh( subGridinvoice_Rows, AV31FilterNro, AV33FilterCreatedDateFrom, AV34FilterCreatedDateTo) ;
      }

      protected void E124K2( )
      {
         /* Filtercreateddatefrom_Controlvaluechanged Routine */
         returnInSub = false;
         subgridinvoice_firstpage( ) ;
         gxgrGridinvoice_refresh( subGridinvoice_Rows, AV31FilterNro, AV33FilterCreatedDateFrom, AV34FilterCreatedDateTo) ;
      }

      protected void E134K2( )
      {
         /* Filtercreateddateto_Controlvaluechanged Routine */
         returnInSub = false;
         subgridinvoice_firstpage( ) ;
         gxgrGridinvoice_refresh( subGridinvoice_Rows, AV31FilterNro, AV33FilterCreatedDateFrom, AV34FilterCreatedDateTo) ;
      }

      protected void E144K2( )
      {
         /* 'ConfirmRegister' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CONFIRMINVOICECANCEL' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         if ( gx_BV53 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15SDTCarProducts", AV15SDTCarProducts);
            nGXsfl_53_bak_idx = nGXsfl_53_idx;
            gxgrGridinvoicedetails_refresh( subGridinvoice_Rows, AV31FilterNro, AV33FilterCreatedDateFrom, AV34FilterCreatedDateTo) ;
            nGXsfl_53_idx = nGXsfl_53_bak_idx;
            sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
            SubsflControlProps_535( ) ;
         }
      }

      protected void S112( )
      {
         /* 'HIDETABLES' Routine */
         returnInSub = false;
         divTablecontent_Visible = 0;
         AssignProp("", false, divTablecontent_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablecontent_Visible), 5, 0), true);
         divTableinvoicedetails_Visible = 0;
         AssignProp("", false, divTableinvoicedetails_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableinvoicedetails_Visible), 5, 0), true);
      }

      protected void S122( )
      {
         /* 'CLEARSDT' Routine */
         returnInSub = false;
         AV15SDTCarProducts.Clear();
         gx_BV53 = true;
      }

      protected void S132( )
      {
         /* 'PREPAREINVOICECANCEL' Routine */
         returnInSub = false;
         AV6AllOk = true;
         AssignAttri("", false, "AV6AllOk", AV6AllOk);
         AV15SDTCarProducts = new GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem>( context, "SDTCarProductsItem", "mtaKB");
         gx_BV53 = true;
         /* Using cursor H004K10 */
         pr_default.execute(2, new Object[] {AV30InvoiceId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A20InvoiceId = H004K10_A20InvoiceId[0];
            /* Using cursor H004K11 */
            pr_default.execute(3, new Object[] {A20InvoiceId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A55ProductCode = H004K11_A55ProductCode[0];
               n55ProductCode = H004K11_n55ProductCode[0];
               A15ProductId = H004K11_A15ProductId[0];
               A16ProductName = H004K11_A16ProductName[0];
               A26InvoiceDetailQuantity = H004K11_A26InvoiceDetailQuantity[0];
               A65InvoiceDetailHistoricPrice = H004K11_A65InvoiceDetailHistoricPrice[0];
               A55ProductCode = H004K11_A55ProductCode[0];
               n55ProductCode = H004K11_n55ProductCode[0];
               A16ProductName = H004K11_A16ProductName[0];
               AV18SDTCarProductsItem = new SdtSDTCarProducts_SDTCarProductsItem(context);
               AV18SDTCarProductsItem.gxTpr_Code = A55ProductCode;
               AV18SDTCarProductsItem.gxTpr_Id = A15ProductId;
               AV18SDTCarProductsItem.gxTpr_Name = A16ProductName;
               AV18SDTCarProductsItem.gxTpr_Quantity = A26InvoiceDetailQuantity;
               AV18SDTCarProductsItem.gxTpr_Unitprice = A65InvoiceDetailHistoricPrice;
               AV18SDTCarProductsItem.gxTpr_Subtotal = (decimal)(A65InvoiceDetailHistoricPrice*A26InvoiceDetailQuantity);
               AV15SDTCarProducts.Add(AV18SDTCarProductsItem, 0);
               gx_BV53 = true;
               pr_default.readNext(3);
            }
            pr_default.close(3);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
      }

      protected void S142( )
      {
         /* 'CONFIRMINVOICECANCEL' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CONTROLINVOICECANCEL' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV20ControlInvoiceCancel )
         {
            AV9Invoice.Load(AV30InvoiceId);
            AV9Invoice.gxTpr_Invoiceactive = false;
            AV9Invoice.Update();
            if ( AV9Invoice.Success() )
            {
               AV47GXV8 = 1;
               while ( AV47GXV8 <= AV9Invoice.gxTpr_Detail.Count )
               {
                  AV14InvoiceDetail = ((SdtInvoice_Detail)AV9Invoice.gxTpr_Detail.Item(AV47GXV8));
                  AV11Product.Load(AV14InvoiceDetail.gxTpr_Productid);
                  AV11Product.gxTpr_Productstock = (int)(AV11Product.gxTpr_Productstock+(AV14InvoiceDetail.gxTpr_Invoicedetailquantity));
                  AV11Product.Update();
                  if ( ! AV11Product.Success() )
                  {
                     AV6AllOk = false;
                     AssignAttri("", false, "AV6AllOk", AV6AllOk);
                     AV7ErrorMessage = AV11Product.GetMessages().ToJSonString(false);
                     AssignAttri("", false, "AV7ErrorMessage", AV7ErrorMessage);
                     if (true) break;
                  }
                  AV47GXV8 = (int)(AV47GXV8+1);
               }
            }
            else
            {
               AV6AllOk = false;
               AssignAttri("", false, "AV6AllOk", AV6AllOk);
               AV7ErrorMessage = AV9Invoice.GetMessages().ToJSonString(false);
               AssignAttri("", false, "AV7ErrorMessage", AV7ErrorMessage);
            }
            if ( AV6AllOk )
            {
               AV13Movement = new SdtMovement(context);
               AV13Movement.gxTpr_Movementkeyaditional = AV30InvoiceId;
               AV13Movement.gxTpr_Movementtype = 3;
               AV13Movement.gxTpr_Movementdescription = AV19MovementDescription;
               AV13Movement.Save();
               if ( ! AV13Movement.Success() )
               {
                  AV6AllOk = false;
                  AssignAttri("", false, "AV6AllOk", AV6AllOk);
                  AV7ErrorMessage = AV13Movement.GetMessages().ToJSonString(false);
                  AssignAttri("", false, "AV7ErrorMessage", AV7ErrorMessage);
               }
            }
            else
            {
               GX_msglist.addItem("Error to cancel Sale: "+AV7ErrorMessage);
            }
         }
         if ( AV6AllOk )
         {
            context.CommitDataStores("wpregistermovement",pr_default);
            GX_msglist.addItem("Sale canceled successfully!");
            /* Execute user subroutine: 'RESETWEBPANEL' */
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else
         {
            GX_msglist.addItem("Sale canceled fail!");
            context.RollbackDataStores("wpregistermovement",pr_default);
         }
      }

      protected void S152( )
      {
         /* 'CONTROLINVOICECANCEL' Routine */
         returnInSub = false;
         AV20ControlInvoiceCancel = true;
         AssignAttri("", false, "AV20ControlInvoiceCancel", AV20ControlInvoiceCancel);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV19MovementDescription)) )
         {
            AV20ControlInvoiceCancel = false;
            AssignAttri("", false, "AV20ControlInvoiceCancel", AV20ControlInvoiceCancel);
            GX_msglist.addItem("Reason is required");
         }
      }

      protected void S162( )
      {
         /* 'RESETWEBPANEL' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'HIDETABLES' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV9Invoice = new SdtInvoice(context);
         AV11Product = new SdtProduct(context);
         AV6AllOk = false;
         AssignAttri("", false, "AV6AllOk", AV6AllOk);
         AV20ControlInvoiceCancel = false;
         AssignAttri("", false, "AV20ControlInvoiceCancel", AV20ControlInvoiceCancel);
         AV19MovementDescription = "";
         AssignAttri("", false, "AV19MovementDescription", AV19MovementDescription);
         AV15SDTCarProducts.Clear();
         gx_BV53 = true;
         AV18SDTCarProductsItem = new SdtSDTCarProducts_SDTCarProductsItem(context);
      }

      private void E154K5( )
      {
         /* Gridinvoicedetails_Load Routine */
         returnInSub = false;
         AV37GXV1 = 1;
         while ( AV37GXV1 <= AV15SDTCarProducts.Count )
         {
            AV15SDTCarProducts.CurrentItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV15SDTCarProducts.Item(AV37GXV1));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 53;
            }
            sendrow_535( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_53_Refreshing )
            {
               DoAjaxLoad(53, GridinvoicedetailsRow);
            }
            AV37GXV1 = (int)(AV37GXV1+1);
         }
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
         PA4K2( ) ;
         WS4K2( ) ;
         WE4K2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202412163563844", true, true);
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
         context.AddJavascriptSource("wpregistermovement.js", "?202412163563845", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_252( )
      {
         edtavCancelinvoice_Internalname = "vCANCELINVOICE_"+sGXsfl_25_idx;
         edtInvoiceId_Internalname = "INVOICEID_"+sGXsfl_25_idx;
         edtInvoiceCreatedDate_Internalname = "INVOICECREATEDDATE_"+sGXsfl_25_idx;
         edtInvoiceTotalReceivable_Internalname = "INVOICETOTALRECEIVABLE_"+sGXsfl_25_idx;
         edtUserName_Internalname = "USERNAME_"+sGXsfl_25_idx;
         edtavDetails_Internalname = "vDETAILS_"+sGXsfl_25_idx;
      }

      protected void SubsflControlProps_fel_252( )
      {
         edtavCancelinvoice_Internalname = "vCANCELINVOICE_"+sGXsfl_25_fel_idx;
         edtInvoiceId_Internalname = "INVOICEID_"+sGXsfl_25_fel_idx;
         edtInvoiceCreatedDate_Internalname = "INVOICECREATEDDATE_"+sGXsfl_25_fel_idx;
         edtInvoiceTotalReceivable_Internalname = "INVOICETOTALRECEIVABLE_"+sGXsfl_25_fel_idx;
         edtUserName_Internalname = "USERNAME_"+sGXsfl_25_fel_idx;
         edtavDetails_Internalname = "vDETAILS_"+sGXsfl_25_fel_idx;
      }

      protected void sendrow_252( )
      {
         SubsflControlProps_252( ) ;
         WB4K0( ) ;
         if ( ( 5 * 1 == 0 ) || ( nGXsfl_25_idx <= subGridinvoice_fnc_Recordsperpage( ) * 1 ) )
         {
            GridinvoiceRow = GXWebRow.GetNew(context,GridinvoiceContainer);
            if ( subGridinvoice_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGridinvoice_Backstyle = 0;
               if ( StringUtil.StrCmp(subGridinvoice_Class, "") != 0 )
               {
                  subGridinvoice_Linesclass = subGridinvoice_Class+"Odd";
               }
            }
            else if ( subGridinvoice_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGridinvoice_Backstyle = 0;
               subGridinvoice_Backcolor = subGridinvoice_Allbackcolor;
               if ( StringUtil.StrCmp(subGridinvoice_Class, "") != 0 )
               {
                  subGridinvoice_Linesclass = subGridinvoice_Class+"Uniform";
               }
            }
            else if ( subGridinvoice_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGridinvoice_Backstyle = 1;
               if ( StringUtil.StrCmp(subGridinvoice_Class, "") != 0 )
               {
                  subGridinvoice_Linesclass = subGridinvoice_Class+"Odd";
               }
               subGridinvoice_Backcolor = (int)(0x0);
            }
            else if ( subGridinvoice_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGridinvoice_Backstyle = 1;
               if ( ((int)((nGXsfl_25_idx) % (2))) == 0 )
               {
                  subGridinvoice_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridinvoice_Class, "") != 0 )
                  {
                     subGridinvoice_Linesclass = subGridinvoice_Class+"Even";
                  }
               }
               else
               {
                  subGridinvoice_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridinvoice_Class, "") != 0 )
                  {
                     subGridinvoice_Linesclass = subGridinvoice_Class+"Odd";
                  }
               }
            }
            if ( GridinvoiceContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"PromptGrid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_25_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridinvoiceContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Active Bitmap Variable */
            TempTags = " " + ((edtavCancelinvoice_Enabled!=0)&&(edtavCancelinvoice_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 26,'',false,'',25)\"" : " ");
            ClassString = "Image" + " " + ((StringUtil.StrCmp(edtavCancelinvoice_gximage, "")==0) ? "" : "GX_Image_"+edtavCancelinvoice_gximage+"_Class");
            StyleString = "";
            AV28CancelInvoice_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV28CancelInvoice))&&String.IsNullOrEmpty(StringUtil.RTrim( AV44Cancelinvoice_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV28CancelInvoice)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV28CancelInvoice)) ? AV44Cancelinvoice_GXI : context.PathToRelativeUrl( AV28CancelInvoice));
            GridinvoiceRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavCancelinvoice_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)5,(string)edtavCancelinvoice_Jsonclick,"'"+""+"'"+",false,"+"'"+"EVCANCELINVOICE.CLICK."+sGXsfl_25_idx+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV28CancelInvoice_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridinvoiceContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridinvoiceRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInvoiceId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A20InvoiceId), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A20InvoiceId), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInvoiceId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)25,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridinvoiceContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridinvoiceRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInvoiceCreatedDate_Internalname,context.localUtil.Format(A38InvoiceCreatedDate, "99/99/99"),context.localUtil.Format( A38InvoiceCreatedDate, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInvoiceCreatedDate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)25,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridinvoiceContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridinvoiceRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInvoiceTotalReceivable_Internalname,StringUtil.LTrim( StringUtil.NToC( A80InvoiceTotalReceivable, 18, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A80InvoiceTotalReceivable, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInvoiceTotalReceivable_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)25,(short)0,(short)-1,(short)0,(bool)true,(string)"Price",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridinvoiceContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridinvoiceRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUserName_Internalname,(string)A100UserName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUserName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)25,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridinvoiceContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavDetails_Enabled!=0)&&(edtavDetails_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 31,'',false,'"+sGXsfl_25_idx+"',25)\"" : " ");
            ROClassString = "Attribute";
            GridinvoiceRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDetails_Internalname,(string)AV26Details,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavDetails_Enabled!=0)&&(edtavDetails_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,31);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+"e204k2_client"+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDetails_Jsonclick,(short)7,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavDetails_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)25,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes4K2( ) ;
            GridinvoiceContainer.AddRow(GridinvoiceRow);
            nGXsfl_25_idx = ((subGridinvoice_Islastpage==1)&&(nGXsfl_25_idx+1>subGridinvoice_fnc_Recordsperpage( )) ? 1 : nGXsfl_25_idx+1);
            sGXsfl_25_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_25_idx), 4, 0), 4, "0");
            SubsflControlProps_252( ) ;
         }
         /* End function sendrow_252 */
      }

      protected void SubsflControlProps_535( )
      {
         edtavCtlcode_Internalname = "CTLCODE_"+sGXsfl_53_idx;
         edtavCtlname_Internalname = "CTLNAME_"+sGXsfl_53_idx;
         edtavCtlquantity_Internalname = "CTLQUANTITY_"+sGXsfl_53_idx;
         edtavCtlunitprice_Internalname = "CTLUNITPRICE_"+sGXsfl_53_idx;
         edtavCtlsubtotal_Internalname = "CTLSUBTOTAL_"+sGXsfl_53_idx;
         edtavCtlwholesaleprice_Internalname = "CTLWHOLESALEPRICE_"+sGXsfl_53_idx;
      }

      protected void SubsflControlProps_fel_535( )
      {
         edtavCtlcode_Internalname = "CTLCODE_"+sGXsfl_53_fel_idx;
         edtavCtlname_Internalname = "CTLNAME_"+sGXsfl_53_fel_idx;
         edtavCtlquantity_Internalname = "CTLQUANTITY_"+sGXsfl_53_fel_idx;
         edtavCtlunitprice_Internalname = "CTLUNITPRICE_"+sGXsfl_53_fel_idx;
         edtavCtlsubtotal_Internalname = "CTLSUBTOTAL_"+sGXsfl_53_fel_idx;
         edtavCtlwholesaleprice_Internalname = "CTLWHOLESALEPRICE_"+sGXsfl_53_fel_idx;
      }

      protected void sendrow_535( )
      {
         SubsflControlProps_535( ) ;
         WB4K0( ) ;
         GridinvoicedetailsRow = GXWebRow.GetNew(context,GridinvoicedetailsContainer);
         if ( subGridinvoicedetails_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridinvoicedetails_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridinvoicedetails_Class, "") != 0 )
            {
               subGridinvoicedetails_Linesclass = subGridinvoicedetails_Class+"Odd";
            }
         }
         else if ( subGridinvoicedetails_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridinvoicedetails_Backstyle = 0;
            subGridinvoicedetails_Backcolor = subGridinvoicedetails_Allbackcolor;
            if ( StringUtil.StrCmp(subGridinvoicedetails_Class, "") != 0 )
            {
               subGridinvoicedetails_Linesclass = subGridinvoicedetails_Class+"Uniform";
            }
         }
         else if ( subGridinvoicedetails_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridinvoicedetails_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridinvoicedetails_Class, "") != 0 )
            {
               subGridinvoicedetails_Linesclass = subGridinvoicedetails_Class+"Odd";
            }
            subGridinvoicedetails_Backcolor = (int)(0x0);
         }
         else if ( subGridinvoicedetails_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridinvoicedetails_Backstyle = 1;
            if ( ((int)((nGXsfl_53_idx) % (2))) == 0 )
            {
               subGridinvoicedetails_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridinvoicedetails_Class, "") != 0 )
               {
                  subGridinvoicedetails_Linesclass = subGridinvoicedetails_Class+"Even";
               }
            }
            else
            {
               subGridinvoicedetails_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridinvoicedetails_Class, "") != 0 )
               {
                  subGridinvoicedetails_Linesclass = subGridinvoicedetails_Class+"Odd";
               }
            }
         }
         if ( GridinvoicedetailsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr ") ;
            context.WriteHtmlText( " class=\""+"Grid"+"\" style=\""+""+"\"") ;
            context.WriteHtmlText( " gxrow=\""+sGXsfl_53_idx+"\">") ;
         }
         /* Subfile cell */
         if ( GridinvoicedetailsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridinvoicedetailsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcode_Internalname,((SdtSDTCarProducts_SDTCarProductsItem)AV15SDTCarProducts.Item(AV37GXV1)).gxTpr_Code,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcode_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlcode_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)53,(short)0,(short)-1,(short)-1,(bool)false,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridinvoicedetailsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridinvoicedetailsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname_Internalname,((SdtSDTCarProducts_SDTCarProductsItem)AV15SDTCarProducts.Item(AV37GXV1)).gxTpr_Name,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)53,(short)0,(short)-1,(short)-1,(bool)false,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridinvoicedetailsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridinvoicedetailsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlquantity_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV15SDTCarProducts.Item(AV37GXV1)).gxTpr_Quantity), 6, 0, ".", "")),StringUtil.LTrim( ((edtavCtlquantity_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV15SDTCarProducts.Item(AV37GXV1)).gxTpr_Quantity), "ZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV15SDTCarProducts.Item(AV37GXV1)).gxTpr_Quantity), "ZZZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlquantity_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlquantity_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)53,(short)0,(short)-1,(short)0,(bool)false,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( GridinvoicedetailsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridinvoicedetailsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlunitprice_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTCarProducts_SDTCarProductsItem)AV15SDTCarProducts.Item(AV37GXV1)).gxTpr_Unitprice, 18, 2, ".", "")),StringUtil.LTrim( ((edtavCtlunitprice_Enabled!=0) ? context.localUtil.Format( ((SdtSDTCarProducts_SDTCarProductsItem)AV15SDTCarProducts.Item(AV37GXV1)).gxTpr_Unitprice, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTCarProducts_SDTCarProductsItem)AV15SDTCarProducts.Item(AV37GXV1)).gxTpr_Unitprice, "ZZZZZZZZZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlunitprice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlunitprice_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)53,(short)0,(short)-1,(short)0,(bool)false,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( GridinvoicedetailsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridinvoicedetailsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsubtotal_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTCarProducts_SDTCarProductsItem)AV15SDTCarProducts.Item(AV37GXV1)).gxTpr_Subtotal, 18, 2, ".", "")),StringUtil.LTrim( ((edtavCtlsubtotal_Enabled!=0) ? context.localUtil.Format( ((SdtSDTCarProducts_SDTCarProductsItem)AV15SDTCarProducts.Item(AV37GXV1)).gxTpr_Subtotal, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTCarProducts_SDTCarProductsItem)AV15SDTCarProducts.Item(AV37GXV1)).gxTpr_Subtotal, "ZZZZZZZZZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlsubtotal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlsubtotal_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)53,(short)0,(short)-1,(short)0,(bool)false,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( GridinvoicedetailsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridinvoicedetailsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlwholesaleprice_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTCarProducts_SDTCarProductsItem)AV15SDTCarProducts.Item(AV37GXV1)).gxTpr_Wholesaleprice, 18, 2, ".", "")),StringUtil.LTrim( ((edtavCtlwholesaleprice_Enabled!=0) ? context.localUtil.Format( ((SdtSDTCarProducts_SDTCarProductsItem)AV15SDTCarProducts.Item(AV37GXV1)).gxTpr_Wholesaleprice, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTCarProducts_SDTCarProductsItem)AV15SDTCarProducts.Item(AV37GXV1)).gxTpr_Wholesaleprice, "ZZZZZZZZZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlwholesaleprice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlwholesaleprice_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)53,(short)0,(short)-1,(short)0,(bool)false,(string)"",(string)"right",(bool)false,(string)""});
         send_integrity_lvl_hashes4K5( ) ;
         GridinvoicedetailsContainer.AddRow(GridinvoicedetailsRow);
         nGXsfl_53_idx = ((subGridinvoicedetails_Islastpage==1)&&(nGXsfl_53_idx+1>subGridinvoicedetails_fnc_Recordsperpage( )) ? 1 : nGXsfl_53_idx+1);
         sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
         SubsflControlProps_535( ) ;
         /* End function sendrow_535 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl25( )
      {
         if ( GridinvoiceContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridinvoiceContainer"+"DivS\" data-gxgridid=\"25\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridinvoice_Internalname, subGridinvoice_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGridinvoice_Backcolorstyle == 0 )
            {
               subGridinvoice_Titlebackstyle = 0;
               if ( StringUtil.Len( subGridinvoice_Class) > 0 )
               {
                  subGridinvoice_Linesclass = subGridinvoice_Class+"Title";
               }
            }
            else
            {
               subGridinvoice_Titlebackstyle = 1;
               if ( subGridinvoice_Backcolorstyle == 1 )
               {
                  subGridinvoice_Titlebackcolor = subGridinvoice_Allbackcolor;
                  if ( StringUtil.Len( subGridinvoice_Class) > 0 )
                  {
                     subGridinvoice_Linesclass = subGridinvoice_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGridinvoice_Class) > 0 )
                  {
                     subGridinvoice_Linesclass = subGridinvoice_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Image"+" "+((StringUtil.StrCmp(edtavCancelinvoice_gximage, "")==0) ? "" : "GX_Image_"+edtavCancelinvoice_gximage+"_Class")+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Cancel") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Nro") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Created") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Total Receivable") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Seller") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridinvoiceContainer.AddObjectProperty("GridName", "Gridinvoice");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridinvoiceContainer = new GXWebGrid( context);
            }
            else
            {
               GridinvoiceContainer.Clear();
            }
            GridinvoiceContainer.SetWrapped(nGXWrapped);
            GridinvoiceContainer.AddObjectProperty("GridName", "Gridinvoice");
            GridinvoiceContainer.AddObjectProperty("Header", subGridinvoice_Header);
            GridinvoiceContainer.AddObjectProperty("Class", "PromptGrid");
            GridinvoiceContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridinvoiceContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridinvoiceContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoice_Backcolorstyle), 1, 0, ".", "")));
            GridinvoiceContainer.AddObjectProperty("CmpContext", "");
            GridinvoiceContainer.AddObjectProperty("InMasterPage", "false");
            GridinvoiceColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridinvoiceColumn.AddObjectProperty("Value", context.convertURL( AV28CancelInvoice));
            GridinvoiceContainer.AddColumnProperties(GridinvoiceColumn);
            GridinvoiceColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridinvoiceColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A20InvoiceId), 6, 0, ".", ""))));
            GridinvoiceContainer.AddColumnProperties(GridinvoiceColumn);
            GridinvoiceColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridinvoiceColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A38InvoiceCreatedDate, "99/99/99")));
            GridinvoiceContainer.AddColumnProperties(GridinvoiceColumn);
            GridinvoiceColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridinvoiceColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A80InvoiceTotalReceivable, 18, 2, ".", ""))));
            GridinvoiceContainer.AddColumnProperties(GridinvoiceColumn);
            GridinvoiceColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridinvoiceColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A100UserName));
            GridinvoiceContainer.AddColumnProperties(GridinvoiceColumn);
            GridinvoiceColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridinvoiceColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV26Details));
            GridinvoiceColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDetails_Enabled), 5, 0, ".", "")));
            GridinvoiceContainer.AddColumnProperties(GridinvoiceColumn);
            GridinvoiceContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoice_Selectedindex), 4, 0, ".", "")));
            GridinvoiceContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoice_Allowselection), 1, 0, ".", "")));
            GridinvoiceContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoice_Selectioncolor), 9, 0, ".", "")));
            GridinvoiceContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoice_Allowhovering), 1, 0, ".", "")));
            GridinvoiceContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoice_Hoveringcolor), 9, 0, ".", "")));
            GridinvoiceContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoice_Allowcollapsing), 1, 0, ".", "")));
            GridinvoiceContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoice_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void StartGridControl53( )
      {
         if ( GridinvoicedetailsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridinvoicedetailsContainer"+"DivS\" data-gxgridid=\"53\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridinvoicedetails_Internalname, subGridinvoicedetails_Internalname, "", "Grid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGridinvoicedetails_Backcolorstyle == 0 )
            {
               subGridinvoicedetails_Titlebackstyle = 0;
               if ( StringUtil.Len( subGridinvoicedetails_Class) > 0 )
               {
                  subGridinvoicedetails_Linesclass = subGridinvoicedetails_Class+"Title";
               }
            }
            else
            {
               subGridinvoicedetails_Titlebackstyle = 1;
               if ( subGridinvoicedetails_Backcolorstyle == 1 )
               {
                  subGridinvoicedetails_Titlebackcolor = subGridinvoicedetails_Allbackcolor;
                  if ( StringUtil.Len( subGridinvoicedetails_Class) > 0 )
                  {
                     subGridinvoicedetails_Linesclass = subGridinvoicedetails_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGridinvoicedetails_Class) > 0 )
                  {
                     subGridinvoicedetails_Linesclass = subGridinvoicedetails_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Product Code") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Quantity") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Unit Price") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Subtotal") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Wholesale Price") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridinvoicedetailsContainer.AddObjectProperty("GridName", "Gridinvoicedetails");
         }
         else
         {
            GridinvoicedetailsContainer.AddObjectProperty("GridName", "Gridinvoicedetails");
            GridinvoicedetailsContainer.AddObjectProperty("Header", subGridinvoicedetails_Header);
            GridinvoicedetailsContainer.AddObjectProperty("Class", "Grid");
            GridinvoicedetailsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridinvoicedetailsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridinvoicedetailsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoicedetails_Backcolorstyle), 1, 0, ".", "")));
            GridinvoicedetailsContainer.AddObjectProperty("CmpContext", "");
            GridinvoicedetailsContainer.AddObjectProperty("InMasterPage", "false");
            GridinvoicedetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridinvoicedetailsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlcode_Enabled), 5, 0, ".", "")));
            GridinvoicedetailsContainer.AddColumnProperties(GridinvoicedetailsColumn);
            GridinvoicedetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridinvoicedetailsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlname_Enabled), 5, 0, ".", "")));
            GridinvoicedetailsContainer.AddColumnProperties(GridinvoicedetailsColumn);
            GridinvoicedetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridinvoicedetailsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlquantity_Enabled), 5, 0, ".", "")));
            GridinvoicedetailsContainer.AddColumnProperties(GridinvoicedetailsColumn);
            GridinvoicedetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridinvoicedetailsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlunitprice_Enabled), 5, 0, ".", "")));
            GridinvoicedetailsContainer.AddColumnProperties(GridinvoicedetailsColumn);
            GridinvoicedetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridinvoicedetailsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlsubtotal_Enabled), 5, 0, ".", "")));
            GridinvoicedetailsContainer.AddColumnProperties(GridinvoicedetailsColumn);
            GridinvoicedetailsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridinvoicedetailsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlwholesaleprice_Enabled), 5, 0, ".", "")));
            GridinvoicedetailsContainer.AddColumnProperties(GridinvoicedetailsColumn);
            GridinvoicedetailsContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoicedetails_Selectedindex), 4, 0, ".", "")));
            GridinvoicedetailsContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoicedetails_Allowselection), 1, 0, ".", "")));
            GridinvoicedetailsContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoicedetails_Selectioncolor), 9, 0, ".", "")));
            GridinvoicedetailsContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoicedetails_Allowhovering), 1, 0, ".", "")));
            GridinvoicedetailsContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoicedetails_Hoveringcolor), 9, 0, ".", "")));
            GridinvoicedetailsContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoicedetails_Allowcollapsing), 1, 0, ".", "")));
            GridinvoicedetailsContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoicedetails_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         edtavFilternro_Internalname = "vFILTERNRO";
         edtavFiltercreateddatefrom_Internalname = "vFILTERCREATEDDATEFROM";
         edtavFiltercreateddateto_Internalname = "vFILTERCREATEDDATETO";
         divTablefilters_Internalname = "TABLEFILTERS";
         edtavCancelinvoice_Internalname = "vCANCELINVOICE";
         edtInvoiceId_Internalname = "INVOICEID";
         edtInvoiceCreatedDate_Internalname = "INVOICECREATEDDATE";
         edtInvoiceTotalReceivable_Internalname = "INVOICETOTALRECEIVABLE";
         edtUserName_Internalname = "USERNAME";
         edtavDetails_Internalname = "vDETAILS";
         divTableinvoices_Internalname = "TABLEINVOICES";
         bttConfirmregister_Internalname = "CONFIRMREGISTER";
         bttCancel_Internalname = "CANCEL";
         edtavMovementdescription_Internalname = "vMOVEMENTDESCRIPTION";
         divTablebuttons_Internalname = "TABLEBUTTONS";
         edtavCtlcode_Internalname = "CTLCODE";
         edtavCtlname_Internalname = "CTLNAME";
         edtavCtlquantity_Internalname = "CTLQUANTITY";
         edtavCtlunitprice_Internalname = "CTLUNITPRICE";
         edtavCtlsubtotal_Internalname = "CTLSUBTOTAL";
         edtavCtlwholesaleprice_Internalname = "CTLWHOLESALEPRICE";
         divTableinvoicedetails_Internalname = "TABLEINVOICEDETAILS";
         divTablecontent_Internalname = "TABLECONTENT";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGridinvoice_Internalname = "GRIDINVOICE";
         subGridinvoicedetails_Internalname = "GRIDINVOICEDETAILS";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("mtaKB", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridinvoicedetails_Allowcollapsing = 0;
         subGridinvoicedetails_Allowselection = 0;
         subGridinvoicedetails_Header = "";
         subGridinvoice_Allowcollapsing = 0;
         subGridinvoice_Allowselection = 0;
         subGridinvoice_Header = "";
         edtavCtlwholesaleprice_Jsonclick = "";
         edtavCtlwholesaleprice_Enabled = 0;
         edtavCtlsubtotal_Jsonclick = "";
         edtavCtlsubtotal_Enabled = 0;
         edtavCtlunitprice_Jsonclick = "";
         edtavCtlunitprice_Enabled = 0;
         edtavCtlquantity_Jsonclick = "";
         edtavCtlquantity_Enabled = 0;
         edtavCtlname_Jsonclick = "";
         edtavCtlname_Enabled = 0;
         edtavCtlcode_Jsonclick = "";
         edtavCtlcode_Enabled = 0;
         subGridinvoicedetails_Class = "Grid";
         subGridinvoicedetails_Backcolorstyle = 0;
         edtavDetails_Jsonclick = "";
         edtavDetails_Visible = -1;
         edtavDetails_Enabled = 1;
         edtUserName_Jsonclick = "";
         edtInvoiceTotalReceivable_Jsonclick = "";
         edtInvoiceCreatedDate_Jsonclick = "";
         edtInvoiceId_Jsonclick = "";
         edtavCancelinvoice_Jsonclick = "";
         edtavCancelinvoice_gximage = "";
         edtavCancelinvoice_Visible = -1;
         edtavCancelinvoice_Enabled = 1;
         subGridinvoice_Class = "PromptGrid";
         subGridinvoice_Backcolorstyle = 0;
         edtavCtlwholesaleprice_Enabled = -1;
         edtavCtlsubtotal_Enabled = -1;
         edtavCtlunitprice_Enabled = -1;
         edtavCtlquantity_Enabled = -1;
         edtavCtlname_Enabled = -1;
         edtavCtlcode_Enabled = -1;
         divTableinvoicedetails_Visible = 1;
         edtavMovementdescription_Enabled = 1;
         divTablecontent_Visible = 1;
         edtavFiltercreateddateto_Jsonclick = "";
         edtavFiltercreateddateto_Enabled = 1;
         edtavFiltercreateddatefrom_Jsonclick = "";
         edtavFiltercreateddatefrom_Enabled = 1;
         edtavFilternro_Jsonclick = "";
         edtavFilternro_Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Cancel Sale";
         subGridinvoice_Rows = 5;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRIDINVOICE_nFirstRecordOnPage'},{av:'GRIDINVOICE_nEOF'},{av:'GRIDINVOICEDETAILS_nFirstRecordOnPage'},{av:'GRIDINVOICEDETAILS_nEOF'},{av:'AV15SDTCarProducts',fld:'vSDTCARPRODUCTS',grid:53,pic:''},{av:'nGXsfl_53_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:53},{av:'nRC_GXsfl_53',ctrl:'GRIDINVOICEDETAILS',prop:'GridRC',grid:53},{av:'subGridinvoice_Rows',ctrl:'GRIDINVOICE',prop:'Rows'},{av:'AV31FilterNro',fld:'vFILTERNRO',pic:'ZZZZZ9'},{av:'AV33FilterCreatedDateFrom',fld:'vFILTERCREATEDDATEFROM',pic:''},{av:'AV34FilterCreatedDateTo',fld:'vFILTERCREATEDDATETO',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("GRIDINVOICE.LOAD","{handler:'E174K2',iparms:[]");
         setEventMetadata("GRIDINVOICE.LOAD",",oparms:[{av:'AV26Details',fld:'vDETAILS',pic:''},{av:'AV28CancelInvoice',fld:'vCANCELINVOICE',pic:''}]}");
         setEventMetadata("VDETAILS.CLICK","{handler:'E204K2',iparms:[{av:'A20InvoiceId',fld:'INVOICEID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("VDETAILS.CLICK",",oparms:[]}");
         setEventMetadata("VCANCELINVOICE.CLICK","{handler:'E184K2',iparms:[{av:'A20InvoiceId',fld:'INVOICEID',pic:'ZZZZZ9',hsh:true},{av:'AV30InvoiceId',fld:'vINVOICEID',pic:'ZZZZZ9'},{av:'A55ProductCode',fld:'PRODUCTCODE',pic:''},{av:'A15ProductId',fld:'PRODUCTID',pic:'ZZZZZ9'},{av:'A16ProductName',fld:'PRODUCTNAME',pic:''},{av:'A26InvoiceDetailQuantity',fld:'INVOICEDETAILQUANTITY',pic:'ZZZZZ9'},{av:'A65InvoiceDetailHistoricPrice',fld:'INVOICEDETAILHISTORICPRICE',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV15SDTCarProducts',fld:'vSDTCARPRODUCTS',grid:53,pic:''},{av:'nGXsfl_53_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:53},{av:'GRIDINVOICEDETAILS_nFirstRecordOnPage'},{av:'nRC_GXsfl_53',ctrl:'GRIDINVOICEDETAILS',prop:'GridRC',grid:53},{av:'GRIDINVOICE_nFirstRecordOnPage'},{av:'GRIDINVOICE_nEOF'},{av:'GRIDINVOICEDETAILS_nEOF'},{av:'subGridinvoice_Rows',ctrl:'GRIDINVOICE',prop:'Rows'},{av:'AV31FilterNro',fld:'vFILTERNRO',pic:'ZZZZZ9'},{av:'AV33FilterCreatedDateFrom',fld:'vFILTERCREATEDDATEFROM',pic:''},{av:'AV34FilterCreatedDateTo',fld:'vFILTERCREATEDDATETO',pic:''}]");
         setEventMetadata("VCANCELINVOICE.CLICK",",oparms:[{av:'divTablecontent_Visible',ctrl:'TABLECONTENT',prop:'Visible'},{av:'divTableinvoicedetails_Visible',ctrl:'TABLEINVOICEDETAILS',prop:'Visible'},{av:'AV30InvoiceId',fld:'vINVOICEID',pic:'ZZZZZ9'},{av:'AV6AllOk',fld:'vALLOK',pic:''},{av:'AV15SDTCarProducts',fld:'vSDTCARPRODUCTS',grid:53,pic:''},{av:'nGXsfl_53_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:53},{av:'GRIDINVOICEDETAILS_nFirstRecordOnPage'},{av:'nRC_GXsfl_53',ctrl:'GRIDINVOICEDETAILS',prop:'GridRC',grid:53}]}");
         setEventMetadata("'CANCEL'","{handler:'E194K2',iparms:[{av:'GRIDINVOICE_nFirstRecordOnPage'},{av:'GRIDINVOICE_nEOF'},{av:'subGridinvoice_Rows',ctrl:'GRIDINVOICE',prop:'Rows'},{av:'AV31FilterNro',fld:'vFILTERNRO',pic:'ZZZZZ9'},{av:'AV33FilterCreatedDateFrom',fld:'vFILTERCREATEDDATEFROM',pic:''},{av:'AV34FilterCreatedDateTo',fld:'vFILTERCREATEDDATETO',pic:''},{av:'AV15SDTCarProducts',fld:'vSDTCARPRODUCTS',grid:53,pic:''},{av:'nGXsfl_53_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:53},{av:'GRIDINVOICEDETAILS_nFirstRecordOnPage'},{av:'nRC_GXsfl_53',ctrl:'GRIDINVOICEDETAILS',prop:'GridRC',grid:53},{av:'GRIDINVOICEDETAILS_nEOF'}]");
         setEventMetadata("'CANCEL'",",oparms:[{av:'AV30InvoiceId',fld:'vINVOICEID',pic:'ZZZZZ9'},{av:'divTablecontent_Visible',ctrl:'TABLECONTENT',prop:'Visible'},{av:'divTableinvoicedetails_Visible',ctrl:'TABLEINVOICEDETAILS',prop:'Visible'},{av:'AV15SDTCarProducts',fld:'vSDTCARPRODUCTS',grid:53,pic:''},{av:'nGXsfl_53_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:53},{av:'GRIDINVOICEDETAILS_nFirstRecordOnPage'},{av:'nRC_GXsfl_53',ctrl:'GRIDINVOICEDETAILS',prop:'GridRC',grid:53}]}");
         setEventMetadata("VFILTERNRO.CONTROLVALUECHANGED","{handler:'E114K2',iparms:[{av:'GRIDINVOICE_nFirstRecordOnPage'},{av:'GRIDINVOICE_nEOF'},{av:'subGridinvoice_Rows',ctrl:'GRIDINVOICE',prop:'Rows'},{av:'AV31FilterNro',fld:'vFILTERNRO',pic:'ZZZZZ9'},{av:'AV33FilterCreatedDateFrom',fld:'vFILTERCREATEDDATEFROM',pic:''},{av:'AV34FilterCreatedDateTo',fld:'vFILTERCREATEDDATETO',pic:''},{av:'GRIDINVOICEDETAILS_nFirstRecordOnPage'},{av:'GRIDINVOICEDETAILS_nEOF'},{av:'AV15SDTCarProducts',fld:'vSDTCARPRODUCTS',grid:53,pic:''},{av:'nGXsfl_53_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:53},{av:'nRC_GXsfl_53',ctrl:'GRIDINVOICEDETAILS',prop:'GridRC',grid:53}]");
         setEventMetadata("VFILTERNRO.CONTROLVALUECHANGED",",oparms:[]}");
         setEventMetadata("VFILTERCREATEDDATEFROM.CONTROLVALUECHANGED","{handler:'E124K2',iparms:[{av:'GRIDINVOICE_nFirstRecordOnPage'},{av:'GRIDINVOICE_nEOF'},{av:'subGridinvoice_Rows',ctrl:'GRIDINVOICE',prop:'Rows'},{av:'AV31FilterNro',fld:'vFILTERNRO',pic:'ZZZZZ9'},{av:'AV33FilterCreatedDateFrom',fld:'vFILTERCREATEDDATEFROM',pic:''},{av:'AV34FilterCreatedDateTo',fld:'vFILTERCREATEDDATETO',pic:''},{av:'GRIDINVOICEDETAILS_nFirstRecordOnPage'},{av:'GRIDINVOICEDETAILS_nEOF'},{av:'AV15SDTCarProducts',fld:'vSDTCARPRODUCTS',grid:53,pic:''},{av:'nGXsfl_53_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:53},{av:'nRC_GXsfl_53',ctrl:'GRIDINVOICEDETAILS',prop:'GridRC',grid:53}]");
         setEventMetadata("VFILTERCREATEDDATEFROM.CONTROLVALUECHANGED",",oparms:[]}");
         setEventMetadata("VFILTERCREATEDDATETO.CONTROLVALUECHANGED","{handler:'E134K2',iparms:[{av:'GRIDINVOICE_nFirstRecordOnPage'},{av:'GRIDINVOICE_nEOF'},{av:'subGridinvoice_Rows',ctrl:'GRIDINVOICE',prop:'Rows'},{av:'AV31FilterNro',fld:'vFILTERNRO',pic:'ZZZZZ9'},{av:'AV33FilterCreatedDateFrom',fld:'vFILTERCREATEDDATEFROM',pic:''},{av:'AV34FilterCreatedDateTo',fld:'vFILTERCREATEDDATETO',pic:''},{av:'GRIDINVOICEDETAILS_nFirstRecordOnPage'},{av:'GRIDINVOICEDETAILS_nEOF'},{av:'AV15SDTCarProducts',fld:'vSDTCARPRODUCTS',grid:53,pic:''},{av:'nGXsfl_53_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:53},{av:'nRC_GXsfl_53',ctrl:'GRIDINVOICEDETAILS',prop:'GridRC',grid:53}]");
         setEventMetadata("VFILTERCREATEDDATETO.CONTROLVALUECHANGED",",oparms:[]}");
         setEventMetadata("'CONFIRMREGISTER'","{handler:'E144K2',iparms:[{av:'AV20ControlInvoiceCancel',fld:'vCONTROLINVOICECANCEL',pic:''},{av:'AV30InvoiceId',fld:'vINVOICEID',pic:'ZZZZZ9'},{av:'AV6AllOk',fld:'vALLOK',pic:''},{av:'AV19MovementDescription',fld:'vMOVEMENTDESCRIPTION',pic:''},{av:'AV7ErrorMessage',fld:'vERRORMESSAGE',pic:''},{av:'AV15SDTCarProducts',fld:'vSDTCARPRODUCTS',grid:53,pic:''},{av:'nGXsfl_53_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:53},{av:'GRIDINVOICEDETAILS_nFirstRecordOnPage'},{av:'nRC_GXsfl_53',ctrl:'GRIDINVOICEDETAILS',prop:'GridRC',grid:53},{av:'GRIDINVOICE_nFirstRecordOnPage'},{av:'GRIDINVOICE_nEOF'},{av:'GRIDINVOICEDETAILS_nEOF'},{av:'subGridinvoice_Rows',ctrl:'GRIDINVOICE',prop:'Rows'},{av:'AV31FilterNro',fld:'vFILTERNRO',pic:'ZZZZZ9'},{av:'AV33FilterCreatedDateFrom',fld:'vFILTERCREATEDDATEFROM',pic:''},{av:'AV34FilterCreatedDateTo',fld:'vFILTERCREATEDDATETO',pic:''}]");
         setEventMetadata("'CONFIRMREGISTER'",",oparms:[{av:'AV6AllOk',fld:'vALLOK',pic:''},{av:'AV7ErrorMessage',fld:'vERRORMESSAGE',pic:''},{av:'AV20ControlInvoiceCancel',fld:'vCONTROLINVOICECANCEL',pic:''},{av:'AV19MovementDescription',fld:'vMOVEMENTDESCRIPTION',pic:''},{av:'AV15SDTCarProducts',fld:'vSDTCARPRODUCTS',grid:53,pic:''},{av:'nGXsfl_53_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:53},{av:'GRIDINVOICEDETAILS_nFirstRecordOnPage'},{av:'nRC_GXsfl_53',ctrl:'GRIDINVOICEDETAILS',prop:'GridRC',grid:53},{av:'divTablecontent_Visible',ctrl:'TABLECONTENT',prop:'Visible'},{av:'divTableinvoicedetails_Visible',ctrl:'TABLEINVOICEDETAILS',prop:'Visible'}]}");
         setEventMetadata("GRIDINVOICE_FIRSTPAGE","{handler:'subgridinvoice_firstpage',iparms:[{av:'GRIDINVOICE_nFirstRecordOnPage'},{av:'GRIDINVOICE_nEOF'},{av:'subGridinvoice_Rows',ctrl:'GRIDINVOICE',prop:'Rows'},{av:'AV31FilterNro',fld:'vFILTERNRO',pic:'ZZZZZ9'},{av:'AV33FilterCreatedDateFrom',fld:'vFILTERCREATEDDATEFROM',pic:''},{av:'AV34FilterCreatedDateTo',fld:'vFILTERCREATEDDATETO',pic:''}]");
         setEventMetadata("GRIDINVOICE_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRIDINVOICE_PREVPAGE","{handler:'subgridinvoice_previouspage',iparms:[{av:'GRIDINVOICE_nFirstRecordOnPage'},{av:'GRIDINVOICE_nEOF'},{av:'subGridinvoice_Rows',ctrl:'GRIDINVOICE',prop:'Rows'},{av:'AV31FilterNro',fld:'vFILTERNRO',pic:'ZZZZZ9'},{av:'AV33FilterCreatedDateFrom',fld:'vFILTERCREATEDDATEFROM',pic:''},{av:'AV34FilterCreatedDateTo',fld:'vFILTERCREATEDDATETO',pic:''}]");
         setEventMetadata("GRIDINVOICE_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRIDINVOICE_NEXTPAGE","{handler:'subgridinvoice_nextpage',iparms:[{av:'GRIDINVOICE_nFirstRecordOnPage'},{av:'GRIDINVOICE_nEOF'},{av:'subGridinvoice_Rows',ctrl:'GRIDINVOICE',prop:'Rows'},{av:'AV31FilterNro',fld:'vFILTERNRO',pic:'ZZZZZ9'},{av:'AV33FilterCreatedDateFrom',fld:'vFILTERCREATEDDATEFROM',pic:''},{av:'AV34FilterCreatedDateTo',fld:'vFILTERCREATEDDATETO',pic:''}]");
         setEventMetadata("GRIDINVOICE_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRIDINVOICE_LASTPAGE","{handler:'subgridinvoice_lastpage',iparms:[{av:'GRIDINVOICE_nFirstRecordOnPage'},{av:'GRIDINVOICE_nEOF'},{av:'subGridinvoice_Rows',ctrl:'GRIDINVOICE',prop:'Rows'},{av:'AV31FilterNro',fld:'vFILTERNRO',pic:'ZZZZZ9'},{av:'AV33FilterCreatedDateFrom',fld:'vFILTERCREATEDDATEFROM',pic:''},{av:'AV34FilterCreatedDateTo',fld:'vFILTERCREATEDDATETO',pic:''}]");
         setEventMetadata("GRIDINVOICE_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_FILTERCREATEDDATEFROM","{handler:'Validv_Filtercreateddatefrom',iparms:[]");
         setEventMetadata("VALIDV_FILTERCREATEDDATEFROM",",oparms:[]}");
         setEventMetadata("VALIDV_FILTERCREATEDDATETO","{handler:'Validv_Filtercreateddateto',iparms:[]");
         setEventMetadata("VALIDV_FILTERCREATEDDATETO",",oparms:[]}");
         setEventMetadata("VALID_INVOICEID","{handler:'Valid_Invoiceid',iparms:[]");
         setEventMetadata("VALID_INVOICEID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Details',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("VALIDV_GXV5","{handler:'Validv_Gxv5',iparms:[]");
         setEventMetadata("VALIDV_GXV5",",oparms:[]}");
         setEventMetadata("VALIDV_GXV6","{handler:'Validv_Gxv6',iparms:[]");
         setEventMetadata("VALIDV_GXV6",",oparms:[]}");
         setEventMetadata("VALIDV_GXV7","{handler:'Validv_Gxv7',iparms:[]");
         setEventMetadata("VALIDV_GXV7",",oparms:[]}");
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
         AV33FilterCreatedDateFrom = DateTime.MinValue;
         AV34FilterCreatedDateTo = DateTime.MinValue;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV15SDTCarProducts = new GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem>( context, "SDTCarProductsItem", "mtaKB");
         A55ProductCode = "";
         A16ProductName = "";
         AV7ErrorMessage = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         GridinvoiceContainer = new GXWebGrid( context);
         sStyleString = "";
         ClassString = "";
         StyleString = "";
         bttConfirmregister_Jsonclick = "";
         bttCancel_Jsonclick = "";
         AV19MovementDescription = "";
         GridinvoicedetailsContainer = new GXWebGrid( context);
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV28CancelInvoice = "";
         AV44Cancelinvoice_GXI = "";
         A38InvoiceCreatedDate = DateTime.MinValue;
         A100UserName = "";
         AV26Details = "";
         scmdbuf = "";
         H004K5_A99UserId = new int[1] ;
         H004K5_A94InvoiceActive = new bool[] {false} ;
         H004K5_A100UserName = new string[] {""} ;
         H004K5_A38InvoiceCreatedDate = new DateTime[] {DateTime.MinValue} ;
         H004K5_A20InvoiceId = new int[1] ;
         H004K5_A80InvoiceTotalReceivable = new decimal[1] ;
         H004K5_n80InvoiceTotalReceivable = new bool[] {false} ;
         H004K9_AGRIDINVOICE_nRecordCount = new long[1] ;
         GXt_SdtSDTContextSession1 = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         GridinvoiceRow = new GXWebRow();
         H004K10_A20InvoiceId = new int[1] ;
         H004K11_A25InvoiceDetailId = new int[1] ;
         H004K11_A20InvoiceId = new int[1] ;
         H004K11_A55ProductCode = new string[] {""} ;
         H004K11_n55ProductCode = new bool[] {false} ;
         H004K11_A15ProductId = new int[1] ;
         H004K11_A16ProductName = new string[] {""} ;
         H004K11_A26InvoiceDetailQuantity = new int[1] ;
         H004K11_A65InvoiceDetailHistoricPrice = new decimal[1] ;
         AV18SDTCarProductsItem = new SdtSDTCarProducts_SDTCarProductsItem(context);
         AV9Invoice = new SdtInvoice(context);
         AV14InvoiceDetail = new SdtInvoice_Detail(context);
         AV11Product = new SdtProduct(context);
         AV13Movement = new SdtMovement(context);
         GridinvoicedetailsRow = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGridinvoice_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         subGridinvoicedetails_Linesclass = "";
         GridinvoiceColumn = new GXWebColumn();
         GridinvoicedetailsColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpregistermovement__default(),
            new Object[][] {
                new Object[] {
               H004K5_A99UserId, H004K5_A94InvoiceActive, H004K5_A100UserName, H004K5_A38InvoiceCreatedDate, H004K5_A20InvoiceId, H004K5_A80InvoiceTotalReceivable, H004K5_n80InvoiceTotalReceivable
               }
               , new Object[] {
               H004K9_AGRIDINVOICE_nRecordCount
               }
               , new Object[] {
               H004K10_A20InvoiceId
               }
               , new Object[] {
               H004K11_A25InvoiceDetailId, H004K11_A20InvoiceId, H004K11_A55ProductCode, H004K11_n55ProductCode, H004K11_A15ProductId, H004K11_A16ProductName, H004K11_A26InvoiceDetailQuantity, H004K11_A65InvoiceDetailHistoricPrice
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavDetails_Enabled = 0;
         edtavCtlcode_Enabled = 0;
         edtavCtlname_Enabled = 0;
         edtavCtlquantity_Enabled = 0;
         edtavCtlunitprice_Enabled = 0;
         edtavCtlsubtotal_Enabled = 0;
         edtavCtlwholesaleprice_Enabled = 0;
      }

      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short GRIDINVOICE_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGridinvoice_Backcolorstyle ;
      private short subGridinvoicedetails_Backcolorstyle ;
      private short GRIDINVOICEDETAILS_nEOF ;
      private short nGXWrapped ;
      private short subGridinvoice_Backstyle ;
      private short subGridinvoicedetails_Backstyle ;
      private short subGridinvoice_Titlebackstyle ;
      private short subGridinvoice_Allowselection ;
      private short subGridinvoice_Allowhovering ;
      private short subGridinvoice_Allowcollapsing ;
      private short subGridinvoice_Collapsed ;
      private short subGridinvoicedetails_Titlebackstyle ;
      private short subGridinvoicedetails_Allowselection ;
      private short subGridinvoicedetails_Allowhovering ;
      private short subGridinvoicedetails_Allowcollapsing ;
      private short subGridinvoicedetails_Collapsed ;
      private int nRC_GXsfl_25 ;
      private int nRC_GXsfl_53 ;
      private int subGridinvoice_Rows ;
      private int nGXsfl_25_idx=1 ;
      private int AV31FilterNro ;
      private int nGXsfl_53_idx=1 ;
      private int AV30InvoiceId ;
      private int A15ProductId ;
      private int A26InvoiceDetailQuantity ;
      private int edtavFilternro_Enabled ;
      private int edtavFiltercreateddatefrom_Enabled ;
      private int edtavFiltercreateddateto_Enabled ;
      private int divTablecontent_Visible ;
      private int edtavMovementdescription_Enabled ;
      private int divTableinvoicedetails_Visible ;
      private int AV37GXV1 ;
      private int A20InvoiceId ;
      private int subGridinvoice_Islastpage ;
      private int subGridinvoicedetails_Islastpage ;
      private int edtavDetails_Enabled ;
      private int edtavCtlcode_Enabled ;
      private int edtavCtlname_Enabled ;
      private int edtavCtlquantity_Enabled ;
      private int edtavCtlunitprice_Enabled ;
      private int edtavCtlsubtotal_Enabled ;
      private int edtavCtlwholesaleprice_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A99UserId ;
      private int nGXsfl_53_fel_idx=1 ;
      private int nGXsfl_53_bak_idx=1 ;
      private int AV47GXV8 ;
      private int idxLst ;
      private int subGridinvoice_Backcolor ;
      private int subGridinvoice_Allbackcolor ;
      private int edtavCancelinvoice_Enabled ;
      private int edtavCancelinvoice_Visible ;
      private int edtavDetails_Visible ;
      private int subGridinvoicedetails_Backcolor ;
      private int subGridinvoicedetails_Allbackcolor ;
      private int subGridinvoice_Titlebackcolor ;
      private int subGridinvoice_Selectedindex ;
      private int subGridinvoice_Selectioncolor ;
      private int subGridinvoice_Hoveringcolor ;
      private int subGridinvoicedetails_Titlebackcolor ;
      private int subGridinvoicedetails_Selectedindex ;
      private int subGridinvoicedetails_Selectioncolor ;
      private int subGridinvoicedetails_Hoveringcolor ;
      private long GRIDINVOICE_nFirstRecordOnPage ;
      private long GRIDINVOICE_nCurrentRecord ;
      private long GRIDINVOICEDETAILS_nCurrentRecord ;
      private long GRIDINVOICE_nRecordCount ;
      private long GRIDINVOICEDETAILS_nFirstRecordOnPage ;
      private decimal A65InvoiceDetailHistoricPrice ;
      private decimal A80InvoiceTotalReceivable ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_25_idx="0001" ;
      private string sGXsfl_53_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divTablefilters_Internalname ;
      private string edtavFilternro_Internalname ;
      private string TempTags ;
      private string edtavFilternro_Jsonclick ;
      private string edtavFiltercreateddatefrom_Internalname ;
      private string edtavFiltercreateddatefrom_Jsonclick ;
      private string edtavFiltercreateddateto_Internalname ;
      private string edtavFiltercreateddateto_Jsonclick ;
      private string divTableinvoices_Internalname ;
      private string sStyleString ;
      private string subGridinvoice_Internalname ;
      private string divTablecontent_Internalname ;
      private string divTablebuttons_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string bttConfirmregister_Internalname ;
      private string bttConfirmregister_Jsonclick ;
      private string bttCancel_Internalname ;
      private string bttCancel_Jsonclick ;
      private string edtavMovementdescription_Internalname ;
      private string divTableinvoicedetails_Internalname ;
      private string subGridinvoicedetails_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavCancelinvoice_Internalname ;
      private string edtInvoiceId_Internalname ;
      private string edtInvoiceCreatedDate_Internalname ;
      private string edtInvoiceTotalReceivable_Internalname ;
      private string edtUserName_Internalname ;
      private string edtavDetails_Internalname ;
      private string edtavCtlcode_Internalname ;
      private string edtavCtlname_Internalname ;
      private string edtavCtlquantity_Internalname ;
      private string edtavCtlunitprice_Internalname ;
      private string edtavCtlsubtotal_Internalname ;
      private string edtavCtlwholesaleprice_Internalname ;
      private string scmdbuf ;
      private string sGXsfl_53_fel_idx="0001" ;
      private string edtavCancelinvoice_gximage ;
      private string sGXsfl_25_fel_idx="0001" ;
      private string subGridinvoice_Class ;
      private string subGridinvoice_Linesclass ;
      private string sImgUrl ;
      private string edtavCancelinvoice_Jsonclick ;
      private string ROClassString ;
      private string edtInvoiceId_Jsonclick ;
      private string edtInvoiceCreatedDate_Jsonclick ;
      private string edtInvoiceTotalReceivable_Jsonclick ;
      private string edtUserName_Jsonclick ;
      private string edtavDetails_Jsonclick ;
      private string subGridinvoicedetails_Class ;
      private string subGridinvoicedetails_Linesclass ;
      private string edtavCtlcode_Jsonclick ;
      private string edtavCtlname_Jsonclick ;
      private string edtavCtlquantity_Jsonclick ;
      private string edtavCtlunitprice_Jsonclick ;
      private string edtavCtlsubtotal_Jsonclick ;
      private string edtavCtlwholesaleprice_Jsonclick ;
      private string subGridinvoice_Header ;
      private string subGridinvoicedetails_Header ;
      private DateTime AV33FilterCreatedDateFrom ;
      private DateTime AV34FilterCreatedDateTo ;
      private DateTime A38InvoiceCreatedDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV20ControlInvoiceCancel ;
      private bool AV6AllOk ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_25_Refreshing=false ;
      private bool n80InvoiceTotalReceivable ;
      private bool bGXsfl_53_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool A94InvoiceActive ;
      private bool returnInSub ;
      private bool gx_BV53 ;
      private bool n55ProductCode ;
      private bool AV28CancelInvoice_IsBlob ;
      private string A55ProductCode ;
      private string A16ProductName ;
      private string AV7ErrorMessage ;
      private string AV19MovementDescription ;
      private string AV44Cancelinvoice_GXI ;
      private string A100UserName ;
      private string AV26Details ;
      private string AV28CancelInvoice ;
      private GXWebGrid GridinvoiceContainer ;
      private GXWebGrid GridinvoicedetailsContainer ;
      private GXWebRow GridinvoiceRow ;
      private GXWebRow GridinvoicedetailsRow ;
      private GXWebColumn GridinvoiceColumn ;
      private GXWebColumn GridinvoicedetailsColumn ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] H004K5_A99UserId ;
      private bool[] H004K5_A94InvoiceActive ;
      private string[] H004K5_A100UserName ;
      private DateTime[] H004K5_A38InvoiceCreatedDate ;
      private int[] H004K5_A20InvoiceId ;
      private decimal[] H004K5_A80InvoiceTotalReceivable ;
      private bool[] H004K5_n80InvoiceTotalReceivable ;
      private long[] H004K9_AGRIDINVOICE_nRecordCount ;
      private int[] H004K10_A20InvoiceId ;
      private int[] H004K11_A25InvoiceDetailId ;
      private int[] H004K11_A20InvoiceId ;
      private string[] H004K11_A55ProductCode ;
      private bool[] H004K11_n55ProductCode ;
      private int[] H004K11_A15ProductId ;
      private string[] H004K11_A16ProductName ;
      private int[] H004K11_A26InvoiceDetailQuantity ;
      private decimal[] H004K11_A65InvoiceDetailHistoricPrice ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem> AV15SDTCarProducts ;
      private GXWebForm Form ;
      private SdtInvoice AV9Invoice ;
      private SdtInvoice_Detail AV14InvoiceDetail ;
      private SdtMovement AV13Movement ;
      private SdtProduct AV11Product ;
      private SdtSDTCarProducts_SDTCarProductsItem AV18SDTCarProductsItem ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession GXt_SdtSDTContextSession1 ;
   }

   public class wpregistermovement__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H004K5( IGxContext context ,
                                             int AV31FilterNro ,
                                             DateTime AV33FilterCreatedDateFrom ,
                                             DateTime AV34FilterCreatedDateTo ,
                                             int A20InvoiceId ,
                                             DateTime A38InvoiceCreatedDate ,
                                             bool A94InvoiceActive )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[6];
         Object[] GXv_Object3 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[UserId], T1.[InvoiceActive], T2.[UserName], T1.[InvoiceCreatedDate], T1.[InvoiceId], COALESCE( T3.[InvoiceTotalReceivable], 0) AS InvoiceTotalReceivable";
         sFromString = " FROM (([Invoice] T1 INNER JOIN [User] T2 ON T2.[UserId] = T1.[UserId]) INNER JOIN (SELECT COALESCE( T6.[GXC1], 0) - COALESCE( T5.[GXC2], 0) + COALESCE( T5.[GXC3], 0) AS InvoiceTotalReceivable, T4.[InvoiceId] FROM (([Invoice] T4 LEFT JOIN (SELECT SUM([InvoicePaymentMethodDiscountIm]) AS GXC2, [InvoiceId], SUM([InvoicePaymentMethodRechargeIm]) AS GXC3 FROM [InvoicePaymentMethod] GROUP BY [InvoiceId] ) T5 ON T5.[InvoiceId] = T4.[InvoiceId]) LEFT JOIN (SELECT SUM([InvoiceDetailQuantity] * CAST([InvoiceDetailHistoricPrice] AS decimal( 28, 10))) AS GXC1, [InvoiceId] FROM [InvoiceDetail] GROUP BY [InvoiceId] ) T6 ON T6.[InvoiceId] = T4.[InvoiceId]) ) T3 ON T3.[InvoiceId] = T1.[InvoiceId])";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.[InvoiceActive] = 1)");
         if ( ! (0==AV31FilterNro) )
         {
            AddWhere(sWhereString, "(T1.[InvoiceId] = @AV31FilterNro)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV33FilterCreatedDateFrom) )
         {
            AddWhere(sWhereString, "(T1.[InvoiceCreatedDate] >= @AV33FilterCreatedDateFrom)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV34FilterCreatedDateTo) )
         {
            AddWhere(sWhereString, "(T1.[InvoiceCreatedDate] <= @AV34FilterCreatedDateTo)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         sOrderString += " ORDER BY T1.[InvoiceId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_H004K9( IGxContext context ,
                                             int AV31FilterNro ,
                                             DateTime AV33FilterCreatedDateFrom ,
                                             DateTime AV34FilterCreatedDateTo ,
                                             int A20InvoiceId ,
                                             DateTime A38InvoiceCreatedDate ,
                                             bool A94InvoiceActive )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[3];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (([Invoice] T1 INNER JOIN [User] T2 ON T2.[UserId] = T1.[UserId]) INNER JOIN (SELECT COALESCE( T6.[GXC1], 0) - COALESCE( T5.[GXC2], 0) + COALESCE( T5.[GXC3], 0) AS InvoiceTotalReceivable, T4.[InvoiceId] FROM (([Invoice] T4 LEFT JOIN (SELECT SUM([InvoicePaymentMethodDiscountIm]) AS GXC2, [InvoiceId], SUM([InvoicePaymentMethodRechargeIm]) AS GXC3 FROM [InvoicePaymentMethod] GROUP BY [InvoiceId] ) T5 ON T5.[InvoiceId] = T4.[InvoiceId]) LEFT JOIN (SELECT SUM([InvoiceDetailQuantity] * CAST([InvoiceDetailHistoricPrice] AS decimal( 28, 10))) AS GXC1, [InvoiceId] FROM [InvoiceDetail] GROUP BY [InvoiceId] ) T6 ON T6.[InvoiceId] = T4.[InvoiceId]) ) T3 ON T3.[InvoiceId] = T1.[InvoiceId])";
         AddWhere(sWhereString, "(T1.[InvoiceActive] = 1)");
         if ( ! (0==AV31FilterNro) )
         {
            AddWhere(sWhereString, "(T1.[InvoiceId] = @AV31FilterNro)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV33FilterCreatedDateFrom) )
         {
            AddWhere(sWhereString, "(T1.[InvoiceCreatedDate] >= @AV33FilterCreatedDateFrom)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV34FilterCreatedDateTo) )
         {
            AddWhere(sWhereString, "(T1.[InvoiceCreatedDate] <= @AV34FilterCreatedDateTo)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         scmdbuf += sWhereString;
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
                     return conditional_H004K5(context, (int)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (int)dynConstraints[3] , (DateTime)dynConstraints[4] , (bool)dynConstraints[5] );
               case 1 :
                     return conditional_H004K9(context, (int)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (int)dynConstraints[3] , (DateTime)dynConstraints[4] , (bool)dynConstraints[5] );
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
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH004K10;
          prmH004K10 = new Object[] {
          new ParDef("@AV30InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmH004K11;
          prmH004K11 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmH004K5;
          prmH004K5 = new Object[] {
          new ParDef("@AV31FilterNro",GXType.Int32,6,0) ,
          new ParDef("@AV33FilterCreatedDateFrom",GXType.Date,8,0) ,
          new ParDef("@AV34FilterCreatedDateTo",GXType.Date,8,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH004K9;
          prmH004K9 = new Object[] {
          new ParDef("@AV31FilterNro",GXType.Int32,6,0) ,
          new ParDef("@AV33FilterCreatedDateFrom",GXType.Date,8,0) ,
          new ParDef("@AV34FilterCreatedDateTo",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("H004K5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004K5,6, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004K9", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004K9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004K10", "SELECT TOP 1 [InvoiceId] FROM [Invoice] WHERE [InvoiceId] = @AV30InvoiceId ORDER BY [InvoiceId]  OPTION (FAST 1)",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004K10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H004K11", "SELECT T1.[InvoiceDetailId], T1.[InvoiceId], T2.[ProductCode], T1.[ProductId], T2.[ProductName], T1.[InvoiceDetailQuantity], T1.[InvoiceDetailHistoricPrice] FROM ([InvoiceDetail] T1 INNER JOIN [Product] T2 ON T2.[ProductId] = T1.[ProductId]) WHERE T1.[InvoiceId] = @InvoiceId ORDER BY T1.[InvoiceId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004K11,100, GxCacheFrequency.OFF ,false,false )
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
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((int[]) buf[4])[0] = rslt.getInt(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                return;
       }
    }

 }

}
