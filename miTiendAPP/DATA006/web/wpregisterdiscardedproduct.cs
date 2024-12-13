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
   public class wpregisterdiscardedproduct : GXDataArea
   {
      public wpregisterdiscardedproduct( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public wpregisterdiscardedproduct( IGxContext context )
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
         dynavEmployee = new GXCombobox();
         dynavSupplier = new GXCombobox();
         dynavBrand = new GXCombobox();
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
               GXDLVvSUPPLIER2B2( ) ;
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
               GXDLVvBRAND2B2( ) ;
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
         nRC_GXsfl_32 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_32"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_32_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_32_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_32_idx = GetPar( "sGXsfl_32_idx");
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
         AV11Code = GetPar( "Code");
         AV15Name = GetPar( "Name");
         dynavSupplier.FromJSonString( GetNextPar( ));
         AV21Supplier = (int)(Math.Round(NumberUtil.Val( GetPar( "Supplier"), "."), 18, MidpointRounding.ToEven));
         dynavBrand.FromJSonString( GetNextPar( ));
         AV7Brand = (int)(Math.Round(NumberUtil.Val( GetPar( "Brand"), "."), 18, MidpointRounding.ToEven));
         dynavEmployee.FromJSonString( GetNextPar( ));
         AV12Employee = (int)(Math.Round(NumberUtil.Val( GetPar( "Employee"), "."), 18, MidpointRounding.ToEven));
         AV16NewQty = (short)(Math.Round(NumberUtil.Val( GetPar( "NewQty"), "."), 18, MidpointRounding.ToEven));
         AV6newName = GetPar( "newName");
         AV5newCode = GetPar( "newCode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrAllproducts_refresh( subAllproducts_Rows, AV11Code, AV15Name, AV21Supplier, AV7Brand, AV12Employee, AV16NewQty, AV6newName, AV5newCode) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrAllproducts_refresh_invoke */
      }

      protected void gxnrCarproducts_newrow_invoke( )
      {
         nRC_GXsfl_55 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_55"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_55_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_55_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_55_idx = GetPar( "sGXsfl_55_idx");
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
         subAllproducts_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subAllproducts_Rows"), "."), 18, MidpointRounding.ToEven));
         AV11Code = GetPar( "Code");
         AV15Name = GetPar( "Name");
         dynavSupplier.FromJSonString( GetNextPar( ));
         AV21Supplier = (int)(Math.Round(NumberUtil.Val( GetPar( "Supplier"), "."), 18, MidpointRounding.ToEven));
         dynavBrand.FromJSonString( GetNextPar( ));
         AV7Brand = (int)(Math.Round(NumberUtil.Val( GetPar( "Brand"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV8Car);
         dynavEmployee.FromJSonString( GetNextPar( ));
         AV12Employee = (int)(Math.Round(NumberUtil.Val( GetPar( "Employee"), "."), 18, MidpointRounding.ToEven));
         AV16NewQty = (short)(Math.Round(NumberUtil.Val( GetPar( "NewQty"), "."), 18, MidpointRounding.ToEven));
         AV6newName = GetPar( "newName");
         AV5newCode = GetPar( "newCode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrCarproducts_refresh( subAllproducts_Rows, AV11Code, AV15Name, AV21Supplier, AV7Brand, AV8Car, AV12Employee, AV16NewQty, AV6newName, AV5newCode) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrCarproducts_refresh_invoke */
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
         PA2B2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2B2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpregisterdiscardedproduct.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vNEWQTY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16NewQty), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWQTY", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV16NewQty), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vNEWNAME", AV6newName);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6newName, "")), context));
         GxWebStd.gx_hidden_field( context, "vNEWCODE", AV5newCode);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV5newCode, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vCODE", AV11Code);
         GxWebStd.gx_hidden_field( context, "GXH_vNAME", AV15Name);
         GxWebStd.gx_hidden_field( context, "GXH_vSUPPLIER", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21Supplier), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vBRAND", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7Brand), 6, 0, ".", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Car", AV8Car);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Car", AV8Car);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_32", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_32), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_55", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_55), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSELECTEDID", AV20SelectedId);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSELECTEDID", AV20SelectedId);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCARITEM", AV10CarItem);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCARITEM", AV10CarItem);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCARAUX", AV9CarAux);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCARAUX", AV9CarAux);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCAR", AV8Car);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCAR", AV8Car);
         }
         GxWebStd.gx_hidden_field( context, "vNEWQTY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16NewQty), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWQTY", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV16NewQty), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vNEWNAME", AV6newName);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6newName, "")), context));
         GxWebStd.gx_hidden_field( context, "vNEWCODE", AV5newCode);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV5newCode, "")), context));
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
            WE2B2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2B2( ) ;
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
         return formatLink("wpregisterdiscardedproduct.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WPRegisterDiscardedProduct" ;
      }

      public override string GetPgmdesc( )
      {
         return "WPRegister Discarded Product" ;
      }

      protected void WB2B0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavEmployee_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavEmployee_Internalname, "Employee", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 11,'',false,'" + sGXsfl_32_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavEmployee, dynavEmployee_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV12Employee), 6, 0)), 1, dynavEmployee_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavEmployee.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,11);\"", "", true, 0, "HLP_WPRegisterDiscardedProduct.htm");
            dynavEmployee.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV12Employee), 6, 0));
            AssignProp("", false, dynavEmployee_Internalname, "Values", (string)(dynavEmployee.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavCode_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCode_Internalname, "Code", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 15,'',false,'" + sGXsfl_32_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCode_Internalname, AV11Code, StringUtil.RTrim( context.localUtil.Format( AV11Code, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,15);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCode_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCode_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "GeneXusUnanimo\\Code", "left", true, "", "HLP_WPRegisterDiscardedProduct.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'" + sGXsfl_32_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavName_Internalname, AV15Name, StringUtil.RTrim( context.localUtil.Format( AV15Name, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,19);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavName_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Name", "left", true, "", "HLP_WPRegisterDiscardedProduct.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'" + sGXsfl_32_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavSupplier, dynavSupplier_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV21Supplier), 6, 0)), 1, dynavSupplier_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavSupplier.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,23);\"", "", true, 0, "HLP_WPRegisterDiscardedProduct.htm");
            dynavSupplier.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21Supplier), 6, 0));
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'" + sGXsfl_32_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavBrand, dynavBrand_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV7Brand), 6, 0)), 1, dynavBrand_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavBrand.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "", true, 0, "HLP_WPRegisterDiscardedProduct.htm");
            dynavBrand.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7Brand), 6, 0));
            AssignProp("", false, dynavBrand_Internalname, "Values", (string)(dynavBrand.ToJavascriptSource()), true);
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
            StartGridControl32( ) ;
         }
         if ( wbEnd == 32 )
         {
            wbEnd = 0;
            nRC_GXsfl_32 = (int)(nGXsfl_32_idx-1);
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
            GxWebStd.gx_div_start( context, divTable2_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttRegistersale_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(32), 2, 0)+","+"null"+");", "Register Sale", bttRegistersale_Jsonclick, 5, "Register Sale", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'REGISTERSALE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPRegisterDiscardedProduct.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttClearsale_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(32), 2, 0)+","+"null"+");", "Clear Sale", bttClearsale_Jsonclick, 5, "Clear Sale", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CLEARSALE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPRegisterDiscardedProduct.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavTotal_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTotal_Internalname, "Total receivable", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'" + sGXsfl_32_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTotal_Internalname, StringUtil.LTrim( StringUtil.NToC( AV22Total, 10, 2, ".", "")), StringUtil.LTrim( ((edtavTotal_Enabled!=0) ? context.localUtil.Format( AV22Total, "ZZZZZZ9.99") : context.localUtil.Format( AV22Total, "ZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTotal_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTotal_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "Price", "right", false, "", "HLP_WPRegisterDiscardedProduct.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            CarproductsContainer.SetIsFreestyle(true);
            CarproductsContainer.SetWrapped(nGXWrapped);
            StartGridControl55( ) ;
         }
         if ( wbEnd == 55 )
         {
            wbEnd = 0;
            nRC_GXsfl_55 = (int)(nGXsfl_55_idx-1);
            if ( CarproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV26GXV1 = nGXsfl_55_idx;
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
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 32 )
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
         if ( wbEnd == 55 )
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
                  AV26GXV1 = nGXsfl_55_idx;
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
         wbLoad = true;
      }

      protected void START2B2( )
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
            Form.Meta.addItem("description", "WPRegister Discarded Product", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2B0( ) ;
      }

      protected void WS2B2( )
      {
         START2B2( ) ;
         EVT2B2( ) ;
      }

      protected void EVT2B2( )
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
                              E112B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CLEARSALE'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'ClearSale' */
                              E122B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVE'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Remove' */
                              E132B2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 33), "CTLQUANTITY1.CONTROLVALUECHANGING") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 8), "'REMOVE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 19), "CARPRODUCTS.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 16), "CARPRODUCTS.LOAD") == 0 ) )
                           {
                              nGXsfl_55_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_55_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_55_idx), 4, 0), 4, "0");
                              SubsflControlProps_553( ) ;
                              AV26GXV1 = nGXsfl_55_idx;
                              if ( ( AV8Car.Count >= AV26GXV1 ) && ( AV26GXV1 > 0 ) )
                              {
                                 AV8Car.CurrentItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV8Car.Item(AV26GXV1));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "CTLQUANTITY1.CONTROLVALUECHANGING") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E142B2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'REMOVE'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'Remove' */
                                    E132B2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "CARPRODUCTS.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E152B2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "CARPRODUCTS.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E162B3 ();
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
                              nGXsfl_32_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_32_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_32_idx), 4, 0), 4, "0");
                              SubsflControlProps_322( ) ;
                              A15ProductId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtProductId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              A55ProductCode = cgiGet( edtProductCode_Internalname);
                              n55ProductCode = false;
                              A16ProductName = cgiGet( edtProductName_Internalname);
                              A18ProductPrice = context.localUtil.CToN( cgiGet( edtProductPrice_Internalname), ".", ",");
                              A17ProductStock = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtProductStock_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "PRODUCTNAME.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E172B2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E182B2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ALLPRODUCTS.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E192B2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Code Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCODE"), AV11Code) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Name Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vNAME"), AV15Name) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Supplier Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vSUPPLIER"), ".", ",") != Convert.ToDecimal( AV21Supplier )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Brand Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vBRAND"), ".", ",") != Convert.ToDecimal( AV7Brand )) )
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

      protected void WE2B2( )
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

      protected void PA2B2( )
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
               GX_FocusControl = dynavEmployee_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVvEMPLOYEE2B1( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvEMPLOYEE_data2B1( ) ;
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

      protected void GXVvEMPLOYEE_html2B1( )
      {
         int gxdynajaxvalue;
         GXDLVvEMPLOYEE_data2B1( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavEmployee.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavEmployee.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 6, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynavEmployee.ItemCount > 0 )
         {
            AV12Employee = (int)(Math.Round(NumberUtil.Val( dynavEmployee.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV12Employee), 6, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV12Employee", StringUtil.LTrimStr( (decimal)(AV12Employee), 6, 0));
         }
      }

      protected void GXDLVvEMPLOYEE_data2B1( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H002B2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H002B2_A12EmployeeId[0]), 6, 0, ".", "")));
            gxdynajaxctrldescr.Add(H002B2_A13EmployeeFirstName[0]);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void GXDLVvSUPPLIER2B2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvSUPPLIER_data2B2( ) ;
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

      protected void GXVvSUPPLIER_html2B2( )
      {
         int gxdynajaxvalue;
         GXDLVvSUPPLIER_data2B2( ) ;
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

      protected void GXDLVvSUPPLIER_data2B2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(None)");
         /* Using cursor H002B3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H002B3_A4SupplierId[0]), 6, 0, ".", "")));
            gxdynajaxctrldescr.Add(H002B3_A5SupplierName[0]);
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void GXDLVvBRAND2B2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvBRAND_data2B2( ) ;
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

      protected void GXVvBRAND_html2B2( )
      {
         int gxdynajaxvalue;
         GXDLVvBRAND_data2B2( ) ;
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

      protected void GXDLVvBRAND_data2B2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(None)");
         /* Using cursor H002B4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H002B4_A1BrandId[0]), 6, 0, ".", "")));
            gxdynajaxctrldescr.Add(H002B4_A2BrandName[0]);
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void gxnrAllproducts_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_322( ) ;
         while ( nGXsfl_32_idx <= nRC_GXsfl_32 )
         {
            sendrow_322( ) ;
            nGXsfl_32_idx = ((subAllproducts_Islastpage==1)&&(nGXsfl_32_idx+1>subAllproducts_fnc_Recordsperpage( )) ? 1 : nGXsfl_32_idx+1);
            sGXsfl_32_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_32_idx), 4, 0), 4, "0");
            SubsflControlProps_322( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( AllproductsContainer)) ;
         /* End function gxnrAllproducts_newrow */
      }

      protected void gxnrCarproducts_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_553( ) ;
         while ( nGXsfl_55_idx <= nRC_GXsfl_55 )
         {
            sendrow_553( ) ;
            nGXsfl_55_idx = ((subCarproducts_Islastpage==1)&&(nGXsfl_55_idx+1>subCarproducts_fnc_Recordsperpage( )) ? 1 : nGXsfl_55_idx+1);
            sGXsfl_55_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_55_idx), 4, 0), 4, "0");
            SubsflControlProps_553( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( CarproductsContainer)) ;
         /* End function gxnrCarproducts_newrow */
      }

      protected void gxgrAllproducts_refresh( int subAllproducts_Rows ,
                                              string AV11Code ,
                                              string AV15Name ,
                                              int AV21Supplier ,
                                              int AV7Brand ,
                                              int AV12Employee ,
                                              short AV16NewQty ,
                                              string AV6newName ,
                                              string AV5newCode )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         ALLPRODUCTS_nCurrentRecord = 0;
         RF2B2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrAllproducts_refresh */
      }

      protected void gxgrCarproducts_refresh( int subAllproducts_Rows ,
                                              string AV11Code ,
                                              string AV15Name ,
                                              int AV21Supplier ,
                                              int AV7Brand ,
                                              GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem> AV8Car ,
                                              int AV12Employee ,
                                              short AV16NewQty ,
                                              string AV6newName ,
                                              string AV5newCode )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         CARPRODUCTS_nCurrentRecord = 0;
         RF2B3( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrCarproducts_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUCTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A15ProductId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "PRODUCTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUCTNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A16ProductName, "")), context));
         GxWebStd.gx_hidden_field( context, "PRODUCTNAME", A16ProductName);
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUCTSTOCK", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A17ProductStock), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "PRODUCTSTOCK", StringUtil.LTrim( StringUtil.NToC( (decimal)(A17ProductStock), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUCTPRICE", GetSecureSignedToken( "", context.localUtil.Format( A18ProductPrice, "ZZZZZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "PRODUCTPRICE", StringUtil.LTrim( StringUtil.NToC( A18ProductPrice, 10, 2, ".", "")));
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXVvSUPPLIER_html2B2( ) ;
            GXVvBRAND_html2B2( ) ;
            dynavEmployee.Name = "vEMPLOYEE";
            dynavEmployee.WebTags = "";
            dynavEmployee.removeAllItems();
            /* Using cursor H002B5 */
            pr_default.execute(3);
            while ( (pr_default.getStatus(3) != 101) )
            {
               dynavEmployee.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H002B5_A12EmployeeId[0]), 6, 0)), H002B5_A13EmployeeFirstName[0], 0);
               pr_default.readNext(3);
            }
            pr_default.close(3);
            if ( dynavEmployee.ItemCount > 0 )
            {
               AV12Employee = (int)(Math.Round(NumberUtil.Val( dynavEmployee.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV12Employee), 6, 0))), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12Employee", StringUtil.LTrimStr( (decimal)(AV12Employee), 6, 0));
            }
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavEmployee.ItemCount > 0 )
         {
            AV12Employee = (int)(Math.Round(NumberUtil.Val( dynavEmployee.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV12Employee), 6, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV12Employee", StringUtil.LTrimStr( (decimal)(AV12Employee), 6, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavEmployee.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV12Employee), 6, 0));
            AssignProp("", false, dynavEmployee_Internalname, "Values", dynavEmployee.ToJavascriptSource(), true);
         }
         if ( dynavSupplier.ItemCount > 0 )
         {
            AV21Supplier = (int)(Math.Round(NumberUtil.Val( dynavSupplier.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV21Supplier), 6, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV21Supplier", StringUtil.LTrimStr( (decimal)(AV21Supplier), 6, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavSupplier.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21Supplier), 6, 0));
            AssignProp("", false, dynavSupplier_Internalname, "Values", dynavSupplier.ToJavascriptSource(), true);
         }
         if ( dynavBrand.ItemCount > 0 )
         {
            AV7Brand = (int)(Math.Round(NumberUtil.Val( dynavBrand.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV7Brand), 6, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV7Brand", StringUtil.LTrimStr( (decimal)(AV7Brand), 6, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavBrand.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7Brand), 6, 0));
            AssignProp("", false, dynavBrand_Internalname, "Values", dynavBrand.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF2B2( ) ;
         RF2B3( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavTotal_Enabled = 0;
         AssignProp("", false, edtavTotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTotal_Enabled), 5, 0), true);
         edtavCtlname1_Enabled = 0;
         AssignProp("", false, edtavCtlname1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname1_Enabled), 5, 0), !bGXsfl_55_Refreshing);
         edtavCtlunitprice1_Enabled = 0;
         AssignProp("", false, edtavCtlunitprice1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlunitprice1_Enabled), 5, 0), !bGXsfl_55_Refreshing);
         edtavCtlstock_Enabled = 0;
         AssignProp("", false, edtavCtlstock_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlstock_Enabled), 5, 0), !bGXsfl_55_Refreshing);
         edtavCtlsubtotal_Enabled = 0;
         AssignProp("", false, edtavCtlsubtotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsubtotal_Enabled), 5, 0), !bGXsfl_55_Refreshing);
      }

      protected void RF2B2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            AllproductsContainer.ClearRows();
         }
         wbStart = 32;
         nGXsfl_32_idx = 1;
         sGXsfl_32_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_32_idx), 4, 0), 4, "0");
         SubsflControlProps_322( ) ;
         bGXsfl_32_Refreshing = true;
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
            SubsflControlProps_322( ) ;
            GXPagingFrom2 = (int)(ALLPRODUCTS_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subAllproducts_fnc_Recordsperpage( )+1);
            pr_default.dynParam(4, new Object[]{ new Object[]{
                                                 AV11Code ,
                                                 AV15Name ,
                                                 AV21Supplier ,
                                                 AV7Brand ,
                                                 A55ProductCode ,
                                                 A16ProductName ,
                                                 A4SupplierId ,
                                                 A1BrandId } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT
                                                 }
            });
            lV11Code = StringUtil.Concat( StringUtil.RTrim( AV11Code), "%", "");
            lV15Name = StringUtil.Concat( StringUtil.RTrim( AV15Name), "%", "");
            /* Using cursor H002B6 */
            pr_default.execute(4, new Object[] {lV11Code, lV15Name, AV21Supplier, AV7Brand, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_32_idx = 1;
            sGXsfl_32_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_32_idx), 4, 0), 4, "0");
            SubsflControlProps_322( ) ;
            while ( ( (pr_default.getStatus(4) != 101) ) && ( ( ALLPRODUCTS_nCurrentRecord < subAllproducts_fnc_Recordsperpage( ) ) ) )
            {
               A1BrandId = H002B6_A1BrandId[0];
               A4SupplierId = H002B6_A4SupplierId[0];
               A17ProductStock = H002B6_A17ProductStock[0];
               A18ProductPrice = H002B6_A18ProductPrice[0];
               A16ProductName = H002B6_A16ProductName[0];
               A55ProductCode = H002B6_A55ProductCode[0];
               n55ProductCode = H002B6_n55ProductCode[0];
               A15ProductId = H002B6_A15ProductId[0];
               E192B2 ();
               pr_default.readNext(4);
            }
            ALLPRODUCTS_nEOF = (short)(((pr_default.getStatus(4) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "ALLPRODUCTS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(ALLPRODUCTS_nEOF), 1, 0, ".", "")));
            pr_default.close(4);
            wbEnd = 32;
            WB2B0( ) ;
         }
         bGXsfl_32_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2B2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUCTID"+"_"+sGXsfl_32_idx, GetSecureSignedToken( sGXsfl_32_idx, context.localUtil.Format( (decimal)(A15ProductId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUCTNAME"+"_"+sGXsfl_32_idx, GetSecureSignedToken( sGXsfl_32_idx, StringUtil.RTrim( context.localUtil.Format( A16ProductName, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUCTSTOCK"+"_"+sGXsfl_32_idx, GetSecureSignedToken( sGXsfl_32_idx, context.localUtil.Format( (decimal)(A17ProductStock), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUCTPRICE"+"_"+sGXsfl_32_idx, GetSecureSignedToken( sGXsfl_32_idx, context.localUtil.Format( A18ProductPrice, "ZZZZZZ9.99"), context));
         GxWebStd.gx_hidden_field( context, "vNEWQTY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16NewQty), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWQTY", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV16NewQty), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vNEWNAME", AV6newName);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6newName, "")), context));
         GxWebStd.gx_hidden_field( context, "vNEWCODE", AV5newCode);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV5newCode, "")), context));
      }

      protected void RF2B3( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            CarproductsContainer.ClearRows();
         }
         wbStart = 55;
         E152B2 ();
         nGXsfl_55_idx = 1;
         sGXsfl_55_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_55_idx), 4, 0), 4, "0");
         SubsflControlProps_553( ) ;
         bGXsfl_55_Refreshing = true;
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
            SubsflControlProps_553( ) ;
            E162B3 ();
            wbEnd = 55;
            WB2B0( ) ;
         }
         bGXsfl_55_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes2B3( )
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
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              AV11Code ,
                                              AV15Name ,
                                              AV21Supplier ,
                                              AV7Brand ,
                                              A55ProductCode ,
                                              A16ProductName ,
                                              A4SupplierId ,
                                              A1BrandId } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV11Code = StringUtil.Concat( StringUtil.RTrim( AV11Code), "%", "");
         lV15Name = StringUtil.Concat( StringUtil.RTrim( AV15Name), "%", "");
         /* Using cursor H002B7 */
         pr_default.execute(5, new Object[] {lV11Code, lV15Name, AV21Supplier, AV7Brand});
         ALLPRODUCTS_nRecordCount = H002B7_AALLPRODUCTS_nRecordCount[0];
         pr_default.close(5);
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
            gxgrAllproducts_refresh( subAllproducts_Rows, AV11Code, AV15Name, AV21Supplier, AV7Brand, AV12Employee, AV16NewQty, AV6newName, AV5newCode) ;
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
            gxgrAllproducts_refresh( subAllproducts_Rows, AV11Code, AV15Name, AV21Supplier, AV7Brand, AV12Employee, AV16NewQty, AV6newName, AV5newCode) ;
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
            gxgrAllproducts_refresh( subAllproducts_Rows, AV11Code, AV15Name, AV21Supplier, AV7Brand, AV12Employee, AV16NewQty, AV6newName, AV5newCode) ;
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
            gxgrAllproducts_refresh( subAllproducts_Rows, AV11Code, AV15Name, AV21Supplier, AV7Brand, AV12Employee, AV16NewQty, AV6newName, AV5newCode) ;
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
            gxgrAllproducts_refresh( subAllproducts_Rows, AV11Code, AV15Name, AV21Supplier, AV7Brand, AV12Employee, AV16NewQty, AV6newName, AV5newCode) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
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
         edtavTotal_Enabled = 0;
         AssignProp("", false, edtavTotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTotal_Enabled), 5, 0), true);
         edtavCtlname1_Enabled = 0;
         AssignProp("", false, edtavCtlname1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlname1_Enabled), 5, 0), !bGXsfl_55_Refreshing);
         edtavCtlunitprice1_Enabled = 0;
         AssignProp("", false, edtavCtlunitprice1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlunitprice1_Enabled), 5, 0), !bGXsfl_55_Refreshing);
         edtavCtlstock_Enabled = 0;
         AssignProp("", false, edtavCtlstock_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlstock_Enabled), 5, 0), !bGXsfl_55_Refreshing);
         edtavCtlsubtotal_Enabled = 0;
         AssignProp("", false, edtavCtlsubtotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsubtotal_Enabled), 5, 0), !bGXsfl_55_Refreshing);
         GXVvSUPPLIER_html2B2( ) ;
         GXVvBRAND_html2B2( ) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2B0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E182B2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Car"), AV8Car);
            /* Read saved values. */
            nRC_GXsfl_32 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_32"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_55 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_55"), ".", ","), 18, MidpointRounding.ToEven));
            ALLPRODUCTS_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "ALLPRODUCTS_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            ALLPRODUCTS_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "ALLPRODUCTS_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_55 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_55"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_55_fel_idx = 0;
            while ( nGXsfl_55_fel_idx < nRC_GXsfl_55 )
            {
               nGXsfl_55_fel_idx = ((subCarproducts_Islastpage==1)&&(nGXsfl_55_fel_idx+1>subCarproducts_fnc_Recordsperpage( )) ? 1 : nGXsfl_55_fel_idx+1);
               sGXsfl_55_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_55_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_553( ) ;
               AV26GXV1 = nGXsfl_55_fel_idx;
               if ( ( AV8Car.Count >= AV26GXV1 ) && ( AV26GXV1 > 0 ) )
               {
                  AV8Car.CurrentItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV8Car.Item(AV26GXV1));
               }
            }
            if ( nGXsfl_55_fel_idx == 0 )
            {
               nGXsfl_55_idx = 1;
               sGXsfl_55_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_55_idx), 4, 0), 4, "0");
               SubsflControlProps_553( ) ;
            }
            nGXsfl_55_fel_idx = 1;
            /* Read variables values. */
            dynavEmployee.Name = dynavEmployee_Internalname;
            dynavEmployee.CurrentValue = cgiGet( dynavEmployee_Internalname);
            AV12Employee = (int)(Math.Round(NumberUtil.Val( cgiGet( dynavEmployee_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV12Employee", StringUtil.LTrimStr( (decimal)(AV12Employee), 6, 0));
            AV11Code = cgiGet( edtavCode_Internalname);
            AssignAttri("", false, "AV11Code", AV11Code);
            AV15Name = cgiGet( edtavName_Internalname);
            AssignAttri("", false, "AV15Name", AV15Name);
            dynavSupplier.Name = dynavSupplier_Internalname;
            dynavSupplier.CurrentValue = cgiGet( dynavSupplier_Internalname);
            AV21Supplier = (int)(Math.Round(NumberUtil.Val( cgiGet( dynavSupplier_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV21Supplier", StringUtil.LTrimStr( (decimal)(AV21Supplier), 6, 0));
            dynavBrand.Name = dynavBrand_Internalname;
            dynavBrand.CurrentValue = cgiGet( dynavBrand_Internalname);
            AV7Brand = (int)(Math.Round(NumberUtil.Val( cgiGet( dynavBrand_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV7Brand", StringUtil.LTrimStr( (decimal)(AV7Brand), 6, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTotal_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTotal_Internalname), ".", ",") > 9999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTOTAL");
               GX_FocusControl = edtavTotal_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV22Total = 0;
               AssignAttri("", false, "AV22Total", StringUtil.LTrimStr( AV22Total, 10, 2));
            }
            else
            {
               AV22Total = context.localUtil.CToN( cgiGet( edtavTotal_Internalname), ".", ",");
               AssignAttri("", false, "AV22Total", StringUtil.LTrimStr( AV22Total, 10, 2));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCODE"), AV11Code) != 0 )
            {
               ALLPRODUCTS_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vNAME"), AV15Name) != 0 )
            {
               ALLPRODUCTS_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vSUPPLIER"), ".", ",") != Convert.ToDecimal( AV21Supplier )) )
            {
               ALLPRODUCTS_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vBRAND"), ".", ",") != Convert.ToDecimal( AV7Brand )) )
            {
               ALLPRODUCTS_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void E172B2( )
      {
         AV26GXV1 = nGXsfl_55_idx;
         if ( ( AV26GXV1 > 0 ) && ( AV8Car.Count >= AV26GXV1 ) )
         {
            AV8Car.CurrentItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV8Car.Item(AV26GXV1));
         }
         /* ProductName_Click Routine */
         returnInSub = false;
         if ( AV20SelectedId.IndexOf(A15ProductId) <= 0 )
         {
            AV20SelectedId.Clear();
            AV10CarItem.gxTpr_Id = A15ProductId;
            AV10CarItem.gxTpr_Name = A16ProductName;
            AV10CarItem.gxTpr_Stock = A17ProductStock;
            AV10CarItem.gxTpr_Unitprice = A18ProductPrice;
            AV10CarItem.gxTpr_Quantity = 0;
            AV9CarAux.Add(AV10CarItem, 0);
            AV20SelectedId.Add(A15ProductId, 0);
            AV32GXV7 = 1;
            while ( AV32GXV7 <= AV8Car.Count )
            {
               AV10CarItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV8Car.Item(AV32GXV7));
               AV9CarAux.Add(AV10CarItem, 0);
               AV20SelectedId.Add(AV10CarItem.gxTpr_Id, 0);
               AV32GXV7 = (int)(AV32GXV7+1);
            }
            AV8Car = (GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem>)(AV9CarAux.Clone());
            gx_BV55 = true;
            AV9CarAux.Clear();
         }
         if ( AV8Car.Count > 0 )
         {
            dynavEmployee.Enabled = 0;
            AssignProp("", false, dynavEmployee_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavEmployee.Enabled), 5, 0), true);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20SelectedId", AV20SelectedId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10CarItem", AV10CarItem);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV9CarAux", AV9CarAux);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV8Car", AV8Car);
         nGXsfl_55_bak_idx = nGXsfl_55_idx;
         gxgrCarproducts_refresh( subAllproducts_Rows, AV11Code, AV15Name, AV21Supplier, AV7Brand, AV8Car, AV12Employee, AV16NewQty, AV6newName, AV5newCode) ;
         nGXsfl_55_idx = nGXsfl_55_bak_idx;
         sGXsfl_55_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_55_idx), 4, 0), 4, "0");
         SubsflControlProps_553( ) ;
      }

      protected void E112B2( )
      {
         AV26GXV1 = nGXsfl_55_idx;
         if ( ( AV26GXV1 > 0 ) && ( AV8Car.Count >= AV26GXV1 ) )
         {
            AV8Car.CurrentItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV8Car.Item(AV26GXV1));
         }
         /* 'RegisterSale' Routine */
         returnInSub = false;
         AV19QuantitiesValid = true;
         AV33GXV8 = 1;
         while ( AV33GXV8 <= AV8Car.Count )
         {
            AV10CarItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV8Car.Item(AV33GXV8));
            if ( ( AV10CarItem.gxTpr_Quantity == 0 ) || ( AV10CarItem.gxTpr_Quantity > AV10CarItem.gxTpr_Stock ) )
            {
               AV19QuantitiesValid = false;
            }
            AV33GXV8 = (int)(AV33GXV8+1);
         }
         if ( ( ( AV8Car.Count > 0 ) ) && ( AV19QuantitiesValid ) )
         {
            AV13Invoice = new SdtInvoice(context);
            AV13Invoice.gxTpr_Employeeid = AV12Employee;
            AV34GXV9 = 1;
            while ( AV34GXV9 <= AV8Car.Count )
            {
               AV10CarItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV8Car.Item(AV34GXV9));
               AV14InvoiceDetail = new SdtInvoice_Detail(context);
               AV14InvoiceDetail.gxTpr_Productid = AV10CarItem.gxTpr_Id;
               AV14InvoiceDetail.gxTpr_Invoicedetailquantity = AV10CarItem.gxTpr_Quantity;
               AV14InvoiceDetail.gxTpr_Invoicedetailhistoricprice = AV10CarItem.gxTpr_Unitprice;
               AV18Product.Load(AV10CarItem.gxTpr_Id);
               AV18Product.gxTpr_Productstock = (int)(AV18Product.gxTpr_Productstock-(AV10CarItem.gxTpr_Quantity));
               AV18Product.Update();
               if ( AV18Product.Success() )
               {
                  context.CommitDataStores("wpregisterdiscardedproduct",pr_default);
               }
               else
               {
                  context.RollbackDataStores("wpregisterdiscardedproduct",pr_default);
                  GX_msglist.addItem("Product "+AV18Product.gxTpr_Productname+" update fail!");
               }
               AV13Invoice.gxTpr_Detail.Add(AV14InvoiceDetail, 0);
               AV34GXV9 = (int)(AV34GXV9+1);
            }
            AV13Invoice.Insert();
            if ( AV13Invoice.Success() )
            {
               context.CommitDataStores("wpregisterdiscardedproduct",pr_default);
               AV22Total = 0;
               AssignAttri("", false, "AV22Total", StringUtil.LTrimStr( AV22Total, 10, 2));
               AV8Car.Clear();
               gx_BV55 = true;
               AV20SelectedId.Clear();
               GX_msglist.addItem("Successful Registered Sale!");
            }
            else
            {
               context.RollbackDataStores("wpregisterdiscardedproduct",pr_default);
               GX_msglist.addItem("Sale Register fail"+AV13Invoice.GetMessages().ToJSonString(false));
            }
         }
         else
         {
            if ( AV8Car.Count > 0 )
            {
               GX_msglist.addItem("Some quantities are invalids");
            }
            else
            {
               GX_msglist.addItem("Choose at least one product before register a sale");
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10CarItem", AV10CarItem);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV8Car", AV8Car);
         nGXsfl_55_bak_idx = nGXsfl_55_idx;
         gxgrCarproducts_refresh( subAllproducts_Rows, AV11Code, AV15Name, AV21Supplier, AV7Brand, AV8Car, AV12Employee, AV16NewQty, AV6newName, AV5newCode) ;
         nGXsfl_55_idx = nGXsfl_55_bak_idx;
         sGXsfl_55_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_55_idx), 4, 0), 4, "0");
         SubsflControlProps_553( ) ;
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20SelectedId", AV20SelectedId);
      }

      protected void E142B2( )
      {
         AV26GXV1 = nGXsfl_55_idx;
         if ( ( AV26GXV1 > 0 ) && ( AV8Car.Count >= AV26GXV1 ) )
         {
            AV8Car.CurrentItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV8Car.Item(AV26GXV1));
         }
         /* Ctlquantity1_Controlvaluechanging Routine */
         returnInSub = false;
         AV10CarItem = ((SdtSDTCarProducts_SDTCarProductsItem)(AV8Car.CurrentItem));
         if ( AV10CarItem.gxTpr_Quantity > AV10CarItem.gxTpr_Stock )
         {
            GX_msglist.addItem("there is not enough stock");
            AV10CarItem.gxTpr_Quantity = AV10CarItem.gxTpr_Stock;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10CarItem", AV10CarItem);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV8Car", AV8Car);
         nGXsfl_55_bak_idx = nGXsfl_55_idx;
         gxgrCarproducts_refresh( subAllproducts_Rows, AV11Code, AV15Name, AV21Supplier, AV7Brand, AV8Car, AV12Employee, AV16NewQty, AV6newName, AV5newCode) ;
         nGXsfl_55_idx = nGXsfl_55_bak_idx;
         sGXsfl_55_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_55_idx), 4, 0), 4, "0");
         SubsflControlProps_553( ) ;
      }

      protected void E122B2( )
      {
         /* 'ClearSale' Routine */
         returnInSub = false;
         AV22Total = 0;
         AssignAttri("", false, "AV22Total", StringUtil.LTrimStr( AV22Total, 10, 2));
         AV8Car.Clear();
         gx_BV55 = true;
         AV20SelectedId.Clear();
         /*  Sending Event outputs  */
         if ( gx_BV55 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV8Car", AV8Car);
            nGXsfl_55_bak_idx = nGXsfl_55_idx;
            gxgrCarproducts_refresh( subAllproducts_Rows, AV11Code, AV15Name, AV21Supplier, AV7Brand, AV8Car, AV12Employee, AV16NewQty, AV6newName, AV5newCode) ;
            nGXsfl_55_idx = nGXsfl_55_bak_idx;
            sGXsfl_55_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_55_idx), 4, 0), 4, "0");
            SubsflControlProps_553( ) ;
         }
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20SelectedId", AV20SelectedId);
      }

      protected void E132B2( )
      {
         AV26GXV1 = nGXsfl_55_idx;
         if ( ( AV26GXV1 > 0 ) && ( AV8Car.Count >= AV26GXV1 ) )
         {
            AV8Car.CurrentItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV8Car.Item(AV26GXV1));
         }
         /* 'Remove' Routine */
         returnInSub = false;
         AV17Position = AV20SelectedId.IndexOf(((SdtSDTCarProducts_SDTCarProductsItem)(AV8Car.CurrentItem)).gxTpr_Id);
         AV20SelectedId.RemoveItem(AV17Position);
         AV8Car.RemoveItem(AV17Position);
         gx_BV55 = true;
         if ( AV8Car.Count < 1 )
         {
            dynavEmployee.Enabled = 1;
            AssignProp("", false, dynavEmployee_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavEmployee.Enabled), 5, 0), true);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20SelectedId", AV20SelectedId);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV8Car", AV8Car);
         nGXsfl_55_bak_idx = nGXsfl_55_idx;
         gxgrCarproducts_refresh( subAllproducts_Rows, AV11Code, AV15Name, AV21Supplier, AV7Brand, AV8Car, AV12Employee, AV16NewQty, AV6newName, AV5newCode) ;
         nGXsfl_55_idx = nGXsfl_55_bak_idx;
         sGXsfl_55_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_55_idx), 4, 0), 4, "0");
         SubsflControlProps_553( ) ;
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E182B2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E182B2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV22Total = 0;
         AssignAttri("", false, "AV22Total", StringUtil.LTrimStr( AV22Total, 10, 2));
      }

      protected void E152B2( )
      {
         AV26GXV1 = nGXsfl_55_idx;
         if ( ( AV26GXV1 > 0 ) && ( AV8Car.Count >= AV26GXV1 ) )
         {
            AV8Car.CurrentItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV8Car.Item(AV26GXV1));
         }
         /* Carproducts_Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CALCULATETOTAL' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10CarItem", AV10CarItem);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV8Car", AV8Car);
      }

      protected void S112( )
      {
         /* 'CALCULATETOTAL' Routine */
         returnInSub = false;
         AV22Total = 0;
         AssignAttri("", false, "AV22Total", StringUtil.LTrimStr( AV22Total, 10, 2));
         AV35GXV10 = 1;
         while ( AV35GXV10 <= AV8Car.Count )
         {
            AV10CarItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV8Car.Item(AV35GXV10));
            AV10CarItem.gxTpr_Subtotal = (decimal)(AV10CarItem.gxTpr_Quantity*AV10CarItem.gxTpr_Unitprice);
            AV22Total = (decimal)(AV22Total+(AV10CarItem.gxTpr_Subtotal));
            AssignAttri("", false, "AV22Total", StringUtil.LTrimStr( AV22Total, 10, 2));
            AV35GXV10 = (int)(AV35GXV10+1);
         }
      }

      private void E192B2( )
      {
         /* Allproducts_Load Routine */
         returnInSub = false;
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 32;
         }
         sendrow_322( ) ;
         ALLPRODUCTS_nCurrentRecord = (long)(ALLPRODUCTS_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_32_Refreshing )
         {
            DoAjaxLoad(32, AllproductsRow);
         }
      }

      private void E162B3( )
      {
         /* Carproducts_Load Routine */
         returnInSub = false;
         AV26GXV1 = 1;
         while ( AV26GXV1 <= AV8Car.Count )
         {
            AV8Car.CurrentItem = ((SdtSDTCarProducts_SDTCarProductsItem)AV8Car.Item(AV26GXV1));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 55;
            }
            sendrow_553( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_55_Refreshing )
            {
               DoAjaxLoad(55, CarproductsRow);
            }
            AV26GXV1 = (int)(AV26GXV1+1);
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
         PA2B2( ) ;
         WS2B2( ) ;
         WE2B2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202312190224763", true, true);
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
         context.AddJavascriptSource("wpregisterdiscardedproduct.js", "?202312190224763", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_322( )
      {
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_32_idx;
         edtProductCode_Internalname = "PRODUCTCODE_"+sGXsfl_32_idx;
         edtProductName_Internalname = "PRODUCTNAME_"+sGXsfl_32_idx;
         edtProductPrice_Internalname = "PRODUCTPRICE_"+sGXsfl_32_idx;
         edtProductStock_Internalname = "PRODUCTSTOCK_"+sGXsfl_32_idx;
      }

      protected void SubsflControlProps_fel_322( )
      {
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_32_fel_idx;
         edtProductCode_Internalname = "PRODUCTCODE_"+sGXsfl_32_fel_idx;
         edtProductName_Internalname = "PRODUCTNAME_"+sGXsfl_32_fel_idx;
         edtProductPrice_Internalname = "PRODUCTPRICE_"+sGXsfl_32_fel_idx;
         edtProductStock_Internalname = "PRODUCTSTOCK_"+sGXsfl_32_fel_idx;
      }

      protected void sendrow_322( )
      {
         SubsflControlProps_322( ) ;
         WB2B0( ) ;
         if ( ( 5 * 1 == 0 ) || ( nGXsfl_32_idx <= subAllproducts_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_32_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_32_idx+"\">") ;
            }
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A15ProductId), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)32,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductCode_Internalname,(string)A55ProductCode,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductCode_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)32,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusUnanimo\\Code",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductName_Internalname,(string)A16ProductName,(string)"",(string)"","'"+""+"'"+",false,"+"'"+"EPRODUCTNAME.CLICK."+sGXsfl_32_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductName_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)32,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductPrice_Internalname,StringUtil.LTrim( StringUtil.NToC( A18ProductPrice, 10, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A18ProductPrice, "ZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductPrice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)32,(short)0,(short)-1,(short)0,(bool)true,(string)"Price",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( AllproductsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            AllproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductStock_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A17ProductStock), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A17ProductStock), "ZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductStock_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)32,(short)0,(short)-1,(short)0,(bool)true,(string)"Stock",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes2B2( ) ;
            AllproductsContainer.AddRow(AllproductsRow);
            nGXsfl_32_idx = ((subAllproducts_Islastpage==1)&&(nGXsfl_32_idx+1>subAllproducts_fnc_Recordsperpage( )) ? 1 : nGXsfl_32_idx+1);
            sGXsfl_32_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_32_idx), 4, 0), 4, "0");
            SubsflControlProps_322( ) ;
         }
         /* End function sendrow_322 */
      }

      protected void SubsflControlProps_553( )
      {
         edtavCtlname1_Internalname = "CTLNAME1_"+sGXsfl_55_idx;
         edtavCtlunitprice1_Internalname = "CTLUNITPRICE1_"+sGXsfl_55_idx;
         edtavCtlstock_Internalname = "CTLSTOCK_"+sGXsfl_55_idx;
         edtavCtlquantity1_Internalname = "CTLQUANTITY1_"+sGXsfl_55_idx;
         edtavCtlsubtotal_Internalname = "CTLSUBTOTAL_"+sGXsfl_55_idx;
      }

      protected void SubsflControlProps_fel_553( )
      {
         edtavCtlname1_Internalname = "CTLNAME1_"+sGXsfl_55_fel_idx;
         edtavCtlunitprice1_Internalname = "CTLUNITPRICE1_"+sGXsfl_55_fel_idx;
         edtavCtlstock_Internalname = "CTLSTOCK_"+sGXsfl_55_fel_idx;
         edtavCtlquantity1_Internalname = "CTLQUANTITY1_"+sGXsfl_55_fel_idx;
         edtavCtlsubtotal_Internalname = "CTLSUBTOTAL_"+sGXsfl_55_fel_idx;
      }

      protected void sendrow_553( )
      {
         SubsflControlProps_553( ) ;
         WB2B0( ) ;
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
            if ( ((int)((nGXsfl_55_idx) % (2))) == 0 )
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
            context.WriteHtmlText( "<tr"+" class=\""+subCarproducts_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_55_idx+"\">") ;
         }
         CarproductsRow.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)subCarproducts_Linesclass,(string)""});
         CarproductsRow.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         CarproductsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divGrid1table_Internalname+"_"+sGXsfl_55_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         CarproductsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         CarproductsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         CarproductsRow.AddColumnProperties("button", 2, isAjaxCallMode( ), new Object[] {(string)bttRemove_Internalname+"_"+sGXsfl_55_idx,"gx.evt.setGridEvt("+StringUtil.Str( (decimal)(55), 2, 0)+","+"null"+");",(string)"Remove",(string)bttRemove_Jsonclick,(short)5,(string)"Remove",(string)"",(string)StyleString,(string)ClassString,(short)1,(short)1,(string)"standard","'"+""+"'"+",false,"+"'"+"E\\'REMOVE\\'."+"'",(string)TempTags,(string)"",context.GetButtonType( )});
         CarproductsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         CarproductsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         CarproductsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         CarproductsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname1_Internalname,(string)"Name",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         CarproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlname1_Internalname,((SdtSDTCarProducts_SDTCarProductsItem)AV8Car.Item(AV26GXV1)).gxTpr_Name,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlname1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlname1_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)55,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         CarproductsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CarproductsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         CarproductsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         CarproductsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         CarproductsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlunitprice1_Internalname,(string)"Unit Price",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         CarproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlunitprice1_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTCarProducts_SDTCarProductsItem)AV8Car.Item(AV26GXV1)).gxTpr_Unitprice, 10, 2, ".", "")),StringUtil.LTrim( ((edtavCtlunitprice1_Enabled!=0) ? context.localUtil.Format( ((SdtSDTCarProducts_SDTCarProductsItem)AV8Car.Item(AV26GXV1)).gxTpr_Unitprice, "ZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTCarProducts_SDTCarProductsItem)AV8Car.Item(AV26GXV1)).gxTpr_Unitprice, "ZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlunitprice1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlunitprice1_Enabled,(short)0,(string)"text",(string)"",(short)10,(string)"chr",(short)1,(string)"row",(short)10,(short)0,(short)0,(short)55,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         CarproductsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CarproductsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         CarproductsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         CarproductsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         CarproductsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlstock_Internalname,(string)"Stock",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         CarproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlstock_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV8Car.Item(AV26GXV1)).gxTpr_Stock), 6, 0, ".", "")),StringUtil.LTrim( ((edtavCtlstock_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV8Car.Item(AV26GXV1)).gxTpr_Stock), "ZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV8Car.Item(AV26GXV1)).gxTpr_Stock), "ZZZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlstock_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlstock_Enabled,(short)0,(string)"text",(string)"1",(short)6,(string)"chr",(short)1,(string)"row",(short)6,(short)0,(short)0,(short)55,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         CarproductsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CarproductsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         CarproductsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         CarproductsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         CarproductsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlquantity1_Internalname,(string)"Quantity",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         TempTags = " " + ((edtavCtlquantity1_Enabled!=0)&&(edtavCtlquantity1_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 73,'',false,'"+sGXsfl_55_idx+"',55)\"" : " ");
         ROClassString = "Attribute";
         CarproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlquantity1_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV8Car.Item(AV26GXV1)).gxTpr_Quantity), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(((SdtSDTCarProducts_SDTCarProductsItem)AV8Car.Item(AV26GXV1)).gxTpr_Quantity), "ZZZZZ9"))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+((edtavCtlquantity1_Enabled!=0)&&(edtavCtlquantity1_Visible!=0) ? " onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,73);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlquantity1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)1,(short)0,(string)"text",(string)"1",(short)6,(string)"chr",(short)1,(string)"row",(short)6,(short)0,(short)0,(short)55,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         CarproductsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CarproductsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         CarproductsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-2",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         CarproductsRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         CarproductsRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsubtotal_Internalname,(string)"Subtotal",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         CarproductsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsubtotal_Internalname,StringUtil.LTrim( StringUtil.NToC( ((SdtSDTCarProducts_SDTCarProductsItem)AV8Car.Item(AV26GXV1)).gxTpr_Subtotal, 10, 2, ".", "")),StringUtil.LTrim( ((edtavCtlsubtotal_Enabled!=0) ? context.localUtil.Format( ((SdtSDTCarProducts_SDTCarProductsItem)AV8Car.Item(AV26GXV1)).gxTpr_Subtotal, "ZZZZZZ9.99") : context.localUtil.Format( ((SdtSDTCarProducts_SDTCarProductsItem)AV8Car.Item(AV26GXV1)).gxTpr_Subtotal, "ZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlsubtotal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlsubtotal_Enabled,(short)0,(string)"text",(string)"",(short)10,(string)"chr",(short)1,(string)"row",(short)10,(short)0,(short)0,(short)55,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         CarproductsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CarproductsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CarproductsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         CarproductsRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         if ( CarproductsContainer.GetWrapped() == 1 )
         {
            CarproductsContainer.CloseTag("cell");
         }
         if ( CarproductsContainer.GetWrapped() == 1 )
         {
            CarproductsContainer.CloseTag("row");
         }
         send_integrity_lvl_hashes2B3( ) ;
         /* End of Columns property logic. */
         if ( CarproductsContainer.GetWrapped() == 1 )
         {
            if ( 1 > 0 )
            {
               if ( ((int)((nGXsfl_55_idx) % (1))) == 0 )
               {
                  context.WriteHtmlTextNl( "</tr>") ;
               }
            }
         }
         CarproductsContainer.AddRow(CarproductsRow);
         nGXsfl_55_idx = ((subCarproducts_Islastpage==1)&&(nGXsfl_55_idx+1>subCarproducts_fnc_Recordsperpage( )) ? 1 : nGXsfl_55_idx+1);
         sGXsfl_55_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_55_idx), 4, 0), 4, "0");
         SubsflControlProps_553( ) ;
         /* End function sendrow_553 */
      }

      protected void init_web_controls( )
      {
         dynavEmployee.Name = "vEMPLOYEE";
         dynavEmployee.WebTags = "";
         dynavEmployee.removeAllItems();
         /* Using cursor H002B8 */
         pr_default.execute(6);
         while ( (pr_default.getStatus(6) != 101) )
         {
            dynavEmployee.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H002B8_A12EmployeeId[0]), 6, 0)), H002B8_A13EmployeeFirstName[0], 0);
            pr_default.readNext(6);
         }
         pr_default.close(6);
         if ( dynavEmployee.ItemCount > 0 )
         {
            AV12Employee = (int)(Math.Round(NumberUtil.Val( dynavEmployee.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV12Employee), 6, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV12Employee", StringUtil.LTrimStr( (decimal)(AV12Employee), 6, 0));
         }
         dynavSupplier.Name = "vSUPPLIER";
         dynavSupplier.WebTags = "";
         dynavBrand.Name = "vBRAND";
         dynavBrand.WebTags = "";
         /* End function init_web_controls */
      }

      protected void StartGridControl32( )
      {
         if ( AllproductsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"AllproductsContainer"+"DivS\" data-gxgridid=\"32\">") ;
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
            context.SendWebValue( "Product Code") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Product Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Product Price") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Product Stock") ;
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
            AllproductsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A55ProductCode));
            AllproductsContainer.AddColumnProperties(AllproductsColumn);
            AllproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A16ProductName));
            AllproductsContainer.AddColumnProperties(AllproductsColumn);
            AllproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A18ProductPrice, 10, 2, ".", ""))));
            AllproductsContainer.AddColumnProperties(AllproductsColumn);
            AllproductsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            AllproductsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A17ProductStock), 6, 0, ".", ""))));
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

      protected void StartGridControl55( )
      {
         if ( CarproductsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"CarproductsContainer"+"DivS\" data-gxgridid=\"55\">") ;
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
            CarproductsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlunitprice1_Enabled), 5, 0, ".", "")));
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

      protected void init_default_properties( )
      {
         dynavEmployee_Internalname = "vEMPLOYEE";
         edtavCode_Internalname = "vCODE";
         edtavName_Internalname = "vNAME";
         dynavSupplier_Internalname = "vSUPPLIER";
         dynavBrand_Internalname = "vBRAND";
         edtProductId_Internalname = "PRODUCTID";
         edtProductCode_Internalname = "PRODUCTCODE";
         edtProductName_Internalname = "PRODUCTNAME";
         edtProductPrice_Internalname = "PRODUCTPRICE";
         edtProductStock_Internalname = "PRODUCTSTOCK";
         divTable1_Internalname = "TABLE1";
         bttRegistersale_Internalname = "REGISTERSALE";
         bttClearsale_Internalname = "CLEARSALE";
         edtavTotal_Internalname = "vTOTAL";
         bttRemove_Internalname = "REMOVE";
         edtavCtlname1_Internalname = "CTLNAME1";
         edtavCtlunitprice1_Internalname = "CTLUNITPRICE1";
         edtavCtlstock_Internalname = "CTLSTOCK";
         edtavCtlquantity1_Internalname = "CTLQUANTITY1";
         edtavCtlsubtotal_Internalname = "CTLSUBTOTAL";
         divGrid1table_Internalname = "GRID1TABLE";
         divTable2_Internalname = "TABLE2";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subAllproducts_Internalname = "ALLPRODUCTS";
         subCarproducts_Internalname = "CARPRODUCTS";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("mtaKB", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subCarproducts_Allowcollapsing = 0;
         subAllproducts_Allowcollapsing = 0;
         subAllproducts_Allowselection = 0;
         subAllproducts_Header = "";
         edtavCtlsubtotal_Jsonclick = "";
         edtavCtlsubtotal_Enabled = 0;
         edtavCtlquantity1_Jsonclick = "";
         edtavCtlquantity1_Visible = 1;
         edtavCtlquantity1_Enabled = 1;
         edtavCtlstock_Jsonclick = "";
         edtavCtlstock_Enabled = 0;
         edtavCtlunitprice1_Jsonclick = "";
         edtavCtlunitprice1_Enabled = 0;
         edtavCtlname1_Jsonclick = "";
         edtavCtlname1_Enabled = 0;
         subCarproducts_Class = "PromptGrid";
         edtProductStock_Jsonclick = "";
         edtProductPrice_Jsonclick = "";
         edtProductName_Jsonclick = "";
         edtProductCode_Jsonclick = "";
         edtProductId_Jsonclick = "";
         subAllproducts_Class = "PromptGrid";
         subAllproducts_Backcolorstyle = 0;
         subCarproducts_Backcolorstyle = 0;
         edtavCtlsubtotal_Enabled = -1;
         edtavCtlstock_Enabled = -1;
         edtavCtlunitprice1_Enabled = -1;
         edtavCtlname1_Enabled = -1;
         edtavTotal_Jsonclick = "";
         edtavTotal_Enabled = 1;
         dynavBrand_Jsonclick = "";
         dynavBrand.Enabled = 1;
         dynavSupplier_Jsonclick = "";
         dynavSupplier.Enabled = 1;
         edtavName_Jsonclick = "";
         edtavName_Enabled = 1;
         edtavCode_Jsonclick = "";
         edtavCode_Enabled = 1;
         dynavEmployee_Jsonclick = "";
         dynavEmployee.Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "WPRegister Discarded Product";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'CARPRODUCTS_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV11Code',fld:'vCODE',pic:''},{av:'AV15Name',fld:'vNAME',pic:''},{av:'AV8Car',fld:'vCAR',grid:55,pic:''},{av:'nGXsfl_55_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:55},{av:'nRC_GXsfl_55',ctrl:'CARPRODUCTS',prop:'GridRC',grid:55},{av:'dynavSupplier'},{av:'AV21Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV7Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavEmployee'},{av:'AV12Employee',fld:'vEMPLOYEE',pic:'ZZZZZ9'},{av:'AV16NewQty',fld:'vNEWQTY',pic:'ZZZ9',hsh:true},{av:'AV6newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5newCode',fld:'vNEWCODE',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("PRODUCTNAME.CLICK","{handler:'E172B2',iparms:[{av:'AV20SelectedId',fld:'vSELECTEDID',pic:''},{av:'A15ProductId',fld:'PRODUCTID',pic:'ZZZZZ9',hsh:true},{av:'AV10CarItem',fld:'vCARITEM',pic:''},{av:'A16ProductName',fld:'PRODUCTNAME',pic:'',hsh:true},{av:'A17ProductStock',fld:'PRODUCTSTOCK',pic:'ZZZZZ9',hsh:true},{av:'A18ProductPrice',fld:'PRODUCTPRICE',pic:'ZZZZZZ9.99',hsh:true},{av:'AV9CarAux',fld:'vCARAUX',pic:''},{av:'AV8Car',fld:'vCAR',grid:55,pic:''},{av:'nGXsfl_55_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:55},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'nRC_GXsfl_55',ctrl:'CARPRODUCTS',prop:'GridRC',grid:55},{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'CARPRODUCTS_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV11Code',fld:'vCODE',pic:''},{av:'AV15Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV21Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV7Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavEmployee'},{av:'AV12Employee',fld:'vEMPLOYEE',pic:'ZZZZZ9'},{av:'AV16NewQty',fld:'vNEWQTY',pic:'ZZZ9',hsh:true},{av:'AV6newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5newCode',fld:'vNEWCODE',pic:'',hsh:true}]");
         setEventMetadata("PRODUCTNAME.CLICK",",oparms:[{av:'AV20SelectedId',fld:'vSELECTEDID',pic:''},{av:'AV10CarItem',fld:'vCARITEM',pic:''},{av:'AV9CarAux',fld:'vCARAUX',pic:''},{av:'AV8Car',fld:'vCAR',grid:55,pic:''},{av:'nGXsfl_55_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:55},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'nRC_GXsfl_55',ctrl:'CARPRODUCTS',prop:'GridRC',grid:55},{av:'dynavEmployee'}]}");
         setEventMetadata("'REGISTERSALE'","{handler:'E112B2',iparms:[{av:'AV8Car',fld:'vCAR',grid:55,pic:''},{av:'nGXsfl_55_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:55},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'nRC_GXsfl_55',ctrl:'CARPRODUCTS',prop:'GridRC',grid:55},{av:'dynavEmployee'},{av:'AV12Employee',fld:'vEMPLOYEE',pic:'ZZZZZ9'},{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'CARPRODUCTS_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV11Code',fld:'vCODE',pic:''},{av:'AV15Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV21Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV7Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'AV16NewQty',fld:'vNEWQTY',pic:'ZZZ9',hsh:true},{av:'AV6newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5newCode',fld:'vNEWCODE',pic:'',hsh:true}]");
         setEventMetadata("'REGISTERSALE'",",oparms:[{av:'AV10CarItem',fld:'vCARITEM',pic:''},{av:'AV22Total',fld:'vTOTAL',pic:'ZZZZZZ9.99'},{av:'AV8Car',fld:'vCAR',grid:55,pic:''},{av:'nGXsfl_55_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:55},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'nRC_GXsfl_55',ctrl:'CARPRODUCTS',prop:'GridRC',grid:55},{av:'AV20SelectedId',fld:'vSELECTEDID',pic:''}]}");
         setEventMetadata("CTLQUANTITY1.CONTROLVALUECHANGING","{handler:'E142B2',iparms:[{av:'AV16NewQty',fld:'vNEWQTY',pic:'ZZZ9',hsh:true},{av:'AV8Car',fld:'vCAR',grid:55,pic:''},{av:'nGXsfl_55_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:55},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'nRC_GXsfl_55',ctrl:'CARPRODUCTS',prop:'GridRC',grid:55},{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'CARPRODUCTS_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV11Code',fld:'vCODE',pic:''},{av:'AV15Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV21Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV7Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavEmployee'},{av:'AV12Employee',fld:'vEMPLOYEE',pic:'ZZZZZ9'},{av:'AV6newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5newCode',fld:'vNEWCODE',pic:'',hsh:true}]");
         setEventMetadata("CTLQUANTITY1.CONTROLVALUECHANGING",",oparms:[{av:'AV10CarItem',fld:'vCARITEM',pic:''},{av:'AV8Car',fld:'vCAR',grid:55,pic:''},{av:'nGXsfl_55_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:55},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'nRC_GXsfl_55',ctrl:'CARPRODUCTS',prop:'GridRC',grid:55}]}");
         setEventMetadata("'CLEARSALE'","{handler:'E122B2',iparms:[{av:'AV8Car',fld:'vCAR',grid:55,pic:''},{av:'nGXsfl_55_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:55},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'nRC_GXsfl_55',ctrl:'CARPRODUCTS',prop:'GridRC',grid:55},{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'CARPRODUCTS_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV11Code',fld:'vCODE',pic:''},{av:'AV15Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV21Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV7Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavEmployee'},{av:'AV12Employee',fld:'vEMPLOYEE',pic:'ZZZZZ9'},{av:'AV16NewQty',fld:'vNEWQTY',pic:'ZZZ9',hsh:true},{av:'AV6newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5newCode',fld:'vNEWCODE',pic:'',hsh:true}]");
         setEventMetadata("'CLEARSALE'",",oparms:[{av:'AV22Total',fld:'vTOTAL',pic:'ZZZZZZ9.99'},{av:'AV8Car',fld:'vCAR',grid:55,pic:''},{av:'nGXsfl_55_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:55},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'nRC_GXsfl_55',ctrl:'CARPRODUCTS',prop:'GridRC',grid:55},{av:'AV20SelectedId',fld:'vSELECTEDID',pic:''}]}");
         setEventMetadata("'REMOVE'","{handler:'E132B2',iparms:[{av:'AV8Car',fld:'vCAR',grid:55,pic:''},{av:'nGXsfl_55_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:55},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'nRC_GXsfl_55',ctrl:'CARPRODUCTS',prop:'GridRC',grid:55},{av:'AV20SelectedId',fld:'vSELECTEDID',pic:''},{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'CARPRODUCTS_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV11Code',fld:'vCODE',pic:''},{av:'AV15Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV21Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV7Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavEmployee'},{av:'AV12Employee',fld:'vEMPLOYEE',pic:'ZZZZZ9'},{av:'AV16NewQty',fld:'vNEWQTY',pic:'ZZZ9',hsh:true},{av:'AV6newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5newCode',fld:'vNEWCODE',pic:'',hsh:true}]");
         setEventMetadata("'REMOVE'",",oparms:[{av:'AV20SelectedId',fld:'vSELECTEDID',pic:''},{av:'AV8Car',fld:'vCAR',grid:55,pic:''},{av:'nGXsfl_55_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:55},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'nRC_GXsfl_55',ctrl:'CARPRODUCTS',prop:'GridRC',grid:55},{av:'dynavEmployee'}]}");
         setEventMetadata("CARPRODUCTS.REFRESH","{handler:'E152B2',iparms:[{av:'AV8Car',fld:'vCAR',grid:55,pic:''},{av:'nGXsfl_55_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:55},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'nRC_GXsfl_55',ctrl:'CARPRODUCTS',prop:'GridRC',grid:55},{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'CARPRODUCTS_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV11Code',fld:'vCODE',pic:''},{av:'AV15Name',fld:'vNAME',pic:''},{av:'dynavSupplier'},{av:'AV21Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV7Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavEmployee'},{av:'AV12Employee',fld:'vEMPLOYEE',pic:'ZZZZZ9'},{av:'AV16NewQty',fld:'vNEWQTY',pic:'ZZZ9',hsh:true},{av:'AV6newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5newCode',fld:'vNEWCODE',pic:'',hsh:true}]");
         setEventMetadata("CARPRODUCTS.REFRESH",",oparms:[{av:'AV22Total',fld:'vTOTAL',pic:'ZZZZZZ9.99'},{av:'AV10CarItem',fld:'vCARITEM',pic:''},{av:'AV8Car',fld:'vCAR',grid:55,pic:''},{av:'nGXsfl_55_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:55},{av:'CARPRODUCTS_nFirstRecordOnPage'},{av:'nRC_GXsfl_55',ctrl:'CARPRODUCTS',prop:'GridRC',grid:55}]}");
         setEventMetadata("ALLPRODUCTS_FIRSTPAGE","{handler:'suballproducts_firstpage',iparms:[{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV11Code',fld:'vCODE',pic:''},{av:'AV15Name',fld:'vNAME',pic:''},{av:'AV16NewQty',fld:'vNEWQTY',pic:'ZZZ9',hsh:true},{av:'AV6newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'dynavSupplier'},{av:'AV21Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV7Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavEmployee'},{av:'AV12Employee',fld:'vEMPLOYEE',pic:'ZZZZZ9'}]");
         setEventMetadata("ALLPRODUCTS_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("ALLPRODUCTS_PREVPAGE","{handler:'suballproducts_previouspage',iparms:[{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV11Code',fld:'vCODE',pic:''},{av:'AV15Name',fld:'vNAME',pic:''},{av:'AV16NewQty',fld:'vNEWQTY',pic:'ZZZ9',hsh:true},{av:'AV6newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'dynavSupplier'},{av:'AV21Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV7Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavEmployee'},{av:'AV12Employee',fld:'vEMPLOYEE',pic:'ZZZZZ9'}]");
         setEventMetadata("ALLPRODUCTS_PREVPAGE",",oparms:[]}");
         setEventMetadata("ALLPRODUCTS_NEXTPAGE","{handler:'suballproducts_nextpage',iparms:[{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV11Code',fld:'vCODE',pic:''},{av:'AV15Name',fld:'vNAME',pic:''},{av:'AV16NewQty',fld:'vNEWQTY',pic:'ZZZ9',hsh:true},{av:'AV6newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'dynavSupplier'},{av:'AV21Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV7Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavEmployee'},{av:'AV12Employee',fld:'vEMPLOYEE',pic:'ZZZZZ9'}]");
         setEventMetadata("ALLPRODUCTS_NEXTPAGE",",oparms:[]}");
         setEventMetadata("ALLPRODUCTS_LASTPAGE","{handler:'suballproducts_lastpage',iparms:[{av:'ALLPRODUCTS_nFirstRecordOnPage'},{av:'ALLPRODUCTS_nEOF'},{av:'subAllproducts_Rows',ctrl:'ALLPRODUCTS',prop:'Rows'},{av:'AV11Code',fld:'vCODE',pic:''},{av:'AV15Name',fld:'vNAME',pic:''},{av:'AV16NewQty',fld:'vNEWQTY',pic:'ZZZ9',hsh:true},{av:'AV6newName',fld:'vNEWNAME',pic:'',hsh:true},{av:'AV5newCode',fld:'vNEWCODE',pic:'',hsh:true},{av:'dynavSupplier'},{av:'AV21Supplier',fld:'vSUPPLIER',pic:'ZZZZZ9'},{av:'dynavBrand'},{av:'AV7Brand',fld:'vBRAND',pic:'ZZZZZ9'},{av:'dynavEmployee'},{av:'AV12Employee',fld:'vEMPLOYEE',pic:'ZZZZZ9'}]");
         setEventMetadata("ALLPRODUCTS_LASTPAGE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Productstock',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Gxv6',iparms:[]");
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
         AV11Code = "";
         AV15Name = "";
         AV6newName = "";
         AV5newCode = "";
         AV8Car = new GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem>( context, "SDTCarProductsItem", "mtaKB");
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV20SelectedId = new GxSimpleCollection<int>();
         AV10CarItem = new SdtSDTCarProducts_SDTCarProductsItem(context);
         AV9CarAux = new GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem>( context, "SDTCarProductsItem", "mtaKB");
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         AllproductsContainer = new GXWebGrid( context);
         sStyleString = "";
         ClassString = "";
         StyleString = "";
         bttRegistersale_Jsonclick = "";
         bttClearsale_Jsonclick = "";
         CarproductsContainer = new GXWebGrid( context);
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A55ProductCode = "";
         A16ProductName = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         scmdbuf = "";
         H002B2_A12EmployeeId = new int[1] ;
         H002B2_A13EmployeeFirstName = new string[] {""} ;
         H002B3_A4SupplierId = new int[1] ;
         H002B3_A5SupplierName = new string[] {""} ;
         H002B4_A1BrandId = new int[1] ;
         H002B4_A2BrandName = new string[] {""} ;
         H002B5_A12EmployeeId = new int[1] ;
         H002B5_A13EmployeeFirstName = new string[] {""} ;
         lV11Code = "";
         lV15Name = "";
         H002B6_A1BrandId = new int[1] ;
         H002B6_A4SupplierId = new int[1] ;
         H002B6_A17ProductStock = new int[1] ;
         H002B6_A18ProductPrice = new decimal[1] ;
         H002B6_A16ProductName = new string[] {""} ;
         H002B6_A55ProductCode = new string[] {""} ;
         H002B6_n55ProductCode = new bool[] {false} ;
         H002B6_A15ProductId = new int[1] ;
         H002B7_AALLPRODUCTS_nRecordCount = new long[1] ;
         AV13Invoice = new SdtInvoice(context);
         AV14InvoiceDetail = new SdtInvoice_Detail(context);
         AV18Product = new SdtProduct(context);
         AllproductsRow = new GXWebRow();
         CarproductsRow = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subAllproducts_Linesclass = "";
         ROClassString = "";
         subCarproducts_Linesclass = "";
         bttRemove_Jsonclick = "";
         H002B8_A12EmployeeId = new int[1] ;
         H002B8_A13EmployeeFirstName = new string[] {""} ;
         AllproductsColumn = new GXWebColumn();
         subCarproducts_Header = "";
         CarproductsColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpregisterdiscardedproduct__default(),
            new Object[][] {
                new Object[] {
               H002B2_A12EmployeeId, H002B2_A13EmployeeFirstName
               }
               , new Object[] {
               H002B3_A4SupplierId, H002B3_A5SupplierName
               }
               , new Object[] {
               H002B4_A1BrandId, H002B4_A2BrandName
               }
               , new Object[] {
               H002B5_A12EmployeeId, H002B5_A13EmployeeFirstName
               }
               , new Object[] {
               H002B6_A1BrandId, H002B6_A4SupplierId, H002B6_A17ProductStock, H002B6_A18ProductPrice, H002B6_A16ProductName, H002B6_A55ProductCode, H002B6_n55ProductCode, H002B6_A15ProductId
               }
               , new Object[] {
               H002B7_AALLPRODUCTS_nRecordCount
               }
               , new Object[] {
               H002B8_A12EmployeeId, H002B8_A13EmployeeFirstName
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavTotal_Enabled = 0;
         edtavCtlname1_Enabled = 0;
         edtavCtlunitprice1_Enabled = 0;
         edtavCtlstock_Enabled = 0;
         edtavCtlsubtotal_Enabled = 0;
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short ALLPRODUCTS_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV16NewQty ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subAllproducts_Backcolorstyle ;
      private short subCarproducts_Backcolorstyle ;
      private short CARPRODUCTS_nEOF ;
      private short nGXWrapped ;
      private short subAllproducts_Backstyle ;
      private short subCarproducts_Backstyle ;
      private short subAllproducts_Titlebackstyle ;
      private short subAllproducts_Allowselection ;
      private short subAllproducts_Allowhovering ;
      private short subAllproducts_Allowcollapsing ;
      private short subAllproducts_Collapsed ;
      private short subCarproducts_Allowselection ;
      private short subCarproducts_Allowhovering ;
      private short subCarproducts_Allowcollapsing ;
      private short subCarproducts_Collapsed ;
      private int nRC_GXsfl_32 ;
      private int nRC_GXsfl_55 ;
      private int subAllproducts_Rows ;
      private int nGXsfl_32_idx=1 ;
      private int AV21Supplier ;
      private int AV7Brand ;
      private int AV12Employee ;
      private int nGXsfl_55_idx=1 ;
      private int edtavCode_Enabled ;
      private int edtavName_Enabled ;
      private int edtavTotal_Enabled ;
      private int AV26GXV1 ;
      private int A15ProductId ;
      private int A17ProductStock ;
      private int gxdynajaxindex ;
      private int subAllproducts_Islastpage ;
      private int subCarproducts_Islastpage ;
      private int edtavCtlname1_Enabled ;
      private int edtavCtlunitprice1_Enabled ;
      private int edtavCtlstock_Enabled ;
      private int edtavCtlsubtotal_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A4SupplierId ;
      private int A1BrandId ;
      private int nGXsfl_55_fel_idx=1 ;
      private int AV32GXV7 ;
      private int nGXsfl_55_bak_idx=1 ;
      private int AV33GXV8 ;
      private int AV34GXV9 ;
      private int AV17Position ;
      private int AV35GXV10 ;
      private int idxLst ;
      private int subAllproducts_Backcolor ;
      private int subAllproducts_Allbackcolor ;
      private int subCarproducts_Backcolor ;
      private int subCarproducts_Allbackcolor ;
      private int edtavCtlquantity1_Enabled ;
      private int edtavCtlquantity1_Visible ;
      private int subAllproducts_Titlebackcolor ;
      private int subAllproducts_Selectedindex ;
      private int subAllproducts_Selectioncolor ;
      private int subAllproducts_Hoveringcolor ;
      private int subCarproducts_Selectedindex ;
      private int subCarproducts_Selectioncolor ;
      private int subCarproducts_Hoveringcolor ;
      private long ALLPRODUCTS_nFirstRecordOnPage ;
      private long ALLPRODUCTS_nCurrentRecord ;
      private long CARPRODUCTS_nCurrentRecord ;
      private long ALLPRODUCTS_nRecordCount ;
      private long CARPRODUCTS_nFirstRecordOnPage ;
      private decimal AV22Total ;
      private decimal A18ProductPrice ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_32_idx="0001" ;
      private string sGXsfl_55_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divTable1_Internalname ;
      private string dynavEmployee_Internalname ;
      private string TempTags ;
      private string dynavEmployee_Jsonclick ;
      private string edtavCode_Internalname ;
      private string edtavCode_Jsonclick ;
      private string edtavName_Internalname ;
      private string edtavName_Jsonclick ;
      private string dynavSupplier_Internalname ;
      private string dynavSupplier_Jsonclick ;
      private string dynavBrand_Internalname ;
      private string dynavBrand_Jsonclick ;
      private string sStyleString ;
      private string subAllproducts_Internalname ;
      private string divTable2_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string bttRegistersale_Internalname ;
      private string bttRegistersale_Jsonclick ;
      private string bttClearsale_Internalname ;
      private string bttClearsale_Jsonclick ;
      private string edtavTotal_Internalname ;
      private string edtavTotal_Jsonclick ;
      private string subCarproducts_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtProductId_Internalname ;
      private string edtProductCode_Internalname ;
      private string edtProductName_Internalname ;
      private string edtProductPrice_Internalname ;
      private string edtProductStock_Internalname ;
      private string gxwrpcisep ;
      private string scmdbuf ;
      private string edtavCtlname1_Internalname ;
      private string edtavCtlunitprice1_Internalname ;
      private string edtavCtlstock_Internalname ;
      private string edtavCtlsubtotal_Internalname ;
      private string sGXsfl_55_fel_idx="0001" ;
      private string sGXsfl_32_fel_idx="0001" ;
      private string subAllproducts_Class ;
      private string subAllproducts_Linesclass ;
      private string ROClassString ;
      private string edtProductId_Jsonclick ;
      private string edtProductCode_Jsonclick ;
      private string edtProductName_Jsonclick ;
      private string edtProductPrice_Jsonclick ;
      private string edtProductStock_Jsonclick ;
      private string edtavCtlquantity1_Internalname ;
      private string subCarproducts_Class ;
      private string subCarproducts_Linesclass ;
      private string divGrid1table_Internalname ;
      private string bttRemove_Internalname ;
      private string bttRemove_Jsonclick ;
      private string edtavCtlname1_Jsonclick ;
      private string edtavCtlunitprice1_Jsonclick ;
      private string edtavCtlstock_Jsonclick ;
      private string edtavCtlquantity1_Jsonclick ;
      private string edtavCtlsubtotal_Jsonclick ;
      private string subAllproducts_Header ;
      private string subCarproducts_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n55ProductCode ;
      private bool gxdyncontrolsrefreshing ;
      private bool bGXsfl_55_Refreshing=false ;
      private bool bGXsfl_32_Refreshing=false ;
      private bool returnInSub ;
      private bool gx_BV55 ;
      private bool AV19QuantitiesValid ;
      private string AV11Code ;
      private string AV15Name ;
      private string AV6newName ;
      private string AV5newCode ;
      private string A55ProductCode ;
      private string A16ProductName ;
      private string lV11Code ;
      private string lV15Name ;
      private GxSimpleCollection<int> AV20SelectedId ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid AllproductsContainer ;
      private GXWebGrid CarproductsContainer ;
      private GXWebRow AllproductsRow ;
      private GXWebRow CarproductsRow ;
      private GXWebColumn AllproductsColumn ;
      private GXWebColumn CarproductsColumn ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavEmployee ;
      private GXCombobox dynavSupplier ;
      private GXCombobox dynavBrand ;
      private IDataStoreProvider pr_default ;
      private int[] H002B2_A12EmployeeId ;
      private string[] H002B2_A13EmployeeFirstName ;
      private int[] H002B3_A4SupplierId ;
      private string[] H002B3_A5SupplierName ;
      private int[] H002B4_A1BrandId ;
      private string[] H002B4_A2BrandName ;
      private int[] H002B5_A12EmployeeId ;
      private string[] H002B5_A13EmployeeFirstName ;
      private int[] H002B6_A1BrandId ;
      private int[] H002B6_A4SupplierId ;
      private int[] H002B6_A17ProductStock ;
      private decimal[] H002B6_A18ProductPrice ;
      private string[] H002B6_A16ProductName ;
      private string[] H002B6_A55ProductCode ;
      private bool[] H002B6_n55ProductCode ;
      private int[] H002B6_A15ProductId ;
      private long[] H002B7_AALLPRODUCTS_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private int[] H002B8_A12EmployeeId ;
      private string[] H002B8_A13EmployeeFirstName ;
      private GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem> AV8Car ;
      private GXBaseCollection<SdtSDTCarProducts_SDTCarProductsItem> AV9CarAux ;
      private GXWebForm Form ;
      private SdtSDTCarProducts_SDTCarProductsItem AV10CarItem ;
      private SdtInvoice AV13Invoice ;
      private SdtInvoice_Detail AV14InvoiceDetail ;
      private SdtProduct AV18Product ;
   }

   public class wpregisterdiscardedproduct__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H002B6( IGxContext context ,
                                             string AV11Code ,
                                             string AV15Name ,
                                             int AV21Supplier ,
                                             int AV7Brand ,
                                             string A55ProductCode ,
                                             string A16ProductName ,
                                             int A4SupplierId ,
                                             int A1BrandId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[7];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [BrandId], [SupplierId], [ProductStock], [ProductPrice], [ProductName], [ProductCode], [ProductId]";
         sFromString = " FROM [Product]";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11Code)) )
         {
            AddWhere(sWhereString, "([ProductCode] like @lV11Code)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15Name)) )
         {
            AddWhere(sWhereString, "([ProductName] like @lV15Name)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV21Supplier) )
         {
            AddWhere(sWhereString, "([SupplierId] = @AV21Supplier)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV7Brand) )
         {
            AddWhere(sWhereString, "([BrandId] = @AV7Brand)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         sOrderString += " ORDER BY [ProductName]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H002B7( IGxContext context ,
                                             string AV11Code ,
                                             string AV15Name ,
                                             int AV21Supplier ,
                                             int AV7Brand ,
                                             string A55ProductCode ,
                                             string A16ProductName ,
                                             int A4SupplierId ,
                                             int A1BrandId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[4];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [Product]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11Code)) )
         {
            AddWhere(sWhereString, "([ProductCode] like @lV11Code)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15Name)) )
         {
            AddWhere(sWhereString, "([ProductName] like @lV15Name)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (0==AV21Supplier) )
         {
            AddWhere(sWhereString, "([SupplierId] = @AV21Supplier)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV7Brand) )
         {
            AddWhere(sWhereString, "([BrandId] = @AV7Brand)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         scmdbuf += sWhereString;
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 4 :
                     return conditional_H002B6(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] );
               case 5 :
                     return conditional_H002B7(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH002B2;
          prmH002B2 = new Object[] {
          };
          Object[] prmH002B3;
          prmH002B3 = new Object[] {
          };
          Object[] prmH002B4;
          prmH002B4 = new Object[] {
          };
          Object[] prmH002B5;
          prmH002B5 = new Object[] {
          };
          Object[] prmH002B8;
          prmH002B8 = new Object[] {
          };
          Object[] prmH002B6;
          prmH002B6 = new Object[] {
          new ParDef("@lV11Code",GXType.NVarChar,100,0) ,
          new ParDef("@lV15Name",GXType.NVarChar,60,0) ,
          new ParDef("@AV21Supplier",GXType.Int32,6,0) ,
          new ParDef("@AV7Brand",GXType.Int32,6,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH002B7;
          prmH002B7 = new Object[] {
          new ParDef("@lV11Code",GXType.NVarChar,100,0) ,
          new ParDef("@lV15Name",GXType.NVarChar,60,0) ,
          new ParDef("@AV21Supplier",GXType.Int32,6,0) ,
          new ParDef("@AV7Brand",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002B2", "SELECT [EmployeeId], [EmployeeFirstName] FROM [Employee] ORDER BY [EmployeeFirstName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002B2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002B3", "SELECT [SupplierId], [SupplierName] FROM [Supplier] ORDER BY [SupplierName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002B3,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002B4", "SELECT [BrandId], [BrandName] FROM [Brand] ORDER BY [BrandName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002B4,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002B5", "SELECT [EmployeeId], [EmployeeFirstName] FROM [Employee] ORDER BY [EmployeeFirstName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002B5,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002B6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002B6,6, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002B7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002B7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002B8", "SELECT [EmployeeId], [EmployeeFirstName] FROM [Employee] ORDER BY [EmployeeFirstName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002B8,0, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                return;
             case 5 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
