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
   public class sector : GXDataArea
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
               AV7SectorId = (int)(Math.Round(NumberUtil.Val( GetPar( "SectorId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7SectorId", StringUtil.LTrimStr( (decimal)(AV7SectorId), 6, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vSECTORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7SectorId), "ZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Sector", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtSectorName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("mtaKB", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public sector( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public sector( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_SectorId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7SectorId = aP1_SectorId;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Sector", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Sector.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Sector.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Sector.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Sector.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Sector.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Sector.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSectorId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSectorId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtSectorId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A9SectorId), 6, 0, ".", "")), StringUtil.LTrim( ((edtSectorId_Enabled!=0) ? context.localUtil.Format( (decimal)(A9SectorId), "ZZZZZ9") : context.localUtil.Format( (decimal)(A9SectorId), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSectorId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSectorId_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_Sector.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSectorName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSectorName_Internalname, "Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSectorName_Internalname, A10SectorName, StringUtil.RTrim( context.localUtil.Format( A10SectorName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSectorName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSectorName_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Name", "left", true, "", "HLP_Sector.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSectorDescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSectorDescription_Internalname, "Description", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtSectorDescription_Internalname, A11SectorDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", 0, 1, edtSectorDescription_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "GeneXusUnanimo\\Description", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Sector.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSectorCreatedDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSectorCreatedDate_Internalname, "Created Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         context.WriteHtmlText( "<div id=\""+edtSectorCreatedDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtSectorCreatedDate_Internalname, context.localUtil.Format(A34SectorCreatedDate, "99/99/99"), context.localUtil.Format( A34SectorCreatedDate, "99/99/99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSectorCreatedDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSectorCreatedDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Sector.htm");
         GxWebStd.gx_bitmap( context, edtSectorCreatedDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtSectorCreatedDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Sector.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSectorModifiedDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSectorModifiedDate_Internalname, "Modified Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtSectorModifiedDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtSectorModifiedDate_Internalname, context.localUtil.Format(A35SectorModifiedDate, "99/99/99"), context.localUtil.Format( A35SectorModifiedDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSectorModifiedDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSectorModifiedDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Sector.htm");
         GxWebStd.gx_bitmap( context, edtSectorModifiedDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtSectorModifiedDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Sector.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Sector.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Sector.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Sector.htm");
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
         E11032 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z9SectorId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z9SectorId"), ".", ","), 18, MidpointRounding.ToEven));
               Z10SectorName = cgiGet( "Z10SectorName");
               Z11SectorDescription = cgiGet( "Z11SectorDescription");
               n11SectorDescription = (String.IsNullOrEmpty(StringUtil.RTrim( A11SectorDescription)) ? true : false);
               Z34SectorCreatedDate = context.localUtil.CToD( cgiGet( "Z34SectorCreatedDate"), 0);
               Z35SectorModifiedDate = context.localUtil.CToD( cgiGet( "Z35SectorModifiedDate"), 0);
               n35SectorModifiedDate = ((DateTime.MinValue==A35SectorModifiedDate) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7SectorId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vSECTORID"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_date = context.localUtil.CToD( cgiGet( "vTODAY"), 0);
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","), 18, MidpointRounding.ToEven));
               AV13Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A9SectorId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtSectorId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A9SectorId", StringUtil.LTrimStr( (decimal)(A9SectorId), 6, 0));
               A10SectorName = cgiGet( edtSectorName_Internalname);
               AssignAttri("", false, "A10SectorName", A10SectorName);
               A11SectorDescription = cgiGet( edtSectorDescription_Internalname);
               n11SectorDescription = false;
               AssignAttri("", false, "A11SectorDescription", A11SectorDescription);
               n11SectorDescription = (String.IsNullOrEmpty(StringUtil.RTrim( A11SectorDescription)) ? true : false);
               A34SectorCreatedDate = context.localUtil.CToD( cgiGet( edtSectorCreatedDate_Internalname), 1);
               AssignAttri("", false, "A34SectorCreatedDate", context.localUtil.Format(A34SectorCreatedDate, "99/99/99"));
               if ( context.localUtil.VCDate( cgiGet( edtSectorModifiedDate_Internalname), 1) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Sector Modified Date"}), 1, "SECTORMODIFIEDDATE");
                  AnyError = 1;
                  GX_FocusControl = edtSectorModifiedDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A35SectorModifiedDate = DateTime.MinValue;
                  n35SectorModifiedDate = false;
                  AssignAttri("", false, "A35SectorModifiedDate", context.localUtil.Format(A35SectorModifiedDate, "99/99/99"));
               }
               else
               {
                  A35SectorModifiedDate = context.localUtil.CToD( cgiGet( edtSectorModifiedDate_Internalname), 1);
                  n35SectorModifiedDate = false;
                  AssignAttri("", false, "A35SectorModifiedDate", context.localUtil.Format(A35SectorModifiedDate, "99/99/99"));
               }
               n35SectorModifiedDate = ((DateTime.MinValue==A35SectorModifiedDate) ? true : false);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Sector");
               A9SectorId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtSectorId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A9SectorId", StringUtil.LTrimStr( (decimal)(A9SectorId), 6, 0));
               forbiddenHiddens.Add("SectorId", context.localUtil.Format( (decimal)(A9SectorId), "ZZZZZ9"));
               A34SectorCreatedDate = context.localUtil.CToD( cgiGet( edtSectorCreatedDate_Internalname), 1);
               AssignAttri("", false, "A34SectorCreatedDate", context.localUtil.Format(A34SectorCreatedDate, "99/99/99"));
               forbiddenHiddens.Add("SectorCreatedDate", context.localUtil.Format(A34SectorCreatedDate, "99/99/99"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A9SectorId != Z9SectorId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("sector:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A9SectorId = (int)(Math.Round(NumberUtil.Val( GetPar( "SectorId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A9SectorId", StringUtil.LTrimStr( (decimal)(A9SectorId), 6, 0));
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
                     sMode3 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode3;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound3 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_030( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "SECTORID");
                        AnyError = 1;
                        GX_FocusControl = edtSectorId_Internalname;
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
                           E11032 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12032 ();
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
            E12032 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll033( ) ;
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
            DisableAttributes033( ) ;
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

      protected void CONFIRM_030( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls033( ) ;
            }
            else
            {
               CheckExtendedTable033( ) ;
               CloseExtendedTableCursors033( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption030( )
      {
      }

      protected void E11032( )
      {
         /* Start Routine */
         returnInSub = false;
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

      protected void E12032( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwsector.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM033( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z10SectorName = T00033_A10SectorName[0];
               Z11SectorDescription = T00033_A11SectorDescription[0];
               Z34SectorCreatedDate = T00033_A34SectorCreatedDate[0];
               Z35SectorModifiedDate = T00033_A35SectorModifiedDate[0];
            }
            else
            {
               Z10SectorName = A10SectorName;
               Z11SectorDescription = A11SectorDescription;
               Z34SectorCreatedDate = A34SectorCreatedDate;
               Z35SectorModifiedDate = A35SectorModifiedDate;
            }
         }
         if ( GX_JID == -6 )
         {
            Z9SectorId = A9SectorId;
            Z10SectorName = A10SectorName;
            Z11SectorDescription = A11SectorDescription;
            Z34SectorCreatedDate = A34SectorCreatedDate;
            Z35SectorModifiedDate = A35SectorModifiedDate;
         }
      }

      protected void standaloneNotModal( )
      {
         edtSectorId_Enabled = 0;
         AssignProp("", false, edtSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorId_Enabled), 5, 0), true);
         edtSectorCreatedDate_Enabled = 0;
         AssignProp("", false, edtSectorCreatedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorCreatedDate_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         Gx_date = DateTimeUtil.Today( context);
         AssignAttri("", false, "Gx_date", context.localUtil.Format(Gx_date, "99/99/99"));
         edtSectorId_Enabled = 0;
         AssignProp("", false, edtSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorId_Enabled), 5, 0), true);
         edtSectorCreatedDate_Enabled = 0;
         AssignProp("", false, edtSectorCreatedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorCreatedDate_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7SectorId) )
         {
            A9SectorId = AV7SectorId;
            AssignAttri("", false, "A9SectorId", StringUtil.LTrimStr( (decimal)(A9SectorId), 6, 0));
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
         if ( IsIns( )  && (DateTime.MinValue==A34SectorCreatedDate) && ( Gx_BScreen == 0 ) )
         {
            A34SectorCreatedDate = Gx_date;
            AssignAttri("", false, "A34SectorCreatedDate", context.localUtil.Format(A34SectorCreatedDate, "99/99/99"));
         }
      }

      protected void Load033( )
      {
         /* Using cursor T00034 */
         pr_default.execute(2, new Object[] {A9SectorId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound3 = 1;
            A10SectorName = T00034_A10SectorName[0];
            AssignAttri("", false, "A10SectorName", A10SectorName);
            A11SectorDescription = T00034_A11SectorDescription[0];
            n11SectorDescription = T00034_n11SectorDescription[0];
            AssignAttri("", false, "A11SectorDescription", A11SectorDescription);
            A34SectorCreatedDate = T00034_A34SectorCreatedDate[0];
            AssignAttri("", false, "A34SectorCreatedDate", context.localUtil.Format(A34SectorCreatedDate, "99/99/99"));
            A35SectorModifiedDate = T00034_A35SectorModifiedDate[0];
            n35SectorModifiedDate = T00034_n35SectorModifiedDate[0];
            AssignAttri("", false, "A35SectorModifiedDate", context.localUtil.Format(A35SectorModifiedDate, "99/99/99"));
            ZM033( -6) ;
         }
         pr_default.close(2);
         OnLoadActions033( ) ;
      }

      protected void OnLoadActions033( )
      {
         AV13Pgmname = "Sector";
         AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
      }

      protected void CheckExtendedTable033( )
      {
         nIsDirty_3 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV13Pgmname = "Sector";
         AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
         if ( ! ( (DateTime.MinValue==A35SectorModifiedDate) || ( DateTimeUtil.ResetTime ( A35SectorModifiedDate ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Sector Modified Date is out of range", "OutOfRange", 1, "SECTORMODIFIEDDATE");
            AnyError = 1;
            GX_FocusControl = edtSectorModifiedDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors033( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey033( )
      {
         /* Using cursor T00035 */
         pr_default.execute(3, new Object[] {A9SectorId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound3 = 1;
         }
         else
         {
            RcdFound3 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00033 */
         pr_default.execute(1, new Object[] {A9SectorId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM033( 6) ;
            RcdFound3 = 1;
            A9SectorId = T00033_A9SectorId[0];
            AssignAttri("", false, "A9SectorId", StringUtil.LTrimStr( (decimal)(A9SectorId), 6, 0));
            A10SectorName = T00033_A10SectorName[0];
            AssignAttri("", false, "A10SectorName", A10SectorName);
            A11SectorDescription = T00033_A11SectorDescription[0];
            n11SectorDescription = T00033_n11SectorDescription[0];
            AssignAttri("", false, "A11SectorDescription", A11SectorDescription);
            A34SectorCreatedDate = T00033_A34SectorCreatedDate[0];
            AssignAttri("", false, "A34SectorCreatedDate", context.localUtil.Format(A34SectorCreatedDate, "99/99/99"));
            A35SectorModifiedDate = T00033_A35SectorModifiedDate[0];
            n35SectorModifiedDate = T00033_n35SectorModifiedDate[0];
            AssignAttri("", false, "A35SectorModifiedDate", context.localUtil.Format(A35SectorModifiedDate, "99/99/99"));
            Z9SectorId = A9SectorId;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load033( ) ;
            if ( AnyError == 1 )
            {
               RcdFound3 = 0;
               InitializeNonKey033( ) ;
            }
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound3 = 0;
            InitializeNonKey033( ) ;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey033( ) ;
         if ( RcdFound3 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound3 = 0;
         /* Using cursor T00036 */
         pr_default.execute(4, new Object[] {A9SectorId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T00036_A9SectorId[0] < A9SectorId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T00036_A9SectorId[0] > A9SectorId ) ) )
            {
               A9SectorId = T00036_A9SectorId[0];
               AssignAttri("", false, "A9SectorId", StringUtil.LTrimStr( (decimal)(A9SectorId), 6, 0));
               RcdFound3 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound3 = 0;
         /* Using cursor T00037 */
         pr_default.execute(5, new Object[] {A9SectorId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T00037_A9SectorId[0] > A9SectorId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T00037_A9SectorId[0] < A9SectorId ) ) )
            {
               A9SectorId = T00037_A9SectorId[0];
               AssignAttri("", false, "A9SectorId", StringUtil.LTrimStr( (decimal)(A9SectorId), 6, 0));
               RcdFound3 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey033( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSectorName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert033( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound3 == 1 )
            {
               if ( A9SectorId != Z9SectorId )
               {
                  A9SectorId = Z9SectorId;
                  AssignAttri("", false, "A9SectorId", StringUtil.LTrimStr( (decimal)(A9SectorId), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SECTORID");
                  AnyError = 1;
                  GX_FocusControl = edtSectorId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtSectorName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update033( ) ;
                  GX_FocusControl = edtSectorName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A9SectorId != Z9SectorId )
               {
                  /* Insert record */
                  GX_FocusControl = edtSectorName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert033( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SECTORID");
                     AnyError = 1;
                     GX_FocusControl = edtSectorId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtSectorName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert033( ) ;
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
         if ( A9SectorId != Z9SectorId )
         {
            A9SectorId = Z9SectorId;
            AssignAttri("", false, "A9SectorId", StringUtil.LTrimStr( (decimal)(A9SectorId), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SECTORID");
            AnyError = 1;
            GX_FocusControl = edtSectorId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtSectorName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency033( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00032 */
            pr_default.execute(0, new Object[] {A9SectorId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Sector"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z10SectorName, T00032_A10SectorName[0]) != 0 ) || ( StringUtil.StrCmp(Z11SectorDescription, T00032_A11SectorDescription[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z34SectorCreatedDate ) != DateTimeUtil.ResetTime ( T00032_A34SectorCreatedDate[0] ) ) || ( DateTimeUtil.ResetTime ( Z35SectorModifiedDate ) != DateTimeUtil.ResetTime ( T00032_A35SectorModifiedDate[0] ) ) )
            {
               if ( StringUtil.StrCmp(Z10SectorName, T00032_A10SectorName[0]) != 0 )
               {
                  GXUtil.WriteLog("sector:[seudo value changed for attri]"+"SectorName");
                  GXUtil.WriteLogRaw("Old: ",Z10SectorName);
                  GXUtil.WriteLogRaw("Current: ",T00032_A10SectorName[0]);
               }
               if ( StringUtil.StrCmp(Z11SectorDescription, T00032_A11SectorDescription[0]) != 0 )
               {
                  GXUtil.WriteLog("sector:[seudo value changed for attri]"+"SectorDescription");
                  GXUtil.WriteLogRaw("Old: ",Z11SectorDescription);
                  GXUtil.WriteLogRaw("Current: ",T00032_A11SectorDescription[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z34SectorCreatedDate ) != DateTimeUtil.ResetTime ( T00032_A34SectorCreatedDate[0] ) )
               {
                  GXUtil.WriteLog("sector:[seudo value changed for attri]"+"SectorCreatedDate");
                  GXUtil.WriteLogRaw("Old: ",Z34SectorCreatedDate);
                  GXUtil.WriteLogRaw("Current: ",T00032_A34SectorCreatedDate[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z35SectorModifiedDate ) != DateTimeUtil.ResetTime ( T00032_A35SectorModifiedDate[0] ) )
               {
                  GXUtil.WriteLog("sector:[seudo value changed for attri]"+"SectorModifiedDate");
                  GXUtil.WriteLogRaw("Old: ",Z35SectorModifiedDate);
                  GXUtil.WriteLogRaw("Current: ",T00032_A35SectorModifiedDate[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Sector"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert033( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable033( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM033( 0) ;
            CheckOptimisticConcurrency033( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm033( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert033( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00038 */
                     pr_default.execute(6, new Object[] {A10SectorName, n11SectorDescription, A11SectorDescription, A34SectorCreatedDate, n35SectorModifiedDate, A35SectorModifiedDate});
                     A9SectorId = T00038_A9SectorId[0];
                     AssignAttri("", false, "A9SectorId", StringUtil.LTrimStr( (decimal)(A9SectorId), 6, 0));
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Sector");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption030( ) ;
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
               Load033( ) ;
            }
            EndLevel033( ) ;
         }
         CloseExtendedTableCursors033( ) ;
      }

      protected void Update033( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable033( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency033( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm033( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate033( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00039 */
                     pr_default.execute(7, new Object[] {A10SectorName, n11SectorDescription, A11SectorDescription, A34SectorCreatedDate, n35SectorModifiedDate, A35SectorModifiedDate, A9SectorId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Sector");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Sector"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate033( ) ;
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
            EndLevel033( ) ;
         }
         CloseExtendedTableCursors033( ) ;
      }

      protected void DeferredUpdate033( )
      {
      }

      protected void delete( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency033( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls033( ) ;
            AfterConfirm033( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete033( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000310 */
                  pr_default.execute(8, new Object[] {A9SectorId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Sector");
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
         sMode3 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel033( ) ;
         Gx_mode = sMode3;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls033( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV13Pgmname = "Sector";
            AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000311 */
            pr_default.execute(9, new Object[] {A9SectorId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Product"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel033( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete033( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("sector",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues030( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("sector",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart033( )
      {
         /* Scan By routine */
         /* Using cursor T000312 */
         pr_default.execute(10);
         RcdFound3 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound3 = 1;
            A9SectorId = T000312_A9SectorId[0];
            AssignAttri("", false, "A9SectorId", StringUtil.LTrimStr( (decimal)(A9SectorId), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext033( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound3 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound3 = 1;
            A9SectorId = T000312_A9SectorId[0];
            AssignAttri("", false, "A9SectorId", StringUtil.LTrimStr( (decimal)(A9SectorId), 6, 0));
         }
      }

      protected void ScanEnd033( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm033( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert033( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate033( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete033( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete033( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate033( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes033( )
      {
         edtSectorId_Enabled = 0;
         AssignProp("", false, edtSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorId_Enabled), 5, 0), true);
         edtSectorName_Enabled = 0;
         AssignProp("", false, edtSectorName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorName_Enabled), 5, 0), true);
         edtSectorDescription_Enabled = 0;
         AssignProp("", false, edtSectorDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorDescription_Enabled), 5, 0), true);
         edtSectorCreatedDate_Enabled = 0;
         AssignProp("", false, edtSectorCreatedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorCreatedDate_Enabled), 5, 0), true);
         edtSectorModifiedDate_Enabled = 0;
         AssignProp("", false, edtSectorModifiedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorModifiedDate_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes033( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues030( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("sector.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7SectorId,6,0))}, new string[] {"Gx_mode","SectorId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Sector");
         forbiddenHiddens.Add("SectorId", context.localUtil.Format( (decimal)(A9SectorId), "ZZZZZ9"));
         forbiddenHiddens.Add("SectorCreatedDate", context.localUtil.Format(A34SectorCreatedDate, "99/99/99"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("sector:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z9SectorId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9SectorId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z10SectorName", Z10SectorName);
         GxWebStd.gx_hidden_field( context, "Z11SectorDescription", Z11SectorDescription);
         GxWebStd.gx_hidden_field( context, "Z34SectorCreatedDate", context.localUtil.DToC( Z34SectorCreatedDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z35SectorModifiedDate", context.localUtil.DToC( Z35SectorModifiedDate, 0, "/"));
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
         GxWebStd.gx_hidden_field( context, "vSECTORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7SectorId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSECTORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7SectorId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
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
         return formatLink("sector.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7SectorId,6,0))}, new string[] {"Gx_mode","SectorId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Sector" ;
      }

      public override string GetPgmdesc( )
      {
         return "Sector" ;
      }

      protected void InitializeNonKey033( )
      {
         A10SectorName = "";
         AssignAttri("", false, "A10SectorName", A10SectorName);
         A11SectorDescription = "";
         n11SectorDescription = false;
         AssignAttri("", false, "A11SectorDescription", A11SectorDescription);
         n11SectorDescription = (String.IsNullOrEmpty(StringUtil.RTrim( A11SectorDescription)) ? true : false);
         A35SectorModifiedDate = DateTime.MinValue;
         n35SectorModifiedDate = false;
         AssignAttri("", false, "A35SectorModifiedDate", context.localUtil.Format(A35SectorModifiedDate, "99/99/99"));
         n35SectorModifiedDate = ((DateTime.MinValue==A35SectorModifiedDate) ? true : false);
         A34SectorCreatedDate = Gx_date;
         AssignAttri("", false, "A34SectorCreatedDate", context.localUtil.Format(A34SectorCreatedDate, "99/99/99"));
         Z10SectorName = "";
         Z11SectorDescription = "";
         Z34SectorCreatedDate = DateTime.MinValue;
         Z35SectorModifiedDate = DateTime.MinValue;
      }

      protected void InitAll033( )
      {
         A9SectorId = 0;
         AssignAttri("", false, "A9SectorId", StringUtil.LTrimStr( (decimal)(A9SectorId), 6, 0));
         InitializeNonKey033( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A34SectorCreatedDate = i34SectorCreatedDate;
         AssignAttri("", false, "A34SectorCreatedDate", context.localUtil.Format(A34SectorCreatedDate, "99/99/99"));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202311222273168", true, true);
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
         context.AddJavascriptSource("sector.js", "?202311222273168", false, true);
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
         edtSectorId_Internalname = "SECTORID";
         edtSectorName_Internalname = "SECTORNAME";
         edtSectorDescription_Internalname = "SECTORDESCRIPTION";
         edtSectorCreatedDate_Internalname = "SECTORCREATEDDATE";
         edtSectorModifiedDate_Internalname = "SECTORMODIFIEDDATE";
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
         Form.Caption = "Sector";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirm";
         bttBtn_enter_Caption = "Confirm";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtSectorModifiedDate_Jsonclick = "";
         edtSectorModifiedDate_Enabled = 1;
         edtSectorCreatedDate_Jsonclick = "";
         edtSectorCreatedDate_Enabled = 0;
         edtSectorDescription_Enabled = 1;
         edtSectorName_Jsonclick = "";
         edtSectorName_Enabled = 1;
         edtSectorId_Jsonclick = "";
         edtSectorId_Enabled = 0;
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7SectorId',fld:'vSECTORID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7SectorId',fld:'vSECTORID',pic:'ZZZZZ9',hsh:true},{av:'A9SectorId',fld:'SECTORID',pic:'ZZZZZ9'},{av:'A34SectorCreatedDate',fld:'SECTORCREATEDDATE',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12032',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_SECTORID","{handler:'Valid_Sectorid',iparms:[]");
         setEventMetadata("VALID_SECTORID",",oparms:[]}");
         setEventMetadata("VALID_SECTORMODIFIEDDATE","{handler:'Valid_Sectormodifieddate',iparms:[]");
         setEventMetadata("VALID_SECTORMODIFIEDDATE",",oparms:[]}");
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
         Z10SectorName = "";
         Z11SectorDescription = "";
         Z34SectorCreatedDate = DateTime.MinValue;
         Z35SectorModifiedDate = DateTime.MinValue;
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
         A10SectorName = "";
         A11SectorDescription = "";
         A34SectorCreatedDate = DateTime.MinValue;
         A35SectorModifiedDate = DateTime.MinValue;
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_date = DateTime.MinValue;
         AV13Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode3 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         T00034_A9SectorId = new int[1] ;
         T00034_A10SectorName = new string[] {""} ;
         T00034_A11SectorDescription = new string[] {""} ;
         T00034_n11SectorDescription = new bool[] {false} ;
         T00034_A34SectorCreatedDate = new DateTime[] {DateTime.MinValue} ;
         T00034_A35SectorModifiedDate = new DateTime[] {DateTime.MinValue} ;
         T00034_n35SectorModifiedDate = new bool[] {false} ;
         T00035_A9SectorId = new int[1] ;
         T00033_A9SectorId = new int[1] ;
         T00033_A10SectorName = new string[] {""} ;
         T00033_A11SectorDescription = new string[] {""} ;
         T00033_n11SectorDescription = new bool[] {false} ;
         T00033_A34SectorCreatedDate = new DateTime[] {DateTime.MinValue} ;
         T00033_A35SectorModifiedDate = new DateTime[] {DateTime.MinValue} ;
         T00033_n35SectorModifiedDate = new bool[] {false} ;
         T00036_A9SectorId = new int[1] ;
         T00037_A9SectorId = new int[1] ;
         T00032_A9SectorId = new int[1] ;
         T00032_A10SectorName = new string[] {""} ;
         T00032_A11SectorDescription = new string[] {""} ;
         T00032_n11SectorDescription = new bool[] {false} ;
         T00032_A34SectorCreatedDate = new DateTime[] {DateTime.MinValue} ;
         T00032_A35SectorModifiedDate = new DateTime[] {DateTime.MinValue} ;
         T00032_n35SectorModifiedDate = new bool[] {false} ;
         T00038_A9SectorId = new int[1] ;
         T000311_A15ProductId = new int[1] ;
         T000312_A9SectorId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i34SectorCreatedDate = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.sector__default(),
            new Object[][] {
                new Object[] {
               T00032_A9SectorId, T00032_A10SectorName, T00032_A11SectorDescription, T00032_n11SectorDescription, T00032_A34SectorCreatedDate, T00032_A35SectorModifiedDate, T00032_n35SectorModifiedDate
               }
               , new Object[] {
               T00033_A9SectorId, T00033_A10SectorName, T00033_A11SectorDescription, T00033_n11SectorDescription, T00033_A34SectorCreatedDate, T00033_A35SectorModifiedDate, T00033_n35SectorModifiedDate
               }
               , new Object[] {
               T00034_A9SectorId, T00034_A10SectorName, T00034_A11SectorDescription, T00034_n11SectorDescription, T00034_A34SectorCreatedDate, T00034_A35SectorModifiedDate, T00034_n35SectorModifiedDate
               }
               , new Object[] {
               T00035_A9SectorId
               }
               , new Object[] {
               T00036_A9SectorId
               }
               , new Object[] {
               T00037_A9SectorId
               }
               , new Object[] {
               T00038_A9SectorId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000311_A15ProductId
               }
               , new Object[] {
               T000312_A9SectorId
               }
            }
         );
         AV13Pgmname = "Sector";
         Z34SectorCreatedDate = DateTime.MinValue;
         A34SectorCreatedDate = DateTime.MinValue;
         i34SectorCreatedDate = DateTime.MinValue;
         Gx_date = DateTimeUtil.Today( context);
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short Gx_BScreen ;
      private short RcdFound3 ;
      private short GX_JID ;
      private short nIsDirty_3 ;
      private short gxajaxcallmode ;
      private int wcpOAV7SectorId ;
      private int Z9SectorId ;
      private int AV7SectorId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A9SectorId ;
      private int edtSectorId_Enabled ;
      private int edtSectorName_Enabled ;
      private int edtSectorDescription_Enabled ;
      private int edtSectorCreatedDate_Enabled ;
      private int edtSectorModifiedDate_Enabled ;
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
      private string edtSectorName_Internalname ;
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
      private string edtSectorId_Internalname ;
      private string edtSectorId_Jsonclick ;
      private string edtSectorName_Jsonclick ;
      private string edtSectorDescription_Internalname ;
      private string edtSectorCreatedDate_Internalname ;
      private string edtSectorCreatedDate_Jsonclick ;
      private string edtSectorModifiedDate_Internalname ;
      private string edtSectorModifiedDate_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Caption ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_enter_Tooltiptext ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV13Pgmname ;
      private string hsh ;
      private string sMode3 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z34SectorCreatedDate ;
      private DateTime Z35SectorModifiedDate ;
      private DateTime A34SectorCreatedDate ;
      private DateTime A35SectorModifiedDate ;
      private DateTime Gx_date ;
      private DateTime i34SectorCreatedDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n11SectorDescription ;
      private bool n35SectorModifiedDate ;
      private bool returnInSub ;
      private string Z10SectorName ;
      private string Z11SectorDescription ;
      private string A10SectorName ;
      private string A11SectorDescription ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T00034_A9SectorId ;
      private string[] T00034_A10SectorName ;
      private string[] T00034_A11SectorDescription ;
      private bool[] T00034_n11SectorDescription ;
      private DateTime[] T00034_A34SectorCreatedDate ;
      private DateTime[] T00034_A35SectorModifiedDate ;
      private bool[] T00034_n35SectorModifiedDate ;
      private int[] T00035_A9SectorId ;
      private int[] T00033_A9SectorId ;
      private string[] T00033_A10SectorName ;
      private string[] T00033_A11SectorDescription ;
      private bool[] T00033_n11SectorDescription ;
      private DateTime[] T00033_A34SectorCreatedDate ;
      private DateTime[] T00033_A35SectorModifiedDate ;
      private bool[] T00033_n35SectorModifiedDate ;
      private int[] T00036_A9SectorId ;
      private int[] T00037_A9SectorId ;
      private int[] T00032_A9SectorId ;
      private string[] T00032_A10SectorName ;
      private string[] T00032_A11SectorDescription ;
      private bool[] T00032_n11SectorDescription ;
      private DateTime[] T00032_A34SectorCreatedDate ;
      private DateTime[] T00032_A35SectorModifiedDate ;
      private bool[] T00032_n35SectorModifiedDate ;
      private int[] T00038_A9SectorId ;
      private int[] T000311_A15ProductId ;
      private int[] T000312_A9SectorId ;
      private GXWebForm Form ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
   }

   public class sector__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[10])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00034;
          prmT00034 = new Object[] {
          new ParDef("@SectorId",GXType.Int32,6,0)
          };
          Object[] prmT00035;
          prmT00035 = new Object[] {
          new ParDef("@SectorId",GXType.Int32,6,0)
          };
          Object[] prmT00033;
          prmT00033 = new Object[] {
          new ParDef("@SectorId",GXType.Int32,6,0)
          };
          Object[] prmT00036;
          prmT00036 = new Object[] {
          new ParDef("@SectorId",GXType.Int32,6,0)
          };
          Object[] prmT00037;
          prmT00037 = new Object[] {
          new ParDef("@SectorId",GXType.Int32,6,0)
          };
          Object[] prmT00032;
          prmT00032 = new Object[] {
          new ParDef("@SectorId",GXType.Int32,6,0)
          };
          Object[] prmT00038;
          prmT00038 = new Object[] {
          new ParDef("@SectorName",GXType.NVarChar,60,0) ,
          new ParDef("@SectorDescription",GXType.NVarChar,200,0){Nullable=true} ,
          new ParDef("@SectorCreatedDate",GXType.Date,8,0) ,
          new ParDef("@SectorModifiedDate",GXType.Date,8,0){Nullable=true}
          };
          Object[] prmT00039;
          prmT00039 = new Object[] {
          new ParDef("@SectorName",GXType.NVarChar,60,0) ,
          new ParDef("@SectorDescription",GXType.NVarChar,200,0){Nullable=true} ,
          new ParDef("@SectorCreatedDate",GXType.Date,8,0) ,
          new ParDef("@SectorModifiedDate",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@SectorId",GXType.Int32,6,0)
          };
          Object[] prmT000310;
          prmT000310 = new Object[] {
          new ParDef("@SectorId",GXType.Int32,6,0)
          };
          Object[] prmT000311;
          prmT000311 = new Object[] {
          new ParDef("@SectorId",GXType.Int32,6,0)
          };
          Object[] prmT000312;
          prmT000312 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T00032", "SELECT [SectorId], [SectorName], [SectorDescription], [SectorCreatedDate], [SectorModifiedDate] FROM [Sector] WITH (UPDLOCK) WHERE [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00032,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00033", "SELECT [SectorId], [SectorName], [SectorDescription], [SectorCreatedDate], [SectorModifiedDate] FROM [Sector] WHERE [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00033,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00034", "SELECT TM1.[SectorId], TM1.[SectorName], TM1.[SectorDescription], TM1.[SectorCreatedDate], TM1.[SectorModifiedDate] FROM [Sector] TM1 WHERE TM1.[SectorId] = @SectorId ORDER BY TM1.[SectorId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00034,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00035", "SELECT [SectorId] FROM [Sector] WHERE [SectorId] = @SectorId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00035,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00036", "SELECT TOP 1 [SectorId] FROM [Sector] WHERE ( [SectorId] > @SectorId) ORDER BY [SectorId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00036,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00037", "SELECT TOP 1 [SectorId] FROM [Sector] WHERE ( [SectorId] < @SectorId) ORDER BY [SectorId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00037,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00038", "INSERT INTO [Sector]([SectorName], [SectorDescription], [SectorCreatedDate], [SectorModifiedDate]) VALUES(@SectorName, @SectorDescription, @SectorCreatedDate, @SectorModifiedDate); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT00038,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00039", "UPDATE [Sector] SET [SectorName]=@SectorName, [SectorDescription]=@SectorDescription, [SectorCreatedDate]=@SectorCreatedDate, [SectorModifiedDate]=@SectorModifiedDate  WHERE [SectorId] = @SectorId", GxErrorMask.GX_NOMASK,prmT00039)
             ,new CursorDef("T000310", "DELETE FROM [Sector]  WHERE [SectorId] = @SectorId", GxErrorMask.GX_NOMASK,prmT000310)
             ,new CursorDef("T000311", "SELECT TOP 1 [ProductId] FROM [Product] WHERE [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000311,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000312", "SELECT [SectorId] FROM [Sector] ORDER BY [SectorId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000312,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
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
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
