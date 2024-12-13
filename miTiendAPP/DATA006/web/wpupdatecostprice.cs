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
   public class wpupdatecostprice : GXDataArea
   {
      public wpupdatecostprice( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public wpupdatecostprice( IGxContext context )
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
               GXDLVvSUPPLIER2J2( ) ;
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
               GXDLVvBRAND2J2( ) ;
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
               GXDLVvSECTOR2J2( ) ;
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Costpricefgrid") == 0 )
            {
               gxnrCostpricefgrid_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Costpricefgrid") == 0 )
            {
               gxgrCostpricefgrid_refresh_invoke( ) ;
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
         AV7Code = GetPar( "Code");
         AV11Name = GetPar( "Name");
         dynavSupplier.FromJSonString( GetNextPar( ));
         AV10Supplier = (int)(Math.Round(NumberUtil.Val( GetPar( "Supplier"), "."), 18, MidpointRounding.ToEven));
         dynavBrand.FromJSonString( GetNextPar( ));
         AV8Brand = (int)(Math.Round(NumberUtil.Val( GetPar( "Brand"), "."), 18, MidpointRounding.ToEven));
         dynavSector.FromJSonString( GetNextPar( ));
         AV9Sector = (int)(Math.Round(NumberUtil.Val( GetPar( "Sector"), "."), 18, MidpointRounding.ToEven));
         AV22newName = GetPar( "newName");
         AV23newCode = GetPar( "newCode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrAllproducts_refresh( subAllproducts_Rows, AV7Code, AV11Name, AV10Supplier, AV8Brand, AV9Sector, AV22newName, AV23newCode) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrAllproducts_refresh_invoke */
      }

      protected void gxnrCostpricefgrid_newrow_invoke( )
      {
         nRC_GXsfl_88 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_88"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_88_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_88_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_88_idx = GetPar( "sGXsfl_88_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrCostpricefgrid_newrow( ) ;
         /* End function gxnrCostpricefgrid_newrow_invoke */
      }

      protected void gxgrCostpricefgrid_refresh_invoke( )
      {
         subAllproducts_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subAllproducts_Rows"), "."), 18, MidpointRounding.ToEven));
         AV7Code = GetPar( "Code");
         AV11Name = GetPar( "Name");
         dynavSupplier.FromJSonString( GetNextPar( ));
         AV10Supplier = (int)(Math.Round(NumberUtil.Val( GetPar( "Supplier"), "."), 18, MidpointRounding.ToEven));
         dynavBrand.FromJSonString( GetNextPar( ));
         AV8Brand = (int)(Math.Round(NumberUtil.Val( GetPar( "Brand"), "."), 18, MidpointRounding.ToEven));
         dynavSector.FromJSonString( GetNextPar( ));
         AV9Sector = (int)(Math.Round(NumberUtil.Val( GetPar( "Sector"), "."), 18, MidpointRounding.ToEven));
         AV22newName = GetPar( "newName");
         AV23newCode = GetPar( "newCode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrCostpricefgrid_refresh( subAllproducts_Rows, AV7Code, AV11Name, AV10Supplier, AV8Brand, AV9Sector, AV22newName, AV23newCode) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrCostpricefgrid_refresh_invoke */
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
         PA2J2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2J2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpupdatecostprice.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vNEWNAME", AV22newName);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV22newName, "")), context));
         GxWebStd.gx_hidden_field( context, "vNEWCODE", AV23newCode);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV23newCode, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vCODE", AV7Code);
         GxWebStd.gx_hidden_field( context, "GXH_vNAME", AV11Name);
         GxWebStd.gx_hidden_field( context, "GXH_vSUPPLIER", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10Supplier), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vBRAND", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8Brand), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vSECTOR", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9Sector), 6, 0, ".", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Costpriceproductsselected", AV28CostPriceProductsSelected);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Costpriceproductsselected", AV28CostPriceProductsSelected);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_39", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_39), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_88", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_88), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vNEWNAME", AV22newName);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV22newName, "")), context));
         GxWebStd.gx_hidden_field( context, "vNEWCODE", AV23newCode);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV23newCode, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOSTPRICEIDSSELECTED", AV29CostPriceIdsSelected);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOSTPRICEIDSSELECTED", AV29CostPriceIdsSelected);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vISIN", AV32IsIn);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPRODUCTSSELECTEDAUX", AV19ProductsSelectedAux);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPRODUCTSSELECTEDAUX", AV19ProductsSelectedAux);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vIDSSELECTEDAUX", AV20IdsSelectedAux);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vIDSSELECTEDAUX", AV20IdsSelectedAux);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOSTPRICEPRODUCTSSELECTED", AV28CostPriceProductsSelected);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOSTPRICEPRODUCTSSELECTED", AV28CostPriceProductsSelected);
         }
         GxWebStd.gx_hidden_field( context, "vIDSELECTED", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33IdSelected), 6, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vONEPRODUCT", AV6OneProduct);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vONEPRODUCT", AV6OneProduct);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vALLOK", AV24AllOk);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vERRORMESSAGE", AV34ErrorMessage);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vERRORMESSAGE", AV34ErrorMessage);
         }
         GxWebStd.gx_hidden_field( context, "ALLPRODUCTS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(ALLPRODUCTS_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ALLPRODUCTS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(ALLPRODUCTS_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTRETAILPROFIT", StringUtil.LTrim( StringUtil.NToC( A89ProductRetailProfit, 8, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTWHOLESALEPROFIT", StringUtil.LTrim( StringUtil.NToC( A87ProductWholesaleProfit, 8, 2, ".", "")));
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
            WE2J2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2J2( ) ;
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
         return formatLink("wpupdatecostprice.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WPUpdateCostPrice" ;
      }

      public override string GetPgmdesc( )
      {
         return "WPUpdate Cost Price" ;
      }

      protected void WB2J0( )
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
            GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Update Cost Price", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WPUpdateCostPrice.htm");
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
            GxWebStd.gx_button_ctrl( context, bttSelectall_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(39), 2, 0)+","+"null"+");", "Select All", bttSelectall_Jsonclick, 5, "Select All", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'SELECTALL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPUpdateCostPrice.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavCode_Internalname, AV7Code, StringUtil.RTrim( context.localUtil.Format( AV7Code, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,18);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCode_Jsonclick, 0, "attribute-filter", "", "", "", "", 1, edtavCode_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_WPUpdateCostPrice.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavName_Internalname, AV11Name, StringUtil.RTrim( context.localUtil.Format( AV11Name, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavName_Jsonclick, 0, "attribute-filter", "", "", "", "", 1, edtavName_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_WPUpdateCostPrice.htm");
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
            GxWebStd.gx_combobox_ctrl1( context, dynavSupplier, dynavSupplier_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV10Supplier), 6, 0)), 1, dynavSupplier_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavSupplier.Enabled, 0, 0, 0, "em", 0, "", "", "attribute-filter", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "", true, 0, "HLP_WPUpdateCostPrice.htm");
            dynavSupplier.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV10Supplier), 6, 0));
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
            GxWebStd.gx_combobox_ctrl1( context, dynavBrand, dynavBrand_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV8Brand), 6, 0)), 1, dynavBrand_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavBrand.Enabled, 0, 0, 0, "em", 0, "", "", "attribute-filter", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "", true, 0, "HLP_WPUpdateCostPrice.htm");
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
            GxWebStd.gx_combobox_ctrl1( context, dynavSector, dynavSector_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV9Sector), 6, 0)), 1, dynavSector_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavSector.Enabled, 0, 0, 0, "em", 0, "", "", "attribute-filter", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "", true, 0, "HLP_WPUpdateCostPrice.htm");
            dynavSector.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV9Sector), 6, 0));
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavCostpricepercentage_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCostpricepercentage_Internalname, "Cost Price Perc.", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'" + sGXsfl_39_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCostpricepercentage_Internalname, StringUtil.LTrim( StringUtil.NToC( AV13CostPricePercentage, 8, 2, ".", "")), StringUtil.LTrim( ((edtavCostpricepercentage_Enabled!=0) ? context.localUtil.Format( AV13CostPricePercentage, "ZZZZ9.99") : context.localUtil.Format( AV13CostPricePercentage, "ZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCostpricepercentage_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCostpricepercentage_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "Percentage", "right", false, "", "HLP_WPUpdateCostPrice.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttUpdate_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(39), 2, 0)+","+"null"+");", "Update", bttUpdate_Jsonclick, 5, "Update", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'COSTPRICEUPDATE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPUpdateCostPrice.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(39), 2, 0)+","+"null"+");", "Cancel", bttCancel_Jsonclick, 5, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'COSTPRICECANCEL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPUpdateCostPrice.htm");
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
            GxWebStd.gx_div_start( context, divCostpricetable_Internalname, divCostpricetable_Visible, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
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
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock28_Internalname, "Action", "", "", lblTextblock28_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdateCostPrice.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Code", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdateCostPrice.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Name", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdateCostPrice.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "U. Cost Price", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdateCostPrice.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "New U. C. Price", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdateCostPrice.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "R. Price", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdateCostPrice.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "W. Price", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdateCostPrice.htm");
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
            CostpricefgridContainer.SetIsFreestyle(true);
            CostpricefgridContainer.SetWrapped(nGXWrapped);
            StartGridControl88( ) ;
         }
         if ( wbEnd == 88 )
         {
            wbEnd = 0;
            nRC_GXsfl_88 = (int)(nGXsfl_88_idx-1);
            if ( CostpricefgridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV42GXV1 = nGXsfl_88_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"CostpricefgridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Costpricefgrid", CostpricefgridContainer, subCostpricefgrid_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "CostpricefgridContainerData", CostpricefgridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "CostpricefgridContainerData"+"V", CostpricefgridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"CostpricefgridContainerData"+"V"+"\" value='"+CostpricefgridContainer.GridValuesHidden()+"'/>") ;
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
         if ( wbEnd == 88 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( CostpricefgridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV42GXV1 = nGXsfl_88_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"CostpricefgridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Costpricefgrid", CostpricefgridContainer, subCostpricefgrid_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "CostpricefgridContainerData", CostpricefgridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "CostpricefgridContainerData"+"V", CostpricefgridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"CostpricefgridContainerData"+"V"+"\" value='"+CostpricefgridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START2J2( )
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
            Form.Meta.addItem("description", "WPUpdate Cost Price", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2J0( ) ;
      }

      protected void WS2J2( )
      {
         START2J2( ) ;
         EVT2J2( ) ;
      }

      protected void EVT2J2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "VCOSTPRICEPERCENTAGE.ISVALID") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E112J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'COSTPRICEUPDATE'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'CostPriceUpdate' */
                              E122J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'COSTPRICECANCEL'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'CostPriceCancel' */
                              E132J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'SELECTALL'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'SelectAll' */
                              E142J2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 20), "VREMOVEPRODUCT.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 22), "COSTPRICEFGRID.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 35), "CTLNEWCOSTPRICE.CONTROLVALUECHANGED") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "COSTPRICEFGRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 20), "VREMOVEPRODUCT.CLICK") == 0 ) )
                           {
                              nGXsfl_88_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
                              SubsflControlProps_883( ) ;
                              AV42GXV1 = nGXsfl_88_idx;
                              if ( ( AV28CostPriceProductsSelected.Count >= AV42GXV1 ) && ( AV42GXV1 > 0 ) )
                              {
                                 AV28CostPriceProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV28CostPriceProductsSelected.Item(AV42GXV1));
                                 AV39RemoveProduct = cgiGet( edtavRemoveproduct_Internalname);
                                 AssignProp("", false, edtavRemoveproduct_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV39RemoveProduct)) ? AV51Removeproduct_GXI : context.convertURL( context.PathToRelativeUrl( AV39RemoveProduct))), !bGXsfl_88_Refreshing);
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
                                    E152J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "COSTPRICEFGRID.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E162J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "CTLNEWCOSTPRICE.CONTROLVALUECHANGED") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E172J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "COSTPRICEFGRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E182J3 ();
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
                           else if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "PRODUCTNAME.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 20), "'COSTPRICEBTNREMOVE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 16), "ALLPRODUCTS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "PRODUCTNAME.CLICK") == 0 ) )
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
                              A90ProductRetailPrice = context.localUtil.CToN( cgiGet( edtProductRetailPrice_Internalname), ".", ",");
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
                                    E192J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "PRODUCTNAME.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E202J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'COSTPRICEBTNREMOVE'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'CostPriceBtnRemove' */
                                    E212J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ALLPRODUCTS.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E222J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Code Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCODE"), AV7Code) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Name Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vNAME"), AV11Name) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Supplier Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vSUPPLIER"), ".", ",") != Convert.ToDecimal( AV10Supplier )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Brand Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vBRAND"), ".", ",") != Convert.ToDecimal( AV8Brand )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Sector Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vSECTOR"), ".", ",") != Convert.ToDecimal( AV9Sector )) )
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

      protected void WE2J2( )
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

      protected void PA2J2( )
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

      protected void GXDLVvSUPPLIER2J2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvSUPPLIER_data2J2( ) ;
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

      protected void GXVvSUPPLIER_html2J2( )
      {
         int gxdynajaxvalue;
         GXDLVvSUPPLIER_data2J2( ) ;
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

      protected void GXDLVvSUPPLIER_data2J2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(None)");
         /* Using cursor H002J2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H002J2_A4SupplierId[0]), 6, 0, ".", "")));
            gxdynajaxctrldescr.Add(H002J2_A5SupplierName[0]);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void GXDLVvBRAND2J2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvBRAND_data2J2( ) ;
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

      protected void GXVvBRAND_html2J2( )
      {
         int gxdynajaxvalue;
         GXDLVvBRAND_data2J2( ) ;
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

      protected void GXDLVvBRAND_data2J2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(None)");
         /* Using cursor H002J3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H002J3_A1BrandId[0]), 6, 0, ".", "")));
            gxdynajaxctrldescr.Add(H002J3_A2BrandName[0]);
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void GXDLVvSECTOR2J2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvSECTOR_data2J2( ) ;
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

      protected void GXVvSECTOR_html2J2( )
      {
         int gxdynajaxvalue;
         GXDLVvSECTOR_data2J2( ) ;
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

      protected void GXDLVvSECTOR_data2J2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(None)");
         /* Using cursor H002J4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H002J4_A9SectorId[0]), 6, 0, ".", "")));
            gxdynajaxctrldescr.Add(H002J4_A10SectorName[0]);
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

      protected void gxnrCostpricefgrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_883( ) ;
         while ( nGXsfl_88_idx <= nRC_GXsfl_88 )
         {
            sendrow_883( ) ;
            nGXsfl_88_idx = ((subCostpricefgrid_Islastpage==1)&&(nGXsfl_88_idx+1>subCostpricefgrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_88_idx+1);
            sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
            SubsflControlProps_883( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( CostpricefgridContainer)) ;
         /* End function gxnrCostpricefgrid_newrow */
      }

      protected void gxgrAllproducts_refresh( int subAllproducts_Rows ,
                                              string AV7Code ,
                                              string AV11Name ,
                                              int AV10Supplier ,
                                              int AV8Brand ,
                                              int AV9Sector ,
                                              string AV22newName ,
                                              string AV23newCode )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         ALLPRODUCTS_nCurrentRecord = 0;
         RF2J2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrAllproducts_refresh */
      }

      protected void gxgrCostpricefgrid_refresh( int subAllproducts_Rows ,
                                                 string AV7Code ,
                                                 string AV11Name ,
                                                 int AV10Supplier ,
                                                 int AV8Brand ,
                                                 int AV9Sector ,
                                                 string AV22newName ,
                                                 string AV23newCode )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         COSTPRICEFGRID_nCurrentRecord = 0;
         RF2J3( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrCostpricefgrid_refresh */
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
            GXVvSUPPLIER_html2J2( ) ;
            GXVvBRAND_html2J2( ) ;
            GXVvSECTOR_html2J2( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavSupplier.ItemCount > 0 )
         {
            AV10Supplier = (int)(Math.Round(NumberUtil.Val( dynavSupplier.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV10Supplier), 6, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV10Supplier", StringUtil.LTrimStr( (decimal)(AV10Supplier), 6, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavSupplier.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV10Supplier), 6, 0));
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
            AV9Sector = (int)(Math.Round(NumberUtil.Val( dynavSector.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV9Sector), 6, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV9Sector", StringUtil.LTrimStr( (decimal)(AV9Sector), 6, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavSector.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV9Sector), 6, 0));
            AssignProp("", false, dynavSector_Internalname, "Values", dynavSector.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF2J2( ) ;
         RF2J3( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavCtlcode3_Enabled = 0;
         AssignProp("", false, edtavCtlcode3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcode3_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtavCtlname3_Enabled = 0;
         AssignProp("", false, edtavCtlname3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname3_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtavCtlcostprice3_Enabled = 0;
         AssignProp("", false, edtavCtlcostprice3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcostprice3_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtavCtlretailprice2_Enabled = 0;
         AssignProp("", false, edtavCtlretailprice2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlretailprice2_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtavCtlwholesaleprice2_Enabled = 0;
         AssignProp("", false, edtavCtlwholesaleprice2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlwholesaleprice2_Enabled), 5, 0), !bGXsfl_88_Refreshing);
      }

      protected void RF2J2( )
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
                                                 AV7Code ,
                                                 AV11Name ,
                                                 AV10Supplier ,
                                                 AV8Brand ,
                                                 AV9Sector ,
                                                 A55ProductCode ,
                                                 A16ProductName ,
                                                 A4SupplierId ,
                                                 A1BrandId ,
                                                 A9SectorId ,
                                                 A110ProductActive } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                                 TypeConstants.BOOLEAN
                                                 }
            });
            lV7Code = StringUtil.Concat( StringUtil.RTrim( AV7Code), "%", "");
            lV11Name = StringUtil.Concat( StringUtil.RTrim( AV11Name), "%", "");
            /* Using cursor H002J5 */
            pr_default.execute(3, new Object[] {lV7Code, lV11Name, AV10Supplier, AV8Brand, AV9Sector, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_39_idx = 1;
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
            while ( ( (pr_default.getStatus(3) != 101) ) && ( ( ALLPRODUCTS_nCurrentRecord < subAllproducts_fnc_Recordsperpage( ) ) ) )
            {
               A110ProductActive = H002J5_A110ProductActive[0];
               n110ProductActive = H002J5_n110ProductActive[0];
               A9SectorId = H002J5_A9SectorId[0];
               n9SectorId = H002J5_n9SectorId[0];
               A1BrandId = H002J5_A1BrandId[0];
               n1BrandId = H002J5_n1BrandId[0];
               A4SupplierId = H002J5_A4SupplierId[0];
               A10SectorName = H002J5_A10SectorName[0];
               A2BrandName = H002J5_A2BrandName[0];
               A5SupplierName = H002J5_A5SupplierName[0];
               A16ProductName = H002J5_A16ProductName[0];
               A55ProductCode = H002J5_A55ProductCode[0];
               n55ProductCode = H002J5_n55ProductCode[0];
               A15ProductId = H002J5_A15ProductId[0];
               A89ProductRetailProfit = H002J5_A89ProductRetailProfit[0];
               n89ProductRetailProfit = H002J5_n89ProductRetailProfit[0];
               A85ProductCostPrice = H002J5_A85ProductCostPrice[0];
               n85ProductCostPrice = H002J5_n85ProductCostPrice[0];
               A87ProductWholesaleProfit = H002J5_A87ProductWholesaleProfit[0];
               n87ProductWholesaleProfit = H002J5_n87ProductWholesaleProfit[0];
               A10SectorName = H002J5_A10SectorName[0];
               A2BrandName = H002J5_A2BrandName[0];
               A5SupplierName = H002J5_A5SupplierName[0];
               GXt_decimal1 = A88ProductWholesalePrice;
               new roundvalue(context ).execute(  A85ProductCostPrice*(1+A87ProductWholesaleProfit/ (decimal)(100)), out  GXt_decimal1) ;
               GXt_decimal2 = A88ProductWholesalePrice;
               new roundvalue(context ).execute(  A85ProductCostPrice*(1+A87ProductWholesaleProfit/ (decimal)(100)), out  GXt_decimal2) ;
               GXt_decimal3 = A88ProductWholesalePrice;
               new roundvalue(context ).execute(  A85ProductCostPrice, out  GXt_decimal3) ;
               A88ProductWholesalePrice = ((A87ProductWholesaleProfit!=Convert.ToDecimal(0)) ? GXt_decimal2 : GXt_decimal3);
               GXt_decimal3 = A90ProductRetailPrice;
               new roundvalue(context ).execute(  A85ProductCostPrice*(1+A89ProductRetailProfit/ (decimal)(100)), out  GXt_decimal3) ;
               GXt_decimal2 = A90ProductRetailPrice;
               new roundvalue(context ).execute(  A85ProductCostPrice*(1+A89ProductRetailProfit/ (decimal)(100)), out  GXt_decimal2) ;
               GXt_decimal1 = A90ProductRetailPrice;
               new roundvalue(context ).execute(  A85ProductCostPrice, out  GXt_decimal1) ;
               A90ProductRetailPrice = ((A89ProductRetailProfit!=Convert.ToDecimal(0)) ? GXt_decimal2 : GXt_decimal1);
               E222J2 ();
               pr_default.readNext(3);
            }
            ALLPRODUCTS_nEOF = (short)(((pr_default.getStatus(3) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "ALLPRODUCTS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(ALLPRODUCTS_nEOF), 1, 0, ".", "")));
            pr_default.close(3);
            wbEnd = 39;
            WB2J0( ) ;
         }
         bGXsfl_39_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2J2( )
      {
         GxWebStd.gx_hidden_field( context, "vNEWNAME", AV22newName);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV22newName, "")), context));
         GxWebStd.gx_hidden_field( context, "vNEWCODE", AV23newCode);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV23newCode, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUCTID"+"_"+sGXsfl_39_idx, GetSecureSignedToken( sGXsfl_39_idx, context.localUtil.Format( (decimal)(A15ProductId), "ZZZZZ9"), context));
      }

      protected void RF2J3( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            CostpricefgridContainer.ClearRows();
         }
         wbStart = 88;
         E162J2 ();
         nGXsfl_88_idx = 1;
         sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
         SubsflControlProps_883( ) ;
         bGXsfl_88_Refreshing = true;
         CostpricefgridContainer.AddObjectProperty("GridName", "Costpricefgrid");
         CostpricefgridContainer.AddObjectProperty("CmpContext", "");
         CostpricefgridContainer.AddObjectProperty("InMasterPage", "false");
         CostpricefgridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         CostpricefgridContainer.AddObjectProperty("Class", "FreeStyleGrid");
         CostpricefgridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         CostpricefgridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         CostpricefgridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subCostpricefgrid_Backcolorstyle), 1, 0, ".", "")));
         CostpricefgridContainer.PageSize = subCostpricefgrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_883( ) ;
            E182J3 ();
            wbEnd = 88;
            WB2J0( ) ;
         }
         bGXsfl_88_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2J3( )
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
                                              AV7Code ,
                                              AV11Name ,
                                              AV10Supplier ,
                                              AV8Brand ,
                                              AV9Sector ,
                                              A55ProductCode ,
                                              A16ProductName ,
                                              A4SupplierId ,
                                              A1BrandId ,
                                              A9SectorId ,
                                              A110ProductActive } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV7Code = StringUtil.Concat( StringUtil.RTrim( AV7Code), "%", "");
         lV11Name = StringUtil.Concat( StringUtil.RTrim( AV11Name), "%", "");
         /* Using cursor H002J6 */
         pr_default.execute(4, new Object[] {lV7Code, lV11Name, AV10Supplier, AV8Brand, AV9Sector});
         ALLPRODUCTS_nRecordCount = H002J6_AALLPRODUCTS_nRecordCount[0];
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
            gxgrAllproducts_refresh( subAllproducts_Rows, AV7Code, AV11Name, AV10Supplier, AV8Brand, AV9Sector, AV22newName, AV23newCode) ;
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
            gxgrAllproducts_refresh( subAllproducts_Rows, AV7Code, AV11Name, AV10Supplier, AV8Brand, AV9Sector, AV22newName, AV23newCode) ;
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
            gxgrAllproducts_refresh( subAllproducts_Rows, AV7Code, AV11Name, AV10Supplier, AV8Brand, AV9Sector, AV22newName, AV23newCode) ;
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
            gxgrAllproducts_refresh( subAllproducts_Rows, AV7Code, AV11Name, AV10Supplier, AV8Brand, AV9Sector, AV22newName, AV23newCode) ;
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
            gxgrAllproducts_refresh( subAllproducts_Rows, AV7Code, AV11Name, AV10Supplier, AV8Brand, AV9Sector, AV22newName, AV23newCode) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected int subCostpricefgrid_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subCostpricefgrid_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subCostpricefgrid_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subCostpricefgrid_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavCtlcode3_Enabled = 0;
         AssignProp("", false, edtavCtlcode3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcode3_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtavCtlname3_Enabled = 0;
         AssignProp("", false, edtavCtlname3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname3_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtavCtlcostprice3_Enabled = 0;
         AssignProp("", false, edtavCtlcostprice3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcostprice3_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtavCtlretailprice2_Enabled = 0;
         AssignProp("", false, edtavCtlretailprice2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlretailprice2_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtavCtlwholesaleprice2_Enabled = 0;
         AssignProp("", false, edtavCtlwholesaleprice2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlwholesaleprice2_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         GXVvSUPPLIER_html2J2( ) ;
         GXVvBRAND_html2J2( ) ;
         GXVvSECTOR_html2J2( ) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2J0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E192J2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Costpriceproductsselected"), AV28CostPriceProductsSelected);
            /* Read saved values. */
            nRC_GXsfl_39 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_39"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_88 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_88"), ".", ","), 18, MidpointRounding.ToEven));
            ALLPRODUCTS_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "ALLPRODUCTS_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            ALLPRODUCTS_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "ALLPRODUCTS_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            subAllproducts_Collapsed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "ALLPRODUCTS_Collapsed"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_88 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_88"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_88_fel_idx = 0;
            while ( nGXsfl_88_fel_idx < nRC_GXsfl_88 )
            {
               nGXsfl_88_fel_idx = ((subCostpricefgrid_Islastpage==1)&&(nGXsfl_88_fel_idx+1>subCostpricefgrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_88_fel_idx+1);
               sGXsfl_88_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_883( ) ;
               AV42GXV1 = nGXsfl_88_fel_idx;
               if ( ( AV28CostPriceProductsSelected.Count >= AV42GXV1 ) && ( AV42GXV1 > 0 ) )
               {
                  AV28CostPriceProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV28CostPriceProductsSelected.Item(AV42GXV1));
                  AV39RemoveProduct = cgiGet( edtavRemoveproduct_Internalname);
               }
            }
            if ( nGXsfl_88_fel_idx == 0 )
            {
               nGXsfl_88_idx = 1;
               sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
               SubsflControlProps_883( ) ;
            }
            nGXsfl_88_fel_idx = 1;
            /* Read variables values. */
            AV7Code = cgiGet( edtavCode_Internalname);
            AssignAttri("", false, "AV7Code", AV7Code);
            AV11Name = cgiGet( edtavName_Internalname);
            AssignAttri("", false, "AV11Name", AV11Name);
            dynavSupplier.Name = dynavSupplier_Internalname;
            dynavSupplier.CurrentValue = cgiGet( dynavSupplier_Internalname);
            AV10Supplier = (int)(Math.Round(NumberUtil.Val( cgiGet( dynavSupplier_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV10Supplier", StringUtil.LTrimStr( (decimal)(AV10Supplier), 6, 0));
            dynavBrand.Name = dynavBrand_Internalname;
            dynavBrand.CurrentValue = cgiGet( dynavBrand_Internalname);
            AV8Brand = (int)(Math.Round(NumberUtil.Val( cgiGet( dynavBrand_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV8Brand", StringUtil.LTrimStr( (decimal)(AV8Brand), 6, 0));
            dynavSector.Name = dynavSector_Internalname;
            dynavSector.CurrentValue = cgiGet( dynavSector_Internalname);
            AV9Sector = (int)(Math.Round(NumberUtil.Val( cgiGet( dynavSector_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV9Sector", StringUtil.LTrimStr( (decimal)(AV9Sector), 6, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCostpricepercentage_Internalname), ".", ",") < -9999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavCostpricepercentage_Internalname), ".", ",") > 99999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCOSTPRICEPERCENTAGE");
               GX_FocusControl = edtavCostpricepercentage_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV13CostPricePercentage = 0;
               AssignAttri("", false, "AV13CostPricePercentage", StringUtil.LTrimStr( AV13CostPricePercentage, 8, 2));
            }
            else
            {
               AV13CostPricePercentage = context.localUtil.CToN( cgiGet( edtavCostpricepercentage_Internalname), ".", ",");
               AssignAttri("", false, "AV13CostPricePercentage", StringUtil.LTrimStr( AV13CostPricePercentage, 8, 2));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCODE"), AV7Code) != 0 )
            {
               ALLPRODUCTS_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vNAME"), AV11Name) != 0 )
            {
               ALLPRODUCTS_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vSUPPLIER"), ".", ",") != Convert.ToDecimal( AV10Supplier )) )
            {
               ALLPRODUCTS_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vBRAND"), ".", ",") != Convert.ToDecimal( AV8Brand )) )
            {
               ALLPRODUCTS_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vSECTOR"), ".", ",") != Convert.ToDecimal( AV9Sector )) )
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
         E192J2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E192J2( )
      {
         /* Start Routine */
         returnInSub = false;
         new getcontext(context ).execute( out  AV37Context, ref  AV24AllOk) ;
         AssignAttri("", false, "AV24AllOk", AV24AllOk);
         if ( ! AV24AllOk )
         {
            AV38WebSession.Set("SecLogIn", "Error");
            CallWebObject(formatLink("wplogin.aspx") );
            context.wjLocDisableFrm = 1;
         }
         divCostpricetable_Visible = 0;
         AssignProp("", false, divCostpricetable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCostpricetable_Visible), 5, 0), true);
         divButtonstable_Visible = 0;
         AssignProp("", false, divButtonstable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divButtonstable_Visible), 5, 0), true);
         bttUpdate_Jsonclick = "confirm('Are you sure to update Cost Price?')";
         AssignProp("", false, bttUpdate_Internalname, "Jsonclick", bttUpdate_Jsonclick, true);
         bttCancel_Jsonclick = "confirm('Are you sure to cancel the update?')";
         AssignProp("", false, bttCancel_Internalname, "Jsonclick", bttCancel_Jsonclick, true);
      }

      protected void E202J2( )
      {
         AV42GXV1 = nGXsfl_88_idx;
         if ( ( AV42GXV1 > 0 ) && ( AV28CostPriceProductsSelected.Count >= AV42GXV1 ) )
         {
            AV28CostPriceProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV28CostPriceProductsSelected.Item(AV42GXV1));
         }
         /* ProductName_Click Routine */
         returnInSub = false;
         if ( AV29CostPriceIdsSelected.Count == 0 )
         {
            divCostpricetable_Visible = 1;
            AssignProp("", false, divCostpricetable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCostpricetable_Visible), 5, 0), true);
            divButtonstable_Visible = 1;
            AssignProp("", false, divButtonstable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divButtonstable_Visible), 5, 0), true);
         }
         AV33IdSelected = A15ProductId;
         AssignAttri("", false, "AV33IdSelected", StringUtil.LTrimStr( (decimal)(AV33IdSelected), 6, 0));
         /* Execute user subroutine: 'IDINSELECTED' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( ! AV32IsIn )
         {
            AV6OneProduct = new SdtSDTProductsSelected_SDTProductsSelectedItem(context);
            GXt_SdtSDTProductsSelected_SDTProductsSelectedItem4 = AV6OneProduct;
            new updateloadoneproduct(context ).execute(  A15ProductId, out  GXt_SdtSDTProductsSelected_SDTProductsSelectedItem4) ;
            AV6OneProduct = GXt_SdtSDTProductsSelected_SDTProductsSelectedItem4;
            /* Execute user subroutine: 'COSTPRICECALCULATEONE' */
            S122 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            AV19ProductsSelectedAux.Add(AV6OneProduct, 0);
            AV20IdsSelectedAux.Add(AV6OneProduct.gxTpr_Id, 0);
            AV6OneProduct = new SdtSDTProductsSelected_SDTProductsSelectedItem(context);
            AV49GXV8 = 1;
            while ( AV49GXV8 <= AV28CostPriceProductsSelected.Count )
            {
               AV6OneProduct = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV28CostPriceProductsSelected.Item(AV49GXV8));
               AV19ProductsSelectedAux.Add(AV6OneProduct, 0);
               AV20IdsSelectedAux.Add(AV6OneProduct.gxTpr_Id, 0);
               AV49GXV8 = (int)(AV49GXV8+1);
            }
            AV28CostPriceProductsSelected.Clear();
            gx_BV88 = true;
            AV29CostPriceIdsSelected.Clear();
            AV28CostPriceProductsSelected = (GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem>)(AV19ProductsSelectedAux.Clone());
            gx_BV88 = true;
            AV29CostPriceIdsSelected = (GxSimpleCollection<int>)(AV20IdsSelectedAux.Clone());
            AV19ProductsSelectedAux.Clear();
            AV20IdsSelectedAux.Clear();
            gxgrCostpricefgrid_refresh( subAllproducts_Rows, AV7Code, AV11Name, AV10Supplier, AV8Brand, AV9Sector, AV22newName, AV23newCode) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6OneProduct", AV6OneProduct);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19ProductsSelectedAux", AV19ProductsSelectedAux);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20IdsSelectedAux", AV20IdsSelectedAux);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28CostPriceProductsSelected", AV28CostPriceProductsSelected);
         nGXsfl_88_bak_idx = nGXsfl_88_idx;
         gxgrCostpricefgrid_refresh( subAllproducts_Rows, AV7Code, AV11Name, AV10Supplier, AV8Brand, AV9Sector, AV22newName, AV23newCode) ;
         nGXsfl_88_idx = nGXsfl_88_bak_idx;
         sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
         SubsflControlProps_883( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV29CostPriceIdsSelected", AV29CostPriceIdsSelected);
      }

      protected void E112J2( )
      {
         AV42GXV1 = nGXsfl_88_idx;
         if ( ( AV42GXV1 > 0 ) && ( AV28CostPriceProductsSelected.Count >= AV42GXV1 ) )
         {
            AV28CostPriceProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV28CostPriceProductsSelected.Item(AV42GXV1));
         }
         /* Costpricepercentage_Isvalid Routine */
         returnInSub = false;
         AV50GXV9 = 1;
         while ( AV50GXV9 <= AV28CostPriceProductsSelected.Count )
         {
            AV6OneProduct = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV28CostPriceProductsSelected.Item(AV50GXV9));
            AV17Value = (decimal)(AV6OneProduct.gxTpr_Costprice*(1+AV13CostPricePercentage/ (decimal)(100)));
            GXt_decimal3 = AV17Value;
            new roundvalue(context ).execute(  AV17Value, out  GXt_decimal3) ;
            AV17Value = GXt_decimal3;
            AV6OneProduct.gxTpr_Newcostprice = AV17Value;
            AV17Value = (decimal)(AV6OneProduct.gxTpr_Newcostprice*(1+AV6OneProduct.gxTpr_Retailprofit/ (decimal)(100)));
            GXt_decimal3 = AV17Value;
            new roundvalue(context ).execute(  AV17Value, out  GXt_decimal3) ;
            AV17Value = GXt_decimal3;
            AV6OneProduct.gxTpr_Retailprice = AV17Value;
            AV17Value = (decimal)(AV6OneProduct.gxTpr_Newcostprice*(1+AV6OneProduct.gxTpr_Wholesaleprofit/ (decimal)(100)));
            GXt_decimal3 = AV17Value;
            new roundvalue(context ).execute(  AV17Value, out  GXt_decimal3) ;
            AV17Value = GXt_decimal3;
            AV6OneProduct.gxTpr_Wholesaleprice = AV17Value;
            AV50GXV9 = (int)(AV50GXV9+1);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6OneProduct", AV6OneProduct);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28CostPriceProductsSelected", AV28CostPriceProductsSelected);
         nGXsfl_88_bak_idx = nGXsfl_88_idx;
         gxgrCostpricefgrid_refresh( subAllproducts_Rows, AV7Code, AV11Name, AV10Supplier, AV8Brand, AV9Sector, AV22newName, AV23newCode) ;
         nGXsfl_88_idx = nGXsfl_88_bak_idx;
         sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
         SubsflControlProps_883( ) ;
      }

      protected void E212J2( )
      {
         AV42GXV1 = nGXsfl_88_idx;
         if ( ( AV42GXV1 > 0 ) && ( AV28CostPriceProductsSelected.Count >= AV42GXV1 ) )
         {
            AV28CostPriceProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV28CostPriceProductsSelected.Item(AV42GXV1));
         }
         /* 'CostPriceBtnRemove' Routine */
         returnInSub = false;
         AV30Position = (short)(AV29CostPriceIdsSelected.IndexOf(((SdtSDTProductsSelected_SDTProductsSelectedItem)(AV28CostPriceProductsSelected.CurrentItem)).gxTpr_Id));
         AV28CostPriceProductsSelected.RemoveItem(AV30Position);
         gx_BV88 = true;
         AV29CostPriceIdsSelected.RemoveItem(AV30Position);
         gxgrCostpricefgrid_refresh( subAllproducts_Rows, AV7Code, AV11Name, AV10Supplier, AV8Brand, AV9Sector, AV22newName, AV23newCode) ;
         if ( AV29CostPriceIdsSelected.Count == 0 )
         {
            divCostpricetable_Visible = 0;
            AssignProp("", false, divCostpricetable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCostpricetable_Visible), 5, 0), true);
            divButtonstable_Visible = 0;
            AssignProp("", false, divButtonstable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divButtonstable_Visible), 5, 0), true);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28CostPriceProductsSelected", AV28CostPriceProductsSelected);
         nGXsfl_88_bak_idx = nGXsfl_88_idx;
         gxgrCostpricefgrid_refresh( subAllproducts_Rows, AV7Code, AV11Name, AV10Supplier, AV8Brand, AV9Sector, AV22newName, AV23newCode) ;
         nGXsfl_88_idx = nGXsfl_88_bak_idx;
         sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
         SubsflControlProps_883( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV29CostPriceIdsSelected", AV29CostPriceIdsSelected);
      }

      protected void E152J2( )
      {
         AV42GXV1 = nGXsfl_88_idx;
         if ( ( AV42GXV1 > 0 ) && ( AV28CostPriceProductsSelected.Count >= AV42GXV1 ) )
         {
            AV28CostPriceProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV28CostPriceProductsSelected.Item(AV42GXV1));
         }
         /* Removeproduct_Click Routine */
         returnInSub = false;
         AV30Position = (short)(AV29CostPriceIdsSelected.IndexOf(((SdtSDTProductsSelected_SDTProductsSelectedItem)(AV28CostPriceProductsSelected.CurrentItem)).gxTpr_Id));
         AV28CostPriceProductsSelected.RemoveItem(AV30Position);
         gx_BV88 = true;
         AV29CostPriceIdsSelected.RemoveItem(AV30Position);
         gxgrCostpricefgrid_refresh( subAllproducts_Rows, AV7Code, AV11Name, AV10Supplier, AV8Brand, AV9Sector, AV22newName, AV23newCode) ;
         if ( AV29CostPriceIdsSelected.Count == 0 )
         {
            divCostpricetable_Visible = 0;
            AssignProp("", false, divCostpricetable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCostpricetable_Visible), 5, 0), true);
            divButtonstable_Visible = 0;
            AssignProp("", false, divButtonstable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divButtonstable_Visible), 5, 0), true);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28CostPriceProductsSelected", AV28CostPriceProductsSelected);
         nGXsfl_88_bak_idx = nGXsfl_88_idx;
         gxgrCostpricefgrid_refresh( subAllproducts_Rows, AV7Code, AV11Name, AV10Supplier, AV8Brand, AV9Sector, AV22newName, AV23newCode) ;
         nGXsfl_88_idx = nGXsfl_88_bak_idx;
         sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
         SubsflControlProps_883( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV29CostPriceIdsSelected", AV29CostPriceIdsSelected);
      }

      protected void E162J2( )
      {
         /* Costpricefgrid_Refresh Routine */
         returnInSub = false;
         edtavRemoveproduct_gximage = "GeneXusUnanimo_delete_light";
         AssignProp("", false, edtavRemoveproduct_Internalname, "gximage", edtavRemoveproduct_gximage, !bGXsfl_88_Refreshing);
         AV39RemoveProduct = context.GetImagePath( "db0f63cd-dde8-4bf7-aca2-01cdf8d3c157", "", context.GetTheme( ));
         AssignProp("", false, edtavRemoveproduct_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV39RemoveProduct)) ? AV51Removeproduct_GXI : context.convertURL( context.PathToRelativeUrl( AV39RemoveProduct))), !bGXsfl_88_Refreshing);
         AssignProp("", false, edtavRemoveproduct_Internalname, "SrcSet", context.GetImageSrcSet( AV39RemoveProduct), true);
         AV51Removeproduct_GXI = GXDbFile.PathToUrl( context.GetImagePath( "db0f63cd-dde8-4bf7-aca2-01cdf8d3c157", "", context.GetTheme( )));
         AssignProp("", false, edtavRemoveproduct_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV39RemoveProduct)) ? AV51Removeproduct_GXI : context.convertURL( context.PathToRelativeUrl( AV39RemoveProduct))), !bGXsfl_88_Refreshing);
         AssignProp("", false, edtavRemoveproduct_Internalname, "SrcSet", context.GetImageSrcSet( AV39RemoveProduct), true);
         /*  Sending Event outputs  */
      }

      protected void E122J2( )
      {
         AV42GXV1 = nGXsfl_88_idx;
         if ( ( AV42GXV1 > 0 ) && ( AV28CostPriceProductsSelected.Count >= AV42GXV1 ) )
         {
            AV28CostPriceProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV28CostPriceProductsSelected.Item(AV42GXV1));
         }
         /* 'CostPriceUpdate' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'COSTPRICECONTROL' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV24AllOk )
         {
            new productupdate(context ).execute(  AV28CostPriceProductsSelected, ref  AV34ErrorMessage, ref  AV24AllOk) ;
            AssignAttri("", false, "AV24AllOk", AV24AllOk);
            if ( AV24AllOk )
            {
               GX_msglist.addItem("Update succesfull");
               AV29CostPriceIdsSelected.Clear();
               AV28CostPriceProductsSelected.Clear();
               gx_BV88 = true;
               gxgrAllproducts_refresh( subAllproducts_Rows, AV7Code, AV11Name, AV10Supplier, AV8Brand, AV9Sector, AV22newName, AV23newCode) ;
               divCostpricetable_Visible = 0;
               AssignProp("", false, divCostpricetable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCostpricetable_Visible), 5, 0), true);
               divButtonstable_Visible = 0;
               AssignProp("", false, divButtonstable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divButtonstable_Visible), 5, 0), true);
            }
            else
            {
               GX_msglist.addItem(AV34ErrorMessage.gxTpr_Description);
            }
         }
         else
         {
            GX_msglist.addItem(AV34ErrorMessage.gxTpr_Description);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV34ErrorMessage", AV34ErrorMessage);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV29CostPriceIdsSelected", AV29CostPriceIdsSelected);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28CostPriceProductsSelected", AV28CostPriceProductsSelected);
         nGXsfl_88_bak_idx = nGXsfl_88_idx;
         gxgrCostpricefgrid_refresh( subAllproducts_Rows, AV7Code, AV11Name, AV10Supplier, AV8Brand, AV9Sector, AV22newName, AV23newCode) ;
         nGXsfl_88_idx = nGXsfl_88_bak_idx;
         sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
         SubsflControlProps_883( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6OneProduct", AV6OneProduct);
      }

      protected void E132J2( )
      {
         /* 'CostPriceCancel' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CLEARSELECTED' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV29CostPriceIdsSelected", AV29CostPriceIdsSelected);
         if ( gx_BV88 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28CostPriceProductsSelected", AV28CostPriceProductsSelected);
            nGXsfl_88_bak_idx = nGXsfl_88_idx;
            gxgrCostpricefgrid_refresh( subAllproducts_Rows, AV7Code, AV11Name, AV10Supplier, AV8Brand, AV9Sector, AV22newName, AV23newCode) ;
            nGXsfl_88_idx = nGXsfl_88_bak_idx;
            sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
            SubsflControlProps_883( ) ;
         }
      }

      protected void E172J2( )
      {
         AV42GXV1 = nGXsfl_88_idx;
         if ( ( AV42GXV1 > 0 ) && ( AV28CostPriceProductsSelected.Count >= AV42GXV1 ) )
         {
            AV28CostPriceProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV28CostPriceProductsSelected.Item(AV42GXV1));
         }
         /* Ctlnewcostprice_Controlvaluechanged Routine */
         returnInSub = false;
         AV6OneProduct = new SdtSDTProductsSelected_SDTProductsSelectedItem(context);
         AV6OneProduct = ((SdtSDTProductsSelected_SDTProductsSelectedItem)(AV28CostPriceProductsSelected.CurrentItem));
         AV6OneProduct.gxTpr_Retailprice = (decimal)(AV6OneProduct.gxTpr_Newcostprice*(1+AV6OneProduct.gxTpr_Retailprofit/ (decimal)(100)));
         AV6OneProduct.gxTpr_Wholesaleprice = (decimal)(AV6OneProduct.gxTpr_Newcostprice*(1+AV6OneProduct.gxTpr_Wholesaleprofit/ (decimal)(100)));
         GXt_decimal3 = 0;
         new roundvalue(context ).execute(  AV6OneProduct.gxTpr_Retailprice, out  GXt_decimal3) ;
         ((SdtSDTProductsSelected_SDTProductsSelectedItem)(AV28CostPriceProductsSelected.CurrentItem)).gxTpr_Retailprice = GXt_decimal3;
         GXt_decimal3 = 0;
         new roundvalue(context ).execute(  AV6OneProduct.gxTpr_Wholesaleprice, out  GXt_decimal3) ;
         ((SdtSDTProductsSelected_SDTProductsSelectedItem)(AV28CostPriceProductsSelected.CurrentItem)).gxTpr_Wholesaleprice = GXt_decimal3;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6OneProduct", AV6OneProduct);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28CostPriceProductsSelected", AV28CostPriceProductsSelected);
         nGXsfl_88_bak_idx = nGXsfl_88_idx;
         gxgrCostpricefgrid_refresh( subAllproducts_Rows, AV7Code, AV11Name, AV10Supplier, AV8Brand, AV9Sector, AV22newName, AV23newCode) ;
         nGXsfl_88_idx = nGXsfl_88_bak_idx;
         sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
         SubsflControlProps_883( ) ;
      }

      protected void E142J2( )
      {
         AV42GXV1 = nGXsfl_88_idx;
         if ( ( AV42GXV1 > 0 ) && ( AV28CostPriceProductsSelected.Count >= AV42GXV1 ) )
         {
            AV28CostPriceProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV28CostPriceProductsSelected.Item(AV42GXV1));
         }
         /* 'SelectAll' Routine */
         returnInSub = false;
         AV28CostPriceProductsSelected.Clear();
         gx_BV88 = true;
         GXt_objcol_SdtSDTProductsSelected_SDTProductsSelectedItem5 = AV28CostPriceProductsSelected;
         new updateselectall(context ).execute(  AV7Code, ref  AV11Name, ref  AV10Supplier, ref  AV8Brand, ref  AV9Sector, out  GXt_objcol_SdtSDTProductsSelected_SDTProductsSelectedItem5) ;
         AssignAttri("", false, "AV11Name", AV11Name);
         AssignAttri("", false, "AV10Supplier", StringUtil.LTrimStr( (decimal)(AV10Supplier), 6, 0));
         AssignAttri("", false, "AV8Brand", StringUtil.LTrimStr( (decimal)(AV8Brand), 6, 0));
         AssignAttri("", false, "AV9Sector", StringUtil.LTrimStr( (decimal)(AV9Sector), 6, 0));
         AV28CostPriceProductsSelected = GXt_objcol_SdtSDTProductsSelected_SDTProductsSelectedItem5;
         gx_BV88 = true;
         if ( ( AV13CostPricePercentage > Convert.ToDecimal( 0 )) )
         {
            /* Execute user subroutine: 'CALCULATEALL' */
            S152 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            gxgrCostpricefgrid_refresh( subAllproducts_Rows, AV7Code, AV11Name, AV10Supplier, AV8Brand, AV9Sector, AV22newName, AV23newCode) ;
         }
         if ( AV28CostPriceProductsSelected.Count > 0 )
         {
            /* Execute user subroutine: 'REGISTERIDS' */
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            divCostpricetable_Visible = 1;
            AssignProp("", false, divCostpricetable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCostpricetable_Visible), 5, 0), true);
            divButtonstable_Visible = 1;
            AssignProp("", false, divButtonstable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divButtonstable_Visible), 5, 0), true);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28CostPriceProductsSelected", AV28CostPriceProductsSelected);
         nGXsfl_88_bak_idx = nGXsfl_88_idx;
         gxgrCostpricefgrid_refresh( subAllproducts_Rows, AV7Code, AV11Name, AV10Supplier, AV8Brand, AV9Sector, AV22newName, AV23newCode) ;
         nGXsfl_88_idx = nGXsfl_88_bak_idx;
         sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
         SubsflControlProps_883( ) ;
         dynavSector.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV9Sector), 6, 0));
         AssignProp("", false, dynavSector_Internalname, "Values", dynavSector.ToJavascriptSource(), true);
         dynavBrand.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV8Brand), 6, 0));
         AssignProp("", false, dynavBrand_Internalname, "Values", dynavBrand.ToJavascriptSource(), true);
         dynavSupplier.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV10Supplier), 6, 0));
         AssignProp("", false, dynavSupplier_Internalname, "Values", dynavSupplier.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6OneProduct", AV6OneProduct);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV29CostPriceIdsSelected", AV29CostPriceIdsSelected);
      }

      protected void S132( )
      {
         /* 'COSTPRICECONTROL' Routine */
         returnInSub = false;
         AV34ErrorMessage.gxTpr_Description = "";
         AV24AllOk = true;
         AssignAttri("", false, "AV24AllOk", AV24AllOk);
         if ( AV29CostPriceIdsSelected.Count <= 0 )
         {
            AV24AllOk = false;
            AssignAttri("", false, "AV24AllOk", AV24AllOk);
            AV34ErrorMessage.gxTpr_Description = AV34ErrorMessage.gxTpr_Description+"Select at least one product ";
         }
         else if ( ( AV13CostPricePercentage < Convert.ToDecimal( -999 )) || ( AV13CostPricePercentage > Convert.ToDecimal( 999 )) )
         {
            AV24AllOk = false;
            AssignAttri("", false, "AV24AllOk", AV24AllOk);
            AV34ErrorMessage.gxTpr_Description = AV34ErrorMessage.gxTpr_Description+"Invalid Percentage ";
         }
         else
         {
            AV24AllOk = true;
            AssignAttri("", false, "AV24AllOk", AV24AllOk);
         }
         /* Execute user subroutine: 'NEWCOSTPRICECONTROL' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S122( )
      {
         /* 'COSTPRICECALCULATEONE' Routine */
         returnInSub = false;
         if ( ( AV13CostPricePercentage >= Convert.ToDecimal( -999 )) && ( AV13CostPricePercentage <= Convert.ToDecimal( 999 )) && ( AV13CostPricePercentage != Convert.ToDecimal( 0 )) )
         {
            AV17Value = (decimal)(AV6OneProduct.gxTpr_Costprice*(1+AV13CostPricePercentage/ (decimal)(100)));
            GXt_decimal3 = AV17Value;
            new roundvalue(context ).execute(  AV17Value, out  GXt_decimal3) ;
            AV17Value = GXt_decimal3;
            AV6OneProduct.gxTpr_Newcostprice = AV17Value;
            AV17Value = (decimal)(AV6OneProduct.gxTpr_Costprice*(1+AV6OneProduct.gxTpr_Retailprofit/ (decimal)(100)));
            GXt_decimal3 = AV17Value;
            new roundvalue(context ).execute(  AV17Value, out  GXt_decimal3) ;
            AV17Value = GXt_decimal3;
            AV6OneProduct.gxTpr_Retailprice = AV17Value;
            AV17Value = (decimal)(AV6OneProduct.gxTpr_Costprice*(1+AV6OneProduct.gxTpr_Wholesaleprofit/ (decimal)(100)));
            GXt_decimal3 = AV17Value;
            new roundvalue(context ).execute(  AV17Value, out  GXt_decimal3) ;
            AV17Value = GXt_decimal3;
            AV6OneProduct.gxTpr_Wholesaleprice = AV17Value;
         }
      }

      protected void S112( )
      {
         /* 'IDINSELECTED' Routine */
         returnInSub = false;
         if ( AV29CostPriceIdsSelected.IndexOf(AV33IdSelected) > 0 )
         {
            AV32IsIn = true;
            AssignAttri("", false, "AV32IsIn", AV32IsIn);
         }
         else
         {
            AV32IsIn = false;
            AssignAttri("", false, "AV32IsIn", AV32IsIn);
         }
      }

      protected void S172( )
      {
         /* 'NEWCOSTPRICECONTROL' Routine */
         returnInSub = false;
         AV52GXV10 = 1;
         while ( AV52GXV10 <= AV28CostPriceProductsSelected.Count )
         {
            AV6OneProduct = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV28CostPriceProductsSelected.Item(AV52GXV10));
            if ( ( AV6OneProduct.gxTpr_Newcostprice <= Convert.ToDecimal( 0 )) )
            {
               AV34ErrorMessage.gxTpr_Description = AV34ErrorMessage.gxTpr_Description+"Some new price is invalid";
               AV24AllOk = false;
               AssignAttri("", false, "AV24AllOk", AV24AllOk);
               if (true) break;
            }
            AV52GXV10 = (int)(AV52GXV10+1);
         }
      }

      protected void S142( )
      {
         /* 'CLEARSELECTED' Routine */
         returnInSub = false;
         AV29CostPriceIdsSelected.Clear();
         AV28CostPriceProductsSelected.Clear();
         gx_BV88 = true;
         divCostpricetable_Visible = 0;
         AssignProp("", false, divCostpricetable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCostpricetable_Visible), 5, 0), true);
         divButtonstable_Visible = 0;
         AssignProp("", false, divButtonstable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divButtonstable_Visible), 5, 0), true);
      }

      protected void S152( )
      {
         /* 'CALCULATEALL' Routine */
         returnInSub = false;
         AV53GXV11 = 1;
         while ( AV53GXV11 <= AV28CostPriceProductsSelected.Count )
         {
            AV6OneProduct = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV28CostPriceProductsSelected.Item(AV53GXV11));
            AV17Value = (decimal)(AV6OneProduct.gxTpr_Costprice*(1+AV13CostPricePercentage/ (decimal)(100)));
            GXt_decimal3 = AV17Value;
            new roundvalue(context ).execute(  AV17Value, out  GXt_decimal3) ;
            AV17Value = GXt_decimal3;
            AV6OneProduct.gxTpr_Newcostprice = AV17Value;
            AV17Value = (decimal)(AV6OneProduct.gxTpr_Costprice*(1+AV6OneProduct.gxTpr_Retailprofit/ (decimal)(100)));
            GXt_decimal3 = AV17Value;
            new roundvalue(context ).execute(  AV17Value, out  GXt_decimal3) ;
            AV17Value = GXt_decimal3;
            AV6OneProduct.gxTpr_Retailprice = AV17Value;
            AV17Value = (decimal)(AV6OneProduct.gxTpr_Costprice*(1+AV6OneProduct.gxTpr_Wholesaleprofit/ (decimal)(100)));
            GXt_decimal3 = AV17Value;
            new roundvalue(context ).execute(  AV17Value, out  GXt_decimal3) ;
            AV17Value = GXt_decimal3;
            AV6OneProduct.gxTpr_Wholesaleprice = AV17Value;
            AV53GXV11 = (int)(AV53GXV11+1);
         }
      }

      protected void S162( )
      {
         /* 'REGISTERIDS' Routine */
         returnInSub = false;
         AV29CostPriceIdsSelected.Clear();
         AV54GXV12 = 1;
         while ( AV54GXV12 <= AV28CostPriceProductsSelected.Count )
         {
            AV6OneProduct = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV28CostPriceProductsSelected.Item(AV54GXV12));
            AV29CostPriceIdsSelected.Add(AV6OneProduct.gxTpr_Id, 0);
            AV54GXV12 = (int)(AV54GXV12+1);
         }
      }

      private void E222J2( )
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

      private void E182J3( )
      {
         /* Costpricefgrid_Load Routine */
         returnInSub = false;
         AV42GXV1 = 1;
         while ( AV42GXV1 <= AV28CostPriceProductsSelected.Count )
         {
            AV28CostPriceProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV28CostPriceProductsSelected.Item(AV42GXV1));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 88;
            }
            sendrow_883( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_88_Refreshing )
            {
               DoAjaxLoad(88, CostpricefgridRow);
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
         PA2J2( ) ;
         WS2J2( ) ;
         WE2J2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20241232522611", true, true);
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
         context.AddJavascriptSource("wpupdatecostprice.js", "?20241232522611", false, true);
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
         edtProductRetailPrice_Internalname = "PRODUCTRETAILPRICE_"+sGXsfl_39_idx;
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
         edtProductRetailPrice_Internalname = "PRODUCTRETAILPRICE_"+sGXsfl_39_fel_idx;
         edtProductWholesalePrice_Internalname = "PRODUCTWHOLESALEPRICE_"+sGXsfl_39_fel_idx;
      }

      protected void sendrow_392( )
      {
         SubsflControlProps_392( ) ;
         WB2J0( ) ;
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
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductRetailPrice_Internalname,StringUtil.LTrim( StringUtil.NToC( A90ProductRetailPrice, 18, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A90ProductRetailPrice, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductRetailPrice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"Price",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductWholesalePrice_Internalname,StringUtil.LTrim( StringUtil.NToC( A88ProductWholesalePrice, 18, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A88ProductWholesalePrice, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductWholesalePrice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)39,(short)0,(short)-1,(short)0,(bool)true,(string)"Price",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes2J2( ) ;
            AllproductsContainer.AddRow(AllproductsRow);
            nGXsfl_39_idx = ((subAllproducts_Islastpage==1)&&(nGXsfl_39_idx+1>subAllproducts_fnc_Recordsperpage( )) ? 1 : nGXsfl_39_idx+1);
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_392( ) ;
         }
         /* End function sendrow_392 */
      }

      protected void SubsflControlProps_883( )
      {
         edtavRemoveproduct_Internalname = "vREMOVEPRODUCT_"+sGXsfl_88_idx;
         edtavCtlcode3_Internalname = "CTLCODE3_"+sGXsfl_88_idx;
         edtavCtlname3_Internalname = "CTLNAME3_"+sGXsfl_88_idx;
         edtavCtlcostprice3_Internalname = "CTLCOSTPRICE3_"+sGXsfl_88_idx;
         edtavCtlnewcostprice_Internalname = "CTLNEWCOSTPRICE_"+sGXsfl_88_idx;
         edtavCtlretailprice2_Internalname = "CTLRETAILPRICE2_"+sGXsfl_88_idx;
         edtavCtlwholesaleprice2_Internalname = "CTLWHOLESALEPRICE2_"+sGXsfl_88_idx;
      }

      protected void SubsflControlProps_fel_883( )
      {
         edtavRemoveproduct_Internalname = "vREMOVEPRODUCT_"+sGXsfl_88_fel_idx;
         edtavCtlcode3_Internalname = "CTLCODE3_"+sGXsfl_88_fel_idx;
         edtavCtlname3_Internalname = "CTLNAME3_"+sGXsfl_88_fel_idx;
         edtavCtlcostprice3_Internalname = "CTLCOSTPRICE3_"+sGXsfl_88_fel_idx;
         edtavCtlnewcostprice_Internalname = "CTLNEWCOSTPRICE_"+sGXsfl_88_fel_idx;
         edtavCtlretailprice2_Internalname = "CTLRETAILPRICE2_"+sGXsfl_88_fel_idx;
         edtavCtlwholesaleprice2_Internalname = "CTLWHOLESALEPRICE2_"+sGXsfl_88_fel_idx;
      }

      protected void sendrow_883( )
      {
         SubsflControlProps_883( ) ;
         WB2J0( ) ;
         CostpricefgridRow = GXWebRow.GetNew(context,CostpricefgridContainer);
         if ( subCostpricefgrid_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subCostpricefgrid_Backstyle = 0;
            if ( StringUtil.StrCmp(subCostpricefgrid_Class, "") != 0 )
            {
               subCostpricefgrid_Linesclass = subCostpricefgrid_Class+"Odd";
            }
         }
         else if ( subCostpricefgrid_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subCostpricefgrid_Backstyle = 0;
            subCostpricefgrid_Backcolor = subCostpricefgrid_Allbackcolor;
            if ( StringUtil.StrCmp(subCostpricefgrid_Class, "") != 0 )
            {
               subCostpricefgrid_Linesclass = subCostpricefgrid_Class+"Uniform";
            }
         }
         else if ( subCostpricefgrid_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subCostpricefgrid_Backstyle = 1;
            if ( StringUtil.StrCmp(subCostpricefgrid_Class, "") != 0 )
            {
               subCostpricefgrid_Linesclass = subCostpricefgrid_Class+"Odd";
            }
            subCostpricefgrid_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subCostpricefgrid_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subCostpricefgrid_Backstyle = 1;
            if ( ((int)((nGXsfl_88_idx) % (2))) == 0 )
            {
               subCostpricefgrid_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subCostpricefgrid_Class, "") != 0 )
               {
                  subCostpricefgrid_Linesclass = subCostpricefgrid_Class+"Even";
               }
            }
            else
            {
               subCostpricefgrid_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subCostpricefgrid_Class, "") != 0 )
               {
                  subCostpricefgrid_Linesclass = subCostpricefgrid_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( CostpricefgridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subCostpricefgrid_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_88_idx+"\">") ;
         }
         /* Div Control */
         CostpricefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divGrid1table2_Internalname+"_"+sGXsfl_88_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         CostpricefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         CostpricefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         CostpricefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavRemoveproduct_Enabled!=0)&&(edtavRemoveproduct_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 93,'',false,'',88)\"" : " ");
         ClassString = "Image" + " " + ((StringUtil.StrCmp(edtavRemoveproduct_gximage, "")==0) ? "" : "GX_Image_"+edtavRemoveproduct_gximage+"_Class");
         StyleString = "";
         AV39RemoveProduct_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV39RemoveProduct))&&String.IsNullOrEmpty(StringUtil.RTrim( AV51Removeproduct_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV39RemoveProduct)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV39RemoveProduct)) ? AV51Removeproduct_GXI : context.PathToRelativeUrl( AV39RemoveProduct));
         CostpricefgridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavRemoveproduct_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)1,(short)1,(string)"",(string)"",(short)0,(short)1,(short)1,(string)"chr",(short)0,(string)"row",(short)0,(short)0,(short)5,(string)edtavRemoveproduct_Jsonclick,"'"+""+"'"+",false,"+"'"+"EVREMOVEPRODUCT.CLICK."+sGXsfl_88_idx+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV39RemoveProduct_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         CostpricefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CostpricefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         CostpricefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         CostpricefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         CostpricefgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcode3_Internalname,(string)"Code",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         CostpricefgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcode3_Internalname,((SdtSDTProductsSelected_SDTProductsSelectedItem)AV28CostPriceProductsSelected.Item(AV42GXV1)).gxTpr_Code,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcode3_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlcode3_Enabled,(short)0,(string)"text",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)100,(short)0,(short)0,(short)88,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         CostpricefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CostpricefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         CostpricefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         CostpricefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         CostpricefgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname3_Internalname,(string)"Name",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         CostpricefgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname3_Internalname,((SdtSDTProductsSelected_SDTProductsSelectedItem)AV28CostPriceProductsSelected.Item(AV42GXV1)).gxTpr_Name,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlname3_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlname3_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)88,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         CostpricefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CostpricefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         CostpricefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         CostpricefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         CostpricefgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcostprice3_Internalname,(string)"Cost Price",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         CostpricefgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcostprice3_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV28CostPriceProductsSelected.Item(AV42GXV1)).gxTpr_Costprice, 18, 2, ".", "")),StringUtil.LTrim( ((edtavCtlcostprice3_Enabled!=0) ? context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV28CostPriceProductsSelected.Item(AV42GXV1)).gxTpr_Costprice, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV28CostPriceProductsSelected.Item(AV42GXV1)).gxTpr_Costprice, "ZZZZZZZZZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcostprice3_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlcostprice3_Enabled,(short)0,(string)"text",(string)"",(short)18,(string)"chr",(short)1,(string)"row",(short)18,(short)0,(short)0,(short)88,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         CostpricefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CostpricefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         CostpricefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         CostpricefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         CostpricefgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlnewcostprice_Internalname,(string)"New Cost Price",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         TempTags = " " + ((edtavCtlnewcostprice_Enabled!=0)&&(edtavCtlnewcostprice_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 105,'',false,'"+sGXsfl_88_idx+"',88)\"" : " ");
         ROClassString = "Attribute";
         CostpricefgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlnewcostprice_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV28CostPriceProductsSelected.Item(AV42GXV1)).gxTpr_Newcostprice, 18, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV28CostPriceProductsSelected.Item(AV42GXV1)).gxTpr_Newcostprice, "ZZZZZZZZZZZZZZ9.99")),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+((edtavCtlnewcostprice_Enabled!=0)&&(edtavCtlnewcostprice_Visible!=0) ? " onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,105);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlnewcostprice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)1,(short)0,(string)"text",(string)"",(short)18,(string)"chr",(short)1,(string)"row",(short)18,(short)0,(short)0,(short)88,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         CostpricefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CostpricefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         CostpricefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         CostpricefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         CostpricefgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlretailprice2_Internalname,(string)"Retail Price",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         CostpricefgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlretailprice2_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV28CostPriceProductsSelected.Item(AV42GXV1)).gxTpr_Retailprice, 18, 2, ".", "")),StringUtil.LTrim( ((edtavCtlretailprice2_Enabled!=0) ? context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV28CostPriceProductsSelected.Item(AV42GXV1)).gxTpr_Retailprice, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV28CostPriceProductsSelected.Item(AV42GXV1)).gxTpr_Retailprice, "ZZZZZZZZZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlretailprice2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlretailprice2_Enabled,(short)0,(string)"text",(string)"",(short)18,(string)"chr",(short)1,(string)"row",(short)18,(short)0,(short)0,(short)88,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         CostpricefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CostpricefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         CostpricefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         CostpricefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         CostpricefgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlwholesaleprice2_Internalname,(string)"Wholesale Price",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         CostpricefgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlwholesaleprice2_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV28CostPriceProductsSelected.Item(AV42GXV1)).gxTpr_Wholesaleprice, 18, 2, ".", "")),StringUtil.LTrim( ((edtavCtlwholesaleprice2_Enabled!=0) ? context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV28CostPriceProductsSelected.Item(AV42GXV1)).gxTpr_Wholesaleprice, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV28CostPriceProductsSelected.Item(AV42GXV1)).gxTpr_Wholesaleprice, "ZZZZZZZZZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlwholesaleprice2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlwholesaleprice2_Enabled,(short)0,(string)"text",(string)"",(short)18,(string)"chr",(short)1,(string)"row",(short)18,(short)0,(short)0,(short)88,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         CostpricefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CostpricefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CostpricefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CostpricefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         send_integrity_lvl_hashes2J3( ) ;
         /* End of Columns property logic. */
         CostpricefgridContainer.AddRow(CostpricefgridRow);
         nGXsfl_88_idx = ((subCostpricefgrid_Islastpage==1)&&(nGXsfl_88_idx+1>subCostpricefgrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_88_idx+1);
         sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
         SubsflControlProps_883( ) ;
         /* End function sendrow_883 */
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
            context.SendWebValue( "R.Price") ;
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
            AllproductsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A90ProductRetailPrice, 18, 2, ".", ""))));
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

      protected void StartGridControl88( )
      {
         if ( CostpricefgridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"CostpricefgridContainer"+"DivS\" data-gxgridid=\"88\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subCostpricefgrid_Internalname, subCostpricefgrid_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            CostpricefgridContainer.AddObjectProperty("GridName", "Costpricefgrid");
         }
         else
         {
            CostpricefgridContainer.AddObjectProperty("GridName", "Costpricefgrid");
            CostpricefgridContainer.AddObjectProperty("Header", subCostpricefgrid_Header);
            CostpricefgridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            CostpricefgridContainer.AddObjectProperty("Class", "FreeStyleGrid");
            CostpricefgridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            CostpricefgridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            CostpricefgridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subCostpricefgrid_Backcolorstyle), 1, 0, ".", "")));
            CostpricefgridContainer.AddObjectProperty("CmpContext", "");
            CostpricefgridContainer.AddObjectProperty("InMasterPage", "false");
            CostpricefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricefgridContainer.AddColumnProperties(CostpricefgridColumn);
            CostpricefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricefgridContainer.AddColumnProperties(CostpricefgridColumn);
            CostpricefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricefgridContainer.AddColumnProperties(CostpricefgridColumn);
            CostpricefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricefgridContainer.AddColumnProperties(CostpricefgridColumn);
            CostpricefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricefgridColumn.AddObjectProperty("Value", context.convertURL( AV39RemoveProduct));
            CostpricefgridContainer.AddColumnProperties(CostpricefgridColumn);
            CostpricefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricefgridContainer.AddColumnProperties(CostpricefgridColumn);
            CostpricefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricefgridContainer.AddColumnProperties(CostpricefgridColumn);
            CostpricefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricefgridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlcode3_Enabled), 5, 0, ".", "")));
            CostpricefgridContainer.AddColumnProperties(CostpricefgridColumn);
            CostpricefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricefgridContainer.AddColumnProperties(CostpricefgridColumn);
            CostpricefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricefgridContainer.AddColumnProperties(CostpricefgridColumn);
            CostpricefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricefgridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlname3_Enabled), 5, 0, ".", "")));
            CostpricefgridContainer.AddColumnProperties(CostpricefgridColumn);
            CostpricefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricefgridContainer.AddColumnProperties(CostpricefgridColumn);
            CostpricefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricefgridContainer.AddColumnProperties(CostpricefgridColumn);
            CostpricefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricefgridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlcostprice3_Enabled), 5, 0, ".", "")));
            CostpricefgridContainer.AddColumnProperties(CostpricefgridColumn);
            CostpricefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricefgridContainer.AddColumnProperties(CostpricefgridColumn);
            CostpricefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricefgridContainer.AddColumnProperties(CostpricefgridColumn);
            CostpricefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricefgridContainer.AddColumnProperties(CostpricefgridColumn);
            CostpricefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricefgridContainer.AddColumnProperties(CostpricefgridColumn);
            CostpricefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricefgridContainer.AddColumnProperties(CostpricefgridColumn);
            CostpricefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricefgridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlretailprice2_Enabled), 5, 0, ".", "")));
            CostpricefgridContainer.AddColumnProperties(CostpricefgridColumn);
            CostpricefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricefgridContainer.AddColumnProperties(CostpricefgridColumn);
            CostpricefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricefgridContainer.AddColumnProperties(CostpricefgridColumn);
            CostpricefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricefgridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlwholesaleprice2_Enabled), 5, 0, ".", "")));
            CostpricefgridContainer.AddColumnProperties(CostpricefgridColumn);
            CostpricefgridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subCostpricefgrid_Selectedindex), 4, 0, ".", "")));
            CostpricefgridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subCostpricefgrid_Allowselection), 1, 0, ".", "")));
            CostpricefgridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subCostpricefgrid_Selectioncolor), 9, 0, ".", "")));
            CostpricefgridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subCostpricefgrid_Allowhovering), 1, 0, ".", "")));
            CostpricefgridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subCostpricefgrid_Hoveringcolor), 9, 0, ".", "")));
            CostpricefgridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subCostpricefgrid_Allowcollapsing), 1, 0, ".", "")));
            CostpricefgridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subCostpricefgrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblTextblock3_Internalname = "TEXTBLOCK3";
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
         edtProductRetailPrice_Internalname = "PRODUCTRETAILPRICE";
         edtProductWholesalePrice_Internalname = "PRODUCTWHOLESALEPRICE";
         divTable1_Internalname = "TABLE1";
         edtavCostpricepercentage_Internalname = "vCOSTPRICEPERCENTAGE";
         bttUpdate_Internalname = "UPDATE";
         bttCancel_Internalname = "CANCEL";
         divButtonstable_Internalname = "BUTTONSTABLE";
         lblTextblock28_Internalname = "TEXTBLOCK28";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         divTable2_Internalname = "TABLE2";
         edtavRemoveproduct_Internalname = "vREMOVEPRODUCT";
         edtavCtlcode3_Internalname = "CTLCODE3";
         edtavCtlname3_Internalname = "CTLNAME3";
         edtavCtlcostprice3_Internalname = "CTLCOSTPRICE3";
         edtavCtlnewcostprice_Internalname = "CTLNEWCOSTPRICE";
         edtavCtlretailprice2_Internalname = "CTLRETAILPRICE2";
         edtavCtlwholesaleprice2_Internalname = "CTLWHOLESALEPRICE2";
         divGrid1table2_Internalname = "GRID1TABLE2";
         divCostpricetable_Internalname = "COSTPRICETABLE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subAllproducts_Internalname = "ALLPRODUCTS";
         subCostpricefgrid_Internalname = "COSTPRICEFGRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("mtaKB", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subCostpricefgrid_Allowcollapsing = 0;
         subAllproducts_Allowcollapsing = 1;
         subAllproducts_Allowselection = 0;
         subAllproducts_Header = "";
         edtavCtlwholesaleprice2_Jsonclick = "";
         edtavCtlwholesaleprice2_Enabled = 0;
         edtavCtlretailprice2_Jsonclick = "";
         edtavCtlretailprice2_Enabled = 0;
         edtavCtlnewcostprice_Jsonclick = "";
         edtavCtlnewcostprice_Visible = 1;
         edtavCtlnewcostprice_Enabled = 1;
         edtavCtlcostprice3_Jsonclick = "";
         edtavCtlcostprice3_Enabled = 0;
         edtavCtlname3_Jsonclick = "";
         edtavCtlname3_Enabled = 0;
         edtavCtlcode3_Jsonclick = "";
         edtavCtlcode3_Enabled = 0;
         edtavRemoveproduct_Jsonclick = "";
         edtavRemoveproduct_Visible = 1;
         edtavRemoveproduct_Enabled = 1;
         subCostpricefgrid_Class = "FreeStyleGrid";
         edtProductWholesalePrice_Jsonclick = "";
         edtProductRetailPrice_Jsonclick = "";
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
         subCostpricefgrid_Backcolorstyle = 0;
         edtavCtlwholesaleprice2_Enabled = -1;
         edtavCtlretailprice2_Enabled = -1;
         edtavCtlcostprice3_Enabled = -1;
         edtavCtlname3_Enabled = -1;
         edtavCtlcode3_Enabled = -1;
         divCostpricetable_Visible = 1;
         edtavCostpricepercentage_Jsonclick = "";
         edtavCostpricepercentage_Enabled = 1;
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
         Form.Caption = "WPUpdate Cost Price";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'COSTPRICEFGRID_nFirstRecordOnPage'},{av:'COSTPRICEFGRID_nEOF'},{av:'AV28CostPriceProductsSelected',fld:'vCOSTPRICEPRODUCTSSELECTED',grid:88,pic:''},{av:'nGXsfl_88_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:88},{av:'nRC_GXsfl_88',ctrl:'COSTPRICEFGRID',prop:'GridRC',grid:88},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV7Code',fld:'vCODE',pic:''},{av:'AV11Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV10Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV9Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV22newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV23newCode',fld:'vNEWCODE',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("PRODUCTNAME.CLICK","{handler:'E202J2',iparms:[{av:'COSTPRICEFGRID_nFirstRecordOnPage'},{av:'COSTPRICEFGRID_nEOF'},{av:'AV28CostPriceProductsSelected',fld:'vCOSTPRICEPRODUCTSSELECTED',grid:88,pic:''},{av:'nGXsfl_88_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:88},{av:'nRC_GXsfl_88',ctrl:'COSTPRICEFGRID',prop:'GridRC',grid:88},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV7Code',fld:'vCODE',pic:''},{av:'AV11Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV10Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV9Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV22newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV23newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'AV29CostPriceIdsSelected',fld:'vCOSTPRICEIDSSELECTED',pic:''},{av:'A15ProductId',fld:'PRODUCTID',pic:'ZZZZZ9',hsh:true},{av:'AV32IsIn',fld:'vISIN',pic:''},{av:'AV19ProductsSelectedAux',fld:'vPRODUCTSSELECTEDAUX',pic:''},{av:'AV20IdsSelectedAux',fld:'vIDSSELECTEDAUX',pic:''},{av:'AV33IdSelected',fld:'vIDSELECTED',pic:'ZZZZZ9'},{av:'AV13CostPricePercentage',fld:'vCOSTPRICEPERCENTAGE',pic:'ZZZZ9.99'},{av:'AV6OneProduct',fld:'vONEPRODUCT',pic:''},{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'}]");
         setEventMetadata("PRODUCTNAME.CLICK",",oparms:[{av:'divCostpricetable_Visible',ctrl:'COSTPRICETABLE',prop:'Visible'},{av:'divButtonstable_Visible',ctrl:'BUTTONSTABLE',prop:'Visible'},{av:'AV33IdSelected',fld:'vIDSELECTED',pic:'ZZZZZ9'},{av:'AV6OneProduct',fld:'vONEPRODUCT',pic:''},{av:'AV19ProductsSelectedAux',fld:'vPRODUCTSSELECTEDAUX',pic:''},{av:'AV20IdsSelectedAux',fld:'vIDSSELECTEDAUX',pic:''},{av:'AV28CostPriceProductsSelected',fld:'vCOSTPRICEPRODUCTSSELECTED',grid:88,pic:''},{av:'nGXsfl_88_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:88},{av:'COSTPRICEFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_88',ctrl:'COSTPRICEFGRID',prop:'GridRC',grid:88},{av:'AV29CostPriceIdsSelected',fld:'vCOSTPRICEIDSSELECTED',pic:''},{av:'AV32IsIn',fld:'vISIN',pic:''}]}");
         setEventMetadata("VCOSTPRICEPERCENTAGE.ISVALID","{handler:'E112J2',iparms:[{av:'AV28CostPriceProductsSelected',fld:'vCOSTPRICEPRODUCTSSELECTED',grid:88,pic:''},{av:'nGXsfl_88_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:88},{av:'COSTPRICEFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_88',ctrl:'COSTPRICEFGRID',prop:'GridRC',grid:88},{av:'AV13CostPricePercentage',fld:'vCOSTPRICEPERCENTAGE',pic:'ZZZZ9.99'},{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'COSTPRICEFGRID_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV7Code',fld:'vCODE',pic:''},{av:'AV11Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV10Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV9Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV22newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV23newCode',fld:'vNEWCODE',pic:'',hsh:true}]");
         setEventMetadata("VCOSTPRICEPERCENTAGE.ISVALID",",oparms:[{av:'AV6OneProduct',fld:'vONEPRODUCT',pic:''},{av:'AV28CostPriceProductsSelected',fld:'vCOSTPRICEPRODUCTSSELECTED',grid:88,pic:''},{av:'nGXsfl_88_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:88},{av:'COSTPRICEFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_88',ctrl:'COSTPRICEFGRID',prop:'GridRC',grid:88}]}");
         setEventMetadata("'COSTPRICEBTNREMOVE'","{handler:'E212J2',iparms:[{av:'COSTPRICEFGRID_nFirstRecordOnPage'},{av:'COSTPRICEFGRID_nEOF'},{av:'AV28CostPriceProductsSelected',fld:'vCOSTPRICEPRODUCTSSELECTED',grid:88,pic:''},{av:'nGXsfl_88_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:88},{av:'nRC_GXsfl_88',ctrl:'COSTPRICEFGRID',prop:'GridRC',grid:88},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV7Code',fld:'vCODE',pic:''},{av:'AV11Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV10Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV9Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV22newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV23newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'AV29CostPriceIdsSelected',fld:'vCOSTPRICEIDSSELECTED',pic:''},{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'}]");
         setEventMetadata("'COSTPRICEBTNREMOVE'",",oparms:[{av:'AV28CostPriceProductsSelected',fld:'vCOSTPRICEPRODUCTSSELECTED',grid:88,pic:''},{av:'nGXsfl_88_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:88},{av:'COSTPRICEFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_88',ctrl:'COSTPRICEFGRID',prop:'GridRC',grid:88},{av:'AV29CostPriceIdsSelected',fld:'vCOSTPRICEIDSSELECTED',pic:''},{av:'divCostpricetable_Visible',ctrl:'COSTPRICETABLE',prop:'Visible'},{av:'divButtonstable_Visible',ctrl:'BUTTONSTABLE',prop:'Visible'}]}");
         setEventMetadata("VREMOVEPRODUCT.CLICK","{handler:'E152J2',iparms:[{av:'COSTPRICEFGRID_nFirstRecordOnPage'},{av:'COSTPRICEFGRID_nEOF'},{av:'AV28CostPriceProductsSelected',fld:'vCOSTPRICEPRODUCTSSELECTED',grid:88,pic:''},{av:'nGXsfl_88_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:88},{av:'nRC_GXsfl_88',ctrl:'COSTPRICEFGRID',prop:'GridRC',grid:88},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV7Code',fld:'vCODE',pic:''},{av:'AV11Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV10Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV9Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV22newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV23newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'AV29CostPriceIdsSelected',fld:'vCOSTPRICEIDSSELECTED',pic:''},{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'}]");
         setEventMetadata("VREMOVEPRODUCT.CLICK",",oparms:[{av:'AV28CostPriceProductsSelected',fld:'vCOSTPRICEPRODUCTSSELECTED',grid:88,pic:''},{av:'nGXsfl_88_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:88},{av:'COSTPRICEFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_88',ctrl:'COSTPRICEFGRID',prop:'GridRC',grid:88},{av:'AV29CostPriceIdsSelected',fld:'vCOSTPRICEIDSSELECTED',pic:''},{av:'divCostpricetable_Visible',ctrl:'COSTPRICETABLE',prop:'Visible'},{av:'divButtonstable_Visible',ctrl:'BUTTONSTABLE',prop:'Visible'}]}");
         setEventMetadata("COSTPRICEFGRID.REFRESH","{handler:'E162J2',iparms:[]");
         setEventMetadata("COSTPRICEFGRID.REFRESH",",oparms:[{av:'AV39RemoveProduct',fld:'vREMOVEPRODUCT',pic:''}]}");
         setEventMetadata("'COSTPRICEUPDATE'","{handler:'E122J2',iparms:[{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV7Code',fld:'vCODE',pic:''},{av:'AV11Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV10Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV9Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV22newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV23newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'AV24AllOk',fld:'vALLOK',pic:''},{av:'AV28CostPriceProductsSelected',fld:'vCOSTPRICEPRODUCTSSELECTED',grid:88,pic:''},{av:'nGXsfl_88_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:88},{av:'COSTPRICEFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_88',ctrl:'COSTPRICEFGRID',prop:'GridRC',grid:88},{av:'AV34ErrorMessage',fld:'vERRORMESSAGE',pic:''},{av:'AV29CostPriceIdsSelected',fld:'vCOSTPRICEIDSSELECTED',pic:''},{av:'AV13CostPricePercentage',fld:'vCOSTPRICEPERCENTAGE',pic:'ZZZZ9.99'},{av:'COSTPRICEFGRID_nEOF'}]");
         setEventMetadata("'COSTPRICEUPDATE'",",oparms:[{av:'AV24AllOk',fld:'vALLOK',pic:''},{av:'AV34ErrorMessage',fld:'vERRORMESSAGE',pic:''},{av:'AV29CostPriceIdsSelected',fld:'vCOSTPRICEIDSSELECTED',pic:''},{av:'AV28CostPriceProductsSelected',fld:'vCOSTPRICEPRODUCTSSELECTED',grid:88,pic:''},{av:'nGXsfl_88_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:88},{av:'COSTPRICEFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_88',ctrl:'COSTPRICEFGRID',prop:'GridRC',grid:88},{av:'divCostpricetable_Visible',ctrl:'COSTPRICETABLE',prop:'Visible'},{av:'divButtonstable_Visible',ctrl:'BUTTONSTABLE',prop:'Visible'},{av:'AV6OneProduct',fld:'vONEPRODUCT',pic:''}]}");
         setEventMetadata("'COSTPRICECANCEL'","{handler:'E132J2',iparms:[{av:'AV28CostPriceProductsSelected',fld:'vCOSTPRICEPRODUCTSSELECTED',grid:88,pic:''},{av:'nGXsfl_88_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:88},{av:'COSTPRICEFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_88',ctrl:'COSTPRICEFGRID',prop:'GridRC',grid:88},{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'COSTPRICEFGRID_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV7Code',fld:'vCODE',pic:''},{av:'AV11Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV10Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV9Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV22newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV23newCode',fld:'vNEWCODE',pic:'',hsh:true}]");
         setEventMetadata("'COSTPRICECANCEL'",",oparms:[{av:'AV29CostPriceIdsSelected',fld:'vCOSTPRICEIDSSELECTED',pic:''},{av:'AV28CostPriceProductsSelected',fld:'vCOSTPRICEPRODUCTSSELECTED',grid:88,pic:''},{av:'nGXsfl_88_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:88},{av:'COSTPRICEFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_88',ctrl:'COSTPRICEFGRID',prop:'GridRC',grid:88},{av:'divCostpricetable_Visible',ctrl:'COSTPRICETABLE',prop:'Visible'},{av:'divButtonstable_Visible',ctrl:'BUTTONSTABLE',prop:'Visible'}]}");
         setEventMetadata("CTLNEWCOSTPRICE.CONTROLVALUECHANGED","{handler:'E172J2',iparms:[{av:'AV28CostPriceProductsSelected',fld:'vCOSTPRICEPRODUCTSSELECTED',grid:88,pic:''},{av:'nGXsfl_88_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:88},{av:'COSTPRICEFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_88',ctrl:'COSTPRICEFGRID',prop:'GridRC',grid:88},{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'COSTPRICEFGRID_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV7Code',fld:'vCODE',pic:''},{av:'AV11Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV10Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV9Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV22newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV23newCode',fld:'vNEWCODE',pic:'',hsh:true}]");
         setEventMetadata("CTLNEWCOSTPRICE.CONTROLVALUECHANGED",",oparms:[{av:'AV6OneProduct',fld:'vONEPRODUCT',pic:''},{av:'AV28CostPriceProductsSelected',fld:'vCOSTPRICEPRODUCTSSELECTED',grid:88,pic:''},{av:'nGXsfl_88_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:88},{av:'COSTPRICEFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_88',ctrl:'COSTPRICEFGRID',prop:'GridRC',grid:88}]}");
         setEventMetadata("'SELECTALL'","{handler:'E142J2',iparms:[{av:'COSTPRICEFGRID_nFirstRecordOnPage'},{av:'COSTPRICEFGRID_nEOF'},{av:'AV28CostPriceProductsSelected',fld:'vCOSTPRICEPRODUCTSSELECTED',grid:88,pic:''},{av:'nGXsfl_88_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:88},{av:'nRC_GXsfl_88',ctrl:'COSTPRICEFGRID',prop:'GridRC',grid:88},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV7Code',fld:'vCODE',pic:''},{av:'AV11Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV10Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV9Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV22newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV23newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'AV13CostPricePercentage',fld:'vCOSTPRICEPERCENTAGE',pic:'ZZZZ9.99'},{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'}]");
         setEventMetadata("'SELECTALL'",",oparms:[{av:'AV28CostPriceProductsSelected',fld:'vCOSTPRICEPRODUCTSSELECTED',grid:88,pic:''},{av:'nGXsfl_88_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:88},{av:'COSTPRICEFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_88',ctrl:'COSTPRICEFGRID',prop:'GridRC',grid:88},{av:'dynavSector'},{av:'AV9Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSupplier'},{av:'AV10Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'AV11Name',fld:'vNAME',pic:''},{av:'divCostpricetable_Visible',ctrl:'COSTPRICETABLE',prop:'Visible'},{av:'divButtonstable_Visible',ctrl:'BUTTONSTABLE',prop:'Visible'},{av:'AV6OneProduct',fld:'vONEPRODUCT',pic:''},{av:'AV29CostPriceIdsSelected',fld:'vCOSTPRICEIDSSELECTED',pic:''}]}");
         setEventMetadata("ALLPRODUCTS_FIRSTPAGE","{handler:'suballproducts_firstpage',iparms:[{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV7Code',fld:'vCODE',pic:''},{av:'AV11Name',fld:'vNAME',pic:''},{av:'AV22newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV23newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'dynavSupplier'},{av:'AV10Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV9Sector',fld:'vSECTOR',pic:'ZZZZZ9'}]");
         setEventMetadata("ALLPRODUCTS_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("ALLPRODUCTS_PREVPAGE","{handler:'suballproducts_previouspage',iparms:[{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV7Code',fld:'vCODE',pic:''},{av:'AV11Name',fld:'vNAME',pic:''},{av:'AV22newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV23newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'dynavSupplier'},{av:'AV10Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV9Sector',fld:'vSECTOR',pic:'ZZZZZ9'}]");
         setEventMetadata("ALLPRODUCTS_PREVPAGE",",oparms:[]}");
         setEventMetadata("ALLPRODUCTS_NEXTPAGE","{handler:'suballproducts_nextpage',iparms:[{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV7Code',fld:'vCODE',pic:''},{av:'AV11Name',fld:'vNAME',pic:''},{av:'AV22newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV23newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'dynavSupplier'},{av:'AV10Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV9Sector',fld:'vSECTOR',pic:'ZZZZZ9'}]");
         setEventMetadata("ALLPRODUCTS_NEXTPAGE",",oparms:[]}");
         setEventMetadata("ALLPRODUCTS_LASTPAGE","{handler:'suballproducts_lastpage',iparms:[{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV7Code',fld:'vCODE',pic:''},{av:'AV11Name',fld:'vNAME',pic:''},{av:'AV22newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV23newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'dynavSupplier'},{av:'AV10Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV9Sector',fld:'vSECTOR',pic:'ZZZZZ9'}]");
         setEventMetadata("ALLPRODUCTS_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_COSTPRICEPERCENTAGE","{handler:'Validv_Costpricepercentage',iparms:[]");
         setEventMetadata("VALIDV_COSTPRICEPERCENTAGE",",oparms:[]}");
         setEventMetadata("VALID_PRODUCTCOSTPRICE","{handler:'Valid_Productcostprice',iparms:[]");
         setEventMetadata("VALID_PRODUCTCOSTPRICE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Productwholesaleprice',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("VALIDV_GXV4","{handler:'Validv_Gxv4',iparms:[]");
         setEventMetadata("VALIDV_GXV4",",oparms:[]}");
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
         AV7Code = "";
         AV11Name = "";
         AV22newName = "";
         AV23newCode = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV28CostPriceProductsSelected = new GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem>( context, "SDTProductsSelectedItem", "mtaKB");
         AV29CostPriceIdsSelected = new GxSimpleCollection<int>();
         AV19ProductsSelectedAux = new GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem>( context, "SDTProductsSelectedItem", "mtaKB");
         AV20IdsSelectedAux = new GxSimpleCollection<int>();
         AV6OneProduct = new SdtSDTProductsSelected_SDTProductsSelectedItem(context);
         AV34ErrorMessage = new GeneXus.Utils.SdtMessages_Message(context);
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTextblock3_Jsonclick = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttSelectall_Jsonclick = "";
         AllproductsContainer = new GXWebGrid( context);
         sStyleString = "";
         bttUpdate_Jsonclick = "";
         bttCancel_Jsonclick = "";
         lblTextblock28_Jsonclick = "";
         lblTextblock1_Jsonclick = "";
         lblTextblock2_Jsonclick = "";
         lblTextblock6_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
         lblTextblock8_Jsonclick = "";
         lblTextblock9_Jsonclick = "";
         CostpricefgridContainer = new GXWebGrid( context);
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV39RemoveProduct = "";
         AV51Removeproduct_GXI = "";
         A55ProductCode = "";
         A16ProductName = "";
         A5SupplierName = "";
         A2BrandName = "";
         A10SectorName = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         scmdbuf = "";
         H002J2_A4SupplierId = new int[1] ;
         H002J2_A5SupplierName = new string[] {""} ;
         H002J3_A1BrandId = new int[1] ;
         H002J3_n1BrandId = new bool[] {false} ;
         H002J3_A2BrandName = new string[] {""} ;
         H002J4_A9SectorId = new int[1] ;
         H002J4_n9SectorId = new bool[] {false} ;
         H002J4_A10SectorName = new string[] {""} ;
         lV7Code = "";
         lV11Name = "";
         H002J5_A110ProductActive = new bool[] {false} ;
         H002J5_n110ProductActive = new bool[] {false} ;
         H002J5_A9SectorId = new int[1] ;
         H002J5_n9SectorId = new bool[] {false} ;
         H002J5_A1BrandId = new int[1] ;
         H002J5_n1BrandId = new bool[] {false} ;
         H002J5_A4SupplierId = new int[1] ;
         H002J5_A10SectorName = new string[] {""} ;
         H002J5_A2BrandName = new string[] {""} ;
         H002J5_A5SupplierName = new string[] {""} ;
         H002J5_A16ProductName = new string[] {""} ;
         H002J5_A55ProductCode = new string[] {""} ;
         H002J5_n55ProductCode = new bool[] {false} ;
         H002J5_A15ProductId = new int[1] ;
         H002J5_A89ProductRetailProfit = new decimal[1] ;
         H002J5_n89ProductRetailProfit = new bool[] {false} ;
         H002J5_A85ProductCostPrice = new decimal[1] ;
         H002J5_n85ProductCostPrice = new bool[] {false} ;
         H002J5_A87ProductWholesaleProfit = new decimal[1] ;
         H002J5_n87ProductWholesaleProfit = new bool[] {false} ;
         H002J6_AALLPRODUCTS_nRecordCount = new long[1] ;
         AV37Context = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         AV38WebSession = context.GetSession();
         GXt_SdtSDTProductsSelected_SDTProductsSelectedItem4 = new SdtSDTProductsSelected_SDTProductsSelectedItem(context);
         GXt_objcol_SdtSDTProductsSelected_SDTProductsSelectedItem5 = new GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem>( context, "SDTProductsSelectedItem", "mtaKB");
         AllproductsRow = new GXWebRow();
         CostpricefgridRow = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subAllproducts_Linesclass = "";
         ROClassString = "";
         subCostpricefgrid_Linesclass = "";
         sImgUrl = "";
         AllproductsColumn = new GXWebColumn();
         subCostpricefgrid_Header = "";
         CostpricefgridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpupdatecostprice__default(),
            new Object[][] {
                new Object[] {
               H002J2_A4SupplierId, H002J2_A5SupplierName
               }
               , new Object[] {
               H002J3_A1BrandId, H002J3_A2BrandName
               }
               , new Object[] {
               H002J4_A9SectorId, H002J4_A10SectorName
               }
               , new Object[] {
               H002J5_A110ProductActive, H002J5_n110ProductActive, H002J5_A9SectorId, H002J5_n9SectorId, H002J5_A1BrandId, H002J5_n1BrandId, H002J5_A4SupplierId, H002J5_A10SectorName, H002J5_A2BrandName, H002J5_A5SupplierName,
               H002J5_A16ProductName, H002J5_A55ProductCode, H002J5_n55ProductCode, H002J5_A15ProductId, H002J5_A89ProductRetailProfit, H002J5_n89ProductRetailProfit, H002J5_A85ProductCostPrice, H002J5_n85ProductCostPrice, H002J5_A87ProductWholesaleProfit, H002J5_n87ProductWholesaleProfit
               }
               , new Object[] {
               H002J6_AALLPRODUCTS_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavCtlcode3_Enabled = 0;
         edtavCtlname3_Enabled = 0;
         edtavCtlcostprice3_Enabled = 0;
         edtavCtlretailprice2_Enabled = 0;
         edtavCtlwholesaleprice2_Enabled = 0;
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
      private short subCostpricefgrid_Backcolorstyle ;
      private short COSTPRICEFGRID_nEOF ;
      private short AV30Position ;
      private short nGXWrapped ;
      private short subAllproducts_Backstyle ;
      private short subCostpricefgrid_Backstyle ;
      private short subAllproducts_Titlebackstyle ;
      private short subAllproducts_Allowselection ;
      private short subAllproducts_Allowhovering ;
      private short subAllproducts_Allowcollapsing ;
      private short subCostpricefgrid_Allowselection ;
      private short subCostpricefgrid_Allowhovering ;
      private short subCostpricefgrid_Allowcollapsing ;
      private short subCostpricefgrid_Collapsed ;
      private int nRC_GXsfl_39 ;
      private int nRC_GXsfl_88 ;
      private int subAllproducts_Rows ;
      private int nGXsfl_39_idx=1 ;
      private int AV10Supplier ;
      private int AV8Brand ;
      private int AV9Sector ;
      private int nGXsfl_88_idx=1 ;
      private int AV33IdSelected ;
      private int edtavCode_Enabled ;
      private int edtavName_Enabled ;
      private int divButtonstable_Visible ;
      private int edtavCostpricepercentage_Enabled ;
      private int divCostpricetable_Visible ;
      private int AV42GXV1 ;
      private int A15ProductId ;
      private int gxdynajaxindex ;
      private int subAllproducts_Islastpage ;
      private int subCostpricefgrid_Islastpage ;
      private int edtavCtlcode3_Enabled ;
      private int edtavCtlname3_Enabled ;
      private int edtavCtlcostprice3_Enabled ;
      private int edtavCtlretailprice2_Enabled ;
      private int edtavCtlwholesaleprice2_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A4SupplierId ;
      private int A1BrandId ;
      private int A9SectorId ;
      private int nGXsfl_88_fel_idx=1 ;
      private int AV49GXV8 ;
      private int nGXsfl_88_bak_idx=1 ;
      private int AV50GXV9 ;
      private int AV52GXV10 ;
      private int AV53GXV11 ;
      private int AV54GXV12 ;
      private int idxLst ;
      private int subAllproducts_Backcolor ;
      private int subAllproducts_Allbackcolor ;
      private int subCostpricefgrid_Backcolor ;
      private int subCostpricefgrid_Allbackcolor ;
      private int edtavRemoveproduct_Enabled ;
      private int edtavRemoveproduct_Visible ;
      private int edtavCtlnewcostprice_Enabled ;
      private int edtavCtlnewcostprice_Visible ;
      private int subAllproducts_Titlebackcolor ;
      private int subAllproducts_Selectedindex ;
      private int subAllproducts_Selectioncolor ;
      private int subAllproducts_Hoveringcolor ;
      private int subCostpricefgrid_Selectedindex ;
      private int subCostpricefgrid_Selectioncolor ;
      private int subCostpricefgrid_Hoveringcolor ;
      private long ALLPRODUCTS_nFirstRecordOnPage ;
      private long ALLPRODUCTS_nCurrentRecord ;
      private long COSTPRICEFGRID_nCurrentRecord ;
      private long ALLPRODUCTS_nRecordCount ;
      private long COSTPRICEFGRID_nFirstRecordOnPage ;
      private decimal A89ProductRetailProfit ;
      private decimal A87ProductWholesaleProfit ;
      private decimal AV13CostPricePercentage ;
      private decimal A85ProductCostPrice ;
      private decimal A90ProductRetailPrice ;
      private decimal A88ProductWholesalePrice ;
      private decimal GXt_decimal2 ;
      private decimal GXt_decimal1 ;
      private decimal AV17Value ;
      private decimal GXt_decimal3 ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_39_idx="0001" ;
      private string sGXsfl_88_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
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
      private string edtavCostpricepercentage_Internalname ;
      private string edtavCostpricepercentage_Jsonclick ;
      private string bttUpdate_Internalname ;
      private string bttUpdate_Jsonclick ;
      private string bttCancel_Internalname ;
      private string bttCancel_Jsonclick ;
      private string divCostpricetable_Internalname ;
      private string divTable2_Internalname ;
      private string lblTextblock28_Internalname ;
      private string lblTextblock28_Jsonclick ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string subCostpricefgrid_Internalname ;
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
      private string edtProductRetailPrice_Internalname ;
      private string edtProductWholesalePrice_Internalname ;
      private string gxwrpcisep ;
      private string scmdbuf ;
      private string edtavCtlcode3_Internalname ;
      private string edtavCtlname3_Internalname ;
      private string edtavCtlcostprice3_Internalname ;
      private string edtavCtlretailprice2_Internalname ;
      private string edtavCtlwholesaleprice2_Internalname ;
      private string sGXsfl_88_fel_idx="0001" ;
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
      private string edtProductRetailPrice_Jsonclick ;
      private string edtProductWholesalePrice_Jsonclick ;
      private string edtavCtlnewcostprice_Internalname ;
      private string subCostpricefgrid_Class ;
      private string subCostpricefgrid_Linesclass ;
      private string divGrid1table2_Internalname ;
      private string sImgUrl ;
      private string edtavRemoveproduct_Jsonclick ;
      private string edtavCtlcode3_Jsonclick ;
      private string edtavCtlname3_Jsonclick ;
      private string edtavCtlcostprice3_Jsonclick ;
      private string edtavCtlnewcostprice_Jsonclick ;
      private string edtavCtlretailprice2_Jsonclick ;
      private string edtavCtlwholesaleprice2_Jsonclick ;
      private string subAllproducts_Header ;
      private string subCostpricefgrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV32IsIn ;
      private bool AV24AllOk ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_88_Refreshing=false ;
      private bool n55ProductCode ;
      private bool n85ProductCostPrice ;
      private bool gxdyncontrolsrefreshing ;
      private bool bGXsfl_39_Refreshing=false ;
      private bool A110ProductActive ;
      private bool n110ProductActive ;
      private bool n9SectorId ;
      private bool n1BrandId ;
      private bool n89ProductRetailProfit ;
      private bool n87ProductWholesaleProfit ;
      private bool returnInSub ;
      private bool gx_BV88 ;
      private bool AV39RemoveProduct_IsBlob ;
      private string AV7Code ;
      private string AV11Name ;
      private string AV22newName ;
      private string AV23newCode ;
      private string AV51Removeproduct_GXI ;
      private string A55ProductCode ;
      private string A16ProductName ;
      private string A5SupplierName ;
      private string A2BrandName ;
      private string A10SectorName ;
      private string lV7Code ;
      private string lV11Name ;
      private string AV39RemoveProduct ;
      private GxSimpleCollection<int> AV29CostPriceIdsSelected ;
      private GxSimpleCollection<int> AV20IdsSelectedAux ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid AllproductsContainer ;
      private GXWebGrid CostpricefgridContainer ;
      private GXWebRow AllproductsRow ;
      private GXWebRow CostpricefgridRow ;
      private GXWebColumn AllproductsColumn ;
      private GXWebColumn CostpricefgridColumn ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavSupplier ;
      private GXCombobox dynavBrand ;
      private GXCombobox dynavSector ;
      private IDataStoreProvider pr_default ;
      private int[] H002J2_A4SupplierId ;
      private string[] H002J2_A5SupplierName ;
      private int[] H002J3_A1BrandId ;
      private bool[] H002J3_n1BrandId ;
      private string[] H002J3_A2BrandName ;
      private int[] H002J4_A9SectorId ;
      private bool[] H002J4_n9SectorId ;
      private string[] H002J4_A10SectorName ;
      private bool[] H002J5_A110ProductActive ;
      private bool[] H002J5_n110ProductActive ;
      private int[] H002J5_A9SectorId ;
      private bool[] H002J5_n9SectorId ;
      private int[] H002J5_A1BrandId ;
      private bool[] H002J5_n1BrandId ;
      private int[] H002J5_A4SupplierId ;
      private string[] H002J5_A10SectorName ;
      private string[] H002J5_A2BrandName ;
      private string[] H002J5_A5SupplierName ;
      private string[] H002J5_A16ProductName ;
      private string[] H002J5_A55ProductCode ;
      private bool[] H002J5_n55ProductCode ;
      private int[] H002J5_A15ProductId ;
      private decimal[] H002J5_A89ProductRetailProfit ;
      private bool[] H002J5_n89ProductRetailProfit ;
      private decimal[] H002J5_A85ProductCostPrice ;
      private bool[] H002J5_n85ProductCostPrice ;
      private decimal[] H002J5_A87ProductWholesaleProfit ;
      private bool[] H002J5_n87ProductWholesaleProfit ;
      private long[] H002J6_AALLPRODUCTS_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IGxSession AV38WebSession ;
      private GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> AV28CostPriceProductsSelected ;
      private GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> AV19ProductsSelectedAux ;
      private GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> GXt_objcol_SdtSDTProductsSelected_SDTProductsSelectedItem5 ;
      private GXWebForm Form ;
      private SdtSDTProductsSelected_SDTProductsSelectedItem AV6OneProduct ;
      private SdtSDTProductsSelected_SDTProductsSelectedItem GXt_SdtSDTProductsSelected_SDTProductsSelectedItem4 ;
      private GeneXus.Utils.SdtMessages_Message AV34ErrorMessage ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession AV37Context ;
   }

   public class wpupdatecostprice__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002J5( IGxContext context ,
                                             string AV7Code ,
                                             string AV11Name ,
                                             int AV10Supplier ,
                                             int AV8Brand ,
                                             int AV9Sector ,
                                             string A55ProductCode ,
                                             string A16ProductName ,
                                             int A4SupplierId ,
                                             int A1BrandId ,
                                             int A9SectorId ,
                                             bool A110ProductActive )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[8];
         Object[] GXv_Object7 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[ProductActive], T1.[SectorId], T1.[BrandId], T1.[SupplierId], T2.[SectorName], T3.[BrandName], T4.[SupplierName], T1.[ProductName], T1.[ProductCode], T1.[ProductId], T1.[ProductRetailProfit], T1.[ProductCostPrice], T1.[ProductWholesaleProfit]";
         sFromString = " FROM ((([Product] T1 LEFT JOIN [Sector] T2 ON T2.[SectorId] = T1.[SectorId]) LEFT JOIN [Brand] T3 ON T3.[BrandId] = T1.[BrandId]) INNER JOIN [Supplier] T4 ON T4.[SupplierId] = T1.[SupplierId])";
         sOrderString = "";
         AddWhere(sWhereString, "(T1.[ProductActive] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7Code)) )
         {
            AddWhere(sWhereString, "(T1.[ProductCode] like @lV7Code)");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11Name)) )
         {
            AddWhere(sWhereString, "(T1.[ProductName] like @lV11Name)");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( ! (0==AV10Supplier) )
         {
            AddWhere(sWhereString, "(T1.[SupplierId] = @AV10Supplier)");
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
         if ( ! (0==AV9Sector) )
         {
            AddWhere(sWhereString, "(T1.[SectorId] = @AV9Sector)");
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

      protected Object[] conditional_H002J6( IGxContext context ,
                                             string AV7Code ,
                                             string AV11Name ,
                                             int AV10Supplier ,
                                             int AV8Brand ,
                                             int AV9Sector ,
                                             string A55ProductCode ,
                                             string A16ProductName ,
                                             int A4SupplierId ,
                                             int A1BrandId ,
                                             int A9SectorId ,
                                             bool A110ProductActive )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[5];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ((([Product] T1 LEFT JOIN [Sector] T3 ON T3.[SectorId] = T1.[SectorId]) LEFT JOIN [Brand] T2 ON T2.[BrandId] = T1.[BrandId]) INNER JOIN [Supplier] T4 ON T4.[SupplierId] = T1.[SupplierId])";
         AddWhere(sWhereString, "(T1.[ProductActive] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7Code)) )
         {
            AddWhere(sWhereString, "(T1.[ProductCode] like @lV7Code)");
         }
         else
         {
            GXv_int8[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11Name)) )
         {
            AddWhere(sWhereString, "(T1.[ProductName] like @lV11Name)");
         }
         else
         {
            GXv_int8[1] = 1;
         }
         if ( ! (0==AV10Supplier) )
         {
            AddWhere(sWhereString, "(T1.[SupplierId] = @AV10Supplier)");
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
         if ( ! (0==AV9Sector) )
         {
            AddWhere(sWhereString, "(T1.[SectorId] = @AV9Sector)");
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
                     return conditional_H002J5(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (bool)dynConstraints[10] );
               case 4 :
                     return conditional_H002J6(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (bool)dynConstraints[10] );
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
          Object[] prmH002J2;
          prmH002J2 = new Object[] {
          };
          Object[] prmH002J3;
          prmH002J3 = new Object[] {
          };
          Object[] prmH002J4;
          prmH002J4 = new Object[] {
          };
          Object[] prmH002J5;
          prmH002J5 = new Object[] {
          new ParDef("@lV7Code",GXType.NVarChar,100,0) ,
          new ParDef("@lV11Name",GXType.NVarChar,60,0) ,
          new ParDef("@AV10Supplier",GXType.Int32,6,0) ,
          new ParDef("@AV8Brand",GXType.Int32,6,0) ,
          new ParDef("@AV9Sector",GXType.Int32,6,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH002J6;
          prmH002J6 = new Object[] {
          new ParDef("@lV7Code",GXType.NVarChar,100,0) ,
          new ParDef("@lV11Name",GXType.NVarChar,60,0) ,
          new ParDef("@AV10Supplier",GXType.Int32,6,0) ,
          new ParDef("@AV8Brand",GXType.Int32,6,0) ,
          new ParDef("@AV9Sector",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002J2", "SELECT [SupplierId], [SupplierName] FROM [Supplier] ORDER BY [SupplierName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002J2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002J3", "SELECT [BrandId], [BrandName] FROM [Brand] ORDER BY [BrandName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002J3,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002J4", "SELECT [SectorId], [SectorName] FROM [Sector] ORDER BY [SectorName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002J4,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002J5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002J5,6, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002J6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002J6,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((string[]) buf[8])[0] = rslt.getVarchar(6);
                ((string[]) buf[9])[0] = rslt.getVarchar(7);
                ((string[]) buf[10])[0] = rslt.getVarchar(8);
                ((string[]) buf[11])[0] = rslt.getVarchar(9);
                ((bool[]) buf[12])[0] = rslt.wasNull(9);
                ((int[]) buf[13])[0] = rslt.getInt(10);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(11);
                ((bool[]) buf[15])[0] = rslt.wasNull(11);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(12);
                ((bool[]) buf[17])[0] = rslt.wasNull(12);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(13);
                ((bool[]) buf[19])[0] = rslt.wasNull(13);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
