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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_15") == 0 )
         {
            A20InvoiceId = (int)(Math.Round(NumberUtil.Val( GetPar( "InvoiceId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A20InvoiceId", StringUtil.LTrimStr( (decimal)(A20InvoiceId), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_15( A20InvoiceId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_14") == 0 )
         {
            A12EmployeeId = (int)(Math.Round(NumberUtil.Val( GetPar( "EmployeeId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A12EmployeeId", StringUtil.LTrimStr( (decimal)(A12EmployeeId), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_14( A12EmployeeId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_17") == 0 )
         {
            A15ProductId = (int)(Math.Round(NumberUtil.Val( GetPar( "ProductId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_17( A15ProductId) ;
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
               AV7InvoiceId = (int)(Math.Round(NumberUtil.Val( GetPar( "InvoiceId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7InvoiceId", StringUtil.LTrimStr( (decimal)(AV7InvoiceId), 6, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vINVOICEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7InvoiceId), "ZZZZZ9"), context));
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
            GX_FocusControl = edtInvoiceDate_Internalname;
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
         nRC_GXsfl_78 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_78"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_78_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_78_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_78_idx = GetPar( "sGXsfl_78_idx");
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
         this.AV7InvoiceId = aP1_InvoiceId;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtInvoiceDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtInvoiceDate_Internalname, "Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtInvoiceDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtInvoiceDate_Internalname, context.localUtil.Format(A21InvoiceDate, "99/99/99"), context.localUtil.Format( A21InvoiceDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtInvoiceDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtInvoiceDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Invoice.htm");
         GxWebStd.gx_bitmap( context, edtInvoiceDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtInvoiceDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Invoice.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEmployeeId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmployeeId_Internalname, "Employee Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmployeeId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A12EmployeeId), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A12EmployeeId), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmployeeId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmployeeId_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_Invoice.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_12_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_12_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_12_Internalname, sImgUrl, imgprompt_12_Link, "", "", context.GetTheme( ), imgprompt_12_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Invoice.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEmployeeLastName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmployeeLastName_Internalname, "Employee Last Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtEmployeeLastName_Internalname, A14EmployeeLastName, StringUtil.RTrim( context.localUtil.Format( A14EmployeeLastName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmployeeLastName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmployeeLastName_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Name", "left", true, "", "HLP_Invoice.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEmployeeFirstName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEmployeeFirstName_Internalname, "Employee First Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtEmployeeFirstName_Internalname, A13EmployeeFirstName, StringUtil.RTrim( context.localUtil.Format( A13EmployeeFirstName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmployeeFirstName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmployeeFirstName_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Name", "left", true, "", "HLP_Invoice.htm");
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
         context.WriteHtmlText( "<div id=\""+edtInvoiceCreatedDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtInvoiceCreatedDate_Internalname, context.localUtil.Format(A38InvoiceCreatedDate, "99/99/99"), context.localUtil.Format( A38InvoiceCreatedDate, "99/99/99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtInvoiceCreatedDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtInvoiceCreatedDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Invoice.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtInvoiceModifiedDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtInvoiceModifiedDate_Internalname, "Modified Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtInvoiceModifiedDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtInvoiceModifiedDate_Internalname, context.localUtil.Format(A39InvoiceModifiedDate, "99/99/99"), context.localUtil.Format( A39InvoiceModifiedDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtInvoiceModifiedDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtInvoiceModifiedDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Invoice.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Invoice.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Invoice.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
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
         StartGridControl78( ) ;
         nGXsfl_78_idx = 0;
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
            B68InvoiceProductQuantity = A68InvoiceProductQuantity;
            n68InvoiceProductQuantity = false;
            AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
            standaloneNotModal0613( ) ;
            standaloneModal0613( ) ;
            sMode13 = Gx_mode;
            while ( nGXsfl_78_idx < nRC_GXsfl_78 )
            {
               bGXsfl_78_Refreshing = true;
               ReadRow0613( ) ;
               edtInvoiceDetailId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVOICEDETAILID_"+sGXsfl_78_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtInvoiceDetailId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceDetailId_Enabled), 5, 0), !bGXsfl_78_Refreshing);
               edtInvoiceDetailQuantity_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVOICEDETAILQUANTITY_"+sGXsfl_78_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtInvoiceDetailQuantity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceDetailQuantity_Enabled), 5, 0), !bGXsfl_78_Refreshing);
               edtInvoiceDetailHistoricPrice_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVOICEDETAILHISTORICPRICE_"+sGXsfl_78_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtInvoiceDetailHistoricPrice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceDetailHistoricPrice_Enabled), 5, 0), !bGXsfl_78_Refreshing);
               edtProductId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTID_"+sGXsfl_78_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), !bGXsfl_78_Refreshing);
               edtProductName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTNAME_"+sGXsfl_78_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProductName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductName_Enabled), 5, 0), !bGXsfl_78_Refreshing);
               imgprompt_12_Link = cgiGet( "PROMPT_15_"+sGXsfl_78_idx+"Link");
               if ( ( nRcdExists_13 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0613( ) ;
               }
               SendRow0613( ) ;
               bGXsfl_78_Refreshing = false;
            }
            Gx_mode = sMode13;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A68InvoiceProductQuantity = B68InvoiceProductQuantity;
            n68InvoiceProductQuantity = false;
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
                  sGXsfl_78_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_78_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_7813( ) ;
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
            sGXsfl_78_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_78_idx+1), 4, 0), 4, "0");
            SubsflControlProps_7813( ) ;
            InitAll0613( ) ;
            init_level_properties13( ) ;
            B68InvoiceProductQuantity = A68InvoiceProductQuantity;
            n68InvoiceProductQuantity = false;
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
            A68InvoiceProductQuantity = B68InvoiceProductQuantity;
            n68InvoiceProductQuantity = false;
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
               Z21InvoiceDate = context.localUtil.CToD( cgiGet( "Z21InvoiceDate"), 0);
               Z38InvoiceCreatedDate = context.localUtil.CToD( cgiGet( "Z38InvoiceCreatedDate"), 0);
               Z39InvoiceModifiedDate = context.localUtil.CToD( cgiGet( "Z39InvoiceModifiedDate"), 0);
               n39InvoiceModifiedDate = ((DateTime.MinValue==A39InvoiceModifiedDate) ? true : false);
               Z12EmployeeId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z12EmployeeId"), ".", ","), 18, MidpointRounding.ToEven));
               O68InvoiceProductQuantity = (short)(Math.Round(context.localUtil.CToN( cgiGet( "O68InvoiceProductQuantity"), ".", ","), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_78 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_78"), ".", ","), 18, MidpointRounding.ToEven));
               N12EmployeeId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N12EmployeeId"), ".", ","), 18, MidpointRounding.ToEven));
               AV7InvoiceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINVOICEID"), ".", ","), 18, MidpointRounding.ToEven));
               AV11Insert_EmployeeId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_EMPLOYEEID"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_date = context.localUtil.CToD( cgiGet( "vTODAY"), 0);
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","), 18, MidpointRounding.ToEven));
               AV15Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A20InvoiceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtInvoiceId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A20InvoiceId", StringUtil.LTrimStr( (decimal)(A20InvoiceId), 6, 0));
               if ( context.localUtil.VCDate( cgiGet( edtInvoiceDate_Internalname), 1) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Invoice Date"}), 1, "INVOICEDATE");
                  AnyError = 1;
                  GX_FocusControl = edtInvoiceDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A21InvoiceDate = DateTime.MinValue;
                  AssignAttri("", false, "A21InvoiceDate", context.localUtil.Format(A21InvoiceDate, "99/99/99"));
               }
               else
               {
                  A21InvoiceDate = context.localUtil.CToD( cgiGet( edtInvoiceDate_Internalname), 1);
                  AssignAttri("", false, "A21InvoiceDate", context.localUtil.Format(A21InvoiceDate, "99/99/99"));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtEmployeeId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtEmployeeId_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "EMPLOYEEID");
                  AnyError = 1;
                  GX_FocusControl = edtEmployeeId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A12EmployeeId = 0;
                  AssignAttri("", false, "A12EmployeeId", StringUtil.LTrimStr( (decimal)(A12EmployeeId), 6, 0));
               }
               else
               {
                  A12EmployeeId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtEmployeeId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A12EmployeeId", StringUtil.LTrimStr( (decimal)(A12EmployeeId), 6, 0));
               }
               A14EmployeeLastName = cgiGet( edtEmployeeLastName_Internalname);
               AssignAttri("", false, "A14EmployeeLastName", A14EmployeeLastName);
               A13EmployeeFirstName = cgiGet( edtEmployeeFirstName_Internalname);
               AssignAttri("", false, "A13EmployeeFirstName", A13EmployeeFirstName);
               A38InvoiceCreatedDate = context.localUtil.CToD( cgiGet( edtInvoiceCreatedDate_Internalname), 1);
               AssignAttri("", false, "A38InvoiceCreatedDate", context.localUtil.Format(A38InvoiceCreatedDate, "99/99/99"));
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
               A68InvoiceProductQuantity = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtInvoiceProductQuantity_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               n68InvoiceProductQuantity = false;
               AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Invoice");
               A20InvoiceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtInvoiceId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A20InvoiceId", StringUtil.LTrimStr( (decimal)(A20InvoiceId), 6, 0));
               forbiddenHiddens.Add("InvoiceId", context.localUtil.Format( (decimal)(A20InvoiceId), "ZZZZZ9"));
               A38InvoiceCreatedDate = context.localUtil.CToD( cgiGet( edtInvoiceCreatedDate_Internalname), 1);
               AssignAttri("", false, "A38InvoiceCreatedDate", context.localUtil.Format(A38InvoiceCreatedDate, "99/99/99"));
               forbiddenHiddens.Add("InvoiceCreatedDate", context.localUtil.Format(A38InvoiceCreatedDate, "99/99/99"));
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
               /* Restore parent mode. */
               Gx_mode = sMode6;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_0613( )
      {
         s68InvoiceProductQuantity = O68InvoiceProductQuantity;
         n68InvoiceProductQuantity = false;
         AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
         nGXsfl_78_idx = 0;
         while ( nGXsfl_78_idx < nRC_GXsfl_78 )
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
                        O68InvoiceProductQuantity = A68InvoiceProductQuantity;
                        n68InvoiceProductQuantity = false;
                        AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
                     }
                  }
                  else
                  {
                     GXCCtl = "INVOICEDETAILID_" + sGXsfl_78_idx;
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
                           O68InvoiceProductQuantity = A68InvoiceProductQuantity;
                           n68InvoiceProductQuantity = false;
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
                              O68InvoiceProductQuantity = A68InvoiceProductQuantity;
                              n68InvoiceProductQuantity = false;
                              AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_13 == 0 )
                     {
                        GXCCtl = "INVOICEDETAILID_" + sGXsfl_78_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtInvoiceDetailId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtInvoiceDetailId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A25InvoiceDetailId), 6, 0, ".", ""))) ;
            ChangePostValue( edtInvoiceDetailQuantity_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A26InvoiceDetailQuantity), 6, 0, ".", ""))) ;
            ChangePostValue( edtInvoiceDetailHistoricPrice_Internalname, StringUtil.LTrim( StringUtil.NToC( A65InvoiceDetailHistoricPrice, 10, 2, ".", ""))) ;
            ChangePostValue( edtProductId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", ""))) ;
            ChangePostValue( edtProductName_Internalname, A16ProductName) ;
            ChangePostValue( "ZT_"+"Z25InvoiceDetailId_"+sGXsfl_78_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z25InvoiceDetailId), 6, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z26InvoiceDetailQuantity_"+sGXsfl_78_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z26InvoiceDetailQuantity), 6, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z65InvoiceDetailHistoricPrice_"+sGXsfl_78_idx, StringUtil.LTrim( StringUtil.NToC( Z65InvoiceDetailHistoricPrice, 10, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z15ProductId_"+sGXsfl_78_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z15ProductId), 6, 0, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_13_"+sGXsfl_78_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_13), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_13_"+sGXsfl_78_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_13), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_13_"+sGXsfl_78_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_13), 4, 0, ".", ""))) ;
            if ( nIsMod_13 != 0 )
            {
               ChangePostValue( "INVOICEDETAILID_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvoiceDetailId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVOICEDETAILQUANTITY_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvoiceDetailQuantity_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVOICEDETAILHISTORICPRICE_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvoiceDetailHistoricPrice_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTID_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTNAME_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductName_Enabled), 5, 0, ".", ""))) ;
            }
         }
         O68InvoiceProductQuantity = s68InvoiceProductQuantity;
         n68InvoiceProductQuantity = false;
         AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption060( )
      {
      }

      protected void E11062( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV15Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV15Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         AV11Insert_EmployeeId = 0;
         AssignAttri("", false, "AV11Insert_EmployeeId", StringUtil.LTrimStr( (decimal)(AV11Insert_EmployeeId), 6, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV15Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV16GXV1 = 1;
            AssignAttri("", false, "AV16GXV1", StringUtil.LTrimStr( (decimal)(AV16GXV1), 8, 0));
            while ( AV16GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((GeneXus.Programs.general.ui.SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV16GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "EmployeeId") == 0 )
               {
                  AV11Insert_EmployeeId = (int)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_EmployeeId", StringUtil.LTrimStr( (decimal)(AV11Insert_EmployeeId), 6, 0));
               }
               AV16GXV1 = (int)(AV16GXV1+1);
               AssignAttri("", false, "AV16GXV1", StringUtil.LTrimStr( (decimal)(AV16GXV1), 8, 0));
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            bttBtn_enter_Caption = "Delete";
            AssignProp("", false, bttBtn_enter_Internalname, "Caption", bttBtn_enter_Caption, true);
            bttBtn_enter_Tooltiptext = "Delete";
            AssignProp("", false, bttBtn_enter_Internalname, "Tooltiptext", bttBtn_enter_Tooltiptext, true);
         }
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
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z21InvoiceDate = T00066_A21InvoiceDate[0];
               Z38InvoiceCreatedDate = T00066_A38InvoiceCreatedDate[0];
               Z39InvoiceModifiedDate = T00066_A39InvoiceModifiedDate[0];
               Z12EmployeeId = T00066_A12EmployeeId[0];
            }
            else
            {
               Z21InvoiceDate = A21InvoiceDate;
               Z38InvoiceCreatedDate = A38InvoiceCreatedDate;
               Z39InvoiceModifiedDate = A39InvoiceModifiedDate;
               Z12EmployeeId = A12EmployeeId;
            }
         }
         if ( GX_JID == -13 )
         {
            Z20InvoiceId = A20InvoiceId;
            Z21InvoiceDate = A21InvoiceDate;
            Z38InvoiceCreatedDate = A38InvoiceCreatedDate;
            Z39InvoiceModifiedDate = A39InvoiceModifiedDate;
            Z12EmployeeId = A12EmployeeId;
            Z68InvoiceProductQuantity = A68InvoiceProductQuantity;
            Z14EmployeeLastName = A14EmployeeLastName;
            Z13EmployeeFirstName = A13EmployeeFirstName;
         }
      }

      protected void standaloneNotModal( )
      {
         edtInvoiceId_Enabled = 0;
         AssignProp("", false, edtInvoiceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceId_Enabled), 5, 0), true);
         edtInvoiceCreatedDate_Enabled = 0;
         AssignProp("", false, edtInvoiceCreatedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceCreatedDate_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         Gx_date = DateTimeUtil.Today( context);
         AssignAttri("", false, "Gx_date", context.localUtil.Format(Gx_date, "99/99/99"));
         imgprompt_12_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0040.aspx"+"',["+"{Ctrl:gx.dom.el('"+"EMPLOYEEID"+"'), id:'"+"EMPLOYEEID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtInvoiceId_Enabled = 0;
         AssignProp("", false, edtInvoiceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceId_Enabled), 5, 0), true);
         edtInvoiceCreatedDate_Enabled = 0;
         AssignProp("", false, edtInvoiceCreatedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceCreatedDate_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7InvoiceId) )
         {
            A20InvoiceId = AV7InvoiceId;
            AssignAttri("", false, "A20InvoiceId", StringUtil.LTrimStr( (decimal)(A20InvoiceId), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_EmployeeId) )
         {
            edtEmployeeId_Enabled = 0;
            AssignProp("", false, edtEmployeeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeId_Enabled), 5, 0), true);
         }
         else
         {
            edtEmployeeId_Enabled = 1;
            AssignProp("", false, edtEmployeeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_EmployeeId) )
         {
            A12EmployeeId = AV11Insert_EmployeeId;
            AssignAttri("", false, "A12EmployeeId", StringUtil.LTrimStr( (decimal)(A12EmployeeId), 6, 0));
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
         if ( IsIns( )  && (DateTime.MinValue==A38InvoiceCreatedDate) && ( Gx_BScreen == 0 ) )
         {
            A38InvoiceCreatedDate = Gx_date;
            AssignAttri("", false, "A38InvoiceCreatedDate", context.localUtil.Format(A38InvoiceCreatedDate, "99/99/99"));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T00069 */
            pr_default.execute(6, new Object[] {A20InvoiceId});
            if ( (pr_default.getStatus(6) != 101) )
            {
               A68InvoiceProductQuantity = T00069_A68InvoiceProductQuantity[0];
               n68InvoiceProductQuantity = T00069_n68InvoiceProductQuantity[0];
               AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
            }
            else
            {
               A68InvoiceProductQuantity = 0;
               n68InvoiceProductQuantity = false;
               AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
            }
            O68InvoiceProductQuantity = A68InvoiceProductQuantity;
            n68InvoiceProductQuantity = false;
            AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
            pr_default.close(6);
            AV15Pgmname = "Invoice";
            AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
            /* Using cursor T00067 */
            pr_default.execute(5, new Object[] {A12EmployeeId});
            A14EmployeeLastName = T00067_A14EmployeeLastName[0];
            AssignAttri("", false, "A14EmployeeLastName", A14EmployeeLastName);
            A13EmployeeFirstName = T00067_A13EmployeeFirstName[0];
            AssignAttri("", false, "A13EmployeeFirstName", A13EmployeeFirstName);
            pr_default.close(5);
         }
      }

      protected void Load066( )
      {
         /* Using cursor T000611 */
         pr_default.execute(7, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound6 = 1;
            A21InvoiceDate = T000611_A21InvoiceDate[0];
            AssignAttri("", false, "A21InvoiceDate", context.localUtil.Format(A21InvoiceDate, "99/99/99"));
            A14EmployeeLastName = T000611_A14EmployeeLastName[0];
            AssignAttri("", false, "A14EmployeeLastName", A14EmployeeLastName);
            A13EmployeeFirstName = T000611_A13EmployeeFirstName[0];
            AssignAttri("", false, "A13EmployeeFirstName", A13EmployeeFirstName);
            A38InvoiceCreatedDate = T000611_A38InvoiceCreatedDate[0];
            AssignAttri("", false, "A38InvoiceCreatedDate", context.localUtil.Format(A38InvoiceCreatedDate, "99/99/99"));
            A39InvoiceModifiedDate = T000611_A39InvoiceModifiedDate[0];
            n39InvoiceModifiedDate = T000611_n39InvoiceModifiedDate[0];
            AssignAttri("", false, "A39InvoiceModifiedDate", context.localUtil.Format(A39InvoiceModifiedDate, "99/99/99"));
            A12EmployeeId = T000611_A12EmployeeId[0];
            AssignAttri("", false, "A12EmployeeId", StringUtil.LTrimStr( (decimal)(A12EmployeeId), 6, 0));
            A68InvoiceProductQuantity = T000611_A68InvoiceProductQuantity[0];
            n68InvoiceProductQuantity = T000611_n68InvoiceProductQuantity[0];
            AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
            ZM066( -13) ;
         }
         pr_default.close(7);
         OnLoadActions066( ) ;
      }

      protected void OnLoadActions066( )
      {
         O68InvoiceProductQuantity = A68InvoiceProductQuantity;
         n68InvoiceProductQuantity = false;
         AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
         AV15Pgmname = "Invoice";
         AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
      }

      protected void CheckExtendedTable066( )
      {
         nIsDirty_6 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV15Pgmname = "Invoice";
         AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
         /* Using cursor T00069 */
         pr_default.execute(6, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            A68InvoiceProductQuantity = T00069_A68InvoiceProductQuantity[0];
            n68InvoiceProductQuantity = T00069_n68InvoiceProductQuantity[0];
            AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
         }
         else
         {
            nIsDirty_6 = 1;
            A68InvoiceProductQuantity = 0;
            n68InvoiceProductQuantity = false;
            AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
         }
         pr_default.close(6);
         if ( ! ( (DateTime.MinValue==A21InvoiceDate) || ( DateTimeUtil.ResetTime ( A21InvoiceDate ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Invoice Date is out of range", "OutOfRange", 1, "INVOICEDATE");
            AnyError = 1;
            GX_FocusControl = edtInvoiceDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00067 */
         pr_default.execute(5, new Object[] {A12EmployeeId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No matching 'Employee'.", "ForeignKeyNotFound", 1, "EMPLOYEEID");
            AnyError = 1;
            GX_FocusControl = edtEmployeeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A14EmployeeLastName = T00067_A14EmployeeLastName[0];
         AssignAttri("", false, "A14EmployeeLastName", A14EmployeeLastName);
         A13EmployeeFirstName = T00067_A13EmployeeFirstName[0];
         AssignAttri("", false, "A13EmployeeFirstName", A13EmployeeFirstName);
         pr_default.close(5);
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
         pr_default.close(6);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_15( int A20InvoiceId )
      {
         /* Using cursor T000613 */
         pr_default.execute(8, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            A68InvoiceProductQuantity = T000613_A68InvoiceProductQuantity[0];
            n68InvoiceProductQuantity = T000613_n68InvoiceProductQuantity[0];
            AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
         }
         else
         {
            A68InvoiceProductQuantity = 0;
            n68InvoiceProductQuantity = false;
            AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A68InvoiceProductQuantity), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void gxLoad_14( int A12EmployeeId )
      {
         /* Using cursor T000614 */
         pr_default.execute(9, new Object[] {A12EmployeeId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No matching 'Employee'.", "ForeignKeyNotFound", 1, "EMPLOYEEID");
            AnyError = 1;
            GX_FocusControl = edtEmployeeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A14EmployeeLastName = T000614_A14EmployeeLastName[0];
         AssignAttri("", false, "A14EmployeeLastName", A14EmployeeLastName);
         A13EmployeeFirstName = T000614_A13EmployeeFirstName[0];
         AssignAttri("", false, "A13EmployeeFirstName", A13EmployeeFirstName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A14EmployeeLastName)+"\""+","+"\""+GXUtil.EncodeJSConstant( A13EmployeeFirstName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void GetKey066( )
      {
         /* Using cursor T000615 */
         pr_default.execute(10, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound6 = 1;
         }
         else
         {
            RcdFound6 = 0;
         }
         pr_default.close(10);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00066 */
         pr_default.execute(4, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM066( 13) ;
            RcdFound6 = 1;
            A20InvoiceId = T00066_A20InvoiceId[0];
            AssignAttri("", false, "A20InvoiceId", StringUtil.LTrimStr( (decimal)(A20InvoiceId), 6, 0));
            A21InvoiceDate = T00066_A21InvoiceDate[0];
            AssignAttri("", false, "A21InvoiceDate", context.localUtil.Format(A21InvoiceDate, "99/99/99"));
            A38InvoiceCreatedDate = T00066_A38InvoiceCreatedDate[0];
            AssignAttri("", false, "A38InvoiceCreatedDate", context.localUtil.Format(A38InvoiceCreatedDate, "99/99/99"));
            A39InvoiceModifiedDate = T00066_A39InvoiceModifiedDate[0];
            n39InvoiceModifiedDate = T00066_n39InvoiceModifiedDate[0];
            AssignAttri("", false, "A39InvoiceModifiedDate", context.localUtil.Format(A39InvoiceModifiedDate, "99/99/99"));
            A12EmployeeId = T00066_A12EmployeeId[0];
            AssignAttri("", false, "A12EmployeeId", StringUtil.LTrimStr( (decimal)(A12EmployeeId), 6, 0));
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
         pr_default.close(4);
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
         /* Using cursor T000616 */
         pr_default.execute(11, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T000616_A20InvoiceId[0] < A20InvoiceId ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T000616_A20InvoiceId[0] > A20InvoiceId ) ) )
            {
               A20InvoiceId = T000616_A20InvoiceId[0];
               AssignAttri("", false, "A20InvoiceId", StringUtil.LTrimStr( (decimal)(A20InvoiceId), 6, 0));
               RcdFound6 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void move_previous( )
      {
         RcdFound6 = 0;
         /* Using cursor T000617 */
         pr_default.execute(12, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            while ( (pr_default.getStatus(12) != 101) && ( ( T000617_A20InvoiceId[0] > A20InvoiceId ) ) )
            {
               pr_default.readNext(12);
            }
            if ( (pr_default.getStatus(12) != 101) && ( ( T000617_A20InvoiceId[0] < A20InvoiceId ) ) )
            {
               A20InvoiceId = T000617_A20InvoiceId[0];
               AssignAttri("", false, "A20InvoiceId", StringUtil.LTrimStr( (decimal)(A20InvoiceId), 6, 0));
               RcdFound6 = 1;
            }
         }
         pr_default.close(12);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey066( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A68InvoiceProductQuantity = O68InvoiceProductQuantity;
            n68InvoiceProductQuantity = false;
            AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
            GX_FocusControl = edtInvoiceDate_Internalname;
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
                  A68InvoiceProductQuantity = O68InvoiceProductQuantity;
                  n68InvoiceProductQuantity = false;
                  AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtInvoiceDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  A68InvoiceProductQuantity = O68InvoiceProductQuantity;
                  n68InvoiceProductQuantity = false;
                  AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
                  Update066( ) ;
                  GX_FocusControl = edtInvoiceDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A20InvoiceId != Z20InvoiceId )
               {
                  /* Insert record */
                  A68InvoiceProductQuantity = O68InvoiceProductQuantity;
                  n68InvoiceProductQuantity = false;
                  AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
                  GX_FocusControl = edtInvoiceDate_Internalname;
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
                     A68InvoiceProductQuantity = O68InvoiceProductQuantity;
                     n68InvoiceProductQuantity = false;
                     AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
                     GX_FocusControl = edtInvoiceDate_Internalname;
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
            A68InvoiceProductQuantity = O68InvoiceProductQuantity;
            n68InvoiceProductQuantity = false;
            AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtInvoiceDate_Internalname;
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
            /* Using cursor T00065 */
            pr_default.execute(3, new Object[] {A20InvoiceId});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Invoice"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(3) == 101) || ( DateTimeUtil.ResetTime ( Z21InvoiceDate ) != DateTimeUtil.ResetTime ( T00065_A21InvoiceDate[0] ) ) || ( DateTimeUtil.ResetTime ( Z38InvoiceCreatedDate ) != DateTimeUtil.ResetTime ( T00065_A38InvoiceCreatedDate[0] ) ) || ( DateTimeUtil.ResetTime ( Z39InvoiceModifiedDate ) != DateTimeUtil.ResetTime ( T00065_A39InvoiceModifiedDate[0] ) ) || ( Z12EmployeeId != T00065_A12EmployeeId[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z21InvoiceDate ) != DateTimeUtil.ResetTime ( T00065_A21InvoiceDate[0] ) )
               {
                  GXUtil.WriteLog("invoice:[seudo value changed for attri]"+"InvoiceDate");
                  GXUtil.WriteLogRaw("Old: ",Z21InvoiceDate);
                  GXUtil.WriteLogRaw("Current: ",T00065_A21InvoiceDate[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z38InvoiceCreatedDate ) != DateTimeUtil.ResetTime ( T00065_A38InvoiceCreatedDate[0] ) )
               {
                  GXUtil.WriteLog("invoice:[seudo value changed for attri]"+"InvoiceCreatedDate");
                  GXUtil.WriteLogRaw("Old: ",Z38InvoiceCreatedDate);
                  GXUtil.WriteLogRaw("Current: ",T00065_A38InvoiceCreatedDate[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z39InvoiceModifiedDate ) != DateTimeUtil.ResetTime ( T00065_A39InvoiceModifiedDate[0] ) )
               {
                  GXUtil.WriteLog("invoice:[seudo value changed for attri]"+"InvoiceModifiedDate");
                  GXUtil.WriteLogRaw("Old: ",Z39InvoiceModifiedDate);
                  GXUtil.WriteLogRaw("Current: ",T00065_A39InvoiceModifiedDate[0]);
               }
               if ( Z12EmployeeId != T00065_A12EmployeeId[0] )
               {
                  GXUtil.WriteLog("invoice:[seudo value changed for attri]"+"EmployeeId");
                  GXUtil.WriteLogRaw("Old: ",Z12EmployeeId);
                  GXUtil.WriteLogRaw("Current: ",T00065_A12EmployeeId[0]);
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
                     /* Using cursor T000618 */
                     pr_default.execute(13, new Object[] {A21InvoiceDate, A38InvoiceCreatedDate, n39InvoiceModifiedDate, A39InvoiceModifiedDate, A12EmployeeId});
                     A20InvoiceId = T000618_A20InvoiceId[0];
                     AssignAttri("", false, "A20InvoiceId", StringUtil.LTrimStr( (decimal)(A20InvoiceId), 6, 0));
                     pr_default.close(13);
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
                     /* Using cursor T000619 */
                     pr_default.execute(14, new Object[] {A21InvoiceDate, A38InvoiceCreatedDate, n39InvoiceModifiedDate, A39InvoiceModifiedDate, A12EmployeeId, A20InvoiceId});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("Invoice");
                     if ( (pr_default.getStatus(14) == 103) )
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
                  A68InvoiceProductQuantity = O68InvoiceProductQuantity;
                  n68InvoiceProductQuantity = false;
                  AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
                  ScanStart0613( ) ;
                  while ( RcdFound13 != 0 )
                  {
                     getByPrimaryKey0613( ) ;
                     Delete0613( ) ;
                     ScanNext0613( ) ;
                     O68InvoiceProductQuantity = A68InvoiceProductQuantity;
                     n68InvoiceProductQuantity = false;
                     AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
                  }
                  ScanEnd0613( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000620 */
                     pr_default.execute(15, new Object[] {A20InvoiceId});
                     pr_default.close(15);
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
            AV15Pgmname = "Invoice";
            AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
            /* Using cursor T000622 */
            pr_default.execute(16, new Object[] {A20InvoiceId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               A68InvoiceProductQuantity = T000622_A68InvoiceProductQuantity[0];
               n68InvoiceProductQuantity = T000622_n68InvoiceProductQuantity[0];
               AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
            }
            else
            {
               A68InvoiceProductQuantity = 0;
               n68InvoiceProductQuantity = false;
               AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
            }
            pr_default.close(16);
            /* Using cursor T000623 */
            pr_default.execute(17, new Object[] {A12EmployeeId});
            A14EmployeeLastName = T000623_A14EmployeeLastName[0];
            AssignAttri("", false, "A14EmployeeLastName", A14EmployeeLastName);
            A13EmployeeFirstName = T000623_A13EmployeeFirstName[0];
            AssignAttri("", false, "A13EmployeeFirstName", A13EmployeeFirstName);
            pr_default.close(17);
         }
      }

      protected void ProcessNestedLevel0613( )
      {
         s68InvoiceProductQuantity = O68InvoiceProductQuantity;
         n68InvoiceProductQuantity = false;
         AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
         nGXsfl_78_idx = 0;
         while ( nGXsfl_78_idx < nRC_GXsfl_78 )
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
                        GXCCtl = "INVOICEDETAILID_" + sGXsfl_78_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtInvoiceDetailId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
               O68InvoiceProductQuantity = A68InvoiceProductQuantity;
               n68InvoiceProductQuantity = false;
               AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
            }
            ChangePostValue( edtInvoiceDetailId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A25InvoiceDetailId), 6, 0, ".", ""))) ;
            ChangePostValue( edtInvoiceDetailQuantity_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A26InvoiceDetailQuantity), 6, 0, ".", ""))) ;
            ChangePostValue( edtInvoiceDetailHistoricPrice_Internalname, StringUtil.LTrim( StringUtil.NToC( A65InvoiceDetailHistoricPrice, 10, 2, ".", ""))) ;
            ChangePostValue( edtProductId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", ""))) ;
            ChangePostValue( edtProductName_Internalname, A16ProductName) ;
            ChangePostValue( "ZT_"+"Z25InvoiceDetailId_"+sGXsfl_78_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z25InvoiceDetailId), 6, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z26InvoiceDetailQuantity_"+sGXsfl_78_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z26InvoiceDetailQuantity), 6, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z65InvoiceDetailHistoricPrice_"+sGXsfl_78_idx, StringUtil.LTrim( StringUtil.NToC( Z65InvoiceDetailHistoricPrice, 10, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z15ProductId_"+sGXsfl_78_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z15ProductId), 6, 0, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_13_"+sGXsfl_78_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_13), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_13_"+sGXsfl_78_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_13), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_13_"+sGXsfl_78_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_13), 4, 0, ".", ""))) ;
            if ( nIsMod_13 != 0 )
            {
               ChangePostValue( "INVOICEDETAILID_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvoiceDetailId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVOICEDETAILQUANTITY_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvoiceDetailQuantity_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "INVOICEDETAILHISTORICPRICE_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvoiceDetailHistoricPrice_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTID_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTNAME_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductName_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0613( ) ;
         if ( AnyError != 0 )
         {
            O68InvoiceProductQuantity = s68InvoiceProductQuantity;
            n68InvoiceProductQuantity = false;
            AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
         }
         nRcdExists_13 = 0;
         nIsMod_13 = 0;
         nRcdDeleted_13 = 0;
      }

      protected void ProcessLevel066( )
      {
         /* Save parent mode. */
         sMode6 = Gx_mode;
         ProcessNestedLevel0613( ) ;
         if ( AnyError != 0 )
         {
            O68InvoiceProductQuantity = s68InvoiceProductQuantity;
            n68InvoiceProductQuantity = false;
            AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
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
            pr_default.close(3);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete066( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(17);
            pr_default.close(16);
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
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(17);
            pr_default.close(16);
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
         /* Using cursor T000624 */
         pr_default.execute(18);
         RcdFound6 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound6 = 1;
            A20InvoiceId = T000624_A20InvoiceId[0];
            AssignAttri("", false, "A20InvoiceId", StringUtil.LTrimStr( (decimal)(A20InvoiceId), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext066( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound6 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound6 = 1;
            A20InvoiceId = T000624_A20InvoiceId[0];
            AssignAttri("", false, "A20InvoiceId", StringUtil.LTrimStr( (decimal)(A20InvoiceId), 6, 0));
         }
      }

      protected void ScanEnd066( )
      {
         pr_default.close(18);
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
         edtInvoiceDate_Enabled = 0;
         AssignProp("", false, edtInvoiceDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceDate_Enabled), 5, 0), true);
         edtEmployeeId_Enabled = 0;
         AssignProp("", false, edtEmployeeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeId_Enabled), 5, 0), true);
         edtEmployeeLastName_Enabled = 0;
         AssignProp("", false, edtEmployeeLastName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeLastName_Enabled), 5, 0), true);
         edtEmployeeFirstName_Enabled = 0;
         AssignProp("", false, edtEmployeeFirstName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmployeeFirstName_Enabled), 5, 0), true);
         edtInvoiceCreatedDate_Enabled = 0;
         AssignProp("", false, edtInvoiceCreatedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceCreatedDate_Enabled), 5, 0), true);
         edtInvoiceModifiedDate_Enabled = 0;
         AssignProp("", false, edtInvoiceModifiedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceModifiedDate_Enabled), 5, 0), true);
         edtInvoiceProductQuantity_Enabled = 0;
         AssignProp("", false, edtInvoiceProductQuantity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceProductQuantity_Enabled), 5, 0), true);
      }

      protected void ZM0613( short GX_JID )
      {
         if ( ( GX_JID == 16 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z26InvoiceDetailQuantity = T00063_A26InvoiceDetailQuantity[0];
               Z65InvoiceDetailHistoricPrice = T00063_A65InvoiceDetailHistoricPrice[0];
               Z15ProductId = T00063_A15ProductId[0];
            }
            else
            {
               Z26InvoiceDetailQuantity = A26InvoiceDetailQuantity;
               Z65InvoiceDetailHistoricPrice = A65InvoiceDetailHistoricPrice;
               Z15ProductId = A15ProductId;
            }
         }
         if ( GX_JID == -16 )
         {
            Z20InvoiceId = A20InvoiceId;
            Z25InvoiceDetailId = A25InvoiceDetailId;
            Z26InvoiceDetailQuantity = A26InvoiceDetailQuantity;
            Z65InvoiceDetailHistoricPrice = A65InvoiceDetailHistoricPrice;
            Z15ProductId = A15ProductId;
            Z16ProductName = A16ProductName;
         }
      }

      protected void standaloneNotModal0613( )
      {
      }

      protected void standaloneModal0613( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtInvoiceDetailId_Enabled = 0;
            AssignProp("", false, edtInvoiceDetailId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceDetailId_Enabled), 5, 0), !bGXsfl_78_Refreshing);
         }
         else
         {
            edtInvoiceDetailId_Enabled = 1;
            AssignProp("", false, edtInvoiceDetailId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceDetailId_Enabled), 5, 0), !bGXsfl_78_Refreshing);
         }
      }

      protected void Load0613( )
      {
         /* Using cursor T000625 */
         pr_default.execute(19, new Object[] {A20InvoiceId, A25InvoiceDetailId});
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound13 = 1;
            A26InvoiceDetailQuantity = T000625_A26InvoiceDetailQuantity[0];
            A65InvoiceDetailHistoricPrice = T000625_A65InvoiceDetailHistoricPrice[0];
            A16ProductName = T000625_A16ProductName[0];
            A15ProductId = T000625_A15ProductId[0];
            ZM0613( -16) ;
         }
         pr_default.close(19);
         OnLoadActions0613( ) ;
      }

      protected void OnLoadActions0613( )
      {
         if ( IsIns( )  )
         {
            A68InvoiceProductQuantity = (short)(O68InvoiceProductQuantity+1);
            n68InvoiceProductQuantity = false;
            AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
         }
         else
         {
            if ( IsUpd( )  )
            {
               A68InvoiceProductQuantity = O68InvoiceProductQuantity;
               n68InvoiceProductQuantity = false;
               AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
            }
            else
            {
               if ( IsDlt( )  )
               {
                  A68InvoiceProductQuantity = (short)(O68InvoiceProductQuantity-1);
                  n68InvoiceProductQuantity = false;
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
            n68InvoiceProductQuantity = false;
            AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
         }
         else
         {
            if ( IsUpd( )  )
            {
               nIsDirty_13 = 1;
               A68InvoiceProductQuantity = O68InvoiceProductQuantity;
               n68InvoiceProductQuantity = false;
               AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
            }
            else
            {
               if ( IsDlt( )  )
               {
                  nIsDirty_13 = 1;
                  A68InvoiceProductQuantity = (short)(O68InvoiceProductQuantity-1);
                  n68InvoiceProductQuantity = false;
                  AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
               }
            }
         }
         /* Using cursor T00064 */
         pr_default.execute(2, new Object[] {A15ProductId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "PRODUCTID_" + sGXsfl_78_idx;
            GX_msglist.addItem("No matching 'Product'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProductId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A16ProductName = T00064_A16ProductName[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0613( )
      {
         pr_default.close(2);
      }

      protected void enableDisable0613( )
      {
      }

      protected void gxLoad_17( int A15ProductId )
      {
         /* Using cursor T000626 */
         pr_default.execute(20, new Object[] {A15ProductId});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GXCCtl = "PRODUCTID_" + sGXsfl_78_idx;
            GX_msglist.addItem("No matching 'Product'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProductId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A16ProductName = T000626_A16ProductName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A16ProductName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(20) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(20);
      }

      protected void GetKey0613( )
      {
         /* Using cursor T000627 */
         pr_default.execute(21, new Object[] {A20InvoiceId, A25InvoiceDetailId});
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound13 = 1;
         }
         else
         {
            RcdFound13 = 0;
         }
         pr_default.close(21);
      }

      protected void getByPrimaryKey0613( )
      {
         /* Using cursor T00063 */
         pr_default.execute(1, new Object[] {A20InvoiceId, A25InvoiceDetailId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0613( 16) ;
            RcdFound13 = 1;
            InitializeNonKey0613( ) ;
            A25InvoiceDetailId = T00063_A25InvoiceDetailId[0];
            A26InvoiceDetailQuantity = T00063_A26InvoiceDetailQuantity[0];
            A65InvoiceDetailHistoricPrice = T00063_A65InvoiceDetailHistoricPrice[0];
            A15ProductId = T00063_A15ProductId[0];
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
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0613( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00062 */
            pr_default.execute(0, new Object[] {A20InvoiceId, A25InvoiceDetailId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"InvoiceDetail"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z26InvoiceDetailQuantity != T00062_A26InvoiceDetailQuantity[0] ) || ( Z65InvoiceDetailHistoricPrice != T00062_A65InvoiceDetailHistoricPrice[0] ) || ( Z15ProductId != T00062_A15ProductId[0] ) )
            {
               if ( Z26InvoiceDetailQuantity != T00062_A26InvoiceDetailQuantity[0] )
               {
                  GXUtil.WriteLog("invoice:[seudo value changed for attri]"+"InvoiceDetailQuantity");
                  GXUtil.WriteLogRaw("Old: ",Z26InvoiceDetailQuantity);
                  GXUtil.WriteLogRaw("Current: ",T00062_A26InvoiceDetailQuantity[0]);
               }
               if ( Z65InvoiceDetailHistoricPrice != T00062_A65InvoiceDetailHistoricPrice[0] )
               {
                  GXUtil.WriteLog("invoice:[seudo value changed for attri]"+"InvoiceDetailHistoricPrice");
                  GXUtil.WriteLogRaw("Old: ",Z65InvoiceDetailHistoricPrice);
                  GXUtil.WriteLogRaw("Current: ",T00062_A65InvoiceDetailHistoricPrice[0]);
               }
               if ( Z15ProductId != T00062_A15ProductId[0] )
               {
                  GXUtil.WriteLog("invoice:[seudo value changed for attri]"+"ProductId");
                  GXUtil.WriteLogRaw("Old: ",Z15ProductId);
                  GXUtil.WriteLogRaw("Current: ",T00062_A15ProductId[0]);
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
                     /* Using cursor T000628 */
                     pr_default.execute(22, new Object[] {A20InvoiceId, A25InvoiceDetailId, A26InvoiceDetailQuantity, A65InvoiceDetailHistoricPrice, A15ProductId});
                     pr_default.close(22);
                     pr_default.SmartCacheProvider.SetUpdated("InvoiceDetail");
                     if ( (pr_default.getStatus(22) == 1) )
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
                        /* Using cursor T000629 */
                        pr_default.execute(23, new Object[] {A26InvoiceDetailQuantity, A65InvoiceDetailHistoricPrice, A15ProductId, A20InvoiceId, A25InvoiceDetailId});
                        pr_default.close(23);
                        pr_default.SmartCacheProvider.SetUpdated("InvoiceDetail");
                        if ( (pr_default.getStatus(23) == 103) )
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
                  /* Using cursor T000630 */
                  pr_default.execute(24, new Object[] {A20InvoiceId, A25InvoiceDetailId});
                  pr_default.close(24);
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
               n68InvoiceProductQuantity = false;
               AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
            }
            else
            {
               if ( IsUpd( )  )
               {
                  A68InvoiceProductQuantity = O68InvoiceProductQuantity;
                  n68InvoiceProductQuantity = false;
                  AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
               }
               else
               {
                  if ( IsDlt( )  )
                  {
                     A68InvoiceProductQuantity = (short)(O68InvoiceProductQuantity-1);
                     n68InvoiceProductQuantity = false;
                     AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
                  }
               }
            }
            /* Using cursor T000631 */
            pr_default.execute(25, new Object[] {A15ProductId});
            A16ProductName = T000631_A16ProductName[0];
            pr_default.close(25);
         }
      }

      protected void EndLevel0613( )
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

      public void ScanStart0613( )
      {
         /* Scan By routine */
         /* Using cursor T000632 */
         pr_default.execute(26, new Object[] {A20InvoiceId});
         RcdFound13 = 0;
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound13 = 1;
            A25InvoiceDetailId = T000632_A25InvoiceDetailId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0613( )
      {
         /* Scan next routine */
         pr_default.readNext(26);
         RcdFound13 = 0;
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound13 = 1;
            A25InvoiceDetailId = T000632_A25InvoiceDetailId[0];
         }
      }

      protected void ScanEnd0613( )
      {
         pr_default.close(26);
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
         AssignProp("", false, edtInvoiceDetailId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceDetailId_Enabled), 5, 0), !bGXsfl_78_Refreshing);
         edtInvoiceDetailQuantity_Enabled = 0;
         AssignProp("", false, edtInvoiceDetailQuantity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceDetailQuantity_Enabled), 5, 0), !bGXsfl_78_Refreshing);
         edtInvoiceDetailHistoricPrice_Enabled = 0;
         AssignProp("", false, edtInvoiceDetailHistoricPrice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceDetailHistoricPrice_Enabled), 5, 0), !bGXsfl_78_Refreshing);
         edtProductId_Enabled = 0;
         AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), !bGXsfl_78_Refreshing);
         edtProductName_Enabled = 0;
         AssignProp("", false, edtProductName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductName_Enabled), 5, 0), !bGXsfl_78_Refreshing);
      }

      protected void send_integrity_lvl_hashes0613( )
      {
      }

      protected void send_integrity_lvl_hashes066( )
      {
      }

      protected void SubsflControlProps_7813( )
      {
         edtInvoiceDetailId_Internalname = "INVOICEDETAILID_"+sGXsfl_78_idx;
         edtInvoiceDetailQuantity_Internalname = "INVOICEDETAILQUANTITY_"+sGXsfl_78_idx;
         edtInvoiceDetailHistoricPrice_Internalname = "INVOICEDETAILHISTORICPRICE_"+sGXsfl_78_idx;
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_78_idx;
         imgprompt_15_Internalname = "PROMPT_15_"+sGXsfl_78_idx;
         edtProductName_Internalname = "PRODUCTNAME_"+sGXsfl_78_idx;
      }

      protected void SubsflControlProps_fel_7813( )
      {
         edtInvoiceDetailId_Internalname = "INVOICEDETAILID_"+sGXsfl_78_fel_idx;
         edtInvoiceDetailQuantity_Internalname = "INVOICEDETAILQUANTITY_"+sGXsfl_78_fel_idx;
         edtInvoiceDetailHistoricPrice_Internalname = "INVOICEDETAILHISTORICPRICE_"+sGXsfl_78_fel_idx;
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_78_fel_idx;
         imgprompt_15_Internalname = "PROMPT_15_"+sGXsfl_78_fel_idx;
         edtProductName_Internalname = "PRODUCTNAME_"+sGXsfl_78_fel_idx;
      }

      protected void AddRow0613( )
      {
         nGXsfl_78_idx = (int)(nGXsfl_78_idx+1);
         sGXsfl_78_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_78_idx), 4, 0), 4, "0");
         SubsflControlProps_7813( ) ;
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
            if ( ((int)((nGXsfl_78_idx) % (2))) == 0 )
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
         imgprompt_15_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0050.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PRODUCTID_"+sGXsfl_78_idx+"'), id:'"+"PRODUCTID_"+sGXsfl_78_idx+"'"+",IOType:'out'}"+"],"+"gx.dom.form()."+"nIsMod_13_"+sGXsfl_78_idx+","+"'', false"+","+"false"+");");
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_13_" + sGXsfl_78_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 79,'',false,'" + sGXsfl_78_idx + "',78)\"";
         ROClassString = "Attribute";
         Gridinvoice_detailRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInvoiceDetailId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A25InvoiceDetailId), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A25InvoiceDetailId), "ZZZZZ9"))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,79);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInvoiceDetailId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtInvoiceDetailId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)78,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_13_" + sGXsfl_78_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 80,'',false,'" + sGXsfl_78_idx + "',78)\"";
         ROClassString = "Attribute";
         Gridinvoice_detailRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInvoiceDetailQuantity_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A26InvoiceDetailQuantity), 6, 0, ".", "")),StringUtil.LTrim( ((edtInvoiceDetailQuantity_Enabled!=0) ? context.localUtil.Format( (decimal)(A26InvoiceDetailQuantity), "ZZZZZ9") : context.localUtil.Format( (decimal)(A26InvoiceDetailQuantity), "ZZZZZ9")))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,80);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInvoiceDetailQuantity_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtInvoiceDetailQuantity_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)78,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_13_" + sGXsfl_78_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 81,'',false,'" + sGXsfl_78_idx + "',78)\"";
         ROClassString = "Attribute";
         Gridinvoice_detailRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtInvoiceDetailHistoricPrice_Internalname,StringUtil.LTrim( StringUtil.NToC( A65InvoiceDetailHistoricPrice, 10, 2, ".", "")),StringUtil.LTrim( ((edtInvoiceDetailHistoricPrice_Enabled!=0) ? context.localUtil.Format( A65InvoiceDetailHistoricPrice, "ZZZZZZ9.99") : context.localUtil.Format( A65InvoiceDetailHistoricPrice, "ZZZZZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,81);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtInvoiceDetailHistoricPrice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtInvoiceDetailHistoricPrice_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)78,(short)0,(short)-1,(short)0,(bool)true,(string)"Price",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_13_" + sGXsfl_78_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 82,'',false,'" + sGXsfl_78_idx + "',78)\"";
         ROClassString = "Attribute";
         Gridinvoice_detailRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", "")),StringUtil.LTrim( ((edtProductId_Enabled!=0) ? context.localUtil.Format( (decimal)(A15ProductId), "ZZZZZ9") : context.localUtil.Format( (decimal)(A15ProductId), "ZZZZZ9")))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,82);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProductId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)78,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_15_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_15_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         Gridinvoice_detailRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_15_Internalname,(string)sImgUrl,(string)imgprompt_15_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_15_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridinvoice_detailRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductName_Internalname,(string)A16ProductName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProductName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)78,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
         ajax_sending_grid_row(Gridinvoice_detailRow);
         send_integrity_lvl_hashes0613( ) ;
         GXCCtl = "Z25InvoiceDetailId_" + sGXsfl_78_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z25InvoiceDetailId), 6, 0, ".", "")));
         GXCCtl = "Z26InvoiceDetailQuantity_" + sGXsfl_78_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z26InvoiceDetailQuantity), 6, 0, ".", "")));
         GXCCtl = "Z65InvoiceDetailHistoricPrice_" + sGXsfl_78_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z65InvoiceDetailHistoricPrice, 10, 2, ".", "")));
         GXCCtl = "Z15ProductId_" + sGXsfl_78_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z15ProductId), 6, 0, ".", "")));
         GXCCtl = "nRcdDeleted_13_" + sGXsfl_78_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_13), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_13_" + sGXsfl_78_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_13), 4, 0, ".", "")));
         GXCCtl = "nIsMod_13_" + sGXsfl_78_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_13), 4, 0, ".", "")));
         GXCCtl = "vMODE_" + sGXsfl_78_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_78_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV9TrnContext);
         }
         GXCCtl = "vINVOICEID_" + sGXsfl_78_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7InvoiceId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "INVOICEDETAILID_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvoiceDetailId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "INVOICEDETAILQUANTITY_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvoiceDetailQuantity_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "INVOICEDETAILHISTORICPRICE_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvoiceDetailHistoricPrice_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTID_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTNAME_"+sGXsfl_78_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_15_"+sGXsfl_78_idx+"Link", StringUtil.RTrim( imgprompt_15_Link));
         ajax_sending_grid_row(null);
         Gridinvoice_detailContainer.AddRow(Gridinvoice_detailRow);
      }

      protected void ReadRow0613( )
      {
         nGXsfl_78_idx = (int)(nGXsfl_78_idx+1);
         sGXsfl_78_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_78_idx), 4, 0), 4, "0");
         SubsflControlProps_7813( ) ;
         edtInvoiceDetailId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVOICEDETAILID_"+sGXsfl_78_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtInvoiceDetailQuantity_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVOICEDETAILQUANTITY_"+sGXsfl_78_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtInvoiceDetailHistoricPrice_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "INVOICEDETAILHISTORICPRICE_"+sGXsfl_78_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtProductId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTID_"+sGXsfl_78_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtProductName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTNAME_"+sGXsfl_78_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         imgprompt_12_Link = cgiGet( "PROMPT_15_"+sGXsfl_78_idx+"Link");
         if ( ( ( context.localUtil.CToN( cgiGet( edtInvoiceDetailId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtInvoiceDetailId_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
         {
            GXCCtl = "INVOICEDETAILID_" + sGXsfl_78_idx;
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
         if ( ( ( context.localUtil.CToN( cgiGet( edtInvoiceDetailQuantity_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtInvoiceDetailQuantity_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
         {
            GXCCtl = "INVOICEDETAILQUANTITY_" + sGXsfl_78_idx;
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
         if ( ( ( context.localUtil.CToN( cgiGet( edtInvoiceDetailHistoricPrice_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtInvoiceDetailHistoricPrice_Internalname), ".", ",") > 9999999.99m ) ) )
         {
            GXCCtl = "INVOICEDETAILHISTORICPRICE_" + sGXsfl_78_idx;
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
         if ( ( ( context.localUtil.CToN( cgiGet( edtProductId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProductId_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
         {
            GXCCtl = "PRODUCTID_" + sGXsfl_78_idx;
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
         GXCCtl = "Z25InvoiceDetailId_" + sGXsfl_78_idx;
         Z25InvoiceDetailId = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "Z26InvoiceDetailQuantity_" + sGXsfl_78_idx;
         Z26InvoiceDetailQuantity = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "Z65InvoiceDetailHistoricPrice_" + sGXsfl_78_idx;
         Z65InvoiceDetailHistoricPrice = context.localUtil.CToN( cgiGet( GXCCtl), ".", ",");
         GXCCtl = "Z15ProductId_" + sGXsfl_78_idx;
         Z15ProductId = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdDeleted_13_" + sGXsfl_78_idx;
         nRcdDeleted_13 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_13_" + sGXsfl_78_idx;
         nRcdExists_13 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_13_" + sGXsfl_78_idx;
         nIsMod_13 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtInvoiceDetailId_Enabled = edtInvoiceDetailId_Enabled;
      }

      protected void ConfirmValues060( )
      {
         nGXsfl_78_idx = 0;
         sGXsfl_78_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_78_idx), 4, 0), 4, "0");
         SubsflControlProps_7813( ) ;
         while ( nGXsfl_78_idx < nRC_GXsfl_78 )
         {
            nGXsfl_78_idx = (int)(nGXsfl_78_idx+1);
            sGXsfl_78_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_78_idx), 4, 0), 4, "0");
            SubsflControlProps_7813( ) ;
            ChangePostValue( "Z25InvoiceDetailId_"+sGXsfl_78_idx, cgiGet( "ZT_"+"Z25InvoiceDetailId_"+sGXsfl_78_idx)) ;
            DeletePostValue( "ZT_"+"Z25InvoiceDetailId_"+sGXsfl_78_idx) ;
            ChangePostValue( "Z26InvoiceDetailQuantity_"+sGXsfl_78_idx, cgiGet( "ZT_"+"Z26InvoiceDetailQuantity_"+sGXsfl_78_idx)) ;
            DeletePostValue( "ZT_"+"Z26InvoiceDetailQuantity_"+sGXsfl_78_idx) ;
            ChangePostValue( "Z65InvoiceDetailHistoricPrice_"+sGXsfl_78_idx, cgiGet( "ZT_"+"Z65InvoiceDetailHistoricPrice_"+sGXsfl_78_idx)) ;
            DeletePostValue( "ZT_"+"Z65InvoiceDetailHistoricPrice_"+sGXsfl_78_idx) ;
            ChangePostValue( "Z15ProductId_"+sGXsfl_78_idx, cgiGet( "ZT_"+"Z15ProductId_"+sGXsfl_78_idx)) ;
            DeletePostValue( "ZT_"+"Z15ProductId_"+sGXsfl_78_idx) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("invoice.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7InvoiceId,6,0))}, new string[] {"Gx_mode","InvoiceId"}) +"\">") ;
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
         forbiddenHiddens.Add("InvoiceCreatedDate", context.localUtil.Format(A38InvoiceCreatedDate, "99/99/99"));
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
         GxWebStd.gx_hidden_field( context, "Z21InvoiceDate", context.localUtil.DToC( Z21InvoiceDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z38InvoiceCreatedDate", context.localUtil.DToC( Z38InvoiceCreatedDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z39InvoiceModifiedDate", context.localUtil.DToC( Z39InvoiceModifiedDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z12EmployeeId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z12EmployeeId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "O68InvoiceProductQuantity", StringUtil.LTrim( StringUtil.NToC( (decimal)(O68InvoiceProductQuantity), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_78", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_78_idx), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N12EmployeeId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A12EmployeeId), 6, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "vINVOICEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7InvoiceId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vINVOICEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7InvoiceId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_EMPLOYEEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_EmployeeId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV15Pgmname));
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
         return formatLink("invoice.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7InvoiceId,6,0))}, new string[] {"Gx_mode","InvoiceId"})  ;
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
         A12EmployeeId = 0;
         AssignAttri("", false, "A12EmployeeId", StringUtil.LTrimStr( (decimal)(A12EmployeeId), 6, 0));
         A21InvoiceDate = DateTime.MinValue;
         AssignAttri("", false, "A21InvoiceDate", context.localUtil.Format(A21InvoiceDate, "99/99/99"));
         A14EmployeeLastName = "";
         AssignAttri("", false, "A14EmployeeLastName", A14EmployeeLastName);
         A13EmployeeFirstName = "";
         AssignAttri("", false, "A13EmployeeFirstName", A13EmployeeFirstName);
         A39InvoiceModifiedDate = DateTime.MinValue;
         n39InvoiceModifiedDate = false;
         AssignAttri("", false, "A39InvoiceModifiedDate", context.localUtil.Format(A39InvoiceModifiedDate, "99/99/99"));
         n39InvoiceModifiedDate = ((DateTime.MinValue==A39InvoiceModifiedDate) ? true : false);
         A68InvoiceProductQuantity = 0;
         n68InvoiceProductQuantity = false;
         AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
         A38InvoiceCreatedDate = Gx_date;
         AssignAttri("", false, "A38InvoiceCreatedDate", context.localUtil.Format(A38InvoiceCreatedDate, "99/99/99"));
         O68InvoiceProductQuantity = A68InvoiceProductQuantity;
         n68InvoiceProductQuantity = false;
         AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrimStr( (decimal)(A68InvoiceProductQuantity), 4, 0));
         Z21InvoiceDate = DateTime.MinValue;
         Z38InvoiceCreatedDate = DateTime.MinValue;
         Z39InvoiceModifiedDate = DateTime.MinValue;
         Z12EmployeeId = 0;
      }

      protected void InitAll066( )
      {
         A20InvoiceId = 0;
         AssignAttri("", false, "A20InvoiceId", StringUtil.LTrimStr( (decimal)(A20InvoiceId), 6, 0));
         InitializeNonKey066( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A38InvoiceCreatedDate = i38InvoiceCreatedDate;
         AssignAttri("", false, "A38InvoiceCreatedDate", context.localUtil.Format(A38InvoiceCreatedDate, "99/99/99"));
      }

      protected void InitializeNonKey0613( )
      {
         A26InvoiceDetailQuantity = 0;
         A65InvoiceDetailHistoricPrice = 0;
         A15ProductId = 0;
         A16ProductName = "";
         Z26InvoiceDetailQuantity = 0;
         Z65InvoiceDetailHistoricPrice = 0;
         Z15ProductId = 0;
      }

      protected void InitAll0613( )
      {
         A25InvoiceDetailId = 0;
         InitializeNonKey0613( ) ;
      }

      protected void StandaloneModalInsert0613( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202311222273838", true, true);
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
         context.AddJavascriptSource("invoice.js", "?202311222273838", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties13( )
      {
         edtInvoiceDetailId_Enabled = defedtInvoiceDetailId_Enabled;
         AssignProp("", false, edtInvoiceDetailId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceDetailId_Enabled), 5, 0), !bGXsfl_78_Refreshing);
      }

      protected void StartGridControl78( )
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
         Gridinvoice_detailColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A26InvoiceDetailQuantity), 6, 0, ".", ""))));
         Gridinvoice_detailColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvoiceDetailQuantity_Enabled), 5, 0, ".", "")));
         Gridinvoice_detailContainer.AddColumnProperties(Gridinvoice_detailColumn);
         Gridinvoice_detailColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridinvoice_detailColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A65InvoiceDetailHistoricPrice, 10, 2, ".", ""))));
         Gridinvoice_detailColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtInvoiceDetailHistoricPrice_Enabled), 5, 0, ".", "")));
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
         Gridinvoice_detailContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoice_detail_Selectedindex), 4, 0, ".", "")));
         Gridinvoice_detailContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoice_detail_Allowselection), 1, 0, ".", "")));
         Gridinvoice_detailContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoice_detail_Selectioncolor), 9, 0, ".", "")));
         Gridinvoice_detailContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoice_detail_Allowhovering), 1, 0, ".", "")));
         Gridinvoice_detailContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoice_detail_Hoveringcolor), 9, 0, ".", "")));
         Gridinvoice_detailContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoice_detail_Allowcollapsing), 1, 0, ".", "")));
         Gridinvoice_detailContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridinvoice_detail_Collapsed), 1, 0, ".", "")));
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
         edtInvoiceDate_Internalname = "INVOICEDATE";
         edtEmployeeId_Internalname = "EMPLOYEEID";
         edtEmployeeLastName_Internalname = "EMPLOYEELASTNAME";
         edtEmployeeFirstName_Internalname = "EMPLOYEEFIRSTNAME";
         edtInvoiceCreatedDate_Internalname = "INVOICECREATEDDATE";
         edtInvoiceModifiedDate_Internalname = "INVOICEMODIFIEDDATE";
         edtInvoiceProductQuantity_Internalname = "INVOICEPRODUCTQUANTITY";
         lblTitledetail_Internalname = "TITLEDETAIL";
         edtInvoiceDetailId_Internalname = "INVOICEDETAILID";
         edtInvoiceDetailQuantity_Internalname = "INVOICEDETAILQUANTITY";
         edtInvoiceDetailHistoricPrice_Internalname = "INVOICEDETAILHISTORICPRICE";
         edtProductId_Internalname = "PRODUCTID";
         edtProductName_Internalname = "PRODUCTNAME";
         divDetailtable_Internalname = "DETAILTABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_12_Internalname = "PROMPT_12";
         imgprompt_15_Internalname = "PROMPT_15";
         subGridinvoice_detail_Internalname = "GRIDINVOICE_DETAIL";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("mtaKB", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridinvoice_detail_Allowcollapsing = 0;
         subGridinvoice_detail_Allowselection = 0;
         subGridinvoice_detail_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Invoice";
         edtProductName_Jsonclick = "";
         imgprompt_15_Visible = 1;
         imgprompt_15_Link = "";
         imgprompt_12_Visible = 1;
         edtProductId_Jsonclick = "";
         edtInvoiceDetailHistoricPrice_Jsonclick = "";
         edtInvoiceDetailQuantity_Jsonclick = "";
         edtInvoiceDetailId_Jsonclick = "";
         subGridinvoice_detail_Class = "Grid";
         subGridinvoice_detail_Backcolorstyle = 0;
         edtProductName_Enabled = 0;
         edtProductId_Enabled = 1;
         edtInvoiceDetailHistoricPrice_Enabled = 1;
         edtInvoiceDetailQuantity_Enabled = 1;
         edtInvoiceDetailId_Enabled = 1;
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirm";
         bttBtn_enter_Caption = "Confirm";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtInvoiceProductQuantity_Jsonclick = "";
         edtInvoiceProductQuantity_Enabled = 0;
         edtInvoiceModifiedDate_Jsonclick = "";
         edtInvoiceModifiedDate_Enabled = 1;
         edtInvoiceCreatedDate_Jsonclick = "";
         edtInvoiceCreatedDate_Enabled = 0;
         edtEmployeeFirstName_Jsonclick = "";
         edtEmployeeFirstName_Enabled = 0;
         edtEmployeeLastName_Jsonclick = "";
         edtEmployeeLastName_Enabled = 0;
         imgprompt_12_Visible = 1;
         imgprompt_12_Link = "";
         edtEmployeeId_Jsonclick = "";
         edtEmployeeId_Enabled = 1;
         edtInvoiceDate_Jsonclick = "";
         edtInvoiceDate_Enabled = 1;
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
         SubsflControlProps_7813( ) ;
         while ( nGXsfl_78_idx <= nRC_GXsfl_78 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0613( ) ;
            standaloneModal0613( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0613( ) ;
            nGXsfl_78_idx = (int)(nGXsfl_78_idx+1);
            sGXsfl_78_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_78_idx), 4, 0), 4, "0");
            SubsflControlProps_7813( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridinvoice_detailContainer)) ;
         /* End function gxnrGridinvoice_detail_newrow */
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

      public void Valid_Invoiceid( )
      {
         n68InvoiceProductQuantity = false;
         /* Using cursor T000622 */
         pr_default.execute(16, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(16) != 101) )
         {
            A68InvoiceProductQuantity = T000622_A68InvoiceProductQuantity[0];
            n68InvoiceProductQuantity = T000622_n68InvoiceProductQuantity[0];
         }
         else
         {
            A68InvoiceProductQuantity = 0;
            n68InvoiceProductQuantity = false;
         }
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A68InvoiceProductQuantity", StringUtil.LTrim( StringUtil.NToC( (decimal)(A68InvoiceProductQuantity), 4, 0, ".", "")));
      }

      public void Valid_Employeeid( )
      {
         /* Using cursor T000623 */
         pr_default.execute(17, new Object[] {A12EmployeeId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No matching 'Employee'.", "ForeignKeyNotFound", 1, "EMPLOYEEID");
            AnyError = 1;
            GX_FocusControl = edtEmployeeId_Internalname;
         }
         A14EmployeeLastName = T000623_A14EmployeeLastName[0];
         A13EmployeeFirstName = T000623_A13EmployeeFirstName[0];
         pr_default.close(17);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A14EmployeeLastName", A14EmployeeLastName);
         AssignAttri("", false, "A13EmployeeFirstName", A13EmployeeFirstName);
      }

      public void Valid_Productid( )
      {
         /* Using cursor T000631 */
         pr_default.execute(25, new Object[] {A15ProductId});
         if ( (pr_default.getStatus(25) == 101) )
         {
            GX_msglist.addItem("No matching 'Product'.", "ForeignKeyNotFound", 1, "PRODUCTID");
            AnyError = 1;
            GX_FocusControl = edtProductId_Internalname;
         }
         A16ProductName = T000631_A16ProductName[0];
         pr_default.close(25);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A16ProductName", A16ProductName);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7InvoiceId',fld:'vINVOICEID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7InvoiceId',fld:'vINVOICEID',pic:'ZZZZZ9',hsh:true},{av:'A20InvoiceId',fld:'INVOICEID',pic:'ZZZZZ9'},{av:'A38InvoiceCreatedDate',fld:'INVOICECREATEDDATE',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12062',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_INVOICEID","{handler:'Valid_Invoiceid',iparms:[{av:'A20InvoiceId',fld:'INVOICEID',pic:'ZZZZZ9'},{av:'A68InvoiceProductQuantity',fld:'INVOICEPRODUCTQUANTITY',pic:'ZZZ9'}]");
         setEventMetadata("VALID_INVOICEID",",oparms:[{av:'A68InvoiceProductQuantity',fld:'INVOICEPRODUCTQUANTITY',pic:'ZZZ9'}]}");
         setEventMetadata("VALID_INVOICEDATE","{handler:'Valid_Invoicedate',iparms:[]");
         setEventMetadata("VALID_INVOICEDATE",",oparms:[]}");
         setEventMetadata("VALID_EMPLOYEEID","{handler:'Valid_Employeeid',iparms:[{av:'A12EmployeeId',fld:'EMPLOYEEID',pic:'ZZZZZ9'},{av:'A14EmployeeLastName',fld:'EMPLOYEELASTNAME',pic:''},{av:'A13EmployeeFirstName',fld:'EMPLOYEEFIRSTNAME',pic:''}]");
         setEventMetadata("VALID_EMPLOYEEID",",oparms:[{av:'A14EmployeeLastName',fld:'EMPLOYEELASTNAME',pic:''},{av:'A13EmployeeFirstName',fld:'EMPLOYEEFIRSTNAME',pic:''}]}");
         setEventMetadata("VALID_INVOICEMODIFIEDDATE","{handler:'Valid_Invoicemodifieddate',iparms:[]");
         setEventMetadata("VALID_INVOICEMODIFIEDDATE",",oparms:[]}");
         setEventMetadata("VALID_INVOICEDETAILID","{handler:'Valid_Invoicedetailid',iparms:[]");
         setEventMetadata("VALID_INVOICEDETAILID",",oparms:[]}");
         setEventMetadata("VALID_PRODUCTID","{handler:'Valid_Productid',iparms:[{av:'A15ProductId',fld:'PRODUCTID',pic:'ZZZZZ9'},{av:'A16ProductName',fld:'PRODUCTNAME',pic:''}]");
         setEventMetadata("VALID_PRODUCTID",",oparms:[{av:'A16ProductName',fld:'PRODUCTNAME',pic:''}]}");
         setEventMetadata("NULL","{handler:'Valid_Productname',iparms:[]");
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
         pr_default.close(25);
         pr_default.close(4);
         pr_default.close(17);
         pr_default.close(16);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z21InvoiceDate = DateTime.MinValue;
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
         A21InvoiceDate = DateTime.MinValue;
         imgprompt_12_gximage = "";
         sImgUrl = "";
         A14EmployeeLastName = "";
         A13EmployeeFirstName = "";
         A38InvoiceCreatedDate = DateTime.MinValue;
         A39InvoiceModifiedDate = DateTime.MinValue;
         lblTitledetail_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridinvoice_detailContainer = new GXWebGrid( context);
         sMode13 = "";
         sStyleString = "";
         Gx_date = DateTime.MinValue;
         AV15Pgmname = "";
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
         A16ProductName = "";
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV12TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         Z14EmployeeLastName = "";
         Z13EmployeeFirstName = "";
         T00069_A68InvoiceProductQuantity = new short[1] ;
         T00069_n68InvoiceProductQuantity = new bool[] {false} ;
         T00067_A14EmployeeLastName = new string[] {""} ;
         T00067_A13EmployeeFirstName = new string[] {""} ;
         T000611_A20InvoiceId = new int[1] ;
         T000611_A21InvoiceDate = new DateTime[] {DateTime.MinValue} ;
         T000611_A14EmployeeLastName = new string[] {""} ;
         T000611_A13EmployeeFirstName = new string[] {""} ;
         T000611_A38InvoiceCreatedDate = new DateTime[] {DateTime.MinValue} ;
         T000611_A39InvoiceModifiedDate = new DateTime[] {DateTime.MinValue} ;
         T000611_n39InvoiceModifiedDate = new bool[] {false} ;
         T000611_A12EmployeeId = new int[1] ;
         T000611_A68InvoiceProductQuantity = new short[1] ;
         T000611_n68InvoiceProductQuantity = new bool[] {false} ;
         T000613_A68InvoiceProductQuantity = new short[1] ;
         T000613_n68InvoiceProductQuantity = new bool[] {false} ;
         T000614_A14EmployeeLastName = new string[] {""} ;
         T000614_A13EmployeeFirstName = new string[] {""} ;
         T000615_A20InvoiceId = new int[1] ;
         T00066_A20InvoiceId = new int[1] ;
         T00066_A21InvoiceDate = new DateTime[] {DateTime.MinValue} ;
         T00066_A38InvoiceCreatedDate = new DateTime[] {DateTime.MinValue} ;
         T00066_A39InvoiceModifiedDate = new DateTime[] {DateTime.MinValue} ;
         T00066_n39InvoiceModifiedDate = new bool[] {false} ;
         T00066_A12EmployeeId = new int[1] ;
         T000616_A20InvoiceId = new int[1] ;
         T000617_A20InvoiceId = new int[1] ;
         T00065_A20InvoiceId = new int[1] ;
         T00065_A21InvoiceDate = new DateTime[] {DateTime.MinValue} ;
         T00065_A38InvoiceCreatedDate = new DateTime[] {DateTime.MinValue} ;
         T00065_A39InvoiceModifiedDate = new DateTime[] {DateTime.MinValue} ;
         T00065_n39InvoiceModifiedDate = new bool[] {false} ;
         T00065_A12EmployeeId = new int[1] ;
         T000618_A20InvoiceId = new int[1] ;
         T000622_A68InvoiceProductQuantity = new short[1] ;
         T000622_n68InvoiceProductQuantity = new bool[] {false} ;
         T000623_A14EmployeeLastName = new string[] {""} ;
         T000623_A13EmployeeFirstName = new string[] {""} ;
         T000624_A20InvoiceId = new int[1] ;
         Z16ProductName = "";
         T000625_A20InvoiceId = new int[1] ;
         T000625_A25InvoiceDetailId = new int[1] ;
         T000625_A26InvoiceDetailQuantity = new int[1] ;
         T000625_A65InvoiceDetailHistoricPrice = new decimal[1] ;
         T000625_A16ProductName = new string[] {""} ;
         T000625_A15ProductId = new int[1] ;
         T00064_A16ProductName = new string[] {""} ;
         T000626_A16ProductName = new string[] {""} ;
         T000627_A20InvoiceId = new int[1] ;
         T000627_A25InvoiceDetailId = new int[1] ;
         T00063_A20InvoiceId = new int[1] ;
         T00063_A25InvoiceDetailId = new int[1] ;
         T00063_A26InvoiceDetailQuantity = new int[1] ;
         T00063_A65InvoiceDetailHistoricPrice = new decimal[1] ;
         T00063_A15ProductId = new int[1] ;
         T00062_A20InvoiceId = new int[1] ;
         T00062_A25InvoiceDetailId = new int[1] ;
         T00062_A26InvoiceDetailQuantity = new int[1] ;
         T00062_A65InvoiceDetailHistoricPrice = new decimal[1] ;
         T00062_A15ProductId = new int[1] ;
         T000631_A16ProductName = new string[] {""} ;
         T000632_A20InvoiceId = new int[1] ;
         T000632_A25InvoiceDetailId = new int[1] ;
         Gridinvoice_detailRow = new GXWebRow();
         subGridinvoice_detail_Linesclass = "";
         ROClassString = "";
         imgprompt_15_gximage = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i38InvoiceCreatedDate = DateTime.MinValue;
         Gridinvoice_detailColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.invoice__default(),
            new Object[][] {
                new Object[] {
               T00062_A20InvoiceId, T00062_A25InvoiceDetailId, T00062_A26InvoiceDetailQuantity, T00062_A65InvoiceDetailHistoricPrice, T00062_A15ProductId
               }
               , new Object[] {
               T00063_A20InvoiceId, T00063_A25InvoiceDetailId, T00063_A26InvoiceDetailQuantity, T00063_A65InvoiceDetailHistoricPrice, T00063_A15ProductId
               }
               , new Object[] {
               T00064_A16ProductName
               }
               , new Object[] {
               T00065_A20InvoiceId, T00065_A21InvoiceDate, T00065_A38InvoiceCreatedDate, T00065_A39InvoiceModifiedDate, T00065_n39InvoiceModifiedDate, T00065_A12EmployeeId
               }
               , new Object[] {
               T00066_A20InvoiceId, T00066_A21InvoiceDate, T00066_A38InvoiceCreatedDate, T00066_A39InvoiceModifiedDate, T00066_n39InvoiceModifiedDate, T00066_A12EmployeeId
               }
               , new Object[] {
               T00067_A14EmployeeLastName, T00067_A13EmployeeFirstName
               }
               , new Object[] {
               T00069_A68InvoiceProductQuantity, T00069_n68InvoiceProductQuantity
               }
               , new Object[] {
               T000611_A20InvoiceId, T000611_A21InvoiceDate, T000611_A14EmployeeLastName, T000611_A13EmployeeFirstName, T000611_A38InvoiceCreatedDate, T000611_A39InvoiceModifiedDate, T000611_n39InvoiceModifiedDate, T000611_A12EmployeeId, T000611_A68InvoiceProductQuantity, T000611_n68InvoiceProductQuantity
               }
               , new Object[] {
               T000613_A68InvoiceProductQuantity, T000613_n68InvoiceProductQuantity
               }
               , new Object[] {
               T000614_A14EmployeeLastName, T000614_A13EmployeeFirstName
               }
               , new Object[] {
               T000615_A20InvoiceId
               }
               , new Object[] {
               T000616_A20InvoiceId
               }
               , new Object[] {
               T000617_A20InvoiceId
               }
               , new Object[] {
               T000618_A20InvoiceId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000622_A68InvoiceProductQuantity, T000622_n68InvoiceProductQuantity
               }
               , new Object[] {
               T000623_A14EmployeeLastName, T000623_A13EmployeeFirstName
               }
               , new Object[] {
               T000624_A20InvoiceId
               }
               , new Object[] {
               T000625_A20InvoiceId, T000625_A25InvoiceDetailId, T000625_A26InvoiceDetailQuantity, T000625_A65InvoiceDetailHistoricPrice, T000625_A16ProductName, T000625_A15ProductId
               }
               , new Object[] {
               T000626_A16ProductName
               }
               , new Object[] {
               T000627_A20InvoiceId, T000627_A25InvoiceDetailId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000631_A16ProductName
               }
               , new Object[] {
               T000632_A20InvoiceId, T000632_A25InvoiceDetailId
               }
            }
         );
         AV15Pgmname = "Invoice";
         Z38InvoiceCreatedDate = DateTime.MinValue;
         A38InvoiceCreatedDate = DateTime.MinValue;
         i38InvoiceCreatedDate = DateTime.MinValue;
         Gx_date = DateTimeUtil.Today( context);
      }

      private short nIsMod_13 ;
      private short O68InvoiceProductQuantity ;
      private short nRcdDeleted_13 ;
      private short nRcdExists_13 ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A68InvoiceProductQuantity ;
      private short nBlankRcdCount13 ;
      private short RcdFound13 ;
      private short B68InvoiceProductQuantity ;
      private short nBlankRcdUsr13 ;
      private short Gx_BScreen ;
      private short RcdFound6 ;
      private short s68InvoiceProductQuantity ;
      private short GX_JID ;
      private short Z68InvoiceProductQuantity ;
      private short nIsDirty_6 ;
      private short nIsDirty_13 ;
      private short subGridinvoice_detail_Backcolorstyle ;
      private short subGridinvoice_detail_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridinvoice_detail_Allowselection ;
      private short subGridinvoice_detail_Allowhovering ;
      private short subGridinvoice_detail_Allowcollapsing ;
      private short subGridinvoice_detail_Collapsed ;
      private int wcpOAV7InvoiceId ;
      private int Z20InvoiceId ;
      private int Z12EmployeeId ;
      private int nRC_GXsfl_78 ;
      private int nGXsfl_78_idx=1 ;
      private int N12EmployeeId ;
      private int Z25InvoiceDetailId ;
      private int Z26InvoiceDetailQuantity ;
      private int Z15ProductId ;
      private int A20InvoiceId ;
      private int A12EmployeeId ;
      private int A15ProductId ;
      private int AV7InvoiceId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtInvoiceId_Enabled ;
      private int edtInvoiceDate_Enabled ;
      private int edtEmployeeId_Enabled ;
      private int imgprompt_12_Visible ;
      private int edtEmployeeLastName_Enabled ;
      private int edtEmployeeFirstName_Enabled ;
      private int edtInvoiceCreatedDate_Enabled ;
      private int edtInvoiceModifiedDate_Enabled ;
      private int edtInvoiceProductQuantity_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtInvoiceDetailId_Enabled ;
      private int edtInvoiceDetailQuantity_Enabled ;
      private int edtInvoiceDetailHistoricPrice_Enabled ;
      private int edtProductId_Enabled ;
      private int edtProductName_Enabled ;
      private int fRowAdded ;
      private int AV11Insert_EmployeeId ;
      private int A25InvoiceDetailId ;
      private int A26InvoiceDetailQuantity ;
      private int AV16GXV1 ;
      private int subGridinvoice_detail_Backcolor ;
      private int subGridinvoice_detail_Allbackcolor ;
      private int imgprompt_15_Visible ;
      private int defedtInvoiceDetailId_Enabled ;
      private int idxLst ;
      private int subGridinvoice_detail_Selectedindex ;
      private int subGridinvoice_detail_Selectioncolor ;
      private int subGridinvoice_detail_Hoveringcolor ;
      private long GRIDINVOICE_DETAIL_nFirstRecordOnPage ;
      private decimal Z65InvoiceDetailHistoricPrice ;
      private decimal A65InvoiceDetailHistoricPrice ;
      private string sPrefix ;
      private string sGXsfl_78_idx="0001" ;
      private string wcpOGx_mode ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtInvoiceDate_Internalname ;
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
      private string edtInvoiceDate_Jsonclick ;
      private string edtEmployeeId_Internalname ;
      private string edtEmployeeId_Jsonclick ;
      private string imgprompt_12_gximage ;
      private string sImgUrl ;
      private string imgprompt_12_Internalname ;
      private string imgprompt_12_Link ;
      private string edtEmployeeLastName_Internalname ;
      private string edtEmployeeLastName_Jsonclick ;
      private string edtEmployeeFirstName_Internalname ;
      private string edtEmployeeFirstName_Jsonclick ;
      private string edtInvoiceCreatedDate_Internalname ;
      private string edtInvoiceCreatedDate_Jsonclick ;
      private string edtInvoiceModifiedDate_Internalname ;
      private string edtInvoiceModifiedDate_Jsonclick ;
      private string edtInvoiceProductQuantity_Internalname ;
      private string edtInvoiceProductQuantity_Jsonclick ;
      private string divDetailtable_Internalname ;
      private string lblTitledetail_Internalname ;
      private string lblTitledetail_Jsonclick ;
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
      private string edtInvoiceDetailQuantity_Internalname ;
      private string edtInvoiceDetailHistoricPrice_Internalname ;
      private string edtProductId_Internalname ;
      private string edtProductName_Internalname ;
      private string sStyleString ;
      private string subGridinvoice_detail_Internalname ;
      private string AV15Pgmname ;
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
      private string sGXsfl_78_fel_idx="0001" ;
      private string subGridinvoice_detail_Class ;
      private string subGridinvoice_detail_Linesclass ;
      private string imgprompt_15_Link ;
      private string ROClassString ;
      private string edtInvoiceDetailId_Jsonclick ;
      private string edtInvoiceDetailQuantity_Jsonclick ;
      private string edtInvoiceDetailHistoricPrice_Jsonclick ;
      private string edtProductId_Jsonclick ;
      private string imgprompt_15_gximage ;
      private string edtProductName_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridinvoice_detail_Header ;
      private DateTime Z21InvoiceDate ;
      private DateTime Z38InvoiceCreatedDate ;
      private DateTime Z39InvoiceModifiedDate ;
      private DateTime A21InvoiceDate ;
      private DateTime A38InvoiceCreatedDate ;
      private DateTime A39InvoiceModifiedDate ;
      private DateTime Gx_date ;
      private DateTime i38InvoiceCreatedDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n68InvoiceProductQuantity ;
      private bool bGXsfl_78_Refreshing=false ;
      private bool n39InvoiceModifiedDate ;
      private bool returnInSub ;
      private string A14EmployeeLastName ;
      private string A13EmployeeFirstName ;
      private string A16ProductName ;
      private string Z14EmployeeLastName ;
      private string Z13EmployeeFirstName ;
      private string Z16ProductName ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridinvoice_detailContainer ;
      private GXWebRow Gridinvoice_detailRow ;
      private GXWebColumn Gridinvoice_detailColumn ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T00069_A68InvoiceProductQuantity ;
      private bool[] T00069_n68InvoiceProductQuantity ;
      private string[] T00067_A14EmployeeLastName ;
      private string[] T00067_A13EmployeeFirstName ;
      private int[] T000611_A20InvoiceId ;
      private DateTime[] T000611_A21InvoiceDate ;
      private string[] T000611_A14EmployeeLastName ;
      private string[] T000611_A13EmployeeFirstName ;
      private DateTime[] T000611_A38InvoiceCreatedDate ;
      private DateTime[] T000611_A39InvoiceModifiedDate ;
      private bool[] T000611_n39InvoiceModifiedDate ;
      private int[] T000611_A12EmployeeId ;
      private short[] T000611_A68InvoiceProductQuantity ;
      private bool[] T000611_n68InvoiceProductQuantity ;
      private short[] T000613_A68InvoiceProductQuantity ;
      private bool[] T000613_n68InvoiceProductQuantity ;
      private string[] T000614_A14EmployeeLastName ;
      private string[] T000614_A13EmployeeFirstName ;
      private int[] T000615_A20InvoiceId ;
      private int[] T00066_A20InvoiceId ;
      private DateTime[] T00066_A21InvoiceDate ;
      private DateTime[] T00066_A38InvoiceCreatedDate ;
      private DateTime[] T00066_A39InvoiceModifiedDate ;
      private bool[] T00066_n39InvoiceModifiedDate ;
      private int[] T00066_A12EmployeeId ;
      private int[] T000616_A20InvoiceId ;
      private int[] T000617_A20InvoiceId ;
      private int[] T00065_A20InvoiceId ;
      private DateTime[] T00065_A21InvoiceDate ;
      private DateTime[] T00065_A38InvoiceCreatedDate ;
      private DateTime[] T00065_A39InvoiceModifiedDate ;
      private bool[] T00065_n39InvoiceModifiedDate ;
      private int[] T00065_A12EmployeeId ;
      private int[] T000618_A20InvoiceId ;
      private short[] T000622_A68InvoiceProductQuantity ;
      private bool[] T000622_n68InvoiceProductQuantity ;
      private string[] T000623_A14EmployeeLastName ;
      private string[] T000623_A13EmployeeFirstName ;
      private int[] T000624_A20InvoiceId ;
      private int[] T000625_A20InvoiceId ;
      private int[] T000625_A25InvoiceDetailId ;
      private int[] T000625_A26InvoiceDetailQuantity ;
      private decimal[] T000625_A65InvoiceDetailHistoricPrice ;
      private string[] T000625_A16ProductName ;
      private int[] T000625_A15ProductId ;
      private string[] T00064_A16ProductName ;
      private string[] T000626_A16ProductName ;
      private int[] T000627_A20InvoiceId ;
      private int[] T000627_A25InvoiceDetailId ;
      private int[] T00063_A20InvoiceId ;
      private int[] T00063_A25InvoiceDetailId ;
      private int[] T00063_A26InvoiceDetailQuantity ;
      private decimal[] T00063_A65InvoiceDetailHistoricPrice ;
      private int[] T00063_A15ProductId ;
      private int[] T00062_A20InvoiceId ;
      private int[] T00062_A25InvoiceDetailId ;
      private int[] T00062_A26InvoiceDetailQuantity ;
      private decimal[] T00062_A65InvoiceDetailHistoricPrice ;
      private int[] T00062_A15ProductId ;
      private string[] T000631_A16ProductName ;
      private int[] T000632_A20InvoiceId ;
      private int[] T000632_A25InvoiceDetailId ;
      private GXWebForm Form ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV12TrnContextAtt ;
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
         ,new UpdateCursor(def[14])
         ,new UpdateCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new UpdateCursor(def[22])
         ,new UpdateCursor(def[23])
         ,new UpdateCursor(def[24])
         ,new ForEachCursor(def[25])
         ,new ForEachCursor(def[26])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000611;
          prmT000611 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmT00069;
          prmT00069 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmT00067;
          prmT00067 = new Object[] {
          new ParDef("@EmployeeId",GXType.Int32,6,0)
          };
          Object[] prmT000613;
          prmT000613 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmT000614;
          prmT000614 = new Object[] {
          new ParDef("@EmployeeId",GXType.Int32,6,0)
          };
          Object[] prmT000615;
          prmT000615 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmT00066;
          prmT00066 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmT000616;
          prmT000616 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmT000617;
          prmT000617 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmT00065;
          prmT00065 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmT000618;
          prmT000618 = new Object[] {
          new ParDef("@InvoiceDate",GXType.Date,8,0) ,
          new ParDef("@InvoiceCreatedDate",GXType.Date,8,0) ,
          new ParDef("@InvoiceModifiedDate",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@EmployeeId",GXType.Int32,6,0)
          };
          Object[] prmT000619;
          prmT000619 = new Object[] {
          new ParDef("@InvoiceDate",GXType.Date,8,0) ,
          new ParDef("@InvoiceCreatedDate",GXType.Date,8,0) ,
          new ParDef("@InvoiceModifiedDate",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@EmployeeId",GXType.Int32,6,0) ,
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmT000620;
          prmT000620 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmT000624;
          prmT000624 = new Object[] {
          };
          Object[] prmT000625;
          prmT000625 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0) ,
          new ParDef("@InvoiceDetailId",GXType.Int32,6,0)
          };
          Object[] prmT00064;
          prmT00064 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmT000626;
          prmT000626 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmT000627;
          prmT000627 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0) ,
          new ParDef("@InvoiceDetailId",GXType.Int32,6,0)
          };
          Object[] prmT00063;
          prmT00063 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0) ,
          new ParDef("@InvoiceDetailId",GXType.Int32,6,0)
          };
          Object[] prmT00062;
          prmT00062 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0) ,
          new ParDef("@InvoiceDetailId",GXType.Int32,6,0)
          };
          Object[] prmT000628;
          prmT000628 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0) ,
          new ParDef("@InvoiceDetailId",GXType.Int32,6,0) ,
          new ParDef("@InvoiceDetailQuantity",GXType.Int32,6,0) ,
          new ParDef("@InvoiceDetailHistoricPrice",GXType.Decimal,10,2) ,
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmT000629;
          prmT000629 = new Object[] {
          new ParDef("@InvoiceDetailQuantity",GXType.Int32,6,0) ,
          new ParDef("@InvoiceDetailHistoricPrice",GXType.Decimal,10,2) ,
          new ParDef("@ProductId",GXType.Int32,6,0) ,
          new ParDef("@InvoiceId",GXType.Int32,6,0) ,
          new ParDef("@InvoiceDetailId",GXType.Int32,6,0)
          };
          Object[] prmT000630;
          prmT000630 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0) ,
          new ParDef("@InvoiceDetailId",GXType.Int32,6,0)
          };
          Object[] prmT000632;
          prmT000632 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmT000622;
          prmT000622 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmT000623;
          prmT000623 = new Object[] {
          new ParDef("@EmployeeId",GXType.Int32,6,0)
          };
          Object[] prmT000631;
          prmT000631 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00062", "SELECT [InvoiceId], [InvoiceDetailId], [InvoiceDetailQuantity], [InvoiceDetailHistoricPrice], [ProductId] FROM [InvoiceDetail] WITH (UPDLOCK) WHERE [InvoiceId] = @InvoiceId AND [InvoiceDetailId] = @InvoiceDetailId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00062,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00063", "SELECT [InvoiceId], [InvoiceDetailId], [InvoiceDetailQuantity], [InvoiceDetailHistoricPrice], [ProductId] FROM [InvoiceDetail] WHERE [InvoiceId] = @InvoiceId AND [InvoiceDetailId] = @InvoiceDetailId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00063,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00064", "SELECT [ProductName] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00064,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00065", "SELECT [InvoiceId], [InvoiceDate], [InvoiceCreatedDate], [InvoiceModifiedDate], [EmployeeId] FROM [Invoice] WITH (UPDLOCK) WHERE [InvoiceId] = @InvoiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00065,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00066", "SELECT [InvoiceId], [InvoiceDate], [InvoiceCreatedDate], [InvoiceModifiedDate], [EmployeeId] FROM [Invoice] WHERE [InvoiceId] = @InvoiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00066,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00067", "SELECT [EmployeeLastName], [EmployeeFirstName] FROM [Employee] WHERE [EmployeeId] = @EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00067,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00069", "SELECT COALESCE( T1.[InvoiceProductQuantity], 0) AS InvoiceProductQuantity FROM (SELECT COUNT(*) AS InvoiceProductQuantity, [InvoiceId] FROM [InvoiceDetail] WITH (UPDLOCK) GROUP BY [InvoiceId] ) T1 WHERE T1.[InvoiceId] = @InvoiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00069,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000611", "SELECT TM1.[InvoiceId], TM1.[InvoiceDate], T3.[EmployeeLastName], T3.[EmployeeFirstName], TM1.[InvoiceCreatedDate], TM1.[InvoiceModifiedDate], TM1.[EmployeeId], COALESCE( T2.[InvoiceProductQuantity], 0) AS InvoiceProductQuantity FROM (([Invoice] TM1 LEFT JOIN (SELECT COUNT(*) AS InvoiceProductQuantity, [InvoiceId] FROM [InvoiceDetail] GROUP BY [InvoiceId] ) T2 ON T2.[InvoiceId] = TM1.[InvoiceId]) INNER JOIN [Employee] T3 ON T3.[EmployeeId] = TM1.[EmployeeId]) WHERE TM1.[InvoiceId] = @InvoiceId ORDER BY TM1.[InvoiceId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000611,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000613", "SELECT COALESCE( T1.[InvoiceProductQuantity], 0) AS InvoiceProductQuantity FROM (SELECT COUNT(*) AS InvoiceProductQuantity, [InvoiceId] FROM [InvoiceDetail] WITH (UPDLOCK) GROUP BY [InvoiceId] ) T1 WHERE T1.[InvoiceId] = @InvoiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000613,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000614", "SELECT [EmployeeLastName], [EmployeeFirstName] FROM [Employee] WHERE [EmployeeId] = @EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000614,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000615", "SELECT [InvoiceId] FROM [Invoice] WHERE [InvoiceId] = @InvoiceId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000615,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000616", "SELECT TOP 1 [InvoiceId] FROM [Invoice] WHERE ( [InvoiceId] > @InvoiceId) ORDER BY [InvoiceId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000616,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000617", "SELECT TOP 1 [InvoiceId] FROM [Invoice] WHERE ( [InvoiceId] < @InvoiceId) ORDER BY [InvoiceId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000617,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000618", "INSERT INTO [Invoice]([InvoiceDate], [InvoiceCreatedDate], [InvoiceModifiedDate], [EmployeeId]) VALUES(@InvoiceDate, @InvoiceCreatedDate, @InvoiceModifiedDate, @EmployeeId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000618,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000619", "UPDATE [Invoice] SET [InvoiceDate]=@InvoiceDate, [InvoiceCreatedDate]=@InvoiceCreatedDate, [InvoiceModifiedDate]=@InvoiceModifiedDate, [EmployeeId]=@EmployeeId  WHERE [InvoiceId] = @InvoiceId", GxErrorMask.GX_NOMASK,prmT000619)
             ,new CursorDef("T000620", "DELETE FROM [Invoice]  WHERE [InvoiceId] = @InvoiceId", GxErrorMask.GX_NOMASK,prmT000620)
             ,new CursorDef("T000622", "SELECT COALESCE( T1.[InvoiceProductQuantity], 0) AS InvoiceProductQuantity FROM (SELECT COUNT(*) AS InvoiceProductQuantity, [InvoiceId] FROM [InvoiceDetail] WITH (UPDLOCK) GROUP BY [InvoiceId] ) T1 WHERE T1.[InvoiceId] = @InvoiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000622,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000623", "SELECT [EmployeeLastName], [EmployeeFirstName] FROM [Employee] WHERE [EmployeeId] = @EmployeeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000623,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000624", "SELECT [InvoiceId] FROM [Invoice] ORDER BY [InvoiceId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000624,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000625", "SELECT T1.[InvoiceId], T1.[InvoiceDetailId], T1.[InvoiceDetailQuantity], T1.[InvoiceDetailHistoricPrice], T2.[ProductName], T1.[ProductId] FROM ([InvoiceDetail] T1 INNER JOIN [Product] T2 ON T2.[ProductId] = T1.[ProductId]) WHERE T1.[InvoiceId] = @InvoiceId and T1.[InvoiceDetailId] = @InvoiceDetailId ORDER BY T1.[InvoiceId], T1.[InvoiceDetailId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000625,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000626", "SELECT [ProductName] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000626,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000627", "SELECT [InvoiceId], [InvoiceDetailId] FROM [InvoiceDetail] WHERE [InvoiceId] = @InvoiceId AND [InvoiceDetailId] = @InvoiceDetailId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000627,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000628", "INSERT INTO [InvoiceDetail]([InvoiceId], [InvoiceDetailId], [InvoiceDetailQuantity], [InvoiceDetailHistoricPrice], [ProductId]) VALUES(@InvoiceId, @InvoiceDetailId, @InvoiceDetailQuantity, @InvoiceDetailHistoricPrice, @ProductId)", GxErrorMask.GX_NOMASK,prmT000628)
             ,new CursorDef("T000629", "UPDATE [InvoiceDetail] SET [InvoiceDetailQuantity]=@InvoiceDetailQuantity, [InvoiceDetailHistoricPrice]=@InvoiceDetailHistoricPrice, [ProductId]=@ProductId  WHERE [InvoiceId] = @InvoiceId AND [InvoiceDetailId] = @InvoiceDetailId", GxErrorMask.GX_NOMASK,prmT000629)
             ,new CursorDef("T000630", "DELETE FROM [InvoiceDetail]  WHERE [InvoiceId] = @InvoiceId AND [InvoiceDetailId] = @InvoiceDetailId", GxErrorMask.GX_NOMASK,prmT000630)
             ,new CursorDef("T000631", "SELECT [ProductName] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000631,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000632", "SELECT [InvoiceId], [InvoiceDetailId] FROM [InvoiceDetail] WHERE [InvoiceId] = @InvoiceId ORDER BY [InvoiceId], [InvoiceDetailId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000632,11, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                ((short[]) buf[8])[0] = rslt.getShort(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 16 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 17 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 18 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 19 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                return;
             case 20 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 21 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 25 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 26 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
       }
    }

 }

}
