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
   public class wpstatisticsgraphs : GXDataArea
   {
      public wpstatisticsgraphs( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public wpstatisticsgraphs( IGxContext context )
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
         cmbavType = new GXCombobox();
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
         PA4J2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START4J2( ) ;
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1853160), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1853160), false, true);
         context.AddJavascriptSource("calendar-en.js", "?"+context.GetBuildNumber( 1853160), false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpstatisticsgraphs.aspx") +"\">") ;
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vELEMENTS", AV10Elements);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vELEMENTS", AV10Elements);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPARAMETERS", AV8Parameters);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPARAMETERS", AV8Parameters);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vITEMCLICKDATA", AV16ItemClickData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vITEMCLICKDATA", AV16ItemClickData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vITEMDOUBLECLICKDATA", AV17ItemDoubleClickData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vITEMDOUBLECLICKDATA", AV17ItemDoubleClickData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDRAGANDDROPDATA", AV12DragAndDropData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDRAGANDDROPDATA", AV12DragAndDropData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFILTERCHANGEDDATA", AV15FilterChangedData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFILTERCHANGEDDATA", AV15FilterChangedData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vITEMEXPANDDATA", AV13ItemExpandData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vITEMEXPANDDATA", AV13ItemExpandData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vITEMCOLLAPSEDATA", AV14ItemCollapseData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vITEMCOLLAPSEDATA", AV14ItemCollapseData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vELEMENTSRETAILSALE", AV22ElementsRetailSale);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vELEMENTSRETAILSALE", AV22ElementsRetailSale);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPARAMETERSRETAILSALE", AV21ParametersRetailSale);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPARAMETERSRETAILSALE", AV21ParametersRetailSale);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vELEMENTSWHOLESALE", AV23ElementsWholeSale);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vELEMENTSWHOLESALE", AV23ElementsWholeSale);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPARAMETERSWHOLESALE", AV20ParametersWholeSale);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPARAMETERSWHOLESALE", AV20ParametersWholeSale);
         }
         GxWebStd.gx_hidden_field( context, "QVSALESTRHOWTIME_Objectname", StringUtil.RTrim( Qvsalestrhowtime_Objectname));
         GxWebStd.gx_hidden_field( context, "QVSALESPRODUCTTOP_Objectname", StringUtil.RTrim( Qvsalesproducttop_Objectname));
         GxWebStd.gx_hidden_field( context, "QVSALESSUPPLIERTOP_Objectname", StringUtil.RTrim( Qvsalessuppliertop_Objectname));
         GxWebStd.gx_hidden_field( context, "QVSALESRETAIL_Objectname", StringUtil.RTrim( Qvsalesretail_Objectname));
         GxWebStd.gx_hidden_field( context, "QVSALESRETAIL_Title", StringUtil.RTrim( Qvsalesretail_Title));
         GxWebStd.gx_hidden_field( context, "QVSALESPRODUCTLEAST_Objectname", StringUtil.RTrim( Qvsalesproductleast_Objectname));
         GxWebStd.gx_hidden_field( context, "QVSALESSUPPLIERLEAST_Objectname", StringUtil.RTrim( Qvsalessupplierleast_Objectname));
         GxWebStd.gx_hidden_field( context, "QVSALESWHOLESALE_Objectname", StringUtil.RTrim( Qvsaleswholesale_Objectname));
         GxWebStd.gx_hidden_field( context, "QVSALESWHOLESALE_Title", StringUtil.RTrim( Qvsaleswholesale_Title));
         GxWebStd.gx_hidden_field( context, "QVPURCHASESTHROWTIME_Objectname", StringUtil.RTrim( Qvpurchasesthrowtime_Objectname));
         GxWebStd.gx_hidden_field( context, "QVPURCHASESTOP_Objectname", StringUtil.RTrim( Qvpurchasestop_Objectname));
         GxWebStd.gx_hidden_field( context, "QUERYVIEWER2_Objectname", StringUtil.RTrim( Queryviewer2_Objectname));
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
            WE4J2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT4J2( ) ;
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
         return formatLink("wpstatisticsgraphs.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WPStatisticsGraphs" ;
      }

      public override string GetPgmdesc( )
      {
         return "WPStatistics Graphs" ;
      }

      protected void WB4J0( )
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
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Statistical Graphics", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WPStatisticsGraphs.htm");
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
            GxWebStd.gx_div_start( context, divTablefilters_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavType_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavType_Internalname, "Type", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavType, cmbavType_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV5Type), 4, 0)), 1, cmbavType_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavType.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,16);\"", "", false, 0, "HLP_WPStatisticsGraphs.htm");
            cmbavType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV5Type), 4, 0));
            AssignProp("", false, cmbavType_Internalname, "Values", (string)(cmbavType.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavFromdate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFromdate_Internalname, "From Date", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavFromdate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavFromdate_Internalname, context.localUtil.Format(AV6FromDate, "99/99/99"), context.localUtil.Format( AV6FromDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFromdate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFromdate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, false, "", "right", false, "", "HLP_WPStatisticsGraphs.htm");
            GxWebStd.gx_bitmap( context, edtavFromdate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavFromdate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WPStatisticsGraphs.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavTodate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTodate_Internalname, "To Date", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavTodate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTodate_Internalname, context.localUtil.Format(AV7ToDate, "99/99/99"), context.localUtil.Format( AV7ToDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,24);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTodate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTodate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, false, "", "right", false, "", "HLP_WPStatisticsGraphs.htm");
            GxWebStd.gx_bitmap( context, edtavTodate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTodate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WPStatisticsGraphs.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablegraphssales_Internalname, divTablegraphssales_Visible, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, divTablesalesthrowtime_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucQvsalestrhowtime.SetProperty("Elements", AV10Elements);
            ucQvsalestrhowtime.SetProperty("Parameters", AV8Parameters);
            ucQvsalestrhowtime.SetProperty("ObjectName", Qvsalestrhowtime_Objectname);
            ucQvsalestrhowtime.SetProperty("Title", Qvsalestrhowtime_Title);
            ucQvsalestrhowtime.SetProperty("ItemClickData", AV16ItemClickData);
            ucQvsalestrhowtime.SetProperty("ItemDoubleClickData", AV17ItemDoubleClickData);
            ucQvsalestrhowtime.SetProperty("DragAndDropData", AV12DragAndDropData);
            ucQvsalestrhowtime.SetProperty("FilterChangedData", AV15FilterChangedData);
            ucQvsalestrhowtime.SetProperty("ItemExpandData", AV13ItemExpandData);
            ucQvsalestrhowtime.SetProperty("ItemCollapseData", AV14ItemCollapseData);
            ucQvsalestrhowtime.Render(context, "queryviewer", Qvsalestrhowtime_Internalname, "QVSALESTRHOWTIMEContainer");
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
            GxWebStd.gx_div_start( context, divTablegraphsalesleft_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucQvsalesproducttop.SetProperty("Elements", AV10Elements);
            ucQvsalesproducttop.SetProperty("Parameters", AV8Parameters);
            ucQvsalesproducttop.SetProperty("ObjectName", Qvsalesproducttop_Objectname);
            ucQvsalesproducttop.SetProperty("Title", Qvsalesproducttop_Title);
            ucQvsalesproducttop.SetProperty("ItemClickData", AV16ItemClickData);
            ucQvsalesproducttop.SetProperty("ItemDoubleClickData", AV17ItemDoubleClickData);
            ucQvsalesproducttop.SetProperty("DragAndDropData", AV12DragAndDropData);
            ucQvsalesproducttop.SetProperty("FilterChangedData", AV15FilterChangedData);
            ucQvsalesproducttop.SetProperty("ItemExpandData", AV13ItemExpandData);
            ucQvsalesproducttop.SetProperty("ItemCollapseData", AV14ItemCollapseData);
            ucQvsalesproducttop.Render(context, "queryviewer", Qvsalesproducttop_Internalname, "QVSALESPRODUCTTOPContainer");
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
            /* User Defined Control */
            ucQvsalessuppliertop.SetProperty("Elements", AV10Elements);
            ucQvsalessuppliertop.SetProperty("Parameters", AV8Parameters);
            ucQvsalessuppliertop.SetProperty("ObjectName", Qvsalessuppliertop_Objectname);
            ucQvsalessuppliertop.SetProperty("Title", Qvsalessuppliertop_Title);
            ucQvsalessuppliertop.SetProperty("ItemClickData", AV16ItemClickData);
            ucQvsalessuppliertop.SetProperty("ItemDoubleClickData", AV17ItemDoubleClickData);
            ucQvsalessuppliertop.SetProperty("DragAndDropData", AV12DragAndDropData);
            ucQvsalessuppliertop.SetProperty("FilterChangedData", AV15FilterChangedData);
            ucQvsalessuppliertop.SetProperty("ItemExpandData", AV13ItemExpandData);
            ucQvsalessuppliertop.SetProperty("ItemCollapseData", AV14ItemCollapseData);
            ucQvsalessuppliertop.Render(context, "queryviewer", Qvsalessuppliertop_Internalname, "QVSALESSUPPLIERTOPContainer");
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
            /* User Defined Control */
            ucQvsalesretail.SetProperty("Elements", AV22ElementsRetailSale);
            ucQvsalesretail.SetProperty("Parameters", AV21ParametersRetailSale);
            ucQvsalesretail.SetProperty("ObjectName", Qvsalesretail_Objectname);
            ucQvsalesretail.SetProperty("Title", Qvsalesretail_Title);
            ucQvsalesretail.SetProperty("ItemClickData", AV16ItemClickData);
            ucQvsalesretail.SetProperty("ItemDoubleClickData", AV17ItemDoubleClickData);
            ucQvsalesretail.SetProperty("DragAndDropData", AV12DragAndDropData);
            ucQvsalesretail.SetProperty("FilterChangedData", AV15FilterChangedData);
            ucQvsalesretail.SetProperty("ItemExpandData", AV13ItemExpandData);
            ucQvsalesretail.SetProperty("ItemCollapseData", AV14ItemCollapseData);
            ucQvsalesretail.Render(context, "queryviewer", Qvsalesretail_Internalname, "QVSALESRETAILContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablegraphsalesrigth_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucQvsalesproductleast.SetProperty("Elements", AV10Elements);
            ucQvsalesproductleast.SetProperty("Parameters", AV8Parameters);
            ucQvsalesproductleast.SetProperty("ObjectName", Qvsalesproductleast_Objectname);
            ucQvsalesproductleast.SetProperty("Title", Qvsalesproductleast_Title);
            ucQvsalesproductleast.SetProperty("ItemClickData", AV16ItemClickData);
            ucQvsalesproductleast.SetProperty("ItemDoubleClickData", AV17ItemDoubleClickData);
            ucQvsalesproductleast.SetProperty("DragAndDropData", AV12DragAndDropData);
            ucQvsalesproductleast.SetProperty("FilterChangedData", AV15FilterChangedData);
            ucQvsalesproductleast.SetProperty("ItemExpandData", AV13ItemExpandData);
            ucQvsalesproductleast.SetProperty("ItemCollapseData", AV14ItemCollapseData);
            ucQvsalesproductleast.Render(context, "queryviewer", Qvsalesproductleast_Internalname, "QVSALESPRODUCTLEASTContainer");
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
            /* User Defined Control */
            ucQvsalessupplierleast.SetProperty("Elements", AV10Elements);
            ucQvsalessupplierleast.SetProperty("Parameters", AV8Parameters);
            ucQvsalessupplierleast.SetProperty("ObjectName", Qvsalessupplierleast_Objectname);
            ucQvsalessupplierleast.SetProperty("Title", Qvsalessupplierleast_Title);
            ucQvsalessupplierleast.SetProperty("ItemClickData", AV16ItemClickData);
            ucQvsalessupplierleast.SetProperty("ItemDoubleClickData", AV17ItemDoubleClickData);
            ucQvsalessupplierleast.SetProperty("DragAndDropData", AV12DragAndDropData);
            ucQvsalessupplierleast.SetProperty("FilterChangedData", AV15FilterChangedData);
            ucQvsalessupplierleast.SetProperty("ItemExpandData", AV13ItemExpandData);
            ucQvsalessupplierleast.SetProperty("ItemCollapseData", AV14ItemCollapseData);
            ucQvsalessupplierleast.Render(context, "queryviewer", Qvsalessupplierleast_Internalname, "QVSALESSUPPLIERLEASTContainer");
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
            /* User Defined Control */
            ucQvsaleswholesale.SetProperty("Elements", AV23ElementsWholeSale);
            ucQvsaleswholesale.SetProperty("Parameters", AV20ParametersWholeSale);
            ucQvsaleswholesale.SetProperty("ObjectName", Qvsaleswholesale_Objectname);
            ucQvsaleswholesale.SetProperty("Title", Qvsaleswholesale_Title);
            ucQvsaleswholesale.SetProperty("ItemClickData", AV16ItemClickData);
            ucQvsaleswholesale.SetProperty("ItemDoubleClickData", AV17ItemDoubleClickData);
            ucQvsaleswholesale.SetProperty("DragAndDropData", AV12DragAndDropData);
            ucQvsaleswholesale.SetProperty("FilterChangedData", AV15FilterChangedData);
            ucQvsaleswholesale.SetProperty("ItemExpandData", AV13ItemExpandData);
            ucQvsaleswholesale.SetProperty("ItemCollapseData", AV14ItemCollapseData);
            ucQvsaleswholesale.Render(context, "queryviewer", Qvsaleswholesale_Internalname, "QVSALESWHOLESALEContainer");
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
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablegraphspurhcases_Internalname, divTablegraphspurhcases_Visible, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, divTablepurchasesthrowtime_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucQvpurchasesthrowtime.SetProperty("Elements", AV10Elements);
            ucQvpurchasesthrowtime.SetProperty("Parameters", AV8Parameters);
            ucQvpurchasesthrowtime.SetProperty("ObjectName", Qvpurchasesthrowtime_Objectname);
            ucQvpurchasesthrowtime.SetProperty("Title", Qvpurchasesthrowtime_Title);
            ucQvpurchasesthrowtime.SetProperty("ItemClickData", AV16ItemClickData);
            ucQvpurchasesthrowtime.SetProperty("ItemDoubleClickData", AV17ItemDoubleClickData);
            ucQvpurchasesthrowtime.SetProperty("DragAndDropData", AV12DragAndDropData);
            ucQvpurchasesthrowtime.SetProperty("FilterChangedData", AV15FilterChangedData);
            ucQvpurchasesthrowtime.SetProperty("ItemExpandData", AV13ItemExpandData);
            ucQvpurchasesthrowtime.SetProperty("ItemCollapseData", AV14ItemCollapseData);
            ucQvpurchasesthrowtime.Render(context, "queryviewer", Qvpurchasesthrowtime_Internalname, "QVPURCHASESTHROWTIMEContainer");
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
            GxWebStd.gx_div_start( context, divTablegraphspurchasesleft_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucQvpurchasestop.SetProperty("Elements", AV10Elements);
            ucQvpurchasestop.SetProperty("Parameters", AV8Parameters);
            ucQvpurchasestop.SetProperty("ObjectName", Qvpurchasestop_Objectname);
            ucQvpurchasestop.SetProperty("Title", Qvpurchasestop_Title);
            ucQvpurchasestop.SetProperty("ItemClickData", AV16ItemClickData);
            ucQvpurchasestop.SetProperty("ItemDoubleClickData", AV17ItemDoubleClickData);
            ucQvpurchasestop.SetProperty("DragAndDropData", AV12DragAndDropData);
            ucQvpurchasestop.SetProperty("FilterChangedData", AV15FilterChangedData);
            ucQvpurchasestop.SetProperty("ItemExpandData", AV13ItemExpandData);
            ucQvpurchasestop.SetProperty("ItemCollapseData", AV14ItemCollapseData);
            ucQvpurchasestop.Render(context, "queryviewer", Qvpurchasestop_Internalname, "QVPURCHASESTOPContainer");
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
            /* User Defined Control */
            ucQueryviewer2.SetProperty("Elements", AV10Elements);
            ucQueryviewer2.SetProperty("Parameters", AV8Parameters);
            ucQueryviewer2.SetProperty("ObjectName", Queryviewer2_Objectname);
            ucQueryviewer2.SetProperty("Title", Queryviewer2_Title);
            ucQueryviewer2.SetProperty("ItemClickData", AV16ItemClickData);
            ucQueryviewer2.SetProperty("ItemDoubleClickData", AV17ItemDoubleClickData);
            ucQueryviewer2.SetProperty("DragAndDropData", AV12DragAndDropData);
            ucQueryviewer2.SetProperty("FilterChangedData", AV15FilterChangedData);
            ucQueryviewer2.SetProperty("ItemExpandData", AV13ItemExpandData);
            ucQueryviewer2.SetProperty("ItemCollapseData", AV14ItemCollapseData);
            ucQueryviewer2.Render(context, "queryviewer", Queryviewer2_Internalname, "QUERYVIEWER2Container");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablegraphspurchasesright_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucQueryviewer3.SetProperty("Elements", AV10Elements);
            ucQueryviewer3.SetProperty("Parameters", AV8Parameters);
            ucQueryviewer3.SetProperty("Title", Queryviewer3_Title);
            ucQueryviewer3.SetProperty("ItemClickData", AV16ItemClickData);
            ucQueryviewer3.SetProperty("ItemDoubleClickData", AV17ItemDoubleClickData);
            ucQueryviewer3.SetProperty("DragAndDropData", AV12DragAndDropData);
            ucQueryviewer3.SetProperty("FilterChangedData", AV15FilterChangedData);
            ucQueryviewer3.SetProperty("ItemExpandData", AV13ItemExpandData);
            ucQueryviewer3.SetProperty("ItemCollapseData", AV14ItemCollapseData);
            ucQueryviewer3.Render(context, "queryviewer", Queryviewer3_Internalname, "QUERYVIEWER3Container");
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
            /* User Defined Control */
            ucQueryviewer4.SetProperty("Elements", AV10Elements);
            ucQueryviewer4.SetProperty("Parameters", AV8Parameters);
            ucQueryviewer4.SetProperty("Title", Queryviewer4_Title);
            ucQueryviewer4.SetProperty("ItemClickData", AV16ItemClickData);
            ucQueryviewer4.SetProperty("ItemDoubleClickData", AV17ItemDoubleClickData);
            ucQueryviewer4.SetProperty("DragAndDropData", AV12DragAndDropData);
            ucQueryviewer4.SetProperty("FilterChangedData", AV15FilterChangedData);
            ucQueryviewer4.SetProperty("ItemExpandData", AV13ItemExpandData);
            ucQueryviewer4.SetProperty("ItemCollapseData", AV14ItemCollapseData);
            ucQueryviewer4.Render(context, "queryviewer", Queryviewer4_Internalname, "QUERYVIEWER4Container");
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
            context.WriteHtmlText( "<hr/>") ;
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

      protected void START4J2( )
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
            Form.Meta.addItem("description", "WPStatistics Graphs", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP4J0( ) ;
      }

      protected void WS4J2( )
      {
         START4J2( ) ;
         EVT4J2( ) ;
      }

      protected void EVT4J2( )
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
                              E114J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VFROMDATE.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E124J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VTODATE.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E134J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E144J2 ();
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

      protected void WE4J2( )
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

      protected void PA4J2( )
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
               GX_FocusControl = cmbavType_Internalname;
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
         if ( cmbavType.ItemCount > 0 )
         {
            AV5Type = (short)(Math.Round(NumberUtil.Val( cmbavType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV5Type), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV5Type", StringUtil.LTrimStr( (decimal)(AV5Type), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV5Type), 4, 0));
            AssignProp("", false, cmbavType_Internalname, "Values", cmbavType.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF4J2( ) ;
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

      protected void RF4J2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E144J2 ();
            WB4J0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes4J2( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4J0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E114J2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vELEMENTS"), AV10Elements);
            ajax_req_read_hidden_sdt(cgiGet( "vPARAMETERS"), AV8Parameters);
            ajax_req_read_hidden_sdt(cgiGet( "vITEMCLICKDATA"), AV16ItemClickData);
            ajax_req_read_hidden_sdt(cgiGet( "vITEMDOUBLECLICKDATA"), AV17ItemDoubleClickData);
            ajax_req_read_hidden_sdt(cgiGet( "vDRAGANDDROPDATA"), AV12DragAndDropData);
            ajax_req_read_hidden_sdt(cgiGet( "vFILTERCHANGEDDATA"), AV15FilterChangedData);
            ajax_req_read_hidden_sdt(cgiGet( "vITEMEXPANDDATA"), AV13ItemExpandData);
            ajax_req_read_hidden_sdt(cgiGet( "vITEMCOLLAPSEDATA"), AV14ItemCollapseData);
            ajax_req_read_hidden_sdt(cgiGet( "vELEMENTSRETAILSALE"), AV22ElementsRetailSale);
            ajax_req_read_hidden_sdt(cgiGet( "vPARAMETERSRETAILSALE"), AV21ParametersRetailSale);
            ajax_req_read_hidden_sdt(cgiGet( "vELEMENTSWHOLESALE"), AV23ElementsWholeSale);
            ajax_req_read_hidden_sdt(cgiGet( "vPARAMETERSWHOLESALE"), AV20ParametersWholeSale);
            /* Read saved values. */
            Qvsalestrhowtime_Objectname = cgiGet( "QVSALESTRHOWTIME_Objectname");
            Qvsalesproducttop_Objectname = cgiGet( "QVSALESPRODUCTTOP_Objectname");
            Qvsalessuppliertop_Objectname = cgiGet( "QVSALESSUPPLIERTOP_Objectname");
            Qvsalesretail_Objectname = cgiGet( "QVSALESRETAIL_Objectname");
            Qvsalesretail_Title = cgiGet( "QVSALESRETAIL_Title");
            Qvsalesproductleast_Objectname = cgiGet( "QVSALESPRODUCTLEAST_Objectname");
            Qvsalessupplierleast_Objectname = cgiGet( "QVSALESSUPPLIERLEAST_Objectname");
            Qvsaleswholesale_Objectname = cgiGet( "QVSALESWHOLESALE_Objectname");
            Qvsaleswholesale_Title = cgiGet( "QVSALESWHOLESALE_Title");
            Qvpurchasesthrowtime_Objectname = cgiGet( "QVPURCHASESTHROWTIME_Objectname");
            Qvpurchasestop_Objectname = cgiGet( "QVPURCHASESTOP_Objectname");
            Queryviewer2_Objectname = cgiGet( "QUERYVIEWER2_Objectname");
            /* Read variables values. */
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
         E114J2 ();
         if (returnInSub) return;
      }

      protected void E114J2( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtSDTContextSession1 = new GeneXus.Programs.general.ui.SdtSDTContextSession();
         new checkauthentication(context ).execute( out  GXt_SdtSDTContextSession1) ;
         AV5Type = 1;
         AssignAttri("", false, "AV5Type", StringUtil.LTrimStr( (decimal)(AV5Type), 4, 0));
         AV7ToDate = DateTimeUtil.ServerDate( context, pr_default);
         AssignAttri("", false, "AV7ToDate", context.localUtil.Format(AV7ToDate, "99/99/99"));
         AV6FromDate = DateTimeUtil.AddMth( AV7ToDate, -6);
         AssignAttri("", false, "AV6FromDate", context.localUtil.Format(AV6FromDate, "99/99/99"));
         /* Execute user subroutine: 'CHARGEQUERIES' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'SHOWTABLES' */
         S122 ();
         if (returnInSub) return;
      }

      protected void E124J2( )
      {
         /* Fromdate_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHARGEQUERIES' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV8Parameters", AV8Parameters);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20ParametersWholeSale", AV20ParametersWholeSale);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ParametersRetailSale", AV21ParametersRetailSale);
      }

      protected void E134J2( )
      {
         /* Todate_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHARGEQUERIES' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV8Parameters", AV8Parameters);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV20ParametersWholeSale", AV20ParametersWholeSale);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV21ParametersRetailSale", AV21ParametersRetailSale);
      }

      protected void S122( )
      {
         /* 'SHOWTABLES' Routine */
         returnInSub = false;
         if ( AV5Type == 1 )
         {
            divTablegraphspurhcases_Visible = 1;
            AssignProp("", false, divTablegraphspurhcases_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablegraphspurhcases_Visible), 5, 0), true);
            divTablegraphssales_Visible = 1;
            AssignProp("", false, divTablegraphssales_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablegraphssales_Visible), 5, 0), true);
         }
         else if ( AV5Type == 2 )
         {
            divTablegraphspurhcases_Visible = 0;
            AssignProp("", false, divTablegraphspurhcases_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablegraphspurhcases_Visible), 5, 0), true);
            divTablegraphssales_Visible = 1;
            AssignProp("", false, divTablegraphssales_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablegraphssales_Visible), 5, 0), true);
         }
         else if ( AV5Type == 3 )
         {
            divTablegraphspurhcases_Visible = 1;
            AssignProp("", false, divTablegraphspurhcases_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablegraphspurhcases_Visible), 5, 0), true);
            divTablegraphssales_Visible = 0;
            AssignProp("", false, divTablegraphssales_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablegraphssales_Visible), 5, 0), true);
         }
         else
         {
            divTablegraphspurhcases_Visible = 0;
            AssignProp("", false, divTablegraphspurhcases_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablegraphspurhcases_Visible), 5, 0), true);
            divTablegraphssales_Visible = 0;
            AssignProp("", false, divTablegraphssales_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablegraphssales_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'CHARGEQUERIES' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHARGEPARAMETERS' */
         S132 ();
         if (returnInSub) return;
      }

      protected void S132( )
      {
         /* 'CHARGEPARAMETERS' Routine */
         returnInSub = false;
         AV18Year = 0;
         AV19Month = 0;
         AV8Parameters.Clear();
         AV9Parameter = new GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter(context);
         AV9Parameter.gxTpr_Name = "Year";
         AV9Parameter.gxTpr_Value = StringUtil.Str( (decimal)(AV18Year), 4, 0);
         AV8Parameters.Add(AV9Parameter, 0);
         AV20ParametersWholeSale.Add(AV9Parameter, 0);
         AV9Parameter = new GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter(context);
         AV9Parameter.gxTpr_Name = "Month";
         AV9Parameter.gxTpr_Value = StringUtil.Str( (decimal)(AV19Month), 4, 0);
         AV8Parameters.Add(AV9Parameter, 0);
         AV20ParametersWholeSale.Add(AV9Parameter, 0);
         AV9Parameter = new GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter(context);
         AV9Parameter.gxTpr_Name = "FromDate";
         AV9Parameter.gxTpr_Value = context.localUtil.DToC( AV6FromDate, 1, "/");
         AV8Parameters.Add(AV9Parameter, 0);
         AV20ParametersWholeSale.Add(AV9Parameter, 0);
         AV9Parameter = new GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter(context);
         AV9Parameter.gxTpr_Name = "ToDate";
         AV9Parameter.gxTpr_Value = context.localUtil.DToC( AV7ToDate, 1, "/");
         AV8Parameters.Add(AV9Parameter, 0);
         AV20ParametersWholeSale.Add(AV9Parameter, 0);
         AV9Parameter = new GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter(context);
         AV9Parameter.gxTpr_Name = "Type";
         AV9Parameter.gxTpr_Value = "True";
         AV8Parameters.Add(AV9Parameter, 0);
         AV20ParametersWholeSale.Add(AV9Parameter, 0);
         AV9Parameter = new GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter(context);
         AV9Parameter.gxTpr_Name = "Type";
         AV9Parameter.gxTpr_Value = "False";
         AV8Parameters.Add(AV9Parameter, 0);
         AV21ParametersRetailSale.Add(AV9Parameter, 0);
      }

      protected void nextLoad( )
      {
      }

      protected void E144J2( )
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
         PA4J2( ) ;
         WS4J2( ) ;
         WE4J2( ) ;
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
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024125234359", true, true);
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
         context.AddJavascriptSource("wpstatisticsgraphs.js", "?2024125234359", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavType.Name = "vTYPE";
         cmbavType.WebTags = "";
         cmbavType.addItem("1", "All", 0);
         cmbavType.addItem("2", "Sales", 0);
         cmbavType.addItem("3", "Purchases", 0);
         if ( cmbavType.ItemCount > 0 )
         {
            AV5Type = (short)(Math.Round(NumberUtil.Val( cmbavType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV5Type), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV5Type", StringUtil.LTrimStr( (decimal)(AV5Type), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTextblock1_Internalname = "TEXTBLOCK1";
         cmbavType_Internalname = "vTYPE";
         edtavFromdate_Internalname = "vFROMDATE";
         edtavTodate_Internalname = "vTODATE";
         divTablefilters_Internalname = "TABLEFILTERS";
         Qvsalestrhowtime_Internalname = "QVSALESTRHOWTIME";
         divTablesalesthrowtime_Internalname = "TABLESALESTHROWTIME";
         Qvsalesproducttop_Internalname = "QVSALESPRODUCTTOP";
         Qvsalessuppliertop_Internalname = "QVSALESSUPPLIERTOP";
         Qvsalesretail_Internalname = "QVSALESRETAIL";
         divTablegraphsalesleft_Internalname = "TABLEGRAPHSALESLEFT";
         Qvsalesproductleast_Internalname = "QVSALESPRODUCTLEAST";
         Qvsalessupplierleast_Internalname = "QVSALESSUPPLIERLEAST";
         Qvsaleswholesale_Internalname = "QVSALESWHOLESALE";
         divTablegraphsalesrigth_Internalname = "TABLEGRAPHSALESRIGTH";
         divTablegraphssales_Internalname = "TABLEGRAPHSSALES";
         Qvpurchasesthrowtime_Internalname = "QVPURCHASESTHROWTIME";
         divTablepurchasesthrowtime_Internalname = "TABLEPURCHASESTHROWTIME";
         Qvpurchasestop_Internalname = "QVPURCHASESTOP";
         Queryviewer2_Internalname = "QUERYVIEWER2";
         divTablegraphspurchasesleft_Internalname = "TABLEGRAPHSPURCHASESLEFT";
         Queryviewer3_Internalname = "QUERYVIEWER3";
         Queryviewer4_Internalname = "QUERYVIEWER4";
         divTablegraphspurchasesright_Internalname = "TABLEGRAPHSPURCHASESRIGHT";
         divTablegraphspurhcases_Internalname = "TABLEGRAPHSPURHCASES";
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
         Queryviewer4_Title = "";
         Queryviewer3_Title = "";
         Queryviewer2_Title = "";
         Qvpurchasestop_Title = "Top Products Purchased";
         Qvpurchasesthrowtime_Title = "Total Raised per Product";
         divTablegraphspurhcases_Visible = 1;
         Qvsalessupplierleast_Title = "Top Raised for Supplier";
         Qvsalesproductleast_Title = "Least Products Sold";
         Qvsalessuppliertop_Title = "Top Raised for Supplier";
         Qvsalesproducttop_Title = "Top Products Sold";
         Qvsalestrhowtime_Title = "Total Raised per Product";
         divTablegraphssales_Visible = 1;
         edtavTodate_Jsonclick = "";
         edtavTodate_Enabled = 1;
         edtavFromdate_Jsonclick = "";
         edtavFromdate_Enabled = 1;
         cmbavType_Jsonclick = "";
         cmbavType.Enabled = 1;
         Queryviewer2_Objectname = "QSupplierPurchaseOrderStatistic";
         Qvpurchasestop_Objectname = "QStatisticsProductTopOrder";
         Qvpurchasesthrowtime_Objectname = "QPurchaseThrowTime";
         Qvsaleswholesale_Title = "Wholesale Sales ";
         Qvsaleswholesale_Objectname = "QStatisticsProductSalesRetailAndWholesale";
         Qvsalessupplierleast_Objectname = "QStatisticsSupplierLeastSold";
         Qvsalesproductleast_Objectname = "QStatisticsProductLeastSold";
         Qvsalesretail_Title = "Retail Sales";
         Qvsalesretail_Objectname = "QStatisticsProductSalesRetailAndWholesale";
         Qvsalessuppliertop_Objectname = "QStatisticsSupplierTopSold";
         Qvsalesproducttop_Objectname = "QStatisticsProductTopSold";
         Qvsalestrhowtime_Objectname = "QSalesThrowTime";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "WPStatistics Graphs";
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
         setEventMetadata("VFROMDATE.CONTROLVALUECHANGED","{handler:'E124J2',iparms:[{av:'AV20ParametersWholeSale',fld:'vPARAMETERSWHOLESALE',pic:''},{av:'AV6FromDate',fld:'vFROMDATE',pic:''},{av:'AV7ToDate',fld:'vTODATE',pic:''},{av:'AV21ParametersRetailSale',fld:'vPARAMETERSRETAILSALE',pic:''}]");
         setEventMetadata("VFROMDATE.CONTROLVALUECHANGED",",oparms:[{av:'AV8Parameters',fld:'vPARAMETERS',pic:''},{av:'AV20ParametersWholeSale',fld:'vPARAMETERSWHOLESALE',pic:''},{av:'AV21ParametersRetailSale',fld:'vPARAMETERSRETAILSALE',pic:''}]}");
         setEventMetadata("VTODATE.CONTROLVALUECHANGED","{handler:'E134J2',iparms:[{av:'AV20ParametersWholeSale',fld:'vPARAMETERSWHOLESALE',pic:''},{av:'AV6FromDate',fld:'vFROMDATE',pic:''},{av:'AV7ToDate',fld:'vTODATE',pic:''},{av:'AV21ParametersRetailSale',fld:'vPARAMETERSRETAILSALE',pic:''}]");
         setEventMetadata("VTODATE.CONTROLVALUECHANGED",",oparms:[{av:'AV8Parameters',fld:'vPARAMETERS',pic:''},{av:'AV20ParametersWholeSale',fld:'vPARAMETERSWHOLESALE',pic:''},{av:'AV21ParametersRetailSale',fld:'vPARAMETERSRETAILSALE',pic:''}]}");
         setEventMetadata("VALIDV_FROMDATE","{handler:'Validv_Fromdate',iparms:[]");
         setEventMetadata("VALIDV_FROMDATE",",oparms:[]}");
         setEventMetadata("VALIDV_TODATE","{handler:'Validv_Todate',iparms:[]");
         setEventMetadata("VALIDV_TODATE",",oparms:[]}");
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
         AV10Elements = new GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element>( context, "Element", "GeneXus.Reporting");
         AV8Parameters = new GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter>( context, "Parameter", "GeneXus.Reporting");
         AV16ItemClickData = new GeneXus.Programs.genexusreporting.SdtQueryViewerItemClickData(context);
         AV17ItemDoubleClickData = new GeneXus.Programs.genexusreporting.SdtQueryViewerItemDoubleClickData(context);
         AV12DragAndDropData = new GeneXus.Programs.genexusreporting.SdtQueryViewerDragAndDropData(context);
         AV15FilterChangedData = new GeneXus.Programs.genexusreporting.SdtQueryViewerFilterChangedData(context);
         AV13ItemExpandData = new GeneXus.Programs.genexusreporting.SdtQueryViewerItemExpandData(context);
         AV14ItemCollapseData = new GeneXus.Programs.genexusreporting.SdtQueryViewerItemCollapseData(context);
         AV22ElementsRetailSale = new GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element>( context, "Element", "GeneXus.Reporting");
         AV21ParametersRetailSale = new GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter>( context, "Parameter", "GeneXus.Reporting");
         AV23ElementsWholeSale = new GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element>( context, "Element", "GeneXus.Reporting");
         AV20ParametersWholeSale = new GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter>( context, "Parameter", "GeneXus.Reporting");
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTextblock1_Jsonclick = "";
         TempTags = "";
         AV6FromDate = DateTime.MinValue;
         AV7ToDate = DateTime.MinValue;
         ucQvsalestrhowtime = new GXUserControl();
         ucQvsalesproducttop = new GXUserControl();
         ucQvsalessuppliertop = new GXUserControl();
         ucQvsalesretail = new GXUserControl();
         ucQvsalesproductleast = new GXUserControl();
         ucQvsalessupplierleast = new GXUserControl();
         ucQvsaleswholesale = new GXUserControl();
         ucQvpurchasesthrowtime = new GXUserControl();
         ucQvpurchasestop = new GXUserControl();
         ucQueryviewer2 = new GXUserControl();
         ucQueryviewer3 = new GXUserControl();
         ucQueryviewer4 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXt_SdtSDTContextSession1 = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         AV9Parameter = new GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpstatisticsgraphs__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV5Type ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV18Year ;
      private short AV19Month ;
      private short nGXWrapped ;
      private int edtavFromdate_Enabled ;
      private int edtavTodate_Enabled ;
      private int divTablegraphssales_Visible ;
      private int divTablegraphspurhcases_Visible ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Qvsalestrhowtime_Objectname ;
      private string Qvsalesproducttop_Objectname ;
      private string Qvsalessuppliertop_Objectname ;
      private string Qvsalesretail_Objectname ;
      private string Qvsalesretail_Title ;
      private string Qvsalesproductleast_Objectname ;
      private string Qvsalessupplierleast_Objectname ;
      private string Qvsaleswholesale_Objectname ;
      private string Qvsaleswholesale_Title ;
      private string Qvpurchasesthrowtime_Objectname ;
      private string Qvpurchasestop_Objectname ;
      private string Queryviewer2_Objectname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string divTablefilters_Internalname ;
      private string cmbavType_Internalname ;
      private string TempTags ;
      private string cmbavType_Jsonclick ;
      private string edtavFromdate_Internalname ;
      private string edtavFromdate_Jsonclick ;
      private string edtavTodate_Internalname ;
      private string edtavTodate_Jsonclick ;
      private string divTablegraphssales_Internalname ;
      private string divTablesalesthrowtime_Internalname ;
      private string Qvsalestrhowtime_Title ;
      private string Qvsalestrhowtime_Internalname ;
      private string divTablegraphsalesleft_Internalname ;
      private string Qvsalesproducttop_Title ;
      private string Qvsalesproducttop_Internalname ;
      private string Qvsalessuppliertop_Title ;
      private string Qvsalessuppliertop_Internalname ;
      private string Qvsalesretail_Internalname ;
      private string divTablegraphsalesrigth_Internalname ;
      private string Qvsalesproductleast_Title ;
      private string Qvsalesproductleast_Internalname ;
      private string Qvsalessupplierleast_Title ;
      private string Qvsalessupplierleast_Internalname ;
      private string Qvsaleswholesale_Internalname ;
      private string divTablegraphspurhcases_Internalname ;
      private string divTablepurchasesthrowtime_Internalname ;
      private string Qvpurchasesthrowtime_Title ;
      private string Qvpurchasesthrowtime_Internalname ;
      private string divTablegraphspurchasesleft_Internalname ;
      private string Qvpurchasestop_Title ;
      private string Qvpurchasestop_Internalname ;
      private string Queryviewer2_Title ;
      private string Queryviewer2_Internalname ;
      private string divTablegraphspurchasesright_Internalname ;
      private string Queryviewer3_Title ;
      private string Queryviewer3_Internalname ;
      private string Queryviewer4_Title ;
      private string Queryviewer4_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private DateTime AV6FromDate ;
      private DateTime AV7ToDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private GXUserControl ucQvsalestrhowtime ;
      private GXUserControl ucQvsalesproducttop ;
      private GXUserControl ucQvsalessuppliertop ;
      private GXUserControl ucQvsalesretail ;
      private GXUserControl ucQvsalesproductleast ;
      private GXUserControl ucQvsalessupplierleast ;
      private GXUserControl ucQvsaleswholesale ;
      private GXUserControl ucQvpurchasesthrowtime ;
      private GXUserControl ucQvpurchasestop ;
      private GXUserControl ucQueryviewer2 ;
      private GXUserControl ucQueryviewer3 ;
      private GXUserControl ucQueryviewer4 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavType ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter> AV8Parameters ;
      private GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter> AV21ParametersRetailSale ;
      private GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter> AV20ParametersWholeSale ;
      private GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element> AV10Elements ;
      private GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element> AV22ElementsRetailSale ;
      private GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element> AV23ElementsWholeSale ;
      private GXWebForm Form ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter AV9Parameter ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerDragAndDropData AV12DragAndDropData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerItemExpandData AV13ItemExpandData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerItemCollapseData AV14ItemCollapseData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerFilterChangedData AV15FilterChangedData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerItemClickData AV16ItemClickData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerItemDoubleClickData AV17ItemDoubleClickData ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession GXt_SdtSDTContextSession1 ;
   }

   public class wpstatisticsgraphs__default : DataStoreHelperBase, IDataStoreHelper
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
