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
   public class role : GXDataArea
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetFirstPar( "Mode");
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A106PermissionId = (int)(Math.Round(NumberUtil.Val( GetPar( "PermissionId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A106PermissionId) ;
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
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridrole_permission") == 0 )
         {
            gxnrGridrole_permission_newrow_invoke( ) ;
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
            Gx_mode = gxfirstwebparm;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
            {
               AV7RoleId = (int)(Math.Round(NumberUtil.Val( GetPar( "RoleId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7RoleId", StringUtil.LTrimStr( (decimal)(AV7RoleId), 6, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7RoleId), "ZZZZZ9"), context));
            }
         }
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
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
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_2-169539", 0) ;
            }
            Form.Meta.addItem("description", "Role", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtRoleName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("mtaKB", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridrole_permission_newrow_invoke( )
      {
         nRC_GXsfl_48 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_48"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_48_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_48_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_48_idx = GetPar( "sGXsfl_48_idx");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridrole_permission_newrow( ) ;
         /* End function gxnrGridrole_permission_newrow_invoke */
      }

      public role( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public role( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_RoleId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7RoleId = aP1_RoleId;
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

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
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

      protected void fix_multi_value_controls( )
      {
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "title-container", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Role", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Role.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
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
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "form-container", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 form__toolbar-cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-first";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Role.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Role.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Role.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Role.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Role.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell-advanced", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRoleId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRoleId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtRoleId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A104RoleId), 6, 0, ".", "")), StringUtil.LTrim( ((edtRoleId_Enabled!=0) ? context.localUtil.Format( (decimal)(A104RoleId), "ZZZZZ9") : context.localUtil.Format( (decimal)(A104RoleId), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRoleId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRoleId_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_Role.htm");
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
         GxWebStd.gx_label_element( context, edtRoleName_Internalname, "Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRoleName_Internalname, A105RoleName, StringUtil.RTrim( context.localUtil.Format( A105RoleName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRoleName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRoleName_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Name", "left", true, "", "HLP_Role.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divPermissiontable_Internalname, 1, 0, "px", 0, "px", "form__table-level", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitlepermission_Internalname, "Permission", "", "", lblTitlepermission_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-04", 0, "", 1, 1, 0, 0, "HLP_Role.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         gxdraw_Gridrole_permission( ) ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__actions--fixed", "Right", "Middle", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Role.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Role.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Role.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "Right", "Middle", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void gxdraw_Gridrole_permission( )
      {
         /*  Grid Control  */
         StartGridControl48( ) ;
         nGXsfl_48_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount19 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_19 = 1;
               ScanStart0C19( ) ;
               while ( RcdFound19 != 0 )
               {
                  init_level_properties19( ) ;
                  getByPrimaryKey0C19( ) ;
                  AddRow0C19( ) ;
                  ScanNext0C19( ) ;
               }
               ScanEnd0C19( ) ;
               nBlankRcdCount19 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal0C19( ) ;
            standaloneModal0C19( ) ;
            sMode19 = Gx_mode;
            while ( nGXsfl_48_idx < nRC_GXsfl_48 )
            {
               bGXsfl_48_Refreshing = true;
               ReadRow0C19( ) ;
               edtPermissionId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PERMISSIONID_"+sGXsfl_48_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtPermissionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPermissionId_Enabled), 5, 0), !bGXsfl_48_Refreshing);
               edtPermissionName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PERMISSIONNAME_"+sGXsfl_48_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtPermissionName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPermissionName_Enabled), 5, 0), !bGXsfl_48_Refreshing);
               imgprompt_106_Link = cgiGet( "PROMPT_106_"+sGXsfl_48_idx+"Link");
               if ( ( nRcdExists_19 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0C19( ) ;
               }
               SendRow0C19( ) ;
               bGXsfl_48_Refreshing = false;
            }
            Gx_mode = sMode19;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount19 = 5;
            nRcdExists_19 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0C19( ) ;
               while ( RcdFound19 != 0 )
               {
                  sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_4819( ) ;
                  init_level_properties19( ) ;
                  standaloneNotModal0C19( ) ;
                  getByPrimaryKey0C19( ) ;
                  standaloneModal0C19( ) ;
                  AddRow0C19( ) ;
                  ScanNext0C19( ) ;
               }
               ScanEnd0C19( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode19 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx+1), 4, 0), 4, "0");
            SubsflControlProps_4819( ) ;
            InitAll0C19( ) ;
            init_level_properties19( ) ;
            nRcdExists_19 = 0;
            nIsMod_19 = 0;
            nRcdDeleted_19 = 0;
            nBlankRcdCount19 = (short)(nBlankRcdUsr19+nBlankRcdCount19);
            fRowAdded = 0;
            while ( nBlankRcdCount19 > 0 )
            {
               standaloneNotModal0C19( ) ;
               standaloneModal0C19( ) ;
               AddRow0C19( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtPermissionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount19 = (short)(nBlankRcdCount19-1);
            }
            Gx_mode = sMode19;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridrole_permissionContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridrole_permission", Gridrole_permissionContainer, subGridrole_permission_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridrole_permissionContainerData", Gridrole_permissionContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridrole_permissionContainerData"+"V", Gridrole_permissionContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridrole_permissionContainerData"+"V"+"\" value='"+Gridrole_permissionContainer.GridValuesHidden()+"'/>") ;
         }
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110C2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z104RoleId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z104RoleId"), ".", ","), 18, MidpointRounding.ToEven));
               Z105RoleName = cgiGet( "Z105RoleName");
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_48 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_48"), ".", ","), 18, MidpointRounding.ToEven));
               AV7RoleId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vROLEID"), ".", ","), 18, MidpointRounding.ToEven));
               AV13Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A104RoleId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtRoleId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               n104RoleId = false;
               AssignAttri("", false, "A104RoleId", StringUtil.LTrimStr( (decimal)(A104RoleId), 6, 0));
               A105RoleName = cgiGet( edtRoleName_Internalname);
               AssignAttri("", false, "A105RoleName", A105RoleName);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Role");
               A104RoleId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtRoleId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               n104RoleId = false;
               AssignAttri("", false, "A104RoleId", StringUtil.LTrimStr( (decimal)(A104RoleId), 6, 0));
               forbiddenHiddens.Add("RoleId", context.localUtil.Format( (decimal)(A104RoleId), "ZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A104RoleId != Z104RoleId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("role:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               /* Check if conditions changed and reset current page numbers */
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A104RoleId = (int)(Math.Round(NumberUtil.Val( GetPar( "RoleId"), "."), 18, MidpointRounding.ToEven));
                  n104RoleId = false;
                  AssignAttri("", false, "A104RoleId", StringUtil.LTrimStr( (decimal)(A104RoleId), 6, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode17 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode17;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound17 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0C0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "ROLEID");
                        AnyError = 1;
                        GX_FocusControl = edtRoleId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
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
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E110C2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120C2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                     }
                     else
                     {
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E120C2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0C17( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtn_delete_Visible = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtn_enter_Visible = 0;
               AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
            }
            DisableAttributes0C17( ) ;
         }
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void CONFIRM_0C0( )
      {
         BeforeValidate0C17( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0C17( ) ;
            }
            else
            {
               CheckExtendedTable0C17( ) ;
               CloseExtendedTableCursors0C17( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode17 = Gx_mode;
            CONFIRM_0C19( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode17;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode17;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_0C19( )
      {
         nGXsfl_48_idx = 0;
         while ( nGXsfl_48_idx < nRC_GXsfl_48 )
         {
            ReadRow0C19( ) ;
            if ( ( nRcdExists_19 != 0 ) || ( nIsMod_19 != 0 ) )
            {
               GetKey0C19( ) ;
               if ( ( nRcdExists_19 == 0 ) && ( nRcdDeleted_19 == 0 ) )
               {
                  if ( RcdFound19 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0C19( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0C19( ) ;
                        CloseExtendedTableCursors0C19( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "PERMISSIONID_" + sGXsfl_48_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtPermissionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound19 != 0 )
                  {
                     if ( nRcdDeleted_19 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0C19( ) ;
                        Load0C19( ) ;
                        BeforeValidate0C19( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0C19( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_19 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0C19( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0C19( ) ;
                              CloseExtendedTableCursors0C19( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_19 == 0 )
                     {
                        GXCCtl = "PERMISSIONID_" + sGXsfl_48_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtPermissionId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtPermissionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A106PermissionId), 6, 0, ".", ""))) ;
            ChangePostValue( edtPermissionName_Internalname, A107PermissionName) ;
            ChangePostValue( "ZT_"+"Z106PermissionId_"+sGXsfl_48_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z106PermissionId), 6, 0, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_19_"+sGXsfl_48_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_19), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_19_"+sGXsfl_48_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_19), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_19_"+sGXsfl_48_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_19), 4, 0, ".", ""))) ;
            if ( nIsMod_19 != 0 )
            {
               ChangePostValue( "PERMISSIONID_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPermissionId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PERMISSIONNAME_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPermissionName_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption0C0( )
      {
      }

      protected void E110C2( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtSDTContextSession1 = new GeneXus.Programs.general.ui.SdtSDTContextSession();
         new checkauthentication(context ).execute( out  GXt_SdtSDTContextSession1) ;
         if ( ! new haspermission(context).executeUdp(  "permission view") )
         {
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && ! new haspermission(context).executeUdp(  "role view") )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         else if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! new haspermission(context).executeUdp(  "role insert") )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         else if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ! new haspermission(context).executeUdp(  "role update") )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         else if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! new haspermission(context).executeUdp(  "role delete") )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV13Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            bttBtn_enter_Caption = "Delete";
            AssignProp("", false, bttBtn_enter_Internalname, "Caption", bttBtn_enter_Caption, true);
            bttBtn_enter_Tooltiptext = "Delete";
            AssignProp("", false, bttBtn_enter_Internalname, "Tooltiptext", bttBtn_enter_Tooltiptext, true);
         }
      }

      protected void E120C2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwrole.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0C17( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z105RoleName = T000C6_A105RoleName[0];
            }
            else
            {
               Z105RoleName = A105RoleName;
            }
         }
         if ( GX_JID == -3 )
         {
            Z104RoleId = A104RoleId;
            Z105RoleName = A105RoleName;
         }
      }

      protected void standaloneNotModal( )
      {
         edtRoleId_Enabled = 0;
         AssignProp("", false, edtRoleId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRoleId_Enabled), 5, 0), true);
         edtRoleId_Enabled = 0;
         AssignProp("", false, edtRoleId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRoleId_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7RoleId) )
         {
            A104RoleId = AV7RoleId;
            n104RoleId = false;
            AssignAttri("", false, "A104RoleId", StringUtil.LTrimStr( (decimal)(A104RoleId), 6, 0));
         }
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
      }

      protected void Load0C17( )
      {
         /* Using cursor T000C7 */
         pr_default.execute(5, new Object[] {n104RoleId, A104RoleId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound17 = 1;
            A105RoleName = T000C7_A105RoleName[0];
            AssignAttri("", false, "A105RoleName", A105RoleName);
            ZM0C17( -3) ;
         }
         pr_default.close(5);
         OnLoadActions0C17( ) ;
      }

      protected void OnLoadActions0C17( )
      {
         AV13Pgmname = "Role";
         AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
      }

      protected void CheckExtendedTable0C17( )
      {
         nIsDirty_17 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV13Pgmname = "Role";
         AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
         /* Using cursor T000C8 */
         pr_default.execute(6, new Object[] {A105RoleName, n104RoleId, A104RoleId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Role Name"}), 1, "ROLENAME");
            AnyError = 1;
            GX_FocusControl = edtRoleName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(6);
      }

      protected void CloseExtendedTableCursors0C17( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0C17( )
      {
         /* Using cursor T000C9 */
         pr_default.execute(7, new Object[] {n104RoleId, A104RoleId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound17 = 1;
         }
         else
         {
            RcdFound17 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000C6 */
         pr_default.execute(4, new Object[] {n104RoleId, A104RoleId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM0C17( 3) ;
            RcdFound17 = 1;
            A104RoleId = T000C6_A104RoleId[0];
            n104RoleId = T000C6_n104RoleId[0];
            AssignAttri("", false, "A104RoleId", StringUtil.LTrimStr( (decimal)(A104RoleId), 6, 0));
            A105RoleName = T000C6_A105RoleName[0];
            AssignAttri("", false, "A105RoleName", A105RoleName);
            Z104RoleId = A104RoleId;
            sMode17 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0C17( ) ;
            if ( AnyError == 1 )
            {
               RcdFound17 = 0;
               InitializeNonKey0C17( ) ;
            }
            Gx_mode = sMode17;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound17 = 0;
            InitializeNonKey0C17( ) ;
            sMode17 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode17;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(4);
      }

      protected void getEqualNoModal( )
      {
         GetKey0C17( ) ;
         if ( RcdFound17 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound17 = 0;
         /* Using cursor T000C10 */
         pr_default.execute(8, new Object[] {n104RoleId, A104RoleId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000C10_A104RoleId[0] < A104RoleId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000C10_A104RoleId[0] > A104RoleId ) ) )
            {
               A104RoleId = T000C10_A104RoleId[0];
               n104RoleId = T000C10_n104RoleId[0];
               AssignAttri("", false, "A104RoleId", StringUtil.LTrimStr( (decimal)(A104RoleId), 6, 0));
               RcdFound17 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound17 = 0;
         /* Using cursor T000C11 */
         pr_default.execute(9, new Object[] {n104RoleId, A104RoleId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000C11_A104RoleId[0] > A104RoleId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000C11_A104RoleId[0] < A104RoleId ) ) )
            {
               A104RoleId = T000C11_A104RoleId[0];
               n104RoleId = T000C11_n104RoleId[0];
               AssignAttri("", false, "A104RoleId", StringUtil.LTrimStr( (decimal)(A104RoleId), 6, 0));
               RcdFound17 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0C17( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtRoleName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0C17( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound17 == 1 )
            {
               if ( A104RoleId != Z104RoleId )
               {
                  A104RoleId = Z104RoleId;
                  n104RoleId = false;
                  AssignAttri("", false, "A104RoleId", StringUtil.LTrimStr( (decimal)(A104RoleId), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ROLEID");
                  AnyError = 1;
                  GX_FocusControl = edtRoleId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtRoleName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0C17( ) ;
                  GX_FocusControl = edtRoleName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A104RoleId != Z104RoleId )
               {
                  /* Insert record */
                  GX_FocusControl = edtRoleName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0C17( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ROLEID");
                     AnyError = 1;
                     GX_FocusControl = edtRoleId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtRoleName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0C17( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A104RoleId != Z104RoleId )
         {
            A104RoleId = Z104RoleId;
            n104RoleId = false;
            AssignAttri("", false, "A104RoleId", StringUtil.LTrimStr( (decimal)(A104RoleId), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ROLEID");
            AnyError = 1;
            GX_FocusControl = edtRoleId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtRoleName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0C17( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000C5 */
            pr_default.execute(3, new Object[] {n104RoleId, A104RoleId});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Role"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(3) == 101) || ( StringUtil.StrCmp(Z105RoleName, T000C5_A105RoleName[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z105RoleName, T000C5_A105RoleName[0]) != 0 )
               {
                  GXUtil.WriteLog("role:[seudo value changed for attri]"+"RoleName");
                  GXUtil.WriteLogRaw("Old: ",Z105RoleName);
                  GXUtil.WriteLogRaw("Current: ",T000C5_A105RoleName[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Role"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0C17( )
      {
         BeforeValidate0C17( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C17( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0C17( 0) ;
            CheckOptimisticConcurrency0C17( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C17( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0C17( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000C12 */
                     pr_default.execute(10, new Object[] {A105RoleName});
                     A104RoleId = T000C12_A104RoleId[0];
                     n104RoleId = T000C12_n104RoleId[0];
                     AssignAttri("", false, "A104RoleId", StringUtil.LTrimStr( (decimal)(A104RoleId), 6, 0));
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Role");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0C17( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption0C0( ) ;
                           }
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load0C17( ) ;
            }
            EndLevel0C17( ) ;
         }
         CloseExtendedTableCursors0C17( ) ;
      }

      protected void Update0C17( )
      {
         BeforeValidate0C17( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C17( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C17( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C17( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0C17( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000C13 */
                     pr_default.execute(11, new Object[] {A105RoleName, n104RoleId, A104RoleId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Role");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Role"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0C17( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0C17( ) ;
                           if ( AnyError == 0 )
                           {
                              if ( IsUpd( ) || IsDlt( ) )
                              {
                                 if ( AnyError == 0 )
                                 {
                                    context.nUserReturn = 1;
                                 }
                              }
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel0C17( ) ;
         }
         CloseExtendedTableCursors0C17( ) ;
      }

      protected void DeferredUpdate0C17( )
      {
      }

      protected void delete( )
      {
         BeforeValidate0C17( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C17( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0C17( ) ;
            AfterConfirm0C17( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0C17( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart0C19( ) ;
                  while ( RcdFound19 != 0 )
                  {
                     getByPrimaryKey0C19( ) ;
                     Delete0C19( ) ;
                     ScanNext0C19( ) ;
                  }
                  ScanEnd0C19( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000C14 */
                     pr_default.execute(12, new Object[] {n104RoleId, A104RoleId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("Role");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
         }
         sMode17 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0C17( ) ;
         Gx_mode = sMode17;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0C17( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV13Pgmname = "Role";
            AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000C15 */
            pr_default.execute(13, new Object[] {n104RoleId, A104RoleId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"User"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
         }
      }

      protected void ProcessNestedLevel0C19( )
      {
         nGXsfl_48_idx = 0;
         while ( nGXsfl_48_idx < nRC_GXsfl_48 )
         {
            ReadRow0C19( ) ;
            if ( ( nRcdExists_19 != 0 ) || ( nIsMod_19 != 0 ) )
            {
               standaloneNotModal0C19( ) ;
               GetKey0C19( ) ;
               if ( ( nRcdExists_19 == 0 ) && ( nRcdDeleted_19 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0C19( ) ;
               }
               else
               {
                  if ( RcdFound19 != 0 )
                  {
                     if ( ( nRcdDeleted_19 != 0 ) && ( nRcdExists_19 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0C19( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_19 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0C19( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_19 == 0 )
                     {
                        GXCCtl = "PERMISSIONID_" + sGXsfl_48_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtPermissionId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtPermissionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A106PermissionId), 6, 0, ".", ""))) ;
            ChangePostValue( edtPermissionName_Internalname, A107PermissionName) ;
            ChangePostValue( "ZT_"+"Z106PermissionId_"+sGXsfl_48_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z106PermissionId), 6, 0, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_19_"+sGXsfl_48_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_19), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_19_"+sGXsfl_48_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_19), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_19_"+sGXsfl_48_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_19), 4, 0, ".", ""))) ;
            if ( nIsMod_19 != 0 )
            {
               ChangePostValue( "PERMISSIONID_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPermissionId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PERMISSIONNAME_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPermissionName_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0C19( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_19 = 0;
         nIsMod_19 = 0;
         nRcdDeleted_19 = 0;
      }

      protected void ProcessLevel0C17( )
      {
         /* Save parent mode. */
         sMode17 = Gx_mode;
         ProcessNestedLevel0C19( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode17;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel0C17( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0C17( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            context.CommitDataStores("role",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0C0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            context.RollbackDataStores("role",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0C17( )
      {
         /* Scan By routine */
         /* Using cursor T000C16 */
         pr_default.execute(14);
         RcdFound17 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound17 = 1;
            A104RoleId = T000C16_A104RoleId[0];
            n104RoleId = T000C16_n104RoleId[0];
            AssignAttri("", false, "A104RoleId", StringUtil.LTrimStr( (decimal)(A104RoleId), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0C17( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound17 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound17 = 1;
            A104RoleId = T000C16_A104RoleId[0];
            n104RoleId = T000C16_n104RoleId[0];
            AssignAttri("", false, "A104RoleId", StringUtil.LTrimStr( (decimal)(A104RoleId), 6, 0));
         }
      }

      protected void ScanEnd0C17( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm0C17( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0C17( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0C17( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0C17( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0C17( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0C17( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0C17( )
      {
         edtRoleId_Enabled = 0;
         AssignProp("", false, edtRoleId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRoleId_Enabled), 5, 0), true);
         edtRoleName_Enabled = 0;
         AssignProp("", false, edtRoleName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRoleName_Enabled), 5, 0), true);
      }

      protected void ZM0C19( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
            }
            else
            {
            }
         }
         if ( GX_JID == -5 )
         {
            Z104RoleId = A104RoleId;
            Z106PermissionId = A106PermissionId;
            Z107PermissionName = A107PermissionName;
         }
      }

      protected void standaloneNotModal0C19( )
      {
      }

      protected void standaloneModal0C19( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtPermissionId_Enabled = 0;
            AssignProp("", false, edtPermissionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPermissionId_Enabled), 5, 0), !bGXsfl_48_Refreshing);
         }
         else
         {
            edtPermissionId_Enabled = 1;
            AssignProp("", false, edtPermissionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPermissionId_Enabled), 5, 0), !bGXsfl_48_Refreshing);
         }
      }

      protected void Load0C19( )
      {
         /* Using cursor T000C17 */
         pr_default.execute(15, new Object[] {n104RoleId, A104RoleId, A106PermissionId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound19 = 1;
            A107PermissionName = T000C17_A107PermissionName[0];
            ZM0C19( -5) ;
         }
         pr_default.close(15);
         OnLoadActions0C19( ) ;
      }

      protected void OnLoadActions0C19( )
      {
      }

      protected void CheckExtendedTable0C19( )
      {
         nIsDirty_19 = 0;
         Gx_BScreen = 1;
         standaloneModal0C19( ) ;
         /* Using cursor T000C4 */
         pr_default.execute(2, new Object[] {A106PermissionId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "PERMISSIONID_" + sGXsfl_48_idx;
            GX_msglist.addItem("No matching 'Permission'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtPermissionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A107PermissionName = T000C4_A107PermissionName[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0C19( )
      {
         pr_default.close(2);
      }

      protected void enableDisable0C19( )
      {
      }

      protected void gxLoad_6( int A106PermissionId )
      {
         /* Using cursor T000C18 */
         pr_default.execute(16, new Object[] {A106PermissionId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GXCCtl = "PERMISSIONID_" + sGXsfl_48_idx;
            GX_msglist.addItem("No matching 'Permission'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtPermissionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A107PermissionName = T000C18_A107PermissionName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A107PermissionName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(16) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(16);
      }

      protected void GetKey0C19( )
      {
         /* Using cursor T000C19 */
         pr_default.execute(17, new Object[] {n104RoleId, A104RoleId, A106PermissionId});
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound19 = 1;
         }
         else
         {
            RcdFound19 = 0;
         }
         pr_default.close(17);
      }

      protected void getByPrimaryKey0C19( )
      {
         /* Using cursor T000C3 */
         pr_default.execute(1, new Object[] {n104RoleId, A104RoleId, A106PermissionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0C19( 5) ;
            RcdFound19 = 1;
            InitializeNonKey0C19( ) ;
            A106PermissionId = T000C3_A106PermissionId[0];
            Z104RoleId = A104RoleId;
            Z106PermissionId = A106PermissionId;
            sMode19 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0C19( ) ;
            Gx_mode = sMode19;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound19 = 0;
            InitializeNonKey0C19( ) ;
            sMode19 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0C19( ) ;
            Gx_mode = sMode19;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0C19( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0C19( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000C2 */
            pr_default.execute(0, new Object[] {n104RoleId, A104RoleId, A106PermissionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"RolePermission"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"RolePermission"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0C19( )
      {
         BeforeValidate0C19( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C19( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0C19( 0) ;
            CheckOptimisticConcurrency0C19( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C19( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0C19( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000C20 */
                     pr_default.execute(18, new Object[] {n104RoleId, A104RoleId, A106PermissionId});
                     pr_default.close(18);
                     pr_default.SmartCacheProvider.SetUpdated("RolePermission");
                     if ( (pr_default.getStatus(18) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load0C19( ) ;
            }
            EndLevel0C19( ) ;
         }
         CloseExtendedTableCursors0C19( ) ;
      }

      protected void Update0C19( )
      {
         BeforeValidate0C19( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C19( ) ;
         }
         if ( ( nIsMod_19 != 0 ) || ( nIsDirty_19 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0C19( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0C19( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0C19( ) ;
                     if ( AnyError == 0 )
                     {
                        /* No attributes to update on table [RolePermission] */
                        DeferredUpdate0C19( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0C19( ) ;
                           }
                        }
                        else
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                           AnyError = 1;
                        }
                     }
                  }
               }
               EndLevel0C19( ) ;
            }
         }
         CloseExtendedTableCursors0C19( ) ;
      }

      protected void DeferredUpdate0C19( )
      {
      }

      protected void Delete0C19( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0C19( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C19( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0C19( ) ;
            AfterConfirm0C19( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0C19( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000C21 */
                  pr_default.execute(19, new Object[] {n104RoleId, A104RoleId, A106PermissionId});
                  pr_default.close(19);
                  pr_default.SmartCacheProvider.SetUpdated("RolePermission");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode19 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0C19( ) ;
         Gx_mode = sMode19;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0C19( )
      {
         standaloneModal0C19( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000C22 */
            pr_default.execute(20, new Object[] {A106PermissionId});
            A107PermissionName = T000C22_A107PermissionName[0];
            pr_default.close(20);
         }
      }

      protected void EndLevel0C19( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0C19( )
      {
         /* Scan By routine */
         /* Using cursor T000C23 */
         pr_default.execute(21, new Object[] {n104RoleId, A104RoleId});
         RcdFound19 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound19 = 1;
            A106PermissionId = T000C23_A106PermissionId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0C19( )
      {
         /* Scan next routine */
         pr_default.readNext(21);
         RcdFound19 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound19 = 1;
            A106PermissionId = T000C23_A106PermissionId[0];
         }
      }

      protected void ScanEnd0C19( )
      {
         pr_default.close(21);
      }

      protected void AfterConfirm0C19( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0C19( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0C19( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0C19( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0C19( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0C19( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0C19( )
      {
         edtPermissionId_Enabled = 0;
         AssignProp("", false, edtPermissionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPermissionId_Enabled), 5, 0), !bGXsfl_48_Refreshing);
         edtPermissionName_Enabled = 0;
         AssignProp("", false, edtPermissionName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPermissionName_Enabled), 5, 0), !bGXsfl_48_Refreshing);
      }

      protected void send_integrity_lvl_hashes0C19( )
      {
      }

      protected void send_integrity_lvl_hashes0C17( )
      {
      }

      protected void SubsflControlProps_4819( )
      {
         edtPermissionId_Internalname = "PERMISSIONID_"+sGXsfl_48_idx;
         imgprompt_106_Internalname = "PROMPT_106_"+sGXsfl_48_idx;
         edtPermissionName_Internalname = "PERMISSIONNAME_"+sGXsfl_48_idx;
      }

      protected void SubsflControlProps_fel_4819( )
      {
         edtPermissionId_Internalname = "PERMISSIONID_"+sGXsfl_48_fel_idx;
         imgprompt_106_Internalname = "PROMPT_106_"+sGXsfl_48_fel_idx;
         edtPermissionName_Internalname = "PERMISSIONNAME_"+sGXsfl_48_fel_idx;
      }

      protected void AddRow0C19( )
      {
         nGXsfl_48_idx = (int)(nGXsfl_48_idx+1);
         sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx), 4, 0), 4, "0");
         SubsflControlProps_4819( ) ;
         SendRow0C19( ) ;
      }

      protected void SendRow0C19( )
      {
         Gridrole_permissionRow = GXWebRow.GetNew(context);
         if ( subGridrole_permission_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridrole_permission_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridrole_permission_Class, "") != 0 )
            {
               subGridrole_permission_Linesclass = subGridrole_permission_Class+"Odd";
            }
         }
         else if ( subGridrole_permission_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridrole_permission_Backstyle = 0;
            subGridrole_permission_Backcolor = subGridrole_permission_Allbackcolor;
            if ( StringUtil.StrCmp(subGridrole_permission_Class, "") != 0 )
            {
               subGridrole_permission_Linesclass = subGridrole_permission_Class+"Uniform";
            }
         }
         else if ( subGridrole_permission_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridrole_permission_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridrole_permission_Class, "") != 0 )
            {
               subGridrole_permission_Linesclass = subGridrole_permission_Class+"Odd";
            }
            subGridrole_permission_Backcolor = (int)(0x0);
         }
         else if ( subGridrole_permission_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridrole_permission_Backstyle = 1;
            if ( ((int)((nGXsfl_48_idx) % (2))) == 0 )
            {
               subGridrole_permission_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridrole_permission_Class, "") != 0 )
               {
                  subGridrole_permission_Linesclass = subGridrole_permission_Class+"Even";
               }
            }
            else
            {
               subGridrole_permission_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridrole_permission_Class, "") != 0 )
               {
                  subGridrole_permission_Linesclass = subGridrole_permission_Class+"Odd";
               }
            }
         }
         imgprompt_106_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx00i0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PERMISSIONID_"+sGXsfl_48_idx+"'), id:'"+"PERMISSIONID_"+sGXsfl_48_idx+"'"+",IOType:'out'}"+"],"+"gx.dom.form()."+"nIsMod_19_"+sGXsfl_48_idx+","+"'', false"+","+"false"+");");
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_19_" + sGXsfl_48_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 49,'',false,'" + sGXsfl_48_idx + "',48)\"";
         ROClassString = "Attribute";
         Gridrole_permissionRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPermissionId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A106PermissionId), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A106PermissionId), "ZZZZZ9"))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,49);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPermissionId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtPermissionId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)48,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_106_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_106_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         Gridrole_permissionRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_106_Internalname,(string)sImgUrl,(string)imgprompt_106_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_106_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridrole_permissionRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPermissionName_Internalname,(string)A107PermissionName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPermissionName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtPermissionName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)48,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
         ajax_sending_grid_row(Gridrole_permissionRow);
         send_integrity_lvl_hashes0C19( ) ;
         GXCCtl = "Z106PermissionId_" + sGXsfl_48_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z106PermissionId), 6, 0, ".", "")));
         GXCCtl = "nRcdDeleted_19_" + sGXsfl_48_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_19), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_19_" + sGXsfl_48_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_19), 4, 0, ".", "")));
         GXCCtl = "nIsMod_19_" + sGXsfl_48_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_19), 4, 0, ".", "")));
         GXCCtl = "vMODE_" + sGXsfl_48_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_48_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV9TrnContext);
         }
         GXCCtl = "vROLEID_" + sGXsfl_48_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7RoleId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PERMISSIONID_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPermissionId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PERMISSIONNAME_"+sGXsfl_48_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPermissionName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_106_"+sGXsfl_48_idx+"Link", StringUtil.RTrim( imgprompt_106_Link));
         ajax_sending_grid_row(null);
         Gridrole_permissionContainer.AddRow(Gridrole_permissionRow);
      }

      protected void ReadRow0C19( )
      {
         nGXsfl_48_idx = (int)(nGXsfl_48_idx+1);
         sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx), 4, 0), 4, "0");
         SubsflControlProps_4819( ) ;
         edtPermissionId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PERMISSIONID_"+sGXsfl_48_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtPermissionName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PERMISSIONNAME_"+sGXsfl_48_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         imgprompt_106_Link = cgiGet( "PROMPT_106_"+sGXsfl_48_idx+"Link");
         if ( ( ( context.localUtil.CToN( cgiGet( edtPermissionId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPermissionId_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
         {
            GXCCtl = "PERMISSIONID_" + sGXsfl_48_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtPermissionId_Internalname;
            wbErr = true;
            A106PermissionId = 0;
         }
         else
         {
            A106PermissionId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPermissionId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
         }
         A107PermissionName = cgiGet( edtPermissionName_Internalname);
         GXCCtl = "Z106PermissionId_" + sGXsfl_48_idx;
         Z106PermissionId = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdDeleted_19_" + sGXsfl_48_idx;
         nRcdDeleted_19 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_19_" + sGXsfl_48_idx;
         nRcdExists_19 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_19_" + sGXsfl_48_idx;
         nIsMod_19 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtPermissionId_Enabled = edtPermissionId_Enabled;
      }

      protected void ConfirmValues0C0( )
      {
         nGXsfl_48_idx = 0;
         sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx), 4, 0), 4, "0");
         SubsflControlProps_4819( ) ;
         while ( nGXsfl_48_idx < nRC_GXsfl_48 )
         {
            nGXsfl_48_idx = (int)(nGXsfl_48_idx+1);
            sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx), 4, 0), 4, "0");
            SubsflControlProps_4819( ) ;
            ChangePostValue( "Z106PermissionId_"+sGXsfl_48_idx, cgiGet( "ZT_"+"Z106PermissionId_"+sGXsfl_48_idx)) ;
            DeletePostValue( "ZT_"+"Z106PermissionId_"+sGXsfl_48_idx) ;
         }
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
         MasterPageObj.master_styles();
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
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("role.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7RoleId,6,0))}, new string[] {"Gx_mode","RoleId"}) +"\">") ;
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
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"Role");
         forbiddenHiddens.Add("RoleId", context.localUtil.Format( (decimal)(A104RoleId), "ZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("role:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z104RoleId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z104RoleId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z105RoleName", Z105RoleName);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_48", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_48_idx), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV9TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV9TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vROLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7RoleId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7RoleId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV13Pgmname));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
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

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("role.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7RoleId,6,0))}, new string[] {"Gx_mode","RoleId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Role" ;
      }

      public override string GetPgmdesc( )
      {
         return "Role" ;
      }

      protected void InitializeNonKey0C17( )
      {
         A105RoleName = "";
         AssignAttri("", false, "A105RoleName", A105RoleName);
         Z105RoleName = "";
      }

      protected void InitAll0C17( )
      {
         A104RoleId = 0;
         n104RoleId = false;
         AssignAttri("", false, "A104RoleId", StringUtil.LTrimStr( (decimal)(A104RoleId), 6, 0));
         InitializeNonKey0C17( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey0C19( )
      {
         A107PermissionName = "";
      }

      protected void InitAll0C19( )
      {
         A106PermissionId = 0;
         InitializeNonKey0C19( ) ;
      }

      protected void StandaloneModalInsert0C19( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024126111580", true, true);
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
         context.AddJavascriptSource("role.js", "?2024126111580", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties19( )
      {
         edtPermissionId_Enabled = defedtPermissionId_Enabled;
         AssignProp("", false, edtPermissionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPermissionId_Enabled), 5, 0), !bGXsfl_48_Refreshing);
      }

      protected void StartGridControl48( )
      {
         Gridrole_permissionContainer.AddObjectProperty("GridName", "Gridrole_permission");
         Gridrole_permissionContainer.AddObjectProperty("Header", subGridrole_permission_Header);
         Gridrole_permissionContainer.AddObjectProperty("Class", "Grid");
         Gridrole_permissionContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridrole_permissionContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridrole_permissionContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridrole_permission_Backcolorstyle), 1, 0, ".", "")));
         Gridrole_permissionContainer.AddObjectProperty("CmpContext", "");
         Gridrole_permissionContainer.AddObjectProperty("InMasterPage", "false");
         Gridrole_permissionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridrole_permissionColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A106PermissionId), 6, 0, ".", ""))));
         Gridrole_permissionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPermissionId_Enabled), 5, 0, ".", "")));
         Gridrole_permissionContainer.AddColumnProperties(Gridrole_permissionColumn);
         Gridrole_permissionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridrole_permissionContainer.AddColumnProperties(Gridrole_permissionColumn);
         Gridrole_permissionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridrole_permissionColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A107PermissionName));
         Gridrole_permissionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPermissionName_Enabled), 5, 0, ".", "")));
         Gridrole_permissionContainer.AddColumnProperties(Gridrole_permissionColumn);
         Gridrole_permissionContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridrole_permission_Selectedindex), 4, 0, ".", "")));
         Gridrole_permissionContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridrole_permission_Allowselection), 1, 0, ".", "")));
         Gridrole_permissionContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridrole_permission_Selectioncolor), 9, 0, ".", "")));
         Gridrole_permissionContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridrole_permission_Allowhovering), 1, 0, ".", "")));
         Gridrole_permissionContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridrole_permission_Hoveringcolor), 9, 0, ".", "")));
         Gridrole_permissionContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridrole_permission_Allowcollapsing), 1, 0, ".", "")));
         Gridrole_permissionContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridrole_permission_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtRoleId_Internalname = "ROLEID";
         edtRoleName_Internalname = "ROLENAME";
         lblTitlepermission_Internalname = "TITLEPERMISSION";
         edtPermissionId_Internalname = "PERMISSIONID";
         edtPermissionName_Internalname = "PERMISSIONNAME";
         divPermissiontable_Internalname = "PERMISSIONTABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_106_Internalname = "PROMPT_106";
         subGridrole_permission_Internalname = "GRIDROLE_PERMISSION";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("mtaKB", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridrole_permission_Allowcollapsing = 0;
         subGridrole_permission_Allowselection = 0;
         subGridrole_permission_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Role";
         edtPermissionName_Jsonclick = "";
         imgprompt_106_Visible = 1;
         imgprompt_106_Link = "";
         imgprompt_106_Visible = 1;
         edtPermissionId_Jsonclick = "";
         subGridrole_permission_Class = "Grid";
         subGridrole_permission_Backcolorstyle = 0;
         edtPermissionName_Enabled = 0;
         edtPermissionId_Enabled = 1;
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirm";
         bttBtn_enter_Caption = "Confirm";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtRoleName_Jsonclick = "";
         edtRoleName_Enabled = 1;
         edtRoleId_Jsonclick = "";
         edtRoleId_Enabled = 0;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridrole_permission_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_4819( ) ;
         while ( nGXsfl_48_idx <= nRC_GXsfl_48 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0C19( ) ;
            standaloneModal0C19( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0C19( ) ;
            nGXsfl_48_idx = (int)(nGXsfl_48_idx+1);
            sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx), 4, 0), 4, "0");
            SubsflControlProps_4819( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridrole_permissionContainer)) ;
         /* End function gxnrGridrole_permission_newrow */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void Valid_Rolename( )
      {
         n104RoleId = false;
         /* Using cursor T000C24 */
         pr_default.execute(22, new Object[] {A105RoleName, n104RoleId, A104RoleId});
         if ( (pr_default.getStatus(22) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Role Name"}), 1, "ROLENAME");
            AnyError = 1;
            GX_FocusControl = edtRoleName_Internalname;
         }
         pr_default.close(22);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Permissionid( )
      {
         /* Using cursor T000C22 */
         pr_default.execute(20, new Object[] {A106PermissionId});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GX_msglist.addItem("No matching 'Permission'.", "ForeignKeyNotFound", 1, "PERMISSIONID");
            AnyError = 1;
            GX_FocusControl = edtPermissionId_Internalname;
         }
         A107PermissionName = T000C22_A107PermissionName[0];
         pr_default.close(20);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A107PermissionName", A107PermissionName);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7RoleId',fld:'vROLEID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7RoleId',fld:'vROLEID',pic:'ZZZZZ9',hsh:true},{av:'A104RoleId',fld:'ROLEID',pic:'ZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120C2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_ROLEID","{handler:'Valid_Roleid',iparms:[]");
         setEventMetadata("VALID_ROLEID",",oparms:[]}");
         setEventMetadata("VALID_ROLENAME","{handler:'Valid_Rolename',iparms:[{av:'A105RoleName',fld:'ROLENAME',pic:''},{av:'A104RoleId',fld:'ROLEID',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_ROLENAME",",oparms:[]}");
         setEventMetadata("VALID_PERMISSIONID","{handler:'Valid_Permissionid',iparms:[{av:'A106PermissionId',fld:'PERMISSIONID',pic:'ZZZZZ9'},{av:'A107PermissionName',fld:'PERMISSIONNAME',pic:''}]");
         setEventMetadata("VALID_PERMISSIONID",",oparms:[{av:'A107PermissionName',fld:'PERMISSIONNAME',pic:''}]}");
         setEventMetadata("NULL","{handler:'Valid_Permissionname',iparms:[]");
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
         pr_default.close(1);
         pr_default.close(20);
         pr_default.close(4);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z105RoleName = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A105RoleName = "";
         lblTitlepermission_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridrole_permissionContainer = new GXWebGrid( context);
         sMode19 = "";
         sStyleString = "";
         AV13Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode17 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A107PermissionName = "";
         GXt_SdtSDTContextSession1 = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         T000C7_A104RoleId = new int[1] ;
         T000C7_n104RoleId = new bool[] {false} ;
         T000C7_A105RoleName = new string[] {""} ;
         T000C8_A105RoleName = new string[] {""} ;
         T000C9_A104RoleId = new int[1] ;
         T000C9_n104RoleId = new bool[] {false} ;
         T000C6_A104RoleId = new int[1] ;
         T000C6_n104RoleId = new bool[] {false} ;
         T000C6_A105RoleName = new string[] {""} ;
         T000C10_A104RoleId = new int[1] ;
         T000C10_n104RoleId = new bool[] {false} ;
         T000C11_A104RoleId = new int[1] ;
         T000C11_n104RoleId = new bool[] {false} ;
         T000C5_A104RoleId = new int[1] ;
         T000C5_n104RoleId = new bool[] {false} ;
         T000C5_A105RoleName = new string[] {""} ;
         T000C12_A104RoleId = new int[1] ;
         T000C12_n104RoleId = new bool[] {false} ;
         T000C15_A99UserId = new int[1] ;
         T000C16_A104RoleId = new int[1] ;
         T000C16_n104RoleId = new bool[] {false} ;
         Z107PermissionName = "";
         T000C17_A104RoleId = new int[1] ;
         T000C17_n104RoleId = new bool[] {false} ;
         T000C17_A107PermissionName = new string[] {""} ;
         T000C17_A106PermissionId = new int[1] ;
         T000C4_A107PermissionName = new string[] {""} ;
         T000C18_A107PermissionName = new string[] {""} ;
         T000C19_A104RoleId = new int[1] ;
         T000C19_n104RoleId = new bool[] {false} ;
         T000C19_A106PermissionId = new int[1] ;
         T000C3_A104RoleId = new int[1] ;
         T000C3_n104RoleId = new bool[] {false} ;
         T000C3_A106PermissionId = new int[1] ;
         T000C2_A104RoleId = new int[1] ;
         T000C2_n104RoleId = new bool[] {false} ;
         T000C2_A106PermissionId = new int[1] ;
         T000C22_A107PermissionName = new string[] {""} ;
         T000C23_A104RoleId = new int[1] ;
         T000C23_n104RoleId = new bool[] {false} ;
         T000C23_A106PermissionId = new int[1] ;
         Gridrole_permissionRow = new GXWebRow();
         subGridrole_permission_Linesclass = "";
         ROClassString = "";
         imgprompt_106_gximage = "";
         sImgUrl = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Gridrole_permissionColumn = new GXWebColumn();
         T000C24_A105RoleName = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.role__default(),
            new Object[][] {
                new Object[] {
               T000C2_A104RoleId, T000C2_A106PermissionId
               }
               , new Object[] {
               T000C3_A104RoleId, T000C3_A106PermissionId
               }
               , new Object[] {
               T000C4_A107PermissionName
               }
               , new Object[] {
               T000C5_A104RoleId, T000C5_A105RoleName
               }
               , new Object[] {
               T000C6_A104RoleId, T000C6_A105RoleName
               }
               , new Object[] {
               T000C7_A104RoleId, T000C7_A105RoleName
               }
               , new Object[] {
               T000C8_A105RoleName
               }
               , new Object[] {
               T000C9_A104RoleId
               }
               , new Object[] {
               T000C10_A104RoleId
               }
               , new Object[] {
               T000C11_A104RoleId
               }
               , new Object[] {
               T000C12_A104RoleId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000C15_A99UserId
               }
               , new Object[] {
               T000C16_A104RoleId
               }
               , new Object[] {
               T000C17_A104RoleId, T000C17_A107PermissionName, T000C17_A106PermissionId
               }
               , new Object[] {
               T000C18_A107PermissionName
               }
               , new Object[] {
               T000C19_A104RoleId, T000C19_A106PermissionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000C22_A107PermissionName
               }
               , new Object[] {
               T000C23_A104RoleId, T000C23_A106PermissionId
               }
               , new Object[] {
               T000C24_A105RoleName
               }
            }
         );
         AV13Pgmname = "Role";
      }

      private short nIsMod_19 ;
      private short nRcdDeleted_19 ;
      private short nRcdExists_19 ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nBlankRcdCount19 ;
      private short RcdFound19 ;
      private short nBlankRcdUsr19 ;
      private short RcdFound17 ;
      private short GX_JID ;
      private short nIsDirty_17 ;
      private short Gx_BScreen ;
      private short nIsDirty_19 ;
      private short subGridrole_permission_Backcolorstyle ;
      private short subGridrole_permission_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridrole_permission_Allowselection ;
      private short subGridrole_permission_Allowhovering ;
      private short subGridrole_permission_Allowcollapsing ;
      private short subGridrole_permission_Collapsed ;
      private int wcpOAV7RoleId ;
      private int Z104RoleId ;
      private int nRC_GXsfl_48 ;
      private int nGXsfl_48_idx=1 ;
      private int Z106PermissionId ;
      private int A106PermissionId ;
      private int AV7RoleId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A104RoleId ;
      private int edtRoleId_Enabled ;
      private int edtRoleName_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtPermissionId_Enabled ;
      private int edtPermissionName_Enabled ;
      private int fRowAdded ;
      private int subGridrole_permission_Backcolor ;
      private int subGridrole_permission_Allbackcolor ;
      private int imgprompt_106_Visible ;
      private int defedtPermissionId_Enabled ;
      private int idxLst ;
      private int subGridrole_permission_Selectedindex ;
      private int subGridrole_permission_Selectioncolor ;
      private int subGridrole_permission_Hoveringcolor ;
      private long GRIDROLE_PERMISSION_nFirstRecordOnPage ;
      private string sPrefix ;
      private string sGXsfl_48_idx="0001" ;
      private string wcpOGx_mode ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtRoleName_Internalname ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string divToolbarcell_Internalname ;
      private string TempTags ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string edtRoleId_Internalname ;
      private string edtRoleId_Jsonclick ;
      private string edtRoleName_Jsonclick ;
      private string divPermissiontable_Internalname ;
      private string lblTitlepermission_Internalname ;
      private string lblTitlepermission_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Caption ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_enter_Tooltiptext ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string sMode19 ;
      private string edtPermissionId_Internalname ;
      private string edtPermissionName_Internalname ;
      private string imgprompt_106_Link ;
      private string sStyleString ;
      private string subGridrole_permission_Internalname ;
      private string AV13Pgmname ;
      private string hsh ;
      private string sMode17 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string imgprompt_106_Internalname ;
      private string sGXsfl_48_fel_idx="0001" ;
      private string subGridrole_permission_Class ;
      private string subGridrole_permission_Linesclass ;
      private string ROClassString ;
      private string edtPermissionId_Jsonclick ;
      private string imgprompt_106_gximage ;
      private string sImgUrl ;
      private string edtPermissionName_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridrole_permission_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool bGXsfl_48_Refreshing=false ;
      private bool n104RoleId ;
      private bool returnInSub ;
      private string Z105RoleName ;
      private string A105RoleName ;
      private string A107PermissionName ;
      private string Z107PermissionName ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridrole_permissionContainer ;
      private GXWebRow Gridrole_permissionRow ;
      private GXWebColumn Gridrole_permissionColumn ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T000C7_A104RoleId ;
      private bool[] T000C7_n104RoleId ;
      private string[] T000C7_A105RoleName ;
      private string[] T000C8_A105RoleName ;
      private int[] T000C9_A104RoleId ;
      private bool[] T000C9_n104RoleId ;
      private int[] T000C6_A104RoleId ;
      private bool[] T000C6_n104RoleId ;
      private string[] T000C6_A105RoleName ;
      private int[] T000C10_A104RoleId ;
      private bool[] T000C10_n104RoleId ;
      private int[] T000C11_A104RoleId ;
      private bool[] T000C11_n104RoleId ;
      private int[] T000C5_A104RoleId ;
      private bool[] T000C5_n104RoleId ;
      private string[] T000C5_A105RoleName ;
      private int[] T000C12_A104RoleId ;
      private bool[] T000C12_n104RoleId ;
      private int[] T000C15_A99UserId ;
      private int[] T000C16_A104RoleId ;
      private bool[] T000C16_n104RoleId ;
      private int[] T000C17_A104RoleId ;
      private bool[] T000C17_n104RoleId ;
      private string[] T000C17_A107PermissionName ;
      private int[] T000C17_A106PermissionId ;
      private string[] T000C4_A107PermissionName ;
      private string[] T000C18_A107PermissionName ;
      private int[] T000C19_A104RoleId ;
      private bool[] T000C19_n104RoleId ;
      private int[] T000C19_A106PermissionId ;
      private int[] T000C3_A104RoleId ;
      private bool[] T000C3_n104RoleId ;
      private int[] T000C3_A106PermissionId ;
      private int[] T000C2_A104RoleId ;
      private bool[] T000C2_n104RoleId ;
      private int[] T000C2_A106PermissionId ;
      private string[] T000C22_A107PermissionName ;
      private int[] T000C23_A104RoleId ;
      private bool[] T000C23_n104RoleId ;
      private int[] T000C23_A106PermissionId ;
      private string[] T000C24_A105RoleName ;
      private GXWebForm Form ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession GXt_SdtSDTContextSession1 ;
   }

   public class role__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new UpdateCursor(def[18])
         ,new UpdateCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000C7;
          prmT000C7 = new Object[] {
          new ParDef("@RoleId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000C8;
          prmT000C8 = new Object[] {
          new ParDef("@RoleName",GXType.NVarChar,60,0) ,
          new ParDef("@RoleId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000C9;
          prmT000C9 = new Object[] {
          new ParDef("@RoleId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000C6;
          prmT000C6 = new Object[] {
          new ParDef("@RoleId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000C10;
          prmT000C10 = new Object[] {
          new ParDef("@RoleId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000C11;
          prmT000C11 = new Object[] {
          new ParDef("@RoleId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000C5;
          prmT000C5 = new Object[] {
          new ParDef("@RoleId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000C12;
          prmT000C12 = new Object[] {
          new ParDef("@RoleName",GXType.NVarChar,60,0)
          };
          Object[] prmT000C13;
          prmT000C13 = new Object[] {
          new ParDef("@RoleName",GXType.NVarChar,60,0) ,
          new ParDef("@RoleId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000C14;
          prmT000C14 = new Object[] {
          new ParDef("@RoleId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000C15;
          prmT000C15 = new Object[] {
          new ParDef("@RoleId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000C16;
          prmT000C16 = new Object[] {
          };
          Object[] prmT000C17;
          prmT000C17 = new Object[] {
          new ParDef("@RoleId",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("@PermissionId",GXType.Int32,6,0)
          };
          Object[] prmT000C4;
          prmT000C4 = new Object[] {
          new ParDef("@PermissionId",GXType.Int32,6,0)
          };
          Object[] prmT000C18;
          prmT000C18 = new Object[] {
          new ParDef("@PermissionId",GXType.Int32,6,0)
          };
          Object[] prmT000C19;
          prmT000C19 = new Object[] {
          new ParDef("@RoleId",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("@PermissionId",GXType.Int32,6,0)
          };
          Object[] prmT000C3;
          prmT000C3 = new Object[] {
          new ParDef("@RoleId",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("@PermissionId",GXType.Int32,6,0)
          };
          Object[] prmT000C2;
          prmT000C2 = new Object[] {
          new ParDef("@RoleId",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("@PermissionId",GXType.Int32,6,0)
          };
          Object[] prmT000C20;
          prmT000C20 = new Object[] {
          new ParDef("@RoleId",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("@PermissionId",GXType.Int32,6,0)
          };
          Object[] prmT000C21;
          prmT000C21 = new Object[] {
          new ParDef("@RoleId",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("@PermissionId",GXType.Int32,6,0)
          };
          Object[] prmT000C23;
          prmT000C23 = new Object[] {
          new ParDef("@RoleId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000C24;
          prmT000C24 = new Object[] {
          new ParDef("@RoleName",GXType.NVarChar,60,0) ,
          new ParDef("@RoleId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000C22;
          prmT000C22 = new Object[] {
          new ParDef("@PermissionId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("T000C2", "SELECT [RoleId], [PermissionId] FROM [RolePermission] WITH (UPDLOCK) WHERE [RoleId] = @RoleId AND [PermissionId] = @PermissionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C3", "SELECT [RoleId], [PermissionId] FROM [RolePermission] WHERE [RoleId] = @RoleId AND [PermissionId] = @PermissionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C4", "SELECT [PermissionName] FROM [Permission] WHERE [PermissionId] = @PermissionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C5", "SELECT [RoleId], [RoleName] FROM [Role] WITH (UPDLOCK) WHERE [RoleId] = @RoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C6", "SELECT [RoleId], [RoleName] FROM [Role] WHERE [RoleId] = @RoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C7", "SELECT TM1.[RoleId], TM1.[RoleName] FROM [Role] TM1 WHERE TM1.[RoleId] = @RoleId ORDER BY TM1.[RoleId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000C7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C8", "SELECT [RoleName] FROM [Role] WHERE ([RoleName] = @RoleName) AND (Not ( [RoleId] = @RoleId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C9", "SELECT [RoleId] FROM [Role] WHERE [RoleId] = @RoleId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000C9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C10", "SELECT TOP 1 [RoleId] FROM [Role] WHERE ( [RoleId] > @RoleId) ORDER BY [RoleId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000C10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000C11", "SELECT TOP 1 [RoleId] FROM [Role] WHERE ( [RoleId] < @RoleId) ORDER BY [RoleId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000C11,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000C12", "INSERT INTO [Role]([RoleName]) VALUES(@RoleName); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000C12,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000C13", "UPDATE [Role] SET [RoleName]=@RoleName  WHERE [RoleId] = @RoleId", GxErrorMask.GX_NOMASK,prmT000C13)
             ,new CursorDef("T000C14", "DELETE FROM [Role]  WHERE [RoleId] = @RoleId", GxErrorMask.GX_NOMASK,prmT000C14)
             ,new CursorDef("T000C15", "SELECT TOP 1 [UserId] FROM [User] WHERE [RoleId] = @RoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C15,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000C16", "SELECT [RoleId] FROM [Role] ORDER BY [RoleId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000C16,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C17", "SELECT T1.[RoleId], T2.[PermissionName], T1.[PermissionId] FROM ([RolePermission] T1 INNER JOIN [Permission] T2 ON T2.[PermissionId] = T1.[PermissionId]) WHERE T1.[RoleId] = @RoleId and T1.[PermissionId] = @PermissionId ORDER BY T1.[RoleId], T1.[PermissionId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C17,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C18", "SELECT [PermissionName] FROM [Permission] WHERE [PermissionId] = @PermissionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C18,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C19", "SELECT [RoleId], [PermissionId] FROM [RolePermission] WHERE [RoleId] = @RoleId AND [PermissionId] = @PermissionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C19,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C20", "INSERT INTO [RolePermission]([RoleId], [PermissionId]) VALUES(@RoleId, @PermissionId)", GxErrorMask.GX_NOMASK,prmT000C20)
             ,new CursorDef("T000C21", "DELETE FROM [RolePermission]  WHERE [RoleId] = @RoleId AND [PermissionId] = @PermissionId", GxErrorMask.GX_NOMASK,prmT000C21)
             ,new CursorDef("T000C22", "SELECT [PermissionName] FROM [Permission] WHERE [PermissionId] = @PermissionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C22,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C23", "SELECT [RoleId], [PermissionId] FROM [RolePermission] WHERE [RoleId] = @RoleId ORDER BY [RoleId], [PermissionId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C23,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C24", "SELECT [RoleName] FROM [Role] WHERE ([RoleName] = @RoleName) AND (Not ( [RoleId] = @RoleId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C24,1, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 14 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 15 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 16 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 17 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 20 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 21 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 22 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
       }
    }

 }

}
