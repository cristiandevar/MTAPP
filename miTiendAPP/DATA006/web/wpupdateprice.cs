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
   public class wpupdateprice : GXDataArea
   {
      public wpupdateprice( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public wpupdateprice( IGxContext context )
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
               GXDLVvSUPPLIER232( ) ;
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
               GXDLVvBRAND232( ) ;
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
               GXDLVvSECTOR232( ) ;
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Allproducts") == 0 )
            {
               gxnrAllproducts_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Allproducts") == 0 )
            {
               gxgrAllproducts_refresh_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Allproductsselected") == 0 )
            {
               gxnrAllproductsselected_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Allproductsselected") == 0 )
            {
               gxgrAllproductsselected_refresh_invoke( ) ;
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

      protected void gxnrAllproducts_newrow_invoke( )
      {
         nRC_GXsfl_34 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_34"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_34_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_34_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_34_idx = GetPar( "sGXsfl_34_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrAllproducts_newrow( ) ;
         /* End function gxnrAllproducts_newrow_invoke */
      }

      protected void gxgrAllproducts_refresh_invoke( )
      {
         subAllproducts_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subAllproducts_Rows"), "."), 18, MidpointRounding.ToEven));
         AV10Code = GetPar( "Code");
         AV9Name = GetPar( "Name");
         dynavSupplier.FromJSonString( GetNextPar( ));
         AV6Supplier = (int)(Math.Round(NumberUtil.Val( GetPar( "Supplier"), "."), 18, MidpointRounding.ToEven));
         dynavBrand.FromJSonString( GetNextPar( ));
         AV5Brand = (int)(Math.Round(NumberUtil.Val( GetPar( "Brand"), "."), 18, MidpointRounding.ToEven));
         dynavSector.FromJSonString( GetNextPar( ));
         AV7Sector = (int)(Math.Round(NumberUtil.Val( GetPar( "Sector"), "."), 18, MidpointRounding.ToEven));
         AV49Newpercentage = NumberUtil.Val( GetPar( "Newpercentage"), ".");
         AV18newName = GetPar( "newName");
         AV19newCode = GetPar( "newCode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrAllproducts_refresh( subAllproducts_Rows, AV10Code, AV9Name, AV6Supplier, AV5Brand, AV7Sector, AV49Newpercentage, AV18newName, AV19newCode) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrAllproducts_refresh_invoke */
      }

      protected void gxnrAllproductsselected_newrow_invoke( )
      {
         nRC_GXsfl_64 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_64"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_64_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_64_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_64_idx = GetPar( "sGXsfl_64_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrAllproductsselected_newrow( ) ;
         /* End function gxnrAllproductsselected_newrow_invoke */
      }

      protected void gxgrAllproductsselected_refresh_invoke( )
      {
         subAllproducts_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subAllproducts_Rows"), "."), 18, MidpointRounding.ToEven));
         AV10Code = GetPar( "Code");
         AV9Name = GetPar( "Name");
         dynavSupplier.FromJSonString( GetNextPar( ));
         AV6Supplier = (int)(Math.Round(NumberUtil.Val( GetPar( "Supplier"), "."), 18, MidpointRounding.ToEven));
         dynavBrand.FromJSonString( GetNextPar( ));
         AV5Brand = (int)(Math.Round(NumberUtil.Val( GetPar( "Brand"), "."), 18, MidpointRounding.ToEven));
         dynavSector.FromJSonString( GetNextPar( ));
         AV7Sector = (int)(Math.Round(NumberUtil.Val( GetPar( "Sector"), "."), 18, MidpointRounding.ToEven));
         AV49Newpercentage = NumberUtil.Val( GetPar( "Newpercentage"), ".");
         AV18newName = GetPar( "newName");
         AV19newCode = GetPar( "newCode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrAllproductsselected_refresh( subAllproducts_Rows, AV10Code, AV9Name, AV6Supplier, AV5Brand, AV7Sector, AV49Newpercentage, AV18newName, AV19newCode) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrAllproductsselected_refresh_invoke */
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
         PA232( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START232( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpupdateprice.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vNEWPERCENTAGE", StringUtil.LTrim( StringUtil.NToC( AV49Newpercentage, 10, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWPERCENTAGE", GetSecureSignedToken( "", context.localUtil.Format( AV49Newpercentage, "9999999.99"), context));
         GxWebStd.gx_hidden_field( context, "vNEWNAME", AV18newName);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV18newName, "")), context));
         GxWebStd.gx_hidden_field( context, "vNEWCODE", AV19newCode);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV19newCode, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vCODE", AV10Code);
         GxWebStd.gx_hidden_field( context, "GXH_vNAME", AV9Name);
         GxWebStd.gx_hidden_field( context, "GXH_vSUPPLIER", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6Supplier), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vBRAND", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Brand), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vSECTOR", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7Sector), 6, 0, ".", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Productsselected", AV15ProductsSelected);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Productsselected", AV15ProductsSelected);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_34", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_34), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_64", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_64), 8, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vROUNDTOP", AV36RoundTop);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSELECTEDID", AV13SelectedId);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSELECTEDID", AV13SelectedId);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPRODUCTSSELECTEDAUX", AV27ProductsSelectedAux);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPRODUCTSSELECTEDAUX", AV27ProductsSelectedAux);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSELECTEDIDAUX", AV28SelectedIdAux);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSELECTEDIDAUX", AV28SelectedIdAux);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPRODUCTSSELECTED", AV15ProductsSelected);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPRODUCTSSELECTED", AV15ProductsSelected);
         }
         GxWebStd.gx_hidden_field( context, "vNEWPERCENTAGE", StringUtil.LTrim( StringUtil.NToC( AV49Newpercentage, 10, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWPERCENTAGE", GetSecureSignedToken( "", context.localUtil.Format( AV49Newpercentage, "9999999.99"), context));
         GxWebStd.gx_hidden_field( context, "vNEWNAME", AV18newName);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV18newName, "")), context));
         GxWebStd.gx_hidden_field( context, "vNEWCODE", AV19newCode);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV19newCode, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vONEPRODUCT", AV16OneProduct);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vONEPRODUCT", AV16OneProduct);
         }
         GxWebStd.gx_hidden_field( context, "vGXV7", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV50GXV7), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ALLPRODUCTS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(ALLPRODUCTS_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ALLPRODUCTS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(ALLPRODUCTS_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ROUNDTOP_Enabled", StringUtil.BoolToStr( Roundtop_Enabled));
         GxWebStd.gx_hidden_field( context, "ROUNDTOP_Captionclass", StringUtil.RTrim( Roundtop_Captionclass));
         GxWebStd.gx_hidden_field( context, "ROUNDTOP_Captionstyle", StringUtil.RTrim( Roundtop_Captionstyle));
         GxWebStd.gx_hidden_field( context, "ROUNDTOP_Captionposition", StringUtil.RTrim( Roundtop_Captionposition));
         GxWebStd.gx_hidden_field( context, "ROUNDTOP_Text", StringUtil.RTrim( Roundtop_Text));
         GxWebStd.gx_hidden_field( context, "ROUNDTOP_Text", StringUtil.RTrim( Roundtop_Text));
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
            WE232( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT232( ) ;
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
         return formatLink("wpupdateprice.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WPUpdatePrice" ;
      }

      public override string GetPgmdesc( )
      {
         return "WPUpdate Price" ;
      }

      protected void WB230( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnallproducts_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(34), 2, 0)+","+"null"+");", "All Products", bttBtnallproducts_Jsonclick, 5, "All Products", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'ALLPRODUCTS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPUpdatePrice.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavCode_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCode_Internalname, "Code", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 13,'',false,'" + sGXsfl_34_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCode_Internalname, AV10Code, StringUtil.RTrim( context.localUtil.Format( AV10Code, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,13);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCode_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCode_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "GeneXusUnanimo\\Code", "left", true, "", "HLP_WPUpdatePrice.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavName_Internalname, "Name", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'" + sGXsfl_34_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavName_Internalname, AV9Name, StringUtil.RTrim( context.localUtil.Format( AV9Name, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,17);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavName_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Name", "left", true, "", "HLP_WPUpdatePrice.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavSupplier_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavSupplier_Internalname, "Supplier", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'" + sGXsfl_34_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavSupplier, dynavSupplier_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV6Supplier), 6, 0)), 1, dynavSupplier_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavSupplier.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "", true, 0, "HLP_WPUpdatePrice.htm");
            dynavSupplier.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV6Supplier), 6, 0));
            AssignProp("", false, dynavSupplier_Internalname, "Values", (string)(dynavSupplier.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavBrand_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavBrand_Internalname, "Brand", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'" + sGXsfl_34_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavBrand, dynavBrand_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV5Brand), 6, 0)), 1, dynavBrand_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavBrand.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "", true, 0, "HLP_WPUpdatePrice.htm");
            dynavBrand.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV5Brand), 6, 0));
            AssignProp("", false, dynavBrand_Internalname, "Values", (string)(dynavBrand.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavSector_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavSector_Internalname, "Sector", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'" + sGXsfl_34_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavSector, dynavSector_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV7Sector), 6, 0)), 1, dynavSector_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavSector.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "", true, 0, "HLP_WPUpdatePrice.htm");
            dynavSector.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7Sector), 6, 0));
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
            AllproductsContainer.SetWrapped(nGXWrapped);
            StartGridControl34( ) ;
         }
         if ( wbEnd == 34 )
         {
            wbEnd = 0;
            nRC_GXsfl_34 = (int)(nGXsfl_34_idx-1);
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AllproductsContainer.AddObjectProperty("ALLPRODUCTS_nEOF", ALLPRODUCTS_nEOF);
               AllproductsContainer.AddObjectProperty("ALLPRODUCTS_nFirstRecordOnPage", ALLPRODUCTS_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"AllproductsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Allproducts", AllproductsContainer, subAllproducts_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "AllproductsContainerData", AllproductsContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "AllproductsContainerData"+"V", AllproductsContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"AllproductsContainerData"+"V"+"\" value='"+AllproductsContainer.GridValuesHidden()+"'/>") ;
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
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable4_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "Bottom", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttUpdateprice_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(34), 2, 0)+","+"null"+");", "Update", bttUpdateprice_Jsonclick, 5, "Update", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'UPDATEPRICE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPUpdatePrice.htm");
            GxWebStd.gx_div_end( context, "left", "Bottom", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavPercentage_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPercentage_Internalname, "Percentage", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'" + sGXsfl_34_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPercentage_Internalname, StringUtil.LTrim( StringUtil.NToC( AV8Percentage, 6, 2, ".", "")), StringUtil.LTrim( ((edtavPercentage_Enabled!=0) ? context.localUtil.Format( AV8Percentage, "ZZ9.99") : context.localUtil.Format( AV8Percentage, "ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,55);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPercentage_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavPercentage_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_WPUpdatePrice.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", -1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+Roundtop_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, Roundtop_Internalname, "Round Top", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* User Defined Control */
            ucRoundtop.SetProperty("Attribute", AV36RoundTop);
            ucRoundtop.SetProperty("CaptionClass", Roundtop_Captionclass);
            ucRoundtop.SetProperty("CaptionStyle", Roundtop_Captionstyle);
            ucRoundtop.SetProperty("CaptionPosition", Roundtop_Captionposition);
            ucRoundtop.Render(context, "sdswitch", Roundtop_Internalname, "ROUNDTOPContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "Bottom", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCancelupdate_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(34), 2, 0)+","+"null"+");", "Cancel", bttCancelupdate_Jsonclick, 5, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CANCELUPDATE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPUpdatePrice.htm");
            GxWebStd.gx_div_end( context, "left", "Bottom", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            AllproductsselectedContainer.SetIsFreestyle(true);
            AllproductsselectedContainer.SetWrapped(nGXWrapped);
            StartGridControl64( ) ;
         }
         if ( wbEnd == 64 )
         {
            wbEnd = 0;
            nRC_GXsfl_64 = (int)(nGXsfl_64_idx-1);
            if ( AllproductsselectedContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV43GXV1 = nGXsfl_64_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"AllproductsselectedContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Allproductsselected", AllproductsselectedContainer, subAllproductsselected_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "AllproductsselectedContainerData", AllproductsselectedContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "AllproductsselectedContainerData"+"V", AllproductsselectedContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"AllproductsselectedContainerData"+"V"+"\" value='"+AllproductsselectedContainer.GridValuesHidden()+"'/>") ;
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
         if ( wbEnd == 34 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( AllproductsContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AllproductsContainer.AddObjectProperty("ALLPRODUCTS_nEOF", ALLPRODUCTS_nEOF);
                  AllproductsContainer.AddObjectProperty("ALLPRODUCTS_nFirstRecordOnPage", ALLPRODUCTS_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"AllproductsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Allproducts", AllproductsContainer, subAllproducts_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "AllproductsContainerData", AllproductsContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "AllproductsContainerData"+"V", AllproductsContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"AllproductsContainerData"+"V"+"\" value='"+AllproductsContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         if ( wbEnd == 64 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( AllproductsselectedContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV43GXV1 = nGXsfl_64_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"AllproductsselectedContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Allproductsselected", AllproductsselectedContainer, subAllproductsselected_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "AllproductsselectedContainerData", AllproductsselectedContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "AllproductsselectedContainerData"+"V", AllproductsselectedContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"AllproductsselectedContainerData"+"V"+"\" value='"+AllproductsselectedContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START232( )
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
            Form.Meta.addItem("description", "WPUpdate Price", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP230( ) ;
      }

      protected void WS232( )
      {
         START232( ) ;
         EVT232( ) ;
      }

      protected void EVT232( )
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
                           else if ( StringUtil.StrCmp(sEvt, "VROUNDTOP.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E11232 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'UPDATEPRICE'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'UpdatePrice' */
                              E12232 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CANCELUPDATE'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'CancelUpdate' */
                              E13232 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ALLPRODUCTS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AllProducts' */
                              E14232 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVE'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Remove' */
                              E15232 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ALLPRODUCTSPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "ALLPRODUCTSPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 suballproducts_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 suballproducts_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 suballproducts_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 suballproducts_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 8), "'REMOVE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 24), "ALLPRODUCTSSELECTED.LOAD") == 0 ) )
                           {
                              nGXsfl_64_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
                              SubsflControlProps_643( ) ;
                              AV43GXV1 = nGXsfl_64_idx;
                              if ( ( AV15ProductsSelected.Count >= AV43GXV1 ) && ( AV43GXV1 > 0 ) )
                              {
                                 AV15ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV15ProductsSelected.Item(AV43GXV1));
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
                                    E15232 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ALLPRODUCTSSELECTED.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E16233 ();
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
                           else if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "PRODUCTNAME.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 16), "ALLPRODUCTS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "PRODUCTNAME.CLICK") == 0 ) )
                           {
                              nGXsfl_34_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
                              SubsflControlProps_342( ) ;
                              A15ProductId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtProductId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A16ProductName = cgiGet( edtProductName_Internalname);
                              A5SupplierName = cgiGet( edtSupplierName_Internalname);
                              A2BrandName = cgiGet( edtBrandName_Internalname);
                              A10SectorName = cgiGet( edtSectorName_Internalname);
                              A18ProductPrice = context.localUtil.CToN( cgiGet( edtProductPrice_Internalname), ".", ",");
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "PRODUCTNAME.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E17232 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E18232 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ALLPRODUCTS.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E19232 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Code Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCODE"), AV10Code) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Name Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vNAME"), AV9Name) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Supplier Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vSUPPLIER"), ".", ",") != Convert.ToDecimal( AV6Supplier )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Brand Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vBRAND"), ".", ",") != Convert.ToDecimal( AV5Brand )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Sector Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vSECTOR"), ".", ",") != Convert.ToDecimal( AV7Sector )) )
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

      protected void WE232( )
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

      protected void PA232( )
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

      protected void GXDLVvSUPPLIER232( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvSUPPLIER_data232( ) ;
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

      protected void GXVvSUPPLIER_html232( )
      {
         int gxdynajaxvalue;
         GXDLVvSUPPLIER_data232( ) ;
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

      protected void GXDLVvSUPPLIER_data232( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(None)");
         /* Using cursor H00232 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00232_A4SupplierId[0]), 6, 0, ".", "")));
            gxdynajaxctrldescr.Add(H00232_A5SupplierName[0]);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void GXDLVvBRAND232( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvBRAND_data232( ) ;
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

      protected void GXVvBRAND_html232( )
      {
         int gxdynajaxvalue;
         GXDLVvBRAND_data232( ) ;
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

      protected void GXDLVvBRAND_data232( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(None)");
         /* Using cursor H00233 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00233_A1BrandId[0]), 6, 0, ".", "")));
            gxdynajaxctrldescr.Add(H00233_A2BrandName[0]);
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void GXDLVvSECTOR232( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvSECTOR_data232( ) ;
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

      protected void GXVvSECTOR_html232( )
      {
         int gxdynajaxvalue;
         GXDLVvSECTOR_data232( ) ;
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

      protected void GXDLVvSECTOR_data232( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(None)");
         /* Using cursor H00234 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00234_A9SectorId[0]), 6, 0, ".", "")));
            gxdynajaxctrldescr.Add(H00234_A10SectorName[0]);
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void gxnrAllproducts_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_342( ) ;
         while ( nGXsfl_34_idx <= nRC_GXsfl_34 )
         {
            sendrow_342( ) ;
            nGXsfl_34_idx = ((subAllproducts_Islastpage==1)&&(nGXsfl_34_idx+1>subAllproducts_fnc_Recordsperpage( )) ? 1 : nGXsfl_34_idx+1);
            sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
            SubsflControlProps_342( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( AllproductsContainer)) ;
         /* End function gxnrAllproducts_newrow */
      }

      protected void gxnrAllproductsselected_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_643( ) ;
         while ( nGXsfl_64_idx <= nRC_GXsfl_64 )
         {
            sendrow_643( ) ;
            nGXsfl_64_idx = ((subAllproductsselected_Islastpage==1)&&(nGXsfl_64_idx+1>subAllproductsselected_fnc_Recordsperpage( )) ? 1 : nGXsfl_64_idx+1);
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_643( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( AllproductsselectedContainer)) ;
         /* End function gxnrAllproductsselected_newrow */
      }

      protected void gxgrAllproducts_refresh( int subAllproducts_Rows ,
                                              string AV10Code ,
                                              string AV9Name ,
                                              int AV6Supplier ,
                                              int AV5Brand ,
                                              int AV7Sector ,
                                              decimal AV49Newpercentage ,
                                              string AV18newName ,
                                              string AV19newCode )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         ALLPRODUCTS_nCurrentRecord = 0;
         RF232( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrAllproducts_refresh */
      }

      protected void gxgrAllproductsselected_refresh( int subAllproducts_Rows ,
                                                      string AV10Code ,
                                                      string AV9Name ,
                                                      int AV6Supplier ,
                                                      int AV5Brand ,
                                                      int AV7Sector ,
                                                      decimal AV49Newpercentage ,
                                                      string AV18newName ,
                                                      string AV19newCode )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         ALLPRODUCTSSELECTED_nCurrentRecord = 0;
         RF233( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrAllproductsselected_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUCTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A15ProductId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "PRODUCTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUCTNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A16ProductName, "")), context));
         GxWebStd.gx_hidden_field( context, "PRODUCTNAME", A16ProductName);
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUCTPRICE", GetSecureSignedToken( "", context.localUtil.Format( A18ProductPrice, "ZZZZZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "PRODUCTPRICE", StringUtil.LTrim( StringUtil.NToC( A18ProductPrice, 10, 2, ".", "")));
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXVvSUPPLIER_html232( ) ;
            GXVvBRAND_html232( ) ;
            GXVvSECTOR_html232( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavSupplier.ItemCount > 0 )
         {
            AV6Supplier = (int)(Math.Round(NumberUtil.Val( dynavSupplier.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV6Supplier), 6, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV6Supplier", StringUtil.LTrimStr( (decimal)(AV6Supplier), 6, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavSupplier.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV6Supplier), 6, 0));
            AssignProp("", false, dynavSupplier_Internalname, "Values", dynavSupplier.ToJavascriptSource(), true);
         }
         if ( dynavBrand.ItemCount > 0 )
         {
            AV5Brand = (int)(Math.Round(NumberUtil.Val( dynavBrand.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV5Brand), 6, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV5Brand", StringUtil.LTrimStr( (decimal)(AV5Brand), 6, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavBrand.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV5Brand), 6, 0));
            AssignProp("", false, dynavBrand_Internalname, "Values", dynavBrand.ToJavascriptSource(), true);
         }
         if ( dynavSector.ItemCount > 0 )
         {
            AV7Sector = (int)(Math.Round(NumberUtil.Val( dynavSector.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV7Sector), 6, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV7Sector", StringUtil.LTrimStr( (decimal)(AV7Sector), 6, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavSector.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7Sector), 6, 0));
            AssignProp("", false, dynavSector_Internalname, "Values", dynavSector.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF232( ) ;
         RF233( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavCtlname1_Enabled = 0;
         AssignProp("", false, edtavCtlname1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname1_Enabled), 5, 0), !bGXsfl_64_Refreshing);
         edtavCtlunitprice1_Enabled = 0;
         AssignProp("", false, edtavCtlunitprice1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlunitprice1_Enabled), 5, 0), !bGXsfl_64_Refreshing);
      }

      protected void RF232( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            AllproductsContainer.ClearRows();
         }
         wbStart = 34;
         nGXsfl_34_idx = 1;
         sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
         SubsflControlProps_342( ) ;
         bGXsfl_34_Refreshing = true;
         AllproductsContainer.AddObjectProperty("GridName", "Allproducts");
         AllproductsContainer.AddObjectProperty("CmpContext", "");
         AllproductsContainer.AddObjectProperty("InMasterPage", "false");
         AllproductsContainer.AddObjectProperty("Class", "PromptGrid");
         AllproductsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         AllproductsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         AllproductsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAllproducts_Backcolorstyle), 1, 0, ".", "")));
         AllproductsContainer.PageSize = subAllproducts_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_342( ) ;
            GXPagingFrom2 = (int)(ALLPRODUCTS_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subAllproducts_fnc_Recordsperpage( )+1);
            pr_default.dynParam(3, new Object[]{ new Object[]{
                                                 AV10Code ,
                                                 AV9Name ,
                                                 AV6Supplier ,
                                                 AV5Brand ,
                                                 AV7Sector ,
                                                 A55ProductCode ,
                                                 A16ProductName ,
                                                 A4SupplierId ,
                                                 A1BrandId ,
                                                 A9SectorId } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                                 }
            });
            lV10Code = StringUtil.Concat( StringUtil.RTrim( AV10Code), "%", "");
            lV9Name = StringUtil.Concat( StringUtil.RTrim( AV9Name), "%", "");
            /* Using cursor H00235 */
            pr_default.execute(3, new Object[] {lV10Code, lV9Name, AV6Supplier, AV5Brand, AV7Sector, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_34_idx = 1;
            sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
            SubsflControlProps_342( ) ;
            while ( ( (pr_default.getStatus(3) != 101) ) && ( ( ALLPRODUCTS_nCurrentRecord < subAllproducts_fnc_Recordsperpage( ) ) ) )
            {
               A9SectorId = H00235_A9SectorId[0];
               A1BrandId = H00235_A1BrandId[0];
               A4SupplierId = H00235_A4SupplierId[0];
               A55ProductCode = H00235_A55ProductCode[0];
               n55ProductCode = H00235_n55ProductCode[0];
               A18ProductPrice = H00235_A18ProductPrice[0];
               A10SectorName = H00235_A10SectorName[0];
               A2BrandName = H00235_A2BrandName[0];
               A5SupplierName = H00235_A5SupplierName[0];
               A16ProductName = H00235_A16ProductName[0];
               A15ProductId = H00235_A15ProductId[0];
               A10SectorName = H00235_A10SectorName[0];
               A2BrandName = H00235_A2BrandName[0];
               A5SupplierName = H00235_A5SupplierName[0];
               E19232 ();
               pr_default.readNext(3);
            }
            ALLPRODUCTS_nEOF = (short)(((pr_default.getStatus(3) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "ALLPRODUCTS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(ALLPRODUCTS_nEOF), 1, 0, ".", "")));
            pr_default.close(3);
            wbEnd = 34;
            WB230( ) ;
         }
         bGXsfl_34_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes232( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUCTID"+"_"+sGXsfl_34_idx, GetSecureSignedToken( sGXsfl_34_idx, context.localUtil.Format( (decimal)(A15ProductId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUCTNAME"+"_"+sGXsfl_34_idx, GetSecureSignedToken( sGXsfl_34_idx, StringUtil.RTrim( context.localUtil.Format( A16ProductName, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUCTPRICE"+"_"+sGXsfl_34_idx, GetSecureSignedToken( sGXsfl_34_idx, context.localUtil.Format( A18ProductPrice, "ZZZZZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "vNEWPERCENTAGE", StringUtil.LTrim( StringUtil.NToC( AV49Newpercentage, 10, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWPERCENTAGE", GetSecureSignedToken( "", context.localUtil.Format( AV49Newpercentage, "9999999.99"), context));
         GxWebStd.gx_hidden_field( context, "vNEWNAME", AV18newName);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV18newName, "")), context));
         GxWebStd.gx_hidden_field( context, "vNEWCODE", AV19newCode);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV19newCode, "")), context));
      }

      protected void RF233( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            AllproductsselectedContainer.ClearRows();
         }
         wbStart = 64;
         nGXsfl_64_idx = 1;
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
         SubsflControlProps_643( ) ;
         bGXsfl_64_Refreshing = true;
         AllproductsselectedContainer.AddObjectProperty("GridName", "Allproductsselected");
         AllproductsselectedContainer.AddObjectProperty("CmpContext", "");
         AllproductsselectedContainer.AddObjectProperty("InMasterPage", "false");
         AllproductsselectedContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         AllproductsselectedContainer.AddObjectProperty("Class", "FreeStyleGrid");
         AllproductsselectedContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         AllproductsselectedContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         AllproductsselectedContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAllproductsselected_Backcolorstyle), 1, 0, ".", "")));
         AllproductsselectedContainer.PageSize = subAllproductsselected_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_643( ) ;
            E16233 ();
            wbEnd = 64;
            WB230( ) ;
         }
         bGXsfl_64_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes233( )
      {
      }

      protected int subAllproducts_fnc_Pagecount( )
      {
         ALLPRODUCTS_nRecordCount = subAllproducts_fnc_Recordcount( );
         if ( ((int)((ALLPRODUCTS_nRecordCount) % (subAllproducts_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(ALLPRODUCTS_nRecordCount/ (decimal)(subAllproducts_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(ALLPRODUCTS_nRecordCount/ (decimal)(subAllproducts_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subAllproducts_fnc_Recordcount( )
      {
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              AV10Code ,
                                              AV9Name ,
                                              AV6Supplier ,
                                              AV5Brand ,
                                              AV7Sector ,
                                              A55ProductCode ,
                                              A16ProductName ,
                                              A4SupplierId ,
                                              A1BrandId ,
                                              A9SectorId } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV10Code = StringUtil.Concat( StringUtil.RTrim( AV10Code), "%", "");
         lV9Name = StringUtil.Concat( StringUtil.RTrim( AV9Name), "%", "");
         /* Using cursor H00236 */
         pr_default.execute(4, new Object[] {lV10Code, lV9Name, AV6Supplier, AV5Brand, AV7Sector});
         ALLPRODUCTS_nRecordCount = H00236_AALLPRODUCTS_nRecordCount[0];
         pr_default.close(4);
         return (int)(ALLPRODUCTS_nRecordCount) ;
      }

      protected int subAllproducts_fnc_Recordsperpage( )
      {
         return (int)(5*1) ;
      }

      protected int subAllproducts_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(ALLPRODUCTS_nFirstRecordOnPage/ (decimal)(subAllproducts_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short suballproducts_firstpage( )
      {
         ALLPRODUCTS_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "ALLPRODUCTS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(ALLPRODUCTS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrAllproducts_refresh( subAllproducts_Rows, AV10Code, AV9Name, AV6Supplier, AV5Brand, AV7Sector, AV49Newpercentage, AV18newName, AV19newCode) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short suballproducts_nextpage( )
      {
         ALLPRODUCTS_nRecordCount = subAllproducts_fnc_Recordcount( );
         if ( ( ALLPRODUCTS_nRecordCount >= subAllproducts_fnc_Recordsperpage( ) ) && ( ALLPRODUCTS_nEOF == 0 ) )
         {
            ALLPRODUCTS_nFirstRecordOnPage = (long)(ALLPRODUCTS_nFirstRecordOnPage+subAllproducts_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "ALLPRODUCTS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(ALLPRODUCTS_nFirstRecordOnPage), 15, 0, ".", "")));
         AllproductsContainer.AddObjectProperty("ALLPRODUCTS_nFirstRecordOnPage", ALLPRODUCTS_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrAllproducts_refresh( subAllproducts_Rows, AV10Code, AV9Name, AV6Supplier, AV5Brand, AV7Sector, AV49Newpercentage, AV18newName, AV19newCode) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((ALLPRODUCTS_nEOF==0) ? 0 : 2)) ;
      }

      protected short suballproducts_previouspage( )
      {
         if ( ALLPRODUCTS_nFirstRecordOnPage >= subAllproducts_fnc_Recordsperpage( ) )
         {
            ALLPRODUCTS_nFirstRecordOnPage = (long)(ALLPRODUCTS_nFirstRecordOnPage-subAllproducts_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "ALLPRODUCTS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(ALLPRODUCTS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrAllproducts_refresh( subAllproducts_Rows, AV10Code, AV9Name, AV6Supplier, AV5Brand, AV7Sector, AV49Newpercentage, AV18newName, AV19newCode) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short suballproducts_lastpage( )
      {
         ALLPRODUCTS_nRecordCount = subAllproducts_fnc_Recordcount( );
         if ( ALLPRODUCTS_nRecordCount > subAllproducts_fnc_Recordsperpage( ) )
         {
            if ( ((int)((ALLPRODUCTS_nRecordCount) % (subAllproducts_fnc_Recordsperpage( )))) == 0 )
            {
               ALLPRODUCTS_nFirstRecordOnPage = (long)(ALLPRODUCTS_nRecordCount-subAllproducts_fnc_Recordsperpage( ));
            }
            else
            {
               ALLPRODUCTS_nFirstRecordOnPage = (long)(ALLPRODUCTS_nRecordCount-((int)((ALLPRODUCTS_nRecordCount) % (subAllproducts_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            ALLPRODUCTS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "ALLPRODUCTS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(ALLPRODUCTS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrAllproducts_refresh( subAllproducts_Rows, AV10Code, AV9Name, AV6Supplier, AV5Brand, AV7Sector, AV49Newpercentage, AV18newName, AV19newCode) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int suballproducts_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            ALLPRODUCTS_nFirstRecordOnPage = (long)(subAllproducts_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            ALLPRODUCTS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "ALLPRODUCTS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(ALLPRODUCTS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrAllproducts_refresh( subAllproducts_Rows, AV10Code, AV9Name, AV6Supplier, AV5Brand, AV7Sector, AV49Newpercentage, AV18newName, AV19newCode) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected int subAllproductsselected_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subAllproductsselected_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subAllproductsselected_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subAllproductsselected_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavCtlname1_Enabled = 0;
         AssignProp("", false, edtavCtlname1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname1_Enabled), 5, 0), !bGXsfl_64_Refreshing);
         edtavCtlunitprice1_Enabled = 0;
         AssignProp("", false, edtavCtlunitprice1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlunitprice1_Enabled), 5, 0), !bGXsfl_64_Refreshing);
         GXVvSUPPLIER_html232( ) ;
         GXVvBRAND_html232( ) ;
         GXVvSECTOR_html232( ) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP230( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E18232 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Productsselected"), AV15ProductsSelected);
            ajax_req_read_hidden_sdt(cgiGet( "vONEPRODUCT"), AV16OneProduct);
            ajax_req_read_hidden_sdt(cgiGet( "vPRODUCTSSELECTED"), AV15ProductsSelected);
            /* Read saved values. */
            nRC_GXsfl_34 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_34"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_64 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_64"), ".", ","), 18, MidpointRounding.ToEven));
            AV36RoundTop = StringUtil.StrToBool( cgiGet( "vROUNDTOP"));
            AV50GXV7 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vGXV7"), ".", ","), 18, MidpointRounding.ToEven));
            ALLPRODUCTS_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "ALLPRODUCTS_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            ALLPRODUCTS_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "ALLPRODUCTS_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            Roundtop_Enabled = StringUtil.StrToBool( cgiGet( "ROUNDTOP_Enabled"));
            Roundtop_Captionclass = cgiGet( "ROUNDTOP_Captionclass");
            Roundtop_Captionstyle = cgiGet( "ROUNDTOP_Captionstyle");
            Roundtop_Captionposition = cgiGet( "ROUNDTOP_Captionposition");
            Roundtop_Text = cgiGet( "ROUNDTOP_Text");
            nRC_GXsfl_64 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_64"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_64_fel_idx = 0;
            while ( nGXsfl_64_fel_idx < nRC_GXsfl_64 )
            {
               nGXsfl_64_fel_idx = ((subAllproductsselected_Islastpage==1)&&(nGXsfl_64_fel_idx+1>subAllproductsselected_fnc_Recordsperpage( )) ? 1 : nGXsfl_64_fel_idx+1);
               sGXsfl_64_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_643( ) ;
               AV43GXV1 = nGXsfl_64_fel_idx;
               if ( ( AV15ProductsSelected.Count >= AV43GXV1 ) && ( AV43GXV1 > 0 ) )
               {
                  AV15ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV15ProductsSelected.Item(AV43GXV1));
               }
            }
            if ( nGXsfl_64_fel_idx == 0 )
            {
               nGXsfl_64_idx = 1;
               sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
               SubsflControlProps_643( ) ;
            }
            nGXsfl_64_fel_idx = 1;
            /* Read variables values. */
            AV10Code = cgiGet( edtavCode_Internalname);
            AssignAttri("", false, "AV10Code", AV10Code);
            AV9Name = cgiGet( edtavName_Internalname);
            AssignAttri("", false, "AV9Name", AV9Name);
            dynavSupplier.Name = dynavSupplier_Internalname;
            dynavSupplier.CurrentValue = cgiGet( dynavSupplier_Internalname);
            AV6Supplier = (int)(Math.Round(NumberUtil.Val( cgiGet( dynavSupplier_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV6Supplier", StringUtil.LTrimStr( (decimal)(AV6Supplier), 6, 0));
            dynavBrand.Name = dynavBrand_Internalname;
            dynavBrand.CurrentValue = cgiGet( dynavBrand_Internalname);
            AV5Brand = (int)(Math.Round(NumberUtil.Val( cgiGet( dynavBrand_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV5Brand", StringUtil.LTrimStr( (decimal)(AV5Brand), 6, 0));
            dynavSector.Name = dynavSector_Internalname;
            dynavSector.CurrentValue = cgiGet( dynavSector_Internalname);
            AV7Sector = (int)(Math.Round(NumberUtil.Val( cgiGet( dynavSector_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV7Sector", StringUtil.LTrimStr( (decimal)(AV7Sector), 6, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPercentage_Internalname), ".", ",") < -99.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavPercentage_Internalname), ".", ",") > 999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPERCENTAGE");
               GX_FocusControl = edtavPercentage_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8Percentage = 0;
               AssignAttri("", false, "AV8Percentage", StringUtil.LTrimStr( AV8Percentage, 6, 2));
            }
            else
            {
               AV8Percentage = context.localUtil.CToN( cgiGet( edtavPercentage_Internalname), ".", ",");
               AssignAttri("", false, "AV8Percentage", StringUtil.LTrimStr( AV8Percentage, 6, 2));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCODE"), AV10Code) != 0 )
            {
               ALLPRODUCTS_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vNAME"), AV9Name) != 0 )
            {
               ALLPRODUCTS_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vSUPPLIER"), ".", ",") != Convert.ToDecimal( AV6Supplier )) )
            {
               ALLPRODUCTS_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vBRAND"), ".", ",") != Convert.ToDecimal( AV5Brand )) )
            {
               ALLPRODUCTS_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vSECTOR"), ".", ",") != Convert.ToDecimal( AV7Sector )) )
            {
               ALLPRODUCTS_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void E17232( )
      {
         AV43GXV1 = nGXsfl_64_idx;
         if ( ( AV43GXV1 > 0 ) && ( AV15ProductsSelected.Count >= AV43GXV1 ) )
         {
            AV15ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV15ProductsSelected.Item(AV43GXV1));
         }
         /* ProductName_Click Routine */
         returnInSub = false;
         if ( AV13SelectedId.IndexOf(A15ProductId) <= 0 )
         {
            AV16OneProduct = new SdtSDTProductsSelected_SDTProductsSelectedItem(context);
            AV16OneProduct.gxTpr_Id = A15ProductId;
            AV16OneProduct.gxTpr_Name = A16ProductName;
            AV16OneProduct.gxTpr_Supplier = A5SupplierName;
            AV16OneProduct.gxTpr_Brand = A2BrandName;
            AV16OneProduct.gxTpr_Sector = A10SectorName;
            AV16OneProduct.gxTpr_Unitprice = A18ProductPrice;
            AV16OneProduct.gxTpr_Newunitprice = (decimal)(A18ProductPrice*(1+AV8Percentage/ (decimal)(100)));
            if ( AV36RoundTop )
            {
               AV38PriceRounded = NumberUtil.Round( AV16OneProduct.gxTpr_Newunitprice, -1);
               AV40Count = 1;
               AV39Digit = (short)(((int)((AV38PriceRounded) % (10))));
               AV38PriceRounded = (decimal)(NumberUtil.Int( (long)(Math.Round(AV38PriceRounded/ (decimal)(10), 18, MidpointRounding.ToEven))));
               while ( ( AV38PriceRounded >= Convert.ToDecimal( 100 )) )
               {
                  AV39Digit = (short)(((int)((AV38PriceRounded) % (10))));
                  AV38PriceRounded = (decimal)(NumberUtil.Int( (long)(Math.Round(AV38PriceRounded/ (decimal)(10), 18, MidpointRounding.ToEven))));
                  AV40Count = (short)(AV40Count+1);
               }
               if ( AV39Digit * 10 > 0 )
               {
                  AV38PriceRounded = (decimal)(AV38PriceRounded+1);
               }
               AV29i = 1;
               while ( AV29i <= AV40Count )
               {
                  AV38PriceRounded = (decimal)(AV38PriceRounded*10);
                  AV29i = (short)(AV29i+1);
               }
               AV16OneProduct.gxTpr_Newunitprice = AV38PriceRounded;
            }
            AV27ProductsSelectedAux.Add(AV16OneProduct, 0);
            AV28SelectedIdAux.Add(A15ProductId, 0);
            AV47GXV5 = 1;
            while ( AV47GXV5 <= AV15ProductsSelected.Count )
            {
               AV16OneProduct = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV15ProductsSelected.Item(AV47GXV5));
               AV27ProductsSelectedAux.Add(AV16OneProduct, 0);
               AV28SelectedIdAux.Add(AV16OneProduct.gxTpr_Id, 0);
               AV47GXV5 = (int)(AV47GXV5+1);
            }
            AV15ProductsSelected = (GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem>)(AV27ProductsSelectedAux.Clone());
            gx_BV64 = true;
            AV13SelectedId = (GxSimpleCollection<int>)(AV28SelectedIdAux.Clone());
            AV27ProductsSelectedAux.Clear();
            AV28SelectedIdAux.Clear();
            gxgrAllproductsselected_refresh( subAllproducts_Rows, AV10Code, AV9Name, AV6Supplier, AV5Brand, AV7Sector, AV49Newpercentage, AV18newName, AV19newCode) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27ProductsSelectedAux", AV27ProductsSelectedAux);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28SelectedIdAux", AV28SelectedIdAux);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15ProductsSelected", AV15ProductsSelected);
         nGXsfl_64_bak_idx = nGXsfl_64_idx;
         gxgrAllproductsselected_refresh( subAllproducts_Rows, AV10Code, AV9Name, AV6Supplier, AV5Brand, AV7Sector, AV49Newpercentage, AV18newName, AV19newCode) ;
         nGXsfl_64_idx = nGXsfl_64_bak_idx;
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
         SubsflControlProps_643( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13SelectedId", AV13SelectedId);
      }

      protected void E12232( )
      {
         AV43GXV1 = nGXsfl_64_idx;
         if ( ( AV43GXV1 > 0 ) && ( AV15ProductsSelected.Count >= AV43GXV1 ) )
         {
            AV15ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV15ProductsSelected.Item(AV43GXV1));
         }
         /* 'UpdatePrice' Routine */
         returnInSub = false;
         AV21AllOk = true;
         if ( ( AV13SelectedId.Count > 0 ) && ( AV8Percentage != Convert.ToDecimal( 0 )) && ( AV8Percentage <= Convert.ToDecimal( 100 )) && ( AV8Percentage >= Convert.ToDecimal( -100 )) )
         {
            AV29i = 1;
            while ( AV29i <= AV13SelectedId.Count )
            {
               if ( ( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV15ProductsSelected.Item(AV29i)).gxTpr_Newunitprice <= Convert.ToDecimal( 0 )) )
               {
                  AV21AllOk = false;
               }
               AV29i = (short)(AV29i+1);
            }
            if ( AV21AllOk )
            {
               AV48GXV6 = 1;
               while ( AV48GXV6 <= AV15ProductsSelected.Count )
               {
                  AV16OneProduct = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV15ProductsSelected.Item(AV48GXV6));
                  AV11Product = new SdtProduct(context);
                  AV11Product.Load(AV16OneProduct.gxTpr_Id);
                  AV11Product.gxTpr_Productprice = AV16OneProduct.gxTpr_Newunitprice;
                  AV11Product.Update();
                  if ( AV11Product.Success() )
                  {
                     context.CommitDataStores("wpupdateprice",pr_default);
                  }
                  else
                  {
                     context.RollbackDataStores("wpupdateprice",pr_default);
                     GX_msglist.addItem("Could not update price to Product: "+AV16OneProduct.gxTpr_Name+" Error Details: "+AV11Product.GetMessages());
                  }
                  AV48GXV6 = (int)(AV48GXV6+1);
               }
               gxgrAllproducts_refresh( subAllproducts_Rows, AV10Code, AV9Name, AV6Supplier, AV5Brand, AV7Sector, AV49Newpercentage, AV18newName, AV19newCode) ;
               AV15ProductsSelected.Clear();
               gx_BV64 = true;
               AV13SelectedId.Clear();
               GX_msglist.addItem("Update Prices finished!");
            }
            else
            {
               GX_msglist.addItem("Some New Price are invalids, must be a positive number");
            }
         }
         else
         {
            if ( AV13SelectedId.Count > 0 )
            {
               if ( ( AV8Percentage != Convert.ToDecimal( 0 )) )
               {
                  if ( ( AV8Percentage <= Convert.ToDecimal( 100 )) )
                  {
                     GX_msglist.addItem("Percentage is less to -100");
                  }
                  else
                  {
                     GX_msglist.addItem("Percentage is high to 100");
                  }
               }
               else
               {
                  GX_msglist.addItem("Percentage must be distinct than zero");
               }
            }
            else
            {
               GX_msglist.addItem("Percentage must be distinct than zero");
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15ProductsSelected", AV15ProductsSelected);
         nGXsfl_64_bak_idx = nGXsfl_64_idx;
         gxgrAllproductsselected_refresh( subAllproducts_Rows, AV10Code, AV9Name, AV6Supplier, AV5Brand, AV7Sector, AV49Newpercentage, AV18newName, AV19newCode) ;
         nGXsfl_64_idx = nGXsfl_64_bak_idx;
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
         SubsflControlProps_643( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13SelectedId", AV13SelectedId);
      }

      protected void E13232( )
      {
         /* 'CancelUpdate' Routine */
         returnInSub = false;
         AV8Percentage = 0;
         AssignAttri("", false, "AV8Percentage", StringUtil.LTrimStr( AV8Percentage, 6, 2));
         AV15ProductsSelected.Clear();
         gx_BV64 = true;
         AV13SelectedId.Clear();
         AV27ProductsSelectedAux.Clear();
         AV28SelectedIdAux.Clear();
         /*  Sending Event outputs  */
         if ( gx_BV64 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15ProductsSelected", AV15ProductsSelected);
            nGXsfl_64_bak_idx = nGXsfl_64_idx;
            gxgrAllproductsselected_refresh( subAllproducts_Rows, AV10Code, AV9Name, AV6Supplier, AV5Brand, AV7Sector, AV49Newpercentage, AV18newName, AV19newCode) ;
            nGXsfl_64_idx = nGXsfl_64_bak_idx;
            sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
            SubsflControlProps_643( ) ;
         }
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13SelectedId", AV13SelectedId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27ProductsSelectedAux", AV27ProductsSelectedAux);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28SelectedIdAux", AV28SelectedIdAux);
      }

      protected void E15232( )
      {
         AV43GXV1 = nGXsfl_64_idx;
         if ( ( AV43GXV1 > 0 ) && ( AV15ProductsSelected.Count >= AV43GXV1 ) )
         {
            AV15ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV15ProductsSelected.Item(AV43GXV1));
         }
         /* 'Remove' Routine */
         returnInSub = false;
         AV23Position = (short)(AV13SelectedId.IndexOf(((SdtSDTProductsSelected_SDTProductsSelectedItem)(AV15ProductsSelected.CurrentItem)).gxTpr_Id));
         AV13SelectedId.RemoveItem(AV23Position);
         AV15ProductsSelected.RemoveItem(AV23Position);
         gx_BV64 = true;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13SelectedId", AV13SelectedId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15ProductsSelected", AV15ProductsSelected);
         nGXsfl_64_bak_idx = nGXsfl_64_idx;
         gxgrAllproductsselected_refresh( subAllproducts_Rows, AV10Code, AV9Name, AV6Supplier, AV5Brand, AV7Sector, AV49Newpercentage, AV18newName, AV19newCode) ;
         nGXsfl_64_idx = nGXsfl_64_bak_idx;
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
         SubsflControlProps_643( ) ;
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E18232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E18232( )
      {
         /* Start Routine */
         returnInSub = false;
         AV8Percentage = 0;
         AssignAttri("", false, "AV8Percentage", StringUtil.LTrimStr( AV8Percentage, 6, 2));
      }

      protected void E14232( )
      {
         AV43GXV1 = nGXsfl_64_idx;
         if ( ( AV43GXV1 > 0 ) && ( AV15ProductsSelected.Count >= AV43GXV1 ) )
         {
            AV15ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV15ProductsSelected.Item(AV43GXV1));
         }
         /* 'AllProducts' Routine */
         returnInSub = false;
         GXt_objcol_SdtSDTProductsSelected_SDTProductsSelectedItem1 = AV27ProductsSelectedAux;
         new dpallproductswhereupdate(context ).execute(  AV9Name,  AV10Code,  AV6Supplier,  AV7Sector,  AV5Brand, out  GXt_objcol_SdtSDTProductsSelected_SDTProductsSelectedItem1) ;
         AV27ProductsSelectedAux = GXt_objcol_SdtSDTProductsSelected_SDTProductsSelectedItem1;
         AV51GXV8 = 1;
         while ( AV51GXV8 <= AV27ProductsSelectedAux.Count )
         {
            AV16OneProduct = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV27ProductsSelectedAux.Item(AV51GXV8));
            if ( AV13SelectedId.IndexOf(AV16OneProduct.gxTpr_Id) <= 0 )
            {
               AV16OneProduct.gxTpr_Newunitprice = (decimal)(AV16OneProduct.gxTpr_Unitprice*(1+AV8Percentage/ (decimal)(100)));
               if ( AV36RoundTop )
               {
                  AV38PriceRounded = NumberUtil.Round( AV16OneProduct.gxTpr_Newunitprice, -1);
                  AV40Count = 1;
                  AV39Digit = (short)(((int)((AV38PriceRounded) % (10))));
                  AV38PriceRounded = (decimal)(NumberUtil.Int( (long)(Math.Round(AV38PriceRounded/ (decimal)(10), 18, MidpointRounding.ToEven))));
                  while ( ( AV38PriceRounded >= Convert.ToDecimal( 100 )) )
                  {
                     AV39Digit = (short)(((int)((AV38PriceRounded) % (10))));
                     AV38PriceRounded = (decimal)(NumberUtil.Int( (long)(Math.Round(AV38PriceRounded/ (decimal)(10), 18, MidpointRounding.ToEven))));
                     AV40Count = (short)(AV40Count+1);
                  }
                  if ( AV39Digit * 10 > 0 )
                  {
                     AV38PriceRounded = (decimal)(AV38PriceRounded+1);
                  }
                  AV29i = 1;
                  while ( AV29i <= AV40Count )
                  {
                     AV38PriceRounded = (decimal)(AV38PriceRounded*10);
                     AV29i = (short)(AV29i+1);
                  }
                  AV16OneProduct.gxTpr_Newunitprice = AV38PriceRounded;
               }
               AV13SelectedId.Add(AV16OneProduct.gxTpr_Id, 0);
               AV15ProductsSelected.Add(AV16OneProduct, 0);
               gx_BV64 = true;
            }
            AV51GXV8 = (int)(AV51GXV8+1);
         }
         AV27ProductsSelectedAux.Clear();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27ProductsSelectedAux", AV27ProductsSelectedAux);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13SelectedId", AV13SelectedId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15ProductsSelected", AV15ProductsSelected);
         nGXsfl_64_bak_idx = nGXsfl_64_idx;
         gxgrAllproductsselected_refresh( subAllproducts_Rows, AV10Code, AV9Name, AV6Supplier, AV5Brand, AV7Sector, AV49Newpercentage, AV18newName, AV19newCode) ;
         nGXsfl_64_idx = nGXsfl_64_bak_idx;
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
         SubsflControlProps_643( ) ;
      }

      protected void S112( )
      {
         /* 'ROUNDTOP' Routine */
         returnInSub = false;
         AV52GXV9 = 1;
         while ( AV52GXV9 <= AV15ProductsSelected.Count )
         {
            AV16OneProduct = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV15ProductsSelected.Item(AV52GXV9));
            AV38PriceRounded = NumberUtil.Round( AV16OneProduct.gxTpr_Newunitprice, -1);
            AV40Count = 1;
            AV39Digit = (short)(((int)((AV38PriceRounded) % (10))));
            AV38PriceRounded = (decimal)(NumberUtil.Int( (long)(Math.Round(AV38PriceRounded/ (decimal)(10), 18, MidpointRounding.ToEven))));
            while ( ( AV38PriceRounded >= Convert.ToDecimal( 100 )) )
            {
               AV39Digit = (short)(((int)((AV38PriceRounded) % (10))));
               AV38PriceRounded = (decimal)(NumberUtil.Int( (long)(Math.Round(AV38PriceRounded/ (decimal)(10), 18, MidpointRounding.ToEven))));
               AV40Count = (short)(AV40Count+1);
            }
            if ( AV39Digit * 10 > 0 )
            {
               AV38PriceRounded = (decimal)(AV38PriceRounded+1);
            }
            AV29i = 1;
            while ( AV29i <= AV40Count )
            {
               AV38PriceRounded = (decimal)(AV38PriceRounded*10);
               AV29i = (short)(AV29i+1);
            }
            AV16OneProduct.gxTpr_Newunitprice = AV38PriceRounded;
            AV52GXV9 = (int)(AV52GXV9+1);
         }
      }

      protected void S122( )
      {
         /* 'CALCULATENEWPRICE' Routine */
         returnInSub = false;
         AV53GXV10 = 1;
         while ( AV53GXV10 <= AV15ProductsSelected.Count )
         {
            AV16OneProduct = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV15ProductsSelected.Item(AV53GXV10));
            AV16OneProduct.gxTpr_Newunitprice = (decimal)(AV16OneProduct.gxTpr_Unitprice*(1+AV8Percentage/ (decimal)(100)));
            AV53GXV10 = (int)(AV53GXV10+1);
         }
      }

      protected void E11232( )
      {
         AV43GXV1 = nGXsfl_64_idx;
         if ( ( AV43GXV1 > 0 ) && ( AV15ProductsSelected.Count >= AV43GXV1 ) )
         {
            AV15ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV15ProductsSelected.Item(AV43GXV1));
         }
         /* Roundtop_Controlvaluechanged Routine */
         returnInSub = false;
         GX_msglist.addItem("RoundTop.Text: "+Roundtop_Text);
         if ( AV36RoundTop )
         {
            /* Execute user subroutine: 'ROUNDTOP' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            GX_msglist.addItem("RoundTop");
         }
         else
         {
            /* Execute user subroutine: 'CALCULATENEWPRICE' */
            S122 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            GX_msglist.addItem("CalculateNewPrice");
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15ProductsSelected", AV15ProductsSelected);
         nGXsfl_64_bak_idx = nGXsfl_64_idx;
         gxgrAllproductsselected_refresh( subAllproducts_Rows, AV10Code, AV9Name, AV6Supplier, AV5Brand, AV7Sector, AV49Newpercentage, AV18newName, AV19newCode) ;
         nGXsfl_64_idx = nGXsfl_64_bak_idx;
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
         SubsflControlProps_643( ) ;
      }

      private void E19232( )
      {
         /* Allproducts_Load Routine */
         returnInSub = false;
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 34;
         }
         sendrow_342( ) ;
         ALLPRODUCTS_nCurrentRecord = (long)(ALLPRODUCTS_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_34_Refreshing )
         {
            DoAjaxLoad(34, AllproductsRow);
         }
      }

      private void E16233( )
      {
         /* Allproductsselected_Load Routine */
         returnInSub = false;
         AV43GXV1 = 1;
         while ( AV43GXV1 <= AV15ProductsSelected.Count )
         {
            AV15ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV15ProductsSelected.Item(AV43GXV1));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 64;
            }
            sendrow_643( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_64_Refreshing )
            {
               DoAjaxLoad(64, AllproductsselectedRow);
            }
            AV43GXV1 = (int)(AV43GXV1+1);
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
         PA232( ) ;
         WS232( ) ;
         WE232( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20242272192292", true, true);
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
         context.AddJavascriptSource("wpupdateprice.js", "?20242272192292", false, true);
         context.AddJavascriptSource("Switch/switch.min.js", "", false, true);
         context.AddJavascriptSource("Switch/switch.min.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_342( )
      {
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_34_idx;
         edtProductName_Internalname = "PRODUCTNAME_"+sGXsfl_34_idx;
         edtSupplierName_Internalname = "SUPPLIERNAME_"+sGXsfl_34_idx;
         edtBrandName_Internalname = "BRANDNAME_"+sGXsfl_34_idx;
         edtSectorName_Internalname = "SECTORNAME_"+sGXsfl_34_idx;
         edtProductPrice_Internalname = "PRODUCTPRICE_"+sGXsfl_34_idx;
      }

      protected void SubsflControlProps_fel_342( )
      {
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_34_fel_idx;
         edtProductName_Internalname = "PRODUCTNAME_"+sGXsfl_34_fel_idx;
         edtSupplierName_Internalname = "SUPPLIERNAME_"+sGXsfl_34_fel_idx;
         edtBrandName_Internalname = "BRANDNAME_"+sGXsfl_34_fel_idx;
         edtSectorName_Internalname = "SECTORNAME_"+sGXsfl_34_fel_idx;
         edtProductPrice_Internalname = "PRODUCTPRICE_"+sGXsfl_34_fel_idx;
      }

      protected void sendrow_342( )
      {
         SubsflControlProps_342( ) ;
         WB230( ) ;
         if ( ( 5 * 1 == 0 ) || ( nGXsfl_34_idx <= subAllproducts_fnc_Recordsperpage( ) * 1 ) )
         {
            AllproductsRow = GXWebRow.GetNew(context,AllproductsContainer);
            if ( subAllproducts_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subAllproducts_Backstyle = 0;
               if ( StringUtil.StrCmp(subAllproducts_Class, "") != 0 )
               {
                  subAllproducts_Linesclass = subAllproducts_Class+"Odd";
               }
            }
            else if ( subAllproducts_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subAllproducts_Backstyle = 0;
               subAllproducts_Backcolor = subAllproducts_Allbackcolor;
               if ( StringUtil.StrCmp(subAllproducts_Class, "") != 0 )
               {
                  subAllproducts_Linesclass = subAllproducts_Class+"Uniform";
               }
            }
            else if ( subAllproducts_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subAllproducts_Backstyle = 1;
               if ( StringUtil.StrCmp(subAllproducts_Class, "") != 0 )
               {
                  subAllproducts_Linesclass = subAllproducts_Class+"Odd";
               }
               subAllproducts_Backcolor = (int)(0x0);
            }
            else if ( subAllproducts_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subAllproducts_Backstyle = 1;
               if ( ((int)((nGXsfl_34_idx) % (2))) == 0 )
               {
                  subAllproducts_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subAllproducts_Class, "") != 0 )
                  {
                     subAllproducts_Linesclass = subAllproducts_Class+"Even";
                  }
               }
               else
               {
                  subAllproducts_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subAllproducts_Class, "") != 0 )
                  {
                     subAllproducts_Linesclass = subAllproducts_Class+"Odd";
                  }
               }
            }
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"PromptGrid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_34_idx+"\">") ;
            }
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A15ProductId), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)34,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductName_Internalname,(string)A16ProductName,(string)"",(string)"","'"+""+"'"+",false,"+"'"+"EPRODUCTNAME.CLICK."+sGXsfl_34_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductName_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)34,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierName_Internalname,(string)A5SupplierName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)34,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtBrandName_Internalname,(string)A2BrandName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtBrandName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)34,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSectorName_Internalname,(string)A10SectorName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSectorName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)34,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductPrice_Internalname,StringUtil.LTrim( StringUtil.NToC( A18ProductPrice, 10, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A18ProductPrice, "ZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductPrice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)34,(short)0,(short)-1,(short)0,(bool)true,(string)"Price",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes232( ) ;
            AllproductsContainer.AddRow(AllproductsRow);
            nGXsfl_34_idx = ((subAllproducts_Islastpage==1)&&(nGXsfl_34_idx+1>subAllproducts_fnc_Recordsperpage( )) ? 1 : nGXsfl_34_idx+1);
            sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
            SubsflControlProps_342( ) ;
         }
         /* End function sendrow_342 */
      }

      protected void SubsflControlProps_643( )
      {
         edtavCtlname1_Internalname = "CTLNAME1_"+sGXsfl_64_idx;
         edtavCtlunitprice1_Internalname = "CTLUNITPRICE1_"+sGXsfl_64_idx;
         edtavCtlnewunitprice_Internalname = "CTLNEWUNITPRICE_"+sGXsfl_64_idx;
      }

      protected void SubsflControlProps_fel_643( )
      {
         edtavCtlname1_Internalname = "CTLNAME1_"+sGXsfl_64_fel_idx;
         edtavCtlunitprice1_Internalname = "CTLUNITPRICE1_"+sGXsfl_64_fel_idx;
         edtavCtlnewunitprice_Internalname = "CTLNEWUNITPRICE_"+sGXsfl_64_fel_idx;
      }

      protected void sendrow_643( )
      {
         SubsflControlProps_643( ) ;
         WB230( ) ;
         AllproductsselectedRow = GXWebRow.GetNew(context,AllproductsselectedContainer);
         if ( subAllproductsselected_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subAllproductsselected_Backstyle = 0;
            if ( StringUtil.StrCmp(subAllproductsselected_Class, "") != 0 )
            {
               subAllproductsselected_Linesclass = subAllproductsselected_Class+"Odd";
            }
         }
         else if ( subAllproductsselected_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subAllproductsselected_Backstyle = 0;
            subAllproductsselected_Backcolor = subAllproductsselected_Allbackcolor;
            if ( StringUtil.StrCmp(subAllproductsselected_Class, "") != 0 )
            {
               subAllproductsselected_Linesclass = subAllproductsselected_Class+"Uniform";
            }
         }
         else if ( subAllproductsselected_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subAllproductsselected_Backstyle = 1;
            if ( StringUtil.StrCmp(subAllproductsselected_Class, "") != 0 )
            {
               subAllproductsselected_Linesclass = subAllproductsselected_Class+"Odd";
            }
            subAllproductsselected_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subAllproductsselected_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subAllproductsselected_Backstyle = 1;
            if ( ((int)((nGXsfl_64_idx) % (2))) == 0 )
            {
               subAllproductsselected_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subAllproductsselected_Class, "") != 0 )
               {
                  subAllproductsselected_Linesclass = subAllproductsselected_Class+"Even";
               }
            }
            else
            {
               subAllproductsselected_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subAllproductsselected_Class, "") != 0 )
               {
                  subAllproductsselected_Linesclass = subAllproductsselected_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( AllproductsselectedContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subAllproductsselected_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_64_idx+"\">") ;
         }
         /* Div Control */
         AllproductsselectedRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divGrid1table_Internalname+"_"+sGXsfl_64_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         AllproductsselectedRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         AllproductsselectedRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3",(string)"left",(string)"Bottom",(string)"",(string)"",(string)"div"});
         /* Div Control */
         AllproductsselectedRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         AllproductsselectedRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname1_Internalname,(string)"Name",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         AllproductsselectedRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname1_Internalname,((SdtSDTProductsSelected_SDTProductsSelectedItem)AV15ProductsSelected.Item(AV43GXV1)).gxTpr_Name,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlname1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlname1_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         AllproductsselectedRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         AllproductsselectedRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"Bottom",(string)"div"});
         /* Div Control */
         AllproductsselectedRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         AllproductsselectedRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group",(string)"left",(string)"top",(string)""+" data-gx-for=\""+edtavCtlunitprice1_Internalname+"\"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         AllproductsselectedRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlunitprice1_Internalname,(string)"Unit Price",(string)"col-xs-12 AttributeLabel",(short)1,(bool)true,(string)""});
         /* Div Control */
         AllproductsselectedRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Single line edit */
         ROClassString = "Attribute";
         AllproductsselectedRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlunitprice1_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV15ProductsSelected.Item(AV43GXV1)).gxTpr_Unitprice, 10, 2, ".", "")),StringUtil.LTrim( ((edtavCtlunitprice1_Enabled!=0) ? context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV15ProductsSelected.Item(AV43GXV1)).gxTpr_Unitprice, "ZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV15ProductsSelected.Item(AV43GXV1)).gxTpr_Unitprice, "ZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlunitprice1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlunitprice1_Enabled,(short)0,(string)"text",(string)"",(short)10,(string)"chr",(short)1,(string)"row",(short)10,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         AllproductsselectedRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         AllproductsselectedRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         AllproductsselectedRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         AllproductsselectedRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         AllproductsselectedRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group",(string)"left",(string)"top",(string)""+" data-gx-for=\""+edtavCtlnewunitprice_Internalname+"\"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         AllproductsselectedRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlnewunitprice_Internalname,(string)"New Unit Price",(string)"col-xs-12 AttributeLabel",(short)1,(bool)true,(string)""});
         /* Div Control */
         AllproductsselectedRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Single line edit */
         TempTags = " " + ((edtavCtlnewunitprice_Enabled!=0)&&(edtavCtlnewunitprice_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 77,'',false,'"+sGXsfl_64_idx+"',64)\"" : " ");
         ROClassString = "Attribute";
         AllproductsselectedRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlnewunitprice_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV15ProductsSelected.Item(AV43GXV1)).gxTpr_Newunitprice, 10, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV15ProductsSelected.Item(AV43GXV1)).gxTpr_Newunitprice, "ZZZZZZ9.99")),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+((edtavCtlnewunitprice_Enabled!=0)&&(edtavCtlnewunitprice_Visible!=0) ? " onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,77);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlnewunitprice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)1,(short)0,(string)"text",(string)"",(short)10,(string)"chr",(short)1,(string)"row",(short)10,(short)0,(short)0,(short)64,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         AllproductsselectedRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         AllproductsselectedRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         AllproductsselectedRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         AllproductsselectedRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-3",(string)"Right",(string)"top",(string)"",(string)"",(string)"div"});
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         AllproductsselectedRow.AddColumnProperties("button", 2, isAjaxCallMode( ), new Object[] {(string)bttRemove_Internalname+"_"+sGXsfl_64_idx,"gx.evt.setGridEvt("+StringUtil.Str( (decimal)(64), 2, 0)+","+"null"+");",(string)"Remove",(string)bttRemove_Jsonclick,(short)5,(string)"Remove",(string)"",(string)StyleString,(string)ClassString,(short)1,(short)1,(string)"standard","'"+""+"'"+",false,"+"'"+"E\\'REMOVE\\'."+"'",(string)TempTags,(string)"",context.GetButtonType( )});
         AllproductsselectedRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"Right",(string)"top",(string)"div"});
         AllproductsselectedRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         AllproductsselectedRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         send_integrity_lvl_hashes233( ) ;
         /* End of Columns property logic. */
         AllproductsselectedContainer.AddRow(AllproductsselectedRow);
         nGXsfl_64_idx = ((subAllproductsselected_Islastpage==1)&&(nGXsfl_64_idx+1>subAllproductsselected_fnc_Recordsperpage( )) ? 1 : nGXsfl_64_idx+1);
         sGXsfl_64_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_64_idx), 4, 0), 4, "0");
         SubsflControlProps_643( ) ;
         /* End function sendrow_643 */
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

      protected void StartGridControl34( )
      {
         if ( AllproductsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"AllproductsContainer"+"DivS\" data-gxgridid=\"34\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subAllproducts_Internalname, subAllproducts_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subAllproducts_Backcolorstyle == 0 )
            {
               subAllproducts_Titlebackstyle = 0;
               if ( StringUtil.Len( subAllproducts_Class) > 0 )
               {
                  subAllproducts_Linesclass = subAllproducts_Class+"Title";
               }
            }
            else
            {
               subAllproducts_Titlebackstyle = 1;
               if ( subAllproducts_Backcolorstyle == 1 )
               {
                  subAllproducts_Titlebackcolor = subAllproducts_Allbackcolor;
                  if ( StringUtil.Len( subAllproducts_Class) > 0 )
                  {
                     subAllproducts_Linesclass = subAllproducts_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subAllproducts_Class) > 0 )
                  {
                     subAllproducts_Linesclass = subAllproducts_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Product Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Product Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Supplier Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Brand Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Sector Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Product Price") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            AllproductsContainer.AddObjectProperty("GridName", "Allproducts");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               AllproductsContainer = new GXWebGrid( context);
            }
            else
            {
               AllproductsContainer.Clear();
            }
            AllproductsContainer.SetWrapped(nGXWrapped);
            AllproductsContainer.AddObjectProperty("GridName", "Allproducts");
            AllproductsContainer.AddObjectProperty("Header", subAllproducts_Header);
            AllproductsContainer.AddObjectProperty("Class", "PromptGrid");
            AllproductsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            AllproductsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            AllproductsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAllproducts_Backcolorstyle), 1, 0, ".", "")));
            AllproductsContainer.AddObjectProperty("CmpContext", "");
            AllproductsContainer.AddObjectProperty("InMasterPage", "false");
            AllproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", ""))));
            AllproductsContainer.AddColumnProperties(AllproductsColumn);
            AllproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A16ProductName));
            AllproductsContainer.AddColumnProperties(AllproductsColumn);
            AllproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A5SupplierName));
            AllproductsContainer.AddColumnProperties(AllproductsColumn);
            AllproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A2BrandName));
            AllproductsContainer.AddColumnProperties(AllproductsColumn);
            AllproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A10SectorName));
            AllproductsContainer.AddColumnProperties(AllproductsColumn);
            AllproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A18ProductPrice, 10, 2, ".", ""))));
            AllproductsContainer.AddColumnProperties(AllproductsColumn);
            AllproductsContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAllproducts_Selectedindex), 4, 0, ".", "")));
            AllproductsContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAllproducts_Allowselection), 1, 0, ".", "")));
            AllproductsContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAllproducts_Selectioncolor), 9, 0, ".", "")));
            AllproductsContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAllproducts_Allowhovering), 1, 0, ".", "")));
            AllproductsContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAllproducts_Hoveringcolor), 9, 0, ".", "")));
            AllproductsContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAllproducts_Allowcollapsing), 1, 0, ".", "")));
            AllproductsContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAllproducts_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void StartGridControl64( )
      {
         if ( AllproductsselectedContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"AllproductsselectedContainer"+"DivS\" data-gxgridid=\"64\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subAllproductsselected_Internalname, subAllproductsselected_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            AllproductsselectedContainer.AddObjectProperty("GridName", "Allproductsselected");
         }
         else
         {
            AllproductsselectedContainer.AddObjectProperty("GridName", "Allproductsselected");
            AllproductsselectedContainer.AddObjectProperty("Header", subAllproductsselected_Header);
            AllproductsselectedContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            AllproductsselectedContainer.AddObjectProperty("Class", "FreeStyleGrid");
            AllproductsselectedContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            AllproductsselectedContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            AllproductsselectedContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAllproductsselected_Backcolorstyle), 1, 0, ".", "")));
            AllproductsselectedContainer.AddObjectProperty("CmpContext", "");
            AllproductsselectedContainer.AddObjectProperty("InMasterPage", "false");
            AllproductsselectedColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsselectedContainer.AddColumnProperties(AllproductsselectedColumn);
            AllproductsselectedColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsselectedContainer.AddColumnProperties(AllproductsselectedColumn);
            AllproductsselectedColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsselectedContainer.AddColumnProperties(AllproductsselectedColumn);
            AllproductsselectedColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsselectedContainer.AddColumnProperties(AllproductsselectedColumn);
            AllproductsselectedColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsselectedColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlname1_Enabled), 5, 0, ".", "")));
            AllproductsselectedContainer.AddColumnProperties(AllproductsselectedColumn);
            AllproductsselectedColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsselectedContainer.AddColumnProperties(AllproductsselectedColumn);
            AllproductsselectedColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsselectedContainer.AddColumnProperties(AllproductsselectedColumn);
            AllproductsselectedColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsselectedContainer.AddColumnProperties(AllproductsselectedColumn);
            AllproductsselectedColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsselectedColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlunitprice1_Enabled), 5, 0, ".", "")));
            AllproductsselectedContainer.AddColumnProperties(AllproductsselectedColumn);
            AllproductsselectedColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsselectedContainer.AddColumnProperties(AllproductsselectedColumn);
            AllproductsselectedColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsselectedContainer.AddColumnProperties(AllproductsselectedColumn);
            AllproductsselectedColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsselectedContainer.AddColumnProperties(AllproductsselectedColumn);
            AllproductsselectedColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsselectedContainer.AddColumnProperties(AllproductsselectedColumn);
            AllproductsselectedColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsselectedContainer.AddColumnProperties(AllproductsselectedColumn);
            AllproductsselectedColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsselectedContainer.AddColumnProperties(AllproductsselectedColumn);
            AllproductsselectedContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAllproductsselected_Selectedindex), 4, 0, ".", "")));
            AllproductsselectedContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAllproductsselected_Allowselection), 1, 0, ".", "")));
            AllproductsselectedContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAllproductsselected_Selectioncolor), 9, 0, ".", "")));
            AllproductsselectedContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAllproductsselected_Allowhovering), 1, 0, ".", "")));
            AllproductsselectedContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAllproductsselected_Hoveringcolor), 9, 0, ".", "")));
            AllproductsselectedContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAllproductsselected_Allowcollapsing), 1, 0, ".", "")));
            AllproductsselectedContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAllproductsselected_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         bttBtnallproducts_Internalname = "BTNALLPRODUCTS";
         edtavCode_Internalname = "vCODE";
         edtavName_Internalname = "vNAME";
         dynavSupplier_Internalname = "vSUPPLIER";
         dynavBrand_Internalname = "vBRAND";
         dynavSector_Internalname = "vSECTOR";
         edtProductId_Internalname = "PRODUCTID";
         edtProductName_Internalname = "PRODUCTNAME";
         edtSupplierName_Internalname = "SUPPLIERNAME";
         edtBrandName_Internalname = "BRANDNAME";
         edtSectorName_Internalname = "SECTORNAME";
         edtProductPrice_Internalname = "PRODUCTPRICE";
         divTable2_Internalname = "TABLE2";
         bttUpdateprice_Internalname = "UPDATEPRICE";
         edtavPercentage_Internalname = "vPERCENTAGE";
         Roundtop_Internalname = "ROUNDTOP";
         bttCancelupdate_Internalname = "CANCELUPDATE";
         divTable4_Internalname = "TABLE4";
         edtavCtlname1_Internalname = "CTLNAME1";
         edtavCtlunitprice1_Internalname = "CTLUNITPRICE1";
         edtavCtlnewunitprice_Internalname = "CTLNEWUNITPRICE";
         bttRemove_Internalname = "REMOVE";
         divGrid1table_Internalname = "GRID1TABLE";
         divTable1_Internalname = "TABLE1";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subAllproducts_Internalname = "ALLPRODUCTS";
         subAllproductsselected_Internalname = "ALLPRODUCTSSELECTED";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("mtaKB", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subAllproductsselected_Allowcollapsing = 0;
         subAllproducts_Allowcollapsing = 0;
         subAllproducts_Allowselection = 0;
         subAllproducts_Header = "";
         edtavCtlnewunitprice_Jsonclick = "";
         edtavCtlnewunitprice_Visible = 1;
         edtavCtlnewunitprice_Enabled = 1;
         edtavCtlunitprice1_Jsonclick = "";
         edtavCtlunitprice1_Enabled = 0;
         edtavCtlname1_Jsonclick = "";
         edtavCtlname1_Enabled = 0;
         subAllproductsselected_Class = "FreeStyleGrid";
         edtProductPrice_Jsonclick = "";
         edtSectorName_Jsonclick = "";
         edtBrandName_Jsonclick = "";
         edtSupplierName_Jsonclick = "";
         edtProductName_Jsonclick = "";
         edtProductId_Jsonclick = "";
         subAllproducts_Class = "PromptGrid";
         subAllproducts_Backcolorstyle = 0;
         subAllproductsselected_Backcolorstyle = 0;
         edtavCtlunitprice1_Enabled = -1;
         edtavCtlname1_Enabled = -1;
         edtavPercentage_Jsonclick = "";
         edtavPercentage_Enabled = 1;
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
         Roundtop_Captionposition = "Top";
         Roundtop_Captionstyle = "";
         Roundtop_Captionclass = "col-xs-12 AttributeLabel";
         Roundtop_Enabled = Convert.ToBoolean( -1);
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "WPUpdate Price";
         subAllproducts_Rows = 5;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'ALLPRODUCTSSELECTED_nFirstRecordOnPage'},{av:'ALLPRODUCTSSELECTED_nEOF'},{av:'AV15ProductsSelected',fld:'vPRODUCTSSELECTED',grid:64,pic:''},{av:'nGXsfl_64_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:64},{av:'nRC_GXsfl_64',ctrl:'ALLPRODUCTSSELECTED',prop:'GridRC',grid:64},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV10Code',fld:'vCODE',pic:''},{av:'AV9Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV6Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV5Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV7Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV49Newpercentage',fld:'vNEWPERCENTAGE',pic:'9999999.99',hsh:true},{av:'AV18newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV19newCode',fld:'vNEWCODE',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("PRODUCTNAME.CLICK","{handler:'E17232',iparms:[{av:'ALLPRODUCTSSELECTED_nFirstRecordOnPage'},{av:'ALLPRODUCTSSELECTED_nEOF'},{av:'AV15ProductsSelected',fld:'vPRODUCTSSELECTED',grid:64,pic:''},{av:'nGXsfl_64_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:64},{av:'nRC_GXsfl_64',ctrl:'ALLPRODUCTSSELECTED',prop:'GridRC',grid:64},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV10Code',fld:'vCODE',pic:''},{av:'AV9Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV6Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV5Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV7Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV49Newpercentage',fld:'vNEWPERCENTAGE',pic:'9999999.99',hsh:true},{av:'AV18newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV19newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'AV13SelectedId',fld:'vSELECTEDID',pic:''},{av:'A15ProductId',fld:'PRODUCTID',pic:'ZZZZZ9',hsh:true},{av:'A16ProductName',fld:'PRODUCTNAME',pic:'',hsh:true},{av:'A5SupplierName',fld:'SUPPLIERNAME',pic:''},{av:'A2BrandName',fld:'BRANDNAME',pic:''},{av:'A10SectorName',fld:'SECTORNAME',pic:''},{av:'A18ProductPrice',fld:'PRODUCTPRICE',pic:'ZZZZZZ9.99',hsh:true},{av:'AV8Percentage',fld:'vPERCENTAGE',pic:'ZZ9.99'},{av:'AV36RoundTop',fld:'vROUNDTOP',pic:''},{av:'AV27ProductsSelectedAux',fld:'vPRODUCTSSELECTEDAUX',pic:''},{av:'AV28SelectedIdAux',fld:'vSELECTEDIDAUX',pic:''},{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'}]");
         setEventMetadata("PRODUCTNAME.CLICK",",oparms:[{av:'AV27ProductsSelectedAux',fld:'vPRODUCTSSELECTEDAUX',pic:''},{av:'AV28SelectedIdAux',fld:'vSELECTEDIDAUX',pic:''},{av:'AV15ProductsSelected',fld:'vPRODUCTSSELECTED',grid:64,pic:''},{av:'nGXsfl_64_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:64},{av:'ALLPRODUCTSSELECTED_nFirstRecordOnPage'},{av:'nRC_GXsfl_64',ctrl:'ALLPRODUCTSSELECTED',prop:'GridRC',grid:64},{av:'AV13SelectedId',fld:'vSELECTEDID',pic:''}]}");
         setEventMetadata("'UPDATEPRICE'","{handler:'E12232',iparms:[{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV10Code',fld:'vCODE',pic:''},{av:'AV9Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV6Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV5Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV7Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV49Newpercentage',fld:'vNEWPERCENTAGE',pic:'9999999.99',hsh:true},{av:'AV18newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV19newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'AV13SelectedId',fld:'vSELECTEDID',pic:''},{av:'AV8Percentage',fld:'vPERCENTAGE',pic:'ZZ9.99'},{av:'AV15ProductsSelected',fld:'vPRODUCTSSELECTED',grid:64,pic:''},{av:'nGXsfl_64_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:64},{av:'ALLPRODUCTSSELECTED_nFirstRecordOnPage'},{av:'nRC_GXsfl_64',ctrl:'ALLPRODUCTSSELECTED',prop:'GridRC',grid:64},{av:'ALLPRODUCTSSELECTED_nEOF'}]");
         setEventMetadata("'UPDATEPRICE'",",oparms:[{av:'AV15ProductsSelected',fld:'vPRODUCTSSELECTED',grid:64,pic:''},{av:'nGXsfl_64_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:64},{av:'ALLPRODUCTSSELECTED_nFirstRecordOnPage'},{av:'nRC_GXsfl_64',ctrl:'ALLPRODUCTSSELECTED',prop:'GridRC',grid:64},{av:'AV13SelectedId',fld:'vSELECTEDID',pic:''}]}");
         setEventMetadata("'CANCELUPDATE'","{handler:'E13232',iparms:[{av:'AV15ProductsSelected',fld:'vPRODUCTSSELECTED',grid:64,pic:''},{av:'nGXsfl_64_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:64},{av:'ALLPRODUCTSSELECTED_nFirstRecordOnPage'},{av:'nRC_GXsfl_64',ctrl:'ALLPRODUCTSSELECTED',prop:'GridRC',grid:64},{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'ALLPRODUCTSSELECTED_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV10Code',fld:'vCODE',pic:''},{av:'AV9Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV6Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV5Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV7Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV49Newpercentage',fld:'vNEWPERCENTAGE',pic:'9999999.99',hsh:true},{av:'AV18newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV19newCode',fld:'vNEWCODE',pic:'',hsh:true}]");
         setEventMetadata("'CANCELUPDATE'",",oparms:[{av:'AV8Percentage',fld:'vPERCENTAGE',pic:'ZZ9.99'},{av:'AV15ProductsSelected',fld:'vPRODUCTSSELECTED',grid:64,pic:''},{av:'nGXsfl_64_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:64},{av:'ALLPRODUCTSSELECTED_nFirstRecordOnPage'},{av:'nRC_GXsfl_64',ctrl:'ALLPRODUCTSSELECTED',prop:'GridRC',grid:64},{av:'AV13SelectedId',fld:'vSELECTEDID',pic:''},{av:'AV27ProductsSelectedAux',fld:'vPRODUCTSSELECTEDAUX',pic:''},{av:'AV28SelectedIdAux',fld:'vSELECTEDIDAUX',pic:''}]}");
         setEventMetadata("'REMOVE'","{handler:'E15232',iparms:[{av:'AV15ProductsSelected',fld:'vPRODUCTSSELECTED',grid:64,pic:''},{av:'nGXsfl_64_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:64},{av:'ALLPRODUCTSSELECTED_nFirstRecordOnPage'},{av:'nRC_GXsfl_64',ctrl:'ALLPRODUCTSSELECTED',prop:'GridRC',grid:64},{av:'AV13SelectedId',fld:'vSELECTEDID',pic:''},{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'ALLPRODUCTSSELECTED_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV10Code',fld:'vCODE',pic:''},{av:'AV9Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV6Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV5Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV7Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV49Newpercentage',fld:'vNEWPERCENTAGE',pic:'9999999.99',hsh:true},{av:'AV18newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV19newCode',fld:'vNEWCODE',pic:'',hsh:true}]");
         setEventMetadata("'REMOVE'",",oparms:[{av:'AV13SelectedId',fld:'vSELECTEDID',pic:''},{av:'AV15ProductsSelected',fld:'vPRODUCTSSELECTED',grid:64,pic:''},{av:'nGXsfl_64_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:64},{av:'ALLPRODUCTSSELECTED_nFirstRecordOnPage'},{av:'nRC_GXsfl_64',ctrl:'ALLPRODUCTSSELECTED',prop:'GridRC',grid:64}]}");
         setEventMetadata("'ALLPRODUCTS'","{handler:'E14232',iparms:[{av:'AV9Name',fld:'vNAME',pic:''},{av:'AV10Code',fld:'vCODE',pic:''},{av:'dynavSupplier'},{av:'AV6Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV7Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV5Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'AV13SelectedId',fld:'vSELECTEDID',pic:''},{av:'AV8Percentage',fld:'vPERCENTAGE',pic:'ZZ9.99'},{av:'AV36RoundTop',fld:'vROUNDTOP',pic:''},{av:'AV15ProductsSelected',fld:'vPRODUCTSSELECTED',grid:64,pic:''},{av:'nGXsfl_64_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:64},{av:'ALLPRODUCTSSELECTED_nFirstRecordOnPage'},{av:'nRC_GXsfl_64',ctrl:'ALLPRODUCTSSELECTED',prop:'GridRC',grid:64},{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'ALLPRODUCTSSELECTED_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV49Newpercentage',fld:'vNEWPERCENTAGE',pic:'9999999.99',hsh:true},{av:'AV18newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV19newCode',fld:'vNEWCODE',pic:'',hsh:true}]");
         setEventMetadata("'ALLPRODUCTS'",",oparms:[{av:'AV27ProductsSelectedAux',fld:'vPRODUCTSSELECTEDAUX',pic:''},{av:'AV13SelectedId',fld:'vSELECTEDID',pic:''},{av:'AV15ProductsSelected',fld:'vPRODUCTSSELECTED',grid:64,pic:''},{av:'nGXsfl_64_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:64},{av:'ALLPRODUCTSSELECTED_nFirstRecordOnPage'},{av:'nRC_GXsfl_64',ctrl:'ALLPRODUCTSSELECTED',prop:'GridRC',grid:64}]}");
         setEventMetadata("VROUNDTOP.CONTROLVALUECHANGED","{handler:'E11232',iparms:[{av:'Roundtop_Text',ctrl:'vROUNDTOP',prop:'Text'},{av:'AV36RoundTop',fld:'vROUNDTOP',pic:''},{av:'AV15ProductsSelected',fld:'vPRODUCTSSELECTED',grid:64,pic:''},{av:'nGXsfl_64_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:64},{av:'ALLPRODUCTSSELECTED_nFirstRecordOnPage'},{av:'nRC_GXsfl_64',ctrl:'ALLPRODUCTSSELECTED',prop:'GridRC',grid:64},{av:'AV8Percentage',fld:'vPERCENTAGE',pic:'ZZ9.99'},{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'ALLPRODUCTSSELECTED_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV10Code',fld:'vCODE',pic:''},{av:'AV9Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV6Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV5Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV7Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV49Newpercentage',fld:'vNEWPERCENTAGE',pic:'9999999.99',hsh:true},{av:'AV18newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV19newCode',fld:'vNEWCODE',pic:'',hsh:true}]");
         setEventMetadata("VROUNDTOP.CONTROLVALUECHANGED",",oparms:[{av:'AV15ProductsSelected',fld:'vPRODUCTSSELECTED',grid:64,pic:''},{av:'nGXsfl_64_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:64},{av:'ALLPRODUCTSSELECTED_nFirstRecordOnPage'},{av:'nRC_GXsfl_64',ctrl:'ALLPRODUCTSSELECTED',prop:'GridRC',grid:64}]}");
         setEventMetadata("ALLPRODUCTS_FIRSTPAGE","{handler:'suballproducts_firstpage',iparms:[{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV10Code',fld:'vCODE',pic:''},{av:'AV9Name',fld:'vNAME',pic:''},{av:'AV49Newpercentage',fld:'vNEWPERCENTAGE',pic:'9999999.99',hsh:true},{av:'AV18newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV19newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'dynavSupplier'},{av:'AV6Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV5Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV7Sector',fld:'vSECTOR',pic:'ZZZZZ9'}]");
         setEventMetadata("ALLPRODUCTS_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("ALLPRODUCTS_PREVPAGE","{handler:'suballproducts_previouspage',iparms:[{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV10Code',fld:'vCODE',pic:''},{av:'AV9Name',fld:'vNAME',pic:''},{av:'AV49Newpercentage',fld:'vNEWPERCENTAGE',pic:'9999999.99',hsh:true},{av:'AV18newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV19newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'dynavSupplier'},{av:'AV6Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV5Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV7Sector',fld:'vSECTOR',pic:'ZZZZZ9'}]");
         setEventMetadata("ALLPRODUCTS_PREVPAGE",",oparms:[]}");
         setEventMetadata("ALLPRODUCTS_NEXTPAGE","{handler:'suballproducts_nextpage',iparms:[{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV10Code',fld:'vCODE',pic:''},{av:'AV9Name',fld:'vNAME',pic:''},{av:'AV49Newpercentage',fld:'vNEWPERCENTAGE',pic:'9999999.99',hsh:true},{av:'AV18newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV19newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'dynavSupplier'},{av:'AV6Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV5Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV7Sector',fld:'vSECTOR',pic:'ZZZZZ9'}]");
         setEventMetadata("ALLPRODUCTS_NEXTPAGE",",oparms:[]}");
         setEventMetadata("ALLPRODUCTS_LASTPAGE","{handler:'suballproducts_lastpage',iparms:[{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV10Code',fld:'vCODE',pic:''},{av:'AV9Name',fld:'vNAME',pic:''},{av:'AV49Newpercentage',fld:'vNEWPERCENTAGE',pic:'9999999.99',hsh:true},{av:'AV18newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV19newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'dynavSupplier'},{av:'AV6Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV5Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV7Sector',fld:'vSECTOR',pic:'ZZZZZ9'}]");
         setEventMetadata("ALLPRODUCTS_LASTPAGE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Productprice',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("VALIDV_GXV3","{handler:'Validv_Gxv3',iparms:[]");
         setEventMetadata("VALIDV_GXV3",",oparms:[]}");
         setEventMetadata("VALIDV_GXV4","{handler:'Validv_Gxv4',iparms:[]");
         setEventMetadata("VALIDV_GXV4",",oparms:[]}");
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
         Roundtop_Text = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV10Code = "";
         AV9Name = "";
         AV18newName = "";
         AV19newCode = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV15ProductsSelected = new GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem>( context, "SDTProductsSelectedItem", "mtaKB");
         AV13SelectedId = new GxSimpleCollection<int>();
         AV27ProductsSelectedAux = new GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem>( context, "SDTProductsSelectedItem", "mtaKB");
         AV28SelectedIdAux = new GxSimpleCollection<int>();
         AV16OneProduct = new SdtSDTProductsSelected_SDTProductsSelectedItem(context);
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnallproducts_Jsonclick = "";
         AllproductsContainer = new GXWebGrid( context);
         sStyleString = "";
         bttUpdateprice_Jsonclick = "";
         ucRoundtop = new GXUserControl();
         bttCancelupdate_Jsonclick = "";
         AllproductsselectedContainer = new GXWebGrid( context);
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A16ProductName = "";
         A5SupplierName = "";
         A2BrandName = "";
         A10SectorName = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         scmdbuf = "";
         H00232_A4SupplierId = new int[1] ;
         H00232_A5SupplierName = new string[] {""} ;
         H00233_A1BrandId = new int[1] ;
         H00233_A2BrandName = new string[] {""} ;
         H00234_A9SectorId = new int[1] ;
         H00234_A10SectorName = new string[] {""} ;
         lV10Code = "";
         lV9Name = "";
         A55ProductCode = "";
         H00235_A9SectorId = new int[1] ;
         H00235_A1BrandId = new int[1] ;
         H00235_A4SupplierId = new int[1] ;
         H00235_A55ProductCode = new string[] {""} ;
         H00235_n55ProductCode = new bool[] {false} ;
         H00235_A18ProductPrice = new decimal[1] ;
         H00235_A10SectorName = new string[] {""} ;
         H00235_A2BrandName = new string[] {""} ;
         H00235_A5SupplierName = new string[] {""} ;
         H00235_A16ProductName = new string[] {""} ;
         H00235_A15ProductId = new int[1] ;
         H00236_AALLPRODUCTS_nRecordCount = new long[1] ;
         AV11Product = new SdtProduct(context);
         GXt_objcol_SdtSDTProductsSelected_SDTProductsSelectedItem1 = new GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem>( context, "SDTProductsSelectedItem", "mtaKB");
         AllproductsRow = new GXWebRow();
         AllproductsselectedRow = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subAllproducts_Linesclass = "";
         ROClassString = "";
         subAllproductsselected_Linesclass = "";
         bttRemove_Jsonclick = "";
         AllproductsColumn = new GXWebColumn();
         subAllproductsselected_Header = "";
         AllproductsselectedColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpupdateprice__default(),
            new Object[][] {
                new Object[] {
               H00232_A4SupplierId, H00232_A5SupplierName
               }
               , new Object[] {
               H00233_A1BrandId, H00233_A2BrandName
               }
               , new Object[] {
               H00234_A9SectorId, H00234_A10SectorName
               }
               , new Object[] {
               H00235_A9SectorId, H00235_A1BrandId, H00235_A4SupplierId, H00235_A55ProductCode, H00235_n55ProductCode, H00235_A18ProductPrice, H00235_A10SectorName, H00235_A2BrandName, H00235_A5SupplierName, H00235_A16ProductName,
               H00235_A15ProductId
               }
               , new Object[] {
               H00236_AALLPRODUCTS_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavCtlname1_Enabled = 0;
         edtavCtlunitprice1_Enabled = 0;
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short ALLPRODUCTS_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subAllproducts_Backcolorstyle ;
      private short subAllproductsselected_Backcolorstyle ;
      private short AV40Count ;
      private short AV39Digit ;
      private short AV29i ;
      private short ALLPRODUCTSSELECTED_nEOF ;
      private short AV23Position ;
      private short nGXWrapped ;
      private short subAllproducts_Backstyle ;
      private short subAllproductsselected_Backstyle ;
      private short subAllproducts_Titlebackstyle ;
      private short subAllproducts_Allowselection ;
      private short subAllproducts_Allowhovering ;
      private short subAllproducts_Allowcollapsing ;
      private short subAllproducts_Collapsed ;
      private short subAllproductsselected_Allowselection ;
      private short subAllproductsselected_Allowhovering ;
      private short subAllproductsselected_Allowcollapsing ;
      private short subAllproductsselected_Collapsed ;
      private int nRC_GXsfl_34 ;
      private int nRC_GXsfl_64 ;
      private int subAllproducts_Rows ;
      private int nGXsfl_34_idx=1 ;
      private int AV6Supplier ;
      private int AV5Brand ;
      private int AV7Sector ;
      private int nGXsfl_64_idx=1 ;
      private int AV50GXV7 ;
      private int edtavCode_Enabled ;
      private int edtavName_Enabled ;
      private int edtavPercentage_Enabled ;
      private int AV43GXV1 ;
      private int A15ProductId ;
      private int gxdynajaxindex ;
      private int subAllproducts_Islastpage ;
      private int subAllproductsselected_Islastpage ;
      private int edtavCtlname1_Enabled ;
      private int edtavCtlunitprice1_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A4SupplierId ;
      private int A1BrandId ;
      private int A9SectorId ;
      private int nGXsfl_64_fel_idx=1 ;
      private int AV47GXV5 ;
      private int nGXsfl_64_bak_idx=1 ;
      private int AV48GXV6 ;
      private int AV51GXV8 ;
      private int AV52GXV9 ;
      private int AV53GXV10 ;
      private int idxLst ;
      private int subAllproducts_Backcolor ;
      private int subAllproducts_Allbackcolor ;
      private int subAllproductsselected_Backcolor ;
      private int subAllproductsselected_Allbackcolor ;
      private int edtavCtlnewunitprice_Enabled ;
      private int edtavCtlnewunitprice_Visible ;
      private int subAllproducts_Titlebackcolor ;
      private int subAllproducts_Selectedindex ;
      private int subAllproducts_Selectioncolor ;
      private int subAllproducts_Hoveringcolor ;
      private int subAllproductsselected_Selectedindex ;
      private int subAllproductsselected_Selectioncolor ;
      private int subAllproductsselected_Hoveringcolor ;
      private long ALLPRODUCTS_nFirstRecordOnPage ;
      private long ALLPRODUCTS_nCurrentRecord ;
      private long ALLPRODUCTSSELECTED_nCurrentRecord ;
      private long ALLPRODUCTS_nRecordCount ;
      private long ALLPRODUCTSSELECTED_nFirstRecordOnPage ;
      private decimal AV49Newpercentage ;
      private decimal AV8Percentage ;
      private decimal A18ProductPrice ;
      private decimal AV38PriceRounded ;
      private string Roundtop_Text ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_34_idx="0001" ;
      private string sGXsfl_64_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Roundtop_Captionclass ;
      private string Roundtop_Captionstyle ;
      private string Roundtop_Captionposition ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divTable2_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnallproducts_Internalname ;
      private string bttBtnallproducts_Jsonclick ;
      private string edtavCode_Internalname ;
      private string edtavCode_Jsonclick ;
      private string edtavName_Internalname ;
      private string edtavName_Jsonclick ;
      private string dynavSupplier_Internalname ;
      private string dynavSupplier_Jsonclick ;
      private string dynavBrand_Internalname ;
      private string dynavBrand_Jsonclick ;
      private string dynavSector_Internalname ;
      private string dynavSector_Jsonclick ;
      private string sStyleString ;
      private string subAllproducts_Internalname ;
      private string divTable1_Internalname ;
      private string divTable4_Internalname ;
      private string bttUpdateprice_Internalname ;
      private string bttUpdateprice_Jsonclick ;
      private string edtavPercentage_Internalname ;
      private string edtavPercentage_Jsonclick ;
      private string Roundtop_Internalname ;
      private string bttCancelupdate_Internalname ;
      private string bttCancelupdate_Jsonclick ;
      private string subAllproductsselected_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtProductId_Internalname ;
      private string edtProductName_Internalname ;
      private string edtSupplierName_Internalname ;
      private string edtBrandName_Internalname ;
      private string edtSectorName_Internalname ;
      private string edtProductPrice_Internalname ;
      private string gxwrpcisep ;
      private string scmdbuf ;
      private string edtavCtlname1_Internalname ;
      private string edtavCtlunitprice1_Internalname ;
      private string sGXsfl_64_fel_idx="0001" ;
      private string sGXsfl_34_fel_idx="0001" ;
      private string subAllproducts_Class ;
      private string subAllproducts_Linesclass ;
      private string ROClassString ;
      private string edtProductId_Jsonclick ;
      private string edtProductName_Jsonclick ;
      private string edtSupplierName_Jsonclick ;
      private string edtBrandName_Jsonclick ;
      private string edtSectorName_Jsonclick ;
      private string edtProductPrice_Jsonclick ;
      private string edtavCtlnewunitprice_Internalname ;
      private string subAllproductsselected_Class ;
      private string subAllproductsselected_Linesclass ;
      private string divGrid1table_Internalname ;
      private string edtavCtlname1_Jsonclick ;
      private string edtavCtlunitprice1_Jsonclick ;
      private string edtavCtlnewunitprice_Jsonclick ;
      private string bttRemove_Internalname ;
      private string bttRemove_Jsonclick ;
      private string subAllproducts_Header ;
      private string subAllproductsselected_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV36RoundTop ;
      private bool Roundtop_Enabled ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool bGXsfl_64_Refreshing=false ;
      private bool bGXsfl_34_Refreshing=false ;
      private bool n55ProductCode ;
      private bool returnInSub ;
      private bool gx_BV64 ;
      private bool AV21AllOk ;
      private string AV10Code ;
      private string AV9Name ;
      private string AV18newName ;
      private string AV19newCode ;
      private string A16ProductName ;
      private string A5SupplierName ;
      private string A2BrandName ;
      private string A10SectorName ;
      private string lV10Code ;
      private string lV9Name ;
      private string A55ProductCode ;
      private GxSimpleCollection<int> AV13SelectedId ;
      private GxSimpleCollection<int> AV28SelectedIdAux ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid AllproductsContainer ;
      private GXWebGrid AllproductsselectedContainer ;
      private GXWebRow AllproductsRow ;
      private GXWebRow AllproductsselectedRow ;
      private GXWebColumn AllproductsColumn ;
      private GXWebColumn AllproductsselectedColumn ;
      private GXUserControl ucRoundtop ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavSupplier ;
      private GXCombobox dynavBrand ;
      private GXCombobox dynavSector ;
      private IDataStoreProvider pr_default ;
      private int[] H00232_A4SupplierId ;
      private string[] H00232_A5SupplierName ;
      private int[] H00233_A1BrandId ;
      private string[] H00233_A2BrandName ;
      private int[] H00234_A9SectorId ;
      private string[] H00234_A10SectorName ;
      private int[] H00235_A9SectorId ;
      private int[] H00235_A1BrandId ;
      private int[] H00235_A4SupplierId ;
      private string[] H00235_A55ProductCode ;
      private bool[] H00235_n55ProductCode ;
      private decimal[] H00235_A18ProductPrice ;
      private string[] H00235_A10SectorName ;
      private string[] H00235_A2BrandName ;
      private string[] H00235_A5SupplierName ;
      private string[] H00235_A16ProductName ;
      private int[] H00235_A15ProductId ;
      private long[] H00236_AALLPRODUCTS_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> AV15ProductsSelected ;
      private GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> AV27ProductsSelectedAux ;
      private GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> GXt_objcol_SdtSDTProductsSelected_SDTProductsSelectedItem1 ;
      private GXWebForm Form ;
      private SdtSDTProductsSelected_SDTProductsSelectedItem AV16OneProduct ;
      private SdtProduct AV11Product ;
   }

   public class wpupdateprice__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00235( IGxContext context ,
                                             string AV10Code ,
                                             string AV9Name ,
                                             int AV6Supplier ,
                                             int AV5Brand ,
                                             int AV7Sector ,
                                             string A55ProductCode ,
                                             string A16ProductName ,
                                             int A4SupplierId ,
                                             int A1BrandId ,
                                             int A9SectorId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[8];
         Object[] GXv_Object3 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[SectorId], T1.[BrandId], T1.[SupplierId], T1.[ProductCode], T1.[ProductPrice], T2.[SectorName], T3.[BrandName], T4.[SupplierName], T1.[ProductName], T1.[ProductId]";
         sFromString = " FROM ((([Product] T1 INNER JOIN [Sector] T2 ON T2.[SectorId] = T1.[SectorId]) INNER JOIN [Brand] T3 ON T3.[BrandId] = T1.[BrandId]) INNER JOIN [Supplier] T4 ON T4.[SupplierId] = T1.[SupplierId])";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10Code)) )
         {
            AddWhere(sWhereString, "(T1.[ProductCode] like @lV10Code)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9Name)) )
         {
            AddWhere(sWhereString, "(T1.[ProductName] like @lV9Name)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (0==AV6Supplier) )
         {
            AddWhere(sWhereString, "(T1.[SupplierId] = @AV6Supplier)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (0==AV5Brand) )
         {
            AddWhere(sWhereString, "(T1.[BrandId] = @AV5Brand)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! (0==AV7Sector) )
         {
            AddWhere(sWhereString, "(T1.[SectorId] = @AV7Sector)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         sOrderString += " ORDER BY T1.[ProductName]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_H00236( IGxContext context ,
                                             string AV10Code ,
                                             string AV9Name ,
                                             int AV6Supplier ,
                                             int AV5Brand ,
                                             int AV7Sector ,
                                             string A55ProductCode ,
                                             string A16ProductName ,
                                             int A4SupplierId ,
                                             int A1BrandId ,
                                             int A9SectorId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[5];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ((([Product] T1 INNER JOIN [Sector] T3 ON T3.[SectorId] = T1.[SectorId]) INNER JOIN [Brand] T2 ON T2.[BrandId] = T1.[BrandId]) INNER JOIN [Supplier] T4 ON T4.[SupplierId] = T1.[SupplierId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10Code)) )
         {
            AddWhere(sWhereString, "(T1.[ProductCode] like @lV10Code)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9Name)) )
         {
            AddWhere(sWhereString, "(T1.[ProductName] like @lV9Name)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ! (0==AV6Supplier) )
         {
            AddWhere(sWhereString, "(T1.[SupplierId] = @AV6Supplier)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! (0==AV5Brand) )
         {
            AddWhere(sWhereString, "(T1.[BrandId] = @AV5Brand)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! (0==AV7Sector) )
         {
            AddWhere(sWhereString, "(T1.[SectorId] = @AV7Sector)");
         }
         else
         {
            GXv_int4[4] = 1;
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
               case 3 :
                     return conditional_H00235(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] );
               case 4 :
                     return conditional_H00236(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00232;
          prmH00232 = new Object[] {
          };
          Object[] prmH00233;
          prmH00233 = new Object[] {
          };
          Object[] prmH00234;
          prmH00234 = new Object[] {
          };
          Object[] prmH00235;
          prmH00235 = new Object[] {
          new ParDef("@lV10Code",GXType.NVarChar,100,0) ,
          new ParDef("@lV9Name",GXType.NVarChar,60,0) ,
          new ParDef("@AV6Supplier",GXType.Int32,6,0) ,
          new ParDef("@AV5Brand",GXType.Int32,6,0) ,
          new ParDef("@AV7Sector",GXType.Int32,6,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00236;
          prmH00236 = new Object[] {
          new ParDef("@lV10Code",GXType.NVarChar,100,0) ,
          new ParDef("@lV9Name",GXType.NVarChar,60,0) ,
          new ParDef("@AV6Supplier",GXType.Int32,6,0) ,
          new ParDef("@AV5Brand",GXType.Int32,6,0) ,
          new ParDef("@AV7Sector",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00232", "SELECT [SupplierId], [SupplierName] FROM [Supplier] ORDER BY [SupplierName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00232,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00233", "SELECT [BrandId], [BrandName] FROM [Brand] ORDER BY [BrandName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00233,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00234", "SELECT [SectorId], [SectorName] FROM [Sector] ORDER BY [SectorName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00234,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00235", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00235,6, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00236", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00236,1, GxCacheFrequency.OFF ,true,false )
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
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((int[]) buf[10])[0] = rslt.getInt(10);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
