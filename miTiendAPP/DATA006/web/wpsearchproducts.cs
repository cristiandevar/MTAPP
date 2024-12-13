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
using GeneXus.Office;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class wpsearchproducts : GXDataArea
   {
      public wpsearchproducts( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public wpsearchproducts( IGxContext context )
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
         dynavSector = new GXCombobox();
         dynavBrand = new GXCombobox();
         cmbavActive = new GXCombobox();
         cmbavOrderby = new GXCombobox();
         chkavDescending = new GXCheckbox();
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
               GXDLVvSUPPLIER242( ) ;
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
               GXDLVvSECTOR242( ) ;
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
               GXDLVvBRAND242( ) ;
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
         nRC_GXsfl_76 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_76"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_76_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_76_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_76_idx = GetPar( "sGXsfl_76_idx");
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
         dynavSupplier.FromJSonString( GetNextPar( ));
         AV9Supplier = (int)(Math.Round(NumberUtil.Val( GetPar( "Supplier"), "."), 18, MidpointRounding.ToEven));
         dynavSector.FromJSonString( GetNextPar( ));
         AV8Sector = (int)(Math.Round(NumberUtil.Val( GetPar( "Sector"), "."), 18, MidpointRounding.ToEven));
         dynavBrand.FromJSonString( GetNextPar( ));
         AV5Brand = (int)(Math.Round(NumberUtil.Val( GetPar( "Brand"), "."), 18, MidpointRounding.ToEven));
         AV7Name = GetPar( "Name");
         AV13StockFrom = (int)(Math.Round(NumberUtil.Val( GetPar( "StockFrom"), "."), 18, MidpointRounding.ToEven));
         AV12StockTo = (int)(Math.Round(NumberUtil.Val( GetPar( "StockTo"), "."), 18, MidpointRounding.ToEven));
         AV14PriceFrom = NumberUtil.Val( GetPar( "PriceFrom"), ".");
         AV15PriceTo = NumberUtil.Val( GetPar( "PriceTo"), ".");
         cmbavActive.FromJSonString( GetNextPar( ));
         AV33Active = (short)(Math.Round(NumberUtil.Val( GetPar( "Active"), "."), 18, MidpointRounding.ToEven));
         cmbavOrderby.FromJSonString( GetNextPar( ));
         AV16OrderBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderBy"), "."), 18, MidpointRounding.ToEven));
         AV18Descending = StringUtil.StrToBool( GetPar( "Descending"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrAllproducts_refresh( subAllproducts_Rows, AV9Supplier, AV8Sector, AV5Brand, AV7Name, AV13StockFrom, AV12StockTo, AV14PriceFrom, AV15PriceTo, AV33Active, AV16OrderBy, AV18Descending) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrAllproducts_refresh_invoke */
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
         PA242( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START242( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpsearchproducts.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vSUPPLIER", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9Supplier), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vSECTOR", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8Sector), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vBRAND", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Brand), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vNAME", AV7Name);
         GxWebStd.gx_hidden_field( context, "GXH_vSTOCKFROM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13StockFrom), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vSTOCKTO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12StockTo), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vPRICEFROM", StringUtil.LTrim( StringUtil.NToC( AV14PriceFrom, 18, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vPRICETO", StringUtil.LTrim( StringUtil.NToC( AV15PriceTo, 18, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vACTIVE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33Active), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vORDERBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16OrderBy), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vDESCENDING", StringUtil.BoolToStr( AV18Descending));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_76", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_76), 8, 0, ".", "")));
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
            WE242( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT242( ) ;
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
         return formatLink("wpsearchproducts.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WPSearchProducts" ;
      }

      public override string GetPgmdesc( )
      {
         return "WPSearch Products" ;
      }

      protected void WB240( )
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
            GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Search/List products", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WPSearchProducts.htm");
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
            GxWebStd.gx_div_start( context, divTable5_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_76_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavSupplier, dynavSupplier_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV9Supplier), 6, 0)), 1, dynavSupplier_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavSupplier.Enabled, 0, 0, 0, "em", 0, "", "", "attribute-filter", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,16);\"", "", true, 0, "HLP_WPSearchProducts.htm");
            dynavSupplier.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV9Supplier), 6, 0));
            AssignProp("", false, dynavSupplier_Internalname, "Values", (string)(dynavSupplier.ToJavascriptSource()), true);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'" + sGXsfl_76_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavSector, dynavSector_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV8Sector), 6, 0)), 1, dynavSector_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavSector.Enabled, 0, 0, 0, "em", 0, "", "", "attribute-filter", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "", true, 0, "HLP_WPSearchProducts.htm");
            dynavSector.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV8Sector), 6, 0));
            AssignProp("", false, dynavSector_Internalname, "Values", (string)(dynavSector.ToJavascriptSource()), true);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'" + sGXsfl_76_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavBrand, dynavBrand_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV5Brand), 6, 0)), 1, dynavBrand_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavBrand.Enabled, 0, 0, 0, "em", 0, "", "", "attribute-filter", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "", true, 0, "HLP_WPSearchProducts.htm");
            dynavBrand.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV5Brand), 6, 0));
            AssignProp("", false, dynavBrand_Internalname, "Values", (string)(dynavBrand.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'" + sGXsfl_76_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavName_Internalname, AV7Name, StringUtil.RTrim( context.localUtil.Format( AV7Name, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavName_Jsonclick, 0, "attribute-filter", "", "", "", "", 1, edtavName_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Name", "left", true, "", "HLP_WPSearchProducts.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavStockfrom_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavStockfrom_Internalname, "Stock From", "col-xs-12 attribute-filterLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'" + sGXsfl_76_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavStockfrom_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13StockFrom), 6, 0, ".", "")), StringUtil.LTrim( ((edtavStockfrom_Enabled!=0) ? context.localUtil.Format( (decimal)(AV13StockFrom), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV13StockFrom), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavStockfrom_Jsonclick, 0, "attribute-filter", "", "", "", "", 1, edtavStockfrom_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Stock", "right", false, "", "HLP_WPSearchProducts.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavStockto_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavStockto_Internalname, "Stock To", "col-xs-12 attribute-filterLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'" + sGXsfl_76_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavStockto_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12StockTo), 6, 0, ".", "")), StringUtil.LTrim( ((edtavStockto_Enabled!=0) ? context.localUtil.Format( (decimal)(AV12StockTo), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV12StockTo), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavStockto_Jsonclick, 0, "attribute-filter", "", "", "", "", 1, edtavStockto_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Stock", "right", false, "", "HLP_WPSearchProducts.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavPricefrom_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPricefrom_Internalname, "Price From", "col-xs-12 attribute-filterLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'" + sGXsfl_76_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPricefrom_Internalname, StringUtil.LTrim( StringUtil.NToC( AV14PriceFrom, 18, 2, ".", "")), StringUtil.LTrim( ((edtavPricefrom_Enabled!=0) ? context.localUtil.Format( AV14PriceFrom, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV14PriceFrom, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPricefrom_Jsonclick, 0, "attribute-filter", "", "", "", "", 1, edtavPricefrom_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Price", "right", false, "", "HLP_WPSearchProducts.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavPriceto_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPriceto_Internalname, "Price To", "col-xs-12 attribute-filterLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_76_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPriceto_Internalname, StringUtil.LTrim( StringUtil.NToC( AV15PriceTo, 18, 2, ".", "")), StringUtil.LTrim( ((edtavPriceto_Enabled!=0) ? context.localUtil.Format( AV15PriceTo, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV15PriceTo, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,45);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPriceto_Jsonclick, 0, "attribute-filter", "", "", "", "", 1, edtavPriceto_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Price", "right", false, "", "HLP_WPSearchProducts.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavActive_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavActive_Internalname, "State", "col-xs-12 attribute-filterLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'" + sGXsfl_76_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavActive, cmbavActive_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV33Active), 1, 0)), 1, cmbavActive_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavActive.Enabled, 0, 0, 0, "em", 0, "", "", "attribute-filter", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"", "", true, 0, "HLP_WPSearchProducts.htm");
            cmbavActive.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV33Active), 1, 0));
            AssignProp("", false, cmbavActive_Internalname, "Values", (string)(cmbavActive.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavOrderby_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavOrderby_Internalname, "Order By", "col-xs-12 attribute-filterLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'" + sGXsfl_76_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavOrderby, cmbavOrderby_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV16OrderBy), 1, 0)), 1, cmbavOrderby_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavOrderby.Enabled, 0, 0, 0, "em", 0, "", "", "attribute-filter", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "", true, 0, "HLP_WPSearchProducts.htm");
            cmbavOrderby.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16OrderBy), 1, 0));
            AssignProp("", false, cmbavOrderby_Internalname, "Values", (string)(cmbavOrderby.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavDescending_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavDescending_Internalname, "Descending", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'" + sGXsfl_76_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavDescending_Internalname, StringUtil.BoolToStr( AV18Descending), "", "Descending", 1, chkavDescending.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(58, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,58);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2", "left", "top", "", "", "div");
            wb_table1_61_242( true) ;
         }
         else
         {
            wb_table1_61_242( false) ;
         }
         return  ;
      }

      protected void wb_table1_61_242e( bool wbgen )
      {
         if ( wbgen )
         {
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
            /*  Grid Control  */
            AllproductsContainer.SetWrapped(nGXWrapped);
            StartGridControl76( ) ;
         }
         if ( wbEnd == 76 )
         {
            wbEnd = 0;
            nRC_GXsfl_76 = (int)(nGXsfl_76_idx-1);
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
         }
         if ( wbEnd == 76 )
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
         wbLoad = true;
      }

      protected void START242( )
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
            Form.Meta.addItem("description", "WPSearch Products", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP240( ) ;
      }

      protected void WS242( )
      {
         START242( ) ;
         EVT242( ) ;
      }

      protected void EVT242( )
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
                           else if ( StringUtil.StrCmp(sEvt, "VEXPORTEXCEL.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E11242 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VEXPORTPDF.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E12242 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 4), "LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_76_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx), 4, 0), 4, "0");
                              SubsflControlProps_762( ) ;
                              A55ProductCode = cgiGet( edtProductCode_Internalname);
                              n55ProductCode = false;
                              A16ProductName = cgiGet( edtProductName_Internalname);
                              A17ProductStock = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtProductStock_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              n17ProductStock = false;
                              A85ProductCostPrice = context.localUtil.CToN( cgiGet( edtProductCostPrice_Internalname), ".", ",");
                              n85ProductCostPrice = false;
                              A89ProductRetailProfit = context.localUtil.CToN( cgiGet( edtProductRetailProfit_Internalname), ".", ",");
                              n89ProductRetailProfit = false;
                              A90ProductRetailPrice = context.localUtil.CToN( cgiGet( edtProductRetailPrice_Internalname), ".", ",");
                              A87ProductWholesaleProfit = context.localUtil.CToN( cgiGet( edtProductWholesaleProfit_Internalname), ".", ",");
                              n87ProductWholesaleProfit = false;
                              A88ProductWholesalePrice = context.localUtil.CToN( cgiGet( edtProductWholesalePrice_Internalname), ".", ",");
                              A2BrandName = cgiGet( edtBrandName_Internalname);
                              A10SectorName = cgiGet( edtSectorName_Internalname);
                              A5SupplierName = cgiGet( edtSupplierName_Internalname);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E13242 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E14242 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Supplier Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vSUPPLIER"), ".", ",") != Convert.ToDecimal( AV9Supplier )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Sector Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vSECTOR"), ".", ",") != Convert.ToDecimal( AV8Sector )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Brand Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vBRAND"), ".", ",") != Convert.ToDecimal( AV5Brand )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Name Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vNAME"), AV7Name) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Stockfrom Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vSTOCKFROM"), ".", ",") != Convert.ToDecimal( AV13StockFrom )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Stockto Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vSTOCKTO"), ".", ",") != Convert.ToDecimal( AV12StockTo )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Pricefrom Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vPRICEFROM"), ".", ",") != AV14PriceFrom )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Priceto Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vPRICETO"), ".", ",") != AV15PriceTo )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Active Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vACTIVE"), ".", ",") != Convert.ToDecimal( AV33Active )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Orderby Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDERBY"), ".", ",") != Convert.ToDecimal( AV16OrderBy )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Descending Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vDESCENDING")) != AV18Descending )
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

      protected void WE242( )
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

      protected void PA242( )
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
               GX_FocusControl = dynavSupplier_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVvSUPPLIER242( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvSUPPLIER_data242( ) ;
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

      protected void GXVvSUPPLIER_html242( )
      {
         int gxdynajaxvalue;
         GXDLVvSUPPLIER_data242( ) ;
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

      protected void GXDLVvSUPPLIER_data242( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(None)");
         /* Using cursor H00242 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00242_A4SupplierId[0]), 6, 0, ".", "")));
            gxdynajaxctrldescr.Add(H00242_A5SupplierName[0]);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void GXDLVvSECTOR242( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvSECTOR_data242( ) ;
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

      protected void GXVvSECTOR_html242( )
      {
         int gxdynajaxvalue;
         GXDLVvSECTOR_data242( ) ;
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

      protected void GXDLVvSECTOR_data242( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(None)");
         /* Using cursor H00243 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00243_A9SectorId[0]), 6, 0, ".", "")));
            gxdynajaxctrldescr.Add(H00243_A10SectorName[0]);
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void GXDLVvBRAND242( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvBRAND_data242( ) ;
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

      protected void GXVvBRAND_html242( )
      {
         int gxdynajaxvalue;
         GXDLVvBRAND_data242( ) ;
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

      protected void GXDLVvBRAND_data242( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(None)");
         /* Using cursor H00244 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00244_A1BrandId[0]), 6, 0, ".", "")));
            gxdynajaxctrldescr.Add(H00244_A2BrandName[0]);
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void gxnrAllproducts_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_762( ) ;
         while ( nGXsfl_76_idx <= nRC_GXsfl_76 )
         {
            sendrow_762( ) ;
            nGXsfl_76_idx = ((subAllproducts_Islastpage==1)&&(nGXsfl_76_idx+1>subAllproducts_fnc_Recordsperpage( )) ? 1 : nGXsfl_76_idx+1);
            sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx), 4, 0), 4, "0");
            SubsflControlProps_762( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( AllproductsContainer)) ;
         /* End function gxnrAllproducts_newrow */
      }

      protected void gxgrAllproducts_refresh( int subAllproducts_Rows ,
                                              int AV9Supplier ,
                                              int AV8Sector ,
                                              int AV5Brand ,
                                              string AV7Name ,
                                              int AV13StockFrom ,
                                              int AV12StockTo ,
                                              decimal AV14PriceFrom ,
                                              decimal AV15PriceTo ,
                                              short AV33Active ,
                                              short AV16OrderBy ,
                                              bool AV18Descending )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         ALLPRODUCTS_nCurrentRecord = 0;
         RF242( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrAllproducts_refresh */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXVvSUPPLIER_html242( ) ;
            GXVvSECTOR_html242( ) ;
            GXVvBRAND_html242( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavSupplier.ItemCount > 0 )
         {
            AV9Supplier = (int)(Math.Round(NumberUtil.Val( dynavSupplier.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV9Supplier), 6, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV9Supplier", StringUtil.LTrimStr( (decimal)(AV9Supplier), 6, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavSupplier.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV9Supplier), 6, 0));
            AssignProp("", false, dynavSupplier_Internalname, "Values", dynavSupplier.ToJavascriptSource(), true);
         }
         if ( dynavSector.ItemCount > 0 )
         {
            AV8Sector = (int)(Math.Round(NumberUtil.Val( dynavSector.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV8Sector), 6, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV8Sector", StringUtil.LTrimStr( (decimal)(AV8Sector), 6, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavSector.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV8Sector), 6, 0));
            AssignProp("", false, dynavSector_Internalname, "Values", dynavSector.ToJavascriptSource(), true);
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
         if ( cmbavActive.ItemCount > 0 )
         {
            AV33Active = (short)(Math.Round(NumberUtil.Val( cmbavActive.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV33Active), 1, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV33Active", StringUtil.Str( (decimal)(AV33Active), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavActive.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV33Active), 1, 0));
            AssignProp("", false, cmbavActive_Internalname, "Values", cmbavActive.ToJavascriptSource(), true);
         }
         if ( cmbavOrderby.ItemCount > 0 )
         {
            AV16OrderBy = (short)(Math.Round(NumberUtil.Val( cmbavOrderby.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV16OrderBy), 1, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV16OrderBy", StringUtil.Str( (decimal)(AV16OrderBy), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavOrderby.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16OrderBy), 1, 0));
            AssignProp("", false, cmbavOrderby_Internalname, "Values", cmbavOrderby.ToJavascriptSource(), true);
         }
         AV18Descending = StringUtil.StrToBool( StringUtil.BoolToStr( AV18Descending));
         AssignAttri("", false, "AV18Descending", AV18Descending);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF242( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      protected void RF242( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            AllproductsContainer.ClearRows();
         }
         wbStart = 76;
         nGXsfl_76_idx = 1;
         sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx), 4, 0), 4, "0");
         SubsflControlProps_762( ) ;
         bGXsfl_76_Refreshing = true;
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
            SubsflControlProps_762( ) ;
            GXPagingFrom2 = (int)(ALLPRODUCTS_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subAllproducts_fnc_Recordsperpage( )+1);
            pr_default.dynParam(3, new Object[]{ new Object[]{
                                                 AV9Supplier ,
                                                 AV8Sector ,
                                                 AV5Brand ,
                                                 AV7Name ,
                                                 AV13StockFrom ,
                                                 AV12StockTo ,
                                                 AV14PriceFrom ,
                                                 AV15PriceTo ,
                                                 AV33Active ,
                                                 A4SupplierId ,
                                                 A9SectorId ,
                                                 A1BrandId ,
                                                 A16ProductName ,
                                                 A17ProductStock ,
                                                 A85ProductCostPrice ,
                                                 A110ProductActive ,
                                                 AV16OrderBy ,
                                                 AV18Descending ,
                                                 A112SupplierActive } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT,
                                                 TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                                 }
            });
            lV7Name = StringUtil.Concat( StringUtil.RTrim( AV7Name), "%", "");
            /* Using cursor H00245 */
            pr_default.execute(3, new Object[] {AV9Supplier, AV8Sector, AV5Brand, lV7Name, AV13StockFrom, AV12StockTo, AV14PriceFrom, AV15PriceTo, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_76_idx = 1;
            sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx), 4, 0), 4, "0");
            SubsflControlProps_762( ) ;
            while ( ( (pr_default.getStatus(3) != 101) ) && ( ( ALLPRODUCTS_nCurrentRecord < subAllproducts_fnc_Recordsperpage( ) ) ) )
            {
               A28ProductCreatedDate = H00245_A28ProductCreatedDate[0];
               A112SupplierActive = H00245_A112SupplierActive[0];
               A110ProductActive = H00245_A110ProductActive[0];
               n110ProductActive = H00245_n110ProductActive[0];
               A1BrandId = H00245_A1BrandId[0];
               n1BrandId = H00245_n1BrandId[0];
               A9SectorId = H00245_A9SectorId[0];
               n9SectorId = H00245_n9SectorId[0];
               A4SupplierId = H00245_A4SupplierId[0];
               A5SupplierName = H00245_A5SupplierName[0];
               A10SectorName = H00245_A10SectorName[0];
               A2BrandName = H00245_A2BrandName[0];
               A17ProductStock = H00245_A17ProductStock[0];
               n17ProductStock = H00245_n17ProductStock[0];
               A16ProductName = H00245_A16ProductName[0];
               A55ProductCode = H00245_A55ProductCode[0];
               n55ProductCode = H00245_n55ProductCode[0];
               A89ProductRetailProfit = H00245_A89ProductRetailProfit[0];
               n89ProductRetailProfit = H00245_n89ProductRetailProfit[0];
               A85ProductCostPrice = H00245_A85ProductCostPrice[0];
               n85ProductCostPrice = H00245_n85ProductCostPrice[0];
               A87ProductWholesaleProfit = H00245_A87ProductWholesaleProfit[0];
               n87ProductWholesaleProfit = H00245_n87ProductWholesaleProfit[0];
               A2BrandName = H00245_A2BrandName[0];
               A10SectorName = H00245_A10SectorName[0];
               A112SupplierActive = H00245_A112SupplierActive[0];
               A5SupplierName = H00245_A5SupplierName[0];
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
               /* Execute user event: Load */
               E14242 ();
               pr_default.readNext(3);
            }
            ALLPRODUCTS_nEOF = (short)(((pr_default.getStatus(3) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "ALLPRODUCTS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(ALLPRODUCTS_nEOF), 1, 0, ".", "")));
            pr_default.close(3);
            wbEnd = 76;
            WB240( ) ;
         }
         bGXsfl_76_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes242( )
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
                                              AV9Supplier ,
                                              AV8Sector ,
                                              AV5Brand ,
                                              AV7Name ,
                                              AV13StockFrom ,
                                              AV12StockTo ,
                                              AV14PriceFrom ,
                                              AV15PriceTo ,
                                              AV33Active ,
                                              A4SupplierId ,
                                              A9SectorId ,
                                              A1BrandId ,
                                              A16ProductName ,
                                              A17ProductStock ,
                                              A85ProductCostPrice ,
                                              A110ProductActive ,
                                              AV16OrderBy ,
                                              AV18Descending ,
                                              A112SupplierActive } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV7Name = StringUtil.Concat( StringUtil.RTrim( AV7Name), "%", "");
         /* Using cursor H00246 */
         pr_default.execute(4, new Object[] {AV9Supplier, AV8Sector, AV5Brand, lV7Name, AV13StockFrom, AV12StockTo, AV14PriceFrom, AV15PriceTo});
         ALLPRODUCTS_nRecordCount = H00246_AALLPRODUCTS_nRecordCount[0];
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
            gxgrAllproducts_refresh( subAllproducts_Rows, AV9Supplier, AV8Sector, AV5Brand, AV7Name, AV13StockFrom, AV12StockTo, AV14PriceFrom, AV15PriceTo, AV33Active, AV16OrderBy, AV18Descending) ;
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
            gxgrAllproducts_refresh( subAllproducts_Rows, AV9Supplier, AV8Sector, AV5Brand, AV7Name, AV13StockFrom, AV12StockTo, AV14PriceFrom, AV15PriceTo, AV33Active, AV16OrderBy, AV18Descending) ;
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
            gxgrAllproducts_refresh( subAllproducts_Rows, AV9Supplier, AV8Sector, AV5Brand, AV7Name, AV13StockFrom, AV12StockTo, AV14PriceFrom, AV15PriceTo, AV33Active, AV16OrderBy, AV18Descending) ;
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
            gxgrAllproducts_refresh( subAllproducts_Rows, AV9Supplier, AV8Sector, AV5Brand, AV7Name, AV13StockFrom, AV12StockTo, AV14PriceFrom, AV15PriceTo, AV33Active, AV16OrderBy, AV18Descending) ;
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
            gxgrAllproducts_refresh( subAllproducts_Rows, AV9Supplier, AV8Sector, AV5Brand, AV7Name, AV13StockFrom, AV12StockTo, AV14PriceFrom, AV15PriceTo, AV33Active, AV16OrderBy, AV18Descending) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         GXVvSUPPLIER_html242( ) ;
         GXVvSECTOR_html242( ) ;
         GXVvBRAND_html242( ) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP240( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E13242 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_76 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_76"), ".", ","), 18, MidpointRounding.ToEven));
            ALLPRODUCTS_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "ALLPRODUCTS_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            ALLPRODUCTS_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "ALLPRODUCTS_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            subAllproducts_Collapsed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "ALLPRODUCTS_Collapsed"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            dynavSupplier.Name = dynavSupplier_Internalname;
            dynavSupplier.CurrentValue = cgiGet( dynavSupplier_Internalname);
            AV9Supplier = (int)(Math.Round(NumberUtil.Val( cgiGet( dynavSupplier_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV9Supplier", StringUtil.LTrimStr( (decimal)(AV9Supplier), 6, 0));
            dynavSector.Name = dynavSector_Internalname;
            dynavSector.CurrentValue = cgiGet( dynavSector_Internalname);
            AV8Sector = (int)(Math.Round(NumberUtil.Val( cgiGet( dynavSector_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV8Sector", StringUtil.LTrimStr( (decimal)(AV8Sector), 6, 0));
            dynavBrand.Name = dynavBrand_Internalname;
            dynavBrand.CurrentValue = cgiGet( dynavBrand_Internalname);
            AV5Brand = (int)(Math.Round(NumberUtil.Val( cgiGet( dynavBrand_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV5Brand", StringUtil.LTrimStr( (decimal)(AV5Brand), 6, 0));
            AV7Name = cgiGet( edtavName_Internalname);
            AssignAttri("", false, "AV7Name", AV7Name);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavStockfrom_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavStockfrom_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSTOCKFROM");
               GX_FocusControl = edtavStockfrom_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV13StockFrom = 0;
               AssignAttri("", false, "AV13StockFrom", StringUtil.LTrimStr( (decimal)(AV13StockFrom), 6, 0));
            }
            else
            {
               AV13StockFrom = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavStockfrom_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV13StockFrom", StringUtil.LTrimStr( (decimal)(AV13StockFrom), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavStockto_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavStockto_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSTOCKTO");
               GX_FocusControl = edtavStockto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12StockTo = 0;
               AssignAttri("", false, "AV12StockTo", StringUtil.LTrimStr( (decimal)(AV12StockTo), 6, 0));
            }
            else
            {
               AV12StockTo = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavStockto_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12StockTo", StringUtil.LTrimStr( (decimal)(AV12StockTo), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPricefrom_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPricefrom_Internalname), ".", ",") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPRICEFROM");
               GX_FocusControl = edtavPricefrom_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV14PriceFrom = 0;
               AssignAttri("", false, "AV14PriceFrom", StringUtil.LTrimStr( AV14PriceFrom, 18, 2));
            }
            else
            {
               AV14PriceFrom = context.localUtil.CToN( cgiGet( edtavPricefrom_Internalname), ".", ",");
               AssignAttri("", false, "AV14PriceFrom", StringUtil.LTrimStr( AV14PriceFrom, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPriceto_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPriceto_Internalname), ".", ",") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPRICETO");
               GX_FocusControl = edtavPriceto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV15PriceTo = 0;
               AssignAttri("", false, "AV15PriceTo", StringUtil.LTrimStr( AV15PriceTo, 18, 2));
            }
            else
            {
               AV15PriceTo = context.localUtil.CToN( cgiGet( edtavPriceto_Internalname), ".", ",");
               AssignAttri("", false, "AV15PriceTo", StringUtil.LTrimStr( AV15PriceTo, 18, 2));
            }
            cmbavActive.Name = cmbavActive_Internalname;
            cmbavActive.CurrentValue = cgiGet( cmbavActive_Internalname);
            AV33Active = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavActive_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV33Active", StringUtil.Str( (decimal)(AV33Active), 1, 0));
            cmbavOrderby.Name = cmbavOrderby_Internalname;
            cmbavOrderby.CurrentValue = cgiGet( cmbavOrderby_Internalname);
            AV16OrderBy = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavOrderby_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV16OrderBy", StringUtil.Str( (decimal)(AV16OrderBy), 1, 0));
            AV18Descending = StringUtil.StrToBool( cgiGet( chkavDescending_Internalname));
            AssignAttri("", false, "AV18Descending", AV18Descending);
            AV19ExportPDF = cgiGet( imgavExportpdf_Internalname);
            AV21ExportExcel = cgiGet( imgavExportexcel_Internalname);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vSUPPLIER"), ".", ",") != Convert.ToDecimal( AV9Supplier )) )
            {
               ALLPRODUCTS_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vSECTOR"), ".", ",") != Convert.ToDecimal( AV8Sector )) )
            {
               ALLPRODUCTS_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vBRAND"), ".", ",") != Convert.ToDecimal( AV5Brand )) )
            {
               ALLPRODUCTS_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vNAME"), AV7Name) != 0 )
            {
               ALLPRODUCTS_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vSTOCKFROM"), ".", ",") != Convert.ToDecimal( AV13StockFrom )) )
            {
               ALLPRODUCTS_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vSTOCKTO"), ".", ",") != Convert.ToDecimal( AV12StockTo )) )
            {
               ALLPRODUCTS_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vPRICEFROM"), ".", ",") != AV14PriceFrom )
            {
               ALLPRODUCTS_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vPRICETO"), ".", ",") != AV15PriceTo )
            {
               ALLPRODUCTS_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vACTIVE"), ".", ",") != Convert.ToDecimal( AV33Active )) )
            {
               ALLPRODUCTS_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vORDERBY"), ".", ",") != Convert.ToDecimal( AV16OrderBy )) )
            {
               ALLPRODUCTS_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vDESCENDING")) != AV18Descending )
            {
               ALLPRODUCTS_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void E12242( )
      {
         /* Exportpdf_Click Routine */
         returnInSub = false;
         /* Window Datatype Object Property */
         AV17window.Url = formatLink("alistproductsfiltered.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV7Name)),UrlEncode(StringUtil.LTrimStr(AV9Supplier,6,0)),UrlEncode(StringUtil.LTrimStr(AV8Sector,6,0)),UrlEncode(StringUtil.LTrimStr(AV5Brand,6,0)),UrlEncode(StringUtil.LTrimStr(AV13StockFrom,6,0)),UrlEncode(StringUtil.LTrimStr(AV12StockTo,6,0)),UrlEncode(StringUtil.LTrimStr(AV14PriceFrom,18,2)),UrlEncode(StringUtil.LTrimStr(AV15PriceTo,18,2)),UrlEncode(StringUtil.LTrimStr(AV16OrderBy,1,0)),UrlEncode(StringUtil.BoolToStr(AV18Descending)),UrlEncode(StringUtil.LTrimStr(AV33Active,1,0))}, new string[] {"Name","SupplierId","SectorId","BrandId","StockFrom","StockTo","PriceFrom","PriceTo","Order","Descending","Active"}) ;
         AV17window.SetReturnParms(new Object[] {"AV9Supplier","AV8Sector","AV5Brand","AV13StockFrom","AV12StockTo","AV14PriceFrom","AV15PriceTo","AV16OrderBy","AV18Descending","AV33Active",});
         AV17window.Height = 370;
         AV17window.Width = 500;
         context.NewWindow(AV17window);
         /*  Sending Event outputs  */
         cmbavActive.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV33Active), 1, 0));
         AssignProp("", false, cmbavActive_Internalname, "Values", cmbavActive.ToJavascriptSource(), true);
         cmbavOrderby.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16OrderBy), 1, 0));
         AssignProp("", false, cmbavOrderby_Internalname, "Values", cmbavOrderby.ToJavascriptSource(), true);
         dynavBrand.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV5Brand), 6, 0));
         AssignProp("", false, dynavBrand_Internalname, "Values", dynavBrand.ToJavascriptSource(), true);
         dynavSector.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV8Sector), 6, 0));
         AssignProp("", false, dynavSector_Internalname, "Values", dynavSector.ToJavascriptSource(), true);
         dynavSupplier.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV9Supplier), 6, 0));
         AssignProp("", false, dynavSupplier_Internalname, "Values", dynavSupplier.ToJavascriptSource(), true);
      }

      protected void E11242( )
      {
         /* Exportexcel_Click Routine */
         returnInSub = false;
         new listproductsfilteredexportexcel(context ).execute(  AV7Name,  AV9Supplier,  AV8Sector,  AV5Brand,  (short)(AV13StockFrom),  (short)(AV12StockTo),  (short)(Math.Round(AV14PriceFrom, 18, MidpointRounding.ToEven)),  (short)(Math.Round(AV15PriceTo, 18, MidpointRounding.ToEven)),  AV16OrderBy,  AV18Descending, ref  AV33Active, out  AV28ExcelFilename, out  AV29ErrorMessage) ;
         AssignAttri("", false, "AV33Active", StringUtil.Str( (decimal)(AV33Active), 1, 0));
         if ( StringUtil.StrCmp(AV28ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV28ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV29ErrorMessage);
         }
         /*  Sending Event outputs  */
         cmbavActive.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV33Active), 1, 0));
         AssignProp("", false, cmbavActive_Internalname, "Values", cmbavActive.ToJavascriptSource(), true);
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E13242 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E13242( )
      {
         /* Start Routine */
         returnInSub = false;
         new getcontext(context ).execute( out  AV30Context, ref  AV31AllOk) ;
         AssignAttri("", false, "AV31AllOk", AV31AllOk);
         if ( ! AV31AllOk )
         {
            AV32WebSession.Set("SecLogIn", "Error");
            CallWebObject(formatLink("wplogin.aspx") );
            context.wjLocDisableFrm = 1;
         }
         imgavExportpdf_gximage = "IconPDF";
         AssignProp("", false, imgavExportpdf_Internalname, "gximage", imgavExportpdf_gximage, true);
         AV19ExportPDF = context.GetImagePath( "ddc0efc9-6a08-4601-95f0-6f2685d9d3ba", "", context.GetTheme( ));
         AssignProp("", false, imgavExportpdf_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV19ExportPDF)) ? AV36Exportpdf_GXI : context.convertURL( context.PathToRelativeUrl( AV19ExportPDF))), true);
         AssignProp("", false, imgavExportpdf_Internalname, "SrcSet", context.GetImageSrcSet( AV19ExportPDF), true);
         AV36Exportpdf_GXI = GXDbFile.PathToUrl( context.GetImagePath( "ddc0efc9-6a08-4601-95f0-6f2685d9d3ba", "", context.GetTheme( )));
         AssignProp("", false, imgavExportpdf_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV19ExportPDF)) ? AV36Exportpdf_GXI : context.convertURL( context.PathToRelativeUrl( AV19ExportPDF))), true);
         AssignProp("", false, imgavExportpdf_Internalname, "SrcSet", context.GetImageSrcSet( AV19ExportPDF), true);
         imgavExportexcel_gximage = "IconXLS";
         AssignProp("", false, imgavExportexcel_Internalname, "gximage", imgavExportexcel_gximage, true);
         AV21ExportExcel = context.GetImagePath( "236cf8a9-2d8e-4554-a40e-171baa85151f", "", context.GetTheme( ));
         AssignProp("", false, imgavExportexcel_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV21ExportExcel)) ? AV37Exportexcel_GXI : context.convertURL( context.PathToRelativeUrl( AV21ExportExcel))), true);
         AssignProp("", false, imgavExportexcel_Internalname, "SrcSet", context.GetImageSrcSet( AV21ExportExcel), true);
         AV37Exportexcel_GXI = GXDbFile.PathToUrl( context.GetImagePath( "236cf8a9-2d8e-4554-a40e-171baa85151f", "", context.GetTheme( )));
         AssignProp("", false, imgavExportexcel_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV21ExportExcel)) ? AV37Exportexcel_GXI : context.convertURL( context.PathToRelativeUrl( AV21ExportExcel))), true);
         AssignProp("", false, imgavExportexcel_Internalname, "SrcSet", context.GetImageSrcSet( AV21ExportExcel), true);
      }

      private void E14242( )
      {
         /* Load Routine */
         returnInSub = false;
         sendrow_762( ) ;
         ALLPRODUCTS_nCurrentRecord = (long)(ALLPRODUCTS_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_76_Refreshing )
         {
            DoAjaxLoad(76, AllproductsRow);
         }
      }

      protected void wb_table1_61_242( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable1_Internalname, tblTable1_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Export List:", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "bold", 0, "", 1, 1, 0, 0, "HLP_WPSearchProducts.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Active Bitmap Variable */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
            ClassString = "Image-20" + " " + ((StringUtil.StrCmp(imgavExportpdf_gximage, "")==0) ? "" : "GX_Image_"+imgavExportpdf_gximage+"_Class");
            StyleString = "";
            AV19ExportPDF_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV19ExportPDF))&&String.IsNullOrEmpty(StringUtil.RTrim( AV36Exportpdf_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV19ExportPDF)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV19ExportPDF)) ? AV36Exportpdf_GXI : context.PathToRelativeUrl( AV19ExportPDF));
            GxWebStd.gx_bitmap( context, imgavExportpdf_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, -1, 0, "", 0, "", 0, 0, 5, imgavExportpdf_Jsonclick, "'"+""+"'"+",false,"+"'"+"EVEXPORTPDF.CLICK."+"'", StyleString, ClassString, "", "", "", "", ""+TempTags, "", "", 1, AV19ExportPDF_IsBlob, false, context.GetImageSrcSet( sImgUrl), "HLP_WPSearchProducts.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Active Bitmap Variable */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
            ClassString = "Image-20" + " " + ((StringUtil.StrCmp(imgavExportexcel_gximage, "")==0) ? "" : "GX_Image_"+imgavExportexcel_gximage+"_Class");
            StyleString = "";
            AV21ExportExcel_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV21ExportExcel))&&String.IsNullOrEmpty(StringUtil.RTrim( AV37Exportexcel_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV21ExportExcel)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV21ExportExcel)) ? AV37Exportexcel_GXI : context.PathToRelativeUrl( AV21ExportExcel));
            GxWebStd.gx_bitmap( context, imgavExportexcel_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "Export in PDF File", "", 0, -1, 0, "", 0, "", 0, 0, 5, imgavExportexcel_Jsonclick, "'"+""+"'"+",false,"+"'"+"EVEXPORTEXCEL.CLICK."+"'", StyleString, ClassString, "", "", "", "", ""+TempTags, "", "", 1, AV21ExportExcel_IsBlob, false, context.GetImageSrcSet( sImgUrl), "HLP_WPSearchProducts.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_61_242e( true) ;
         }
         else
         {
            wb_table1_61_242e( false) ;
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
         PA242( ) ;
         WS242( ) ;
         WE242( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202412223272453", true, true);
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
         context.AddJavascriptSource("wpsearchproducts.js", "?202412223272453", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_762( )
      {
         edtProductCode_Internalname = "PRODUCTCODE_"+sGXsfl_76_idx;
         edtProductName_Internalname = "PRODUCTNAME_"+sGXsfl_76_idx;
         edtProductStock_Internalname = "PRODUCTSTOCK_"+sGXsfl_76_idx;
         edtProductCostPrice_Internalname = "PRODUCTCOSTPRICE_"+sGXsfl_76_idx;
         edtProductRetailProfit_Internalname = "PRODUCTRETAILPROFIT_"+sGXsfl_76_idx;
         edtProductRetailPrice_Internalname = "PRODUCTRETAILPRICE_"+sGXsfl_76_idx;
         edtProductWholesaleProfit_Internalname = "PRODUCTWHOLESALEPROFIT_"+sGXsfl_76_idx;
         edtProductWholesalePrice_Internalname = "PRODUCTWHOLESALEPRICE_"+sGXsfl_76_idx;
         edtBrandName_Internalname = "BRANDNAME_"+sGXsfl_76_idx;
         edtSectorName_Internalname = "SECTORNAME_"+sGXsfl_76_idx;
         edtSupplierName_Internalname = "SUPPLIERNAME_"+sGXsfl_76_idx;
      }

      protected void SubsflControlProps_fel_762( )
      {
         edtProductCode_Internalname = "PRODUCTCODE_"+sGXsfl_76_fel_idx;
         edtProductName_Internalname = "PRODUCTNAME_"+sGXsfl_76_fel_idx;
         edtProductStock_Internalname = "PRODUCTSTOCK_"+sGXsfl_76_fel_idx;
         edtProductCostPrice_Internalname = "PRODUCTCOSTPRICE_"+sGXsfl_76_fel_idx;
         edtProductRetailProfit_Internalname = "PRODUCTRETAILPROFIT_"+sGXsfl_76_fel_idx;
         edtProductRetailPrice_Internalname = "PRODUCTRETAILPRICE_"+sGXsfl_76_fel_idx;
         edtProductWholesaleProfit_Internalname = "PRODUCTWHOLESALEPROFIT_"+sGXsfl_76_fel_idx;
         edtProductWholesalePrice_Internalname = "PRODUCTWHOLESALEPRICE_"+sGXsfl_76_fel_idx;
         edtBrandName_Internalname = "BRANDNAME_"+sGXsfl_76_fel_idx;
         edtSectorName_Internalname = "SECTORNAME_"+sGXsfl_76_fel_idx;
         edtSupplierName_Internalname = "SUPPLIERNAME_"+sGXsfl_76_fel_idx;
      }

      protected void sendrow_762( )
      {
         SubsflControlProps_762( ) ;
         WB240( ) ;
         if ( ( 5 * 1 == 0 ) || ( nGXsfl_76_idx <= subAllproducts_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_76_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_76_idx+"\">") ;
            }
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductCode_Internalname,(string)A55ProductCode,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductCode_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)76,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusUnanimo\\Code",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductName_Internalname,(string)A16ProductName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)76,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductStock_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A17ProductStock), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A17ProductStock), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductStock_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)76,(short)0,(short)-1,(short)0,(bool)true,(string)"Stock",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductCostPrice_Internalname,StringUtil.LTrim( StringUtil.NToC( A85ProductCostPrice, 18, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A85ProductCostPrice, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductCostPrice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)76,(short)0,(short)-1,(short)0,(bool)true,(string)"Price",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductRetailProfit_Internalname,StringUtil.LTrim( StringUtil.NToC( A89ProductRetailProfit, 8, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A89ProductRetailProfit, "ZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductRetailProfit_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)76,(short)0,(short)-1,(short)0,(bool)true,(string)"Percentage",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductRetailPrice_Internalname,StringUtil.LTrim( StringUtil.NToC( A90ProductRetailPrice, 18, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A90ProductRetailPrice, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductRetailPrice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)76,(short)0,(short)-1,(short)0,(bool)true,(string)"Price",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductWholesaleProfit_Internalname,StringUtil.LTrim( StringUtil.NToC( A87ProductWholesaleProfit, 8, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A87ProductWholesaleProfit, "ZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductWholesaleProfit_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)76,(short)0,(short)-1,(short)0,(bool)true,(string)"Percentage",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductWholesalePrice_Internalname,StringUtil.LTrim( StringUtil.NToC( A88ProductWholesalePrice, 18, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A88ProductWholesalePrice, "ZZZZZZZZZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductWholesalePrice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)76,(short)0,(short)-1,(short)0,(bool)true,(string)"Price",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtBrandName_Internalname,(string)A2BrandName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtBrandName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)76,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSectorName_Internalname,(string)A10SectorName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSectorName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)76,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSupplierName_Internalname,(string)A5SupplierName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSupplierName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)76,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes242( ) ;
            AllproductsContainer.AddRow(AllproductsRow);
            nGXsfl_76_idx = ((subAllproducts_Islastpage==1)&&(nGXsfl_76_idx+1>subAllproducts_fnc_Recordsperpage( )) ? 1 : nGXsfl_76_idx+1);
            sGXsfl_76_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_76_idx), 4, 0), 4, "0");
            SubsflControlProps_762( ) ;
         }
         /* End function sendrow_762 */
      }

      protected void init_web_controls( )
      {
         dynavSupplier.Name = "vSUPPLIER";
         dynavSupplier.WebTags = "";
         dynavSector.Name = "vSECTOR";
         dynavSector.WebTags = "";
         dynavBrand.Name = "vBRAND";
         dynavBrand.WebTags = "";
         cmbavActive.Name = "vACTIVE";
         cmbavActive.WebTags = "";
         cmbavActive.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(0), 1, 0)), "(None)", 0);
         cmbavActive.addItem("1", "Active", 0);
         cmbavActive.addItem("2", "Deactive", 0);
         if ( cmbavActive.ItemCount > 0 )
         {
            AV33Active = (short)(Math.Round(NumberUtil.Val( cmbavActive.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV33Active), 1, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV33Active", StringUtil.Str( (decimal)(AV33Active), 1, 0));
         }
         cmbavOrderby.Name = "vORDERBY";
         cmbavOrderby.WebTags = "";
         cmbavOrderby.addItem("1", "Name", 0);
         cmbavOrderby.addItem("2", "Supplier", 0);
         cmbavOrderby.addItem("3", "Brand", 0);
         cmbavOrderby.addItem("4", "Sector", 0);
         cmbavOrderby.addItem("5", "Stock", 0);
         cmbavOrderby.addItem("6", "Cost Price", 0);
         cmbavOrderby.addItem("9", "Registered", 0);
         if ( cmbavOrderby.ItemCount > 0 )
         {
            AV16OrderBy = (short)(Math.Round(NumberUtil.Val( cmbavOrderby.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV16OrderBy), 1, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV16OrderBy", StringUtil.Str( (decimal)(AV16OrderBy), 1, 0));
         }
         chkavDescending.Name = "vDESCENDING";
         chkavDescending.WebTags = "";
         chkavDescending.Caption = "";
         AssignProp("", false, chkavDescending_Internalname, "TitleCaption", chkavDescending.Caption, true);
         chkavDescending.CheckedValue = "false";
         AV18Descending = StringUtil.StrToBool( StringUtil.BoolToStr( AV18Descending));
         AssignAttri("", false, "AV18Descending", AV18Descending);
         /* End function init_web_controls */
      }

      protected void StartGridControl76( )
      {
         if ( AllproductsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"AllproductsContainer"+"DivS\" data-gxgridid=\"76\">") ;
            sStyleString = "";
            if ( subAllproducts_Collapsed != 0 )
            {
               sStyleString += "display:none;";
            }
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
            context.SendWebValue( "Cost Price") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "R. Profit") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "R. Price") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "W. Profit") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "W. Price") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Brand") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Sector") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Supplier") ;
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
            AllproductsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A55ProductCode));
            AllproductsContainer.AddColumnProperties(AllproductsColumn);
            AllproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A16ProductName));
            AllproductsContainer.AddColumnProperties(AllproductsColumn);
            AllproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A17ProductStock), 6, 0, ".", ""))));
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
            AllproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A87ProductWholesaleProfit, 8, 2, ".", ""))));
            AllproductsContainer.AddColumnProperties(AllproductsColumn);
            AllproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A88ProductWholesalePrice, 18, 2, ".", ""))));
            AllproductsContainer.AddColumnProperties(AllproductsColumn);
            AllproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A2BrandName));
            AllproductsContainer.AddColumnProperties(AllproductsColumn);
            AllproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A10SectorName));
            AllproductsContainer.AddColumnProperties(AllproductsColumn);
            AllproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A5SupplierName));
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

      protected void init_default_properties( )
      {
         lblTextblock2_Internalname = "TEXTBLOCK2";
         dynavSupplier_Internalname = "vSUPPLIER";
         dynavSector_Internalname = "vSECTOR";
         dynavBrand_Internalname = "vBRAND";
         edtavName_Internalname = "vNAME";
         edtavStockfrom_Internalname = "vSTOCKFROM";
         edtavStockto_Internalname = "vSTOCKTO";
         edtavPricefrom_Internalname = "vPRICEFROM";
         edtavPriceto_Internalname = "vPRICETO";
         cmbavActive_Internalname = "vACTIVE";
         cmbavOrderby_Internalname = "vORDERBY";
         chkavDescending_Internalname = "vDESCENDING";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         imgavExportpdf_Internalname = "vEXPORTPDF";
         imgavExportexcel_Internalname = "vEXPORTEXCEL";
         tblTable1_Internalname = "TABLE1";
         divTable5_Internalname = "TABLE5";
         edtProductCode_Internalname = "PRODUCTCODE";
         edtProductName_Internalname = "PRODUCTNAME";
         edtProductStock_Internalname = "PRODUCTSTOCK";
         edtProductCostPrice_Internalname = "PRODUCTCOSTPRICE";
         edtProductRetailProfit_Internalname = "PRODUCTRETAILPROFIT";
         edtProductRetailPrice_Internalname = "PRODUCTRETAILPRICE";
         edtProductWholesaleProfit_Internalname = "PRODUCTWHOLESALEPROFIT";
         edtProductWholesalePrice_Internalname = "PRODUCTWHOLESALEPRICE";
         edtBrandName_Internalname = "BRANDNAME";
         edtSectorName_Internalname = "SECTORNAME";
         edtSupplierName_Internalname = "SUPPLIERNAME";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subAllproducts_Internalname = "ALLPRODUCTS";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("mtaKB", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subAllproducts_Allowcollapsing = 1;
         subAllproducts_Allowselection = 0;
         subAllproducts_Header = "";
         chkavDescending.Caption = "Descending";
         edtSupplierName_Jsonclick = "";
         edtSectorName_Jsonclick = "";
         edtBrandName_Jsonclick = "";
         edtProductWholesalePrice_Jsonclick = "";
         edtProductWholesaleProfit_Jsonclick = "";
         edtProductRetailPrice_Jsonclick = "";
         edtProductRetailProfit_Jsonclick = "";
         edtProductCostPrice_Jsonclick = "";
         edtProductStock_Jsonclick = "";
         edtProductName_Jsonclick = "";
         edtProductCode_Jsonclick = "";
         subAllproducts_Class = "PromptGrid";
         subAllproducts_Backcolorstyle = 0;
         imgavExportexcel_Jsonclick = "";
         imgavExportpdf_Jsonclick = "";
         imgavExportexcel_gximage = "";
         imgavExportpdf_gximage = "";
         chkavDescending.Enabled = 1;
         cmbavOrderby_Jsonclick = "";
         cmbavOrderby.Enabled = 1;
         cmbavActive_Jsonclick = "";
         cmbavActive.Enabled = 1;
         edtavPriceto_Jsonclick = "";
         edtavPriceto_Enabled = 1;
         edtavPricefrom_Jsonclick = "";
         edtavPricefrom_Enabled = 1;
         edtavStockto_Jsonclick = "";
         edtavStockto_Enabled = 1;
         edtavStockfrom_Jsonclick = "";
         edtavStockfrom_Enabled = 1;
         edtavName_Jsonclick = "";
         edtavName_Enabled = 1;
         dynavBrand_Jsonclick = "";
         dynavBrand.Enabled = 1;
         dynavSector_Jsonclick = "";
         dynavSector.Enabled = 1;
         dynavSupplier_Jsonclick = "";
         dynavSupplier.Enabled = 1;
         subAllproducts_Collapsed = 0;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "WPSearch Products";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV7Name',fld:'vNAME',pic:''},{av:'AV13StockFrom',fld:'vSTOCKFROM',pic:'ZZZZZ9'},{av:'AV12StockTo',fld:'vSTOCKTO',pic:'ZZZZZ9'},{av:'AV14PriceFrom',fld:'vPRICEFROM',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV15PriceTo',fld:'vPRICETO',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'cmbavActive'},{av:'AV33Active',fld:'vACTIVE',pic:'9'},{av:'cmbavOrderby'},{av:'AV16OrderBy',fld:'vORDERBY',pic:'9'},{av:'dynavSupplier'},{av:'AV9Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV8Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV5Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'AV18Descending',fld:'vDESCENDING',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VEXPORTPDF.CLICK","{handler:'E12242',iparms:[{av:'AV7Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV9Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV8Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV5Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'AV13StockFrom',fld:'vSTOCKFROM',pic:'ZZZZZ9'},{av:'AV12StockTo',fld:'vSTOCKTO',pic:'ZZZZZ9'},{av:'AV14PriceFrom',fld:'vPRICEFROM',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV15PriceTo',fld:'vPRICETO',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'cmbavOrderby'},{av:'AV16OrderBy',fld:'vORDERBY',pic:'9'},{av:'AV18Descending',fld:'vDESCENDING',pic:''},{av:'cmbavActive'},{av:'AV33Active',fld:'vACTIVE',pic:'9'}]");
         setEventMetadata("VEXPORTPDF.CLICK",",oparms:[{av:'cmbavActive'},{av:'AV33Active',fld:'vACTIVE',pic:'9'},{av:'AV18Descending',fld:'vDESCENDING',pic:''},{av:'cmbavOrderby'},{av:'AV16OrderBy',fld:'vORDERBY',pic:'9'},{av:'AV15PriceTo',fld:'vPRICETO',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV14PriceFrom',fld:'vPRICEFROM',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV12StockTo',fld:'vSTOCKTO',pic:'ZZZZZ9'},{av:'AV13StockFrom',fld:'vSTOCKFROM',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV5Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV8Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'dynavSupplier'},{av:'AV9Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'}]}");
         setEventMetadata("VEXPORTEXCEL.CLICK","{handler:'E11242',iparms:[{av:'AV7Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV9Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV8Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV5Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'AV13StockFrom',fld:'vSTOCKFROM',pic:'ZZZZZ9'},{av:'AV12StockTo',fld:'vSTOCKTO',pic:'ZZZZZ9'},{av:'AV14PriceFrom',fld:'vPRICEFROM',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV15PriceTo',fld:'vPRICETO',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'cmbavOrderby'},{av:'AV16OrderBy',fld:'vORDERBY',pic:'9'},{av:'AV18Descending',fld:'vDESCENDING',pic:''},{av:'cmbavActive'},{av:'AV33Active',fld:'vACTIVE',pic:'9'}]");
         setEventMetadata("VEXPORTEXCEL.CLICK",",oparms:[{av:'cmbavActive'},{av:'AV33Active',fld:'vACTIVE',pic:'9'}]}");
         setEventMetadata("ALLPRODUCTS_FIRSTPAGE","{handler:'suballproducts_firstpage',iparms:[{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV7Name',fld:'vNAME',pic:''},{av:'AV13StockFrom',fld:'vSTOCKFROM',pic:'ZZZZZ9'},{av:'AV12StockTo',fld:'vSTOCKTO',pic:'ZZZZZ9'},{av:'AV14PriceFrom',fld:'vPRICEFROM',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV15PriceTo',fld:'vPRICETO',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'cmbavActive'},{av:'AV33Active',fld:'vACTIVE',pic:'9'},{av:'cmbavOrderby'},{av:'AV16OrderBy',fld:'vORDERBY',pic:'9'},{av:'dynavSupplier'},{av:'AV9Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV8Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV5Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'AV18Descending',fld:'vDESCENDING',pic:''}]");
         setEventMetadata("ALLPRODUCTS_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("ALLPRODUCTS_PREVPAGE","{handler:'suballproducts_previouspage',iparms:[{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV7Name',fld:'vNAME',pic:''},{av:'AV13StockFrom',fld:'vSTOCKFROM',pic:'ZZZZZ9'},{av:'AV12StockTo',fld:'vSTOCKTO',pic:'ZZZZZ9'},{av:'AV14PriceFrom',fld:'vPRICEFROM',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV15PriceTo',fld:'vPRICETO',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'cmbavActive'},{av:'AV33Active',fld:'vACTIVE',pic:'9'},{av:'cmbavOrderby'},{av:'AV16OrderBy',fld:'vORDERBY',pic:'9'},{av:'dynavSupplier'},{av:'AV9Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV8Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV5Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'AV18Descending',fld:'vDESCENDING',pic:''}]");
         setEventMetadata("ALLPRODUCTS_PREVPAGE",",oparms:[]}");
         setEventMetadata("ALLPRODUCTS_NEXTPAGE","{handler:'suballproducts_nextpage',iparms:[{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV7Name',fld:'vNAME',pic:''},{av:'AV13StockFrom',fld:'vSTOCKFROM',pic:'ZZZZZ9'},{av:'AV12StockTo',fld:'vSTOCKTO',pic:'ZZZZZ9'},{av:'AV14PriceFrom',fld:'vPRICEFROM',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV15PriceTo',fld:'vPRICETO',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'cmbavActive'},{av:'AV33Active',fld:'vACTIVE',pic:'9'},{av:'cmbavOrderby'},{av:'AV16OrderBy',fld:'vORDERBY',pic:'9'},{av:'dynavSupplier'},{av:'AV9Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV8Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV5Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'AV18Descending',fld:'vDESCENDING',pic:''}]");
         setEventMetadata("ALLPRODUCTS_NEXTPAGE",",oparms:[]}");
         setEventMetadata("ALLPRODUCTS_LASTPAGE","{handler:'suballproducts_lastpage',iparms:[{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV7Name',fld:'vNAME',pic:''},{av:'AV13StockFrom',fld:'vSTOCKFROM',pic:'ZZZZZ9'},{av:'AV12StockTo',fld:'vSTOCKTO',pic:'ZZZZZ9'},{av:'AV14PriceFrom',fld:'vPRICEFROM',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV15PriceTo',fld:'vPRICETO',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'cmbavActive'},{av:'AV33Active',fld:'vACTIVE',pic:'9'},{av:'cmbavOrderby'},{av:'AV16OrderBy',fld:'vORDERBY',pic:'9'},{av:'dynavSupplier'},{av:'AV9Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavSector'},{av:'AV8Sector',fld:'vSECTOR',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV5Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'AV18Descending',fld:'vDESCENDING',pic:''}]");
         setEventMetadata("ALLPRODUCTS_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_PRICEFROM","{handler:'Validv_Pricefrom',iparms:[]");
         setEventMetadata("VALIDV_PRICEFROM",",oparms:[]}");
         setEventMetadata("VALIDV_PRICETO","{handler:'Validv_Priceto',iparms:[]");
         setEventMetadata("VALIDV_PRICETO",",oparms:[]}");
         setEventMetadata("VALIDV_ORDERBY","{handler:'Validv_Orderby',iparms:[]");
         setEventMetadata("VALIDV_ORDERBY",",oparms:[]}");
         setEventMetadata("VALID_PRODUCTCOSTPRICE","{handler:'Valid_Productcostprice',iparms:[]");
         setEventMetadata("VALID_PRODUCTCOSTPRICE",",oparms:[]}");
         setEventMetadata("VALID_PRODUCTRETAILPROFIT","{handler:'Valid_Productretailprofit',iparms:[]");
         setEventMetadata("VALID_PRODUCTRETAILPROFIT",",oparms:[]}");
         setEventMetadata("VALID_PRODUCTWHOLESALEPROFIT","{handler:'Valid_Productwholesaleprofit',iparms:[]");
         setEventMetadata("VALID_PRODUCTWHOLESALEPROFIT",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Suppliername',iparms:[]");
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
         AV7Name = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTextblock2_Jsonclick = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         AllproductsContainer = new GXWebGrid( context);
         sStyleString = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A55ProductCode = "";
         A16ProductName = "";
         A2BrandName = "";
         A10SectorName = "";
         A5SupplierName = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         scmdbuf = "";
         H00242_A4SupplierId = new int[1] ;
         H00242_A5SupplierName = new string[] {""} ;
         H00243_A9SectorId = new int[1] ;
         H00243_n9SectorId = new bool[] {false} ;
         H00243_A10SectorName = new string[] {""} ;
         H00244_A1BrandId = new int[1] ;
         H00244_n1BrandId = new bool[] {false} ;
         H00244_A2BrandName = new string[] {""} ;
         lV7Name = "";
         H00245_A15ProductId = new int[1] ;
         H00245_A28ProductCreatedDate = new DateTime[] {DateTime.MinValue} ;
         H00245_A112SupplierActive = new bool[] {false} ;
         H00245_A110ProductActive = new bool[] {false} ;
         H00245_n110ProductActive = new bool[] {false} ;
         H00245_A1BrandId = new int[1] ;
         H00245_n1BrandId = new bool[] {false} ;
         H00245_A9SectorId = new int[1] ;
         H00245_n9SectorId = new bool[] {false} ;
         H00245_A4SupplierId = new int[1] ;
         H00245_A5SupplierName = new string[] {""} ;
         H00245_A10SectorName = new string[] {""} ;
         H00245_A2BrandName = new string[] {""} ;
         H00245_A17ProductStock = new int[1] ;
         H00245_n17ProductStock = new bool[] {false} ;
         H00245_A16ProductName = new string[] {""} ;
         H00245_A55ProductCode = new string[] {""} ;
         H00245_n55ProductCode = new bool[] {false} ;
         H00245_A89ProductRetailProfit = new decimal[1] ;
         H00245_n89ProductRetailProfit = new bool[] {false} ;
         H00245_A85ProductCostPrice = new decimal[1] ;
         H00245_n85ProductCostPrice = new bool[] {false} ;
         H00245_A87ProductWholesaleProfit = new decimal[1] ;
         H00245_n87ProductWholesaleProfit = new bool[] {false} ;
         A28ProductCreatedDate = DateTime.MinValue;
         H00246_AALLPRODUCTS_nRecordCount = new long[1] ;
         AV19ExportPDF = "";
         AV21ExportExcel = "";
         AV17window = new GXWindow();
         AV28ExcelFilename = "";
         AV29ErrorMessage = "";
         AV30Context = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         AV32WebSession = context.GetSession();
         AV36Exportpdf_GXI = "";
         AV37Exportexcel_GXI = "";
         AllproductsRow = new GXWebRow();
         lblTextblock1_Jsonclick = "";
         sImgUrl = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subAllproducts_Linesclass = "";
         ROClassString = "";
         AllproductsColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpsearchproducts__default(),
            new Object[][] {
                new Object[] {
               H00242_A4SupplierId, H00242_A5SupplierName
               }
               , new Object[] {
               H00243_A9SectorId, H00243_A10SectorName
               }
               , new Object[] {
               H00244_A1BrandId, H00244_A2BrandName
               }
               , new Object[] {
               H00245_A15ProductId, H00245_A28ProductCreatedDate, H00245_A112SupplierActive, H00245_A110ProductActive, H00245_n110ProductActive, H00245_A1BrandId, H00245_n1BrandId, H00245_A9SectorId, H00245_n9SectorId, H00245_A4SupplierId,
               H00245_A5SupplierName, H00245_A10SectorName, H00245_A2BrandName, H00245_A17ProductStock, H00245_n17ProductStock, H00245_A16ProductName, H00245_A55ProductCode, H00245_n55ProductCode, H00245_A89ProductRetailProfit, H00245_n89ProductRetailProfit,
               H00245_A85ProductCostPrice, H00245_n85ProductCostPrice, H00245_A87ProductWholesaleProfit, H00245_n87ProductWholesaleProfit
               }
               , new Object[] {
               H00246_AALLPRODUCTS_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short ALLPRODUCTS_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV33Active ;
      private short AV16OrderBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short subAllproducts_Collapsed ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subAllproducts_Backcolorstyle ;
      private short nGXWrapped ;
      private short subAllproducts_Backstyle ;
      private short subAllproducts_Titlebackstyle ;
      private short subAllproducts_Allowselection ;
      private short subAllproducts_Allowhovering ;
      private short subAllproducts_Allowcollapsing ;
      private int nRC_GXsfl_76 ;
      private int subAllproducts_Rows ;
      private int nGXsfl_76_idx=1 ;
      private int AV9Supplier ;
      private int AV8Sector ;
      private int AV5Brand ;
      private int AV13StockFrom ;
      private int AV12StockTo ;
      private int edtavName_Enabled ;
      private int edtavStockfrom_Enabled ;
      private int edtavStockto_Enabled ;
      private int edtavPricefrom_Enabled ;
      private int edtavPriceto_Enabled ;
      private int A17ProductStock ;
      private int gxdynajaxindex ;
      private int subAllproducts_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A4SupplierId ;
      private int A9SectorId ;
      private int A1BrandId ;
      private int idxLst ;
      private int subAllproducts_Backcolor ;
      private int subAllproducts_Allbackcolor ;
      private int subAllproducts_Titlebackcolor ;
      private int subAllproducts_Selectedindex ;
      private int subAllproducts_Selectioncolor ;
      private int subAllproducts_Hoveringcolor ;
      private long ALLPRODUCTS_nFirstRecordOnPage ;
      private long ALLPRODUCTS_nCurrentRecord ;
      private long ALLPRODUCTS_nRecordCount ;
      private decimal AV14PriceFrom ;
      private decimal AV15PriceTo ;
      private decimal A85ProductCostPrice ;
      private decimal A89ProductRetailProfit ;
      private decimal A90ProductRetailPrice ;
      private decimal A87ProductWholesaleProfit ;
      private decimal A88ProductWholesalePrice ;
      private decimal GXt_decimal3 ;
      private decimal GXt_decimal2 ;
      private decimal GXt_decimal1 ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_76_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string divTable5_Internalname ;
      private string dynavSupplier_Internalname ;
      private string TempTags ;
      private string dynavSupplier_Jsonclick ;
      private string dynavSector_Internalname ;
      private string dynavSector_Jsonclick ;
      private string dynavBrand_Internalname ;
      private string dynavBrand_Jsonclick ;
      private string edtavName_Internalname ;
      private string edtavName_Jsonclick ;
      private string edtavStockfrom_Internalname ;
      private string edtavStockfrom_Jsonclick ;
      private string edtavStockto_Internalname ;
      private string edtavStockto_Jsonclick ;
      private string edtavPricefrom_Internalname ;
      private string edtavPricefrom_Jsonclick ;
      private string edtavPriceto_Internalname ;
      private string edtavPriceto_Jsonclick ;
      private string cmbavActive_Internalname ;
      private string cmbavActive_Jsonclick ;
      private string cmbavOrderby_Internalname ;
      private string cmbavOrderby_Jsonclick ;
      private string chkavDescending_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string sStyleString ;
      private string subAllproducts_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtProductCode_Internalname ;
      private string edtProductName_Internalname ;
      private string edtProductStock_Internalname ;
      private string edtProductCostPrice_Internalname ;
      private string edtProductRetailProfit_Internalname ;
      private string edtProductRetailPrice_Internalname ;
      private string edtProductWholesaleProfit_Internalname ;
      private string edtProductWholesalePrice_Internalname ;
      private string edtBrandName_Internalname ;
      private string edtSectorName_Internalname ;
      private string edtSupplierName_Internalname ;
      private string gxwrpcisep ;
      private string scmdbuf ;
      private string imgavExportpdf_Internalname ;
      private string imgavExportexcel_Internalname ;
      private string imgavExportpdf_gximage ;
      private string imgavExportexcel_gximage ;
      private string tblTable1_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string sImgUrl ;
      private string imgavExportpdf_Jsonclick ;
      private string imgavExportexcel_Jsonclick ;
      private string sGXsfl_76_fel_idx="0001" ;
      private string subAllproducts_Class ;
      private string subAllproducts_Linesclass ;
      private string ROClassString ;
      private string edtProductCode_Jsonclick ;
      private string edtProductName_Jsonclick ;
      private string edtProductStock_Jsonclick ;
      private string edtProductCostPrice_Jsonclick ;
      private string edtProductRetailProfit_Jsonclick ;
      private string edtProductRetailPrice_Jsonclick ;
      private string edtProductWholesaleProfit_Jsonclick ;
      private string edtProductWholesalePrice_Jsonclick ;
      private string edtBrandName_Jsonclick ;
      private string edtSectorName_Jsonclick ;
      private string edtSupplierName_Jsonclick ;
      private string subAllproducts_Header ;
      private DateTime A28ProductCreatedDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV18Descending ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n55ProductCode ;
      private bool n17ProductStock ;
      private bool n85ProductCostPrice ;
      private bool n89ProductRetailProfit ;
      private bool n87ProductWholesaleProfit ;
      private bool gxdyncontrolsrefreshing ;
      private bool bGXsfl_76_Refreshing=false ;
      private bool A110ProductActive ;
      private bool A112SupplierActive ;
      private bool n110ProductActive ;
      private bool n1BrandId ;
      private bool n9SectorId ;
      private bool returnInSub ;
      private bool AV31AllOk ;
      private bool AV19ExportPDF_IsBlob ;
      private bool AV21ExportExcel_IsBlob ;
      private string AV7Name ;
      private string A55ProductCode ;
      private string A16ProductName ;
      private string A2BrandName ;
      private string A10SectorName ;
      private string A5SupplierName ;
      private string lV7Name ;
      private string AV28ExcelFilename ;
      private string AV29ErrorMessage ;
      private string AV36Exportpdf_GXI ;
      private string AV37Exportexcel_GXI ;
      private string AV19ExportPDF ;
      private string AV21ExportExcel ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid AllproductsContainer ;
      private GXWebRow AllproductsRow ;
      private GXWebColumn AllproductsColumn ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavSupplier ;
      private GXCombobox dynavSector ;
      private GXCombobox dynavBrand ;
      private GXCombobox cmbavActive ;
      private GXCombobox cmbavOrderby ;
      private GXCheckbox chkavDescending ;
      private IDataStoreProvider pr_default ;
      private int[] H00242_A4SupplierId ;
      private string[] H00242_A5SupplierName ;
      private int[] H00243_A9SectorId ;
      private bool[] H00243_n9SectorId ;
      private string[] H00243_A10SectorName ;
      private int[] H00244_A1BrandId ;
      private bool[] H00244_n1BrandId ;
      private string[] H00244_A2BrandName ;
      private int[] H00245_A15ProductId ;
      private DateTime[] H00245_A28ProductCreatedDate ;
      private bool[] H00245_A112SupplierActive ;
      private bool[] H00245_A110ProductActive ;
      private bool[] H00245_n110ProductActive ;
      private int[] H00245_A1BrandId ;
      private bool[] H00245_n1BrandId ;
      private int[] H00245_A9SectorId ;
      private bool[] H00245_n9SectorId ;
      private int[] H00245_A4SupplierId ;
      private string[] H00245_A5SupplierName ;
      private string[] H00245_A10SectorName ;
      private string[] H00245_A2BrandName ;
      private int[] H00245_A17ProductStock ;
      private bool[] H00245_n17ProductStock ;
      private string[] H00245_A16ProductName ;
      private string[] H00245_A55ProductCode ;
      private bool[] H00245_n55ProductCode ;
      private decimal[] H00245_A89ProductRetailProfit ;
      private bool[] H00245_n89ProductRetailProfit ;
      private decimal[] H00245_A85ProductCostPrice ;
      private bool[] H00245_n85ProductCostPrice ;
      private decimal[] H00245_A87ProductWholesaleProfit ;
      private bool[] H00245_n87ProductWholesaleProfit ;
      private long[] H00246_AALLPRODUCTS_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IGxSession AV32WebSession ;
      private GXWebForm Form ;
      private GXWindow AV17window ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession AV30Context ;
   }

   public class wpsearchproducts__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00245( IGxContext context ,
                                             int AV9Supplier ,
                                             int AV8Sector ,
                                             int AV5Brand ,
                                             string AV7Name ,
                                             int AV13StockFrom ,
                                             int AV12StockTo ,
                                             decimal AV14PriceFrom ,
                                             decimal AV15PriceTo ,
                                             short AV33Active ,
                                             int A4SupplierId ,
                                             int A9SectorId ,
                                             int A1BrandId ,
                                             string A16ProductName ,
                                             int A17ProductStock ,
                                             decimal A85ProductCostPrice ,
                                             bool A110ProductActive ,
                                             short AV16OrderBy ,
                                             bool AV18Descending ,
                                             bool A112SupplierActive )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[11];
         Object[] GXv_Object5 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.[ProductId], T1.[ProductCreatedDate], T4.[SupplierActive], T1.[ProductActive], T1.[BrandId], T1.[SectorId], T1.[SupplierId], T4.[SupplierName], T3.[SectorName], T2.[BrandName], T1.[ProductStock], T1.[ProductName], T1.[ProductCode], T1.[ProductRetailProfit], T1.[ProductCostPrice], T1.[ProductWholesaleProfit]";
         sFromString = " FROM ((([Product] T1 LEFT JOIN [Brand] T2 ON T2.[BrandId] = T1.[BrandId]) LEFT JOIN [Sector] T3 ON T3.[SectorId] = T1.[SectorId]) INNER JOIN [Supplier] T4 ON T4.[SupplierId] = T1.[SupplierId])";
         sOrderString = "";
         AddWhere(sWhereString, "(T4.[SupplierActive] = 1)");
         if ( ! (0==AV9Supplier) )
         {
            AddWhere(sWhereString, "(T1.[SupplierId] = @AV9Supplier)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ! (0==AV8Sector) )
         {
            AddWhere(sWhereString, "(T1.[SectorId] = @AV8Sector)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ! (0==AV5Brand) )
         {
            AddWhere(sWhereString, "(T1.[BrandId] = @AV5Brand)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7Name)) )
         {
            AddWhere(sWhereString, "(T1.[ProductName] like @lV7Name)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! (0==AV13StockFrom) )
         {
            AddWhere(sWhereString, "(T1.[ProductStock] >= @AV13StockFrom)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! (0==AV12StockTo) )
         {
            AddWhere(sWhereString, "(T1.[ProductStock] <= @AV12StockTo)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV14PriceFrom) )
         {
            AddWhere(sWhereString, "(T1.[ProductCostPrice] >= @AV14PriceFrom)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV15PriceTo) )
         {
            AddWhere(sWhereString, "(T1.[ProductCostPrice] <= @AV15PriceTo)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! (0==AV33Active) && ( AV33Active == 1 ) )
         {
            AddWhere(sWhereString, "(T1.[ProductActive] = 1)");
         }
         if ( ! (0==AV33Active) && ( AV33Active == 2 ) )
         {
            AddWhere(sWhereString, "(Not T1.[ProductActive] = 1)");
         }
         if ( ( AV16OrderBy == 1 ) && ! AV18Descending )
         {
            sOrderString += " ORDER BY T1.[ProductName]";
         }
         else if ( ( AV16OrderBy == 1 ) && ( AV18Descending ) )
         {
            sOrderString += " ORDER BY T1.[ProductName] DESC";
         }
         else if ( ( AV16OrderBy == 2 ) && ! AV18Descending )
         {
            sOrderString += " ORDER BY T4.[SupplierName]";
         }
         else if ( ( AV16OrderBy == 2 ) && ( AV18Descending ) )
         {
            sOrderString += " ORDER BY T4.[SupplierName] DESC";
         }
         else if ( ( AV16OrderBy == 3 ) && ! AV18Descending )
         {
            sOrderString += " ORDER BY T2.[BrandName]";
         }
         else if ( ( AV16OrderBy == 3 ) && ( AV18Descending ) )
         {
            sOrderString += " ORDER BY T2.[BrandName] DESC";
         }
         else if ( ( AV16OrderBy == 4 ) && ! AV18Descending )
         {
            sOrderString += " ORDER BY T3.[SectorName]";
         }
         else if ( ( AV16OrderBy == 4 ) && ( AV18Descending ) )
         {
            sOrderString += " ORDER BY T3.[SectorName] DESC";
         }
         else if ( ( AV16OrderBy == 5 ) && ! AV18Descending )
         {
            sOrderString += " ORDER BY T1.[ProductStock]";
         }
         else if ( ( AV16OrderBy == 5 ) && ( AV18Descending ) )
         {
            sOrderString += " ORDER BY T1.[ProductStock] DESC";
         }
         else if ( ( AV16OrderBy == 6 ) && ! AV18Descending )
         {
            sOrderString += " ORDER BY T1.[ProductCostPrice]";
         }
         else if ( ( AV16OrderBy == 6 ) && ( AV18Descending ) )
         {
            sOrderString += " ORDER BY T1.[ProductCostPrice] DESC";
         }
         else if ( ( AV16OrderBy == 9 ) && ! AV18Descending )
         {
            sOrderString += " ORDER BY T1.[ProductCreatedDate]";
         }
         else if ( ( AV16OrderBy == 9 ) && ( AV18Descending ) )
         {
            sOrderString += " ORDER BY T1.[ProductCreatedDate] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.[ProductId]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_H00246( IGxContext context ,
                                             int AV9Supplier ,
                                             int AV8Sector ,
                                             int AV5Brand ,
                                             string AV7Name ,
                                             int AV13StockFrom ,
                                             int AV12StockTo ,
                                             decimal AV14PriceFrom ,
                                             decimal AV15PriceTo ,
                                             short AV33Active ,
                                             int A4SupplierId ,
                                             int A9SectorId ,
                                             int A1BrandId ,
                                             string A16ProductName ,
                                             int A17ProductStock ,
                                             decimal A85ProductCostPrice ,
                                             bool A110ProductActive ,
                                             short AV16OrderBy ,
                                             bool AV18Descending ,
                                             bool A112SupplierActive )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[8];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ((([Product] T1 LEFT JOIN [Brand] T2 ON T2.[BrandId] = T1.[BrandId]) LEFT JOIN [Sector] T3 ON T3.[SectorId] = T1.[SectorId]) INNER JOIN [Supplier] T4 ON T4.[SupplierId] = T1.[SupplierId])";
         AddWhere(sWhereString, "(T4.[SupplierActive] = 1)");
         if ( ! (0==AV9Supplier) )
         {
            AddWhere(sWhereString, "(T1.[SupplierId] = @AV9Supplier)");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         if ( ! (0==AV8Sector) )
         {
            AddWhere(sWhereString, "(T1.[SectorId] = @AV8Sector)");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( ! (0==AV5Brand) )
         {
            AddWhere(sWhereString, "(T1.[BrandId] = @AV5Brand)");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7Name)) )
         {
            AddWhere(sWhereString, "(T1.[ProductName] like @lV7Name)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( ! (0==AV13StockFrom) )
         {
            AddWhere(sWhereString, "(T1.[ProductStock] >= @AV13StockFrom)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ! (0==AV12StockTo) )
         {
            AddWhere(sWhereString, "(T1.[ProductStock] <= @AV12StockTo)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV14PriceFrom) )
         {
            AddWhere(sWhereString, "(T1.[ProductCostPrice] >= @AV14PriceFrom)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV15PriceTo) )
         {
            AddWhere(sWhereString, "(T1.[ProductCostPrice] <= @AV15PriceTo)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( ! (0==AV33Active) && ( AV33Active == 1 ) )
         {
            AddWhere(sWhereString, "(T1.[ProductActive] = 1)");
         }
         if ( ! (0==AV33Active) && ( AV33Active == 2 ) )
         {
            AddWhere(sWhereString, "(Not T1.[ProductActive] = 1)");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderBy == 1 ) && ! AV18Descending )
         {
            scmdbuf += "";
         }
         else if ( ( AV16OrderBy == 1 ) && ( AV18Descending ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV16OrderBy == 2 ) && ! AV18Descending )
         {
            scmdbuf += "";
         }
         else if ( ( AV16OrderBy == 2 ) && ( AV18Descending ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV16OrderBy == 3 ) && ! AV18Descending )
         {
            scmdbuf += "";
         }
         else if ( ( AV16OrderBy == 3 ) && ( AV18Descending ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV16OrderBy == 4 ) && ! AV18Descending )
         {
            scmdbuf += "";
         }
         else if ( ( AV16OrderBy == 4 ) && ( AV18Descending ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV16OrderBy == 5 ) && ! AV18Descending )
         {
            scmdbuf += "";
         }
         else if ( ( AV16OrderBy == 5 ) && ( AV18Descending ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV16OrderBy == 6 ) && ! AV18Descending )
         {
            scmdbuf += "";
         }
         else if ( ( AV16OrderBy == 6 ) && ( AV18Descending ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV16OrderBy == 9 ) && ! AV18Descending )
         {
            scmdbuf += "";
         }
         else if ( ( AV16OrderBy == 9 ) && ( AV18Descending ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 3 :
                     return conditional_H00245(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (decimal)dynConstraints[6] , (decimal)dynConstraints[7] , (short)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (decimal)dynConstraints[14] , (bool)dynConstraints[15] , (short)dynConstraints[16] , (bool)dynConstraints[17] , (bool)dynConstraints[18] );
               case 4 :
                     return conditional_H00246(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (decimal)dynConstraints[6] , (decimal)dynConstraints[7] , (short)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (decimal)dynConstraints[14] , (bool)dynConstraints[15] , (short)dynConstraints[16] , (bool)dynConstraints[17] , (bool)dynConstraints[18] );
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
          Object[] prmH00242;
          prmH00242 = new Object[] {
          };
          Object[] prmH00243;
          prmH00243 = new Object[] {
          };
          Object[] prmH00244;
          prmH00244 = new Object[] {
          };
          Object[] prmH00245;
          prmH00245 = new Object[] {
          new ParDef("@AV9Supplier",GXType.Int32,6,0) ,
          new ParDef("@AV8Sector",GXType.Int32,6,0) ,
          new ParDef("@AV5Brand",GXType.Int32,6,0) ,
          new ParDef("@lV7Name",GXType.NVarChar,60,0) ,
          new ParDef("@AV13StockFrom",GXType.Int32,6,0) ,
          new ParDef("@AV12StockTo",GXType.Int32,6,0) ,
          new ParDef("@AV14PriceFrom",GXType.Decimal,18,2) ,
          new ParDef("@AV15PriceTo",GXType.Decimal,18,2) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00246;
          prmH00246 = new Object[] {
          new ParDef("@AV9Supplier",GXType.Int32,6,0) ,
          new ParDef("@AV8Sector",GXType.Int32,6,0) ,
          new ParDef("@AV5Brand",GXType.Int32,6,0) ,
          new ParDef("@lV7Name",GXType.NVarChar,60,0) ,
          new ParDef("@AV13StockFrom",GXType.Int32,6,0) ,
          new ParDef("@AV12StockTo",GXType.Int32,6,0) ,
          new ParDef("@AV14PriceFrom",GXType.Decimal,18,2) ,
          new ParDef("@AV15PriceTo",GXType.Decimal,18,2)
          };
          def= new CursorDef[] {
              new CursorDef("H00242", "SELECT [SupplierId], [SupplierName] FROM [Supplier] ORDER BY [SupplierName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00242,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00243", "SELECT [SectorId], [SectorName] FROM [Sector] ORDER BY [SectorName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00243,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00244", "SELECT [BrandId], [BrandName] FROM [Brand] ORDER BY [BrandName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00244,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00245", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00245,6, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00246", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00246,1, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((int[]) buf[7])[0] = rslt.getInt(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((int[]) buf[9])[0] = rslt.getInt(7);
                ((string[]) buf[10])[0] = rslt.getVarchar(8);
                ((string[]) buf[11])[0] = rslt.getVarchar(9);
                ((string[]) buf[12])[0] = rslt.getVarchar(10);
                ((int[]) buf[13])[0] = rslt.getInt(11);
                ((bool[]) buf[14])[0] = rslt.wasNull(11);
                ((string[]) buf[15])[0] = rslt.getVarchar(12);
                ((string[]) buf[16])[0] = rslt.getVarchar(13);
                ((bool[]) buf[17])[0] = rslt.wasNull(13);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(14);
                ((bool[]) buf[19])[0] = rslt.wasNull(14);
                ((decimal[]) buf[20])[0] = rslt.getDecimal(15);
                ((bool[]) buf[21])[0] = rslt.wasNull(15);
                ((decimal[]) buf[22])[0] = rslt.getDecimal(16);
                ((bool[]) buf[23])[0] = rslt.wasNull(16);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
