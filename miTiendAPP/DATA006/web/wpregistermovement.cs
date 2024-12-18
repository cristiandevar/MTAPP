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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridpaymentcancel") == 0 )
            {
               gxnrGridpaymentcancel_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridpaymentcancel") == 0 )
            {
               gxgrGridpaymentcancel_refresh_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridinvoicedetailsedit") == 0 )
            {
               gxnrGridinvoicedetailsedit_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridinvoicedetailsedit") == 0 )
            {
               gxgrGridinvoicedetailsedit_refresh_invoke( ) ;
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

      protected void gxnrGrid1_newrow_invoke( )
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
         gxnrGrid1_newrow( ) ;
         /* End function gxnrGrid1_newrow_invoke */
      }

      protected void gxgrGrid1_refresh_invoke( )
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
         gxgrGrid1_refresh( subGridinvoice_Rows, AV31FilterNro, AV33FilterCreatedDateFrom, AV34FilterCreatedDateTo) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid1_refresh_invoke */
      }

      protected void gxnrGridpaymentcancel_newrow_invoke( )
      {
         nRC_GXsfl_76 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_76"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_76_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_76_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_76_idx = GetPar( "sGXsfl_76_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridpaymentcancel_newrow( ) ;
         /* End function gxnrGridpaymentcancel_newrow_invoke */
      }

      protected void gxgrGridpaymentcancel_refresh_invoke( )
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
         gxgrGridpaymentcancel_refresh( subGridinvoice_Rows, AV31FilterNro, AV33FilterCreatedDateFrom, AV34FilterCreatedDateTo) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridpaymentcancel_refresh_invoke */
      }

      protected void gxnrGridinvoicedetailsedit_newrow_invoke( )
      {
         nRC_GXsfl_108 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_108"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_108_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_108_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_108_idx = GetPar( "sGXsfl_108_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridinvoicedetailsedit_newrow( ) ;
         /* End function gxnrGridinvoicedetailsedit_newrow_invoke */
      }

      protected void gxgrGridinvoicedetailsedit_refresh_invoke( )
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
         gxgrGridinvoicedetailsedit_refresh( subGridinvoice_Rows, AV31FilterNro, AV33FilterCreatedDateFrom, AV34FilterCreatedDateTo) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridinvoicedetailsedit_refresh_invoke */
      }

      protected void gxnrGrid2_newrow_invoke( )
      {
         nRC_GXsfl_123 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_123"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_123_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_123_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_123_idx = GetPar( "sGXsfl_123_idx");
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
         gxgrGrid2_refresh( subGridinvoice_Rows, AV31FilterNro, AV33FilterCreatedDateFrom, AV34FilterCreatedDateTo) ;
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Sdtcarproducts_cancel", AV15SDTCarProducts_Cancel);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Sdtcarproducts_cancel", AV15SDTCarProducts_Cancel);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Sdtinvoiceaddpaymentmethod_cancel", AV39SDTInvoiceAddPaymentMethod_Cancel);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Sdtinvoiceaddpaymentmethod_cancel", AV39SDTInvoiceAddPaymentMethod_Cancel);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Sdtcarproducts_edit", AV16SDTCarProducts_Edit);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Sdtcarproducts_edit", AV16SDTCarProducts_Edit);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Sdtinvoiceaddpaymentmethod_edit", AV38SDTInvoiceAddPaymentMethod_Edit);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Sdtinvoiceaddpaymentmethod_edit", AV38SDTInvoiceAddPaymentMethod_Edit);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_25", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_25), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_62", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_62), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_76", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_76), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_108", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_108), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_123", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_123), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINVOICEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30InvoiceId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTCODE", A55ProductCode);
         GxWebStd.gx_hidden_field( context, "PRODUCTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTNAME", A16ProductName);
         GxWebStd.gx_hidden_field( context, "INVOICEDETAILQUANTITY", StringUtil.LTrim( StringUtil.NToC( (decimal)(A26InvoiceDetailQuantity), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "INVOICEDETAILHISTORICPRICE", StringUtil.LTrim( StringUtil.NToC( A65InvoiceDetailHistoricPrice, 18, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "PAYMENTMETHODID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A115PaymentMethodId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PAYMENTMETHODDESCRIPTION", A116PaymentMethodDescription);
         GxWebStd.gx_hidden_field( context, "INVOICEPAYMENTMETHODRECHARGEIM", StringUtil.LTrim( StringUtil.NToC( A132InvoicePaymentMethodRechargeIm, 18, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "INVOICEPAYMENTMETHODDISCOUNTIM", StringUtil.LTrim( StringUtil.NToC( A133InvoicePaymentMethodDiscountIm, 18, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "INVOICEPAYMENTMETHODIMPORT", StringUtil.LTrim( StringUtil.NToC( A120InvoicePaymentMethodImport, 18, 2, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vCONTROLCANCEL", AV20ControlCancel);
         GxWebStd.gx_hidden_field( context, "vERRORMESSAGE", AV7ErrorMessage);
         GxWebStd.gx_hidden_field( context, "vCONTROLEDIT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43ControlEdit), 4, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTCARPRODUCTS_EDIT", AV16SDTCarProducts_Edit);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTCARPRODUCTS_EDIT", AV16SDTCarProducts_Edit);
         }
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
            context.WriteHtmlText( "<hr/>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecancel_Internalname, divTablecancel_Visible, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablebuttonscancel_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttConfirmcancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(25), 2, 0)+","+"null"+");", "Confirm", bttConfirmcancel_Jsonclick, 5, "Confirm", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CONFIRMCANCEL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPRegisterMovement.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCancelcancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(25), 2, 0)+","+"null"+");", "Cancel", bttCancelcancel_Jsonclick, 5, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CANCEL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPRegisterMovement.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavImpottotalcancel_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavImpottotalcancel_Internalname, "Total Receivable", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'" + sGXsfl_25_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavImpottotalcancel_Internalname, StringUtil.LTrim( StringUtil.NToC( AV41ImpotTotalCancel, 18, 2, ".", "")), StringUtil.LTrim( ((edtavImpottotalcancel_Enabled!=0) ? context.localUtil.Format( AV41ImpotTotalCancel, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV41ImpotTotalCancel, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,50);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavImpottotalcancel_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavImpottotalcancel_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_WPRegisterMovement.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavMovementdescription_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMovementdescription_Internalname, "Reason", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'" + sGXsfl_25_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavMovementdescription_Internalname, AV19MovementDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", 0, 1, edtavMovementdescription_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WPRegisterMovement.htm");
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
            GxWebStd.gx_div_start( context, divTableinvoicedetailscancel_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl62( ) ;
         }
         if ( wbEnd == 62 )
         {
            wbEnd = 0;
            nRC_GXsfl_62 = (int)(nGXsfl_62_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV49GXV1 = nGXsfl_62_idx;
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
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridpaymentcancelContainer.SetWrapped(nGXWrapped);
            StartGridControl76( ) ;
         }
         if ( wbEnd == 76 )
         {
            wbEnd = 0;
            nRC_GXsfl_76 = (int)(nGXsfl_76_idx-1);
            if ( GridpaymentcancelContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV56GXV8 = nGXsfl_76_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridpaymentcancelContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridpaymentcancel", GridpaymentcancelContainer, subGridpaymentcancel_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridpaymentcancelContainerData", GridpaymentcancelContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridpaymentcancelContainerData"+"V", GridpaymentcancelContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridpaymentcancelContainerData"+"V"+"\" value='"+GridpaymentcancelContainer.GridValuesHidden()+"'/>") ;
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
            GxWebStd.gx_div_start( context, divTableedit_Internalname, divTableedit_Visible, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablebuttonsedit_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttConfirmedit_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(25), 2, 0)+","+"null"+");", "Confirm", bttConfirmedit_Jsonclick, 7, "Confirm", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e114k1_client"+"'", TempTags, "", 2, "HLP_WPRegisterMovement.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCanceledit_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(25), 2, 0)+","+"null"+");", "Cancel", bttCanceledit_Jsonclick, 5, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CANCEL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPRegisterMovement.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavImportreceivable_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavImportreceivable_Internalname, "Import Receivable", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'" + sGXsfl_25_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavImportreceivable_Internalname, StringUtil.LTrim( StringUtil.NToC( AV35ImportReceivable, 18, 2, ".", "")), StringUtil.LTrim( ((edtavImportreceivable_Enabled!=0) ? context.localUtil.Format( AV35ImportReceivable, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV35ImportReceivable, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavImportreceivable_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavImportreceivable_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_WPRegisterMovement.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavMovementdescription_edit_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMovementdescription_edit_Internalname, "Reason", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'" + sGXsfl_25_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavMovementdescription_edit_Internalname, AV46MovementDescription_Edit, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,100);\"", 0, 1, edtavMovementdescription_edit_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WPRegisterMovement.htm");
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
            GxWebStd.gx_div_start( context, divTableinvoicedetailsedit_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridinvoicedetailseditContainer.SetWrapped(nGXWrapped);
            StartGridControl108( ) ;
         }
         if ( wbEnd == 108 )
         {
            wbEnd = 0;
            nRC_GXsfl_108 = (int)(nGXsfl_108_idx-1);
            if ( GridinvoicedetailseditContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV61GXV13 = nGXsfl_108_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridinvoicedetailseditContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridinvoicedetailsedit", GridinvoicedetailseditContainer, subGridinvoicedetailsedit_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridinvoicedetailseditContainerData", GridinvoicedetailseditContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridinvoicedetailseditContainerData"+"V", GridinvoicedetailseditContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridinvoicedetailseditContainerData"+"V"+"\" value='"+GridinvoicedetailseditContainer.GridValuesHidden()+"'/>") ;
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
            context.WriteHtmlText( "<hr/>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablepaymentedit_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid2Container.SetWrapped(nGXWrapped);
            StartGridControl123( ) ;
         }
         if ( wbEnd == 123 )
         {
            wbEnd = 0;
            nRC_GXsfl_123 = (int)(nGXsfl_123_idx-1);
            if ( Grid2Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV69GXV21 = nGXsfl_123_idx;
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
         if ( wbEnd == 62 )
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
                  AV49GXV1 = nGXsfl_62_idx;
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
         if ( wbEnd == 76 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridpaymentcancelContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV56GXV8 = nGXsfl_76_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridpaymentcancelContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridpaymentcancel", GridpaymentcancelContainer, subGridpaymentcancel_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridpaymentcancelContainerData", GridpaymentcancelContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridpaymentcancelContainerData"+"V", GridpaymentcancelContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridpaymentcancelContainerData"+"V"+"\" value='"+GridpaymentcancelContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         if ( wbEnd == 108 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridinvoicedetailseditContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV61GXV13 = nGXsfl_108_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridinvoicedetailseditContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridinvoicedetailsedit", GridinvoicedetailseditContainer, subGridinvoicedetailsedit_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridinvoicedetailseditContainerData", GridinvoicedetailseditContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridinvoicedetailseditContainerData"+"V", GridinvoicedetailseditContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridinvoicedetailseditContainerData"+"V"+"\" value='"+GridinvoicedetailseditContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         if ( wbEnd == 123 )
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
                  AV69GXV21 = nGXsfl_123_idx;
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
                           else if ( StringUtil.StrCmp(sEvt, "'CANCEL'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Cancel' */
                              E124K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VFILTERNRO.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E134K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VFILTERCREATEDDATEFROM.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E144K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VFILTERCREATEDDATETO.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E154K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CONFIRMCANCEL'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'ConfirmCancel' */
                              E164K2 ();
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
                           if ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRID1.LOAD") == 0 )
                           {
                              nGXsfl_62_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_62_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_62_idx), 4, 0), 4, "0");
                              SubsflControlProps_6212( ) ;
                              AV49GXV1 = nGXsfl_62_idx;
                              if ( ( AV15SDTCarProducts_Cancel.Count >= AV49GXV1 ) && ( AV49GXV1 > 0 ) )
                              {
                                 AV15SDTCarProducts_Cancel.CurrentItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV15SDTCarProducts_Cancel.Item(AV49GXV1));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "GRID1.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E174K12 ();
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
                           else if ( StringUtil.StrCmp(StringUtil.Left( sEvt, 22), "GRIDPAYMENTCANCEL.LOAD") == 0 )
                           {
                              nGXsfl_76_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx), 4, 0), 4, "0");
                              SubsflControlProps_7611( ) ;
                              AV56GXV8 = nGXsfl_76_idx;
                              if ( ( AV39SDTInvoiceAddPaymentMethod_Cancel.Count >= AV56GXV8 ) && ( AV56GXV8 > 0 ) )
                              {
                                 AV39SDTInvoiceAddPaymentMethod_Cancel.CurrentItem = ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV39SDTInvoiceAddPaymentMethod_Cancel.Item(AV56GXV8));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "GRIDPAYMENTCANCEL.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E184K11 ();
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
                           else if ( StringUtil.StrCmp(StringUtil.Left( sEvt, 27), "GRIDINVOICEDETAILSEDIT.LOAD") == 0 )
                           {
                              nGXsfl_108_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_108_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_108_idx), 4, 0), 4, "0");
                              SubsflControlProps_10810( ) ;
                              AV61GXV13 = nGXsfl_108_idx;
                              if ( ( AV16SDTCarProducts_Edit.Count >= AV61GXV13 ) && ( AV61GXV13 > 0 ) )
                              {
                                 AV16SDTCarProducts_Edit.CurrentItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV16SDTCarProducts_Edit.Item(AV61GXV13));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "GRIDINVOICEDETAILSEDIT.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E194K10 ();
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
                           else if ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRID2.LOAD") == 0 )
                           {
                              nGXsfl_123_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_123_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_123_idx), 4, 0), 4, "0");
                              SubsflControlProps_1239( ) ;
                              AV69GXV21 = nGXsfl_123_idx;
                              if ( ( AV38SDTInvoiceAddPaymentMethod_Edit.Count >= AV69GXV21 ) && ( AV69GXV21 > 0 ) )
                              {
                                 AV38SDTInvoiceAddPaymentMethod_Edit.CurrentItem = ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV38SDTInvoiceAddPaymentMethod_Edit.Item(AV69GXV21));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "GRID2.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E204K9 ();
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
                           else if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 16), "GRIDINVOICE.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 20), "VCANCELINVOICE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VEDITINVOICE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VEDITINVOICE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 20), "VCANCELINVOICE.CLICK") == 0 ) )
                           {
                              nGXsfl_25_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_25_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_25_idx), 4, 0), 4, "0");
                              SubsflControlProps_252( ) ;
                              AV40EditInvoice = cgiGet( edtavEditinvoice_Internalname);
                              AssignProp("", false, edtavEditinvoice_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV40EditInvoice)) ? AV75Editinvoice_GXI : context.convertURL( context.PathToRelativeUrl( AV40EditInvoice))), !bGXsfl_25_Refreshing);
                              AssignProp("", false, edtavEditinvoice_Internalname, "SrcSet", context.GetImageSrcSet( AV40EditInvoice), true);
                              AV28CancelInvoice = cgiGet( edtavCancelinvoice_Internalname);
                              AssignProp("", false, edtavCancelinvoice_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV28CancelInvoice)) ? AV74Cancelinvoice_GXI : context.convertURL( context.PathToRelativeUrl( AV28CancelInvoice))), !bGXsfl_25_Refreshing);
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
                                    E214K2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDINVOICE.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E224K2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VCANCELINVOICE.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E234K2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VEDITINVOICE.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E244K2 ();
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

      protected void gxnrGrid2_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1239( ) ;
         while ( nGXsfl_123_idx <= nRC_GXsfl_123 )
         {
            sendrow_1239( ) ;
            nGXsfl_123_idx = ((subGrid2_Islastpage==1)&&(nGXsfl_123_idx+1>subGrid2_fnc_Recordsperpage( )) ? 1 : nGXsfl_123_idx+1);
            sGXsfl_123_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_123_idx), 4, 0), 4, "0");
            SubsflControlProps_1239( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid2Container)) ;
         /* End function gxnrGrid2_newrow */
      }

      protected void gxnrGridinvoicedetailsedit_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_10810( ) ;
         while ( nGXsfl_108_idx <= nRC_GXsfl_108 )
         {
            sendrow_10810( ) ;
            nGXsfl_108_idx = ((subGridinvoicedetailsedit_Islastpage==1)&&(nGXsfl_108_idx+1>subGridinvoicedetailsedit_fnc_Recordsperpage( )) ? 1 : nGXsfl_108_idx+1);
            sGXsfl_108_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_108_idx), 4, 0), 4, "0");
            SubsflControlProps_10810( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridinvoicedetailseditContainer)) ;
         /* End function gxnrGridinvoicedetailsedit_newrow */
      }

      protected void gxnrGridpaymentcancel_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_7611( ) ;
         while ( nGXsfl_76_idx <= nRC_GXsfl_76 )
         {
            sendrow_7611( ) ;
            nGXsfl_76_idx = ((subGridpaymentcancel_Islastpage==1)&&(nGXsfl_76_idx+1>subGridpaymentcancel_fnc_Recordsperpage( )) ? 1 : nGXsfl_76_idx+1);
            sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx), 4, 0), 4, "0");
            SubsflControlProps_7611( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridpaymentcancelContainer)) ;
         /* End function gxnrGridpaymentcancel_newrow */
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_6212( ) ;
         while ( nGXsfl_62_idx <= nRC_GXsfl_62 )
         {
            sendrow_6212( ) ;
            nGXsfl_62_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_62_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_62_idx+1);
            sGXsfl_62_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_62_idx), 4, 0), 4, "0");
            SubsflControlProps_6212( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
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

      protected void gxgrGrid1_refresh( int subGridinvoice_Rows ,
                                        int AV31FilterNro ,
                                        DateTime AV33FilterCreatedDateFrom ,
                                        DateTime AV34FilterCreatedDateTo )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF4K12( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void gxgrGridpaymentcancel_refresh( int subGridinvoice_Rows ,
                                                    int AV31FilterNro ,
                                                    DateTime AV33FilterCreatedDateFrom ,
                                                    DateTime AV34FilterCreatedDateTo )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDPAYMENTCANCEL_nCurrentRecord = 0;
         RF4K11( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridpaymentcancel_refresh */
      }

      protected void gxgrGridinvoicedetailsedit_refresh( int subGridinvoice_Rows ,
                                                         int AV31FilterNro ,
                                                         DateTime AV33FilterCreatedDateFrom ,
                                                         DateTime AV34FilterCreatedDateTo )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDINVOICEDETAILSEDIT_nCurrentRecord = 0;
         RF4K10( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridinvoicedetailsedit_refresh */
      }

      protected void gxgrGrid2_refresh( int subGridinvoice_Rows ,
                                        int AV31FilterNro ,
                                        DateTime AV33FilterCreatedDateFrom ,
                                        DateTime AV34FilterCreatedDateTo )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID2_nCurrentRecord = 0;
         RF4K9( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid2_refresh */
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
         RF4K12( ) ;
         RF4K11( ) ;
         RF4K10( ) ;
         RF4K9( ) ;
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
         edtavImpottotalcancel_Enabled = 0;
         AssignProp("", false, edtavImpottotalcancel_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavImpottotalcancel_Enabled), 5, 0), true);
         edtavCtlcode_Enabled = 0;
         AssignProp("", false, edtavCtlcode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcode_Enabled), 5, 0), !bGXsfl_62_Refreshing);
         edtavCtlname_Enabled = 0;
         AssignProp("", false, edtavCtlname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname_Enabled), 5, 0), !bGXsfl_62_Refreshing);
         edtavCtlstock1_Enabled = 0;
         AssignProp("", false, edtavCtlstock1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlstock1_Enabled), 5, 0), !bGXsfl_62_Refreshing);
         edtavCtlquantity_Enabled = 0;
         AssignProp("", false, edtavCtlquantity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlquantity_Enabled), 5, 0), !bGXsfl_62_Refreshing);
         edtavCtlunitprice_Enabled = 0;
         AssignProp("", false, edtavCtlunitprice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlunitprice_Enabled), 5, 0), !bGXsfl_62_Refreshing);
         edtavCtlsubtotal_Enabled = 0;
         AssignProp("", false, edtavCtlsubtotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsubtotal_Enabled), 5, 0), !bGXsfl_62_Refreshing);
         edtavCtlpaymentmethoddescription1_Enabled = 0;
         AssignProp("", false, edtavCtlpaymentmethoddescription1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlpaymentmethoddescription1_Enabled), 5, 0), !bGXsfl_76_Refreshing);
         edtavCtlinvoicepaymentmethodimport1_Enabled = 0;
         AssignProp("", false, edtavCtlinvoicepaymentmethodimport1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlinvoicepaymentmethodimport1_Enabled), 5, 0), !bGXsfl_76_Refreshing);
         edtavCtlinvoicepaymentmethoddiscountimport1_Enabled = 0;
         AssignProp("", false, edtavCtlinvoicepaymentmethoddiscountimport1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlinvoicepaymentmethoddiscountimport1_Enabled), 5, 0), !bGXsfl_76_Refreshing);
         edtavCtlinvoicepaymentmethodrechargeimport1_Enabled = 0;
         AssignProp("", false, edtavCtlinvoicepaymentmethodrechargeimport1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlinvoicepaymentmethodrechargeimport1_Enabled), 5, 0), !bGXsfl_76_Refreshing);
         edtavCtlcode1_Enabled = 0;
         AssignProp("", false, edtavCtlcode1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcode1_Enabled), 5, 0), !bGXsfl_108_Refreshing);
         edtavCtlname1_Enabled = 0;
         AssignProp("", false, edtavCtlname1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname1_Enabled), 5, 0), !bGXsfl_108_Refreshing);
         edtavCtlstock_Enabled = 0;
         AssignProp("", false, edtavCtlstock_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlstock_Enabled), 5, 0), !bGXsfl_108_Refreshing);
         edtavCtlsubtotal1_Enabled = 0;
         AssignProp("", false, edtavCtlsubtotal1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsubtotal1_Enabled), 5, 0), !bGXsfl_108_Refreshing);
         edtavCtlproductminiumquantitywholesale_Enabled = 0;
         AssignProp("", false, edtavCtlproductminiumquantitywholesale_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlproductminiumquantitywholesale_Enabled), 5, 0), !bGXsfl_108_Refreshing);
         edtavCtlpaymentmethoddescription_Enabled = 0;
         AssignProp("", false, edtavCtlpaymentmethoddescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlpaymentmethoddescription_Enabled), 5, 0), !bGXsfl_123_Refreshing);
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
               E224K2 ();
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

      protected void RF4K9( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid2Container.ClearRows();
         }
         wbStart = 123;
         nGXsfl_123_idx = 1;
         sGXsfl_123_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_123_idx), 4, 0), 4, "0");
         SubsflControlProps_1239( ) ;
         bGXsfl_123_Refreshing = true;
         Grid2Container.AddObjectProperty("GridName", "Grid2");
         Grid2Container.AddObjectProperty("CmpContext", "");
         Grid2Container.AddObjectProperty("InMasterPage", "false");
         Grid2Container.AddObjectProperty("Class", "PromptGrid");
         Grid2Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid2Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid2Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Backcolorstyle), 1, 0, ".", "")));
         Grid2Container.PageSize = subGrid2_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1239( ) ;
            E204K9 ();
            wbEnd = 123;
            WB4K0( ) ;
         }
         bGXsfl_123_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes4K9( )
      {
      }

      protected void RF4K10( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridinvoicedetailseditContainer.ClearRows();
         }
         wbStart = 108;
         nGXsfl_108_idx = 1;
         sGXsfl_108_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_108_idx), 4, 0), 4, "0");
         SubsflControlProps_10810( ) ;
         bGXsfl_108_Refreshing = true;
         GridinvoicedetailseditContainer.AddObjectProperty("GridName", "Gridinvoicedetailsedit");
         GridinvoicedetailseditContainer.AddObjectProperty("CmpContext", "");
         GridinvoicedetailseditContainer.AddObjectProperty("InMasterPage", "false");
         GridinvoicedetailseditContainer.AddObjectProperty("Class", "PromptGrid");
         GridinvoicedetailseditContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridinvoicedetailseditContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridinvoicedetailseditContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoicedetailsedit_Backcolorstyle), 1, 0, ".", "")));
         GridinvoicedetailseditContainer.PageSize = subGridinvoicedetailsedit_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_10810( ) ;
            E194K10 ();
            wbEnd = 108;
            WB4K0( ) ;
         }
         bGXsfl_108_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes4K10( )
      {
      }

      protected void RF4K11( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridpaymentcancelContainer.ClearRows();
         }
         wbStart = 76;
         nGXsfl_76_idx = 1;
         sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx), 4, 0), 4, "0");
         SubsflControlProps_7611( ) ;
         bGXsfl_76_Refreshing = true;
         GridpaymentcancelContainer.AddObjectProperty("GridName", "Gridpaymentcancel");
         GridpaymentcancelContainer.AddObjectProperty("CmpContext", "");
         GridpaymentcancelContainer.AddObjectProperty("InMasterPage", "false");
         GridpaymentcancelContainer.AddObjectProperty("Class", "PromptGrid");
         GridpaymentcancelContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridpaymentcancelContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridpaymentcancelContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpaymentcancel_Backcolorstyle), 1, 0, ".", "")));
         GridpaymentcancelContainer.PageSize = subGridpaymentcancel_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_7611( ) ;
            E184K11 ();
            wbEnd = 76;
            WB4K0( ) ;
         }
         bGXsfl_76_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes4K11( )
      {
      }

      protected void RF4K12( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 62;
         nGXsfl_62_idx = 1;
         sGXsfl_62_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_62_idx), 4, 0), 4, "0");
         SubsflControlProps_6212( ) ;
         bGXsfl_62_Refreshing = true;
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
            SubsflControlProps_6212( ) ;
            E174K12 ();
            wbEnd = 62;
            WB4K0( ) ;
         }
         bGXsfl_62_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes4K12( )
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

      protected int subGridinvoicedetailsedit_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGridinvoicedetailsedit_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGridinvoicedetailsedit_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGridinvoicedetailsedit_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected int subGridpaymentcancel_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGridpaymentcancel_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGridpaymentcancel_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGridpaymentcancel_fnc_Currentpage( )
      {
         return (int)(-1) ;
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

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavDetails_Enabled = 0;
         AssignProp("", false, edtavDetails_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDetails_Enabled), 5, 0), !bGXsfl_25_Refreshing);
         edtavImpottotalcancel_Enabled = 0;
         AssignProp("", false, edtavImpottotalcancel_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavImpottotalcancel_Enabled), 5, 0), true);
         edtavCtlcode_Enabled = 0;
         AssignProp("", false, edtavCtlcode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcode_Enabled), 5, 0), !bGXsfl_62_Refreshing);
         edtavCtlname_Enabled = 0;
         AssignProp("", false, edtavCtlname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname_Enabled), 5, 0), !bGXsfl_62_Refreshing);
         edtavCtlstock1_Enabled = 0;
         AssignProp("", false, edtavCtlstock1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlstock1_Enabled), 5, 0), !bGXsfl_62_Refreshing);
         edtavCtlquantity_Enabled = 0;
         AssignProp("", false, edtavCtlquantity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlquantity_Enabled), 5, 0), !bGXsfl_62_Refreshing);
         edtavCtlunitprice_Enabled = 0;
         AssignProp("", false, edtavCtlunitprice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlunitprice_Enabled), 5, 0), !bGXsfl_62_Refreshing);
         edtavCtlsubtotal_Enabled = 0;
         AssignProp("", false, edtavCtlsubtotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsubtotal_Enabled), 5, 0), !bGXsfl_62_Refreshing);
         edtavCtlpaymentmethoddescription1_Enabled = 0;
         AssignProp("", false, edtavCtlpaymentmethoddescription1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlpaymentmethoddescription1_Enabled), 5, 0), !bGXsfl_76_Refreshing);
         edtavCtlinvoicepaymentmethodimport1_Enabled = 0;
         AssignProp("", false, edtavCtlinvoicepaymentmethodimport1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlinvoicepaymentmethodimport1_Enabled), 5, 0), !bGXsfl_76_Refreshing);
         edtavCtlinvoicepaymentmethoddiscountimport1_Enabled = 0;
         AssignProp("", false, edtavCtlinvoicepaymentmethoddiscountimport1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlinvoicepaymentmethoddiscountimport1_Enabled), 5, 0), !bGXsfl_76_Refreshing);
         edtavCtlinvoicepaymentmethodrechargeimport1_Enabled = 0;
         AssignProp("", false, edtavCtlinvoicepaymentmethodrechargeimport1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlinvoicepaymentmethodrechargeimport1_Enabled), 5, 0), !bGXsfl_76_Refreshing);
         edtavCtlcode1_Enabled = 0;
         AssignProp("", false, edtavCtlcode1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcode1_Enabled), 5, 0), !bGXsfl_108_Refreshing);
         edtavCtlname1_Enabled = 0;
         AssignProp("", false, edtavCtlname1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname1_Enabled), 5, 0), !bGXsfl_108_Refreshing);
         edtavCtlstock_Enabled = 0;
         AssignProp("", false, edtavCtlstock_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlstock_Enabled), 5, 0), !bGXsfl_108_Refreshing);
         edtavCtlsubtotal1_Enabled = 0;
         AssignProp("", false, edtavCtlsubtotal1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsubtotal1_Enabled), 5, 0), !bGXsfl_108_Refreshing);
         edtavCtlproductminiumquantitywholesale_Enabled = 0;
         AssignProp("", false, edtavCtlproductminiumquantitywholesale_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlproductminiumquantitywholesale_Enabled), 5, 0), !bGXsfl_108_Refreshing);
         edtavCtlpaymentmethoddescription_Enabled = 0;
         AssignProp("", false, edtavCtlpaymentmethoddescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlpaymentmethoddescription_Enabled), 5, 0), !bGXsfl_123_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4K0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E214K2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Sdtcarproducts_cancel"), AV15SDTCarProducts_Cancel);
            ajax_req_read_hidden_sdt(cgiGet( "Sdtinvoiceaddpaymentmethod_cancel"), AV39SDTInvoiceAddPaymentMethod_Cancel);
            ajax_req_read_hidden_sdt(cgiGet( "Sdtcarproducts_edit"), AV16SDTCarProducts_Edit);
            ajax_req_read_hidden_sdt(cgiGet( "Sdtinvoiceaddpaymentmethod_edit"), AV38SDTInvoiceAddPaymentMethod_Edit);
            ajax_req_read_hidden_sdt(cgiGet( "vSDTCARPRODUCTS_EDIT"), AV16SDTCarProducts_Edit);
            /* Read saved values. */
            nRC_GXsfl_25 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_25"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_62 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_62"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_76 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_76"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_108 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_108"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_123 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_123"), ".", ","), 18, MidpointRounding.ToEven));
            AV43ControlEdit = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vCONTROLEDIT"), ".", ","), 18, MidpointRounding.ToEven));
            GRIDINVOICE_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDINVOICE_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRIDINVOICE_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDINVOICE_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_62 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_62"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_62_fel_idx = 0;
            while ( nGXsfl_62_fel_idx < nRC_GXsfl_62 )
            {
               nGXsfl_62_fel_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_62_fel_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_62_fel_idx+1);
               sGXsfl_62_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_62_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_6212( ) ;
               AV49GXV1 = nGXsfl_62_fel_idx;
               if ( ( AV15SDTCarProducts_Cancel.Count >= AV49GXV1 ) && ( AV49GXV1 > 0 ) )
               {
                  AV15SDTCarProducts_Cancel.CurrentItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV15SDTCarProducts_Cancel.Item(AV49GXV1));
               }
            }
            if ( nGXsfl_62_fel_idx == 0 )
            {
               nGXsfl_62_idx = 1;
               sGXsfl_62_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_62_idx), 4, 0), 4, "0");
               SubsflControlProps_6212( ) ;
            }
            nGXsfl_62_fel_idx = 1;
            nRC_GXsfl_76 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_76"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_76_fel_idx = 0;
            while ( nGXsfl_76_fel_idx < nRC_GXsfl_76 )
            {
               nGXsfl_76_fel_idx = ((subGridpaymentcancel_Islastpage==1)&&(nGXsfl_76_fel_idx+1>subGridpaymentcancel_fnc_Recordsperpage( )) ? 1 : nGXsfl_76_fel_idx+1);
               sGXsfl_76_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_7611( ) ;
               AV56GXV8 = nGXsfl_76_fel_idx;
               if ( ( AV39SDTInvoiceAddPaymentMethod_Cancel.Count >= AV56GXV8 ) && ( AV56GXV8 > 0 ) )
               {
                  AV39SDTInvoiceAddPaymentMethod_Cancel.CurrentItem = ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV39SDTInvoiceAddPaymentMethod_Cancel.Item(AV56GXV8));
               }
            }
            if ( nGXsfl_76_fel_idx == 0 )
            {
               nGXsfl_76_idx = 1;
               sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx), 4, 0), 4, "0");
               SubsflControlProps_7611( ) ;
            }
            nGXsfl_76_fel_idx = 1;
            nRC_GXsfl_108 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_108"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_108_fel_idx = 0;
            while ( nGXsfl_108_fel_idx < nRC_GXsfl_108 )
            {
               nGXsfl_108_fel_idx = ((subGridinvoicedetailsedit_Islastpage==1)&&(nGXsfl_108_fel_idx+1>subGridinvoicedetailsedit_fnc_Recordsperpage( )) ? 1 : nGXsfl_108_fel_idx+1);
               sGXsfl_108_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_108_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_10810( ) ;
               AV61GXV13 = nGXsfl_108_fel_idx;
               if ( ( AV16SDTCarProducts_Edit.Count >= AV61GXV13 ) && ( AV61GXV13 > 0 ) )
               {
                  AV16SDTCarProducts_Edit.CurrentItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV16SDTCarProducts_Edit.Item(AV61GXV13));
               }
            }
            if ( nGXsfl_108_fel_idx == 0 )
            {
               nGXsfl_108_idx = 1;
               sGXsfl_108_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_108_idx), 4, 0), 4, "0");
               SubsflControlProps_10810( ) ;
            }
            nGXsfl_108_fel_idx = 1;
            nRC_GXsfl_123 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_123"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_123_fel_idx = 0;
            while ( nGXsfl_123_fel_idx < nRC_GXsfl_123 )
            {
               nGXsfl_123_fel_idx = ((subGrid2_Islastpage==1)&&(nGXsfl_123_fel_idx+1>subGrid2_fnc_Recordsperpage( )) ? 1 : nGXsfl_123_fel_idx+1);
               sGXsfl_123_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_123_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_1239( ) ;
               AV69GXV21 = nGXsfl_123_fel_idx;
               if ( ( AV38SDTInvoiceAddPaymentMethod_Edit.Count >= AV69GXV21 ) && ( AV69GXV21 > 0 ) )
               {
                  AV38SDTInvoiceAddPaymentMethod_Edit.CurrentItem = ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV38SDTInvoiceAddPaymentMethod_Edit.Item(AV69GXV21));
               }
            }
            if ( nGXsfl_123_fel_idx == 0 )
            {
               nGXsfl_123_idx = 1;
               sGXsfl_123_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_123_idx), 4, 0), 4, "0");
               SubsflControlProps_1239( ) ;
            }
            nGXsfl_123_fel_idx = 1;
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavImpottotalcancel_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavImpottotalcancel_Internalname), ".", ",") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vIMPOTTOTALCANCEL");
               GX_FocusControl = edtavImpottotalcancel_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV41ImpotTotalCancel = 0;
               AssignAttri("", false, "AV41ImpotTotalCancel", StringUtil.LTrimStr( AV41ImpotTotalCancel, 18, 2));
            }
            else
            {
               AV41ImpotTotalCancel = context.localUtil.CToN( cgiGet( edtavImpottotalcancel_Internalname), ".", ",");
               AssignAttri("", false, "AV41ImpotTotalCancel", StringUtil.LTrimStr( AV41ImpotTotalCancel, 18, 2));
            }
            AV19MovementDescription = cgiGet( edtavMovementdescription_Internalname);
            AssignAttri("", false, "AV19MovementDescription", AV19MovementDescription);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavImportreceivable_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavImportreceivable_Internalname), ".", ",") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vIMPORTRECEIVABLE");
               GX_FocusControl = edtavImportreceivable_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV35ImportReceivable = 0;
               AssignAttri("", false, "AV35ImportReceivable", StringUtil.LTrimStr( AV35ImportReceivable, 18, 2));
            }
            else
            {
               AV35ImportReceivable = context.localUtil.CToN( cgiGet( edtavImportreceivable_Internalname), ".", ",");
               AssignAttri("", false, "AV35ImportReceivable", StringUtil.LTrimStr( AV35ImportReceivable, 18, 2));
            }
            AV46MovementDescription_Edit = cgiGet( edtavMovementdescription_edit_Internalname);
            AssignAttri("", false, "AV46MovementDescription_Edit", AV46MovementDescription_Edit);
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
         E214K2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E214K2( )
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
         /* Execute user subroutine: 'CLEARSDTS' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         bttConfirmcancel_Jsonclick = "confirm('Are you sure Cancel Sale?')";
         AssignProp("", false, bttConfirmcancel_Internalname, "Jsonclick", bttConfirmcancel_Jsonclick, true);
         bttConfirmedit_Jsonclick = "confirm('Are you sure Edit Sale?')";
         AssignProp("", false, bttConfirmedit_Internalname, "Jsonclick", bttConfirmedit_Jsonclick, true);
      }

      private void E224K2( )
      {
         /* Gridinvoice_Load Routine */
         returnInSub = false;
         AV26Details = "Details";
         AssignAttri("", false, edtavDetails_Internalname, AV26Details);
         edtavCancelinvoice_gximage = "icon_cancel_order_enabled";
         AV28CancelInvoice = context.GetImagePath( "1403447e-77df-409a-a5f6-c34a5fd96a80", "", context.GetTheme( ));
         AssignAttri("", false, edtavCancelinvoice_Internalname, AV28CancelInvoice);
         AV74Cancelinvoice_GXI = GXDbFile.PathToUrl( context.GetImagePath( "1403447e-77df-409a-a5f6-c34a5fd96a80", "", context.GetTheme( )));
         edtavEditinvoice_gximage = "icon_edit_order_enabled";
         AV40EditInvoice = context.GetImagePath( "b4daee42-061f-42ce-b968-5722595bff36", "", context.GetTheme( ));
         AssignAttri("", false, edtavEditinvoice_Internalname, AV40EditInvoice);
         AV75Editinvoice_GXI = GXDbFile.PathToUrl( context.GetImagePath( "b4daee42-061f-42ce-b968-5722595bff36", "", context.GetTheme( )));
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

      protected void E234K2( )
      {
         AV49GXV1 = nGXsfl_62_idx;
         if ( ( AV49GXV1 > 0 ) && ( AV15SDTCarProducts_Cancel.Count >= AV49GXV1 ) )
         {
            AV15SDTCarProducts_Cancel.CurrentItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV15SDTCarProducts_Cancel.Item(AV49GXV1));
         }
         AV56GXV8 = nGXsfl_76_idx;
         if ( ( AV56GXV8 > 0 ) && ( AV39SDTInvoiceAddPaymentMethod_Cancel.Count >= AV56GXV8 ) )
         {
            AV39SDTInvoiceAddPaymentMethod_Cancel.CurrentItem = ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV39SDTInvoiceAddPaymentMethod_Cancel.Item(AV56GXV8));
         }
         /* Cancelinvoice_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'RESETWEBPANEL' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         divTablecancel_Visible = 1;
         AssignProp("", false, divTablecancel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablecancel_Visible), 5, 0), true);
         AV30InvoiceId = A20InvoiceId;
         AssignAttri("", false, "AV30InvoiceId", StringUtil.LTrimStr( (decimal)(AV30InvoiceId), 6, 0));
         /* Execute user subroutine: 'PREPAREINVOICECANCEL' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         if ( gx_BV62 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15SDTCarProducts_Cancel", AV15SDTCarProducts_Cancel);
            nGXsfl_62_bak_idx = nGXsfl_62_idx;
            gxgrGrid1_refresh( subGridinvoice_Rows, AV31FilterNro, AV33FilterCreatedDateFrom, AV34FilterCreatedDateTo) ;
            nGXsfl_62_idx = nGXsfl_62_bak_idx;
            sGXsfl_62_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_62_idx), 4, 0), 4, "0");
            SubsflControlProps_6212( ) ;
         }
         if ( gx_BV76 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39SDTInvoiceAddPaymentMethod_Cancel", AV39SDTInvoiceAddPaymentMethod_Cancel);
            nGXsfl_76_bak_idx = nGXsfl_76_idx;
            gxgrGridpaymentcancel_refresh( subGridinvoice_Rows, AV31FilterNro, AV33FilterCreatedDateFrom, AV34FilterCreatedDateTo) ;
            nGXsfl_76_idx = nGXsfl_76_bak_idx;
            sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx), 4, 0), 4, "0");
            SubsflControlProps_7611( ) ;
         }
         if ( gx_BV108 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV16SDTCarProducts_Edit", AV16SDTCarProducts_Edit);
            nGXsfl_108_bak_idx = nGXsfl_108_idx;
            gxgrGridinvoicedetailsedit_refresh( subGridinvoice_Rows, AV31FilterNro, AV33FilterCreatedDateFrom, AV34FilterCreatedDateTo) ;
            nGXsfl_108_idx = nGXsfl_108_bak_idx;
            sGXsfl_108_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_108_idx), 4, 0), 4, "0");
            SubsflControlProps_10810( ) ;
         }
         if ( gx_BV123 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38SDTInvoiceAddPaymentMethod_Edit", AV38SDTInvoiceAddPaymentMethod_Edit);
            nGXsfl_123_bak_idx = nGXsfl_123_idx;
            gxgrGrid2_refresh( subGridinvoice_Rows, AV31FilterNro, AV33FilterCreatedDateFrom, AV34FilterCreatedDateTo) ;
            nGXsfl_123_idx = nGXsfl_123_bak_idx;
            sGXsfl_123_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_123_idx), 4, 0), 4, "0");
            SubsflControlProps_1239( ) ;
         }
      }

      protected void E244K2( )
      {
         AV61GXV13 = nGXsfl_108_idx;
         if ( ( AV61GXV13 > 0 ) && ( AV16SDTCarProducts_Edit.Count >= AV61GXV13 ) )
         {
            AV16SDTCarProducts_Edit.CurrentItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV16SDTCarProducts_Edit.Item(AV61GXV13));
         }
         AV69GXV21 = nGXsfl_123_idx;
         if ( ( AV69GXV21 > 0 ) && ( AV38SDTInvoiceAddPaymentMethod_Edit.Count >= AV69GXV21 ) )
         {
            AV38SDTInvoiceAddPaymentMethod_Edit.CurrentItem = ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV38SDTInvoiceAddPaymentMethod_Edit.Item(AV69GXV21));
         }
         /* Editinvoice_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'RESETWEBPANEL' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         divTableedit_Visible = 1;
         AssignProp("", false, divTableedit_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableedit_Visible), 5, 0), true);
         AV30InvoiceId = A20InvoiceId;
         AssignAttri("", false, "AV30InvoiceId", StringUtil.LTrimStr( (decimal)(AV30InvoiceId), 6, 0));
         /* Execute user subroutine: 'PREPAREINVOICEEDIT' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         if ( gx_BV108 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV16SDTCarProducts_Edit", AV16SDTCarProducts_Edit);
            nGXsfl_108_bak_idx = nGXsfl_108_idx;
            gxgrGridinvoicedetailsedit_refresh( subGridinvoice_Rows, AV31FilterNro, AV33FilterCreatedDateFrom, AV34FilterCreatedDateTo) ;
            nGXsfl_108_idx = nGXsfl_108_bak_idx;
            sGXsfl_108_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_108_idx), 4, 0), 4, "0");
            SubsflControlProps_10810( ) ;
         }
         if ( gx_BV123 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38SDTInvoiceAddPaymentMethod_Edit", AV38SDTInvoiceAddPaymentMethod_Edit);
            nGXsfl_123_bak_idx = nGXsfl_123_idx;
            gxgrGrid2_refresh( subGridinvoice_Rows, AV31FilterNro, AV33FilterCreatedDateFrom, AV34FilterCreatedDateTo) ;
            nGXsfl_123_idx = nGXsfl_123_bak_idx;
            sGXsfl_123_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_123_idx), 4, 0), 4, "0");
            SubsflControlProps_1239( ) ;
         }
         if ( gx_BV76 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39SDTInvoiceAddPaymentMethod_Cancel", AV39SDTInvoiceAddPaymentMethod_Cancel);
            nGXsfl_76_bak_idx = nGXsfl_76_idx;
            gxgrGridpaymentcancel_refresh( subGridinvoice_Rows, AV31FilterNro, AV33FilterCreatedDateFrom, AV34FilterCreatedDateTo) ;
            nGXsfl_76_idx = nGXsfl_76_bak_idx;
            sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx), 4, 0), 4, "0");
            SubsflControlProps_7611( ) ;
         }
         if ( gx_BV62 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15SDTCarProducts_Cancel", AV15SDTCarProducts_Cancel);
            nGXsfl_62_bak_idx = nGXsfl_62_idx;
            gxgrGrid1_refresh( subGridinvoice_Rows, AV31FilterNro, AV33FilterCreatedDateFrom, AV34FilterCreatedDateTo) ;
            nGXsfl_62_idx = nGXsfl_62_bak_idx;
            sGXsfl_62_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_62_idx), 4, 0), 4, "0");
            SubsflControlProps_6212( ) ;
         }
      }

      protected void E124K2( )
      {
         /* 'Cancel' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'RESETWEBPANEL' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         if ( gx_BV76 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39SDTInvoiceAddPaymentMethod_Cancel", AV39SDTInvoiceAddPaymentMethod_Cancel);
            nGXsfl_76_bak_idx = nGXsfl_76_idx;
            gxgrGridpaymentcancel_refresh( subGridinvoice_Rows, AV31FilterNro, AV33FilterCreatedDateFrom, AV34FilterCreatedDateTo) ;
            nGXsfl_76_idx = nGXsfl_76_bak_idx;
            sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx), 4, 0), 4, "0");
            SubsflControlProps_7611( ) ;
         }
         if ( gx_BV108 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV16SDTCarProducts_Edit", AV16SDTCarProducts_Edit);
            nGXsfl_108_bak_idx = nGXsfl_108_idx;
            gxgrGridinvoicedetailsedit_refresh( subGridinvoice_Rows, AV31FilterNro, AV33FilterCreatedDateFrom, AV34FilterCreatedDateTo) ;
            nGXsfl_108_idx = nGXsfl_108_bak_idx;
            sGXsfl_108_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_108_idx), 4, 0), 4, "0");
            SubsflControlProps_10810( ) ;
         }
         if ( gx_BV123 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38SDTInvoiceAddPaymentMethod_Edit", AV38SDTInvoiceAddPaymentMethod_Edit);
            nGXsfl_123_bak_idx = nGXsfl_123_idx;
            gxgrGrid2_refresh( subGridinvoice_Rows, AV31FilterNro, AV33FilterCreatedDateFrom, AV34FilterCreatedDateTo) ;
            nGXsfl_123_idx = nGXsfl_123_bak_idx;
            sGXsfl_123_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_123_idx), 4, 0), 4, "0");
            SubsflControlProps_1239( ) ;
         }
         if ( gx_BV62 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15SDTCarProducts_Cancel", AV15SDTCarProducts_Cancel);
            nGXsfl_62_bak_idx = nGXsfl_62_idx;
            gxgrGrid1_refresh( subGridinvoice_Rows, AV31FilterNro, AV33FilterCreatedDateFrom, AV34FilterCreatedDateTo) ;
            nGXsfl_62_idx = nGXsfl_62_bak_idx;
            sGXsfl_62_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_62_idx), 4, 0), 4, "0");
            SubsflControlProps_6212( ) ;
         }
      }

      protected void E134K2( )
      {
         /* Filternro_Controlvaluechanged Routine */
         returnInSub = false;
         subgridinvoice_firstpage( ) ;
         gxgrGridinvoice_refresh( subGridinvoice_Rows, AV31FilterNro, AV33FilterCreatedDateFrom, AV34FilterCreatedDateTo) ;
      }

      protected void E144K2( )
      {
         /* Filtercreateddatefrom_Controlvaluechanged Routine */
         returnInSub = false;
         subgridinvoice_firstpage( ) ;
         gxgrGridinvoice_refresh( subGridinvoice_Rows, AV31FilterNro, AV33FilterCreatedDateFrom, AV34FilterCreatedDateTo) ;
      }

      protected void E154K2( )
      {
         /* Filtercreateddateto_Controlvaluechanged Routine */
         returnInSub = false;
         subgridinvoice_firstpage( ) ;
         gxgrGridinvoice_refresh( subGridinvoice_Rows, AV31FilterNro, AV33FilterCreatedDateFrom, AV34FilterCreatedDateTo) ;
      }

      protected void S112( )
      {
         /* 'HIDETABLES' Routine */
         returnInSub = false;
         divTablecancel_Visible = 0;
         AssignProp("", false, divTablecancel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablecancel_Visible), 5, 0), true);
         divTableedit_Visible = 0;
         AssignProp("", false, divTableedit_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableedit_Visible), 5, 0), true);
      }

      protected void S122( )
      {
         /* 'CLEARSDTS' Routine */
         returnInSub = false;
         AV44SDTCarProducts.Clear();
         AV39SDTInvoiceAddPaymentMethod_Cancel.Clear();
         gx_BV76 = true;
         AV16SDTCarProducts_Edit.Clear();
         gx_BV108 = true;
         AV45SDTInvoiceAddPaymentMethod.Clear();
      }

      protected void S142( )
      {
         /* 'PREPAREINVOICECANCEL' Routine */
         returnInSub = false;
         AV6AllOk = true;
         AV15SDTCarProducts_Cancel = new GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem>( context, "SDTCarProductsItem", "mtaKB");
         gx_BV62 = true;
         AV39SDTInvoiceAddPaymentMethod_Cancel = new GXBaseCollection<SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem>( context, "SDTInvoiceAddPaymentMethodItem", "mtaKB");
         gx_BV76 = true;
         AV41ImpotTotalCancel = 0;
         AssignAttri("", false, "AV41ImpotTotalCancel", StringUtil.LTrimStr( AV41ImpotTotalCancel, 18, 2));
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
               AV41ImpotTotalCancel = (decimal)(AV41ImpotTotalCancel+(AV18SDTCarProductsItem.gxTpr_Subtotal));
               AssignAttri("", false, "AV41ImpotTotalCancel", StringUtil.LTrimStr( AV41ImpotTotalCancel, 18, 2));
               AV15SDTCarProducts_Cancel.Add(AV18SDTCarProductsItem, 0);
               gx_BV62 = true;
               pr_default.readNext(3);
            }
            pr_default.close(3);
            /* Using cursor H004K12 */
            pr_default.execute(4, new Object[] {A20InvoiceId});
            while ( (pr_default.getStatus(4) != 101) )
            {
               A115PaymentMethodId = H004K12_A115PaymentMethodId[0];
               n115PaymentMethodId = H004K12_n115PaymentMethodId[0];
               A116PaymentMethodDescription = H004K12_A116PaymentMethodDescription[0];
               A132InvoicePaymentMethodRechargeIm = H004K12_A132InvoicePaymentMethodRechargeIm[0];
               n132InvoicePaymentMethodRechargeIm = H004K12_n132InvoicePaymentMethodRechargeIm[0];
               A133InvoicePaymentMethodDiscountIm = H004K12_A133InvoicePaymentMethodDiscountIm[0];
               n133InvoicePaymentMethodDiscountIm = H004K12_n133InvoicePaymentMethodDiscountIm[0];
               A120InvoicePaymentMethodImport = H004K12_A120InvoicePaymentMethodImport[0];
               n120InvoicePaymentMethodImport = H004K12_n120InvoicePaymentMethodImport[0];
               A116PaymentMethodDescription = H004K12_A116PaymentMethodDescription[0];
               AV42SDTInvoiceAddPaymentMethodItem = new SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem(context);
               AV42SDTInvoiceAddPaymentMethodItem.gxTpr_Paymentmethodid = A115PaymentMethodId;
               AV42SDTInvoiceAddPaymentMethodItem.gxTpr_Paymentmethoddescription = A116PaymentMethodDescription;
               AV42SDTInvoiceAddPaymentMethodItem.gxTpr_Invoicepaymentmethodrechargeimport = A132InvoicePaymentMethodRechargeIm;
               AV42SDTInvoiceAddPaymentMethodItem.gxTpr_Invoicepaymentmethoddiscountimport = A133InvoicePaymentMethodDiscountIm;
               AV42SDTInvoiceAddPaymentMethodItem.gxTpr_Invoicepaymentmethodimport = A120InvoicePaymentMethodImport;
               AV39SDTInvoiceAddPaymentMethod_Cancel.Add(AV42SDTInvoiceAddPaymentMethodItem, 0);
               gx_BV76 = true;
               pr_default.readNext(4);
            }
            pr_default.close(4);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
      }

      protected void S152( )
      {
         /* 'PREPAREINVOICEEDIT' Routine */
         returnInSub = false;
         AV6AllOk = true;
         AV16SDTCarProducts_Edit = new GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem>( context, "SDTCarProductsItem", "mtaKB");
         gx_BV108 = true;
         AV38SDTInvoiceAddPaymentMethod_Edit = new GXBaseCollection<SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem>( context, "SDTInvoiceAddPaymentMethodItem", "mtaKB");
         gx_BV123 = true;
         AV35ImportReceivable = 0;
         AssignAttri("", false, "AV35ImportReceivable", StringUtil.LTrimStr( AV35ImportReceivable, 18, 2));
         /* Using cursor H004K13 */
         pr_default.execute(5, new Object[] {AV30InvoiceId});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A20InvoiceId = H004K13_A20InvoiceId[0];
            /* Using cursor H004K14 */
            pr_default.execute(6, new Object[] {A20InvoiceId});
            while ( (pr_default.getStatus(6) != 101) )
            {
               A55ProductCode = H004K14_A55ProductCode[0];
               n55ProductCode = H004K14_n55ProductCode[0];
               A15ProductId = H004K14_A15ProductId[0];
               A16ProductName = H004K14_A16ProductName[0];
               A26InvoiceDetailQuantity = H004K14_A26InvoiceDetailQuantity[0];
               A65InvoiceDetailHistoricPrice = H004K14_A65InvoiceDetailHistoricPrice[0];
               A55ProductCode = H004K14_A55ProductCode[0];
               n55ProductCode = H004K14_n55ProductCode[0];
               A16ProductName = H004K14_A16ProductName[0];
               AV18SDTCarProductsItem = new SdtSDTCarProducts_SDTCarProductsItem(context);
               AV18SDTCarProductsItem.gxTpr_Code = A55ProductCode;
               AV18SDTCarProductsItem.gxTpr_Id = A15ProductId;
               AV18SDTCarProductsItem.gxTpr_Name = A16ProductName;
               AV18SDTCarProductsItem.gxTpr_Quantity = A26InvoiceDetailQuantity;
               AV18SDTCarProductsItem.gxTpr_Unitprice = A65InvoiceDetailHistoricPrice;
               AV18SDTCarProductsItem.gxTpr_Subtotal = (decimal)(A65InvoiceDetailHistoricPrice*A26InvoiceDetailQuantity);
               AV35ImportReceivable = (decimal)(AV35ImportReceivable+(AV18SDTCarProductsItem.gxTpr_Subtotal));
               AssignAttri("", false, "AV35ImportReceivable", StringUtil.LTrimStr( AV35ImportReceivable, 18, 2));
               AV16SDTCarProducts_Edit.Add(AV18SDTCarProductsItem, 0);
               gx_BV108 = true;
               pr_default.readNext(6);
            }
            pr_default.close(6);
            /* Using cursor H004K15 */
            pr_default.execute(7, new Object[] {A20InvoiceId});
            while ( (pr_default.getStatus(7) != 101) )
            {
               A115PaymentMethodId = H004K15_A115PaymentMethodId[0];
               n115PaymentMethodId = H004K15_n115PaymentMethodId[0];
               A116PaymentMethodDescription = H004K15_A116PaymentMethodDescription[0];
               A132InvoicePaymentMethodRechargeIm = H004K15_A132InvoicePaymentMethodRechargeIm[0];
               n132InvoicePaymentMethodRechargeIm = H004K15_n132InvoicePaymentMethodRechargeIm[0];
               A133InvoicePaymentMethodDiscountIm = H004K15_A133InvoicePaymentMethodDiscountIm[0];
               n133InvoicePaymentMethodDiscountIm = H004K15_n133InvoicePaymentMethodDiscountIm[0];
               A120InvoicePaymentMethodImport = H004K15_A120InvoicePaymentMethodImport[0];
               n120InvoicePaymentMethodImport = H004K15_n120InvoicePaymentMethodImport[0];
               A116PaymentMethodDescription = H004K15_A116PaymentMethodDescription[0];
               AV42SDTInvoiceAddPaymentMethodItem = new SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem(context);
               AV42SDTInvoiceAddPaymentMethodItem.gxTpr_Paymentmethodid = A115PaymentMethodId;
               AV42SDTInvoiceAddPaymentMethodItem.gxTpr_Paymentmethoddescription = A116PaymentMethodDescription;
               AV42SDTInvoiceAddPaymentMethodItem.gxTpr_Invoicepaymentmethodrechargeimport = A132InvoicePaymentMethodRechargeIm;
               AV42SDTInvoiceAddPaymentMethodItem.gxTpr_Invoicepaymentmethoddiscountimport = A133InvoicePaymentMethodDiscountIm;
               AV42SDTInvoiceAddPaymentMethodItem.gxTpr_Invoicepaymentmethodimport = A120InvoicePaymentMethodImport;
               AV38SDTInvoiceAddPaymentMethod_Edit.Add(AV42SDTInvoiceAddPaymentMethodItem, 0);
               gx_BV123 = true;
               pr_default.readNext(7);
            }
            pr_default.close(7);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(5);
      }

      protected void E164K2( )
      {
         /* 'ConfirmCancel' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CONTROLINVOICECANCEL' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV20ControlCancel )
         {
            AV6AllOk = true;
            AV9Invoice.Load(AV30InvoiceId);
            AV9Invoice.gxTpr_Invoiceactive = false;
            AV9Invoice.Update();
            if ( AV9Invoice.Success() )
            {
               AV82GXV26 = 1;
               while ( AV82GXV26 <= AV9Invoice.gxTpr_Detail.Count )
               {
                  AV14InvoiceDetail = ((SdtInvoice_Detail)AV9Invoice.gxTpr_Detail.Item(AV82GXV26));
                  AV11Product.Load(AV14InvoiceDetail.gxTpr_Productid);
                  AV11Product.gxTpr_Productstock = (int)(AV11Product.gxTpr_Productstock+(AV14InvoiceDetail.gxTpr_Invoicedetailquantity));
                  AV11Product.Update();
                  if ( ! AV11Product.Success() )
                  {
                     AV6AllOk = false;
                     AV7ErrorMessage = AV11Product.GetMessages().ToJSonString(false);
                     AssignAttri("", false, "AV7ErrorMessage", AV7ErrorMessage);
                     if (true) break;
                  }
                  AV82GXV26 = (int)(AV82GXV26+1);
               }
            }
            else
            {
               AV6AllOk = false;
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
                  AV7ErrorMessage = AV13Movement.GetMessages().ToJSonString(false);
                  AssignAttri("", false, "AV7ErrorMessage", AV7ErrorMessage);
               }
            }
            else
            {
               GX_msglist.addItem("Error to cancel Sale: "+AV7ErrorMessage);
            }
            if ( AV6AllOk )
            {
               context.CommitDataStores("wpregistermovement",pr_default);
               GX_msglist.addItem("Sale canceled successfully!");
               /* Execute user subroutine: 'RESETWEBPANEL' */
               S132 ();
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
         /*  Sending Event outputs  */
         if ( gx_BV76 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39SDTInvoiceAddPaymentMethod_Cancel", AV39SDTInvoiceAddPaymentMethod_Cancel);
            nGXsfl_76_bak_idx = nGXsfl_76_idx;
            gxgrGridpaymentcancel_refresh( subGridinvoice_Rows, AV31FilterNro, AV33FilterCreatedDateFrom, AV34FilterCreatedDateTo) ;
            nGXsfl_76_idx = nGXsfl_76_bak_idx;
            sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx), 4, 0), 4, "0");
            SubsflControlProps_7611( ) ;
         }
         if ( gx_BV108 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV16SDTCarProducts_Edit", AV16SDTCarProducts_Edit);
            nGXsfl_108_bak_idx = nGXsfl_108_idx;
            gxgrGridinvoicedetailsedit_refresh( subGridinvoice_Rows, AV31FilterNro, AV33FilterCreatedDateFrom, AV34FilterCreatedDateTo) ;
            nGXsfl_108_idx = nGXsfl_108_bak_idx;
            sGXsfl_108_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_108_idx), 4, 0), 4, "0");
            SubsflControlProps_10810( ) ;
         }
         if ( gx_BV123 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38SDTInvoiceAddPaymentMethod_Edit", AV38SDTInvoiceAddPaymentMethod_Edit);
            nGXsfl_123_bak_idx = nGXsfl_123_idx;
            gxgrGrid2_refresh( subGridinvoice_Rows, AV31FilterNro, AV33FilterCreatedDateFrom, AV34FilterCreatedDateTo) ;
            nGXsfl_123_idx = nGXsfl_123_bak_idx;
            sGXsfl_123_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_123_idx), 4, 0), 4, "0");
            SubsflControlProps_1239( ) ;
         }
         if ( gx_BV62 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15SDTCarProducts_Cancel", AV15SDTCarProducts_Cancel);
            nGXsfl_62_bak_idx = nGXsfl_62_idx;
            gxgrGrid1_refresh( subGridinvoice_Rows, AV31FilterNro, AV33FilterCreatedDateFrom, AV34FilterCreatedDateTo) ;
            nGXsfl_62_idx = nGXsfl_62_bak_idx;
            sGXsfl_62_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_62_idx), 4, 0), 4, "0");
            SubsflControlProps_6212( ) ;
         }
      }

      protected void S162( )
      {
         /* 'CONTROLINVOICECANCEL' Routine */
         returnInSub = false;
         AV20ControlCancel = true;
         AssignAttri("", false, "AV20ControlCancel", AV20ControlCancel);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV19MovementDescription)) )
         {
            AV20ControlCancel = false;
            AssignAttri("", false, "AV20ControlCancel", AV20ControlCancel);
            GX_msglist.addItem("Reason is required");
         }
      }

      protected void S172( )
      {
         /* 'CONTROLINVOICEEDIT' Routine */
         returnInSub = false;
         AV43ControlEdit = (short)(Convert.ToInt16(true));
         AssignAttri("", false, "AV43ControlEdit", StringUtil.LTrimStr( (decimal)(AV43ControlEdit), 4, 0));
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV19MovementDescription)) )
         {
            AV43ControlEdit = (short)(Convert.ToInt16(false));
            AssignAttri("", false, "AV43ControlEdit", StringUtil.LTrimStr( (decimal)(AV43ControlEdit), 4, 0));
            GX_msglist.addItem("Reason is required");
         }
         if ( AV16SDTCarProducts_Edit.Count == 0 )
         {
            AV43ControlEdit = (short)(Convert.ToInt16(false));
            AssignAttri("", false, "AV43ControlEdit", StringUtil.LTrimStr( (decimal)(AV43ControlEdit), 4, 0));
            GX_msglist.addItem("The sale must have one detail at least");
         }
      }

      protected void S182( )
      {
         /* 'CLEARVARIABLES' Routine */
         returnInSub = false;
         AV9Invoice = new SdtInvoice(context);
         AV11Product = new SdtProduct(context);
         AV13Movement = new SdtMovement(context);
         AV6AllOk = false;
         AV19MovementDescription = "";
         AssignAttri("", false, "AV19MovementDescription", AV19MovementDescription);
         AV16SDTCarProducts_Edit.Clear();
         gx_BV108 = true;
         AV38SDTInvoiceAddPaymentMethod_Edit.Clear();
         gx_BV123 = true;
         AV43ControlEdit = (short)(Convert.ToInt16(false));
         AssignAttri("", false, "AV43ControlEdit", StringUtil.LTrimStr( (decimal)(AV43ControlEdit), 4, 0));
         AV15SDTCarProducts_Cancel.Clear();
         gx_BV62 = true;
         AV39SDTInvoiceAddPaymentMethod_Cancel.Clear();
         gx_BV76 = true;
         AV20ControlCancel = false;
         AssignAttri("", false, "AV20ControlCancel", AV20ControlCancel);
      }

      protected void S132( )
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
         /* Execute user subroutine: 'CLEARSDTS' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'CLEARVARIABLES' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      private void E204K9( )
      {
         /* Grid2_Load Routine */
         returnInSub = false;
         AV69GXV21 = 1;
         while ( AV69GXV21 <= AV38SDTInvoiceAddPaymentMethod_Edit.Count )
         {
            AV38SDTInvoiceAddPaymentMethod_Edit.CurrentItem = ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV38SDTInvoiceAddPaymentMethod_Edit.Item(AV69GXV21));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 123;
            }
            sendrow_1239( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_123_Refreshing )
            {
               DoAjaxLoad(123, Grid2Row);
            }
            AV69GXV21 = (int)(AV69GXV21+1);
         }
      }

      private void E194K10( )
      {
         /* Gridinvoicedetailsedit_Load Routine */
         returnInSub = false;
         AV61GXV13 = 1;
         while ( AV61GXV13 <= AV16SDTCarProducts_Edit.Count )
         {
            AV16SDTCarProducts_Edit.CurrentItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV16SDTCarProducts_Edit.Item(AV61GXV13));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 108;
            }
            sendrow_10810( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_108_Refreshing )
            {
               DoAjaxLoad(108, GridinvoicedetailseditRow);
            }
            AV61GXV13 = (int)(AV61GXV13+1);
         }
      }

      private void E184K11( )
      {
         /* Gridpaymentcancel_Load Routine */
         returnInSub = false;
         AV56GXV8 = 1;
         while ( AV56GXV8 <= AV39SDTInvoiceAddPaymentMethod_Cancel.Count )
         {
            AV39SDTInvoiceAddPaymentMethod_Cancel.CurrentItem = ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV39SDTInvoiceAddPaymentMethod_Cancel.Item(AV56GXV8));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 76;
            }
            sendrow_7611( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_76_Refreshing )
            {
               DoAjaxLoad(76, GridpaymentcancelRow);
            }
            AV56GXV8 = (int)(AV56GXV8+1);
         }
      }

      private void E174K12( )
      {
         /* Grid1_Load Routine */
         returnInSub = false;
         AV49GXV1 = 1;
         while ( AV49GXV1 <= AV15SDTCarProducts_Cancel.Count )
         {
            AV15SDTCarProducts_Cancel.CurrentItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV15SDTCarProducts_Cancel.Item(AV49GXV1));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 62;
            }
            sendrow_6212( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_62_Refreshing )
            {
               DoAjaxLoad(62, Grid1Row);
            }
            AV49GXV1 = (int)(AV49GXV1+1);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20241218030897", true, true);
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
         context.AddJavascriptSource("wpregistermovement.js", "?20241218030897", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_252( )
      {
         edtavEditinvoice_Internalname = "vEDITINVOICE_"+sGXsfl_25_idx;
         edtavCancelinvoice_Internalname = "vCANCELINVOICE_"+sGXsfl_25_idx;
         edtInvoiceId_Internalname = "INVOICEID_"+sGXsfl_25_idx;
         edtInvoiceCreatedDate_Internalname = "INVOICECREATEDDATE_"+sGXsfl_25_idx;
         edtInvoiceTotalReceivable_Internalname = "INVOICETOTALRECEIVABLE_"+sGXsfl_25_idx;
         edtUserName_Internalname = "USERNAME_"+sGXsfl_25_idx;
         edtavDetails_Internalname = "vDETAILS_"+sGXsfl_25_idx;
      }

      protected void SubsflControlProps_fel_252( )
      {
         edtavEditinvoice_Internalname = "vEDITINVOICE_"+sGXsfl_25_fel_idx;
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
            TempTags = " " + ((edtavEditinvoice_Enabled!=0)&&(edtavEditinvoice_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 26,'',false,'',25)\"" : " ");
            ClassString = "Image" + " " + ((StringUtil.StrCmp(edtavEditinvoice_gximage, "")==0) ? "" : "GX_Image_"+edtavEditinvoice_gximage+"_Class");
            StyleString = "";
            AV40EditInvoice_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV40EditInvoice))&&String.IsNullOrEmpty(StringUtil.RTrim( AV75Editinvoice_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV40EditInvoice)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV40EditInvoice)) ? AV75Editinvoice_GXI : context.PathToRelativeUrl( AV40EditInvoice));
            GridinvoiceRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavEditinvoice_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"Edit Sale",(string)"Edit Sale",(short)0,(short)1,(short)25,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)5,(string)edtavEditinvoice_Jsonclick,"'"+""+"'"+",false,"+"'"+"EVEDITINVOICE.CLICK."+sGXsfl_25_idx+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV40EditInvoice_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridinvoiceContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Active Bitmap Variable */
            TempTags = " " + ((edtavCancelinvoice_Enabled!=0)&&(edtavCancelinvoice_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 27,'',false,'',25)\"" : " ");
            ClassString = "Image" + " " + ((StringUtil.StrCmp(edtavCancelinvoice_gximage, "")==0) ? "" : "GX_Image_"+edtavCancelinvoice_gximage+"_Class");
            StyleString = "";
            AV28CancelInvoice_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV28CancelInvoice))&&String.IsNullOrEmpty(StringUtil.RTrim( AV74Cancelinvoice_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV28CancelInvoice)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV28CancelInvoice)) ? AV74Cancelinvoice_GXI : context.PathToRelativeUrl( AV28CancelInvoice));
            GridinvoiceRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavCancelinvoice_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"Cancel Sale",(string)"Cancel Sale",(short)0,(short)1,(short)25,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)5,(string)edtavCancelinvoice_Jsonclick,"'"+""+"'"+",false,"+"'"+"EVCANCELINVOICE.CLICK."+sGXsfl_25_idx+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV28CancelInvoice_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
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
            TempTags = " " + ((edtavDetails_Enabled!=0)&&(edtavDetails_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 32,'',false,'"+sGXsfl_25_idx+"',25)\"" : " ");
            ROClassString = "Attribute";
            GridinvoiceRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDetails_Internalname,(string)AV26Details,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavDetails_Enabled!=0)&&(edtavDetails_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,32);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+"e254k2_client"+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDetails_Jsonclick,(short)7,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavDetails_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)25,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes4K2( ) ;
            GridinvoiceContainer.AddRow(GridinvoiceRow);
            nGXsfl_25_idx = ((subGridinvoice_Islastpage==1)&&(nGXsfl_25_idx+1>subGridinvoice_fnc_Recordsperpage( )) ? 1 : nGXsfl_25_idx+1);
            sGXsfl_25_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_25_idx), 4, 0), 4, "0");
            SubsflControlProps_252( ) ;
         }
         /* End function sendrow_252 */
      }

      protected void SubsflControlProps_6212( )
      {
         edtavCtlcode_Internalname = "CTLCODE_"+sGXsfl_62_idx;
         edtavCtlname_Internalname = "CTLNAME_"+sGXsfl_62_idx;
         edtavCtlstock1_Internalname = "CTLSTOCK1_"+sGXsfl_62_idx;
         edtavCtlquantity_Internalname = "CTLQUANTITY_"+sGXsfl_62_idx;
         edtavCtlunitprice_Internalname = "CTLUNITPRICE_"+sGXsfl_62_idx;
         edtavCtlsubtotal_Internalname = "CTLSUBTOTAL_"+sGXsfl_62_idx;
      }

      protected void SubsflControlProps_fel_6212( )
      {
         edtavCtlcode_Internalname = "CTLCODE_"+sGXsfl_62_fel_idx;
         edtavCtlname_Internalname = "CTLNAME_"+sGXsfl_62_fel_idx;
         edtavCtlstock1_Internalname = "CTLSTOCK1_"+sGXsfl_62_fel_idx;
         edtavCtlquantity_Internalname = "CTLQUANTITY_"+sGXsfl_62_fel_idx;
         edtavCtlunitprice_Internalname = "CTLUNITPRICE_"+sGXsfl_62_fel_idx;
         edtavCtlsubtotal_Internalname = "CTLSUBTOTAL_"+sGXsfl_62_fel_idx;
      }

      protected void sendrow_6212( )
      {
         SubsflControlProps_6212( ) ;
         WB4K0( ) ;
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
            if ( ((int)((nGXsfl_62_idx) % (2))) == 0 )
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
            context.WriteHtmlText( " gxrow=\""+sGXsfl_62_idx+"\">") ;
         }
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcode_Internalname,((SdtSDTCarProducts_SDTCarProductsItem)AV15SDTCarProducts_Cancel.Item(AV49GXV1)).gxTpr_Code,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcode_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlcode_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)62,(short)0,(short)-1,(short)-1,(bool)false,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname_Internalname,((SdtSDTCarProducts_SDTCarProductsItem)AV15SDTCarProducts_Cancel.Item(AV49GXV1)).gxTpr_Name,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)62,(short)0,(short)-1,(short)-1,(bool)false,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlstock1_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV15SDTCarProducts_Cancel.Item(AV49GXV1)).gxTpr_Stock), 6, 0, ".", "")),StringUtil.LTrim( ((edtavCtlstock1_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV15SDTCarProducts_Cancel.Item(AV49GXV1)).gxTpr_Stock), "ZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV15SDTCarProducts_Cancel.Item(AV49GXV1)).gxTpr_Stock), "ZZZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlstock1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlstock1_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)62,(short)0,(short)-1,(short)0,(bool)false,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlquantity_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV15SDTCarProducts_Cancel.Item(AV49GXV1)).gxTpr_Quantity), 6, 0, ".", "")),StringUtil.LTrim( ((edtavCtlquantity_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV15SDTCarProducts_Cancel.Item(AV49GXV1)).gxTpr_Quantity), "ZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV15SDTCarProducts_Cancel.Item(AV49GXV1)).gxTpr_Quantity), "ZZZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlquantity_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlquantity_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)62,(short)0,(short)-1,(short)0,(bool)false,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlunitprice_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTCarProducts_SDTCarProductsItem)AV15SDTCarProducts_Cancel.Item(AV49GXV1)).gxTpr_Unitprice, 18, 2, ".", "")),StringUtil.LTrim( ((edtavCtlunitprice_Enabled!=0) ? context.localUtil.Format( ((SdtSDTCarProducts_SDTCarProductsItem)AV15SDTCarProducts_Cancel.Item(AV49GXV1)).gxTpr_Unitprice, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTCarProducts_SDTCarProductsItem)AV15SDTCarProducts_Cancel.Item(AV49GXV1)).gxTpr_Unitprice, "ZZZZZZZZZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlunitprice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlunitprice_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)62,(short)0,(short)-1,(short)0,(bool)false,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsubtotal_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTCarProducts_SDTCarProductsItem)AV15SDTCarProducts_Cancel.Item(AV49GXV1)).gxTpr_Subtotal, 18, 2, ".", "")),StringUtil.LTrim( ((edtavCtlsubtotal_Enabled!=0) ? context.localUtil.Format( ((SdtSDTCarProducts_SDTCarProductsItem)AV15SDTCarProducts_Cancel.Item(AV49GXV1)).gxTpr_Subtotal, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTCarProducts_SDTCarProductsItem)AV15SDTCarProducts_Cancel.Item(AV49GXV1)).gxTpr_Subtotal, "ZZZZZZZZZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlsubtotal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlsubtotal_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)62,(short)0,(short)-1,(short)0,(bool)false,(string)"",(string)"right",(bool)false,(string)""});
         send_integrity_lvl_hashes4K12( ) ;
         Grid1Container.AddRow(Grid1Row);
         nGXsfl_62_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_62_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_62_idx+1);
         sGXsfl_62_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_62_idx), 4, 0), 4, "0");
         SubsflControlProps_6212( ) ;
         /* End function sendrow_6212 */
      }

      protected void SubsflControlProps_7611( )
      {
         edtavCtlpaymentmethoddescription1_Internalname = "CTLPAYMENTMETHODDESCRIPTION1_"+sGXsfl_76_idx;
         edtavCtlinvoicepaymentmethodimport1_Internalname = "CTLINVOICEPAYMENTMETHODIMPORT1_"+sGXsfl_76_idx;
         edtavCtlinvoicepaymentmethoddiscountimport1_Internalname = "CTLINVOICEPAYMENTMETHODDISCOUNTIMPORT1_"+sGXsfl_76_idx;
         edtavCtlinvoicepaymentmethodrechargeimport1_Internalname = "CTLINVOICEPAYMENTMETHODRECHARGEIMPORT1_"+sGXsfl_76_idx;
      }

      protected void SubsflControlProps_fel_7611( )
      {
         edtavCtlpaymentmethoddescription1_Internalname = "CTLPAYMENTMETHODDESCRIPTION1_"+sGXsfl_76_fel_idx;
         edtavCtlinvoicepaymentmethodimport1_Internalname = "CTLINVOICEPAYMENTMETHODIMPORT1_"+sGXsfl_76_fel_idx;
         edtavCtlinvoicepaymentmethoddiscountimport1_Internalname = "CTLINVOICEPAYMENTMETHODDISCOUNTIMPORT1_"+sGXsfl_76_fel_idx;
         edtavCtlinvoicepaymentmethodrechargeimport1_Internalname = "CTLINVOICEPAYMENTMETHODRECHARGEIMPORT1_"+sGXsfl_76_fel_idx;
      }

      protected void sendrow_7611( )
      {
         SubsflControlProps_7611( ) ;
         WB4K0( ) ;
         GridpaymentcancelRow = GXWebRow.GetNew(context,GridpaymentcancelContainer);
         if ( subGridpaymentcancel_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridpaymentcancel_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridpaymentcancel_Class, "") != 0 )
            {
               subGridpaymentcancel_Linesclass = subGridpaymentcancel_Class+"Odd";
            }
         }
         else if ( subGridpaymentcancel_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridpaymentcancel_Backstyle = 0;
            subGridpaymentcancel_Backcolor = subGridpaymentcancel_Allbackcolor;
            if ( StringUtil.StrCmp(subGridpaymentcancel_Class, "") != 0 )
            {
               subGridpaymentcancel_Linesclass = subGridpaymentcancel_Class+"Uniform";
            }
         }
         else if ( subGridpaymentcancel_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridpaymentcancel_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridpaymentcancel_Class, "") != 0 )
            {
               subGridpaymentcancel_Linesclass = subGridpaymentcancel_Class+"Odd";
            }
            subGridpaymentcancel_Backcolor = (int)(0x0);
         }
         else if ( subGridpaymentcancel_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridpaymentcancel_Backstyle = 1;
            if ( ((int)((nGXsfl_76_idx) % (2))) == 0 )
            {
               subGridpaymentcancel_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridpaymentcancel_Class, "") != 0 )
               {
                  subGridpaymentcancel_Linesclass = subGridpaymentcancel_Class+"Even";
               }
            }
            else
            {
               subGridpaymentcancel_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridpaymentcancel_Class, "") != 0 )
               {
                  subGridpaymentcancel_Linesclass = subGridpaymentcancel_Class+"Odd";
               }
            }
         }
         if ( GridpaymentcancelContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr ") ;
            context.WriteHtmlText( " class=\""+"PromptGrid"+"\" style=\""+""+"\"") ;
            context.WriteHtmlText( " gxrow=\""+sGXsfl_76_idx+"\">") ;
         }
         /* Subfile cell */
         if ( GridpaymentcancelContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridpaymentcancelRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlpaymentmethoddescription1_Internalname,((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV39SDTInvoiceAddPaymentMethod_Cancel.Item(AV56GXV8)).gxTpr_Paymentmethoddescription,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlpaymentmethoddescription1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlpaymentmethoddescription1_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)76,(short)0,(short)-1,(short)-1,(bool)false,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridpaymentcancelContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridpaymentcancelRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlinvoicepaymentmethodimport1_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV39SDTInvoiceAddPaymentMethod_Cancel.Item(AV56GXV8)).gxTpr_Invoicepaymentmethodimport, 18, 2, ".", "")),StringUtil.LTrim( ((edtavCtlinvoicepaymentmethodimport1_Enabled!=0) ? context.localUtil.Format( ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV39SDTInvoiceAddPaymentMethod_Cancel.Item(AV56GXV8)).gxTpr_Invoicepaymentmethodimport, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV39SDTInvoiceAddPaymentMethod_Cancel.Item(AV56GXV8)).gxTpr_Invoicepaymentmethodimport, "ZZZZZZZZZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlinvoicepaymentmethodimport1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlinvoicepaymentmethodimport1_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)76,(short)0,(short)-1,(short)0,(bool)false,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( GridpaymentcancelContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridpaymentcancelRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlinvoicepaymentmethoddiscountimport1_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV39SDTInvoiceAddPaymentMethod_Cancel.Item(AV56GXV8)).gxTpr_Invoicepaymentmethoddiscountimport, 18, 2, ".", "")),StringUtil.LTrim( ((edtavCtlinvoicepaymentmethoddiscountimport1_Enabled!=0) ? context.localUtil.Format( ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV39SDTInvoiceAddPaymentMethod_Cancel.Item(AV56GXV8)).gxTpr_Invoicepaymentmethoddiscountimport, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV39SDTInvoiceAddPaymentMethod_Cancel.Item(AV56GXV8)).gxTpr_Invoicepaymentmethoddiscountimport, "ZZZZZZZZZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlinvoicepaymentmethoddiscountimport1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlinvoicepaymentmethoddiscountimport1_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)76,(short)0,(short)-1,(short)0,(bool)false,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( GridpaymentcancelContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridpaymentcancelRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlinvoicepaymentmethodrechargeimport1_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV39SDTInvoiceAddPaymentMethod_Cancel.Item(AV56GXV8)).gxTpr_Invoicepaymentmethodrechargeimport, 18, 2, ".", "")),StringUtil.LTrim( ((edtavCtlinvoicepaymentmethodrechargeimport1_Enabled!=0) ? context.localUtil.Format( ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV39SDTInvoiceAddPaymentMethod_Cancel.Item(AV56GXV8)).gxTpr_Invoicepaymentmethodrechargeimport, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV39SDTInvoiceAddPaymentMethod_Cancel.Item(AV56GXV8)).gxTpr_Invoicepaymentmethodrechargeimport, "ZZZZZZZZZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlinvoicepaymentmethodrechargeimport1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlinvoicepaymentmethodrechargeimport1_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)76,(short)0,(short)-1,(short)0,(bool)false,(string)"",(string)"right",(bool)false,(string)""});
         send_integrity_lvl_hashes4K11( ) ;
         GridpaymentcancelContainer.AddRow(GridpaymentcancelRow);
         nGXsfl_76_idx = ((subGridpaymentcancel_Islastpage==1)&&(nGXsfl_76_idx+1>subGridpaymentcancel_fnc_Recordsperpage( )) ? 1 : nGXsfl_76_idx+1);
         sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx), 4, 0), 4, "0");
         SubsflControlProps_7611( ) ;
         /* End function sendrow_7611 */
      }

      protected void SubsflControlProps_10810( )
      {
         edtavCtlcode1_Internalname = "CTLCODE1_"+sGXsfl_108_idx;
         edtavCtlname1_Internalname = "CTLNAME1_"+sGXsfl_108_idx;
         edtavCtlstock_Internalname = "CTLSTOCK_"+sGXsfl_108_idx;
         edtavCtlquantity1_Internalname = "CTLQUANTITY1_"+sGXsfl_108_idx;
         edtavCtlunitprice1_Internalname = "CTLUNITPRICE1_"+sGXsfl_108_idx;
         edtavCtlsubtotal1_Internalname = "CTLSUBTOTAL1_"+sGXsfl_108_idx;
         edtavCtlproductminiumquantitywholesale_Internalname = "CTLPRODUCTMINIUMQUANTITYWHOLESALE_"+sGXsfl_108_idx;
      }

      protected void SubsflControlProps_fel_10810( )
      {
         edtavCtlcode1_Internalname = "CTLCODE1_"+sGXsfl_108_fel_idx;
         edtavCtlname1_Internalname = "CTLNAME1_"+sGXsfl_108_fel_idx;
         edtavCtlstock_Internalname = "CTLSTOCK_"+sGXsfl_108_fel_idx;
         edtavCtlquantity1_Internalname = "CTLQUANTITY1_"+sGXsfl_108_fel_idx;
         edtavCtlunitprice1_Internalname = "CTLUNITPRICE1_"+sGXsfl_108_fel_idx;
         edtavCtlsubtotal1_Internalname = "CTLSUBTOTAL1_"+sGXsfl_108_fel_idx;
         edtavCtlproductminiumquantitywholesale_Internalname = "CTLPRODUCTMINIUMQUANTITYWHOLESALE_"+sGXsfl_108_fel_idx;
      }

      protected void sendrow_10810( )
      {
         SubsflControlProps_10810( ) ;
         WB4K0( ) ;
         GridinvoicedetailseditRow = GXWebRow.GetNew(context,GridinvoicedetailseditContainer);
         if ( subGridinvoicedetailsedit_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridinvoicedetailsedit_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridinvoicedetailsedit_Class, "") != 0 )
            {
               subGridinvoicedetailsedit_Linesclass = subGridinvoicedetailsedit_Class+"Odd";
            }
         }
         else if ( subGridinvoicedetailsedit_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridinvoicedetailsedit_Backstyle = 0;
            subGridinvoicedetailsedit_Backcolor = subGridinvoicedetailsedit_Allbackcolor;
            if ( StringUtil.StrCmp(subGridinvoicedetailsedit_Class, "") != 0 )
            {
               subGridinvoicedetailsedit_Linesclass = subGridinvoicedetailsedit_Class+"Uniform";
            }
         }
         else if ( subGridinvoicedetailsedit_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridinvoicedetailsedit_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridinvoicedetailsedit_Class, "") != 0 )
            {
               subGridinvoicedetailsedit_Linesclass = subGridinvoicedetailsedit_Class+"Odd";
            }
            subGridinvoicedetailsedit_Backcolor = (int)(0x0);
         }
         else if ( subGridinvoicedetailsedit_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridinvoicedetailsedit_Backstyle = 1;
            if ( ((int)((nGXsfl_108_idx) % (2))) == 0 )
            {
               subGridinvoicedetailsedit_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridinvoicedetailsedit_Class, "") != 0 )
               {
                  subGridinvoicedetailsedit_Linesclass = subGridinvoicedetailsedit_Class+"Even";
               }
            }
            else
            {
               subGridinvoicedetailsedit_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridinvoicedetailsedit_Class, "") != 0 )
               {
                  subGridinvoicedetailsedit_Linesclass = subGridinvoicedetailsedit_Class+"Odd";
               }
            }
         }
         if ( GridinvoicedetailseditContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr ") ;
            context.WriteHtmlText( " class=\""+"PromptGrid"+"\" style=\""+""+"\"") ;
            context.WriteHtmlText( " gxrow=\""+sGXsfl_108_idx+"\">") ;
         }
         /* Subfile cell */
         if ( GridinvoicedetailseditContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridinvoicedetailseditRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcode1_Internalname,((SdtSDTCarProducts_SDTCarProductsItem)AV16SDTCarProducts_Edit.Item(AV61GXV13)).gxTpr_Code,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcode1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlcode1_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)108,(short)0,(short)-1,(short)-1,(bool)false,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridinvoicedetailseditContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridinvoicedetailseditRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname1_Internalname,((SdtSDTCarProducts_SDTCarProductsItem)AV16SDTCarProducts_Edit.Item(AV61GXV13)).gxTpr_Name,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlname1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlname1_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)108,(short)0,(short)-1,(short)-1,(bool)false,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridinvoicedetailseditContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridinvoicedetailseditRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlstock_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV16SDTCarProducts_Edit.Item(AV61GXV13)).gxTpr_Stock), 6, 0, ".", "")),StringUtil.LTrim( ((edtavCtlstock_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV16SDTCarProducts_Edit.Item(AV61GXV13)).gxTpr_Stock), "ZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV16SDTCarProducts_Edit.Item(AV61GXV13)).gxTpr_Stock), "ZZZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlstock_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlstock_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)108,(short)0,(short)-1,(short)0,(bool)false,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( GridinvoicedetailseditContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavCtlquantity1_Enabled!=0)&&(edtavCtlquantity1_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 112,'',false,'"+sGXsfl_108_idx+"',108)\"" : " ");
         ROClassString = "Attribute";
         GridinvoicedetailseditRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlquantity1_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV16SDTCarProducts_Edit.Item(AV61GXV13)).gxTpr_Quantity), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV16SDTCarProducts_Edit.Item(AV61GXV13)).gxTpr_Quantity), "ZZZZZ9"))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+((edtavCtlquantity1_Enabled!=0)&&(edtavCtlquantity1_Visible!=0) ? " onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,112);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlquantity1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)1,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)108,(short)0,(short)-1,(short)0,(bool)false,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( GridinvoicedetailseditContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavCtlunitprice1_Enabled!=0)&&(edtavCtlunitprice1_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 113,'',false,'"+sGXsfl_108_idx+"',108)\"" : " ");
         ROClassString = "Attribute";
         GridinvoicedetailseditRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlunitprice1_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTCarProducts_SDTCarProductsItem)AV16SDTCarProducts_Edit.Item(AV61GXV13)).gxTpr_Unitprice, 18, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( ((SdtSDTCarProducts_SDTCarProductsItem)AV16SDTCarProducts_Edit.Item(AV61GXV13)).gxTpr_Unitprice, "ZZZZZZZZZZZZZZ9.99")),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+((edtavCtlunitprice1_Enabled!=0)&&(edtavCtlunitprice1_Visible!=0) ? " onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,113);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlunitprice1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)1,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)108,(short)0,(short)-1,(short)0,(bool)false,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( GridinvoicedetailseditContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridinvoicedetailseditRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsubtotal1_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTCarProducts_SDTCarProductsItem)AV16SDTCarProducts_Edit.Item(AV61GXV13)).gxTpr_Subtotal, 18, 2, ".", "")),StringUtil.LTrim( ((edtavCtlsubtotal1_Enabled!=0) ? context.localUtil.Format( ((SdtSDTCarProducts_SDTCarProductsItem)AV16SDTCarProducts_Edit.Item(AV61GXV13)).gxTpr_Subtotal, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTCarProducts_SDTCarProductsItem)AV16SDTCarProducts_Edit.Item(AV61GXV13)).gxTpr_Subtotal, "ZZZZZZZZZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlsubtotal1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlsubtotal1_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)108,(short)0,(short)-1,(short)0,(bool)false,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( GridinvoicedetailseditContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridinvoicedetailseditRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlproductminiumquantitywholesale_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV16SDTCarProducts_Edit.Item(AV61GXV13)).gxTpr_Productminiumquantitywholesale), 4, 0, ".", "")),StringUtil.LTrim( ((edtavCtlproductminiumquantitywholesale_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV16SDTCarProducts_Edit.Item(AV61GXV13)).gxTpr_Productminiumquantitywholesale), "ZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV16SDTCarProducts_Edit.Item(AV61GXV13)).gxTpr_Productminiumquantitywholesale), "ZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlproductminiumquantitywholesale_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlproductminiumquantitywholesale_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)108,(short)0,(short)-1,(short)0,(bool)false,(string)"",(string)"right",(bool)false,(string)""});
         send_integrity_lvl_hashes4K10( ) ;
         GridinvoicedetailseditContainer.AddRow(GridinvoicedetailseditRow);
         nGXsfl_108_idx = ((subGridinvoicedetailsedit_Islastpage==1)&&(nGXsfl_108_idx+1>subGridinvoicedetailsedit_fnc_Recordsperpage( )) ? 1 : nGXsfl_108_idx+1);
         sGXsfl_108_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_108_idx), 4, 0), 4, "0");
         SubsflControlProps_10810( ) ;
         /* End function sendrow_10810 */
      }

      protected void SubsflControlProps_1239( )
      {
         edtavCtlpaymentmethoddescription_Internalname = "CTLPAYMENTMETHODDESCRIPTION_"+sGXsfl_123_idx;
         edtavCtlinvoicepaymentmethodimport_Internalname = "CTLINVOICEPAYMENTMETHODIMPORT_"+sGXsfl_123_idx;
         edtavCtlinvoicepaymentmethoddiscountimport_Internalname = "CTLINVOICEPAYMENTMETHODDISCOUNTIMPORT_"+sGXsfl_123_idx;
         edtavCtlinvoicepaymentmethodrechargeimport_Internalname = "CTLINVOICEPAYMENTMETHODRECHARGEIMPORT_"+sGXsfl_123_idx;
      }

      protected void SubsflControlProps_fel_1239( )
      {
         edtavCtlpaymentmethoddescription_Internalname = "CTLPAYMENTMETHODDESCRIPTION_"+sGXsfl_123_fel_idx;
         edtavCtlinvoicepaymentmethodimport_Internalname = "CTLINVOICEPAYMENTMETHODIMPORT_"+sGXsfl_123_fel_idx;
         edtavCtlinvoicepaymentmethoddiscountimport_Internalname = "CTLINVOICEPAYMENTMETHODDISCOUNTIMPORT_"+sGXsfl_123_fel_idx;
         edtavCtlinvoicepaymentmethodrechargeimport_Internalname = "CTLINVOICEPAYMENTMETHODRECHARGEIMPORT_"+sGXsfl_123_fel_idx;
      }

      protected void sendrow_1239( )
      {
         SubsflControlProps_1239( ) ;
         WB4K0( ) ;
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
            if ( ((int)((nGXsfl_123_idx) % (2))) == 0 )
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
            context.WriteHtmlText( " class=\""+"PromptGrid"+"\" style=\""+""+"\"") ;
            context.WriteHtmlText( " gxrow=\""+sGXsfl_123_idx+"\">") ;
         }
         /* Subfile cell */
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlpaymentmethoddescription_Internalname,((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV38SDTInvoiceAddPaymentMethod_Edit.Item(AV69GXV21)).gxTpr_Paymentmethoddescription,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlpaymentmethoddescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlpaymentmethoddescription_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)123,(short)0,(short)-1,(short)-1,(bool)false,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavCtlinvoicepaymentmethodimport_Enabled!=0)&&(edtavCtlinvoicepaymentmethodimport_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 125,'',false,'"+sGXsfl_123_idx+"',123)\"" : " ");
         ROClassString = "Attribute";
         Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlinvoicepaymentmethodimport_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV38SDTInvoiceAddPaymentMethod_Edit.Item(AV69GXV21)).gxTpr_Invoicepaymentmethodimport, 18, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV38SDTInvoiceAddPaymentMethod_Edit.Item(AV69GXV21)).gxTpr_Invoicepaymentmethodimport, "ZZZZZZZZZZZZZZ9.99")),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+((edtavCtlinvoicepaymentmethodimport_Enabled!=0)&&(edtavCtlinvoicepaymentmethodimport_Visible!=0) ? " onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,125);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlinvoicepaymentmethodimport_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)1,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)123,(short)0,(short)-1,(short)0,(bool)false,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavCtlinvoicepaymentmethoddiscountimport_Enabled!=0)&&(edtavCtlinvoicepaymentmethoddiscountimport_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 126,'',false,'"+sGXsfl_123_idx+"',123)\"" : " ");
         ROClassString = "Attribute";
         Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlinvoicepaymentmethoddiscountimport_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV38SDTInvoiceAddPaymentMethod_Edit.Item(AV69GXV21)).gxTpr_Invoicepaymentmethoddiscountimport, 18, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV38SDTInvoiceAddPaymentMethod_Edit.Item(AV69GXV21)).gxTpr_Invoicepaymentmethoddiscountimport, "ZZZZZZZZZZZZZZ9.99")),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+((edtavCtlinvoicepaymentmethoddiscountimport_Enabled!=0)&&(edtavCtlinvoicepaymentmethoddiscountimport_Visible!=0) ? " onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,126);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlinvoicepaymentmethoddiscountimport_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)1,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)123,(short)0,(short)-1,(short)0,(bool)false,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavCtlinvoicepaymentmethodrechargeimport_Enabled!=0)&&(edtavCtlinvoicepaymentmethodrechargeimport_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 127,'',false,'"+sGXsfl_123_idx+"',123)\"" : " ");
         ROClassString = "Attribute";
         Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlinvoicepaymentmethodrechargeimport_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV38SDTInvoiceAddPaymentMethod_Edit.Item(AV69GXV21)).gxTpr_Invoicepaymentmethodrechargeimport, 18, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV38SDTInvoiceAddPaymentMethod_Edit.Item(AV69GXV21)).gxTpr_Invoicepaymentmethodrechargeimport, "ZZZZZZZZZZZZZZ9.99")),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+((edtavCtlinvoicepaymentmethodrechargeimport_Enabled!=0)&&(edtavCtlinvoicepaymentmethodrechargeimport_Visible!=0) ? " onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,127);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlinvoicepaymentmethodrechargeimport_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)1,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)123,(short)0,(short)-1,(short)0,(bool)false,(string)"",(string)"right",(bool)false,(string)""});
         send_integrity_lvl_hashes4K9( ) ;
         Grid2Container.AddRow(Grid2Row);
         nGXsfl_123_idx = ((subGrid2_Islastpage==1)&&(nGXsfl_123_idx+1>subGrid2_fnc_Recordsperpage( )) ? 1 : nGXsfl_123_idx+1);
         sGXsfl_123_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_123_idx), 4, 0), 4, "0");
         SubsflControlProps_1239( ) ;
         /* End function sendrow_1239 */
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
            context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(25), 4, 0)+"px"+" class=\""+"Image"+" "+((StringUtil.StrCmp(edtavEditinvoice_gximage, "")==0) ? "" : "GX_Image_"+edtavEditinvoice_gximage+"_Class")+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(25), 4, 0)+"px"+" class=\""+"Image"+" "+((StringUtil.StrCmp(edtavCancelinvoice_gximage, "")==0) ? "" : "GX_Image_"+edtavCancelinvoice_gximage+"_Class")+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
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
            GridinvoiceColumn.AddObjectProperty("Value", context.convertURL( AV40EditInvoice));
            GridinvoiceContainer.AddColumnProperties(GridinvoiceColumn);
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

      protected void StartGridControl62( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"62\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "Details", 0);
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
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Code") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Current Stock") ;
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
            context.WriteHtmlTextNl( "</tr>") ;
            Grid1Container.AddObjectProperty("GridName", "Grid1");
         }
         else
         {
            Grid1Container.AddObjectProperty("GridName", "Grid1");
            Grid1Container.AddObjectProperty("Header", subGrid1_Header);
            Grid1Container.AddObjectProperty("Class", "PromptGrid");
            Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("CmpContext", "");
            Grid1Container.AddObjectProperty("InMasterPage", "false");
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlcode_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlname_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlstock1_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlquantity_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlunitprice_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlsubtotal_Enabled), 5, 0, ".", "")));
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

      protected void StartGridControl76( )
      {
         if ( GridpaymentcancelContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridpaymentcancelContainer"+"DivS\" data-gxgridid=\"76\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridpaymentcancel_Internalname, subGridpaymentcancel_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "Payment Methods", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGridpaymentcancel_Backcolorstyle == 0 )
            {
               subGridpaymentcancel_Titlebackstyle = 0;
               if ( StringUtil.Len( subGridpaymentcancel_Class) > 0 )
               {
                  subGridpaymentcancel_Linesclass = subGridpaymentcancel_Class+"Title";
               }
            }
            else
            {
               subGridpaymentcancel_Titlebackstyle = 1;
               if ( subGridpaymentcancel_Backcolorstyle == 1 )
               {
                  subGridpaymentcancel_Titlebackcolor = subGridpaymentcancel_Allbackcolor;
                  if ( StringUtil.Len( subGridpaymentcancel_Class) > 0 )
                  {
                     subGridpaymentcancel_Linesclass = subGridpaymentcancel_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGridpaymentcancel_Class) > 0 )
                  {
                     subGridpaymentcancel_Linesclass = subGridpaymentcancel_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Payment Method") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Import") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Discount") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Recharge") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridpaymentcancelContainer.AddObjectProperty("GridName", "Gridpaymentcancel");
         }
         else
         {
            GridpaymentcancelContainer.AddObjectProperty("GridName", "Gridpaymentcancel");
            GridpaymentcancelContainer.AddObjectProperty("Header", subGridpaymentcancel_Header);
            GridpaymentcancelContainer.AddObjectProperty("Class", "PromptGrid");
            GridpaymentcancelContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridpaymentcancelContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridpaymentcancelContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpaymentcancel_Backcolorstyle), 1, 0, ".", "")));
            GridpaymentcancelContainer.AddObjectProperty("CmpContext", "");
            GridpaymentcancelContainer.AddObjectProperty("InMasterPage", "false");
            GridpaymentcancelColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridpaymentcancelColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlpaymentmethoddescription1_Enabled), 5, 0, ".", "")));
            GridpaymentcancelContainer.AddColumnProperties(GridpaymentcancelColumn);
            GridpaymentcancelColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridpaymentcancelColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlinvoicepaymentmethodimport1_Enabled), 5, 0, ".", "")));
            GridpaymentcancelContainer.AddColumnProperties(GridpaymentcancelColumn);
            GridpaymentcancelColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridpaymentcancelColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlinvoicepaymentmethoddiscountimport1_Enabled), 5, 0, ".", "")));
            GridpaymentcancelContainer.AddColumnProperties(GridpaymentcancelColumn);
            GridpaymentcancelColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridpaymentcancelColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlinvoicepaymentmethodrechargeimport1_Enabled), 5, 0, ".", "")));
            GridpaymentcancelContainer.AddColumnProperties(GridpaymentcancelColumn);
            GridpaymentcancelContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpaymentcancel_Selectedindex), 4, 0, ".", "")));
            GridpaymentcancelContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpaymentcancel_Allowselection), 1, 0, ".", "")));
            GridpaymentcancelContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpaymentcancel_Selectioncolor), 9, 0, ".", "")));
            GridpaymentcancelContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpaymentcancel_Allowhovering), 1, 0, ".", "")));
            GridpaymentcancelContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpaymentcancel_Hoveringcolor), 9, 0, ".", "")));
            GridpaymentcancelContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpaymentcancel_Allowcollapsing), 1, 0, ".", "")));
            GridpaymentcancelContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpaymentcancel_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void StartGridControl108( )
      {
         if ( GridinvoicedetailseditContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridinvoicedetailseditContainer"+"DivS\" data-gxgridid=\"108\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridinvoicedetailsedit_Internalname, subGridinvoicedetailsedit_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGridinvoicedetailsedit_Backcolorstyle == 0 )
            {
               subGridinvoicedetailsedit_Titlebackstyle = 0;
               if ( StringUtil.Len( subGridinvoicedetailsedit_Class) > 0 )
               {
                  subGridinvoicedetailsedit_Linesclass = subGridinvoicedetailsedit_Class+"Title";
               }
            }
            else
            {
               subGridinvoicedetailsedit_Titlebackstyle = 1;
               if ( subGridinvoicedetailsedit_Backcolorstyle == 1 )
               {
                  subGridinvoicedetailsedit_Titlebackcolor = subGridinvoicedetailsedit_Allbackcolor;
                  if ( StringUtil.Len( subGridinvoicedetailsedit_Class) > 0 )
                  {
                     subGridinvoicedetailsedit_Linesclass = subGridinvoicedetailsedit_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGridinvoicedetailsedit_Class) > 0 )
                  {
                     subGridinvoicedetailsedit_Linesclass = subGridinvoicedetailsedit_Class+"Title";
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
            context.SendWebValue( "Current Stock") ;
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
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Min Qty. Wholesale") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridinvoicedetailseditContainer.AddObjectProperty("GridName", "Gridinvoicedetailsedit");
         }
         else
         {
            GridinvoicedetailseditContainer.AddObjectProperty("GridName", "Gridinvoicedetailsedit");
            GridinvoicedetailseditContainer.AddObjectProperty("Header", subGridinvoicedetailsedit_Header);
            GridinvoicedetailseditContainer.AddObjectProperty("Class", "PromptGrid");
            GridinvoicedetailseditContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridinvoicedetailseditContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridinvoicedetailseditContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoicedetailsedit_Backcolorstyle), 1, 0, ".", "")));
            GridinvoicedetailseditContainer.AddObjectProperty("CmpContext", "");
            GridinvoicedetailseditContainer.AddObjectProperty("InMasterPage", "false");
            GridinvoicedetailseditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridinvoicedetailseditColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlcode1_Enabled), 5, 0, ".", "")));
            GridinvoicedetailseditContainer.AddColumnProperties(GridinvoicedetailseditColumn);
            GridinvoicedetailseditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridinvoicedetailseditColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlname1_Enabled), 5, 0, ".", "")));
            GridinvoicedetailseditContainer.AddColumnProperties(GridinvoicedetailseditColumn);
            GridinvoicedetailseditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridinvoicedetailseditColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlstock_Enabled), 5, 0, ".", "")));
            GridinvoicedetailseditContainer.AddColumnProperties(GridinvoicedetailseditColumn);
            GridinvoicedetailseditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridinvoicedetailseditContainer.AddColumnProperties(GridinvoicedetailseditColumn);
            GridinvoicedetailseditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridinvoicedetailseditContainer.AddColumnProperties(GridinvoicedetailseditColumn);
            GridinvoicedetailseditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridinvoicedetailseditColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlsubtotal1_Enabled), 5, 0, ".", "")));
            GridinvoicedetailseditContainer.AddColumnProperties(GridinvoicedetailseditColumn);
            GridinvoicedetailseditColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridinvoicedetailseditColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlproductminiumquantitywholesale_Enabled), 5, 0, ".", "")));
            GridinvoicedetailseditContainer.AddColumnProperties(GridinvoicedetailseditColumn);
            GridinvoicedetailseditContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoicedetailsedit_Selectedindex), 4, 0, ".", "")));
            GridinvoicedetailseditContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoicedetailsedit_Allowselection), 1, 0, ".", "")));
            GridinvoicedetailseditContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoicedetailsedit_Selectioncolor), 9, 0, ".", "")));
            GridinvoicedetailseditContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoicedetailsedit_Allowhovering), 1, 0, ".", "")));
            GridinvoicedetailseditContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoicedetailsedit_Hoveringcolor), 9, 0, ".", "")));
            GridinvoicedetailseditContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoicedetailsedit_Allowcollapsing), 1, 0, ".", "")));
            GridinvoicedetailseditContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoicedetailsedit_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void StartGridControl123( )
      {
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid2Container"+"DivS\" data-gxgridid=\"123\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid2_Internalname, subGrid2_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
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
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Payment Method") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Import") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Discount") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Recharge") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Grid2Container.AddObjectProperty("GridName", "Grid2");
         }
         else
         {
            Grid2Container.AddObjectProperty("GridName", "Grid2");
            Grid2Container.AddObjectProperty("Header", subGrid2_Header);
            Grid2Container.AddObjectProperty("Class", "PromptGrid");
            Grid2Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid2Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid2Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Backcolorstyle), 1, 0, ".", "")));
            Grid2Container.AddObjectProperty("CmpContext", "");
            Grid2Container.AddObjectProperty("InMasterPage", "false");
            Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid2Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlpaymentmethoddescription_Enabled), 5, 0, ".", "")));
            Grid2Container.AddColumnProperties(Grid2Column);
            Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid2Container.AddColumnProperties(Grid2Column);
            Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid2Container.AddColumnProperties(Grid2Column);
            Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
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
         edtavFilternro_Internalname = "vFILTERNRO";
         edtavFiltercreateddatefrom_Internalname = "vFILTERCREATEDDATEFROM";
         edtavFiltercreateddateto_Internalname = "vFILTERCREATEDDATETO";
         divTablefilters_Internalname = "TABLEFILTERS";
         edtavEditinvoice_Internalname = "vEDITINVOICE";
         edtavCancelinvoice_Internalname = "vCANCELINVOICE";
         edtInvoiceId_Internalname = "INVOICEID";
         edtInvoiceCreatedDate_Internalname = "INVOICECREATEDDATE";
         edtInvoiceTotalReceivable_Internalname = "INVOICETOTALRECEIVABLE";
         edtUserName_Internalname = "USERNAME";
         edtavDetails_Internalname = "vDETAILS";
         divTableinvoices_Internalname = "TABLEINVOICES";
         bttConfirmcancel_Internalname = "CONFIRMCANCEL";
         bttCancelcancel_Internalname = "CANCELCANCEL";
         edtavImpottotalcancel_Internalname = "vIMPOTTOTALCANCEL";
         edtavMovementdescription_Internalname = "vMOVEMENTDESCRIPTION";
         divTablebuttonscancel_Internalname = "TABLEBUTTONSCANCEL";
         edtavCtlcode_Internalname = "CTLCODE";
         edtavCtlname_Internalname = "CTLNAME";
         edtavCtlstock1_Internalname = "CTLSTOCK1";
         edtavCtlquantity_Internalname = "CTLQUANTITY";
         edtavCtlunitprice_Internalname = "CTLUNITPRICE";
         edtavCtlsubtotal_Internalname = "CTLSUBTOTAL";
         divTableinvoicedetailscancel_Internalname = "TABLEINVOICEDETAILSCANCEL";
         edtavCtlpaymentmethoddescription1_Internalname = "CTLPAYMENTMETHODDESCRIPTION1";
         edtavCtlinvoicepaymentmethodimport1_Internalname = "CTLINVOICEPAYMENTMETHODIMPORT1";
         edtavCtlinvoicepaymentmethoddiscountimport1_Internalname = "CTLINVOICEPAYMENTMETHODDISCOUNTIMPORT1";
         edtavCtlinvoicepaymentmethodrechargeimport1_Internalname = "CTLINVOICEPAYMENTMETHODRECHARGEIMPORT1";
         divTable1_Internalname = "TABLE1";
         divTablecancel_Internalname = "TABLECANCEL";
         bttConfirmedit_Internalname = "CONFIRMEDIT";
         bttCanceledit_Internalname = "CANCELEDIT";
         edtavImportreceivable_Internalname = "vIMPORTRECEIVABLE";
         edtavMovementdescription_edit_Internalname = "vMOVEMENTDESCRIPTION_EDIT";
         divTablebuttonsedit_Internalname = "TABLEBUTTONSEDIT";
         edtavCtlcode1_Internalname = "CTLCODE1";
         edtavCtlname1_Internalname = "CTLNAME1";
         edtavCtlstock_Internalname = "CTLSTOCK";
         edtavCtlquantity1_Internalname = "CTLQUANTITY1";
         edtavCtlunitprice1_Internalname = "CTLUNITPRICE1";
         edtavCtlsubtotal1_Internalname = "CTLSUBTOTAL1";
         edtavCtlproductminiumquantitywholesale_Internalname = "CTLPRODUCTMINIUMQUANTITYWHOLESALE";
         divTableinvoicedetailsedit_Internalname = "TABLEINVOICEDETAILSEDIT";
         edtavCtlpaymentmethoddescription_Internalname = "CTLPAYMENTMETHODDESCRIPTION";
         edtavCtlinvoicepaymentmethodimport_Internalname = "CTLINVOICEPAYMENTMETHODIMPORT";
         edtavCtlinvoicepaymentmethoddiscountimport_Internalname = "CTLINVOICEPAYMENTMETHODDISCOUNTIMPORT";
         edtavCtlinvoicepaymentmethodrechargeimport_Internalname = "CTLINVOICEPAYMENTMETHODRECHARGEIMPORT";
         divTablepaymentedit_Internalname = "TABLEPAYMENTEDIT";
         divTableedit_Internalname = "TABLEEDIT";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGridinvoice_Internalname = "GRIDINVOICE";
         subGrid1_Internalname = "GRID1";
         subGridpaymentcancel_Internalname = "GRIDPAYMENTCANCEL";
         subGridinvoicedetailsedit_Internalname = "GRIDINVOICEDETAILSEDIT";
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
         subGridinvoicedetailsedit_Allowcollapsing = 0;
         subGridinvoicedetailsedit_Allowselection = 0;
         subGridinvoicedetailsedit_Header = "";
         subGridpaymentcancel_Allowcollapsing = 0;
         subGridpaymentcancel_Allowselection = 0;
         subGridpaymentcancel_Header = "Payment Methods";
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         subGrid1_Header = "Details";
         subGridinvoice_Allowcollapsing = 0;
         subGridinvoice_Allowselection = 0;
         subGridinvoice_Header = "";
         edtavCtlinvoicepaymentmethodrechargeimport_Jsonclick = "";
         edtavCtlinvoicepaymentmethodrechargeimport_Visible = -1;
         edtavCtlinvoicepaymentmethodrechargeimport_Enabled = 1;
         edtavCtlinvoicepaymentmethoddiscountimport_Jsonclick = "";
         edtavCtlinvoicepaymentmethoddiscountimport_Visible = -1;
         edtavCtlinvoicepaymentmethoddiscountimport_Enabled = 1;
         edtavCtlinvoicepaymentmethodimport_Jsonclick = "";
         edtavCtlinvoicepaymentmethodimport_Visible = -1;
         edtavCtlinvoicepaymentmethodimport_Enabled = 1;
         edtavCtlpaymentmethoddescription_Jsonclick = "";
         edtavCtlpaymentmethoddescription_Enabled = 0;
         subGrid2_Class = "PromptGrid";
         subGrid2_Backcolorstyle = 0;
         edtavCtlproductminiumquantitywholesale_Jsonclick = "";
         edtavCtlproductminiumquantitywholesale_Enabled = 0;
         edtavCtlsubtotal1_Jsonclick = "";
         edtavCtlsubtotal1_Enabled = 0;
         edtavCtlunitprice1_Jsonclick = "";
         edtavCtlunitprice1_Visible = -1;
         edtavCtlunitprice1_Enabled = 1;
         edtavCtlquantity1_Jsonclick = "";
         edtavCtlquantity1_Visible = -1;
         edtavCtlquantity1_Enabled = 1;
         edtavCtlstock_Jsonclick = "";
         edtavCtlstock_Enabled = 0;
         edtavCtlname1_Jsonclick = "";
         edtavCtlname1_Enabled = 0;
         edtavCtlcode1_Jsonclick = "";
         edtavCtlcode1_Enabled = 0;
         subGridinvoicedetailsedit_Class = "PromptGrid";
         subGridinvoicedetailsedit_Backcolorstyle = 0;
         edtavCtlinvoicepaymentmethodrechargeimport1_Jsonclick = "";
         edtavCtlinvoicepaymentmethodrechargeimport1_Enabled = 0;
         edtavCtlinvoicepaymentmethoddiscountimport1_Jsonclick = "";
         edtavCtlinvoicepaymentmethoddiscountimport1_Enabled = 0;
         edtavCtlinvoicepaymentmethodimport1_Jsonclick = "";
         edtavCtlinvoicepaymentmethodimport1_Enabled = 0;
         edtavCtlpaymentmethoddescription1_Jsonclick = "";
         edtavCtlpaymentmethoddescription1_Enabled = 0;
         subGridpaymentcancel_Class = "PromptGrid";
         subGridpaymentcancel_Backcolorstyle = 0;
         edtavCtlsubtotal_Jsonclick = "";
         edtavCtlsubtotal_Enabled = 0;
         edtavCtlunitprice_Jsonclick = "";
         edtavCtlunitprice_Enabled = 0;
         edtavCtlquantity_Jsonclick = "";
         edtavCtlquantity_Enabled = 0;
         edtavCtlstock1_Jsonclick = "";
         edtavCtlstock1_Enabled = 0;
         edtavCtlname_Jsonclick = "";
         edtavCtlname_Enabled = 0;
         edtavCtlcode_Jsonclick = "";
         edtavCtlcode_Enabled = 0;
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
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
         edtavEditinvoice_Jsonclick = "";
         edtavEditinvoice_gximage = "";
         edtavEditinvoice_Visible = -1;
         edtavEditinvoice_Enabled = 1;
         subGridinvoice_Class = "PromptGrid";
         subGridinvoice_Backcolorstyle = 0;
         edtavCtlpaymentmethoddescription_Enabled = -1;
         edtavCtlproductminiumquantitywholesale_Enabled = -1;
         edtavCtlsubtotal1_Enabled = -1;
         edtavCtlstock_Enabled = -1;
         edtavCtlname1_Enabled = -1;
         edtavCtlcode1_Enabled = -1;
         edtavCtlinvoicepaymentmethodrechargeimport1_Enabled = -1;
         edtavCtlinvoicepaymentmethoddiscountimport1_Enabled = -1;
         edtavCtlinvoicepaymentmethodimport1_Enabled = -1;
         edtavCtlpaymentmethoddescription1_Enabled = -1;
         edtavCtlsubtotal_Enabled = -1;
         edtavCtlunitprice_Enabled = -1;
         edtavCtlquantity_Enabled = -1;
         edtavCtlstock1_Enabled = -1;
         edtavCtlname_Enabled = -1;
         edtavCtlcode_Enabled = -1;
         edtavMovementdescription_edit_Enabled = 1;
         edtavImportreceivable_Jsonclick = "";
         edtavImportreceivable_Enabled = 1;
         divTableedit_Visible = 1;
         edtavMovementdescription_Enabled = 1;
         edtavImpottotalcancel_Jsonclick = "";
         edtavImpottotalcancel_Enabled = 1;
         divTablecancel_Visible = 1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRIDINVOICE_nFirstRecordOnPage'},{av:'GRIDINVOICE_nEOF'},{av:'GRID2_nFirstRecordOnPage'},{av:'GRID2_nEOF'},{av:'AV38SDTInvoiceAddPaymentMethod_Edit',fld:'vSDTINVOICEADDPAYMENTMETHOD_EDIT',grid:123,pic:''},{av:'nGXsfl_123_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:123},{av:'nRC_GXsfl_123',ctrl:'GRID2',prop:'GridRC',grid:123},{av:'GRIDINVOICEDETAILSEDIT_nFirstRecordOnPage'},{av:'GRIDINVOICEDETAILSEDIT_nEOF'},{av:'AV16SDTCarProducts_Edit',fld:'vSDTCARPRODUCTS_EDIT',grid:108,pic:''},{av:'nGXsfl_108_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:108},{av:'nRC_GXsfl_108',ctrl:'GRIDINVOICEDETAILSEDIT',prop:'GridRC',grid:108},{av:'GRIDPAYMENTCANCEL_nFirstRecordOnPage'},{av:'GRIDPAYMENTCANCEL_nEOF'},{av:'AV39SDTInvoiceAddPaymentMethod_Cancel',fld:'vSDTINVOICEADDPAYMENTMETHOD_CANCEL',grid:76,pic:''},{av:'nGXsfl_76_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:76},{av:'nRC_GXsfl_76',ctrl:'GRIDPAYMENTCANCEL',prop:'GridRC',grid:76},{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'AV15SDTCarProducts_Cancel',fld:'vSDTCARPRODUCTS_CANCEL',grid:62,pic:''},{av:'nGXsfl_62_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:62},{av:'nRC_GXsfl_62',ctrl:'GRID1',prop:'GridRC',grid:62},{av:'subGridinvoice_Rows',ctrl:'GRIDINVOICE',prop:'Rows'},{av:'AV31FilterNro',fld:'vFILTERNRO',pic:'ZZZZZ9'},{av:'AV33FilterCreatedDateFrom',fld:'vFILTERCREATEDDATEFROM',pic:''},{av:'AV34FilterCreatedDateTo',fld:'vFILTERCREATEDDATETO',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("GRIDINVOICE.LOAD","{handler:'E224K2',iparms:[]");
         setEventMetadata("GRIDINVOICE.LOAD",",oparms:[{av:'AV26Details',fld:'vDETAILS',pic:''},{av:'AV28CancelInvoice',fld:'vCANCELINVOICE',pic:''},{av:'AV40EditInvoice',fld:'vEDITINVOICE',pic:''}]}");
         setEventMetadata("VDETAILS.CLICK","{handler:'E254K2',iparms:[{av:'A20InvoiceId',fld:'INVOICEID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("VDETAILS.CLICK",",oparms:[]}");
         setEventMetadata("VCANCELINVOICE.CLICK","{handler:'E234K2',iparms:[{av:'A20InvoiceId',fld:'INVOICEID',pic:'ZZZZZ9',hsh:true},{av:'AV30InvoiceId',fld:'vINVOICEID',pic:'ZZZZZ9'},{av:'A55ProductCode',fld:'PRODUCTCODE',pic:''},{av:'A15ProductId',fld:'PRODUCTID',pic:'ZZZZZ9'},{av:'A16ProductName',fld:'PRODUCTNAME',pic:''},{av:'A26InvoiceDetailQuantity',fld:'INVOICEDETAILQUANTITY',pic:'ZZZZZ9'},{av:'A65InvoiceDetailHistoricPrice',fld:'INVOICEDETAILHISTORICPRICE',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'A115PaymentMethodId',fld:'PAYMENTMETHODID',pic:'ZZZZZ9'},{av:'A116PaymentMethodDescription',fld:'PAYMENTMETHODDESCRIPTION',pic:''},{av:'A132InvoicePaymentMethodRechargeIm',fld:'INVOICEPAYMENTMETHODRECHARGEIM',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'A133InvoicePaymentMethodDiscountIm',fld:'INVOICEPAYMENTMETHODDISCOUNTIM',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'A120InvoicePaymentMethodImport',fld:'INVOICEPAYMENTMETHODIMPORT',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV38SDTInvoiceAddPaymentMethod_Edit',fld:'vSDTINVOICEADDPAYMENTMETHOD_EDIT',grid:123,pic:''},{av:'nGXsfl_123_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:123},{av:'GRID2_nFirstRecordOnPage'},{av:'nRC_GXsfl_123',ctrl:'GRID2',prop:'GridRC',grid:123},{av:'GRIDINVOICE_nFirstRecordOnPage'},{av:'GRIDINVOICE_nEOF'},{av:'GRID2_nEOF'},{av:'GRIDINVOICEDETAILSEDIT_nFirstRecordOnPage'},{av:'GRIDINVOICEDETAILSEDIT_nEOF'},{av:'AV16SDTCarProducts_Edit',fld:'vSDTCARPRODUCTS_EDIT',grid:108,pic:''},{av:'nGXsfl_108_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:108},{av:'nRC_GXsfl_108',ctrl:'GRIDINVOICEDETAILSEDIT',prop:'GridRC',grid:108},{av:'GRIDPAYMENTCANCEL_nFirstRecordOnPage'},{av:'GRIDPAYMENTCANCEL_nEOF'},{av:'AV39SDTInvoiceAddPaymentMethod_Cancel',fld:'vSDTINVOICEADDPAYMENTMETHOD_CANCEL',grid:76,pic:''},{av:'nGXsfl_76_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:76},{av:'nRC_GXsfl_76',ctrl:'GRIDPAYMENTCANCEL',prop:'GridRC',grid:76},{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'AV15SDTCarProducts_Cancel',fld:'vSDTCARPRODUCTS_CANCEL',grid:62,pic:''},{av:'nGXsfl_62_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:62},{av:'nRC_GXsfl_62',ctrl:'GRID1',prop:'GridRC',grid:62},{av:'subGridinvoice_Rows',ctrl:'GRIDINVOICE',prop:'Rows'},{av:'AV31FilterNro',fld:'vFILTERNRO',pic:'ZZZZZ9'},{av:'AV33FilterCreatedDateFrom',fld:'vFILTERCREATEDDATEFROM',pic:''},{av:'AV34FilterCreatedDateTo',fld:'vFILTERCREATEDDATETO',pic:''}]");
         setEventMetadata("VCANCELINVOICE.CLICK",",oparms:[{av:'divTablecancel_Visible',ctrl:'TABLECANCEL',prop:'Visible'},{av:'AV30InvoiceId',fld:'vINVOICEID',pic:'ZZZZZ9'},{av:'AV15SDTCarProducts_Cancel',fld:'vSDTCARPRODUCTS_CANCEL',grid:62,pic:''},{av:'nGXsfl_62_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:62},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_62',ctrl:'GRID1',prop:'GridRC',grid:62},{av:'AV39SDTInvoiceAddPaymentMethod_Cancel',fld:'vSDTINVOICEADDPAYMENTMETHOD_CANCEL',grid:76,pic:''},{av:'nGXsfl_76_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:76},{av:'GRIDPAYMENTCANCEL_nFirstRecordOnPage'},{av:'nRC_GXsfl_76',ctrl:'GRIDPAYMENTCANCEL',prop:'GridRC',grid:76},{av:'AV41ImpotTotalCancel',fld:'vIMPOTTOTALCANCEL',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'divTableedit_Visible',ctrl:'TABLEEDIT',prop:'Visible'},{av:'AV16SDTCarProducts_Edit',fld:'vSDTCARPRODUCTS_EDIT',grid:108,pic:''},{av:'nGXsfl_108_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:108},{av:'GRIDINVOICEDETAILSEDIT_nFirstRecordOnPage'},{av:'nRC_GXsfl_108',ctrl:'GRIDINVOICEDETAILSEDIT',prop:'GridRC',grid:108},{av:'AV19MovementDescription',fld:'vMOVEMENTDESCRIPTION',pic:''},{av:'AV38SDTInvoiceAddPaymentMethod_Edit',fld:'vSDTINVOICEADDPAYMENTMETHOD_EDIT',grid:123,pic:''},{av:'nGXsfl_123_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:123},{av:'GRID2_nFirstRecordOnPage'},{av:'nRC_GXsfl_123',ctrl:'GRID2',prop:'GridRC',grid:123},{av:'AV43ControlEdit',fld:'vCONTROLEDIT',pic:'ZZZ9'},{av:'AV20ControlCancel',fld:'vCONTROLCANCEL',pic:''}]}");
         setEventMetadata("VEDITINVOICE.CLICK","{handler:'E244K2',iparms:[{av:'A20InvoiceId',fld:'INVOICEID',pic:'ZZZZZ9',hsh:true},{av:'AV30InvoiceId',fld:'vINVOICEID',pic:'ZZZZZ9'},{av:'A55ProductCode',fld:'PRODUCTCODE',pic:''},{av:'A15ProductId',fld:'PRODUCTID',pic:'ZZZZZ9'},{av:'A16ProductName',fld:'PRODUCTNAME',pic:''},{av:'A26InvoiceDetailQuantity',fld:'INVOICEDETAILQUANTITY',pic:'ZZZZZ9'},{av:'A65InvoiceDetailHistoricPrice',fld:'INVOICEDETAILHISTORICPRICE',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'A115PaymentMethodId',fld:'PAYMENTMETHODID',pic:'ZZZZZ9'},{av:'A116PaymentMethodDescription',fld:'PAYMENTMETHODDESCRIPTION',pic:''},{av:'A132InvoicePaymentMethodRechargeIm',fld:'INVOICEPAYMENTMETHODRECHARGEIM',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'A133InvoicePaymentMethodDiscountIm',fld:'INVOICEPAYMENTMETHODDISCOUNTIM',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'A120InvoicePaymentMethodImport',fld:'INVOICEPAYMENTMETHODIMPORT',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV15SDTCarProducts_Cancel',fld:'vSDTCARPRODUCTS_CANCEL',grid:62,pic:''},{av:'nGXsfl_62_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:62},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_62',ctrl:'GRID1',prop:'GridRC',grid:62},{av:'GRIDINVOICE_nFirstRecordOnPage'},{av:'GRIDINVOICE_nEOF'},{av:'GRID2_nFirstRecordOnPage'},{av:'GRID2_nEOF'},{av:'AV38SDTInvoiceAddPaymentMethod_Edit',fld:'vSDTINVOICEADDPAYMENTMETHOD_EDIT',grid:123,pic:''},{av:'nGXsfl_123_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:123},{av:'nRC_GXsfl_123',ctrl:'GRID2',prop:'GridRC',grid:123},{av:'GRIDINVOICEDETAILSEDIT_nFirstRecordOnPage'},{av:'GRIDINVOICEDETAILSEDIT_nEOF'},{av:'AV16SDTCarProducts_Edit',fld:'vSDTCARPRODUCTS_EDIT',grid:108,pic:''},{av:'nGXsfl_108_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:108},{av:'nRC_GXsfl_108',ctrl:'GRIDINVOICEDETAILSEDIT',prop:'GridRC',grid:108},{av:'GRIDPAYMENTCANCEL_nFirstRecordOnPage'},{av:'GRIDPAYMENTCANCEL_nEOF'},{av:'AV39SDTInvoiceAddPaymentMethod_Cancel',fld:'vSDTINVOICEADDPAYMENTMETHOD_CANCEL',grid:76,pic:''},{av:'nGXsfl_76_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:76},{av:'nRC_GXsfl_76',ctrl:'GRIDPAYMENTCANCEL',prop:'GridRC',grid:76},{av:'GRID1_nEOF'},{av:'subGridinvoice_Rows',ctrl:'GRIDINVOICE',prop:'Rows'},{av:'AV31FilterNro',fld:'vFILTERNRO',pic:'ZZZZZ9'},{av:'AV33FilterCreatedDateFrom',fld:'vFILTERCREATEDDATEFROM',pic:''},{av:'AV34FilterCreatedDateTo',fld:'vFILTERCREATEDDATETO',pic:''}]");
         setEventMetadata("VEDITINVOICE.CLICK",",oparms:[{av:'divTableedit_Visible',ctrl:'TABLEEDIT',prop:'Visible'},{av:'AV30InvoiceId',fld:'vINVOICEID',pic:'ZZZZZ9'},{av:'AV16SDTCarProducts_Edit',fld:'vSDTCARPRODUCTS_EDIT',grid:108,pic:''},{av:'nGXsfl_108_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:108},{av:'GRIDINVOICEDETAILSEDIT_nFirstRecordOnPage'},{av:'nRC_GXsfl_108',ctrl:'GRIDINVOICEDETAILSEDIT',prop:'GridRC',grid:108},{av:'AV38SDTInvoiceAddPaymentMethod_Edit',fld:'vSDTINVOICEADDPAYMENTMETHOD_EDIT',grid:123,pic:''},{av:'nGXsfl_123_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:123},{av:'GRID2_nFirstRecordOnPage'},{av:'nRC_GXsfl_123',ctrl:'GRID2',prop:'GridRC',grid:123},{av:'AV35ImportReceivable',fld:'vIMPORTRECEIVABLE',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'divTablecancel_Visible',ctrl:'TABLECANCEL',prop:'Visible'},{av:'AV39SDTInvoiceAddPaymentMethod_Cancel',fld:'vSDTINVOICEADDPAYMENTMETHOD_CANCEL',grid:76,pic:''},{av:'nGXsfl_76_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:76},{av:'GRIDPAYMENTCANCEL_nFirstRecordOnPage'},{av:'nRC_GXsfl_76',ctrl:'GRIDPAYMENTCANCEL',prop:'GridRC',grid:76},{av:'AV19MovementDescription',fld:'vMOVEMENTDESCRIPTION',pic:''},{av:'AV43ControlEdit',fld:'vCONTROLEDIT',pic:'ZZZ9'},{av:'AV15SDTCarProducts_Cancel',fld:'vSDTCARPRODUCTS_CANCEL',grid:62,pic:''},{av:'nGXsfl_62_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:62},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_62',ctrl:'GRID1',prop:'GridRC',grid:62},{av:'AV20ControlCancel',fld:'vCONTROLCANCEL',pic:''}]}");
         setEventMetadata("'CANCEL'","{handler:'E124K2',iparms:[{av:'AV15SDTCarProducts_Cancel',fld:'vSDTCARPRODUCTS_CANCEL',grid:62,pic:''},{av:'nGXsfl_62_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:62},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_62',ctrl:'GRID1',prop:'GridRC',grid:62},{av:'GRIDINVOICE_nFirstRecordOnPage'},{av:'GRIDINVOICE_nEOF'},{av:'GRID2_nFirstRecordOnPage'},{av:'GRID2_nEOF'},{av:'AV38SDTInvoiceAddPaymentMethod_Edit',fld:'vSDTINVOICEADDPAYMENTMETHOD_EDIT',grid:123,pic:''},{av:'nGXsfl_123_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:123},{av:'nRC_GXsfl_123',ctrl:'GRID2',prop:'GridRC',grid:123},{av:'GRIDINVOICEDETAILSEDIT_nFirstRecordOnPage'},{av:'GRIDINVOICEDETAILSEDIT_nEOF'},{av:'AV16SDTCarProducts_Edit',fld:'vSDTCARPRODUCTS_EDIT',grid:108,pic:''},{av:'nGXsfl_108_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:108},{av:'nRC_GXsfl_108',ctrl:'GRIDINVOICEDETAILSEDIT',prop:'GridRC',grid:108},{av:'GRIDPAYMENTCANCEL_nFirstRecordOnPage'},{av:'GRIDPAYMENTCANCEL_nEOF'},{av:'AV39SDTInvoiceAddPaymentMethod_Cancel',fld:'vSDTINVOICEADDPAYMENTMETHOD_CANCEL',grid:76,pic:''},{av:'nGXsfl_76_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:76},{av:'nRC_GXsfl_76',ctrl:'GRIDPAYMENTCANCEL',prop:'GridRC',grid:76},{av:'GRID1_nEOF'},{av:'subGridinvoice_Rows',ctrl:'GRIDINVOICE',prop:'Rows'},{av:'AV31FilterNro',fld:'vFILTERNRO',pic:'ZZZZZ9'},{av:'AV33FilterCreatedDateFrom',fld:'vFILTERCREATEDDATEFROM',pic:''},{av:'AV34FilterCreatedDateTo',fld:'vFILTERCREATEDDATETO',pic:''}]");
         setEventMetadata("'CANCEL'",",oparms:[{av:'divTablecancel_Visible',ctrl:'TABLECANCEL',prop:'Visible'},{av:'divTableedit_Visible',ctrl:'TABLEEDIT',prop:'Visible'},{av:'AV39SDTInvoiceAddPaymentMethod_Cancel',fld:'vSDTINVOICEADDPAYMENTMETHOD_CANCEL',grid:76,pic:''},{av:'nGXsfl_76_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:76},{av:'GRIDPAYMENTCANCEL_nFirstRecordOnPage'},{av:'nRC_GXsfl_76',ctrl:'GRIDPAYMENTCANCEL',prop:'GridRC',grid:76},{av:'AV16SDTCarProducts_Edit',fld:'vSDTCARPRODUCTS_EDIT',grid:108,pic:''},{av:'nGXsfl_108_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:108},{av:'GRIDINVOICEDETAILSEDIT_nFirstRecordOnPage'},{av:'nRC_GXsfl_108',ctrl:'GRIDINVOICEDETAILSEDIT',prop:'GridRC',grid:108},{av:'AV19MovementDescription',fld:'vMOVEMENTDESCRIPTION',pic:''},{av:'AV38SDTInvoiceAddPaymentMethod_Edit',fld:'vSDTINVOICEADDPAYMENTMETHOD_EDIT',grid:123,pic:''},{av:'nGXsfl_123_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:123},{av:'GRID2_nFirstRecordOnPage'},{av:'nRC_GXsfl_123',ctrl:'GRID2',prop:'GridRC',grid:123},{av:'AV43ControlEdit',fld:'vCONTROLEDIT',pic:'ZZZ9'},{av:'AV15SDTCarProducts_Cancel',fld:'vSDTCARPRODUCTS_CANCEL',grid:62,pic:''},{av:'nGXsfl_62_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:62},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_62',ctrl:'GRID1',prop:'GridRC',grid:62},{av:'AV20ControlCancel',fld:'vCONTROLCANCEL',pic:''}]}");
         setEventMetadata("VFILTERNRO.CONTROLVALUECHANGED","{handler:'E134K2',iparms:[{av:'GRIDINVOICE_nFirstRecordOnPage'},{av:'GRIDINVOICE_nEOF'},{av:'subGridinvoice_Rows',ctrl:'GRIDINVOICE',prop:'Rows'},{av:'AV31FilterNro',fld:'vFILTERNRO',pic:'ZZZZZ9'},{av:'AV33FilterCreatedDateFrom',fld:'vFILTERCREATEDDATEFROM',pic:''},{av:'AV34FilterCreatedDateTo',fld:'vFILTERCREATEDDATETO',pic:''},{av:'GRID2_nFirstRecordOnPage'},{av:'GRID2_nEOF'},{av:'AV38SDTInvoiceAddPaymentMethod_Edit',fld:'vSDTINVOICEADDPAYMENTMETHOD_EDIT',grid:123,pic:''},{av:'nGXsfl_123_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:123},{av:'nRC_GXsfl_123',ctrl:'GRID2',prop:'GridRC',grid:123},{av:'GRIDINVOICEDETAILSEDIT_nFirstRecordOnPage'},{av:'GRIDINVOICEDETAILSEDIT_nEOF'},{av:'AV16SDTCarProducts_Edit',fld:'vSDTCARPRODUCTS_EDIT',grid:108,pic:''},{av:'nGXsfl_108_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:108},{av:'nRC_GXsfl_108',ctrl:'GRIDINVOICEDETAILSEDIT',prop:'GridRC',grid:108},{av:'GRIDPAYMENTCANCEL_nFirstRecordOnPage'},{av:'GRIDPAYMENTCANCEL_nEOF'},{av:'AV39SDTInvoiceAddPaymentMethod_Cancel',fld:'vSDTINVOICEADDPAYMENTMETHOD_CANCEL',grid:76,pic:''},{av:'nGXsfl_76_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:76},{av:'nRC_GXsfl_76',ctrl:'GRIDPAYMENTCANCEL',prop:'GridRC',grid:76},{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'AV15SDTCarProducts_Cancel',fld:'vSDTCARPRODUCTS_CANCEL',grid:62,pic:''},{av:'nGXsfl_62_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:62},{av:'nRC_GXsfl_62',ctrl:'GRID1',prop:'GridRC',grid:62}]");
         setEventMetadata("VFILTERNRO.CONTROLVALUECHANGED",",oparms:[]}");
         setEventMetadata("VFILTERCREATEDDATEFROM.CONTROLVALUECHANGED","{handler:'E144K2',iparms:[{av:'GRIDINVOICE_nFirstRecordOnPage'},{av:'GRIDINVOICE_nEOF'},{av:'subGridinvoice_Rows',ctrl:'GRIDINVOICE',prop:'Rows'},{av:'AV31FilterNro',fld:'vFILTERNRO',pic:'ZZZZZ9'},{av:'AV33FilterCreatedDateFrom',fld:'vFILTERCREATEDDATEFROM',pic:''},{av:'AV34FilterCreatedDateTo',fld:'vFILTERCREATEDDATETO',pic:''},{av:'GRID2_nFirstRecordOnPage'},{av:'GRID2_nEOF'},{av:'AV38SDTInvoiceAddPaymentMethod_Edit',fld:'vSDTINVOICEADDPAYMENTMETHOD_EDIT',grid:123,pic:''},{av:'nGXsfl_123_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:123},{av:'nRC_GXsfl_123',ctrl:'GRID2',prop:'GridRC',grid:123},{av:'GRIDINVOICEDETAILSEDIT_nFirstRecordOnPage'},{av:'GRIDINVOICEDETAILSEDIT_nEOF'},{av:'AV16SDTCarProducts_Edit',fld:'vSDTCARPRODUCTS_EDIT',grid:108,pic:''},{av:'nGXsfl_108_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:108},{av:'nRC_GXsfl_108',ctrl:'GRIDINVOICEDETAILSEDIT',prop:'GridRC',grid:108},{av:'GRIDPAYMENTCANCEL_nFirstRecordOnPage'},{av:'GRIDPAYMENTCANCEL_nEOF'},{av:'AV39SDTInvoiceAddPaymentMethod_Cancel',fld:'vSDTINVOICEADDPAYMENTMETHOD_CANCEL',grid:76,pic:''},{av:'nGXsfl_76_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:76},{av:'nRC_GXsfl_76',ctrl:'GRIDPAYMENTCANCEL',prop:'GridRC',grid:76},{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'AV15SDTCarProducts_Cancel',fld:'vSDTCARPRODUCTS_CANCEL',grid:62,pic:''},{av:'nGXsfl_62_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:62},{av:'nRC_GXsfl_62',ctrl:'GRID1',prop:'GridRC',grid:62}]");
         setEventMetadata("VFILTERCREATEDDATEFROM.CONTROLVALUECHANGED",",oparms:[]}");
         setEventMetadata("VFILTERCREATEDDATETO.CONTROLVALUECHANGED","{handler:'E154K2',iparms:[{av:'GRIDINVOICE_nFirstRecordOnPage'},{av:'GRIDINVOICE_nEOF'},{av:'subGridinvoice_Rows',ctrl:'GRIDINVOICE',prop:'Rows'},{av:'AV31FilterNro',fld:'vFILTERNRO',pic:'ZZZZZ9'},{av:'AV33FilterCreatedDateFrom',fld:'vFILTERCREATEDDATEFROM',pic:''},{av:'AV34FilterCreatedDateTo',fld:'vFILTERCREATEDDATETO',pic:''},{av:'GRID2_nFirstRecordOnPage'},{av:'GRID2_nEOF'},{av:'AV38SDTInvoiceAddPaymentMethod_Edit',fld:'vSDTINVOICEADDPAYMENTMETHOD_EDIT',grid:123,pic:''},{av:'nGXsfl_123_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:123},{av:'nRC_GXsfl_123',ctrl:'GRID2',prop:'GridRC',grid:123},{av:'GRIDINVOICEDETAILSEDIT_nFirstRecordOnPage'},{av:'GRIDINVOICEDETAILSEDIT_nEOF'},{av:'AV16SDTCarProducts_Edit',fld:'vSDTCARPRODUCTS_EDIT',grid:108,pic:''},{av:'nGXsfl_108_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:108},{av:'nRC_GXsfl_108',ctrl:'GRIDINVOICEDETAILSEDIT',prop:'GridRC',grid:108},{av:'GRIDPAYMENTCANCEL_nFirstRecordOnPage'},{av:'GRIDPAYMENTCANCEL_nEOF'},{av:'AV39SDTInvoiceAddPaymentMethod_Cancel',fld:'vSDTINVOICEADDPAYMENTMETHOD_CANCEL',grid:76,pic:''},{av:'nGXsfl_76_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:76},{av:'nRC_GXsfl_76',ctrl:'GRIDPAYMENTCANCEL',prop:'GridRC',grid:76},{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'AV15SDTCarProducts_Cancel',fld:'vSDTCARPRODUCTS_CANCEL',grid:62,pic:''},{av:'nGXsfl_62_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:62},{av:'nRC_GXsfl_62',ctrl:'GRID1',prop:'GridRC',grid:62}]");
         setEventMetadata("VFILTERCREATEDDATETO.CONTROLVALUECHANGED",",oparms:[]}");
         setEventMetadata("'CONFIRMCANCEL'","{handler:'E164K2',iparms:[{av:'AV20ControlCancel',fld:'vCONTROLCANCEL',pic:''},{av:'AV30InvoiceId',fld:'vINVOICEID',pic:'ZZZZZ9'},{av:'AV19MovementDescription',fld:'vMOVEMENTDESCRIPTION',pic:''},{av:'AV7ErrorMessage',fld:'vERRORMESSAGE',pic:''},{av:'AV15SDTCarProducts_Cancel',fld:'vSDTCARPRODUCTS_CANCEL',grid:62,pic:''},{av:'nGXsfl_62_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:62},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_62',ctrl:'GRID1',prop:'GridRC',grid:62},{av:'GRIDINVOICE_nFirstRecordOnPage'},{av:'GRIDINVOICE_nEOF'},{av:'GRID2_nFirstRecordOnPage'},{av:'GRID2_nEOF'},{av:'AV38SDTInvoiceAddPaymentMethod_Edit',fld:'vSDTINVOICEADDPAYMENTMETHOD_EDIT',grid:123,pic:''},{av:'nGXsfl_123_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:123},{av:'nRC_GXsfl_123',ctrl:'GRID2',prop:'GridRC',grid:123},{av:'GRIDINVOICEDETAILSEDIT_nFirstRecordOnPage'},{av:'GRIDINVOICEDETAILSEDIT_nEOF'},{av:'AV16SDTCarProducts_Edit',fld:'vSDTCARPRODUCTS_EDIT',grid:108,pic:''},{av:'nGXsfl_108_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:108},{av:'nRC_GXsfl_108',ctrl:'GRIDINVOICEDETAILSEDIT',prop:'GridRC',grid:108},{av:'GRIDPAYMENTCANCEL_nFirstRecordOnPage'},{av:'GRIDPAYMENTCANCEL_nEOF'},{av:'AV39SDTInvoiceAddPaymentMethod_Cancel',fld:'vSDTINVOICEADDPAYMENTMETHOD_CANCEL',grid:76,pic:''},{av:'nGXsfl_76_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:76},{av:'nRC_GXsfl_76',ctrl:'GRIDPAYMENTCANCEL',prop:'GridRC',grid:76},{av:'GRID1_nEOF'},{av:'subGridinvoice_Rows',ctrl:'GRIDINVOICE',prop:'Rows'},{av:'AV31FilterNro',fld:'vFILTERNRO',pic:'ZZZZZ9'},{av:'AV33FilterCreatedDateFrom',fld:'vFILTERCREATEDDATEFROM',pic:''},{av:'AV34FilterCreatedDateTo',fld:'vFILTERCREATEDDATETO',pic:''}]");
         setEventMetadata("'CONFIRMCANCEL'",",oparms:[{av:'AV7ErrorMessage',fld:'vERRORMESSAGE',pic:''},{av:'AV20ControlCancel',fld:'vCONTROLCANCEL',pic:''},{av:'divTablecancel_Visible',ctrl:'TABLECANCEL',prop:'Visible'},{av:'divTableedit_Visible',ctrl:'TABLEEDIT',prop:'Visible'},{av:'AV39SDTInvoiceAddPaymentMethod_Cancel',fld:'vSDTINVOICEADDPAYMENTMETHOD_CANCEL',grid:76,pic:''},{av:'nGXsfl_76_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:76},{av:'GRIDPAYMENTCANCEL_nFirstRecordOnPage'},{av:'nRC_GXsfl_76',ctrl:'GRIDPAYMENTCANCEL',prop:'GridRC',grid:76},{av:'AV16SDTCarProducts_Edit',fld:'vSDTCARPRODUCTS_EDIT',grid:108,pic:''},{av:'nGXsfl_108_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:108},{av:'GRIDINVOICEDETAILSEDIT_nFirstRecordOnPage'},{av:'nRC_GXsfl_108',ctrl:'GRIDINVOICEDETAILSEDIT',prop:'GridRC',grid:108},{av:'AV19MovementDescription',fld:'vMOVEMENTDESCRIPTION',pic:''},{av:'AV38SDTInvoiceAddPaymentMethod_Edit',fld:'vSDTINVOICEADDPAYMENTMETHOD_EDIT',grid:123,pic:''},{av:'nGXsfl_123_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:123},{av:'GRID2_nFirstRecordOnPage'},{av:'nRC_GXsfl_123',ctrl:'GRID2',prop:'GridRC',grid:123},{av:'AV43ControlEdit',fld:'vCONTROLEDIT',pic:'ZZZ9'},{av:'AV15SDTCarProducts_Cancel',fld:'vSDTCARPRODUCTS_CANCEL',grid:62,pic:''},{av:'nGXsfl_62_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:62},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_62',ctrl:'GRID1',prop:'GridRC',grid:62}]}");
         setEventMetadata("'CONFIRMEDIT'","{handler:'E114K1',iparms:[{av:'AV43ControlEdit',fld:'vCONTROLEDIT',pic:'ZZZ9'},{av:'AV19MovementDescription',fld:'vMOVEMENTDESCRIPTION',pic:''},{av:'AV16SDTCarProducts_Edit',fld:'vSDTCARPRODUCTS_EDIT',grid:108,pic:''},{av:'nGXsfl_108_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:108},{av:'GRIDINVOICEDETAILSEDIT_nFirstRecordOnPage'},{av:'nRC_GXsfl_108',ctrl:'GRIDINVOICEDETAILSEDIT',prop:'GridRC',grid:108}]");
         setEventMetadata("'CONFIRMEDIT'",",oparms:[{av:'AV43ControlEdit',fld:'vCONTROLEDIT',pic:'ZZZ9'}]}");
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
         setEventMetadata("VALIDV_IMPOTTOTALCANCEL","{handler:'Validv_Impottotalcancel',iparms:[]");
         setEventMetadata("VALIDV_IMPOTTOTALCANCEL",",oparms:[]}");
         setEventMetadata("VALIDV_IMPORTRECEIVABLE","{handler:'Validv_Importreceivable',iparms:[]");
         setEventMetadata("VALIDV_IMPORTRECEIVABLE",",oparms:[]}");
         setEventMetadata("VALID_INVOICEID","{handler:'Valid_Invoiceid',iparms:[]");
         setEventMetadata("VALID_INVOICEID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Details',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("VALIDV_GXV6","{handler:'Validv_Gxv6',iparms:[]");
         setEventMetadata("VALIDV_GXV6",",oparms:[]}");
         setEventMetadata("VALIDV_GXV7","{handler:'Validv_Gxv7',iparms:[]");
         setEventMetadata("VALIDV_GXV7",",oparms:[]}");
         setEventMetadata("VALIDV_GXV10","{handler:'Validv_Gxv10',iparms:[]");
         setEventMetadata("VALIDV_GXV10",",oparms:[]}");
         setEventMetadata("VALIDV_GXV11","{handler:'Validv_Gxv11',iparms:[]");
         setEventMetadata("VALIDV_GXV11",",oparms:[]}");
         setEventMetadata("VALIDV_GXV12","{handler:'Validv_Gxv12',iparms:[]");
         setEventMetadata("VALIDV_GXV12",",oparms:[]}");
         setEventMetadata("VALIDV_GXV18","{handler:'Validv_Gxv18',iparms:[]");
         setEventMetadata("VALIDV_GXV18",",oparms:[]}");
         setEventMetadata("VALIDV_GXV19","{handler:'Validv_Gxv19',iparms:[]");
         setEventMetadata("VALIDV_GXV19",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Gxv20',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("VALIDV_GXV23","{handler:'Validv_Gxv23',iparms:[]");
         setEventMetadata("VALIDV_GXV23",",oparms:[]}");
         setEventMetadata("VALIDV_GXV24","{handler:'Validv_Gxv24',iparms:[]");
         setEventMetadata("VALIDV_GXV24",",oparms:[]}");
         setEventMetadata("VALIDV_GXV25","{handler:'Validv_Gxv25',iparms:[]");
         setEventMetadata("VALIDV_GXV25",",oparms:[]}");
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
         AV15SDTCarProducts_Cancel = new GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem>( context, "SDTCarProductsItem", "mtaKB");
         AV39SDTInvoiceAddPaymentMethod_Cancel = new GXBaseCollection<SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem>( context, "SDTInvoiceAddPaymentMethodItem", "mtaKB");
         AV16SDTCarProducts_Edit = new GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem>( context, "SDTCarProductsItem", "mtaKB");
         AV38SDTInvoiceAddPaymentMethod_Edit = new GXBaseCollection<SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem>( context, "SDTInvoiceAddPaymentMethodItem", "mtaKB");
         A55ProductCode = "";
         A16ProductName = "";
         A116PaymentMethodDescription = "";
         AV7ErrorMessage = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         GridinvoiceContainer = new GXWebGrid( context);
         sStyleString = "";
         ClassString = "";
         StyleString = "";
         bttConfirmcancel_Jsonclick = "";
         bttCancelcancel_Jsonclick = "";
         AV19MovementDescription = "";
         Grid1Container = new GXWebGrid( context);
         GridpaymentcancelContainer = new GXWebGrid( context);
         bttConfirmedit_Jsonclick = "";
         bttCanceledit_Jsonclick = "";
         AV46MovementDescription_Edit = "";
         GridinvoicedetailseditContainer = new GXWebGrid( context);
         Grid2Container = new GXWebGrid( context);
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV40EditInvoice = "";
         AV75Editinvoice_GXI = "";
         AV28CancelInvoice = "";
         AV74Cancelinvoice_GXI = "";
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
         AV44SDTCarProducts = new GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem>( context, "SDTCarProductsItem", "mtaKB");
         AV45SDTInvoiceAddPaymentMethod = new GXBaseCollection<SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem>( context, "SDTInvoiceAddPaymentMethodItem", "mtaKB");
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
         H004K12_A118InvoicePaymentMethodId = new int[1] ;
         H004K12_A20InvoiceId = new int[1] ;
         H004K12_A115PaymentMethodId = new int[1] ;
         H004K12_n115PaymentMethodId = new bool[] {false} ;
         H004K12_A116PaymentMethodDescription = new string[] {""} ;
         H004K12_A132InvoicePaymentMethodRechargeIm = new decimal[1] ;
         H004K12_n132InvoicePaymentMethodRechargeIm = new bool[] {false} ;
         H004K12_A133InvoicePaymentMethodDiscountIm = new decimal[1] ;
         H004K12_n133InvoicePaymentMethodDiscountIm = new bool[] {false} ;
         H004K12_A120InvoicePaymentMethodImport = new decimal[1] ;
         H004K12_n120InvoicePaymentMethodImport = new bool[] {false} ;
         AV42SDTInvoiceAddPaymentMethodItem = new SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem(context);
         H004K13_A20InvoiceId = new int[1] ;
         H004K14_A25InvoiceDetailId = new int[1] ;
         H004K14_A20InvoiceId = new int[1] ;
         H004K14_A55ProductCode = new string[] {""} ;
         H004K14_n55ProductCode = new bool[] {false} ;
         H004K14_A15ProductId = new int[1] ;
         H004K14_A16ProductName = new string[] {""} ;
         H004K14_A26InvoiceDetailQuantity = new int[1] ;
         H004K14_A65InvoiceDetailHistoricPrice = new decimal[1] ;
         H004K15_A118InvoicePaymentMethodId = new int[1] ;
         H004K15_A20InvoiceId = new int[1] ;
         H004K15_A115PaymentMethodId = new int[1] ;
         H004K15_n115PaymentMethodId = new bool[] {false} ;
         H004K15_A116PaymentMethodDescription = new string[] {""} ;
         H004K15_A132InvoicePaymentMethodRechargeIm = new decimal[1] ;
         H004K15_n132InvoicePaymentMethodRechargeIm = new bool[] {false} ;
         H004K15_A133InvoicePaymentMethodDiscountIm = new decimal[1] ;
         H004K15_n133InvoicePaymentMethodDiscountIm = new bool[] {false} ;
         H004K15_A120InvoicePaymentMethodImport = new decimal[1] ;
         H004K15_n120InvoicePaymentMethodImport = new bool[] {false} ;
         AV9Invoice = new SdtInvoice(context);
         AV14InvoiceDetail = new SdtInvoice_Detail(context);
         AV11Product = new SdtProduct(context);
         AV13Movement = new SdtMovement(context);
         Grid2Row = new GXWebRow();
         GridinvoicedetailseditRow = new GXWebRow();
         GridpaymentcancelRow = new GXWebRow();
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGridinvoice_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         subGrid1_Linesclass = "";
         subGridpaymentcancel_Linesclass = "";
         subGridinvoicedetailsedit_Linesclass = "";
         subGrid2_Linesclass = "";
         GridinvoiceColumn = new GXWebColumn();
         Grid1Column = new GXWebColumn();
         GridpaymentcancelColumn = new GXWebColumn();
         GridinvoicedetailseditColumn = new GXWebColumn();
         Grid2Column = new GXWebColumn();
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
               , new Object[] {
               H004K12_A118InvoicePaymentMethodId, H004K12_A20InvoiceId, H004K12_A115PaymentMethodId, H004K12_n115PaymentMethodId, H004K12_A116PaymentMethodDescription, H004K12_A132InvoicePaymentMethodRechargeIm, H004K12_n132InvoicePaymentMethodRechargeIm, H004K12_A133InvoicePaymentMethodDiscountIm, H004K12_n133InvoicePaymentMethodDiscountIm, H004K12_A120InvoicePaymentMethodImport,
               H004K12_n120InvoicePaymentMethodImport
               }
               , new Object[] {
               H004K13_A20InvoiceId
               }
               , new Object[] {
               H004K14_A25InvoiceDetailId, H004K14_A20InvoiceId, H004K14_A55ProductCode, H004K14_n55ProductCode, H004K14_A15ProductId, H004K14_A16ProductName, H004K14_A26InvoiceDetailQuantity, H004K14_A65InvoiceDetailHistoricPrice
               }
               , new Object[] {
               H004K15_A118InvoicePaymentMethodId, H004K15_A20InvoiceId, H004K15_A115PaymentMethodId, H004K15_n115PaymentMethodId, H004K15_A116PaymentMethodDescription, H004K15_A132InvoicePaymentMethodRechargeIm, H004K15_n132InvoicePaymentMethodRechargeIm, H004K15_A133InvoicePaymentMethodDiscountIm, H004K15_n133InvoicePaymentMethodDiscountIm, H004K15_A120InvoicePaymentMethodImport,
               H004K15_n120InvoicePaymentMethodImport
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavDetails_Enabled = 0;
         edtavImpottotalcancel_Enabled = 0;
         edtavCtlcode_Enabled = 0;
         edtavCtlname_Enabled = 0;
         edtavCtlstock1_Enabled = 0;
         edtavCtlquantity_Enabled = 0;
         edtavCtlunitprice_Enabled = 0;
         edtavCtlsubtotal_Enabled = 0;
         edtavCtlpaymentmethoddescription1_Enabled = 0;
         edtavCtlinvoicepaymentmethodimport1_Enabled = 0;
         edtavCtlinvoicepaymentmethoddiscountimport1_Enabled = 0;
         edtavCtlinvoicepaymentmethodrechargeimport1_Enabled = 0;
         edtavCtlcode1_Enabled = 0;
         edtavCtlname1_Enabled = 0;
         edtavCtlstock_Enabled = 0;
         edtavCtlsubtotal1_Enabled = 0;
         edtavCtlproductminiumquantitywholesale_Enabled = 0;
         edtavCtlpaymentmethoddescription_Enabled = 0;
      }

      private short nRcdExists_12 ;
      private short nIsMod_12 ;
      private short nRcdExists_11 ;
      private short nIsMod_11 ;
      private short nRcdExists_10 ;
      private short nIsMod_10 ;
      private short nRcdExists_9 ;
      private short nIsMod_9 ;
      private short GRIDINVOICE_nEOF ;
      private short nRcdExists_6 ;
      private short nIsMod_6 ;
      private short nRcdExists_8 ;
      private short nIsMod_8 ;
      private short nRcdExists_7 ;
      private short nIsMod_7 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short AV43ControlEdit ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGridinvoice_Backcolorstyle ;
      private short subGrid2_Backcolorstyle ;
      private short subGridinvoicedetailsedit_Backcolorstyle ;
      private short subGridpaymentcancel_Backcolorstyle ;
      private short subGrid1_Backcolorstyle ;
      private short GRID2_nEOF ;
      private short GRIDINVOICEDETAILSEDIT_nEOF ;
      private short GRIDPAYMENTCANCEL_nEOF ;
      private short GRID1_nEOF ;
      private short nGXWrapped ;
      private short subGridinvoice_Backstyle ;
      private short subGrid1_Backstyle ;
      private short subGridpaymentcancel_Backstyle ;
      private short subGridinvoicedetailsedit_Backstyle ;
      private short subGrid2_Backstyle ;
      private short subGridinvoice_Titlebackstyle ;
      private short subGridinvoice_Allowselection ;
      private short subGridinvoice_Allowhovering ;
      private short subGridinvoice_Allowcollapsing ;
      private short subGridinvoice_Collapsed ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private short subGridpaymentcancel_Titlebackstyle ;
      private short subGridpaymentcancel_Allowselection ;
      private short subGridpaymentcancel_Allowhovering ;
      private short subGridpaymentcancel_Allowcollapsing ;
      private short subGridpaymentcancel_Collapsed ;
      private short subGridinvoicedetailsedit_Titlebackstyle ;
      private short subGridinvoicedetailsedit_Allowselection ;
      private short subGridinvoicedetailsedit_Allowhovering ;
      private short subGridinvoicedetailsedit_Allowcollapsing ;
      private short subGridinvoicedetailsedit_Collapsed ;
      private short subGrid2_Titlebackstyle ;
      private short subGrid2_Allowselection ;
      private short subGrid2_Allowhovering ;
      private short subGrid2_Allowcollapsing ;
      private short subGrid2_Collapsed ;
      private int nRC_GXsfl_25 ;
      private int nRC_GXsfl_62 ;
      private int nRC_GXsfl_76 ;
      private int nRC_GXsfl_108 ;
      private int nRC_GXsfl_123 ;
      private int subGridinvoice_Rows ;
      private int nGXsfl_25_idx=1 ;
      private int AV31FilterNro ;
      private int nGXsfl_62_idx=1 ;
      private int nGXsfl_76_idx=1 ;
      private int nGXsfl_108_idx=1 ;
      private int nGXsfl_123_idx=1 ;
      private int AV30InvoiceId ;
      private int A15ProductId ;
      private int A26InvoiceDetailQuantity ;
      private int A115PaymentMethodId ;
      private int edtavFilternro_Enabled ;
      private int edtavFiltercreateddatefrom_Enabled ;
      private int edtavFiltercreateddateto_Enabled ;
      private int divTablecancel_Visible ;
      private int edtavImpottotalcancel_Enabled ;
      private int edtavMovementdescription_Enabled ;
      private int AV49GXV1 ;
      private int AV56GXV8 ;
      private int divTableedit_Visible ;
      private int edtavImportreceivable_Enabled ;
      private int edtavMovementdescription_edit_Enabled ;
      private int AV61GXV13 ;
      private int AV69GXV21 ;
      private int A20InvoiceId ;
      private int subGridinvoice_Islastpage ;
      private int subGrid2_Islastpage ;
      private int subGridinvoicedetailsedit_Islastpage ;
      private int subGridpaymentcancel_Islastpage ;
      private int subGrid1_Islastpage ;
      private int edtavDetails_Enabled ;
      private int edtavCtlcode_Enabled ;
      private int edtavCtlname_Enabled ;
      private int edtavCtlstock1_Enabled ;
      private int edtavCtlquantity_Enabled ;
      private int edtavCtlunitprice_Enabled ;
      private int edtavCtlsubtotal_Enabled ;
      private int edtavCtlpaymentmethoddescription1_Enabled ;
      private int edtavCtlinvoicepaymentmethodimport1_Enabled ;
      private int edtavCtlinvoicepaymentmethoddiscountimport1_Enabled ;
      private int edtavCtlinvoicepaymentmethodrechargeimport1_Enabled ;
      private int edtavCtlcode1_Enabled ;
      private int edtavCtlname1_Enabled ;
      private int edtavCtlstock_Enabled ;
      private int edtavCtlsubtotal1_Enabled ;
      private int edtavCtlproductminiumquantitywholesale_Enabled ;
      private int edtavCtlpaymentmethoddescription_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A99UserId ;
      private int nGXsfl_62_fel_idx=1 ;
      private int nGXsfl_76_fel_idx=1 ;
      private int nGXsfl_108_fel_idx=1 ;
      private int nGXsfl_123_fel_idx=1 ;
      private int nGXsfl_62_bak_idx=1 ;
      private int nGXsfl_76_bak_idx=1 ;
      private int nGXsfl_108_bak_idx=1 ;
      private int nGXsfl_123_bak_idx=1 ;
      private int AV82GXV26 ;
      private int idxLst ;
      private int subGridinvoice_Backcolor ;
      private int subGridinvoice_Allbackcolor ;
      private int edtavEditinvoice_Enabled ;
      private int edtavEditinvoice_Visible ;
      private int edtavCancelinvoice_Enabled ;
      private int edtavCancelinvoice_Visible ;
      private int edtavDetails_Visible ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGridpaymentcancel_Backcolor ;
      private int subGridpaymentcancel_Allbackcolor ;
      private int subGridinvoicedetailsedit_Backcolor ;
      private int subGridinvoicedetailsedit_Allbackcolor ;
      private int edtavCtlquantity1_Enabled ;
      private int edtavCtlquantity1_Visible ;
      private int edtavCtlunitprice1_Enabled ;
      private int edtavCtlunitprice1_Visible ;
      private int subGrid2_Backcolor ;
      private int subGrid2_Allbackcolor ;
      private int edtavCtlinvoicepaymentmethodimport_Enabled ;
      private int edtavCtlinvoicepaymentmethodimport_Visible ;
      private int edtavCtlinvoicepaymentmethoddiscountimport_Enabled ;
      private int edtavCtlinvoicepaymentmethoddiscountimport_Visible ;
      private int edtavCtlinvoicepaymentmethodrechargeimport_Enabled ;
      private int edtavCtlinvoicepaymentmethodrechargeimport_Visible ;
      private int subGridinvoice_Titlebackcolor ;
      private int subGridinvoice_Selectedindex ;
      private int subGridinvoice_Selectioncolor ;
      private int subGridinvoice_Hoveringcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private int subGridpaymentcancel_Titlebackcolor ;
      private int subGridpaymentcancel_Selectedindex ;
      private int subGridpaymentcancel_Selectioncolor ;
      private int subGridpaymentcancel_Hoveringcolor ;
      private int subGridinvoicedetailsedit_Titlebackcolor ;
      private int subGridinvoicedetailsedit_Selectedindex ;
      private int subGridinvoicedetailsedit_Selectioncolor ;
      private int subGridinvoicedetailsedit_Hoveringcolor ;
      private int subGrid2_Titlebackcolor ;
      private int subGrid2_Selectedindex ;
      private int subGrid2_Selectioncolor ;
      private int subGrid2_Hoveringcolor ;
      private long GRIDINVOICE_nFirstRecordOnPage ;
      private long GRIDINVOICE_nCurrentRecord ;
      private long GRID1_nCurrentRecord ;
      private long GRIDPAYMENTCANCEL_nCurrentRecord ;
      private long GRIDINVOICEDETAILSEDIT_nCurrentRecord ;
      private long GRID2_nCurrentRecord ;
      private long GRIDINVOICE_nRecordCount ;
      private long GRID2_nFirstRecordOnPage ;
      private long GRIDINVOICEDETAILSEDIT_nFirstRecordOnPage ;
      private long GRIDPAYMENTCANCEL_nFirstRecordOnPage ;
      private long GRID1_nFirstRecordOnPage ;
      private decimal A65InvoiceDetailHistoricPrice ;
      private decimal A132InvoicePaymentMethodRechargeIm ;
      private decimal A133InvoicePaymentMethodDiscountIm ;
      private decimal A120InvoicePaymentMethodImport ;
      private decimal AV41ImpotTotalCancel ;
      private decimal AV35ImportReceivable ;
      private decimal A80InvoiceTotalReceivable ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_25_idx="0001" ;
      private string sGXsfl_62_idx="0001" ;
      private string sGXsfl_76_idx="0001" ;
      private string sGXsfl_108_idx="0001" ;
      private string sGXsfl_123_idx="0001" ;
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
      private string divTablecancel_Internalname ;
      private string divTablebuttonscancel_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string bttConfirmcancel_Internalname ;
      private string bttConfirmcancel_Jsonclick ;
      private string bttCancelcancel_Internalname ;
      private string bttCancelcancel_Jsonclick ;
      private string edtavImpottotalcancel_Internalname ;
      private string edtavImpottotalcancel_Jsonclick ;
      private string edtavMovementdescription_Internalname ;
      private string divTableinvoicedetailscancel_Internalname ;
      private string subGrid1_Internalname ;
      private string divTable1_Internalname ;
      private string subGridpaymentcancel_Internalname ;
      private string divTableedit_Internalname ;
      private string divTablebuttonsedit_Internalname ;
      private string bttConfirmedit_Internalname ;
      private string bttConfirmedit_Jsonclick ;
      private string bttCanceledit_Internalname ;
      private string bttCanceledit_Jsonclick ;
      private string edtavImportreceivable_Internalname ;
      private string edtavImportreceivable_Jsonclick ;
      private string edtavMovementdescription_edit_Internalname ;
      private string divTableinvoicedetailsedit_Internalname ;
      private string subGridinvoicedetailsedit_Internalname ;
      private string divTablepaymentedit_Internalname ;
      private string subGrid2_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavEditinvoice_Internalname ;
      private string edtavCancelinvoice_Internalname ;
      private string edtInvoiceId_Internalname ;
      private string edtInvoiceCreatedDate_Internalname ;
      private string edtInvoiceTotalReceivable_Internalname ;
      private string edtUserName_Internalname ;
      private string edtavDetails_Internalname ;
      private string edtavCtlcode_Internalname ;
      private string edtavCtlname_Internalname ;
      private string edtavCtlstock1_Internalname ;
      private string edtavCtlquantity_Internalname ;
      private string edtavCtlunitprice_Internalname ;
      private string edtavCtlsubtotal_Internalname ;
      private string edtavCtlpaymentmethoddescription1_Internalname ;
      private string edtavCtlinvoicepaymentmethodimport1_Internalname ;
      private string edtavCtlinvoicepaymentmethoddiscountimport1_Internalname ;
      private string edtavCtlinvoicepaymentmethodrechargeimport1_Internalname ;
      private string edtavCtlcode1_Internalname ;
      private string edtavCtlname1_Internalname ;
      private string edtavCtlstock_Internalname ;
      private string edtavCtlsubtotal1_Internalname ;
      private string edtavCtlproductminiumquantitywholesale_Internalname ;
      private string edtavCtlpaymentmethoddescription_Internalname ;
      private string scmdbuf ;
      private string sGXsfl_62_fel_idx="0001" ;
      private string sGXsfl_76_fel_idx="0001" ;
      private string sGXsfl_108_fel_idx="0001" ;
      private string sGXsfl_123_fel_idx="0001" ;
      private string edtavCancelinvoice_gximage ;
      private string edtavEditinvoice_gximage ;
      private string sGXsfl_25_fel_idx="0001" ;
      private string subGridinvoice_Class ;
      private string subGridinvoice_Linesclass ;
      private string sImgUrl ;
      private string edtavEditinvoice_Jsonclick ;
      private string edtavCancelinvoice_Jsonclick ;
      private string ROClassString ;
      private string edtInvoiceId_Jsonclick ;
      private string edtInvoiceCreatedDate_Jsonclick ;
      private string edtInvoiceTotalReceivable_Jsonclick ;
      private string edtUserName_Jsonclick ;
      private string edtavDetails_Jsonclick ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavCtlcode_Jsonclick ;
      private string edtavCtlname_Jsonclick ;
      private string edtavCtlstock1_Jsonclick ;
      private string edtavCtlquantity_Jsonclick ;
      private string edtavCtlunitprice_Jsonclick ;
      private string edtavCtlsubtotal_Jsonclick ;
      private string subGridpaymentcancel_Class ;
      private string subGridpaymentcancel_Linesclass ;
      private string edtavCtlpaymentmethoddescription1_Jsonclick ;
      private string edtavCtlinvoicepaymentmethodimport1_Jsonclick ;
      private string edtavCtlinvoicepaymentmethoddiscountimport1_Jsonclick ;
      private string edtavCtlinvoicepaymentmethodrechargeimport1_Jsonclick ;
      private string edtavCtlquantity1_Internalname ;
      private string edtavCtlunitprice1_Internalname ;
      private string subGridinvoicedetailsedit_Class ;
      private string subGridinvoicedetailsedit_Linesclass ;
      private string edtavCtlcode1_Jsonclick ;
      private string edtavCtlname1_Jsonclick ;
      private string edtavCtlstock_Jsonclick ;
      private string edtavCtlquantity1_Jsonclick ;
      private string edtavCtlunitprice1_Jsonclick ;
      private string edtavCtlsubtotal1_Jsonclick ;
      private string edtavCtlproductminiumquantitywholesale_Jsonclick ;
      private string edtavCtlinvoicepaymentmethodimport_Internalname ;
      private string edtavCtlinvoicepaymentmethoddiscountimport_Internalname ;
      private string edtavCtlinvoicepaymentmethodrechargeimport_Internalname ;
      private string subGrid2_Class ;
      private string subGrid2_Linesclass ;
      private string edtavCtlpaymentmethoddescription_Jsonclick ;
      private string edtavCtlinvoicepaymentmethodimport_Jsonclick ;
      private string edtavCtlinvoicepaymentmethoddiscountimport_Jsonclick ;
      private string edtavCtlinvoicepaymentmethodrechargeimport_Jsonclick ;
      private string subGridinvoice_Header ;
      private string subGrid1_Header ;
      private string subGridpaymentcancel_Header ;
      private string subGridinvoicedetailsedit_Header ;
      private string subGrid2_Header ;
      private DateTime AV33FilterCreatedDateFrom ;
      private DateTime AV34FilterCreatedDateTo ;
      private DateTime A38InvoiceCreatedDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV20ControlCancel ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_25_Refreshing=false ;
      private bool n80InvoiceTotalReceivable ;
      private bool bGXsfl_62_Refreshing=false ;
      private bool bGXsfl_76_Refreshing=false ;
      private bool bGXsfl_108_Refreshing=false ;
      private bool bGXsfl_123_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool A94InvoiceActive ;
      private bool returnInSub ;
      private bool gx_BV76 ;
      private bool gx_BV108 ;
      private bool AV6AllOk ;
      private bool gx_BV62 ;
      private bool n55ProductCode ;
      private bool n115PaymentMethodId ;
      private bool n132InvoicePaymentMethodRechargeIm ;
      private bool n133InvoicePaymentMethodDiscountIm ;
      private bool n120InvoicePaymentMethodImport ;
      private bool gx_BV123 ;
      private bool AV40EditInvoice_IsBlob ;
      private bool AV28CancelInvoice_IsBlob ;
      private string A55ProductCode ;
      private string A16ProductName ;
      private string A116PaymentMethodDescription ;
      private string AV7ErrorMessage ;
      private string AV19MovementDescription ;
      private string AV46MovementDescription_Edit ;
      private string AV75Editinvoice_GXI ;
      private string AV74Cancelinvoice_GXI ;
      private string A100UserName ;
      private string AV26Details ;
      private string AV40EditInvoice ;
      private string AV28CancelInvoice ;
      private GXWebGrid GridinvoiceContainer ;
      private GXWebGrid Grid1Container ;
      private GXWebGrid GridpaymentcancelContainer ;
      private GXWebGrid GridinvoicedetailseditContainer ;
      private GXWebGrid Grid2Container ;
      private GXWebRow GridinvoiceRow ;
      private GXWebRow Grid2Row ;
      private GXWebRow GridinvoicedetailseditRow ;
      private GXWebRow GridpaymentcancelRow ;
      private GXWebRow Grid1Row ;
      private GXWebColumn GridinvoiceColumn ;
      private GXWebColumn Grid1Column ;
      private GXWebColumn GridpaymentcancelColumn ;
      private GXWebColumn GridinvoicedetailseditColumn ;
      private GXWebColumn Grid2Column ;
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
      private int[] H004K12_A118InvoicePaymentMethodId ;
      private int[] H004K12_A20InvoiceId ;
      private int[] H004K12_A115PaymentMethodId ;
      private bool[] H004K12_n115PaymentMethodId ;
      private string[] H004K12_A116PaymentMethodDescription ;
      private decimal[] H004K12_A132InvoicePaymentMethodRechargeIm ;
      private bool[] H004K12_n132InvoicePaymentMethodRechargeIm ;
      private decimal[] H004K12_A133InvoicePaymentMethodDiscountIm ;
      private bool[] H004K12_n133InvoicePaymentMethodDiscountIm ;
      private decimal[] H004K12_A120InvoicePaymentMethodImport ;
      private bool[] H004K12_n120InvoicePaymentMethodImport ;
      private int[] H004K13_A20InvoiceId ;
      private int[] H004K14_A25InvoiceDetailId ;
      private int[] H004K14_A20InvoiceId ;
      private string[] H004K14_A55ProductCode ;
      private bool[] H004K14_n55ProductCode ;
      private int[] H004K14_A15ProductId ;
      private string[] H004K14_A16ProductName ;
      private int[] H004K14_A26InvoiceDetailQuantity ;
      private decimal[] H004K14_A65InvoiceDetailHistoricPrice ;
      private int[] H004K15_A118InvoicePaymentMethodId ;
      private int[] H004K15_A20InvoiceId ;
      private int[] H004K15_A115PaymentMethodId ;
      private bool[] H004K15_n115PaymentMethodId ;
      private string[] H004K15_A116PaymentMethodDescription ;
      private decimal[] H004K15_A132InvoicePaymentMethodRechargeIm ;
      private bool[] H004K15_n132InvoicePaymentMethodRechargeIm ;
      private decimal[] H004K15_A133InvoicePaymentMethodDiscountIm ;
      private bool[] H004K15_n133InvoicePaymentMethodDiscountIm ;
      private decimal[] H004K15_A120InvoicePaymentMethodImport ;
      private bool[] H004K15_n120InvoicePaymentMethodImport ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem> AV15SDTCarProducts_Cancel ;
      private GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem> AV16SDTCarProducts_Edit ;
      private GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem> AV44SDTCarProducts ;
      private GXBaseCollection<SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem> AV39SDTInvoiceAddPaymentMethod_Cancel ;
      private GXBaseCollection<SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem> AV38SDTInvoiceAddPaymentMethod_Edit ;
      private GXBaseCollection<SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem> AV45SDTInvoiceAddPaymentMethod ;
      private GXWebForm Form ;
      private SdtInvoice AV9Invoice ;
      private SdtInvoice_Detail AV14InvoiceDetail ;
      private SdtMovement AV13Movement ;
      private SdtProduct AV11Product ;
      private SdtSDTCarProducts_SDTCarProductsItem AV18SDTCarProductsItem ;
      private SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem AV42SDTInvoiceAddPaymentMethodItem ;
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
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
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
          Object[] prmH004K12;
          prmH004K12 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmH004K13;
          prmH004K13 = new Object[] {
          new ParDef("@AV30InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmH004K14;
          prmH004K14 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmH004K15;
          prmH004K15 = new Object[] {
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
             ,new CursorDef("H004K12", "SELECT T1.[InvoicePaymentMethodId], T1.[InvoiceId], T1.[PaymentMethodId], T2.[PaymentMethodDescription], T1.[InvoicePaymentMethodRechargeIm], T1.[InvoicePaymentMethodDiscountIm], T1.[InvoicePaymentMethodImport] FROM ([InvoicePaymentMethod] T1 LEFT JOIN [PaymentMethod] T2 ON T2.[PaymentMethodId] = T1.[PaymentMethodId]) WHERE T1.[InvoiceId] = @InvoiceId ORDER BY T1.[InvoiceId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004K12,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H004K13", "SELECT TOP 1 [InvoiceId] FROM [Invoice] WHERE [InvoiceId] = @AV30InvoiceId ORDER BY [InvoiceId]  OPTION (FAST 1)",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004K13,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H004K14", "SELECT T1.[InvoiceDetailId], T1.[InvoiceId], T2.[ProductCode], T1.[ProductId], T2.[ProductName], T1.[InvoiceDetailQuantity], T1.[InvoiceDetailHistoricPrice] FROM ([InvoiceDetail] T1 INNER JOIN [Product] T2 ON T2.[ProductId] = T1.[ProductId]) WHERE T1.[InvoiceId] = @InvoiceId ORDER BY T1.[InvoiceId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004K14,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H004K15", "SELECT T1.[InvoicePaymentMethodId], T1.[InvoiceId], T1.[PaymentMethodId], T2.[PaymentMethodDescription], T1.[InvoicePaymentMethodRechargeIm], T1.[InvoicePaymentMethodDiscountIm], T1.[InvoicePaymentMethodImport] FROM ([InvoicePaymentMethod] T1 LEFT JOIN [PaymentMethod] T2 ON T2.[PaymentMethodId] = T1.[PaymentMethodId]) WHERE T1.[InvoiceId] = @InvoiceId ORDER BY T1.[InvoiceId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004K15,100, GxCacheFrequency.OFF ,false,false )
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
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((int[]) buf[4])[0] = rslt.getInt(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                return;
       }
    }

 }

}
