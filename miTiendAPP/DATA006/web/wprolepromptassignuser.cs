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
   public class wprolepromptassignuser : GXDataArea
   {
      public wprolepromptassignuser( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public wprolepromptassignuser( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_RoleId )
      {
         this.AV5RoleId = aP0_RoleId;
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
            gxfirstwebparm = GetFirstPar( "RoleId");
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
               gxfirstwebparm = GetFirstPar( "RoleId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "RoleId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
            {
               gxnrGrid_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
            {
               gxgrGrid_refresh_invoke( ) ;
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
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV5RoleId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV5RoleId", StringUtil.LTrimStr( (decimal)(AV5RoleId), 6, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5RoleId), "ZZZZZ9"), context));
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

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_31 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_31"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_31_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_31_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_31_idx = GetPar( "sGXsfl_31_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid_newrow( ) ;
         /* End function gxnrGrid_newrow_invoke */
      }

      protected void gxgrGrid_refresh_invoke( )
      {
         AV5RoleId = (int)(Math.Round(NumberUtil.Val( GetPar( "RoleId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( AV5RoleId) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
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
            MasterPageObj.setDataArea(this,true);
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
         PA3R2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3R2( ) ;
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
         context.AddJavascriptSource("Switch/switch.min.js", "", false, true);
         context.AddJavascriptSource("Switch/switch.min.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wprolepromptassignuser.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV5RoleId,6,0))}, new string[] {"RoleId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vROLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5RoleId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5RoleId), "ZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Sdtuser", AV32SDTUser);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Sdtuser", AV32SDTUser);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_31", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_31), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTUSERAUX", AV39SDTUserAux);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTUSERAUX", AV39SDTUserAux);
         }
         GxWebStd.gx_hidden_field( context, "vROLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5RoleId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5RoleId), "ZZZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTUSER", AV32SDTUser);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTUSER", AV32SDTUser);
         }
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
            WE3R2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3R2( ) ;
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
         return formatLink("wprolepromptassignuser.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV5RoleId,6,0))}, new string[] {"RoleId"})  ;
      }

      public override string GetPgmname( )
      {
         return "WPRolePromptAssignUser" ;
      }

      public override string GetPgmdesc( )
      {
         return "WPRole Prompt Assign User" ;
      }

      protected void WB3R0( )
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
            GxWebStd.gx_div_start( context, divMain_Internalname, 1, 0, "px", 0, "px", "ContainerFluid PromptContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "Flex ww__actions-container", "left", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", " "+"classref"+" ", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 10,'',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnconfirmar_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(31), 2, 0)+","+"null"+");", "Confirm", bttBtnconfirmar_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtnconfirmar_Visible, bttBtnconfirmar_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CONFIRM\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPRolePromptAssignUser.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 12,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(31), 2, 0)+","+"null"+");", "Cancel", bttBtncancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPRolePromptAssignUser.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", " "+"classref"+" ", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+edtavUsername_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_31_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsername_Internalname, AV37UserName, StringUtil.RTrim( context.localUtil.Format( AV37UserName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Name", edtavUsername_Jsonclick, 0, "attribute-search", "", "", "", "", 1, edtavUsername_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_WPRolePromptAssignUser.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 ww__grid-cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "container-fluid container-advanced", "left", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, divGridcontainer_Internalname, 1, 0, "px", 0, "px", "ww__grid-container", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Users", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPRolePromptAssignUser.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetIsFreestyle(true);
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl31( ) ;
         }
         if ( wbEnd == 31 )
         {
            wbEnd = 0;
            nRC_GXsfl_31 = (int)(nGXsfl_31_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV42GXV1 = nGXsfl_31_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
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
         if ( wbEnd == 31 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV42GXV1 = nGXsfl_31_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START3R2( )
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
            Form.Meta.addItem("description", "WPRole Prompt Assign User", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3R0( ) ;
      }

      protected void WS3R2( )
      {
         START3R2( ) ;
         EVT3R2( ) ;
      }

      protected void EVT3R2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "'CONFIRM'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Confirm' */
                              E113R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VUSERNAME.CONTROLVALUECHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E123R2 ();
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
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 8), "'CANCEL'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) )
                           {
                              nGXsfl_31_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_31_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_31_idx), 4, 0), 4, "0");
                              SubsflControlProps_312( ) ;
                              GXCCtl = "CTLSELECTED_Captionclass_" + sGXsfl_31_idx;
                              Ctlselected_Captionclass = cgiGet( GXCCtl);
                              ucCtlselected.SendProperty(context, "", false, Ctlselected_Internalname, "CaptionClass", Ctlselected_Captionclass);
                              GXCCtl = "CTLSELECTED_Captionstyle_" + sGXsfl_31_idx;
                              Ctlselected_Captionstyle = cgiGet( GXCCtl);
                              ucCtlselected.SendProperty(context, "", false, Ctlselected_Internalname, "CaptionStyle", Ctlselected_Captionstyle);
                              GXCCtl = "CTLSELECTED_Captionposition_" + sGXsfl_31_idx;
                              Ctlselected_Captionposition = cgiGet( GXCCtl);
                              ucCtlselected.SendProperty(context, "", false, Ctlselected_Internalname, "CaptionPosition", Ctlselected_Captionposition);
                              AV42GXV1 = nGXsfl_31_idx;
                              if ( ( AV32SDTUser.Count >= AV42GXV1 ) && ( AV42GXV1 > 0 ) )
                              {
                                 AV32SDTUser.CurrentItem = ((SdtSDTUser_SDTUserItem)AV32SDTUser.Item(AV42GXV1));
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
                                    E133R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'CANCEL'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'Cancel' */
                                    E143R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E153R2 ();
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

      protected void WE3R2( )
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

      protected void PA3R2( )
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

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_312( ) ;
         while ( nGXsfl_31_idx <= nRC_GXsfl_31 )
         {
            sendrow_312( ) ;
            nGXsfl_31_idx = ((subGrid_Islastpage==1)&&(nGXsfl_31_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_31_idx+1);
            sGXsfl_31_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_31_idx), 4, 0), 4, "0");
            SubsflControlProps_312( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int AV5RoleId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF3R2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
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
         RF3R2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV44Pgmname = "WPRolePromptAssignUser";
         context.Gx_err = 0;
         edtavCtlusername_Enabled = 0;
         AssignProp("", false, edtavCtlusername_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlusername_Enabled), 5, 0), !bGXsfl_31_Refreshing);
      }

      protected void RF3R2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 31;
         nGXsfl_31_idx = 1;
         sGXsfl_31_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_31_idx), 4, 0), 4, "0");
         SubsflControlProps_312( ) ;
         bGXsfl_31_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         GridContainer.AddObjectProperty("Class", "FreeStyleGrid");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_312( ) ;
            E153R2 ();
            wbEnd = 31;
            WB3R0( ) ;
         }
         bGXsfl_31_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3R2( )
      {
      }

      protected int subGrid_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         AV44Pgmname = "WPRolePromptAssignUser";
         context.Gx_err = 0;
         edtavCtlusername_Enabled = 0;
         AssignProp("", false, edtavCtlusername_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlusername_Enabled), 5, 0), !bGXsfl_31_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3R0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E133R2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Sdtuser"), AV32SDTUser);
            /* Read saved values. */
            nRC_GXsfl_31 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_31"), ".", ","), 18, MidpointRounding.ToEven));
            nRC_GXsfl_31 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_31"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_31_fel_idx = 0;
            while ( nGXsfl_31_fel_idx < nRC_GXsfl_31 )
            {
               nGXsfl_31_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_31_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_31_fel_idx+1);
               sGXsfl_31_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_31_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_312( ) ;
               GXCCtl = "CTLSELECTED_Captionclass_" + sGXsfl_31_fel_idx;
               Ctlselected_Captionclass = cgiGet( GXCCtl);
               GXCCtl = "CTLSELECTED_Captionstyle_" + sGXsfl_31_fel_idx;
               Ctlselected_Captionstyle = cgiGet( GXCCtl);
               GXCCtl = "CTLSELECTED_Captionposition_" + sGXsfl_31_fel_idx;
               Ctlselected_Captionposition = cgiGet( GXCCtl);
               AV42GXV1 = nGXsfl_31_fel_idx;
               if ( ( AV32SDTUser.Count >= AV42GXV1 ) && ( AV42GXV1 > 0 ) )
               {
                  AV32SDTUser.CurrentItem = ((SdtSDTUser_SDTUserItem)AV32SDTUser.Item(AV42GXV1));
               }
            }
            if ( nGXsfl_31_fel_idx == 0 )
            {
               nGXsfl_31_idx = 1;
               sGXsfl_31_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_31_idx), 4, 0), 4, "0");
               SubsflControlProps_312( ) ;
            }
            nGXsfl_31_fel_idx = 1;
            /* Read variables values. */
            AV37UserName = cgiGet( edtavUsername_Internalname);
            AssignAttri("", false, "AV37UserName", AV37UserName);
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
         E133R2 ();
         if (returnInSub) return;
      }

      protected void E133R2( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtSDTContextSession1 = new GeneXus.Programs.general.ui.SdtSDTContextSession();
         new checkauthentication(context ).execute( out  GXt_SdtSDTContextSession1) ;
         if ( ! new haspermission(context).executeUdp(  "user view") )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV44Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         if ( new haspermission(context).executeUdp(  "user update") )
         {
            bttBtnconfirmar_Visible = 1;
            AssignProp("", false, bttBtnconfirmar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnconfirmar_Visible), 5, 0), true);
            bttBtnconfirmar_Enabled = 1;
            AssignProp("", false, bttBtnconfirmar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtnconfirmar_Enabled), 5, 0), true);
         }
         else
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV44Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV32SDTUser = new GXBaseCollection<SdtSDTUser_SDTUserItem>( context, "SDTUserItem", "mtaKB");
         gx_BV31 = true;
         AV28OriginalPosition = 1;
         /* Using cursor H003R2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A111UserActive = H003R2_A111UserActive[0];
            n111UserActive = H003R2_n111UserActive[0];
            A99UserId = H003R2_A99UserId[0];
            A104RoleId = H003R2_A104RoleId[0];
            n104RoleId = H003R2_n104RoleId[0];
            A100UserName = H003R2_A100UserName[0];
            AV33SDTUserItem = new SdtSDTUser_SDTUserItem(context);
            AV33SDTUserItem.gxTpr_Userid = A99UserId;
            AV33SDTUserItem.gxTpr_Username = A100UserName;
            if ( A104RoleId == AV5RoleId )
            {
               AV33SDTUserItem.gxTpr_Selected = true;
            }
            else
            {
               AV33SDTUserItem.gxTpr_Selected = false;
            }
            AV33SDTUserItem.gxTpr_Originalposition = AV28OriginalPosition;
            AV32SDTUser.Add(AV33SDTUserItem, 0);
            gx_BV31 = true;
            AV28OriginalPosition = (short)(AV28OriginalPosition+1);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV39SDTUserAux = (GXBaseCollection<SdtSDTUser_SDTUserItem>)(AV32SDTUser.Clone());
      }

      protected void E143R2( )
      {
         /* 'Cancel' Routine */
         returnInSub = false;
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void E113R2( )
      {
         AV42GXV1 = nGXsfl_31_idx;
         if ( ( AV42GXV1 > 0 ) && ( AV32SDTUser.Count >= AV42GXV1 ) )
         {
            AV32SDTUser.CurrentItem = ((SdtSDTUser_SDTUserItem)AV32SDTUser.Item(AV42GXV1));
         }
         /* 'Confirm' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'SAVESDT' */
         S112 ();
         if (returnInSub) return;
         AV46GXV3 = 1;
         while ( AV46GXV3 <= AV39SDTUserAux.Count )
         {
            AV33SDTUserItem = ((SdtSDTUser_SDTUserItem)AV39SDTUserAux.Item(AV46GXV3));
            AV36User.Load(AV33SDTUserItem.gxTpr_Userid);
            if ( AV33SDTUserItem.gxTpr_Selected )
            {
               if ( ! ( AV36User.gxTpr_Roleid == AV5RoleId ) )
               {
                  AV36User.gxTpr_Roleid = AV5RoleId;
                  AV36User.Save();
                  if ( AV36User.Success() )
                  {
                     context.CommitDataStores("wprolepromptassignuser",pr_default);
                  }
                  else
                  {
                     GX_msglist.addItem("User assigned Fail: "+AV36User.GetMessages().ToJSonString(false));
                     context.RollbackDataStores("wprolepromptassignuser",pr_default);
                  }
               }
            }
            else
            {
               if ( AV36User.gxTpr_Roleid == AV5RoleId )
               {
                  AV36User.gxTv_SdtUser_Roleid_SetNull();
                  AV36User.Save();
                  if ( AV36User.Success() )
                  {
                     context.CommitDataStores("wprolepromptassignuser",pr_default);
                  }
                  else
                  {
                     GX_msglist.addItem("User assigned Fail: "+AV36User.GetMessages().ToJSonString(false));
                     context.RollbackDataStores("wprolepromptassignuser",pr_default);
                  }
               }
            }
            AV46GXV3 = (int)(AV46GXV3+1);
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39SDTUserAux", AV39SDTUserAux);
      }

      protected void E123R2( )
      {
         AV42GXV1 = nGXsfl_31_idx;
         if ( ( AV42GXV1 > 0 ) && ( AV32SDTUser.Count >= AV42GXV1 ) )
         {
            AV32SDTUser.CurrentItem = ((SdtSDTUser_SDTUserItem)AV32SDTUser.Item(AV42GXV1));
         }
         /* Username_Controlvaluechanged Routine */
         returnInSub = false;
         /* Execute user subroutine: 'SAVESDT' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'CHARGESDT' */
         S122 ();
         if (returnInSub) return;
         gxgrGrid_refresh( AV5RoleId) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV39SDTUserAux", AV39SDTUserAux);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32SDTUser", AV32SDTUser);
         nGXsfl_31_bak_idx = nGXsfl_31_idx;
         gxgrGrid_refresh( AV5RoleId) ;
         nGXsfl_31_idx = nGXsfl_31_bak_idx;
         sGXsfl_31_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_31_idx), 4, 0), 4, "0");
         SubsflControlProps_312( ) ;
      }

      protected void S112( )
      {
         /* 'SAVESDT' Routine */
         returnInSub = false;
         AV47GXV4 = 1;
         while ( AV47GXV4 <= AV32SDTUser.Count )
         {
            AV33SDTUserItem = ((SdtSDTUser_SDTUserItem)AV32SDTUser.Item(AV47GXV4));
            AV29Position = AV33SDTUserItem.gxTpr_Originalposition;
            AV38SDTUserItemAux = ((SdtSDTUser_SDTUserItem)AV39SDTUserAux.Item(AV29Position));
            AV38SDTUserItemAux.gxTpr_Selected = AV33SDTUserItem.gxTpr_Selected;
            AV47GXV4 = (int)(AV47GXV4+1);
         }
      }

      protected void S122( )
      {
         /* 'CHARGESDT' Routine */
         returnInSub = false;
         AV32SDTUser.Clear();
         gx_BV31 = true;
         AV25Count = 1;
         AV48GXV5 = 1;
         while ( AV48GXV5 <= AV39SDTUserAux.Count )
         {
            AV38SDTUserItemAux = ((SdtSDTUser_SDTUserItem)AV39SDTUserAux.Item(AV48GXV5));
            if ( ( StringUtil.Like( AV38SDTUserItemAux.gxTpr_Username , StringUtil.PadR( "%" + AV37UserName + "%" , 22 , "%"),  ' ' ) ) )
            {
               AV33SDTUserItem = new SdtSDTUser_SDTUserItem(context);
               AV33SDTUserItem.gxTpr_Userid = AV38SDTUserItemAux.gxTpr_Userid;
               AV33SDTUserItem.gxTpr_Username = AV38SDTUserItemAux.gxTpr_Username;
               AV33SDTUserItem.gxTpr_Selected = AV38SDTUserItemAux.gxTpr_Selected;
               AV33SDTUserItem.gxTpr_Originalposition = AV38SDTUserItemAux.gxTpr_Originalposition;
               AV32SDTUser.Add(AV33SDTUserItem, 0);
               gx_BV31 = true;
            }
            AV25Count = (short)(AV25Count+1);
            AV48GXV5 = (int)(AV48GXV5+1);
         }
      }

      private void E153R2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV42GXV1 = 1;
         while ( AV42GXV1 <= AV32SDTUser.Count )
         {
            AV32SDTUser.CurrentItem = ((SdtSDTUser_SDTUserItem)AV32SDTUser.Item(AV42GXV1));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 31;
            }
            sendrow_312( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_31_Refreshing )
            {
               DoAjaxLoad(31, GridRow);
            }
            AV42GXV1 = (int)(AV42GXV1+1);
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV5RoleId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV5RoleId", StringUtil.LTrimStr( (decimal)(AV5RoleId), 6, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5RoleId), "ZZZZZ9"), context));
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
         PA3R2( ) ;
         WS3R2( ) ;
         WE3R2( ) ;
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
         AddStyleSheetFile("Switch/switch.min.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20241261113329", true, true);
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
         context.AddJavascriptSource("wprolepromptassignuser.js", "?20241261113329", false, true);
         context.AddJavascriptSource("Switch/switch.min.js", "", false, true);
         context.AddJavascriptSource("Switch/switch.min.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_312( )
      {
         edtavCtlusername_Internalname = "CTLUSERNAME_"+sGXsfl_31_idx;
         Ctlselected_Internalname = "CTLSELECTED_"+sGXsfl_31_idx;
      }

      protected void SubsflControlProps_fel_312( )
      {
         edtavCtlusername_Internalname = "CTLUSERNAME_"+sGXsfl_31_fel_idx;
         Ctlselected_Internalname = "CTLSELECTED_"+sGXsfl_31_fel_idx;
      }

      protected void sendrow_312( )
      {
         SubsflControlProps_312( ) ;
         WB3R0( ) ;
         GridRow = GXWebRow.GetNew(context,GridContainer);
         if ( subGrid_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGrid_Backstyle = 0;
            if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
            {
               subGrid_Linesclass = subGrid_Class+"Odd";
            }
         }
         else if ( subGrid_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGrid_Backstyle = 0;
            subGrid_Backcolor = subGrid_Allbackcolor;
            if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
            {
               subGrid_Linesclass = subGrid_Class+"Uniform";
            }
         }
         else if ( subGrid_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGrid_Backstyle = 1;
            if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
            {
               subGrid_Linesclass = subGrid_Class+"Odd";
            }
            subGrid_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subGrid_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGrid_Backstyle = 1;
            if ( ((int)((nGXsfl_31_idx) % (2))) == 0 )
            {
               subGrid_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Even";
               }
            }
            else
            {
               subGrid_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subGrid_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_31_idx+"\">") ;
         }
         /* Div Control */
         GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divGrid1table_Internalname+"_"+sGXsfl_31_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-6",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlusername_Internalname,(string)"User Name",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
         /* Single line edit */
         ROClassString = "Attribute";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlusername_Internalname,((SdtSDTUser_SDTUserItem)AV32SDTUser.Item(AV42GXV1)).gxTpr_Username,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlusername_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlusername_Enabled,(short)0,(string)"text",(string)"",(short)20,(string)"chr",(short)1,(string)"row",(short)20,(short)0,(short)0,(short)31,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-6",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* User Defined Control */
         GridRow.AddColumnProperties("usercontrol", -1, isAjaxCallMode( ), new Object[] {(string)"CTLSELECTEDContainer"+"_"+sGXsfl_31_idx,(short)-1});
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         send_integrity_lvl_hashes3R2( ) ;
         GXCCtl = "CTLSELECTED_Captionclass_" + sGXsfl_31_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Ctlselected_Captionclass));
         GXCCtl = "CTLSELECTED_Captionstyle_" + sGXsfl_31_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Ctlselected_Captionstyle));
         GXCCtl = "CTLSELECTED_Captionposition_" + sGXsfl_31_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Ctlselected_Captionposition));
         /* End of Columns property logic. */
         GridContainer.AddRow(GridRow);
         nGXsfl_31_idx = ((subGrid_Islastpage==1)&&(nGXsfl_31_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_31_idx+1);
         sGXsfl_31_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_31_idx), 4, 0), 4, "0");
         SubsflControlProps_312( ) ;
         /* End function sendrow_312 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl31( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"31\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            GridContainer.AddObjectProperty("Class", "FreeStyleGrid");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlusername_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridContainer.AddColumnProperties(GridColumn);
            GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         bttBtnconfirmar_Internalname = "BTNCONFIRMAR";
         bttBtncancel_Internalname = "BTNCANCEL";
         edtavUsername_Internalname = "vUSERNAME";
         divTable1_Internalname = "TABLE1";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         edtavCtlusername_Internalname = "CTLUSERNAME";
         Ctlselected_Internalname = "CTLSELECTED";
         divGrid1table_Internalname = "GRID1TABLE";
         divGridcontainer_Internalname = "GRIDCONTAINER";
         divGridtable_Internalname = "GRIDTABLE";
         divGridcell_Internalname = "GRIDCELL";
         divMain_Internalname = "MAIN";
         Form.Internalname = "FORM";
         subGrid_Internalname = "GRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("mtaKB", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid_Allowcollapsing = 0;
         edtavCtlusername_Jsonclick = "";
         edtavCtlusername_Enabled = 0;
         subGrid_Class = "FreeStyleGrid";
         subGrid_Backcolorstyle = 0;
         edtavCtlusername_Enabled = -1;
         Ctlselected_Captionposition = "None";
         Ctlselected_Captionstyle = "";
         Ctlselected_Captionclass = "col-sm-3 AttributeLabel";
         edtavUsername_Jsonclick = "";
         edtavUsername_Enabled = 1;
         bttBtnconfirmar_Enabled = 1;
         bttBtnconfirmar_Visible = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "WPRole Prompt Assign User";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV32SDTUser',fld:'vSDTUSER',grid:31,pic:''},{av:'nGXsfl_31_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:31},{av:'nRC_GXsfl_31',ctrl:'GRID',prop:'GridRC',grid:31},{av:'AV5RoleId',fld:'vROLEID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'CANCEL'","{handler:'E143R2',iparms:[]");
         setEventMetadata("'CANCEL'",",oparms:[]}");
         setEventMetadata("'CONFIRM'","{handler:'E113R2',iparms:[{av:'AV39SDTUserAux',fld:'vSDTUSERAUX',pic:''},{av:'AV5RoleId',fld:'vROLEID',pic:'ZZZZZ9',hsh:true},{av:'AV32SDTUser',fld:'vSDTUSER',grid:31,pic:''},{av:'nGXsfl_31_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:31},{av:'GRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_31',ctrl:'GRID',prop:'GridRC',grid:31}]");
         setEventMetadata("'CONFIRM'",",oparms:[{av:'AV39SDTUserAux',fld:'vSDTUSERAUX',pic:''}]}");
         setEventMetadata("VUSERNAME.CONTROLVALUECHANGED","{handler:'E123R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV32SDTUser',fld:'vSDTUSER',grid:31,pic:''},{av:'nGXsfl_31_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:31},{av:'nRC_GXsfl_31',ctrl:'GRID',prop:'GridRC',grid:31},{av:'AV5RoleId',fld:'vROLEID',pic:'ZZZZZ9',hsh:true},{av:'AV39SDTUserAux',fld:'vSDTUSERAUX',pic:''},{av:'AV37UserName',fld:'vUSERNAME',pic:''}]");
         setEventMetadata("VUSERNAME.CONTROLVALUECHANGED",",oparms:[{av:'AV39SDTUserAux',fld:'vSDTUSERAUX',pic:''},{av:'AV32SDTUser',fld:'vSDTUSER',grid:31,pic:''},{av:'nGXsfl_31_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:31},{av:'GRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_31',ctrl:'GRID',prop:'GridRC',grid:31}]}");
         setEventMetadata("NULL","{handler:'Validv_Gxv2',iparms:[]");
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
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV32SDTUser = new GXBaseCollection<SdtSDTUser_SDTUserItem>( context, "SDTUserItem", "mtaKB");
         AV39SDTUserAux = new GXBaseCollection<SdtSDTUser_SDTUserItem>( context, "SDTUserItem", "mtaKB");
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnconfirmar_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         AV37UserName = "";
         lblTextblock1_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXCCtl = "";
         ucCtlselected = new GXUserControl();
         AV44Pgmname = "";
         GXt_SdtSDTContextSession1 = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         scmdbuf = "";
         H003R2_A111UserActive = new bool[] {false} ;
         H003R2_n111UserActive = new bool[] {false} ;
         H003R2_A99UserId = new int[1] ;
         H003R2_A104RoleId = new int[1] ;
         H003R2_n104RoleId = new bool[] {false} ;
         H003R2_A100UserName = new string[] {""} ;
         A100UserName = "";
         AV33SDTUserItem = new SdtSDTUser_SDTUserItem(context);
         AV36User = new SdtUser(context);
         AV38SDTUserItemAux = new SdtSDTUser_SDTUserItem(context);
         GridRow = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         subGrid_Header = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wprolepromptassignuser__default(),
            new Object[][] {
                new Object[] {
               H003R2_A111UserActive, H003R2_n111UserActive, H003R2_A99UserId, H003R2_A104RoleId, H003R2_n104RoleId, H003R2_A100UserName
               }
            }
         );
         AV44Pgmname = "WPRolePromptAssignUser";
         /* GeneXus formulas. */
         AV44Pgmname = "WPRolePromptAssignUser";
         context.Gx_err = 0;
         edtavCtlusername_Enabled = 0;
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
      private short subGrid_Backcolorstyle ;
      private short AV28OriginalPosition ;
      private short GRID_nEOF ;
      private short AV29Position ;
      private short AV25Count ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int AV5RoleId ;
      private int wcpOAV5RoleId ;
      private int nRC_GXsfl_31 ;
      private int nGXsfl_31_idx=1 ;
      private int bttBtnconfirmar_Visible ;
      private int bttBtnconfirmar_Enabled ;
      private int edtavUsername_Enabled ;
      private int AV42GXV1 ;
      private int subGrid_Islastpage ;
      private int edtavCtlusername_Enabled ;
      private int nGXsfl_31_fel_idx=1 ;
      private int A99UserId ;
      private int A104RoleId ;
      private int AV46GXV3 ;
      private int nGXsfl_31_bak_idx=1 ;
      private int AV47GXV4 ;
      private int AV48GXV5 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nCurrentRecord ;
      private long GRID_nFirstRecordOnPage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_31_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divTable1_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnconfirmar_Internalname ;
      private string bttBtnconfirmar_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string edtavUsername_Internalname ;
      private string edtavUsername_Jsonclick ;
      private string divGridcell_Internalname ;
      private string divGridtable_Internalname ;
      private string divGridcontainer_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXCCtl ;
      private string Ctlselected_Captionclass ;
      private string Ctlselected_Internalname ;
      private string Ctlselected_Captionstyle ;
      private string Ctlselected_Captionposition ;
      private string AV44Pgmname ;
      private string edtavCtlusername_Internalname ;
      private string sGXsfl_31_fel_idx="0001" ;
      private string scmdbuf ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string divGrid1table_Internalname ;
      private string ROClassString ;
      private string edtavCtlusername_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_31_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_BV31 ;
      private bool A111UserActive ;
      private bool n111UserActive ;
      private bool n104RoleId ;
      private string AV37UserName ;
      private string A100UserName ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucCtlselected ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private bool[] H003R2_A111UserActive ;
      private bool[] H003R2_n111UserActive ;
      private int[] H003R2_A99UserId ;
      private int[] H003R2_A104RoleId ;
      private bool[] H003R2_n104RoleId ;
      private string[] H003R2_A100UserName ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<SdtSDTUser_SDTUserItem> AV32SDTUser ;
      private GXBaseCollection<SdtSDTUser_SDTUserItem> AV39SDTUserAux ;
      private GXWebForm Form ;
      private SdtSDTUser_SDTUserItem AV33SDTUserItem ;
      private SdtSDTUser_SDTUserItem AV38SDTUserItemAux ;
      private SdtUser AV36User ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession GXt_SdtSDTContextSession1 ;
   }

   public class wprolepromptassignuser__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH003R2;
          prmH003R2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H003R2", "SELECT [UserActive], [UserId], [RoleId], [UserName] FROM [User] WHERE [UserActive] = 1 ORDER BY [UserName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003R2,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                return;
       }
    }

 }

}
