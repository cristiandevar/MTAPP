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
   public class wpgeneratepurchasecopy1 : GXDataArea
   {
      public wpgeneratepurchasecopy1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public wpgeneratepurchasecopy1( IGxContext context )
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
         dynavSupplier = new GXCombobox();
         dynavBrand = new GXCombobox();
         dynavSector = new GXCombobox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vSUPPLIER") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvSUPPLIER2M2( ) ;
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
               GXDLVvBRAND2M2( ) ;
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
               GXDLVvSECTOR2M2( ) ;
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridfilteredproducts") == 0 )
            {
               gxnrGridfilteredproducts_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridfilteredproducts") == 0 )
            {
               gxgrGridfilteredproducts_refresh_invoke( ) ;
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Allvouchers") == 0 )
            {
               gxnrAllvouchers_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Allvouchers") == 0 )
            {
               gxgrAllvouchers_refresh_invoke( ) ;
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

      protected void gxnrGridfilteredproducts_newrow_invoke( )
      {
         nRC_GXsfl_49 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_49"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_49_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_49_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_49_idx = GetPar( "sGXsfl_49_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridfilteredproducts_newrow( ) ;
         /* End function gxnrGridfilteredproducts_newrow_invoke */
      }

      protected void gxgrGridfilteredproducts_refresh_invoke( )
      {
         subGridfilteredproducts_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridfilteredproducts_Rows"), "."), 18, MidpointRounding.ToEven));
         subCarproducts_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subCarproducts_Rows"), "."), 18, MidpointRounding.ToEven));
         subAllvouchers_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subAllvouchers_Rows"), "."), 18, MidpointRounding.ToEven));
         dynavSupplier.FromJSonString( GetNextPar( ));
         AV29Supplier = (int)(Math.Round(NumberUtil.Val( GetPar( "Supplier"), "."), 18, MidpointRounding.ToEven));
         dynavBrand.FromJSonString( GetNextPar( ));
         AV9Brand = (int)(Math.Round(NumberUtil.Val( GetPar( "Brand"), "."), 18, MidpointRounding.ToEven));
         dynavSector.FromJSonString( GetNextPar( ));
         AV31Sector = (int)(Math.Round(NumberUtil.Val( GetPar( "Sector"), "."), 18, MidpointRounding.ToEven));
         AV6NewName = GetPar( "NewName");
         AV5NewCode = GetPar( "NewCode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridfilteredproducts_refresh( subGridfilteredproducts_Rows, subCarproducts_Rows, subAllvouchers_Rows, AV29Supplier, AV9Brand, AV31Sector, AV6NewName, AV5NewCode) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridfilteredproducts_refresh_invoke */
      }

      protected void gxnrCarproducts_newrow_invoke( )
      {
         nRC_GXsfl_80 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_80"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_80_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_80_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_80_idx = GetPar( "sGXsfl_80_idx");
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
         subGridfilteredproducts_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridfilteredproducts_Rows"), "."), 18, MidpointRounding.ToEven));
         subCarproducts_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subCarproducts_Rows"), "."), 18, MidpointRounding.ToEven));
         subAllvouchers_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subAllvouchers_Rows"), "."), 18, MidpointRounding.ToEven));
         dynavSupplier.FromJSonString( GetNextPar( ));
         AV29Supplier = (int)(Math.Round(NumberUtil.Val( GetPar( "Supplier"), "."), 18, MidpointRounding.ToEven));
         dynavBrand.FromJSonString( GetNextPar( ));
         AV9Brand = (int)(Math.Round(NumberUtil.Val( GetPar( "Brand"), "."), 18, MidpointRounding.ToEven));
         dynavSector.FromJSonString( GetNextPar( ));
         AV31Sector = (int)(Math.Round(NumberUtil.Val( GetPar( "Sector"), "."), 18, MidpointRounding.ToEven));
         AV6NewName = GetPar( "NewName");
         AV5NewCode = GetPar( "NewCode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrCarproducts_refresh( subGridfilteredproducts_Rows, subCarproducts_Rows, subAllvouchers_Rows, AV29Supplier, AV9Brand, AV31Sector, AV6NewName, AV5NewCode) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrCarproducts_refresh_invoke */
      }

      protected void gxnrAllvouchers_newrow_invoke( )
      {
         nRC_GXsfl_107 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_107"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_107_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_107_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_107_idx = GetPar( "sGXsfl_107_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrAllvouchers_newrow( ) ;
         /* End function gxnrAllvouchers_newrow_invoke */
      }

      protected void gxgrAllvouchers_refresh_invoke( )
      {
         subGridfilteredproducts_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridfilteredproducts_Rows"), "."), 18, MidpointRounding.ToEven));
         subCarproducts_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subCarproducts_Rows"), "."), 18, MidpointRounding.ToEven));
         subAllvouchers_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subAllvouchers_Rows"), "."), 18, MidpointRounding.ToEven));
         dynavSupplier.FromJSonString( GetNextPar( ));
         AV29Supplier = (int)(Math.Round(NumberUtil.Val( GetPar( "Supplier"), "."), 18, MidpointRounding.ToEven));
         dynavBrand.FromJSonString( GetNextPar( ));
         AV9Brand = (int)(Math.Round(NumberUtil.Val( GetPar( "Brand"), "."), 18, MidpointRounding.ToEven));
         dynavSector.FromJSonString( GetNextPar( ));
         AV31Sector = (int)(Math.Round(NumberUtil.Val( GetPar( "Sector"), "."), 18, MidpointRounding.ToEven));
         AV6NewName = GetPar( "NewName");
         AV5NewCode = GetPar( "NewCode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrAllvouchers_refresh( subGridfilteredproducts_Rows, subCarproducts_Rows, subAllvouchers_Rows, AV29Supplier, AV9Brand, AV31Sector, AV6NewName, AV5NewCode) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrAllvouchers_refresh_invoke */
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
         PA2M2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2M2( ) ;
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
         context.AddJavascriptSource("Switch/switch.min.js", "", false, true);
         context.AddJavascriptSource("Switch/switch.min.js", "", false, true);
         context.AddJavascriptSource("Switch/switch.min.js", "", false, true);
         context.AddJavascriptSource("Switch/switch.min.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpgeneratepurchasecopy1.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vNEWNAME", AV6NewName);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6NewName, "")), context));
         GxWebStd.gx_hidden_field( context, "vNEWCODE", AV5NewCode);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV5NewCode, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Car", AV10Car);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Car", AV10Car);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Sdtpurchaseordergeneratelist", AV27SDTPurchaseOrderGenerateList);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Sdtpurchaseordergeneratelist", AV27SDTPurchaseOrderGenerateList);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Sdtproductsfiltered", AV37SDTProductsFiltered);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Sdtproductsfiltered", AV37SDTProductsFiltered);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_49", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_49), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_80", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_80), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_107", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_107), 8, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vNECESARY", AV15Necesary);
         GxWebStd.gx_boolean_hidden_field( context, "vORDERED", AV18Ordered);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCAR", AV10Car);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCAR", AV10Car);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSUPPLIERSID", AV30SuppliersId);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSUPPLIERSID", AV30SuppliersId);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vORDERS", AV19Orders);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vORDERS", AV19Orders);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTPURCHASEORDERGENERATELIST", AV27SDTPurchaseOrderGenerateList);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTPURCHASEORDERGENERATELIST", AV27SDTPurchaseOrderGenerateList);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSELECTEDID", AV28SelectedId);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSELECTEDID", AV28SelectedId);
         }
         GxWebStd.gx_hidden_field( context, "vNEWNAME", AV6NewName);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6NewName, "")), context));
         GxWebStd.gx_hidden_field( context, "vNEWCODE", AV5NewCode);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV5NewCode, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTPRODUCTSFILTERED", AV37SDTProductsFiltered);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTPRODUCTSFILTERED", AV37SDTProductsFiltered);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCARITEM", AV12CarItem);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCARITEM", AV12CarItem);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCARAUX", AV11CarAux);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCARAUX", AV11CarAux);
         }
         GxWebStd.gx_hidden_field( context, "GRIDFILTEREDPRODUCTS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDFILTEREDPRODUCTS_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CARPRODUCTS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(CARPRODUCTS_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ALLVOUCHERS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(ALLVOUCHERS_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDFILTEREDPRODUCTS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDFILTEREDPRODUCTS_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CARPRODUCTS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(CARPRODUCTS_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ALLVOUCHERS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(ALLVOUCHERS_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDFILTEREDPRODUCTS_Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridfilteredproducts_Collapsed), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "NECESARY_Enabled", StringUtil.BoolToStr( Necesary_Enabled));
         GxWebStd.gx_hidden_field( context, "NECESARY_Captionclass", StringUtil.RTrim( Necesary_Captionclass));
         GxWebStd.gx_hidden_field( context, "NECESARY_Captionstyle", StringUtil.RTrim( Necesary_Captionstyle));
         GxWebStd.gx_hidden_field( context, "NECESARY_Captionposition", StringUtil.RTrim( Necesary_Captionposition));
         GxWebStd.gx_hidden_field( context, "ORDERED_Enabled", StringUtil.BoolToStr( Ordered_Enabled));
         GxWebStd.gx_hidden_field( context, "ORDERED_Captionclass", StringUtil.RTrim( Ordered_Captionclass));
         GxWebStd.gx_hidden_field( context, "ORDERED_Captionstyle", StringUtil.RTrim( Ordered_Captionstyle));
         GxWebStd.gx_hidden_field( context, "ORDERED_Captionposition", StringUtil.RTrim( Ordered_Captionposition));
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
            WE2M2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2M2( ) ;
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
         return formatLink("wpgeneratepurchasecopy1.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WPGeneratePurchaseCopy1" ;
      }

      public override string GetPgmdesc( )
      {
         return "WPGenerate Purchase Copy1" ;
      }

      protected void WB2M0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "Middle", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Generate Purchase Orders", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WPGeneratePurchaseCopy1.htm");
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
            GxWebStd.gx_div_start( context, divTable1_Internalname, divTable1_Visible, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavCode_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCode_Internalname, "Code", "col-xs-12 attribute-filterLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_49_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCode_Internalname, AV13Code, StringUtil.RTrim( context.localUtil.Format( AV13Code, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCode_Jsonclick, 0, "attribute-filter", "", "", "", "", 1, edtavCode_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "GeneXusUnanimo\\Code", "left", true, "", "HLP_WPGeneratePurchaseCopy1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavName_Internalname, "Name", "col-xs-12 attribute-filterLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'" + sGXsfl_49_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavName_Internalname, AV14Name, StringUtil.RTrim( context.localUtil.Format( AV14Name, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavName_Jsonclick, 0, "attribute-filter", "", "", "", "", 1, edtavName_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Name", "left", true, "", "HLP_WPGeneratePurchaseCopy1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavSupplier_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavSupplier_Internalname, "Supplier", "col-xs-12 attribute-filterLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_49_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavSupplier, dynavSupplier_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV29Supplier), 6, 0)), 1, dynavSupplier_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavSupplier.Enabled, 0, 0, 0, "em", 0, "", "", "attribute-filter", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "", true, 0, "HLP_WPGeneratePurchaseCopy1.htm");
            dynavSupplier.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29Supplier), 6, 0));
            AssignProp("", false, dynavSupplier_Internalname, "Values", (string)(dynavSupplier.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavBrand_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavBrand_Internalname, "Brand", "col-xs-12 attribute-filterLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'" + sGXsfl_49_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavBrand, dynavBrand_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV9Brand), 6, 0)), 1, dynavBrand_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavBrand.Enabled, 0, 0, 0, "em", 0, "", "", "attribute-filter", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "", true, 0, "HLP_WPGeneratePurchaseCopy1.htm");
            dynavBrand.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV9Brand), 6, 0));
            AssignProp("", false, dynavBrand_Internalname, "Values", (string)(dynavBrand.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavSector_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavSector_Internalname, "Sector", "col-xs-12 attribute-filterLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'" + sGXsfl_49_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavSector, dynavSector_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV31Sector), 6, 0)), 1, dynavSector_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavSector.Enabled, 0, 0, 0, "em", 0, "", "", "attribute-filter", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "", true, 0, "HLP_WPGeneratePurchaseCopy1.htm");
            dynavSector.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31Sector), 6, 0));
            AssignProp("", false, dynavSector_Internalname, "Values", (string)(dynavSector.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", -1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+Necesary_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, Necesary_Internalname, "Just Necesary", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* User Defined Control */
            ucNecesary.SetProperty("Attribute", AV15Necesary);
            ucNecesary.SetProperty("CaptionClass", Necesary_Captionclass);
            ucNecesary.SetProperty("CaptionStyle", Necesary_Captionstyle);
            ucNecesary.SetProperty("CaptionPosition", Necesary_Captionposition);
            ucNecesary.Render(context, "sdswitch", Necesary_Internalname, "NECESARYContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", -1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+Ordered_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, Ordered_Internalname, "Not Ordered", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* User Defined Control */
            ucOrdered.SetProperty("Attribute", AV18Ordered);
            ucOrdered.SetProperty("CaptionClass", Ordered_Captionclass);
            ucOrdered.SetProperty("CaptionStyle", Ordered_Captionstyle);
            ucOrdered.SetProperty("CaptionPosition", Ordered_Captionposition);
            ucOrdered.Render(context, "sdswitch", Ordered_Internalname, "ORDEREDContainer");
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
            GridfilteredproductsContainer.SetWrapped(nGXWrapped);
            StartGridControl49( ) ;
         }
         if ( wbEnd == 49 )
         {
            wbEnd = 0;
            nRC_GXsfl_49 = (int)(nGXsfl_49_idx-1);
            if ( GridfilteredproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridfilteredproductsContainer.AddObjectProperty("GRIDFILTEREDPRODUCTS_nEOF", GRIDFILTEREDPRODUCTS_nEOF);
               GridfilteredproductsContainer.AddObjectProperty("GRIDFILTEREDPRODUCTS_nFirstRecordOnPage", GRIDFILTEREDPRODUCTS_nFirstRecordOnPage);
               AV40GXV1 = nGXsfl_49_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridfilteredproductsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridfilteredproducts", GridfilteredproductsContainer, subGridfilteredproducts_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridfilteredproductsContainerData", GridfilteredproductsContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridfilteredproductsContainerData"+"V", GridfilteredproductsContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridfilteredproductsContainerData"+"V"+"\" value='"+GridfilteredproductsContainer.GridValuesHidden()+"'/>") ;
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
            GxWebStd.gx_div_start( context, divTable2_Internalname, divTable2_Visible, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 mb-2", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttGenerateorder_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(49), 2, 0)+","+"null"+");", "Generate", bttGenerateorder_Jsonclick, 5, "Generate", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'GENERATEORDER\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPGeneratePurchaseCopy1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 mb-2", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttClearorder_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(49), 2, 0)+","+"null"+");", "Clear", bttClearorder_Jsonclick, 5, "Clear", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CLEARORDER\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPGeneratePurchaseCopy1.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Product", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPGeneratePurchaseCopy1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Current Stock", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPGeneratePurchaseCopy1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Quantity required", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPGeneratePurchaseCopy1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Action", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPGeneratePurchaseCopy1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            CarproductsContainer.SetIsFreestyle(true);
            CarproductsContainer.SetWrapped(nGXWrapped);
            StartGridControl80( ) ;
         }
         if ( wbEnd == 80 )
         {
            wbEnd = 0;
            nRC_GXsfl_80 = (int)(nGXsfl_80_idx-1);
            if ( CarproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               CarproductsContainer.AddObjectProperty("CARPRODUCTS_nEOF", CARPRODUCTS_nEOF);
               CarproductsContainer.AddObjectProperty("CARPRODUCTS_nFirstRecordOnPage", CARPRODUCTS_nFirstRecordOnPage);
               AV50GXV11 = nGXsfl_80_idx;
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
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable3_Internalname, divTable3_Visible, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "Middle", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Summary", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-02", 0, "", 1, 1, 0, 0, "HLP_WPGeneratePurchaseCopy1.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttGenerateneworder_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(49), 2, 0)+","+"null"+");", "New Order", bttGenerateneworder_Jsonclick, 5, "New Order", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'GENERATENEWORDER\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPGeneratePurchaseCopy1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            AllvouchersContainer.SetWrapped(nGXWrapped);
            StartGridControl107( ) ;
         }
         if ( wbEnd == 107 )
         {
            wbEnd = 0;
            nRC_GXsfl_107 = (int)(nGXsfl_107_idx-1);
            if ( AllvouchersContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AllvouchersContainer.AddObjectProperty("ALLVOUCHERS_nEOF", ALLVOUCHERS_nEOF);
               AllvouchersContainer.AddObjectProperty("ALLVOUCHERS_nFirstRecordOnPage", ALLVOUCHERS_nFirstRecordOnPage);
               AV54GXV15 = nGXsfl_107_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"AllvouchersContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Allvouchers", AllvouchersContainer, subAllvouchers_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "AllvouchersContainerData", AllvouchersContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "AllvouchersContainerData"+"V", AllvouchersContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"AllvouchersContainerData"+"V"+"\" value='"+AllvouchersContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 49 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridfilteredproductsContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  GridfilteredproductsContainer.AddObjectProperty("GRIDFILTEREDPRODUCTS_nEOF", GRIDFILTEREDPRODUCTS_nEOF);
                  GridfilteredproductsContainer.AddObjectProperty("GRIDFILTEREDPRODUCTS_nFirstRecordOnPage", GRIDFILTEREDPRODUCTS_nFirstRecordOnPage);
                  AV40GXV1 = nGXsfl_49_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridfilteredproductsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridfilteredproducts", GridfilteredproductsContainer, subGridfilteredproducts_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridfilteredproductsContainerData", GridfilteredproductsContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridfilteredproductsContainerData"+"V", GridfilteredproductsContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridfilteredproductsContainerData"+"V"+"\" value='"+GridfilteredproductsContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         if ( wbEnd == 80 )
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
                  CarproductsContainer.AddObjectProperty("CARPRODUCTS_nEOF", CARPRODUCTS_nEOF);
                  CarproductsContainer.AddObjectProperty("CARPRODUCTS_nFirstRecordOnPage", CARPRODUCTS_nFirstRecordOnPage);
                  AV50GXV11 = nGXsfl_80_idx;
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
         if ( wbEnd == 107 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( AllvouchersContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AllvouchersContainer.AddObjectProperty("ALLVOUCHERS_nEOF", ALLVOUCHERS_nEOF);
                  AllvouchersContainer.AddObjectProperty("ALLVOUCHERS_nFirstRecordOnPage", ALLVOUCHERS_nFirstRecordOnPage);
                  AV54GXV15 = nGXsfl_107_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"AllvouchersContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Allvouchers", AllvouchersContainer, subAllvouchers_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "AllvouchersContainerData", AllvouchersContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "AllvouchersContainerData"+"V", AllvouchersContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"AllvouchersContainerData"+"V"+"\" value='"+AllvouchersContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START2M2( )
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
            Form.Meta.addItem("description", "WPGenerate Purchase Copy1", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2M0( ) ;
      }

      protected void WS2M2( )
      {
         START2M2( ) ;
         EVT2M2( ) ;
      }

      protected void EVT2M2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "VNECESARY.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E112M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VORDERED.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E122M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'GENERATEORDER'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'GenerateOrder' */
                              E132M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CLEARORDER'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'ClearOrder' */
                              E142M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VBRAND.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E152M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VSUPPLIER.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E162M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VNAME.CONTROLVALUECHANGING") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E172M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VCODE.CONTROLVALUECHANGING") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E182M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VSECTOR.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E192M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'GENERATENEWORDER'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'GenerateNewOrder' */
                              E202M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVE'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Remove' */
                              E212M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDFILTEREDPRODUCTSPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRIDFILTEREDPRODUCTSPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgridfilteredproducts_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgridfilteredproducts_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgridfilteredproducts_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgridfilteredproducts_lastpage( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "CARPRODUCTSPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "CARPRODUCTSPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subcarproducts_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subcarproducts_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subcarproducts_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subcarproducts_lastpage( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ALLVOUCHERSPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "ALLVOUCHERSPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 suballvouchers_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 suballvouchers_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 suballvouchers_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 suballvouchers_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 8), "'REMOVE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 16), "CARPRODUCTS.LOAD") == 0 ) )
                           {
                              nGXsfl_80_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_80_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_80_idx), 4, 0), 4, "0");
                              SubsflControlProps_804( ) ;
                              AV50GXV11 = (int)(nGXsfl_80_idx+CARPRODUCTS_nFirstRecordOnPage);
                              if ( ( AV10Car.Count >= AV50GXV11 ) && ( AV50GXV11 > 0 ) )
                              {
                                 AV10Car.CurrentItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV10Car.Item(AV50GXV11));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "'REMOVE'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'Remove' */
                                    E212M2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "CARPRODUCTS.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E222M4 ();
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
                           else if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 23), "CTLSDTVOUCHERLINK.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 20), "CTLDETAILSLINK.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 16), "ALLVOUCHERS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 20), "CTLDETAILSLINK.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 23), "CTLSDTVOUCHERLINK.CLICK") == 0 ) )
                           {
                              nGXsfl_107_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_107_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_107_idx), 4, 0), 4, "0");
                              SubsflControlProps_1073( ) ;
                              AV54GXV15 = (int)(nGXsfl_107_idx+ALLVOUCHERS_nFirstRecordOnPage);
                              if ( ( AV27SDTPurchaseOrderGenerateList.Count >= AV54GXV15 ) && ( AV54GXV15 > 0 ) )
                              {
                                 AV27SDTPurchaseOrderGenerateList.CurrentItem = ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV27SDTPurchaseOrderGenerateList.Item(AV54GXV15));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "CTLSDTVOUCHERLINK.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E232M2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "CTLDETAILSLINK.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E242M2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ALLVOUCHERS.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E252M3 ();
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
                           else if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "CTLNAME.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 25), "GRIDFILTEREDPRODUCTS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "CTLNAME.CLICK") == 0 ) )
                           {
                              nGXsfl_49_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_49_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_49_idx), 4, 0), 4, "0");
                              SubsflControlProps_492( ) ;
                              AV40GXV1 = (int)(nGXsfl_49_idx+GRIDFILTEREDPRODUCTS_nFirstRecordOnPage);
                              if ( ( AV37SDTProductsFiltered.Count >= AV40GXV1 ) && ( AV40GXV1 > 0 ) )
                              {
                                 AV37SDTProductsFiltered.CurrentItem = ((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV37SDTProductsFiltered.Item(AV40GXV1));
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
                                    E262M2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "CTLNAME.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E272M2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDFILTEREDPRODUCTS.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E282M2 ();
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

      protected void WE2M2( )
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

      protected void PA2M2( )
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
               GX_FocusControl = edtavCode_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVvSUPPLIER2M2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvSUPPLIER_data2M2( ) ;
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

      protected void GXVvSUPPLIER_html2M2( )
      {
         int gxdynajaxvalue;
         GXDLVvSUPPLIER_data2M2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavSupplier.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavSupplier.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 6, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvSUPPLIER_data2M2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(None)");
         /* Using cursor H002M2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H002M2_A4SupplierId[0]), 6, 0, ".", "")));
            gxdynajaxctrldescr.Add(H002M2_A5SupplierName[0]);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void GXDLVvBRAND2M2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvBRAND_data2M2( ) ;
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

      protected void GXVvBRAND_html2M2( )
      {
         int gxdynajaxvalue;
         GXDLVvBRAND_data2M2( ) ;
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

      protected void GXDLVvBRAND_data2M2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(None)");
         /* Using cursor H002M3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H002M3_A1BrandId[0]), 6, 0, ".", "")));
            gxdynajaxctrldescr.Add(H002M3_A2BrandName[0]);
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void GXDLVvSECTOR2M2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvSECTOR_data2M2( ) ;
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

      protected void GXVvSECTOR_html2M2( )
      {
         int gxdynajaxvalue;
         GXDLVvSECTOR_data2M2( ) ;
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

      protected void GXDLVvSECTOR_data2M2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(None)");
         /* Using cursor H002M4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H002M4_A9SectorId[0]), 6, 0, ".", "")));
            gxdynajaxctrldescr.Add(H002M4_A10SectorName[0]);
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void gxnrGridfilteredproducts_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_492( ) ;
         while ( nGXsfl_49_idx <= nRC_GXsfl_49 )
         {
            sendrow_492( ) ;
            nGXsfl_49_idx = ((subGridfilteredproducts_Islastpage==1)&&(nGXsfl_49_idx+1>subGridfilteredproducts_fnc_Recordsperpage( )) ? 1 : nGXsfl_49_idx+1);
            sGXsfl_49_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_49_idx), 4, 0), 4, "0");
            SubsflControlProps_492( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridfilteredproductsContainer)) ;
         /* End function gxnrGridfilteredproducts_newrow */
      }

      protected void gxnrAllvouchers_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1073( ) ;
         while ( nGXsfl_107_idx <= nRC_GXsfl_107 )
         {
            sendrow_1073( ) ;
            nGXsfl_107_idx = ((subAllvouchers_Islastpage==1)&&(nGXsfl_107_idx+1>subAllvouchers_fnc_Recordsperpage( )) ? 1 : nGXsfl_107_idx+1);
            sGXsfl_107_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_107_idx), 4, 0), 4, "0");
            SubsflControlProps_1073( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( AllvouchersContainer)) ;
         /* End function gxnrAllvouchers_newrow */
      }

      protected void gxnrCarproducts_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_804( ) ;
         while ( nGXsfl_80_idx <= nRC_GXsfl_80 )
         {
            sendrow_804( ) ;
            nGXsfl_80_idx = ((subCarproducts_Islastpage==1)&&(nGXsfl_80_idx+1>subCarproducts_fnc_Recordsperpage( )) ? 1 : nGXsfl_80_idx+1);
            sGXsfl_80_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_80_idx), 4, 0), 4, "0");
            SubsflControlProps_804( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( CarproductsContainer)) ;
         /* End function gxnrCarproducts_newrow */
      }

      protected void gxgrGridfilteredproducts_refresh( int subGridfilteredproducts_Rows ,
                                                       int subCarproducts_Rows ,
                                                       int subAllvouchers_Rows ,
                                                       int AV29Supplier ,
                                                       int AV9Brand ,
                                                       int AV31Sector ,
                                                       string AV6NewName ,
                                                       string AV5NewCode )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDFILTEREDPRODUCTS_nCurrentRecord = 0;
         RF2M2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridfilteredproducts_refresh */
      }

      protected void gxgrCarproducts_refresh( int subGridfilteredproducts_Rows ,
                                              int subCarproducts_Rows ,
                                              int subAllvouchers_Rows ,
                                              int AV29Supplier ,
                                              int AV9Brand ,
                                              int AV31Sector ,
                                              string AV6NewName ,
                                              string AV5NewCode )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         CARPRODUCTS_nCurrentRecord = 0;
         RF2M4( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrCarproducts_refresh */
      }

      protected void gxgrAllvouchers_refresh( int subGridfilteredproducts_Rows ,
                                              int subCarproducts_Rows ,
                                              int subAllvouchers_Rows ,
                                              int AV29Supplier ,
                                              int AV9Brand ,
                                              int AV31Sector ,
                                              string AV6NewName ,
                                              string AV5NewCode )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         ALLVOUCHERS_nCurrentRecord = 0;
         RF2M3( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrAllvouchers_refresh */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXVvSUPPLIER_html2M2( ) ;
            GXVvBRAND_html2M2( ) ;
            GXVvSECTOR_html2M2( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavSupplier.ItemCount > 0 )
         {
            AV29Supplier = (int)(Math.Round(NumberUtil.Val( dynavSupplier.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV29Supplier), 6, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV29Supplier", StringUtil.LTrimStr( (decimal)(AV29Supplier), 6, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavSupplier.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29Supplier), 6, 0));
            AssignProp("", false, dynavSupplier_Internalname, "Values", dynavSupplier.ToJavascriptSource(), true);
         }
         if ( dynavBrand.ItemCount > 0 )
         {
            AV9Brand = (int)(Math.Round(NumberUtil.Val( dynavBrand.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV9Brand), 6, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV9Brand", StringUtil.LTrimStr( (decimal)(AV9Brand), 6, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavBrand.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV9Brand), 6, 0));
            AssignProp("", false, dynavBrand_Internalname, "Values", dynavBrand.ToJavascriptSource(), true);
         }
         if ( dynavSector.ItemCount > 0 )
         {
            AV31Sector = (int)(Math.Round(NumberUtil.Val( dynavSector.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV31Sector), 6, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV31Sector", StringUtil.LTrimStr( (decimal)(AV31Sector), 6, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavSector.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31Sector), 6, 0));
            AssignProp("", false, dynavSector_Internalname, "Values", dynavSector.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF2M2( ) ;
         RF2M4( ) ;
         RF2M3( ) ;
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
         AssignProp("", false, edtavCtlid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlid_Enabled), 5, 0), !bGXsfl_49_Refreshing);
         edtavCtlcode_Enabled = 0;
         AssignProp("", false, edtavCtlcode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcode_Enabled), 5, 0), !bGXsfl_49_Refreshing);
         edtavCtlname_Enabled = 0;
         AssignProp("", false, edtavCtlname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname_Enabled), 5, 0), !bGXsfl_49_Refreshing);
         edtavCtlstock1_Enabled = 0;
         AssignProp("", false, edtavCtlstock1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlstock1_Enabled), 5, 0), !bGXsfl_49_Refreshing);
         edtavCtlminiumstock_Enabled = 0;
         AssignProp("", false, edtavCtlminiumstock_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlminiumstock_Enabled), 5, 0), !bGXsfl_49_Refreshing);
         edtavCtlcostprice_Enabled = 0;
         AssignProp("", false, edtavCtlcostprice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcostprice_Enabled), 5, 0), !bGXsfl_49_Refreshing);
         edtavCtlsupplier_Enabled = 0;
         AssignProp("", false, edtavCtlsupplier_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsupplier_Enabled), 5, 0), !bGXsfl_49_Refreshing);
         edtavCtlbrand_Enabled = 0;
         AssignProp("", false, edtavCtlbrand_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlbrand_Enabled), 5, 0), !bGXsfl_49_Refreshing);
         edtavCtlsector_Enabled = 0;
         AssignProp("", false, edtavCtlsector_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsector_Enabled), 5, 0), !bGXsfl_49_Refreshing);
         edtavCtlname1_Enabled = 0;
         AssignProp("", false, edtavCtlname1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname1_Enabled), 5, 0), !bGXsfl_80_Refreshing);
         edtavCtlstock_Enabled = 0;
         AssignProp("", false, edtavCtlstock_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlstock_Enabled), 5, 0), !bGXsfl_80_Refreshing);
         edtavCtlpurchaseorderid_Enabled = 0;
         AssignProp("", false, edtavCtlpurchaseorderid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlpurchaseorderid_Enabled), 5, 0), !bGXsfl_107_Refreshing);
         edtavCtlsuppliername_Enabled = 0;
         AssignProp("", false, edtavCtlsuppliername_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsuppliername_Enabled), 5, 0), !bGXsfl_107_Refreshing);
         edtavCtlpurchaseorderdetailsquantity_Enabled = 0;
         AssignProp("", false, edtavCtlpurchaseorderdetailsquantity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlpurchaseorderdetailsquantity_Enabled), 5, 0), !bGXsfl_107_Refreshing);
         edtavCtldetailslink_Enabled = 0;
         AssignProp("", false, edtavCtldetailslink_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtldetailslink_Enabled), 5, 0), !bGXsfl_107_Refreshing);
         edtavCtlsdtvoucherlink_Enabled = 0;
         AssignProp("", false, edtavCtlsdtvoucherlink_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsdtvoucherlink_Enabled), 5, 0), !bGXsfl_107_Refreshing);
      }

      protected void RF2M2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridfilteredproductsContainer.ClearRows();
         }
         wbStart = 49;
         nGXsfl_49_idx = 1;
         sGXsfl_49_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_49_idx), 4, 0), 4, "0");
         SubsflControlProps_492( ) ;
         bGXsfl_49_Refreshing = true;
         GridfilteredproductsContainer.AddObjectProperty("GridName", "Gridfilteredproducts");
         GridfilteredproductsContainer.AddObjectProperty("CmpContext", "");
         GridfilteredproductsContainer.AddObjectProperty("InMasterPage", "false");
         GridfilteredproductsContainer.AddObjectProperty("Class", "PromptGrid");
         GridfilteredproductsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridfilteredproductsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridfilteredproductsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridfilteredproducts_Backcolorstyle), 1, 0, ".", "")));
         GridfilteredproductsContainer.PageSize = subGridfilteredproducts_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_492( ) ;
            E282M2 ();
            if ( ( subGridfilteredproducts_Islastpage == 0 ) && ( GRIDFILTEREDPRODUCTS_nCurrentRecord > 0 ) && ( GRIDFILTEREDPRODUCTS_nGridOutOfScope == 0 ) && ( nGXsfl_49_idx == 1 ) )
            {
               GRIDFILTEREDPRODUCTS_nCurrentRecord = 0;
               GRIDFILTEREDPRODUCTS_nGridOutOfScope = 1;
               subgridfilteredproducts_firstpage( ) ;
               E282M2 ();
            }
            wbEnd = 49;
            WB2M0( ) ;
         }
         bGXsfl_49_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2M2( )
      {
         GxWebStd.gx_hidden_field( context, "vNEWNAME", AV6NewName);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6NewName, "")), context));
         GxWebStd.gx_hidden_field( context, "vNEWCODE", AV5NewCode);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV5NewCode, "")), context));
      }

      protected void RF2M3( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            AllvouchersContainer.ClearRows();
         }
         wbStart = 107;
         nGXsfl_107_idx = 1;
         sGXsfl_107_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_107_idx), 4, 0), 4, "0");
         SubsflControlProps_1073( ) ;
         bGXsfl_107_Refreshing = true;
         AllvouchersContainer.AddObjectProperty("GridName", "Allvouchers");
         AllvouchersContainer.AddObjectProperty("CmpContext", "");
         AllvouchersContainer.AddObjectProperty("InMasterPage", "false");
         AllvouchersContainer.AddObjectProperty("Class", "PromptGrid");
         AllvouchersContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         AllvouchersContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         AllvouchersContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAllvouchers_Backcolorstyle), 1, 0, ".", "")));
         AllvouchersContainer.PageSize = subAllvouchers_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1073( ) ;
            E252M3 ();
            if ( ( subAllvouchers_Islastpage == 0 ) && ( ALLVOUCHERS_nCurrentRecord > 0 ) && ( ALLVOUCHERS_nGridOutOfScope == 0 ) && ( nGXsfl_107_idx == 1 ) )
            {
               ALLVOUCHERS_nCurrentRecord = 0;
               ALLVOUCHERS_nGridOutOfScope = 1;
               suballvouchers_firstpage( ) ;
               E252M3 ();
            }
            wbEnd = 107;
            WB2M0( ) ;
         }
         bGXsfl_107_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2M3( )
      {
      }

      protected void RF2M4( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            CarproductsContainer.ClearRows();
         }
         wbStart = 80;
         nGXsfl_80_idx = 1;
         sGXsfl_80_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_80_idx), 4, 0), 4, "0");
         SubsflControlProps_804( ) ;
         bGXsfl_80_Refreshing = true;
         CarproductsContainer.AddObjectProperty("GridName", "Carproducts");
         CarproductsContainer.AddObjectProperty("CmpContext", "");
         CarproductsContainer.AddObjectProperty("InMasterPage", "false");
         CarproductsContainer.AddObjectProperty("Class", StringUtil.RTrim( "PromptGrid"));
         CarproductsContainer.AddObjectProperty("Class", "PromptGrid");
         CarproductsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         CarproductsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         CarproductsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subCarproducts_Backcolorstyle), 1, 0, ".", "")));
         CarproductsContainer.PageSize = subCarproducts_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_804( ) ;
            E222M4 ();
            wbEnd = 80;
            WB2M0( ) ;
         }
         bGXsfl_80_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2M4( )
      {
      }

      protected int subGridfilteredproducts_fnc_Pagecount( )
      {
         GRIDFILTEREDPRODUCTS_nRecordCount = subGridfilteredproducts_fnc_Recordcount( );
         if ( ((int)((GRIDFILTEREDPRODUCTS_nRecordCount) % (subGridfilteredproducts_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRIDFILTEREDPRODUCTS_nRecordCount/ (decimal)(subGridfilteredproducts_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDFILTEREDPRODUCTS_nRecordCount/ (decimal)(subGridfilteredproducts_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGridfilteredproducts_fnc_Recordcount( )
      {
         return AV37SDTProductsFiltered.Count ;
      }

      protected int subGridfilteredproducts_fnc_Recordsperpage( )
      {
         return (int)(5*1) ;
      }

      protected int subGridfilteredproducts_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDFILTEREDPRODUCTS_nFirstRecordOnPage/ (decimal)(subGridfilteredproducts_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgridfilteredproducts_firstpage( )
      {
         GRIDFILTEREDPRODUCTS_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRIDFILTEREDPRODUCTS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDFILTEREDPRODUCTS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridfilteredproducts_refresh( subGridfilteredproducts_Rows, subCarproducts_Rows, subAllvouchers_Rows, AV29Supplier, AV9Brand, AV31Sector, AV6NewName, AV5NewCode) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridfilteredproducts_nextpage( )
      {
         GRIDFILTEREDPRODUCTS_nRecordCount = subGridfilteredproducts_fnc_Recordcount( );
         if ( ( GRIDFILTEREDPRODUCTS_nRecordCount >= subGridfilteredproducts_fnc_Recordsperpage( ) ) && ( GRIDFILTEREDPRODUCTS_nEOF == 0 ) )
         {
            GRIDFILTEREDPRODUCTS_nFirstRecordOnPage = (long)(GRIDFILTEREDPRODUCTS_nFirstRecordOnPage+subGridfilteredproducts_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDFILTEREDPRODUCTS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDFILTEREDPRODUCTS_nFirstRecordOnPage), 15, 0, ".", "")));
         GridfilteredproductsContainer.AddObjectProperty("GRIDFILTEREDPRODUCTS_nFirstRecordOnPage", GRIDFILTEREDPRODUCTS_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGridfilteredproducts_refresh( subGridfilteredproducts_Rows, subCarproducts_Rows, subAllvouchers_Rows, AV29Supplier, AV9Brand, AV31Sector, AV6NewName, AV5NewCode) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRIDFILTEREDPRODUCTS_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgridfilteredproducts_previouspage( )
      {
         if ( GRIDFILTEREDPRODUCTS_nFirstRecordOnPage >= subGridfilteredproducts_fnc_Recordsperpage( ) )
         {
            GRIDFILTEREDPRODUCTS_nFirstRecordOnPage = (long)(GRIDFILTEREDPRODUCTS_nFirstRecordOnPage-subGridfilteredproducts_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDFILTEREDPRODUCTS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDFILTEREDPRODUCTS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridfilteredproducts_refresh( subGridfilteredproducts_Rows, subCarproducts_Rows, subAllvouchers_Rows, AV29Supplier, AV9Brand, AV31Sector, AV6NewName, AV5NewCode) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridfilteredproducts_lastpage( )
      {
         GRIDFILTEREDPRODUCTS_nRecordCount = subGridfilteredproducts_fnc_Recordcount( );
         if ( GRIDFILTEREDPRODUCTS_nRecordCount > subGridfilteredproducts_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRIDFILTEREDPRODUCTS_nRecordCount) % (subGridfilteredproducts_fnc_Recordsperpage( )))) == 0 )
            {
               GRIDFILTEREDPRODUCTS_nFirstRecordOnPage = (long)(GRIDFILTEREDPRODUCTS_nRecordCount-subGridfilteredproducts_fnc_Recordsperpage( ));
            }
            else
            {
               GRIDFILTEREDPRODUCTS_nFirstRecordOnPage = (long)(GRIDFILTEREDPRODUCTS_nRecordCount-((int)((GRIDFILTEREDPRODUCTS_nRecordCount) % (subGridfilteredproducts_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRIDFILTEREDPRODUCTS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDFILTEREDPRODUCTS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDFILTEREDPRODUCTS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridfilteredproducts_refresh( subGridfilteredproducts_Rows, subCarproducts_Rows, subAllvouchers_Rows, AV29Supplier, AV9Brand, AV31Sector, AV6NewName, AV5NewCode) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgridfilteredproducts_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRIDFILTEREDPRODUCTS_nFirstRecordOnPage = (long)(subGridfilteredproducts_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRIDFILTEREDPRODUCTS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDFILTEREDPRODUCTS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDFILTEREDPRODUCTS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridfilteredproducts_refresh( subGridfilteredproducts_Rows, subCarproducts_Rows, subAllvouchers_Rows, AV29Supplier, AV9Brand, AV31Sector, AV6NewName, AV5NewCode) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected int subAllvouchers_fnc_Pagecount( )
      {
         ALLVOUCHERS_nRecordCount = subAllvouchers_fnc_Recordcount( );
         if ( ((int)((ALLVOUCHERS_nRecordCount) % (subAllvouchers_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(ALLVOUCHERS_nRecordCount/ (decimal)(subAllvouchers_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(ALLVOUCHERS_nRecordCount/ (decimal)(subAllvouchers_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subAllvouchers_fnc_Recordcount( )
      {
         return AV27SDTPurchaseOrderGenerateList.Count ;
      }

      protected int subAllvouchers_fnc_Recordsperpage( )
      {
         return (int)(5*1) ;
      }

      protected int subAllvouchers_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(ALLVOUCHERS_nFirstRecordOnPage/ (decimal)(subAllvouchers_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short suballvouchers_firstpage( )
      {
         ALLVOUCHERS_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "ALLVOUCHERS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(ALLVOUCHERS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrAllvouchers_refresh( subGridfilteredproducts_Rows, subCarproducts_Rows, subAllvouchers_Rows, AV29Supplier, AV9Brand, AV31Sector, AV6NewName, AV5NewCode) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short suballvouchers_nextpage( )
      {
         ALLVOUCHERS_nRecordCount = subAllvouchers_fnc_Recordcount( );
         if ( ( ALLVOUCHERS_nRecordCount >= subAllvouchers_fnc_Recordsperpage( ) ) && ( ALLVOUCHERS_nEOF == 0 ) )
         {
            ALLVOUCHERS_nFirstRecordOnPage = (long)(ALLVOUCHERS_nFirstRecordOnPage+subAllvouchers_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "ALLVOUCHERS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(ALLVOUCHERS_nFirstRecordOnPage), 15, 0, ".", "")));
         AllvouchersContainer.AddObjectProperty("ALLVOUCHERS_nFirstRecordOnPage", ALLVOUCHERS_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrAllvouchers_refresh( subGridfilteredproducts_Rows, subCarproducts_Rows, subAllvouchers_Rows, AV29Supplier, AV9Brand, AV31Sector, AV6NewName, AV5NewCode) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((ALLVOUCHERS_nEOF==0) ? 0 : 2)) ;
      }

      protected short suballvouchers_previouspage( )
      {
         if ( ALLVOUCHERS_nFirstRecordOnPage >= subAllvouchers_fnc_Recordsperpage( ) )
         {
            ALLVOUCHERS_nFirstRecordOnPage = (long)(ALLVOUCHERS_nFirstRecordOnPage-subAllvouchers_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "ALLVOUCHERS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(ALLVOUCHERS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrAllvouchers_refresh( subGridfilteredproducts_Rows, subCarproducts_Rows, subAllvouchers_Rows, AV29Supplier, AV9Brand, AV31Sector, AV6NewName, AV5NewCode) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short suballvouchers_lastpage( )
      {
         ALLVOUCHERS_nRecordCount = subAllvouchers_fnc_Recordcount( );
         if ( ALLVOUCHERS_nRecordCount > subAllvouchers_fnc_Recordsperpage( ) )
         {
            if ( ((int)((ALLVOUCHERS_nRecordCount) % (subAllvouchers_fnc_Recordsperpage( )))) == 0 )
            {
               ALLVOUCHERS_nFirstRecordOnPage = (long)(ALLVOUCHERS_nRecordCount-subAllvouchers_fnc_Recordsperpage( ));
            }
            else
            {
               ALLVOUCHERS_nFirstRecordOnPage = (long)(ALLVOUCHERS_nRecordCount-((int)((ALLVOUCHERS_nRecordCount) % (subAllvouchers_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            ALLVOUCHERS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "ALLVOUCHERS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(ALLVOUCHERS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrAllvouchers_refresh( subGridfilteredproducts_Rows, subCarproducts_Rows, subAllvouchers_Rows, AV29Supplier, AV9Brand, AV31Sector, AV6NewName, AV5NewCode) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int suballvouchers_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            ALLVOUCHERS_nFirstRecordOnPage = (long)(subAllvouchers_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            ALLVOUCHERS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "ALLVOUCHERS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(ALLVOUCHERS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrAllvouchers_refresh( subGridfilteredproducts_Rows, subCarproducts_Rows, subAllvouchers_Rows, AV29Supplier, AV9Brand, AV31Sector, AV6NewName, AV5NewCode) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected int subCarproducts_fnc_Pagecount( )
      {
         CARPRODUCTS_nRecordCount = subCarproducts_fnc_Recordcount( );
         if ( ((int)((CARPRODUCTS_nRecordCount) % (subCarproducts_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(CARPRODUCTS_nRecordCount/ (decimal)(subCarproducts_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(CARPRODUCTS_nRecordCount/ (decimal)(subCarproducts_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subCarproducts_fnc_Recordcount( )
      {
         return AV10Car.Count ;
      }

      protected int subCarproducts_fnc_Recordsperpage( )
      {
         return (int)(5*1) ;
      }

      protected int subCarproducts_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(CARPRODUCTS_nFirstRecordOnPage/ (decimal)(subCarproducts_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subcarproducts_firstpage( )
      {
         CARPRODUCTS_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "CARPRODUCTS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(CARPRODUCTS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrCarproducts_refresh( subGridfilteredproducts_Rows, subCarproducts_Rows, subAllvouchers_Rows, AV29Supplier, AV9Brand, AV31Sector, AV6NewName, AV5NewCode) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subcarproducts_nextpage( )
      {
         CARPRODUCTS_nRecordCount = subCarproducts_fnc_Recordcount( );
         if ( ( CARPRODUCTS_nRecordCount >= subCarproducts_fnc_Recordsperpage( ) ) && ( CARPRODUCTS_nEOF == 0 ) )
         {
            CARPRODUCTS_nFirstRecordOnPage = (long)(CARPRODUCTS_nFirstRecordOnPage+subCarproducts_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "CARPRODUCTS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(CARPRODUCTS_nFirstRecordOnPage), 15, 0, ".", "")));
         CarproductsContainer.AddObjectProperty("CARPRODUCTS_nFirstRecordOnPage", CARPRODUCTS_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrCarproducts_refresh( subGridfilteredproducts_Rows, subCarproducts_Rows, subAllvouchers_Rows, AV29Supplier, AV9Brand, AV31Sector, AV6NewName, AV5NewCode) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((CARPRODUCTS_nEOF==0) ? 0 : 2)) ;
      }

      protected short subcarproducts_previouspage( )
      {
         if ( CARPRODUCTS_nFirstRecordOnPage >= subCarproducts_fnc_Recordsperpage( ) )
         {
            CARPRODUCTS_nFirstRecordOnPage = (long)(CARPRODUCTS_nFirstRecordOnPage-subCarproducts_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "CARPRODUCTS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(CARPRODUCTS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrCarproducts_refresh( subGridfilteredproducts_Rows, subCarproducts_Rows, subAllvouchers_Rows, AV29Supplier, AV9Brand, AV31Sector, AV6NewName, AV5NewCode) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subcarproducts_lastpage( )
      {
         CARPRODUCTS_nRecordCount = subCarproducts_fnc_Recordcount( );
         if ( CARPRODUCTS_nRecordCount > subCarproducts_fnc_Recordsperpage( ) )
         {
            if ( ((int)((CARPRODUCTS_nRecordCount) % (subCarproducts_fnc_Recordsperpage( )))) == 0 )
            {
               CARPRODUCTS_nFirstRecordOnPage = (long)(CARPRODUCTS_nRecordCount-subCarproducts_fnc_Recordsperpage( ));
            }
            else
            {
               CARPRODUCTS_nFirstRecordOnPage = (long)(CARPRODUCTS_nRecordCount-((int)((CARPRODUCTS_nRecordCount) % (subCarproducts_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            CARPRODUCTS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "CARPRODUCTS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(CARPRODUCTS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrCarproducts_refresh( subGridfilteredproducts_Rows, subCarproducts_Rows, subAllvouchers_Rows, AV29Supplier, AV9Brand, AV31Sector, AV6NewName, AV5NewCode) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subcarproducts_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            CARPRODUCTS_nFirstRecordOnPage = (long)(subCarproducts_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            CARPRODUCTS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "CARPRODUCTS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(CARPRODUCTS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrCarproducts_refresh( subGridfilteredproducts_Rows, subCarproducts_Rows, subAllvouchers_Rows, AV29Supplier, AV9Brand, AV31Sector, AV6NewName, AV5NewCode) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavCtlid_Enabled = 0;
         AssignProp("", false, edtavCtlid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlid_Enabled), 5, 0), !bGXsfl_49_Refreshing);
         edtavCtlcode_Enabled = 0;
         AssignProp("", false, edtavCtlcode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcode_Enabled), 5, 0), !bGXsfl_49_Refreshing);
         edtavCtlname_Enabled = 0;
         AssignProp("", false, edtavCtlname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname_Enabled), 5, 0), !bGXsfl_49_Refreshing);
         edtavCtlstock1_Enabled = 0;
         AssignProp("", false, edtavCtlstock1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlstock1_Enabled), 5, 0), !bGXsfl_49_Refreshing);
         edtavCtlminiumstock_Enabled = 0;
         AssignProp("", false, edtavCtlminiumstock_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlminiumstock_Enabled), 5, 0), !bGXsfl_49_Refreshing);
         edtavCtlcostprice_Enabled = 0;
         AssignProp("", false, edtavCtlcostprice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcostprice_Enabled), 5, 0), !bGXsfl_49_Refreshing);
         edtavCtlsupplier_Enabled = 0;
         AssignProp("", false, edtavCtlsupplier_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsupplier_Enabled), 5, 0), !bGXsfl_49_Refreshing);
         edtavCtlbrand_Enabled = 0;
         AssignProp("", false, edtavCtlbrand_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlbrand_Enabled), 5, 0), !bGXsfl_49_Refreshing);
         edtavCtlsector_Enabled = 0;
         AssignProp("", false, edtavCtlsector_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsector_Enabled), 5, 0), !bGXsfl_49_Refreshing);
         edtavCtlname1_Enabled = 0;
         AssignProp("", false, edtavCtlname1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname1_Enabled), 5, 0), !bGXsfl_80_Refreshing);
         edtavCtlstock_Enabled = 0;
         AssignProp("", false, edtavCtlstock_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlstock_Enabled), 5, 0), !bGXsfl_80_Refreshing);
         edtavCtlpurchaseorderid_Enabled = 0;
         AssignProp("", false, edtavCtlpurchaseorderid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlpurchaseorderid_Enabled), 5, 0), !bGXsfl_107_Refreshing);
         edtavCtlsuppliername_Enabled = 0;
         AssignProp("", false, edtavCtlsuppliername_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsuppliername_Enabled), 5, 0), !bGXsfl_107_Refreshing);
         edtavCtlpurchaseorderdetailsquantity_Enabled = 0;
         AssignProp("", false, edtavCtlpurchaseorderdetailsquantity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlpurchaseorderdetailsquantity_Enabled), 5, 0), !bGXsfl_107_Refreshing);
         edtavCtldetailslink_Enabled = 0;
         AssignProp("", false, edtavCtldetailslink_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtldetailslink_Enabled), 5, 0), !bGXsfl_107_Refreshing);
         edtavCtlsdtvoucherlink_Enabled = 0;
         AssignProp("", false, edtavCtlsdtvoucherlink_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsdtvoucherlink_Enabled), 5, 0), !bGXsfl_107_Refreshing);
         GXVvSUPPLIER_html2M2( ) ;
         GXVvBRAND_html2M2( ) ;
         GXVvSECTOR_html2M2( ) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2M0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E262M2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Car"), AV10Car);
            ajax_req_read_hidden_sdt(cgiGet( "Sdtpurchaseordergeneratelist"), AV27SDTPurchaseOrderGenerateList);
            ajax_req_read_hidden_sdt(cgiGet( "Sdtproductsfiltered"), AV37SDTProductsFiltered);
            ajax_req_read_hidden_sdt(cgiGet( "vSDTPRODUCTSFILTERED"), AV37SDTProductsFiltered);
            ajax_req_read_hidden_sdt(cgiGet( "vCAR"), AV10Car);
            ajax_req_read_hidden_sdt(cgiGet( "vSDTPURCHASEORDERGENERATELIST"), AV27SDTPurchaseOrderGenerateList);
            /* Read saved values. */
            nRC_GXsfl_49 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_49"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_80 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_80"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_107 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_107"), ".", ","), 18, MidpointRounding.ToEven));
            AV15Necesary = StringUtil.StrToBool( cgiGet( "vNECESARY"));
            AV18Ordered = StringUtil.StrToBool( cgiGet( "vORDERED"));
            GRIDFILTEREDPRODUCTS_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDFILTEREDPRODUCTS_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            CARPRODUCTS_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "CARPRODUCTS_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            ALLVOUCHERS_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "ALLVOUCHERS_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRIDFILTEREDPRODUCTS_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDFILTEREDPRODUCTS_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            CARPRODUCTS_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "CARPRODUCTS_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            ALLVOUCHERS_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "ALLVOUCHERS_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            subGridfilteredproducts_Collapsed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDFILTEREDPRODUCTS_Collapsed"), ".", ","), 18, MidpointRounding.ToEven));
            Necesary_Enabled = StringUtil.StrToBool( cgiGet( "NECESARY_Enabled"));
            Necesary_Captionclass = cgiGet( "NECESARY_Captionclass");
            Necesary_Captionstyle = cgiGet( "NECESARY_Captionstyle");
            Necesary_Captionposition = cgiGet( "NECESARY_Captionposition");
            Ordered_Enabled = StringUtil.StrToBool( cgiGet( "ORDERED_Enabled"));
            Ordered_Captionclass = cgiGet( "ORDERED_Captionclass");
            Ordered_Captionstyle = cgiGet( "ORDERED_Captionstyle");
            Ordered_Captionposition = cgiGet( "ORDERED_Captionposition");
            nRC_GXsfl_49 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_49"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_49_fel_idx = 0;
            while ( nGXsfl_49_fel_idx < nRC_GXsfl_49 )
            {
               nGXsfl_49_fel_idx = ((subGridfilteredproducts_Islastpage==1)&&(nGXsfl_49_fel_idx+1>subGridfilteredproducts_fnc_Recordsperpage( )) ? 1 : nGXsfl_49_fel_idx+1);
               sGXsfl_49_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_49_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_492( ) ;
               AV40GXV1 = (int)(nGXsfl_49_fel_idx+GRIDFILTEREDPRODUCTS_nFirstRecordOnPage);
               if ( ( AV37SDTProductsFiltered.Count >= AV40GXV1 ) && ( AV40GXV1 > 0 ) )
               {
                  AV37SDTProductsFiltered.CurrentItem = ((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV37SDTProductsFiltered.Item(AV40GXV1));
               }
            }
            if ( nGXsfl_49_fel_idx == 0 )
            {
               nGXsfl_49_idx = 1;
               sGXsfl_49_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_49_idx), 4, 0), 4, "0");
               SubsflControlProps_492( ) ;
            }
            nGXsfl_49_fel_idx = 1;
            nRC_GXsfl_80 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_80"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_80_fel_idx = 0;
            while ( nGXsfl_80_fel_idx < nRC_GXsfl_80 )
            {
               nGXsfl_80_fel_idx = ((subCarproducts_Islastpage==1)&&(nGXsfl_80_fel_idx+1>subCarproducts_fnc_Recordsperpage( )) ? 1 : nGXsfl_80_fel_idx+1);
               sGXsfl_80_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_80_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_804( ) ;
               AV50GXV11 = (int)(nGXsfl_80_fel_idx+CARPRODUCTS_nFirstRecordOnPage);
               if ( ( AV10Car.Count >= AV50GXV11 ) && ( AV50GXV11 > 0 ) )
               {
                  AV10Car.CurrentItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV10Car.Item(AV50GXV11));
               }
            }
            if ( nGXsfl_80_fel_idx == 0 )
            {
               nGXsfl_80_idx = 1;
               sGXsfl_80_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_80_idx), 4, 0), 4, "0");
               SubsflControlProps_804( ) ;
            }
            nGXsfl_80_fel_idx = 1;
            nRC_GXsfl_107 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_107"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_107_fel_idx = 0;
            while ( nGXsfl_107_fel_idx < nRC_GXsfl_107 )
            {
               nGXsfl_107_fel_idx = ((subAllvouchers_Islastpage==1)&&(nGXsfl_107_fel_idx+1>subAllvouchers_fnc_Recordsperpage( )) ? 1 : nGXsfl_107_fel_idx+1);
               sGXsfl_107_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_107_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_1073( ) ;
               AV54GXV15 = (int)(nGXsfl_107_fel_idx+ALLVOUCHERS_nFirstRecordOnPage);
               if ( ( AV27SDTPurchaseOrderGenerateList.Count >= AV54GXV15 ) && ( AV54GXV15 > 0 ) )
               {
                  AV27SDTPurchaseOrderGenerateList.CurrentItem = ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV27SDTPurchaseOrderGenerateList.Item(AV54GXV15));
               }
            }
            if ( nGXsfl_107_fel_idx == 0 )
            {
               nGXsfl_107_idx = 1;
               sGXsfl_107_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_107_idx), 4, 0), 4, "0");
               SubsflControlProps_1073( ) ;
            }
            nGXsfl_107_fel_idx = 1;
            /* Read variables values. */
            AV13Code = cgiGet( edtavCode_Internalname);
            AssignAttri("", false, "AV13Code", AV13Code);
            AV14Name = cgiGet( edtavName_Internalname);
            AssignAttri("", false, "AV14Name", AV14Name);
            dynavSupplier.Name = dynavSupplier_Internalname;
            dynavSupplier.CurrentValue = cgiGet( dynavSupplier_Internalname);
            AV29Supplier = (int)(Math.Round(NumberUtil.Val( cgiGet( dynavSupplier_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV29Supplier", StringUtil.LTrimStr( (decimal)(AV29Supplier), 6, 0));
            dynavBrand.Name = dynavBrand_Internalname;
            dynavBrand.CurrentValue = cgiGet( dynavBrand_Internalname);
            AV9Brand = (int)(Math.Round(NumberUtil.Val( cgiGet( dynavBrand_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV9Brand", StringUtil.LTrimStr( (decimal)(AV9Brand), 6, 0));
            dynavSector.Name = dynavSector_Internalname;
            dynavSector.CurrentValue = cgiGet( dynavSector_Internalname);
            AV31Sector = (int)(Math.Round(NumberUtil.Val( cgiGet( dynavSector_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV31Sector", StringUtil.LTrimStr( (decimal)(AV31Sector), 6, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            /* Check if conditions changed and reset current page numbers */
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
         E262M2 ();
         if (returnInSub) return;
      }

      protected void E262M2( )
      {
         /* Start Routine */
         returnInSub = false;
         divTable2_Visible = 0;
         AssignProp("", false, divTable2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTable2_Visible), 5, 0), true);
         divTable3_Visible = 0;
         AssignProp("", false, divTable3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTable3_Visible), 5, 0), true);
         /* Execute user subroutine: 'CHECKORDERED' */
         S112 ();
         if (returnInSub) return;
         GXt_objcol_SdtSDTProductsFiltered_SDTProductsFilteredItem1 = AV37SDTProductsFiltered;
         new getproductsfiltered(context ).execute(  AV13Code, ref  AV14Name, ref  AV29Supplier, ref  AV31Sector, ref  AV9Brand, ref  AV18Ordered, ref  AV15Necesary, out  GXt_objcol_SdtSDTProductsFiltered_SDTProductsFilteredItem1) ;
         AssignAttri("", false, "AV14Name", AV14Name);
         AssignAttri("", false, "AV29Supplier", StringUtil.LTrimStr( (decimal)(AV29Supplier), 6, 0));
         AssignAttri("", false, "AV31Sector", StringUtil.LTrimStr( (decimal)(AV31Sector), 6, 0));
         AssignAttri("", false, "AV9Brand", StringUtil.LTrimStr( (decimal)(AV9Brand), 6, 0));
         AssignAttri("", false, "AV18Ordered", AV18Ordered);
         AssignAttri("", false, "AV15Necesary", AV15Necesary);
         AV37SDTProductsFiltered = GXt_objcol_SdtSDTProductsFiltered_SDTProductsFilteredItem1;
         gx_BV49 = true;
      }

      protected void E132M2( )
      {
         AV50GXV11 = (int)(nGXsfl_80_idx+CARPRODUCTS_nFirstRecordOnPage);
         if ( ( AV50GXV11 > 0 ) && ( AV10Car.Count >= AV50GXV11 ) )
         {
            AV10Car.CurrentItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV10Car.Item(AV50GXV11));
         }
         AV54GXV15 = (int)(nGXsfl_107_idx+ALLVOUCHERS_nFirstRecordOnPage);
         if ( ( AV54GXV15 > 0 ) && ( AV27SDTPurchaseOrderGenerateList.Count >= AV54GXV15 ) )
         {
            AV27SDTPurchaseOrderGenerateList.CurrentItem = ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV27SDTPurchaseOrderGenerateList.Item(AV54GXV15));
         }
         /* 'GenerateOrder' Routine */
         returnInSub = false;
         AV8AllOk = true;
         AV60GXV21 = 1;
         while ( AV60GXV21 <= AV10Car.Count )
         {
            AV12CarItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV10Car.Item(AV60GXV21));
            if ( AV12CarItem.gxTpr_Quantity <= 0 )
            {
               AV8AllOk = false;
            }
            AV60GXV21 = (int)(AV60GXV21+1);
         }
         if ( ( AV10Car.Count > 0 ) && AV8AllOk )
         {
            AV61GXV22 = 1;
            while ( AV61GXV22 <= AV10Car.Count )
            {
               AV12CarItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV10Car.Item(AV61GXV22));
               AV21Product.Load(AV12CarItem.gxTpr_Id);
               if ( AV30SuppliersId.IndexOf(AV21Product.gxTpr_Supplierid) <= 0 )
               {
                  AV16Order = new SdtPurchaseOrder(context);
                  AV16Order.gxTpr_Supplierid = AV21Product.gxTpr_Supplierid;
                  AV30SuppliersId.Add(AV21Product.gxTpr_Supplierid, 0);
                  AV19Orders.Add(AV16Order, 0);
               }
               else
               {
                  AV20Position = 1;
                  AV16Order = ((SdtPurchaseOrder)AV19Orders.Item(AV20Position));
                  while ( AV16Order.gxTpr_Supplierid != AV21Product.gxTpr_Supplierid )
                  {
                     AV20Position = (short)(AV20Position+1);
                     AV16Order = ((SdtPurchaseOrder)AV19Orders.Item(AV20Position));
                  }
               }
               AV17OrderDetail = new SdtPurchaseOrder_Detail(context);
               AV17OrderDetail.gxTpr_Productid = AV21Product.gxTpr_Productid;
               AV17OrderDetail.gxTpr_Purchaseorderdetailquantityordered = AV12CarItem.gxTpr_Quantity;
               AV16Order.gxTpr_Detail.Add(AV17OrderDetail, 0);
               AV61GXV22 = (int)(AV61GXV22+1);
            }
            AV62GXV23 = 1;
            while ( AV62GXV23 <= AV19Orders.Count )
            {
               AV16Order = ((SdtPurchaseOrder)AV19Orders.Item(AV62GXV23));
               AV16Order.Insert();
               if ( AV16Order.Success() )
               {
                  context.CommitDataStores("wpgeneratepurchasecopy1",pr_default);
               }
               else
               {
                  context.RollbackDataStores("wpgeneratepurchasecopy1",pr_default);
                  GX_msglist.addItem("Error to register a order: "+AV16Order.GetMessages().ToJSonString(false));
                  AV8AllOk = false;
                  if (true) break;
               }
               AV62GXV23 = (int)(AV62GXV23+1);
            }
            if ( AV8AllOk )
            {
               AV63GXV24 = 1;
               while ( AV63GXV24 <= AV19Orders.Count )
               {
                  AV16Order = ((SdtPurchaseOrder)AV19Orders.Item(AV63GXV24));
                  AV26SDTPurchaseOrderGenerateItem = new SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem(context);
                  AV26SDTPurchaseOrderGenerateItem.gxTpr_Purchaseorderid = AV16Order.gxTpr_Purchaseorderid;
                  AV26SDTPurchaseOrderGenerateItem.gxTpr_Suppliername = AV16Order.gxTpr_Suppliername;
                  AV26SDTPurchaseOrderGenerateItem.gxTpr_Purchaseorderdetailsquantity = AV16Order.gxTpr_Purchaseorderdetailsquantity;
                  AV26SDTPurchaseOrderGenerateItem.gxTpr_Detailslink = "Details";
                  AV26SDTPurchaseOrderGenerateItem.gxTpr_Sdtvoucherlink = "View Voucher";
                  AV27SDTPurchaseOrderGenerateList.Add(AV26SDTPurchaseOrderGenerateItem, 0);
                  gx_BV107 = true;
                  AV63GXV24 = (int)(AV63GXV24+1);
               }
               AV19Orders.Clear();
               AV30SuppliersId.Clear();
               AV28SelectedId.Clear();
               AV10Car.Clear();
               gx_BV80 = true;
               divTable1_Visible = 0;
               AssignProp("", false, divTable1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTable1_Visible), 5, 0), true);
               divTable2_Visible = 0;
               AssignProp("", false, divTable2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTable2_Visible), 5, 0), true);
               divTable3_Visible = 1;
               AssignProp("", false, divTable3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTable3_Visible), 5, 0), true);
            }
            else
            {
               GX_msglist.addItem("An error ocurred: "+AV16Order.GetMessages());
            }
         }
         else
         {
            if ( AV10Car.Count > 0 )
            {
               GX_msglist.addItem("Some Quantities are invalids");
            }
            else
            {
               GX_msglist.addItem("Choose at least one product before register a order");
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV12CarItem", AV12CarItem);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV30SuppliersId", AV30SuppliersId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19Orders", AV19Orders);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27SDTPurchaseOrderGenerateList", AV27SDTPurchaseOrderGenerateList);
         nGXsfl_107_bak_idx = nGXsfl_107_idx;
         gxgrAllvouchers_refresh( subGridfilteredproducts_Rows, subCarproducts_Rows, subAllvouchers_Rows, AV29Supplier, AV9Brand, AV31Sector, AV6NewName, AV5NewCode) ;
         nGXsfl_107_idx = nGXsfl_107_bak_idx;
         sGXsfl_107_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_107_idx), 4, 0), 4, "0");
         SubsflControlProps_1073( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28SelectedId", AV28SelectedId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10Car", AV10Car);
         nGXsfl_80_bak_idx = nGXsfl_80_idx;
         gxgrCarproducts_refresh( subGridfilteredproducts_Rows, subCarproducts_Rows, subAllvouchers_Rows, AV29Supplier, AV9Brand, AV31Sector, AV6NewName, AV5NewCode) ;
         nGXsfl_80_idx = nGXsfl_80_bak_idx;
         sGXsfl_80_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_80_idx), 4, 0), 4, "0");
         SubsflControlProps_804( ) ;
      }

      protected void E142M2( )
      {
         /* 'ClearOrder' Routine */
         returnInSub = false;
         AV28SelectedId.Clear();
         AV10Car.Clear();
         gx_BV80 = true;
         divTable2_Visible = 0;
         AssignProp("", false, divTable2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTable2_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28SelectedId", AV28SelectedId);
         if ( gx_BV80 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10Car", AV10Car);
            nGXsfl_80_bak_idx = nGXsfl_80_idx;
            gxgrCarproducts_refresh( subGridfilteredproducts_Rows, subCarproducts_Rows, subAllvouchers_Rows, AV29Supplier, AV9Brand, AV31Sector, AV6NewName, AV5NewCode) ;
            nGXsfl_80_idx = nGXsfl_80_bak_idx;
            sGXsfl_80_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_80_idx), 4, 0), 4, "0");
            SubsflControlProps_804( ) ;
         }
      }

      protected void E212M2( )
      {
         AV50GXV11 = (int)(nGXsfl_80_idx+CARPRODUCTS_nFirstRecordOnPage);
         if ( ( AV50GXV11 > 0 ) && ( AV10Car.Count >= AV50GXV11 ) )
         {
            AV10Car.CurrentItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV10Car.Item(AV50GXV11));
         }
         /* 'Remove' Routine */
         returnInSub = false;
         AV20Position = (short)(AV28SelectedId.IndexOf(((SdtSDTCarProducts_SDTCarProductsItem)(AV10Car.CurrentItem)).gxTpr_Id));
         AV28SelectedId.RemoveItem(AV20Position);
         AV10Car.RemoveItem(AV20Position);
         gx_BV80 = true;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28SelectedId", AV28SelectedId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10Car", AV10Car);
         nGXsfl_80_bak_idx = nGXsfl_80_idx;
         gxgrCarproducts_refresh( subGridfilteredproducts_Rows, subCarproducts_Rows, subAllvouchers_Rows, AV29Supplier, AV9Brand, AV31Sector, AV6NewName, AV5NewCode) ;
         nGXsfl_80_idx = nGXsfl_80_bak_idx;
         sGXsfl_80_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_80_idx), 4, 0), 4, "0");
         SubsflControlProps_804( ) ;
      }

      protected void E152M2( )
      {
         AV40GXV1 = (int)(nGXsfl_49_idx+GRIDFILTEREDPRODUCTS_nFirstRecordOnPage);
         if ( ( AV40GXV1 > 0 ) && ( AV37SDTProductsFiltered.Count >= AV40GXV1 ) )
         {
            AV37SDTProductsFiltered.CurrentItem = ((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV37SDTProductsFiltered.Item(AV40GXV1));
         }
         /* Brand_Controlvaluechanged Routine */
         returnInSub = false;
         GXt_objcol_SdtSDTProductsFiltered_SDTProductsFilteredItem1 = AV37SDTProductsFiltered;
         new getproductsfiltered(context ).execute(  AV13Code, ref  AV14Name, ref  AV29Supplier, ref  AV31Sector, ref  AV9Brand, ref  AV18Ordered, ref  AV15Necesary, out  GXt_objcol_SdtSDTProductsFiltered_SDTProductsFilteredItem1) ;
         AssignAttri("", false, "AV14Name", AV14Name);
         AssignAttri("", false, "AV29Supplier", StringUtil.LTrimStr( (decimal)(AV29Supplier), 6, 0));
         AssignAttri("", false, "AV31Sector", StringUtil.LTrimStr( (decimal)(AV31Sector), 6, 0));
         AssignAttri("", false, "AV9Brand", StringUtil.LTrimStr( (decimal)(AV9Brand), 6, 0));
         AssignAttri("", false, "AV18Ordered", AV18Ordered);
         AssignAttri("", false, "AV15Necesary", AV15Necesary);
         AV37SDTProductsFiltered = GXt_objcol_SdtSDTProductsFiltered_SDTProductsFilteredItem1;
         gx_BV49 = true;
         gxgrGridfilteredproducts_refresh( subGridfilteredproducts_Rows, subCarproducts_Rows, subAllvouchers_Rows, AV29Supplier, AV9Brand, AV31Sector, AV6NewName, AV5NewCode) ;
         /*  Sending Event outputs  */
         if ( gx_BV49 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV37SDTProductsFiltered", AV37SDTProductsFiltered);
            nGXsfl_49_bak_idx = nGXsfl_49_idx;
            gxgrGridfilteredproducts_refresh( subGridfilteredproducts_Rows, subCarproducts_Rows, subAllvouchers_Rows, AV29Supplier, AV9Brand, AV31Sector, AV6NewName, AV5NewCode) ;
            nGXsfl_49_idx = nGXsfl_49_bak_idx;
            sGXsfl_49_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_49_idx), 4, 0), 4, "0");
            SubsflControlProps_492( ) ;
         }
         dynavBrand.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV9Brand), 6, 0));
         AssignProp("", false, dynavBrand_Internalname, "Values", dynavBrand.ToJavascriptSource(), true);
         dynavSector.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31Sector), 6, 0));
         AssignProp("", false, dynavSector_Internalname, "Values", dynavSector.ToJavascriptSource(), true);
         dynavSupplier.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29Supplier), 6, 0));
         AssignProp("", false, dynavSupplier_Internalname, "Values", dynavSupplier.ToJavascriptSource(), true);
      }

      protected void E162M2( )
      {
         AV40GXV1 = (int)(nGXsfl_49_idx+GRIDFILTEREDPRODUCTS_nFirstRecordOnPage);
         if ( ( AV40GXV1 > 0 ) && ( AV37SDTProductsFiltered.Count >= AV40GXV1 ) )
         {
            AV37SDTProductsFiltered.CurrentItem = ((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV37SDTProductsFiltered.Item(AV40GXV1));
         }
         /* Supplier_Controlvaluechanged Routine */
         returnInSub = false;
         GXt_objcol_SdtSDTProductsFiltered_SDTProductsFilteredItem1 = AV37SDTProductsFiltered;
         new getproductsfiltered(context ).execute(  AV13Code, ref  AV14Name, ref  AV29Supplier, ref  AV31Sector, ref  AV9Brand, ref  AV18Ordered, ref  AV15Necesary, out  GXt_objcol_SdtSDTProductsFiltered_SDTProductsFilteredItem1) ;
         AssignAttri("", false, "AV14Name", AV14Name);
         AssignAttri("", false, "AV29Supplier", StringUtil.LTrimStr( (decimal)(AV29Supplier), 6, 0));
         AssignAttri("", false, "AV31Sector", StringUtil.LTrimStr( (decimal)(AV31Sector), 6, 0));
         AssignAttri("", false, "AV9Brand", StringUtil.LTrimStr( (decimal)(AV9Brand), 6, 0));
         AssignAttri("", false, "AV18Ordered", AV18Ordered);
         AssignAttri("", false, "AV15Necesary", AV15Necesary);
         AV37SDTProductsFiltered = GXt_objcol_SdtSDTProductsFiltered_SDTProductsFilteredItem1;
         gx_BV49 = true;
         gxgrGridfilteredproducts_refresh( subGridfilteredproducts_Rows, subCarproducts_Rows, subAllvouchers_Rows, AV29Supplier, AV9Brand, AV31Sector, AV6NewName, AV5NewCode) ;
         /*  Sending Event outputs  */
         if ( gx_BV49 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV37SDTProductsFiltered", AV37SDTProductsFiltered);
            nGXsfl_49_bak_idx = nGXsfl_49_idx;
            gxgrGridfilteredproducts_refresh( subGridfilteredproducts_Rows, subCarproducts_Rows, subAllvouchers_Rows, AV29Supplier, AV9Brand, AV31Sector, AV6NewName, AV5NewCode) ;
            nGXsfl_49_idx = nGXsfl_49_bak_idx;
            sGXsfl_49_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_49_idx), 4, 0), 4, "0");
            SubsflControlProps_492( ) ;
         }
         dynavBrand.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV9Brand), 6, 0));
         AssignProp("", false, dynavBrand_Internalname, "Values", dynavBrand.ToJavascriptSource(), true);
         dynavSector.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31Sector), 6, 0));
         AssignProp("", false, dynavSector_Internalname, "Values", dynavSector.ToJavascriptSource(), true);
         dynavSupplier.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29Supplier), 6, 0));
         AssignProp("", false, dynavSupplier_Internalname, "Values", dynavSupplier.ToJavascriptSource(), true);
      }

      protected void E172M2( )
      {
         AV40GXV1 = (int)(nGXsfl_49_idx+GRIDFILTEREDPRODUCTS_nFirstRecordOnPage);
         if ( ( AV40GXV1 > 0 ) && ( AV37SDTProductsFiltered.Count >= AV40GXV1 ) )
         {
            AV37SDTProductsFiltered.CurrentItem = ((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV37SDTProductsFiltered.Item(AV40GXV1));
         }
         /* Name_Controlvaluechanging Routine */
         returnInSub = false;
         GXt_objcol_SdtSDTProductsFiltered_SDTProductsFilteredItem1 = AV37SDTProductsFiltered;
         new getproductsfiltered(context ).execute(  AV13Code, ref  AV14Name, ref  AV29Supplier, ref  AV31Sector, ref  AV9Brand, ref  AV18Ordered, ref  AV15Necesary, out  GXt_objcol_SdtSDTProductsFiltered_SDTProductsFilteredItem1) ;
         AssignAttri("", false, "AV14Name", AV14Name);
         AssignAttri("", false, "AV29Supplier", StringUtil.LTrimStr( (decimal)(AV29Supplier), 6, 0));
         AssignAttri("", false, "AV31Sector", StringUtil.LTrimStr( (decimal)(AV31Sector), 6, 0));
         AssignAttri("", false, "AV9Brand", StringUtil.LTrimStr( (decimal)(AV9Brand), 6, 0));
         AssignAttri("", false, "AV18Ordered", AV18Ordered);
         AssignAttri("", false, "AV15Necesary", AV15Necesary);
         AV37SDTProductsFiltered = GXt_objcol_SdtSDTProductsFiltered_SDTProductsFilteredItem1;
         gx_BV49 = true;
         gxgrGridfilteredproducts_refresh( subGridfilteredproducts_Rows, subCarproducts_Rows, subAllvouchers_Rows, AV29Supplier, AV9Brand, AV31Sector, AV6NewName, AV5NewCode) ;
         /*  Sending Event outputs  */
         if ( gx_BV49 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV37SDTProductsFiltered", AV37SDTProductsFiltered);
            nGXsfl_49_bak_idx = nGXsfl_49_idx;
            gxgrGridfilteredproducts_refresh( subGridfilteredproducts_Rows, subCarproducts_Rows, subAllvouchers_Rows, AV29Supplier, AV9Brand, AV31Sector, AV6NewName, AV5NewCode) ;
            nGXsfl_49_idx = nGXsfl_49_bak_idx;
            sGXsfl_49_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_49_idx), 4, 0), 4, "0");
            SubsflControlProps_492( ) ;
         }
         dynavBrand.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV9Brand), 6, 0));
         AssignProp("", false, dynavBrand_Internalname, "Values", dynavBrand.ToJavascriptSource(), true);
         dynavSector.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31Sector), 6, 0));
         AssignProp("", false, dynavSector_Internalname, "Values", dynavSector.ToJavascriptSource(), true);
         dynavSupplier.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29Supplier), 6, 0));
         AssignProp("", false, dynavSupplier_Internalname, "Values", dynavSupplier.ToJavascriptSource(), true);
      }

      protected void E182M2( )
      {
         AV40GXV1 = (int)(nGXsfl_49_idx+GRIDFILTEREDPRODUCTS_nFirstRecordOnPage);
         if ( ( AV40GXV1 > 0 ) && ( AV37SDTProductsFiltered.Count >= AV40GXV1 ) )
         {
            AV37SDTProductsFiltered.CurrentItem = ((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV37SDTProductsFiltered.Item(AV40GXV1));
         }
         /* Code_Controlvaluechanging Routine */
         returnInSub = false;
         GXt_objcol_SdtSDTProductsFiltered_SDTProductsFilteredItem1 = AV37SDTProductsFiltered;
         new getproductsfiltered(context ).execute(  AV13Code, ref  AV14Name, ref  AV29Supplier, ref  AV31Sector, ref  AV9Brand, ref  AV18Ordered, ref  AV15Necesary, out  GXt_objcol_SdtSDTProductsFiltered_SDTProductsFilteredItem1) ;
         AssignAttri("", false, "AV14Name", AV14Name);
         AssignAttri("", false, "AV29Supplier", StringUtil.LTrimStr( (decimal)(AV29Supplier), 6, 0));
         AssignAttri("", false, "AV31Sector", StringUtil.LTrimStr( (decimal)(AV31Sector), 6, 0));
         AssignAttri("", false, "AV9Brand", StringUtil.LTrimStr( (decimal)(AV9Brand), 6, 0));
         AssignAttri("", false, "AV18Ordered", AV18Ordered);
         AssignAttri("", false, "AV15Necesary", AV15Necesary);
         AV37SDTProductsFiltered = GXt_objcol_SdtSDTProductsFiltered_SDTProductsFilteredItem1;
         gx_BV49 = true;
         gxgrGridfilteredproducts_refresh( subGridfilteredproducts_Rows, subCarproducts_Rows, subAllvouchers_Rows, AV29Supplier, AV9Brand, AV31Sector, AV6NewName, AV5NewCode) ;
         /*  Sending Event outputs  */
         if ( gx_BV49 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV37SDTProductsFiltered", AV37SDTProductsFiltered);
            nGXsfl_49_bak_idx = nGXsfl_49_idx;
            gxgrGridfilteredproducts_refresh( subGridfilteredproducts_Rows, subCarproducts_Rows, subAllvouchers_Rows, AV29Supplier, AV9Brand, AV31Sector, AV6NewName, AV5NewCode) ;
            nGXsfl_49_idx = nGXsfl_49_bak_idx;
            sGXsfl_49_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_49_idx), 4, 0), 4, "0");
            SubsflControlProps_492( ) ;
         }
         dynavBrand.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV9Brand), 6, 0));
         AssignProp("", false, dynavBrand_Internalname, "Values", dynavBrand.ToJavascriptSource(), true);
         dynavSector.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31Sector), 6, 0));
         AssignProp("", false, dynavSector_Internalname, "Values", dynavSector.ToJavascriptSource(), true);
         dynavSupplier.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29Supplier), 6, 0));
         AssignProp("", false, dynavSupplier_Internalname, "Values", dynavSupplier.ToJavascriptSource(), true);
      }

      protected void E192M2( )
      {
         AV40GXV1 = (int)(nGXsfl_49_idx+GRIDFILTEREDPRODUCTS_nFirstRecordOnPage);
         if ( ( AV40GXV1 > 0 ) && ( AV37SDTProductsFiltered.Count >= AV40GXV1 ) )
         {
            AV37SDTProductsFiltered.CurrentItem = ((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV37SDTProductsFiltered.Item(AV40GXV1));
         }
         /* Sector_Controlvaluechanged Routine */
         returnInSub = false;
         GXt_objcol_SdtSDTProductsFiltered_SDTProductsFilteredItem1 = AV37SDTProductsFiltered;
         new getproductsfiltered(context ).execute(  AV13Code, ref  AV14Name, ref  AV29Supplier, ref  AV31Sector, ref  AV9Brand, ref  AV18Ordered, ref  AV15Necesary, out  GXt_objcol_SdtSDTProductsFiltered_SDTProductsFilteredItem1) ;
         AssignAttri("", false, "AV14Name", AV14Name);
         AssignAttri("", false, "AV29Supplier", StringUtil.LTrimStr( (decimal)(AV29Supplier), 6, 0));
         AssignAttri("", false, "AV31Sector", StringUtil.LTrimStr( (decimal)(AV31Sector), 6, 0));
         AssignAttri("", false, "AV9Brand", StringUtil.LTrimStr( (decimal)(AV9Brand), 6, 0));
         AssignAttri("", false, "AV18Ordered", AV18Ordered);
         AssignAttri("", false, "AV15Necesary", AV15Necesary);
         AV37SDTProductsFiltered = GXt_objcol_SdtSDTProductsFiltered_SDTProductsFilteredItem1;
         gx_BV49 = true;
         gxgrGridfilteredproducts_refresh( subGridfilteredproducts_Rows, subCarproducts_Rows, subAllvouchers_Rows, AV29Supplier, AV9Brand, AV31Sector, AV6NewName, AV5NewCode) ;
         /*  Sending Event outputs  */
         if ( gx_BV49 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV37SDTProductsFiltered", AV37SDTProductsFiltered);
            nGXsfl_49_bak_idx = nGXsfl_49_idx;
            gxgrGridfilteredproducts_refresh( subGridfilteredproducts_Rows, subCarproducts_Rows, subAllvouchers_Rows, AV29Supplier, AV9Brand, AV31Sector, AV6NewName, AV5NewCode) ;
            nGXsfl_49_idx = nGXsfl_49_bak_idx;
            sGXsfl_49_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_49_idx), 4, 0), 4, "0");
            SubsflControlProps_492( ) ;
         }
         dynavBrand.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV9Brand), 6, 0));
         AssignProp("", false, dynavBrand_Internalname, "Values", dynavBrand.ToJavascriptSource(), true);
         dynavSector.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31Sector), 6, 0));
         AssignProp("", false, dynavSector_Internalname, "Values", dynavSector.ToJavascriptSource(), true);
         dynavSupplier.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29Supplier), 6, 0));
         AssignProp("", false, dynavSupplier_Internalname, "Values", dynavSupplier.ToJavascriptSource(), true);
      }

      protected void E112M2( )
      {
         AV40GXV1 = (int)(nGXsfl_49_idx+GRIDFILTEREDPRODUCTS_nFirstRecordOnPage);
         if ( ( AV40GXV1 > 0 ) && ( AV37SDTProductsFiltered.Count >= AV40GXV1 ) )
         {
            AV37SDTProductsFiltered.CurrentItem = ((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV37SDTProductsFiltered.Item(AV40GXV1));
         }
         /* Necesary_Controlvaluechanged Routine */
         returnInSub = false;
         GXt_objcol_SdtSDTProductsFiltered_SDTProductsFilteredItem1 = AV37SDTProductsFiltered;
         new getproductsfiltered(context ).execute(  AV13Code, ref  AV14Name, ref  AV29Supplier, ref  AV31Sector, ref  AV9Brand, ref  AV18Ordered, ref  AV15Necesary, out  GXt_objcol_SdtSDTProductsFiltered_SDTProductsFilteredItem1) ;
         AssignAttri("", false, "AV14Name", AV14Name);
         AssignAttri("", false, "AV29Supplier", StringUtil.LTrimStr( (decimal)(AV29Supplier), 6, 0));
         AssignAttri("", false, "AV31Sector", StringUtil.LTrimStr( (decimal)(AV31Sector), 6, 0));
         AssignAttri("", false, "AV9Brand", StringUtil.LTrimStr( (decimal)(AV9Brand), 6, 0));
         AssignAttri("", false, "AV18Ordered", AV18Ordered);
         AssignAttri("", false, "AV15Necesary", AV15Necesary);
         AV37SDTProductsFiltered = GXt_objcol_SdtSDTProductsFiltered_SDTProductsFilteredItem1;
         gx_BV49 = true;
         gxgrGridfilteredproducts_refresh( subGridfilteredproducts_Rows, subCarproducts_Rows, subAllvouchers_Rows, AV29Supplier, AV9Brand, AV31Sector, AV6NewName, AV5NewCode) ;
         /*  Sending Event outputs  */
         if ( gx_BV49 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV37SDTProductsFiltered", AV37SDTProductsFiltered);
            nGXsfl_49_bak_idx = nGXsfl_49_idx;
            gxgrGridfilteredproducts_refresh( subGridfilteredproducts_Rows, subCarproducts_Rows, subAllvouchers_Rows, AV29Supplier, AV9Brand, AV31Sector, AV6NewName, AV5NewCode) ;
            nGXsfl_49_idx = nGXsfl_49_bak_idx;
            sGXsfl_49_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_49_idx), 4, 0), 4, "0");
            SubsflControlProps_492( ) ;
         }
         dynavBrand.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV9Brand), 6, 0));
         AssignProp("", false, dynavBrand_Internalname, "Values", dynavBrand.ToJavascriptSource(), true);
         dynavSector.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31Sector), 6, 0));
         AssignProp("", false, dynavSector_Internalname, "Values", dynavSector.ToJavascriptSource(), true);
         dynavSupplier.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29Supplier), 6, 0));
         AssignProp("", false, dynavSupplier_Internalname, "Values", dynavSupplier.ToJavascriptSource(), true);
      }

      protected void E122M2( )
      {
         AV40GXV1 = (int)(nGXsfl_49_idx+GRIDFILTEREDPRODUCTS_nFirstRecordOnPage);
         if ( ( AV40GXV1 > 0 ) && ( AV37SDTProductsFiltered.Count >= AV40GXV1 ) )
         {
            AV37SDTProductsFiltered.CurrentItem = ((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV37SDTProductsFiltered.Item(AV40GXV1));
         }
         /* Ordered_Controlvaluechanged Routine */
         returnInSub = false;
         GXt_objcol_SdtSDTProductsFiltered_SDTProductsFilteredItem1 = AV37SDTProductsFiltered;
         new getproductsfiltered(context ).execute(  AV13Code, ref  AV14Name, ref  AV29Supplier, ref  AV31Sector, ref  AV9Brand, ref  AV18Ordered, ref  AV15Necesary, out  GXt_objcol_SdtSDTProductsFiltered_SDTProductsFilteredItem1) ;
         AssignAttri("", false, "AV14Name", AV14Name);
         AssignAttri("", false, "AV29Supplier", StringUtil.LTrimStr( (decimal)(AV29Supplier), 6, 0));
         AssignAttri("", false, "AV31Sector", StringUtil.LTrimStr( (decimal)(AV31Sector), 6, 0));
         AssignAttri("", false, "AV9Brand", StringUtil.LTrimStr( (decimal)(AV9Brand), 6, 0));
         AssignAttri("", false, "AV18Ordered", AV18Ordered);
         AssignAttri("", false, "AV15Necesary", AV15Necesary);
         AV37SDTProductsFiltered = GXt_objcol_SdtSDTProductsFiltered_SDTProductsFilteredItem1;
         gx_BV49 = true;
         gxgrGridfilteredproducts_refresh( subGridfilteredproducts_Rows, subCarproducts_Rows, subAllvouchers_Rows, AV29Supplier, AV9Brand, AV31Sector, AV6NewName, AV5NewCode) ;
         /*  Sending Event outputs  */
         if ( gx_BV49 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV37SDTProductsFiltered", AV37SDTProductsFiltered);
            nGXsfl_49_bak_idx = nGXsfl_49_idx;
            gxgrGridfilteredproducts_refresh( subGridfilteredproducts_Rows, subCarproducts_Rows, subAllvouchers_Rows, AV29Supplier, AV9Brand, AV31Sector, AV6NewName, AV5NewCode) ;
            nGXsfl_49_idx = nGXsfl_49_bak_idx;
            sGXsfl_49_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_49_idx), 4, 0), 4, "0");
            SubsflControlProps_492( ) ;
         }
         dynavBrand.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV9Brand), 6, 0));
         AssignProp("", false, dynavBrand_Internalname, "Values", dynavBrand.ToJavascriptSource(), true);
         dynavSector.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV31Sector), 6, 0));
         AssignProp("", false, dynavSector_Internalname, "Values", dynavSector.ToJavascriptSource(), true);
         dynavSupplier.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV29Supplier), 6, 0));
         AssignProp("", false, dynavSupplier_Internalname, "Values", dynavSupplier.ToJavascriptSource(), true);
      }

      protected void E232M2( )
      {
         AV54GXV15 = (int)(nGXsfl_107_idx+ALLVOUCHERS_nFirstRecordOnPage);
         if ( ( AV54GXV15 > 0 ) && ( AV27SDTPurchaseOrderGenerateList.Count >= AV54GXV15 ) )
         {
            AV27SDTPurchaseOrderGenerateList.CurrentItem = ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV27SDTPurchaseOrderGenerateList.Item(AV54GXV15));
         }
         /* Ctlsdtvoucherlink_Click Routine */
         returnInSub = false;
         /* Window Datatype Object Property */
         AV7window.Url = formatLink("apurchaseordergenerate.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)(AV27SDTPurchaseOrderGenerateList.CurrentItem)).gxTpr_Purchaseorderid,6,0))}, new string[] {"PurchaseOrderId"}) ;
         AV7window.SetReturnParms(new Object[] {});
         AV7window.Height = 370;
         AV7window.Width = 500;
         context.NewWindow(AV7window);
         /*  Sending Event outputs  */
      }

      protected void E242M2( )
      {
         AV54GXV15 = (int)(nGXsfl_107_idx+ALLVOUCHERS_nFirstRecordOnPage);
         if ( ( AV54GXV15 > 0 ) && ( AV27SDTPurchaseOrderGenerateList.Count >= AV54GXV15 ) )
         {
            AV27SDTPurchaseOrderGenerateList.CurrentItem = ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV27SDTPurchaseOrderGenerateList.Item(AV54GXV15));
         }
         /* Ctldetailslink_Click Routine */
         returnInSub = false;
         /* Window Datatype Object Property */
         AV7window.Url = formatLink("wppurchaseorderdetails.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)(AV27SDTPurchaseOrderGenerateList.CurrentItem)).gxTpr_Purchaseorderid,6,0))}, new string[] {"PurchaseOrderId"}) ;
         AV7window.SetReturnParms(new Object[] {});
         AV7window.Height = 370;
         AV7window.Width = 500;
         context.NewWindow(AV7window);
         /*  Sending Event outputs  */
      }

      protected void E202M2( )
      {
         /* 'GenerateNewOrder' Routine */
         returnInSub = false;
         AV27SDTPurchaseOrderGenerateList.Clear();
         gx_BV107 = true;
         divTable1_Visible = 1;
         AssignProp("", false, divTable1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTable1_Visible), 5, 0), true);
         divTable2_Visible = 0;
         AssignProp("", false, divTable2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTable2_Visible), 5, 0), true);
         divTable3_Visible = 0;
         AssignProp("", false, divTable3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTable3_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         if ( gx_BV107 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27SDTPurchaseOrderGenerateList", AV27SDTPurchaseOrderGenerateList);
            nGXsfl_107_bak_idx = nGXsfl_107_idx;
            gxgrAllvouchers_refresh( subGridfilteredproducts_Rows, subCarproducts_Rows, subAllvouchers_Rows, AV29Supplier, AV9Brand, AV31Sector, AV6NewName, AV5NewCode) ;
            nGXsfl_107_idx = nGXsfl_107_bak_idx;
            sGXsfl_107_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_107_idx), 4, 0), 4, "0");
            SubsflControlProps_1073( ) ;
         }
      }

      protected void S112( )
      {
         /* 'CHECKORDERED' Routine */
         returnInSub = false;
         GXt_objcol_SdtSDTProductsSelected_SDTProductsSelectedItem2 = AV24SDTProductsOrdered;
         new dpallproductswhereordered(context ).execute( out  GXt_objcol_SdtSDTProductsSelected_SDTProductsSelectedItem2) ;
         AV24SDTProductsOrdered = GXt_objcol_SdtSDTProductsSelected_SDTProductsSelectedItem2;
         AV22ProductsOrderedId.Clear();
         AV64GXV25 = 1;
         while ( AV64GXV25 <= AV24SDTProductsOrdered.Count )
         {
            AV25SDTProductsOrderedItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV24SDTProductsOrdered.Item(AV64GXV25));
            if ( AV22ProductsOrderedId.IndexOf(AV25SDTProductsOrderedItem.gxTpr_Id) == 0 )
            {
               AV22ProductsOrderedId.Add(AV25SDTProductsOrderedItem.gxTpr_Id, 0);
            }
            AV64GXV25 = (int)(AV64GXV25+1);
         }
      }

      protected void E272M2( )
      {
         AV50GXV11 = (int)(nGXsfl_80_idx+CARPRODUCTS_nFirstRecordOnPage);
         if ( ( AV50GXV11 > 0 ) && ( AV10Car.Count >= AV50GXV11 ) )
         {
            AV10Car.CurrentItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV10Car.Item(AV50GXV11));
         }
         AV40GXV1 = (int)(nGXsfl_49_idx+GRIDFILTEREDPRODUCTS_nFirstRecordOnPage);
         if ( ( AV40GXV1 > 0 ) && ( AV37SDTProductsFiltered.Count >= AV40GXV1 ) )
         {
            AV37SDTProductsFiltered.CurrentItem = ((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV37SDTProductsFiltered.Item(AV40GXV1));
         }
         /* Ctlname_Click Routine */
         returnInSub = false;
         if ( AV28SelectedId.IndexOf(((SdtSDTProductsFiltered_SDTProductsFilteredItem)(AV37SDTProductsFiltered.CurrentItem)).gxTpr_Id) <= 0 )
         {
            AV12CarItem.gxTpr_Id = ((SdtSDTProductsFiltered_SDTProductsFilteredItem)(AV37SDTProductsFiltered.CurrentItem)).gxTpr_Id;
            AV12CarItem.gxTpr_Name = ((SdtSDTProductsFiltered_SDTProductsFilteredItem)(AV37SDTProductsFiltered.CurrentItem)).gxTpr_Name;
            AV12CarItem.gxTpr_Stock = ((SdtSDTProductsFiltered_SDTProductsFilteredItem)(AV37SDTProductsFiltered.CurrentItem)).gxTpr_Stock;
            AV12CarItem.gxTpr_Quantity = 0;
            AV28SelectedId.Clear();
            AV28SelectedId.Add(AV12CarItem.gxTpr_Id, 0);
            AV11CarAux.Add(AV12CarItem, 0);
            AV65GXV26 = 1;
            while ( AV65GXV26 <= AV10Car.Count )
            {
               AV12CarItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV10Car.Item(AV65GXV26));
               AV11CarAux.Add(AV12CarItem, 0);
               AV28SelectedId.Add(AV12CarItem.gxTpr_Id, 0);
               AV65GXV26 = (int)(AV65GXV26+1);
            }
            AV10Car = (GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem>)(AV11CarAux.Clone());
            gx_BV80 = true;
            AV11CarAux.Clear();
         }
         if ( AV10Car.Count > 0 )
         {
            divTable2_Visible = 1;
            AssignProp("", false, divTable2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTable2_Visible), 5, 0), true);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV12CarItem", AV12CarItem);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28SelectedId", AV28SelectedId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11CarAux", AV11CarAux);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10Car", AV10Car);
         nGXsfl_80_bak_idx = nGXsfl_80_idx;
         gxgrCarproducts_refresh( subGridfilteredproducts_Rows, subCarproducts_Rows, subAllvouchers_Rows, AV29Supplier, AV9Brand, AV31Sector, AV6NewName, AV5NewCode) ;
         nGXsfl_80_idx = nGXsfl_80_bak_idx;
         sGXsfl_80_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_80_idx), 4, 0), 4, "0");
         SubsflControlProps_804( ) ;
      }

      private void E282M2( )
      {
         /* Gridfilteredproducts_Load Routine */
         returnInSub = false;
         AV40GXV1 = 1;
         while ( AV40GXV1 <= AV37SDTProductsFiltered.Count )
         {
            AV37SDTProductsFiltered.CurrentItem = ((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV37SDTProductsFiltered.Item(AV40GXV1));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 49;
            }
            if ( ( subGridfilteredproducts_Islastpage == 1 ) || ( 5 == 0 ) || ( ( GRIDFILTEREDPRODUCTS_nCurrentRecord >= GRIDFILTEREDPRODUCTS_nFirstRecordOnPage ) && ( GRIDFILTEREDPRODUCTS_nCurrentRecord < GRIDFILTEREDPRODUCTS_nFirstRecordOnPage + subGridfilteredproducts_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_492( ) ;
            }
            GRIDFILTEREDPRODUCTS_nEOF = (short)(((GRIDFILTEREDPRODUCTS_nCurrentRecord<GRIDFILTEREDPRODUCTS_nFirstRecordOnPage+subGridfilteredproducts_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRIDFILTEREDPRODUCTS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDFILTEREDPRODUCTS_nEOF), 1, 0, ".", "")));
            GRIDFILTEREDPRODUCTS_nCurrentRecord = (long)(GRIDFILTEREDPRODUCTS_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_49_Refreshing )
            {
               DoAjaxLoad(49, GridfilteredproductsRow);
            }
            AV40GXV1 = (int)(AV40GXV1+1);
         }
      }

      private void E252M3( )
      {
         /* Allvouchers_Load Routine */
         returnInSub = false;
         AV54GXV15 = 1;
         while ( AV54GXV15 <= AV27SDTPurchaseOrderGenerateList.Count )
         {
            AV27SDTPurchaseOrderGenerateList.CurrentItem = ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV27SDTPurchaseOrderGenerateList.Item(AV54GXV15));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 107;
            }
            if ( ( subAllvouchers_Islastpage == 1 ) || ( 5 == 0 ) || ( ( ALLVOUCHERS_nCurrentRecord >= ALLVOUCHERS_nFirstRecordOnPage ) && ( ALLVOUCHERS_nCurrentRecord < ALLVOUCHERS_nFirstRecordOnPage + subAllvouchers_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_1073( ) ;
            }
            ALLVOUCHERS_nEOF = (short)(((ALLVOUCHERS_nCurrentRecord<ALLVOUCHERS_nFirstRecordOnPage+subAllvouchers_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "ALLVOUCHERS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(ALLVOUCHERS_nEOF), 1, 0, ".", "")));
            ALLVOUCHERS_nCurrentRecord = (long)(ALLVOUCHERS_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_107_Refreshing )
            {
               DoAjaxLoad(107, AllvouchersRow);
            }
            AV54GXV15 = (int)(AV54GXV15+1);
         }
      }

      private void E222M4( )
      {
         /* Carproducts_Load Routine */
         returnInSub = false;
         AV50GXV11 = 1;
         while ( AV50GXV11 <= AV10Car.Count )
         {
            AV10Car.CurrentItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV10Car.Item(AV50GXV11));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 80;
            }
            if ( ( subCarproducts_Islastpage == 1 ) || ( 5 == 0 ) || ( ( CARPRODUCTS_nCurrentRecord >= CARPRODUCTS_nFirstRecordOnPage ) && ( CARPRODUCTS_nCurrentRecord < CARPRODUCTS_nFirstRecordOnPage + subCarproducts_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_804( ) ;
            }
            CARPRODUCTS_nEOF = (short)(((CARPRODUCTS_nCurrentRecord<CARPRODUCTS_nFirstRecordOnPage+subCarproducts_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "CARPRODUCTS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(CARPRODUCTS_nEOF), 1, 0, ".", "")));
            CARPRODUCTS_nCurrentRecord = (long)(CARPRODUCTS_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_80_Refreshing )
            {
               DoAjaxLoad(80, CarproductsRow);
            }
            AV50GXV11 = (int)(AV50GXV11+1);
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
         PA2M2( ) ;
         WS2M2( ) ;
         WE2M2( ) ;
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
         AddStyleSheetFile("Switch/switch.min.css", "");
         AddStyleSheetFile("Switch/switch.min.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024372347378", true, true);
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
         context.AddJavascriptSource("wpgeneratepurchasecopy1.js", "?20243723473710", false, true);
         context.AddJavascriptSource("Switch/switch.min.js", "", false, true);
         context.AddJavascriptSource("Switch/switch.min.js", "", false, true);
         context.AddJavascriptSource("Switch/switch.min.js", "", false, true);
         context.AddJavascriptSource("Switch/switch.min.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_492( )
      {
         edtavCtlid_Internalname = "CTLID_"+sGXsfl_49_idx;
         edtavCtlcode_Internalname = "CTLCODE_"+sGXsfl_49_idx;
         edtavCtlname_Internalname = "CTLNAME_"+sGXsfl_49_idx;
         edtavCtlstock1_Internalname = "CTLSTOCK1_"+sGXsfl_49_idx;
         edtavCtlminiumstock_Internalname = "CTLMINIUMSTOCK_"+sGXsfl_49_idx;
         edtavCtlcostprice_Internalname = "CTLCOSTPRICE_"+sGXsfl_49_idx;
         edtavCtlsupplier_Internalname = "CTLSUPPLIER_"+sGXsfl_49_idx;
         edtavCtlbrand_Internalname = "CTLBRAND_"+sGXsfl_49_idx;
         edtavCtlsector_Internalname = "CTLSECTOR_"+sGXsfl_49_idx;
      }

      protected void SubsflControlProps_fel_492( )
      {
         edtavCtlid_Internalname = "CTLID_"+sGXsfl_49_fel_idx;
         edtavCtlcode_Internalname = "CTLCODE_"+sGXsfl_49_fel_idx;
         edtavCtlname_Internalname = "CTLNAME_"+sGXsfl_49_fel_idx;
         edtavCtlstock1_Internalname = "CTLSTOCK1_"+sGXsfl_49_fel_idx;
         edtavCtlminiumstock_Internalname = "CTLMINIUMSTOCK_"+sGXsfl_49_fel_idx;
         edtavCtlcostprice_Internalname = "CTLCOSTPRICE_"+sGXsfl_49_fel_idx;
         edtavCtlsupplier_Internalname = "CTLSUPPLIER_"+sGXsfl_49_fel_idx;
         edtavCtlbrand_Internalname = "CTLBRAND_"+sGXsfl_49_fel_idx;
         edtavCtlsector_Internalname = "CTLSECTOR_"+sGXsfl_49_fel_idx;
      }

      protected void sendrow_492( )
      {
         SubsflControlProps_492( ) ;
         WB2M0( ) ;
         if ( ( 5 * 1 == 0 ) || ( nGXsfl_49_idx <= subGridfilteredproducts_fnc_Recordsperpage( ) * 1 ) )
         {
            GridfilteredproductsRow = GXWebRow.GetNew(context,GridfilteredproductsContainer);
            if ( subGridfilteredproducts_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGridfilteredproducts_Backstyle = 0;
               if ( StringUtil.StrCmp(subGridfilteredproducts_Class, "") != 0 )
               {
                  subGridfilteredproducts_Linesclass = subGridfilteredproducts_Class+"Odd";
               }
            }
            else if ( subGridfilteredproducts_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGridfilteredproducts_Backstyle = 0;
               subGridfilteredproducts_Backcolor = subGridfilteredproducts_Allbackcolor;
               if ( StringUtil.StrCmp(subGridfilteredproducts_Class, "") != 0 )
               {
                  subGridfilteredproducts_Linesclass = subGridfilteredproducts_Class+"Uniform";
               }
            }
            else if ( subGridfilteredproducts_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGridfilteredproducts_Backstyle = 1;
               if ( StringUtil.StrCmp(subGridfilteredproducts_Class, "") != 0 )
               {
                  subGridfilteredproducts_Linesclass = subGridfilteredproducts_Class+"Odd";
               }
               subGridfilteredproducts_Backcolor = (int)(0x0);
            }
            else if ( subGridfilteredproducts_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGridfilteredproducts_Backstyle = 1;
               if ( ((int)((nGXsfl_49_idx) % (2))) == 0 )
               {
                  subGridfilteredproducts_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridfilteredproducts_Class, "") != 0 )
                  {
                     subGridfilteredproducts_Linesclass = subGridfilteredproducts_Class+"Even";
                  }
               }
               else
               {
                  subGridfilteredproducts_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridfilteredproducts_Class, "") != 0 )
                  {
                     subGridfilteredproducts_Linesclass = subGridfilteredproducts_Class+"Odd";
                  }
               }
            }
            if ( GridfilteredproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"PromptGrid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_49_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridfilteredproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridfilteredproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV37SDTProductsFiltered.Item(AV40GXV1)).gxTpr_Id), 6, 0, ".", "")),StringUtil.LTrim( ((edtavCtlid_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV37SDTProductsFiltered.Item(AV40GXV1)).gxTpr_Id), "ZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV37SDTProductsFiltered.Item(AV40GXV1)).gxTpr_Id), "ZZZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(int)edtavCtlid_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)49,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridfilteredproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridfilteredproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcode_Internalname,((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV37SDTProductsFiltered.Item(AV40GXV1)).gxTpr_Code,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcode_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlcode_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)49,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridfilteredproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridfilteredproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname_Internalname,((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV37SDTProductsFiltered.Item(AV40GXV1)).gxTpr_Name,(string)"",(string)"","'"+""+"'"+",false,"+"'"+"ECTLNAME.CLICK."+sGXsfl_49_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlname_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)49,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridfilteredproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridfilteredproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlstock1_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV37SDTProductsFiltered.Item(AV40GXV1)).gxTpr_Stock), 6, 0, ".", "")),StringUtil.LTrim( ((edtavCtlstock1_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV37SDTProductsFiltered.Item(AV40GXV1)).gxTpr_Stock), "ZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV37SDTProductsFiltered.Item(AV40GXV1)).gxTpr_Stock), "ZZZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlstock1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlstock1_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)49,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridfilteredproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridfilteredproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlminiumstock_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV37SDTProductsFiltered.Item(AV40GXV1)).gxTpr_Miniumstock), 6, 0, ".", "")),StringUtil.LTrim( ((edtavCtlminiumstock_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV37SDTProductsFiltered.Item(AV40GXV1)).gxTpr_Miniumstock), "ZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV37SDTProductsFiltered.Item(AV40GXV1)).gxTpr_Miniumstock), "ZZZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlminiumstock_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlminiumstock_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)49,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridfilteredproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridfilteredproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcostprice_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV37SDTProductsFiltered.Item(AV40GXV1)).gxTpr_Costprice, 10, 2, ".", "")),StringUtil.LTrim( ((edtavCtlcostprice_Enabled!=0) ? context.localUtil.Format( ((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV37SDTProductsFiltered.Item(AV40GXV1)).gxTpr_Costprice, "ZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV37SDTProductsFiltered.Item(AV40GXV1)).gxTpr_Costprice, "ZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcostprice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlcostprice_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)49,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridfilteredproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridfilteredproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsupplier_Internalname,((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV37SDTProductsFiltered.Item(AV40GXV1)).gxTpr_Supplier,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlsupplier_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlsupplier_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)49,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridfilteredproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridfilteredproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlbrand_Internalname,((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV37SDTProductsFiltered.Item(AV40GXV1)).gxTpr_Brand,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlbrand_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlbrand_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)49,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridfilteredproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridfilteredproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsector_Internalname,((SdtSDTProductsFiltered_SDTProductsFilteredItem)AV37SDTProductsFiltered.Item(AV40GXV1)).gxTpr_Sector,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlsector_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlsector_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)49,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes2M2( ) ;
            GridfilteredproductsContainer.AddRow(GridfilteredproductsRow);
            nGXsfl_49_idx = ((subGridfilteredproducts_Islastpage==1)&&(nGXsfl_49_idx+1>subGridfilteredproducts_fnc_Recordsperpage( )) ? 1 : nGXsfl_49_idx+1);
            sGXsfl_49_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_49_idx), 4, 0), 4, "0");
            SubsflControlProps_492( ) ;
         }
         /* End function sendrow_492 */
      }

      protected void SubsflControlProps_804( )
      {
         edtavCtlname1_Internalname = "CTLNAME1_"+sGXsfl_80_idx;
         edtavCtlstock_Internalname = "CTLSTOCK_"+sGXsfl_80_idx;
         edtavCtlquantity1_Internalname = "CTLQUANTITY1_"+sGXsfl_80_idx;
      }

      protected void SubsflControlProps_fel_804( )
      {
         edtavCtlname1_Internalname = "CTLNAME1_"+sGXsfl_80_fel_idx;
         edtavCtlstock_Internalname = "CTLSTOCK_"+sGXsfl_80_fel_idx;
         edtavCtlquantity1_Internalname = "CTLQUANTITY1_"+sGXsfl_80_fel_idx;
      }

      protected void sendrow_804( )
      {
         SubsflControlProps_804( ) ;
         WB2M0( ) ;
         if ( ( 5 * 1 == 0 ) || ( nGXsfl_80_idx <= subCarproducts_fnc_Recordsperpage( ) * 1 ) )
         {
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
               if ( ((int)((nGXsfl_80_idx) % (2))) == 0 )
               {
                  subCarproducts_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subCarproducts_Class, "") != 0 )
                  {
                     subCarproducts_Linesclass = subCarproducts_Class+"Even";
                  }
               }
               else
               {
                  subCarproducts_Backcolor = (int)(0xFFFFFF);
                  if ( StringUtil.StrCmp(subCarproducts_Class, "") != 0 )
                  {
                     subCarproducts_Linesclass = subCarproducts_Class+"Odd";
                  }
               }
            }
            /* Start of Columns property logic. */
            if ( CarproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr"+" class=\""+subCarproducts_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_80_idx+"\">") ;
            }
            /* Div Control */
            CarproductsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divGrid1table_Internalname+"_"+sGXsfl_80_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            CarproductsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            CarproductsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            CarproductsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            CarproductsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname1_Internalname,(string)"Name",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
            /* Single line edit */
            ROClassString = "Attribute";
            CarproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname1_Internalname,((SdtSDTCarProducts_SDTCarProductsItem)AV10Car.Item(AV50GXV11)).gxTpr_Name,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlname1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlname1_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)80,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            CarproductsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            CarproductsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            /* Div Control */
            CarproductsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            CarproductsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            CarproductsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlstock_Internalname,(string)"Stock",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
            /* Single line edit */
            ROClassString = "Attribute";
            CarproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlstock_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV10Car.Item(AV50GXV11)).gxTpr_Stock), 6, 0, ".", "")),StringUtil.LTrim( ((edtavCtlstock_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV10Car.Item(AV50GXV11)).gxTpr_Stock), "ZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV10Car.Item(AV50GXV11)).gxTpr_Stock), "ZZZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlstock_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlstock_Enabled,(short)0,(string)"text",(string)"1",(short)6,(string)"chr",(short)1,(string)"row",(short)6,(short)0,(short)0,(short)80,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            CarproductsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            CarproductsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            /* Div Control */
            CarproductsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            CarproductsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            CarproductsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlquantity1_Internalname,(string)"Quantity",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
            /* Single line edit */
            TempTags = " " + ((edtavCtlquantity1_Enabled!=0)&&(edtavCtlquantity1_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 91,'',false,'"+sGXsfl_80_idx+"',80)\"" : " ");
            ROClassString = "Attribute";
            CarproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlquantity1_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV10Car.Item(AV50GXV11)).gxTpr_Quantity), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV10Car.Item(AV50GXV11)).gxTpr_Quantity), "ZZZZZ9"))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+((edtavCtlquantity1_Enabled!=0)&&(edtavCtlquantity1_Visible!=0) ? " onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,91);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlquantity1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)1,(short)0,(string)"text",(string)"1",(short)6,(string)"chr",(short)1,(string)"row",(short)6,(short)0,(short)0,(short)80,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            CarproductsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            CarproductsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            /* Div Control */
            CarproductsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            CarproductsRow.AddColumnProperties("button", 2, isAjaxCallMode( ), new Object[] {(string)bttRemove_Internalname+"_"+sGXsfl_80_idx,"gx.evt.setGridEvt("+StringUtil.Str( (decimal)(80), 2, 0)+","+"null"+");",(string)"Remove",(string)bttRemove_Jsonclick,(short)5,(string)"Remove",(string)"",(string)StyleString,(string)ClassString,(short)1,(short)1,(string)"standard","'"+""+"'"+",false,"+"'"+"E\\'REMOVE\\'."+"'",(string)TempTags,(string)"",context.GetButtonType( )});
            CarproductsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            CarproductsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            CarproductsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            send_integrity_lvl_hashes2M4( ) ;
            /* End of Columns property logic. */
            CarproductsContainer.AddRow(CarproductsRow);
            nGXsfl_80_idx = ((subCarproducts_Islastpage==1)&&(nGXsfl_80_idx+1>subCarproducts_fnc_Recordsperpage( )) ? 1 : nGXsfl_80_idx+1);
            sGXsfl_80_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_80_idx), 4, 0), 4, "0");
            SubsflControlProps_804( ) ;
         }
         /* End function sendrow_804 */
      }

      protected void SubsflControlProps_1073( )
      {
         edtavCtlpurchaseorderid_Internalname = "CTLPURCHASEORDERID_"+sGXsfl_107_idx;
         edtavCtlsuppliername_Internalname = "CTLSUPPLIERNAME_"+sGXsfl_107_idx;
         edtavCtlpurchaseorderdetailsquantity_Internalname = "CTLPURCHASEORDERDETAILSQUANTITY_"+sGXsfl_107_idx;
         edtavCtldetailslink_Internalname = "CTLDETAILSLINK_"+sGXsfl_107_idx;
         edtavCtlsdtvoucherlink_Internalname = "CTLSDTVOUCHERLINK_"+sGXsfl_107_idx;
      }

      protected void SubsflControlProps_fel_1073( )
      {
         edtavCtlpurchaseorderid_Internalname = "CTLPURCHASEORDERID_"+sGXsfl_107_fel_idx;
         edtavCtlsuppliername_Internalname = "CTLSUPPLIERNAME_"+sGXsfl_107_fel_idx;
         edtavCtlpurchaseorderdetailsquantity_Internalname = "CTLPURCHASEORDERDETAILSQUANTITY_"+sGXsfl_107_fel_idx;
         edtavCtldetailslink_Internalname = "CTLDETAILSLINK_"+sGXsfl_107_fel_idx;
         edtavCtlsdtvoucherlink_Internalname = "CTLSDTVOUCHERLINK_"+sGXsfl_107_fel_idx;
      }

      protected void sendrow_1073( )
      {
         SubsflControlProps_1073( ) ;
         WB2M0( ) ;
         if ( ( 5 * 1 == 0 ) || ( nGXsfl_107_idx <= subAllvouchers_fnc_Recordsperpage( ) * 1 ) )
         {
            AllvouchersRow = GXWebRow.GetNew(context,AllvouchersContainer);
            if ( subAllvouchers_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subAllvouchers_Backstyle = 0;
               if ( StringUtil.StrCmp(subAllvouchers_Class, "") != 0 )
               {
                  subAllvouchers_Linesclass = subAllvouchers_Class+"Odd";
               }
            }
            else if ( subAllvouchers_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subAllvouchers_Backstyle = 0;
               subAllvouchers_Backcolor = subAllvouchers_Allbackcolor;
               if ( StringUtil.StrCmp(subAllvouchers_Class, "") != 0 )
               {
                  subAllvouchers_Linesclass = subAllvouchers_Class+"Uniform";
               }
            }
            else if ( subAllvouchers_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subAllvouchers_Backstyle = 1;
               if ( StringUtil.StrCmp(subAllvouchers_Class, "") != 0 )
               {
                  subAllvouchers_Linesclass = subAllvouchers_Class+"Odd";
               }
               subAllvouchers_Backcolor = (int)(0x0);
            }
            else if ( subAllvouchers_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subAllvouchers_Backstyle = 1;
               if ( ((int)((nGXsfl_107_idx) % (2))) == 0 )
               {
                  subAllvouchers_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subAllvouchers_Class, "") != 0 )
                  {
                     subAllvouchers_Linesclass = subAllvouchers_Class+"Even";
                  }
               }
               else
               {
                  subAllvouchers_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subAllvouchers_Class, "") != 0 )
                  {
                     subAllvouchers_Linesclass = subAllvouchers_Class+"Odd";
                  }
               }
            }
            if ( AllvouchersContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"PromptGrid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_107_idx+"\">") ;
            }
            /* Subfile cell */
            if ( AllvouchersContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllvouchersRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlpurchaseorderid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV27SDTPurchaseOrderGenerateList.Item(AV54GXV15)).gxTpr_Purchaseorderid), 6, 0, ".", "")),StringUtil.LTrim( ((edtavCtlpurchaseorderid_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV27SDTPurchaseOrderGenerateList.Item(AV54GXV15)).gxTpr_Purchaseorderid), "ZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV27SDTPurchaseOrderGenerateList.Item(AV54GXV15)).gxTpr_Purchaseorderid), "ZZZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlpurchaseorderid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(int)edtavCtlpurchaseorderid_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( AllvouchersContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllvouchersRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsuppliername_Internalname,((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV27SDTPurchaseOrderGenerateList.Item(AV54GXV15)).gxTpr_Suppliername,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlsuppliername_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlsuppliername_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( AllvouchersContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllvouchersRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlpurchaseorderdetailsquantity_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV27SDTPurchaseOrderGenerateList.Item(AV54GXV15)).gxTpr_Purchaseorderdetailsquantity), 4, 0, ".", "")),StringUtil.LTrim( ((edtavCtlpurchaseorderdetailsquantity_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV27SDTPurchaseOrderGenerateList.Item(AV54GXV15)).gxTpr_Purchaseorderdetailsquantity), "ZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV27SDTPurchaseOrderGenerateList.Item(AV54GXV15)).gxTpr_Purchaseorderdetailsquantity), "ZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlpurchaseorderdetailsquantity_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlpurchaseorderdetailsquantity_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( AllvouchersContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllvouchersRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtldetailslink_Internalname,((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV27SDTPurchaseOrderGenerateList.Item(AV54GXV15)).gxTpr_Detailslink,(string)"",(string)"","'"+""+"'"+",false,"+"'"+"ECTLDETAILSLINK.CLICK."+sGXsfl_107_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtldetailslink_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtldetailslink_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( AllvouchersContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllvouchersRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsdtvoucherlink_Internalname,((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV27SDTPurchaseOrderGenerateList.Item(AV54GXV15)).gxTpr_Sdtvoucherlink,(string)"",(string)"","'"+""+"'"+",false,"+"'"+"ECTLSDTVOUCHERLINK.CLICK."+sGXsfl_107_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlsdtvoucherlink_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlsdtvoucherlink_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)107,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes2M3( ) ;
            AllvouchersContainer.AddRow(AllvouchersRow);
            nGXsfl_107_idx = ((subAllvouchers_Islastpage==1)&&(nGXsfl_107_idx+1>subAllvouchers_fnc_Recordsperpage( )) ? 1 : nGXsfl_107_idx+1);
            sGXsfl_107_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_107_idx), 4, 0), 4, "0");
            SubsflControlProps_1073( ) ;
         }
         /* End function sendrow_1073 */
      }

      protected void init_web_controls( )
      {
         dynavSupplier.Name = "vSUPPLIER";
         dynavSupplier.WebTags = "";
         dynavBrand.Name = "vBRAND";
         dynavBrand.WebTags = "";
         dynavSector.Name = "vSECTOR";
         dynavSector.WebTags = "";
         /* End function init_web_controls */
      }

      protected void StartGridControl49( )
      {
         if ( GridfilteredproductsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridfilteredproductsContainer"+"DivS\" data-gxgridid=\"49\">") ;
            sStyleString = "";
            if ( subGridfilteredproducts_Collapsed != 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, subGridfilteredproducts_Internalname, subGridfilteredproducts_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGridfilteredproducts_Backcolorstyle == 0 )
            {
               subGridfilteredproducts_Titlebackstyle = 0;
               if ( StringUtil.Len( subGridfilteredproducts_Class) > 0 )
               {
                  subGridfilteredproducts_Linesclass = subGridfilteredproducts_Class+"Title";
               }
            }
            else
            {
               subGridfilteredproducts_Titlebackstyle = 1;
               if ( subGridfilteredproducts_Backcolorstyle == 1 )
               {
                  subGridfilteredproducts_Titlebackcolor = subGridfilteredproducts_Allbackcolor;
                  if ( StringUtil.Len( subGridfilteredproducts_Class) > 0 )
                  {
                     subGridfilteredproducts_Linesclass = subGridfilteredproducts_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGridfilteredproducts_Class) > 0 )
                  {
                     subGridfilteredproducts_Linesclass = subGridfilteredproducts_Class+"Title";
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
            context.SendWebValue( "Product") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Current Stock") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Minium Stock") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Cost Price") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Supplier") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Brand") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Sector") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridfilteredproductsContainer.AddObjectProperty("GridName", "Gridfilteredproducts");
         }
         else
         {
            GridfilteredproductsContainer.AddObjectProperty("GridName", "Gridfilteredproducts");
            GridfilteredproductsContainer.AddObjectProperty("Header", subGridfilteredproducts_Header);
            GridfilteredproductsContainer.AddObjectProperty("Class", "PromptGrid");
            GridfilteredproductsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridfilteredproductsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridfilteredproductsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridfilteredproducts_Backcolorstyle), 1, 0, ".", "")));
            GridfilteredproductsContainer.AddObjectProperty("CmpContext", "");
            GridfilteredproductsContainer.AddObjectProperty("InMasterPage", "false");
            GridfilteredproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridfilteredproductsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlid_Enabled), 5, 0, ".", "")));
            GridfilteredproductsContainer.AddColumnProperties(GridfilteredproductsColumn);
            GridfilteredproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridfilteredproductsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlcode_Enabled), 5, 0, ".", "")));
            GridfilteredproductsContainer.AddColumnProperties(GridfilteredproductsColumn);
            GridfilteredproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridfilteredproductsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlname_Enabled), 5, 0, ".", "")));
            GridfilteredproductsContainer.AddColumnProperties(GridfilteredproductsColumn);
            GridfilteredproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridfilteredproductsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlstock1_Enabled), 5, 0, ".", "")));
            GridfilteredproductsContainer.AddColumnProperties(GridfilteredproductsColumn);
            GridfilteredproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridfilteredproductsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlminiumstock_Enabled), 5, 0, ".", "")));
            GridfilteredproductsContainer.AddColumnProperties(GridfilteredproductsColumn);
            GridfilteredproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridfilteredproductsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlcostprice_Enabled), 5, 0, ".", "")));
            GridfilteredproductsContainer.AddColumnProperties(GridfilteredproductsColumn);
            GridfilteredproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridfilteredproductsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlsupplier_Enabled), 5, 0, ".", "")));
            GridfilteredproductsContainer.AddColumnProperties(GridfilteredproductsColumn);
            GridfilteredproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridfilteredproductsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlbrand_Enabled), 5, 0, ".", "")));
            GridfilteredproductsContainer.AddColumnProperties(GridfilteredproductsColumn);
            GridfilteredproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridfilteredproductsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlsector_Enabled), 5, 0, ".", "")));
            GridfilteredproductsContainer.AddColumnProperties(GridfilteredproductsColumn);
            GridfilteredproductsContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridfilteredproducts_Selectedindex), 4, 0, ".", "")));
            GridfilteredproductsContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridfilteredproducts_Allowselection), 1, 0, ".", "")));
            GridfilteredproductsContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridfilteredproducts_Selectioncolor), 9, 0, ".", "")));
            GridfilteredproductsContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridfilteredproducts_Allowhovering), 1, 0, ".", "")));
            GridfilteredproductsContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridfilteredproducts_Hoveringcolor), 9, 0, ".", "")));
            GridfilteredproductsContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridfilteredproducts_Allowcollapsing), 1, 0, ".", "")));
            GridfilteredproductsContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridfilteredproducts_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void StartGridControl80( )
      {
         if ( CarproductsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"CarproductsContainer"+"DivS\" data-gxgridid=\"80\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subCarproducts_Internalname, subCarproducts_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            CarproductsContainer.AddObjectProperty("GridName", "Carproducts");
         }
         else
         {
            CarproductsContainer.AddObjectProperty("GridName", "Carproducts");
            CarproductsContainer.AddObjectProperty("Header", subCarproducts_Header);
            CarproductsContainer.AddObjectProperty("Class", StringUtil.RTrim( "PromptGrid"));
            CarproductsContainer.AddObjectProperty("Class", "PromptGrid");
            CarproductsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            CarproductsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
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
            CarproductsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlname1_Enabled), 5, 0, ".", "")));
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
            CarproductsContainer.AddColumnProperties(CarproductsColumn);
            CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CarproductsContainer.AddColumnProperties(CarproductsColumn);
            CarproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
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

      protected void StartGridControl107( )
      {
         if ( AllvouchersContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"AllvouchersContainer"+"DivS\" data-gxgridid=\"107\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subAllvouchers_Internalname, subAllvouchers_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subAllvouchers_Backcolorstyle == 0 )
            {
               subAllvouchers_Titlebackstyle = 0;
               if ( StringUtil.Len( subAllvouchers_Class) > 0 )
               {
                  subAllvouchers_Linesclass = subAllvouchers_Class+"Title";
               }
            }
            else
            {
               subAllvouchers_Titlebackstyle = 1;
               if ( subAllvouchers_Backcolorstyle == 1 )
               {
                  subAllvouchers_Titlebackcolor = subAllvouchers_Allbackcolor;
                  if ( StringUtil.Len( subAllvouchers_Class) > 0 )
                  {
                     subAllvouchers_Linesclass = subAllvouchers_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subAllvouchers_Class) > 0 )
                  {
                     subAllvouchers_Linesclass = subAllvouchers_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Purchase Order Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Supplier") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Quantity Products") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Details Link") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Links") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            AllvouchersContainer.AddObjectProperty("GridName", "Allvouchers");
         }
         else
         {
            AllvouchersContainer.AddObjectProperty("GridName", "Allvouchers");
            AllvouchersContainer.AddObjectProperty("Header", subAllvouchers_Header);
            AllvouchersContainer.AddObjectProperty("Class", "PromptGrid");
            AllvouchersContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            AllvouchersContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            AllvouchersContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAllvouchers_Backcolorstyle), 1, 0, ".", "")));
            AllvouchersContainer.AddObjectProperty("CmpContext", "");
            AllvouchersContainer.AddObjectProperty("InMasterPage", "false");
            AllvouchersColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllvouchersColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlpurchaseorderid_Enabled), 5, 0, ".", "")));
            AllvouchersContainer.AddColumnProperties(AllvouchersColumn);
            AllvouchersColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllvouchersColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlsuppliername_Enabled), 5, 0, ".", "")));
            AllvouchersContainer.AddColumnProperties(AllvouchersColumn);
            AllvouchersColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllvouchersColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlpurchaseorderdetailsquantity_Enabled), 5, 0, ".", "")));
            AllvouchersContainer.AddColumnProperties(AllvouchersColumn);
            AllvouchersColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllvouchersColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtldetailslink_Enabled), 5, 0, ".", "")));
            AllvouchersContainer.AddColumnProperties(AllvouchersColumn);
            AllvouchersColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllvouchersColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlsdtvoucherlink_Enabled), 5, 0, ".", "")));
            AllvouchersContainer.AddColumnProperties(AllvouchersColumn);
            AllvouchersContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAllvouchers_Selectedindex), 4, 0, ".", "")));
            AllvouchersContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAllvouchers_Allowselection), 1, 0, ".", "")));
            AllvouchersContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAllvouchers_Selectioncolor), 9, 0, ".", "")));
            AllvouchersContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAllvouchers_Allowhovering), 1, 0, ".", "")));
            AllvouchersContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAllvouchers_Hoveringcolor), 9, 0, ".", "")));
            AllvouchersContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAllvouchers_Allowcollapsing), 1, 0, ".", "")));
            AllvouchersContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAllvouchers_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtavCode_Internalname = "vCODE";
         edtavName_Internalname = "vNAME";
         dynavSupplier_Internalname = "vSUPPLIER";
         dynavBrand_Internalname = "vBRAND";
         dynavSector_Internalname = "vSECTOR";
         Necesary_Internalname = "NECESARY";
         Ordered_Internalname = "ORDERED";
         edtavCtlid_Internalname = "CTLID";
         edtavCtlcode_Internalname = "CTLCODE";
         edtavCtlname_Internalname = "CTLNAME";
         edtavCtlstock1_Internalname = "CTLSTOCK1";
         edtavCtlminiumstock_Internalname = "CTLMINIUMSTOCK";
         edtavCtlcostprice_Internalname = "CTLCOSTPRICE";
         edtavCtlsupplier_Internalname = "CTLSUPPLIER";
         edtavCtlbrand_Internalname = "CTLBRAND";
         edtavCtlsector_Internalname = "CTLSECTOR";
         divTable1_Internalname = "TABLE1";
         bttGenerateorder_Internalname = "GENERATEORDER";
         bttClearorder_Internalname = "CLEARORDER";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtavCtlname1_Internalname = "CTLNAME1";
         edtavCtlstock_Internalname = "CTLSTOCK";
         edtavCtlquantity1_Internalname = "CTLQUANTITY1";
         bttRemove_Internalname = "REMOVE";
         divGrid1table_Internalname = "GRID1TABLE";
         divTable2_Internalname = "TABLE2";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         bttGenerateneworder_Internalname = "GENERATENEWORDER";
         edtavCtlpurchaseorderid_Internalname = "CTLPURCHASEORDERID";
         edtavCtlsuppliername_Internalname = "CTLSUPPLIERNAME";
         edtavCtlpurchaseorderdetailsquantity_Internalname = "CTLPURCHASEORDERDETAILSQUANTITY";
         edtavCtldetailslink_Internalname = "CTLDETAILSLINK";
         edtavCtlsdtvoucherlink_Internalname = "CTLSDTVOUCHERLINK";
         divTable3_Internalname = "TABLE3";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGridfilteredproducts_Internalname = "GRIDFILTEREDPRODUCTS";
         subCarproducts_Internalname = "CARPRODUCTS";
         subAllvouchers_Internalname = "ALLVOUCHERS";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("mtaKB", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subAllvouchers_Allowcollapsing = 0;
         subAllvouchers_Allowselection = 0;
         subAllvouchers_Header = "";
         subCarproducts_Allowcollapsing = 0;
         subGridfilteredproducts_Allowcollapsing = 1;
         subGridfilteredproducts_Allowselection = 0;
         subGridfilteredproducts_Header = "";
         edtavCtlsdtvoucherlink_Jsonclick = "";
         edtavCtlsdtvoucherlink_Enabled = 0;
         edtavCtldetailslink_Jsonclick = "";
         edtavCtldetailslink_Enabled = 0;
         edtavCtlpurchaseorderdetailsquantity_Jsonclick = "";
         edtavCtlpurchaseorderdetailsquantity_Enabled = 0;
         edtavCtlsuppliername_Jsonclick = "";
         edtavCtlsuppliername_Enabled = 0;
         edtavCtlpurchaseorderid_Jsonclick = "";
         edtavCtlpurchaseorderid_Enabled = 0;
         subAllvouchers_Class = "PromptGrid";
         subAllvouchers_Backcolorstyle = 0;
         edtavCtlquantity1_Jsonclick = "";
         edtavCtlquantity1_Visible = 1;
         edtavCtlquantity1_Enabled = 1;
         edtavCtlstock_Jsonclick = "";
         edtavCtlstock_Enabled = 0;
         edtavCtlname1_Jsonclick = "";
         edtavCtlname1_Enabled = 0;
         subCarproducts_Class = "PromptGrid";
         edtavCtlsector_Jsonclick = "";
         edtavCtlsector_Enabled = 0;
         edtavCtlbrand_Jsonclick = "";
         edtavCtlbrand_Enabled = 0;
         edtavCtlsupplier_Jsonclick = "";
         edtavCtlsupplier_Enabled = 0;
         edtavCtlcostprice_Jsonclick = "";
         edtavCtlcostprice_Enabled = 0;
         edtavCtlminiumstock_Jsonclick = "";
         edtavCtlminiumstock_Enabled = 0;
         edtavCtlstock1_Jsonclick = "";
         edtavCtlstock1_Enabled = 0;
         edtavCtlname_Jsonclick = "";
         edtavCtlname_Enabled = 0;
         edtavCtlcode_Jsonclick = "";
         edtavCtlcode_Enabled = 0;
         edtavCtlid_Jsonclick = "";
         edtavCtlid_Enabled = 0;
         subGridfilteredproducts_Class = "PromptGrid";
         subGridfilteredproducts_Backcolorstyle = 0;
         subCarproducts_Backcolorstyle = 0;
         edtavCtlsdtvoucherlink_Enabled = -1;
         edtavCtldetailslink_Enabled = -1;
         edtavCtlpurchaseorderdetailsquantity_Enabled = -1;
         edtavCtlsuppliername_Enabled = -1;
         edtavCtlpurchaseorderid_Enabled = -1;
         edtavCtlstock_Enabled = -1;
         edtavCtlname1_Enabled = -1;
         edtavCtlsector_Enabled = -1;
         edtavCtlbrand_Enabled = -1;
         edtavCtlsupplier_Enabled = -1;
         edtavCtlcostprice_Enabled = -1;
         edtavCtlminiumstock_Enabled = -1;
         edtavCtlstock1_Enabled = -1;
         edtavCtlname_Enabled = -1;
         edtavCtlcode_Enabled = -1;
         edtavCtlid_Enabled = -1;
         divTable3_Visible = 1;
         divTable2_Visible = 1;
         dynavSector_Jsonclick = "";
         dynavSector.Enabled = 1;
         dynavBrand_Jsonclick = "";
         dynavBrand.Enabled = 1;
         dynavSupplier_Jsonclick = "";
         dynavSupplier.Enabled = 1;
         edtavName_Jsonclick = "";
         edtavName_Enabled = 1;
         edtavCode_Jsonclick = "";
         edtavCode_Enabled = 1;
         divTable1_Visible = 1;
         Ordered_Captionposition = "Top";
         Ordered_Captionstyle = "";
         Ordered_Captionclass = "col-xs-12 AttributeLabel";
         Ordered_Enabled = Convert.ToBoolean( -1);
         Necesary_Captionposition = "Top";
         Necesary_Captionstyle = "";
         Necesary_Captionclass = "col-xs-12 AttributeLabel";
         Necesary_Enabled = Convert.ToBoolean( -1);
         subGridfilteredproducts_Collapsed = 0;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "WPGenerate Purchase Copy1";
         subAllvouchers_Rows = 5;
         subCarproducts_Rows = 5;
         subGridfilteredproducts_Rows = 5;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRIDFILTEREDPRODUCTS_nFirstRecordOnPage'},{av:'GRIDFILTEREDPRODUCTS_nEOF'},{av:'AV37SDTProductsFiltered',fld:'vSDTPRODUCTSFILTERED',grid:49,pic:''},{av:'nGXsfl_49_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:49},{av:'nRC_GXsfl_49',ctrl:'GRIDFILTEREDPRODUCTS',prop:'GridRC',grid:49},{av:'ALLVOUCHERS_nFirstRecordOnPage'},{av:'ALLVOUCHERS_nEOF'},{av:'AV27SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:107,pic:''},{av:'nGXsfl_107_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:107},{av:'nRC_GXsfl_107',ctrl:'ALLVOUCHERS',prop:'GridRC',grid:107},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'CARPRODUCTS_nEOF'},{av:'AV10Car',fld:'vCAR',grid:80,pic:''},{av:'nGXsfl_80_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:80},{av:'nRC_GXsfl_80',ctrl:'CARPRODUCTS',prop:'GridRC',grid:80},{av:'subGridfilteredproducts_Rows',ctrl:'GRIDFILTEREDPRODUCTS',prop:'Rows'},{av:'subCarproducts_Rows',ctrl:'CARPRODUCTS',prop:'Rows'},{av:'subAllvouchers_Rows',ctrl:'ALLVOUCHERS',prop:'Rows'},{av:'dynavSupplier'},{av:'AV29Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV9Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV31Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV6NewName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5NewCode',fld:'vNEWCODE',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'GENERATEORDER'","{handler:'E132M2',iparms:[{av:'AV10Car',fld:'vCAR',grid:80,pic:''},{av:'nGXsfl_80_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:80},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'nRC_GXsfl_80',ctrl:'CARPRODUCTS',prop:'GridRC',grid:80},{av:'AV30SuppliersId',fld:'vSUPPLIERSID',pic:''},{av:'AV19Orders',fld:'vORDERS',pic:''},{av:'AV27SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:107,pic:''},{av:'nGXsfl_107_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:107},{av:'ALLVOUCHERS_nFirstRecordOnPage'},{av:'nRC_GXsfl_107',ctrl:'ALLVOUCHERS',prop:'GridRC',grid:107},{av:'GRIDFILTEREDPRODUCTS_nFirstRecordOnPage'},{av:'GRIDFILTEREDPRODUCTS_nEOF'},{av:'AV37SDTProductsFiltered',fld:'vSDTPRODUCTSFILTERED',grid:49,pic:''},{av:'nGXsfl_49_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:49},{av:'nRC_GXsfl_49',ctrl:'GRIDFILTEREDPRODUCTS',prop:'GridRC',grid:49},{av:'ALLVOUCHERS_nEOF'},{av:'CARPRODUCTS_nEOF'},{av:'subGridfilteredproducts_Rows',ctrl:'GRIDFILTEREDPRODUCTS',prop:'Rows'},{av:'subCarproducts_Rows',ctrl:'CARPRODUCTS',prop:'Rows'},{av:'subAllvouchers_Rows',ctrl:'ALLVOUCHERS',prop:'Rows'},{av:'dynavSupplier'},{av:'AV29Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV9Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV31Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV6NewName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5NewCode',fld:'vNEWCODE',pic:'',hsh:true}]");
         setEventMetadata("'GENERATEORDER'",",oparms:[{av:'AV12CarItem',fld:'vCARITEM',pic:''},{av:'AV30SuppliersId',fld:'vSUPPLIERSID',pic:''},{av:'AV19Orders',fld:'vORDERS',pic:''},{av:'AV27SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:107,pic:''},{av:'nGXsfl_107_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:107},{av:'ALLVOUCHERS_nFirstRecordOnPage'},{av:'nRC_GXsfl_107',ctrl:'ALLVOUCHERS',prop:'GridRC',grid:107},{av:'AV28SelectedId',fld:'vSELECTEDID',pic:''},{av:'AV10Car',fld:'vCAR',grid:80,pic:''},{av:'nGXsfl_80_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:80},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'nRC_GXsfl_80',ctrl:'CARPRODUCTS',prop:'GridRC',grid:80},{av:'divTable1_Visible',ctrl:'TABLE1',prop:'Visible'},{av:'divTable2_Visible',ctrl:'TABLE2',prop:'Visible'},{av:'divTable3_Visible',ctrl:'TABLE3',prop:'Visible'}]}");
         setEventMetadata("'CLEARORDER'","{handler:'E142M2',iparms:[{av:'AV10Car',fld:'vCAR',grid:80,pic:''},{av:'nGXsfl_80_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:80},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'nRC_GXsfl_80',ctrl:'CARPRODUCTS',prop:'GridRC',grid:80},{av:'GRIDFILTEREDPRODUCTS_nFirstRecordOnPage'},{av:'GRIDFILTEREDPRODUCTS_nEOF'},{av:'AV37SDTProductsFiltered',fld:'vSDTPRODUCTSFILTERED',grid:49,pic:''},{av:'nGXsfl_49_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:49},{av:'nRC_GXsfl_49',ctrl:'GRIDFILTEREDPRODUCTS',prop:'GridRC',grid:49},{av:'ALLVOUCHERS_nFirstRecordOnPage'},{av:'ALLVOUCHERS_nEOF'},{av:'AV27SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:107,pic:''},{av:'nGXsfl_107_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:107},{av:'nRC_GXsfl_107',ctrl:'ALLVOUCHERS',prop:'GridRC',grid:107},{av:'CARPRODUCTS_nEOF'},{av:'subGridfilteredproducts_Rows',ctrl:'GRIDFILTEREDPRODUCTS',prop:'Rows'},{av:'subCarproducts_Rows',ctrl:'CARPRODUCTS',prop:'Rows'},{av:'subAllvouchers_Rows',ctrl:'ALLVOUCHERS',prop:'Rows'},{av:'dynavSupplier'},{av:'AV29Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV9Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV31Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV6NewName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5NewCode',fld:'vNEWCODE',pic:'',hsh:true}]");
         setEventMetadata("'CLEARORDER'",",oparms:[{av:'AV28SelectedId',fld:'vSELECTEDID',pic:''},{av:'AV10Car',fld:'vCAR',grid:80,pic:''},{av:'nGXsfl_80_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:80},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'nRC_GXsfl_80',ctrl:'CARPRODUCTS',prop:'GridRC',grid:80},{av:'divTable2_Visible',ctrl:'TABLE2',prop:'Visible'}]}");
         setEventMetadata("'REMOVE'","{handler:'E212M2',iparms:[{av:'AV10Car',fld:'vCAR',grid:80,pic:''},{av:'nGXsfl_80_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:80},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'nRC_GXsfl_80',ctrl:'CARPRODUCTS',prop:'GridRC',grid:80},{av:'AV28SelectedId',fld:'vSELECTEDID',pic:''},{av:'GRIDFILTEREDPRODUCTS_nFirstRecordOnPage'},{av:'GRIDFILTEREDPRODUCTS_nEOF'},{av:'AV37SDTProductsFiltered',fld:'vSDTPRODUCTSFILTERED',grid:49,pic:''},{av:'nGXsfl_49_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:49},{av:'nRC_GXsfl_49',ctrl:'GRIDFILTEREDPRODUCTS',prop:'GridRC',grid:49},{av:'ALLVOUCHERS_nFirstRecordOnPage'},{av:'ALLVOUCHERS_nEOF'},{av:'AV27SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:107,pic:''},{av:'nGXsfl_107_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:107},{av:'nRC_GXsfl_107',ctrl:'ALLVOUCHERS',prop:'GridRC',grid:107},{av:'CARPRODUCTS_nEOF'},{av:'subGridfilteredproducts_Rows',ctrl:'GRIDFILTEREDPRODUCTS',prop:'Rows'},{av:'subCarproducts_Rows',ctrl:'CARPRODUCTS',prop:'Rows'},{av:'subAllvouchers_Rows',ctrl:'ALLVOUCHERS',prop:'Rows'},{av:'dynavSupplier'},{av:'AV29Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV9Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV31Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV6NewName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5NewCode',fld:'vNEWCODE',pic:'',hsh:true}]");
         setEventMetadata("'REMOVE'",",oparms:[{av:'AV28SelectedId',fld:'vSELECTEDID',pic:''},{av:'AV10Car',fld:'vCAR',grid:80,pic:''},{av:'nGXsfl_80_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:80},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'nRC_GXsfl_80',ctrl:'CARPRODUCTS',prop:'GridRC',grid:80}]}");
         setEventMetadata("VBRAND.CONTROLVALUECHANGED","{handler:'E152M2',iparms:[{av:'GRIDFILTEREDPRODUCTS_nFirstRecordOnPage'},{av:'GRIDFILTEREDPRODUCTS_nEOF'},{av:'AV37SDTProductsFiltered',fld:'vSDTPRODUCTSFILTERED',grid:49,pic:''},{av:'nGXsfl_49_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:49},{av:'nRC_GXsfl_49',ctrl:'GRIDFILTEREDPRODUCTS',prop:'GridRC',grid:49},{av:'subGridfilteredproducts_Rows',ctrl:'GRIDFILTEREDPRODUCTS',prop:'Rows'},{av:'subCarproducts_Rows',ctrl:'CARPRODUCTS',prop:'Rows'},{av:'subAllvouchers_Rows',ctrl:'ALLVOUCHERS',prop:'Rows'},{av:'dynavSupplier'},{av:'AV29Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV9Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV31Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV6NewName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5NewCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'AV13Code',fld:'vCODE',pic:''},{av:'AV14Name',fld:'vNAME',pic:''},{av:'AV18Ordered',fld:'vORDERED',pic:''},{av:'AV15Necesary',fld:'vNECESARY',pic:''},{av:'ALLVOUCHERS_nFirstRecordOnPage'},{av:'ALLVOUCHERS_nEOF'},{av:'AV27SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:107,pic:''},{av:'nGXsfl_107_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:107},{av:'nRC_GXsfl_107',ctrl:'ALLVOUCHERS',prop:'GridRC',grid:107},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'CARPRODUCTS_nEOF'},{av:'AV10Car',fld:'vCAR',grid:80,pic:''},{av:'nGXsfl_80_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:80},{av:'nRC_GXsfl_80',ctrl:'CARPRODUCTS',prop:'GridRC',grid:80}]");
         setEventMetadata("VBRAND.CONTROLVALUECHANGED",",oparms:[{av:'AV37SDTProductsFiltered',fld:'vSDTPRODUCTSFILTERED',grid:49,pic:''},{av:'nGXsfl_49_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:49},{av:'GRIDFILTEREDPRODUCTS_nFirstRecordOnPage'},{av:'nRC_GXsfl_49',ctrl:'GRIDFILTEREDPRODUCTS',prop:'GridRC',grid:49},{av:'AV15Necesary',fld:'vNECESARY',pic:''},{av:'AV18Ordered',fld:'vORDERED',pic:''},{av:'dynavBrand'},{av:'AV9Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV31Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'dynavSupplier'},{av:'AV29Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV14Name',fld:'vNAME',pic:''}]}");
         setEventMetadata("VSUPPLIER.CONTROLVALUECHANGED","{handler:'E162M2',iparms:[{av:'GRIDFILTEREDPRODUCTS_nFirstRecordOnPage'},{av:'GRIDFILTEREDPRODUCTS_nEOF'},{av:'AV37SDTProductsFiltered',fld:'vSDTPRODUCTSFILTERED',grid:49,pic:''},{av:'nGXsfl_49_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:49},{av:'nRC_GXsfl_49',ctrl:'GRIDFILTEREDPRODUCTS',prop:'GridRC',grid:49},{av:'subGridfilteredproducts_Rows',ctrl:'GRIDFILTEREDPRODUCTS',prop:'Rows'},{av:'subCarproducts_Rows',ctrl:'CARPRODUCTS',prop:'Rows'},{av:'subAllvouchers_Rows',ctrl:'ALLVOUCHERS',prop:'Rows'},{av:'dynavSupplier'},{av:'AV29Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV9Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV31Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV6NewName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5NewCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'AV13Code',fld:'vCODE',pic:''},{av:'AV14Name',fld:'vNAME',pic:''},{av:'AV18Ordered',fld:'vORDERED',pic:''},{av:'AV15Necesary',fld:'vNECESARY',pic:''},{av:'ALLVOUCHERS_nFirstRecordOnPage'},{av:'ALLVOUCHERS_nEOF'},{av:'AV27SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:107,pic:''},{av:'nGXsfl_107_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:107},{av:'nRC_GXsfl_107',ctrl:'ALLVOUCHERS',prop:'GridRC',grid:107},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'CARPRODUCTS_nEOF'},{av:'AV10Car',fld:'vCAR',grid:80,pic:''},{av:'nGXsfl_80_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:80},{av:'nRC_GXsfl_80',ctrl:'CARPRODUCTS',prop:'GridRC',grid:80}]");
         setEventMetadata("VSUPPLIER.CONTROLVALUECHANGED",",oparms:[{av:'AV37SDTProductsFiltered',fld:'vSDTPRODUCTSFILTERED',grid:49,pic:''},{av:'nGXsfl_49_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:49},{av:'GRIDFILTEREDPRODUCTS_nFirstRecordOnPage'},{av:'nRC_GXsfl_49',ctrl:'GRIDFILTEREDPRODUCTS',prop:'GridRC',grid:49},{av:'AV15Necesary',fld:'vNECESARY',pic:''},{av:'AV18Ordered',fld:'vORDERED',pic:''},{av:'dynavBrand'},{av:'AV9Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV31Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'dynavSupplier'},{av:'AV29Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV14Name',fld:'vNAME',pic:''}]}");
         setEventMetadata("VNAME.CONTROLVALUECHANGING","{handler:'E172M2',iparms:[{av:'GRIDFILTEREDPRODUCTS_nFirstRecordOnPage'},{av:'GRIDFILTEREDPRODUCTS_nEOF'},{av:'AV37SDTProductsFiltered',fld:'vSDTPRODUCTSFILTERED',grid:49,pic:''},{av:'nGXsfl_49_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:49},{av:'nRC_GXsfl_49',ctrl:'GRIDFILTEREDPRODUCTS',prop:'GridRC',grid:49},{av:'subGridfilteredproducts_Rows',ctrl:'GRIDFILTEREDPRODUCTS',prop:'Rows'},{av:'subCarproducts_Rows',ctrl:'CARPRODUCTS',prop:'Rows'},{av:'subAllvouchers_Rows',ctrl:'ALLVOUCHERS',prop:'Rows'},{av:'dynavSupplier'},{av:'AV29Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV9Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV31Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV6NewName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5NewCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'AV13Code',fld:'vCODE',pic:''},{av:'AV14Name',fld:'vNAME',pic:''},{av:'AV18Ordered',fld:'vORDERED',pic:''},{av:'AV15Necesary',fld:'vNECESARY',pic:''},{av:'ALLVOUCHERS_nFirstRecordOnPage'},{av:'ALLVOUCHERS_nEOF'},{av:'AV27SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:107,pic:''},{av:'nGXsfl_107_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:107},{av:'nRC_GXsfl_107',ctrl:'ALLVOUCHERS',prop:'GridRC',grid:107},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'CARPRODUCTS_nEOF'},{av:'AV10Car',fld:'vCAR',grid:80,pic:''},{av:'nGXsfl_80_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:80},{av:'nRC_GXsfl_80',ctrl:'CARPRODUCTS',prop:'GridRC',grid:80}]");
         setEventMetadata("VNAME.CONTROLVALUECHANGING",",oparms:[{av:'AV37SDTProductsFiltered',fld:'vSDTPRODUCTSFILTERED',grid:49,pic:''},{av:'nGXsfl_49_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:49},{av:'GRIDFILTEREDPRODUCTS_nFirstRecordOnPage'},{av:'nRC_GXsfl_49',ctrl:'GRIDFILTEREDPRODUCTS',prop:'GridRC',grid:49},{av:'AV15Necesary',fld:'vNECESARY',pic:''},{av:'AV18Ordered',fld:'vORDERED',pic:''},{av:'dynavBrand'},{av:'AV9Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV31Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'dynavSupplier'},{av:'AV29Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV14Name',fld:'vNAME',pic:''}]}");
         setEventMetadata("VCODE.CONTROLVALUECHANGING","{handler:'E182M2',iparms:[{av:'GRIDFILTEREDPRODUCTS_nFirstRecordOnPage'},{av:'GRIDFILTEREDPRODUCTS_nEOF'},{av:'AV37SDTProductsFiltered',fld:'vSDTPRODUCTSFILTERED',grid:49,pic:''},{av:'nGXsfl_49_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:49},{av:'nRC_GXsfl_49',ctrl:'GRIDFILTEREDPRODUCTS',prop:'GridRC',grid:49},{av:'subGridfilteredproducts_Rows',ctrl:'GRIDFILTEREDPRODUCTS',prop:'Rows'},{av:'subCarproducts_Rows',ctrl:'CARPRODUCTS',prop:'Rows'},{av:'subAllvouchers_Rows',ctrl:'ALLVOUCHERS',prop:'Rows'},{av:'dynavSupplier'},{av:'AV29Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV9Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV31Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV6NewName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5NewCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'AV13Code',fld:'vCODE',pic:''},{av:'AV14Name',fld:'vNAME',pic:''},{av:'AV18Ordered',fld:'vORDERED',pic:''},{av:'AV15Necesary',fld:'vNECESARY',pic:''},{av:'ALLVOUCHERS_nFirstRecordOnPage'},{av:'ALLVOUCHERS_nEOF'},{av:'AV27SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:107,pic:''},{av:'nGXsfl_107_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:107},{av:'nRC_GXsfl_107',ctrl:'ALLVOUCHERS',prop:'GridRC',grid:107},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'CARPRODUCTS_nEOF'},{av:'AV10Car',fld:'vCAR',grid:80,pic:''},{av:'nGXsfl_80_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:80},{av:'nRC_GXsfl_80',ctrl:'CARPRODUCTS',prop:'GridRC',grid:80}]");
         setEventMetadata("VCODE.CONTROLVALUECHANGING",",oparms:[{av:'AV37SDTProductsFiltered',fld:'vSDTPRODUCTSFILTERED',grid:49,pic:''},{av:'nGXsfl_49_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:49},{av:'GRIDFILTEREDPRODUCTS_nFirstRecordOnPage'},{av:'nRC_GXsfl_49',ctrl:'GRIDFILTEREDPRODUCTS',prop:'GridRC',grid:49},{av:'AV15Necesary',fld:'vNECESARY',pic:''},{av:'AV18Ordered',fld:'vORDERED',pic:''},{av:'dynavBrand'},{av:'AV9Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV31Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'dynavSupplier'},{av:'AV29Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV14Name',fld:'vNAME',pic:''}]}");
         setEventMetadata("VSECTOR.CONTROLVALUECHANGED","{handler:'E192M2',iparms:[{av:'GRIDFILTEREDPRODUCTS_nFirstRecordOnPage'},{av:'GRIDFILTEREDPRODUCTS_nEOF'},{av:'AV37SDTProductsFiltered',fld:'vSDTPRODUCTSFILTERED',grid:49,pic:''},{av:'nGXsfl_49_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:49},{av:'nRC_GXsfl_49',ctrl:'GRIDFILTEREDPRODUCTS',prop:'GridRC',grid:49},{av:'subGridfilteredproducts_Rows',ctrl:'GRIDFILTEREDPRODUCTS',prop:'Rows'},{av:'subCarproducts_Rows',ctrl:'CARPRODUCTS',prop:'Rows'},{av:'subAllvouchers_Rows',ctrl:'ALLVOUCHERS',prop:'Rows'},{av:'dynavSupplier'},{av:'AV29Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV9Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV31Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV6NewName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5NewCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'AV13Code',fld:'vCODE',pic:''},{av:'AV14Name',fld:'vNAME',pic:''},{av:'AV18Ordered',fld:'vORDERED',pic:''},{av:'AV15Necesary',fld:'vNECESARY',pic:''},{av:'ALLVOUCHERS_nFirstRecordOnPage'},{av:'ALLVOUCHERS_nEOF'},{av:'AV27SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:107,pic:''},{av:'nGXsfl_107_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:107},{av:'nRC_GXsfl_107',ctrl:'ALLVOUCHERS',prop:'GridRC',grid:107},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'CARPRODUCTS_nEOF'},{av:'AV10Car',fld:'vCAR',grid:80,pic:''},{av:'nGXsfl_80_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:80},{av:'nRC_GXsfl_80',ctrl:'CARPRODUCTS',prop:'GridRC',grid:80}]");
         setEventMetadata("VSECTOR.CONTROLVALUECHANGED",",oparms:[{av:'AV37SDTProductsFiltered',fld:'vSDTPRODUCTSFILTERED',grid:49,pic:''},{av:'nGXsfl_49_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:49},{av:'GRIDFILTEREDPRODUCTS_nFirstRecordOnPage'},{av:'nRC_GXsfl_49',ctrl:'GRIDFILTEREDPRODUCTS',prop:'GridRC',grid:49},{av:'AV15Necesary',fld:'vNECESARY',pic:''},{av:'AV18Ordered',fld:'vORDERED',pic:''},{av:'dynavBrand'},{av:'AV9Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV31Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'dynavSupplier'},{av:'AV29Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV14Name',fld:'vNAME',pic:''}]}");
         setEventMetadata("VNECESARY.CONTROLVALUECHANGED","{handler:'E112M2',iparms:[{av:'GRIDFILTEREDPRODUCTS_nFirstRecordOnPage'},{av:'GRIDFILTEREDPRODUCTS_nEOF'},{av:'AV37SDTProductsFiltered',fld:'vSDTPRODUCTSFILTERED',grid:49,pic:''},{av:'nGXsfl_49_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:49},{av:'nRC_GXsfl_49',ctrl:'GRIDFILTEREDPRODUCTS',prop:'GridRC',grid:49},{av:'subGridfilteredproducts_Rows',ctrl:'GRIDFILTEREDPRODUCTS',prop:'Rows'},{av:'subCarproducts_Rows',ctrl:'CARPRODUCTS',prop:'Rows'},{av:'subAllvouchers_Rows',ctrl:'ALLVOUCHERS',prop:'Rows'},{av:'dynavSupplier'},{av:'AV29Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV9Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV31Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV6NewName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5NewCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'AV13Code',fld:'vCODE',pic:''},{av:'AV14Name',fld:'vNAME',pic:''},{av:'AV18Ordered',fld:'vORDERED',pic:''},{av:'AV15Necesary',fld:'vNECESARY',pic:''},{av:'ALLVOUCHERS_nFirstRecordOnPage'},{av:'ALLVOUCHERS_nEOF'},{av:'AV27SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:107,pic:''},{av:'nGXsfl_107_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:107},{av:'nRC_GXsfl_107',ctrl:'ALLVOUCHERS',prop:'GridRC',grid:107},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'CARPRODUCTS_nEOF'},{av:'AV10Car',fld:'vCAR',grid:80,pic:''},{av:'nGXsfl_80_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:80},{av:'nRC_GXsfl_80',ctrl:'CARPRODUCTS',prop:'GridRC',grid:80}]");
         setEventMetadata("VNECESARY.CONTROLVALUECHANGED",",oparms:[{av:'AV37SDTProductsFiltered',fld:'vSDTPRODUCTSFILTERED',grid:49,pic:''},{av:'nGXsfl_49_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:49},{av:'GRIDFILTEREDPRODUCTS_nFirstRecordOnPage'},{av:'nRC_GXsfl_49',ctrl:'GRIDFILTEREDPRODUCTS',prop:'GridRC',grid:49},{av:'AV15Necesary',fld:'vNECESARY',pic:''},{av:'AV18Ordered',fld:'vORDERED',pic:''},{av:'dynavBrand'},{av:'AV9Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV31Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'dynavSupplier'},{av:'AV29Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV14Name',fld:'vNAME',pic:''}]}");
         setEventMetadata("VORDERED.CONTROLVALUECHANGED","{handler:'E122M2',iparms:[{av:'GRIDFILTEREDPRODUCTS_nFirstRecordOnPage'},{av:'GRIDFILTEREDPRODUCTS_nEOF'},{av:'AV37SDTProductsFiltered',fld:'vSDTPRODUCTSFILTERED',grid:49,pic:''},{av:'nGXsfl_49_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:49},{av:'nRC_GXsfl_49',ctrl:'GRIDFILTEREDPRODUCTS',prop:'GridRC',grid:49},{av:'subGridfilteredproducts_Rows',ctrl:'GRIDFILTEREDPRODUCTS',prop:'Rows'},{av:'subCarproducts_Rows',ctrl:'CARPRODUCTS',prop:'Rows'},{av:'subAllvouchers_Rows',ctrl:'ALLVOUCHERS',prop:'Rows'},{av:'dynavSupplier'},{av:'AV29Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV9Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV31Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV6NewName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5NewCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'AV13Code',fld:'vCODE',pic:''},{av:'AV14Name',fld:'vNAME',pic:''},{av:'AV18Ordered',fld:'vORDERED',pic:''},{av:'AV15Necesary',fld:'vNECESARY',pic:''},{av:'ALLVOUCHERS_nFirstRecordOnPage'},{av:'ALLVOUCHERS_nEOF'},{av:'AV27SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:107,pic:''},{av:'nGXsfl_107_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:107},{av:'nRC_GXsfl_107',ctrl:'ALLVOUCHERS',prop:'GridRC',grid:107},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'CARPRODUCTS_nEOF'},{av:'AV10Car',fld:'vCAR',grid:80,pic:''},{av:'nGXsfl_80_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:80},{av:'nRC_GXsfl_80',ctrl:'CARPRODUCTS',prop:'GridRC',grid:80}]");
         setEventMetadata("VORDERED.CONTROLVALUECHANGED",",oparms:[{av:'AV37SDTProductsFiltered',fld:'vSDTPRODUCTSFILTERED',grid:49,pic:''},{av:'nGXsfl_49_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:49},{av:'GRIDFILTEREDPRODUCTS_nFirstRecordOnPage'},{av:'nRC_GXsfl_49',ctrl:'GRIDFILTEREDPRODUCTS',prop:'GridRC',grid:49},{av:'AV15Necesary',fld:'vNECESARY',pic:''},{av:'AV18Ordered',fld:'vORDERED',pic:''},{av:'dynavBrand'},{av:'AV9Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV31Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'dynavSupplier'},{av:'AV29Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV14Name',fld:'vNAME',pic:''}]}");
         setEventMetadata("CTLSDTVOUCHERLINK.CLICK","{handler:'E232M2',iparms:[{av:'AV27SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:107,pic:''},{av:'nGXsfl_107_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:107},{av:'ALLVOUCHERS_nFirstRecordOnPage'},{av:'nRC_GXsfl_107',ctrl:'ALLVOUCHERS',prop:'GridRC',grid:107}]");
         setEventMetadata("CTLSDTVOUCHERLINK.CLICK",",oparms:[]}");
         setEventMetadata("CTLDETAILSLINK.CLICK","{handler:'E242M2',iparms:[{av:'AV27SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:107,pic:''},{av:'nGXsfl_107_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:107},{av:'ALLVOUCHERS_nFirstRecordOnPage'},{av:'nRC_GXsfl_107',ctrl:'ALLVOUCHERS',prop:'GridRC',grid:107}]");
         setEventMetadata("CTLDETAILSLINK.CLICK",",oparms:[]}");
         setEventMetadata("'GENERATENEWORDER'","{handler:'E202M2',iparms:[{av:'AV27SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:107,pic:''},{av:'nGXsfl_107_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:107},{av:'ALLVOUCHERS_nFirstRecordOnPage'},{av:'nRC_GXsfl_107',ctrl:'ALLVOUCHERS',prop:'GridRC',grid:107},{av:'GRIDFILTEREDPRODUCTS_nFirstRecordOnPage'},{av:'GRIDFILTEREDPRODUCTS_nEOF'},{av:'AV37SDTProductsFiltered',fld:'vSDTPRODUCTSFILTERED',grid:49,pic:''},{av:'nGXsfl_49_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:49},{av:'nRC_GXsfl_49',ctrl:'GRIDFILTEREDPRODUCTS',prop:'GridRC',grid:49},{av:'ALLVOUCHERS_nEOF'},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'CARPRODUCTS_nEOF'},{av:'AV10Car',fld:'vCAR',grid:80,pic:''},{av:'nGXsfl_80_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:80},{av:'nRC_GXsfl_80',ctrl:'CARPRODUCTS',prop:'GridRC',grid:80},{av:'subGridfilteredproducts_Rows',ctrl:'GRIDFILTEREDPRODUCTS',prop:'Rows'},{av:'subCarproducts_Rows',ctrl:'CARPRODUCTS',prop:'Rows'},{av:'subAllvouchers_Rows',ctrl:'ALLVOUCHERS',prop:'Rows'},{av:'dynavSupplier'},{av:'AV29Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV9Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV31Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV6NewName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5NewCode',fld:'vNEWCODE',pic:'',hsh:true}]");
         setEventMetadata("'GENERATENEWORDER'",",oparms:[{av:'AV27SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:107,pic:''},{av:'nGXsfl_107_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:107},{av:'ALLVOUCHERS_nFirstRecordOnPage'},{av:'nRC_GXsfl_107',ctrl:'ALLVOUCHERS',prop:'GridRC',grid:107},{av:'divTable1_Visible',ctrl:'TABLE1',prop:'Visible'},{av:'divTable2_Visible',ctrl:'TABLE2',prop:'Visible'},{av:'divTable3_Visible',ctrl:'TABLE3',prop:'Visible'}]}");
         setEventMetadata("CTLNAME.CLICK","{handler:'E272M2',iparms:[{av:'AV28SelectedId',fld:'vSELECTEDID',pic:''},{av:'AV37SDTProductsFiltered',fld:'vSDTPRODUCTSFILTERED',grid:49,pic:''},{av:'nGXsfl_49_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:49},{av:'GRIDFILTEREDPRODUCTS_nFirstRecordOnPage'},{av:'nRC_GXsfl_49',ctrl:'GRIDFILTEREDPRODUCTS',prop:'GridRC',grid:49},{av:'AV12CarItem',fld:'vCARITEM',pic:''},{av:'AV11CarAux',fld:'vCARAUX',pic:''},{av:'AV10Car',fld:'vCAR',grid:80,pic:''},{av:'nGXsfl_80_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:80},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'nRC_GXsfl_80',ctrl:'CARPRODUCTS',prop:'GridRC',grid:80},{av:'GRIDFILTEREDPRODUCTS_nEOF'},{av:'ALLVOUCHERS_nFirstRecordOnPage'},{av:'ALLVOUCHERS_nEOF'},{av:'AV27SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:107,pic:''},{av:'nGXsfl_107_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:107},{av:'nRC_GXsfl_107',ctrl:'ALLVOUCHERS',prop:'GridRC',grid:107},{av:'CARPRODUCTS_nEOF'},{av:'subGridfilteredproducts_Rows',ctrl:'GRIDFILTEREDPRODUCTS',prop:'Rows'},{av:'subCarproducts_Rows',ctrl:'CARPRODUCTS',prop:'Rows'},{av:'subAllvouchers_Rows',ctrl:'ALLVOUCHERS',prop:'Rows'},{av:'dynavSupplier'},{av:'AV29Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV9Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV31Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV6NewName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5NewCode',fld:'vNEWCODE',pic:'',hsh:true}]");
         setEventMetadata("CTLNAME.CLICK",",oparms:[{av:'AV12CarItem',fld:'vCARITEM',pic:''},{av:'AV28SelectedId',fld:'vSELECTEDID',pic:''},{av:'AV11CarAux',fld:'vCARAUX',pic:''},{av:'AV10Car',fld:'vCAR',grid:80,pic:''},{av:'nGXsfl_80_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:80},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'nRC_GXsfl_80',ctrl:'CARPRODUCTS',prop:'GridRC',grid:80},{av:'divTable2_Visible',ctrl:'TABLE2',prop:'Visible'}]}");
         setEventMetadata("GRIDFILTEREDPRODUCTS_FIRSTPAGE","{handler:'subgridfilteredproducts_firstpage',iparms:[{av:'GRIDFILTEREDPRODUCTS_nFirstRecordOnPage'},{av:'GRIDFILTEREDPRODUCTS_nEOF'},{av:'AV37SDTProductsFiltered',fld:'vSDTPRODUCTSFILTERED',grid:49,pic:''},{av:'nGXsfl_49_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:49},{av:'nRC_GXsfl_49',ctrl:'GRIDFILTEREDPRODUCTS',prop:'GridRC',grid:49},{av:'subGridfilteredproducts_Rows',ctrl:'GRIDFILTEREDPRODUCTS',prop:'Rows'},{av:'subCarproducts_Rows',ctrl:'CARPRODUCTS',prop:'Rows'},{av:'subAllvouchers_Rows',ctrl:'ALLVOUCHERS',prop:'Rows'},{av:'AV6NewName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5NewCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'dynavSupplier'},{av:'AV29Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV9Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV31Sector',fld:'vSECTOR',pic:'ZZZZZ9'}]");
         setEventMetadata("GRIDFILTEREDPRODUCTS_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRIDFILTEREDPRODUCTS_PREVPAGE","{handler:'subgridfilteredproducts_previouspage',iparms:[{av:'GRIDFILTEREDPRODUCTS_nFirstRecordOnPage'},{av:'GRIDFILTEREDPRODUCTS_nEOF'},{av:'AV37SDTProductsFiltered',fld:'vSDTPRODUCTSFILTERED',grid:49,pic:''},{av:'nGXsfl_49_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:49},{av:'nRC_GXsfl_49',ctrl:'GRIDFILTEREDPRODUCTS',prop:'GridRC',grid:49},{av:'subGridfilteredproducts_Rows',ctrl:'GRIDFILTEREDPRODUCTS',prop:'Rows'},{av:'subCarproducts_Rows',ctrl:'CARPRODUCTS',prop:'Rows'},{av:'subAllvouchers_Rows',ctrl:'ALLVOUCHERS',prop:'Rows'},{av:'AV6NewName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5NewCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'dynavSupplier'},{av:'AV29Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV9Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV31Sector',fld:'vSECTOR',pic:'ZZZZZ9'}]");
         setEventMetadata("GRIDFILTEREDPRODUCTS_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRIDFILTEREDPRODUCTS_NEXTPAGE","{handler:'subgridfilteredproducts_nextpage',iparms:[{av:'GRIDFILTEREDPRODUCTS_nFirstRecordOnPage'},{av:'GRIDFILTEREDPRODUCTS_nEOF'},{av:'AV37SDTProductsFiltered',fld:'vSDTPRODUCTSFILTERED',grid:49,pic:''},{av:'nGXsfl_49_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:49},{av:'nRC_GXsfl_49',ctrl:'GRIDFILTEREDPRODUCTS',prop:'GridRC',grid:49},{av:'subGridfilteredproducts_Rows',ctrl:'GRIDFILTEREDPRODUCTS',prop:'Rows'},{av:'subCarproducts_Rows',ctrl:'CARPRODUCTS',prop:'Rows'},{av:'subAllvouchers_Rows',ctrl:'ALLVOUCHERS',prop:'Rows'},{av:'AV6NewName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5NewCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'dynavSupplier'},{av:'AV29Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV9Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV31Sector',fld:'vSECTOR',pic:'ZZZZZ9'}]");
         setEventMetadata("GRIDFILTEREDPRODUCTS_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRIDFILTEREDPRODUCTS_LASTPAGE","{handler:'subgridfilteredproducts_lastpage',iparms:[{av:'GRIDFILTEREDPRODUCTS_nFirstRecordOnPage'},{av:'GRIDFILTEREDPRODUCTS_nEOF'},{av:'AV37SDTProductsFiltered',fld:'vSDTPRODUCTSFILTERED',grid:49,pic:''},{av:'nGXsfl_49_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:49},{av:'nRC_GXsfl_49',ctrl:'GRIDFILTEREDPRODUCTS',prop:'GridRC',grid:49},{av:'subGridfilteredproducts_Rows',ctrl:'GRIDFILTEREDPRODUCTS',prop:'Rows'},{av:'subCarproducts_Rows',ctrl:'CARPRODUCTS',prop:'Rows'},{av:'subAllvouchers_Rows',ctrl:'ALLVOUCHERS',prop:'Rows'},{av:'AV6NewName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5NewCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'dynavSupplier'},{av:'AV29Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV9Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV31Sector',fld:'vSECTOR',pic:'ZZZZZ9'}]");
         setEventMetadata("GRIDFILTEREDPRODUCTS_LASTPAGE",",oparms:[]}");
         setEventMetadata("ALLVOUCHERS_FIRSTPAGE","{handler:'suballvouchers_firstpage',iparms:[{av:'ALLVOUCHERS_nFirstRecordOnPage'},{av:'ALLVOUCHERS_nEOF'},{av:'AV27SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:107,pic:''},{av:'nGXsfl_107_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:107},{av:'nRC_GXsfl_107',ctrl:'ALLVOUCHERS',prop:'GridRC',grid:107},{av:'subGridfilteredproducts_Rows',ctrl:'GRIDFILTEREDPRODUCTS',prop:'Rows'},{av:'subCarproducts_Rows',ctrl:'CARPRODUCTS',prop:'Rows'},{av:'subAllvouchers_Rows',ctrl:'ALLVOUCHERS',prop:'Rows'},{av:'AV6NewName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5NewCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'dynavSupplier'},{av:'AV29Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV9Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV31Sector',fld:'vSECTOR',pic:'ZZZZZ9'}]");
         setEventMetadata("ALLVOUCHERS_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("ALLVOUCHERS_PREVPAGE","{handler:'suballvouchers_previouspage',iparms:[{av:'ALLVOUCHERS_nFirstRecordOnPage'},{av:'ALLVOUCHERS_nEOF'},{av:'AV27SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:107,pic:''},{av:'nGXsfl_107_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:107},{av:'nRC_GXsfl_107',ctrl:'ALLVOUCHERS',prop:'GridRC',grid:107},{av:'subGridfilteredproducts_Rows',ctrl:'GRIDFILTEREDPRODUCTS',prop:'Rows'},{av:'subCarproducts_Rows',ctrl:'CARPRODUCTS',prop:'Rows'},{av:'subAllvouchers_Rows',ctrl:'ALLVOUCHERS',prop:'Rows'},{av:'AV6NewName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5NewCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'dynavSupplier'},{av:'AV29Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV9Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV31Sector',fld:'vSECTOR',pic:'ZZZZZ9'}]");
         setEventMetadata("ALLVOUCHERS_PREVPAGE",",oparms:[]}");
         setEventMetadata("ALLVOUCHERS_NEXTPAGE","{handler:'suballvouchers_nextpage',iparms:[{av:'ALLVOUCHERS_nFirstRecordOnPage'},{av:'ALLVOUCHERS_nEOF'},{av:'AV27SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:107,pic:''},{av:'nGXsfl_107_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:107},{av:'nRC_GXsfl_107',ctrl:'ALLVOUCHERS',prop:'GridRC',grid:107},{av:'subGridfilteredproducts_Rows',ctrl:'GRIDFILTEREDPRODUCTS',prop:'Rows'},{av:'subCarproducts_Rows',ctrl:'CARPRODUCTS',prop:'Rows'},{av:'subAllvouchers_Rows',ctrl:'ALLVOUCHERS',prop:'Rows'},{av:'AV6NewName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5NewCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'dynavSupplier'},{av:'AV29Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV9Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV31Sector',fld:'vSECTOR',pic:'ZZZZZ9'}]");
         setEventMetadata("ALLVOUCHERS_NEXTPAGE",",oparms:[]}");
         setEventMetadata("ALLVOUCHERS_LASTPAGE","{handler:'suballvouchers_lastpage',iparms:[{av:'ALLVOUCHERS_nFirstRecordOnPage'},{av:'ALLVOUCHERS_nEOF'},{av:'AV27SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:107,pic:''},{av:'nGXsfl_107_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:107},{av:'nRC_GXsfl_107',ctrl:'ALLVOUCHERS',prop:'GridRC',grid:107},{av:'subGridfilteredproducts_Rows',ctrl:'GRIDFILTEREDPRODUCTS',prop:'Rows'},{av:'subCarproducts_Rows',ctrl:'CARPRODUCTS',prop:'Rows'},{av:'subAllvouchers_Rows',ctrl:'ALLVOUCHERS',prop:'Rows'},{av:'AV6NewName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5NewCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'dynavSupplier'},{av:'AV29Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV9Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV31Sector',fld:'vSECTOR',pic:'ZZZZZ9'}]");
         setEventMetadata("ALLVOUCHERS_LASTPAGE",",oparms:[]}");
         setEventMetadata("CARPRODUCTS_FIRSTPAGE","{handler:'subcarproducts_firstpage',iparms:[{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'CARPRODUCTS_nEOF'},{av:'AV10Car',fld:'vCAR',grid:80,pic:''},{av:'nGXsfl_80_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:80},{av:'nRC_GXsfl_80',ctrl:'CARPRODUCTS',prop:'GridRC',grid:80},{av:'subGridfilteredproducts_Rows',ctrl:'GRIDFILTEREDPRODUCTS',prop:'Rows'},{av:'subCarproducts_Rows',ctrl:'CARPRODUCTS',prop:'Rows'},{av:'subAllvouchers_Rows',ctrl:'ALLVOUCHERS',prop:'Rows'},{av:'AV6NewName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5NewCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'dynavSupplier'},{av:'AV29Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV9Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV31Sector',fld:'vSECTOR',pic:'ZZZZZ9'}]");
         setEventMetadata("CARPRODUCTS_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("CARPRODUCTS_PREVPAGE","{handler:'subcarproducts_previouspage',iparms:[{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'CARPRODUCTS_nEOF'},{av:'AV10Car',fld:'vCAR',grid:80,pic:''},{av:'nGXsfl_80_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:80},{av:'nRC_GXsfl_80',ctrl:'CARPRODUCTS',prop:'GridRC',grid:80},{av:'subGridfilteredproducts_Rows',ctrl:'GRIDFILTEREDPRODUCTS',prop:'Rows'},{av:'subCarproducts_Rows',ctrl:'CARPRODUCTS',prop:'Rows'},{av:'subAllvouchers_Rows',ctrl:'ALLVOUCHERS',prop:'Rows'},{av:'AV6NewName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5NewCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'dynavSupplier'},{av:'AV29Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV9Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV31Sector',fld:'vSECTOR',pic:'ZZZZZ9'}]");
         setEventMetadata("CARPRODUCTS_PREVPAGE",",oparms:[]}");
         setEventMetadata("CARPRODUCTS_NEXTPAGE","{handler:'subcarproducts_nextpage',iparms:[{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'CARPRODUCTS_nEOF'},{av:'AV10Car',fld:'vCAR',grid:80,pic:''},{av:'nGXsfl_80_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:80},{av:'nRC_GXsfl_80',ctrl:'CARPRODUCTS',prop:'GridRC',grid:80},{av:'subGridfilteredproducts_Rows',ctrl:'GRIDFILTEREDPRODUCTS',prop:'Rows'},{av:'subCarproducts_Rows',ctrl:'CARPRODUCTS',prop:'Rows'},{av:'subAllvouchers_Rows',ctrl:'ALLVOUCHERS',prop:'Rows'},{av:'AV6NewName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5NewCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'dynavSupplier'},{av:'AV29Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV9Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV31Sector',fld:'vSECTOR',pic:'ZZZZZ9'}]");
         setEventMetadata("CARPRODUCTS_NEXTPAGE",",oparms:[]}");
         setEventMetadata("CARPRODUCTS_LASTPAGE","{handler:'subcarproducts_lastpage',iparms:[{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'CARPRODUCTS_nEOF'},{av:'AV10Car',fld:'vCAR',grid:80,pic:''},{av:'nGXsfl_80_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:80},{av:'nRC_GXsfl_80',ctrl:'CARPRODUCTS',prop:'GridRC',grid:80},{av:'subGridfilteredproducts_Rows',ctrl:'GRIDFILTEREDPRODUCTS',prop:'Rows'},{av:'subCarproducts_Rows',ctrl:'CARPRODUCTS',prop:'Rows'},{av:'subAllvouchers_Rows',ctrl:'ALLVOUCHERS',prop:'Rows'},{av:'AV6NewName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5NewCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'dynavSupplier'},{av:'AV29Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV9Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV31Sector',fld:'vSECTOR',pic:'ZZZZZ9'}]");
         setEventMetadata("CARPRODUCTS_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_GXV7","{handler:'Validv_Gxv7',iparms:[]");
         setEventMetadata("VALIDV_GXV7",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Gxv10',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Gxv14',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Gxv20',iparms:[]");
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
         AV6NewName = "";
         AV5NewCode = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV10Car = new GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem>( context, "SDTCarProductsItem", "mtaKB");
         AV27SDTPurchaseOrderGenerateList = new GXBaseCollection<SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem>( context, "SDTPurchaseOrderGenerateListItem", "mtaKB");
         AV37SDTProductsFiltered = new GXBaseCollection<SdtSDTProductsFiltered_SDTProductsFilteredItem>( context, "SDTProductsFilteredItem", "mtaKB");
         AV30SuppliersId = new GxSimpleCollection<int>();
         AV19Orders = new GXBCCollection<SdtPurchaseOrder>( context, "PurchaseOrder", "mtaKB");
         AV28SelectedId = new GxSimpleCollection<int>();
         AV12CarItem = new SdtSDTCarProducts_SDTCarProductsItem(context);
         AV11CarAux = new GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem>( context, "SDTCarProductsItem", "mtaKB");
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTextblock5_Jsonclick = "";
         TempTags = "";
         AV13Code = "";
         AV14Name = "";
         ucNecesary = new GXUserControl();
         ucOrdered = new GXUserControl();
         GridfilteredproductsContainer = new GXWebGrid( context);
         sStyleString = "";
         ClassString = "";
         StyleString = "";
         bttGenerateorder_Jsonclick = "";
         bttClearorder_Jsonclick = "";
         lblTextblock1_Jsonclick = "";
         lblTextblock2_Jsonclick = "";
         lblTextblock3_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         CarproductsContainer = new GXWebGrid( context);
         lblTextblock6_Jsonclick = "";
         bttGenerateneworder_Jsonclick = "";
         AllvouchersContainer = new GXWebGrid( context);
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         scmdbuf = "";
         H002M2_A4SupplierId = new int[1] ;
         H002M2_A5SupplierName = new string[] {""} ;
         H002M3_A1BrandId = new int[1] ;
         H002M3_A2BrandName = new string[] {""} ;
         H002M4_A9SectorId = new int[1] ;
         H002M4_A10SectorName = new string[] {""} ;
         AV21Product = new SdtProduct(context);
         AV16Order = new SdtPurchaseOrder(context);
         AV17OrderDetail = new SdtPurchaseOrder_Detail(context);
         AV26SDTPurchaseOrderGenerateItem = new SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem(context);
         GXt_objcol_SdtSDTProductsFiltered_SDTProductsFilteredItem1 = new GXBaseCollection<SdtSDTProductsFiltered_SDTProductsFilteredItem>( context, "SDTProductsFilteredItem", "mtaKB");
         AV7window = new GXWindow();
         AV24SDTProductsOrdered = new GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem>( context, "SDTProductsSelectedItem", "mtaKB");
         GXt_objcol_SdtSDTProductsSelected_SDTProductsSelectedItem2 = new GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem>( context, "SDTProductsSelectedItem", "mtaKB");
         AV22ProductsOrderedId = new GxSimpleCollection<int>();
         AV25SDTProductsOrderedItem = new SdtSDTProductsSelected_SDTProductsSelectedItem(context);
         GridfilteredproductsRow = new GXWebRow();
         AllvouchersRow = new GXWebRow();
         CarproductsRow = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGridfilteredproducts_Linesclass = "";
         ROClassString = "";
         subCarproducts_Linesclass = "";
         bttRemove_Jsonclick = "";
         subAllvouchers_Linesclass = "";
         GridfilteredproductsColumn = new GXWebColumn();
         subCarproducts_Header = "";
         CarproductsColumn = new GXWebColumn();
         AllvouchersColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpgeneratepurchasecopy1__default(),
            new Object[][] {
                new Object[] {
               H002M2_A4SupplierId, H002M2_A5SupplierName
               }
               , new Object[] {
               H002M3_A1BrandId, H002M3_A2BrandName
               }
               , new Object[] {
               H002M4_A9SectorId, H002M4_A10SectorName
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavCtlid_Enabled = 0;
         edtavCtlcode_Enabled = 0;
         edtavCtlname_Enabled = 0;
         edtavCtlstock1_Enabled = 0;
         edtavCtlminiumstock_Enabled = 0;
         edtavCtlcostprice_Enabled = 0;
         edtavCtlsupplier_Enabled = 0;
         edtavCtlbrand_Enabled = 0;
         edtavCtlsector_Enabled = 0;
         edtavCtlname1_Enabled = 0;
         edtavCtlstock_Enabled = 0;
         edtavCtlpurchaseorderid_Enabled = 0;
         edtavCtlsuppliername_Enabled = 0;
         edtavCtlpurchaseorderdetailsquantity_Enabled = 0;
         edtavCtldetailslink_Enabled = 0;
         edtavCtlsdtvoucherlink_Enabled = 0;
      }

      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short GRIDFILTEREDPRODUCTS_nEOF ;
      private short CARPRODUCTS_nEOF ;
      private short ALLVOUCHERS_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short subGridfilteredproducts_Collapsed ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGridfilteredproducts_Backcolorstyle ;
      private short subAllvouchers_Backcolorstyle ;
      private short subCarproducts_Backcolorstyle ;
      private short AV20Position ;
      private short nGXWrapped ;
      private short subGridfilteredproducts_Backstyle ;
      private short subCarproducts_Backstyle ;
      private short subAllvouchers_Backstyle ;
      private short subGridfilteredproducts_Titlebackstyle ;
      private short subGridfilteredproducts_Allowselection ;
      private short subGridfilteredproducts_Allowhovering ;
      private short subGridfilteredproducts_Allowcollapsing ;
      private short subCarproducts_Allowselection ;
      private short subCarproducts_Allowhovering ;
      private short subCarproducts_Allowcollapsing ;
      private short subCarproducts_Collapsed ;
      private short subAllvouchers_Titlebackstyle ;
      private short subAllvouchers_Allowselection ;
      private short subAllvouchers_Allowhovering ;
      private short subAllvouchers_Allowcollapsing ;
      private short subAllvouchers_Collapsed ;
      private int nRC_GXsfl_49 ;
      private int nRC_GXsfl_80 ;
      private int nRC_GXsfl_107 ;
      private int subGridfilteredproducts_Rows ;
      private int subCarproducts_Rows ;
      private int subAllvouchers_Rows ;
      private int nGXsfl_49_idx=1 ;
      private int AV29Supplier ;
      private int AV9Brand ;
      private int AV31Sector ;
      private int nGXsfl_80_idx=1 ;
      private int nGXsfl_107_idx=1 ;
      private int divTable1_Visible ;
      private int edtavCode_Enabled ;
      private int edtavName_Enabled ;
      private int AV40GXV1 ;
      private int divTable2_Visible ;
      private int AV50GXV11 ;
      private int divTable3_Visible ;
      private int AV54GXV15 ;
      private int gxdynajaxindex ;
      private int subGridfilteredproducts_Islastpage ;
      private int subAllvouchers_Islastpage ;
      private int subCarproducts_Islastpage ;
      private int edtavCtlid_Enabled ;
      private int edtavCtlcode_Enabled ;
      private int edtavCtlname_Enabled ;
      private int edtavCtlstock1_Enabled ;
      private int edtavCtlminiumstock_Enabled ;
      private int edtavCtlcostprice_Enabled ;
      private int edtavCtlsupplier_Enabled ;
      private int edtavCtlbrand_Enabled ;
      private int edtavCtlsector_Enabled ;
      private int edtavCtlname1_Enabled ;
      private int edtavCtlstock_Enabled ;
      private int edtavCtlpurchaseorderid_Enabled ;
      private int edtavCtlsuppliername_Enabled ;
      private int edtavCtlpurchaseorderdetailsquantity_Enabled ;
      private int edtavCtldetailslink_Enabled ;
      private int edtavCtlsdtvoucherlink_Enabled ;
      private int GRIDFILTEREDPRODUCTS_nGridOutOfScope ;
      private int ALLVOUCHERS_nGridOutOfScope ;
      private int nGXsfl_49_fel_idx=1 ;
      private int nGXsfl_80_fel_idx=1 ;
      private int nGXsfl_107_fel_idx=1 ;
      private int AV60GXV21 ;
      private int AV61GXV22 ;
      private int AV62GXV23 ;
      private int AV63GXV24 ;
      private int nGXsfl_107_bak_idx=1 ;
      private int nGXsfl_80_bak_idx=1 ;
      private int nGXsfl_49_bak_idx=1 ;
      private int AV64GXV25 ;
      private int AV65GXV26 ;
      private int idxLst ;
      private int subGridfilteredproducts_Backcolor ;
      private int subGridfilteredproducts_Allbackcolor ;
      private int subCarproducts_Backcolor ;
      private int subCarproducts_Allbackcolor ;
      private int edtavCtlquantity1_Enabled ;
      private int edtavCtlquantity1_Visible ;
      private int subAllvouchers_Backcolor ;
      private int subAllvouchers_Allbackcolor ;
      private int subGridfilteredproducts_Titlebackcolor ;
      private int subGridfilteredproducts_Selectedindex ;
      private int subGridfilteredproducts_Selectioncolor ;
      private int subGridfilteredproducts_Hoveringcolor ;
      private int subCarproducts_Selectedindex ;
      private int subCarproducts_Selectioncolor ;
      private int subCarproducts_Hoveringcolor ;
      private int subAllvouchers_Titlebackcolor ;
      private int subAllvouchers_Selectedindex ;
      private int subAllvouchers_Selectioncolor ;
      private int subAllvouchers_Hoveringcolor ;
      private long GRIDFILTEREDPRODUCTS_nFirstRecordOnPage ;
      private long CARPRODUCTS_nFirstRecordOnPage ;
      private long ALLVOUCHERS_nFirstRecordOnPage ;
      private long GRIDFILTEREDPRODUCTS_nCurrentRecord ;
      private long CARPRODUCTS_nCurrentRecord ;
      private long ALLVOUCHERS_nCurrentRecord ;
      private long GRIDFILTEREDPRODUCTS_nRecordCount ;
      private long ALLVOUCHERS_nRecordCount ;
      private long CARPRODUCTS_nRecordCount ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_49_idx="0001" ;
      private string sGXsfl_80_idx="0001" ;
      private string sGXsfl_107_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Necesary_Captionclass ;
      private string Necesary_Captionstyle ;
      private string Necesary_Captionposition ;
      private string Ordered_Captionclass ;
      private string Ordered_Captionstyle ;
      private string Ordered_Captionposition ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string divTable1_Internalname ;
      private string edtavCode_Internalname ;
      private string TempTags ;
      private string edtavCode_Jsonclick ;
      private string edtavName_Internalname ;
      private string edtavName_Jsonclick ;
      private string dynavSupplier_Internalname ;
      private string dynavSupplier_Jsonclick ;
      private string dynavBrand_Internalname ;
      private string dynavBrand_Jsonclick ;
      private string dynavSector_Internalname ;
      private string dynavSector_Jsonclick ;
      private string Necesary_Internalname ;
      private string Ordered_Internalname ;
      private string sStyleString ;
      private string subGridfilteredproducts_Internalname ;
      private string divTable2_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string bttGenerateorder_Internalname ;
      private string bttGenerateorder_Jsonclick ;
      private string bttClearorder_Internalname ;
      private string bttClearorder_Jsonclick ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string subCarproducts_Internalname ;
      private string divTable3_Internalname ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string bttGenerateneworder_Internalname ;
      private string bttGenerateneworder_Jsonclick ;
      private string subAllvouchers_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string gxwrpcisep ;
      private string scmdbuf ;
      private string edtavCtlid_Internalname ;
      private string edtavCtlcode_Internalname ;
      private string edtavCtlname_Internalname ;
      private string edtavCtlstock1_Internalname ;
      private string edtavCtlminiumstock_Internalname ;
      private string edtavCtlcostprice_Internalname ;
      private string edtavCtlsupplier_Internalname ;
      private string edtavCtlbrand_Internalname ;
      private string edtavCtlsector_Internalname ;
      private string edtavCtlname1_Internalname ;
      private string edtavCtlstock_Internalname ;
      private string edtavCtlpurchaseorderid_Internalname ;
      private string edtavCtlsuppliername_Internalname ;
      private string edtavCtlpurchaseorderdetailsquantity_Internalname ;
      private string edtavCtldetailslink_Internalname ;
      private string edtavCtlsdtvoucherlink_Internalname ;
      private string sGXsfl_49_fel_idx="0001" ;
      private string sGXsfl_80_fel_idx="0001" ;
      private string sGXsfl_107_fel_idx="0001" ;
      private string subGridfilteredproducts_Class ;
      private string subGridfilteredproducts_Linesclass ;
      private string ROClassString ;
      private string edtavCtlid_Jsonclick ;
      private string edtavCtlcode_Jsonclick ;
      private string edtavCtlname_Jsonclick ;
      private string edtavCtlstock1_Jsonclick ;
      private string edtavCtlminiumstock_Jsonclick ;
      private string edtavCtlcostprice_Jsonclick ;
      private string edtavCtlsupplier_Jsonclick ;
      private string edtavCtlbrand_Jsonclick ;
      private string edtavCtlsector_Jsonclick ;
      private string edtavCtlquantity1_Internalname ;
      private string subCarproducts_Class ;
      private string subCarproducts_Linesclass ;
      private string divGrid1table_Internalname ;
      private string edtavCtlname1_Jsonclick ;
      private string edtavCtlstock_Jsonclick ;
      private string edtavCtlquantity1_Jsonclick ;
      private string bttRemove_Internalname ;
      private string bttRemove_Jsonclick ;
      private string subAllvouchers_Class ;
      private string subAllvouchers_Linesclass ;
      private string edtavCtlpurchaseorderid_Jsonclick ;
      private string edtavCtlsuppliername_Jsonclick ;
      private string edtavCtlpurchaseorderdetailsquantity_Jsonclick ;
      private string edtavCtldetailslink_Jsonclick ;
      private string edtavCtlsdtvoucherlink_Jsonclick ;
      private string subGridfilteredproducts_Header ;
      private string subCarproducts_Header ;
      private string subAllvouchers_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15Necesary ;
      private bool AV18Ordered ;
      private bool Necesary_Enabled ;
      private bool Ordered_Enabled ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool bGXsfl_49_Refreshing=false ;
      private bool bGXsfl_80_Refreshing=false ;
      private bool bGXsfl_107_Refreshing=false ;
      private bool returnInSub ;
      private bool gx_BV49 ;
      private bool AV8AllOk ;
      private bool gx_BV107 ;
      private bool gx_BV80 ;
      private string AV6NewName ;
      private string AV5NewCode ;
      private string AV13Code ;
      private string AV14Name ;
      private GxSimpleCollection<int> AV30SuppliersId ;
      private GxSimpleCollection<int> AV28SelectedId ;
      private GxSimpleCollection<int> AV22ProductsOrderedId ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid GridfilteredproductsContainer ;
      private GXWebGrid CarproductsContainer ;
      private GXWebGrid AllvouchersContainer ;
      private GXWebRow GridfilteredproductsRow ;
      private GXWebRow AllvouchersRow ;
      private GXWebRow CarproductsRow ;
      private GXWebColumn GridfilteredproductsColumn ;
      private GXWebColumn CarproductsColumn ;
      private GXWebColumn AllvouchersColumn ;
      private GXUserControl ucNecesary ;
      private GXUserControl ucOrdered ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavSupplier ;
      private GXCombobox dynavBrand ;
      private GXCombobox dynavSector ;
      private IDataStoreProvider pr_default ;
      private int[] H002M2_A4SupplierId ;
      private string[] H002M2_A5SupplierName ;
      private int[] H002M3_A1BrandId ;
      private string[] H002M3_A2BrandName ;
      private int[] H002M4_A9SectorId ;
      private string[] H002M4_A10SectorName ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem> AV10Car ;
      private GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem> AV11CarAux ;
      private GXBCCollection<SdtPurchaseOrder> AV19Orders ;
      private GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> AV24SDTProductsOrdered ;
      private GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> GXt_objcol_SdtSDTProductsSelected_SDTProductsSelectedItem2 ;
      private GXBaseCollection<SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem> AV27SDTPurchaseOrderGenerateList ;
      private GXBaseCollection<SdtSDTProductsFiltered_SDTProductsFilteredItem> AV37SDTProductsFiltered ;
      private GXBaseCollection<SdtSDTProductsFiltered_SDTProductsFilteredItem> GXt_objcol_SdtSDTProductsFiltered_SDTProductsFilteredItem1 ;
      private GXWebForm Form ;
      private GXWindow AV7window ;
      private SdtSDTCarProducts_SDTCarProductsItem AV12CarItem ;
      private SdtPurchaseOrder AV16Order ;
      private SdtPurchaseOrder_Detail AV17OrderDetail ;
      private SdtProduct AV21Product ;
      private SdtSDTProductsSelected_SDTProductsSelectedItem AV25SDTProductsOrderedItem ;
      private SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem AV26SDTPurchaseOrderGenerateItem ;
   }

   public class wpgeneratepurchasecopy1__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH002M2;
          prmH002M2 = new Object[] {
          };
          Object[] prmH002M3;
          prmH002M3 = new Object[] {
          };
          Object[] prmH002M4;
          prmH002M4 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H002M2", "SELECT [SupplierId], [SupplierName] FROM [Supplier] ORDER BY [SupplierName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002M2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002M3", "SELECT [BrandId], [BrandName] FROM [Brand] ORDER BY [BrandName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002M3,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002M4", "SELECT [SectorId], [SectorName] FROM [Sector] ORDER BY [SectorName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002M4,0, GxCacheFrequency.OFF ,true,false )
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
                return;
       }
    }

 }

}
