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
   public class wphome : GXDataArea
   {
      public wphome( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public wphome( IGxContext context )
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
         cmbavYear = new GXCombobox();
         cmbavMonth = new GXCombobox();
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
         PA352( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START352( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wphome.aspx") +"\">") ;
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMONTHS", AV24Months);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMONTHS", AV24Months);
         }
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
         if ( ! ( WebComp_Wcamountstatement == null ) )
         {
            WebComp_Wcamountstatement.componentjscripts();
         }
         if ( ! ( WebComp_Wcproductstopsold == null ) )
         {
            WebComp_Wcproductstopsold.componentjscripts();
         }
         if ( ! ( WebComp_Wcproductstoppurchase == null ) )
         {
            WebComp_Wcproductstoppurchase.componentjscripts();
         }
         if ( ! ( WebComp_Wcproductsleastsold == null ) )
         {
            WebComp_Wcproductsleastsold.componentjscripts();
         }
         if ( ! ( WebComp_Wcproductsleastpurchased == null ) )
         {
            WebComp_Wcproductsleastpurchased.componentjscripts();
         }
         if ( ! ( WebComp_Wcproductsoutofstock == null ) )
         {
            WebComp_Wcproductsoutofstock.componentjscripts();
         }
         if ( ! ( WebComp_Wcsuppliertopsold == null ) )
         {
            WebComp_Wcsuppliertopsold.componentjscripts();
         }
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE352( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT352( ) ;
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
         return formatLink("wphome.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WPHome" ;
      }

      public override string GetPgmdesc( )
      {
         return "Home" ;
      }

      protected void WB350( )
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
            GxWebStd.gx_div_start( context, divTable12_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavYear_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavYear_Internalname, "Year", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 11,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavYear, cmbavYear_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV18Year), 4, 0)), 1, cmbavYear_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavYear.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,11);\"", "", true, 0, "HLP_WPHome.htm");
            cmbavYear.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18Year), 4, 0));
            AssignProp("", false, cmbavYear_Internalname, "Values", (string)(cmbavYear.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavMonth_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavMonth_Internalname, "Month", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 15,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavMonth, cmbavMonth_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV21Month), 4, 0)), 1, cmbavMonth_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavMonth.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,15);\"", "", true, 0, "HLP_WPHome.htm");
            cmbavMonth.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21Month), 4, 0));
            AssignProp("", false, cmbavMonth_Internalname, "Values", (string)(cmbavMonth.ToJavascriptSource()), true);
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
            context.WriteHtmlText( "<hr/>") ;
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableamountstatement_Internalname, divTableamountstatement_Visible, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0026"+"", StringUtil.RTrim( WebComp_Wcamountstatement_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0026"+""+"\""+((WebComp_Wcamountstatement_Visible==1) ? "" : " style=\"display:none;\"")) ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcamountstatement_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcamountstatement), StringUtil.Lower( WebComp_Wcamountstatement_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0026"+"");
                  }
                  WebComp_Wcamountstatement.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcamountstatement), StringUtil.Lower( WebComp_Wcamountstatement_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
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
            context.WriteHtmlText( "<hr/>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableproductstopsold_Internalname, divTableproductstopsold_Visible, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0034"+"", StringUtil.RTrim( WebComp_Wcproductstopsold_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0034"+""+"\""+((WebComp_Wcproductstopsold_Visible==1) ? "" : " style=\"display:none;\"")) ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcproductstopsold_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcproductstopsold), StringUtil.Lower( WebComp_Wcproductstopsold_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0034"+"");
                  }
                  WebComp_Wcproductstopsold.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcproductstopsold), StringUtil.Lower( WebComp_Wcproductstopsold_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableproducttoppurchased_Internalname, divTableproducttoppurchased_Visible, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0039"+"", StringUtil.RTrim( WebComp_Wcproductstoppurchase_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0039"+""+"\""+((WebComp_Wcproductstoppurchase_Visible==1) ? "" : " style=\"display:none;\"")) ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcproductstoppurchase_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcproductstoppurchase), StringUtil.Lower( WebComp_Wcproductstoppurchase_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0039"+"");
                  }
                  WebComp_Wcproductstoppurchase.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcproductstoppurchase), StringUtil.Lower( WebComp_Wcproductstoppurchase_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
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
            context.WriteHtmlText( "<hr/>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableproductsleastsold_Internalname, divTableproductsleastsold_Visible, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0047"+"", StringUtil.RTrim( WebComp_Wcproductsleastsold_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0047"+""+"\""+((WebComp_Wcproductsleastsold_Visible==1) ? "" : " style=\"display:none;\"")) ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcproductsleastsold_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcproductsleastsold), StringUtil.Lower( WebComp_Wcproductsleastsold_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0047"+"");
                  }
                  WebComp_Wcproductsleastsold.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcproductsleastsold), StringUtil.Lower( WebComp_Wcproductsleastsold_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableproductsleastpurchased_Internalname, divTableproductsleastpurchased_Visible, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0052"+"", StringUtil.RTrim( WebComp_Wcproductsleastpurchased_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0052"+""+"\""+((WebComp_Wcproductsleastpurchased_Visible==1) ? "" : " style=\"display:none;\"")) ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcproductsleastpurchased_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcproductsleastpurchased), StringUtil.Lower( WebComp_Wcproductsleastpurchased_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0052"+"");
                  }
                  WebComp_Wcproductsleastpurchased.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcproductsleastpurchased), StringUtil.Lower( WebComp_Wcproductsleastpurchased_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
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
            context.WriteHtmlText( "<hr/>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableproductsoutofstock_Internalname, divTableproductsoutofstock_Visible, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0060"+"", StringUtil.RTrim( WebComp_Wcproductsoutofstock_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0060"+""+"\""+((WebComp_Wcproductsoutofstock_Visible==1) ? "" : " style=\"display:none;\"")) ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcproductsoutofstock_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcproductsoutofstock), StringUtil.Lower( WebComp_Wcproductsoutofstock_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0060"+"");
                  }
                  WebComp_Wcproductsoutofstock.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcproductsoutofstock), StringUtil.Lower( WebComp_Wcproductsoutofstock_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
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
            context.WriteHtmlText( "<hr/>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesuppliertopsold_Internalname, divTablesuppliertopsold_Visible, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0068"+"", StringUtil.RTrim( WebComp_Wcsuppliertopsold_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0068"+""+"\""+((WebComp_Wcsuppliertopsold_Visible==1) ? "" : " style=\"display:none;\"")) ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcsuppliertopsold_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcsuppliertopsold), StringUtil.Lower( WebComp_Wcsuppliertopsold_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0068"+"");
                  }
                  WebComp_Wcsuppliertopsold.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcsuppliertopsold), StringUtil.Lower( WebComp_Wcsuppliertopsold_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
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
         wbLoad = true;
      }

      protected void START352( )
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
            Form.Meta.addItem("description", "Home", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP350( ) ;
      }

      protected void WS352( )
      {
         START352( ) ;
         EVT352( ) ;
      }

      protected void EVT352( )
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
                              E11352 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VYEAR.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E12352 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VMONTH.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E13352 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E14352 ();
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
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                        if ( nCmpId == 26 )
                        {
                           OldWcamountstatement = cgiGet( "W0026");
                           if ( ( StringUtil.Len( OldWcamountstatement) == 0 ) || ( StringUtil.StrCmp(OldWcamountstatement, WebComp_Wcamountstatement_Component) != 0 ) )
                           {
                              WebComp_Wcamountstatement = getWebComponent(GetType(), "GeneXus.Programs", OldWcamountstatement, new Object[] {context} );
                              WebComp_Wcamountstatement.ComponentInit();
                              WebComp_Wcamountstatement.Name = "OldWcamountstatement";
                              WebComp_Wcamountstatement_Component = OldWcamountstatement;
                           }
                           if ( StringUtil.Len( WebComp_Wcamountstatement_Component) != 0 )
                           {
                              WebComp_Wcamountstatement.componentprocess("W0026", "", sEvt);
                           }
                           WebComp_Wcamountstatement_Component = OldWcamountstatement;
                        }
                        else if ( nCmpId == 34 )
                        {
                           OldWcproductstopsold = cgiGet( "W0034");
                           if ( ( StringUtil.Len( OldWcproductstopsold) == 0 ) || ( StringUtil.StrCmp(OldWcproductstopsold, WebComp_Wcproductstopsold_Component) != 0 ) )
                           {
                              WebComp_Wcproductstopsold = getWebComponent(GetType(), "GeneXus.Programs", OldWcproductstopsold, new Object[] {context} );
                              WebComp_Wcproductstopsold.ComponentInit();
                              WebComp_Wcproductstopsold.Name = "OldWcproductstopsold";
                              WebComp_Wcproductstopsold_Component = OldWcproductstopsold;
                           }
                           if ( StringUtil.Len( WebComp_Wcproductstopsold_Component) != 0 )
                           {
                              WebComp_Wcproductstopsold.componentprocess("W0034", "", sEvt);
                           }
                           WebComp_Wcproductstopsold_Component = OldWcproductstopsold;
                        }
                        else if ( nCmpId == 39 )
                        {
                           OldWcproductstoppurchase = cgiGet( "W0039");
                           if ( ( StringUtil.Len( OldWcproductstoppurchase) == 0 ) || ( StringUtil.StrCmp(OldWcproductstoppurchase, WebComp_Wcproductstoppurchase_Component) != 0 ) )
                           {
                              WebComp_Wcproductstoppurchase = getWebComponent(GetType(), "GeneXus.Programs", OldWcproductstoppurchase, new Object[] {context} );
                              WebComp_Wcproductstoppurchase.ComponentInit();
                              WebComp_Wcproductstoppurchase.Name = "OldWcproductstoppurchase";
                              WebComp_Wcproductstoppurchase_Component = OldWcproductstoppurchase;
                           }
                           if ( StringUtil.Len( WebComp_Wcproductstoppurchase_Component) != 0 )
                           {
                              WebComp_Wcproductstoppurchase.componentprocess("W0039", "", sEvt);
                           }
                           WebComp_Wcproductstoppurchase_Component = OldWcproductstoppurchase;
                        }
                        else if ( nCmpId == 47 )
                        {
                           OldWcproductsleastsold = cgiGet( "W0047");
                           if ( ( StringUtil.Len( OldWcproductsleastsold) == 0 ) || ( StringUtil.StrCmp(OldWcproductsleastsold, WebComp_Wcproductsleastsold_Component) != 0 ) )
                           {
                              WebComp_Wcproductsleastsold = getWebComponent(GetType(), "GeneXus.Programs", OldWcproductsleastsold, new Object[] {context} );
                              WebComp_Wcproductsleastsold.ComponentInit();
                              WebComp_Wcproductsleastsold.Name = "OldWcproductsleastsold";
                              WebComp_Wcproductsleastsold_Component = OldWcproductsleastsold;
                           }
                           if ( StringUtil.Len( WebComp_Wcproductsleastsold_Component) != 0 )
                           {
                              WebComp_Wcproductsleastsold.componentprocess("W0047", "", sEvt);
                           }
                           WebComp_Wcproductsleastsold_Component = OldWcproductsleastsold;
                        }
                        else if ( nCmpId == 52 )
                        {
                           OldWcproductsleastpurchased = cgiGet( "W0052");
                           if ( ( StringUtil.Len( OldWcproductsleastpurchased) == 0 ) || ( StringUtil.StrCmp(OldWcproductsleastpurchased, WebComp_Wcproductsleastpurchased_Component) != 0 ) )
                           {
                              WebComp_Wcproductsleastpurchased = getWebComponent(GetType(), "GeneXus.Programs", OldWcproductsleastpurchased, new Object[] {context} );
                              WebComp_Wcproductsleastpurchased.ComponentInit();
                              WebComp_Wcproductsleastpurchased.Name = "OldWcproductsleastpurchased";
                              WebComp_Wcproductsleastpurchased_Component = OldWcproductsleastpurchased;
                           }
                           if ( StringUtil.Len( WebComp_Wcproductsleastpurchased_Component) != 0 )
                           {
                              WebComp_Wcproductsleastpurchased.componentprocess("W0052", "", sEvt);
                           }
                           WebComp_Wcproductsleastpurchased_Component = OldWcproductsleastpurchased;
                        }
                        else if ( nCmpId == 60 )
                        {
                           OldWcproductsoutofstock = cgiGet( "W0060");
                           if ( ( StringUtil.Len( OldWcproductsoutofstock) == 0 ) || ( StringUtil.StrCmp(OldWcproductsoutofstock, WebComp_Wcproductsoutofstock_Component) != 0 ) )
                           {
                              WebComp_Wcproductsoutofstock = getWebComponent(GetType(), "GeneXus.Programs", OldWcproductsoutofstock, new Object[] {context} );
                              WebComp_Wcproductsoutofstock.ComponentInit();
                              WebComp_Wcproductsoutofstock.Name = "OldWcproductsoutofstock";
                              WebComp_Wcproductsoutofstock_Component = OldWcproductsoutofstock;
                           }
                           if ( StringUtil.Len( WebComp_Wcproductsoutofstock_Component) != 0 )
                           {
                              WebComp_Wcproductsoutofstock.componentprocess("W0060", "", sEvt);
                           }
                           WebComp_Wcproductsoutofstock_Component = OldWcproductsoutofstock;
                        }
                        else if ( nCmpId == 68 )
                        {
                           OldWcsuppliertopsold = cgiGet( "W0068");
                           if ( ( StringUtil.Len( OldWcsuppliertopsold) == 0 ) || ( StringUtil.StrCmp(OldWcsuppliertopsold, WebComp_Wcsuppliertopsold_Component) != 0 ) )
                           {
                              WebComp_Wcsuppliertopsold = getWebComponent(GetType(), "GeneXus.Programs", OldWcsuppliertopsold, new Object[] {context} );
                              WebComp_Wcsuppliertopsold.ComponentInit();
                              WebComp_Wcsuppliertopsold.Name = "OldWcsuppliertopsold";
                              WebComp_Wcsuppliertopsold_Component = OldWcsuppliertopsold;
                           }
                           if ( StringUtil.Len( WebComp_Wcsuppliertopsold_Component) != 0 )
                           {
                              WebComp_Wcsuppliertopsold.componentprocess("W0068", "", sEvt);
                           }
                           WebComp_Wcsuppliertopsold_Component = OldWcsuppliertopsold;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE352( )
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

      protected void PA352( )
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
               GX_FocusControl = cmbavYear_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( cmbavYear.ItemCount > 0 )
         {
            AV18Year = (short)(Math.Round(NumberUtil.Val( cmbavYear.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV18Year), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV18Year", StringUtil.LTrimStr( (decimal)(AV18Year), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavYear.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV18Year), 4, 0));
            AssignProp("", false, cmbavYear_Internalname, "Values", cmbavYear.ToJavascriptSource(), true);
         }
         if ( cmbavMonth.ItemCount > 0 )
         {
            AV21Month = (short)(Math.Round(NumberUtil.Val( cmbavMonth.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV21Month), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV21Month", StringUtil.LTrimStr( (decimal)(AV21Month), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavMonth.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21Month), 4, 0));
            AssignProp("", false, cmbavMonth_Internalname, "Values", cmbavMonth.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF352( ) ;
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

      protected void RF352( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( StringUtil.StrCmp(WebComp_Wcamountstatement_Component, "") == 0 )
            {
               WebComp_Wcamountstatement = getWebComponent(GetType(), "GeneXus.Programs", "wcstatisticsamountstatement", new Object[] {context} );
               WebComp_Wcamountstatement.ComponentInit();
               WebComp_Wcamountstatement.Name = "WCStatisticsAmountStatement";
               WebComp_Wcamountstatement_Component = "WCStatisticsAmountStatement";
            }
            if ( ( StringUtil.Len( WebComp_Wcamountstatement_Component) != 0 ) && ( StringUtil.StrCmp(WebComp_Wcamountstatement_Component, "WCStatisticsAmountStatement") == 0 ) )
            {
               WebComp_Wcamountstatement.setjustcreated();
               WebComp_Wcamountstatement.componentprepare(new Object[] {(string)"W0026",(string)"",(short)AV18Year,(short)AV21Month});
               WebComp_Wcamountstatement.componentbind(new Object[] {(string)"vYEAR",(string)"vMONTH"});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wcamountstatement )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0026"+"");
               WebComp_Wcamountstatement.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
            if ( WebComp_Wcamountstatement_Visible != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcamountstatement_Component) != 0 )
               {
                  WebComp_Wcamountstatement.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( StringUtil.StrCmp(WebComp_Wcproductstopsold_Component, "") == 0 )
            {
               WebComp_Wcproductstopsold = getWebComponent(GetType(), "GeneXus.Programs", "wcstatisticsproductstopsold", new Object[] {context} );
               WebComp_Wcproductstopsold.ComponentInit();
               WebComp_Wcproductstopsold.Name = "WCStatisticsProductsTopSold";
               WebComp_Wcproductstopsold_Component = "WCStatisticsProductsTopSold";
            }
            if ( ( StringUtil.Len( WebComp_Wcproductstopsold_Component) != 0 ) && ( StringUtil.StrCmp(WebComp_Wcproductstopsold_Component, "WCStatisticsProductsTopSold") == 0 ) )
            {
               WebComp_Wcproductstopsold.setjustcreated();
               WebComp_Wcproductstopsold.componentprepare(new Object[] {(string)"W0034",(string)"",(short)AV18Year,(short)AV21Month});
               WebComp_Wcproductstopsold.componentbind(new Object[] {(string)"vYEAR",(string)"vMONTH"});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wcproductstopsold )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0034"+"");
               WebComp_Wcproductstopsold.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
            if ( WebComp_Wcproductstopsold_Visible != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcproductstopsold_Component) != 0 )
               {
                  WebComp_Wcproductstopsold.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( StringUtil.StrCmp(WebComp_Wcproductstoppurchase_Component, "") == 0 )
            {
               WebComp_Wcproductstoppurchase = getWebComponent(GetType(), "GeneXus.Programs", "wcstatisticsproductstoppurchased", new Object[] {context} );
               WebComp_Wcproductstoppurchase.ComponentInit();
               WebComp_Wcproductstoppurchase.Name = "WCStatisticsProductsTopPurchased";
               WebComp_Wcproductstoppurchase_Component = "WCStatisticsProductsTopPurchased";
            }
            if ( ( StringUtil.Len( WebComp_Wcproductstoppurchase_Component) != 0 ) && ( StringUtil.StrCmp(WebComp_Wcproductstoppurchase_Component, "WCStatisticsProductsTopPurchased") == 0 ) )
            {
               WebComp_Wcproductstoppurchase.setjustcreated();
               WebComp_Wcproductstoppurchase.componentprepare(new Object[] {(string)"W0039",(string)"",(short)AV18Year,(short)AV21Month});
               WebComp_Wcproductstoppurchase.componentbind(new Object[] {(string)"vYEAR",(string)"vMONTH"});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wcproductstoppurchase )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0039"+"");
               WebComp_Wcproductstoppurchase.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
            if ( WebComp_Wcproductstoppurchase_Visible != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcproductstoppurchase_Component) != 0 )
               {
                  WebComp_Wcproductstoppurchase.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( StringUtil.StrCmp(WebComp_Wcproductsleastsold_Component, "") == 0 )
            {
               WebComp_Wcproductsleastsold = getWebComponent(GetType(), "GeneXus.Programs", "wcstatisticsproductsleastsold", new Object[] {context} );
               WebComp_Wcproductsleastsold.ComponentInit();
               WebComp_Wcproductsleastsold.Name = "WCStatisticsProductsLeastSold";
               WebComp_Wcproductsleastsold_Component = "WCStatisticsProductsLeastSold";
            }
            if ( ( StringUtil.Len( WebComp_Wcproductsleastsold_Component) != 0 ) && ( StringUtil.StrCmp(WebComp_Wcproductsleastsold_Component, "WCStatisticsProductsLeastSold") == 0 ) )
            {
               WebComp_Wcproductsleastsold.setjustcreated();
               WebComp_Wcproductsleastsold.componentprepare(new Object[] {(string)"W0047",(string)"",(short)AV18Year,(short)AV21Month});
               WebComp_Wcproductsleastsold.componentbind(new Object[] {(string)"vYEAR",(string)"vMONTH"});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wcproductsleastsold )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0047"+"");
               WebComp_Wcproductsleastsold.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
            if ( WebComp_Wcproductsleastsold_Visible != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcproductsleastsold_Component) != 0 )
               {
                  WebComp_Wcproductsleastsold.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( StringUtil.StrCmp(WebComp_Wcproductsleastpurchased_Component, "") == 0 )
            {
               WebComp_Wcproductsleastpurchased = getWebComponent(GetType(), "GeneXus.Programs", "wcstatisticsproductsleastpurchased", new Object[] {context} );
               WebComp_Wcproductsleastpurchased.ComponentInit();
               WebComp_Wcproductsleastpurchased.Name = "WCStatisticsProductsLeastPurchased";
               WebComp_Wcproductsleastpurchased_Component = "WCStatisticsProductsLeastPurchased";
            }
            if ( ( StringUtil.Len( WebComp_Wcproductsleastpurchased_Component) != 0 ) && ( StringUtil.StrCmp(WebComp_Wcproductsleastpurchased_Component, "WCStatisticsProductsLeastPurchased") == 0 ) )
            {
               WebComp_Wcproductsleastpurchased.setjustcreated();
               WebComp_Wcproductsleastpurchased.componentprepare(new Object[] {(string)"W0052",(string)"",(short)AV18Year,(short)AV21Month});
               WebComp_Wcproductsleastpurchased.componentbind(new Object[] {(string)"vYEAR",(string)"vMONTH"});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wcproductsleastpurchased )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0052"+"");
               WebComp_Wcproductsleastpurchased.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
            if ( WebComp_Wcproductsleastpurchased_Visible != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcproductsleastpurchased_Component) != 0 )
               {
                  WebComp_Wcproductsleastpurchased.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( StringUtil.StrCmp(WebComp_Wcproductsoutofstock_Component, "") == 0 )
            {
               WebComp_Wcproductsoutofstock = getWebComponent(GetType(), "GeneXus.Programs", "wcstatisticsproductsoutofstock", new Object[] {context} );
               WebComp_Wcproductsoutofstock.ComponentInit();
               WebComp_Wcproductsoutofstock.Name = "WCStatisticsProductsOutOfStock";
               WebComp_Wcproductsoutofstock_Component = "WCStatisticsProductsOutOfStock";
            }
            if ( ( StringUtil.Len( WebComp_Wcproductsoutofstock_Component) != 0 ) && ( StringUtil.StrCmp(WebComp_Wcproductsoutofstock_Component, "WCStatisticsProductsOutOfStock") == 0 ) )
            {
               WebComp_Wcproductsoutofstock.setjustcreated();
               WebComp_Wcproductsoutofstock.componentprepare(new Object[] {(string)"W0060",(string)"",(short)AV18Year,(short)AV21Month});
               WebComp_Wcproductsoutofstock.componentbind(new Object[] {(string)"vYEAR",(string)"vMONTH"});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wcproductsoutofstock )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0060"+"");
               WebComp_Wcproductsoutofstock.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
            if ( WebComp_Wcproductsoutofstock_Visible != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcproductsoutofstock_Component) != 0 )
               {
                  WebComp_Wcproductsoutofstock.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( StringUtil.StrCmp(WebComp_Wcsuppliertopsold_Component, "") == 0 )
            {
               WebComp_Wcsuppliertopsold = getWebComponent(GetType(), "GeneXus.Programs", "wcstatisticssuppliertopsold", new Object[] {context} );
               WebComp_Wcsuppliertopsold.ComponentInit();
               WebComp_Wcsuppliertopsold.Name = "WCStatisticsSupplierTopSold";
               WebComp_Wcsuppliertopsold_Component = "WCStatisticsSupplierTopSold";
            }
            if ( ( StringUtil.Len( WebComp_Wcsuppliertopsold_Component) != 0 ) && ( StringUtil.StrCmp(WebComp_Wcsuppliertopsold_Component, "WCStatisticsSupplierTopSold") == 0 ) )
            {
               WebComp_Wcsuppliertopsold.setjustcreated();
               WebComp_Wcsuppliertopsold.componentprepare(new Object[] {(string)"W0068",(string)"",(short)AV18Year,(short)AV21Month});
               WebComp_Wcsuppliertopsold.componentbind(new Object[] {(string)"vYEAR",(string)"vMONTH"});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wcsuppliertopsold )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0068"+"");
               WebComp_Wcsuppliertopsold.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
            if ( WebComp_Wcsuppliertopsold_Visible != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcsuppliertopsold_Component) != 0 )
               {
                  WebComp_Wcsuppliertopsold.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E14352 ();
            WB350( ) ;
         }
      }

      protected void send_integrity_lvl_hashes352( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP350( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11352 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            cmbavYear.CurrentValue = cgiGet( cmbavYear_Internalname);
            AV18Year = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavYear_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV18Year", StringUtil.LTrimStr( (decimal)(AV18Year), 4, 0));
            cmbavMonth.CurrentValue = cgiGet( cmbavMonth_Internalname);
            AV21Month = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavMonth_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV21Month", StringUtil.LTrimStr( (decimal)(AV21Month), 4, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E11352 ();
         if (returnInSub) return;
      }

      protected void E11352( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtSDTContextSession1 = new GeneXus.Programs.general.ui.SdtSDTContextSession();
         new checkauthentication(context ).execute( out  GXt_SdtSDTContextSession1) ;
         /* Execute user subroutine: 'CHARGEYEARS' */
         S112 ();
         if (returnInSub) return;
         AV18Year = (short)(AV20Years.GetNumeric(AV20Years.Count));
         AssignAttri("", false, "AV18Year", StringUtil.LTrimStr( (decimal)(AV18Year), 4, 0));
         /* Execute user subroutine: 'CHARGEMONTHS' */
         S122 ();
         if (returnInSub) return;
         AV21Month = (short)(AV24Months.GetNumeric(AV24Months.Count));
         AssignAttri("", false, "AV21Month", StringUtil.LTrimStr( (decimal)(AV21Month), 4, 0));
      }

      protected void E12352( )
      {
         /* Year_Controlvaluechanged Routine */
         returnInSub = false;
         AV24Months.Clear();
         /* Execute user subroutine: 'CHARGEMONTHS' */
         S122 ();
         if (returnInSub) return;
         AV21Month = 0;
         AssignAttri("", false, "AV21Month", StringUtil.LTrimStr( (decimal)(AV21Month), 4, 0));
         /* Execute user subroutine: 'CHARGEWEBCOMPONENTS' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV24Months", AV24Months);
         cmbavMonth.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21Month), 4, 0));
         AssignProp("", false, cmbavMonth_Internalname, "Values", cmbavMonth.ToJavascriptSource(), true);
      }

      protected void E13352( )
      {
         /* Month_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHARGEWEBCOMPONENTS' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S142( )
      {
         /* 'CHARGEYEARSPURCHASE' Routine */
         returnInSub = false;
         AV35PYears.Clear();
         GXt_objcol_int2 = AV35PYears;
         new purchaseordergetyears(context ).execute( out  GXt_objcol_int2) ;
         AV35PYears = GXt_objcol_int2;
         AV40GXV1 = 1;
         while ( AV40GXV1 <= AV35PYears.Count )
         {
            AV19YearAux = (short)(AV35PYears.GetNumeric(AV40GXV1));
            if ( AV20Years.IndexOf(AV19YearAux) <= 0 )
            {
               AV20Years.Add(AV19YearAux, 0);
            }
            AV40GXV1 = (int)(AV40GXV1+1);
         }
      }

      protected void S152( )
      {
         /* 'CHARGEYEARSSALE' Routine */
         returnInSub = false;
         AV34SYears.Clear();
         GXt_objcol_int2 = AV34SYears;
         new invoicegetyears(context ).execute( out  GXt_objcol_int2) ;
         AV34SYears = GXt_objcol_int2;
         AV41GXV2 = 1;
         while ( AV41GXV2 <= AV34SYears.Count )
         {
            AV19YearAux = (short)(AV34SYears.GetNumeric(AV41GXV2));
            if ( AV20Years.IndexOf(AV19YearAux) <= 0 )
            {
               AV20Years.Add(AV19YearAux, 0);
            }
            AV41GXV2 = (int)(AV41GXV2+1);
         }
      }

      protected void S112( )
      {
         /* 'CHARGEYEARS' Routine */
         returnInSub = false;
         cmbavYear.removeAllItems();
         AV20Years.Clear();
         /* Execute user subroutine: 'CHARGEYEARSPURCHASE' */
         S142 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'CHARGEYEARSSALE' */
         S152 ();
         if (returnInSub) return;
         AV23DateAux = DateTimeUtil.ServerDate( context, pr_default);
         AV19YearAux = (short)(DateTimeUtil.Year( AV23DateAux));
         if ( AV20Years.IndexOf(AV19YearAux) <= 0 )
         {
            AV20Years.Add(AV19YearAux, 0);
         }
         AV20Years.Sort("");
         AV22Position = 1;
         AV42GXV3 = 1;
         while ( AV42GXV3 <= AV20Years.Count )
         {
            AV19YearAux = (short)(AV20Years.GetNumeric(AV42GXV3));
            cmbavYear.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(AV19YearAux), 4, 0)), StringUtil.Str( (decimal)(AV19YearAux), 4, 0), AV22Position);
            AV22Position = (short)(AV22Position+1);
            AV42GXV3 = (int)(AV42GXV3+1);
         }
      }

      protected void S162( )
      {
         /* 'CHARGEMONTHSPURCHASE' Routine */
         returnInSub = false;
         AV36PMonths.Clear();
         GXt_objcol_int2 = AV36PMonths;
         new purchaseordergetmonthperyear(context ).execute(  AV18Year, out  GXt_objcol_int2) ;
         AV36PMonths = GXt_objcol_int2;
         AV43GXV4 = 1;
         while ( AV43GXV4 <= AV36PMonths.Count )
         {
            AV25MonthAux = (short)(AV36PMonths.GetNumeric(AV43GXV4));
            if ( AV24Months.IndexOf(AV25MonthAux) <= 0 )
            {
               AV24Months.Add(AV25MonthAux, 0);
            }
            AV43GXV4 = (int)(AV43GXV4+1);
         }
      }

      protected void S172( )
      {
         /* 'CHARGEMONTHSSALE' Routine */
         returnInSub = false;
         AV37SMonths.Clear();
         GXt_objcol_int2 = AV37SMonths;
         new invoicegetmonthperyear(context ).execute(  AV18Year, out  GXt_objcol_int2) ;
         AV37SMonths = GXt_objcol_int2;
         AV44GXV5 = 1;
         while ( AV44GXV5 <= AV37SMonths.Count )
         {
            AV25MonthAux = (short)(AV37SMonths.GetNumeric(AV44GXV5));
            if ( AV24Months.IndexOf(AV25MonthAux) <= 0 )
            {
               AV24Months.Add(AV25MonthAux, 0);
            }
            AV44GXV5 = (int)(AV44GXV5+1);
         }
      }

      protected void S122( )
      {
         /* 'CHARGEMONTHS' Routine */
         returnInSub = false;
         cmbavMonth.removeAllItems();
         AV24Months.Clear();
         /* Execute user subroutine: 'CHARGEMONTHSPURCHASE' */
         S162 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'CHARGEMONTHSSALE' */
         S172 ();
         if (returnInSub) return;
         AV23DateAux = DateTimeUtil.ServerDate( context, pr_default);
         AV25MonthAux = (short)(DateTimeUtil.Month( AV23DateAux));
         if ( AV24Months.IndexOf(AV25MonthAux) <= 0 )
         {
            AV24Months.Add(AV25MonthAux, 0);
         }
         AV24Months.Sort("");
         cmbavMonth.addItem("0", "All", 1);
         AV22Position = 2;
         AV45GXV6 = 1;
         while ( AV45GXV6 <= AV24Months.Count )
         {
            AV25MonthAux = (short)(AV24Months.GetNumeric(AV45GXV6));
            AV23DateAux = context.localUtil.YMDToD( AV18Year, AV25MonthAux, 1);
            cmbavMonth.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(AV25MonthAux), 4, 0)), DateTimeUtil.CMonth( AV23DateAux, "eng"), AV22Position);
            AV22Position = (short)(AV22Position+1);
            AV45GXV6 = (int)(AV45GXV6+1);
         }
      }

      protected void S132( )
      {
         /* 'CHARGEWEBCOMPONENTS' Routine */
         returnInSub = false;
         if ( new haspermission(context).executeUdp(  "invoice view") && new haspermission(context).executeUdp(  "purchaseorder view") )
         {
            divTableamountstatement_Visible = 1;
            AssignProp("", false, divTableamountstatement_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableamountstatement_Visible), 5, 0), true);
            WebComp_Wcamountstatement_Visible = 1;
            AssignProp("", false, "gxHTMLWrpW0026"+"", "Visible", StringUtil.LTrimStr( (decimal)(WebComp_Wcamountstatement_Visible), 5, 0), true);
            /* Object Property */
            if ( true )
            {
               bDynCreated_Wcamountstatement = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcamountstatement_Component), StringUtil.Lower( "WCStatisticsAmountStatement")) != 0 )
            {
               WebComp_Wcamountstatement = getWebComponent(GetType(), "GeneXus.Programs", "wcstatisticsamountstatement", new Object[] {context} );
               WebComp_Wcamountstatement.ComponentInit();
               WebComp_Wcamountstatement.Name = "WCStatisticsAmountStatement";
               WebComp_Wcamountstatement_Component = "WCStatisticsAmountStatement";
            }
            if ( StringUtil.Len( WebComp_Wcamountstatement_Component) != 0 )
            {
               WebComp_Wcamountstatement.setjustcreated();
               WebComp_Wcamountstatement.componentprepare(new Object[] {(string)"W0026",(string)"",(short)AV18Year,(short)AV21Month});
               WebComp_Wcamountstatement.componentbind(new Object[] {(string)"vYEAR",(string)"vMONTH"});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wcamountstatement )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0026"+"");
               WebComp_Wcamountstatement.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         else
         {
            divTableamountstatement_Visible = 0;
            AssignProp("", false, divTableamountstatement_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableamountstatement_Visible), 5, 0), true);
            WebComp_Wcamountstatement_Visible = 0;
            AssignProp("", false, "gxHTMLWrpW0026"+"", "Visible", StringUtil.LTrimStr( (decimal)(WebComp_Wcamountstatement_Visible), 5, 0), true);
         }
         if ( new haspermission(context).executeUdp(  "product view") && new haspermission(context).executeUdp(  "invoice view") )
         {
            divTableproductstopsold_Visible = 1;
            AssignProp("", false, divTableproductstopsold_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableproductstopsold_Visible), 5, 0), true);
            WebComp_Wcproductstopsold_Visible = 1;
            AssignProp("", false, "gxHTMLWrpW0034"+"", "Visible", StringUtil.LTrimStr( (decimal)(WebComp_Wcproductstopsold_Visible), 5, 0), true);
            /* Object Property */
            if ( true )
            {
               bDynCreated_Wcproductstopsold = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcproductstopsold_Component), StringUtil.Lower( "WCStatisticsProductsTopSold")) != 0 )
            {
               WebComp_Wcproductstopsold = getWebComponent(GetType(), "GeneXus.Programs", "wcstatisticsproductstopsold", new Object[] {context} );
               WebComp_Wcproductstopsold.ComponentInit();
               WebComp_Wcproductstopsold.Name = "WCStatisticsProductsTopSold";
               WebComp_Wcproductstopsold_Component = "WCStatisticsProductsTopSold";
            }
            if ( StringUtil.Len( WebComp_Wcproductstopsold_Component) != 0 )
            {
               WebComp_Wcproductstopsold.setjustcreated();
               WebComp_Wcproductstopsold.componentprepare(new Object[] {(string)"W0034",(string)"",(short)AV18Year,(short)AV21Month});
               WebComp_Wcproductstopsold.componentbind(new Object[] {(string)"vYEAR",(string)"vMONTH"});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wcproductstopsold )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0034"+"");
               WebComp_Wcproductstopsold.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
            divTableproductsleastsold_Visible = 1;
            AssignProp("", false, divTableproductsleastsold_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableproductsleastsold_Visible), 5, 0), true);
            WebComp_Wcproductsleastsold_Visible = 1;
            AssignProp("", false, "gxHTMLWrpW0047"+"", "Visible", StringUtil.LTrimStr( (decimal)(WebComp_Wcproductsleastsold_Visible), 5, 0), true);
            /* Object Property */
            if ( true )
            {
               bDynCreated_Wcproductsleastsold = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcproductsleastsold_Component), StringUtil.Lower( "WCStatisticsProductsLeastSold")) != 0 )
            {
               WebComp_Wcproductsleastsold = getWebComponent(GetType(), "GeneXus.Programs", "wcstatisticsproductsleastsold", new Object[] {context} );
               WebComp_Wcproductsleastsold.ComponentInit();
               WebComp_Wcproductsleastsold.Name = "WCStatisticsProductsLeastSold";
               WebComp_Wcproductsleastsold_Component = "WCStatisticsProductsLeastSold";
            }
            if ( StringUtil.Len( WebComp_Wcproductsleastsold_Component) != 0 )
            {
               WebComp_Wcproductsleastsold.setjustcreated();
               WebComp_Wcproductsleastsold.componentprepare(new Object[] {(string)"W0047",(string)"",(short)AV18Year,(short)AV21Month});
               WebComp_Wcproductsleastsold.componentbind(new Object[] {(string)"vYEAR",(string)"vMONTH"});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wcproductsleastsold )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0047"+"");
               WebComp_Wcproductsleastsold.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         else
         {
            divTableproductstopsold_Visible = 0;
            AssignProp("", false, divTableproductstopsold_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableproductstopsold_Visible), 5, 0), true);
            WebComp_Wcproductstopsold_Visible = 0;
            AssignProp("", false, "gxHTMLWrpW0034"+"", "Visible", StringUtil.LTrimStr( (decimal)(WebComp_Wcproductstopsold_Visible), 5, 0), true);
            divTableproductsleastsold_Visible = 0;
            AssignProp("", false, divTableproductsleastsold_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableproductsleastsold_Visible), 5, 0), true);
            WebComp_Wcproductsleastsold_Visible = 0;
            AssignProp("", false, "gxHTMLWrpW0047"+"", "Visible", StringUtil.LTrimStr( (decimal)(WebComp_Wcproductsleastsold_Visible), 5, 0), true);
         }
         if ( new haspermission(context).executeUdp(  "product view") && new haspermission(context).executeUdp(  "purchaseorder view") )
         {
            divTableproducttoppurchased_Visible = 1;
            AssignProp("", false, divTableproducttoppurchased_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableproducttoppurchased_Visible), 5, 0), true);
            WebComp_Wcproductstoppurchase_Visible = 1;
            AssignProp("", false, "gxHTMLWrpW0039"+"", "Visible", StringUtil.LTrimStr( (decimal)(WebComp_Wcproductstoppurchase_Visible), 5, 0), true);
            /* Object Property */
            if ( true )
            {
               bDynCreated_Wcproductstoppurchase = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcproductstoppurchase_Component), StringUtil.Lower( "WCStatisticsProductsTopPurchased")) != 0 )
            {
               WebComp_Wcproductstoppurchase = getWebComponent(GetType(), "GeneXus.Programs", "wcstatisticsproductstoppurchased", new Object[] {context} );
               WebComp_Wcproductstoppurchase.ComponentInit();
               WebComp_Wcproductstoppurchase.Name = "WCStatisticsProductsTopPurchased";
               WebComp_Wcproductstoppurchase_Component = "WCStatisticsProductsTopPurchased";
            }
            if ( StringUtil.Len( WebComp_Wcproductstoppurchase_Component) != 0 )
            {
               WebComp_Wcproductstoppurchase.setjustcreated();
               WebComp_Wcproductstoppurchase.componentprepare(new Object[] {(string)"W0039",(string)"",(short)AV18Year,(short)AV21Month});
               WebComp_Wcproductstoppurchase.componentbind(new Object[] {(string)"vYEAR",(string)"vMONTH"});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wcproductstoppurchase )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0039"+"");
               WebComp_Wcproductstoppurchase.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
            divTableproductsleastpurchased_Visible = 1;
            AssignProp("", false, divTableproductsleastpurchased_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableproductsleastpurchased_Visible), 5, 0), true);
            WebComp_Wcproductsleastpurchased_Visible = 1;
            AssignProp("", false, "gxHTMLWrpW0052"+"", "Visible", StringUtil.LTrimStr( (decimal)(WebComp_Wcproductsleastpurchased_Visible), 5, 0), true);
            /* Object Property */
            if ( true )
            {
               bDynCreated_Wcproductsleastpurchased = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcproductsleastpurchased_Component), StringUtil.Lower( "WCStatisticsProductsLeastPurchased")) != 0 )
            {
               WebComp_Wcproductsleastpurchased = getWebComponent(GetType(), "GeneXus.Programs", "wcstatisticsproductsleastpurchased", new Object[] {context} );
               WebComp_Wcproductsleastpurchased.ComponentInit();
               WebComp_Wcproductsleastpurchased.Name = "WCStatisticsProductsLeastPurchased";
               WebComp_Wcproductsleastpurchased_Component = "WCStatisticsProductsLeastPurchased";
            }
            if ( StringUtil.Len( WebComp_Wcproductsleastpurchased_Component) != 0 )
            {
               WebComp_Wcproductsleastpurchased.setjustcreated();
               WebComp_Wcproductsleastpurchased.componentprepare(new Object[] {(string)"W0052",(string)"",(short)AV18Year,(short)AV21Month});
               WebComp_Wcproductsleastpurchased.componentbind(new Object[] {(string)"vYEAR",(string)"vMONTH"});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wcproductsleastpurchased )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0052"+"");
               WebComp_Wcproductsleastpurchased.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         else
         {
            divTableproducttoppurchased_Visible = 0;
            AssignProp("", false, divTableproducttoppurchased_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableproducttoppurchased_Visible), 5, 0), true);
            WebComp_Wcproductstoppurchase_Visible = 0;
            AssignProp("", false, "gxHTMLWrpW0039"+"", "Visible", StringUtil.LTrimStr( (decimal)(WebComp_Wcproductstoppurchase_Visible), 5, 0), true);
            divTableproductsleastpurchased_Visible = 0;
            AssignProp("", false, divTableproductsleastpurchased_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableproductsleastpurchased_Visible), 5, 0), true);
            WebComp_Wcproductsleastpurchased_Visible = 0;
            AssignProp("", false, "gxHTMLWrpW0052"+"", "Visible", StringUtil.LTrimStr( (decimal)(WebComp_Wcproductsleastpurchased_Visible), 5, 0), true);
         }
         if ( new haspermission(context).executeUdp(  "supplier view") && new haspermission(context).executeUdp(  "invoice view") )
         {
            divTablesuppliertopsold_Visible = 1;
            AssignProp("", false, divTablesuppliertopsold_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesuppliertopsold_Visible), 5, 0), true);
            WebComp_Wcsuppliertopsold_Visible = 1;
            AssignProp("", false, "gxHTMLWrpW0068"+"", "Visible", StringUtil.LTrimStr( (decimal)(WebComp_Wcsuppliertopsold_Visible), 5, 0), true);
            /* Object Property */
            if ( true )
            {
               bDynCreated_Wcsuppliertopsold = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcsuppliertopsold_Component), StringUtil.Lower( "WCStatisticsSupplierTopSold")) != 0 )
            {
               WebComp_Wcsuppliertopsold = getWebComponent(GetType(), "GeneXus.Programs", "wcstatisticssuppliertopsold", new Object[] {context} );
               WebComp_Wcsuppliertopsold.ComponentInit();
               WebComp_Wcsuppliertopsold.Name = "WCStatisticsSupplierTopSold";
               WebComp_Wcsuppliertopsold_Component = "WCStatisticsSupplierTopSold";
            }
            if ( StringUtil.Len( WebComp_Wcsuppliertopsold_Component) != 0 )
            {
               WebComp_Wcsuppliertopsold.setjustcreated();
               WebComp_Wcsuppliertopsold.componentprepare(new Object[] {(string)"W0068",(string)"",(short)AV18Year,(short)AV21Month});
               WebComp_Wcsuppliertopsold.componentbind(new Object[] {(string)"vYEAR",(string)"vMONTH"});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wcsuppliertopsold )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0068"+"");
               WebComp_Wcsuppliertopsold.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         else
         {
            divTablesuppliertopsold_Visible = 0;
            AssignProp("", false, divTablesuppliertopsold_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablesuppliertopsold_Visible), 5, 0), true);
            WebComp_Wcsuppliertopsold_Visible = 0;
            AssignProp("", false, "gxHTMLWrpW0068"+"", "Visible", StringUtil.LTrimStr( (decimal)(WebComp_Wcsuppliertopsold_Visible), 5, 0), true);
         }
         if ( new haspermission(context).executeUdp(  "product view") )
         {
            divTableproductsoutofstock_Visible = 1;
            AssignProp("", false, divTableproductsoutofstock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableproductsoutofstock_Visible), 5, 0), true);
            WebComp_Wcproductsoutofstock_Visible = 1;
            AssignProp("", false, "gxHTMLWrpW0060"+"", "Visible", StringUtil.LTrimStr( (decimal)(WebComp_Wcproductsoutofstock_Visible), 5, 0), true);
            /* Object Property */
            if ( true )
            {
               bDynCreated_Wcproductsoutofstock = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcproductsoutofstock_Component), StringUtil.Lower( "WCStatisticsProductsOutOfStock")) != 0 )
            {
               WebComp_Wcproductsoutofstock = getWebComponent(GetType(), "GeneXus.Programs", "wcstatisticsproductsoutofstock", new Object[] {context} );
               WebComp_Wcproductsoutofstock.ComponentInit();
               WebComp_Wcproductsoutofstock.Name = "WCStatisticsProductsOutOfStock";
               WebComp_Wcproductsoutofstock_Component = "WCStatisticsProductsOutOfStock";
            }
            if ( StringUtil.Len( WebComp_Wcproductsoutofstock_Component) != 0 )
            {
               WebComp_Wcproductsoutofstock.setjustcreated();
               WebComp_Wcproductsoutofstock.componentprepare(new Object[] {(string)"W0060",(string)"",(short)AV18Year,(short)AV21Month});
               WebComp_Wcproductsoutofstock.componentbind(new Object[] {(string)"vYEAR",(string)"vMONTH"});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wcproductsoutofstock )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0060"+"");
               WebComp_Wcproductsoutofstock.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         else
         {
            divTableproductsoutofstock_Visible = 0;
            AssignProp("", false, divTableproductsoutofstock_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableproductsoutofstock_Visible), 5, 0), true);
            WebComp_Wcproductsoutofstock_Visible = 0;
            AssignProp("", false, "gxHTMLWrpW0060"+"", "Visible", StringUtil.LTrimStr( (decimal)(WebComp_Wcproductsoutofstock_Visible), 5, 0), true);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E14352( )
      {
         /* Load Routine */
         returnInSub = false;
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
         PA352( ) ;
         WS352( ) ;
         WE352( ) ;
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
         if ( StringUtil.StrCmp(WebComp_Wcamountstatement_Component, "") == 0 )
         {
            WebComp_Wcamountstatement = getWebComponent(GetType(), "GeneXus.Programs", "wcstatisticsamountstatement", new Object[] {context} );
            WebComp_Wcamountstatement.ComponentInit();
            WebComp_Wcamountstatement.Name = "WCStatisticsAmountStatement";
            WebComp_Wcamountstatement_Component = "WCStatisticsAmountStatement";
         }
         if ( ! ( WebComp_Wcamountstatement == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcamountstatement_Component) != 0 )
            {
               WebComp_Wcamountstatement.componentthemes();
            }
         }
         if ( StringUtil.StrCmp(WebComp_Wcproductstopsold_Component, "") == 0 )
         {
            WebComp_Wcproductstopsold = getWebComponent(GetType(), "GeneXus.Programs", "wcstatisticsproductstopsold", new Object[] {context} );
            WebComp_Wcproductstopsold.ComponentInit();
            WebComp_Wcproductstopsold.Name = "WCStatisticsProductsTopSold";
            WebComp_Wcproductstopsold_Component = "WCStatisticsProductsTopSold";
         }
         if ( ! ( WebComp_Wcproductstopsold == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcproductstopsold_Component) != 0 )
            {
               WebComp_Wcproductstopsold.componentthemes();
            }
         }
         if ( StringUtil.StrCmp(WebComp_Wcproductstoppurchase_Component, "") == 0 )
         {
            WebComp_Wcproductstoppurchase = getWebComponent(GetType(), "GeneXus.Programs", "wcstatisticsproductstoppurchased", new Object[] {context} );
            WebComp_Wcproductstoppurchase.ComponentInit();
            WebComp_Wcproductstoppurchase.Name = "WCStatisticsProductsTopPurchased";
            WebComp_Wcproductstoppurchase_Component = "WCStatisticsProductsTopPurchased";
         }
         if ( ! ( WebComp_Wcproductstoppurchase == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcproductstoppurchase_Component) != 0 )
            {
               WebComp_Wcproductstoppurchase.componentthemes();
            }
         }
         if ( StringUtil.StrCmp(WebComp_Wcproductsleastsold_Component, "") == 0 )
         {
            WebComp_Wcproductsleastsold = getWebComponent(GetType(), "GeneXus.Programs", "wcstatisticsproductsleastsold", new Object[] {context} );
            WebComp_Wcproductsleastsold.ComponentInit();
            WebComp_Wcproductsleastsold.Name = "WCStatisticsProductsLeastSold";
            WebComp_Wcproductsleastsold_Component = "WCStatisticsProductsLeastSold";
         }
         if ( ! ( WebComp_Wcproductsleastsold == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcproductsleastsold_Component) != 0 )
            {
               WebComp_Wcproductsleastsold.componentthemes();
            }
         }
         if ( StringUtil.StrCmp(WebComp_Wcproductsleastpurchased_Component, "") == 0 )
         {
            WebComp_Wcproductsleastpurchased = getWebComponent(GetType(), "GeneXus.Programs", "wcstatisticsproductsleastpurchased", new Object[] {context} );
            WebComp_Wcproductsleastpurchased.ComponentInit();
            WebComp_Wcproductsleastpurchased.Name = "WCStatisticsProductsLeastPurchased";
            WebComp_Wcproductsleastpurchased_Component = "WCStatisticsProductsLeastPurchased";
         }
         if ( ! ( WebComp_Wcproductsleastpurchased == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcproductsleastpurchased_Component) != 0 )
            {
               WebComp_Wcproductsleastpurchased.componentthemes();
            }
         }
         if ( StringUtil.StrCmp(WebComp_Wcproductsoutofstock_Component, "") == 0 )
         {
            WebComp_Wcproductsoutofstock = getWebComponent(GetType(), "GeneXus.Programs", "wcstatisticsproductsoutofstock", new Object[] {context} );
            WebComp_Wcproductsoutofstock.ComponentInit();
            WebComp_Wcproductsoutofstock.Name = "WCStatisticsProductsOutOfStock";
            WebComp_Wcproductsoutofstock_Component = "WCStatisticsProductsOutOfStock";
         }
         if ( ! ( WebComp_Wcproductsoutofstock == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcproductsoutofstock_Component) != 0 )
            {
               WebComp_Wcproductsoutofstock.componentthemes();
            }
         }
         if ( StringUtil.StrCmp(WebComp_Wcsuppliertopsold_Component, "") == 0 )
         {
            WebComp_Wcsuppliertopsold = getWebComponent(GetType(), "GeneXus.Programs", "wcstatisticssuppliertopsold", new Object[] {context} );
            WebComp_Wcsuppliertopsold.ComponentInit();
            WebComp_Wcsuppliertopsold.Name = "WCStatisticsSupplierTopSold";
            WebComp_Wcsuppliertopsold_Component = "WCStatisticsSupplierTopSold";
         }
         if ( ! ( WebComp_Wcsuppliertopsold == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcsuppliertopsold_Component) != 0 )
            {
               WebComp_Wcsuppliertopsold.componentthemes();
            }
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024121421263485", true, true);
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
         context.AddJavascriptSource("wphome.js", "?2024121421263486", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavYear.Name = "vYEAR";
         cmbavYear.WebTags = "";
         if ( cmbavYear.ItemCount > 0 )
         {
            AV18Year = (short)(Math.Round(NumberUtil.Val( cmbavYear.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV18Year), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV18Year", StringUtil.LTrimStr( (decimal)(AV18Year), 4, 0));
         }
         cmbavMonth.Name = "vMONTH";
         cmbavMonth.WebTags = "";
         cmbavMonth.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(0), 4, 0)), "(None)", 0);
         if ( cmbavMonth.ItemCount > 0 )
         {
            AV21Month = (short)(Math.Round(NumberUtil.Val( cmbavMonth.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV21Month), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV21Month", StringUtil.LTrimStr( (decimal)(AV21Month), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         cmbavYear_Internalname = "vYEAR";
         cmbavMonth_Internalname = "vMONTH";
         divTable12_Internalname = "TABLE12";
         divTableamountstatement_Internalname = "TABLEAMOUNTSTATEMENT";
         divTableproductstopsold_Internalname = "TABLEPRODUCTSTOPSOLD";
         divTableproducttoppurchased_Internalname = "TABLEPRODUCTTOPPURCHASED";
         divTableproductsleastsold_Internalname = "TABLEPRODUCTSLEASTSOLD";
         divTableproductsleastpurchased_Internalname = "TABLEPRODUCTSLEASTPURCHASED";
         divTableproductsoutofstock_Internalname = "TABLEPRODUCTSOUTOFSTOCK";
         divTablesuppliertopsold_Internalname = "TABLESUPPLIERTOPSOLD";
         divTable3_Internalname = "TABLE3";
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
         WebComp_Wcsuppliertopsold_Visible = 1;
         AssignProp("", false, "gxHTMLWrpW0068"+"", "Visible", StringUtil.LTrimStr( (decimal)(WebComp_Wcsuppliertopsold_Visible), 5, 0), true);
         divTablesuppliertopsold_Visible = 1;
         WebComp_Wcproductsoutofstock_Visible = 1;
         AssignProp("", false, "gxHTMLWrpW0060"+"", "Visible", StringUtil.LTrimStr( (decimal)(WebComp_Wcproductsoutofstock_Visible), 5, 0), true);
         divTableproductsoutofstock_Visible = 1;
         WebComp_Wcproductsleastpurchased_Visible = 1;
         AssignProp("", false, "gxHTMLWrpW0052"+"", "Visible", StringUtil.LTrimStr( (decimal)(WebComp_Wcproductsleastpurchased_Visible), 5, 0), true);
         divTableproductsleastpurchased_Visible = 1;
         WebComp_Wcproductsleastsold_Visible = 1;
         AssignProp("", false, "gxHTMLWrpW0047"+"", "Visible", StringUtil.LTrimStr( (decimal)(WebComp_Wcproductsleastsold_Visible), 5, 0), true);
         divTableproductsleastsold_Visible = 1;
         WebComp_Wcproductstoppurchase_Visible = 1;
         AssignProp("", false, "gxHTMLWrpW0039"+"", "Visible", StringUtil.LTrimStr( (decimal)(WebComp_Wcproductstoppurchase_Visible), 5, 0), true);
         divTableproducttoppurchased_Visible = 1;
         WebComp_Wcproductstopsold_Visible = 1;
         AssignProp("", false, "gxHTMLWrpW0034"+"", "Visible", StringUtil.LTrimStr( (decimal)(WebComp_Wcproductstopsold_Visible), 5, 0), true);
         divTableproductstopsold_Visible = 1;
         WebComp_Wcamountstatement_Visible = 1;
         AssignProp("", false, "gxHTMLWrpW0026"+"", "Visible", StringUtil.LTrimStr( (decimal)(WebComp_Wcamountstatement_Visible), 5, 0), true);
         divTableamountstatement_Visible = 1;
         cmbavMonth_Jsonclick = "";
         cmbavMonth.Enabled = 1;
         cmbavYear_Jsonclick = "";
         cmbavYear.Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Home";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VYEAR.CONTROLVALUECHANGED","{handler:'E12352',iparms:[{av:'cmbavYear'},{av:'AV18Year',fld:'vYEAR',pic:'ZZZ9'},{av:'cmbavMonth'},{av:'AV21Month',fld:'vMONTH',pic:'ZZZ9'},{av:'AV24Months',fld:'vMONTHS',pic:''}]");
         setEventMetadata("VYEAR.CONTROLVALUECHANGED",",oparms:[{av:'AV24Months',fld:'vMONTHS',pic:''},{av:'cmbavMonth'},{av:'AV21Month',fld:'vMONTH',pic:'ZZZ9'},{ctrl:'WCAMOUNTSTATEMENT'},{av:'divTableamountstatement_Visible',ctrl:'TABLEAMOUNTSTATEMENT',prop:'Visible'},{ctrl:'WCAMOUNTSTATEMENT',prop:'Visible'},{ctrl:'WCPRODUCTSTOPSOLD'},{ctrl:'WCPRODUCTSLEASTSOLD'},{av:'divTableproductstopsold_Visible',ctrl:'TABLEPRODUCTSTOPSOLD',prop:'Visible'},{ctrl:'WCPRODUCTSTOPSOLD',prop:'Visible'},{av:'divTableproductsleastsold_Visible',ctrl:'TABLEPRODUCTSLEASTSOLD',prop:'Visible'},{ctrl:'WCPRODUCTSLEASTSOLD',prop:'Visible'},{ctrl:'WCPRODUCTSTOPPURCHASE'},{ctrl:'WCPRODUCTSLEASTPURCHASED'},{av:'divTableproducttoppurchased_Visible',ctrl:'TABLEPRODUCTTOPPURCHASED',prop:'Visible'},{ctrl:'WCPRODUCTSTOPPURCHASE',prop:'Visible'},{av:'divTableproductsleastpurchased_Visible',ctrl:'TABLEPRODUCTSLEASTPURCHASED',prop:'Visible'},{ctrl:'WCPRODUCTSLEASTPURCHASED',prop:'Visible'},{ctrl:'WCSUPPLIERTOPSOLD'},{av:'divTablesuppliertopsold_Visible',ctrl:'TABLESUPPLIERTOPSOLD',prop:'Visible'},{ctrl:'WCSUPPLIERTOPSOLD',prop:'Visible'},{ctrl:'WCPRODUCTSOUTOFSTOCK'},{av:'divTableproductsoutofstock_Visible',ctrl:'TABLEPRODUCTSOUTOFSTOCK',prop:'Visible'},{ctrl:'WCPRODUCTSOUTOFSTOCK',prop:'Visible'}]}");
         setEventMetadata("VMONTH.CONTROLVALUECHANGED","{handler:'E13352',iparms:[{av:'cmbavYear'},{av:'AV18Year',fld:'vYEAR',pic:'ZZZ9'},{av:'cmbavMonth'},{av:'AV21Month',fld:'vMONTH',pic:'ZZZ9'}]");
         setEventMetadata("VMONTH.CONTROLVALUECHANGED",",oparms:[{ctrl:'WCAMOUNTSTATEMENT'},{av:'divTableamountstatement_Visible',ctrl:'TABLEAMOUNTSTATEMENT',prop:'Visible'},{ctrl:'WCAMOUNTSTATEMENT',prop:'Visible'},{ctrl:'WCPRODUCTSTOPSOLD'},{ctrl:'WCPRODUCTSLEASTSOLD'},{av:'divTableproductstopsold_Visible',ctrl:'TABLEPRODUCTSTOPSOLD',prop:'Visible'},{ctrl:'WCPRODUCTSTOPSOLD',prop:'Visible'},{av:'divTableproductsleastsold_Visible',ctrl:'TABLEPRODUCTSLEASTSOLD',prop:'Visible'},{ctrl:'WCPRODUCTSLEASTSOLD',prop:'Visible'},{ctrl:'WCPRODUCTSTOPPURCHASE'},{ctrl:'WCPRODUCTSLEASTPURCHASED'},{av:'divTableproducttoppurchased_Visible',ctrl:'TABLEPRODUCTTOPPURCHASED',prop:'Visible'},{ctrl:'WCPRODUCTSTOPPURCHASE',prop:'Visible'},{av:'divTableproductsleastpurchased_Visible',ctrl:'TABLEPRODUCTSLEASTPURCHASED',prop:'Visible'},{ctrl:'WCPRODUCTSLEASTPURCHASED',prop:'Visible'},{ctrl:'WCSUPPLIERTOPSOLD'},{av:'divTablesuppliertopsold_Visible',ctrl:'TABLESUPPLIERTOPSOLD',prop:'Visible'},{ctrl:'WCSUPPLIERTOPSOLD',prop:'Visible'},{ctrl:'WCPRODUCTSOUTOFSTOCK'},{av:'divTableproductsoutofstock_Visible',ctrl:'TABLEPRODUCTSOUTOFSTOCK',prop:'Visible'},{ctrl:'WCPRODUCTSOUTOFSTOCK',prop:'Visible'}]}");
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
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV24Months = new GxSimpleCollection<short>();
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         WebComp_Wcamountstatement_Component = "";
         OldWcamountstatement = "";
         WebComp_Wcproductstopsold_Component = "";
         OldWcproductstopsold = "";
         WebComp_Wcproductstoppurchase_Component = "";
         OldWcproductstoppurchase = "";
         WebComp_Wcproductsleastsold_Component = "";
         OldWcproductsleastsold = "";
         WebComp_Wcproductsleastpurchased_Component = "";
         OldWcproductsleastpurchased = "";
         WebComp_Wcproductsoutofstock_Component = "";
         OldWcproductsoutofstock = "";
         WebComp_Wcsuppliertopsold_Component = "";
         OldWcsuppliertopsold = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXt_SdtSDTContextSession1 = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         AV20Years = new GxSimpleCollection<short>();
         AV35PYears = new GxSimpleCollection<short>();
         AV34SYears = new GxSimpleCollection<short>();
         AV23DateAux = DateTime.MinValue;
         AV36PMonths = new GxSimpleCollection<short>();
         AV37SMonths = new GxSimpleCollection<short>();
         GXt_objcol_int2 = new GxSimpleCollection<short>();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wphome__default(),
            new Object[][] {
            }
         );
         WebComp_Wcamountstatement = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wcproductstopsold = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wcproductstoppurchase = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wcproductsleastsold = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wcproductsleastpurchased = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wcproductsoutofstock = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wcsuppliertopsold = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV18Year ;
      private short AV21Month ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV19YearAux ;
      private short AV22Position ;
      private short AV25MonthAux ;
      private short nGXWrapped ;
      private int divTableamountstatement_Visible ;
      private int WebComp_Wcamountstatement_Visible ;
      private int divTableproductstopsold_Visible ;
      private int WebComp_Wcproductstopsold_Visible ;
      private int divTableproducttoppurchased_Visible ;
      private int WebComp_Wcproductstoppurchase_Visible ;
      private int divTableproductsleastsold_Visible ;
      private int WebComp_Wcproductsleastsold_Visible ;
      private int divTableproductsleastpurchased_Visible ;
      private int WebComp_Wcproductsleastpurchased_Visible ;
      private int divTableproductsoutofstock_Visible ;
      private int WebComp_Wcproductsoutofstock_Visible ;
      private int divTablesuppliertopsold_Visible ;
      private int WebComp_Wcsuppliertopsold_Visible ;
      private int AV40GXV1 ;
      private int AV41GXV2 ;
      private int AV42GXV3 ;
      private int AV43GXV4 ;
      private int AV44GXV5 ;
      private int AV45GXV6 ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divTable12_Internalname ;
      private string cmbavYear_Internalname ;
      private string TempTags ;
      private string cmbavYear_Jsonclick ;
      private string cmbavMonth_Internalname ;
      private string cmbavMonth_Jsonclick ;
      private string divTable3_Internalname ;
      private string divTableamountstatement_Internalname ;
      private string WebComp_Wcamountstatement_Component ;
      private string OldWcamountstatement ;
      private string divTableproductstopsold_Internalname ;
      private string WebComp_Wcproductstopsold_Component ;
      private string OldWcproductstopsold ;
      private string divTableproducttoppurchased_Internalname ;
      private string WebComp_Wcproductstoppurchase_Component ;
      private string OldWcproductstoppurchase ;
      private string divTableproductsleastsold_Internalname ;
      private string WebComp_Wcproductsleastsold_Component ;
      private string OldWcproductsleastsold ;
      private string divTableproductsleastpurchased_Internalname ;
      private string WebComp_Wcproductsleastpurchased_Component ;
      private string OldWcproductsleastpurchased ;
      private string divTableproductsoutofstock_Internalname ;
      private string WebComp_Wcproductsoutofstock_Component ;
      private string OldWcproductsoutofstock ;
      private string divTablesuppliertopsold_Internalname ;
      private string WebComp_Wcsuppliertopsold_Component ;
      private string OldWcsuppliertopsold ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private DateTime AV23DateAux ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bDynCreated_Wcamountstatement ;
      private bool bDynCreated_Wcproductstopsold ;
      private bool bDynCreated_Wcproductstoppurchase ;
      private bool bDynCreated_Wcproductsleastsold ;
      private bool bDynCreated_Wcproductsleastpurchased ;
      private bool bDynCreated_Wcproductsoutofstock ;
      private bool bDynCreated_Wcsuppliertopsold ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private GxSimpleCollection<short> AV24Months ;
      private GxSimpleCollection<short> AV20Years ;
      private GxSimpleCollection<short> AV35PYears ;
      private GxSimpleCollection<short> AV34SYears ;
      private GxSimpleCollection<short> AV36PMonths ;
      private GxSimpleCollection<short> AV37SMonths ;
      private GxSimpleCollection<short> GXt_objcol_int2 ;
      private GXWebComponent WebComp_Wcamountstatement ;
      private GXWebComponent WebComp_Wcproductstopsold ;
      private GXWebComponent WebComp_Wcproductstoppurchase ;
      private GXWebComponent WebComp_Wcproductsleastsold ;
      private GXWebComponent WebComp_Wcproductsleastpurchased ;
      private GXWebComponent WebComp_Wcproductsoutofstock ;
      private GXWebComponent WebComp_Wcsuppliertopsold ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavYear ;
      private GXCombobox cmbavMonth ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession GXt_SdtSDTContextSession1 ;
   }

   public class wphome__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

 }

}
