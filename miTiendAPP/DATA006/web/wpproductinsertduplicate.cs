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
   public class wpproductinsertduplicate : GXDataArea
   {
      public wpproductinsertduplicate( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public wpproductinsertduplicate( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_ReturnObject )
      {
         this.AV21ReturnObject = aP0_ReturnObject;
         executePrivate();
         aP0_ReturnObject=this.AV21ReturnObject;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynavSupplierid = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "ReturnObject");
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vSUPPLIERID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvSUPPLIERID3T2( ) ;
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
               gxfirstwebparm = GetFirstPar( "ReturnObject");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "ReturnObject");
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
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV21ReturnObject = gxfirstwebparm;
               AssignAttri("", false, "AV21ReturnObject", AV21ReturnObject);
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
         PA3T2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3T2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpproductinsertduplicate.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV21ReturnObject))}, new string[] {"ReturnObject"}) +"\">") ;
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
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vPRODUCTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18ProductId), 6, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vALLOK", AV20AllOk);
         GxWebStd.gx_hidden_field( context, "vRETURNOBJECT", AV21ReturnObject);
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
            WE3T2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3T2( ) ;
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
         return formatLink("wpproductinsertduplicate.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV21ReturnObject))}, new string[] {"ReturnObject"})  ;
      }

      public override string GetPgmname( )
      {
         return "WPProductInsertDuplicate" ;
      }

      public override string GetPgmdesc( )
      {
         return "WPProduct Insert Duplicate" ;
      }

      protected void WB3T0( )
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
            GxWebStd.gx_div_start( context, divAttributestable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavProductcode_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProductcode_Internalname, "Code", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProductcode_Internalname, AV6ProductCode, StringUtil.RTrim( context.localUtil.Format( AV6ProductCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,14);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProductcode_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavProductcode_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_WPProductInsertDuplicate.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProductName_Internalname, "Name", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtProductName_Internalname, A16ProductName, StringUtil.RTrim( context.localUtil.Format( A16ProductName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductName_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtProductName_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Name", "left", true, "", "HLP_WPProductInsertDuplicate.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavProductcostprice_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProductcostprice_Internalname, "Cost Price", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProductcostprice_Internalname, StringUtil.LTrim( StringUtil.NToC( AV8ProductCostPrice, 18, 2, ".", "")), StringUtil.LTrim( ((edtavProductcostprice_Enabled!=0) ? context.localUtil.Format( AV8ProductCostPrice, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV8ProductCostPrice, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,24);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProductcostprice_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavProductcostprice_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_WPProductInsertDuplicate.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavProductretailprofit_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProductretailprofit_Internalname, "Retail Profit", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProductretailprofit_Internalname, StringUtil.LTrim( StringUtil.NToC( AV9ProductRetailProfit, 8, 2, ".", "")), StringUtil.LTrim( ((edtavProductretailprofit_Enabled!=0) ? context.localUtil.Format( AV9ProductRetailProfit, "ZZZZ9.99") : context.localUtil.Format( AV9ProductRetailProfit, "ZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,29);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProductretailprofit_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavProductretailprofit_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_WPProductInsertDuplicate.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavProductretailprice_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProductretailprice_Internalname, "Retail Price", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProductretailprice_Internalname, StringUtil.LTrim( StringUtil.NToC( AV10ProductRetailPrice, 18, 2, ".", "")), StringUtil.LTrim( ((edtavProductretailprice_Enabled!=0) ? context.localUtil.Format( AV10ProductRetailPrice, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV10ProductRetailPrice, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProductretailprice_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtavProductretailprice_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_WPProductInsertDuplicate.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavProductwholesaleprofit_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProductwholesaleprofit_Internalname, "Wholesale Profit", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProductwholesaleprofit_Internalname, StringUtil.LTrim( StringUtil.NToC( AV11ProductWholesaleProfit, 8, 2, ".", "")), StringUtil.LTrim( ((edtavProductwholesaleprofit_Enabled!=0) ? context.localUtil.Format( AV11ProductWholesaleProfit, "ZZZZ9.99") : context.localUtil.Format( AV11ProductWholesaleProfit, "ZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProductwholesaleprofit_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavProductwholesaleprofit_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_WPProductInsertDuplicate.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavProductwholesaleprice_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProductwholesaleprice_Internalname, "Wholesale Price", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProductwholesaleprice_Internalname, StringUtil.LTrim( StringUtil.NToC( AV12ProductWholesalePrice, 18, 2, ".", "")), StringUtil.LTrim( ((edtavProductwholesaleprice_Enabled!=0) ? context.localUtil.Format( AV12ProductWholesalePrice, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( AV12ProductWholesalePrice, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProductwholesaleprice_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtavProductwholesaleprice_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_WPProductInsertDuplicate.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavProductminiumquantitywholesale_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProductminiumquantitywholesale_Internalname, "Quantity Wholesale", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProductminiumquantitywholesale_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13ProductMiniumQuantityWholesale), 4, 0, ".", "")), StringUtil.LTrim( ((edtavProductminiumquantitywholesale_Enabled!=0) ? context.localUtil.Format( (decimal)(AV13ProductMiniumQuantityWholesale), "ZZZ9") : context.localUtil.Format( (decimal)(AV13ProductMiniumQuantityWholesale), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProductminiumquantitywholesale_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavProductminiumquantitywholesale_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_WPProductInsertDuplicate.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtBrandName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtBrandName_Internalname, "Brand", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtBrandName_Internalname, A2BrandName, StringUtil.RTrim( context.localUtil.Format( A2BrandName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBrandName_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtBrandName_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Name", "left", true, "", "HLP_WPProductInsertDuplicate.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavSupplierid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavSupplierid_Internalname, "Supplier", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavSupplierid, dynavSupplierid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV14SupplierId), 6, 0)), 1, dynavSupplierid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavSupplierid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "", true, 0, "HLP_WPProductInsertDuplicate.htm");
            dynavSupplierid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV14SupplierId), 6, 0));
            AssignProp("", false, dynavSupplierid_Internalname, "Values", (string)(dynavSupplierid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSectorName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtSectorName_Internalname, "Sector", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtSectorName_Internalname, A10SectorName, StringUtil.RTrim( context.localUtil.Format( A10SectorName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSectorName_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtSectorName_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Name", "left", true, "", "HLP_WPProductInsertDuplicate.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavProductstock_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProductstock_Internalname, "Stock", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProductstock_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16ProductStock), 6, 0, ".", "")), StringUtil.LTrim( ((edtavProductstock_Enabled!=0) ? context.localUtil.Format( (decimal)(AV16ProductStock), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV16ProductStock), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProductstock_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtavProductstock_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_WPProductInsertDuplicate.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavProductminiumstock_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavProductminiumstock_Internalname, "Minium Stock", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavProductminiumstock_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17ProductMiniumStock), 6, 0, ".", "")), StringUtil.LTrim( ((edtavProductminiumstock_Enabled!=0) ? context.localUtil.Format( (decimal)(AV17ProductMiniumStock), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV17ProductMiniumStock), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavProductminiumstock_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavProductminiumstock_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_WPProductInsertDuplicate.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductDescription_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProductDescription_Internalname, "Description", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtProductDescription_Internalname, A19ProductDescription, "", "", 0, 1, edtProductDescription_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "GeneXusUnanimo\\Description", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WPProductInsertDuplicate.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START3T2( )
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
            Form.Meta.addItem("description", "WPProduct Insert Duplicate", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3T0( ) ;
      }

      protected void WS3T2( )
      {
         START3T2( ) ;
         EVT3T2( ) ;
      }

      protected void EVT3T2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E113T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CONFIRM'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Confirm' */
                              E123T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VPRODUCTCODE.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E133T2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E143T2 ();
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
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE3T2( )
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

      protected void PA3T2( )
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
               GX_FocusControl = edtavProductcode_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVvSUPPLIERID3T2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvSUPPLIERID_data3T2( ) ;
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

      protected void GXVvSUPPLIERID_html3T2( )
      {
         int gxdynajaxvalue;
         GXDLVvSUPPLIERID_data3T2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavSupplierid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynavSupplierid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 6, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvSUPPLIERID_data3T2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(None)");
         /* Using cursor H003T2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H003T2_A4SupplierId[0]), 6, 0, ".", "")));
            gxdynajaxctrldescr.Add(H003T2_A5SupplierName[0]);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXVvSUPPLIERID_html3T2( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavSupplierid.ItemCount > 0 )
         {
            AV14SupplierId = (int)(Math.Round(NumberUtil.Val( dynavSupplierid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV14SupplierId), 6, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV14SupplierId", StringUtil.LTrimStr( (decimal)(AV14SupplierId), 6, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavSupplierid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV14SupplierId), 6, 0));
            AssignProp("", false, dynavSupplierid_Internalname, "Values", dynavSupplierid.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF3T2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavProductretailprice_Enabled = 0;
         AssignProp("", false, edtavProductretailprice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavProductretailprice_Enabled), 5, 0), true);
         edtavProductwholesaleprice_Enabled = 0;
         AssignProp("", false, edtavProductwholesaleprice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavProductwholesaleprice_Enabled), 5, 0), true);
      }

      protected void RF3T2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H003T3 */
            pr_default.execute(1, new Object[] {AV18ProductId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A1BrandId = H003T3_A1BrandId[0];
               n1BrandId = H003T3_n1BrandId[0];
               A9SectorId = H003T3_A9SectorId[0];
               n9SectorId = H003T3_n9SectorId[0];
               A15ProductId = H003T3_A15ProductId[0];
               A19ProductDescription = H003T3_A19ProductDescription[0];
               n19ProductDescription = H003T3_n19ProductDescription[0];
               AssignAttri("", false, "A19ProductDescription", A19ProductDescription);
               A10SectorName = H003T3_A10SectorName[0];
               AssignAttri("", false, "A10SectorName", A10SectorName);
               A2BrandName = H003T3_A2BrandName[0];
               AssignAttri("", false, "A2BrandName", A2BrandName);
               A16ProductName = H003T3_A16ProductName[0];
               AssignAttri("", false, "A16ProductName", A16ProductName);
               A2BrandName = H003T3_A2BrandName[0];
               AssignAttri("", false, "A2BrandName", A2BrandName);
               A10SectorName = H003T3_A10SectorName[0];
               AssignAttri("", false, "A10SectorName", A10SectorName);
               GXVvSUPPLIERID_html3T2( ) ;
               /* Execute user event: Load */
               E143T2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            WB3T0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes3T2( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavProductretailprice_Enabled = 0;
         AssignProp("", false, edtavProductretailprice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavProductretailprice_Enabled), 5, 0), true);
         edtavProductwholesaleprice_Enabled = 0;
         AssignProp("", false, edtavProductwholesaleprice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavProductwholesaleprice_Enabled), 5, 0), true);
         GXVvSUPPLIERID_html3T2( ) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3T0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E113T2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            AV6ProductCode = cgiGet( edtavProductcode_Internalname);
            AssignAttri("", false, "AV6ProductCode", AV6ProductCode);
            A16ProductName = cgiGet( edtProductName_Internalname);
            AssignAttri("", false, "A16ProductName", A16ProductName);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavProductcostprice_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavProductcostprice_Internalname), ".", ",") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPRODUCTCOSTPRICE");
               GX_FocusControl = edtavProductcostprice_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8ProductCostPrice = 0;
               AssignAttri("", false, "AV8ProductCostPrice", StringUtil.LTrimStr( AV8ProductCostPrice, 18, 2));
            }
            else
            {
               AV8ProductCostPrice = context.localUtil.CToN( cgiGet( edtavProductcostprice_Internalname), ".", ",");
               AssignAttri("", false, "AV8ProductCostPrice", StringUtil.LTrimStr( AV8ProductCostPrice, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavProductretailprofit_Internalname), ".", ",") < -9999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavProductretailprofit_Internalname), ".", ",") > 99999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPRODUCTRETAILPROFIT");
               GX_FocusControl = edtavProductretailprofit_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9ProductRetailProfit = 0;
               AssignAttri("", false, "AV9ProductRetailProfit", StringUtil.LTrimStr( AV9ProductRetailProfit, 8, 2));
            }
            else
            {
               AV9ProductRetailProfit = context.localUtil.CToN( cgiGet( edtavProductretailprofit_Internalname), ".", ",");
               AssignAttri("", false, "AV9ProductRetailProfit", StringUtil.LTrimStr( AV9ProductRetailProfit, 8, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavProductretailprice_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavProductretailprice_Internalname), ".", ",") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPRODUCTRETAILPRICE");
               GX_FocusControl = edtavProductretailprice_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10ProductRetailPrice = 0;
               AssignAttri("", false, "AV10ProductRetailPrice", StringUtil.LTrimStr( AV10ProductRetailPrice, 18, 2));
            }
            else
            {
               AV10ProductRetailPrice = context.localUtil.CToN( cgiGet( edtavProductretailprice_Internalname), ".", ",");
               AssignAttri("", false, "AV10ProductRetailPrice", StringUtil.LTrimStr( AV10ProductRetailPrice, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavProductwholesaleprofit_Internalname), ".", ",") < -9999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtavProductwholesaleprofit_Internalname), ".", ",") > 99999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPRODUCTWHOLESALEPROFIT");
               GX_FocusControl = edtavProductwholesaleprofit_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11ProductWholesaleProfit = 0;
               AssignAttri("", false, "AV11ProductWholesaleProfit", StringUtil.LTrimStr( AV11ProductWholesaleProfit, 8, 2));
            }
            else
            {
               AV11ProductWholesaleProfit = context.localUtil.CToN( cgiGet( edtavProductwholesaleprofit_Internalname), ".", ",");
               AssignAttri("", false, "AV11ProductWholesaleProfit", StringUtil.LTrimStr( AV11ProductWholesaleProfit, 8, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavProductwholesaleprice_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavProductwholesaleprice_Internalname), ".", ",") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPRODUCTWHOLESALEPRICE");
               GX_FocusControl = edtavProductwholesaleprice_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12ProductWholesalePrice = 0;
               AssignAttri("", false, "AV12ProductWholesalePrice", StringUtil.LTrimStr( AV12ProductWholesalePrice, 18, 2));
            }
            else
            {
               AV12ProductWholesalePrice = context.localUtil.CToN( cgiGet( edtavProductwholesaleprice_Internalname), ".", ",");
               AssignAttri("", false, "AV12ProductWholesalePrice", StringUtil.LTrimStr( AV12ProductWholesalePrice, 18, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavProductminiumquantitywholesale_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavProductminiumquantitywholesale_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPRODUCTMINIUMQUANTITYWHOLESALE");
               GX_FocusControl = edtavProductminiumquantitywholesale_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV13ProductMiniumQuantityWholesale = 0;
               AssignAttri("", false, "AV13ProductMiniumQuantityWholesale", StringUtil.LTrimStr( (decimal)(AV13ProductMiniumQuantityWholesale), 4, 0));
            }
            else
            {
               AV13ProductMiniumQuantityWholesale = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavProductminiumquantitywholesale_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV13ProductMiniumQuantityWholesale", StringUtil.LTrimStr( (decimal)(AV13ProductMiniumQuantityWholesale), 4, 0));
            }
            A2BrandName = cgiGet( edtBrandName_Internalname);
            AssignAttri("", false, "A2BrandName", A2BrandName);
            dynavSupplierid.CurrentValue = cgiGet( dynavSupplierid_Internalname);
            AV14SupplierId = (int)(Math.Round(NumberUtil.Val( cgiGet( dynavSupplierid_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV14SupplierId", StringUtil.LTrimStr( (decimal)(AV14SupplierId), 6, 0));
            A10SectorName = cgiGet( edtSectorName_Internalname);
            AssignAttri("", false, "A10SectorName", A10SectorName);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavProductstock_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavProductstock_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPRODUCTSTOCK");
               GX_FocusControl = edtavProductstock_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV16ProductStock = 0;
               AssignAttri("", false, "AV16ProductStock", StringUtil.LTrimStr( (decimal)(AV16ProductStock), 6, 0));
            }
            else
            {
               AV16ProductStock = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavProductstock_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV16ProductStock", StringUtil.LTrimStr( (decimal)(AV16ProductStock), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavProductminiumstock_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavProductminiumstock_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPRODUCTMINIUMSTOCK");
               GX_FocusControl = edtavProductminiumstock_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV17ProductMiniumStock = 0;
               AssignAttri("", false, "AV17ProductMiniumStock", StringUtil.LTrimStr( (decimal)(AV17ProductMiniumStock), 6, 0));
            }
            else
            {
               AV17ProductMiniumStock = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavProductminiumstock_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV17ProductMiniumStock", StringUtil.LTrimStr( (decimal)(AV17ProductMiniumStock), 6, 0));
            }
            A19ProductDescription = cgiGet( edtProductDescription_Internalname);
            n19ProductDescription = false;
            AssignAttri("", false, "A19ProductDescription", A19ProductDescription);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXVvSUPPLIERID_html3T2( ) ;
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E113T2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E113T2( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E123T2( )
      {
         /* 'Confirm' Routine */
         returnInSub = false;
         if ( ! (0==AV18ProductId) )
         {
            new productinsertduplicate(context ).execute(  AV18ProductId, ref  AV16ProductStock, ref  AV14SupplierId, ref  AV8ProductCostPrice, ref  AV9ProductRetailProfit, ref  AV11ProductWholesaleProfit, out  AV19ErrorMessages, ref  AV20AllOk) ;
            AssignAttri("", false, "AV16ProductStock", StringUtil.LTrimStr( (decimal)(AV16ProductStock), 6, 0));
            AssignAttri("", false, "AV14SupplierId", StringUtil.LTrimStr( (decimal)(AV14SupplierId), 6, 0));
            AssignAttri("", false, "AV8ProductCostPrice", StringUtil.LTrimStr( AV8ProductCostPrice, 18, 2));
            AssignAttri("", false, "AV9ProductRetailProfit", StringUtil.LTrimStr( AV9ProductRetailProfit, 8, 2));
            AssignAttri("", false, "AV11ProductWholesaleProfit", StringUtil.LTrimStr( AV11ProductWholesaleProfit, 8, 2));
            AssignAttri("", false, "AV20AllOk", AV20AllOk);
            if ( ! AV20AllOk )
            {
               GX_msglist.addItem("Insert Product Duplicate Failed: "+AV19ErrorMessages.ToJSonString(false));
            }
            else
            {
               CallWebObject(formatLink("wwproduct.aspx") );
               context.wjLocDisableFrm = 1;
            }
         }
         /*  Sending Event outputs  */
         dynavSupplierid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV14SupplierId), 6, 0));
         AssignProp("", false, dynavSupplierid_Internalname, "Values", dynavSupplierid.ToJavascriptSource(), true);
      }

      protected void E133T2( )
      {
         /* Productcode_Controlvaluechanged Routine */
         returnInSub = false;
         GXt_int1 = AV18ProductId;
         new productsearchwithcode(context ).execute(  AV6ProductCode, out  GXt_int1) ;
         AV18ProductId = GXt_int1;
         AssignAttri("", false, "AV18ProductId", StringUtil.LTrimStr( (decimal)(AV18ProductId), 6, 0));
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
      }

      protected void nextLoad( )
      {
      }

      protected void E143T2( )
      {
         /* Load Routine */
         returnInSub = false;
         if ( ! (0==AV18ProductId) )
         {
            AV8ProductCostPrice = 0;
            AssignAttri("", false, "AV8ProductCostPrice", StringUtil.LTrimStr( AV8ProductCostPrice, 18, 2));
            AV13ProductMiniumQuantityWholesale = 0;
            AssignAttri("", false, "AV13ProductMiniumQuantityWholesale", StringUtil.LTrimStr( (decimal)(AV13ProductMiniumQuantityWholesale), 4, 0));
            AV17ProductMiniumStock = 0;
            AssignAttri("", false, "AV17ProductMiniumStock", StringUtil.LTrimStr( (decimal)(AV17ProductMiniumStock), 6, 0));
            AV14SupplierId = 0;
            AssignAttri("", false, "AV14SupplierId", StringUtil.LTrimStr( (decimal)(AV14SupplierId), 6, 0));
            AV16ProductStock = 0;
            AssignAttri("", false, "AV16ProductStock", StringUtil.LTrimStr( (decimal)(AV16ProductStock), 6, 0));
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV21ReturnObject = (string)getParm(obj,0);
         AssignAttri("", false, "AV21ReturnObject", AV21ReturnObject);
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
         PA3T2( ) ;
         WS3T2( ) ;
         WE3T2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202411152134272", true, true);
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
         context.AddJavascriptSource("wpproductinsertduplicate.js", "?202411152134272", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         dynavSupplierid.Name = "vSUPPLIERID";
         dynavSupplierid.WebTags = "";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavProductcode_Internalname = "vPRODUCTCODE";
         edtProductName_Internalname = "PRODUCTNAME";
         edtavProductcostprice_Internalname = "vPRODUCTCOSTPRICE";
         edtavProductretailprofit_Internalname = "vPRODUCTRETAILPROFIT";
         edtavProductretailprice_Internalname = "vPRODUCTRETAILPRICE";
         edtavProductwholesaleprofit_Internalname = "vPRODUCTWHOLESALEPROFIT";
         edtavProductwholesaleprice_Internalname = "vPRODUCTWHOLESALEPRICE";
         edtavProductminiumquantitywholesale_Internalname = "vPRODUCTMINIUMQUANTITYWHOLESALE";
         edtBrandName_Internalname = "BRANDNAME";
         dynavSupplierid_Internalname = "vSUPPLIERID";
         edtSectorName_Internalname = "SECTORNAME";
         edtavProductstock_Internalname = "vPRODUCTSTOCK";
         edtavProductminiumstock_Internalname = "vPRODUCTMINIUMSTOCK";
         edtProductDescription_Internalname = "PRODUCTDESCRIPTION";
         divAttributestable_Internalname = "ATTRIBUTESTABLE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("mtaKB", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtProductDescription_Enabled = 0;
         edtavProductminiumstock_Jsonclick = "";
         edtavProductminiumstock_Enabled = 1;
         edtavProductstock_Jsonclick = "";
         edtavProductstock_Enabled = 1;
         edtSectorName_Jsonclick = "";
         edtSectorName_Enabled = 0;
         dynavSupplierid_Jsonclick = "";
         dynavSupplierid.Enabled = 1;
         edtBrandName_Jsonclick = "";
         edtBrandName_Enabled = 0;
         edtavProductminiumquantitywholesale_Jsonclick = "";
         edtavProductminiumquantitywholesale_Enabled = 1;
         edtavProductwholesaleprice_Jsonclick = "";
         edtavProductwholesaleprice_Enabled = 1;
         edtavProductwholesaleprofit_Jsonclick = "";
         edtavProductwholesaleprofit_Enabled = 1;
         edtavProductretailprice_Jsonclick = "";
         edtavProductretailprice_Enabled = 1;
         edtavProductretailprofit_Jsonclick = "";
         edtavProductretailprofit_Enabled = 1;
         edtavProductcostprice_Jsonclick = "";
         edtavProductcostprice_Enabled = 1;
         edtProductName_Jsonclick = "";
         edtProductName_Enabled = 0;
         edtavProductcode_Jsonclick = "";
         edtavProductcode_Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "WPProduct Insert Duplicate";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'dynavSupplierid'},{av:'AV14SupplierId',fld:'vSUPPLIERID',pic:'ZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'CONFIRM'","{handler:'E123T2',iparms:[{av:'AV18ProductId',fld:'vPRODUCTID',pic:'ZZZZZ9'},{av:'AV16ProductStock',fld:'vPRODUCTSTOCK',pic:'ZZZZZ9'},{av:'dynavSupplierid'},{av:'AV14SupplierId',fld:'vSUPPLIERID',pic:'ZZZZZ9'},{av:'AV8ProductCostPrice',fld:'vPRODUCTCOSTPRICE',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'AV9ProductRetailProfit',fld:'vPRODUCTRETAILPROFIT',pic:'ZZZZ9.99'},{av:'AV11ProductWholesaleProfit',fld:'vPRODUCTWHOLESALEPROFIT',pic:'ZZZZ9.99'},{av:'AV20AllOk',fld:'vALLOK',pic:''}]");
         setEventMetadata("'CONFIRM'",",oparms:[{av:'AV20AllOk',fld:'vALLOK',pic:''},{av:'AV11ProductWholesaleProfit',fld:'vPRODUCTWHOLESALEPROFIT',pic:'ZZZZ9.99'},{av:'AV9ProductRetailProfit',fld:'vPRODUCTRETAILPROFIT',pic:'ZZZZ9.99'},{av:'AV8ProductCostPrice',fld:'vPRODUCTCOSTPRICE',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'dynavSupplierid'},{av:'AV14SupplierId',fld:'vSUPPLIERID',pic:'ZZZZZ9'},{av:'AV16ProductStock',fld:'vPRODUCTSTOCK',pic:'ZZZZZ9'}]}");
         setEventMetadata("VPRODUCTCODE.CONTROLVALUECHANGED","{handler:'E133T2',iparms:[{av:'AV6ProductCode',fld:'vPRODUCTCODE',pic:''}]");
         setEventMetadata("VPRODUCTCODE.CONTROLVALUECHANGED",",oparms:[{av:'AV18ProductId',fld:'vPRODUCTID',pic:'ZZZZZ9'}]}");
         setEventMetadata("VALIDV_PRODUCTCOSTPRICE","{handler:'Validv_Productcostprice',iparms:[]");
         setEventMetadata("VALIDV_PRODUCTCOSTPRICE",",oparms:[]}");
         setEventMetadata("VALIDV_PRODUCTRETAILPROFIT","{handler:'Validv_Productretailprofit',iparms:[]");
         setEventMetadata("VALIDV_PRODUCTRETAILPROFIT",",oparms:[]}");
         setEventMetadata("VALIDV_PRODUCTRETAILPRICE","{handler:'Validv_Productretailprice',iparms:[]");
         setEventMetadata("VALIDV_PRODUCTRETAILPRICE",",oparms:[]}");
         setEventMetadata("VALIDV_PRODUCTWHOLESALEPROFIT","{handler:'Validv_Productwholesaleprofit',iparms:[]");
         setEventMetadata("VALIDV_PRODUCTWHOLESALEPROFIT",",oparms:[]}");
         setEventMetadata("VALIDV_PRODUCTWHOLESALEPRICE","{handler:'Validv_Productwholesaleprice',iparms:[]");
         setEventMetadata("VALIDV_PRODUCTWHOLESALEPRICE",",oparms:[]}");
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
         wcpOAV21ReturnObject = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV6ProductCode = "";
         A16ProductName = "";
         A2BrandName = "";
         A10SectorName = "";
         A19ProductDescription = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         scmdbuf = "";
         H003T2_A4SupplierId = new int[1] ;
         H003T2_A5SupplierName = new string[] {""} ;
         H003T2_A112SupplierActive = new bool[] {false} ;
         H003T3_A1BrandId = new int[1] ;
         H003T3_n1BrandId = new bool[] {false} ;
         H003T3_A9SectorId = new int[1] ;
         H003T3_n9SectorId = new bool[] {false} ;
         H003T3_A15ProductId = new int[1] ;
         H003T3_A19ProductDescription = new string[] {""} ;
         H003T3_n19ProductDescription = new bool[] {false} ;
         H003T3_A10SectorName = new string[] {""} ;
         H003T3_A2BrandName = new string[] {""} ;
         H003T3_A16ProductName = new string[] {""} ;
         AV19ErrorMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpproductinsertduplicate__default(),
            new Object[][] {
                new Object[] {
               H003T2_A4SupplierId, H003T2_A5SupplierName, H003T2_A112SupplierActive
               }
               , new Object[] {
               H003T3_A1BrandId, H003T3_n1BrandId, H003T3_A9SectorId, H003T3_n9SectorId, H003T3_A15ProductId, H003T3_A19ProductDescription, H003T3_n19ProductDescription, H003T3_A10SectorName, H003T3_A2BrandName, H003T3_A16ProductName
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavProductretailprice_Enabled = 0;
         edtavProductwholesaleprice_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV13ProductMiniumQuantityWholesale ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int AV18ProductId ;
      private int edtavProductcode_Enabled ;
      private int edtProductName_Enabled ;
      private int edtavProductcostprice_Enabled ;
      private int edtavProductretailprofit_Enabled ;
      private int edtavProductretailprice_Enabled ;
      private int edtavProductwholesaleprofit_Enabled ;
      private int edtavProductwholesaleprice_Enabled ;
      private int edtavProductminiumquantitywholesale_Enabled ;
      private int edtBrandName_Enabled ;
      private int AV14SupplierId ;
      private int edtSectorName_Enabled ;
      private int AV16ProductStock ;
      private int edtavProductstock_Enabled ;
      private int AV17ProductMiniumStock ;
      private int edtavProductminiumstock_Enabled ;
      private int edtProductDescription_Enabled ;
      private int gxdynajaxindex ;
      private int A1BrandId ;
      private int A9SectorId ;
      private int A15ProductId ;
      private int GXt_int1 ;
      private int idxLst ;
      private decimal AV8ProductCostPrice ;
      private decimal AV9ProductRetailProfit ;
      private decimal AV10ProductRetailPrice ;
      private decimal AV11ProductWholesaleProfit ;
      private decimal AV12ProductWholesalePrice ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divAttributestable_Internalname ;
      private string edtavProductcode_Internalname ;
      private string TempTags ;
      private string edtavProductcode_Jsonclick ;
      private string edtProductName_Internalname ;
      private string edtProductName_Jsonclick ;
      private string edtavProductcostprice_Internalname ;
      private string edtavProductcostprice_Jsonclick ;
      private string edtavProductretailprofit_Internalname ;
      private string edtavProductretailprofit_Jsonclick ;
      private string edtavProductretailprice_Internalname ;
      private string edtavProductretailprice_Jsonclick ;
      private string edtavProductwholesaleprofit_Internalname ;
      private string edtavProductwholesaleprofit_Jsonclick ;
      private string edtavProductwholesaleprice_Internalname ;
      private string edtavProductwholesaleprice_Jsonclick ;
      private string edtavProductminiumquantitywholesale_Internalname ;
      private string edtavProductminiumquantitywholesale_Jsonclick ;
      private string edtBrandName_Internalname ;
      private string edtBrandName_Jsonclick ;
      private string dynavSupplierid_Internalname ;
      private string dynavSupplierid_Jsonclick ;
      private string edtSectorName_Internalname ;
      private string edtSectorName_Jsonclick ;
      private string edtavProductstock_Internalname ;
      private string edtavProductstock_Jsonclick ;
      private string edtavProductminiumstock_Internalname ;
      private string edtavProductminiumstock_Jsonclick ;
      private string edtProductDescription_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string gxwrpcisep ;
      private string scmdbuf ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV20AllOk ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool n1BrandId ;
      private bool n9SectorId ;
      private bool n19ProductDescription ;
      private bool returnInSub ;
      private string AV21ReturnObject ;
      private string wcpOAV21ReturnObject ;
      private string AV6ProductCode ;
      private string A16ProductName ;
      private string A2BrandName ;
      private string A10SectorName ;
      private string A19ProductDescription ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private IGxDataStore dsDefault ;
      private string aP0_ReturnObject ;
      private GXCombobox dynavSupplierid ;
      private IDataStoreProvider pr_default ;
      private int[] H003T2_A4SupplierId ;
      private string[] H003T2_A5SupplierName ;
      private bool[] H003T2_A112SupplierActive ;
      private int[] H003T3_A1BrandId ;
      private bool[] H003T3_n1BrandId ;
      private int[] H003T3_A9SectorId ;
      private bool[] H003T3_n9SectorId ;
      private int[] H003T3_A15ProductId ;
      private string[] H003T3_A19ProductDescription ;
      private bool[] H003T3_n19ProductDescription ;
      private string[] H003T3_A10SectorName ;
      private string[] H003T3_A2BrandName ;
      private string[] H003T3_A16ProductName ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV19ErrorMessages ;
      private GXWebForm Form ;
   }

   public class wpproductinsertduplicate__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH003T2;
          prmH003T2 = new Object[] {
          };
          Object[] prmH003T3;
          prmH003T3 = new Object[] {
          new ParDef("@AV18ProductId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("H003T2", "SELECT [SupplierId], [SupplierName], [SupplierActive] FROM [Supplier] WHERE [SupplierActive] = 1 ORDER BY [SupplierName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003T2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H003T3", "SELECT T1.[BrandId], T1.[SectorId], T1.[ProductId], T1.[ProductDescription], T3.[SectorName], T2.[BrandName], T1.[ProductName] FROM (([Product] T1 LEFT JOIN [Brand] T2 ON T2.[BrandId] = T1.[BrandId]) LEFT JOIN [Sector] T3 ON T3.[SectorId] = T1.[SectorId]) WHERE T1.[ProductId] = @AV18ProductId ORDER BY T1.[ProductId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003T3,1, GxCacheFrequency.OFF ,true,true )
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
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((string[]) buf[8])[0] = rslt.getVarchar(6);
                ((string[]) buf[9])[0] = rslt.getVarchar(7);
                return;
       }
    }

 }

}
