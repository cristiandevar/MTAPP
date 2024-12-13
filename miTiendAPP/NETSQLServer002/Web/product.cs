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
   public class product : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_18") == 0 )
         {
            A1BrandId = (int)(Math.Round(NumberUtil.Val( GetPar( "BrandId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A1BrandId", StringUtil.LTrimStr( (decimal)(A1BrandId), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_18( A1BrandId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_19") == 0 )
         {
            A9SectorId = (int)(Math.Round(NumberUtil.Val( GetPar( "SectorId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A9SectorId", StringUtil.LTrimStr( (decimal)(A9SectorId), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_19( A9SectorId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_20") == 0 )
         {
            A4SupplierId = (int)(Math.Round(NumberUtil.Val( GetPar( "SupplierId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A4SupplierId", StringUtil.LTrimStr( (decimal)(A4SupplierId), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_20( A4SupplierId) ;
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
               AV7ProductId = (int)(Math.Round(NumberUtil.Val( GetPar( "ProductId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7ProductId", StringUtil.LTrimStr( (decimal)(AV7ProductId), 6, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vPRODUCTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ProductId), "ZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Product", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtProductCode_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("mtaKB", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public product( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public product( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_ProductId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ProductId = aP1_ProductId;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Product", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Product.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Product.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtProductId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", "")), StringUtil.LTrim( ((edtProductId_Enabled!=0) ? context.localUtil.Format( (decimal)(A15ProductId), "ZZZZZ9") : context.localUtil.Format( (decimal)(A15ProductId), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductId_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductCode_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductCode_Internalname, "Code", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductCode_Internalname, A55ProductCode, StringUtil.RTrim( context.localUtil.Format( A55ProductCode, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductCode_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductCode_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "GeneXusUnanimo\\Code", "left", true, "", "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductName_Internalname, "Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductName_Internalname, A16ProductName, StringUtil.RTrim( context.localUtil.Format( A16ProductName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductName_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Name", "left", true, "", "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductStock_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductStock_Internalname, "Stock", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductStock_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A17ProductStock), 6, 0, ".", "")), StringUtil.LTrim( ((edtProductStock_Enabled!=0) ? context.localUtil.Format( (decimal)(A17ProductStock), "ZZZZZ9") : context.localUtil.Format( (decimal)(A17ProductStock), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductStock_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductStock_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductPrice_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductPrice_Internalname, "Price", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductPrice_Internalname, StringUtil.LTrim( StringUtil.NToC( A18ProductPrice, 10, 2, ".", "")), StringUtil.LTrim( ((edtProductPrice_Enabled!=0) ? context.localUtil.Format( A18ProductPrice, "ZZZZZZ9.99") : context.localUtil.Format( A18ProductPrice, "ZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductPrice_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductPrice_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "Price", "right", false, "", "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductDescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductDescription_Internalname, "Description", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtProductDescription_Internalname, A19ProductDescription, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", 0, 1, edtProductDescription_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "GeneXusUnanimo\\Description", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtBrandId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtBrandId_Internalname, "Brand Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtBrandId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1BrandId), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A1BrandId), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBrandId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtBrandId_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_Product.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_1_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_1_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_1_Internalname, sImgUrl, imgprompt_1_Link, "", "", context.GetTheme( ), imgprompt_1_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Product.htm");
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
         GxWebStd.gx_label_element( context, edtBrandName_Internalname, "Brand Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtBrandName_Internalname, A2BrandName, StringUtil.RTrim( context.localUtil.Format( A2BrandName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBrandName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtBrandName_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Name", "left", true, "", "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSectorId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSectorId_Internalname, "Sector Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSectorId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A9SectorId), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A9SectorId), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSectorId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSectorId_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_Product.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_9_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_9_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_9_Internalname, sImgUrl, imgprompt_9_Link, "", "", context.GetTheme( ), imgprompt_9_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Product.htm");
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
         GxWebStd.gx_label_element( context, edtSectorName_Internalname, "Sector Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtSectorName_Internalname, A10SectorName, StringUtil.RTrim( context.localUtil.Format( A10SectorName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSectorName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSectorName_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Name", "left", true, "", "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSupplierId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierId_Internalname, "Supplier Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A4SupplierId), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A4SupplierId), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierId_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_Product.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_4_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_4_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_4_Internalname, sImgUrl, imgprompt_4_Link, "", "", context.GetTheme( ), imgprompt_4_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Product.htm");
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
         GxWebStd.gx_label_element( context, edtSupplierName_Internalname, "Supplier Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtSupplierName_Internalname, A5SupplierName, StringUtil.RTrim( context.localUtil.Format( A5SupplierName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierName_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Name", "left", true, "", "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductCreatedDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductCreatedDate_Internalname, "Created Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         context.WriteHtmlText( "<div id=\""+edtProductCreatedDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtProductCreatedDate_Internalname, context.localUtil.Format(A28ProductCreatedDate, "99/99/99"), context.localUtil.Format( A28ProductCreatedDate, "99/99/99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductCreatedDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductCreatedDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Product.htm");
         GxWebStd.gx_bitmap( context, edtProductCreatedDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtProductCreatedDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Product.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductModifiedDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductModifiedDate_Internalname, "Modified Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtProductModifiedDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtProductModifiedDate_Internalname, context.localUtil.Format(A29ProductModifiedDate, "99/99/99"), context.localUtil.Format( A29ProductModifiedDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductModifiedDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductModifiedDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Product.htm");
         GxWebStd.gx_bitmap( context, edtProductModifiedDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtProductModifiedDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Product.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Product.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Product.htm");
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
         E11052 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z15ProductId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z15ProductId"), ".", ","), 18, MidpointRounding.ToEven));
               Z55ProductCode = cgiGet( "Z55ProductCode");
               n55ProductCode = (String.IsNullOrEmpty(StringUtil.RTrim( A55ProductCode)) ? true : false);
               Z16ProductName = cgiGet( "Z16ProductName");
               Z17ProductStock = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z17ProductStock"), ".", ","), 18, MidpointRounding.ToEven));
               Z18ProductPrice = context.localUtil.CToN( cgiGet( "Z18ProductPrice"), ".", ",");
               Z19ProductDescription = cgiGet( "Z19ProductDescription");
               n19ProductDescription = (String.IsNullOrEmpty(StringUtil.RTrim( A19ProductDescription)) ? true : false);
               Z28ProductCreatedDate = context.localUtil.CToD( cgiGet( "Z28ProductCreatedDate"), 0);
               Z29ProductModifiedDate = context.localUtil.CToD( cgiGet( "Z29ProductModifiedDate"), 0);
               n29ProductModifiedDate = ((DateTime.MinValue==A29ProductModifiedDate) ? true : false);
               Z1BrandId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z1BrandId"), ".", ","), 18, MidpointRounding.ToEven));
               Z9SectorId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z9SectorId"), ".", ","), 18, MidpointRounding.ToEven));
               Z4SupplierId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z4SupplierId"), ".", ","), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N1BrandId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N1BrandId"), ".", ","), 18, MidpointRounding.ToEven));
               N9SectorId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N9SectorId"), ".", ","), 18, MidpointRounding.ToEven));
               N4SupplierId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N4SupplierId"), ".", ","), 18, MidpointRounding.ToEven));
               AV7ProductId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vPRODUCTID"), ".", ","), 18, MidpointRounding.ToEven));
               AV11Insert_BrandId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_BRANDID"), ".", ","), 18, MidpointRounding.ToEven));
               AV12Insert_SectorId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_SECTORID"), ".", ","), 18, MidpointRounding.ToEven));
               AV13Insert_SupplierId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_SUPPLIERID"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_date = context.localUtil.CToD( cgiGet( "vTODAY"), 0);
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","), 18, MidpointRounding.ToEven));
               AV17Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A15ProductId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtProductId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A15ProductId", StringUtil.LTrimStr( (decimal)(A15ProductId), 6, 0));
               A55ProductCode = cgiGet( edtProductCode_Internalname);
               n55ProductCode = false;
               AssignAttri("", false, "A55ProductCode", A55ProductCode);
               n55ProductCode = (String.IsNullOrEmpty(StringUtil.RTrim( A55ProductCode)) ? true : false);
               A16ProductName = cgiGet( edtProductName_Internalname);
               AssignAttri("", false, "A16ProductName", A16ProductName);
               if ( ( ( context.localUtil.CToN( cgiGet( edtProductStock_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProductStock_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODUCTSTOCK");
                  AnyError = 1;
                  GX_FocusControl = edtProductStock_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A17ProductStock = 0;
                  AssignAttri("", false, "A17ProductStock", StringUtil.LTrimStr( (decimal)(A17ProductStock), 6, 0));
               }
               else
               {
                  A17ProductStock = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtProductStock_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A17ProductStock", StringUtil.LTrimStr( (decimal)(A17ProductStock), 6, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtProductPrice_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProductPrice_Internalname), ".", ",") > 9999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODUCTPRICE");
                  AnyError = 1;
                  GX_FocusControl = edtProductPrice_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A18ProductPrice = 0;
                  AssignAttri("", false, "A18ProductPrice", StringUtil.LTrimStr( A18ProductPrice, 10, 2));
               }
               else
               {
                  A18ProductPrice = context.localUtil.CToN( cgiGet( edtProductPrice_Internalname), ".", ",");
                  AssignAttri("", false, "A18ProductPrice", StringUtil.LTrimStr( A18ProductPrice, 10, 2));
               }
               A19ProductDescription = cgiGet( edtProductDescription_Internalname);
               n19ProductDescription = false;
               AssignAttri("", false, "A19ProductDescription", A19ProductDescription);
               n19ProductDescription = (String.IsNullOrEmpty(StringUtil.RTrim( A19ProductDescription)) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtBrandId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtBrandId_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "BRANDID");
                  AnyError = 1;
                  GX_FocusControl = edtBrandId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1BrandId = 0;
                  AssignAttri("", false, "A1BrandId", StringUtil.LTrimStr( (decimal)(A1BrandId), 6, 0));
               }
               else
               {
                  A1BrandId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtBrandId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A1BrandId", StringUtil.LTrimStr( (decimal)(A1BrandId), 6, 0));
               }
               A2BrandName = cgiGet( edtBrandName_Internalname);
               AssignAttri("", false, "A2BrandName", A2BrandName);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSectorId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSectorId_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SECTORID");
                  AnyError = 1;
                  GX_FocusControl = edtSectorId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A9SectorId = 0;
                  AssignAttri("", false, "A9SectorId", StringUtil.LTrimStr( (decimal)(A9SectorId), 6, 0));
               }
               else
               {
                  A9SectorId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtSectorId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A9SectorId", StringUtil.LTrimStr( (decimal)(A9SectorId), 6, 0));
               }
               A10SectorName = cgiGet( edtSectorName_Internalname);
               AssignAttri("", false, "A10SectorName", A10SectorName);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSupplierId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSupplierId_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SUPPLIERID");
                  AnyError = 1;
                  GX_FocusControl = edtSupplierId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A4SupplierId = 0;
                  AssignAttri("", false, "A4SupplierId", StringUtil.LTrimStr( (decimal)(A4SupplierId), 6, 0));
               }
               else
               {
                  A4SupplierId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtSupplierId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A4SupplierId", StringUtil.LTrimStr( (decimal)(A4SupplierId), 6, 0));
               }
               A5SupplierName = cgiGet( edtSupplierName_Internalname);
               AssignAttri("", false, "A5SupplierName", A5SupplierName);
               A28ProductCreatedDate = context.localUtil.CToD( cgiGet( edtProductCreatedDate_Internalname), 1);
               AssignAttri("", false, "A28ProductCreatedDate", context.localUtil.Format(A28ProductCreatedDate, "99/99/99"));
               if ( context.localUtil.VCDate( cgiGet( edtProductModifiedDate_Internalname), 1) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Product Modified Date"}), 1, "PRODUCTMODIFIEDDATE");
                  AnyError = 1;
                  GX_FocusControl = edtProductModifiedDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A29ProductModifiedDate = DateTime.MinValue;
                  n29ProductModifiedDate = false;
                  AssignAttri("", false, "A29ProductModifiedDate", context.localUtil.Format(A29ProductModifiedDate, "99/99/99"));
               }
               else
               {
                  A29ProductModifiedDate = context.localUtil.CToD( cgiGet( edtProductModifiedDate_Internalname), 1);
                  n29ProductModifiedDate = false;
                  AssignAttri("", false, "A29ProductModifiedDate", context.localUtil.Format(A29ProductModifiedDate, "99/99/99"));
               }
               n29ProductModifiedDate = ((DateTime.MinValue==A29ProductModifiedDate) ? true : false);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Product");
               A15ProductId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtProductId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A15ProductId", StringUtil.LTrimStr( (decimal)(A15ProductId), 6, 0));
               forbiddenHiddens.Add("ProductId", context.localUtil.Format( (decimal)(A15ProductId), "ZZZZZ9"));
               A28ProductCreatedDate = context.localUtil.CToD( cgiGet( edtProductCreatedDate_Internalname), 1);
               AssignAttri("", false, "A28ProductCreatedDate", context.localUtil.Format(A28ProductCreatedDate, "99/99/99"));
               forbiddenHiddens.Add("ProductCreatedDate", context.localUtil.Format(A28ProductCreatedDate, "99/99/99"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A15ProductId != Z15ProductId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("product:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A15ProductId = (int)(Math.Round(NumberUtil.Val( GetPar( "ProductId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A15ProductId", StringUtil.LTrimStr( (decimal)(A15ProductId), 6, 0));
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
                     sMode5 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode5;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound5 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_050( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "PRODUCTID");
                        AnyError = 1;
                        GX_FocusControl = edtProductId_Internalname;
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
                           E11052 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12052 ();
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
            E12052 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll055( ) ;
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
            DisableAttributes055( ) ;
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

      protected void CONFIRM_050( )
      {
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls055( ) ;
            }
            else
            {
               CheckExtendedTable055( ) ;
               CloseExtendedTableCursors055( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption050( )
      {
      }

      protected void E11052( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV17Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV17Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         AV11Insert_BrandId = 0;
         AssignAttri("", false, "AV11Insert_BrandId", StringUtil.LTrimStr( (decimal)(AV11Insert_BrandId), 6, 0));
         AV12Insert_SectorId = 0;
         AssignAttri("", false, "AV12Insert_SectorId", StringUtil.LTrimStr( (decimal)(AV12Insert_SectorId), 6, 0));
         AV13Insert_SupplierId = 0;
         AssignAttri("", false, "AV13Insert_SupplierId", StringUtil.LTrimStr( (decimal)(AV13Insert_SupplierId), 6, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV17Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV18GXV1 = 1;
            AssignAttri("", false, "AV18GXV1", StringUtil.LTrimStr( (decimal)(AV18GXV1), 8, 0));
            while ( AV18GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((GeneXus.Programs.general.ui.SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV18GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "BrandId") == 0 )
               {
                  AV11Insert_BrandId = (int)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_BrandId", StringUtil.LTrimStr( (decimal)(AV11Insert_BrandId), 6, 0));
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "SectorId") == 0 )
               {
                  AV12Insert_SectorId = (int)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV12Insert_SectorId", StringUtil.LTrimStr( (decimal)(AV12Insert_SectorId), 6, 0));
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "SupplierId") == 0 )
               {
                  AV13Insert_SupplierId = (int)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13Insert_SupplierId", StringUtil.LTrimStr( (decimal)(AV13Insert_SupplierId), 6, 0));
               }
               AV18GXV1 = (int)(AV18GXV1+1);
               AssignAttri("", false, "AV18GXV1", StringUtil.LTrimStr( (decimal)(AV18GXV1), 8, 0));
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

      protected void E12052( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwproduct.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM055( short GX_JID )
      {
         if ( ( GX_JID == 17 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z55ProductCode = T00053_A55ProductCode[0];
               Z16ProductName = T00053_A16ProductName[0];
               Z17ProductStock = T00053_A17ProductStock[0];
               Z18ProductPrice = T00053_A18ProductPrice[0];
               Z19ProductDescription = T00053_A19ProductDescription[0];
               Z28ProductCreatedDate = T00053_A28ProductCreatedDate[0];
               Z29ProductModifiedDate = T00053_A29ProductModifiedDate[0];
               Z1BrandId = T00053_A1BrandId[0];
               Z9SectorId = T00053_A9SectorId[0];
               Z4SupplierId = T00053_A4SupplierId[0];
            }
            else
            {
               Z55ProductCode = A55ProductCode;
               Z16ProductName = A16ProductName;
               Z17ProductStock = A17ProductStock;
               Z18ProductPrice = A18ProductPrice;
               Z19ProductDescription = A19ProductDescription;
               Z28ProductCreatedDate = A28ProductCreatedDate;
               Z29ProductModifiedDate = A29ProductModifiedDate;
               Z1BrandId = A1BrandId;
               Z9SectorId = A9SectorId;
               Z4SupplierId = A4SupplierId;
            }
         }
         if ( GX_JID == -17 )
         {
            Z15ProductId = A15ProductId;
            Z55ProductCode = A55ProductCode;
            Z16ProductName = A16ProductName;
            Z17ProductStock = A17ProductStock;
            Z18ProductPrice = A18ProductPrice;
            Z19ProductDescription = A19ProductDescription;
            Z28ProductCreatedDate = A28ProductCreatedDate;
            Z29ProductModifiedDate = A29ProductModifiedDate;
            Z1BrandId = A1BrandId;
            Z9SectorId = A9SectorId;
            Z4SupplierId = A4SupplierId;
            Z2BrandName = A2BrandName;
            Z10SectorName = A10SectorName;
            Z5SupplierName = A5SupplierName;
         }
      }

      protected void standaloneNotModal( )
      {
         edtProductId_Enabled = 0;
         AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), true);
         edtProductCreatedDate_Enabled = 0;
         AssignProp("", false, edtProductCreatedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductCreatedDate_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         Gx_date = DateTimeUtil.Today( context);
         AssignAttri("", false, "Gx_date", context.localUtil.Format(Gx_date, "99/99/99"));
         imgprompt_1_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"BRANDID"+"'), id:'"+"BRANDID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_9_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0030.aspx"+"',["+"{Ctrl:gx.dom.el('"+"SECTORID"+"'), id:'"+"SECTORID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_4_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0020.aspx"+"',["+"{Ctrl:gx.dom.el('"+"SUPPLIERID"+"'), id:'"+"SUPPLIERID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtProductId_Enabled = 0;
         AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), true);
         edtProductCreatedDate_Enabled = 0;
         AssignProp("", false, edtProductCreatedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductCreatedDate_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7ProductId) )
         {
            A15ProductId = AV7ProductId;
            AssignAttri("", false, "A15ProductId", StringUtil.LTrimStr( (decimal)(A15ProductId), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_BrandId) )
         {
            edtBrandId_Enabled = 0;
            AssignProp("", false, edtBrandId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBrandId_Enabled), 5, 0), true);
         }
         else
         {
            edtBrandId_Enabled = 1;
            AssignProp("", false, edtBrandId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBrandId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_SectorId) )
         {
            edtSectorId_Enabled = 0;
            AssignProp("", false, edtSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorId_Enabled), 5, 0), true);
         }
         else
         {
            edtSectorId_Enabled = 1;
            AssignProp("", false, edtSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_SupplierId) )
         {
            edtSupplierId_Enabled = 0;
            AssignProp("", false, edtSupplierId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierId_Enabled), 5, 0), true);
         }
         else
         {
            edtSupplierId_Enabled = 1;
            AssignProp("", false, edtSupplierId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_SupplierId) )
         {
            A4SupplierId = AV13Insert_SupplierId;
            AssignAttri("", false, "A4SupplierId", StringUtil.LTrimStr( (decimal)(A4SupplierId), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_SectorId) )
         {
            A9SectorId = AV12Insert_SectorId;
            AssignAttri("", false, "A9SectorId", StringUtil.LTrimStr( (decimal)(A9SectorId), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_BrandId) )
         {
            A1BrandId = AV11Insert_BrandId;
            AssignAttri("", false, "A1BrandId", StringUtil.LTrimStr( (decimal)(A1BrandId), 6, 0));
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
         if ( IsIns( )  && (DateTime.MinValue==A28ProductCreatedDate) && ( Gx_BScreen == 0 ) )
         {
            A28ProductCreatedDate = Gx_date;
            AssignAttri("", false, "A28ProductCreatedDate", context.localUtil.Format(A28ProductCreatedDate, "99/99/99"));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV17Pgmname = "Product";
            AssignAttri("", false, "AV17Pgmname", AV17Pgmname);
            /* Using cursor T00056 */
            pr_default.execute(4, new Object[] {A4SupplierId});
            A5SupplierName = T00056_A5SupplierName[0];
            AssignAttri("", false, "A5SupplierName", A5SupplierName);
            pr_default.close(4);
            /* Using cursor T00055 */
            pr_default.execute(3, new Object[] {A9SectorId});
            A10SectorName = T00055_A10SectorName[0];
            AssignAttri("", false, "A10SectorName", A10SectorName);
            pr_default.close(3);
            /* Using cursor T00054 */
            pr_default.execute(2, new Object[] {A1BrandId});
            A2BrandName = T00054_A2BrandName[0];
            AssignAttri("", false, "A2BrandName", A2BrandName);
            pr_default.close(2);
         }
      }

      protected void Load055( )
      {
         /* Using cursor T00057 */
         pr_default.execute(5, new Object[] {A15ProductId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound5 = 1;
            A55ProductCode = T00057_A55ProductCode[0];
            n55ProductCode = T00057_n55ProductCode[0];
            AssignAttri("", false, "A55ProductCode", A55ProductCode);
            A16ProductName = T00057_A16ProductName[0];
            AssignAttri("", false, "A16ProductName", A16ProductName);
            A17ProductStock = T00057_A17ProductStock[0];
            AssignAttri("", false, "A17ProductStock", StringUtil.LTrimStr( (decimal)(A17ProductStock), 6, 0));
            A18ProductPrice = T00057_A18ProductPrice[0];
            AssignAttri("", false, "A18ProductPrice", StringUtil.LTrimStr( A18ProductPrice, 10, 2));
            A19ProductDescription = T00057_A19ProductDescription[0];
            n19ProductDescription = T00057_n19ProductDescription[0];
            AssignAttri("", false, "A19ProductDescription", A19ProductDescription);
            A2BrandName = T00057_A2BrandName[0];
            AssignAttri("", false, "A2BrandName", A2BrandName);
            A10SectorName = T00057_A10SectorName[0];
            AssignAttri("", false, "A10SectorName", A10SectorName);
            A5SupplierName = T00057_A5SupplierName[0];
            AssignAttri("", false, "A5SupplierName", A5SupplierName);
            A28ProductCreatedDate = T00057_A28ProductCreatedDate[0];
            AssignAttri("", false, "A28ProductCreatedDate", context.localUtil.Format(A28ProductCreatedDate, "99/99/99"));
            A29ProductModifiedDate = T00057_A29ProductModifiedDate[0];
            n29ProductModifiedDate = T00057_n29ProductModifiedDate[0];
            AssignAttri("", false, "A29ProductModifiedDate", context.localUtil.Format(A29ProductModifiedDate, "99/99/99"));
            A1BrandId = T00057_A1BrandId[0];
            AssignAttri("", false, "A1BrandId", StringUtil.LTrimStr( (decimal)(A1BrandId), 6, 0));
            A9SectorId = T00057_A9SectorId[0];
            AssignAttri("", false, "A9SectorId", StringUtil.LTrimStr( (decimal)(A9SectorId), 6, 0));
            A4SupplierId = T00057_A4SupplierId[0];
            AssignAttri("", false, "A4SupplierId", StringUtil.LTrimStr( (decimal)(A4SupplierId), 6, 0));
            ZM055( -17) ;
         }
         pr_default.close(5);
         OnLoadActions055( ) ;
      }

      protected void OnLoadActions055( )
      {
         AV17Pgmname = "Product";
         AssignAttri("", false, "AV17Pgmname", AV17Pgmname);
      }

      protected void CheckExtendedTable055( )
      {
         nIsDirty_5 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV17Pgmname = "Product";
         AssignAttri("", false, "AV17Pgmname", AV17Pgmname);
         /* Using cursor T00054 */
         pr_default.execute(2, new Object[] {A1BrandId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'Brand'.", "ForeignKeyNotFound", 1, "BRANDID");
            AnyError = 1;
            GX_FocusControl = edtBrandId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2BrandName = T00054_A2BrandName[0];
         AssignAttri("", false, "A2BrandName", A2BrandName);
         pr_default.close(2);
         /* Using cursor T00055 */
         pr_default.execute(3, new Object[] {A9SectorId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No matching 'Sector'.", "ForeignKeyNotFound", 1, "SECTORID");
            AnyError = 1;
            GX_FocusControl = edtSectorId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A10SectorName = T00055_A10SectorName[0];
         AssignAttri("", false, "A10SectorName", A10SectorName);
         pr_default.close(3);
         /* Using cursor T00056 */
         pr_default.execute(4, new Object[] {A4SupplierId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No matching 'Supplier'.", "ForeignKeyNotFound", 1, "SUPPLIERID");
            AnyError = 1;
            GX_FocusControl = edtSupplierId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A5SupplierName = T00056_A5SupplierName[0];
         AssignAttri("", false, "A5SupplierName", A5SupplierName);
         pr_default.close(4);
         if ( ! ( (DateTime.MinValue==A29ProductModifiedDate) || ( DateTimeUtil.ResetTime ( A29ProductModifiedDate ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Product Modified Date is out of range", "OutOfRange", 1, "PRODUCTMODIFIEDDATE");
            AnyError = 1;
            GX_FocusControl = edtProductModifiedDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors055( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_18( int A1BrandId )
      {
         /* Using cursor T00058 */
         pr_default.execute(6, new Object[] {A1BrandId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No matching 'Brand'.", "ForeignKeyNotFound", 1, "BRANDID");
            AnyError = 1;
            GX_FocusControl = edtBrandId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2BrandName = T00058_A2BrandName[0];
         AssignAttri("", false, "A2BrandName", A2BrandName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A2BrandName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void gxLoad_19( int A9SectorId )
      {
         /* Using cursor T00059 */
         pr_default.execute(7, new Object[] {A9SectorId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No matching 'Sector'.", "ForeignKeyNotFound", 1, "SECTORID");
            AnyError = 1;
            GX_FocusControl = edtSectorId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A10SectorName = T00059_A10SectorName[0];
         AssignAttri("", false, "A10SectorName", A10SectorName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A10SectorName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_20( int A4SupplierId )
      {
         /* Using cursor T000510 */
         pr_default.execute(8, new Object[] {A4SupplierId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No matching 'Supplier'.", "ForeignKeyNotFound", 1, "SUPPLIERID");
            AnyError = 1;
            GX_FocusControl = edtSupplierId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A5SupplierName = T000510_A5SupplierName[0];
         AssignAttri("", false, "A5SupplierName", A5SupplierName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A5SupplierName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey055( )
      {
         /* Using cursor T000511 */
         pr_default.execute(9, new Object[] {A15ProductId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound5 = 1;
         }
         else
         {
            RcdFound5 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00053 */
         pr_default.execute(1, new Object[] {A15ProductId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM055( 17) ;
            RcdFound5 = 1;
            A15ProductId = T00053_A15ProductId[0];
            AssignAttri("", false, "A15ProductId", StringUtil.LTrimStr( (decimal)(A15ProductId), 6, 0));
            A55ProductCode = T00053_A55ProductCode[0];
            n55ProductCode = T00053_n55ProductCode[0];
            AssignAttri("", false, "A55ProductCode", A55ProductCode);
            A16ProductName = T00053_A16ProductName[0];
            AssignAttri("", false, "A16ProductName", A16ProductName);
            A17ProductStock = T00053_A17ProductStock[0];
            AssignAttri("", false, "A17ProductStock", StringUtil.LTrimStr( (decimal)(A17ProductStock), 6, 0));
            A18ProductPrice = T00053_A18ProductPrice[0];
            AssignAttri("", false, "A18ProductPrice", StringUtil.LTrimStr( A18ProductPrice, 10, 2));
            A19ProductDescription = T00053_A19ProductDescription[0];
            n19ProductDescription = T00053_n19ProductDescription[0];
            AssignAttri("", false, "A19ProductDescription", A19ProductDescription);
            A28ProductCreatedDate = T00053_A28ProductCreatedDate[0];
            AssignAttri("", false, "A28ProductCreatedDate", context.localUtil.Format(A28ProductCreatedDate, "99/99/99"));
            A29ProductModifiedDate = T00053_A29ProductModifiedDate[0];
            n29ProductModifiedDate = T00053_n29ProductModifiedDate[0];
            AssignAttri("", false, "A29ProductModifiedDate", context.localUtil.Format(A29ProductModifiedDate, "99/99/99"));
            A1BrandId = T00053_A1BrandId[0];
            AssignAttri("", false, "A1BrandId", StringUtil.LTrimStr( (decimal)(A1BrandId), 6, 0));
            A9SectorId = T00053_A9SectorId[0];
            AssignAttri("", false, "A9SectorId", StringUtil.LTrimStr( (decimal)(A9SectorId), 6, 0));
            A4SupplierId = T00053_A4SupplierId[0];
            AssignAttri("", false, "A4SupplierId", StringUtil.LTrimStr( (decimal)(A4SupplierId), 6, 0));
            Z15ProductId = A15ProductId;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load055( ) ;
            if ( AnyError == 1 )
            {
               RcdFound5 = 0;
               InitializeNonKey055( ) ;
            }
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound5 = 0;
            InitializeNonKey055( ) ;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey055( ) ;
         if ( RcdFound5 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound5 = 0;
         /* Using cursor T000512 */
         pr_default.execute(10, new Object[] {A15ProductId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T000512_A15ProductId[0] < A15ProductId ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T000512_A15ProductId[0] > A15ProductId ) ) )
            {
               A15ProductId = T000512_A15ProductId[0];
               AssignAttri("", false, "A15ProductId", StringUtil.LTrimStr( (decimal)(A15ProductId), 6, 0));
               RcdFound5 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound5 = 0;
         /* Using cursor T000513 */
         pr_default.execute(11, new Object[] {A15ProductId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T000513_A15ProductId[0] > A15ProductId ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T000513_A15ProductId[0] < A15ProductId ) ) )
            {
               A15ProductId = T000513_A15ProductId[0];
               AssignAttri("", false, "A15ProductId", StringUtil.LTrimStr( (decimal)(A15ProductId), 6, 0));
               RcdFound5 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey055( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtProductCode_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert055( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound5 == 1 )
            {
               if ( A15ProductId != Z15ProductId )
               {
                  A15ProductId = Z15ProductId;
                  AssignAttri("", false, "A15ProductId", StringUtil.LTrimStr( (decimal)(A15ProductId), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PRODUCTID");
                  AnyError = 1;
                  GX_FocusControl = edtProductId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtProductCode_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update055( ) ;
                  GX_FocusControl = edtProductCode_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A15ProductId != Z15ProductId )
               {
                  /* Insert record */
                  GX_FocusControl = edtProductCode_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert055( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PRODUCTID");
                     AnyError = 1;
                     GX_FocusControl = edtProductId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtProductCode_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert055( ) ;
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
         if ( A15ProductId != Z15ProductId )
         {
            A15ProductId = Z15ProductId;
            AssignAttri("", false, "A15ProductId", StringUtil.LTrimStr( (decimal)(A15ProductId), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PRODUCTID");
            AnyError = 1;
            GX_FocusControl = edtProductId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtProductCode_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency055( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00052 */
            pr_default.execute(0, new Object[] {A15ProductId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Product"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z55ProductCode, T00052_A55ProductCode[0]) != 0 ) || ( StringUtil.StrCmp(Z16ProductName, T00052_A16ProductName[0]) != 0 ) || ( Z17ProductStock != T00052_A17ProductStock[0] ) || ( Z18ProductPrice != T00052_A18ProductPrice[0] ) || ( StringUtil.StrCmp(Z19ProductDescription, T00052_A19ProductDescription[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( DateTimeUtil.ResetTime ( Z28ProductCreatedDate ) != DateTimeUtil.ResetTime ( T00052_A28ProductCreatedDate[0] ) ) || ( DateTimeUtil.ResetTime ( Z29ProductModifiedDate ) != DateTimeUtil.ResetTime ( T00052_A29ProductModifiedDate[0] ) ) || ( Z1BrandId != T00052_A1BrandId[0] ) || ( Z9SectorId != T00052_A9SectorId[0] ) || ( Z4SupplierId != T00052_A4SupplierId[0] ) )
            {
               if ( StringUtil.StrCmp(Z55ProductCode, T00052_A55ProductCode[0]) != 0 )
               {
                  GXUtil.WriteLog("product:[seudo value changed for attri]"+"ProductCode");
                  GXUtil.WriteLogRaw("Old: ",Z55ProductCode);
                  GXUtil.WriteLogRaw("Current: ",T00052_A55ProductCode[0]);
               }
               if ( StringUtil.StrCmp(Z16ProductName, T00052_A16ProductName[0]) != 0 )
               {
                  GXUtil.WriteLog("product:[seudo value changed for attri]"+"ProductName");
                  GXUtil.WriteLogRaw("Old: ",Z16ProductName);
                  GXUtil.WriteLogRaw("Current: ",T00052_A16ProductName[0]);
               }
               if ( Z17ProductStock != T00052_A17ProductStock[0] )
               {
                  GXUtil.WriteLog("product:[seudo value changed for attri]"+"ProductStock");
                  GXUtil.WriteLogRaw("Old: ",Z17ProductStock);
                  GXUtil.WriteLogRaw("Current: ",T00052_A17ProductStock[0]);
               }
               if ( Z18ProductPrice != T00052_A18ProductPrice[0] )
               {
                  GXUtil.WriteLog("product:[seudo value changed for attri]"+"ProductPrice");
                  GXUtil.WriteLogRaw("Old: ",Z18ProductPrice);
                  GXUtil.WriteLogRaw("Current: ",T00052_A18ProductPrice[0]);
               }
               if ( StringUtil.StrCmp(Z19ProductDescription, T00052_A19ProductDescription[0]) != 0 )
               {
                  GXUtil.WriteLog("product:[seudo value changed for attri]"+"ProductDescription");
                  GXUtil.WriteLogRaw("Old: ",Z19ProductDescription);
                  GXUtil.WriteLogRaw("Current: ",T00052_A19ProductDescription[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z28ProductCreatedDate ) != DateTimeUtil.ResetTime ( T00052_A28ProductCreatedDate[0] ) )
               {
                  GXUtil.WriteLog("product:[seudo value changed for attri]"+"ProductCreatedDate");
                  GXUtil.WriteLogRaw("Old: ",Z28ProductCreatedDate);
                  GXUtil.WriteLogRaw("Current: ",T00052_A28ProductCreatedDate[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z29ProductModifiedDate ) != DateTimeUtil.ResetTime ( T00052_A29ProductModifiedDate[0] ) )
               {
                  GXUtil.WriteLog("product:[seudo value changed for attri]"+"ProductModifiedDate");
                  GXUtil.WriteLogRaw("Old: ",Z29ProductModifiedDate);
                  GXUtil.WriteLogRaw("Current: ",T00052_A29ProductModifiedDate[0]);
               }
               if ( Z1BrandId != T00052_A1BrandId[0] )
               {
                  GXUtil.WriteLog("product:[seudo value changed for attri]"+"BrandId");
                  GXUtil.WriteLogRaw("Old: ",Z1BrandId);
                  GXUtil.WriteLogRaw("Current: ",T00052_A1BrandId[0]);
               }
               if ( Z9SectorId != T00052_A9SectorId[0] )
               {
                  GXUtil.WriteLog("product:[seudo value changed for attri]"+"SectorId");
                  GXUtil.WriteLogRaw("Old: ",Z9SectorId);
                  GXUtil.WriteLogRaw("Current: ",T00052_A9SectorId[0]);
               }
               if ( Z4SupplierId != T00052_A4SupplierId[0] )
               {
                  GXUtil.WriteLog("product:[seudo value changed for attri]"+"SupplierId");
                  GXUtil.WriteLogRaw("Old: ",Z4SupplierId);
                  GXUtil.WriteLogRaw("Current: ",T00052_A4SupplierId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Product"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert055( )
      {
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable055( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM055( 0) ;
            CheckOptimisticConcurrency055( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm055( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert055( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000514 */
                     pr_default.execute(12, new Object[] {n55ProductCode, A55ProductCode, A16ProductName, A17ProductStock, A18ProductPrice, n19ProductDescription, A19ProductDescription, A28ProductCreatedDate, n29ProductModifiedDate, A29ProductModifiedDate, A1BrandId, A9SectorId, A4SupplierId});
                     A15ProductId = T000514_A15ProductId[0];
                     AssignAttri("", false, "A15ProductId", StringUtil.LTrimStr( (decimal)(A15ProductId), 6, 0));
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("Product");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption050( ) ;
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
               Load055( ) ;
            }
            EndLevel055( ) ;
         }
         CloseExtendedTableCursors055( ) ;
      }

      protected void Update055( )
      {
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable055( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency055( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm055( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate055( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000515 */
                     pr_default.execute(13, new Object[] {n55ProductCode, A55ProductCode, A16ProductName, A17ProductStock, A18ProductPrice, n19ProductDescription, A19ProductDescription, A28ProductCreatedDate, n29ProductModifiedDate, A29ProductModifiedDate, A1BrandId, A9SectorId, A4SupplierId, A15ProductId});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("Product");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Product"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate055( ) ;
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
            EndLevel055( ) ;
         }
         CloseExtendedTableCursors055( ) ;
      }

      protected void DeferredUpdate055( )
      {
      }

      protected void delete( )
      {
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency055( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls055( ) ;
            AfterConfirm055( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete055( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000516 */
                  pr_default.execute(14, new Object[] {A15ProductId});
                  pr_default.close(14);
                  pr_default.SmartCacheProvider.SetUpdated("Product");
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
         sMode5 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel055( ) ;
         Gx_mode = sMode5;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls055( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV17Pgmname = "Product";
            AssignAttri("", false, "AV17Pgmname", AV17Pgmname);
            /* Using cursor T000517 */
            pr_default.execute(15, new Object[] {A1BrandId});
            A2BrandName = T000517_A2BrandName[0];
            AssignAttri("", false, "A2BrandName", A2BrandName);
            pr_default.close(15);
            /* Using cursor T000518 */
            pr_default.execute(16, new Object[] {A9SectorId});
            A10SectorName = T000518_A10SectorName[0];
            AssignAttri("", false, "A10SectorName", A10SectorName);
            pr_default.close(16);
            /* Using cursor T000519 */
            pr_default.execute(17, new Object[] {A4SupplierId});
            A5SupplierName = T000519_A5SupplierName[0];
            AssignAttri("", false, "A5SupplierName", A5SupplierName);
            pr_default.close(17);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000520 */
            pr_default.execute(18, new Object[] {A15ProductId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detail"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor T000521 */
            pr_default.execute(19, new Object[] {A15ProductId});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detail"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
         }
      }

      protected void EndLevel055( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete055( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(15);
            pr_default.close(16);
            pr_default.close(17);
            context.CommitDataStores("product",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues050( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(15);
            pr_default.close(16);
            pr_default.close(17);
            context.RollbackDataStores("product",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart055( )
      {
         /* Scan By routine */
         /* Using cursor T000522 */
         pr_default.execute(20);
         RcdFound5 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound5 = 1;
            A15ProductId = T000522_A15ProductId[0];
            AssignAttri("", false, "A15ProductId", StringUtil.LTrimStr( (decimal)(A15ProductId), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext055( )
      {
         /* Scan next routine */
         pr_default.readNext(20);
         RcdFound5 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound5 = 1;
            A15ProductId = T000522_A15ProductId[0];
            AssignAttri("", false, "A15ProductId", StringUtil.LTrimStr( (decimal)(A15ProductId), 6, 0));
         }
      }

      protected void ScanEnd055( )
      {
         pr_default.close(20);
      }

      protected void AfterConfirm055( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert055( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate055( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete055( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete055( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate055( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes055( )
      {
         edtProductId_Enabled = 0;
         AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), true);
         edtProductCode_Enabled = 0;
         AssignProp("", false, edtProductCode_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductCode_Enabled), 5, 0), true);
         edtProductName_Enabled = 0;
         AssignProp("", false, edtProductName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductName_Enabled), 5, 0), true);
         edtProductStock_Enabled = 0;
         AssignProp("", false, edtProductStock_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductStock_Enabled), 5, 0), true);
         edtProductPrice_Enabled = 0;
         AssignProp("", false, edtProductPrice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductPrice_Enabled), 5, 0), true);
         edtProductDescription_Enabled = 0;
         AssignProp("", false, edtProductDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductDescription_Enabled), 5, 0), true);
         edtBrandId_Enabled = 0;
         AssignProp("", false, edtBrandId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBrandId_Enabled), 5, 0), true);
         edtBrandName_Enabled = 0;
         AssignProp("", false, edtBrandName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBrandName_Enabled), 5, 0), true);
         edtSectorId_Enabled = 0;
         AssignProp("", false, edtSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorId_Enabled), 5, 0), true);
         edtSectorName_Enabled = 0;
         AssignProp("", false, edtSectorName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorName_Enabled), 5, 0), true);
         edtSupplierId_Enabled = 0;
         AssignProp("", false, edtSupplierId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierId_Enabled), 5, 0), true);
         edtSupplierName_Enabled = 0;
         AssignProp("", false, edtSupplierName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierName_Enabled), 5, 0), true);
         edtProductCreatedDate_Enabled = 0;
         AssignProp("", false, edtProductCreatedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductCreatedDate_Enabled), 5, 0), true);
         edtProductModifiedDate_Enabled = 0;
         AssignProp("", false, edtProductModifiedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductModifiedDate_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes055( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues050( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("product.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7ProductId,6,0))}, new string[] {"Gx_mode","ProductId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Product");
         forbiddenHiddens.Add("ProductId", context.localUtil.Format( (decimal)(A15ProductId), "ZZZZZ9"));
         forbiddenHiddens.Add("ProductCreatedDate", context.localUtil.Format(A28ProductCreatedDate, "99/99/99"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("product:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z15ProductId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z15ProductId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z55ProductCode", Z55ProductCode);
         GxWebStd.gx_hidden_field( context, "Z16ProductName", Z16ProductName);
         GxWebStd.gx_hidden_field( context, "Z17ProductStock", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z17ProductStock), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z18ProductPrice", StringUtil.LTrim( StringUtil.NToC( Z18ProductPrice, 10, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z19ProductDescription", Z19ProductDescription);
         GxWebStd.gx_hidden_field( context, "Z28ProductCreatedDate", context.localUtil.DToC( Z28ProductCreatedDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z29ProductModifiedDate", context.localUtil.DToC( Z29ProductModifiedDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1BrandId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1BrandId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z9SectorId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9SectorId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z4SupplierId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z4SupplierId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N1BrandId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1BrandId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N9SectorId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9SectorId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N4SupplierId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A4SupplierId), 6, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "vPRODUCTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ProductId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPRODUCTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ProductId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_BRANDID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_BrandId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_SECTORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_SectorId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_SUPPLIERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_SupplierId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV17Pgmname));
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
         return formatLink("product.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7ProductId,6,0))}, new string[] {"Gx_mode","ProductId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Product" ;
      }

      public override string GetPgmdesc( )
      {
         return "Product" ;
      }

      protected void InitializeNonKey055( )
      {
         A1BrandId = 0;
         AssignAttri("", false, "A1BrandId", StringUtil.LTrimStr( (decimal)(A1BrandId), 6, 0));
         A9SectorId = 0;
         AssignAttri("", false, "A9SectorId", StringUtil.LTrimStr( (decimal)(A9SectorId), 6, 0));
         A4SupplierId = 0;
         AssignAttri("", false, "A4SupplierId", StringUtil.LTrimStr( (decimal)(A4SupplierId), 6, 0));
         A55ProductCode = "";
         n55ProductCode = false;
         AssignAttri("", false, "A55ProductCode", A55ProductCode);
         n55ProductCode = (String.IsNullOrEmpty(StringUtil.RTrim( A55ProductCode)) ? true : false);
         A16ProductName = "";
         AssignAttri("", false, "A16ProductName", A16ProductName);
         A17ProductStock = 0;
         AssignAttri("", false, "A17ProductStock", StringUtil.LTrimStr( (decimal)(A17ProductStock), 6, 0));
         A18ProductPrice = 0;
         AssignAttri("", false, "A18ProductPrice", StringUtil.LTrimStr( A18ProductPrice, 10, 2));
         A19ProductDescription = "";
         n19ProductDescription = false;
         AssignAttri("", false, "A19ProductDescription", A19ProductDescription);
         n19ProductDescription = (String.IsNullOrEmpty(StringUtil.RTrim( A19ProductDescription)) ? true : false);
         A2BrandName = "";
         AssignAttri("", false, "A2BrandName", A2BrandName);
         A10SectorName = "";
         AssignAttri("", false, "A10SectorName", A10SectorName);
         A5SupplierName = "";
         AssignAttri("", false, "A5SupplierName", A5SupplierName);
         A29ProductModifiedDate = DateTime.MinValue;
         n29ProductModifiedDate = false;
         AssignAttri("", false, "A29ProductModifiedDate", context.localUtil.Format(A29ProductModifiedDate, "99/99/99"));
         n29ProductModifiedDate = ((DateTime.MinValue==A29ProductModifiedDate) ? true : false);
         A28ProductCreatedDate = Gx_date;
         AssignAttri("", false, "A28ProductCreatedDate", context.localUtil.Format(A28ProductCreatedDate, "99/99/99"));
         Z55ProductCode = "";
         Z16ProductName = "";
         Z17ProductStock = 0;
         Z18ProductPrice = 0;
         Z19ProductDescription = "";
         Z28ProductCreatedDate = DateTime.MinValue;
         Z29ProductModifiedDate = DateTime.MinValue;
         Z1BrandId = 0;
         Z9SectorId = 0;
         Z4SupplierId = 0;
      }

      protected void InitAll055( )
      {
         A15ProductId = 0;
         AssignAttri("", false, "A15ProductId", StringUtil.LTrimStr( (decimal)(A15ProductId), 6, 0));
         InitializeNonKey055( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A28ProductCreatedDate = i28ProductCreatedDate;
         AssignAttri("", false, "A28ProductCreatedDate", context.localUtil.Format(A28ProductCreatedDate, "99/99/99"));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202311222273549", true, true);
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
         context.AddJavascriptSource("product.js", "?202311222273549", false, true);
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
         edtProductId_Internalname = "PRODUCTID";
         edtProductCode_Internalname = "PRODUCTCODE";
         edtProductName_Internalname = "PRODUCTNAME";
         edtProductStock_Internalname = "PRODUCTSTOCK";
         edtProductPrice_Internalname = "PRODUCTPRICE";
         edtProductDescription_Internalname = "PRODUCTDESCRIPTION";
         edtBrandId_Internalname = "BRANDID";
         edtBrandName_Internalname = "BRANDNAME";
         edtSectorId_Internalname = "SECTORID";
         edtSectorName_Internalname = "SECTORNAME";
         edtSupplierId_Internalname = "SUPPLIERID";
         edtSupplierName_Internalname = "SUPPLIERNAME";
         edtProductCreatedDate_Internalname = "PRODUCTCREATEDDATE";
         edtProductModifiedDate_Internalname = "PRODUCTMODIFIEDDATE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_1_Internalname = "PROMPT_1";
         imgprompt_9_Internalname = "PROMPT_9";
         imgprompt_4_Internalname = "PROMPT_4";
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
         Form.Caption = "Product";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirm";
         bttBtn_enter_Caption = "Confirm";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtProductModifiedDate_Jsonclick = "";
         edtProductModifiedDate_Enabled = 1;
         edtProductCreatedDate_Jsonclick = "";
         edtProductCreatedDate_Enabled = 0;
         edtSupplierName_Jsonclick = "";
         edtSupplierName_Enabled = 0;
         imgprompt_4_Visible = 1;
         imgprompt_4_Link = "";
         edtSupplierId_Jsonclick = "";
         edtSupplierId_Enabled = 1;
         edtSectorName_Jsonclick = "";
         edtSectorName_Enabled = 0;
         imgprompt_9_Visible = 1;
         imgprompt_9_Link = "";
         edtSectorId_Jsonclick = "";
         edtSectorId_Enabled = 1;
         edtBrandName_Jsonclick = "";
         edtBrandName_Enabled = 0;
         imgprompt_1_Visible = 1;
         imgprompt_1_Link = "";
         edtBrandId_Jsonclick = "";
         edtBrandId_Enabled = 1;
         edtProductDescription_Enabled = 1;
         edtProductPrice_Jsonclick = "";
         edtProductPrice_Enabled = 1;
         edtProductStock_Jsonclick = "";
         edtProductStock_Enabled = 1;
         edtProductName_Jsonclick = "";
         edtProductName_Enabled = 1;
         edtProductCode_Jsonclick = "";
         edtProductCode_Enabled = 1;
         edtProductId_Jsonclick = "";
         edtProductId_Enabled = 0;
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
         /* Using cursor T000517 */
         pr_default.execute(15, new Object[] {A1BrandId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No matching 'Brand'.", "ForeignKeyNotFound", 1, "BRANDID");
            AnyError = 1;
            GX_FocusControl = edtBrandId_Internalname;
         }
         A2BrandName = T000517_A2BrandName[0];
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2BrandName", A2BrandName);
      }

      public void Valid_Sectorid( )
      {
         /* Using cursor T000518 */
         pr_default.execute(16, new Object[] {A9SectorId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No matching 'Sector'.", "ForeignKeyNotFound", 1, "SECTORID");
            AnyError = 1;
            GX_FocusControl = edtSectorId_Internalname;
         }
         A10SectorName = T000518_A10SectorName[0];
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A10SectorName", A10SectorName);
      }

      public void Valid_Supplierid( )
      {
         /* Using cursor T000519 */
         pr_default.execute(17, new Object[] {A4SupplierId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No matching 'Supplier'.", "ForeignKeyNotFound", 1, "SUPPLIERID");
            AnyError = 1;
            GX_FocusControl = edtSupplierId_Internalname;
         }
         A5SupplierName = T000519_A5SupplierName[0];
         pr_default.close(17);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A5SupplierName", A5SupplierName);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7ProductId',fld:'vPRODUCTID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7ProductId',fld:'vPRODUCTID',pic:'ZZZZZ9',hsh:true},{av:'A15ProductId',fld:'PRODUCTID',pic:'ZZZZZ9'},{av:'A28ProductCreatedDate',fld:'PRODUCTCREATEDDATE',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12052',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_PRODUCTID","{handler:'Valid_Productid',iparms:[]");
         setEventMetadata("VALID_PRODUCTID",",oparms:[]}");
         setEventMetadata("VALID_BRANDID","{handler:'Valid_Brandid',iparms:[{av:'A1BrandId',fld:'BRANDID',pic:'ZZZZZ9'},{av:'A2BrandName',fld:'BRANDNAME',pic:''}]");
         setEventMetadata("VALID_BRANDID",",oparms:[{av:'A2BrandName',fld:'BRANDNAME',pic:''}]}");
         setEventMetadata("VALID_SECTORID","{handler:'Valid_Sectorid',iparms:[{av:'A9SectorId',fld:'SECTORID',pic:'ZZZZZ9'},{av:'A10SectorName',fld:'SECTORNAME',pic:''}]");
         setEventMetadata("VALID_SECTORID",",oparms:[{av:'A10SectorName',fld:'SECTORNAME',pic:''}]}");
         setEventMetadata("VALID_SUPPLIERID","{handler:'Valid_Supplierid',iparms:[{av:'A4SupplierId',fld:'SUPPLIERID',pic:'ZZZZZ9'},{av:'A5SupplierName',fld:'SUPPLIERNAME',pic:''}]");
         setEventMetadata("VALID_SUPPLIERID",",oparms:[{av:'A5SupplierName',fld:'SUPPLIERNAME',pic:''}]}");
         setEventMetadata("VALID_PRODUCTMODIFIEDDATE","{handler:'Valid_Productmodifieddate',iparms:[]");
         setEventMetadata("VALID_PRODUCTMODIFIEDDATE",",oparms:[]}");
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
         pr_default.close(15);
         pr_default.close(16);
         pr_default.close(17);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z55ProductCode = "";
         Z16ProductName = "";
         Z19ProductDescription = "";
         Z28ProductCreatedDate = DateTime.MinValue;
         Z29ProductModifiedDate = DateTime.MinValue;
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
         A55ProductCode = "";
         A16ProductName = "";
         A19ProductDescription = "";
         imgprompt_1_gximage = "";
         sImgUrl = "";
         A2BrandName = "";
         imgprompt_9_gximage = "";
         A10SectorName = "";
         imgprompt_4_gximage = "";
         A5SupplierName = "";
         A28ProductCreatedDate = DateTime.MinValue;
         A29ProductModifiedDate = DateTime.MinValue;
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_date = DateTime.MinValue;
         AV17Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode5 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV14TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         Z2BrandName = "";
         Z10SectorName = "";
         Z5SupplierName = "";
         T00056_A5SupplierName = new string[] {""} ;
         T00055_A10SectorName = new string[] {""} ;
         T00054_A2BrandName = new string[] {""} ;
         T00057_A15ProductId = new int[1] ;
         T00057_A55ProductCode = new string[] {""} ;
         T00057_n55ProductCode = new bool[] {false} ;
         T00057_A16ProductName = new string[] {""} ;
         T00057_A17ProductStock = new int[1] ;
         T00057_A18ProductPrice = new decimal[1] ;
         T00057_A19ProductDescription = new string[] {""} ;
         T00057_n19ProductDescription = new bool[] {false} ;
         T00057_A2BrandName = new string[] {""} ;
         T00057_A10SectorName = new string[] {""} ;
         T00057_A5SupplierName = new string[] {""} ;
         T00057_A28ProductCreatedDate = new DateTime[] {DateTime.MinValue} ;
         T00057_A29ProductModifiedDate = new DateTime[] {DateTime.MinValue} ;
         T00057_n29ProductModifiedDate = new bool[] {false} ;
         T00057_A1BrandId = new int[1] ;
         T00057_A9SectorId = new int[1] ;
         T00057_A4SupplierId = new int[1] ;
         T00058_A2BrandName = new string[] {""} ;
         T00059_A10SectorName = new string[] {""} ;
         T000510_A5SupplierName = new string[] {""} ;
         T000511_A15ProductId = new int[1] ;
         T00053_A15ProductId = new int[1] ;
         T00053_A55ProductCode = new string[] {""} ;
         T00053_n55ProductCode = new bool[] {false} ;
         T00053_A16ProductName = new string[] {""} ;
         T00053_A17ProductStock = new int[1] ;
         T00053_A18ProductPrice = new decimal[1] ;
         T00053_A19ProductDescription = new string[] {""} ;
         T00053_n19ProductDescription = new bool[] {false} ;
         T00053_A28ProductCreatedDate = new DateTime[] {DateTime.MinValue} ;
         T00053_A29ProductModifiedDate = new DateTime[] {DateTime.MinValue} ;
         T00053_n29ProductModifiedDate = new bool[] {false} ;
         T00053_A1BrandId = new int[1] ;
         T00053_A9SectorId = new int[1] ;
         T00053_A4SupplierId = new int[1] ;
         T000512_A15ProductId = new int[1] ;
         T000513_A15ProductId = new int[1] ;
         T00052_A15ProductId = new int[1] ;
         T00052_A55ProductCode = new string[] {""} ;
         T00052_n55ProductCode = new bool[] {false} ;
         T00052_A16ProductName = new string[] {""} ;
         T00052_A17ProductStock = new int[1] ;
         T00052_A18ProductPrice = new decimal[1] ;
         T00052_A19ProductDescription = new string[] {""} ;
         T00052_n19ProductDescription = new bool[] {false} ;
         T00052_A28ProductCreatedDate = new DateTime[] {DateTime.MinValue} ;
         T00052_A29ProductModifiedDate = new DateTime[] {DateTime.MinValue} ;
         T00052_n29ProductModifiedDate = new bool[] {false} ;
         T00052_A1BrandId = new int[1] ;
         T00052_A9SectorId = new int[1] ;
         T00052_A4SupplierId = new int[1] ;
         T000514_A15ProductId = new int[1] ;
         T000517_A2BrandName = new string[] {""} ;
         T000518_A10SectorName = new string[] {""} ;
         T000519_A5SupplierName = new string[] {""} ;
         T000520_A20InvoiceId = new int[1] ;
         T000520_A25InvoiceDetailId = new int[1] ;
         T000521_A50PurchaseOrderId = new int[1] ;
         T000521_A61PurchaseOrderDetailId = new int[1] ;
         T000522_A15ProductId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i28ProductCreatedDate = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.product__default(),
            new Object[][] {
                new Object[] {
               T00052_A15ProductId, T00052_A55ProductCode, T00052_n55ProductCode, T00052_A16ProductName, T00052_A17ProductStock, T00052_A18ProductPrice, T00052_A19ProductDescription, T00052_n19ProductDescription, T00052_A28ProductCreatedDate, T00052_A29ProductModifiedDate,
               T00052_n29ProductModifiedDate, T00052_A1BrandId, T00052_A9SectorId, T00052_A4SupplierId
               }
               , new Object[] {
               T00053_A15ProductId, T00053_A55ProductCode, T00053_n55ProductCode, T00053_A16ProductName, T00053_A17ProductStock, T00053_A18ProductPrice, T00053_A19ProductDescription, T00053_n19ProductDescription, T00053_A28ProductCreatedDate, T00053_A29ProductModifiedDate,
               T00053_n29ProductModifiedDate, T00053_A1BrandId, T00053_A9SectorId, T00053_A4SupplierId
               }
               , new Object[] {
               T00054_A2BrandName
               }
               , new Object[] {
               T00055_A10SectorName
               }
               , new Object[] {
               T00056_A5SupplierName
               }
               , new Object[] {
               T00057_A15ProductId, T00057_A55ProductCode, T00057_n55ProductCode, T00057_A16ProductName, T00057_A17ProductStock, T00057_A18ProductPrice, T00057_A19ProductDescription, T00057_n19ProductDescription, T00057_A2BrandName, T00057_A10SectorName,
               T00057_A5SupplierName, T00057_A28ProductCreatedDate, T00057_A29ProductModifiedDate, T00057_n29ProductModifiedDate, T00057_A1BrandId, T00057_A9SectorId, T00057_A4SupplierId
               }
               , new Object[] {
               T00058_A2BrandName
               }
               , new Object[] {
               T00059_A10SectorName
               }
               , new Object[] {
               T000510_A5SupplierName
               }
               , new Object[] {
               T000511_A15ProductId
               }
               , new Object[] {
               T000512_A15ProductId
               }
               , new Object[] {
               T000513_A15ProductId
               }
               , new Object[] {
               T000514_A15ProductId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000517_A2BrandName
               }
               , new Object[] {
               T000518_A10SectorName
               }
               , new Object[] {
               T000519_A5SupplierName
               }
               , new Object[] {
               T000520_A20InvoiceId, T000520_A25InvoiceDetailId
               }
               , new Object[] {
               T000521_A50PurchaseOrderId, T000521_A61PurchaseOrderDetailId
               }
               , new Object[] {
               T000522_A15ProductId
               }
            }
         );
         AV17Pgmname = "Product";
         Z28ProductCreatedDate = DateTime.MinValue;
         A28ProductCreatedDate = DateTime.MinValue;
         i28ProductCreatedDate = DateTime.MinValue;
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
      private short RcdFound5 ;
      private short GX_JID ;
      private short nIsDirty_5 ;
      private short gxajaxcallmode ;
      private int wcpOAV7ProductId ;
      private int Z15ProductId ;
      private int Z17ProductStock ;
      private int Z1BrandId ;
      private int Z9SectorId ;
      private int Z4SupplierId ;
      private int N1BrandId ;
      private int N9SectorId ;
      private int N4SupplierId ;
      private int A1BrandId ;
      private int A9SectorId ;
      private int A4SupplierId ;
      private int AV7ProductId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A15ProductId ;
      private int edtProductId_Enabled ;
      private int edtProductCode_Enabled ;
      private int edtProductName_Enabled ;
      private int A17ProductStock ;
      private int edtProductStock_Enabled ;
      private int edtProductPrice_Enabled ;
      private int edtProductDescription_Enabled ;
      private int edtBrandId_Enabled ;
      private int imgprompt_1_Visible ;
      private int edtBrandName_Enabled ;
      private int edtSectorId_Enabled ;
      private int imgprompt_9_Visible ;
      private int edtSectorName_Enabled ;
      private int edtSupplierId_Enabled ;
      private int imgprompt_4_Visible ;
      private int edtSupplierName_Enabled ;
      private int edtProductCreatedDate_Enabled ;
      private int edtProductModifiedDate_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int AV11Insert_BrandId ;
      private int AV12Insert_SectorId ;
      private int AV13Insert_SupplierId ;
      private int AV18GXV1 ;
      private int idxLst ;
      private decimal Z18ProductPrice ;
      private decimal A18ProductPrice ;
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
      private string edtProductCode_Internalname ;
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
      private string edtProductId_Internalname ;
      private string edtProductId_Jsonclick ;
      private string edtProductCode_Jsonclick ;
      private string edtProductName_Internalname ;
      private string edtProductName_Jsonclick ;
      private string edtProductStock_Internalname ;
      private string edtProductStock_Jsonclick ;
      private string edtProductPrice_Internalname ;
      private string edtProductPrice_Jsonclick ;
      private string edtProductDescription_Internalname ;
      private string edtBrandId_Internalname ;
      private string edtBrandId_Jsonclick ;
      private string imgprompt_1_gximage ;
      private string sImgUrl ;
      private string imgprompt_1_Internalname ;
      private string imgprompt_1_Link ;
      private string edtBrandName_Internalname ;
      private string edtBrandName_Jsonclick ;
      private string edtSectorId_Internalname ;
      private string edtSectorId_Jsonclick ;
      private string imgprompt_9_gximage ;
      private string imgprompt_9_Internalname ;
      private string imgprompt_9_Link ;
      private string edtSectorName_Internalname ;
      private string edtSectorName_Jsonclick ;
      private string edtSupplierId_Internalname ;
      private string edtSupplierId_Jsonclick ;
      private string imgprompt_4_gximage ;
      private string imgprompt_4_Internalname ;
      private string imgprompt_4_Link ;
      private string edtSupplierName_Internalname ;
      private string edtSupplierName_Jsonclick ;
      private string edtProductCreatedDate_Internalname ;
      private string edtProductCreatedDate_Jsonclick ;
      private string edtProductModifiedDate_Internalname ;
      private string edtProductModifiedDate_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Caption ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_enter_Tooltiptext ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV17Pgmname ;
      private string hsh ;
      private string sMode5 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z28ProductCreatedDate ;
      private DateTime Z29ProductModifiedDate ;
      private DateTime A28ProductCreatedDate ;
      private DateTime A29ProductModifiedDate ;
      private DateTime Gx_date ;
      private DateTime i28ProductCreatedDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n55ProductCode ;
      private bool n19ProductDescription ;
      private bool n29ProductModifiedDate ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string Z55ProductCode ;
      private string Z16ProductName ;
      private string Z19ProductDescription ;
      private string A55ProductCode ;
      private string A16ProductName ;
      private string A19ProductDescription ;
      private string A2BrandName ;
      private string A10SectorName ;
      private string A5SupplierName ;
      private string Z2BrandName ;
      private string Z10SectorName ;
      private string Z5SupplierName ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00056_A5SupplierName ;
      private string[] T00055_A10SectorName ;
      private string[] T00054_A2BrandName ;
      private int[] T00057_A15ProductId ;
      private string[] T00057_A55ProductCode ;
      private bool[] T00057_n55ProductCode ;
      private string[] T00057_A16ProductName ;
      private int[] T00057_A17ProductStock ;
      private decimal[] T00057_A18ProductPrice ;
      private string[] T00057_A19ProductDescription ;
      private bool[] T00057_n19ProductDescription ;
      private string[] T00057_A2BrandName ;
      private string[] T00057_A10SectorName ;
      private string[] T00057_A5SupplierName ;
      private DateTime[] T00057_A28ProductCreatedDate ;
      private DateTime[] T00057_A29ProductModifiedDate ;
      private bool[] T00057_n29ProductModifiedDate ;
      private int[] T00057_A1BrandId ;
      private int[] T00057_A9SectorId ;
      private int[] T00057_A4SupplierId ;
      private string[] T00058_A2BrandName ;
      private string[] T00059_A10SectorName ;
      private string[] T000510_A5SupplierName ;
      private int[] T000511_A15ProductId ;
      private int[] T00053_A15ProductId ;
      private string[] T00053_A55ProductCode ;
      private bool[] T00053_n55ProductCode ;
      private string[] T00053_A16ProductName ;
      private int[] T00053_A17ProductStock ;
      private decimal[] T00053_A18ProductPrice ;
      private string[] T00053_A19ProductDescription ;
      private bool[] T00053_n19ProductDescription ;
      private DateTime[] T00053_A28ProductCreatedDate ;
      private DateTime[] T00053_A29ProductModifiedDate ;
      private bool[] T00053_n29ProductModifiedDate ;
      private int[] T00053_A1BrandId ;
      private int[] T00053_A9SectorId ;
      private int[] T00053_A4SupplierId ;
      private int[] T000512_A15ProductId ;
      private int[] T000513_A15ProductId ;
      private int[] T00052_A15ProductId ;
      private string[] T00052_A55ProductCode ;
      private bool[] T00052_n55ProductCode ;
      private string[] T00052_A16ProductName ;
      private int[] T00052_A17ProductStock ;
      private decimal[] T00052_A18ProductPrice ;
      private string[] T00052_A19ProductDescription ;
      private bool[] T00052_n19ProductDescription ;
      private DateTime[] T00052_A28ProductCreatedDate ;
      private DateTime[] T00052_A29ProductModifiedDate ;
      private bool[] T00052_n29ProductModifiedDate ;
      private int[] T00052_A1BrandId ;
      private int[] T00052_A9SectorId ;
      private int[] T00052_A4SupplierId ;
      private int[] T000514_A15ProductId ;
      private string[] T000517_A2BrandName ;
      private string[] T000518_A10SectorName ;
      private string[] T000519_A5SupplierName ;
      private int[] T000520_A20InvoiceId ;
      private int[] T000520_A25InvoiceDetailId ;
      private int[] T000521_A50PurchaseOrderId ;
      private int[] T000521_A61PurchaseOrderDetailId ;
      private int[] T000522_A15ProductId ;
      private GXWebForm Form ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV14TrnContextAtt ;
   }

   public class product__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[13])
         ,new UpdateCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00057;
          prmT00057 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmT00054;
          prmT00054 = new Object[] {
          new ParDef("@BrandId",GXType.Int32,6,0)
          };
          Object[] prmT00055;
          prmT00055 = new Object[] {
          new ParDef("@SectorId",GXType.Int32,6,0)
          };
          Object[] prmT00056;
          prmT00056 = new Object[] {
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          Object[] prmT00058;
          prmT00058 = new Object[] {
          new ParDef("@BrandId",GXType.Int32,6,0)
          };
          Object[] prmT00059;
          prmT00059 = new Object[] {
          new ParDef("@SectorId",GXType.Int32,6,0)
          };
          Object[] prmT000510;
          prmT000510 = new Object[] {
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          Object[] prmT000511;
          prmT000511 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmT00053;
          prmT00053 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmT000512;
          prmT000512 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmT000513;
          prmT000513 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmT00052;
          prmT00052 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmT000514;
          prmT000514 = new Object[] {
          new ParDef("@ProductCode",GXType.NVarChar,100,0){Nullable=true} ,
          new ParDef("@ProductName",GXType.NVarChar,60,0) ,
          new ParDef("@ProductStock",GXType.Int32,6,0) ,
          new ParDef("@ProductPrice",GXType.Decimal,10,2) ,
          new ParDef("@ProductDescription",GXType.NVarChar,200,0){Nullable=true} ,
          new ParDef("@ProductCreatedDate",GXType.Date,8,0) ,
          new ParDef("@ProductModifiedDate",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@BrandId",GXType.Int32,6,0) ,
          new ParDef("@SectorId",GXType.Int32,6,0) ,
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          Object[] prmT000515;
          prmT000515 = new Object[] {
          new ParDef("@ProductCode",GXType.NVarChar,100,0){Nullable=true} ,
          new ParDef("@ProductName",GXType.NVarChar,60,0) ,
          new ParDef("@ProductStock",GXType.Int32,6,0) ,
          new ParDef("@ProductPrice",GXType.Decimal,10,2) ,
          new ParDef("@ProductDescription",GXType.NVarChar,200,0){Nullable=true} ,
          new ParDef("@ProductCreatedDate",GXType.Date,8,0) ,
          new ParDef("@ProductModifiedDate",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@BrandId",GXType.Int32,6,0) ,
          new ParDef("@SectorId",GXType.Int32,6,0) ,
          new ParDef("@SupplierId",GXType.Int32,6,0) ,
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmT000516;
          prmT000516 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmT000520;
          prmT000520 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmT000521;
          prmT000521 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmT000522;
          prmT000522 = new Object[] {
          };
          Object[] prmT000517;
          prmT000517 = new Object[] {
          new ParDef("@BrandId",GXType.Int32,6,0)
          };
          Object[] prmT000518;
          prmT000518 = new Object[] {
          new ParDef("@SectorId",GXType.Int32,6,0)
          };
          Object[] prmT000519;
          prmT000519 = new Object[] {
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00052", "SELECT [ProductId], [ProductCode], [ProductName], [ProductStock], [ProductPrice], [ProductDescription], [ProductCreatedDate], [ProductModifiedDate], [BrandId], [SectorId], [SupplierId] FROM [Product] WITH (UPDLOCK) WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00052,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00053", "SELECT [ProductId], [ProductCode], [ProductName], [ProductStock], [ProductPrice], [ProductDescription], [ProductCreatedDate], [ProductModifiedDate], [BrandId], [SectorId], [SupplierId] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00053,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00054", "SELECT [BrandName] FROM [Brand] WHERE [BrandId] = @BrandId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00054,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00055", "SELECT [SectorName] FROM [Sector] WHERE [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00055,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00056", "SELECT [SupplierName] FROM [Supplier] WHERE [SupplierId] = @SupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00056,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00057", "SELECT TM1.[ProductId], TM1.[ProductCode], TM1.[ProductName], TM1.[ProductStock], TM1.[ProductPrice], TM1.[ProductDescription], T2.[BrandName], T3.[SectorName], T4.[SupplierName], TM1.[ProductCreatedDate], TM1.[ProductModifiedDate], TM1.[BrandId], TM1.[SectorId], TM1.[SupplierId] FROM ((([Product] TM1 INNER JOIN [Brand] T2 ON T2.[BrandId] = TM1.[BrandId]) INNER JOIN [Sector] T3 ON T3.[SectorId] = TM1.[SectorId]) INNER JOIN [Supplier] T4 ON T4.[SupplierId] = TM1.[SupplierId]) WHERE TM1.[ProductId] = @ProductId ORDER BY TM1.[ProductId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00057,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00058", "SELECT [BrandName] FROM [Brand] WHERE [BrandId] = @BrandId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00058,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00059", "SELECT [SectorName] FROM [Sector] WHERE [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00059,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000510", "SELECT [SupplierName] FROM [Supplier] WHERE [SupplierId] = @SupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000510,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000511", "SELECT [ProductId] FROM [Product] WHERE [ProductId] = @ProductId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000511,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000512", "SELECT TOP 1 [ProductId] FROM [Product] WHERE ( [ProductId] > @ProductId) ORDER BY [ProductId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000512,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000513", "SELECT TOP 1 [ProductId] FROM [Product] WHERE ( [ProductId] < @ProductId) ORDER BY [ProductId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000513,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000514", "INSERT INTO [Product]([ProductCode], [ProductName], [ProductStock], [ProductPrice], [ProductDescription], [ProductCreatedDate], [ProductModifiedDate], [BrandId], [SectorId], [SupplierId]) VALUES(@ProductCode, @ProductName, @ProductStock, @ProductPrice, @ProductDescription, @ProductCreatedDate, @ProductModifiedDate, @BrandId, @SectorId, @SupplierId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000514,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000515", "UPDATE [Product] SET [ProductCode]=@ProductCode, [ProductName]=@ProductName, [ProductStock]=@ProductStock, [ProductPrice]=@ProductPrice, [ProductDescription]=@ProductDescription, [ProductCreatedDate]=@ProductCreatedDate, [ProductModifiedDate]=@ProductModifiedDate, [BrandId]=@BrandId, [SectorId]=@SectorId, [SupplierId]=@SupplierId  WHERE [ProductId] = @ProductId", GxErrorMask.GX_NOMASK,prmT000515)
             ,new CursorDef("T000516", "DELETE FROM [Product]  WHERE [ProductId] = @ProductId", GxErrorMask.GX_NOMASK,prmT000516)
             ,new CursorDef("T000517", "SELECT [BrandName] FROM [Brand] WHERE [BrandId] = @BrandId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000517,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000518", "SELECT [SectorName] FROM [Sector] WHERE [SectorId] = @SectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000518,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000519", "SELECT [SupplierName] FROM [Supplier] WHERE [SupplierId] = @SupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000519,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000520", "SELECT TOP 1 [InvoiceId], [InvoiceDetailId] FROM [InvoiceDetail] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000520,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000521", "SELECT TOP 1 [PurchaseOrderId], [PurchaseOrderDetailId] FROM [PurchaseOrderDetail] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000521,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000522", "SELECT [ProductId] FROM [Product] ORDER BY [ProductId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000522,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[4])[0] = rslt.getInt(4);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(7);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((int[]) buf[11])[0] = rslt.getInt(9);
                ((int[]) buf[12])[0] = rslt.getInt(10);
                ((int[]) buf[13])[0] = rslt.getInt(11);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((int[]) buf[4])[0] = rslt.getInt(4);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(7);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((int[]) buf[11])[0] = rslt.getInt(9);
                ((int[]) buf[12])[0] = rslt.getInt(10);
                ((int[]) buf[13])[0] = rslt.getInt(11);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((int[]) buf[4])[0] = rslt.getInt(4);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((string[]) buf[8])[0] = rslt.getVarchar(7);
                ((string[]) buf[9])[0] = rslt.getVarchar(8);
                ((string[]) buf[10])[0] = rslt.getVarchar(9);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(10);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(11);
                ((bool[]) buf[13])[0] = rslt.wasNull(11);
                ((int[]) buf[14])[0] = rslt.getInt(12);
                ((int[]) buf[15])[0] = rslt.getInt(13);
                ((int[]) buf[16])[0] = rslt.getInt(14);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
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
             case 15 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 16 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 17 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 18 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 19 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 20 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
