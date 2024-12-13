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
   public class purchaseorderconfirmated : GXDataArea
   {
      public purchaseorderconfirmated( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public purchaseorderconfirmated( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_PurchaseOrderId )
      {
         this.AV15PurchaseOrderId = aP0_PurchaseOrderId;
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
            gxfirstwebparm = GetFirstPar( "PurchaseOrderId");
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
               gxfirstwebparm = GetFirstPar( "PurchaseOrderId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "PurchaseOrderId");
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
               AV15PurchaseOrderId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV15PurchaseOrderId", StringUtil.LTrimStr( (decimal)(AV15PurchaseOrderId), 6, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vPURCHASEORDERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15PurchaseOrderId), "ZZZZZ9"), context));
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("general.ui.masterguest", "GeneXus.Programs.general.ui.masterguest", new Object[] {context});
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
         PA3O2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3O2( ) ;
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("purchaseorderconfirmated.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV15PurchaseOrderId,6,0))}, new string[] {"PurchaseOrderId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPURCHASEORDERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15PurchaseOrderId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPURCHASEORDERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15PurchaseOrderId), "ZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"PurchaseOrderConfirmated");
         forbiddenHiddens.Add("PurchaseOrderCreatedDate", context.localUtil.Format(A52PurchaseOrderCreatedDate, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("purchaseorderconfirmated:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vPURCHASEORDERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15PurchaseOrderId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPURCHASEORDERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15PurchaseOrderId), "ZZZZZ9"), context));
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
            WE3O2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3O2( ) ;
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
         return formatLink("purchaseorderconfirmated.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV15PurchaseOrderId,6,0))}, new string[] {"PurchaseOrderId"})  ;
      }

      public override string GetPgmname( )
      {
         return "PurchaseOrderConfirmated" ;
      }

      public override string GetPgmdesc( )
      {
         return "Purchase Order Confirmated" ;
      }

      protected void WB3O0( )
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
            GxWebStd.gx_div_start( context, divTabletop_Internalname, 1, 0, "px", 0, "px", "ww__actions-container", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTitletext_Internalname, lblTitletext_Caption, "", "", lblTitletext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextblockMedium", 0, "", 1, 1, 0, 0, "HLP_PurchaseOrderConfirmated.htm");
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
            GxWebStd.gx_div_start( context, divTablefixeddata_1_Internalname, 1, 0, "px", 0, "px", "Flex ww__view__title-table", "left", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", " "+"classref"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtPurchaseOrderCreatedDate_Internalname, "Created Date", "gx-form-item heading-01Label", 0, true, "width: 25%;");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtPurchaseOrderCreatedDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtPurchaseOrderCreatedDate_Internalname, context.localUtil.Format(A52PurchaseOrderCreatedDate, "99/99/99"), context.localUtil.Format( A52PurchaseOrderCreatedDate, "99/99/99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPurchaseOrderCreatedDate_Jsonclick, 0, "heading-01", "", "", "", "", 1, edtPurchaseOrderCreatedDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "PurchaseOrderDate", "right", false, "", "HLP_PurchaseOrderConfirmated.htm");
            GxWebStd.gx_bitmap( context, edtPurchaseOrderCreatedDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPurchaseOrderCreatedDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_PurchaseOrderConfirmated.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table1_18_3O2( true) ;
         }
         else
         {
            wb_table1_18_3O2( false) ;
         }
         return  ;
      }

      protected void wb_table1_18_3O2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START3O2( )
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
            Form.Meta.addItem("description", "Purchase Order Confirmated", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3O0( ) ;
      }

      protected void WS3O2( )
      {
         START3O2( ) ;
         EVT3O2( ) ;
      }

      protected void EVT3O2( )
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
                              E113O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E123O2 ();
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

      protected void WE3O2( )
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

      protected void PA3O2( )
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
         RF3O2( ) ;
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

      protected void RF3O2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H003O2 */
            pr_default.execute(0, new Object[] {AV15PurchaseOrderId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A50PurchaseOrderId = H003O2_A50PurchaseOrderId[0];
               A52PurchaseOrderCreatedDate = H003O2_A52PurchaseOrderCreatedDate[0];
               AssignAttri("", false, "A52PurchaseOrderCreatedDate", context.localUtil.Format(A52PurchaseOrderCreatedDate, "99/99/99"));
               /* Execute user event: Load */
               E123O2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB3O0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes3O2( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3O0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E113O2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            A52PurchaseOrderCreatedDate = context.localUtil.CToD( cgiGet( edtPurchaseOrderCreatedDate_Internalname), 1);
            AssignAttri("", false, "A52PurchaseOrderCreatedDate", context.localUtil.Format(A52PurchaseOrderCreatedDate, "99/99/99"));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"PurchaseOrderConfirmated");
            A52PurchaseOrderCreatedDate = context.localUtil.CToD( cgiGet( edtPurchaseOrderCreatedDate_Internalname), 1);
            AssignAttri("", false, "A52PurchaseOrderCreatedDate", context.localUtil.Format(A52PurchaseOrderCreatedDate, "99/99/99"));
            forbiddenHiddens.Add("PurchaseOrderCreatedDate", context.localUtil.Format(A52PurchaseOrderCreatedDate, "99/99/99"));
            hsh = cgiGet( "hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("purchaseorderconfirmated:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               return  ;
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
         E113O2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E113O2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV27GXLvl3 = 0;
         /* Using cursor H003O3 */
         pr_default.execute(1, new Object[] {AV15PurchaseOrderId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A4SupplierId = H003O3_A4SupplierId[0];
            A79PurchaseOrderActive = H003O3_A79PurchaseOrderActive[0];
            A50PurchaseOrderId = H003O3_A50PurchaseOrderId[0];
            A5SupplierName = H003O3_A5SupplierName[0];
            A52PurchaseOrderCreatedDate = H003O3_A52PurchaseOrderCreatedDate[0];
            AssignAttri("", false, "A52PurchaseOrderCreatedDate", context.localUtil.Format(A52PurchaseOrderCreatedDate, "99/99/99"));
            A5SupplierName = H003O3_A5SupplierName[0];
            AV27GXLvl3 = 1;
            lblTitletext_Caption = lblTitletext_Caption+A5SupplierName;
            AssignProp("", false, lblTitletext_Internalname, "Caption", lblTitletext_Caption, true);
            AV17SupplierName = A5SupplierName;
            AV14PurchaseOrderCreatedDate = A52PurchaseOrderCreatedDate;
            AV8Exists = true;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         if ( AV27GXLvl3 == 0 )
         {
            AV8Exists = false;
            AV17SupplierName = "Not Found";
            AV14PurchaseOrderCreatedDate = DateTime.MinValue;
         }
         if ( ! AV8Exists )
         {
            CallWebObject(formatLink("wplogin.aspx") );
            context.wjLocDisableFrm = 1;
         }
         AV7EmailBody = "";
         AV11MeEmail = "mtappcontact@gmail.com";
         AV22Answer = false;
         AV23ButtonURL = AV24HttpRequest.BaseURL;
         AV23ButtonURL += formatLink("purchaseordersupplierview.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV15PurchaseOrderId,6,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"PurchaseOrderId","MesaggeError"}) ;
         AV6ConfirmedDate = DateTimeUtil.ServerDate( context, pr_default);
         AV7EmailBody += "<h5>Order Confirmed</h5>";
         AV7EmailBody += "<p>Supplier:" + StringUtil.Trim( AV17SupplierName) + "</p></br>";
         AV7EmailBody += "<p>Order Nro:" + StringUtil.Str( (decimal)(AV15PurchaseOrderId), 6, 0) + "</p></br>";
         AV7EmailBody += "<p>Date Ordered:" + context.localUtil.Format( AV14PurchaseOrderCreatedDate, "99/99/99") + "</p></br>";
         AV7EmailBody += "<p>Date Confirmated:" + context.localUtil.Format( AV6ConfirmedDate, "99/99/9999") + "</p></br>";
         AV7EmailBody += "<a href=\"";
         AV7EmailBody += StringUtil.RTrim( context.localUtil.Format( AV23ButtonURL, ""));
         AV7EmailBody += "\" target=\"_blank\" class=\"btn btn-info\"";
         AV7EmailBody += ">See PurchaseOrder</a>";
         AV21URLs = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV21URLs.Add(formatLink("apurchaseordergenerateattach.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV15PurchaseOrderId,6,0))}, new string[] {"PurchaseOrderId"}) , 0);
         AV12NamesOfAttachs.Add("Voucher_"+StringUtil.Trim( StringUtil.Str( (decimal)(AV15PurchaseOrderId), 6, 0))+".pdf", 0);
         GXt_char1 = "Order Confirmed";
         new sendemail(context ).execute(  AV11MeEmail, ref  AV7EmailBody, ref  GXt_char1, ref  AV21URLs, ref  AV12NamesOfAttachs, ref  AV5AllOk) ;
         AssignAttri("", false, "AV5AllOk", AV5AllOk);
         if ( AV5AllOk )
         {
            lblMessagge_Caption = "Purchase Order was Confirmed succeffully";
            AssignProp("", false, lblMessagge_Internalname, "Caption", lblMessagge_Caption, true);
         }
         else
         {
            CallWebObject(formatLink("purchaseordersupplierview.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV15PurchaseOrderId,6,0)),UrlEncode(StringUtil.RTrim("Error: Purchase Order was not Confirmed"))}, new string[] {"PurchaseOrderId","MesaggeError"}) );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E123O2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_18_3O2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable2_Internalname, tblTable2_Internalname, "", "ww__grid-container", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblMessagge_Internalname, lblMessagge_Caption, "", "", lblMessagge_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_PurchaseOrderConfirmated.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_18_3O2e( true) ;
         }
         else
         {
            wb_table1_18_3O2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV15PurchaseOrderId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV15PurchaseOrderId", StringUtil.LTrimStr( (decimal)(AV15PurchaseOrderId), 6, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vPURCHASEORDERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15PurchaseOrderId), "ZZZZZ9"), context));
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
         PA3O2( ) ;
         WS3O2( ) ;
         WE3O2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024112411524815", true, true);
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
            context.AddJavascriptSource("purchaseorderconfirmated.js", "?2024112411524815", false, true);
         }
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTitletext_Internalname = "TITLETEXT";
         divTabletop_Internalname = "TABLETOP";
         edtPurchaseOrderCreatedDate_Internalname = "PURCHASEORDERCREATEDDATE";
         divTablefixeddata_1_Internalname = "TABLEFIXEDDATA_1";
         lblMessagge_Internalname = "MESSAGGE";
         tblTable2_Internalname = "TABLE2";
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
         lblMessagge_Caption = "Text Block";
         edtPurchaseOrderCreatedDate_Jsonclick = "";
         edtPurchaseOrderCreatedDate_Enabled = 0;
         lblTitletext_Caption = "Purchase Order to ";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Purchase Order Confirmated";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV15PurchaseOrderId',fld:'vPURCHASEORDERID',pic:'ZZZZZ9',hsh:true},{av:'A52PurchaseOrderCreatedDate',fld:'PURCHASEORDERCREATEDDATE',pic:''}]");
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
         forbiddenHiddens = new GXProperties();
         A52PurchaseOrderCreatedDate = DateTime.MinValue;
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTitletext_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         scmdbuf = "";
         H003O2_A50PurchaseOrderId = new int[1] ;
         H003O2_A52PurchaseOrderCreatedDate = new DateTime[] {DateTime.MinValue} ;
         hsh = "";
         H003O3_A4SupplierId = new int[1] ;
         H003O3_A79PurchaseOrderActive = new bool[] {false} ;
         H003O3_A50PurchaseOrderId = new int[1] ;
         H003O3_A5SupplierName = new string[] {""} ;
         H003O3_A52PurchaseOrderCreatedDate = new DateTime[] {DateTime.MinValue} ;
         A5SupplierName = "";
         AV17SupplierName = "";
         AV14PurchaseOrderCreatedDate = DateTime.MinValue;
         AV7EmailBody = "";
         AV11MeEmail = "";
         AV23ButtonURL = "";
         AV24HttpRequest = new GxHttpRequest( context);
         AV6ConfirmedDate = DateTime.MinValue;
         AV21URLs = new GxSimpleCollection<string>();
         AV12NamesOfAttachs = new GxSimpleCollection<string>();
         GXt_char1 = "";
         sStyleString = "";
         lblMessagge_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.purchaseorderconfirmated__default(),
            new Object[][] {
                new Object[] {
               H003O2_A50PurchaseOrderId, H003O2_A52PurchaseOrderCreatedDate
               }
               , new Object[] {
               H003O3_A4SupplierId, H003O3_A79PurchaseOrderActive, H003O3_A50PurchaseOrderId, H003O3_A5SupplierName, H003O3_A52PurchaseOrderCreatedDate
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV27GXLvl3 ;
      private int AV15PurchaseOrderId ;
      private int wcpOAV15PurchaseOrderId ;
      private int edtPurchaseOrderCreatedDate_Enabled ;
      private int A50PurchaseOrderId ;
      private int A4SupplierId ;
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
      private string divTabletop_Internalname ;
      private string lblTitletext_Internalname ;
      private string lblTitletext_Caption ;
      private string lblTitletext_Jsonclick ;
      private string divTablefixeddata_1_Internalname ;
      private string edtPurchaseOrderCreatedDate_Internalname ;
      private string edtPurchaseOrderCreatedDate_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string scmdbuf ;
      private string hsh ;
      private string GXt_char1 ;
      private string lblMessagge_Caption ;
      private string lblMessagge_Internalname ;
      private string sStyleString ;
      private string tblTable2_Internalname ;
      private string lblMessagge_Jsonclick ;
      private DateTime A52PurchaseOrderCreatedDate ;
      private DateTime AV14PurchaseOrderCreatedDate ;
      private DateTime AV6ConfirmedDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool A79PurchaseOrderActive ;
      private bool AV8Exists ;
      private bool AV22Answer ;
      private bool AV5AllOk ;
      private string A5SupplierName ;
      private string AV17SupplierName ;
      private string AV7EmailBody ;
      private string AV11MeEmail ;
      private string AV23ButtonURL ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] H003O2_A50PurchaseOrderId ;
      private DateTime[] H003O2_A52PurchaseOrderCreatedDate ;
      private int[] H003O3_A4SupplierId ;
      private bool[] H003O3_A79PurchaseOrderActive ;
      private int[] H003O3_A50PurchaseOrderId ;
      private string[] H003O3_A5SupplierName ;
      private DateTime[] H003O3_A52PurchaseOrderCreatedDate ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV24HttpRequest ;
      private GxSimpleCollection<string> AV21URLs ;
      private GxSimpleCollection<string> AV12NamesOfAttachs ;
      private GXWebForm Form ;
   }

   public class purchaseorderconfirmated__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH003O2;
          prmH003O2 = new Object[] {
          new ParDef("@AV15PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmH003O3;
          prmH003O3 = new Object[] {
          new ParDef("@AV15PurchaseOrderId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("H003O2", "SELECT [PurchaseOrderId], [PurchaseOrderCreatedDate] FROM [PurchaseOrder] WHERE [PurchaseOrderId] = @AV15PurchaseOrderId ORDER BY [PurchaseOrderId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003O2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H003O3", "SELECT T1.[SupplierId], T1.[PurchaseOrderActive], T1.[PurchaseOrderId], T2.[SupplierName], T1.[PurchaseOrderCreatedDate] FROM ([PurchaseOrder] T1 INNER JOIN [Supplier] T2 ON T2.[SupplierId] = T1.[SupplierId]) WHERE (T1.[PurchaseOrderId] = @AV15PurchaseOrderId) AND (T1.[PurchaseOrderActive] = 1) ORDER BY T1.[PurchaseOrderId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003O3,1, GxCacheFrequency.OFF ,false,true )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                return;
       }
    }

 }

}
