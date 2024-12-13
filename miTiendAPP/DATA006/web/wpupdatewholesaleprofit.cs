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
   public class wpupdatewholesaleprofit : GXDataArea
   {
      public wpupdatewholesaleprofit( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public wpupdatewholesaleprofit( IGxContext context )
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
               GXDLVvSUPPLIER2L2( ) ;
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
               GXDLVvBRAND2L2( ) ;
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
               GXDLVvSECTOR2L2( ) ;
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Wholesalefgrid") == 0 )
            {
               gxnrWholesalefgrid_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Wholesalefgrid") == 0 )
            {
               gxgrWholesalefgrid_refresh_invoke( ) ;
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
         AV32newName = GetPar( "newName");
         AV33newCode = GetPar( "newCode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrAllproducts_refresh( subAllproducts_Rows, AV9Code, AV16Name, AV23Supplier, AV8Brand, AV22Sector, AV32newName, AV33newCode) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrAllproducts_refresh_invoke */
      }

      protected void gxnrWholesalefgrid_newrow_invoke( )
      {
         nRC_GXsfl_94 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_94"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_94_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_94_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_94_idx = GetPar( "sGXsfl_94_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrWholesalefgrid_newrow( ) ;
         /* End function gxnrWholesalefgrid_newrow_invoke */
      }

      protected void gxgrWholesalefgrid_refresh_invoke( )
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
         AV32newName = GetPar( "newName");
         AV33newCode = GetPar( "newCode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrWholesalefgrid_refresh( subAllproducts_Rows, AV9Code, AV16Name, AV23Supplier, AV8Brand, AV22Sector, AV32newName, AV33newCode) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrWholesalefgrid_refresh_invoke */
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
         PA2L2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2L2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpupdatewholesaleprofit.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vNEWNAME", AV32newName);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV32newName, "")), context));
         GxWebStd.gx_hidden_field( context, "vNEWCODE", AV33newCode);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV33newCode, "")), context));
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
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_94", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_94), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vNEWNAME", AV32newName);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV32newName, "")), context));
         GxWebStd.gx_hidden_field( context, "vNEWCODE", AV33newCode);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV33newCode, "")), context));
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vERRORMESSAGE", AV37ErrorMessage);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vERRORMESSAGE", AV37ErrorMessage);
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
            WE2L2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2L2( ) ;
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
         return formatLink("wpupdatewholesaleprofit.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WPUpdateWholesaleProfit" ;
      }

      public override string GetPgmdesc( )
      {
         return "WPUpdate Wholesale Profit" ;
      }

      protected void WB2L0( )
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
            GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Update Wholesale Profit", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WPUpdateWholesaleProfit.htm");
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
            GxWebStd.gx_button_ctrl( context, bttSelectall_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(39), 2, 0)+","+"null"+");", "Select All", bttSelectall_Jsonclick, 5, "Select All", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'SELECTALL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPUpdateWholesaleProfit.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavCode_Internalname, AV9Code, StringUtil.RTrim( context.localUtil.Format( AV9Code, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,18);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCode_Jsonclick, 0, "attribute-filter", "", "", "", "", 1, edtavCode_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_WPUpdateWholesaleProfit.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavName_Internalname, AV16Name, StringUtil.RTrim( context.localUtil.Format( AV16Name, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavName_Jsonclick, 0, "attribute-filter", "", "", "", "", 1, edtavName_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_WPUpdateWholesaleProfit.htm");
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
            GxWebStd.gx_combobox_ctrl1( context, dynavSupplier, dynavSupplier_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV23Supplier), 6, 0)), 1, dynavSupplier_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavSupplier.Enabled, 0, 0, 0, "em", 0, "", "", "attribute-filter", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "", true, 0, "HLP_WPUpdateWholesaleProfit.htm");
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
            GxWebStd.gx_combobox_ctrl1( context, dynavBrand, dynavBrand_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV8Brand), 6, 0)), 1, dynavBrand_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavBrand.Enabled, 0, 0, 0, "em", 0, "", "", "attribute-filter", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "", true, 0, "HLP_WPUpdateWholesaleProfit.htm");
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
            GxWebStd.gx_combobox_ctrl1( context, dynavSector, dynavSector_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV22Sector), 6, 0)), 1, dynavSector_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavSector.Enabled, 0, 0, 0, "em", 0, "", "", "attribute-filter", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "", true, 0, "HLP_WPUpdateWholesaleProfit.htm");
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
            GxWebStd.gx_div_start( context, divButtonstable_Internalname, divButtonstable_Visible, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavNewwprofit_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNewwprofit_Internalname, "W. Profit", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'" + sGXsfl_39_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNewwprofit_Internalname, StringUtil.LTrim( StringUtil.NToC( AV26NewWProfit, 8, 2, ".", "")), StringUtil.LTrim( ((edtavNewwprofit_Enabled!=0) ? context.localUtil.Format( AV26NewWProfit, "ZZZZ9.99") : context.localUtil.Format( AV26NewWProfit, "ZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNewwprofit_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavNewwprofit_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "Percentage", "right", false, "", "HLP_WPUpdateWholesaleProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttUpdate_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(39), 2, 0)+","+"null"+");", "Update", bttUpdate_Jsonclick, 5, "Update", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'UPDATE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPUpdateWholesaleProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(39), 2, 0)+","+"null"+");", "Cancel", bttCancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPUpdateWholesaleProfit.htm");
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
            GxWebStd.gx_div_start( context, divWholesaleprofittable_Internalname, divWholesaleprofittable_Visible, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable4_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-1 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Action", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPUpdateWholesaleProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-1 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock19_Internalname, "Code", "", "", lblTextblock19_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdateWholesaleProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-1", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock20_Internalname, "Name", "", "", lblTextblock20_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdateWholesaleProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-1", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock21_Internalname, "Supplier", "", "", lblTextblock21_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdateWholesaleProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-1", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock22_Internalname, "Brand", "", "", lblTextblock22_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdateWholesaleProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-1", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock23_Internalname, "Sector", "", "", lblTextblock23_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdateWholesaleProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-1", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock24_Internalname, "U. Cost Price", "", "", lblTextblock24_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdateWholesaleProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-1", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock25_Internalname, "W. Profit", "", "", lblTextblock25_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdateWholesaleProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-1", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock26_Internalname, "New W. Profit", "", "", lblTextblock26_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdateWholesaleProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-1", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock27_Internalname, "W. Price", "", "", lblTextblock27_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdateWholesaleProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-10 col-sm-12", "left", "top", "", "", "div");
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
            WholesalefgridContainer.SetIsFreestyle(true);
            WholesalefgridContainer.SetWrapped(nGXWrapped);
            StartGridControl94( ) ;
         }
         if ( wbEnd == 94 )
         {
            wbEnd = 0;
            nRC_GXsfl_94 = (int)(nGXsfl_94_idx-1);
            if ( WholesalefgridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV44GXV1 = nGXsfl_94_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"WholesalefgridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Wholesalefgrid", WholesalefgridContainer, subWholesalefgrid_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "WholesalefgridContainerData", WholesalefgridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "WholesalefgridContainerData"+"V", WholesalefgridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"WholesalefgridContainerData"+"V"+"\" value='"+WholesalefgridContainer.GridValuesHidden()+"'/>") ;
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
         if ( wbEnd == 94 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( WholesalefgridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV44GXV1 = nGXsfl_94_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"WholesalefgridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Wholesalefgrid", WholesalefgridContainer, subWholesalefgrid_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "WholesalefgridContainerData", WholesalefgridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "WholesalefgridContainerData"+"V", WholesalefgridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"WholesalefgridContainerData"+"V"+"\" value='"+WholesalefgridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START2L2( )
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
            Form.Meta.addItem("description", "WPUpdate Wholesale Profit", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2L0( ) ;
      }

      protected void WS2L2( )
      {
         START2L2( ) ;
         EVT2L2( ) ;
      }

      protected void EVT2L2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "VNEWWPROFIT.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E112L2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'UPDATE'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Update' */
                              E122L2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'SELECTALL'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'SelectAll' */
                              E132L2 ();
                              /* No code required for Cancel button. It is implemented as the Reset button. */
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 20), "VREMOVEPRODUCT.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 22), "WHOLESALEFGRID.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 41), "CTLNEWWHOLESALEPROFIT.CONTROLVALUECHANGED") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 37), "CTLWHOLESALEPRICE.CONTROLVALUECHANGED") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "WHOLESALEFGRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 20), "VREMOVEPRODUCT.CLICK") == 0 ) )
                           {
                              nGXsfl_94_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_94_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_94_idx), 4, 0), 4, "0");
                              SubsflControlProps_943( ) ;
                              AV44GXV1 = nGXsfl_94_idx;
                              if ( ( AV19ProductsSelected.Count >= AV44GXV1 ) && ( AV44GXV1 > 0 ) )
                              {
                                 AV19ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV44GXV1));
                                 AV41RemoveProduct = cgiGet( edtavRemoveproduct_Internalname);
                                 AssignProp("", false, edtavRemoveproduct_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV41RemoveProduct)) ? AV56Removeproduct_GXI : context.convertURL( context.PathToRelativeUrl( AV41RemoveProduct))), !bGXsfl_94_Refreshing);
                                 AssignProp("", false, edtavRemoveproduct_Internalname, "SrcSet", context.GetImageSrcSet( AV41RemoveProduct), true);
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "VREMOVEPRODUCT.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E142L2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "WHOLESALEFGRID.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E152L2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "CTLNEWWHOLESALEPROFIT.CONTROLVALUECHANGED") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E162L2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "CTLWHOLESALEPRICE.CONTROLVALUECHANGED") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E172L2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "WHOLESALEFGRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E182L3 ();
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
                           else if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "PRODUCTNAME.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 8), "'CANCEL'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 16), "ALLPRODUCTS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "PRODUCTNAME.CLICK") == 0 ) )
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
                              A87ProductWholesaleProfit = context.localUtil.CToN( cgiGet( edtProductWholesaleProfit_Internalname), ".", ",");
                              n87ProductWholesaleProfit = false;
                              A88ProductWholesalePrice = context.localUtil.CToN( cgiGet( edtProductWholesalePrice_Internalname), ".", ",");
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E192L2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "PRODUCTNAME.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E202L2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'CANCEL'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'Cancel' */
                                    E212L2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ALLPRODUCTS.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E222L2 ();
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

      protected void WE2L2( )
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

      protected void PA2L2( )
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

      protected void GXDLVvSUPPLIER2L2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvSUPPLIER_data2L2( ) ;
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

      protected void GXVvSUPPLIER_html2L2( )
      {
         int gxdynajaxvalue;
         GXDLVvSUPPLIER_data2L2( ) ;
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

      protected void GXDLVvSUPPLIER_data2L2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(None)");
         /* Using cursor H002L2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H002L2_A4SupplierId[0]), 6, 0, ".", "")));
            gxdynajaxctrldescr.Add(H002L2_A5SupplierName[0]);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void GXDLVvBRAND2L2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvBRAND_data2L2( ) ;
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

      protected void GXVvBRAND_html2L2( )
      {
         int gxdynajaxvalue;
         GXDLVvBRAND_data2L2( ) ;
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

      protected void GXDLVvBRAND_data2L2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(None)");
         /* Using cursor H002L3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H002L3_A1BrandId[0]), 6, 0, ".", "")));
            gxdynajaxctrldescr.Add(H002L3_A2BrandName[0]);
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void GXDLVvSECTOR2L2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvSECTOR_data2L2( ) ;
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

      protected void GXVvSECTOR_html2L2( )
      {
         int gxdynajaxvalue;
         GXDLVvSECTOR_data2L2( ) ;
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

      protected void GXDLVvSECTOR_data2L2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(None)");
         /* Using cursor H002L4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H002L4_A9SectorId[0]), 6, 0, ".", "")));
            gxdynajaxctrldescr.Add(H002L4_A10SectorName[0]);
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

      protected void gxnrWholesalefgrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_943( ) ;
         while ( nGXsfl_94_idx <= nRC_GXsfl_94 )
         {
            sendrow_943( ) ;
            nGXsfl_94_idx = ((subWholesalefgrid_Islastpage==1)&&(nGXsfl_94_idx+1>subWholesalefgrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_94_idx+1);
            sGXsfl_94_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_94_idx), 4, 0), 4, "0");
            SubsflControlProps_943( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( WholesalefgridContainer)) ;
         /* End function gxnrWholesalefgrid_newrow */
      }

      protected void gxgrAllproducts_refresh( int subAllproducts_Rows ,
                                              string AV9Code ,
                                              string AV16Name ,
                                              int AV23Supplier ,
                                              int AV8Brand ,
                                              int AV22Sector ,
                                              string AV32newName ,
                                              string AV33newCode )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         ALLPRODUCTS_nCurrentRecord = 0;
         RF2L2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrAllproducts_refresh */
      }

      protected void gxgrWholesalefgrid_refresh( int subAllproducts_Rows ,
                                                 string AV9Code ,
                                                 string AV16Name ,
                                                 int AV23Supplier ,
                                                 int AV8Brand ,
                                                 int AV22Sector ,
                                                 string AV32newName ,
                                                 string AV33newCode )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         WHOLESALEFGRID_nCurrentRecord = 0;
         RF2L3( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrWholesalefgrid_refresh */
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
            GXVvSUPPLIER_html2L2( ) ;
            GXVvBRAND_html2L2( ) ;
            GXVvSECTOR_html2L2( ) ;
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
         RF2L2( ) ;
         RF2L3( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavCtlcode2_Enabled = 0;
         AssignProp("", false, edtavCtlcode2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcode2_Enabled), 5, 0), !bGXsfl_94_Refreshing);
         edtavCtlname2_Enabled = 0;
         AssignProp("", false, edtavCtlname2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname2_Enabled), 5, 0), !bGXsfl_94_Refreshing);
         edtavCtlsupplier2_Enabled = 0;
         AssignProp("", false, edtavCtlsupplier2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsupplier2_Enabled), 5, 0), !bGXsfl_94_Refreshing);
         edtavCtlbrand2_Enabled = 0;
         AssignProp("", false, edtavCtlbrand2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlbrand2_Enabled), 5, 0), !bGXsfl_94_Refreshing);
         edtavCtlsector2_Enabled = 0;
         AssignProp("", false, edtavCtlsector2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsector2_Enabled), 5, 0), !bGXsfl_94_Refreshing);
         edtavCtlcostprice2_Enabled = 0;
         AssignProp("", false, edtavCtlcostprice2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcostprice2_Enabled), 5, 0), !bGXsfl_94_Refreshing);
         edtavCtlwholesaleprofit1_Enabled = 0;
         AssignProp("", false, edtavCtlwholesaleprofit1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlwholesaleprofit1_Enabled), 5, 0), !bGXsfl_94_Refreshing);
      }

      protected void RF2L2( )
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
            /* Using cursor H002L5 */
            pr_default.execute(3, new Object[] {lV9Code, lV16Name, AV23Supplier, AV8Brand, AV22Sector, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_39_idx = 1;
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
            while ( ( (pr_default.getStatus(3) != 101) ) && ( ( ALLPRODUCTS_nCurrentRecord < subAllproducts_fnc_Recordsperpage( ) ) ) )
            {
               A9SectorId = H002L5_A9SectorId[0];
               n9SectorId = H002L5_n9SectorId[0];
               A1BrandId = H002L5_A1BrandId[0];
               n1BrandId = H002L5_n1BrandId[0];
               A4SupplierId = H002L5_A4SupplierId[0];
               A10SectorName = H002L5_A10SectorName[0];
               A2BrandName = H002L5_A2BrandName[0];
               A5SupplierName = H002L5_A5SupplierName[0];
               A16ProductName = H002L5_A16ProductName[0];
               A55ProductCode = H002L5_A55ProductCode[0];
               n55ProductCode = H002L5_n55ProductCode[0];
               A15ProductId = H002L5_A15ProductId[0];
               A85ProductCostPrice = H002L5_A85ProductCostPrice[0];
               n85ProductCostPrice = H002L5_n85ProductCostPrice[0];
               A87ProductWholesaleProfit = H002L5_A87ProductWholesaleProfit[0];
               n87ProductWholesaleProfit = H002L5_n87ProductWholesaleProfit[0];
               A10SectorName = H002L5_A10SectorName[0];
               A2BrandName = H002L5_A2BrandName[0];
               A5SupplierName = H002L5_A5SupplierName[0];
               GXt_decimal1 = A88ProductWholesalePrice;
               new roundvalue(context ).execute(  A85ProductCostPrice*(1+A87ProductWholesaleProfit/ (decimal)(100)), out  GXt_decimal1) ;
               GXt_decimal2 = A88ProductWholesalePrice;
               new roundvalue(context ).execute(  A85ProductCostPrice*(1+A87ProductWholesaleProfit/ (decimal)(100)), out  GXt_decimal2) ;
               GXt_decimal3 = A88ProductWholesalePrice;
               new roundvalue(context ).execute(  A85ProductCostPrice, out  GXt_decimal3) ;
               A88ProductWholesalePrice = ((A87ProductWholesaleProfit!=Convert.ToDecimal(0)) ? GXt_decimal2 : GXt_decimal3);
               E222L2 ();
               pr_default.readNext(3);
            }
            ALLPRODUCTS_nEOF = (short)(((pr_default.getStatus(3) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "ALLPRODUCTS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(ALLPRODUCTS_nEOF), 1, 0, ".", "")));
            pr_default.close(3);
            wbEnd = 39;
            WB2L0( ) ;
         }
         bGXsfl_39_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2L2( )
      {
         GxWebStd.gx_hidden_field( context, "vNEWNAME", AV32newName);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV32newName, "")), context));
         GxWebStd.gx_hidden_field( context, "vNEWCODE", AV33newCode);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV33newCode, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUCTID"+"_"+sGXsfl_39_idx, GetSecureSignedToken( sGXsfl_39_idx, context.localUtil.Format( (decimal)(A15ProductId), "ZZZZZ9"), context));
      }

      protected void RF2L3( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            WholesalefgridContainer.ClearRows();
         }
         wbStart = 94;
         E152L2 ();
         nGXsfl_94_idx = 1;
         sGXsfl_94_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_94_idx), 4, 0), 4, "0");
         SubsflControlProps_943( ) ;
         bGXsfl_94_Refreshing = true;
         WholesalefgridContainer.AddObjectProperty("GridName", "Wholesalefgrid");
         WholesalefgridContainer.AddObjectProperty("CmpContext", "");
         WholesalefgridContainer.AddObjectProperty("InMasterPage", "false");
         WholesalefgridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         WholesalefgridContainer.AddObjectProperty("Class", "FreeStyleGrid");
         WholesalefgridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         WholesalefgridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         WholesalefgridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subWholesalefgrid_Backcolorstyle), 1, 0, ".", "")));
         WholesalefgridContainer.PageSize = subWholesalefgrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_943( ) ;
            E182L3 ();
            wbEnd = 94;
            WB2L0( ) ;
         }
         bGXsfl_94_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2L3( )
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
         /* Using cursor H002L6 */
         pr_default.execute(4, new Object[] {lV9Code, lV16Name, AV23Supplier, AV8Brand, AV22Sector});
         ALLPRODUCTS_nRecordCount = H002L6_AALLPRODUCTS_nRecordCount[0];
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
            gxgrAllproducts_refresh( subAllproducts_Rows, AV9Code, AV16Name, AV23Supplier, AV8Brand, AV22Sector, AV32newName, AV33newCode) ;
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
            gxgrAllproducts_refresh( subAllproducts_Rows, AV9Code, AV16Name, AV23Supplier, AV8Brand, AV22Sector, AV32newName, AV33newCode) ;
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
            gxgrAllproducts_refresh( subAllproducts_Rows, AV9Code, AV16Name, AV23Supplier, AV8Brand, AV22Sector, AV32newName, AV33newCode) ;
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
            gxgrAllproducts_refresh( subAllproducts_Rows, AV9Code, AV16Name, AV23Supplier, AV8Brand, AV22Sector, AV32newName, AV33newCode) ;
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
            gxgrAllproducts_refresh( subAllproducts_Rows, AV9Code, AV16Name, AV23Supplier, AV8Brand, AV22Sector, AV32newName, AV33newCode) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected int subWholesalefgrid_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subWholesalefgrid_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subWholesalefgrid_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subWholesalefgrid_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavCtlcode2_Enabled = 0;
         AssignProp("", false, edtavCtlcode2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcode2_Enabled), 5, 0), !bGXsfl_94_Refreshing);
         edtavCtlname2_Enabled = 0;
         AssignProp("", false, edtavCtlname2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname2_Enabled), 5, 0), !bGXsfl_94_Refreshing);
         edtavCtlsupplier2_Enabled = 0;
         AssignProp("", false, edtavCtlsupplier2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsupplier2_Enabled), 5, 0), !bGXsfl_94_Refreshing);
         edtavCtlbrand2_Enabled = 0;
         AssignProp("", false, edtavCtlbrand2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlbrand2_Enabled), 5, 0), !bGXsfl_94_Refreshing);
         edtavCtlsector2_Enabled = 0;
         AssignProp("", false, edtavCtlsector2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsector2_Enabled), 5, 0), !bGXsfl_94_Refreshing);
         edtavCtlcostprice2_Enabled = 0;
         AssignProp("", false, edtavCtlcostprice2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcostprice2_Enabled), 5, 0), !bGXsfl_94_Refreshing);
         edtavCtlwholesaleprofit1_Enabled = 0;
         AssignProp("", false, edtavCtlwholesaleprofit1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlwholesaleprofit1_Enabled), 5, 0), !bGXsfl_94_Refreshing);
         GXVvSUPPLIER_html2L2( ) ;
         GXVvBRAND_html2L2( ) ;
         GXVvSECTOR_html2L2( ) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2L0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E192L2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Productsselected"), AV19ProductsSelected);
            /* Read saved values. */
            nRC_GXsfl_39 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_39"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_94 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_94"), ".", ","), 18, MidpointRounding.ToEven));
            ALLPRODUCTS_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "ALLPRODUCTS_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            ALLPRODUCTS_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "ALLPRODUCTS_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            subAllproducts_Collapsed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "ALLPRODUCTS_Collapsed"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_94 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_94"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_94_fel_idx = 0;
            while ( nGXsfl_94_fel_idx < nRC_GXsfl_94 )
            {
               nGXsfl_94_fel_idx = ((subWholesalefgrid_Islastpage==1)&&(nGXsfl_94_fel_idx+1>subWholesalefgrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_94_fel_idx+1);
               sGXsfl_94_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_94_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_943( ) ;
               AV44GXV1 = nGXsfl_94_fel_idx;
               if ( ( AV19ProductsSelected.Count >= AV44GXV1 ) && ( AV44GXV1 > 0 ) )
               {
                  AV19ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV44GXV1));
                  AV41RemoveProduct = cgiGet( edtavRemoveproduct_Internalname);
               }
            }
            if ( nGXsfl_94_fel_idx == 0 )
            {
               nGXsfl_94_idx = 1;
               sGXsfl_94_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_94_idx), 4, 0), 4, "0");
               SubsflControlProps_943( ) ;
            }
            nGXsfl_94_fel_idx = 1;
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavNewwprofit_Internalname), ".", ",") < -9999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavNewwprofit_Internalname), ".", ",") > 99999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vNEWWPROFIT");
               GX_FocusControl = edtavNewwprofit_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV26NewWProfit = 0;
               AssignAttri("", false, "AV26NewWProfit", StringUtil.LTrimStr( AV26NewWProfit, 8, 2));
            }
            else
            {
               AV26NewWProfit = context.localUtil.CToN( cgiGet( edtavNewwprofit_Internalname), ".", ",");
               AssignAttri("", false, "AV26NewWProfit", StringUtil.LTrimStr( AV26NewWProfit, 8, 2));
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
         E192L2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E192L2( )
      {
         /* Start Routine */
         returnInSub = false;
         new getcontext(context ).execute( out  AV39Context, ref  AV7AllOk) ;
         AssignAttri("", false, "AV7AllOk", AV7AllOk);
         if ( ! AV7AllOk )
         {
            AV40WebSession.Set("SecLogIn", "Error");
            CallWebObject(formatLink("wplogin.aspx") );
            context.wjLocDisableFrm = 1;
         }
         divWholesaleprofittable_Visible = 0;
         AssignProp("", false, divWholesaleprofittable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divWholesaleprofittable_Visible), 5, 0), true);
         divButtonstable_Visible = 0;
         AssignProp("", false, divButtonstable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divButtonstable_Visible), 5, 0), true);
         bttUpdate_Jsonclick = "confirm('Are you sure to update Cost Price?')";
         AssignProp("", false, bttUpdate_Internalname, "Jsonclick", bttUpdate_Jsonclick, true);
         bttCancel_Jsonclick = "confirm('Are you sure to cancel the update?')";
         AssignProp("", false, bttCancel_Internalname, "Jsonclick", bttCancel_Jsonclick, true);
      }

      protected void E202L2( )
      {
         AV44GXV1 = nGXsfl_94_idx;
         if ( ( AV44GXV1 > 0 ) && ( AV19ProductsSelected.Count >= AV44GXV1 ) )
         {
            AV19ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV44GXV1));
         }
         /* ProductName_Click Routine */
         returnInSub = false;
         if ( AV14IdsSelected.Count == 0 )
         {
            divWholesaleprofittable_Visible = 1;
            AssignProp("", false, divWholesaleprofittable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divWholesaleprofittable_Visible), 5, 0), true);
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
            if ( ( AV26NewWProfit > Convert.ToDecimal( 0 )) )
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
            AV54GXV11 = 1;
            while ( AV54GXV11 <= AV19ProductsSelected.Count )
            {
               AV17OneProduct = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV54GXV11));
               AV20ProductsSelectedAux.Add(AV17OneProduct, 0);
               AV15IdsSelectedAux.Add(AV17OneProduct.gxTpr_Id, 0);
               AV54GXV11 = (int)(AV54GXV11+1);
            }
            AV19ProductsSelected.Clear();
            gx_BV94 = true;
            AV14IdsSelected.Clear();
            AV19ProductsSelected = (GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem>)(AV20ProductsSelectedAux.Clone());
            gx_BV94 = true;
            AV14IdsSelected = (GxSimpleCollection<int>)(AV15IdsSelectedAux.Clone());
            AV20ProductsSelectedAux.Clear();
            AV15IdsSelectedAux.Clear();
            gxgrWholesalefgrid_refresh( subAllproducts_Rows, AV9Code, AV16Name, AV23Supplier, AV8Brand, AV22Sector, AV32newName, AV33newCode) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17OneProduct", AV17OneProduct);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20ProductsSelectedAux", AV20ProductsSelectedAux);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15IdsSelectedAux", AV15IdsSelectedAux);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19ProductsSelected", AV19ProductsSelected);
         nGXsfl_94_bak_idx = nGXsfl_94_idx;
         gxgrWholesalefgrid_refresh( subAllproducts_Rows, AV9Code, AV16Name, AV23Supplier, AV8Brand, AV22Sector, AV32newName, AV33newCode) ;
         nGXsfl_94_idx = nGXsfl_94_bak_idx;
         sGXsfl_94_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_94_idx), 4, 0), 4, "0");
         SubsflControlProps_943( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14IdsSelected", AV14IdsSelected);
      }

      protected void E112L2( )
      {
         AV44GXV1 = nGXsfl_94_idx;
         if ( ( AV44GXV1 > 0 ) && ( AV19ProductsSelected.Count >= AV44GXV1 ) )
         {
            AV19ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV44GXV1));
         }
         /* Newwprofit_Controlvaluechanged Routine */
         returnInSub = false;
         AV55GXV12 = 1;
         while ( AV55GXV12 <= AV19ProductsSelected.Count )
         {
            AV17OneProduct = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV55GXV12));
            AV17OneProduct.gxTpr_Newwholesaleprofit = AV26NewWProfit;
            GXt_decimal3 = 0;
            new roundvalue(context ).execute(  AV17OneProduct.gxTpr_Costprice*(1+AV26NewWProfit/ (decimal)(100)), out  GXt_decimal3) ;
            AV17OneProduct.gxTpr_Wholesaleprice = GXt_decimal3;
            AV55GXV12 = (int)(AV55GXV12+1);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17OneProduct", AV17OneProduct);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19ProductsSelected", AV19ProductsSelected);
         nGXsfl_94_bak_idx = nGXsfl_94_idx;
         gxgrWholesalefgrid_refresh( subAllproducts_Rows, AV9Code, AV16Name, AV23Supplier, AV8Brand, AV22Sector, AV32newName, AV33newCode) ;
         nGXsfl_94_idx = nGXsfl_94_bak_idx;
         sGXsfl_94_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_94_idx), 4, 0), 4, "0");
         SubsflControlProps_943( ) ;
      }

      protected void E142L2( )
      {
         AV44GXV1 = nGXsfl_94_idx;
         if ( ( AV44GXV1 > 0 ) && ( AV19ProductsSelected.Count >= AV44GXV1 ) )
         {
            AV19ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV44GXV1));
         }
         /* Removeproduct_Click Routine */
         returnInSub = false;
         AV29Position = (short)(AV14IdsSelected.IndexOf(((SdtSDTProductsSelected_SDTProductsSelectedItem)(AV19ProductsSelected.CurrentItem)).gxTpr_Id));
         AV19ProductsSelected.RemoveItem(AV29Position);
         gx_BV94 = true;
         AV14IdsSelected.RemoveItem(AV29Position);
         gxgrWholesalefgrid_refresh( subAllproducts_Rows, AV9Code, AV16Name, AV23Supplier, AV8Brand, AV22Sector, AV32newName, AV33newCode) ;
         if ( AV14IdsSelected.Count == 0 )
         {
            divWholesaleprofittable_Visible = 0;
            AssignProp("", false, divWholesaleprofittable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divWholesaleprofittable_Visible), 5, 0), true);
            divButtonstable_Visible = 0;
            AssignProp("", false, divButtonstable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divButtonstable_Visible), 5, 0), true);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19ProductsSelected", AV19ProductsSelected);
         nGXsfl_94_bak_idx = nGXsfl_94_idx;
         gxgrWholesalefgrid_refresh( subAllproducts_Rows, AV9Code, AV16Name, AV23Supplier, AV8Brand, AV22Sector, AV32newName, AV33newCode) ;
         nGXsfl_94_idx = nGXsfl_94_bak_idx;
         sGXsfl_94_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_94_idx), 4, 0), 4, "0");
         SubsflControlProps_943( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14IdsSelected", AV14IdsSelected);
      }

      protected void E152L2( )
      {
         /* Wholesalefgrid_Refresh Routine */
         returnInSub = false;
         edtavRemoveproduct_gximage = "GeneXusUnanimo_delete_light";
         AssignProp("", false, edtavRemoveproduct_Internalname, "gximage", edtavRemoveproduct_gximage, !bGXsfl_94_Refreshing);
         AV41RemoveProduct = context.GetImagePath( "db0f63cd-dde8-4bf7-aca2-01cdf8d3c157", "", context.GetTheme( ));
         AssignProp("", false, edtavRemoveproduct_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV41RemoveProduct)) ? AV56Removeproduct_GXI : context.convertURL( context.PathToRelativeUrl( AV41RemoveProduct))), !bGXsfl_94_Refreshing);
         AssignProp("", false, edtavRemoveproduct_Internalname, "SrcSet", context.GetImageSrcSet( AV41RemoveProduct), true);
         AV56Removeproduct_GXI = GXDbFile.PathToUrl( context.GetImagePath( "db0f63cd-dde8-4bf7-aca2-01cdf8d3c157", "", context.GetTheme( )));
         AssignProp("", false, edtavRemoveproduct_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV41RemoveProduct)) ? AV56Removeproduct_GXI : context.convertURL( context.PathToRelativeUrl( AV41RemoveProduct))), !bGXsfl_94_Refreshing);
         AssignProp("", false, edtavRemoveproduct_Internalname, "SrcSet", context.GetImageSrcSet( AV41RemoveProduct), true);
         /*  Sending Event outputs  */
      }

      protected void E122L2( )
      {
         AV44GXV1 = nGXsfl_94_idx;
         if ( ( AV44GXV1 > 0 ) && ( AV19ProductsSelected.Count >= AV44GXV1 ) )
         {
            AV19ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV44GXV1));
         }
         /* 'Update' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'WPROFITCONTROL' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV7AllOk )
         {
            new productupdate(context ).execute(  AV19ProductsSelected, ref  AV37ErrorMessage, ref  AV7AllOk) ;
            AssignAttri("", false, "AV7AllOk", AV7AllOk);
            if ( AV7AllOk )
            {
               GX_msglist.addItem("Update succesfull");
               AV14IdsSelected.Clear();
               AV19ProductsSelected.Clear();
               gx_BV94 = true;
               gxgrAllproducts_refresh( subAllproducts_Rows, AV9Code, AV16Name, AV23Supplier, AV8Brand, AV22Sector, AV32newName, AV33newCode) ;
               divWholesaleprofittable_Visible = 0;
               AssignProp("", false, divWholesaleprofittable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divWholesaleprofittable_Visible), 5, 0), true);
               divButtonstable_Visible = 0;
               AssignProp("", false, divButtonstable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divButtonstable_Visible), 5, 0), true);
            }
            else
            {
               GX_msglist.addItem(AV37ErrorMessage.gxTpr_Description);
            }
         }
         else
         {
            GX_msglist.addItem(AV37ErrorMessage.gxTpr_Description);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV37ErrorMessage", AV37ErrorMessage);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14IdsSelected", AV14IdsSelected);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19ProductsSelected", AV19ProductsSelected);
         nGXsfl_94_bak_idx = nGXsfl_94_idx;
         gxgrWholesalefgrid_refresh( subAllproducts_Rows, AV9Code, AV16Name, AV23Supplier, AV8Brand, AV22Sector, AV32newName, AV33newCode) ;
         nGXsfl_94_idx = nGXsfl_94_bak_idx;
         sGXsfl_94_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_94_idx), 4, 0), 4, "0");
         SubsflControlProps_943( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17OneProduct", AV17OneProduct);
      }

      protected void E212L2( )
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
         if ( gx_BV94 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19ProductsSelected", AV19ProductsSelected);
            nGXsfl_94_bak_idx = nGXsfl_94_idx;
            gxgrWholesalefgrid_refresh( subAllproducts_Rows, AV9Code, AV16Name, AV23Supplier, AV8Brand, AV22Sector, AV32newName, AV33newCode) ;
            nGXsfl_94_idx = nGXsfl_94_bak_idx;
            sGXsfl_94_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_94_idx), 4, 0), 4, "0");
            SubsflControlProps_943( ) ;
         }
      }

      protected void E162L2( )
      {
         AV44GXV1 = nGXsfl_94_idx;
         if ( ( AV44GXV1 > 0 ) && ( AV19ProductsSelected.Count >= AV44GXV1 ) )
         {
            AV19ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV44GXV1));
         }
         /* Ctlnewwholesaleprofit_Controlvaluechanged Routine */
         returnInSub = false;
         AV17OneProduct = new SdtSDTProductsSelected_SDTProductsSelectedItem(context);
         AV17OneProduct = ((SdtSDTProductsSelected_SDTProductsSelectedItem)(AV19ProductsSelected.CurrentItem));
         AV17OneProduct.gxTpr_Wholesaleprice = (decimal)(AV17OneProduct.gxTpr_Costprice*(1+AV17OneProduct.gxTpr_Newwholesaleprofit/ (decimal)(100)));
         GXt_decimal3 = 0;
         new roundvalue(context ).execute(  AV17OneProduct.gxTpr_Wholesaleprice, out  GXt_decimal3) ;
         ((SdtSDTProductsSelected_SDTProductsSelectedItem)(AV19ProductsSelected.CurrentItem)).gxTpr_Wholesaleprice = GXt_decimal3;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17OneProduct", AV17OneProduct);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19ProductsSelected", AV19ProductsSelected);
         nGXsfl_94_bak_idx = nGXsfl_94_idx;
         gxgrWholesalefgrid_refresh( subAllproducts_Rows, AV9Code, AV16Name, AV23Supplier, AV8Brand, AV22Sector, AV32newName, AV33newCode) ;
         nGXsfl_94_idx = nGXsfl_94_bak_idx;
         sGXsfl_94_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_94_idx), 4, 0), 4, "0");
         SubsflControlProps_943( ) ;
      }

      protected void E172L2( )
      {
         AV44GXV1 = nGXsfl_94_idx;
         if ( ( AV44GXV1 > 0 ) && ( AV19ProductsSelected.Count >= AV44GXV1 ) )
         {
            AV19ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV44GXV1));
         }
         /* Ctlwholesaleprice_Controlvaluechanged Routine */
         returnInSub = false;
         AV17OneProduct = new SdtSDTProductsSelected_SDTProductsSelectedItem(context);
         AV17OneProduct = ((SdtSDTProductsSelected_SDTProductsSelectedItem)(AV19ProductsSelected.CurrentItem));
         GXt_decimal3 = 0;
         new roundvalue(context ).execute(  AV17OneProduct.gxTpr_Wholesaleprice, out  GXt_decimal3) ;
         AV17OneProduct.gxTpr_Wholesaleprice = GXt_decimal3;
         AV17OneProduct.gxTpr_Newwholesaleprofit = (decimal)(((AV17OneProduct.gxTpr_Wholesaleprice/ (decimal)(AV17OneProduct.gxTpr_Costprice))-1)*100);
         ((SdtSDTProductsSelected_SDTProductsSelectedItem)(AV19ProductsSelected.CurrentItem)).gxTpr_Wholesaleprice = AV17OneProduct.gxTpr_Wholesaleprice;
         ((SdtSDTProductsSelected_SDTProductsSelectedItem)(AV19ProductsSelected.CurrentItem)).gxTpr_Newwholesaleprofit = AV17OneProduct.gxTpr_Newwholesaleprofit;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17OneProduct", AV17OneProduct);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19ProductsSelected", AV19ProductsSelected);
         nGXsfl_94_bak_idx = nGXsfl_94_idx;
         gxgrWholesalefgrid_refresh( subAllproducts_Rows, AV9Code, AV16Name, AV23Supplier, AV8Brand, AV22Sector, AV32newName, AV33newCode) ;
         nGXsfl_94_idx = nGXsfl_94_bak_idx;
         sGXsfl_94_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_94_idx), 4, 0), 4, "0");
         SubsflControlProps_943( ) ;
      }

      protected void E132L2( )
      {
         AV44GXV1 = nGXsfl_94_idx;
         if ( ( AV44GXV1 > 0 ) && ( AV19ProductsSelected.Count >= AV44GXV1 ) )
         {
            AV19ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV44GXV1));
         }
         /* 'SelectAll' Routine */
         returnInSub = false;
         AV19ProductsSelected.Clear();
         gx_BV94 = true;
         GXt_objcol_SdtSDTProductsSelected_SDTProductsSelectedItem5 = AV19ProductsSelected;
         new updateselectall(context ).execute(  AV9Code, ref  AV16Name, ref  AV23Supplier, ref  AV8Brand, ref  AV22Sector, out  GXt_objcol_SdtSDTProductsSelected_SDTProductsSelectedItem5) ;
         AssignAttri("", false, "AV16Name", AV16Name);
         AssignAttri("", false, "AV23Supplier", StringUtil.LTrimStr( (decimal)(AV23Supplier), 6, 0));
         AssignAttri("", false, "AV8Brand", StringUtil.LTrimStr( (decimal)(AV8Brand), 6, 0));
         AssignAttri("", false, "AV22Sector", StringUtil.LTrimStr( (decimal)(AV22Sector), 6, 0));
         AV19ProductsSelected = GXt_objcol_SdtSDTProductsSelected_SDTProductsSelectedItem5;
         gx_BV94 = true;
         if ( ( AV26NewWProfit > Convert.ToDecimal( 0 )) )
         {
            /* Execute user subroutine: 'CALCULATEALL' */
            S152 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            gxgrWholesalefgrid_refresh( subAllproducts_Rows, AV9Code, AV16Name, AV23Supplier, AV8Brand, AV22Sector, AV32newName, AV33newCode) ;
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
            divWholesaleprofittable_Visible = 1;
            AssignProp("", false, divWholesaleprofittable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divWholesaleprofittable_Visible), 5, 0), true);
            divButtonstable_Visible = 1;
            AssignProp("", false, divButtonstable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divButtonstable_Visible), 5, 0), true);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19ProductsSelected", AV19ProductsSelected);
         nGXsfl_94_bak_idx = nGXsfl_94_idx;
         gxgrWholesalefgrid_refresh( subAllproducts_Rows, AV9Code, AV16Name, AV23Supplier, AV8Brand, AV22Sector, AV32newName, AV33newCode) ;
         nGXsfl_94_idx = nGXsfl_94_bak_idx;
         sGXsfl_94_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_94_idx), 4, 0), 4, "0");
         SubsflControlProps_943( ) ;
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
         /* 'WPROFITCONTROL' Routine */
         returnInSub = false;
         AV37ErrorMessage.gxTpr_Description = "";
         AV7AllOk = true;
         AssignAttri("", false, "AV7AllOk", AV7AllOk);
         if ( AV14IdsSelected.Count <= 0 )
         {
            AV7AllOk = false;
            AssignAttri("", false, "AV7AllOk", AV7AllOk);
            AV37ErrorMessage.gxTpr_Description = AV37ErrorMessage.gxTpr_Description+"Select at least one product ";
         }
         else if ( ( AV26NewWProfit < Convert.ToDecimal( 0 )) || ( AV26NewWProfit > Convert.ToDecimal( 999 )) )
         {
            AV7AllOk = false;
            AssignAttri("", false, "AV7AllOk", AV7AllOk);
            AV37ErrorMessage.gxTpr_Description = AV37ErrorMessage.gxTpr_Description+"Invalid New Profit ";
         }
         else
         {
            AV7AllOk = true;
            AssignAttri("", false, "AV7AllOk", AV7AllOk);
         }
         /* Execute user subroutine: 'NEWWPROFITCONTROL' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'NEWWPRICECONTROL' */
         S182 ();
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
         if ( ( AV26NewWProfit >= Convert.ToDecimal( 0 )) && ( AV26NewWProfit <= Convert.ToDecimal( 999 )) )
         {
            AV17OneProduct.gxTpr_Newwholesaleprofit = AV26NewWProfit;
            GXt_decimal3 = 0;
            new roundvalue(context ).execute(  AV17OneProduct.gxTpr_Costprice*(1+AV26NewWProfit/ (decimal)(100)), out  GXt_decimal3) ;
            AV17OneProduct.gxTpr_Wholesaleprice = GXt_decimal3;
         }
         else
         {
            GX_msglist.addItem("New W. Profit Invalid");
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
         /* 'NEWWPROFITCONTROL' Routine */
         returnInSub = false;
         AV57GXV13 = 1;
         while ( AV57GXV13 <= AV19ProductsSelected.Count )
         {
            AV17OneProduct = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV57GXV13));
            if ( ( AV17OneProduct.gxTpr_Newwholesaleprofit < Convert.ToDecimal( 0 )) || ( AV17OneProduct.gxTpr_Newwholesaleprofit > Convert.ToDecimal( 999 )) )
            {
               AV37ErrorMessage.gxTpr_Description = AV37ErrorMessage.gxTpr_Description+"Some new profit is invalid";
               AV7AllOk = false;
               AssignAttri("", false, "AV7AllOk", AV7AllOk);
               if (true) break;
            }
            AV57GXV13 = (int)(AV57GXV13+1);
         }
      }

      protected void S182( )
      {
         /* 'NEWWPRICECONTROL' Routine */
         returnInSub = false;
         AV58GXV14 = 1;
         while ( AV58GXV14 <= AV19ProductsSelected.Count )
         {
            AV17OneProduct = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV58GXV14));
            if ( ( AV17OneProduct.gxTpr_Wholesaleprice < Convert.ToDecimal( 0 )) || ( AV17OneProduct.gxTpr_Wholesaleprice > Convert.ToDecimal( 999 )) )
            {
               AV37ErrorMessage.gxTpr_Description = AV37ErrorMessage.gxTpr_Description+"Some new price is invalid";
               AV7AllOk = false;
               AssignAttri("", false, "AV7AllOk", AV7AllOk);
               if (true) break;
            }
            AV58GXV14 = (int)(AV58GXV14+1);
         }
      }

      protected void S142( )
      {
         /* 'CLEARSELECTED' Routine */
         returnInSub = false;
         AV14IdsSelected.Clear();
         AV19ProductsSelected.Clear();
         gx_BV94 = true;
         divWholesaleprofittable_Visible = 0;
         AssignProp("", false, divWholesaleprofittable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divWholesaleprofittable_Visible), 5, 0), true);
         divButtonstable_Visible = 0;
         AssignProp("", false, divButtonstable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divButtonstable_Visible), 5, 0), true);
      }

      protected void S152( )
      {
         /* 'CALCULATEALL' Routine */
         returnInSub = false;
         AV59GXV15 = 1;
         while ( AV59GXV15 <= AV19ProductsSelected.Count )
         {
            AV17OneProduct = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV59GXV15));
            AV17OneProduct.gxTpr_Newwholesaleprofit = AV26NewWProfit;
            GXt_decimal3 = 0;
            new roundvalue(context ).execute(  AV17OneProduct.gxTpr_Costprice*(1+AV26NewWProfit/ (decimal)(100)), out  GXt_decimal3) ;
            AV17OneProduct.gxTpr_Wholesaleprice = GXt_decimal3;
            AV59GXV15 = (int)(AV59GXV15+1);
         }
      }

      protected void S162( )
      {
         /* 'REGISTERIDS' Routine */
         returnInSub = false;
         AV14IdsSelected.Clear();
         AV60GXV16 = 1;
         while ( AV60GXV16 <= AV19ProductsSelected.Count )
         {
            AV17OneProduct = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV60GXV16));
            AV14IdsSelected.Add(AV17OneProduct.gxTpr_Id, 0);
            AV60GXV16 = (int)(AV60GXV16+1);
         }
      }

      private void E222L2( )
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

      private void E182L3( )
      {
         /* Wholesalefgrid_Load Routine */
         returnInSub = false;
         AV44GXV1 = 1;
         while ( AV44GXV1 <= AV19ProductsSelected.Count )
         {
            AV19ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV44GXV1));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 94;
            }
            sendrow_943( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_94_Refreshing )
            {
               DoAjaxLoad(94, WholesalefgridRow);
            }
            AV44GXV1 = (int)(AV44GXV1+1);
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
         PA2L2( ) ;
         WS2L2( ) ;
         WE2L2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024123317193", true, true);
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
         context.AddJavascriptSource("wpupdatewholesaleprofit.js", "?2024123317194", false, true);
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
         edtProductWholesaleProfit_Internalname = "PRODUCTWHOLESALEPROFIT_"+sGXsfl_39_idx;
         edtProductWholesalePrice_Internalname = "PRODUCTWHOLESALEPRICE_"+sGXsfl_39_idx;
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
         edtProductWholesaleProfit_Internalname = "PRODUCTWHOLESALEPROFIT_"+sGXsfl_39_fel_idx;
         edtProductWholesalePrice_Internalname = "PRODUCTWHOLESALEPRICE_"+sGXsfl_39_fel_idx;
      }

      protected void sendrow_392( )
      {
         SubsflControlProps_392( ) ;
         WB2L0( ) ;
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
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductWholesaleProfit_Internalname,StringUtil.LTrim( StringUtil.NToC( A87ProductWholesaleProfit, 8, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A87ProductWholesaleProfit, "ZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductWholesaleProfit_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"Percentage",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductWholesalePrice_Internalname,StringUtil.LTrim( StringUtil.NToC( A88ProductWholesalePrice, 18, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A88ProductWholesalePrice, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductWholesalePrice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"Price",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes2L2( ) ;
            AllproductsContainer.AddRow(AllproductsRow);
            nGXsfl_39_idx = ((subAllproducts_Islastpage==1)&&(nGXsfl_39_idx+1>subAllproducts_fnc_Recordsperpage( )) ? 1 : nGXsfl_39_idx+1);
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
         }
         /* End function sendrow_392 */
      }

      protected void SubsflControlProps_943( )
      {
         edtavRemoveproduct_Internalname = "vREMOVEPRODUCT_"+sGXsfl_94_idx;
         edtavCtlcode2_Internalname = "CTLCODE2_"+sGXsfl_94_idx;
         edtavCtlname2_Internalname = "CTLNAME2_"+sGXsfl_94_idx;
         edtavCtlsupplier2_Internalname = "CTLSUPPLIER2_"+sGXsfl_94_idx;
         edtavCtlbrand2_Internalname = "CTLBRAND2_"+sGXsfl_94_idx;
         edtavCtlsector2_Internalname = "CTLSECTOR2_"+sGXsfl_94_idx;
         edtavCtlcostprice2_Internalname = "CTLCOSTPRICE2_"+sGXsfl_94_idx;
         edtavCtlwholesaleprofit1_Internalname = "CTLWHOLESALEPROFIT1_"+sGXsfl_94_idx;
         edtavCtlnewwholesaleprofit_Internalname = "CTLNEWWHOLESALEPROFIT_"+sGXsfl_94_idx;
         edtavCtlwholesaleprice_Internalname = "CTLWHOLESALEPRICE_"+sGXsfl_94_idx;
      }

      protected void SubsflControlProps_fel_943( )
      {
         edtavRemoveproduct_Internalname = "vREMOVEPRODUCT_"+sGXsfl_94_fel_idx;
         edtavCtlcode2_Internalname = "CTLCODE2_"+sGXsfl_94_fel_idx;
         edtavCtlname2_Internalname = "CTLNAME2_"+sGXsfl_94_fel_idx;
         edtavCtlsupplier2_Internalname = "CTLSUPPLIER2_"+sGXsfl_94_fel_idx;
         edtavCtlbrand2_Internalname = "CTLBRAND2_"+sGXsfl_94_fel_idx;
         edtavCtlsector2_Internalname = "CTLSECTOR2_"+sGXsfl_94_fel_idx;
         edtavCtlcostprice2_Internalname = "CTLCOSTPRICE2_"+sGXsfl_94_fel_idx;
         edtavCtlwholesaleprofit1_Internalname = "CTLWHOLESALEPROFIT1_"+sGXsfl_94_fel_idx;
         edtavCtlnewwholesaleprofit_Internalname = "CTLNEWWHOLESALEPROFIT_"+sGXsfl_94_fel_idx;
         edtavCtlwholesaleprice_Internalname = "CTLWHOLESALEPRICE_"+sGXsfl_94_fel_idx;
      }

      protected void sendrow_943( )
      {
         SubsflControlProps_943( ) ;
         WB2L0( ) ;
         WholesalefgridRow = GXWebRow.GetNew(context,WholesalefgridContainer);
         if ( subWholesalefgrid_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subWholesalefgrid_Backstyle = 0;
            if ( StringUtil.StrCmp(subWholesalefgrid_Class, "") != 0 )
            {
               subWholesalefgrid_Linesclass = subWholesalefgrid_Class+"Odd";
            }
         }
         else if ( subWholesalefgrid_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subWholesalefgrid_Backstyle = 0;
            subWholesalefgrid_Backcolor = subWholesalefgrid_Allbackcolor;
            if ( StringUtil.StrCmp(subWholesalefgrid_Class, "") != 0 )
            {
               subWholesalefgrid_Linesclass = subWholesalefgrid_Class+"Uniform";
            }
         }
         else if ( subWholesalefgrid_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subWholesalefgrid_Backstyle = 1;
            if ( StringUtil.StrCmp(subWholesalefgrid_Class, "") != 0 )
            {
               subWholesalefgrid_Linesclass = subWholesalefgrid_Class+"Odd";
            }
            subWholesalefgrid_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subWholesalefgrid_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subWholesalefgrid_Backstyle = 1;
            if ( ((int)((nGXsfl_94_idx) % (2))) == 0 )
            {
               subWholesalefgrid_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subWholesalefgrid_Class, "") != 0 )
               {
                  subWholesalefgrid_Linesclass = subWholesalefgrid_Class+"Even";
               }
            }
            else
            {
               subWholesalefgrid_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subWholesalefgrid_Class, "") != 0 )
               {
                  subWholesalefgrid_Linesclass = subWholesalefgrid_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( WholesalefgridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subWholesalefgrid_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_94_idx+"\">") ;
         }
         /* Div Control */
         WholesalefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divGrid2table_Internalname+"_"+sGXsfl_94_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         WholesalefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         WholesalefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-1 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         WholesalefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavRemoveproduct_Enabled!=0)&&(edtavRemoveproduct_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 99,'',false,'',94)\"" : " ");
         ClassString = "Image" + " " + ((StringUtil.StrCmp(edtavRemoveproduct_gximage, "")==0) ? "" : "GX_Image_"+edtavRemoveproduct_gximage+"_Class");
         StyleString = "";
         AV41RemoveProduct_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV41RemoveProduct))&&String.IsNullOrEmpty(StringUtil.RTrim( AV56Removeproduct_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV41RemoveProduct)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV41RemoveProduct)) ? AV56Removeproduct_GXI : context.PathToRelativeUrl( AV41RemoveProduct));
         WholesalefgridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavRemoveproduct_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)1,(short)1,(string)"",(string)"",(short)0,(short)1,(short)1,(string)"chr",(short)0,(string)"row",(short)0,(short)0,(short)5,(string)edtavRemoveproduct_Jsonclick,"'"+""+"'"+",false,"+"'"+"EVREMOVEPRODUCT.CLICK."+sGXsfl_94_idx+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV41RemoveProduct_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         WholesalefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         WholesalefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         WholesalefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-1 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         WholesalefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         WholesalefgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcode2_Internalname,(string)"Code",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         WholesalefgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcode2_Internalname,((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV44GXV1)).gxTpr_Code,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcode2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlcode2_Enabled,(short)0,(string)"text",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)100,(short)0,(short)0,(short)94,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         WholesalefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         WholesalefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         WholesalefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         WholesalefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         WholesalefgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname2_Internalname,(string)"Name",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         WholesalefgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname2_Internalname,((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV44GXV1)).gxTpr_Name,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlname2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlname2_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)94,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         WholesalefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         WholesalefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         WholesalefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         WholesalefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         WholesalefgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsupplier2_Internalname,(string)"Supplier",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         WholesalefgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsupplier2_Internalname,((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV44GXV1)).gxTpr_Supplier,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlsupplier2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlsupplier2_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)94,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         WholesalefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         WholesalefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         WholesalefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         WholesalefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         WholesalefgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlbrand2_Internalname,(string)"Brand",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         WholesalefgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlbrand2_Internalname,((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV44GXV1)).gxTpr_Brand,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlbrand2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlbrand2_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)94,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         WholesalefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         WholesalefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         WholesalefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         WholesalefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         WholesalefgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsector2_Internalname,(string)"Sector",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         WholesalefgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsector2_Internalname,((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV44GXV1)).gxTpr_Sector,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlsector2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlsector2_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)94,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         WholesalefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         WholesalefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         WholesalefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         WholesalefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         WholesalefgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcostprice2_Internalname,(string)"Cost Price",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         WholesalefgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcostprice2_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV44GXV1)).gxTpr_Costprice, 18, 2, ".", "")),StringUtil.LTrim( ((edtavCtlcostprice2_Enabled!=0) ? context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV44GXV1)).gxTpr_Costprice, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV44GXV1)).gxTpr_Costprice, "ZZZZZZZZZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcostprice2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlcostprice2_Enabled,(short)0,(string)"text",(string)"",(short)18,(string)"chr",(short)1,(string)"row",(short)18,(short)0,(short)0,(short)94,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         WholesalefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         WholesalefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         WholesalefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         WholesalefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         WholesalefgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlwholesaleprofit1_Internalname,"W. Profit",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         WholesalefgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlwholesaleprofit1_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV44GXV1)).gxTpr_Wholesaleprofit, 7, 2, ".", "")),StringUtil.LTrim( ((edtavCtlwholesaleprofit1_Enabled!=0) ? context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV44GXV1)).gxTpr_Wholesaleprofit, "ZZZ9.99") : context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV44GXV1)).gxTpr_Wholesaleprofit, "ZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlwholesaleprofit1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlwholesaleprofit1_Enabled,(short)0,(string)"text",(string)"",(short)7,(string)"chr",(short)1,(string)"row",(short)7,(short)0,(short)0,(short)94,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         WholesalefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         WholesalefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         WholesalefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         WholesalefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         WholesalefgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlnewwholesaleprofit_Internalname,"New W. Profit",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         TempTags = " " + ((edtavCtlnewwholesaleprofit_Enabled!=0)&&(edtavCtlnewwholesaleprofit_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 123,'',false,'"+sGXsfl_94_idx+"',94)\"" : " ");
         ROClassString = "Attribute";
         WholesalefgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlnewwholesaleprofit_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV44GXV1)).gxTpr_Newwholesaleprofit, 7, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV44GXV1)).gxTpr_Newwholesaleprofit, "ZZZ9.99")),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+((edtavCtlnewwholesaleprofit_Enabled!=0)&&(edtavCtlnewwholesaleprofit_Visible!=0) ? " onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,123);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlnewwholesaleprofit_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)1,(short)0,(string)"text",(string)"",(short)7,(string)"chr",(short)1,(string)"row",(short)7,(short)0,(short)0,(short)94,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         WholesalefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         WholesalefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         WholesalefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         WholesalefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         sendrow_94330( ) ;
      }

      protected void sendrow_94330( )
      {
         /* Attribute/Variable Label */
         WholesalefgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlwholesaleprice_Internalname,"W. Price",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         TempTags = " " + ((edtavCtlwholesaleprice_Enabled!=0)&&(edtavCtlwholesaleprice_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 126,'',false,'"+sGXsfl_94_idx+"',94)\"" : " ");
         ROClassString = "Attribute";
         WholesalefgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlwholesaleprice_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV44GXV1)).gxTpr_Wholesaleprice, 18, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV19ProductsSelected.Item(AV44GXV1)).gxTpr_Wholesaleprice, "ZZZZZZZZZZZZZZ9.99")),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+((edtavCtlwholesaleprice_Enabled!=0)&&(edtavCtlwholesaleprice_Visible!=0) ? " onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,126);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlwholesaleprice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)1,(short)0,(string)"text",(string)"",(short)18,(string)"chr",(short)1,(string)"row",(short)18,(short)0,(short)0,(short)94,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         WholesalefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         WholesalefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         WholesalefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         WholesalefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         send_integrity_lvl_hashes2L3( ) ;
         /* End of Columns property logic. */
         WholesalefgridContainer.AddRow(WholesalefgridRow);
         nGXsfl_94_idx = ((subWholesalefgrid_Islastpage==1)&&(nGXsfl_94_idx+1>subWholesalefgrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_94_idx+1);
         sGXsfl_94_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_94_idx), 4, 0), 4, "0");
         SubsflControlProps_943( ) ;
         /* End function sendrow_943 */
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
            context.SendWebValue( "W. Profit") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "W. Price") ;
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
            AllproductsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A87ProductWholesaleProfit, 8, 2, ".", ""))));
            AllproductsContainer.AddColumnProperties(AllproductsColumn);
            AllproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A88ProductWholesalePrice, 18, 2, ".", ""))));
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

      protected void StartGridControl94( )
      {
         if ( WholesalefgridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"WholesalefgridContainer"+"DivS\" data-gxgridid=\"94\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subWholesalefgrid_Internalname, subWholesalefgrid_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            WholesalefgridContainer.AddObjectProperty("GridName", "Wholesalefgrid");
         }
         else
         {
            WholesalefgridContainer.AddObjectProperty("GridName", "Wholesalefgrid");
            WholesalefgridContainer.AddObjectProperty("Header", subWholesalefgrid_Header);
            WholesalefgridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            WholesalefgridContainer.AddObjectProperty("Class", "FreeStyleGrid");
            WholesalefgridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            WholesalefgridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            WholesalefgridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subWholesalefgrid_Backcolorstyle), 1, 0, ".", "")));
            WholesalefgridContainer.AddObjectProperty("CmpContext", "");
            WholesalefgridContainer.AddObjectProperty("InMasterPage", "false");
            WholesalefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            WholesalefgridContainer.AddColumnProperties(WholesalefgridColumn);
            WholesalefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            WholesalefgridContainer.AddColumnProperties(WholesalefgridColumn);
            WholesalefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            WholesalefgridContainer.AddColumnProperties(WholesalefgridColumn);
            WholesalefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            WholesalefgridContainer.AddColumnProperties(WholesalefgridColumn);
            WholesalefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            WholesalefgridColumn.AddObjectProperty("Value", context.convertURL( AV41RemoveProduct));
            WholesalefgridContainer.AddColumnProperties(WholesalefgridColumn);
            WholesalefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            WholesalefgridContainer.AddColumnProperties(WholesalefgridColumn);
            WholesalefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            WholesalefgridContainer.AddColumnProperties(WholesalefgridColumn);
            WholesalefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            WholesalefgridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlcode2_Enabled), 5, 0, ".", "")));
            WholesalefgridContainer.AddColumnProperties(WholesalefgridColumn);
            WholesalefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            WholesalefgridContainer.AddColumnProperties(WholesalefgridColumn);
            WholesalefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            WholesalefgridContainer.AddColumnProperties(WholesalefgridColumn);
            WholesalefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            WholesalefgridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlname2_Enabled), 5, 0, ".", "")));
            WholesalefgridContainer.AddColumnProperties(WholesalefgridColumn);
            WholesalefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            WholesalefgridContainer.AddColumnProperties(WholesalefgridColumn);
            WholesalefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            WholesalefgridContainer.AddColumnProperties(WholesalefgridColumn);
            WholesalefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            WholesalefgridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlsupplier2_Enabled), 5, 0, ".", "")));
            WholesalefgridContainer.AddColumnProperties(WholesalefgridColumn);
            WholesalefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            WholesalefgridContainer.AddColumnProperties(WholesalefgridColumn);
            WholesalefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            WholesalefgridContainer.AddColumnProperties(WholesalefgridColumn);
            WholesalefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            WholesalefgridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlbrand2_Enabled), 5, 0, ".", "")));
            WholesalefgridContainer.AddColumnProperties(WholesalefgridColumn);
            WholesalefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            WholesalefgridContainer.AddColumnProperties(WholesalefgridColumn);
            WholesalefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            WholesalefgridContainer.AddColumnProperties(WholesalefgridColumn);
            WholesalefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            WholesalefgridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlsector2_Enabled), 5, 0, ".", "")));
            WholesalefgridContainer.AddColumnProperties(WholesalefgridColumn);
            WholesalefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            WholesalefgridContainer.AddColumnProperties(WholesalefgridColumn);
            WholesalefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            WholesalefgridContainer.AddColumnProperties(WholesalefgridColumn);
            WholesalefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            WholesalefgridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlcostprice2_Enabled), 5, 0, ".", "")));
            WholesalefgridContainer.AddColumnProperties(WholesalefgridColumn);
            WholesalefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            WholesalefgridContainer.AddColumnProperties(WholesalefgridColumn);
            WholesalefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            WholesalefgridContainer.AddColumnProperties(WholesalefgridColumn);
            WholesalefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            WholesalefgridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlwholesaleprofit1_Enabled), 5, 0, ".", "")));
            WholesalefgridContainer.AddColumnProperties(WholesalefgridColumn);
            WholesalefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            WholesalefgridContainer.AddColumnProperties(WholesalefgridColumn);
            WholesalefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            WholesalefgridContainer.AddColumnProperties(WholesalefgridColumn);
            WholesalefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            WholesalefgridContainer.AddColumnProperties(WholesalefgridColumn);
            WholesalefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            WholesalefgridContainer.AddColumnProperties(WholesalefgridColumn);
            WholesalefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            WholesalefgridContainer.AddColumnProperties(WholesalefgridColumn);
            WholesalefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            WholesalefgridContainer.AddColumnProperties(WholesalefgridColumn);
            WholesalefgridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subWholesalefgrid_Selectedindex), 4, 0, ".", "")));
            WholesalefgridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subWholesalefgrid_Allowselection), 1, 0, ".", "")));
            WholesalefgridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subWholesalefgrid_Selectioncolor), 9, 0, ".", "")));
            WholesalefgridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subWholesalefgrid_Allowhovering), 1, 0, ".", "")));
            WholesalefgridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subWholesalefgrid_Hoveringcolor), 9, 0, ".", "")));
            WholesalefgridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subWholesalefgrid_Allowcollapsing), 1, 0, ".", "")));
            WholesalefgridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subWholesalefgrid_Collapsed), 1, 0, ".", "")));
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
         edtProductWholesaleProfit_Internalname = "PRODUCTWHOLESALEPROFIT";
         edtProductWholesalePrice_Internalname = "PRODUCTWHOLESALEPRICE";
         divTable1_Internalname = "TABLE1";
         edtavNewwprofit_Internalname = "vNEWWPROFIT";
         bttUpdate_Internalname = "UPDATE";
         bttCancel_Internalname = "CANCEL";
         divButtonstable_Internalname = "BUTTONSTABLE";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         lblTextblock19_Internalname = "TEXTBLOCK19";
         lblTextblock20_Internalname = "TEXTBLOCK20";
         lblTextblock21_Internalname = "TEXTBLOCK21";
         lblTextblock22_Internalname = "TEXTBLOCK22";
         lblTextblock23_Internalname = "TEXTBLOCK23";
         lblTextblock24_Internalname = "TEXTBLOCK24";
         lblTextblock25_Internalname = "TEXTBLOCK25";
         lblTextblock26_Internalname = "TEXTBLOCK26";
         lblTextblock27_Internalname = "TEXTBLOCK27";
         divTable4_Internalname = "TABLE4";
         edtavRemoveproduct_Internalname = "vREMOVEPRODUCT";
         edtavCtlcode2_Internalname = "CTLCODE2";
         edtavCtlname2_Internalname = "CTLNAME2";
         edtavCtlsupplier2_Internalname = "CTLSUPPLIER2";
         edtavCtlbrand2_Internalname = "CTLBRAND2";
         edtavCtlsector2_Internalname = "CTLSECTOR2";
         edtavCtlcostprice2_Internalname = "CTLCOSTPRICE2";
         edtavCtlwholesaleprofit1_Internalname = "CTLWHOLESALEPROFIT1";
         edtavCtlnewwholesaleprofit_Internalname = "CTLNEWWHOLESALEPROFIT";
         edtavCtlwholesaleprice_Internalname = "CTLWHOLESALEPRICE";
         divGrid2table_Internalname = "GRID2TABLE";
         divWholesaleprofittable_Internalname = "WHOLESALEPROFITTABLE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subAllproducts_Internalname = "ALLPRODUCTS";
         subWholesalefgrid_Internalname = "WHOLESALEFGRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("mtaKB", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subWholesalefgrid_Allowcollapsing = 0;
         subAllproducts_Allowcollapsing = 1;
         subAllproducts_Allowselection = 0;
         subAllproducts_Header = "";
         edtavCtlwholesaleprice_Jsonclick = "";
         edtavCtlwholesaleprice_Visible = 1;
         edtavCtlwholesaleprice_Enabled = 1;
         edtavCtlnewwholesaleprofit_Jsonclick = "";
         edtavCtlnewwholesaleprofit_Visible = 1;
         edtavCtlnewwholesaleprofit_Enabled = 1;
         edtavCtlwholesaleprofit1_Jsonclick = "";
         edtavCtlwholesaleprofit1_Enabled = 0;
         edtavCtlcostprice2_Jsonclick = "";
         edtavCtlcostprice2_Enabled = 0;
         edtavCtlsector2_Jsonclick = "";
         edtavCtlsector2_Enabled = 0;
         edtavCtlbrand2_Jsonclick = "";
         edtavCtlbrand2_Enabled = 0;
         edtavCtlsupplier2_Jsonclick = "";
         edtavCtlsupplier2_Enabled = 0;
         edtavCtlname2_Jsonclick = "";
         edtavCtlname2_Enabled = 0;
         edtavCtlcode2_Jsonclick = "";
         edtavCtlcode2_Enabled = 0;
         edtavRemoveproduct_Jsonclick = "";
         edtavRemoveproduct_Visible = 1;
         edtavRemoveproduct_Enabled = 1;
         subWholesalefgrid_Class = "FreeStyleGrid";
         edtProductWholesalePrice_Jsonclick = "";
         edtProductWholesaleProfit_Jsonclick = "";
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
         subWholesalefgrid_Backcolorstyle = 0;
         edtavCtlwholesaleprofit1_Enabled = -1;
         edtavCtlcostprice2_Enabled = -1;
         edtavCtlsector2_Enabled = -1;
         edtavCtlbrand2_Enabled = -1;
         edtavCtlsupplier2_Enabled = -1;
         edtavCtlname2_Enabled = -1;
         edtavCtlcode2_Enabled = -1;
         divWholesaleprofittable_Visible = 1;
         edtavNewwprofit_Jsonclick = "";
         edtavNewwprofit_Enabled = 1;
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
         Form.Caption = "WPUpdate Wholesale Profit";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'WHOLESALEFGRID_nFirstRecordOnPage'},{av:'WHOLESALEFGRID_nEOF'},{av:'AV19ProductsSelected',fld:'vPRODUCTSSELECTED',grid:94,pic:''},{av:'nGXsfl_94_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:94},{av:'nRC_GXsfl_94',ctrl:'WHOLESALEFGRID',prop:'GridRC',grid:94},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV9Code',fld:'vCODE',pic:''},{av:'AV16Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV23Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV22Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV32newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV33newCode',fld:'vNEWCODE',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("PRODUCTNAME.CLICK","{handler:'E202L2',iparms:[{av:'WHOLESALEFGRID_nFirstRecordOnPage'},{av:'WHOLESALEFGRID_nEOF'},{av:'AV19ProductsSelected',fld:'vPRODUCTSSELECTED',grid:94,pic:''},{av:'nGXsfl_94_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:94},{av:'nRC_GXsfl_94',ctrl:'WHOLESALEFGRID',prop:'GridRC',grid:94},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV9Code',fld:'vCODE',pic:''},{av:'AV16Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV23Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV22Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV32newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV33newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'AV14IdsSelected',fld:'vIDSSELECTED',pic:''},{av:'A15ProductId',fld:'PRODUCTID',pic:'ZZZZZ9',hsh:true},{av:'AV30IsIn',fld:'vISIN',pic:''},{av:'AV26NewWProfit',fld:'vNEWWPROFIT',pic:'ZZZZ9.99'},{av:'AV20ProductsSelectedAux',fld:'vPRODUCTSSELECTEDAUX',pic:''},{av:'AV15IdsSelectedAux',fld:'vIDSSELECTEDAUX',pic:''},{av:'AV31IdSelected',fld:'vIDSELECTED',pic:'ZZZZZ9'},{av:'AV17OneProduct',fld:'vONEPRODUCT',pic:''},{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'}]");
         setEventMetadata("PRODUCTNAME.CLICK",",oparms:[{av:'divWholesaleprofittable_Visible',ctrl:'WHOLESALEPROFITTABLE',prop:'Visible'},{av:'divButtonstable_Visible',ctrl:'BUTTONSTABLE',prop:'Visible'},{av:'AV31IdSelected',fld:'vIDSELECTED',pic:'ZZZZZ9'},{av:'AV17OneProduct',fld:'vONEPRODUCT',pic:''},{av:'AV20ProductsSelectedAux',fld:'vPRODUCTSSELECTEDAUX',pic:''},{av:'AV15IdsSelectedAux',fld:'vIDSSELECTEDAUX',pic:''},{av:'AV19ProductsSelected',fld:'vPRODUCTSSELECTED',grid:94,pic:''},{av:'nGXsfl_94_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:94},{av:'WHOLESALEFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_94',ctrl:'WHOLESALEFGRID',prop:'GridRC',grid:94},{av:'AV14IdsSelected',fld:'vIDSSELECTED',pic:''},{av:'AV30IsIn',fld:'vISIN',pic:''}]}");
         setEventMetadata("VNEWWPROFIT.CONTROLVALUECHANGED","{handler:'E112L2',iparms:[{av:'AV19ProductsSelected',fld:'vPRODUCTSSELECTED',grid:94,pic:''},{av:'nGXsfl_94_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:94},{av:'WHOLESALEFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_94',ctrl:'WHOLESALEFGRID',prop:'GridRC',grid:94},{av:'AV26NewWProfit',fld:'vNEWWPROFIT',pic:'ZZZZ9.99'},{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'WHOLESALEFGRID_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV9Code',fld:'vCODE',pic:''},{av:'AV16Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV23Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV22Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV32newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV33newCode',fld:'vNEWCODE',pic:'',hsh:true}]");
         setEventMetadata("VNEWWPROFIT.CONTROLVALUECHANGED",",oparms:[{av:'AV17OneProduct',fld:'vONEPRODUCT',pic:''},{av:'AV19ProductsSelected',fld:'vPRODUCTSSELECTED',grid:94,pic:''},{av:'nGXsfl_94_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:94},{av:'WHOLESALEFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_94',ctrl:'WHOLESALEFGRID',prop:'GridRC',grid:94}]}");
         setEventMetadata("VREMOVEPRODUCT.CLICK","{handler:'E142L2',iparms:[{av:'WHOLESALEFGRID_nFirstRecordOnPage'},{av:'WHOLESALEFGRID_nEOF'},{av:'AV19ProductsSelected',fld:'vPRODUCTSSELECTED',grid:94,pic:''},{av:'nGXsfl_94_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:94},{av:'nRC_GXsfl_94',ctrl:'WHOLESALEFGRID',prop:'GridRC',grid:94},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV9Code',fld:'vCODE',pic:''},{av:'AV16Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV23Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV22Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV32newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV33newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'AV14IdsSelected',fld:'vIDSSELECTED',pic:''},{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'}]");
         setEventMetadata("VREMOVEPRODUCT.CLICK",",oparms:[{av:'AV19ProductsSelected',fld:'vPRODUCTSSELECTED',grid:94,pic:''},{av:'nGXsfl_94_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:94},{av:'WHOLESALEFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_94',ctrl:'WHOLESALEFGRID',prop:'GridRC',grid:94},{av:'AV14IdsSelected',fld:'vIDSSELECTED',pic:''},{av:'divWholesaleprofittable_Visible',ctrl:'WHOLESALEPROFITTABLE',prop:'Visible'},{av:'divButtonstable_Visible',ctrl:'BUTTONSTABLE',prop:'Visible'}]}");
         setEventMetadata("WHOLESALEFGRID.REFRESH","{handler:'E152L2',iparms:[]");
         setEventMetadata("WHOLESALEFGRID.REFRESH",",oparms:[{av:'AV41RemoveProduct',fld:'vREMOVEPRODUCT',pic:''}]}");
         setEventMetadata("'UPDATE'","{handler:'E122L2',iparms:[{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV9Code',fld:'vCODE',pic:''},{av:'AV16Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV23Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV22Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV32newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV33newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'AV7AllOk',fld:'vALLOK',pic:''},{av:'AV19ProductsSelected',fld:'vPRODUCTSSELECTED',grid:94,pic:''},{av:'nGXsfl_94_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:94},{av:'WHOLESALEFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_94',ctrl:'WHOLESALEFGRID',prop:'GridRC',grid:94},{av:'AV37ErrorMessage',fld:'vERRORMESSAGE',pic:''},{av:'AV14IdsSelected',fld:'vIDSSELECTED',pic:''},{av:'AV26NewWProfit',fld:'vNEWWPROFIT',pic:'ZZZZ9.99'},{av:'WHOLESALEFGRID_nEOF'}]");
         setEventMetadata("'UPDATE'",",oparms:[{av:'AV7AllOk',fld:'vALLOK',pic:''},{av:'AV37ErrorMessage',fld:'vERRORMESSAGE',pic:''},{av:'AV14IdsSelected',fld:'vIDSSELECTED',pic:''},{av:'AV19ProductsSelected',fld:'vPRODUCTSSELECTED',grid:94,pic:''},{av:'nGXsfl_94_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:94},{av:'WHOLESALEFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_94',ctrl:'WHOLESALEFGRID',prop:'GridRC',grid:94},{av:'divWholesaleprofittable_Visible',ctrl:'WHOLESALEPROFITTABLE',prop:'Visible'},{av:'divButtonstable_Visible',ctrl:'BUTTONSTABLE',prop:'Visible'},{av:'AV17OneProduct',fld:'vONEPRODUCT',pic:''}]}");
         setEventMetadata("'CANCEL'","{handler:'E212L2',iparms:[{av:'AV19ProductsSelected',fld:'vPRODUCTSSELECTED',grid:94,pic:''},{av:'nGXsfl_94_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:94},{av:'WHOLESALEFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_94',ctrl:'WHOLESALEFGRID',prop:'GridRC',grid:94},{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'WHOLESALEFGRID_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV9Code',fld:'vCODE',pic:''},{av:'AV16Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV23Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV22Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV32newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV33newCode',fld:'vNEWCODE',pic:'',hsh:true}]");
         setEventMetadata("'CANCEL'",",oparms:[{av:'AV14IdsSelected',fld:'vIDSSELECTED',pic:''},{av:'AV19ProductsSelected',fld:'vPRODUCTSSELECTED',grid:94,pic:''},{av:'nGXsfl_94_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:94},{av:'WHOLESALEFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_94',ctrl:'WHOLESALEFGRID',prop:'GridRC',grid:94},{av:'divWholesaleprofittable_Visible',ctrl:'WHOLESALEPROFITTABLE',prop:'Visible'},{av:'divButtonstable_Visible',ctrl:'BUTTONSTABLE',prop:'Visible'}]}");
         setEventMetadata("CTLNEWWHOLESALEPROFIT.CONTROLVALUECHANGED","{handler:'E162L2',iparms:[{av:'AV19ProductsSelected',fld:'vPRODUCTSSELECTED',grid:94,pic:''},{av:'nGXsfl_94_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:94},{av:'WHOLESALEFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_94',ctrl:'WHOLESALEFGRID',prop:'GridRC',grid:94},{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'WHOLESALEFGRID_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV9Code',fld:'vCODE',pic:''},{av:'AV16Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV23Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV22Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV32newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV33newCode',fld:'vNEWCODE',pic:'',hsh:true}]");
         setEventMetadata("CTLNEWWHOLESALEPROFIT.CONTROLVALUECHANGED",",oparms:[{av:'AV17OneProduct',fld:'vONEPRODUCT',pic:''},{av:'AV19ProductsSelected',fld:'vPRODUCTSSELECTED',grid:94,pic:''},{av:'nGXsfl_94_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:94},{av:'WHOLESALEFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_94',ctrl:'WHOLESALEFGRID',prop:'GridRC',grid:94}]}");
         setEventMetadata("CTLWHOLESALEPRICE.CONTROLVALUECHANGED","{handler:'E172L2',iparms:[{av:'AV19ProductsSelected',fld:'vPRODUCTSSELECTED',grid:94,pic:''},{av:'nGXsfl_94_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:94},{av:'WHOLESALEFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_94',ctrl:'WHOLESALEFGRID',prop:'GridRC',grid:94},{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'WHOLESALEFGRID_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV9Code',fld:'vCODE',pic:''},{av:'AV16Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV23Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV22Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV32newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV33newCode',fld:'vNEWCODE',pic:'',hsh:true}]");
         setEventMetadata("CTLWHOLESALEPRICE.CONTROLVALUECHANGED",",oparms:[{av:'AV17OneProduct',fld:'vONEPRODUCT',pic:''},{av:'AV19ProductsSelected',fld:'vPRODUCTSSELECTED',grid:94,pic:''},{av:'nGXsfl_94_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:94},{av:'WHOLESALEFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_94',ctrl:'WHOLESALEFGRID',prop:'GridRC',grid:94}]}");
         setEventMetadata("'SELECTALL'","{handler:'E132L2',iparms:[{av:'WHOLESALEFGRID_nFirstRecordOnPage'},{av:'WHOLESALEFGRID_nEOF'},{av:'AV19ProductsSelected',fld:'vPRODUCTSSELECTED',grid:94,pic:''},{av:'nGXsfl_94_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:94},{av:'nRC_GXsfl_94',ctrl:'WHOLESALEFGRID',prop:'GridRC',grid:94},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV9Code',fld:'vCODE',pic:''},{av:'AV16Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV23Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV22Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV32newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV33newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'AV26NewWProfit',fld:'vNEWWPROFIT',pic:'ZZZZ9.99'},{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'}]");
         setEventMetadata("'SELECTALL'",",oparms:[{av:'AV19ProductsSelected',fld:'vPRODUCTSSELECTED',grid:94,pic:''},{av:'nGXsfl_94_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:94},{av:'WHOLESALEFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_94',ctrl:'WHOLESALEFGRID',prop:'GridRC',grid:94},{av:'dynavSector'},{av:'AV22Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSupplier'},{av:'AV23Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV16Name',fld:'vNAME',pic:''},{av:'divWholesaleprofittable_Visible',ctrl:'WHOLESALEPROFITTABLE',prop:'Visible'},{av:'divButtonstable_Visible',ctrl:'BUTTONSTABLE',prop:'Visible'},{av:'AV17OneProduct',fld:'vONEPRODUCT',pic:''},{av:'AV14IdsSelected',fld:'vIDSSELECTED',pic:''}]}");
         setEventMetadata("ALLPRODUCTS_FIRSTPAGE","{handler:'suballproducts_firstpage',iparms:[{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV9Code',fld:'vCODE',pic:''},{av:'AV16Name',fld:'vNAME',pic:''},{av:'AV32newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV33newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'dynavSupplier'},{av:'AV23Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV22Sector',fld:'vSECTOR',pic:'ZZZZZ9'}]");
         setEventMetadata("ALLPRODUCTS_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("ALLPRODUCTS_PREVPAGE","{handler:'suballproducts_previouspage',iparms:[{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV9Code',fld:'vCODE',pic:''},{av:'AV16Name',fld:'vNAME',pic:''},{av:'AV32newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV33newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'dynavSupplier'},{av:'AV23Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV22Sector',fld:'vSECTOR',pic:'ZZZZZ9'}]");
         setEventMetadata("ALLPRODUCTS_PREVPAGE",",oparms:[]}");
         setEventMetadata("ALLPRODUCTS_NEXTPAGE","{handler:'suballproducts_nextpage',iparms:[{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV9Code',fld:'vCODE',pic:''},{av:'AV16Name',fld:'vNAME',pic:''},{av:'AV32newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV33newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'dynavSupplier'},{av:'AV23Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV22Sector',fld:'vSECTOR',pic:'ZZZZZ9'}]");
         setEventMetadata("ALLPRODUCTS_NEXTPAGE",",oparms:[]}");
         setEventMetadata("ALLPRODUCTS_LASTPAGE","{handler:'suballproducts_lastpage',iparms:[{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV9Code',fld:'vCODE',pic:''},{av:'AV16Name',fld:'vNAME',pic:''},{av:'AV32newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV33newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'dynavSupplier'},{av:'AV23Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV22Sector',fld:'vSECTOR',pic:'ZZZZZ9'}]");
         setEventMetadata("ALLPRODUCTS_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_NEWWPROFIT","{handler:'Validv_Newwprofit',iparms:[]");
         setEventMetadata("VALIDV_NEWWPROFIT",",oparms:[]}");
         setEventMetadata("VALID_PRODUCTCOSTPRICE","{handler:'Valid_Productcostprice',iparms:[]");
         setEventMetadata("VALID_PRODUCTCOSTPRICE",",oparms:[]}");
         setEventMetadata("VALID_PRODUCTWHOLESALEPROFIT","{handler:'Valid_Productwholesaleprofit',iparms:[]");
         setEventMetadata("VALID_PRODUCTWHOLESALEPROFIT",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Productwholesaleprice',iparms:[]");
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
         AV32newName = "";
         AV33newCode = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV19ProductsSelected = new GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem>( context, "SDTProductsSelectedItem", "mtaKB");
         AV14IdsSelected = new GxSimpleCollection<int>();
         AV20ProductsSelectedAux = new GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem>( context, "SDTProductsSelectedItem", "mtaKB");
         AV15IdsSelectedAux = new GxSimpleCollection<int>();
         AV17OneProduct = new SdtSDTProductsSelected_SDTProductsSelectedItem(context);
         AV37ErrorMessage = new GeneXus.Utils.SdtMessages_Message(context);
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
         lblTextblock19_Jsonclick = "";
         lblTextblock20_Jsonclick = "";
         lblTextblock21_Jsonclick = "";
         lblTextblock22_Jsonclick = "";
         lblTextblock23_Jsonclick = "";
         lblTextblock24_Jsonclick = "";
         lblTextblock25_Jsonclick = "";
         lblTextblock26_Jsonclick = "";
         lblTextblock27_Jsonclick = "";
         WholesalefgridContainer = new GXWebGrid( context);
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV41RemoveProduct = "";
         AV56Removeproduct_GXI = "";
         A55ProductCode = "";
         A16ProductName = "";
         A5SupplierName = "";
         A2BrandName = "";
         A10SectorName = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         scmdbuf = "";
         H002L2_A4SupplierId = new int[1] ;
         H002L2_A5SupplierName = new string[] {""} ;
         H002L3_A1BrandId = new int[1] ;
         H002L3_n1BrandId = new bool[] {false} ;
         H002L3_A2BrandName = new string[] {""} ;
         H002L4_A9SectorId = new int[1] ;
         H002L4_n9SectorId = new bool[] {false} ;
         H002L4_A10SectorName = new string[] {""} ;
         lV9Code = "";
         lV16Name = "";
         H002L5_A9SectorId = new int[1] ;
         H002L5_n9SectorId = new bool[] {false} ;
         H002L5_A1BrandId = new int[1] ;
         H002L5_n1BrandId = new bool[] {false} ;
         H002L5_A4SupplierId = new int[1] ;
         H002L5_A10SectorName = new string[] {""} ;
         H002L5_A2BrandName = new string[] {""} ;
         H002L5_A5SupplierName = new string[] {""} ;
         H002L5_A16ProductName = new string[] {""} ;
         H002L5_A55ProductCode = new string[] {""} ;
         H002L5_n55ProductCode = new bool[] {false} ;
         H002L5_A15ProductId = new int[1] ;
         H002L5_A85ProductCostPrice = new decimal[1] ;
         H002L5_n85ProductCostPrice = new bool[] {false} ;
         H002L5_A87ProductWholesaleProfit = new decimal[1] ;
         H002L5_n87ProductWholesaleProfit = new bool[] {false} ;
         H002L6_AALLPRODUCTS_nRecordCount = new long[1] ;
         AV39Context = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         AV40WebSession = context.GetSession();
         GXt_SdtSDTProductsSelected_SDTProductsSelectedItem4 = new SdtSDTProductsSelected_SDTProductsSelectedItem(context);
         GXt_objcol_SdtSDTProductsSelected_SDTProductsSelectedItem5 = new GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem>( context, "SDTProductsSelectedItem", "mtaKB");
         AllproductsRow = new GXWebRow();
         WholesalefgridRow = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subAllproducts_Linesclass = "";
         ROClassString = "";
         subWholesalefgrid_Linesclass = "";
         sImgUrl = "";
         AllproductsColumn = new GXWebColumn();
         subWholesalefgrid_Header = "";
         WholesalefgridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpupdatewholesaleprofit__default(),
            new Object[][] {
                new Object[] {
               H002L2_A4SupplierId, H002L2_A5SupplierName
               }
               , new Object[] {
               H002L3_A1BrandId, H002L3_A2BrandName
               }
               , new Object[] {
               H002L4_A9SectorId, H002L4_A10SectorName
               }
               , new Object[] {
               H002L5_A9SectorId, H002L5_n9SectorId, H002L5_A1BrandId, H002L5_n1BrandId, H002L5_A4SupplierId, H002L5_A10SectorName, H002L5_A2BrandName, H002L5_A5SupplierName, H002L5_A16ProductName, H002L5_A55ProductCode,
               H002L5_n55ProductCode, H002L5_A15ProductId, H002L5_A85ProductCostPrice, H002L5_n85ProductCostPrice, H002L5_A87ProductWholesaleProfit, H002L5_n87ProductWholesaleProfit
               }
               , new Object[] {
               H002L6_AALLPRODUCTS_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavCtlcode2_Enabled = 0;
         edtavCtlname2_Enabled = 0;
         edtavCtlsupplier2_Enabled = 0;
         edtavCtlbrand2_Enabled = 0;
         edtavCtlsector2_Enabled = 0;
         edtavCtlcostprice2_Enabled = 0;
         edtavCtlwholesaleprofit1_Enabled = 0;
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
      private short subWholesalefgrid_Backcolorstyle ;
      private short WHOLESALEFGRID_nEOF ;
      private short AV29Position ;
      private short nGXWrapped ;
      private short subAllproducts_Backstyle ;
      private short subWholesalefgrid_Backstyle ;
      private short subAllproducts_Titlebackstyle ;
      private short subAllproducts_Allowselection ;
      private short subAllproducts_Allowhovering ;
      private short subAllproducts_Allowcollapsing ;
      private short subWholesalefgrid_Allowselection ;
      private short subWholesalefgrid_Allowhovering ;
      private short subWholesalefgrid_Allowcollapsing ;
      private short subWholesalefgrid_Collapsed ;
      private int nRC_GXsfl_39 ;
      private int nRC_GXsfl_94 ;
      private int subAllproducts_Rows ;
      private int nGXsfl_39_idx=1 ;
      private int AV23Supplier ;
      private int AV8Brand ;
      private int AV22Sector ;
      private int nGXsfl_94_idx=1 ;
      private int AV31IdSelected ;
      private int edtavCode_Enabled ;
      private int edtavName_Enabled ;
      private int divButtonstable_Visible ;
      private int edtavNewwprofit_Enabled ;
      private int divWholesaleprofittable_Visible ;
      private int AV44GXV1 ;
      private int A15ProductId ;
      private int gxdynajaxindex ;
      private int subAllproducts_Islastpage ;
      private int subWholesalefgrid_Islastpage ;
      private int edtavCtlcode2_Enabled ;
      private int edtavCtlname2_Enabled ;
      private int edtavCtlsupplier2_Enabled ;
      private int edtavCtlbrand2_Enabled ;
      private int edtavCtlsector2_Enabled ;
      private int edtavCtlcostprice2_Enabled ;
      private int edtavCtlwholesaleprofit1_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A4SupplierId ;
      private int A1BrandId ;
      private int A9SectorId ;
      private int nGXsfl_94_fel_idx=1 ;
      private int AV54GXV11 ;
      private int nGXsfl_94_bak_idx=1 ;
      private int AV55GXV12 ;
      private int AV57GXV13 ;
      private int AV58GXV14 ;
      private int AV59GXV15 ;
      private int AV60GXV16 ;
      private int idxLst ;
      private int subAllproducts_Backcolor ;
      private int subAllproducts_Allbackcolor ;
      private int subWholesalefgrid_Backcolor ;
      private int subWholesalefgrid_Allbackcolor ;
      private int edtavRemoveproduct_Enabled ;
      private int edtavRemoveproduct_Visible ;
      private int edtavCtlnewwholesaleprofit_Enabled ;
      private int edtavCtlnewwholesaleprofit_Visible ;
      private int edtavCtlwholesaleprice_Enabled ;
      private int edtavCtlwholesaleprice_Visible ;
      private int subAllproducts_Titlebackcolor ;
      private int subAllproducts_Selectedindex ;
      private int subAllproducts_Selectioncolor ;
      private int subAllproducts_Hoveringcolor ;
      private int subWholesalefgrid_Selectedindex ;
      private int subWholesalefgrid_Selectioncolor ;
      private int subWholesalefgrid_Hoveringcolor ;
      private long ALLPRODUCTS_nFirstRecordOnPage ;
      private long ALLPRODUCTS_nCurrentRecord ;
      private long WHOLESALEFGRID_nCurrentRecord ;
      private long ALLPRODUCTS_nRecordCount ;
      private long WHOLESALEFGRID_nFirstRecordOnPage ;
      private decimal AV26NewWProfit ;
      private decimal A85ProductCostPrice ;
      private decimal A87ProductWholesaleProfit ;
      private decimal A88ProductWholesalePrice ;
      private decimal GXt_decimal1 ;
      private decimal GXt_decimal2 ;
      private decimal GXt_decimal3 ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_39_idx="0001" ;
      private string sGXsfl_94_idx="0001" ;
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
      private string divButtonstable_Internalname ;
      private string edtavNewwprofit_Internalname ;
      private string edtavNewwprofit_Jsonclick ;
      private string bttUpdate_Internalname ;
      private string bttUpdate_Jsonclick ;
      private string bttCancel_Internalname ;
      private string bttCancel_Jsonclick ;
      private string divWholesaleprofittable_Internalname ;
      private string divTable4_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string lblTextblock19_Internalname ;
      private string lblTextblock19_Jsonclick ;
      private string lblTextblock20_Internalname ;
      private string lblTextblock20_Jsonclick ;
      private string lblTextblock21_Internalname ;
      private string lblTextblock21_Jsonclick ;
      private string lblTextblock22_Internalname ;
      private string lblTextblock22_Jsonclick ;
      private string lblTextblock23_Internalname ;
      private string lblTextblock23_Jsonclick ;
      private string lblTextblock24_Internalname ;
      private string lblTextblock24_Jsonclick ;
      private string lblTextblock25_Internalname ;
      private string lblTextblock25_Jsonclick ;
      private string lblTextblock26_Internalname ;
      private string lblTextblock26_Jsonclick ;
      private string lblTextblock27_Internalname ;
      private string lblTextblock27_Jsonclick ;
      private string subWholesalefgrid_Internalname ;
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
      private string edtProductWholesaleProfit_Internalname ;
      private string edtProductWholesalePrice_Internalname ;
      private string gxwrpcisep ;
      private string scmdbuf ;
      private string edtavCtlcode2_Internalname ;
      private string edtavCtlname2_Internalname ;
      private string edtavCtlsupplier2_Internalname ;
      private string edtavCtlbrand2_Internalname ;
      private string edtavCtlsector2_Internalname ;
      private string edtavCtlcostprice2_Internalname ;
      private string edtavCtlwholesaleprofit1_Internalname ;
      private string sGXsfl_94_fel_idx="0001" ;
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
      private string edtProductWholesaleProfit_Jsonclick ;
      private string edtProductWholesalePrice_Jsonclick ;
      private string edtavCtlnewwholesaleprofit_Internalname ;
      private string edtavCtlwholesaleprice_Internalname ;
      private string subWholesalefgrid_Class ;
      private string subWholesalefgrid_Linesclass ;
      private string divGrid2table_Internalname ;
      private string sImgUrl ;
      private string edtavRemoveproduct_Jsonclick ;
      private string edtavCtlcode2_Jsonclick ;
      private string edtavCtlname2_Jsonclick ;
      private string edtavCtlsupplier2_Jsonclick ;
      private string edtavCtlbrand2_Jsonclick ;
      private string edtavCtlsector2_Jsonclick ;
      private string edtavCtlcostprice2_Jsonclick ;
      private string edtavCtlwholesaleprofit1_Jsonclick ;
      private string edtavCtlnewwholesaleprofit_Jsonclick ;
      private string edtavCtlwholesaleprice_Jsonclick ;
      private string subAllproducts_Header ;
      private string subWholesalefgrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV30IsIn ;
      private bool AV7AllOk ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_94_Refreshing=false ;
      private bool n55ProductCode ;
      private bool n85ProductCostPrice ;
      private bool n87ProductWholesaleProfit ;
      private bool gxdyncontrolsrefreshing ;
      private bool bGXsfl_39_Refreshing=false ;
      private bool n9SectorId ;
      private bool n1BrandId ;
      private bool returnInSub ;
      private bool gx_BV94 ;
      private bool AV41RemoveProduct_IsBlob ;
      private string AV9Code ;
      private string AV16Name ;
      private string AV32newName ;
      private string AV33newCode ;
      private string AV56Removeproduct_GXI ;
      private string A55ProductCode ;
      private string A16ProductName ;
      private string A5SupplierName ;
      private string A2BrandName ;
      private string A10SectorName ;
      private string lV9Code ;
      private string lV16Name ;
      private string AV41RemoveProduct ;
      private GxSimpleCollection<int> AV14IdsSelected ;
      private GxSimpleCollection<int> AV15IdsSelectedAux ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid AllproductsContainer ;
      private GXWebGrid WholesalefgridContainer ;
      private GXWebRow AllproductsRow ;
      private GXWebRow WholesalefgridRow ;
      private GXWebColumn AllproductsColumn ;
      private GXWebColumn WholesalefgridColumn ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavSupplier ;
      private GXCombobox dynavBrand ;
      private GXCombobox dynavSector ;
      private IDataStoreProvider pr_default ;
      private int[] H002L2_A4SupplierId ;
      private string[] H002L2_A5SupplierName ;
      private int[] H002L3_A1BrandId ;
      private bool[] H002L3_n1BrandId ;
      private string[] H002L3_A2BrandName ;
      private int[] H002L4_A9SectorId ;
      private bool[] H002L4_n9SectorId ;
      private string[] H002L4_A10SectorName ;
      private int[] H002L5_A9SectorId ;
      private bool[] H002L5_n9SectorId ;
      private int[] H002L5_A1BrandId ;
      private bool[] H002L5_n1BrandId ;
      private int[] H002L5_A4SupplierId ;
      private string[] H002L5_A10SectorName ;
      private string[] H002L5_A2BrandName ;
      private string[] H002L5_A5SupplierName ;
      private string[] H002L5_A16ProductName ;
      private string[] H002L5_A55ProductCode ;
      private bool[] H002L5_n55ProductCode ;
      private int[] H002L5_A15ProductId ;
      private decimal[] H002L5_A85ProductCostPrice ;
      private bool[] H002L5_n85ProductCostPrice ;
      private decimal[] H002L5_A87ProductWholesaleProfit ;
      private bool[] H002L5_n87ProductWholesaleProfit ;
      private long[] H002L6_AALLPRODUCTS_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IGxSession AV40WebSession ;
      private GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> AV19ProductsSelected ;
      private GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> AV20ProductsSelectedAux ;
      private GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> GXt_objcol_SdtSDTProductsSelected_SDTProductsSelectedItem5 ;
      private GXWebForm Form ;
      private SdtSDTProductsSelected_SDTProductsSelectedItem AV17OneProduct ;
      private SdtSDTProductsSelected_SDTProductsSelectedItem GXt_SdtSDTProductsSelected_SDTProductsSelectedItem4 ;
      private GeneXus.Utils.SdtMessages_Message AV37ErrorMessage ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession AV39Context ;
   }

   public class wpupdatewholesaleprofit__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002L5( IGxContext context ,
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
         sSelectString = " T1.[SectorId], T1.[BrandId], T1.[SupplierId], T2.[SectorName], T3.[BrandName], T4.[SupplierName], T1.[ProductName], T1.[ProductCode], T1.[ProductId], T1.[ProductCostPrice], T1.[ProductWholesaleProfit]";
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

      protected Object[] conditional_H002L6( IGxContext context ,
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
                     return conditional_H002L5(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] );
               case 4 :
                     return conditional_H002L6(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] );
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
          Object[] prmH002L2;
          prmH002L2 = new Object[] {
          };
          Object[] prmH002L3;
          prmH002L3 = new Object[] {
          };
          Object[] prmH002L4;
          prmH002L4 = new Object[] {
          };
          Object[] prmH002L5;
          prmH002L5 = new Object[] {
          new ParDef("@lV9Code",GXType.NVarChar,100,0) ,
          new ParDef("@lV16Name",GXType.NVarChar,60,0) ,
          new ParDef("@AV23Supplier",GXType.Int32,6,0) ,
          new ParDef("@AV8Brand",GXType.Int32,6,0) ,
          new ParDef("@AV22Sector",GXType.Int32,6,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH002L6;
          prmH002L6 = new Object[] {
          new ParDef("@lV9Code",GXType.NVarChar,100,0) ,
          new ParDef("@lV16Name",GXType.NVarChar,60,0) ,
          new ParDef("@AV23Supplier",GXType.Int32,6,0) ,
          new ParDef("@AV8Brand",GXType.Int32,6,0) ,
          new ParDef("@AV22Sector",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002L2", "SELECT [SupplierId], [SupplierName] FROM [Supplier] ORDER BY [SupplierName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002L2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002L3", "SELECT [BrandId], [BrandName] FROM [Brand] ORDER BY [BrandName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002L3,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002L4", "SELECT [SectorId], [SectorName] FROM [Sector] ORDER BY [SectorName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002L4,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002L5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002L5,6, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002L6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002L6,1, GxCacheFrequency.OFF ,true,false )
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
