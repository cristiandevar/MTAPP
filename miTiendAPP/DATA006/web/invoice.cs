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
   public class invoice : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_28") == 0 )
         {
            A20InvoiceId = (int)(Math.Round(NumberUtil.Val( GetPar( "InvoiceId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A20InvoiceId", StringUtil.LTrimStr( (decimal)(A20InvoiceId), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_28( A20InvoiceId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_30") == 0 )
         {
            A20InvoiceId = (int)(Math.Round(NumberUtil.Val( GetPar( "InvoiceId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A20InvoiceId", StringUtil.LTrimStr( (decimal)(A20InvoiceId), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_30( A20InvoiceId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_31") == 0 )
         {
            A20InvoiceId = (int)(Math.Round(NumberUtil.Val( GetPar( "InvoiceId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A20InvoiceId", StringUtil.LTrimStr( (decimal)(A20InvoiceId), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_31( A20InvoiceId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_29") == 0 )
         {
            A99UserId = (int)(Math.Round(NumberUtil.Val( GetPar( "UserId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A99UserId", StringUtil.LTrimStr( (decimal)(A99UserId), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_29( A99UserId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_33") == 0 )
         {
            A15ProductId = (int)(Math.Round(NumberUtil.Val( GetPar( "ProductId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_33( A15ProductId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_35") == 0 )
         {
            A115PaymentMethodId = (int)(Math.Round(NumberUtil.Val( GetPar( "PaymentMethodId"), "."), 18, MidpointRounding.ToEven));
            n115PaymentMethodId = false;
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_35( A115PaymentMethodId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridinvoice_detail") == 0 )
         {
            gxnrGridinvoice_detail_newrow_invoke( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridinvoice_paymentmethod") == 0 )
         {
            gxnrGridinvoice_paymentmethod_newrow_invoke( ) ;
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
               AV13InvoiceId = (int)(Math.Round(NumberUtil.Val( GetPar( "InvoiceId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV13InvoiceId", StringUtil.LTrimStr( (decimal)(AV13InvoiceId), 6, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vINVOICEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13InvoiceId), "ZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Invoice", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtInvoiceCreatedDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("mtaKB", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridinvoice_detail_newrow_invoke( )
      {
         nRC_GXsfl_88 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_88"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_88_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_88_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_88_idx = GetPar( "sGXsfl_88_idx");
         A97InvoiceLastDetailId = (int)(Math.Round(NumberUtil.Val( GetPar( "InvoiceLastDetailId"), "."), 18, MidpointRounding.ToEven));
         Gx_BScreen = (short)(Math.Round(NumberUtil.Val( GetPar( "Gx_BScreen"), "."), 18, MidpointRounding.ToEven));
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridinvoice_detail_newrow( ) ;
         /* End function gxnrGridinvoice_detail_newrow_invoke */
      }

      protected void gxnrGridinvoice_paymentmethod_newrow_invoke( )
      {
         nRC_GXsfl_104 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_104"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_104_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_104_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_104_idx = GetPar( "sGXsfl_104_idx");
         A131InvoiceLastPaymentMethodId = (int)(Math.Round(NumberUtil.Val( GetPar( "InvoiceLastPaymentMethodId"), "."), 18, MidpointRounding.ToEven));
         n131InvoiceLastPaymentMethodId = false;
         Gx_BScreen = (short)(Math.Round(NumberUtil.Val( GetPar( "Gx_BScreen"), "."), 18, MidpointRounding.ToEven));
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridinvoice_paymentmethod_newrow( ) ;
         /* End function gxnrGridinvoice_paymentmethod_newrow_invoke */
      }

      public invoice( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public invoice( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_InvoiceId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV13InvoiceId = aP1_InvoiceId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkInvoiceActive = new GXCheckbox();
         chkInvoiceDetailIsWholesale = new GXCheckbox();
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
         A94InvoiceActive = StringUtil.StrToBool( StringUtil.BoolToStr( A94InvoiceActive));
         AssignAttri("", false, "A94InvoiceActive", A94InvoiceActive);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Invoice", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Invoice.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Invoice.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Invoice.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Invoice.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Invoice.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Invoice.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtInvoiceId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtInvoiceId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtInvoiceId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A20InvoiceId), 6, 0, ".", "")), StringUtil.LTrim( ((edtInvoiceId_Enabled!=0) ? context.localUtil.Format( (decimal)(A20InvoiceId), "ZZZZZ9") : context.localUtil.Format( (decimal)(A20InvoiceId), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtInvoiceId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtInvoiceId_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_Invoice.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtInvoiceCreatedDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtInvoiceCreatedDate_Internalname, "Created Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtInvoiceCreatedDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtInvoiceCreatedDate_Internalname, context.localUtil.Format(A38InvoiceCreatedDate, "99/99/99"), context.localUtil.Format( A38InvoiceCreatedDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtInvoiceCreatedDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtInvoiceCreatedDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Invoice.htm");
         GxWebStd.gx_bitmap( context, edtInvoiceCreatedDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtInvoiceCreatedDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Invoice.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUserId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUserId_Internalname, "User Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUserId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A99UserId), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A99UserId), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUserId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUserId_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_Invoice.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_99_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_99_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_99_Internalname, sImgUrl, imgprompt_99_Link, "", "", context.GetTheme( ), imgprompt_99_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Invoice.htm");
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
         GxWebStd.gx_label_element( context, edtUserName_Internalname, "User Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtUserName_Internalname, A100UserName, StringUtil.RTrim( context.localUtil.Format( A100UserName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUserName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUserName_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Invoice.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtInvoiceModifiedDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtInvoiceModifiedDate_Internalname, "Modified Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtInvoiceModifiedDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtInvoiceModifiedDate_Internalname, context.localUtil.Format(A39InvoiceModifiedDate, "99/99/99"), context.localUtil.Format( A39InvoiceModifiedDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtInvoiceModifiedDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtInvoiceModifiedDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Invoice.htm");
         GxWebStd.gx_bitmap( context, edtInvoiceModifiedDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtInvoiceModifiedDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Invoice.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkInvoiceActive_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkInvoiceActive_Internalname, "Active", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkInvoiceActive_Internalname, StringUtil.BoolToStr( A94InvoiceActive), "", "Active", 1, chkInvoiceActive.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(59, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,59);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtInvoiceTotalReceivable_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtInvoiceTotalReceivable_Internalname, "Total Receivable", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtInvoiceTotalReceivable_Internalname, StringUtil.LTrim( StringUtil.NToC( A80InvoiceTotalReceivable, 18, 2, ".", "")), StringUtil.LTrim( ((edtInvoiceTotalReceivable_Enabled!=0) ? context.localUtil.Format( A80InvoiceTotalReceivable, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A80InvoiceTotalReceivable, "ZZZZZZZZZZZZZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtInvoiceTotalReceivable_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtInvoiceTotalReceivable_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Price", "right", false, "", "HLP_Invoice.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtInvoiceProductQuantity_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtInvoiceProductQuantity_Internalname, "Product Quantity", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtInvoiceProductQuantity_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A68InvoiceProductQuantity), 4, 0, ".", "")), StringUtil.LTrim( ((edtInvoiceProductQuantity_Enabled!=0) ? context.localUtil.Format( (decimal)(A68InvoiceProductQuantity), "ZZZ9") : context.localUtil.Format( (decimal)(A68InvoiceProductQuantity), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtInvoiceProductQuantity_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtInvoiceProductQuantity_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Invoice.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtInvoiceLastDetailId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtInvoiceLastDetailId_Internalname, "Detail Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtInvoiceLastDetailId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A97InvoiceLastDetailId), 6, 0, ".", "")), StringUtil.LTrim( ((edtInvoiceLastDetailId_Enabled!=0) ? context.localUtil.Format( (decimal)(A97InvoiceLastDetailId), "ZZZZZ9") : context.localUtil.Format( (decimal)(A97InvoiceLastDetailId), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtInvoiceLastDetailId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtInvoiceLastDetailId_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_Invoice.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtInvoiceLastPaymentMethodId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtInvoiceLastPaymentMethodId_Internalname, "Method Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtInvoiceLastPaymentMethodId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0, ".", "")), StringUtil.LTrim( ((edtInvoiceLastPaymentMethodId_Enabled!=0) ? context.localUtil.Format( (decimal)(A131InvoiceLastPaymentMethodId), "ZZZZZ9") : context.localUtil.Format( (decimal)(A131InvoiceLastPaymentMethodId), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtInvoiceLastPaymentMethodId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtInvoiceLastPaymentMethodId_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_Invoice.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divDetailtable_Internalname, 1, 0, "px", 0, "px", "form__table-level", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitledetail_Internalname, "Detail", "", "", lblTitledetail_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-04", 0, "", 1, 1, 0, 0, "HLP_Invoice.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         gxdraw_Gridinvoice_detail( ) ;
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
         GxWebStd.gx_div_start( context, divPaymentmethodtable_Internalname, 1, 0, "px", 0, "px", "form__table-level", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitlepaymentmethod_Internalname, "Payment Method", "", "", lblTitlepaymentmethod_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-04", 0, "", 1, 1, 0, 0, "HLP_Invoice.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         gxdraw_Gridinvoice_paymentmethod( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 117,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Invoice.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Invoice.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Invoice.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "Right", "Middle", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void gxdraw_Gridinvoice_detail( )
      {
         /*  Grid Control  */
         StartGridControl88( ) ;
         nGXsfl_88_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount13 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_13 = 1;
               ScanStart0613( ) ;
               while ( RcdFound13 != 0 )
               {
                  init_level_properties13( ) ;
                  getByPrimaryKey0613( ) ;
                  AddRow0613( ) ;
                  ScanNext0613( ) ;
               }
               ScanEnd0613( ) ;
               nBlankRcdCount13 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B131InvoiceLastPaymentMethodId = A131InvoiceLastPaymentMethodId;
            n131InvoiceLastPaymentMethodId = false;
            AssignAttri("", false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
            B97InvoiceLastDetailId = A97InvoiceLastDetailId;
            AssignAttri("", false, "A97InvoiceLastDetailId", StringUtil.LTrimStr( (decimal)(A97InvoiceLastDetailId), 6, 0));
            B68InvoiceProductQuantity = A68InvoiceProductQuantity;
            AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
            standaloneNotModal0613( ) ;
            standaloneModal0613( ) ;
            sMode13 = Gx_mode;
            while ( nGXsfl_88_idx < nRC_GXsfl_88 )
            {
               bGXsfl_88_Refreshing = true;
               ReadRow0613( ) ;
               edtInvoiceDetailId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVOICEDETAILID_"+sGXsfl_88_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtInvoiceDetailId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceDetailId_Enabled), 5, 0), !bGXsfl_88_Refreshing);
               edtProductId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTID_"+sGXsfl_88_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), !bGXsfl_88_Refreshing);
               edtProductName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTNAME_"+sGXsfl_88_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProductName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductName_Enabled), 5, 0), !bGXsfl_88_Refreshing);
               edtProductStock_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTSTOCK_"+sGXsfl_88_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProductStock_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductStock_Enabled), 5, 0), !bGXsfl_88_Refreshing);
               edtInvoiceDetailQuantity_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVOICEDETAILQUANTITY_"+sGXsfl_88_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtInvoiceDetailQuantity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceDetailQuantity_Enabled), 5, 0), !bGXsfl_88_Refreshing);
               edtInvoiceDetailHistoricPrice_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVOICEDETAILHISTORICPRICE_"+sGXsfl_88_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtInvoiceDetailHistoricPrice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceDetailHistoricPrice_Enabled), 5, 0), !bGXsfl_88_Refreshing);
               chkInvoiceDetailIsWholesale.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVOICEDETAILISWHOLESALE_"+sGXsfl_88_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, chkInvoiceDetailIsWholesale_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkInvoiceDetailIsWholesale.Enabled), 5, 0), !bGXsfl_88_Refreshing);
               imgprompt_99_Link = cgiGet( "PROMPT_15_"+sGXsfl_88_idx+"Link");
               if ( ( nRcdExists_13 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0613( ) ;
               }
               SendRow0613( ) ;
               bGXsfl_88_Refreshing = false;
            }
            Gx_mode = sMode13;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A131InvoiceLastPaymentMethodId = B131InvoiceLastPaymentMethodId;
            n131InvoiceLastPaymentMethodId = false;
            AssignAttri("", false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
            A97InvoiceLastDetailId = B97InvoiceLastDetailId;
            AssignAttri("", false, "A97InvoiceLastDetailId", StringUtil.LTrimStr( (decimal)(A97InvoiceLastDetailId), 6, 0));
            A68InvoiceProductQuantity = B68InvoiceProductQuantity;
            AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount13 = 5;
            nRcdExists_13 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0613( ) ;
               while ( RcdFound13 != 0 )
               {
                  sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_8813( ) ;
                  init_level_properties13( ) ;
                  standaloneNotModal0613( ) ;
                  getByPrimaryKey0613( ) ;
                  standaloneModal0613( ) ;
                  AddRow0613( ) ;
                  ScanNext0613( ) ;
               }
               ScanEnd0613( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode13 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx+1), 4, 0), 4, "0");
            SubsflControlProps_8813( ) ;
            InitAll0613( ) ;
            init_level_properties13( ) ;
            B131InvoiceLastPaymentMethodId = A131InvoiceLastPaymentMethodId;
            n131InvoiceLastPaymentMethodId = false;
            AssignAttri("", false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
            B97InvoiceLastDetailId = A97InvoiceLastDetailId;
            AssignAttri("", false, "A97InvoiceLastDetailId", StringUtil.LTrimStr( (decimal)(A97InvoiceLastDetailId), 6, 0));
            B68InvoiceProductQuantity = A68InvoiceProductQuantity;
            AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
            nRcdExists_13 = 0;
            nIsMod_13 = 0;
            nRcdDeleted_13 = 0;
            nBlankRcdCount13 = (short)(nBlankRcdUsr13+nBlankRcdCount13);
            fRowAdded = 0;
            while ( nBlankRcdCount13 > 0 )
            {
               standaloneNotModal0613( ) ;
               standaloneModal0613( ) ;
               AddRow0613( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtInvoiceDetailId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount13 = (short)(nBlankRcdCount13-1);
            }
            Gx_mode = sMode13;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A131InvoiceLastPaymentMethodId = B131InvoiceLastPaymentMethodId;
            n131InvoiceLastPaymentMethodId = false;
            AssignAttri("", false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
            A97InvoiceLastDetailId = B97InvoiceLastDetailId;
            AssignAttri("", false, "A97InvoiceLastDetailId", StringUtil.LTrimStr( (decimal)(A97InvoiceLastDetailId), 6, 0));
            A68InvoiceProductQuantity = B68InvoiceProductQuantity;
            AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridinvoice_detailContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridinvoice_detail", Gridinvoice_detailContainer, subGridinvoice_detail_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridinvoice_detailContainerData", Gridinvoice_detailContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridinvoice_detailContainerData"+"V", Gridinvoice_detailContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridinvoice_detailContainerData"+"V"+"\" value='"+Gridinvoice_detailContainer.GridValuesHidden()+"'/>") ;
         }
      }

      protected void gxdraw_Gridinvoice_paymentmethod( )
      {
         /*  Grid Control  */
         StartGridControl104( ) ;
         nGXsfl_104_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount21 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_21 = 1;
               ScanStart0621( ) ;
               while ( RcdFound21 != 0 )
               {
                  init_level_properties21( ) ;
                  getByPrimaryKey0621( ) ;
                  AddRow0621( ) ;
                  ScanNext0621( ) ;
               }
               ScanEnd0621( ) ;
               nBlankRcdCount21 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B131InvoiceLastPaymentMethodId = A131InvoiceLastPaymentMethodId;
            n131InvoiceLastPaymentMethodId = false;
            AssignAttri("", false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
            B97InvoiceLastDetailId = A97InvoiceLastDetailId;
            AssignAttri("", false, "A97InvoiceLastDetailId", StringUtil.LTrimStr( (decimal)(A97InvoiceLastDetailId), 6, 0));
            B68InvoiceProductQuantity = A68InvoiceProductQuantity;
            AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
            standaloneNotModal0621( ) ;
            standaloneModal0621( ) ;
            sMode21 = Gx_mode;
            while ( nGXsfl_104_idx < nRC_GXsfl_104 )
            {
               bGXsfl_104_Refreshing = true;
               ReadRow0621( ) ;
               edtInvoicePaymentMethodId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVOICEPAYMENTMETHODID_"+sGXsfl_104_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtInvoicePaymentMethodId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoicePaymentMethodId_Enabled), 5, 0), !bGXsfl_104_Refreshing);
               edtPaymentMethodId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PAYMENTMETHODID_"+sGXsfl_104_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtPaymentMethodId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaymentMethodId_Enabled), 5, 0), !bGXsfl_104_Refreshing);
               edtPaymentMethodDescription_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PAYMENTMETHODDESCRIPTION_"+sGXsfl_104_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtPaymentMethodDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaymentMethodDescription_Enabled), 5, 0), !bGXsfl_104_Refreshing);
               edtPaymentMethodDiscount_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PAYMENTMETHODDISCOUNT_"+sGXsfl_104_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtPaymentMethodDiscount_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaymentMethodDiscount_Enabled), 5, 0), !bGXsfl_104_Refreshing);
               edtPaymentMethodRecarge_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PAYMENTMETHODRECARGE_"+sGXsfl_104_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtPaymentMethodRecarge_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaymentMethodRecarge_Enabled), 5, 0), !bGXsfl_104_Refreshing);
               edtInvoicePaymentMethodImport_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVOICEPAYMENTMETHODIMPORT_"+sGXsfl_104_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtInvoicePaymentMethodImport_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoicePaymentMethodImport_Enabled), 5, 0), !bGXsfl_104_Refreshing);
               edtInvoicePaymentMethodRechargeIm_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVOICEPAYMENTMETHODRECHARGEIM_"+sGXsfl_104_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtInvoicePaymentMethodRechargeIm_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoicePaymentMethodRechargeIm_Enabled), 5, 0), !bGXsfl_104_Refreshing);
               edtInvoicePaymentMethodDiscountIm_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVOICEPAYMENTMETHODDISCOUNTIM_"+sGXsfl_104_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtInvoicePaymentMethodDiscountIm_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoicePaymentMethodDiscountIm_Enabled), 5, 0), !bGXsfl_104_Refreshing);
               imgprompt_99_Link = cgiGet( "PROMPT_115_"+sGXsfl_104_idx+"Link");
               if ( ( nRcdExists_21 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0621( ) ;
               }
               SendRow0621( ) ;
               bGXsfl_104_Refreshing = false;
            }
            Gx_mode = sMode21;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A131InvoiceLastPaymentMethodId = B131InvoiceLastPaymentMethodId;
            n131InvoiceLastPaymentMethodId = false;
            AssignAttri("", false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
            A97InvoiceLastDetailId = B97InvoiceLastDetailId;
            AssignAttri("", false, "A97InvoiceLastDetailId", StringUtil.LTrimStr( (decimal)(A97InvoiceLastDetailId), 6, 0));
            A68InvoiceProductQuantity = B68InvoiceProductQuantity;
            AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount21 = 5;
            nRcdExists_21 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0621( ) ;
               while ( RcdFound21 != 0 )
               {
                  sGXsfl_104_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_104_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_10421( ) ;
                  init_level_properties21( ) ;
                  standaloneNotModal0621( ) ;
                  getByPrimaryKey0621( ) ;
                  standaloneModal0621( ) ;
                  AddRow0621( ) ;
                  ScanNext0621( ) ;
               }
               ScanEnd0621( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode21 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_104_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_104_idx+1), 4, 0), 4, "0");
            SubsflControlProps_10421( ) ;
            InitAll0621( ) ;
            init_level_properties21( ) ;
            B131InvoiceLastPaymentMethodId = A131InvoiceLastPaymentMethodId;
            n131InvoiceLastPaymentMethodId = false;
            AssignAttri("", false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
            B97InvoiceLastDetailId = A97InvoiceLastDetailId;
            AssignAttri("", false, "A97InvoiceLastDetailId", StringUtil.LTrimStr( (decimal)(A97InvoiceLastDetailId), 6, 0));
            B68InvoiceProductQuantity = A68InvoiceProductQuantity;
            AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
            nRcdExists_21 = 0;
            nIsMod_21 = 0;
            nRcdDeleted_21 = 0;
            nBlankRcdCount21 = (short)(nBlankRcdUsr21+nBlankRcdCount21);
            fRowAdded = 0;
            while ( nBlankRcdCount21 > 0 )
            {
               standaloneNotModal0621( ) ;
               standaloneModal0621( ) ;
               AddRow0621( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtInvoicePaymentMethodId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount21 = (short)(nBlankRcdCount21-1);
            }
            Gx_mode = sMode21;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A131InvoiceLastPaymentMethodId = B131InvoiceLastPaymentMethodId;
            n131InvoiceLastPaymentMethodId = false;
            AssignAttri("", false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
            A97InvoiceLastDetailId = B97InvoiceLastDetailId;
            AssignAttri("", false, "A97InvoiceLastDetailId", StringUtil.LTrimStr( (decimal)(A97InvoiceLastDetailId), 6, 0));
            A68InvoiceProductQuantity = B68InvoiceProductQuantity;
            AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridinvoice_paymentmethodContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridinvoice_paymentmethod", Gridinvoice_paymentmethodContainer, subGridinvoice_paymentmethod_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridinvoice_paymentmethodContainerData", Gridinvoice_paymentmethodContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridinvoice_paymentmethodContainerData"+"V", Gridinvoice_paymentmethodContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridinvoice_paymentmethodContainerData"+"V"+"\" value='"+Gridinvoice_paymentmethodContainer.GridValuesHidden()+"'/>") ;
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
         E11062 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z20InvoiceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z20InvoiceId"), ".", ","), 18, MidpointRounding.ToEven));
               Z38InvoiceCreatedDate = context.localUtil.CToD( cgiGet( "Z38InvoiceCreatedDate"), 0);
               Z39InvoiceModifiedDate = context.localUtil.CToD( cgiGet( "Z39InvoiceModifiedDate"), 0);
               n39InvoiceModifiedDate = ((DateTime.MinValue==A39InvoiceModifiedDate) ? true : false);
               Z94InvoiceActive = StringUtil.StrToBool( cgiGet( "Z94InvoiceActive"));
               Z99UserId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z99UserId"), ".", ","), 18, MidpointRounding.ToEven));
               O131InvoiceLastPaymentMethodId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "O131InvoiceLastPaymentMethodId"), ".", ","), 18, MidpointRounding.ToEven));
               O97InvoiceLastDetailId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "O97InvoiceLastDetailId"), ".", ","), 18, MidpointRounding.ToEven));
               O68InvoiceProductQuantity = (short)(Math.Round(context.localUtil.CToN( cgiGet( "O68InvoiceProductQuantity"), ".", ","), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_88 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_88"), ".", ","), 18, MidpointRounding.ToEven));
               nRC_GXsfl_104 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_104"), ".", ","), 18, MidpointRounding.ToEven));
               N99UserId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N99UserId"), ".", ","), 18, MidpointRounding.ToEven));
               AV13InvoiceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINVOICEID"), ".", ","), 18, MidpointRounding.ToEven));
               AV14Insert_UserId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_USERID"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_date = context.localUtil.CToD( cgiGet( "vTODAY"), 0);
               AV21Pgmname = cgiGet( "vPGMNAME");
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               A20InvoiceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtInvoiceId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A20InvoiceId", StringUtil.LTrimStr( (decimal)(A20InvoiceId), 6, 0));
               if ( context.localUtil.VCDate( cgiGet( edtInvoiceCreatedDate_Internalname), 1) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Invoice Created Date"}), 1, "INVOICECREATEDDATE");
                  AnyError = 1;
                  GX_FocusControl = edtInvoiceCreatedDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A38InvoiceCreatedDate = DateTime.MinValue;
                  AssignAttri("", false, "A38InvoiceCreatedDate", context.localUtil.Format(A38InvoiceCreatedDate, "99/99/99"));
               }
               else
               {
                  A38InvoiceCreatedDate = context.localUtil.CToD( cgiGet( edtInvoiceCreatedDate_Internalname), 1);
                  AssignAttri("", false, "A38InvoiceCreatedDate", context.localUtil.Format(A38InvoiceCreatedDate, "99/99/99"));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtUserId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtUserId_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USERID");
                  AnyError = 1;
                  GX_FocusControl = edtUserId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A99UserId = 0;
                  AssignAttri("", false, "A99UserId", StringUtil.LTrimStr( (decimal)(A99UserId), 6, 0));
               }
               else
               {
                  A99UserId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtUserId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A99UserId", StringUtil.LTrimStr( (decimal)(A99UserId), 6, 0));
               }
               A100UserName = cgiGet( edtUserName_Internalname);
               AssignAttri("", false, "A100UserName", A100UserName);
               if ( context.localUtil.VCDate( cgiGet( edtInvoiceModifiedDate_Internalname), 1) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Invoice Modified Date"}), 1, "INVOICEMODIFIEDDATE");
                  AnyError = 1;
                  GX_FocusControl = edtInvoiceModifiedDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A39InvoiceModifiedDate = DateTime.MinValue;
                  n39InvoiceModifiedDate = false;
                  AssignAttri("", false, "A39InvoiceModifiedDate", context.localUtil.Format(A39InvoiceModifiedDate, "99/99/99"));
               }
               else
               {
                  A39InvoiceModifiedDate = context.localUtil.CToD( cgiGet( edtInvoiceModifiedDate_Internalname), 1);
                  n39InvoiceModifiedDate = false;
                  AssignAttri("", false, "A39InvoiceModifiedDate", context.localUtil.Format(A39InvoiceModifiedDate, "99/99/99"));
               }
               n39InvoiceModifiedDate = ((DateTime.MinValue==A39InvoiceModifiedDate) ? true : false);
               A94InvoiceActive = StringUtil.StrToBool( cgiGet( chkInvoiceActive_Internalname));
               AssignAttri("", false, "A94InvoiceActive", A94InvoiceActive);
               A80InvoiceTotalReceivable = context.localUtil.CToN( cgiGet( edtInvoiceTotalReceivable_Internalname), ".", ",");
               n80InvoiceTotalReceivable = false;
               AssignAttri("", false, "A80InvoiceTotalReceivable", StringUtil.LTrimStr( A80InvoiceTotalReceivable, 18, 2));
               A68InvoiceProductQuantity = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtInvoiceProductQuantity_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
               A97InvoiceLastDetailId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtInvoiceLastDetailId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A97InvoiceLastDetailId", StringUtil.LTrimStr( (decimal)(A97InvoiceLastDetailId), 6, 0));
               A131InvoiceLastPaymentMethodId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtInvoiceLastPaymentMethodId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               n131InvoiceLastPaymentMethodId = false;
               AssignAttri("", false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Invoice");
               A20InvoiceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtInvoiceId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A20InvoiceId", StringUtil.LTrimStr( (decimal)(A20InvoiceId), 6, 0));
               forbiddenHiddens.Add("InvoiceId", context.localUtil.Format( (decimal)(A20InvoiceId), "ZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A20InvoiceId != Z20InvoiceId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("invoice:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A20InvoiceId = (int)(Math.Round(NumberUtil.Val( GetPar( "InvoiceId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A20InvoiceId", StringUtil.LTrimStr( (decimal)(A20InvoiceId), 6, 0));
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
                     sMode6 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode6;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound6 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_060( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "INVOICEID");
                        AnyError = 1;
                        GX_FocusControl = edtInvoiceId_Internalname;
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
                           E11062 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12062 ();
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
            E12062 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll066( ) ;
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
            DisableAttributes066( ) ;
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

      protected void CONFIRM_060( )
      {
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls066( ) ;
            }
            else
            {
               CheckExtendedTable066( ) ;
               CloseExtendedTableCursors066( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode6 = Gx_mode;
            CONFIRM_0613( ) ;
            if ( AnyError == 0 )
            {
               CONFIRM_0621( ) ;
               if ( AnyError == 0 )
               {
                  /* Restore parent mode. */
                  Gx_mode = sMode6;
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  IsConfirmed = 1;
                  AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
               }
            }
            /* Restore parent mode. */
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_0621( )
      {
         s131InvoiceLastPaymentMethodId = O131InvoiceLastPaymentMethodId;
         n131InvoiceLastPaymentMethodId = false;
         AssignAttri("", false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
         nGXsfl_104_idx = 0;
         while ( nGXsfl_104_idx < nRC_GXsfl_104 )
         {
            ReadRow0621( ) ;
            if ( ( nRcdExists_21 != 0 ) || ( nIsMod_21 != 0 ) )
            {
               GetKey0621( ) ;
               if ( ( nRcdExists_21 == 0 ) && ( nRcdDeleted_21 == 0 ) )
               {
                  if ( RcdFound21 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0621( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0621( ) ;
                        CloseExtendedTableCursors0621( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                        O131InvoiceLastPaymentMethodId = A131InvoiceLastPaymentMethodId;
                        n131InvoiceLastPaymentMethodId = false;
                        AssignAttri("", false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
                     }
                  }
                  else
                  {
                     GXCCtl = "INVOICEPAYMENTMETHODID_" + sGXsfl_104_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtInvoicePaymentMethodId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound21 != 0 )
                  {
                     if ( nRcdDeleted_21 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0621( ) ;
                        Load0621( ) ;
                        BeforeValidate0621( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0621( ) ;
                           O131InvoiceLastPaymentMethodId = A131InvoiceLastPaymentMethodId;
                           n131InvoiceLastPaymentMethodId = false;
                           AssignAttri("", false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
                        }
                     }
                     else
                     {
                        if ( nIsMod_21 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0621( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0621( ) ;
                              CloseExtendedTableCursors0621( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                              O131InvoiceLastPaymentMethodId = A131InvoiceLastPaymentMethodId;
                              n131InvoiceLastPaymentMethodId = false;
                              AssignAttri("", false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_21 == 0 )
                     {
                        GXCCtl = "INVOICEPAYMENTMETHODID_" + sGXsfl_104_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtInvoicePaymentMethodId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtInvoicePaymentMethodId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A118InvoicePaymentMethodId), 6, 0, ".", ""))) ;
            ChangePostValue( edtPaymentMethodId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A115PaymentMethodId), 6, 0, ".", ""))) ;
            ChangePostValue( edtPaymentMethodDescription_Internalname, A116PaymentMethodDescription) ;
            ChangePostValue( edtPaymentMethodDiscount_Internalname, StringUtil.LTrim( StringUtil.NToC( A129PaymentMethodDiscount, 8, 2, ".", ""))) ;
            ChangePostValue( edtPaymentMethodRecarge_Internalname, StringUtil.LTrim( StringUtil.NToC( A130PaymentMethodRecarge, 8, 2, ".", ""))) ;
            ChangePostValue( edtInvoicePaymentMethodImport_Internalname, StringUtil.LTrim( StringUtil.NToC( A120InvoicePaymentMethodImport, 18, 2, ".", ""))) ;
            ChangePostValue( edtInvoicePaymentMethodRechargeIm_Internalname, StringUtil.LTrim( StringUtil.NToC( A132InvoicePaymentMethodRechargeIm, 18, 2, ".", ""))) ;
            ChangePostValue( edtInvoicePaymentMethodDiscountIm_Internalname, StringUtil.LTrim( StringUtil.NToC( A133InvoicePaymentMethodDiscountIm, 18, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z118InvoicePaymentMethodId_"+sGXsfl_104_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z118InvoicePaymentMethodId), 6, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z120InvoicePaymentMethodImport_"+sGXsfl_104_idx, StringUtil.LTrim( StringUtil.NToC( Z120InvoicePaymentMethodImport, 18, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z132InvoicePaymentMethodRechargeIm_"+sGXsfl_104_idx, StringUtil.LTrim( StringUtil.NToC( Z132InvoicePaymentMethodRechargeIm, 18, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z133InvoicePaymentMethodDiscountIm_"+sGXsfl_104_idx, StringUtil.LTrim( StringUtil.NToC( Z133InvoicePaymentMethodDiscountIm, 18, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z115PaymentMethodId_"+sGXsfl_104_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z115PaymentMethodId), 6, 0, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_21_"+sGXsfl_104_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_21), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_21_"+sGXsfl_104_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_21), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_21_"+sGXsfl_104_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_21), 4, 0, ".", ""))) ;
            if ( nIsMod_21 != 0 )
            {
               ChangePostValue( "INVOICEPAYMENTMETHODID_"+sGXsfl_104_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvoicePaymentMethodId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PAYMENTMETHODID_"+sGXsfl_104_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPaymentMethodId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PAYMENTMETHODDESCRIPTION_"+sGXsfl_104_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPaymentMethodDescription_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PAYMENTMETHODDISCOUNT_"+sGXsfl_104_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPaymentMethodDiscount_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PAYMENTMETHODRECARGE_"+sGXsfl_104_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPaymentMethodRecarge_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVOICEPAYMENTMETHODIMPORT_"+sGXsfl_104_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvoicePaymentMethodImport_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVOICEPAYMENTMETHODRECHARGEIM_"+sGXsfl_104_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvoicePaymentMethodRechargeIm_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVOICEPAYMENTMETHODDISCOUNTIM_"+sGXsfl_104_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvoicePaymentMethodDiscountIm_Enabled), 5, 0, ".", ""))) ;
            }
         }
         O131InvoiceLastPaymentMethodId = s131InvoiceLastPaymentMethodId;
         n131InvoiceLastPaymentMethodId = false;
         AssignAttri("", false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
         /* Start of After( level) rules */
         /* Using cursor T00068 */
         pr_default.execute(3, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            A80InvoiceTotalReceivable = T00068_A80InvoiceTotalReceivable[0];
            n80InvoiceTotalReceivable = T00068_n80InvoiceTotalReceivable[0];
            AssignAttri("", false, "A80InvoiceTotalReceivable", StringUtil.LTrimStr( A80InvoiceTotalReceivable, 18, 2));
         }
         else
         {
            A80InvoiceTotalReceivable = 0;
            n80InvoiceTotalReceivable = false;
            AssignAttri("", false, "A80InvoiceTotalReceivable", StringUtil.LTrimStr( A80InvoiceTotalReceivable, 18, 2));
         }
         /* Using cursor T000610 */
         pr_default.execute(4, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            A131InvoiceLastPaymentMethodId = T000610_A131InvoiceLastPaymentMethodId[0];
            n131InvoiceLastPaymentMethodId = T000610_n131InvoiceLastPaymentMethodId[0];
            AssignAttri("", false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
         }
         else
         {
            A131InvoiceLastPaymentMethodId = 0;
            n131InvoiceLastPaymentMethodId = false;
            AssignAttri("", false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
         }
         /* End of After( level) rules */
      }

      protected void CONFIRM_0613( )
      {
         s97InvoiceLastDetailId = O97InvoiceLastDetailId;
         AssignAttri("", false, "A97InvoiceLastDetailId", StringUtil.LTrimStr( (decimal)(A97InvoiceLastDetailId), 6, 0));
         s68InvoiceProductQuantity = O68InvoiceProductQuantity;
         AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
         nGXsfl_88_idx = 0;
         while ( nGXsfl_88_idx < nRC_GXsfl_88 )
         {
            ReadRow0613( ) ;
            if ( ( nRcdExists_13 != 0 ) || ( nIsMod_13 != 0 ) )
            {
               GetKey0613( ) ;
               if ( ( nRcdExists_13 == 0 ) && ( nRcdDeleted_13 == 0 ) )
               {
                  if ( RcdFound13 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0613( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0613( ) ;
                        CloseExtendedTableCursors0613( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                        O97InvoiceLastDetailId = A97InvoiceLastDetailId;
                        AssignAttri("", false, "A97InvoiceLastDetailId", StringUtil.LTrimStr( (decimal)(A97InvoiceLastDetailId), 6, 0));
                        O68InvoiceProductQuantity = A68InvoiceProductQuantity;
                        AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
                     }
                  }
                  else
                  {
                     GXCCtl = "INVOICEDETAILID_" + sGXsfl_88_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtInvoiceDetailId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound13 != 0 )
                  {
                     if ( nRcdDeleted_13 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0613( ) ;
                        Load0613( ) ;
                        BeforeValidate0613( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0613( ) ;
                           O97InvoiceLastDetailId = A97InvoiceLastDetailId;
                           AssignAttri("", false, "A97InvoiceLastDetailId", StringUtil.LTrimStr( (decimal)(A97InvoiceLastDetailId), 6, 0));
                           O68InvoiceProductQuantity = A68InvoiceProductQuantity;
                           AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
                        }
                     }
                     else
                     {
                        if ( nIsMod_13 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0613( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0613( ) ;
                              CloseExtendedTableCursors0613( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                              O97InvoiceLastDetailId = A97InvoiceLastDetailId;
                              AssignAttri("", false, "A97InvoiceLastDetailId", StringUtil.LTrimStr( (decimal)(A97InvoiceLastDetailId), 6, 0));
                              O68InvoiceProductQuantity = A68InvoiceProductQuantity;
                              AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_13 == 0 )
                     {
                        GXCCtl = "INVOICEDETAILID_" + sGXsfl_88_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtInvoiceDetailId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtInvoiceDetailId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A25InvoiceDetailId), 6, 0, ".", ""))) ;
            ChangePostValue( edtProductId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", ""))) ;
            ChangePostValue( edtProductName_Internalname, A16ProductName) ;
            ChangePostValue( edtProductStock_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A17ProductStock), 6, 0, ".", ""))) ;
            ChangePostValue( edtInvoiceDetailQuantity_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A26InvoiceDetailQuantity), 6, 0, ".", ""))) ;
            ChangePostValue( edtInvoiceDetailHistoricPrice_Internalname, StringUtil.LTrim( StringUtil.NToC( A65InvoiceDetailHistoricPrice, 18, 2, ".", ""))) ;
            ChangePostValue( chkInvoiceDetailIsWholesale_Internalname, StringUtil.BoolToStr( A98InvoiceDetailIsWholesale)) ;
            ChangePostValue( "ZT_"+"Z25InvoiceDetailId_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z25InvoiceDetailId), 6, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z26InvoiceDetailQuantity_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z26InvoiceDetailQuantity), 6, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z65InvoiceDetailHistoricPrice_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( Z65InvoiceDetailHistoricPrice, 18, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z98InvoiceDetailIsWholesale_"+sGXsfl_88_idx, StringUtil.BoolToStr( Z98InvoiceDetailIsWholesale)) ;
            ChangePostValue( "ZT_"+"Z15ProductId_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z15ProductId), 6, 0, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_13_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_13), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_13_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_13), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_13_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_13), 4, 0, ".", ""))) ;
            if ( nIsMod_13 != 0 )
            {
               ChangePostValue( "INVOICEDETAILID_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvoiceDetailId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTID_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTNAME_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTSTOCK_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductStock_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVOICEDETAILQUANTITY_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvoiceDetailQuantity_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVOICEDETAILHISTORICPRICE_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvoiceDetailHistoricPrice_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVOICEDETAILISWHOLESALE_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkInvoiceDetailIsWholesale.Enabled), 5, 0, ".", ""))) ;
            }
         }
         O97InvoiceLastDetailId = s97InvoiceLastDetailId;
         AssignAttri("", false, "A97InvoiceLastDetailId", StringUtil.LTrimStr( (decimal)(A97InvoiceLastDetailId), 6, 0));
         O68InvoiceProductQuantity = s68InvoiceProductQuantity;
         AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
         /* Start of After( level) rules */
         /* Using cursor T00068 */
         pr_default.execute(3, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            A80InvoiceTotalReceivable = T00068_A80InvoiceTotalReceivable[0];
            n80InvoiceTotalReceivable = T00068_n80InvoiceTotalReceivable[0];
            AssignAttri("", false, "A80InvoiceTotalReceivable", StringUtil.LTrimStr( A80InvoiceTotalReceivable, 18, 2));
         }
         else
         {
            A80InvoiceTotalReceivable = 0;
            n80InvoiceTotalReceivable = false;
            AssignAttri("", false, "A80InvoiceTotalReceivable", StringUtil.LTrimStr( A80InvoiceTotalReceivable, 18, 2));
         }
         /* Using cursor T000615 */
         pr_default.execute(8, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            A97InvoiceLastDetailId = T000615_A97InvoiceLastDetailId[0];
            AssignAttri("", false, "A97InvoiceLastDetailId", StringUtil.LTrimStr( (decimal)(A97InvoiceLastDetailId), 6, 0));
         }
         else
         {
            A68InvoiceProductQuantity = 0;
            AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
            A97InvoiceLastDetailId = 0;
            AssignAttri("", false, "A97InvoiceLastDetailId", StringUtil.LTrimStr( (decimal)(A97InvoiceLastDetailId), 6, 0));
         }
         /* End of After( level) rules */
      }

      protected void ResetCaption060( )
      {
      }

      protected void E11062( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtSDTContextSession1 = new GeneXus.Programs.general.ui.SdtSDTContextSession();
         new checkauthentication(context ).execute( out  GXt_SdtSDTContextSession1) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && ! new haspermission(context).executeUdp(  "invoice view") )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV21Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         else if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! new haspermission(context).executeUdp(  "invoice insert") )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV21Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         else if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ! new haspermission(context).executeUdp(  "invoice update") )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV21Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         else if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! new haspermission(context).executeUdp(  "invoice delete") )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV21Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV21Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV21Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         AV14Insert_UserId = 0;
         AssignAttri("", false, "AV14Insert_UserId", StringUtil.LTrimStr( (decimal)(AV14Insert_UserId), 6, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV21Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV22GXV1 = 1;
            AssignAttri("", false, "AV22GXV1", StringUtil.LTrimStr( (decimal)(AV22GXV1), 8, 0));
            while ( AV22GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((GeneXus.Programs.general.ui.SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV22GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "UserId") == 0 )
               {
                  AV14Insert_UserId = (int)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV14Insert_UserId", StringUtil.LTrimStr( (decimal)(AV14Insert_UserId), 6, 0));
               }
               AV22GXV1 = (int)(AV22GXV1+1);
               AssignAttri("", false, "AV22GXV1", StringUtil.LTrimStr( (decimal)(AV22GXV1), 8, 0));
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            bttBtn_enter_Caption = "Delete";
            AssignProp("", false, bttBtn_enter_Internalname, "Caption", bttBtn_enter_Caption, true);
            bttBtn_enter_Tooltiptext = "Delete";
            AssignProp("", false, bttBtn_enter_Internalname, "Tooltiptext", bttBtn_enter_Tooltiptext, true);
         }
         new getcontext(context ).execute( out  AV17Context, ref  AV18AllOk) ;
         AssignAttri("", false, "AV18AllOk", AV18AllOk);
         AV14Insert_UserId = AV17Context.gxTpr_Userid;
         AssignAttri("", false, "AV14Insert_UserId", StringUtil.LTrimStr( (decimal)(AV14Insert_UserId), 6, 0));
      }

      protected void E12062( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwinvoice.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM066( short GX_JID )
      {
         if ( ( GX_JID == 27 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z38InvoiceCreatedDate = T000617_A38InvoiceCreatedDate[0];
               Z39InvoiceModifiedDate = T000617_A39InvoiceModifiedDate[0];
               Z94InvoiceActive = T000617_A94InvoiceActive[0];
               Z99UserId = T000617_A99UserId[0];
            }
            else
            {
               Z38InvoiceCreatedDate = A38InvoiceCreatedDate;
               Z39InvoiceModifiedDate = A39InvoiceModifiedDate;
               Z94InvoiceActive = A94InvoiceActive;
               Z99UserId = A99UserId;
            }
         }
         if ( GX_JID == -27 )
         {
            Z20InvoiceId = A20InvoiceId;
            Z38InvoiceCreatedDate = A38InvoiceCreatedDate;
            Z39InvoiceModifiedDate = A39InvoiceModifiedDate;
            Z94InvoiceActive = A94InvoiceActive;
            Z99UserId = A99UserId;
            Z68InvoiceProductQuantity = A68InvoiceProductQuantity;
            Z97InvoiceLastDetailId = A97InvoiceLastDetailId;
            Z131InvoiceLastPaymentMethodId = A131InvoiceLastPaymentMethodId;
            Z100UserName = A100UserName;
         }
      }

      protected void standaloneNotModal( )
      {
         edtInvoiceId_Enabled = 0;
         AssignProp("", false, edtInvoiceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceId_Enabled), 5, 0), true);
         edtInvoiceLastDetailId_Enabled = 0;
         AssignProp("", false, edtInvoiceLastDetailId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceLastDetailId_Enabled), 5, 0), true);
         edtInvoiceLastPaymentMethodId_Enabled = 0;
         AssignProp("", false, edtInvoiceLastPaymentMethodId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceLastPaymentMethodId_Enabled), 5, 0), true);
         Gx_date = DateTimeUtil.Today( context);
         AssignAttri("", false, "Gx_date", context.localUtil.Format(Gx_date, "99/99/99"));
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         imgprompt_99_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx00g0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"USERID"+"'), id:'"+"USERID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtInvoiceId_Enabled = 0;
         AssignProp("", false, edtInvoiceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceId_Enabled), 5, 0), true);
         edtInvoiceLastDetailId_Enabled = 0;
         AssignProp("", false, edtInvoiceLastDetailId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceLastDetailId_Enabled), 5, 0), true);
         edtInvoiceLastPaymentMethodId_Enabled = 0;
         AssignProp("", false, edtInvoiceLastPaymentMethodId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceLastPaymentMethodId_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV13InvoiceId) )
         {
            A20InvoiceId = AV13InvoiceId;
            AssignAttri("", false, "A20InvoiceId", StringUtil.LTrimStr( (decimal)(A20InvoiceId), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_UserId) )
         {
            edtUserId_Enabled = 0;
            AssignProp("", false, edtUserId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUserId_Enabled), 5, 0), true);
         }
         else
         {
            edtUserId_Enabled = 1;
            AssignProp("", false, edtUserId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUserId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_UserId) )
         {
            A99UserId = AV14Insert_UserId;
            AssignAttri("", false, "A99UserId", StringUtil.LTrimStr( (decimal)(A99UserId), 6, 0));
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
            A38InvoiceCreatedDate = Gx_date;
            AssignAttri("", false, "A38InvoiceCreatedDate", context.localUtil.Format(A38InvoiceCreatedDate, "99/99/99"));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
         {
            A39InvoiceModifiedDate = Gx_date;
            n39InvoiceModifiedDate = false;
            AssignAttri("", false, "A39InvoiceModifiedDate", context.localUtil.Format(A39InvoiceModifiedDate, "99/99/99"));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T00068 */
            pr_default.execute(3, new Object[] {A20InvoiceId});
            if ( (pr_default.getStatus(3) != 101) )
            {
               A80InvoiceTotalReceivable = T00068_A80InvoiceTotalReceivable[0];
               n80InvoiceTotalReceivable = T00068_n80InvoiceTotalReceivable[0];
               AssignAttri("", false, "A80InvoiceTotalReceivable", StringUtil.LTrimStr( A80InvoiceTotalReceivable, 18, 2));
            }
            else
            {
               A80InvoiceTotalReceivable = 0;
               n80InvoiceTotalReceivable = false;
               AssignAttri("", false, "A80InvoiceTotalReceivable", StringUtil.LTrimStr( A80InvoiceTotalReceivable, 18, 2));
            }
            pr_default.close(3);
            /* Using cursor T000615 */
            pr_default.execute(8, new Object[] {A20InvoiceId});
            if ( (pr_default.getStatus(8) != 101) )
            {
               A68InvoiceProductQuantity = T000615_A68InvoiceProductQuantity[0];
               AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
               A97InvoiceLastDetailId = T000615_A97InvoiceLastDetailId[0];
               AssignAttri("", false, "A97InvoiceLastDetailId", StringUtil.LTrimStr( (decimal)(A97InvoiceLastDetailId), 6, 0));
            }
            else
            {
               A68InvoiceProductQuantity = 0;
               AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
               A97InvoiceLastDetailId = 0;
               AssignAttri("", false, "A97InvoiceLastDetailId", StringUtil.LTrimStr( (decimal)(A97InvoiceLastDetailId), 6, 0));
            }
            O68InvoiceProductQuantity = A68InvoiceProductQuantity;
            AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
            O97InvoiceLastDetailId = A97InvoiceLastDetailId;
            AssignAttri("", false, "A97InvoiceLastDetailId", StringUtil.LTrimStr( (decimal)(A97InvoiceLastDetailId), 6, 0));
            pr_default.close(8);
            /* Using cursor T000610 */
            pr_default.execute(4, new Object[] {A20InvoiceId});
            if ( (pr_default.getStatus(4) != 101) )
            {
               A131InvoiceLastPaymentMethodId = T000610_A131InvoiceLastPaymentMethodId[0];
               n131InvoiceLastPaymentMethodId = T000610_n131InvoiceLastPaymentMethodId[0];
               AssignAttri("", false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
            }
            else
            {
               A131InvoiceLastPaymentMethodId = 0;
               n131InvoiceLastPaymentMethodId = false;
               AssignAttri("", false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
            }
            O131InvoiceLastPaymentMethodId = A131InvoiceLastPaymentMethodId;
            n131InvoiceLastPaymentMethodId = false;
            AssignAttri("", false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
            pr_default.close(4);
            AV21Pgmname = "Invoice";
            AssignAttri("", false, "AV21Pgmname", AV21Pgmname);
            /* Using cursor T000618 */
            pr_default.execute(11, new Object[] {A99UserId});
            A100UserName = T000618_A100UserName[0];
            AssignAttri("", false, "A100UserName", A100UserName);
            pr_default.close(11);
         }
      }

      protected void Load066( )
      {
         /* Using cursor T000621 */
         pr_default.execute(12, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound6 = 1;
            A38InvoiceCreatedDate = T000621_A38InvoiceCreatedDate[0];
            AssignAttri("", false, "A38InvoiceCreatedDate", context.localUtil.Format(A38InvoiceCreatedDate, "99/99/99"));
            A100UserName = T000621_A100UserName[0];
            AssignAttri("", false, "A100UserName", A100UserName);
            A39InvoiceModifiedDate = T000621_A39InvoiceModifiedDate[0];
            n39InvoiceModifiedDate = T000621_n39InvoiceModifiedDate[0];
            AssignAttri("", false, "A39InvoiceModifiedDate", context.localUtil.Format(A39InvoiceModifiedDate, "99/99/99"));
            A94InvoiceActive = T000621_A94InvoiceActive[0];
            AssignAttri("", false, "A94InvoiceActive", A94InvoiceActive);
            A99UserId = T000621_A99UserId[0];
            AssignAttri("", false, "A99UserId", StringUtil.LTrimStr( (decimal)(A99UserId), 6, 0));
            A68InvoiceProductQuantity = T000621_A68InvoiceProductQuantity[0];
            AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
            A97InvoiceLastDetailId = T000621_A97InvoiceLastDetailId[0];
            AssignAttri("", false, "A97InvoiceLastDetailId", StringUtil.LTrimStr( (decimal)(A97InvoiceLastDetailId), 6, 0));
            A131InvoiceLastPaymentMethodId = T000621_A131InvoiceLastPaymentMethodId[0];
            n131InvoiceLastPaymentMethodId = T000621_n131InvoiceLastPaymentMethodId[0];
            AssignAttri("", false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
            ZM066( -27) ;
         }
         pr_default.close(12);
         OnLoadActions066( ) ;
      }

      protected void OnLoadActions066( )
      {
         O131InvoiceLastPaymentMethodId = A131InvoiceLastPaymentMethodId;
         n131InvoiceLastPaymentMethodId = false;
         AssignAttri("", false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
         O97InvoiceLastDetailId = A97InvoiceLastDetailId;
         AssignAttri("", false, "A97InvoiceLastDetailId", StringUtil.LTrimStr( (decimal)(A97InvoiceLastDetailId), 6, 0));
         O68InvoiceProductQuantity = A68InvoiceProductQuantity;
         AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
         AV21Pgmname = "Invoice";
         AssignAttri("", false, "AV21Pgmname", AV21Pgmname);
         /* Using cursor T00068 */
         pr_default.execute(3, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            A80InvoiceTotalReceivable = T00068_A80InvoiceTotalReceivable[0];
            n80InvoiceTotalReceivable = T00068_n80InvoiceTotalReceivable[0];
            AssignAttri("", false, "A80InvoiceTotalReceivable", StringUtil.LTrimStr( A80InvoiceTotalReceivable, 18, 2));
         }
         else
         {
            A80InvoiceTotalReceivable = 0;
            n80InvoiceTotalReceivable = false;
            AssignAttri("", false, "A80InvoiceTotalReceivable", StringUtil.LTrimStr( A80InvoiceTotalReceivable, 18, 2));
         }
         pr_default.close(3);
      }

      protected void CheckExtendedTable066( )
      {
         nIsDirty_6 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV21Pgmname = "Invoice";
         AssignAttri("", false, "AV21Pgmname", AV21Pgmname);
         /* Using cursor T00068 */
         pr_default.execute(3, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            A80InvoiceTotalReceivable = T00068_A80InvoiceTotalReceivable[0];
            n80InvoiceTotalReceivable = T00068_n80InvoiceTotalReceivable[0];
            AssignAttri("", false, "A80InvoiceTotalReceivable", StringUtil.LTrimStr( A80InvoiceTotalReceivable, 18, 2));
         }
         else
         {
            nIsDirty_6 = 1;
            A80InvoiceTotalReceivable = 0;
            n80InvoiceTotalReceivable = false;
            AssignAttri("", false, "A80InvoiceTotalReceivable", StringUtil.LTrimStr( A80InvoiceTotalReceivable, 18, 2));
         }
         pr_default.close(3);
         /* Using cursor T000615 */
         pr_default.execute(8, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            A68InvoiceProductQuantity = T000615_A68InvoiceProductQuantity[0];
            AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
            A97InvoiceLastDetailId = T000615_A97InvoiceLastDetailId[0];
            AssignAttri("", false, "A97InvoiceLastDetailId", StringUtil.LTrimStr( (decimal)(A97InvoiceLastDetailId), 6, 0));
         }
         else
         {
            nIsDirty_6 = 1;
            A68InvoiceProductQuantity = 0;
            AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
            nIsDirty_6 = 1;
            A97InvoiceLastDetailId = 0;
            AssignAttri("", false, "A97InvoiceLastDetailId", StringUtil.LTrimStr( (decimal)(A97InvoiceLastDetailId), 6, 0));
         }
         pr_default.close(8);
         /* Using cursor T000610 */
         pr_default.execute(4, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            A131InvoiceLastPaymentMethodId = T000610_A131InvoiceLastPaymentMethodId[0];
            n131InvoiceLastPaymentMethodId = T000610_n131InvoiceLastPaymentMethodId[0];
            AssignAttri("", false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
         }
         else
         {
            nIsDirty_6 = 1;
            A131InvoiceLastPaymentMethodId = 0;
            n131InvoiceLastPaymentMethodId = false;
            AssignAttri("", false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
         }
         pr_default.close(4);
         if ( ! ( (DateTime.MinValue==A38InvoiceCreatedDate) || ( DateTimeUtil.ResetTime ( A38InvoiceCreatedDate ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Invoice Created Date is out of range", "OutOfRange", 1, "INVOICECREATEDDATE");
            AnyError = 1;
            GX_FocusControl = edtInvoiceCreatedDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000618 */
         pr_default.execute(11, new Object[] {A99UserId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No matching 'User'.", "ForeignKeyNotFound", 1, "USERID");
            AnyError = 1;
            GX_FocusControl = edtUserId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A100UserName = T000618_A100UserName[0];
         AssignAttri("", false, "A100UserName", A100UserName);
         pr_default.close(11);
         if ( ! ( (DateTime.MinValue==A39InvoiceModifiedDate) || ( DateTimeUtil.ResetTime ( A39InvoiceModifiedDate ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Invoice Modified Date is out of range", "OutOfRange", 1, "INVOICEMODIFIEDDATE");
            AnyError = 1;
            GX_FocusControl = edtInvoiceModifiedDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors066( )
      {
         pr_default.close(3);
         pr_default.close(8);
         pr_default.close(4);
         pr_default.close(11);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_28( int A20InvoiceId )
      {
         /* Using cursor T000625 */
         pr_default.execute(13, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            A80InvoiceTotalReceivable = T000625_A80InvoiceTotalReceivable[0];
            n80InvoiceTotalReceivable = T000625_n80InvoiceTotalReceivable[0];
            AssignAttri("", false, "A80InvoiceTotalReceivable", StringUtil.LTrimStr( A80InvoiceTotalReceivable, 18, 2));
         }
         else
         {
            A80InvoiceTotalReceivable = 0;
            n80InvoiceTotalReceivable = false;
            AssignAttri("", false, "A80InvoiceTotalReceivable", StringUtil.LTrimStr( A80InvoiceTotalReceivable, 18, 2));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A80InvoiceTotalReceivable, 18, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(13) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(13);
      }

      protected void gxLoad_30( int A20InvoiceId )
      {
         /* Using cursor T000627 */
         pr_default.execute(14, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            A68InvoiceProductQuantity = T000627_A68InvoiceProductQuantity[0];
            AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
            A97InvoiceLastDetailId = T000627_A97InvoiceLastDetailId[0];
            AssignAttri("", false, "A97InvoiceLastDetailId", StringUtil.LTrimStr( (decimal)(A97InvoiceLastDetailId), 6, 0));
         }
         else
         {
            A68InvoiceProductQuantity = 0;
            AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
            A97InvoiceLastDetailId = 0;
            AssignAttri("", false, "A97InvoiceLastDetailId", StringUtil.LTrimStr( (decimal)(A97InvoiceLastDetailId), 6, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A68InvoiceProductQuantity), 4, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A97InvoiceLastDetailId), 6, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(14) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(14);
      }

      protected void gxLoad_31( int A20InvoiceId )
      {
         /* Using cursor T000629 */
         pr_default.execute(15, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            A131InvoiceLastPaymentMethodId = T000629_A131InvoiceLastPaymentMethodId[0];
            n131InvoiceLastPaymentMethodId = T000629_n131InvoiceLastPaymentMethodId[0];
            AssignAttri("", false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
         }
         else
         {
            A131InvoiceLastPaymentMethodId = 0;
            n131InvoiceLastPaymentMethodId = false;
            AssignAttri("", false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(15) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(15);
      }

      protected void gxLoad_29( int A99UserId )
      {
         /* Using cursor T000630 */
         pr_default.execute(16, new Object[] {A99UserId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No matching 'User'.", "ForeignKeyNotFound", 1, "USERID");
            AnyError = 1;
            GX_FocusControl = edtUserId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A100UserName = T000630_A100UserName[0];
         AssignAttri("", false, "A100UserName", A100UserName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A100UserName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(16) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(16);
      }

      protected void GetKey066( )
      {
         /* Using cursor T000631 */
         pr_default.execute(17, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound6 = 1;
         }
         else
         {
            RcdFound6 = 0;
         }
         pr_default.close(17);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000617 */
         pr_default.execute(10, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            ZM066( 27) ;
            RcdFound6 = 1;
            A20InvoiceId = T000617_A20InvoiceId[0];
            AssignAttri("", false, "A20InvoiceId", StringUtil.LTrimStr( (decimal)(A20InvoiceId), 6, 0));
            A38InvoiceCreatedDate = T000617_A38InvoiceCreatedDate[0];
            AssignAttri("", false, "A38InvoiceCreatedDate", context.localUtil.Format(A38InvoiceCreatedDate, "99/99/99"));
            A39InvoiceModifiedDate = T000617_A39InvoiceModifiedDate[0];
            n39InvoiceModifiedDate = T000617_n39InvoiceModifiedDate[0];
            AssignAttri("", false, "A39InvoiceModifiedDate", context.localUtil.Format(A39InvoiceModifiedDate, "99/99/99"));
            A94InvoiceActive = T000617_A94InvoiceActive[0];
            AssignAttri("", false, "A94InvoiceActive", A94InvoiceActive);
            A99UserId = T000617_A99UserId[0];
            AssignAttri("", false, "A99UserId", StringUtil.LTrimStr( (decimal)(A99UserId), 6, 0));
            Z20InvoiceId = A20InvoiceId;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load066( ) ;
            if ( AnyError == 1 )
            {
               RcdFound6 = 0;
               InitializeNonKey066( ) ;
            }
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound6 = 0;
            InitializeNonKey066( ) ;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(10);
      }

      protected void getEqualNoModal( )
      {
         GetKey066( ) ;
         if ( RcdFound6 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound6 = 0;
         /* Using cursor T000632 */
         pr_default.execute(18, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(18) != 101) )
         {
            while ( (pr_default.getStatus(18) != 101) && ( ( T000632_A20InvoiceId[0] < A20InvoiceId ) ) )
            {
               pr_default.readNext(18);
            }
            if ( (pr_default.getStatus(18) != 101) && ( ( T000632_A20InvoiceId[0] > A20InvoiceId ) ) )
            {
               A20InvoiceId = T000632_A20InvoiceId[0];
               AssignAttri("", false, "A20InvoiceId", StringUtil.LTrimStr( (decimal)(A20InvoiceId), 6, 0));
               RcdFound6 = 1;
            }
         }
         pr_default.close(18);
      }

      protected void move_previous( )
      {
         RcdFound6 = 0;
         /* Using cursor T000633 */
         pr_default.execute(19, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(19) != 101) )
         {
            while ( (pr_default.getStatus(19) != 101) && ( ( T000633_A20InvoiceId[0] > A20InvoiceId ) ) )
            {
               pr_default.readNext(19);
            }
            if ( (pr_default.getStatus(19) != 101) && ( ( T000633_A20InvoiceId[0] < A20InvoiceId ) ) )
            {
               A20InvoiceId = T000633_A20InvoiceId[0];
               AssignAttri("", false, "A20InvoiceId", StringUtil.LTrimStr( (decimal)(A20InvoiceId), 6, 0));
               RcdFound6 = 1;
            }
         }
         pr_default.close(19);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey066( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A97InvoiceLastDetailId = O97InvoiceLastDetailId;
            AssignAttri("", false, "A97InvoiceLastDetailId", StringUtil.LTrimStr( (decimal)(A97InvoiceLastDetailId), 6, 0));
            A68InvoiceProductQuantity = O68InvoiceProductQuantity;
            AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
            A131InvoiceLastPaymentMethodId = O131InvoiceLastPaymentMethodId;
            n131InvoiceLastPaymentMethodId = false;
            AssignAttri("", false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
            GX_FocusControl = edtInvoiceCreatedDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert066( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound6 == 1 )
            {
               if ( A20InvoiceId != Z20InvoiceId )
               {
                  A20InvoiceId = Z20InvoiceId;
                  AssignAttri("", false, "A20InvoiceId", StringUtil.LTrimStr( (decimal)(A20InvoiceId), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "INVOICEID");
                  AnyError = 1;
                  GX_FocusControl = edtInvoiceId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  A97InvoiceLastDetailId = O97InvoiceLastDetailId;
                  AssignAttri("", false, "A97InvoiceLastDetailId", StringUtil.LTrimStr( (decimal)(A97InvoiceLastDetailId), 6, 0));
                  A68InvoiceProductQuantity = O68InvoiceProductQuantity;
                  AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
                  A131InvoiceLastPaymentMethodId = O131InvoiceLastPaymentMethodId;
                  n131InvoiceLastPaymentMethodId = false;
                  AssignAttri("", false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtInvoiceCreatedDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  A97InvoiceLastDetailId = O97InvoiceLastDetailId;
                  AssignAttri("", false, "A97InvoiceLastDetailId", StringUtil.LTrimStr( (decimal)(A97InvoiceLastDetailId), 6, 0));
                  A68InvoiceProductQuantity = O68InvoiceProductQuantity;
                  AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
                  A131InvoiceLastPaymentMethodId = O131InvoiceLastPaymentMethodId;
                  n131InvoiceLastPaymentMethodId = false;
                  AssignAttri("", false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
                  Update066( ) ;
                  GX_FocusControl = edtInvoiceCreatedDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A20InvoiceId != Z20InvoiceId )
               {
                  /* Insert record */
                  A97InvoiceLastDetailId = O97InvoiceLastDetailId;
                  AssignAttri("", false, "A97InvoiceLastDetailId", StringUtil.LTrimStr( (decimal)(A97InvoiceLastDetailId), 6, 0));
                  A68InvoiceProductQuantity = O68InvoiceProductQuantity;
                  AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
                  A131InvoiceLastPaymentMethodId = O131InvoiceLastPaymentMethodId;
                  n131InvoiceLastPaymentMethodId = false;
                  AssignAttri("", false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
                  GX_FocusControl = edtInvoiceCreatedDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert066( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "INVOICEID");
                     AnyError = 1;
                     GX_FocusControl = edtInvoiceId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     A97InvoiceLastDetailId = O97InvoiceLastDetailId;
                     AssignAttri("", false, "A97InvoiceLastDetailId", StringUtil.LTrimStr( (decimal)(A97InvoiceLastDetailId), 6, 0));
                     A68InvoiceProductQuantity = O68InvoiceProductQuantity;
                     AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
                     A131InvoiceLastPaymentMethodId = O131InvoiceLastPaymentMethodId;
                     n131InvoiceLastPaymentMethodId = false;
                     AssignAttri("", false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
                     GX_FocusControl = edtInvoiceCreatedDate_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert066( ) ;
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
         if ( A20InvoiceId != Z20InvoiceId )
         {
            A20InvoiceId = Z20InvoiceId;
            AssignAttri("", false, "A20InvoiceId", StringUtil.LTrimStr( (decimal)(A20InvoiceId), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "INVOICEID");
            AnyError = 1;
            GX_FocusControl = edtInvoiceId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            A97InvoiceLastDetailId = O97InvoiceLastDetailId;
            AssignAttri("", false, "A97InvoiceLastDetailId", StringUtil.LTrimStr( (decimal)(A97InvoiceLastDetailId), 6, 0));
            A68InvoiceProductQuantity = O68InvoiceProductQuantity;
            AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
            A131InvoiceLastPaymentMethodId = O131InvoiceLastPaymentMethodId;
            n131InvoiceLastPaymentMethodId = false;
            AssignAttri("", false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtInvoiceCreatedDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency066( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000616 */
            pr_default.execute(9, new Object[] {A20InvoiceId});
            if ( (pr_default.getStatus(9) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Invoice"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(9) == 101) || ( DateTimeUtil.ResetTime ( Z38InvoiceCreatedDate ) != DateTimeUtil.ResetTime ( T000616_A38InvoiceCreatedDate[0] ) ) || ( DateTimeUtil.ResetTime ( Z39InvoiceModifiedDate ) != DateTimeUtil.ResetTime ( T000616_A39InvoiceModifiedDate[0] ) ) || ( Z94InvoiceActive != T000616_A94InvoiceActive[0] ) || ( Z99UserId != T000616_A99UserId[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z38InvoiceCreatedDate ) != DateTimeUtil.ResetTime ( T000616_A38InvoiceCreatedDate[0] ) )
               {
                  GXUtil.WriteLog("invoice:[seudo value changed for attri]"+"InvoiceCreatedDate");
                  GXUtil.WriteLogRaw("Old: ",Z38InvoiceCreatedDate);
                  GXUtil.WriteLogRaw("Current: ",T000616_A38InvoiceCreatedDate[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z39InvoiceModifiedDate ) != DateTimeUtil.ResetTime ( T000616_A39InvoiceModifiedDate[0] ) )
               {
                  GXUtil.WriteLog("invoice:[seudo value changed for attri]"+"InvoiceModifiedDate");
                  GXUtil.WriteLogRaw("Old: ",Z39InvoiceModifiedDate);
                  GXUtil.WriteLogRaw("Current: ",T000616_A39InvoiceModifiedDate[0]);
               }
               if ( Z94InvoiceActive != T000616_A94InvoiceActive[0] )
               {
                  GXUtil.WriteLog("invoice:[seudo value changed for attri]"+"InvoiceActive");
                  GXUtil.WriteLogRaw("Old: ",Z94InvoiceActive);
                  GXUtil.WriteLogRaw("Current: ",T000616_A94InvoiceActive[0]);
               }
               if ( Z99UserId != T000616_A99UserId[0] )
               {
                  GXUtil.WriteLog("invoice:[seudo value changed for attri]"+"UserId");
                  GXUtil.WriteLogRaw("Old: ",Z99UserId);
                  GXUtil.WriteLogRaw("Current: ",T000616_A99UserId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Invoice"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert066( )
      {
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable066( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM066( 0) ;
            CheckOptimisticConcurrency066( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm066( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert066( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000634 */
                     pr_default.execute(20, new Object[] {A38InvoiceCreatedDate, n39InvoiceModifiedDate, A39InvoiceModifiedDate, A94InvoiceActive, A99UserId});
                     A20InvoiceId = T000634_A20InvoiceId[0];
                     AssignAttri("", false, "A20InvoiceId", StringUtil.LTrimStr( (decimal)(A20InvoiceId), 6, 0));
                     pr_default.close(20);
                     pr_default.SmartCacheProvider.SetUpdated("Invoice");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel066( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption060( ) ;
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
               Load066( ) ;
            }
            EndLevel066( ) ;
         }
         CloseExtendedTableCursors066( ) ;
      }

      protected void Update066( )
      {
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable066( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency066( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm066( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate066( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000635 */
                     pr_default.execute(21, new Object[] {A38InvoiceCreatedDate, n39InvoiceModifiedDate, A39InvoiceModifiedDate, A94InvoiceActive, A99UserId, A20InvoiceId});
                     pr_default.close(21);
                     pr_default.SmartCacheProvider.SetUpdated("Invoice");
                     if ( (pr_default.getStatus(21) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Invoice"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate066( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel066( ) ;
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
            EndLevel066( ) ;
         }
         CloseExtendedTableCursors066( ) ;
      }

      protected void DeferredUpdate066( )
      {
      }

      protected void delete( )
      {
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency066( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls066( ) ;
            AfterConfirm066( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete066( ) ;
               if ( AnyError == 0 )
               {
                  A131InvoiceLastPaymentMethodId = O131InvoiceLastPaymentMethodId;
                  n131InvoiceLastPaymentMethodId = false;
                  AssignAttri("", false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
                  ScanStart0621( ) ;
                  while ( RcdFound21 != 0 )
                  {
                     getByPrimaryKey0621( ) ;
                     Delete0621( ) ;
                     ScanNext0621( ) ;
                     O131InvoiceLastPaymentMethodId = A131InvoiceLastPaymentMethodId;
                     n131InvoiceLastPaymentMethodId = false;
                     AssignAttri("", false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
                  }
                  ScanEnd0621( ) ;
                  A97InvoiceLastDetailId = O97InvoiceLastDetailId;
                  AssignAttri("", false, "A97InvoiceLastDetailId", StringUtil.LTrimStr( (decimal)(A97InvoiceLastDetailId), 6, 0));
                  A68InvoiceProductQuantity = O68InvoiceProductQuantity;
                  AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
                  ScanStart0613( ) ;
                  while ( RcdFound13 != 0 )
                  {
                     getByPrimaryKey0613( ) ;
                     Delete0613( ) ;
                     ScanNext0613( ) ;
                     O97InvoiceLastDetailId = A97InvoiceLastDetailId;
                     AssignAttri("", false, "A97InvoiceLastDetailId", StringUtil.LTrimStr( (decimal)(A97InvoiceLastDetailId), 6, 0));
                     O68InvoiceProductQuantity = A68InvoiceProductQuantity;
                     AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
                  }
                  ScanEnd0613( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000636 */
                     pr_default.execute(22, new Object[] {A20InvoiceId});
                     pr_default.close(22);
                     pr_default.SmartCacheProvider.SetUpdated("Invoice");
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
         sMode6 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel066( ) ;
         Gx_mode = sMode6;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls066( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV21Pgmname = "Invoice";
            AssignAttri("", false, "AV21Pgmname", AV21Pgmname);
            /* Using cursor T000640 */
            pr_default.execute(23, new Object[] {A20InvoiceId});
            if ( (pr_default.getStatus(23) != 101) )
            {
               A80InvoiceTotalReceivable = T000640_A80InvoiceTotalReceivable[0];
               n80InvoiceTotalReceivable = T000640_n80InvoiceTotalReceivable[0];
               AssignAttri("", false, "A80InvoiceTotalReceivable", StringUtil.LTrimStr( A80InvoiceTotalReceivable, 18, 2));
            }
            else
            {
               A80InvoiceTotalReceivable = 0;
               n80InvoiceTotalReceivable = false;
               AssignAttri("", false, "A80InvoiceTotalReceivable", StringUtil.LTrimStr( A80InvoiceTotalReceivable, 18, 2));
            }
            pr_default.close(23);
            /* Using cursor T000642 */
            pr_default.execute(24, new Object[] {A20InvoiceId});
            if ( (pr_default.getStatus(24) != 101) )
            {
               A68InvoiceProductQuantity = T000642_A68InvoiceProductQuantity[0];
               AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
               A97InvoiceLastDetailId = T000642_A97InvoiceLastDetailId[0];
               AssignAttri("", false, "A97InvoiceLastDetailId", StringUtil.LTrimStr( (decimal)(A97InvoiceLastDetailId), 6, 0));
            }
            else
            {
               A68InvoiceProductQuantity = 0;
               AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
               A97InvoiceLastDetailId = 0;
               AssignAttri("", false, "A97InvoiceLastDetailId", StringUtil.LTrimStr( (decimal)(A97InvoiceLastDetailId), 6, 0));
            }
            pr_default.close(24);
            /* Using cursor T000644 */
            pr_default.execute(25, new Object[] {A20InvoiceId});
            if ( (pr_default.getStatus(25) != 101) )
            {
               A131InvoiceLastPaymentMethodId = T000644_A131InvoiceLastPaymentMethodId[0];
               n131InvoiceLastPaymentMethodId = T000644_n131InvoiceLastPaymentMethodId[0];
               AssignAttri("", false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
            }
            else
            {
               A131InvoiceLastPaymentMethodId = 0;
               n131InvoiceLastPaymentMethodId = false;
               AssignAttri("", false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
            }
            pr_default.close(25);
            /* Using cursor T000645 */
            pr_default.execute(26, new Object[] {A99UserId});
            A100UserName = T000645_A100UserName[0];
            AssignAttri("", false, "A100UserName", A100UserName);
            pr_default.close(26);
         }
      }

      protected void ProcessNestedLevel0613( )
      {
         s97InvoiceLastDetailId = O97InvoiceLastDetailId;
         AssignAttri("", false, "A97InvoiceLastDetailId", StringUtil.LTrimStr( (decimal)(A97InvoiceLastDetailId), 6, 0));
         s68InvoiceProductQuantity = O68InvoiceProductQuantity;
         AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
         nGXsfl_88_idx = 0;
         while ( nGXsfl_88_idx < nRC_GXsfl_88 )
         {
            ReadRow0613( ) ;
            if ( ( nRcdExists_13 != 0 ) || ( nIsMod_13 != 0 ) )
            {
               standaloneNotModal0613( ) ;
               GetKey0613( ) ;
               if ( ( nRcdExists_13 == 0 ) && ( nRcdDeleted_13 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0613( ) ;
               }
               else
               {
                  if ( RcdFound13 != 0 )
                  {
                     if ( ( nRcdDeleted_13 != 0 ) && ( nRcdExists_13 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0613( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_13 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0613( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_13 == 0 )
                     {
                        GXCCtl = "INVOICEDETAILID_" + sGXsfl_88_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtInvoiceDetailId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
               O97InvoiceLastDetailId = A97InvoiceLastDetailId;
               AssignAttri("", false, "A97InvoiceLastDetailId", StringUtil.LTrimStr( (decimal)(A97InvoiceLastDetailId), 6, 0));
               O68InvoiceProductQuantity = A68InvoiceProductQuantity;
               AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
            }
            ChangePostValue( edtInvoiceDetailId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A25InvoiceDetailId), 6, 0, ".", ""))) ;
            ChangePostValue( edtProductId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", ""))) ;
            ChangePostValue( edtProductName_Internalname, A16ProductName) ;
            ChangePostValue( edtProductStock_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A17ProductStock), 6, 0, ".", ""))) ;
            ChangePostValue( edtInvoiceDetailQuantity_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A26InvoiceDetailQuantity), 6, 0, ".", ""))) ;
            ChangePostValue( edtInvoiceDetailHistoricPrice_Internalname, StringUtil.LTrim( StringUtil.NToC( A65InvoiceDetailHistoricPrice, 18, 2, ".", ""))) ;
            ChangePostValue( chkInvoiceDetailIsWholesale_Internalname, StringUtil.BoolToStr( A98InvoiceDetailIsWholesale)) ;
            ChangePostValue( "ZT_"+"Z25InvoiceDetailId_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z25InvoiceDetailId), 6, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z26InvoiceDetailQuantity_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z26InvoiceDetailQuantity), 6, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z65InvoiceDetailHistoricPrice_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( Z65InvoiceDetailHistoricPrice, 18, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z98InvoiceDetailIsWholesale_"+sGXsfl_88_idx, StringUtil.BoolToStr( Z98InvoiceDetailIsWholesale)) ;
            ChangePostValue( "ZT_"+"Z15ProductId_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z15ProductId), 6, 0, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_13_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_13), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_13_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_13), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_13_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_13), 4, 0, ".", ""))) ;
            if ( nIsMod_13 != 0 )
            {
               ChangePostValue( "INVOICEDETAILID_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvoiceDetailId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTID_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTNAME_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTSTOCK_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductStock_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVOICEDETAILQUANTITY_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvoiceDetailQuantity_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVOICEDETAILHISTORICPRICE_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvoiceDetailHistoricPrice_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVOICEDETAILISWHOLESALE_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkInvoiceDetailIsWholesale.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* Using cursor T000640 */
         pr_default.execute(23, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(23) != 101) )
         {
            A80InvoiceTotalReceivable = T000640_A80InvoiceTotalReceivable[0];
            n80InvoiceTotalReceivable = T000640_n80InvoiceTotalReceivable[0];
            AssignAttri("", false, "A80InvoiceTotalReceivable", StringUtil.LTrimStr( A80InvoiceTotalReceivable, 18, 2));
         }
         else
         {
            A80InvoiceTotalReceivable = 0;
            n80InvoiceTotalReceivable = false;
            AssignAttri("", false, "A80InvoiceTotalReceivable", StringUtil.LTrimStr( A80InvoiceTotalReceivable, 18, 2));
         }
         /* Using cursor T000642 */
         pr_default.execute(24, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(24) != 101) )
         {
            A97InvoiceLastDetailId = T000642_A97InvoiceLastDetailId[0];
            AssignAttri("", false, "A97InvoiceLastDetailId", StringUtil.LTrimStr( (decimal)(A97InvoiceLastDetailId), 6, 0));
         }
         else
         {
            A68InvoiceProductQuantity = 0;
            AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
            A97InvoiceLastDetailId = 0;
            AssignAttri("", false, "A97InvoiceLastDetailId", StringUtil.LTrimStr( (decimal)(A97InvoiceLastDetailId), 6, 0));
         }
         /* End of After( level) rules */
         InitAll0613( ) ;
         if ( AnyError != 0 )
         {
            O97InvoiceLastDetailId = s97InvoiceLastDetailId;
            AssignAttri("", false, "A97InvoiceLastDetailId", StringUtil.LTrimStr( (decimal)(A97InvoiceLastDetailId), 6, 0));
            O68InvoiceProductQuantity = s68InvoiceProductQuantity;
            AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
         }
         nRcdExists_13 = 0;
         nIsMod_13 = 0;
         nRcdDeleted_13 = 0;
      }

      protected void ProcessNestedLevel0621( )
      {
         s131InvoiceLastPaymentMethodId = O131InvoiceLastPaymentMethodId;
         n131InvoiceLastPaymentMethodId = false;
         AssignAttri("", false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
         nGXsfl_104_idx = 0;
         while ( nGXsfl_104_idx < nRC_GXsfl_104 )
         {
            ReadRow0621( ) ;
            if ( ( nRcdExists_21 != 0 ) || ( nIsMod_21 != 0 ) )
            {
               standaloneNotModal0621( ) ;
               GetKey0621( ) ;
               if ( ( nRcdExists_21 == 0 ) && ( nRcdDeleted_21 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0621( ) ;
               }
               else
               {
                  if ( RcdFound21 != 0 )
                  {
                     if ( ( nRcdDeleted_21 != 0 ) && ( nRcdExists_21 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0621( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_21 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0621( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_21 == 0 )
                     {
                        GXCCtl = "INVOICEPAYMENTMETHODID_" + sGXsfl_104_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtInvoicePaymentMethodId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
               O131InvoiceLastPaymentMethodId = A131InvoiceLastPaymentMethodId;
               n131InvoiceLastPaymentMethodId = false;
               AssignAttri("", false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
            }
            ChangePostValue( edtInvoicePaymentMethodId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A118InvoicePaymentMethodId), 6, 0, ".", ""))) ;
            ChangePostValue( edtPaymentMethodId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A115PaymentMethodId), 6, 0, ".", ""))) ;
            ChangePostValue( edtPaymentMethodDescription_Internalname, A116PaymentMethodDescription) ;
            ChangePostValue( edtPaymentMethodDiscount_Internalname, StringUtil.LTrim( StringUtil.NToC( A129PaymentMethodDiscount, 8, 2, ".", ""))) ;
            ChangePostValue( edtPaymentMethodRecarge_Internalname, StringUtil.LTrim( StringUtil.NToC( A130PaymentMethodRecarge, 8, 2, ".", ""))) ;
            ChangePostValue( edtInvoicePaymentMethodImport_Internalname, StringUtil.LTrim( StringUtil.NToC( A120InvoicePaymentMethodImport, 18, 2, ".", ""))) ;
            ChangePostValue( edtInvoicePaymentMethodRechargeIm_Internalname, StringUtil.LTrim( StringUtil.NToC( A132InvoicePaymentMethodRechargeIm, 18, 2, ".", ""))) ;
            ChangePostValue( edtInvoicePaymentMethodDiscountIm_Internalname, StringUtil.LTrim( StringUtil.NToC( A133InvoicePaymentMethodDiscountIm, 18, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z118InvoicePaymentMethodId_"+sGXsfl_104_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z118InvoicePaymentMethodId), 6, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z120InvoicePaymentMethodImport_"+sGXsfl_104_idx, StringUtil.LTrim( StringUtil.NToC( Z120InvoicePaymentMethodImport, 18, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z132InvoicePaymentMethodRechargeIm_"+sGXsfl_104_idx, StringUtil.LTrim( StringUtil.NToC( Z132InvoicePaymentMethodRechargeIm, 18, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z133InvoicePaymentMethodDiscountIm_"+sGXsfl_104_idx, StringUtil.LTrim( StringUtil.NToC( Z133InvoicePaymentMethodDiscountIm, 18, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z115PaymentMethodId_"+sGXsfl_104_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z115PaymentMethodId), 6, 0, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_21_"+sGXsfl_104_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_21), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_21_"+sGXsfl_104_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_21), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_21_"+sGXsfl_104_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_21), 4, 0, ".", ""))) ;
            if ( nIsMod_21 != 0 )
            {
               ChangePostValue( "INVOICEPAYMENTMETHODID_"+sGXsfl_104_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvoicePaymentMethodId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PAYMENTMETHODID_"+sGXsfl_104_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPaymentMethodId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PAYMENTMETHODDESCRIPTION_"+sGXsfl_104_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPaymentMethodDescription_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PAYMENTMETHODDISCOUNT_"+sGXsfl_104_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPaymentMethodDiscount_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PAYMENTMETHODRECARGE_"+sGXsfl_104_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPaymentMethodRecarge_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVOICEPAYMENTMETHODIMPORT_"+sGXsfl_104_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvoicePaymentMethodImport_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVOICEPAYMENTMETHODRECHARGEIM_"+sGXsfl_104_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvoicePaymentMethodRechargeIm_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVOICEPAYMENTMETHODDISCOUNTIM_"+sGXsfl_104_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvoicePaymentMethodDiscountIm_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* Using cursor T000640 */
         pr_default.execute(23, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(23) != 101) )
         {
            A80InvoiceTotalReceivable = T000640_A80InvoiceTotalReceivable[0];
            n80InvoiceTotalReceivable = T000640_n80InvoiceTotalReceivable[0];
            AssignAttri("", false, "A80InvoiceTotalReceivable", StringUtil.LTrimStr( A80InvoiceTotalReceivable, 18, 2));
         }
         else
         {
            A80InvoiceTotalReceivable = 0;
            n80InvoiceTotalReceivable = false;
            AssignAttri("", false, "A80InvoiceTotalReceivable", StringUtil.LTrimStr( A80InvoiceTotalReceivable, 18, 2));
         }
         /* Using cursor T000644 */
         pr_default.execute(25, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(25) != 101) )
         {
            A131InvoiceLastPaymentMethodId = T000644_A131InvoiceLastPaymentMethodId[0];
            n131InvoiceLastPaymentMethodId = T000644_n131InvoiceLastPaymentMethodId[0];
            AssignAttri("", false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
         }
         else
         {
            A131InvoiceLastPaymentMethodId = 0;
            n131InvoiceLastPaymentMethodId = false;
            AssignAttri("", false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
         }
         /* End of After( level) rules */
         InitAll0621( ) ;
         if ( AnyError != 0 )
         {
            O131InvoiceLastPaymentMethodId = s131InvoiceLastPaymentMethodId;
            n131InvoiceLastPaymentMethodId = false;
            AssignAttri("", false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
         }
         nRcdExists_21 = 0;
         nIsMod_21 = 0;
         nRcdDeleted_21 = 0;
      }

      protected void ProcessLevel066( )
      {
         /* Save parent mode. */
         sMode6 = Gx_mode;
         ProcessNestedLevel0613( ) ;
         ProcessNestedLevel0621( ) ;
         if ( AnyError != 0 )
         {
            O97InvoiceLastDetailId = s97InvoiceLastDetailId;
            AssignAttri("", false, "A97InvoiceLastDetailId", StringUtil.LTrimStr( (decimal)(A97InvoiceLastDetailId), 6, 0));
            O68InvoiceProductQuantity = s68InvoiceProductQuantity;
            AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
            O131InvoiceLastPaymentMethodId = s131InvoiceLastPaymentMethodId;
            n131InvoiceLastPaymentMethodId = false;
            AssignAttri("", false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
         }
         /* Restore parent mode. */
         Gx_mode = sMode6;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel066( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(9);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete066( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(10);
            pr_default.close(6);
            pr_default.close(5);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(23);
            pr_default.close(26);
            pr_default.close(24);
            pr_default.close(25);
            pr_default.close(7);
            pr_default.close(2);
            context.CommitDataStores("invoice",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues060( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(10);
            pr_default.close(6);
            pr_default.close(5);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(23);
            pr_default.close(26);
            pr_default.close(24);
            pr_default.close(25);
            pr_default.close(7);
            pr_default.close(2);
            context.RollbackDataStores("invoice",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart066( )
      {
         /* Scan By routine */
         /* Using cursor T000646 */
         pr_default.execute(27);
         RcdFound6 = 0;
         if ( (pr_default.getStatus(27) != 101) )
         {
            RcdFound6 = 1;
            A20InvoiceId = T000646_A20InvoiceId[0];
            AssignAttri("", false, "A20InvoiceId", StringUtil.LTrimStr( (decimal)(A20InvoiceId), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext066( )
      {
         /* Scan next routine */
         pr_default.readNext(27);
         RcdFound6 = 0;
         if ( (pr_default.getStatus(27) != 101) )
         {
            RcdFound6 = 1;
            A20InvoiceId = T000646_A20InvoiceId[0];
            AssignAttri("", false, "A20InvoiceId", StringUtil.LTrimStr( (decimal)(A20InvoiceId), 6, 0));
         }
      }

      protected void ScanEnd066( )
      {
         pr_default.close(27);
      }

      protected void AfterConfirm066( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert066( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate066( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete066( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete066( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate066( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes066( )
      {
         edtInvoiceId_Enabled = 0;
         AssignProp("", false, edtInvoiceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceId_Enabled), 5, 0), true);
         edtInvoiceCreatedDate_Enabled = 0;
         AssignProp("", false, edtInvoiceCreatedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceCreatedDate_Enabled), 5, 0), true);
         edtUserId_Enabled = 0;
         AssignProp("", false, edtUserId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUserId_Enabled), 5, 0), true);
         edtUserName_Enabled = 0;
         AssignProp("", false, edtUserName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUserName_Enabled), 5, 0), true);
         edtInvoiceModifiedDate_Enabled = 0;
         AssignProp("", false, edtInvoiceModifiedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceModifiedDate_Enabled), 5, 0), true);
         chkInvoiceActive.Enabled = 0;
         AssignProp("", false, chkInvoiceActive_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkInvoiceActive.Enabled), 5, 0), true);
         edtInvoiceTotalReceivable_Enabled = 0;
         AssignProp("", false, edtInvoiceTotalReceivable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceTotalReceivable_Enabled), 5, 0), true);
         edtInvoiceProductQuantity_Enabled = 0;
         AssignProp("", false, edtInvoiceProductQuantity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceProductQuantity_Enabled), 5, 0), true);
         edtInvoiceLastDetailId_Enabled = 0;
         AssignProp("", false, edtInvoiceLastDetailId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceLastDetailId_Enabled), 5, 0), true);
         edtInvoiceLastPaymentMethodId_Enabled = 0;
         AssignProp("", false, edtInvoiceLastPaymentMethodId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceLastPaymentMethodId_Enabled), 5, 0), true);
      }

      protected void ZM0613( short GX_JID )
      {
         if ( ( GX_JID == 32 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z26InvoiceDetailQuantity = T000612_A26InvoiceDetailQuantity[0];
               Z65InvoiceDetailHistoricPrice = T000612_A65InvoiceDetailHistoricPrice[0];
               Z98InvoiceDetailIsWholesale = T000612_A98InvoiceDetailIsWholesale[0];
               Z15ProductId = T000612_A15ProductId[0];
            }
            else
            {
               Z26InvoiceDetailQuantity = A26InvoiceDetailQuantity;
               Z65InvoiceDetailHistoricPrice = A65InvoiceDetailHistoricPrice;
               Z98InvoiceDetailIsWholesale = A98InvoiceDetailIsWholesale;
               Z15ProductId = A15ProductId;
            }
         }
         if ( GX_JID == -32 )
         {
            Z20InvoiceId = A20InvoiceId;
            Z25InvoiceDetailId = A25InvoiceDetailId;
            Z26InvoiceDetailQuantity = A26InvoiceDetailQuantity;
            Z65InvoiceDetailHistoricPrice = A65InvoiceDetailHistoricPrice;
            Z98InvoiceDetailIsWholesale = A98InvoiceDetailIsWholesale;
            Z15ProductId = A15ProductId;
            Z16ProductName = A16ProductName;
            Z17ProductStock = A17ProductStock;
         }
      }

      protected void standaloneNotModal0613( )
      {
         edtInvoiceLastDetailId_Enabled = 0;
         AssignProp("", false, edtInvoiceLastDetailId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceLastDetailId_Enabled), 5, 0), true);
         edtInvoiceLastDetailId_Enabled = 0;
         AssignProp("", false, edtInvoiceLastDetailId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceLastDetailId_Enabled), 5, 0), true);
      }

      protected void standaloneModal0613( )
      {
         if ( IsIns( )  )
         {
            A97InvoiceLastDetailId = (int)(O97InvoiceLastDetailId+1);
            AssignAttri("", false, "A97InvoiceLastDetailId", StringUtil.LTrimStr( (decimal)(A97InvoiceLastDetailId), 6, 0));
         }
         if ( IsIns( )  && ( Gx_BScreen == 1 ) )
         {
            A25InvoiceDetailId = A97InvoiceLastDetailId;
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtInvoiceDetailId_Enabled = 0;
            AssignProp("", false, edtInvoiceDetailId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceDetailId_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         }
         else
         {
            edtInvoiceDetailId_Enabled = 1;
            AssignProp("", false, edtInvoiceDetailId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceDetailId_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         }
      }

      protected void Load0613( )
      {
         /* Using cursor T000647 */
         pr_default.execute(28, new Object[] {A20InvoiceId, A25InvoiceDetailId});
         if ( (pr_default.getStatus(28) != 101) )
         {
            RcdFound13 = 1;
            A16ProductName = T000647_A16ProductName[0];
            A17ProductStock = T000647_A17ProductStock[0];
            n17ProductStock = T000647_n17ProductStock[0];
            A26InvoiceDetailQuantity = T000647_A26InvoiceDetailQuantity[0];
            A65InvoiceDetailHistoricPrice = T000647_A65InvoiceDetailHistoricPrice[0];
            A98InvoiceDetailIsWholesale = T000647_A98InvoiceDetailIsWholesale[0];
            A15ProductId = T000647_A15ProductId[0];
            ZM0613( -32) ;
         }
         pr_default.close(28);
         OnLoadActions0613( ) ;
      }

      protected void OnLoadActions0613( )
      {
         if ( IsIns( )  )
         {
            A68InvoiceProductQuantity = (short)(O68InvoiceProductQuantity+1);
            AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
         }
         else
         {
            if ( IsUpd( )  )
            {
               A68InvoiceProductQuantity = O68InvoiceProductQuantity;
               AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
            }
            else
            {
               if ( IsDlt( )  )
               {
                  A68InvoiceProductQuantity = (short)(O68InvoiceProductQuantity-1);
                  AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
               }
            }
         }
      }

      protected void CheckExtendedTable0613( )
      {
         nIsDirty_13 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal0613( ) ;
         if ( IsIns( )  )
         {
            nIsDirty_13 = 1;
            A68InvoiceProductQuantity = (short)(O68InvoiceProductQuantity+1);
            AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
         }
         else
         {
            if ( IsUpd( )  )
            {
               nIsDirty_13 = 1;
               A68InvoiceProductQuantity = O68InvoiceProductQuantity;
               AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
            }
            else
            {
               if ( IsDlt( )  )
               {
                  nIsDirty_13 = 1;
                  A68InvoiceProductQuantity = (short)(O68InvoiceProductQuantity-1);
                  AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
               }
            }
         }
         /* Using cursor T000613 */
         pr_default.execute(7, new Object[] {A15ProductId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GXCCtl = "PRODUCTID_" + sGXsfl_88_idx;
            GX_msglist.addItem("No matching 'Product'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProductId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A16ProductName = T000613_A16ProductName[0];
         A17ProductStock = T000613_A17ProductStock[0];
         n17ProductStock = T000613_n17ProductStock[0];
         pr_default.close(7);
         if ( A26InvoiceDetailQuantity > A17ProductStock )
         {
            GXCCtl = "INVOICEDETAILQUANTITY_" + sGXsfl_88_idx;
            GX_msglist.addItem("Quantity must be lower or equal than Stock", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtInvoiceDetailQuantity_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( A26InvoiceDetailQuantity <= 0 )
         {
            GXCCtl = "INVOICEDETAILQUANTITY_" + sGXsfl_88_idx;
            GX_msglist.addItem("Quantity must be positive number", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtInvoiceDetailQuantity_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( ( A65InvoiceDetailHistoricPrice >= Convert.ToDecimal( 0 )) && ( A65InvoiceDetailHistoricPrice <= 999999999999999.99m ) ) ) )
         {
            GXCCtl = "INVOICEDETAILHISTORICPRICE_" + sGXsfl_88_idx;
            GX_msglist.addItem("Invalid Price", "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtInvoiceDetailHistoricPrice_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0613( )
      {
         pr_default.close(7);
      }

      protected void enableDisable0613( )
      {
      }

      protected void gxLoad_33( int A15ProductId )
      {
         /* Using cursor T000648 */
         pr_default.execute(29, new Object[] {A15ProductId});
         if ( (pr_default.getStatus(29) == 101) )
         {
            GXCCtl = "PRODUCTID_" + sGXsfl_88_idx;
            GX_msglist.addItem("No matching 'Product'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProductId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A16ProductName = T000648_A16ProductName[0];
         A17ProductStock = T000648_A17ProductStock[0];
         n17ProductStock = T000648_n17ProductStock[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A16ProductName)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A17ProductStock), 6, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(29) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(29);
      }

      protected void GetKey0613( )
      {
         /* Using cursor T000649 */
         pr_default.execute(30, new Object[] {A20InvoiceId, A25InvoiceDetailId});
         if ( (pr_default.getStatus(30) != 101) )
         {
            RcdFound13 = 1;
         }
         else
         {
            RcdFound13 = 0;
         }
         pr_default.close(30);
      }

      protected void getByPrimaryKey0613( )
      {
         /* Using cursor T000612 */
         pr_default.execute(6, new Object[] {A20InvoiceId, A25InvoiceDetailId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            ZM0613( 32) ;
            RcdFound13 = 1;
            InitializeNonKey0613( ) ;
            A25InvoiceDetailId = T000612_A25InvoiceDetailId[0];
            A26InvoiceDetailQuantity = T000612_A26InvoiceDetailQuantity[0];
            A65InvoiceDetailHistoricPrice = T000612_A65InvoiceDetailHistoricPrice[0];
            A98InvoiceDetailIsWholesale = T000612_A98InvoiceDetailIsWholesale[0];
            A15ProductId = T000612_A15ProductId[0];
            Z20InvoiceId = A20InvoiceId;
            Z25InvoiceDetailId = A25InvoiceDetailId;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0613( ) ;
            Gx_mode = sMode13;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound13 = 0;
            InitializeNonKey0613( ) ;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0613( ) ;
            Gx_mode = sMode13;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0613( ) ;
         }
         pr_default.close(6);
      }

      protected void CheckOptimisticConcurrency0613( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000611 */
            pr_default.execute(5, new Object[] {A20InvoiceId, A25InvoiceDetailId});
            if ( (pr_default.getStatus(5) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"InvoiceDetail"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(5) == 101) || ( Z26InvoiceDetailQuantity != T000611_A26InvoiceDetailQuantity[0] ) || ( Z65InvoiceDetailHistoricPrice != T000611_A65InvoiceDetailHistoricPrice[0] ) || ( Z98InvoiceDetailIsWholesale != T000611_A98InvoiceDetailIsWholesale[0] ) || ( Z15ProductId != T000611_A15ProductId[0] ) )
            {
               if ( Z26InvoiceDetailQuantity != T000611_A26InvoiceDetailQuantity[0] )
               {
                  GXUtil.WriteLog("invoice:[seudo value changed for attri]"+"InvoiceDetailQuantity");
                  GXUtil.WriteLogRaw("Old: ",Z26InvoiceDetailQuantity);
                  GXUtil.WriteLogRaw("Current: ",T000611_A26InvoiceDetailQuantity[0]);
               }
               if ( Z65InvoiceDetailHistoricPrice != T000611_A65InvoiceDetailHistoricPrice[0] )
               {
                  GXUtil.WriteLog("invoice:[seudo value changed for attri]"+"InvoiceDetailHistoricPrice");
                  GXUtil.WriteLogRaw("Old: ",Z65InvoiceDetailHistoricPrice);
                  GXUtil.WriteLogRaw("Current: ",T000611_A65InvoiceDetailHistoricPrice[0]);
               }
               if ( Z98InvoiceDetailIsWholesale != T000611_A98InvoiceDetailIsWholesale[0] )
               {
                  GXUtil.WriteLog("invoice:[seudo value changed for attri]"+"InvoiceDetailIsWholesale");
                  GXUtil.WriteLogRaw("Old: ",Z98InvoiceDetailIsWholesale);
                  GXUtil.WriteLogRaw("Current: ",T000611_A98InvoiceDetailIsWholesale[0]);
               }
               if ( Z15ProductId != T000611_A15ProductId[0] )
               {
                  GXUtil.WriteLog("invoice:[seudo value changed for attri]"+"ProductId");
                  GXUtil.WriteLogRaw("Old: ",Z15ProductId);
                  GXUtil.WriteLogRaw("Current: ",T000611_A15ProductId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"InvoiceDetail"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0613( )
      {
         BeforeValidate0613( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0613( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0613( 0) ;
            CheckOptimisticConcurrency0613( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0613( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0613( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000650 */
                     pr_default.execute(31, new Object[] {A20InvoiceId, A25InvoiceDetailId, A26InvoiceDetailQuantity, A65InvoiceDetailHistoricPrice, A98InvoiceDetailIsWholesale, A15ProductId});
                     pr_default.close(31);
                     pr_default.SmartCacheProvider.SetUpdated("InvoiceDetail");
                     if ( (pr_default.getStatus(31) == 1) )
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
               Load0613( ) ;
            }
            EndLevel0613( ) ;
         }
         CloseExtendedTableCursors0613( ) ;
      }

      protected void Update0613( )
      {
         BeforeValidate0613( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0613( ) ;
         }
         if ( ( nIsMod_13 != 0 ) || ( nIsDirty_13 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0613( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0613( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0613( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000651 */
                        pr_default.execute(32, new Object[] {A26InvoiceDetailQuantity, A65InvoiceDetailHistoricPrice, A98InvoiceDetailIsWholesale, A15ProductId, A20InvoiceId, A25InvoiceDetailId});
                        pr_default.close(32);
                        pr_default.SmartCacheProvider.SetUpdated("InvoiceDetail");
                        if ( (pr_default.getStatus(32) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"InvoiceDetail"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0613( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0613( ) ;
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
               EndLevel0613( ) ;
            }
         }
         CloseExtendedTableCursors0613( ) ;
      }

      protected void DeferredUpdate0613( )
      {
      }

      protected void Delete0613( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0613( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0613( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0613( ) ;
            AfterConfirm0613( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0613( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000652 */
                  pr_default.execute(33, new Object[] {A20InvoiceId, A25InvoiceDetailId});
                  pr_default.close(33);
                  pr_default.SmartCacheProvider.SetUpdated("InvoiceDetail");
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
         sMode13 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0613( ) ;
         Gx_mode = sMode13;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0613( )
      {
         standaloneModal0613( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            if ( IsIns( )  )
            {
               A68InvoiceProductQuantity = (short)(O68InvoiceProductQuantity+1);
               AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
            }
            else
            {
               if ( IsUpd( )  )
               {
                  A68InvoiceProductQuantity = O68InvoiceProductQuantity;
                  AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
               }
               else
               {
                  if ( IsDlt( )  )
                  {
                     A68InvoiceProductQuantity = (short)(O68InvoiceProductQuantity-1);
                     AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
                  }
               }
            }
            /* Using cursor T000653 */
            pr_default.execute(34, new Object[] {A15ProductId});
            A16ProductName = T000653_A16ProductName[0];
            A17ProductStock = T000653_A17ProductStock[0];
            n17ProductStock = T000653_n17ProductStock[0];
            pr_default.close(34);
         }
      }

      protected void EndLevel0613( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(5);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0613( )
      {
         /* Scan By routine */
         /* Using cursor T000654 */
         pr_default.execute(35, new Object[] {A20InvoiceId});
         RcdFound13 = 0;
         if ( (pr_default.getStatus(35) != 101) )
         {
            RcdFound13 = 1;
            A25InvoiceDetailId = T000654_A25InvoiceDetailId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0613( )
      {
         /* Scan next routine */
         pr_default.readNext(35);
         RcdFound13 = 0;
         if ( (pr_default.getStatus(35) != 101) )
         {
            RcdFound13 = 1;
            A25InvoiceDetailId = T000654_A25InvoiceDetailId[0];
         }
      }

      protected void ScanEnd0613( )
      {
         pr_default.close(35);
      }

      protected void AfterConfirm0613( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0613( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0613( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0613( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0613( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0613( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0613( )
      {
         edtInvoiceDetailId_Enabled = 0;
         AssignProp("", false, edtInvoiceDetailId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceDetailId_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtProductId_Enabled = 0;
         AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtProductName_Enabled = 0;
         AssignProp("", false, edtProductName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductName_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtProductStock_Enabled = 0;
         AssignProp("", false, edtProductStock_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductStock_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtInvoiceDetailQuantity_Enabled = 0;
         AssignProp("", false, edtInvoiceDetailQuantity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceDetailQuantity_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtInvoiceDetailHistoricPrice_Enabled = 0;
         AssignProp("", false, edtInvoiceDetailHistoricPrice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceDetailHistoricPrice_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         chkInvoiceDetailIsWholesale.Enabled = 0;
         AssignProp("", false, chkInvoiceDetailIsWholesale_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkInvoiceDetailIsWholesale.Enabled), 5, 0), !bGXsfl_88_Refreshing);
      }

      protected void send_integrity_lvl_hashes0613( )
      {
      }

      protected void ZM0621( short GX_JID )
      {
         if ( ( GX_JID == 34 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z120InvoicePaymentMethodImport = T00063_A120InvoicePaymentMethodImport[0];
               Z132InvoicePaymentMethodRechargeIm = T00063_A132InvoicePaymentMethodRechargeIm[0];
               Z133InvoicePaymentMethodDiscountIm = T00063_A133InvoicePaymentMethodDiscountIm[0];
               Z115PaymentMethodId = T00063_A115PaymentMethodId[0];
            }
            else
            {
               Z120InvoicePaymentMethodImport = A120InvoicePaymentMethodImport;
               Z132InvoicePaymentMethodRechargeIm = A132InvoicePaymentMethodRechargeIm;
               Z133InvoicePaymentMethodDiscountIm = A133InvoicePaymentMethodDiscountIm;
               Z115PaymentMethodId = A115PaymentMethodId;
            }
         }
         if ( GX_JID == -34 )
         {
            Z20InvoiceId = A20InvoiceId;
            Z118InvoicePaymentMethodId = A118InvoicePaymentMethodId;
            Z120InvoicePaymentMethodImport = A120InvoicePaymentMethodImport;
            Z132InvoicePaymentMethodRechargeIm = A132InvoicePaymentMethodRechargeIm;
            Z133InvoicePaymentMethodDiscountIm = A133InvoicePaymentMethodDiscountIm;
            Z115PaymentMethodId = A115PaymentMethodId;
            Z116PaymentMethodDescription = A116PaymentMethodDescription;
            Z129PaymentMethodDiscount = A129PaymentMethodDiscount;
            Z130PaymentMethodRecarge = A130PaymentMethodRecarge;
         }
      }

      protected void standaloneNotModal0621( )
      {
         edtInvoiceLastPaymentMethodId_Enabled = 0;
         AssignProp("", false, edtInvoiceLastPaymentMethodId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceLastPaymentMethodId_Enabled), 5, 0), true);
         edtInvoiceLastPaymentMethodId_Enabled = 0;
         AssignProp("", false, edtInvoiceLastPaymentMethodId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceLastPaymentMethodId_Enabled), 5, 0), true);
      }

      protected void standaloneModal0621( )
      {
         if ( IsIns( )  )
         {
            A131InvoiceLastPaymentMethodId = (int)(O131InvoiceLastPaymentMethodId+1);
            n131InvoiceLastPaymentMethodId = false;
            AssignAttri("", false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
         }
         if ( IsIns( )  && ( Gx_BScreen == 1 ) )
         {
            A118InvoicePaymentMethodId = A131InvoiceLastPaymentMethodId;
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtInvoicePaymentMethodId_Enabled = 0;
            AssignProp("", false, edtInvoicePaymentMethodId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoicePaymentMethodId_Enabled), 5, 0), !bGXsfl_104_Refreshing);
         }
         else
         {
            edtInvoicePaymentMethodId_Enabled = 1;
            AssignProp("", false, edtInvoicePaymentMethodId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoicePaymentMethodId_Enabled), 5, 0), !bGXsfl_104_Refreshing);
         }
      }

      protected void Load0621( )
      {
         /* Using cursor T000655 */
         pr_default.execute(36, new Object[] {A20InvoiceId, A118InvoicePaymentMethodId});
         if ( (pr_default.getStatus(36) != 101) )
         {
            RcdFound21 = 1;
            A116PaymentMethodDescription = T000655_A116PaymentMethodDescription[0];
            A129PaymentMethodDiscount = T000655_A129PaymentMethodDiscount[0];
            A130PaymentMethodRecarge = T000655_A130PaymentMethodRecarge[0];
            A120InvoicePaymentMethodImport = T000655_A120InvoicePaymentMethodImport[0];
            n120InvoicePaymentMethodImport = T000655_n120InvoicePaymentMethodImport[0];
            A132InvoicePaymentMethodRechargeIm = T000655_A132InvoicePaymentMethodRechargeIm[0];
            n132InvoicePaymentMethodRechargeIm = T000655_n132InvoicePaymentMethodRechargeIm[0];
            A133InvoicePaymentMethodDiscountIm = T000655_A133InvoicePaymentMethodDiscountIm[0];
            n133InvoicePaymentMethodDiscountIm = T000655_n133InvoicePaymentMethodDiscountIm[0];
            A115PaymentMethodId = T000655_A115PaymentMethodId[0];
            n115PaymentMethodId = T000655_n115PaymentMethodId[0];
            ZM0621( -34) ;
         }
         pr_default.close(36);
         OnLoadActions0621( ) ;
      }

      protected void OnLoadActions0621( )
      {
      }

      protected void CheckExtendedTable0621( )
      {
         nIsDirty_21 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal0621( ) ;
         /* Using cursor T00064 */
         pr_default.execute(2, new Object[] {n115PaymentMethodId, A115PaymentMethodId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A115PaymentMethodId) ) )
            {
               GXCCtl = "PAYMENTMETHODID_" + sGXsfl_104_idx;
               GX_msglist.addItem("No matching 'Payment Method of Invoices'.", "ForeignKeyNotFound", 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtPaymentMethodId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A116PaymentMethodDescription = T00064_A116PaymentMethodDescription[0];
         A129PaymentMethodDiscount = T00064_A129PaymentMethodDiscount[0];
         A130PaymentMethodRecarge = T00064_A130PaymentMethodRecarge[0];
         pr_default.close(2);
         if ( ! ( ( ( A120InvoicePaymentMethodImport >= Convert.ToDecimal( 0 )) && ( A120InvoicePaymentMethodImport <= 999999999999999.99m ) ) || (Convert.ToDecimal(0)==A120InvoicePaymentMethodImport) ) )
         {
            GXCCtl = "INVOICEPAYMENTMETHODIMPORT_" + sGXsfl_104_idx;
            GX_msglist.addItem("Invalid Price", "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtInvoicePaymentMethodImport_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( ( A132InvoicePaymentMethodRechargeIm >= Convert.ToDecimal( 0 )) && ( A132InvoicePaymentMethodRechargeIm <= 999999999999999.99m ) ) || (Convert.ToDecimal(0)==A132InvoicePaymentMethodRechargeIm) ) )
         {
            GXCCtl = "INVOICEPAYMENTMETHODRECHARGEIM_" + sGXsfl_104_idx;
            GX_msglist.addItem("Invalid Price", "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtInvoicePaymentMethodRechargeIm_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( ( A133InvoicePaymentMethodDiscountIm >= Convert.ToDecimal( 0 )) && ( A133InvoicePaymentMethodDiscountIm <= 999999999999999.99m ) ) || (Convert.ToDecimal(0)==A133InvoicePaymentMethodDiscountIm) ) )
         {
            GXCCtl = "INVOICEPAYMENTMETHODDISCOUNTIM_" + sGXsfl_104_idx;
            GX_msglist.addItem("Invalid Price", "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtInvoicePaymentMethodDiscountIm_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0621( )
      {
         pr_default.close(2);
      }

      protected void enableDisable0621( )
      {
      }

      protected void gxLoad_35( int A115PaymentMethodId )
      {
         /* Using cursor T000656 */
         pr_default.execute(37, new Object[] {n115PaymentMethodId, A115PaymentMethodId});
         if ( (pr_default.getStatus(37) == 101) )
         {
            if ( ! ( (0==A115PaymentMethodId) ) )
            {
               GXCCtl = "PAYMENTMETHODID_" + sGXsfl_104_idx;
               GX_msglist.addItem("No matching 'Payment Method of Invoices'.", "ForeignKeyNotFound", 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtPaymentMethodId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A116PaymentMethodDescription = T000656_A116PaymentMethodDescription[0];
         A129PaymentMethodDiscount = T000656_A129PaymentMethodDiscount[0];
         A130PaymentMethodRecarge = T000656_A130PaymentMethodRecarge[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A116PaymentMethodDescription)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A129PaymentMethodDiscount, 8, 2, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A130PaymentMethodRecarge, 8, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(37) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(37);
      }

      protected void GetKey0621( )
      {
         /* Using cursor T000657 */
         pr_default.execute(38, new Object[] {A20InvoiceId, A118InvoicePaymentMethodId});
         if ( (pr_default.getStatus(38) != 101) )
         {
            RcdFound21 = 1;
         }
         else
         {
            RcdFound21 = 0;
         }
         pr_default.close(38);
      }

      protected void getByPrimaryKey0621( )
      {
         /* Using cursor T00063 */
         pr_default.execute(1, new Object[] {A20InvoiceId, A118InvoicePaymentMethodId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0621( 34) ;
            RcdFound21 = 1;
            InitializeNonKey0621( ) ;
            A118InvoicePaymentMethodId = T00063_A118InvoicePaymentMethodId[0];
            A120InvoicePaymentMethodImport = T00063_A120InvoicePaymentMethodImport[0];
            n120InvoicePaymentMethodImport = T00063_n120InvoicePaymentMethodImport[0];
            A132InvoicePaymentMethodRechargeIm = T00063_A132InvoicePaymentMethodRechargeIm[0];
            n132InvoicePaymentMethodRechargeIm = T00063_n132InvoicePaymentMethodRechargeIm[0];
            A133InvoicePaymentMethodDiscountIm = T00063_A133InvoicePaymentMethodDiscountIm[0];
            n133InvoicePaymentMethodDiscountIm = T00063_n133InvoicePaymentMethodDiscountIm[0];
            A115PaymentMethodId = T00063_A115PaymentMethodId[0];
            n115PaymentMethodId = T00063_n115PaymentMethodId[0];
            Z20InvoiceId = A20InvoiceId;
            Z118InvoicePaymentMethodId = A118InvoicePaymentMethodId;
            sMode21 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0621( ) ;
            Gx_mode = sMode21;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound21 = 0;
            InitializeNonKey0621( ) ;
            sMode21 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0621( ) ;
            Gx_mode = sMode21;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0621( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0621( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00062 */
            pr_default.execute(0, new Object[] {A20InvoiceId, A118InvoicePaymentMethodId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"InvoicePaymentMethod"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z120InvoicePaymentMethodImport != T00062_A120InvoicePaymentMethodImport[0] ) || ( Z132InvoicePaymentMethodRechargeIm != T00062_A132InvoicePaymentMethodRechargeIm[0] ) || ( Z133InvoicePaymentMethodDiscountIm != T00062_A133InvoicePaymentMethodDiscountIm[0] ) || ( Z115PaymentMethodId != T00062_A115PaymentMethodId[0] ) )
            {
               if ( Z120InvoicePaymentMethodImport != T00062_A120InvoicePaymentMethodImport[0] )
               {
                  GXUtil.WriteLog("invoice:[seudo value changed for attri]"+"InvoicePaymentMethodImport");
                  GXUtil.WriteLogRaw("Old: ",Z120InvoicePaymentMethodImport);
                  GXUtil.WriteLogRaw("Current: ",T00062_A120InvoicePaymentMethodImport[0]);
               }
               if ( Z132InvoicePaymentMethodRechargeIm != T00062_A132InvoicePaymentMethodRechargeIm[0] )
               {
                  GXUtil.WriteLog("invoice:[seudo value changed for attri]"+"InvoicePaymentMethodRechargeIm");
                  GXUtil.WriteLogRaw("Old: ",Z132InvoicePaymentMethodRechargeIm);
                  GXUtil.WriteLogRaw("Current: ",T00062_A132InvoicePaymentMethodRechargeIm[0]);
               }
               if ( Z133InvoicePaymentMethodDiscountIm != T00062_A133InvoicePaymentMethodDiscountIm[0] )
               {
                  GXUtil.WriteLog("invoice:[seudo value changed for attri]"+"InvoicePaymentMethodDiscountIm");
                  GXUtil.WriteLogRaw("Old: ",Z133InvoicePaymentMethodDiscountIm);
                  GXUtil.WriteLogRaw("Current: ",T00062_A133InvoicePaymentMethodDiscountIm[0]);
               }
               if ( Z115PaymentMethodId != T00062_A115PaymentMethodId[0] )
               {
                  GXUtil.WriteLog("invoice:[seudo value changed for attri]"+"PaymentMethodId");
                  GXUtil.WriteLogRaw("Old: ",Z115PaymentMethodId);
                  GXUtil.WriteLogRaw("Current: ",T00062_A115PaymentMethodId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"InvoicePaymentMethod"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0621( )
      {
         BeforeValidate0621( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0621( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0621( 0) ;
            CheckOptimisticConcurrency0621( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0621( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0621( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000658 */
                     pr_default.execute(39, new Object[] {A20InvoiceId, A118InvoicePaymentMethodId, n120InvoicePaymentMethodImport, A120InvoicePaymentMethodImport, n132InvoicePaymentMethodRechargeIm, A132InvoicePaymentMethodRechargeIm, n133InvoicePaymentMethodDiscountIm, A133InvoicePaymentMethodDiscountIm, n115PaymentMethodId, A115PaymentMethodId});
                     pr_default.close(39);
                     pr_default.SmartCacheProvider.SetUpdated("InvoicePaymentMethod");
                     if ( (pr_default.getStatus(39) == 1) )
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
               Load0621( ) ;
            }
            EndLevel0621( ) ;
         }
         CloseExtendedTableCursors0621( ) ;
      }

      protected void Update0621( )
      {
         BeforeValidate0621( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0621( ) ;
         }
         if ( ( nIsMod_21 != 0 ) || ( nIsDirty_21 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0621( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0621( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0621( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000659 */
                        pr_default.execute(40, new Object[] {n120InvoicePaymentMethodImport, A120InvoicePaymentMethodImport, n132InvoicePaymentMethodRechargeIm, A132InvoicePaymentMethodRechargeIm, n133InvoicePaymentMethodDiscountIm, A133InvoicePaymentMethodDiscountIm, n115PaymentMethodId, A115PaymentMethodId, A20InvoiceId, A118InvoicePaymentMethodId});
                        pr_default.close(40);
                        pr_default.SmartCacheProvider.SetUpdated("InvoicePaymentMethod");
                        if ( (pr_default.getStatus(40) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"InvoicePaymentMethod"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0621( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0621( ) ;
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
               EndLevel0621( ) ;
            }
         }
         CloseExtendedTableCursors0621( ) ;
      }

      protected void DeferredUpdate0621( )
      {
      }

      protected void Delete0621( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0621( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0621( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0621( ) ;
            AfterConfirm0621( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0621( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000660 */
                  pr_default.execute(41, new Object[] {A20InvoiceId, A118InvoicePaymentMethodId});
                  pr_default.close(41);
                  pr_default.SmartCacheProvider.SetUpdated("InvoicePaymentMethod");
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
         sMode21 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0621( ) ;
         Gx_mode = sMode21;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0621( )
      {
         standaloneModal0621( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000661 */
            pr_default.execute(42, new Object[] {n115PaymentMethodId, A115PaymentMethodId});
            A116PaymentMethodDescription = T000661_A116PaymentMethodDescription[0];
            A129PaymentMethodDiscount = T000661_A129PaymentMethodDiscount[0];
            A130PaymentMethodRecarge = T000661_A130PaymentMethodRecarge[0];
            pr_default.close(42);
         }
      }

      protected void EndLevel0621( )
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

      public void ScanStart0621( )
      {
         /* Scan By routine */
         /* Using cursor T000662 */
         pr_default.execute(43, new Object[] {A20InvoiceId});
         RcdFound21 = 0;
         if ( (pr_default.getStatus(43) != 101) )
         {
            RcdFound21 = 1;
            A118InvoicePaymentMethodId = T000662_A118InvoicePaymentMethodId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0621( )
      {
         /* Scan next routine */
         pr_default.readNext(43);
         RcdFound21 = 0;
         if ( (pr_default.getStatus(43) != 101) )
         {
            RcdFound21 = 1;
            A118InvoicePaymentMethodId = T000662_A118InvoicePaymentMethodId[0];
         }
      }

      protected void ScanEnd0621( )
      {
         pr_default.close(43);
      }

      protected void AfterConfirm0621( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0621( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0621( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0621( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0621( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0621( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0621( )
      {
         edtInvoicePaymentMethodId_Enabled = 0;
         AssignProp("", false, edtInvoicePaymentMethodId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoicePaymentMethodId_Enabled), 5, 0), !bGXsfl_104_Refreshing);
         edtPaymentMethodId_Enabled = 0;
         AssignProp("", false, edtPaymentMethodId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaymentMethodId_Enabled), 5, 0), !bGXsfl_104_Refreshing);
         edtPaymentMethodDescription_Enabled = 0;
         AssignProp("", false, edtPaymentMethodDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaymentMethodDescription_Enabled), 5, 0), !bGXsfl_104_Refreshing);
         edtPaymentMethodDiscount_Enabled = 0;
         AssignProp("", false, edtPaymentMethodDiscount_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaymentMethodDiscount_Enabled), 5, 0), !bGXsfl_104_Refreshing);
         edtPaymentMethodRecarge_Enabled = 0;
         AssignProp("", false, edtPaymentMethodRecarge_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaymentMethodRecarge_Enabled), 5, 0), !bGXsfl_104_Refreshing);
         edtInvoicePaymentMethodImport_Enabled = 0;
         AssignProp("", false, edtInvoicePaymentMethodImport_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoicePaymentMethodImport_Enabled), 5, 0), !bGXsfl_104_Refreshing);
         edtInvoicePaymentMethodRechargeIm_Enabled = 0;
         AssignProp("", false, edtInvoicePaymentMethodRechargeIm_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoicePaymentMethodRechargeIm_Enabled), 5, 0), !bGXsfl_104_Refreshing);
         edtInvoicePaymentMethodDiscountIm_Enabled = 0;
         AssignProp("", false, edtInvoicePaymentMethodDiscountIm_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoicePaymentMethodDiscountIm_Enabled), 5, 0), !bGXsfl_104_Refreshing);
      }

      protected void send_integrity_lvl_hashes0621( )
      {
      }

      protected void send_integrity_lvl_hashes066( )
      {
      }

      protected void SubsflControlProps_8813( )
      {
         edtInvoiceDetailId_Internalname = "INVOICEDETAILID_"+sGXsfl_88_idx;
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_88_idx;
         imgprompt_15_Internalname = "PROMPT_15_"+sGXsfl_88_idx;
         edtProductName_Internalname = "PRODUCTNAME_"+sGXsfl_88_idx;
         edtProductStock_Internalname = "PRODUCTSTOCK_"+sGXsfl_88_idx;
         edtInvoiceDetailQuantity_Internalname = "INVOICEDETAILQUANTITY_"+sGXsfl_88_idx;
         edtInvoiceDetailHistoricPrice_Internalname = "INVOICEDETAILHISTORICPRICE_"+sGXsfl_88_idx;
         chkInvoiceDetailIsWholesale_Internalname = "INVOICEDETAILISWHOLESALE_"+sGXsfl_88_idx;
      }

      protected void SubsflControlProps_fel_8813( )
      {
         edtInvoiceDetailId_Internalname = "INVOICEDETAILID_"+sGXsfl_88_fel_idx;
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_88_fel_idx;
         imgprompt_15_Internalname = "PROMPT_15_"+sGXsfl_88_fel_idx;
         edtProductName_Internalname = "PRODUCTNAME_"+sGXsfl_88_fel_idx;
         edtProductStock_Internalname = "PRODUCTSTOCK_"+sGXsfl_88_fel_idx;
         edtInvoiceDetailQuantity_Internalname = "INVOICEDETAILQUANTITY_"+sGXsfl_88_fel_idx;
         edtInvoiceDetailHistoricPrice_Internalname = "INVOICEDETAILHISTORICPRICE_"+sGXsfl_88_fel_idx;
         chkInvoiceDetailIsWholesale_Internalname = "INVOICEDETAILISWHOLESALE_"+sGXsfl_88_fel_idx;
      }

      protected void AddRow0613( )
      {
         nGXsfl_88_idx = (int)(nGXsfl_88_idx+1);
         sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
         SubsflControlProps_8813( ) ;
         SendRow0613( ) ;
      }

      protected void SendRow0613( )
      {
         Gridinvoice_detailRow = GXWebRow.GetNew(context);
         if ( subGridinvoice_detail_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridinvoice_detail_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridinvoice_detail_Class, "") != 0 )
            {
               subGridinvoice_detail_Linesclass = subGridinvoice_detail_Class+"Odd";
            }
         }
         else if ( subGridinvoice_detail_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridinvoice_detail_Backstyle = 0;
            subGridinvoice_detail_Backcolor = subGridinvoice_detail_Allbackcolor;
            if ( StringUtil.StrCmp(subGridinvoice_detail_Class, "") != 0 )
            {
               subGridinvoice_detail_Linesclass = subGridinvoice_detail_Class+"Uniform";
            }
         }
         else if ( subGridinvoice_detail_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridinvoice_detail_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridinvoice_detail_Class, "") != 0 )
            {
               subGridinvoice_detail_Linesclass = subGridinvoice_detail_Class+"Odd";
            }
            subGridinvoice_detail_Backcolor = (int)(0x0);
         }
         else if ( subGridinvoice_detail_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridinvoice_detail_Backstyle = 1;
            if ( ((int)((nGXsfl_88_idx) % (2))) == 0 )
            {
               subGridinvoice_detail_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridinvoice_detail_Class, "") != 0 )
               {
                  subGridinvoice_detail_Linesclass = subGridinvoice_detail_Class+"Even";
               }
            }
            else
            {
               subGridinvoice_detail_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridinvoice_detail_Class, "") != 0 )
               {
                  subGridinvoice_detail_Linesclass = subGridinvoice_detail_Class+"Odd";
               }
            }
         }
         imgprompt_15_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0050.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PRODUCTID_"+sGXsfl_88_idx+"'), id:'"+"PRODUCTID_"+sGXsfl_88_idx+"'"+",IOType:'out'}"+"],"+"gx.dom.form()."+"nIsMod_13_"+sGXsfl_88_idx+","+"'', false"+","+"false"+");");
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_13_" + sGXsfl_88_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 89,'',false,'" + sGXsfl_88_idx + "',88)\"";
         ROClassString = "Attribute";
         Gridinvoice_detailRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInvoiceDetailId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A25InvoiceDetailId), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A25InvoiceDetailId), "ZZZZZ9"))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,89);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInvoiceDetailId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtInvoiceDetailId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)88,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_13_" + sGXsfl_88_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 90,'',false,'" + sGXsfl_88_idx + "',88)\"";
         ROClassString = "Attribute";
         Gridinvoice_detailRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", "")),StringUtil.LTrim( ((edtProductId_Enabled!=0) ? context.localUtil.Format( (decimal)(A15ProductId), "ZZZZZ9") : context.localUtil.Format( (decimal)(A15ProductId), "ZZZZZ9")))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,90);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProductId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)88,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_15_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_15_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         Gridinvoice_detailRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_15_Internalname,(string)sImgUrl,(string)imgprompt_15_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_15_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridinvoice_detailRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductName_Internalname,(string)A16ProductName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProductName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)88,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridinvoice_detailRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductStock_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A17ProductStock), 6, 0, ".", "")),StringUtil.LTrim( ((edtProductStock_Enabled!=0) ? context.localUtil.Format( (decimal)(A17ProductStock), "ZZZZZ9") : context.localUtil.Format( (decimal)(A17ProductStock), "ZZZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductStock_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProductStock_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)88,(short)0,(short)-1,(short)0,(bool)true,(string)"Stock",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_13_" + sGXsfl_88_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 93,'',false,'" + sGXsfl_88_idx + "',88)\"";
         ROClassString = "Attribute";
         Gridinvoice_detailRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInvoiceDetailQuantity_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A26InvoiceDetailQuantity), 6, 0, ".", "")),StringUtil.LTrim( ((edtInvoiceDetailQuantity_Enabled!=0) ? context.localUtil.Format( (decimal)(A26InvoiceDetailQuantity), "ZZZZZ9") : context.localUtil.Format( (decimal)(A26InvoiceDetailQuantity), "ZZZZZ9")))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,93);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInvoiceDetailQuantity_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtInvoiceDetailQuantity_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)88,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_13_" + sGXsfl_88_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 94,'',false,'" + sGXsfl_88_idx + "',88)\"";
         ROClassString = "Attribute";
         Gridinvoice_detailRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInvoiceDetailHistoricPrice_Internalname,StringUtil.LTrim( StringUtil.NToC( A65InvoiceDetailHistoricPrice, 18, 2, ".", "")),StringUtil.LTrim( ((edtInvoiceDetailHistoricPrice_Enabled!=0) ? context.localUtil.Format( A65InvoiceDetailHistoricPrice, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A65InvoiceDetailHistoricPrice, "ZZZZZZZZZZZZZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,94);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInvoiceDetailHistoricPrice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtInvoiceDetailHistoricPrice_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)88,(short)0,(short)-1,(short)0,(bool)true,(string)"Price",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Check box */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_13_" + sGXsfl_88_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 95,'',false,'" + sGXsfl_88_idx + "',88)\"";
         ClassString = "Attribute";
         StyleString = "";
         GXCCtl = "INVOICEDETAILISWHOLESALE_" + sGXsfl_88_idx;
         chkInvoiceDetailIsWholesale.Name = GXCCtl;
         chkInvoiceDetailIsWholesale.WebTags = "";
         chkInvoiceDetailIsWholesale.Caption = "";
         AssignProp("", false, chkInvoiceDetailIsWholesale_Internalname, "TitleCaption", chkInvoiceDetailIsWholesale.Caption, !bGXsfl_88_Refreshing);
         chkInvoiceDetailIsWholesale.CheckedValue = "false";
         A98InvoiceDetailIsWholesale = StringUtil.StrToBool( StringUtil.BoolToStr( A98InvoiceDetailIsWholesale));
         Gridinvoice_detailRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkInvoiceDetailIsWholesale_Internalname,StringUtil.BoolToStr( A98InvoiceDetailIsWholesale),(string)"",(string)"",(short)-1,chkInvoiceDetailIsWholesale.Enabled,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",TempTags+" onclick="+"\"gx.fn.checkboxClick(95, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,95);\""});
         ajax_sending_grid_row(Gridinvoice_detailRow);
         send_integrity_lvl_hashes0613( ) ;
         GXCCtl = "Z25InvoiceDetailId_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z25InvoiceDetailId), 6, 0, ".", "")));
         GXCCtl = "Z26InvoiceDetailQuantity_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z26InvoiceDetailQuantity), 6, 0, ".", "")));
         GXCCtl = "Z65InvoiceDetailHistoricPrice_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z65InvoiceDetailHistoricPrice, 18, 2, ".", "")));
         GXCCtl = "Z98InvoiceDetailIsWholesale_" + sGXsfl_88_idx;
         GxWebStd.gx_boolean_hidden_field( context, GXCCtl, Z98InvoiceDetailIsWholesale);
         GXCCtl = "Z15ProductId_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z15ProductId), 6, 0, ".", "")));
         GXCCtl = "nRcdDeleted_13_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_13), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_13_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_13), 4, 0, ".", "")));
         GXCCtl = "nIsMod_13_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_13), 4, 0, ".", "")));
         GXCCtl = "vMODE_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_88_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV9TrnContext);
         }
         GXCCtl = "vINVOICEID_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13InvoiceId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "INVOICEDETAILID_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvoiceDetailId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTID_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTNAME_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTSTOCK_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductStock_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "INVOICEDETAILQUANTITY_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvoiceDetailQuantity_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "INVOICEDETAILHISTORICPRICE_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvoiceDetailHistoricPrice_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "INVOICEDETAILISWHOLESALE_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkInvoiceDetailIsWholesale.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_15_"+sGXsfl_88_idx+"Link", StringUtil.RTrim( imgprompt_15_Link));
         ajax_sending_grid_row(null);
         Gridinvoice_detailContainer.AddRow(Gridinvoice_detailRow);
      }

      protected void ReadRow0613( )
      {
         nGXsfl_88_idx = (int)(nGXsfl_88_idx+1);
         sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
         SubsflControlProps_8813( ) ;
         edtInvoiceDetailId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVOICEDETAILID_"+sGXsfl_88_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtProductId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTID_"+sGXsfl_88_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtProductName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTNAME_"+sGXsfl_88_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtProductStock_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTSTOCK_"+sGXsfl_88_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtInvoiceDetailQuantity_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVOICEDETAILQUANTITY_"+sGXsfl_88_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtInvoiceDetailHistoricPrice_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVOICEDETAILHISTORICPRICE_"+sGXsfl_88_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         chkInvoiceDetailIsWholesale.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVOICEDETAILISWHOLESALE_"+sGXsfl_88_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         imgprompt_99_Link = cgiGet( "PROMPT_15_"+sGXsfl_88_idx+"Link");
         if ( ( ( context.localUtil.CToN( cgiGet( edtInvoiceDetailId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtInvoiceDetailId_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
         {
            GXCCtl = "INVOICEDETAILID_" + sGXsfl_88_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtInvoiceDetailId_Internalname;
            wbErr = true;
            A25InvoiceDetailId = 0;
         }
         else
         {
            A25InvoiceDetailId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtInvoiceDetailId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
         }
         if ( ( ( context.localUtil.CToN( cgiGet( edtProductId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProductId_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
         {
            GXCCtl = "PRODUCTID_" + sGXsfl_88_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProductId_Internalname;
            wbErr = true;
            A15ProductId = 0;
         }
         else
         {
            A15ProductId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtProductId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
         }
         A16ProductName = cgiGet( edtProductName_Internalname);
         A17ProductStock = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtProductStock_Internalname), ".", ","), 18, MidpointRounding.ToEven));
         n17ProductStock = false;
         if ( ( ( context.localUtil.CToN( cgiGet( edtInvoiceDetailQuantity_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtInvoiceDetailQuantity_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
         {
            GXCCtl = "INVOICEDETAILQUANTITY_" + sGXsfl_88_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtInvoiceDetailQuantity_Internalname;
            wbErr = true;
            A26InvoiceDetailQuantity = 0;
         }
         else
         {
            A26InvoiceDetailQuantity = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtInvoiceDetailQuantity_Internalname), ".", ","), 18, MidpointRounding.ToEven));
         }
         if ( ( ( context.localUtil.CToN( cgiGet( edtInvoiceDetailHistoricPrice_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtInvoiceDetailHistoricPrice_Internalname), ".", ",") > 999999999999999.99m ) ) )
         {
            GXCCtl = "INVOICEDETAILHISTORICPRICE_" + sGXsfl_88_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtInvoiceDetailHistoricPrice_Internalname;
            wbErr = true;
            A65InvoiceDetailHistoricPrice = 0;
         }
         else
         {
            A65InvoiceDetailHistoricPrice = context.localUtil.CToN( cgiGet( edtInvoiceDetailHistoricPrice_Internalname), ".", ",");
         }
         A98InvoiceDetailIsWholesale = StringUtil.StrToBool( cgiGet( chkInvoiceDetailIsWholesale_Internalname));
         GXCCtl = "Z25InvoiceDetailId_" + sGXsfl_88_idx;
         Z25InvoiceDetailId = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "Z26InvoiceDetailQuantity_" + sGXsfl_88_idx;
         Z26InvoiceDetailQuantity = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "Z65InvoiceDetailHistoricPrice_" + sGXsfl_88_idx;
         Z65InvoiceDetailHistoricPrice = context.localUtil.CToN( cgiGet( GXCCtl), ".", ",");
         GXCCtl = "Z98InvoiceDetailIsWholesale_" + sGXsfl_88_idx;
         Z98InvoiceDetailIsWholesale = StringUtil.StrToBool( cgiGet( GXCCtl));
         GXCCtl = "Z15ProductId_" + sGXsfl_88_idx;
         Z15ProductId = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdDeleted_13_" + sGXsfl_88_idx;
         nRcdDeleted_13 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_13_" + sGXsfl_88_idx;
         nRcdExists_13 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_13_" + sGXsfl_88_idx;
         nIsMod_13 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
      }

      protected void SubsflControlProps_10421( )
      {
         edtInvoicePaymentMethodId_Internalname = "INVOICEPAYMENTMETHODID_"+sGXsfl_104_idx;
         edtPaymentMethodId_Internalname = "PAYMENTMETHODID_"+sGXsfl_104_idx;
         imgprompt_115_Internalname = "PROMPT_115_"+sGXsfl_104_idx;
         edtPaymentMethodDescription_Internalname = "PAYMENTMETHODDESCRIPTION_"+sGXsfl_104_idx;
         edtPaymentMethodDiscount_Internalname = "PAYMENTMETHODDISCOUNT_"+sGXsfl_104_idx;
         edtPaymentMethodRecarge_Internalname = "PAYMENTMETHODRECARGE_"+sGXsfl_104_idx;
         edtInvoicePaymentMethodImport_Internalname = "INVOICEPAYMENTMETHODIMPORT_"+sGXsfl_104_idx;
         edtInvoicePaymentMethodRechargeIm_Internalname = "INVOICEPAYMENTMETHODRECHARGEIM_"+sGXsfl_104_idx;
         edtInvoicePaymentMethodDiscountIm_Internalname = "INVOICEPAYMENTMETHODDISCOUNTIM_"+sGXsfl_104_idx;
      }

      protected void SubsflControlProps_fel_10421( )
      {
         edtInvoicePaymentMethodId_Internalname = "INVOICEPAYMENTMETHODID_"+sGXsfl_104_fel_idx;
         edtPaymentMethodId_Internalname = "PAYMENTMETHODID_"+sGXsfl_104_fel_idx;
         imgprompt_115_Internalname = "PROMPT_115_"+sGXsfl_104_fel_idx;
         edtPaymentMethodDescription_Internalname = "PAYMENTMETHODDESCRIPTION_"+sGXsfl_104_fel_idx;
         edtPaymentMethodDiscount_Internalname = "PAYMENTMETHODDISCOUNT_"+sGXsfl_104_fel_idx;
         edtPaymentMethodRecarge_Internalname = "PAYMENTMETHODRECARGE_"+sGXsfl_104_fel_idx;
         edtInvoicePaymentMethodImport_Internalname = "INVOICEPAYMENTMETHODIMPORT_"+sGXsfl_104_fel_idx;
         edtInvoicePaymentMethodRechargeIm_Internalname = "INVOICEPAYMENTMETHODRECHARGEIM_"+sGXsfl_104_fel_idx;
         edtInvoicePaymentMethodDiscountIm_Internalname = "INVOICEPAYMENTMETHODDISCOUNTIM_"+sGXsfl_104_fel_idx;
      }

      protected void AddRow0621( )
      {
         nGXsfl_104_idx = (int)(nGXsfl_104_idx+1);
         sGXsfl_104_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_104_idx), 4, 0), 4, "0");
         SubsflControlProps_10421( ) ;
         SendRow0621( ) ;
      }

      protected void SendRow0621( )
      {
         Gridinvoice_paymentmethodRow = GXWebRow.GetNew(context);
         if ( subGridinvoice_paymentmethod_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridinvoice_paymentmethod_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridinvoice_paymentmethod_Class, "") != 0 )
            {
               subGridinvoice_paymentmethod_Linesclass = subGridinvoice_paymentmethod_Class+"Odd";
            }
         }
         else if ( subGridinvoice_paymentmethod_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridinvoice_paymentmethod_Backstyle = 0;
            subGridinvoice_paymentmethod_Backcolor = subGridinvoice_paymentmethod_Allbackcolor;
            if ( StringUtil.StrCmp(subGridinvoice_paymentmethod_Class, "") != 0 )
            {
               subGridinvoice_paymentmethod_Linesclass = subGridinvoice_paymentmethod_Class+"Uniform";
            }
         }
         else if ( subGridinvoice_paymentmethod_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridinvoice_paymentmethod_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridinvoice_paymentmethod_Class, "") != 0 )
            {
               subGridinvoice_paymentmethod_Linesclass = subGridinvoice_paymentmethod_Class+"Odd";
            }
            subGridinvoice_paymentmethod_Backcolor = (int)(0x0);
         }
         else if ( subGridinvoice_paymentmethod_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridinvoice_paymentmethod_Backstyle = 1;
            if ( ((int)((nGXsfl_104_idx) % (2))) == 0 )
            {
               subGridinvoice_paymentmethod_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridinvoice_paymentmethod_Class, "") != 0 )
               {
                  subGridinvoice_paymentmethod_Linesclass = subGridinvoice_paymentmethod_Class+"Even";
               }
            }
            else
            {
               subGridinvoice_paymentmethod_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridinvoice_paymentmethod_Class, "") != 0 )
               {
                  subGridinvoice_paymentmethod_Linesclass = subGridinvoice_paymentmethod_Class+"Odd";
               }
            }
         }
         imgprompt_115_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx00k0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PAYMENTMETHODID_"+sGXsfl_104_idx+"'), id:'"+"PAYMENTMETHODID_"+sGXsfl_104_idx+"'"+",IOType:'out'}"+"],"+"gx.dom.form()."+"nIsMod_21_"+sGXsfl_104_idx+","+"'', false"+","+"false"+");");
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_21_" + sGXsfl_104_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 105,'',false,'" + sGXsfl_104_idx + "',104)\"";
         ROClassString = "Attribute";
         Gridinvoice_paymentmethodRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInvoicePaymentMethodId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A118InvoicePaymentMethodId), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A118InvoicePaymentMethodId), "ZZZZZ9"))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,105);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInvoicePaymentMethodId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtInvoicePaymentMethodId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)104,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_21_" + sGXsfl_104_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 106,'',false,'" + sGXsfl_104_idx + "',104)\"";
         ROClassString = "Attribute";
         Gridinvoice_paymentmethodRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPaymentMethodId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A115PaymentMethodId), 6, 0, ".", "")),StringUtil.LTrim( ((edtPaymentMethodId_Enabled!=0) ? context.localUtil.Format( (decimal)(A115PaymentMethodId), "ZZZZZ9") : context.localUtil.Format( (decimal)(A115PaymentMethodId), "ZZZZZ9")))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,106);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPaymentMethodId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtPaymentMethodId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)104,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_115_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_115_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         Gridinvoice_paymentmethodRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_115_Internalname,(string)sImgUrl,(string)imgprompt_115_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_115_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridinvoice_paymentmethodRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPaymentMethodDescription_Internalname,(string)A116PaymentMethodDescription,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPaymentMethodDescription_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtPaymentMethodDescription_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)104,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusUnanimo\\Description",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridinvoice_paymentmethodRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPaymentMethodDiscount_Internalname,StringUtil.LTrim( StringUtil.NToC( A129PaymentMethodDiscount, 8, 2, ".", "")),StringUtil.LTrim( ((edtPaymentMethodDiscount_Enabled!=0) ? context.localUtil.Format( A129PaymentMethodDiscount, "ZZZZ9.99") : context.localUtil.Format( A129PaymentMethodDiscount, "ZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPaymentMethodDiscount_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtPaymentMethodDiscount_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)104,(short)0,(short)-1,(short)0,(bool)true,(string)"Percentage",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridinvoice_paymentmethodRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPaymentMethodRecarge_Internalname,StringUtil.LTrim( StringUtil.NToC( A130PaymentMethodRecarge, 8, 2, ".", "")),StringUtil.LTrim( ((edtPaymentMethodRecarge_Enabled!=0) ? context.localUtil.Format( A130PaymentMethodRecarge, "ZZZZ9.99") : context.localUtil.Format( A130PaymentMethodRecarge, "ZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPaymentMethodRecarge_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtPaymentMethodRecarge_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)104,(short)0,(short)-1,(short)0,(bool)true,(string)"Percentage",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_21_" + sGXsfl_104_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 110,'',false,'" + sGXsfl_104_idx + "',104)\"";
         ROClassString = "Attribute";
         Gridinvoice_paymentmethodRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInvoicePaymentMethodImport_Internalname,StringUtil.LTrim( StringUtil.NToC( A120InvoicePaymentMethodImport, 18, 2, ".", "")),StringUtil.LTrim( ((edtInvoicePaymentMethodImport_Enabled!=0) ? context.localUtil.Format( A120InvoicePaymentMethodImport, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A120InvoicePaymentMethodImport, "ZZZZZZZZZZZZZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,110);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInvoicePaymentMethodImport_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtInvoicePaymentMethodImport_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)104,(short)0,(short)-1,(short)0,(bool)true,(string)"Price",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_21_" + sGXsfl_104_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 111,'',false,'" + sGXsfl_104_idx + "',104)\"";
         ROClassString = "Attribute";
         Gridinvoice_paymentmethodRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInvoicePaymentMethodRechargeIm_Internalname,StringUtil.LTrim( StringUtil.NToC( A132InvoicePaymentMethodRechargeIm, 18, 2, ".", "")),StringUtil.LTrim( ((edtInvoicePaymentMethodRechargeIm_Enabled!=0) ? context.localUtil.Format( A132InvoicePaymentMethodRechargeIm, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A132InvoicePaymentMethodRechargeIm, "ZZZZZZZZZZZZZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,111);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInvoicePaymentMethodRechargeIm_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtInvoicePaymentMethodRechargeIm_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)104,(short)0,(short)-1,(short)0,(bool)true,(string)"Price",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_21_" + sGXsfl_104_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 112,'',false,'" + sGXsfl_104_idx + "',104)\"";
         ROClassString = "Attribute";
         Gridinvoice_paymentmethodRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInvoicePaymentMethodDiscountIm_Internalname,StringUtil.LTrim( StringUtil.NToC( A133InvoicePaymentMethodDiscountIm, 18, 2, ".", "")),StringUtil.LTrim( ((edtInvoicePaymentMethodDiscountIm_Enabled!=0) ? context.localUtil.Format( A133InvoicePaymentMethodDiscountIm, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A133InvoicePaymentMethodDiscountIm, "ZZZZZZZZZZZZZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,112);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInvoicePaymentMethodDiscountIm_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtInvoicePaymentMethodDiscountIm_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)104,(short)0,(short)-1,(short)0,(bool)true,(string)"Price",(string)"right",(bool)false,(string)""});
         ajax_sending_grid_row(Gridinvoice_paymentmethodRow);
         send_integrity_lvl_hashes0621( ) ;
         GXCCtl = "Z118InvoicePaymentMethodId_" + sGXsfl_104_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z118InvoicePaymentMethodId), 6, 0, ".", "")));
         GXCCtl = "Z120InvoicePaymentMethodImport_" + sGXsfl_104_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z120InvoicePaymentMethodImport, 18, 2, ".", "")));
         GXCCtl = "Z132InvoicePaymentMethodRechargeIm_" + sGXsfl_104_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z132InvoicePaymentMethodRechargeIm, 18, 2, ".", "")));
         GXCCtl = "Z133InvoicePaymentMethodDiscountIm_" + sGXsfl_104_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z133InvoicePaymentMethodDiscountIm, 18, 2, ".", "")));
         GXCCtl = "Z115PaymentMethodId_" + sGXsfl_104_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z115PaymentMethodId), 6, 0, ".", "")));
         GXCCtl = "nRcdDeleted_21_" + sGXsfl_104_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_21), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_21_" + sGXsfl_104_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_21), 4, 0, ".", "")));
         GXCCtl = "nIsMod_21_" + sGXsfl_104_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_21), 4, 0, ".", "")));
         GXCCtl = "vMODE_" + sGXsfl_104_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_104_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV9TrnContext);
         }
         GXCCtl = "vINVOICEID_" + sGXsfl_104_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13InvoiceId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "INVOICEPAYMENTMETHODID_"+sGXsfl_104_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvoicePaymentMethodId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PAYMENTMETHODID_"+sGXsfl_104_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPaymentMethodId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PAYMENTMETHODDESCRIPTION_"+sGXsfl_104_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPaymentMethodDescription_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PAYMENTMETHODDISCOUNT_"+sGXsfl_104_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPaymentMethodDiscount_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PAYMENTMETHODRECARGE_"+sGXsfl_104_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPaymentMethodRecarge_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "INVOICEPAYMENTMETHODIMPORT_"+sGXsfl_104_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvoicePaymentMethodImport_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "INVOICEPAYMENTMETHODRECHARGEIM_"+sGXsfl_104_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvoicePaymentMethodRechargeIm_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "INVOICEPAYMENTMETHODDISCOUNTIM_"+sGXsfl_104_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvoicePaymentMethodDiscountIm_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_115_"+sGXsfl_104_idx+"Link", StringUtil.RTrim( imgprompt_115_Link));
         ajax_sending_grid_row(null);
         Gridinvoice_paymentmethodContainer.AddRow(Gridinvoice_paymentmethodRow);
      }

      protected void ReadRow0621( )
      {
         nGXsfl_104_idx = (int)(nGXsfl_104_idx+1);
         sGXsfl_104_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_104_idx), 4, 0), 4, "0");
         SubsflControlProps_10421( ) ;
         edtInvoicePaymentMethodId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVOICEPAYMENTMETHODID_"+sGXsfl_104_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtPaymentMethodId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PAYMENTMETHODID_"+sGXsfl_104_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtPaymentMethodDescription_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PAYMENTMETHODDESCRIPTION_"+sGXsfl_104_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtPaymentMethodDiscount_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PAYMENTMETHODDISCOUNT_"+sGXsfl_104_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtPaymentMethodRecarge_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PAYMENTMETHODRECARGE_"+sGXsfl_104_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtInvoicePaymentMethodImport_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVOICEPAYMENTMETHODIMPORT_"+sGXsfl_104_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtInvoicePaymentMethodRechargeIm_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVOICEPAYMENTMETHODRECHARGEIM_"+sGXsfl_104_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtInvoicePaymentMethodDiscountIm_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVOICEPAYMENTMETHODDISCOUNTIM_"+sGXsfl_104_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         imgprompt_99_Link = cgiGet( "PROMPT_115_"+sGXsfl_104_idx+"Link");
         if ( ( ( context.localUtil.CToN( cgiGet( edtInvoicePaymentMethodId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtInvoicePaymentMethodId_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
         {
            GXCCtl = "INVOICEPAYMENTMETHODID_" + sGXsfl_104_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtInvoicePaymentMethodId_Internalname;
            wbErr = true;
            A118InvoicePaymentMethodId = 0;
         }
         else
         {
            A118InvoicePaymentMethodId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtInvoicePaymentMethodId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
         }
         if ( ( ( context.localUtil.CToN( cgiGet( edtPaymentMethodId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPaymentMethodId_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
         {
            GXCCtl = "PAYMENTMETHODID_" + sGXsfl_104_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtPaymentMethodId_Internalname;
            wbErr = true;
            A115PaymentMethodId = 0;
            n115PaymentMethodId = false;
         }
         else
         {
            A115PaymentMethodId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPaymentMethodId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
            n115PaymentMethodId = false;
         }
         n115PaymentMethodId = ((0==A115PaymentMethodId) ? true : false);
         A116PaymentMethodDescription = cgiGet( edtPaymentMethodDescription_Internalname);
         A129PaymentMethodDiscount = context.localUtil.CToN( cgiGet( edtPaymentMethodDiscount_Internalname), ".", ",");
         A130PaymentMethodRecarge = context.localUtil.CToN( cgiGet( edtPaymentMethodRecarge_Internalname), ".", ",");
         if ( ( ( context.localUtil.CToN( cgiGet( edtInvoicePaymentMethodImport_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtInvoicePaymentMethodImport_Internalname), ".", ",") > 999999999999999.99m ) ) )
         {
            GXCCtl = "INVOICEPAYMENTMETHODIMPORT_" + sGXsfl_104_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtInvoicePaymentMethodImport_Internalname;
            wbErr = true;
            A120InvoicePaymentMethodImport = 0;
            n120InvoicePaymentMethodImport = false;
         }
         else
         {
            A120InvoicePaymentMethodImport = context.localUtil.CToN( cgiGet( edtInvoicePaymentMethodImport_Internalname), ".", ",");
            n120InvoicePaymentMethodImport = false;
         }
         n120InvoicePaymentMethodImport = ((Convert.ToDecimal(0)==A120InvoicePaymentMethodImport) ? true : false);
         if ( ( ( context.localUtil.CToN( cgiGet( edtInvoicePaymentMethodRechargeIm_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtInvoicePaymentMethodRechargeIm_Internalname), ".", ",") > 999999999999999.99m ) ) )
         {
            GXCCtl = "INVOICEPAYMENTMETHODRECHARGEIM_" + sGXsfl_104_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtInvoicePaymentMethodRechargeIm_Internalname;
            wbErr = true;
            A132InvoicePaymentMethodRechargeIm = 0;
            n132InvoicePaymentMethodRechargeIm = false;
         }
         else
         {
            A132InvoicePaymentMethodRechargeIm = context.localUtil.CToN( cgiGet( edtInvoicePaymentMethodRechargeIm_Internalname), ".", ",");
            n132InvoicePaymentMethodRechargeIm = false;
         }
         n132InvoicePaymentMethodRechargeIm = ((Convert.ToDecimal(0)==A132InvoicePaymentMethodRechargeIm) ? true : false);
         if ( ( ( context.localUtil.CToN( cgiGet( edtInvoicePaymentMethodDiscountIm_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtInvoicePaymentMethodDiscountIm_Internalname), ".", ",") > 999999999999999.99m ) ) )
         {
            GXCCtl = "INVOICEPAYMENTMETHODDISCOUNTIM_" + sGXsfl_104_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtInvoicePaymentMethodDiscountIm_Internalname;
            wbErr = true;
            A133InvoicePaymentMethodDiscountIm = 0;
            n133InvoicePaymentMethodDiscountIm = false;
         }
         else
         {
            A133InvoicePaymentMethodDiscountIm = context.localUtil.CToN( cgiGet( edtInvoicePaymentMethodDiscountIm_Internalname), ".", ",");
            n133InvoicePaymentMethodDiscountIm = false;
         }
         n133InvoicePaymentMethodDiscountIm = ((Convert.ToDecimal(0)==A133InvoicePaymentMethodDiscountIm) ? true : false);
         GXCCtl = "Z118InvoicePaymentMethodId_" + sGXsfl_104_idx;
         Z118InvoicePaymentMethodId = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "Z120InvoicePaymentMethodImport_" + sGXsfl_104_idx;
         Z120InvoicePaymentMethodImport = context.localUtil.CToN( cgiGet( GXCCtl), ".", ",");
         n120InvoicePaymentMethodImport = ((Convert.ToDecimal(0)==A120InvoicePaymentMethodImport) ? true : false);
         GXCCtl = "Z132InvoicePaymentMethodRechargeIm_" + sGXsfl_104_idx;
         Z132InvoicePaymentMethodRechargeIm = context.localUtil.CToN( cgiGet( GXCCtl), ".", ",");
         n132InvoicePaymentMethodRechargeIm = ((Convert.ToDecimal(0)==A132InvoicePaymentMethodRechargeIm) ? true : false);
         GXCCtl = "Z133InvoicePaymentMethodDiscountIm_" + sGXsfl_104_idx;
         Z133InvoicePaymentMethodDiscountIm = context.localUtil.CToN( cgiGet( GXCCtl), ".", ",");
         n133InvoicePaymentMethodDiscountIm = ((Convert.ToDecimal(0)==A133InvoicePaymentMethodDiscountIm) ? true : false);
         GXCCtl = "Z115PaymentMethodId_" + sGXsfl_104_idx;
         Z115PaymentMethodId = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         n115PaymentMethodId = ((0==A115PaymentMethodId) ? true : false);
         GXCCtl = "nRcdDeleted_21_" + sGXsfl_104_idx;
         nRcdDeleted_21 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_21_" + sGXsfl_104_idx;
         nRcdExists_21 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_21_" + sGXsfl_104_idx;
         nIsMod_21 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtInvoicePaymentMethodId_Enabled = edtInvoicePaymentMethodId_Enabled;
         defedtInvoiceDetailId_Enabled = edtInvoiceDetailId_Enabled;
      }

      protected void ConfirmValues060( )
      {
         nGXsfl_88_idx = 0;
         sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
         SubsflControlProps_8813( ) ;
         while ( nGXsfl_88_idx < nRC_GXsfl_88 )
         {
            nGXsfl_88_idx = (int)(nGXsfl_88_idx+1);
            sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
            SubsflControlProps_8813( ) ;
            ChangePostValue( "Z25InvoiceDetailId_"+sGXsfl_88_idx, cgiGet( "ZT_"+"Z25InvoiceDetailId_"+sGXsfl_88_idx)) ;
            DeletePostValue( "ZT_"+"Z25InvoiceDetailId_"+sGXsfl_88_idx) ;
            ChangePostValue( "Z26InvoiceDetailQuantity_"+sGXsfl_88_idx, cgiGet( "ZT_"+"Z26InvoiceDetailQuantity_"+sGXsfl_88_idx)) ;
            DeletePostValue( "ZT_"+"Z26InvoiceDetailQuantity_"+sGXsfl_88_idx) ;
            ChangePostValue( "Z65InvoiceDetailHistoricPrice_"+sGXsfl_88_idx, cgiGet( "ZT_"+"Z65InvoiceDetailHistoricPrice_"+sGXsfl_88_idx)) ;
            DeletePostValue( "ZT_"+"Z65InvoiceDetailHistoricPrice_"+sGXsfl_88_idx) ;
            ChangePostValue( "Z98InvoiceDetailIsWholesale_"+sGXsfl_88_idx, cgiGet( "ZT_"+"Z98InvoiceDetailIsWholesale_"+sGXsfl_88_idx)) ;
            DeletePostValue( "ZT_"+"Z98InvoiceDetailIsWholesale_"+sGXsfl_88_idx) ;
            ChangePostValue( "Z15ProductId_"+sGXsfl_88_idx, cgiGet( "ZT_"+"Z15ProductId_"+sGXsfl_88_idx)) ;
            DeletePostValue( "ZT_"+"Z15ProductId_"+sGXsfl_88_idx) ;
         }
         nGXsfl_104_idx = 0;
         sGXsfl_104_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_104_idx), 4, 0), 4, "0");
         SubsflControlProps_10421( ) ;
         while ( nGXsfl_104_idx < nRC_GXsfl_104 )
         {
            nGXsfl_104_idx = (int)(nGXsfl_104_idx+1);
            sGXsfl_104_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_104_idx), 4, 0), 4, "0");
            SubsflControlProps_10421( ) ;
            ChangePostValue( "Z118InvoicePaymentMethodId_"+sGXsfl_104_idx, cgiGet( "ZT_"+"Z118InvoicePaymentMethodId_"+sGXsfl_104_idx)) ;
            DeletePostValue( "ZT_"+"Z118InvoicePaymentMethodId_"+sGXsfl_104_idx) ;
            ChangePostValue( "Z120InvoicePaymentMethodImport_"+sGXsfl_104_idx, cgiGet( "ZT_"+"Z120InvoicePaymentMethodImport_"+sGXsfl_104_idx)) ;
            DeletePostValue( "ZT_"+"Z120InvoicePaymentMethodImport_"+sGXsfl_104_idx) ;
            ChangePostValue( "Z132InvoicePaymentMethodRechargeIm_"+sGXsfl_104_idx, cgiGet( "ZT_"+"Z132InvoicePaymentMethodRechargeIm_"+sGXsfl_104_idx)) ;
            DeletePostValue( "ZT_"+"Z132InvoicePaymentMethodRechargeIm_"+sGXsfl_104_idx) ;
            ChangePostValue( "Z133InvoicePaymentMethodDiscountIm_"+sGXsfl_104_idx, cgiGet( "ZT_"+"Z133InvoicePaymentMethodDiscountIm_"+sGXsfl_104_idx)) ;
            DeletePostValue( "ZT_"+"Z133InvoicePaymentMethodDiscountIm_"+sGXsfl_104_idx) ;
            ChangePostValue( "Z115PaymentMethodId_"+sGXsfl_104_idx, cgiGet( "ZT_"+"Z115PaymentMethodId_"+sGXsfl_104_idx)) ;
            DeletePostValue( "ZT_"+"Z115PaymentMethodId_"+sGXsfl_104_idx) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("invoice.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV13InvoiceId,6,0))}, new string[] {"Gx_mode","InvoiceId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Invoice");
         forbiddenHiddens.Add("InvoiceId", context.localUtil.Format( (decimal)(A20InvoiceId), "ZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("invoice:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z20InvoiceId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z20InvoiceId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z38InvoiceCreatedDate", context.localUtil.DToC( Z38InvoiceCreatedDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z39InvoiceModifiedDate", context.localUtil.DToC( Z39InvoiceModifiedDate, 0, "/"));
         GxWebStd.gx_boolean_hidden_field( context, "Z94InvoiceActive", Z94InvoiceActive);
         GxWebStd.gx_hidden_field( context, "Z99UserId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z99UserId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "O131InvoiceLastPaymentMethodId", StringUtil.LTrim( StringUtil.NToC( (decimal)(O131InvoiceLastPaymentMethodId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "O97InvoiceLastDetailId", StringUtil.LTrim( StringUtil.NToC( (decimal)(O97InvoiceLastDetailId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "O68InvoiceProductQuantity", StringUtil.LTrim( StringUtil.NToC( (decimal)(O68InvoiceProductQuantity), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_88", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_88_idx), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_104", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_104_idx), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N99UserId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A99UserId), 6, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "vINVOICEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13InvoiceId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vINVOICEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13InvoiceId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_USERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14Insert_UserId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV21Pgmname));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
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
         return formatLink("invoice.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV13InvoiceId,6,0))}, new string[] {"Gx_mode","InvoiceId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Invoice" ;
      }

      public override string GetPgmdesc( )
      {
         return "Invoice" ;
      }

      protected void InitializeNonKey066( )
      {
         A99UserId = 0;
         AssignAttri("", false, "A99UserId", StringUtil.LTrimStr( (decimal)(A99UserId), 6, 0));
         A38InvoiceCreatedDate = DateTime.MinValue;
         AssignAttri("", false, "A38InvoiceCreatedDate", context.localUtil.Format(A38InvoiceCreatedDate, "99/99/99"));
         A100UserName = "";
         AssignAttri("", false, "A100UserName", A100UserName);
         A39InvoiceModifiedDate = DateTime.MinValue;
         n39InvoiceModifiedDate = false;
         AssignAttri("", false, "A39InvoiceModifiedDate", context.localUtil.Format(A39InvoiceModifiedDate, "99/99/99"));
         n39InvoiceModifiedDate = ((DateTime.MinValue==A39InvoiceModifiedDate) ? true : false);
         A94InvoiceActive = false;
         AssignAttri("", false, "A94InvoiceActive", A94InvoiceActive);
         A80InvoiceTotalReceivable = 0;
         n80InvoiceTotalReceivable = false;
         AssignAttri("", false, "A80InvoiceTotalReceivable", StringUtil.LTrimStr( A80InvoiceTotalReceivable, 18, 2));
         A68InvoiceProductQuantity = 0;
         AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
         A97InvoiceLastDetailId = 0;
         AssignAttri("", false, "A97InvoiceLastDetailId", StringUtil.LTrimStr( (decimal)(A97InvoiceLastDetailId), 6, 0));
         A131InvoiceLastPaymentMethodId = 0;
         n131InvoiceLastPaymentMethodId = false;
         AssignAttri("", false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
         O131InvoiceLastPaymentMethodId = A131InvoiceLastPaymentMethodId;
         n131InvoiceLastPaymentMethodId = false;
         AssignAttri("", false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
         O97InvoiceLastDetailId = A97InvoiceLastDetailId;
         AssignAttri("", false, "A97InvoiceLastDetailId", StringUtil.LTrimStr( (decimal)(A97InvoiceLastDetailId), 6, 0));
         O68InvoiceProductQuantity = A68InvoiceProductQuantity;
         AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
         Z38InvoiceCreatedDate = DateTime.MinValue;
         Z39InvoiceModifiedDate = DateTime.MinValue;
         Z94InvoiceActive = false;
         Z99UserId = 0;
      }

      protected void InitAll066( )
      {
         A20InvoiceId = 0;
         AssignAttri("", false, "A20InvoiceId", StringUtil.LTrimStr( (decimal)(A20InvoiceId), 6, 0));
         InitializeNonKey066( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey0613( )
      {
         A15ProductId = 0;
         A16ProductName = "";
         A17ProductStock = 0;
         n17ProductStock = false;
         A26InvoiceDetailQuantity = 0;
         A65InvoiceDetailHistoricPrice = 0;
         A98InvoiceDetailIsWholesale = false;
         Z26InvoiceDetailQuantity = 0;
         Z65InvoiceDetailHistoricPrice = 0;
         Z98InvoiceDetailIsWholesale = false;
         Z15ProductId = 0;
      }

      protected void InitAll0613( )
      {
         A25InvoiceDetailId = 0;
         InitializeNonKey0613( ) ;
      }

      protected void StandaloneModalInsert0613( )
      {
         A97InvoiceLastDetailId = i97InvoiceLastDetailId;
         AssignAttri("", false, "A97InvoiceLastDetailId", StringUtil.LTrimStr( (decimal)(A97InvoiceLastDetailId), 6, 0));
      }

      protected void InitializeNonKey0621( )
      {
         A115PaymentMethodId = 0;
         n115PaymentMethodId = false;
         A116PaymentMethodDescription = "";
         A129PaymentMethodDiscount = 0;
         A130PaymentMethodRecarge = 0;
         A120InvoicePaymentMethodImport = 0;
         n120InvoicePaymentMethodImport = false;
         A132InvoicePaymentMethodRechargeIm = 0;
         n132InvoicePaymentMethodRechargeIm = false;
         A133InvoicePaymentMethodDiscountIm = 0;
         n133InvoicePaymentMethodDiscountIm = false;
         Z120InvoicePaymentMethodImport = 0;
         Z132InvoicePaymentMethodRechargeIm = 0;
         Z133InvoicePaymentMethodDiscountIm = 0;
         Z115PaymentMethodId = 0;
      }

      protected void InitAll0621( )
      {
         A118InvoicePaymentMethodId = 0;
         InitializeNonKey0621( ) ;
      }

      protected void StandaloneModalInsert0621( )
      {
         A131InvoiceLastPaymentMethodId = i131InvoiceLastPaymentMethodId;
         n131InvoiceLastPaymentMethodId = false;
         AssignAttri("", false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrimStr( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20241261113168", true, true);
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
         context.AddJavascriptSource("gxdec.js", "?"+context.GetBuildNumber( 1853160), false, true);
         context.AddJavascriptSource("invoice.js", "?20241261113169", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties13( )
      {
         edtInvoiceDetailId_Enabled = defedtInvoiceDetailId_Enabled;
         AssignProp("", false, edtInvoiceDetailId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceDetailId_Enabled), 5, 0), !bGXsfl_88_Refreshing);
      }

      protected void init_level_properties21( )
      {
         edtInvoicePaymentMethodId_Enabled = defedtInvoicePaymentMethodId_Enabled;
         AssignProp("", false, edtInvoicePaymentMethodId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoicePaymentMethodId_Enabled), 5, 0), !bGXsfl_104_Refreshing);
      }

      protected void StartGridControl88( )
      {
         Gridinvoice_detailContainer.AddObjectProperty("GridName", "Gridinvoice_detail");
         Gridinvoice_detailContainer.AddObjectProperty("Header", subGridinvoice_detail_Header);
         Gridinvoice_detailContainer.AddObjectProperty("Class", "Grid");
         Gridinvoice_detailContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridinvoice_detailContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridinvoice_detailContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoice_detail_Backcolorstyle), 1, 0, ".", "")));
         Gridinvoice_detailContainer.AddObjectProperty("CmpContext", "");
         Gridinvoice_detailContainer.AddObjectProperty("InMasterPage", "false");
         Gridinvoice_detailColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridinvoice_detailColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A25InvoiceDetailId), 6, 0, ".", ""))));
         Gridinvoice_detailColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvoiceDetailId_Enabled), 5, 0, ".", "")));
         Gridinvoice_detailContainer.AddColumnProperties(Gridinvoice_detailColumn);
         Gridinvoice_detailColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridinvoice_detailColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", ""))));
         Gridinvoice_detailColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductId_Enabled), 5, 0, ".", "")));
         Gridinvoice_detailContainer.AddColumnProperties(Gridinvoice_detailColumn);
         Gridinvoice_detailColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridinvoice_detailContainer.AddColumnProperties(Gridinvoice_detailColumn);
         Gridinvoice_detailColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridinvoice_detailColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A16ProductName));
         Gridinvoice_detailColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductName_Enabled), 5, 0, ".", "")));
         Gridinvoice_detailContainer.AddColumnProperties(Gridinvoice_detailColumn);
         Gridinvoice_detailColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridinvoice_detailColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A17ProductStock), 6, 0, ".", ""))));
         Gridinvoice_detailColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductStock_Enabled), 5, 0, ".", "")));
         Gridinvoice_detailContainer.AddColumnProperties(Gridinvoice_detailColumn);
         Gridinvoice_detailColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridinvoice_detailColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A26InvoiceDetailQuantity), 6, 0, ".", ""))));
         Gridinvoice_detailColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvoiceDetailQuantity_Enabled), 5, 0, ".", "")));
         Gridinvoice_detailContainer.AddColumnProperties(Gridinvoice_detailColumn);
         Gridinvoice_detailColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridinvoice_detailColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A65InvoiceDetailHistoricPrice, 18, 2, ".", ""))));
         Gridinvoice_detailColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvoiceDetailHistoricPrice_Enabled), 5, 0, ".", "")));
         Gridinvoice_detailContainer.AddColumnProperties(Gridinvoice_detailColumn);
         Gridinvoice_detailColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridinvoice_detailColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A98InvoiceDetailIsWholesale)));
         Gridinvoice_detailColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkInvoiceDetailIsWholesale.Enabled), 5, 0, ".", "")));
         Gridinvoice_detailContainer.AddColumnProperties(Gridinvoice_detailColumn);
         Gridinvoice_detailContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoice_detail_Selectedindex), 4, 0, ".", "")));
         Gridinvoice_detailContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoice_detail_Allowselection), 1, 0, ".", "")));
         Gridinvoice_detailContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoice_detail_Selectioncolor), 9, 0, ".", "")));
         Gridinvoice_detailContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoice_detail_Allowhovering), 1, 0, ".", "")));
         Gridinvoice_detailContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoice_detail_Hoveringcolor), 9, 0, ".", "")));
         Gridinvoice_detailContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoice_detail_Allowcollapsing), 1, 0, ".", "")));
         Gridinvoice_detailContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoice_detail_Collapsed), 1, 0, ".", "")));
      }

      protected void StartGridControl104( )
      {
         Gridinvoice_paymentmethodContainer.AddObjectProperty("GridName", "Gridinvoice_paymentmethod");
         Gridinvoice_paymentmethodContainer.AddObjectProperty("Header", subGridinvoice_paymentmethod_Header);
         Gridinvoice_paymentmethodContainer.AddObjectProperty("Class", "Grid");
         Gridinvoice_paymentmethodContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridinvoice_paymentmethodContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridinvoice_paymentmethodContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoice_paymentmethod_Backcolorstyle), 1, 0, ".", "")));
         Gridinvoice_paymentmethodContainer.AddObjectProperty("CmpContext", "");
         Gridinvoice_paymentmethodContainer.AddObjectProperty("InMasterPage", "false");
         Gridinvoice_paymentmethodColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridinvoice_paymentmethodColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A118InvoicePaymentMethodId), 6, 0, ".", ""))));
         Gridinvoice_paymentmethodColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvoicePaymentMethodId_Enabled), 5, 0, ".", "")));
         Gridinvoice_paymentmethodContainer.AddColumnProperties(Gridinvoice_paymentmethodColumn);
         Gridinvoice_paymentmethodColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridinvoice_paymentmethodColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A115PaymentMethodId), 6, 0, ".", ""))));
         Gridinvoice_paymentmethodColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPaymentMethodId_Enabled), 5, 0, ".", "")));
         Gridinvoice_paymentmethodContainer.AddColumnProperties(Gridinvoice_paymentmethodColumn);
         Gridinvoice_paymentmethodColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridinvoice_paymentmethodContainer.AddColumnProperties(Gridinvoice_paymentmethodColumn);
         Gridinvoice_paymentmethodColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridinvoice_paymentmethodColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A116PaymentMethodDescription));
         Gridinvoice_paymentmethodColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPaymentMethodDescription_Enabled), 5, 0, ".", "")));
         Gridinvoice_paymentmethodContainer.AddColumnProperties(Gridinvoice_paymentmethodColumn);
         Gridinvoice_paymentmethodColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridinvoice_paymentmethodColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A129PaymentMethodDiscount, 8, 2, ".", ""))));
         Gridinvoice_paymentmethodColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPaymentMethodDiscount_Enabled), 5, 0, ".", "")));
         Gridinvoice_paymentmethodContainer.AddColumnProperties(Gridinvoice_paymentmethodColumn);
         Gridinvoice_paymentmethodColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridinvoice_paymentmethodColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A130PaymentMethodRecarge, 8, 2, ".", ""))));
         Gridinvoice_paymentmethodColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPaymentMethodRecarge_Enabled), 5, 0, ".", "")));
         Gridinvoice_paymentmethodContainer.AddColumnProperties(Gridinvoice_paymentmethodColumn);
         Gridinvoice_paymentmethodColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridinvoice_paymentmethodColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A120InvoicePaymentMethodImport, 18, 2, ".", ""))));
         Gridinvoice_paymentmethodColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvoicePaymentMethodImport_Enabled), 5, 0, ".", "")));
         Gridinvoice_paymentmethodContainer.AddColumnProperties(Gridinvoice_paymentmethodColumn);
         Gridinvoice_paymentmethodColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridinvoice_paymentmethodColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A132InvoicePaymentMethodRechargeIm, 18, 2, ".", ""))));
         Gridinvoice_paymentmethodColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvoicePaymentMethodRechargeIm_Enabled), 5, 0, ".", "")));
         Gridinvoice_paymentmethodContainer.AddColumnProperties(Gridinvoice_paymentmethodColumn);
         Gridinvoice_paymentmethodColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridinvoice_paymentmethodColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A133InvoicePaymentMethodDiscountIm, 18, 2, ".", ""))));
         Gridinvoice_paymentmethodColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvoicePaymentMethodDiscountIm_Enabled), 5, 0, ".", "")));
         Gridinvoice_paymentmethodContainer.AddColumnProperties(Gridinvoice_paymentmethodColumn);
         Gridinvoice_paymentmethodContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoice_paymentmethod_Selectedindex), 4, 0, ".", "")));
         Gridinvoice_paymentmethodContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoice_paymentmethod_Allowselection), 1, 0, ".", "")));
         Gridinvoice_paymentmethodContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoice_paymentmethod_Selectioncolor), 9, 0, ".", "")));
         Gridinvoice_paymentmethodContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoice_paymentmethod_Allowhovering), 1, 0, ".", "")));
         Gridinvoice_paymentmethodContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoice_paymentmethod_Hoveringcolor), 9, 0, ".", "")));
         Gridinvoice_paymentmethodContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoice_paymentmethod_Allowcollapsing), 1, 0, ".", "")));
         Gridinvoice_paymentmethodContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoice_paymentmethod_Collapsed), 1, 0, ".", "")));
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
         edtInvoiceId_Internalname = "INVOICEID";
         edtInvoiceCreatedDate_Internalname = "INVOICECREATEDDATE";
         edtUserId_Internalname = "USERID";
         edtUserName_Internalname = "USERNAME";
         edtInvoiceModifiedDate_Internalname = "INVOICEMODIFIEDDATE";
         chkInvoiceActive_Internalname = "INVOICEACTIVE";
         edtInvoiceTotalReceivable_Internalname = "INVOICETOTALRECEIVABLE";
         edtInvoiceProductQuantity_Internalname = "INVOICEPRODUCTQUANTITY";
         edtInvoiceLastDetailId_Internalname = "INVOICELASTDETAILID";
         edtInvoiceLastPaymentMethodId_Internalname = "INVOICELASTPAYMENTMETHODID";
         lblTitledetail_Internalname = "TITLEDETAIL";
         edtInvoiceDetailId_Internalname = "INVOICEDETAILID";
         edtProductId_Internalname = "PRODUCTID";
         edtProductName_Internalname = "PRODUCTNAME";
         edtProductStock_Internalname = "PRODUCTSTOCK";
         edtInvoiceDetailQuantity_Internalname = "INVOICEDETAILQUANTITY";
         edtInvoiceDetailHistoricPrice_Internalname = "INVOICEDETAILHISTORICPRICE";
         chkInvoiceDetailIsWholesale_Internalname = "INVOICEDETAILISWHOLESALE";
         divDetailtable_Internalname = "DETAILTABLE";
         lblTitlepaymentmethod_Internalname = "TITLEPAYMENTMETHOD";
         edtInvoicePaymentMethodId_Internalname = "INVOICEPAYMENTMETHODID";
         edtPaymentMethodId_Internalname = "PAYMENTMETHODID";
         edtPaymentMethodDescription_Internalname = "PAYMENTMETHODDESCRIPTION";
         edtPaymentMethodDiscount_Internalname = "PAYMENTMETHODDISCOUNT";
         edtPaymentMethodRecarge_Internalname = "PAYMENTMETHODRECARGE";
         edtInvoicePaymentMethodImport_Internalname = "INVOICEPAYMENTMETHODIMPORT";
         edtInvoicePaymentMethodRechargeIm_Internalname = "INVOICEPAYMENTMETHODRECHARGEIM";
         edtInvoicePaymentMethodDiscountIm_Internalname = "INVOICEPAYMENTMETHODDISCOUNTIM";
         divPaymentmethodtable_Internalname = "PAYMENTMETHODTABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_99_Internalname = "PROMPT_99";
         imgprompt_15_Internalname = "PROMPT_15";
         imgprompt_115_Internalname = "PROMPT_115";
         subGridinvoice_detail_Internalname = "GRIDINVOICE_DETAIL";
         subGridinvoice_paymentmethod_Internalname = "GRIDINVOICE_PAYMENTMETHOD";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("mtaKB", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridinvoice_paymentmethod_Allowcollapsing = 0;
         subGridinvoice_paymentmethod_Allowselection = 0;
         subGridinvoice_paymentmethod_Header = "";
         subGridinvoice_detail_Allowcollapsing = 0;
         subGridinvoice_detail_Allowselection = 0;
         subGridinvoice_detail_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Invoice";
         edtInvoicePaymentMethodDiscountIm_Jsonclick = "";
         edtInvoicePaymentMethodRechargeIm_Jsonclick = "";
         edtInvoicePaymentMethodImport_Jsonclick = "";
         edtPaymentMethodRecarge_Jsonclick = "";
         edtPaymentMethodDiscount_Jsonclick = "";
         edtPaymentMethodDescription_Jsonclick = "";
         imgprompt_115_Visible = 1;
         imgprompt_115_Link = "";
         edtPaymentMethodId_Jsonclick = "";
         edtInvoicePaymentMethodId_Jsonclick = "";
         subGridinvoice_paymentmethod_Class = "Grid";
         subGridinvoice_paymentmethod_Backcolorstyle = 0;
         chkInvoiceDetailIsWholesale.Caption = "";
         edtInvoiceDetailHistoricPrice_Jsonclick = "";
         edtInvoiceDetailQuantity_Jsonclick = "";
         edtProductStock_Jsonclick = "";
         edtProductName_Jsonclick = "";
         imgprompt_15_Visible = 1;
         imgprompt_15_Link = "";
         imgprompt_99_Visible = 1;
         edtProductId_Jsonclick = "";
         edtInvoiceDetailId_Jsonclick = "";
         subGridinvoice_detail_Class = "Grid";
         subGridinvoice_detail_Backcolorstyle = 0;
         edtInvoicePaymentMethodDiscountIm_Enabled = 1;
         edtInvoicePaymentMethodRechargeIm_Enabled = 1;
         edtInvoicePaymentMethodImport_Enabled = 1;
         edtPaymentMethodRecarge_Enabled = 0;
         edtPaymentMethodDiscount_Enabled = 0;
         edtPaymentMethodDescription_Enabled = 0;
         edtPaymentMethodId_Enabled = 1;
         edtInvoicePaymentMethodId_Enabled = 1;
         chkInvoiceDetailIsWholesale.Enabled = 1;
         edtInvoiceDetailHistoricPrice_Enabled = 1;
         edtInvoiceDetailQuantity_Enabled = 1;
         edtProductStock_Enabled = 0;
         edtProductName_Enabled = 0;
         edtProductId_Enabled = 1;
         edtInvoiceDetailId_Enabled = 1;
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirm";
         bttBtn_enter_Caption = "Confirm";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtInvoiceLastPaymentMethodId_Jsonclick = "";
         edtInvoiceLastPaymentMethodId_Enabled = 0;
         edtInvoiceLastDetailId_Jsonclick = "";
         edtInvoiceLastDetailId_Enabled = 0;
         edtInvoiceProductQuantity_Jsonclick = "";
         edtInvoiceProductQuantity_Enabled = 0;
         edtInvoiceTotalReceivable_Jsonclick = "";
         edtInvoiceTotalReceivable_Enabled = 0;
         chkInvoiceActive.Enabled = 1;
         edtInvoiceModifiedDate_Jsonclick = "";
         edtInvoiceModifiedDate_Enabled = 1;
         edtUserName_Jsonclick = "";
         edtUserName_Enabled = 0;
         imgprompt_99_Visible = 1;
         imgprompt_99_Link = "";
         edtUserId_Jsonclick = "";
         edtUserId_Enabled = 1;
         edtInvoiceCreatedDate_Jsonclick = "";
         edtInvoiceCreatedDate_Enabled = 1;
         edtInvoiceId_Jsonclick = "";
         edtInvoiceId_Enabled = 0;
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

      protected void gxnrGridinvoice_detail_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_8813( ) ;
         while ( nGXsfl_88_idx <= nRC_GXsfl_88 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0613( ) ;
            standaloneModal0613( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0613( ) ;
            nGXsfl_88_idx = (int)(nGXsfl_88_idx+1);
            sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
            SubsflControlProps_8813( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridinvoice_detailContainer)) ;
         /* End function gxnrGridinvoice_detail_newrow */
      }

      protected void gxnrGridinvoice_paymentmethod_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_10421( ) ;
         while ( nGXsfl_104_idx <= nRC_GXsfl_104 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0621( ) ;
            standaloneModal0621( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0621( ) ;
            nGXsfl_104_idx = (int)(nGXsfl_104_idx+1);
            sGXsfl_104_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_104_idx), 4, 0), 4, "0");
            SubsflControlProps_10421( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridinvoice_paymentmethodContainer)) ;
         /* End function gxnrGridinvoice_paymentmethod_newrow */
      }

      protected void init_web_controls( )
      {
         chkInvoiceActive.Name = "INVOICEACTIVE";
         chkInvoiceActive.WebTags = "";
         chkInvoiceActive.Caption = "";
         AssignProp("", false, chkInvoiceActive_Internalname, "TitleCaption", chkInvoiceActive.Caption, true);
         chkInvoiceActive.CheckedValue = "false";
         A94InvoiceActive = StringUtil.StrToBool( StringUtil.BoolToStr( A94InvoiceActive));
         AssignAttri("", false, "A94InvoiceActive", A94InvoiceActive);
         GXCCtl = "INVOICEDETAILISWHOLESALE_" + sGXsfl_88_idx;
         chkInvoiceDetailIsWholesale.Name = GXCCtl;
         chkInvoiceDetailIsWholesale.WebTags = "";
         chkInvoiceDetailIsWholesale.Caption = "";
         AssignProp("", false, chkInvoiceDetailIsWholesale_Internalname, "TitleCaption", chkInvoiceDetailIsWholesale.Caption, !bGXsfl_88_Refreshing);
         chkInvoiceDetailIsWholesale.CheckedValue = "false";
         A98InvoiceDetailIsWholesale = StringUtil.StrToBool( StringUtil.BoolToStr( A98InvoiceDetailIsWholesale));
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

      public void Valid_Invoiceid( )
      {
         n80InvoiceTotalReceivable = false;
         n131InvoiceLastPaymentMethodId = false;
         /* Using cursor T000640 */
         pr_default.execute(23, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(23) != 101) )
         {
            A80InvoiceTotalReceivable = T000640_A80InvoiceTotalReceivable[0];
            n80InvoiceTotalReceivable = T000640_n80InvoiceTotalReceivable[0];
         }
         else
         {
            A80InvoiceTotalReceivable = 0;
            n80InvoiceTotalReceivable = false;
         }
         pr_default.close(23);
         /* Using cursor T000642 */
         pr_default.execute(24, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(24) != 101) )
         {
            A68InvoiceProductQuantity = T000642_A68InvoiceProductQuantity[0];
            A97InvoiceLastDetailId = T000642_A97InvoiceLastDetailId[0];
         }
         else
         {
            A68InvoiceProductQuantity = 0;
            A97InvoiceLastDetailId = 0;
         }
         pr_default.close(24);
         /* Using cursor T000644 */
         pr_default.execute(25, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(25) != 101) )
         {
            A131InvoiceLastPaymentMethodId = T000644_A131InvoiceLastPaymentMethodId[0];
            n131InvoiceLastPaymentMethodId = T000644_n131InvoiceLastPaymentMethodId[0];
         }
         else
         {
            A131InvoiceLastPaymentMethodId = 0;
            n131InvoiceLastPaymentMethodId = false;
         }
         pr_default.close(25);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A80InvoiceTotalReceivable", StringUtil.LTrim( StringUtil.NToC( A80InvoiceTotalReceivable, 18, 2, ".", "")));
         AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrim( StringUtil.NToC( (decimal)(A68InvoiceProductQuantity), 4, 0, ".", "")));
         AssignAttri("", false, "A97InvoiceLastDetailId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A97InvoiceLastDetailId), 6, 0, ".", "")));
         AssignAttri("", false, "A131InvoiceLastPaymentMethodId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A131InvoiceLastPaymentMethodId), 6, 0, ".", "")));
      }

      public void Valid_Userid( )
      {
         /* Using cursor T000645 */
         pr_default.execute(26, new Object[] {A99UserId});
         if ( (pr_default.getStatus(26) == 101) )
         {
            GX_msglist.addItem("No matching 'User'.", "ForeignKeyNotFound", 1, "USERID");
            AnyError = 1;
            GX_FocusControl = edtUserId_Internalname;
         }
         A100UserName = T000645_A100UserName[0];
         pr_default.close(26);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A100UserName", A100UserName);
      }

      public void Valid_Productid( )
      {
         n17ProductStock = false;
         /* Using cursor T000653 */
         pr_default.execute(34, new Object[] {A15ProductId});
         if ( (pr_default.getStatus(34) == 101) )
         {
            GX_msglist.addItem("No matching 'Product'.", "ForeignKeyNotFound", 1, "PRODUCTID");
            AnyError = 1;
            GX_FocusControl = edtProductId_Internalname;
         }
         A16ProductName = T000653_A16ProductName[0];
         A17ProductStock = T000653_A17ProductStock[0];
         n17ProductStock = T000653_n17ProductStock[0];
         pr_default.close(34);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A16ProductName", A16ProductName);
         AssignAttri("", false, "A17ProductStock", StringUtil.LTrim( StringUtil.NToC( (decimal)(A17ProductStock), 6, 0, ".", "")));
      }

      public void Valid_Paymentmethodid( )
      {
         n115PaymentMethodId = false;
         /* Using cursor T000661 */
         pr_default.execute(42, new Object[] {n115PaymentMethodId, A115PaymentMethodId});
         if ( (pr_default.getStatus(42) == 101) )
         {
            if ( ! ( (0==A115PaymentMethodId) ) )
            {
               GX_msglist.addItem("No matching 'Payment Method of Invoices'.", "ForeignKeyNotFound", 1, "PAYMENTMETHODID");
               AnyError = 1;
               GX_FocusControl = edtPaymentMethodId_Internalname;
            }
         }
         A116PaymentMethodDescription = T000661_A116PaymentMethodDescription[0];
         A129PaymentMethodDiscount = T000661_A129PaymentMethodDiscount[0];
         A130PaymentMethodRecarge = T000661_A130PaymentMethodRecarge[0];
         pr_default.close(42);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A116PaymentMethodDescription", A116PaymentMethodDescription);
         AssignAttri("", false, "A129PaymentMethodDiscount", StringUtil.LTrim( StringUtil.NToC( A129PaymentMethodDiscount, 8, 2, ".", "")));
         AssignAttri("", false, "A130PaymentMethodRecarge", StringUtil.LTrim( StringUtil.NToC( A130PaymentMethodRecarge, 8, 2, ".", "")));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV13InvoiceId',fld:'vINVOICEID',pic:'ZZZZZ9',hsh:true},{av:'A94InvoiceActive',fld:'INVOICEACTIVE',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'A94InvoiceActive',fld:'INVOICEACTIVE',pic:''}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV13InvoiceId',fld:'vINVOICEID',pic:'ZZZZZ9',hsh:true},{av:'A20InvoiceId',fld:'INVOICEID',pic:'ZZZZZ9'},{av:'A94InvoiceActive',fld:'INVOICEACTIVE',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A94InvoiceActive',fld:'INVOICEACTIVE',pic:''}]}");
         setEventMetadata("AFTER TRN","{handler:'E12062',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A94InvoiceActive',fld:'INVOICEACTIVE',pic:''}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'A94InvoiceActive',fld:'INVOICEACTIVE',pic:''}]}");
         setEventMetadata("VALID_INVOICEID","{handler:'Valid_Invoiceid',iparms:[{av:'A20InvoiceId',fld:'INVOICEID',pic:'ZZZZZ9'},{av:'A80InvoiceTotalReceivable',fld:'INVOICETOTALRECEIVABLE',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'A68InvoiceProductQuantity',fld:'INVOICEPRODUCTQUANTITY',pic:'ZZZ9'},{av:'A97InvoiceLastDetailId',fld:'INVOICELASTDETAILID',pic:'ZZZZZ9'},{av:'A131InvoiceLastPaymentMethodId',fld:'INVOICELASTPAYMENTMETHODID',pic:'ZZZZZ9'},{av:'A94InvoiceActive',fld:'INVOICEACTIVE',pic:''}]");
         setEventMetadata("VALID_INVOICEID",",oparms:[{av:'A80InvoiceTotalReceivable',fld:'INVOICETOTALRECEIVABLE',pic:'ZZZZZZZZZZZZZZ9.99'},{av:'A68InvoiceProductQuantity',fld:'INVOICEPRODUCTQUANTITY',pic:'ZZZ9'},{av:'A97InvoiceLastDetailId',fld:'INVOICELASTDETAILID',pic:'ZZZZZ9'},{av:'A131InvoiceLastPaymentMethodId',fld:'INVOICELASTPAYMENTMETHODID',pic:'ZZZZZ9'},{av:'A94InvoiceActive',fld:'INVOICEACTIVE',pic:''}]}");
         setEventMetadata("VALID_INVOICECREATEDDATE","{handler:'Valid_Invoicecreateddate',iparms:[{av:'A94InvoiceActive',fld:'INVOICEACTIVE',pic:''}]");
         setEventMetadata("VALID_INVOICECREATEDDATE",",oparms:[{av:'A94InvoiceActive',fld:'INVOICEACTIVE',pic:''}]}");
         setEventMetadata("VALID_USERID","{handler:'Valid_Userid',iparms:[{av:'A99UserId',fld:'USERID',pic:'ZZZZZ9'},{av:'A100UserName',fld:'USERNAME',pic:''},{av:'A94InvoiceActive',fld:'INVOICEACTIVE',pic:''}]");
         setEventMetadata("VALID_USERID",",oparms:[{av:'A100UserName',fld:'USERNAME',pic:''},{av:'A94InvoiceActive',fld:'INVOICEACTIVE',pic:''}]}");
         setEventMetadata("VALID_INVOICEMODIFIEDDATE","{handler:'Valid_Invoicemodifieddate',iparms:[{av:'A94InvoiceActive',fld:'INVOICEACTIVE',pic:''}]");
         setEventMetadata("VALID_INVOICEMODIFIEDDATE",",oparms:[{av:'A94InvoiceActive',fld:'INVOICEACTIVE',pic:''}]}");
         setEventMetadata("VALID_INVOICELASTDETAILID","{handler:'Valid_Invoicelastdetailid',iparms:[{av:'A94InvoiceActive',fld:'INVOICEACTIVE',pic:''}]");
         setEventMetadata("VALID_INVOICELASTDETAILID",",oparms:[{av:'A94InvoiceActive',fld:'INVOICEACTIVE',pic:''}]}");
         setEventMetadata("VALID_INVOICELASTPAYMENTMETHODID","{handler:'Valid_Invoicelastpaymentmethodid',iparms:[{av:'A94InvoiceActive',fld:'INVOICEACTIVE',pic:''}]");
         setEventMetadata("VALID_INVOICELASTPAYMENTMETHODID",",oparms:[{av:'A94InvoiceActive',fld:'INVOICEACTIVE',pic:''}]}");
         setEventMetadata("VALID_INVOICEDETAILID","{handler:'Valid_Invoicedetailid',iparms:[{av:'A94InvoiceActive',fld:'INVOICEACTIVE',pic:''}]");
         setEventMetadata("VALID_INVOICEDETAILID",",oparms:[{av:'A94InvoiceActive',fld:'INVOICEACTIVE',pic:''}]}");
         setEventMetadata("VALID_PRODUCTID","{handler:'Valid_Productid',iparms:[{av:'A15ProductId',fld:'PRODUCTID',pic:'ZZZZZ9'},{av:'A16ProductName',fld:'PRODUCTNAME',pic:''},{av:'A17ProductStock',fld:'PRODUCTSTOCK',pic:'ZZZZZ9'},{av:'A94InvoiceActive',fld:'INVOICEACTIVE',pic:''}]");
         setEventMetadata("VALID_PRODUCTID",",oparms:[{av:'A16ProductName',fld:'PRODUCTNAME',pic:''},{av:'A17ProductStock',fld:'PRODUCTSTOCK',pic:'ZZZZZ9'},{av:'A94InvoiceActive',fld:'INVOICEACTIVE',pic:''}]}");
         setEventMetadata("VALID_PRODUCTSTOCK","{handler:'Valid_Productstock',iparms:[{av:'A94InvoiceActive',fld:'INVOICEACTIVE',pic:''}]");
         setEventMetadata("VALID_PRODUCTSTOCK",",oparms:[{av:'A94InvoiceActive',fld:'INVOICEACTIVE',pic:''}]}");
         setEventMetadata("VALID_INVOICEDETAILQUANTITY","{handler:'Valid_Invoicedetailquantity',iparms:[{av:'A94InvoiceActive',fld:'INVOICEACTIVE',pic:''}]");
         setEventMetadata("VALID_INVOICEDETAILQUANTITY",",oparms:[{av:'A94InvoiceActive',fld:'INVOICEACTIVE',pic:''}]}");
         setEventMetadata("VALID_INVOICEDETAILHISTORICPRICE","{handler:'Valid_Invoicedetailhistoricprice',iparms:[{av:'A94InvoiceActive',fld:'INVOICEACTIVE',pic:''}]");
         setEventMetadata("VALID_INVOICEDETAILHISTORICPRICE",",oparms:[{av:'A94InvoiceActive',fld:'INVOICEACTIVE',pic:''}]}");
         setEventMetadata("NULL","{handler:'Valid_Invoicedetailiswholesale',iparms:[{av:'A94InvoiceActive',fld:'INVOICEACTIVE',pic:''}]");
         setEventMetadata("NULL",",oparms:[{av:'A94InvoiceActive',fld:'INVOICEACTIVE',pic:''}]}");
         setEventMetadata("VALID_INVOICEPAYMENTMETHODID","{handler:'Valid_Invoicepaymentmethodid',iparms:[{av:'A94InvoiceActive',fld:'INVOICEACTIVE',pic:''}]");
         setEventMetadata("VALID_INVOICEPAYMENTMETHODID",",oparms:[{av:'A94InvoiceActive',fld:'INVOICEACTIVE',pic:''}]}");
         setEventMetadata("VALID_PAYMENTMETHODID","{handler:'Valid_Paymentmethodid',iparms:[{av:'A115PaymentMethodId',fld:'PAYMENTMETHODID',pic:'ZZZZZ9'},{av:'A116PaymentMethodDescription',fld:'PAYMENTMETHODDESCRIPTION',pic:''},{av:'A129PaymentMethodDiscount',fld:'PAYMENTMETHODDISCOUNT',pic:'ZZZZ9.99'},{av:'A130PaymentMethodRecarge',fld:'PAYMENTMETHODRECARGE',pic:'ZZZZ9.99'},{av:'A94InvoiceActive',fld:'INVOICEACTIVE',pic:''}]");
         setEventMetadata("VALID_PAYMENTMETHODID",",oparms:[{av:'A116PaymentMethodDescription',fld:'PAYMENTMETHODDESCRIPTION',pic:''},{av:'A129PaymentMethodDiscount',fld:'PAYMENTMETHODDISCOUNT',pic:'ZZZZ9.99'},{av:'A130PaymentMethodRecarge',fld:'PAYMENTMETHODRECARGE',pic:'ZZZZ9.99'},{av:'A94InvoiceActive',fld:'INVOICEACTIVE',pic:''}]}");
         setEventMetadata("VALID_INVOICEPAYMENTMETHODIMPORT","{handler:'Valid_Invoicepaymentmethodimport',iparms:[{av:'A94InvoiceActive',fld:'INVOICEACTIVE',pic:''}]");
         setEventMetadata("VALID_INVOICEPAYMENTMETHODIMPORT",",oparms:[{av:'A94InvoiceActive',fld:'INVOICEACTIVE',pic:''}]}");
         setEventMetadata("VALID_INVOICEPAYMENTMETHODRECHARGEIM","{handler:'Valid_Invoicepaymentmethodrechargeim',iparms:[{av:'A94InvoiceActive',fld:'INVOICEACTIVE',pic:''}]");
         setEventMetadata("VALID_INVOICEPAYMENTMETHODRECHARGEIM",",oparms:[{av:'A94InvoiceActive',fld:'INVOICEACTIVE',pic:''}]}");
         setEventMetadata("VALID_INVOICEPAYMENTMETHODDISCOUNTIM","{handler:'Valid_Invoicepaymentmethoddiscountim',iparms:[{av:'A94InvoiceActive',fld:'INVOICEACTIVE',pic:''}]");
         setEventMetadata("VALID_INVOICEPAYMENTMETHODDISCOUNTIM",",oparms:[{av:'A94InvoiceActive',fld:'INVOICEACTIVE',pic:''}]}");
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
         pr_default.close(42);
         pr_default.close(6);
         pr_default.close(34);
         pr_default.close(10);
         pr_default.close(26);
         pr_default.close(23);
         pr_default.close(24);
         pr_default.close(25);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z38InvoiceCreatedDate = DateTime.MinValue;
         Z39InvoiceModifiedDate = DateTime.MinValue;
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
         A38InvoiceCreatedDate = DateTime.MinValue;
         imgprompt_99_gximage = "";
         sImgUrl = "";
         A100UserName = "";
         A39InvoiceModifiedDate = DateTime.MinValue;
         lblTitledetail_Jsonclick = "";
         lblTitlepaymentmethod_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridinvoice_detailContainer = new GXWebGrid( context);
         sMode13 = "";
         sStyleString = "";
         Gridinvoice_paymentmethodContainer = new GXWebGrid( context);
         sMode21 = "";
         Gx_date = DateTime.MinValue;
         AV21Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode6 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A116PaymentMethodDescription = "";
         T00068_A80InvoiceTotalReceivable = new decimal[1] ;
         T00068_n80InvoiceTotalReceivable = new bool[] {false} ;
         T000610_A131InvoiceLastPaymentMethodId = new int[1] ;
         T000610_n131InvoiceLastPaymentMethodId = new bool[] {false} ;
         A16ProductName = "";
         T000615_A68InvoiceProductQuantity = new short[1] ;
         T000615_A97InvoiceLastDetailId = new int[1] ;
         GXt_SdtSDTContextSession1 = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV12TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         AV17Context = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         Z100UserName = "";
         T000618_A100UserName = new string[] {""} ;
         T000621_A20InvoiceId = new int[1] ;
         T000621_A38InvoiceCreatedDate = new DateTime[] {DateTime.MinValue} ;
         T000621_A100UserName = new string[] {""} ;
         T000621_A39InvoiceModifiedDate = new DateTime[] {DateTime.MinValue} ;
         T000621_n39InvoiceModifiedDate = new bool[] {false} ;
         T000621_A94InvoiceActive = new bool[] {false} ;
         T000621_A99UserId = new int[1] ;
         T000621_A68InvoiceProductQuantity = new short[1] ;
         T000621_A97InvoiceLastDetailId = new int[1] ;
         T000621_A131InvoiceLastPaymentMethodId = new int[1] ;
         T000621_n131InvoiceLastPaymentMethodId = new bool[] {false} ;
         T000625_A80InvoiceTotalReceivable = new decimal[1] ;
         T000625_n80InvoiceTotalReceivable = new bool[] {false} ;
         T000627_A68InvoiceProductQuantity = new short[1] ;
         T000627_A97InvoiceLastDetailId = new int[1] ;
         T000629_A131InvoiceLastPaymentMethodId = new int[1] ;
         T000629_n131InvoiceLastPaymentMethodId = new bool[] {false} ;
         T000630_A100UserName = new string[] {""} ;
         T000631_A20InvoiceId = new int[1] ;
         T000617_A20InvoiceId = new int[1] ;
         T000617_A38InvoiceCreatedDate = new DateTime[] {DateTime.MinValue} ;
         T000617_A39InvoiceModifiedDate = new DateTime[] {DateTime.MinValue} ;
         T000617_n39InvoiceModifiedDate = new bool[] {false} ;
         T000617_A94InvoiceActive = new bool[] {false} ;
         T000617_A99UserId = new int[1] ;
         T000632_A20InvoiceId = new int[1] ;
         T000633_A20InvoiceId = new int[1] ;
         T000616_A20InvoiceId = new int[1] ;
         T000616_A38InvoiceCreatedDate = new DateTime[] {DateTime.MinValue} ;
         T000616_A39InvoiceModifiedDate = new DateTime[] {DateTime.MinValue} ;
         T000616_n39InvoiceModifiedDate = new bool[] {false} ;
         T000616_A94InvoiceActive = new bool[] {false} ;
         T000616_A99UserId = new int[1] ;
         T000634_A20InvoiceId = new int[1] ;
         T000640_A80InvoiceTotalReceivable = new decimal[1] ;
         T000640_n80InvoiceTotalReceivable = new bool[] {false} ;
         T000642_A68InvoiceProductQuantity = new short[1] ;
         T000642_A97InvoiceLastDetailId = new int[1] ;
         T000644_A131InvoiceLastPaymentMethodId = new int[1] ;
         T000644_n131InvoiceLastPaymentMethodId = new bool[] {false} ;
         T000645_A100UserName = new string[] {""} ;
         T000646_A20InvoiceId = new int[1] ;
         Z16ProductName = "";
         T000647_A20InvoiceId = new int[1] ;
         T000647_A25InvoiceDetailId = new int[1] ;
         T000647_A16ProductName = new string[] {""} ;
         T000647_A17ProductStock = new int[1] ;
         T000647_n17ProductStock = new bool[] {false} ;
         T000647_A26InvoiceDetailQuantity = new int[1] ;
         T000647_A65InvoiceDetailHistoricPrice = new decimal[1] ;
         T000647_A98InvoiceDetailIsWholesale = new bool[] {false} ;
         T000647_A15ProductId = new int[1] ;
         T000613_A16ProductName = new string[] {""} ;
         T000613_A17ProductStock = new int[1] ;
         T000613_n17ProductStock = new bool[] {false} ;
         T000648_A16ProductName = new string[] {""} ;
         T000648_A17ProductStock = new int[1] ;
         T000648_n17ProductStock = new bool[] {false} ;
         T000649_A20InvoiceId = new int[1] ;
         T000649_A25InvoiceDetailId = new int[1] ;
         T000612_A20InvoiceId = new int[1] ;
         T000612_A25InvoiceDetailId = new int[1] ;
         T000612_A26InvoiceDetailQuantity = new int[1] ;
         T000612_A65InvoiceDetailHistoricPrice = new decimal[1] ;
         T000612_A98InvoiceDetailIsWholesale = new bool[] {false} ;
         T000612_A15ProductId = new int[1] ;
         T000611_A20InvoiceId = new int[1] ;
         T000611_A25InvoiceDetailId = new int[1] ;
         T000611_A26InvoiceDetailQuantity = new int[1] ;
         T000611_A65InvoiceDetailHistoricPrice = new decimal[1] ;
         T000611_A98InvoiceDetailIsWholesale = new bool[] {false} ;
         T000611_A15ProductId = new int[1] ;
         T000653_A16ProductName = new string[] {""} ;
         T000653_A17ProductStock = new int[1] ;
         T000653_n17ProductStock = new bool[] {false} ;
         T000654_A20InvoiceId = new int[1] ;
         T000654_A25InvoiceDetailId = new int[1] ;
         Z116PaymentMethodDescription = "";
         T000655_A20InvoiceId = new int[1] ;
         T000655_A118InvoicePaymentMethodId = new int[1] ;
         T000655_A116PaymentMethodDescription = new string[] {""} ;
         T000655_A129PaymentMethodDiscount = new decimal[1] ;
         T000655_A130PaymentMethodRecarge = new decimal[1] ;
         T000655_A120InvoicePaymentMethodImport = new decimal[1] ;
         T000655_n120InvoicePaymentMethodImport = new bool[] {false} ;
         T000655_A132InvoicePaymentMethodRechargeIm = new decimal[1] ;
         T000655_n132InvoicePaymentMethodRechargeIm = new bool[] {false} ;
         T000655_A133InvoicePaymentMethodDiscountIm = new decimal[1] ;
         T000655_n133InvoicePaymentMethodDiscountIm = new bool[] {false} ;
         T000655_A115PaymentMethodId = new int[1] ;
         T000655_n115PaymentMethodId = new bool[] {false} ;
         T00064_A116PaymentMethodDescription = new string[] {""} ;
         T00064_A129PaymentMethodDiscount = new decimal[1] ;
         T00064_A130PaymentMethodRecarge = new decimal[1] ;
         T000656_A116PaymentMethodDescription = new string[] {""} ;
         T000656_A129PaymentMethodDiscount = new decimal[1] ;
         T000656_A130PaymentMethodRecarge = new decimal[1] ;
         T000657_A20InvoiceId = new int[1] ;
         T000657_A118InvoicePaymentMethodId = new int[1] ;
         T00063_A20InvoiceId = new int[1] ;
         T00063_A118InvoicePaymentMethodId = new int[1] ;
         T00063_A120InvoicePaymentMethodImport = new decimal[1] ;
         T00063_n120InvoicePaymentMethodImport = new bool[] {false} ;
         T00063_A132InvoicePaymentMethodRechargeIm = new decimal[1] ;
         T00063_n132InvoicePaymentMethodRechargeIm = new bool[] {false} ;
         T00063_A133InvoicePaymentMethodDiscountIm = new decimal[1] ;
         T00063_n133InvoicePaymentMethodDiscountIm = new bool[] {false} ;
         T00063_A115PaymentMethodId = new int[1] ;
         T00063_n115PaymentMethodId = new bool[] {false} ;
         T00062_A20InvoiceId = new int[1] ;
         T00062_A118InvoicePaymentMethodId = new int[1] ;
         T00062_A120InvoicePaymentMethodImport = new decimal[1] ;
         T00062_n120InvoicePaymentMethodImport = new bool[] {false} ;
         T00062_A132InvoicePaymentMethodRechargeIm = new decimal[1] ;
         T00062_n132InvoicePaymentMethodRechargeIm = new bool[] {false} ;
         T00062_A133InvoicePaymentMethodDiscountIm = new decimal[1] ;
         T00062_n133InvoicePaymentMethodDiscountIm = new bool[] {false} ;
         T00062_A115PaymentMethodId = new int[1] ;
         T00062_n115PaymentMethodId = new bool[] {false} ;
         T000661_A116PaymentMethodDescription = new string[] {""} ;
         T000661_A129PaymentMethodDiscount = new decimal[1] ;
         T000661_A130PaymentMethodRecarge = new decimal[1] ;
         T000662_A20InvoiceId = new int[1] ;
         T000662_A118InvoicePaymentMethodId = new int[1] ;
         Gridinvoice_detailRow = new GXWebRow();
         subGridinvoice_detail_Linesclass = "";
         ROClassString = "";
         imgprompt_15_gximage = "";
         Gridinvoice_paymentmethodRow = new GXWebRow();
         subGridinvoice_paymentmethod_Linesclass = "";
         imgprompt_115_gximage = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Gridinvoice_detailColumn = new GXWebColumn();
         Gridinvoice_paymentmethodColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.invoice__default(),
            new Object[][] {
                new Object[] {
               T00062_A20InvoiceId, T00062_A118InvoicePaymentMethodId, T00062_A120InvoicePaymentMethodImport, T00062_n120InvoicePaymentMethodImport, T00062_A132InvoicePaymentMethodRechargeIm, T00062_n132InvoicePaymentMethodRechargeIm, T00062_A133InvoicePaymentMethodDiscountIm, T00062_n133InvoicePaymentMethodDiscountIm, T00062_A115PaymentMethodId, T00062_n115PaymentMethodId
               }
               , new Object[] {
               T00063_A20InvoiceId, T00063_A118InvoicePaymentMethodId, T00063_A120InvoicePaymentMethodImport, T00063_n120InvoicePaymentMethodImport, T00063_A132InvoicePaymentMethodRechargeIm, T00063_n132InvoicePaymentMethodRechargeIm, T00063_A133InvoicePaymentMethodDiscountIm, T00063_n133InvoicePaymentMethodDiscountIm, T00063_A115PaymentMethodId, T00063_n115PaymentMethodId
               }
               , new Object[] {
               T00064_A116PaymentMethodDescription, T00064_A129PaymentMethodDiscount, T00064_A130PaymentMethodRecarge
               }
               , new Object[] {
               T00068_A80InvoiceTotalReceivable, T00068_n80InvoiceTotalReceivable
               }
               , new Object[] {
               T000610_A131InvoiceLastPaymentMethodId, T000610_n131InvoiceLastPaymentMethodId
               }
               , new Object[] {
               T000611_A20InvoiceId, T000611_A25InvoiceDetailId, T000611_A26InvoiceDetailQuantity, T000611_A65InvoiceDetailHistoricPrice, T000611_A98InvoiceDetailIsWholesale, T000611_A15ProductId
               }
               , new Object[] {
               T000612_A20InvoiceId, T000612_A25InvoiceDetailId, T000612_A26InvoiceDetailQuantity, T000612_A65InvoiceDetailHistoricPrice, T000612_A98InvoiceDetailIsWholesale, T000612_A15ProductId
               }
               , new Object[] {
               T000613_A16ProductName, T000613_A17ProductStock, T000613_n17ProductStock
               }
               , new Object[] {
               T000615_A68InvoiceProductQuantity, T000615_A97InvoiceLastDetailId
               }
               , new Object[] {
               T000616_A20InvoiceId, T000616_A38InvoiceCreatedDate, T000616_A39InvoiceModifiedDate, T000616_n39InvoiceModifiedDate, T000616_A94InvoiceActive, T000616_A99UserId
               }
               , new Object[] {
               T000617_A20InvoiceId, T000617_A38InvoiceCreatedDate, T000617_A39InvoiceModifiedDate, T000617_n39InvoiceModifiedDate, T000617_A94InvoiceActive, T000617_A99UserId
               }
               , new Object[] {
               T000618_A100UserName
               }
               , new Object[] {
               T000621_A20InvoiceId, T000621_A38InvoiceCreatedDate, T000621_A100UserName, T000621_A39InvoiceModifiedDate, T000621_n39InvoiceModifiedDate, T000621_A94InvoiceActive, T000621_A99UserId, T000621_A68InvoiceProductQuantity, T000621_A97InvoiceLastDetailId, T000621_A131InvoiceLastPaymentMethodId,
               T000621_n131InvoiceLastPaymentMethodId
               }
               , new Object[] {
               T000625_A80InvoiceTotalReceivable, T000625_n80InvoiceTotalReceivable
               }
               , new Object[] {
               T000627_A68InvoiceProductQuantity, T000627_A97InvoiceLastDetailId
               }
               , new Object[] {
               T000629_A131InvoiceLastPaymentMethodId, T000629_n131InvoiceLastPaymentMethodId
               }
               , new Object[] {
               T000630_A100UserName
               }
               , new Object[] {
               T000631_A20InvoiceId
               }
               , new Object[] {
               T000632_A20InvoiceId
               }
               , new Object[] {
               T000633_A20InvoiceId
               }
               , new Object[] {
               T000634_A20InvoiceId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000640_A80InvoiceTotalReceivable, T000640_n80InvoiceTotalReceivable
               }
               , new Object[] {
               T000642_A68InvoiceProductQuantity, T000642_A97InvoiceLastDetailId
               }
               , new Object[] {
               T000644_A131InvoiceLastPaymentMethodId, T000644_n131InvoiceLastPaymentMethodId
               }
               , new Object[] {
               T000645_A100UserName
               }
               , new Object[] {
               T000646_A20InvoiceId
               }
               , new Object[] {
               T000647_A20InvoiceId, T000647_A25InvoiceDetailId, T000647_A16ProductName, T000647_A17ProductStock, T000647_n17ProductStock, T000647_A26InvoiceDetailQuantity, T000647_A65InvoiceDetailHistoricPrice, T000647_A98InvoiceDetailIsWholesale, T000647_A15ProductId
               }
               , new Object[] {
               T000648_A16ProductName, T000648_A17ProductStock, T000648_n17ProductStock
               }
               , new Object[] {
               T000649_A20InvoiceId, T000649_A25InvoiceDetailId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000653_A16ProductName, T000653_A17ProductStock, T000653_n17ProductStock
               }
               , new Object[] {
               T000654_A20InvoiceId, T000654_A25InvoiceDetailId
               }
               , new Object[] {
               T000655_A20InvoiceId, T000655_A118InvoicePaymentMethodId, T000655_A116PaymentMethodDescription, T000655_A129PaymentMethodDiscount, T000655_A130PaymentMethodRecarge, T000655_A120InvoicePaymentMethodImport, T000655_n120InvoicePaymentMethodImport, T000655_A132InvoicePaymentMethodRechargeIm, T000655_n132InvoicePaymentMethodRechargeIm, T000655_A133InvoicePaymentMethodDiscountIm,
               T000655_n133InvoicePaymentMethodDiscountIm, T000655_A115PaymentMethodId, T000655_n115PaymentMethodId
               }
               , new Object[] {
               T000656_A116PaymentMethodDescription, T000656_A129PaymentMethodDiscount, T000656_A130PaymentMethodRecarge
               }
               , new Object[] {
               T000657_A20InvoiceId, T000657_A118InvoicePaymentMethodId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000661_A116PaymentMethodDescription, T000661_A129PaymentMethodDiscount, T000661_A130PaymentMethodRecarge
               }
               , new Object[] {
               T000662_A20InvoiceId, T000662_A118InvoicePaymentMethodId
               }
            }
         );
         AV21Pgmname = "Invoice";
         Gx_date = DateTimeUtil.Today( context);
      }

      private short nIsMod_13 ;
      private short nIsMod_21 ;
      private short O68InvoiceProductQuantity ;
      private short nRcdDeleted_13 ;
      private short nRcdExists_13 ;
      private short nRcdDeleted_21 ;
      private short nRcdExists_21 ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short initialized ;
      private short A68InvoiceProductQuantity ;
      private short nBlankRcdCount13 ;
      private short RcdFound13 ;
      private short B68InvoiceProductQuantity ;
      private short nBlankRcdUsr13 ;
      private short nBlankRcdCount21 ;
      private short RcdFound21 ;
      private short nBlankRcdUsr21 ;
      private short RcdFound6 ;
      private short s68InvoiceProductQuantity ;
      private short GX_JID ;
      private short Z68InvoiceProductQuantity ;
      private short nIsDirty_6 ;
      private short nIsDirty_13 ;
      private short nIsDirty_21 ;
      private short subGridinvoice_detail_Backcolorstyle ;
      private short subGridinvoice_detail_Backstyle ;
      private short subGridinvoice_paymentmethod_Backcolorstyle ;
      private short subGridinvoice_paymentmethod_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridinvoice_detail_Allowselection ;
      private short subGridinvoice_detail_Allowhovering ;
      private short subGridinvoice_detail_Allowcollapsing ;
      private short subGridinvoice_detail_Collapsed ;
      private short subGridinvoice_paymentmethod_Allowselection ;
      private short subGridinvoice_paymentmethod_Allowhovering ;
      private short subGridinvoice_paymentmethod_Allowcollapsing ;
      private short subGridinvoice_paymentmethod_Collapsed ;
      private int wcpOAV13InvoiceId ;
      private int Z20InvoiceId ;
      private int Z99UserId ;
      private int O131InvoiceLastPaymentMethodId ;
      private int O97InvoiceLastDetailId ;
      private int nRC_GXsfl_88 ;
      private int nGXsfl_88_idx=1 ;
      private int nRC_GXsfl_104 ;
      private int nGXsfl_104_idx=1 ;
      private int N99UserId ;
      private int Z25InvoiceDetailId ;
      private int Z26InvoiceDetailQuantity ;
      private int Z15ProductId ;
      private int Z118InvoicePaymentMethodId ;
      private int Z115PaymentMethodId ;
      private int A20InvoiceId ;
      private int A99UserId ;
      private int A15ProductId ;
      private int A115PaymentMethodId ;
      private int AV13InvoiceId ;
      private int trnEnded ;
      private int A97InvoiceLastDetailId ;
      private int A131InvoiceLastPaymentMethodId ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtInvoiceId_Enabled ;
      private int edtInvoiceCreatedDate_Enabled ;
      private int edtUserId_Enabled ;
      private int imgprompt_99_Visible ;
      private int edtUserName_Enabled ;
      private int edtInvoiceModifiedDate_Enabled ;
      private int edtInvoiceTotalReceivable_Enabled ;
      private int edtInvoiceProductQuantity_Enabled ;
      private int edtInvoiceLastDetailId_Enabled ;
      private int edtInvoiceLastPaymentMethodId_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int B131InvoiceLastPaymentMethodId ;
      private int B97InvoiceLastDetailId ;
      private int edtInvoiceDetailId_Enabled ;
      private int edtProductId_Enabled ;
      private int edtProductName_Enabled ;
      private int edtProductStock_Enabled ;
      private int edtInvoiceDetailQuantity_Enabled ;
      private int edtInvoiceDetailHistoricPrice_Enabled ;
      private int fRowAdded ;
      private int edtInvoicePaymentMethodId_Enabled ;
      private int edtPaymentMethodId_Enabled ;
      private int edtPaymentMethodDescription_Enabled ;
      private int edtPaymentMethodDiscount_Enabled ;
      private int edtPaymentMethodRecarge_Enabled ;
      private int edtInvoicePaymentMethodImport_Enabled ;
      private int edtInvoicePaymentMethodRechargeIm_Enabled ;
      private int edtInvoicePaymentMethodDiscountIm_Enabled ;
      private int AV14Insert_UserId ;
      private int s131InvoiceLastPaymentMethodId ;
      private int A118InvoicePaymentMethodId ;
      private int s97InvoiceLastDetailId ;
      private int A25InvoiceDetailId ;
      private int A17ProductStock ;
      private int A26InvoiceDetailQuantity ;
      private int AV22GXV1 ;
      private int Z97InvoiceLastDetailId ;
      private int Z131InvoiceLastPaymentMethodId ;
      private int Z17ProductStock ;
      private int subGridinvoice_detail_Backcolor ;
      private int subGridinvoice_detail_Allbackcolor ;
      private int imgprompt_15_Visible ;
      private int subGridinvoice_paymentmethod_Backcolor ;
      private int subGridinvoice_paymentmethod_Allbackcolor ;
      private int imgprompt_115_Visible ;
      private int defedtInvoicePaymentMethodId_Enabled ;
      private int defedtInvoiceDetailId_Enabled ;
      private int i97InvoiceLastDetailId ;
      private int i131InvoiceLastPaymentMethodId ;
      private int idxLst ;
      private int subGridinvoice_detail_Selectedindex ;
      private int subGridinvoice_detail_Selectioncolor ;
      private int subGridinvoice_detail_Hoveringcolor ;
      private int subGridinvoice_paymentmethod_Selectedindex ;
      private int subGridinvoice_paymentmethod_Selectioncolor ;
      private int subGridinvoice_paymentmethod_Hoveringcolor ;
      private long GRIDINVOICE_DETAIL_nFirstRecordOnPage ;
      private long GRIDINVOICE_PAYMENTMETHOD_nFirstRecordOnPage ;
      private decimal Z65InvoiceDetailHistoricPrice ;
      private decimal Z120InvoicePaymentMethodImport ;
      private decimal Z132InvoicePaymentMethodRechargeIm ;
      private decimal Z133InvoicePaymentMethodDiscountIm ;
      private decimal A80InvoiceTotalReceivable ;
      private decimal A129PaymentMethodDiscount ;
      private decimal A130PaymentMethodRecarge ;
      private decimal A120InvoicePaymentMethodImport ;
      private decimal A132InvoicePaymentMethodRechargeIm ;
      private decimal A133InvoicePaymentMethodDiscountIm ;
      private decimal A65InvoiceDetailHistoricPrice ;
      private decimal Z129PaymentMethodDiscount ;
      private decimal Z130PaymentMethodRecarge ;
      private decimal Z80InvoiceTotalReceivable ;
      private string sPrefix ;
      private string sGXsfl_88_idx="0001" ;
      private string sGXsfl_104_idx="0001" ;
      private string wcpOGx_mode ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtInvoiceCreatedDate_Internalname ;
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
      private string edtInvoiceId_Internalname ;
      private string edtInvoiceId_Jsonclick ;
      private string edtInvoiceCreatedDate_Jsonclick ;
      private string edtUserId_Internalname ;
      private string edtUserId_Jsonclick ;
      private string imgprompt_99_gximage ;
      private string sImgUrl ;
      private string imgprompt_99_Internalname ;
      private string imgprompt_99_Link ;
      private string edtUserName_Internalname ;
      private string edtUserName_Jsonclick ;
      private string edtInvoiceModifiedDate_Internalname ;
      private string edtInvoiceModifiedDate_Jsonclick ;
      private string chkInvoiceActive_Internalname ;
      private string edtInvoiceTotalReceivable_Internalname ;
      private string edtInvoiceTotalReceivable_Jsonclick ;
      private string edtInvoiceProductQuantity_Internalname ;
      private string edtInvoiceProductQuantity_Jsonclick ;
      private string edtInvoiceLastDetailId_Internalname ;
      private string edtInvoiceLastDetailId_Jsonclick ;
      private string edtInvoiceLastPaymentMethodId_Internalname ;
      private string edtInvoiceLastPaymentMethodId_Jsonclick ;
      private string divDetailtable_Internalname ;
      private string lblTitledetail_Internalname ;
      private string lblTitledetail_Jsonclick ;
      private string divPaymentmethodtable_Internalname ;
      private string lblTitlepaymentmethod_Internalname ;
      private string lblTitlepaymentmethod_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Caption ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_enter_Tooltiptext ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string sMode13 ;
      private string edtInvoiceDetailId_Internalname ;
      private string edtProductId_Internalname ;
      private string edtProductName_Internalname ;
      private string edtProductStock_Internalname ;
      private string edtInvoiceDetailQuantity_Internalname ;
      private string edtInvoiceDetailHistoricPrice_Internalname ;
      private string chkInvoiceDetailIsWholesale_Internalname ;
      private string sStyleString ;
      private string subGridinvoice_detail_Internalname ;
      private string sMode21 ;
      private string edtInvoicePaymentMethodId_Internalname ;
      private string edtPaymentMethodId_Internalname ;
      private string edtPaymentMethodDescription_Internalname ;
      private string edtPaymentMethodDiscount_Internalname ;
      private string edtPaymentMethodRecarge_Internalname ;
      private string edtInvoicePaymentMethodImport_Internalname ;
      private string edtInvoicePaymentMethodRechargeIm_Internalname ;
      private string edtInvoicePaymentMethodDiscountIm_Internalname ;
      private string subGridinvoice_paymentmethod_Internalname ;
      private string AV21Pgmname ;
      private string hsh ;
      private string sMode6 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string imgprompt_15_Internalname ;
      private string sGXsfl_88_fel_idx="0001" ;
      private string subGridinvoice_detail_Class ;
      private string subGridinvoice_detail_Linesclass ;
      private string imgprompt_15_Link ;
      private string ROClassString ;
      private string edtInvoiceDetailId_Jsonclick ;
      private string edtProductId_Jsonclick ;
      private string imgprompt_15_gximage ;
      private string edtProductName_Jsonclick ;
      private string edtProductStock_Jsonclick ;
      private string edtInvoiceDetailQuantity_Jsonclick ;
      private string edtInvoiceDetailHistoricPrice_Jsonclick ;
      private string imgprompt_115_Internalname ;
      private string sGXsfl_104_fel_idx="0001" ;
      private string subGridinvoice_paymentmethod_Class ;
      private string subGridinvoice_paymentmethod_Linesclass ;
      private string imgprompt_115_Link ;
      private string edtInvoicePaymentMethodId_Jsonclick ;
      private string edtPaymentMethodId_Jsonclick ;
      private string imgprompt_115_gximage ;
      private string edtPaymentMethodDescription_Jsonclick ;
      private string edtPaymentMethodDiscount_Jsonclick ;
      private string edtPaymentMethodRecarge_Jsonclick ;
      private string edtInvoicePaymentMethodImport_Jsonclick ;
      private string edtInvoicePaymentMethodRechargeIm_Jsonclick ;
      private string edtInvoicePaymentMethodDiscountIm_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridinvoice_detail_Header ;
      private string subGridinvoice_paymentmethod_Header ;
      private DateTime Z38InvoiceCreatedDate ;
      private DateTime Z39InvoiceModifiedDate ;
      private DateTime A38InvoiceCreatedDate ;
      private DateTime A39InvoiceModifiedDate ;
      private DateTime Gx_date ;
      private bool Z94InvoiceActive ;
      private bool Z98InvoiceDetailIsWholesale ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n115PaymentMethodId ;
      private bool wbErr ;
      private bool n131InvoiceLastPaymentMethodId ;
      private bool A94InvoiceActive ;
      private bool bGXsfl_88_Refreshing=false ;
      private bool bGXsfl_104_Refreshing=false ;
      private bool n39InvoiceModifiedDate ;
      private bool n80InvoiceTotalReceivable ;
      private bool A98InvoiceDetailIsWholesale ;
      private bool returnInSub ;
      private bool AV18AllOk ;
      private bool n17ProductStock ;
      private bool n120InvoicePaymentMethodImport ;
      private bool n132InvoicePaymentMethodRechargeIm ;
      private bool n133InvoicePaymentMethodDiscountIm ;
      private string A100UserName ;
      private string A116PaymentMethodDescription ;
      private string A16ProductName ;
      private string Z100UserName ;
      private string Z16ProductName ;
      private string Z116PaymentMethodDescription ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridinvoice_detailContainer ;
      private GXWebGrid Gridinvoice_paymentmethodContainer ;
      private GXWebRow Gridinvoice_detailRow ;
      private GXWebRow Gridinvoice_paymentmethodRow ;
      private GXWebColumn Gridinvoice_detailColumn ;
      private GXWebColumn Gridinvoice_paymentmethodColumn ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkInvoiceActive ;
      private GXCheckbox chkInvoiceDetailIsWholesale ;
      private IDataStoreProvider pr_default ;
      private decimal[] T00068_A80InvoiceTotalReceivable ;
      private bool[] T00068_n80InvoiceTotalReceivable ;
      private int[] T000610_A131InvoiceLastPaymentMethodId ;
      private bool[] T000610_n131InvoiceLastPaymentMethodId ;
      private short[] T000615_A68InvoiceProductQuantity ;
      private int[] T000615_A97InvoiceLastDetailId ;
      private string[] T000618_A100UserName ;
      private int[] T000621_A20InvoiceId ;
      private DateTime[] T000621_A38InvoiceCreatedDate ;
      private string[] T000621_A100UserName ;
      private DateTime[] T000621_A39InvoiceModifiedDate ;
      private bool[] T000621_n39InvoiceModifiedDate ;
      private bool[] T000621_A94InvoiceActive ;
      private int[] T000621_A99UserId ;
      private short[] T000621_A68InvoiceProductQuantity ;
      private int[] T000621_A97InvoiceLastDetailId ;
      private int[] T000621_A131InvoiceLastPaymentMethodId ;
      private bool[] T000621_n131InvoiceLastPaymentMethodId ;
      private decimal[] T000625_A80InvoiceTotalReceivable ;
      private bool[] T000625_n80InvoiceTotalReceivable ;
      private short[] T000627_A68InvoiceProductQuantity ;
      private int[] T000627_A97InvoiceLastDetailId ;
      private int[] T000629_A131InvoiceLastPaymentMethodId ;
      private bool[] T000629_n131InvoiceLastPaymentMethodId ;
      private string[] T000630_A100UserName ;
      private int[] T000631_A20InvoiceId ;
      private int[] T000617_A20InvoiceId ;
      private DateTime[] T000617_A38InvoiceCreatedDate ;
      private DateTime[] T000617_A39InvoiceModifiedDate ;
      private bool[] T000617_n39InvoiceModifiedDate ;
      private bool[] T000617_A94InvoiceActive ;
      private int[] T000617_A99UserId ;
      private int[] T000632_A20InvoiceId ;
      private int[] T000633_A20InvoiceId ;
      private int[] T000616_A20InvoiceId ;
      private DateTime[] T000616_A38InvoiceCreatedDate ;
      private DateTime[] T000616_A39InvoiceModifiedDate ;
      private bool[] T000616_n39InvoiceModifiedDate ;
      private bool[] T000616_A94InvoiceActive ;
      private int[] T000616_A99UserId ;
      private int[] T000634_A20InvoiceId ;
      private decimal[] T000640_A80InvoiceTotalReceivable ;
      private bool[] T000640_n80InvoiceTotalReceivable ;
      private short[] T000642_A68InvoiceProductQuantity ;
      private int[] T000642_A97InvoiceLastDetailId ;
      private int[] T000644_A131InvoiceLastPaymentMethodId ;
      private bool[] T000644_n131InvoiceLastPaymentMethodId ;
      private string[] T000645_A100UserName ;
      private int[] T000646_A20InvoiceId ;
      private int[] T000647_A20InvoiceId ;
      private int[] T000647_A25InvoiceDetailId ;
      private string[] T000647_A16ProductName ;
      private int[] T000647_A17ProductStock ;
      private bool[] T000647_n17ProductStock ;
      private int[] T000647_A26InvoiceDetailQuantity ;
      private decimal[] T000647_A65InvoiceDetailHistoricPrice ;
      private bool[] T000647_A98InvoiceDetailIsWholesale ;
      private int[] T000647_A15ProductId ;
      private string[] T000613_A16ProductName ;
      private int[] T000613_A17ProductStock ;
      private bool[] T000613_n17ProductStock ;
      private string[] T000648_A16ProductName ;
      private int[] T000648_A17ProductStock ;
      private bool[] T000648_n17ProductStock ;
      private int[] T000649_A20InvoiceId ;
      private int[] T000649_A25InvoiceDetailId ;
      private int[] T000612_A20InvoiceId ;
      private int[] T000612_A25InvoiceDetailId ;
      private int[] T000612_A26InvoiceDetailQuantity ;
      private decimal[] T000612_A65InvoiceDetailHistoricPrice ;
      private bool[] T000612_A98InvoiceDetailIsWholesale ;
      private int[] T000612_A15ProductId ;
      private int[] T000611_A20InvoiceId ;
      private int[] T000611_A25InvoiceDetailId ;
      private int[] T000611_A26InvoiceDetailQuantity ;
      private decimal[] T000611_A65InvoiceDetailHistoricPrice ;
      private bool[] T000611_A98InvoiceDetailIsWholesale ;
      private int[] T000611_A15ProductId ;
      private string[] T000653_A16ProductName ;
      private int[] T000653_A17ProductStock ;
      private bool[] T000653_n17ProductStock ;
      private int[] T000654_A20InvoiceId ;
      private int[] T000654_A25InvoiceDetailId ;
      private int[] T000655_A20InvoiceId ;
      private int[] T000655_A118InvoicePaymentMethodId ;
      private string[] T000655_A116PaymentMethodDescription ;
      private decimal[] T000655_A129PaymentMethodDiscount ;
      private decimal[] T000655_A130PaymentMethodRecarge ;
      private decimal[] T000655_A120InvoicePaymentMethodImport ;
      private bool[] T000655_n120InvoicePaymentMethodImport ;
      private decimal[] T000655_A132InvoicePaymentMethodRechargeIm ;
      private bool[] T000655_n132InvoicePaymentMethodRechargeIm ;
      private decimal[] T000655_A133InvoicePaymentMethodDiscountIm ;
      private bool[] T000655_n133InvoicePaymentMethodDiscountIm ;
      private int[] T000655_A115PaymentMethodId ;
      private bool[] T000655_n115PaymentMethodId ;
      private string[] T00064_A116PaymentMethodDescription ;
      private decimal[] T00064_A129PaymentMethodDiscount ;
      private decimal[] T00064_A130PaymentMethodRecarge ;
      private string[] T000656_A116PaymentMethodDescription ;
      private decimal[] T000656_A129PaymentMethodDiscount ;
      private decimal[] T000656_A130PaymentMethodRecarge ;
      private int[] T000657_A20InvoiceId ;
      private int[] T000657_A118InvoicePaymentMethodId ;
      private int[] T00063_A20InvoiceId ;
      private int[] T00063_A118InvoicePaymentMethodId ;
      private decimal[] T00063_A120InvoicePaymentMethodImport ;
      private bool[] T00063_n120InvoicePaymentMethodImport ;
      private decimal[] T00063_A132InvoicePaymentMethodRechargeIm ;
      private bool[] T00063_n132InvoicePaymentMethodRechargeIm ;
      private decimal[] T00063_A133InvoicePaymentMethodDiscountIm ;
      private bool[] T00063_n133InvoicePaymentMethodDiscountIm ;
      private int[] T00063_A115PaymentMethodId ;
      private bool[] T00063_n115PaymentMethodId ;
      private int[] T00062_A20InvoiceId ;
      private int[] T00062_A118InvoicePaymentMethodId ;
      private decimal[] T00062_A120InvoicePaymentMethodImport ;
      private bool[] T00062_n120InvoicePaymentMethodImport ;
      private decimal[] T00062_A132InvoicePaymentMethodRechargeIm ;
      private bool[] T00062_n132InvoicePaymentMethodRechargeIm ;
      private decimal[] T00062_A133InvoicePaymentMethodDiscountIm ;
      private bool[] T00062_n133InvoicePaymentMethodDiscountIm ;
      private int[] T00062_A115PaymentMethodId ;
      private bool[] T00062_n115PaymentMethodId ;
      private string[] T000661_A116PaymentMethodDescription ;
      private decimal[] T000661_A129PaymentMethodDiscount ;
      private decimal[] T000661_A130PaymentMethodRecarge ;
      private int[] T000662_A20InvoiceId ;
      private int[] T000662_A118InvoicePaymentMethodId ;
      private GXWebForm Form ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV12TrnContextAtt ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession GXt_SdtSDTContextSession1 ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession AV17Context ;
   }

   public class invoice__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new UpdateCursor(def[21])
         ,new UpdateCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new ForEachCursor(def[24])
         ,new ForEachCursor(def[25])
         ,new ForEachCursor(def[26])
         ,new ForEachCursor(def[27])
         ,new ForEachCursor(def[28])
         ,new ForEachCursor(def[29])
         ,new ForEachCursor(def[30])
         ,new UpdateCursor(def[31])
         ,new UpdateCursor(def[32])
         ,new UpdateCursor(def[33])
         ,new ForEachCursor(def[34])
         ,new ForEachCursor(def[35])
         ,new ForEachCursor(def[36])
         ,new ForEachCursor(def[37])
         ,new ForEachCursor(def[38])
         ,new UpdateCursor(def[39])
         ,new UpdateCursor(def[40])
         ,new UpdateCursor(def[41])
         ,new ForEachCursor(def[42])
         ,new ForEachCursor(def[43])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000621;
          prmT000621 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmT00068;
          prmT00068 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmT000615;
          prmT000615 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmT000610;
          prmT000610 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmT000618;
          prmT000618 = new Object[] {
          new ParDef("@UserId",GXType.Int32,6,0)
          };
          Object[] prmT000625;
          prmT000625 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmT000627;
          prmT000627 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmT000629;
          prmT000629 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmT000630;
          prmT000630 = new Object[] {
          new ParDef("@UserId",GXType.Int32,6,0)
          };
          Object[] prmT000631;
          prmT000631 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmT000617;
          prmT000617 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmT000632;
          prmT000632 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmT000633;
          prmT000633 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmT000616;
          prmT000616 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmT000634;
          prmT000634 = new Object[] {
          new ParDef("@InvoiceCreatedDate",GXType.Date,8,0) ,
          new ParDef("@InvoiceModifiedDate",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@InvoiceActive",GXType.Boolean,4,0) ,
          new ParDef("@UserId",GXType.Int32,6,0)
          };
          Object[] prmT000635;
          prmT000635 = new Object[] {
          new ParDef("@InvoiceCreatedDate",GXType.Date,8,0) ,
          new ParDef("@InvoiceModifiedDate",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@InvoiceActive",GXType.Boolean,4,0) ,
          new ParDef("@UserId",GXType.Int32,6,0) ,
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmT000636;
          prmT000636 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmT000646;
          prmT000646 = new Object[] {
          };
          Object[] prmT000647;
          prmT000647 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0) ,
          new ParDef("@InvoiceDetailId",GXType.Int32,6,0)
          };
          Object[] prmT000613;
          prmT000613 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmT000648;
          prmT000648 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmT000649;
          prmT000649 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0) ,
          new ParDef("@InvoiceDetailId",GXType.Int32,6,0)
          };
          Object[] prmT000612;
          prmT000612 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0) ,
          new ParDef("@InvoiceDetailId",GXType.Int32,6,0)
          };
          Object[] prmT000611;
          prmT000611 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0) ,
          new ParDef("@InvoiceDetailId",GXType.Int32,6,0)
          };
          Object[] prmT000650;
          prmT000650 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0) ,
          new ParDef("@InvoiceDetailId",GXType.Int32,6,0) ,
          new ParDef("@InvoiceDetailQuantity",GXType.Int32,6,0) ,
          new ParDef("@InvoiceDetailHistoricPrice",GXType.Decimal,18,2) ,
          new ParDef("@InvoiceDetailIsWholesale",GXType.Boolean,4,0) ,
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmT000651;
          prmT000651 = new Object[] {
          new ParDef("@InvoiceDetailQuantity",GXType.Int32,6,0) ,
          new ParDef("@InvoiceDetailHistoricPrice",GXType.Decimal,18,2) ,
          new ParDef("@InvoiceDetailIsWholesale",GXType.Boolean,4,0) ,
          new ParDef("@ProductId",GXType.Int32,6,0) ,
          new ParDef("@InvoiceId",GXType.Int32,6,0) ,
          new ParDef("@InvoiceDetailId",GXType.Int32,6,0)
          };
          Object[] prmT000652;
          prmT000652 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0) ,
          new ParDef("@InvoiceDetailId",GXType.Int32,6,0)
          };
          Object[] prmT000654;
          prmT000654 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmT000655;
          prmT000655 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0) ,
          new ParDef("@InvoicePaymentMethodId",GXType.Int32,6,0)
          };
          Object[] prmT00064;
          prmT00064 = new Object[] {
          new ParDef("@PaymentMethodId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000656;
          prmT000656 = new Object[] {
          new ParDef("@PaymentMethodId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000657;
          prmT000657 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0) ,
          new ParDef("@InvoicePaymentMethodId",GXType.Int32,6,0)
          };
          Object[] prmT00063;
          prmT00063 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0) ,
          new ParDef("@InvoicePaymentMethodId",GXType.Int32,6,0)
          };
          Object[] prmT00062;
          prmT00062 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0) ,
          new ParDef("@InvoicePaymentMethodId",GXType.Int32,6,0)
          };
          Object[] prmT000658;
          prmT000658 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0) ,
          new ParDef("@InvoicePaymentMethodId",GXType.Int32,6,0) ,
          new ParDef("@InvoicePaymentMethodImport",GXType.Decimal,18,2){Nullable=true} ,
          new ParDef("@InvoicePaymentMethodRechargeIm",GXType.Decimal,18,2){Nullable=true} ,
          new ParDef("@InvoicePaymentMethodDiscountIm",GXType.Decimal,18,2){Nullable=true} ,
          new ParDef("@PaymentMethodId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT000659;
          prmT000659 = new Object[] {
          new ParDef("@InvoicePaymentMethodImport",GXType.Decimal,18,2){Nullable=true} ,
          new ParDef("@InvoicePaymentMethodRechargeIm",GXType.Decimal,18,2){Nullable=true} ,
          new ParDef("@InvoicePaymentMethodDiscountIm",GXType.Decimal,18,2){Nullable=true} ,
          new ParDef("@PaymentMethodId",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("@InvoiceId",GXType.Int32,6,0) ,
          new ParDef("@InvoicePaymentMethodId",GXType.Int32,6,0)
          };
          Object[] prmT000660;
          prmT000660 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0) ,
          new ParDef("@InvoicePaymentMethodId",GXType.Int32,6,0)
          };
          Object[] prmT000662;
          prmT000662 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmT000640;
          prmT000640 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmT000642;
          prmT000642 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmT000644;
          prmT000644 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmT000645;
          prmT000645 = new Object[] {
          new ParDef("@UserId",GXType.Int32,6,0)
          };
          Object[] prmT000653;
          prmT000653 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmT000661;
          prmT000661 = new Object[] {
          new ParDef("@PaymentMethodId",GXType.Int32,6,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T00062", "SELECT [InvoiceId], [InvoicePaymentMethodId], [InvoicePaymentMethodImport], [InvoicePaymentMethodRechargeIm], [InvoicePaymentMethodDiscountIm], [PaymentMethodId] FROM [InvoicePaymentMethod] WITH (UPDLOCK) WHERE [InvoiceId] = @InvoiceId AND [InvoicePaymentMethodId] = @InvoicePaymentMethodId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00062,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00063", "SELECT [InvoiceId], [InvoicePaymentMethodId], [InvoicePaymentMethodImport], [InvoicePaymentMethodRechargeIm], [InvoicePaymentMethodDiscountIm], [PaymentMethodId] FROM [InvoicePaymentMethod] WHERE [InvoiceId] = @InvoiceId AND [InvoicePaymentMethodId] = @InvoicePaymentMethodId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00063,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00064", "SELECT [PaymentMethodDescription], [PaymentMethodDiscount], [PaymentMethodRecarge] FROM [PaymentMethod] WHERE [PaymentMethodId] = @PaymentMethodId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00064,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00068", "SELECT COALESCE( T1.[InvoiceTotalReceivable], 0) AS InvoiceTotalReceivable FROM (SELECT COALESCE( T3.[GXC1], 0) - COALESCE( T2.[GXC2], 0) + COALESCE( T2.[GXC3], 0) AS InvoiceTotalReceivable FROM (SELECT SUM([InvoicePaymentMethodDiscountIm]) AS GXC2, [InvoiceId], SUM([InvoicePaymentMethodRechargeIm]) AS GXC3 FROM [InvoicePaymentMethod] WITH (UPDLOCK) GROUP BY [InvoiceId] ) T2, (SELECT SUM([InvoiceDetailQuantity] * CAST([InvoiceDetailHistoricPrice] AS decimal( 28, 10))) AS GXC1, [InvoiceId] FROM [InvoiceDetail] WITH (UPDLOCK) GROUP BY [InvoiceId] ) T3 WHERE T2.[InvoiceId] = @InvoiceId AND T3.[InvoiceId] = @InvoiceId ) T1 ",true, GxErrorMask.GX_NOMASK, false, this,prmT00068,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000610", "SELECT COALESCE( T1.[InvoiceLastPaymentMethodId], 0) AS InvoiceLastPaymentMethodId FROM (SELECT MAX([InvoicePaymentMethodId]) AS InvoiceLastPaymentMethodId, [InvoiceId] FROM [InvoicePaymentMethod] WITH (UPDLOCK) GROUP BY [InvoiceId] ) T1 WHERE T1.[InvoiceId] = @InvoiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000610,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000611", "SELECT [InvoiceId], [InvoiceDetailId], [InvoiceDetailQuantity], [InvoiceDetailHistoricPrice], [InvoiceDetailIsWholesale], [ProductId] FROM [InvoiceDetail] WITH (UPDLOCK) WHERE [InvoiceId] = @InvoiceId AND [InvoiceDetailId] = @InvoiceDetailId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000611,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000612", "SELECT [InvoiceId], [InvoiceDetailId], [InvoiceDetailQuantity], [InvoiceDetailHistoricPrice], [InvoiceDetailIsWholesale], [ProductId] FROM [InvoiceDetail] WHERE [InvoiceId] = @InvoiceId AND [InvoiceDetailId] = @InvoiceDetailId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000612,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000613", "SELECT [ProductName], [ProductStock] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000613,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000615", "SELECT COALESCE( T1.[InvoiceProductQuantity], 0) AS InvoiceProductQuantity, COALESCE( T1.[InvoiceLastDetailId], 0) AS InvoiceLastDetailId FROM (SELECT COUNT(*) AS InvoiceProductQuantity, [InvoiceId], MAX([InvoiceDetailId]) AS InvoiceLastDetailId FROM [InvoiceDetail] WITH (UPDLOCK) GROUP BY [InvoiceId] ) T1 WHERE T1.[InvoiceId] = @InvoiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000615,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000616", "SELECT [InvoiceId], [InvoiceCreatedDate], [InvoiceModifiedDate], [InvoiceActive], [UserId] FROM [Invoice] WITH (UPDLOCK) WHERE [InvoiceId] = @InvoiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000616,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000617", "SELECT [InvoiceId], [InvoiceCreatedDate], [InvoiceModifiedDate], [InvoiceActive], [UserId] FROM [Invoice] WHERE [InvoiceId] = @InvoiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000617,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000618", "SELECT [UserName] FROM [User] WHERE [UserId] = @UserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000618,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000621", "SELECT TM1.[InvoiceId], TM1.[InvoiceCreatedDate], T4.[UserName], TM1.[InvoiceModifiedDate], TM1.[InvoiceActive], TM1.[UserId], COALESCE( T2.[InvoiceProductQuantity], 0) AS InvoiceProductQuantity, COALESCE( T2.[InvoiceLastDetailId], 0) AS InvoiceLastDetailId, COALESCE( T3.[InvoiceLastPaymentMethodId], 0) AS InvoiceLastPaymentMethodId FROM ((([Invoice] TM1 LEFT JOIN (SELECT COUNT(*) AS InvoiceProductQuantity, [InvoiceId], MAX([InvoiceDetailId]) AS InvoiceLastDetailId FROM [InvoiceDetail] GROUP BY [InvoiceId] ) T2 ON T2.[InvoiceId] = TM1.[InvoiceId]) LEFT JOIN (SELECT MAX([InvoicePaymentMethodId]) AS InvoiceLastPaymentMethodId, [InvoiceId] FROM [InvoicePaymentMethod] GROUP BY [InvoiceId] ) T3 ON T3.[InvoiceId] = TM1.[InvoiceId]) INNER JOIN [User] T4 ON T4.[UserId] = TM1.[UserId]) WHERE TM1.[InvoiceId] = @InvoiceId ORDER BY TM1.[InvoiceId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000621,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000625", "SELECT COALESCE( T1.[InvoiceTotalReceivable], 0) AS InvoiceTotalReceivable FROM (SELECT COALESCE( T3.[GXC1], 0) - COALESCE( T2.[GXC2], 0) + COALESCE( T2.[GXC3], 0) AS InvoiceTotalReceivable FROM (SELECT SUM([InvoicePaymentMethodDiscountIm]) AS GXC2, [InvoiceId], SUM([InvoicePaymentMethodRechargeIm]) AS GXC3 FROM [InvoicePaymentMethod] WITH (UPDLOCK) GROUP BY [InvoiceId] ) T2, (SELECT SUM([InvoiceDetailQuantity] * CAST([InvoiceDetailHistoricPrice] AS decimal( 28, 10))) AS GXC1, [InvoiceId] FROM [InvoiceDetail] WITH (UPDLOCK) GROUP BY [InvoiceId] ) T3 WHERE T2.[InvoiceId] = @InvoiceId AND T3.[InvoiceId] = @InvoiceId ) T1 ",true, GxErrorMask.GX_NOMASK, false, this,prmT000625,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000627", "SELECT COALESCE( T1.[InvoiceProductQuantity], 0) AS InvoiceProductQuantity, COALESCE( T1.[InvoiceLastDetailId], 0) AS InvoiceLastDetailId FROM (SELECT COUNT(*) AS InvoiceProductQuantity, [InvoiceId], MAX([InvoiceDetailId]) AS InvoiceLastDetailId FROM [InvoiceDetail] WITH (UPDLOCK) GROUP BY [InvoiceId] ) T1 WHERE T1.[InvoiceId] = @InvoiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000627,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000629", "SELECT COALESCE( T1.[InvoiceLastPaymentMethodId], 0) AS InvoiceLastPaymentMethodId FROM (SELECT MAX([InvoicePaymentMethodId]) AS InvoiceLastPaymentMethodId, [InvoiceId] FROM [InvoicePaymentMethod] WITH (UPDLOCK) GROUP BY [InvoiceId] ) T1 WHERE T1.[InvoiceId] = @InvoiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000629,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000630", "SELECT [UserName] FROM [User] WHERE [UserId] = @UserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000630,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000631", "SELECT [InvoiceId] FROM [Invoice] WHERE [InvoiceId] = @InvoiceId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000631,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000632", "SELECT TOP 1 [InvoiceId] FROM [Invoice] WHERE ( [InvoiceId] > @InvoiceId) ORDER BY [InvoiceId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000632,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000633", "SELECT TOP 1 [InvoiceId] FROM [Invoice] WHERE ( [InvoiceId] < @InvoiceId) ORDER BY [InvoiceId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000633,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000634", "INSERT INTO [Invoice]([InvoiceCreatedDate], [InvoiceModifiedDate], [InvoiceActive], [UserId]) VALUES(@InvoiceCreatedDate, @InvoiceModifiedDate, @InvoiceActive, @UserId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000634,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000635", "UPDATE [Invoice] SET [InvoiceCreatedDate]=@InvoiceCreatedDate, [InvoiceModifiedDate]=@InvoiceModifiedDate, [InvoiceActive]=@InvoiceActive, [UserId]=@UserId  WHERE [InvoiceId] = @InvoiceId", GxErrorMask.GX_NOMASK,prmT000635)
             ,new CursorDef("T000636", "DELETE FROM [Invoice]  WHERE [InvoiceId] = @InvoiceId", GxErrorMask.GX_NOMASK,prmT000636)
             ,new CursorDef("T000640", "SELECT COALESCE( T1.[InvoiceTotalReceivable], 0) AS InvoiceTotalReceivable FROM (SELECT COALESCE( T3.[GXC1], 0) - COALESCE( T2.[GXC2], 0) + COALESCE( T2.[GXC3], 0) AS InvoiceTotalReceivable FROM (SELECT SUM([InvoicePaymentMethodDiscountIm]) AS GXC2, [InvoiceId], SUM([InvoicePaymentMethodRechargeIm]) AS GXC3 FROM [InvoicePaymentMethod] WITH (UPDLOCK) GROUP BY [InvoiceId] ) T2, (SELECT SUM([InvoiceDetailQuantity] * CAST([InvoiceDetailHistoricPrice] AS decimal( 28, 10))) AS GXC1, [InvoiceId] FROM [InvoiceDetail] WITH (UPDLOCK) GROUP BY [InvoiceId] ) T3 WHERE T2.[InvoiceId] = @InvoiceId AND T3.[InvoiceId] = @InvoiceId ) T1 ",true, GxErrorMask.GX_NOMASK, false, this,prmT000640,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000642", "SELECT COALESCE( T1.[InvoiceProductQuantity], 0) AS InvoiceProductQuantity, COALESCE( T1.[InvoiceLastDetailId], 0) AS InvoiceLastDetailId FROM (SELECT COUNT(*) AS InvoiceProductQuantity, [InvoiceId], MAX([InvoiceDetailId]) AS InvoiceLastDetailId FROM [InvoiceDetail] WITH (UPDLOCK) GROUP BY [InvoiceId] ) T1 WHERE T1.[InvoiceId] = @InvoiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000642,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000644", "SELECT COALESCE( T1.[InvoiceLastPaymentMethodId], 0) AS InvoiceLastPaymentMethodId FROM (SELECT MAX([InvoicePaymentMethodId]) AS InvoiceLastPaymentMethodId, [InvoiceId] FROM [InvoicePaymentMethod] WITH (UPDLOCK) GROUP BY [InvoiceId] ) T1 WHERE T1.[InvoiceId] = @InvoiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000644,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000645", "SELECT [UserName] FROM [User] WHERE [UserId] = @UserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000645,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000646", "SELECT [InvoiceId] FROM [Invoice] ORDER BY [InvoiceId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000646,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000647", "SELECT T1.[InvoiceId], T1.[InvoiceDetailId], T2.[ProductName], T2.[ProductStock], T1.[InvoiceDetailQuantity], T1.[InvoiceDetailHistoricPrice], T1.[InvoiceDetailIsWholesale], T1.[ProductId] FROM ([InvoiceDetail] T1 INNER JOIN [Product] T2 ON T2.[ProductId] = T1.[ProductId]) WHERE T1.[InvoiceId] = @InvoiceId and T1.[InvoiceDetailId] = @InvoiceDetailId ORDER BY T1.[InvoiceId], T1.[InvoiceDetailId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000647,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000648", "SELECT [ProductName], [ProductStock] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000648,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000649", "SELECT [InvoiceId], [InvoiceDetailId] FROM [InvoiceDetail] WHERE [InvoiceId] = @InvoiceId AND [InvoiceDetailId] = @InvoiceDetailId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000649,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000650", "INSERT INTO [InvoiceDetail]([InvoiceId], [InvoiceDetailId], [InvoiceDetailQuantity], [InvoiceDetailHistoricPrice], [InvoiceDetailIsWholesale], [ProductId]) VALUES(@InvoiceId, @InvoiceDetailId, @InvoiceDetailQuantity, @InvoiceDetailHistoricPrice, @InvoiceDetailIsWholesale, @ProductId)", GxErrorMask.GX_NOMASK,prmT000650)
             ,new CursorDef("T000651", "UPDATE [InvoiceDetail] SET [InvoiceDetailQuantity]=@InvoiceDetailQuantity, [InvoiceDetailHistoricPrice]=@InvoiceDetailHistoricPrice, [InvoiceDetailIsWholesale]=@InvoiceDetailIsWholesale, [ProductId]=@ProductId  WHERE [InvoiceId] = @InvoiceId AND [InvoiceDetailId] = @InvoiceDetailId", GxErrorMask.GX_NOMASK,prmT000651)
             ,new CursorDef("T000652", "DELETE FROM [InvoiceDetail]  WHERE [InvoiceId] = @InvoiceId AND [InvoiceDetailId] = @InvoiceDetailId", GxErrorMask.GX_NOMASK,prmT000652)
             ,new CursorDef("T000653", "SELECT [ProductName], [ProductStock] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000653,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000654", "SELECT [InvoiceId], [InvoiceDetailId] FROM [InvoiceDetail] WHERE [InvoiceId] = @InvoiceId ORDER BY [InvoiceId], [InvoiceDetailId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000654,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000655", "SELECT T1.[InvoiceId], T1.[InvoicePaymentMethodId], T2.[PaymentMethodDescription], T2.[PaymentMethodDiscount], T2.[PaymentMethodRecarge], T1.[InvoicePaymentMethodImport], T1.[InvoicePaymentMethodRechargeIm], T1.[InvoicePaymentMethodDiscountIm], T1.[PaymentMethodId] FROM ([InvoicePaymentMethod] T1 LEFT JOIN [PaymentMethod] T2 ON T2.[PaymentMethodId] = T1.[PaymentMethodId]) WHERE T1.[InvoiceId] = @InvoiceId and T1.[InvoicePaymentMethodId] = @InvoicePaymentMethodId ORDER BY T1.[InvoiceId], T1.[InvoicePaymentMethodId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000655,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000656", "SELECT [PaymentMethodDescription], [PaymentMethodDiscount], [PaymentMethodRecarge] FROM [PaymentMethod] WHERE [PaymentMethodId] = @PaymentMethodId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000656,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000657", "SELECT [InvoiceId], [InvoicePaymentMethodId] FROM [InvoicePaymentMethod] WHERE [InvoiceId] = @InvoiceId AND [InvoicePaymentMethodId] = @InvoicePaymentMethodId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000657,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000658", "INSERT INTO [InvoicePaymentMethod]([InvoiceId], [InvoicePaymentMethodId], [InvoicePaymentMethodImport], [InvoicePaymentMethodRechargeIm], [InvoicePaymentMethodDiscountIm], [PaymentMethodId]) VALUES(@InvoiceId, @InvoicePaymentMethodId, @InvoicePaymentMethodImport, @InvoicePaymentMethodRechargeIm, @InvoicePaymentMethodDiscountIm, @PaymentMethodId)", GxErrorMask.GX_NOMASK,prmT000658)
             ,new CursorDef("T000659", "UPDATE [InvoicePaymentMethod] SET [InvoicePaymentMethodImport]=@InvoicePaymentMethodImport, [InvoicePaymentMethodRechargeIm]=@InvoicePaymentMethodRechargeIm, [InvoicePaymentMethodDiscountIm]=@InvoicePaymentMethodDiscountIm, [PaymentMethodId]=@PaymentMethodId  WHERE [InvoiceId] = @InvoiceId AND [InvoicePaymentMethodId] = @InvoicePaymentMethodId", GxErrorMask.GX_NOMASK,prmT000659)
             ,new CursorDef("T000660", "DELETE FROM [InvoicePaymentMethod]  WHERE [InvoiceId] = @InvoiceId AND [InvoicePaymentMethodId] = @InvoicePaymentMethodId", GxErrorMask.GX_NOMASK,prmT000660)
             ,new CursorDef("T000661", "SELECT [PaymentMethodDescription], [PaymentMethodDiscount], [PaymentMethodRecarge] FROM [PaymentMethod] WHERE [PaymentMethodId] = @PaymentMethodId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000661,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000662", "SELECT [InvoiceId], [InvoicePaymentMethodId] FROM [InvoicePaymentMethod] WHERE [InvoiceId] = @InvoiceId ORDER BY [InvoiceId], [InvoicePaymentMethodId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000662,11, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((int[]) buf[8])[0] = rslt.getInt(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((int[]) buf[8])[0] = rslt.getInt(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                return;
             case 3 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((bool[]) buf[4])[0] = rslt.getBool(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((bool[]) buf[4])[0] = rslt.getBool(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((bool[]) buf[5])[0] = rslt.getBool(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                ((int[]) buf[8])[0] = rslt.getInt(8);
                ((int[]) buf[9])[0] = rslt.getInt(9);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                return;
             case 13 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 14 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 15 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 16 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 17 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 18 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 19 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 20 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 23 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 24 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 25 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 26 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 27 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 28 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(6);
                ((bool[]) buf[7])[0] = rslt.getBool(7);
                ((int[]) buf[8])[0] = rslt.getInt(8);
                return;
             case 29 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
       }
       getresults30( cursor, rslt, buf) ;
    }

    public void getresults30( int cursor ,
                              IFieldGetter rslt ,
                              Object[] buf )
    {
       switch ( cursor )
       {
             case 30 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 34 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 35 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 36 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((int[]) buf[11])[0] = rslt.getInt(9);
                ((bool[]) buf[12])[0] = rslt.wasNull(9);
                return;
             case 37 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                return;
             case 38 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 42 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                return;
             case 43 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
       }
    }

 }

}
