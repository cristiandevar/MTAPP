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
   public class supplier : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_8") == 0 )
         {
            A4SupplierId = (int)(Math.Round(NumberUtil.Val( GetPar( "SupplierId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A4SupplierId", StringUtil.LTrimStr( (decimal)(A4SupplierId), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_8( A4SupplierId) ;
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
               AV7SupplierId = (int)(Math.Round(NumberUtil.Val( GetPar( "SupplierId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7SupplierId", StringUtil.LTrimStr( (decimal)(AV7SupplierId), 6, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vSUPPLIERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7SupplierId), "ZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Supplier", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtSupplierName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("mtaKB", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public supplier( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public supplier( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_SupplierId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7SupplierId = aP1_SupplierId;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Supplier", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Supplier.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Supplier.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Supplier.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Supplier.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Supplier.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Supplier.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSupplierId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtSupplierId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A4SupplierId), 6, 0, ".", "")), StringUtil.LTrim( ((edtSupplierId_Enabled!=0) ? context.localUtil.Format( (decimal)(A4SupplierId), "ZZZZZ9") : context.localUtil.Format( (decimal)(A4SupplierId), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierId_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_Supplier.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSupplierName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierName_Internalname, "Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierName_Internalname, A5SupplierName, StringUtil.RTrim( context.localUtil.Format( A5SupplierName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierName_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Name", "left", true, "", "HLP_Supplier.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSupplierDescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierDescription_Internalname, "Description", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtSupplierDescription_Internalname, A6SupplierDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", 0, 1, edtSupplierDescription_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "GeneXusUnanimo\\Description", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Supplier.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSupplierPhone_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierPhone_Internalname, "Phone", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A7SupplierPhone);
         }
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierPhone_Internalname, StringUtil.RTrim( A7SupplierPhone), StringUtil.RTrim( context.localUtil.Format( A7SupplierPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtSupplierPhone_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierPhone_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "left", true, "", "HLP_Supplier.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSupplierEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierEmail_Internalname, "Email", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierEmail_Internalname, A8SupplierEmail, StringUtil.RTrim( context.localUtil.Format( A8SupplierEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A8SupplierEmail, "", "", "", edtSupplierEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "left", true, "", "HLP_Supplier.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSupplierCreatedDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierCreatedDate_Internalname, "Created Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         context.WriteHtmlText( "<div id=\""+edtSupplierCreatedDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtSupplierCreatedDate_Internalname, context.localUtil.Format(A32SupplierCreatedDate, "99/99/99"), context.localUtil.Format( A32SupplierCreatedDate, "99/99/99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierCreatedDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierCreatedDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Supplier.htm");
         GxWebStd.gx_bitmap( context, edtSupplierCreatedDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtSupplierCreatedDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Supplier.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSupplierModifiedDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierModifiedDate_Internalname, "Modified Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtSupplierModifiedDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtSupplierModifiedDate_Internalname, context.localUtil.Format(A33SupplierModifiedDate, "99/99/99"), context.localUtil.Format( A33SupplierModifiedDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierModifiedDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierModifiedDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Supplier.htm");
         GxWebStd.gx_bitmap( context, edtSupplierModifiedDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtSupplierModifiedDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Supplier.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSupplierProductQuantity_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierProductQuantity_Internalname, "Product Quantity", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtSupplierProductQuantity_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A57SupplierProductQuantity), 4, 0, ".", "")), StringUtil.LTrim( ((edtSupplierProductQuantity_Enabled!=0) ? context.localUtil.Format( (decimal)(A57SupplierProductQuantity), "ZZZ9") : context.localUtil.Format( (decimal)(A57SupplierProductQuantity), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierProductQuantity_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierProductQuantity_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Supplier.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Supplier.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Supplier.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Supplier.htm");
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
         E11022 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z4SupplierId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z4SupplierId"), ".", ","), 18, MidpointRounding.ToEven));
               Z5SupplierName = cgiGet( "Z5SupplierName");
               Z6SupplierDescription = cgiGet( "Z6SupplierDescription");
               n6SupplierDescription = (String.IsNullOrEmpty(StringUtil.RTrim( A6SupplierDescription)) ? true : false);
               Z7SupplierPhone = cgiGet( "Z7SupplierPhone");
               n7SupplierPhone = (String.IsNullOrEmpty(StringUtil.RTrim( A7SupplierPhone)) ? true : false);
               Z8SupplierEmail = cgiGet( "Z8SupplierEmail");
               n8SupplierEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A8SupplierEmail)) ? true : false);
               Z32SupplierCreatedDate = context.localUtil.CToD( cgiGet( "Z32SupplierCreatedDate"), 0);
               Z33SupplierModifiedDate = context.localUtil.CToD( cgiGet( "Z33SupplierModifiedDate"), 0);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7SupplierId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vSUPPLIERID"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_date = context.localUtil.CToD( cgiGet( "vTODAY"), 0);
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","), 18, MidpointRounding.ToEven));
               AV13Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A4SupplierId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtSupplierId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A4SupplierId", StringUtil.LTrimStr( (decimal)(A4SupplierId), 6, 0));
               A5SupplierName = cgiGet( edtSupplierName_Internalname);
               AssignAttri("", false, "A5SupplierName", A5SupplierName);
               A6SupplierDescription = cgiGet( edtSupplierDescription_Internalname);
               n6SupplierDescription = false;
               AssignAttri("", false, "A6SupplierDescription", A6SupplierDescription);
               n6SupplierDescription = (String.IsNullOrEmpty(StringUtil.RTrim( A6SupplierDescription)) ? true : false);
               A7SupplierPhone = cgiGet( edtSupplierPhone_Internalname);
               n7SupplierPhone = false;
               AssignAttri("", false, "A7SupplierPhone", A7SupplierPhone);
               n7SupplierPhone = (String.IsNullOrEmpty(StringUtil.RTrim( A7SupplierPhone)) ? true : false);
               A8SupplierEmail = cgiGet( edtSupplierEmail_Internalname);
               n8SupplierEmail = false;
               AssignAttri("", false, "A8SupplierEmail", A8SupplierEmail);
               n8SupplierEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A8SupplierEmail)) ? true : false);
               A32SupplierCreatedDate = context.localUtil.CToD( cgiGet( edtSupplierCreatedDate_Internalname), 1);
               AssignAttri("", false, "A32SupplierCreatedDate", context.localUtil.Format(A32SupplierCreatedDate, "99/99/99"));
               if ( context.localUtil.VCDate( cgiGet( edtSupplierModifiedDate_Internalname), 1) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Supplier Modified Date"}), 1, "SUPPLIERMODIFIEDDATE");
                  AnyError = 1;
                  GX_FocusControl = edtSupplierModifiedDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A33SupplierModifiedDate = DateTime.MinValue;
                  AssignAttri("", false, "A33SupplierModifiedDate", context.localUtil.Format(A33SupplierModifiedDate, "99/99/99"));
               }
               else
               {
                  A33SupplierModifiedDate = context.localUtil.CToD( cgiGet( edtSupplierModifiedDate_Internalname), 1);
                  AssignAttri("", false, "A33SupplierModifiedDate", context.localUtil.Format(A33SupplierModifiedDate, "99/99/99"));
               }
               A57SupplierProductQuantity = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSupplierProductQuantity_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               n57SupplierProductQuantity = false;
               AssignAttri("", false, "A57SupplierProductQuantity", StringUtil.LTrimStr( (decimal)(A57SupplierProductQuantity), 4, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Supplier");
               A4SupplierId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtSupplierId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A4SupplierId", StringUtil.LTrimStr( (decimal)(A4SupplierId), 6, 0));
               forbiddenHiddens.Add("SupplierId", context.localUtil.Format( (decimal)(A4SupplierId), "ZZZZZ9"));
               A32SupplierCreatedDate = context.localUtil.CToD( cgiGet( edtSupplierCreatedDate_Internalname), 1);
               AssignAttri("", false, "A32SupplierCreatedDate", context.localUtil.Format(A32SupplierCreatedDate, "99/99/99"));
               forbiddenHiddens.Add("SupplierCreatedDate", context.localUtil.Format(A32SupplierCreatedDate, "99/99/99"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A4SupplierId != Z4SupplierId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("supplier:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A4SupplierId = (int)(Math.Round(NumberUtil.Val( GetPar( "SupplierId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A4SupplierId", StringUtil.LTrimStr( (decimal)(A4SupplierId), 6, 0));
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
                     sMode2 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode2;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound2 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_020( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "SUPPLIERID");
                        AnyError = 1;
                        GX_FocusControl = edtSupplierId_Internalname;
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
                           E11022 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12022 ();
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
            E12022 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll022( ) ;
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
            DisableAttributes022( ) ;
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

      protected void CONFIRM_020( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls022( ) ;
            }
            else
            {
               CheckExtendedTable022( ) ;
               CloseExtendedTableCursors022( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption020( )
      {
      }

      protected void E11022( )
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

      protected void E12022( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwsupplier.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         pr_default.close(1);
         pr_default.close(2);
         returnInSub = true;
         if (true) return;
      }

      protected void ZM022( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z5SupplierName = T00023_A5SupplierName[0];
               Z6SupplierDescription = T00023_A6SupplierDescription[0];
               Z7SupplierPhone = T00023_A7SupplierPhone[0];
               Z8SupplierEmail = T00023_A8SupplierEmail[0];
               Z32SupplierCreatedDate = T00023_A32SupplierCreatedDate[0];
               Z33SupplierModifiedDate = T00023_A33SupplierModifiedDate[0];
            }
            else
            {
               Z5SupplierName = A5SupplierName;
               Z6SupplierDescription = A6SupplierDescription;
               Z7SupplierPhone = A7SupplierPhone;
               Z8SupplierEmail = A8SupplierEmail;
               Z32SupplierCreatedDate = A32SupplierCreatedDate;
               Z33SupplierModifiedDate = A33SupplierModifiedDate;
            }
         }
         if ( GX_JID == -7 )
         {
            Z4SupplierId = A4SupplierId;
            Z5SupplierName = A5SupplierName;
            Z6SupplierDescription = A6SupplierDescription;
            Z7SupplierPhone = A7SupplierPhone;
            Z8SupplierEmail = A8SupplierEmail;
            Z32SupplierCreatedDate = A32SupplierCreatedDate;
            Z33SupplierModifiedDate = A33SupplierModifiedDate;
            Z57SupplierProductQuantity = A57SupplierProductQuantity;
         }
      }

      protected void standaloneNotModal( )
      {
         edtSupplierId_Enabled = 0;
         AssignProp("", false, edtSupplierId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierId_Enabled), 5, 0), true);
         edtSupplierCreatedDate_Enabled = 0;
         AssignProp("", false, edtSupplierCreatedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierCreatedDate_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         Gx_date = DateTimeUtil.Today( context);
         AssignAttri("", false, "Gx_date", context.localUtil.Format(Gx_date, "99/99/99"));
         edtSupplierId_Enabled = 0;
         AssignProp("", false, edtSupplierId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierId_Enabled), 5, 0), true);
         edtSupplierCreatedDate_Enabled = 0;
         AssignProp("", false, edtSupplierCreatedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierCreatedDate_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7SupplierId) )
         {
            A4SupplierId = AV7SupplierId;
            AssignAttri("", false, "A4SupplierId", StringUtil.LTrimStr( (decimal)(A4SupplierId), 6, 0));
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
         if ( IsIns( )  && (DateTime.MinValue==A32SupplierCreatedDate) && ( Gx_BScreen == 0 ) )
         {
            A32SupplierCreatedDate = Gx_date;
            AssignAttri("", false, "A32SupplierCreatedDate", context.localUtil.Format(A32SupplierCreatedDate, "99/99/99"));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T00025 */
            pr_default.execute(2, new Object[] {A4SupplierId});
            if ( (pr_default.getStatus(2) != 101) )
            {
               A57SupplierProductQuantity = T00025_A57SupplierProductQuantity[0];
               n57SupplierProductQuantity = T00025_n57SupplierProductQuantity[0];
               AssignAttri("", false, "A57SupplierProductQuantity", StringUtil.LTrimStr( (decimal)(A57SupplierProductQuantity), 4, 0));
            }
            else
            {
               A57SupplierProductQuantity = 0;
               n57SupplierProductQuantity = false;
               AssignAttri("", false, "A57SupplierProductQuantity", StringUtil.LTrimStr( (decimal)(A57SupplierProductQuantity), 4, 0));
            }
            pr_default.close(2);
         }
      }

      protected void Load022( )
      {
         /* Using cursor T00027 */
         pr_default.execute(3, new Object[] {A4SupplierId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound2 = 1;
            A5SupplierName = T00027_A5SupplierName[0];
            AssignAttri("", false, "A5SupplierName", A5SupplierName);
            A6SupplierDescription = T00027_A6SupplierDescription[0];
            n6SupplierDescription = T00027_n6SupplierDescription[0];
            AssignAttri("", false, "A6SupplierDescription", A6SupplierDescription);
            A7SupplierPhone = T00027_A7SupplierPhone[0];
            n7SupplierPhone = T00027_n7SupplierPhone[0];
            AssignAttri("", false, "A7SupplierPhone", A7SupplierPhone);
            A8SupplierEmail = T00027_A8SupplierEmail[0];
            n8SupplierEmail = T00027_n8SupplierEmail[0];
            AssignAttri("", false, "A8SupplierEmail", A8SupplierEmail);
            A32SupplierCreatedDate = T00027_A32SupplierCreatedDate[0];
            AssignAttri("", false, "A32SupplierCreatedDate", context.localUtil.Format(A32SupplierCreatedDate, "99/99/99"));
            A33SupplierModifiedDate = T00027_A33SupplierModifiedDate[0];
            AssignAttri("", false, "A33SupplierModifiedDate", context.localUtil.Format(A33SupplierModifiedDate, "99/99/99"));
            A57SupplierProductQuantity = T00027_A57SupplierProductQuantity[0];
            n57SupplierProductQuantity = T00027_n57SupplierProductQuantity[0];
            AssignAttri("", false, "A57SupplierProductQuantity", StringUtil.LTrimStr( (decimal)(A57SupplierProductQuantity), 4, 0));
            ZM022( -7) ;
         }
         pr_default.close(3);
         OnLoadActions022( ) ;
      }

      protected void OnLoadActions022( )
      {
         AV13Pgmname = "Supplier";
         AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
      }

      protected void CheckExtendedTable022( )
      {
         nIsDirty_2 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV13Pgmname = "Supplier";
         AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
         /* Using cursor T00025 */
         pr_default.execute(2, new Object[] {A4SupplierId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            A57SupplierProductQuantity = T00025_A57SupplierProductQuantity[0];
            n57SupplierProductQuantity = T00025_n57SupplierProductQuantity[0];
            AssignAttri("", false, "A57SupplierProductQuantity", StringUtil.LTrimStr( (decimal)(A57SupplierProductQuantity), 4, 0));
         }
         else
         {
            nIsDirty_2 = 1;
            A57SupplierProductQuantity = 0;
            n57SupplierProductQuantity = false;
            AssignAttri("", false, "A57SupplierProductQuantity", StringUtil.LTrimStr( (decimal)(A57SupplierProductQuantity), 4, 0));
         }
         pr_default.close(2);
         if ( ! ( GxRegex.IsMatch(A8SupplierEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A8SupplierEmail)) ) )
         {
            GX_msglist.addItem("Field Supplier Email does not match the specified pattern", "OutOfRange", 1, "SUPPLIEREMAIL");
            AnyError = 1;
            GX_FocusControl = edtSupplierEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A33SupplierModifiedDate) || ( DateTimeUtil.ResetTime ( A33SupplierModifiedDate ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Supplier Modified Date is out of range", "OutOfRange", 1, "SUPPLIERMODIFIEDDATE");
            AnyError = 1;
            GX_FocusControl = edtSupplierModifiedDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors022( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_8( int A4SupplierId )
      {
         /* Using cursor T00029 */
         pr_default.execute(4, new Object[] {A4SupplierId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            A57SupplierProductQuantity = T00029_A57SupplierProductQuantity[0];
            n57SupplierProductQuantity = T00029_n57SupplierProductQuantity[0];
            AssignAttri("", false, "A57SupplierProductQuantity", StringUtil.LTrimStr( (decimal)(A57SupplierProductQuantity), 4, 0));
         }
         else
         {
            A57SupplierProductQuantity = 0;
            n57SupplierProductQuantity = false;
            AssignAttri("", false, "A57SupplierProductQuantity", StringUtil.LTrimStr( (decimal)(A57SupplierProductQuantity), 4, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A57SupplierProductQuantity), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey022( )
      {
         /* Using cursor T000210 */
         pr_default.execute(5, new Object[] {A4SupplierId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound2 = 1;
         }
         else
         {
            RcdFound2 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00023 */
         pr_default.execute(1, new Object[] {A4SupplierId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM022( 7) ;
            RcdFound2 = 1;
            A4SupplierId = T00023_A4SupplierId[0];
            AssignAttri("", false, "A4SupplierId", StringUtil.LTrimStr( (decimal)(A4SupplierId), 6, 0));
            A5SupplierName = T00023_A5SupplierName[0];
            AssignAttri("", false, "A5SupplierName", A5SupplierName);
            A6SupplierDescription = T00023_A6SupplierDescription[0];
            n6SupplierDescription = T00023_n6SupplierDescription[0];
            AssignAttri("", false, "A6SupplierDescription", A6SupplierDescription);
            A7SupplierPhone = T00023_A7SupplierPhone[0];
            n7SupplierPhone = T00023_n7SupplierPhone[0];
            AssignAttri("", false, "A7SupplierPhone", A7SupplierPhone);
            A8SupplierEmail = T00023_A8SupplierEmail[0];
            n8SupplierEmail = T00023_n8SupplierEmail[0];
            AssignAttri("", false, "A8SupplierEmail", A8SupplierEmail);
            A32SupplierCreatedDate = T00023_A32SupplierCreatedDate[0];
            AssignAttri("", false, "A32SupplierCreatedDate", context.localUtil.Format(A32SupplierCreatedDate, "99/99/99"));
            A33SupplierModifiedDate = T00023_A33SupplierModifiedDate[0];
            AssignAttri("", false, "A33SupplierModifiedDate", context.localUtil.Format(A33SupplierModifiedDate, "99/99/99"));
            Z4SupplierId = A4SupplierId;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load022( ) ;
            if ( AnyError == 1 )
            {
               RcdFound2 = 0;
               InitializeNonKey022( ) ;
            }
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound2 = 0;
            InitializeNonKey022( ) ;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey022( ) ;
         if ( RcdFound2 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound2 = 0;
         /* Using cursor T000211 */
         pr_default.execute(6, new Object[] {A4SupplierId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T000211_A4SupplierId[0] < A4SupplierId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T000211_A4SupplierId[0] > A4SupplierId ) ) )
            {
               A4SupplierId = T000211_A4SupplierId[0];
               AssignAttri("", false, "A4SupplierId", StringUtil.LTrimStr( (decimal)(A4SupplierId), 6, 0));
               RcdFound2 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound2 = 0;
         /* Using cursor T000212 */
         pr_default.execute(7, new Object[] {A4SupplierId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T000212_A4SupplierId[0] > A4SupplierId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T000212_A4SupplierId[0] < A4SupplierId ) ) )
            {
               A4SupplierId = T000212_A4SupplierId[0];
               AssignAttri("", false, "A4SupplierId", StringUtil.LTrimStr( (decimal)(A4SupplierId), 6, 0));
               RcdFound2 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey022( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSupplierName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert022( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound2 == 1 )
            {
               if ( A4SupplierId != Z4SupplierId )
               {
                  A4SupplierId = Z4SupplierId;
                  AssignAttri("", false, "A4SupplierId", StringUtil.LTrimStr( (decimal)(A4SupplierId), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SUPPLIERID");
                  AnyError = 1;
                  GX_FocusControl = edtSupplierId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtSupplierName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update022( ) ;
                  GX_FocusControl = edtSupplierName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A4SupplierId != Z4SupplierId )
               {
                  /* Insert record */
                  GX_FocusControl = edtSupplierName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert022( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SUPPLIERID");
                     AnyError = 1;
                     GX_FocusControl = edtSupplierId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtSupplierName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert022( ) ;
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
         if ( A4SupplierId != Z4SupplierId )
         {
            A4SupplierId = Z4SupplierId;
            AssignAttri("", false, "A4SupplierId", StringUtil.LTrimStr( (decimal)(A4SupplierId), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SUPPLIERID");
            AnyError = 1;
            GX_FocusControl = edtSupplierId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtSupplierName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency022( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00022 */
            pr_default.execute(0, new Object[] {A4SupplierId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Supplier"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z5SupplierName, T00022_A5SupplierName[0]) != 0 ) || ( StringUtil.StrCmp(Z6SupplierDescription, T00022_A6SupplierDescription[0]) != 0 ) || ( StringUtil.StrCmp(Z7SupplierPhone, T00022_A7SupplierPhone[0]) != 0 ) || ( StringUtil.StrCmp(Z8SupplierEmail, T00022_A8SupplierEmail[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z32SupplierCreatedDate ) != DateTimeUtil.ResetTime ( T00022_A32SupplierCreatedDate[0] ) ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( DateTimeUtil.ResetTime ( Z33SupplierModifiedDate ) != DateTimeUtil.ResetTime ( T00022_A33SupplierModifiedDate[0] ) ) )
            {
               if ( StringUtil.StrCmp(Z5SupplierName, T00022_A5SupplierName[0]) != 0 )
               {
                  GXUtil.WriteLog("supplier:[seudo value changed for attri]"+"SupplierName");
                  GXUtil.WriteLogRaw("Old: ",Z5SupplierName);
                  GXUtil.WriteLogRaw("Current: ",T00022_A5SupplierName[0]);
               }
               if ( StringUtil.StrCmp(Z6SupplierDescription, T00022_A6SupplierDescription[0]) != 0 )
               {
                  GXUtil.WriteLog("supplier:[seudo value changed for attri]"+"SupplierDescription");
                  GXUtil.WriteLogRaw("Old: ",Z6SupplierDescription);
                  GXUtil.WriteLogRaw("Current: ",T00022_A6SupplierDescription[0]);
               }
               if ( StringUtil.StrCmp(Z7SupplierPhone, T00022_A7SupplierPhone[0]) != 0 )
               {
                  GXUtil.WriteLog("supplier:[seudo value changed for attri]"+"SupplierPhone");
                  GXUtil.WriteLogRaw("Old: ",Z7SupplierPhone);
                  GXUtil.WriteLogRaw("Current: ",T00022_A7SupplierPhone[0]);
               }
               if ( StringUtil.StrCmp(Z8SupplierEmail, T00022_A8SupplierEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("supplier:[seudo value changed for attri]"+"SupplierEmail");
                  GXUtil.WriteLogRaw("Old: ",Z8SupplierEmail);
                  GXUtil.WriteLogRaw("Current: ",T00022_A8SupplierEmail[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z32SupplierCreatedDate ) != DateTimeUtil.ResetTime ( T00022_A32SupplierCreatedDate[0] ) )
               {
                  GXUtil.WriteLog("supplier:[seudo value changed for attri]"+"SupplierCreatedDate");
                  GXUtil.WriteLogRaw("Old: ",Z32SupplierCreatedDate);
                  GXUtil.WriteLogRaw("Current: ",T00022_A32SupplierCreatedDate[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z33SupplierModifiedDate ) != DateTimeUtil.ResetTime ( T00022_A33SupplierModifiedDate[0] ) )
               {
                  GXUtil.WriteLog("supplier:[seudo value changed for attri]"+"SupplierModifiedDate");
                  GXUtil.WriteLogRaw("Old: ",Z33SupplierModifiedDate);
                  GXUtil.WriteLogRaw("Current: ",T00022_A33SupplierModifiedDate[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Supplier"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM022( 0) ;
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000213 */
                     pr_default.execute(8, new Object[] {A5SupplierName, n6SupplierDescription, A6SupplierDescription, n7SupplierPhone, A7SupplierPhone, n8SupplierEmail, A8SupplierEmail, A32SupplierCreatedDate, A33SupplierModifiedDate});
                     A4SupplierId = T000213_A4SupplierId[0];
                     AssignAttri("", false, "A4SupplierId", StringUtil.LTrimStr( (decimal)(A4SupplierId), 6, 0));
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Supplier");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption020( ) ;
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
               Load022( ) ;
            }
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void Update022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000214 */
                     pr_default.execute(9, new Object[] {A5SupplierName, n6SupplierDescription, A6SupplierDescription, n7SupplierPhone, A7SupplierPhone, n8SupplierEmail, A8SupplierEmail, A32SupplierCreatedDate, A33SupplierModifiedDate, A4SupplierId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Supplier");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Supplier"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate022( ) ;
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
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void DeferredUpdate022( )
      {
      }

      protected void delete( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls022( ) ;
            AfterConfirm022( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete022( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000215 */
                  pr_default.execute(10, new Object[] {A4SupplierId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("Supplier");
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
         sMode2 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel022( ) ;
         Gx_mode = sMode2;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls022( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV13Pgmname = "Supplier";
            AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
            /* Using cursor T000217 */
            pr_default.execute(11, new Object[] {A4SupplierId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               A57SupplierProductQuantity = T000217_A57SupplierProductQuantity[0];
               n57SupplierProductQuantity = T000217_n57SupplierProductQuantity[0];
               AssignAttri("", false, "A57SupplierProductQuantity", StringUtil.LTrimStr( (decimal)(A57SupplierProductQuantity), 4, 0));
            }
            else
            {
               A57SupplierProductQuantity = 0;
               n57SupplierProductQuantity = false;
               AssignAttri("", false, "A57SupplierProductQuantity", StringUtil.LTrimStr( (decimal)(A57SupplierProductQuantity), 4, 0));
            }
            pr_default.close(11);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000218 */
            pr_default.execute(12, new Object[] {A4SupplierId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Purchase Order"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T000219 */
            pr_default.execute(13, new Object[] {A4SupplierId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Product"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
         }
      }

      protected void EndLevel022( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete022( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(11);
            context.CommitDataStores("supplier",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues020( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(11);
            context.RollbackDataStores("supplier",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart022( )
      {
         /* Scan By routine */
         /* Using cursor T000220 */
         pr_default.execute(14);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound2 = 1;
            A4SupplierId = T000220_A4SupplierId[0];
            AssignAttri("", false, "A4SupplierId", StringUtil.LTrimStr( (decimal)(A4SupplierId), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext022( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound2 = 1;
            A4SupplierId = T000220_A4SupplierId[0];
            AssignAttri("", false, "A4SupplierId", StringUtil.LTrimStr( (decimal)(A4SupplierId), 6, 0));
         }
      }

      protected void ScanEnd022( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm022( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert022( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate022( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete022( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete022( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate022( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes022( )
      {
         edtSupplierId_Enabled = 0;
         AssignProp("", false, edtSupplierId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierId_Enabled), 5, 0), true);
         edtSupplierName_Enabled = 0;
         AssignProp("", false, edtSupplierName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierName_Enabled), 5, 0), true);
         edtSupplierDescription_Enabled = 0;
         AssignProp("", false, edtSupplierDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierDescription_Enabled), 5, 0), true);
         edtSupplierPhone_Enabled = 0;
         AssignProp("", false, edtSupplierPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierPhone_Enabled), 5, 0), true);
         edtSupplierEmail_Enabled = 0;
         AssignProp("", false, edtSupplierEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierEmail_Enabled), 5, 0), true);
         edtSupplierCreatedDate_Enabled = 0;
         AssignProp("", false, edtSupplierCreatedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierCreatedDate_Enabled), 5, 0), true);
         edtSupplierModifiedDate_Enabled = 0;
         AssignProp("", false, edtSupplierModifiedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierModifiedDate_Enabled), 5, 0), true);
         edtSupplierProductQuantity_Enabled = 0;
         AssignProp("", false, edtSupplierProductQuantity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierProductQuantity_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes022( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues020( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("supplier.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7SupplierId,6,0))}, new string[] {"Gx_mode","SupplierId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Supplier");
         forbiddenHiddens.Add("SupplierId", context.localUtil.Format( (decimal)(A4SupplierId), "ZZZZZ9"));
         forbiddenHiddens.Add("SupplierCreatedDate", context.localUtil.Format(A32SupplierCreatedDate, "99/99/99"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("supplier:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z4SupplierId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z4SupplierId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z5SupplierName", Z5SupplierName);
         GxWebStd.gx_hidden_field( context, "Z6SupplierDescription", Z6SupplierDescription);
         GxWebStd.gx_hidden_field( context, "Z7SupplierPhone", StringUtil.RTrim( Z7SupplierPhone));
         GxWebStd.gx_hidden_field( context, "Z8SupplierEmail", Z8SupplierEmail);
         GxWebStd.gx_hidden_field( context, "Z32SupplierCreatedDate", context.localUtil.DToC( Z32SupplierCreatedDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z33SupplierModifiedDate", context.localUtil.DToC( Z33SupplierModifiedDate, 0, "/"));
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
         GxWebStd.gx_hidden_field( context, "vSUPPLIERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7SupplierId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSUPPLIERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7SupplierId), "ZZZZZ9"), context));
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
         return formatLink("supplier.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7SupplierId,6,0))}, new string[] {"Gx_mode","SupplierId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Supplier" ;
      }

      public override string GetPgmdesc( )
      {
         return "Supplier" ;
      }

      protected void InitializeNonKey022( )
      {
         A5SupplierName = "";
         AssignAttri("", false, "A5SupplierName", A5SupplierName);
         A6SupplierDescription = "";
         n6SupplierDescription = false;
         AssignAttri("", false, "A6SupplierDescription", A6SupplierDescription);
         n6SupplierDescription = (String.IsNullOrEmpty(StringUtil.RTrim( A6SupplierDescription)) ? true : false);
         A7SupplierPhone = "";
         n7SupplierPhone = false;
         AssignAttri("", false, "A7SupplierPhone", A7SupplierPhone);
         n7SupplierPhone = (String.IsNullOrEmpty(StringUtil.RTrim( A7SupplierPhone)) ? true : false);
         A8SupplierEmail = "";
         n8SupplierEmail = false;
         AssignAttri("", false, "A8SupplierEmail", A8SupplierEmail);
         n8SupplierEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A8SupplierEmail)) ? true : false);
         A33SupplierModifiedDate = DateTime.MinValue;
         AssignAttri("", false, "A33SupplierModifiedDate", context.localUtil.Format(A33SupplierModifiedDate, "99/99/99"));
         A57SupplierProductQuantity = 0;
         n57SupplierProductQuantity = false;
         AssignAttri("", false, "A57SupplierProductQuantity", StringUtil.LTrimStr( (decimal)(A57SupplierProductQuantity), 4, 0));
         A32SupplierCreatedDate = Gx_date;
         AssignAttri("", false, "A32SupplierCreatedDate", context.localUtil.Format(A32SupplierCreatedDate, "99/99/99"));
         Z5SupplierName = "";
         Z6SupplierDescription = "";
         Z7SupplierPhone = "";
         Z8SupplierEmail = "";
         Z32SupplierCreatedDate = DateTime.MinValue;
         Z33SupplierModifiedDate = DateTime.MinValue;
      }

      protected void InitAll022( )
      {
         A4SupplierId = 0;
         AssignAttri("", false, "A4SupplierId", StringUtil.LTrimStr( (decimal)(A4SupplierId), 6, 0));
         InitializeNonKey022( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A32SupplierCreatedDate = i32SupplierCreatedDate;
         AssignAttri("", false, "A32SupplierCreatedDate", context.localUtil.Format(A32SupplierCreatedDate, "99/99/99"));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202311222273155", true, true);
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
         context.AddJavascriptSource("supplier.js", "?202311222273156", false, true);
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
         edtSupplierId_Internalname = "SUPPLIERID";
         edtSupplierName_Internalname = "SUPPLIERNAME";
         edtSupplierDescription_Internalname = "SUPPLIERDESCRIPTION";
         edtSupplierPhone_Internalname = "SUPPLIERPHONE";
         edtSupplierEmail_Internalname = "SUPPLIEREMAIL";
         edtSupplierCreatedDate_Internalname = "SUPPLIERCREATEDDATE";
         edtSupplierModifiedDate_Internalname = "SUPPLIERMODIFIEDDATE";
         edtSupplierProductQuantity_Internalname = "SUPPLIERPRODUCTQUANTITY";
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
         Form.Caption = "Supplier";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirm";
         bttBtn_enter_Caption = "Confirm";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtSupplierProductQuantity_Jsonclick = "";
         edtSupplierProductQuantity_Enabled = 0;
         edtSupplierModifiedDate_Jsonclick = "";
         edtSupplierModifiedDate_Enabled = 1;
         edtSupplierCreatedDate_Jsonclick = "";
         edtSupplierCreatedDate_Enabled = 0;
         edtSupplierEmail_Jsonclick = "";
         edtSupplierEmail_Enabled = 1;
         edtSupplierPhone_Jsonclick = "";
         edtSupplierPhone_Enabled = 1;
         edtSupplierDescription_Enabled = 1;
         edtSupplierName_Jsonclick = "";
         edtSupplierName_Enabled = 1;
         edtSupplierId_Jsonclick = "";
         edtSupplierId_Enabled = 0;
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

      public void Valid_Supplierid( )
      {
         n57SupplierProductQuantity = false;
         /* Using cursor T000217 */
         pr_default.execute(11, new Object[] {A4SupplierId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            A57SupplierProductQuantity = T000217_A57SupplierProductQuantity[0];
            n57SupplierProductQuantity = T000217_n57SupplierProductQuantity[0];
         }
         else
         {
            A57SupplierProductQuantity = 0;
            n57SupplierProductQuantity = false;
         }
         pr_default.close(11);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A57SupplierProductQuantity", StringUtil.LTrim( StringUtil.NToC( (decimal)(A57SupplierProductQuantity), 4, 0, ".", "")));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7SupplierId',fld:'vSUPPLIERID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7SupplierId',fld:'vSUPPLIERID',pic:'ZZZZZ9',hsh:true},{av:'A4SupplierId',fld:'SUPPLIERID',pic:'ZZZZZ9'},{av:'A32SupplierCreatedDate',fld:'SUPPLIERCREATEDDATE',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12022',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_SUPPLIERID","{handler:'Valid_Supplierid',iparms:[{av:'A4SupplierId',fld:'SUPPLIERID',pic:'ZZZZZ9'},{av:'A57SupplierProductQuantity',fld:'SUPPLIERPRODUCTQUANTITY',pic:'ZZZ9'}]");
         setEventMetadata("VALID_SUPPLIERID",",oparms:[{av:'A57SupplierProductQuantity',fld:'SUPPLIERPRODUCTQUANTITY',pic:'ZZZ9'}]}");
         setEventMetadata("VALID_SUPPLIEREMAIL","{handler:'Valid_Supplieremail',iparms:[]");
         setEventMetadata("VALID_SUPPLIEREMAIL",",oparms:[]}");
         setEventMetadata("VALID_SUPPLIERMODIFIEDDATE","{handler:'Valid_Suppliermodifieddate',iparms:[]");
         setEventMetadata("VALID_SUPPLIERMODIFIEDDATE",",oparms:[]}");
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
         Z5SupplierName = "";
         Z6SupplierDescription = "";
         Z7SupplierPhone = "";
         Z8SupplierEmail = "";
         Z32SupplierCreatedDate = DateTime.MinValue;
         Z33SupplierModifiedDate = DateTime.MinValue;
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
         A5SupplierName = "";
         A6SupplierDescription = "";
         gxphoneLink = "";
         A7SupplierPhone = "";
         A8SupplierEmail = "";
         A32SupplierCreatedDate = DateTime.MinValue;
         A33SupplierModifiedDate = DateTime.MinValue;
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_date = DateTime.MinValue;
         AV13Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode2 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         T00025_A57SupplierProductQuantity = new short[1] ;
         T00025_n57SupplierProductQuantity = new bool[] {false} ;
         T00027_A4SupplierId = new int[1] ;
         T00027_A5SupplierName = new string[] {""} ;
         T00027_A6SupplierDescription = new string[] {""} ;
         T00027_n6SupplierDescription = new bool[] {false} ;
         T00027_A7SupplierPhone = new string[] {""} ;
         T00027_n7SupplierPhone = new bool[] {false} ;
         T00027_A8SupplierEmail = new string[] {""} ;
         T00027_n8SupplierEmail = new bool[] {false} ;
         T00027_A32SupplierCreatedDate = new DateTime[] {DateTime.MinValue} ;
         T00027_A33SupplierModifiedDate = new DateTime[] {DateTime.MinValue} ;
         T00027_A57SupplierProductQuantity = new short[1] ;
         T00027_n57SupplierProductQuantity = new bool[] {false} ;
         T00029_A57SupplierProductQuantity = new short[1] ;
         T00029_n57SupplierProductQuantity = new bool[] {false} ;
         T000210_A4SupplierId = new int[1] ;
         T00023_A4SupplierId = new int[1] ;
         T00023_A5SupplierName = new string[] {""} ;
         T00023_A6SupplierDescription = new string[] {""} ;
         T00023_n6SupplierDescription = new bool[] {false} ;
         T00023_A7SupplierPhone = new string[] {""} ;
         T00023_n7SupplierPhone = new bool[] {false} ;
         T00023_A8SupplierEmail = new string[] {""} ;
         T00023_n8SupplierEmail = new bool[] {false} ;
         T00023_A32SupplierCreatedDate = new DateTime[] {DateTime.MinValue} ;
         T00023_A33SupplierModifiedDate = new DateTime[] {DateTime.MinValue} ;
         T000211_A4SupplierId = new int[1] ;
         T000212_A4SupplierId = new int[1] ;
         T00022_A4SupplierId = new int[1] ;
         T00022_A5SupplierName = new string[] {""} ;
         T00022_A6SupplierDescription = new string[] {""} ;
         T00022_n6SupplierDescription = new bool[] {false} ;
         T00022_A7SupplierPhone = new string[] {""} ;
         T00022_n7SupplierPhone = new bool[] {false} ;
         T00022_A8SupplierEmail = new string[] {""} ;
         T00022_n8SupplierEmail = new bool[] {false} ;
         T00022_A32SupplierCreatedDate = new DateTime[] {DateTime.MinValue} ;
         T00022_A33SupplierModifiedDate = new DateTime[] {DateTime.MinValue} ;
         T000213_A4SupplierId = new int[1] ;
         T000217_A57SupplierProductQuantity = new short[1] ;
         T000217_n57SupplierProductQuantity = new bool[] {false} ;
         T000218_A50PurchaseOrderId = new int[1] ;
         T000219_A15ProductId = new int[1] ;
         T000220_A4SupplierId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i32SupplierCreatedDate = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.supplier__default(),
            new Object[][] {
                new Object[] {
               T00022_A4SupplierId, T00022_A5SupplierName, T00022_A6SupplierDescription, T00022_n6SupplierDescription, T00022_A7SupplierPhone, T00022_n7SupplierPhone, T00022_A8SupplierEmail, T00022_n8SupplierEmail, T00022_A32SupplierCreatedDate, T00022_A33SupplierModifiedDate
               }
               , new Object[] {
               T00023_A4SupplierId, T00023_A5SupplierName, T00023_A6SupplierDescription, T00023_n6SupplierDescription, T00023_A7SupplierPhone, T00023_n7SupplierPhone, T00023_A8SupplierEmail, T00023_n8SupplierEmail, T00023_A32SupplierCreatedDate, T00023_A33SupplierModifiedDate
               }
               , new Object[] {
               T00025_A57SupplierProductQuantity, T00025_n57SupplierProductQuantity
               }
               , new Object[] {
               T00027_A4SupplierId, T00027_A5SupplierName, T00027_A6SupplierDescription, T00027_n6SupplierDescription, T00027_A7SupplierPhone, T00027_n7SupplierPhone, T00027_A8SupplierEmail, T00027_n8SupplierEmail, T00027_A32SupplierCreatedDate, T00027_A33SupplierModifiedDate,
               T00027_A57SupplierProductQuantity, T00027_n57SupplierProductQuantity
               }
               , new Object[] {
               T00029_A57SupplierProductQuantity, T00029_n57SupplierProductQuantity
               }
               , new Object[] {
               T000210_A4SupplierId
               }
               , new Object[] {
               T000211_A4SupplierId
               }
               , new Object[] {
               T000212_A4SupplierId
               }
               , new Object[] {
               T000213_A4SupplierId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000217_A57SupplierProductQuantity, T000217_n57SupplierProductQuantity
               }
               , new Object[] {
               T000218_A50PurchaseOrderId
               }
               , new Object[] {
               T000219_A15ProductId
               }
               , new Object[] {
               T000220_A4SupplierId
               }
            }
         );
         AV13Pgmname = "Supplier";
         Z32SupplierCreatedDate = DateTime.MinValue;
         A32SupplierCreatedDate = DateTime.MinValue;
         i32SupplierCreatedDate = DateTime.MinValue;
         Gx_date = DateTimeUtil.Today( context);
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A57SupplierProductQuantity ;
      private short Gx_BScreen ;
      private short RcdFound2 ;
      private short GX_JID ;
      private short Z57SupplierProductQuantity ;
      private short nIsDirty_2 ;
      private short gxajaxcallmode ;
      private int wcpOAV7SupplierId ;
      private int Z4SupplierId ;
      private int A4SupplierId ;
      private int AV7SupplierId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtSupplierId_Enabled ;
      private int edtSupplierName_Enabled ;
      private int edtSupplierDescription_Enabled ;
      private int edtSupplierPhone_Enabled ;
      private int edtSupplierEmail_Enabled ;
      private int edtSupplierCreatedDate_Enabled ;
      private int edtSupplierModifiedDate_Enabled ;
      private int edtSupplierProductQuantity_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z7SupplierPhone ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtSupplierName_Internalname ;
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
      private string edtSupplierId_Internalname ;
      private string edtSupplierId_Jsonclick ;
      private string edtSupplierName_Jsonclick ;
      private string edtSupplierDescription_Internalname ;
      private string edtSupplierPhone_Internalname ;
      private string gxphoneLink ;
      private string A7SupplierPhone ;
      private string edtSupplierPhone_Jsonclick ;
      private string edtSupplierEmail_Internalname ;
      private string edtSupplierEmail_Jsonclick ;
      private string edtSupplierCreatedDate_Internalname ;
      private string edtSupplierCreatedDate_Jsonclick ;
      private string edtSupplierModifiedDate_Internalname ;
      private string edtSupplierModifiedDate_Jsonclick ;
      private string edtSupplierProductQuantity_Internalname ;
      private string edtSupplierProductQuantity_Jsonclick ;
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
      private string sMode2 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z32SupplierCreatedDate ;
      private DateTime Z33SupplierModifiedDate ;
      private DateTime A32SupplierCreatedDate ;
      private DateTime A33SupplierModifiedDate ;
      private DateTime Gx_date ;
      private DateTime i32SupplierCreatedDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n6SupplierDescription ;
      private bool n7SupplierPhone ;
      private bool n8SupplierEmail ;
      private bool n57SupplierProductQuantity ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string Z5SupplierName ;
      private string Z6SupplierDescription ;
      private string Z8SupplierEmail ;
      private string A5SupplierName ;
      private string A6SupplierDescription ;
      private string A8SupplierEmail ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T00025_A57SupplierProductQuantity ;
      private bool[] T00025_n57SupplierProductQuantity ;
      private int[] T00027_A4SupplierId ;
      private string[] T00027_A5SupplierName ;
      private string[] T00027_A6SupplierDescription ;
      private bool[] T00027_n6SupplierDescription ;
      private string[] T00027_A7SupplierPhone ;
      private bool[] T00027_n7SupplierPhone ;
      private string[] T00027_A8SupplierEmail ;
      private bool[] T00027_n8SupplierEmail ;
      private DateTime[] T00027_A32SupplierCreatedDate ;
      private DateTime[] T00027_A33SupplierModifiedDate ;
      private short[] T00027_A57SupplierProductQuantity ;
      private bool[] T00027_n57SupplierProductQuantity ;
      private short[] T00029_A57SupplierProductQuantity ;
      private bool[] T00029_n57SupplierProductQuantity ;
      private int[] T000210_A4SupplierId ;
      private int[] T00023_A4SupplierId ;
      private string[] T00023_A5SupplierName ;
      private string[] T00023_A6SupplierDescription ;
      private bool[] T00023_n6SupplierDescription ;
      private string[] T00023_A7SupplierPhone ;
      private bool[] T00023_n7SupplierPhone ;
      private string[] T00023_A8SupplierEmail ;
      private bool[] T00023_n8SupplierEmail ;
      private DateTime[] T00023_A32SupplierCreatedDate ;
      private DateTime[] T00023_A33SupplierModifiedDate ;
      private int[] T000211_A4SupplierId ;
      private int[] T000212_A4SupplierId ;
      private int[] T00022_A4SupplierId ;
      private string[] T00022_A5SupplierName ;
      private string[] T00022_A6SupplierDescription ;
      private bool[] T00022_n6SupplierDescription ;
      private string[] T00022_A7SupplierPhone ;
      private bool[] T00022_n7SupplierPhone ;
      private string[] T00022_A8SupplierEmail ;
      private bool[] T00022_n8SupplierEmail ;
      private DateTime[] T00022_A32SupplierCreatedDate ;
      private DateTime[] T00022_A33SupplierModifiedDate ;
      private int[] T000213_A4SupplierId ;
      private short[] T000217_A57SupplierProductQuantity ;
      private bool[] T000217_n57SupplierProductQuantity ;
      private int[] T000218_A50PurchaseOrderId ;
      private int[] T000219_A15ProductId ;
      private int[] T000220_A4SupplierId ;
      private GXWebForm Form ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
   }

   public class supplier__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[14])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00027;
          prmT00027 = new Object[] {
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          Object[] prmT00025;
          prmT00025 = new Object[] {
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          Object[] prmT00029;
          prmT00029 = new Object[] {
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          Object[] prmT000210;
          prmT000210 = new Object[] {
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          Object[] prmT00023;
          prmT00023 = new Object[] {
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          Object[] prmT000211;
          prmT000211 = new Object[] {
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          Object[] prmT000212;
          prmT000212 = new Object[] {
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          Object[] prmT00022;
          prmT00022 = new Object[] {
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          Object[] prmT000213;
          prmT000213 = new Object[] {
          new ParDef("@SupplierName",GXType.NVarChar,60,0) ,
          new ParDef("@SupplierDescription",GXType.NVarChar,200,0){Nullable=true} ,
          new ParDef("@SupplierPhone",GXType.NChar,20,0){Nullable=true} ,
          new ParDef("@SupplierEmail",GXType.NVarChar,100,0){Nullable=true} ,
          new ParDef("@SupplierCreatedDate",GXType.Date,8,0) ,
          new ParDef("@SupplierModifiedDate",GXType.Date,8,0)
          };
          Object[] prmT000214;
          prmT000214 = new Object[] {
          new ParDef("@SupplierName",GXType.NVarChar,60,0) ,
          new ParDef("@SupplierDescription",GXType.NVarChar,200,0){Nullable=true} ,
          new ParDef("@SupplierPhone",GXType.NChar,20,0){Nullable=true} ,
          new ParDef("@SupplierEmail",GXType.NVarChar,100,0){Nullable=true} ,
          new ParDef("@SupplierCreatedDate",GXType.Date,8,0) ,
          new ParDef("@SupplierModifiedDate",GXType.Date,8,0) ,
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          Object[] prmT000215;
          prmT000215 = new Object[] {
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          Object[] prmT000218;
          prmT000218 = new Object[] {
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          Object[] prmT000219;
          prmT000219 = new Object[] {
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          Object[] prmT000220;
          prmT000220 = new Object[] {
          };
          Object[] prmT000217;
          prmT000217 = new Object[] {
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00022", "SELECT [SupplierId], [SupplierName], [SupplierDescription], [SupplierPhone], [SupplierEmail], [SupplierCreatedDate], [SupplierModifiedDate] FROM [Supplier] WITH (UPDLOCK) WHERE [SupplierId] = @SupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00022,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00023", "SELECT [SupplierId], [SupplierName], [SupplierDescription], [SupplierPhone], [SupplierEmail], [SupplierCreatedDate], [SupplierModifiedDate] FROM [Supplier] WHERE [SupplierId] = @SupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00023,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00025", "SELECT COALESCE( T1.[SupplierProductQuantity], 0) AS SupplierProductQuantity FROM (SELECT COUNT(*) AS SupplierProductQuantity, [SupplierId] FROM [Product] GROUP BY [SupplierId] ) T1 WHERE T1.[SupplierId] = @SupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00025,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00027", "SELECT TM1.[SupplierId], TM1.[SupplierName], TM1.[SupplierDescription], TM1.[SupplierPhone], TM1.[SupplierEmail], TM1.[SupplierCreatedDate], TM1.[SupplierModifiedDate], COALESCE( T2.[SupplierProductQuantity], 0) AS SupplierProductQuantity FROM ([Supplier] TM1 LEFT JOIN (SELECT COUNT(*) AS SupplierProductQuantity, [SupplierId] FROM [Product] GROUP BY [SupplierId] ) T2 ON T2.[SupplierId] = TM1.[SupplierId]) WHERE TM1.[SupplierId] = @SupplierId ORDER BY TM1.[SupplierId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00027,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00029", "SELECT COALESCE( T1.[SupplierProductQuantity], 0) AS SupplierProductQuantity FROM (SELECT COUNT(*) AS SupplierProductQuantity, [SupplierId] FROM [Product] GROUP BY [SupplierId] ) T1 WHERE T1.[SupplierId] = @SupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00029,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000210", "SELECT [SupplierId] FROM [Supplier] WHERE [SupplierId] = @SupplierId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000210,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000211", "SELECT TOP 1 [SupplierId] FROM [Supplier] WHERE ( [SupplierId] > @SupplierId) ORDER BY [SupplierId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000211,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000212", "SELECT TOP 1 [SupplierId] FROM [Supplier] WHERE ( [SupplierId] < @SupplierId) ORDER BY [SupplierId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000212,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000213", "INSERT INTO [Supplier]([SupplierName], [SupplierDescription], [SupplierPhone], [SupplierEmail], [SupplierCreatedDate], [SupplierModifiedDate]) VALUES(@SupplierName, @SupplierDescription, @SupplierPhone, @SupplierEmail, @SupplierCreatedDate, @SupplierModifiedDate); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000213,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000214", "UPDATE [Supplier] SET [SupplierName]=@SupplierName, [SupplierDescription]=@SupplierDescription, [SupplierPhone]=@SupplierPhone, [SupplierEmail]=@SupplierEmail, [SupplierCreatedDate]=@SupplierCreatedDate, [SupplierModifiedDate]=@SupplierModifiedDate  WHERE [SupplierId] = @SupplierId", GxErrorMask.GX_NOMASK,prmT000214)
             ,new CursorDef("T000215", "DELETE FROM [Supplier]  WHERE [SupplierId] = @SupplierId", GxErrorMask.GX_NOMASK,prmT000215)
             ,new CursorDef("T000217", "SELECT COALESCE( T1.[SupplierProductQuantity], 0) AS SupplierProductQuantity FROM (SELECT COUNT(*) AS SupplierProductQuantity, [SupplierId] FROM [Product] GROUP BY [SupplierId] ) T1 WHERE T1.[SupplierId] = @SupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000217,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000218", "SELECT TOP 1 [PurchaseOrderId] FROM [PurchaseOrder] WHERE [SupplierId] = @SupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000218,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000219", "SELECT TOP 1 [ProductId] FROM [Product] WHERE [SupplierId] = @SupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000219,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000220", "SELECT [SupplierId] FROM [Supplier] ORDER BY [SupplierId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000220,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[4])[0] = rslt.getString(4, 20);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(6);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(7);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 20);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(6);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(7);
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
                ((string[]) buf[4])[0] = rslt.getString(4, 20);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(6);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(7);
                ((short[]) buf[10])[0] = rslt.getShort(8);
                ((bool[]) buf[11])[0] = rslt.wasNull(8);
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
             case 14 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
