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
   public class brand : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A1BrandId = (int)(Math.Round(NumberUtil.Val( GetPar( "BrandId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A1BrandId", StringUtil.LTrimStr( (decimal)(A1BrandId), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A1BrandId) ;
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
               AV7BrandId = (int)(Math.Round(NumberUtil.Val( GetPar( "BrandId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7BrandId", StringUtil.LTrimStr( (decimal)(AV7BrandId), 6, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vBRANDID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7BrandId), "ZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Brand", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtBrandName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("mtaKB", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public brand( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public brand( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_BrandId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7BrandId = aP1_BrandId;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Brand", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Brand.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Brand.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Brand.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Brand.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Brand.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Brand.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtBrandId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtBrandId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtBrandId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1BrandId), 6, 0, ".", "")), StringUtil.LTrim( ((edtBrandId_Enabled!=0) ? context.localUtil.Format( (decimal)(A1BrandId), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1BrandId), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBrandId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtBrandId_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_Brand.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtBrandName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtBrandName_Internalname, "Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtBrandName_Internalname, A2BrandName, StringUtil.RTrim( context.localUtil.Format( A2BrandName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBrandName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtBrandName_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Name", "left", true, "", "HLP_Brand.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtBrandDescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtBrandDescription_Internalname, "Description", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtBrandDescription_Internalname, A3BrandDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", 0, 1, edtBrandDescription_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "GeneXusUnanimo\\Description", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Brand.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtBrandCreatedDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtBrandCreatedDate_Internalname, "Created Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         context.WriteHtmlText( "<div id=\""+edtBrandCreatedDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtBrandCreatedDate_Internalname, context.localUtil.Format(A30BrandCreatedDate, "99/99/99"), context.localUtil.Format( A30BrandCreatedDate, "99/99/99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBrandCreatedDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtBrandCreatedDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Brand.htm");
         GxWebStd.gx_bitmap( context, edtBrandCreatedDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtBrandCreatedDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Brand.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtBrandModifiedDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtBrandModifiedDate_Internalname, "Modified Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtBrandModifiedDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtBrandModifiedDate_Internalname, context.localUtil.Format(A31BrandModifiedDate, "99/99/99"), context.localUtil.Format( A31BrandModifiedDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBrandModifiedDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtBrandModifiedDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Brand.htm");
         GxWebStd.gx_bitmap( context, edtBrandModifiedDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtBrandModifiedDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Brand.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtBrandProductQuantity_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtBrandProductQuantity_Internalname, "Product Quantity", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtBrandProductQuantity_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A56BrandProductQuantity), 4, 0, ".", "")), StringUtil.LTrim( ((edtBrandProductQuantity_Enabled!=0) ? context.localUtil.Format( (decimal)(A56BrandProductQuantity), "ZZZ9") : context.localUtil.Format( (decimal)(A56BrandProductQuantity), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBrandProductQuantity_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtBrandProductQuantity_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Brand.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Brand.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Brand.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Brand.htm");
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
         E11012 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z1BrandId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z1BrandId"), ".", ","), 18, MidpointRounding.ToEven));
               Z2BrandName = cgiGet( "Z2BrandName");
               Z3BrandDescription = cgiGet( "Z3BrandDescription");
               n3BrandDescription = (String.IsNullOrEmpty(StringUtil.RTrim( A3BrandDescription)) ? true : false);
               Z30BrandCreatedDate = context.localUtil.CToD( cgiGet( "Z30BrandCreatedDate"), 0);
               Z31BrandModifiedDate = context.localUtil.CToD( cgiGet( "Z31BrandModifiedDate"), 0);
               n31BrandModifiedDate = ((DateTime.MinValue==A31BrandModifiedDate) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7BrandId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vBRANDID"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_date = context.localUtil.CToD( cgiGet( "vTODAY"), 0);
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","), 18, MidpointRounding.ToEven));
               AV13Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A1BrandId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtBrandId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A1BrandId", StringUtil.LTrimStr( (decimal)(A1BrandId), 6, 0));
               A2BrandName = cgiGet( edtBrandName_Internalname);
               AssignAttri("", false, "A2BrandName", A2BrandName);
               A3BrandDescription = cgiGet( edtBrandDescription_Internalname);
               n3BrandDescription = false;
               AssignAttri("", false, "A3BrandDescription", A3BrandDescription);
               n3BrandDescription = (String.IsNullOrEmpty(StringUtil.RTrim( A3BrandDescription)) ? true : false);
               A30BrandCreatedDate = context.localUtil.CToD( cgiGet( edtBrandCreatedDate_Internalname), 1);
               AssignAttri("", false, "A30BrandCreatedDate", context.localUtil.Format(A30BrandCreatedDate, "99/99/99"));
               if ( context.localUtil.VCDate( cgiGet( edtBrandModifiedDate_Internalname), 1) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Brand Modified Date"}), 1, "BRANDMODIFIEDDATE");
                  AnyError = 1;
                  GX_FocusControl = edtBrandModifiedDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A31BrandModifiedDate = DateTime.MinValue;
                  n31BrandModifiedDate = false;
                  AssignAttri("", false, "A31BrandModifiedDate", context.localUtil.Format(A31BrandModifiedDate, "99/99/99"));
               }
               else
               {
                  A31BrandModifiedDate = context.localUtil.CToD( cgiGet( edtBrandModifiedDate_Internalname), 1);
                  n31BrandModifiedDate = false;
                  AssignAttri("", false, "A31BrandModifiedDate", context.localUtil.Format(A31BrandModifiedDate, "99/99/99"));
               }
               n31BrandModifiedDate = ((DateTime.MinValue==A31BrandModifiedDate) ? true : false);
               A56BrandProductQuantity = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtBrandProductQuantity_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               n56BrandProductQuantity = false;
               AssignAttri("", false, "A56BrandProductQuantity", StringUtil.LTrimStr( (decimal)(A56BrandProductQuantity), 4, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Brand");
               A1BrandId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtBrandId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A1BrandId", StringUtil.LTrimStr( (decimal)(A1BrandId), 6, 0));
               forbiddenHiddens.Add("BrandId", context.localUtil.Format( (decimal)(A1BrandId), "ZZZZZ9"));
               A30BrandCreatedDate = context.localUtil.CToD( cgiGet( edtBrandCreatedDate_Internalname), 1);
               AssignAttri("", false, "A30BrandCreatedDate", context.localUtil.Format(A30BrandCreatedDate, "99/99/99"));
               forbiddenHiddens.Add("BrandCreatedDate", context.localUtil.Format(A30BrandCreatedDate, "99/99/99"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A1BrandId != Z1BrandId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("brand:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A1BrandId = (int)(Math.Round(NumberUtil.Val( GetPar( "BrandId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A1BrandId", StringUtil.LTrimStr( (decimal)(A1BrandId), 6, 0));
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
                     sMode1 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode1;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound1 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_010( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "BRANDID");
                        AnyError = 1;
                        GX_FocusControl = edtBrandId_Internalname;
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
                           E11012 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12012 ();
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
            E12012 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll011( ) ;
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
            DisableAttributes011( ) ;
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

      protected void CONFIRM_010( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls011( ) ;
            }
            else
            {
               CheckExtendedTable011( ) ;
               CloseExtendedTableCursors011( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption010( )
      {
      }

      protected void E11012( )
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

      protected void E12012( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwbrand.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM011( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2BrandName = T00013_A2BrandName[0];
               Z3BrandDescription = T00013_A3BrandDescription[0];
               Z30BrandCreatedDate = T00013_A30BrandCreatedDate[0];
               Z31BrandModifiedDate = T00013_A31BrandModifiedDate[0];
            }
            else
            {
               Z2BrandName = A2BrandName;
               Z3BrandDescription = A3BrandDescription;
               Z30BrandCreatedDate = A30BrandCreatedDate;
               Z31BrandModifiedDate = A31BrandModifiedDate;
            }
         }
         if ( GX_JID == -6 )
         {
            Z1BrandId = A1BrandId;
            Z2BrandName = A2BrandName;
            Z3BrandDescription = A3BrandDescription;
            Z30BrandCreatedDate = A30BrandCreatedDate;
            Z31BrandModifiedDate = A31BrandModifiedDate;
            Z56BrandProductQuantity = A56BrandProductQuantity;
         }
      }

      protected void standaloneNotModal( )
      {
         edtBrandId_Enabled = 0;
         AssignProp("", false, edtBrandId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBrandId_Enabled), 5, 0), true);
         edtBrandCreatedDate_Enabled = 0;
         AssignProp("", false, edtBrandCreatedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBrandCreatedDate_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         Gx_date = DateTimeUtil.Today( context);
         AssignAttri("", false, "Gx_date", context.localUtil.Format(Gx_date, "99/99/99"));
         edtBrandId_Enabled = 0;
         AssignProp("", false, edtBrandId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBrandId_Enabled), 5, 0), true);
         edtBrandCreatedDate_Enabled = 0;
         AssignProp("", false, edtBrandCreatedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBrandCreatedDate_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7BrandId) )
         {
            A1BrandId = AV7BrandId;
            AssignAttri("", false, "A1BrandId", StringUtil.LTrimStr( (decimal)(A1BrandId), 6, 0));
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
         if ( IsIns( )  && (DateTime.MinValue==A30BrandCreatedDate) && ( Gx_BScreen == 0 ) )
         {
            A30BrandCreatedDate = Gx_date;
            AssignAttri("", false, "A30BrandCreatedDate", context.localUtil.Format(A30BrandCreatedDate, "99/99/99"));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T00015 */
            pr_default.execute(2, new Object[] {A1BrandId});
            if ( (pr_default.getStatus(2) != 101) )
            {
               A56BrandProductQuantity = T00015_A56BrandProductQuantity[0];
               n56BrandProductQuantity = T00015_n56BrandProductQuantity[0];
               AssignAttri("", false, "A56BrandProductQuantity", StringUtil.LTrimStr( (decimal)(A56BrandProductQuantity), 4, 0));
            }
            else
            {
               A56BrandProductQuantity = 0;
               n56BrandProductQuantity = false;
               AssignAttri("", false, "A56BrandProductQuantity", StringUtil.LTrimStr( (decimal)(A56BrandProductQuantity), 4, 0));
            }
            pr_default.close(2);
         }
      }

      protected void Load011( )
      {
         /* Using cursor T00017 */
         pr_default.execute(3, new Object[] {A1BrandId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound1 = 1;
            A2BrandName = T00017_A2BrandName[0];
            AssignAttri("", false, "A2BrandName", A2BrandName);
            A3BrandDescription = T00017_A3BrandDescription[0];
            n3BrandDescription = T00017_n3BrandDescription[0];
            AssignAttri("", false, "A3BrandDescription", A3BrandDescription);
            A30BrandCreatedDate = T00017_A30BrandCreatedDate[0];
            AssignAttri("", false, "A30BrandCreatedDate", context.localUtil.Format(A30BrandCreatedDate, "99/99/99"));
            A31BrandModifiedDate = T00017_A31BrandModifiedDate[0];
            n31BrandModifiedDate = T00017_n31BrandModifiedDate[0];
            AssignAttri("", false, "A31BrandModifiedDate", context.localUtil.Format(A31BrandModifiedDate, "99/99/99"));
            A56BrandProductQuantity = T00017_A56BrandProductQuantity[0];
            n56BrandProductQuantity = T00017_n56BrandProductQuantity[0];
            AssignAttri("", false, "A56BrandProductQuantity", StringUtil.LTrimStr( (decimal)(A56BrandProductQuantity), 4, 0));
            ZM011( -6) ;
         }
         pr_default.close(3);
         OnLoadActions011( ) ;
      }

      protected void OnLoadActions011( )
      {
         AV13Pgmname = "Brand";
         AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
      }

      protected void CheckExtendedTable011( )
      {
         nIsDirty_1 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV13Pgmname = "Brand";
         AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
         /* Using cursor T00015 */
         pr_default.execute(2, new Object[] {A1BrandId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            A56BrandProductQuantity = T00015_A56BrandProductQuantity[0];
            n56BrandProductQuantity = T00015_n56BrandProductQuantity[0];
            AssignAttri("", false, "A56BrandProductQuantity", StringUtil.LTrimStr( (decimal)(A56BrandProductQuantity), 4, 0));
         }
         else
         {
            nIsDirty_1 = 1;
            A56BrandProductQuantity = 0;
            n56BrandProductQuantity = false;
            AssignAttri("", false, "A56BrandProductQuantity", StringUtil.LTrimStr( (decimal)(A56BrandProductQuantity), 4, 0));
         }
         pr_default.close(2);
         if ( ! ( (DateTime.MinValue==A31BrandModifiedDate) || ( DateTimeUtil.ResetTime ( A31BrandModifiedDate ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Brand Modified Date is out of range", "OutOfRange", 1, "BRANDMODIFIEDDATE");
            AnyError = 1;
            GX_FocusControl = edtBrandModifiedDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors011( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_7( int A1BrandId )
      {
         /* Using cursor T00019 */
         pr_default.execute(4, new Object[] {A1BrandId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            A56BrandProductQuantity = T00019_A56BrandProductQuantity[0];
            n56BrandProductQuantity = T00019_n56BrandProductQuantity[0];
            AssignAttri("", false, "A56BrandProductQuantity", StringUtil.LTrimStr( (decimal)(A56BrandProductQuantity), 4, 0));
         }
         else
         {
            A56BrandProductQuantity = 0;
            n56BrandProductQuantity = false;
            AssignAttri("", false, "A56BrandProductQuantity", StringUtil.LTrimStr( (decimal)(A56BrandProductQuantity), 4, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A56BrandProductQuantity), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey011( )
      {
         /* Using cursor T000110 */
         pr_default.execute(5, new Object[] {A1BrandId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound1 = 1;
         }
         else
         {
            RcdFound1 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00013 */
         pr_default.execute(1, new Object[] {A1BrandId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM011( 6) ;
            RcdFound1 = 1;
            A1BrandId = T00013_A1BrandId[0];
            AssignAttri("", false, "A1BrandId", StringUtil.LTrimStr( (decimal)(A1BrandId), 6, 0));
            A2BrandName = T00013_A2BrandName[0];
            AssignAttri("", false, "A2BrandName", A2BrandName);
            A3BrandDescription = T00013_A3BrandDescription[0];
            n3BrandDescription = T00013_n3BrandDescription[0];
            AssignAttri("", false, "A3BrandDescription", A3BrandDescription);
            A30BrandCreatedDate = T00013_A30BrandCreatedDate[0];
            AssignAttri("", false, "A30BrandCreatedDate", context.localUtil.Format(A30BrandCreatedDate, "99/99/99"));
            A31BrandModifiedDate = T00013_A31BrandModifiedDate[0];
            n31BrandModifiedDate = T00013_n31BrandModifiedDate[0];
            AssignAttri("", false, "A31BrandModifiedDate", context.localUtil.Format(A31BrandModifiedDate, "99/99/99"));
            Z1BrandId = A1BrandId;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load011( ) ;
            if ( AnyError == 1 )
            {
               RcdFound1 = 0;
               InitializeNonKey011( ) ;
            }
            Gx_mode = sMode1;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound1 = 0;
            InitializeNonKey011( ) ;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode1;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey011( ) ;
         if ( RcdFound1 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound1 = 0;
         /* Using cursor T000111 */
         pr_default.execute(6, new Object[] {A1BrandId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T000111_A1BrandId[0] < A1BrandId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T000111_A1BrandId[0] > A1BrandId ) ) )
            {
               A1BrandId = T000111_A1BrandId[0];
               AssignAttri("", false, "A1BrandId", StringUtil.LTrimStr( (decimal)(A1BrandId), 6, 0));
               RcdFound1 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound1 = 0;
         /* Using cursor T000112 */
         pr_default.execute(7, new Object[] {A1BrandId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T000112_A1BrandId[0] > A1BrandId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T000112_A1BrandId[0] < A1BrandId ) ) )
            {
               A1BrandId = T000112_A1BrandId[0];
               AssignAttri("", false, "A1BrandId", StringUtil.LTrimStr( (decimal)(A1BrandId), 6, 0));
               RcdFound1 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey011( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtBrandName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert011( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound1 == 1 )
            {
               if ( A1BrandId != Z1BrandId )
               {
                  A1BrandId = Z1BrandId;
                  AssignAttri("", false, "A1BrandId", StringUtil.LTrimStr( (decimal)(A1BrandId), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "BRANDID");
                  AnyError = 1;
                  GX_FocusControl = edtBrandId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtBrandName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update011( ) ;
                  GX_FocusControl = edtBrandName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A1BrandId != Z1BrandId )
               {
                  /* Insert record */
                  GX_FocusControl = edtBrandName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert011( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "BRANDID");
                     AnyError = 1;
                     GX_FocusControl = edtBrandId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtBrandName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert011( ) ;
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
         if ( A1BrandId != Z1BrandId )
         {
            A1BrandId = Z1BrandId;
            AssignAttri("", false, "A1BrandId", StringUtil.LTrimStr( (decimal)(A1BrandId), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "BRANDID");
            AnyError = 1;
            GX_FocusControl = edtBrandId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtBrandName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency011( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00012 */
            pr_default.execute(0, new Object[] {A1BrandId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Brand"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z2BrandName, T00012_A2BrandName[0]) != 0 ) || ( StringUtil.StrCmp(Z3BrandDescription, T00012_A3BrandDescription[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z30BrandCreatedDate ) != DateTimeUtil.ResetTime ( T00012_A30BrandCreatedDate[0] ) ) || ( DateTimeUtil.ResetTime ( Z31BrandModifiedDate ) != DateTimeUtil.ResetTime ( T00012_A31BrandModifiedDate[0] ) ) )
            {
               if ( StringUtil.StrCmp(Z2BrandName, T00012_A2BrandName[0]) != 0 )
               {
                  GXUtil.WriteLog("brand:[seudo value changed for attri]"+"BrandName");
                  GXUtil.WriteLogRaw("Old: ",Z2BrandName);
                  GXUtil.WriteLogRaw("Current: ",T00012_A2BrandName[0]);
               }
               if ( StringUtil.StrCmp(Z3BrandDescription, T00012_A3BrandDescription[0]) != 0 )
               {
                  GXUtil.WriteLog("brand:[seudo value changed for attri]"+"BrandDescription");
                  GXUtil.WriteLogRaw("Old: ",Z3BrandDescription);
                  GXUtil.WriteLogRaw("Current: ",T00012_A3BrandDescription[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z30BrandCreatedDate ) != DateTimeUtil.ResetTime ( T00012_A30BrandCreatedDate[0] ) )
               {
                  GXUtil.WriteLog("brand:[seudo value changed for attri]"+"BrandCreatedDate");
                  GXUtil.WriteLogRaw("Old: ",Z30BrandCreatedDate);
                  GXUtil.WriteLogRaw("Current: ",T00012_A30BrandCreatedDate[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z31BrandModifiedDate ) != DateTimeUtil.ResetTime ( T00012_A31BrandModifiedDate[0] ) )
               {
                  GXUtil.WriteLog("brand:[seudo value changed for attri]"+"BrandModifiedDate");
                  GXUtil.WriteLogRaw("Old: ",Z31BrandModifiedDate);
                  GXUtil.WriteLogRaw("Current: ",T00012_A31BrandModifiedDate[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Brand"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM011( 0) ;
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000113 */
                     pr_default.execute(8, new Object[] {A2BrandName, n3BrandDescription, A3BrandDescription, A30BrandCreatedDate, n31BrandModifiedDate, A31BrandModifiedDate});
                     A1BrandId = T000113_A1BrandId[0];
                     AssignAttri("", false, "A1BrandId", StringUtil.LTrimStr( (decimal)(A1BrandId), 6, 0));
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Brand");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption010( ) ;
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
               Load011( ) ;
            }
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void Update011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000114 */
                     pr_default.execute(9, new Object[] {A2BrandName, n3BrandDescription, A3BrandDescription, A30BrandCreatedDate, n31BrandModifiedDate, A31BrandModifiedDate, A1BrandId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Brand");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Brand"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate011( ) ;
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
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void DeferredUpdate011( )
      {
      }

      protected void delete( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls011( ) ;
            AfterConfirm011( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete011( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000115 */
                  pr_default.execute(10, new Object[] {A1BrandId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("Brand");
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
         sMode1 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel011( ) ;
         Gx_mode = sMode1;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls011( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV13Pgmname = "Brand";
            AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
            /* Using cursor T000117 */
            pr_default.execute(11, new Object[] {A1BrandId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               A56BrandProductQuantity = T000117_A56BrandProductQuantity[0];
               n56BrandProductQuantity = T000117_n56BrandProductQuantity[0];
               AssignAttri("", false, "A56BrandProductQuantity", StringUtil.LTrimStr( (decimal)(A56BrandProductQuantity), 4, 0));
            }
            else
            {
               A56BrandProductQuantity = 0;
               n56BrandProductQuantity = false;
               AssignAttri("", false, "A56BrandProductQuantity", StringUtil.LTrimStr( (decimal)(A56BrandProductQuantity), 4, 0));
            }
            pr_default.close(11);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000118 */
            pr_default.execute(12, new Object[] {A1BrandId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Product"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel011( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete011( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(11);
            context.CommitDataStores("brand",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues010( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(11);
            context.RollbackDataStores("brand",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart011( )
      {
         /* Scan By routine */
         /* Using cursor T000119 */
         pr_default.execute(13);
         RcdFound1 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound1 = 1;
            A1BrandId = T000119_A1BrandId[0];
            AssignAttri("", false, "A1BrandId", StringUtil.LTrimStr( (decimal)(A1BrandId), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext011( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound1 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound1 = 1;
            A1BrandId = T000119_A1BrandId[0];
            AssignAttri("", false, "A1BrandId", StringUtil.LTrimStr( (decimal)(A1BrandId), 6, 0));
         }
      }

      protected void ScanEnd011( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm011( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert011( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate011( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete011( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete011( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate011( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes011( )
      {
         edtBrandId_Enabled = 0;
         AssignProp("", false, edtBrandId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBrandId_Enabled), 5, 0), true);
         edtBrandName_Enabled = 0;
         AssignProp("", false, edtBrandName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBrandName_Enabled), 5, 0), true);
         edtBrandDescription_Enabled = 0;
         AssignProp("", false, edtBrandDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBrandDescription_Enabled), 5, 0), true);
         edtBrandCreatedDate_Enabled = 0;
         AssignProp("", false, edtBrandCreatedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBrandCreatedDate_Enabled), 5, 0), true);
         edtBrandModifiedDate_Enabled = 0;
         AssignProp("", false, edtBrandModifiedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBrandModifiedDate_Enabled), 5, 0), true);
         edtBrandProductQuantity_Enabled = 0;
         AssignProp("", false, edtBrandProductQuantity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBrandProductQuantity_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes011( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues010( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("brand.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7BrandId,6,0))}, new string[] {"Gx_mode","BrandId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Brand");
         forbiddenHiddens.Add("BrandId", context.localUtil.Format( (decimal)(A1BrandId), "ZZZZZ9"));
         forbiddenHiddens.Add("BrandCreatedDate", context.localUtil.Format(A30BrandCreatedDate, "99/99/99"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("brand:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z1BrandId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1BrandId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2BrandName", Z2BrandName);
         GxWebStd.gx_hidden_field( context, "Z3BrandDescription", Z3BrandDescription);
         GxWebStd.gx_hidden_field( context, "Z30BrandCreatedDate", context.localUtil.DToC( Z30BrandCreatedDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z31BrandModifiedDate", context.localUtil.DToC( Z31BrandModifiedDate, 0, "/"));
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
         GxWebStd.gx_hidden_field( context, "vBRANDID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7BrandId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vBRANDID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7BrandId), "ZZZZZ9"), context));
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
         return formatLink("brand.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7BrandId,6,0))}, new string[] {"Gx_mode","BrandId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Brand" ;
      }

      public override string GetPgmdesc( )
      {
         return "Brand" ;
      }

      protected void InitializeNonKey011( )
      {
         A2BrandName = "";
         AssignAttri("", false, "A2BrandName", A2BrandName);
         A3BrandDescription = "";
         n3BrandDescription = false;
         AssignAttri("", false, "A3BrandDescription", A3BrandDescription);
         n3BrandDescription = (String.IsNullOrEmpty(StringUtil.RTrim( A3BrandDescription)) ? true : false);
         A31BrandModifiedDate = DateTime.MinValue;
         n31BrandModifiedDate = false;
         AssignAttri("", false, "A31BrandModifiedDate", context.localUtil.Format(A31BrandModifiedDate, "99/99/99"));
         n31BrandModifiedDate = ((DateTime.MinValue==A31BrandModifiedDate) ? true : false);
         A56BrandProductQuantity = 0;
         n56BrandProductQuantity = false;
         AssignAttri("", false, "A56BrandProductQuantity", StringUtil.LTrimStr( (decimal)(A56BrandProductQuantity), 4, 0));
         A30BrandCreatedDate = Gx_date;
         AssignAttri("", false, "A30BrandCreatedDate", context.localUtil.Format(A30BrandCreatedDate, "99/99/99"));
         Z2BrandName = "";
         Z3BrandDescription = "";
         Z30BrandCreatedDate = DateTime.MinValue;
         Z31BrandModifiedDate = DateTime.MinValue;
      }

      protected void InitAll011( )
      {
         A1BrandId = 0;
         AssignAttri("", false, "A1BrandId", StringUtil.LTrimStr( (decimal)(A1BrandId), 6, 0));
         InitializeNonKey011( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A30BrandCreatedDate = i30BrandCreatedDate;
         AssignAttri("", false, "A30BrandCreatedDate", context.localUtil.Format(A30BrandCreatedDate, "99/99/99"));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202311222273033", true, true);
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
         context.AddJavascriptSource("brand.js", "?202311222273035", false, true);
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
         edtBrandId_Internalname = "BRANDID";
         edtBrandName_Internalname = "BRANDNAME";
         edtBrandDescription_Internalname = "BRANDDESCRIPTION";
         edtBrandCreatedDate_Internalname = "BRANDCREATEDDATE";
         edtBrandModifiedDate_Internalname = "BRANDMODIFIEDDATE";
         edtBrandProductQuantity_Internalname = "BRANDPRODUCTQUANTITY";
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
         Form.Caption = "Brand";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirm";
         bttBtn_enter_Caption = "Confirm";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtBrandProductQuantity_Jsonclick = "";
         edtBrandProductQuantity_Enabled = 0;
         edtBrandModifiedDate_Jsonclick = "";
         edtBrandModifiedDate_Enabled = 1;
         edtBrandCreatedDate_Jsonclick = "";
         edtBrandCreatedDate_Enabled = 0;
         edtBrandDescription_Enabled = 1;
         edtBrandName_Jsonclick = "";
         edtBrandName_Enabled = 1;
         edtBrandId_Jsonclick = "";
         edtBrandId_Enabled = 0;
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

      public void Valid_Brandid( )
      {
         n56BrandProductQuantity = false;
         /* Using cursor T000117 */
         pr_default.execute(11, new Object[] {A1BrandId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            A56BrandProductQuantity = T000117_A56BrandProductQuantity[0];
            n56BrandProductQuantity = T000117_n56BrandProductQuantity[0];
         }
         else
         {
            A56BrandProductQuantity = 0;
            n56BrandProductQuantity = false;
         }
         pr_default.close(11);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A56BrandProductQuantity", StringUtil.LTrim( StringUtil.NToC( (decimal)(A56BrandProductQuantity), 4, 0, ".", "")));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7BrandId',fld:'vBRANDID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7BrandId',fld:'vBRANDID',pic:'ZZZZZ9',hsh:true},{av:'A1BrandId',fld:'BRANDID',pic:'ZZZZZ9'},{av:'A30BrandCreatedDate',fld:'BRANDCREATEDDATE',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12012',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_BRANDID","{handler:'Valid_Brandid',iparms:[{av:'A1BrandId',fld:'BRANDID',pic:'ZZZZZ9'},{av:'A56BrandProductQuantity',fld:'BRANDPRODUCTQUANTITY',pic:'ZZZ9'}]");
         setEventMetadata("VALID_BRANDID",",oparms:[{av:'A56BrandProductQuantity',fld:'BRANDPRODUCTQUANTITY',pic:'ZZZ9'}]}");
         setEventMetadata("VALID_BRANDMODIFIEDDATE","{handler:'Valid_Brandmodifieddate',iparms:[]");
         setEventMetadata("VALID_BRANDMODIFIEDDATE",",oparms:[]}");
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
         pr_default.close(11);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z2BrandName = "";
         Z3BrandDescription = "";
         Z30BrandCreatedDate = DateTime.MinValue;
         Z31BrandModifiedDate = DateTime.MinValue;
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
         A2BrandName = "";
         A3BrandDescription = "";
         A30BrandCreatedDate = DateTime.MinValue;
         A31BrandModifiedDate = DateTime.MinValue;
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_date = DateTime.MinValue;
         AV13Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode1 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         T00015_A56BrandProductQuantity = new short[1] ;
         T00015_n56BrandProductQuantity = new bool[] {false} ;
         T00017_A1BrandId = new int[1] ;
         T00017_A2BrandName = new string[] {""} ;
         T00017_A3BrandDescription = new string[] {""} ;
         T00017_n3BrandDescription = new bool[] {false} ;
         T00017_A30BrandCreatedDate = new DateTime[] {DateTime.MinValue} ;
         T00017_A31BrandModifiedDate = new DateTime[] {DateTime.MinValue} ;
         T00017_n31BrandModifiedDate = new bool[] {false} ;
         T00017_A56BrandProductQuantity = new short[1] ;
         T00017_n56BrandProductQuantity = new bool[] {false} ;
         T00019_A56BrandProductQuantity = new short[1] ;
         T00019_n56BrandProductQuantity = new bool[] {false} ;
         T000110_A1BrandId = new int[1] ;
         T00013_A1BrandId = new int[1] ;
         T00013_A2BrandName = new string[] {""} ;
         T00013_A3BrandDescription = new string[] {""} ;
         T00013_n3BrandDescription = new bool[] {false} ;
         T00013_A30BrandCreatedDate = new DateTime[] {DateTime.MinValue} ;
         T00013_A31BrandModifiedDate = new DateTime[] {DateTime.MinValue} ;
         T00013_n31BrandModifiedDate = new bool[] {false} ;
         T000111_A1BrandId = new int[1] ;
         T000112_A1BrandId = new int[1] ;
         T00012_A1BrandId = new int[1] ;
         T00012_A2BrandName = new string[] {""} ;
         T00012_A3BrandDescription = new string[] {""} ;
         T00012_n3BrandDescription = new bool[] {false} ;
         T00012_A30BrandCreatedDate = new DateTime[] {DateTime.MinValue} ;
         T00012_A31BrandModifiedDate = new DateTime[] {DateTime.MinValue} ;
         T00012_n31BrandModifiedDate = new bool[] {false} ;
         T000113_A1BrandId = new int[1] ;
         T000117_A56BrandProductQuantity = new short[1] ;
         T000117_n56BrandProductQuantity = new bool[] {false} ;
         T000118_A15ProductId = new int[1] ;
         T000119_A1BrandId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i30BrandCreatedDate = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.brand__default(),
            new Object[][] {
                new Object[] {
               T00012_A1BrandId, T00012_A2BrandName, T00012_A3BrandDescription, T00012_n3BrandDescription, T00012_A30BrandCreatedDate, T00012_A31BrandModifiedDate, T00012_n31BrandModifiedDate
               }
               , new Object[] {
               T00013_A1BrandId, T00013_A2BrandName, T00013_A3BrandDescription, T00013_n3BrandDescription, T00013_A30BrandCreatedDate, T00013_A31BrandModifiedDate, T00013_n31BrandModifiedDate
               }
               , new Object[] {
               T00015_A56BrandProductQuantity, T00015_n56BrandProductQuantity
               }
               , new Object[] {
               T00017_A1BrandId, T00017_A2BrandName, T00017_A3BrandDescription, T00017_n3BrandDescription, T00017_A30BrandCreatedDate, T00017_A31BrandModifiedDate, T00017_n31BrandModifiedDate, T00017_A56BrandProductQuantity, T00017_n56BrandProductQuantity
               }
               , new Object[] {
               T00019_A56BrandProductQuantity, T00019_n56BrandProductQuantity
               }
               , new Object[] {
               T000110_A1BrandId
               }
               , new Object[] {
               T000111_A1BrandId
               }
               , new Object[] {
               T000112_A1BrandId
               }
               , new Object[] {
               T000113_A1BrandId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000117_A56BrandProductQuantity, T000117_n56BrandProductQuantity
               }
               , new Object[] {
               T000118_A15ProductId
               }
               , new Object[] {
               T000119_A1BrandId
               }
            }
         );
         AV13Pgmname = "Brand";
         Z30BrandCreatedDate = DateTime.MinValue;
         A30BrandCreatedDate = DateTime.MinValue;
         i30BrandCreatedDate = DateTime.MinValue;
         Gx_date = DateTimeUtil.Today( context);
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A56BrandProductQuantity ;
      private short Gx_BScreen ;
      private short RcdFound1 ;
      private short GX_JID ;
      private short Z56BrandProductQuantity ;
      private short nIsDirty_1 ;
      private short gxajaxcallmode ;
      private int wcpOAV7BrandId ;
      private int Z1BrandId ;
      private int A1BrandId ;
      private int AV7BrandId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtBrandId_Enabled ;
      private int edtBrandName_Enabled ;
      private int edtBrandDescription_Enabled ;
      private int edtBrandCreatedDate_Enabled ;
      private int edtBrandModifiedDate_Enabled ;
      private int edtBrandProductQuantity_Enabled ;
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
      private string edtBrandName_Internalname ;
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
      private string edtBrandId_Internalname ;
      private string edtBrandId_Jsonclick ;
      private string edtBrandName_Jsonclick ;
      private string edtBrandDescription_Internalname ;
      private string edtBrandCreatedDate_Internalname ;
      private string edtBrandCreatedDate_Jsonclick ;
      private string edtBrandModifiedDate_Internalname ;
      private string edtBrandModifiedDate_Jsonclick ;
      private string edtBrandProductQuantity_Internalname ;
      private string edtBrandProductQuantity_Jsonclick ;
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
      private string sMode1 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z30BrandCreatedDate ;
      private DateTime Z31BrandModifiedDate ;
      private DateTime A30BrandCreatedDate ;
      private DateTime A31BrandModifiedDate ;
      private DateTime Gx_date ;
      private DateTime i30BrandCreatedDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n3BrandDescription ;
      private bool n31BrandModifiedDate ;
      private bool n56BrandProductQuantity ;
      private bool returnInSub ;
      private string Z2BrandName ;
      private string Z3BrandDescription ;
      private string A2BrandName ;
      private string A3BrandDescription ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T00015_A56BrandProductQuantity ;
      private bool[] T00015_n56BrandProductQuantity ;
      private int[] T00017_A1BrandId ;
      private string[] T00017_A2BrandName ;
      private string[] T00017_A3BrandDescription ;
      private bool[] T00017_n3BrandDescription ;
      private DateTime[] T00017_A30BrandCreatedDate ;
      private DateTime[] T00017_A31BrandModifiedDate ;
      private bool[] T00017_n31BrandModifiedDate ;
      private short[] T00017_A56BrandProductQuantity ;
      private bool[] T00017_n56BrandProductQuantity ;
      private short[] T00019_A56BrandProductQuantity ;
      private bool[] T00019_n56BrandProductQuantity ;
      private int[] T000110_A1BrandId ;
      private int[] T00013_A1BrandId ;
      private string[] T00013_A2BrandName ;
      private string[] T00013_A3BrandDescription ;
      private bool[] T00013_n3BrandDescription ;
      private DateTime[] T00013_A30BrandCreatedDate ;
      private DateTime[] T00013_A31BrandModifiedDate ;
      private bool[] T00013_n31BrandModifiedDate ;
      private int[] T000111_A1BrandId ;
      private int[] T000112_A1BrandId ;
      private int[] T00012_A1BrandId ;
      private string[] T00012_A2BrandName ;
      private string[] T00012_A3BrandDescription ;
      private bool[] T00012_n3BrandDescription ;
      private DateTime[] T00012_A30BrandCreatedDate ;
      private DateTime[] T00012_A31BrandModifiedDate ;
      private bool[] T00012_n31BrandModifiedDate ;
      private int[] T000113_A1BrandId ;
      private short[] T000117_A56BrandProductQuantity ;
      private bool[] T000117_n56BrandProductQuantity ;
      private int[] T000118_A15ProductId ;
      private int[] T000119_A1BrandId ;
      private GXWebForm Form ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
   }

   public class brand__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00017;
          prmT00017 = new Object[] {
          new ParDef("@BrandId",GXType.Int32,6,0)
          };
          Object[] prmT00015;
          prmT00015 = new Object[] {
          new ParDef("@BrandId",GXType.Int32,6,0)
          };
          Object[] prmT00019;
          prmT00019 = new Object[] {
          new ParDef("@BrandId",GXType.Int32,6,0)
          };
          Object[] prmT000110;
          prmT000110 = new Object[] {
          new ParDef("@BrandId",GXType.Int32,6,0)
          };
          Object[] prmT00013;
          prmT00013 = new Object[] {
          new ParDef("@BrandId",GXType.Int32,6,0)
          };
          Object[] prmT000111;
          prmT000111 = new Object[] {
          new ParDef("@BrandId",GXType.Int32,6,0)
          };
          Object[] prmT000112;
          prmT000112 = new Object[] {
          new ParDef("@BrandId",GXType.Int32,6,0)
          };
          Object[] prmT00012;
          prmT00012 = new Object[] {
          new ParDef("@BrandId",GXType.Int32,6,0)
          };
          Object[] prmT000113;
          prmT000113 = new Object[] {
          new ParDef("@BrandName",GXType.NVarChar,60,0) ,
          new ParDef("@BrandDescription",GXType.NVarChar,200,0){Nullable=true} ,
          new ParDef("@BrandCreatedDate",GXType.Date,8,0) ,
          new ParDef("@BrandModifiedDate",GXType.Date,8,0){Nullable=true}
          };
          Object[] prmT000114;
          prmT000114 = new Object[] {
          new ParDef("@BrandName",GXType.NVarChar,60,0) ,
          new ParDef("@BrandDescription",GXType.NVarChar,200,0){Nullable=true} ,
          new ParDef("@BrandCreatedDate",GXType.Date,8,0) ,
          new ParDef("@BrandModifiedDate",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@BrandId",GXType.Int32,6,0)
          };
          Object[] prmT000115;
          prmT000115 = new Object[] {
          new ParDef("@BrandId",GXType.Int32,6,0)
          };
          Object[] prmT000118;
          prmT000118 = new Object[] {
          new ParDef("@BrandId",GXType.Int32,6,0)
          };
          Object[] prmT000119;
          prmT000119 = new Object[] {
          };
          Object[] prmT000117;
          prmT000117 = new Object[] {
          new ParDef("@BrandId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00012", "SELECT [BrandId], [BrandName], [BrandDescription], [BrandCreatedDate], [BrandModifiedDate] FROM [Brand] WITH (UPDLOCK) WHERE [BrandId] = @BrandId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00012,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00013", "SELECT [BrandId], [BrandName], [BrandDescription], [BrandCreatedDate], [BrandModifiedDate] FROM [Brand] WHERE [BrandId] = @BrandId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00013,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00015", "SELECT COALESCE( T1.[BrandProductQuantity], 0) AS BrandProductQuantity FROM (SELECT COUNT(*) AS BrandProductQuantity, [BrandId] FROM [Product] GROUP BY [BrandId] ) T1 WHERE T1.[BrandId] = @BrandId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00015,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00017", "SELECT TM1.[BrandId], TM1.[BrandName], TM1.[BrandDescription], TM1.[BrandCreatedDate], TM1.[BrandModifiedDate], COALESCE( T2.[BrandProductQuantity], 0) AS BrandProductQuantity FROM ([Brand] TM1 LEFT JOIN (SELECT COUNT(*) AS BrandProductQuantity, [BrandId] FROM [Product] GROUP BY [BrandId] ) T2 ON T2.[BrandId] = TM1.[BrandId]) WHERE TM1.[BrandId] = @BrandId ORDER BY TM1.[BrandId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00017,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00019", "SELECT COALESCE( T1.[BrandProductQuantity], 0) AS BrandProductQuantity FROM (SELECT COUNT(*) AS BrandProductQuantity, [BrandId] FROM [Product] GROUP BY [BrandId] ) T1 WHERE T1.[BrandId] = @BrandId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00019,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000110", "SELECT [BrandId] FROM [Brand] WHERE [BrandId] = @BrandId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000110,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000111", "SELECT TOP 1 [BrandId] FROM [Brand] WHERE ( [BrandId] > @BrandId) ORDER BY [BrandId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000111,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000112", "SELECT TOP 1 [BrandId] FROM [Brand] WHERE ( [BrandId] < @BrandId) ORDER BY [BrandId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000112,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000113", "INSERT INTO [Brand]([BrandName], [BrandDescription], [BrandCreatedDate], [BrandModifiedDate]) VALUES(@BrandName, @BrandDescription, @BrandCreatedDate, @BrandModifiedDate); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000113,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000114", "UPDATE [Brand] SET [BrandName]=@BrandName, [BrandDescription]=@BrandDescription, [BrandCreatedDate]=@BrandCreatedDate, [BrandModifiedDate]=@BrandModifiedDate  WHERE [BrandId] = @BrandId", GxErrorMask.GX_NOMASK,prmT000114)
             ,new CursorDef("T000115", "DELETE FROM [Brand]  WHERE [BrandId] = @BrandId", GxErrorMask.GX_NOMASK,prmT000115)
             ,new CursorDef("T000117", "SELECT COALESCE( T1.[BrandProductQuantity], 0) AS BrandProductQuantity FROM (SELECT COUNT(*) AS BrandProductQuantity, [BrandId] FROM [Product] GROUP BY [BrandId] ) T1 WHERE T1.[BrandId] = @BrandId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000117,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000118", "SELECT TOP 1 [ProductId] FROM [Product] WHERE [BrandId] = @BrandId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000118,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000119", "SELECT [BrandId] FROM [Brand] ORDER BY [BrandId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000119,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((short[]) buf[7])[0] = rslt.getShort(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
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
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
