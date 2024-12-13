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
   public class movement : GXDataArea
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
               AV7MovementId = (int)(Math.Round(NumberUtil.Val( GetPar( "MovementId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7MovementId", StringUtil.LTrimStr( (decimal)(AV7MovementId), 6, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vMOVEMENTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7MovementId), "ZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Movement", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = cmbMovementType_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("mtaKB", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public movement( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public movement( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_MovementId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7MovementId = aP1_MovementId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbMovementType = new GXCombobox();
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
         if ( cmbMovementType.ItemCount > 0 )
         {
            A124MovementType = (short)(Math.Round(NumberUtil.Val( cmbMovementType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A124MovementType), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A124MovementType", StringUtil.LTrimStr( (decimal)(A124MovementType), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbMovementType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A124MovementType), 4, 0));
            AssignProp("", false, cmbMovementType_Internalname, "Values", cmbMovementType.ToJavascriptSource(), true);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Movement", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Movement.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Movement.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Movement.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Movement.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Movement.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Movement.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMovementId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMovementId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMovementId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A123MovementId), 6, 0, ".", "")), StringUtil.LTrim( ((edtMovementId_Enabled!=0) ? context.localUtil.Format( (decimal)(A123MovementId), "ZZZZZ9") : context.localUtil.Format( (decimal)(A123MovementId), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMovementId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMovementId_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_Movement.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbMovementType_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbMovementType_Internalname, "Type", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbMovementType, cmbMovementType_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A124MovementType), 4, 0)), 1, cmbMovementType_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbMovementType.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "", true, 0, "HLP_Movement.htm");
         cmbMovementType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A124MovementType), 4, 0));
         AssignProp("", false, cmbMovementType_Internalname, "Values", (string)(cmbMovementType.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMovementCreatedDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMovementCreatedDate_Internalname, "Created Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtMovementCreatedDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtMovementCreatedDate_Internalname, context.localUtil.Format(A125MovementCreatedDate, "99/99/99"), context.localUtil.Format( A125MovementCreatedDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMovementCreatedDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMovementCreatedDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Movement.htm");
         GxWebStd.gx_bitmap( context, edtMovementCreatedDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtMovementCreatedDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Movement.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMovementKeyAditional_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMovementKeyAditional_Internalname, "Key Aditional", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMovementKeyAditional_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A128MovementKeyAditional), 6, 0, ".", "")), StringUtil.LTrim( ((edtMovementKeyAditional_Enabled!=0) ? context.localUtil.Format( (decimal)(A128MovementKeyAditional), "ZZZZZ9") : context.localUtil.Format( (decimal)(A128MovementKeyAditional), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMovementKeyAditional_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMovementKeyAditional_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Movement.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMovementQuantity_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMovementQuantity_Internalname, "Quantity", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMovementQuantity_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A127MovementQuantity), 4, 0, ".", "")), StringUtil.LTrim( ((edtMovementQuantity_Enabled!=0) ? context.localUtil.Format( (decimal)(A127MovementQuantity), "ZZZ9") : context.localUtil.Format( (decimal)(A127MovementQuantity), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMovementQuantity_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMovementQuantity_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Movement.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Movement.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Movement.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Movement.htm");
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
         E110F2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z123MovementId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z123MovementId"), ".", ","), 18, MidpointRounding.ToEven));
               Z124MovementType = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z124MovementType"), ".", ","), 18, MidpointRounding.ToEven));
               Z125MovementCreatedDate = context.localUtil.CToD( cgiGet( "Z125MovementCreatedDate"), 0);
               Z128MovementKeyAditional = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z128MovementKeyAditional"), ".", ","), 18, MidpointRounding.ToEven));
               Z127MovementQuantity = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z127MovementQuantity"), ".", ","), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7MovementId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vMOVEMENTID"), ".", ","), 18, MidpointRounding.ToEven));
               AV11Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A123MovementId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtMovementId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A123MovementId", StringUtil.LTrimStr( (decimal)(A123MovementId), 6, 0));
               cmbMovementType.CurrentValue = cgiGet( cmbMovementType_Internalname);
               A124MovementType = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbMovementType_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A124MovementType", StringUtil.LTrimStr( (decimal)(A124MovementType), 4, 0));
               if ( context.localUtil.VCDate( cgiGet( edtMovementCreatedDate_Internalname), 1) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Movement Created Date"}), 1, "MOVEMENTCREATEDDATE");
                  AnyError = 1;
                  GX_FocusControl = edtMovementCreatedDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A125MovementCreatedDate = DateTime.MinValue;
                  AssignAttri("", false, "A125MovementCreatedDate", context.localUtil.Format(A125MovementCreatedDate, "99/99/99"));
               }
               else
               {
                  A125MovementCreatedDate = context.localUtil.CToD( cgiGet( edtMovementCreatedDate_Internalname), 1);
                  AssignAttri("", false, "A125MovementCreatedDate", context.localUtil.Format(A125MovementCreatedDate, "99/99/99"));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtMovementKeyAditional_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMovementKeyAditional_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MOVEMENTKEYADITIONAL");
                  AnyError = 1;
                  GX_FocusControl = edtMovementKeyAditional_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A128MovementKeyAditional = 0;
                  AssignAttri("", false, "A128MovementKeyAditional", StringUtil.LTrimStr( (decimal)(A128MovementKeyAditional), 6, 0));
               }
               else
               {
                  A128MovementKeyAditional = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtMovementKeyAditional_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A128MovementKeyAditional", StringUtil.LTrimStr( (decimal)(A128MovementKeyAditional), 6, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtMovementQuantity_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMovementQuantity_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MOVEMENTQUANTITY");
                  AnyError = 1;
                  GX_FocusControl = edtMovementQuantity_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A127MovementQuantity = 0;
                  AssignAttri("", false, "A127MovementQuantity", StringUtil.LTrimStr( (decimal)(A127MovementQuantity), 4, 0));
               }
               else
               {
                  A127MovementQuantity = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtMovementQuantity_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A127MovementQuantity", StringUtil.LTrimStr( (decimal)(A127MovementQuantity), 4, 0));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Movement");
               A123MovementId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtMovementId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A123MovementId", StringUtil.LTrimStr( (decimal)(A123MovementId), 6, 0));
               forbiddenHiddens.Add("MovementId", context.localUtil.Format( (decimal)(A123MovementId), "ZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A123MovementId != Z123MovementId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("movement:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A123MovementId = (int)(Math.Round(NumberUtil.Val( GetPar( "MovementId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A123MovementId", StringUtil.LTrimStr( (decimal)(A123MovementId), 6, 0));
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
                     sMode22 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode22;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound22 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0F0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "MOVEMENTID");
                        AnyError = 1;
                        GX_FocusControl = edtMovementId_Internalname;
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
                           E110F2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120F2 ();
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
            E120F2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0F22( ) ;
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
            DisableAttributes0F22( ) ;
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

      protected void CONFIRM_0F0( )
      {
         BeforeValidate0F22( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0F22( ) ;
            }
            else
            {
               CheckExtendedTable0F22( ) ;
               CloseExtendedTableCursors0F22( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0F0( )
      {
      }

      protected void E110F2( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV11Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV11Pgmname))}, new string[] {"GxObject"}) );
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

      protected void E120F2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwmovement.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0F22( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z124MovementType = T000F3_A124MovementType[0];
               Z125MovementCreatedDate = T000F3_A125MovementCreatedDate[0];
               Z128MovementKeyAditional = T000F3_A128MovementKeyAditional[0];
               Z127MovementQuantity = T000F3_A127MovementQuantity[0];
            }
            else
            {
               Z124MovementType = A124MovementType;
               Z125MovementCreatedDate = A125MovementCreatedDate;
               Z128MovementKeyAditional = A128MovementKeyAditional;
               Z127MovementQuantity = A127MovementQuantity;
            }
         }
         if ( GX_JID == -5 )
         {
            Z123MovementId = A123MovementId;
            Z124MovementType = A124MovementType;
            Z125MovementCreatedDate = A125MovementCreatedDate;
            Z128MovementKeyAditional = A128MovementKeyAditional;
            Z127MovementQuantity = A127MovementQuantity;
         }
      }

      protected void standaloneNotModal( )
      {
         edtMovementId_Enabled = 0;
         AssignProp("", false, edtMovementId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMovementId_Enabled), 5, 0), true);
         edtMovementId_Enabled = 0;
         AssignProp("", false, edtMovementId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMovementId_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7MovementId) )
         {
            A123MovementId = AV7MovementId;
            AssignAttri("", false, "A123MovementId", StringUtil.LTrimStr( (decimal)(A123MovementId), 6, 0));
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

      protected void Load0F22( )
      {
         /* Using cursor T000F4 */
         pr_default.execute(2, new Object[] {A123MovementId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound22 = 1;
            A124MovementType = T000F4_A124MovementType[0];
            AssignAttri("", false, "A124MovementType", StringUtil.LTrimStr( (decimal)(A124MovementType), 4, 0));
            A125MovementCreatedDate = T000F4_A125MovementCreatedDate[0];
            AssignAttri("", false, "A125MovementCreatedDate", context.localUtil.Format(A125MovementCreatedDate, "99/99/99"));
            A128MovementKeyAditional = T000F4_A128MovementKeyAditional[0];
            AssignAttri("", false, "A128MovementKeyAditional", StringUtil.LTrimStr( (decimal)(A128MovementKeyAditional), 6, 0));
            A127MovementQuantity = T000F4_A127MovementQuantity[0];
            AssignAttri("", false, "A127MovementQuantity", StringUtil.LTrimStr( (decimal)(A127MovementQuantity), 4, 0));
            ZM0F22( -5) ;
         }
         pr_default.close(2);
         OnLoadActions0F22( ) ;
      }

      protected void OnLoadActions0F22( )
      {
         AV11Pgmname = "Movement";
         AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
      }

      protected void CheckExtendedTable0F22( )
      {
         nIsDirty_22 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV11Pgmname = "Movement";
         AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
         if ( ! ( ( A124MovementType == 1 ) || ( A124MovementType == 2 ) ) )
         {
            GX_msglist.addItem("Field Movement Type is out of range", "OutOfRange", 1, "MOVEMENTTYPE");
            AnyError = 1;
            GX_FocusControl = cmbMovementType_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A125MovementCreatedDate) || ( DateTimeUtil.ResetTime ( A125MovementCreatedDate ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Movement Created Date is out of range", "OutOfRange", 1, "MOVEMENTCREATEDDATE");
            AnyError = 1;
            GX_FocusControl = edtMovementCreatedDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0F22( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0F22( )
      {
         /* Using cursor T000F5 */
         pr_default.execute(3, new Object[] {A123MovementId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound22 = 1;
         }
         else
         {
            RcdFound22 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000F3 */
         pr_default.execute(1, new Object[] {A123MovementId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0F22( 5) ;
            RcdFound22 = 1;
            A123MovementId = T000F3_A123MovementId[0];
            AssignAttri("", false, "A123MovementId", StringUtil.LTrimStr( (decimal)(A123MovementId), 6, 0));
            A124MovementType = T000F3_A124MovementType[0];
            AssignAttri("", false, "A124MovementType", StringUtil.LTrimStr( (decimal)(A124MovementType), 4, 0));
            A125MovementCreatedDate = T000F3_A125MovementCreatedDate[0];
            AssignAttri("", false, "A125MovementCreatedDate", context.localUtil.Format(A125MovementCreatedDate, "99/99/99"));
            A128MovementKeyAditional = T000F3_A128MovementKeyAditional[0];
            AssignAttri("", false, "A128MovementKeyAditional", StringUtil.LTrimStr( (decimal)(A128MovementKeyAditional), 6, 0));
            A127MovementQuantity = T000F3_A127MovementQuantity[0];
            AssignAttri("", false, "A127MovementQuantity", StringUtil.LTrimStr( (decimal)(A127MovementQuantity), 4, 0));
            Z123MovementId = A123MovementId;
            sMode22 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0F22( ) ;
            if ( AnyError == 1 )
            {
               RcdFound22 = 0;
               InitializeNonKey0F22( ) ;
            }
            Gx_mode = sMode22;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound22 = 0;
            InitializeNonKey0F22( ) ;
            sMode22 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode22;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0F22( ) ;
         if ( RcdFound22 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound22 = 0;
         /* Using cursor T000F6 */
         pr_default.execute(4, new Object[] {A123MovementId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T000F6_A123MovementId[0] < A123MovementId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T000F6_A123MovementId[0] > A123MovementId ) ) )
            {
               A123MovementId = T000F6_A123MovementId[0];
               AssignAttri("", false, "A123MovementId", StringUtil.LTrimStr( (decimal)(A123MovementId), 6, 0));
               RcdFound22 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound22 = 0;
         /* Using cursor T000F7 */
         pr_default.execute(5, new Object[] {A123MovementId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T000F7_A123MovementId[0] > A123MovementId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T000F7_A123MovementId[0] < A123MovementId ) ) )
            {
               A123MovementId = T000F7_A123MovementId[0];
               AssignAttri("", false, "A123MovementId", StringUtil.LTrimStr( (decimal)(A123MovementId), 6, 0));
               RcdFound22 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0F22( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = cmbMovementType_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0F22( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound22 == 1 )
            {
               if ( A123MovementId != Z123MovementId )
               {
                  A123MovementId = Z123MovementId;
                  AssignAttri("", false, "A123MovementId", StringUtil.LTrimStr( (decimal)(A123MovementId), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "MOVEMENTID");
                  AnyError = 1;
                  GX_FocusControl = edtMovementId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = cmbMovementType_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0F22( ) ;
                  GX_FocusControl = cmbMovementType_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A123MovementId != Z123MovementId )
               {
                  /* Insert record */
                  GX_FocusControl = cmbMovementType_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0F22( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "MOVEMENTID");
                     AnyError = 1;
                     GX_FocusControl = edtMovementId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = cmbMovementType_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0F22( ) ;
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
         if ( A123MovementId != Z123MovementId )
         {
            A123MovementId = Z123MovementId;
            AssignAttri("", false, "A123MovementId", StringUtil.LTrimStr( (decimal)(A123MovementId), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "MOVEMENTID");
            AnyError = 1;
            GX_FocusControl = edtMovementId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = cmbMovementType_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0F22( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000F2 */
            pr_default.execute(0, new Object[] {A123MovementId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Movement"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z124MovementType != T000F2_A124MovementType[0] ) || ( DateTimeUtil.ResetTime ( Z125MovementCreatedDate ) != DateTimeUtil.ResetTime ( T000F2_A125MovementCreatedDate[0] ) ) || ( Z128MovementKeyAditional != T000F2_A128MovementKeyAditional[0] ) || ( Z127MovementQuantity != T000F2_A127MovementQuantity[0] ) )
            {
               if ( Z124MovementType != T000F2_A124MovementType[0] )
               {
                  GXUtil.WriteLog("movement:[seudo value changed for attri]"+"MovementType");
                  GXUtil.WriteLogRaw("Old: ",Z124MovementType);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A124MovementType[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z125MovementCreatedDate ) != DateTimeUtil.ResetTime ( T000F2_A125MovementCreatedDate[0] ) )
               {
                  GXUtil.WriteLog("movement:[seudo value changed for attri]"+"MovementCreatedDate");
                  GXUtil.WriteLogRaw("Old: ",Z125MovementCreatedDate);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A125MovementCreatedDate[0]);
               }
               if ( Z128MovementKeyAditional != T000F2_A128MovementKeyAditional[0] )
               {
                  GXUtil.WriteLog("movement:[seudo value changed for attri]"+"MovementKeyAditional");
                  GXUtil.WriteLogRaw("Old: ",Z128MovementKeyAditional);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A128MovementKeyAditional[0]);
               }
               if ( Z127MovementQuantity != T000F2_A127MovementQuantity[0] )
               {
                  GXUtil.WriteLog("movement:[seudo value changed for attri]"+"MovementQuantity");
                  GXUtil.WriteLogRaw("Old: ",Z127MovementQuantity);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A127MovementQuantity[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Movement"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0F22( )
      {
         BeforeValidate0F22( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F22( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0F22( 0) ;
            CheckOptimisticConcurrency0F22( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F22( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0F22( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000F8 */
                     pr_default.execute(6, new Object[] {A124MovementType, A125MovementCreatedDate, A128MovementKeyAditional, A127MovementQuantity});
                     A123MovementId = T000F8_A123MovementId[0];
                     AssignAttri("", false, "A123MovementId", StringUtil.LTrimStr( (decimal)(A123MovementId), 6, 0));
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Movement");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0F0( ) ;
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
               Load0F22( ) ;
            }
            EndLevel0F22( ) ;
         }
         CloseExtendedTableCursors0F22( ) ;
      }

      protected void Update0F22( )
      {
         BeforeValidate0F22( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F22( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F22( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F22( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0F22( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000F9 */
                     pr_default.execute(7, new Object[] {A124MovementType, A125MovementCreatedDate, A128MovementKeyAditional, A127MovementQuantity, A123MovementId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Movement");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Movement"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0F22( ) ;
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
            EndLevel0F22( ) ;
         }
         CloseExtendedTableCursors0F22( ) ;
      }

      protected void DeferredUpdate0F22( )
      {
      }

      protected void delete( )
      {
         BeforeValidate0F22( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F22( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0F22( ) ;
            AfterConfirm0F22( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0F22( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000F10 */
                  pr_default.execute(8, new Object[] {A123MovementId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Movement");
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
         sMode22 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0F22( ) ;
         Gx_mode = sMode22;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0F22( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV11Pgmname = "Movement";
            AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
         }
      }

      protected void EndLevel0F22( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0F22( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("movement",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0F0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("movement",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0F22( )
      {
         /* Scan By routine */
         /* Using cursor T000F11 */
         pr_default.execute(9);
         RcdFound22 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound22 = 1;
            A123MovementId = T000F11_A123MovementId[0];
            AssignAttri("", false, "A123MovementId", StringUtil.LTrimStr( (decimal)(A123MovementId), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0F22( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound22 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound22 = 1;
            A123MovementId = T000F11_A123MovementId[0];
            AssignAttri("", false, "A123MovementId", StringUtil.LTrimStr( (decimal)(A123MovementId), 6, 0));
         }
      }

      protected void ScanEnd0F22( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm0F22( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0F22( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0F22( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0F22( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0F22( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0F22( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0F22( )
      {
         edtMovementId_Enabled = 0;
         AssignProp("", false, edtMovementId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMovementId_Enabled), 5, 0), true);
         cmbMovementType.Enabled = 0;
         AssignProp("", false, cmbMovementType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbMovementType.Enabled), 5, 0), true);
         edtMovementCreatedDate_Enabled = 0;
         AssignProp("", false, edtMovementCreatedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMovementCreatedDate_Enabled), 5, 0), true);
         edtMovementKeyAditional_Enabled = 0;
         AssignProp("", false, edtMovementKeyAditional_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMovementKeyAditional_Enabled), 5, 0), true);
         edtMovementQuantity_Enabled = 0;
         AssignProp("", false, edtMovementQuantity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMovementQuantity_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0F22( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0F0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("movement.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7MovementId,6,0))}, new string[] {"Gx_mode","MovementId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Movement");
         forbiddenHiddens.Add("MovementId", context.localUtil.Format( (decimal)(A123MovementId), "ZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("movement:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z123MovementId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z123MovementId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z124MovementType", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z124MovementType), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z125MovementCreatedDate", context.localUtil.DToC( Z125MovementCreatedDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z128MovementKeyAditional", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z128MovementKeyAditional), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z127MovementQuantity", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z127MovementQuantity), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
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
         GxWebStd.gx_hidden_field( context, "vMOVEMENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7MovementId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vMOVEMENTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7MovementId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV11Pgmname));
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
         return formatLink("movement.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7MovementId,6,0))}, new string[] {"Gx_mode","MovementId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Movement" ;
      }

      public override string GetPgmdesc( )
      {
         return "Movement" ;
      }

      protected void InitializeNonKey0F22( )
      {
         A124MovementType = 0;
         AssignAttri("", false, "A124MovementType", StringUtil.LTrimStr( (decimal)(A124MovementType), 4, 0));
         A125MovementCreatedDate = DateTime.MinValue;
         AssignAttri("", false, "A125MovementCreatedDate", context.localUtil.Format(A125MovementCreatedDate, "99/99/99"));
         A128MovementKeyAditional = 0;
         AssignAttri("", false, "A128MovementKeyAditional", StringUtil.LTrimStr( (decimal)(A128MovementKeyAditional), 6, 0));
         A127MovementQuantity = 0;
         AssignAttri("", false, "A127MovementQuantity", StringUtil.LTrimStr( (decimal)(A127MovementQuantity), 4, 0));
         Z124MovementType = 0;
         Z125MovementCreatedDate = DateTime.MinValue;
         Z128MovementKeyAditional = 0;
         Z127MovementQuantity = 0;
      }

      protected void InitAll0F22( )
      {
         A123MovementId = 0;
         AssignAttri("", false, "A123MovementId", StringUtil.LTrimStr( (decimal)(A123MovementId), 6, 0));
         InitializeNonKey0F22( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20241120046189", true, true);
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
         context.AddJavascriptSource("movement.js", "?20241120046189", false, true);
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
         edtMovementId_Internalname = "MOVEMENTID";
         cmbMovementType_Internalname = "MOVEMENTTYPE";
         edtMovementCreatedDate_Internalname = "MOVEMENTCREATEDDATE";
         edtMovementKeyAditional_Internalname = "MOVEMENTKEYADITIONAL";
         edtMovementQuantity_Internalname = "MOVEMENTQUANTITY";
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
         Form.Caption = "Movement";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirm";
         bttBtn_enter_Caption = "Confirm";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtMovementQuantity_Jsonclick = "";
         edtMovementQuantity_Enabled = 1;
         edtMovementKeyAditional_Jsonclick = "";
         edtMovementKeyAditional_Enabled = 1;
         edtMovementCreatedDate_Jsonclick = "";
         edtMovementCreatedDate_Enabled = 1;
         cmbMovementType_Jsonclick = "";
         cmbMovementType.Enabled = 1;
         edtMovementId_Jsonclick = "";
         edtMovementId_Enabled = 0;
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

      protected void init_web_controls( )
      {
         cmbMovementType.Name = "MOVEMENTTYPE";
         cmbMovementType.WebTags = "";
         cmbMovementType.addItem("1", "Product Discard", 0);
         cmbMovementType.addItem("2", "Product Added", 0);
         if ( cmbMovementType.ItemCount > 0 )
         {
            A124MovementType = (short)(Math.Round(NumberUtil.Val( cmbMovementType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A124MovementType), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A124MovementType", StringUtil.LTrimStr( (decimal)(A124MovementType), 4, 0));
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

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7MovementId',fld:'vMOVEMENTID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7MovementId',fld:'vMOVEMENTID',pic:'ZZZZZ9',hsh:true},{av:'A123MovementId',fld:'MOVEMENTID',pic:'ZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120F2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_MOVEMENTID","{handler:'Valid_Movementid',iparms:[]");
         setEventMetadata("VALID_MOVEMENTID",",oparms:[]}");
         setEventMetadata("VALID_MOVEMENTTYPE","{handler:'Valid_Movementtype',iparms:[]");
         setEventMetadata("VALID_MOVEMENTTYPE",",oparms:[]}");
         setEventMetadata("VALID_MOVEMENTCREATEDDATE","{handler:'Valid_Movementcreateddate',iparms:[]");
         setEventMetadata("VALID_MOVEMENTCREATEDDATE",",oparms:[]}");
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
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z125MovementCreatedDate = DateTime.MinValue;
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
         A125MovementCreatedDate = DateTime.MinValue;
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV11Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode22 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         T000F4_A123MovementId = new int[1] ;
         T000F4_A124MovementType = new short[1] ;
         T000F4_A125MovementCreatedDate = new DateTime[] {DateTime.MinValue} ;
         T000F4_A128MovementKeyAditional = new int[1] ;
         T000F4_A127MovementQuantity = new short[1] ;
         T000F5_A123MovementId = new int[1] ;
         T000F3_A123MovementId = new int[1] ;
         T000F3_A124MovementType = new short[1] ;
         T000F3_A125MovementCreatedDate = new DateTime[] {DateTime.MinValue} ;
         T000F3_A128MovementKeyAditional = new int[1] ;
         T000F3_A127MovementQuantity = new short[1] ;
         T000F6_A123MovementId = new int[1] ;
         T000F7_A123MovementId = new int[1] ;
         T000F2_A123MovementId = new int[1] ;
         T000F2_A124MovementType = new short[1] ;
         T000F2_A125MovementCreatedDate = new DateTime[] {DateTime.MinValue} ;
         T000F2_A128MovementKeyAditional = new int[1] ;
         T000F2_A127MovementQuantity = new short[1] ;
         T000F8_A123MovementId = new int[1] ;
         T000F11_A123MovementId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.movement__default(),
            new Object[][] {
                new Object[] {
               T000F2_A123MovementId, T000F2_A124MovementType, T000F2_A125MovementCreatedDate, T000F2_A128MovementKeyAditional, T000F2_A127MovementQuantity
               }
               , new Object[] {
               T000F3_A123MovementId, T000F3_A124MovementType, T000F3_A125MovementCreatedDate, T000F3_A128MovementKeyAditional, T000F3_A127MovementQuantity
               }
               , new Object[] {
               T000F4_A123MovementId, T000F4_A124MovementType, T000F4_A125MovementCreatedDate, T000F4_A128MovementKeyAditional, T000F4_A127MovementQuantity
               }
               , new Object[] {
               T000F5_A123MovementId
               }
               , new Object[] {
               T000F6_A123MovementId
               }
               , new Object[] {
               T000F7_A123MovementId
               }
               , new Object[] {
               T000F8_A123MovementId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000F11_A123MovementId
               }
            }
         );
         AV11Pgmname = "Movement";
      }

      private short Z124MovementType ;
      private short Z127MovementQuantity ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A124MovementType ;
      private short A127MovementQuantity ;
      private short RcdFound22 ;
      private short GX_JID ;
      private short nIsDirty_22 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int wcpOAV7MovementId ;
      private int Z123MovementId ;
      private int Z128MovementKeyAditional ;
      private int AV7MovementId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A123MovementId ;
      private int edtMovementId_Enabled ;
      private int edtMovementCreatedDate_Enabled ;
      private int A128MovementKeyAditional ;
      private int edtMovementKeyAditional_Enabled ;
      private int edtMovementQuantity_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
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
      private string cmbMovementType_Internalname ;
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
      private string edtMovementId_Internalname ;
      private string edtMovementId_Jsonclick ;
      private string cmbMovementType_Jsonclick ;
      private string edtMovementCreatedDate_Internalname ;
      private string edtMovementCreatedDate_Jsonclick ;
      private string edtMovementKeyAditional_Internalname ;
      private string edtMovementKeyAditional_Jsonclick ;
      private string edtMovementQuantity_Internalname ;
      private string edtMovementQuantity_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Caption ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_enter_Tooltiptext ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV11Pgmname ;
      private string hsh ;
      private string sMode22 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z125MovementCreatedDate ;
      private DateTime A125MovementCreatedDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool returnInSub ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbMovementType ;
      private IDataStoreProvider pr_default ;
      private int[] T000F4_A123MovementId ;
      private short[] T000F4_A124MovementType ;
      private DateTime[] T000F4_A125MovementCreatedDate ;
      private int[] T000F4_A128MovementKeyAditional ;
      private short[] T000F4_A127MovementQuantity ;
      private int[] T000F5_A123MovementId ;
      private int[] T000F3_A123MovementId ;
      private short[] T000F3_A124MovementType ;
      private DateTime[] T000F3_A125MovementCreatedDate ;
      private int[] T000F3_A128MovementKeyAditional ;
      private short[] T000F3_A127MovementQuantity ;
      private int[] T000F6_A123MovementId ;
      private int[] T000F7_A123MovementId ;
      private int[] T000F2_A123MovementId ;
      private short[] T000F2_A124MovementType ;
      private DateTime[] T000F2_A125MovementCreatedDate ;
      private int[] T000F2_A128MovementKeyAditional ;
      private short[] T000F2_A127MovementQuantity ;
      private int[] T000F8_A123MovementId ;
      private int[] T000F11_A123MovementId ;
      private GXWebForm Form ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
   }

   public class movement__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new ForEachCursor(def[9])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000F4;
          prmT000F4 = new Object[] {
          new ParDef("@MovementId",GXType.Int32,6,0)
          };
          Object[] prmT000F5;
          prmT000F5 = new Object[] {
          new ParDef("@MovementId",GXType.Int32,6,0)
          };
          Object[] prmT000F3;
          prmT000F3 = new Object[] {
          new ParDef("@MovementId",GXType.Int32,6,0)
          };
          Object[] prmT000F6;
          prmT000F6 = new Object[] {
          new ParDef("@MovementId",GXType.Int32,6,0)
          };
          Object[] prmT000F7;
          prmT000F7 = new Object[] {
          new ParDef("@MovementId",GXType.Int32,6,0)
          };
          Object[] prmT000F2;
          prmT000F2 = new Object[] {
          new ParDef("@MovementId",GXType.Int32,6,0)
          };
          Object[] prmT000F8;
          prmT000F8 = new Object[] {
          new ParDef("@MovementType",GXType.Int16,4,0) ,
          new ParDef("@MovementCreatedDate",GXType.Date,8,0) ,
          new ParDef("@MovementKeyAditional",GXType.Int32,6,0) ,
          new ParDef("@MovementQuantity",GXType.Int16,4,0)
          };
          Object[] prmT000F9;
          prmT000F9 = new Object[] {
          new ParDef("@MovementType",GXType.Int16,4,0) ,
          new ParDef("@MovementCreatedDate",GXType.Date,8,0) ,
          new ParDef("@MovementKeyAditional",GXType.Int32,6,0) ,
          new ParDef("@MovementQuantity",GXType.Int16,4,0) ,
          new ParDef("@MovementId",GXType.Int32,6,0)
          };
          Object[] prmT000F10;
          prmT000F10 = new Object[] {
          new ParDef("@MovementId",GXType.Int32,6,0)
          };
          Object[] prmT000F11;
          prmT000F11 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T000F2", "SELECT [MovementId], [MovementType], [MovementCreatedDate], [MovementKeyAditional], [MovementQuantity] FROM [Movement] WITH (UPDLOCK) WHERE [MovementId] = @MovementId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000F3", "SELECT [MovementId], [MovementType], [MovementCreatedDate], [MovementKeyAditional], [MovementQuantity] FROM [Movement] WHERE [MovementId] = @MovementId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000F4", "SELECT TM1.[MovementId], TM1.[MovementType], TM1.[MovementCreatedDate], TM1.[MovementKeyAditional], TM1.[MovementQuantity] FROM [Movement] TM1 WHERE TM1.[MovementId] = @MovementId ORDER BY TM1.[MovementId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000F4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000F5", "SELECT [MovementId] FROM [Movement] WHERE [MovementId] = @MovementId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000F5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000F6", "SELECT TOP 1 [MovementId] FROM [Movement] WHERE ( [MovementId] > @MovementId) ORDER BY [MovementId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000F6,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000F7", "SELECT TOP 1 [MovementId] FROM [Movement] WHERE ( [MovementId] < @MovementId) ORDER BY [MovementId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000F7,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000F8", "INSERT INTO [Movement]([MovementType], [MovementCreatedDate], [MovementKeyAditional], [MovementQuantity]) VALUES(@MovementType, @MovementCreatedDate, @MovementKeyAditional, @MovementQuantity); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000F8,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000F9", "UPDATE [Movement] SET [MovementType]=@MovementType, [MovementCreatedDate]=@MovementCreatedDate, [MovementKeyAditional]=@MovementKeyAditional, [MovementQuantity]=@MovementQuantity  WHERE [MovementId] = @MovementId", GxErrorMask.GX_NOMASK,prmT000F9)
             ,new CursorDef("T000F10", "DELETE FROM [Movement]  WHERE [MovementId] = @MovementId", GxErrorMask.GX_NOMASK,prmT000F10)
             ,new CursorDef("T000F11", "SELECT [MovementId] FROM [Movement] ORDER BY [MovementId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000F11,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
