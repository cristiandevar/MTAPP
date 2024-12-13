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
   public class paymentmethod : GXDataArea
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
               AV7PaymentMethodId = (int)(Math.Round(NumberUtil.Val( GetPar( "PaymentMethodId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7PaymentMethodId", StringUtil.LTrimStr( (decimal)(AV7PaymentMethodId), 6, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vPAYMENTMETHODID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7PaymentMethodId), "ZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Payment Method of Sale", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPaymentMethodDescription_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("mtaKB", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public paymentmethod( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public paymentmethod( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_PaymentMethodId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7PaymentMethodId = aP1_PaymentMethodId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkPaymentMethodActive = new GXCheckbox();
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
         A117PaymentMethodActive = StringUtil.StrToBool( StringUtil.BoolToStr( A117PaymentMethodActive));
         AssignAttri("", false, "A117PaymentMethodActive", A117PaymentMethodActive);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Payment Method of Sale", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_PaymentMethod.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_PaymentMethod.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_PaymentMethod.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_PaymentMethod.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_PaymentMethod.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_PaymentMethod.htm");
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
         GxWebStd.gx_div_start( context, "", edtPaymentMethodId_Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPaymentMethodId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPaymentMethodId_Internalname, "Method Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPaymentMethodId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A115PaymentMethodId), 6, 0, ".", "")), StringUtil.LTrim( ((edtPaymentMethodId_Enabled!=0) ? context.localUtil.Format( (decimal)(A115PaymentMethodId), "ZZZZZ9") : context.localUtil.Format( (decimal)(A115PaymentMethodId), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaymentMethodId_Jsonclick, 0, "Attribute", "", "", "", "", edtPaymentMethodId_Visible, edtPaymentMethodId_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_PaymentMethod.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPaymentMethodDescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPaymentMethodDescription_Internalname, "Method", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtPaymentMethodDescription_Internalname, A116PaymentMethodDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", 0, 1, edtPaymentMethodDescription_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "GeneXusUnanimo\\Description", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_PaymentMethod.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkPaymentMethodActive_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkPaymentMethodActive_Internalname, "Active", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkPaymentMethodActive_Internalname, StringUtil.BoolToStr( A117PaymentMethodActive), "", "Active", 1, chkPaymentMethodActive.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(44, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,44);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPaymentMethodDiscount_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPaymentMethodDiscount_Internalname, "Discount", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPaymentMethodDiscount_Internalname, StringUtil.LTrim( StringUtil.NToC( A129PaymentMethodDiscount, 8, 2, ".", "")), StringUtil.LTrim( ((edtPaymentMethodDiscount_Enabled!=0) ? context.localUtil.Format( A129PaymentMethodDiscount, "ZZZZ9.99") : context.localUtil.Format( A129PaymentMethodDiscount, "ZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaymentMethodDiscount_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaymentMethodDiscount_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "Percentage", "right", false, "", "HLP_PaymentMethod.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPaymentMethodRecarge_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPaymentMethodRecarge_Internalname, "Recharge", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPaymentMethodRecarge_Internalname, StringUtil.LTrim( StringUtil.NToC( A130PaymentMethodRecarge, 8, 2, ".", "")), StringUtil.LTrim( ((edtPaymentMethodRecarge_Enabled!=0) ? context.localUtil.Format( A130PaymentMethodRecarge, "ZZZZ9.99") : context.localUtil.Format( A130PaymentMethodRecarge, "ZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaymentMethodRecarge_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaymentMethodRecarge_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "Percentage", "right", false, "", "HLP_PaymentMethod.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_PaymentMethod.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_PaymentMethod.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_PaymentMethod.htm");
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
         E110E2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z115PaymentMethodId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z115PaymentMethodId"), ".", ","), 18, MidpointRounding.ToEven));
               Z116PaymentMethodDescription = cgiGet( "Z116PaymentMethodDescription");
               Z117PaymentMethodActive = StringUtil.StrToBool( cgiGet( "Z117PaymentMethodActive"));
               Z129PaymentMethodDiscount = context.localUtil.CToN( cgiGet( "Z129PaymentMethodDiscount"), ".", ",");
               Z130PaymentMethodRecarge = context.localUtil.CToN( cgiGet( "Z130PaymentMethodRecarge"), ".", ",");
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7PaymentMethodId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vPAYMENTMETHODID"), ".", ","), 18, MidpointRounding.ToEven));
               AV11Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A115PaymentMethodId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPaymentMethodId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               n115PaymentMethodId = false;
               AssignAttri("", false, "A115PaymentMethodId", StringUtil.LTrimStr( (decimal)(A115PaymentMethodId), 6, 0));
               A116PaymentMethodDescription = cgiGet( edtPaymentMethodDescription_Internalname);
               AssignAttri("", false, "A116PaymentMethodDescription", A116PaymentMethodDescription);
               A117PaymentMethodActive = StringUtil.StrToBool( cgiGet( chkPaymentMethodActive_Internalname));
               AssignAttri("", false, "A117PaymentMethodActive", A117PaymentMethodActive);
               if ( ( ( context.localUtil.CToN( cgiGet( edtPaymentMethodDiscount_Internalname), ".", ",") < -9999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtPaymentMethodDiscount_Internalname), ".", ",") > 99999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PAYMENTMETHODDISCOUNT");
                  AnyError = 1;
                  GX_FocusControl = edtPaymentMethodDiscount_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A129PaymentMethodDiscount = 0;
                  AssignAttri("", false, "A129PaymentMethodDiscount", StringUtil.LTrimStr( A129PaymentMethodDiscount, 8, 2));
               }
               else
               {
                  A129PaymentMethodDiscount = context.localUtil.CToN( cgiGet( edtPaymentMethodDiscount_Internalname), ".", ",");
                  AssignAttri("", false, "A129PaymentMethodDiscount", StringUtil.LTrimStr( A129PaymentMethodDiscount, 8, 2));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtPaymentMethodRecarge_Internalname), ".", ",") < -9999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtPaymentMethodRecarge_Internalname), ".", ",") > 99999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PAYMENTMETHODRECARGE");
                  AnyError = 1;
                  GX_FocusControl = edtPaymentMethodRecarge_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A130PaymentMethodRecarge = 0;
                  AssignAttri("", false, "A130PaymentMethodRecarge", StringUtil.LTrimStr( A130PaymentMethodRecarge, 8, 2));
               }
               else
               {
                  A130PaymentMethodRecarge = context.localUtil.CToN( cgiGet( edtPaymentMethodRecarge_Internalname), ".", ",");
                  AssignAttri("", false, "A130PaymentMethodRecarge", StringUtil.LTrimStr( A130PaymentMethodRecarge, 8, 2));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"PaymentMethod");
               A115PaymentMethodId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPaymentMethodId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               n115PaymentMethodId = false;
               AssignAttri("", false, "A115PaymentMethodId", StringUtil.LTrimStr( (decimal)(A115PaymentMethodId), 6, 0));
               forbiddenHiddens.Add("PaymentMethodId", context.localUtil.Format( (decimal)(A115PaymentMethodId), "ZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A115PaymentMethodId != Z115PaymentMethodId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("paymentmethod:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A115PaymentMethodId = (int)(Math.Round(NumberUtil.Val( GetPar( "PaymentMethodId"), "."), 18, MidpointRounding.ToEven));
                  n115PaymentMethodId = false;
                  AssignAttri("", false, "A115PaymentMethodId", StringUtil.LTrimStr( (decimal)(A115PaymentMethodId), 6, 0));
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
                     sMode20 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode20;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound20 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0E0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "PAYMENTMETHODID");
                        AnyError = 1;
                        GX_FocusControl = edtPaymentMethodId_Internalname;
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
                           E110E2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120E2 ();
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
            E120E2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0E20( ) ;
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
            DisableAttributes0E20( ) ;
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

      protected void CONFIRM_0E0( )
      {
         BeforeValidate0E20( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0E20( ) ;
            }
            else
            {
               CheckExtendedTable0E20( ) ;
               CloseExtendedTableCursors0E20( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0E0( )
      {
      }

      protected void E110E2( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV11Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV11Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         edtPaymentMethodId_Visible = 0;
         AssignProp("", false, edtPaymentMethodId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPaymentMethodId_Visible), 5, 0), true);
      }

      protected void E120E2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwpaymentmethod.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0E20( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z116PaymentMethodDescription = T000E3_A116PaymentMethodDescription[0];
               Z117PaymentMethodActive = T000E3_A117PaymentMethodActive[0];
               Z129PaymentMethodDiscount = T000E3_A129PaymentMethodDiscount[0];
               Z130PaymentMethodRecarge = T000E3_A130PaymentMethodRecarge[0];
            }
            else
            {
               Z116PaymentMethodDescription = A116PaymentMethodDescription;
               Z117PaymentMethodActive = A117PaymentMethodActive;
               Z129PaymentMethodDiscount = A129PaymentMethodDiscount;
               Z130PaymentMethodRecarge = A130PaymentMethodRecarge;
            }
         }
         if ( GX_JID == -5 )
         {
            Z115PaymentMethodId = A115PaymentMethodId;
            Z116PaymentMethodDescription = A116PaymentMethodDescription;
            Z117PaymentMethodActive = A117PaymentMethodActive;
            Z129PaymentMethodDiscount = A129PaymentMethodDiscount;
            Z130PaymentMethodRecarge = A130PaymentMethodRecarge;
         }
      }

      protected void standaloneNotModal( )
      {
         edtPaymentMethodId_Enabled = 0;
         AssignProp("", false, edtPaymentMethodId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaymentMethodId_Enabled), 5, 0), true);
         edtPaymentMethodId_Enabled = 0;
         AssignProp("", false, edtPaymentMethodId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaymentMethodId_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7PaymentMethodId) )
         {
            A115PaymentMethodId = AV7PaymentMethodId;
            n115PaymentMethodId = false;
            AssignAttri("", false, "A115PaymentMethodId", StringUtil.LTrimStr( (decimal)(A115PaymentMethodId), 6, 0));
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

      protected void Load0E20( )
      {
         /* Using cursor T000E4 */
         pr_default.execute(2, new Object[] {n115PaymentMethodId, A115PaymentMethodId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound20 = 1;
            A116PaymentMethodDescription = T000E4_A116PaymentMethodDescription[0];
            AssignAttri("", false, "A116PaymentMethodDescription", A116PaymentMethodDescription);
            A117PaymentMethodActive = T000E4_A117PaymentMethodActive[0];
            AssignAttri("", false, "A117PaymentMethodActive", A117PaymentMethodActive);
            A129PaymentMethodDiscount = T000E4_A129PaymentMethodDiscount[0];
            AssignAttri("", false, "A129PaymentMethodDiscount", StringUtil.LTrimStr( A129PaymentMethodDiscount, 8, 2));
            A130PaymentMethodRecarge = T000E4_A130PaymentMethodRecarge[0];
            AssignAttri("", false, "A130PaymentMethodRecarge", StringUtil.LTrimStr( A130PaymentMethodRecarge, 8, 2));
            ZM0E20( -5) ;
         }
         pr_default.close(2);
         OnLoadActions0E20( ) ;
      }

      protected void OnLoadActions0E20( )
      {
         AV11Pgmname = "PaymentMethod";
         AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
      }

      protected void CheckExtendedTable0E20( )
      {
         nIsDirty_20 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV11Pgmname = "PaymentMethod";
         AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
         if ( ! ( ( ( A129PaymentMethodDiscount >= Convert.ToDecimal( -999 )) && ( A129PaymentMethodDiscount <= Convert.ToDecimal( 999 )) ) ) )
         {
            GX_msglist.addItem("Field Payment Method Discount is out of range", "OutOfRange", 1, "PAYMENTMETHODDISCOUNT");
            AnyError = 1;
            GX_FocusControl = edtPaymentMethodDiscount_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( ( A130PaymentMethodRecarge >= Convert.ToDecimal( -999 )) && ( A130PaymentMethodRecarge <= Convert.ToDecimal( 999 )) ) ) )
         {
            GX_msglist.addItem("Field Payment Method Recarge is out of range", "OutOfRange", 1, "PAYMENTMETHODRECARGE");
            AnyError = 1;
            GX_FocusControl = edtPaymentMethodRecarge_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0E20( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0E20( )
      {
         /* Using cursor T000E5 */
         pr_default.execute(3, new Object[] {n115PaymentMethodId, A115PaymentMethodId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound20 = 1;
         }
         else
         {
            RcdFound20 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000E3 */
         pr_default.execute(1, new Object[] {n115PaymentMethodId, A115PaymentMethodId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0E20( 5) ;
            RcdFound20 = 1;
            A115PaymentMethodId = T000E3_A115PaymentMethodId[0];
            n115PaymentMethodId = T000E3_n115PaymentMethodId[0];
            AssignAttri("", false, "A115PaymentMethodId", StringUtil.LTrimStr( (decimal)(A115PaymentMethodId), 6, 0));
            A116PaymentMethodDescription = T000E3_A116PaymentMethodDescription[0];
            AssignAttri("", false, "A116PaymentMethodDescription", A116PaymentMethodDescription);
            A117PaymentMethodActive = T000E3_A117PaymentMethodActive[0];
            AssignAttri("", false, "A117PaymentMethodActive", A117PaymentMethodActive);
            A129PaymentMethodDiscount = T000E3_A129PaymentMethodDiscount[0];
            AssignAttri("", false, "A129PaymentMethodDiscount", StringUtil.LTrimStr( A129PaymentMethodDiscount, 8, 2));
            A130PaymentMethodRecarge = T000E3_A130PaymentMethodRecarge[0];
            AssignAttri("", false, "A130PaymentMethodRecarge", StringUtil.LTrimStr( A130PaymentMethodRecarge, 8, 2));
            Z115PaymentMethodId = A115PaymentMethodId;
            sMode20 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0E20( ) ;
            if ( AnyError == 1 )
            {
               RcdFound20 = 0;
               InitializeNonKey0E20( ) ;
            }
            Gx_mode = sMode20;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound20 = 0;
            InitializeNonKey0E20( ) ;
            sMode20 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode20;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0E20( ) ;
         if ( RcdFound20 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound20 = 0;
         /* Using cursor T000E6 */
         pr_default.execute(4, new Object[] {n115PaymentMethodId, A115PaymentMethodId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T000E6_A115PaymentMethodId[0] < A115PaymentMethodId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T000E6_A115PaymentMethodId[0] > A115PaymentMethodId ) ) )
            {
               A115PaymentMethodId = T000E6_A115PaymentMethodId[0];
               n115PaymentMethodId = T000E6_n115PaymentMethodId[0];
               AssignAttri("", false, "A115PaymentMethodId", StringUtil.LTrimStr( (decimal)(A115PaymentMethodId), 6, 0));
               RcdFound20 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound20 = 0;
         /* Using cursor T000E7 */
         pr_default.execute(5, new Object[] {n115PaymentMethodId, A115PaymentMethodId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T000E7_A115PaymentMethodId[0] > A115PaymentMethodId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T000E7_A115PaymentMethodId[0] < A115PaymentMethodId ) ) )
            {
               A115PaymentMethodId = T000E7_A115PaymentMethodId[0];
               n115PaymentMethodId = T000E7_n115PaymentMethodId[0];
               AssignAttri("", false, "A115PaymentMethodId", StringUtil.LTrimStr( (decimal)(A115PaymentMethodId), 6, 0));
               RcdFound20 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0E20( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPaymentMethodDescription_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0E20( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound20 == 1 )
            {
               if ( A115PaymentMethodId != Z115PaymentMethodId )
               {
                  A115PaymentMethodId = Z115PaymentMethodId;
                  n115PaymentMethodId = false;
                  AssignAttri("", false, "A115PaymentMethodId", StringUtil.LTrimStr( (decimal)(A115PaymentMethodId), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PAYMENTMETHODID");
                  AnyError = 1;
                  GX_FocusControl = edtPaymentMethodId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPaymentMethodDescription_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0E20( ) ;
                  GX_FocusControl = edtPaymentMethodDescription_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A115PaymentMethodId != Z115PaymentMethodId )
               {
                  /* Insert record */
                  GX_FocusControl = edtPaymentMethodDescription_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0E20( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PAYMENTMETHODID");
                     AnyError = 1;
                     GX_FocusControl = edtPaymentMethodId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtPaymentMethodDescription_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0E20( ) ;
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
         if ( A115PaymentMethodId != Z115PaymentMethodId )
         {
            A115PaymentMethodId = Z115PaymentMethodId;
            n115PaymentMethodId = false;
            AssignAttri("", false, "A115PaymentMethodId", StringUtil.LTrimStr( (decimal)(A115PaymentMethodId), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PAYMENTMETHODID");
            AnyError = 1;
            GX_FocusControl = edtPaymentMethodId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPaymentMethodDescription_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0E20( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000E2 */
            pr_default.execute(0, new Object[] {n115PaymentMethodId, A115PaymentMethodId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PaymentMethod"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z116PaymentMethodDescription, T000E2_A116PaymentMethodDescription[0]) != 0 ) || ( Z117PaymentMethodActive != T000E2_A117PaymentMethodActive[0] ) || ( Z129PaymentMethodDiscount != T000E2_A129PaymentMethodDiscount[0] ) || ( Z130PaymentMethodRecarge != T000E2_A130PaymentMethodRecarge[0] ) )
            {
               if ( StringUtil.StrCmp(Z116PaymentMethodDescription, T000E2_A116PaymentMethodDescription[0]) != 0 )
               {
                  GXUtil.WriteLog("paymentmethod:[seudo value changed for attri]"+"PaymentMethodDescription");
                  GXUtil.WriteLogRaw("Old: ",Z116PaymentMethodDescription);
                  GXUtil.WriteLogRaw("Current: ",T000E2_A116PaymentMethodDescription[0]);
               }
               if ( Z117PaymentMethodActive != T000E2_A117PaymentMethodActive[0] )
               {
                  GXUtil.WriteLog("paymentmethod:[seudo value changed for attri]"+"PaymentMethodActive");
                  GXUtil.WriteLogRaw("Old: ",Z117PaymentMethodActive);
                  GXUtil.WriteLogRaw("Current: ",T000E2_A117PaymentMethodActive[0]);
               }
               if ( Z129PaymentMethodDiscount != T000E2_A129PaymentMethodDiscount[0] )
               {
                  GXUtil.WriteLog("paymentmethod:[seudo value changed for attri]"+"PaymentMethodDiscount");
                  GXUtil.WriteLogRaw("Old: ",Z129PaymentMethodDiscount);
                  GXUtil.WriteLogRaw("Current: ",T000E2_A129PaymentMethodDiscount[0]);
               }
               if ( Z130PaymentMethodRecarge != T000E2_A130PaymentMethodRecarge[0] )
               {
                  GXUtil.WriteLog("paymentmethod:[seudo value changed for attri]"+"PaymentMethodRecarge");
                  GXUtil.WriteLogRaw("Old: ",Z130PaymentMethodRecarge);
                  GXUtil.WriteLogRaw("Current: ",T000E2_A130PaymentMethodRecarge[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"PaymentMethod"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0E20( )
      {
         BeforeValidate0E20( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0E20( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0E20( 0) ;
            CheckOptimisticConcurrency0E20( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0E20( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0E20( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000E8 */
                     pr_default.execute(6, new Object[] {A116PaymentMethodDescription, A117PaymentMethodActive, A129PaymentMethodDiscount, A130PaymentMethodRecarge});
                     A115PaymentMethodId = T000E8_A115PaymentMethodId[0];
                     n115PaymentMethodId = T000E8_n115PaymentMethodId[0];
                     AssignAttri("", false, "A115PaymentMethodId", StringUtil.LTrimStr( (decimal)(A115PaymentMethodId), 6, 0));
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("PaymentMethod");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0E0( ) ;
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
               Load0E20( ) ;
            }
            EndLevel0E20( ) ;
         }
         CloseExtendedTableCursors0E20( ) ;
      }

      protected void Update0E20( )
      {
         BeforeValidate0E20( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0E20( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0E20( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0E20( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0E20( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000E9 */
                     pr_default.execute(7, new Object[] {A116PaymentMethodDescription, A117PaymentMethodActive, A129PaymentMethodDiscount, A130PaymentMethodRecarge, n115PaymentMethodId, A115PaymentMethodId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("PaymentMethod");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PaymentMethod"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0E20( ) ;
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
            EndLevel0E20( ) ;
         }
         CloseExtendedTableCursors0E20( ) ;
      }

      protected void DeferredUpdate0E20( )
      {
      }

      protected void delete( )
      {
         BeforeValidate0E20( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0E20( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0E20( ) ;
            AfterConfirm0E20( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0E20( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000E10 */
                  pr_default.execute(8, new Object[] {n115PaymentMethodId, A115PaymentMethodId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("PaymentMethod");
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
         sMode20 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0E20( ) ;
         Gx_mode = sMode20;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0E20( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV11Pgmname = "PaymentMethod";
            AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000E11 */
            pr_default.execute(9, new Object[] {n115PaymentMethodId, A115PaymentMethodId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Payment Method"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel0E20( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0E20( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("paymentmethod",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0E0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("paymentmethod",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0E20( )
      {
         /* Scan By routine */
         /* Using cursor T000E12 */
         pr_default.execute(10);
         RcdFound20 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound20 = 1;
            A115PaymentMethodId = T000E12_A115PaymentMethodId[0];
            n115PaymentMethodId = T000E12_n115PaymentMethodId[0];
            AssignAttri("", false, "A115PaymentMethodId", StringUtil.LTrimStr( (decimal)(A115PaymentMethodId), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0E20( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound20 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound20 = 1;
            A115PaymentMethodId = T000E12_A115PaymentMethodId[0];
            n115PaymentMethodId = T000E12_n115PaymentMethodId[0];
            AssignAttri("", false, "A115PaymentMethodId", StringUtil.LTrimStr( (decimal)(A115PaymentMethodId), 6, 0));
         }
      }

      protected void ScanEnd0E20( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm0E20( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0E20( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0E20( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0E20( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0E20( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0E20( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0E20( )
      {
         edtPaymentMethodId_Enabled = 0;
         AssignProp("", false, edtPaymentMethodId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaymentMethodId_Enabled), 5, 0), true);
         edtPaymentMethodDescription_Enabled = 0;
         AssignProp("", false, edtPaymentMethodDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaymentMethodDescription_Enabled), 5, 0), true);
         chkPaymentMethodActive.Enabled = 0;
         AssignProp("", false, chkPaymentMethodActive_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkPaymentMethodActive.Enabled), 5, 0), true);
         edtPaymentMethodDiscount_Enabled = 0;
         AssignProp("", false, edtPaymentMethodDiscount_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaymentMethodDiscount_Enabled), 5, 0), true);
         edtPaymentMethodRecarge_Enabled = 0;
         AssignProp("", false, edtPaymentMethodRecarge_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaymentMethodRecarge_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0E20( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0E0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("paymentmethod.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7PaymentMethodId,6,0))}, new string[] {"Gx_mode","PaymentMethodId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"PaymentMethod");
         forbiddenHiddens.Add("PaymentMethodId", context.localUtil.Format( (decimal)(A115PaymentMethodId), "ZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("paymentmethod:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z115PaymentMethodId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z115PaymentMethodId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z116PaymentMethodDescription", Z116PaymentMethodDescription);
         GxWebStd.gx_boolean_hidden_field( context, "Z117PaymentMethodActive", Z117PaymentMethodActive);
         GxWebStd.gx_hidden_field( context, "Z129PaymentMethodDiscount", StringUtil.LTrim( StringUtil.NToC( Z129PaymentMethodDiscount, 8, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z130PaymentMethodRecarge", StringUtil.LTrim( StringUtil.NToC( Z130PaymentMethodRecarge, 8, 2, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "vPAYMENTMETHODID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7PaymentMethodId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPAYMENTMETHODID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7PaymentMethodId), "ZZZZZ9"), context));
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
         return formatLink("paymentmethod.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7PaymentMethodId,6,0))}, new string[] {"Gx_mode","PaymentMethodId"})  ;
      }

      public override string GetPgmname( )
      {
         return "PaymentMethod" ;
      }

      public override string GetPgmdesc( )
      {
         return "Payment Method of Sale" ;
      }

      protected void InitializeNonKey0E20( )
      {
         A116PaymentMethodDescription = "";
         AssignAttri("", false, "A116PaymentMethodDescription", A116PaymentMethodDescription);
         A117PaymentMethodActive = false;
         AssignAttri("", false, "A117PaymentMethodActive", A117PaymentMethodActive);
         A129PaymentMethodDiscount = 0;
         AssignAttri("", false, "A129PaymentMethodDiscount", StringUtil.LTrimStr( A129PaymentMethodDiscount, 8, 2));
         A130PaymentMethodRecarge = 0;
         AssignAttri("", false, "A130PaymentMethodRecarge", StringUtil.LTrimStr( A130PaymentMethodRecarge, 8, 2));
         Z116PaymentMethodDescription = "";
         Z117PaymentMethodActive = false;
         Z129PaymentMethodDiscount = 0;
         Z130PaymentMethodRecarge = 0;
      }

      protected void InitAll0E20( )
      {
         A115PaymentMethodId = 0;
         n115PaymentMethodId = false;
         AssignAttri("", false, "A115PaymentMethodId", StringUtil.LTrimStr( (decimal)(A115PaymentMethodId), 6, 0));
         InitializeNonKey0E20( ) ;
      }

      protected void StandaloneModalInsert( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024112315032", true, true);
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
         context.AddJavascriptSource("paymentmethod.js", "?2024112315032", false, true);
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
         edtPaymentMethodId_Internalname = "PAYMENTMETHODID";
         edtPaymentMethodDescription_Internalname = "PAYMENTMETHODDESCRIPTION";
         chkPaymentMethodActive_Internalname = "PAYMENTMETHODACTIVE";
         edtPaymentMethodDiscount_Internalname = "PAYMENTMETHODDISCOUNT";
         edtPaymentMethodRecarge_Internalname = "PAYMENTMETHODRECARGE";
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
         Form.Caption = "Payment Method of Sale";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtPaymentMethodRecarge_Jsonclick = "";
         edtPaymentMethodRecarge_Enabled = 1;
         edtPaymentMethodDiscount_Jsonclick = "";
         edtPaymentMethodDiscount_Enabled = 1;
         chkPaymentMethodActive.Enabled = 1;
         edtPaymentMethodDescription_Enabled = 1;
         edtPaymentMethodId_Jsonclick = "";
         edtPaymentMethodId_Enabled = 0;
         edtPaymentMethodId_Visible = 1;
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
         chkPaymentMethodActive.Name = "PAYMENTMETHODACTIVE";
         chkPaymentMethodActive.WebTags = "";
         chkPaymentMethodActive.Caption = "";
         AssignProp("", false, chkPaymentMethodActive_Internalname, "TitleCaption", chkPaymentMethodActive.Caption, true);
         chkPaymentMethodActive.CheckedValue = "false";
         A117PaymentMethodActive = StringUtil.StrToBool( StringUtil.BoolToStr( A117PaymentMethodActive));
         AssignAttri("", false, "A117PaymentMethodActive", A117PaymentMethodActive);
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7PaymentMethodId',fld:'vPAYMENTMETHODID',pic:'ZZZZZ9',hsh:true},{av:'A117PaymentMethodActive',fld:'PAYMENTMETHODACTIVE',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'A117PaymentMethodActive',fld:'PAYMENTMETHODACTIVE',pic:''}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7PaymentMethodId',fld:'vPAYMENTMETHODID',pic:'ZZZZZ9',hsh:true},{av:'A115PaymentMethodId',fld:'PAYMENTMETHODID',pic:'ZZZZZ9'},{av:'A117PaymentMethodActive',fld:'PAYMENTMETHODACTIVE',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A117PaymentMethodActive',fld:'PAYMENTMETHODACTIVE',pic:''}]}");
         setEventMetadata("AFTER TRN","{handler:'E120E2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A117PaymentMethodActive',fld:'PAYMENTMETHODACTIVE',pic:''}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'A117PaymentMethodActive',fld:'PAYMENTMETHODACTIVE',pic:''}]}");
         setEventMetadata("VALID_PAYMENTMETHODID","{handler:'Valid_Paymentmethodid',iparms:[{av:'A117PaymentMethodActive',fld:'PAYMENTMETHODACTIVE',pic:''}]");
         setEventMetadata("VALID_PAYMENTMETHODID",",oparms:[{av:'A117PaymentMethodActive',fld:'PAYMENTMETHODACTIVE',pic:''}]}");
         setEventMetadata("VALID_PAYMENTMETHODDISCOUNT","{handler:'Valid_Paymentmethoddiscount',iparms:[{av:'A117PaymentMethodActive',fld:'PAYMENTMETHODACTIVE',pic:''}]");
         setEventMetadata("VALID_PAYMENTMETHODDISCOUNT",",oparms:[{av:'A117PaymentMethodActive',fld:'PAYMENTMETHODACTIVE',pic:''}]}");
         setEventMetadata("VALID_PAYMENTMETHODRECARGE","{handler:'Valid_Paymentmethodrecarge',iparms:[{av:'A117PaymentMethodActive',fld:'PAYMENTMETHODACTIVE',pic:''}]");
         setEventMetadata("VALID_PAYMENTMETHODRECARGE",",oparms:[{av:'A117PaymentMethodActive',fld:'PAYMENTMETHODACTIVE',pic:''}]}");
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
         Z116PaymentMethodDescription = "";
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
         A116PaymentMethodDescription = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV11Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode20 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         T000E4_A115PaymentMethodId = new int[1] ;
         T000E4_n115PaymentMethodId = new bool[] {false} ;
         T000E4_A116PaymentMethodDescription = new string[] {""} ;
         T000E4_A117PaymentMethodActive = new bool[] {false} ;
         T000E4_A129PaymentMethodDiscount = new decimal[1] ;
         T000E4_A130PaymentMethodRecarge = new decimal[1] ;
         T000E5_A115PaymentMethodId = new int[1] ;
         T000E5_n115PaymentMethodId = new bool[] {false} ;
         T000E3_A115PaymentMethodId = new int[1] ;
         T000E3_n115PaymentMethodId = new bool[] {false} ;
         T000E3_A116PaymentMethodDescription = new string[] {""} ;
         T000E3_A117PaymentMethodActive = new bool[] {false} ;
         T000E3_A129PaymentMethodDiscount = new decimal[1] ;
         T000E3_A130PaymentMethodRecarge = new decimal[1] ;
         T000E6_A115PaymentMethodId = new int[1] ;
         T000E6_n115PaymentMethodId = new bool[] {false} ;
         T000E7_A115PaymentMethodId = new int[1] ;
         T000E7_n115PaymentMethodId = new bool[] {false} ;
         T000E2_A115PaymentMethodId = new int[1] ;
         T000E2_n115PaymentMethodId = new bool[] {false} ;
         T000E2_A116PaymentMethodDescription = new string[] {""} ;
         T000E2_A117PaymentMethodActive = new bool[] {false} ;
         T000E2_A129PaymentMethodDiscount = new decimal[1] ;
         T000E2_A130PaymentMethodRecarge = new decimal[1] ;
         T000E8_A115PaymentMethodId = new int[1] ;
         T000E8_n115PaymentMethodId = new bool[] {false} ;
         T000E11_A20InvoiceId = new int[1] ;
         T000E11_A118InvoicePaymentMethodId = new int[1] ;
         T000E12_A115PaymentMethodId = new int[1] ;
         T000E12_n115PaymentMethodId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.paymentmethod__default(),
            new Object[][] {
                new Object[] {
               T000E2_A115PaymentMethodId, T000E2_A116PaymentMethodDescription, T000E2_A117PaymentMethodActive, T000E2_A129PaymentMethodDiscount, T000E2_A130PaymentMethodRecarge
               }
               , new Object[] {
               T000E3_A115PaymentMethodId, T000E3_A116PaymentMethodDescription, T000E3_A117PaymentMethodActive, T000E3_A129PaymentMethodDiscount, T000E3_A130PaymentMethodRecarge
               }
               , new Object[] {
               T000E4_A115PaymentMethodId, T000E4_A116PaymentMethodDescription, T000E4_A117PaymentMethodActive, T000E4_A129PaymentMethodDiscount, T000E4_A130PaymentMethodRecarge
               }
               , new Object[] {
               T000E5_A115PaymentMethodId
               }
               , new Object[] {
               T000E6_A115PaymentMethodId
               }
               , new Object[] {
               T000E7_A115PaymentMethodId
               }
               , new Object[] {
               T000E8_A115PaymentMethodId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000E11_A20InvoiceId, T000E11_A118InvoicePaymentMethodId
               }
               , new Object[] {
               T000E12_A115PaymentMethodId
               }
            }
         );
         AV11Pgmname = "PaymentMethod";
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short RcdFound20 ;
      private short GX_JID ;
      private short nIsDirty_20 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int wcpOAV7PaymentMethodId ;
      private int Z115PaymentMethodId ;
      private int AV7PaymentMethodId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtPaymentMethodId_Visible ;
      private int A115PaymentMethodId ;
      private int edtPaymentMethodId_Enabled ;
      private int edtPaymentMethodDescription_Enabled ;
      private int edtPaymentMethodDiscount_Enabled ;
      private int edtPaymentMethodRecarge_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private decimal Z129PaymentMethodDiscount ;
      private decimal Z130PaymentMethodRecarge ;
      private decimal A129PaymentMethodDiscount ;
      private decimal A130PaymentMethodRecarge ;
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
      private string edtPaymentMethodDescription_Internalname ;
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
      private string edtPaymentMethodId_Internalname ;
      private string edtPaymentMethodId_Jsonclick ;
      private string chkPaymentMethodActive_Internalname ;
      private string edtPaymentMethodDiscount_Internalname ;
      private string edtPaymentMethodDiscount_Jsonclick ;
      private string edtPaymentMethodRecarge_Internalname ;
      private string edtPaymentMethodRecarge_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV11Pgmname ;
      private string hsh ;
      private string sMode20 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool Z117PaymentMethodActive ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A117PaymentMethodActive ;
      private bool n115PaymentMethodId ;
      private bool returnInSub ;
      private string Z116PaymentMethodDescription ;
      private string A116PaymentMethodDescription ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkPaymentMethodActive ;
      private IDataStoreProvider pr_default ;
      private int[] T000E4_A115PaymentMethodId ;
      private bool[] T000E4_n115PaymentMethodId ;
      private string[] T000E4_A116PaymentMethodDescription ;
      private bool[] T000E4_A117PaymentMethodActive ;
      private decimal[] T000E4_A129PaymentMethodDiscount ;
      private decimal[] T000E4_A130PaymentMethodRecarge ;
      private int[] T000E5_A115PaymentMethodId ;
      private bool[] T000E5_n115PaymentMethodId ;
      private int[] T000E3_A115PaymentMethodId ;
      private bool[] T000E3_n115PaymentMethodId ;
      private string[] T000E3_A116PaymentMethodDescription ;
      private bool[] T000E3_A117PaymentMethodActive ;
      private decimal[] T000E3_A129PaymentMethodDiscount ;
      private decimal[] T000E3_A130PaymentMethodRecarge ;
      private int[] T000E6_A115PaymentMethodId ;
      private bool[] T000E6_n115PaymentMethodId ;
      private int[] T000E7_A115PaymentMethodId ;
      private bool[] T000E7_n115PaymentMethodId ;
      private int[] T000E2_A115PaymentMethodId ;
      private bool[] T000E2_n115PaymentMethodId ;
      private string[] T000E2_A116PaymentMethodDescription ;
      private bool[] T000E2_A117PaymentMethodActive ;
      private decimal[] T000E2_A129PaymentMethodDiscount ;
      private decimal[] T000E2_A130PaymentMethodRecarge ;
      private int[] T000E8_A115PaymentMethodId ;
      private bool[] T000E8_n115PaymentMethodId ;
      private int[] T000E11_A20InvoiceId ;
      private int[] T000E11_A118InvoicePaymentMethodId ;
      private int[] T000E12_A115PaymentMethodId ;
      private bool[] T000E12_n115PaymentMethodId ;
      private GXWebForm Form ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
   }

   public class paymentmethod__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT000E4;
          prmT000E4 = new Object[] {
          new ParDef("@PaymentMethodId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000E5;
          prmT000E5 = new Object[] {
          new ParDef("@PaymentMethodId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000E3;
          prmT000E3 = new Object[] {
          new ParDef("@PaymentMethodId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000E6;
          prmT000E6 = new Object[] {
          new ParDef("@PaymentMethodId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000E7;
          prmT000E7 = new Object[] {
          new ParDef("@PaymentMethodId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000E2;
          prmT000E2 = new Object[] {
          new ParDef("@PaymentMethodId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000E8;
          prmT000E8 = new Object[] {
          new ParDef("@PaymentMethodDescription",GXType.NVarChar,200,0) ,
          new ParDef("@PaymentMethodActive",GXType.Boolean,4,0) ,
          new ParDef("@PaymentMethodDiscount",GXType.Decimal,8,2) ,
          new ParDef("@PaymentMethodRecarge",GXType.Decimal,8,2)
          };
          Object[] prmT000E9;
          prmT000E9 = new Object[] {
          new ParDef("@PaymentMethodDescription",GXType.NVarChar,200,0) ,
          new ParDef("@PaymentMethodActive",GXType.Boolean,4,0) ,
          new ParDef("@PaymentMethodDiscount",GXType.Decimal,8,2) ,
          new ParDef("@PaymentMethodRecarge",GXType.Decimal,8,2) ,
          new ParDef("@PaymentMethodId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000E10;
          prmT000E10 = new Object[] {
          new ParDef("@PaymentMethodId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000E11;
          prmT000E11 = new Object[] {
          new ParDef("@PaymentMethodId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000E12;
          prmT000E12 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T000E2", "SELECT [PaymentMethodId], [PaymentMethodDescription], [PaymentMethodActive], [PaymentMethodDiscount], [PaymentMethodRecarge] FROM [PaymentMethod] WITH (UPDLOCK) WHERE [PaymentMethodId] = @PaymentMethodId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000E3", "SELECT [PaymentMethodId], [PaymentMethodDescription], [PaymentMethodActive], [PaymentMethodDiscount], [PaymentMethodRecarge] FROM [PaymentMethod] WHERE [PaymentMethodId] = @PaymentMethodId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000E4", "SELECT TM1.[PaymentMethodId], TM1.[PaymentMethodDescription], TM1.[PaymentMethodActive], TM1.[PaymentMethodDiscount], TM1.[PaymentMethodRecarge] FROM [PaymentMethod] TM1 WHERE TM1.[PaymentMethodId] = @PaymentMethodId ORDER BY TM1.[PaymentMethodId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000E4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000E5", "SELECT [PaymentMethodId] FROM [PaymentMethod] WHERE [PaymentMethodId] = @PaymentMethodId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000E5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000E6", "SELECT TOP 1 [PaymentMethodId] FROM [PaymentMethod] WHERE ( [PaymentMethodId] > @PaymentMethodId) ORDER BY [PaymentMethodId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000E6,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000E7", "SELECT TOP 1 [PaymentMethodId] FROM [PaymentMethod] WHERE ( [PaymentMethodId] < @PaymentMethodId) ORDER BY [PaymentMethodId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000E7,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000E8", "INSERT INTO [PaymentMethod]([PaymentMethodDescription], [PaymentMethodActive], [PaymentMethodDiscount], [PaymentMethodRecarge]) VALUES(@PaymentMethodDescription, @PaymentMethodActive, @PaymentMethodDiscount, @PaymentMethodRecarge); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000E8,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000E9", "UPDATE [PaymentMethod] SET [PaymentMethodDescription]=@PaymentMethodDescription, [PaymentMethodActive]=@PaymentMethodActive, [PaymentMethodDiscount]=@PaymentMethodDiscount, [PaymentMethodRecarge]=@PaymentMethodRecarge  WHERE [PaymentMethodId] = @PaymentMethodId", GxErrorMask.GX_NOMASK,prmT000E9)
             ,new CursorDef("T000E10", "DELETE FROM [PaymentMethod]  WHERE [PaymentMethodId] = @PaymentMethodId", GxErrorMask.GX_NOMASK,prmT000E10)
             ,new CursorDef("T000E11", "SELECT TOP 1 [InvoiceId], [InvoicePaymentMethodId] FROM [InvoicePaymentMethod] WHERE [PaymentMethodId] = @PaymentMethodId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E11,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000E12", "SELECT [PaymentMethodId] FROM [PaymentMethod] ORDER BY [PaymentMethodId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000E12,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
