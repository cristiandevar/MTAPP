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
   public class wcstatisticsamountstatement : GXWebComponent
   {
      public wcstatisticsamountstatement( )
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

      public wcstatisticsamountstatement( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_Year ,
                           short aP1_Month )
      {
         this.AV25Year = aP0_Year;
         this.AV26Month = aP1_Month;
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
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "Year");
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
                  AV25Year = (short)(Math.Round(NumberUtil.Val( GetPar( "Year"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV25Year", StringUtil.LTrimStr( (decimal)(AV25Year), 4, 0));
                  AV26Month = (short)(Math.Round(NumberUtil.Val( GetPar( "Month"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV26Month", StringUtil.LTrimStr( (decimal)(AV26Month), 4, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(short)AV25Year,(short)AV26Month});
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
                  gxfirstwebparm = GetFirstPar( "Year");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "Year");
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
            PA412( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               WS412( ) ;
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
            context.SendWebValue( "WCStatistics Amount Statement") ;
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
            context.WriteHtmlText( "<body ") ;
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            if ( nGXWrapped != 1 )
            {
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wcstatisticsamountstatement.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV25Year,4,0)),UrlEncode(StringUtil.LTrimStr(AV26Month,4,0))}, new string[] {"Year","Month"}) +"\">") ;
               GxWebStd.gx_hidden_field( context, "_EventName", "");
               GxWebStd.gx_hidden_field( context, "_EventGridId", "");
               GxWebStd.gx_hidden_field( context, "_EventRowId", "");
               context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
               AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
            }
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vELEMENTS", AV9Elements);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vELEMENTS", AV9Elements);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vPARAMETERS", AV7Parameters);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vPARAMETERS", AV7Parameters);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vITEMCLICKDATA", AV15ItemClickData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vITEMCLICKDATA", AV15ItemClickData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vITEMDOUBLECLICKDATA", AV16ItemDoubleClickData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vITEMDOUBLECLICKDATA", AV16ItemDoubleClickData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDRAGANDDROPDATA", AV11DragAndDropData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDRAGANDDROPDATA", AV11DragAndDropData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vFILTERCHANGEDDATA", AV14FilterChangedData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vFILTERCHANGEDDATA", AV14FilterChangedData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vITEMEXPANDDATA", AV12ItemExpandData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vITEMEXPANDDATA", AV12ItemExpandData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vITEMCOLLAPSEDATA", AV13ItemCollapseData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vITEMCOLLAPSEDATA", AV13ItemCollapseData);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV25Year", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV25Year), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV26Month", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV26Month), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vYEAR", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25Year), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMONTH", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26Month), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"QUERYVIEWERAMOUNTSTATEMENT_Objectname", StringUtil.RTrim( Queryvieweramountstatement_Objectname));
         GxWebStd.gx_hidden_field( context, sPrefix+"QUERYVIEWERAMOUNTSTATEMENT_Type", StringUtil.RTrim( Queryvieweramountstatement_Type));
         GxWebStd.gx_hidden_field( context, sPrefix+"QUERYVIEWERAMOUNTSTATEMENT_Charttype", StringUtil.RTrim( Queryvieweramountstatement_Charttype));
      }

      protected void RenderHtmlCloseForm412( )
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
            if ( nGXWrapped != 1 )
            {
               context.WriteHtmlTextNl( "</form>") ;
            }
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
         return "WCStatisticsAmountStatement" ;
      }

      public override string GetPgmdesc( )
      {
         return "WCStatistics Amount Statement" ;
      }

      protected void WB410( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wcstatisticsamountstatement.aspx");
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
            /* User Defined Control */
            ucQueryvieweramountstatement.SetProperty("Elements", AV9Elements);
            ucQueryvieweramountstatement.SetProperty("Parameters", AV7Parameters);
            ucQueryvieweramountstatement.SetProperty("ObjectName", Queryvieweramountstatement_Objectname);
            ucQueryvieweramountstatement.SetProperty("Type", Queryvieweramountstatement_Type);
            ucQueryvieweramountstatement.SetProperty("Title", Queryvieweramountstatement_Title);
            ucQueryvieweramountstatement.SetProperty("ChartType", Queryvieweramountstatement_Charttype);
            ucQueryvieweramountstatement.SetProperty("ItemClickData", AV15ItemClickData);
            ucQueryvieweramountstatement.SetProperty("ItemDoubleClickData", AV16ItemDoubleClickData);
            ucQueryvieweramountstatement.SetProperty("DragAndDropData", AV11DragAndDropData);
            ucQueryvieweramountstatement.SetProperty("FilterChangedData", AV14FilterChangedData);
            ucQueryvieweramountstatement.SetProperty("ItemExpandData", AV12ItemExpandData);
            ucQueryvieweramountstatement.SetProperty("ItemCollapseData", AV13ItemCollapseData);
            ucQueryvieweramountstatement.Render(context, "queryviewer", Queryvieweramountstatement_Internalname, sPrefix+"QUERYVIEWERAMOUNTSTATEMENTContainer");
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

      protected void START412( )
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
               Form.Meta.addItem("description", "WCStatistics Amount Statement", 0) ;
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
               STRUP410( ) ;
            }
         }
      }

      protected void WS412( )
      {
         START412( ) ;
         EVT412( ) ;
      }

      protected void EVT412( )
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
                                 STRUP410( ) ;
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
                                 STRUP410( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E11412 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP410( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E12412 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP410( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E13412 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP410( ) ;
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
                                 STRUP410( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
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

      protected void WE412( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm412( ) ;
            }
         }
      }

      protected void PA412( )
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF412( ) ;
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

      protected void RF412( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E12412 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E13412 ();
            WB410( ) ;
         }
      }

      protected void send_integrity_lvl_hashes412( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP410( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11412 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vELEMENTS"), AV9Elements);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vPARAMETERS"), AV7Parameters);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vITEMCLICKDATA"), AV15ItemClickData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vITEMDOUBLECLICKDATA"), AV16ItemDoubleClickData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDRAGANDDROPDATA"), AV11DragAndDropData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vFILTERCHANGEDDATA"), AV14FilterChangedData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vITEMEXPANDDATA"), AV12ItemExpandData);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vITEMCOLLAPSEDATA"), AV13ItemCollapseData);
            /* Read saved values. */
            wcpOAV25Year = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV25Year"), ".", ","), 18, MidpointRounding.ToEven));
            wcpOAV26Month = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV26Month"), ".", ","), 18, MidpointRounding.ToEven));
            Queryvieweramountstatement_Objectname = cgiGet( sPrefix+"QUERYVIEWERAMOUNTSTATEMENT_Objectname");
            Queryvieweramountstatement_Type = cgiGet( sPrefix+"QUERYVIEWERAMOUNTSTATEMENT_Type");
            Queryvieweramountstatement_Charttype = cgiGet( sPrefix+"QUERYVIEWERAMOUNTSTATEMENT_Charttype");
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
         E11412 ();
         if (returnInSub) return;
      }

      protected void E11412( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHARGEPARAMETERS' */
         S112 ();
         if (returnInSub) return;
      }

      protected void E12412( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHARGEPARAMETERS' */
         S112 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV7Parameters", AV7Parameters);
      }

      protected void S112( )
      {
         /* 'CHARGEPARAMETERS' Routine */
         returnInSub = false;
         AV7Parameters.Clear();
         AV8Parameter = new GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter(context);
         AV8Parameter.gxTpr_Name = "Year";
         AV8Parameter.gxTpr_Value = StringUtil.Str( (decimal)(AV25Year), 4, 0);
         AV7Parameters.Add(AV8Parameter, 0);
         AV8Parameter = new GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter(context);
         AV8Parameter.gxTpr_Name = "Month";
         AV8Parameter.gxTpr_Value = StringUtil.Str( (decimal)(AV26Month), 4, 0);
         AV7Parameters.Add(AV8Parameter, 0);
      }

      protected void nextLoad( )
      {
      }

      protected void E13412( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV25Year = Convert.ToInt16(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV25Year", StringUtil.LTrimStr( (decimal)(AV25Year), 4, 0));
         AV26Month = Convert.ToInt16(getParm(obj,1));
         AssignAttri(sPrefix, false, "AV26Month", StringUtil.LTrimStr( (decimal)(AV26Month), 4, 0));
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
         PA412( ) ;
         WS412( ) ;
         WE412( ) ;
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
         sCtrlAV25Year = (string)((string)getParm(obj,0));
         sCtrlAV26Month = (string)((string)getParm(obj,1));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA412( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wcstatisticsamountstatement", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA412( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV25Year = Convert.ToInt16(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV25Year", StringUtil.LTrimStr( (decimal)(AV25Year), 4, 0));
            AV26Month = Convert.ToInt16(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV26Month", StringUtil.LTrimStr( (decimal)(AV26Month), 4, 0));
         }
         wcpOAV25Year = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV25Year"), ".", ","), 18, MidpointRounding.ToEven));
         wcpOAV26Month = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV26Month"), ".", ","), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( AV25Year != wcpOAV25Year ) || ( AV26Month != wcpOAV26Month ) ) )
         {
            setjustcreated();
         }
         wcpOAV25Year = AV25Year;
         wcpOAV26Month = AV26Month;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV25Year = cgiGet( sPrefix+"AV25Year_CTRL");
         if ( StringUtil.Len( sCtrlAV25Year) > 0 )
         {
            AV25Year = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV25Year), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV25Year", StringUtil.LTrimStr( (decimal)(AV25Year), 4, 0));
         }
         else
         {
            AV25Year = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV25Year_PARM"), ".", ","), 18, MidpointRounding.ToEven));
         }
         sCtrlAV26Month = cgiGet( sPrefix+"AV26Month_CTRL");
         if ( StringUtil.Len( sCtrlAV26Month) > 0 )
         {
            AV26Month = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV26Month), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV26Month", StringUtil.LTrimStr( (decimal)(AV26Month), 4, 0));
         }
         else
         {
            AV26Month = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV26Month_PARM"), ".", ","), 18, MidpointRounding.ToEven));
         }
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
         PA412( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS412( ) ;
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
         WS412( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV25Year_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25Year), 4, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV25Year)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV25Year_CTRL", StringUtil.RTrim( sCtrlAV25Year));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV26Month_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26Month), 4, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV26Month)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV26Month_CTRL", StringUtil.RTrim( sCtrlAV26Month));
         }
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
         WE412( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202411161572161", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("wcstatisticsamountstatement.js", "?202411161572161", false, true);
            context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         Queryvieweramountstatement_Internalname = sPrefix+"QUERYVIEWERAMOUNTSTATEMENT";
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
         Queryvieweramountstatement_Title = "";
         Queryvieweramountstatement_Charttype = "SmoothTimeline";
         Queryvieweramountstatement_Type = "Chart";
         Queryvieweramountstatement_Objectname = "DPStatisticsAmountStatement";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV25Year',fld:'vYEAR',pic:'ZZZ9'},{av:'AV26Month',fld:'vMONTH',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV7Parameters',fld:'vPARAMETERS',pic:''}]}");
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
         AV9Elements = new GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element>( context, "Element", "GeneXus.Reporting");
         AV7Parameters = new GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter>( context, "Parameter", "GeneXus.Reporting");
         AV15ItemClickData = new GeneXus.Programs.genexusreporting.SdtQueryViewerItemClickData(context);
         AV16ItemDoubleClickData = new GeneXus.Programs.genexusreporting.SdtQueryViewerItemDoubleClickData(context);
         AV11DragAndDropData = new GeneXus.Programs.genexusreporting.SdtQueryViewerDragAndDropData(context);
         AV14FilterChangedData = new GeneXus.Programs.genexusreporting.SdtQueryViewerFilterChangedData(context);
         AV12ItemExpandData = new GeneXus.Programs.genexusreporting.SdtQueryViewerItemExpandData(context);
         AV13ItemCollapseData = new GeneXus.Programs.genexusreporting.SdtQueryViewerItemCollapseData(context);
         GX_FocusControl = "";
         ucQueryvieweramountstatement = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV8Parameter = new GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV25Year = "";
         sCtrlAV26Month = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV25Year ;
      private short AV26Month ;
      private short wcpOAV25Year ;
      private short wcpOAV26Month ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
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
      private string Queryvieweramountstatement_Objectname ;
      private string Queryvieweramountstatement_Type ;
      private string Queryvieweramountstatement_Charttype ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
      private string divTable1_Internalname ;
      private string Queryvieweramountstatement_Title ;
      private string Queryvieweramountstatement_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string sCtrlAV25Year ;
      private string sCtrlAV26Month ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private GXUserControl ucQueryvieweramountstatement ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter> AV7Parameters ;
      private GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element> AV9Elements ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter AV8Parameter ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerDragAndDropData AV11DragAndDropData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerItemExpandData AV12ItemExpandData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerItemCollapseData AV13ItemCollapseData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerFilterChangedData AV14FilterChangedData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerItemClickData AV15ItemClickData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerItemDoubleClickData AV16ItemDoubleClickData ;
   }

}
