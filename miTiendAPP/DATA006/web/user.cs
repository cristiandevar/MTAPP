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
   public class user : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_15") == 0 )
         {
            A104RoleId = (int)(Math.Round(NumberUtil.Val( GetPar( "RoleId"), "."), 18, MidpointRounding.ToEven));
            n104RoleId = false;
            AssignAttri("", false, "A104RoleId", StringUtil.LTrimStr( (decimal)(A104RoleId), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_15( A104RoleId) ;
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
               AV11UserId = (int)(Math.Round(NumberUtil.Val( GetPar( "UserId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11UserId", StringUtil.LTrimStr( (decimal)(AV11UserId), 6, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vUSERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV11UserId), "ZZZZZ9"), context));
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
            Form.Meta.addItem("description", "User", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtUserEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("mtaKB", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public user( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public user( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_UserId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV11UserId = aP1_UserId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynRoleId = new GXCombobox();
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
         if ( dynRoleId.ItemCount > 0 )
         {
            A104RoleId = (int)(Math.Round(NumberUtil.Val( dynRoleId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A104RoleId), 6, 0))), "."), 18, MidpointRounding.ToEven));
            n104RoleId = false;
            AssignAttri("", false, "A104RoleId", StringUtil.LTrimStr( (decimal)(A104RoleId), 6, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynRoleId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A104RoleId), 6, 0));
            AssignProp("", false, dynRoleId_Internalname, "Values", dynRoleId.ToJavascriptSource(), true);
         }
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "User", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_User.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_User.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_User.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_User.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_User.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_User.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUserId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUserId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtUserId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A99UserId), 6, 0, ".", "")), StringUtil.LTrim( ((edtUserId_Enabled!=0) ? context.localUtil.Format( (decimal)(A99UserId), "ZZZZZ9") : context.localUtil.Format( (decimal)(A99UserId), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUserId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUserId_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_User.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUserEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUserEmail_Internalname, "User Email", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUserEmail_Internalname, A137UserEmail, StringUtil.RTrim( context.localUtil.Format( A137UserEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A137UserEmail, "", "", "", edtUserEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUserEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "left", true, "", "HLP_User.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUserName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUserName_Internalname, "Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUserName_Internalname, A100UserName, StringUtil.RTrim( context.localUtil.Format( A100UserName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUserName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUserName_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_User.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynRoleId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, dynRoleId_Internalname, "Role Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, dynRoleId, dynRoleId_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A104RoleId), 6, 0)), 1, dynRoleId_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynRoleId.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 0, "HLP_User.htm");
         dynRoleId.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A104RoleId), 6, 0));
         AssignProp("", false, dynRoleId_Internalname, "Values", (string)(dynRoleId.ToJavascriptSource()), true);
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
         GxWebStd.gx_label_element( context, edtUserCreatedDate_Internalname, "Created Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         context.WriteHtmlText( "<div id=\""+edtUserCreatedDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtUserCreatedDate_Internalname, context.localUtil.Format(A102UserCreatedDate, "99/99/99"), context.localUtil.Format( A102UserCreatedDate, "99/99/99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUserCreatedDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUserCreatedDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_User.htm");
         GxWebStd.gx_bitmap( context, edtUserCreatedDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtUserCreatedDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_User.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUserModifiedDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUserModifiedDate_Internalname, "Modified Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         context.WriteHtmlText( "<div id=\""+edtUserModifiedDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtUserModifiedDate_Internalname, context.localUtil.Format(A103UserModifiedDate, "99/99/99"), context.localUtil.Format( A103UserModifiedDate, "99/99/99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUserModifiedDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUserModifiedDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_User.htm");
         GxWebStd.gx_bitmap( context, edtUserModifiedDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtUserModifiedDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_User.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__actions--fixed", "Right", "Middle", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_User.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_User.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_User.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "Right", "Middle", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
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
         E11042 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z99UserId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z99UserId"), ".", ","), 18, MidpointRounding.ToEven));
               Z137UserEmail = cgiGet( "Z137UserEmail");
               n137UserEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A137UserEmail)) ? true : false);
               Z100UserName = cgiGet( "Z100UserName");
               Z101UserPassword = cgiGet( "Z101UserPassword");
               Z109UserHash = cgiGet( "Z109UserHash");
               Z102UserCreatedDate = context.localUtil.CToD( cgiGet( "Z102UserCreatedDate"), 0);
               Z103UserModifiedDate = context.localUtil.CToD( cgiGet( "Z103UserModifiedDate"), 0);
               Z111UserActive = StringUtil.StrToBool( cgiGet( "Z111UserActive"));
               n111UserActive = ((false==A111UserActive) ? true : false);
               Z104RoleId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z104RoleId"), ".", ","), 18, MidpointRounding.ToEven));
               n104RoleId = ((0==A104RoleId) ? true : false);
               A101UserPassword = cgiGet( "Z101UserPassword");
               A109UserHash = cgiGet( "Z109UserHash");
               A111UserActive = StringUtil.StrToBool( cgiGet( "Z111UserActive"));
               n111UserActive = false;
               n111UserActive = ((false==A111UserActive) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N104RoleId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N104RoleId"), ".", ","), 18, MidpointRounding.ToEven));
               n104RoleId = ((0==A104RoleId) ? true : false);
               AV11UserId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vUSERID"), ".", ","), 18, MidpointRounding.ToEven));
               AV12Insert_RoleId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_ROLEID"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_date = context.localUtil.CToD( cgiGet( "vTODAY"), 0);
               A101UserPassword = cgiGet( "USERPASSWORD");
               A109UserHash = cgiGet( "USERHASH");
               A111UserActive = StringUtil.StrToBool( cgiGet( "USERACTIVE"));
               n111UserActive = ((false==A111UserActive) ? true : false);
               A105RoleName = cgiGet( "ROLENAME");
               AV38Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A99UserId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtUserId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A99UserId", StringUtil.LTrimStr( (decimal)(A99UserId), 6, 0));
               A137UserEmail = cgiGet( edtUserEmail_Internalname);
               n137UserEmail = false;
               AssignAttri("", false, "A137UserEmail", A137UserEmail);
               n137UserEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A137UserEmail)) ? true : false);
               A100UserName = cgiGet( edtUserName_Internalname);
               AssignAttri("", false, "A100UserName", A100UserName);
               dynRoleId.CurrentValue = cgiGet( dynRoleId_Internalname);
               A104RoleId = (int)(Math.Round(NumberUtil.Val( cgiGet( dynRoleId_Internalname), "."), 18, MidpointRounding.ToEven));
               n104RoleId = false;
               AssignAttri("", false, "A104RoleId", StringUtil.LTrimStr( (decimal)(A104RoleId), 6, 0));
               n104RoleId = ((0==A104RoleId) ? true : false);
               A102UserCreatedDate = context.localUtil.CToD( cgiGet( edtUserCreatedDate_Internalname), 1);
               AssignAttri("", false, "A102UserCreatedDate", context.localUtil.Format(A102UserCreatedDate, "99/99/99"));
               A103UserModifiedDate = context.localUtil.CToD( cgiGet( edtUserModifiedDate_Internalname), 1);
               AssignAttri("", false, "A103UserModifiedDate", context.localUtil.Format(A103UserModifiedDate, "99/99/99"));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"User");
               A99UserId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtUserId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A99UserId", StringUtil.LTrimStr( (decimal)(A99UserId), 6, 0));
               forbiddenHiddens.Add("UserId", context.localUtil.Format( (decimal)(A99UserId), "ZZZZZ9"));
               A102UserCreatedDate = context.localUtil.CToD( cgiGet( edtUserCreatedDate_Internalname), 1);
               AssignAttri("", false, "A102UserCreatedDate", context.localUtil.Format(A102UserCreatedDate, "99/99/99"));
               forbiddenHiddens.Add("UserCreatedDate", context.localUtil.Format(A102UserCreatedDate, "99/99/99"));
               A103UserModifiedDate = context.localUtil.CToD( cgiGet( edtUserModifiedDate_Internalname), 1);
               AssignAttri("", false, "A103UserModifiedDate", context.localUtil.Format(A103UserModifiedDate, "99/99/99"));
               forbiddenHiddens.Add("UserModifiedDate", context.localUtil.Format(A103UserModifiedDate, "99/99/99"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("UserPassword", StringUtil.RTrim( context.localUtil.Format( A101UserPassword, "")));
               forbiddenHiddens.Add("UserHash", StringUtil.RTrim( context.localUtil.Format( A109UserHash, "")));
               forbiddenHiddens.Add("UserActive", StringUtil.BoolToStr( A111UserActive));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A99UserId != Z99UserId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("user:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A99UserId = (int)(Math.Round(NumberUtil.Val( GetPar( "UserId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A99UserId", StringUtil.LTrimStr( (decimal)(A99UserId), 6, 0));
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
                     sMode16 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode16;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound16 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_040( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "USERID");
                        AnyError = 1;
                        GX_FocusControl = edtUserId_Internalname;
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
                           E11042 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12042 ();
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
            E12042 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0416( ) ;
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
            DisableAttributes0416( ) ;
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

      protected void CONFIRM_040( )
      {
         BeforeValidate0416( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0416( ) ;
            }
            else
            {
               CheckExtendedTable0416( ) ;
               CloseExtendedTableCursors0416( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption040( )
      {
      }

      protected void E11042( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtSDTContextSession1 = new GeneXus.Programs.general.ui.SdtSDTContextSession();
         new checkauthentication(context ).execute( out  GXt_SdtSDTContextSession1) ;
         if ( (0==AV11UserId) )
         {
            AV11UserId = AV14Context.gxTpr_Userid;
            AssignAttri("", false, "AV11UserId", StringUtil.LTrimStr( (decimal)(AV11UserId), 6, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vUSERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV11UserId), "ZZZZZ9"), context));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && ! new haspermission(context).executeUdp(  "user view") )
         {
            if ( AV11UserId != AV14Context.gxTpr_Userid )
            {
               CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV38Pgmname))}, new string[] {"GxObject"}) );
               context.wjLocDisableFrm = 1;
            }
         }
         else if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! new haspermission(context).executeUdp(  "user insert") )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV38Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         else if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ! new haspermission(context).executeUdp(  "user update") )
         {
            if ( AV11UserId != AV14Context.gxTpr_Userid )
            {
               CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV38Pgmname))}, new string[] {"GxObject"}) );
               context.wjLocDisableFrm = 1;
            }
         }
         else if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! new haspermission(context).executeUdp(  "user delete") )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV38Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV38Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV38Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         AV12Insert_RoleId = 0;
         AssignAttri("", false, "AV12Insert_RoleId", StringUtil.LTrimStr( (decimal)(AV12Insert_RoleId), 6, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV38Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV39GXV1 = 1;
            AssignAttri("", false, "AV39GXV1", StringUtil.LTrimStr( (decimal)(AV39GXV1), 8, 0));
            while ( AV39GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((GeneXus.Programs.general.ui.SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV39GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "RoleId") == 0 )
               {
                  AV12Insert_RoleId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV12Insert_RoleId", StringUtil.LTrimStr( (decimal)(AV12Insert_RoleId), 6, 0));
               }
               AV39GXV1 = (int)(AV39GXV1+1);
               AssignAttri("", false, "AV39GXV1", StringUtil.LTrimStr( (decimal)(AV39GXV1), 8, 0));
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            AV28AuxUserName = A100UserName;
            AssignAttri("", false, "AV28AuxUserName", AV28AuxUserName);
            GxWebStd.gx_hidden_field( context, "gxhash_vAUXUSERNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV28AuxUserName, "")), context));
            AV29AuxUserEmail = A137UserEmail;
            AssignAttri("", false, "AV29AuxUserEmail", AV29AuxUserEmail);
            GxWebStd.gx_hidden_field( context, "gxhash_vAUXUSEREMAIL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV29AuxUserEmail, "")), context));
            AV32AuxRoleId = A104RoleId;
            AssignAttri("", false, "AV32AuxRoleId", StringUtil.LTrimStr( (decimal)(AV32AuxRoleId), 6, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vAUXROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV32AuxRoleId), "ZZZZZ9"), context));
         }
      }

      protected void E12042( )
      {
         /* After Trn Routine */
         returnInSub = false;
         AV21UserName = A100UserName;
         AssignAttri("", false, "AV21UserName", AV21UserName);
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV21UserName, "")), context));
         AV16UserEmail = A137UserEmail;
         AssignAttri("", false, "AV16UserEmail", AV16UserEmail);
         GxWebStd.gx_hidden_field( context, "gxhash_vUSEREMAIL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV16UserEmail, "")), context));
         AV27UserActive = A111UserActive;
         AssignAttri("", false, "AV27UserActive", AV27UserActive);
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERACTIVE", GetSecureSignedToken( "", AV27UserActive, context));
         AV34RoleId = A104RoleId;
         AssignAttri("", false, "AV34RoleId", StringUtil.LTrimStr( (decimal)(AV34RoleId), 6, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV34RoleId), "ZZZZZ9"), context));
         AV26RolName = A105RoleName;
         AssignAttri("", false, "AV26RolName", AV26RolName);
         GxWebStd.gx_hidden_field( context, "gxhash_vROLNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV26RolName, "")), context));
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_boolean2 = false;
            new user_resetpassword(context ).execute(  A99UserId, out  GXt_boolean2) ;
            /* Execute user subroutine: 'PREPARENOTIFICATIONINSERT' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            /* Execute user subroutine: 'WASCHANGED' */
            S122 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            if ( AV35WasChanged )
            {
               /* Execute user subroutine: 'PREPARENOTIFICATIONUPDATE' */
               S132 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
            }
         }
         /* Execute user subroutine: 'SENDNOTIFICATION' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwuser.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      protected void S142( )
      {
         /* 'SENDNOTIFICATION' Routine */
         returnInSub = false;
         AV19URLs.Clear();
         AV20Names.Clear();
         new sendemailprepareheader(context ).execute(  AV24EmailTitle,  AV25EmailSubtitle,  AV17EmailBody, out  AV18EmailBodyAux) ;
         AV17EmailBody = AV18EmailBodyAux;
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         new sendemail(context ).execute(  AV16UserEmail, ref  AV17EmailBody, ref  AV36EmailSubject, ref  AV19URLs, ref  AV20Names, ref  AV15AllOk) ;
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AssignAttri("", false, "AV36EmailSubject", AV36EmailSubject);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILSUBJECT", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV36EmailSubject, "")), context));
         AssignAttri("", false, "AV15AllOk", AV15AllOk);
         GxWebStd.gx_hidden_field( context, "gxhash_vALLOK", GetSecureSignedToken( "", AV15AllOk, context));
      }

      protected void S112( )
      {
         /* 'PREPARENOTIFICATIONINSERT' Routine */
         returnInSub = false;
         AV36EmailSubject = "User Generated";
         AssignAttri("", false, "AV36EmailSubject", AV36EmailSubject);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILSUBJECT", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV36EmailSubject, "")), context));
         AV24EmailTitle = "User Generated";
         AssignAttri("", false, "AV24EmailTitle", AV24EmailTitle);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILTITLE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV24EmailTitle, "")), context));
         AV25EmailSubtitle = "An User was Generated with the next information";
         AssignAttri("", false, "AV25EmailSubtitle", AV25EmailSubtitle);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILSUBTITLE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV25EmailSubtitle, "")), context));
         AV22USerCreatedDAte = DateTimeUtil.ServerDate( context, pr_default);
         AV17EmailBody = "";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody = "                <table class=\"table table-border table-striped\">";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += "                    <tr>";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += "                        <td style=\"text-align:left;\"><strong>Email</strong></td>";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += "                        <td>" + AV16UserEmail + "</td>";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += "                    </tr>";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += "                    <tr>";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += "                        <td style=\"text-align:left;\"><strong>User Name</strong></td>";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += "                        <td>" + AV21UserName + "</td>";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += "                    </tr>";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += "                    <tr>";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += "                        <td style=\"text-align:left;\"><strong>Created Date</strong></td>";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += "                        <td>";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += context.localUtil.DToC( AV22USerCreatedDAte, 1, "/");
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += "					</td>";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += "                    </tr>";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += "                    <tr>";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += "                        <td style=\"text-align:left;\"><strong>Rol</strong></td>";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += "                        <td>";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += AV26RolName;
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += "					</td>";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += "                    </tr>";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += "                    <tr>";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += "                        <td style=\"text-align:left;\"><strong>State</strong></td>";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += "                        <td>";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += (AV27UserActive ? "Enabled" : "Disabled");
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += "					</td>";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += "                    </tr>";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += "                </table>";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
      }

      protected void S132( )
      {
         /* 'PREPARENOTIFICATIONUPDATE' Routine */
         returnInSub = false;
         AV36EmailSubject = "User Modified";
         AssignAttri("", false, "AV36EmailSubject", AV36EmailSubject);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILSUBJECT", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV36EmailSubject, "")), context));
         AV24EmailTitle = "User Modified";
         AssignAttri("", false, "AV24EmailTitle", AV24EmailTitle);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILTITLE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV24EmailTitle, "")), context));
         AV25EmailSubtitle = "The information of the you user has been modified";
         AssignAttri("", false, "AV25EmailSubtitle", AV25EmailSubtitle);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILSUBTITLE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV25EmailSubtitle, "")), context));
         AV22USerCreatedDAte = DateTimeUtil.ServerDate( context, pr_default);
         AV17EmailBody = "                <table class=\"table table-border table-striped\">";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += "                    <tr>";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += "                        <td style=\"text-align:left;\"><strong>Email</strong></td>";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += "                        <td>" + AV16UserEmail + "</td>";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += "                    </tr>";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += "                    <tr>";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += "                        <td style=\"text-align:left;\"><strong>User Name</strong></td>";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += "                        <td>" + AV21UserName + "</td>";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += "                    </tr>";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += "                    <tr>";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += "                        <td style=\"text-align:left;\"><strong>Created Date</strong></td>";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += "                        <td>";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += context.localUtil.DToC( AV22USerCreatedDAte, 1, "/");
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += "					</td>";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += "                    </tr>";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += "                    <tr>";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += "                        <td style=\"text-align:left;\"><strong>Rol</strong></td>";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += "                        <td>";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += AV26RolName;
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += "					</td>";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += "                    </tr>";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += "                    <tr>";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += "                        <td style=\"text-align:left;\"><strong>State</strong></td>";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += "                        <td>";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += (AV27UserActive ? "Enabled" : "Disabled");
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += "					</td>";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += "                    </tr>";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         AV17EmailBody += "                </table>";
         AssignAttri("", false, "AV17EmailBody", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
      }

      protected void S122( )
      {
         /* 'WASCHANGED' Routine */
         returnInSub = false;
         AV35WasChanged = false;
         AssignAttri("", false, "AV35WasChanged", AV35WasChanged);
         GxWebStd.gx_hidden_field( context, "gxhash_vWASCHANGED", GetSecureSignedToken( "", AV35WasChanged, context));
         if ( AV32AuxRoleId != AV34RoleId )
         {
            AV35WasChanged = true;
            AssignAttri("", false, "AV35WasChanged", AV35WasChanged);
            GxWebStd.gx_hidden_field( context, "gxhash_vWASCHANGED", GetSecureSignedToken( "", AV35WasChanged, context));
         }
         if ( StringUtil.StrCmp(AV29AuxUserEmail, AV16UserEmail) != 0 )
         {
            AV35WasChanged = true;
            AssignAttri("", false, "AV35WasChanged", AV35WasChanged);
            GxWebStd.gx_hidden_field( context, "gxhash_vWASCHANGED", GetSecureSignedToken( "", AV35WasChanged, context));
         }
         if ( StringUtil.StrCmp(AV28AuxUserName, AV21UserName) != 0 )
         {
            AV35WasChanged = true;
            AssignAttri("", false, "AV35WasChanged", AV35WasChanged);
            GxWebStd.gx_hidden_field( context, "gxhash_vWASCHANGED", GetSecureSignedToken( "", AV35WasChanged, context));
         }
      }

      protected void ZM0416( short GX_JID )
      {
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z137UserEmail = T00043_A137UserEmail[0];
               Z100UserName = T00043_A100UserName[0];
               Z101UserPassword = T00043_A101UserPassword[0];
               Z109UserHash = T00043_A109UserHash[0];
               Z102UserCreatedDate = T00043_A102UserCreatedDate[0];
               Z103UserModifiedDate = T00043_A103UserModifiedDate[0];
               Z111UserActive = T00043_A111UserActive[0];
               Z104RoleId = T00043_A104RoleId[0];
            }
            else
            {
               Z137UserEmail = A137UserEmail;
               Z100UserName = A100UserName;
               Z101UserPassword = A101UserPassword;
               Z109UserHash = A109UserHash;
               Z102UserCreatedDate = A102UserCreatedDate;
               Z103UserModifiedDate = A103UserModifiedDate;
               Z111UserActive = A111UserActive;
               Z104RoleId = A104RoleId;
            }
         }
         if ( GX_JID == -13 )
         {
            Z99UserId = A99UserId;
            Z137UserEmail = A137UserEmail;
            Z100UserName = A100UserName;
            Z101UserPassword = A101UserPassword;
            Z109UserHash = A109UserHash;
            Z102UserCreatedDate = A102UserCreatedDate;
            Z103UserModifiedDate = A103UserModifiedDate;
            Z111UserActive = A111UserActive;
            Z104RoleId = A104RoleId;
            Z105RoleName = A105RoleName;
         }
      }

      protected void standaloneNotModal( )
      {
         edtUserId_Enabled = 0;
         AssignProp("", false, edtUserId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUserId_Enabled), 5, 0), true);
         edtUserCreatedDate_Enabled = 0;
         AssignProp("", false, edtUserCreatedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUserCreatedDate_Enabled), 5, 0), true);
         edtUserModifiedDate_Enabled = 0;
         AssignProp("", false, edtUserModifiedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUserModifiedDate_Enabled), 5, 0), true);
         Gx_date = DateTimeUtil.Today( context);
         AssignAttri("", false, "Gx_date", context.localUtil.Format(Gx_date, "99/99/99"));
         edtUserId_Enabled = 0;
         AssignProp("", false, edtUserId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUserId_Enabled), 5, 0), true);
         edtUserCreatedDate_Enabled = 0;
         AssignProp("", false, edtUserCreatedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUserCreatedDate_Enabled), 5, 0), true);
         edtUserModifiedDate_Enabled = 0;
         AssignProp("", false, edtUserModifiedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUserModifiedDate_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV11UserId) )
         {
            A99UserId = AV11UserId;
            AssignAttri("", false, "A99UserId", StringUtil.LTrimStr( (decimal)(A99UserId), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_RoleId) )
         {
            dynRoleId.Enabled = 0;
            AssignProp("", false, dynRoleId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynRoleId.Enabled), 5, 0), true);
         }
         else
         {
            dynRoleId.Enabled = 1;
            AssignProp("", false, dynRoleId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynRoleId.Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_RoleId) )
         {
            A104RoleId = AV12Insert_RoleId;
            n104RoleId = false;
            AssignAttri("", false, "A104RoleId", StringUtil.LTrimStr( (decimal)(A104RoleId), 6, 0));
         }
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
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            A102UserCreatedDate = Gx_date;
            AssignAttri("", false, "A102UserCreatedDate", context.localUtil.Format(A102UserCreatedDate, "99/99/99"));
         }
         else
         {
            if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
            {
               A102UserCreatedDate = Gx_date;
               AssignAttri("", false, "A102UserCreatedDate", context.localUtil.Format(A102UserCreatedDate, "99/99/99"));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV38Pgmname = "User";
            AssignAttri("", false, "AV38Pgmname", AV38Pgmname);
            /* Using cursor T00044 */
            pr_default.execute(2, new Object[] {n104RoleId, A104RoleId});
            A105RoleName = T00044_A105RoleName[0];
            pr_default.close(2);
         }
      }

      protected void Load0416( )
      {
         /* Using cursor T00045 */
         pr_default.execute(3, new Object[] {A99UserId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound16 = 1;
            A137UserEmail = T00045_A137UserEmail[0];
            n137UserEmail = T00045_n137UserEmail[0];
            AssignAttri("", false, "A137UserEmail", A137UserEmail);
            A100UserName = T00045_A100UserName[0];
            AssignAttri("", false, "A100UserName", A100UserName);
            A101UserPassword = T00045_A101UserPassword[0];
            A109UserHash = T00045_A109UserHash[0];
            A102UserCreatedDate = T00045_A102UserCreatedDate[0];
            AssignAttri("", false, "A102UserCreatedDate", context.localUtil.Format(A102UserCreatedDate, "99/99/99"));
            A103UserModifiedDate = T00045_A103UserModifiedDate[0];
            AssignAttri("", false, "A103UserModifiedDate", context.localUtil.Format(A103UserModifiedDate, "99/99/99"));
            A105RoleName = T00045_A105RoleName[0];
            A111UserActive = T00045_A111UserActive[0];
            n111UserActive = T00045_n111UserActive[0];
            A104RoleId = T00045_A104RoleId[0];
            n104RoleId = T00045_n104RoleId[0];
            AssignAttri("", false, "A104RoleId", StringUtil.LTrimStr( (decimal)(A104RoleId), 6, 0));
            ZM0416( -13) ;
         }
         pr_default.close(3);
         OnLoadActions0416( ) ;
      }

      protected void OnLoadActions0416( )
      {
         AV38Pgmname = "User";
         AssignAttri("", false, "AV38Pgmname", AV38Pgmname);
      }

      protected void CheckExtendedTable0416( )
      {
         nIsDirty_16 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV38Pgmname = "User";
         AssignAttri("", false, "AV38Pgmname", AV38Pgmname);
         /* Using cursor T00046 */
         pr_default.execute(4, new Object[] {A100UserName, A99UserId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"User Name"}), 1, "USERNAME");
            AnyError = 1;
            GX_FocusControl = edtUserName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(4);
         if ( ! ( GxRegex.IsMatch(A137UserEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A137UserEmail)) ) )
         {
            GX_msglist.addItem("Field User Email does not match the specified pattern", "OutOfRange", 1, "USEREMAIL");
            AnyError = 1;
            GX_FocusControl = edtUserEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A137UserEmail)) )
         {
            GX_msglist.addItem("Email is required", 1, "USEREMAIL");
            AnyError = 1;
            GX_FocusControl = edtUserEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00044 */
         pr_default.execute(2, new Object[] {n104RoleId, A104RoleId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A104RoleId) ) )
            {
               GX_msglist.addItem("No matching 'Role'.", "ForeignKeyNotFound", 1, "ROLEID");
               AnyError = 1;
               GX_FocusControl = dynRoleId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A105RoleName = T00044_A105RoleName[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0416( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_15( int A104RoleId )
      {
         /* Using cursor T00047 */
         pr_default.execute(5, new Object[] {n104RoleId, A104RoleId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A104RoleId) ) )
            {
               GX_msglist.addItem("No matching 'Role'.", "ForeignKeyNotFound", 1, "ROLEID");
               AnyError = 1;
               GX_FocusControl = dynRoleId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A105RoleName = T00047_A105RoleName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A105RoleName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void GetKey0416( )
      {
         /* Using cursor T00048 */
         pr_default.execute(6, new Object[] {A99UserId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound16 = 1;
         }
         else
         {
            RcdFound16 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00043 */
         pr_default.execute(1, new Object[] {A99UserId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0416( 13) ;
            RcdFound16 = 1;
            A99UserId = T00043_A99UserId[0];
            AssignAttri("", false, "A99UserId", StringUtil.LTrimStr( (decimal)(A99UserId), 6, 0));
            A137UserEmail = T00043_A137UserEmail[0];
            n137UserEmail = T00043_n137UserEmail[0];
            AssignAttri("", false, "A137UserEmail", A137UserEmail);
            A100UserName = T00043_A100UserName[0];
            AssignAttri("", false, "A100UserName", A100UserName);
            A101UserPassword = T00043_A101UserPassword[0];
            A109UserHash = T00043_A109UserHash[0];
            A102UserCreatedDate = T00043_A102UserCreatedDate[0];
            AssignAttri("", false, "A102UserCreatedDate", context.localUtil.Format(A102UserCreatedDate, "99/99/99"));
            A103UserModifiedDate = T00043_A103UserModifiedDate[0];
            AssignAttri("", false, "A103UserModifiedDate", context.localUtil.Format(A103UserModifiedDate, "99/99/99"));
            A111UserActive = T00043_A111UserActive[0];
            n111UserActive = T00043_n111UserActive[0];
            A104RoleId = T00043_A104RoleId[0];
            n104RoleId = T00043_n104RoleId[0];
            AssignAttri("", false, "A104RoleId", StringUtil.LTrimStr( (decimal)(A104RoleId), 6, 0));
            Z99UserId = A99UserId;
            sMode16 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0416( ) ;
            if ( AnyError == 1 )
            {
               RcdFound16 = 0;
               InitializeNonKey0416( ) ;
            }
            Gx_mode = sMode16;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound16 = 0;
            InitializeNonKey0416( ) ;
            sMode16 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode16;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0416( ) ;
         if ( RcdFound16 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound16 = 0;
         /* Using cursor T00049 */
         pr_default.execute(7, new Object[] {A99UserId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00049_A99UserId[0] < A99UserId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00049_A99UserId[0] > A99UserId ) ) )
            {
               A99UserId = T00049_A99UserId[0];
               AssignAttri("", false, "A99UserId", StringUtil.LTrimStr( (decimal)(A99UserId), 6, 0));
               RcdFound16 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void move_previous( )
      {
         RcdFound16 = 0;
         /* Using cursor T000410 */
         pr_default.execute(8, new Object[] {A99UserId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000410_A99UserId[0] > A99UserId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000410_A99UserId[0] < A99UserId ) ) )
            {
               A99UserId = T000410_A99UserId[0];
               AssignAttri("", false, "A99UserId", StringUtil.LTrimStr( (decimal)(A99UserId), 6, 0));
               RcdFound16 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0416( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtUserEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0416( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound16 == 1 )
            {
               if ( A99UserId != Z99UserId )
               {
                  A99UserId = Z99UserId;
                  AssignAttri("", false, "A99UserId", StringUtil.LTrimStr( (decimal)(A99UserId), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "USERID");
                  AnyError = 1;
                  GX_FocusControl = edtUserId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtUserEmail_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0416( ) ;
                  GX_FocusControl = edtUserEmail_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A99UserId != Z99UserId )
               {
                  /* Insert record */
                  GX_FocusControl = edtUserEmail_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0416( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "USERID");
                     AnyError = 1;
                     GX_FocusControl = edtUserId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtUserEmail_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0416( ) ;
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
         if ( A99UserId != Z99UserId )
         {
            A99UserId = Z99UserId;
            AssignAttri("", false, "A99UserId", StringUtil.LTrimStr( (decimal)(A99UserId), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "USERID");
            AnyError = 1;
            GX_FocusControl = edtUserId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtUserEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0416( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00042 */
            pr_default.execute(0, new Object[] {A99UserId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"User"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z137UserEmail, T00042_A137UserEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z100UserName, T00042_A100UserName[0]) != 0 ) || ( StringUtil.StrCmp(Z101UserPassword, T00042_A101UserPassword[0]) != 0 ) || ( StringUtil.StrCmp(Z109UserHash, T00042_A109UserHash[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z102UserCreatedDate ) != DateTimeUtil.ResetTime ( T00042_A102UserCreatedDate[0] ) ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( DateTimeUtil.ResetTime ( Z103UserModifiedDate ) != DateTimeUtil.ResetTime ( T00042_A103UserModifiedDate[0] ) ) || ( Z111UserActive != T00042_A111UserActive[0] ) || ( Z104RoleId != T00042_A104RoleId[0] ) )
            {
               if ( StringUtil.StrCmp(Z137UserEmail, T00042_A137UserEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("user:[seudo value changed for attri]"+"UserEmail");
                  GXUtil.WriteLogRaw("Old: ",Z137UserEmail);
                  GXUtil.WriteLogRaw("Current: ",T00042_A137UserEmail[0]);
               }
               if ( StringUtil.StrCmp(Z100UserName, T00042_A100UserName[0]) != 0 )
               {
                  GXUtil.WriteLog("user:[seudo value changed for attri]"+"UserName");
                  GXUtil.WriteLogRaw("Old: ",Z100UserName);
                  GXUtil.WriteLogRaw("Current: ",T00042_A100UserName[0]);
               }
               if ( StringUtil.StrCmp(Z101UserPassword, T00042_A101UserPassword[0]) != 0 )
               {
                  GXUtil.WriteLog("user:[seudo value changed for attri]"+"UserPassword");
                  GXUtil.WriteLogRaw("Old: ",Z101UserPassword);
                  GXUtil.WriteLogRaw("Current: ",T00042_A101UserPassword[0]);
               }
               if ( StringUtil.StrCmp(Z109UserHash, T00042_A109UserHash[0]) != 0 )
               {
                  GXUtil.WriteLog("user:[seudo value changed for attri]"+"UserHash");
                  GXUtil.WriteLogRaw("Old: ",Z109UserHash);
                  GXUtil.WriteLogRaw("Current: ",T00042_A109UserHash[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z102UserCreatedDate ) != DateTimeUtil.ResetTime ( T00042_A102UserCreatedDate[0] ) )
               {
                  GXUtil.WriteLog("user:[seudo value changed for attri]"+"UserCreatedDate");
                  GXUtil.WriteLogRaw("Old: ",Z102UserCreatedDate);
                  GXUtil.WriteLogRaw("Current: ",T00042_A102UserCreatedDate[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z103UserModifiedDate ) != DateTimeUtil.ResetTime ( T00042_A103UserModifiedDate[0] ) )
               {
                  GXUtil.WriteLog("user:[seudo value changed for attri]"+"UserModifiedDate");
                  GXUtil.WriteLogRaw("Old: ",Z103UserModifiedDate);
                  GXUtil.WriteLogRaw("Current: ",T00042_A103UserModifiedDate[0]);
               }
               if ( Z111UserActive != T00042_A111UserActive[0] )
               {
                  GXUtil.WriteLog("user:[seudo value changed for attri]"+"UserActive");
                  GXUtil.WriteLogRaw("Old: ",Z111UserActive);
                  GXUtil.WriteLogRaw("Current: ",T00042_A111UserActive[0]);
               }
               if ( Z104RoleId != T00042_A104RoleId[0] )
               {
                  GXUtil.WriteLog("user:[seudo value changed for attri]"+"RoleId");
                  GXUtil.WriteLogRaw("Old: ",Z104RoleId);
                  GXUtil.WriteLogRaw("Current: ",T00042_A104RoleId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"User"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0416( )
      {
         BeforeValidate0416( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0416( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0416( 0) ;
            CheckOptimisticConcurrency0416( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0416( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0416( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000411 */
                     pr_default.execute(9, new Object[] {n137UserEmail, A137UserEmail, A100UserName, A101UserPassword, A109UserHash, A102UserCreatedDate, A103UserModifiedDate, n111UserActive, A111UserActive, n104RoleId, A104RoleId});
                     A99UserId = T000411_A99UserId[0];
                     AssignAttri("", false, "A99UserId", StringUtil.LTrimStr( (decimal)(A99UserId), 6, 0));
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("User");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption040( ) ;
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
               Load0416( ) ;
            }
            EndLevel0416( ) ;
         }
         CloseExtendedTableCursors0416( ) ;
      }

      protected void Update0416( )
      {
         BeforeValidate0416( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0416( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0416( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0416( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0416( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000412 */
                     pr_default.execute(10, new Object[] {n137UserEmail, A137UserEmail, A100UserName, A101UserPassword, A109UserHash, A102UserCreatedDate, A103UserModifiedDate, n111UserActive, A111UserActive, n104RoleId, A104RoleId, A99UserId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("User");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"User"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0416( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
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
            EndLevel0416( ) ;
         }
         CloseExtendedTableCursors0416( ) ;
      }

      protected void DeferredUpdate0416( )
      {
      }

      protected void delete( )
      {
         BeforeValidate0416( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0416( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0416( ) ;
            AfterConfirm0416( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0416( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000413 */
                  pr_default.execute(11, new Object[] {A99UserId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("User");
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
         sMode16 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0416( ) ;
         Gx_mode = sMode16;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0416( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV38Pgmname = "User";
            AssignAttri("", false, "AV38Pgmname", AV38Pgmname);
            /* Using cursor T000414 */
            pr_default.execute(12, new Object[] {n104RoleId, A104RoleId});
            A105RoleName = T000414_A105RoleName[0];
            pr_default.close(12);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000415 */
            pr_default.execute(13, new Object[] {A99UserId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Invoice"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
         }
      }

      protected void EndLevel0416( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0416( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(12);
            context.CommitDataStores("user",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues040( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(12);
            context.RollbackDataStores("user",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0416( )
      {
         /* Scan By routine */
         /* Using cursor T000416 */
         pr_default.execute(14);
         RcdFound16 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound16 = 1;
            A99UserId = T000416_A99UserId[0];
            AssignAttri("", false, "A99UserId", StringUtil.LTrimStr( (decimal)(A99UserId), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0416( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound16 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound16 = 1;
            A99UserId = T000416_A99UserId[0];
            AssignAttri("", false, "A99UserId", StringUtil.LTrimStr( (decimal)(A99UserId), 6, 0));
         }
      }

      protected void ScanEnd0416( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm0416( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0416( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0416( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0416( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0416( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0416( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0416( )
      {
         edtUserId_Enabled = 0;
         AssignProp("", false, edtUserId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUserId_Enabled), 5, 0), true);
         edtUserEmail_Enabled = 0;
         AssignProp("", false, edtUserEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUserEmail_Enabled), 5, 0), true);
         edtUserName_Enabled = 0;
         AssignProp("", false, edtUserName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUserName_Enabled), 5, 0), true);
         dynRoleId.Enabled = 0;
         AssignProp("", false, dynRoleId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynRoleId.Enabled), 5, 0), true);
         edtUserCreatedDate_Enabled = 0;
         AssignProp("", false, edtUserCreatedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUserCreatedDate_Enabled), 5, 0), true);
         edtUserModifiedDate_Enabled = 0;
         AssignProp("", false, edtUserModifiedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUserModifiedDate_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0416( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues040( )
      {
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1853160), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1853160), false, true);
         context.AddJavascriptSource("calendar-en.js", "?"+context.GetBuildNumber( 1853160), false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("user.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV11UserId,6,0))}, new string[] {"Gx_mode","UserId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"User");
         forbiddenHiddens.Add("UserId", context.localUtil.Format( (decimal)(A99UserId), "ZZZZZ9"));
         forbiddenHiddens.Add("UserCreatedDate", context.localUtil.Format(A102UserCreatedDate, "99/99/99"));
         forbiddenHiddens.Add("UserModifiedDate", context.localUtil.Format(A103UserModifiedDate, "99/99/99"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("UserPassword", StringUtil.RTrim( context.localUtil.Format( A101UserPassword, "")));
         forbiddenHiddens.Add("UserHash", StringUtil.RTrim( context.localUtil.Format( A109UserHash, "")));
         forbiddenHiddens.Add("UserActive", StringUtil.BoolToStr( A111UserActive));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("user:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z99UserId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z99UserId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z137UserEmail", Z137UserEmail);
         GxWebStd.gx_hidden_field( context, "Z100UserName", Z100UserName);
         GxWebStd.gx_hidden_field( context, "Z101UserPassword", Z101UserPassword);
         GxWebStd.gx_hidden_field( context, "Z109UserHash", Z109UserHash);
         GxWebStd.gx_hidden_field( context, "Z102UserCreatedDate", context.localUtil.DToC( Z102UserCreatedDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z103UserModifiedDate", context.localUtil.DToC( Z103UserModifiedDate, 0, "/"));
         GxWebStd.gx_boolean_hidden_field( context, "Z111UserActive", Z111UserActive);
         GxWebStd.gx_hidden_field( context, "Z104RoleId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z104RoleId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N104RoleId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A104RoleId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vWASCHANGED", AV35WasChanged);
         GxWebStd.gx_hidden_field( context, "gxhash_vWASCHANGED", GetSecureSignedToken( "", AV35WasChanged, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV9TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV9TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vUSEREMAIL", AV16UserEmail);
         GxWebStd.gx_hidden_field( context, "gxhash_vUSEREMAIL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV16UserEmail, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSERNAME", AV21UserName);
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV21UserName, "")), context));
         GxWebStd.gx_hidden_field( context, "vROLNAME", AV26RolName);
         GxWebStd.gx_hidden_field( context, "gxhash_vROLNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV26RolName, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vUSERACTIVE", AV27UserActive);
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERACTIVE", GetSecureSignedToken( "", AV27UserActive, context));
         GxWebStd.gx_hidden_field( context, "vAUXROLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32AuxRoleId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vAUXROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV32AuxRoleId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vROLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34RoleId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV34RoleId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vAUXUSEREMAIL", AV29AuxUserEmail);
         GxWebStd.gx_hidden_field( context, "gxhash_vAUXUSEREMAIL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV29AuxUserEmail, "")), context));
         GxWebStd.gx_hidden_field( context, "vAUXUSERNAME", AV28AuxUserName);
         GxWebStd.gx_hidden_field( context, "gxhash_vAUXUSERNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV28AuxUserName, "")), context));
         GxWebStd.gx_hidden_field( context, "vEMAILTITLE", AV24EmailTitle);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILTITLE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV24EmailTitle, "")), context));
         GxWebStd.gx_hidden_field( context, "vEMAILSUBTITLE", AV25EmailSubtitle);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILSUBTITLE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV25EmailSubtitle, "")), context));
         GxWebStd.gx_hidden_field( context, "vEMAILBODY", AV17EmailBody);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILBODY", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV17EmailBody, "")), context));
         GxWebStd.gx_hidden_field( context, "vEMAILSUBJECT", AV36EmailSubject);
         GxWebStd.gx_hidden_field( context, "gxhash_vEMAILSUBJECT", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV36EmailSubject, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vALLOK", AV15AllOk);
         GxWebStd.gx_hidden_field( context, "gxhash_vALLOK", GetSecureSignedToken( "", AV15AllOk, context));
         GxWebStd.gx_hidden_field( context, "vUSERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11UserId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV11UserId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_ROLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_RoleId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "USERPASSWORD", A101UserPassword);
         GxWebStd.gx_hidden_field( context, "USERHASH", A109UserHash);
         GxWebStd.gx_boolean_hidden_field( context, "USERACTIVE", A111UserActive);
         GxWebStd.gx_hidden_field( context, "gxhash_USERACTIVE", GetSecureSignedToken( "", A111UserActive, context));
         GxWebStd.gx_hidden_field( context, "ROLENAME", A105RoleName);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV38Pgmname));
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
         return formatLink("user.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV11UserId,6,0))}, new string[] {"Gx_mode","UserId"})  ;
      }

      public override string GetPgmname( )
      {
         return "User" ;
      }

      public override string GetPgmdesc( )
      {
         return "User" ;
      }

      protected void InitializeNonKey0416( )
      {
         A104RoleId = 0;
         n104RoleId = false;
         AssignAttri("", false, "A104RoleId", StringUtil.LTrimStr( (decimal)(A104RoleId), 6, 0));
         n104RoleId = ((0==A104RoleId) ? true : false);
         A137UserEmail = "";
         n137UserEmail = false;
         AssignAttri("", false, "A137UserEmail", A137UserEmail);
         n137UserEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A137UserEmail)) ? true : false);
         A100UserName = "";
         AssignAttri("", false, "A100UserName", A100UserName);
         A101UserPassword = "";
         AssignAttri("", false, "A101UserPassword", A101UserPassword);
         A109UserHash = "";
         AssignAttri("", false, "A109UserHash", A109UserHash);
         A102UserCreatedDate = DateTime.MinValue;
         AssignAttri("", false, "A102UserCreatedDate", context.localUtil.Format(A102UserCreatedDate, "99/99/99"));
         A103UserModifiedDate = DateTime.MinValue;
         AssignAttri("", false, "A103UserModifiedDate", context.localUtil.Format(A103UserModifiedDate, "99/99/99"));
         A105RoleName = "";
         AssignAttri("", false, "A105RoleName", A105RoleName);
         A111UserActive = false;
         n111UserActive = false;
         AssignAttri("", false, "A111UserActive", A111UserActive);
         GxWebStd.gx_hidden_field( context, "gxhash_USERACTIVE", GetSecureSignedToken( "", A111UserActive, context));
         Z137UserEmail = "";
         Z100UserName = "";
         Z101UserPassword = "";
         Z109UserHash = "";
         Z102UserCreatedDate = DateTime.MinValue;
         Z103UserModifiedDate = DateTime.MinValue;
         Z111UserActive = false;
         Z104RoleId = 0;
      }

      protected void InitAll0416( )
      {
         A99UserId = 0;
         AssignAttri("", false, "A99UserId", StringUtil.LTrimStr( (decimal)(A99UserId), 6, 0));
         InitializeNonKey0416( ) ;
      }

      protected void StandaloneModalInsert( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20241271213429", true, true);
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
         context.AddJavascriptSource("user.js", "?20241271213429", false, true);
         /* End function include_jscripts */
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
         edtUserId_Internalname = "USERID";
         edtUserEmail_Internalname = "USEREMAIL";
         edtUserName_Internalname = "USERNAME";
         dynRoleId_Internalname = "ROLEID";
         edtUserCreatedDate_Internalname = "USERCREATEDDATE";
         edtUserModifiedDate_Internalname = "USERMODIFIEDDATE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
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
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "User";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtUserModifiedDate_Jsonclick = "";
         edtUserModifiedDate_Enabled = 0;
         edtUserCreatedDate_Jsonclick = "";
         edtUserCreatedDate_Enabled = 0;
         dynRoleId_Jsonclick = "";
         dynRoleId.Enabled = 1;
         edtUserName_Jsonclick = "";
         edtUserName_Enabled = 1;
         edtUserEmail_Jsonclick = "";
         edtUserEmail_Enabled = 1;
         edtUserId_Jsonclick = "";
         edtUserId_Enabled = 0;
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

      protected void GXDLAROLEID041( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLAROLEID_data041( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXAROLEID_html041( )
      {
         int gxdynajaxvalue;
         GXDLAROLEID_data041( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynRoleId.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(Math.Round(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."), 18, MidpointRounding.ToEven));
            dynRoleId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 6, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLAROLEID_data041( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor T000417 */
         pr_default.execute(15);
         while ( (pr_default.getStatus(15) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(T000417_A104RoleId[0]), 6, 0, ".", "")));
            gxdynajaxctrldescr.Add(T000417_A105RoleName[0]);
            pr_default.readNext(15);
         }
         pr_default.close(15);
      }

      protected void init_web_controls( )
      {
         dynRoleId.Name = "ROLEID";
         dynRoleId.WebTags = "";
         dynRoleId.removeAllItems();
         /* Using cursor T000418 */
         pr_default.execute(16);
         while ( (pr_default.getStatus(16) != 101) )
         {
            dynRoleId.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(T000418_A104RoleId[0]), 6, 0)), T000418_A105RoleName[0], 0);
            pr_default.readNext(16);
         }
         pr_default.close(16);
         if ( dynRoleId.ItemCount > 0 )
         {
            A104RoleId = (int)(Math.Round(NumberUtil.Val( dynRoleId.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A104RoleId), 6, 0))), "."), 18, MidpointRounding.ToEven));
            n104RoleId = false;
            AssignAttri("", false, "A104RoleId", StringUtil.LTrimStr( (decimal)(A104RoleId), 6, 0));
         }
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

      public void Valid_Username( )
      {
         n104RoleId = false;
         A104RoleId = (int)(Math.Round(NumberUtil.Val( dynRoleId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n104RoleId = false;
         /* Using cursor T000419 */
         pr_default.execute(17, new Object[] {A100UserName, A99UserId});
         if ( (pr_default.getStatus(17) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"User Name"}), 1, "USERNAME");
            AnyError = 1;
            GX_FocusControl = edtUserName_Internalname;
         }
         pr_default.close(17);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Roleid( )
      {
         n104RoleId = false;
         A104RoleId = (int)(Math.Round(NumberUtil.Val( dynRoleId.CurrentValue, "."), 18, MidpointRounding.ToEven));
         n104RoleId = false;
         /* Using cursor T000414 */
         pr_default.execute(12, new Object[] {n104RoleId, A104RoleId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            if ( ! ( (0==A104RoleId) ) )
            {
               GX_msglist.addItem("No matching 'Role'.", "ForeignKeyNotFound", 1, "ROLEID");
               AnyError = 1;
               GX_FocusControl = dynRoleId_Internalname;
            }
         }
         A105RoleName = T000414_A105RoleName[0];
         pr_default.close(12);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A105RoleName", A105RoleName);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11UserId',fld:'vUSERID',pic:'ZZZZZ9',hsh:true},{av:'dynRoleId'},{av:'A104RoleId',fld:'ROLEID',pic:'ZZZZZ9'}]");
         setEventMetadata("ENTER",",oparms:[{av:'dynRoleId'},{av:'A104RoleId',fld:'ROLEID',pic:'ZZZZZ9'}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A111UserActive',fld:'USERACTIVE',pic:'',hsh:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV35WasChanged',fld:'vWASCHANGED',pic:'',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV16UserEmail',fld:'vUSEREMAIL',pic:'',hsh:true},{av:'AV21UserName',fld:'vUSERNAME',pic:'',hsh:true},{av:'AV26RolName',fld:'vROLNAME',pic:'',hsh:true},{av:'AV27UserActive',fld:'vUSERACTIVE',pic:'',hsh:true},{av:'AV32AuxRoleId',fld:'vAUXROLEID',pic:'ZZZZZ9',hsh:true},{av:'AV34RoleId',fld:'vROLEID',pic:'ZZZZZ9',hsh:true},{av:'AV29AuxUserEmail',fld:'vAUXUSEREMAIL',pic:'',hsh:true},{av:'AV28AuxUserName',fld:'vAUXUSERNAME',pic:'',hsh:true},{av:'AV24EmailTitle',fld:'vEMAILTITLE',pic:'',hsh:true},{av:'AV25EmailSubtitle',fld:'vEMAILSUBTITLE',pic:'',hsh:true},{av:'AV17EmailBody',fld:'vEMAILBODY',pic:'',hsh:true},{av:'AV36EmailSubject',fld:'vEMAILSUBJECT',pic:'',hsh:true},{av:'AV15AllOk',fld:'vALLOK',pic:'',hsh:true},{av:'AV11UserId',fld:'vUSERID',pic:'ZZZZZ9',hsh:true},{av:'A99UserId',fld:'USERID',pic:'ZZZZZ9'},{av:'A102UserCreatedDate',fld:'USERCREATEDDATE',pic:''},{av:'A103UserModifiedDate',fld:'USERMODIFIEDDATE',pic:''},{av:'A101UserPassword',fld:'USERPASSWORD',pic:''},{av:'A109UserHash',fld:'USERHASH',pic:''},{av:'dynRoleId'},{av:'A104RoleId',fld:'ROLEID',pic:'ZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'dynRoleId'},{av:'A104RoleId',fld:'ROLEID',pic:'ZZZZZ9'}]}");
         setEventMetadata("AFTER TRN","{handler:'E12042',iparms:[{av:'A100UserName',fld:'USERNAME',pic:''},{av:'A137UserEmail',fld:'USEREMAIL',pic:''},{av:'A111UserActive',fld:'USERACTIVE',pic:'',hsh:true},{av:'A105RoleName',fld:'ROLENAME',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'A99UserId',fld:'USERID',pic:'ZZZZZ9'},{av:'AV35WasChanged',fld:'vWASCHANGED',pic:'',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV16UserEmail',fld:'vUSEREMAIL',pic:'',hsh:true},{av:'AV21UserName',fld:'vUSERNAME',pic:'',hsh:true},{av:'AV26RolName',fld:'vROLNAME',pic:'',hsh:true},{av:'AV27UserActive',fld:'vUSERACTIVE',pic:'',hsh:true},{av:'AV32AuxRoleId',fld:'vAUXROLEID',pic:'ZZZZZ9',hsh:true},{av:'AV34RoleId',fld:'vROLEID',pic:'ZZZZZ9',hsh:true},{av:'AV29AuxUserEmail',fld:'vAUXUSEREMAIL',pic:'',hsh:true},{av:'AV28AuxUserName',fld:'vAUXUSERNAME',pic:'',hsh:true},{av:'AV24EmailTitle',fld:'vEMAILTITLE',pic:'',hsh:true},{av:'AV25EmailSubtitle',fld:'vEMAILSUBTITLE',pic:'',hsh:true},{av:'AV17EmailBody',fld:'vEMAILBODY',pic:'',hsh:true},{av:'AV36EmailSubject',fld:'vEMAILSUBJECT',pic:'',hsh:true},{av:'AV15AllOk',fld:'vALLOK',pic:'',hsh:true},{av:'dynRoleId'},{av:'A104RoleId',fld:'ROLEID',pic:'ZZZZZ9'}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'AV21UserName',fld:'vUSERNAME',pic:'',hsh:true},{av:'AV16UserEmail',fld:'vUSEREMAIL',pic:'',hsh:true},{av:'AV27UserActive',fld:'vUSERACTIVE',pic:'',hsh:true},{av:'AV34RoleId',fld:'vROLEID',pic:'ZZZZZ9',hsh:true},{av:'AV26RolName',fld:'vROLNAME',pic:'',hsh:true},{av:'AV36EmailSubject',fld:'vEMAILSUBJECT',pic:'',hsh:true},{av:'AV24EmailTitle',fld:'vEMAILTITLE',pic:'',hsh:true},{av:'AV25EmailSubtitle',fld:'vEMAILSUBTITLE',pic:'',hsh:true},{av:'AV17EmailBody',fld:'vEMAILBODY',pic:'',hsh:true},{av:'AV35WasChanged',fld:'vWASCHANGED',pic:'',hsh:true},{av:'AV15AllOk',fld:'vALLOK',pic:'',hsh:true},{av:'dynRoleId'},{av:'A104RoleId',fld:'ROLEID',pic:'ZZZZZ9'}]}");
         setEventMetadata("VALID_USERID","{handler:'Valid_Userid',iparms:[{av:'dynRoleId'},{av:'A104RoleId',fld:'ROLEID',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_USERID",",oparms:[{av:'dynRoleId'},{av:'A104RoleId',fld:'ROLEID',pic:'ZZZZZ9'}]}");
         setEventMetadata("VALID_USEREMAIL","{handler:'Valid_Useremail',iparms:[{av:'dynRoleId'},{av:'A104RoleId',fld:'ROLEID',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_USEREMAIL",",oparms:[{av:'dynRoleId'},{av:'A104RoleId',fld:'ROLEID',pic:'ZZZZZ9'}]}");
         setEventMetadata("VALID_USERNAME","{handler:'Valid_Username',iparms:[{av:'A100UserName',fld:'USERNAME',pic:''},{av:'A99UserId',fld:'USERID',pic:'ZZZZZ9'},{av:'dynRoleId'},{av:'A104RoleId',fld:'ROLEID',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_USERNAME",",oparms:[{av:'dynRoleId'},{av:'A104RoleId',fld:'ROLEID',pic:'ZZZZZ9'}]}");
         setEventMetadata("VALID_ROLEID","{handler:'Valid_Roleid',iparms:[{av:'A105RoleName',fld:'ROLENAME',pic:''},{av:'dynRoleId'},{av:'A104RoleId',fld:'ROLEID',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_ROLEID",",oparms:[{av:'A105RoleName',fld:'ROLENAME',pic:''},{av:'dynRoleId'},{av:'A104RoleId',fld:'ROLEID',pic:'ZZZZZ9'}]}");
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
         pr_default.close(12);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z137UserEmail = "";
         Z100UserName = "";
         Z101UserPassword = "";
         Z109UserHash = "";
         Z102UserCreatedDate = DateTime.MinValue;
         Z103UserModifiedDate = DateTime.MinValue;
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
         A137UserEmail = "";
         A100UserName = "";
         A102UserCreatedDate = DateTime.MinValue;
         A103UserModifiedDate = DateTime.MinValue;
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         A101UserPassword = "";
         A109UserHash = "";
         Gx_date = DateTime.MinValue;
         A105RoleName = "";
         AV38Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode16 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXt_SdtSDTContextSession1 = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         AV14Context = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV13TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         AV28AuxUserName = "";
         AV29AuxUserEmail = "";
         AV21UserName = "";
         AV16UserEmail = "";
         AV26RolName = "";
         AV19URLs = new GxSimpleCollection<string>();
         AV20Names = new GxSimpleCollection<string>();
         AV24EmailTitle = "";
         AV25EmailSubtitle = "";
         AV17EmailBody = "";
         AV18EmailBodyAux = "";
         AV36EmailSubject = "";
         AV22USerCreatedDAte = DateTime.MinValue;
         Z105RoleName = "";
         T00044_A105RoleName = new string[] {""} ;
         T00045_A99UserId = new int[1] ;
         T00045_A137UserEmail = new string[] {""} ;
         T00045_n137UserEmail = new bool[] {false} ;
         T00045_A100UserName = new string[] {""} ;
         T00045_A101UserPassword = new string[] {""} ;
         T00045_A109UserHash = new string[] {""} ;
         T00045_A102UserCreatedDate = new DateTime[] {DateTime.MinValue} ;
         T00045_A103UserModifiedDate = new DateTime[] {DateTime.MinValue} ;
         T00045_A105RoleName = new string[] {""} ;
         T00045_A111UserActive = new bool[] {false} ;
         T00045_n111UserActive = new bool[] {false} ;
         T00045_A104RoleId = new int[1] ;
         T00045_n104RoleId = new bool[] {false} ;
         T00046_A100UserName = new string[] {""} ;
         T00047_A105RoleName = new string[] {""} ;
         T00048_A99UserId = new int[1] ;
         T00043_A99UserId = new int[1] ;
         T00043_A137UserEmail = new string[] {""} ;
         T00043_n137UserEmail = new bool[] {false} ;
         T00043_A100UserName = new string[] {""} ;
         T00043_A101UserPassword = new string[] {""} ;
         T00043_A109UserHash = new string[] {""} ;
         T00043_A102UserCreatedDate = new DateTime[] {DateTime.MinValue} ;
         T00043_A103UserModifiedDate = new DateTime[] {DateTime.MinValue} ;
         T00043_A111UserActive = new bool[] {false} ;
         T00043_n111UserActive = new bool[] {false} ;
         T00043_A104RoleId = new int[1] ;
         T00043_n104RoleId = new bool[] {false} ;
         T00049_A99UserId = new int[1] ;
         T000410_A99UserId = new int[1] ;
         T00042_A99UserId = new int[1] ;
         T00042_A137UserEmail = new string[] {""} ;
         T00042_n137UserEmail = new bool[] {false} ;
         T00042_A100UserName = new string[] {""} ;
         T00042_A101UserPassword = new string[] {""} ;
         T00042_A109UserHash = new string[] {""} ;
         T00042_A102UserCreatedDate = new DateTime[] {DateTime.MinValue} ;
         T00042_A103UserModifiedDate = new DateTime[] {DateTime.MinValue} ;
         T00042_A111UserActive = new bool[] {false} ;
         T00042_n111UserActive = new bool[] {false} ;
         T00042_A104RoleId = new int[1] ;
         T00042_n104RoleId = new bool[] {false} ;
         T000411_A99UserId = new int[1] ;
         T000414_A105RoleName = new string[] {""} ;
         T000415_A20InvoiceId = new int[1] ;
         T000416_A99UserId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         T000417_A104RoleId = new int[1] ;
         T000417_n104RoleId = new bool[] {false} ;
         T000417_A105RoleName = new string[] {""} ;
         T000418_A104RoleId = new int[1] ;
         T000418_n104RoleId = new bool[] {false} ;
         T000418_A105RoleName = new string[] {""} ;
         T000419_A100UserName = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.user__default(),
            new Object[][] {
                new Object[] {
               T00042_A99UserId, T00042_A137UserEmail, T00042_n137UserEmail, T00042_A100UserName, T00042_A101UserPassword, T00042_A109UserHash, T00042_A102UserCreatedDate, T00042_A103UserModifiedDate, T00042_A111UserActive, T00042_n111UserActive,
               T00042_A104RoleId, T00042_n104RoleId
               }
               , new Object[] {
               T00043_A99UserId, T00043_A137UserEmail, T00043_n137UserEmail, T00043_A100UserName, T00043_A101UserPassword, T00043_A109UserHash, T00043_A102UserCreatedDate, T00043_A103UserModifiedDate, T00043_A111UserActive, T00043_n111UserActive,
               T00043_A104RoleId, T00043_n104RoleId
               }
               , new Object[] {
               T00044_A105RoleName
               }
               , new Object[] {
               T00045_A99UserId, T00045_A137UserEmail, T00045_n137UserEmail, T00045_A100UserName, T00045_A101UserPassword, T00045_A109UserHash, T00045_A102UserCreatedDate, T00045_A103UserModifiedDate, T00045_A105RoleName, T00045_A111UserActive,
               T00045_n111UserActive, T00045_A104RoleId, T00045_n104RoleId
               }
               , new Object[] {
               T00046_A100UserName
               }
               , new Object[] {
               T00047_A105RoleName
               }
               , new Object[] {
               T00048_A99UserId
               }
               , new Object[] {
               T00049_A99UserId
               }
               , new Object[] {
               T000410_A99UserId
               }
               , new Object[] {
               T000411_A99UserId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000414_A105RoleName
               }
               , new Object[] {
               T000415_A20InvoiceId
               }
               , new Object[] {
               T000416_A99UserId
               }
               , new Object[] {
               T000417_A104RoleId, T000417_A105RoleName
               }
               , new Object[] {
               T000418_A104RoleId, T000418_A105RoleName
               }
               , new Object[] {
               T000419_A100UserName
               }
            }
         );
         AV38Pgmname = "User";
         Gx_date = DateTimeUtil.Today( context);
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short RcdFound16 ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short nIsDirty_16 ;
      private short gxajaxcallmode ;
      private int wcpOAV11UserId ;
      private int Z99UserId ;
      private int Z104RoleId ;
      private int N104RoleId ;
      private int A104RoleId ;
      private int AV11UserId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A99UserId ;
      private int edtUserId_Enabled ;
      private int edtUserEmail_Enabled ;
      private int edtUserName_Enabled ;
      private int edtUserCreatedDate_Enabled ;
      private int edtUserModifiedDate_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int AV12Insert_RoleId ;
      private int AV39GXV1 ;
      private int AV32AuxRoleId ;
      private int AV34RoleId ;
      private int idxLst ;
      private int gxdynajaxindex ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtUserEmail_Internalname ;
      private string dynRoleId_Internalname ;
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
      private string edtUserId_Internalname ;
      private string edtUserId_Jsonclick ;
      private string edtUserEmail_Jsonclick ;
      private string edtUserName_Internalname ;
      private string edtUserName_Jsonclick ;
      private string dynRoleId_Jsonclick ;
      private string edtUserCreatedDate_Internalname ;
      private string edtUserCreatedDate_Jsonclick ;
      private string edtUserModifiedDate_Internalname ;
      private string edtUserModifiedDate_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV38Pgmname ;
      private string hsh ;
      private string sMode16 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string gxwrpcisep ;
      private DateTime Z102UserCreatedDate ;
      private DateTime Z103UserModifiedDate ;
      private DateTime A102UserCreatedDate ;
      private DateTime A103UserModifiedDate ;
      private DateTime Gx_date ;
      private DateTime AV22USerCreatedDAte ;
      private bool Z111UserActive ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n104RoleId ;
      private bool wbErr ;
      private bool n137UserEmail ;
      private bool n111UserActive ;
      private bool A111UserActive ;
      private bool returnInSub ;
      private bool AV27UserActive ;
      private bool GXt_boolean2 ;
      private bool AV35WasChanged ;
      private bool AV15AllOk ;
      private bool Gx_longc ;
      private bool gxdyncontrolsrefreshing ;
      private string Z137UserEmail ;
      private string Z100UserName ;
      private string Z101UserPassword ;
      private string Z109UserHash ;
      private string A137UserEmail ;
      private string A100UserName ;
      private string A101UserPassword ;
      private string A109UserHash ;
      private string A105RoleName ;
      private string AV28AuxUserName ;
      private string AV29AuxUserEmail ;
      private string AV21UserName ;
      private string AV16UserEmail ;
      private string AV26RolName ;
      private string AV24EmailTitle ;
      private string AV25EmailSubtitle ;
      private string AV17EmailBody ;
      private string AV18EmailBodyAux ;
      private string AV36EmailSubject ;
      private string Z105RoleName ;
      private IGxSession AV10WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynRoleId ;
      private IDataStoreProvider pr_default ;
      private string[] T00044_A105RoleName ;
      private int[] T00045_A99UserId ;
      private string[] T00045_A137UserEmail ;
      private bool[] T00045_n137UserEmail ;
      private string[] T00045_A100UserName ;
      private string[] T00045_A101UserPassword ;
      private string[] T00045_A109UserHash ;
      private DateTime[] T00045_A102UserCreatedDate ;
      private DateTime[] T00045_A103UserModifiedDate ;
      private string[] T00045_A105RoleName ;
      private bool[] T00045_A111UserActive ;
      private bool[] T00045_n111UserActive ;
      private int[] T00045_A104RoleId ;
      private bool[] T00045_n104RoleId ;
      private string[] T00046_A100UserName ;
      private string[] T00047_A105RoleName ;
      private int[] T00048_A99UserId ;
      private int[] T00043_A99UserId ;
      private string[] T00043_A137UserEmail ;
      private bool[] T00043_n137UserEmail ;
      private string[] T00043_A100UserName ;
      private string[] T00043_A101UserPassword ;
      private string[] T00043_A109UserHash ;
      private DateTime[] T00043_A102UserCreatedDate ;
      private DateTime[] T00043_A103UserModifiedDate ;
      private bool[] T00043_A111UserActive ;
      private bool[] T00043_n111UserActive ;
      private int[] T00043_A104RoleId ;
      private bool[] T00043_n104RoleId ;
      private int[] T00049_A99UserId ;
      private int[] T000410_A99UserId ;
      private int[] T00042_A99UserId ;
      private string[] T00042_A137UserEmail ;
      private bool[] T00042_n137UserEmail ;
      private string[] T00042_A100UserName ;
      private string[] T00042_A101UserPassword ;
      private string[] T00042_A109UserHash ;
      private DateTime[] T00042_A102UserCreatedDate ;
      private DateTime[] T00042_A103UserModifiedDate ;
      private bool[] T00042_A111UserActive ;
      private bool[] T00042_n111UserActive ;
      private int[] T00042_A104RoleId ;
      private bool[] T00042_n104RoleId ;
      private int[] T000411_A99UserId ;
      private string[] T000414_A105RoleName ;
      private int[] T000415_A20InvoiceId ;
      private int[] T000416_A99UserId ;
      private int[] T000417_A104RoleId ;
      private bool[] T000417_n104RoleId ;
      private string[] T000417_A105RoleName ;
      private int[] T000418_A104RoleId ;
      private bool[] T000418_n104RoleId ;
      private string[] T000418_A105RoleName ;
      private string[] T000419_A100UserName ;
      private GxSimpleCollection<string> AV19URLs ;
      private GxSimpleCollection<string> AV20Names ;
      private GXWebForm Form ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession GXt_SdtSDTContextSession1 ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession AV14Context ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV13TrnContextAtt ;
   }

   public class user__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00045;
          prmT00045 = new Object[] {
          new ParDef("@UserId",GXType.Int32,6,0)
          };
          Object[] prmT00046;
          prmT00046 = new Object[] {
          new ParDef("@UserName",GXType.NVarChar,20,0) ,
          new ParDef("@UserId",GXType.Int32,6,0)
          };
          Object[] prmT00044;
          prmT00044 = new Object[] {
          new ParDef("@RoleId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT00047;
          prmT00047 = new Object[] {
          new ParDef("@RoleId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT00048;
          prmT00048 = new Object[] {
          new ParDef("@UserId",GXType.Int32,6,0)
          };
          Object[] prmT00043;
          prmT00043 = new Object[] {
          new ParDef("@UserId",GXType.Int32,6,0)
          };
          Object[] prmT00049;
          prmT00049 = new Object[] {
          new ParDef("@UserId",GXType.Int32,6,0)
          };
          Object[] prmT000410;
          prmT000410 = new Object[] {
          new ParDef("@UserId",GXType.Int32,6,0)
          };
          Object[] prmT00042;
          prmT00042 = new Object[] {
          new ParDef("@UserId",GXType.Int32,6,0)
          };
          Object[] prmT000411;
          prmT000411 = new Object[] {
          new ParDef("@UserEmail",GXType.NVarChar,100,0){Nullable=true} ,
          new ParDef("@UserName",GXType.NVarChar,20,0) ,
          new ParDef("@UserPassword",GXType.NVarChar,40,0) ,
          new ParDef("@UserHash",GXType.NVarChar,40,0) ,
          new ParDef("@UserCreatedDate",GXType.Date,8,0) ,
          new ParDef("@UserModifiedDate",GXType.Date,8,0) ,
          new ParDef("@UserActive",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@RoleId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000412;
          prmT000412 = new Object[] {
          new ParDef("@UserEmail",GXType.NVarChar,100,0){Nullable=true} ,
          new ParDef("@UserName",GXType.NVarChar,20,0) ,
          new ParDef("@UserPassword",GXType.NVarChar,40,0) ,
          new ParDef("@UserHash",GXType.NVarChar,40,0) ,
          new ParDef("@UserCreatedDate",GXType.Date,8,0) ,
          new ParDef("@UserModifiedDate",GXType.Date,8,0) ,
          new ParDef("@UserActive",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@RoleId",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("@UserId",GXType.Int32,6,0)
          };
          Object[] prmT000413;
          prmT000413 = new Object[] {
          new ParDef("@UserId",GXType.Int32,6,0)
          };
          Object[] prmT000415;
          prmT000415 = new Object[] {
          new ParDef("@UserId",GXType.Int32,6,0)
          };
          Object[] prmT000416;
          prmT000416 = new Object[] {
          };
          Object[] prmT000417;
          prmT000417 = new Object[] {
          };
          Object[] prmT000418;
          prmT000418 = new Object[] {
          };
          Object[] prmT000419;
          prmT000419 = new Object[] {
          new ParDef("@UserName",GXType.NVarChar,20,0) ,
          new ParDef("@UserId",GXType.Int32,6,0)
          };
          Object[] prmT000414;
          prmT000414 = new Object[] {
          new ParDef("@RoleId",GXType.Int32,6,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T00042", "SELECT [UserId], [UserEmail], [UserName], [UserPassword], [UserHash], [UserCreatedDate], [UserModifiedDate], [UserActive], [RoleId] FROM [User] WITH (UPDLOCK) WHERE [UserId] = @UserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00042,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00043", "SELECT [UserId], [UserEmail], [UserName], [UserPassword], [UserHash], [UserCreatedDate], [UserModifiedDate], [UserActive], [RoleId] FROM [User] WHERE [UserId] = @UserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00043,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00044", "SELECT [RoleName] FROM [Role] WHERE [RoleId] = @RoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00044,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00045", "SELECT TM1.[UserId], TM1.[UserEmail], TM1.[UserName], TM1.[UserPassword], TM1.[UserHash], TM1.[UserCreatedDate], TM1.[UserModifiedDate], T2.[RoleName], TM1.[UserActive], TM1.[RoleId] FROM ([User] TM1 LEFT JOIN [Role] T2 ON T2.[RoleId] = TM1.[RoleId]) WHERE TM1.[UserId] = @UserId ORDER BY TM1.[UserId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00045,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00046", "SELECT [UserName] FROM [User] WHERE ([UserName] = @UserName) AND (Not ( [UserId] = @UserId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT00046,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00047", "SELECT [RoleName] FROM [Role] WHERE [RoleId] = @RoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00047,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00048", "SELECT [UserId] FROM [User] WHERE [UserId] = @UserId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00048,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00049", "SELECT TOP 1 [UserId] FROM [User] WHERE ( [UserId] > @UserId) ORDER BY [UserId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00049,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000410", "SELECT TOP 1 [UserId] FROM [User] WHERE ( [UserId] < @UserId) ORDER BY [UserId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000410,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000411", "INSERT INTO [User]([UserEmail], [UserName], [UserPassword], [UserHash], [UserCreatedDate], [UserModifiedDate], [UserActive], [RoleId]) VALUES(@UserEmail, @UserName, @UserPassword, @UserHash, @UserCreatedDate, @UserModifiedDate, @UserActive, @RoleId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000411,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000412", "UPDATE [User] SET [UserEmail]=@UserEmail, [UserName]=@UserName, [UserPassword]=@UserPassword, [UserHash]=@UserHash, [UserCreatedDate]=@UserCreatedDate, [UserModifiedDate]=@UserModifiedDate, [UserActive]=@UserActive, [RoleId]=@RoleId  WHERE [UserId] = @UserId", GxErrorMask.GX_NOMASK,prmT000412)
             ,new CursorDef("T000413", "DELETE FROM [User]  WHERE [UserId] = @UserId", GxErrorMask.GX_NOMASK,prmT000413)
             ,new CursorDef("T000414", "SELECT [RoleName] FROM [Role] WHERE [RoleId] = @RoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000414,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000415", "SELECT TOP 1 [InvoiceId] FROM [Invoice] WHERE [UserId] = @UserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000415,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000416", "SELECT [UserId] FROM [User] ORDER BY [UserId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000416,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000417", "SELECT [RoleId], [RoleName] FROM [Role] ORDER BY [RoleName] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000417,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000418", "SELECT [RoleId], [RoleName] FROM [Role] ORDER BY [RoleName] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000418,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000419", "SELECT [UserName] FROM [User] WHERE ([UserName] = @UserName) AND (Not ( [UserId] = @UserId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000419,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(6);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(7);
                ((bool[]) buf[8])[0] = rslt.getBool(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((int[]) buf[10])[0] = rslt.getInt(9);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(6);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(7);
                ((bool[]) buf[8])[0] = rslt.getBool(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((int[]) buf[10])[0] = rslt.getInt(9);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(6);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((bool[]) buf[9])[0] = rslt.getBool(9);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((int[]) buf[11])[0] = rslt.getInt(10);
                ((bool[]) buf[12])[0] = rslt.wasNull(10);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
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
             case 12 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
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
                return;
             case 16 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 17 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
       }
    }

 }

}
