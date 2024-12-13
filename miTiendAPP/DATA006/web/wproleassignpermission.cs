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
   public class wproleassignpermission : GXDataArea
   {
      public wproleassignpermission( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public wproleassignpermission( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_RoleId )
      {
         this.AV19RoleId = aP0_RoleId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkavCtlselected = new GXCheckbox();
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
               AV19RoleId = (int)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV19RoleId", StringUtil.LTrimStr( (decimal)(AV19RoleId), 6, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV19RoleId), "ZZZZZ9"), context));
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
         nRC_GXsfl_28 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_28"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_28_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_28_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_28_idx = GetPar( "sGXsfl_28_idx");
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
         subGrid_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid_Rows"), "."), 18, MidpointRounding.ToEven));
         AV19RoleId = (int)(Math.Round(NumberUtil.Val( GetPar( "RoleId"), "."), 18, MidpointRounding.ToEven));
         AV26newPermissionName = GetPar( "newPermissionName");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV19RoleId, AV26newPermissionName) ;
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
         PA3I2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3I2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wproleassignpermission.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV19RoleId,6,0))}, new string[] {"RoleId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vNEWPERMISSIONNAME", AV26newPermissionName);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWPERMISSIONNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV26newPermissionName, "")), context));
         GxWebStd.gx_hidden_field( context, "vROLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19RoleId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV19RoleId), "ZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Sdtpermission", AV17SDTPermission);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Sdtpermission", AV17SDTPermission);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_28", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_28), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTPERMISSION", AV17SDTPermission);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTPERMISSION", AV17SDTPermission);
         }
         GxWebStd.gx_hidden_field( context, "vROLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19RoleId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV19RoleId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vNEWPERMISSIONNAME", AV26newPermissionName);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWPERMISSIONNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV26newPermissionName, "")), context));
         GxWebStd.gx_hidden_field( context, "PERMISSIONNAME", A107PermissionName);
         GxWebStd.gx_hidden_field( context, "PERMISSIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A106PermissionId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
            WE3I2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3I2( ) ;
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
         return formatLink("wproleassignpermission.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV19RoleId,6,0))}, new string[] {"RoleId"})  ;
      }

      public override string GetPgmname( )
      {
         return "WPRoleAssignPermission" ;
      }

      public override string GetPgmdesc( )
      {
         return "WPRole Assign Permission" ;
      }

      protected void WB3I0( )
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
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "body-container", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "Flex ww__actions-container", "left", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", " "+"classref"+" ", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 10,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnconfirmar_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(28), 2, 0)+","+"null"+");", "Confirm", bttBtnconfirmar_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtnconfirmar_Visible, bttBtnconfirmar_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CONFIRM\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPRoleAssignPermission.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 12,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(28), 2, 0)+","+"null"+");", "Cancel", bttBtncancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPRoleAssignPermission.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", " "+"classref"+" ", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+edtavPermissionname_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_28_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPermissionname_Internalname, AV24PermissionName, StringUtil.RTrim( context.localUtil.Format( AV24PermissionName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Name", edtavPermissionname_Jsonclick, 0, "attribute-search", "", "", "", "", 1, edtavPermissionname_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_WPRoleAssignPermission.htm");
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
            /*  Grid Control  */
            GridContainer.SetIsFreestyle(true);
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl28( ) ;
         }
         if ( wbEnd == 28 )
         {
            wbEnd = 0;
            nRC_GXsfl_28 = (int)(nGXsfl_28_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
               GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
               AV29GXV1 = nGXsfl_28_idx;
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
         if ( wbEnd == 28 )
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
                  GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
                  GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
                  AV29GXV1 = nGXsfl_28_idx;
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

      protected void START3I2( )
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
            Form.Meta.addItem("description", "WPRole Assign Permission", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3I0( ) ;
      }

      protected void WS3I2( )
      {
         START3I2( ) ;
         EVT3I2( ) ;
      }

      protected void EVT3I2( )
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
                              E113I2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VPERMISSIONNAME.CONTROLVALUECHANGING") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E123I2 ();
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRIDPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 8), "'CANCEL'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) )
                           {
                              nGXsfl_28_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_28_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_28_idx), 4, 0), 4, "0");
                              SubsflControlProps_282( ) ;
                              AV29GXV1 = (int)(nGXsfl_28_idx+GRID_nFirstRecordOnPage);
                              if ( ( AV17SDTPermission.Count >= AV29GXV1 ) && ( AV29GXV1 > 0 ) )
                              {
                                 AV17SDTPermission.CurrentItem = ((SdtSDTPermission_SDTPermissionItem)AV17SDTPermission.Item(AV29GXV1));
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
                                    E133I2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'CANCEL'") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: 'Cancel' */
                                    E143I2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E153I2 ();
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

      protected void WE3I2( )
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

      protected void PA3I2( )
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
               GX_FocusControl = edtavPermissionname_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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
         SubsflControlProps_282( ) ;
         while ( nGXsfl_28_idx <= nRC_GXsfl_28 )
         {
            sendrow_282( ) ;
            nGXsfl_28_idx = ((subGrid_Islastpage==1)&&(nGXsfl_28_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_28_idx+1);
            sGXsfl_28_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_28_idx), 4, 0), 4, "0");
            SubsflControlProps_282( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       int AV19RoleId ,
                                       string AV26newPermissionName )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF3I2( ) ;
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
         RF3I2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV32Pgmname = "WPRoleAssignPermission";
         context.Gx_err = 0;
         edtavCtlpermissionname_Enabled = 0;
         AssignProp("", false, edtavCtlpermissionname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlpermissionname_Enabled), 5, 0), !bGXsfl_28_Refreshing);
      }

      protected void RF3I2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 28;
         nGXsfl_28_idx = 1;
         sGXsfl_28_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_28_idx), 4, 0), 4, "0");
         SubsflControlProps_282( ) ;
         bGXsfl_28_Refreshing = true;
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
            SubsflControlProps_282( ) ;
            E153I2 ();
            wbEnd = 28;
            WB3I0( ) ;
         }
         bGXsfl_28_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3I2( )
      {
         GxWebStd.gx_hidden_field( context, "vNEWPERMISSIONNAME", AV26newPermissionName);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEWPERMISSIONNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV26newPermissionName, "")), context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         return AV17SDTPermission.Count ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV19RoleId, AV26newPermissionName) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV19RoleId, AV26newPermissionName) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV19RoleId, AV26newPermissionName) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV19RoleId, AV26newPermissionName) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV19RoleId, AV26newPermissionName) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV32Pgmname = "WPRoleAssignPermission";
         context.Gx_err = 0;
         edtavCtlpermissionname_Enabled = 0;
         AssignProp("", false, edtavCtlpermissionname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlpermissionname_Enabled), 5, 0), !bGXsfl_28_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3I0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E133I2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Sdtpermission"), AV17SDTPermission);
            ajax_req_read_hidden_sdt(cgiGet( "vSDTPERMISSION"), AV17SDTPermission);
            /* Read saved values. */
            nRC_GXsfl_28 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_28"), ".", ","), 18, MidpointRounding.ToEven));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ".", ","), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ".", ","), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            nRC_GXsfl_28 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_28"), ".", ","), 18, MidpointRounding.ToEven));
            nGXsfl_28_fel_idx = 0;
            while ( nGXsfl_28_fel_idx < nRC_GXsfl_28 )
            {
               nGXsfl_28_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_28_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_28_fel_idx+1);
               sGXsfl_28_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_28_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_282( ) ;
               AV29GXV1 = (int)(nGXsfl_28_fel_idx+GRID_nFirstRecordOnPage);
               if ( ( AV17SDTPermission.Count >= AV29GXV1 ) && ( AV29GXV1 > 0 ) )
               {
                  AV17SDTPermission.CurrentItem = ((SdtSDTPermission_SDTPermissionItem)AV17SDTPermission.Item(AV29GXV1));
               }
            }
            if ( nGXsfl_28_fel_idx == 0 )
            {
               nGXsfl_28_idx = 1;
               sGXsfl_28_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_28_idx), 4, 0), 4, "0");
               SubsflControlProps_282( ) ;
            }
            nGXsfl_28_fel_idx = 1;
            /* Read variables values. */
            AV24PermissionName = cgiGet( edtavPermissionname_Internalname);
            AssignAttri("", false, "AV24PermissionName", AV24PermissionName);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E133I2 ();
         if (returnInSub) return;
      }

      protected void E133I2( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtSDTContextSession1 = new GeneXus.Programs.general.ui.SdtSDTContextSession();
         new checkauthentication(context ).execute( out  GXt_SdtSDTContextSession1) ;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         if ( ! new haspermission(context).executeUdp(  "role view") )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV32Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         if ( ! ( new haspermission(context).executeUdp(  "role update") && new haspermission(context).executeUdp(  "role delete") ) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV32Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            bttBtnconfirmar_Visible = 0;
            AssignProp("", false, bttBtnconfirmar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnconfirmar_Visible), 5, 0), true);
            bttBtnconfirmar_Enabled = 0;
            AssignProp("", false, bttBtnconfirmar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtnconfirmar_Enabled), 5, 0), true);
         }
         AV17SDTPermission = new GXBaseCollection<SdtSDTPermission_SDTPermissionItem>( context, "SDTPermissionItem", "mtaKB");
         gx_BV28 = true;
         /* Using cursor H003I2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A106PermissionId = H003I2_A106PermissionId[0];
            A107PermissionName = H003I2_A107PermissionName[0];
            AV18SDTPermissionItem = new SdtSDTPermission_SDTPermissionItem(context);
            AV18SDTPermissionItem.gxTpr_Permissionid = A106PermissionId;
            AV18SDTPermissionItem.gxTpr_Permissionname = A107PermissionName;
            if ( new haspermission(context).executeUdp(  A107PermissionName) )
            {
               AV18SDTPermissionItem.gxTpr_Selected = true;
            }
            else
            {
               AV18SDTPermissionItem.gxTpr_Selected = false;
            }
            AV17SDTPermission.Add(AV18SDTPermissionItem, 0);
            gx_BV28 = true;
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void E143I2( )
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

      protected void E113I2( )
      {
         AV29GXV1 = (int)(nGXsfl_28_idx+GRID_nFirstRecordOnPage);
         if ( ( AV29GXV1 > 0 ) && ( AV17SDTPermission.Count >= AV29GXV1 ) )
         {
            AV17SDTPermission.CurrentItem = ((SdtSDTPermission_SDTPermissionItem)AV17SDTPermission.Item(AV29GXV1));
         }
         /* 'Confirm' Routine */
         returnInSub = false;
         AV34GXV4 = 1;
         while ( AV34GXV4 <= AV17SDTPermission.Count )
         {
            AV18SDTPermissionItem = ((SdtSDTPermission_SDTPermissionItem)AV17SDTPermission.Item(AV34GXV4));
            if ( AV18SDTPermissionItem.gxTpr_Selected )
            {
               AV21RolePermission = new SdtRole_Permission(context);
               AV21RolePermission.gxTpr_Permissionid = AV18SDTPermissionItem.gxTpr_Permissionid;
               AV22Role.Load(AV19RoleId);
               AV22Role.gxTpr_Permission.Add((SdtRole_Permission)(AV21RolePermission.Clone()), 0);
               AV22Role.Update();
               if ( AV22Role.Success() )
               {
                  context.CommitDataStores("wproleassignpermission",pr_default);
               }
               else
               {
                  GX_msglist.addItem("Error al agregar: "+AV22Role.GetMessages().ToJSonString(false));
                  context.RollbackDataStores("wproleassignpermission",pr_default);
               }
            }
            else
            {
               if ( new haspermission(context).executeUdp(  AV18SDTPermissionItem.gxTpr_Permissionname) )
               {
                  AV22Role.Load(AV19RoleId);
                  AV22Role.gxTpr_Permission.RemoveByKey(AV18SDTPermissionItem.gxTpr_Permissionid) ;
                  AV22Role.Update();
                  if ( AV22Role.Success() )
                  {
                     context.CommitDataStores("wproleassignpermission",pr_default);
                  }
                  else
                  {
                     GX_msglist.addItem("Error al quitar: "+AV22Role.GetMessages().ToJSonString(false));
                     context.RollbackDataStores("wproleassignpermission",pr_default);
                  }
               }
            }
            AV34GXV4 = (int)(AV34GXV4+1);
         }
      }

      protected void E123I2( )
      {
         AV29GXV1 = (int)(nGXsfl_28_idx+GRID_nFirstRecordOnPage);
         if ( ( AV29GXV1 > 0 ) && ( AV17SDTPermission.Count >= AV29GXV1 ) )
         {
            AV17SDTPermission.CurrentItem = ((SdtSDTPermission_SDTPermissionItem)AV17SDTPermission.Item(AV29GXV1));
         }
         /* Permissionname_Controlvaluechanging Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHARGESDT' */
         S112 ();
         if (returnInSub) return;
         gxgrGrid_refresh( subGrid_Rows, AV19RoleId, AV26newPermissionName) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17SDTPermission", AV17SDTPermission);
         nGXsfl_28_bak_idx = nGXsfl_28_idx;
         gxgrGrid_refresh( subGrid_Rows, AV19RoleId, AV26newPermissionName) ;
         nGXsfl_28_idx = nGXsfl_28_bak_idx;
         sGXsfl_28_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_28_idx), 4, 0), 4, "0");
         SubsflControlProps_282( ) ;
      }

      protected void S112( )
      {
         /* 'CHARGESDT' Routine */
         returnInSub = false;
         AV23SDTPermissionAux = (GXBaseCollection<SdtSDTPermission_SDTPermissionItem>)(AV17SDTPermission.Clone());
         AV17SDTPermission.Clear();
         gx_BV28 = true;
         AV25Count = 0;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV24PermissionName ,
                                              A107PermissionName } ,
                                              new int[]{
                                              }
         });
         lV24PermissionName = StringUtil.Concat( StringUtil.RTrim( AV24PermissionName), "%", "");
         /* Using cursor H003I3 */
         pr_default.execute(1, new Object[] {lV24PermissionName});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A107PermissionName = H003I3_A107PermissionName[0];
            A106PermissionId = H003I3_A106PermissionId[0];
            AV18SDTPermissionItem = new SdtSDTPermission_SDTPermissionItem(context);
            AV18SDTPermissionItem.gxTpr_Permissionid = A106PermissionId;
            AV18SDTPermissionItem.gxTpr_Permissionname = A107PermissionName;
            if ( new haspermission(context).executeUdp(  A107PermissionName) )
            {
               AV18SDTPermissionItem.gxTpr_Selected = true;
            }
            else
            {
               AV18SDTPermissionItem.gxTpr_Selected = false;
            }
            AV17SDTPermission.Add(AV18SDTPermissionItem, 0);
            gx_BV28 = true;
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      private void E153I2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV29GXV1 = 1;
         while ( AV29GXV1 <= AV17SDTPermission.Count )
         {
            AV17SDTPermission.CurrentItem = ((SdtSDTPermission_SDTPermissionItem)AV17SDTPermission.Item(AV29GXV1));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 28;
            }
            if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_282( ) ;
            }
            GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_28_Refreshing )
            {
               DoAjaxLoad(28, GridRow);
            }
            AV29GXV1 = (int)(AV29GXV1+1);
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV19RoleId = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV19RoleId", StringUtil.LTrimStr( (decimal)(AV19RoleId), 6, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV19RoleId), "ZZZZZ9"), context));
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
         PA3I2( ) ;
         WS3I2( ) ;
         WE3I2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20241115213375", true, true);
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
         context.AddJavascriptSource("wproleassignpermission.js", "?20241115213376", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_282( )
      {
         edtavCtlpermissionname_Internalname = "CTLPERMISSIONNAME_"+sGXsfl_28_idx;
         chkavCtlselected_Internalname = "CTLSELECTED_"+sGXsfl_28_idx;
      }

      protected void SubsflControlProps_fel_282( )
      {
         edtavCtlpermissionname_Internalname = "CTLPERMISSIONNAME_"+sGXsfl_28_fel_idx;
         chkavCtlselected_Internalname = "CTLSELECTED_"+sGXsfl_28_fel_idx;
      }

      protected void sendrow_282( )
      {
         SubsflControlProps_282( ) ;
         WB3I0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_28_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
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
               if ( ((int)((nGXsfl_28_idx) % (2))) == 0 )
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
               context.WriteHtmlText( "<tr"+" class=\""+subGrid_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_28_idx+"\">") ;
            }
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divGrid1table_Internalname+"_"+sGXsfl_28_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-6",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavCtlpermissionname_Internalname,(string)"Permission Name",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlpermissionname_Internalname,((SdtSDTPermission_SDTPermissionItem)AV17SDTPermission.Item(AV29GXV1)).gxTpr_Permissionname,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlpermissionname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(int)edtavCtlpermissionname_Enabled,(short)0,(string)"text",(string)"",(short)60,(string)"chr",(short)1,(string)"row",(short)60,(short)0,(short)0,(short)28,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-6",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Div Control */
            GridRow.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)" gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
            /* Attribute/Variable Label */
            GridRow.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)chkavCtlselected_Internalname,(string)"Selected",(string)"col-sm-3 AttributeLabel",(short)0,(bool)true,(string)""});
            /* Check box */
            TempTags = " " + ((chkavCtlselected.Enabled!=0)&&(chkavCtlselected.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 36,'',false,'"+sGXsfl_28_idx+"',28)\"" : " ");
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "CTLSELECTED_" + sGXsfl_28_idx;
            chkavCtlselected.Name = GXCCtl;
            chkavCtlselected.WebTags = "";
            chkavCtlselected.Caption = "";
            AssignProp("", false, chkavCtlselected_Internalname, "TitleCaption", chkavCtlselected.Caption, !bGXsfl_28_Refreshing);
            chkavCtlselected.CheckedValue = "false";
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavCtlselected_Internalname,StringUtil.BoolToStr( ((SdtSDTPermission_SDTPermissionItem)AV17SDTPermission.Item(AV29GXV1)).gxTpr_Selected),(string)"",(string)"Selected",(short)1,(short)1,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",TempTags+" onclick="+"\"gx.fn.checkboxClick(36, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+((chkavCtlselected.Enabled!=0)&&(chkavCtlselected.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,36);\"" : " ")});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            GridRow.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
            send_integrity_lvl_hashes3I2( ) ;
            /* End of Columns property logic. */
            GridContainer.AddRow(GridRow);
            nGXsfl_28_idx = ((subGrid_Islastpage==1)&&(nGXsfl_28_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_28_idx+1);
            sGXsfl_28_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_28_idx), 4, 0), 4, "0");
            SubsflControlProps_282( ) ;
         }
         /* End function sendrow_282 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "CTLSELECTED_" + sGXsfl_28_idx;
         chkavCtlselected.Name = GXCCtl;
         chkavCtlselected.WebTags = "";
         chkavCtlselected.Caption = "";
         AssignProp("", false, chkavCtlselected_Internalname, "TitleCaption", chkavCtlselected.Caption, !bGXsfl_28_Refreshing);
         chkavCtlselected.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void StartGridControl28( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"28\">") ;
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
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlpermissionname_Enabled), 5, 0, ".", "")));
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
         edtavPermissionname_Internalname = "vPERMISSIONNAME";
         divTable1_Internalname = "TABLE1";
         edtavCtlpermissionname_Internalname = "CTLPERMISSIONNAME";
         chkavCtlselected_Internalname = "CTLSELECTED";
         divGrid1table_Internalname = "GRID1TABLE";
         divGridcontainer_Internalname = "GRIDCONTAINER";
         divGridtable_Internalname = "GRIDTABLE";
         divGridcell_Internalname = "GRIDCELL";
         divMaintable_Internalname = "MAINTABLE";
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
         chkavCtlselected.Caption = "Selected";
         chkavCtlselected.Visible = 1;
         chkavCtlselected.Enabled = 1;
         edtavCtlpermissionname_Jsonclick = "";
         edtavCtlpermissionname_Enabled = 0;
         subGrid_Class = "FreeStyleGrid";
         subGrid_Backcolorstyle = 0;
         edtavCtlpermissionname_Enabled = -1;
         edtavPermissionname_Jsonclick = "";
         edtavPermissionname_Enabled = 1;
         bttBtnconfirmar_Enabled = 1;
         bttBtnconfirmar_Visible = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "WPRole Assign Permission";
         subGrid_Rows = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV17SDTPermission',fld:'vSDTPERMISSION',grid:28,pic:''},{av:'nGXsfl_28_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:28},{av:'nRC_GXsfl_28',ctrl:'GRID',prop:'GridRC',grid:28},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV19RoleId',fld:'vROLEID',pic:'ZZZZZ9',hsh:true},{av:'AV26newPermissionName',fld:'vNEWPERMISSIONNAME',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'CANCEL'","{handler:'E143I2',iparms:[]");
         setEventMetadata("'CANCEL'",",oparms:[]}");
         setEventMetadata("'CONFIRM'","{handler:'E113I2',iparms:[{av:'AV17SDTPermission',fld:'vSDTPERMISSION',grid:28,pic:''},{av:'nGXsfl_28_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:28},{av:'GRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_28',ctrl:'GRID',prop:'GridRC',grid:28},{av:'AV19RoleId',fld:'vROLEID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("'CONFIRM'",",oparms:[]}");
         setEventMetadata("VPERMISSIONNAME.CONTROLVALUECHANGING","{handler:'E123I2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV17SDTPermission',fld:'vSDTPERMISSION',grid:28,pic:''},{av:'nGXsfl_28_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:28},{av:'nRC_GXsfl_28',ctrl:'GRID',prop:'GridRC',grid:28},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV19RoleId',fld:'vROLEID',pic:'ZZZZZ9',hsh:true},{av:'AV26newPermissionName',fld:'vNEWPERMISSIONNAME',pic:'',hsh:true},{av:'A107PermissionName',fld:'PERMISSIONNAME',pic:''},{av:'AV24PermissionName',fld:'vPERMISSIONNAME',pic:''},{av:'A106PermissionId',fld:'PERMISSIONID',pic:'ZZZZZ9'}]");
         setEventMetadata("VPERMISSIONNAME.CONTROLVALUECHANGING",",oparms:[{av:'AV17SDTPermission',fld:'vSDTPERMISSION',grid:28,pic:''},{av:'nGXsfl_28_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:28},{av:'GRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_28',ctrl:'GRID',prop:'GridRC',grid:28}]}");
         setEventMetadata("GRID_FIRSTPAGE","{handler:'subgrid_firstpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV17SDTPermission',fld:'vSDTPERMISSION',grid:28,pic:''},{av:'nGXsfl_28_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:28},{av:'nRC_GXsfl_28',ctrl:'GRID',prop:'GridRC',grid:28},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV19RoleId',fld:'vROLEID',pic:'ZZZZZ9',hsh:true},{av:'AV26newPermissionName',fld:'vNEWPERMISSIONNAME',pic:'',hsh:true}]");
         setEventMetadata("GRID_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID_PREVPAGE","{handler:'subgrid_previouspage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV17SDTPermission',fld:'vSDTPERMISSION',grid:28,pic:''},{av:'nGXsfl_28_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:28},{av:'nRC_GXsfl_28',ctrl:'GRID',prop:'GridRC',grid:28},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV19RoleId',fld:'vROLEID',pic:'ZZZZZ9',hsh:true},{av:'AV26newPermissionName',fld:'vNEWPERMISSIONNAME',pic:'',hsh:true}]");
         setEventMetadata("GRID_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID_NEXTPAGE","{handler:'subgrid_nextpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV17SDTPermission',fld:'vSDTPERMISSION',grid:28,pic:''},{av:'nGXsfl_28_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:28},{av:'nRC_GXsfl_28',ctrl:'GRID',prop:'GridRC',grid:28},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV19RoleId',fld:'vROLEID',pic:'ZZZZZ9',hsh:true},{av:'AV26newPermissionName',fld:'vNEWPERMISSIONNAME',pic:'',hsh:true}]");
         setEventMetadata("GRID_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID_LASTPAGE","{handler:'subgrid_lastpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV17SDTPermission',fld:'vSDTPERMISSION',grid:28,pic:''},{av:'nGXsfl_28_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:28},{av:'nRC_GXsfl_28',ctrl:'GRID',prop:'GridRC',grid:28},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV19RoleId',fld:'vROLEID',pic:'ZZZZZ9',hsh:true},{av:'AV26newPermissionName',fld:'vNEWPERMISSIONNAME',pic:'',hsh:true}]");
         setEventMetadata("GRID_LASTPAGE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Gxv3',iparms:[]");
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
         AV26newPermissionName = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV17SDTPermission = new GXBaseCollection<SdtSDTPermission_SDTPermissionItem>( context, "SDTPermissionItem", "mtaKB");
         A107PermissionName = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnconfirmar_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         AV24PermissionName = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV32Pgmname = "";
         GXt_SdtSDTContextSession1 = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         scmdbuf = "";
         H003I2_A106PermissionId = new int[1] ;
         H003I2_A107PermissionName = new string[] {""} ;
         AV18SDTPermissionItem = new SdtSDTPermission_SDTPermissionItem(context);
         AV21RolePermission = new SdtRole_Permission(context);
         AV22Role = new SdtRole(context);
         AV23SDTPermissionAux = new GXBaseCollection<SdtSDTPermission_SDTPermissionItem>( context, "SDTPermissionItem", "mtaKB");
         lV24PermissionName = "";
         H003I3_A107PermissionName = new string[] {""} ;
         H003I3_A106PermissionId = new int[1] ;
         GridRow = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         subGrid_Header = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wproleassignpermission__default(),
            new Object[][] {
                new Object[] {
               H003I2_A106PermissionId, H003I2_A107PermissionName
               }
               , new Object[] {
               H003I3_A107PermissionName, H003I3_A106PermissionId
               }
            }
         );
         AV32Pgmname = "WPRoleAssignPermission";
         /* GeneXus formulas. */
         AV32Pgmname = "WPRoleAssignPermission";
         context.Gx_err = 0;
         edtavCtlpermissionname_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
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
      private short AV25Count ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int AV19RoleId ;
      private int wcpOAV19RoleId ;
      private int nRC_GXsfl_28 ;
      private int subGrid_Rows ;
      private int nGXsfl_28_idx=1 ;
      private int A106PermissionId ;
      private int bttBtnconfirmar_Visible ;
      private int bttBtnconfirmar_Enabled ;
      private int edtavPermissionname_Enabled ;
      private int AV29GXV1 ;
      private int subGrid_Islastpage ;
      private int edtavCtlpermissionname_Enabled ;
      private int nGXsfl_28_fel_idx=1 ;
      private int AV34GXV4 ;
      private int nGXsfl_28_bak_idx=1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_28_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divTable1_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnconfirmar_Internalname ;
      private string bttBtnconfirmar_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string edtavPermissionname_Internalname ;
      private string edtavPermissionname_Jsonclick ;
      private string divGridcell_Internalname ;
      private string divGridtable_Internalname ;
      private string divGridcontainer_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV32Pgmname ;
      private string edtavCtlpermissionname_Internalname ;
      private string sGXsfl_28_fel_idx="0001" ;
      private string scmdbuf ;
      private string chkavCtlselected_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string divGrid1table_Internalname ;
      private string ROClassString ;
      private string edtavCtlpermissionname_Jsonclick ;
      private string GXCCtl ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_28_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_BV28 ;
      private string AV26newPermissionName ;
      private string A107PermissionName ;
      private string AV24PermissionName ;
      private string lV24PermissionName ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavCtlselected ;
      private IDataStoreProvider pr_default ;
      private int[] H003I2_A106PermissionId ;
      private string[] H003I2_A107PermissionName ;
      private string[] H003I3_A107PermissionName ;
      private int[] H003I3_A106PermissionId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<SdtSDTPermission_SDTPermissionItem> AV17SDTPermission ;
      private GXBaseCollection<SdtSDTPermission_SDTPermissionItem> AV23SDTPermissionAux ;
      private GXWebForm Form ;
      private SdtRole AV22Role ;
      private SdtRole_Permission AV21RolePermission ;
      private SdtSDTPermission_SDTPermissionItem AV18SDTPermissionItem ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession GXt_SdtSDTContextSession1 ;
   }

   public class wproleassignpermission__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H003I3( IGxContext context ,
                                             string AV24PermissionName ,
                                             string A107PermissionName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[1];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [PermissionName], [PermissionId] FROM [Permission]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24PermissionName)) )
         {
            AddWhere(sWhereString, "([PermissionName] like ( '%' + @lV24PermissionName + '%'))");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [PermissionId]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_H003I3(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmH003I2;
          prmH003I2 = new Object[] {
          };
          Object[] prmH003I3;
          prmH003I3 = new Object[] {
          new ParDef("@lV24PermissionName",GXType.NVarChar,60,0)
          };
          def= new CursorDef[] {
              new CursorDef("H003I2", "SELECT [PermissionId], [PermissionName] FROM [Permission] ORDER BY [PermissionId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003I2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H003I3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003I3,100, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
       }
    }

 }

}
