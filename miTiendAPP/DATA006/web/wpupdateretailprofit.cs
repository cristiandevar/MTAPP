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
   public class wpupdateretailprofit : GXDataArea
   {
      public wpupdateretailprofit( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public wpupdateretailprofit( IGxContext context )
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
               GXDLVvSUPPLIER2K2( ) ;
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
               GXDLVvBRAND2K2( ) ;
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
               GXDLVvSECTOR2K2( ) ;
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Retailfgrid") == 0 )
            {
               gxnrRetailfgrid_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Retailfgrid") == 0 )
            {
               gxgrRetailfgrid_refresh_invoke( ) ;
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
         nRC_GXsfl_39 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_39"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_39_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_39_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_39_idx = GetPar( "sGXsfl_39_idx");
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
         AV9Code = GetPar( "Code");
         AV16Name = GetPar( "Name");
         dynavSupplier.FromJSonString( GetNextPar( ));
         AV23Supplier = (int)(Math.Round(NumberUtil.Val( GetPar( "Supplier"), "."), 18, MidpointRounding.ToEven));
         dynavBrand.FromJSonString( GetNextPar( ));
         AV8Brand = (int)(Math.Round(NumberUtil.Val( GetPar( "Brand"), "."), 18, MidpointRounding.ToEven));
         dynavSector.FromJSonString( GetNextPar( ));
         AV22Sector = (int)(Math.Round(NumberUtil.Val( GetPar( "Sector"), "."), 18, MidpointRounding.ToEven));
         AV34newName = GetPar( "newName");
         AV35newCode = GetPar( "newCode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrAllproducts_refresh( subAllproducts_Rows, AV9Code, AV16Name, AV23Supplier, AV8Brand, AV22Sector, AV34newName, AV35newCode) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrAllproducts_refresh_invoke */
      }

      protected void gxnrRetailfgrid_newrow_invoke( )
      {
         nRC_GXsfl_97 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_97"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_97_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_97_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_97_idx = GetPar( "sGXsfl_97_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrRetailfgrid_newrow( ) ;
         /* End function gxnrRetailfgrid_newrow_invoke */
      }

      protected void gxgrRetailfgrid_refresh_invoke( )
      {
         subAllproducts_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subAllproducts_Rows"), "."), 18, MidpointRounding.ToEven));
         AV9Code = GetPar( "Code");
         AV16Name = GetPar( "Name");
         dynavSupplier.FromJSonString( GetNextPar( ));
         AV23Supplier = (int)(Math.Round(NumberUtil.Val( GetPar( "Supplier"), "."), 18, MidpointRounding.ToEven));
         dynavBrand.FromJSonString( GetNextPar( ));
         AV8Brand = (int)(Math.Round(NumberUtil.Val( GetPar( "Brand"), "."), 18, MidpointRounding.ToEven));
         dynavSector.FromJSonString( GetNextPar( ));
         AV22Sector = (int)(Math.Round(NumberUtil.Val( GetPar( "Sector"), "."), 18, MidpointRounding.ToEven));
         AV34newName = GetPar( "newName");
         AV35newCode = GetPar( "newCode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrRetailfgrid_refresh( subAllproducts_Rows, AV9Code, AV16Name, AV23Supplier, AV8Brand, AV22Sector, AV34newName, AV35newCode) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrRetailfgrid_refresh_invoke */
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
         PA2K2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2K2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpupdateretailprofit.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vNEWNAME", AV34newName);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV34newName, "")), context));
         GxWebStd.gx_hidden_field( context, "vNEWCODE", AV35newCode);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV35newCode, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vCODE", AV9Code);
         GxWebStd.gx_hidden_field( context, "GXH_vNAME", AV16Name);
         GxWebStd.gx_hidden_field( context, "GXH_vSUPPLIER", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23Supplier), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vBRAND", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8Brand), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vSECTOR", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22Sector), 6, 0, ".", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Productsselected", AV19ProductsSelected);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Productsselected", AV19ProductsSelected);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_39", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_39), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_97", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_97), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vNEWNAME", AV34newName);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV34newName, "")), context));
         GxWebStd.gx_hidden_field( context, "vNEWCODE", AV35newCode);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV35newCode, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vIDSSELECTED", AV14IdsSelected);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vIDSSELECTED", AV14IdsSelected);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vISIN", AV30IsIn);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPRODUCTSSELECTEDAUX", AV20ProductsSelectedAux);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPRODUCTSSELECTEDAUX", AV20ProductsSelectedAux);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vIDSSELECTEDAUX", AV15IdsSelectedAux);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vIDSSELECTEDAUX", AV15IdsSelectedAux);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPRODUCTSSELECTED", AV19ProductsSelected);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPRODUCTSSELECTED", AV19ProductsSelected);
         }
         GxWebStd.gx_hidden_field( context, "vIDSELECTED", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31IdSelected), 6, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vONEPRODUCT", AV17OneProduct);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vONEPRODUCT", AV17OneProduct);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vALLOK", AV7AllOk);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vERRORMESSAGE", AV32ErrorMessage);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vERRORMESSAGE", AV32ErrorMessage);
         }
         GxWebStd.gx_hidden_field( context, "ALLPRODUCTS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(ALLPRODUCTS_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ALLPRODUCTS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(ALLPRODUCTS_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ALLPRODUCTS_Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAllproducts_Collapsed), 1, 0, ".", "")));
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
            WE2K2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2K2( ) ;
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
         return formatLink("wpupdateretailprofit.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WPUpdateRetailProfit" ;
      }

      public override string GetPgmdesc( )
      {
         return "WPUpdate Retail Profit" ;
      }

      protected void WB2K0( )
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
            GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Update Retail Profit", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WPUpdateRetailProfit.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "Center", "Bottom", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttSelectall_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(39), 2, 0)+","+"null"+");", "Select All", bttSelectall_Jsonclick, 5, "Select All", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'SELECTALL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPUpdateRetailProfit.htm");
            GxWebStd.gx_div_end( context, "Center", "Bottom", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavCode_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCode_Internalname, "Product Code", "col-xs-12 attribute-filterLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'" + sGXsfl_39_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCode_Internalname, AV9Code, StringUtil.RTrim( context.localUtil.Format( AV9Code, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,18);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCode_Jsonclick, 0, "attribute-filter", "", "", "", "", 1, edtavCode_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_WPUpdateRetailProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavName_Internalname, "Product Name", "col-xs-12 attribute-filterLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'" + sGXsfl_39_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavName_Internalname, AV16Name, StringUtil.RTrim( context.localUtil.Format( AV16Name, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavName_Jsonclick, 0, "attribute-filter", "", "", "", "", 1, edtavName_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_WPUpdateRetailProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavSupplier_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavSupplier_Internalname, "Supplier", "col-xs-12 attribute-filterLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_39_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavSupplier, dynavSupplier_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV23Supplier), 6, 0)), 1, dynavSupplier_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavSupplier.Enabled, 0, 0, 0, "em", 0, "", "", "attribute-filter", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "", true, 0, "HLP_WPUpdateRetailProfit.htm");
            dynavSupplier.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23Supplier), 6, 0));
            AssignProp("", false, dynavSupplier_Internalname, "Values", (string)(dynavSupplier.ToJavascriptSource()), true);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'" + sGXsfl_39_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavBrand, dynavBrand_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV8Brand), 6, 0)), 1, dynavBrand_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavBrand.Enabled, 0, 0, 0, "em", 0, "", "", "attribute-filter", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "", true, 0, "HLP_WPUpdateRetailProfit.htm");
            dynavBrand.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV8Brand), 6, 0));
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'" + sGXsfl_39_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavSector, dynavSector_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV22Sector), 6, 0)), 1, dynavSector_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavSector.Enabled, 0, 0, 0, "em", 0, "", "", "attribute-filter", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "", true, 0, "HLP_WPUpdateRetailProfit.htm");
            dynavSector.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22Sector), 6, 0));
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
            StartGridControl39( ) ;
         }
         if ( wbEnd == 39 )
         {
            wbEnd = 0;
            nRC_GXsfl_39 = (int)(nGXsfl_39_idx-1);
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
            GxWebStd.gx_div_start( context, divRetaiprofitltable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divButtonstable_Internalname, divButtonstable_Visible, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavNewretailprofit_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNewretailprofit_Internalname, "Retail Profit", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'" + sGXsfl_39_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNewretailprofit_Internalname, StringUtil.LTrim( StringUtil.NToC( AV36NewRetailProfit, 7, 2, ".", "")), StringUtil.LTrim( ((edtavNewretailprofit_Enabled!=0) ? context.localUtil.Format( AV36NewRetailProfit, "ZZZ9.99") : context.localUtil.Format( AV36NewRetailProfit, "ZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNewretailprofit_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavNewretailprofit_Enabled, 0, "text", "", 7, "chr", 1, "row", 7, 0, 0, 0, 0, -1, 0, true, "Profit", "right", false, "", "HLP_WPUpdateRetailProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttUpdate_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(39), 2, 0)+","+"null"+");", "Update", bttUpdate_Jsonclick, 5, "Update", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'UPDATE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPUpdateRetailProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(39), 2, 0)+","+"null"+");", "Cancel", bttCancel_Jsonclick, 5, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CANCEL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPUpdateRetailProfit.htm");
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
            GxWebStd.gx_div_start( context, divRetailprofittable_Internalname, divRetailprofittable_Visible, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable3_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Action", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdateRetailProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Code", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdateRetailProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "Name", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdateRetailProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "Supplier", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdateRetailProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock13_Internalname, "Brand", "", "", lblTextblock13_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdateRetailProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock14_Internalname, "Sector", "", "", lblTextblock14_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdateRetailProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock15_Internalname, "U. Cost Price", "", "", lblTextblock15_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdateRetailProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock16_Internalname, "R. Profit", "", "", lblTextblock16_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdateRetailProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock17_Internalname, "New R. Profit", "", "", lblTextblock17_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdateRetailProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock18_Internalname, "R. Price", "", "", lblTextblock18_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdateRetailProfit.htm");
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
            /*  Grid Control  */
            RetailfgridContainer.SetIsFreestyle(true);
            RetailfgridContainer.SetWrapped(nGXWrapped);
            StartGridControl97( ) ;
         }
         if ( wbEnd == 97 )
         {
            wbEnd = 0;
            nRC_GXsfl_97 = (int)(nGXsfl_97_idx-1);
            if ( RetailfgridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV42GXV1 = nGXsfl_97_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"RetailfgridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Retailfgrid", RetailfgridContainer, subRetailfgrid_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "RetailfgridContainerData", RetailfgridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "RetailfgridContainerData"+"V", RetailfgridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"RetailfgridContainerData"+"V"+"\" value='"+RetailfgridContainer.GridValuesHidden()+"'/>") ;
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
         if ( wbEnd == 39 )
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
         if ( wbEnd == 97 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( RetailfgridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV42GXV1 = nGXsfl_97_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"RetailfgridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Retailfgrid", RetailfgridContainer, subRetailfgrid_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "RetailfgridContainerData", RetailfgridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "RetailfgridContainerData"+"V", RetailfgridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"RetailfgridContainerData"+"V"+"\" value='"+RetailfgridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START2K2( )
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
            Form.Meta.addItem("description", "WPUpdate Retail Profit", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2K0( ) ;
      }

      protected void WS2K2( )
      {
         START2K2( ) ;
         EVT2K2( ) ;
      }

      protected void EVT2K2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "VNEWRETAILPROFIT.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E112K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'UPDATE'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Update' */
                              E122K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CANCEL'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Cancel' */
                              E132K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'SELECTALL'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'SelectAll' */
                              E142K2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 20), "VREMOVEPRODUCT.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "RETAILFGRID.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 38), "CTLNEWRETAILPROFIT.CONTROLVALUECHANGED") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 34), "CTLRETAILPRICE.CONTROLVALUECHANGED") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 16), "RETAILFGRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 20), "VREMOVEPRODUCT.CLICK") == 0 ) )
                           {
                              nGXsfl_97_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_97_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_97_idx), 4, 0), 4, "0");
                              SubsflControlProps_973( ) ;
                              AV42GXV1 = nGXsfl_97_idx;
                              if ( ( AV19ProductsSelected.Count >= AV42GXV1 ) && ( AV42GXV1 > 0 ) )
                              {
                                 AV19ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV42GXV1));
                                 AV39RemoveProduct = cgiGet( edtavRemoveproduct_Internalname);
                                 AssignProp("", false, edtavRemoveproduct_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV39RemoveProduct)) ? AV54Removeproduct_GXI : context.convertURL( context.PathToRelativeUrl( AV39RemoveProduct))), !bGXsfl_97_Refreshing);
                                 AssignProp("", false, edtavRemoveproduct_Internalname, "SrcSet", context.GetImageSrcSet( AV39RemoveProduct), true);
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "VREMOVEPRODUCT.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E152K2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "RETAILFGRID.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E162K2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "CTLNEWRETAILPROFIT.CONTROLVALUECHANGED") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E172K2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "CTLRETAILPRICE.CONTROLVALUECHANGED") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E182K2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "RETAILFGRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E192K3 ();
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
                           else if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "PRODUCTNAME.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 16), "ALLPRODUCTS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "PRODUCTNAME.CLICK") == 0 ) )
                           {
                              nGXsfl_39_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
                              SubsflControlProps_392( ) ;
                              A15ProductId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtProductId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A55ProductCode = cgiGet( edtProductCode_Internalname);
                              n55ProductCode = false;
                              A16ProductName = cgiGet( edtProductName_Internalname);
                              A5SupplierName = cgiGet( edtSupplierName_Internalname);
                              A2BrandName = cgiGet( edtBrandName_Internalname);
                              A10SectorName = cgiGet( edtSectorName_Internalname);
                              A85ProductCostPrice = context.localUtil.CToN( cgiGet( edtProductCostPrice_Internalname), ".", ",");
                              n85ProductCostPrice = false;
                              A89ProductRetailProfit = context.localUtil.CToN( cgiGet( edtProductRetailProfit_Internalname), ".", ",");
                              n89ProductRetailProfit = false;
                              A90ProductRetailPrice = context.localUtil.CToN( cgiGet( edtProductRetailPrice_Internalname), ".", ",");
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E202K2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "PRODUCTNAME.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E212K2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ALLPRODUCTS.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E222K2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Code Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCODE"), AV9Code) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Name Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vNAME"), AV16Name) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Supplier Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vSUPPLIER"), ".", ",") != Convert.ToDecimal( AV23Supplier )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Brand Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vBRAND"), ".", ",") != Convert.ToDecimal( AV8Brand )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Sector Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vSECTOR"), ".", ",") != Convert.ToDecimal( AV22Sector )) )
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

      protected void WE2K2( )
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

      protected void PA2K2( )
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

      protected void GXDLVvSUPPLIER2K2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvSUPPLIER_data2K2( ) ;
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

      protected void GXVvSUPPLIER_html2K2( )
      {
         int gxdynajaxvalue;
         GXDLVvSUPPLIER_data2K2( ) ;
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

      protected void GXDLVvSUPPLIER_data2K2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(None)");
         /* Using cursor H002K2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H002K2_A4SupplierId[0]), 6, 0, ".", "")));
            gxdynajaxctrldescr.Add(H002K2_A5SupplierName[0]);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void GXDLVvBRAND2K2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvBRAND_data2K2( ) ;
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

      protected void GXVvBRAND_html2K2( )
      {
         int gxdynajaxvalue;
         GXDLVvBRAND_data2K2( ) ;
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

      protected void GXDLVvBRAND_data2K2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(None)");
         /* Using cursor H002K3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H002K3_A1BrandId[0]), 6, 0, ".", "")));
            gxdynajaxctrldescr.Add(H002K3_A2BrandName[0]);
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void GXDLVvSECTOR2K2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvSECTOR_data2K2( ) ;
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

      protected void GXVvSECTOR_html2K2( )
      {
         int gxdynajaxvalue;
         GXDLVvSECTOR_data2K2( ) ;
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

      protected void GXDLVvSECTOR_data2K2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(None)");
         /* Using cursor H002K4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H002K4_A9SectorId[0]), 6, 0, ".", "")));
            gxdynajaxctrldescr.Add(H002K4_A10SectorName[0]);
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void gxnrAllproducts_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_392( ) ;
         while ( nGXsfl_39_idx <= nRC_GXsfl_39 )
         {
            sendrow_392( ) ;
            nGXsfl_39_idx = ((subAllproducts_Islastpage==1)&&(nGXsfl_39_idx+1>subAllproducts_fnc_Recordsperpage( )) ? 1 : nGXsfl_39_idx+1);
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( AllproductsContainer)) ;
         /* End function gxnrAllproducts_newrow */
      }

      protected void gxnrRetailfgrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_973( ) ;
         while ( nGXsfl_97_idx <= nRC_GXsfl_97 )
         {
            sendrow_973( ) ;
            nGXsfl_97_idx = ((subRetailfgrid_Islastpage==1)&&(nGXsfl_97_idx+1>subRetailfgrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_97_idx+1);
            sGXsfl_97_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_97_idx), 4, 0), 4, "0");
            SubsflControlProps_973( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( RetailfgridContainer)) ;
         /* End function gxnrRetailfgrid_newrow */
      }

      protected void gxgrAllproducts_refresh( int subAllproducts_Rows ,
                                              string AV9Code ,
                                              string AV16Name ,
                                              int AV23Supplier ,
                                              int AV8Brand ,
                                              int AV22Sector ,
                                              string AV34newName ,
                                              string AV35newCode )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         ALLPRODUCTS_nCurrentRecord = 0;
         RF2K2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrAllproducts_refresh */
      }

      protected void gxgrRetailfgrid_refresh( int subAllproducts_Rows ,
                                              string AV9Code ,
                                              string AV16Name ,
                                              int AV23Supplier ,
                                              int AV8Brand ,
                                              int AV22Sector ,
                                              string AV34newName ,
                                              string AV35newCode )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         RETAILFGRID_nCurrentRecord = 0;
         RF2K3( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrRetailfgrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUCTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A15ProductId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "PRODUCTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", "")));
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXVvSUPPLIER_html2K2( ) ;
            GXVvBRAND_html2K2( ) ;
            GXVvSECTOR_html2K2( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavSupplier.ItemCount > 0 )
         {
            AV23Supplier = (int)(Math.Round(NumberUtil.Val( dynavSupplier.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV23Supplier), 6, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV23Supplier", StringUtil.LTrimStr( (decimal)(AV23Supplier), 6, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavSupplier.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23Supplier), 6, 0));
            AssignProp("", false, dynavSupplier_Internalname, "Values", dynavSupplier.ToJavascriptSource(), true);
         }
         if ( dynavBrand.ItemCount > 0 )
         {
            AV8Brand = (int)(Math.Round(NumberUtil.Val( dynavBrand.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV8Brand), 6, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV8Brand", StringUtil.LTrimStr( (decimal)(AV8Brand), 6, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavBrand.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV8Brand), 6, 0));
            AssignProp("", false, dynavBrand_Internalname, "Values", dynavBrand.ToJavascriptSource(), true);
         }
         if ( dynavSector.ItemCount > 0 )
         {
            AV22Sector = (int)(Math.Round(NumberUtil.Val( dynavSector.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV22Sector), 6, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV22Sector", StringUtil.LTrimStr( (decimal)(AV22Sector), 6, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavSector.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22Sector), 6, 0));
            AssignProp("", false, dynavSector_Internalname, "Values", dynavSector.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF2K2( ) ;
         RF2K3( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavCtlcode1_Enabled = 0;
         AssignProp("", false, edtavCtlcode1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcode1_Enabled), 5, 0), !bGXsfl_97_Refreshing);
         edtavCtlname1_Enabled = 0;
         AssignProp("", false, edtavCtlname1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname1_Enabled), 5, 0), !bGXsfl_97_Refreshing);
         edtavCtlsupplier1_Enabled = 0;
         AssignProp("", false, edtavCtlsupplier1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsupplier1_Enabled), 5, 0), !bGXsfl_97_Refreshing);
         edtavCtlbrand1_Enabled = 0;
         AssignProp("", false, edtavCtlbrand1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlbrand1_Enabled), 5, 0), !bGXsfl_97_Refreshing);
         edtavCtlsector1_Enabled = 0;
         AssignProp("", false, edtavCtlsector1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsector1_Enabled), 5, 0), !bGXsfl_97_Refreshing);
         edtavCtlcostprice1_Enabled = 0;
         AssignProp("", false, edtavCtlcostprice1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcostprice1_Enabled), 5, 0), !bGXsfl_97_Refreshing);
         edtavCtlretailprofit1_Enabled = 0;
         AssignProp("", false, edtavCtlretailprofit1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlretailprofit1_Enabled), 5, 0), !bGXsfl_97_Refreshing);
      }

      protected void RF2K2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            AllproductsContainer.ClearRows();
         }
         wbStart = 39;
         nGXsfl_39_idx = 1;
         sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
         SubsflControlProps_392( ) ;
         bGXsfl_39_Refreshing = true;
         AllproductsContainer.AddObjectProperty("GridName", "Allproducts");
         AllproductsContainer.AddObjectProperty("CmpContext", "");
         AllproductsContainer.AddObjectProperty("InMasterPage", "false");
         AllproductsContainer.AddObjectProperty("Class", "PromptGrid");
         AllproductsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         AllproductsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         AllproductsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAllproducts_Backcolorstyle), 1, 0, ".", "")));
         AllproductsContainer.PageSize = subAllproducts_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_392( ) ;
            GXPagingFrom2 = (int)(ALLPRODUCTS_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subAllproducts_fnc_Recordsperpage( )+1);
            pr_default.dynParam(3, new Object[]{ new Object[]{
                                                 AV9Code ,
                                                 AV16Name ,
                                                 AV23Supplier ,
                                                 AV8Brand ,
                                                 AV22Sector ,
                                                 A55ProductCode ,
                                                 A16ProductName ,
                                                 A4SupplierId ,
                                                 A1BrandId ,
                                                 A9SectorId } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN
                                                 }
            });
            lV9Code = StringUtil.Concat( StringUtil.RTrim( AV9Code), "%", "");
            lV16Name = StringUtil.Concat( StringUtil.RTrim( AV16Name), "%", "");
            /* Using cursor H002K5 */
            pr_default.execute(3, new Object[] {lV9Code, lV16Name, AV23Supplier, AV8Brand, AV22Sector, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_39_idx = 1;
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
            while ( ( (pr_default.getStatus(3) != 101) ) && ( ( ALLPRODUCTS_nCurrentRecord < subAllproducts_fnc_Recordsperpage( ) ) ) )
            {
               A9SectorId = H002K5_A9SectorId[0];
               n9SectorId = H002K5_n9SectorId[0];
               A1BrandId = H002K5_A1BrandId[0];
               n1BrandId = H002K5_n1BrandId[0];
               A4SupplierId = H002K5_A4SupplierId[0];
               A10SectorName = H002K5_A10SectorName[0];
               A2BrandName = H002K5_A2BrandName[0];
               A5SupplierName = H002K5_A5SupplierName[0];
               A16ProductName = H002K5_A16ProductName[0];
               A55ProductCode = H002K5_A55ProductCode[0];
               n55ProductCode = H002K5_n55ProductCode[0];
               A15ProductId = H002K5_A15ProductId[0];
               A85ProductCostPrice = H002K5_A85ProductCostPrice[0];
               n85ProductCostPrice = H002K5_n85ProductCostPrice[0];
               A89ProductRetailProfit = H002K5_A89ProductRetailProfit[0];
               n89ProductRetailProfit = H002K5_n89ProductRetailProfit[0];
               A10SectorName = H002K5_A10SectorName[0];
               A2BrandName = H002K5_A2BrandName[0];
               A5SupplierName = H002K5_A5SupplierName[0];
               GXt_decimal1 = A90ProductRetailPrice;
               new roundvalue(context ).execute(  A85ProductCostPrice*(1+A89ProductRetailProfit/ (decimal)(100)), out  GXt_decimal1) ;
               GXt_decimal2 = A90ProductRetailPrice;
               new roundvalue(context ).execute(  A85ProductCostPrice*(1+A89ProductRetailProfit/ (decimal)(100)), out  GXt_decimal2) ;
               GXt_decimal3 = A90ProductRetailPrice;
               new roundvalue(context ).execute(  A85ProductCostPrice, out  GXt_decimal3) ;
               A90ProductRetailPrice = ((A89ProductRetailProfit!=Convert.ToDecimal(0)) ? GXt_decimal2 : GXt_decimal3);
               E222K2 ();
               pr_default.readNext(3);
            }
            ALLPRODUCTS_nEOF = (short)(((pr_default.getStatus(3) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "ALLPRODUCTS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(ALLPRODUCTS_nEOF), 1, 0, ".", "")));
            pr_default.close(3);
            wbEnd = 39;
            WB2K0( ) ;
         }
         bGXsfl_39_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2K2( )
      {
         GxWebStd.gx_hidden_field( context, "vNEWNAME", AV34newName);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV34newName, "")), context));
         GxWebStd.gx_hidden_field( context, "vNEWCODE", AV35newCode);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV35newCode, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUCTID"+"_"+sGXsfl_39_idx, GetSecureSignedToken( sGXsfl_39_idx, context.localUtil.Format( (decimal)(A15ProductId), "ZZZZZ9"), context));
      }

      protected void RF2K3( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            RetailfgridContainer.ClearRows();
         }
         wbStart = 97;
         E162K2 ();
         nGXsfl_97_idx = 1;
         sGXsfl_97_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_97_idx), 4, 0), 4, "0");
         SubsflControlProps_973( ) ;
         bGXsfl_97_Refreshing = true;
         RetailfgridContainer.AddObjectProperty("GridName", "Retailfgrid");
         RetailfgridContainer.AddObjectProperty("CmpContext", "");
         RetailfgridContainer.AddObjectProperty("InMasterPage", "false");
         RetailfgridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         RetailfgridContainer.AddObjectProperty("Class", "FreeStyleGrid");
         RetailfgridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         RetailfgridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         RetailfgridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subRetailfgrid_Backcolorstyle), 1, 0, ".", "")));
         RetailfgridContainer.PageSize = subRetailfgrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_973( ) ;
            E192K3 ();
            wbEnd = 97;
            WB2K0( ) ;
         }
         bGXsfl_97_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2K3( )
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
                                              AV9Code ,
                                              AV16Name ,
                                              AV23Supplier ,
                                              AV8Brand ,
                                              AV22Sector ,
                                              A55ProductCode ,
                                              A16ProductName ,
                                              A4SupplierId ,
                                              A1BrandId ,
                                              A9SectorId } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV9Code = StringUtil.Concat( StringUtil.RTrim( AV9Code), "%", "");
         lV16Name = StringUtil.Concat( StringUtil.RTrim( AV16Name), "%", "");
         /* Using cursor H002K6 */
         pr_default.execute(4, new Object[] {lV9Code, lV16Name, AV23Supplier, AV8Brand, AV22Sector});
         ALLPRODUCTS_nRecordCount = H002K6_AALLPRODUCTS_nRecordCount[0];
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
            gxgrAllproducts_refresh( subAllproducts_Rows, AV9Code, AV16Name, AV23Supplier, AV8Brand, AV22Sector, AV34newName, AV35newCode) ;
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
            gxgrAllproducts_refresh( subAllproducts_Rows, AV9Code, AV16Name, AV23Supplier, AV8Brand, AV22Sector, AV34newName, AV35newCode) ;
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
            gxgrAllproducts_refresh( subAllproducts_Rows, AV9Code, AV16Name, AV23Supplier, AV8Brand, AV22Sector, AV34newName, AV35newCode) ;
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
            gxgrAllproducts_refresh( subAllproducts_Rows, AV9Code, AV16Name, AV23Supplier, AV8Brand, AV22Sector, AV34newName, AV35newCode) ;
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
            gxgrAllproducts_refresh( subAllproducts_Rows, AV9Code, AV16Name, AV23Supplier, AV8Brand, AV22Sector, AV34newName, AV35newCode) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected int subRetailfgrid_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subRetailfgrid_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subRetailfgrid_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subRetailfgrid_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavCtlcode1_Enabled = 0;
         AssignProp("", false, edtavCtlcode1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcode1_Enabled), 5, 0), !bGXsfl_97_Refreshing);
         edtavCtlname1_Enabled = 0;
         AssignProp("", false, edtavCtlname1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname1_Enabled), 5, 0), !bGXsfl_97_Refreshing);
         edtavCtlsupplier1_Enabled = 0;
         AssignProp("", false, edtavCtlsupplier1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsupplier1_Enabled), 5, 0), !bGXsfl_97_Refreshing);
         edtavCtlbrand1_Enabled = 0;
         AssignProp("", false, edtavCtlbrand1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlbrand1_Enabled), 5, 0), !bGXsfl_97_Refreshing);
         edtavCtlsector1_Enabled = 0;
         AssignProp("", false, edtavCtlsector1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsector1_Enabled), 5, 0), !bGXsfl_97_Refreshing);
         edtavCtlcostprice1_Enabled = 0;
         AssignProp("", false, edtavCtlcostprice1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcostprice1_Enabled), 5, 0), !bGXsfl_97_Refreshing);
         edtavCtlretailprofit1_Enabled = 0;
         AssignProp("", false, edtavCtlretailprofit1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlretailprofit1_Enabled), 5, 0), !bGXsfl_97_Refreshing);
         GXVvSUPPLIER_html2K2( ) ;
         GXVvBRAND_html2K2( ) ;
         GXVvSECTOR_html2K2( ) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2K0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E202K2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Productsselected"), AV19ProductsSelected);
            /* Read saved values. */
            nRC_GXsfl_39 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_39"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_97 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_97"), ".", ","), 18, MidpointRounding.ToEven));
            ALLPRODUCTS_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "ALLPRODUCTS_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            ALLPRODUCTS_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "ALLPRODUCTS_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            subAllproducts_Collapsed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "ALLPRODUCTS_Collapsed"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_97 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_97"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_97_fel_idx = 0;
            while ( nGXsfl_97_fel_idx < nRC_GXsfl_97 )
            {
               nGXsfl_97_fel_idx = ((subRetailfgrid_Islastpage==1)&&(nGXsfl_97_fel_idx+1>subRetailfgrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_97_fel_idx+1);
               sGXsfl_97_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_97_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_973( ) ;
               AV42GXV1 = nGXsfl_97_fel_idx;
               if ( ( AV19ProductsSelected.Count >= AV42GXV1 ) && ( AV42GXV1 > 0 ) )
               {
                  AV19ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV42GXV1));
                  AV39RemoveProduct = cgiGet( edtavRemoveproduct_Internalname);
               }
            }
            if ( nGXsfl_97_fel_idx == 0 )
            {
               nGXsfl_97_idx = 1;
               sGXsfl_97_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_97_idx), 4, 0), 4, "0");
               SubsflControlProps_973( ) ;
            }
            nGXsfl_97_fel_idx = 1;
            /* Read variables values. */
            AV9Code = cgiGet( edtavCode_Internalname);
            AssignAttri("", false, "AV9Code", AV9Code);
            AV16Name = cgiGet( edtavName_Internalname);
            AssignAttri("", false, "AV16Name", AV16Name);
            dynavSupplier.Name = dynavSupplier_Internalname;
            dynavSupplier.CurrentValue = cgiGet( dynavSupplier_Internalname);
            AV23Supplier = (int)(Math.Round(NumberUtil.Val( cgiGet( dynavSupplier_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV23Supplier", StringUtil.LTrimStr( (decimal)(AV23Supplier), 6, 0));
            dynavBrand.Name = dynavBrand_Internalname;
            dynavBrand.CurrentValue = cgiGet( dynavBrand_Internalname);
            AV8Brand = (int)(Math.Round(NumberUtil.Val( cgiGet( dynavBrand_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV8Brand", StringUtil.LTrimStr( (decimal)(AV8Brand), 6, 0));
            dynavSector.Name = dynavSector_Internalname;
            dynavSector.CurrentValue = cgiGet( dynavSector_Internalname);
            AV22Sector = (int)(Math.Round(NumberUtil.Val( cgiGet( dynavSector_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV22Sector", StringUtil.LTrimStr( (decimal)(AV22Sector), 6, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavNewretailprofit_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavNewretailprofit_Internalname), ".", ",") > 9999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vNEWRETAILPROFIT");
               GX_FocusControl = edtavNewretailprofit_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV36NewRetailProfit = 0;
               AssignAttri("", false, "AV36NewRetailProfit", StringUtil.LTrimStr( AV36NewRetailProfit, 7, 2));
            }
            else
            {
               AV36NewRetailProfit = context.localUtil.CToN( cgiGet( edtavNewretailprofit_Internalname), ".", ",");
               AssignAttri("", false, "AV36NewRetailProfit", StringUtil.LTrimStr( AV36NewRetailProfit, 7, 2));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCODE"), AV9Code) != 0 )
            {
               ALLPRODUCTS_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vNAME"), AV16Name) != 0 )
            {
               ALLPRODUCTS_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vSUPPLIER"), ".", ",") != Convert.ToDecimal( AV23Supplier )) )
            {
               ALLPRODUCTS_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vBRAND"), ".", ",") != Convert.ToDecimal( AV8Brand )) )
            {
               ALLPRODUCTS_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vSECTOR"), ".", ",") != Convert.ToDecimal( AV22Sector )) )
            {
               ALLPRODUCTS_nFirstRecordOnPage = 0;
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
         E202K2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E202K2( )
      {
         /* Start Routine */
         returnInSub = false;
         new getcontext(context ).execute( out  AV37Context, ref  AV7AllOk) ;
         AssignAttri("", false, "AV7AllOk", AV7AllOk);
         if ( ! AV7AllOk )
         {
            AV38WebSession.Set("SecLogIn", "Error");
            CallWebObject(formatLink("wplogin.aspx") );
            context.wjLocDisableFrm = 1;
         }
         divRetailprofittable_Visible = 0;
         AssignProp("", false, divRetailprofittable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divRetailprofittable_Visible), 5, 0), true);
         divButtonstable_Visible = 0;
         AssignProp("", false, divButtonstable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divButtonstable_Visible), 5, 0), true);
         bttUpdate_Jsonclick = "confirm('Are you sure to update Cost Price?')";
         AssignProp("", false, bttUpdate_Internalname, "Jsonclick", bttUpdate_Jsonclick, true);
         bttCancel_Jsonclick = "confirm('Are you sure to cancel the update?')";
         AssignProp("", false, bttCancel_Internalname, "Jsonclick", bttCancel_Jsonclick, true);
      }

      protected void E212K2( )
      {
         AV42GXV1 = nGXsfl_97_idx;
         if ( ( AV42GXV1 > 0 ) && ( AV19ProductsSelected.Count >= AV42GXV1 ) )
         {
            AV19ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV42GXV1));
         }
         /* ProductName_Click Routine */
         returnInSub = false;
         if ( AV14IdsSelected.Count == 0 )
         {
            divRetailprofittable_Visible = 1;
            AssignProp("", false, divRetailprofittable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divRetailprofittable_Visible), 5, 0), true);
            divButtonstable_Visible = 1;
            AssignProp("", false, divButtonstable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divButtonstable_Visible), 5, 0), true);
         }
         AV31IdSelected = A15ProductId;
         AssignAttri("", false, "AV31IdSelected", StringUtil.LTrimStr( (decimal)(AV31IdSelected), 6, 0));
         /* Execute user subroutine: 'IDINSELECTED' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( ! AV30IsIn )
         {
            AV17OneProduct = new SdtSDTProductsSelected_SDTProductsSelectedItem(context);
            GXt_SdtSDTProductsSelected_SDTProductsSelectedItem4 = AV17OneProduct;
            new updateloadoneproduct(context ).execute(  A15ProductId, out  GXt_SdtSDTProductsSelected_SDTProductsSelectedItem4) ;
            AV17OneProduct = GXt_SdtSDTProductsSelected_SDTProductsSelectedItem4;
            if ( ( AV36NewRetailProfit > Convert.ToDecimal( 0 )) )
            {
               /* Execute user subroutine: 'CALCULATEPRICEONE' */
               S122 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
            }
            AV20ProductsSelectedAux.Add(AV17OneProduct, 0);
            AV15IdsSelectedAux.Add(AV17OneProduct.gxTpr_Id, 0);
            AV17OneProduct = new SdtSDTProductsSelected_SDTProductsSelectedItem(context);
            AV52GXV11 = 1;
            while ( AV52GXV11 <= AV19ProductsSelected.Count )
            {
               AV17OneProduct = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV52GXV11));
               AV20ProductsSelectedAux.Add(AV17OneProduct, 0);
               AV15IdsSelectedAux.Add(AV17OneProduct.gxTpr_Id, 0);
               AV52GXV11 = (int)(AV52GXV11+1);
            }
            AV19ProductsSelected.Clear();
            gx_BV97 = true;
            AV14IdsSelected.Clear();
            AV19ProductsSelected = (GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem>)(AV20ProductsSelectedAux.Clone());
            gx_BV97 = true;
            AV14IdsSelected = (GxSimpleCollection<int>)(AV15IdsSelectedAux.Clone());
            AV20ProductsSelectedAux.Clear();
            AV15IdsSelectedAux.Clear();
            gxgrRetailfgrid_refresh( subAllproducts_Rows, AV9Code, AV16Name, AV23Supplier, AV8Brand, AV22Sector, AV34newName, AV35newCode) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17OneProduct", AV17OneProduct);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20ProductsSelectedAux", AV20ProductsSelectedAux);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15IdsSelectedAux", AV15IdsSelectedAux);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19ProductsSelected", AV19ProductsSelected);
         nGXsfl_97_bak_idx = nGXsfl_97_idx;
         gxgrRetailfgrid_refresh( subAllproducts_Rows, AV9Code, AV16Name, AV23Supplier, AV8Brand, AV22Sector, AV34newName, AV35newCode) ;
         nGXsfl_97_idx = nGXsfl_97_bak_idx;
         sGXsfl_97_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_97_idx), 4, 0), 4, "0");
         SubsflControlProps_973( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14IdsSelected", AV14IdsSelected);
      }

      protected void E112K2( )
      {
         AV42GXV1 = nGXsfl_97_idx;
         if ( ( AV42GXV1 > 0 ) && ( AV19ProductsSelected.Count >= AV42GXV1 ) )
         {
            AV19ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV42GXV1));
         }
         /* Newretailprofit_Controlvaluechanged Routine */
         returnInSub = false;
         if ( ( AV36NewRetailProfit >= Convert.ToDecimal( 0 )) && ( AV36NewRetailProfit <= Convert.ToDecimal( 999 )) )
         {
            AV53GXV12 = 1;
            while ( AV53GXV12 <= AV19ProductsSelected.Count )
            {
               AV17OneProduct = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV53GXV12));
               AV17OneProduct.gxTpr_Newretailprofit = AV36NewRetailProfit;
               GXt_decimal3 = 0;
               new roundvalue(context ).execute(  AV17OneProduct.gxTpr_Costprice*(1+AV17OneProduct.gxTpr_Newretailprofit/ (decimal)(100)), out  GXt_decimal3) ;
               AV17OneProduct.gxTpr_Retailprice = GXt_decimal3;
               AV53GXV12 = (int)(AV53GXV12+1);
            }
         }
         else
         {
            GX_msglist.addItem("New R. Profit invalid");
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17OneProduct", AV17OneProduct);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19ProductsSelected", AV19ProductsSelected);
         nGXsfl_97_bak_idx = nGXsfl_97_idx;
         gxgrRetailfgrid_refresh( subAllproducts_Rows, AV9Code, AV16Name, AV23Supplier, AV8Brand, AV22Sector, AV34newName, AV35newCode) ;
         nGXsfl_97_idx = nGXsfl_97_bak_idx;
         sGXsfl_97_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_97_idx), 4, 0), 4, "0");
         SubsflControlProps_973( ) ;
      }

      protected void E152K2( )
      {
         AV42GXV1 = nGXsfl_97_idx;
         if ( ( AV42GXV1 > 0 ) && ( AV19ProductsSelected.Count >= AV42GXV1 ) )
         {
            AV19ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV42GXV1));
         }
         /* Removeproduct_Click Routine */
         returnInSub = false;
         AV29Position = (short)(AV14IdsSelected.IndexOf(((SdtSDTProductsSelected_SDTProductsSelectedItem)(AV19ProductsSelected.CurrentItem)).gxTpr_Id));
         AV19ProductsSelected.RemoveItem(AV29Position);
         gx_BV97 = true;
         AV14IdsSelected.RemoveItem(AV29Position);
         gxgrRetailfgrid_refresh( subAllproducts_Rows, AV9Code, AV16Name, AV23Supplier, AV8Brand, AV22Sector, AV34newName, AV35newCode) ;
         if ( AV14IdsSelected.Count == 0 )
         {
            divRetailprofittable_Visible = 0;
            AssignProp("", false, divRetailprofittable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divRetailprofittable_Visible), 5, 0), true);
            divButtonstable_Visible = 0;
            AssignProp("", false, divButtonstable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divButtonstable_Visible), 5, 0), true);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19ProductsSelected", AV19ProductsSelected);
         nGXsfl_97_bak_idx = nGXsfl_97_idx;
         gxgrRetailfgrid_refresh( subAllproducts_Rows, AV9Code, AV16Name, AV23Supplier, AV8Brand, AV22Sector, AV34newName, AV35newCode) ;
         nGXsfl_97_idx = nGXsfl_97_bak_idx;
         sGXsfl_97_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_97_idx), 4, 0), 4, "0");
         SubsflControlProps_973( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14IdsSelected", AV14IdsSelected);
      }

      protected void E162K2( )
      {
         /* Retailfgrid_Refresh Routine */
         returnInSub = false;
         edtavRemoveproduct_gximage = "GeneXusUnanimo_delete_light";
         AssignProp("", false, edtavRemoveproduct_Internalname, "gximage", edtavRemoveproduct_gximage, !bGXsfl_97_Refreshing);
         AV39RemoveProduct = context.GetImagePath( "db0f63cd-dde8-4bf7-aca2-01cdf8d3c157", "", context.GetTheme( ));
         AssignProp("", false, edtavRemoveproduct_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV39RemoveProduct)) ? AV54Removeproduct_GXI : context.convertURL( context.PathToRelativeUrl( AV39RemoveProduct))), !bGXsfl_97_Refreshing);
         AssignProp("", false, edtavRemoveproduct_Internalname, "SrcSet", context.GetImageSrcSet( AV39RemoveProduct), true);
         AV54Removeproduct_GXI = GXDbFile.PathToUrl( context.GetImagePath( "db0f63cd-dde8-4bf7-aca2-01cdf8d3c157", "", context.GetTheme( )));
         AssignProp("", false, edtavRemoveproduct_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV39RemoveProduct)) ? AV54Removeproduct_GXI : context.convertURL( context.PathToRelativeUrl( AV39RemoveProduct))), !bGXsfl_97_Refreshing);
         AssignProp("", false, edtavRemoveproduct_Internalname, "SrcSet", context.GetImageSrcSet( AV39RemoveProduct), true);
         /*  Sending Event outputs  */
      }

      protected void E122K2( )
      {
         AV42GXV1 = nGXsfl_97_idx;
         if ( ( AV42GXV1 > 0 ) && ( AV19ProductsSelected.Count >= AV42GXV1 ) )
         {
            AV19ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV42GXV1));
         }
         /* 'Update' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'RPROFITCONTROL' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV7AllOk )
         {
            new productupdate(context ).execute(  AV19ProductsSelected, ref  AV32ErrorMessage, ref  AV7AllOk) ;
            AssignAttri("", false, "AV7AllOk", AV7AllOk);
            if ( AV7AllOk )
            {
               GX_msglist.addItem("Update succesfull");
               AV14IdsSelected.Clear();
               AV19ProductsSelected.Clear();
               gx_BV97 = true;
               gxgrAllproducts_refresh( subAllproducts_Rows, AV9Code, AV16Name, AV23Supplier, AV8Brand, AV22Sector, AV34newName, AV35newCode) ;
               divRetailprofittable_Visible = 0;
               AssignProp("", false, divRetailprofittable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divRetailprofittable_Visible), 5, 0), true);
               divButtonstable_Visible = 0;
               AssignProp("", false, divButtonstable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divButtonstable_Visible), 5, 0), true);
            }
            else
            {
               GX_msglist.addItem(AV32ErrorMessage.gxTpr_Description);
            }
         }
         else
         {
            GX_msglist.addItem(AV32ErrorMessage.gxTpr_Description);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32ErrorMessage", AV32ErrorMessage);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14IdsSelected", AV14IdsSelected);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19ProductsSelected", AV19ProductsSelected);
         nGXsfl_97_bak_idx = nGXsfl_97_idx;
         gxgrRetailfgrid_refresh( subAllproducts_Rows, AV9Code, AV16Name, AV23Supplier, AV8Brand, AV22Sector, AV34newName, AV35newCode) ;
         nGXsfl_97_idx = nGXsfl_97_bak_idx;
         sGXsfl_97_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_97_idx), 4, 0), 4, "0");
         SubsflControlProps_973( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17OneProduct", AV17OneProduct);
      }

      protected void E132K2( )
      {
         /* 'Cancel' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CLEARSELECTED' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14IdsSelected", AV14IdsSelected);
         if ( gx_BV97 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19ProductsSelected", AV19ProductsSelected);
            nGXsfl_97_bak_idx = nGXsfl_97_idx;
            gxgrRetailfgrid_refresh( subAllproducts_Rows, AV9Code, AV16Name, AV23Supplier, AV8Brand, AV22Sector, AV34newName, AV35newCode) ;
            nGXsfl_97_idx = nGXsfl_97_bak_idx;
            sGXsfl_97_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_97_idx), 4, 0), 4, "0");
            SubsflControlProps_973( ) ;
         }
      }

      protected void E172K2( )
      {
         AV42GXV1 = nGXsfl_97_idx;
         if ( ( AV42GXV1 > 0 ) && ( AV19ProductsSelected.Count >= AV42GXV1 ) )
         {
            AV19ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV42GXV1));
         }
         /* Ctlnewretailprofit_Controlvaluechanged Routine */
         returnInSub = false;
         AV17OneProduct = new SdtSDTProductsSelected_SDTProductsSelectedItem(context);
         AV17OneProduct = ((SdtSDTProductsSelected_SDTProductsSelectedItem)(AV19ProductsSelected.CurrentItem));
         if ( ( AV17OneProduct.gxTpr_Newretailprofit >= Convert.ToDecimal( 0 )) && ( AV17OneProduct.gxTpr_Newretailprofit <= Convert.ToDecimal( 999 )) )
         {
            AV17OneProduct.gxTpr_Retailprice = (decimal)(AV17OneProduct.gxTpr_Costprice*(1+AV17OneProduct.gxTpr_Newretailprofit/ (decimal)(100)));
            GXt_decimal3 = 0;
            new roundvalue(context ).execute(  AV17OneProduct.gxTpr_Retailprice, out  GXt_decimal3) ;
            ((SdtSDTProductsSelected_SDTProductsSelectedItem)(AV19ProductsSelected.CurrentItem)).gxTpr_Retailprice = GXt_decimal3;
         }
         else
         {
            AV17OneProduct.gxTpr_Newretailprofit = (decimal)(((AV17OneProduct.gxTpr_Retailprice/ (decimal)(AV17OneProduct.gxTpr_Costprice))-1)*100);
            ((SdtSDTProductsSelected_SDTProductsSelectedItem)(AV19ProductsSelected.CurrentItem)).gxTpr_Newretailprofit = AV17OneProduct.gxTpr_Newretailprofit;
            GX_msglist.addItem("New R. Profit invalid");
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17OneProduct", AV17OneProduct);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19ProductsSelected", AV19ProductsSelected);
         nGXsfl_97_bak_idx = nGXsfl_97_idx;
         gxgrRetailfgrid_refresh( subAllproducts_Rows, AV9Code, AV16Name, AV23Supplier, AV8Brand, AV22Sector, AV34newName, AV35newCode) ;
         nGXsfl_97_idx = nGXsfl_97_bak_idx;
         sGXsfl_97_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_97_idx), 4, 0), 4, "0");
         SubsflControlProps_973( ) ;
      }

      protected void E182K2( )
      {
         AV42GXV1 = nGXsfl_97_idx;
         if ( ( AV42GXV1 > 0 ) && ( AV19ProductsSelected.Count >= AV42GXV1 ) )
         {
            AV19ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV42GXV1));
         }
         /* Ctlretailprice_Controlvaluechanged Routine */
         returnInSub = false;
         AV17OneProduct = new SdtSDTProductsSelected_SDTProductsSelectedItem(context);
         AV17OneProduct = ((SdtSDTProductsSelected_SDTProductsSelectedItem)(AV19ProductsSelected.CurrentItem));
         if ( ( AV17OneProduct.gxTpr_Retailprice >= Convert.ToDecimal( 0 )) )
         {
            GXt_decimal3 = 0;
            new roundvalue(context ).execute(  AV17OneProduct.gxTpr_Retailprice, out  GXt_decimal3) ;
            AV17OneProduct.gxTpr_Retailprice = GXt_decimal3;
            AV17OneProduct.gxTpr_Newretailprofit = (decimal)(((AV17OneProduct.gxTpr_Retailprice/ (decimal)(AV17OneProduct.gxTpr_Costprice))-1)*100);
            ((SdtSDTProductsSelected_SDTProductsSelectedItem)(AV19ProductsSelected.CurrentItem)).gxTpr_Retailprice = AV17OneProduct.gxTpr_Retailprice;
            ((SdtSDTProductsSelected_SDTProductsSelectedItem)(AV19ProductsSelected.CurrentItem)).gxTpr_Newretailprofit = AV17OneProduct.gxTpr_Newretailprofit;
         }
         else
         {
            AV17OneProduct.gxTpr_Retailprice = (decimal)(AV17OneProduct.gxTpr_Costprice*(1+AV17OneProduct.gxTpr_Newretailprofit/ (decimal)(100)));
            GXt_decimal3 = 0;
            new roundvalue(context ).execute(  AV17OneProduct.gxTpr_Retailprice, out  GXt_decimal3) ;
            ((SdtSDTProductsSelected_SDTProductsSelectedItem)(AV19ProductsSelected.CurrentItem)).gxTpr_Retailprice = GXt_decimal3;
            GX_msglist.addItem("Price must be higher than zero");
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17OneProduct", AV17OneProduct);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19ProductsSelected", AV19ProductsSelected);
         nGXsfl_97_bak_idx = nGXsfl_97_idx;
         gxgrRetailfgrid_refresh( subAllproducts_Rows, AV9Code, AV16Name, AV23Supplier, AV8Brand, AV22Sector, AV34newName, AV35newCode) ;
         nGXsfl_97_idx = nGXsfl_97_bak_idx;
         sGXsfl_97_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_97_idx), 4, 0), 4, "0");
         SubsflControlProps_973( ) ;
      }

      protected void E142K2( )
      {
         AV42GXV1 = nGXsfl_97_idx;
         if ( ( AV42GXV1 > 0 ) && ( AV19ProductsSelected.Count >= AV42GXV1 ) )
         {
            AV19ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV42GXV1));
         }
         /* 'SelectAll' Routine */
         returnInSub = false;
         AV19ProductsSelected.Clear();
         gx_BV97 = true;
         GXt_objcol_SdtSDTProductsSelected_SDTProductsSelectedItem5 = AV19ProductsSelected;
         new updateselectall(context ).execute(  AV9Code, ref  AV16Name, ref  AV23Supplier, ref  AV8Brand, ref  AV22Sector, out  GXt_objcol_SdtSDTProductsSelected_SDTProductsSelectedItem5) ;
         AssignAttri("", false, "AV16Name", AV16Name);
         AssignAttri("", false, "AV23Supplier", StringUtil.LTrimStr( (decimal)(AV23Supplier), 6, 0));
         AssignAttri("", false, "AV8Brand", StringUtil.LTrimStr( (decimal)(AV8Brand), 6, 0));
         AssignAttri("", false, "AV22Sector", StringUtil.LTrimStr( (decimal)(AV22Sector), 6, 0));
         AV19ProductsSelected = GXt_objcol_SdtSDTProductsSelected_SDTProductsSelectedItem5;
         gx_BV97 = true;
         if ( ( AV36NewRetailProfit > Convert.ToDecimal( 0 )) )
         {
            /* Execute user subroutine: 'CALCULATEALL' */
            S152 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            gxgrRetailfgrid_refresh( subAllproducts_Rows, AV9Code, AV16Name, AV23Supplier, AV8Brand, AV22Sector, AV34newName, AV35newCode) ;
         }
         if ( AV19ProductsSelected.Count > 0 )
         {
            /* Execute user subroutine: 'REGISTERIDS' */
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            divRetailprofittable_Visible = 1;
            AssignProp("", false, divRetailprofittable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divRetailprofittable_Visible), 5, 0), true);
            divButtonstable_Visible = 1;
            AssignProp("", false, divButtonstable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divButtonstable_Visible), 5, 0), true);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19ProductsSelected", AV19ProductsSelected);
         nGXsfl_97_bak_idx = nGXsfl_97_idx;
         gxgrRetailfgrid_refresh( subAllproducts_Rows, AV9Code, AV16Name, AV23Supplier, AV8Brand, AV22Sector, AV34newName, AV35newCode) ;
         nGXsfl_97_idx = nGXsfl_97_bak_idx;
         sGXsfl_97_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_97_idx), 4, 0), 4, "0");
         SubsflControlProps_973( ) ;
         dynavSector.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22Sector), 6, 0));
         AssignProp("", false, dynavSector_Internalname, "Values", dynavSector.ToJavascriptSource(), true);
         dynavBrand.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV8Brand), 6, 0));
         AssignProp("", false, dynavBrand_Internalname, "Values", dynavBrand.ToJavascriptSource(), true);
         dynavSupplier.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23Supplier), 6, 0));
         AssignProp("", false, dynavSupplier_Internalname, "Values", dynavSupplier.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17OneProduct", AV17OneProduct);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14IdsSelected", AV14IdsSelected);
      }

      protected void S132( )
      {
         /* 'RPROFITCONTROL' Routine */
         returnInSub = false;
         AV32ErrorMessage.gxTpr_Description = "";
         if ( AV14IdsSelected.Count <= 0 )
         {
            AV7AllOk = false;
            AssignAttri("", false, "AV7AllOk", AV7AllOk);
            AV32ErrorMessage.gxTpr_Description = AV32ErrorMessage.gxTpr_Description+"Select at least one product ";
         }
         else if ( ( AV36NewRetailProfit < Convert.ToDecimal( 0 )) || ( AV36NewRetailProfit > Convert.ToDecimal( 999 )) )
         {
            AV7AllOk = false;
            AssignAttri("", false, "AV7AllOk", AV7AllOk);
            AV32ErrorMessage.gxTpr_Description = AV32ErrorMessage.gxTpr_Description+"Invalid Percentage ";
         }
         else
         {
            AV7AllOk = true;
            AssignAttri("", false, "AV7AllOk", AV7AllOk);
         }
         /* Execute user subroutine: 'NEWRPROFITCONTROL' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S122( )
      {
         /* 'CALCULATEPRICEONE' Routine */
         returnInSub = false;
         if ( ( AV36NewRetailProfit >= Convert.ToDecimal( 0 )) && ( AV36NewRetailProfit <= Convert.ToDecimal( 999 )) )
         {
            AV17OneProduct.gxTpr_Newretailprofit = AV36NewRetailProfit;
            GXt_decimal3 = 0;
            new roundvalue(context ).execute(  AV17OneProduct.gxTpr_Costprice*(1+AV36NewRetailProfit/ (decimal)(100)), out  GXt_decimal3) ;
            AV17OneProduct.gxTpr_Retailprice = GXt_decimal3;
         }
      }

      protected void S112( )
      {
         /* 'IDINSELECTED' Routine */
         returnInSub = false;
         if ( AV14IdsSelected.IndexOf(AV31IdSelected) > 0 )
         {
            AV30IsIn = true;
            AssignAttri("", false, "AV30IsIn", AV30IsIn);
         }
         else
         {
            AV30IsIn = false;
            AssignAttri("", false, "AV30IsIn", AV30IsIn);
         }
      }

      protected void S172( )
      {
         /* 'NEWRPROFITCONTROL' Routine */
         returnInSub = false;
         AV55GXV13 = 1;
         while ( AV55GXV13 <= AV19ProductsSelected.Count )
         {
            AV17OneProduct = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV55GXV13));
            if ( ( AV17OneProduct.gxTpr_Newretailprofit < Convert.ToDecimal( 0 )) || ( AV17OneProduct.gxTpr_Newretailprofit > Convert.ToDecimal( 999 )) )
            {
               AV32ErrorMessage.gxTpr_Description = AV32ErrorMessage.gxTpr_Description+"Some new profit is invalid";
               AV7AllOk = false;
               AssignAttri("", false, "AV7AllOk", AV7AllOk);
               if (true) break;
            }
            AV55GXV13 = (int)(AV55GXV13+1);
         }
      }

      protected void S142( )
      {
         /* 'CLEARSELECTED' Routine */
         returnInSub = false;
         AV14IdsSelected.Clear();
         AV19ProductsSelected.Clear();
         gx_BV97 = true;
         divRetailprofittable_Visible = 0;
         AssignProp("", false, divRetailprofittable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divRetailprofittable_Visible), 5, 0), true);
         divButtonstable_Visible = 0;
         AssignProp("", false, divButtonstable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divButtonstable_Visible), 5, 0), true);
      }

      protected void S152( )
      {
         /* 'CALCULATEALL' Routine */
         returnInSub = false;
         AV56GXV14 = 1;
         while ( AV56GXV14 <= AV19ProductsSelected.Count )
         {
            AV17OneProduct = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV56GXV14));
            AV17OneProduct.gxTpr_Newretailprofit = AV36NewRetailProfit;
            GXt_decimal3 = 0;
            new roundvalue(context ).execute(  AV17OneProduct.gxTpr_Costprice*(1+AV36NewRetailProfit/ (decimal)(100)), out  GXt_decimal3) ;
            AV17OneProduct.gxTpr_Retailprice = GXt_decimal3;
            AV56GXV14 = (int)(AV56GXV14+1);
         }
      }

      protected void S162( )
      {
         /* 'REGISTERIDS' Routine */
         returnInSub = false;
         AV14IdsSelected.Clear();
         AV57GXV15 = 1;
         while ( AV57GXV15 <= AV19ProductsSelected.Count )
         {
            AV17OneProduct = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV57GXV15));
            AV14IdsSelected.Add(AV17OneProduct.gxTpr_Id, 0);
            AV57GXV15 = (int)(AV57GXV15+1);
         }
      }

      private void E222K2( )
      {
         /* Allproducts_Load Routine */
         returnInSub = false;
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 39;
         }
         sendrow_392( ) ;
         ALLPRODUCTS_nCurrentRecord = (long)(ALLPRODUCTS_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_39_Refreshing )
         {
            DoAjaxLoad(39, AllproductsRow);
         }
      }

      private void E192K3( )
      {
         /* Retailfgrid_Load Routine */
         returnInSub = false;
         AV42GXV1 = 1;
         while ( AV42GXV1 <= AV19ProductsSelected.Count )
         {
            AV19ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV42GXV1));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 97;
            }
            sendrow_973( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_97_Refreshing )
            {
               DoAjaxLoad(97, RetailfgridRow);
            }
            AV42GXV1 = (int)(AV42GXV1+1);
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
         PA2K2( ) ;
         WS2K2( ) ;
         WE2K2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20241232523253", true, true);
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
         context.AddJavascriptSource("wpupdateretailprofit.js", "?20241232523253", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_392( )
      {
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_39_idx;
         edtProductCode_Internalname = "PRODUCTCODE_"+sGXsfl_39_idx;
         edtProductName_Internalname = "PRODUCTNAME_"+sGXsfl_39_idx;
         edtSupplierName_Internalname = "SUPPLIERNAME_"+sGXsfl_39_idx;
         edtBrandName_Internalname = "BRANDNAME_"+sGXsfl_39_idx;
         edtSectorName_Internalname = "SECTORNAME_"+sGXsfl_39_idx;
         edtProductCostPrice_Internalname = "PRODUCTCOSTPRICE_"+sGXsfl_39_idx;
         edtProductRetailProfit_Internalname = "PRODUCTRETAILPROFIT_"+sGXsfl_39_idx;
         edtProductRetailPrice_Internalname = "PRODUCTRETAILPRICE_"+sGXsfl_39_idx;
      }

      protected void SubsflControlProps_fel_392( )
      {
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_39_fel_idx;
         edtProductCode_Internalname = "PRODUCTCODE_"+sGXsfl_39_fel_idx;
         edtProductName_Internalname = "PRODUCTNAME_"+sGXsfl_39_fel_idx;
         edtSupplierName_Internalname = "SUPPLIERNAME_"+sGXsfl_39_fel_idx;
         edtBrandName_Internalname = "BRANDNAME_"+sGXsfl_39_fel_idx;
         edtSectorName_Internalname = "SECTORNAME_"+sGXsfl_39_fel_idx;
         edtProductCostPrice_Internalname = "PRODUCTCOSTPRICE_"+sGXsfl_39_fel_idx;
         edtProductRetailProfit_Internalname = "PRODUCTRETAILPROFIT_"+sGXsfl_39_fel_idx;
         edtProductRetailPrice_Internalname = "PRODUCTRETAILPRICE_"+sGXsfl_39_fel_idx;
      }

      protected void sendrow_392( )
      {
         SubsflControlProps_392( ) ;
         WB2K0( ) ;
         if ( ( 5 * 1 == 0 ) || ( nGXsfl_39_idx <= subAllproducts_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_39_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_39_idx+"\">") ;
            }
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A15ProductId), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductCode_Internalname,(string)A55ProductCode,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductCode_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusUnanimo\\Code",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductName_Internalname,(string)A16ProductName,(string)"",(string)"","'"+""+"'"+",false,"+"'"+"EPRODUCTNAME.CLICK."+sGXsfl_39_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductName_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierName_Internalname,(string)A5SupplierName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtBrandName_Internalname,(string)A2BrandName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtBrandName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSectorName_Internalname,(string)A10SectorName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSectorName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductCostPrice_Internalname,StringUtil.LTrim( StringUtil.NToC( A85ProductCostPrice, 18, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A85ProductCostPrice, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductCostPrice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"Price",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductRetailProfit_Internalname,StringUtil.LTrim( StringUtil.NToC( A89ProductRetailProfit, 8, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A89ProductRetailProfit, "ZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductRetailProfit_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"Percentage",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductRetailPrice_Internalname,StringUtil.LTrim( StringUtil.NToC( A90ProductRetailPrice, 18, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A90ProductRetailPrice, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductRetailPrice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"Price",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes2K2( ) ;
            AllproductsContainer.AddRow(AllproductsRow);
            nGXsfl_39_idx = ((subAllproducts_Islastpage==1)&&(nGXsfl_39_idx+1>subAllproducts_fnc_Recordsperpage( )) ? 1 : nGXsfl_39_idx+1);
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
         }
         /* End function sendrow_392 */
      }

      protected void SubsflControlProps_973( )
      {
         edtavRemoveproduct_Internalname = "vREMOVEPRODUCT_"+sGXsfl_97_idx;
         edtavCtlcode1_Internalname = "CTLCODE1_"+sGXsfl_97_idx;
         edtavCtlname1_Internalname = "CTLNAME1_"+sGXsfl_97_idx;
         edtavCtlsupplier1_Internalname = "CTLSUPPLIER1_"+sGXsfl_97_idx;
         edtavCtlbrand1_Internalname = "CTLBRAND1_"+sGXsfl_97_idx;
         edtavCtlsector1_Internalname = "CTLSECTOR1_"+sGXsfl_97_idx;
         edtavCtlcostprice1_Internalname = "CTLCOSTPRICE1_"+sGXsfl_97_idx;
         edtavCtlretailprofit1_Internalname = "CTLRETAILPROFIT1_"+sGXsfl_97_idx;
         edtavCtlnewretailprofit_Internalname = "CTLNEWRETAILPROFIT_"+sGXsfl_97_idx;
         edtavCtlretailprice_Internalname = "CTLRETAILPRICE_"+sGXsfl_97_idx;
      }

      protected void SubsflControlProps_fel_973( )
      {
         edtavRemoveproduct_Internalname = "vREMOVEPRODUCT_"+sGXsfl_97_fel_idx;
         edtavCtlcode1_Internalname = "CTLCODE1_"+sGXsfl_97_fel_idx;
         edtavCtlname1_Internalname = "CTLNAME1_"+sGXsfl_97_fel_idx;
         edtavCtlsupplier1_Internalname = "CTLSUPPLIER1_"+sGXsfl_97_fel_idx;
         edtavCtlbrand1_Internalname = "CTLBRAND1_"+sGXsfl_97_fel_idx;
         edtavCtlsector1_Internalname = "CTLSECTOR1_"+sGXsfl_97_fel_idx;
         edtavCtlcostprice1_Internalname = "CTLCOSTPRICE1_"+sGXsfl_97_fel_idx;
         edtavCtlretailprofit1_Internalname = "CTLRETAILPROFIT1_"+sGXsfl_97_fel_idx;
         edtavCtlnewretailprofit_Internalname = "CTLNEWRETAILPROFIT_"+sGXsfl_97_fel_idx;
         edtavCtlretailprice_Internalname = "CTLRETAILPRICE_"+sGXsfl_97_fel_idx;
      }

      protected void sendrow_973( )
      {
         SubsflControlProps_973( ) ;
         WB2K0( ) ;
         RetailfgridRow = GXWebRow.GetNew(context,RetailfgridContainer);
         if ( subRetailfgrid_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subRetailfgrid_Backstyle = 0;
            if ( StringUtil.StrCmp(subRetailfgrid_Class, "") != 0 )
            {
               subRetailfgrid_Linesclass = subRetailfgrid_Class+"Odd";
            }
         }
         else if ( subRetailfgrid_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subRetailfgrid_Backstyle = 0;
            subRetailfgrid_Backcolor = subRetailfgrid_Allbackcolor;
            if ( StringUtil.StrCmp(subRetailfgrid_Class, "") != 0 )
            {
               subRetailfgrid_Linesclass = subRetailfgrid_Class+"Uniform";
            }
         }
         else if ( subRetailfgrid_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subRetailfgrid_Backstyle = 1;
            if ( StringUtil.StrCmp(subRetailfgrid_Class, "") != 0 )
            {
               subRetailfgrid_Linesclass = subRetailfgrid_Class+"Odd";
            }
            subRetailfgrid_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subRetailfgrid_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subRetailfgrid_Backstyle = 1;
            if ( ((int)((nGXsfl_97_idx) % (2))) == 0 )
            {
               subRetailfgrid_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subRetailfgrid_Class, "") != 0 )
               {
                  subRetailfgrid_Linesclass = subRetailfgrid_Class+"Even";
               }
            }
            else
            {
               subRetailfgrid_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subRetailfgrid_Class, "") != 0 )
               {
                  subRetailfgrid_Linesclass = subRetailfgrid_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( RetailfgridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subRetailfgrid_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_97_idx+"\">") ;
         }
         /* Div Control */
         RetailfgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divGrid1table1_Internalname+"_"+sGXsfl_97_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         RetailfgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         RetailfgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         RetailfgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavRemoveproduct_Enabled!=0)&&(edtavRemoveproduct_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 102,'',false,'',97)\"" : " ");
         ClassString = "Image" + " " + ((StringUtil.StrCmp(edtavRemoveproduct_gximage, "")==0) ? "" : "GX_Image_"+edtavRemoveproduct_gximage+"_Class");
         StyleString = "";
         AV39RemoveProduct_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV39RemoveProduct))&&String.IsNullOrEmpty(StringUtil.RTrim( AV54Removeproduct_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV39RemoveProduct)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV39RemoveProduct)) ? AV54Removeproduct_GXI : context.PathToRelativeUrl( AV39RemoveProduct));
         RetailfgridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavRemoveproduct_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)1,(short)1,(string)"",(string)"",(short)0,(short)1,(short)1,(string)"chr",(short)0,(string)"row",(short)0,(short)0,(short)5,(string)edtavRemoveproduct_Jsonclick,"'"+""+"'"+",false,"+"'"+"EVREMOVEPRODUCT.CLICK."+sGXsfl_97_idx+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV39RemoveProduct_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         RetailfgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         RetailfgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         RetailfgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         RetailfgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         RetailfgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcode1_Internalname,(string)"Code",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         RetailfgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcode1_Internalname,((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV42GXV1)).gxTpr_Code,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcode1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlcode1_Enabled,(short)0,(string)"text",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)100,(short)0,(short)0,(short)97,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         RetailfgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         RetailfgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         RetailfgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         RetailfgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         RetailfgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname1_Internalname,(string)"Name",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         RetailfgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname1_Internalname,((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV42GXV1)).gxTpr_Name,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlname1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlname1_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)97,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         RetailfgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         RetailfgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         RetailfgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         RetailfgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         RetailfgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsupplier1_Internalname,(string)"Supplier",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         RetailfgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsupplier1_Internalname,((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV42GXV1)).gxTpr_Supplier,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlsupplier1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlsupplier1_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)97,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         RetailfgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         RetailfgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         RetailfgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         RetailfgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         RetailfgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlbrand1_Internalname,(string)"Brand",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         RetailfgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlbrand1_Internalname,((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV42GXV1)).gxTpr_Brand,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlbrand1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlbrand1_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)97,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         RetailfgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         RetailfgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         RetailfgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         RetailfgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         RetailfgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsector1_Internalname,(string)"Sector",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         RetailfgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsector1_Internalname,((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV42GXV1)).gxTpr_Sector,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlsector1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlsector1_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)97,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         RetailfgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         RetailfgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         RetailfgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         RetailfgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         RetailfgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcostprice1_Internalname,(string)"Cost Price",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         RetailfgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcostprice1_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV42GXV1)).gxTpr_Costprice, 18, 2, ".", "")),StringUtil.LTrim( ((edtavCtlcostprice1_Enabled!=0) ? context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV42GXV1)).gxTpr_Costprice, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV42GXV1)).gxTpr_Costprice, "ZZZZZZZZZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcostprice1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlcostprice1_Enabled,(short)0,(string)"text",(string)"",(short)18,(string)"chr",(short)1,(string)"row",(short)18,(short)0,(short)0,(short)97,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         RetailfgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         RetailfgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         RetailfgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         RetailfgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         RetailfgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlretailprofit1_Internalname,"R. Profit",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         RetailfgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlretailprofit1_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV42GXV1)).gxTpr_Retailprofit, 7, 2, ".", "")),StringUtil.LTrim( ((edtavCtlretailprofit1_Enabled!=0) ? context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV42GXV1)).gxTpr_Retailprofit, "ZZZ9.99") : context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV42GXV1)).gxTpr_Retailprofit, "ZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlretailprofit1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlretailprofit1_Enabled,(short)0,(string)"text",(string)"",(short)7,(string)"chr",(short)1,(string)"row",(short)7,(short)0,(short)0,(short)97,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         RetailfgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         RetailfgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         RetailfgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         RetailfgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         RetailfgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlnewretailprofit_Internalname,"New R. Profit",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         TempTags = " " + ((edtavCtlnewretailprofit_Enabled!=0)&&(edtavCtlnewretailprofit_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 126,'',false,'"+sGXsfl_97_idx+"',97)\"" : " ");
         ROClassString = "Attribute";
         RetailfgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlnewretailprofit_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV42GXV1)).gxTpr_Newretailprofit, 7, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV42GXV1)).gxTpr_Newretailprofit, "ZZZ9.99")),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+((edtavCtlnewretailprofit_Enabled!=0)&&(edtavCtlnewretailprofit_Visible!=0) ? " onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,126);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlnewretailprofit_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)1,(short)0,(string)"text",(string)"",(short)7,(string)"chr",(short)1,(string)"row",(short)7,(short)0,(short)0,(short)97,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         RetailfgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         RetailfgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         RetailfgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         RetailfgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         sendrow_97330( ) ;
      }

      protected void sendrow_97330( )
      {
         /* Attribute/Variable Label */
         RetailfgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlretailprice_Internalname,"R. Price",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         TempTags = " " + ((edtavCtlretailprice_Enabled!=0)&&(edtavCtlretailprice_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 129,'',false,'"+sGXsfl_97_idx+"',97)\"" : " ");
         ROClassString = "Attribute";
         RetailfgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlretailprice_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV42GXV1)).gxTpr_Retailprice, 18, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV42GXV1)).gxTpr_Retailprice, "ZZZZZZZZZZZZZZ9.99")),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+((edtavCtlretailprice_Enabled!=0)&&(edtavCtlretailprice_Visible!=0) ? " onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,129);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlretailprice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)1,(short)0,(string)"text",(string)"",(short)18,(string)"chr",(short)1,(string)"row",(short)18,(short)0,(short)0,(short)97,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         RetailfgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         RetailfgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         RetailfgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         RetailfgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         send_integrity_lvl_hashes2K3( ) ;
         /* End of Columns property logic. */
         RetailfgridContainer.AddRow(RetailfgridRow);
         nGXsfl_97_idx = ((subRetailfgrid_Islastpage==1)&&(nGXsfl_97_idx+1>subRetailfgrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_97_idx+1);
         sGXsfl_97_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_97_idx), 4, 0), 4, "0");
         SubsflControlProps_973( ) ;
         /* End function sendrow_973 */
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

      protected void StartGridControl39( )
      {
         if ( AllproductsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"AllproductsContainer"+"DivS\" data-gxgridid=\"39\">") ;
            sStyleString = "";
            if ( subAllproducts_Collapsed != 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, subAllproducts_Internalname, subAllproducts_Internalname, "", "PromptGrid", 0, "", "", 1, 1, sStyleString, "", "", 0);
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
            context.SendWebValue( "Code") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Product") ;
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
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "U. Cost Price") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "R. Profit") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "R.Price") ;
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
            AllproductsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            AllproductsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAllproducts_Backcolorstyle), 1, 0, ".", "")));
            AllproductsContainer.AddObjectProperty("CmpContext", "");
            AllproductsContainer.AddObjectProperty("InMasterPage", "false");
            AllproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", ""))));
            AllproductsContainer.AddColumnProperties(AllproductsColumn);
            AllproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A55ProductCode));
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
            AllproductsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A85ProductCostPrice, 18, 2, ".", ""))));
            AllproductsContainer.AddColumnProperties(AllproductsColumn);
            AllproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A89ProductRetailProfit, 8, 2, ".", ""))));
            AllproductsContainer.AddColumnProperties(AllproductsColumn);
            AllproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A90ProductRetailPrice, 18, 2, ".", ""))));
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

      protected void StartGridControl97( )
      {
         if ( RetailfgridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"RetailfgridContainer"+"DivS\" data-gxgridid=\"97\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subRetailfgrid_Internalname, subRetailfgrid_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            RetailfgridContainer.AddObjectProperty("GridName", "Retailfgrid");
         }
         else
         {
            RetailfgridContainer.AddObjectProperty("GridName", "Retailfgrid");
            RetailfgridContainer.AddObjectProperty("Header", subRetailfgrid_Header);
            RetailfgridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            RetailfgridContainer.AddObjectProperty("Class", "FreeStyleGrid");
            RetailfgridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            RetailfgridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            RetailfgridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subRetailfgrid_Backcolorstyle), 1, 0, ".", "")));
            RetailfgridContainer.AddObjectProperty("CmpContext", "");
            RetailfgridContainer.AddObjectProperty("InMasterPage", "false");
            RetailfgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            RetailfgridContainer.AddColumnProperties(RetailfgridColumn);
            RetailfgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            RetailfgridContainer.AddColumnProperties(RetailfgridColumn);
            RetailfgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            RetailfgridContainer.AddColumnProperties(RetailfgridColumn);
            RetailfgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            RetailfgridContainer.AddColumnProperties(RetailfgridColumn);
            RetailfgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            RetailfgridColumn.AddObjectProperty("Value", context.convertURL( AV39RemoveProduct));
            RetailfgridContainer.AddColumnProperties(RetailfgridColumn);
            RetailfgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            RetailfgridContainer.AddColumnProperties(RetailfgridColumn);
            RetailfgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            RetailfgridContainer.AddColumnProperties(RetailfgridColumn);
            RetailfgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            RetailfgridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlcode1_Enabled), 5, 0, ".", "")));
            RetailfgridContainer.AddColumnProperties(RetailfgridColumn);
            RetailfgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            RetailfgridContainer.AddColumnProperties(RetailfgridColumn);
            RetailfgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            RetailfgridContainer.AddColumnProperties(RetailfgridColumn);
            RetailfgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            RetailfgridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlname1_Enabled), 5, 0, ".", "")));
            RetailfgridContainer.AddColumnProperties(RetailfgridColumn);
            RetailfgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            RetailfgridContainer.AddColumnProperties(RetailfgridColumn);
            RetailfgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            RetailfgridContainer.AddColumnProperties(RetailfgridColumn);
            RetailfgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            RetailfgridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlsupplier1_Enabled), 5, 0, ".", "")));
            RetailfgridContainer.AddColumnProperties(RetailfgridColumn);
            RetailfgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            RetailfgridContainer.AddColumnProperties(RetailfgridColumn);
            RetailfgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            RetailfgridContainer.AddColumnProperties(RetailfgridColumn);
            RetailfgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            RetailfgridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlbrand1_Enabled), 5, 0, ".", "")));
            RetailfgridContainer.AddColumnProperties(RetailfgridColumn);
            RetailfgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            RetailfgridContainer.AddColumnProperties(RetailfgridColumn);
            RetailfgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            RetailfgridContainer.AddColumnProperties(RetailfgridColumn);
            RetailfgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            RetailfgridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlsector1_Enabled), 5, 0, ".", "")));
            RetailfgridContainer.AddColumnProperties(RetailfgridColumn);
            RetailfgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            RetailfgridContainer.AddColumnProperties(RetailfgridColumn);
            RetailfgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            RetailfgridContainer.AddColumnProperties(RetailfgridColumn);
            RetailfgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            RetailfgridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlcostprice1_Enabled), 5, 0, ".", "")));
            RetailfgridContainer.AddColumnProperties(RetailfgridColumn);
            RetailfgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            RetailfgridContainer.AddColumnProperties(RetailfgridColumn);
            RetailfgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            RetailfgridContainer.AddColumnProperties(RetailfgridColumn);
            RetailfgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            RetailfgridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlretailprofit1_Enabled), 5, 0, ".", "")));
            RetailfgridContainer.AddColumnProperties(RetailfgridColumn);
            RetailfgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            RetailfgridContainer.AddColumnProperties(RetailfgridColumn);
            RetailfgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            RetailfgridContainer.AddColumnProperties(RetailfgridColumn);
            RetailfgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            RetailfgridContainer.AddColumnProperties(RetailfgridColumn);
            RetailfgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            RetailfgridContainer.AddColumnProperties(RetailfgridColumn);
            RetailfgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            RetailfgridContainer.AddColumnProperties(RetailfgridColumn);
            RetailfgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            RetailfgridContainer.AddColumnProperties(RetailfgridColumn);
            RetailfgridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subRetailfgrid_Selectedindex), 4, 0, ".", "")));
            RetailfgridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subRetailfgrid_Allowselection), 1, 0, ".", "")));
            RetailfgridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subRetailfgrid_Selectioncolor), 9, 0, ".", "")));
            RetailfgridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subRetailfgrid_Allowhovering), 1, 0, ".", "")));
            RetailfgridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subRetailfgrid_Hoveringcolor), 9, 0, ".", "")));
            RetailfgridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subRetailfgrid_Allowcollapsing), 1, 0, ".", "")));
            RetailfgridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subRetailfgrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblTextblock2_Internalname = "TEXTBLOCK2";
         bttSelectall_Internalname = "SELECTALL";
         edtavCode_Internalname = "vCODE";
         edtavName_Internalname = "vNAME";
         dynavSupplier_Internalname = "vSUPPLIER";
         dynavBrand_Internalname = "vBRAND";
         dynavSector_Internalname = "vSECTOR";
         edtProductId_Internalname = "PRODUCTID";
         edtProductCode_Internalname = "PRODUCTCODE";
         edtProductName_Internalname = "PRODUCTNAME";
         edtSupplierName_Internalname = "SUPPLIERNAME";
         edtBrandName_Internalname = "BRANDNAME";
         edtSectorName_Internalname = "SECTORNAME";
         edtProductCostPrice_Internalname = "PRODUCTCOSTPRICE";
         edtProductRetailProfit_Internalname = "PRODUCTRETAILPROFIT";
         edtProductRetailPrice_Internalname = "PRODUCTRETAILPRICE";
         divTable1_Internalname = "TABLE1";
         edtavNewretailprofit_Internalname = "vNEWRETAILPROFIT";
         bttUpdate_Internalname = "UPDATE";
         bttCancel_Internalname = "CANCEL";
         divButtonstable_Internalname = "BUTTONSTABLE";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         lblTextblock12_Internalname = "TEXTBLOCK12";
         lblTextblock13_Internalname = "TEXTBLOCK13";
         lblTextblock14_Internalname = "TEXTBLOCK14";
         lblTextblock15_Internalname = "TEXTBLOCK15";
         lblTextblock16_Internalname = "TEXTBLOCK16";
         lblTextblock17_Internalname = "TEXTBLOCK17";
         lblTextblock18_Internalname = "TEXTBLOCK18";
         divTable3_Internalname = "TABLE3";
         edtavRemoveproduct_Internalname = "vREMOVEPRODUCT";
         edtavCtlcode1_Internalname = "CTLCODE1";
         edtavCtlname1_Internalname = "CTLNAME1";
         edtavCtlsupplier1_Internalname = "CTLSUPPLIER1";
         edtavCtlbrand1_Internalname = "CTLBRAND1";
         edtavCtlsector1_Internalname = "CTLSECTOR1";
         edtavCtlcostprice1_Internalname = "CTLCOSTPRICE1";
         edtavCtlretailprofit1_Internalname = "CTLRETAILPROFIT1";
         edtavCtlnewretailprofit_Internalname = "CTLNEWRETAILPROFIT";
         edtavCtlretailprice_Internalname = "CTLRETAILPRICE";
         divGrid1table1_Internalname = "GRID1TABLE1";
         divRetailprofittable_Internalname = "RETAILPROFITTABLE";
         divRetaiprofitltable_Internalname = "RETAIPROFITLTABLE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subAllproducts_Internalname = "ALLPRODUCTS";
         subRetailfgrid_Internalname = "RETAILFGRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("mtaKB", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subRetailfgrid_Allowcollapsing = 0;
         subAllproducts_Allowcollapsing = 1;
         subAllproducts_Allowselection = 0;
         subAllproducts_Header = "";
         edtavCtlretailprice_Jsonclick = "";
         edtavCtlretailprice_Visible = 1;
         edtavCtlretailprice_Enabled = 1;
         edtavCtlnewretailprofit_Jsonclick = "";
         edtavCtlnewretailprofit_Visible = 1;
         edtavCtlnewretailprofit_Enabled = 1;
         edtavCtlretailprofit1_Jsonclick = "";
         edtavCtlretailprofit1_Enabled = 0;
         edtavCtlcostprice1_Jsonclick = "";
         edtavCtlcostprice1_Enabled = 0;
         edtavCtlsector1_Jsonclick = "";
         edtavCtlsector1_Enabled = 0;
         edtavCtlbrand1_Jsonclick = "";
         edtavCtlbrand1_Enabled = 0;
         edtavCtlsupplier1_Jsonclick = "";
         edtavCtlsupplier1_Enabled = 0;
         edtavCtlname1_Jsonclick = "";
         edtavCtlname1_Enabled = 0;
         edtavCtlcode1_Jsonclick = "";
         edtavCtlcode1_Enabled = 0;
         edtavRemoveproduct_Jsonclick = "";
         edtavRemoveproduct_Visible = 1;
         edtavRemoveproduct_Enabled = 1;
         subRetailfgrid_Class = "FreeStyleGrid";
         edtProductRetailPrice_Jsonclick = "";
         edtProductRetailProfit_Jsonclick = "";
         edtProductCostPrice_Jsonclick = "";
         edtSectorName_Jsonclick = "";
         edtBrandName_Jsonclick = "";
         edtSupplierName_Jsonclick = "";
         edtProductName_Jsonclick = "";
         edtProductCode_Jsonclick = "";
         edtProductId_Jsonclick = "";
         subAllproducts_Class = "PromptGrid";
         subAllproducts_Backcolorstyle = 0;
         edtavRemoveproduct_gximage = "";
         subRetailfgrid_Backcolorstyle = 0;
         edtavCtlretailprofit1_Enabled = -1;
         edtavCtlcostprice1_Enabled = -1;
         edtavCtlsector1_Enabled = -1;
         edtavCtlbrand1_Enabled = -1;
         edtavCtlsupplier1_Enabled = -1;
         edtavCtlname1_Enabled = -1;
         edtavCtlcode1_Enabled = -1;
         divRetailprofittable_Visible = 1;
         edtavNewretailprofit_Jsonclick = "";
         edtavNewretailprofit_Enabled = 1;
         divButtonstable_Visible = 1;
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
         subAllproducts_Collapsed = 0;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "WPUpdate Retail Profit";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'RETAILFGRID_nFirstRecordOnPage'},{av:'RETAILFGRID_nEOF'},{av:'AV19ProductsSelected',fld:'vPRODUCTSSELECTED',grid:97,pic:''},{av:'nGXsfl_97_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:97},{av:'nRC_GXsfl_97',ctrl:'RETAILFGRID',prop:'GridRC',grid:97},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV9Code',fld:'vCODE',pic:''},{av:'AV16Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV23Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV22Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV34newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV35newCode',fld:'vNEWCODE',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("PRODUCTNAME.CLICK","{handler:'E212K2',iparms:[{av:'RETAILFGRID_nFirstRecordOnPage'},{av:'RETAILFGRID_nEOF'},{av:'AV19ProductsSelected',fld:'vPRODUCTSSELECTED',grid:97,pic:''},{av:'nGXsfl_97_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:97},{av:'nRC_GXsfl_97',ctrl:'RETAILFGRID',prop:'GridRC',grid:97},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV9Code',fld:'vCODE',pic:''},{av:'AV16Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV23Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV22Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV34newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV35newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'AV14IdsSelected',fld:'vIDSSELECTED',pic:''},{av:'A15ProductId',fld:'PRODUCTID',pic:'ZZZZZ9',hsh:true},{av:'AV30IsIn',fld:'vISIN',pic:''},{av:'AV36NewRetailProfit',fld:'vNEWRETAILPROFIT',pic:'ZZZ9.99'},{av:'AV20ProductsSelectedAux',fld:'vPRODUCTSSELECTEDAUX',pic:''},{av:'AV15IdsSelectedAux',fld:'vIDSSELECTEDAUX',pic:''},{av:'AV31IdSelected',fld:'vIDSELECTED',pic:'ZZZZZ9'},{av:'AV17OneProduct',fld:'vONEPRODUCT',pic:''},{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'}]");
         setEventMetadata("PRODUCTNAME.CLICK",",oparms:[{av:'divRetailprofittable_Visible',ctrl:'RETAILPROFITTABLE',prop:'Visible'},{av:'divButtonstable_Visible',ctrl:'BUTTONSTABLE',prop:'Visible'},{av:'AV31IdSelected',fld:'vIDSELECTED',pic:'ZZZZZ9'},{av:'AV17OneProduct',fld:'vONEPRODUCT',pic:''},{av:'AV20ProductsSelectedAux',fld:'vPRODUCTSSELECTEDAUX',pic:''},{av:'AV15IdsSelectedAux',fld:'vIDSSELECTEDAUX',pic:''},{av:'AV19ProductsSelected',fld:'vPRODUCTSSELECTED',grid:97,pic:''},{av:'nGXsfl_97_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:97},{av:'RETAILFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_97',ctrl:'RETAILFGRID',prop:'GridRC',grid:97},{av:'AV14IdsSelected',fld:'vIDSSELECTED',pic:''},{av:'AV30IsIn',fld:'vISIN',pic:''}]}");
         setEventMetadata("VNEWRETAILPROFIT.CONTROLVALUECHANGED","{handler:'E112K2',iparms:[{av:'AV36NewRetailProfit',fld:'vNEWRETAILPROFIT',pic:'ZZZ9.99'},{av:'AV19ProductsSelected',fld:'vPRODUCTSSELECTED',grid:97,pic:''},{av:'nGXsfl_97_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:97},{av:'RETAILFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_97',ctrl:'RETAILFGRID',prop:'GridRC',grid:97},{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'RETAILFGRID_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV9Code',fld:'vCODE',pic:''},{av:'AV16Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV23Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV22Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV34newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV35newCode',fld:'vNEWCODE',pic:'',hsh:true}]");
         setEventMetadata("VNEWRETAILPROFIT.CONTROLVALUECHANGED",",oparms:[{av:'AV17OneProduct',fld:'vONEPRODUCT',pic:''},{av:'AV19ProductsSelected',fld:'vPRODUCTSSELECTED',grid:97,pic:''},{av:'nGXsfl_97_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:97},{av:'RETAILFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_97',ctrl:'RETAILFGRID',prop:'GridRC',grid:97}]}");
         setEventMetadata("VREMOVEPRODUCT.CLICK","{handler:'E152K2',iparms:[{av:'RETAILFGRID_nFirstRecordOnPage'},{av:'RETAILFGRID_nEOF'},{av:'AV19ProductsSelected',fld:'vPRODUCTSSELECTED',grid:97,pic:''},{av:'nGXsfl_97_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:97},{av:'nRC_GXsfl_97',ctrl:'RETAILFGRID',prop:'GridRC',grid:97},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV9Code',fld:'vCODE',pic:''},{av:'AV16Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV23Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV22Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV34newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV35newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'AV14IdsSelected',fld:'vIDSSELECTED',pic:''},{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'}]");
         setEventMetadata("VREMOVEPRODUCT.CLICK",",oparms:[{av:'AV19ProductsSelected',fld:'vPRODUCTSSELECTED',grid:97,pic:''},{av:'nGXsfl_97_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:97},{av:'RETAILFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_97',ctrl:'RETAILFGRID',prop:'GridRC',grid:97},{av:'AV14IdsSelected',fld:'vIDSSELECTED',pic:''},{av:'divRetailprofittable_Visible',ctrl:'RETAILPROFITTABLE',prop:'Visible'},{av:'divButtonstable_Visible',ctrl:'BUTTONSTABLE',prop:'Visible'}]}");
         setEventMetadata("RETAILFGRID.REFRESH","{handler:'E162K2',iparms:[]");
         setEventMetadata("RETAILFGRID.REFRESH",",oparms:[{av:'AV39RemoveProduct',fld:'vREMOVEPRODUCT',pic:''}]}");
         setEventMetadata("'UPDATE'","{handler:'E122K2',iparms:[{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV9Code',fld:'vCODE',pic:''},{av:'AV16Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV23Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV22Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV34newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV35newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'AV7AllOk',fld:'vALLOK',pic:''},{av:'AV19ProductsSelected',fld:'vPRODUCTSSELECTED',grid:97,pic:''},{av:'nGXsfl_97_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:97},{av:'RETAILFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_97',ctrl:'RETAILFGRID',prop:'GridRC',grid:97},{av:'AV32ErrorMessage',fld:'vERRORMESSAGE',pic:''},{av:'AV14IdsSelected',fld:'vIDSSELECTED',pic:''},{av:'AV36NewRetailProfit',fld:'vNEWRETAILPROFIT',pic:'ZZZ9.99'},{av:'RETAILFGRID_nEOF'}]");
         setEventMetadata("'UPDATE'",",oparms:[{av:'AV7AllOk',fld:'vALLOK',pic:''},{av:'AV32ErrorMessage',fld:'vERRORMESSAGE',pic:''},{av:'AV14IdsSelected',fld:'vIDSSELECTED',pic:''},{av:'AV19ProductsSelected',fld:'vPRODUCTSSELECTED',grid:97,pic:''},{av:'nGXsfl_97_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:97},{av:'RETAILFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_97',ctrl:'RETAILFGRID',prop:'GridRC',grid:97},{av:'divRetailprofittable_Visible',ctrl:'RETAILPROFITTABLE',prop:'Visible'},{av:'divButtonstable_Visible',ctrl:'BUTTONSTABLE',prop:'Visible'},{av:'AV17OneProduct',fld:'vONEPRODUCT',pic:''}]}");
         setEventMetadata("'CANCEL'","{handler:'E132K2',iparms:[{av:'AV19ProductsSelected',fld:'vPRODUCTSSELECTED',grid:97,pic:''},{av:'nGXsfl_97_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:97},{av:'RETAILFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_97',ctrl:'RETAILFGRID',prop:'GridRC',grid:97},{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'RETAILFGRID_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV9Code',fld:'vCODE',pic:''},{av:'AV16Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV23Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV22Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV34newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV35newCode',fld:'vNEWCODE',pic:'',hsh:true}]");
         setEventMetadata("'CANCEL'",",oparms:[{av:'AV14IdsSelected',fld:'vIDSSELECTED',pic:''},{av:'AV19ProductsSelected',fld:'vPRODUCTSSELECTED',grid:97,pic:''},{av:'nGXsfl_97_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:97},{av:'RETAILFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_97',ctrl:'RETAILFGRID',prop:'GridRC',grid:97},{av:'divRetailprofittable_Visible',ctrl:'RETAILPROFITTABLE',prop:'Visible'},{av:'divButtonstable_Visible',ctrl:'BUTTONSTABLE',prop:'Visible'}]}");
         setEventMetadata("CTLNEWRETAILPROFIT.CONTROLVALUECHANGED","{handler:'E172K2',iparms:[{av:'AV19ProductsSelected',fld:'vPRODUCTSSELECTED',grid:97,pic:''},{av:'nGXsfl_97_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:97},{av:'RETAILFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_97',ctrl:'RETAILFGRID',prop:'GridRC',grid:97},{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'RETAILFGRID_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV9Code',fld:'vCODE',pic:''},{av:'AV16Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV23Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV22Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV34newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV35newCode',fld:'vNEWCODE',pic:'',hsh:true}]");
         setEventMetadata("CTLNEWRETAILPROFIT.CONTROLVALUECHANGED",",oparms:[{av:'AV17OneProduct',fld:'vONEPRODUCT',pic:''},{av:'AV19ProductsSelected',fld:'vPRODUCTSSELECTED',grid:97,pic:''},{av:'nGXsfl_97_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:97},{av:'RETAILFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_97',ctrl:'RETAILFGRID',prop:'GridRC',grid:97}]}");
         setEventMetadata("CTLRETAILPRICE.CONTROLVALUECHANGED","{handler:'E182K2',iparms:[{av:'AV19ProductsSelected',fld:'vPRODUCTSSELECTED',grid:97,pic:''},{av:'nGXsfl_97_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:97},{av:'RETAILFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_97',ctrl:'RETAILFGRID',prop:'GridRC',grid:97},{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'RETAILFGRID_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV9Code',fld:'vCODE',pic:''},{av:'AV16Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV23Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV22Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV34newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV35newCode',fld:'vNEWCODE',pic:'',hsh:true}]");
         setEventMetadata("CTLRETAILPRICE.CONTROLVALUECHANGED",",oparms:[{av:'AV17OneProduct',fld:'vONEPRODUCT',pic:''},{av:'AV19ProductsSelected',fld:'vPRODUCTSSELECTED',grid:97,pic:''},{av:'nGXsfl_97_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:97},{av:'RETAILFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_97',ctrl:'RETAILFGRID',prop:'GridRC',grid:97}]}");
         setEventMetadata("'SELECTALL'","{handler:'E142K2',iparms:[{av:'RETAILFGRID_nFirstRecordOnPage'},{av:'RETAILFGRID_nEOF'},{av:'AV19ProductsSelected',fld:'vPRODUCTSSELECTED',grid:97,pic:''},{av:'nGXsfl_97_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:97},{av:'nRC_GXsfl_97',ctrl:'RETAILFGRID',prop:'GridRC',grid:97},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV9Code',fld:'vCODE',pic:''},{av:'AV16Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV23Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV22Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV34newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV35newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'AV36NewRetailProfit',fld:'vNEWRETAILPROFIT',pic:'ZZZ9.99'},{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'}]");
         setEventMetadata("'SELECTALL'",",oparms:[{av:'AV19ProductsSelected',fld:'vPRODUCTSSELECTED',grid:97,pic:''},{av:'nGXsfl_97_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:97},{av:'RETAILFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_97',ctrl:'RETAILFGRID',prop:'GridRC',grid:97},{av:'dynavSector'},{av:'AV22Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSupplier'},{av:'AV23Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV16Name',fld:'vNAME',pic:''},{av:'divRetailprofittable_Visible',ctrl:'RETAILPROFITTABLE',prop:'Visible'},{av:'divButtonstable_Visible',ctrl:'BUTTONSTABLE',prop:'Visible'},{av:'AV17OneProduct',fld:'vONEPRODUCT',pic:''},{av:'AV14IdsSelected',fld:'vIDSSELECTED',pic:''}]}");
         setEventMetadata("ALLPRODUCTS_FIRSTPAGE","{handler:'suballproducts_firstpage',iparms:[{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV9Code',fld:'vCODE',pic:''},{av:'AV16Name',fld:'vNAME',pic:''},{av:'AV34newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV35newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'dynavSupplier'},{av:'AV23Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV22Sector',fld:'vSECTOR',pic:'ZZZZZ9'}]");
         setEventMetadata("ALLPRODUCTS_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("ALLPRODUCTS_PREVPAGE","{handler:'suballproducts_previouspage',iparms:[{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV9Code',fld:'vCODE',pic:''},{av:'AV16Name',fld:'vNAME',pic:''},{av:'AV34newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV35newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'dynavSupplier'},{av:'AV23Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV22Sector',fld:'vSECTOR',pic:'ZZZZZ9'}]");
         setEventMetadata("ALLPRODUCTS_PREVPAGE",",oparms:[]}");
         setEventMetadata("ALLPRODUCTS_NEXTPAGE","{handler:'suballproducts_nextpage',iparms:[{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV9Code',fld:'vCODE',pic:''},{av:'AV16Name',fld:'vNAME',pic:''},{av:'AV34newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV35newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'dynavSupplier'},{av:'AV23Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV22Sector',fld:'vSECTOR',pic:'ZZZZZ9'}]");
         setEventMetadata("ALLPRODUCTS_NEXTPAGE",",oparms:[]}");
         setEventMetadata("ALLPRODUCTS_LASTPAGE","{handler:'suballproducts_lastpage',iparms:[{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV9Code',fld:'vCODE',pic:''},{av:'AV16Name',fld:'vNAME',pic:''},{av:'AV34newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV35newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'dynavSupplier'},{av:'AV23Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV22Sector',fld:'vSECTOR',pic:'ZZZZZ9'}]");
         setEventMetadata("ALLPRODUCTS_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_NEWRETAILPROFIT","{handler:'Validv_Newretailprofit',iparms:[]");
         setEventMetadata("VALIDV_NEWRETAILPROFIT",",oparms:[]}");
         setEventMetadata("VALID_PRODUCTCOSTPRICE","{handler:'Valid_Productcostprice',iparms:[]");
         setEventMetadata("VALID_PRODUCTCOSTPRICE",",oparms:[]}");
         setEventMetadata("VALID_PRODUCTRETAILPROFIT","{handler:'Valid_Productretailprofit',iparms:[]");
         setEventMetadata("VALID_PRODUCTRETAILPROFIT",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Productretailprice',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("VALIDV_GXV7","{handler:'Validv_Gxv7',iparms:[]");
         setEventMetadata("VALIDV_GXV7",",oparms:[]}");
         setEventMetadata("VALIDV_GXV8","{handler:'Validv_Gxv8',iparms:[]");
         setEventMetadata("VALIDV_GXV8",",oparms:[]}");
         setEventMetadata("VALIDV_GXV9","{handler:'Validv_Gxv9',iparms:[]");
         setEventMetadata("VALIDV_GXV9",",oparms:[]}");
         setEventMetadata("VALIDV_GXV10","{handler:'Validv_Gxv10',iparms:[]");
         setEventMetadata("VALIDV_GXV10",",oparms:[]}");
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
         AV9Code = "";
         AV16Name = "";
         AV34newName = "";
         AV35newCode = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV19ProductsSelected = new GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem>( context, "SDTProductsSelectedItem", "mtaKB");
         AV14IdsSelected = new GxSimpleCollection<int>();
         AV20ProductsSelectedAux = new GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem>( context, "SDTProductsSelectedItem", "mtaKB");
         AV15IdsSelectedAux = new GxSimpleCollection<int>();
         AV17OneProduct = new SdtSDTProductsSelected_SDTProductsSelectedItem(context);
         AV32ErrorMessage = new GeneXus.Utils.SdtMessages_Message(context);
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTextblock2_Jsonclick = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttSelectall_Jsonclick = "";
         AllproductsContainer = new GXWebGrid( context);
         sStyleString = "";
         bttUpdate_Jsonclick = "";
         bttCancel_Jsonclick = "";
         lblTextblock1_Jsonclick = "";
         lblTextblock10_Jsonclick = "";
         lblTextblock11_Jsonclick = "";
         lblTextblock12_Jsonclick = "";
         lblTextblock13_Jsonclick = "";
         lblTextblock14_Jsonclick = "";
         lblTextblock15_Jsonclick = "";
         lblTextblock16_Jsonclick = "";
         lblTextblock17_Jsonclick = "";
         lblTextblock18_Jsonclick = "";
         RetailfgridContainer = new GXWebGrid( context);
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV39RemoveProduct = "";
         AV54Removeproduct_GXI = "";
         A55ProductCode = "";
         A16ProductName = "";
         A5SupplierName = "";
         A2BrandName = "";
         A10SectorName = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         scmdbuf = "";
         H002K2_A4SupplierId = new int[1] ;
         H002K2_A5SupplierName = new string[] {""} ;
         H002K3_A1BrandId = new int[1] ;
         H002K3_n1BrandId = new bool[] {false} ;
         H002K3_A2BrandName = new string[] {""} ;
         H002K4_A9SectorId = new int[1] ;
         H002K4_n9SectorId = new bool[] {false} ;
         H002K4_A10SectorName = new string[] {""} ;
         lV9Code = "";
         lV16Name = "";
         H002K5_A9SectorId = new int[1] ;
         H002K5_n9SectorId = new bool[] {false} ;
         H002K5_A1BrandId = new int[1] ;
         H002K5_n1BrandId = new bool[] {false} ;
         H002K5_A4SupplierId = new int[1] ;
         H002K5_A10SectorName = new string[] {""} ;
         H002K5_A2BrandName = new string[] {""} ;
         H002K5_A5SupplierName = new string[] {""} ;
         H002K5_A16ProductName = new string[] {""} ;
         H002K5_A55ProductCode = new string[] {""} ;
         H002K5_n55ProductCode = new bool[] {false} ;
         H002K5_A15ProductId = new int[1] ;
         H002K5_A85ProductCostPrice = new decimal[1] ;
         H002K5_n85ProductCostPrice = new bool[] {false} ;
         H002K5_A89ProductRetailProfit = new decimal[1] ;
         H002K5_n89ProductRetailProfit = new bool[] {false} ;
         H002K6_AALLPRODUCTS_nRecordCount = new long[1] ;
         AV37Context = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         AV38WebSession = context.GetSession();
         GXt_SdtSDTProductsSelected_SDTProductsSelectedItem4 = new SdtSDTProductsSelected_SDTProductsSelectedItem(context);
         GXt_objcol_SdtSDTProductsSelected_SDTProductsSelectedItem5 = new GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem>( context, "SDTProductsSelectedItem", "mtaKB");
         AllproductsRow = new GXWebRow();
         RetailfgridRow = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subAllproducts_Linesclass = "";
         ROClassString = "";
         subRetailfgrid_Linesclass = "";
         sImgUrl = "";
         AllproductsColumn = new GXWebColumn();
         subRetailfgrid_Header = "";
         RetailfgridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpupdateretailprofit__default(),
            new Object[][] {
                new Object[] {
               H002K2_A4SupplierId, H002K2_A5SupplierName
               }
               , new Object[] {
               H002K3_A1BrandId, H002K3_A2BrandName
               }
               , new Object[] {
               H002K4_A9SectorId, H002K4_A10SectorName
               }
               , new Object[] {
               H002K5_A9SectorId, H002K5_n9SectorId, H002K5_A1BrandId, H002K5_n1BrandId, H002K5_A4SupplierId, H002K5_A10SectorName, H002K5_A2BrandName, H002K5_A5SupplierName, H002K5_A16ProductName, H002K5_A55ProductCode,
               H002K5_n55ProductCode, H002K5_A15ProductId, H002K5_A85ProductCostPrice, H002K5_n85ProductCostPrice, H002K5_A89ProductRetailProfit, H002K5_n89ProductRetailProfit
               }
               , new Object[] {
               H002K6_AALLPRODUCTS_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavCtlcode1_Enabled = 0;
         edtavCtlname1_Enabled = 0;
         edtavCtlsupplier1_Enabled = 0;
         edtavCtlbrand1_Enabled = 0;
         edtavCtlsector1_Enabled = 0;
         edtavCtlcostprice1_Enabled = 0;
         edtavCtlretailprofit1_Enabled = 0;
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short ALLPRODUCTS_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short subAllproducts_Collapsed ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subAllproducts_Backcolorstyle ;
      private short subRetailfgrid_Backcolorstyle ;
      private short RETAILFGRID_nEOF ;
      private short AV29Position ;
      private short nGXWrapped ;
      private short subAllproducts_Backstyle ;
      private short subRetailfgrid_Backstyle ;
      private short subAllproducts_Titlebackstyle ;
      private short subAllproducts_Allowselection ;
      private short subAllproducts_Allowhovering ;
      private short subAllproducts_Allowcollapsing ;
      private short subRetailfgrid_Allowselection ;
      private short subRetailfgrid_Allowhovering ;
      private short subRetailfgrid_Allowcollapsing ;
      private short subRetailfgrid_Collapsed ;
      private int nRC_GXsfl_39 ;
      private int nRC_GXsfl_97 ;
      private int subAllproducts_Rows ;
      private int nGXsfl_39_idx=1 ;
      private int AV23Supplier ;
      private int AV8Brand ;
      private int AV22Sector ;
      private int nGXsfl_97_idx=1 ;
      private int AV31IdSelected ;
      private int edtavCode_Enabled ;
      private int edtavName_Enabled ;
      private int divButtonstable_Visible ;
      private int edtavNewretailprofit_Enabled ;
      private int divRetailprofittable_Visible ;
      private int AV42GXV1 ;
      private int A15ProductId ;
      private int gxdynajaxindex ;
      private int subAllproducts_Islastpage ;
      private int subRetailfgrid_Islastpage ;
      private int edtavCtlcode1_Enabled ;
      private int edtavCtlname1_Enabled ;
      private int edtavCtlsupplier1_Enabled ;
      private int edtavCtlbrand1_Enabled ;
      private int edtavCtlsector1_Enabled ;
      private int edtavCtlcostprice1_Enabled ;
      private int edtavCtlretailprofit1_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A4SupplierId ;
      private int A1BrandId ;
      private int A9SectorId ;
      private int nGXsfl_97_fel_idx=1 ;
      private int AV52GXV11 ;
      private int nGXsfl_97_bak_idx=1 ;
      private int AV53GXV12 ;
      private int AV55GXV13 ;
      private int AV56GXV14 ;
      private int AV57GXV15 ;
      private int idxLst ;
      private int subAllproducts_Backcolor ;
      private int subAllproducts_Allbackcolor ;
      private int subRetailfgrid_Backcolor ;
      private int subRetailfgrid_Allbackcolor ;
      private int edtavRemoveproduct_Enabled ;
      private int edtavRemoveproduct_Visible ;
      private int edtavCtlnewretailprofit_Enabled ;
      private int edtavCtlnewretailprofit_Visible ;
      private int edtavCtlretailprice_Enabled ;
      private int edtavCtlretailprice_Visible ;
      private int subAllproducts_Titlebackcolor ;
      private int subAllproducts_Selectedindex ;
      private int subAllproducts_Selectioncolor ;
      private int subAllproducts_Hoveringcolor ;
      private int subRetailfgrid_Selectedindex ;
      private int subRetailfgrid_Selectioncolor ;
      private int subRetailfgrid_Hoveringcolor ;
      private long ALLPRODUCTS_nFirstRecordOnPage ;
      private long ALLPRODUCTS_nCurrentRecord ;
      private long RETAILFGRID_nCurrentRecord ;
      private long ALLPRODUCTS_nRecordCount ;
      private long RETAILFGRID_nFirstRecordOnPage ;
      private decimal AV36NewRetailProfit ;
      private decimal A85ProductCostPrice ;
      private decimal A89ProductRetailProfit ;
      private decimal A90ProductRetailPrice ;
      private decimal GXt_decimal1 ;
      private decimal GXt_decimal2 ;
      private decimal GXt_decimal3 ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_39_idx="0001" ;
      private string sGXsfl_97_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string divTable1_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttSelectall_Internalname ;
      private string bttSelectall_Jsonclick ;
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
      private string divRetaiprofitltable_Internalname ;
      private string divButtonstable_Internalname ;
      private string edtavNewretailprofit_Internalname ;
      private string edtavNewretailprofit_Jsonclick ;
      private string bttUpdate_Internalname ;
      private string bttUpdate_Jsonclick ;
      private string bttCancel_Internalname ;
      private string bttCancel_Jsonclick ;
      private string divRetailprofittable_Internalname ;
      private string divTable3_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string lblTextblock12_Internalname ;
      private string lblTextblock12_Jsonclick ;
      private string lblTextblock13_Internalname ;
      private string lblTextblock13_Jsonclick ;
      private string lblTextblock14_Internalname ;
      private string lblTextblock14_Jsonclick ;
      private string lblTextblock15_Internalname ;
      private string lblTextblock15_Jsonclick ;
      private string lblTextblock16_Internalname ;
      private string lblTextblock16_Jsonclick ;
      private string lblTextblock17_Internalname ;
      private string lblTextblock17_Jsonclick ;
      private string lblTextblock18_Internalname ;
      private string lblTextblock18_Jsonclick ;
      private string subRetailfgrid_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavRemoveproduct_Internalname ;
      private string edtProductId_Internalname ;
      private string edtProductCode_Internalname ;
      private string edtProductName_Internalname ;
      private string edtSupplierName_Internalname ;
      private string edtBrandName_Internalname ;
      private string edtSectorName_Internalname ;
      private string edtProductCostPrice_Internalname ;
      private string edtProductRetailProfit_Internalname ;
      private string edtProductRetailPrice_Internalname ;
      private string gxwrpcisep ;
      private string scmdbuf ;
      private string edtavCtlcode1_Internalname ;
      private string edtavCtlname1_Internalname ;
      private string edtavCtlsupplier1_Internalname ;
      private string edtavCtlbrand1_Internalname ;
      private string edtavCtlsector1_Internalname ;
      private string edtavCtlcostprice1_Internalname ;
      private string edtavCtlretailprofit1_Internalname ;
      private string sGXsfl_97_fel_idx="0001" ;
      private string edtavRemoveproduct_gximage ;
      private string sGXsfl_39_fel_idx="0001" ;
      private string subAllproducts_Class ;
      private string subAllproducts_Linesclass ;
      private string ROClassString ;
      private string edtProductId_Jsonclick ;
      private string edtProductCode_Jsonclick ;
      private string edtProductName_Jsonclick ;
      private string edtSupplierName_Jsonclick ;
      private string edtBrandName_Jsonclick ;
      private string edtSectorName_Jsonclick ;
      private string edtProductCostPrice_Jsonclick ;
      private string edtProductRetailProfit_Jsonclick ;
      private string edtProductRetailPrice_Jsonclick ;
      private string edtavCtlnewretailprofit_Internalname ;
      private string edtavCtlretailprice_Internalname ;
      private string subRetailfgrid_Class ;
      private string subRetailfgrid_Linesclass ;
      private string divGrid1table1_Internalname ;
      private string sImgUrl ;
      private string edtavRemoveproduct_Jsonclick ;
      private string edtavCtlcode1_Jsonclick ;
      private string edtavCtlname1_Jsonclick ;
      private string edtavCtlsupplier1_Jsonclick ;
      private string edtavCtlbrand1_Jsonclick ;
      private string edtavCtlsector1_Jsonclick ;
      private string edtavCtlcostprice1_Jsonclick ;
      private string edtavCtlretailprofit1_Jsonclick ;
      private string edtavCtlnewretailprofit_Jsonclick ;
      private string edtavCtlretailprice_Jsonclick ;
      private string subAllproducts_Header ;
      private string subRetailfgrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV30IsIn ;
      private bool AV7AllOk ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_97_Refreshing=false ;
      private bool n55ProductCode ;
      private bool n85ProductCostPrice ;
      private bool n89ProductRetailProfit ;
      private bool gxdyncontrolsrefreshing ;
      private bool bGXsfl_39_Refreshing=false ;
      private bool n9SectorId ;
      private bool n1BrandId ;
      private bool returnInSub ;
      private bool gx_BV97 ;
      private bool AV39RemoveProduct_IsBlob ;
      private string AV9Code ;
      private string AV16Name ;
      private string AV34newName ;
      private string AV35newCode ;
      private string AV54Removeproduct_GXI ;
      private string A55ProductCode ;
      private string A16ProductName ;
      private string A5SupplierName ;
      private string A2BrandName ;
      private string A10SectorName ;
      private string lV9Code ;
      private string lV16Name ;
      private string AV39RemoveProduct ;
      private GxSimpleCollection<int> AV14IdsSelected ;
      private GxSimpleCollection<int> AV15IdsSelectedAux ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid AllproductsContainer ;
      private GXWebGrid RetailfgridContainer ;
      private GXWebRow AllproductsRow ;
      private GXWebRow RetailfgridRow ;
      private GXWebColumn AllproductsColumn ;
      private GXWebColumn RetailfgridColumn ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavSupplier ;
      private GXCombobox dynavBrand ;
      private GXCombobox dynavSector ;
      private IDataStoreProvider pr_default ;
      private int[] H002K2_A4SupplierId ;
      private string[] H002K2_A5SupplierName ;
      private int[] H002K3_A1BrandId ;
      private bool[] H002K3_n1BrandId ;
      private string[] H002K3_A2BrandName ;
      private int[] H002K4_A9SectorId ;
      private bool[] H002K4_n9SectorId ;
      private string[] H002K4_A10SectorName ;
      private int[] H002K5_A9SectorId ;
      private bool[] H002K5_n9SectorId ;
      private int[] H002K5_A1BrandId ;
      private bool[] H002K5_n1BrandId ;
      private int[] H002K5_A4SupplierId ;
      private string[] H002K5_A10SectorName ;
      private string[] H002K5_A2BrandName ;
      private string[] H002K5_A5SupplierName ;
      private string[] H002K5_A16ProductName ;
      private string[] H002K5_A55ProductCode ;
      private bool[] H002K5_n55ProductCode ;
      private int[] H002K5_A15ProductId ;
      private decimal[] H002K5_A85ProductCostPrice ;
      private bool[] H002K5_n85ProductCostPrice ;
      private decimal[] H002K5_A89ProductRetailProfit ;
      private bool[] H002K5_n89ProductRetailProfit ;
      private long[] H002K6_AALLPRODUCTS_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IGxSession AV38WebSession ;
      private GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> AV19ProductsSelected ;
      private GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> AV20ProductsSelectedAux ;
      private GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> GXt_objcol_SdtSDTProductsSelected_SDTProductsSelectedItem5 ;
      private GXWebForm Form ;
      private GeneXus.Utils.SdtMessages_Message AV32ErrorMessage ;
      private SdtSDTProductsSelected_SDTProductsSelectedItem AV17OneProduct ;
      private SdtSDTProductsSelected_SDTProductsSelectedItem GXt_SdtSDTProductsSelected_SDTProductsSelectedItem4 ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession AV37Context ;
   }

   public class wpupdateretailprofit__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002K5( IGxContext context ,
                                             string AV9Code ,
                                             string AV16Name ,
                                             int AV23Supplier ,
                                             int AV8Brand ,
                                             int AV22Sector ,
                                             string A55ProductCode ,
                                             string A16ProductName ,
                                             int A4SupplierId ,
                                             int A1BrandId ,
                                             int A9SectorId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[8];
         Object[] GXv_Object7 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[SectorId], T1.[BrandId], T1.[SupplierId], T2.[SectorName], T3.[BrandName], T4.[SupplierName], T1.[ProductName], T1.[ProductCode], T1.[ProductId], T1.[ProductCostPrice], T1.[ProductRetailProfit]";
         sFromString = " FROM ((([Product] T1 LEFT JOIN [Sector] T2 ON T2.[SectorId] = T1.[SectorId]) LEFT JOIN [Brand] T3 ON T3.[BrandId] = T1.[BrandId]) INNER JOIN [Supplier] T4 ON T4.[SupplierId] = T1.[SupplierId])";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9Code)) )
         {
            AddWhere(sWhereString, "(T1.[ProductCode] like @lV9Code)");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16Name)) )
         {
            AddWhere(sWhereString, "(T1.[ProductName] like @lV16Name)");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( ! (0==AV23Supplier) )
         {
            AddWhere(sWhereString, "(T1.[SupplierId] = @AV23Supplier)");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( ! (0==AV8Brand) )
         {
            AddWhere(sWhereString, "(T1.[BrandId] = @AV8Brand)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( ! (0==AV22Sector) )
         {
            AddWhere(sWhereString, "(T1.[SectorId] = @AV22Sector)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         sOrderString += " ORDER BY T1.[ProductName]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_H002K6( IGxContext context ,
                                             string AV9Code ,
                                             string AV16Name ,
                                             int AV23Supplier ,
                                             int AV8Brand ,
                                             int AV22Sector ,
                                             string A55ProductCode ,
                                             string A16ProductName ,
                                             int A4SupplierId ,
                                             int A1BrandId ,
                                             int A9SectorId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[5];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ((([Product] T1 LEFT JOIN [Sector] T3 ON T3.[SectorId] = T1.[SectorId]) LEFT JOIN [Brand] T2 ON T2.[BrandId] = T1.[BrandId]) INNER JOIN [Supplier] T4 ON T4.[SupplierId] = T1.[SupplierId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9Code)) )
         {
            AddWhere(sWhereString, "(T1.[ProductCode] like @lV9Code)");
         }
         else
         {
            GXv_int8[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16Name)) )
         {
            AddWhere(sWhereString, "(T1.[ProductName] like @lV16Name)");
         }
         else
         {
            GXv_int8[1] = 1;
         }
         if ( ! (0==AV23Supplier) )
         {
            AddWhere(sWhereString, "(T1.[SupplierId] = @AV23Supplier)");
         }
         else
         {
            GXv_int8[2] = 1;
         }
         if ( ! (0==AV8Brand) )
         {
            AddWhere(sWhereString, "(T1.[BrandId] = @AV8Brand)");
         }
         else
         {
            GXv_int8[3] = 1;
         }
         if ( ! (0==AV22Sector) )
         {
            AddWhere(sWhereString, "(T1.[SectorId] = @AV22Sector)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         scmdbuf += sWhereString;
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 3 :
                     return conditional_H002K5(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] );
               case 4 :
                     return conditional_H002K6(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] );
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
          Object[] prmH002K2;
          prmH002K2 = new Object[] {
          };
          Object[] prmH002K3;
          prmH002K3 = new Object[] {
          };
          Object[] prmH002K4;
          prmH002K4 = new Object[] {
          };
          Object[] prmH002K5;
          prmH002K5 = new Object[] {
          new ParDef("@lV9Code",GXType.NVarChar,100,0) ,
          new ParDef("@lV16Name",GXType.NVarChar,60,0) ,
          new ParDef("@AV23Supplier",GXType.Int32,6,0) ,
          new ParDef("@AV8Brand",GXType.Int32,6,0) ,
          new ParDef("@AV22Sector",GXType.Int32,6,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH002K6;
          prmH002K6 = new Object[] {
          new ParDef("@lV9Code",GXType.NVarChar,100,0) ,
          new ParDef("@lV16Name",GXType.NVarChar,60,0) ,
          new ParDef("@AV23Supplier",GXType.Int32,6,0) ,
          new ParDef("@AV8Brand",GXType.Int32,6,0) ,
          new ParDef("@AV22Sector",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002K2", "SELECT [SupplierId], [SupplierName] FROM [Supplier] ORDER BY [SupplierName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002K2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002K3", "SELECT [BrandId], [BrandName] FROM [Brand] ORDER BY [BrandName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002K3,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002K4", "SELECT [SectorId], [SectorName] FROM [Sector] ORDER BY [SectorName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002K4,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002K5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002K5,6, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002K6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002K6,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                ((string[]) buf[8])[0] = rslt.getVarchar(7);
                ((string[]) buf[9])[0] = rslt.getVarchar(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((int[]) buf[11])[0] = rslt.getInt(9);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(10);
                ((bool[]) buf[13])[0] = rslt.wasNull(10);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(11);
                ((bool[]) buf[15])[0] = rslt.wasNull(11);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
