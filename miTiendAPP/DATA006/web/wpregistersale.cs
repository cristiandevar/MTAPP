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
   public class wpregistersale : GXDataArea
   {
      public wpregistersale( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public wpregistersale( IGxContext context )
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
         dynavBrand = new GXCombobox();
         dynavSector = new GXCombobox();
         dynavPaymentmethodid = new GXCombobox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vBRAND") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvBRAND1T2( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vSECTOR") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvSECTOR1T2( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vPAYMENTMETHODID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvPAYMENTMETHODID1T2( ) ;
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Allproductsfiltered") == 0 )
            {
               gxnrAllproductsfiltered_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Allproductsfiltered") == 0 )
            {
               gxgrAllproductsfiltered_refresh_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Carproducts") == 0 )
            {
               gxnrCarproducts_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Carproducts") == 0 )
            {
               gxgrCarproducts_refresh_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridinvoiceaddpaymentmethod") == 0 )
            {
               gxnrGridinvoiceaddpaymentmethod_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridinvoiceaddpaymentmethod") == 0 )
            {
               gxgrGridinvoiceaddpaymentmethod_refresh_invoke( ) ;
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

      protected void gxnrAllproductsfiltered_newrow_invoke( )
      {
         nRC_GXsfl_35 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_35"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_35_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_35_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_35_idx = GetPar( "sGXsfl_35_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrAllproductsfiltered_newrow( ) ;
         /* End function gxnrAllproductsfiltered_newrow_invoke */
      }

      protected void gxgrAllproductsfiltered_refresh_invoke( )
      {
         subAllproductsfiltered_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subAllproductsfiltered_Rows"), "."), 18, MidpointRounding.ToEven));
         AV17Code = GetPar( "Code");
         AV18Name = GetPar( "Name");
         AV15Supplier = (int)(Math.Round(NumberUtil.Val( GetPar( "Supplier"), "."), 18, MidpointRounding.ToEven));
         dynavSector.FromJSonString( GetNextPar( ));
         AV45Sector = (int)(Math.Round(NumberUtil.Val( GetPar( "Sector"), "."), 18, MidpointRounding.ToEven));
         dynavBrand.FromJSonString( GetNextPar( ));
         AV16Brand = (int)(Math.Round(NumberUtil.Val( GetPar( "Brand"), "."), 18, MidpointRounding.ToEven));
         dynavPaymentmethodid.FromJSonString( GetNextPar( ));
         AV58PaymentMethodId = (int)(Math.Round(NumberUtil.Val( GetPar( "PaymentMethodId"), "."), 18, MidpointRounding.ToEven));
         AV38newName = GetPar( "newName");
         AV41newCode = GetPar( "newCode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrAllproductsfiltered_refresh( subAllproductsfiltered_Rows, AV17Code, AV18Name, AV15Supplier, AV45Sector, AV16Brand, AV58PaymentMethodId, AV38newName, AV41newCode) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrAllproductsfiltered_refresh_invoke */
      }

      protected void gxnrCarproducts_newrow_invoke( )
      {
         nRC_GXsfl_79 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_79"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_79_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_79_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_79_idx = GetPar( "sGXsfl_79_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrCarproducts_newrow( ) ;
         /* End function gxnrCarproducts_newrow_invoke */
      }

      protected void gxgrCarproducts_refresh_invoke( )
      {
         subAllproductsfiltered_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subAllproductsfiltered_Rows"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV24Car);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV56SDTInvoiceAddPaymentMethod);
         AV36Total = NumberUtil.Val( GetPar( "Total"), ".");
         dynavBrand.FromJSonString( GetNextPar( ));
         AV16Brand = (int)(Math.Round(NumberUtil.Val( GetPar( "Brand"), "."), 18, MidpointRounding.ToEven));
         dynavSector.FromJSonString( GetNextPar( ));
         AV45Sector = (int)(Math.Round(NumberUtil.Val( GetPar( "Sector"), "."), 18, MidpointRounding.ToEven));
         dynavPaymentmethodid.FromJSonString( GetNextPar( ));
         AV58PaymentMethodId = (int)(Math.Round(NumberUtil.Val( GetPar( "PaymentMethodId"), "."), 18, MidpointRounding.ToEven));
         AV38newName = GetPar( "newName");
         AV41newCode = GetPar( "newCode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrCarproducts_refresh( subAllproductsfiltered_Rows, AV24Car, AV56SDTInvoiceAddPaymentMethod, AV36Total, AV16Brand, AV45Sector, AV58PaymentMethodId, AV38newName, AV41newCode) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrCarproducts_refresh_invoke */
      }

      protected void gxnrGridinvoiceaddpaymentmethod_newrow_invoke( )
      {
         nRC_GXsfl_139 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_139"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_139_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_139_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_139_idx = GetPar( "sGXsfl_139_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridinvoiceaddpaymentmethod_newrow( ) ;
         /* End function gxnrGridinvoiceaddpaymentmethod_newrow_invoke */
      }

      protected void gxgrGridinvoiceaddpaymentmethod_refresh_invoke( )
      {
         subAllproductsfiltered_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subAllproductsfiltered_Rows"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV56SDTInvoiceAddPaymentMethod);
         AV36Total = NumberUtil.Val( GetPar( "Total"), ".");
         dynavBrand.FromJSonString( GetNextPar( ));
         AV16Brand = (int)(Math.Round(NumberUtil.Val( GetPar( "Brand"), "."), 18, MidpointRounding.ToEven));
         dynavSector.FromJSonString( GetNextPar( ));
         AV45Sector = (int)(Math.Round(NumberUtil.Val( GetPar( "Sector"), "."), 18, MidpointRounding.ToEven));
         dynavPaymentmethodid.FromJSonString( GetNextPar( ));
         AV58PaymentMethodId = (int)(Math.Round(NumberUtil.Val( GetPar( "PaymentMethodId"), "."), 18, MidpointRounding.ToEven));
         AV38newName = GetPar( "newName");
         AV41newCode = GetPar( "newCode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridinvoiceaddpaymentmethod_refresh( subAllproductsfiltered_Rows, AV56SDTInvoiceAddPaymentMethod, AV36Total, AV16Brand, AV45Sector, AV58PaymentMethodId, AV38newName, AV41newCode) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridinvoiceaddpaymentmethod_refresh_invoke */
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
         PA1T2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1T2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpregistersale.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vNEWNAME", AV38newName);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV38newName, "")), context));
         GxWebStd.gx_hidden_field( context, "vNEWCODE", AV41newCode);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV41newCode, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Car", AV24Car);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Car", AV24Car);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Sdtinvoiceaddpaymentmethod", AV56SDTInvoiceAddPaymentMethod);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Sdtinvoiceaddpaymentmethod", AV56SDTInvoiceAddPaymentMethod);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Sdtproductfiltered", AV49SDTProductFiltered);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Sdtproductfiltered", AV49SDTProductFiltered);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_35", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_35), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_79", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_79), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_139", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_139), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTPRODUCTFILTERED", AV49SDTProductFiltered);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTPRODUCTFILTERED", AV49SDTProductFiltered);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSELECTEDID", AV29SelectedId);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSELECTEDID", AV29SelectedId);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCARAUX", AV42CarAux);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCARAUX", AV42CarAux);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCAR", AV24Car);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCAR", AV24Car);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTINVOICEADDPAYMENTMETHOD", AV56SDTInvoiceAddPaymentMethod);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTINVOICEADDPAYMENTMETHOD", AV56SDTInvoiceAddPaymentMethod);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vALLOK", AV37AllOk);
         GxWebStd.gx_hidden_field( context, "vNEWNAME", AV38newName);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV38newName, "")), context));
         GxWebStd.gx_hidden_field( context, "vNEWCODE", AV41newCode);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV41newCode, "")), context));
         GxWebStd.gx_hidden_field( context, "vSUPPLIER", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15Supplier), 6, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vWASUSED", AV63WasUsed);
         GxWebStd.gx_hidden_field( context, "vPOSITION", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30Position), 6, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTINVOICEADDPAYMENTMETHODITEM", AV57SDTInvoiceAddPaymentMethodItem);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTINVOICEADDPAYMENTMETHODITEM", AV57SDTInvoiceAddPaymentMethodItem);
         }
         GxWebStd.gx_hidden_field( context, "ALLPRODUCTSFILTERED_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(ALLPRODUCTSFILTERED_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ALLPRODUCTSFILTERED_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(ALLPRODUCTSFILTERED_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ALLPRODUCTSFILTERED_Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAllproductsfiltered_Collapsed), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CARPRODUCTS_Class", StringUtil.RTrim( subCarproducts_Class));
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
            WE1T2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1T2( ) ;
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
         return formatLink("wpregistersale.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WPRegisterSale" ;
      }

      public override string GetPgmdesc( )
      {
         return "WPRegister Sale" ;
      }

      protected void WB1T0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "Middle", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Choose your Products and Register a Sale", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WPRegisterSale.htm");
            GxWebStd.gx_div_end( context, "Center", "Middle", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttSelectall_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(35), 2, 0)+","+"null"+");", "Select All", bttSelectall_Jsonclick, 5, "Select All", "", StyleString, ClassString, bttSelectall_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'SELECTALL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPRegisterSale.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavName_Internalname, "Name", "col-xs-12 attribute-filterLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'" + sGXsfl_35_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavName_Internalname, AV18Name, StringUtil.RTrim( context.localUtil.Format( AV18Name, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,18);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavName_Jsonclick, 0, "attribute-filter", "", "", "", "", 1, edtavName_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Name", "left", true, "", "HLP_WPRegisterSale.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavCode_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCode_Internalname, "Code", "col-xs-12 attribute-filterLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'" + sGXsfl_35_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCode_Internalname, AV17Code, StringUtil.RTrim( context.localUtil.Format( AV17Code, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCode_Jsonclick, 0, "attribute-filter", "", "", "", "", 1, edtavCode_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "GeneXusUnanimo\\Code", "left", true, "", "HLP_WPRegisterSale.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavBrand_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavBrand_Internalname, "Brand", "col-xs-12 attribute-filterLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_35_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavBrand, dynavBrand_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV16Brand), 6, 0)), 1, dynavBrand_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavBrand.Enabled, 0, 0, 0, "em", 0, "", "", "attribute-filter", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "", true, 0, "HLP_WPRegisterSale.htm");
            dynavBrand.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16Brand), 6, 0));
            AssignProp("", false, dynavBrand_Internalname, "Values", (string)(dynavBrand.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavSector_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavSector_Internalname, "Sector", "col-xs-12 attribute-filterLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'" + sGXsfl_35_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavSector, dynavSector_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV45Sector), 6, 0)), 1, dynavSector_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavSector.Enabled, 0, 0, 0, "em", 0, "", "", "attribute-filter", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "", true, 0, "HLP_WPRegisterSale.htm");
            dynavSector.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV45Sector), 6, 0));
            AssignProp("", false, dynavSector_Internalname, "Values", (string)(dynavSector.ToJavascriptSource()), true);
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
            AllproductsfilteredContainer.SetWrapped(nGXWrapped);
            StartGridControl35( ) ;
         }
         if ( wbEnd == 35 )
         {
            wbEnd = 0;
            nRC_GXsfl_35 = (int)(nGXsfl_35_idx-1);
            if ( AllproductsfilteredContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AllproductsfilteredContainer.AddObjectProperty("ALLPRODUCTSFILTERED_nEOF", ALLPRODUCTSFILTERED_nEOF);
               AllproductsfilteredContainer.AddObjectProperty("ALLPRODUCTSFILTERED_nFirstRecordOnPage", ALLPRODUCTSFILTERED_nFirstRecordOnPage);
               AV71GXV1 = nGXsfl_35_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"AllproductsfilteredContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Allproductsfiltered", AllproductsfilteredContainer, subAllproductsfiltered_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "AllproductsfilteredContainerData", AllproductsfilteredContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "AllproductsfilteredContainerData"+"V", AllproductsfilteredContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"AllproductsfilteredContainerData"+"V"+"\" value='"+AllproductsfilteredContainer.GridValuesHidden()+"'/>") ;
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
            GxWebStd.gx_div_start( context, divTablenewsale_Internalname, divTablenewsale_Visible, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttRegistersale_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(35), 2, 0)+","+"null"+");", "Register", bttRegistersale_Jsonclick, 5, "Register", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'REGISTERSALE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPRegisterSale.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavTotal_Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavTotal_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTotal_Internalname, "Total receivable", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'" + sGXsfl_35_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTotal_Internalname, StringUtil.LTrim( StringUtil.NToC( AV36Total, 18, 2, ".", "")), StringUtil.LTrim( ((edtavTotal_Enabled!=0) ? context.localUtil.Format( AV36Total, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV36Total, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,57);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTotal_Jsonclick, 0, "Attribute", "", "", "", "", edtavTotal_Visible, edtavTotal_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Price", "right", false, "", "HLP_WPRegisterSale.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttClearsale_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(35), 2, 0)+","+"null"+");", "Clear", bttClearsale_Jsonclick, 5, "Clear", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CLEARSALE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPRegisterSale.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Action", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPRegisterSale.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Name", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPRegisterSale.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Qty. to W. Price", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPRegisterSale.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Stock", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPRegisterSale.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Price", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPRegisterSale.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Quantity", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPRegisterSale.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Subtotal", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPRegisterSale.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            CarproductsContainer.SetIsFreestyle(true);
            CarproductsContainer.SetWrapped(nGXWrapped);
            StartGridControl79( ) ;
         }
         if ( wbEnd == 79 )
         {
            wbEnd = 0;
            nRC_GXsfl_79 = (int)(nGXsfl_79_idx-1);
            if ( CarproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV79GXV9 = nGXsfl_79_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"CarproductsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Carproducts", CarproductsContainer, subCarproducts_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "CarproductsContainerData", CarproductsContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "CarproductsContainerData"+"V", CarproductsContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"CarproductsContainerData"+"V"+"\" value='"+CarproductsContainer.GridValuesHidden()+"'/>") ;
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
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablepaymentmethod_Internalname, divTablepaymentmethod_Visible, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable3_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 115,'',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttAddpaymentmethod_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(35), 2, 0)+","+"null"+");", "Add Method", bttAddpaymentmethod_Jsonclick, 5, "Add Method", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'ADDPAYMENTMETHOD\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPRegisterSale.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavPaymentmethodid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavPaymentmethodid_Internalname, "Method", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'',false,'" + sGXsfl_35_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavPaymentmethodid, dynavPaymentmethodid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV58PaymentMethodId), 6, 0)), 1, dynavPaymentmethodid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavPaymentmethodid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,119);\"", "", true, 0, "HLP_WPRegisterSale.htm");
            dynavPaymentmethodid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV58PaymentMethodId), 6, 0));
            AssignProp("", false, dynavPaymentmethodid_Internalname, "Values", (string)(dynavPaymentmethodid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavInvoicepaymentmethodimport_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavInvoicepaymentmethodimport_Internalname, "Import", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 123,'',false,'" + sGXsfl_35_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavInvoicepaymentmethodimport_Internalname, StringUtil.LTrim( StringUtil.NToC( AV59InvoicePaymentMethodImport, 18, 2, ".", "")), StringUtil.LTrim( ((edtavInvoicepaymentmethodimport_Enabled!=0) ? context.localUtil.Format( AV59InvoicePaymentMethodImport, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV59InvoicePaymentMethodImport, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,123);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavInvoicepaymentmethodimport_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavInvoicepaymentmethodimport_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_WPRegisterSale.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavRemainingamount_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRemainingamount_Internalname, "Remaining Amount", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 127,'',false,'" + sGXsfl_35_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRemainingamount_Internalname, StringUtil.LTrim( StringUtil.NToC( AV55RemainingAmount, 18, 2, ".", "")), StringUtil.LTrim( ((edtavRemainingamount_Enabled!=0) ? context.localUtil.Format( AV55RemainingAmount, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV55RemainingAmount, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,127);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRemainingamount_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavRemainingamount_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Price", "right", false, "", "HLP_WPRegisterSale.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavAmountreceivable_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAmountreceivable_Internalname, "Amount Receivable", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 131,'',false,'" + sGXsfl_35_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAmountreceivable_Internalname, StringUtil.LTrim( StringUtil.NToC( AV64AmountReceivable, 18, 2, ".", "")), StringUtil.LTrim( ((edtavAmountreceivable_Enabled!=0) ? context.localUtil.Format( AV64AmountReceivable, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV64AmountReceivable, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,131);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAmountreceivable_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavAmountreceivable_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Price", "right", false, "", "HLP_WPRegisterSale.htm");
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
            GxWebStd.gx_div_start( context, divTable4_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridinvoiceaddpaymentmethodContainer.SetWrapped(nGXWrapped);
            StartGridControl139( ) ;
         }
         if ( wbEnd == 139 )
         {
            wbEnd = 0;
            nRC_GXsfl_139 = (int)(nGXsfl_139_idx-1);
            if ( GridinvoiceaddpaymentmethodContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV86GXV16 = nGXsfl_139_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridinvoiceaddpaymentmethodContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridinvoiceaddpaymentmethod", GridinvoiceaddpaymentmethodContainer, subGridinvoiceaddpaymentmethod_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridinvoiceaddpaymentmethodContainerData", GridinvoiceaddpaymentmethodContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridinvoiceaddpaymentmethodContainerData"+"V", GridinvoiceaddpaymentmethodContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridinvoiceaddpaymentmethodContainerData"+"V"+"\" value='"+GridinvoiceaddpaymentmethodContainer.GridValuesHidden()+"'/>") ;
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
         if ( wbEnd == 35 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( AllproductsfilteredContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AllproductsfilteredContainer.AddObjectProperty("ALLPRODUCTSFILTERED_nEOF", ALLPRODUCTSFILTERED_nEOF);
                  AllproductsfilteredContainer.AddObjectProperty("ALLPRODUCTSFILTERED_nFirstRecordOnPage", ALLPRODUCTSFILTERED_nFirstRecordOnPage);
                  AV71GXV1 = nGXsfl_35_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"AllproductsfilteredContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Allproductsfiltered", AllproductsfilteredContainer, subAllproductsfiltered_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "AllproductsfilteredContainerData", AllproductsfilteredContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "AllproductsfilteredContainerData"+"V", AllproductsfilteredContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"AllproductsfilteredContainerData"+"V"+"\" value='"+AllproductsfilteredContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         if ( wbEnd == 79 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( CarproductsContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV79GXV9 = nGXsfl_79_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"CarproductsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Carproducts", CarproductsContainer, subCarproducts_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "CarproductsContainerData", CarproductsContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "CarproductsContainerData"+"V", CarproductsContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"CarproductsContainerData"+"V"+"\" value='"+CarproductsContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         if ( wbEnd == 139 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridinvoiceaddpaymentmethodContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV86GXV16 = nGXsfl_139_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridinvoiceaddpaymentmethodContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridinvoiceaddpaymentmethod", GridinvoiceaddpaymentmethodContainer, subGridinvoiceaddpaymentmethod_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridinvoiceaddpaymentmethodContainerData", GridinvoiceaddpaymentmethodContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridinvoiceaddpaymentmethodContainerData"+"V", GridinvoiceaddpaymentmethodContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridinvoiceaddpaymentmethodContainerData"+"V"+"\" value='"+GridinvoiceaddpaymentmethodContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START1T2( )
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
            Form.Meta.addItem("description", "WPRegister Sale", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1T0( ) ;
      }

      protected void WS1T2( )
      {
         START1T2( ) ;
         EVT1T2( ) ;
      }

      protected void EVT1T2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "'REGISTERSALE'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RegisterSale' */
                              E111T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CLEARSALE'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'ClearSale' */
                              E121T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'SELECTALL'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'SelectAll' */
                              E131T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDPAYMENTMETHOD'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddPaymentMethod' */
                              E141T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ALLPRODUCTSFILTEREDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "ALLPRODUCTSFILTEREDPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 suballproductsfiltered_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 suballproductsfiltered_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 suballproductsfiltered_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 suballproductsfiltered_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 32), "CTLQUANTITY1.CONTROLVALUECHANGED") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "VREMOVE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "CARPRODUCTS.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 16), "CARPRODUCTS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "VREMOVE.CLICK") == 0 ) )
                           {
                              nGXsfl_79_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_79_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_79_idx), 4, 0), 4, "0");
                              SubsflControlProps_794( ) ;
                              AV79GXV9 = nGXsfl_79_idx;
                              if ( ( AV24Car.Count >= AV79GXV9 ) && ( AV79GXV9 > 0 ) )
                              {
                                 AV24Car.CurrentItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV24Car.Item(AV79GXV9));
                                 AV44Remove = cgiGet( edtavRemove_Internalname);
                                 AssignProp("", false, edtavRemove_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV44Remove)) ? AV93Remove_GXI : context.convertURL( context.PathToRelativeUrl( AV44Remove))), !bGXsfl_79_Refreshing);
                                 AssignProp("", false, edtavRemove_Internalname, "SrcSet", context.GetImageSrcSet( AV44Remove), true);
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "CTLQUANTITY1.CONTROLVALUECHANGED") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E151T2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VREMOVE.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E161T2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "CARPRODUCTS.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E171T2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "CARPRODUCTS.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E181T4 ();
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
                           else if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 35), "GRIDINVOICEADDPAYMENTMETHOD.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 26), "VPAYMENTMETHODREMOVE.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 49), "CTLINVOICEPAYMENTMETHODIMPORT.CONTROLVALUECHANGED") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 32), "GRIDINVOICEADDPAYMENTMETHOD.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 26), "VPAYMENTMETHODREMOVE.CLICK") == 0 ) )
                           {
                              nGXsfl_139_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_139_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_139_idx), 4, 0), 4, "0");
                              SubsflControlProps_1393( ) ;
                              AV86GXV16 = nGXsfl_139_idx;
                              if ( ( AV56SDTInvoiceAddPaymentMethod.Count >= AV86GXV16 ) && ( AV86GXV16 > 0 ) )
                              {
                                 AV56SDTInvoiceAddPaymentMethod.CurrentItem = ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV56SDTInvoiceAddPaymentMethod.Item(AV86GXV16));
                                 AV61PaymentMethodRemove = cgiGet( edtavPaymentmethodremove_Internalname);
                                 AssignProp("", false, edtavPaymentmethodremove_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV61PaymentMethodRemove)) ? AV96Paymentmethodremove_GXI : context.convertURL( context.PathToRelativeUrl( AV61PaymentMethodRemove))), !bGXsfl_139_Refreshing);
                                 AssignProp("", false, edtavPaymentmethodremove_Internalname, "SrcSet", context.GetImageSrcSet( AV61PaymentMethodRemove), true);
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "GRIDINVOICEADDPAYMENTMETHOD.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E191T2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VPAYMENTMETHODREMOVE.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E201T2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "CTLINVOICEPAYMENTMETHODIMPORT.CONTROLVALUECHANGED") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E211T2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDINVOICEADDPAYMENTMETHOD.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E221T3 ();
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
                           else if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "CTLNAME.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 27), "ALLPRODUCTSFILTERED.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 24), "ALLPRODUCTSFILTERED.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "CTLNAME.CLICK") == 0 ) )
                           {
                              nGXsfl_35_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
                              SubsflControlProps_352( ) ;
                              AV71GXV1 = (int)(nGXsfl_35_idx+ALLPRODUCTSFILTERED_nFirstRecordOnPage);
                              if ( ( AV49SDTProductFiltered.Count >= AV71GXV1 ) && ( AV71GXV1 > 0 ) )
                              {
                                 AV49SDTProductFiltered.CurrentItem = ((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV49SDTProductFiltered.Item(AV71GXV1));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "CTLNAME.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E231T2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E241T2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ALLPRODUCTSFILTERED.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E251T2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ALLPRODUCTSFILTERED.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E261T2 ();
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

      protected void WE1T2( )
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

      protected void PA1T2( )
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
               GX_FocusControl = edtavName_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVvBRAND1T2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvBRAND_data1T2( ) ;
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

      protected void GXVvBRAND_html1T2( )
      {
         int gxdynajaxvalue;
         GXDLVvBRAND_data1T2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavBrand.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavBrand.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 6, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvBRAND_data1T2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(None)");
         /* Using cursor H001T2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H001T2_A1BrandId[0]), 6, 0, ".", "")));
            gxdynajaxctrldescr.Add(H001T2_A2BrandName[0]);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void GXDLVvSECTOR1T2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvSECTOR_data1T2( ) ;
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

      protected void GXVvSECTOR_html1T2( )
      {
         int gxdynajaxvalue;
         GXDLVvSECTOR_data1T2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavSector.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavSector.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 6, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvSECTOR_data1T2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(None)");
         /* Using cursor H001T3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H001T3_A9SectorId[0]), 6, 0, ".", "")));
            gxdynajaxctrldescr.Add(H001T3_A10SectorName[0]);
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void GXDLVvPAYMENTMETHODID1T2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvPAYMENTMETHODID_data1T2( ) ;
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

      protected void GXVvPAYMENTMETHODID_html1T2( )
      {
         int gxdynajaxvalue;
         GXDLVvPAYMENTMETHODID_data1T2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavPaymentmethodid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavPaymentmethodid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 6, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvPAYMENTMETHODID_data1T2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(None)");
         /* Using cursor H001T4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H001T4_A115PaymentMethodId[0]), 6, 0, ".", "")));
            gxdynajaxctrldescr.Add(H001T4_A116PaymentMethodDescription[0]);
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void gxnrAllproductsfiltered_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_352( ) ;
         while ( nGXsfl_35_idx <= nRC_GXsfl_35 )
         {
            sendrow_352( ) ;
            nGXsfl_35_idx = ((subAllproductsfiltered_Islastpage==1)&&(nGXsfl_35_idx+1>subAllproductsfiltered_fnc_Recordsperpage( )) ? 1 : nGXsfl_35_idx+1);
            sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
            SubsflControlProps_352( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( AllproductsfilteredContainer)) ;
         /* End function gxnrAllproductsfiltered_newrow */
      }

      protected void gxnrGridinvoiceaddpaymentmethod_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1393( ) ;
         while ( nGXsfl_139_idx <= nRC_GXsfl_139 )
         {
            sendrow_1393( ) ;
            nGXsfl_139_idx = ((subGridinvoiceaddpaymentmethod_Islastpage==1)&&(nGXsfl_139_idx+1>subGridinvoiceaddpaymentmethod_fnc_Recordsperpage( )) ? 1 : nGXsfl_139_idx+1);
            sGXsfl_139_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_139_idx), 4, 0), 4, "0");
            SubsflControlProps_1393( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridinvoiceaddpaymentmethodContainer)) ;
         /* End function gxnrGridinvoiceaddpaymentmethod_newrow */
      }

      protected void gxnrCarproducts_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_794( ) ;
         while ( nGXsfl_79_idx <= nRC_GXsfl_79 )
         {
            sendrow_794( ) ;
            nGXsfl_79_idx = ((subCarproducts_Islastpage==1)&&(nGXsfl_79_idx+1>subCarproducts_fnc_Recordsperpage( )) ? 1 : nGXsfl_79_idx+1);
            sGXsfl_79_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_79_idx), 4, 0), 4, "0");
            SubsflControlProps_794( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( CarproductsContainer)) ;
         /* End function gxnrCarproducts_newrow */
      }

      protected void gxgrAllproductsfiltered_refresh( int subAllproductsfiltered_Rows ,
                                                      string AV17Code ,
                                                      string AV18Name ,
                                                      int AV15Supplier ,
                                                      int AV45Sector ,
                                                      int AV16Brand ,
                                                      int AV58PaymentMethodId ,
                                                      string AV38newName ,
                                                      string AV41newCode )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         ALLPRODUCTSFILTERED_nCurrentRecord = 0;
         RF1T2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrAllproductsfiltered_refresh */
      }

      protected void gxgrCarproducts_refresh( int subAllproductsfiltered_Rows ,
                                              GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem> AV24Car ,
                                              GXBaseCollection<SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem> AV56SDTInvoiceAddPaymentMethod ,
                                              decimal AV36Total ,
                                              int AV16Brand ,
                                              int AV45Sector ,
                                              int AV58PaymentMethodId ,
                                              string AV38newName ,
                                              string AV41newCode )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         CARPRODUCTS_nCurrentRecord = 0;
         RF1T4( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrCarproducts_refresh */
      }

      protected void gxgrGridinvoiceaddpaymentmethod_refresh( int subAllproductsfiltered_Rows ,
                                                              GXBaseCollection<SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem> AV56SDTInvoiceAddPaymentMethod ,
                                                              decimal AV36Total ,
                                                              int AV16Brand ,
                                                              int AV45Sector ,
                                                              int AV58PaymentMethodId ,
                                                              string AV38newName ,
                                                              string AV41newCode )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDINVOICEADDPAYMENTMETHOD_nCurrentRecord = 0;
         RF1T3( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridinvoiceaddpaymentmethod_refresh */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXVvBRAND_html1T2( ) ;
            GXVvSECTOR_html1T2( ) ;
            GXVvPAYMENTMETHODID_html1T2( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavBrand.ItemCount > 0 )
         {
            AV16Brand = (int)(Math.Round(NumberUtil.Val( dynavBrand.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV16Brand), 6, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV16Brand", StringUtil.LTrimStr( (decimal)(AV16Brand), 6, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavBrand.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16Brand), 6, 0));
            AssignProp("", false, dynavBrand_Internalname, "Values", dynavBrand.ToJavascriptSource(), true);
         }
         if ( dynavSector.ItemCount > 0 )
         {
            AV45Sector = (int)(Math.Round(NumberUtil.Val( dynavSector.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV45Sector), 6, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV45Sector", StringUtil.LTrimStr( (decimal)(AV45Sector), 6, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavSector.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV45Sector), 6, 0));
            AssignProp("", false, dynavSector_Internalname, "Values", dynavSector.ToJavascriptSource(), true);
         }
         if ( dynavPaymentmethodid.ItemCount > 0 )
         {
            AV58PaymentMethodId = (int)(Math.Round(NumberUtil.Val( dynavPaymentmethodid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV58PaymentMethodId), 6, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV58PaymentMethodId", StringUtil.LTrimStr( (decimal)(AV58PaymentMethodId), 6, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavPaymentmethodid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV58PaymentMethodId), 6, 0));
            AssignProp("", false, dynavPaymentmethodid_Internalname, "Values", dynavPaymentmethodid.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF1T2( ) ;
         RF1T4( ) ;
         RF1T3( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavCtlid_Enabled = 0;
         AssignProp("", false, edtavCtlid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlid_Enabled), 5, 0), !bGXsfl_35_Refreshing);
         edtavCtlcode_Enabled = 0;
         AssignProp("", false, edtavCtlcode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcode_Enabled), 5, 0), !bGXsfl_35_Refreshing);
         edtavCtlname_Enabled = 0;
         AssignProp("", false, edtavCtlname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname_Enabled), 5, 0), !bGXsfl_35_Refreshing);
         edtavCtlstock1_Enabled = 0;
         AssignProp("", false, edtavCtlstock1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlstock1_Enabled), 5, 0), !bGXsfl_35_Refreshing);
         edtavCtlretailprice_Enabled = 0;
         AssignProp("", false, edtavCtlretailprice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlretailprice_Enabled), 5, 0), !bGXsfl_35_Refreshing);
         edtavCtlwholesaleprice_Enabled = 0;
         AssignProp("", false, edtavCtlwholesaleprice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlwholesaleprice_Enabled), 5, 0), !bGXsfl_35_Refreshing);
         edtavCtlminiumquantitywholesale_Enabled = 0;
         AssignProp("", false, edtavCtlminiumquantitywholesale_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlminiumquantitywholesale_Enabled), 5, 0), !bGXsfl_35_Refreshing);
         edtavTotal_Enabled = 0;
         AssignProp("", false, edtavTotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTotal_Enabled), 5, 0), true);
         edtavCtlname1_Enabled = 0;
         AssignProp("", false, edtavCtlname1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname1_Enabled), 5, 0), !bGXsfl_79_Refreshing);
         edtavCtlproductminiumquantitywholesale_Enabled = 0;
         AssignProp("", false, edtavCtlproductminiumquantitywholesale_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlproductminiumquantitywholesale_Enabled), 5, 0), !bGXsfl_79_Refreshing);
         edtavCtlstock_Enabled = 0;
         AssignProp("", false, edtavCtlstock_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlstock_Enabled), 5, 0), !bGXsfl_79_Refreshing);
         edtavCtlunitprice1_Enabled = 0;
         AssignProp("", false, edtavCtlunitprice1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlunitprice1_Enabled), 5, 0), !bGXsfl_79_Refreshing);
         edtavCtlsubtotal_Enabled = 0;
         AssignProp("", false, edtavCtlsubtotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsubtotal_Enabled), 5, 0), !bGXsfl_79_Refreshing);
         edtavRemainingamount_Enabled = 0;
         AssignProp("", false, edtavRemainingamount_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRemainingamount_Enabled), 5, 0), true);
         edtavAmountreceivable_Enabled = 0;
         AssignProp("", false, edtavAmountreceivable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAmountreceivable_Enabled), 5, 0), true);
         edtavCtlpaymentmethodid_Enabled = 0;
         AssignProp("", false, edtavCtlpaymentmethodid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlpaymentmethodid_Enabled), 5, 0), !bGXsfl_139_Refreshing);
         edtavCtlpaymentmethoddescription_Enabled = 0;
         AssignProp("", false, edtavCtlpaymentmethoddescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlpaymentmethoddescription_Enabled), 5, 0), !bGXsfl_139_Refreshing);
         edtavCtlinvoicepaymentmethodimport_Enabled = 0;
         AssignProp("", false, edtavCtlinvoicepaymentmethodimport_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlinvoicepaymentmethodimport_Enabled), 5, 0), !bGXsfl_139_Refreshing);
         edtavCtlinvoicepaymentmethoddiscountimport_Enabled = 0;
         AssignProp("", false, edtavCtlinvoicepaymentmethoddiscountimport_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlinvoicepaymentmethoddiscountimport_Enabled), 5, 0), !bGXsfl_139_Refreshing);
         edtavCtlinvoicepaymentmethodrechargeimport_Enabled = 0;
         AssignProp("", false, edtavCtlinvoicepaymentmethodrechargeimport_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlinvoicepaymentmethodrechargeimport_Enabled), 5, 0), !bGXsfl_139_Refreshing);
      }

      protected void RF1T2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            AllproductsfilteredContainer.ClearRows();
         }
         wbStart = 35;
         E251T2 ();
         nGXsfl_35_idx = 1;
         sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
         SubsflControlProps_352( ) ;
         bGXsfl_35_Refreshing = true;
         AllproductsfilteredContainer.AddObjectProperty("GridName", "Allproductsfiltered");
         AllproductsfilteredContainer.AddObjectProperty("CmpContext", "");
         AllproductsfilteredContainer.AddObjectProperty("InMasterPage", "false");
         AllproductsfilteredContainer.AddObjectProperty("Class", "PromptGrid");
         AllproductsfilteredContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         AllproductsfilteredContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         AllproductsfilteredContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAllproductsfiltered_Backcolorstyle), 1, 0, ".", "")));
         AllproductsfilteredContainer.PageSize = subAllproductsfiltered_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_352( ) ;
            E261T2 ();
            if ( ( subAllproductsfiltered_Islastpage == 0 ) && ( ALLPRODUCTSFILTERED_nCurrentRecord > 0 ) && ( ALLPRODUCTSFILTERED_nGridOutOfScope == 0 ) && ( nGXsfl_35_idx == 1 ) )
            {
               ALLPRODUCTSFILTERED_nCurrentRecord = 0;
               ALLPRODUCTSFILTERED_nGridOutOfScope = 1;
               suballproductsfiltered_firstpage( ) ;
               E261T2 ();
            }
            wbEnd = 35;
            WB1T0( ) ;
         }
         bGXsfl_35_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes1T2( )
      {
         GxWebStd.gx_hidden_field( context, "vNEWNAME", AV38newName);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV38newName, "")), context));
         GxWebStd.gx_hidden_field( context, "vNEWCODE", AV41newCode);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV41newCode, "")), context));
      }

      protected void RF1T3( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridinvoiceaddpaymentmethodContainer.ClearRows();
         }
         wbStart = 139;
         E191T2 ();
         nGXsfl_139_idx = 1;
         sGXsfl_139_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_139_idx), 4, 0), 4, "0");
         SubsflControlProps_1393( ) ;
         bGXsfl_139_Refreshing = true;
         GridinvoiceaddpaymentmethodContainer.AddObjectProperty("GridName", "Gridinvoiceaddpaymentmethod");
         GridinvoiceaddpaymentmethodContainer.AddObjectProperty("CmpContext", "");
         GridinvoiceaddpaymentmethodContainer.AddObjectProperty("InMasterPage", "false");
         GridinvoiceaddpaymentmethodContainer.AddObjectProperty("Class", "PromptGrid");
         GridinvoiceaddpaymentmethodContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridinvoiceaddpaymentmethodContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridinvoiceaddpaymentmethodContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoiceaddpaymentmethod_Backcolorstyle), 1, 0, ".", "")));
         GridinvoiceaddpaymentmethodContainer.PageSize = subGridinvoiceaddpaymentmethod_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1393( ) ;
            E221T3 ();
            wbEnd = 139;
            WB1T0( ) ;
         }
         bGXsfl_139_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes1T3( )
      {
      }

      protected void RF1T4( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            CarproductsContainer.ClearRows();
         }
         wbStart = 79;
         E171T2 ();
         nGXsfl_79_idx = 1;
         sGXsfl_79_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_79_idx), 4, 0), 4, "0");
         SubsflControlProps_794( ) ;
         bGXsfl_79_Refreshing = true;
         CarproductsContainer.AddObjectProperty("GridName", "Carproducts");
         CarproductsContainer.AddObjectProperty("CmpContext", "");
         CarproductsContainer.AddObjectProperty("InMasterPage", "false");
         CarproductsContainer.AddObjectProperty("Class", StringUtil.RTrim( "PromptGrid"));
         CarproductsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         CarproductsContainer.AddObjectProperty("Class", "PromptGrid");
         CarproductsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         CarproductsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         CarproductsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subCarproducts_Backcolorstyle), 1, 0, ".", "")));
         CarproductsContainer.PageSize = subCarproducts_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_794( ) ;
            E181T4 ();
            wbEnd = 79;
            WB1T0( ) ;
         }
         bGXsfl_79_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes1T4( )
      {
      }

      protected int subAllproductsfiltered_fnc_Pagecount( )
      {
         ALLPRODUCTSFILTERED_nRecordCount = subAllproductsfiltered_fnc_Recordcount( );
         if ( ((int)((ALLPRODUCTSFILTERED_nRecordCount) % (subAllproductsfiltered_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(ALLPRODUCTSFILTERED_nRecordCount/ (decimal)(subAllproductsfiltered_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(ALLPRODUCTSFILTERED_nRecordCount/ (decimal)(subAllproductsfiltered_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subAllproductsfiltered_fnc_Recordcount( )
      {
         return AV49SDTProductFiltered.Count ;
      }

      protected int subAllproductsfiltered_fnc_Recordsperpage( )
      {
         return (int)(4*1) ;
      }

      protected int subAllproductsfiltered_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(ALLPRODUCTSFILTERED_nFirstRecordOnPage/ (decimal)(subAllproductsfiltered_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short suballproductsfiltered_firstpage( )
      {
         ALLPRODUCTSFILTERED_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "ALLPRODUCTSFILTERED_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(ALLPRODUCTSFILTERED_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrAllproductsfiltered_refresh( subAllproductsfiltered_Rows, AV17Code, AV18Name, AV15Supplier, AV45Sector, AV16Brand, AV58PaymentMethodId, AV38newName, AV41newCode) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short suballproductsfiltered_nextpage( )
      {
         ALLPRODUCTSFILTERED_nRecordCount = subAllproductsfiltered_fnc_Recordcount( );
         if ( ( ALLPRODUCTSFILTERED_nRecordCount >= subAllproductsfiltered_fnc_Recordsperpage( ) ) && ( ALLPRODUCTSFILTERED_nEOF == 0 ) )
         {
            ALLPRODUCTSFILTERED_nFirstRecordOnPage = (long)(ALLPRODUCTSFILTERED_nFirstRecordOnPage+subAllproductsfiltered_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "ALLPRODUCTSFILTERED_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(ALLPRODUCTSFILTERED_nFirstRecordOnPage), 15, 0, ".", "")));
         AllproductsfilteredContainer.AddObjectProperty("ALLPRODUCTSFILTERED_nFirstRecordOnPage", ALLPRODUCTSFILTERED_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrAllproductsfiltered_refresh( subAllproductsfiltered_Rows, AV17Code, AV18Name, AV15Supplier, AV45Sector, AV16Brand, AV58PaymentMethodId, AV38newName, AV41newCode) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((ALLPRODUCTSFILTERED_nEOF==0) ? 0 : 2)) ;
      }

      protected short suballproductsfiltered_previouspage( )
      {
         if ( ALLPRODUCTSFILTERED_nFirstRecordOnPage >= subAllproductsfiltered_fnc_Recordsperpage( ) )
         {
            ALLPRODUCTSFILTERED_nFirstRecordOnPage = (long)(ALLPRODUCTSFILTERED_nFirstRecordOnPage-subAllproductsfiltered_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "ALLPRODUCTSFILTERED_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(ALLPRODUCTSFILTERED_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrAllproductsfiltered_refresh( subAllproductsfiltered_Rows, AV17Code, AV18Name, AV15Supplier, AV45Sector, AV16Brand, AV58PaymentMethodId, AV38newName, AV41newCode) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short suballproductsfiltered_lastpage( )
      {
         ALLPRODUCTSFILTERED_nRecordCount = subAllproductsfiltered_fnc_Recordcount( );
         if ( ALLPRODUCTSFILTERED_nRecordCount > subAllproductsfiltered_fnc_Recordsperpage( ) )
         {
            if ( ((int)((ALLPRODUCTSFILTERED_nRecordCount) % (subAllproductsfiltered_fnc_Recordsperpage( )))) == 0 )
            {
               ALLPRODUCTSFILTERED_nFirstRecordOnPage = (long)(ALLPRODUCTSFILTERED_nRecordCount-subAllproductsfiltered_fnc_Recordsperpage( ));
            }
            else
            {
               ALLPRODUCTSFILTERED_nFirstRecordOnPage = (long)(ALLPRODUCTSFILTERED_nRecordCount-((int)((ALLPRODUCTSFILTERED_nRecordCount) % (subAllproductsfiltered_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            ALLPRODUCTSFILTERED_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "ALLPRODUCTSFILTERED_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(ALLPRODUCTSFILTERED_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrAllproductsfiltered_refresh( subAllproductsfiltered_Rows, AV17Code, AV18Name, AV15Supplier, AV45Sector, AV16Brand, AV58PaymentMethodId, AV38newName, AV41newCode) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int suballproductsfiltered_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            ALLPRODUCTSFILTERED_nFirstRecordOnPage = (long)(subAllproductsfiltered_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            ALLPRODUCTSFILTERED_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "ALLPRODUCTSFILTERED_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(ALLPRODUCTSFILTERED_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrAllproductsfiltered_refresh( subAllproductsfiltered_Rows, AV17Code, AV18Name, AV15Supplier, AV45Sector, AV16Brand, AV58PaymentMethodId, AV38newName, AV41newCode) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected int subGridinvoiceaddpaymentmethod_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGridinvoiceaddpaymentmethod_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGridinvoiceaddpaymentmethod_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGridinvoiceaddpaymentmethod_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected int subCarproducts_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subCarproducts_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subCarproducts_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subCarproducts_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavCtlid_Enabled = 0;
         AssignProp("", false, edtavCtlid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlid_Enabled), 5, 0), !bGXsfl_35_Refreshing);
         edtavCtlcode_Enabled = 0;
         AssignProp("", false, edtavCtlcode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcode_Enabled), 5, 0), !bGXsfl_35_Refreshing);
         edtavCtlname_Enabled = 0;
         AssignProp("", false, edtavCtlname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname_Enabled), 5, 0), !bGXsfl_35_Refreshing);
         edtavCtlstock1_Enabled = 0;
         AssignProp("", false, edtavCtlstock1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlstock1_Enabled), 5, 0), !bGXsfl_35_Refreshing);
         edtavCtlretailprice_Enabled = 0;
         AssignProp("", false, edtavCtlretailprice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlretailprice_Enabled), 5, 0), !bGXsfl_35_Refreshing);
         edtavCtlwholesaleprice_Enabled = 0;
         AssignProp("", false, edtavCtlwholesaleprice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlwholesaleprice_Enabled), 5, 0), !bGXsfl_35_Refreshing);
         edtavCtlminiumquantitywholesale_Enabled = 0;
         AssignProp("", false, edtavCtlminiumquantitywholesale_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlminiumquantitywholesale_Enabled), 5, 0), !bGXsfl_35_Refreshing);
         edtavTotal_Enabled = 0;
         AssignProp("", false, edtavTotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTotal_Enabled), 5, 0), true);
         edtavCtlname1_Enabled = 0;
         AssignProp("", false, edtavCtlname1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname1_Enabled), 5, 0), !bGXsfl_79_Refreshing);
         edtavCtlproductminiumquantitywholesale_Enabled = 0;
         AssignProp("", false, edtavCtlproductminiumquantitywholesale_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlproductminiumquantitywholesale_Enabled), 5, 0), !bGXsfl_79_Refreshing);
         edtavCtlstock_Enabled = 0;
         AssignProp("", false, edtavCtlstock_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlstock_Enabled), 5, 0), !bGXsfl_79_Refreshing);
         edtavCtlunitprice1_Enabled = 0;
         AssignProp("", false, edtavCtlunitprice1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlunitprice1_Enabled), 5, 0), !bGXsfl_79_Refreshing);
         edtavCtlsubtotal_Enabled = 0;
         AssignProp("", false, edtavCtlsubtotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsubtotal_Enabled), 5, 0), !bGXsfl_79_Refreshing);
         edtavRemainingamount_Enabled = 0;
         AssignProp("", false, edtavRemainingamount_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRemainingamount_Enabled), 5, 0), true);
         edtavAmountreceivable_Enabled = 0;
         AssignProp("", false, edtavAmountreceivable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAmountreceivable_Enabled), 5, 0), true);
         edtavCtlpaymentmethodid_Enabled = 0;
         AssignProp("", false, edtavCtlpaymentmethodid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlpaymentmethodid_Enabled), 5, 0), !bGXsfl_139_Refreshing);
         edtavCtlpaymentmethoddescription_Enabled = 0;
         AssignProp("", false, edtavCtlpaymentmethoddescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlpaymentmethoddescription_Enabled), 5, 0), !bGXsfl_139_Refreshing);
         edtavCtlinvoicepaymentmethodimport_Enabled = 0;
         AssignProp("", false, edtavCtlinvoicepaymentmethodimport_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlinvoicepaymentmethodimport_Enabled), 5, 0), !bGXsfl_139_Refreshing);
         edtavCtlinvoicepaymentmethoddiscountimport_Enabled = 0;
         AssignProp("", false, edtavCtlinvoicepaymentmethoddiscountimport_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlinvoicepaymentmethoddiscountimport_Enabled), 5, 0), !bGXsfl_139_Refreshing);
         edtavCtlinvoicepaymentmethodrechargeimport_Enabled = 0;
         AssignProp("", false, edtavCtlinvoicepaymentmethodrechargeimport_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlinvoicepaymentmethodrechargeimport_Enabled), 5, 0), !bGXsfl_139_Refreshing);
         GXVvBRAND_html1T2( ) ;
         GXVvSECTOR_html1T2( ) ;
         GXVvPAYMENTMETHODID_html1T2( ) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP1T0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E241T2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Car"), AV24Car);
            ajax_req_read_hidden_sdt(cgiGet( "Sdtinvoiceaddpaymentmethod"), AV56SDTInvoiceAddPaymentMethod);
            ajax_req_read_hidden_sdt(cgiGet( "Sdtproductfiltered"), AV49SDTProductFiltered);
            ajax_req_read_hidden_sdt(cgiGet( "vSDTPRODUCTFILTERED"), AV49SDTProductFiltered);
            /* Read saved values. */
            nRC_GXsfl_35 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_35"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_79 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_79"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_139 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_139"), ".", ","), 18, MidpointRounding.ToEven));
            ALLPRODUCTSFILTERED_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "ALLPRODUCTSFILTERED_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            ALLPRODUCTSFILTERED_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "ALLPRODUCTSFILTERED_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            subAllproductsfiltered_Collapsed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "ALLPRODUCTSFILTERED_Collapsed"), ".", ","), 18, MidpointRounding.ToEven));
            subCarproducts_Class = cgiGet( "CARPRODUCTS_Class");
            nRC_GXsfl_35 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_35"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_35_fel_idx = 0;
            while ( nGXsfl_35_fel_idx < nRC_GXsfl_35 )
            {
               nGXsfl_35_fel_idx = ((subAllproductsfiltered_Islastpage==1)&&(nGXsfl_35_fel_idx+1>subAllproductsfiltered_fnc_Recordsperpage( )) ? 1 : nGXsfl_35_fel_idx+1);
               sGXsfl_35_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_352( ) ;
               AV71GXV1 = (int)(nGXsfl_35_fel_idx+ALLPRODUCTSFILTERED_nFirstRecordOnPage);
               if ( ( AV49SDTProductFiltered.Count >= AV71GXV1 ) && ( AV71GXV1 > 0 ) )
               {
                  AV49SDTProductFiltered.CurrentItem = ((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV49SDTProductFiltered.Item(AV71GXV1));
               }
            }
            if ( nGXsfl_35_fel_idx == 0 )
            {
               nGXsfl_35_idx = 1;
               sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
               SubsflControlProps_352( ) ;
            }
            nGXsfl_35_fel_idx = 1;
            nRC_GXsfl_79 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_79"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_79_fel_idx = 0;
            while ( nGXsfl_79_fel_idx < nRC_GXsfl_79 )
            {
               nGXsfl_79_fel_idx = ((subCarproducts_Islastpage==1)&&(nGXsfl_79_fel_idx+1>subCarproducts_fnc_Recordsperpage( )) ? 1 : nGXsfl_79_fel_idx+1);
               sGXsfl_79_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_79_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_794( ) ;
               AV79GXV9 = nGXsfl_79_fel_idx;
               if ( ( AV24Car.Count >= AV79GXV9 ) && ( AV79GXV9 > 0 ) )
               {
                  AV24Car.CurrentItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV24Car.Item(AV79GXV9));
                  AV44Remove = cgiGet( edtavRemove_Internalname);
               }
            }
            if ( nGXsfl_79_fel_idx == 0 )
            {
               nGXsfl_79_idx = 1;
               sGXsfl_79_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_79_idx), 4, 0), 4, "0");
               SubsflControlProps_794( ) ;
            }
            nGXsfl_79_fel_idx = 1;
            nRC_GXsfl_139 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_139"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_139_fel_idx = 0;
            while ( nGXsfl_139_fel_idx < nRC_GXsfl_139 )
            {
               nGXsfl_139_fel_idx = ((subGridinvoiceaddpaymentmethod_Islastpage==1)&&(nGXsfl_139_fel_idx+1>subGridinvoiceaddpaymentmethod_fnc_Recordsperpage( )) ? 1 : nGXsfl_139_fel_idx+1);
               sGXsfl_139_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_139_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_1393( ) ;
               AV86GXV16 = nGXsfl_139_fel_idx;
               if ( ( AV56SDTInvoiceAddPaymentMethod.Count >= AV86GXV16 ) && ( AV86GXV16 > 0 ) )
               {
                  AV56SDTInvoiceAddPaymentMethod.CurrentItem = ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV56SDTInvoiceAddPaymentMethod.Item(AV86GXV16));
                  AV61PaymentMethodRemove = cgiGet( edtavPaymentmethodremove_Internalname);
               }
            }
            if ( nGXsfl_139_fel_idx == 0 )
            {
               nGXsfl_139_idx = 1;
               sGXsfl_139_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_139_idx), 4, 0), 4, "0");
               SubsflControlProps_1393( ) ;
            }
            nGXsfl_139_fel_idx = 1;
            /* Read variables values. */
            AV18Name = cgiGet( edtavName_Internalname);
            AssignAttri("", false, "AV18Name", AV18Name);
            AV17Code = cgiGet( edtavCode_Internalname);
            AssignAttri("", false, "AV17Code", AV17Code);
            dynavBrand.Name = dynavBrand_Internalname;
            dynavBrand.CurrentValue = cgiGet( dynavBrand_Internalname);
            AV16Brand = (int)(Math.Round(NumberUtil.Val( cgiGet( dynavBrand_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV16Brand", StringUtil.LTrimStr( (decimal)(AV16Brand), 6, 0));
            dynavSector.Name = dynavSector_Internalname;
            dynavSector.CurrentValue = cgiGet( dynavSector_Internalname);
            AV45Sector = (int)(Math.Round(NumberUtil.Val( cgiGet( dynavSector_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV45Sector", StringUtil.LTrimStr( (decimal)(AV45Sector), 6, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTotal_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTotal_Internalname), ".", ",") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTOTAL");
               GX_FocusControl = edtavTotal_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV36Total = 0;
               AssignAttri("", false, "AV36Total", StringUtil.LTrimStr( AV36Total, 18, 2));
            }
            else
            {
               AV36Total = context.localUtil.CToN( cgiGet( edtavTotal_Internalname), ".", ",");
               AssignAttri("", false, "AV36Total", StringUtil.LTrimStr( AV36Total, 18, 2));
            }
            dynavPaymentmethodid.Name = dynavPaymentmethodid_Internalname;
            dynavPaymentmethodid.CurrentValue = cgiGet( dynavPaymentmethodid_Internalname);
            AV58PaymentMethodId = (int)(Math.Round(NumberUtil.Val( cgiGet( dynavPaymentmethodid_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV58PaymentMethodId", StringUtil.LTrimStr( (decimal)(AV58PaymentMethodId), 6, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavInvoicepaymentmethodimport_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavInvoicepaymentmethodimport_Internalname), ".", ",") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vINVOICEPAYMENTMETHODIMPORT");
               GX_FocusControl = edtavInvoicepaymentmethodimport_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV59InvoicePaymentMethodImport = 0;
               AssignAttri("", false, "AV59InvoicePaymentMethodImport", StringUtil.LTrimStr( AV59InvoicePaymentMethodImport, 18, 2));
            }
            else
            {
               AV59InvoicePaymentMethodImport = context.localUtil.CToN( cgiGet( edtavInvoicepaymentmethodimport_Internalname), ".", ",");
               AssignAttri("", false, "AV59InvoicePaymentMethodImport", StringUtil.LTrimStr( AV59InvoicePaymentMethodImport, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavRemainingamount_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavRemainingamount_Internalname), ".", ",") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vREMAININGAMOUNT");
               GX_FocusControl = edtavRemainingamount_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV55RemainingAmount = 0;
               AssignAttri("", false, "AV55RemainingAmount", StringUtil.LTrimStr( AV55RemainingAmount, 18, 2));
            }
            else
            {
               AV55RemainingAmount = context.localUtil.CToN( cgiGet( edtavRemainingamount_Internalname), ".", ",");
               AssignAttri("", false, "AV55RemainingAmount", StringUtil.LTrimStr( AV55RemainingAmount, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavAmountreceivable_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavAmountreceivable_Internalname), ".", ",") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vAMOUNTRECEIVABLE");
               GX_FocusControl = edtavAmountreceivable_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV64AmountReceivable = 0;
               AssignAttri("", false, "AV64AmountReceivable", StringUtil.LTrimStr( AV64AmountReceivable, 18, 2));
            }
            else
            {
               AV64AmountReceivable = context.localUtil.CToN( cgiGet( edtavAmountreceivable_Internalname), ".", ",");
               AssignAttri("", false, "AV64AmountReceivable", StringUtil.LTrimStr( AV64AmountReceivable, 18, 2));
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

      protected void E231T2( )
      {
         AV79GXV9 = nGXsfl_79_idx;
         if ( ( AV79GXV9 > 0 ) && ( AV24Car.Count >= AV79GXV9 ) )
         {
            AV24Car.CurrentItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV24Car.Item(AV79GXV9));
         }
         AV71GXV1 = (int)(nGXsfl_35_idx+ALLPRODUCTSFILTERED_nFirstRecordOnPage);
         if ( ( AV71GXV1 > 0 ) && ( AV49SDTProductFiltered.Count >= AV71GXV1 ) )
         {
            AV49SDTProductFiltered.CurrentItem = ((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV49SDTProductFiltered.Item(AV71GXV1));
         }
         /* Ctlname_Click Routine */
         returnInSub = false;
         AV54ProductId = ((SdtSDTProductsFiltered_SDTProductsFilteredItem)(AV49SDTProductFiltered.CurrentItem)).gxTpr_Id;
         if ( AV29SelectedId.IndexOf(AV54ProductId) <= 0 )
         {
            AV29SelectedId.Clear();
            GXt_SdtSDTCarProducts_SDTCarProductsItem1 = AV26CarItem;
            new registersalechargeproduct(context ).execute(  AV54ProductId, out  GXt_SdtSDTCarProducts_SDTCarProductsItem1) ;
            AV26CarItem = GXt_SdtSDTCarProducts_SDTCarProductsItem1;
            AV42CarAux.Add((SdtSDTCarProducts_SDTCarProductsItem)(AV26CarItem.Clone()), 0);
            AV29SelectedId.Add(AV54ProductId, 0);
            AV26CarItem = new SdtSDTCarProducts_SDTCarProductsItem(context);
            AV92GXV22 = 1;
            while ( AV92GXV22 <= AV24Car.Count )
            {
               AV26CarItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV24Car.Item(AV92GXV22));
               AV42CarAux.Add(AV26CarItem, 0);
               AV29SelectedId.Add(AV26CarItem.gxTpr_Id, 0);
               AV92GXV22 = (int)(AV92GXV22+1);
            }
            AV24Car = (GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem>)(AV42CarAux.Clone());
            gx_BV79 = true;
            AV42CarAux.Clear();
         }
         if ( AV24Car.Count > 0 )
         {
            divTablenewsale_Visible = 1;
            AssignProp("", false, divTablenewsale_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablenewsale_Visible), 5, 0), true);
            divTablepaymentmethod_Visible = 1;
            AssignProp("", false, divTablepaymentmethod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablepaymentmethod_Visible), 5, 0), true);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV29SelectedId", AV29SelectedId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV42CarAux", AV42CarAux);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24Car", AV24Car);
         nGXsfl_79_bak_idx = nGXsfl_79_idx;
         gxgrCarproducts_refresh( subAllproductsfiltered_Rows, AV24Car, AV56SDTInvoiceAddPaymentMethod, AV36Total, AV16Brand, AV45Sector, AV58PaymentMethodId, AV38newName, AV41newCode) ;
         nGXsfl_79_idx = nGXsfl_79_bak_idx;
         sGXsfl_79_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_79_idx), 4, 0), 4, "0");
         SubsflControlProps_794( ) ;
      }

      protected void E111T2( )
      {
         AV86GXV16 = nGXsfl_139_idx;
         if ( ( AV86GXV16 > 0 ) && ( AV56SDTInvoiceAddPaymentMethod.Count >= AV86GXV16 ) )
         {
            AV56SDTInvoiceAddPaymentMethod.CurrentItem = ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV56SDTInvoiceAddPaymentMethod.Item(AV86GXV16));
         }
         AV79GXV9 = nGXsfl_79_idx;
         if ( ( AV79GXV9 > 0 ) && ( AV24Car.Count >= AV79GXV9 ) )
         {
            AV24Car.CurrentItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV24Car.Item(AV79GXV9));
         }
         /* 'RegisterSale' Routine */
         returnInSub = false;
         AV37AllOk = true;
         AssignAttri("", false, "AV37AllOk", AV37AllOk);
         /* Execute user subroutine: 'CONTROL' */
         S112 ();
         if (returnInSub) return;
         if ( AV37AllOk )
         {
            new registersale(context ).execute(  AV24Car,  AV56SDTInvoiceAddPaymentMethod, out  AV46InvoiceId, out  AV37AllOk) ;
            AssignAttri("", false, "AV37AllOk", AV37AllOk);
            if ( AV37AllOk )
            {
               GX_msglist.addItem("Sale Registered Succesffully");
               AV36Total = 0;
               AssignAttri("", false, "AV36Total", StringUtil.LTrimStr( AV36Total, 18, 2));
               AV24Car.Clear();
               gx_BV79 = true;
               AV29SelectedId.Clear();
               gxgrAllproductsfiltered_refresh( subAllproductsfiltered_Rows, AV17Code, AV18Name, AV15Supplier, AV45Sector, AV16Brand, AV58PaymentMethodId, AV38newName, AV41newCode) ;
               divTablenewsale_Visible = 0;
               AssignProp("", false, divTablenewsale_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablenewsale_Visible), 5, 0), true);
               divTablepaymentmethod_Visible = 0;
               AssignProp("", false, divTablepaymentmethod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablepaymentmethod_Visible), 5, 0), true);
               /* Execute user subroutine: 'CLEARPAYMENTMETHOD' */
               S122 ();
               if (returnInSub) return;
               /* Window Datatype Object Property */
               AV43window.Url = formatLink("ainvoiceregister.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV46InvoiceId,6,0)),UrlEncode(StringUtil.BoolToStr(AV37AllOk))}, new string[] {"InvoiceId","AllOk"}) ;
               AV43window.SetReturnParms(new Object[] {"AV37AllOk",});
               AV43window.Height = 500;
               AV43window.Width = 500;
               context.NewWindow(AV43window);
            }
            else
            {
               GX_msglist.addItem("Sale Register Failed");
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24Car", AV24Car);
         nGXsfl_79_bak_idx = nGXsfl_79_idx;
         gxgrCarproducts_refresh( subAllproductsfiltered_Rows, AV24Car, AV56SDTInvoiceAddPaymentMethod, AV36Total, AV16Brand, AV45Sector, AV58PaymentMethodId, AV38newName, AV41newCode) ;
         nGXsfl_79_idx = nGXsfl_79_bak_idx;
         sGXsfl_79_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_79_idx), 4, 0), 4, "0");
         SubsflControlProps_794( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV29SelectedId", AV29SelectedId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV56SDTInvoiceAddPaymentMethod", AV56SDTInvoiceAddPaymentMethod);
         nGXsfl_139_bak_idx = nGXsfl_139_idx;
         gxgrGridinvoiceaddpaymentmethod_refresh( subAllproductsfiltered_Rows, AV56SDTInvoiceAddPaymentMethod, AV36Total, AV16Brand, AV45Sector, AV58PaymentMethodId, AV38newName, AV41newCode) ;
         nGXsfl_139_idx = nGXsfl_139_bak_idx;
         sGXsfl_139_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_139_idx), 4, 0), 4, "0");
         SubsflControlProps_1393( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV57SDTInvoiceAddPaymentMethodItem", AV57SDTInvoiceAddPaymentMethodItem);
         dynavPaymentmethodid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV58PaymentMethodId), 6, 0));
         AssignProp("", false, dynavPaymentmethodid_Internalname, "Values", dynavPaymentmethodid.ToJavascriptSource(), true);
      }

      protected void E151T2( )
      {
         AV86GXV16 = nGXsfl_139_idx;
         if ( ( AV86GXV16 > 0 ) && ( AV56SDTInvoiceAddPaymentMethod.Count >= AV86GXV16 ) )
         {
            AV56SDTInvoiceAddPaymentMethod.CurrentItem = ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV56SDTInvoiceAddPaymentMethod.Item(AV86GXV16));
         }
         AV79GXV9 = nGXsfl_79_idx;
         if ( ( AV79GXV9 > 0 ) && ( AV24Car.Count >= AV79GXV9 ) )
         {
            AV24Car.CurrentItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV24Car.Item(AV79GXV9));
         }
         /* Ctlquantity1_Controlvaluechanged Routine */
         returnInSub = false;
         AV26CarItem = ((SdtSDTCarProducts_SDTCarProductsItem)(AV24Car.CurrentItem));
         if ( AV26CarItem.gxTpr_Quantity > AV26CarItem.gxTpr_Stock )
         {
            GX_msglist.addItem("there is not enough stock");
            AV26CarItem.gxTpr_Quantity = AV26CarItem.gxTpr_Stock;
         }
         if ( ( AV26CarItem.gxTpr_Quantity >= AV26CarItem.gxTpr_Productminiumquantitywholesale ) && ( AV26CarItem.gxTpr_Productminiumquantitywholesale != 0 ) )
         {
            AV26CarItem.gxTpr_Unitprice = AV26CarItem.gxTpr_Wholesaleprice;
         }
         else
         {
            AV26CarItem.gxTpr_Unitprice = AV26CarItem.gxTpr_Retailprice;
         }
         AV26CarItem.gxTpr_Subtotal = (decimal)(AV26CarItem.gxTpr_Unitprice*AV26CarItem.gxTpr_Quantity);
         /* Execute user subroutine: 'CALCULATETOTAL' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'CLEARPAYMENTMETHOD' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24Car", AV24Car);
         nGXsfl_79_bak_idx = nGXsfl_79_idx;
         gxgrCarproducts_refresh( subAllproductsfiltered_Rows, AV24Car, AV56SDTInvoiceAddPaymentMethod, AV36Total, AV16Brand, AV45Sector, AV58PaymentMethodId, AV38newName, AV41newCode) ;
         nGXsfl_79_idx = nGXsfl_79_bak_idx;
         sGXsfl_79_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_79_idx), 4, 0), 4, "0");
         SubsflControlProps_794( ) ;
         if ( gx_BV139 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV56SDTInvoiceAddPaymentMethod", AV56SDTInvoiceAddPaymentMethod);
            nGXsfl_139_bak_idx = nGXsfl_139_idx;
            gxgrGridinvoiceaddpaymentmethod_refresh( subAllproductsfiltered_Rows, AV56SDTInvoiceAddPaymentMethod, AV36Total, AV16Brand, AV45Sector, AV58PaymentMethodId, AV38newName, AV41newCode) ;
            nGXsfl_139_idx = nGXsfl_139_bak_idx;
            sGXsfl_139_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_139_idx), 4, 0), 4, "0");
            SubsflControlProps_1393( ) ;
         }
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV57SDTInvoiceAddPaymentMethodItem", AV57SDTInvoiceAddPaymentMethodItem);
         dynavPaymentmethodid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV58PaymentMethodId), 6, 0));
         AssignProp("", false, dynavPaymentmethodid_Internalname, "Values", dynavPaymentmethodid.ToJavascriptSource(), true);
      }

      protected void E121T2( )
      {
         AV86GXV16 = nGXsfl_139_idx;
         if ( ( AV86GXV16 > 0 ) && ( AV56SDTInvoiceAddPaymentMethod.Count >= AV86GXV16 ) )
         {
            AV56SDTInvoiceAddPaymentMethod.CurrentItem = ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV56SDTInvoiceAddPaymentMethod.Item(AV86GXV16));
         }
         /* 'ClearSale' Routine */
         returnInSub = false;
         AV36Total = 0;
         AssignAttri("", false, "AV36Total", StringUtil.LTrimStr( AV36Total, 18, 2));
         AV55RemainingAmount = 0;
         AssignAttri("", false, "AV55RemainingAmount", StringUtil.LTrimStr( AV55RemainingAmount, 18, 2));
         AV24Car.Clear();
         gx_BV79 = true;
         AV29SelectedId.Clear();
         divTablenewsale_Visible = 0;
         AssignProp("", false, divTablenewsale_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablenewsale_Visible), 5, 0), true);
         divTablepaymentmethod_Visible = 0;
         AssignProp("", false, divTablepaymentmethod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablepaymentmethod_Visible), 5, 0), true);
         /* Execute user subroutine: 'CLEARPAYMENTMETHOD' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         if ( gx_BV79 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24Car", AV24Car);
            nGXsfl_79_bak_idx = nGXsfl_79_idx;
            gxgrCarproducts_refresh( subAllproductsfiltered_Rows, AV24Car, AV56SDTInvoiceAddPaymentMethod, AV36Total, AV16Brand, AV45Sector, AV58PaymentMethodId, AV38newName, AV41newCode) ;
            nGXsfl_79_idx = nGXsfl_79_bak_idx;
            sGXsfl_79_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_79_idx), 4, 0), 4, "0");
            SubsflControlProps_794( ) ;
         }
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV29SelectedId", AV29SelectedId);
         if ( gx_BV139 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV56SDTInvoiceAddPaymentMethod", AV56SDTInvoiceAddPaymentMethod);
            nGXsfl_139_bak_idx = nGXsfl_139_idx;
            gxgrGridinvoiceaddpaymentmethod_refresh( subAllproductsfiltered_Rows, AV56SDTInvoiceAddPaymentMethod, AV36Total, AV16Brand, AV45Sector, AV58PaymentMethodId, AV38newName, AV41newCode) ;
            nGXsfl_139_idx = nGXsfl_139_bak_idx;
            sGXsfl_139_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_139_idx), 4, 0), 4, "0");
            SubsflControlProps_1393( ) ;
         }
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV57SDTInvoiceAddPaymentMethodItem", AV57SDTInvoiceAddPaymentMethodItem);
         dynavPaymentmethodid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV58PaymentMethodId), 6, 0));
         AssignProp("", false, dynavPaymentmethodid_Internalname, "Values", dynavPaymentmethodid.ToJavascriptSource(), true);
      }

      protected void E161T2( )
      {
         AV86GXV16 = nGXsfl_139_idx;
         if ( ( AV86GXV16 > 0 ) && ( AV56SDTInvoiceAddPaymentMethod.Count >= AV86GXV16 ) )
         {
            AV56SDTInvoiceAddPaymentMethod.CurrentItem = ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV56SDTInvoiceAddPaymentMethod.Item(AV86GXV16));
         }
         AV79GXV9 = nGXsfl_79_idx;
         if ( ( AV79GXV9 > 0 ) && ( AV24Car.Count >= AV79GXV9 ) )
         {
            AV24Car.CurrentItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV24Car.Item(AV79GXV9));
         }
         /* Remove_Click Routine */
         returnInSub = false;
         AV30Position = AV29SelectedId.IndexOf(((SdtSDTCarProducts_SDTCarProductsItem)(AV24Car.CurrentItem)).gxTpr_Id);
         AssignAttri("", false, "AV30Position", StringUtil.LTrimStr( (decimal)(AV30Position), 6, 0));
         AV29SelectedId.RemoveItem(AV30Position);
         AV24Car.RemoveItem(AV30Position);
         gx_BV79 = true;
         if ( AV24Car.Count < 1 )
         {
            divTablenewsale_Visible = 0;
            AssignProp("", false, divTablenewsale_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablenewsale_Visible), 5, 0), true);
            divTablepaymentmethod_Visible = 0;
            AssignProp("", false, divTablepaymentmethod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablepaymentmethod_Visible), 5, 0), true);
            /* Execute user subroutine: 'CLEARPAYMENTMETHOD' */
            S122 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV29SelectedId", AV29SelectedId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24Car", AV24Car);
         nGXsfl_79_bak_idx = nGXsfl_79_idx;
         gxgrCarproducts_refresh( subAllproductsfiltered_Rows, AV24Car, AV56SDTInvoiceAddPaymentMethod, AV36Total, AV16Brand, AV45Sector, AV58PaymentMethodId, AV38newName, AV41newCode) ;
         nGXsfl_79_idx = nGXsfl_79_bak_idx;
         sGXsfl_79_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_79_idx), 4, 0), 4, "0");
         SubsflControlProps_794( ) ;
         if ( gx_BV139 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV56SDTInvoiceAddPaymentMethod", AV56SDTInvoiceAddPaymentMethod);
            nGXsfl_139_bak_idx = nGXsfl_139_idx;
            gxgrGridinvoiceaddpaymentmethod_refresh( subAllproductsfiltered_Rows, AV56SDTInvoiceAddPaymentMethod, AV36Total, AV16Brand, AV45Sector, AV58PaymentMethodId, AV38newName, AV41newCode) ;
            nGXsfl_139_idx = nGXsfl_139_bak_idx;
            sGXsfl_139_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_139_idx), 4, 0), 4, "0");
            SubsflControlProps_1393( ) ;
         }
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV57SDTInvoiceAddPaymentMethodItem", AV57SDTInvoiceAddPaymentMethodItem);
         dynavPaymentmethodid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV58PaymentMethodId), 6, 0));
         AssignProp("", false, dynavPaymentmethodid_Internalname, "Values", dynavPaymentmethodid.ToJavascriptSource(), true);
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E241T2 ();
         if (returnInSub) return;
      }

      protected void E241T2( )
      {
         /* Start Routine */
         returnInSub = false;
         new checkauthentication(context ).execute( out  AV47Context) ;
         AV36Total = 0;
         AssignAttri("", false, "AV36Total", StringUtil.LTrimStr( AV36Total, 18, 2));
         edtavTotal_Visible = 0;
         AssignProp("", false, edtavTotal_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTotal_Visible), 5, 0), true);
         AV34Employee = 1;
         divTablenewsale_Visible = 0;
         AssignProp("", false, divTablenewsale_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablenewsale_Visible), 5, 0), true);
         divTablepaymentmethod_Visible = 0;
         AssignProp("", false, divTablepaymentmethod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablepaymentmethod_Visible), 5, 0), true);
         /* Execute user subroutine: 'CLEARPAYMENTMETHOD' */
         S122 ();
         if (returnInSub) return;
         AV49SDTProductFiltered = new GXBaseCollection<SdtSDTProductsFiltered_SDTProductsFilteredItem>( context, "SDTProductsFilteredItem", "mtaKB");
         gx_BV35 = true;
         GXt_int2 = 0;
         new invoiceregistergetproductsfiltered(context ).execute(  AV17Code, ref  AV18Name, ref  GXt_int2, ref  AV45Sector, ref  AV16Brand, out  AV49SDTProductFiltered) ;
         gx_BV35 = true;
         AssignAttri("", false, "AV18Name", AV18Name);
         AssignAttri("", false, "AV45Sector", StringUtil.LTrimStr( (decimal)(AV45Sector), 6, 0));
         AssignAttri("", false, "AV16Brand", StringUtil.LTrimStr( (decimal)(AV16Brand), 6, 0));
         bttSelectall_Visible = 0;
         AssignProp("", false, bttSelectall_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttSelectall_Visible), 5, 0), true);
      }

      protected void E171T2( )
      {
         AV86GXV16 = nGXsfl_139_idx;
         if ( ( AV86GXV16 > 0 ) && ( AV56SDTInvoiceAddPaymentMethod.Count >= AV86GXV16 ) )
         {
            AV56SDTInvoiceAddPaymentMethod.CurrentItem = ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV56SDTInvoiceAddPaymentMethod.Item(AV86GXV16));
         }
         AV79GXV9 = nGXsfl_79_idx;
         if ( ( AV79GXV9 > 0 ) && ( AV24Car.Count >= AV79GXV9 ) )
         {
            AV24Car.CurrentItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV24Car.Item(AV79GXV9));
         }
         /* Carproducts_Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CALCULATETOTAL' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'CALCULATEREMAINING' */
         S142 ();
         if (returnInSub) return;
         edtavRemove_gximage = "GeneXusUnanimo_delete_light";
         AssignProp("", false, edtavRemove_Internalname, "gximage", edtavRemove_gximage, !bGXsfl_79_Refreshing);
         AV44Remove = context.GetImagePath( "db0f63cd-dde8-4bf7-aca2-01cdf8d3c157", "", context.GetTheme( ));
         AssignProp("", false, edtavRemove_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV44Remove)) ? AV93Remove_GXI : context.convertURL( context.PathToRelativeUrl( AV44Remove))), !bGXsfl_79_Refreshing);
         AssignProp("", false, edtavRemove_Internalname, "SrcSet", context.GetImageSrcSet( AV44Remove), true);
         AV93Remove_GXI = GXDbFile.PathToUrl( context.GetImagePath( "db0f63cd-dde8-4bf7-aca2-01cdf8d3c157", "", context.GetTheme( )));
         AssignProp("", false, edtavRemove_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV44Remove)) ? AV93Remove_GXI : context.convertURL( context.PathToRelativeUrl( AV44Remove))), !bGXsfl_79_Refreshing);
         AssignProp("", false, edtavRemove_Internalname, "SrcSet", context.GetImageSrcSet( AV44Remove), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24Car", AV24Car);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV57SDTInvoiceAddPaymentMethodItem", AV57SDTInvoiceAddPaymentMethodItem);
      }

      protected void S132( )
      {
         /* 'CALCULATETOTAL' Routine */
         returnInSub = false;
         AV36Total = 0;
         AssignAttri("", false, "AV36Total", StringUtil.LTrimStr( AV36Total, 18, 2));
         AV94GXV23 = 1;
         while ( AV94GXV23 <= AV24Car.Count )
         {
            AV26CarItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV24Car.Item(AV94GXV23));
            AV26CarItem.gxTpr_Subtotal = (decimal)(AV26CarItem.gxTpr_Quantity*AV26CarItem.gxTpr_Unitprice);
            AV36Total = (decimal)(AV36Total+(AV26CarItem.gxTpr_Subtotal));
            AssignAttri("", false, "AV36Total", StringUtil.LTrimStr( AV36Total, 18, 2));
            AV94GXV23 = (int)(AV94GXV23+1);
         }
      }

      protected void E131T2( )
      {
         AV86GXV16 = nGXsfl_139_idx;
         if ( ( AV86GXV16 > 0 ) && ( AV56SDTInvoiceAddPaymentMethod.Count >= AV86GXV16 ) )
         {
            AV56SDTInvoiceAddPaymentMethod.CurrentItem = ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV56SDTInvoiceAddPaymentMethod.Item(AV86GXV16));
         }
         AV79GXV9 = nGXsfl_79_idx;
         if ( ( AV79GXV9 > 0 ) && ( AV24Car.Count >= AV79GXV9 ) )
         {
            AV24Car.CurrentItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV24Car.Item(AV79GXV9));
         }
         /* 'SelectAll' Routine */
         returnInSub = false;
         AV24Car = new GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem>( context, "SDTCarProductsItem", "mtaKB");
         gx_BV79 = true;
         GXt_objcol_SdtSDTCarProducts_SDTCarProductsItem3 = AV24Car;
         GXt_int2 = 0;
         new registersaleselectall(context ).execute(  AV17Code, ref  AV18Name, ref  GXt_int2, ref  AV16Brand, ref  AV45Sector, out  GXt_objcol_SdtSDTCarProducts_SDTCarProductsItem3) ;
         AssignAttri("", false, "AV18Name", AV18Name);
         AssignAttri("", false, "AV16Brand", StringUtil.LTrimStr( (decimal)(AV16Brand), 6, 0));
         AssignAttri("", false, "AV45Sector", StringUtil.LTrimStr( (decimal)(AV45Sector), 6, 0));
         AV24Car = GXt_objcol_SdtSDTCarProducts_SDTCarProductsItem3;
         gx_BV79 = true;
         divTablenewsale_Visible = 1;
         AssignProp("", false, divTablenewsale_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablenewsale_Visible), 5, 0), true);
         divTablepaymentmethod_Visible = 1;
         AssignProp("", false, divTablepaymentmethod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablepaymentmethod_Visible), 5, 0), true);
         /* Execute user subroutine: 'CLEARPAYMENTMETHOD' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         if ( gx_BV79 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24Car", AV24Car);
            nGXsfl_79_bak_idx = nGXsfl_79_idx;
            gxgrCarproducts_refresh( subAllproductsfiltered_Rows, AV24Car, AV56SDTInvoiceAddPaymentMethod, AV36Total, AV16Brand, AV45Sector, AV58PaymentMethodId, AV38newName, AV41newCode) ;
            nGXsfl_79_idx = nGXsfl_79_bak_idx;
            sGXsfl_79_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_79_idx), 4, 0), 4, "0");
            SubsflControlProps_794( ) ;
         }
         dynavSector.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV45Sector), 6, 0));
         AssignProp("", false, dynavSector_Internalname, "Values", dynavSector.ToJavascriptSource(), true);
         dynavBrand.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16Brand), 6, 0));
         AssignProp("", false, dynavBrand_Internalname, "Values", dynavBrand.ToJavascriptSource(), true);
         if ( gx_BV139 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV56SDTInvoiceAddPaymentMethod", AV56SDTInvoiceAddPaymentMethod);
            nGXsfl_139_bak_idx = nGXsfl_139_idx;
            gxgrGridinvoiceaddpaymentmethod_refresh( subAllproductsfiltered_Rows, AV56SDTInvoiceAddPaymentMethod, AV36Total, AV16Brand, AV45Sector, AV58PaymentMethodId, AV38newName, AV41newCode) ;
            nGXsfl_139_idx = nGXsfl_139_bak_idx;
            sGXsfl_139_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_139_idx), 4, 0), 4, "0");
            SubsflControlProps_1393( ) ;
         }
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV57SDTInvoiceAddPaymentMethodItem", AV57SDTInvoiceAddPaymentMethodItem);
         dynavPaymentmethodid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV58PaymentMethodId), 6, 0));
         AssignProp("", false, dynavPaymentmethodid_Internalname, "Values", dynavPaymentmethodid.ToJavascriptSource(), true);
      }

      protected void S112( )
      {
         /* 'CONTROL' Routine */
         returnInSub = false;
         AV95GXV24 = 1;
         while ( AV95GXV24 <= AV24Car.Count )
         {
            AV26CarItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV24Car.Item(AV95GXV24));
            if ( ( AV26CarItem.gxTpr_Quantity == 0 ) || ( AV26CarItem.gxTpr_Quantity > AV26CarItem.gxTpr_Stock ) )
            {
               AV37AllOk = false;
               AssignAttri("", false, "AV37AllOk", AV37AllOk);
               GX_msglist.addItem("Some Quantity is invalid!");
               if (true) break;
            }
            AV95GXV24 = (int)(AV95GXV24+1);
         }
         if ( ( AV24Car.Count <= 0 ) && AV37AllOk )
         {
            AV37AllOk = false;
            AssignAttri("", false, "AV37AllOk", AV37AllOk);
            GX_msglist.addItem("Choose at least one product before register a sale");
         }
         if ( ( AV55RemainingAmount != AV36Total ) && ( AV55RemainingAmount != Convert.ToDecimal( 0 )) )
         {
            AV37AllOk = false;
            AssignAttri("", false, "AV37AllOk", AV37AllOk);
            GX_msglist.addItem("The total of the payment method does not match the remaining amount");
         }
      }

      protected void E251T2( )
      {
         AV71GXV1 = (int)(nGXsfl_35_idx+ALLPRODUCTSFILTERED_nFirstRecordOnPage);
         if ( ( AV71GXV1 > 0 ) && ( AV49SDTProductFiltered.Count >= AV71GXV1 ) )
         {
            AV49SDTProductFiltered.CurrentItem = ((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV49SDTProductFiltered.Item(AV71GXV1));
         }
         /* Allproductsfiltered_Refresh Routine */
         returnInSub = false;
         AV49SDTProductFiltered = new GXBaseCollection<SdtSDTProductsFiltered_SDTProductsFilteredItem>( context, "SDTProductsFilteredItem", "mtaKB");
         gx_BV35 = true;
         GXt_int2 = 0;
         new invoiceregistergetproductsfiltered(context ).execute(  AV17Code, ref  AV18Name, ref  GXt_int2, ref  AV45Sector, ref  AV16Brand, out  AV49SDTProductFiltered) ;
         gx_BV35 = true;
         AssignAttri("", false, "AV18Name", AV18Name);
         AssignAttri("", false, "AV45Sector", StringUtil.LTrimStr( (decimal)(AV45Sector), 6, 0));
         AssignAttri("", false, "AV16Brand", StringUtil.LTrimStr( (decimal)(AV16Brand), 6, 0));
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV49SDTProductFiltered", AV49SDTProductFiltered);
         dynavBrand.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16Brand), 6, 0));
         AssignProp("", false, dynavBrand_Internalname, "Values", dynavBrand.ToJavascriptSource(), true);
         dynavSector.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV45Sector), 6, 0));
         AssignProp("", false, dynavSector_Internalname, "Values", dynavSector.ToJavascriptSource(), true);
      }

      protected void E141T2( )
      {
         AV86GXV16 = nGXsfl_139_idx;
         if ( ( AV86GXV16 > 0 ) && ( AV56SDTInvoiceAddPaymentMethod.Count >= AV86GXV16 ) )
         {
            AV56SDTInvoiceAddPaymentMethod.CurrentItem = ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV56SDTInvoiceAddPaymentMethod.Item(AV86GXV16));
         }
         /* 'AddPaymentMethod' Routine */
         returnInSub = false;
         if ( ! (0==AV58PaymentMethodId) && ( AV59InvoicePaymentMethodImport <= AV55RemainingAmount ) && ( AV59InvoicePaymentMethodImport > Convert.ToDecimal( 0 )) )
         {
            AV60PaymentMethod.Load(AV58PaymentMethodId);
            /* Execute user subroutine: 'PAYMENTMETHODWASUSED' */
            S152 ();
            if (returnInSub) return;
            if ( ! AV63WasUsed )
            {
               AV57SDTInvoiceAddPaymentMethodItem = new SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem(context);
               AV57SDTInvoiceAddPaymentMethodItem.gxTpr_Paymentmethodid = AV60PaymentMethod.gxTpr_Paymentmethodid;
               AV57SDTInvoiceAddPaymentMethodItem.gxTpr_Paymentmethoddescription = AV60PaymentMethod.gxTpr_Paymentmethoddescription;
               AV57SDTInvoiceAddPaymentMethodItem.gxTpr_Paymentmethodrecarge = AV60PaymentMethod.gxTpr_Paymentmethodrecarge;
               AV57SDTInvoiceAddPaymentMethodItem.gxTpr_Paymentmethoddiscount = AV60PaymentMethod.gxTpr_Paymentmethoddiscount;
               AV57SDTInvoiceAddPaymentMethodItem.gxTpr_Invoicepaymentmethodimport = AV59InvoicePaymentMethodImport;
               GXt_decimal4 = 0;
               new roundvalue(context ).execute(  AV59InvoicePaymentMethodImport*(AV60PaymentMethod.gxTpr_Paymentmethoddiscount/ (decimal)(100)), out  GXt_decimal4) ;
               AV57SDTInvoiceAddPaymentMethodItem.gxTpr_Invoicepaymentmethoddiscountimport = GXt_decimal4;
               GXt_decimal4 = 0;
               new roundvalue(context ).execute(  AV59InvoicePaymentMethodImport*(AV60PaymentMethod.gxTpr_Paymentmethodrecarge/ (decimal)(100)), out  GXt_decimal4) ;
               AV57SDTInvoiceAddPaymentMethodItem.gxTpr_Invoicepaymentmethodrechargeimport = GXt_decimal4;
               AV56SDTInvoiceAddPaymentMethod.Add(AV57SDTInvoiceAddPaymentMethodItem, 0);
               gx_BV139 = true;
            }
            else
            {
               /* Execute user subroutine: 'PAYMENTMETHODPOSITION' */
               S162 ();
               if (returnInSub) return;
               ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV56SDTInvoiceAddPaymentMethod.Item(AV30Position)).gxTpr_Invoicepaymentmethodimport = (decimal)(((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV56SDTInvoiceAddPaymentMethod.Item(AV30Position)).gxTpr_Invoicepaymentmethodimport+AV59InvoicePaymentMethodImport);
               GXt_decimal4 = 0;
               new roundvalue(context ).execute(  ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV56SDTInvoiceAddPaymentMethod.Item(AV30Position)).gxTpr_Invoicepaymentmethodimport*(AV60PaymentMethod.gxTpr_Paymentmethoddiscount/ (decimal)(100)), out  GXt_decimal4) ;
               AV57SDTInvoiceAddPaymentMethodItem.gxTpr_Invoicepaymentmethoddiscountimport = GXt_decimal4;
               GXt_decimal4 = 0;
               new roundvalue(context ).execute(  ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV56SDTInvoiceAddPaymentMethod.Item(AV30Position)).gxTpr_Invoicepaymentmethodimport*(AV60PaymentMethod.gxTpr_Paymentmethodrecarge/ (decimal)(100)), out  GXt_decimal4) ;
               AV57SDTInvoiceAddPaymentMethodItem.gxTpr_Invoicepaymentmethodrechargeimport = GXt_decimal4;
            }
         }
         else
         {
            if ( (0==AV58PaymentMethodId) )
            {
               GX_msglist.addItem("Choose a Payment Method first!");
            }
            else if ( AV59InvoicePaymentMethodImport > AV55RemainingAmount )
            {
               GX_msglist.addItem("Import of Payment Methods must be less or equal to Remaining Amount");
            }
            else if ( ( AV59InvoicePaymentMethodImport <= Convert.ToDecimal( 0 )) )
            {
               GX_msglist.addItem("Import of Payment Methods must be higher to zero");
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV57SDTInvoiceAddPaymentMethodItem", AV57SDTInvoiceAddPaymentMethodItem);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV56SDTInvoiceAddPaymentMethod", AV56SDTInvoiceAddPaymentMethod);
         nGXsfl_139_bak_idx = nGXsfl_139_idx;
         gxgrGridinvoiceaddpaymentmethod_refresh( subAllproductsfiltered_Rows, AV56SDTInvoiceAddPaymentMethod, AV36Total, AV16Brand, AV45Sector, AV58PaymentMethodId, AV38newName, AV41newCode) ;
         nGXsfl_139_idx = nGXsfl_139_bak_idx;
         sGXsfl_139_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_139_idx), 4, 0), 4, "0");
         SubsflControlProps_1393( ) ;
      }

      protected void E191T2( )
      {
         AV86GXV16 = nGXsfl_139_idx;
         if ( ( AV86GXV16 > 0 ) && ( AV56SDTInvoiceAddPaymentMethod.Count >= AV86GXV16 ) )
         {
            AV56SDTInvoiceAddPaymentMethod.CurrentItem = ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV56SDTInvoiceAddPaymentMethod.Item(AV86GXV16));
         }
         /* Gridinvoiceaddpaymentmethod_Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CALCULATEREMAINING' */
         S142 ();
         if (returnInSub) return;
         edtavPaymentmethodremove_gximage = "GeneXusUnanimo_delete_light";
         AssignProp("", false, edtavPaymentmethodremove_Internalname, "gximage", edtavPaymentmethodremove_gximage, !bGXsfl_139_Refreshing);
         AV61PaymentMethodRemove = context.GetImagePath( "db0f63cd-dde8-4bf7-aca2-01cdf8d3c157", "", context.GetTheme( ));
         AssignProp("", false, edtavPaymentmethodremove_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV61PaymentMethodRemove)) ? AV96Paymentmethodremove_GXI : context.convertURL( context.PathToRelativeUrl( AV61PaymentMethodRemove))), !bGXsfl_139_Refreshing);
         AssignProp("", false, edtavPaymentmethodremove_Internalname, "SrcSet", context.GetImageSrcSet( AV61PaymentMethodRemove), true);
         AV96Paymentmethodremove_GXI = GXDbFile.PathToUrl( context.GetImagePath( "db0f63cd-dde8-4bf7-aca2-01cdf8d3c157", "", context.GetTheme( )));
         AssignProp("", false, edtavPaymentmethodremove_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV61PaymentMethodRemove)) ? AV96Paymentmethodremove_GXI : context.convertURL( context.PathToRelativeUrl( AV61PaymentMethodRemove))), !bGXsfl_139_Refreshing);
         AssignProp("", false, edtavPaymentmethodremove_Internalname, "SrcSet", context.GetImageSrcSet( AV61PaymentMethodRemove), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV57SDTInvoiceAddPaymentMethodItem", AV57SDTInvoiceAddPaymentMethodItem);
      }

      protected void E201T2( )
      {
         AV86GXV16 = nGXsfl_139_idx;
         if ( ( AV86GXV16 > 0 ) && ( AV56SDTInvoiceAddPaymentMethod.Count >= AV86GXV16 ) )
         {
            AV56SDTInvoiceAddPaymentMethod.CurrentItem = ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV56SDTInvoiceAddPaymentMethod.Item(AV86GXV16));
         }
         /* Paymentmethodremove_Click Routine */
         returnInSub = false;
         AV30Position = AV56SDTInvoiceAddPaymentMethod.IndexOf(((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)(AV56SDTInvoiceAddPaymentMethod.CurrentItem)));
         AssignAttri("", false, "AV30Position", StringUtil.LTrimStr( (decimal)(AV30Position), 6, 0));
         AV56SDTInvoiceAddPaymentMethod.RemoveItem(AV30Position);
         gx_BV139 = true;
         /* Execute user subroutine: 'CALCULATEREMAINING' */
         S142 ();
         if (returnInSub) return;
         gxgrGridinvoiceaddpaymentmethod_refresh( subAllproductsfiltered_Rows, AV56SDTInvoiceAddPaymentMethod, AV36Total, AV16Brand, AV45Sector, AV58PaymentMethodId, AV38newName, AV41newCode) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV56SDTInvoiceAddPaymentMethod", AV56SDTInvoiceAddPaymentMethod);
         nGXsfl_139_bak_idx = nGXsfl_139_idx;
         gxgrGridinvoiceaddpaymentmethod_refresh( subAllproductsfiltered_Rows, AV56SDTInvoiceAddPaymentMethod, AV36Total, AV16Brand, AV45Sector, AV58PaymentMethodId, AV38newName, AV41newCode) ;
         nGXsfl_139_idx = nGXsfl_139_bak_idx;
         sGXsfl_139_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_139_idx), 4, 0), 4, "0");
         SubsflControlProps_1393( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV57SDTInvoiceAddPaymentMethodItem", AV57SDTInvoiceAddPaymentMethodItem);
      }

      protected void S122( )
      {
         /* 'CLEARPAYMENTMETHOD' Routine */
         returnInSub = false;
         AV56SDTInvoiceAddPaymentMethod = new GXBaseCollection<SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem>( context, "SDTInvoiceAddPaymentMethodItem", "mtaKB");
         gx_BV139 = true;
         AV57SDTInvoiceAddPaymentMethodItem = new SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem(context);
         AV55RemainingAmount = AV36Total;
         AssignAttri("", false, "AV55RemainingAmount", StringUtil.LTrimStr( AV55RemainingAmount, 18, 2));
         AV64AmountReceivable = AV36Total;
         AssignAttri("", false, "AV64AmountReceivable", StringUtil.LTrimStr( AV64AmountReceivable, 18, 2));
         AV58PaymentMethodId = 0;
         AssignAttri("", false, "AV58PaymentMethodId", StringUtil.LTrimStr( (decimal)(AV58PaymentMethodId), 6, 0));
         AV59InvoicePaymentMethodImport = 0;
         AssignAttri("", false, "AV59InvoicePaymentMethodImport", StringUtil.LTrimStr( AV59InvoicePaymentMethodImport, 18, 2));
      }

      protected void E211T2( )
      {
         AV86GXV16 = nGXsfl_139_idx;
         if ( ( AV86GXV16 > 0 ) && ( AV56SDTInvoiceAddPaymentMethod.Count >= AV86GXV16 ) )
         {
            AV56SDTInvoiceAddPaymentMethod.CurrentItem = ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV56SDTInvoiceAddPaymentMethod.Item(AV86GXV16));
         }
         /* Ctlinvoicepaymentmethodimport_Controlvaluechanged Routine */
         returnInSub = false;
         AV62ImportAux = ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)(AV56SDTInvoiceAddPaymentMethod.CurrentItem)).gxTpr_Invoicepaymentmethodimport;
         if ( ! ( AV62ImportAux <= Convert.ToDecimal( 0 )) && ( AV62ImportAux <= AV55RemainingAmount ) )
         {
            ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)(AV56SDTInvoiceAddPaymentMethod.CurrentItem)).gxTpr_Invoicepaymentmethodimport = AV62ImportAux;
            /* Execute user subroutine: 'CALCULATEREMAINING' */
            S142 ();
            if (returnInSub) return;
         }
         else
         {
            if ( ! ( AV62ImportAux <= Convert.ToDecimal( 0 )) )
            {
               GX_msglist.addItem("Import of Payment must be less or equal to Remaining Amount");
            }
            else
            {
               GX_msglist.addItem("Import must be higher to zero");
            }
            ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)(AV56SDTInvoiceAddPaymentMethod.CurrentItem)).gxTpr_Invoicepaymentmethodimport = AV55RemainingAmount;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV56SDTInvoiceAddPaymentMethod", AV56SDTInvoiceAddPaymentMethod);
         nGXsfl_139_bak_idx = nGXsfl_139_idx;
         gxgrGridinvoiceaddpaymentmethod_refresh( subAllproductsfiltered_Rows, AV56SDTInvoiceAddPaymentMethod, AV36Total, AV16Brand, AV45Sector, AV58PaymentMethodId, AV38newName, AV41newCode) ;
         nGXsfl_139_idx = nGXsfl_139_bak_idx;
         sGXsfl_139_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_139_idx), 4, 0), 4, "0");
         SubsflControlProps_1393( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV57SDTInvoiceAddPaymentMethodItem", AV57SDTInvoiceAddPaymentMethodItem);
      }

      protected void S142( )
      {
         /* 'CALCULATEREMAINING' Routine */
         returnInSub = false;
         AV62ImportAux = 0;
         AV65DiscountImportAux = 0;
         AV66RechargeImportAux = 0;
         AV97GXV25 = 1;
         while ( AV97GXV25 <= AV56SDTInvoiceAddPaymentMethod.Count )
         {
            AV57SDTInvoiceAddPaymentMethodItem = ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV56SDTInvoiceAddPaymentMethod.Item(AV97GXV25));
            AV62ImportAux = (decimal)(AV62ImportAux+(AV57SDTInvoiceAddPaymentMethodItem.gxTpr_Invoicepaymentmethodimport));
            AV65DiscountImportAux = (decimal)(AV65DiscountImportAux+(AV57SDTInvoiceAddPaymentMethodItem.gxTpr_Invoicepaymentmethoddiscountimport));
            AV66RechargeImportAux = (decimal)(AV66RechargeImportAux+(AV57SDTInvoiceAddPaymentMethodItem.gxTpr_Invoicepaymentmethodrechargeimport));
            AV97GXV25 = (int)(AV97GXV25+1);
         }
         AV55RemainingAmount = (decimal)(AV36Total-AV62ImportAux);
         AssignAttri("", false, "AV55RemainingAmount", StringUtil.LTrimStr( AV55RemainingAmount, 18, 2));
         AV64AmountReceivable = (decimal)(AV36Total+AV66RechargeImportAux-AV65DiscountImportAux);
         AssignAttri("", false, "AV64AmountReceivable", StringUtil.LTrimStr( AV64AmountReceivable, 18, 2));
         AV59InvoicePaymentMethodImport = AV55RemainingAmount;
         AssignAttri("", false, "AV59InvoicePaymentMethodImport", StringUtil.LTrimStr( AV59InvoicePaymentMethodImport, 18, 2));
      }

      protected void S152( )
      {
         /* 'PAYMENTMETHODWASUSED' Routine */
         returnInSub = false;
         AV63WasUsed = false;
         AssignAttri("", false, "AV63WasUsed", AV63WasUsed);
         AV98GXV26 = 1;
         while ( AV98GXV26 <= AV56SDTInvoiceAddPaymentMethod.Count )
         {
            AV57SDTInvoiceAddPaymentMethodItem = ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV56SDTInvoiceAddPaymentMethod.Item(AV98GXV26));
            if ( AV57SDTInvoiceAddPaymentMethodItem.gxTpr_Paymentmethodid == AV58PaymentMethodId )
            {
               AV63WasUsed = true;
               AssignAttri("", false, "AV63WasUsed", AV63WasUsed);
               if (true) break;
            }
            AV98GXV26 = (int)(AV98GXV26+1);
         }
      }

      protected void S162( )
      {
         /* 'PAYMENTMETHODPOSITION' Routine */
         returnInSub = false;
         AV30Position = 0;
         AssignAttri("", false, "AV30Position", StringUtil.LTrimStr( (decimal)(AV30Position), 6, 0));
         AV99GXV27 = 1;
         while ( AV99GXV27 <= AV56SDTInvoiceAddPaymentMethod.Count )
         {
            AV57SDTInvoiceAddPaymentMethodItem = ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV56SDTInvoiceAddPaymentMethod.Item(AV99GXV27));
            AV30Position = (int)(AV30Position+1);
            AssignAttri("", false, "AV30Position", StringUtil.LTrimStr( (decimal)(AV30Position), 6, 0));
            if ( AV57SDTInvoiceAddPaymentMethodItem.gxTpr_Paymentmethodid == AV58PaymentMethodId )
            {
               if (true) break;
            }
            AV99GXV27 = (int)(AV99GXV27+1);
         }
      }

      private void E261T2( )
      {
         /* Allproductsfiltered_Load Routine */
         returnInSub = false;
         AV71GXV1 = 1;
         while ( AV71GXV1 <= AV49SDTProductFiltered.Count )
         {
            AV49SDTProductFiltered.CurrentItem = ((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV49SDTProductFiltered.Item(AV71GXV1));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 35;
            }
            if ( ( subAllproductsfiltered_Islastpage == 1 ) || ( 4 == 0 ) || ( ( ALLPRODUCTSFILTERED_nCurrentRecord >= ALLPRODUCTSFILTERED_nFirstRecordOnPage ) && ( ALLPRODUCTSFILTERED_nCurrentRecord < ALLPRODUCTSFILTERED_nFirstRecordOnPage + subAllproductsfiltered_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_352( ) ;
            }
            ALLPRODUCTSFILTERED_nEOF = (short)(((ALLPRODUCTSFILTERED_nCurrentRecord<ALLPRODUCTSFILTERED_nFirstRecordOnPage+subAllproductsfiltered_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "ALLPRODUCTSFILTERED_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(ALLPRODUCTSFILTERED_nEOF), 1, 0, ".", "")));
            ALLPRODUCTSFILTERED_nCurrentRecord = (long)(ALLPRODUCTSFILTERED_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_35_Refreshing )
            {
               DoAjaxLoad(35, AllproductsfilteredRow);
            }
            AV71GXV1 = (int)(AV71GXV1+1);
         }
      }

      private void E221T3( )
      {
         /* Gridinvoiceaddpaymentmethod_Load Routine */
         returnInSub = false;
         AV86GXV16 = 1;
         while ( AV86GXV16 <= AV56SDTInvoiceAddPaymentMethod.Count )
         {
            AV56SDTInvoiceAddPaymentMethod.CurrentItem = ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV56SDTInvoiceAddPaymentMethod.Item(AV86GXV16));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 139;
            }
            sendrow_1393( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_139_Refreshing )
            {
               DoAjaxLoad(139, GridinvoiceaddpaymentmethodRow);
            }
            AV86GXV16 = (int)(AV86GXV16+1);
         }
      }

      private void E181T4( )
      {
         /* Carproducts_Load Routine */
         returnInSub = false;
         AV79GXV9 = 1;
         while ( AV79GXV9 <= AV24Car.Count )
         {
            AV24Car.CurrentItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV24Car.Item(AV79GXV9));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 79;
            }
            sendrow_794( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_79_Refreshing )
            {
               DoAjaxLoad(79, CarproductsRow);
            }
            AV79GXV9 = (int)(AV79GXV9+1);
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
         PA1T2( ) ;
         WS1T2( ) ;
         WE1T2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024121511282159", true, true);
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
         context.AddJavascriptSource("wpregistersale.js", "?2024121511282160", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_352( )
      {
         edtavCtlid_Internalname = "CTLID_"+sGXsfl_35_idx;
         edtavCtlcode_Internalname = "CTLCODE_"+sGXsfl_35_idx;
         edtavCtlname_Internalname = "CTLNAME_"+sGXsfl_35_idx;
         edtavCtlstock1_Internalname = "CTLSTOCK1_"+sGXsfl_35_idx;
         edtavCtlretailprice_Internalname = "CTLRETAILPRICE_"+sGXsfl_35_idx;
         edtavCtlwholesaleprice_Internalname = "CTLWHOLESALEPRICE_"+sGXsfl_35_idx;
         edtavCtlminiumquantitywholesale_Internalname = "CTLMINIUMQUANTITYWHOLESALE_"+sGXsfl_35_idx;
      }

      protected void SubsflControlProps_fel_352( )
      {
         edtavCtlid_Internalname = "CTLID_"+sGXsfl_35_fel_idx;
         edtavCtlcode_Internalname = "CTLCODE_"+sGXsfl_35_fel_idx;
         edtavCtlname_Internalname = "CTLNAME_"+sGXsfl_35_fel_idx;
         edtavCtlstock1_Internalname = "CTLSTOCK1_"+sGXsfl_35_fel_idx;
         edtavCtlretailprice_Internalname = "CTLRETAILPRICE_"+sGXsfl_35_fel_idx;
         edtavCtlwholesaleprice_Internalname = "CTLWHOLESALEPRICE_"+sGXsfl_35_fel_idx;
         edtavCtlminiumquantitywholesale_Internalname = "CTLMINIUMQUANTITYWHOLESALE_"+sGXsfl_35_fel_idx;
      }

      protected void sendrow_352( )
      {
         SubsflControlProps_352( ) ;
         WB1T0( ) ;
         if ( ( 4 * 1 == 0 ) || ( nGXsfl_35_idx <= subAllproductsfiltered_fnc_Recordsperpage( ) * 1 ) )
         {
            AllproductsfilteredRow = GXWebRow.GetNew(context,AllproductsfilteredContainer);
            if ( subAllproductsfiltered_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subAllproductsfiltered_Backstyle = 0;
               if ( StringUtil.StrCmp(subAllproductsfiltered_Class, "") != 0 )
               {
                  subAllproductsfiltered_Linesclass = subAllproductsfiltered_Class+"Odd";
               }
            }
            else if ( subAllproductsfiltered_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subAllproductsfiltered_Backstyle = 0;
               subAllproductsfiltered_Backcolor = subAllproductsfiltered_Allbackcolor;
               if ( StringUtil.StrCmp(subAllproductsfiltered_Class, "") != 0 )
               {
                  subAllproductsfiltered_Linesclass = subAllproductsfiltered_Class+"Uniform";
               }
            }
            else if ( subAllproductsfiltered_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subAllproductsfiltered_Backstyle = 1;
               if ( StringUtil.StrCmp(subAllproductsfiltered_Class, "") != 0 )
               {
                  subAllproductsfiltered_Linesclass = subAllproductsfiltered_Class+"Odd";
               }
               subAllproductsfiltered_Backcolor = (int)(0x0);
            }
            else if ( subAllproductsfiltered_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subAllproductsfiltered_Backstyle = 1;
               if ( ((int)((nGXsfl_35_idx) % (2))) == 0 )
               {
                  subAllproductsfiltered_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subAllproductsfiltered_Class, "") != 0 )
                  {
                     subAllproductsfiltered_Linesclass = subAllproductsfiltered_Class+"Even";
                  }
               }
               else
               {
                  subAllproductsfiltered_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subAllproductsfiltered_Class, "") != 0 )
                  {
                     subAllproductsfiltered_Linesclass = subAllproductsfiltered_Class+"Odd";
                  }
               }
            }
            if ( AllproductsfilteredContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"PromptGrid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_35_idx+"\">") ;
            }
            /* Subfile cell */
            if ( AllproductsfilteredContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsfilteredRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV49SDTProductFiltered.Item(AV71GXV1)).gxTpr_Id), 6, 0, ".", "")),StringUtil.LTrim( ((edtavCtlid_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV49SDTProductFiltered.Item(AV71GXV1)).gxTpr_Id), "ZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV49SDTProductFiltered.Item(AV71GXV1)).gxTpr_Id), "ZZZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(int)edtavCtlid_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( AllproductsfilteredContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsfilteredRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcode_Internalname,((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV49SDTProductFiltered.Item(AV71GXV1)).gxTpr_Code,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcode_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlcode_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( AllproductsfilteredContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsfilteredRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname_Internalname,((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV49SDTProductFiltered.Item(AV71GXV1)).gxTpr_Name,(string)"",(string)"","'"+""+"'"+",false,"+"'"+"ECTLNAME.CLICK."+sGXsfl_35_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlname_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( AllproductsfilteredContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsfilteredRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlstock1_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV49SDTProductFiltered.Item(AV71GXV1)).gxTpr_Stock), 6, 0, ".", "")),StringUtil.LTrim( ((edtavCtlstock1_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV49SDTProductFiltered.Item(AV71GXV1)).gxTpr_Stock), "ZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV49SDTProductFiltered.Item(AV71GXV1)).gxTpr_Stock), "ZZZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlstock1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlstock1_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( AllproductsfilteredContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsfilteredRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlretailprice_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV49SDTProductFiltered.Item(AV71GXV1)).gxTpr_Retailprice, 18, 2, ".", "")),StringUtil.LTrim( ((edtavCtlretailprice_Enabled!=0) ? context.localUtil.Format( ((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV49SDTProductFiltered.Item(AV71GXV1)).gxTpr_Retailprice, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV49SDTProductFiltered.Item(AV71GXV1)).gxTpr_Retailprice, "ZZZZZZZZZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlretailprice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlretailprice_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( AllproductsfilteredContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsfilteredRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlwholesaleprice_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV49SDTProductFiltered.Item(AV71GXV1)).gxTpr_Wholesaleprice, 18, 2, ".", "")),StringUtil.LTrim( ((edtavCtlwholesaleprice_Enabled!=0) ? context.localUtil.Format( ((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV49SDTProductFiltered.Item(AV71GXV1)).gxTpr_Wholesaleprice, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV49SDTProductFiltered.Item(AV71GXV1)).gxTpr_Wholesaleprice, "ZZZZZZZZZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlwholesaleprice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlwholesaleprice_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( AllproductsfilteredContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsfilteredRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlminiumquantitywholesale_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV49SDTProductFiltered.Item(AV71GXV1)).gxTpr_Miniumquantitywholesale), 4, 0, ".", "")),StringUtil.LTrim( ((edtavCtlminiumquantitywholesale_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV49SDTProductFiltered.Item(AV71GXV1)).gxTpr_Miniumquantitywholesale), "ZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV49SDTProductFiltered.Item(AV71GXV1)).gxTpr_Miniumquantitywholesale), "ZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlminiumquantitywholesale_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlminiumquantitywholesale_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)35,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes1T2( ) ;
            AllproductsfilteredContainer.AddRow(AllproductsfilteredRow);
            nGXsfl_35_idx = ((subAllproductsfiltered_Islastpage==1)&&(nGXsfl_35_idx+1>subAllproductsfiltered_fnc_Recordsperpage( )) ? 1 : nGXsfl_35_idx+1);
            sGXsfl_35_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_35_idx), 4, 0), 4, "0");
            SubsflControlProps_352( ) ;
         }
         /* End function sendrow_352 */
      }

      protected void SubsflControlProps_794( )
      {
         edtavRemove_Internalname = "vREMOVE_"+sGXsfl_79_idx;
         edtavCtlname1_Internalname = "CTLNAME1_"+sGXsfl_79_idx;
         edtavCtlproductminiumquantitywholesale_Internalname = "CTLPRODUCTMINIUMQUANTITYWHOLESALE_"+sGXsfl_79_idx;
         edtavCtlstock_Internalname = "CTLSTOCK_"+sGXsfl_79_idx;
         edtavCtlunitprice1_Internalname = "CTLUNITPRICE1_"+sGXsfl_79_idx;
         edtavCtlquantity1_Internalname = "CTLQUANTITY1_"+sGXsfl_79_idx;
         edtavCtlsubtotal_Internalname = "CTLSUBTOTAL_"+sGXsfl_79_idx;
      }

      protected void SubsflControlProps_fel_794( )
      {
         edtavRemove_Internalname = "vREMOVE_"+sGXsfl_79_fel_idx;
         edtavCtlname1_Internalname = "CTLNAME1_"+sGXsfl_79_fel_idx;
         edtavCtlproductminiumquantitywholesale_Internalname = "CTLPRODUCTMINIUMQUANTITYWHOLESALE_"+sGXsfl_79_fel_idx;
         edtavCtlstock_Internalname = "CTLSTOCK_"+sGXsfl_79_fel_idx;
         edtavCtlunitprice1_Internalname = "CTLUNITPRICE1_"+sGXsfl_79_fel_idx;
         edtavCtlquantity1_Internalname = "CTLQUANTITY1_"+sGXsfl_79_fel_idx;
         edtavCtlsubtotal_Internalname = "CTLSUBTOTAL_"+sGXsfl_79_fel_idx;
      }

      protected void sendrow_794( )
      {
         SubsflControlProps_794( ) ;
         WB1T0( ) ;
         CarproductsRow = GXWebRow.GetNew(context,CarproductsContainer);
         if ( subCarproducts_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subCarproducts_Backstyle = 0;
            if ( StringUtil.StrCmp(subCarproducts_Class, "") != 0 )
            {
               subCarproducts_Linesclass = subCarproducts_Class+"Odd";
            }
         }
         else if ( subCarproducts_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subCarproducts_Backstyle = 0;
            subCarproducts_Backcolor = subCarproducts_Allbackcolor;
            if ( StringUtil.StrCmp(subCarproducts_Class, "") != 0 )
            {
               subCarproducts_Linesclass = subCarproducts_Class+"Uniform";
            }
         }
         else if ( subCarproducts_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subCarproducts_Backstyle = 1;
            if ( StringUtil.StrCmp(subCarproducts_Class, "") != 0 )
            {
               subCarproducts_Linesclass = subCarproducts_Class+"Odd";
            }
            subCarproducts_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subCarproducts_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subCarproducts_Backstyle = 1;
            subCarproducts_Backcolor = (int)(0xFFFFFF);
            if ( StringUtil.StrCmp(subCarproducts_Class, "") != 0 )
            {
               subCarproducts_Linesclass = subCarproducts_Class+"Odd";
            }
         }
         /* Start of Columns property logic. */
         CarproductsRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)subCarproducts_Linesclass,(string)""});
         CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CarproductsRow.AddRenderProperties(CarproductsColumn);
         CarproductsRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CarproductsRow.AddRenderProperties(CarproductsColumn);
         /* Div Control */
         CarproductsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divGrid1table_Internalname+"_"+sGXsfl_79_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CarproductsRow.AddRenderProperties(CarproductsColumn);
         /* Div Control */
         CarproductsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CarproductsRow.AddRenderProperties(CarproductsColumn);
         /* Div Control */
         CarproductsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CarproductsRow.AddRenderProperties(CarproductsColumn);
         /* Div Control */
         CarproductsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CarproductsRow.AddRenderProperties(CarproductsColumn);
         /* Attribute/Variable Label */
         CarproductsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"Remove",(string)"col-sm-3 ImageLabel",(short)0,(bool)true,(string)""});
         CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CarproductsRow.AddRenderProperties(CarproductsColumn);
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavRemove_Enabled!=0)&&(edtavRemove_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 86,'',false,'',79)\"" : " ");
         ClassString = "Image" + " " + ((StringUtil.StrCmp(edtavRemove_gximage, "")==0) ? "" : "GX_Image_"+edtavRemove_gximage+"_Class");
         StyleString = "";
         AV44Remove_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV44Remove))&&String.IsNullOrEmpty(StringUtil.RTrim( AV93Remove_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV44Remove)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV44Remove)) ? AV93Remove_GXI : context.PathToRelativeUrl( AV44Remove));
         CarproductsRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavRemove_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)1,(short)1,(string)"Remove Product",(string)"Remove Product",(short)0,(short)-1,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)5,(string)edtavRemove_Jsonclick,"'"+""+"'"+",false,"+"'"+"EVREMOVE.CLICK."+sGXsfl_79_idx+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV44Remove_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CarproductsRow.AddRenderProperties(CarproductsColumn);
         CarproductsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CarproductsRow.AddRenderProperties(CarproductsColumn);
         CarproductsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CarproductsRow.AddRenderProperties(CarproductsColumn);
         /* Div Control */
         CarproductsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CarproductsRow.AddRenderProperties(CarproductsColumn);
         /* Div Control */
         CarproductsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CarproductsRow.AddRenderProperties(CarproductsColumn);
         /* Attribute/Variable Label */
         CarproductsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname1_Internalname,(string)"Name",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CarproductsRow.AddRenderProperties(CarproductsColumn);
         /* Single line edit */
         ROClassString = "Attribute";
         CarproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname1_Internalname,((SdtSDTCarProducts_SDTCarProductsItem)AV24Car.Item(AV79GXV9)).gxTpr_Name,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlname1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlname1_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)79,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CarproductsRow.AddRenderProperties(CarproductsColumn);
         CarproductsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CarproductsRow.AddRenderProperties(CarproductsColumn);
         CarproductsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CarproductsRow.AddRenderProperties(CarproductsColumn);
         /* Div Control */
         CarproductsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CarproductsRow.AddRenderProperties(CarproductsColumn);
         /* Div Control */
         CarproductsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CarproductsRow.AddRenderProperties(CarproductsColumn);
         /* Attribute/Variable Label */
         CarproductsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlproductminiumquantitywholesale_Internalname,(string)"Product Minium Quantity Wholesale",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CarproductsRow.AddRenderProperties(CarproductsColumn);
         /* Single line edit */
         ROClassString = "Attribute";
         CarproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlproductminiumquantitywholesale_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV24Car.Item(AV79GXV9)).gxTpr_Productminiumquantitywholesale), 4, 0, ".", "")),StringUtil.LTrim( ((edtavCtlproductminiumquantitywholesale_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV24Car.Item(AV79GXV9)).gxTpr_Productminiumquantitywholesale), "ZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV24Car.Item(AV79GXV9)).gxTpr_Productminiumquantitywholesale), "ZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlproductminiumquantitywholesale_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlproductminiumquantitywholesale_Enabled,(short)0,(string)"text",(string)"1",(short)4,(string)"chr",(short)1,(string)"row",(short)4,(short)0,(short)0,(short)79,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CarproductsRow.AddRenderProperties(CarproductsColumn);
         CarproductsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CarproductsRow.AddRenderProperties(CarproductsColumn);
         CarproductsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CarproductsRow.AddRenderProperties(CarproductsColumn);
         /* Div Control */
         CarproductsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CarproductsRow.AddRenderProperties(CarproductsColumn);
         /* Div Control */
         CarproductsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CarproductsRow.AddRenderProperties(CarproductsColumn);
         /* Attribute/Variable Label */
         CarproductsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlstock_Internalname,(string)"Stock",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CarproductsRow.AddRenderProperties(CarproductsColumn);
         /* Single line edit */
         ROClassString = "Attribute";
         CarproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlstock_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV24Car.Item(AV79GXV9)).gxTpr_Stock), 6, 0, ".", "")),StringUtil.LTrim( ((edtavCtlstock_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV24Car.Item(AV79GXV9)).gxTpr_Stock), "ZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV24Car.Item(AV79GXV9)).gxTpr_Stock), "ZZZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlstock_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlstock_Enabled,(short)0,(string)"text",(string)"1",(short)6,(string)"chr",(short)1,(string)"row",(short)6,(short)0,(short)0,(short)79,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CarproductsRow.AddRenderProperties(CarproductsColumn);
         CarproductsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CarproductsRow.AddRenderProperties(CarproductsColumn);
         CarproductsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CarproductsRow.AddRenderProperties(CarproductsColumn);
         /* Div Control */
         CarproductsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CarproductsRow.AddRenderProperties(CarproductsColumn);
         /* Div Control */
         CarproductsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CarproductsRow.AddRenderProperties(CarproductsColumn);
         /* Attribute/Variable Label */
         CarproductsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlunitprice1_Internalname,(string)"Unit Price",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CarproductsRow.AddRenderProperties(CarproductsColumn);
         /* Single line edit */
         ROClassString = "Attribute";
         CarproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlunitprice1_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTCarProducts_SDTCarProductsItem)AV24Car.Item(AV79GXV9)).gxTpr_Unitprice, 18, 2, ".", "")),StringUtil.LTrim( ((edtavCtlunitprice1_Enabled!=0) ? context.localUtil.Format( ((SdtSDTCarProducts_SDTCarProductsItem)AV24Car.Item(AV79GXV9)).gxTpr_Unitprice, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTCarProducts_SDTCarProductsItem)AV24Car.Item(AV79GXV9)).gxTpr_Unitprice, "ZZZZZZZZZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlunitprice1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlunitprice1_Enabled,(short)0,(string)"text",(string)"",(short)18,(string)"chr",(short)1,(string)"row",(short)18,(short)0,(short)0,(short)79,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CarproductsRow.AddRenderProperties(CarproductsColumn);
         CarproductsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CarproductsRow.AddRenderProperties(CarproductsColumn);
         CarproductsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CarproductsRow.AddRenderProperties(CarproductsColumn);
         /* Div Control */
         CarproductsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CarproductsRow.AddRenderProperties(CarproductsColumn);
         /* Div Control */
         CarproductsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CarproductsRow.AddRenderProperties(CarproductsColumn);
         /* Attribute/Variable Label */
         CarproductsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlquantity1_Internalname,(string)"Quantity",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CarproductsRow.AddRenderProperties(CarproductsColumn);
         /* Single line edit */
         TempTags = " " + ((edtavCtlquantity1_Enabled!=0)&&(edtavCtlquantity1_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 101,'',false,'"+sGXsfl_79_idx+"',79)\"" : " ");
         ROClassString = "Attribute";
         CarproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlquantity1_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV24Car.Item(AV79GXV9)).gxTpr_Quantity), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV24Car.Item(AV79GXV9)).gxTpr_Quantity), "ZZZZZ9"))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+((edtavCtlquantity1_Enabled!=0)&&(edtavCtlquantity1_Visible!=0) ? " onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,101);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlquantity1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)1,(short)0,(string)"text",(string)"1",(short)6,(string)"chr",(short)1,(string)"row",(short)6,(short)0,(short)0,(short)79,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CarproductsRow.AddRenderProperties(CarproductsColumn);
         CarproductsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CarproductsRow.AddRenderProperties(CarproductsColumn);
         CarproductsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CarproductsRow.AddRenderProperties(CarproductsColumn);
         /* Div Control */
         CarproductsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CarproductsRow.AddRenderProperties(CarproductsColumn);
         /* Div Control */
         CarproductsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CarproductsRow.AddRenderProperties(CarproductsColumn);
         /* Attribute/Variable Label */
         CarproductsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsubtotal_Internalname,(string)"Subtotal",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CarproductsRow.AddRenderProperties(CarproductsColumn);
         /* Single line edit */
         ROClassString = "Attribute";
         CarproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsubtotal_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTCarProducts_SDTCarProductsItem)AV24Car.Item(AV79GXV9)).gxTpr_Subtotal, 18, 2, ".", "")),StringUtil.LTrim( ((edtavCtlsubtotal_Enabled!=0) ? context.localUtil.Format( ((SdtSDTCarProducts_SDTCarProductsItem)AV24Car.Item(AV79GXV9)).gxTpr_Subtotal, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTCarProducts_SDTCarProductsItem)AV24Car.Item(AV79GXV9)).gxTpr_Subtotal, "ZZZZZZZZZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlsubtotal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlsubtotal_Enabled,(short)0,(string)"text",(string)"",(short)18,(string)"chr",(short)1,(string)"row",(short)18,(short)0,(short)0,(short)79,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CarproductsRow.AddRenderProperties(CarproductsColumn);
         CarproductsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CarproductsRow.AddRenderProperties(CarproductsColumn);
         CarproductsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CarproductsRow.AddRenderProperties(CarproductsColumn);
         CarproductsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CarproductsRow.AddRenderProperties(CarproductsColumn);
         CarproductsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         CarproductsRow.AddRenderProperties(CarproductsColumn);
         if ( CarproductsContainer.GetWrapped() == 1 )
         {
            CarproductsContainer.CloseTag("cell");
         }
         if ( CarproductsContainer.GetWrapped() == 1 )
         {
            CarproductsContainer.CloseTag("row");
         }
         send_integrity_lvl_hashes1T4( ) ;
         /* End of Columns property logic. */
         CarproductsContainer.AddRow(CarproductsRow);
         nGXsfl_79_idx = ((subCarproducts_Islastpage==1)&&(nGXsfl_79_idx+1>subCarproducts_fnc_Recordsperpage( )) ? 1 : nGXsfl_79_idx+1);
         sGXsfl_79_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_79_idx), 4, 0), 4, "0");
         SubsflControlProps_794( ) ;
         /* End function sendrow_794 */
      }

      protected void SubsflControlProps_1393( )
      {
         edtavPaymentmethodremove_Internalname = "vPAYMENTMETHODREMOVE_"+sGXsfl_139_idx;
         edtavCtlpaymentmethodid_Internalname = "CTLPAYMENTMETHODID_"+sGXsfl_139_idx;
         edtavCtlpaymentmethoddescription_Internalname = "CTLPAYMENTMETHODDESCRIPTION_"+sGXsfl_139_idx;
         edtavCtlinvoicepaymentmethodimport_Internalname = "CTLINVOICEPAYMENTMETHODIMPORT_"+sGXsfl_139_idx;
         edtavCtlinvoicepaymentmethoddiscountimport_Internalname = "CTLINVOICEPAYMENTMETHODDISCOUNTIMPORT_"+sGXsfl_139_idx;
         edtavCtlinvoicepaymentmethodrechargeimport_Internalname = "CTLINVOICEPAYMENTMETHODRECHARGEIMPORT_"+sGXsfl_139_idx;
      }

      protected void SubsflControlProps_fel_1393( )
      {
         edtavPaymentmethodremove_Internalname = "vPAYMENTMETHODREMOVE_"+sGXsfl_139_fel_idx;
         edtavCtlpaymentmethodid_Internalname = "CTLPAYMENTMETHODID_"+sGXsfl_139_fel_idx;
         edtavCtlpaymentmethoddescription_Internalname = "CTLPAYMENTMETHODDESCRIPTION_"+sGXsfl_139_fel_idx;
         edtavCtlinvoicepaymentmethodimport_Internalname = "CTLINVOICEPAYMENTMETHODIMPORT_"+sGXsfl_139_fel_idx;
         edtavCtlinvoicepaymentmethoddiscountimport_Internalname = "CTLINVOICEPAYMENTMETHODDISCOUNTIMPORT_"+sGXsfl_139_fel_idx;
         edtavCtlinvoicepaymentmethodrechargeimport_Internalname = "CTLINVOICEPAYMENTMETHODRECHARGEIMPORT_"+sGXsfl_139_fel_idx;
      }

      protected void sendrow_1393( )
      {
         SubsflControlProps_1393( ) ;
         WB1T0( ) ;
         GridinvoiceaddpaymentmethodRow = GXWebRow.GetNew(context,GridinvoiceaddpaymentmethodContainer);
         if ( subGridinvoiceaddpaymentmethod_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridinvoiceaddpaymentmethod_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridinvoiceaddpaymentmethod_Class, "") != 0 )
            {
               subGridinvoiceaddpaymentmethod_Linesclass = subGridinvoiceaddpaymentmethod_Class+"Odd";
            }
         }
         else if ( subGridinvoiceaddpaymentmethod_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridinvoiceaddpaymentmethod_Backstyle = 0;
            subGridinvoiceaddpaymentmethod_Backcolor = subGridinvoiceaddpaymentmethod_Allbackcolor;
            if ( StringUtil.StrCmp(subGridinvoiceaddpaymentmethod_Class, "") != 0 )
            {
               subGridinvoiceaddpaymentmethod_Linesclass = subGridinvoiceaddpaymentmethod_Class+"Uniform";
            }
         }
         else if ( subGridinvoiceaddpaymentmethod_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridinvoiceaddpaymentmethod_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridinvoiceaddpaymentmethod_Class, "") != 0 )
            {
               subGridinvoiceaddpaymentmethod_Linesclass = subGridinvoiceaddpaymentmethod_Class+"Odd";
            }
            subGridinvoiceaddpaymentmethod_Backcolor = (int)(0x0);
         }
         else if ( subGridinvoiceaddpaymentmethod_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridinvoiceaddpaymentmethod_Backstyle = 1;
            if ( ((int)((nGXsfl_139_idx) % (2))) == 0 )
            {
               subGridinvoiceaddpaymentmethod_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridinvoiceaddpaymentmethod_Class, "") != 0 )
               {
                  subGridinvoiceaddpaymentmethod_Linesclass = subGridinvoiceaddpaymentmethod_Class+"Even";
               }
            }
            else
            {
               subGridinvoiceaddpaymentmethod_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridinvoiceaddpaymentmethod_Class, "") != 0 )
               {
                  subGridinvoiceaddpaymentmethod_Linesclass = subGridinvoiceaddpaymentmethod_Class+"Odd";
               }
            }
         }
         if ( GridinvoiceaddpaymentmethodContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr ") ;
            context.WriteHtmlText( " class=\""+"PromptGrid"+"\" style=\""+""+"\"") ;
            context.WriteHtmlText( " gxrow=\""+sGXsfl_139_idx+"\">") ;
         }
         /* Subfile cell */
         if ( GridinvoiceaddpaymentmethodContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavPaymentmethodremove_Enabled!=0)&&(edtavPaymentmethodremove_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 140,'',false,'',139)\"" : " ");
         ClassString = "Image" + " " + ((StringUtil.StrCmp(edtavPaymentmethodremove_gximage, "")==0) ? "" : "GX_Image_"+edtavPaymentmethodremove_gximage+"_Class");
         StyleString = "";
         AV61PaymentMethodRemove_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV61PaymentMethodRemove))&&String.IsNullOrEmpty(StringUtil.RTrim( AV96Paymentmethodremove_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV61PaymentMethodRemove)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV61PaymentMethodRemove)) ? AV96Paymentmethodremove_GXI : context.PathToRelativeUrl( AV61PaymentMethodRemove));
         GridinvoiceaddpaymentmethodRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavPaymentmethodremove_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"Remove Product",(string)"Remove Product",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)5,(string)edtavPaymentmethodremove_Jsonclick,"'"+""+"'"+",false,"+"'"+"EVPAYMENTMETHODREMOVE.CLICK."+sGXsfl_139_idx+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV61PaymentMethodRemove_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         if ( GridinvoiceaddpaymentmethodContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridinvoiceaddpaymentmethodRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlpaymentmethodid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV56SDTInvoiceAddPaymentMethod.Item(AV86GXV16)).gxTpr_Paymentmethodid), 6, 0, ".", "")),StringUtil.LTrim( ((edtavCtlpaymentmethodid_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV56SDTInvoiceAddPaymentMethod.Item(AV86GXV16)).gxTpr_Paymentmethodid), "ZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV56SDTInvoiceAddPaymentMethod.Item(AV86GXV16)).gxTpr_Paymentmethodid), "ZZZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlpaymentmethodid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(int)edtavCtlpaymentmethodid_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)139,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( GridinvoiceaddpaymentmethodContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridinvoiceaddpaymentmethodRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlpaymentmethoddescription_Internalname,((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV56SDTInvoiceAddPaymentMethod.Item(AV86GXV16)).gxTpr_Paymentmethoddescription,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlpaymentmethoddescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlpaymentmethoddescription_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)139,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridinvoiceaddpaymentmethodContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridinvoiceaddpaymentmethodRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlinvoicepaymentmethodimport_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV56SDTInvoiceAddPaymentMethod.Item(AV86GXV16)).gxTpr_Invoicepaymentmethodimport, 18, 2, ".", "")),StringUtil.LTrim( ((edtavCtlinvoicepaymentmethodimport_Enabled!=0) ? context.localUtil.Format( ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV56SDTInvoiceAddPaymentMethod.Item(AV86GXV16)).gxTpr_Invoicepaymentmethodimport, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV56SDTInvoiceAddPaymentMethod.Item(AV86GXV16)).gxTpr_Invoicepaymentmethodimport, "ZZZZZZZZZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlinvoicepaymentmethodimport_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlinvoicepaymentmethodimport_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)139,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( GridinvoiceaddpaymentmethodContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridinvoiceaddpaymentmethodRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlinvoicepaymentmethoddiscountimport_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV56SDTInvoiceAddPaymentMethod.Item(AV86GXV16)).gxTpr_Invoicepaymentmethoddiscountimport, 18, 2, ".", "")),StringUtil.LTrim( ((edtavCtlinvoicepaymentmethoddiscountimport_Enabled!=0) ? context.localUtil.Format( ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV56SDTInvoiceAddPaymentMethod.Item(AV86GXV16)).gxTpr_Invoicepaymentmethoddiscountimport, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV56SDTInvoiceAddPaymentMethod.Item(AV86GXV16)).gxTpr_Invoicepaymentmethoddiscountimport, "ZZZZZZZZZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlinvoicepaymentmethoddiscountimport_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlinvoicepaymentmethoddiscountimport_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)139,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( GridinvoiceaddpaymentmethodContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         GridinvoiceaddpaymentmethodRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlinvoicepaymentmethodrechargeimport_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV56SDTInvoiceAddPaymentMethod.Item(AV86GXV16)).gxTpr_Invoicepaymentmethodrechargeimport, 18, 2, ".", "")),StringUtil.LTrim( ((edtavCtlinvoicepaymentmethodrechargeimport_Enabled!=0) ? context.localUtil.Format( ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV56SDTInvoiceAddPaymentMethod.Item(AV86GXV16)).gxTpr_Invoicepaymentmethodrechargeimport, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem)AV56SDTInvoiceAddPaymentMethod.Item(AV86GXV16)).gxTpr_Invoicepaymentmethodrechargeimport, "ZZZZZZZZZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlinvoicepaymentmethodrechargeimport_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlinvoicepaymentmethodrechargeimport_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)139,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         send_integrity_lvl_hashes1T3( ) ;
         GridinvoiceaddpaymentmethodContainer.AddRow(GridinvoiceaddpaymentmethodRow);
         nGXsfl_139_idx = ((subGridinvoiceaddpaymentmethod_Islastpage==1)&&(nGXsfl_139_idx+1>subGridinvoiceaddpaymentmethod_fnc_Recordsperpage( )) ? 1 : nGXsfl_139_idx+1);
         sGXsfl_139_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_139_idx), 4, 0), 4, "0");
         SubsflControlProps_1393( ) ;
         /* End function sendrow_1393 */
      }

      protected void init_web_controls( )
      {
         dynavBrand.Name = "vBRAND";
         dynavBrand.WebTags = "";
         dynavSector.Name = "vSECTOR";
         dynavSector.WebTags = "";
         dynavPaymentmethodid.Name = "vPAYMENTMETHODID";
         dynavPaymentmethodid.WebTags = "";
         /* End function init_web_controls */
      }

      protected void StartGridControl35( )
      {
         if ( AllproductsfilteredContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"AllproductsfilteredContainer"+"DivS\" data-gxgridid=\"35\">") ;
            sStyleString = "";
            if ( subAllproductsfiltered_Collapsed != 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, subAllproductsfiltered_Internalname, subAllproductsfiltered_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subAllproductsfiltered_Backcolorstyle == 0 )
            {
               subAllproductsfiltered_Titlebackstyle = 0;
               if ( StringUtil.Len( subAllproductsfiltered_Class) > 0 )
               {
                  subAllproductsfiltered_Linesclass = subAllproductsfiltered_Class+"Title";
               }
            }
            else
            {
               subAllproductsfiltered_Titlebackstyle = 1;
               if ( subAllproductsfiltered_Backcolorstyle == 1 )
               {
                  subAllproductsfiltered_Titlebackcolor = subAllproductsfiltered_Allbackcolor;
                  if ( StringUtil.Len( subAllproductsfiltered_Class) > 0 )
                  {
                     subAllproductsfiltered_Linesclass = subAllproductsfiltered_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subAllproductsfiltered_Class) > 0 )
                  {
                     subAllproductsfiltered_Linesclass = subAllproductsfiltered_Class+"Title";
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
            context.SendWebValue( "Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Stock") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Retail Price") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Wholesale Price") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Min. Qty. Wholesale") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            AllproductsfilteredContainer.AddObjectProperty("GridName", "Allproductsfiltered");
         }
         else
         {
            AllproductsfilteredContainer.AddObjectProperty("GridName", "Allproductsfiltered");
            AllproductsfilteredContainer.AddObjectProperty("Header", subAllproductsfiltered_Header);
            AllproductsfilteredContainer.AddObjectProperty("Class", "PromptGrid");
            AllproductsfilteredContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            AllproductsfilteredContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            AllproductsfilteredContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAllproductsfiltered_Backcolorstyle), 1, 0, ".", "")));
            AllproductsfilteredContainer.AddObjectProperty("CmpContext", "");
            AllproductsfilteredContainer.AddObjectProperty("InMasterPage", "false");
            AllproductsfilteredColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsfilteredColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlid_Enabled), 5, 0, ".", "")));
            AllproductsfilteredContainer.AddColumnProperties(AllproductsfilteredColumn);
            AllproductsfilteredColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsfilteredColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlcode_Enabled), 5, 0, ".", "")));
            AllproductsfilteredContainer.AddColumnProperties(AllproductsfilteredColumn);
            AllproductsfilteredColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsfilteredColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlname_Enabled), 5, 0, ".", "")));
            AllproductsfilteredContainer.AddColumnProperties(AllproductsfilteredColumn);
            AllproductsfilteredColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsfilteredColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlstock1_Enabled), 5, 0, ".", "")));
            AllproductsfilteredContainer.AddColumnProperties(AllproductsfilteredColumn);
            AllproductsfilteredColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsfilteredColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlretailprice_Enabled), 5, 0, ".", "")));
            AllproductsfilteredContainer.AddColumnProperties(AllproductsfilteredColumn);
            AllproductsfilteredColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsfilteredColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlwholesaleprice_Enabled), 5, 0, ".", "")));
            AllproductsfilteredContainer.AddColumnProperties(AllproductsfilteredColumn);
            AllproductsfilteredColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsfilteredColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlminiumquantitywholesale_Enabled), 5, 0, ".", "")));
            AllproductsfilteredContainer.AddColumnProperties(AllproductsfilteredColumn);
            AllproductsfilteredContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAllproductsfiltered_Selectedindex), 4, 0, ".", "")));
            AllproductsfilteredContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAllproductsfiltered_Allowselection), 1, 0, ".", "")));
            AllproductsfilteredContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAllproductsfiltered_Selectioncolor), 9, 0, ".", "")));
            AllproductsfilteredContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAllproductsfiltered_Allowhovering), 1, 0, ".", "")));
            AllproductsfilteredContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAllproductsfiltered_Hoveringcolor), 9, 0, ".", "")));
            AllproductsfilteredContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAllproductsfiltered_Allowcollapsing), 1, 0, ".", "")));
            AllproductsfilteredContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAllproductsfiltered_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void StartGridControl79( )
      {
         if ( CarproductsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"CarproductsContainer"+"DivS\" data-gxgridid=\"79\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subCarproducts_Internalname, subCarproducts_Internalname, "", "PromptGrid", 0, "", "", 1, 1, sStyleString, "", "", 0);
            CarproductsContainer.AddObjectProperty("GridName", "Carproducts");
         }
         else
         {
            CarproductsContainer.AddObjectProperty("GridName", "Carproducts");
            CarproductsContainer.AddObjectProperty("Header", subCarproducts_Header);
            CarproductsContainer.AddObjectProperty("Class", StringUtil.RTrim( "PromptGrid"));
            CarproductsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            CarproductsContainer.AddObjectProperty("Class", "PromptGrid");
            CarproductsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            CarproductsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            CarproductsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subCarproducts_Backcolorstyle), 1, 0, ".", "")));
            CarproductsContainer.AddObjectProperty("CmpContext", "");
            CarproductsContainer.AddObjectProperty("InMasterPage", "false");
            CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CarproductsContainer.AddColumnProperties(CarproductsColumn);
            CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CarproductsContainer.AddColumnProperties(CarproductsColumn);
            CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CarproductsContainer.AddColumnProperties(CarproductsColumn);
            CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CarproductsContainer.AddColumnProperties(CarproductsColumn);
            CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CarproductsContainer.AddColumnProperties(CarproductsColumn);
            CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CarproductsContainer.AddColumnProperties(CarproductsColumn);
            CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CarproductsColumn.AddObjectProperty("Value", context.convertURL( AV44Remove));
            CarproductsContainer.AddColumnProperties(CarproductsColumn);
            CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CarproductsContainer.AddColumnProperties(CarproductsColumn);
            CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CarproductsContainer.AddColumnProperties(CarproductsColumn);
            CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CarproductsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlname1_Enabled), 5, 0, ".", "")));
            CarproductsContainer.AddColumnProperties(CarproductsColumn);
            CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CarproductsContainer.AddColumnProperties(CarproductsColumn);
            CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CarproductsContainer.AddColumnProperties(CarproductsColumn);
            CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CarproductsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlproductminiumquantitywholesale_Enabled), 5, 0, ".", "")));
            CarproductsContainer.AddColumnProperties(CarproductsColumn);
            CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CarproductsContainer.AddColumnProperties(CarproductsColumn);
            CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CarproductsContainer.AddColumnProperties(CarproductsColumn);
            CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CarproductsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlstock_Enabled), 5, 0, ".", "")));
            CarproductsContainer.AddColumnProperties(CarproductsColumn);
            CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CarproductsContainer.AddColumnProperties(CarproductsColumn);
            CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CarproductsContainer.AddColumnProperties(CarproductsColumn);
            CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CarproductsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlunitprice1_Enabled), 5, 0, ".", "")));
            CarproductsContainer.AddColumnProperties(CarproductsColumn);
            CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CarproductsContainer.AddColumnProperties(CarproductsColumn);
            CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CarproductsContainer.AddColumnProperties(CarproductsColumn);
            CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CarproductsContainer.AddColumnProperties(CarproductsColumn);
            CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CarproductsContainer.AddColumnProperties(CarproductsColumn);
            CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CarproductsContainer.AddColumnProperties(CarproductsColumn);
            CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CarproductsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlsubtotal_Enabled), 5, 0, ".", "")));
            CarproductsContainer.AddColumnProperties(CarproductsColumn);
            CarproductsContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subCarproducts_Selectedindex), 4, 0, ".", "")));
            CarproductsContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subCarproducts_Allowselection), 1, 0, ".", "")));
            CarproductsContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subCarproducts_Selectioncolor), 9, 0, ".", "")));
            CarproductsContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subCarproducts_Allowhovering), 1, 0, ".", "")));
            CarproductsContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subCarproducts_Hoveringcolor), 9, 0, ".", "")));
            CarproductsContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subCarproducts_Allowcollapsing), 1, 0, ".", "")));
            CarproductsContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subCarproducts_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void StartGridControl139( )
      {
         if ( GridinvoiceaddpaymentmethodContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridinvoiceaddpaymentmethodContainer"+"DivS\" data-gxgridid=\"139\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridinvoiceaddpaymentmethod_Internalname, subGridinvoiceaddpaymentmethod_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGridinvoiceaddpaymentmethod_Backcolorstyle == 0 )
            {
               subGridinvoiceaddpaymentmethod_Titlebackstyle = 0;
               if ( StringUtil.Len( subGridinvoiceaddpaymentmethod_Class) > 0 )
               {
                  subGridinvoiceaddpaymentmethod_Linesclass = subGridinvoiceaddpaymentmethod_Class+"Title";
               }
            }
            else
            {
               subGridinvoiceaddpaymentmethod_Titlebackstyle = 1;
               if ( subGridinvoiceaddpaymentmethod_Backcolorstyle == 1 )
               {
                  subGridinvoiceaddpaymentmethod_Titlebackcolor = subGridinvoiceaddpaymentmethod_Allbackcolor;
                  if ( StringUtil.Len( subGridinvoiceaddpaymentmethod_Class) > 0 )
                  {
                     subGridinvoiceaddpaymentmethod_Linesclass = subGridinvoiceaddpaymentmethod_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGridinvoiceaddpaymentmethod_Class) > 0 )
                  {
                     subGridinvoiceaddpaymentmethod_Linesclass = subGridinvoiceaddpaymentmethod_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Image"+" "+((StringUtil.StrCmp(edtavPaymentmethodremove_gximage, "")==0) ? "" : "GX_Image_"+edtavPaymentmethodremove_gximage+"_Class")+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Payment Method Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Method") ;
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
            GridinvoiceaddpaymentmethodContainer.AddObjectProperty("GridName", "Gridinvoiceaddpaymentmethod");
         }
         else
         {
            GridinvoiceaddpaymentmethodContainer.AddObjectProperty("GridName", "Gridinvoiceaddpaymentmethod");
            GridinvoiceaddpaymentmethodContainer.AddObjectProperty("Header", subGridinvoiceaddpaymentmethod_Header);
            GridinvoiceaddpaymentmethodContainer.AddObjectProperty("Class", "PromptGrid");
            GridinvoiceaddpaymentmethodContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridinvoiceaddpaymentmethodContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridinvoiceaddpaymentmethodContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoiceaddpaymentmethod_Backcolorstyle), 1, 0, ".", "")));
            GridinvoiceaddpaymentmethodContainer.AddObjectProperty("CmpContext", "");
            GridinvoiceaddpaymentmethodContainer.AddObjectProperty("InMasterPage", "false");
            GridinvoiceaddpaymentmethodColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridinvoiceaddpaymentmethodColumn.AddObjectProperty("Value", context.convertURL( AV61PaymentMethodRemove));
            GridinvoiceaddpaymentmethodContainer.AddColumnProperties(GridinvoiceaddpaymentmethodColumn);
            GridinvoiceaddpaymentmethodColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridinvoiceaddpaymentmethodColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlpaymentmethodid_Enabled), 5, 0, ".", "")));
            GridinvoiceaddpaymentmethodContainer.AddColumnProperties(GridinvoiceaddpaymentmethodColumn);
            GridinvoiceaddpaymentmethodColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridinvoiceaddpaymentmethodColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlpaymentmethoddescription_Enabled), 5, 0, ".", "")));
            GridinvoiceaddpaymentmethodContainer.AddColumnProperties(GridinvoiceaddpaymentmethodColumn);
            GridinvoiceaddpaymentmethodColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridinvoiceaddpaymentmethodColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlinvoicepaymentmethodimport_Enabled), 5, 0, ".", "")));
            GridinvoiceaddpaymentmethodContainer.AddColumnProperties(GridinvoiceaddpaymentmethodColumn);
            GridinvoiceaddpaymentmethodColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridinvoiceaddpaymentmethodColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlinvoicepaymentmethoddiscountimport_Enabled), 5, 0, ".", "")));
            GridinvoiceaddpaymentmethodContainer.AddColumnProperties(GridinvoiceaddpaymentmethodColumn);
            GridinvoiceaddpaymentmethodColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridinvoiceaddpaymentmethodColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlinvoicepaymentmethodrechargeimport_Enabled), 5, 0, ".", "")));
            GridinvoiceaddpaymentmethodContainer.AddColumnProperties(GridinvoiceaddpaymentmethodColumn);
            GridinvoiceaddpaymentmethodContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoiceaddpaymentmethod_Selectedindex), 4, 0, ".", "")));
            GridinvoiceaddpaymentmethodContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoiceaddpaymentmethod_Allowselection), 1, 0, ".", "")));
            GridinvoiceaddpaymentmethodContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoiceaddpaymentmethod_Selectioncolor), 9, 0, ".", "")));
            GridinvoiceaddpaymentmethodContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoiceaddpaymentmethod_Allowhovering), 1, 0, ".", "")));
            GridinvoiceaddpaymentmethodContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoiceaddpaymentmethod_Hoveringcolor), 9, 0, ".", "")));
            GridinvoiceaddpaymentmethodContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoiceaddpaymentmethod_Allowcollapsing), 1, 0, ".", "")));
            GridinvoiceaddpaymentmethodContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoiceaddpaymentmethod_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblTextblock7_Internalname = "TEXTBLOCK7";
         bttSelectall_Internalname = "SELECTALL";
         edtavName_Internalname = "vNAME";
         edtavCode_Internalname = "vCODE";
         dynavBrand_Internalname = "vBRAND";
         dynavSector_Internalname = "vSECTOR";
         edtavCtlid_Internalname = "CTLID";
         edtavCtlcode_Internalname = "CTLCODE";
         edtavCtlname_Internalname = "CTLNAME";
         edtavCtlstock1_Internalname = "CTLSTOCK1";
         edtavCtlretailprice_Internalname = "CTLRETAILPRICE";
         edtavCtlwholesaleprice_Internalname = "CTLWHOLESALEPRICE";
         edtavCtlminiumquantitywholesale_Internalname = "CTLMINIUMQUANTITYWHOLESALE";
         divTable1_Internalname = "TABLE1";
         bttRegistersale_Internalname = "REGISTERSALE";
         edtavTotal_Internalname = "vTOTAL";
         bttClearsale_Internalname = "CLEARSALE";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtavRemove_Internalname = "vREMOVE";
         edtavCtlname1_Internalname = "CTLNAME1";
         edtavCtlproductminiumquantitywholesale_Internalname = "CTLPRODUCTMINIUMQUANTITYWHOLESALE";
         edtavCtlstock_Internalname = "CTLSTOCK";
         edtavCtlunitprice1_Internalname = "CTLUNITPRICE1";
         edtavCtlquantity1_Internalname = "CTLQUANTITY1";
         edtavCtlsubtotal_Internalname = "CTLSUBTOTAL";
         divGrid1table_Internalname = "GRID1TABLE";
         divTablenewsale_Internalname = "TABLENEWSALE";
         bttAddpaymentmethod_Internalname = "ADDPAYMENTMETHOD";
         dynavPaymentmethodid_Internalname = "vPAYMENTMETHODID";
         edtavInvoicepaymentmethodimport_Internalname = "vINVOICEPAYMENTMETHODIMPORT";
         edtavRemainingamount_Internalname = "vREMAININGAMOUNT";
         edtavAmountreceivable_Internalname = "vAMOUNTRECEIVABLE";
         divTable3_Internalname = "TABLE3";
         edtavPaymentmethodremove_Internalname = "vPAYMENTMETHODREMOVE";
         edtavCtlpaymentmethodid_Internalname = "CTLPAYMENTMETHODID";
         edtavCtlpaymentmethoddescription_Internalname = "CTLPAYMENTMETHODDESCRIPTION";
         edtavCtlinvoicepaymentmethodimport_Internalname = "CTLINVOICEPAYMENTMETHODIMPORT";
         edtavCtlinvoicepaymentmethoddiscountimport_Internalname = "CTLINVOICEPAYMENTMETHODDISCOUNTIMPORT";
         edtavCtlinvoicepaymentmethodrechargeimport_Internalname = "CTLINVOICEPAYMENTMETHODRECHARGEIMPORT";
         divTable4_Internalname = "TABLE4";
         divTablepaymentmethod_Internalname = "TABLEPAYMENTMETHOD";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subAllproductsfiltered_Internalname = "ALLPRODUCTSFILTERED";
         subCarproducts_Internalname = "CARPRODUCTS";
         subGridinvoiceaddpaymentmethod_Internalname = "GRIDINVOICEADDPAYMENTMETHOD";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("mtaKB", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridinvoiceaddpaymentmethod_Allowcollapsing = 0;
         subGridinvoiceaddpaymentmethod_Allowselection = 0;
         subGridinvoiceaddpaymentmethod_Header = "";
         subCarproducts_Allowcollapsing = 0;
         subAllproductsfiltered_Allowcollapsing = 1;
         subAllproductsfiltered_Allowselection = 0;
         subAllproductsfiltered_Header = "";
         edtavCtlinvoicepaymentmethodrechargeimport_Jsonclick = "";
         edtavCtlinvoicepaymentmethodrechargeimport_Enabled = 0;
         edtavCtlinvoicepaymentmethoddiscountimport_Jsonclick = "";
         edtavCtlinvoicepaymentmethoddiscountimport_Enabled = 0;
         edtavCtlinvoicepaymentmethodimport_Jsonclick = "";
         edtavCtlinvoicepaymentmethodimport_Enabled = 0;
         edtavCtlpaymentmethoddescription_Jsonclick = "";
         edtavCtlpaymentmethoddescription_Enabled = 0;
         edtavCtlpaymentmethodid_Jsonclick = "";
         edtavCtlpaymentmethodid_Enabled = 0;
         edtavPaymentmethodremove_Jsonclick = "";
         edtavPaymentmethodremove_Visible = -1;
         edtavPaymentmethodremove_Enabled = 1;
         subGridinvoiceaddpaymentmethod_Class = "PromptGrid";
         subGridinvoiceaddpaymentmethod_Backcolorstyle = 0;
         edtavCtlsubtotal_Jsonclick = "";
         edtavCtlsubtotal_Enabled = 0;
         edtavCtlquantity1_Jsonclick = "";
         edtavCtlquantity1_Visible = 1;
         edtavCtlquantity1_Enabled = 1;
         edtavCtlunitprice1_Jsonclick = "";
         edtavCtlunitprice1_Enabled = 0;
         edtavCtlstock_Jsonclick = "";
         edtavCtlstock_Enabled = 0;
         edtavCtlproductminiumquantitywholesale_Jsonclick = "";
         edtavCtlproductminiumquantitywholesale_Enabled = 0;
         edtavCtlname1_Jsonclick = "";
         edtavCtlname1_Enabled = 0;
         edtavRemove_Jsonclick = "";
         edtavRemove_Visible = 1;
         edtavRemove_Enabled = 1;
         edtavCtlminiumquantitywholesale_Jsonclick = "";
         edtavCtlminiumquantitywholesale_Enabled = 0;
         edtavCtlwholesaleprice_Jsonclick = "";
         edtavCtlwholesaleprice_Enabled = 0;
         edtavCtlretailprice_Jsonclick = "";
         edtavCtlretailprice_Enabled = 0;
         edtavCtlstock1_Jsonclick = "";
         edtavCtlstock1_Enabled = 0;
         edtavCtlname_Jsonclick = "";
         edtavCtlname_Enabled = 0;
         edtavCtlcode_Jsonclick = "";
         edtavCtlcode_Enabled = 0;
         edtavCtlid_Jsonclick = "";
         edtavCtlid_Enabled = 0;
         subAllproductsfiltered_Class = "PromptGrid";
         subAllproductsfiltered_Backcolorstyle = 0;
         edtavPaymentmethodremove_gximage = "";
         edtavRemove_gximage = "";
         subCarproducts_Backcolorstyle = 0;
         edtavCtlinvoicepaymentmethodrechargeimport_Enabled = -1;
         edtavCtlinvoicepaymentmethoddiscountimport_Enabled = -1;
         edtavCtlinvoicepaymentmethodimport_Enabled = -1;
         edtavCtlpaymentmethoddescription_Enabled = -1;
         edtavCtlpaymentmethodid_Enabled = -1;
         edtavCtlsubtotal_Enabled = -1;
         edtavCtlunitprice1_Enabled = -1;
         edtavCtlstock_Enabled = -1;
         edtavCtlproductminiumquantitywholesale_Enabled = -1;
         edtavCtlname1_Enabled = -1;
         edtavCtlminiumquantitywholesale_Enabled = -1;
         edtavCtlwholesaleprice_Enabled = -1;
         edtavCtlretailprice_Enabled = -1;
         edtavCtlstock1_Enabled = -1;
         edtavCtlname_Enabled = -1;
         edtavCtlcode_Enabled = -1;
         edtavCtlid_Enabled = -1;
         edtavAmountreceivable_Jsonclick = "";
         edtavAmountreceivable_Enabled = 1;
         edtavRemainingamount_Jsonclick = "";
         edtavRemainingamount_Enabled = 1;
         edtavInvoicepaymentmethodimport_Jsonclick = "";
         edtavInvoicepaymentmethodimport_Enabled = 1;
         dynavPaymentmethodid_Jsonclick = "";
         dynavPaymentmethodid.Enabled = 1;
         divTablepaymentmethod_Visible = 1;
         edtavTotal_Jsonclick = "";
         edtavTotal_Enabled = 1;
         edtavTotal_Visible = 1;
         divTablenewsale_Visible = 1;
         dynavSector_Jsonclick = "";
         dynavSector.Enabled = 1;
         dynavBrand_Jsonclick = "";
         dynavBrand.Enabled = 1;
         edtavCode_Jsonclick = "";
         edtavCode_Enabled = 1;
         edtavName_Jsonclick = "";
         edtavName_Enabled = 1;
         bttSelectall_Visible = 1;
         subCarproducts_Class = "PromptGrid";
         subAllproductsfiltered_Collapsed = 0;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "WPRegister Sale";
         subAllproductsfiltered_Rows = 4;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'ALLPRODUCTSFILTERED_nFirstRecordOnPage'},{av:'ALLPRODUCTSFILTERED_nEOF'},{av:'AV49SDTProductFiltered',fld:'vSDTPRODUCTFILTERED',grid:35,pic:''},{av:'nGXsfl_35_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:35},{av:'nRC_GXsfl_35',ctrl:'ALLPRODUCTSFILTERED',prop:'GridRC',grid:35},{av:'AV17Code',fld:'vCODE',pic:''},{av:'AV18Name',fld:'vNAME',pic:''},{av:'AV15Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'GRIDINVOICEADDPAYMENTMETHOD_nFirstRecordOnPage'},{av:'GRIDINVOICEADDPAYMENTMETHOD_nEOF'},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'CARPRODUCTS_nEOF'},{av:'subAllproductsfiltered_Rows',ctrl:'ALLPRODUCTSFILTERED',prop:'Rows'},{av:'AV24Car',fld:'vCAR',grid:79,pic:''},{av:'nGXsfl_79_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:79},{av:'nRC_GXsfl_79',ctrl:'CARPRODUCTS',prop:'GridRC',grid:79},{av:'AV56SDTInvoiceAddPaymentMethod',fld:'vSDTINVOICEADDPAYMENTMETHOD',grid:139,pic:''},{av:'nGXsfl_139_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:139},{av:'nRC_GXsfl_139',ctrl:'GRIDINVOICEADDPAYMENTMETHOD',prop:'GridRC',grid:139},{av:'AV36Total',fld:'vTOTAL',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'dynavBrand'},{av:'AV16Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV45Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'dynavPaymentmethodid'},{av:'AV58PaymentMethodId',fld:'vPAYMENTMETHODID',pic:'ZZZZZ9'},{av:'AV38newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV41newCode',fld:'vNEWCODE',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("CTLNAME.CLICK","{handler:'E231T2',iparms:[{av:'AV49SDTProductFiltered',fld:'vSDTPRODUCTFILTERED',grid:35,pic:''},{av:'nGXsfl_35_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:35},{av:'ALLPRODUCTSFILTERED_nFirstRecordOnPage'},{av:'nRC_GXsfl_35',ctrl:'ALLPRODUCTSFILTERED',prop:'GridRC',grid:35},{av:'AV29SelectedId',fld:'vSELECTEDID',pic:''},{av:'AV42CarAux',fld:'vCARAUX',pic:''},{av:'AV24Car',fld:'vCAR',grid:79,pic:''},{av:'nGXsfl_79_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:79},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'nRC_GXsfl_79',ctrl:'CARPRODUCTS',prop:'GridRC',grid:79},{av:'ALLPRODUCTSFILTERED_nEOF'},{av:'AV17Code',fld:'vCODE',pic:''},{av:'AV18Name',fld:'vNAME',pic:''},{av:'AV15Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'GRIDINVOICEADDPAYMENTMETHOD_nFirstRecordOnPage'},{av:'GRIDINVOICEADDPAYMENTMETHOD_nEOF'},{av:'CARPRODUCTS_nEOF'},{av:'subAllproductsfiltered_Rows',ctrl:'ALLPRODUCTSFILTERED',prop:'Rows'},{av:'AV56SDTInvoiceAddPaymentMethod',fld:'vSDTINVOICEADDPAYMENTMETHOD',grid:139,pic:''},{av:'nGXsfl_139_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:139},{av:'nRC_GXsfl_139',ctrl:'GRIDINVOICEADDPAYMENTMETHOD',prop:'GridRC',grid:139},{av:'AV36Total',fld:'vTOTAL',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'dynavBrand'},{av:'AV16Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV45Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'dynavPaymentmethodid'},{av:'AV58PaymentMethodId',fld:'vPAYMENTMETHODID',pic:'ZZZZZ9'},{av:'AV38newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV41newCode',fld:'vNEWCODE',pic:'',hsh:true}]");
         setEventMetadata("CTLNAME.CLICK",",oparms:[{av:'AV29SelectedId',fld:'vSELECTEDID',pic:''},{av:'AV42CarAux',fld:'vCARAUX',pic:''},{av:'AV24Car',fld:'vCAR',grid:79,pic:''},{av:'nGXsfl_79_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:79},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'nRC_GXsfl_79',ctrl:'CARPRODUCTS',prop:'GridRC',grid:79},{av:'divTablenewsale_Visible',ctrl:'TABLENEWSALE',prop:'Visible'},{av:'divTablepaymentmethod_Visible',ctrl:'TABLEPAYMENTMETHOD',prop:'Visible'}]}");
         setEventMetadata("'REGISTERSALE'","{handler:'E111T2',iparms:[{av:'ALLPRODUCTSFILTERED_nFirstRecordOnPage'},{av:'ALLPRODUCTSFILTERED_nEOF'},{av:'AV49SDTProductFiltered',fld:'vSDTPRODUCTFILTERED',grid:35,pic:''},{av:'nGXsfl_35_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:35},{av:'nRC_GXsfl_35',ctrl:'ALLPRODUCTSFILTERED',prop:'GridRC',grid:35},{av:'subAllproductsfiltered_Rows',ctrl:'ALLPRODUCTSFILTERED',prop:'Rows'},{av:'AV17Code',fld:'vCODE',pic:''},{av:'AV18Name',fld:'vNAME',pic:''},{av:'AV15Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV45Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV16Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavPaymentmethodid'},{av:'AV58PaymentMethodId',fld:'vPAYMENTMETHODID',pic:'ZZZZZ9'},{av:'AV38newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV41newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'AV24Car',fld:'vCAR',grid:79,pic:''},{av:'nGXsfl_79_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:79},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'nRC_GXsfl_79',ctrl:'CARPRODUCTS',prop:'GridRC',grid:79},{av:'AV56SDTInvoiceAddPaymentMethod',fld:'vSDTINVOICEADDPAYMENTMETHOD',grid:139,pic:''},{av:'nGXsfl_139_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:139},{av:'GRIDINVOICEADDPAYMENTMETHOD_nFirstRecordOnPage'},{av:'nRC_GXsfl_139',ctrl:'GRIDINVOICEADDPAYMENTMETHOD',prop:'GridRC',grid:139},{av:'AV37AllOk',fld:'vALLOK',pic:''},{av:'AV36Total',fld:'vTOTAL',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV55RemainingAmount',fld:'vREMAININGAMOUNT',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'GRIDINVOICEADDPAYMENTMETHOD_nEOF'},{av:'CARPRODUCTS_nEOF'}]");
         setEventMetadata("'REGISTERSALE'",",oparms:[{av:'AV37AllOk',fld:'vALLOK',pic:''},{av:'AV36Total',fld:'vTOTAL',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV24Car',fld:'vCAR',grid:79,pic:''},{av:'nGXsfl_79_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:79},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'nRC_GXsfl_79',ctrl:'CARPRODUCTS',prop:'GridRC',grid:79},{av:'AV29SelectedId',fld:'vSELECTEDID',pic:''},{av:'divTablenewsale_Visible',ctrl:'TABLENEWSALE',prop:'Visible'},{av:'divTablepaymentmethod_Visible',ctrl:'TABLEPAYMENTMETHOD',prop:'Visible'},{av:'AV56SDTInvoiceAddPaymentMethod',fld:'vSDTINVOICEADDPAYMENTMETHOD',grid:139,pic:''},{av:'nGXsfl_139_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:139},{av:'GRIDINVOICEADDPAYMENTMETHOD_nFirstRecordOnPage'},{av:'nRC_GXsfl_139',ctrl:'GRIDINVOICEADDPAYMENTMETHOD',prop:'GridRC',grid:139},{av:'AV57SDTInvoiceAddPaymentMethodItem',fld:'vSDTINVOICEADDPAYMENTMETHODITEM',pic:''},{av:'AV55RemainingAmount',fld:'vREMAININGAMOUNT',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV64AmountReceivable',fld:'vAMOUNTRECEIVABLE',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'dynavPaymentmethodid'},{av:'AV58PaymentMethodId',fld:'vPAYMENTMETHODID',pic:'ZZZZZ9'},{av:'AV59InvoicePaymentMethodImport',fld:'vINVOICEPAYMENTMETHODIMPORT',pic:'ZZZZZZZZZZZZZZ9.99'}]}");
         setEventMetadata("CTLQUANTITY1.CONTROLVALUECHANGED","{handler:'E151T2',iparms:[{av:'AV24Car',fld:'vCAR',grid:79,pic:''},{av:'nGXsfl_79_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:79},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'nRC_GXsfl_79',ctrl:'CARPRODUCTS',prop:'GridRC',grid:79},{av:'AV36Total',fld:'vTOTAL',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV56SDTInvoiceAddPaymentMethod',fld:'vSDTINVOICEADDPAYMENTMETHOD',grid:139,pic:''},{av:'nGXsfl_139_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:139},{av:'GRIDINVOICEADDPAYMENTMETHOD_nFirstRecordOnPage'},{av:'nRC_GXsfl_139',ctrl:'GRIDINVOICEADDPAYMENTMETHOD',prop:'GridRC',grid:139},{av:'ALLPRODUCTSFILTERED_nFirstRecordOnPage'},{av:'ALLPRODUCTSFILTERED_nEOF'},{av:'AV49SDTProductFiltered',fld:'vSDTPRODUCTFILTERED',grid:35,pic:''},{av:'nGXsfl_35_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:35},{av:'nRC_GXsfl_35',ctrl:'ALLPRODUCTSFILTERED',prop:'GridRC',grid:35},{av:'AV17Code',fld:'vCODE',pic:''},{av:'AV18Name',fld:'vNAME',pic:''},{av:'AV15Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'GRIDINVOICEADDPAYMENTMETHOD_nEOF'},{av:'CARPRODUCTS_nEOF'},{av:'subAllproductsfiltered_Rows',ctrl:'ALLPRODUCTSFILTERED',prop:'Rows'},{av:'dynavBrand'},{av:'AV16Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV45Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'dynavPaymentmethodid'},{av:'AV58PaymentMethodId',fld:'vPAYMENTMETHODID',pic:'ZZZZZ9'},{av:'AV38newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV41newCode',fld:'vNEWCODE',pic:'',hsh:true}]");
         setEventMetadata("CTLQUANTITY1.CONTROLVALUECHANGED",",oparms:[{av:'AV24Car',fld:'vCAR',grid:79,pic:''},{av:'nGXsfl_79_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:79},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'nRC_GXsfl_79',ctrl:'CARPRODUCTS',prop:'GridRC',grid:79},{av:'AV36Total',fld:'vTOTAL',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV56SDTInvoiceAddPaymentMethod',fld:'vSDTINVOICEADDPAYMENTMETHOD',grid:139,pic:''},{av:'nGXsfl_139_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:139},{av:'GRIDINVOICEADDPAYMENTMETHOD_nFirstRecordOnPage'},{av:'nRC_GXsfl_139',ctrl:'GRIDINVOICEADDPAYMENTMETHOD',prop:'GridRC',grid:139},{av:'AV57SDTInvoiceAddPaymentMethodItem',fld:'vSDTINVOICEADDPAYMENTMETHODITEM',pic:''},{av:'AV55RemainingAmount',fld:'vREMAININGAMOUNT',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV64AmountReceivable',fld:'vAMOUNTRECEIVABLE',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'dynavPaymentmethodid'},{av:'AV58PaymentMethodId',fld:'vPAYMENTMETHODID',pic:'ZZZZZ9'},{av:'AV59InvoicePaymentMethodImport',fld:'vINVOICEPAYMENTMETHODIMPORT',pic:'ZZZZZZZZZZZZZZ9.99'}]}");
         setEventMetadata("'CLEARSALE'","{handler:'E121T2',iparms:[{av:'AV36Total',fld:'vTOTAL',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV56SDTInvoiceAddPaymentMethod',fld:'vSDTINVOICEADDPAYMENTMETHOD',grid:139,pic:''},{av:'nGXsfl_139_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:139},{av:'GRIDINVOICEADDPAYMENTMETHOD_nFirstRecordOnPage'},{av:'nRC_GXsfl_139',ctrl:'GRIDINVOICEADDPAYMENTMETHOD',prop:'GridRC',grid:139},{av:'ALLPRODUCTSFILTERED_nFirstRecordOnPage'},{av:'ALLPRODUCTSFILTERED_nEOF'},{av:'AV49SDTProductFiltered',fld:'vSDTPRODUCTFILTERED',grid:35,pic:''},{av:'nGXsfl_35_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:35},{av:'nRC_GXsfl_35',ctrl:'ALLPRODUCTSFILTERED',prop:'GridRC',grid:35},{av:'AV17Code',fld:'vCODE',pic:''},{av:'AV18Name',fld:'vNAME',pic:''},{av:'AV15Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'GRIDINVOICEADDPAYMENTMETHOD_nEOF'},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'CARPRODUCTS_nEOF'},{av:'subAllproductsfiltered_Rows',ctrl:'ALLPRODUCTSFILTERED',prop:'Rows'},{av:'AV24Car',fld:'vCAR',grid:79,pic:''},{av:'nGXsfl_79_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:79},{av:'nRC_GXsfl_79',ctrl:'CARPRODUCTS',prop:'GridRC',grid:79},{av:'dynavBrand'},{av:'AV16Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV45Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'dynavPaymentmethodid'},{av:'AV58PaymentMethodId',fld:'vPAYMENTMETHODID',pic:'ZZZZZ9'},{av:'AV38newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV41newCode',fld:'vNEWCODE',pic:'',hsh:true}]");
         setEventMetadata("'CLEARSALE'",",oparms:[{av:'AV36Total',fld:'vTOTAL',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV55RemainingAmount',fld:'vREMAININGAMOUNT',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV24Car',fld:'vCAR',grid:79,pic:''},{av:'nGXsfl_79_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:79},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'nRC_GXsfl_79',ctrl:'CARPRODUCTS',prop:'GridRC',grid:79},{av:'AV29SelectedId',fld:'vSELECTEDID',pic:''},{av:'divTablenewsale_Visible',ctrl:'TABLENEWSALE',prop:'Visible'},{av:'divTablepaymentmethod_Visible',ctrl:'TABLEPAYMENTMETHOD',prop:'Visible'},{av:'AV56SDTInvoiceAddPaymentMethod',fld:'vSDTINVOICEADDPAYMENTMETHOD',grid:139,pic:''},{av:'nGXsfl_139_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:139},{av:'GRIDINVOICEADDPAYMENTMETHOD_nFirstRecordOnPage'},{av:'nRC_GXsfl_139',ctrl:'GRIDINVOICEADDPAYMENTMETHOD',prop:'GridRC',grid:139},{av:'AV57SDTInvoiceAddPaymentMethodItem',fld:'vSDTINVOICEADDPAYMENTMETHODITEM',pic:''},{av:'AV64AmountReceivable',fld:'vAMOUNTRECEIVABLE',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'dynavPaymentmethodid'},{av:'AV58PaymentMethodId',fld:'vPAYMENTMETHODID',pic:'ZZZZZ9'},{av:'AV59InvoicePaymentMethodImport',fld:'vINVOICEPAYMENTMETHODIMPORT',pic:'ZZZZZZZZZZZZZZ9.99'}]}");
         setEventMetadata("VREMOVE.CLICK","{handler:'E161T2',iparms:[{av:'AV24Car',fld:'vCAR',grid:79,pic:''},{av:'nGXsfl_79_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:79},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'nRC_GXsfl_79',ctrl:'CARPRODUCTS',prop:'GridRC',grid:79},{av:'AV29SelectedId',fld:'vSELECTEDID',pic:''},{av:'AV36Total',fld:'vTOTAL',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV56SDTInvoiceAddPaymentMethod',fld:'vSDTINVOICEADDPAYMENTMETHOD',grid:139,pic:''},{av:'nGXsfl_139_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:139},{av:'GRIDINVOICEADDPAYMENTMETHOD_nFirstRecordOnPage'},{av:'nRC_GXsfl_139',ctrl:'GRIDINVOICEADDPAYMENTMETHOD',prop:'GridRC',grid:139},{av:'ALLPRODUCTSFILTERED_nFirstRecordOnPage'},{av:'ALLPRODUCTSFILTERED_nEOF'},{av:'AV49SDTProductFiltered',fld:'vSDTPRODUCTFILTERED',grid:35,pic:''},{av:'nGXsfl_35_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:35},{av:'nRC_GXsfl_35',ctrl:'ALLPRODUCTSFILTERED',prop:'GridRC',grid:35},{av:'AV17Code',fld:'vCODE',pic:''},{av:'AV18Name',fld:'vNAME',pic:''},{av:'AV15Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'GRIDINVOICEADDPAYMENTMETHOD_nEOF'},{av:'CARPRODUCTS_nEOF'},{av:'subAllproductsfiltered_Rows',ctrl:'ALLPRODUCTSFILTERED',prop:'Rows'},{av:'dynavBrand'},{av:'AV16Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV45Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'dynavPaymentmethodid'},{av:'AV58PaymentMethodId',fld:'vPAYMENTMETHODID',pic:'ZZZZZ9'},{av:'AV38newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV41newCode',fld:'vNEWCODE',pic:'',hsh:true}]");
         setEventMetadata("VREMOVE.CLICK",",oparms:[{av:'AV30Position',fld:'vPOSITION',pic:'ZZZZZ9'},{av:'AV29SelectedId',fld:'vSELECTEDID',pic:''},{av:'AV24Car',fld:'vCAR',grid:79,pic:''},{av:'nGXsfl_79_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:79},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'nRC_GXsfl_79',ctrl:'CARPRODUCTS',prop:'GridRC',grid:79},{av:'divTablenewsale_Visible',ctrl:'TABLENEWSALE',prop:'Visible'},{av:'divTablepaymentmethod_Visible',ctrl:'TABLEPAYMENTMETHOD',prop:'Visible'},{av:'AV56SDTInvoiceAddPaymentMethod',fld:'vSDTINVOICEADDPAYMENTMETHOD',grid:139,pic:''},{av:'nGXsfl_139_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:139},{av:'GRIDINVOICEADDPAYMENTMETHOD_nFirstRecordOnPage'},{av:'nRC_GXsfl_139',ctrl:'GRIDINVOICEADDPAYMENTMETHOD',prop:'GridRC',grid:139},{av:'AV57SDTInvoiceAddPaymentMethodItem',fld:'vSDTINVOICEADDPAYMENTMETHODITEM',pic:''},{av:'AV55RemainingAmount',fld:'vREMAININGAMOUNT',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV64AmountReceivable',fld:'vAMOUNTRECEIVABLE',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'dynavPaymentmethodid'},{av:'AV58PaymentMethodId',fld:'vPAYMENTMETHODID',pic:'ZZZZZ9'},{av:'AV59InvoicePaymentMethodImport',fld:'vINVOICEPAYMENTMETHODIMPORT',pic:'ZZZZZZZZZZZZZZ9.99'}]}");
         setEventMetadata("CARPRODUCTS.REFRESH","{handler:'E171T2',iparms:[{av:'AV24Car',fld:'vCAR',grid:79,pic:''},{av:'nGXsfl_79_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:79},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'nRC_GXsfl_79',ctrl:'CARPRODUCTS',prop:'GridRC',grid:79},{av:'AV56SDTInvoiceAddPaymentMethod',fld:'vSDTINVOICEADDPAYMENTMETHOD',grid:139,pic:''},{av:'nGXsfl_139_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:139},{av:'GRIDINVOICEADDPAYMENTMETHOD_nFirstRecordOnPage'},{av:'nRC_GXsfl_139',ctrl:'GRIDINVOICEADDPAYMENTMETHOD',prop:'GridRC',grid:139},{av:'AV36Total',fld:'vTOTAL',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'ALLPRODUCTSFILTERED_nFirstRecordOnPage'},{av:'ALLPRODUCTSFILTERED_nEOF'},{av:'AV49SDTProductFiltered',fld:'vSDTPRODUCTFILTERED',grid:35,pic:''},{av:'nGXsfl_35_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:35},{av:'nRC_GXsfl_35',ctrl:'ALLPRODUCTSFILTERED',prop:'GridRC',grid:35},{av:'AV17Code',fld:'vCODE',pic:''},{av:'AV18Name',fld:'vNAME',pic:''},{av:'AV15Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'GRIDINVOICEADDPAYMENTMETHOD_nEOF'},{av:'CARPRODUCTS_nEOF'},{av:'subAllproductsfiltered_Rows',ctrl:'ALLPRODUCTSFILTERED',prop:'Rows'},{av:'dynavBrand'},{av:'AV16Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV45Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'dynavPaymentmethodid'},{av:'AV58PaymentMethodId',fld:'vPAYMENTMETHODID',pic:'ZZZZZ9'},{av:'AV38newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV41newCode',fld:'vNEWCODE',pic:'',hsh:true}]");
         setEventMetadata("CARPRODUCTS.REFRESH",",oparms:[{av:'AV44Remove',fld:'vREMOVE',pic:''},{av:'AV36Total',fld:'vTOTAL',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV24Car',fld:'vCAR',grid:79,pic:''},{av:'nGXsfl_79_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:79},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'nRC_GXsfl_79',ctrl:'CARPRODUCTS',prop:'GridRC',grid:79},{av:'AV57SDTInvoiceAddPaymentMethodItem',fld:'vSDTINVOICEADDPAYMENTMETHODITEM',pic:''},{av:'AV55RemainingAmount',fld:'vREMAININGAMOUNT',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV64AmountReceivable',fld:'vAMOUNTRECEIVABLE',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV59InvoicePaymentMethodImport',fld:'vINVOICEPAYMENTMETHODIMPORT',pic:'ZZZZZZZZZZZZZZ9.99'}]}");
         setEventMetadata("'SELECTALL'","{handler:'E131T2',iparms:[{av:'AV17Code',fld:'vCODE',pic:''},{av:'AV18Name',fld:'vNAME',pic:''},{av:'AV15Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV16Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV45Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV36Total',fld:'vTOTAL',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV56SDTInvoiceAddPaymentMethod',fld:'vSDTINVOICEADDPAYMENTMETHOD',grid:139,pic:''},{av:'nGXsfl_139_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:139},{av:'GRIDINVOICEADDPAYMENTMETHOD_nFirstRecordOnPage'},{av:'nRC_GXsfl_139',ctrl:'GRIDINVOICEADDPAYMENTMETHOD',prop:'GridRC',grid:139},{av:'ALLPRODUCTSFILTERED_nFirstRecordOnPage'},{av:'ALLPRODUCTSFILTERED_nEOF'},{av:'AV49SDTProductFiltered',fld:'vSDTPRODUCTFILTERED',grid:35,pic:''},{av:'nGXsfl_35_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:35},{av:'nRC_GXsfl_35',ctrl:'ALLPRODUCTSFILTERED',prop:'GridRC',grid:35},{av:'GRIDINVOICEADDPAYMENTMETHOD_nEOF'},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'CARPRODUCTS_nEOF'},{av:'subAllproductsfiltered_Rows',ctrl:'ALLPRODUCTSFILTERED',prop:'Rows'},{av:'AV24Car',fld:'vCAR',grid:79,pic:''},{av:'nGXsfl_79_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:79},{av:'nRC_GXsfl_79',ctrl:'CARPRODUCTS',prop:'GridRC',grid:79},{av:'dynavPaymentmethodid'},{av:'AV58PaymentMethodId',fld:'vPAYMENTMETHODID',pic:'ZZZZZ9'},{av:'AV38newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV41newCode',fld:'vNEWCODE',pic:'',hsh:true}]");
         setEventMetadata("'SELECTALL'",",oparms:[{av:'AV24Car',fld:'vCAR',grid:79,pic:''},{av:'nGXsfl_79_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:79},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'nRC_GXsfl_79',ctrl:'CARPRODUCTS',prop:'GridRC',grid:79},{av:'dynavSector'},{av:'AV45Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV16Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'AV15Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV18Name',fld:'vNAME',pic:''},{av:'divTablenewsale_Visible',ctrl:'TABLENEWSALE',prop:'Visible'},{av:'divTablepaymentmethod_Visible',ctrl:'TABLEPAYMENTMETHOD',prop:'Visible'},{av:'AV56SDTInvoiceAddPaymentMethod',fld:'vSDTINVOICEADDPAYMENTMETHOD',grid:139,pic:''},{av:'nGXsfl_139_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:139},{av:'GRIDINVOICEADDPAYMENTMETHOD_nFirstRecordOnPage'},{av:'nRC_GXsfl_139',ctrl:'GRIDINVOICEADDPAYMENTMETHOD',prop:'GridRC',grid:139},{av:'AV57SDTInvoiceAddPaymentMethodItem',fld:'vSDTINVOICEADDPAYMENTMETHODITEM',pic:''},{av:'AV55RemainingAmount',fld:'vREMAININGAMOUNT',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV64AmountReceivable',fld:'vAMOUNTRECEIVABLE',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'dynavPaymentmethodid'},{av:'AV58PaymentMethodId',fld:'vPAYMENTMETHODID',pic:'ZZZZZ9'},{av:'AV59InvoicePaymentMethodImport',fld:'vINVOICEPAYMENTMETHODIMPORT',pic:'ZZZZZZZZZZZZZZ9.99'}]}");
         setEventMetadata("ALLPRODUCTSFILTERED.REFRESH","{handler:'E251T2',iparms:[{av:'AV17Code',fld:'vCODE',pic:''},{av:'AV18Name',fld:'vNAME',pic:''},{av:'AV15Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV45Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV16Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'AV49SDTProductFiltered',fld:'vSDTPRODUCTFILTERED',grid:35,pic:''},{av:'nGXsfl_35_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:35},{av:'ALLPRODUCTSFILTERED_nFirstRecordOnPage'},{av:'nRC_GXsfl_35',ctrl:'ALLPRODUCTSFILTERED',prop:'GridRC',grid:35},{av:'ALLPRODUCTSFILTERED_nEOF'},{av:'GRIDINVOICEADDPAYMENTMETHOD_nFirstRecordOnPage'},{av:'GRIDINVOICEADDPAYMENTMETHOD_nEOF'},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'CARPRODUCTS_nEOF'},{av:'subAllproductsfiltered_Rows',ctrl:'ALLPRODUCTSFILTERED',prop:'Rows'},{av:'AV24Car',fld:'vCAR',grid:79,pic:''},{av:'nGXsfl_79_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:79},{av:'nRC_GXsfl_79',ctrl:'CARPRODUCTS',prop:'GridRC',grid:79},{av:'AV56SDTInvoiceAddPaymentMethod',fld:'vSDTINVOICEADDPAYMENTMETHOD',grid:139,pic:''},{av:'nGXsfl_139_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:139},{av:'nRC_GXsfl_139',ctrl:'GRIDINVOICEADDPAYMENTMETHOD',prop:'GridRC',grid:139},{av:'AV36Total',fld:'vTOTAL',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'dynavPaymentmethodid'},{av:'AV58PaymentMethodId',fld:'vPAYMENTMETHODID',pic:'ZZZZZ9'},{av:'AV38newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV41newCode',fld:'vNEWCODE',pic:'',hsh:true}]");
         setEventMetadata("ALLPRODUCTSFILTERED.REFRESH",",oparms:[{av:'AV49SDTProductFiltered',fld:'vSDTPRODUCTFILTERED',grid:35,pic:''},{av:'nGXsfl_35_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:35},{av:'ALLPRODUCTSFILTERED_nFirstRecordOnPage'},{av:'nRC_GXsfl_35',ctrl:'ALLPRODUCTSFILTERED',prop:'GridRC',grid:35},{av:'dynavBrand'},{av:'AV16Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV45Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV15Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV18Name',fld:'vNAME',pic:''}]}");
         setEventMetadata("'ADDPAYMENTMETHOD'","{handler:'E141T2',iparms:[{av:'dynavPaymentmethodid'},{av:'AV58PaymentMethodId',fld:'vPAYMENTMETHODID',pic:'ZZZZZ9'},{av:'AV55RemainingAmount',fld:'vREMAININGAMOUNT',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV59InvoicePaymentMethodImport',fld:'vINVOICEPAYMENTMETHODIMPORT',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV63WasUsed',fld:'vWASUSED',pic:''},{av:'AV56SDTInvoiceAddPaymentMethod',fld:'vSDTINVOICEADDPAYMENTMETHOD',grid:139,pic:''},{av:'nGXsfl_139_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:139},{av:'GRIDINVOICEADDPAYMENTMETHOD_nFirstRecordOnPage'},{av:'nRC_GXsfl_139',ctrl:'GRIDINVOICEADDPAYMENTMETHOD',prop:'GridRC',grid:139},{av:'AV30Position',fld:'vPOSITION',pic:'ZZZZZ9'},{av:'AV57SDTInvoiceAddPaymentMethodItem',fld:'vSDTINVOICEADDPAYMENTMETHODITEM',pic:''},{av:'ALLPRODUCTSFILTERED_nFirstRecordOnPage'},{av:'ALLPRODUCTSFILTERED_nEOF'},{av:'AV49SDTProductFiltered',fld:'vSDTPRODUCTFILTERED',grid:35,pic:''},{av:'nGXsfl_35_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:35},{av:'nRC_GXsfl_35',ctrl:'ALLPRODUCTSFILTERED',prop:'GridRC',grid:35},{av:'AV17Code',fld:'vCODE',pic:''},{av:'AV18Name',fld:'vNAME',pic:''},{av:'AV15Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'GRIDINVOICEADDPAYMENTMETHOD_nEOF'},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'CARPRODUCTS_nEOF'},{av:'subAllproductsfiltered_Rows',ctrl:'ALLPRODUCTSFILTERED',prop:'Rows'},{av:'AV24Car',fld:'vCAR',grid:79,pic:''},{av:'nGXsfl_79_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:79},{av:'nRC_GXsfl_79',ctrl:'CARPRODUCTS',prop:'GridRC',grid:79},{av:'AV36Total',fld:'vTOTAL',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'dynavBrand'},{av:'AV16Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV45Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV38newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV41newCode',fld:'vNEWCODE',pic:'',hsh:true}]");
         setEventMetadata("'ADDPAYMENTMETHOD'",",oparms:[{av:'AV57SDTInvoiceAddPaymentMethodItem',fld:'vSDTINVOICEADDPAYMENTMETHODITEM',pic:''},{av:'AV56SDTInvoiceAddPaymentMethod',fld:'vSDTINVOICEADDPAYMENTMETHOD',grid:139,pic:''},{av:'nGXsfl_139_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:139},{av:'GRIDINVOICEADDPAYMENTMETHOD_nFirstRecordOnPage'},{av:'nRC_GXsfl_139',ctrl:'GRIDINVOICEADDPAYMENTMETHOD',prop:'GridRC',grid:139},{av:'AV63WasUsed',fld:'vWASUSED',pic:''},{av:'AV30Position',fld:'vPOSITION',pic:'ZZZZZ9'}]}");
         setEventMetadata("GRIDINVOICEADDPAYMENTMETHOD.REFRESH","{handler:'E191T2',iparms:[{av:'AV56SDTInvoiceAddPaymentMethod',fld:'vSDTINVOICEADDPAYMENTMETHOD',grid:139,pic:''},{av:'nGXsfl_139_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:139},{av:'GRIDINVOICEADDPAYMENTMETHOD_nFirstRecordOnPage'},{av:'nRC_GXsfl_139',ctrl:'GRIDINVOICEADDPAYMENTMETHOD',prop:'GridRC',grid:139},{av:'AV36Total',fld:'vTOTAL',pic:'ZZZZZZZZZZZZZZ9.99'}]");
         setEventMetadata("GRIDINVOICEADDPAYMENTMETHOD.REFRESH",",oparms:[{av:'AV61PaymentMethodRemove',fld:'vPAYMENTMETHODREMOVE',pic:''},{av:'AV57SDTInvoiceAddPaymentMethodItem',fld:'vSDTINVOICEADDPAYMENTMETHODITEM',pic:''},{av:'AV55RemainingAmount',fld:'vREMAININGAMOUNT',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV64AmountReceivable',fld:'vAMOUNTRECEIVABLE',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV59InvoicePaymentMethodImport',fld:'vINVOICEPAYMENTMETHODIMPORT',pic:'ZZZZZZZZZZZZZZ9.99'}]}");
         setEventMetadata("VPAYMENTMETHODREMOVE.CLICK","{handler:'E201T2',iparms:[{av:'GRIDINVOICEADDPAYMENTMETHOD_nFirstRecordOnPage'},{av:'GRIDINVOICEADDPAYMENTMETHOD_nEOF'},{av:'subAllproductsfiltered_Rows',ctrl:'ALLPRODUCTSFILTERED',prop:'Rows'},{av:'AV56SDTInvoiceAddPaymentMethod',fld:'vSDTINVOICEADDPAYMENTMETHOD',grid:139,pic:''},{av:'nGXsfl_139_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:139},{av:'nRC_GXsfl_139',ctrl:'GRIDINVOICEADDPAYMENTMETHOD',prop:'GridRC',grid:139},{av:'AV36Total',fld:'vTOTAL',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'dynavBrand'},{av:'AV16Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV45Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'dynavPaymentmethodid'},{av:'AV58PaymentMethodId',fld:'vPAYMENTMETHODID',pic:'ZZZZZ9'},{av:'AV38newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV41newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'ALLPRODUCTSFILTERED_nFirstRecordOnPage'},{av:'ALLPRODUCTSFILTERED_nEOF'},{av:'AV49SDTProductFiltered',fld:'vSDTPRODUCTFILTERED',grid:35,pic:''},{av:'nGXsfl_35_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:35},{av:'nRC_GXsfl_35',ctrl:'ALLPRODUCTSFILTERED',prop:'GridRC',grid:35},{av:'AV17Code',fld:'vCODE',pic:''},{av:'AV18Name',fld:'vNAME',pic:''},{av:'AV15Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'CARPRODUCTS_nEOF'},{av:'AV24Car',fld:'vCAR',grid:79,pic:''},{av:'nGXsfl_79_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:79},{av:'nRC_GXsfl_79',ctrl:'CARPRODUCTS',prop:'GridRC',grid:79}]");
         setEventMetadata("VPAYMENTMETHODREMOVE.CLICK",",oparms:[{av:'AV30Position',fld:'vPOSITION',pic:'ZZZZZ9'},{av:'AV56SDTInvoiceAddPaymentMethod',fld:'vSDTINVOICEADDPAYMENTMETHOD',grid:139,pic:''},{av:'nGXsfl_139_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:139},{av:'GRIDINVOICEADDPAYMENTMETHOD_nFirstRecordOnPage'},{av:'nRC_GXsfl_139',ctrl:'GRIDINVOICEADDPAYMENTMETHOD',prop:'GridRC',grid:139},{av:'AV57SDTInvoiceAddPaymentMethodItem',fld:'vSDTINVOICEADDPAYMENTMETHODITEM',pic:''},{av:'AV55RemainingAmount',fld:'vREMAININGAMOUNT',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV64AmountReceivable',fld:'vAMOUNTRECEIVABLE',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV59InvoicePaymentMethodImport',fld:'vINVOICEPAYMENTMETHODIMPORT',pic:'ZZZZZZZZZZZZZZ9.99'}]}");
         setEventMetadata("CTLINVOICEPAYMENTMETHODIMPORT.CONTROLVALUECHANGED","{handler:'E211T2',iparms:[{av:'AV56SDTInvoiceAddPaymentMethod',fld:'vSDTINVOICEADDPAYMENTMETHOD',grid:139,pic:''},{av:'nGXsfl_139_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:139},{av:'GRIDINVOICEADDPAYMENTMETHOD_nFirstRecordOnPage'},{av:'nRC_GXsfl_139',ctrl:'GRIDINVOICEADDPAYMENTMETHOD',prop:'GridRC',grid:139},{av:'AV55RemainingAmount',fld:'vREMAININGAMOUNT',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV36Total',fld:'vTOTAL',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'ALLPRODUCTSFILTERED_nFirstRecordOnPage'},{av:'ALLPRODUCTSFILTERED_nEOF'},{av:'AV49SDTProductFiltered',fld:'vSDTPRODUCTFILTERED',grid:35,pic:''},{av:'nGXsfl_35_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:35},{av:'nRC_GXsfl_35',ctrl:'ALLPRODUCTSFILTERED',prop:'GridRC',grid:35},{av:'AV17Code',fld:'vCODE',pic:''},{av:'AV18Name',fld:'vNAME',pic:''},{av:'AV15Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'GRIDINVOICEADDPAYMENTMETHOD_nEOF'},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'CARPRODUCTS_nEOF'},{av:'subAllproductsfiltered_Rows',ctrl:'ALLPRODUCTSFILTERED',prop:'Rows'},{av:'AV24Car',fld:'vCAR',grid:79,pic:''},{av:'nGXsfl_79_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:79},{av:'nRC_GXsfl_79',ctrl:'CARPRODUCTS',prop:'GridRC',grid:79},{av:'dynavBrand'},{av:'AV16Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV45Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'dynavPaymentmethodid'},{av:'AV58PaymentMethodId',fld:'vPAYMENTMETHODID',pic:'ZZZZZ9'},{av:'AV38newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV41newCode',fld:'vNEWCODE',pic:'',hsh:true}]");
         setEventMetadata("CTLINVOICEPAYMENTMETHODIMPORT.CONTROLVALUECHANGED",",oparms:[{av:'AV56SDTInvoiceAddPaymentMethod',fld:'vSDTINVOICEADDPAYMENTMETHOD',grid:139,pic:''},{av:'nGXsfl_139_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:139},{av:'GRIDINVOICEADDPAYMENTMETHOD_nFirstRecordOnPage'},{av:'nRC_GXsfl_139',ctrl:'GRIDINVOICEADDPAYMENTMETHOD',prop:'GridRC',grid:139},{av:'AV57SDTInvoiceAddPaymentMethodItem',fld:'vSDTINVOICEADDPAYMENTMETHODITEM',pic:''},{av:'AV55RemainingAmount',fld:'vREMAININGAMOUNT',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV64AmountReceivable',fld:'vAMOUNTRECEIVABLE',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV59InvoicePaymentMethodImport',fld:'vINVOICEPAYMENTMETHODIMPORT',pic:'ZZZZZZZZZZZZZZ9.99'}]}");
         setEventMetadata("ALLPRODUCTSFILTERED_FIRSTPAGE","{handler:'suballproductsfiltered_firstpage',iparms:[{av:'ALLPRODUCTSFILTERED_nFirstRecordOnPage'},{av:'ALLPRODUCTSFILTERED_nEOF'},{av:'AV49SDTProductFiltered',fld:'vSDTPRODUCTFILTERED',grid:35,pic:''},{av:'nGXsfl_35_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:35},{av:'nRC_GXsfl_35',ctrl:'ALLPRODUCTSFILTERED',prop:'GridRC',grid:35},{av:'subAllproductsfiltered_Rows',ctrl:'ALLPRODUCTSFILTERED',prop:'Rows'},{av:'AV17Code',fld:'vCODE',pic:''},{av:'AV18Name',fld:'vNAME',pic:''},{av:'AV15Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV38newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV41newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'dynavBrand'},{av:'AV16Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV45Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'dynavPaymentmethodid'},{av:'AV58PaymentMethodId',fld:'vPAYMENTMETHODID',pic:'ZZZZZ9'}]");
         setEventMetadata("ALLPRODUCTSFILTERED_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("ALLPRODUCTSFILTERED_PREVPAGE","{handler:'suballproductsfiltered_previouspage',iparms:[{av:'ALLPRODUCTSFILTERED_nFirstRecordOnPage'},{av:'ALLPRODUCTSFILTERED_nEOF'},{av:'AV49SDTProductFiltered',fld:'vSDTPRODUCTFILTERED',grid:35,pic:''},{av:'nGXsfl_35_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:35},{av:'nRC_GXsfl_35',ctrl:'ALLPRODUCTSFILTERED',prop:'GridRC',grid:35},{av:'subAllproductsfiltered_Rows',ctrl:'ALLPRODUCTSFILTERED',prop:'Rows'},{av:'AV17Code',fld:'vCODE',pic:''},{av:'AV18Name',fld:'vNAME',pic:''},{av:'AV15Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV38newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV41newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'dynavBrand'},{av:'AV16Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV45Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'dynavPaymentmethodid'},{av:'AV58PaymentMethodId',fld:'vPAYMENTMETHODID',pic:'ZZZZZ9'}]");
         setEventMetadata("ALLPRODUCTSFILTERED_PREVPAGE",",oparms:[]}");
         setEventMetadata("ALLPRODUCTSFILTERED_NEXTPAGE","{handler:'suballproductsfiltered_nextpage',iparms:[{av:'ALLPRODUCTSFILTERED_nFirstRecordOnPage'},{av:'ALLPRODUCTSFILTERED_nEOF'},{av:'AV49SDTProductFiltered',fld:'vSDTPRODUCTFILTERED',grid:35,pic:''},{av:'nGXsfl_35_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:35},{av:'nRC_GXsfl_35',ctrl:'ALLPRODUCTSFILTERED',prop:'GridRC',grid:35},{av:'subAllproductsfiltered_Rows',ctrl:'ALLPRODUCTSFILTERED',prop:'Rows'},{av:'AV17Code',fld:'vCODE',pic:''},{av:'AV18Name',fld:'vNAME',pic:''},{av:'AV15Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV38newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV41newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'dynavBrand'},{av:'AV16Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV45Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'dynavPaymentmethodid'},{av:'AV58PaymentMethodId',fld:'vPAYMENTMETHODID',pic:'ZZZZZ9'}]");
         setEventMetadata("ALLPRODUCTSFILTERED_NEXTPAGE",",oparms:[]}");
         setEventMetadata("ALLPRODUCTSFILTERED_LASTPAGE","{handler:'suballproductsfiltered_lastpage',iparms:[{av:'ALLPRODUCTSFILTERED_nFirstRecordOnPage'},{av:'ALLPRODUCTSFILTERED_nEOF'},{av:'AV49SDTProductFiltered',fld:'vSDTPRODUCTFILTERED',grid:35,pic:''},{av:'nGXsfl_35_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:35},{av:'nRC_GXsfl_35',ctrl:'ALLPRODUCTSFILTERED',prop:'GridRC',grid:35},{av:'subAllproductsfiltered_Rows',ctrl:'ALLPRODUCTSFILTERED',prop:'Rows'},{av:'AV17Code',fld:'vCODE',pic:''},{av:'AV18Name',fld:'vNAME',pic:''},{av:'AV15Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV38newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV41newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'dynavBrand'},{av:'AV16Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV45Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'dynavPaymentmethodid'},{av:'AV58PaymentMethodId',fld:'vPAYMENTMETHODID',pic:'ZZZZZ9'}]");
         setEventMetadata("ALLPRODUCTSFILTERED_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_TOTAL","{handler:'Validv_Total',iparms:[]");
         setEventMetadata("VALIDV_TOTAL",",oparms:[]}");
         setEventMetadata("VALIDV_INVOICEPAYMENTMETHODIMPORT","{handler:'Validv_Invoicepaymentmethodimport',iparms:[]");
         setEventMetadata("VALIDV_INVOICEPAYMENTMETHODIMPORT",",oparms:[]}");
         setEventMetadata("VALIDV_REMAININGAMOUNT","{handler:'Validv_Remainingamount',iparms:[]");
         setEventMetadata("VALIDV_REMAININGAMOUNT",",oparms:[]}");
         setEventMetadata("VALIDV_AMOUNTRECEIVABLE","{handler:'Validv_Amountreceivable',iparms:[]");
         setEventMetadata("VALIDV_AMOUNTRECEIVABLE",",oparms:[]}");
         setEventMetadata("VALIDV_GXV6","{handler:'Validv_Gxv6',iparms:[]");
         setEventMetadata("VALIDV_GXV6",",oparms:[]}");
         setEventMetadata("VALIDV_GXV7","{handler:'Validv_Gxv7',iparms:[]");
         setEventMetadata("VALIDV_GXV7",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Gxv8',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("VALIDV_GXV13","{handler:'Validv_Gxv13',iparms:[]");
         setEventMetadata("VALIDV_GXV13",",oparms:[]}");
         setEventMetadata("VALIDV_GXV15","{handler:'Validv_Gxv15',iparms:[]");
         setEventMetadata("VALIDV_GXV15",",oparms:[]}");
         setEventMetadata("VALIDV_GXV19","{handler:'Validv_Gxv19',iparms:[]");
         setEventMetadata("VALIDV_GXV19",",oparms:[]}");
         setEventMetadata("VALIDV_GXV20","{handler:'Validv_Gxv20',iparms:[]");
         setEventMetadata("VALIDV_GXV20",",oparms:[]}");
         setEventMetadata("VALIDV_GXV21","{handler:'Validv_Gxv21',iparms:[]");
         setEventMetadata("VALIDV_GXV21",",oparms:[]}");
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
         AV17Code = "";
         AV18Name = "";
         AV38newName = "";
         AV41newCode = "";
         AV24Car = new GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem>( context, "SDTCarProductsItem", "mtaKB");
         AV56SDTInvoiceAddPaymentMethod = new GXBaseCollection<SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem>( context, "SDTInvoiceAddPaymentMethodItem", "mtaKB");
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV49SDTProductFiltered = new GXBaseCollection<SdtSDTProductsFiltered_SDTProductsFilteredItem>( context, "SDTProductsFilteredItem", "mtaKB");
         AV29SelectedId = new GxSimpleCollection<int>();
         AV42CarAux = new GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem>( context, "SDTCarProductsItem", "mtaKB");
         AV57SDTInvoiceAddPaymentMethodItem = new SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem(context);
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTextblock7_Jsonclick = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttSelectall_Jsonclick = "";
         AllproductsfilteredContainer = new GXWebGrid( context);
         sStyleString = "";
         bttRegistersale_Jsonclick = "";
         bttClearsale_Jsonclick = "";
         lblTextblock6_Jsonclick = "";
         lblTextblock1_Jsonclick = "";
         lblTextblock10_Jsonclick = "";
         lblTextblock3_Jsonclick = "";
         lblTextblock2_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
         CarproductsContainer = new GXWebGrid( context);
         bttAddpaymentmethod_Jsonclick = "";
         GridinvoiceaddpaymentmethodContainer = new GXWebGrid( context);
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV44Remove = "";
         AV93Remove_GXI = "";
         AV61PaymentMethodRemove = "";
         AV96Paymentmethodremove_GXI = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         scmdbuf = "";
         H001T2_A1BrandId = new int[1] ;
         H001T2_A2BrandName = new string[] {""} ;
         H001T3_A9SectorId = new int[1] ;
         H001T3_A10SectorName = new string[] {""} ;
         H001T4_A115PaymentMethodId = new int[1] ;
         H001T4_A116PaymentMethodDescription = new string[] {""} ;
         H001T4_A117PaymentMethodActive = new bool[] {false} ;
         AV26CarItem = new SdtSDTCarProducts_SDTCarProductsItem(context);
         GXt_SdtSDTCarProducts_SDTCarProductsItem1 = new SdtSDTCarProducts_SDTCarProductsItem(context);
         AV43window = new GXWindow();
         AV47Context = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         GXt_objcol_SdtSDTCarProducts_SDTCarProductsItem3 = new GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem>( context, "SDTCarProductsItem", "mtaKB");
         AV60PaymentMethod = new SdtPaymentMethod(context);
         AllproductsfilteredRow = new GXWebRow();
         GridinvoiceaddpaymentmethodRow = new GXWebRow();
         CarproductsRow = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subAllproductsfiltered_Linesclass = "";
         ROClassString = "";
         subCarproducts_Linesclass = "";
         CarproductsColumn = new GXWebColumn();
         sImgUrl = "";
         subGridinvoiceaddpaymentmethod_Linesclass = "";
         AllproductsfilteredColumn = new GXWebColumn();
         subCarproducts_Header = "";
         GridinvoiceaddpaymentmethodColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpregistersale__default(),
            new Object[][] {
                new Object[] {
               H001T2_A1BrandId, H001T2_A2BrandName
               }
               , new Object[] {
               H001T3_A9SectorId, H001T3_A10SectorName
               }
               , new Object[] {
               H001T4_A115PaymentMethodId, H001T4_A116PaymentMethodDescription, H001T4_A117PaymentMethodActive
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavCtlid_Enabled = 0;
         edtavCtlcode_Enabled = 0;
         edtavCtlname_Enabled = 0;
         edtavCtlstock1_Enabled = 0;
         edtavCtlretailprice_Enabled = 0;
         edtavCtlwholesaleprice_Enabled = 0;
         edtavCtlminiumquantitywholesale_Enabled = 0;
         edtavTotal_Enabled = 0;
         edtavCtlname1_Enabled = 0;
         edtavCtlproductminiumquantitywholesale_Enabled = 0;
         edtavCtlstock_Enabled = 0;
         edtavCtlunitprice1_Enabled = 0;
         edtavCtlsubtotal_Enabled = 0;
         edtavRemainingamount_Enabled = 0;
         edtavAmountreceivable_Enabled = 0;
         edtavCtlpaymentmethodid_Enabled = 0;
         edtavCtlpaymentmethoddescription_Enabled = 0;
         edtavCtlinvoicepaymentmethodimport_Enabled = 0;
         edtavCtlinvoicepaymentmethoddiscountimport_Enabled = 0;
         edtavCtlinvoicepaymentmethodrechargeimport_Enabled = 0;
      }

      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short ALLPRODUCTSFILTERED_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short subAllproductsfiltered_Collapsed ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subAllproductsfiltered_Backcolorstyle ;
      private short subGridinvoiceaddpaymentmethod_Backcolorstyle ;
      private short subCarproducts_Backcolorstyle ;
      private short GRIDINVOICEADDPAYMENTMETHOD_nEOF ;
      private short CARPRODUCTS_nEOF ;
      private short nGXWrapped ;
      private short subAllproductsfiltered_Backstyle ;
      private short subCarproducts_Backstyle ;
      private short subGridinvoiceaddpaymentmethod_Backstyle ;
      private short subAllproductsfiltered_Titlebackstyle ;
      private short subAllproductsfiltered_Allowselection ;
      private short subAllproductsfiltered_Allowhovering ;
      private short subAllproductsfiltered_Allowcollapsing ;
      private short subCarproducts_Allowselection ;
      private short subCarproducts_Allowhovering ;
      private short subCarproducts_Allowcollapsing ;
      private short subCarproducts_Collapsed ;
      private short subGridinvoiceaddpaymentmethod_Titlebackstyle ;
      private short subGridinvoiceaddpaymentmethod_Allowselection ;
      private short subGridinvoiceaddpaymentmethod_Allowhovering ;
      private short subGridinvoiceaddpaymentmethod_Allowcollapsing ;
      private short subGridinvoiceaddpaymentmethod_Collapsed ;
      private int nRC_GXsfl_35 ;
      private int nRC_GXsfl_79 ;
      private int nRC_GXsfl_139 ;
      private int subAllproductsfiltered_Rows ;
      private int nGXsfl_35_idx=1 ;
      private int AV15Supplier ;
      private int AV45Sector ;
      private int AV16Brand ;
      private int AV58PaymentMethodId ;
      private int nGXsfl_79_idx=1 ;
      private int nGXsfl_139_idx=1 ;
      private int AV30Position ;
      private int bttSelectall_Visible ;
      private int edtavName_Enabled ;
      private int edtavCode_Enabled ;
      private int AV71GXV1 ;
      private int divTablenewsale_Visible ;
      private int edtavTotal_Visible ;
      private int edtavTotal_Enabled ;
      private int AV79GXV9 ;
      private int divTablepaymentmethod_Visible ;
      private int edtavInvoicepaymentmethodimport_Enabled ;
      private int edtavRemainingamount_Enabled ;
      private int edtavAmountreceivable_Enabled ;
      private int AV86GXV16 ;
      private int gxdynajaxindex ;
      private int subAllproductsfiltered_Islastpage ;
      private int subGridinvoiceaddpaymentmethod_Islastpage ;
      private int subCarproducts_Islastpage ;
      private int edtavCtlid_Enabled ;
      private int edtavCtlcode_Enabled ;
      private int edtavCtlname_Enabled ;
      private int edtavCtlstock1_Enabled ;
      private int edtavCtlretailprice_Enabled ;
      private int edtavCtlwholesaleprice_Enabled ;
      private int edtavCtlminiumquantitywholesale_Enabled ;
      private int edtavCtlname1_Enabled ;
      private int edtavCtlproductminiumquantitywholesale_Enabled ;
      private int edtavCtlstock_Enabled ;
      private int edtavCtlunitprice1_Enabled ;
      private int edtavCtlsubtotal_Enabled ;
      private int edtavCtlpaymentmethodid_Enabled ;
      private int edtavCtlpaymentmethoddescription_Enabled ;
      private int edtavCtlinvoicepaymentmethodimport_Enabled ;
      private int edtavCtlinvoicepaymentmethoddiscountimport_Enabled ;
      private int edtavCtlinvoicepaymentmethodrechargeimport_Enabled ;
      private int ALLPRODUCTSFILTERED_nGridOutOfScope ;
      private int nGXsfl_35_fel_idx=1 ;
      private int nGXsfl_79_fel_idx=1 ;
      private int nGXsfl_139_fel_idx=1 ;
      private int AV54ProductId ;
      private int AV92GXV22 ;
      private int nGXsfl_79_bak_idx=1 ;
      private int AV46InvoiceId ;
      private int nGXsfl_139_bak_idx=1 ;
      private int AV34Employee ;
      private int AV94GXV23 ;
      private int AV95GXV24 ;
      private int GXt_int2 ;
      private int AV97GXV25 ;
      private int AV98GXV26 ;
      private int AV99GXV27 ;
      private int idxLst ;
      private int subAllproductsfiltered_Backcolor ;
      private int subAllproductsfiltered_Allbackcolor ;
      private int subCarproducts_Backcolor ;
      private int subCarproducts_Allbackcolor ;
      private int edtavRemove_Enabled ;
      private int edtavRemove_Visible ;
      private int edtavCtlquantity1_Enabled ;
      private int edtavCtlquantity1_Visible ;
      private int subGridinvoiceaddpaymentmethod_Backcolor ;
      private int subGridinvoiceaddpaymentmethod_Allbackcolor ;
      private int edtavPaymentmethodremove_Enabled ;
      private int edtavPaymentmethodremove_Visible ;
      private int subAllproductsfiltered_Titlebackcolor ;
      private int subAllproductsfiltered_Selectedindex ;
      private int subAllproductsfiltered_Selectioncolor ;
      private int subAllproductsfiltered_Hoveringcolor ;
      private int subCarproducts_Selectedindex ;
      private int subCarproducts_Selectioncolor ;
      private int subCarproducts_Hoveringcolor ;
      private int subGridinvoiceaddpaymentmethod_Titlebackcolor ;
      private int subGridinvoiceaddpaymentmethod_Selectedindex ;
      private int subGridinvoiceaddpaymentmethod_Selectioncolor ;
      private int subGridinvoiceaddpaymentmethod_Hoveringcolor ;
      private long ALLPRODUCTSFILTERED_nFirstRecordOnPage ;
      private long ALLPRODUCTSFILTERED_nCurrentRecord ;
      private long CARPRODUCTS_nCurrentRecord ;
      private long GRIDINVOICEADDPAYMENTMETHOD_nCurrentRecord ;
      private long ALLPRODUCTSFILTERED_nRecordCount ;
      private long GRIDINVOICEADDPAYMENTMETHOD_nFirstRecordOnPage ;
      private long CARPRODUCTS_nFirstRecordOnPage ;
      private decimal AV36Total ;
      private decimal AV59InvoicePaymentMethodImport ;
      private decimal AV55RemainingAmount ;
      private decimal AV64AmountReceivable ;
      private decimal GXt_decimal4 ;
      private decimal AV62ImportAux ;
      private decimal AV65DiscountImportAux ;
      private decimal AV66RechargeImportAux ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_35_idx="0001" ;
      private string sGXsfl_79_idx="0001" ;
      private string sGXsfl_139_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string subCarproducts_Class ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string divTable1_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttSelectall_Internalname ;
      private string bttSelectall_Jsonclick ;
      private string edtavName_Internalname ;
      private string edtavName_Jsonclick ;
      private string edtavCode_Internalname ;
      private string edtavCode_Jsonclick ;
      private string dynavBrand_Internalname ;
      private string dynavBrand_Jsonclick ;
      private string dynavSector_Internalname ;
      private string dynavSector_Jsonclick ;
      private string sStyleString ;
      private string subAllproductsfiltered_Internalname ;
      private string divTablenewsale_Internalname ;
      private string bttRegistersale_Internalname ;
      private string bttRegistersale_Jsonclick ;
      private string edtavTotal_Internalname ;
      private string edtavTotal_Jsonclick ;
      private string bttClearsale_Internalname ;
      private string bttClearsale_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string subCarproducts_Internalname ;
      private string divTablepaymentmethod_Internalname ;
      private string divTable3_Internalname ;
      private string bttAddpaymentmethod_Internalname ;
      private string bttAddpaymentmethod_Jsonclick ;
      private string dynavPaymentmethodid_Internalname ;
      private string dynavPaymentmethodid_Jsonclick ;
      private string edtavInvoicepaymentmethodimport_Internalname ;
      private string edtavInvoicepaymentmethodimport_Jsonclick ;
      private string edtavRemainingamount_Internalname ;
      private string edtavRemainingamount_Jsonclick ;
      private string edtavAmountreceivable_Internalname ;
      private string edtavAmountreceivable_Jsonclick ;
      private string divTable4_Internalname ;
      private string subGridinvoiceaddpaymentmethod_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavRemove_Internalname ;
      private string edtavPaymentmethodremove_Internalname ;
      private string gxwrpcisep ;
      private string scmdbuf ;
      private string edtavCtlid_Internalname ;
      private string edtavCtlcode_Internalname ;
      private string edtavCtlname_Internalname ;
      private string edtavCtlstock1_Internalname ;
      private string edtavCtlretailprice_Internalname ;
      private string edtavCtlwholesaleprice_Internalname ;
      private string edtavCtlminiumquantitywholesale_Internalname ;
      private string edtavCtlname1_Internalname ;
      private string edtavCtlproductminiumquantitywholesale_Internalname ;
      private string edtavCtlstock_Internalname ;
      private string edtavCtlunitprice1_Internalname ;
      private string edtavCtlsubtotal_Internalname ;
      private string edtavCtlpaymentmethodid_Internalname ;
      private string edtavCtlpaymentmethoddescription_Internalname ;
      private string edtavCtlinvoicepaymentmethodimport_Internalname ;
      private string edtavCtlinvoicepaymentmethoddiscountimport_Internalname ;
      private string edtavCtlinvoicepaymentmethodrechargeimport_Internalname ;
      private string sGXsfl_35_fel_idx="0001" ;
      private string sGXsfl_79_fel_idx="0001" ;
      private string sGXsfl_139_fel_idx="0001" ;
      private string edtavRemove_gximage ;
      private string edtavPaymentmethodremove_gximage ;
      private string subAllproductsfiltered_Class ;
      private string subAllproductsfiltered_Linesclass ;
      private string ROClassString ;
      private string edtavCtlid_Jsonclick ;
      private string edtavCtlcode_Jsonclick ;
      private string edtavCtlname_Jsonclick ;
      private string edtavCtlstock1_Jsonclick ;
      private string edtavCtlretailprice_Jsonclick ;
      private string edtavCtlwholesaleprice_Jsonclick ;
      private string edtavCtlminiumquantitywholesale_Jsonclick ;
      private string edtavCtlquantity1_Internalname ;
      private string subCarproducts_Linesclass ;
      private string divGrid1table_Internalname ;
      private string sImgUrl ;
      private string edtavRemove_Jsonclick ;
      private string edtavCtlname1_Jsonclick ;
      private string edtavCtlproductminiumquantitywholesale_Jsonclick ;
      private string edtavCtlstock_Jsonclick ;
      private string edtavCtlunitprice1_Jsonclick ;
      private string edtavCtlquantity1_Jsonclick ;
      private string edtavCtlsubtotal_Jsonclick ;
      private string subGridinvoiceaddpaymentmethod_Class ;
      private string subGridinvoiceaddpaymentmethod_Linesclass ;
      private string edtavPaymentmethodremove_Jsonclick ;
      private string edtavCtlpaymentmethodid_Jsonclick ;
      private string edtavCtlpaymentmethoddescription_Jsonclick ;
      private string edtavCtlinvoicepaymentmethodimport_Jsonclick ;
      private string edtavCtlinvoicepaymentmethoddiscountimport_Jsonclick ;
      private string edtavCtlinvoicepaymentmethodrechargeimport_Jsonclick ;
      private string subAllproductsfiltered_Header ;
      private string subCarproducts_Header ;
      private string subGridinvoiceaddpaymentmethod_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV37AllOk ;
      private bool AV63WasUsed ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_79_Refreshing=false ;
      private bool bGXsfl_139_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool bGXsfl_35_Refreshing=false ;
      private bool returnInSub ;
      private bool gx_BV79 ;
      private bool gx_BV35 ;
      private bool gx_BV139 ;
      private bool AV44Remove_IsBlob ;
      private bool AV61PaymentMethodRemove_IsBlob ;
      private string AV17Code ;
      private string AV18Name ;
      private string AV38newName ;
      private string AV41newCode ;
      private string AV93Remove_GXI ;
      private string AV96Paymentmethodremove_GXI ;
      private string AV44Remove ;
      private string AV61PaymentMethodRemove ;
      private GxSimpleCollection<int> AV29SelectedId ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid AllproductsfilteredContainer ;
      private GXWebGrid CarproductsContainer ;
      private GXWebGrid GridinvoiceaddpaymentmethodContainer ;
      private GXWebRow AllproductsfilteredRow ;
      private GXWebRow GridinvoiceaddpaymentmethodRow ;
      private GXWebRow CarproductsRow ;
      private GXWebColumn CarproductsColumn ;
      private GXWebColumn AllproductsfilteredColumn ;
      private GXWebColumn GridinvoiceaddpaymentmethodColumn ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavBrand ;
      private GXCombobox dynavSector ;
      private GXCombobox dynavPaymentmethodid ;
      private IDataStoreProvider pr_default ;
      private int[] H001T2_A1BrandId ;
      private string[] H001T2_A2BrandName ;
      private int[] H001T3_A9SectorId ;
      private string[] H001T3_A10SectorName ;
      private int[] H001T4_A115PaymentMethodId ;
      private string[] H001T4_A116PaymentMethodDescription ;
      private bool[] H001T4_A117PaymentMethodActive ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem> AV24Car ;
      private GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem> AV42CarAux ;
      private GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem> GXt_objcol_SdtSDTCarProducts_SDTCarProductsItem3 ;
      private GXBaseCollection<SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem> AV56SDTInvoiceAddPaymentMethod ;
      private GXBaseCollection<SdtSDTProductsFiltered_SDTProductsFilteredItem> AV49SDTProductFiltered ;
      private GXWebForm Form ;
      private GXWindow AV43window ;
      private SdtSDTCarProducts_SDTCarProductsItem AV26CarItem ;
      private SdtSDTCarProducts_SDTCarProductsItem GXt_SdtSDTCarProducts_SDTCarProductsItem1 ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession AV47Context ;
      private SdtPaymentMethod AV60PaymentMethod ;
      private SdtSDTInvoiceAddPaymentMethod_SDTInvoiceAddPaymentMethodItem AV57SDTInvoiceAddPaymentMethodItem ;
   }

   public class wpregistersale__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmH001T2;
          prmH001T2 = new Object[] {
          };
          Object[] prmH001T3;
          prmH001T3 = new Object[] {
          };
          Object[] prmH001T4;
          prmH001T4 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H001T2", "SELECT [BrandId], [BrandName] FROM [Brand] ORDER BY [BrandName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001T2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H001T3", "SELECT [SectorId], [SectorName] FROM [Sector] ORDER BY [SectorName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001T3,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H001T4", "SELECT [PaymentMethodId], [PaymentMethodDescription], [PaymentMethodActive] FROM [PaymentMethod] WHERE [PaymentMethodActive] = 1 ORDER BY [PaymentMethodDescription] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001T4,0, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                return;
       }
    }

 }

}
