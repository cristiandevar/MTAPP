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
   public class wpupdatepriceandprofit : GXDataArea
   {
      public wpupdatepriceandprofit( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public wpupdatepriceandprofit( IGxContext context )
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
         cmbavUpdatetype = new GXCombobox();
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
         nRC_GXsfl_36 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_36"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_36_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_36_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_36_idx = GetPar( "sGXsfl_36_idx");
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
         ajax_req_read_hidden_sdt(GetNextPar( ), AV5ProductsSelected);
         AV22newName = GetPar( "newName");
         AV23newCode = GetPar( "newCode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrAllproducts_refresh( subAllproducts_Rows, AV7Code, AV11Name, AV10Supplier, AV8Brand, AV9Sector, AV5ProductsSelected, AV22newName, AV23newCode) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrAllproducts_refresh_invoke */
      }

      protected void gxnrGrid1_newrow_invoke( )
      {
         nRC_GXsfl_86 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_86"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_86_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_86_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_86_idx = GetPar( "sGXsfl_86_idx");
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
         subAllproducts_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subAllproducts_Rows"), "."), 18, MidpointRounding.ToEven));
         AV7Code = GetPar( "Code");
         AV11Name = GetPar( "Name");
         dynavSupplier.FromJSonString( GetNextPar( ));
         AV10Supplier = (int)(Math.Round(NumberUtil.Val( GetPar( "Supplier"), "."), 18, MidpointRounding.ToEven));
         dynavBrand.FromJSonString( GetNextPar( ));
         AV8Brand = (int)(Math.Round(NumberUtil.Val( GetPar( "Brand"), "."), 18, MidpointRounding.ToEven));
         dynavSector.FromJSonString( GetNextPar( ));
         AV9Sector = (int)(Math.Round(NumberUtil.Val( GetPar( "Sector"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV5ProductsSelected);
         AV22newName = GetPar( "newName");
         AV23newCode = GetPar( "newCode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subAllproducts_Rows, AV7Code, AV11Name, AV10Supplier, AV8Brand, AV9Sector, AV5ProductsSelected, AV22newName, AV23newCode) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid1_refresh_invoke */
      }

      protected void gxnrCostpricefgrid_newrow_invoke( )
      {
         nRC_GXsfl_111 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_111"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_111_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_111_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_111_idx = GetPar( "sGXsfl_111_idx");
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
         ajax_req_read_hidden_sdt(GetNextPar( ), AV5ProductsSelected);
         AV22newName = GetPar( "newName");
         AV23newCode = GetPar( "newCode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrCostpricefgrid_refresh( subAllproducts_Rows, AV7Code, AV11Name, AV10Supplier, AV8Brand, AV9Sector, AV5ProductsSelected, AV22newName, AV23newCode) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrCostpricefgrid_refresh_invoke */
      }

      protected void gxnrRetailfgrid_newrow_invoke( )
      {
         nRC_GXsfl_175 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_175"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_175_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_175_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_175_idx = GetPar( "sGXsfl_175_idx");
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
         AV7Code = GetPar( "Code");
         AV11Name = GetPar( "Name");
         dynavSupplier.FromJSonString( GetNextPar( ));
         AV10Supplier = (int)(Math.Round(NumberUtil.Val( GetPar( "Supplier"), "."), 18, MidpointRounding.ToEven));
         dynavBrand.FromJSonString( GetNextPar( ));
         AV8Brand = (int)(Math.Round(NumberUtil.Val( GetPar( "Brand"), "."), 18, MidpointRounding.ToEven));
         dynavSector.FromJSonString( GetNextPar( ));
         AV9Sector = (int)(Math.Round(NumberUtil.Val( GetPar( "Sector"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV5ProductsSelected);
         AV22newName = GetPar( "newName");
         AV23newCode = GetPar( "newCode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrRetailfgrid_refresh( subAllproducts_Rows, AV7Code, AV11Name, AV10Supplier, AV8Brand, AV9Sector, AV5ProductsSelected, AV22newName, AV23newCode) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrRetailfgrid_refresh_invoke */
      }

      protected void gxnrWholesalefgrid_newrow_invoke( )
      {
         nRC_GXsfl_237 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_237"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_237_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_237_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_237_idx = GetPar( "sGXsfl_237_idx");
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
         AV7Code = GetPar( "Code");
         AV11Name = GetPar( "Name");
         dynavSupplier.FromJSonString( GetNextPar( ));
         AV10Supplier = (int)(Math.Round(NumberUtil.Val( GetPar( "Supplier"), "."), 18, MidpointRounding.ToEven));
         dynavBrand.FromJSonString( GetNextPar( ));
         AV8Brand = (int)(Math.Round(NumberUtil.Val( GetPar( "Brand"), "."), 18, MidpointRounding.ToEven));
         dynavSector.FromJSonString( GetNextPar( ));
         AV9Sector = (int)(Math.Round(NumberUtil.Val( GetPar( "Sector"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV5ProductsSelected);
         AV22newName = GetPar( "newName");
         AV23newCode = GetPar( "newCode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrWholesalefgrid_refresh( subAllproducts_Rows, AV7Code, AV11Name, AV10Supplier, AV8Brand, AV9Sector, AV5ProductsSelected, AV22newName, AV23newCode) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpupdatepriceandprofit.aspx") +"\">") ;
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPRODUCTSSELECTED", AV5ProductsSelected);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPRODUCTSSELECTED", AV5ProductsSelected);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vPRODUCTSSELECTED", GetSecureSignedToken( "", AV5ProductsSelected, context));
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Productsselected", AV5ProductsSelected);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Productsselected", AV5ProductsSelected);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_Productsselected", GetSecureSignedToken( "", AV5ProductsSelected, context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_36", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_36), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_86", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_86), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_111", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_111), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_175", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_175), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_237", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_237), 8, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vISIN", AV32IsIn);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOSTPRICEPRODUCTSSELECTED", AV28CostPriceProductsSelected);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOSTPRICEPRODUCTSSELECTED", AV28CostPriceProductsSelected);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOSTPRICEIDSSELECTED", AV29CostPriceIdsSelected);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOSTPRICEIDSSELECTED", AV29CostPriceIdsSelected);
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
         GxWebStd.gx_hidden_field( context, "vVALUE", StringUtil.LTrim( StringUtil.NToC( AV17Value, 10, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "vNEWNAME", AV22newName);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV22newName, "")), context));
         GxWebStd.gx_hidden_field( context, "vNEWCODE", AV23newCode);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV23newCode, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPRODUCTSSELECTED", AV5ProductsSelected);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPRODUCTSSELECTED", AV5ProductsSelected);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vPRODUCTSSELECTED", GetSecureSignedToken( "", AV5ProductsSelected, context));
         GxWebStd.gx_boolean_hidden_field( context, "vALLOK", AV24AllOk);
         GxWebStd.gx_hidden_field( context, "ALLPRODUCTS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(ALLPRODUCTS_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ALLPRODUCTS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(ALLPRODUCTS_nEOF), 1, 0, ".", "")));
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
         return formatLink("wpupdatepriceandprofit.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WPUpdatePriceAndProfit" ;
      }

      public override string GetPgmdesc( )
      {
         return "WPUpdate Price And Profit" ;
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavUpdatetype_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavUpdatetype_Internalname, "Update Type", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 11,'',false,'" + sGXsfl_36_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavUpdatetype, cmbavUpdatetype_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV12UpdateType), 1, 0)), 1, cmbavUpdatetype_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavUpdatetype.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,11);\"", "", true, 0, "HLP_WPUpdatePriceAndProfit.htm");
            cmbavUpdatetype.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV12UpdateType), 1, 0));
            AssignProp("", false, cmbavUpdatetype_Internalname, "Values", (string)(cmbavUpdatetype.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavCode_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCode_Internalname, "Product Code", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 15,'',false,'" + sGXsfl_36_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCode_Internalname, AV7Code, StringUtil.RTrim( context.localUtil.Format( AV7Code, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,15);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCode_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCode_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_WPUpdatePriceAndProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavName_Internalname, "Product Name", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'" + sGXsfl_36_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavName_Internalname, AV11Name, StringUtil.RTrim( context.localUtil.Format( AV11Name, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,19);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavName_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_WPUpdatePriceAndProfit.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'" + sGXsfl_36_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavSupplier, dynavSupplier_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV10Supplier), 6, 0)), 1, dynavSupplier_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavSupplier.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,23);\"", "", true, 0, "HLP_WPUpdatePriceAndProfit.htm");
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
            GxWebStd.gx_label_element( context, dynavBrand_Internalname, "Brand", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'" + sGXsfl_36_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavBrand, dynavBrand_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV8Brand), 6, 0)), 1, dynavBrand_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavBrand.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "", true, 0, "HLP_WPUpdatePriceAndProfit.htm");
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
            GxWebStd.gx_label_element( context, dynavSector_Internalname, "Sector", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'" + sGXsfl_36_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavSector, dynavSector_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV9Sector), 6, 0)), 1, dynavSector_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavSector.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "", true, 0, "HLP_WPUpdatePriceAndProfit.htm");
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
            StartGridControl36( ) ;
         }
         if ( wbEnd == 36 )
         {
            wbEnd = 0;
            nRC_GXsfl_36 = (int)(nGXsfl_36_idx-1);
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
            GxWebStd.gx_div_start( context, divButtonstable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttUpdate_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(36), 2, 0)+","+"null"+");", "Update", bttUpdate_Jsonclick, 7, "Update", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e112j1_client"+"'", TempTags, "", 2, "HLP_WPUpdatePriceAndProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(36), 2, 0)+","+"null"+");", "Cancel", bttCancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPUpdatePriceAndProfit.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavCostpricepercentage_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCostpricepercentage_Internalname, "Cost Price Perc.", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'" + sGXsfl_36_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCostpricepercentage_Internalname, StringUtil.LTrim( StringUtil.NToC( AV13CostPricePercentage, 6, 2, ".", "")), StringUtil.LTrim( ((edtavCostpricepercentage_Enabled!=0) ? context.localUtil.Format( AV13CostPricePercentage, "ZZ9.99") : context.localUtil.Format( AV13CostPricePercentage, "ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,65);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCostpricepercentage_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCostpricepercentage_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Percentage", "right", false, "", "HLP_WPUpdatePriceAndProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Code", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdatePriceAndProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Name", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdatePriceAndProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "U. Cost Price", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdatePriceAndProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "New U. C. Price", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdatePriceAndProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "R. Price", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdatePriceAndProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "W. Price", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdatePriceAndProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock28_Internalname, "Action", "", "", lblTextblock28_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdatePriceAndProfit.htm");
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
            Grid1Container.SetIsFreestyle(true);
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl86( ) ;
         }
         if ( wbEnd == 86 )
         {
            wbEnd = 0;
            nRC_GXsfl_86 = (int)(nGXsfl_86_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV36GXV1 = nGXsfl_86_idx;
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
            /*  Grid Control  */
            CostpricefgridContainer.SetIsFreestyle(true);
            CostpricefgridContainer.SetWrapped(nGXWrapped);
            StartGridControl111( ) ;
         }
         if ( wbEnd == 111 )
         {
            wbEnd = 0;
            nRC_GXsfl_111 = (int)(nGXsfl_111_idx-1);
            if ( CostpricefgridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV43GXV8 = nGXsfl_111_idx;
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divRetaiprofitltable_Internalname, divRetaiprofitltable_Visible, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavRppercentage_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRppercentage_Internalname, "R. Profit", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 150,'',false,'" + sGXsfl_36_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRppercentage_Internalname, StringUtil.LTrim( StringUtil.NToC( AV14RPPercentage, 6, 2, ".", "")), StringUtil.LTrim( ((edtavRppercentage_Enabled!=0) ? context.localUtil.Format( AV14RPPercentage, "ZZ9.99") : context.localUtil.Format( AV14RPPercentage, "ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,150);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRppercentage_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavRppercentage_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Percentage", "right", false, "", "HLP_WPUpdatePriceAndProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Code", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdatePriceAndProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "Name", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdatePriceAndProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "Supplier", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdatePriceAndProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock13_Internalname, "Brand", "", "", lblTextblock13_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdatePriceAndProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock14_Internalname, "Sector", "", "", lblTextblock14_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdatePriceAndProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock15_Internalname, "U. Cost Price", "", "", lblTextblock15_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdatePriceAndProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock16_Internalname, "R. Profit", "", "", lblTextblock16_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdatePriceAndProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock17_Internalname, "New R. Profit", "", "", lblTextblock17_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdatePriceAndProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock18_Internalname, "R. Price", "", "", lblTextblock18_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdatePriceAndProfit.htm");
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
            StartGridControl175( ) ;
         }
         if ( wbEnd == 175 )
         {
            wbEnd = 0;
            nRC_GXsfl_175 = (int)(nGXsfl_175_idx-1);
            if ( RetailfgridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV53GXV18 = nGXsfl_175_idx;
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavWppercentage_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWppercentage_Internalname, "W. Profit", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 212,'',false,'" + sGXsfl_36_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWppercentage_Internalname, StringUtil.LTrim( StringUtil.NToC( AV15WPPercentage, 6, 2, ".", "")), StringUtil.LTrim( ((edtavWppercentage_Enabled!=0) ? context.localUtil.Format( AV15WPPercentage, "ZZ9.99") : context.localUtil.Format( AV15WPPercentage, "ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,212);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWppercentage_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavWppercentage_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Percentage", "right", false, "", "HLP_WPUpdatePriceAndProfit.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock19_Internalname, "Code", "", "", lblTextblock19_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdatePriceAndProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock20_Internalname, "Name", "", "", lblTextblock20_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdatePriceAndProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock21_Internalname, "Supplier", "", "", lblTextblock21_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdatePriceAndProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock22_Internalname, "Brand", "", "", lblTextblock22_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdatePriceAndProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock23_Internalname, "Sector", "", "", lblTextblock23_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdatePriceAndProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock24_Internalname, "U. Cost Price", "", "", lblTextblock24_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdatePriceAndProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock25_Internalname, "W. Profit", "", "", lblTextblock25_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdatePriceAndProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock26_Internalname, "New W. Profit", "", "", lblTextblock26_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdatePriceAndProfit.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock27_Internalname, "W. Price", "", "", lblTextblock27_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdatePriceAndProfit.htm");
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
            StartGridControl237( ) ;
         }
         if ( wbEnd == 237 )
         {
            wbEnd = 0;
            nRC_GXsfl_237 = (int)(nGXsfl_237_idx-1);
            if ( WholesalefgridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV63GXV28 = nGXsfl_237_idx;
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
         if ( wbEnd == 36 )
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
         if ( wbEnd == 86 )
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
                  AV36GXV1 = nGXsfl_86_idx;
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
         if ( wbEnd == 111 )
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
                  AV43GXV8 = nGXsfl_111_idx;
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
         if ( wbEnd == 175 )
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
                  AV53GXV18 = nGXsfl_175_idx;
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
         if ( wbEnd == 237 )
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
                  AV63GXV28 = nGXsfl_237_idx;
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
            Form.Meta.addItem("description", "WPUpdate Price And Profit", 0) ;
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
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'COSTPRICEBTNREMOVE'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'CostPriceBtnRemove' */
                              E122J2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 20), "'COSTPRICEBTNREMOVE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRID1.LOAD") == 0 ) )
                           {
                              nGXsfl_86_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_86_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_86_idx), 4, 0), 4, "0");
                              SubsflControlProps_866( ) ;
                              AV36GXV1 = nGXsfl_86_idx;
                              if ( ( AV28CostPriceProductsSelected.Count >= AV36GXV1 ) && ( AV36GXV1 > 0 ) )
                              {
                                 AV28CostPriceProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV28CostPriceProductsSelected.Item(AV36GXV1));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "'COSTPRICEBTNREMOVE'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'CostPriceBtnRemove' */
                                    E122J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID1.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E132J6 ();
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
                           else if ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "COSTPRICEFGRID.LOAD") == 0 )
                           {
                              nGXsfl_111_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_111_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_111_idx), 4, 0), 4, "0");
                              SubsflControlProps_1115( ) ;
                              AV43GXV8 = nGXsfl_111_idx;
                              if ( ( AV5ProductsSelected.Count >= AV43GXV8 ) && ( AV43GXV8 > 0 ) )
                              {
                                 AV5ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV43GXV8));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "COSTPRICEFGRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E142J5 ();
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
                           else if ( StringUtil.StrCmp(StringUtil.Left( sEvt, 16), "RETAILFGRID.LOAD") == 0 )
                           {
                              nGXsfl_175_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_175_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_175_idx), 4, 0), 4, "0");
                              SubsflControlProps_1754( ) ;
                              AV53GXV18 = nGXsfl_175_idx;
                              if ( ( AV5ProductsSelected.Count >= AV53GXV18 ) && ( AV53GXV18 > 0 ) )
                              {
                                 AV5ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV53GXV18));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "RETAILFGRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E152J4 ();
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
                           else if ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "WHOLESALEFGRID.LOAD") == 0 )
                           {
                              nGXsfl_237_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_237_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_237_idx), 4, 0), 4, "0");
                              SubsflControlProps_2373( ) ;
                              AV63GXV28 = nGXsfl_237_idx;
                              if ( ( AV5ProductsSelected.Count >= AV63GXV28 ) && ( AV63GXV28 > 0 ) )
                              {
                                 AV5ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV63GXV28));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "WHOLESALEFGRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E162J3 ();
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
                           else if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "PRODUCTNAME.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 16), "ALLPRODUCTS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "PRODUCTNAME.CLICK") == 0 ) )
                           {
                              nGXsfl_36_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_36_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_36_idx), 4, 0), 4, "0");
                              SubsflControlProps_362( ) ;
                              A15ProductId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtProductId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A55ProductCode = cgiGet( edtProductCode_Internalname);
                              n55ProductCode = false;
                              A16ProductName = cgiGet( edtProductName_Internalname);
                              A5SupplierName = cgiGet( edtSupplierName_Internalname);
                              A2BrandName = cgiGet( edtBrandName_Internalname);
                              A10SectorName = cgiGet( edtSectorName_Internalname);
                              A85ProductCostPrice = context.localUtil.CToN( cgiGet( edtProductCostPrice_Internalname), ".", ",");
                              A89ProductRetailProfit = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtProductRetailProfit_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              n89ProductRetailProfit = false;
                              A90ProductRetailPrice = context.localUtil.CToN( cgiGet( edtProductRetailPrice_Internalname), ".", ",");
                              A87ProductWholesaleProfit = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtProductWholesaleProfit_Internalname), ".", ","), 18, MidpointRounding.ToEven));
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
                                    E172J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "PRODUCTNAME.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E182J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ALLPRODUCTS.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E192J2 ();
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
               GX_FocusControl = cmbavUpdatetype_Internalname;
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
         SubsflControlProps_362( ) ;
         while ( nGXsfl_36_idx <= nRC_GXsfl_36 )
         {
            sendrow_362( ) ;
            nGXsfl_36_idx = ((subAllproducts_Islastpage==1)&&(nGXsfl_36_idx+1>subAllproducts_fnc_Recordsperpage( )) ? 1 : nGXsfl_36_idx+1);
            sGXsfl_36_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_36_idx), 4, 0), 4, "0");
            SubsflControlProps_362( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( AllproductsContainer)) ;
         /* End function gxnrAllproducts_newrow */
      }

      protected void gxnrWholesalefgrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_2373( ) ;
         while ( nGXsfl_237_idx <= nRC_GXsfl_237 )
         {
            sendrow_2373( ) ;
            nGXsfl_237_idx = ((subWholesalefgrid_Islastpage==1)&&(nGXsfl_237_idx+1>subWholesalefgrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_237_idx+1);
            sGXsfl_237_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_237_idx), 4, 0), 4, "0");
            SubsflControlProps_2373( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( WholesalefgridContainer)) ;
         /* End function gxnrWholesalefgrid_newrow */
      }

      protected void gxnrRetailfgrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1754( ) ;
         while ( nGXsfl_175_idx <= nRC_GXsfl_175 )
         {
            sendrow_1754( ) ;
            nGXsfl_175_idx = ((subRetailfgrid_Islastpage==1)&&(nGXsfl_175_idx+1>subRetailfgrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_175_idx+1);
            sGXsfl_175_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_175_idx), 4, 0), 4, "0");
            SubsflControlProps_1754( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( RetailfgridContainer)) ;
         /* End function gxnrRetailfgrid_newrow */
      }

      protected void gxnrCostpricefgrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1115( ) ;
         while ( nGXsfl_111_idx <= nRC_GXsfl_111 )
         {
            sendrow_1115( ) ;
            nGXsfl_111_idx = ((subCostpricefgrid_Islastpage==1)&&(nGXsfl_111_idx+1>subCostpricefgrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_111_idx+1);
            sGXsfl_111_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_111_idx), 4, 0), 4, "0");
            SubsflControlProps_1115( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( CostpricefgridContainer)) ;
         /* End function gxnrCostpricefgrid_newrow */
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_866( ) ;
         while ( nGXsfl_86_idx <= nRC_GXsfl_86 )
         {
            sendrow_866( ) ;
            nGXsfl_86_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_86_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_86_idx+1);
            sGXsfl_86_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_86_idx), 4, 0), 4, "0");
            SubsflControlProps_866( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrAllproducts_refresh( int subAllproducts_Rows ,
                                              string AV7Code ,
                                              string AV11Name ,
                                              int AV10Supplier ,
                                              int AV8Brand ,
                                              int AV9Sector ,
                                              GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> AV5ProductsSelected ,
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

      protected void gxgrGrid1_refresh( int subAllproducts_Rows ,
                                        string AV7Code ,
                                        string AV11Name ,
                                        int AV10Supplier ,
                                        int AV8Brand ,
                                        int AV9Sector ,
                                        GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> AV5ProductsSelected ,
                                        string AV22newName ,
                                        string AV23newCode )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF2J6( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void gxgrCostpricefgrid_refresh( int subAllproducts_Rows ,
                                                 string AV7Code ,
                                                 string AV11Name ,
                                                 int AV10Supplier ,
                                                 int AV8Brand ,
                                                 int AV9Sector ,
                                                 GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> AV5ProductsSelected ,
                                                 string AV22newName ,
                                                 string AV23newCode )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         COSTPRICEFGRID_nCurrentRecord = 0;
         RF2J5( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrCostpricefgrid_refresh */
      }

      protected void gxgrRetailfgrid_refresh( int subAllproducts_Rows ,
                                              string AV7Code ,
                                              string AV11Name ,
                                              int AV10Supplier ,
                                              int AV8Brand ,
                                              int AV9Sector ,
                                              GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> AV5ProductsSelected ,
                                              string AV22newName ,
                                              string AV23newCode )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         RETAILFGRID_nCurrentRecord = 0;
         RF2J4( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrRetailfgrid_refresh */
      }

      protected void gxgrWholesalefgrid_refresh( int subAllproducts_Rows ,
                                                 string AV7Code ,
                                                 string AV11Name ,
                                                 int AV10Supplier ,
                                                 int AV8Brand ,
                                                 int AV9Sector ,
                                                 GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> AV5ProductsSelected ,
                                                 string AV22newName ,
                                                 string AV23newCode )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         WHOLESALEFGRID_nCurrentRecord = 0;
         RF2J3( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrWholesalefgrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUCTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A15ProductId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "PRODUCTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUCTCOSTPRICE", GetSecureSignedToken( "", context.localUtil.Format( A85ProductCostPrice, "ZZZZZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "PRODUCTCOSTPRICE", StringUtil.LTrim( StringUtil.NToC( A85ProductCostPrice, 10, 2, ".", "")));
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
         if ( cmbavUpdatetype.ItemCount > 0 )
         {
            AV12UpdateType = (short)(Math.Round(NumberUtil.Val( cmbavUpdatetype.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV12UpdateType), 1, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV12UpdateType", StringUtil.Str( (decimal)(AV12UpdateType), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavUpdatetype.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV12UpdateType), 1, 0));
            AssignProp("", false, cmbavUpdatetype_Internalname, "Values", cmbavUpdatetype.ToJavascriptSource(), true);
         }
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
         RF2J6( ) ;
         RF2J5( ) ;
         RF2J4( ) ;
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
         AssignProp("", false, edtavCtlcode3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcode3_Enabled), 5, 0), !bGXsfl_86_Refreshing);
         edtavCtlname3_Enabled = 0;
         AssignProp("", false, edtavCtlname3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname3_Enabled), 5, 0), !bGXsfl_86_Refreshing);
         edtavCtlcostprice3_Enabled = 0;
         AssignProp("", false, edtavCtlcostprice3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcostprice3_Enabled), 5, 0), !bGXsfl_86_Refreshing);
         edtavCtlretailprice2_Enabled = 0;
         AssignProp("", false, edtavCtlretailprice2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlretailprice2_Enabled), 5, 0), !bGXsfl_86_Refreshing);
         edtavCtlwholesaleprice2_Enabled = 0;
         AssignProp("", false, edtavCtlwholesaleprice2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlwholesaleprice2_Enabled), 5, 0), !bGXsfl_86_Refreshing);
         edtavCtlcode_Enabled = 0;
         AssignProp("", false, edtavCtlcode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcode_Enabled), 5, 0), !bGXsfl_111_Refreshing);
         edtavCtlname_Enabled = 0;
         AssignProp("", false, edtavCtlname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname_Enabled), 5, 0), !bGXsfl_111_Refreshing);
         edtavCtlsupplier_Enabled = 0;
         AssignProp("", false, edtavCtlsupplier_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsupplier_Enabled), 5, 0), !bGXsfl_111_Refreshing);
         edtavCtlbrand_Enabled = 0;
         AssignProp("", false, edtavCtlbrand_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlbrand_Enabled), 5, 0), !bGXsfl_111_Refreshing);
         edtavCtlsector_Enabled = 0;
         AssignProp("", false, edtavCtlsector_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsector_Enabled), 5, 0), !bGXsfl_111_Refreshing);
         edtavCtlcostprice_Enabled = 0;
         AssignProp("", false, edtavCtlcostprice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcostprice_Enabled), 5, 0), !bGXsfl_111_Refreshing);
         edtavCtlretailprice_Enabled = 0;
         AssignProp("", false, edtavCtlretailprice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlretailprice_Enabled), 5, 0), !bGXsfl_111_Refreshing);
         edtavCtlwholesaleprice_Enabled = 0;
         AssignProp("", false, edtavCtlwholesaleprice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlwholesaleprice_Enabled), 5, 0), !bGXsfl_111_Refreshing);
         edtavCtlcode1_Enabled = 0;
         AssignProp("", false, edtavCtlcode1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcode1_Enabled), 5, 0), !bGXsfl_175_Refreshing);
         edtavCtlname1_Enabled = 0;
         AssignProp("", false, edtavCtlname1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname1_Enabled), 5, 0), !bGXsfl_175_Refreshing);
         edtavCtlsupplier1_Enabled = 0;
         AssignProp("", false, edtavCtlsupplier1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsupplier1_Enabled), 5, 0), !bGXsfl_175_Refreshing);
         edtavCtlbrand1_Enabled = 0;
         AssignProp("", false, edtavCtlbrand1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlbrand1_Enabled), 5, 0), !bGXsfl_175_Refreshing);
         edtavCtlsector1_Enabled = 0;
         AssignProp("", false, edtavCtlsector1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsector1_Enabled), 5, 0), !bGXsfl_175_Refreshing);
         edtavCtlcostprice1_Enabled = 0;
         AssignProp("", false, edtavCtlcostprice1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcostprice1_Enabled), 5, 0), !bGXsfl_175_Refreshing);
         edtavCtlretailprofit1_Enabled = 0;
         AssignProp("", false, edtavCtlretailprofit1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlretailprofit1_Enabled), 5, 0), !bGXsfl_175_Refreshing);
         edtavCtlretailprice1_Enabled = 0;
         AssignProp("", false, edtavCtlretailprice1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlretailprice1_Enabled), 5, 0), !bGXsfl_175_Refreshing);
         edtavCtlcode2_Enabled = 0;
         AssignProp("", false, edtavCtlcode2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcode2_Enabled), 5, 0), !bGXsfl_237_Refreshing);
         edtavCtlname2_Enabled = 0;
         AssignProp("", false, edtavCtlname2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname2_Enabled), 5, 0), !bGXsfl_237_Refreshing);
         edtavCtlsupplier2_Enabled = 0;
         AssignProp("", false, edtavCtlsupplier2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsupplier2_Enabled), 5, 0), !bGXsfl_237_Refreshing);
         edtavCtlbrand2_Enabled = 0;
         AssignProp("", false, edtavCtlbrand2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlbrand2_Enabled), 5, 0), !bGXsfl_237_Refreshing);
         edtavCtlsector2_Enabled = 0;
         AssignProp("", false, edtavCtlsector2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsector2_Enabled), 5, 0), !bGXsfl_237_Refreshing);
         edtavCtlcostprice2_Enabled = 0;
         AssignProp("", false, edtavCtlcostprice2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcostprice2_Enabled), 5, 0), !bGXsfl_237_Refreshing);
         edtavCtlwholesaleprofit1_Enabled = 0;
         AssignProp("", false, edtavCtlwholesaleprofit1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlwholesaleprofit1_Enabled), 5, 0), !bGXsfl_237_Refreshing);
         edtavCtlwholesaleprice1_Enabled = 0;
         AssignProp("", false, edtavCtlwholesaleprice1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlwholesaleprice1_Enabled), 5, 0), !bGXsfl_237_Refreshing);
      }

      protected void RF2J2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            AllproductsContainer.ClearRows();
         }
         wbStart = 36;
         nGXsfl_36_idx = 1;
         sGXsfl_36_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_36_idx), 4, 0), 4, "0");
         SubsflControlProps_362( ) ;
         bGXsfl_36_Refreshing = true;
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
            SubsflControlProps_362( ) ;
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
                                                 A9SectorId } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                                 }
            });
            lV7Code = StringUtil.Concat( StringUtil.RTrim( AV7Code), "%", "");
            lV11Name = StringUtil.Concat( StringUtil.RTrim( AV11Name), "%", "");
            /* Using cursor H002J5 */
            pr_default.execute(3, new Object[] {lV7Code, lV11Name, AV10Supplier, AV8Brand, AV9Sector, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_36_idx = 1;
            sGXsfl_36_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_36_idx), 4, 0), 4, "0");
            SubsflControlProps_362( ) ;
            while ( ( (pr_default.getStatus(3) != 101) ) && ( ( ALLPRODUCTS_nCurrentRecord < subAllproducts_fnc_Recordsperpage( ) ) ) )
            {
               A9SectorId = H002J5_A9SectorId[0];
               A1BrandId = H002J5_A1BrandId[0];
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
               A87ProductWholesaleProfit = H002J5_A87ProductWholesaleProfit[0];
               n87ProductWholesaleProfit = H002J5_n87ProductWholesaleProfit[0];
               A85ProductCostPrice = H002J5_A85ProductCostPrice[0];
               A10SectorName = H002J5_A10SectorName[0];
               A2BrandName = H002J5_A2BrandName[0];
               A5SupplierName = H002J5_A5SupplierName[0];
               A90ProductRetailPrice = (decimal)(A85ProductCostPrice*(1+A89ProductRetailProfit/ (decimal)(100)));
               A88ProductWholesalePrice = (decimal)(A85ProductCostPrice*(1+A87ProductWholesaleProfit/ (decimal)(100)));
               E192J2 ();
               pr_default.readNext(3);
            }
            ALLPRODUCTS_nEOF = (short)(((pr_default.getStatus(3) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "ALLPRODUCTS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(ALLPRODUCTS_nEOF), 1, 0, ".", "")));
            pr_default.close(3);
            wbEnd = 36;
            WB2J0( ) ;
         }
         bGXsfl_36_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2J2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUCTID"+"_"+sGXsfl_36_idx, GetSecureSignedToken( sGXsfl_36_idx, context.localUtil.Format( (decimal)(A15ProductId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUCTCOSTPRICE"+"_"+sGXsfl_36_idx, GetSecureSignedToken( sGXsfl_36_idx, context.localUtil.Format( A85ProductCostPrice, "ZZZZZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "vNEWNAME", AV22newName);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV22newName, "")), context));
         GxWebStd.gx_hidden_field( context, "vNEWCODE", AV23newCode);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV23newCode, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPRODUCTSSELECTED", AV5ProductsSelected);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPRODUCTSSELECTED", AV5ProductsSelected);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vPRODUCTSSELECTED", GetSecureSignedToken( "", AV5ProductsSelected, context));
      }

      protected void RF2J3( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            WholesalefgridContainer.ClearRows();
         }
         wbStart = 237;
         nGXsfl_237_idx = 1;
         sGXsfl_237_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_237_idx), 4, 0), 4, "0");
         SubsflControlProps_2373( ) ;
         bGXsfl_237_Refreshing = true;
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
            SubsflControlProps_2373( ) ;
            E162J3 ();
            wbEnd = 237;
            WB2J0( ) ;
         }
         bGXsfl_237_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2J3( )
      {
      }

      protected void RF2J4( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            RetailfgridContainer.ClearRows();
         }
         wbStart = 175;
         nGXsfl_175_idx = 1;
         sGXsfl_175_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_175_idx), 4, 0), 4, "0");
         SubsflControlProps_1754( ) ;
         bGXsfl_175_Refreshing = true;
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
            SubsflControlProps_1754( ) ;
            E152J4 ();
            wbEnd = 175;
            WB2J0( ) ;
         }
         bGXsfl_175_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2J4( )
      {
      }

      protected void RF2J5( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            CostpricefgridContainer.ClearRows();
         }
         wbStart = 111;
         nGXsfl_111_idx = 1;
         sGXsfl_111_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_111_idx), 4, 0), 4, "0");
         SubsflControlProps_1115( ) ;
         bGXsfl_111_Refreshing = true;
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
            SubsflControlProps_1115( ) ;
            E142J5 ();
            wbEnd = 111;
            WB2J0( ) ;
         }
         bGXsfl_111_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2J5( )
      {
      }

      protected void RF2J6( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 86;
         nGXsfl_86_idx = 1;
         sGXsfl_86_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_86_idx), 4, 0), 4, "0");
         SubsflControlProps_866( ) ;
         bGXsfl_86_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         Grid1Container.AddObjectProperty("Class", "FreeStyleGrid");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_866( ) ;
            E132J6 ();
            wbEnd = 86;
            WB2J0( ) ;
         }
         bGXsfl_86_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2J6( )
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
                                              A9SectorId } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
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
            gxgrAllproducts_refresh( subAllproducts_Rows, AV7Code, AV11Name, AV10Supplier, AV8Brand, AV9Sector, AV5ProductsSelected, AV22newName, AV23newCode) ;
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
            gxgrAllproducts_refresh( subAllproducts_Rows, AV7Code, AV11Name, AV10Supplier, AV8Brand, AV9Sector, AV5ProductsSelected, AV22newName, AV23newCode) ;
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
            gxgrAllproducts_refresh( subAllproducts_Rows, AV7Code, AV11Name, AV10Supplier, AV8Brand, AV9Sector, AV5ProductsSelected, AV22newName, AV23newCode) ;
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
            gxgrAllproducts_refresh( subAllproducts_Rows, AV7Code, AV11Name, AV10Supplier, AV8Brand, AV9Sector, AV5ProductsSelected, AV22newName, AV23newCode) ;
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
            gxgrAllproducts_refresh( subAllproducts_Rows, AV7Code, AV11Name, AV10Supplier, AV8Brand, AV9Sector, AV5ProductsSelected, AV22newName, AV23newCode) ;
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
         edtavCtlcode3_Enabled = 0;
         AssignProp("", false, edtavCtlcode3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcode3_Enabled), 5, 0), !bGXsfl_86_Refreshing);
         edtavCtlname3_Enabled = 0;
         AssignProp("", false, edtavCtlname3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname3_Enabled), 5, 0), !bGXsfl_86_Refreshing);
         edtavCtlcostprice3_Enabled = 0;
         AssignProp("", false, edtavCtlcostprice3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcostprice3_Enabled), 5, 0), !bGXsfl_86_Refreshing);
         edtavCtlretailprice2_Enabled = 0;
         AssignProp("", false, edtavCtlretailprice2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlretailprice2_Enabled), 5, 0), !bGXsfl_86_Refreshing);
         edtavCtlwholesaleprice2_Enabled = 0;
         AssignProp("", false, edtavCtlwholesaleprice2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlwholesaleprice2_Enabled), 5, 0), !bGXsfl_86_Refreshing);
         edtavCtlcode_Enabled = 0;
         AssignProp("", false, edtavCtlcode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcode_Enabled), 5, 0), !bGXsfl_111_Refreshing);
         edtavCtlname_Enabled = 0;
         AssignProp("", false, edtavCtlname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname_Enabled), 5, 0), !bGXsfl_111_Refreshing);
         edtavCtlsupplier_Enabled = 0;
         AssignProp("", false, edtavCtlsupplier_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsupplier_Enabled), 5, 0), !bGXsfl_111_Refreshing);
         edtavCtlbrand_Enabled = 0;
         AssignProp("", false, edtavCtlbrand_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlbrand_Enabled), 5, 0), !bGXsfl_111_Refreshing);
         edtavCtlsector_Enabled = 0;
         AssignProp("", false, edtavCtlsector_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsector_Enabled), 5, 0), !bGXsfl_111_Refreshing);
         edtavCtlcostprice_Enabled = 0;
         AssignProp("", false, edtavCtlcostprice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcostprice_Enabled), 5, 0), !bGXsfl_111_Refreshing);
         edtavCtlretailprice_Enabled = 0;
         AssignProp("", false, edtavCtlretailprice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlretailprice_Enabled), 5, 0), !bGXsfl_111_Refreshing);
         edtavCtlwholesaleprice_Enabled = 0;
         AssignProp("", false, edtavCtlwholesaleprice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlwholesaleprice_Enabled), 5, 0), !bGXsfl_111_Refreshing);
         edtavCtlcode1_Enabled = 0;
         AssignProp("", false, edtavCtlcode1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcode1_Enabled), 5, 0), !bGXsfl_175_Refreshing);
         edtavCtlname1_Enabled = 0;
         AssignProp("", false, edtavCtlname1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname1_Enabled), 5, 0), !bGXsfl_175_Refreshing);
         edtavCtlsupplier1_Enabled = 0;
         AssignProp("", false, edtavCtlsupplier1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsupplier1_Enabled), 5, 0), !bGXsfl_175_Refreshing);
         edtavCtlbrand1_Enabled = 0;
         AssignProp("", false, edtavCtlbrand1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlbrand1_Enabled), 5, 0), !bGXsfl_175_Refreshing);
         edtavCtlsector1_Enabled = 0;
         AssignProp("", false, edtavCtlsector1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsector1_Enabled), 5, 0), !bGXsfl_175_Refreshing);
         edtavCtlcostprice1_Enabled = 0;
         AssignProp("", false, edtavCtlcostprice1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcostprice1_Enabled), 5, 0), !bGXsfl_175_Refreshing);
         edtavCtlretailprofit1_Enabled = 0;
         AssignProp("", false, edtavCtlretailprofit1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlretailprofit1_Enabled), 5, 0), !bGXsfl_175_Refreshing);
         edtavCtlretailprice1_Enabled = 0;
         AssignProp("", false, edtavCtlretailprice1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlretailprice1_Enabled), 5, 0), !bGXsfl_175_Refreshing);
         edtavCtlcode2_Enabled = 0;
         AssignProp("", false, edtavCtlcode2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcode2_Enabled), 5, 0), !bGXsfl_237_Refreshing);
         edtavCtlname2_Enabled = 0;
         AssignProp("", false, edtavCtlname2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname2_Enabled), 5, 0), !bGXsfl_237_Refreshing);
         edtavCtlsupplier2_Enabled = 0;
         AssignProp("", false, edtavCtlsupplier2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsupplier2_Enabled), 5, 0), !bGXsfl_237_Refreshing);
         edtavCtlbrand2_Enabled = 0;
         AssignProp("", false, edtavCtlbrand2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlbrand2_Enabled), 5, 0), !bGXsfl_237_Refreshing);
         edtavCtlsector2_Enabled = 0;
         AssignProp("", false, edtavCtlsector2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsector2_Enabled), 5, 0), !bGXsfl_237_Refreshing);
         edtavCtlcostprice2_Enabled = 0;
         AssignProp("", false, edtavCtlcostprice2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcostprice2_Enabled), 5, 0), !bGXsfl_237_Refreshing);
         edtavCtlwholesaleprofit1_Enabled = 0;
         AssignProp("", false, edtavCtlwholesaleprofit1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlwholesaleprofit1_Enabled), 5, 0), !bGXsfl_237_Refreshing);
         edtavCtlwholesaleprice1_Enabled = 0;
         AssignProp("", false, edtavCtlwholesaleprice1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlwholesaleprice1_Enabled), 5, 0), !bGXsfl_237_Refreshing);
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
         E172J2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Costpriceproductsselected"), AV28CostPriceProductsSelected);
            ajax_req_read_hidden_sdt(cgiGet( "Productsselected"), AV5ProductsSelected);
            ajax_req_read_hidden_sdt(cgiGet( "vPRODUCTSSELECTED"), AV5ProductsSelected);
            /* Read saved values. */
            nRC_GXsfl_36 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_36"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_86 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_86"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_111 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_111"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_175 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_175"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_237 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_237"), ".", ","), 18, MidpointRounding.ToEven));
            AV24AllOk = StringUtil.StrToBool( cgiGet( "vALLOK"));
            ALLPRODUCTS_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "ALLPRODUCTS_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            ALLPRODUCTS_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "ALLPRODUCTS_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_86 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_86"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_86_fel_idx = 0;
            while ( nGXsfl_86_fel_idx < nRC_GXsfl_86 )
            {
               nGXsfl_86_fel_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_86_fel_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_86_fel_idx+1);
               sGXsfl_86_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_86_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_866( ) ;
               AV36GXV1 = nGXsfl_86_fel_idx;
               if ( ( AV28CostPriceProductsSelected.Count >= AV36GXV1 ) && ( AV36GXV1 > 0 ) )
               {
                  AV28CostPriceProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV28CostPriceProductsSelected.Item(AV36GXV1));
               }
            }
            if ( nGXsfl_86_fel_idx == 0 )
            {
               nGXsfl_86_idx = 1;
               sGXsfl_86_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_86_idx), 4, 0), 4, "0");
               SubsflControlProps_866( ) ;
            }
            nGXsfl_86_fel_idx = 1;
            nRC_GXsfl_111 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_111"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_111_fel_idx = 0;
            while ( nGXsfl_111_fel_idx < nRC_GXsfl_111 )
            {
               nGXsfl_111_fel_idx = ((subCostpricefgrid_Islastpage==1)&&(nGXsfl_111_fel_idx+1>subCostpricefgrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_111_fel_idx+1);
               sGXsfl_111_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_111_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_1115( ) ;
               AV43GXV8 = nGXsfl_111_fel_idx;
               if ( ( AV5ProductsSelected.Count >= AV43GXV8 ) && ( AV43GXV8 > 0 ) )
               {
                  AV5ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV43GXV8));
               }
            }
            if ( nGXsfl_111_fel_idx == 0 )
            {
               nGXsfl_111_idx = 1;
               sGXsfl_111_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_111_idx), 4, 0), 4, "0");
               SubsflControlProps_1115( ) ;
            }
            nGXsfl_111_fel_idx = 1;
            nRC_GXsfl_175 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_175"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_175_fel_idx = 0;
            while ( nGXsfl_175_fel_idx < nRC_GXsfl_175 )
            {
               nGXsfl_175_fel_idx = ((subRetailfgrid_Islastpage==1)&&(nGXsfl_175_fel_idx+1>subRetailfgrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_175_fel_idx+1);
               sGXsfl_175_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_175_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_1754( ) ;
               AV53GXV18 = nGXsfl_175_fel_idx;
               if ( ( AV5ProductsSelected.Count >= AV53GXV18 ) && ( AV53GXV18 > 0 ) )
               {
                  AV5ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV53GXV18));
               }
            }
            if ( nGXsfl_175_fel_idx == 0 )
            {
               nGXsfl_175_idx = 1;
               sGXsfl_175_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_175_idx), 4, 0), 4, "0");
               SubsflControlProps_1754( ) ;
            }
            nGXsfl_175_fel_idx = 1;
            nRC_GXsfl_237 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_237"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_237_fel_idx = 0;
            while ( nGXsfl_237_fel_idx < nRC_GXsfl_237 )
            {
               nGXsfl_237_fel_idx = ((subWholesalefgrid_Islastpage==1)&&(nGXsfl_237_fel_idx+1>subWholesalefgrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_237_fel_idx+1);
               sGXsfl_237_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_237_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_2373( ) ;
               AV63GXV28 = nGXsfl_237_fel_idx;
               if ( ( AV5ProductsSelected.Count >= AV63GXV28 ) && ( AV63GXV28 > 0 ) )
               {
                  AV5ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV63GXV28));
               }
            }
            if ( nGXsfl_237_fel_idx == 0 )
            {
               nGXsfl_237_idx = 1;
               sGXsfl_237_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_237_idx), 4, 0), 4, "0");
               SubsflControlProps_2373( ) ;
            }
            nGXsfl_237_fel_idx = 1;
            /* Read variables values. */
            cmbavUpdatetype.Name = cmbavUpdatetype_Internalname;
            cmbavUpdatetype.CurrentValue = cgiGet( cmbavUpdatetype_Internalname);
            AV12UpdateType = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavUpdatetype_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV12UpdateType", StringUtil.Str( (decimal)(AV12UpdateType), 1, 0));
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCostpricepercentage_Internalname), ".", ",") < -99.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavCostpricepercentage_Internalname), ".", ",") > 999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCOSTPRICEPERCENTAGE");
               GX_FocusControl = edtavCostpricepercentage_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV13CostPricePercentage = 0;
               AssignAttri("", false, "AV13CostPricePercentage", StringUtil.LTrimStr( AV13CostPricePercentage, 6, 2));
            }
            else
            {
               AV13CostPricePercentage = context.localUtil.CToN( cgiGet( edtavCostpricepercentage_Internalname), ".", ",");
               AssignAttri("", false, "AV13CostPricePercentage", StringUtil.LTrimStr( AV13CostPricePercentage, 6, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavRppercentage_Internalname), ".", ",") < -99.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavRppercentage_Internalname), ".", ",") > 999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vRPPERCENTAGE");
               GX_FocusControl = edtavRppercentage_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV14RPPercentage = 0;
               AssignAttri("", false, "AV14RPPercentage", StringUtil.LTrimStr( AV14RPPercentage, 6, 2));
            }
            else
            {
               AV14RPPercentage = context.localUtil.CToN( cgiGet( edtavRppercentage_Internalname), ".", ",");
               AssignAttri("", false, "AV14RPPercentage", StringUtil.LTrimStr( AV14RPPercentage, 6, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavWppercentage_Internalname), ".", ",") < -99.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavWppercentage_Internalname), ".", ",") > 999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vWPPERCENTAGE");
               GX_FocusControl = edtavWppercentage_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV15WPPercentage = 0;
               AssignAttri("", false, "AV15WPPercentage", StringUtil.LTrimStr( AV15WPPercentage, 6, 2));
            }
            else
            {
               AV15WPPercentage = context.localUtil.CToN( cgiGet( edtavWppercentage_Internalname), ".", ",");
               AssignAttri("", false, "AV15WPPercentage", StringUtil.LTrimStr( AV15WPPercentage, 6, 2));
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
         E172J2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E172J2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'COSTPRICEPREPARETOUPDATE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E182J2( )
      {
         AV36GXV1 = nGXsfl_86_idx;
         if ( ( AV36GXV1 > 0 ) && ( AV28CostPriceProductsSelected.Count >= AV36GXV1 ) )
         {
            AV28CostPriceProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV28CostPriceProductsSelected.Item(AV36GXV1));
         }
         /* ProductName_Click Routine */
         returnInSub = false;
         AV33IdSelected = A15ProductId;
         AssignAttri("", false, "AV33IdSelected", StringUtil.LTrimStr( (decimal)(AV33IdSelected), 6, 0));
         /* Execute user subroutine: 'IDINSELECTED' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( ! AV32IsIn )
         {
            AV6OneProduct = new SdtSDTProductsSelected_SDTProductsSelectedItem(context);
            GXt_SdtSDTProductsSelected_SDTProductsSelectedItem1 = AV6OneProduct;
            new updateloadoneproduct(context ).execute(  A15ProductId, out  GXt_SdtSDTProductsSelected_SDTProductsSelectedItem1) ;
            AV6OneProduct = GXt_SdtSDTProductsSelected_SDTProductsSelectedItem1;
            if ( AV12UpdateType == 0 )
            {
               /* Execute user subroutine: 'COSTPRICECALCULATEONE' */
               S132 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
            }
            else if ( AV12UpdateType == 1 )
            {
               /* Execute user subroutine: 'RETAILPROFITCALCULATEONE' */
               S142 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
            }
            else if ( AV12UpdateType == 2 )
            {
               /* Execute user subroutine: 'WHOLESALEPROFITCALCULATEONE' */
               S152 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
            }
            else
            {
               /* Execute user subroutine: 'COSTPRICECALCULATEONE' */
               S132 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
            }
            AV17Value = (decimal)(A85ProductCostPrice*(1+AV13CostPricePercentage/ (decimal)(100)));
            AssignAttri("", false, "AV17Value", StringUtil.LTrimStr( AV17Value, 10, 2));
            /* Execute user subroutine: 'ROUNDVALUE' */
            S162 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            AV6OneProduct.gxTpr_Newcostprice = AV17Value;
            AV28CostPriceProductsSelected.Add(AV6OneProduct, 0);
            gx_BV86 = true;
            AV29CostPriceIdsSelected.Add(AV6OneProduct.gxTpr_Id, 0);
            gxgrCostpricefgrid_refresh( subAllproducts_Rows, AV7Code, AV11Name, AV10Supplier, AV8Brand, AV9Sector, AV5ProductsSelected, AV22newName, AV23newCode) ;
            gxgrRetailfgrid_refresh( subAllproducts_Rows, AV7Code, AV11Name, AV10Supplier, AV8Brand, AV9Sector, AV5ProductsSelected, AV22newName, AV23newCode) ;
            gxgrWholesalefgrid_refresh( subAllproducts_Rows, AV7Code, AV11Name, AV10Supplier, AV8Brand, AV9Sector, AV5ProductsSelected, AV22newName, AV23newCode) ;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6OneProduct", AV6OneProduct);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28CostPriceProductsSelected", AV28CostPriceProductsSelected);
         nGXsfl_86_bak_idx = nGXsfl_86_idx;
         gxgrGrid1_refresh( subAllproducts_Rows, AV7Code, AV11Name, AV10Supplier, AV8Brand, AV9Sector, AV5ProductsSelected, AV22newName, AV23newCode) ;
         nGXsfl_86_idx = nGXsfl_86_bak_idx;
         sGXsfl_86_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_86_idx), 4, 0), 4, "0");
         SubsflControlProps_866( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV29CostPriceIdsSelected", AV29CostPriceIdsSelected);
      }

      protected void S162( )
      {
         /* 'ROUNDVALUE' Routine */
         returnInSub = false;
         AV18PriceRounded = AV17Value;
         AV25Count = 1;
         AV26Digit = (short)(((int)((AV18PriceRounded) % (10))));
         AV18PriceRounded = (decimal)(NumberUtil.Int( (long)(Math.Round(AV18PriceRounded/ (decimal)(10), 18, MidpointRounding.ToEven))));
         while ( ( AV18PriceRounded >= Convert.ToDecimal( 100 )) )
         {
            AV26Digit = (short)(((int)((AV18PriceRounded) % (10))));
            AV18PriceRounded = (decimal)(NumberUtil.Int( (long)(Math.Round(AV18PriceRounded/ (decimal)(10), 18, MidpointRounding.ToEven))));
            AV25Count = (short)(AV25Count+1);
         }
         if ( AV26Digit * 10 > 0 )
         {
            AV18PriceRounded = (decimal)(AV18PriceRounded+1);
         }
         AV27I = 1;
         while ( AV27I <= AV25Count )
         {
            AV18PriceRounded = (decimal)(AV18PriceRounded*10);
            AV27I = (short)(AV27I+1);
         }
         AV17Value = AV18PriceRounded;
         AssignAttri("", false, "AV17Value", StringUtil.LTrimStr( AV17Value, 10, 2));
      }

      protected void S112( )
      {
         /* 'COSTPRICEPREPARETOUPDATE' Routine */
         returnInSub = false;
         divCostpricetable_Visible = 1;
         AssignProp("", false, divCostpricetable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCostpricetable_Visible), 5, 0), true);
         divRetaiprofitltable_Visible = 0;
         AssignProp("", false, divRetaiprofitltable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divRetaiprofitltable_Visible), 5, 0), true);
         divWholesaleprofittable_Visible = 0;
         AssignProp("", false, divWholesaleprofittable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divWholesaleprofittable_Visible), 5, 0), true);
      }

      protected void S172( )
      {
         /* 'RETAILPROFITPREPARETOUPDATE' Routine */
         returnInSub = false;
         divCostpricetable_Visible = 0;
         AssignProp("", false, divCostpricetable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCostpricetable_Visible), 5, 0), true);
         divRetaiprofitltable_Visible = 1;
         AssignProp("", false, divRetaiprofitltable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divRetaiprofitltable_Visible), 5, 0), true);
         divWholesaleprofittable_Visible = 0;
         AssignProp("", false, divWholesaleprofittable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divWholesaleprofittable_Visible), 5, 0), true);
      }

      protected void S182( )
      {
         /* 'WHOLESALEPROFITPREPARETOUPDATE' Routine */
         returnInSub = false;
         divCostpricetable_Visible = 0;
         AssignProp("", false, divCostpricetable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divCostpricetable_Visible), 5, 0), true);
         divRetaiprofitltable_Visible = 0;
         AssignProp("", false, divRetaiprofitltable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divRetaiprofitltable_Visible), 5, 0), true);
         divWholesaleprofittable_Visible = 1;
         AssignProp("", false, divWholesaleprofittable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divWholesaleprofittable_Visible), 5, 0), true);
      }

      protected void S192( )
      {
         /* 'COSTPRICEUPDATE' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'COSTPRICECONTROL' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S202( )
      {
         /* 'RETAILPROFITUPDATE' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'RETAILPROFITCONTROL' */
         S232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S212( )
      {
         /* 'WHOLESALEPROFITUPDATE' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'WHOLESALEPROFITCONTROL' */
         S242 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S222( )
      {
         /* 'COSTPRICECONTROL' Routine */
         returnInSub = false;
         AV24AllOk = true;
      }

      protected void S232( )
      {
         /* 'RETAILPROFITCONTROL' Routine */
         returnInSub = false;
         AV24AllOk = true;
      }

      protected void S242( )
      {
         /* 'WHOLESALEPROFITCONTROL' Routine */
         returnInSub = false;
         AV24AllOk = true;
      }

      protected void S132( )
      {
         /* 'COSTPRICECALCULATEONE' Routine */
         returnInSub = false;
         AV17Value = (decimal)(AV6OneProduct.gxTpr_Costprice*(1+AV13CostPricePercentage/ (decimal)(100)));
         AssignAttri("", false, "AV17Value", StringUtil.LTrimStr( AV17Value, 10, 2));
         /* Execute user subroutine: 'ROUNDVALUE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV6OneProduct.gxTpr_Newcostprice = AV17Value;
         AV17Value = (decimal)(AV6OneProduct.gxTpr_Costprice*(1+AV6OneProduct.gxTpr_Retailprofit/ (decimal)(100)));
         AssignAttri("", false, "AV17Value", StringUtil.LTrimStr( AV17Value, 10, 2));
         /* Execute user subroutine: 'ROUNDVALUE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV6OneProduct.gxTpr_Retailprice = AV17Value;
         AV17Value = (decimal)(AV6OneProduct.gxTpr_Costprice*(1+AV6OneProduct.gxTpr_Wholesaleprofit/ (decimal)(100)));
         AssignAttri("", false, "AV17Value", StringUtil.LTrimStr( AV17Value, 10, 2));
         /* Execute user subroutine: 'ROUNDVALUE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV6OneProduct.gxTpr_Wholesaleprice = AV17Value;
      }

      protected void S142( )
      {
         /* 'RETAILPROFITCALCULATEONE' Routine */
         returnInSub = false;
         AV6OneProduct.gxTpr_Newretailprofit = AV14RPPercentage;
         AV17Value = (decimal)(AV6OneProduct.gxTpr_Costprice*(1+AV6OneProduct.gxTpr_Newretailprofit/ (decimal)(100)));
         AssignAttri("", false, "AV17Value", StringUtil.LTrimStr( AV17Value, 10, 2));
         /* Execute user subroutine: 'ROUNDVALUE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV6OneProduct.gxTpr_Retailprice = AV17Value;
      }

      protected void S152( )
      {
         /* 'WHOLESALEPROFITCALCULATEONE' Routine */
         returnInSub = false;
         AV6OneProduct.gxTpr_Newwholesaleprofit = AV15WPPercentage;
         AV17Value = (decimal)(AV6OneProduct.gxTpr_Costprice*(1+AV6OneProduct.gxTpr_Newwholesaleprofit/ (decimal)(100)));
         AssignAttri("", false, "AV17Value", StringUtil.LTrimStr( AV17Value, 10, 2));
         /* Execute user subroutine: 'ROUNDVALUE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV6OneProduct.gxTpr_Wholesaleprice = AV17Value;
      }

      protected void S122( )
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

      protected void E122J2( )
      {
         AV36GXV1 = nGXsfl_86_idx;
         if ( ( AV36GXV1 > 0 ) && ( AV28CostPriceProductsSelected.Count >= AV36GXV1 ) )
         {
            AV28CostPriceProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV28CostPriceProductsSelected.Item(AV36GXV1));
         }
         /* 'CostPriceBtnRemove' Routine */
         returnInSub = false;
         GX_msglist.addItem("Remove element by id: "+((SdtSDTProductsSelected_SDTProductsSelectedItem)(AV28CostPriceProductsSelected.CurrentItem)).gxTpr_Id);
         AV30Position = (short)(AV29CostPriceIdsSelected.IndexOf(((SdtSDTProductsSelected_SDTProductsSelectedItem)(AV28CostPriceProductsSelected.CurrentItem)).gxTpr_Id));
         AV28CostPriceProductsSelected.RemoveItem(AV30Position);
         gx_BV86 = true;
         AV29CostPriceIdsSelected.RemoveItem(AV30Position);
         gxgrCostpricefgrid_refresh( subAllproducts_Rows, AV7Code, AV11Name, AV10Supplier, AV8Brand, AV9Sector, AV5ProductsSelected, AV22newName, AV23newCode) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28CostPriceProductsSelected", AV28CostPriceProductsSelected);
         nGXsfl_86_bak_idx = nGXsfl_86_idx;
         gxgrGrid1_refresh( subAllproducts_Rows, AV7Code, AV11Name, AV10Supplier, AV8Brand, AV9Sector, AV5ProductsSelected, AV22newName, AV23newCode) ;
         nGXsfl_86_idx = nGXsfl_86_bak_idx;
         sGXsfl_86_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_86_idx), 4, 0), 4, "0");
         SubsflControlProps_866( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV29CostPriceIdsSelected", AV29CostPriceIdsSelected);
      }

      private void E192J2( )
      {
         /* Allproducts_Load Routine */
         returnInSub = false;
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 36;
         }
         sendrow_362( ) ;
         ALLPRODUCTS_nCurrentRecord = (long)(ALLPRODUCTS_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_36_Refreshing )
         {
            DoAjaxLoad(36, AllproductsRow);
         }
      }

      private void E162J3( )
      {
         /* Wholesalefgrid_Load Routine */
         returnInSub = false;
         AV63GXV28 = 1;
         while ( AV63GXV28 <= AV5ProductsSelected.Count )
         {
            AV5ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV63GXV28));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 237;
            }
            sendrow_2373( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_237_Refreshing )
            {
               DoAjaxLoad(237, WholesalefgridRow);
            }
            AV63GXV28 = (int)(AV63GXV28+1);
         }
      }

      private void E152J4( )
      {
         /* Retailfgrid_Load Routine */
         returnInSub = false;
         AV53GXV18 = 1;
         while ( AV53GXV18 <= AV5ProductsSelected.Count )
         {
            AV5ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV53GXV18));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 175;
            }
            sendrow_1754( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_175_Refreshing )
            {
               DoAjaxLoad(175, RetailfgridRow);
            }
            AV53GXV18 = (int)(AV53GXV18+1);
         }
      }

      private void E142J5( )
      {
         /* Costpricefgrid_Load Routine */
         returnInSub = false;
         AV43GXV8 = 1;
         while ( AV43GXV8 <= AV5ProductsSelected.Count )
         {
            AV5ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV43GXV8));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 111;
            }
            sendrow_1115( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_111_Refreshing )
            {
               DoAjaxLoad(111, CostpricefgridRow);
            }
            AV43GXV8 = (int)(AV43GXV8+1);
         }
      }

      private void E132J6( )
      {
         /* Grid1_Load Routine */
         returnInSub = false;
         AV36GXV1 = 1;
         while ( AV36GXV1 <= AV28CostPriceProductsSelected.Count )
         {
            AV28CostPriceProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV28CostPriceProductsSelected.Item(AV36GXV1));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 86;
            }
            sendrow_866( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_86_Refreshing )
            {
               DoAjaxLoad(86, Grid1Row);
            }
            AV36GXV1 = (int)(AV36GXV1+1);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20242623184868", true, true);
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
         context.AddJavascriptSource("wpupdatepriceandprofit.js", "?20242623184868", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_362( )
      {
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_36_idx;
         edtProductCode_Internalname = "PRODUCTCODE_"+sGXsfl_36_idx;
         edtProductName_Internalname = "PRODUCTNAME_"+sGXsfl_36_idx;
         edtSupplierName_Internalname = "SUPPLIERNAME_"+sGXsfl_36_idx;
         edtBrandName_Internalname = "BRANDNAME_"+sGXsfl_36_idx;
         edtSectorName_Internalname = "SECTORNAME_"+sGXsfl_36_idx;
         edtProductCostPrice_Internalname = "PRODUCTCOSTPRICE_"+sGXsfl_36_idx;
         edtProductRetailProfit_Internalname = "PRODUCTRETAILPROFIT_"+sGXsfl_36_idx;
         edtProductRetailPrice_Internalname = "PRODUCTRETAILPRICE_"+sGXsfl_36_idx;
         edtProductWholesaleProfit_Internalname = "PRODUCTWHOLESALEPROFIT_"+sGXsfl_36_idx;
         edtProductWholesalePrice_Internalname = "PRODUCTWHOLESALEPRICE_"+sGXsfl_36_idx;
      }

      protected void SubsflControlProps_fel_362( )
      {
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_36_fel_idx;
         edtProductCode_Internalname = "PRODUCTCODE_"+sGXsfl_36_fel_idx;
         edtProductName_Internalname = "PRODUCTNAME_"+sGXsfl_36_fel_idx;
         edtSupplierName_Internalname = "SUPPLIERNAME_"+sGXsfl_36_fel_idx;
         edtBrandName_Internalname = "BRANDNAME_"+sGXsfl_36_fel_idx;
         edtSectorName_Internalname = "SECTORNAME_"+sGXsfl_36_fel_idx;
         edtProductCostPrice_Internalname = "PRODUCTCOSTPRICE_"+sGXsfl_36_fel_idx;
         edtProductRetailProfit_Internalname = "PRODUCTRETAILPROFIT_"+sGXsfl_36_fel_idx;
         edtProductRetailPrice_Internalname = "PRODUCTRETAILPRICE_"+sGXsfl_36_fel_idx;
         edtProductWholesaleProfit_Internalname = "PRODUCTWHOLESALEPROFIT_"+sGXsfl_36_fel_idx;
         edtProductWholesalePrice_Internalname = "PRODUCTWHOLESALEPRICE_"+sGXsfl_36_fel_idx;
      }

      protected void sendrow_362( )
      {
         SubsflControlProps_362( ) ;
         WB2J0( ) ;
         if ( ( 5 * 1 == 0 ) || ( nGXsfl_36_idx <= subAllproducts_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_36_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_36_idx+"\">") ;
            }
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A15ProductId), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)36,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductCode_Internalname,(string)A55ProductCode,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductCode_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)36,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusUnanimo\\Code",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductName_Internalname,(string)A16ProductName,(string)"",(string)"","'"+""+"'"+",false,"+"'"+"EPRODUCTNAME.CLICK."+sGXsfl_36_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductName_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)36,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierName_Internalname,(string)A5SupplierName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)36,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtBrandName_Internalname,(string)A2BrandName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtBrandName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)36,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSectorName_Internalname,(string)A10SectorName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSectorName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)36,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductCostPrice_Internalname,StringUtil.LTrim( StringUtil.NToC( A85ProductCostPrice, 10, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A85ProductCostPrice, "ZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductCostPrice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)36,(short)0,(short)-1,(short)0,(bool)true,(string)"Price",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductRetailProfit_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A89ProductRetailProfit), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A89ProductRetailProfit), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductRetailProfit_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)36,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductRetailPrice_Internalname,StringUtil.LTrim( StringUtil.NToC( A90ProductRetailPrice, 10, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A90ProductRetailPrice, "ZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductRetailPrice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)36,(short)0,(short)-1,(short)0,(bool)true,(string)"Price",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductWholesaleProfit_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A87ProductWholesaleProfit), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A87ProductWholesaleProfit), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductWholesaleProfit_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)36,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductWholesalePrice_Internalname,StringUtil.LTrim( StringUtil.NToC( A88ProductWholesalePrice, 10, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A88ProductWholesalePrice, "ZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductWholesalePrice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)36,(short)0,(short)-1,(short)0,(bool)true,(string)"Price",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes2J2( ) ;
            AllproductsContainer.AddRow(AllproductsRow);
            nGXsfl_36_idx = ((subAllproducts_Islastpage==1)&&(nGXsfl_36_idx+1>subAllproducts_fnc_Recordsperpage( )) ? 1 : nGXsfl_36_idx+1);
            sGXsfl_36_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_36_idx), 4, 0), 4, "0");
            SubsflControlProps_362( ) ;
         }
         /* End function sendrow_362 */
      }

      protected void SubsflControlProps_866( )
      {
         edtavCtlcode3_Internalname = "CTLCODE3_"+sGXsfl_86_idx;
         edtavCtlname3_Internalname = "CTLNAME3_"+sGXsfl_86_idx;
         edtavCtlcostprice3_Internalname = "CTLCOSTPRICE3_"+sGXsfl_86_idx;
         edtavCtlnewcostprice1_Internalname = "CTLNEWCOSTPRICE1_"+sGXsfl_86_idx;
         edtavCtlretailprice2_Internalname = "CTLRETAILPRICE2_"+sGXsfl_86_idx;
         edtavCtlwholesaleprice2_Internalname = "CTLWHOLESALEPRICE2_"+sGXsfl_86_idx;
      }

      protected void SubsflControlProps_fel_866( )
      {
         edtavCtlcode3_Internalname = "CTLCODE3_"+sGXsfl_86_fel_idx;
         edtavCtlname3_Internalname = "CTLNAME3_"+sGXsfl_86_fel_idx;
         edtavCtlcostprice3_Internalname = "CTLCOSTPRICE3_"+sGXsfl_86_fel_idx;
         edtavCtlnewcostprice1_Internalname = "CTLNEWCOSTPRICE1_"+sGXsfl_86_fel_idx;
         edtavCtlretailprice2_Internalname = "CTLRETAILPRICE2_"+sGXsfl_86_fel_idx;
         edtavCtlwholesaleprice2_Internalname = "CTLWHOLESALEPRICE2_"+sGXsfl_86_fel_idx;
      }

      protected void sendrow_866( )
      {
         SubsflControlProps_866( ) ;
         WB2J0( ) ;
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
            subGrid1_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subGrid1_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGrid1_Backstyle = 1;
            if ( ((int)((nGXsfl_86_idx) % (2))) == 0 )
            {
               subGrid1_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Even";
               }
            }
            else
            {
               subGrid1_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subGrid1_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_86_idx+"\">") ;
         }
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divGrid1table2_Internalname+"_"+sGXsfl_86_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Grid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcode3_Internalname,(string)"Code",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcode3_Internalname,((SdtSDTProductsSelected_SDTProductsSelectedItem)AV28CostPriceProductsSelected.Item(AV36GXV1)).gxTpr_Code,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcode3_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlcode3_Enabled,(short)0,(string)"text",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)100,(short)0,(short)0,(short)86,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Grid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname3_Internalname,(string)"Name",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname3_Internalname,((SdtSDTProductsSelected_SDTProductsSelectedItem)AV28CostPriceProductsSelected.Item(AV36GXV1)).gxTpr_Name,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlname3_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlname3_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)86,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Grid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcostprice3_Internalname,(string)"Cost Price",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcostprice3_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV28CostPriceProductsSelected.Item(AV36GXV1)).gxTpr_Costprice, 10, 2, ".", "")),StringUtil.LTrim( ((edtavCtlcostprice3_Enabled!=0) ? context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV28CostPriceProductsSelected.Item(AV36GXV1)).gxTpr_Costprice, "ZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV28CostPriceProductsSelected.Item(AV36GXV1)).gxTpr_Costprice, "ZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcostprice3_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlcostprice3_Enabled,(short)0,(string)"text",(string)"",(short)10,(string)"chr",(short)1,(string)"row",(short)10,(short)0,(short)0,(short)86,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Grid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlnewcostprice1_Internalname,(string)"New Cost Price",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         TempTags = " " + ((edtavCtlnewcostprice1_Enabled!=0)&&(edtavCtlnewcostprice1_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 100,'',false,'"+sGXsfl_86_idx+"',86)\"" : " ");
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlnewcostprice1_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV28CostPriceProductsSelected.Item(AV36GXV1)).gxTpr_Newcostprice, 10, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV28CostPriceProductsSelected.Item(AV36GXV1)).gxTpr_Newcostprice, "ZZZZZZ9.99")),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+((edtavCtlnewcostprice1_Enabled!=0)&&(edtavCtlnewcostprice1_Visible!=0) ? " onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,100);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlnewcostprice1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)1,(short)0,(string)"text",(string)"",(short)10,(string)"chr",(short)1,(string)"row",(short)10,(short)0,(short)0,(short)86,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Grid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlretailprice2_Internalname,(string)"Retail Price",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlretailprice2_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV28CostPriceProductsSelected.Item(AV36GXV1)).gxTpr_Retailprice, 10, 2, ".", "")),StringUtil.LTrim( ((edtavCtlretailprice2_Enabled!=0) ? context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV28CostPriceProductsSelected.Item(AV36GXV1)).gxTpr_Retailprice, "ZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV28CostPriceProductsSelected.Item(AV36GXV1)).gxTpr_Retailprice, "ZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlretailprice2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlretailprice2_Enabled,(short)0,(string)"text",(string)"",(short)10,(string)"chr",(short)1,(string)"row",(short)10,(short)0,(short)0,(short)86,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Grid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlwholesaleprice2_Internalname,(string)"Wholesale Price",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlwholesaleprice2_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV28CostPriceProductsSelected.Item(AV36GXV1)).gxTpr_Wholesaleprice, 10, 2, ".", "")),StringUtil.LTrim( ((edtavCtlwholesaleprice2_Enabled!=0) ? context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV28CostPriceProductsSelected.Item(AV36GXV1)).gxTpr_Wholesaleprice, "ZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV28CostPriceProductsSelected.Item(AV36GXV1)).gxTpr_Wholesaleprice, "ZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlwholesaleprice2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlwholesaleprice2_Enabled,(short)0,(string)"text",(string)"",(short)10,(string)"chr",(short)1,(string)"row",(short)10,(short)0,(short)0,(short)86,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         Grid1Row.AddColumnProperties("button", 2, isAjaxCallMode( ), new Object[] {(string)bttCostpricebtnremove_Internalname+"_"+sGXsfl_86_idx,"gx.evt.setGridEvt("+StringUtil.Str( (decimal)(86), 2, 0)+","+"null"+");",(string)"Remove",(string)bttCostpricebtnremove_Jsonclick,(short)5,(string)"Remove",(string)"",(string)StyleString,(string)ClassString,(short)1,(short)1,(string)"standard","'"+""+"'"+",false,"+"'"+"E\\'COSTPRICEBTNREMOVE\\'."+"'",(string)TempTags,(string)"",context.GetButtonType( )});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         send_integrity_lvl_hashes2J6( ) ;
         /* End of Columns property logic. */
         Grid1Container.AddRow(Grid1Row);
         nGXsfl_86_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_86_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_86_idx+1);
         sGXsfl_86_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_86_idx), 4, 0), 4, "0");
         SubsflControlProps_866( ) ;
         /* End function sendrow_866 */
      }

      protected void SubsflControlProps_1115( )
      {
         edtavCtlcode_Internalname = "CTLCODE_"+sGXsfl_111_idx;
         edtavCtlname_Internalname = "CTLNAME_"+sGXsfl_111_idx;
         edtavCtlsupplier_Internalname = "CTLSUPPLIER_"+sGXsfl_111_idx;
         edtavCtlbrand_Internalname = "CTLBRAND_"+sGXsfl_111_idx;
         edtavCtlsector_Internalname = "CTLSECTOR_"+sGXsfl_111_idx;
         edtavCtlcostprice_Internalname = "CTLCOSTPRICE_"+sGXsfl_111_idx;
         edtavCtlnewcostprice_Internalname = "CTLNEWCOSTPRICE_"+sGXsfl_111_idx;
         edtavCtlretailprice_Internalname = "CTLRETAILPRICE_"+sGXsfl_111_idx;
         edtavCtlwholesaleprice_Internalname = "CTLWHOLESALEPRICE_"+sGXsfl_111_idx;
      }

      protected void SubsflControlProps_fel_1115( )
      {
         edtavCtlcode_Internalname = "CTLCODE_"+sGXsfl_111_fel_idx;
         edtavCtlname_Internalname = "CTLNAME_"+sGXsfl_111_fel_idx;
         edtavCtlsupplier_Internalname = "CTLSUPPLIER_"+sGXsfl_111_fel_idx;
         edtavCtlbrand_Internalname = "CTLBRAND_"+sGXsfl_111_fel_idx;
         edtavCtlsector_Internalname = "CTLSECTOR_"+sGXsfl_111_fel_idx;
         edtavCtlcostprice_Internalname = "CTLCOSTPRICE_"+sGXsfl_111_fel_idx;
         edtavCtlnewcostprice_Internalname = "CTLNEWCOSTPRICE_"+sGXsfl_111_fel_idx;
         edtavCtlretailprice_Internalname = "CTLRETAILPRICE_"+sGXsfl_111_fel_idx;
         edtavCtlwholesaleprice_Internalname = "CTLWHOLESALEPRICE_"+sGXsfl_111_fel_idx;
      }

      protected void sendrow_1115( )
      {
         SubsflControlProps_1115( ) ;
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
            if ( ((int)((nGXsfl_111_idx) % (2))) == 0 )
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
            context.WriteHtmlText( "<tr"+" class=\""+subCostpricefgrid_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_111_idx+"\">") ;
         }
         /* Div Control */
         CostpricefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divGrid1table_Internalname+"_"+sGXsfl_111_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         CostpricefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         CostpricefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         CostpricefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         CostpricefgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcode_Internalname,(string)"Code",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         CostpricefgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcode_Internalname,((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV43GXV8)).gxTpr_Code,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcode_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlcode_Enabled,(short)0,(string)"text",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)100,(short)0,(short)0,(short)111,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         CostpricefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CostpricefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         CostpricefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         CostpricefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         CostpricefgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname_Internalname,(string)"Name",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         CostpricefgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname_Internalname,((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV43GXV8)).gxTpr_Name,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlname_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)111,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         CostpricefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CostpricefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         CostpricefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         CostpricefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         CostpricefgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsupplier_Internalname,(string)"Supplier",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         CostpricefgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsupplier_Internalname,((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV43GXV8)).gxTpr_Supplier,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlsupplier_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlsupplier_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)111,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         CostpricefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CostpricefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         CostpricefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         CostpricefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         CostpricefgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlbrand_Internalname,(string)"Brand",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         CostpricefgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlbrand_Internalname,((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV43GXV8)).gxTpr_Brand,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlbrand_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlbrand_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)111,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         CostpricefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CostpricefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         CostpricefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         CostpricefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         CostpricefgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsector_Internalname,(string)"Sector",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         CostpricefgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsector_Internalname,((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV43GXV8)).gxTpr_Sector,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlsector_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlsector_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)111,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         CostpricefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CostpricefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         CostpricefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"Right",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         CostpricefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         CostpricefgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcostprice_Internalname,"Unit C. Price",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         CostpricefgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcostprice_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV43GXV8)).gxTpr_Costprice, 10, 2, ".", "")),StringUtil.LTrim( ((edtavCtlcostprice_Enabled!=0) ? context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV43GXV8)).gxTpr_Costprice, "ZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV43GXV8)).gxTpr_Costprice, "ZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcostprice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlcostprice_Enabled,(short)0,(string)"text",(string)"",(short)10,(string)"chr",(short)1,(string)"row",(short)10,(short)0,(short)0,(short)111,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         CostpricefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CostpricefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"Right",(string)"top",(string)"div"});
         /* Div Control */
         CostpricefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"Right",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         CostpricefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         CostpricefgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlnewcostprice_Internalname,"New C. Price",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         TempTags = " " + ((edtavCtlnewcostprice_Enabled!=0)&&(edtavCtlnewcostprice_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 134,'',false,'"+sGXsfl_111_idx+"',111)\"" : " ");
         ROClassString = "Attribute";
         CostpricefgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlnewcostprice_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV43GXV8)).gxTpr_Newcostprice, 10, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV43GXV8)).gxTpr_Newcostprice, "ZZZZZZ9.99")),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+((edtavCtlnewcostprice_Enabled!=0)&&(edtavCtlnewcostprice_Visible!=0) ? " onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,134);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlnewcostprice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)1,(short)0,(string)"text",(string)"",(short)10,(string)"chr",(short)1,(string)"row",(short)10,(short)0,(short)0,(short)111,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         CostpricefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CostpricefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"Right",(string)"top",(string)"div"});
         /* Div Control */
         CostpricefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"Right",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         CostpricefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         CostpricefgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlretailprice_Internalname,"R. Price",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         CostpricefgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlretailprice_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV43GXV8)).gxTpr_Retailprice, 10, 2, ".", "")),StringUtil.LTrim( ((edtavCtlretailprice_Enabled!=0) ? context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV43GXV8)).gxTpr_Retailprice, "ZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV43GXV8)).gxTpr_Retailprice, "ZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlretailprice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlretailprice_Enabled,(short)0,(string)"text",(string)"",(short)10,(string)"chr",(short)1,(string)"row",(short)10,(short)0,(short)0,(short)111,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         CostpricefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CostpricefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"Right",(string)"top",(string)"div"});
         /* Div Control */
         CostpricefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"Right",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         CostpricefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         CostpricefgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlwholesaleprice_Internalname,"W. Price",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         CostpricefgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlwholesaleprice_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV43GXV8)).gxTpr_Wholesaleprice, 10, 2, ".", "")),StringUtil.LTrim( ((edtavCtlwholesaleprice_Enabled!=0) ? context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV43GXV8)).gxTpr_Wholesaleprice, "ZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV43GXV8)).gxTpr_Wholesaleprice, "ZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlwholesaleprice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlwholesaleprice_Enabled,(short)0,(string)"text",(string)"",(short)10,(string)"chr",(short)1,(string)"row",(short)10,(short)0,(short)0,(short)111,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         CostpricefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CostpricefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"Right",(string)"top",(string)"div"});
         /* Div Control */
         CostpricefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 142,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         CostpricefgridRow.AddColumnProperties("button", 2, isAjaxCallMode( ), new Object[] {(string)bttRemove_Internalname+"_"+sGXsfl_111_idx,"gx.evt.setGridEvt("+StringUtil.Str( (decimal)(111), 3, 0)+","+"null"+");",(string)"Remove",(string)bttRemove_Jsonclick,(short)7,(string)"Remove",(string)"",(string)StyleString,(string)ClassString,(short)1,(short)1,(string)"standard",(string)"'"+""+"'"+",false,"+"'"+"e202j5_client"+"'",(string)TempTags,(string)"",(short)2});
         CostpricefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CostpricefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CostpricefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         send_integrity_lvl_hashes2J5( ) ;
         /* End of Columns property logic. */
         CostpricefgridContainer.AddRow(CostpricefgridRow);
         nGXsfl_111_idx = ((subCostpricefgrid_Islastpage==1)&&(nGXsfl_111_idx+1>subCostpricefgrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_111_idx+1);
         sGXsfl_111_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_111_idx), 4, 0), 4, "0");
         SubsflControlProps_1115( ) ;
         /* End function sendrow_1115 */
      }

      protected void SubsflControlProps_1754( )
      {
         edtavCtlcode1_Internalname = "CTLCODE1_"+sGXsfl_175_idx;
         edtavCtlname1_Internalname = "CTLNAME1_"+sGXsfl_175_idx;
         edtavCtlsupplier1_Internalname = "CTLSUPPLIER1_"+sGXsfl_175_idx;
         edtavCtlbrand1_Internalname = "CTLBRAND1_"+sGXsfl_175_idx;
         edtavCtlsector1_Internalname = "CTLSECTOR1_"+sGXsfl_175_idx;
         edtavCtlcostprice1_Internalname = "CTLCOSTPRICE1_"+sGXsfl_175_idx;
         edtavCtlretailprofit1_Internalname = "CTLRETAILPROFIT1_"+sGXsfl_175_idx;
         edtavCtlnewretailprofit_Internalname = "CTLNEWRETAILPROFIT_"+sGXsfl_175_idx;
         edtavCtlretailprice1_Internalname = "CTLRETAILPRICE1_"+sGXsfl_175_idx;
      }

      protected void SubsflControlProps_fel_1754( )
      {
         edtavCtlcode1_Internalname = "CTLCODE1_"+sGXsfl_175_fel_idx;
         edtavCtlname1_Internalname = "CTLNAME1_"+sGXsfl_175_fel_idx;
         edtavCtlsupplier1_Internalname = "CTLSUPPLIER1_"+sGXsfl_175_fel_idx;
         edtavCtlbrand1_Internalname = "CTLBRAND1_"+sGXsfl_175_fel_idx;
         edtavCtlsector1_Internalname = "CTLSECTOR1_"+sGXsfl_175_fel_idx;
         edtavCtlcostprice1_Internalname = "CTLCOSTPRICE1_"+sGXsfl_175_fel_idx;
         edtavCtlretailprofit1_Internalname = "CTLRETAILPROFIT1_"+sGXsfl_175_fel_idx;
         edtavCtlnewretailprofit_Internalname = "CTLNEWRETAILPROFIT_"+sGXsfl_175_fel_idx;
         edtavCtlretailprice1_Internalname = "CTLRETAILPRICE1_"+sGXsfl_175_fel_idx;
      }

      protected void sendrow_1754( )
      {
         SubsflControlProps_1754( ) ;
         WB2J0( ) ;
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
            if ( ((int)((nGXsfl_175_idx) % (2))) == 0 )
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
            context.WriteHtmlText( "<tr"+" class=\""+subRetailfgrid_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_175_idx+"\">") ;
         }
         /* Div Control */
         RetailfgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divGrid1table1_Internalname+"_"+sGXsfl_175_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         RetailfgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         RetailfgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         RetailfgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         RetailfgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcode1_Internalname,(string)"Code",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         RetailfgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcode1_Internalname,((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV53GXV18)).gxTpr_Code,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcode1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlcode1_Enabled,(short)0,(string)"text",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)100,(short)0,(short)0,(short)175,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         RetailfgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         RetailfgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         RetailfgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         RetailfgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         RetailfgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname1_Internalname,(string)"Name",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         RetailfgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname1_Internalname,((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV53GXV18)).gxTpr_Name,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlname1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlname1_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)175,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         RetailfgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         RetailfgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         RetailfgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         RetailfgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         RetailfgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsupplier1_Internalname,(string)"Supplier",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         RetailfgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsupplier1_Internalname,((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV53GXV18)).gxTpr_Supplier,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlsupplier1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlsupplier1_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)175,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
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
         RetailfgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlbrand1_Internalname,((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV53GXV18)).gxTpr_Brand,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlbrand1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlbrand1_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)175,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
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
         RetailfgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsector1_Internalname,((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV53GXV18)).gxTpr_Sector,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlsector1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlsector1_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)175,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
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
         RetailfgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcostprice1_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV53GXV18)).gxTpr_Costprice, 10, 2, ".", "")),StringUtil.LTrim( ((edtavCtlcostprice1_Enabled!=0) ? context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV53GXV18)).gxTpr_Costprice, "ZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV53GXV18)).gxTpr_Costprice, "ZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcostprice1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlcostprice1_Enabled,(short)0,(string)"text",(string)"",(short)10,(string)"chr",(short)1,(string)"row",(short)10,(short)0,(short)0,(short)175,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
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
         RetailfgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlretailprofit1_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV53GXV18)).gxTpr_Retailprofit, 6, 2, ".", "")),StringUtil.LTrim( ((edtavCtlretailprofit1_Enabled!=0) ? context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV53GXV18)).gxTpr_Retailprofit, "ZZ9.99") : context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV53GXV18)).gxTpr_Retailprofit, "ZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlretailprofit1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlretailprofit1_Enabled,(short)0,(string)"text",(string)"",(short)6,(string)"chr",(short)1,(string)"row",(short)6,(short)0,(short)0,(short)175,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         RetailfgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         RetailfgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         RetailfgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         RetailfgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         RetailfgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlnewretailprofit_Internalname,"New R. Profit",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         TempTags = " " + ((edtavCtlnewretailprofit_Enabled!=0)&&(edtavCtlnewretailprofit_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 201,'',false,'"+sGXsfl_175_idx+"',175)\"" : " ");
         ROClassString = "Attribute";
         RetailfgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlnewretailprofit_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV53GXV18)).gxTpr_Newretailprofit, 6, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV53GXV18)).gxTpr_Newretailprofit, "ZZ9.99")),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+((edtavCtlnewretailprofit_Enabled!=0)&&(edtavCtlnewretailprofit_Visible!=0) ? " onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,201);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlnewretailprofit_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)1,(short)0,(string)"text",(string)"",(short)6,(string)"chr",(short)1,(string)"row",(short)6,(short)0,(short)0,(short)175,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         RetailfgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         RetailfgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         RetailfgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         RetailfgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         RetailfgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlretailprice1_Internalname,"R. Price",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         RetailfgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlretailprice1_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV53GXV18)).gxTpr_Retailprice, 10, 2, ".", "")),StringUtil.LTrim( ((edtavCtlretailprice1_Enabled!=0) ? context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV53GXV18)).gxTpr_Retailprice, "ZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV53GXV18)).gxTpr_Retailprice, "ZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlretailprice1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlretailprice1_Enabled,(short)0,(string)"text",(string)"",(short)10,(string)"chr",(short)1,(string)"row",(short)10,(short)0,(short)0,(short)175,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         RetailfgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         RetailfgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         RetailfgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         RetailfgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         send_integrity_lvl_hashes2J4( ) ;
         /* End of Columns property logic. */
         RetailfgridContainer.AddRow(RetailfgridRow);
         nGXsfl_175_idx = ((subRetailfgrid_Islastpage==1)&&(nGXsfl_175_idx+1>subRetailfgrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_175_idx+1);
         sGXsfl_175_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_175_idx), 4, 0), 4, "0");
         SubsflControlProps_1754( ) ;
         /* End function sendrow_1754 */
      }

      protected void SubsflControlProps_2373( )
      {
         edtavCtlcode2_Internalname = "CTLCODE2_"+sGXsfl_237_idx;
         edtavCtlname2_Internalname = "CTLNAME2_"+sGXsfl_237_idx;
         edtavCtlsupplier2_Internalname = "CTLSUPPLIER2_"+sGXsfl_237_idx;
         edtavCtlbrand2_Internalname = "CTLBRAND2_"+sGXsfl_237_idx;
         edtavCtlsector2_Internalname = "CTLSECTOR2_"+sGXsfl_237_idx;
         edtavCtlcostprice2_Internalname = "CTLCOSTPRICE2_"+sGXsfl_237_idx;
         edtavCtlwholesaleprofit1_Internalname = "CTLWHOLESALEPROFIT1_"+sGXsfl_237_idx;
         edtavCtlnewwholesaleprofit_Internalname = "CTLNEWWHOLESALEPROFIT_"+sGXsfl_237_idx;
         edtavCtlwholesaleprice1_Internalname = "CTLWHOLESALEPRICE1_"+sGXsfl_237_idx;
      }

      protected void SubsflControlProps_fel_2373( )
      {
         edtavCtlcode2_Internalname = "CTLCODE2_"+sGXsfl_237_fel_idx;
         edtavCtlname2_Internalname = "CTLNAME2_"+sGXsfl_237_fel_idx;
         edtavCtlsupplier2_Internalname = "CTLSUPPLIER2_"+sGXsfl_237_fel_idx;
         edtavCtlbrand2_Internalname = "CTLBRAND2_"+sGXsfl_237_fel_idx;
         edtavCtlsector2_Internalname = "CTLSECTOR2_"+sGXsfl_237_fel_idx;
         edtavCtlcostprice2_Internalname = "CTLCOSTPRICE2_"+sGXsfl_237_fel_idx;
         edtavCtlwholesaleprofit1_Internalname = "CTLWHOLESALEPROFIT1_"+sGXsfl_237_fel_idx;
         edtavCtlnewwholesaleprofit_Internalname = "CTLNEWWHOLESALEPROFIT_"+sGXsfl_237_fel_idx;
         edtavCtlwholesaleprice1_Internalname = "CTLWHOLESALEPRICE1_"+sGXsfl_237_fel_idx;
      }

      protected void sendrow_2373( )
      {
         SubsflControlProps_2373( ) ;
         WB2J0( ) ;
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
            if ( ((int)((nGXsfl_237_idx) % (2))) == 0 )
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
            context.WriteHtmlText( "<tr"+" class=\""+subWholesalefgrid_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_237_idx+"\">") ;
         }
         /* Div Control */
         WholesalefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divGrid2table_Internalname+"_"+sGXsfl_237_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         WholesalefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         WholesalefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         WholesalefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         WholesalefgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcode2_Internalname,(string)"Code",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         WholesalefgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcode2_Internalname,((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV63GXV28)).gxTpr_Code,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcode2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlcode2_Enabled,(short)0,(string)"text",(string)"",(short)80,(string)"chr",(short)1,(string)"row",(short)100,(short)0,(short)0,(short)237,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         WholesalefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         WholesalefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         WholesalefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         WholesalefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         WholesalefgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname2_Internalname,(string)"Name",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         WholesalefgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname2_Internalname,((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV63GXV28)).gxTpr_Name,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlname2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlname2_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)237,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         WholesalefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         WholesalefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         WholesalefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         WholesalefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         WholesalefgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsupplier2_Internalname,(string)"Supplier",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         WholesalefgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsupplier2_Internalname,((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV63GXV28)).gxTpr_Supplier,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlsupplier2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlsupplier2_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)237,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         WholesalefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         WholesalefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         WholesalefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         WholesalefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         WholesalefgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlbrand2_Internalname,(string)"Brand",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         WholesalefgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlbrand2_Internalname,((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV63GXV28)).gxTpr_Brand,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlbrand2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlbrand2_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)237,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         WholesalefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         WholesalefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         WholesalefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         WholesalefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         WholesalefgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsector2_Internalname,(string)"Sector",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         WholesalefgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsector2_Internalname,((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV63GXV28)).gxTpr_Sector,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlsector2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlsector2_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)237,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         WholesalefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         WholesalefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         WholesalefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         WholesalefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         WholesalefgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcostprice2_Internalname,(string)"Cost Price",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         WholesalefgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcostprice2_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV63GXV28)).gxTpr_Costprice, 10, 2, ".", "")),StringUtil.LTrim( ((edtavCtlcostprice2_Enabled!=0) ? context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV63GXV28)).gxTpr_Costprice, "ZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV63GXV28)).gxTpr_Costprice, "ZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcostprice2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlcostprice2_Enabled,(short)0,(string)"text",(string)"",(short)10,(string)"chr",(short)1,(string)"row",(short)10,(short)0,(short)0,(short)237,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         WholesalefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         WholesalefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         WholesalefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         WholesalefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         WholesalefgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlwholesaleprofit1_Internalname,"W. Profit",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         WholesalefgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlwholesaleprofit1_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV63GXV28)).gxTpr_Wholesaleprofit, 6, 2, ".", "")),StringUtil.LTrim( ((edtavCtlwholesaleprofit1_Enabled!=0) ? context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV63GXV28)).gxTpr_Wholesaleprofit, "ZZ9.99") : context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV63GXV28)).gxTpr_Wholesaleprofit, "ZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlwholesaleprofit1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlwholesaleprofit1_Enabled,(short)0,(string)"text",(string)"",(short)6,(string)"chr",(short)1,(string)"row",(short)6,(short)0,(short)0,(short)237,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         WholesalefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         WholesalefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         WholesalefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         WholesalefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         WholesalefgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlnewwholesaleprofit_Internalname,"New W. Profit",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         TempTags = " " + ((edtavCtlnewwholesaleprofit_Enabled!=0)&&(edtavCtlnewwholesaleprofit_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 263,'',false,'"+sGXsfl_237_idx+"',237)\"" : " ");
         ROClassString = "Attribute";
         WholesalefgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlnewwholesaleprofit_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV63GXV28)).gxTpr_Newwholesaleprofit, 6, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV63GXV28)).gxTpr_Newwholesaleprofit, "ZZ9.99")),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+((edtavCtlnewwholesaleprofit_Enabled!=0)&&(edtavCtlnewwholesaleprofit_Visible!=0) ? " onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,263);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlnewwholesaleprofit_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)1,(short)0,(string)"text",(string)"",(short)6,(string)"chr",(short)1,(string)"row",(short)6,(short)0,(short)0,(short)237,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         WholesalefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         WholesalefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         WholesalefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         WholesalefgridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         WholesalefgridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlwholesaleprice1_Internalname,"W. Price",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         WholesalefgridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlwholesaleprice1_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV63GXV28)).gxTpr_Wholesaleprice, 10, 2, ".", "")),StringUtil.LTrim( ((edtavCtlwholesaleprice1_Enabled!=0) ? context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV63GXV28)).gxTpr_Wholesaleprice, "ZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV5ProductsSelected.Item(AV63GXV28)).gxTpr_Wholesaleprice, "ZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlwholesaleprice1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlwholesaleprice1_Enabled,(short)0,(string)"text",(string)"",(short)10,(string)"chr",(short)1,(string)"row",(short)10,(short)0,(short)0,(short)237,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         WholesalefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         WholesalefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         WholesalefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         WholesalefgridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         send_integrity_lvl_hashes2J3( ) ;
         /* End of Columns property logic. */
         WholesalefgridContainer.AddRow(WholesalefgridRow);
         nGXsfl_237_idx = ((subWholesalefgrid_Islastpage==1)&&(nGXsfl_237_idx+1>subWholesalefgrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_237_idx+1);
         sGXsfl_237_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_237_idx), 4, 0), 4, "0");
         SubsflControlProps_2373( ) ;
         /* End function sendrow_2373 */
      }

      protected void init_web_controls( )
      {
         cmbavUpdatetype.Name = "vUPDATETYPE";
         cmbavUpdatetype.WebTags = "";
         cmbavUpdatetype.addItem("0", "Cost Price", 0);
         cmbavUpdatetype.addItem("1", "Retail Profit", 0);
         cmbavUpdatetype.addItem("2", "Whole Sale Profit", 0);
         if ( cmbavUpdatetype.ItemCount > 0 )
         {
            AV12UpdateType = (short)(Math.Round(NumberUtil.Val( cmbavUpdatetype.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV12UpdateType), 1, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV12UpdateType", StringUtil.Str( (decimal)(AV12UpdateType), 1, 0));
         }
         dynavSupplier.Name = "vSUPPLIER";
         dynavSupplier.WebTags = "";
         dynavBrand.Name = "vBRAND";
         dynavBrand.WebTags = "";
         dynavSector.Name = "vSECTOR";
         dynavSector.WebTags = "";
         /* End function init_web_controls */
      }

      protected void StartGridControl36( )
      {
         if ( AllproductsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"AllproductsContainer"+"DivS\" data-gxgridid=\"36\">") ;
            sStyleString = "";
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
            AllproductsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A85ProductCostPrice, 10, 2, ".", ""))));
            AllproductsContainer.AddColumnProperties(AllproductsColumn);
            AllproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A89ProductRetailProfit), 4, 0, ".", ""))));
            AllproductsContainer.AddColumnProperties(AllproductsColumn);
            AllproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A90ProductRetailPrice, 10, 2, ".", ""))));
            AllproductsContainer.AddColumnProperties(AllproductsColumn);
            AllproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A87ProductWholesaleProfit), 4, 0, ".", ""))));
            AllproductsContainer.AddColumnProperties(AllproductsColumn);
            AllproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A88ProductWholesalePrice, 10, 2, ".", ""))));
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

      protected void StartGridControl86( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"86\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            Grid1Container.AddObjectProperty("GridName", "Grid1");
         }
         else
         {
            Grid1Container.AddObjectProperty("GridName", "Grid1");
            Grid1Container.AddObjectProperty("Header", subGrid1_Header);
            Grid1Container.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            Grid1Container.AddObjectProperty("Class", "FreeStyleGrid");
            Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("CmpContext", "");
            Grid1Container.AddObjectProperty("InMasterPage", "false");
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlcode3_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlname3_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlcostprice3_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlretailprice2_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlwholesaleprice2_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
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

      protected void StartGridControl111( )
      {
         if ( CostpricefgridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"CostpricefgridContainer"+"DivS\" data-gxgridid=\"111\">") ;
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
            CostpricefgridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlcode_Enabled), 5, 0, ".", "")));
            CostpricefgridContainer.AddColumnProperties(CostpricefgridColumn);
            CostpricefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricefgridContainer.AddColumnProperties(CostpricefgridColumn);
            CostpricefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricefgridContainer.AddColumnProperties(CostpricefgridColumn);
            CostpricefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricefgridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlname_Enabled), 5, 0, ".", "")));
            CostpricefgridContainer.AddColumnProperties(CostpricefgridColumn);
            CostpricefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricefgridContainer.AddColumnProperties(CostpricefgridColumn);
            CostpricefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricefgridContainer.AddColumnProperties(CostpricefgridColumn);
            CostpricefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricefgridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlsupplier_Enabled), 5, 0, ".", "")));
            CostpricefgridContainer.AddColumnProperties(CostpricefgridColumn);
            CostpricefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricefgridContainer.AddColumnProperties(CostpricefgridColumn);
            CostpricefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricefgridContainer.AddColumnProperties(CostpricefgridColumn);
            CostpricefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricefgridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlbrand_Enabled), 5, 0, ".", "")));
            CostpricefgridContainer.AddColumnProperties(CostpricefgridColumn);
            CostpricefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricefgridContainer.AddColumnProperties(CostpricefgridColumn);
            CostpricefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricefgridContainer.AddColumnProperties(CostpricefgridColumn);
            CostpricefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricefgridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlsector_Enabled), 5, 0, ".", "")));
            CostpricefgridContainer.AddColumnProperties(CostpricefgridColumn);
            CostpricefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricefgridContainer.AddColumnProperties(CostpricefgridColumn);
            CostpricefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricefgridContainer.AddColumnProperties(CostpricefgridColumn);
            CostpricefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricefgridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlcostprice_Enabled), 5, 0, ".", "")));
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
            CostpricefgridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlretailprice_Enabled), 5, 0, ".", "")));
            CostpricefgridContainer.AddColumnProperties(CostpricefgridColumn);
            CostpricefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricefgridContainer.AddColumnProperties(CostpricefgridColumn);
            CostpricefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricefgridContainer.AddColumnProperties(CostpricefgridColumn);
            CostpricefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricefgridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlwholesaleprice_Enabled), 5, 0, ".", "")));
            CostpricefgridContainer.AddColumnProperties(CostpricefgridColumn);
            CostpricefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricefgridContainer.AddColumnProperties(CostpricefgridColumn);
            CostpricefgridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
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

      protected void StartGridControl175( )
      {
         if ( RetailfgridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"RetailfgridContainer"+"DivS\" data-gxgridid=\"175\">") ;
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
            RetailfgridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlretailprice1_Enabled), 5, 0, ".", "")));
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

      protected void StartGridControl237( )
      {
         if ( WholesalefgridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"WholesalefgridContainer"+"DivS\" data-gxgridid=\"237\">") ;
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
            WholesalefgridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlwholesaleprice1_Enabled), 5, 0, ".", "")));
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
         cmbavUpdatetype_Internalname = "vUPDATETYPE";
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
         edtProductWholesaleProfit_Internalname = "PRODUCTWHOLESALEPROFIT";
         edtProductWholesalePrice_Internalname = "PRODUCTWHOLESALEPRICE";
         divTable1_Internalname = "TABLE1";
         bttUpdate_Internalname = "UPDATE";
         bttCancel_Internalname = "CANCEL";
         divButtonstable_Internalname = "BUTTONSTABLE";
         edtavCostpricepercentage_Internalname = "vCOSTPRICEPERCENTAGE";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         lblTextblock28_Internalname = "TEXTBLOCK28";
         divTable2_Internalname = "TABLE2";
         edtavCtlcode3_Internalname = "CTLCODE3";
         edtavCtlname3_Internalname = "CTLNAME3";
         edtavCtlcostprice3_Internalname = "CTLCOSTPRICE3";
         edtavCtlnewcostprice1_Internalname = "CTLNEWCOSTPRICE1";
         edtavCtlretailprice2_Internalname = "CTLRETAILPRICE2";
         edtavCtlwholesaleprice2_Internalname = "CTLWHOLESALEPRICE2";
         bttCostpricebtnremove_Internalname = "COSTPRICEBTNREMOVE";
         divGrid1table2_Internalname = "GRID1TABLE2";
         edtavCtlcode_Internalname = "CTLCODE";
         edtavCtlname_Internalname = "CTLNAME";
         edtavCtlsupplier_Internalname = "CTLSUPPLIER";
         edtavCtlbrand_Internalname = "CTLBRAND";
         edtavCtlsector_Internalname = "CTLSECTOR";
         edtavCtlcostprice_Internalname = "CTLCOSTPRICE";
         edtavCtlnewcostprice_Internalname = "CTLNEWCOSTPRICE";
         edtavCtlretailprice_Internalname = "CTLRETAILPRICE";
         edtavCtlwholesaleprice_Internalname = "CTLWHOLESALEPRICE";
         bttRemove_Internalname = "REMOVE";
         divGrid1table_Internalname = "GRID1TABLE";
         divCostpricetable_Internalname = "COSTPRICETABLE";
         edtavRppercentage_Internalname = "vRPPERCENTAGE";
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
         edtavCtlcode1_Internalname = "CTLCODE1";
         edtavCtlname1_Internalname = "CTLNAME1";
         edtavCtlsupplier1_Internalname = "CTLSUPPLIER1";
         edtavCtlbrand1_Internalname = "CTLBRAND1";
         edtavCtlsector1_Internalname = "CTLSECTOR1";
         edtavCtlcostprice1_Internalname = "CTLCOSTPRICE1";
         edtavCtlretailprofit1_Internalname = "CTLRETAILPROFIT1";
         edtavCtlnewretailprofit_Internalname = "CTLNEWRETAILPROFIT";
         edtavCtlretailprice1_Internalname = "CTLRETAILPRICE1";
         divGrid1table1_Internalname = "GRID1TABLE1";
         divRetaiprofitltable_Internalname = "RETAIPROFITLTABLE";
         edtavWppercentage_Internalname = "vWPPERCENTAGE";
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
         edtavCtlcode2_Internalname = "CTLCODE2";
         edtavCtlname2_Internalname = "CTLNAME2";
         edtavCtlsupplier2_Internalname = "CTLSUPPLIER2";
         edtavCtlbrand2_Internalname = "CTLBRAND2";
         edtavCtlsector2_Internalname = "CTLSECTOR2";
         edtavCtlcostprice2_Internalname = "CTLCOSTPRICE2";
         edtavCtlwholesaleprofit1_Internalname = "CTLWHOLESALEPROFIT1";
         edtavCtlnewwholesaleprofit_Internalname = "CTLNEWWHOLESALEPROFIT";
         edtavCtlwholesaleprice1_Internalname = "CTLWHOLESALEPRICE1";
         divGrid2table_Internalname = "GRID2TABLE";
         divWholesaleprofittable_Internalname = "WHOLESALEPROFITTABLE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subAllproducts_Internalname = "ALLPRODUCTS";
         subGrid1_Internalname = "GRID1";
         subCostpricefgrid_Internalname = "COSTPRICEFGRID";
         subRetailfgrid_Internalname = "RETAILFGRID";
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
         subRetailfgrid_Allowcollapsing = 0;
         subCostpricefgrid_Allowcollapsing = 0;
         subGrid1_Allowcollapsing = 0;
         subAllproducts_Allowcollapsing = 0;
         subAllproducts_Allowselection = 0;
         subAllproducts_Header = "";
         edtavCtlwholesaleprice1_Jsonclick = "";
         edtavCtlwholesaleprice1_Enabled = 0;
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
         subWholesalefgrid_Class = "FreeStyleGrid";
         edtavCtlretailprice1_Jsonclick = "";
         edtavCtlretailprice1_Enabled = 0;
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
         subRetailfgrid_Class = "FreeStyleGrid";
         edtavCtlwholesaleprice_Jsonclick = "";
         edtavCtlwholesaleprice_Enabled = 0;
         edtavCtlretailprice_Jsonclick = "";
         edtavCtlretailprice_Enabled = 0;
         edtavCtlnewcostprice_Jsonclick = "";
         edtavCtlnewcostprice_Visible = 1;
         edtavCtlnewcostprice_Enabled = 1;
         edtavCtlcostprice_Jsonclick = "";
         edtavCtlcostprice_Enabled = 0;
         edtavCtlsector_Jsonclick = "";
         edtavCtlsector_Enabled = 0;
         edtavCtlbrand_Jsonclick = "";
         edtavCtlbrand_Enabled = 0;
         edtavCtlsupplier_Jsonclick = "";
         edtavCtlsupplier_Enabled = 0;
         edtavCtlname_Jsonclick = "";
         edtavCtlname_Enabled = 0;
         edtavCtlcode_Jsonclick = "";
         edtavCtlcode_Enabled = 0;
         subCostpricefgrid_Class = "FreeStyleGrid";
         edtavCtlwholesaleprice2_Jsonclick = "";
         edtavCtlwholesaleprice2_Enabled = 0;
         edtavCtlretailprice2_Jsonclick = "";
         edtavCtlretailprice2_Enabled = 0;
         edtavCtlnewcostprice1_Jsonclick = "";
         edtavCtlnewcostprice1_Visible = 1;
         edtavCtlnewcostprice1_Enabled = 1;
         edtavCtlcostprice3_Jsonclick = "";
         edtavCtlcostprice3_Enabled = 0;
         edtavCtlname3_Jsonclick = "";
         edtavCtlname3_Enabled = 0;
         edtavCtlcode3_Jsonclick = "";
         edtavCtlcode3_Enabled = 0;
         subGrid1_Class = "FreeStyleGrid";
         edtProductWholesalePrice_Jsonclick = "";
         edtProductWholesaleProfit_Jsonclick = "";
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
         subGrid1_Backcolorstyle = 0;
         subCostpricefgrid_Backcolorstyle = 0;
         subRetailfgrid_Backcolorstyle = 0;
         subWholesalefgrid_Backcolorstyle = 0;
         edtavCtlwholesaleprice1_Enabled = -1;
         edtavCtlwholesaleprofit1_Enabled = -1;
         edtavCtlcostprice2_Enabled = -1;
         edtavCtlsector2_Enabled = -1;
         edtavCtlbrand2_Enabled = -1;
         edtavCtlsupplier2_Enabled = -1;
         edtavCtlname2_Enabled = -1;
         edtavCtlcode2_Enabled = -1;
         edtavCtlretailprice1_Enabled = -1;
         edtavCtlretailprofit1_Enabled = -1;
         edtavCtlcostprice1_Enabled = -1;
         edtavCtlsector1_Enabled = -1;
         edtavCtlbrand1_Enabled = -1;
         edtavCtlsupplier1_Enabled = -1;
         edtavCtlname1_Enabled = -1;
         edtavCtlcode1_Enabled = -1;
         edtavCtlwholesaleprice_Enabled = -1;
         edtavCtlretailprice_Enabled = -1;
         edtavCtlcostprice_Enabled = -1;
         edtavCtlsector_Enabled = -1;
         edtavCtlbrand_Enabled = -1;
         edtavCtlsupplier_Enabled = -1;
         edtavCtlname_Enabled = -1;
         edtavCtlcode_Enabled = -1;
         edtavCtlwholesaleprice2_Enabled = -1;
         edtavCtlretailprice2_Enabled = -1;
         edtavCtlcostprice3_Enabled = -1;
         edtavCtlname3_Enabled = -1;
         edtavCtlcode3_Enabled = -1;
         edtavWppercentage_Jsonclick = "";
         edtavWppercentage_Enabled = 1;
         divWholesaleprofittable_Visible = 1;
         edtavRppercentage_Jsonclick = "";
         edtavRppercentage_Enabled = 1;
         divRetaiprofitltable_Visible = 1;
         edtavCostpricepercentage_Jsonclick = "";
         edtavCostpricepercentage_Enabled = 1;
         divCostpricetable_Visible = 1;
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
         cmbavUpdatetype_Jsonclick = "";
         cmbavUpdatetype.Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "WPUpdate Price And Profit";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'WHOLESALEFGRID_nFirstRecordOnPage'},{av:'WHOLESALEFGRID_nEOF'},{av:'RETAILFGRID_nFirstRecordOnPage'},{av:'RETAILFGRID_nEOF'},{av:'COSTPRICEFGRID_nFirstRecordOnPage'},{av:'COSTPRICEFGRID_nEOF'},{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'AV28CostPriceProductsSelected',fld:'vCOSTPRICEPRODUCTSSELECTED',grid:86,pic:''},{av:'nGXsfl_86_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:86},{av:'nRC_GXsfl_86',ctrl:'GRID1',prop:'GridRC',grid:86},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV7Code',fld:'vCODE',pic:''},{av:'AV11Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV10Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV9Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV5ProductsSelected',fld:'vPRODUCTSSELECTED',grid:111,pic:'',hsh:true},{av:'nGXsfl_111_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:111},{av:'nRC_GXsfl_111',ctrl:'COSTPRICEFGRID',prop:'GridRC',grid:111},{av:'nRC_GXsfl_175',ctrl:'RETAILFGRID',prop:'GridRC',grid:175},{av:'nRC_GXsfl_237',ctrl:'WHOLESALEFGRID',prop:'GridRC',grid:237},{av:'AV22newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV23newCode',fld:'vNEWCODE',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("PRODUCTNAME.CLICK","{handler:'E182J2',iparms:[{av:'WHOLESALEFGRID_nFirstRecordOnPage'},{av:'WHOLESALEFGRID_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV7Code',fld:'vCODE',pic:''},{av:'AV11Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV10Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV9Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV5ProductsSelected',fld:'vPRODUCTSSELECTED',grid:111,pic:'',hsh:true},{av:'nGXsfl_111_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:111},{av:'COSTPRICEFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_111',ctrl:'COSTPRICEFGRID',prop:'GridRC',grid:111},{av:'RETAILFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_175',ctrl:'RETAILFGRID',prop:'GridRC',grid:175},{av:'nRC_GXsfl_237',ctrl:'WHOLESALEFGRID',prop:'GridRC',grid:237},{av:'AV22newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV23newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'RETAILFGRID_nEOF'},{av:'COSTPRICEFGRID_nEOF'},{av:'A15ProductId',fld:'PRODUCTID',pic:'ZZZZZ9',hsh:true},{av:'AV32IsIn',fld:'vISIN',pic:''},{av:'cmbavUpdatetype'},{av:'AV12UpdateType',fld:'vUPDATETYPE',pic:'9'},{av:'A85ProductCostPrice',fld:'PRODUCTCOSTPRICE',pic:'ZZZZZZ9.99',hsh:true},{av:'AV13CostPricePercentage',fld:'vCOSTPRICEPERCENTAGE',pic:'ZZ9.99'},{av:'AV28CostPriceProductsSelected',fld:'vCOSTPRICEPRODUCTSSELECTED',grid:86,pic:''},{av:'nGXsfl_86_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:86},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_86',ctrl:'GRID1',prop:'GridRC',grid:86},{av:'AV29CostPriceIdsSelected',fld:'vCOSTPRICEIDSSELECTED',pic:''},{av:'AV33IdSelected',fld:'vIDSELECTED',pic:'ZZZZZ9'},{av:'AV6OneProduct',fld:'vONEPRODUCT',pic:''},{av:'AV14RPPercentage',fld:'vRPPERCENTAGE',pic:'ZZ9.99'},{av:'AV15WPPercentage',fld:'vWPPERCENTAGE',pic:'ZZ9.99'},{av:'AV17Value',fld:'vVALUE',pic:'ZZZZZZ9.99'},{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'GRID1_nEOF'}]");
         setEventMetadata("PRODUCTNAME.CLICK",",oparms:[{av:'AV33IdSelected',fld:'vIDSELECTED',pic:'ZZZZZ9'},{av:'AV6OneProduct',fld:'vONEPRODUCT',pic:''},{av:'AV17Value',fld:'vVALUE',pic:'ZZZZZZ9.99'},{av:'AV28CostPriceProductsSelected',fld:'vCOSTPRICEPRODUCTSSELECTED',grid:86,pic:''},{av:'nGXsfl_86_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:86},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_86',ctrl:'GRID1',prop:'GridRC',grid:86},{av:'AV29CostPriceIdsSelected',fld:'vCOSTPRICEIDSSELECTED',pic:''},{av:'AV32IsIn',fld:'vISIN',pic:''}]}");
         setEventMetadata("'UPDATE'","{handler:'E112J1',iparms:[{av:'cmbavUpdatetype'},{av:'AV12UpdateType',fld:'vUPDATETYPE',pic:'9'}]");
         setEventMetadata("'UPDATE'",",oparms:[]}");
         setEventMetadata("'COSTPRICEREMOVE'","{handler:'E202J5',iparms:[{av:'AV5ProductsSelected',fld:'vPRODUCTSSELECTED',grid:111,pic:'',hsh:true},{av:'nGXsfl_111_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:111},{av:'COSTPRICEFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_111',ctrl:'COSTPRICEFGRID',prop:'GridRC',grid:111},{av:'RETAILFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_175',ctrl:'RETAILFGRID',prop:'GridRC',grid:175},{av:'WHOLESALEFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_237',ctrl:'WHOLESALEFGRID',prop:'GridRC',grid:237}]");
         setEventMetadata("'COSTPRICEREMOVE'",",oparms:[]}");
         setEventMetadata("'COSTPRICEBTNREMOVE'","{handler:'E122J2',iparms:[{av:'COSTPRICEFGRID_nFirstRecordOnPage'},{av:'COSTPRICEFGRID_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV7Code',fld:'vCODE',pic:''},{av:'AV11Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV10Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV9Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV5ProductsSelected',fld:'vPRODUCTSSELECTED',grid:111,pic:'',hsh:true},{av:'nGXsfl_111_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:111},{av:'nRC_GXsfl_111',ctrl:'COSTPRICEFGRID',prop:'GridRC',grid:111},{av:'RETAILFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_175',ctrl:'RETAILFGRID',prop:'GridRC',grid:175},{av:'WHOLESALEFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_237',ctrl:'WHOLESALEFGRID',prop:'GridRC',grid:237},{av:'AV22newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV23newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'AV28CostPriceProductsSelected',fld:'vCOSTPRICEPRODUCTSSELECTED',grid:86,pic:''},{av:'nGXsfl_86_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:86},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_86',ctrl:'GRID1',prop:'GridRC',grid:86},{av:'AV29CostPriceIdsSelected',fld:'vCOSTPRICEIDSSELECTED',pic:''},{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'WHOLESALEFGRID_nEOF'},{av:'RETAILFGRID_nEOF'},{av:'GRID1_nEOF'}]");
         setEventMetadata("'COSTPRICEBTNREMOVE'",",oparms:[{av:'AV28CostPriceProductsSelected',fld:'vCOSTPRICEPRODUCTSSELECTED',grid:86,pic:''},{av:'nGXsfl_86_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:86},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_86',ctrl:'GRID1',prop:'GridRC',grid:86},{av:'AV29CostPriceIdsSelected',fld:'vCOSTPRICEIDSSELECTED',pic:''}]}");
         setEventMetadata("ALLPRODUCTS_FIRSTPAGE","{handler:'suballproducts_firstpage',iparms:[{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV7Code',fld:'vCODE',pic:''},{av:'AV11Name',fld:'vNAME',pic:''},{av:'AV5ProductsSelected',fld:'vPRODUCTSSELECTED',grid:111,pic:'',hsh:true},{av:'nGXsfl_111_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:111},{av:'COSTPRICEFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_111',ctrl:'COSTPRICEFGRID',prop:'GridRC',grid:111},{av:'RETAILFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_175',ctrl:'RETAILFGRID',prop:'GridRC',grid:175},{av:'WHOLESALEFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_237',ctrl:'WHOLESALEFGRID',prop:'GridRC',grid:237},{av:'AV22newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV23newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'dynavSupplier'},{av:'AV10Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV9Sector',fld:'vSECTOR',pic:'ZZZZZ9'}]");
         setEventMetadata("ALLPRODUCTS_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("ALLPRODUCTS_PREVPAGE","{handler:'suballproducts_previouspage',iparms:[{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV7Code',fld:'vCODE',pic:''},{av:'AV11Name',fld:'vNAME',pic:''},{av:'AV5ProductsSelected',fld:'vPRODUCTSSELECTED',grid:111,pic:'',hsh:true},{av:'nGXsfl_111_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:111},{av:'COSTPRICEFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_111',ctrl:'COSTPRICEFGRID',prop:'GridRC',grid:111},{av:'RETAILFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_175',ctrl:'RETAILFGRID',prop:'GridRC',grid:175},{av:'WHOLESALEFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_237',ctrl:'WHOLESALEFGRID',prop:'GridRC',grid:237},{av:'AV22newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV23newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'dynavSupplier'},{av:'AV10Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV9Sector',fld:'vSECTOR',pic:'ZZZZZ9'}]");
         setEventMetadata("ALLPRODUCTS_PREVPAGE",",oparms:[]}");
         setEventMetadata("ALLPRODUCTS_NEXTPAGE","{handler:'suballproducts_nextpage',iparms:[{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV7Code',fld:'vCODE',pic:''},{av:'AV11Name',fld:'vNAME',pic:''},{av:'AV5ProductsSelected',fld:'vPRODUCTSSELECTED',grid:111,pic:'',hsh:true},{av:'nGXsfl_111_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:111},{av:'COSTPRICEFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_111',ctrl:'COSTPRICEFGRID',prop:'GridRC',grid:111},{av:'RETAILFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_175',ctrl:'RETAILFGRID',prop:'GridRC',grid:175},{av:'WHOLESALEFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_237',ctrl:'WHOLESALEFGRID',prop:'GridRC',grid:237},{av:'AV22newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV23newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'dynavSupplier'},{av:'AV10Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV9Sector',fld:'vSECTOR',pic:'ZZZZZ9'}]");
         setEventMetadata("ALLPRODUCTS_NEXTPAGE",",oparms:[]}");
         setEventMetadata("ALLPRODUCTS_LASTPAGE","{handler:'suballproducts_lastpage',iparms:[{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV7Code',fld:'vCODE',pic:''},{av:'AV11Name',fld:'vNAME',pic:''},{av:'AV5ProductsSelected',fld:'vPRODUCTSSELECTED',grid:111,pic:'',hsh:true},{av:'nGXsfl_111_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:111},{av:'COSTPRICEFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_111',ctrl:'COSTPRICEFGRID',prop:'GridRC',grid:111},{av:'RETAILFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_175',ctrl:'RETAILFGRID',prop:'GridRC',grid:175},{av:'WHOLESALEFGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_237',ctrl:'WHOLESALEFGRID',prop:'GridRC',grid:237},{av:'AV22newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV23newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'dynavSupplier'},{av:'AV10Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV8Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV9Sector',fld:'vSECTOR',pic:'ZZZZZ9'}]");
         setEventMetadata("ALLPRODUCTS_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_UPDATETYPE","{handler:'Validv_Updatetype',iparms:[]");
         setEventMetadata("VALIDV_UPDATETYPE",",oparms:[]}");
         setEventMetadata("VALID_PRODUCTCOSTPRICE","{handler:'Valid_Productcostprice',iparms:[]");
         setEventMetadata("VALID_PRODUCTCOSTPRICE",",oparms:[]}");
         setEventMetadata("VALID_PRODUCTRETAILPROFIT","{handler:'Valid_Productretailprofit',iparms:[]");
         setEventMetadata("VALID_PRODUCTRETAILPROFIT",",oparms:[]}");
         setEventMetadata("VALID_PRODUCTWHOLESALEPROFIT","{handler:'Valid_Productwholesaleprofit',iparms:[]");
         setEventMetadata("VALID_PRODUCTWHOLESALEPROFIT",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Productwholesaleprice',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Gxv7',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Gxv17',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Gxv27',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Gxv37',iparms:[]");
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
         AV7Code = "";
         AV11Name = "";
         AV5ProductsSelected = new GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem>( context, "SDTProductsSelectedItem", "mtaKB");
         AV22newName = "";
         AV23newCode = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV28CostPriceProductsSelected = new GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem>( context, "SDTProductsSelectedItem", "mtaKB");
         AV29CostPriceIdsSelected = new GxSimpleCollection<int>();
         AV6OneProduct = new SdtSDTProductsSelected_SDTProductsSelectedItem(context);
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         AllproductsContainer = new GXWebGrid( context);
         sStyleString = "";
         ClassString = "";
         StyleString = "";
         bttUpdate_Jsonclick = "";
         bttCancel_Jsonclick = "";
         lblTextblock1_Jsonclick = "";
         lblTextblock2_Jsonclick = "";
         lblTextblock6_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
         lblTextblock8_Jsonclick = "";
         lblTextblock9_Jsonclick = "";
         lblTextblock28_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         CostpricefgridContainer = new GXWebGrid( context);
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
         H002J3_A2BrandName = new string[] {""} ;
         H002J4_A9SectorId = new int[1] ;
         H002J4_A10SectorName = new string[] {""} ;
         lV7Code = "";
         lV11Name = "";
         H002J5_A9SectorId = new int[1] ;
         H002J5_A1BrandId = new int[1] ;
         H002J5_A4SupplierId = new int[1] ;
         H002J5_A10SectorName = new string[] {""} ;
         H002J5_A2BrandName = new string[] {""} ;
         H002J5_A5SupplierName = new string[] {""} ;
         H002J5_A16ProductName = new string[] {""} ;
         H002J5_A55ProductCode = new string[] {""} ;
         H002J5_n55ProductCode = new bool[] {false} ;
         H002J5_A15ProductId = new int[1] ;
         H002J5_A89ProductRetailProfit = new short[1] ;
         H002J5_n89ProductRetailProfit = new bool[] {false} ;
         H002J5_A87ProductWholesaleProfit = new short[1] ;
         H002J5_n87ProductWholesaleProfit = new bool[] {false} ;
         H002J5_A85ProductCostPrice = new decimal[1] ;
         H002J6_AALLPRODUCTS_nRecordCount = new long[1] ;
         GXt_SdtSDTProductsSelected_SDTProductsSelectedItem1 = new SdtSDTProductsSelected_SDTProductsSelectedItem(context);
         AllproductsRow = new GXWebRow();
         WholesalefgridRow = new GXWebRow();
         RetailfgridRow = new GXWebRow();
         CostpricefgridRow = new GXWebRow();
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subAllproducts_Linesclass = "";
         ROClassString = "";
         subGrid1_Linesclass = "";
         bttCostpricebtnremove_Jsonclick = "";
         subCostpricefgrid_Linesclass = "";
         bttRemove_Jsonclick = "";
         subRetailfgrid_Linesclass = "";
         subWholesalefgrid_Linesclass = "";
         AllproductsColumn = new GXWebColumn();
         subGrid1_Header = "";
         Grid1Column = new GXWebColumn();
         subCostpricefgrid_Header = "";
         CostpricefgridColumn = new GXWebColumn();
         subRetailfgrid_Header = "";
         RetailfgridColumn = new GXWebColumn();
         subWholesalefgrid_Header = "";
         WholesalefgridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpupdatepriceandprofit__default(),
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
               H002J5_A9SectorId, H002J5_A1BrandId, H002J5_A4SupplierId, H002J5_A10SectorName, H002J5_A2BrandName, H002J5_A5SupplierName, H002J5_A16ProductName, H002J5_A55ProductCode, H002J5_n55ProductCode, H002J5_A15ProductId,
               H002J5_A89ProductRetailProfit, H002J5_n89ProductRetailProfit, H002J5_A87ProductWholesaleProfit, H002J5_n87ProductWholesaleProfit, H002J5_A85ProductCostPrice
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
         edtavCtlcode_Enabled = 0;
         edtavCtlname_Enabled = 0;
         edtavCtlsupplier_Enabled = 0;
         edtavCtlbrand_Enabled = 0;
         edtavCtlsector_Enabled = 0;
         edtavCtlcostprice_Enabled = 0;
         edtavCtlretailprice_Enabled = 0;
         edtavCtlwholesaleprice_Enabled = 0;
         edtavCtlcode1_Enabled = 0;
         edtavCtlname1_Enabled = 0;
         edtavCtlsupplier1_Enabled = 0;
         edtavCtlbrand1_Enabled = 0;
         edtavCtlsector1_Enabled = 0;
         edtavCtlcostprice1_Enabled = 0;
         edtavCtlretailprofit1_Enabled = 0;
         edtavCtlretailprice1_Enabled = 0;
         edtavCtlcode2_Enabled = 0;
         edtavCtlname2_Enabled = 0;
         edtavCtlsupplier2_Enabled = 0;
         edtavCtlbrand2_Enabled = 0;
         edtavCtlsector2_Enabled = 0;
         edtavCtlcostprice2_Enabled = 0;
         edtavCtlwholesaleprofit1_Enabled = 0;
         edtavCtlwholesaleprice1_Enabled = 0;
      }

      private short nRcdExists_6 ;
      private short nIsMod_6 ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short ALLPRODUCTS_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV12UpdateType ;
      private short A89ProductRetailProfit ;
      private short A87ProductWholesaleProfit ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subAllproducts_Backcolorstyle ;
      private short subWholesalefgrid_Backcolorstyle ;
      private short subRetailfgrid_Backcolorstyle ;
      private short subCostpricefgrid_Backcolorstyle ;
      private short subGrid1_Backcolorstyle ;
      private short WHOLESALEFGRID_nEOF ;
      private short RETAILFGRID_nEOF ;
      private short COSTPRICEFGRID_nEOF ;
      private short GRID1_nEOF ;
      private short AV25Count ;
      private short AV26Digit ;
      private short AV27I ;
      private short AV30Position ;
      private short nGXWrapped ;
      private short subAllproducts_Backstyle ;
      private short subGrid1_Backstyle ;
      private short subCostpricefgrid_Backstyle ;
      private short subRetailfgrid_Backstyle ;
      private short subWholesalefgrid_Backstyle ;
      private short subAllproducts_Titlebackstyle ;
      private short subAllproducts_Allowselection ;
      private short subAllproducts_Allowhovering ;
      private short subAllproducts_Allowcollapsing ;
      private short subAllproducts_Collapsed ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private short subCostpricefgrid_Allowselection ;
      private short subCostpricefgrid_Allowhovering ;
      private short subCostpricefgrid_Allowcollapsing ;
      private short subCostpricefgrid_Collapsed ;
      private short subRetailfgrid_Allowselection ;
      private short subRetailfgrid_Allowhovering ;
      private short subRetailfgrid_Allowcollapsing ;
      private short subRetailfgrid_Collapsed ;
      private short subWholesalefgrid_Allowselection ;
      private short subWholesalefgrid_Allowhovering ;
      private short subWholesalefgrid_Allowcollapsing ;
      private short subWholesalefgrid_Collapsed ;
      private int nRC_GXsfl_36 ;
      private int nRC_GXsfl_86 ;
      private int nRC_GXsfl_111 ;
      private int nRC_GXsfl_175 ;
      private int nRC_GXsfl_237 ;
      private int subAllproducts_Rows ;
      private int nGXsfl_36_idx=1 ;
      private int AV10Supplier ;
      private int AV8Brand ;
      private int AV9Sector ;
      private int nGXsfl_86_idx=1 ;
      private int nGXsfl_111_idx=1 ;
      private int nGXsfl_175_idx=1 ;
      private int nGXsfl_237_idx=1 ;
      private int AV33IdSelected ;
      private int edtavCode_Enabled ;
      private int edtavName_Enabled ;
      private int divCostpricetable_Visible ;
      private int edtavCostpricepercentage_Enabled ;
      private int AV36GXV1 ;
      private int AV43GXV8 ;
      private int divRetaiprofitltable_Visible ;
      private int edtavRppercentage_Enabled ;
      private int AV53GXV18 ;
      private int divWholesaleprofittable_Visible ;
      private int edtavWppercentage_Enabled ;
      private int AV63GXV28 ;
      private int A15ProductId ;
      private int gxdynajaxindex ;
      private int subAllproducts_Islastpage ;
      private int subWholesalefgrid_Islastpage ;
      private int subRetailfgrid_Islastpage ;
      private int subCostpricefgrid_Islastpage ;
      private int subGrid1_Islastpage ;
      private int edtavCtlcode3_Enabled ;
      private int edtavCtlname3_Enabled ;
      private int edtavCtlcostprice3_Enabled ;
      private int edtavCtlretailprice2_Enabled ;
      private int edtavCtlwholesaleprice2_Enabled ;
      private int edtavCtlcode_Enabled ;
      private int edtavCtlname_Enabled ;
      private int edtavCtlsupplier_Enabled ;
      private int edtavCtlbrand_Enabled ;
      private int edtavCtlsector_Enabled ;
      private int edtavCtlcostprice_Enabled ;
      private int edtavCtlretailprice_Enabled ;
      private int edtavCtlwholesaleprice_Enabled ;
      private int edtavCtlcode1_Enabled ;
      private int edtavCtlname1_Enabled ;
      private int edtavCtlsupplier1_Enabled ;
      private int edtavCtlbrand1_Enabled ;
      private int edtavCtlsector1_Enabled ;
      private int edtavCtlcostprice1_Enabled ;
      private int edtavCtlretailprofit1_Enabled ;
      private int edtavCtlretailprice1_Enabled ;
      private int edtavCtlcode2_Enabled ;
      private int edtavCtlname2_Enabled ;
      private int edtavCtlsupplier2_Enabled ;
      private int edtavCtlbrand2_Enabled ;
      private int edtavCtlsector2_Enabled ;
      private int edtavCtlcostprice2_Enabled ;
      private int edtavCtlwholesaleprofit1_Enabled ;
      private int edtavCtlwholesaleprice1_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A4SupplierId ;
      private int A1BrandId ;
      private int A9SectorId ;
      private int nGXsfl_86_fel_idx=1 ;
      private int nGXsfl_111_fel_idx=1 ;
      private int nGXsfl_175_fel_idx=1 ;
      private int nGXsfl_237_fel_idx=1 ;
      private int nGXsfl_86_bak_idx=1 ;
      private int idxLst ;
      private int subAllproducts_Backcolor ;
      private int subAllproducts_Allbackcolor ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int edtavCtlnewcostprice1_Enabled ;
      private int edtavCtlnewcostprice1_Visible ;
      private int subCostpricefgrid_Backcolor ;
      private int subCostpricefgrid_Allbackcolor ;
      private int edtavCtlnewcostprice_Enabled ;
      private int edtavCtlnewcostprice_Visible ;
      private int subRetailfgrid_Backcolor ;
      private int subRetailfgrid_Allbackcolor ;
      private int edtavCtlnewretailprofit_Enabled ;
      private int edtavCtlnewretailprofit_Visible ;
      private int subWholesalefgrid_Backcolor ;
      private int subWholesalefgrid_Allbackcolor ;
      private int edtavCtlnewwholesaleprofit_Enabled ;
      private int edtavCtlnewwholesaleprofit_Visible ;
      private int subAllproducts_Titlebackcolor ;
      private int subAllproducts_Selectedindex ;
      private int subAllproducts_Selectioncolor ;
      private int subAllproducts_Hoveringcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private int subCostpricefgrid_Selectedindex ;
      private int subCostpricefgrid_Selectioncolor ;
      private int subCostpricefgrid_Hoveringcolor ;
      private int subRetailfgrid_Selectedindex ;
      private int subRetailfgrid_Selectioncolor ;
      private int subRetailfgrid_Hoveringcolor ;
      private int subWholesalefgrid_Selectedindex ;
      private int subWholesalefgrid_Selectioncolor ;
      private int subWholesalefgrid_Hoveringcolor ;
      private long ALLPRODUCTS_nFirstRecordOnPage ;
      private long ALLPRODUCTS_nCurrentRecord ;
      private long GRID1_nCurrentRecord ;
      private long COSTPRICEFGRID_nCurrentRecord ;
      private long RETAILFGRID_nCurrentRecord ;
      private long WHOLESALEFGRID_nCurrentRecord ;
      private long ALLPRODUCTS_nRecordCount ;
      private long WHOLESALEFGRID_nFirstRecordOnPage ;
      private long RETAILFGRID_nFirstRecordOnPage ;
      private long COSTPRICEFGRID_nFirstRecordOnPage ;
      private long GRID1_nFirstRecordOnPage ;
      private decimal AV17Value ;
      private decimal AV13CostPricePercentage ;
      private decimal AV14RPPercentage ;
      private decimal AV15WPPercentage ;
      private decimal A85ProductCostPrice ;
      private decimal A90ProductRetailPrice ;
      private decimal A88ProductWholesalePrice ;
      private decimal AV18PriceRounded ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_36_idx="0001" ;
      private string sGXsfl_86_idx="0001" ;
      private string sGXsfl_111_idx="0001" ;
      private string sGXsfl_175_idx="0001" ;
      private string sGXsfl_237_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divTable1_Internalname ;
      private string cmbavUpdatetype_Internalname ;
      private string TempTags ;
      private string cmbavUpdatetype_Jsonclick ;
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
      private string ClassString ;
      private string StyleString ;
      private string bttUpdate_Internalname ;
      private string bttUpdate_Jsonclick ;
      private string bttCancel_Internalname ;
      private string bttCancel_Jsonclick ;
      private string divCostpricetable_Internalname ;
      private string edtavCostpricepercentage_Internalname ;
      private string edtavCostpricepercentage_Jsonclick ;
      private string divTable2_Internalname ;
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
      private string lblTextblock28_Internalname ;
      private string lblTextblock28_Jsonclick ;
      private string subGrid1_Internalname ;
      private string subCostpricefgrid_Internalname ;
      private string divRetaiprofitltable_Internalname ;
      private string edtavRppercentage_Internalname ;
      private string edtavRppercentage_Jsonclick ;
      private string divTable3_Internalname ;
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
      private string divWholesaleprofittable_Internalname ;
      private string edtavWppercentage_Internalname ;
      private string edtavWppercentage_Jsonclick ;
      private string divTable4_Internalname ;
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
      private string edtProductId_Internalname ;
      private string edtProductCode_Internalname ;
      private string edtProductName_Internalname ;
      private string edtSupplierName_Internalname ;
      private string edtBrandName_Internalname ;
      private string edtSectorName_Internalname ;
      private string edtProductCostPrice_Internalname ;
      private string edtProductRetailProfit_Internalname ;
      private string edtProductRetailPrice_Internalname ;
      private string edtProductWholesaleProfit_Internalname ;
      private string edtProductWholesalePrice_Internalname ;
      private string gxwrpcisep ;
      private string scmdbuf ;
      private string edtavCtlcode3_Internalname ;
      private string edtavCtlname3_Internalname ;
      private string edtavCtlcostprice3_Internalname ;
      private string edtavCtlretailprice2_Internalname ;
      private string edtavCtlwholesaleprice2_Internalname ;
      private string edtavCtlcode_Internalname ;
      private string edtavCtlname_Internalname ;
      private string edtavCtlsupplier_Internalname ;
      private string edtavCtlbrand_Internalname ;
      private string edtavCtlsector_Internalname ;
      private string edtavCtlcostprice_Internalname ;
      private string edtavCtlretailprice_Internalname ;
      private string edtavCtlwholesaleprice_Internalname ;
      private string edtavCtlcode1_Internalname ;
      private string edtavCtlname1_Internalname ;
      private string edtavCtlsupplier1_Internalname ;
      private string edtavCtlbrand1_Internalname ;
      private string edtavCtlsector1_Internalname ;
      private string edtavCtlcostprice1_Internalname ;
      private string edtavCtlretailprofit1_Internalname ;
      private string edtavCtlretailprice1_Internalname ;
      private string edtavCtlcode2_Internalname ;
      private string edtavCtlname2_Internalname ;
      private string edtavCtlsupplier2_Internalname ;
      private string edtavCtlbrand2_Internalname ;
      private string edtavCtlsector2_Internalname ;
      private string edtavCtlcostprice2_Internalname ;
      private string edtavCtlwholesaleprofit1_Internalname ;
      private string edtavCtlwholesaleprice1_Internalname ;
      private string sGXsfl_86_fel_idx="0001" ;
      private string sGXsfl_111_fel_idx="0001" ;
      private string sGXsfl_175_fel_idx="0001" ;
      private string sGXsfl_237_fel_idx="0001" ;
      private string sGXsfl_36_fel_idx="0001" ;
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
      private string edtProductWholesaleProfit_Jsonclick ;
      private string edtProductWholesalePrice_Jsonclick ;
      private string edtavCtlnewcostprice1_Internalname ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string divGrid1table2_Internalname ;
      private string edtavCtlcode3_Jsonclick ;
      private string edtavCtlname3_Jsonclick ;
      private string edtavCtlcostprice3_Jsonclick ;
      private string edtavCtlnewcostprice1_Jsonclick ;
      private string edtavCtlretailprice2_Jsonclick ;
      private string edtavCtlwholesaleprice2_Jsonclick ;
      private string bttCostpricebtnremove_Internalname ;
      private string bttCostpricebtnremove_Jsonclick ;
      private string edtavCtlnewcostprice_Internalname ;
      private string subCostpricefgrid_Class ;
      private string subCostpricefgrid_Linesclass ;
      private string divGrid1table_Internalname ;
      private string edtavCtlcode_Jsonclick ;
      private string edtavCtlname_Jsonclick ;
      private string edtavCtlsupplier_Jsonclick ;
      private string edtavCtlbrand_Jsonclick ;
      private string edtavCtlsector_Jsonclick ;
      private string edtavCtlcostprice_Jsonclick ;
      private string edtavCtlnewcostprice_Jsonclick ;
      private string edtavCtlretailprice_Jsonclick ;
      private string edtavCtlwholesaleprice_Jsonclick ;
      private string bttRemove_Internalname ;
      private string bttRemove_Jsonclick ;
      private string edtavCtlnewretailprofit_Internalname ;
      private string subRetailfgrid_Class ;
      private string subRetailfgrid_Linesclass ;
      private string divGrid1table1_Internalname ;
      private string edtavCtlcode1_Jsonclick ;
      private string edtavCtlname1_Jsonclick ;
      private string edtavCtlsupplier1_Jsonclick ;
      private string edtavCtlbrand1_Jsonclick ;
      private string edtavCtlsector1_Jsonclick ;
      private string edtavCtlcostprice1_Jsonclick ;
      private string edtavCtlretailprofit1_Jsonclick ;
      private string edtavCtlnewretailprofit_Jsonclick ;
      private string edtavCtlretailprice1_Jsonclick ;
      private string edtavCtlnewwholesaleprofit_Internalname ;
      private string subWholesalefgrid_Class ;
      private string subWholesalefgrid_Linesclass ;
      private string divGrid2table_Internalname ;
      private string edtavCtlcode2_Jsonclick ;
      private string edtavCtlname2_Jsonclick ;
      private string edtavCtlsupplier2_Jsonclick ;
      private string edtavCtlbrand2_Jsonclick ;
      private string edtavCtlsector2_Jsonclick ;
      private string edtavCtlcostprice2_Jsonclick ;
      private string edtavCtlwholesaleprofit1_Jsonclick ;
      private string edtavCtlnewwholesaleprofit_Jsonclick ;
      private string edtavCtlwholesaleprice1_Jsonclick ;
      private string subAllproducts_Header ;
      private string subGrid1_Header ;
      private string subCostpricefgrid_Header ;
      private string subRetailfgrid_Header ;
      private string subWholesalefgrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV32IsIn ;
      private bool AV24AllOk ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n55ProductCode ;
      private bool n89ProductRetailProfit ;
      private bool n87ProductWholesaleProfit ;
      private bool gxdyncontrolsrefreshing ;
      private bool bGXsfl_86_Refreshing=false ;
      private bool bGXsfl_111_Refreshing=false ;
      private bool bGXsfl_175_Refreshing=false ;
      private bool bGXsfl_237_Refreshing=false ;
      private bool bGXsfl_36_Refreshing=false ;
      private bool returnInSub ;
      private bool gx_BV86 ;
      private string AV7Code ;
      private string AV11Name ;
      private string AV22newName ;
      private string AV23newCode ;
      private string A55ProductCode ;
      private string A16ProductName ;
      private string A5SupplierName ;
      private string A2BrandName ;
      private string A10SectorName ;
      private string lV7Code ;
      private string lV11Name ;
      private GxSimpleCollection<int> AV29CostPriceIdsSelected ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid AllproductsContainer ;
      private GXWebGrid Grid1Container ;
      private GXWebGrid CostpricefgridContainer ;
      private GXWebGrid RetailfgridContainer ;
      private GXWebGrid WholesalefgridContainer ;
      private GXWebRow AllproductsRow ;
      private GXWebRow WholesalefgridRow ;
      private GXWebRow RetailfgridRow ;
      private GXWebRow CostpricefgridRow ;
      private GXWebRow Grid1Row ;
      private GXWebColumn AllproductsColumn ;
      private GXWebColumn Grid1Column ;
      private GXWebColumn CostpricefgridColumn ;
      private GXWebColumn RetailfgridColumn ;
      private GXWebColumn WholesalefgridColumn ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavUpdatetype ;
      private GXCombobox dynavSupplier ;
      private GXCombobox dynavBrand ;
      private GXCombobox dynavSector ;
      private IDataStoreProvider pr_default ;
      private int[] H002J2_A4SupplierId ;
      private string[] H002J2_A5SupplierName ;
      private int[] H002J3_A1BrandId ;
      private string[] H002J3_A2BrandName ;
      private int[] H002J4_A9SectorId ;
      private string[] H002J4_A10SectorName ;
      private int[] H002J5_A9SectorId ;
      private int[] H002J5_A1BrandId ;
      private int[] H002J5_A4SupplierId ;
      private string[] H002J5_A10SectorName ;
      private string[] H002J5_A2BrandName ;
      private string[] H002J5_A5SupplierName ;
      private string[] H002J5_A16ProductName ;
      private string[] H002J5_A55ProductCode ;
      private bool[] H002J5_n55ProductCode ;
      private int[] H002J5_A15ProductId ;
      private short[] H002J5_A89ProductRetailProfit ;
      private bool[] H002J5_n89ProductRetailProfit ;
      private short[] H002J5_A87ProductWholesaleProfit ;
      private bool[] H002J5_n87ProductWholesaleProfit ;
      private decimal[] H002J5_A85ProductCostPrice ;
      private long[] H002J6_AALLPRODUCTS_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> AV5ProductsSelected ;
      private GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> AV28CostPriceProductsSelected ;
      private GXWebForm Form ;
      private SdtSDTProductsSelected_SDTProductsSelectedItem AV6OneProduct ;
      private SdtSDTProductsSelected_SDTProductsSelectedItem GXt_SdtSDTProductsSelected_SDTProductsSelectedItem1 ;
   }

   public class wpupdatepriceandprofit__default : DataStoreHelperBase, IDataStoreHelper
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
                                             int A9SectorId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[8];
         Object[] GXv_Object3 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[SectorId], T1.[BrandId], T1.[SupplierId], T2.[SectorName], T3.[BrandName], T4.[SupplierName], T1.[ProductName], T1.[ProductCode], T1.[ProductId], T1.[ProductRetailProfit], T1.[ProductWholesaleProfit], T1.[ProductCostPrice]";
         sFromString = " FROM ((([Product] T1 INNER JOIN [Sector] T2 ON T2.[SectorId] = T1.[SectorId]) INNER JOIN [Brand] T3 ON T3.[BrandId] = T1.[BrandId]) INNER JOIN [Supplier] T4 ON T4.[SupplierId] = T1.[SupplierId])";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7Code)) )
         {
            AddWhere(sWhereString, "(T1.[ProductCode] like @lV7Code)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11Name)) )
         {
            AddWhere(sWhereString, "(T1.[ProductName] like @lV11Name)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (0==AV10Supplier) )
         {
            AddWhere(sWhereString, "(T1.[SupplierId] = @AV10Supplier)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (0==AV8Brand) )
         {
            AddWhere(sWhereString, "(T1.[BrandId] = @AV8Brand)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! (0==AV9Sector) )
         {
            AddWhere(sWhereString, "(T1.[SectorId] = @AV9Sector)");
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
                                             int A9SectorId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[5];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ((([Product] T1 INNER JOIN [Sector] T3 ON T3.[SectorId] = T1.[SectorId]) INNER JOIN [Brand] T2 ON T2.[BrandId] = T1.[BrandId]) INNER JOIN [Supplier] T4 ON T4.[SupplierId] = T1.[SupplierId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7Code)) )
         {
            AddWhere(sWhereString, "(T1.[ProductCode] like @lV7Code)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11Name)) )
         {
            AddWhere(sWhereString, "(T1.[ProductName] like @lV11Name)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ! (0==AV10Supplier) )
         {
            AddWhere(sWhereString, "(T1.[SupplierId] = @AV10Supplier)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! (0==AV8Brand) )
         {
            AddWhere(sWhereString, "(T1.[BrandId] = @AV8Brand)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! (0==AV9Sector) )
         {
            AddWhere(sWhereString, "(T1.[SectorId] = @AV9Sector)");
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
                     return conditional_H002J5(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] );
               case 4 :
                     return conditional_H002J6(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] );
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((int[]) buf[9])[0] = rslt.getInt(9);
                ((short[]) buf[10])[0] = rslt.getShort(10);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((short[]) buf[12])[0] = rslt.getShort(11);
                ((bool[]) buf[13])[0] = rslt.wasNull(11);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(12);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
