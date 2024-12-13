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
   public class wcstatisticsproductstop : GXWebComponent
   {
      public wcstatisticsproductstop( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("mtaKB", true);
         }
      }

      public wcstatisticsproductstop( IGxContext context )
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

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
         cmbavYear = new GXCombobox();
         cmbavMonth = new GXCombobox();
         cmbavOption = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
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
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA3V2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               WS3V2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( "WCStatistics Products Top") ;
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
         }
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
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
            context.WriteHtmlText( "<body ") ;
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wcstatisticsproductstop.aspx") +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vELEMENTS", AV7Elements);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vELEMENTS", AV7Elements);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vPARAMETERS", AV5Parameters);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vPARAMETERS", AV5Parameters);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vITEMCLICKDATA", AV13ItemClickData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vITEMCLICKDATA", AV13ItemClickData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vITEMDOUBLECLICKDATA", AV14ItemDoubleClickData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vITEMDOUBLECLICKDATA", AV14ItemDoubleClickData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDRAGANDDROPDATA", AV9DragAndDropData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDRAGANDDROPDATA", AV9DragAndDropData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vFILTERCHANGEDDATA", AV12FilterChangedData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vFILTERCHANGEDDATA", AV12FilterChangedData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vITEMEXPANDDATA", AV10ItemExpandData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vITEMEXPANDDATA", AV10ItemExpandData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vITEMCOLLAPSEDATA", AV11ItemCollapseData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vITEMCOLLAPSEDATA", AV11ItemCollapseData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vMONTHS", AV24Months);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vMONTHS", AV24Months);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"QUERYVIEWERSALE_Objectname", StringUtil.RTrim( Queryviewersale_Objectname));
         GxWebStd.gx_hidden_field( context, sPrefix+"QUERYVIEWERSALE_Type", StringUtil.RTrim( Queryviewersale_Type));
         GxWebStd.gx_hidden_field( context, sPrefix+"QUERYVIEWERSALE_Charttype", StringUtil.RTrim( Queryviewersale_Charttype));
         GxWebStd.gx_hidden_field( context, sPrefix+"QUERYVIEWERSALE_Visible", StringUtil.BoolToStr( Queryviewersale_Visible));
         GxWebStd.gx_hidden_field( context, sPrefix+"QUERYVIEWERPURCHASE_Objectname", StringUtil.RTrim( Queryviewerpurchase_Objectname));
         GxWebStd.gx_hidden_field( context, sPrefix+"QUERYVIEWERPURCHASE_Charttype", StringUtil.RTrim( Queryviewerpurchase_Charttype));
         GxWebStd.gx_hidden_field( context, sPrefix+"QUERYVIEWERPURCHASE_Visible", StringUtil.BoolToStr( Queryviewerpurchase_Visible));
      }

      protected void RenderHtmlCloseForm3V2( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "WCStatisticsProductsTop" ;
      }

      public override string GetPgmdesc( )
      {
         return "WCStatistics Products Top" ;
      }

      protected void WB3V0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wcstatisticsproductstop.aspx");
               context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
               context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
               context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
               context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable2_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavYear_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavYear_Internalname, "Year", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavYear, cmbavYear_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV16Year), 4, 0)), 1, cmbavYear_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavYear.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,14);\"", "", false, 0, "HLP_WCStatisticsProductsTop.htm");
            cmbavYear.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16Year), 4, 0));
            AssignProp(sPrefix, false, cmbavYear_Internalname, "Values", (string)(cmbavYear.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavMonth_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavMonth_Internalname, "Month", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavMonth, cmbavMonth_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV15Month), 4, 0)), 1, cmbavMonth_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavMonth.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,18);\"", "", false, 0, "HLP_WCStatisticsProductsTop.htm");
            cmbavMonth.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV15Month), 4, 0));
            AssignProp(sPrefix, false, cmbavMonth_Internalname, "Values", (string)(cmbavMonth.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavOption_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavOption_Internalname, "Option", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavOption, cmbavOption_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV30Option), 4, 0)), 1, cmbavOption_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavOption.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "", false, 0, "HLP_WCStatisticsProductsTop.htm");
            cmbavOption.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30Option), 4, 0));
            AssignProp(sPrefix, false, cmbavOption_Internalname, "Values", (string)(cmbavOption.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divTable3_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* User Defined Control */
            ucQueryviewersale.SetProperty("Elements", AV7Elements);
            ucQueryviewersale.SetProperty("Parameters", AV5Parameters);
            ucQueryviewersale.SetProperty("ObjectName", Queryviewersale_Objectname);
            ucQueryviewersale.SetProperty("Type", Queryviewersale_Type);
            ucQueryviewersale.SetProperty("Title", Queryviewersale_Title);
            ucQueryviewersale.SetProperty("ChartType", Queryviewersale_Charttype);
            ucQueryviewersale.SetProperty("ItemClickData", AV13ItemClickData);
            ucQueryviewersale.SetProperty("ItemDoubleClickData", AV14ItemDoubleClickData);
            ucQueryviewersale.SetProperty("DragAndDropData", AV9DragAndDropData);
            ucQueryviewersale.SetProperty("FilterChangedData", AV12FilterChangedData);
            ucQueryviewersale.SetProperty("ItemExpandData", AV10ItemExpandData);
            ucQueryviewersale.SetProperty("ItemCollapseData", AV11ItemCollapseData);
            ucQueryviewersale.Render(context, "queryviewer", Queryviewersale_Internalname, sPrefix+"QUERYVIEWERSALEContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* User Defined Control */
            ucQueryviewerpurchase.SetProperty("Elements", AV7Elements);
            ucQueryviewerpurchase.SetProperty("Parameters", AV5Parameters);
            ucQueryviewerpurchase.SetProperty("ObjectName", Queryviewerpurchase_Objectname);
            ucQueryviewerpurchase.SetProperty("Title", Queryviewerpurchase_Title);
            ucQueryviewerpurchase.SetProperty("ChartType", Queryviewerpurchase_Charttype);
            ucQueryviewerpurchase.SetProperty("ItemClickData", AV13ItemClickData);
            ucQueryviewerpurchase.SetProperty("ItemDoubleClickData", AV14ItemDoubleClickData);
            ucQueryviewerpurchase.SetProperty("DragAndDropData", AV9DragAndDropData);
            ucQueryviewerpurchase.SetProperty("FilterChangedData", AV12FilterChangedData);
            ucQueryviewerpurchase.SetProperty("ItemExpandData", AV10ItemExpandData);
            ucQueryviewerpurchase.SetProperty("ItemCollapseData", AV11ItemCollapseData);
            ucQueryviewerpurchase.Render(context, "queryviewer", Queryviewerpurchase_Internalname, sPrefix+"QUERYVIEWERPURCHASEContainer");
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

      protected void START3V2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET 18_0_2-169539", 0) ;
               }
               Form.Meta.addItem("description", "WCStatistics Products Top", 0) ;
            }
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP3V0( ) ;
            }
         }
      }

      protected void WS3V2( )
      {
         START3V2( ) ;
         EVT3V2( ) ;
      }

      protected void EVT3V2( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3V0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3V0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E113V2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VYEAR.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3V0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E123V2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VMONTH.CONTROLVALUECHANGED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3V0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E133V2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3V0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E143V2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3V0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E153V2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3V0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP3V0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = cmbavYear_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
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

      protected void WE3V2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm3V2( ) ;
            }
         }
      }

      protected void PA3V2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = cmbavYear_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
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
            AV16Year = (short)(Math.Round(NumberUtil.Val( cmbavYear.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV16Year), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV16Year", StringUtil.LTrimStr( (decimal)(AV16Year), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavYear.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16Year), 4, 0));
            AssignProp(sPrefix, false, cmbavYear_Internalname, "Values", cmbavYear.ToJavascriptSource(), true);
         }
         if ( cmbavMonth.ItemCount > 0 )
         {
            AV15Month = (short)(Math.Round(NumberUtil.Val( cmbavMonth.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV15Month), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV15Month", StringUtil.LTrimStr( (decimal)(AV15Month), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavMonth.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV15Month), 4, 0));
            AssignProp(sPrefix, false, cmbavMonth_Internalname, "Values", cmbavMonth.ToJavascriptSource(), true);
         }
         if ( cmbavOption.ItemCount > 0 )
         {
            AV30Option = (short)(Math.Round(NumberUtil.Val( cmbavOption.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV30Option), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV30Option", StringUtil.LTrimStr( (decimal)(AV30Option), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavOption.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV30Option), 4, 0));
            AssignProp(sPrefix, false, cmbavOption_Internalname, "Values", cmbavOption.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF3V2( ) ;
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

      protected void RF3V2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E143V2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E153V2 ();
            WB3V0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes3V2( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3V0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E113V2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vELEMENTS"), AV7Elements);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vPARAMETERS"), AV5Parameters);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vITEMCLICKDATA"), AV13ItemClickData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vITEMDOUBLECLICKDATA"), AV14ItemDoubleClickData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDRAGANDDROPDATA"), AV9DragAndDropData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vFILTERCHANGEDDATA"), AV12FilterChangedData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vITEMEXPANDDATA"), AV10ItemExpandData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vITEMCOLLAPSEDATA"), AV11ItemCollapseData);
            /* Read saved values. */
            Queryviewersale_Objectname = cgiGet( sPrefix+"QUERYVIEWERSALE_Objectname");
            Queryviewersale_Type = cgiGet( sPrefix+"QUERYVIEWERSALE_Type");
            Queryviewersale_Charttype = cgiGet( sPrefix+"QUERYVIEWERSALE_Charttype");
            Queryviewersale_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"QUERYVIEWERSALE_Visible"));
            Queryviewerpurchase_Objectname = cgiGet( sPrefix+"QUERYVIEWERPURCHASE_Objectname");
            Queryviewerpurchase_Charttype = cgiGet( sPrefix+"QUERYVIEWERPURCHASE_Charttype");
            Queryviewerpurchase_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"QUERYVIEWERPURCHASE_Visible"));
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
         E113V2 ();
         if (returnInSub) return;
      }

      protected void E113V2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHARGEYEARS' */
         S112 ();
         if (returnInSub) return;
         AV16Year = (short)(AV28Years.GetNumeric(1));
         AssignAttri(sPrefix, false, "AV16Year", StringUtil.LTrimStr( (decimal)(AV16Year), 4, 0));
         /* Execute user subroutine: 'CHARGEMONTHS' */
         S122 ();
         if (returnInSub) return;
         AV15Month = (short)(AV24Months.GetNumeric(1));
         AssignAttri(sPrefix, false, "AV15Month", StringUtil.LTrimStr( (decimal)(AV15Month), 4, 0));
         /* Execute user subroutine: 'CHARGEPARAMETERS' */
         S132 ();
         if (returnInSub) return;
      }

      protected void E123V2( )
      {
         /* Year_Controlvaluechanged Routine */
         returnInSub = false;
         if ( ! (0==AV16Year) )
         {
            /* Execute user subroutine: 'CHARGEMONTHS' */
            S122 ();
            if (returnInSub) return;
            AV15Month = (short)(AV24Months.GetNumeric(1));
            AssignAttri(sPrefix, false, "AV15Month", StringUtil.LTrimStr( (decimal)(AV15Month), 4, 0));
            context.DoAjaxRefreshCmp(sPrefix);
         }
         /*  Sending Event outputs  */
         cmbavMonth.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV15Month), 4, 0));
         AssignProp(sPrefix, false, cmbavMonth_Internalname, "Values", cmbavMonth.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV24Months", AV24Months);
      }

      protected void E133V2( )
      {
         /* Month_Controlvaluechanged Routine */
         returnInSub = false;
         if ( ! (0==AV15Month) )
         {
            context.DoAjaxRefreshCmp(sPrefix);
         }
      }

      protected void E143V2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHARGEPARAMETERS' */
         S132 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV5Parameters", AV5Parameters);
      }

      protected void S112( )
      {
         /* 'CHARGEYEARS' Routine */
         returnInSub = false;
         cmbavYear.removeAllItems();
         GXt_objcol_int1 = AV28Years;
         new invoicegetyears(context ).execute( out  GXt_objcol_int1) ;
         AV28Years = GXt_objcol_int1;
         AV29Position = 1;
         AV33GXV1 = 1;
         while ( AV33GXV1 <= AV28Years.Count )
         {
            AV27YearAux = (short)(AV28Years.GetNumeric(AV33GXV1));
            cmbavYear.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(AV27YearAux), 4, 0)), StringUtil.Str( (decimal)(AV27YearAux), 4, 0), AV29Position);
            AV29Position = (short)(AV29Position+1);
            AV33GXV1 = (int)(AV33GXV1+1);
         }
      }

      protected void S122( )
      {
         /* 'CHARGEMONTHS' Routine */
         returnInSub = false;
         cmbavMonth.removeAllItems();
         GXt_objcol_int1 = AV24Months;
         new invoicegetmonthperyear(context ).execute(  AV16Year, out  GXt_objcol_int1) ;
         AV24Months = GXt_objcol_int1;
         AV29Position = 1;
         AV34GXV2 = 1;
         while ( AV34GXV2 <= AV24Months.Count )
         {
            AV26MonthAux = (short)(AV24Months.GetNumeric(AV34GXV2));
            AV25DateAux = context.localUtil.YMDToD( AV16Year, AV26MonthAux, 1);
            cmbavMonth.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(AV26MonthAux), 4, 0)), DateTimeUtil.CMonth( AV25DateAux, "eng"), AV29Position);
            AV29Position = (short)(AV29Position+1);
            AV34GXV2 = (int)(AV34GXV2+1);
         }
      }

      protected void S132( )
      {
         /* 'CHARGEPARAMETERS' Routine */
         returnInSub = false;
         AV5Parameters.Clear();
         AV6Parameter = new GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter(context);
         AV6Parameter.gxTpr_Name = "Year";
         AV6Parameter.gxTpr_Value = StringUtil.Str( (decimal)(AV16Year), 4, 0);
         AV5Parameters.Add(AV6Parameter, 0);
         AV6Parameter = new GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter(context);
         AV6Parameter.gxTpr_Name = "Month";
         AV6Parameter.gxTpr_Value = StringUtil.Str( (decimal)(AV15Month), 4, 0);
         AV5Parameters.Add(AV6Parameter, 0);
      }

      protected void nextLoad( )
      {
      }

      protected void E153V2( )
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
         PA3V2( ) ;
         WS3V2( ) ;
         WE3V2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA3V2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wcstatisticsproductstop", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA3V2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
         }
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA3V2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS3V2( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS3V2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE3V2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024112312253681", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         CloseStyles();
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("wcstatisticsproductstop.js", "?2024112312253681", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavYear.Name = "vYEAR";
         cmbavYear.WebTags = "";
         if ( cmbavYear.ItemCount > 0 )
         {
         }
         cmbavMonth.Name = "vMONTH";
         cmbavMonth.WebTags = "";
         if ( cmbavMonth.ItemCount > 0 )
         {
         }
         cmbavOption.Name = "vOPTION";
         cmbavOption.WebTags = "";
         cmbavOption.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(0), 4, 0)), "Sold/Purchased", 0);
         cmbavOption.addItem("1", "Sold", 0);
         cmbavOption.addItem("2", "Purchased", 0);
         if ( cmbavOption.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         cmbavYear_Internalname = sPrefix+"vYEAR";
         cmbavMonth_Internalname = sPrefix+"vMONTH";
         cmbavOption_Internalname = sPrefix+"vOPTION";
         divTable2_Internalname = sPrefix+"TABLE2";
         Queryviewersale_Internalname = sPrefix+"QUERYVIEWERSALE";
         Queryviewerpurchase_Internalname = sPrefix+"QUERYVIEWERPURCHASE";
         divTable3_Internalname = sPrefix+"TABLE3";
         divTable1_Internalname = sPrefix+"TABLE1";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
         Form.Internalname = sPrefix+"FORM";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("mtaKB", true);
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         Queryviewerpurchase_Title = "Top Products Purchased";
         Queryviewersale_Title = "Top Products Sold";
         cmbavOption_Jsonclick = "";
         cmbavOption.Enabled = 1;
         cmbavMonth_Jsonclick = "";
         cmbavMonth.Enabled = 1;
         cmbavYear_Jsonclick = "";
         cmbavYear.Enabled = 1;
         Queryviewerpurchase_Visible = Convert.ToBoolean( -1);
         Queryviewerpurchase_Charttype = "Column";
         Queryviewerpurchase_Objectname = "QStatisticsProductTopOrder";
         Queryviewersale_Visible = Convert.ToBoolean( -1);
         Queryviewersale_Charttype = "ColumnLine";
         Queryviewersale_Type = "Chart";
         Queryviewersale_Objectname = "QStatisticsProductTopSold";
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'cmbavYear'},{av:'AV16Year',fld:'vYEAR',pic:'ZZZ9'},{av:'cmbavMonth'},{av:'AV15Month',fld:'vMONTH',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV5Parameters',fld:'vPARAMETERS',pic:''}]}");
         setEventMetadata("VYEAR.CONTROLVALUECHANGED","{handler:'E123V2',iparms:[{av:'cmbavYear'},{av:'AV16Year',fld:'vYEAR',pic:'ZZZ9'},{av:'AV24Months',fld:'vMONTHS',pic:''}]");
         setEventMetadata("VYEAR.CONTROLVALUECHANGED",",oparms:[{av:'cmbavMonth'},{av:'AV15Month',fld:'vMONTH',pic:'ZZZ9'},{av:'AV24Months',fld:'vMONTHS',pic:''}]}");
         setEventMetadata("VMONTH.CONTROLVALUECHANGED","{handler:'E133V2',iparms:[{av:'cmbavMonth'},{av:'AV15Month',fld:'vMONTH',pic:'ZZZ9'}]");
         setEventMetadata("VMONTH.CONTROLVALUECHANGED",",oparms:[]}");
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
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV7Elements = new GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element>( context, "Element", "GeneXus.Reporting");
         AV5Parameters = new GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter>( context, "Parameter", "GeneXus.Reporting");
         AV13ItemClickData = new GeneXus.Programs.genexusreporting.SdtQueryViewerItemClickData(context);
         AV14ItemDoubleClickData = new GeneXus.Programs.genexusreporting.SdtQueryViewerItemDoubleClickData(context);
         AV9DragAndDropData = new GeneXus.Programs.genexusreporting.SdtQueryViewerDragAndDropData(context);
         AV12FilterChangedData = new GeneXus.Programs.genexusreporting.SdtQueryViewerFilterChangedData(context);
         AV10ItemExpandData = new GeneXus.Programs.genexusreporting.SdtQueryViewerItemExpandData(context);
         AV11ItemCollapseData = new GeneXus.Programs.genexusreporting.SdtQueryViewerItemCollapseData(context);
         AV24Months = new GxSimpleCollection<short>();
         GX_FocusControl = "";
         TempTags = "";
         ucQueryviewersale = new GXUserControl();
         ucQueryviewerpurchase = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV28Years = new GxSimpleCollection<short>();
         GXt_objcol_int1 = new GxSimpleCollection<short>();
         AV25DateAux = DateTime.MinValue;
         AV6Parameter = new GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short AV16Year ;
      private short AV15Month ;
      private short AV30Option ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV29Position ;
      private short AV27YearAux ;
      private short AV26MonthAux ;
      private short nGXWrapped ;
      private int AV33GXV1 ;
      private int AV34GXV2 ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Queryviewersale_Objectname ;
      private string Queryviewersale_Type ;
      private string Queryviewersale_Charttype ;
      private string Queryviewerpurchase_Objectname ;
      private string Queryviewerpurchase_Charttype ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
      private string divTable1_Internalname ;
      private string divTable2_Internalname ;
      private string cmbavYear_Internalname ;
      private string TempTags ;
      private string cmbavYear_Jsonclick ;
      private string cmbavMonth_Internalname ;
      private string cmbavMonth_Jsonclick ;
      private string cmbavOption_Internalname ;
      private string cmbavOption_Jsonclick ;
      private string divTable3_Internalname ;
      private string Queryviewersale_Title ;
      private string Queryviewersale_Internalname ;
      private string Queryviewerpurchase_Title ;
      private string Queryviewerpurchase_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private DateTime AV25DateAux ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Queryviewersale_Visible ;
      private bool Queryviewerpurchase_Visible ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private GxSimpleCollection<short> AV28Years ;
      private GxSimpleCollection<short> AV24Months ;
      private GxSimpleCollection<short> GXt_objcol_int1 ;
      private GXUserControl ucQueryviewersale ;
      private GXUserControl ucQueryviewerpurchase ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavYear ;
      private GXCombobox cmbavMonth ;
      private GXCombobox cmbavOption ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element> AV7Elements ;
      private GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter> AV5Parameters ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerDragAndDropData AV9DragAndDropData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerFilterChangedData AV12FilterChangedData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerItemClickData AV13ItemClickData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerItemCollapseData AV11ItemCollapseData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerItemDoubleClickData AV14ItemDoubleClickData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerItemExpandData AV10ItemExpandData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter AV6Parameter ;
   }

}
