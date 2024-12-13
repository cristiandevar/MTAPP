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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class wppurchaseordergenerated : GXDataArea
   {
      public wppurchaseordergenerated( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public wppurchaseordergenerated( IGxContext context )
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

      protected void gxnrGrid1_newrow_invoke( )
      {
         nRC_GXsfl_21 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_21"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_21_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_21_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_21_idx = GetPar( "sGXsfl_21_idx");
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
         ajax_req_read_hidden_sdt(GetNextPar( ), AV5SDTPurchaseOrderGenerateList);
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( AV5SDTPurchaseOrderGenerateList) ;
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
         PA4I2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START4I2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wppurchaseordergenerated.aspx") +"\">") ;
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTPURCHASEORDERGENERATELIST", AV5SDTPurchaseOrderGenerateList);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTPURCHASEORDERGENERATELIST", AV5SDTPurchaseOrderGenerateList);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vSDTPURCHASEORDERGENERATELIST", GetSecureSignedToken( "", AV5SDTPurchaseOrderGenerateList, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Sdtpurchaseordergeneratelist", AV5SDTPurchaseOrderGenerateList);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Sdtpurchaseordergeneratelist", AV5SDTPurchaseOrderGenerateList);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_Sdtpurchaseordergeneratelist", GetSecureSignedToken( "", AV5SDTPurchaseOrderGenerateList, context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_21", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_21), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTPURCHASEORDERGENERATELIST", AV5SDTPurchaseOrderGenerateList);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTPURCHASEORDERGENERATELIST", AV5SDTPurchaseOrderGenerateList);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vSDTPURCHASEORDERGENERATELIST", GetSecureSignedToken( "", AV5SDTPurchaseOrderGenerateList, context));
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
            WE4I2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT4I2( ) ;
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
         return formatLink("wppurchaseordergenerated.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WPPurchaseOrderGenerated" ;
      }

      public override string GetPgmdesc( )
      {
         return "Purchase Order Generated" ;
      }

      protected void WB4I0( )
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
            GxWebStd.gx_div_start( context, divTable2_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 15,'',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttNeworder_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(21), 2, 0)+","+"null"+");", "New Order", bttNeworder_Jsonclick, 7, "New Order", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e114i1_client"+"'", TempTags, "", 2, "HLP_WPPurchaseOrderGenerated.htm");
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
            GxWebStd.gx_div_start( context, divTable4_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl21( ) ;
         }
         if ( wbEnd == 21 )
         {
            wbEnd = 0;
            nRC_GXsfl_21 = (int)(nGXsfl_21_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV28GXV1 = nGXsfl_21_idx;
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
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 21 )
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
                  AV28GXV1 = nGXsfl_21_idx;
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

      protected void START4I2( )
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
            Form.Meta.addItem("description", "Purchase Order Generated", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP4I0( ) ;
      }

      protected void WS4I2( )
      {
         START4I2( ) ;
         EVT4I2( ) ;
      }

      protected void EVT4I2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 20), "CTLDETAILSLINK.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 23), "CTLSDTVOUCHERLINK.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRID1.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 20), "CTLDETAILSLINK.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 23), "CTLSDTVOUCHERLINK.CLICK") == 0 ) )
                           {
                              nGXsfl_21_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_21_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_21_idx), 4, 0), 4, "0");
                              SubsflControlProps_212( ) ;
                              AV28GXV1 = nGXsfl_21_idx;
                              if ( ( AV5SDTPurchaseOrderGenerateList.Count >= AV28GXV1 ) && ( AV28GXV1 > 0 ) )
                              {
                                 AV5SDTPurchaseOrderGenerateList.CurrentItem = ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV5SDTPurchaseOrderGenerateList.Item(AV28GXV1));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E124I2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "CTLDETAILSLINK.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E134I2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "CTLSDTVOUCHERLINK.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E144I2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID1.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E154I2 ();
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

      protected void WE4I2( )
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

      protected void PA4I2( )
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

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_212( ) ;
         while ( nGXsfl_21_idx <= nRC_GXsfl_21 )
         {
            sendrow_212( ) ;
            nGXsfl_21_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_21_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_21_idx+1);
            sGXsfl_21_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_21_idx), 4, 0), 4, "0");
            SubsflControlProps_212( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( GXBaseCollection<SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem> AV5SDTPurchaseOrderGenerateList )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF4I2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
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
         RF4I2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavCtlpurchaseorderid_Enabled = 0;
         AssignProp("", false, edtavCtlpurchaseorderid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlpurchaseorderid_Enabled), 5, 0), !bGXsfl_21_Refreshing);
         edtavCtlsuppliername_Enabled = 0;
         AssignProp("", false, edtavCtlsuppliername_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsuppliername_Enabled), 5, 0), !bGXsfl_21_Refreshing);
         edtavCtlpurchaseorderdetailsquantity_Enabled = 0;
         AssignProp("", false, edtavCtlpurchaseorderdetailsquantity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlpurchaseorderdetailsquantity_Enabled), 5, 0), !bGXsfl_21_Refreshing);
         edtavCtldetailslink_Enabled = 0;
         AssignProp("", false, edtavCtldetailslink_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtldetailslink_Enabled), 5, 0), !bGXsfl_21_Refreshing);
         edtavCtlsdtvoucherlink_Enabled = 0;
         AssignProp("", false, edtavCtlsdtvoucherlink_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsdtvoucherlink_Enabled), 5, 0), !bGXsfl_21_Refreshing);
         edtavCtlcreateddate_Enabled = 0;
         AssignProp("", false, edtavCtlcreateddate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcreateddate_Enabled), 5, 0), !bGXsfl_21_Refreshing);
         edtavCtlcloseddate_Enabled = 0;
         AssignProp("", false, edtavCtlcloseddate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcloseddate_Enabled), 5, 0), !bGXsfl_21_Refreshing);
      }

      protected void RF4I2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 21;
         nGXsfl_21_idx = 1;
         sGXsfl_21_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_21_idx), 4, 0), 4, "0");
         SubsflControlProps_212( ) ;
         bGXsfl_21_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "PromptGrid");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_212( ) ;
            E154I2 ();
            wbEnd = 21;
            WB4I0( ) ;
         }
         bGXsfl_21_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes4I2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTPURCHASEORDERGENERATELIST", AV5SDTPurchaseOrderGenerateList);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTPURCHASEORDERGENERATELIST", AV5SDTPurchaseOrderGenerateList);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vSDTPURCHASEORDERGENERATELIST", GetSecureSignedToken( "", AV5SDTPurchaseOrderGenerateList, context));
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
         edtavCtlpurchaseorderid_Enabled = 0;
         AssignProp("", false, edtavCtlpurchaseorderid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlpurchaseorderid_Enabled), 5, 0), !bGXsfl_21_Refreshing);
         edtavCtlsuppliername_Enabled = 0;
         AssignProp("", false, edtavCtlsuppliername_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsuppliername_Enabled), 5, 0), !bGXsfl_21_Refreshing);
         edtavCtlpurchaseorderdetailsquantity_Enabled = 0;
         AssignProp("", false, edtavCtlpurchaseorderdetailsquantity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlpurchaseorderdetailsquantity_Enabled), 5, 0), !bGXsfl_21_Refreshing);
         edtavCtldetailslink_Enabled = 0;
         AssignProp("", false, edtavCtldetailslink_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtldetailslink_Enabled), 5, 0), !bGXsfl_21_Refreshing);
         edtavCtlsdtvoucherlink_Enabled = 0;
         AssignProp("", false, edtavCtlsdtvoucherlink_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlsdtvoucherlink_Enabled), 5, 0), !bGXsfl_21_Refreshing);
         edtavCtlcreateddate_Enabled = 0;
         AssignProp("", false, edtavCtlcreateddate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcreateddate_Enabled), 5, 0), !bGXsfl_21_Refreshing);
         edtavCtlcloseddate_Enabled = 0;
         AssignProp("", false, edtavCtlcloseddate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcloseddate_Enabled), 5, 0), !bGXsfl_21_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4I0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E124I2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Sdtpurchaseordergeneratelist"), AV5SDTPurchaseOrderGenerateList);
            /* Read saved values. */
            nRC_GXsfl_21 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_21"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_21 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_21"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_21_fel_idx = 0;
            while ( nGXsfl_21_fel_idx < nRC_GXsfl_21 )
            {
               nGXsfl_21_fel_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_21_fel_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_21_fel_idx+1);
               sGXsfl_21_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_21_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_212( ) ;
               AV28GXV1 = nGXsfl_21_fel_idx;
               if ( ( AV5SDTPurchaseOrderGenerateList.Count >= AV28GXV1 ) && ( AV28GXV1 > 0 ) )
               {
                  AV5SDTPurchaseOrderGenerateList.CurrentItem = ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV5SDTPurchaseOrderGenerateList.Item(AV28GXV1));
               }
            }
            if ( nGXsfl_21_fel_idx == 0 )
            {
               nGXsfl_21_idx = 1;
               sGXsfl_21_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_21_idx), 4, 0), 4, "0");
               SubsflControlProps_212( ) ;
            }
            nGXsfl_21_fel_idx = 1;
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
         E124I2 ();
         if (returnInSub) return;
      }

      protected void E124I2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV11Orders.FromXml(AV19WebSession.Get("WPGeneratePurchaseOrders"), null, "PurchaseOrderCollection", "");
         AV19WebSession.Remove("WPGeneratePurchaseOrders");
         /* Execute user subroutine: 'CHARGESDT' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'SENDEMAILS' */
         S122 ();
         if (returnInSub) return;
      }

      protected void E134I2( )
      {
         AV28GXV1 = nGXsfl_21_idx;
         if ( ( AV28GXV1 > 0 ) && ( AV5SDTPurchaseOrderGenerateList.Count >= AV28GXV1 ) )
         {
            AV5SDTPurchaseOrderGenerateList.CurrentItem = ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV5SDTPurchaseOrderGenerateList.Item(AV28GXV1));
         }
         /* Ctldetailslink_Click Routine */
         returnInSub = false;
         /* Window Datatype Object Property */
         AV6window.Url = formatLink("wppurchaseorderdetails.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)(AV5SDTPurchaseOrderGenerateList.CurrentItem)).gxTpr_Purchaseorderid,6,0))}, new string[] {"PurchaseOrderId"}) ;
         AV6window.SetReturnParms(new Object[] {});
         AV6window.Height = 500;
         AV6window.Width = 500;
         context.NewWindow(AV6window);
         /*  Sending Event outputs  */
      }

      protected void E144I2( )
      {
         AV28GXV1 = nGXsfl_21_idx;
         if ( ( AV28GXV1 > 0 ) && ( AV5SDTPurchaseOrderGenerateList.Count >= AV28GXV1 ) )
         {
            AV5SDTPurchaseOrderGenerateList.CurrentItem = ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV5SDTPurchaseOrderGenerateList.Item(AV28GXV1));
         }
         /* Ctlsdtvoucherlink_Click Routine */
         returnInSub = false;
         /* Window Datatype Object Property */
         AV6window.Url = formatLink("apurchaseordergenerate.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)(AV5SDTPurchaseOrderGenerateList.CurrentItem)).gxTpr_Purchaseorderid,6,0))}, new string[] {"PurchaseOrderId"}) ;
         AV6window.SetReturnParms(new Object[] {});
         AV6window.Height = 500;
         AV6window.Width = 500;
         context.NewWindow(AV6window);
         /*  Sending Event outputs  */
      }

      protected void S122( )
      {
         /* 'SENDEMAILS' Routine */
         returnInSub = false;
         AV36GXV9 = 1;
         while ( AV36GXV9 <= AV11Orders.Count )
         {
            AV12Order = ((SdtPurchaseOrder)AV11Orders.Item(AV36GXV9));
            /* Using cursor H004I2 */
            pr_default.execute(0, new Object[] {AV12Order.gxTpr_Supplierid});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A4SupplierId = H004I2_A4SupplierId[0];
               A8SupplierEmail = H004I2_A8SupplierEmail[0];
               n8SupplierEmail = H004I2_n8SupplierEmail[0];
               A5SupplierName = H004I2_A5SupplierName[0];
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A8SupplierEmail)) || H004I2_n8SupplierEmail[0] ) )
               {
                  AV14URLs = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
                  AV14URLs.Add(formatLink("apurchaseordergenerateattach.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV12Order.gxTpr_Purchaseorderid,6,0))}, new string[] {"PurchaseOrderId"}) , 0);
                  AV15NamesAttachs = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
                  AV15NamesAttachs.Add("Voucher_"+StringUtil.Trim( StringUtil.Str( (decimal)(AV12Order.gxTpr_Purchaseorderid), 6, 0))+".pdf", 0);
                  AV13PurchaseOrderId = AV12Order.gxTpr_Purchaseorderid;
                  AssignAttri("", false, "AV13PurchaseOrderId", StringUtil.LTrimStr( (decimal)(AV13PurchaseOrderId), 6, 0));
                  AV24EmailTitle = "Purchase Order Generated";
                  AV25EmailSubtitle = "Hello!. We generate a Purchase Order for you. Please, we need confirmation or rejection of it. The proof of the order is attached.";
                  /* Execute user subroutine: 'CREATEBODYMSG' */
                  S133 ();
                  if ( returnInSub )
                  {
                     pr_default.close(0);
                     returnInSub = true;
                     if (true) return;
                  }
                  new sendemailprepareheader(context ).execute(  AV24EmailTitle,  AV25EmailSubtitle,  AV10BodyMsg, out  AV23BodyMsgAux) ;
                  AV10BodyMsg = AV23BodyMsgAux;
                  AssignAttri("", false, "AV10BodyMsg", AV10BodyMsg);
                  GXt_char1 = "Purchase Order Generated for You";
                  new sendemail(context ).execute(  A8SupplierEmail, ref  AV10BodyMsg, ref  GXt_char1, ref  AV14URLs, ref  AV15NamesAttachs, ref  AV9AllOk) ;
                  AssignAttri("", false, "AV10BodyMsg", AV10BodyMsg);
                  AssignAttri("", false, "AV9AllOk", AV9AllOk);
                  if ( ! AV9AllOk )
                  {
                     GX_msglist.addItem("Send Email Error to:"+A5SupplierName);
                  }
               }
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            AV36GXV9 = (int)(AV36GXV9+1);
         }
      }

      protected void S112( )
      {
         /* 'CHARGESDT' Routine */
         returnInSub = false;
         AV38GXV10 = 1;
         while ( AV38GXV10 <= AV11Orders.Count )
         {
            AV12Order = ((SdtPurchaseOrder)AV11Orders.Item(AV38GXV10));
            AV16SDTPurchaseOrderGenerateItem = new SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem(context);
            AV16SDTPurchaseOrderGenerateItem.gxTpr_Purchaseorderid = AV12Order.gxTpr_Purchaseorderid;
            AV16SDTPurchaseOrderGenerateItem.gxTpr_Suppliername = AV12Order.gxTpr_Suppliername;
            AV16SDTPurchaseOrderGenerateItem.gxTpr_Purchaseorderdetailsquantity = AV12Order.gxTpr_Purchaseorderdetailsquantity;
            AV16SDTPurchaseOrderGenerateItem.gxTpr_Detailslink = "Details";
            AV16SDTPurchaseOrderGenerateItem.gxTpr_Sdtvoucherlink = "View Voucher";
            AV5SDTPurchaseOrderGenerateList.Add(AV16SDTPurchaseOrderGenerateItem, 0);
            gx_BV21 = true;
            AV38GXV10 = (int)(AV38GXV10+1);
         }
      }

      protected void S133( )
      {
         /* 'CREATEBODYMSG' Routine */
         returnInSub = false;
         AV17BaseURL = "https://drive.google.com/uc?export=download&id=";
         AV21ImageName2 = "1kTIbiEt6WViWNUHW9MOrXpqFTSiBia0e";
         AV22ImageName3 = "1ZZms6FLS4uaYV5rauLHbMbnWapaYrZ3t";
         AV10BodyMsg = "";
         AssignAttri("", false, "AV10BodyMsg", AV10BodyMsg);
         AV10BodyMsg += "                <table role=\"presentation\" style=\"width:100%;border-collapse:collapse;border:0;border-spacing:0;\">";
         AssignAttri("", false, "AV10BodyMsg", AV10BodyMsg);
         AV10BodyMsg += "					<tr>";
         AssignAttri("", false, "AV10BodyMsg", AV10BodyMsg);
         AV10BodyMsg += "						<td style=\"width:260px;padding:0;vertical-align:top;color:#13142c;\">";
         AssignAttri("", false, "AV10BodyMsg", AV10BodyMsg);
         AV10BodyMsg += "							<p style=\"margin:0 0 25px 0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;\" align=\"center\">";
         AssignAttri("", false, "AV10BodyMsg", AV10BodyMsg);
         AV10BodyMsg += "								<a href=\"" + StringUtil.Trim( AV18HTTPRequest.BaseURL) + formatLink("purchaseordersupplierview.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13PurchaseOrderId,6,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"PurchaseOrderId","MesaggeError"})  + "\">";
         AssignAttri("", false, "AV10BodyMsg", AV10BodyMsg);
         AV10BodyMsg += "									<img src=\"" + AV17BaseURL + AV21ImageName2 + "\" alt=\"Icon Task List\" width=\"100\" style=\"height:auto;display:block;\" />";
         AssignAttri("", false, "AV10BodyMsg", AV10BodyMsg);
         AV10BodyMsg += "								</a>";
         AssignAttri("", false, "AV10BodyMsg", AV10BodyMsg);
         AV10BodyMsg += "							</p>";
         AssignAttri("", false, "AV10BodyMsg", AV10BodyMsg);
         AV10BodyMsg += "							<p style=\"margin:0 0 12px 0;font-size:12px;line-height:24px;font-family:Arial,sans-serif;\">";
         AssignAttri("", false, "AV10BodyMsg", AV10BodyMsg);
         AV10BodyMsg += "								If you wish to confirm, modify or cancel the generated purchase order, you can do so through the following link:";
         AssignAttri("", false, "AV10BodyMsg", AV10BodyMsg);
         AV10BodyMsg += "							</p>";
         AssignAttri("", false, "AV10BodyMsg", AV10BodyMsg);
         AV10BodyMsg += "							<p style=\"margin:0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;\">";
         AssignAttri("", false, "AV10BodyMsg", AV10BodyMsg);
         AV10BodyMsg += "								<a href=\"" + StringUtil.Trim( AV18HTTPRequest.BaseURL) + formatLink("purchaseordersupplierview.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13PurchaseOrderId,6,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"PurchaseOrderId","MesaggeError"})  + "\" style=\"color:#ee4c50;text-decoration:underline;\">";
         AssignAttri("", false, "AV10BodyMsg", AV10BodyMsg);
         AV10BodyMsg += "									Manage Purchase Order";
         AssignAttri("", false, "AV10BodyMsg", AV10BodyMsg);
         AV10BodyMsg += "								</a>";
         AssignAttri("", false, "AV10BodyMsg", AV10BodyMsg);
         AV10BodyMsg += "							</p>";
         AssignAttri("", false, "AV10BodyMsg", AV10BodyMsg);
         AV10BodyMsg += "						</td>";
         AssignAttri("", false, "AV10BodyMsg", AV10BodyMsg);
         AV10BodyMsg += "						<td style=\"width:20px;padding:0;font-size:0;line-height:0;\">";
         AssignAttri("", false, "AV10BodyMsg", AV10BodyMsg);
         AV10BodyMsg += "							&nbsp;";
         AssignAttri("", false, "AV10BodyMsg", AV10BodyMsg);
         AV10BodyMsg += "						</td>";
         AssignAttri("", false, "AV10BodyMsg", AV10BodyMsg);
         AV10BodyMsg += "						<td style=\"width:260px;padding:0;vertical-align:top;color:#153643;\">";
         AssignAttri("", false, "AV10BodyMsg", AV10BodyMsg);
         AV10BodyMsg += "							<p style=\"margin:0 0 25px 0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;\" align=\"center\">";
         AssignAttri("", false, "AV10BodyMsg", AV10BodyMsg);
         AV10BodyMsg += "								<a href=\"" + StringUtil.Trim( AV18HTTPRequest.BaseURL) + formatLink("wpcontactus.aspx")  + "\" >";
         AssignAttri("", false, "AV10BodyMsg", AV10BodyMsg);
         AV10BodyMsg += "									<img src=\"" + AV17BaseURL + AV22ImageName3 + "\" alt=\"Icon Letter Email\" width=\"100\" style=\"height:auto;display:block;\" />";
         AssignAttri("", false, "AV10BodyMsg", AV10BodyMsg);
         AV10BodyMsg += "								</a>";
         AssignAttri("", false, "AV10BodyMsg", AV10BodyMsg);
         AV10BodyMsg += "							</p>";
         AssignAttri("", false, "AV10BodyMsg", AV10BodyMsg);
         AV10BodyMsg += "							<p style=\"margin:0 0 12px 0;font-size:12px;line-height:24px;font-family:Arial,sans-serif;\">";
         AssignAttri("", false, "AV10BodyMsg", AV10BodyMsg);
         AV10BodyMsg += "								If, on the other hand, you consider that this email does not correspond, you can contact us to inform us from the following link:";
         AssignAttri("", false, "AV10BodyMsg", AV10BodyMsg);
         AV10BodyMsg += "							</p>";
         AssignAttri("", false, "AV10BodyMsg", AV10BodyMsg);
         AV10BodyMsg += "							<p style=\"margin:0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;\">";
         AssignAttri("", false, "AV10BodyMsg", AV10BodyMsg);
         AV10BodyMsg += "								<a href=\"" + StringUtil.Trim( AV18HTTPRequest.BaseURL) + formatLink("wpcontactus.aspx")  + "\" style=\"color:#ee4c50;text-decoration:underline;\">";
         AssignAttri("", false, "AV10BodyMsg", AV10BodyMsg);
         AV10BodyMsg += "									Contact Us";
         AssignAttri("", false, "AV10BodyMsg", AV10BodyMsg);
         AV10BodyMsg += "								</a>";
         AssignAttri("", false, "AV10BodyMsg", AV10BodyMsg);
         AV10BodyMsg += "							</p>";
         AssignAttri("", false, "AV10BodyMsg", AV10BodyMsg);
         AV10BodyMsg += "						</td>";
         AssignAttri("", false, "AV10BodyMsg", AV10BodyMsg);
         AV10BodyMsg += "					</tr>";
         AssignAttri("", false, "AV10BodyMsg", AV10BodyMsg);
         AV10BodyMsg += "				</table>";
         AssignAttri("", false, "AV10BodyMsg", AV10BodyMsg);
      }

      private void E154I2( )
      {
         /* Grid1_Load Routine */
         returnInSub = false;
         AV28GXV1 = 1;
         while ( AV28GXV1 <= AV5SDTPurchaseOrderGenerateList.Count )
         {
            AV5SDTPurchaseOrderGenerateList.CurrentItem = ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV5SDTPurchaseOrderGenerateList.Item(AV28GXV1));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 21;
            }
            sendrow_212( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_21_Refreshing )
            {
               DoAjaxLoad(21, Grid1Row);
            }
            AV28GXV1 = (int)(AV28GXV1+1);
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
         PA4I2( ) ;
         WS4I2( ) ;
         WE4I2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20241292465062", true, true);
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
         context.AddJavascriptSource("wppurchaseordergenerated.js", "?20241292465062", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_212( )
      {
         edtavCtlpurchaseorderid_Internalname = "CTLPURCHASEORDERID_"+sGXsfl_21_idx;
         edtavCtlsuppliername_Internalname = "CTLSUPPLIERNAME_"+sGXsfl_21_idx;
         edtavCtlpurchaseorderdetailsquantity_Internalname = "CTLPURCHASEORDERDETAILSQUANTITY_"+sGXsfl_21_idx;
         edtavCtldetailslink_Internalname = "CTLDETAILSLINK_"+sGXsfl_21_idx;
         edtavCtlsdtvoucherlink_Internalname = "CTLSDTVOUCHERLINK_"+sGXsfl_21_idx;
         edtavCtlcreateddate_Internalname = "CTLCREATEDDATE_"+sGXsfl_21_idx;
         edtavCtlcloseddate_Internalname = "CTLCLOSEDDATE_"+sGXsfl_21_idx;
      }

      protected void SubsflControlProps_fel_212( )
      {
         edtavCtlpurchaseorderid_Internalname = "CTLPURCHASEORDERID_"+sGXsfl_21_fel_idx;
         edtavCtlsuppliername_Internalname = "CTLSUPPLIERNAME_"+sGXsfl_21_fel_idx;
         edtavCtlpurchaseorderdetailsquantity_Internalname = "CTLPURCHASEORDERDETAILSQUANTITY_"+sGXsfl_21_fel_idx;
         edtavCtldetailslink_Internalname = "CTLDETAILSLINK_"+sGXsfl_21_fel_idx;
         edtavCtlsdtvoucherlink_Internalname = "CTLSDTVOUCHERLINK_"+sGXsfl_21_fel_idx;
         edtavCtlcreateddate_Internalname = "CTLCREATEDDATE_"+sGXsfl_21_fel_idx;
         edtavCtlcloseddate_Internalname = "CTLCLOSEDDATE_"+sGXsfl_21_fel_idx;
      }

      protected void sendrow_212( )
      {
         SubsflControlProps_212( ) ;
         WB4I0( ) ;
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
            subGrid1_Backcolor = (int)(0x0);
         }
         else if ( subGrid1_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGrid1_Backstyle = 1;
            if ( ((int)((nGXsfl_21_idx) % (2))) == 0 )
            {
               subGrid1_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Even";
               }
            }
            else
            {
               subGrid1_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
         }
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr ") ;
            context.WriteHtmlText( " class=\""+"PromptGrid"+"\" style=\""+""+"\"") ;
            context.WriteHtmlText( " gxrow=\""+sGXsfl_21_idx+"\">") ;
         }
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlpurchaseorderid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV5SDTPurchaseOrderGenerateList.Item(AV28GXV1)).gxTpr_Purchaseorderid), 6, 0, ".", "")),StringUtil.LTrim( ((edtavCtlpurchaseorderid_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV5SDTPurchaseOrderGenerateList.Item(AV28GXV1)).gxTpr_Purchaseorderid), "ZZZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV5SDTPurchaseOrderGenerateList.Item(AV28GXV1)).gxTpr_Purchaseorderid), "ZZZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlpurchaseorderid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlpurchaseorderid_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)21,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsuppliername_Internalname,((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV5SDTPurchaseOrderGenerateList.Item(AV28GXV1)).gxTpr_Suppliername,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlsuppliername_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlsuppliername_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)21,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlpurchaseorderdetailsquantity_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV5SDTPurchaseOrderGenerateList.Item(AV28GXV1)).gxTpr_Purchaseorderdetailsquantity), 4, 0, ".", "")),StringUtil.LTrim( ((edtavCtlpurchaseorderdetailsquantity_Enabled!=0) ? context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV5SDTPurchaseOrderGenerateList.Item(AV28GXV1)).gxTpr_Purchaseorderdetailsquantity), "ZZZ9") : context.localUtil.Format( (decimal)(((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV5SDTPurchaseOrderGenerateList.Item(AV28GXV1)).gxTpr_Purchaseorderdetailsquantity), "ZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlpurchaseorderdetailsquantity_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlpurchaseorderdetailsquantity_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)21,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtldetailslink_Internalname,((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV5SDTPurchaseOrderGenerateList.Item(AV28GXV1)).gxTpr_Detailslink,(string)"",(string)"","'"+""+"'"+",false,"+"'"+"ECTLDETAILSLINK.CLICK."+sGXsfl_21_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtldetailslink_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtldetailslink_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)21,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlsdtvoucherlink_Internalname,((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV5SDTPurchaseOrderGenerateList.Item(AV28GXV1)).gxTpr_Sdtvoucherlink,(string)"",(string)"","'"+""+"'"+",false,"+"'"+"ECTLSDTVOUCHERLINK.CLICK."+sGXsfl_21_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlsdtvoucherlink_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavCtlsdtvoucherlink_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)21,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcreateddate_Internalname,context.localUtil.Format(((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV5SDTPurchaseOrderGenerateList.Item(AV28GXV1)).gxTpr_Createddate, "99/99/99"),context.localUtil.Format( ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV5SDTPurchaseOrderGenerateList.Item(AV28GXV1)).gxTpr_Createddate, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcreateddate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(int)edtavCtlcreateddate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)21,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcloseddate_Internalname,context.localUtil.Format(((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV5SDTPurchaseOrderGenerateList.Item(AV28GXV1)).gxTpr_Closeddate, "99/99/99"),context.localUtil.Format( ((SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem)AV5SDTPurchaseOrderGenerateList.Item(AV28GXV1)).gxTpr_Closeddate, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcloseddate_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(int)edtavCtlcloseddate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)21,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         send_integrity_lvl_hashes4I2( ) ;
         Grid1Container.AddRow(Grid1Row);
         nGXsfl_21_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_21_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_21_idx+1);
         sGXsfl_21_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_21_idx), 4, 0), 4, "0");
         SubsflControlProps_212( ) ;
         /* End function sendrow_212 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl21( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"21\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid1_Backcolorstyle == 0 )
            {
               subGrid1_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid1_Class) > 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Title";
               }
            }
            else
            {
               subGrid1_Titlebackstyle = 1;
               if ( subGrid1_Backcolorstyle == 1 )
               {
                  subGrid1_Titlebackcolor = subGrid1_Allbackcolor;
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Nro. Order") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Supplier") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Qty. Details") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Created Date") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Closed Date") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Grid1Container.AddObjectProperty("GridName", "Grid1");
         }
         else
         {
            Grid1Container.AddObjectProperty("GridName", "Grid1");
            Grid1Container.AddObjectProperty("Header", subGrid1_Header);
            Grid1Container.AddObjectProperty("Class", "PromptGrid");
            Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("CmpContext", "");
            Grid1Container.AddObjectProperty("InMasterPage", "false");
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlpurchaseorderid_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlsuppliername_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlpurchaseorderdetailsquantity_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtldetailslink_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlsdtvoucherlink_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlcreateddate_Enabled), 5, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlcloseddate_Enabled), 5, 0, ".", "")));
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
         bttNeworder_Internalname = "NEWORDER";
         divTable3_Internalname = "TABLE3";
         edtavCtlpurchaseorderid_Internalname = "CTLPURCHASEORDERID";
         edtavCtlsuppliername_Internalname = "CTLSUPPLIERNAME";
         edtavCtlpurchaseorderdetailsquantity_Internalname = "CTLPURCHASEORDERDETAILSQUANTITY";
         edtavCtldetailslink_Internalname = "CTLDETAILSLINK";
         edtavCtlsdtvoucherlink_Internalname = "CTLSDTVOUCHERLINK";
         edtavCtlcreateddate_Internalname = "CTLCREATEDDATE";
         edtavCtlcloseddate_Internalname = "CTLCLOSEDDATE";
         divTable4_Internalname = "TABLE4";
         divTable2_Internalname = "TABLE2";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
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
         subGrid1_Allowselection = 0;
         subGrid1_Header = "";
         edtavCtlcloseddate_Jsonclick = "";
         edtavCtlcloseddate_Enabled = 0;
         edtavCtlcreateddate_Jsonclick = "";
         edtavCtlcreateddate_Enabled = 0;
         edtavCtlsdtvoucherlink_Jsonclick = "";
         edtavCtlsdtvoucherlink_Enabled = 0;
         edtavCtldetailslink_Jsonclick = "";
         edtavCtldetailslink_Enabled = 0;
         edtavCtlpurchaseorderdetailsquantity_Jsonclick = "";
         edtavCtlpurchaseorderdetailsquantity_Enabled = 0;
         edtavCtlsuppliername_Jsonclick = "";
         edtavCtlsuppliername_Enabled = 0;
         edtavCtlpurchaseorderid_Jsonclick = "";
         edtavCtlpurchaseorderid_Enabled = 0;
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCtlcloseddate_Enabled = -1;
         edtavCtlcreateddate_Enabled = -1;
         edtavCtlsdtvoucherlink_Enabled = -1;
         edtavCtldetailslink_Enabled = -1;
         edtavCtlpurchaseorderdetailsquantity_Enabled = -1;
         edtavCtlsuppliername_Enabled = -1;
         edtavCtlpurchaseorderid_Enabled = -1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Purchase Order Generated";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'AV5SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:21,pic:'',hsh:true},{av:'nGXsfl_21_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:21},{av:'nRC_GXsfl_21',ctrl:'GRID1',prop:'GridRC',grid:21}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'NEWORDER'","{handler:'E114I1',iparms:[]");
         setEventMetadata("'NEWORDER'",",oparms:[]}");
         setEventMetadata("CTLDETAILSLINK.CLICK","{handler:'E134I2',iparms:[{av:'AV5SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:21,pic:'',hsh:true},{av:'nGXsfl_21_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:21},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_21',ctrl:'GRID1',prop:'GridRC',grid:21}]");
         setEventMetadata("CTLDETAILSLINK.CLICK",",oparms:[]}");
         setEventMetadata("CTLSDTVOUCHERLINK.CLICK","{handler:'E144I2',iparms:[{av:'AV5SDTPurchaseOrderGenerateList',fld:'vSDTPURCHASEORDERGENERATELIST',grid:21,pic:'',hsh:true},{av:'nGXsfl_21_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:21},{av:'GRID1_nFirstRecordOnPage'},{av:'nRC_GXsfl_21',ctrl:'GRID1',prop:'GridRC',grid:21}]");
         setEventMetadata("CTLSDTVOUCHERLINK.CLICK",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Gxv8',iparms:[]");
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
         AV5SDTPurchaseOrderGenerateList = new GXBaseCollection<SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem>( context, "SDTPurchaseOrderGenerateListItem", "mtaKB");
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
         bttNeworder_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV11Orders = new GXBCCollection<SdtPurchaseOrder>( context, "PurchaseOrder", "mtaKB");
         AV19WebSession = context.GetSession();
         AV6window = new GXWindow();
         AV12Order = new SdtPurchaseOrder(context);
         scmdbuf = "";
         H004I2_A4SupplierId = new int[1] ;
         H004I2_A8SupplierEmail = new string[] {""} ;
         H004I2_n8SupplierEmail = new bool[] {false} ;
         H004I2_A5SupplierName = new string[] {""} ;
         A8SupplierEmail = "";
         A5SupplierName = "";
         AV14URLs = new GxSimpleCollection<string>();
         AV15NamesAttachs = new GxSimpleCollection<string>();
         AV24EmailTitle = "";
         AV25EmailSubtitle = "";
         AV10BodyMsg = "";
         AV23BodyMsgAux = "";
         GXt_char1 = "";
         AV16SDTPurchaseOrderGenerateItem = new SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem(context);
         AV17BaseURL = "";
         AV21ImageName2 = "";
         AV22ImageName3 = "";
         AV18HTTPRequest = new GxHttpRequest( context);
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wppurchaseordergenerated__default(),
            new Object[][] {
                new Object[] {
               H004I2_A4SupplierId, H004I2_A8SupplierEmail, H004I2_n8SupplierEmail, H004I2_A5SupplierName
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavCtlpurchaseorderid_Enabled = 0;
         edtavCtlsuppliername_Enabled = 0;
         edtavCtlpurchaseorderdetailsquantity_Enabled = 0;
         edtavCtldetailslink_Enabled = 0;
         edtavCtlsdtvoucherlink_Enabled = 0;
         edtavCtlcreateddate_Enabled = 0;
         edtavCtlcloseddate_Enabled = 0;
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid1_Backcolorstyle ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private short GRID1_nEOF ;
      private int nRC_GXsfl_21 ;
      private int nGXsfl_21_idx=1 ;
      private int AV28GXV1 ;
      private int subGrid1_Islastpage ;
      private int edtavCtlpurchaseorderid_Enabled ;
      private int edtavCtlsuppliername_Enabled ;
      private int edtavCtlpurchaseorderdetailsquantity_Enabled ;
      private int edtavCtldetailslink_Enabled ;
      private int edtavCtlsdtvoucherlink_Enabled ;
      private int edtavCtlcreateddate_Enabled ;
      private int edtavCtlcloseddate_Enabled ;
      private int nGXsfl_21_fel_idx=1 ;
      private int AV36GXV9 ;
      private int A4SupplierId ;
      private int AV13PurchaseOrderId ;
      private int AV38GXV10 ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nFirstRecordOnPage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_21_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTable2_Internalname ;
      private string divTable3_Internalname ;
      private string TempTags ;
      private string bttNeworder_Internalname ;
      private string bttNeworder_Jsonclick ;
      private string divTable4_Internalname ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavCtlpurchaseorderid_Internalname ;
      private string edtavCtlsuppliername_Internalname ;
      private string edtavCtlpurchaseorderdetailsquantity_Internalname ;
      private string edtavCtldetailslink_Internalname ;
      private string edtavCtlsdtvoucherlink_Internalname ;
      private string edtavCtlcreateddate_Internalname ;
      private string edtavCtlcloseddate_Internalname ;
      private string sGXsfl_21_fel_idx="0001" ;
      private string scmdbuf ;
      private string GXt_char1 ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string ROClassString ;
      private string edtavCtlpurchaseorderid_Jsonclick ;
      private string edtavCtlsuppliername_Jsonclick ;
      private string edtavCtlpurchaseorderdetailsquantity_Jsonclick ;
      private string edtavCtldetailslink_Jsonclick ;
      private string edtavCtlsdtvoucherlink_Jsonclick ;
      private string edtavCtlcreateddate_Jsonclick ;
      private string edtavCtlcloseddate_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_21_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool n8SupplierEmail ;
      private bool AV9AllOk ;
      private bool gx_BV21 ;
      private string A8SupplierEmail ;
      private string A5SupplierName ;
      private string AV24EmailTitle ;
      private string AV25EmailSubtitle ;
      private string AV10BodyMsg ;
      private string AV23BodyMsgAux ;
      private string AV17BaseURL ;
      private string AV21ImageName2 ;
      private string AV22ImageName3 ;
      private IGxSession AV19WebSession ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] H004I2_A4SupplierId ;
      private string[] H004I2_A8SupplierEmail ;
      private bool[] H004I2_n8SupplierEmail ;
      private string[] H004I2_A5SupplierName ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV18HTTPRequest ;
      private GxSimpleCollection<string> AV14URLs ;
      private GxSimpleCollection<string> AV15NamesAttachs ;
      private GXBCCollection<SdtPurchaseOrder> AV11Orders ;
      private GXBaseCollection<SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem> AV5SDTPurchaseOrderGenerateList ;
      private GXWebForm Form ;
      private GXWindow AV6window ;
      private SdtPurchaseOrder AV12Order ;
      private SdtSDTPurchaseOrderGenerateList_SDTPurchaseOrderGenerateListItem AV16SDTPurchaseOrderGenerateItem ;
   }

   public class wppurchaseordergenerated__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH004I2;
          prmH004I2 = new Object[] {
          new ParDef("@AV12Order__Supplierid",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("H004I2", "SELECT [SupplierId], [SupplierEmail], [SupplierName] FROM [Supplier] WHERE [SupplierId] = @AV12Order__Supplierid ORDER BY [SupplierId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004I2,1, GxCacheFrequency.OFF ,true,true )
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
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                return;
       }
    }

 }

}
