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
   public class wpregistersalenew : GXDataArea
   {
      public wpregistersalenew( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public wpregistersalenew( IGxContext context )
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid2") == 0 )
            {
               gxnrGrid2_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid2") == 0 )
            {
               gxgrGrid2_refresh_invoke( ) ;
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

      protected void gxnrGrid1_newrow_invoke( )
      {
         nRC_GXsfl_30 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_30"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_30_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_30_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_30_idx = GetPar( "sGXsfl_30_idx");
         AV9Delete = GetPar( "Delete");
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
         AV9Delete = GetPar( "Delete");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( AV9Delete) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid1_refresh_invoke */
      }

      protected void gxnrGrid2_newrow_invoke( )
      {
         nRC_GXsfl_46 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_46"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_46_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_46_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_46_idx = GetPar( "sGXsfl_46_idx");
         AV10Add = GetPar( "Add");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid2_newrow( ) ;
         /* End function gxnrGrid2_newrow_invoke */
      }

      protected void gxgrGrid2_refresh_invoke( )
      {
         AV10Add = GetPar( "Add");
         ajax_req_read_hidden_sdt(GetNextPar( ), AV8SDTCarProductsToCharge);
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid2_refresh( AV10Add, AV8SDTCarProductsToCharge) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid2_refresh_invoke */
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
         PA3U2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3U2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpregistersalenew.aspx") +"\">") ;
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
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Sdtcarproductstocharge", AV8SDTCarProductsToCharge);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Sdtcarproductstocharge", AV8SDTCarProductsToCharge);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Sdtcarproducts", AV6SDTCarProducts);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Sdtcarproducts", AV6SDTCarProducts);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_30", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_30), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_46", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_46), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTCARPRODUCTSTOCHARGE", AV8SDTCarProductsToCharge);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTCARPRODUCTSTOCHARGE", AV8SDTCarProductsToCharge);
         }
         GxWebStd.gx_hidden_field( context, "PRODUCTCODE", A55ProductCode);
         GxWebStd.gx_boolean_hidden_field( context, "PRODUCTACTIVE", A110ProductActive);
         GxWebStd.gx_boolean_hidden_field( context, "SUPPLIERACTIVE", A112SupplierActive);
         GxWebStd.gx_hidden_field( context, "PRODUCTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTCARPRODUCTSTOCHARGEITEM", AV14SDTCarProductsToChargeItem);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTCARPRODUCTSTOCHARGEITEM", AV14SDTCarProductsToChargeItem);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vALLOK", AV18AllOk);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTCARPRODUCTSITEM", AV17SDTCarProductsItem);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTCARPRODUCTSITEM", AV17SDTCarProductsItem);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vWASADDED", AV20WasAdded);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTCARPRODUCTS", AV6SDTCarProducts);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTCARPRODUCTS", AV6SDTCarProducts);
         }
         GxWebStd.gx_hidden_field( context, "vSUBTOTAL", StringUtil.LTrim( StringUtil.NToC( AV13Subtotal, 15, 2, ".", "")));
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
            WE3U2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3U2( ) ;
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
         return formatLink("wpregistersalenew.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WPRegisterSaleNew" ;
      }

      public override string GetPgmdesc( )
      {
         return "WPRegister Sale New" ;
      }

      protected void WB3U0( )
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
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, divTableinvoiceheader_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavInvoiceid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavInvoiceid_Internalname, "Nro", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'" + sGXsfl_30_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavInvoiceid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19InvoiceId), 6, 0, ".", "")), StringUtil.LTrim( ((edtavInvoiceid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV19InvoiceId), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV19InvoiceId), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,14);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavInvoiceid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavInvoiceid_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_WPRegisterSaleNew.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavInvoicecreateddate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavInvoicecreateddate_Internalname, "Date", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'" + sGXsfl_30_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavInvoicecreateddate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavInvoicecreateddate_Internalname, context.localUtil.Format(AV15InvoiceCreatedDate, "99/99/99"), context.localUtil.Format( AV15InvoiceCreatedDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,18);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavInvoicecreateddate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavInvoicecreateddate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_WPRegisterSaleNew.htm");
            GxWebStd.gx_bitmap( context, edtavInvoicecreateddate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavInvoicecreateddate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WPRegisterSaleNew.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavInvoicetotalreceivable_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavInvoicetotalreceivable_Internalname, "Total", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'" + sGXsfl_30_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavInvoicetotalreceivable_Internalname, StringUtil.LTrim( StringUtil.NToC( AV16InvoiceTotalReceivable, 18, 2, ".", "")), StringUtil.LTrim( ((edtavInvoicetotalreceivable_Enabled!=0) ? context.localUtil.Format( AV16InvoiceTotalReceivable, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV16InvoiceTotalReceivable, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavInvoicetotalreceivable_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavInvoicetotalreceivable_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_WPRegisterSaleNew.htm");
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
            context.WriteHtmlText( "<hr/>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableinvoicedetails_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl30( ) ;
         }
         if ( wbEnd == 30 )
         {
            wbEnd = 0;
            nRC_GXsfl_30 = (int)(nGXsfl_30_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV23GXV1 = nGXsfl_30_idx;
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
            context.WriteHtmlText( "<hr/>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid2Container.SetWrapped(nGXWrapped);
            StartGridControl46( ) ;
         }
         if ( wbEnd == 46 )
         {
            wbEnd = 0;
            nRC_GXsfl_46 = (int)(nGXsfl_46_idx-1);
            if ( Grid2Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV34GXV12 = nGXsfl_46_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid2Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid2", Grid2Container, subGrid2_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid2ContainerData", Grid2Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid2ContainerData"+"V", Grid2Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid2ContainerData"+"V"+"\" value='"+Grid2Container.GridValuesHidden()+"'/>") ;
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
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttConfirm_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(30), 2, 0)+","+"null"+");", "Confirm", bttConfirm_Jsonclick, 5, "Confirm", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CONFIRM\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPRegisterSaleNew.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(30), 2, 0)+","+"null"+");", "Cancel", bttCancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPRegisterSaleNew.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 30 )
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
                  AV23GXV1 = nGXsfl_30_idx;
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
         if ( wbEnd == 46 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid2Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV34GXV12 = nGXsfl_46_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid2Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid2", Grid2Container, subGrid2_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid2ContainerData", Grid2Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid2ContainerData"+"V", Grid2Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid2ContainerData"+"V"+"\" value='"+Grid2Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START3U2( )
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
            Form.Meta.addItem("description", "WPRegister Sale New", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3U0( ) ;
      }

      protected void WS3U2( )
      {
         START3U2( ) ;
         EVT3U2( ) ;
      }

      protected void EVT3U2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "'CONFIRM'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 28), "CTLCODE1.CONTROLVALUECHANGED") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "VADD.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "GRID2.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRID2.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "VADD.CLICK") == 0 ) )
                           {
                              nGXsfl_46_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_46_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_46_idx), 4, 0), 4, "0");
                              SubsflControlProps_464( ) ;
                              AV34GXV12 = nGXsfl_46_idx;
                              if ( ( AV8SDTCarProductsToCharge.Count >= AV34GXV12 ) && ( AV34GXV12 > 0 ) )
                              {
                                 AV8SDTCarProductsToCharge.CurrentItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV8SDTCarProductsToCharge.Item(AV34GXV12));
                                 AV10Add = cgiGet( edtavAdd_Internalname);
                                 AssignAttri("", false, edtavAdd_Internalname, AV10Add);
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "CTLCODE1.CONTROLVALUECHANGED") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E113U2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VADD.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E123U2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID2.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E133U2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID2.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E143U4 ();
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
                           else if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "VDELETE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 31), "CTLQUANTITY.CONTROLVALUECHANGED") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "GRID1.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRID1.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "VDELETE.CLICK") == 0 ) )
                           {
                              nGXsfl_30_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_30_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_30_idx), 4, 0), 4, "0");
                              SubsflControlProps_302( ) ;
                              AV23GXV1 = nGXsfl_30_idx;
                              if ( ( AV6SDTCarProducts.Count >= AV23GXV1 ) && ( AV23GXV1 > 0 ) )
                              {
                                 AV6SDTCarProducts.CurrentItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV6SDTCarProducts.Item(AV23GXV1));
                                 AV9Delete = cgiGet( edtavDelete_Internalname);
                                 AssignAttri("", false, edtavDelete_Internalname, AV9Delete);
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
                                    E153U2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VDELETE.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E163U2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "CTLQUANTITY.CONTROLVALUECHANGED") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E173U2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID1.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E183U2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID1.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E193U2 ();
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

      protected void WE3U2( )
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

      protected void PA3U2( )
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
               GX_FocusControl = edtavInvoiceid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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
         SubsflControlProps_302( ) ;
         while ( nGXsfl_30_idx <= nRC_GXsfl_30 )
         {
            sendrow_302( ) ;
            nGXsfl_30_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_30_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_30_idx+1);
            sGXsfl_30_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_30_idx), 4, 0), 4, "0");
            SubsflControlProps_302( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxnrGrid2_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_464( ) ;
         while ( nGXsfl_46_idx <= nRC_GXsfl_46 )
         {
            sendrow_464( ) ;
            nGXsfl_46_idx = ((subGrid2_Islastpage==1)&&(nGXsfl_46_idx+1>subGrid2_fnc_Recordsperpage( )) ? 1 : nGXsfl_46_idx+1);
            sGXsfl_46_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_46_idx), 4, 0), 4, "0");
            SubsflControlProps_464( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid2Container)) ;
         /* End function gxnrGrid2_newrow */
      }

      protected void gxgrGrid1_refresh( string AV9Delete )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF3U2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void gxgrGrid2_refresh( string AV10Add ,
                                        GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem> AV8SDTCarProductsToCharge )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID2_nCurrentRecord = 0;
         RF3U4( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid2_refresh */
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
         RF3U2( ) ;
         RF3U4( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavInvoiceid_Enabled = 0;
         AssignProp("", false, edtavInvoiceid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavInvoiceid_Enabled), 5, 0), true);
         edtavInvoicecreateddate_Enabled = 0;
         AssignProp("", false, edtavInvoicecreateddate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavInvoicecreateddate_Enabled), 5, 0), true);
         edtavInvoicetotalreceivable_Enabled = 0;
         AssignProp("", false, edtavInvoicetotalreceivable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavInvoicetotalreceivable_Enabled), 5, 0), true);
         edtavCtlid_Enabled = 0;
         AssignProp("", false, edtavCtlid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlid_Enabled), 5, 0), !bGXsfl_30_Refreshing);
         edtavCtlcode_Enabled = 0;
         AssignProp("", false, edtavCtlcode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcode_Enabled), 5, 0), !bGXsfl_30_Refreshing);
         edtavCtlname_Enabled = 0;
         AssignProp("", false, edtavCtlname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname_Enabled), 5, 0), !bGXsfl_30_Refreshing);
         edtavCtlstock_Enabled = 0;
         AssignProp("", false, edtavCtlstock_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlstock_Enabled), 5, 0), !bGXsfl_30_Refreshing);
         edtavCtlunitprice_Enabled = 0;
         AssignProp("", false, edtavCtlunitprice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlunitprice_Enabled), 5, 0), !bGXsfl_30_Refreshing);
         edtavCtlsubtotal_Enabled = 0;
         AssignProp("", false, edtavCtlsubtotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsubtotal_Enabled), 5, 0), !bGXsfl_30_Refreshing);
         edtavCtlretailprice_Enabled = 0;
         AssignProp("", false, edtavCtlretailprice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlretailprice_Enabled), 5, 0), !bGXsfl_30_Refreshing);
         edtavCtlwholesaleprice_Enabled = 0;
         AssignProp("", false, edtavCtlwholesaleprice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlwholesaleprice_Enabled), 5, 0), !bGXsfl_30_Refreshing);
         edtavCtlproductminiumquantitywholesale_Enabled = 0;
         AssignProp("", false, edtavCtlproductminiumquantitywholesale_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlproductminiumquantitywholesale_Enabled), 5, 0), !bGXsfl_30_Refreshing);
         edtavDelete_Enabled = 0;
         AssignProp("", false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_30_Refreshing);
         edtavCtlid1_Enabled = 0;
         AssignProp("", false, edtavCtlid1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlid1_Enabled), 5, 0), !bGXsfl_46_Refreshing);
         edtavCtlname1_Enabled = 0;
         AssignProp("", false, edtavCtlname1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname1_Enabled), 5, 0), !bGXsfl_46_Refreshing);
         edtavCtlstock1_Enabled = 0;
         AssignProp("", false, edtavCtlstock1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlstock1_Enabled), 5, 0), !bGXsfl_46_Refreshing);
         edtavCtlunitprice1_Enabled = 0;
         AssignProp("", false, edtavCtlunitprice1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlunitprice1_Enabled), 5, 0), !bGXsfl_46_Refreshing);
         edtavCtlsubtotal1_Enabled = 0;
         AssignProp("", false, edtavCtlsubtotal1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsubtotal1_Enabled), 5, 0), !bGXsfl_46_Refreshing);
         edtavCtlretailprice1_Enabled = 0;
         AssignProp("", false, edtavCtlretailprice1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlretailprice1_Enabled), 5, 0), !bGXsfl_46_Refreshing);
         edtavCtlwholesaleprice1_Enabled = 0;
         AssignProp("", false, edtavCtlwholesaleprice1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlwholesaleprice1_Enabled), 5, 0), !bGXsfl_46_Refreshing);
         edtavCtlproductminiumquantitywholesale1_Enabled = 0;
         AssignProp("", false, edtavCtlproductminiumquantitywholesale1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlproductminiumquantitywholesale1_Enabled), 5, 0), !bGXsfl_46_Refreshing);
         edtavAdd_Enabled = 0;
         AssignProp("", false, edtavAdd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAdd_Enabled), 5, 0), !bGXsfl_46_Refreshing);
      }

      protected void RF3U2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 30;
         E183U2 ();
         nGXsfl_30_idx = 1;
         sGXsfl_30_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_30_idx), 4, 0), 4, "0");
         SubsflControlProps_302( ) ;
         bGXsfl_30_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "Grid");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_302( ) ;
            E193U2 ();
            wbEnd = 30;
            WB3U0( ) ;
         }
         bGXsfl_30_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3U2( )
      {
      }

      protected void RF3U4( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid2Container.ClearRows();
         }
         wbStart = 46;
         E133U2 ();
         nGXsfl_46_idx = 1;
         sGXsfl_46_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_46_idx), 4, 0), 4, "0");
         SubsflControlProps_464( ) ;
         bGXsfl_46_Refreshing = true;
         Grid2Container.AddObjectProperty("GridName", "Grid2");
         Grid2Container.AddObjectProperty("CmpContext", "");
         Grid2Container.AddObjectProperty("InMasterPage", "false");
         Grid2Container.AddObjectProperty("Class", "Grid");
         Grid2Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid2Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid2Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Backcolorstyle), 1, 0, ".", "")));
         Grid2Container.PageSize = subGrid2_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_464( ) ;
            E143U4 ();
            wbEnd = 46;
            WB3U0( ) ;
         }
         bGXsfl_46_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3U4( )
      {
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected int subGrid2_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid2_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid2_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGrid2_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavInvoiceid_Enabled = 0;
         AssignProp("", false, edtavInvoiceid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavInvoiceid_Enabled), 5, 0), true);
         edtavInvoicecreateddate_Enabled = 0;
         AssignProp("", false, edtavInvoicecreateddate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavInvoicecreateddate_Enabled), 5, 0), true);
         edtavInvoicetotalreceivable_Enabled = 0;
         AssignProp("", false, edtavInvoicetotalreceivable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavInvoicetotalreceivable_Enabled), 5, 0), true);
         edtavCtlid_Enabled = 0;
         AssignProp("", false, edtavCtlid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlid_Enabled), 5, 0), !bGXsfl_30_Refreshing);
         edtavCtlcode_Enabled = 0;
         AssignProp("", false, edtavCtlcode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcode_Enabled), 5, 0), !bGXsfl_30_Refreshing);
         edtavCtlname_Enabled = 0;
         AssignProp("", false, edtavCtlname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname_Enabled), 5, 0), !bGXsfl_30_Refreshing);
         edtavCtlstock_Enabled = 0;
         AssignProp("", false, edtavCtlstock_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlstock_Enabled), 5, 0), !bGXsfl_30_Refreshing);
         edtavCtlunitprice_Enabled = 0;
         AssignProp("", false, edtavCtlunitprice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlunitprice_Enabled), 5, 0), !bGXsfl_30_Refreshing);
         edtavCtlsubtotal_Enabled = 0;
         AssignProp("", false, edtavCtlsubtotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsubtotal_Enabled), 5, 0), !bGXsfl_30_Refreshing);
         edtavCtlretailprice_Enabled = 0;
         AssignProp("", false, edtavCtlretailprice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlretailprice_Enabled), 5, 0), !bGXsfl_30_Refreshing);
         edtavCtlwholesaleprice_Enabled = 0;
         AssignProp("", false, edtavCtlwholesaleprice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlwholesaleprice_Enabled), 5, 0), !bGXsfl_30_Refreshing);
         edtavCtlproductminiumquantitywholesale_Enabled = 0;
         AssignProp("", false, edtavCtlproductminiumquantitywholesale_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlproductminiumquantitywholesale_Enabled), 5, 0), !bGXsfl_30_Refreshing);
         edtavDelete_Enabled = 0;
         AssignProp("", false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_30_Refreshing);
         edtavCtlid1_Enabled = 0;
         AssignProp("", false, edtavCtlid1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlid1_Enabled), 5, 0), !bGXsfl_46_Refreshing);
         edtavCtlname1_Enabled = 0;
         AssignProp("", false, edtavCtlname1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname1_Enabled), 5, 0), !bGXsfl_46_Refreshing);
         edtavCtlstock1_Enabled = 0;
         AssignProp("", false, edtavCtlstock1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlstock1_Enabled), 5, 0), !bGXsfl_46_Refreshing);
         edtavCtlunitprice1_Enabled = 0;
         AssignProp("", false, edtavCtlunitprice1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlunitprice1_Enabled), 5, 0), !bGXsfl_46_Refreshing);
         edtavCtlsubtotal1_Enabled = 0;
         AssignProp("", false, edtavCtlsubtotal1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsubtotal1_Enabled), 5, 0), !bGXsfl_46_Refreshing);
         edtavCtlretailprice1_Enabled = 0;
         AssignProp("", false, edtavCtlretailprice1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlretailprice1_Enabled), 5, 0), !bGXsfl_46_Refreshing);
         edtavCtlwholesaleprice1_Enabled = 0;
         AssignProp("", false, edtavCtlwholesaleprice1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlwholesaleprice1_Enabled), 5, 0), !bGXsfl_46_Refreshing);
         edtavCtlproductminiumquantitywholesale1_Enabled = 0;
         AssignProp("", false, edtavCtlproductminiumquantitywholesale1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlproductminiumquantitywholesale1_Enabled), 5, 0), !bGXsfl_46_Refreshing);
         edtavAdd_Enabled = 0;
         AssignProp("", false, edtavAdd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAdd_Enabled), 5, 0), !bGXsfl_46_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3U0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E153U2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Sdtcarproductstocharge"), AV8SDTCarProductsToCharge);
            ajax_req_read_hidden_sdt(cgiGet( "Sdtcarproducts"), AV6SDTCarProducts);
            ajax_req_read_hidden_sdt(cgiGet( "vSDTCARPRODUCTSITEM"), AV17SDTCarProductsItem);
            ajax_req_read_hidden_sdt(cgiGet( "vSDTCARPRODUCTSTOCHARGE"), AV8SDTCarProductsToCharge);
            ajax_req_read_hidden_sdt(cgiGet( "vSDTCARPRODUCTSTOCHARGEITEM"), AV14SDTCarProductsToChargeItem);
            /* Read saved values. */
            nRC_GXsfl_30 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_30"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_46 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_46"), ".", ","), 18, MidpointRounding.ToEven));
            AV18AllOk = StringUtil.StrToBool( cgiGet( "vALLOK"));
            AV13Subtotal = context.localUtil.CToN( cgiGet( "vSUBTOTAL"), ".", ",");
            nRC_GXsfl_30 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_30"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_30_fel_idx = 0;
            while ( nGXsfl_30_fel_idx < nRC_GXsfl_30 )
            {
               nGXsfl_30_fel_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_30_fel_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_30_fel_idx+1);
               sGXsfl_30_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_30_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_302( ) ;
               AV23GXV1 = nGXsfl_30_fel_idx;
               if ( ( AV6SDTCarProducts.Count >= AV23GXV1 ) && ( AV23GXV1 > 0 ) )
               {
                  AV6SDTCarProducts.CurrentItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV6SDTCarProducts.Item(AV23GXV1));
                  AV9Delete = cgiGet( edtavDelete_Internalname);
               }
            }
            if ( nGXsfl_30_fel_idx == 0 )
            {
               nGXsfl_30_idx = 1;
               sGXsfl_30_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_30_idx), 4, 0), 4, "0");
               SubsflControlProps_302( ) ;
            }
            nGXsfl_30_fel_idx = 1;
            nRC_GXsfl_46 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_46"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_46_fel_idx = 0;
            while ( nGXsfl_46_fel_idx < nRC_GXsfl_46 )
            {
               nGXsfl_46_fel_idx = ((subGrid2_Islastpage==1)&&(nGXsfl_46_fel_idx+1>subGrid2_fnc_Recordsperpage( )) ? 1 : nGXsfl_46_fel_idx+1);
               sGXsfl_46_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_46_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_464( ) ;
               AV34GXV12 = nGXsfl_46_fel_idx;
               if ( ( AV8SDTCarProductsToCharge.Count >= AV34GXV12 ) && ( AV34GXV12 > 0 ) )
               {
                  AV8SDTCarProductsToCharge.CurrentItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV8SDTCarProductsToCharge.Item(AV34GXV12));
                  AV10Add = cgiGet( edtavAdd_Internalname);
               }
            }
            if ( nGXsfl_46_fel_idx == 0 )
            {
               nGXsfl_46_idx = 1;
               sGXsfl_46_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_46_idx), 4, 0), 4, "0");
               SubsflControlProps_464( ) ;
            }
            nGXsfl_46_fel_idx = 1;
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavInvoiceid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavInvoiceid_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vINVOICEID");
               GX_FocusControl = edtavInvoiceid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV19InvoiceId = 0;
               AssignAttri("", false, "AV19InvoiceId", StringUtil.LTrimStr( (decimal)(AV19InvoiceId), 6, 0));
            }
            else
            {
               AV19InvoiceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavInvoiceid_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV19InvoiceId", StringUtil.LTrimStr( (decimal)(AV19InvoiceId), 6, 0));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavInvoicecreateddate_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Invoice Created Date"}), 1, "vINVOICECREATEDDATE");
               GX_FocusControl = edtavInvoicecreateddate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV15InvoiceCreatedDate = DateTime.MinValue;
               AssignAttri("", false, "AV15InvoiceCreatedDate", context.localUtil.Format(AV15InvoiceCreatedDate, "99/99/99"));
            }
            else
            {
               AV15InvoiceCreatedDate = context.localUtil.CToD( cgiGet( edtavInvoicecreateddate_Internalname), 1);
               AssignAttri("", false, "AV15InvoiceCreatedDate", context.localUtil.Format(AV15InvoiceCreatedDate, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavInvoicetotalreceivable_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavInvoicetotalreceivable_Internalname), ".", ",") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vINVOICETOTALRECEIVABLE");
               GX_FocusControl = edtavInvoicetotalreceivable_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV16InvoiceTotalReceivable = 0;
               AssignAttri("", false, "AV16InvoiceTotalReceivable", StringUtil.LTrimStr( AV16InvoiceTotalReceivable, 18, 2));
            }
            else
            {
               AV16InvoiceTotalReceivable = context.localUtil.CToN( cgiGet( edtavInvoicetotalreceivable_Internalname), ".", ",");
               AssignAttri("", false, "AV16InvoiceTotalReceivable", StringUtil.LTrimStr( AV16InvoiceTotalReceivable, 18, 2));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E153U2 ();
         if (returnInSub) return;
      }

      protected void E153U2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV10Add = "";
         AssignAttri("", false, edtavAdd_Internalname, AV10Add);
         AV9Delete = "";
         AssignAttri("", false, edtavDelete_Internalname, AV9Delete);
         AV16InvoiceTotalReceivable = 0;
         AssignAttri("", false, "AV16InvoiceTotalReceivable", StringUtil.LTrimStr( AV16InvoiceTotalReceivable, 18, 2));
         AV15InvoiceCreatedDate = DateTimeUtil.ServerDate( context, pr_default);
         AssignAttri("", false, "AV15InvoiceCreatedDate", context.localUtil.Format(AV15InvoiceCreatedDate, "99/99/99"));
         GXt_int1 = AV19InvoiceId;
         new invoicegetlastid(context ).execute( out  GXt_int1) ;
         AV19InvoiceId = GXt_int1;
         AssignAttri("", false, "AV19InvoiceId", StringUtil.LTrimStr( (decimal)(AV19InvoiceId), 6, 0));
         /* Execute user subroutine: 'RESTARTPRODUCTTOCHARGE' */
         S112 ();
         if (returnInSub) return;
         GX_FocusControl = edtavCtlcode1_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         context.DoAjaxSetFocus(GX_FocusControl);
      }

      protected void E113U2( )
      {
         AV34GXV12 = nGXsfl_46_idx;
         if ( ( AV34GXV12 > 0 ) && ( AV8SDTCarProductsToCharge.Count >= AV34GXV12 ) )
         {
            AV8SDTCarProductsToCharge.CurrentItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV8SDTCarProductsToCharge.Item(AV34GXV12));
         }
         /* Ctlcode1_Controlvaluechanged Routine */
         returnInSub = false;
         AV7ProductCode = ((SdtSDTCarProducts_SDTCarProductsItem)(AV8SDTCarProductsToCharge.CurrentItem)).gxTpr_Code;
         AssignAttri("", false, "AV7ProductCode", AV7ProductCode);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7ProductCode)) )
         {
            AV45GXLvl16 = 0;
            /* Using cursor H003U2 */
            pr_default.execute(0, new Object[] {AV7ProductCode});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A4SupplierId = H003U2_A4SupplierId[0];
               A112SupplierActive = H003U2_A112SupplierActive[0];
               A110ProductActive = H003U2_A110ProductActive[0];
               n110ProductActive = H003U2_n110ProductActive[0];
               A55ProductCode = H003U2_A55ProductCode[0];
               n55ProductCode = H003U2_n55ProductCode[0];
               A15ProductId = H003U2_A15ProductId[0];
               A112SupplierActive = H003U2_A112SupplierActive[0];
               AV45GXLvl16 = 1;
               GXt_SdtSDTCarProducts_SDTCarProductsItem2 = AV14SDTCarProductsToChargeItem;
               new registersalechargeproduct(context ).execute(  A15ProductId, out  GXt_SdtSDTCarProducts_SDTCarProductsItem2) ;
               AV14SDTCarProductsToChargeItem = GXt_SdtSDTCarProducts_SDTCarProductsItem2;
               /* Execute user subroutine: 'LOADPRODUCTTOCHARGE' */
               S123 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'CALCULATESUBTOTALTOCHARGE' */
               S133 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  returnInSub = true;
                  if (true) return;
               }
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(0);
            }
            pr_default.close(0);
            if ( AV45GXLvl16 == 0 )
            {
               ((SdtSDTCarProducts_SDTCarProductsItem)(AV8SDTCarProductsToCharge.CurrentItem)).gxTpr_Id = 0;
               ((SdtSDTCarProducts_SDTCarProductsItem)(AV8SDTCarProductsToCharge.CurrentItem)).gxTpr_Name = "Product Not Found";
            }
            context.DoAjaxRefresh();
         }
         else
         {
            ((SdtSDTCarProducts_SDTCarProductsItem)(AV8SDTCarProductsToCharge.CurrentItem)).gxTpr_Id = 0;
            ((SdtSDTCarProducts_SDTCarProductsItem)(AV8SDTCarProductsToCharge.CurrentItem)).gxTpr_Name = "Product Not Found";
            context.DoAjaxRefresh();
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14SDTCarProductsToChargeItem", AV14SDTCarProductsToChargeItem);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV8SDTCarProductsToCharge", AV8SDTCarProductsToCharge);
         nGXsfl_46_bak_idx = nGXsfl_46_idx;
         gxgrGrid2_refresh( AV10Add, AV8SDTCarProductsToCharge) ;
         nGXsfl_46_idx = nGXsfl_46_bak_idx;
         sGXsfl_46_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_46_idx), 4, 0), 4, "0");
         SubsflControlProps_464( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17SDTCarProductsItem", AV17SDTCarProductsItem);
      }

      protected void E123U2( )
      {
         AV23GXV1 = nGXsfl_30_idx;
         if ( ( AV23GXV1 > 0 ) && ( AV6SDTCarProducts.Count >= AV23GXV1 ) )
         {
            AV6SDTCarProducts.CurrentItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV6SDTCarProducts.Item(AV23GXV1));
         }
         AV34GXV12 = nGXsfl_46_idx;
         if ( ( AV34GXV12 > 0 ) && ( AV8SDTCarProductsToCharge.Count >= AV34GXV12 ) )
         {
            AV8SDTCarProductsToCharge.CurrentItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV8SDTCarProductsToCharge.Item(AV34GXV12));
         }
         /* Add_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CONTROLWASADDED' */
         S142 ();
         if (returnInSub) return;
         if ( ( ((SdtSDTCarProducts_SDTCarProductsItem)(AV8SDTCarProductsToCharge.CurrentItem)).gxTpr_Id != 0 ) && ! AV20WasAdded )
         {
            AV14SDTCarProductsToChargeItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV8SDTCarProductsToCharge.Item(1));
            AV6SDTCarProducts.Add(AV14SDTCarProductsToChargeItem, 0);
            gx_BV30 = true;
            /* Execute user subroutine: 'CALCULATETOTAL' */
            S152 ();
            if (returnInSub) return;
            /* Execute user subroutine: 'RESTARTPRODUCTTOCHARGE' */
            S112 ();
            if (returnInSub) return;
            GX_FocusControl = edtavCtlcode1_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            context.DoAjaxSetFocus(GX_FocusControl);
            context.DoAjaxRefresh();
         }
         else
         {
            if ( ((SdtSDTCarProducts_SDTCarProductsItem)(AV8SDTCarProductsToCharge.CurrentItem)).gxTpr_Id == 0 )
            {
               GX_msglist.addItem("Choose Product First");
            }
            else
            {
               GX_msglist.addItem("Product was added, please modify quantity from products added");
               GX_FocusControl = edtavCtlquantity_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               context.DoAjaxSetFocus(GX_FocusControl);
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14SDTCarProductsToChargeItem", AV14SDTCarProductsToChargeItem);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6SDTCarProducts", AV6SDTCarProducts);
         nGXsfl_30_bak_idx = nGXsfl_30_idx;
         gxgrGrid1_refresh( AV9Delete) ;
         nGXsfl_30_idx = nGXsfl_30_bak_idx;
         sGXsfl_30_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_30_idx), 4, 0), 4, "0");
         SubsflControlProps_302( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17SDTCarProductsItem", AV17SDTCarProductsItem);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV8SDTCarProductsToCharge", AV8SDTCarProductsToCharge);
         nGXsfl_46_bak_idx = nGXsfl_46_idx;
         gxgrGrid2_refresh( AV10Add, AV8SDTCarProductsToCharge) ;
         nGXsfl_46_idx = nGXsfl_46_bak_idx;
         sGXsfl_46_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_46_idx), 4, 0), 4, "0");
         SubsflControlProps_464( ) ;
      }

      protected void E163U2( )
      {
         AV23GXV1 = nGXsfl_30_idx;
         if ( ( AV23GXV1 > 0 ) && ( AV6SDTCarProducts.Count >= AV23GXV1 ) )
         {
            AV6SDTCarProducts.CurrentItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV6SDTCarProducts.Item(AV23GXV1));
         }
         /* Delete_Click Routine */
         returnInSub = false;
         AV12Position = (short)(AV6SDTCarProducts.IndexOf(((SdtSDTCarProducts_SDTCarProductsItem)(AV6SDTCarProducts.CurrentItem))));
         if ( AV12Position != 0 )
         {
            AV6SDTCarProducts.RemoveItem(AV12Position);
            gx_BV30 = true;
            /* Execute user subroutine: 'CALCULATETOTAL' */
            S152 ();
            if (returnInSub) return;
            context.DoAjaxRefresh();
         }
         else
         {
            GX_msglist.addItem("Error, Position: "+StringUtil.Str( (decimal)(AV12Position), 4, 0));
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6SDTCarProducts", AV6SDTCarProducts);
         nGXsfl_30_bak_idx = nGXsfl_30_idx;
         gxgrGrid1_refresh( AV9Delete) ;
         nGXsfl_30_idx = nGXsfl_30_bak_idx;
         sGXsfl_30_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_30_idx), 4, 0), 4, "0");
         SubsflControlProps_302( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17SDTCarProductsItem", AV17SDTCarProductsItem);
      }

      protected void E173U2( )
      {
         AV23GXV1 = nGXsfl_30_idx;
         if ( ( AV23GXV1 > 0 ) && ( AV6SDTCarProducts.Count >= AV23GXV1 ) )
         {
            AV6SDTCarProducts.CurrentItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV6SDTCarProducts.Item(AV23GXV1));
         }
         /* Ctlquantity_Controlvaluechanged Routine */
         returnInSub = false;
         AV17SDTCarProductsItem = ((SdtSDTCarProducts_SDTCarProductsItem)(AV6SDTCarProducts.CurrentItem));
         /* Execute user subroutine: 'CONTROLQUANTITY' */
         S162 ();
         if (returnInSub) return;
         if ( AV18AllOk )
         {
            if ( AV17SDTCarProductsItem.gxTpr_Quantity >= AV17SDTCarProductsItem.gxTpr_Productminiumquantitywholesale )
            {
               ((SdtSDTCarProducts_SDTCarProductsItem)(AV6SDTCarProducts.CurrentItem)).gxTpr_Subtotal = (decimal)(AV17SDTCarProductsItem.gxTpr_Quantity*AV17SDTCarProductsItem.gxTpr_Wholesaleprice);
            }
            else
            {
               ((SdtSDTCarProducts_SDTCarProductsItem)(AV6SDTCarProducts.CurrentItem)).gxTpr_Subtotal = (decimal)(AV17SDTCarProductsItem.gxTpr_Quantity*AV17SDTCarProductsItem.gxTpr_Retailprice);
            }
            /* Execute user subroutine: 'CALCULATETOTAL' */
            S152 ();
            if (returnInSub) return;
            GX_FocusControl = edtavCtlcode1_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            context.DoAjaxSetFocus(GX_FocusControl);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17SDTCarProductsItem", AV17SDTCarProductsItem);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6SDTCarProducts", AV6SDTCarProducts);
         nGXsfl_30_bak_idx = nGXsfl_30_idx;
         gxgrGrid1_refresh( AV9Delete) ;
         nGXsfl_30_idx = nGXsfl_30_bak_idx;
         sGXsfl_30_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_30_idx), 4, 0), 4, "0");
         SubsflControlProps_302( ) ;
      }

      protected void E133U2( )
      {
         AV34GXV12 = nGXsfl_46_idx;
         if ( ( AV34GXV12 > 0 ) && ( AV8SDTCarProductsToCharge.Count >= AV34GXV12 ) )
         {
            AV8SDTCarProductsToCharge.CurrentItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV8SDTCarProductsToCharge.Item(AV34GXV12));
         }
         /* Grid2_Refresh Routine */
         returnInSub = false;
         if ( ((SdtSDTCarProducts_SDTCarProductsItem)AV8SDTCarProductsToCharge.Item(1)).gxTpr_Id != 0 )
         {
            AV10Add = "Add";
            AssignAttri("", false, edtavAdd_Internalname, AV10Add);
         }
         else
         {
            AV10Add = "";
            AssignAttri("", false, edtavAdd_Internalname, AV10Add);
         }
         /*  Sending Event outputs  */
      }

      protected void E183U2( )
      {
         /* Grid1_Refresh Routine */
         returnInSub = false;
         AV9Delete = "Delete";
         AssignAttri("", false, edtavDelete_Internalname, AV9Delete);
         /*  Sending Event outputs  */
      }

      protected void S133( )
      {
         /* 'CALCULATESUBTOTALTOCHARGE' Routine */
         returnInSub = false;
         AV17SDTCarProductsItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV8SDTCarProductsToCharge.Item(1));
         /* Execute user subroutine: 'CONTROLQUANTITY' */
         S162 ();
         if (returnInSub) return;
         if ( AV18AllOk )
         {
            AV14SDTCarProductsToChargeItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV8SDTCarProductsToCharge.Item(1));
            if ( AV14SDTCarProductsToChargeItem.gxTpr_Id != 0 )
            {
               if ( AV14SDTCarProductsToChargeItem.gxTpr_Quantity >= AV14SDTCarProductsToChargeItem.gxTpr_Productminiumquantitywholesale )
               {
                  AV13Subtotal = (decimal)(AV14SDTCarProductsToChargeItem.gxTpr_Quantity*AV14SDTCarProductsToChargeItem.gxTpr_Wholesaleprice);
               }
               else
               {
                  AV13Subtotal = (decimal)(AV14SDTCarProductsToChargeItem.gxTpr_Quantity*AV14SDTCarProductsToChargeItem.gxTpr_Retailprice);
               }
               AV14SDTCarProductsToChargeItem.gxTpr_Subtotal = AV13Subtotal;
            }
         }
      }

      protected void S152( )
      {
         /* 'CALCULATETOTAL' Routine */
         returnInSub = false;
         AV16InvoiceTotalReceivable = 0;
         AssignAttri("", false, "AV16InvoiceTotalReceivable", StringUtil.LTrimStr( AV16InvoiceTotalReceivable, 18, 2));
         AV46GXV23 = 1;
         while ( AV46GXV23 <= AV6SDTCarProducts.Count )
         {
            AV17SDTCarProductsItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV6SDTCarProducts.Item(AV46GXV23));
            AV16InvoiceTotalReceivable = (decimal)(AV16InvoiceTotalReceivable+(AV17SDTCarProductsItem.gxTpr_Subtotal));
            AssignAttri("", false, "AV16InvoiceTotalReceivable", StringUtil.LTrimStr( AV16InvoiceTotalReceivable, 18, 2));
            AV46GXV23 = (int)(AV46GXV23+1);
         }
      }

      protected void S112( )
      {
         /* 'RESTARTPRODUCTTOCHARGE' Routine */
         returnInSub = false;
         AV14SDTCarProductsToChargeItem = new SdtSDTCarProducts_SDTCarProductsItem(context);
         AV8SDTCarProductsToCharge.Clear();
         gx_BV46 = true;
         AV8SDTCarProductsToCharge.Add(AV14SDTCarProductsToChargeItem, 0);
         gx_BV46 = true;
      }

      protected void S123( )
      {
         /* 'LOADPRODUCTTOCHARGE' Routine */
         returnInSub = false;
         ((SdtSDTCarProducts_SDTCarProductsItem)AV8SDTCarProductsToCharge.Item(1)).gxTpr_Id = AV14SDTCarProductsToChargeItem.gxTpr_Id;
         ((SdtSDTCarProducts_SDTCarProductsItem)AV8SDTCarProductsToCharge.Item(1)).gxTpr_Name = AV14SDTCarProductsToChargeItem.gxTpr_Name;
         ((SdtSDTCarProducts_SDTCarProductsItem)AV8SDTCarProductsToCharge.Item(1)).gxTpr_Quantity = 1;
         ((SdtSDTCarProducts_SDTCarProductsItem)AV8SDTCarProductsToCharge.Item(1)).gxTpr_Stock = AV14SDTCarProductsToChargeItem.gxTpr_Stock;
         ((SdtSDTCarProducts_SDTCarProductsItem)AV8SDTCarProductsToCharge.Item(1)).gxTpr_Unitprice = AV14SDTCarProductsToChargeItem.gxTpr_Unitprice;
         ((SdtSDTCarProducts_SDTCarProductsItem)AV8SDTCarProductsToCharge.Item(1)).gxTpr_Retailprice = AV14SDTCarProductsToChargeItem.gxTpr_Retailprice;
         ((SdtSDTCarProducts_SDTCarProductsItem)AV8SDTCarProductsToCharge.Item(1)).gxTpr_Wholesaleprice = AV14SDTCarProductsToChargeItem.gxTpr_Wholesaleprice;
         ((SdtSDTCarProducts_SDTCarProductsItem)AV8SDTCarProductsToCharge.Item(1)).gxTpr_Subtotal = AV14SDTCarProductsToChargeItem.gxTpr_Unitprice;
         ((SdtSDTCarProducts_SDTCarProductsItem)AV8SDTCarProductsToCharge.Item(1)).gxTpr_Productminiumquantitywholesale = AV14SDTCarProductsToChargeItem.gxTpr_Productminiumquantitywholesale;
      }

      protected void S162( )
      {
         /* 'CONTROLQUANTITY' Routine */
         returnInSub = false;
         if ( AV17SDTCarProductsItem.gxTpr_Quantity <= AV17SDTCarProductsItem.gxTpr_Stock )
         {
            AV18AllOk = true;
            AssignAttri("", false, "AV18AllOk", AV18AllOk);
         }
         else
         {
            AV18AllOk = false;
            AssignAttri("", false, "AV18AllOk", AV18AllOk);
            GX_msglist.addItem("Quantity must be less or equal to Current Stock");
         }
      }

      protected void S142( )
      {
         /* 'CONTROLWASADDED' Routine */
         returnInSub = false;
         AV20WasAdded = false;
         AssignAttri("", false, "AV20WasAdded", AV20WasAdded);
         AV47GXV24 = 1;
         while ( AV47GXV24 <= AV6SDTCarProducts.Count )
         {
            AV17SDTCarProductsItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV6SDTCarProducts.Item(AV47GXV24));
            if ( AV17SDTCarProductsItem.gxTpr_Id == ((SdtSDTCarProducts_SDTCarProductsItem)AV8SDTCarProductsToCharge.Item(1)).gxTpr_Id )
            {
               AV20WasAdded = true;
               AssignAttri("", false, "AV20WasAdded", AV20WasAdded);
               if (true) break;
            }
            AV47GXV24 = (int)(AV47GXV24+1);
         }
      }

      private void E193U2( )
      {
         /* Grid1_Load Routine */
         returnInSub = false;
         AV23GXV1 = 1;
         while ( AV23GXV1 <= AV6SDTCarProducts.Count )
         {
            AV6SDTCarProducts.CurrentItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV6SDTCarProducts.Item(AV23GXV1));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 30;
            }
            sendrow_302( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_30_Refreshing )
            {
               DoAjaxLoad(30, Grid1Row);
            }
            AV23GXV1 = (int)(AV23GXV1+1);
         }
      }

      private void E143U4( )
      {
         /* Grid2_Load Routine */
         returnInSub = false;
         AV34GXV12 = 1;
         while ( AV34GXV12 <= AV8SDTCarProductsToCharge.Count )
         {
            AV8SDTCarProductsToCharge.CurrentItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV8SDTCarProductsToCharge.Item(AV34GXV12));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 46;
            }
            sendrow_464( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_46_Refreshing )
            {
               DoAjaxLoad(46, Grid2Row);
            }
            AV34GXV12 = (int)(AV34GXV12+1);
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
         PA3U2( ) ;
         WS3U2( ) ;
         WE3U2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202411152134595", true, true);
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
         context.AddJavascriptSource("wpregistersalenew.js", "?202411152134595", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_302( )
      {
         edtavCtlid_Internalname = "CTLID_"+sGXsfl_30_idx;
         edtavCtlcode_Internalname = "CTLCODE_"+sGXsfl_30_idx;
         edtavCtlname_Internalname = "CTLNAME_"+sGXsfl_30_idx;
         edtavCtlstock_Internalname = "CTLSTOCK_"+sGXsfl_30_idx;
         edtavCtlquantity_Internalname = "CTLQUANTITY_"+sGXsfl_30_idx;
         edtavCtlunitprice_Internalname = "CTLUNITPRICE_"+sGXsfl_30_idx;
         edtavCtlsubtotal_Internalname = "CTLSUBTOTAL_"+sGXsfl_30_idx;
         edtavCtlretailprice_Internalname = "CTLRETAILPRICE_"+sGXsfl_30_idx;
         edtavCtlwholesaleprice_Internalname = "CTLWHOLESALEPRICE_"+sGXsfl_30_idx;
         edtavCtlproductminiumquantitywholesale_Internalname = "CTLPRODUCTMINIUMQUANTITYWHOLESALE_"+sGXsfl_30_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_30_idx;
      }

      protected void SubsflControlProps_fel_302( )
      {
         edtavCtlid_Internalname = "CTLID_"+sGXsfl_30_fel_idx;
         edtavCtlcode_Internalname = "CTLCODE_"+sGXsfl_30_fel_idx;
         edtavCtlname_Internalname = "CTLNAME_"+sGXsfl_30_fel_idx;
         edtavCtlstock_Internalname = "CTLSTOCK_"+sGXsfl_30_fel_idx;
         edtavCtlquantity_Internalname = "CTLQUANTITY_"+sGXsfl_30_fel_idx;
         edtavCtlunitprice_Internalname = "CTLUNITPRICE_"+sGXsfl_30_fel_idx;
         edtavCtlsubtotal_Internalname = "CTLSUBTOTAL_"+sGXsfl_30_fel_idx;
         edtavCtlretailprice_Internalname = "CTLRETAILPRICE_"+sGXsfl_30_fel_idx;
         edtavCtlwholesaleprice_Internalname = "CTLWHOLESALEPRICE_"+sGXsfl_30_fel_idx;
         edtavCtlproductminiumquantitywholesale_Internalname = "CTLPRODUCTMINIUMQUANTITYWHOLESALE_"+sGXsfl_30_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_30_fel_idx;
      }

      protected void sendrow_302( )
      {
         SubsflControlProps_302( ) ;
         WB3U0( ) ;
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
            if ( ((int)((nGXsfl_30_idx) % (2))) == 0 )
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
            context.WriteHtmlText( " class=\""+"Grid"+"\" style=\""+""+"\"") ;
            context.WriteHtmlText( " gxrow=\""+sGXsfl_30_idx+"\">") ;
         }
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV6SDTCarProducts.Item(AV23GXV1)).gxTpr_Id), 6, 0, ".", "")),StringUtil.LTrim( ((edtavCtlid_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV6SDTCarProducts.Item(AV23GXV1)).gxTpr_Id), "ZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV6SDTCarProducts.Item(AV23GXV1)).gxTpr_Id), "ZZZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(int)edtavCtlid_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)30,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcode_Internalname,((SdtSDTCarProducts_SDTCarProductsItem)AV6SDTCarProducts.Item(AV23GXV1)).gxTpr_Code,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcode_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlcode_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)30,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname_Internalname,((SdtSDTCarProducts_SDTCarProductsItem)AV6SDTCarProducts.Item(AV23GXV1)).gxTpr_Name,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)30,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlstock_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV6SDTCarProducts.Item(AV23GXV1)).gxTpr_Stock), 6, 0, ".", "")),StringUtil.LTrim( ((edtavCtlstock_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV6SDTCarProducts.Item(AV23GXV1)).gxTpr_Stock), "ZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV6SDTCarProducts.Item(AV23GXV1)).gxTpr_Stock), "ZZZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlstock_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(int)edtavCtlstock_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)30,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavCtlquantity_Enabled!=0)&&(edtavCtlquantity_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 35,'',false,'"+sGXsfl_30_idx+"',30)\"" : " ");
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlquantity_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV6SDTCarProducts.Item(AV23GXV1)).gxTpr_Quantity), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV6SDTCarProducts.Item(AV23GXV1)).gxTpr_Quantity), "ZZZZZ9"))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+((edtavCtlquantity_Enabled!=0)&&(edtavCtlquantity_Visible!=0) ? " onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,35);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlquantity_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)1,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)30,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlunitprice_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTCarProducts_SDTCarProductsItem)AV6SDTCarProducts.Item(AV23GXV1)).gxTpr_Unitprice, 18, 2, ".", "")),StringUtil.LTrim( ((edtavCtlunitprice_Enabled!=0) ? context.localUtil.Format( ((SdtSDTCarProducts_SDTCarProductsItem)AV6SDTCarProducts.Item(AV23GXV1)).gxTpr_Unitprice, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTCarProducts_SDTCarProductsItem)AV6SDTCarProducts.Item(AV23GXV1)).gxTpr_Unitprice, "ZZZZZZZZZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlunitprice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlunitprice_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)30,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsubtotal_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTCarProducts_SDTCarProductsItem)AV6SDTCarProducts.Item(AV23GXV1)).gxTpr_Subtotal, 18, 2, ".", "")),StringUtil.LTrim( ((edtavCtlsubtotal_Enabled!=0) ? context.localUtil.Format( ((SdtSDTCarProducts_SDTCarProductsItem)AV6SDTCarProducts.Item(AV23GXV1)).gxTpr_Subtotal, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTCarProducts_SDTCarProductsItem)AV6SDTCarProducts.Item(AV23GXV1)).gxTpr_Subtotal, "ZZZZZZZZZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlsubtotal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlsubtotal_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)30,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlretailprice_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTCarProducts_SDTCarProductsItem)AV6SDTCarProducts.Item(AV23GXV1)).gxTpr_Retailprice, 18, 2, ".", "")),StringUtil.LTrim( ((edtavCtlretailprice_Enabled!=0) ? context.localUtil.Format( ((SdtSDTCarProducts_SDTCarProductsItem)AV6SDTCarProducts.Item(AV23GXV1)).gxTpr_Retailprice, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTCarProducts_SDTCarProductsItem)AV6SDTCarProducts.Item(AV23GXV1)).gxTpr_Retailprice, "ZZZZZZZZZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlretailprice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(int)edtavCtlretailprice_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)30,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlwholesaleprice_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTCarProducts_SDTCarProductsItem)AV6SDTCarProducts.Item(AV23GXV1)).gxTpr_Wholesaleprice, 18, 2, ".", "")),StringUtil.LTrim( ((edtavCtlwholesaleprice_Enabled!=0) ? context.localUtil.Format( ((SdtSDTCarProducts_SDTCarProductsItem)AV6SDTCarProducts.Item(AV23GXV1)).gxTpr_Wholesaleprice, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTCarProducts_SDTCarProductsItem)AV6SDTCarProducts.Item(AV23GXV1)).gxTpr_Wholesaleprice, "ZZZZZZZZZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlwholesaleprice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(int)edtavCtlwholesaleprice_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)30,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlproductminiumquantitywholesale_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV6SDTCarProducts.Item(AV23GXV1)).gxTpr_Productminiumquantitywholesale), 4, 0, ".", "")),StringUtil.LTrim( ((edtavCtlproductminiumquantitywholesale_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV6SDTCarProducts.Item(AV23GXV1)).gxTpr_Productminiumquantitywholesale), "ZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV6SDTCarProducts.Item(AV23GXV1)).gxTpr_Productminiumquantitywholesale), "ZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlproductminiumquantitywholesale_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlproductminiumquantitywholesale_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)30,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavDelete_Enabled!=0)&&(edtavDelete_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 41,'',false,'"+sGXsfl_30_idx+"',30)\"" : " ");
         ROClassString = "TextActionAttribute TextLikeLink";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,(string)AV9Delete,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavDelete_Enabled!=0)&&(edtavDelete_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,41);\"" : " "),"'"+""+"'"+",false,"+"'"+"EVDELETE.CLICK."+sGXsfl_30_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDelete_Jsonclick,(short)5,(string)"TextActionAttribute TextLikeLink",(string)"",(string)ROClassString,(string)"WWTextActionColumn",(string)"",(short)-1,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)30,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         send_integrity_lvl_hashes3U2( ) ;
         Grid1Container.AddRow(Grid1Row);
         nGXsfl_30_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_30_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_30_idx+1);
         sGXsfl_30_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_30_idx), 4, 0), 4, "0");
         SubsflControlProps_302( ) ;
         /* End function sendrow_302 */
      }

      protected void SubsflControlProps_464( )
      {
         edtavCtlid1_Internalname = "CTLID1_"+sGXsfl_46_idx;
         edtavCtlcode1_Internalname = "CTLCODE1_"+sGXsfl_46_idx;
         edtavCtlname1_Internalname = "CTLNAME1_"+sGXsfl_46_idx;
         edtavCtlstock1_Internalname = "CTLSTOCK1_"+sGXsfl_46_idx;
         edtavCtlquantity1_Internalname = "CTLQUANTITY1_"+sGXsfl_46_idx;
         edtavCtlunitprice1_Internalname = "CTLUNITPRICE1_"+sGXsfl_46_idx;
         edtavCtlsubtotal1_Internalname = "CTLSUBTOTAL1_"+sGXsfl_46_idx;
         edtavCtlretailprice1_Internalname = "CTLRETAILPRICE1_"+sGXsfl_46_idx;
         edtavCtlwholesaleprice1_Internalname = "CTLWHOLESALEPRICE1_"+sGXsfl_46_idx;
         edtavCtlproductminiumquantitywholesale1_Internalname = "CTLPRODUCTMINIUMQUANTITYWHOLESALE1_"+sGXsfl_46_idx;
         edtavAdd_Internalname = "vADD_"+sGXsfl_46_idx;
      }

      protected void SubsflControlProps_fel_464( )
      {
         edtavCtlid1_Internalname = "CTLID1_"+sGXsfl_46_fel_idx;
         edtavCtlcode1_Internalname = "CTLCODE1_"+sGXsfl_46_fel_idx;
         edtavCtlname1_Internalname = "CTLNAME1_"+sGXsfl_46_fel_idx;
         edtavCtlstock1_Internalname = "CTLSTOCK1_"+sGXsfl_46_fel_idx;
         edtavCtlquantity1_Internalname = "CTLQUANTITY1_"+sGXsfl_46_fel_idx;
         edtavCtlunitprice1_Internalname = "CTLUNITPRICE1_"+sGXsfl_46_fel_idx;
         edtavCtlsubtotal1_Internalname = "CTLSUBTOTAL1_"+sGXsfl_46_fel_idx;
         edtavCtlretailprice1_Internalname = "CTLRETAILPRICE1_"+sGXsfl_46_fel_idx;
         edtavCtlwholesaleprice1_Internalname = "CTLWHOLESALEPRICE1_"+sGXsfl_46_fel_idx;
         edtavCtlproductminiumquantitywholesale1_Internalname = "CTLPRODUCTMINIUMQUANTITYWHOLESALE1_"+sGXsfl_46_fel_idx;
         edtavAdd_Internalname = "vADD_"+sGXsfl_46_fel_idx;
      }

      protected void sendrow_464( )
      {
         SubsflControlProps_464( ) ;
         WB3U0( ) ;
         Grid2Row = GXWebRow.GetNew(context,Grid2Container);
         if ( subGrid2_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGrid2_Backstyle = 0;
            if ( StringUtil.StrCmp(subGrid2_Class, "") != 0 )
            {
               subGrid2_Linesclass = subGrid2_Class+"Odd";
            }
         }
         else if ( subGrid2_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGrid2_Backstyle = 0;
            subGrid2_Backcolor = subGrid2_Allbackcolor;
            if ( StringUtil.StrCmp(subGrid2_Class, "") != 0 )
            {
               subGrid2_Linesclass = subGrid2_Class+"Uniform";
            }
         }
         else if ( subGrid2_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGrid2_Backstyle = 1;
            if ( StringUtil.StrCmp(subGrid2_Class, "") != 0 )
            {
               subGrid2_Linesclass = subGrid2_Class+"Odd";
            }
            subGrid2_Backcolor = (int)(0x0);
         }
         else if ( subGrid2_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGrid2_Backstyle = 1;
            if ( ((int)((nGXsfl_46_idx) % (2))) == 0 )
            {
               subGrid2_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGrid2_Class, "") != 0 )
               {
                  subGrid2_Linesclass = subGrid2_Class+"Even";
               }
            }
            else
            {
               subGrid2_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGrid2_Class, "") != 0 )
               {
                  subGrid2_Linesclass = subGrid2_Class+"Odd";
               }
            }
         }
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr ") ;
            context.WriteHtmlText( " class=\""+"Grid"+"\" style=\""+""+"\"") ;
            context.WriteHtmlText( " gxrow=\""+sGXsfl_46_idx+"\">") ;
         }
         /* Subfile cell */
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlid1_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV8SDTCarProductsToCharge.Item(AV34GXV12)).gxTpr_Id), 6, 0, ".", "")),StringUtil.LTrim( ((edtavCtlid1_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV8SDTCarProductsToCharge.Item(AV34GXV12)).gxTpr_Id), "ZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV8SDTCarProductsToCharge.Item(AV34GXV12)).gxTpr_Id), "ZZZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlid1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(int)edtavCtlid1_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)46,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavCtlcode1_Enabled!=0)&&(edtavCtlcode1_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 48,'',false,'"+sGXsfl_46_idx+"',46)\"" : " ");
         ROClassString = "Attribute";
         Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcode1_Internalname,((SdtSDTCarProducts_SDTCarProductsItem)AV8SDTCarProductsToCharge.Item(AV34GXV12)).gxTpr_Code,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavCtlcode1_Enabled!=0)&&(edtavCtlcode1_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,48);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcode1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)1,(short)0,(string)"text",(string)"",(short)15,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)46,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname1_Internalname,((SdtSDTCarProducts_SDTCarProductsItem)AV8SDTCarProductsToCharge.Item(AV34GXV12)).gxTpr_Name,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlname1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlname1_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)46,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlstock1_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV8SDTCarProductsToCharge.Item(AV34GXV12)).gxTpr_Stock), 6, 0, ".", "")),StringUtil.LTrim( ((edtavCtlstock1_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV8SDTCarProductsToCharge.Item(AV34GXV12)).gxTpr_Stock), "ZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV8SDTCarProductsToCharge.Item(AV34GXV12)).gxTpr_Stock), "ZZZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlstock1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlstock1_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)46,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavCtlquantity1_Enabled!=0)&&(edtavCtlquantity1_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 51,'',false,'"+sGXsfl_46_idx+"',46)\"" : " ");
         ROClassString = "Attribute";
         Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlquantity1_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV8SDTCarProductsToCharge.Item(AV34GXV12)).gxTpr_Quantity), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV8SDTCarProductsToCharge.Item(AV34GXV12)).gxTpr_Quantity), "ZZZZZ9"))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+((edtavCtlquantity1_Enabled!=0)&&(edtavCtlquantity1_Visible!=0) ? " onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,51);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlquantity1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)1,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)46,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlunitprice1_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTCarProducts_SDTCarProductsItem)AV8SDTCarProductsToCharge.Item(AV34GXV12)).gxTpr_Unitprice, 18, 2, ".", "")),StringUtil.LTrim( ((edtavCtlunitprice1_Enabled!=0) ? context.localUtil.Format( ((SdtSDTCarProducts_SDTCarProductsItem)AV8SDTCarProductsToCharge.Item(AV34GXV12)).gxTpr_Unitprice, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTCarProducts_SDTCarProductsItem)AV8SDTCarProductsToCharge.Item(AV34GXV12)).gxTpr_Unitprice, "ZZZZZZZZZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlunitprice1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlunitprice1_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)46,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsubtotal1_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTCarProducts_SDTCarProductsItem)AV8SDTCarProductsToCharge.Item(AV34GXV12)).gxTpr_Subtotal, 18, 2, ".", "")),StringUtil.LTrim( ((edtavCtlsubtotal1_Enabled!=0) ? context.localUtil.Format( ((SdtSDTCarProducts_SDTCarProductsItem)AV8SDTCarProductsToCharge.Item(AV34GXV12)).gxTpr_Subtotal, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTCarProducts_SDTCarProductsItem)AV8SDTCarProductsToCharge.Item(AV34GXV12)).gxTpr_Subtotal, "ZZZZZZZZZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlsubtotal1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlsubtotal1_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)46,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlretailprice1_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTCarProducts_SDTCarProductsItem)AV8SDTCarProductsToCharge.Item(AV34GXV12)).gxTpr_Retailprice, 18, 2, ".", "")),StringUtil.LTrim( ((edtavCtlretailprice1_Enabled!=0) ? context.localUtil.Format( ((SdtSDTCarProducts_SDTCarProductsItem)AV8SDTCarProductsToCharge.Item(AV34GXV12)).gxTpr_Retailprice, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTCarProducts_SDTCarProductsItem)AV8SDTCarProductsToCharge.Item(AV34GXV12)).gxTpr_Retailprice, "ZZZZZZZZZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlretailprice1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(int)edtavCtlretailprice1_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)46,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlwholesaleprice1_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTCarProducts_SDTCarProductsItem)AV8SDTCarProductsToCharge.Item(AV34GXV12)).gxTpr_Wholesaleprice, 18, 2, ".", "")),StringUtil.LTrim( ((edtavCtlwholesaleprice1_Enabled!=0) ? context.localUtil.Format( ((SdtSDTCarProducts_SDTCarProductsItem)AV8SDTCarProductsToCharge.Item(AV34GXV12)).gxTpr_Wholesaleprice, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTCarProducts_SDTCarProductsItem)AV8SDTCarProductsToCharge.Item(AV34GXV12)).gxTpr_Wholesaleprice, "ZZZZZZZZZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlwholesaleprice1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(int)edtavCtlwholesaleprice1_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)46,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlproductminiumquantitywholesale1_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV8SDTCarProductsToCharge.Item(AV34GXV12)).gxTpr_Productminiumquantitywholesale), 4, 0, ".", "")),StringUtil.LTrim( ((edtavCtlproductminiumquantitywholesale1_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV8SDTCarProductsToCharge.Item(AV34GXV12)).gxTpr_Productminiumquantitywholesale), "ZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV8SDTCarProductsToCharge.Item(AV34GXV12)).gxTpr_Productminiumquantitywholesale), "ZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlproductminiumquantitywholesale1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlproductminiumquantitywholesale1_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)46,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavAdd_Enabled!=0)&&(edtavAdd_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 57,'',false,'"+sGXsfl_46_idx+"',46)\"" : " ");
         ROClassString = "TextActionAttribute TextLikeLink";
         Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavAdd_Internalname,(string)AV10Add,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavAdd_Enabled!=0)&&(edtavAdd_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,57);\"" : " "),"'"+""+"'"+",false,"+"'"+"EVADD.CLICK."+sGXsfl_46_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavAdd_Jsonclick,(short)5,(string)"TextActionAttribute TextLikeLink",(string)"",(string)ROClassString,(string)"WWTextActionColumn",(string)"",(short)-1,(int)edtavAdd_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)46,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         send_integrity_lvl_hashes3U4( ) ;
         Grid2Container.AddRow(Grid2Row);
         nGXsfl_46_idx = ((subGrid2_Islastpage==1)&&(nGXsfl_46_idx+1>subGrid2_fnc_Recordsperpage( )) ? 1 : nGXsfl_46_idx+1);
         sGXsfl_46_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_46_idx), 4, 0), 4, "0");
         SubsflControlProps_464( ) ;
         /* End function sendrow_464 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl30( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"30\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "Grid", 0, "", "", 1, 2, sStyleString, "", "", 0);
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
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Code") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Stock") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Quantity") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Price") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Subtotal") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Retail Price") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Wholesale Price") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Qty Wholesale") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"TextActionAttribute TextLikeLink"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Grid1Container.AddObjectProperty("GridName", "Grid1");
         }
         else
         {
            Grid1Container.AddObjectProperty("GridName", "Grid1");
            Grid1Container.AddObjectProperty("Header", subGrid1_Header);
            Grid1Container.AddObjectProperty("Class", "Grid");
            Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("CmpContext", "");
            Grid1Container.AddObjectProperty("InMasterPage", "false");
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlid_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlcode_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlname_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlstock_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlunitprice_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlsubtotal_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlretailprice_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlwholesaleprice_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlproductminiumquantitywholesale_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", GXUtil.ValueEncode( AV9Delete));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
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

      protected void StartGridControl46( )
      {
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid2Container"+"DivS\" data-gxgridid=\"46\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid2_Internalname, subGrid2_Internalname, "", "Grid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid2_Backcolorstyle == 0 )
            {
               subGrid2_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid2_Class) > 0 )
               {
                  subGrid2_Linesclass = subGrid2_Class+"Title";
               }
            }
            else
            {
               subGrid2_Titlebackstyle = 1;
               if ( subGrid2_Backcolorstyle == 1 )
               {
                  subGrid2_Titlebackcolor = subGrid2_Allbackcolor;
                  if ( StringUtil.Len( subGrid2_Class) > 0 )
                  {
                     subGrid2_Linesclass = subGrid2_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid2_Class) > 0 )
                  {
                     subGrid2_Linesclass = subGrid2_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(15), 4, 0)+"px"+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Code") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Current Stock") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Units") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Price") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Subtotal") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Qty. Wholesale") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"TextActionAttribute TextLikeLink"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Grid2Container.AddObjectProperty("GridName", "Grid2");
         }
         else
         {
            Grid2Container.AddObjectProperty("GridName", "Grid2");
            Grid2Container.AddObjectProperty("Header", subGrid2_Header);
            Grid2Container.AddObjectProperty("Class", "Grid");
            Grid2Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid2Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid2Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Backcolorstyle), 1, 0, ".", "")));
            Grid2Container.AddObjectProperty("CmpContext", "");
            Grid2Container.AddObjectProperty("InMasterPage", "false");
            Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid2Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlid1_Enabled), 5, 0, ".", "")));
            Grid2Container.AddColumnProperties(Grid2Column);
            Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid2Container.AddColumnProperties(Grid2Column);
            Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid2Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlname1_Enabled), 5, 0, ".", "")));
            Grid2Container.AddColumnProperties(Grid2Column);
            Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid2Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlstock1_Enabled), 5, 0, ".", "")));
            Grid2Container.AddColumnProperties(Grid2Column);
            Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid2Container.AddColumnProperties(Grid2Column);
            Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid2Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlunitprice1_Enabled), 5, 0, ".", "")));
            Grid2Container.AddColumnProperties(Grid2Column);
            Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid2Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlsubtotal1_Enabled), 5, 0, ".", "")));
            Grid2Container.AddColumnProperties(Grid2Column);
            Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid2Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlretailprice1_Enabled), 5, 0, ".", "")));
            Grid2Container.AddColumnProperties(Grid2Column);
            Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid2Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlwholesaleprice1_Enabled), 5, 0, ".", "")));
            Grid2Container.AddColumnProperties(Grid2Column);
            Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid2Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlproductminiumquantitywholesale1_Enabled), 5, 0, ".", "")));
            Grid2Container.AddColumnProperties(Grid2Column);
            Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid2Column.AddObjectProperty("Value", GXUtil.ValueEncode( AV10Add));
            Grid2Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavAdd_Enabled), 5, 0, ".", "")));
            Grid2Container.AddColumnProperties(Grid2Column);
            Grid2Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Selectedindex), 4, 0, ".", "")));
            Grid2Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Allowselection), 1, 0, ".", "")));
            Grid2Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Selectioncolor), 9, 0, ".", "")));
            Grid2Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Allowhovering), 1, 0, ".", "")));
            Grid2Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Hoveringcolor), 9, 0, ".", "")));
            Grid2Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Allowcollapsing), 1, 0, ".", "")));
            Grid2Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         edtavInvoiceid_Internalname = "vINVOICEID";
         edtavInvoicecreateddate_Internalname = "vINVOICECREATEDDATE";
         edtavInvoicetotalreceivable_Internalname = "vINVOICETOTALRECEIVABLE";
         divTableinvoiceheader_Internalname = "TABLEINVOICEHEADER";
         edtavCtlid_Internalname = "CTLID";
         edtavCtlcode_Internalname = "CTLCODE";
         edtavCtlname_Internalname = "CTLNAME";
         edtavCtlstock_Internalname = "CTLSTOCK";
         edtavCtlquantity_Internalname = "CTLQUANTITY";
         edtavCtlunitprice_Internalname = "CTLUNITPRICE";
         edtavCtlsubtotal_Internalname = "CTLSUBTOTAL";
         edtavCtlretailprice_Internalname = "CTLRETAILPRICE";
         edtavCtlwholesaleprice_Internalname = "CTLWHOLESALEPRICE";
         edtavCtlproductminiumquantitywholesale_Internalname = "CTLPRODUCTMINIUMQUANTITYWHOLESALE";
         edtavDelete_Internalname = "vDELETE";
         edtavCtlid1_Internalname = "CTLID1";
         edtavCtlcode1_Internalname = "CTLCODE1";
         edtavCtlname1_Internalname = "CTLNAME1";
         edtavCtlstock1_Internalname = "CTLSTOCK1";
         edtavCtlquantity1_Internalname = "CTLQUANTITY1";
         edtavCtlunitprice1_Internalname = "CTLUNITPRICE1";
         edtavCtlsubtotal1_Internalname = "CTLSUBTOTAL1";
         edtavCtlretailprice1_Internalname = "CTLRETAILPRICE1";
         edtavCtlwholesaleprice1_Internalname = "CTLWHOLESALEPRICE1";
         edtavCtlproductminiumquantitywholesale1_Internalname = "CTLPRODUCTMINIUMQUANTITYWHOLESALE1";
         edtavAdd_Internalname = "vADD";
         divTableinvoicedetails_Internalname = "TABLEINVOICEDETAILS";
         bttConfirm_Internalname = "CONFIRM";
         bttCancel_Internalname = "CANCEL";
         divTable1_Internalname = "TABLE1";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGrid1_Internalname = "GRID1";
         subGrid2_Internalname = "GRID2";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("mtaKB", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid2_Allowcollapsing = 0;
         subGrid2_Allowselection = 0;
         subGrid2_Header = "";
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         subGrid1_Header = "";
         edtavAdd_Jsonclick = "";
         edtavAdd_Visible = -1;
         edtavAdd_Enabled = 1;
         edtavCtlproductminiumquantitywholesale1_Jsonclick = "";
         edtavCtlproductminiumquantitywholesale1_Enabled = 0;
         edtavCtlwholesaleprice1_Jsonclick = "";
         edtavCtlwholesaleprice1_Enabled = 0;
         edtavCtlretailprice1_Jsonclick = "";
         edtavCtlretailprice1_Enabled = 0;
         edtavCtlsubtotal1_Jsonclick = "";
         edtavCtlsubtotal1_Enabled = 0;
         edtavCtlunitprice1_Jsonclick = "";
         edtavCtlunitprice1_Enabled = 0;
         edtavCtlquantity1_Jsonclick = "";
         edtavCtlquantity1_Visible = -1;
         edtavCtlquantity1_Enabled = 1;
         edtavCtlstock1_Jsonclick = "";
         edtavCtlstock1_Enabled = 0;
         edtavCtlname1_Jsonclick = "";
         edtavCtlname1_Enabled = 0;
         edtavCtlcode1_Jsonclick = "";
         edtavCtlcode1_Visible = -1;
         edtavCtlcode1_Enabled = 1;
         edtavCtlid1_Jsonclick = "";
         edtavCtlid1_Enabled = 0;
         subGrid2_Class = "Grid";
         subGrid2_Backcolorstyle = 0;
         edtavDelete_Jsonclick = "";
         edtavDelete_Visible = -1;
         edtavDelete_Enabled = 1;
         edtavCtlproductminiumquantitywholesale_Jsonclick = "";
         edtavCtlproductminiumquantitywholesale_Enabled = 0;
         edtavCtlwholesaleprice_Jsonclick = "";
         edtavCtlwholesaleprice_Enabled = 0;
         edtavCtlretailprice_Jsonclick = "";
         edtavCtlretailprice_Enabled = 0;
         edtavCtlsubtotal_Jsonclick = "";
         edtavCtlsubtotal_Enabled = 0;
         edtavCtlunitprice_Jsonclick = "";
         edtavCtlunitprice_Enabled = 0;
         edtavCtlquantity_Jsonclick = "";
         edtavCtlquantity_Visible = -1;
         edtavCtlquantity_Enabled = 1;
         edtavCtlstock_Jsonclick = "";
         edtavCtlstock_Enabled = 0;
         edtavCtlname_Jsonclick = "";
         edtavCtlname_Enabled = 0;
         edtavCtlcode_Jsonclick = "";
         edtavCtlcode_Enabled = 0;
         edtavCtlid_Jsonclick = "";
         edtavCtlid_Enabled = 0;
         subGrid1_Class = "Grid";
         subGrid1_Backcolorstyle = 0;
         edtavCtlproductminiumquantitywholesale1_Enabled = -1;
         edtavCtlwholesaleprice1_Enabled = -1;
         edtavCtlretailprice1_Enabled = -1;
         edtavCtlsubtotal1_Enabled = -1;
         edtavCtlunitprice1_Enabled = -1;
         edtavCtlstock1_Enabled = -1;
         edtavCtlname1_Enabled = -1;
         edtavCtlid1_Enabled = -1;
         edtavCtlproductminiumquantitywholesale_Enabled = -1;
         edtavCtlwholesaleprice_Enabled = -1;
         edtavCtlretailprice_Enabled = -1;
         edtavCtlsubtotal_Enabled = -1;
         edtavCtlunitprice_Enabled = -1;
         edtavCtlstock_Enabled = -1;
         edtavCtlname_Enabled = -1;
         edtavCtlcode_Enabled = -1;
         edtavCtlid_Enabled = -1;
         edtavInvoicetotalreceivable_Jsonclick = "";
         edtavInvoicetotalreceivable_Enabled = 1;
         edtavInvoicecreateddate_Jsonclick = "";
         edtavInvoicecreateddate_Enabled = 1;
         edtavInvoiceid_Jsonclick = "";
         edtavInvoiceid_Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "WPRegister Sale New";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'AV6SDTCarProducts',fld:'vSDTCARPRODUCTS',grid:30,pic:''},{av:'nGXsfl_30_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:30},{av:'nRC_GXsfl_30',ctrl:'GRID1',prop:'GridRC',grid:30},{av:'AV9Delete',fld:'vDELETE',pic:''},{av:'GRID2_nFirstRecordOnPage'},{av:'GRID2_nEOF'},{av:'AV10Add',fld:'vADD',pic:''},{av:'AV8SDTCarProductsToCharge',fld:'vSDTCARPRODUCTSTOCHARGE',grid:46,pic:''},{av:'nGXsfl_46_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:46},{av:'nRC_GXsfl_46',ctrl:'GRID2',prop:'GridRC',grid:46}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("CTLCODE1.CONTROLVALUECHANGED","{handler:'E113U2',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'AV6SDTCarProducts',fld:'vSDTCARPRODUCTS',grid:30,pic:''},{av:'nGXsfl_30_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:30},{av:'nRC_GXsfl_30',ctrl:'GRID1',prop:'GridRC',grid:30},{av:'AV9Delete',fld:'vDELETE',pic:''},{av:'AV8SDTCarProductsToCharge',fld:'vSDTCARPRODUCTSTOCHARGE',grid:46,pic:''},{av:'nGXsfl_46_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:46},{av:'GRID2_nFirstRecordOnPage'},{av:'nRC_GXsfl_46',ctrl:'GRID2',prop:'GridRC',grid:46},{av:'A55ProductCode',fld:'PRODUCTCODE',pic:''},{av:'A110ProductActive',fld:'PRODUCTACTIVE',pic:''},{av:'A112SupplierActive',fld:'SUPPLIERACTIVE',pic:''},{av:'A15ProductId',fld:'PRODUCTID',pic:'ZZZZZ9'},{av:'AV14SDTCarProductsToChargeItem',fld:'vSDTCARPRODUCTSTOCHARGEITEM',pic:''},{av:'AV18AllOk',fld:'vALLOK',pic:''},{av:'AV17SDTCarProductsItem',fld:'vSDTCARPRODUCTSITEM',pic:''},{av:'GRID2_nEOF'},{av:'AV10Add',fld:'vADD',pic:''}]");
         setEventMetadata("CTLCODE1.CONTROLVALUECHANGED",",oparms:[{av:'AV7ProductCode',fld:'vPRODUCTCODE',pic:''},{av:'AV14SDTCarProductsToChargeItem',fld:'vSDTCARPRODUCTSTOCHARGEITEM',pic:''},{av:'AV8SDTCarProductsToCharge',fld:'vSDTCARPRODUCTSTOCHARGE',grid:46,pic:''},{av:'nGXsfl_46_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:46},{av:'GRID2_nFirstRecordOnPage'},{av:'nRC_GXsfl_46',ctrl:'GRID2',prop:'GridRC',grid:46},{av:'AV17SDTCarProductsItem',fld:'vSDTCARPRODUCTSITEM',pic:''},{av:'AV18AllOk',fld:'vALLOK',pic:''}]}");
         setEventMetadata("VADD.CLICK","{handler:'E123U2',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'AV6SDTCarProducts',fld:'vSDTCARPRODUCTS',grid:30,pic:''},{av:'nGXsfl_30_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:30},{av:'nRC_GXsfl_30',ctrl:'GRID1',prop:'GridRC',grid:30},{av:'AV9Delete',fld:'vDELETE',pic:''},{av:'AV8SDTCarProductsToCharge',fld:'vSDTCARPRODUCTSTOCHARGE',grid:46,pic:''},{av:'nGXsfl_46_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:46},{av:'GRID2_nFirstRecordOnPage'},{av:'nRC_GXsfl_46',ctrl:'GRID2',prop:'GridRC',grid:46},{av:'AV20WasAdded',fld:'vWASADDED',pic:''},{av:'GRID2_nEOF'},{av:'AV10Add',fld:'vADD',pic:''}]");
         setEventMetadata("VADD.CLICK",",oparms:[{av:'AV14SDTCarProductsToChargeItem',fld:'vSDTCARPRODUCTSTOCHARGEITEM',pic:''},{av:'AV6SDTCarProducts',fld:'vSDTCARPRODUCTS',grid:30,pic:''},{av:'nGXsfl_30_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:30},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_30',ctrl:'GRID1',prop:'GridRC',grid:30},{av:'AV20WasAdded',fld:'vWASADDED',pic:''},{av:'AV17SDTCarProductsItem',fld:'vSDTCARPRODUCTSITEM',pic:''},{av:'AV16InvoiceTotalReceivable',fld:'vINVOICETOTALRECEIVABLE',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV8SDTCarProductsToCharge',fld:'vSDTCARPRODUCTSTOCHARGE',grid:46,pic:''},{av:'nGXsfl_46_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:46},{av:'GRID2_nFirstRecordOnPage'},{av:'nRC_GXsfl_46',ctrl:'GRID2',prop:'GridRC',grid:46}]}");
         setEventMetadata("VDELETE.CLICK","{handler:'E163U2',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'AV6SDTCarProducts',fld:'vSDTCARPRODUCTS',grid:30,pic:''},{av:'nGXsfl_30_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:30},{av:'nRC_GXsfl_30',ctrl:'GRID1',prop:'GridRC',grid:30},{av:'AV9Delete',fld:'vDELETE',pic:''},{av:'GRID2_nFirstRecordOnPage'},{av:'GRID2_nEOF'},{av:'AV10Add',fld:'vADD',pic:''},{av:'AV8SDTCarProductsToCharge',fld:'vSDTCARPRODUCTSTOCHARGE',grid:46,pic:''},{av:'nGXsfl_46_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:46},{av:'nRC_GXsfl_46',ctrl:'GRID2',prop:'GridRC',grid:46}]");
         setEventMetadata("VDELETE.CLICK",",oparms:[{av:'AV6SDTCarProducts',fld:'vSDTCARPRODUCTS',grid:30,pic:''},{av:'nGXsfl_30_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:30},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_30',ctrl:'GRID1',prop:'GridRC',grid:30},{av:'AV16InvoiceTotalReceivable',fld:'vINVOICETOTALRECEIVABLE',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV17SDTCarProductsItem',fld:'vSDTCARPRODUCTSITEM',pic:''}]}");
         setEventMetadata("CTLQUANTITY.CONTROLVALUECHANGED","{handler:'E173U2',iparms:[{av:'AV6SDTCarProducts',fld:'vSDTCARPRODUCTS',grid:30,pic:''},{av:'nGXsfl_30_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:30},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_30',ctrl:'GRID1',prop:'GridRC',grid:30},{av:'AV18AllOk',fld:'vALLOK',pic:''},{av:'AV17SDTCarProductsItem',fld:'vSDTCARPRODUCTSITEM',pic:''},{av:'GRID1_nEOF'},{av:'AV9Delete',fld:'vDELETE',pic:''},{av:'GRID2_nFirstRecordOnPage'},{av:'GRID2_nEOF'},{av:'AV10Add',fld:'vADD',pic:''},{av:'AV8SDTCarProductsToCharge',fld:'vSDTCARPRODUCTSTOCHARGE',grid:46,pic:''},{av:'nGXsfl_46_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:46},{av:'nRC_GXsfl_46',ctrl:'GRID2',prop:'GridRC',grid:46}]");
         setEventMetadata("CTLQUANTITY.CONTROLVALUECHANGED",",oparms:[{av:'AV17SDTCarProductsItem',fld:'vSDTCARPRODUCTSITEM',pic:''},{av:'AV6SDTCarProducts',fld:'vSDTCARPRODUCTS',grid:30,pic:''},{av:'nGXsfl_30_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:30},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_30',ctrl:'GRID1',prop:'GridRC',grid:30},{av:'AV18AllOk',fld:'vALLOK',pic:''},{av:'AV16InvoiceTotalReceivable',fld:'vINVOICETOTALRECEIVABLE',pic:'ZZZZZZZZZZZZZZ9.99'}]}");
         setEventMetadata("GRID2.REFRESH","{handler:'E133U2',iparms:[{av:'AV8SDTCarProductsToCharge',fld:'vSDTCARPRODUCTSTOCHARGE',grid:46,pic:''},{av:'nGXsfl_46_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:46},{av:'GRID2_nFirstRecordOnPage'},{av:'nRC_GXsfl_46',ctrl:'GRID2',prop:'GridRC',grid:46}]");
         setEventMetadata("GRID2.REFRESH",",oparms:[{av:'AV10Add',fld:'vADD',pic:''}]}");
         setEventMetadata("GRID1.REFRESH","{handler:'E183U2',iparms:[]");
         setEventMetadata("GRID1.REFRESH",",oparms:[{av:'AV9Delete',fld:'vDELETE',pic:''}]}");
         setEventMetadata("VALIDV_INVOICECREATEDDATE","{handler:'Validv_Invoicecreateddate',iparms:[]");
         setEventMetadata("VALIDV_INVOICECREATEDDATE",",oparms:[]}");
         setEventMetadata("VALIDV_INVOICETOTALRECEIVABLE","{handler:'Validv_Invoicetotalreceivable',iparms:[]");
         setEventMetadata("VALIDV_INVOICETOTALRECEIVABLE",",oparms:[]}");
         setEventMetadata("VALIDV_GXV7","{handler:'Validv_Gxv7',iparms:[]");
         setEventMetadata("VALIDV_GXV7",",oparms:[]}");
         setEventMetadata("VALIDV_GXV8","{handler:'Validv_Gxv8',iparms:[]");
         setEventMetadata("VALIDV_GXV8",",oparms:[]}");
         setEventMetadata("VALIDV_GXV9","{handler:'Validv_Gxv9',iparms:[]");
         setEventMetadata("VALIDV_GXV9",",oparms:[]}");
         setEventMetadata("VALIDV_GXV10","{handler:'Validv_Gxv10',iparms:[]");
         setEventMetadata("VALIDV_GXV10",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Delete',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("VALIDV_GXV18","{handler:'Validv_Gxv18',iparms:[]");
         setEventMetadata("VALIDV_GXV18",",oparms:[]}");
         setEventMetadata("VALIDV_GXV19","{handler:'Validv_Gxv19',iparms:[]");
         setEventMetadata("VALIDV_GXV19",",oparms:[]}");
         setEventMetadata("VALIDV_GXV20","{handler:'Validv_Gxv20',iparms:[]");
         setEventMetadata("VALIDV_GXV20",",oparms:[]}");
         setEventMetadata("VALIDV_GXV21","{handler:'Validv_Gxv21',iparms:[]");
         setEventMetadata("VALIDV_GXV21",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Add',iparms:[]");
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
         AV9Delete = "";
         AV10Add = "";
         AV8SDTCarProductsToCharge = new GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem>( context, "SDTCarProductsItem", "mtaKB");
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV6SDTCarProducts = new GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem>( context, "SDTCarProductsItem", "mtaKB");
         A55ProductCode = "";
         AV14SDTCarProductsToChargeItem = new SdtSDTCarProducts_SDTCarProductsItem(context);
         AV17SDTCarProductsItem = new SdtSDTCarProducts_SDTCarProductsItem(context);
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV15InvoiceCreatedDate = DateTime.MinValue;
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         Grid2Container = new GXWebGrid( context);
         bttConfirm_Jsonclick = "";
         bttCancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV7ProductCode = "";
         scmdbuf = "";
         H003U2_A4SupplierId = new int[1] ;
         H003U2_A112SupplierActive = new bool[] {false} ;
         H003U2_A110ProductActive = new bool[] {false} ;
         H003U2_n110ProductActive = new bool[] {false} ;
         H003U2_A55ProductCode = new string[] {""} ;
         H003U2_n55ProductCode = new bool[] {false} ;
         H003U2_A15ProductId = new int[1] ;
         GXt_SdtSDTCarProducts_SDTCarProductsItem2 = new SdtSDTCarProducts_SDTCarProductsItem(context);
         Grid1Row = new GXWebRow();
         Grid2Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         ROClassString = "";
         subGrid2_Linesclass = "";
         Grid1Column = new GXWebColumn();
         Grid2Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpregistersalenew__default(),
            new Object[][] {
                new Object[] {
               H003U2_A4SupplierId, H003U2_A112SupplierActive, H003U2_A110ProductActive, H003U2_n110ProductActive, H003U2_A55ProductCode, H003U2_n55ProductCode, H003U2_A15ProductId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavInvoiceid_Enabled = 0;
         edtavInvoicecreateddate_Enabled = 0;
         edtavInvoicetotalreceivable_Enabled = 0;
         edtavCtlid_Enabled = 0;
         edtavCtlcode_Enabled = 0;
         edtavCtlname_Enabled = 0;
         edtavCtlstock_Enabled = 0;
         edtavCtlunitprice_Enabled = 0;
         edtavCtlsubtotal_Enabled = 0;
         edtavCtlretailprice_Enabled = 0;
         edtavCtlwholesaleprice_Enabled = 0;
         edtavCtlproductminiumquantitywholesale_Enabled = 0;
         edtavDelete_Enabled = 0;
         edtavCtlid1_Enabled = 0;
         edtavCtlname1_Enabled = 0;
         edtavCtlstock1_Enabled = 0;
         edtavCtlunitprice1_Enabled = 0;
         edtavCtlsubtotal1_Enabled = 0;
         edtavCtlretailprice1_Enabled = 0;
         edtavCtlwholesaleprice1_Enabled = 0;
         edtavCtlproductminiumquantitywholesale1_Enabled = 0;
         edtavAdd_Enabled = 0;
      }

      private short nRcdExists_4 ;
      private short nIsMod_4 ;
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
      private short subGrid1_Backcolorstyle ;
      private short subGrid2_Backcolorstyle ;
      private short AV45GXLvl16 ;
      private short GRID1_nEOF ;
      private short GRID2_nEOF ;
      private short AV12Position ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private short subGrid2_Backstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private short subGrid2_Titlebackstyle ;
      private short subGrid2_Allowselection ;
      private short subGrid2_Allowhovering ;
      private short subGrid2_Allowcollapsing ;
      private short subGrid2_Collapsed ;
      private int nRC_GXsfl_30 ;
      private int nRC_GXsfl_46 ;
      private int nGXsfl_30_idx=1 ;
      private int nGXsfl_46_idx=1 ;
      private int A15ProductId ;
      private int AV19InvoiceId ;
      private int edtavInvoiceid_Enabled ;
      private int edtavInvoicecreateddate_Enabled ;
      private int edtavInvoicetotalreceivable_Enabled ;
      private int AV23GXV1 ;
      private int AV34GXV12 ;
      private int subGrid1_Islastpage ;
      private int subGrid2_Islastpage ;
      private int edtavCtlid_Enabled ;
      private int edtavCtlcode_Enabled ;
      private int edtavCtlname_Enabled ;
      private int edtavCtlstock_Enabled ;
      private int edtavCtlunitprice_Enabled ;
      private int edtavCtlsubtotal_Enabled ;
      private int edtavCtlretailprice_Enabled ;
      private int edtavCtlwholesaleprice_Enabled ;
      private int edtavCtlproductminiumquantitywholesale_Enabled ;
      private int edtavDelete_Enabled ;
      private int edtavCtlid1_Enabled ;
      private int edtavCtlname1_Enabled ;
      private int edtavCtlstock1_Enabled ;
      private int edtavCtlunitprice1_Enabled ;
      private int edtavCtlsubtotal1_Enabled ;
      private int edtavCtlretailprice1_Enabled ;
      private int edtavCtlwholesaleprice1_Enabled ;
      private int edtavCtlproductminiumquantitywholesale1_Enabled ;
      private int edtavAdd_Enabled ;
      private int nGXsfl_30_fel_idx=1 ;
      private int nGXsfl_46_fel_idx=1 ;
      private int GXt_int1 ;
      private int A4SupplierId ;
      private int nGXsfl_46_bak_idx=1 ;
      private int nGXsfl_30_bak_idx=1 ;
      private int AV46GXV23 ;
      private int AV47GXV24 ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int edtavCtlquantity_Enabled ;
      private int edtavCtlquantity_Visible ;
      private int edtavDelete_Visible ;
      private int subGrid2_Backcolor ;
      private int subGrid2_Allbackcolor ;
      private int edtavCtlcode1_Enabled ;
      private int edtavCtlcode1_Visible ;
      private int edtavCtlquantity1_Enabled ;
      private int edtavCtlquantity1_Visible ;
      private int edtavAdd_Visible ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private int subGrid2_Titlebackcolor ;
      private int subGrid2_Selectedindex ;
      private int subGrid2_Selectioncolor ;
      private int subGrid2_Hoveringcolor ;
      private long GRID1_nCurrentRecord ;
      private long GRID2_nCurrentRecord ;
      private long GRID1_nFirstRecordOnPage ;
      private long GRID2_nFirstRecordOnPage ;
      private decimal AV13Subtotal ;
      private decimal AV16InvoiceTotalReceivable ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_30_idx="0001" ;
      private string sGXsfl_46_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTableinvoiceheader_Internalname ;
      private string edtavInvoiceid_Internalname ;
      private string TempTags ;
      private string edtavInvoiceid_Jsonclick ;
      private string edtavInvoicecreateddate_Internalname ;
      private string edtavInvoicecreateddate_Jsonclick ;
      private string edtavInvoicetotalreceivable_Internalname ;
      private string edtavInvoicetotalreceivable_Jsonclick ;
      private string divTableinvoicedetails_Internalname ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string subGrid2_Internalname ;
      private string divTable1_Internalname ;
      private string bttConfirm_Internalname ;
      private string bttConfirm_Jsonclick ;
      private string bttCancel_Internalname ;
      private string bttCancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavAdd_Internalname ;
      private string edtavDelete_Internalname ;
      private string edtavCtlid_Internalname ;
      private string edtavCtlcode_Internalname ;
      private string edtavCtlname_Internalname ;
      private string edtavCtlstock_Internalname ;
      private string edtavCtlunitprice_Internalname ;
      private string edtavCtlsubtotal_Internalname ;
      private string edtavCtlretailprice_Internalname ;
      private string edtavCtlwholesaleprice_Internalname ;
      private string edtavCtlproductminiumquantitywholesale_Internalname ;
      private string edtavCtlid1_Internalname ;
      private string edtavCtlname1_Internalname ;
      private string edtavCtlstock1_Internalname ;
      private string edtavCtlunitprice1_Internalname ;
      private string edtavCtlsubtotal1_Internalname ;
      private string edtavCtlretailprice1_Internalname ;
      private string edtavCtlwholesaleprice1_Internalname ;
      private string edtavCtlproductminiumquantitywholesale1_Internalname ;
      private string sGXsfl_30_fel_idx="0001" ;
      private string sGXsfl_46_fel_idx="0001" ;
      private string edtavCtlcode1_Internalname ;
      private string scmdbuf ;
      private string edtavCtlquantity_Internalname ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string ROClassString ;
      private string edtavCtlid_Jsonclick ;
      private string edtavCtlcode_Jsonclick ;
      private string edtavCtlname_Jsonclick ;
      private string edtavCtlstock_Jsonclick ;
      private string edtavCtlquantity_Jsonclick ;
      private string edtavCtlunitprice_Jsonclick ;
      private string edtavCtlsubtotal_Jsonclick ;
      private string edtavCtlretailprice_Jsonclick ;
      private string edtavCtlwholesaleprice_Jsonclick ;
      private string edtavCtlproductminiumquantitywholesale_Jsonclick ;
      private string edtavDelete_Jsonclick ;
      private string edtavCtlquantity1_Internalname ;
      private string subGrid2_Class ;
      private string subGrid2_Linesclass ;
      private string edtavCtlid1_Jsonclick ;
      private string edtavCtlcode1_Jsonclick ;
      private string edtavCtlname1_Jsonclick ;
      private string edtavCtlstock1_Jsonclick ;
      private string edtavCtlquantity1_Jsonclick ;
      private string edtavCtlunitprice1_Jsonclick ;
      private string edtavCtlsubtotal1_Jsonclick ;
      private string edtavCtlretailprice1_Jsonclick ;
      private string edtavCtlwholesaleprice1_Jsonclick ;
      private string edtavCtlproductminiumquantitywholesale1_Jsonclick ;
      private string edtavAdd_Jsonclick ;
      private string subGrid1_Header ;
      private string subGrid2_Header ;
      private DateTime AV15InvoiceCreatedDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool A110ProductActive ;
      private bool A112SupplierActive ;
      private bool AV18AllOk ;
      private bool AV20WasAdded ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_30_Refreshing=false ;
      private bool bGXsfl_46_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool n110ProductActive ;
      private bool n55ProductCode ;
      private bool gx_BV30 ;
      private bool gx_BV46 ;
      private string AV9Delete ;
      private string AV10Add ;
      private string A55ProductCode ;
      private string AV7ProductCode ;
      private GXWebGrid Grid1Container ;
      private GXWebGrid Grid2Container ;
      private GXWebRow Grid1Row ;
      private GXWebRow Grid2Row ;
      private GXWebColumn Grid1Column ;
      private GXWebColumn Grid2Column ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] H003U2_A4SupplierId ;
      private bool[] H003U2_A112SupplierActive ;
      private bool[] H003U2_A110ProductActive ;
      private bool[] H003U2_n110ProductActive ;
      private string[] H003U2_A55ProductCode ;
      private bool[] H003U2_n55ProductCode ;
      private int[] H003U2_A15ProductId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem> AV8SDTCarProductsToCharge ;
      private GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem> AV6SDTCarProducts ;
      private GXWebForm Form ;
      private SdtSDTCarProducts_SDTCarProductsItem AV14SDTCarProductsToChargeItem ;
      private SdtSDTCarProducts_SDTCarProductsItem AV17SDTCarProductsItem ;
      private SdtSDTCarProducts_SDTCarProductsItem GXt_SdtSDTCarProducts_SDTCarProductsItem2 ;
   }

   public class wpregistersalenew__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH003U2;
          prmH003U2 = new Object[] {
          new ParDef("@AV7ProductCode",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H003U2", "SELECT TOP 1 T1.[SupplierId], T2.[SupplierActive], T1.[ProductActive], T1.[ProductCode], T1.[ProductId] FROM ([Product] T1 INNER JOIN [Supplier] T2 ON T2.[SupplierId] = T1.[SupplierId]) WHERE (T1.[ProductActive] = 1) AND (T2.[SupplierActive] = 1) AND (Not (T1.[ProductCode] = '')) AND (Not T1.[ProductCode] IS NULL) AND (T1.[ProductCode] = @AV7ProductCode) ORDER BY T1.[ProductId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003U2,1, GxCacheFrequency.OFF ,true,true )
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
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((int[]) buf[6])[0] = rslt.getInt(5);
                return;
       }
    }

 }

}
