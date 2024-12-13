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
   public class wpsupplierpurchaseorderstatistics : GXDataArea
   {
      public wpsupplierpurchaseorderstatistics( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public wpsupplierpurchaseorderstatistics( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_SupplierId )
      {
         this.AV15SupplierId = aP0_SupplierId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "SupplierId");
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
               gxfirstwebparm = GetFirstPar( "SupplierId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "SupplierId");
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
               AV15SupplierId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV15SupplierId", StringUtil.LTrimStr( (decimal)(AV15SupplierId), 6, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vSUPPLIERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15SupplierId), "ZZZZZ9"), context));
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("general.ui.masterprompt", "GeneXus.Programs.general.ui.masterprompt", new Object[] {context});
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
         PA3S2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3S2( ) ;
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
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpsupplierpurchaseorderstatistics.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV15SupplierId,6,0))}, new string[] {"SupplierId"}) +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         }
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "vSUPPLIERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15SupplierId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSUPPLIERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15SupplierId), "ZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vELEMENTS", AV7Elements);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vELEMENTS", AV7Elements);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPARAMETERS", AV5Parameters);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPARAMETERS", AV5Parameters);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vITEMCLICKDATA", AV13ItemClickData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vITEMCLICKDATA", AV13ItemClickData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vITEMDOUBLECLICKDATA", AV14ItemDoubleClickData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vITEMDOUBLECLICKDATA", AV14ItemDoubleClickData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDRAGANDDROPDATA", AV9DragAndDropData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDRAGANDDROPDATA", AV9DragAndDropData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFILTERCHANGEDDATA", AV12FilterChangedData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFILTERCHANGEDDATA", AV12FilterChangedData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vITEMEXPANDDATA", AV10ItemExpandData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vITEMEXPANDDATA", AV10ItemExpandData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vITEMCOLLAPSEDATA", AV11ItemCollapseData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vITEMCOLLAPSEDATA", AV11ItemCollapseData);
         }
         GxWebStd.gx_hidden_field( context, "vSUPPLIERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15SupplierId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSUPPLIERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15SupplierId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "QUERYVIEWER1_Objectcall", StringUtil.RTrim( Queryviewer1_Objectcall));
         GxWebStd.gx_hidden_field( context, "QUERYVIEWER1_Objectname", StringUtil.RTrim( Queryviewer1_Objectname));
         GxWebStd.gx_hidden_field( context, "QUERYVIEWER1_Objectcall", StringUtil.RTrim( Queryviewer1_Objectcall));
         GxWebStd.gx_hidden_field( context, "QUERYVIEWER1_Exporttohtml", StringUtil.BoolToStr( Queryviewer1_Exporttohtml));
         GxWebStd.gx_hidden_field( context, "QUERYVIEWER1_Exporttoxls", StringUtil.BoolToStr( Queryviewer1_Exporttoxls));
         GxWebStd.gx_hidden_field( context, "QUERYVIEWER1_Type", StringUtil.RTrim( Queryviewer1_Type));
         GxWebStd.gx_hidden_field( context, "QUERYVIEWER1_Title", StringUtil.RTrim( Queryviewer1_Title));
         GxWebStd.gx_hidden_field( context, "QUERYVIEWER1_Charttype", StringUtil.RTrim( Queryviewer1_Charttype));
         GxWebStd.gx_hidden_field( context, "QUERYVIEWER1_Xaxistitle", StringUtil.RTrim( Queryviewer1_Xaxistitle));
         GxWebStd.gx_hidden_field( context, "QUERYVIEWER1_Yaxistitle", StringUtil.RTrim( Queryviewer1_Yaxistitle));
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "</form>") ;
         }
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
            WE3S2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3S2( ) ;
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
         return formatLink("wpsupplierpurchaseorderstatistics.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV15SupplierId,6,0))}, new string[] {"SupplierId"})  ;
      }

      public override string GetPgmname( )
      {
         return "WPSupplierPurchaseOrderStatistics" ;
      }

      public override string GetPgmdesc( )
      {
         return "Orders per month" ;
      }

      protected void WB3S0( )
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
            /* User Defined Control */
            ucQueryviewer1.SetProperty("Elements", AV7Elements);
            ucQueryviewer1.SetProperty("Parameters", AV5Parameters);
            ucQueryviewer1.SetProperty("ObjectName", Queryviewer1_Objectname);
            ucQueryviewer1.SetProperty("ExportToHTML", Queryviewer1_Exporttohtml);
            ucQueryviewer1.SetProperty("ExportToXLS", Queryviewer1_Exporttoxls);
            ucQueryviewer1.SetProperty("Type", Queryviewer1_Type);
            ucQueryviewer1.SetProperty("Title", Queryviewer1_Title);
            ucQueryviewer1.SetProperty("ChartType", Queryviewer1_Charttype);
            ucQueryviewer1.SetProperty("XAxisTitle", Queryviewer1_Xaxistitle);
            ucQueryviewer1.SetProperty("YAxisTitle", Queryviewer1_Yaxistitle);
            ucQueryviewer1.SetProperty("ItemClickData", AV13ItemClickData);
            ucQueryviewer1.SetProperty("ItemDoubleClickData", AV14ItemDoubleClickData);
            ucQueryviewer1.SetProperty("DragAndDropData", AV9DragAndDropData);
            ucQueryviewer1.SetProperty("FilterChangedData", AV12FilterChangedData);
            ucQueryviewer1.SetProperty("ItemExpandData", AV10ItemExpandData);
            ucQueryviewer1.SetProperty("ItemCollapseData", AV11ItemCollapseData);
            ucQueryviewer1.Render(context, "queryviewer", Queryviewer1_Internalname, "QUERYVIEWER1Container");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START3S2( )
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
            Form.Meta.addItem("description", "Orders per month", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3S0( ) ;
      }

      protected void WS3S2( )
      {
         START3S2( ) ;
         EVT3S2( ) ;
      }

      protected void EVT3S2( )
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
                              E113S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E123S2 ();
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

      protected void WE3S2( )
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

      protected void PA3S2( )
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
         RF3S2( ) ;
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

      protected void RF3S2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E123S2 ();
            WB3S0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes3S2( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3S0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E113S2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vELEMENTS"), AV7Elements);
            ajax_req_read_hidden_sdt(cgiGet( "vPARAMETERS"), AV5Parameters);
            ajax_req_read_hidden_sdt(cgiGet( "vITEMCLICKDATA"), AV13ItemClickData);
            ajax_req_read_hidden_sdt(cgiGet( "vITEMDOUBLECLICKDATA"), AV14ItemDoubleClickData);
            ajax_req_read_hidden_sdt(cgiGet( "vDRAGANDDROPDATA"), AV9DragAndDropData);
            ajax_req_read_hidden_sdt(cgiGet( "vFILTERCHANGEDDATA"), AV12FilterChangedData);
            ajax_req_read_hidden_sdt(cgiGet( "vITEMEXPANDDATA"), AV10ItemExpandData);
            ajax_req_read_hidden_sdt(cgiGet( "vITEMCOLLAPSEDATA"), AV11ItemCollapseData);
            /* Read saved values. */
            Queryviewer1_Objectcall = cgiGet( "QUERYVIEWER1_Objectcall");
            Queryviewer1_Objectname = cgiGet( "QUERYVIEWER1_Objectname");
            Queryviewer1_Objectcall = cgiGet( "QUERYVIEWER1_Objectcall");
            Queryviewer1_Exporttohtml = StringUtil.StrToBool( cgiGet( "QUERYVIEWER1_Exporttohtml"));
            Queryviewer1_Exporttoxls = StringUtil.StrToBool( cgiGet( "QUERYVIEWER1_Exporttoxls"));
            Queryviewer1_Type = cgiGet( "QUERYVIEWER1_Type");
            Queryviewer1_Title = cgiGet( "QUERYVIEWER1_Title");
            Queryviewer1_Charttype = cgiGet( "QUERYVIEWER1_Charttype");
            Queryviewer1_Xaxistitle = cgiGet( "QUERYVIEWER1_Xaxistitle");
            Queryviewer1_Yaxistitle = cgiGet( "QUERYVIEWER1_Yaxistitle");
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
         E113S2 ();
         if (returnInSub) return;
      }

      protected void E113S2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV5Parameters = new GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter>( context, "Parameter", "GeneXus.Reporting");
         AV6Parameter = new GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter(context);
         AV6Parameter.gxTpr_Name = "SupplierId";
         AV6Parameter.gxTpr_Value = StringUtil.Str( (decimal)(AV15SupplierId), 6, 0);
         AV5Parameters.Add(AV6Parameter, 0);
         AV6Parameter = new GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter(context);
         AV6Parameter.gxTpr_Name = "Year";
         AV6Parameter.gxTpr_Value = StringUtil.Str( (decimal)(DateTimeUtil.Year( DateTimeUtil.ServerDate( context, pr_default))), 10, 0);
         AV5Parameters.Add(AV6Parameter, 0);
         AV6Parameter = new GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter(context);
         AV6Parameter.gxTpr_Name = "State";
         AV6Parameter.gxTpr_Value = "";
         AV5Parameters.Add(AV6Parameter, 0);
         Queryviewer1_Objectcall = "[ \""+"query"+"\", \""+StringUtil.JSONEncode( "QSupplierPurchaseOrderStatistic")+"\", \""+StringUtil.JSONEncode( StringUtil.Str( (decimal)(AV15SupplierId), 6, 0))+"\", \""+StringUtil.JSONEncode( StringUtil.Str( (decimal)(DateTimeUtil.Year( DateTimeUtil.ServerDate( context, pr_default))), 9, 0))+"\", \""+StringUtil.JSONEncode( "")+"\" ]";
         ucQueryviewer1.SendProperty(context, "", false, Queryviewer1_Internalname, "Object", Queryviewer1_Objectcall);
         GX_msglist.addItem(AV7Elements.ToJSonString(false));
      }

      protected void nextLoad( )
      {
      }

      protected void E123S2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV15SupplierId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV15SupplierId", StringUtil.LTrimStr( (decimal)(AV15SupplierId), 6, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vSUPPLIERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15SupplierId), "ZZZZZ9"), context));
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
         PA3S2( ) ;
         WS3S2( ) ;
         WE3S2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202411152133989", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("messages.eng.js", "?"+GetCacheInvalidationToken( ), false, true);
            context.AddJavascriptSource("wpsupplierpurchaseorderstatistics.js", "?202411152133990", false, true);
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
         Queryviewer1_Internalname = "QUERYVIEWER1";
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
         Queryviewer1_Yaxistitle = "Qty Orders";
         Queryviewer1_Xaxistitle = "Month";
         Queryviewer1_Charttype = "Column3D";
         Queryviewer1_Title = "Purchase per month";
         Queryviewer1_Type = "Chart";
         Queryviewer1_Exporttoxls = Convert.ToBoolean( -1);
         Queryviewer1_Exporttohtml = Convert.ToBoolean( -1);
         Queryviewer1_Objectname = "QSupplierPurchaseOrderStatistic";
         Queryviewer1_Objectcall = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Orders per month";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV15SupplierId',fld:'vSUPPLIERID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
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
         AV7Elements = new GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element>( context, "Element", "GeneXus.Reporting");
         AV5Parameters = new GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter>( context, "Parameter", "GeneXus.Reporting");
         AV13ItemClickData = new GeneXus.Programs.genexusreporting.SdtQueryViewerItemClickData(context);
         AV14ItemDoubleClickData = new GeneXus.Programs.genexusreporting.SdtQueryViewerItemDoubleClickData(context);
         AV9DragAndDropData = new GeneXus.Programs.genexusreporting.SdtQueryViewerDragAndDropData(context);
         AV12FilterChangedData = new GeneXus.Programs.genexusreporting.SdtQueryViewerFilterChangedData(context);
         AV10ItemExpandData = new GeneXus.Programs.genexusreporting.SdtQueryViewerItemExpandData(context);
         AV11ItemCollapseData = new GeneXus.Programs.genexusreporting.SdtQueryViewerItemCollapseData(context);
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucQueryviewer1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV6Parameter = new GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpsupplierpurchaseorderstatistics__default(),
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
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private int AV15SupplierId ;
      private int wcpOAV15SupplierId ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Queryviewer1_Objectcall ;
      private string Queryviewer1_Objectname ;
      private string Queryviewer1_Type ;
      private string Queryviewer1_Title ;
      private string Queryviewer1_Charttype ;
      private string Queryviewer1_Xaxistitle ;
      private string Queryviewer1_Yaxistitle ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string Queryviewer1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Queryviewer1_Exporttohtml ;
      private bool Queryviewer1_Exporttoxls ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private GXUserControl ucQueryviewer1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter> AV5Parameters ;
      private GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element> AV7Elements ;
      private GXWebForm Form ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter AV6Parameter ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerDragAndDropData AV9DragAndDropData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerItemExpandData AV10ItemExpandData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerItemCollapseData AV11ItemCollapseData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerFilterChangedData AV12FilterChangedData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerItemClickData AV13ItemClickData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerItemDoubleClickData AV14ItemDoubleClickData ;
   }

   public class wpsupplierpurchaseorderstatistics__default : DataStoreHelperBase, IDataStoreHelper
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
