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
   public class wpupdatepricecopy1 : GXDataArea
   {
      public wpupdatepricecopy1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public wpupdatepricecopy1( IGxContext context )
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
               GXDLVvSUPPLIER2I2( ) ;
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
               GXDLVvBRAND2I2( ) ;
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
               GXDLVvSECTOR2I2( ) ;
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Costpricegrid") == 0 )
            {
               gxnrCostpricegrid_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Costpricegrid") == 0 )
            {
               gxgrCostpricegrid_refresh_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid3") == 0 )
            {
               gxnrGrid3_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid3") == 0 )
            {
               gxgrGrid3_refresh_invoke( ) ;
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
         AV15Name = GetPar( "Name");
         dynavSupplier.FromJSonString( GetNextPar( ));
         AV30Supplier = (int)(Math.Round(NumberUtil.Val( GetPar( "Supplier"), "."), 18, MidpointRounding.ToEven));
         dynavBrand.FromJSonString( GetNextPar( ));
         AV9Brand = (int)(Math.Round(NumberUtil.Val( GetPar( "Brand"), "."), 18, MidpointRounding.ToEven));
         dynavSector.FromJSonString( GetNextPar( ));
         AV26Sector = (int)(Math.Round(NumberUtil.Val( GetPar( "Sector"), "."), 18, MidpointRounding.ToEven));
         AV6newName = GetPar( "newName");
         AV5newCode = GetPar( "newCode");
         AV37newCostPricePercentage = NumberUtil.Val( GetPar( "newCostPricePercentage"), ".");
         AV38newPrice = NumberUtil.Val( GetPar( "newPrice"), ".");
         AV33newPercentage = NumberUtil.Val( GetPar( "newPercentage"), ".");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrAllproducts_refresh( subAllproducts_Rows, AV10Code, AV15Name, AV30Supplier, AV9Brand, AV26Sector, AV6newName, AV5newCode, AV37newCostPricePercentage, AV38newPrice, AV33newPercentage) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrAllproducts_refresh_invoke */
      }

      protected void gxnrCostpricegrid_newrow_invoke( )
      {
         nRC_GXsfl_96 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_96"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_96_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_96_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_96_idx = GetPar( "sGXsfl_96_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrCostpricegrid_newrow( ) ;
         /* End function gxnrCostpricegrid_newrow_invoke */
      }

      protected void gxgrCostpricegrid_refresh_invoke( )
      {
         subAllproducts_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subAllproducts_Rows"), "."), 18, MidpointRounding.ToEven));
         AV10Code = GetPar( "Code");
         AV15Name = GetPar( "Name");
         dynavSupplier.FromJSonString( GetNextPar( ));
         AV30Supplier = (int)(Math.Round(NumberUtil.Val( GetPar( "Supplier"), "."), 18, MidpointRounding.ToEven));
         dynavBrand.FromJSonString( GetNextPar( ));
         AV9Brand = (int)(Math.Round(NumberUtil.Val( GetPar( "Brand"), "."), 18, MidpointRounding.ToEven));
         dynavSector.FromJSonString( GetNextPar( ));
         AV26Sector = (int)(Math.Round(NumberUtil.Val( GetPar( "Sector"), "."), 18, MidpointRounding.ToEven));
         AV6newName = GetPar( "newName");
         AV5newCode = GetPar( "newCode");
         AV37newCostPricePercentage = NumberUtil.Val( GetPar( "newCostPricePercentage"), ".");
         AV38newPrice = NumberUtil.Val( GetPar( "newPrice"), ".");
         AV33newPercentage = NumberUtil.Val( GetPar( "newPercentage"), ".");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrCostpricegrid_refresh( subAllproducts_Rows, AV10Code, AV15Name, AV30Supplier, AV9Brand, AV26Sector, AV6newName, AV5newCode, AV37newCostPricePercentage, AV38newPrice, AV33newPercentage) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrCostpricegrid_refresh_invoke */
      }

      protected void gxnrGrid3_newrow_invoke( )
      {
         nRC_GXsfl_152 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_152"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_152_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_152_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_152_idx = GetPar( "sGXsfl_152_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid3_newrow( ) ;
         /* End function gxnrGrid3_newrow_invoke */
      }

      protected void gxgrGrid3_refresh_invoke( )
      {
         subAllproducts_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subAllproducts_Rows"), "."), 18, MidpointRounding.ToEven));
         AV10Code = GetPar( "Code");
         AV15Name = GetPar( "Name");
         dynavSupplier.FromJSonString( GetNextPar( ));
         AV30Supplier = (int)(Math.Round(NumberUtil.Val( GetPar( "Supplier"), "."), 18, MidpointRounding.ToEven));
         dynavBrand.FromJSonString( GetNextPar( ));
         AV9Brand = (int)(Math.Round(NumberUtil.Val( GetPar( "Brand"), "."), 18, MidpointRounding.ToEven));
         dynavSector.FromJSonString( GetNextPar( ));
         AV26Sector = (int)(Math.Round(NumberUtil.Val( GetPar( "Sector"), "."), 18, MidpointRounding.ToEven));
         AV6newName = GetPar( "newName");
         AV5newCode = GetPar( "newCode");
         AV37newCostPricePercentage = NumberUtil.Val( GetPar( "newCostPricePercentage"), ".");
         AV38newPrice = NumberUtil.Val( GetPar( "newPrice"), ".");
         AV33newPercentage = NumberUtil.Val( GetPar( "newPercentage"), ".");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid3_refresh( subAllproducts_Rows, AV10Code, AV15Name, AV30Supplier, AV9Brand, AV26Sector, AV6newName, AV5newCode, AV37newCostPricePercentage, AV38newPrice, AV33newPercentage) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid3_refresh_invoke */
      }

      protected void gxnrGrid1_newrow_invoke( )
      {
         nRC_GXsfl_205 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_205"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_205_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_205_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_205_idx = GetPar( "sGXsfl_205_idx");
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
         AV10Code = GetPar( "Code");
         AV15Name = GetPar( "Name");
         dynavSupplier.FromJSonString( GetNextPar( ));
         AV30Supplier = (int)(Math.Round(NumberUtil.Val( GetPar( "Supplier"), "."), 18, MidpointRounding.ToEven));
         dynavBrand.FromJSonString( GetNextPar( ));
         AV9Brand = (int)(Math.Round(NumberUtil.Val( GetPar( "Brand"), "."), 18, MidpointRounding.ToEven));
         dynavSector.FromJSonString( GetNextPar( ));
         AV26Sector = (int)(Math.Round(NumberUtil.Val( GetPar( "Sector"), "."), 18, MidpointRounding.ToEven));
         AV6newName = GetPar( "newName");
         AV5newCode = GetPar( "newCode");
         AV37newCostPricePercentage = NumberUtil.Val( GetPar( "newCostPricePercentage"), ".");
         AV38newPrice = NumberUtil.Val( GetPar( "newPrice"), ".");
         AV33newPercentage = NumberUtil.Val( GetPar( "newPercentage"), ".");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subAllproducts_Rows, AV10Code, AV15Name, AV30Supplier, AV9Brand, AV26Sector, AV6newName, AV5newCode, AV37newCostPricePercentage, AV38newPrice, AV33newPercentage) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid1_refresh_invoke */
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
         PA2I2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2I2( ) ;
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
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/BasicTabRender.js", "", false, true);
         context.AddJavascriptSource("Switch/switch.min.js", "", false, true);
         context.AddJavascriptSource("Switch/switch.min.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpupdatepricecopy1.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vNEWNAME", AV6newName);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6newName, "")), context));
         GxWebStd.gx_hidden_field( context, "vNEWCODE", AV5newCode);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV5newCode, "")), context));
         GxWebStd.gx_hidden_field( context, "vNEWCOSTPRICEPERCENTAGE", StringUtil.LTrim( StringUtil.NToC( AV37newCostPricePercentage, 8, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWCOSTPRICEPERCENTAGE", GetSecureSignedToken( "", context.localUtil.Format( AV37newCostPricePercentage, "ZZZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "vNEWPRICE", StringUtil.LTrim( StringUtil.NToC( AV38newPrice, 10, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWPRICE", GetSecureSignedToken( "", context.localUtil.Format( AV38newPrice, "ZZZZZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "vNEWPERCENTAGE", StringUtil.LTrim( StringUtil.NToC( AV33newPercentage, 8, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWPERCENTAGE", GetSecureSignedToken( "", context.localUtil.Format( AV33newPercentage, "ZZZZ9.99"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vCODE", AV10Code);
         GxWebStd.gx_hidden_field( context, "GXH_vNAME", AV15Name);
         GxWebStd.gx_hidden_field( context, "GXH_vSUPPLIER", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30Supplier), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vBRAND", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9Brand), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vSECTOR", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26Sector), 6, 0, ".", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Productsselected", AV22ProductsSelected);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Productsselected", AV22ProductsSelected);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Costpriceproductsselected", AV39CostPriceProductsSelected);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Costpriceproductsselected", AV39CostPriceProductsSelected);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_34", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_34), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_96", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_96), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_152", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_152), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_205", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_205), 8, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vCOSTPRICEROUNDTOP", AV35CostPriceRoundTop);
         GxWebStd.gx_boolean_hidden_field( context, "vROUNDTOP", AV25RoundTop);
         GxWebStd.gx_hidden_field( context, "vNEWNAME", AV6newName);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6newName, "")), context));
         GxWebStd.gx_hidden_field( context, "vNEWCODE", AV5newCode);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV5newCode, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPRODUCTSSELECTED", AV22ProductsSelected);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPRODUCTSSELECTED", AV22ProductsSelected);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSELECTEDID", AV27SelectedId);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSELECTEDID", AV27SelectedId);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPRODUCT", AV21Product);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPRODUCT", AV21Product);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOSTPRICESELECTEDID", AV40CostPriceSelectedId);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOSTPRICESELECTEDID", AV40CostPriceSelectedId);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPRODUCTSSELECTEDAUX", AV23ProductsSelectedAux);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPRODUCTSSELECTEDAUX", AV23ProductsSelectedAux);
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOSTPRICEPRODUCTSSELECTED", AV39CostPriceProductsSelected);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOSTPRICEPRODUCTSSELECTED", AV39CostPriceProductsSelected);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vONEPRODUCT", AV17OneProduct);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vONEPRODUCT", AV17OneProduct);
         }
         GxWebStd.gx_hidden_field( context, "vNEWCOSTPRICEPERCENTAGE", StringUtil.LTrim( StringUtil.NToC( AV37newCostPricePercentage, 8, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWCOSTPRICEPERCENTAGE", GetSecureSignedToken( "", context.localUtil.Format( AV37newCostPricePercentage, "ZZZZ9.99"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vALLOK", AV7AllOk);
         GxWebStd.gx_hidden_field( context, "vNEWPRICE", StringUtil.LTrim( StringUtil.NToC( AV38newPrice, 10, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWPRICE", GetSecureSignedToken( "", context.localUtil.Format( AV38newPrice, "ZZZZZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "vNEWPERCENTAGE", StringUtil.LTrim( StringUtil.NToC( AV33newPercentage, 8, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWPERCENTAGE", GetSecureSignedToken( "", context.localUtil.Format( AV33newPercentage, "ZZZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "vGXV32", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV77GXV32), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGXV33", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV78GXV33), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPRICEROUNDED", StringUtil.LTrim( StringUtil.NToC( AV20PriceRounded, 10, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "vCOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Count), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vDIGIT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Digit), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vI", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13i), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGXV34", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV79GXV34), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ALLPRODUCTS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(ALLPRODUCTS_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ALLPRODUCTS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(ALLPRODUCTS_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COSTPRICEROUNDTOP_Enabled", StringUtil.BoolToStr( Costpriceroundtop_Enabled));
         GxWebStd.gx_hidden_field( context, "COSTPRICEROUNDTOP_Captionclass", StringUtil.RTrim( Costpriceroundtop_Captionclass));
         GxWebStd.gx_hidden_field( context, "COSTPRICEROUNDTOP_Captionstyle", StringUtil.RTrim( Costpriceroundtop_Captionstyle));
         GxWebStd.gx_hidden_field( context, "COSTPRICEROUNDTOP_Captionposition", StringUtil.RTrim( Costpriceroundtop_Captionposition));
         GxWebStd.gx_hidden_field( context, "ROUNDTOP_Enabled", StringUtil.BoolToStr( Roundtop_Enabled));
         GxWebStd.gx_hidden_field( context, "ROUNDTOP_Captionclass", StringUtil.RTrim( Roundtop_Captionclass));
         GxWebStd.gx_hidden_field( context, "ROUNDTOP_Captionstyle", StringUtil.RTrim( Roundtop_Captionstyle));
         GxWebStd.gx_hidden_field( context, "ROUNDTOP_Captionposition", StringUtil.RTrim( Roundtop_Captionposition));
         GxWebStd.gx_hidden_field( context, "ROUNDTOP_Enabled", StringUtil.BoolToStr( Roundtop_Enabled));
         GxWebStd.gx_hidden_field( context, "ROUNDTOP_Captionclass", StringUtil.RTrim( Roundtop_Captionclass));
         GxWebStd.gx_hidden_field( context, "ROUNDTOP_Captionstyle", StringUtil.RTrim( Roundtop_Captionstyle));
         GxWebStd.gx_hidden_field( context, "ROUNDTOP_Captionposition", StringUtil.RTrim( Roundtop_Captionposition));
         GxWebStd.gx_hidden_field( context, "TAB1_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Tab1_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TAB1_Class", StringUtil.RTrim( Tab1_Class));
         GxWebStd.gx_hidden_field( context, "TAB1_Historymanagement", StringUtil.BoolToStr( Tab1_Historymanagement));
         GxWebStd.gx_hidden_field( context, "TAB1_Activepagecontrolname", StringUtil.RTrim( Tab1_Activepagecontrolname));
         GxWebStd.gx_hidden_field( context, "TAB1_Activepagecontrolname", StringUtil.RTrim( Tab1_Activepagecontrolname));
         GxWebStd.gx_hidden_field( context, "TAB1_Activepagecontrolname", StringUtil.RTrim( Tab1_Activepagecontrolname));
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
            WE2I2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2I2( ) ;
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
         return formatLink("wpupdatepricecopy1.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WPUpdatePriceCopy1" ;
      }

      public override string GetPgmdesc( )
      {
         return "WPUpdate Price Copy1" ;
      }

      protected void WB2I0( )
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
            GxWebStd.gx_button_ctrl( context, bttBtnallproducts_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(34), 2, 0)+","+"null"+");", "All Products", bttBtnallproducts_Jsonclick, 5, "All Products", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'ALLPRODUCTS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPUpdatePriceCopy1.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavCode_Internalname, AV10Code, StringUtil.RTrim( context.localUtil.Format( AV10Code, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,13);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCode_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCode_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "GeneXusUnanimo\\Code", "left", true, "", "HLP_WPUpdatePriceCopy1.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavName_Internalname, AV15Name, StringUtil.RTrim( context.localUtil.Format( AV15Name, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,17);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavName_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Name", "left", true, "", "HLP_WPUpdatePriceCopy1.htm");
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
            GxWebStd.gx_combobox_ctrl1( context, dynavSupplier, dynavSupplier_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV30Supplier), 6, 0)), 1, dynavSupplier_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavSupplier.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "", true, 0, "HLP_WPUpdatePriceCopy1.htm");
            dynavSupplier.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30Supplier), 6, 0));
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
            GxWebStd.gx_combobox_ctrl1( context, dynavBrand, dynavBrand_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV9Brand), 6, 0)), 1, dynavBrand_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavBrand.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "", true, 0, "HLP_WPUpdatePriceCopy1.htm");
            dynavBrand.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV9Brand), 6, 0));
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
            GxWebStd.gx_combobox_ctrl1( context, dynavSector, dynavSector_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV26Sector), 6, 0)), 1, dynavSector_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavSector.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "", true, 0, "HLP_WPUpdatePriceCopy1.htm");
            dynavSector.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26Sector), 6, 0));
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
            /* User Defined Control */
            ucTab1.SetProperty("PageCount", Tab1_Pagecount);
            ucTab1.SetProperty("Class", Tab1_Class);
            ucTab1.SetProperty("HistoryManagement", Tab1_Historymanagement);
            ucTab1.Render(context, "basictab", Tab1_Internalname, "TAB1Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TAB1Container"+"title1"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTabpagecostprice_title_Internalname, "Cost Price", "", "", lblTabpagecostprice_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPUpdatePriceCopy1.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "TabPageCostPrice") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TAB1Container"+"panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabpage1table_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable3_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "Bottom", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttUpdatecostprice_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(34), 2, 0)+","+"null"+");", "Update", bttUpdatecostprice_Jsonclick, 5, "Update", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'COSTPRICEUPDATE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPUpdatePriceCopy1.htm");
            GxWebStd.gx_div_end( context, "left", "Bottom", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavCostpricepercentage_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCostpricepercentage_Internalname, "Percentage", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'" + sGXsfl_34_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCostpricepercentage_Internalname, StringUtil.LTrim( StringUtil.NToC( AV34CostPricePercentage, 8, 2, ".", "")), StringUtil.LTrim( ((edtavCostpricepercentage_Enabled!=0) ? context.localUtil.Format( AV34CostPricePercentage, "ZZZZ9.99") : context.localUtil.Format( AV34CostPricePercentage, "ZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,65);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCostpricepercentage_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCostpricepercentage_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "Percentage", "right", false, "", "HLP_WPUpdatePriceCopy1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", -1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+Costpriceroundtop_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, Costpriceroundtop_Internalname, "Round Top", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* User Defined Control */
            ucCostpriceroundtop.SetProperty("Attribute", AV35CostPriceRoundTop);
            ucCostpriceroundtop.SetProperty("CaptionClass", Costpriceroundtop_Captionclass);
            ucCostpriceroundtop.SetProperty("CaptionStyle", Costpriceroundtop_Captionstyle);
            ucCostpriceroundtop.SetProperty("CaptionPosition", Costpriceroundtop_Captionposition);
            ucCostpriceroundtop.Render(context, "sdswitch", Costpriceroundtop_Internalname, "COSTPRICEROUNDTOPContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "Bottom", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCostpricecancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(34), 2, 0)+","+"null"+");", "Cancel", bttCostpricecancel_Jsonclick, 5, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CANCELUPDATE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPUpdatePriceCopy1.htm");
            GxWebStd.gx_div_end( context, "left", "Bottom", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable7_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTb_costpriceproductname_Internalname, "Product", "", "", lblTb_costpriceproductname_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdatePriceCopy1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTb_costpricesupplier_Internalname, "Supplier", "", "", lblTb_costpricesupplier_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdatePriceCopy1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTb_costpricesector_Internalname, "Sector", "", "", lblTb_costpricesector_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdatePriceCopy1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTb_costpricebrand_Internalname, "Brand", "", "", lblTb_costpricebrand_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdatePriceCopy1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1", "Right", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTb_costpriceold_Internalname, "Cost Price", "", "", lblTb_costpriceold_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdatePriceCopy1.htm");
            GxWebStd.gx_div_end( context, "Right", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1", "Right", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTb_costpricenew_Internalname, "New C. P.", "", "", lblTb_costpricenew_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdatePriceCopy1.htm");
            GxWebStd.gx_div_end( context, "Right", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1", "Right", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTb_costpriceretailprice_Internalname, "R. Price", "", "", lblTb_costpriceretailprice_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdatePriceCopy1.htm");
            GxWebStd.gx_div_end( context, "Right", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1", "Right", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTb_costpricewholesaleprice_Internalname, "W. Price", "", "", lblTb_costpricewholesaleprice_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdatePriceCopy1.htm");
            GxWebStd.gx_div_end( context, "Right", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1", "Right", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Action", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPUpdatePriceCopy1.htm");
            GxWebStd.gx_div_end( context, "Right", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            CostpricegridContainer.SetIsFreestyle(true);
            CostpricegridContainer.SetWrapped(nGXWrapped);
            StartGridControl96( ) ;
         }
         if ( wbEnd == 96 )
         {
            wbEnd = 0;
            nRC_GXsfl_96 = (int)(nGXsfl_96_idx-1);
            if ( CostpricegridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV46GXV1 = nGXsfl_96_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"CostpricegridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Costpricegrid", CostpricegridContainer, subCostpricegrid_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "CostpricegridContainerData", CostpricegridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "CostpricegridContainerData"+"V", CostpricegridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"CostpricegridContainerData"+"V"+"\" value='"+CostpricegridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TAB1Container"+"title2"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTabpage2_title_Internalname, "Profit Percentage", "", "", lblTabpage2_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPUpdatePriceCopy1.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "TabPage2") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TAB1Container"+"panel2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabpage2table_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable5_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "Bottom", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 135,'',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttUpdateprice2_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(34), 2, 0)+","+"null"+");", "Update", bttUpdateprice2_Jsonclick, 7, "Update", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e112i1_client"+"'", TempTags, "", 2, "HLP_WPUpdatePriceCopy1.htm");
            GxWebStd.gx_div_end( context, "left", "Bottom", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavRetailprofitpercentage_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRetailprofitpercentage_Internalname, "Retail", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 139,'',false,'" + sGXsfl_34_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRetailprofitpercentage_Internalname, StringUtil.LTrim( StringUtil.NToC( AV31RetailProfitPercentage, 8, 2, ".", "")), StringUtil.LTrim( ((edtavRetailprofitpercentage_Enabled!=0) ? context.localUtil.Format( AV31RetailProfitPercentage, "ZZZZ9.99") : context.localUtil.Format( AV31RetailProfitPercentage, "ZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,139);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRetailprofitpercentage_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavRetailprofitpercentage_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "Percentage", "right", false, "", "HLP_WPUpdatePriceCopy1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavWholesaleprofitpercentage_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavWholesaleprofitpercentage_Internalname, "Wholesale", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 143,'',false,'" + sGXsfl_34_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavWholesaleprofitpercentage_Internalname, StringUtil.LTrim( StringUtil.NToC( AV32WholesaleProfitPercentage, 8, 2, ".", "")), StringUtil.LTrim( ((edtavWholesaleprofitpercentage_Enabled!=0) ? context.localUtil.Format( AV32WholesaleProfitPercentage, "ZZZZ9.99") : context.localUtil.Format( AV32WholesaleProfitPercentage, "ZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,143);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavWholesaleprofitpercentage_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavWholesaleprofitpercentage_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "Percentage", "right", false, "", "HLP_WPUpdatePriceCopy1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", -1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+Roundtop_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, Roundtop_Internalname, "Round Top", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* User Defined Control */
            ucRoundtop.SetProperty("Attribute", AV25RoundTop);
            ucRoundtop.SetProperty("CaptionClass", Roundtop_Captionclass);
            ucRoundtop.SetProperty("CaptionStyle", Roundtop_Captionstyle);
            ucRoundtop.SetProperty("CaptionPosition", Roundtop_Captionposition);
            ucRoundtop.Render(context, "sdswitch", Roundtop_Internalname, "ROUNDTOPContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "Bottom", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 149,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCancelupdate2_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(34), 2, 0)+","+"null"+");", "Cancel", bttCancelupdate2_Jsonclick, 5, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CANCELUPDATE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPUpdatePriceCopy1.htm");
            GxWebStd.gx_div_end( context, "left", "Bottom", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid3Container.SetIsFreestyle(true);
            Grid3Container.SetWrapped(nGXWrapped);
            StartGridControl152( ) ;
         }
         if ( wbEnd == 152 )
         {
            wbEnd = 0;
            nRC_GXsfl_152 = (int)(nGXsfl_152_idx-1);
            if ( Grid3Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV55GXV10 = nGXsfl_152_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid3Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid3", Grid3Container, subGrid3_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid3ContainerData", Grid3Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid3ContainerData"+"V", Grid3Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid3ContainerData"+"V"+"\" value='"+Grid3Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TAB1Container"+"title3"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTabpage3_title_Internalname, "Final Price", "", "", lblTabpage3_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPUpdatePriceCopy1.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "TabPage3") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TAB1Container"+"panel3"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabpage3table_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable6_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "Bottom", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 192,'',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttUpdateprice3_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(34), 2, 0)+","+"null"+");", "Update", bttUpdateprice3_Jsonclick, 7, "Update", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e112i1_client"+"'", TempTags, "", 2, "HLP_WPUpdatePriceCopy1.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 196,'',false,'" + sGXsfl_34_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPercentage_Internalname, StringUtil.LTrim( StringUtil.NToC( AV18Percentage, 6, 2, ".", "")), StringUtil.LTrim( ((edtavPercentage_Enabled!=0) ? context.localUtil.Format( AV18Percentage, "ZZ9.99") : context.localUtil.Format( AV18Percentage, "ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,196);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPercentage_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavPercentage_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_WPUpdatePriceCopy1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* User Defined Control */
            ucRoundtop.SetProperty("Attribute", AV25RoundTop);
            ucRoundtop.SetProperty("CaptionClass", Roundtop_Captionclass);
            ucRoundtop.SetProperty("CaptionStyle", Roundtop_Captionstyle);
            ucRoundtop.SetProperty("CaptionPosition", Roundtop_Captionposition);
            ucRoundtop.Render(context, "sdswitch", Roundtop_Internalname, "ROUNDTOPContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "Bottom", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 202,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCancelupdate3_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(34), 2, 0)+","+"null"+");", "Cancel", bttCancelupdate3_Jsonclick, 5, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CANCELUPDATE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPUpdatePriceCopy1.htm");
            GxWebStd.gx_div_end( context, "left", "Bottom", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetIsFreestyle(true);
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl205( ) ;
         }
         if ( wbEnd == 205 )
         {
            wbEnd = 0;
            nRC_GXsfl_205 = (int)(nGXsfl_205_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV65GXV20 = nGXsfl_205_idx;
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
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
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
         if ( wbEnd == 96 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( CostpricegridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV46GXV1 = nGXsfl_96_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"CostpricegridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Costpricegrid", CostpricegridContainer, subCostpricegrid_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "CostpricegridContainerData", CostpricegridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "CostpricegridContainerData"+"V", CostpricegridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"CostpricegridContainerData"+"V"+"\" value='"+CostpricegridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         if ( wbEnd == 152 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid3Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV55GXV10 = nGXsfl_152_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid3Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid3", Grid3Container, subGrid3_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid3ContainerData", Grid3Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid3ContainerData"+"V", Grid3Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid3ContainerData"+"V"+"\" value='"+Grid3Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         if ( wbEnd == 205 )
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
                  AV65GXV20 = nGXsfl_205_idx;
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
         wbLoad = true;
      }

      protected void START2I2( )
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
            Form.Meta.addItem("description", "WPUpdate Price Copy1", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2I0( ) ;
      }

      protected void WS2I2( )
      {
         START2I2( ) ;
         EVT2I2( ) ;
      }

      protected void EVT2I2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "VCOSTPRICEROUNDTOP.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E122I2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CANCELUPDATE'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'CancelUpdate' */
                              E132I2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ALLPRODUCTS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AllProducts' */
                              E142I2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'COSTPRICEUPDATE'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'CostPriceUpdate' */
                              E152I2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'COSTPRICEREMOVE'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'CostPriceRemove' */
                              E162I2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "'COSTPRICEREMOVE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "COSTPRICEGRID.LOAD") == 0 ) )
                           {
                              nGXsfl_96_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_96_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_96_idx), 4, 0), 4, "0");
                              SubsflControlProps_965( ) ;
                              AV46GXV1 = nGXsfl_96_idx;
                              if ( ( AV39CostPriceProductsSelected.Count >= AV46GXV1 ) && ( AV46GXV1 > 0 ) )
                              {
                                 AV39CostPriceProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV39CostPriceProductsSelected.Item(AV46GXV1));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "'COSTPRICEREMOVE'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'CostPriceRemove' */
                                    E162I2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "COSTPRICEGRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E172I5 ();
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
                           else if ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRID3.LOAD") == 0 )
                           {
                              nGXsfl_152_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_152_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_152_idx), 4, 0), 4, "0");
                              SubsflControlProps_1524( ) ;
                              AV55GXV10 = nGXsfl_152_idx;
                              if ( ( AV22ProductsSelected.Count >= AV55GXV10 ) && ( AV55GXV10 > 0 ) )
                              {
                                 AV22ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV55GXV10));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "GRID3.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E182I4 ();
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
                           else if ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRID1.LOAD") == 0 )
                           {
                              nGXsfl_205_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_205_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_205_idx), 4, 0), 4, "0");
                              SubsflControlProps_2053( ) ;
                              AV65GXV20 = nGXsfl_205_idx;
                              if ( ( AV22ProductsSelected.Count >= AV65GXV20 ) && ( AV65GXV20 > 0 ) )
                              {
                                 AV22ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV65GXV20));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "GRID1.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E192I3 ();
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
                           else if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 8), "'REMOVE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "PRODUCTNAME.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "'COSTPRICECANCEL'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 16), "ALLPRODUCTS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "PRODUCTNAME.CLICK") == 0 ) )
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
                              A85ProductCostPrice = context.localUtil.CToN( cgiGet( edtProductCostPrice_Internalname), ".", ",");
                              A89ProductRetailProfit = context.localUtil.CToN( cgiGet( edtProductRetailProfit_Internalname), ".", ",");
                              n89ProductRetailProfit = false;
                              A90ProductRetailPrice = context.localUtil.CToN( cgiGet( edtProductRetailPrice_Internalname), ".", ",");
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
                                    E202I2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'REMOVE'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'Remove' */
                                    E212I2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "PRODUCTNAME.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E222I2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'COSTPRICECANCEL'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'CostPriceCancel' */
                                    E232I2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ALLPRODUCTS.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E242I2 ();
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
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vNAME"), AV15Name) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Supplier Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vSUPPLIER"), ".", ",") != Convert.ToDecimal( AV30Supplier )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Brand Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vBRAND"), ".", ",") != Convert.ToDecimal( AV9Brand )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Sector Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vSECTOR"), ".", ",") != Convert.ToDecimal( AV26Sector )) )
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

      protected void WE2I2( )
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

      protected void PA2I2( )
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

      protected void GXDLVvSUPPLIER2I2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvSUPPLIER_data2I2( ) ;
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

      protected void GXVvSUPPLIER_html2I2( )
      {
         int gxdynajaxvalue;
         GXDLVvSUPPLIER_data2I2( ) ;
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

      protected void GXDLVvSUPPLIER_data2I2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(None)");
         /* Using cursor H002I2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H002I2_A4SupplierId[0]), 6, 0, ".", "")));
            gxdynajaxctrldescr.Add(H002I2_A5SupplierName[0]);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void GXDLVvBRAND2I2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvBRAND_data2I2( ) ;
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

      protected void GXVvBRAND_html2I2( )
      {
         int gxdynajaxvalue;
         GXDLVvBRAND_data2I2( ) ;
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

      protected void GXDLVvBRAND_data2I2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(None)");
         /* Using cursor H002I3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H002I3_A1BrandId[0]), 6, 0, ".", "")));
            gxdynajaxctrldescr.Add(H002I3_A2BrandName[0]);
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void GXDLVvSECTOR2I2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvSECTOR_data2I2( ) ;
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

      protected void GXVvSECTOR_html2I2( )
      {
         int gxdynajaxvalue;
         GXDLVvSECTOR_data2I2( ) ;
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

      protected void GXDLVvSECTOR_data2I2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(None)");
         /* Using cursor H002I4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H002I4_A9SectorId[0]), 6, 0, ".", "")));
            gxdynajaxctrldescr.Add(H002I4_A10SectorName[0]);
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

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_2053( ) ;
         while ( nGXsfl_205_idx <= nRC_GXsfl_205 )
         {
            sendrow_2053( ) ;
            nGXsfl_205_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_205_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_205_idx+1);
            sGXsfl_205_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_205_idx), 4, 0), 4, "0");
            SubsflControlProps_2053( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxnrGrid3_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1524( ) ;
         while ( nGXsfl_152_idx <= nRC_GXsfl_152 )
         {
            sendrow_1524( ) ;
            nGXsfl_152_idx = ((subGrid3_Islastpage==1)&&(nGXsfl_152_idx+1>subGrid3_fnc_Recordsperpage( )) ? 1 : nGXsfl_152_idx+1);
            sGXsfl_152_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_152_idx), 4, 0), 4, "0");
            SubsflControlProps_1524( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid3Container)) ;
         /* End function gxnrGrid3_newrow */
      }

      protected void gxnrCostpricegrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_965( ) ;
         while ( nGXsfl_96_idx <= nRC_GXsfl_96 )
         {
            sendrow_965( ) ;
            nGXsfl_96_idx = ((subCostpricegrid_Islastpage==1)&&(nGXsfl_96_idx+1>subCostpricegrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_96_idx+1);
            sGXsfl_96_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_96_idx), 4, 0), 4, "0");
            SubsflControlProps_965( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( CostpricegridContainer)) ;
         /* End function gxnrCostpricegrid_newrow */
      }

      protected void gxgrAllproducts_refresh( int subAllproducts_Rows ,
                                              string AV10Code ,
                                              string AV15Name ,
                                              int AV30Supplier ,
                                              int AV9Brand ,
                                              int AV26Sector ,
                                              string AV6newName ,
                                              string AV5newCode ,
                                              decimal AV37newCostPricePercentage ,
                                              decimal AV38newPrice ,
                                              decimal AV33newPercentage )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         ALLPRODUCTS_nCurrentRecord = 0;
         RF2I2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrAllproducts_refresh */
      }

      protected void gxgrCostpricegrid_refresh( int subAllproducts_Rows ,
                                                string AV10Code ,
                                                string AV15Name ,
                                                int AV30Supplier ,
                                                int AV9Brand ,
                                                int AV26Sector ,
                                                string AV6newName ,
                                                string AV5newCode ,
                                                decimal AV37newCostPricePercentage ,
                                                decimal AV38newPrice ,
                                                decimal AV33newPercentage )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         COSTPRICEGRID_nCurrentRecord = 0;
         RF2I5( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrCostpricegrid_refresh */
      }

      protected void gxgrGrid3_refresh( int subAllproducts_Rows ,
                                        string AV10Code ,
                                        string AV15Name ,
                                        int AV30Supplier ,
                                        int AV9Brand ,
                                        int AV26Sector ,
                                        string AV6newName ,
                                        string AV5newCode ,
                                        decimal AV37newCostPricePercentage ,
                                        decimal AV38newPrice ,
                                        decimal AV33newPercentage )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID3_nCurrentRecord = 0;
         RF2I4( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid3_refresh */
      }

      protected void gxgrGrid1_refresh( int subAllproducts_Rows ,
                                        string AV10Code ,
                                        string AV15Name ,
                                        int AV30Supplier ,
                                        int AV9Brand ,
                                        int AV26Sector ,
                                        string AV6newName ,
                                        string AV5newCode ,
                                        decimal AV37newCostPricePercentage ,
                                        decimal AV38newPrice ,
                                        decimal AV33newPercentage )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF2I3( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUCTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A15ProductId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "PRODUCTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUCTNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A16ProductName, "")), context));
         GxWebStd.gx_hidden_field( context, "PRODUCTNAME", A16ProductName);
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUCTCOSTPRICE", GetSecureSignedToken( "", context.localUtil.Format( A85ProductCostPrice, "ZZZZZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "PRODUCTCOSTPRICE", StringUtil.LTrim( StringUtil.NToC( A85ProductCostPrice, 10, 2, ".", "")));
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXVvSUPPLIER_html2I2( ) ;
            GXVvBRAND_html2I2( ) ;
            GXVvSECTOR_html2I2( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavSupplier.ItemCount > 0 )
         {
            AV30Supplier = (int)(Math.Round(NumberUtil.Val( dynavSupplier.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV30Supplier), 6, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV30Supplier", StringUtil.LTrimStr( (decimal)(AV30Supplier), 6, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavSupplier.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30Supplier), 6, 0));
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
            AV26Sector = (int)(Math.Round(NumberUtil.Val( dynavSector.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV26Sector), 6, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV26Sector", StringUtil.LTrimStr( (decimal)(AV26Sector), 6, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavSector.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26Sector), 6, 0));
            AssignProp("", false, dynavSector_Internalname, "Values", dynavSector.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF2I2( ) ;
         RF2I5( ) ;
         RF2I4( ) ;
         RF2I3( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavCtlname_Enabled = 0;
         AssignProp("", false, edtavCtlname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname_Enabled), 5, 0), !bGXsfl_96_Refreshing);
         edtavCtlsupplier_Enabled = 0;
         AssignProp("", false, edtavCtlsupplier_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsupplier_Enabled), 5, 0), !bGXsfl_96_Refreshing);
         edtavCtlsector_Enabled = 0;
         AssignProp("", false, edtavCtlsector_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsector_Enabled), 5, 0), !bGXsfl_96_Refreshing);
         edtavCtlbrand_Enabled = 0;
         AssignProp("", false, edtavCtlbrand_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlbrand_Enabled), 5, 0), !bGXsfl_96_Refreshing);
         edtavCtlcostprice_Enabled = 0;
         AssignProp("", false, edtavCtlcostprice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcostprice_Enabled), 5, 0), !bGXsfl_96_Refreshing);
         edtavCtlretailprice_Enabled = 0;
         AssignProp("", false, edtavCtlretailprice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlretailprice_Enabled), 5, 0), !bGXsfl_96_Refreshing);
         edtavCtlwholesaleprice_Enabled = 0;
         AssignProp("", false, edtavCtlwholesaleprice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlwholesaleprice_Enabled), 5, 0), !bGXsfl_96_Refreshing);
         edtavCtlname2_Enabled = 0;
         AssignProp("", false, edtavCtlname2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname2_Enabled), 5, 0), !bGXsfl_152_Refreshing);
         edtavCtlsector1_Enabled = 0;
         AssignProp("", false, edtavCtlsector1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsector1_Enabled), 5, 0), !bGXsfl_152_Refreshing);
         edtavCtlsupplier1_Enabled = 0;
         AssignProp("", false, edtavCtlsupplier1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsupplier1_Enabled), 5, 0), !bGXsfl_152_Refreshing);
         edtavCtlbrand1_Enabled = 0;
         AssignProp("", false, edtavCtlbrand1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlbrand1_Enabled), 5, 0), !bGXsfl_152_Refreshing);
         edtavCtlcostprice1_Enabled = 0;
         AssignProp("", false, edtavCtlcostprice1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcostprice1_Enabled), 5, 0), !bGXsfl_152_Refreshing);
         edtavCtlretailprice1_Enabled = 0;
         AssignProp("", false, edtavCtlretailprice1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlretailprice1_Enabled), 5, 0), !bGXsfl_152_Refreshing);
         edtavCtlwholesaleprice1_Enabled = 0;
         AssignProp("", false, edtavCtlwholesaleprice1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlwholesaleprice1_Enabled), 5, 0), !bGXsfl_152_Refreshing);
         edtavCtlname3_Enabled = 0;
         AssignProp("", false, edtavCtlname3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname3_Enabled), 5, 0), !bGXsfl_205_Refreshing);
         edtavCtlsector2_Enabled = 0;
         AssignProp("", false, edtavCtlsector2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsector2_Enabled), 5, 0), !bGXsfl_205_Refreshing);
         edtavCtlsupplier2_Enabled = 0;
         AssignProp("", false, edtavCtlsupplier2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsupplier2_Enabled), 5, 0), !bGXsfl_205_Refreshing);
         edtavCtlbrand2_Enabled = 0;
         AssignProp("", false, edtavCtlbrand2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlbrand2_Enabled), 5, 0), !bGXsfl_205_Refreshing);
         edtavCtlcostprice2_Enabled = 0;
         AssignProp("", false, edtavCtlcostprice2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcostprice2_Enabled), 5, 0), !bGXsfl_205_Refreshing);
         edtavCtlretailprofit1_Enabled = 0;
         AssignProp("", false, edtavCtlretailprofit1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlretailprofit1_Enabled), 5, 0), !bGXsfl_205_Refreshing);
         edtavCtlwholesaleprofit1_Enabled = 0;
         AssignProp("", false, edtavCtlwholesaleprofit1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlwholesaleprofit1_Enabled), 5, 0), !bGXsfl_205_Refreshing);
      }

      protected void RF2I2( )
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
                                                 AV15Name ,
                                                 AV30Supplier ,
                                                 AV9Brand ,
                                                 AV26Sector ,
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
            lV15Name = StringUtil.Concat( StringUtil.RTrim( AV15Name), "%", "");
            /* Using cursor H002I5 */
            pr_default.execute(3, new Object[] {lV10Code, lV15Name, AV30Supplier, AV9Brand, AV26Sector, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_34_idx = 1;
            sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
            SubsflControlProps_342( ) ;
            while ( ( (pr_default.getStatus(3) != 101) ) && ( ( ALLPRODUCTS_nCurrentRecord < subAllproducts_fnc_Recordsperpage( ) ) ) )
            {
               A9SectorId = H002I5_A9SectorId[0];
               A1BrandId = H002I5_A1BrandId[0];
               A4SupplierId = H002I5_A4SupplierId[0];
               A55ProductCode = H002I5_A55ProductCode[0];
               n55ProductCode = H002I5_n55ProductCode[0];
               A18ProductPrice = H002I5_A18ProductPrice[0];
               A10SectorName = H002I5_A10SectorName[0];
               A2BrandName = H002I5_A2BrandName[0];
               A5SupplierName = H002I5_A5SupplierName[0];
               A16ProductName = H002I5_A16ProductName[0];
               A15ProductId = H002I5_A15ProductId[0];
               A89ProductRetailProfit = H002I5_A89ProductRetailProfit[0];
               n89ProductRetailProfit = H002I5_n89ProductRetailProfit[0];
               A87ProductWholesaleProfit = H002I5_A87ProductWholesaleProfit[0];
               n87ProductWholesaleProfit = H002I5_n87ProductWholesaleProfit[0];
               A85ProductCostPrice = H002I5_A85ProductCostPrice[0];
               A10SectorName = H002I5_A10SectorName[0];
               A2BrandName = H002I5_A2BrandName[0];
               A5SupplierName = H002I5_A5SupplierName[0];
               GXt_decimal1 = A90ProductRetailPrice;
               new roundvalue(context ).execute(  A85ProductCostPrice*(1+A89ProductRetailProfit/ (decimal)(100)), out  GXt_decimal1) ;
               A90ProductRetailPrice = GXt_decimal1;
               GXt_decimal1 = A88ProductWholesalePrice;
               new roundvalue(context ).execute(  A85ProductCostPrice*(1+A87ProductWholesaleProfit/ (decimal)(100)), out  GXt_decimal1) ;
               A88ProductWholesalePrice = GXt_decimal1;
               E242I2 ();
               pr_default.readNext(3);
            }
            ALLPRODUCTS_nEOF = (short)(((pr_default.getStatus(3) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "ALLPRODUCTS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(ALLPRODUCTS_nEOF), 1, 0, ".", "")));
            pr_default.close(3);
            wbEnd = 34;
            WB2I0( ) ;
         }
         bGXsfl_34_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2I2( )
      {
         GxWebStd.gx_hidden_field( context, "vNEWNAME", AV6newName);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6newName, "")), context));
         GxWebStd.gx_hidden_field( context, "vNEWCODE", AV5newCode);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV5newCode, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUCTID"+"_"+sGXsfl_34_idx, GetSecureSignedToken( sGXsfl_34_idx, context.localUtil.Format( (decimal)(A15ProductId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUCTNAME"+"_"+sGXsfl_34_idx, GetSecureSignedToken( sGXsfl_34_idx, StringUtil.RTrim( context.localUtil.Format( A16ProductName, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUCTCOSTPRICE"+"_"+sGXsfl_34_idx, GetSecureSignedToken( sGXsfl_34_idx, context.localUtil.Format( A85ProductCostPrice, "ZZZZZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "vNEWCOSTPRICEPERCENTAGE", StringUtil.LTrim( StringUtil.NToC( AV37newCostPricePercentage, 8, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWCOSTPRICEPERCENTAGE", GetSecureSignedToken( "", context.localUtil.Format( AV37newCostPricePercentage, "ZZZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "vNEWPRICE", StringUtil.LTrim( StringUtil.NToC( AV38newPrice, 10, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWPRICE", GetSecureSignedToken( "", context.localUtil.Format( AV38newPrice, "ZZZZZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "vNEWPERCENTAGE", StringUtil.LTrim( StringUtil.NToC( AV33newPercentage, 8, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWPERCENTAGE", GetSecureSignedToken( "", context.localUtil.Format( AV33newPercentage, "ZZZZ9.99"), context));
      }

      protected void RF2I3( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 205;
         nGXsfl_205_idx = 1;
         sGXsfl_205_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_205_idx), 4, 0), 4, "0");
         SubsflControlProps_2053( ) ;
         bGXsfl_205_Refreshing = true;
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
            SubsflControlProps_2053( ) ;
            E192I3 ();
            wbEnd = 205;
            WB2I0( ) ;
         }
         bGXsfl_205_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2I3( )
      {
      }

      protected void RF2I4( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid3Container.ClearRows();
         }
         wbStart = 152;
         nGXsfl_152_idx = 1;
         sGXsfl_152_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_152_idx), 4, 0), 4, "0");
         SubsflControlProps_1524( ) ;
         bGXsfl_152_Refreshing = true;
         Grid3Container.AddObjectProperty("GridName", "Grid3");
         Grid3Container.AddObjectProperty("CmpContext", "");
         Grid3Container.AddObjectProperty("InMasterPage", "false");
         Grid3Container.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         Grid3Container.AddObjectProperty("Class", "FreeStyleGrid");
         Grid3Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid3Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid3Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid3_Backcolorstyle), 1, 0, ".", "")));
         Grid3Container.PageSize = subGrid3_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1524( ) ;
            E182I4 ();
            wbEnd = 152;
            WB2I0( ) ;
         }
         bGXsfl_152_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2I4( )
      {
      }

      protected void RF2I5( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            CostpricegridContainer.ClearRows();
         }
         wbStart = 96;
         nGXsfl_96_idx = 1;
         sGXsfl_96_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_96_idx), 4, 0), 4, "0");
         SubsflControlProps_965( ) ;
         bGXsfl_96_Refreshing = true;
         CostpricegridContainer.AddObjectProperty("GridName", "Costpricegrid");
         CostpricegridContainer.AddObjectProperty("CmpContext", "");
         CostpricegridContainer.AddObjectProperty("InMasterPage", "false");
         CostpricegridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         CostpricegridContainer.AddObjectProperty("Class", "FreeStyleGrid");
         CostpricegridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         CostpricegridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         CostpricegridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subCostpricegrid_Backcolorstyle), 1, 0, ".", "")));
         CostpricegridContainer.PageSize = subCostpricegrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_965( ) ;
            E172I5 ();
            wbEnd = 96;
            WB2I0( ) ;
         }
         bGXsfl_96_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2I5( )
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
                                              AV15Name ,
                                              AV30Supplier ,
                                              AV9Brand ,
                                              AV26Sector ,
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
         lV15Name = StringUtil.Concat( StringUtil.RTrim( AV15Name), "%", "");
         /* Using cursor H002I6 */
         pr_default.execute(4, new Object[] {lV10Code, lV15Name, AV30Supplier, AV9Brand, AV26Sector});
         ALLPRODUCTS_nRecordCount = H002I6_AALLPRODUCTS_nRecordCount[0];
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
            gxgrAllproducts_refresh( subAllproducts_Rows, AV10Code, AV15Name, AV30Supplier, AV9Brand, AV26Sector, AV6newName, AV5newCode, AV37newCostPricePercentage, AV38newPrice, AV33newPercentage) ;
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
            gxgrAllproducts_refresh( subAllproducts_Rows, AV10Code, AV15Name, AV30Supplier, AV9Brand, AV26Sector, AV6newName, AV5newCode, AV37newCostPricePercentage, AV38newPrice, AV33newPercentage) ;
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
            gxgrAllproducts_refresh( subAllproducts_Rows, AV10Code, AV15Name, AV30Supplier, AV9Brand, AV26Sector, AV6newName, AV5newCode, AV37newCostPricePercentage, AV38newPrice, AV33newPercentage) ;
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
            gxgrAllproducts_refresh( subAllproducts_Rows, AV10Code, AV15Name, AV30Supplier, AV9Brand, AV26Sector, AV6newName, AV5newCode, AV37newCostPricePercentage, AV38newPrice, AV33newPercentage) ;
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
            gxgrAllproducts_refresh( subAllproducts_Rows, AV10Code, AV15Name, AV30Supplier, AV9Brand, AV26Sector, AV6newName, AV5newCode, AV37newCostPricePercentage, AV38newPrice, AV33newPercentage) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
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

      protected int subGrid3_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid3_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid3_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGrid3_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected int subCostpricegrid_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subCostpricegrid_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subCostpricegrid_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subCostpricegrid_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavCtlname_Enabled = 0;
         AssignProp("", false, edtavCtlname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname_Enabled), 5, 0), !bGXsfl_96_Refreshing);
         edtavCtlsupplier_Enabled = 0;
         AssignProp("", false, edtavCtlsupplier_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsupplier_Enabled), 5, 0), !bGXsfl_96_Refreshing);
         edtavCtlsector_Enabled = 0;
         AssignProp("", false, edtavCtlsector_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsector_Enabled), 5, 0), !bGXsfl_96_Refreshing);
         edtavCtlbrand_Enabled = 0;
         AssignProp("", false, edtavCtlbrand_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlbrand_Enabled), 5, 0), !bGXsfl_96_Refreshing);
         edtavCtlcostprice_Enabled = 0;
         AssignProp("", false, edtavCtlcostprice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcostprice_Enabled), 5, 0), !bGXsfl_96_Refreshing);
         edtavCtlretailprice_Enabled = 0;
         AssignProp("", false, edtavCtlretailprice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlretailprice_Enabled), 5, 0), !bGXsfl_96_Refreshing);
         edtavCtlwholesaleprice_Enabled = 0;
         AssignProp("", false, edtavCtlwholesaleprice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlwholesaleprice_Enabled), 5, 0), !bGXsfl_96_Refreshing);
         edtavCtlname2_Enabled = 0;
         AssignProp("", false, edtavCtlname2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname2_Enabled), 5, 0), !bGXsfl_152_Refreshing);
         edtavCtlsector1_Enabled = 0;
         AssignProp("", false, edtavCtlsector1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsector1_Enabled), 5, 0), !bGXsfl_152_Refreshing);
         edtavCtlsupplier1_Enabled = 0;
         AssignProp("", false, edtavCtlsupplier1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsupplier1_Enabled), 5, 0), !bGXsfl_152_Refreshing);
         edtavCtlbrand1_Enabled = 0;
         AssignProp("", false, edtavCtlbrand1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlbrand1_Enabled), 5, 0), !bGXsfl_152_Refreshing);
         edtavCtlcostprice1_Enabled = 0;
         AssignProp("", false, edtavCtlcostprice1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcostprice1_Enabled), 5, 0), !bGXsfl_152_Refreshing);
         edtavCtlretailprice1_Enabled = 0;
         AssignProp("", false, edtavCtlretailprice1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlretailprice1_Enabled), 5, 0), !bGXsfl_152_Refreshing);
         edtavCtlwholesaleprice1_Enabled = 0;
         AssignProp("", false, edtavCtlwholesaleprice1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlwholesaleprice1_Enabled), 5, 0), !bGXsfl_152_Refreshing);
         edtavCtlname3_Enabled = 0;
         AssignProp("", false, edtavCtlname3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname3_Enabled), 5, 0), !bGXsfl_205_Refreshing);
         edtavCtlsector2_Enabled = 0;
         AssignProp("", false, edtavCtlsector2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsector2_Enabled), 5, 0), !bGXsfl_205_Refreshing);
         edtavCtlsupplier2_Enabled = 0;
         AssignProp("", false, edtavCtlsupplier2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsupplier2_Enabled), 5, 0), !bGXsfl_205_Refreshing);
         edtavCtlbrand2_Enabled = 0;
         AssignProp("", false, edtavCtlbrand2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlbrand2_Enabled), 5, 0), !bGXsfl_205_Refreshing);
         edtavCtlcostprice2_Enabled = 0;
         AssignProp("", false, edtavCtlcostprice2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcostprice2_Enabled), 5, 0), !bGXsfl_205_Refreshing);
         edtavCtlretailprofit1_Enabled = 0;
         AssignProp("", false, edtavCtlretailprofit1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlretailprofit1_Enabled), 5, 0), !bGXsfl_205_Refreshing);
         edtavCtlwholesaleprofit1_Enabled = 0;
         AssignProp("", false, edtavCtlwholesaleprofit1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlwholesaleprofit1_Enabled), 5, 0), !bGXsfl_205_Refreshing);
         GXVvSUPPLIER_html2I2( ) ;
         GXVvBRAND_html2I2( ) ;
         GXVvSECTOR_html2I2( ) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2I0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E202I2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Productsselected"), AV22ProductsSelected);
            ajax_req_read_hidden_sdt(cgiGet( "Costpriceproductsselected"), AV39CostPriceProductsSelected);
            ajax_req_read_hidden_sdt(cgiGet( "vPRODUCTSSELECTED"), AV22ProductsSelected);
            ajax_req_read_hidden_sdt(cgiGet( "vONEPRODUCT"), AV17OneProduct);
            ajax_req_read_hidden_sdt(cgiGet( "vCOSTPRICEPRODUCTSSELECTED"), AV39CostPriceProductsSelected);
            /* Read saved values. */
            nRC_GXsfl_34 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_34"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_96 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_96"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_152 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_152"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_205 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_205"), ".", ","), 18, MidpointRounding.ToEven));
            AV35CostPriceRoundTop = StringUtil.StrToBool( cgiGet( "vCOSTPRICEROUNDTOP"));
            AV25RoundTop = StringUtil.StrToBool( cgiGet( "vROUNDTOP"));
            AV77GXV32 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vGXV32"), ".", ","), 18, MidpointRounding.ToEven));
            AV78GXV33 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vGXV33"), ".", ","), 18, MidpointRounding.ToEven));
            AV20PriceRounded = context.localUtil.CToN( cgiGet( "vPRICEROUNDED"), ".", ",");
            AV11Count = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vCOUNT"), ".", ","), 18, MidpointRounding.ToEven));
            AV12Digit = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vDIGIT"), ".", ","), 18, MidpointRounding.ToEven));
            AV13i = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vI"), ".", ","), 18, MidpointRounding.ToEven));
            AV79GXV34 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vGXV34"), ".", ","), 18, MidpointRounding.ToEven));
            ALLPRODUCTS_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "ALLPRODUCTS_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            ALLPRODUCTS_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "ALLPRODUCTS_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            Costpriceroundtop_Enabled = StringUtil.StrToBool( cgiGet( "COSTPRICEROUNDTOP_Enabled"));
            Costpriceroundtop_Captionclass = cgiGet( "COSTPRICEROUNDTOP_Captionclass");
            Costpriceroundtop_Captionstyle = cgiGet( "COSTPRICEROUNDTOP_Captionstyle");
            Costpriceroundtop_Captionposition = cgiGet( "COSTPRICEROUNDTOP_Captionposition");
            Roundtop_Enabled = StringUtil.StrToBool( cgiGet( "ROUNDTOP_Enabled"));
            Roundtop_Captionclass = cgiGet( "ROUNDTOP_Captionclass");
            Roundtop_Captionstyle = cgiGet( "ROUNDTOP_Captionstyle");
            Roundtop_Captionposition = cgiGet( "ROUNDTOP_Captionposition");
            Roundtop_Enabled = StringUtil.StrToBool( cgiGet( "ROUNDTOP_Enabled"));
            Roundtop_Captionclass = cgiGet( "ROUNDTOP_Captionclass");
            Roundtop_Captionstyle = cgiGet( "ROUNDTOP_Captionstyle");
            Roundtop_Captionposition = cgiGet( "ROUNDTOP_Captionposition");
            Tab1_Pagecount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "TAB1_Pagecount"), ".", ","), 18, MidpointRounding.ToEven));
            Tab1_Class = cgiGet( "TAB1_Class");
            Tab1_Historymanagement = StringUtil.StrToBool( cgiGet( "TAB1_Historymanagement"));
            Tab1_Activepagecontrolname = cgiGet( "TAB1_Activepagecontrolname");
            Tab1_Activepagecontrolname = cgiGet( "TAB1_Activepagecontrolname");
            nRC_GXsfl_96 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_96"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_96_fel_idx = 0;
            while ( nGXsfl_96_fel_idx < nRC_GXsfl_96 )
            {
               nGXsfl_96_fel_idx = ((subCostpricegrid_Islastpage==1)&&(nGXsfl_96_fel_idx+1>subCostpricegrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_96_fel_idx+1);
               sGXsfl_96_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_96_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_965( ) ;
               AV46GXV1 = nGXsfl_96_fel_idx;
               if ( ( AV39CostPriceProductsSelected.Count >= AV46GXV1 ) && ( AV46GXV1 > 0 ) )
               {
                  AV39CostPriceProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV39CostPriceProductsSelected.Item(AV46GXV1));
               }
            }
            if ( nGXsfl_96_fel_idx == 0 )
            {
               nGXsfl_96_idx = 1;
               sGXsfl_96_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_96_idx), 4, 0), 4, "0");
               SubsflControlProps_965( ) ;
            }
            nGXsfl_96_fel_idx = 1;
            nRC_GXsfl_152 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_152"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_152_fel_idx = 0;
            while ( nGXsfl_152_fel_idx < nRC_GXsfl_152 )
            {
               nGXsfl_152_fel_idx = ((subGrid3_Islastpage==1)&&(nGXsfl_152_fel_idx+1>subGrid3_fnc_Recordsperpage( )) ? 1 : nGXsfl_152_fel_idx+1);
               sGXsfl_152_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_152_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_1524( ) ;
               AV55GXV10 = nGXsfl_152_fel_idx;
               if ( ( AV22ProductsSelected.Count >= AV55GXV10 ) && ( AV55GXV10 > 0 ) )
               {
                  AV22ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV55GXV10));
               }
            }
            if ( nGXsfl_152_fel_idx == 0 )
            {
               nGXsfl_152_idx = 1;
               sGXsfl_152_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_152_idx), 4, 0), 4, "0");
               SubsflControlProps_1524( ) ;
            }
            nGXsfl_152_fel_idx = 1;
            nRC_GXsfl_205 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_205"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_205_fel_idx = 0;
            while ( nGXsfl_205_fel_idx < nRC_GXsfl_205 )
            {
               nGXsfl_205_fel_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_205_fel_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_205_fel_idx+1);
               sGXsfl_205_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_205_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_2053( ) ;
               AV65GXV20 = nGXsfl_205_fel_idx;
               if ( ( AV22ProductsSelected.Count >= AV65GXV20 ) && ( AV65GXV20 > 0 ) )
               {
                  AV22ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV65GXV20));
               }
            }
            if ( nGXsfl_205_fel_idx == 0 )
            {
               nGXsfl_205_idx = 1;
               sGXsfl_205_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_205_idx), 4, 0), 4, "0");
               SubsflControlProps_2053( ) ;
            }
            nGXsfl_205_fel_idx = 1;
            /* Read variables values. */
            AV10Code = cgiGet( edtavCode_Internalname);
            AssignAttri("", false, "AV10Code", AV10Code);
            AV15Name = cgiGet( edtavName_Internalname);
            AssignAttri("", false, "AV15Name", AV15Name);
            dynavSupplier.Name = dynavSupplier_Internalname;
            dynavSupplier.CurrentValue = cgiGet( dynavSupplier_Internalname);
            AV30Supplier = (int)(Math.Round(NumberUtil.Val( cgiGet( dynavSupplier_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV30Supplier", StringUtil.LTrimStr( (decimal)(AV30Supplier), 6, 0));
            dynavBrand.Name = dynavBrand_Internalname;
            dynavBrand.CurrentValue = cgiGet( dynavBrand_Internalname);
            AV9Brand = (int)(Math.Round(NumberUtil.Val( cgiGet( dynavBrand_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV9Brand", StringUtil.LTrimStr( (decimal)(AV9Brand), 6, 0));
            dynavSector.Name = dynavSector_Internalname;
            dynavSector.CurrentValue = cgiGet( dynavSector_Internalname);
            AV26Sector = (int)(Math.Round(NumberUtil.Val( cgiGet( dynavSector_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV26Sector", StringUtil.LTrimStr( (decimal)(AV26Sector), 6, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCostpricepercentage_Internalname), ".", ",") < -9999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavCostpricepercentage_Internalname), ".", ",") > 99999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCOSTPRICEPERCENTAGE");
               GX_FocusControl = edtavCostpricepercentage_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV34CostPricePercentage = 0;
               AssignAttri("", false, "AV34CostPricePercentage", StringUtil.LTrimStr( AV34CostPricePercentage, 8, 2));
            }
            else
            {
               AV34CostPricePercentage = context.localUtil.CToN( cgiGet( edtavCostpricepercentage_Internalname), ".", ",");
               AssignAttri("", false, "AV34CostPricePercentage", StringUtil.LTrimStr( AV34CostPricePercentage, 8, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavRetailprofitpercentage_Internalname), ".", ",") < -9999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavRetailprofitpercentage_Internalname), ".", ",") > 99999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vRETAILPROFITPERCENTAGE");
               GX_FocusControl = edtavRetailprofitpercentage_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV31RetailProfitPercentage = 0;
               AssignAttri("", false, "AV31RetailProfitPercentage", StringUtil.LTrimStr( AV31RetailProfitPercentage, 8, 2));
            }
            else
            {
               AV31RetailProfitPercentage = context.localUtil.CToN( cgiGet( edtavRetailprofitpercentage_Internalname), ".", ",");
               AssignAttri("", false, "AV31RetailProfitPercentage", StringUtil.LTrimStr( AV31RetailProfitPercentage, 8, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavWholesaleprofitpercentage_Internalname), ".", ",") < -9999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavWholesaleprofitpercentage_Internalname), ".", ",") > 99999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vWHOLESALEPROFITPERCENTAGE");
               GX_FocusControl = edtavWholesaleprofitpercentage_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV32WholesaleProfitPercentage = 0;
               AssignAttri("", false, "AV32WholesaleProfitPercentage", StringUtil.LTrimStr( AV32WholesaleProfitPercentage, 8, 2));
            }
            else
            {
               AV32WholesaleProfitPercentage = context.localUtil.CToN( cgiGet( edtavWholesaleprofitpercentage_Internalname), ".", ",");
               AssignAttri("", false, "AV32WholesaleProfitPercentage", StringUtil.LTrimStr( AV32WholesaleProfitPercentage, 8, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPercentage_Internalname), ".", ",") < -99.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavPercentage_Internalname), ".", ",") > 999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPERCENTAGE");
               GX_FocusControl = edtavPercentage_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV18Percentage = 0;
               AssignAttri("", false, "AV18Percentage", StringUtil.LTrimStr( AV18Percentage, 6, 2));
            }
            else
            {
               AV18Percentage = context.localUtil.CToN( cgiGet( edtavPercentage_Internalname), ".", ",");
               AssignAttri("", false, "AV18Percentage", StringUtil.LTrimStr( AV18Percentage, 6, 2));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCODE"), AV10Code) != 0 )
            {
               ALLPRODUCTS_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vNAME"), AV15Name) != 0 )
            {
               ALLPRODUCTS_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vSUPPLIER"), ".", ",") != Convert.ToDecimal( AV30Supplier )) )
            {
               ALLPRODUCTS_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vBRAND"), ".", ",") != Convert.ToDecimal( AV9Brand )) )
            {
               ALLPRODUCTS_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vSECTOR"), ".", ",") != Convert.ToDecimal( AV26Sector )) )
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
         E202I2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E202I2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV18Percentage = 0;
         AssignAttri("", false, "AV18Percentage", StringUtil.LTrimStr( AV18Percentage, 6, 2));
      }

      protected void E212I2( )
      {
         AV55GXV10 = nGXsfl_152_idx;
         if ( ( AV55GXV10 > 0 ) && ( AV22ProductsSelected.Count >= AV55GXV10 ) )
         {
            AV22ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV55GXV10));
         }
         AV65GXV20 = nGXsfl_205_idx;
         if ( ( AV65GXV20 > 0 ) && ( AV22ProductsSelected.Count >= AV65GXV20 ) )
         {
            AV22ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV65GXV20));
         }
         /* 'Remove' Routine */
         returnInSub = false;
         AV19Position = (short)(AV27SelectedId.IndexOf(((SdtSDTProductsSelected_SDTProductsSelectedItem)(AV22ProductsSelected.CurrentItem)).gxTpr_Id));
         AV27SelectedId.RemoveItem(AV19Position);
         AV22ProductsSelected.RemoveItem(AV19Position);
         gx_BV152 = true;
         GX_msglist.addItem("Position: "+((SdtSDTProductsSelected_SDTProductsSelectedItem)(AV22ProductsSelected.CurrentItem)).gxTpr_Name);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27SelectedId", AV27SelectedId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ProductsSelected", AV22ProductsSelected);
         nGXsfl_152_bak_idx = nGXsfl_152_idx;
         gxgrGrid3_refresh( subAllproducts_Rows, AV10Code, AV15Name, AV30Supplier, AV9Brand, AV26Sector, AV6newName, AV5newCode, AV37newCostPricePercentage, AV38newPrice, AV33newPercentage) ;
         nGXsfl_152_idx = nGXsfl_152_bak_idx;
         sGXsfl_152_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_152_idx), 4, 0), 4, "0");
         SubsflControlProps_1524( ) ;
      }

      protected void E132I2( )
      {
         /* 'CancelUpdate' Routine */
         returnInSub = false;
         AV18Percentage = 0;
         AssignAttri("", false, "AV18Percentage", StringUtil.LTrimStr( AV18Percentage, 6, 2));
         AV34CostPricePercentage = 0;
         AssignAttri("", false, "AV34CostPricePercentage", StringUtil.LTrimStr( AV34CostPricePercentage, 8, 2));
         AV22ProductsSelected.Clear();
         gx_BV152 = true;
         AV27SelectedId.Clear();
         AV23ProductsSelectedAux.Clear();
         AV28SelectedIdAux.Clear();
         /*  Sending Event outputs  */
         if ( gx_BV152 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ProductsSelected", AV22ProductsSelected);
            nGXsfl_152_bak_idx = nGXsfl_152_idx;
            gxgrGrid3_refresh( subAllproducts_Rows, AV10Code, AV15Name, AV30Supplier, AV9Brand, AV26Sector, AV6newName, AV5newCode, AV37newCostPricePercentage, AV38newPrice, AV33newPercentage) ;
            nGXsfl_152_idx = nGXsfl_152_bak_idx;
            sGXsfl_152_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_152_idx), 4, 0), 4, "0");
            SubsflControlProps_1524( ) ;
         }
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27SelectedId", AV27SelectedId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV23ProductsSelectedAux", AV23ProductsSelectedAux);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28SelectedIdAux", AV28SelectedIdAux);
      }

      protected void E222I2( )
      {
         AV46GXV1 = nGXsfl_96_idx;
         if ( ( AV46GXV1 > 0 ) && ( AV39CostPriceProductsSelected.Count >= AV46GXV1 ) )
         {
            AV39CostPriceProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV39CostPriceProductsSelected.Item(AV46GXV1));
         }
         /* ProductName_Click Routine */
         returnInSub = false;
         AV21Product.Load(A15ProductId);
         if ( StringUtil.StrCmp(Tab1_Activepagecontrolname, "TabPageCostPrice") == 0 )
         {
            /* Execute user subroutine: 'COSTPRICEADDPRODUCT' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else
         {
            GX_msglist.addItem("Other Tab: "+Tab1_Activepagecontrolname);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21Product", AV21Product);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17OneProduct", AV17OneProduct);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV23ProductsSelectedAux", AV23ProductsSelectedAux);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28SelectedIdAux", AV28SelectedIdAux);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39CostPriceProductsSelected", AV39CostPriceProductsSelected);
         nGXsfl_96_bak_idx = nGXsfl_96_idx;
         gxgrCostpricegrid_refresh( subAllproducts_Rows, AV10Code, AV15Name, AV30Supplier, AV9Brand, AV26Sector, AV6newName, AV5newCode, AV37newCostPricePercentage, AV38newPrice, AV33newPercentage) ;
         nGXsfl_96_idx = nGXsfl_96_bak_idx;
         sGXsfl_96_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_96_idx), 4, 0), 4, "0");
         SubsflControlProps_965( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV40CostPriceSelectedId", AV40CostPriceSelectedId);
      }

      protected void E142I2( )
      {
         AV46GXV1 = nGXsfl_96_idx;
         if ( ( AV46GXV1 > 0 ) && ( AV39CostPriceProductsSelected.Count >= AV46GXV1 ) )
         {
            AV39CostPriceProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV39CostPriceProductsSelected.Item(AV46GXV1));
         }
         /* 'AllProducts' Routine */
         returnInSub = false;
         GXt_objcol_SdtSDTProductsSelected_SDTProductsSelectedItem2 = AV23ProductsSelectedAux;
         new dpallproductswhereupdate(context ).execute(  AV15Name,  AV10Code,  AV30Supplier,  AV26Sector,  AV9Brand, out  GXt_objcol_SdtSDTProductsSelected_SDTProductsSelectedItem2) ;
         AV23ProductsSelectedAux = GXt_objcol_SdtSDTProductsSelected_SDTProductsSelectedItem2;
         if ( StringUtil.StrCmp(Tab1_Activepagecontrolname, "TabPageCostPrice") == 0 )
         {
            /* Execute user subroutine: 'COSTPRICEALLPRODUCTS' */
            S122 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else
         {
            GX_msglist.addItem("Other Tab");
         }
         AV23ProductsSelectedAux.Clear();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV23ProductsSelectedAux", AV23ProductsSelectedAux);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17OneProduct", AV17OneProduct);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39CostPriceProductsSelected", AV39CostPriceProductsSelected);
         nGXsfl_96_bak_idx = nGXsfl_96_idx;
         gxgrCostpricegrid_refresh( subAllproducts_Rows, AV10Code, AV15Name, AV30Supplier, AV9Brand, AV26Sector, AV6newName, AV5newCode, AV37newCostPricePercentage, AV38newPrice, AV33newPercentage) ;
         nGXsfl_96_idx = nGXsfl_96_bak_idx;
         sGXsfl_96_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_96_idx), 4, 0), 4, "0");
         SubsflControlProps_965( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV40CostPriceSelectedId", AV40CostPriceSelectedId);
      }

      protected void E122I2( )
      {
         AV46GXV1 = nGXsfl_96_idx;
         if ( ( AV46GXV1 > 0 ) && ( AV39CostPriceProductsSelected.Count >= AV46GXV1 ) )
         {
            AV39CostPriceProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV39CostPriceProductsSelected.Item(AV46GXV1));
         }
         /* Costpriceroundtop_Controlvaluechanged Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(StringUtil.BoolToStr( AV35CostPriceRoundTop), "true") == 0 )
         {
            /* Execute user subroutine: 'COSTPRICECALCULATEALL' */
            S132 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            /* Execute user subroutine: 'COSTPRICEROUNDALL' */
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else
         {
            /* Execute user subroutine: 'COSTPRICECALCULATEALL' */
            S132 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17OneProduct", AV17OneProduct);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39CostPriceProductsSelected", AV39CostPriceProductsSelected);
         nGXsfl_96_bak_idx = nGXsfl_96_idx;
         gxgrCostpricegrid_refresh( subAllproducts_Rows, AV10Code, AV15Name, AV30Supplier, AV9Brand, AV26Sector, AV6newName, AV5newCode, AV37newCostPricePercentage, AV38newPrice, AV33newPercentage) ;
         nGXsfl_96_idx = nGXsfl_96_bak_idx;
         sGXsfl_96_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_96_idx), 4, 0), 4, "0");
         SubsflControlProps_965( ) ;
      }

      protected void E232I2( )
      {
         /* 'CostPriceCancel' Routine */
         returnInSub = false;
         AV34CostPricePercentage = 0;
         AssignAttri("", false, "AV34CostPricePercentage", StringUtil.LTrimStr( AV34CostPricePercentage, 8, 2));
         AV35CostPriceRoundTop = false;
         AssignAttri("", false, "AV35CostPriceRoundTop", AV35CostPriceRoundTop);
         AV22ProductsSelected.Clear();
         gx_BV152 = true;
         AV27SelectedId.Clear();
         AV23ProductsSelectedAux.Clear();
         AV28SelectedIdAux.Clear();
         /*  Sending Event outputs  */
         if ( gx_BV152 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ProductsSelected", AV22ProductsSelected);
            nGXsfl_152_bak_idx = nGXsfl_152_idx;
            gxgrGrid3_refresh( subAllproducts_Rows, AV10Code, AV15Name, AV30Supplier, AV9Brand, AV26Sector, AV6newName, AV5newCode, AV37newCostPricePercentage, AV38newPrice, AV33newPercentage) ;
            nGXsfl_152_idx = nGXsfl_152_bak_idx;
            sGXsfl_152_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_152_idx), 4, 0), 4, "0");
            SubsflControlProps_1524( ) ;
         }
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27SelectedId", AV27SelectedId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV23ProductsSelectedAux", AV23ProductsSelectedAux);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV28SelectedIdAux", AV28SelectedIdAux);
      }

      protected void E162I2( )
      {
         AV55GXV10 = nGXsfl_152_idx;
         if ( ( AV55GXV10 > 0 ) && ( AV22ProductsSelected.Count >= AV55GXV10 ) )
         {
            AV22ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV55GXV10));
         }
         AV65GXV20 = nGXsfl_205_idx;
         if ( ( AV65GXV20 > 0 ) && ( AV22ProductsSelected.Count >= AV65GXV20 ) )
         {
            AV22ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV65GXV20));
         }
         /* 'CostPriceRemove' Routine */
         returnInSub = false;
         AV19Position = (short)(AV27SelectedId.IndexOf(((SdtSDTProductsSelected_SDTProductsSelectedItem)(AV22ProductsSelected.CurrentItem)).gxTpr_Id));
         AV27SelectedId.RemoveItem(AV19Position);
         AV22ProductsSelected.RemoveItem(AV19Position);
         gx_BV152 = true;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27SelectedId", AV27SelectedId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ProductsSelected", AV22ProductsSelected);
         nGXsfl_152_bak_idx = nGXsfl_152_idx;
         gxgrGrid3_refresh( subAllproducts_Rows, AV10Code, AV15Name, AV30Supplier, AV9Brand, AV26Sector, AV6newName, AV5newCode, AV37newCostPricePercentage, AV38newPrice, AV33newPercentage) ;
         nGXsfl_152_idx = nGXsfl_152_bak_idx;
         sGXsfl_152_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_152_idx), 4, 0), 4, "0");
         SubsflControlProps_1524( ) ;
      }

      protected void E152I2( )
      {
         AV55GXV10 = nGXsfl_152_idx;
         if ( ( AV55GXV10 > 0 ) && ( AV22ProductsSelected.Count >= AV55GXV10 ) )
         {
            AV22ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV55GXV10));
         }
         AV65GXV20 = nGXsfl_205_idx;
         if ( ( AV65GXV20 > 0 ) && ( AV22ProductsSelected.Count >= AV65GXV20 ) )
         {
            AV22ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV65GXV20));
         }
         /* 'CostPriceUpdate' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'COSTPRICEALLPRICEOK' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV7AllOk )
         {
            AV75GXV30 = 1;
            while ( AV75GXV30 <= AV22ProductsSelected.Count )
            {
               AV17OneProduct = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV75GXV30));
               AV21Product = new SdtProduct(context);
               AV21Product.Load(AV17OneProduct.gxTpr_Id);
               AV21Product.gxTpr_Productcostprice = AV17OneProduct.gxTpr_Newcostprice;
               AV21Product.Update();
               if ( AV21Product.Success() )
               {
                  context.CommitDataStores("wpupdatepricecopy1",pr_default);
               }
               else
               {
                  context.RollbackDataStores("wpupdatepricecopy1",pr_default);
                  GX_msglist.addItem("Could not update price to Product: "+AV17OneProduct.gxTpr_Name+" Error Details: "+AV21Product.GetMessages());
               }
               AV75GXV30 = (int)(AV75GXV30+1);
            }
            gxgrAllproducts_refresh( subAllproducts_Rows, AV10Code, AV15Name, AV30Supplier, AV9Brand, AV26Sector, AV6newName, AV5newCode, AV37newCostPricePercentage, AV38newPrice, AV33newPercentage) ;
            AV22ProductsSelected.Clear();
            gx_BV152 = true;
            AV27SelectedId.Clear();
            GX_msglist.addItem("Update Prices finished!");
         }
         else
         {
            GX_msglist.addItem("Some New Price are invalids, must be a positive number");
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17OneProduct", AV17OneProduct);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21Product", AV21Product);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ProductsSelected", AV22ProductsSelected);
         nGXsfl_152_bak_idx = nGXsfl_152_idx;
         gxgrGrid3_refresh( subAllproducts_Rows, AV10Code, AV15Name, AV30Supplier, AV9Brand, AV26Sector, AV6newName, AV5newCode, AV37newCostPricePercentage, AV38newPrice, AV33newPercentage) ;
         nGXsfl_152_idx = nGXsfl_152_bak_idx;
         sGXsfl_152_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_152_idx), 4, 0), 4, "0");
         SubsflControlProps_1524( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV27SelectedId", AV27SelectedId);
      }

      protected void S112( )
      {
         /* 'COSTPRICEADDPRODUCT' Routine */
         returnInSub = false;
         GX_msglist.addItem("&Product: "+AV21Product.ToJSonString(true, true));
         if ( AV40CostPriceSelectedId.IndexOf(A15ProductId) <= 0 )
         {
            AV17OneProduct = new SdtSDTProductsSelected_SDTProductsSelectedItem(context);
            AV17OneProduct.gxTpr_Id = A15ProductId;
            AV17OneProduct.gxTpr_Name = A16ProductName;
            AV17OneProduct.gxTpr_Supplier = A5SupplierName;
            AV17OneProduct.gxTpr_Brand = A2BrandName;
            AV17OneProduct.gxTpr_Sector = A10SectorName;
            AV17OneProduct.gxTpr_Costprice = A85ProductCostPrice;
            if ( StringUtil.StrCmp(StringUtil.BoolToStr( AV35CostPriceRoundTop), "true") == 0 )
            {
               /* Execute user subroutine: 'COSTPRICECALCULATEONE' */
               S172 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'COSTPRICEROUNDONE' */
               S182 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
            }
            else
            {
               /* Execute user subroutine: 'COSTPRICECALCULATEONE' */
               S172 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
            }
            AV23ProductsSelectedAux.Add(AV17OneProduct, 0);
            AV28SelectedIdAux.Add(AV17OneProduct.gxTpr_Id, 0);
            AV76GXV31 = 1;
            while ( AV76GXV31 <= AV39CostPriceProductsSelected.Count )
            {
               AV17OneProduct = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV39CostPriceProductsSelected.Item(AV76GXV31));
               AV23ProductsSelectedAux.Add(AV17OneProduct, 0);
               AV28SelectedIdAux.Add(AV17OneProduct.gxTpr_Id, 0);
               AV76GXV31 = (int)(AV76GXV31+1);
            }
            AV39CostPriceProductsSelected = (GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem>)(AV23ProductsSelectedAux.Clone());
            gx_BV96 = true;
            AV40CostPriceSelectedId = (GxSimpleCollection<int>)(AV28SelectedIdAux.Clone());
            AV23ProductsSelectedAux.Clear();
            AV28SelectedIdAux.Clear();
            gxgrCostpricegrid_refresh( subAllproducts_Rows, AV10Code, AV15Name, AV30Supplier, AV9Brand, AV26Sector, AV6newName, AV5newCode, AV37newCostPricePercentage, AV38newPrice, AV33newPercentage) ;
         }
      }

      protected void S162( )
      {
         /* 'COSTPRICECALCULATERWPRICES' Routine */
         returnInSub = false;
         AV77GXV32 = 1;
         while ( AV77GXV32 <= AV22ProductsSelected.Count )
         {
            AV17OneProduct = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV77GXV32));
            AV17OneProduct.gxTpr_Wholesaleprice = (decimal)(AV17OneProduct.gxTpr_Newcostprice*AV17OneProduct.gxTpr_Wholesaleprofit);
            AV17OneProduct.gxTpr_Retailprice = (decimal)(AV17OneProduct.gxTpr_Newcostprice*AV17OneProduct.gxTpr_Retailprofit);
            AV77GXV32 = (int)(AV77GXV32+1);
         }
      }

      protected void S182( )
      {
         /* 'COSTPRICEROUNDONE' Routine */
         returnInSub = false;
         AV20PriceRounded = NumberUtil.Round( AV17OneProduct.gxTpr_Newcostprice, -1);
         AV11Count = 1;
         AV12Digit = (short)(((int)((AV20PriceRounded) % (10))));
         AV20PriceRounded = (decimal)(NumberUtil.Int( (long)(Math.Round(AV20PriceRounded/ (decimal)(10), 18, MidpointRounding.ToEven))));
         while ( ( AV20PriceRounded >= Convert.ToDecimal( 100 )) )
         {
            AV12Digit = (short)(((int)((AV20PriceRounded) % (10))));
            AV20PriceRounded = (decimal)(NumberUtil.Int( (long)(Math.Round(AV20PriceRounded/ (decimal)(10), 18, MidpointRounding.ToEven))));
            AV11Count = (short)(AV11Count+1);
         }
         if ( AV12Digit * 10 > 0 )
         {
            AV20PriceRounded = (decimal)(AV20PriceRounded+1);
         }
         AV13i = 1;
         while ( AV13i <= AV11Count )
         {
            AV20PriceRounded = (decimal)(AV20PriceRounded*10);
            AV13i = (short)(AV13i+1);
         }
         AV17OneProduct.gxTpr_Newcostprice = AV20PriceRounded;
      }

      protected void S142( )
      {
         /* 'COSTPRICEROUNDALL' Routine */
         returnInSub = false;
         AV78GXV33 = 1;
         while ( AV78GXV33 <= AV39CostPriceProductsSelected.Count )
         {
            AV17OneProduct = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV39CostPriceProductsSelected.Item(AV78GXV33));
            AV20PriceRounded = NumberUtil.Round( AV17OneProduct.gxTpr_Newcostprice, -1);
            AV11Count = 1;
            AV12Digit = (short)(((int)((AV20PriceRounded) % (10))));
            AV20PriceRounded = (decimal)(NumberUtil.Int( (long)(Math.Round(AV20PriceRounded/ (decimal)(10), 18, MidpointRounding.ToEven))));
            while ( ( AV20PriceRounded >= Convert.ToDecimal( 100 )) )
            {
               AV12Digit = (short)(((int)((AV20PriceRounded) % (10))));
               AV20PriceRounded = (decimal)(NumberUtil.Int( (long)(Math.Round(AV20PriceRounded/ (decimal)(10), 18, MidpointRounding.ToEven))));
               AV11Count = (short)(AV11Count+1);
            }
            if ( AV12Digit * 10 > 0 )
            {
               AV20PriceRounded = (decimal)(AV20PriceRounded+1);
            }
            AV13i = 1;
            while ( AV13i <= AV11Count )
            {
               AV20PriceRounded = (decimal)(AV20PriceRounded*10);
               AV13i = (short)(AV13i+1);
            }
            AV17OneProduct.gxTpr_Newcostprice = AV20PriceRounded;
            AV78GXV33 = (int)(AV78GXV33+1);
         }
      }

      protected void S172( )
      {
         /* 'COSTPRICECALCULATEONE' Routine */
         returnInSub = false;
         AV17OneProduct.gxTpr_Newcostprice = (decimal)(AV17OneProduct.gxTpr_Costprice*(1+AV34CostPricePercentage/ (decimal)(100)));
      }

      protected void S132( )
      {
         /* 'COSTPRICECALCULATEALL' Routine */
         returnInSub = false;
         AV17OneProduct = new SdtSDTProductsSelected_SDTProductsSelectedItem(context);
         AV79GXV34 = 1;
         while ( AV79GXV34 <= AV39CostPriceProductsSelected.Count )
         {
            AV17OneProduct = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV39CostPriceProductsSelected.Item(AV79GXV34));
            AV17OneProduct.gxTpr_Newcostprice = (decimal)(AV17OneProduct.gxTpr_Costprice*(1+AV34CostPricePercentage/ (decimal)(100)));
            AV79GXV34 = (int)(AV79GXV34+1);
         }
      }

      protected void S152( )
      {
         /* 'COSTPRICEALLPRICEOK' Routine */
         returnInSub = false;
         AV7AllOk = true;
         AssignAttri("", false, "AV7AllOk", AV7AllOk);
         if ( AV27SelectedId.Count > 0 )
         {
            if ( ( ( AV34CostPricePercentage == Convert.ToDecimal( 0 )) ) || ( ( AV34CostPricePercentage != Convert.ToDecimal( 0 )) && ( AV34CostPricePercentage <= Convert.ToDecimal( 100 )) && ( AV18Percentage >= Convert.ToDecimal( -100 )) ) )
            {
               AV13i = 1;
               while ( AV13i <= AV27SelectedId.Count )
               {
                  if ( ( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV13i)).gxTpr_Newcostprice <= Convert.ToDecimal( 0 )) )
                  {
                     AV7AllOk = false;
                     AssignAttri("", false, "AV7AllOk", AV7AllOk);
                  }
                  AV13i = (short)(AV13i+1);
               }
            }
            else
            {
               AV7AllOk = false;
               AssignAttri("", false, "AV7AllOk", AV7AllOk);
            }
         }
         else
         {
            AV7AllOk = false;
            AssignAttri("", false, "AV7AllOk", AV7AllOk);
         }
      }

      protected void S122( )
      {
         /* 'COSTPRICEALLPRODUCTS' Routine */
         returnInSub = false;
         AV80GXV35 = 1;
         while ( AV80GXV35 <= AV23ProductsSelectedAux.Count )
         {
            AV17OneProduct = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV23ProductsSelectedAux.Item(AV80GXV35));
            if ( AV40CostPriceSelectedId.IndexOf(AV17OneProduct.gxTpr_Id) <= 0 )
            {
               if ( StringUtil.StrCmp(StringUtil.BoolToStr( AV35CostPriceRoundTop), "true") == 0 )
               {
                  /* Execute user subroutine: 'COSTPRICECALCULATEONE' */
                  S172 ();
                  if ( returnInSub )
                  {
                     returnInSub = true;
                     if (true) return;
                  }
                  /* Execute user subroutine: 'COSTPRICEROUNDONE' */
                  S182 ();
                  if ( returnInSub )
                  {
                     returnInSub = true;
                     if (true) return;
                  }
               }
               else
               {
                  /* Execute user subroutine: 'COSTPRICECALCULATEONE' */
                  S172 ();
                  if ( returnInSub )
                  {
                     returnInSub = true;
                     if (true) return;
                  }
               }
               AV39CostPriceProductsSelected.Add(AV17OneProduct, 0);
               gx_BV96 = true;
               AV40CostPriceSelectedId.Add(AV17OneProduct.gxTpr_Id, 0);
            }
            AV80GXV35 = (int)(AV80GXV35+1);
         }
      }

      private void E242I2( )
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

      private void E192I3( )
      {
         /* Grid1_Load Routine */
         returnInSub = false;
         AV65GXV20 = 1;
         while ( AV65GXV20 <= AV22ProductsSelected.Count )
         {
            AV22ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV65GXV20));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 205;
            }
            sendrow_2053( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_205_Refreshing )
            {
               DoAjaxLoad(205, Grid1Row);
            }
            AV65GXV20 = (int)(AV65GXV20+1);
         }
      }

      private void E182I4( )
      {
         /* Grid3_Load Routine */
         returnInSub = false;
         AV55GXV10 = 1;
         while ( AV55GXV10 <= AV22ProductsSelected.Count )
         {
            AV22ProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV55GXV10));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 152;
            }
            sendrow_1524( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_152_Refreshing )
            {
               DoAjaxLoad(152, Grid3Row);
            }
            AV55GXV10 = (int)(AV55GXV10+1);
         }
      }

      private void E172I5( )
      {
         /* Costpricegrid_Load Routine */
         returnInSub = false;
         AV46GXV1 = 1;
         while ( AV46GXV1 <= AV39CostPriceProductsSelected.Count )
         {
            AV39CostPriceProductsSelected.CurrentItem = ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV39CostPriceProductsSelected.Item(AV46GXV1));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 96;
            }
            sendrow_965( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_96_Refreshing )
            {
               DoAjaxLoad(96, CostpricegridRow);
            }
            AV46GXV1 = (int)(AV46GXV1+1);
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
         PA2I2( ) ;
         WS2I2( ) ;
         WE2I2( ) ;
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
         AddStyleSheetFile("Tab/BasicTab.css", "");
         AddStyleSheetFile("Switch/switch.min.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20242272193975", true, true);
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
         context.AddJavascriptSource("wpupdatepricecopy1.js", "?20242272193977", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/BasicTabRender.js", "", false, true);
         context.AddJavascriptSource("Switch/switch.min.js", "", false, true);
         context.AddJavascriptSource("Switch/switch.min.js", "", false, true);
         context.AddJavascriptSource("Switch/switch.min.js", "", false, true);
         context.AddJavascriptSource("Switch/switch.min.js", "", false, true);
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
         edtProductCostPrice_Internalname = "PRODUCTCOSTPRICE_"+sGXsfl_34_idx;
         edtProductRetailProfit_Internalname = "PRODUCTRETAILPROFIT_"+sGXsfl_34_idx;
         edtProductRetailPrice_Internalname = "PRODUCTRETAILPRICE_"+sGXsfl_34_idx;
         edtProductWholesaleProfit_Internalname = "PRODUCTWHOLESALEPROFIT_"+sGXsfl_34_idx;
         edtProductWholesalePrice_Internalname = "PRODUCTWHOLESALEPRICE_"+sGXsfl_34_idx;
      }

      protected void SubsflControlProps_fel_342( )
      {
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_34_fel_idx;
         edtProductName_Internalname = "PRODUCTNAME_"+sGXsfl_34_fel_idx;
         edtSupplierName_Internalname = "SUPPLIERNAME_"+sGXsfl_34_fel_idx;
         edtBrandName_Internalname = "BRANDNAME_"+sGXsfl_34_fel_idx;
         edtSectorName_Internalname = "SECTORNAME_"+sGXsfl_34_fel_idx;
         edtProductPrice_Internalname = "PRODUCTPRICE_"+sGXsfl_34_fel_idx;
         edtProductCostPrice_Internalname = "PRODUCTCOSTPRICE_"+sGXsfl_34_fel_idx;
         edtProductRetailProfit_Internalname = "PRODUCTRETAILPROFIT_"+sGXsfl_34_fel_idx;
         edtProductRetailPrice_Internalname = "PRODUCTRETAILPRICE_"+sGXsfl_34_fel_idx;
         edtProductWholesaleProfit_Internalname = "PRODUCTWHOLESALEPROFIT_"+sGXsfl_34_fel_idx;
         edtProductWholesalePrice_Internalname = "PRODUCTWHOLESALEPRICE_"+sGXsfl_34_fel_idx;
      }

      protected void sendrow_342( )
      {
         SubsflControlProps_342( ) ;
         WB2I0( ) ;
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
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductCostPrice_Internalname,StringUtil.LTrim( StringUtil.NToC( A85ProductCostPrice, 10, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A85ProductCostPrice, "ZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductCostPrice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)34,(short)0,(short)-1,(short)0,(bool)true,(string)"Price",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductRetailProfit_Internalname,StringUtil.LTrim( StringUtil.NToC( A89ProductRetailProfit, 8, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A89ProductRetailProfit, "ZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductRetailProfit_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)34,(short)0,(short)-1,(short)0,(bool)true,(string)"Percentage",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductRetailPrice_Internalname,StringUtil.LTrim( StringUtil.NToC( A90ProductRetailPrice, 10, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A90ProductRetailPrice, "ZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductRetailPrice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)34,(short)0,(short)-1,(short)0,(bool)true,(string)"Price",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductWholesaleProfit_Internalname,StringUtil.LTrim( StringUtil.NToC( A87ProductWholesaleProfit, 8, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A87ProductWholesaleProfit, "ZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductWholesaleProfit_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)34,(short)0,(short)-1,(short)0,(bool)true,(string)"Percentage",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductWholesalePrice_Internalname,StringUtil.LTrim( StringUtil.NToC( A88ProductWholesalePrice, 10, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A88ProductWholesalePrice, "ZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductWholesalePrice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)34,(short)0,(short)-1,(short)0,(bool)true,(string)"Price",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes2I2( ) ;
            AllproductsContainer.AddRow(AllproductsRow);
            nGXsfl_34_idx = ((subAllproducts_Islastpage==1)&&(nGXsfl_34_idx+1>subAllproducts_fnc_Recordsperpage( )) ? 1 : nGXsfl_34_idx+1);
            sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
            SubsflControlProps_342( ) ;
         }
         /* End function sendrow_342 */
      }

      protected void SubsflControlProps_965( )
      {
         edtavCtlname_Internalname = "CTLNAME_"+sGXsfl_96_idx;
         edtavCtlsupplier_Internalname = "CTLSUPPLIER_"+sGXsfl_96_idx;
         edtavCtlsector_Internalname = "CTLSECTOR_"+sGXsfl_96_idx;
         edtavCtlbrand_Internalname = "CTLBRAND_"+sGXsfl_96_idx;
         edtavCtlcostprice_Internalname = "CTLCOSTPRICE_"+sGXsfl_96_idx;
         edtavCtlnewcostprice_Internalname = "CTLNEWCOSTPRICE_"+sGXsfl_96_idx;
         edtavCtlretailprice_Internalname = "CTLRETAILPRICE_"+sGXsfl_96_idx;
         edtavCtlwholesaleprice_Internalname = "CTLWHOLESALEPRICE_"+sGXsfl_96_idx;
      }

      protected void SubsflControlProps_fel_965( )
      {
         edtavCtlname_Internalname = "CTLNAME_"+sGXsfl_96_fel_idx;
         edtavCtlsupplier_Internalname = "CTLSUPPLIER_"+sGXsfl_96_fel_idx;
         edtavCtlsector_Internalname = "CTLSECTOR_"+sGXsfl_96_fel_idx;
         edtavCtlbrand_Internalname = "CTLBRAND_"+sGXsfl_96_fel_idx;
         edtavCtlcostprice_Internalname = "CTLCOSTPRICE_"+sGXsfl_96_fel_idx;
         edtavCtlnewcostprice_Internalname = "CTLNEWCOSTPRICE_"+sGXsfl_96_fel_idx;
         edtavCtlretailprice_Internalname = "CTLRETAILPRICE_"+sGXsfl_96_fel_idx;
         edtavCtlwholesaleprice_Internalname = "CTLWHOLESALEPRICE_"+sGXsfl_96_fel_idx;
      }

      protected void sendrow_965( )
      {
         SubsflControlProps_965( ) ;
         WB2I0( ) ;
         CostpricegridRow = GXWebRow.GetNew(context,CostpricegridContainer);
         if ( subCostpricegrid_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subCostpricegrid_Backstyle = 0;
            if ( StringUtil.StrCmp(subCostpricegrid_Class, "") != 0 )
            {
               subCostpricegrid_Linesclass = subCostpricegrid_Class+"Odd";
            }
         }
         else if ( subCostpricegrid_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subCostpricegrid_Backstyle = 0;
            subCostpricegrid_Backcolor = subCostpricegrid_Allbackcolor;
            if ( StringUtil.StrCmp(subCostpricegrid_Class, "") != 0 )
            {
               subCostpricegrid_Linesclass = subCostpricegrid_Class+"Uniform";
            }
         }
         else if ( subCostpricegrid_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subCostpricegrid_Backstyle = 1;
            if ( StringUtil.StrCmp(subCostpricegrid_Class, "") != 0 )
            {
               subCostpricegrid_Linesclass = subCostpricegrid_Class+"Odd";
            }
            subCostpricegrid_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subCostpricegrid_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subCostpricegrid_Backstyle = 1;
            if ( ((int)((nGXsfl_96_idx) % (2))) == 0 )
            {
               subCostpricegrid_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subCostpricegrid_Class, "") != 0 )
               {
                  subCostpricegrid_Linesclass = subCostpricegrid_Class+"Even";
               }
            }
            else
            {
               subCostpricegrid_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subCostpricegrid_Class, "") != 0 )
               {
                  subCostpricegrid_Linesclass = subCostpricegrid_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( CostpricegridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subCostpricegrid_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_96_idx+"\">") ;
         }
         /* Div Control */
         CostpricegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divGrid2table_Internalname+"_"+sGXsfl_96_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         CostpricegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         CostpricegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         CostpricegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         CostpricegridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname_Internalname,(string)"Name",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         CostpricegridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname_Internalname,((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV46GXV1)).gxTpr_Name,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlname_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)96,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         CostpricegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CostpricegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         CostpricegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         CostpricegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         CostpricegridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsupplier_Internalname,(string)"Supplier",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         CostpricegridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsupplier_Internalname,((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV46GXV1)).gxTpr_Supplier,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlsupplier_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlsupplier_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)96,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         CostpricegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CostpricegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         CostpricegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         CostpricegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         CostpricegridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsector_Internalname,(string)"Sector",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         CostpricegridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsector_Internalname,((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV46GXV1)).gxTpr_Sector,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlsector_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlsector_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)96,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         CostpricegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CostpricegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         CostpricegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         CostpricegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         CostpricegridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlbrand_Internalname,(string)"Brand",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         CostpricegridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlbrand_Internalname,((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV46GXV1)).gxTpr_Brand,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlbrand_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlbrand_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)96,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         CostpricegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CostpricegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         CostpricegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"Right",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         CostpricegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         CostpricegridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcostprice_Internalname,(string)"Cost Price",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         CostpricegridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcostprice_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV46GXV1)).gxTpr_Costprice, 10, 2, ".", "")),StringUtil.LTrim( ((edtavCtlcostprice_Enabled!=0) ? context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV46GXV1)).gxTpr_Costprice, "ZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV46GXV1)).gxTpr_Costprice, "ZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcostprice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlcostprice_Enabled,(short)0,(string)"text",(string)"",(short)10,(string)"chr",(short)1,(string)"row",(short)10,(short)0,(short)0,(short)96,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         CostpricegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CostpricegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"Right",(string)"top",(string)"div"});
         /* Div Control */
         CostpricegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"Right",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         CostpricegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         CostpricegridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlnewcostprice_Internalname,(string)"New Cost Price",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         TempTags = " " + ((edtavCtlnewcostprice_Enabled!=0)&&(edtavCtlnewcostprice_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 116,'',false,'"+sGXsfl_96_idx+"',96)\"" : " ");
         ROClassString = "Attribute";
         CostpricegridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlnewcostprice_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV46GXV1)).gxTpr_Newcostprice, 10, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV46GXV1)).gxTpr_Newcostprice, "ZZZZZZ9.99")),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+((edtavCtlnewcostprice_Enabled!=0)&&(edtavCtlnewcostprice_Visible!=0) ? " onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,116);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlnewcostprice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)1,(short)0,(string)"text",(string)"",(short)10,(string)"chr",(short)1,(string)"row",(short)10,(short)0,(short)0,(short)96,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         CostpricegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CostpricegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"Right",(string)"top",(string)"div"});
         /* Div Control */
         CostpricegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"Right",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         CostpricegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         CostpricegridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlretailprice_Internalname,(string)"Retail Price",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         CostpricegridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlretailprice_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV46GXV1)).gxTpr_Retailprice, 10, 2, ".", "")),StringUtil.LTrim( ((edtavCtlretailprice_Enabled!=0) ? context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV46GXV1)).gxTpr_Retailprice, "ZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV46GXV1)).gxTpr_Retailprice, "ZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlretailprice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlretailprice_Enabled,(short)0,(string)"text",(string)"",(short)10,(string)"chr",(short)1,(string)"row",(short)10,(short)0,(short)0,(short)96,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         CostpricegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CostpricegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"Right",(string)"top",(string)"div"});
         /* Div Control */
         CostpricegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"Right",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         CostpricegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         CostpricegridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlwholesaleprice_Internalname,(string)"Wholesale Price",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         CostpricegridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlwholesaleprice_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV46GXV1)).gxTpr_Wholesaleprice, 10, 2, ".", "")),StringUtil.LTrim( ((edtavCtlwholesaleprice_Enabled!=0) ? context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV46GXV1)).gxTpr_Wholesaleprice, "ZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV46GXV1)).gxTpr_Wholesaleprice, "ZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlwholesaleprice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlwholesaleprice_Enabled,(short)0,(string)"text",(string)"",(short)10,(string)"chr",(short)1,(string)"row",(short)10,(short)0,(short)0,(short)96,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         CostpricegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CostpricegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"Right",(string)"top",(string)"div"});
         /* Div Control */
         CostpricegridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 124,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         CostpricegridRow.AddColumnProperties("button", 2, isAjaxCallMode( ), new Object[] {(string)bttCostpriceremove_Internalname+"_"+sGXsfl_96_idx,"gx.evt.setGridEvt("+StringUtil.Str( (decimal)(96), 2, 0)+","+"null"+");",(string)"Remove",(string)bttCostpriceremove_Jsonclick,(short)5,(string)"Remove",(string)"",(string)StyleString,(string)ClassString,(short)1,(short)1,(string)"standard","'"+""+"'"+",false,"+"'"+"E\\'COSTPRICEREMOVE\\'."+"'",(string)TempTags,(string)"",context.GetButtonType( )});
         CostpricegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CostpricegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CostpricegridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         send_integrity_lvl_hashes2I5( ) ;
         /* End of Columns property logic. */
         CostpricegridContainer.AddRow(CostpricegridRow);
         nGXsfl_96_idx = ((subCostpricegrid_Islastpage==1)&&(nGXsfl_96_idx+1>subCostpricegrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_96_idx+1);
         sGXsfl_96_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_96_idx), 4, 0), 4, "0");
         SubsflControlProps_965( ) ;
         /* End function sendrow_965 */
      }

      protected void SubsflControlProps_1524( )
      {
         edtavCtlname2_Internalname = "CTLNAME2_"+sGXsfl_152_idx;
         edtavCtlsector1_Internalname = "CTLSECTOR1_"+sGXsfl_152_idx;
         edtavCtlsupplier1_Internalname = "CTLSUPPLIER1_"+sGXsfl_152_idx;
         edtavCtlbrand1_Internalname = "CTLBRAND1_"+sGXsfl_152_idx;
         edtavCtlcostprice1_Internalname = "CTLCOSTPRICE1_"+sGXsfl_152_idx;
         edtavCtlretailprofit_Internalname = "CTLRETAILPROFIT_"+sGXsfl_152_idx;
         edtavCtlretailprice1_Internalname = "CTLRETAILPRICE1_"+sGXsfl_152_idx;
         edtavCtlwholesaleprofit_Internalname = "CTLWHOLESALEPROFIT_"+sGXsfl_152_idx;
         edtavCtlwholesaleprice1_Internalname = "CTLWHOLESALEPRICE1_"+sGXsfl_152_idx;
      }

      protected void SubsflControlProps_fel_1524( )
      {
         edtavCtlname2_Internalname = "CTLNAME2_"+sGXsfl_152_fel_idx;
         edtavCtlsector1_Internalname = "CTLSECTOR1_"+sGXsfl_152_fel_idx;
         edtavCtlsupplier1_Internalname = "CTLSUPPLIER1_"+sGXsfl_152_fel_idx;
         edtavCtlbrand1_Internalname = "CTLBRAND1_"+sGXsfl_152_fel_idx;
         edtavCtlcostprice1_Internalname = "CTLCOSTPRICE1_"+sGXsfl_152_fel_idx;
         edtavCtlretailprofit_Internalname = "CTLRETAILPROFIT_"+sGXsfl_152_fel_idx;
         edtavCtlretailprice1_Internalname = "CTLRETAILPRICE1_"+sGXsfl_152_fel_idx;
         edtavCtlwholesaleprofit_Internalname = "CTLWHOLESALEPROFIT_"+sGXsfl_152_fel_idx;
         edtavCtlwholesaleprice1_Internalname = "CTLWHOLESALEPRICE1_"+sGXsfl_152_fel_idx;
      }

      protected void sendrow_1524( )
      {
         SubsflControlProps_1524( ) ;
         WB2I0( ) ;
         Grid3Row = GXWebRow.GetNew(context,Grid3Container);
         if ( subGrid3_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGrid3_Backstyle = 0;
            if ( StringUtil.StrCmp(subGrid3_Class, "") != 0 )
            {
               subGrid3_Linesclass = subGrid3_Class+"Odd";
            }
         }
         else if ( subGrid3_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGrid3_Backstyle = 0;
            subGrid3_Backcolor = subGrid3_Allbackcolor;
            if ( StringUtil.StrCmp(subGrid3_Class, "") != 0 )
            {
               subGrid3_Linesclass = subGrid3_Class+"Uniform";
            }
         }
         else if ( subGrid3_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGrid3_Backstyle = 1;
            if ( StringUtil.StrCmp(subGrid3_Class, "") != 0 )
            {
               subGrid3_Linesclass = subGrid3_Class+"Odd";
            }
            subGrid3_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subGrid3_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGrid3_Backstyle = 1;
            if ( ((int)((nGXsfl_152_idx) % (2))) == 0 )
            {
               subGrid3_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGrid3_Class, "") != 0 )
               {
                  subGrid3_Linesclass = subGrid3_Class+"Even";
               }
            }
            else
            {
               subGrid3_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subGrid3_Class, "") != 0 )
               {
                  subGrid3_Linesclass = subGrid3_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( Grid3Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subGrid3_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_152_idx+"\">") ;
         }
         /* Div Control */
         Grid3Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divGrid3table_Internalname+"_"+sGXsfl_152_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid3Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid3Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid3Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Grid3Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname2_Internalname,(string)"Name",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         Grid3Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname2_Internalname,((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV55GXV10)).gxTpr_Name,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlname2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlname2_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)152,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         Grid3Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid3Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Grid3Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid3Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Grid3Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsector1_Internalname,(string)"Sector",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         Grid3Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsector1_Internalname,((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV55GXV10)).gxTpr_Sector,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlsector1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlsector1_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)152,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         Grid3Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid3Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Grid3Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid3Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Grid3Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsupplier1_Internalname,(string)"Supplier",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         Grid3Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsupplier1_Internalname,((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV55GXV10)).gxTpr_Supplier,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlsupplier1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlsupplier1_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)152,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         Grid3Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid3Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Grid3Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid3Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Grid3Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlbrand1_Internalname,(string)"Brand",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         Grid3Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlbrand1_Internalname,((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV55GXV10)).gxTpr_Brand,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlbrand1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlbrand1_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)152,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         Grid3Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid3Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Grid3Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid3Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Grid3Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcostprice1_Internalname,(string)"Cost Price",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         Grid3Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcostprice1_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV55GXV10)).gxTpr_Costprice, 10, 2, ".", "")),StringUtil.LTrim( ((edtavCtlcostprice1_Enabled!=0) ? context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV55GXV10)).gxTpr_Costprice, "ZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV55GXV10)).gxTpr_Costprice, "ZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcostprice1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlcostprice1_Enabled,(short)0,(string)"text",(string)"",(short)10,(string)"chr",(short)1,(string)"row",(short)10,(short)0,(short)0,(short)152,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         Grid3Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid3Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Grid3Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid3Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Grid3Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlretailprofit_Internalname,(string)"Retail Profit",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         TempTags = " " + ((edtavCtlretailprofit_Enabled!=0)&&(edtavCtlretailprofit_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 172,'',false,'"+sGXsfl_152_idx+"',152)\"" : " ");
         ROClassString = "Attribute";
         Grid3Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlretailprofit_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV55GXV10)).gxTpr_Retailprofit, 8, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV55GXV10)).gxTpr_Retailprofit, "ZZZZ9.99")),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+((edtavCtlretailprofit_Enabled!=0)&&(edtavCtlretailprofit_Visible!=0) ? " onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,172);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlretailprofit_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)1,(short)0,(string)"text",(string)"",(short)8,(string)"chr",(short)1,(string)"row",(short)8,(short)0,(short)0,(short)152,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         Grid3Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid3Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Grid3Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid3Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Grid3Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlretailprice1_Internalname,(string)"Retail Price",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         Grid3Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlretailprice1_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV55GXV10)).gxTpr_Retailprice, 10, 2, ".", "")),StringUtil.LTrim( ((edtavCtlretailprice1_Enabled!=0) ? context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV55GXV10)).gxTpr_Retailprice, "ZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV55GXV10)).gxTpr_Retailprice, "ZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlretailprice1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlretailprice1_Enabled,(short)0,(string)"text",(string)"",(short)10,(string)"chr",(short)1,(string)"row",(short)10,(short)0,(short)0,(short)152,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         Grid3Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid3Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Grid3Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid3Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Grid3Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlwholesaleprofit_Internalname,(string)"Wholesale Profit",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         TempTags = " " + ((edtavCtlwholesaleprofit_Enabled!=0)&&(edtavCtlwholesaleprofit_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 178,'',false,'"+sGXsfl_152_idx+"',152)\"" : " ");
         ROClassString = "Attribute";
         Grid3Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlwholesaleprofit_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV55GXV10)).gxTpr_Wholesaleprofit, 8, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV55GXV10)).gxTpr_Wholesaleprofit, "ZZZZ9.99")),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+((edtavCtlwholesaleprofit_Enabled!=0)&&(edtavCtlwholesaleprofit_Visible!=0) ? " onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,178);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlwholesaleprofit_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)1,(short)0,(string)"text",(string)"",(short)8,(string)"chr",(short)1,(string)"row",(short)8,(short)0,(short)0,(short)152,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         Grid3Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid3Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Grid3Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid3Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Grid3Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlwholesaleprice1_Internalname,(string)"Wholesale Price",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         Grid3Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlwholesaleprice1_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV55GXV10)).gxTpr_Wholesaleprice, 10, 2, ".", "")),StringUtil.LTrim( ((edtavCtlwholesaleprice1_Enabled!=0) ? context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV55GXV10)).gxTpr_Wholesaleprice, "ZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV55GXV10)).gxTpr_Wholesaleprice, "ZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlwholesaleprice1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlwholesaleprice1_Enabled,(short)0,(string)"text",(string)"",(short)10,(string)"chr",(short)1,(string)"row",(short)10,(short)0,(short)0,(short)152,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         Grid3Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid3Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid3Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid3Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         send_integrity_lvl_hashes2I4( ) ;
         /* End of Columns property logic. */
         Grid3Container.AddRow(Grid3Row);
         nGXsfl_152_idx = ((subGrid3_Islastpage==1)&&(nGXsfl_152_idx+1>subGrid3_fnc_Recordsperpage( )) ? 1 : nGXsfl_152_idx+1);
         sGXsfl_152_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_152_idx), 4, 0), 4, "0");
         SubsflControlProps_1524( ) ;
         /* End function sendrow_1524 */
      }

      protected void SubsflControlProps_2053( )
      {
         edtavCtlname3_Internalname = "CTLNAME3_"+sGXsfl_205_idx;
         edtavCtlsector2_Internalname = "CTLSECTOR2_"+sGXsfl_205_idx;
         edtavCtlsupplier2_Internalname = "CTLSUPPLIER2_"+sGXsfl_205_idx;
         edtavCtlbrand2_Internalname = "CTLBRAND2_"+sGXsfl_205_idx;
         edtavCtlcostprice2_Internalname = "CTLCOSTPRICE2_"+sGXsfl_205_idx;
         edtavCtlretailprofit1_Internalname = "CTLRETAILPROFIT1_"+sGXsfl_205_idx;
         edtavCtlretailprice2_Internalname = "CTLRETAILPRICE2_"+sGXsfl_205_idx;
         edtavCtlwholesaleprofit1_Internalname = "CTLWHOLESALEPROFIT1_"+sGXsfl_205_idx;
         edtavCtlwholesaleprice2_Internalname = "CTLWHOLESALEPRICE2_"+sGXsfl_205_idx;
      }

      protected void SubsflControlProps_fel_2053( )
      {
         edtavCtlname3_Internalname = "CTLNAME3_"+sGXsfl_205_fel_idx;
         edtavCtlsector2_Internalname = "CTLSECTOR2_"+sGXsfl_205_fel_idx;
         edtavCtlsupplier2_Internalname = "CTLSUPPLIER2_"+sGXsfl_205_fel_idx;
         edtavCtlbrand2_Internalname = "CTLBRAND2_"+sGXsfl_205_fel_idx;
         edtavCtlcostprice2_Internalname = "CTLCOSTPRICE2_"+sGXsfl_205_fel_idx;
         edtavCtlretailprofit1_Internalname = "CTLRETAILPROFIT1_"+sGXsfl_205_fel_idx;
         edtavCtlretailprice2_Internalname = "CTLRETAILPRICE2_"+sGXsfl_205_fel_idx;
         edtavCtlwholesaleprofit1_Internalname = "CTLWHOLESALEPROFIT1_"+sGXsfl_205_fel_idx;
         edtavCtlwholesaleprice2_Internalname = "CTLWHOLESALEPRICE2_"+sGXsfl_205_fel_idx;
      }

      protected void sendrow_2053( )
      {
         SubsflControlProps_2053( ) ;
         WB2I0( ) ;
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
            if ( ((int)((nGXsfl_205_idx) % (2))) == 0 )
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
            context.WriteHtmlText( "<tr"+" class=\""+subGrid1_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_205_idx+"\">") ;
         }
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divGrid1table1_Internalname+"_"+sGXsfl_205_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Grid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname3_Internalname,(string)"Name",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname3_Internalname,((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV65GXV20)).gxTpr_Name,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlname3_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlname3_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)205,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Grid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsector2_Internalname,(string)"Sector",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsector2_Internalname,((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV65GXV20)).gxTpr_Sector,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlsector2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlsector2_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)205,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Grid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsupplier2_Internalname,(string)"Supplier",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsupplier2_Internalname,((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV65GXV20)).gxTpr_Supplier,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlsupplier2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlsupplier2_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)205,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Grid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlbrand2_Internalname,(string)"Brand",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlbrand2_Internalname,((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV65GXV20)).gxTpr_Brand,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlbrand2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlbrand2_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)205,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Grid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcostprice2_Internalname,(string)"Cost Price",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcostprice2_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV65GXV20)).gxTpr_Costprice, 10, 2, ".", "")),StringUtil.LTrim( ((edtavCtlcostprice2_Enabled!=0) ? context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV65GXV20)).gxTpr_Costprice, "ZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV65GXV20)).gxTpr_Costprice, "ZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcostprice2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlcostprice2_Enabled,(short)0,(string)"text",(string)"",(short)10,(string)"chr",(short)1,(string)"row",(short)10,(short)0,(short)0,(short)205,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Grid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlretailprofit1_Internalname,(string)"Retail Profit",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlretailprofit1_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV65GXV20)).gxTpr_Retailprofit, 8, 2, ".", "")),StringUtil.LTrim( ((edtavCtlretailprofit1_Enabled!=0) ? context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV65GXV20)).gxTpr_Retailprofit, "ZZZZ9.99") : context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV65GXV20)).gxTpr_Retailprofit, "ZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlretailprofit1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlretailprofit1_Enabled,(short)0,(string)"text",(string)"",(short)8,(string)"chr",(short)1,(string)"row",(short)8,(short)0,(short)0,(short)205,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Grid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlretailprice2_Internalname,(string)"Retail Price",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         TempTags = " " + ((edtavCtlretailprice2_Enabled!=0)&&(edtavCtlretailprice2_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 228,'',false,'"+sGXsfl_205_idx+"',205)\"" : " ");
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlretailprice2_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV65GXV20)).gxTpr_Retailprice, 10, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV65GXV20)).gxTpr_Retailprice, "ZZZZZZ9.99")),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+((edtavCtlretailprice2_Enabled!=0)&&(edtavCtlretailprice2_Visible!=0) ? " onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,228);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlretailprice2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)1,(short)0,(string)"text",(string)"",(short)10,(string)"chr",(short)1,(string)"row",(short)10,(short)0,(short)0,(short)205,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Grid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlwholesaleprofit1_Internalname,(string)"Wholesale Profit",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlwholesaleprofit1_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV65GXV20)).gxTpr_Wholesaleprofit, 8, 2, ".", "")),StringUtil.LTrim( ((edtavCtlwholesaleprofit1_Enabled!=0) ? context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV65GXV20)).gxTpr_Wholesaleprofit, "ZZZZ9.99") : context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV65GXV20)).gxTpr_Wholesaleprofit, "ZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlwholesaleprofit1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlwholesaleprofit1_Enabled,(short)0,(string)"text",(string)"",(short)8,(string)"chr",(short)1,(string)"row",(short)8,(short)0,(short)0,(short)205,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-1",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Grid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlwholesaleprice2_Internalname,(string)"Wholesale Price",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         TempTags = " " + ((edtavCtlwholesaleprice2_Enabled!=0)&&(edtavCtlwholesaleprice2_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 234,'',false,'"+sGXsfl_205_idx+"',205)\"" : " ");
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlwholesaleprice2_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV65GXV20)).gxTpr_Wholesaleprice, 10, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( ((SdtSDTProductsSelected_SDTProductsSelectedItem)AV22ProductsSelected.Item(AV65GXV20)).gxTpr_Wholesaleprice, "ZZZZZZ9.99")),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+((edtavCtlwholesaleprice2_Enabled!=0)&&(edtavCtlwholesaleprice2_Visible!=0) ? " onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,234);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlwholesaleprice2_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)1,(short)0,(string)"text",(string)"",(short)10,(string)"chr",(short)1,(string)"row",(short)10,(short)0,(short)0,(short)205,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         send_integrity_lvl_hashes2I3( ) ;
         /* End of Columns property logic. */
         Grid1Container.AddRow(Grid1Row);
         nGXsfl_205_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_205_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_205_idx+1);
         sGXsfl_205_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_205_idx), 4, 0), 4, "0");
         SubsflControlProps_2053( ) ;
         /* End function sendrow_2053 */
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
            context.SendWebValue( "Unit Price") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Cost Price") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Retail Profit") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Retail Price") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Wholesale Profit") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Wholesale Price") ;
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
            AllproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A85ProductCostPrice, 10, 2, ".", ""))));
            AllproductsContainer.AddColumnProperties(AllproductsColumn);
            AllproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A89ProductRetailProfit, 8, 2, ".", ""))));
            AllproductsContainer.AddColumnProperties(AllproductsColumn);
            AllproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A90ProductRetailPrice, 10, 2, ".", ""))));
            AllproductsContainer.AddColumnProperties(AllproductsColumn);
            AllproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A87ProductWholesaleProfit, 8, 2, ".", ""))));
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

      protected void StartGridControl96( )
      {
         if ( CostpricegridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"CostpricegridContainer"+"DivS\" data-gxgridid=\"96\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subCostpricegrid_Internalname, subCostpricegrid_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            CostpricegridContainer.AddObjectProperty("GridName", "Costpricegrid");
         }
         else
         {
            CostpricegridContainer.AddObjectProperty("GridName", "Costpricegrid");
            CostpricegridContainer.AddObjectProperty("Header", subCostpricegrid_Header);
            CostpricegridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            CostpricegridContainer.AddObjectProperty("Class", "FreeStyleGrid");
            CostpricegridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            CostpricegridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            CostpricegridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subCostpricegrid_Backcolorstyle), 1, 0, ".", "")));
            CostpricegridContainer.AddObjectProperty("CmpContext", "");
            CostpricegridContainer.AddObjectProperty("InMasterPage", "false");
            CostpricegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricegridContainer.AddColumnProperties(CostpricegridColumn);
            CostpricegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricegridContainer.AddColumnProperties(CostpricegridColumn);
            CostpricegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricegridContainer.AddColumnProperties(CostpricegridColumn);
            CostpricegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricegridContainer.AddColumnProperties(CostpricegridColumn);
            CostpricegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricegridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlname_Enabled), 5, 0, ".", "")));
            CostpricegridContainer.AddColumnProperties(CostpricegridColumn);
            CostpricegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricegridContainer.AddColumnProperties(CostpricegridColumn);
            CostpricegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricegridContainer.AddColumnProperties(CostpricegridColumn);
            CostpricegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricegridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlsupplier_Enabled), 5, 0, ".", "")));
            CostpricegridContainer.AddColumnProperties(CostpricegridColumn);
            CostpricegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricegridContainer.AddColumnProperties(CostpricegridColumn);
            CostpricegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricegridContainer.AddColumnProperties(CostpricegridColumn);
            CostpricegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricegridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlsector_Enabled), 5, 0, ".", "")));
            CostpricegridContainer.AddColumnProperties(CostpricegridColumn);
            CostpricegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricegridContainer.AddColumnProperties(CostpricegridColumn);
            CostpricegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricegridContainer.AddColumnProperties(CostpricegridColumn);
            CostpricegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricegridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlbrand_Enabled), 5, 0, ".", "")));
            CostpricegridContainer.AddColumnProperties(CostpricegridColumn);
            CostpricegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricegridContainer.AddColumnProperties(CostpricegridColumn);
            CostpricegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricegridContainer.AddColumnProperties(CostpricegridColumn);
            CostpricegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricegridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlcostprice_Enabled), 5, 0, ".", "")));
            CostpricegridContainer.AddColumnProperties(CostpricegridColumn);
            CostpricegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricegridContainer.AddColumnProperties(CostpricegridColumn);
            CostpricegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricegridContainer.AddColumnProperties(CostpricegridColumn);
            CostpricegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricegridContainer.AddColumnProperties(CostpricegridColumn);
            CostpricegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricegridContainer.AddColumnProperties(CostpricegridColumn);
            CostpricegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricegridContainer.AddColumnProperties(CostpricegridColumn);
            CostpricegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricegridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlretailprice_Enabled), 5, 0, ".", "")));
            CostpricegridContainer.AddColumnProperties(CostpricegridColumn);
            CostpricegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricegridContainer.AddColumnProperties(CostpricegridColumn);
            CostpricegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricegridContainer.AddColumnProperties(CostpricegridColumn);
            CostpricegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricegridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlwholesaleprice_Enabled), 5, 0, ".", "")));
            CostpricegridContainer.AddColumnProperties(CostpricegridColumn);
            CostpricegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricegridContainer.AddColumnProperties(CostpricegridColumn);
            CostpricegridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            CostpricegridContainer.AddColumnProperties(CostpricegridColumn);
            CostpricegridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subCostpricegrid_Selectedindex), 4, 0, ".", "")));
            CostpricegridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subCostpricegrid_Allowselection), 1, 0, ".", "")));
            CostpricegridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subCostpricegrid_Selectioncolor), 9, 0, ".", "")));
            CostpricegridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subCostpricegrid_Allowhovering), 1, 0, ".", "")));
            CostpricegridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subCostpricegrid_Hoveringcolor), 9, 0, ".", "")));
            CostpricegridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subCostpricegrid_Allowcollapsing), 1, 0, ".", "")));
            CostpricegridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subCostpricegrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void StartGridControl152( )
      {
         if ( Grid3Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid3Container"+"DivS\" data-gxgridid=\"152\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid3_Internalname, subGrid3_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            Grid3Container.AddObjectProperty("GridName", "Grid3");
         }
         else
         {
            Grid3Container.AddObjectProperty("GridName", "Grid3");
            Grid3Container.AddObjectProperty("Header", subGrid3_Header);
            Grid3Container.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            Grid3Container.AddObjectProperty("Class", "FreeStyleGrid");
            Grid3Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid3Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid3Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid3_Backcolorstyle), 1, 0, ".", "")));
            Grid3Container.AddObjectProperty("CmpContext", "");
            Grid3Container.AddObjectProperty("InMasterPage", "false");
            Grid3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid3Container.AddColumnProperties(Grid3Column);
            Grid3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid3Container.AddColumnProperties(Grid3Column);
            Grid3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid3Container.AddColumnProperties(Grid3Column);
            Grid3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid3Container.AddColumnProperties(Grid3Column);
            Grid3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid3Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlname2_Enabled), 5, 0, ".", "")));
            Grid3Container.AddColumnProperties(Grid3Column);
            Grid3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid3Container.AddColumnProperties(Grid3Column);
            Grid3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid3Container.AddColumnProperties(Grid3Column);
            Grid3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid3Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlsector1_Enabled), 5, 0, ".", "")));
            Grid3Container.AddColumnProperties(Grid3Column);
            Grid3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid3Container.AddColumnProperties(Grid3Column);
            Grid3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid3Container.AddColumnProperties(Grid3Column);
            Grid3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid3Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlsupplier1_Enabled), 5, 0, ".", "")));
            Grid3Container.AddColumnProperties(Grid3Column);
            Grid3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid3Container.AddColumnProperties(Grid3Column);
            Grid3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid3Container.AddColumnProperties(Grid3Column);
            Grid3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid3Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlbrand1_Enabled), 5, 0, ".", "")));
            Grid3Container.AddColumnProperties(Grid3Column);
            Grid3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid3Container.AddColumnProperties(Grid3Column);
            Grid3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid3Container.AddColumnProperties(Grid3Column);
            Grid3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid3Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlcostprice1_Enabled), 5, 0, ".", "")));
            Grid3Container.AddColumnProperties(Grid3Column);
            Grid3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid3Container.AddColumnProperties(Grid3Column);
            Grid3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid3Container.AddColumnProperties(Grid3Column);
            Grid3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid3Container.AddColumnProperties(Grid3Column);
            Grid3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid3Container.AddColumnProperties(Grid3Column);
            Grid3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid3Container.AddColumnProperties(Grid3Column);
            Grid3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid3Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlretailprice1_Enabled), 5, 0, ".", "")));
            Grid3Container.AddColumnProperties(Grid3Column);
            Grid3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid3Container.AddColumnProperties(Grid3Column);
            Grid3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid3Container.AddColumnProperties(Grid3Column);
            Grid3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid3Container.AddColumnProperties(Grid3Column);
            Grid3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid3Container.AddColumnProperties(Grid3Column);
            Grid3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid3Container.AddColumnProperties(Grid3Column);
            Grid3Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid3Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlwholesaleprice1_Enabled), 5, 0, ".", "")));
            Grid3Container.AddColumnProperties(Grid3Column);
            Grid3Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid3_Selectedindex), 4, 0, ".", "")));
            Grid3Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid3_Allowselection), 1, 0, ".", "")));
            Grid3Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid3_Selectioncolor), 9, 0, ".", "")));
            Grid3Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid3_Allowhovering), 1, 0, ".", "")));
            Grid3Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid3_Hoveringcolor), 9, 0, ".", "")));
            Grid3Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid3_Allowcollapsing), 1, 0, ".", "")));
            Grid3Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid3_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void StartGridControl205( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"205\">") ;
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
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlname3_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlsector2_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlsupplier2_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlbrand2_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlcostprice2_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlretailprofit1_Enabled), 5, 0, ".", "")));
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
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlwholesaleprofit1_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
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
         edtProductCostPrice_Internalname = "PRODUCTCOSTPRICE";
         edtProductRetailProfit_Internalname = "PRODUCTRETAILPROFIT";
         edtProductRetailPrice_Internalname = "PRODUCTRETAILPRICE";
         edtProductWholesaleProfit_Internalname = "PRODUCTWHOLESALEPROFIT";
         edtProductWholesalePrice_Internalname = "PRODUCTWHOLESALEPRICE";
         divTable2_Internalname = "TABLE2";
         lblTabpagecostprice_title_Internalname = "TABPAGECOSTPRICE_TITLE";
         bttUpdatecostprice_Internalname = "UPDATECOSTPRICE";
         edtavCostpricepercentage_Internalname = "vCOSTPRICEPERCENTAGE";
         Costpriceroundtop_Internalname = "COSTPRICEROUNDTOP";
         bttCostpricecancel_Internalname = "COSTPRICECANCEL";
         divTable3_Internalname = "TABLE3";
         lblTb_costpriceproductname_Internalname = "TB_COSTPRICEPRODUCTNAME";
         lblTb_costpricesupplier_Internalname = "TB_COSTPRICESUPPLIER";
         lblTb_costpricesector_Internalname = "TB_COSTPRICESECTOR";
         lblTb_costpricebrand_Internalname = "TB_COSTPRICEBRAND";
         lblTb_costpriceold_Internalname = "TB_COSTPRICEOLD";
         lblTb_costpricenew_Internalname = "TB_COSTPRICENEW";
         lblTb_costpriceretailprice_Internalname = "TB_COSTPRICERETAILPRICE";
         lblTb_costpricewholesaleprice_Internalname = "TB_COSTPRICEWHOLESALEPRICE";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         divTable7_Internalname = "TABLE7";
         edtavCtlname_Internalname = "CTLNAME";
         edtavCtlsupplier_Internalname = "CTLSUPPLIER";
         edtavCtlsector_Internalname = "CTLSECTOR";
         edtavCtlbrand_Internalname = "CTLBRAND";
         edtavCtlcostprice_Internalname = "CTLCOSTPRICE";
         edtavCtlnewcostprice_Internalname = "CTLNEWCOSTPRICE";
         edtavCtlretailprice_Internalname = "CTLRETAILPRICE";
         edtavCtlwholesaleprice_Internalname = "CTLWHOLESALEPRICE";
         bttCostpriceremove_Internalname = "COSTPRICEREMOVE";
         divGrid2table_Internalname = "GRID2TABLE";
         divTabpage1table_Internalname = "TABPAGE1TABLE";
         lblTabpage2_title_Internalname = "TABPAGE2_TITLE";
         bttUpdateprice2_Internalname = "UPDATEPRICE2";
         edtavRetailprofitpercentage_Internalname = "vRETAILPROFITPERCENTAGE";
         edtavWholesaleprofitpercentage_Internalname = "vWHOLESALEPROFITPERCENTAGE";
         Roundtop_Internalname = "ROUNDTOP";
         bttCancelupdate2_Internalname = "CANCELUPDATE2";
         edtavCtlname2_Internalname = "CTLNAME2";
         edtavCtlsector1_Internalname = "CTLSECTOR1";
         edtavCtlsupplier1_Internalname = "CTLSUPPLIER1";
         edtavCtlbrand1_Internalname = "CTLBRAND1";
         edtavCtlcostprice1_Internalname = "CTLCOSTPRICE1";
         edtavCtlretailprofit_Internalname = "CTLRETAILPROFIT";
         edtavCtlretailprice1_Internalname = "CTLRETAILPRICE1";
         edtavCtlwholesaleprofit_Internalname = "CTLWHOLESALEPROFIT";
         edtavCtlwholesaleprice1_Internalname = "CTLWHOLESALEPRICE1";
         divGrid3table_Internalname = "GRID3TABLE";
         divTable5_Internalname = "TABLE5";
         divTabpage2table_Internalname = "TABPAGE2TABLE";
         lblTabpage3_title_Internalname = "TABPAGE3_TITLE";
         bttUpdateprice3_Internalname = "UPDATEPRICE3";
         edtavPercentage_Internalname = "vPERCENTAGE";
         Roundtop_Internalname = "ROUNDTOP";
         bttCancelupdate3_Internalname = "CANCELUPDATE3";
         edtavCtlname3_Internalname = "CTLNAME3";
         edtavCtlsector2_Internalname = "CTLSECTOR2";
         edtavCtlsupplier2_Internalname = "CTLSUPPLIER2";
         edtavCtlbrand2_Internalname = "CTLBRAND2";
         edtavCtlcostprice2_Internalname = "CTLCOSTPRICE2";
         edtavCtlretailprofit1_Internalname = "CTLRETAILPROFIT1";
         edtavCtlretailprice2_Internalname = "CTLRETAILPRICE2";
         edtavCtlwholesaleprofit1_Internalname = "CTLWHOLESALEPROFIT1";
         edtavCtlwholesaleprice2_Internalname = "CTLWHOLESALEPRICE2";
         divGrid1table1_Internalname = "GRID1TABLE1";
         divTable6_Internalname = "TABLE6";
         divTabpage3table_Internalname = "TABPAGE3TABLE";
         Tab1_Internalname = "TAB1";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subAllproducts_Internalname = "ALLPRODUCTS";
         subCostpricegrid_Internalname = "COSTPRICEGRID";
         subGrid3_Internalname = "GRID3";
         subGrid1_Internalname = "GRID1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("mtaKB", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid1_Allowcollapsing = 0;
         subGrid3_Allowcollapsing = 0;
         subCostpricegrid_Allowcollapsing = 0;
         subAllproducts_Allowcollapsing = 0;
         subAllproducts_Allowselection = 0;
         subAllproducts_Header = "";
         edtavCtlwholesaleprice2_Jsonclick = "";
         edtavCtlwholesaleprice2_Visible = 1;
         edtavCtlwholesaleprice2_Enabled = 1;
         edtavCtlwholesaleprofit1_Jsonclick = "";
         edtavCtlwholesaleprofit1_Enabled = 0;
         edtavCtlretailprice2_Jsonclick = "";
         edtavCtlretailprice2_Visible = 1;
         edtavCtlretailprice2_Enabled = 1;
         edtavCtlretailprofit1_Jsonclick = "";
         edtavCtlretailprofit1_Enabled = 0;
         edtavCtlcostprice2_Jsonclick = "";
         edtavCtlcostprice2_Enabled = 0;
         edtavCtlbrand2_Jsonclick = "";
         edtavCtlbrand2_Enabled = 0;
         edtavCtlsupplier2_Jsonclick = "";
         edtavCtlsupplier2_Enabled = 0;
         edtavCtlsector2_Jsonclick = "";
         edtavCtlsector2_Enabled = 0;
         edtavCtlname3_Jsonclick = "";
         edtavCtlname3_Enabled = 0;
         subGrid1_Class = "FreeStyleGrid";
         edtavCtlwholesaleprice1_Jsonclick = "";
         edtavCtlwholesaleprice1_Enabled = 0;
         edtavCtlwholesaleprofit_Jsonclick = "";
         edtavCtlwholesaleprofit_Visible = 1;
         edtavCtlwholesaleprofit_Enabled = 1;
         edtavCtlretailprice1_Jsonclick = "";
         edtavCtlretailprice1_Enabled = 0;
         edtavCtlretailprofit_Jsonclick = "";
         edtavCtlretailprofit_Visible = 1;
         edtavCtlretailprofit_Enabled = 1;
         edtavCtlcostprice1_Jsonclick = "";
         edtavCtlcostprice1_Enabled = 0;
         edtavCtlbrand1_Jsonclick = "";
         edtavCtlbrand1_Enabled = 0;
         edtavCtlsupplier1_Jsonclick = "";
         edtavCtlsupplier1_Enabled = 0;
         edtavCtlsector1_Jsonclick = "";
         edtavCtlsector1_Enabled = 0;
         edtavCtlname2_Jsonclick = "";
         edtavCtlname2_Enabled = 0;
         subGrid3_Class = "FreeStyleGrid";
         edtavCtlwholesaleprice_Jsonclick = "";
         edtavCtlwholesaleprice_Enabled = 0;
         edtavCtlretailprice_Jsonclick = "";
         edtavCtlretailprice_Enabled = 0;
         edtavCtlnewcostprice_Jsonclick = "";
         edtavCtlnewcostprice_Visible = 1;
         edtavCtlnewcostprice_Enabled = 1;
         edtavCtlcostprice_Jsonclick = "";
         edtavCtlcostprice_Enabled = 0;
         edtavCtlbrand_Jsonclick = "";
         edtavCtlbrand_Enabled = 0;
         edtavCtlsector_Jsonclick = "";
         edtavCtlsector_Enabled = 0;
         edtavCtlsupplier_Jsonclick = "";
         edtavCtlsupplier_Enabled = 0;
         edtavCtlname_Jsonclick = "";
         edtavCtlname_Enabled = 0;
         subCostpricegrid_Class = "FreeStyleGrid";
         edtProductWholesalePrice_Jsonclick = "";
         edtProductWholesaleProfit_Jsonclick = "";
         edtProductRetailPrice_Jsonclick = "";
         edtProductRetailProfit_Jsonclick = "";
         edtProductCostPrice_Jsonclick = "";
         edtProductPrice_Jsonclick = "";
         edtSectorName_Jsonclick = "";
         edtBrandName_Jsonclick = "";
         edtSupplierName_Jsonclick = "";
         edtProductName_Jsonclick = "";
         edtProductId_Jsonclick = "";
         subAllproducts_Class = "PromptGrid";
         subAllproducts_Backcolorstyle = 0;
         subCostpricegrid_Backcolorstyle = 0;
         subGrid3_Backcolorstyle = 0;
         subGrid1_Backcolorstyle = 0;
         edtavCtlwholesaleprofit1_Enabled = -1;
         edtavCtlretailprofit1_Enabled = -1;
         edtavCtlcostprice2_Enabled = -1;
         edtavCtlbrand2_Enabled = -1;
         edtavCtlsupplier2_Enabled = -1;
         edtavCtlsector2_Enabled = -1;
         edtavCtlname3_Enabled = -1;
         edtavCtlwholesaleprice1_Enabled = -1;
         edtavCtlretailprice1_Enabled = -1;
         edtavCtlcostprice1_Enabled = -1;
         edtavCtlbrand1_Enabled = -1;
         edtavCtlsupplier1_Enabled = -1;
         edtavCtlsector1_Enabled = -1;
         edtavCtlname2_Enabled = -1;
         edtavCtlwholesaleprice_Enabled = -1;
         edtavCtlretailprice_Enabled = -1;
         edtavCtlcostprice_Enabled = -1;
         edtavCtlbrand_Enabled = -1;
         edtavCtlsector_Enabled = -1;
         edtavCtlsupplier_Enabled = -1;
         edtavCtlname_Enabled = -1;
         edtavPercentage_Jsonclick = "";
         edtavPercentage_Enabled = 1;
         edtavWholesaleprofitpercentage_Jsonclick = "";
         edtavWholesaleprofitpercentage_Enabled = 1;
         edtavRetailprofitpercentage_Jsonclick = "";
         edtavRetailprofitpercentage_Enabled = 1;
         edtavCostpricepercentage_Jsonclick = "";
         edtavCostpricepercentage_Enabled = 1;
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
         Tab1_Historymanagement = Convert.ToBoolean( 0);
         Tab1_Class = "Tab";
         Tab1_Pagecount = 3;
         Roundtop_Captionposition = "Top";
         Roundtop_Captionstyle = "";
         Roundtop_Captionclass = "col-xs-12 AttributeLabel";
         Roundtop_Enabled = Convert.ToBoolean( -1);
         Costpriceroundtop_Captionposition = "Top";
         Costpriceroundtop_Captionstyle = "";
         Costpriceroundtop_Captionclass = "col-xs-12 AttributeLabel";
         Costpriceroundtop_Enabled = Convert.ToBoolean( -1);
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "WPUpdate Price Copy1";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'GRID3_nFirstRecordOnPage'},{av:'GRID3_nEOF'},{av:'AV22ProductsSelected',fld:'vPRODUCTSSELECTED',grid:96,pic:''},{av:'nGXsfl_96_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:96},{av:'nRC_GXsfl_152',ctrl:'GRID3',prop:'GridRC',grid:152},{av:'nRC_GXsfl_205',ctrl:'GRID1',prop:'GridRC',grid:205},{av:'COSTPRICEGRID_nFirstRecordOnPage'},{av:'COSTPRICEGRID_nEOF'},{av:'AV39CostPriceProductsSelected',fld:'vCOSTPRICEPRODUCTSSELECTED',pic:''},{av:'nRC_GXsfl_96',ctrl:'COSTPRICEGRID',prop:'GridRC',grid:96},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV10Code',fld:'vCODE',pic:''},{av:'AV15Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV30Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV9Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV26Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV6newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'AV37newCostPricePercentage',fld:'vNEWCOSTPRICEPERCENTAGE',pic:'ZZZZ9.99',hsh:true},{av:'AV38newPrice',fld:'vNEWPRICE',pic:'ZZZZZZ9.99',hsh:true},{av:'AV33newPercentage',fld:'vNEWPERCENTAGE',pic:'ZZZZ9.99',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'REMOVE'","{handler:'E212I2',iparms:[{av:'AV22ProductsSelected',fld:'vPRODUCTSSELECTED',grid:96,pic:''},{av:'nGXsfl_96_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:96},{av:'GRID3_nFirstRecordOnPage'},{av:'nRC_GXsfl_152',ctrl:'GRID3',prop:'GridRC',grid:152},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_205',ctrl:'GRID1',prop:'GridRC',grid:205},{av:'AV27SelectedId',fld:'vSELECTEDID',pic:''},{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'GRID1_nEOF'},{av:'GRID3_nEOF'},{av:'COSTPRICEGRID_nFirstRecordOnPage'},{av:'COSTPRICEGRID_nEOF'},{av:'AV39CostPriceProductsSelected',fld:'vCOSTPRICEPRODUCTSSELECTED',pic:''},{av:'nRC_GXsfl_96',ctrl:'COSTPRICEGRID',prop:'GridRC',grid:96},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV10Code',fld:'vCODE',pic:''},{av:'AV15Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV30Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV9Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV26Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV6newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'AV37newCostPricePercentage',fld:'vNEWCOSTPRICEPERCENTAGE',pic:'ZZZZ9.99',hsh:true},{av:'AV38newPrice',fld:'vNEWPRICE',pic:'ZZZZZZ9.99',hsh:true},{av:'AV33newPercentage',fld:'vNEWPERCENTAGE',pic:'ZZZZ9.99',hsh:true}]");
         setEventMetadata("'REMOVE'",",oparms:[{av:'AV27SelectedId',fld:'vSELECTEDID',pic:''},{av:'AV22ProductsSelected',fld:'vPRODUCTSSELECTED',grid:96,pic:''},{av:'nGXsfl_96_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:96},{av:'GRID3_nFirstRecordOnPage'},{av:'nRC_GXsfl_152',ctrl:'GRID3',prop:'GridRC',grid:152},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_205',ctrl:'GRID1',prop:'GridRC',grid:205}]}");
         setEventMetadata("'CANCELUPDATE'","{handler:'E132I2',iparms:[{av:'AV22ProductsSelected',fld:'vPRODUCTSSELECTED',grid:96,pic:''},{av:'nGXsfl_96_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:96},{av:'GRID3_nFirstRecordOnPage'},{av:'nRC_GXsfl_152',ctrl:'GRID3',prop:'GridRC',grid:152},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_205',ctrl:'GRID1',prop:'GridRC',grid:205},{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'GRID1_nEOF'},{av:'GRID3_nEOF'},{av:'COSTPRICEGRID_nFirstRecordOnPage'},{av:'COSTPRICEGRID_nEOF'},{av:'AV39CostPriceProductsSelected',fld:'vCOSTPRICEPRODUCTSSELECTED',pic:''},{av:'nRC_GXsfl_96',ctrl:'COSTPRICEGRID',prop:'GridRC',grid:96},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV10Code',fld:'vCODE',pic:''},{av:'AV15Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV30Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV9Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV26Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV6newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'AV37newCostPricePercentage',fld:'vNEWCOSTPRICEPERCENTAGE',pic:'ZZZZ9.99',hsh:true},{av:'AV38newPrice',fld:'vNEWPRICE',pic:'ZZZZZZ9.99',hsh:true},{av:'AV33newPercentage',fld:'vNEWPERCENTAGE',pic:'ZZZZ9.99',hsh:true}]");
         setEventMetadata("'CANCELUPDATE'",",oparms:[{av:'AV18Percentage',fld:'vPERCENTAGE',pic:'ZZ9.99'},{av:'AV34CostPricePercentage',fld:'vCOSTPRICEPERCENTAGE',pic:'ZZZZ9.99'},{av:'AV22ProductsSelected',fld:'vPRODUCTSSELECTED',grid:96,pic:''},{av:'nGXsfl_96_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:96},{av:'GRID3_nFirstRecordOnPage'},{av:'nRC_GXsfl_152',ctrl:'GRID3',prop:'GridRC',grid:152},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_205',ctrl:'GRID1',prop:'GridRC',grid:205},{av:'AV27SelectedId',fld:'vSELECTEDID',pic:''},{av:'AV23ProductsSelectedAux',fld:'vPRODUCTSSELECTEDAUX',pic:''},{av:'AV28SelectedIdAux',fld:'vSELECTEDIDAUX',pic:''}]}");
         setEventMetadata("PRODUCTNAME.CLICK","{handler:'E222I2',iparms:[{av:'A15ProductId',fld:'PRODUCTID',pic:'ZZZZZ9',hsh:true},{av:'Tab1_Activepagecontrolname',ctrl:'TAB1',prop:'ActivePageControlName'},{av:'COSTPRICEGRID_nFirstRecordOnPage'},{av:'COSTPRICEGRID_nEOF'},{av:'AV39CostPriceProductsSelected',fld:'vCOSTPRICEPRODUCTSSELECTED',pic:''},{av:'nRC_GXsfl_96',ctrl:'COSTPRICEGRID',prop:'GridRC',grid:96},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV10Code',fld:'vCODE',pic:''},{av:'AV15Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV30Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV9Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV26Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV6newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'AV37newCostPricePercentage',fld:'vNEWCOSTPRICEPERCENTAGE',pic:'ZZZZ9.99',hsh:true},{av:'AV38newPrice',fld:'vNEWPRICE',pic:'ZZZZZZ9.99',hsh:true},{av:'AV33newPercentage',fld:'vNEWPERCENTAGE',pic:'ZZZZ9.99',hsh:true},{av:'AV21Product',fld:'vPRODUCT',pic:''},{av:'AV40CostPriceSelectedId',fld:'vCOSTPRICESELECTEDID',pic:''},{av:'A16ProductName',fld:'PRODUCTNAME',pic:'',hsh:true},{av:'A5SupplierName',fld:'SUPPLIERNAME',pic:''},{av:'A2BrandName',fld:'BRANDNAME',pic:''},{av:'A10SectorName',fld:'SECTORNAME',pic:''},{av:'A85ProductCostPrice',fld:'PRODUCTCOSTPRICE',pic:'ZZZZZZ9.99',hsh:true},{av:'AV35CostPriceRoundTop',fld:'vCOSTPRICEROUNDTOP',pic:''},{av:'AV23ProductsSelectedAux',fld:'vPRODUCTSSELECTEDAUX',pic:''},{av:'AV28SelectedIdAux',fld:'vSELECTEDIDAUX',pic:''},{av:'AV34CostPricePercentage',fld:'vCOSTPRICEPERCENTAGE',pic:'ZZZZ9.99'},{av:'AV17OneProduct',fld:'vONEPRODUCT',pic:''},{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'GRID3_nFirstRecordOnPage'},{av:'GRID3_nEOF'},{av:'AV22ProductsSelected',fld:'vPRODUCTSSELECTED',grid:96,pic:''},{av:'nGXsfl_96_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:96},{av:'nRC_GXsfl_152',ctrl:'GRID3',prop:'GridRC',grid:152},{av:'nRC_GXsfl_205',ctrl:'GRID1',prop:'GridRC',grid:205}]");
         setEventMetadata("PRODUCTNAME.CLICK",",oparms:[{av:'AV21Product',fld:'vPRODUCT',pic:''},{av:'AV17OneProduct',fld:'vONEPRODUCT',pic:''},{av:'AV23ProductsSelectedAux',fld:'vPRODUCTSSELECTEDAUX',pic:''},{av:'AV28SelectedIdAux',fld:'vSELECTEDIDAUX',pic:''},{av:'AV39CostPriceProductsSelected',fld:'vCOSTPRICEPRODUCTSSELECTED',pic:''},{av:'COSTPRICEGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_96',ctrl:'COSTPRICEGRID',prop:'GridRC',grid:96},{av:'AV40CostPriceSelectedId',fld:'vCOSTPRICESELECTEDID',pic:''}]}");
         setEventMetadata("'ALLPRODUCTS'","{handler:'E142I2',iparms:[{av:'AV15Name',fld:'vNAME',pic:''},{av:'AV10Code',fld:'vCODE',pic:''},{av:'dynavSupplier'},{av:'AV30Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV26Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV9Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'Tab1_Activepagecontrolname',ctrl:'TAB1',prop:'ActivePageControlName'},{av:'AV23ProductsSelectedAux',fld:'vPRODUCTSSELECTEDAUX',pic:''},{av:'AV40CostPriceSelectedId',fld:'vCOSTPRICESELECTEDID',pic:''},{av:'AV35CostPriceRoundTop',fld:'vCOSTPRICEROUNDTOP',pic:''},{av:'AV39CostPriceProductsSelected',fld:'vCOSTPRICEPRODUCTSSELECTED',pic:''},{av:'COSTPRICEGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_96',ctrl:'COSTPRICEGRID',prop:'GridRC',grid:96},{av:'AV34CostPricePercentage',fld:'vCOSTPRICEPERCENTAGE',pic:'ZZZZ9.99'},{av:'AV17OneProduct',fld:'vONEPRODUCT',pic:''},{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'GRID3_nFirstRecordOnPage'},{av:'GRID3_nEOF'},{av:'AV22ProductsSelected',fld:'vPRODUCTSSELECTED',grid:96,pic:''},{av:'nGXsfl_96_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:96},{av:'nRC_GXsfl_152',ctrl:'GRID3',prop:'GridRC',grid:152},{av:'nRC_GXsfl_205',ctrl:'GRID1',prop:'GridRC',grid:205},{av:'COSTPRICEGRID_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV6newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'AV37newCostPricePercentage',fld:'vNEWCOSTPRICEPERCENTAGE',pic:'ZZZZ9.99',hsh:true},{av:'AV38newPrice',fld:'vNEWPRICE',pic:'ZZZZZZ9.99',hsh:true},{av:'AV33newPercentage',fld:'vNEWPERCENTAGE',pic:'ZZZZ9.99',hsh:true}]");
         setEventMetadata("'ALLPRODUCTS'",",oparms:[{av:'AV23ProductsSelectedAux',fld:'vPRODUCTSSELECTEDAUX',pic:''},{av:'AV17OneProduct',fld:'vONEPRODUCT',pic:''},{av:'AV39CostPriceProductsSelected',fld:'vCOSTPRICEPRODUCTSSELECTED',pic:''},{av:'COSTPRICEGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_96',ctrl:'COSTPRICEGRID',prop:'GridRC',grid:96},{av:'AV40CostPriceSelectedId',fld:'vCOSTPRICESELECTEDID',pic:''}]}");
         setEventMetadata("VCOSTPRICEROUNDTOP.CONTROLVALUECHANGED","{handler:'E122I2',iparms:[{av:'AV35CostPriceRoundTop',fld:'vCOSTPRICEROUNDTOP',pic:''},{av:'AV39CostPriceProductsSelected',fld:'vCOSTPRICEPRODUCTSSELECTED',pic:''},{av:'COSTPRICEGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_96',ctrl:'COSTPRICEGRID',prop:'GridRC',grid:96},{av:'AV34CostPricePercentage',fld:'vCOSTPRICEPERCENTAGE',pic:'ZZZZ9.99'},{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'GRID3_nFirstRecordOnPage'},{av:'GRID3_nEOF'},{av:'AV22ProductsSelected',fld:'vPRODUCTSSELECTED',grid:96,pic:''},{av:'nGXsfl_96_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:96},{av:'nRC_GXsfl_152',ctrl:'GRID3',prop:'GridRC',grid:152},{av:'nRC_GXsfl_205',ctrl:'GRID1',prop:'GridRC',grid:205},{av:'COSTPRICEGRID_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV10Code',fld:'vCODE',pic:''},{av:'AV15Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV30Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV9Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV26Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV6newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'AV37newCostPricePercentage',fld:'vNEWCOSTPRICEPERCENTAGE',pic:'ZZZZ9.99',hsh:true},{av:'AV38newPrice',fld:'vNEWPRICE',pic:'ZZZZZZ9.99',hsh:true},{av:'AV33newPercentage',fld:'vNEWPERCENTAGE',pic:'ZZZZ9.99',hsh:true}]");
         setEventMetadata("VCOSTPRICEROUNDTOP.CONTROLVALUECHANGED",",oparms:[{av:'AV17OneProduct',fld:'vONEPRODUCT',pic:''},{av:'AV39CostPriceProductsSelected',fld:'vCOSTPRICEPRODUCTSSELECTED',pic:''},{av:'COSTPRICEGRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_96',ctrl:'COSTPRICEGRID',prop:'GridRC',grid:96}]}");
         setEventMetadata("'COSTPRICECANCEL'","{handler:'E232I2',iparms:[{av:'AV22ProductsSelected',fld:'vPRODUCTSSELECTED',grid:96,pic:''},{av:'nGXsfl_96_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:96},{av:'GRID3_nFirstRecordOnPage'},{av:'nRC_GXsfl_152',ctrl:'GRID3',prop:'GridRC',grid:152},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_205',ctrl:'GRID1',prop:'GridRC',grid:205},{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'GRID1_nEOF'},{av:'GRID3_nEOF'},{av:'COSTPRICEGRID_nFirstRecordOnPage'},{av:'COSTPRICEGRID_nEOF'},{av:'AV39CostPriceProductsSelected',fld:'vCOSTPRICEPRODUCTSSELECTED',pic:''},{av:'nRC_GXsfl_96',ctrl:'COSTPRICEGRID',prop:'GridRC',grid:96},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV10Code',fld:'vCODE',pic:''},{av:'AV15Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV30Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV9Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV26Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV6newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'AV37newCostPricePercentage',fld:'vNEWCOSTPRICEPERCENTAGE',pic:'ZZZZ9.99',hsh:true},{av:'AV38newPrice',fld:'vNEWPRICE',pic:'ZZZZZZ9.99',hsh:true},{av:'AV33newPercentage',fld:'vNEWPERCENTAGE',pic:'ZZZZ9.99',hsh:true}]");
         setEventMetadata("'COSTPRICECANCEL'",",oparms:[{av:'AV34CostPricePercentage',fld:'vCOSTPRICEPERCENTAGE',pic:'ZZZZ9.99'},{av:'AV35CostPriceRoundTop',fld:'vCOSTPRICEROUNDTOP',pic:''},{av:'AV22ProductsSelected',fld:'vPRODUCTSSELECTED',grid:96,pic:''},{av:'nGXsfl_96_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:96},{av:'GRID3_nFirstRecordOnPage'},{av:'nRC_GXsfl_152',ctrl:'GRID3',prop:'GridRC',grid:152},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_205',ctrl:'GRID1',prop:'GridRC',grid:205},{av:'AV27SelectedId',fld:'vSELECTEDID',pic:''},{av:'AV23ProductsSelectedAux',fld:'vPRODUCTSSELECTEDAUX',pic:''},{av:'AV28SelectedIdAux',fld:'vSELECTEDIDAUX',pic:''}]}");
         setEventMetadata("'COSTPRICEREMOVE'","{handler:'E162I2',iparms:[{av:'AV22ProductsSelected',fld:'vPRODUCTSSELECTED',grid:96,pic:''},{av:'nGXsfl_96_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:96},{av:'GRID3_nFirstRecordOnPage'},{av:'nRC_GXsfl_152',ctrl:'GRID3',prop:'GridRC',grid:152},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_205',ctrl:'GRID1',prop:'GridRC',grid:205},{av:'AV27SelectedId',fld:'vSELECTEDID',pic:''},{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'GRID1_nEOF'},{av:'GRID3_nEOF'},{av:'COSTPRICEGRID_nFirstRecordOnPage'},{av:'COSTPRICEGRID_nEOF'},{av:'AV39CostPriceProductsSelected',fld:'vCOSTPRICEPRODUCTSSELECTED',pic:''},{av:'nRC_GXsfl_96',ctrl:'COSTPRICEGRID',prop:'GridRC',grid:96},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV10Code',fld:'vCODE',pic:''},{av:'AV15Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV30Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV9Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV26Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV6newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'AV37newCostPricePercentage',fld:'vNEWCOSTPRICEPERCENTAGE',pic:'ZZZZ9.99',hsh:true},{av:'AV38newPrice',fld:'vNEWPRICE',pic:'ZZZZZZ9.99',hsh:true},{av:'AV33newPercentage',fld:'vNEWPERCENTAGE',pic:'ZZZZ9.99',hsh:true}]");
         setEventMetadata("'COSTPRICEREMOVE'",",oparms:[{av:'AV27SelectedId',fld:'vSELECTEDID',pic:''},{av:'AV22ProductsSelected',fld:'vPRODUCTSSELECTED',grid:96,pic:''},{av:'nGXsfl_96_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:96},{av:'GRID3_nFirstRecordOnPage'},{av:'nRC_GXsfl_152',ctrl:'GRID3',prop:'GridRC',grid:152},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_205',ctrl:'GRID1',prop:'GridRC',grid:205}]}");
         setEventMetadata("'COSTPRICEUPDATE'","{handler:'E152I2',iparms:[{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV10Code',fld:'vCODE',pic:''},{av:'AV15Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV30Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV9Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV26Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'AV6newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'AV37newCostPricePercentage',fld:'vNEWCOSTPRICEPERCENTAGE',pic:'ZZZZ9.99',hsh:true},{av:'AV38newPrice',fld:'vNEWPRICE',pic:'ZZZZZZ9.99',hsh:true},{av:'AV33newPercentage',fld:'vNEWPERCENTAGE',pic:'ZZZZ9.99',hsh:true},{av:'AV7AllOk',fld:'vALLOK',pic:''},{av:'AV22ProductsSelected',fld:'vPRODUCTSSELECTED',grid:96,pic:''},{av:'nGXsfl_96_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:96},{av:'GRID3_nFirstRecordOnPage'},{av:'nRC_GXsfl_152',ctrl:'GRID3',prop:'GridRC',grid:152},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_205',ctrl:'GRID1',prop:'GridRC',grid:205},{av:'AV27SelectedId',fld:'vSELECTEDID',pic:''},{av:'AV34CostPricePercentage',fld:'vCOSTPRICEPERCENTAGE',pic:'ZZZZ9.99'},{av:'AV18Percentage',fld:'vPERCENTAGE',pic:'ZZ9.99'},{av:'GRID1_nEOF'},{av:'GRID3_nEOF'},{av:'COSTPRICEGRID_nFirstRecordOnPage'},{av:'COSTPRICEGRID_nEOF'},{av:'AV39CostPriceProductsSelected',fld:'vCOSTPRICEPRODUCTSSELECTED',pic:''},{av:'nRC_GXsfl_96',ctrl:'COSTPRICEGRID',prop:'GridRC',grid:96}]");
         setEventMetadata("'COSTPRICEUPDATE'",",oparms:[{av:'AV17OneProduct',fld:'vONEPRODUCT',pic:''},{av:'AV21Product',fld:'vPRODUCT',pic:''},{av:'AV22ProductsSelected',fld:'vPRODUCTSSELECTED',grid:96,pic:''},{av:'nGXsfl_96_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:96},{av:'GRID3_nFirstRecordOnPage'},{av:'nRC_GXsfl_152',ctrl:'GRID3',prop:'GridRC',grid:152},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_205',ctrl:'GRID1',prop:'GridRC',grid:205},{av:'AV27SelectedId',fld:'vSELECTEDID',pic:''},{av:'AV7AllOk',fld:'vALLOK',pic:''}]}");
         setEventMetadata("'UPDATEPRICE'","{handler:'E112I1',iparms:[]");
         setEventMetadata("'UPDATEPRICE'",",oparms:[]}");
         setEventMetadata("ALLPRODUCTS_FIRSTPAGE","{handler:'suballproducts_firstpage',iparms:[{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV10Code',fld:'vCODE',pic:''},{av:'AV15Name',fld:'vNAME',pic:''},{av:'AV6newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'AV37newCostPricePercentage',fld:'vNEWCOSTPRICEPERCENTAGE',pic:'ZZZZ9.99',hsh:true},{av:'AV38newPrice',fld:'vNEWPRICE',pic:'ZZZZZZ9.99',hsh:true},{av:'AV33newPercentage',fld:'vNEWPERCENTAGE',pic:'ZZZZ9.99',hsh:true},{av:'dynavSupplier'},{av:'AV30Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV9Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV26Sector',fld:'vSECTOR',pic:'ZZZZZ9'}]");
         setEventMetadata("ALLPRODUCTS_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("ALLPRODUCTS_PREVPAGE","{handler:'suballproducts_previouspage',iparms:[{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV10Code',fld:'vCODE',pic:''},{av:'AV15Name',fld:'vNAME',pic:''},{av:'AV6newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'AV37newCostPricePercentage',fld:'vNEWCOSTPRICEPERCENTAGE',pic:'ZZZZ9.99',hsh:true},{av:'AV38newPrice',fld:'vNEWPRICE',pic:'ZZZZZZ9.99',hsh:true},{av:'AV33newPercentage',fld:'vNEWPERCENTAGE',pic:'ZZZZ9.99',hsh:true},{av:'dynavSupplier'},{av:'AV30Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV9Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV26Sector',fld:'vSECTOR',pic:'ZZZZZ9'}]");
         setEventMetadata("ALLPRODUCTS_PREVPAGE",",oparms:[]}");
         setEventMetadata("ALLPRODUCTS_NEXTPAGE","{handler:'suballproducts_nextpage',iparms:[{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV10Code',fld:'vCODE',pic:''},{av:'AV15Name',fld:'vNAME',pic:''},{av:'AV6newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'AV37newCostPricePercentage',fld:'vNEWCOSTPRICEPERCENTAGE',pic:'ZZZZ9.99',hsh:true},{av:'AV38newPrice',fld:'vNEWPRICE',pic:'ZZZZZZ9.99',hsh:true},{av:'AV33newPercentage',fld:'vNEWPERCENTAGE',pic:'ZZZZ9.99',hsh:true},{av:'dynavSupplier'},{av:'AV30Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV9Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV26Sector',fld:'vSECTOR',pic:'ZZZZZ9'}]");
         setEventMetadata("ALLPRODUCTS_NEXTPAGE",",oparms:[]}");
         setEventMetadata("ALLPRODUCTS_LASTPAGE","{handler:'suballproducts_lastpage',iparms:[{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV10Code',fld:'vCODE',pic:''},{av:'AV15Name',fld:'vNAME',pic:''},{av:'AV6newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'AV37newCostPricePercentage',fld:'vNEWCOSTPRICEPERCENTAGE',pic:'ZZZZ9.99',hsh:true},{av:'AV38newPrice',fld:'vNEWPRICE',pic:'ZZZZZZ9.99',hsh:true},{av:'AV33newPercentage',fld:'vNEWPERCENTAGE',pic:'ZZZZ9.99',hsh:true},{av:'dynavSupplier'},{av:'AV30Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV9Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV26Sector',fld:'vSECTOR',pic:'ZZZZZ9'}]");
         setEventMetadata("ALLPRODUCTS_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_COSTPRICEPERCENTAGE","{handler:'Validv_Costpricepercentage',iparms:[]");
         setEventMetadata("VALIDV_COSTPRICEPERCENTAGE",",oparms:[]}");
         setEventMetadata("VALIDV_RETAILPROFITPERCENTAGE","{handler:'Validv_Retailprofitpercentage',iparms:[]");
         setEventMetadata("VALIDV_RETAILPROFITPERCENTAGE",",oparms:[]}");
         setEventMetadata("VALIDV_WHOLESALEPROFITPERCENTAGE","{handler:'Validv_Wholesaleprofitpercentage',iparms:[]");
         setEventMetadata("VALIDV_WHOLESALEPROFITPERCENTAGE",",oparms:[]}");
         setEventMetadata("VALID_PRODUCTCOSTPRICE","{handler:'Valid_Productcostprice',iparms:[]");
         setEventMetadata("VALID_PRODUCTCOSTPRICE",",oparms:[]}");
         setEventMetadata("VALID_PRODUCTRETAILPROFIT","{handler:'Valid_Productretailprofit',iparms:[]");
         setEventMetadata("VALID_PRODUCTRETAILPROFIT",",oparms:[]}");
         setEventMetadata("VALID_PRODUCTWHOLESALEPROFIT","{handler:'Valid_Productwholesaleprofit',iparms:[]");
         setEventMetadata("VALID_PRODUCTWHOLESALEPROFIT",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Productwholesaleprice',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("VALIDV_GXV6","{handler:'Validv_Gxv6',iparms:[]");
         setEventMetadata("VALIDV_GXV6",",oparms:[]}");
         setEventMetadata("VALIDV_GXV7","{handler:'Validv_Gxv7',iparms:[]");
         setEventMetadata("VALIDV_GXV7",",oparms:[]}");
         setEventMetadata("VALIDV_GXV8","{handler:'Validv_Gxv8',iparms:[]");
         setEventMetadata("VALIDV_GXV8",",oparms:[]}");
         setEventMetadata("VALIDV_GXV9","{handler:'Validv_Gxv9',iparms:[]");
         setEventMetadata("VALIDV_GXV9",",oparms:[]}");
         setEventMetadata("VALIDV_GXV15","{handler:'Validv_Gxv15',iparms:[]");
         setEventMetadata("VALIDV_GXV15",",oparms:[]}");
         setEventMetadata("VALIDV_GXV16","{handler:'Validv_Gxv16',iparms:[]");
         setEventMetadata("VALIDV_GXV16",",oparms:[]}");
         setEventMetadata("VALIDV_GXV17","{handler:'Validv_Gxv17',iparms:[]");
         setEventMetadata("VALIDV_GXV17",",oparms:[]}");
         setEventMetadata("VALIDV_GXV18","{handler:'Validv_Gxv18',iparms:[]");
         setEventMetadata("VALIDV_GXV18",",oparms:[]}");
         setEventMetadata("VALIDV_GXV19","{handler:'Validv_Gxv19',iparms:[]");
         setEventMetadata("VALIDV_GXV19",",oparms:[]}");
         setEventMetadata("VALIDV_GXV25","{handler:'Validv_Gxv25',iparms:[]");
         setEventMetadata("VALIDV_GXV25",",oparms:[]}");
         setEventMetadata("VALIDV_GXV26","{handler:'Validv_Gxv26',iparms:[]");
         setEventMetadata("VALIDV_GXV26",",oparms:[]}");
         setEventMetadata("VALIDV_GXV27","{handler:'Validv_Gxv27',iparms:[]");
         setEventMetadata("VALIDV_GXV27",",oparms:[]}");
         setEventMetadata("VALIDV_GXV28","{handler:'Validv_Gxv28',iparms:[]");
         setEventMetadata("VALIDV_GXV28",",oparms:[]}");
         setEventMetadata("VALIDV_GXV29","{handler:'Validv_Gxv29',iparms:[]");
         setEventMetadata("VALIDV_GXV29",",oparms:[]}");
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
         Tab1_Activepagecontrolname = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV10Code = "";
         AV15Name = "";
         AV6newName = "";
         AV5newCode = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV22ProductsSelected = new GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem>( context, "SDTProductsSelectedItem", "mtaKB");
         AV39CostPriceProductsSelected = new GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem>( context, "SDTProductsSelectedItem", "mtaKB");
         AV27SelectedId = new GxSimpleCollection<int>();
         AV21Product = new SdtProduct(context);
         AV40CostPriceSelectedId = new GxSimpleCollection<int>();
         AV23ProductsSelectedAux = new GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem>( context, "SDTProductsSelectedItem", "mtaKB");
         AV28SelectedIdAux = new GxSimpleCollection<int>();
         AV17OneProduct = new SdtSDTProductsSelected_SDTProductsSelectedItem(context);
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnallproducts_Jsonclick = "";
         AllproductsContainer = new GXWebGrid( context);
         sStyleString = "";
         ucTab1 = new GXUserControl();
         lblTabpagecostprice_title_Jsonclick = "";
         bttUpdatecostprice_Jsonclick = "";
         ucCostpriceroundtop = new GXUserControl();
         bttCostpricecancel_Jsonclick = "";
         lblTb_costpriceproductname_Jsonclick = "";
         lblTb_costpricesupplier_Jsonclick = "";
         lblTb_costpricesector_Jsonclick = "";
         lblTb_costpricebrand_Jsonclick = "";
         lblTb_costpriceold_Jsonclick = "";
         lblTb_costpricenew_Jsonclick = "";
         lblTb_costpriceretailprice_Jsonclick = "";
         lblTb_costpricewholesaleprice_Jsonclick = "";
         lblTextblock1_Jsonclick = "";
         CostpricegridContainer = new GXWebGrid( context);
         lblTabpage2_title_Jsonclick = "";
         bttUpdateprice2_Jsonclick = "";
         ucRoundtop = new GXUserControl();
         bttCancelupdate2_Jsonclick = "";
         Grid3Container = new GXWebGrid( context);
         lblTabpage3_title_Jsonclick = "";
         bttUpdateprice3_Jsonclick = "";
         bttCancelupdate3_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
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
         H002I2_A4SupplierId = new int[1] ;
         H002I2_A5SupplierName = new string[] {""} ;
         H002I3_A1BrandId = new int[1] ;
         H002I3_A2BrandName = new string[] {""} ;
         H002I4_A9SectorId = new int[1] ;
         H002I4_A10SectorName = new string[] {""} ;
         lV10Code = "";
         lV15Name = "";
         A55ProductCode = "";
         H002I5_A9SectorId = new int[1] ;
         H002I5_A1BrandId = new int[1] ;
         H002I5_A4SupplierId = new int[1] ;
         H002I5_A55ProductCode = new string[] {""} ;
         H002I5_n55ProductCode = new bool[] {false} ;
         H002I5_A18ProductPrice = new decimal[1] ;
         H002I5_A10SectorName = new string[] {""} ;
         H002I5_A2BrandName = new string[] {""} ;
         H002I5_A5SupplierName = new string[] {""} ;
         H002I5_A16ProductName = new string[] {""} ;
         H002I5_A15ProductId = new int[1] ;
         H002I5_A89ProductRetailProfit = new decimal[1] ;
         H002I5_n89ProductRetailProfit = new bool[] {false} ;
         H002I5_A87ProductWholesaleProfit = new decimal[1] ;
         H002I5_n87ProductWholesaleProfit = new bool[] {false} ;
         H002I5_A85ProductCostPrice = new decimal[1] ;
         H002I6_AALLPRODUCTS_nRecordCount = new long[1] ;
         GXt_objcol_SdtSDTProductsSelected_SDTProductsSelectedItem2 = new GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem>( context, "SDTProductsSelectedItem", "mtaKB");
         AllproductsRow = new GXWebRow();
         Grid1Row = new GXWebRow();
         Grid3Row = new GXWebRow();
         CostpricegridRow = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subAllproducts_Linesclass = "";
         ROClassString = "";
         subCostpricegrid_Linesclass = "";
         bttCostpriceremove_Jsonclick = "";
         subGrid3_Linesclass = "";
         subGrid1_Linesclass = "";
         AllproductsColumn = new GXWebColumn();
         subCostpricegrid_Header = "";
         CostpricegridColumn = new GXWebColumn();
         subGrid3_Header = "";
         Grid3Column = new GXWebColumn();
         subGrid1_Header = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpupdatepricecopy1__default(),
            new Object[][] {
                new Object[] {
               H002I2_A4SupplierId, H002I2_A5SupplierName
               }
               , new Object[] {
               H002I3_A1BrandId, H002I3_A2BrandName
               }
               , new Object[] {
               H002I4_A9SectorId, H002I4_A10SectorName
               }
               , new Object[] {
               H002I5_A9SectorId, H002I5_A1BrandId, H002I5_A4SupplierId, H002I5_A55ProductCode, H002I5_n55ProductCode, H002I5_A18ProductPrice, H002I5_A10SectorName, H002I5_A2BrandName, H002I5_A5SupplierName, H002I5_A16ProductName,
               H002I5_A15ProductId, H002I5_A89ProductRetailProfit, H002I5_n89ProductRetailProfit, H002I5_A87ProductWholesaleProfit, H002I5_n87ProductWholesaleProfit, H002I5_A85ProductCostPrice
               }
               , new Object[] {
               H002I6_AALLPRODUCTS_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavCtlname_Enabled = 0;
         edtavCtlsupplier_Enabled = 0;
         edtavCtlsector_Enabled = 0;
         edtavCtlbrand_Enabled = 0;
         edtavCtlcostprice_Enabled = 0;
         edtavCtlretailprice_Enabled = 0;
         edtavCtlwholesaleprice_Enabled = 0;
         edtavCtlname2_Enabled = 0;
         edtavCtlsector1_Enabled = 0;
         edtavCtlsupplier1_Enabled = 0;
         edtavCtlbrand1_Enabled = 0;
         edtavCtlcostprice1_Enabled = 0;
         edtavCtlretailprice1_Enabled = 0;
         edtavCtlwholesaleprice1_Enabled = 0;
         edtavCtlname3_Enabled = 0;
         edtavCtlsector2_Enabled = 0;
         edtavCtlsupplier2_Enabled = 0;
         edtavCtlbrand2_Enabled = 0;
         edtavCtlcostprice2_Enabled = 0;
         edtavCtlretailprofit1_Enabled = 0;
         edtavCtlwholesaleprofit1_Enabled = 0;
      }

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
      private short AV11Count ;
      private short AV12Digit ;
      private short AV13i ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subAllproducts_Backcolorstyle ;
      private short subGrid1_Backcolorstyle ;
      private short subGrid3_Backcolorstyle ;
      private short subCostpricegrid_Backcolorstyle ;
      private short AV19Position ;
      private short GRID1_nEOF ;
      private short GRID3_nEOF ;
      private short COSTPRICEGRID_nEOF ;
      private short nGXWrapped ;
      private short subAllproducts_Backstyle ;
      private short subCostpricegrid_Backstyle ;
      private short subGrid3_Backstyle ;
      private short subGrid1_Backstyle ;
      private short subAllproducts_Titlebackstyle ;
      private short subAllproducts_Allowselection ;
      private short subAllproducts_Allowhovering ;
      private short subAllproducts_Allowcollapsing ;
      private short subAllproducts_Collapsed ;
      private short subCostpricegrid_Allowselection ;
      private short subCostpricegrid_Allowhovering ;
      private short subCostpricegrid_Allowcollapsing ;
      private short subCostpricegrid_Collapsed ;
      private short subGrid3_Allowselection ;
      private short subGrid3_Allowhovering ;
      private short subGrid3_Allowcollapsing ;
      private short subGrid3_Collapsed ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private int nRC_GXsfl_34 ;
      private int nRC_GXsfl_96 ;
      private int nRC_GXsfl_152 ;
      private int nRC_GXsfl_205 ;
      private int subAllproducts_Rows ;
      private int nGXsfl_34_idx=1 ;
      private int AV30Supplier ;
      private int AV9Brand ;
      private int AV26Sector ;
      private int nGXsfl_96_idx=1 ;
      private int nGXsfl_152_idx=1 ;
      private int nGXsfl_205_idx=1 ;
      private int AV77GXV32 ;
      private int AV78GXV33 ;
      private int AV79GXV34 ;
      private int Tab1_Pagecount ;
      private int edtavCode_Enabled ;
      private int edtavName_Enabled ;
      private int edtavCostpricepercentage_Enabled ;
      private int AV46GXV1 ;
      private int edtavRetailprofitpercentage_Enabled ;
      private int edtavWholesaleprofitpercentage_Enabled ;
      private int AV55GXV10 ;
      private int edtavPercentage_Enabled ;
      private int AV65GXV20 ;
      private int A15ProductId ;
      private int gxdynajaxindex ;
      private int subAllproducts_Islastpage ;
      private int subGrid1_Islastpage ;
      private int subGrid3_Islastpage ;
      private int subCostpricegrid_Islastpage ;
      private int edtavCtlname_Enabled ;
      private int edtavCtlsupplier_Enabled ;
      private int edtavCtlsector_Enabled ;
      private int edtavCtlbrand_Enabled ;
      private int edtavCtlcostprice_Enabled ;
      private int edtavCtlretailprice_Enabled ;
      private int edtavCtlwholesaleprice_Enabled ;
      private int edtavCtlname2_Enabled ;
      private int edtavCtlsector1_Enabled ;
      private int edtavCtlsupplier1_Enabled ;
      private int edtavCtlbrand1_Enabled ;
      private int edtavCtlcostprice1_Enabled ;
      private int edtavCtlretailprice1_Enabled ;
      private int edtavCtlwholesaleprice1_Enabled ;
      private int edtavCtlname3_Enabled ;
      private int edtavCtlsector2_Enabled ;
      private int edtavCtlsupplier2_Enabled ;
      private int edtavCtlbrand2_Enabled ;
      private int edtavCtlcostprice2_Enabled ;
      private int edtavCtlretailprofit1_Enabled ;
      private int edtavCtlwholesaleprofit1_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A4SupplierId ;
      private int A1BrandId ;
      private int A9SectorId ;
      private int nGXsfl_96_fel_idx=1 ;
      private int nGXsfl_152_fel_idx=1 ;
      private int nGXsfl_205_fel_idx=1 ;
      private int nGXsfl_152_bak_idx=1 ;
      private int nGXsfl_96_bak_idx=1 ;
      private int AV75GXV30 ;
      private int AV76GXV31 ;
      private int AV80GXV35 ;
      private int idxLst ;
      private int subAllproducts_Backcolor ;
      private int subAllproducts_Allbackcolor ;
      private int subCostpricegrid_Backcolor ;
      private int subCostpricegrid_Allbackcolor ;
      private int edtavCtlnewcostprice_Enabled ;
      private int edtavCtlnewcostprice_Visible ;
      private int subGrid3_Backcolor ;
      private int subGrid3_Allbackcolor ;
      private int edtavCtlretailprofit_Enabled ;
      private int edtavCtlretailprofit_Visible ;
      private int edtavCtlwholesaleprofit_Enabled ;
      private int edtavCtlwholesaleprofit_Visible ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int edtavCtlretailprice2_Enabled ;
      private int edtavCtlretailprice2_Visible ;
      private int edtavCtlwholesaleprice2_Enabled ;
      private int edtavCtlwholesaleprice2_Visible ;
      private int subAllproducts_Titlebackcolor ;
      private int subAllproducts_Selectedindex ;
      private int subAllproducts_Selectioncolor ;
      private int subAllproducts_Hoveringcolor ;
      private int subCostpricegrid_Selectedindex ;
      private int subCostpricegrid_Selectioncolor ;
      private int subCostpricegrid_Hoveringcolor ;
      private int subGrid3_Selectedindex ;
      private int subGrid3_Selectioncolor ;
      private int subGrid3_Hoveringcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long ALLPRODUCTS_nFirstRecordOnPage ;
      private long ALLPRODUCTS_nCurrentRecord ;
      private long COSTPRICEGRID_nCurrentRecord ;
      private long GRID3_nCurrentRecord ;
      private long GRID1_nCurrentRecord ;
      private long ALLPRODUCTS_nRecordCount ;
      private long GRID1_nFirstRecordOnPage ;
      private long GRID3_nFirstRecordOnPage ;
      private long COSTPRICEGRID_nFirstRecordOnPage ;
      private decimal AV37newCostPricePercentage ;
      private decimal AV38newPrice ;
      private decimal AV33newPercentage ;
      private decimal AV20PriceRounded ;
      private decimal AV34CostPricePercentage ;
      private decimal AV31RetailProfitPercentage ;
      private decimal AV32WholesaleProfitPercentage ;
      private decimal AV18Percentage ;
      private decimal A18ProductPrice ;
      private decimal A85ProductCostPrice ;
      private decimal A89ProductRetailProfit ;
      private decimal A90ProductRetailPrice ;
      private decimal A87ProductWholesaleProfit ;
      private decimal A88ProductWholesalePrice ;
      private decimal GXt_decimal1 ;
      private string Tab1_Activepagecontrolname ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_34_idx="0001" ;
      private string sGXsfl_96_idx="0001" ;
      private string sGXsfl_152_idx="0001" ;
      private string sGXsfl_205_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Costpriceroundtop_Captionclass ;
      private string Costpriceroundtop_Captionstyle ;
      private string Costpriceroundtop_Captionposition ;
      private string Roundtop_Captionclass ;
      private string Roundtop_Captionstyle ;
      private string Roundtop_Captionposition ;
      private string Tab1_Class ;
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
      private string Tab1_Internalname ;
      private string lblTabpagecostprice_title_Internalname ;
      private string lblTabpagecostprice_title_Jsonclick ;
      private string divTabpage1table_Internalname ;
      private string divTable3_Internalname ;
      private string bttUpdatecostprice_Internalname ;
      private string bttUpdatecostprice_Jsonclick ;
      private string edtavCostpricepercentage_Internalname ;
      private string edtavCostpricepercentage_Jsonclick ;
      private string Costpriceroundtop_Internalname ;
      private string bttCostpricecancel_Internalname ;
      private string bttCostpricecancel_Jsonclick ;
      private string divTable7_Internalname ;
      private string lblTb_costpriceproductname_Internalname ;
      private string lblTb_costpriceproductname_Jsonclick ;
      private string lblTb_costpricesupplier_Internalname ;
      private string lblTb_costpricesupplier_Jsonclick ;
      private string lblTb_costpricesector_Internalname ;
      private string lblTb_costpricesector_Jsonclick ;
      private string lblTb_costpricebrand_Internalname ;
      private string lblTb_costpricebrand_Jsonclick ;
      private string lblTb_costpriceold_Internalname ;
      private string lblTb_costpriceold_Jsonclick ;
      private string lblTb_costpricenew_Internalname ;
      private string lblTb_costpricenew_Jsonclick ;
      private string lblTb_costpriceretailprice_Internalname ;
      private string lblTb_costpriceretailprice_Jsonclick ;
      private string lblTb_costpricewholesaleprice_Internalname ;
      private string lblTb_costpricewholesaleprice_Jsonclick ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string subCostpricegrid_Internalname ;
      private string lblTabpage2_title_Internalname ;
      private string lblTabpage2_title_Jsonclick ;
      private string divTabpage2table_Internalname ;
      private string divTable5_Internalname ;
      private string bttUpdateprice2_Internalname ;
      private string bttUpdateprice2_Jsonclick ;
      private string edtavRetailprofitpercentage_Internalname ;
      private string edtavRetailprofitpercentage_Jsonclick ;
      private string edtavWholesaleprofitpercentage_Internalname ;
      private string edtavWholesaleprofitpercentage_Jsonclick ;
      private string Roundtop_Internalname ;
      private string bttCancelupdate2_Internalname ;
      private string bttCancelupdate2_Jsonclick ;
      private string subGrid3_Internalname ;
      private string lblTabpage3_title_Internalname ;
      private string lblTabpage3_title_Jsonclick ;
      private string divTabpage3table_Internalname ;
      private string divTable6_Internalname ;
      private string bttUpdateprice3_Internalname ;
      private string bttUpdateprice3_Jsonclick ;
      private string edtavPercentage_Internalname ;
      private string edtavPercentage_Jsonclick ;
      private string bttCancelupdate3_Internalname ;
      private string bttCancelupdate3_Jsonclick ;
      private string subGrid1_Internalname ;
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
      private string edtProductCostPrice_Internalname ;
      private string edtProductRetailProfit_Internalname ;
      private string edtProductRetailPrice_Internalname ;
      private string edtProductWholesaleProfit_Internalname ;
      private string edtProductWholesalePrice_Internalname ;
      private string gxwrpcisep ;
      private string scmdbuf ;
      private string edtavCtlname_Internalname ;
      private string edtavCtlsupplier_Internalname ;
      private string edtavCtlsector_Internalname ;
      private string edtavCtlbrand_Internalname ;
      private string edtavCtlcostprice_Internalname ;
      private string edtavCtlretailprice_Internalname ;
      private string edtavCtlwholesaleprice_Internalname ;
      private string edtavCtlname2_Internalname ;
      private string edtavCtlsector1_Internalname ;
      private string edtavCtlsupplier1_Internalname ;
      private string edtavCtlbrand1_Internalname ;
      private string edtavCtlcostprice1_Internalname ;
      private string edtavCtlretailprice1_Internalname ;
      private string edtavCtlwholesaleprice1_Internalname ;
      private string edtavCtlname3_Internalname ;
      private string edtavCtlsector2_Internalname ;
      private string edtavCtlsupplier2_Internalname ;
      private string edtavCtlbrand2_Internalname ;
      private string edtavCtlcostprice2_Internalname ;
      private string edtavCtlretailprofit1_Internalname ;
      private string edtavCtlwholesaleprofit1_Internalname ;
      private string sGXsfl_96_fel_idx="0001" ;
      private string sGXsfl_152_fel_idx="0001" ;
      private string sGXsfl_205_fel_idx="0001" ;
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
      private string edtProductCostPrice_Jsonclick ;
      private string edtProductRetailProfit_Jsonclick ;
      private string edtProductRetailPrice_Jsonclick ;
      private string edtProductWholesaleProfit_Jsonclick ;
      private string edtProductWholesalePrice_Jsonclick ;
      private string edtavCtlnewcostprice_Internalname ;
      private string subCostpricegrid_Class ;
      private string subCostpricegrid_Linesclass ;
      private string divGrid2table_Internalname ;
      private string edtavCtlname_Jsonclick ;
      private string edtavCtlsupplier_Jsonclick ;
      private string edtavCtlsector_Jsonclick ;
      private string edtavCtlbrand_Jsonclick ;
      private string edtavCtlcostprice_Jsonclick ;
      private string edtavCtlnewcostprice_Jsonclick ;
      private string edtavCtlretailprice_Jsonclick ;
      private string edtavCtlwholesaleprice_Jsonclick ;
      private string bttCostpriceremove_Internalname ;
      private string bttCostpriceremove_Jsonclick ;
      private string edtavCtlretailprofit_Internalname ;
      private string edtavCtlwholesaleprofit_Internalname ;
      private string subGrid3_Class ;
      private string subGrid3_Linesclass ;
      private string divGrid3table_Internalname ;
      private string edtavCtlname2_Jsonclick ;
      private string edtavCtlsector1_Jsonclick ;
      private string edtavCtlsupplier1_Jsonclick ;
      private string edtavCtlbrand1_Jsonclick ;
      private string edtavCtlcostprice1_Jsonclick ;
      private string edtavCtlretailprofit_Jsonclick ;
      private string edtavCtlretailprice1_Jsonclick ;
      private string edtavCtlwholesaleprofit_Jsonclick ;
      private string edtavCtlwholesaleprice1_Jsonclick ;
      private string edtavCtlretailprice2_Internalname ;
      private string edtavCtlwholesaleprice2_Internalname ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string divGrid1table1_Internalname ;
      private string edtavCtlname3_Jsonclick ;
      private string edtavCtlsector2_Jsonclick ;
      private string edtavCtlsupplier2_Jsonclick ;
      private string edtavCtlbrand2_Jsonclick ;
      private string edtavCtlcostprice2_Jsonclick ;
      private string edtavCtlretailprofit1_Jsonclick ;
      private string edtavCtlretailprice2_Jsonclick ;
      private string edtavCtlwholesaleprofit1_Jsonclick ;
      private string edtavCtlwholesaleprice2_Jsonclick ;
      private string subAllproducts_Header ;
      private string subCostpricegrid_Header ;
      private string subGrid3_Header ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV35CostPriceRoundTop ;
      private bool AV25RoundTop ;
      private bool AV7AllOk ;
      private bool Costpriceroundtop_Enabled ;
      private bool Roundtop_Enabled ;
      private bool Tab1_Historymanagement ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n89ProductRetailProfit ;
      private bool n87ProductWholesaleProfit ;
      private bool gxdyncontrolsrefreshing ;
      private bool bGXsfl_96_Refreshing=false ;
      private bool bGXsfl_152_Refreshing=false ;
      private bool bGXsfl_205_Refreshing=false ;
      private bool bGXsfl_34_Refreshing=false ;
      private bool n55ProductCode ;
      private bool returnInSub ;
      private bool gx_BV152 ;
      private bool gx_BV96 ;
      private string AV10Code ;
      private string AV15Name ;
      private string AV6newName ;
      private string AV5newCode ;
      private string A16ProductName ;
      private string A5SupplierName ;
      private string A2BrandName ;
      private string A10SectorName ;
      private string lV10Code ;
      private string lV15Name ;
      private string A55ProductCode ;
      private GxSimpleCollection<int> AV27SelectedId ;
      private GxSimpleCollection<int> AV40CostPriceSelectedId ;
      private GxSimpleCollection<int> AV28SelectedIdAux ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid AllproductsContainer ;
      private GXWebGrid CostpricegridContainer ;
      private GXWebGrid Grid3Container ;
      private GXWebGrid Grid1Container ;
      private GXWebRow AllproductsRow ;
      private GXWebRow Grid1Row ;
      private GXWebRow Grid3Row ;
      private GXWebRow CostpricegridRow ;
      private GXWebColumn AllproductsColumn ;
      private GXWebColumn CostpricegridColumn ;
      private GXWebColumn Grid3Column ;
      private GXWebColumn Grid1Column ;
      private GXUserControl ucTab1 ;
      private GXUserControl ucCostpriceroundtop ;
      private GXUserControl ucRoundtop ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavSupplier ;
      private GXCombobox dynavBrand ;
      private GXCombobox dynavSector ;
      private IDataStoreProvider pr_default ;
      private int[] H002I2_A4SupplierId ;
      private string[] H002I2_A5SupplierName ;
      private int[] H002I3_A1BrandId ;
      private string[] H002I3_A2BrandName ;
      private int[] H002I4_A9SectorId ;
      private string[] H002I4_A10SectorName ;
      private int[] H002I5_A9SectorId ;
      private int[] H002I5_A1BrandId ;
      private int[] H002I5_A4SupplierId ;
      private string[] H002I5_A55ProductCode ;
      private bool[] H002I5_n55ProductCode ;
      private decimal[] H002I5_A18ProductPrice ;
      private string[] H002I5_A10SectorName ;
      private string[] H002I5_A2BrandName ;
      private string[] H002I5_A5SupplierName ;
      private string[] H002I5_A16ProductName ;
      private int[] H002I5_A15ProductId ;
      private decimal[] H002I5_A89ProductRetailProfit ;
      private bool[] H002I5_n89ProductRetailProfit ;
      private decimal[] H002I5_A87ProductWholesaleProfit ;
      private bool[] H002I5_n87ProductWholesaleProfit ;
      private decimal[] H002I5_A85ProductCostPrice ;
      private long[] H002I6_AALLPRODUCTS_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> AV22ProductsSelected ;
      private GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> AV39CostPriceProductsSelected ;
      private GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> AV23ProductsSelectedAux ;
      private GXBaseCollection<SdtSDTProductsSelected_SDTProductsSelectedItem> GXt_objcol_SdtSDTProductsSelected_SDTProductsSelectedItem2 ;
      private GXWebForm Form ;
      private SdtSDTProductsSelected_SDTProductsSelectedItem AV17OneProduct ;
      private SdtProduct AV21Product ;
   }

   public class wpupdatepricecopy1__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002I5( IGxContext context ,
                                             string AV10Code ,
                                             string AV15Name ,
                                             int AV30Supplier ,
                                             int AV9Brand ,
                                             int AV26Sector ,
                                             string A55ProductCode ,
                                             string A16ProductName ,
                                             int A4SupplierId ,
                                             int A1BrandId ,
                                             int A9SectorId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[8];
         Object[] GXv_Object4 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[SectorId], T1.[BrandId], T1.[SupplierId], T1.[ProductCode], T1.[ProductPrice], T2.[SectorName], T3.[BrandName], T4.[SupplierName], T1.[ProductName], T1.[ProductId], T1.[ProductRetailProfit], T1.[ProductWholesaleProfit], T1.[ProductCostPrice]";
         sFromString = " FROM ((([Product] T1 INNER JOIN [Sector] T2 ON T2.[SectorId] = T1.[SectorId]) INNER JOIN [Brand] T3 ON T3.[BrandId] = T1.[BrandId]) INNER JOIN [Supplier] T4 ON T4.[SupplierId] = T1.[SupplierId])";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10Code)) )
         {
            AddWhere(sWhereString, "(T1.[ProductCode] like @lV10Code)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15Name)) )
         {
            AddWhere(sWhereString, "(T1.[ProductName] like @lV15Name)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (0==AV30Supplier) )
         {
            AddWhere(sWhereString, "(T1.[SupplierId] = @AV30Supplier)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV9Brand) )
         {
            AddWhere(sWhereString, "(T1.[BrandId] = @AV9Brand)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV26Sector) )
         {
            AddWhere(sWhereString, "(T1.[SectorId] = @AV26Sector)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         sOrderString += " ORDER BY T1.[ProductName]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_H002I6( IGxContext context ,
                                             string AV10Code ,
                                             string AV15Name ,
                                             int AV30Supplier ,
                                             int AV9Brand ,
                                             int AV26Sector ,
                                             string A55ProductCode ,
                                             string A16ProductName ,
                                             int A4SupplierId ,
                                             int A1BrandId ,
                                             int A9SectorId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[5];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ((([Product] T1 INNER JOIN [Sector] T3 ON T3.[SectorId] = T1.[SectorId]) INNER JOIN [Brand] T2 ON T2.[BrandId] = T1.[BrandId]) INNER JOIN [Supplier] T4 ON T4.[SupplierId] = T1.[SupplierId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10Code)) )
         {
            AddWhere(sWhereString, "(T1.[ProductCode] like @lV10Code)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15Name)) )
         {
            AddWhere(sWhereString, "(T1.[ProductName] like @lV15Name)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ! (0==AV30Supplier) )
         {
            AddWhere(sWhereString, "(T1.[SupplierId] = @AV30Supplier)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! (0==AV9Brand) )
         {
            AddWhere(sWhereString, "(T1.[BrandId] = @AV9Brand)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! (0==AV26Sector) )
         {
            AddWhere(sWhereString, "(T1.[SectorId] = @AV26Sector)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         scmdbuf += sWhereString;
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 3 :
                     return conditional_H002I5(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] );
               case 4 :
                     return conditional_H002I6(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] );
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
          Object[] prmH002I2;
          prmH002I2 = new Object[] {
          };
          Object[] prmH002I3;
          prmH002I3 = new Object[] {
          };
          Object[] prmH002I4;
          prmH002I4 = new Object[] {
          };
          Object[] prmH002I5;
          prmH002I5 = new Object[] {
          new ParDef("@lV10Code",GXType.NVarChar,100,0) ,
          new ParDef("@lV15Name",GXType.NVarChar,60,0) ,
          new ParDef("@AV30Supplier",GXType.Int32,6,0) ,
          new ParDef("@AV9Brand",GXType.Int32,6,0) ,
          new ParDef("@AV26Sector",GXType.Int32,6,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH002I6;
          prmH002I6 = new Object[] {
          new ParDef("@lV10Code",GXType.NVarChar,100,0) ,
          new ParDef("@lV15Name",GXType.NVarChar,60,0) ,
          new ParDef("@AV30Supplier",GXType.Int32,6,0) ,
          new ParDef("@AV9Brand",GXType.Int32,6,0) ,
          new ParDef("@AV26Sector",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002I2", "SELECT [SupplierId], [SupplierName] FROM [Supplier] ORDER BY [SupplierName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002I2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002I3", "SELECT [BrandId], [BrandName] FROM [Brand] ORDER BY [BrandName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002I3,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002I4", "SELECT [SectorId], [SectorName] FROM [Sector] ORDER BY [SectorName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002I4,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002I5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002I5,6, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002I6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002I6,1, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[11])[0] = rslt.getDecimal(11);
                ((bool[]) buf[12])[0] = rslt.wasNull(11);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(12);
                ((bool[]) buf[14])[0] = rslt.wasNull(12);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(13);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
