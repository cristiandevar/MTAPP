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
   public class usergeneral : GXWebComponent
   {
      public usergeneral( )
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

      public usergeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_UserId )
      {
         this.A99UserId = aP0_UserId;
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
         cmbavState = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "UserId");
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
                  A99UserId = (int)(Math.Round(NumberUtil.Val( GetPar( "UserId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "A99UserId", StringUtil.LTrimStr( (decimal)(A99UserId), 6, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(int)A99UserId});
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
                  gxfirstwebparm = GetFirstPar( "UserId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "UserId");
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
            PA2Z2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV18Pgmname = "UserGeneral";
               context.Gx_err = 0;
               cmbavState.Enabled = 0;
               AssignProp(sPrefix, false, cmbavState_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavState.Enabled), 5, 0), true);
               /* Using cursor H002Z2 */
               pr_default.execute(0, new Object[] {A99UserId});
               A104RoleId = H002Z2_A104RoleId[0];
               n104RoleId = H002Z2_n104RoleId[0];
               A111UserActive = H002Z2_A111UserActive[0];
               n111UserActive = H002Z2_n111UserActive[0];
               AssignAttri(sPrefix, false, "A111UserActive", A111UserActive);
               A103UserModifiedDate = H002Z2_A103UserModifiedDate[0];
               AssignAttri(sPrefix, false, "A103UserModifiedDate", context.localUtil.Format(A103UserModifiedDate, "99/99/99"));
               A102UserCreatedDate = H002Z2_A102UserCreatedDate[0];
               AssignAttri(sPrefix, false, "A102UserCreatedDate", context.localUtil.Format(A102UserCreatedDate, "99/99/99"));
               A100UserName = H002Z2_A100UserName[0];
               AssignAttri(sPrefix, false, "A100UserName", A100UserName);
               pr_default.close(0);
               /* Using cursor H002Z3 */
               pr_default.execute(1, new Object[] {n104RoleId, A104RoleId});
               A105RoleName = H002Z3_A105RoleName[0];
               AssignAttri(sPrefix, false, "A105RoleName", A105RoleName);
               pr_default.close(1);
               WS2Z2( ) ;
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
            context.SendWebValue( "User General") ;
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1853160), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1853160), false, true);
         context.AddJavascriptSource("calendar-en.js", "?"+context.GetBuildNumber( 1853160), false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("usergeneral.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A99UserId,6,0))}, new string[] {"UserId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6UserId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUSERID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV6UserId), "ZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA99UserId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA99UserId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6UserId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUSERID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV6UserId), "ZZZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vERRORMESSAGES", AV13ErrorMessages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vERRORMESSAGES", AV13ErrorMessages);
         }
      }

      protected void RenderHtmlCloseForm2Z2( )
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
         return "UserGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "User General" ;
      }

      protected void WB2Z0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "usergeneral.aspx");
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 ww__view__actions-cell", "Right", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ww__view__actions", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button button-primary";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", "Update", bttBtnupdate_Jsonclick, 7, "Update", "", StyleString, ClassString, bttBtnupdate_Visible, bttBtnupdate_Enabled, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e112z1_client"+"'", TempTags, "", 2, "HLP_UserGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 10,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button button-tertiary";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnudelete_Internalname, "", bttBtnudelete_Caption, bttBtnudelete_Jsonclick, 5, "", "", StyleString, ClassString, bttBtnudelete_Visible, bttBtnudelete_Enabled, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOUDELETE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_UserGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Right", "top", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUserName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtUserName_Internalname, "Name", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtUserName_Internalname, A100UserName, StringUtil.RTrim( context.localUtil.Format( A100UserName, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtUserName_Link, "", "", "", edtUserName_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtUserName_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_UserGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRoleName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtRoleName_Internalname, "Role Name", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtRoleName_Internalname, A105RoleName, StringUtil.RTrim( context.localUtil.Format( A105RoleName, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtRoleName_Link, "", "", "", edtRoleName_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtRoleName_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Name", "left", true, "", "HLP_UserGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavState_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavState_Internalname, "State", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'" + sPrefix + "',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavState, cmbavState_Internalname, StringUtil.RTrim( AV11State), 1, cmbavState_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavState.Enabled, 0, 0, 0, "em", 0, "", "", "ReadonlyAttribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "", true, 0, "HLP_UserGeneral.htm");
            cmbavState.CurrentValue = StringUtil.RTrim( AV11State);
            AssignProp(sPrefix, false, cmbavState_Internalname, "Values", (string)(cmbavState.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUserCreatedDate_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtUserCreatedDate_Internalname, "Created Date", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtUserCreatedDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtUserCreatedDate_Internalname, context.localUtil.Format(A102UserCreatedDate, "99/99/99"), context.localUtil.Format( A102UserCreatedDate, "99/99/99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUserCreatedDate_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtUserCreatedDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_UserGeneral.htm");
            GxWebStd.gx_bitmap( context, edtUserCreatedDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtUserCreatedDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_UserGeneral.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtUserModifiedDate_Internalname, "User Modified Date", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtUserModifiedDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtUserModifiedDate_Internalname, context.localUtil.Format(A103UserModifiedDate, "99/99/99"), context.localUtil.Format( A103UserModifiedDate, "99/99/99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUserModifiedDate_Jsonclick, 0, "Attribute", "", "", "", "", edtUserModifiedDate_Visible, edtUserModifiedDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_UserGeneral.htm");
            GxWebStd.gx_bitmap( context, edtUserModifiedDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((edtUserModifiedDate_Visible==0)||(edtUserModifiedDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_UserGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtUserActive_Internalname, "User Active", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtUserActive_Internalname, StringUtil.BoolToStr( A111UserActive), StringUtil.BoolToStr( A111UserActive), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUserActive_Jsonclick, 0, "Attribute", "", "", "", "", edtUserActive_Visible, edtUserActive_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, 0, 0, true, "", "right", false, "", "HLP_UserGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtUserId_Internalname, "User Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtUserId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A99UserId), 6, 0, ".", "")), StringUtil.LTrim( ((edtUserId_Enabled!=0) ? context.localUtil.Format( (decimal)(A99UserId), "ZZZZZ9") : context.localUtil.Format( (decimal)(A99UserId), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUserId_Jsonclick, 0, "Attribute", "", "", "", "", edtUserId_Visible, edtUserId_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_UserGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START2Z2( )
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
               Form.Meta.addItem("description", "User General", 0) ;
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
               STRUP2Z0( ) ;
            }
         }
      }

      protected void WS2Z2( )
      {
         START2Z2( ) ;
         EVT2Z2( ) ;
      }

      protected void EVT2Z2( )
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
                                 STRUP2Z0( ) ;
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
                                 STRUP2Z0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E122Z2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2Z0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E132Z2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOUDELETE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2Z0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoUDelete' */
                                    E142Z2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP2Z0( ) ;
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
                                 STRUP2Z0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = cmbavState_Internalname;
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

      protected void WE2Z2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm2Z2( ) ;
            }
         }
      }

      protected void PA2Z2( )
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
               GX_FocusControl = cmbavState_Internalname;
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
         if ( cmbavState.ItemCount > 0 )
         {
            AV11State = cmbavState.getValidValue(AV11State);
            AssignAttri(sPrefix, false, "AV11State", AV11State);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavState.CurrentValue = StringUtil.RTrim( AV11State);
            AssignProp(sPrefix, false, cmbavState_Internalname, "Values", cmbavState.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF2Z2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV18Pgmname = "UserGeneral";
         context.Gx_err = 0;
         cmbavState.Enabled = 0;
         AssignProp(sPrefix, false, cmbavState_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavState.Enabled), 5, 0), true);
      }

      protected void RF2Z2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H002Z4 */
            pr_default.execute(2, new Object[] {A99UserId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A20InvoiceId = H002Z4_A20InvoiceId[0];
               /* Execute user event: Load */
               E132Z2 ();
               pr_default.readNext(2);
            }
            pr_default.close(2);
            WB2Z0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes2Z2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6UserId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUSERID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV6UserId), "ZZZZZ9"), context));
      }

      protected void before_start_formulas( )
      {
         AV18Pgmname = "UserGeneral";
         context.Gx_err = 0;
         cmbavState.Enabled = 0;
         AssignProp(sPrefix, false, cmbavState_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavState.Enabled), 5, 0), true);
         /* Using cursor H002Z5 */
         pr_default.execute(3, new Object[] {A99UserId});
         A104RoleId = H002Z5_A104RoleId[0];
         n104RoleId = H002Z5_n104RoleId[0];
         A111UserActive = H002Z5_A111UserActive[0];
         n111UserActive = H002Z5_n111UserActive[0];
         AssignAttri(sPrefix, false, "A111UserActive", A111UserActive);
         A103UserModifiedDate = H002Z5_A103UserModifiedDate[0];
         AssignAttri(sPrefix, false, "A103UserModifiedDate", context.localUtil.Format(A103UserModifiedDate, "99/99/99"));
         A102UserCreatedDate = H002Z5_A102UserCreatedDate[0];
         AssignAttri(sPrefix, false, "A102UserCreatedDate", context.localUtil.Format(A102UserCreatedDate, "99/99/99"));
         A100UserName = H002Z5_A100UserName[0];
         AssignAttri(sPrefix, false, "A100UserName", A100UserName);
         pr_default.close(3);
         /* Using cursor H002Z6 */
         pr_default.execute(4, new Object[] {n104RoleId, A104RoleId});
         A105RoleName = H002Z6_A105RoleName[0];
         AssignAttri(sPrefix, false, "A105RoleName", A105RoleName);
         pr_default.close(4);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2Z0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E122Z2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA99UserId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA99UserId"), ".", ","), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            A100UserName = cgiGet( edtUserName_Internalname);
            AssignAttri(sPrefix, false, "A100UserName", A100UserName);
            A105RoleName = cgiGet( edtRoleName_Internalname);
            AssignAttri(sPrefix, false, "A105RoleName", A105RoleName);
            cmbavState.CurrentValue = cgiGet( cmbavState_Internalname);
            AV11State = cgiGet( cmbavState_Internalname);
            AssignAttri(sPrefix, false, "AV11State", AV11State);
            A102UserCreatedDate = context.localUtil.CToD( cgiGet( edtUserCreatedDate_Internalname), 1);
            AssignAttri(sPrefix, false, "A102UserCreatedDate", context.localUtil.Format(A102UserCreatedDate, "99/99/99"));
            A103UserModifiedDate = context.localUtil.CToD( cgiGet( edtUserModifiedDate_Internalname), 1);
            AssignAttri(sPrefix, false, "A103UserModifiedDate", context.localUtil.Format(A103UserModifiedDate, "99/99/99"));
            A111UserActive = StringUtil.StrToBool( cgiGet( edtUserActive_Internalname));
            n111UserActive = false;
            AssignAttri(sPrefix, false, "A111UserActive", A111UserActive);
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
         E122Z2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E122Z2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV15Context.FromXml(AV14WebSession.Get("Context"), null, "", "");
         AV6UserId = AV15Context.gxTpr_Userid;
         AssignAttri(sPrefix, false, "AV6UserId", StringUtil.LTrimStr( (decimal)(AV6UserId), 6, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vUSERID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV6UserId), "ZZZZZ9"), context));
         if ( ! new haspermission(context).executeUdp(  "user update") )
         {
            bttBtnupdate_Visible = 0;
            AssignProp(sPrefix, false, bttBtnupdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnupdate_Visible), 5, 0), true);
            bttBtnupdate_Enabled = 0;
            AssignProp(sPrefix, false, bttBtnupdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtnupdate_Enabled), 5, 0), true);
         }
         if ( ! new haspermission(context).executeUdp(  "user delete") )
         {
            bttBtnudelete_Visible = 0;
            AssignProp(sPrefix, false, bttBtnudelete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnudelete_Visible), 5, 0), true);
            bttBtnudelete_Enabled = 0;
            AssignProp(sPrefix, false, bttBtnudelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtnudelete_Enabled), 5, 0), true);
         }
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV18Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV18Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         bttBtnudelete_Caption = (A111UserActive ? "Disable" : "Enable");
         AssignProp(sPrefix, false, bttBtnudelete_Internalname, "Caption", bttBtnudelete_Caption, true);
         if ( A99UserId != AV6UserId )
         {
            bttBtnudelete_Enabled = 1;
            AssignProp(sPrefix, false, bttBtnudelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtnudelete_Enabled), 5, 0), true);
         }
         else
         {
            bttBtnudelete_Enabled = 0;
            AssignProp(sPrefix, false, bttBtnudelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtnudelete_Enabled), 5, 0), true);
         }
         AV11State = (A111UserActive ? "Enabled" : "Disabled");
         AssignAttri(sPrefix, false, "AV11State", AV11State);
         edtUserActive_Visible = 0;
         AssignProp(sPrefix, false, edtUserActive_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUserActive_Visible), 5, 0), true);
         edtUserModifiedDate_Visible = 0;
         AssignProp(sPrefix, false, edtUserModifiedDate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUserModifiedDate_Visible), 5, 0), true);
         edtUserId_Visible = 0;
         AssignProp(sPrefix, false, edtUserId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUserId_Visible), 5, 0), true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E132Z2( )
      {
         /* Load Routine */
         returnInSub = false;
         if ( new haspermission(context).executeUdp(  "invoice view") )
         {
            edtUserName_Link = formatLink("viewinvoice.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A20InvoiceId,6,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"InvoiceId","TabCode"}) ;
            AssignProp(sPrefix, false, edtUserName_Internalname, "Link", edtUserName_Link, true);
         }
         if ( new haspermission(context).executeUdp(  "role view") )
         {
            edtRoleName_Link = formatLink("viewrole.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A104RoleId,6,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"RoleId","TabCode"}) ;
            AssignProp(sPrefix, false, edtRoleName_Internalname, "Link", edtRoleName_Link, true);
         }
      }

      protected void E142Z2( )
      {
         /* 'DoUDelete' Routine */
         returnInSub = false;
         if ( A99UserId != AV6UserId )
         {
            GXt_boolean1 = (bool)(!A111UserActive);
            new useractivedeactive(context ).execute(  A99UserId, ref  GXt_boolean1, out  AV12AllOk, ref  AV13ErrorMessages) ;
            if ( ! AV12AllOk )
            {
               GX_msglist.addItem((A111UserActive ? "Disable " : "Enable ")+"failed: "+AV13ErrorMessages.ToJSonString(false));
            }
         }
         CallWebObject(formatLink("viewuser.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A99UserId,6,0)),UrlEncode(StringUtil.RTrim("General"))}, new string[] {"UserId","TabCode"}) );
         context.wjLocDisableFrm = 1;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV13ErrorMessages", AV13ErrorMessages);
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV7TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV7TrnContext.gxTpr_Callerobject = AV18Pgmname;
         AV7TrnContext.gxTpr_Callerondelete = false;
         AV7TrnContext.gxTpr_Callerurl = AV10HTTPRequest.ScriptName+"?"+AV10HTTPRequest.QueryString;
         AV7TrnContext.gxTpr_Transactionname = "User";
         AV8TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         AV8TrnContextAtt.gxTpr_Attributename = "UserId";
         AV8TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV6UserId), 6, 0);
         AV7TrnContext.gxTpr_Attributes.Add(AV8TrnContextAtt, 0);
         AV9Session.Set("TrnContext", AV7TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A99UserId = Convert.ToInt32(getParm(obj,0));
         AssignAttri(sPrefix, false, "A99UserId", StringUtil.LTrimStr( (decimal)(A99UserId), 6, 0));
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
         PA2Z2( ) ;
         WS2Z2( ) ;
         WE2Z2( ) ;
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
         sCtrlA99UserId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA2Z2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "usergeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA2Z2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A99UserId = Convert.ToInt32(getParm(obj,2));
            AssignAttri(sPrefix, false, "A99UserId", StringUtil.LTrimStr( (decimal)(A99UserId), 6, 0));
         }
         wcpOA99UserId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA99UserId"), ".", ","), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( A99UserId != wcpOA99UserId ) ) )
         {
            setjustcreated();
         }
         wcpOA99UserId = A99UserId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA99UserId = cgiGet( sPrefix+"A99UserId_CTRL");
         if ( StringUtil.Len( sCtrlA99UserId) > 0 )
         {
            A99UserId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlA99UserId), ".", ","), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "A99UserId", StringUtil.LTrimStr( (decimal)(A99UserId), 6, 0));
         }
         else
         {
            A99UserId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"A99UserId_PARM"), ".", ","), 18, MidpointRounding.ToEven));
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
         PA2Z2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS2Z2( ) ;
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
         WS2Z2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A99UserId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A99UserId), 6, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA99UserId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A99UserId_CTRL", StringUtil.RTrim( sCtrlA99UserId));
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
         WE2Z2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20241261105691", true, true);
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
         context.AddJavascriptSource("usergeneral.js", "?20241261105692", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavState.Name = "vSTATE";
         cmbavState.WebTags = "";
         cmbavState.addItem("Enabled", "Enabled", 0);
         cmbavState.addItem("Disabled", "Disabled", 0);
         if ( cmbavState.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtnudelete_Internalname = sPrefix+"BTNUDELETE";
         edtUserName_Internalname = sPrefix+"USERNAME";
         edtRoleName_Internalname = sPrefix+"ROLENAME";
         cmbavState_Internalname = sPrefix+"vSTATE";
         edtUserCreatedDate_Internalname = sPrefix+"USERCREATEDDATE";
         divAttributestable_Internalname = sPrefix+"ATTRIBUTESTABLE";
         edtUserModifiedDate_Internalname = sPrefix+"USERMODIFIEDDATE";
         edtUserActive_Internalname = sPrefix+"USERACTIVE";
         edtUserId_Internalname = sPrefix+"USERID";
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
         edtUserId_Jsonclick = "";
         edtUserId_Enabled = 0;
         edtUserId_Visible = 1;
         edtUserActive_Jsonclick = "";
         edtUserActive_Enabled = 0;
         edtUserActive_Visible = 1;
         edtUserModifiedDate_Jsonclick = "";
         edtUserModifiedDate_Enabled = 0;
         edtUserModifiedDate_Visible = 1;
         edtUserCreatedDate_Jsonclick = "";
         edtUserCreatedDate_Enabled = 0;
         cmbavState_Jsonclick = "";
         cmbavState.Enabled = 1;
         edtRoleName_Jsonclick = "";
         edtRoleName_Link = "";
         edtRoleName_Enabled = 0;
         edtUserName_Jsonclick = "";
         edtUserName_Link = "";
         edtUserName_Enabled = 0;
         bttBtnudelete_Caption = "";
         bttBtnudelete_Enabled = 1;
         bttBtnudelete_Visible = 1;
         bttBtnupdate_Enabled = 1;
         bttBtnupdate_Visible = 1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A99UserId',fld:'USERID',pic:'ZZZZZ9'},{av:'AV6UserId',fld:'vUSERID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUPDATE'","{handler:'E112Z1',iparms:[{av:'A99UserId',fld:'USERID',pic:'ZZZZZ9'}]");
         setEventMetadata("'DOUPDATE'",",oparms:[]}");
         setEventMetadata("'DOUDELETE'","{handler:'E142Z2',iparms:[{av:'A99UserId',fld:'USERID',pic:'ZZZZZ9'},{av:'AV6UserId',fld:'vUSERID',pic:'ZZZZZ9',hsh:true},{av:'A111UserActive',fld:'USERACTIVE',pic:''},{av:'AV13ErrorMessages',fld:'vERRORMESSAGES',pic:''}]");
         setEventMetadata("'DOUDELETE'",",oparms:[{av:'AV13ErrorMessages',fld:'vERRORMESSAGES',pic:''},{av:'A111UserActive',fld:'USERACTIVE',pic:''}]}");
         setEventMetadata("VALIDV_STATE","{handler:'Validv_State',iparms:[]");
         setEventMetadata("VALIDV_STATE",",oparms:[]}");
         setEventMetadata("VALID_USERID","{handler:'Valid_Userid',iparms:[]");
         setEventMetadata("VALID_USERID",",oparms:[]}");
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
         AV18Pgmname = "";
         scmdbuf = "";
         H002Z2_A104RoleId = new int[1] ;
         H002Z2_n104RoleId = new bool[] {false} ;
         H002Z2_A111UserActive = new bool[] {false} ;
         H002Z2_n111UserActive = new bool[] {false} ;
         H002Z2_A103UserModifiedDate = new DateTime[] {DateTime.MinValue} ;
         H002Z2_A102UserCreatedDate = new DateTime[] {DateTime.MinValue} ;
         H002Z2_A100UserName = new string[] {""} ;
         A103UserModifiedDate = DateTime.MinValue;
         A102UserCreatedDate = DateTime.MinValue;
         A100UserName = "";
         H002Z3_A105RoleName = new string[] {""} ;
         A105RoleName = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV13ErrorMessages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GX_FocusControl = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnupdate_Jsonclick = "";
         bttBtnudelete_Jsonclick = "";
         AV11State = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         H002Z4_A99UserId = new int[1] ;
         H002Z4_A20InvoiceId = new int[1] ;
         H002Z4_A104RoleId = new int[1] ;
         H002Z4_n104RoleId = new bool[] {false} ;
         H002Z4_A111UserActive = new bool[] {false} ;
         H002Z4_n111UserActive = new bool[] {false} ;
         H002Z4_A103UserModifiedDate = new DateTime[] {DateTime.MinValue} ;
         H002Z4_A102UserCreatedDate = new DateTime[] {DateTime.MinValue} ;
         H002Z4_A105RoleName = new string[] {""} ;
         H002Z4_A100UserName = new string[] {""} ;
         H002Z5_A104RoleId = new int[1] ;
         H002Z5_n104RoleId = new bool[] {false} ;
         H002Z5_A111UserActive = new bool[] {false} ;
         H002Z5_n111UserActive = new bool[] {false} ;
         H002Z5_A103UserModifiedDate = new DateTime[] {DateTime.MinValue} ;
         H002Z5_A102UserCreatedDate = new DateTime[] {DateTime.MinValue} ;
         H002Z5_A100UserName = new string[] {""} ;
         H002Z6_A105RoleName = new string[] {""} ;
         AV15Context = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         AV14WebSession = context.GetSession();
         AV7TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10HTTPRequest = new GxHttpRequest( context);
         AV8TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         AV9Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA99UserId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.usergeneral__default(),
            new Object[][] {
                new Object[] {
               H002Z2_A104RoleId, H002Z2_n104RoleId, H002Z2_A111UserActive, H002Z2_n111UserActive, H002Z2_A103UserModifiedDate, H002Z2_A102UserCreatedDate, H002Z2_A100UserName
               }
               , new Object[] {
               H002Z3_A105RoleName
               }
               , new Object[] {
               H002Z4_A99UserId, H002Z4_A20InvoiceId, H002Z4_A104RoleId, H002Z4_n104RoleId, H002Z4_A111UserActive, H002Z4_n111UserActive, H002Z4_A103UserModifiedDate, H002Z4_A102UserCreatedDate, H002Z4_A105RoleName, H002Z4_A100UserName
               }
               , new Object[] {
               H002Z5_A104RoleId, H002Z5_n104RoleId, H002Z5_A111UserActive, H002Z5_n111UserActive, H002Z5_A103UserModifiedDate, H002Z5_A102UserCreatedDate, H002Z5_A100UserName
               }
               , new Object[] {
               H002Z6_A105RoleName
               }
            }
         );
         AV18Pgmname = "UserGeneral";
         /* GeneXus formulas. */
         AV18Pgmname = "UserGeneral";
         context.Gx_err = 0;
         cmbavState.Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int A99UserId ;
      private int wcpOA99UserId ;
      private int A104RoleId ;
      private int AV6UserId ;
      private int bttBtnupdate_Visible ;
      private int bttBtnupdate_Enabled ;
      private int bttBtnudelete_Visible ;
      private int bttBtnudelete_Enabled ;
      private int edtUserName_Enabled ;
      private int edtRoleName_Enabled ;
      private int edtUserCreatedDate_Enabled ;
      private int edtUserModifiedDate_Visible ;
      private int edtUserModifiedDate_Enabled ;
      private int edtUserActive_Visible ;
      private int edtUserActive_Enabled ;
      private int edtUserId_Enabled ;
      private int edtUserId_Visible ;
      private int A20InvoiceId ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV18Pgmname ;
      private string cmbavState_Internalname ;
      private string scmdbuf ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnupdate_Internalname ;
      private string bttBtnupdate_Jsonclick ;
      private string bttBtnudelete_Internalname ;
      private string bttBtnudelete_Caption ;
      private string bttBtnudelete_Jsonclick ;
      private string divAttributestable_Internalname ;
      private string edtUserName_Internalname ;
      private string edtUserName_Link ;
      private string edtUserName_Jsonclick ;
      private string edtRoleName_Internalname ;
      private string edtRoleName_Link ;
      private string edtRoleName_Jsonclick ;
      private string cmbavState_Jsonclick ;
      private string edtUserCreatedDate_Internalname ;
      private string edtUserCreatedDate_Jsonclick ;
      private string edtUserModifiedDate_Internalname ;
      private string edtUserModifiedDate_Jsonclick ;
      private string edtUserActive_Internalname ;
      private string edtUserActive_Jsonclick ;
      private string edtUserId_Internalname ;
      private string edtUserId_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string sCtrlA99UserId ;
      private DateTime A103UserModifiedDate ;
      private DateTime A102UserCreatedDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n104RoleId ;
      private bool A111UserActive ;
      private bool n111UserActive ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool GXt_boolean1 ;
      private bool AV12AllOk ;
      private string A100UserName ;
      private string A105RoleName ;
      private string AV11State ;
      private IGxSession AV14WebSession ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavState ;
      private IDataStoreProvider pr_default ;
      private int[] H002Z2_A104RoleId ;
      private bool[] H002Z2_n104RoleId ;
      private bool[] H002Z2_A111UserActive ;
      private bool[] H002Z2_n111UserActive ;
      private DateTime[] H002Z2_A103UserModifiedDate ;
      private DateTime[] H002Z2_A102UserCreatedDate ;
      private string[] H002Z2_A100UserName ;
      private string[] H002Z3_A105RoleName ;
      private int[] H002Z4_A99UserId ;
      private int[] H002Z4_A20InvoiceId ;
      private int[] H002Z4_A104RoleId ;
      private bool[] H002Z4_n104RoleId ;
      private bool[] H002Z4_A111UserActive ;
      private bool[] H002Z4_n111UserActive ;
      private DateTime[] H002Z4_A103UserModifiedDate ;
      private DateTime[] H002Z4_A102UserCreatedDate ;
      private string[] H002Z4_A105RoleName ;
      private string[] H002Z4_A100UserName ;
      private int[] H002Z5_A104RoleId ;
      private bool[] H002Z5_n104RoleId ;
      private bool[] H002Z5_A111UserActive ;
      private bool[] H002Z5_n111UserActive ;
      private DateTime[] H002Z5_A103UserModifiedDate ;
      private DateTime[] H002Z5_A102UserCreatedDate ;
      private string[] H002Z5_A100UserName ;
      private string[] H002Z6_A105RoleName ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV10HTTPRequest ;
      private IGxSession AV9Session ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV13ErrorMessages ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV7TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV8TrnContextAtt ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession AV15Context ;
   }

   public class usergeneral__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH002Z2;
          prmH002Z2 = new Object[] {
          new ParDef("@UserId",GXType.Int32,6,0)
          };
          Object[] prmH002Z3;
          prmH002Z3 = new Object[] {
          new ParDef("@RoleId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmH002Z4;
          prmH002Z4 = new Object[] {
          new ParDef("@UserId",GXType.Int32,6,0)
          };
          Object[] prmH002Z5;
          prmH002Z5 = new Object[] {
          new ParDef("@UserId",GXType.Int32,6,0)
          };
          Object[] prmH002Z6;
          prmH002Z6 = new Object[] {
          new ParDef("@RoleId",GXType.Int32,6,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("H002Z2", "SELECT [RoleId], [UserActive], [UserModifiedDate], [UserCreatedDate], [UserName] FROM [User] WHERE [UserId] = @UserId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002Z2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002Z3", "SELECT [RoleName] FROM [Role] WHERE [RoleId] = @RoleId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002Z3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002Z4", "SELECT T1.[UserId], T1.[InvoiceId], T2.[RoleId], T2.[UserActive], T2.[UserModifiedDate], T2.[UserCreatedDate], T3.[RoleName], T2.[UserName] FROM (([Invoice] T1 INNER JOIN [User] T2 ON T2.[UserId] = T1.[UserId]) LEFT JOIN [Role] T3 ON T3.[RoleId] = T2.[RoleId]) WHERE T1.[UserId] = @UserId ORDER BY T1.[UserId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002Z4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002Z5", "SELECT [RoleId], [UserActive], [UserModifiedDate], [UserCreatedDate], [UserName] FROM [User] WHERE [UserId] = @UserId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002Z5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H002Z6", "SELECT [RoleName] FROM [Role] WHERE [RoleId] = @RoleId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002Z6,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(4);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((bool[]) buf[4])[0] = rslt.getBool(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(5);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(6);
                ((string[]) buf[8])[0] = rslt.getVarchar(7);
                ((string[]) buf[9])[0] = rslt.getVarchar(8);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(4);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
       }
    }

 }

}
