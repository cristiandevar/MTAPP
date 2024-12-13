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
   public class wpconfirm : GXDataArea
   {
      public wpconfirm( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public wpconfirm( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Messagge ,
                           ref string aP1_CaptionConfirm ,
                           ref string aP2_CaptionCancel ,
                           out bool aP3_Answer )
      {
         this.AV7Messagge = aP0_Messagge;
         this.AV5CaptionConfirm = aP1_CaptionConfirm;
         this.AV6CaptionCancel = aP2_CaptionCancel;
         this.AV8Answer = false ;
         executePrivate();
         aP1_CaptionConfirm=this.AV5CaptionConfirm;
         aP2_CaptionCancel=this.AV6CaptionCancel;
         aP3_Answer=this.AV8Answer;
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
            gxfirstwebparm = GetFirstPar( "Messagge");
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
               gxfirstwebparm = GetFirstPar( "Messagge");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "Messagge");
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
               AV7Messagge = gxfirstwebparm;
               AssignAttri("", false, "AV7Messagge", AV7Messagge);
               GxWebStd.gx_hidden_field( context, "gxhash_vMESSAGGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7Messagge, "")), context));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV5CaptionConfirm = GetPar( "CaptionConfirm");
                  AssignAttri("", false, "AV5CaptionConfirm", AV5CaptionConfirm);
                  GxWebStd.gx_hidden_field( context, "gxhash_vCAPTIONCONFIRM", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV5CaptionConfirm, "")), context));
                  AV6CaptionCancel = GetPar( "CaptionCancel");
                  AssignAttri("", false, "AV6CaptionCancel", AV6CaptionCancel);
                  GxWebStd.gx_hidden_field( context, "gxhash_vCAPTIONCANCEL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6CaptionCancel, "")), context));
                  AV8Answer = StringUtil.StrToBool( GetPar( "Answer"));
                  AssignAttri("", false, "AV8Answer", AV8Answer);
               }
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
         PA3M2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3M2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpconfirm.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV7Messagge)),UrlEncode(StringUtil.RTrim(AV5CaptionConfirm)),UrlEncode(StringUtil.RTrim(AV6CaptionCancel)),UrlEncode(StringUtil.BoolToStr(AV8Answer))}, new string[] {"Messagge","CaptionConfirm","CaptionCancel","Answer"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vCAPTIONCANCEL", AV6CaptionCancel);
         GxWebStd.gx_hidden_field( context, "gxhash_vCAPTIONCANCEL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6CaptionCancel, "")), context));
         GxWebStd.gx_hidden_field( context, "vCAPTIONCONFIRM", AV5CaptionConfirm);
         GxWebStd.gx_hidden_field( context, "gxhash_vCAPTIONCONFIRM", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV5CaptionConfirm, "")), context));
         GxWebStd.gx_hidden_field( context, "vMESSAGGE", AV7Messagge);
         GxWebStd.gx_hidden_field( context, "gxhash_vMESSAGGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7Messagge, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vCAPTIONCANCEL", AV6CaptionCancel);
         GxWebStd.gx_hidden_field( context, "gxhash_vCAPTIONCANCEL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6CaptionCancel, "")), context));
         GxWebStd.gx_hidden_field( context, "vCAPTIONCONFIRM", AV5CaptionConfirm);
         GxWebStd.gx_hidden_field( context, "gxhash_vCAPTIONCONFIRM", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV5CaptionConfirm, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vANSWER", AV8Answer);
         GxWebStd.gx_hidden_field( context, "vMESSAGGE", AV7Messagge);
         GxWebStd.gx_hidden_field( context, "gxhash_vMESSAGGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7Messagge, "")), context));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", "notset");
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
            WE3M2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3M2( ) ;
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
         return formatLink("wpconfirm.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV7Messagge)),UrlEncode(StringUtil.RTrim(AV5CaptionConfirm)),UrlEncode(StringUtil.RTrim(AV6CaptionCancel)),UrlEncode(StringUtil.BoolToStr(AV8Answer))}, new string[] {"Messagge","CaptionConfirm","CaptionCancel","Answer"})  ;
      }

      public override string GetPgmname( )
      {
         return "WPConfirm" ;
      }

      public override string GetPgmdesc( )
      {
         return "Confirm" ;
      }

      protected void WB3M0( )
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
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, divMaintable_Width, "px", divMaintable_Height, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 PromptAdvancedBarCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "AdvancedContainerVisible", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table1_9_3M2( true) ;
         }
         else
         {
            wb_table1_9_3M2( false) ;
         }
         return  ;
      }

      protected void wb_table1_9_3M2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table2_24_3M2( true) ;
         }
         else
         {
            wb_table2_24_3M2( false) ;
         }
         return  ;
      }

      protected void wb_table2_24_3M2e( bool wbgen )
      {
         if ( wbgen )
         {
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

      protected void START3M2( )
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
            Form.Meta.addItem("description", "Confirm", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3M0( ) ;
      }

      protected void WS3M2( )
      {
         START3M2( ) ;
         EVT3M2( ) ;
      }

      protected void EVT3M2( )
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
                              E113M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CONFIRM'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Confirm' */
                              E123M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CANCEL'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Cancel' */
                              E133M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E143M2 ();
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

      protected void WE3M2( )
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

      protected void PA3M2( )
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
         RF3M2( ) ;
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

      protected void RF3M2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E143M2 ();
            WB3M0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes3M2( )
      {
         GxWebStd.gx_hidden_field( context, "vCAPTIONCANCEL", AV6CaptionCancel);
         GxWebStd.gx_hidden_field( context, "gxhash_vCAPTIONCANCEL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6CaptionCancel, "")), context));
         GxWebStd.gx_hidden_field( context, "vCAPTIONCONFIRM", AV5CaptionConfirm);
         GxWebStd.gx_hidden_field( context, "gxhash_vCAPTIONCONFIRM", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV5CaptionConfirm, "")), context));
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3M0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E113M2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
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
         E113M2 ();
         if (returnInSub) return;
      }

      protected void E113M2( )
      {
         /* Start Routine */
         returnInSub = false;
         lblQuestionmessagge_Caption = AV7Messagge;
         AssignProp("", false, lblQuestionmessagge_Internalname, "Caption", lblQuestionmessagge_Caption, true);
         bttBtnconfirm_Caption = AV5CaptionConfirm;
         AssignProp("", false, bttBtnconfirm_Internalname, "Caption", bttBtnconfirm_Caption, true);
         bttBtncancel_Caption = AV6CaptionCancel;
         AssignProp("", false, bttBtncancel_Internalname, "Caption", bttBtncancel_Caption, true);
         divMaintable_Height = 10;
         AssignProp("", false, divMaintable_Internalname, "Height", StringUtil.LTrimStr( (decimal)(divMaintable_Height), 9, 0), true);
         divMaintable_Width = 30;
         AssignProp("", false, divMaintable_Internalname, "Width", StringUtil.LTrimStr( (decimal)(divMaintable_Width), 9, 0), true);
         AV8Answer = false;
         AssignAttri("", false, "AV8Answer", AV8Answer);
      }

      protected void E123M2( )
      {
         /* 'Confirm' Routine */
         returnInSub = false;
         AV8Answer = true;
         AssignAttri("", false, "AV8Answer", AV8Answer);
         context.setWebReturnParms(new Object[] {(string)AV5CaptionConfirm,(string)AV6CaptionCancel,(bool)AV8Answer});
         context.setWebReturnParmsMetadata(new Object[] {"AV5CaptionConfirm","AV6CaptionCancel","AV8Answer"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      protected void E133M2( )
      {
         /* 'Cancel' Routine */
         returnInSub = false;
         context.setWebReturnParms(new Object[] {(string)AV5CaptionConfirm,(string)AV6CaptionCancel,(bool)AV8Answer});
         context.setWebReturnParmsMetadata(new Object[] {"AV5CaptionConfirm","AV6CaptionCancel","AV8Answer"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void nextLoad( )
      {
      }

      protected void E143M2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table2_24_3M2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable2_Internalname, tblTable2_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnconfirm_Internalname, "", bttBtnconfirm_Caption, bttBtnconfirm_Jsonclick, 5, "Confirm", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CONFIRM\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPConfirm.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", bttBtncancel_Caption, bttBtncancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPConfirm.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_24_3M2e( true) ;
         }
         else
         {
            wb_table2_24_3M2e( false) ;
         }
      }

      protected void wb_table1_9_3M2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable1_Internalname, tblTable1_Internalname, "", "AdvancedContainerItem", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"Center\" colspan=\"20\" rowspan=\"5\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-Center;text-align:-moz-Center;text-align:-webkit-Center;vertical-align:Middle")+"\" class='eading-03'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblQuestionmessagge_Internalname, lblQuestionmessagge_Caption, "", "", lblQuestionmessagge_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-03", 0, "", 1, 1, 0, 0, "HLP_WPConfirm.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_9_3M2e( true) ;
         }
         else
         {
            wb_table1_9_3M2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV7Messagge = (string)getParm(obj,0);
         AssignAttri("", false, "AV7Messagge", AV7Messagge);
         GxWebStd.gx_hidden_field( context, "gxhash_vMESSAGGE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7Messagge, "")), context));
         AV5CaptionConfirm = (string)getParm(obj,1);
         AssignAttri("", false, "AV5CaptionConfirm", AV5CaptionConfirm);
         GxWebStd.gx_hidden_field( context, "gxhash_vCAPTIONCONFIRM", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV5CaptionConfirm, "")), context));
         AV6CaptionCancel = (string)getParm(obj,2);
         AssignAttri("", false, "AV6CaptionCancel", AV6CaptionCancel);
         GxWebStd.gx_hidden_field( context, "gxhash_vCAPTIONCANCEL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6CaptionCancel, "")), context));
         AV8Answer = (bool)getParm(obj,3);
         AssignAttri("", false, "AV8Answer", AV8Answer);
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
         PA3M2( ) ;
         WS3M2( ) ;
         WE3M2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202411152133625", true, true);
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
         context.AddJavascriptSource("wpconfirm.js", "?202411152133625", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblQuestionmessagge_Internalname = "QUESTIONMESSAGGE";
         tblTable1_Internalname = "TABLE1";
         bttBtnconfirm_Internalname = "BTNCONFIRM";
         bttBtncancel_Internalname = "BTNCANCEL";
         tblTable2_Internalname = "TABLE2";
         divTablecontent_Internalname = "TABLECONTENT";
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
         bttBtncancel_Caption = "Cancel";
         bttBtnconfirm_Caption = "Confirm";
         lblQuestionmessagge_Caption = "Text Block";
         divMaintable_Height = 0;
         divMaintable_Width = 0;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Confirm";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV7Messagge',fld:'vMESSAGGE',pic:'',hsh:true},{av:'AV6CaptionCancel',fld:'vCAPTIONCANCEL',pic:'',hsh:true},{av:'AV5CaptionConfirm',fld:'vCAPTIONCONFIRM',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'CONFIRM'","{handler:'E123M2',iparms:[{av:'AV6CaptionCancel',fld:'vCAPTIONCANCEL',pic:'',hsh:true},{av:'AV5CaptionConfirm',fld:'vCAPTIONCONFIRM',pic:'',hsh:true}]");
         setEventMetadata("'CONFIRM'",",oparms:[{av:'AV8Answer',fld:'vANSWER',pic:''}]}");
         setEventMetadata("'CANCEL'","{handler:'E133M2',iparms:[{av:'AV8Answer',fld:'vANSWER',pic:''},{av:'AV6CaptionCancel',fld:'vCAPTIONCANCEL',pic:'',hsh:true},{av:'AV5CaptionConfirm',fld:'vCAPTIONCONFIRM',pic:'',hsh:true}]");
         setEventMetadata("'CANCEL'",",oparms:[]}");
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
         wcpOAV7Messagge = "";
         wcpOAV5CaptionConfirm = "";
         wcpOAV6CaptionCancel = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         sStyleString = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnconfirm_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         lblQuestionmessagge_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int divMaintable_Width ;
      private int divMaintable_Height ;
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
      private string divTablecontent_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string lblQuestionmessagge_Caption ;
      private string lblQuestionmessagge_Internalname ;
      private string bttBtnconfirm_Caption ;
      private string bttBtnconfirm_Internalname ;
      private string bttBtncancel_Caption ;
      private string bttBtncancel_Internalname ;
      private string sStyleString ;
      private string tblTable2_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnconfirm_Jsonclick ;
      private string bttBtncancel_Jsonclick ;
      private string tblTable1_Internalname ;
      private string lblQuestionmessagge_Jsonclick ;
      private bool AV8Answer ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV7Messagge ;
      private string AV5CaptionConfirm ;
      private string AV6CaptionCancel ;
      private string wcpOAV7Messagge ;
      private string wcpOAV5CaptionConfirm ;
      private string wcpOAV6CaptionCancel ;
      private IGxDataStore dsDefault ;
      private string aP1_CaptionConfirm ;
      private string aP2_CaptionCancel ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private bool aP3_Answer ;
      private GXWebForm Form ;
   }

}
