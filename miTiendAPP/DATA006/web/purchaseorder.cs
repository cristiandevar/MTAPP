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
   public class purchaseorder : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_22") == 0 )
         {
            A50PurchaseOrderId = (int)(Math.Round(NumberUtil.Val( GetPar( "PurchaseOrderId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A50PurchaseOrderId", StringUtil.LTrimStr( (decimal)(A50PurchaseOrderId), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_22( A50PurchaseOrderId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_21") == 0 )
         {
            A4SupplierId = (int)(Math.Round(NumberUtil.Val( GetPar( "SupplierId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A4SupplierId", StringUtil.LTrimStr( (decimal)(A4SupplierId), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_21( A4SupplierId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_24") == 0 )
         {
            A15ProductId = (int)(Math.Round(NumberUtil.Val( GetPar( "ProductId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_24( A15ProductId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridpurchaseorder_detail") == 0 )
         {
            gxnrGridpurchaseorder_detail_newrow_invoke( ) ;
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
               AV13PurchaseOrderId = (int)(Math.Round(NumberUtil.Val( GetPar( "PurchaseOrderId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV13PurchaseOrderId", StringUtil.LTrimStr( (decimal)(AV13PurchaseOrderId), 6, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vPURCHASEORDERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13PurchaseOrderId), "ZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Purchase Order", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtSupplierId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("mtaKB", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridpurchaseorder_detail_newrow_invoke( )
      {
         nRC_GXsfl_83 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_83"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_83_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_83_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_83_idx = GetPar( "sGXsfl_83_idx");
         A96PurchaseOrderLastDetailId = (int)(Math.Round(NumberUtil.Val( GetPar( "PurchaseOrderLastDetailId"), "."), 18, MidpointRounding.ToEven));
         Gx_BScreen = (short)(Math.Round(NumberUtil.Val( GetPar( "Gx_BScreen"), "."), 18, MidpointRounding.ToEven));
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridpurchaseorder_detail_newrow( ) ;
         /* End function gxnrGridpurchaseorder_detail_newrow_invoke */
      }

      public purchaseorder( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public purchaseorder( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_PurchaseOrderId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV13PurchaseOrderId = aP1_PurchaseOrderId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkPurchaseOrderActive = new GXCheckbox();
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
         A79PurchaseOrderActive = StringUtil.StrToBool( StringUtil.BoolToStr( A79PurchaseOrderActive));
         AssignAttri("", false, "A79PurchaseOrderActive", A79PurchaseOrderActive);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Purchase Order", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_PurchaseOrder.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_PurchaseOrder.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_PurchaseOrder.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_PurchaseOrder.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_PurchaseOrder.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_PurchaseOrder.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPurchaseOrderId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPurchaseOrderId_Internalname, "Order Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPurchaseOrderId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A50PurchaseOrderId), 6, 0, ".", "")), StringUtil.LTrim( ((edtPurchaseOrderId_Enabled!=0) ? context.localUtil.Format( (decimal)(A50PurchaseOrderId), "ZZZZZ9") : context.localUtil.Format( (decimal)(A50PurchaseOrderId), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPurchaseOrderId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPurchaseOrderId_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_PurchaseOrder.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A4SupplierId), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A4SupplierId), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierId_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_PurchaseOrder.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_4_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_4_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_4_Internalname, sImgUrl, imgprompt_4_Link, "", "", context.GetTheme( ), imgprompt_4_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_PurchaseOrder.htm");
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
         GxWebStd.gx_single_line_edit( context, edtSupplierName_Internalname, A5SupplierName, StringUtil.RTrim( context.localUtil.Format( A5SupplierName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierName_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Name", "left", true, "", "HLP_PurchaseOrder.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPurchaseOrderCreatedDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPurchaseOrderCreatedDate_Internalname, "Created Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPurchaseOrderCreatedDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPurchaseOrderCreatedDate_Internalname, context.localUtil.Format(A52PurchaseOrderCreatedDate, "99/99/99"), context.localUtil.Format( A52PurchaseOrderCreatedDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPurchaseOrderCreatedDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPurchaseOrderCreatedDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "PurchaseOrderDate", "right", false, "", "HLP_PurchaseOrder.htm");
         GxWebStd.gx_bitmap( context, edtPurchaseOrderCreatedDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPurchaseOrderCreatedDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_PurchaseOrder.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPurchaseOrderTotalPaid_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPurchaseOrderTotalPaid_Internalname, "Total Paid", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPurchaseOrderTotalPaid_Internalname, StringUtil.LTrim( StringUtil.NToC( A78PurchaseOrderTotalPaid, 18, 2, ".", "")), StringUtil.LTrim( ((edtPurchaseOrderTotalPaid_Enabled!=0) ? context.localUtil.Format( A78PurchaseOrderTotalPaid, "ZZZZZZZZZZZZZZ9.99") : context.localUtil.Format( A78PurchaseOrderTotalPaid, "ZZZZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPurchaseOrderTotalPaid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPurchaseOrderTotalPaid_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Price", "right", false, "", "HLP_PurchaseOrder.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPurchaseOrderClosedDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPurchaseOrderClosedDate_Internalname, "Closed Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         context.WriteHtmlText( "<div id=\""+edtPurchaseOrderClosedDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPurchaseOrderClosedDate_Internalname, context.localUtil.Format(A66PurchaseOrderClosedDate, "99/99/99"), context.localUtil.Format( A66PurchaseOrderClosedDate, "99/99/99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPurchaseOrderClosedDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPurchaseOrderClosedDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "PurchaseOrderDate", "right", false, "", "HLP_PurchaseOrder.htm");
         GxWebStd.gx_bitmap( context, edtPurchaseOrderClosedDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPurchaseOrderClosedDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_PurchaseOrder.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPurchaseOrderModifiedDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPurchaseOrderModifiedDate_Internalname, "Modified Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         context.WriteHtmlText( "<div id=\""+edtPurchaseOrderModifiedDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPurchaseOrderModifiedDate_Internalname, context.localUtil.Format(A53PurchaseOrderModifiedDate, "99/99/99"), context.localUtil.Format( A53PurchaseOrderModifiedDate, "99/99/99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPurchaseOrderModifiedDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPurchaseOrderModifiedDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_PurchaseOrder.htm");
         GxWebStd.gx_bitmap( context, edtPurchaseOrderModifiedDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPurchaseOrderModifiedDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_PurchaseOrder.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkPurchaseOrderActive_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkPurchaseOrderActive_Internalname, "Order Active", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkPurchaseOrderActive_Internalname, StringUtil.BoolToStr( A79PurchaseOrderActive), "", "Order Active", 1, chkPurchaseOrderActive.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(69, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,69);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPurchaseOrderDetailsQuantity_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPurchaseOrderDetailsQuantity_Internalname, "Details Quantity", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPurchaseOrderDetailsQuantity_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0, ".", "")), StringUtil.LTrim( ((edtPurchaseOrderDetailsQuantity_Enabled!=0) ? context.localUtil.Format( (decimal)(A67PurchaseOrderDetailsQuantity), "ZZZ9") : context.localUtil.Format( (decimal)(A67PurchaseOrderDetailsQuantity), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPurchaseOrderDetailsQuantity_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPurchaseOrderDetailsQuantity_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_PurchaseOrder.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTitledetail_Internalname, "Detail", "", "", lblTitledetail_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-04", 0, "", 1, 1, 0, 0, "HLP_PurchaseOrder.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         gxdraw_Gridpurchaseorder_detail( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_PurchaseOrder.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_PurchaseOrder.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_PurchaseOrder.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "Right", "Middle", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void gxdraw_Gridpurchaseorder_detail( )
      {
         /*  Grid Control  */
         StartGridControl83( ) ;
         nGXsfl_83_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount12 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_12 = 1;
               ScanStart0712( ) ;
               while ( RcdFound12 != 0 )
               {
                  init_level_properties12( ) ;
                  getByPrimaryKey0712( ) ;
                  AddRow0712( ) ;
                  ScanNext0712( ) ;
               }
               ScanEnd0712( ) ;
               nBlankRcdCount12 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B96PurchaseOrderLastDetailId = A96PurchaseOrderLastDetailId;
            AssignAttri("", false, "A96PurchaseOrderLastDetailId", StringUtil.LTrimStr( (decimal)(A96PurchaseOrderLastDetailId), 6, 0));
            B67PurchaseOrderDetailsQuantity = A67PurchaseOrderDetailsQuantity;
            AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
            standaloneNotModal0712( ) ;
            standaloneModal0712( ) ;
            sMode12 = Gx_mode;
            while ( nGXsfl_83_idx < nRC_GXsfl_83 )
            {
               bGXsfl_83_Refreshing = true;
               ReadRow0712( ) ;
               edtPurchaseOrderDetailId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PURCHASEORDERDETAILID_"+sGXsfl_83_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtPurchaseOrderDetailId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderDetailId_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               edtProductId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTID_"+sGXsfl_83_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               edtProductName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTNAME_"+sGXsfl_83_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProductName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductName_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               edtPurchaseOrderDetailQuantityOrd_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PURCHASEORDERDETAILQUANTITYORD_"+sGXsfl_83_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtPurchaseOrderDetailQuantityOrd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderDetailQuantityOrd_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               edtPurchaseOrderDetailQuantityRec_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PURCHASEORDERDETAILQUANTITYREC_"+sGXsfl_83_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtPurchaseOrderDetailQuantityRec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderDetailQuantityRec_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               imgprompt_4_Link = cgiGet( "PROMPT_15_"+sGXsfl_83_idx+"Link");
               if ( ( nRcdExists_12 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0712( ) ;
               }
               SendRow0712( ) ;
               bGXsfl_83_Refreshing = false;
            }
            Gx_mode = sMode12;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A96PurchaseOrderLastDetailId = B96PurchaseOrderLastDetailId;
            AssignAttri("", false, "A96PurchaseOrderLastDetailId", StringUtil.LTrimStr( (decimal)(A96PurchaseOrderLastDetailId), 6, 0));
            A67PurchaseOrderDetailsQuantity = B67PurchaseOrderDetailsQuantity;
            AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount12 = 5;
            nRcdExists_12 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0712( ) ;
               while ( RcdFound12 != 0 )
               {
                  sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_8312( ) ;
                  init_level_properties12( ) ;
                  standaloneNotModal0712( ) ;
                  getByPrimaryKey0712( ) ;
                  standaloneModal0712( ) ;
                  AddRow0712( ) ;
                  ScanNext0712( ) ;
               }
               ScanEnd0712( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode12 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx+1), 4, 0), 4, "0");
            SubsflControlProps_8312( ) ;
            InitAll0712( ) ;
            init_level_properties12( ) ;
            B96PurchaseOrderLastDetailId = A96PurchaseOrderLastDetailId;
            AssignAttri("", false, "A96PurchaseOrderLastDetailId", StringUtil.LTrimStr( (decimal)(A96PurchaseOrderLastDetailId), 6, 0));
            B67PurchaseOrderDetailsQuantity = A67PurchaseOrderDetailsQuantity;
            AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
            nRcdExists_12 = 0;
            nIsMod_12 = 0;
            nRcdDeleted_12 = 0;
            nBlankRcdCount12 = (short)(nBlankRcdUsr12+nBlankRcdCount12);
            fRowAdded = 0;
            while ( nBlankRcdCount12 > 0 )
            {
               standaloneNotModal0712( ) ;
               standaloneModal0712( ) ;
               AddRow0712( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtPurchaseOrderDetailId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount12 = (short)(nBlankRcdCount12-1);
            }
            Gx_mode = sMode12;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A96PurchaseOrderLastDetailId = B96PurchaseOrderLastDetailId;
            AssignAttri("", false, "A96PurchaseOrderLastDetailId", StringUtil.LTrimStr( (decimal)(A96PurchaseOrderLastDetailId), 6, 0));
            A67PurchaseOrderDetailsQuantity = B67PurchaseOrderDetailsQuantity;
            AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridpurchaseorder_detailContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridpurchaseorder_detail", Gridpurchaseorder_detailContainer, subGridpurchaseorder_detail_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridpurchaseorder_detailContainerData", Gridpurchaseorder_detailContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridpurchaseorder_detailContainerData"+"V", Gridpurchaseorder_detailContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridpurchaseorder_detailContainerData"+"V"+"\" value='"+Gridpurchaseorder_detailContainer.GridValuesHidden()+"'/>") ;
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
         E11072 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z50PurchaseOrderId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z50PurchaseOrderId"), ".", ","), 18, MidpointRounding.ToEven));
               Z52PurchaseOrderCreatedDate = context.localUtil.CToD( cgiGet( "Z52PurchaseOrderCreatedDate"), 0);
               Z78PurchaseOrderTotalPaid = context.localUtil.CToN( cgiGet( "Z78PurchaseOrderTotalPaid"), ".", ",");
               n78PurchaseOrderTotalPaid = ((Convert.ToDecimal(0)==A78PurchaseOrderTotalPaid) ? true : false);
               Z66PurchaseOrderClosedDate = context.localUtil.CToD( cgiGet( "Z66PurchaseOrderClosedDate"), 0);
               n66PurchaseOrderClosedDate = ((DateTime.MinValue==A66PurchaseOrderClosedDate) ? true : false);
               Z53PurchaseOrderModifiedDate = context.localUtil.CToD( cgiGet( "Z53PurchaseOrderModifiedDate"), 0);
               n53PurchaseOrderModifiedDate = ((DateTime.MinValue==A53PurchaseOrderModifiedDate) ? true : false);
               Z135PurchaseOrderConfirmatedDate = context.localUtil.CToD( cgiGet( "Z135PurchaseOrderConfirmatedDate"), 0);
               n135PurchaseOrderConfirmatedDate = ((DateTime.MinValue==A135PurchaseOrderConfirmatedDate) ? true : false);
               Z79PurchaseOrderActive = StringUtil.StrToBool( cgiGet( "Z79PurchaseOrderActive"));
               Z136PurchaseOrderCanceledDescripti = cgiGet( "Z136PurchaseOrderCanceledDescripti");
               n136PurchaseOrderCanceledDescripti = (String.IsNullOrEmpty(StringUtil.RTrim( A136PurchaseOrderCanceledDescripti)) ? true : false);
               Z138PurchaseOrderWasPaid = StringUtil.StrToBool( cgiGet( "Z138PurchaseOrderWasPaid"));
               n138PurchaseOrderWasPaid = ((false==A138PurchaseOrderWasPaid) ? true : false);
               Z139PurchaseOrderPaidDate = context.localUtil.CToD( cgiGet( "Z139PurchaseOrderPaidDate"), 0);
               n139PurchaseOrderPaidDate = ((DateTime.MinValue==A139PurchaseOrderPaidDate) ? true : false);
               Z4SupplierId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z4SupplierId"), ".", ","), 18, MidpointRounding.ToEven));
               A135PurchaseOrderConfirmatedDate = context.localUtil.CToD( cgiGet( "Z135PurchaseOrderConfirmatedDate"), 0);
               n135PurchaseOrderConfirmatedDate = false;
               n135PurchaseOrderConfirmatedDate = ((DateTime.MinValue==A135PurchaseOrderConfirmatedDate) ? true : false);
               A136PurchaseOrderCanceledDescripti = cgiGet( "Z136PurchaseOrderCanceledDescripti");
               n136PurchaseOrderCanceledDescripti = false;
               n136PurchaseOrderCanceledDescripti = (String.IsNullOrEmpty(StringUtil.RTrim( A136PurchaseOrderCanceledDescripti)) ? true : false);
               A138PurchaseOrderWasPaid = StringUtil.StrToBool( cgiGet( "Z138PurchaseOrderWasPaid"));
               n138PurchaseOrderWasPaid = false;
               n138PurchaseOrderWasPaid = ((false==A138PurchaseOrderWasPaid) ? true : false);
               A139PurchaseOrderPaidDate = context.localUtil.CToD( cgiGet( "Z139PurchaseOrderPaidDate"), 0);
               n139PurchaseOrderPaidDate = false;
               n139PurchaseOrderPaidDate = ((DateTime.MinValue==A139PurchaseOrderPaidDate) ? true : false);
               O96PurchaseOrderLastDetailId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "O96PurchaseOrderLastDetailId"), ".", ","), 18, MidpointRounding.ToEven));
               O67PurchaseOrderDetailsQuantity = (short)(Math.Round(context.localUtil.CToN( cgiGet( "O67PurchaseOrderDetailsQuantity"), ".", ","), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_83 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_83"), ".", ","), 18, MidpointRounding.ToEven));
               N4SupplierId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N4SupplierId"), ".", ","), 18, MidpointRounding.ToEven));
               AV13PurchaseOrderId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vPURCHASEORDERID"), ".", ","), 18, MidpointRounding.ToEven));
               AV11Insert_SupplierId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_SUPPLIERID"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_date = context.localUtil.CToD( cgiGet( "vTODAY"), 0);
               A135PurchaseOrderConfirmatedDate = context.localUtil.CToD( cgiGet( "PURCHASEORDERCONFIRMATEDDATE"), 0);
               n135PurchaseOrderConfirmatedDate = ((DateTime.MinValue==A135PurchaseOrderConfirmatedDate) ? true : false);
               A136PurchaseOrderCanceledDescripti = cgiGet( "PURCHASEORDERCANCELEDDESCRIPTI");
               n136PurchaseOrderCanceledDescripti = (String.IsNullOrEmpty(StringUtil.RTrim( A136PurchaseOrderCanceledDescripti)) ? true : false);
               A138PurchaseOrderWasPaid = StringUtil.StrToBool( cgiGet( "PURCHASEORDERWASPAID"));
               n138PurchaseOrderWasPaid = ((false==A138PurchaseOrderWasPaid) ? true : false);
               A139PurchaseOrderPaidDate = context.localUtil.CToD( cgiGet( "PURCHASEORDERPAIDDATE"), 0);
               n139PurchaseOrderPaidDate = ((DateTime.MinValue==A139PurchaseOrderPaidDate) ? true : false);
               A96PurchaseOrderLastDetailId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PURCHASEORDERLASTDETAILID"), ".", ","), 18, MidpointRounding.ToEven));
               AV16Pgmname = cgiGet( "vPGMNAME");
               A134PurchaseOrderDetailSuggestedPr = context.localUtil.CToN( cgiGet( "PURCHASEORDERDETAILSUGGESTEDPR"), ".", ",");
               n134PurchaseOrderDetailSuggestedPr = false;
               n134PurchaseOrderDetailSuggestedPr = ((Convert.ToDecimal(0)==A134PurchaseOrderDetailSuggestedPr) ? true : false);
               /* Read variables values. */
               A50PurchaseOrderId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPurchaseOrderId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A50PurchaseOrderId", StringUtil.LTrimStr( (decimal)(A50PurchaseOrderId), 6, 0));
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
               if ( context.localUtil.VCDate( cgiGet( edtPurchaseOrderCreatedDate_Internalname), 1) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Purchase Order Created Date"}), 1, "PURCHASEORDERCREATEDDATE");
                  AnyError = 1;
                  GX_FocusControl = edtPurchaseOrderCreatedDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A52PurchaseOrderCreatedDate = DateTime.MinValue;
                  AssignAttri("", false, "A52PurchaseOrderCreatedDate", context.localUtil.Format(A52PurchaseOrderCreatedDate, "99/99/99"));
               }
               else
               {
                  A52PurchaseOrderCreatedDate = context.localUtil.CToD( cgiGet( edtPurchaseOrderCreatedDate_Internalname), 1);
                  AssignAttri("", false, "A52PurchaseOrderCreatedDate", context.localUtil.Format(A52PurchaseOrderCreatedDate, "99/99/99"));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtPurchaseOrderTotalPaid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPurchaseOrderTotalPaid_Internalname), ".", ",") > 999999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PURCHASEORDERTOTALPAID");
                  AnyError = 1;
                  GX_FocusControl = edtPurchaseOrderTotalPaid_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A78PurchaseOrderTotalPaid = 0;
                  n78PurchaseOrderTotalPaid = false;
                  AssignAttri("", false, "A78PurchaseOrderTotalPaid", StringUtil.LTrimStr( A78PurchaseOrderTotalPaid, 18, 2));
               }
               else
               {
                  A78PurchaseOrderTotalPaid = context.localUtil.CToN( cgiGet( edtPurchaseOrderTotalPaid_Internalname), ".", ",");
                  n78PurchaseOrderTotalPaid = false;
                  AssignAttri("", false, "A78PurchaseOrderTotalPaid", StringUtil.LTrimStr( A78PurchaseOrderTotalPaid, 18, 2));
               }
               n78PurchaseOrderTotalPaid = ((Convert.ToDecimal(0)==A78PurchaseOrderTotalPaid) ? true : false);
               A66PurchaseOrderClosedDate = context.localUtil.CToD( cgiGet( edtPurchaseOrderClosedDate_Internalname), 1);
               n66PurchaseOrderClosedDate = false;
               AssignAttri("", false, "A66PurchaseOrderClosedDate", context.localUtil.Format(A66PurchaseOrderClosedDate, "99/99/99"));
               A53PurchaseOrderModifiedDate = context.localUtil.CToD( cgiGet( edtPurchaseOrderModifiedDate_Internalname), 1);
               n53PurchaseOrderModifiedDate = false;
               AssignAttri("", false, "A53PurchaseOrderModifiedDate", context.localUtil.Format(A53PurchaseOrderModifiedDate, "99/99/99"));
               A79PurchaseOrderActive = StringUtil.StrToBool( cgiGet( chkPurchaseOrderActive_Internalname));
               AssignAttri("", false, "A79PurchaseOrderActive", A79PurchaseOrderActive);
               A67PurchaseOrderDetailsQuantity = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPurchaseOrderDetailsQuantity_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"PurchaseOrder");
               A50PurchaseOrderId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPurchaseOrderId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A50PurchaseOrderId", StringUtil.LTrimStr( (decimal)(A50PurchaseOrderId), 6, 0));
               forbiddenHiddens.Add("PurchaseOrderId", context.localUtil.Format( (decimal)(A50PurchaseOrderId), "ZZZZZ9"));
               A66PurchaseOrderClosedDate = context.localUtil.CToD( cgiGet( edtPurchaseOrderClosedDate_Internalname), 1);
               n66PurchaseOrderClosedDate = false;
               AssignAttri("", false, "A66PurchaseOrderClosedDate", context.localUtil.Format(A66PurchaseOrderClosedDate, "99/99/99"));
               forbiddenHiddens.Add("PurchaseOrderClosedDate", context.localUtil.Format(A66PurchaseOrderClosedDate, "99/99/99"));
               A53PurchaseOrderModifiedDate = context.localUtil.CToD( cgiGet( edtPurchaseOrderModifiedDate_Internalname), 1);
               n53PurchaseOrderModifiedDate = false;
               AssignAttri("", false, "A53PurchaseOrderModifiedDate", context.localUtil.Format(A53PurchaseOrderModifiedDate, "99/99/99"));
               forbiddenHiddens.Add("PurchaseOrderModifiedDate", context.localUtil.Format(A53PurchaseOrderModifiedDate, "99/99/99"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("PurchaseOrderConfirmatedDate", context.localUtil.Format(A135PurchaseOrderConfirmatedDate, "99/99/99"));
               forbiddenHiddens.Add("PurchaseOrderCanceledDescripti", StringUtil.RTrim( context.localUtil.Format( A136PurchaseOrderCanceledDescripti, "")));
               forbiddenHiddens.Add("PurchaseOrderWasPaid", StringUtil.BoolToStr( A138PurchaseOrderWasPaid));
               forbiddenHiddens.Add("PurchaseOrderPaidDate", context.localUtil.Format(A139PurchaseOrderPaidDate, "99/99/99"));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A50PurchaseOrderId != Z50PurchaseOrderId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("purchaseorder:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A50PurchaseOrderId = (int)(Math.Round(NumberUtil.Val( GetPar( "PurchaseOrderId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A50PurchaseOrderId", StringUtil.LTrimStr( (decimal)(A50PurchaseOrderId), 6, 0));
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
                     sMode10 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode10;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound10 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_070( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "PURCHASEORDERID");
                        AnyError = 1;
                        GX_FocusControl = edtPurchaseOrderId_Internalname;
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
                           E11072 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12072 ();
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
            E12072 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0710( ) ;
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
            DisableAttributes0710( ) ;
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

      protected void CONFIRM_070( )
      {
         BeforeValidate0710( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0710( ) ;
            }
            else
            {
               CheckExtendedTable0710( ) ;
               CloseExtendedTableCursors0710( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode10 = Gx_mode;
            CONFIRM_0712( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode10;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode10;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_0712( )
      {
         s96PurchaseOrderLastDetailId = O96PurchaseOrderLastDetailId;
         AssignAttri("", false, "A96PurchaseOrderLastDetailId", StringUtil.LTrimStr( (decimal)(A96PurchaseOrderLastDetailId), 6, 0));
         s67PurchaseOrderDetailsQuantity = O67PurchaseOrderDetailsQuantity;
         AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
         nGXsfl_83_idx = 0;
         while ( nGXsfl_83_idx < nRC_GXsfl_83 )
         {
            ReadRow0712( ) ;
            if ( ( nRcdExists_12 != 0 ) || ( nIsMod_12 != 0 ) )
            {
               GetKey0712( ) ;
               if ( ( nRcdExists_12 == 0 ) && ( nRcdDeleted_12 == 0 ) )
               {
                  if ( RcdFound12 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0712( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0712( ) ;
                        CloseExtendedTableCursors0712( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                        O96PurchaseOrderLastDetailId = A96PurchaseOrderLastDetailId;
                        AssignAttri("", false, "A96PurchaseOrderLastDetailId", StringUtil.LTrimStr( (decimal)(A96PurchaseOrderLastDetailId), 6, 0));
                        O67PurchaseOrderDetailsQuantity = A67PurchaseOrderDetailsQuantity;
                        AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
                     }
                  }
                  else
                  {
                     GXCCtl = "PURCHASEORDERDETAILID_" + sGXsfl_83_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtPurchaseOrderDetailId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound12 != 0 )
                  {
                     if ( nRcdDeleted_12 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0712( ) ;
                        Load0712( ) ;
                        BeforeValidate0712( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0712( ) ;
                           O96PurchaseOrderLastDetailId = A96PurchaseOrderLastDetailId;
                           AssignAttri("", false, "A96PurchaseOrderLastDetailId", StringUtil.LTrimStr( (decimal)(A96PurchaseOrderLastDetailId), 6, 0));
                           O67PurchaseOrderDetailsQuantity = A67PurchaseOrderDetailsQuantity;
                           AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
                        }
                     }
                     else
                     {
                        if ( nIsMod_12 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0712( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0712( ) ;
                              CloseExtendedTableCursors0712( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                              O96PurchaseOrderLastDetailId = A96PurchaseOrderLastDetailId;
                              AssignAttri("", false, "A96PurchaseOrderLastDetailId", StringUtil.LTrimStr( (decimal)(A96PurchaseOrderLastDetailId), 6, 0));
                              O67PurchaseOrderDetailsQuantity = A67PurchaseOrderDetailsQuantity;
                              AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_12 == 0 )
                     {
                        GXCCtl = "PURCHASEORDERDETAILID_" + sGXsfl_83_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtPurchaseOrderDetailId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtPurchaseOrderDetailId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A61PurchaseOrderDetailId), 6, 0, ".", ""))) ;
            ChangePostValue( edtProductId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", ""))) ;
            ChangePostValue( edtProductName_Internalname, A16ProductName) ;
            ChangePostValue( edtPurchaseOrderDetailQuantityOrd_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A76PurchaseOrderDetailQuantityOrd), 6, 0, ".", ""))) ;
            ChangePostValue( edtPurchaseOrderDetailQuantityRec_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A77PurchaseOrderDetailQuantityRec), 6, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z61PurchaseOrderDetailId_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z61PurchaseOrderDetailId), 6, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z76PurchaseOrderDetailQuantityOrd_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z76PurchaseOrderDetailQuantityOrd), 6, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z77PurchaseOrderDetailQuantityRec_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z77PurchaseOrderDetailQuantityRec), 6, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z134PurchaseOrderDetailSuggestedPr_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( Z134PurchaseOrderDetailSuggestedPr, 18, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z15ProductId_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z15ProductId), 6, 0, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_12_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_12), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_12_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_12), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_12_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_12), 4, 0, ".", ""))) ;
            if ( nIsMod_12 != 0 )
            {
               ChangePostValue( "PURCHASEORDERDETAILID_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPurchaseOrderDetailId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTID_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTNAME_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PURCHASEORDERDETAILQUANTITYORD_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPurchaseOrderDetailQuantityOrd_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PURCHASEORDERDETAILQUANTITYREC_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPurchaseOrderDetailQuantityRec_Enabled), 5, 0, ".", ""))) ;
            }
         }
         O96PurchaseOrderLastDetailId = s96PurchaseOrderLastDetailId;
         AssignAttri("", false, "A96PurchaseOrderLastDetailId", StringUtil.LTrimStr( (decimal)(A96PurchaseOrderLastDetailId), 6, 0));
         O67PurchaseOrderDetailsQuantity = s67PurchaseOrderDetailsQuantity;
         AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
         /* Start of After( level) rules */
         /* Using cursor T00076 */
         pr_default.execute(3, new Object[] {A50PurchaseOrderId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            A96PurchaseOrderLastDetailId = T00076_A96PurchaseOrderLastDetailId[0];
         }
         else
         {
            A67PurchaseOrderDetailsQuantity = 0;
            AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
            A96PurchaseOrderLastDetailId = 0;
            AssignAttri("", false, "A96PurchaseOrderLastDetailId", StringUtil.LTrimStr( (decimal)(A96PurchaseOrderLastDetailId), 6, 0));
         }
         /* End of After( level) rules */
      }

      protected void ResetCaption070( )
      {
      }

      protected void E11072( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_SdtSDTContextSession1 = new GeneXus.Programs.general.ui.SdtSDTContextSession();
         new checkauthentication(context ).execute( out  GXt_SdtSDTContextSession1) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && ! new haspermission(context).executeUdp(  "purchaseorder view") )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV16Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         else if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! new haspermission(context).executeUdp(  "purchaseorder insert") )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV16Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         else if ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ! new haspermission(context).executeUdp(  "purchaseorder update") )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV16Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         else if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! new haspermission(context).executeUdp(  "purchaseorder delete") )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV16Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV16Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV16Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         AV11Insert_SupplierId = 0;
         AssignAttri("", false, "AV11Insert_SupplierId", StringUtil.LTrimStr( (decimal)(AV11Insert_SupplierId), 6, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV16Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV17GXV1 = 1;
            AssignAttri("", false, "AV17GXV1", StringUtil.LTrimStr( (decimal)(AV17GXV1), 8, 0));
            while ( AV17GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((GeneXus.Programs.general.ui.SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV17GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "SupplierId") == 0 )
               {
                  AV11Insert_SupplierId = (int)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_SupplierId", StringUtil.LTrimStr( (decimal)(AV11Insert_SupplierId), 6, 0));
               }
               AV17GXV1 = (int)(AV17GXV1+1);
               AssignAttri("", false, "AV17GXV1", StringUtil.LTrimStr( (decimal)(AV17GXV1), 8, 0));
            }
         }
      }

      protected void E12072( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwpurchaseorder.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0710( short GX_JID )
      {
         if ( ( GX_JID == 20 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z52PurchaseOrderCreatedDate = T00078_A52PurchaseOrderCreatedDate[0];
               Z78PurchaseOrderTotalPaid = T00078_A78PurchaseOrderTotalPaid[0];
               Z66PurchaseOrderClosedDate = T00078_A66PurchaseOrderClosedDate[0];
               Z53PurchaseOrderModifiedDate = T00078_A53PurchaseOrderModifiedDate[0];
               Z135PurchaseOrderConfirmatedDate = T00078_A135PurchaseOrderConfirmatedDate[0];
               Z79PurchaseOrderActive = T00078_A79PurchaseOrderActive[0];
               Z136PurchaseOrderCanceledDescripti = T00078_A136PurchaseOrderCanceledDescripti[0];
               Z138PurchaseOrderWasPaid = T00078_A138PurchaseOrderWasPaid[0];
               Z139PurchaseOrderPaidDate = T00078_A139PurchaseOrderPaidDate[0];
               Z4SupplierId = T00078_A4SupplierId[0];
            }
            else
            {
               Z52PurchaseOrderCreatedDate = A52PurchaseOrderCreatedDate;
               Z78PurchaseOrderTotalPaid = A78PurchaseOrderTotalPaid;
               Z66PurchaseOrderClosedDate = A66PurchaseOrderClosedDate;
               Z53PurchaseOrderModifiedDate = A53PurchaseOrderModifiedDate;
               Z135PurchaseOrderConfirmatedDate = A135PurchaseOrderConfirmatedDate;
               Z79PurchaseOrderActive = A79PurchaseOrderActive;
               Z136PurchaseOrderCanceledDescripti = A136PurchaseOrderCanceledDescripti;
               Z138PurchaseOrderWasPaid = A138PurchaseOrderWasPaid;
               Z139PurchaseOrderPaidDate = A139PurchaseOrderPaidDate;
               Z4SupplierId = A4SupplierId;
            }
         }
         if ( GX_JID == -20 )
         {
            Z50PurchaseOrderId = A50PurchaseOrderId;
            Z52PurchaseOrderCreatedDate = A52PurchaseOrderCreatedDate;
            Z78PurchaseOrderTotalPaid = A78PurchaseOrderTotalPaid;
            Z66PurchaseOrderClosedDate = A66PurchaseOrderClosedDate;
            Z53PurchaseOrderModifiedDate = A53PurchaseOrderModifiedDate;
            Z135PurchaseOrderConfirmatedDate = A135PurchaseOrderConfirmatedDate;
            Z79PurchaseOrderActive = A79PurchaseOrderActive;
            Z136PurchaseOrderCanceledDescripti = A136PurchaseOrderCanceledDescripti;
            Z138PurchaseOrderWasPaid = A138PurchaseOrderWasPaid;
            Z139PurchaseOrderPaidDate = A139PurchaseOrderPaidDate;
            Z4SupplierId = A4SupplierId;
            Z67PurchaseOrderDetailsQuantity = A67PurchaseOrderDetailsQuantity;
            Z96PurchaseOrderLastDetailId = A96PurchaseOrderLastDetailId;
            Z5SupplierName = A5SupplierName;
         }
      }

      protected void standaloneNotModal( )
      {
         edtPurchaseOrderId_Enabled = 0;
         AssignProp("", false, edtPurchaseOrderId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderId_Enabled), 5, 0), true);
         edtPurchaseOrderClosedDate_Enabled = 0;
         AssignProp("", false, edtPurchaseOrderClosedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderClosedDate_Enabled), 5, 0), true);
         edtPurchaseOrderModifiedDate_Enabled = 0;
         AssignProp("", false, edtPurchaseOrderModifiedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderModifiedDate_Enabled), 5, 0), true);
         Gx_date = DateTimeUtil.Today( context);
         AssignAttri("", false, "Gx_date", context.localUtil.Format(Gx_date, "99/99/99"));
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         imgprompt_4_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0020.aspx"+"',["+"{Ctrl:gx.dom.el('"+"SUPPLIERID"+"'), id:'"+"SUPPLIERID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtPurchaseOrderId_Enabled = 0;
         AssignProp("", false, edtPurchaseOrderId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderId_Enabled), 5, 0), true);
         edtPurchaseOrderClosedDate_Enabled = 0;
         AssignProp("", false, edtPurchaseOrderClosedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderClosedDate_Enabled), 5, 0), true);
         edtPurchaseOrderModifiedDate_Enabled = 0;
         AssignProp("", false, edtPurchaseOrderModifiedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderModifiedDate_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV13PurchaseOrderId) )
         {
            A50PurchaseOrderId = AV13PurchaseOrderId;
            AssignAttri("", false, "A50PurchaseOrderId", StringUtil.LTrimStr( (decimal)(A50PurchaseOrderId), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_SupplierId) )
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_SupplierId) )
         {
            A4SupplierId = AV11Insert_SupplierId;
            AssignAttri("", false, "A4SupplierId", StringUtil.LTrimStr( (decimal)(A4SupplierId), 6, 0));
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
         if ( IsIns( )  && (false==A79PurchaseOrderActive) && ( Gx_BScreen == 0 ) )
         {
            A79PurchaseOrderActive = true;
            AssignAttri("", false, "A79PurchaseOrderActive", A79PurchaseOrderActive);
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            A52PurchaseOrderCreatedDate = Gx_date;
            AssignAttri("", false, "A52PurchaseOrderCreatedDate", context.localUtil.Format(A52PurchaseOrderCreatedDate, "99/99/99"));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
         {
            A53PurchaseOrderModifiedDate = Gx_date;
            n53PurchaseOrderModifiedDate = false;
            AssignAttri("", false, "A53PurchaseOrderModifiedDate", context.localUtil.Format(A53PurchaseOrderModifiedDate, "99/99/99"));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T00076 */
            pr_default.execute(3, new Object[] {A50PurchaseOrderId});
            if ( (pr_default.getStatus(3) != 101) )
            {
               A67PurchaseOrderDetailsQuantity = T00076_A67PurchaseOrderDetailsQuantity[0];
               AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
               A96PurchaseOrderLastDetailId = T00076_A96PurchaseOrderLastDetailId[0];
            }
            else
            {
               A67PurchaseOrderDetailsQuantity = 0;
               AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
               A96PurchaseOrderLastDetailId = 0;
               AssignAttri("", false, "A96PurchaseOrderLastDetailId", StringUtil.LTrimStr( (decimal)(A96PurchaseOrderLastDetailId), 6, 0));
            }
            O67PurchaseOrderDetailsQuantity = A67PurchaseOrderDetailsQuantity;
            AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
            O96PurchaseOrderLastDetailId = A96PurchaseOrderLastDetailId;
            AssignAttri("", false, "A96PurchaseOrderLastDetailId", StringUtil.LTrimStr( (decimal)(A96PurchaseOrderLastDetailId), 6, 0));
            pr_default.close(3);
            AV16Pgmname = "PurchaseOrder";
            AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
            /* Using cursor T00079 */
            pr_default.execute(6, new Object[] {A4SupplierId});
            A5SupplierName = T00079_A5SupplierName[0];
            AssignAttri("", false, "A5SupplierName", A5SupplierName);
            pr_default.close(6);
         }
      }

      protected void Load0710( )
      {
         /* Using cursor T000711 */
         pr_default.execute(7, new Object[] {A50PurchaseOrderId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound10 = 1;
            A5SupplierName = T000711_A5SupplierName[0];
            AssignAttri("", false, "A5SupplierName", A5SupplierName);
            A52PurchaseOrderCreatedDate = T000711_A52PurchaseOrderCreatedDate[0];
            AssignAttri("", false, "A52PurchaseOrderCreatedDate", context.localUtil.Format(A52PurchaseOrderCreatedDate, "99/99/99"));
            A78PurchaseOrderTotalPaid = T000711_A78PurchaseOrderTotalPaid[0];
            n78PurchaseOrderTotalPaid = T000711_n78PurchaseOrderTotalPaid[0];
            AssignAttri("", false, "A78PurchaseOrderTotalPaid", StringUtil.LTrimStr( A78PurchaseOrderTotalPaid, 18, 2));
            A66PurchaseOrderClosedDate = T000711_A66PurchaseOrderClosedDate[0];
            n66PurchaseOrderClosedDate = T000711_n66PurchaseOrderClosedDate[0];
            AssignAttri("", false, "A66PurchaseOrderClosedDate", context.localUtil.Format(A66PurchaseOrderClosedDate, "99/99/99"));
            A53PurchaseOrderModifiedDate = T000711_A53PurchaseOrderModifiedDate[0];
            n53PurchaseOrderModifiedDate = T000711_n53PurchaseOrderModifiedDate[0];
            AssignAttri("", false, "A53PurchaseOrderModifiedDate", context.localUtil.Format(A53PurchaseOrderModifiedDate, "99/99/99"));
            A135PurchaseOrderConfirmatedDate = T000711_A135PurchaseOrderConfirmatedDate[0];
            n135PurchaseOrderConfirmatedDate = T000711_n135PurchaseOrderConfirmatedDate[0];
            A79PurchaseOrderActive = T000711_A79PurchaseOrderActive[0];
            AssignAttri("", false, "A79PurchaseOrderActive", A79PurchaseOrderActive);
            A136PurchaseOrderCanceledDescripti = T000711_A136PurchaseOrderCanceledDescripti[0];
            n136PurchaseOrderCanceledDescripti = T000711_n136PurchaseOrderCanceledDescripti[0];
            A138PurchaseOrderWasPaid = T000711_A138PurchaseOrderWasPaid[0];
            n138PurchaseOrderWasPaid = T000711_n138PurchaseOrderWasPaid[0];
            A139PurchaseOrderPaidDate = T000711_A139PurchaseOrderPaidDate[0];
            n139PurchaseOrderPaidDate = T000711_n139PurchaseOrderPaidDate[0];
            A4SupplierId = T000711_A4SupplierId[0];
            AssignAttri("", false, "A4SupplierId", StringUtil.LTrimStr( (decimal)(A4SupplierId), 6, 0));
            A67PurchaseOrderDetailsQuantity = T000711_A67PurchaseOrderDetailsQuantity[0];
            AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
            A96PurchaseOrderLastDetailId = T000711_A96PurchaseOrderLastDetailId[0];
            ZM0710( -20) ;
         }
         pr_default.close(7);
         OnLoadActions0710( ) ;
      }

      protected void OnLoadActions0710( )
      {
         O96PurchaseOrderLastDetailId = A96PurchaseOrderLastDetailId;
         AssignAttri("", false, "A96PurchaseOrderLastDetailId", StringUtil.LTrimStr( (decimal)(A96PurchaseOrderLastDetailId), 6, 0));
         O67PurchaseOrderDetailsQuantity = A67PurchaseOrderDetailsQuantity;
         AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
         AV16Pgmname = "PurchaseOrder";
         AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
      }

      protected void CheckExtendedTable0710( )
      {
         nIsDirty_10 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV16Pgmname = "PurchaseOrder";
         AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
         /* Using cursor T00076 */
         pr_default.execute(3, new Object[] {A50PurchaseOrderId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            A67PurchaseOrderDetailsQuantity = T00076_A67PurchaseOrderDetailsQuantity[0];
            AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
            A96PurchaseOrderLastDetailId = T00076_A96PurchaseOrderLastDetailId[0];
         }
         else
         {
            nIsDirty_10 = 1;
            A67PurchaseOrderDetailsQuantity = 0;
            AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
            nIsDirty_10 = 1;
            A96PurchaseOrderLastDetailId = 0;
            AssignAttri("", false, "A96PurchaseOrderLastDetailId", StringUtil.LTrimStr( (decimal)(A96PurchaseOrderLastDetailId), 6, 0));
         }
         pr_default.close(3);
         /* Using cursor T00079 */
         pr_default.execute(6, new Object[] {A4SupplierId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No matching 'Supplier'.", "ForeignKeyNotFound", 1, "SUPPLIERID");
            AnyError = 1;
            GX_FocusControl = edtSupplierId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A5SupplierName = T00079_A5SupplierName[0];
         AssignAttri("", false, "A5SupplierName", A5SupplierName);
         pr_default.close(6);
         if ( ! ( (DateTime.MinValue==A52PurchaseOrderCreatedDate) || ( DateTimeUtil.ResetTime ( A52PurchaseOrderCreatedDate ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Purchase Order Created Date is out of range", "OutOfRange", 1, "PURCHASEORDERCREATEDDATE");
            AnyError = 1;
            GX_FocusControl = edtPurchaseOrderCreatedDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( ( A78PurchaseOrderTotalPaid >= Convert.ToDecimal( 0 )) && ( A78PurchaseOrderTotalPaid <= 999999999999999.99m ) ) || (Convert.ToDecimal(0)==A78PurchaseOrderTotalPaid) ) )
         {
            GX_msglist.addItem("Invalid Price", "OutOfRange", 1, "PURCHASEORDERTOTALPAID");
            AnyError = 1;
            GX_FocusControl = edtPurchaseOrderTotalPaid_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0710( )
      {
         pr_default.close(3);
         pr_default.close(6);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_22( int A50PurchaseOrderId )
      {
         /* Using cursor T000713 */
         pr_default.execute(8, new Object[] {A50PurchaseOrderId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            A67PurchaseOrderDetailsQuantity = T000713_A67PurchaseOrderDetailsQuantity[0];
            AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
            A96PurchaseOrderLastDetailId = T000713_A96PurchaseOrderLastDetailId[0];
         }
         else
         {
            A67PurchaseOrderDetailsQuantity = 0;
            AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
            A96PurchaseOrderLastDetailId = 0;
            AssignAttri("", false, "A96PurchaseOrderLastDetailId", StringUtil.LTrimStr( (decimal)(A96PurchaseOrderLastDetailId), 6, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A96PurchaseOrderLastDetailId), 6, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void gxLoad_21( int A4SupplierId )
      {
         /* Using cursor T000714 */
         pr_default.execute(9, new Object[] {A4SupplierId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No matching 'Supplier'.", "ForeignKeyNotFound", 1, "SUPPLIERID");
            AnyError = 1;
            GX_FocusControl = edtSupplierId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A5SupplierName = T000714_A5SupplierName[0];
         AssignAttri("", false, "A5SupplierName", A5SupplierName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A5SupplierName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void GetKey0710( )
      {
         /* Using cursor T000715 */
         pr_default.execute(10, new Object[] {A50PurchaseOrderId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound10 = 1;
         }
         else
         {
            RcdFound10 = 0;
         }
         pr_default.close(10);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00078 */
         pr_default.execute(5, new Object[] {A50PurchaseOrderId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            ZM0710( 20) ;
            RcdFound10 = 1;
            A50PurchaseOrderId = T00078_A50PurchaseOrderId[0];
            AssignAttri("", false, "A50PurchaseOrderId", StringUtil.LTrimStr( (decimal)(A50PurchaseOrderId), 6, 0));
            A52PurchaseOrderCreatedDate = T00078_A52PurchaseOrderCreatedDate[0];
            AssignAttri("", false, "A52PurchaseOrderCreatedDate", context.localUtil.Format(A52PurchaseOrderCreatedDate, "99/99/99"));
            A78PurchaseOrderTotalPaid = T00078_A78PurchaseOrderTotalPaid[0];
            n78PurchaseOrderTotalPaid = T00078_n78PurchaseOrderTotalPaid[0];
            AssignAttri("", false, "A78PurchaseOrderTotalPaid", StringUtil.LTrimStr( A78PurchaseOrderTotalPaid, 18, 2));
            A66PurchaseOrderClosedDate = T00078_A66PurchaseOrderClosedDate[0];
            n66PurchaseOrderClosedDate = T00078_n66PurchaseOrderClosedDate[0];
            AssignAttri("", false, "A66PurchaseOrderClosedDate", context.localUtil.Format(A66PurchaseOrderClosedDate, "99/99/99"));
            A53PurchaseOrderModifiedDate = T00078_A53PurchaseOrderModifiedDate[0];
            n53PurchaseOrderModifiedDate = T00078_n53PurchaseOrderModifiedDate[0];
            AssignAttri("", false, "A53PurchaseOrderModifiedDate", context.localUtil.Format(A53PurchaseOrderModifiedDate, "99/99/99"));
            A135PurchaseOrderConfirmatedDate = T00078_A135PurchaseOrderConfirmatedDate[0];
            n135PurchaseOrderConfirmatedDate = T00078_n135PurchaseOrderConfirmatedDate[0];
            A79PurchaseOrderActive = T00078_A79PurchaseOrderActive[0];
            AssignAttri("", false, "A79PurchaseOrderActive", A79PurchaseOrderActive);
            A136PurchaseOrderCanceledDescripti = T00078_A136PurchaseOrderCanceledDescripti[0];
            n136PurchaseOrderCanceledDescripti = T00078_n136PurchaseOrderCanceledDescripti[0];
            A138PurchaseOrderWasPaid = T00078_A138PurchaseOrderWasPaid[0];
            n138PurchaseOrderWasPaid = T00078_n138PurchaseOrderWasPaid[0];
            A139PurchaseOrderPaidDate = T00078_A139PurchaseOrderPaidDate[0];
            n139PurchaseOrderPaidDate = T00078_n139PurchaseOrderPaidDate[0];
            A4SupplierId = T00078_A4SupplierId[0];
            AssignAttri("", false, "A4SupplierId", StringUtil.LTrimStr( (decimal)(A4SupplierId), 6, 0));
            Z50PurchaseOrderId = A50PurchaseOrderId;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0710( ) ;
            if ( AnyError == 1 )
            {
               RcdFound10 = 0;
               InitializeNonKey0710( ) ;
            }
            Gx_mode = sMode10;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound10 = 0;
            InitializeNonKey0710( ) ;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode10;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(5);
      }

      protected void getEqualNoModal( )
      {
         GetKey0710( ) ;
         if ( RcdFound10 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound10 = 0;
         /* Using cursor T000716 */
         pr_default.execute(11, new Object[] {A50PurchaseOrderId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T000716_A50PurchaseOrderId[0] < A50PurchaseOrderId ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T000716_A50PurchaseOrderId[0] > A50PurchaseOrderId ) ) )
            {
               A50PurchaseOrderId = T000716_A50PurchaseOrderId[0];
               AssignAttri("", false, "A50PurchaseOrderId", StringUtil.LTrimStr( (decimal)(A50PurchaseOrderId), 6, 0));
               RcdFound10 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void move_previous( )
      {
         RcdFound10 = 0;
         /* Using cursor T000717 */
         pr_default.execute(12, new Object[] {A50PurchaseOrderId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            while ( (pr_default.getStatus(12) != 101) && ( ( T000717_A50PurchaseOrderId[0] > A50PurchaseOrderId ) ) )
            {
               pr_default.readNext(12);
            }
            if ( (pr_default.getStatus(12) != 101) && ( ( T000717_A50PurchaseOrderId[0] < A50PurchaseOrderId ) ) )
            {
               A50PurchaseOrderId = T000717_A50PurchaseOrderId[0];
               AssignAttri("", false, "A50PurchaseOrderId", StringUtil.LTrimStr( (decimal)(A50PurchaseOrderId), 6, 0));
               RcdFound10 = 1;
            }
         }
         pr_default.close(12);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0710( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A96PurchaseOrderLastDetailId = O96PurchaseOrderLastDetailId;
            AssignAttri("", false, "A96PurchaseOrderLastDetailId", StringUtil.LTrimStr( (decimal)(A96PurchaseOrderLastDetailId), 6, 0));
            A67PurchaseOrderDetailsQuantity = O67PurchaseOrderDetailsQuantity;
            AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
            GX_FocusControl = edtSupplierId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0710( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound10 == 1 )
            {
               if ( A50PurchaseOrderId != Z50PurchaseOrderId )
               {
                  A50PurchaseOrderId = Z50PurchaseOrderId;
                  AssignAttri("", false, "A50PurchaseOrderId", StringUtil.LTrimStr( (decimal)(A50PurchaseOrderId), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PURCHASEORDERID");
                  AnyError = 1;
                  GX_FocusControl = edtPurchaseOrderId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  A96PurchaseOrderLastDetailId = O96PurchaseOrderLastDetailId;
                  AssignAttri("", false, "A96PurchaseOrderLastDetailId", StringUtil.LTrimStr( (decimal)(A96PurchaseOrderLastDetailId), 6, 0));
                  A67PurchaseOrderDetailsQuantity = O67PurchaseOrderDetailsQuantity;
                  AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtSupplierId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  A96PurchaseOrderLastDetailId = O96PurchaseOrderLastDetailId;
                  AssignAttri("", false, "A96PurchaseOrderLastDetailId", StringUtil.LTrimStr( (decimal)(A96PurchaseOrderLastDetailId), 6, 0));
                  A67PurchaseOrderDetailsQuantity = O67PurchaseOrderDetailsQuantity;
                  AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
                  Update0710( ) ;
                  GX_FocusControl = edtSupplierId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A50PurchaseOrderId != Z50PurchaseOrderId )
               {
                  /* Insert record */
                  A96PurchaseOrderLastDetailId = O96PurchaseOrderLastDetailId;
                  AssignAttri("", false, "A96PurchaseOrderLastDetailId", StringUtil.LTrimStr( (decimal)(A96PurchaseOrderLastDetailId), 6, 0));
                  A67PurchaseOrderDetailsQuantity = O67PurchaseOrderDetailsQuantity;
                  AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
                  GX_FocusControl = edtSupplierId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0710( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PURCHASEORDERID");
                     AnyError = 1;
                     GX_FocusControl = edtPurchaseOrderId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     A96PurchaseOrderLastDetailId = O96PurchaseOrderLastDetailId;
                     AssignAttri("", false, "A96PurchaseOrderLastDetailId", StringUtil.LTrimStr( (decimal)(A96PurchaseOrderLastDetailId), 6, 0));
                     A67PurchaseOrderDetailsQuantity = O67PurchaseOrderDetailsQuantity;
                     AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
                     GX_FocusControl = edtSupplierId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0710( ) ;
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
         if ( A50PurchaseOrderId != Z50PurchaseOrderId )
         {
            A50PurchaseOrderId = Z50PurchaseOrderId;
            AssignAttri("", false, "A50PurchaseOrderId", StringUtil.LTrimStr( (decimal)(A50PurchaseOrderId), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PURCHASEORDERID");
            AnyError = 1;
            GX_FocusControl = edtPurchaseOrderId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            A96PurchaseOrderLastDetailId = O96PurchaseOrderLastDetailId;
            AssignAttri("", false, "A96PurchaseOrderLastDetailId", StringUtil.LTrimStr( (decimal)(A96PurchaseOrderLastDetailId), 6, 0));
            A67PurchaseOrderDetailsQuantity = O67PurchaseOrderDetailsQuantity;
            AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtSupplierId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0710( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00077 */
            pr_default.execute(4, new Object[] {A50PurchaseOrderId});
            if ( (pr_default.getStatus(4) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PurchaseOrder"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(4) == 101) || ( DateTimeUtil.ResetTime ( Z52PurchaseOrderCreatedDate ) != DateTimeUtil.ResetTime ( T00077_A52PurchaseOrderCreatedDate[0] ) ) || ( Z78PurchaseOrderTotalPaid != T00077_A78PurchaseOrderTotalPaid[0] ) || ( DateTimeUtil.ResetTime ( Z66PurchaseOrderClosedDate ) != DateTimeUtil.ResetTime ( T00077_A66PurchaseOrderClosedDate[0] ) ) || ( DateTimeUtil.ResetTime ( Z53PurchaseOrderModifiedDate ) != DateTimeUtil.ResetTime ( T00077_A53PurchaseOrderModifiedDate[0] ) ) || ( DateTimeUtil.ResetTime ( Z135PurchaseOrderConfirmatedDate ) != DateTimeUtil.ResetTime ( T00077_A135PurchaseOrderConfirmatedDate[0] ) ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z79PurchaseOrderActive != T00077_A79PurchaseOrderActive[0] ) || ( StringUtil.StrCmp(Z136PurchaseOrderCanceledDescripti, T00077_A136PurchaseOrderCanceledDescripti[0]) != 0 ) || ( Z138PurchaseOrderWasPaid != T00077_A138PurchaseOrderWasPaid[0] ) || ( DateTimeUtil.ResetTime ( Z139PurchaseOrderPaidDate ) != DateTimeUtil.ResetTime ( T00077_A139PurchaseOrderPaidDate[0] ) ) || ( Z4SupplierId != T00077_A4SupplierId[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z52PurchaseOrderCreatedDate ) != DateTimeUtil.ResetTime ( T00077_A52PurchaseOrderCreatedDate[0] ) )
               {
                  GXUtil.WriteLog("purchaseorder:[seudo value changed for attri]"+"PurchaseOrderCreatedDate");
                  GXUtil.WriteLogRaw("Old: ",Z52PurchaseOrderCreatedDate);
                  GXUtil.WriteLogRaw("Current: ",T00077_A52PurchaseOrderCreatedDate[0]);
               }
               if ( Z78PurchaseOrderTotalPaid != T00077_A78PurchaseOrderTotalPaid[0] )
               {
                  GXUtil.WriteLog("purchaseorder:[seudo value changed for attri]"+"PurchaseOrderTotalPaid");
                  GXUtil.WriteLogRaw("Old: ",Z78PurchaseOrderTotalPaid);
                  GXUtil.WriteLogRaw("Current: ",T00077_A78PurchaseOrderTotalPaid[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z66PurchaseOrderClosedDate ) != DateTimeUtil.ResetTime ( T00077_A66PurchaseOrderClosedDate[0] ) )
               {
                  GXUtil.WriteLog("purchaseorder:[seudo value changed for attri]"+"PurchaseOrderClosedDate");
                  GXUtil.WriteLogRaw("Old: ",Z66PurchaseOrderClosedDate);
                  GXUtil.WriteLogRaw("Current: ",T00077_A66PurchaseOrderClosedDate[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z53PurchaseOrderModifiedDate ) != DateTimeUtil.ResetTime ( T00077_A53PurchaseOrderModifiedDate[0] ) )
               {
                  GXUtil.WriteLog("purchaseorder:[seudo value changed for attri]"+"PurchaseOrderModifiedDate");
                  GXUtil.WriteLogRaw("Old: ",Z53PurchaseOrderModifiedDate);
                  GXUtil.WriteLogRaw("Current: ",T00077_A53PurchaseOrderModifiedDate[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z135PurchaseOrderConfirmatedDate ) != DateTimeUtil.ResetTime ( T00077_A135PurchaseOrderConfirmatedDate[0] ) )
               {
                  GXUtil.WriteLog("purchaseorder:[seudo value changed for attri]"+"PurchaseOrderConfirmatedDate");
                  GXUtil.WriteLogRaw("Old: ",Z135PurchaseOrderConfirmatedDate);
                  GXUtil.WriteLogRaw("Current: ",T00077_A135PurchaseOrderConfirmatedDate[0]);
               }
               if ( Z79PurchaseOrderActive != T00077_A79PurchaseOrderActive[0] )
               {
                  GXUtil.WriteLog("purchaseorder:[seudo value changed for attri]"+"PurchaseOrderActive");
                  GXUtil.WriteLogRaw("Old: ",Z79PurchaseOrderActive);
                  GXUtil.WriteLogRaw("Current: ",T00077_A79PurchaseOrderActive[0]);
               }
               if ( StringUtil.StrCmp(Z136PurchaseOrderCanceledDescripti, T00077_A136PurchaseOrderCanceledDescripti[0]) != 0 )
               {
                  GXUtil.WriteLog("purchaseorder:[seudo value changed for attri]"+"PurchaseOrderCanceledDescripti");
                  GXUtil.WriteLogRaw("Old: ",Z136PurchaseOrderCanceledDescripti);
                  GXUtil.WriteLogRaw("Current: ",T00077_A136PurchaseOrderCanceledDescripti[0]);
               }
               if ( Z138PurchaseOrderWasPaid != T00077_A138PurchaseOrderWasPaid[0] )
               {
                  GXUtil.WriteLog("purchaseorder:[seudo value changed for attri]"+"PurchaseOrderWasPaid");
                  GXUtil.WriteLogRaw("Old: ",Z138PurchaseOrderWasPaid);
                  GXUtil.WriteLogRaw("Current: ",T00077_A138PurchaseOrderWasPaid[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z139PurchaseOrderPaidDate ) != DateTimeUtil.ResetTime ( T00077_A139PurchaseOrderPaidDate[0] ) )
               {
                  GXUtil.WriteLog("purchaseorder:[seudo value changed for attri]"+"PurchaseOrderPaidDate");
                  GXUtil.WriteLogRaw("Old: ",Z139PurchaseOrderPaidDate);
                  GXUtil.WriteLogRaw("Current: ",T00077_A139PurchaseOrderPaidDate[0]);
               }
               if ( Z4SupplierId != T00077_A4SupplierId[0] )
               {
                  GXUtil.WriteLog("purchaseorder:[seudo value changed for attri]"+"SupplierId");
                  GXUtil.WriteLogRaw("Old: ",Z4SupplierId);
                  GXUtil.WriteLogRaw("Current: ",T00077_A4SupplierId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"PurchaseOrder"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0710( )
      {
         BeforeValidate0710( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0710( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0710( 0) ;
            CheckOptimisticConcurrency0710( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0710( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0710( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000718 */
                     pr_default.execute(13, new Object[] {A52PurchaseOrderCreatedDate, n78PurchaseOrderTotalPaid, A78PurchaseOrderTotalPaid, n66PurchaseOrderClosedDate, A66PurchaseOrderClosedDate, n53PurchaseOrderModifiedDate, A53PurchaseOrderModifiedDate, n135PurchaseOrderConfirmatedDate, A135PurchaseOrderConfirmatedDate, A79PurchaseOrderActive, n136PurchaseOrderCanceledDescripti, A136PurchaseOrderCanceledDescripti, n138PurchaseOrderWasPaid, A138PurchaseOrderWasPaid, n139PurchaseOrderPaidDate, A139PurchaseOrderPaidDate, A4SupplierId});
                     A50PurchaseOrderId = T000718_A50PurchaseOrderId[0];
                     AssignAttri("", false, "A50PurchaseOrderId", StringUtil.LTrimStr( (decimal)(A50PurchaseOrderId), 6, 0));
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("PurchaseOrder");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0710( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption070( ) ;
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
               Load0710( ) ;
            }
            EndLevel0710( ) ;
         }
         CloseExtendedTableCursors0710( ) ;
      }

      protected void Update0710( )
      {
         BeforeValidate0710( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0710( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0710( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0710( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0710( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000719 */
                     pr_default.execute(14, new Object[] {A52PurchaseOrderCreatedDate, n78PurchaseOrderTotalPaid, A78PurchaseOrderTotalPaid, n66PurchaseOrderClosedDate, A66PurchaseOrderClosedDate, n53PurchaseOrderModifiedDate, A53PurchaseOrderModifiedDate, n135PurchaseOrderConfirmatedDate, A135PurchaseOrderConfirmatedDate, A79PurchaseOrderActive, n136PurchaseOrderCanceledDescripti, A136PurchaseOrderCanceledDescripti, n138PurchaseOrderWasPaid, A138PurchaseOrderWasPaid, n139PurchaseOrderPaidDate, A139PurchaseOrderPaidDate, A4SupplierId, A50PurchaseOrderId});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("PurchaseOrder");
                     if ( (pr_default.getStatus(14) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PurchaseOrder"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0710( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0710( ) ;
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
            EndLevel0710( ) ;
         }
         CloseExtendedTableCursors0710( ) ;
      }

      protected void DeferredUpdate0710( )
      {
      }

      protected void delete( )
      {
         BeforeValidate0710( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0710( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0710( ) ;
            AfterConfirm0710( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0710( ) ;
               if ( AnyError == 0 )
               {
                  A96PurchaseOrderLastDetailId = O96PurchaseOrderLastDetailId;
                  AssignAttri("", false, "A96PurchaseOrderLastDetailId", StringUtil.LTrimStr( (decimal)(A96PurchaseOrderLastDetailId), 6, 0));
                  A67PurchaseOrderDetailsQuantity = O67PurchaseOrderDetailsQuantity;
                  AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
                  ScanStart0712( ) ;
                  while ( RcdFound12 != 0 )
                  {
                     getByPrimaryKey0712( ) ;
                     Delete0712( ) ;
                     ScanNext0712( ) ;
                     O96PurchaseOrderLastDetailId = A96PurchaseOrderLastDetailId;
                     AssignAttri("", false, "A96PurchaseOrderLastDetailId", StringUtil.LTrimStr( (decimal)(A96PurchaseOrderLastDetailId), 6, 0));
                     O67PurchaseOrderDetailsQuantity = A67PurchaseOrderDetailsQuantity;
                     AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
                  }
                  ScanEnd0712( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000720 */
                     pr_default.execute(15, new Object[] {A50PurchaseOrderId});
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("PurchaseOrder");
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
         sMode10 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0710( ) ;
         Gx_mode = sMode10;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0710( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV16Pgmname = "PurchaseOrder";
            AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
            /* Using cursor T000722 */
            pr_default.execute(16, new Object[] {A50PurchaseOrderId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               A67PurchaseOrderDetailsQuantity = T000722_A67PurchaseOrderDetailsQuantity[0];
               AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
               A96PurchaseOrderLastDetailId = T000722_A96PurchaseOrderLastDetailId[0];
            }
            else
            {
               A67PurchaseOrderDetailsQuantity = 0;
               AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
               A96PurchaseOrderLastDetailId = 0;
               AssignAttri("", false, "A96PurchaseOrderLastDetailId", StringUtil.LTrimStr( (decimal)(A96PurchaseOrderLastDetailId), 6, 0));
            }
            pr_default.close(16);
            /* Using cursor T000723 */
            pr_default.execute(17, new Object[] {A4SupplierId});
            A5SupplierName = T000723_A5SupplierName[0];
            AssignAttri("", false, "A5SupplierName", A5SupplierName);
            pr_default.close(17);
         }
      }

      protected void ProcessNestedLevel0712( )
      {
         s96PurchaseOrderLastDetailId = O96PurchaseOrderLastDetailId;
         AssignAttri("", false, "A96PurchaseOrderLastDetailId", StringUtil.LTrimStr( (decimal)(A96PurchaseOrderLastDetailId), 6, 0));
         s67PurchaseOrderDetailsQuantity = O67PurchaseOrderDetailsQuantity;
         AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
         nGXsfl_83_idx = 0;
         while ( nGXsfl_83_idx < nRC_GXsfl_83 )
         {
            ReadRow0712( ) ;
            if ( ( nRcdExists_12 != 0 ) || ( nIsMod_12 != 0 ) )
            {
               standaloneNotModal0712( ) ;
               GetKey0712( ) ;
               if ( ( nRcdExists_12 == 0 ) && ( nRcdDeleted_12 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0712( ) ;
               }
               else
               {
                  if ( RcdFound12 != 0 )
                  {
                     if ( ( nRcdDeleted_12 != 0 ) && ( nRcdExists_12 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0712( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_12 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0712( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_12 == 0 )
                     {
                        GXCCtl = "PURCHASEORDERDETAILID_" + sGXsfl_83_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtPurchaseOrderDetailId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
               O96PurchaseOrderLastDetailId = A96PurchaseOrderLastDetailId;
               AssignAttri("", false, "A96PurchaseOrderLastDetailId", StringUtil.LTrimStr( (decimal)(A96PurchaseOrderLastDetailId), 6, 0));
               O67PurchaseOrderDetailsQuantity = A67PurchaseOrderDetailsQuantity;
               AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
            }
            ChangePostValue( edtPurchaseOrderDetailId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A61PurchaseOrderDetailId), 6, 0, ".", ""))) ;
            ChangePostValue( edtProductId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", ""))) ;
            ChangePostValue( edtProductName_Internalname, A16ProductName) ;
            ChangePostValue( edtPurchaseOrderDetailQuantityOrd_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A76PurchaseOrderDetailQuantityOrd), 6, 0, ".", ""))) ;
            ChangePostValue( edtPurchaseOrderDetailQuantityRec_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A77PurchaseOrderDetailQuantityRec), 6, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z61PurchaseOrderDetailId_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z61PurchaseOrderDetailId), 6, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z76PurchaseOrderDetailQuantityOrd_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z76PurchaseOrderDetailQuantityOrd), 6, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z77PurchaseOrderDetailQuantityRec_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z77PurchaseOrderDetailQuantityRec), 6, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z134PurchaseOrderDetailSuggestedPr_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( Z134PurchaseOrderDetailSuggestedPr, 18, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z15ProductId_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z15ProductId), 6, 0, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_12_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_12), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_12_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_12), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_12_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_12), 4, 0, ".", ""))) ;
            if ( nIsMod_12 != 0 )
            {
               ChangePostValue( "PURCHASEORDERDETAILID_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPurchaseOrderDetailId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTID_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTNAME_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PURCHASEORDERDETAILQUANTITYORD_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPurchaseOrderDetailQuantityOrd_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PURCHASEORDERDETAILQUANTITYREC_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPurchaseOrderDetailQuantityRec_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* Using cursor T000722 */
         pr_default.execute(16, new Object[] {A50PurchaseOrderId});
         if ( (pr_default.getStatus(16) != 101) )
         {
            A96PurchaseOrderLastDetailId = T000722_A96PurchaseOrderLastDetailId[0];
         }
         else
         {
            A67PurchaseOrderDetailsQuantity = 0;
            AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
            A96PurchaseOrderLastDetailId = 0;
            AssignAttri("", false, "A96PurchaseOrderLastDetailId", StringUtil.LTrimStr( (decimal)(A96PurchaseOrderLastDetailId), 6, 0));
         }
         /* End of After( level) rules */
         InitAll0712( ) ;
         if ( AnyError != 0 )
         {
            O96PurchaseOrderLastDetailId = s96PurchaseOrderLastDetailId;
            AssignAttri("", false, "A96PurchaseOrderLastDetailId", StringUtil.LTrimStr( (decimal)(A96PurchaseOrderLastDetailId), 6, 0));
            O67PurchaseOrderDetailsQuantity = s67PurchaseOrderDetailsQuantity;
            AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
         }
         nRcdExists_12 = 0;
         nIsMod_12 = 0;
         nRcdDeleted_12 = 0;
      }

      protected void ProcessLevel0710( )
      {
         /* Save parent mode. */
         sMode10 = Gx_mode;
         ProcessNestedLevel0712( ) ;
         if ( AnyError != 0 )
         {
            O96PurchaseOrderLastDetailId = s96PurchaseOrderLastDetailId;
            AssignAttri("", false, "A96PurchaseOrderLastDetailId", StringUtil.LTrimStr( (decimal)(A96PurchaseOrderLastDetailId), 6, 0));
            O67PurchaseOrderDetailsQuantity = s67PurchaseOrderDetailsQuantity;
            AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
         }
         /* Restore parent mode. */
         Gx_mode = sMode10;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel0710( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(4);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0710( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(5);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(17);
            pr_default.close(16);
            pr_default.close(2);
            context.CommitDataStores("purchaseorder",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues070( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(5);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(17);
            pr_default.close(16);
            pr_default.close(2);
            context.RollbackDataStores("purchaseorder",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0710( )
      {
         /* Scan By routine */
         /* Using cursor T000724 */
         pr_default.execute(18);
         RcdFound10 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound10 = 1;
            A50PurchaseOrderId = T000724_A50PurchaseOrderId[0];
            AssignAttri("", false, "A50PurchaseOrderId", StringUtil.LTrimStr( (decimal)(A50PurchaseOrderId), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0710( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound10 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound10 = 1;
            A50PurchaseOrderId = T000724_A50PurchaseOrderId[0];
            AssignAttri("", false, "A50PurchaseOrderId", StringUtil.LTrimStr( (decimal)(A50PurchaseOrderId), 6, 0));
         }
      }

      protected void ScanEnd0710( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm0710( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0710( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0710( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0710( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0710( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0710( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0710( )
      {
         edtPurchaseOrderId_Enabled = 0;
         AssignProp("", false, edtPurchaseOrderId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderId_Enabled), 5, 0), true);
         edtSupplierId_Enabled = 0;
         AssignProp("", false, edtSupplierId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierId_Enabled), 5, 0), true);
         edtSupplierName_Enabled = 0;
         AssignProp("", false, edtSupplierName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierName_Enabled), 5, 0), true);
         edtPurchaseOrderCreatedDate_Enabled = 0;
         AssignProp("", false, edtPurchaseOrderCreatedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderCreatedDate_Enabled), 5, 0), true);
         edtPurchaseOrderTotalPaid_Enabled = 0;
         AssignProp("", false, edtPurchaseOrderTotalPaid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderTotalPaid_Enabled), 5, 0), true);
         edtPurchaseOrderClosedDate_Enabled = 0;
         AssignProp("", false, edtPurchaseOrderClosedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderClosedDate_Enabled), 5, 0), true);
         edtPurchaseOrderModifiedDate_Enabled = 0;
         AssignProp("", false, edtPurchaseOrderModifiedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderModifiedDate_Enabled), 5, 0), true);
         chkPurchaseOrderActive.Enabled = 0;
         AssignProp("", false, chkPurchaseOrderActive_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkPurchaseOrderActive.Enabled), 5, 0), true);
         edtPurchaseOrderDetailsQuantity_Enabled = 0;
         AssignProp("", false, edtPurchaseOrderDetailsQuantity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderDetailsQuantity_Enabled), 5, 0), true);
      }

      protected void ZM0712( short GX_JID )
      {
         if ( ( GX_JID == 23 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z76PurchaseOrderDetailQuantityOrd = T00073_A76PurchaseOrderDetailQuantityOrd[0];
               Z77PurchaseOrderDetailQuantityRec = T00073_A77PurchaseOrderDetailQuantityRec[0];
               Z134PurchaseOrderDetailSuggestedPr = T00073_A134PurchaseOrderDetailSuggestedPr[0];
               Z15ProductId = T00073_A15ProductId[0];
            }
            else
            {
               Z76PurchaseOrderDetailQuantityOrd = A76PurchaseOrderDetailQuantityOrd;
               Z77PurchaseOrderDetailQuantityRec = A77PurchaseOrderDetailQuantityRec;
               Z134PurchaseOrderDetailSuggestedPr = A134PurchaseOrderDetailSuggestedPr;
               Z15ProductId = A15ProductId;
            }
         }
         if ( GX_JID == -23 )
         {
            Z50PurchaseOrderId = A50PurchaseOrderId;
            Z61PurchaseOrderDetailId = A61PurchaseOrderDetailId;
            Z76PurchaseOrderDetailQuantityOrd = A76PurchaseOrderDetailQuantityOrd;
            Z77PurchaseOrderDetailQuantityRec = A77PurchaseOrderDetailQuantityRec;
            Z134PurchaseOrderDetailSuggestedPr = A134PurchaseOrderDetailSuggestedPr;
            Z15ProductId = A15ProductId;
            Z16ProductName = A16ProductName;
         }
      }

      protected void standaloneNotModal0712( )
      {
      }

      protected void standaloneModal0712( )
      {
         if ( IsIns( )  )
         {
            A96PurchaseOrderLastDetailId = (int)(O96PurchaseOrderLastDetailId+1);
            AssignAttri("", false, "A96PurchaseOrderLastDetailId", StringUtil.LTrimStr( (decimal)(A96PurchaseOrderLastDetailId), 6, 0));
         }
         if ( IsIns( )  && ( Gx_BScreen == 1 ) )
         {
            A61PurchaseOrderDetailId = A96PurchaseOrderLastDetailId;
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtPurchaseOrderDetailId_Enabled = 0;
            AssignProp("", false, edtPurchaseOrderDetailId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderDetailId_Enabled), 5, 0), !bGXsfl_83_Refreshing);
         }
         else
         {
            edtPurchaseOrderDetailId_Enabled = 1;
            AssignProp("", false, edtPurchaseOrderDetailId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderDetailId_Enabled), 5, 0), !bGXsfl_83_Refreshing);
         }
      }

      protected void Load0712( )
      {
         /* Using cursor T000725 */
         pr_default.execute(19, new Object[] {A50PurchaseOrderId, A61PurchaseOrderDetailId});
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound12 = 1;
            A16ProductName = T000725_A16ProductName[0];
            A76PurchaseOrderDetailQuantityOrd = T000725_A76PurchaseOrderDetailQuantityOrd[0];
            A77PurchaseOrderDetailQuantityRec = T000725_A77PurchaseOrderDetailQuantityRec[0];
            A134PurchaseOrderDetailSuggestedPr = T000725_A134PurchaseOrderDetailSuggestedPr[0];
            n134PurchaseOrderDetailSuggestedPr = T000725_n134PurchaseOrderDetailSuggestedPr[0];
            A15ProductId = T000725_A15ProductId[0];
            ZM0712( -23) ;
         }
         pr_default.close(19);
         OnLoadActions0712( ) ;
      }

      protected void OnLoadActions0712( )
      {
         if ( IsIns( )  )
         {
            A67PurchaseOrderDetailsQuantity = (short)(O67PurchaseOrderDetailsQuantity+1);
            AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
         }
         else
         {
            if ( IsUpd( )  )
            {
               A67PurchaseOrderDetailsQuantity = O67PurchaseOrderDetailsQuantity;
               AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
            }
            else
            {
               if ( IsDlt( )  )
               {
                  A67PurchaseOrderDetailsQuantity = (short)(O67PurchaseOrderDetailsQuantity-1);
                  AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
               }
            }
         }
      }

      protected void CheckExtendedTable0712( )
      {
         nIsDirty_12 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal0712( ) ;
         if ( IsIns( )  )
         {
            nIsDirty_12 = 1;
            A67PurchaseOrderDetailsQuantity = (short)(O67PurchaseOrderDetailsQuantity+1);
            AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
         }
         else
         {
            if ( IsUpd( )  )
            {
               nIsDirty_12 = 1;
               A67PurchaseOrderDetailsQuantity = O67PurchaseOrderDetailsQuantity;
               AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
            }
            else
            {
               if ( IsDlt( )  )
               {
                  nIsDirty_12 = 1;
                  A67PurchaseOrderDetailsQuantity = (short)(O67PurchaseOrderDetailsQuantity-1);
                  AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
               }
            }
         }
         /* Using cursor T00074 */
         pr_default.execute(2, new Object[] {A15ProductId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "PRODUCTID_" + sGXsfl_83_idx;
            GX_msglist.addItem("No matching 'Product'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProductId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A16ProductName = T00074_A16ProductName[0];
         pr_default.close(2);
         if ( A76PurchaseOrderDetailQuantityOrd <= 0 )
         {
            GXCCtl = "PURCHASEORDERDETAILQUANTITYORD_" + sGXsfl_83_idx;
            GX_msglist.addItem("Enter a positive, integer number", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtPurchaseOrderDetailQuantityOrd_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( A77PurchaseOrderDetailQuantityRec < 0 )
         {
            GXCCtl = "PURCHASEORDERDETAILQUANTITYREC_" + sGXsfl_83_idx;
            GX_msglist.addItem("Enter a positive, integer number o zero", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtPurchaseOrderDetailQuantityRec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0712( )
      {
         pr_default.close(2);
      }

      protected void enableDisable0712( )
      {
      }

      protected void gxLoad_24( int A15ProductId )
      {
         /* Using cursor T000726 */
         pr_default.execute(20, new Object[] {A15ProductId});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GXCCtl = "PRODUCTID_" + sGXsfl_83_idx;
            GX_msglist.addItem("No matching 'Product'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProductId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A16ProductName = T000726_A16ProductName[0];
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

      protected void GetKey0712( )
      {
         /* Using cursor T000727 */
         pr_default.execute(21, new Object[] {A50PurchaseOrderId, A61PurchaseOrderDetailId});
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound12 = 1;
         }
         else
         {
            RcdFound12 = 0;
         }
         pr_default.close(21);
      }

      protected void getByPrimaryKey0712( )
      {
         /* Using cursor T00073 */
         pr_default.execute(1, new Object[] {A50PurchaseOrderId, A61PurchaseOrderDetailId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0712( 23) ;
            RcdFound12 = 1;
            InitializeNonKey0712( ) ;
            A61PurchaseOrderDetailId = T00073_A61PurchaseOrderDetailId[0];
            A76PurchaseOrderDetailQuantityOrd = T00073_A76PurchaseOrderDetailQuantityOrd[0];
            A77PurchaseOrderDetailQuantityRec = T00073_A77PurchaseOrderDetailQuantityRec[0];
            A134PurchaseOrderDetailSuggestedPr = T00073_A134PurchaseOrderDetailSuggestedPr[0];
            n134PurchaseOrderDetailSuggestedPr = T00073_n134PurchaseOrderDetailSuggestedPr[0];
            A15ProductId = T00073_A15ProductId[0];
            Z50PurchaseOrderId = A50PurchaseOrderId;
            Z61PurchaseOrderDetailId = A61PurchaseOrderDetailId;
            sMode12 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0712( ) ;
            Gx_mode = sMode12;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound12 = 0;
            InitializeNonKey0712( ) ;
            sMode12 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0712( ) ;
            Gx_mode = sMode12;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0712( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0712( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00072 */
            pr_default.execute(0, new Object[] {A50PurchaseOrderId, A61PurchaseOrderDetailId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PurchaseOrderDetail"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z76PurchaseOrderDetailQuantityOrd != T00072_A76PurchaseOrderDetailQuantityOrd[0] ) || ( Z77PurchaseOrderDetailQuantityRec != T00072_A77PurchaseOrderDetailQuantityRec[0] ) || ( Z134PurchaseOrderDetailSuggestedPr != T00072_A134PurchaseOrderDetailSuggestedPr[0] ) || ( Z15ProductId != T00072_A15ProductId[0] ) )
            {
               if ( Z76PurchaseOrderDetailQuantityOrd != T00072_A76PurchaseOrderDetailQuantityOrd[0] )
               {
                  GXUtil.WriteLog("purchaseorder:[seudo value changed for attri]"+"PurchaseOrderDetailQuantityOrd");
                  GXUtil.WriteLogRaw("Old: ",Z76PurchaseOrderDetailQuantityOrd);
                  GXUtil.WriteLogRaw("Current: ",T00072_A76PurchaseOrderDetailQuantityOrd[0]);
               }
               if ( Z77PurchaseOrderDetailQuantityRec != T00072_A77PurchaseOrderDetailQuantityRec[0] )
               {
                  GXUtil.WriteLog("purchaseorder:[seudo value changed for attri]"+"PurchaseOrderDetailQuantityRec");
                  GXUtil.WriteLogRaw("Old: ",Z77PurchaseOrderDetailQuantityRec);
                  GXUtil.WriteLogRaw("Current: ",T00072_A77PurchaseOrderDetailQuantityRec[0]);
               }
               if ( Z134PurchaseOrderDetailSuggestedPr != T00072_A134PurchaseOrderDetailSuggestedPr[0] )
               {
                  GXUtil.WriteLog("purchaseorder:[seudo value changed for attri]"+"PurchaseOrderDetailSuggestedPr");
                  GXUtil.WriteLogRaw("Old: ",Z134PurchaseOrderDetailSuggestedPr);
                  GXUtil.WriteLogRaw("Current: ",T00072_A134PurchaseOrderDetailSuggestedPr[0]);
               }
               if ( Z15ProductId != T00072_A15ProductId[0] )
               {
                  GXUtil.WriteLog("purchaseorder:[seudo value changed for attri]"+"ProductId");
                  GXUtil.WriteLogRaw("Old: ",Z15ProductId);
                  GXUtil.WriteLogRaw("Current: ",T00072_A15ProductId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"PurchaseOrderDetail"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0712( )
      {
         BeforeValidate0712( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0712( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0712( 0) ;
            CheckOptimisticConcurrency0712( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0712( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0712( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000728 */
                     pr_default.execute(22, new Object[] {A50PurchaseOrderId, A61PurchaseOrderDetailId, A76PurchaseOrderDetailQuantityOrd, A77PurchaseOrderDetailQuantityRec, n134PurchaseOrderDetailSuggestedPr, A134PurchaseOrderDetailSuggestedPr, A15ProductId});
                     pr_default.close(22);
                     pr_default.SmartCacheProvider.SetUpdated("PurchaseOrderDetail");
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
               Load0712( ) ;
            }
            EndLevel0712( ) ;
         }
         CloseExtendedTableCursors0712( ) ;
      }

      protected void Update0712( )
      {
         BeforeValidate0712( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0712( ) ;
         }
         if ( ( nIsMod_12 != 0 ) || ( nIsDirty_12 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0712( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0712( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0712( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000729 */
                        pr_default.execute(23, new Object[] {A76PurchaseOrderDetailQuantityOrd, A77PurchaseOrderDetailQuantityRec, n134PurchaseOrderDetailSuggestedPr, A134PurchaseOrderDetailSuggestedPr, A15ProductId, A50PurchaseOrderId, A61PurchaseOrderDetailId});
                        pr_default.close(23);
                        pr_default.SmartCacheProvider.SetUpdated("PurchaseOrderDetail");
                        if ( (pr_default.getStatus(23) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PurchaseOrderDetail"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0712( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0712( ) ;
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
               EndLevel0712( ) ;
            }
         }
         CloseExtendedTableCursors0712( ) ;
      }

      protected void DeferredUpdate0712( )
      {
      }

      protected void Delete0712( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0712( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0712( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0712( ) ;
            AfterConfirm0712( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0712( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000730 */
                  pr_default.execute(24, new Object[] {A50PurchaseOrderId, A61PurchaseOrderDetailId});
                  pr_default.close(24);
                  pr_default.SmartCacheProvider.SetUpdated("PurchaseOrderDetail");
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
         sMode12 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0712( ) ;
         Gx_mode = sMode12;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0712( )
      {
         standaloneModal0712( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            if ( IsIns( )  )
            {
               A67PurchaseOrderDetailsQuantity = (short)(O67PurchaseOrderDetailsQuantity+1);
               AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
            }
            else
            {
               if ( IsUpd( )  )
               {
                  A67PurchaseOrderDetailsQuantity = O67PurchaseOrderDetailsQuantity;
                  AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
               }
               else
               {
                  if ( IsDlt( )  )
                  {
                     A67PurchaseOrderDetailsQuantity = (short)(O67PurchaseOrderDetailsQuantity-1);
                     AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
                  }
               }
            }
            /* Using cursor T000731 */
            pr_default.execute(25, new Object[] {A15ProductId});
            A16ProductName = T000731_A16ProductName[0];
            pr_default.close(25);
         }
      }

      protected void EndLevel0712( )
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

      public void ScanStart0712( )
      {
         /* Scan By routine */
         /* Using cursor T000732 */
         pr_default.execute(26, new Object[] {A50PurchaseOrderId});
         RcdFound12 = 0;
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound12 = 1;
            A61PurchaseOrderDetailId = T000732_A61PurchaseOrderDetailId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0712( )
      {
         /* Scan next routine */
         pr_default.readNext(26);
         RcdFound12 = 0;
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound12 = 1;
            A61PurchaseOrderDetailId = T000732_A61PurchaseOrderDetailId[0];
         }
      }

      protected void ScanEnd0712( )
      {
         pr_default.close(26);
      }

      protected void AfterConfirm0712( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0712( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0712( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0712( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0712( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0712( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0712( )
      {
         edtPurchaseOrderDetailId_Enabled = 0;
         AssignProp("", false, edtPurchaseOrderDetailId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderDetailId_Enabled), 5, 0), !bGXsfl_83_Refreshing);
         edtProductId_Enabled = 0;
         AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), !bGXsfl_83_Refreshing);
         edtProductName_Enabled = 0;
         AssignProp("", false, edtProductName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductName_Enabled), 5, 0), !bGXsfl_83_Refreshing);
         edtPurchaseOrderDetailQuantityOrd_Enabled = 0;
         AssignProp("", false, edtPurchaseOrderDetailQuantityOrd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderDetailQuantityOrd_Enabled), 5, 0), !bGXsfl_83_Refreshing);
         edtPurchaseOrderDetailQuantityRec_Enabled = 0;
         AssignProp("", false, edtPurchaseOrderDetailQuantityRec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderDetailQuantityRec_Enabled), 5, 0), !bGXsfl_83_Refreshing);
      }

      protected void send_integrity_lvl_hashes0712( )
      {
      }

      protected void send_integrity_lvl_hashes0710( )
      {
      }

      protected void SubsflControlProps_8312( )
      {
         edtPurchaseOrderDetailId_Internalname = "PURCHASEORDERDETAILID_"+sGXsfl_83_idx;
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_83_idx;
         imgprompt_15_Internalname = "PROMPT_15_"+sGXsfl_83_idx;
         edtProductName_Internalname = "PRODUCTNAME_"+sGXsfl_83_idx;
         edtPurchaseOrderDetailQuantityOrd_Internalname = "PURCHASEORDERDETAILQUANTITYORD_"+sGXsfl_83_idx;
         edtPurchaseOrderDetailQuantityRec_Internalname = "PURCHASEORDERDETAILQUANTITYREC_"+sGXsfl_83_idx;
      }

      protected void SubsflControlProps_fel_8312( )
      {
         edtPurchaseOrderDetailId_Internalname = "PURCHASEORDERDETAILID_"+sGXsfl_83_fel_idx;
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_83_fel_idx;
         imgprompt_15_Internalname = "PROMPT_15_"+sGXsfl_83_fel_idx;
         edtProductName_Internalname = "PRODUCTNAME_"+sGXsfl_83_fel_idx;
         edtPurchaseOrderDetailQuantityOrd_Internalname = "PURCHASEORDERDETAILQUANTITYORD_"+sGXsfl_83_fel_idx;
         edtPurchaseOrderDetailQuantityRec_Internalname = "PURCHASEORDERDETAILQUANTITYREC_"+sGXsfl_83_fel_idx;
      }

      protected void AddRow0712( )
      {
         nGXsfl_83_idx = (int)(nGXsfl_83_idx+1);
         sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx), 4, 0), 4, "0");
         SubsflControlProps_8312( ) ;
         SendRow0712( ) ;
      }

      protected void SendRow0712( )
      {
         Gridpurchaseorder_detailRow = GXWebRow.GetNew(context);
         if ( subGridpurchaseorder_detail_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridpurchaseorder_detail_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridpurchaseorder_detail_Class, "") != 0 )
            {
               subGridpurchaseorder_detail_Linesclass = subGridpurchaseorder_detail_Class+"Odd";
            }
         }
         else if ( subGridpurchaseorder_detail_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridpurchaseorder_detail_Backstyle = 0;
            subGridpurchaseorder_detail_Backcolor = subGridpurchaseorder_detail_Allbackcolor;
            if ( StringUtil.StrCmp(subGridpurchaseorder_detail_Class, "") != 0 )
            {
               subGridpurchaseorder_detail_Linesclass = subGridpurchaseorder_detail_Class+"Uniform";
            }
         }
         else if ( subGridpurchaseorder_detail_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridpurchaseorder_detail_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridpurchaseorder_detail_Class, "") != 0 )
            {
               subGridpurchaseorder_detail_Linesclass = subGridpurchaseorder_detail_Class+"Odd";
            }
            subGridpurchaseorder_detail_Backcolor = (int)(0x0);
         }
         else if ( subGridpurchaseorder_detail_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridpurchaseorder_detail_Backstyle = 1;
            if ( ((int)((nGXsfl_83_idx) % (2))) == 0 )
            {
               subGridpurchaseorder_detail_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridpurchaseorder_detail_Class, "") != 0 )
               {
                  subGridpurchaseorder_detail_Linesclass = subGridpurchaseorder_detail_Class+"Even";
               }
            }
            else
            {
               subGridpurchaseorder_detail_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridpurchaseorder_detail_Class, "") != 0 )
               {
                  subGridpurchaseorder_detail_Linesclass = subGridpurchaseorder_detail_Class+"Odd";
               }
            }
         }
         imgprompt_15_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0050.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PRODUCTID_"+sGXsfl_83_idx+"'), id:'"+"PRODUCTID_"+sGXsfl_83_idx+"'"+",IOType:'out'}"+"],"+"gx.dom.form()."+"nIsMod_12_"+sGXsfl_83_idx+","+"'', false"+","+"false"+");");
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_12_" + sGXsfl_83_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 84,'',false,'" + sGXsfl_83_idx + "',83)\"";
         ROClassString = "Attribute";
         Gridpurchaseorder_detailRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPurchaseOrderDetailId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A61PurchaseOrderDetailId), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A61PurchaseOrderDetailId), "ZZZZZ9"))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,84);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPurchaseOrderDetailId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtPurchaseOrderDetailId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)83,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_12_" + sGXsfl_83_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 85,'',false,'" + sGXsfl_83_idx + "',83)\"";
         ROClassString = "Attribute";
         Gridpurchaseorder_detailRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", "")),StringUtil.LTrim( ((edtProductId_Enabled!=0) ? context.localUtil.Format( (decimal)(A15ProductId), "ZZZZZ9") : context.localUtil.Format( (decimal)(A15ProductId), "ZZZZZ9")))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,85);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProductId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)83,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_15_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_15_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         Gridpurchaseorder_detailRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_15_Internalname,(string)sImgUrl,(string)imgprompt_15_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_15_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridpurchaseorder_detailRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductName_Internalname,(string)A16ProductName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProductName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)83,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_12_" + sGXsfl_83_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 87,'',false,'" + sGXsfl_83_idx + "',83)\"";
         ROClassString = "Attribute";
         Gridpurchaseorder_detailRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPurchaseOrderDetailQuantityOrd_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A76PurchaseOrderDetailQuantityOrd), 6, 0, ".", "")),StringUtil.LTrim( ((edtPurchaseOrderDetailQuantityOrd_Enabled!=0) ? context.localUtil.Format( (decimal)(A76PurchaseOrderDetailQuantityOrd), "ZZZZZ9") : context.localUtil.Format( (decimal)(A76PurchaseOrderDetailQuantityOrd), "ZZZZZ9")))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,87);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPurchaseOrderDetailQuantityOrd_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtPurchaseOrderDetailQuantityOrd_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)83,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_12_" + sGXsfl_83_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 88,'',false,'" + sGXsfl_83_idx + "',83)\"";
         ROClassString = "Attribute";
         Gridpurchaseorder_detailRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPurchaseOrderDetailQuantityRec_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A77PurchaseOrderDetailQuantityRec), 6, 0, ".", "")),StringUtil.LTrim( ((edtPurchaseOrderDetailQuantityRec_Enabled!=0) ? context.localUtil.Format( (decimal)(A77PurchaseOrderDetailQuantityRec), "ZZZZZ9") : context.localUtil.Format( (decimal)(A77PurchaseOrderDetailQuantityRec), "ZZZZZ9")))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,88);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPurchaseOrderDetailQuantityRec_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtPurchaseOrderDetailQuantityRec_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)83,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         ajax_sending_grid_row(Gridpurchaseorder_detailRow);
         send_integrity_lvl_hashes0712( ) ;
         GXCCtl = "Z61PurchaseOrderDetailId_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z61PurchaseOrderDetailId), 6, 0, ".", "")));
         GXCCtl = "Z76PurchaseOrderDetailQuantityOrd_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z76PurchaseOrderDetailQuantityOrd), 6, 0, ".", "")));
         GXCCtl = "Z77PurchaseOrderDetailQuantityRec_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z77PurchaseOrderDetailQuantityRec), 6, 0, ".", "")));
         GXCCtl = "Z134PurchaseOrderDetailSuggestedPr_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z134PurchaseOrderDetailSuggestedPr, 18, 2, ".", "")));
         GXCCtl = "Z15ProductId_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z15ProductId), 6, 0, ".", "")));
         GXCCtl = "nRcdDeleted_12_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_12), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_12_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_12), 4, 0, ".", "")));
         GXCCtl = "nIsMod_12_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_12), 4, 0, ".", "")));
         GXCCtl = "vMODE_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_83_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV9TrnContext);
         }
         GXCCtl = "vPURCHASEORDERID_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13PurchaseOrderId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PURCHASEORDERDETAILID_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPurchaseOrderDetailId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTID_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTNAME_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PURCHASEORDERDETAILQUANTITYORD_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPurchaseOrderDetailQuantityOrd_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PURCHASEORDERDETAILQUANTITYREC_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPurchaseOrderDetailQuantityRec_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_15_"+sGXsfl_83_idx+"Link", StringUtil.RTrim( imgprompt_15_Link));
         ajax_sending_grid_row(null);
         Gridpurchaseorder_detailContainer.AddRow(Gridpurchaseorder_detailRow);
      }

      protected void ReadRow0712( )
      {
         nGXsfl_83_idx = (int)(nGXsfl_83_idx+1);
         sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx), 4, 0), 4, "0");
         SubsflControlProps_8312( ) ;
         edtPurchaseOrderDetailId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PURCHASEORDERDETAILID_"+sGXsfl_83_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtProductId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTID_"+sGXsfl_83_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtProductName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTNAME_"+sGXsfl_83_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtPurchaseOrderDetailQuantityOrd_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PURCHASEORDERDETAILQUANTITYORD_"+sGXsfl_83_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtPurchaseOrderDetailQuantityRec_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PURCHASEORDERDETAILQUANTITYREC_"+sGXsfl_83_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         imgprompt_4_Link = cgiGet( "PROMPT_15_"+sGXsfl_83_idx+"Link");
         if ( ( ( context.localUtil.CToN( cgiGet( edtPurchaseOrderDetailId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPurchaseOrderDetailId_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
         {
            GXCCtl = "PURCHASEORDERDETAILID_" + sGXsfl_83_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtPurchaseOrderDetailId_Internalname;
            wbErr = true;
            A61PurchaseOrderDetailId = 0;
         }
         else
         {
            A61PurchaseOrderDetailId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPurchaseOrderDetailId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
         }
         if ( ( ( context.localUtil.CToN( cgiGet( edtProductId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProductId_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
         {
            GXCCtl = "PRODUCTID_" + sGXsfl_83_idx;
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
         if ( ( ( context.localUtil.CToN( cgiGet( edtPurchaseOrderDetailQuantityOrd_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPurchaseOrderDetailQuantityOrd_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
         {
            GXCCtl = "PURCHASEORDERDETAILQUANTITYORD_" + sGXsfl_83_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtPurchaseOrderDetailQuantityOrd_Internalname;
            wbErr = true;
            A76PurchaseOrderDetailQuantityOrd = 0;
         }
         else
         {
            A76PurchaseOrderDetailQuantityOrd = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPurchaseOrderDetailQuantityOrd_Internalname), ".", ","), 18, MidpointRounding.ToEven));
         }
         if ( ( ( context.localUtil.CToN( cgiGet( edtPurchaseOrderDetailQuantityRec_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPurchaseOrderDetailQuantityRec_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
         {
            GXCCtl = "PURCHASEORDERDETAILQUANTITYREC_" + sGXsfl_83_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtPurchaseOrderDetailQuantityRec_Internalname;
            wbErr = true;
            A77PurchaseOrderDetailQuantityRec = 0;
         }
         else
         {
            A77PurchaseOrderDetailQuantityRec = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPurchaseOrderDetailQuantityRec_Internalname), ".", ","), 18, MidpointRounding.ToEven));
         }
         GXCCtl = "Z61PurchaseOrderDetailId_" + sGXsfl_83_idx;
         Z61PurchaseOrderDetailId = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "Z76PurchaseOrderDetailQuantityOrd_" + sGXsfl_83_idx;
         Z76PurchaseOrderDetailQuantityOrd = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "Z77PurchaseOrderDetailQuantityRec_" + sGXsfl_83_idx;
         Z77PurchaseOrderDetailQuantityRec = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "Z134PurchaseOrderDetailSuggestedPr_" + sGXsfl_83_idx;
         Z134PurchaseOrderDetailSuggestedPr = context.localUtil.CToN( cgiGet( GXCCtl), ".", ",");
         n134PurchaseOrderDetailSuggestedPr = ((Convert.ToDecimal(0)==A134PurchaseOrderDetailSuggestedPr) ? true : false);
         GXCCtl = "Z15ProductId_" + sGXsfl_83_idx;
         Z15ProductId = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "Z134PurchaseOrderDetailSuggestedPr_" + sGXsfl_83_idx;
         A134PurchaseOrderDetailSuggestedPr = context.localUtil.CToN( cgiGet( GXCCtl), ".", ",");
         n134PurchaseOrderDetailSuggestedPr = false;
         n134PurchaseOrderDetailSuggestedPr = ((Convert.ToDecimal(0)==A134PurchaseOrderDetailSuggestedPr) ? true : false);
         GXCCtl = "nRcdDeleted_12_" + sGXsfl_83_idx;
         nRcdDeleted_12 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_12_" + sGXsfl_83_idx;
         nRcdExists_12 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_12_" + sGXsfl_83_idx;
         nIsMod_12 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtPurchaseOrderDetailId_Enabled = edtPurchaseOrderDetailId_Enabled;
      }

      protected void ConfirmValues070( )
      {
         nGXsfl_83_idx = 0;
         sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx), 4, 0), 4, "0");
         SubsflControlProps_8312( ) ;
         while ( nGXsfl_83_idx < nRC_GXsfl_83 )
         {
            nGXsfl_83_idx = (int)(nGXsfl_83_idx+1);
            sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx), 4, 0), 4, "0");
            SubsflControlProps_8312( ) ;
            ChangePostValue( "Z61PurchaseOrderDetailId_"+sGXsfl_83_idx, cgiGet( "ZT_"+"Z61PurchaseOrderDetailId_"+sGXsfl_83_idx)) ;
            DeletePostValue( "ZT_"+"Z61PurchaseOrderDetailId_"+sGXsfl_83_idx) ;
            ChangePostValue( "Z76PurchaseOrderDetailQuantityOrd_"+sGXsfl_83_idx, cgiGet( "ZT_"+"Z76PurchaseOrderDetailQuantityOrd_"+sGXsfl_83_idx)) ;
            DeletePostValue( "ZT_"+"Z76PurchaseOrderDetailQuantityOrd_"+sGXsfl_83_idx) ;
            ChangePostValue( "Z77PurchaseOrderDetailQuantityRec_"+sGXsfl_83_idx, cgiGet( "ZT_"+"Z77PurchaseOrderDetailQuantityRec_"+sGXsfl_83_idx)) ;
            DeletePostValue( "ZT_"+"Z77PurchaseOrderDetailQuantityRec_"+sGXsfl_83_idx) ;
            ChangePostValue( "Z134PurchaseOrderDetailSuggestedPr_"+sGXsfl_83_idx, cgiGet( "ZT_"+"Z134PurchaseOrderDetailSuggestedPr_"+sGXsfl_83_idx)) ;
            DeletePostValue( "ZT_"+"Z134PurchaseOrderDetailSuggestedPr_"+sGXsfl_83_idx) ;
            ChangePostValue( "Z15ProductId_"+sGXsfl_83_idx, cgiGet( "ZT_"+"Z15ProductId_"+sGXsfl_83_idx)) ;
            DeletePostValue( "ZT_"+"Z15ProductId_"+sGXsfl_83_idx) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("purchaseorder.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV13PurchaseOrderId,6,0))}, new string[] {"Gx_mode","PurchaseOrderId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"PurchaseOrder");
         forbiddenHiddens.Add("PurchaseOrderId", context.localUtil.Format( (decimal)(A50PurchaseOrderId), "ZZZZZ9"));
         forbiddenHiddens.Add("PurchaseOrderClosedDate", context.localUtil.Format(A66PurchaseOrderClosedDate, "99/99/99"));
         forbiddenHiddens.Add("PurchaseOrderModifiedDate", context.localUtil.Format(A53PurchaseOrderModifiedDate, "99/99/99"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("PurchaseOrderConfirmatedDate", context.localUtil.Format(A135PurchaseOrderConfirmatedDate, "99/99/99"));
         forbiddenHiddens.Add("PurchaseOrderCanceledDescripti", StringUtil.RTrim( context.localUtil.Format( A136PurchaseOrderCanceledDescripti, "")));
         forbiddenHiddens.Add("PurchaseOrderWasPaid", StringUtil.BoolToStr( A138PurchaseOrderWasPaid));
         forbiddenHiddens.Add("PurchaseOrderPaidDate", context.localUtil.Format(A139PurchaseOrderPaidDate, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("purchaseorder:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z50PurchaseOrderId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z50PurchaseOrderId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z52PurchaseOrderCreatedDate", context.localUtil.DToC( Z52PurchaseOrderCreatedDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z78PurchaseOrderTotalPaid", StringUtil.LTrim( StringUtil.NToC( Z78PurchaseOrderTotalPaid, 18, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z66PurchaseOrderClosedDate", context.localUtil.DToC( Z66PurchaseOrderClosedDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z53PurchaseOrderModifiedDate", context.localUtil.DToC( Z53PurchaseOrderModifiedDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z135PurchaseOrderConfirmatedDate", context.localUtil.DToC( Z135PurchaseOrderConfirmatedDate, 0, "/"));
         GxWebStd.gx_boolean_hidden_field( context, "Z79PurchaseOrderActive", Z79PurchaseOrderActive);
         GxWebStd.gx_hidden_field( context, "Z136PurchaseOrderCanceledDescripti", Z136PurchaseOrderCanceledDescripti);
         GxWebStd.gx_boolean_hidden_field( context, "Z138PurchaseOrderWasPaid", Z138PurchaseOrderWasPaid);
         GxWebStd.gx_hidden_field( context, "Z139PurchaseOrderPaidDate", context.localUtil.DToC( Z139PurchaseOrderPaidDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z4SupplierId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z4SupplierId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "O96PurchaseOrderLastDetailId", StringUtil.LTrim( StringUtil.NToC( (decimal)(O96PurchaseOrderLastDetailId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "O67PurchaseOrderDetailsQuantity", StringUtil.LTrim( StringUtil.NToC( (decimal)(O67PurchaseOrderDetailsQuantity), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_83", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_83_idx), 8, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "vPURCHASEORDERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13PurchaseOrderId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPURCHASEORDERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13PurchaseOrderId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_SUPPLIERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_SupplierId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "PURCHASEORDERCONFIRMATEDDATE", context.localUtil.DToC( A135PurchaseOrderConfirmatedDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "PURCHASEORDERCANCELEDDESCRIPTI", A136PurchaseOrderCanceledDescripti);
         GxWebStd.gx_boolean_hidden_field( context, "PURCHASEORDERWASPAID", A138PurchaseOrderWasPaid);
         GxWebStd.gx_hidden_field( context, "PURCHASEORDERPAIDDATE", context.localUtil.DToC( A139PurchaseOrderPaidDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "PURCHASEORDERLASTDETAILID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A96PurchaseOrderLastDetailId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV16Pgmname));
         GxWebStd.gx_hidden_field( context, "PURCHASEORDERDETAILSUGGESTEDPR", StringUtil.LTrim( StringUtil.NToC( A134PurchaseOrderDetailSuggestedPr, 18, 2, ".", "")));
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
         return formatLink("purchaseorder.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV13PurchaseOrderId,6,0))}, new string[] {"Gx_mode","PurchaseOrderId"})  ;
      }

      public override string GetPgmname( )
      {
         return "PurchaseOrder" ;
      }

      public override string GetPgmdesc( )
      {
         return "Purchase Order" ;
      }

      protected void InitializeNonKey0710( )
      {
         A4SupplierId = 0;
         AssignAttri("", false, "A4SupplierId", StringUtil.LTrimStr( (decimal)(A4SupplierId), 6, 0));
         A5SupplierName = "";
         AssignAttri("", false, "A5SupplierName", A5SupplierName);
         A52PurchaseOrderCreatedDate = DateTime.MinValue;
         AssignAttri("", false, "A52PurchaseOrderCreatedDate", context.localUtil.Format(A52PurchaseOrderCreatedDate, "99/99/99"));
         A78PurchaseOrderTotalPaid = 0;
         n78PurchaseOrderTotalPaid = false;
         AssignAttri("", false, "A78PurchaseOrderTotalPaid", StringUtil.LTrimStr( A78PurchaseOrderTotalPaid, 18, 2));
         n78PurchaseOrderTotalPaid = ((Convert.ToDecimal(0)==A78PurchaseOrderTotalPaid) ? true : false);
         A66PurchaseOrderClosedDate = DateTime.MinValue;
         n66PurchaseOrderClosedDate = false;
         AssignAttri("", false, "A66PurchaseOrderClosedDate", context.localUtil.Format(A66PurchaseOrderClosedDate, "99/99/99"));
         n66PurchaseOrderClosedDate = ((DateTime.MinValue==A66PurchaseOrderClosedDate) ? true : false);
         A53PurchaseOrderModifiedDate = DateTime.MinValue;
         n53PurchaseOrderModifiedDate = false;
         AssignAttri("", false, "A53PurchaseOrderModifiedDate", context.localUtil.Format(A53PurchaseOrderModifiedDate, "99/99/99"));
         n53PurchaseOrderModifiedDate = ((DateTime.MinValue==A53PurchaseOrderModifiedDate) ? true : false);
         A135PurchaseOrderConfirmatedDate = DateTime.MinValue;
         n135PurchaseOrderConfirmatedDate = false;
         AssignAttri("", false, "A135PurchaseOrderConfirmatedDate", context.localUtil.Format(A135PurchaseOrderConfirmatedDate, "99/99/99"));
         A136PurchaseOrderCanceledDescripti = "";
         n136PurchaseOrderCanceledDescripti = false;
         AssignAttri("", false, "A136PurchaseOrderCanceledDescripti", A136PurchaseOrderCanceledDescripti);
         A138PurchaseOrderWasPaid = false;
         n138PurchaseOrderWasPaid = false;
         AssignAttri("", false, "A138PurchaseOrderWasPaid", A138PurchaseOrderWasPaid);
         A139PurchaseOrderPaidDate = DateTime.MinValue;
         n139PurchaseOrderPaidDate = false;
         AssignAttri("", false, "A139PurchaseOrderPaidDate", context.localUtil.Format(A139PurchaseOrderPaidDate, "99/99/99"));
         A67PurchaseOrderDetailsQuantity = 0;
         AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
         A96PurchaseOrderLastDetailId = 0;
         AssignAttri("", false, "A96PurchaseOrderLastDetailId", StringUtil.LTrimStr( (decimal)(A96PurchaseOrderLastDetailId), 6, 0));
         A79PurchaseOrderActive = true;
         AssignAttri("", false, "A79PurchaseOrderActive", A79PurchaseOrderActive);
         O96PurchaseOrderLastDetailId = A96PurchaseOrderLastDetailId;
         AssignAttri("", false, "A96PurchaseOrderLastDetailId", StringUtil.LTrimStr( (decimal)(A96PurchaseOrderLastDetailId), 6, 0));
         O67PurchaseOrderDetailsQuantity = A67PurchaseOrderDetailsQuantity;
         AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
         Z52PurchaseOrderCreatedDate = DateTime.MinValue;
         Z78PurchaseOrderTotalPaid = 0;
         Z66PurchaseOrderClosedDate = DateTime.MinValue;
         Z53PurchaseOrderModifiedDate = DateTime.MinValue;
         Z135PurchaseOrderConfirmatedDate = DateTime.MinValue;
         Z79PurchaseOrderActive = false;
         Z136PurchaseOrderCanceledDescripti = "";
         Z138PurchaseOrderWasPaid = false;
         Z139PurchaseOrderPaidDate = DateTime.MinValue;
         Z4SupplierId = 0;
      }

      protected void InitAll0710( )
      {
         A50PurchaseOrderId = 0;
         AssignAttri("", false, "A50PurchaseOrderId", StringUtil.LTrimStr( (decimal)(A50PurchaseOrderId), 6, 0));
         InitializeNonKey0710( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A79PurchaseOrderActive = i79PurchaseOrderActive;
         AssignAttri("", false, "A79PurchaseOrderActive", A79PurchaseOrderActive);
      }

      protected void InitializeNonKey0712( )
      {
         A15ProductId = 0;
         A16ProductName = "";
         A76PurchaseOrderDetailQuantityOrd = 0;
         A77PurchaseOrderDetailQuantityRec = 0;
         A134PurchaseOrderDetailSuggestedPr = 0;
         n134PurchaseOrderDetailSuggestedPr = false;
         AssignAttri("", false, "A134PurchaseOrderDetailSuggestedPr", StringUtil.LTrimStr( A134PurchaseOrderDetailSuggestedPr, 18, 2));
         Z76PurchaseOrderDetailQuantityOrd = 0;
         Z77PurchaseOrderDetailQuantityRec = 0;
         Z134PurchaseOrderDetailSuggestedPr = 0;
         Z15ProductId = 0;
      }

      protected void InitAll0712( )
      {
         A61PurchaseOrderDetailId = 0;
         InitializeNonKey0712( ) ;
      }

      protected void StandaloneModalInsert0712( )
      {
         A96PurchaseOrderLastDetailId = i96PurchaseOrderLastDetailId;
         AssignAttri("", false, "A96PurchaseOrderLastDetailId", StringUtil.LTrimStr( (decimal)(A96PurchaseOrderLastDetailId), 6, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20241212032375", true, true);
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
         context.AddJavascriptSource("purchaseorder.js", "?20241212032375", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties12( )
      {
         edtPurchaseOrderDetailId_Enabled = defedtPurchaseOrderDetailId_Enabled;
         AssignProp("", false, edtPurchaseOrderDetailId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderDetailId_Enabled), 5, 0), !bGXsfl_83_Refreshing);
      }

      protected void StartGridControl83( )
      {
         Gridpurchaseorder_detailContainer.AddObjectProperty("GridName", "Gridpurchaseorder_detail");
         Gridpurchaseorder_detailContainer.AddObjectProperty("Header", subGridpurchaseorder_detail_Header);
         Gridpurchaseorder_detailContainer.AddObjectProperty("Class", "Grid");
         Gridpurchaseorder_detailContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridpurchaseorder_detailContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridpurchaseorder_detailContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpurchaseorder_detail_Backcolorstyle), 1, 0, ".", "")));
         Gridpurchaseorder_detailContainer.AddObjectProperty("CmpContext", "");
         Gridpurchaseorder_detailContainer.AddObjectProperty("InMasterPage", "false");
         Gridpurchaseorder_detailColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridpurchaseorder_detailColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A61PurchaseOrderDetailId), 6, 0, ".", ""))));
         Gridpurchaseorder_detailColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPurchaseOrderDetailId_Enabled), 5, 0, ".", "")));
         Gridpurchaseorder_detailContainer.AddColumnProperties(Gridpurchaseorder_detailColumn);
         Gridpurchaseorder_detailColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridpurchaseorder_detailColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", ""))));
         Gridpurchaseorder_detailColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductId_Enabled), 5, 0, ".", "")));
         Gridpurchaseorder_detailContainer.AddColumnProperties(Gridpurchaseorder_detailColumn);
         Gridpurchaseorder_detailColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridpurchaseorder_detailContainer.AddColumnProperties(Gridpurchaseorder_detailColumn);
         Gridpurchaseorder_detailColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridpurchaseorder_detailColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A16ProductName));
         Gridpurchaseorder_detailColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductName_Enabled), 5, 0, ".", "")));
         Gridpurchaseorder_detailContainer.AddColumnProperties(Gridpurchaseorder_detailColumn);
         Gridpurchaseorder_detailColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridpurchaseorder_detailColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A76PurchaseOrderDetailQuantityOrd), 6, 0, ".", ""))));
         Gridpurchaseorder_detailColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPurchaseOrderDetailQuantityOrd_Enabled), 5, 0, ".", "")));
         Gridpurchaseorder_detailContainer.AddColumnProperties(Gridpurchaseorder_detailColumn);
         Gridpurchaseorder_detailColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridpurchaseorder_detailColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A77PurchaseOrderDetailQuantityRec), 6, 0, ".", ""))));
         Gridpurchaseorder_detailColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPurchaseOrderDetailQuantityRec_Enabled), 5, 0, ".", "")));
         Gridpurchaseorder_detailContainer.AddColumnProperties(Gridpurchaseorder_detailColumn);
         Gridpurchaseorder_detailContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpurchaseorder_detail_Selectedindex), 4, 0, ".", "")));
         Gridpurchaseorder_detailContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpurchaseorder_detail_Allowselection), 1, 0, ".", "")));
         Gridpurchaseorder_detailContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpurchaseorder_detail_Selectioncolor), 9, 0, ".", "")));
         Gridpurchaseorder_detailContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpurchaseorder_detail_Allowhovering), 1, 0, ".", "")));
         Gridpurchaseorder_detailContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpurchaseorder_detail_Hoveringcolor), 9, 0, ".", "")));
         Gridpurchaseorder_detailContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpurchaseorder_detail_Allowcollapsing), 1, 0, ".", "")));
         Gridpurchaseorder_detailContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpurchaseorder_detail_Collapsed), 1, 0, ".", "")));
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
         edtPurchaseOrderId_Internalname = "PURCHASEORDERID";
         edtSupplierId_Internalname = "SUPPLIERID";
         edtSupplierName_Internalname = "SUPPLIERNAME";
         edtPurchaseOrderCreatedDate_Internalname = "PURCHASEORDERCREATEDDATE";
         edtPurchaseOrderTotalPaid_Internalname = "PURCHASEORDERTOTALPAID";
         edtPurchaseOrderClosedDate_Internalname = "PURCHASEORDERCLOSEDDATE";
         edtPurchaseOrderModifiedDate_Internalname = "PURCHASEORDERMODIFIEDDATE";
         chkPurchaseOrderActive_Internalname = "PURCHASEORDERACTIVE";
         edtPurchaseOrderDetailsQuantity_Internalname = "PURCHASEORDERDETAILSQUANTITY";
         lblTitledetail_Internalname = "TITLEDETAIL";
         edtPurchaseOrderDetailId_Internalname = "PURCHASEORDERDETAILID";
         edtProductId_Internalname = "PRODUCTID";
         edtProductName_Internalname = "PRODUCTNAME";
         edtPurchaseOrderDetailQuantityOrd_Internalname = "PURCHASEORDERDETAILQUANTITYORD";
         edtPurchaseOrderDetailQuantityRec_Internalname = "PURCHASEORDERDETAILQUANTITYREC";
         divDetailtable_Internalname = "DETAILTABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_4_Internalname = "PROMPT_4";
         imgprompt_15_Internalname = "PROMPT_15";
         subGridpurchaseorder_detail_Internalname = "GRIDPURCHASEORDER_DETAIL";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("mtaKB", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridpurchaseorder_detail_Allowcollapsing = 0;
         subGridpurchaseorder_detail_Allowselection = 0;
         subGridpurchaseorder_detail_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Purchase Order";
         edtPurchaseOrderDetailQuantityRec_Jsonclick = "";
         edtPurchaseOrderDetailQuantityOrd_Jsonclick = "";
         edtProductName_Jsonclick = "";
         imgprompt_15_Visible = 1;
         imgprompt_15_Link = "";
         imgprompt_4_Visible = 1;
         edtProductId_Jsonclick = "";
         edtPurchaseOrderDetailId_Jsonclick = "";
         subGridpurchaseorder_detail_Class = "Grid";
         subGridpurchaseorder_detail_Backcolorstyle = 0;
         edtPurchaseOrderDetailQuantityRec_Enabled = 1;
         edtPurchaseOrderDetailQuantityOrd_Enabled = 1;
         edtProductName_Enabled = 0;
         edtProductId_Enabled = 1;
         edtPurchaseOrderDetailId_Enabled = 1;
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtPurchaseOrderDetailsQuantity_Jsonclick = "";
         edtPurchaseOrderDetailsQuantity_Enabled = 0;
         chkPurchaseOrderActive.Enabled = 1;
         edtPurchaseOrderModifiedDate_Jsonclick = "";
         edtPurchaseOrderModifiedDate_Enabled = 0;
         edtPurchaseOrderClosedDate_Jsonclick = "";
         edtPurchaseOrderClosedDate_Enabled = 0;
         edtPurchaseOrderTotalPaid_Jsonclick = "";
         edtPurchaseOrderTotalPaid_Enabled = 1;
         edtPurchaseOrderCreatedDate_Jsonclick = "";
         edtPurchaseOrderCreatedDate_Enabled = 1;
         edtSupplierName_Jsonclick = "";
         edtSupplierName_Enabled = 0;
         imgprompt_4_Visible = 1;
         imgprompt_4_Link = "";
         edtSupplierId_Jsonclick = "";
         edtSupplierId_Enabled = 1;
         edtPurchaseOrderId_Jsonclick = "";
         edtPurchaseOrderId_Enabled = 0;
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

      protected void gxnrGridpurchaseorder_detail_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_8312( ) ;
         while ( nGXsfl_83_idx <= nRC_GXsfl_83 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0712( ) ;
            standaloneModal0712( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0712( ) ;
            nGXsfl_83_idx = (int)(nGXsfl_83_idx+1);
            sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx), 4, 0), 4, "0");
            SubsflControlProps_8312( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridpurchaseorder_detailContainer)) ;
         /* End function gxnrGridpurchaseorder_detail_newrow */
      }

      protected void init_web_controls( )
      {
         chkPurchaseOrderActive.Name = "PURCHASEORDERACTIVE";
         chkPurchaseOrderActive.WebTags = "";
         chkPurchaseOrderActive.Caption = "";
         AssignProp("", false, chkPurchaseOrderActive_Internalname, "TitleCaption", chkPurchaseOrderActive.Caption, true);
         chkPurchaseOrderActive.CheckedValue = "false";
         if ( IsIns( ) && (false==A79PurchaseOrderActive) )
         {
            A79PurchaseOrderActive = true;
            AssignAttri("", false, "A79PurchaseOrderActive", A79PurchaseOrderActive);
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

      public void Valid_Purchaseorderid( )
      {
         /* Using cursor T000722 */
         pr_default.execute(16, new Object[] {A50PurchaseOrderId});
         if ( (pr_default.getStatus(16) != 101) )
         {
            A67PurchaseOrderDetailsQuantity = T000722_A67PurchaseOrderDetailsQuantity[0];
            A96PurchaseOrderLastDetailId = T000722_A96PurchaseOrderLastDetailId[0];
         }
         else
         {
            A67PurchaseOrderDetailsQuantity = 0;
            A96PurchaseOrderLastDetailId = 0;
         }
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrim( StringUtil.NToC( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0, ".", "")));
         AssignAttri("", false, "A96PurchaseOrderLastDetailId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A96PurchaseOrderLastDetailId), 6, 0, ".", "")));
      }

      public void Valid_Supplierid( )
      {
         /* Using cursor T000723 */
         pr_default.execute(17, new Object[] {A4SupplierId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No matching 'Supplier'.", "ForeignKeyNotFound", 1, "SUPPLIERID");
            AnyError = 1;
            GX_FocusControl = edtSupplierId_Internalname;
         }
         A5SupplierName = T000723_A5SupplierName[0];
         pr_default.close(17);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A5SupplierName", A5SupplierName);
      }

      public void Valid_Productid( )
      {
         /* Using cursor T000731 */
         pr_default.execute(25, new Object[] {A15ProductId});
         if ( (pr_default.getStatus(25) == 101) )
         {
            GX_msglist.addItem("No matching 'Product'.", "ForeignKeyNotFound", 1, "PRODUCTID");
            AnyError = 1;
            GX_FocusControl = edtProductId_Internalname;
         }
         A16ProductName = T000731_A16ProductName[0];
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV13PurchaseOrderId',fld:'vPURCHASEORDERID',pic:'ZZZZZ9',hsh:true},{av:'A79PurchaseOrderActive',fld:'PURCHASEORDERACTIVE',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'A79PurchaseOrderActive',fld:'PURCHASEORDERACTIVE',pic:''}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV13PurchaseOrderId',fld:'vPURCHASEORDERID',pic:'ZZZZZ9',hsh:true},{av:'A50PurchaseOrderId',fld:'PURCHASEORDERID',pic:'ZZZZZ9'},{av:'A66PurchaseOrderClosedDate',fld:'PURCHASEORDERCLOSEDDATE',pic:''},{av:'A53PurchaseOrderModifiedDate',fld:'PURCHASEORDERMODIFIEDDATE',pic:''},{av:'A135PurchaseOrderConfirmatedDate',fld:'PURCHASEORDERCONFIRMATEDDATE',pic:''},{av:'A136PurchaseOrderCanceledDescripti',fld:'PURCHASEORDERCANCELEDDESCRIPTI',pic:''},{av:'A138PurchaseOrderWasPaid',fld:'PURCHASEORDERWASPAID',pic:''},{av:'A139PurchaseOrderPaidDate',fld:'PURCHASEORDERPAIDDATE',pic:''},{av:'A79PurchaseOrderActive',fld:'PURCHASEORDERACTIVE',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A79PurchaseOrderActive',fld:'PURCHASEORDERACTIVE',pic:''}]}");
         setEventMetadata("AFTER TRN","{handler:'E12072',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A79PurchaseOrderActive',fld:'PURCHASEORDERACTIVE',pic:''}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'A79PurchaseOrderActive',fld:'PURCHASEORDERACTIVE',pic:''}]}");
         setEventMetadata("VALID_PURCHASEORDERID","{handler:'Valid_Purchaseorderid',iparms:[{av:'A50PurchaseOrderId',fld:'PURCHASEORDERID',pic:'ZZZZZ9'},{av:'A67PurchaseOrderDetailsQuantity',fld:'PURCHASEORDERDETAILSQUANTITY',pic:'ZZZ9'},{av:'A96PurchaseOrderLastDetailId',fld:'PURCHASEORDERLASTDETAILID',pic:'ZZZZZ9'},{av:'A79PurchaseOrderActive',fld:'PURCHASEORDERACTIVE',pic:''}]");
         setEventMetadata("VALID_PURCHASEORDERID",",oparms:[{av:'A67PurchaseOrderDetailsQuantity',fld:'PURCHASEORDERDETAILSQUANTITY',pic:'ZZZ9'},{av:'A96PurchaseOrderLastDetailId',fld:'PURCHASEORDERLASTDETAILID',pic:'ZZZZZ9'},{av:'A79PurchaseOrderActive',fld:'PURCHASEORDERACTIVE',pic:''}]}");
         setEventMetadata("VALID_SUPPLIERID","{handler:'Valid_Supplierid',iparms:[{av:'A4SupplierId',fld:'SUPPLIERID',pic:'ZZZZZ9'},{av:'A5SupplierName',fld:'SUPPLIERNAME',pic:''},{av:'A79PurchaseOrderActive',fld:'PURCHASEORDERACTIVE',pic:''}]");
         setEventMetadata("VALID_SUPPLIERID",",oparms:[{av:'A5SupplierName',fld:'SUPPLIERNAME',pic:''},{av:'A79PurchaseOrderActive',fld:'PURCHASEORDERACTIVE',pic:''}]}");
         setEventMetadata("VALID_PURCHASEORDERCREATEDDATE","{handler:'Valid_Purchaseordercreateddate',iparms:[{av:'A79PurchaseOrderActive',fld:'PURCHASEORDERACTIVE',pic:''}]");
         setEventMetadata("VALID_PURCHASEORDERCREATEDDATE",",oparms:[{av:'A79PurchaseOrderActive',fld:'PURCHASEORDERACTIVE',pic:''}]}");
         setEventMetadata("VALID_PURCHASEORDERTOTALPAID","{handler:'Valid_Purchaseordertotalpaid',iparms:[{av:'A79PurchaseOrderActive',fld:'PURCHASEORDERACTIVE',pic:''}]");
         setEventMetadata("VALID_PURCHASEORDERTOTALPAID",",oparms:[{av:'A79PurchaseOrderActive',fld:'PURCHASEORDERACTIVE',pic:''}]}");
         setEventMetadata("VALID_PURCHASEORDERDETAILID","{handler:'Valid_Purchaseorderdetailid',iparms:[{av:'A79PurchaseOrderActive',fld:'PURCHASEORDERACTIVE',pic:''}]");
         setEventMetadata("VALID_PURCHASEORDERDETAILID",",oparms:[{av:'A79PurchaseOrderActive',fld:'PURCHASEORDERACTIVE',pic:''}]}");
         setEventMetadata("VALID_PRODUCTID","{handler:'Valid_Productid',iparms:[{av:'A15ProductId',fld:'PRODUCTID',pic:'ZZZZZ9'},{av:'A16ProductName',fld:'PRODUCTNAME',pic:''},{av:'A79PurchaseOrderActive',fld:'PURCHASEORDERACTIVE',pic:''}]");
         setEventMetadata("VALID_PRODUCTID",",oparms:[{av:'A16ProductName',fld:'PRODUCTNAME',pic:''},{av:'A79PurchaseOrderActive',fld:'PURCHASEORDERACTIVE',pic:''}]}");
         setEventMetadata("VALID_PURCHASEORDERDETAILQUANTITYORD","{handler:'Valid_Purchaseorderdetailquantityord',iparms:[{av:'A79PurchaseOrderActive',fld:'PURCHASEORDERACTIVE',pic:''}]");
         setEventMetadata("VALID_PURCHASEORDERDETAILQUANTITYORD",",oparms:[{av:'A79PurchaseOrderActive',fld:'PURCHASEORDERACTIVE',pic:''}]}");
         setEventMetadata("VALID_PURCHASEORDERDETAILQUANTITYREC","{handler:'Valid_Purchaseorderdetailquantityrec',iparms:[{av:'A79PurchaseOrderActive',fld:'PURCHASEORDERACTIVE',pic:''}]");
         setEventMetadata("VALID_PURCHASEORDERDETAILQUANTITYREC",",oparms:[{av:'A79PurchaseOrderActive',fld:'PURCHASEORDERACTIVE',pic:''}]}");
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
         pr_default.close(5);
         pr_default.close(17);
         pr_default.close(16);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z52PurchaseOrderCreatedDate = DateTime.MinValue;
         Z66PurchaseOrderClosedDate = DateTime.MinValue;
         Z53PurchaseOrderModifiedDate = DateTime.MinValue;
         Z135PurchaseOrderConfirmatedDate = DateTime.MinValue;
         Z136PurchaseOrderCanceledDescripti = "";
         Z139PurchaseOrderPaidDate = DateTime.MinValue;
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
         imgprompt_4_gximage = "";
         sImgUrl = "";
         A5SupplierName = "";
         A52PurchaseOrderCreatedDate = DateTime.MinValue;
         A66PurchaseOrderClosedDate = DateTime.MinValue;
         A53PurchaseOrderModifiedDate = DateTime.MinValue;
         lblTitledetail_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridpurchaseorder_detailContainer = new GXWebGrid( context);
         sMode12 = "";
         sStyleString = "";
         A135PurchaseOrderConfirmatedDate = DateTime.MinValue;
         A136PurchaseOrderCanceledDescripti = "";
         A139PurchaseOrderPaidDate = DateTime.MinValue;
         Gx_date = DateTime.MinValue;
         AV16Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode10 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A16ProductName = "";
         T00076_A67PurchaseOrderDetailsQuantity = new short[1] ;
         T00076_A96PurchaseOrderLastDetailId = new int[1] ;
         GXt_SdtSDTContextSession1 = new GeneXus.Programs.general.ui.SdtSDTContextSession(context);
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV12TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         Z5SupplierName = "";
         T00079_A5SupplierName = new string[] {""} ;
         T000711_A50PurchaseOrderId = new int[1] ;
         T000711_A5SupplierName = new string[] {""} ;
         T000711_A52PurchaseOrderCreatedDate = new DateTime[] {DateTime.MinValue} ;
         T000711_A78PurchaseOrderTotalPaid = new decimal[1] ;
         T000711_n78PurchaseOrderTotalPaid = new bool[] {false} ;
         T000711_A66PurchaseOrderClosedDate = new DateTime[] {DateTime.MinValue} ;
         T000711_n66PurchaseOrderClosedDate = new bool[] {false} ;
         T000711_A53PurchaseOrderModifiedDate = new DateTime[] {DateTime.MinValue} ;
         T000711_n53PurchaseOrderModifiedDate = new bool[] {false} ;
         T000711_A135PurchaseOrderConfirmatedDate = new DateTime[] {DateTime.MinValue} ;
         T000711_n135PurchaseOrderConfirmatedDate = new bool[] {false} ;
         T000711_A79PurchaseOrderActive = new bool[] {false} ;
         T000711_A136PurchaseOrderCanceledDescripti = new string[] {""} ;
         T000711_n136PurchaseOrderCanceledDescripti = new bool[] {false} ;
         T000711_A138PurchaseOrderWasPaid = new bool[] {false} ;
         T000711_n138PurchaseOrderWasPaid = new bool[] {false} ;
         T000711_A139PurchaseOrderPaidDate = new DateTime[] {DateTime.MinValue} ;
         T000711_n139PurchaseOrderPaidDate = new bool[] {false} ;
         T000711_A4SupplierId = new int[1] ;
         T000711_A67PurchaseOrderDetailsQuantity = new short[1] ;
         T000711_A96PurchaseOrderLastDetailId = new int[1] ;
         T000713_A67PurchaseOrderDetailsQuantity = new short[1] ;
         T000713_A96PurchaseOrderLastDetailId = new int[1] ;
         T000714_A5SupplierName = new string[] {""} ;
         T000715_A50PurchaseOrderId = new int[1] ;
         T00078_A50PurchaseOrderId = new int[1] ;
         T00078_A52PurchaseOrderCreatedDate = new DateTime[] {DateTime.MinValue} ;
         T00078_A78PurchaseOrderTotalPaid = new decimal[1] ;
         T00078_n78PurchaseOrderTotalPaid = new bool[] {false} ;
         T00078_A66PurchaseOrderClosedDate = new DateTime[] {DateTime.MinValue} ;
         T00078_n66PurchaseOrderClosedDate = new bool[] {false} ;
         T00078_A53PurchaseOrderModifiedDate = new DateTime[] {DateTime.MinValue} ;
         T00078_n53PurchaseOrderModifiedDate = new bool[] {false} ;
         T00078_A135PurchaseOrderConfirmatedDate = new DateTime[] {DateTime.MinValue} ;
         T00078_n135PurchaseOrderConfirmatedDate = new bool[] {false} ;
         T00078_A79PurchaseOrderActive = new bool[] {false} ;
         T00078_A136PurchaseOrderCanceledDescripti = new string[] {""} ;
         T00078_n136PurchaseOrderCanceledDescripti = new bool[] {false} ;
         T00078_A138PurchaseOrderWasPaid = new bool[] {false} ;
         T00078_n138PurchaseOrderWasPaid = new bool[] {false} ;
         T00078_A139PurchaseOrderPaidDate = new DateTime[] {DateTime.MinValue} ;
         T00078_n139PurchaseOrderPaidDate = new bool[] {false} ;
         T00078_A4SupplierId = new int[1] ;
         T000716_A50PurchaseOrderId = new int[1] ;
         T000717_A50PurchaseOrderId = new int[1] ;
         T00077_A50PurchaseOrderId = new int[1] ;
         T00077_A52PurchaseOrderCreatedDate = new DateTime[] {DateTime.MinValue} ;
         T00077_A78PurchaseOrderTotalPaid = new decimal[1] ;
         T00077_n78PurchaseOrderTotalPaid = new bool[] {false} ;
         T00077_A66PurchaseOrderClosedDate = new DateTime[] {DateTime.MinValue} ;
         T00077_n66PurchaseOrderClosedDate = new bool[] {false} ;
         T00077_A53PurchaseOrderModifiedDate = new DateTime[] {DateTime.MinValue} ;
         T00077_n53PurchaseOrderModifiedDate = new bool[] {false} ;
         T00077_A135PurchaseOrderConfirmatedDate = new DateTime[] {DateTime.MinValue} ;
         T00077_n135PurchaseOrderConfirmatedDate = new bool[] {false} ;
         T00077_A79PurchaseOrderActive = new bool[] {false} ;
         T00077_A136PurchaseOrderCanceledDescripti = new string[] {""} ;
         T00077_n136PurchaseOrderCanceledDescripti = new bool[] {false} ;
         T00077_A138PurchaseOrderWasPaid = new bool[] {false} ;
         T00077_n138PurchaseOrderWasPaid = new bool[] {false} ;
         T00077_A139PurchaseOrderPaidDate = new DateTime[] {DateTime.MinValue} ;
         T00077_n139PurchaseOrderPaidDate = new bool[] {false} ;
         T00077_A4SupplierId = new int[1] ;
         T000718_A50PurchaseOrderId = new int[1] ;
         T000722_A67PurchaseOrderDetailsQuantity = new short[1] ;
         T000722_A96PurchaseOrderLastDetailId = new int[1] ;
         T000723_A5SupplierName = new string[] {""} ;
         T000724_A50PurchaseOrderId = new int[1] ;
         Z16ProductName = "";
         T000725_A50PurchaseOrderId = new int[1] ;
         T000725_A61PurchaseOrderDetailId = new int[1] ;
         T000725_A16ProductName = new string[] {""} ;
         T000725_A76PurchaseOrderDetailQuantityOrd = new int[1] ;
         T000725_A77PurchaseOrderDetailQuantityRec = new int[1] ;
         T000725_A134PurchaseOrderDetailSuggestedPr = new decimal[1] ;
         T000725_n134PurchaseOrderDetailSuggestedPr = new bool[] {false} ;
         T000725_A15ProductId = new int[1] ;
         T00074_A16ProductName = new string[] {""} ;
         T000726_A16ProductName = new string[] {""} ;
         T000727_A50PurchaseOrderId = new int[1] ;
         T000727_A61PurchaseOrderDetailId = new int[1] ;
         T00073_A50PurchaseOrderId = new int[1] ;
         T00073_A61PurchaseOrderDetailId = new int[1] ;
         T00073_A76PurchaseOrderDetailQuantityOrd = new int[1] ;
         T00073_A77PurchaseOrderDetailQuantityRec = new int[1] ;
         T00073_A134PurchaseOrderDetailSuggestedPr = new decimal[1] ;
         T00073_n134PurchaseOrderDetailSuggestedPr = new bool[] {false} ;
         T00073_A15ProductId = new int[1] ;
         T00072_A50PurchaseOrderId = new int[1] ;
         T00072_A61PurchaseOrderDetailId = new int[1] ;
         T00072_A76PurchaseOrderDetailQuantityOrd = new int[1] ;
         T00072_A77PurchaseOrderDetailQuantityRec = new int[1] ;
         T00072_A134PurchaseOrderDetailSuggestedPr = new decimal[1] ;
         T00072_n134PurchaseOrderDetailSuggestedPr = new bool[] {false} ;
         T00072_A15ProductId = new int[1] ;
         T000731_A16ProductName = new string[] {""} ;
         T000732_A50PurchaseOrderId = new int[1] ;
         T000732_A61PurchaseOrderDetailId = new int[1] ;
         Gridpurchaseorder_detailRow = new GXWebRow();
         subGridpurchaseorder_detail_Linesclass = "";
         ROClassString = "";
         imgprompt_15_gximage = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Gridpurchaseorder_detailColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.purchaseorder__default(),
            new Object[][] {
                new Object[] {
               T00072_A50PurchaseOrderId, T00072_A61PurchaseOrderDetailId, T00072_A76PurchaseOrderDetailQuantityOrd, T00072_A77PurchaseOrderDetailQuantityRec, T00072_A134PurchaseOrderDetailSuggestedPr, T00072_n134PurchaseOrderDetailSuggestedPr, T00072_A15ProductId
               }
               , new Object[] {
               T00073_A50PurchaseOrderId, T00073_A61PurchaseOrderDetailId, T00073_A76PurchaseOrderDetailQuantityOrd, T00073_A77PurchaseOrderDetailQuantityRec, T00073_A134PurchaseOrderDetailSuggestedPr, T00073_n134PurchaseOrderDetailSuggestedPr, T00073_A15ProductId
               }
               , new Object[] {
               T00074_A16ProductName
               }
               , new Object[] {
               T00076_A67PurchaseOrderDetailsQuantity, T00076_A96PurchaseOrderLastDetailId
               }
               , new Object[] {
               T00077_A50PurchaseOrderId, T00077_A52PurchaseOrderCreatedDate, T00077_A78PurchaseOrderTotalPaid, T00077_n78PurchaseOrderTotalPaid, T00077_A66PurchaseOrderClosedDate, T00077_n66PurchaseOrderClosedDate, T00077_A53PurchaseOrderModifiedDate, T00077_n53PurchaseOrderModifiedDate, T00077_A135PurchaseOrderConfirmatedDate, T00077_n135PurchaseOrderConfirmatedDate,
               T00077_A79PurchaseOrderActive, T00077_A136PurchaseOrderCanceledDescripti, T00077_n136PurchaseOrderCanceledDescripti, T00077_A138PurchaseOrderWasPaid, T00077_n138PurchaseOrderWasPaid, T00077_A139PurchaseOrderPaidDate, T00077_n139PurchaseOrderPaidDate, T00077_A4SupplierId
               }
               , new Object[] {
               T00078_A50PurchaseOrderId, T00078_A52PurchaseOrderCreatedDate, T00078_A78PurchaseOrderTotalPaid, T00078_n78PurchaseOrderTotalPaid, T00078_A66PurchaseOrderClosedDate, T00078_n66PurchaseOrderClosedDate, T00078_A53PurchaseOrderModifiedDate, T00078_n53PurchaseOrderModifiedDate, T00078_A135PurchaseOrderConfirmatedDate, T00078_n135PurchaseOrderConfirmatedDate,
               T00078_A79PurchaseOrderActive, T00078_A136PurchaseOrderCanceledDescripti, T00078_n136PurchaseOrderCanceledDescripti, T00078_A138PurchaseOrderWasPaid, T00078_n138PurchaseOrderWasPaid, T00078_A139PurchaseOrderPaidDate, T00078_n139PurchaseOrderPaidDate, T00078_A4SupplierId
               }
               , new Object[] {
               T00079_A5SupplierName
               }
               , new Object[] {
               T000711_A50PurchaseOrderId, T000711_A5SupplierName, T000711_A52PurchaseOrderCreatedDate, T000711_A78PurchaseOrderTotalPaid, T000711_n78PurchaseOrderTotalPaid, T000711_A66PurchaseOrderClosedDate, T000711_n66PurchaseOrderClosedDate, T000711_A53PurchaseOrderModifiedDate, T000711_n53PurchaseOrderModifiedDate, T000711_A135PurchaseOrderConfirmatedDate,
               T000711_n135PurchaseOrderConfirmatedDate, T000711_A79PurchaseOrderActive, T000711_A136PurchaseOrderCanceledDescripti, T000711_n136PurchaseOrderCanceledDescripti, T000711_A138PurchaseOrderWasPaid, T000711_n138PurchaseOrderWasPaid, T000711_A139PurchaseOrderPaidDate, T000711_n139PurchaseOrderPaidDate, T000711_A4SupplierId, T000711_A67PurchaseOrderDetailsQuantity,
               T000711_A96PurchaseOrderLastDetailId
               }
               , new Object[] {
               T000713_A67PurchaseOrderDetailsQuantity, T000713_A96PurchaseOrderLastDetailId
               }
               , new Object[] {
               T000714_A5SupplierName
               }
               , new Object[] {
               T000715_A50PurchaseOrderId
               }
               , new Object[] {
               T000716_A50PurchaseOrderId
               }
               , new Object[] {
               T000717_A50PurchaseOrderId
               }
               , new Object[] {
               T000718_A50PurchaseOrderId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000722_A67PurchaseOrderDetailsQuantity, T000722_A96PurchaseOrderLastDetailId
               }
               , new Object[] {
               T000723_A5SupplierName
               }
               , new Object[] {
               T000724_A50PurchaseOrderId
               }
               , new Object[] {
               T000725_A50PurchaseOrderId, T000725_A61PurchaseOrderDetailId, T000725_A16ProductName, T000725_A76PurchaseOrderDetailQuantityOrd, T000725_A77PurchaseOrderDetailQuantityRec, T000725_A134PurchaseOrderDetailSuggestedPr, T000725_n134PurchaseOrderDetailSuggestedPr, T000725_A15ProductId
               }
               , new Object[] {
               T000726_A16ProductName
               }
               , new Object[] {
               T000727_A50PurchaseOrderId, T000727_A61PurchaseOrderDetailId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000731_A16ProductName
               }
               , new Object[] {
               T000732_A50PurchaseOrderId, T000732_A61PurchaseOrderDetailId
               }
            }
         );
         Z79PurchaseOrderActive = true;
         A79PurchaseOrderActive = true;
         i79PurchaseOrderActive = true;
         AV16Pgmname = "PurchaseOrder";
         Gx_date = DateTimeUtil.Today( context);
      }

      private short nIsMod_12 ;
      private short O67PurchaseOrderDetailsQuantity ;
      private short nRcdDeleted_12 ;
      private short nRcdExists_12 ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short initialized ;
      private short A67PurchaseOrderDetailsQuantity ;
      private short nBlankRcdCount12 ;
      private short RcdFound12 ;
      private short B67PurchaseOrderDetailsQuantity ;
      private short nBlankRcdUsr12 ;
      private short RcdFound10 ;
      private short s67PurchaseOrderDetailsQuantity ;
      private short GX_JID ;
      private short Z67PurchaseOrderDetailsQuantity ;
      private short nIsDirty_10 ;
      private short nIsDirty_12 ;
      private short subGridpurchaseorder_detail_Backcolorstyle ;
      private short subGridpurchaseorder_detail_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridpurchaseorder_detail_Allowselection ;
      private short subGridpurchaseorder_detail_Allowhovering ;
      private short subGridpurchaseorder_detail_Allowcollapsing ;
      private short subGridpurchaseorder_detail_Collapsed ;
      private int wcpOAV13PurchaseOrderId ;
      private int Z50PurchaseOrderId ;
      private int Z4SupplierId ;
      private int O96PurchaseOrderLastDetailId ;
      private int nRC_GXsfl_83 ;
      private int nGXsfl_83_idx=1 ;
      private int N4SupplierId ;
      private int Z61PurchaseOrderDetailId ;
      private int Z76PurchaseOrderDetailQuantityOrd ;
      private int Z77PurchaseOrderDetailQuantityRec ;
      private int Z15ProductId ;
      private int A50PurchaseOrderId ;
      private int A4SupplierId ;
      private int A15ProductId ;
      private int AV13PurchaseOrderId ;
      private int trnEnded ;
      private int A96PurchaseOrderLastDetailId ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtPurchaseOrderId_Enabled ;
      private int edtSupplierId_Enabled ;
      private int imgprompt_4_Visible ;
      private int edtSupplierName_Enabled ;
      private int edtPurchaseOrderCreatedDate_Enabled ;
      private int edtPurchaseOrderTotalPaid_Enabled ;
      private int edtPurchaseOrderClosedDate_Enabled ;
      private int edtPurchaseOrderModifiedDate_Enabled ;
      private int edtPurchaseOrderDetailsQuantity_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int B96PurchaseOrderLastDetailId ;
      private int edtPurchaseOrderDetailId_Enabled ;
      private int edtProductId_Enabled ;
      private int edtProductName_Enabled ;
      private int edtPurchaseOrderDetailQuantityOrd_Enabled ;
      private int edtPurchaseOrderDetailQuantityRec_Enabled ;
      private int fRowAdded ;
      private int AV11Insert_SupplierId ;
      private int s96PurchaseOrderLastDetailId ;
      private int A61PurchaseOrderDetailId ;
      private int A76PurchaseOrderDetailQuantityOrd ;
      private int A77PurchaseOrderDetailQuantityRec ;
      private int AV17GXV1 ;
      private int Z96PurchaseOrderLastDetailId ;
      private int subGridpurchaseorder_detail_Backcolor ;
      private int subGridpurchaseorder_detail_Allbackcolor ;
      private int imgprompt_15_Visible ;
      private int defedtPurchaseOrderDetailId_Enabled ;
      private int i96PurchaseOrderLastDetailId ;
      private int idxLst ;
      private int subGridpurchaseorder_detail_Selectedindex ;
      private int subGridpurchaseorder_detail_Selectioncolor ;
      private int subGridpurchaseorder_detail_Hoveringcolor ;
      private long GRIDPURCHASEORDER_DETAIL_nFirstRecordOnPage ;
      private decimal Z78PurchaseOrderTotalPaid ;
      private decimal Z134PurchaseOrderDetailSuggestedPr ;
      private decimal A78PurchaseOrderTotalPaid ;
      private decimal A134PurchaseOrderDetailSuggestedPr ;
      private string sPrefix ;
      private string sGXsfl_83_idx="0001" ;
      private string wcpOGx_mode ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtSupplierId_Internalname ;
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
      private string edtPurchaseOrderId_Internalname ;
      private string edtPurchaseOrderId_Jsonclick ;
      private string edtSupplierId_Jsonclick ;
      private string imgprompt_4_gximage ;
      private string sImgUrl ;
      private string imgprompt_4_Internalname ;
      private string imgprompt_4_Link ;
      private string edtSupplierName_Internalname ;
      private string edtSupplierName_Jsonclick ;
      private string edtPurchaseOrderCreatedDate_Internalname ;
      private string edtPurchaseOrderCreatedDate_Jsonclick ;
      private string edtPurchaseOrderTotalPaid_Internalname ;
      private string edtPurchaseOrderTotalPaid_Jsonclick ;
      private string edtPurchaseOrderClosedDate_Internalname ;
      private string edtPurchaseOrderClosedDate_Jsonclick ;
      private string edtPurchaseOrderModifiedDate_Internalname ;
      private string edtPurchaseOrderModifiedDate_Jsonclick ;
      private string chkPurchaseOrderActive_Internalname ;
      private string edtPurchaseOrderDetailsQuantity_Internalname ;
      private string edtPurchaseOrderDetailsQuantity_Jsonclick ;
      private string divDetailtable_Internalname ;
      private string lblTitledetail_Internalname ;
      private string lblTitledetail_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string sMode12 ;
      private string edtPurchaseOrderDetailId_Internalname ;
      private string edtProductId_Internalname ;
      private string edtProductName_Internalname ;
      private string edtPurchaseOrderDetailQuantityOrd_Internalname ;
      private string edtPurchaseOrderDetailQuantityRec_Internalname ;
      private string sStyleString ;
      private string subGridpurchaseorder_detail_Internalname ;
      private string AV16Pgmname ;
      private string hsh ;
      private string sMode10 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string imgprompt_15_Internalname ;
      private string sGXsfl_83_fel_idx="0001" ;
      private string subGridpurchaseorder_detail_Class ;
      private string subGridpurchaseorder_detail_Linesclass ;
      private string imgprompt_15_Link ;
      private string ROClassString ;
      private string edtPurchaseOrderDetailId_Jsonclick ;
      private string edtProductId_Jsonclick ;
      private string imgprompt_15_gximage ;
      private string edtProductName_Jsonclick ;
      private string edtPurchaseOrderDetailQuantityOrd_Jsonclick ;
      private string edtPurchaseOrderDetailQuantityRec_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridpurchaseorder_detail_Header ;
      private DateTime Z52PurchaseOrderCreatedDate ;
      private DateTime Z66PurchaseOrderClosedDate ;
      private DateTime Z53PurchaseOrderModifiedDate ;
      private DateTime Z135PurchaseOrderConfirmatedDate ;
      private DateTime Z139PurchaseOrderPaidDate ;
      private DateTime A52PurchaseOrderCreatedDate ;
      private DateTime A66PurchaseOrderClosedDate ;
      private DateTime A53PurchaseOrderModifiedDate ;
      private DateTime A135PurchaseOrderConfirmatedDate ;
      private DateTime A139PurchaseOrderPaidDate ;
      private DateTime Gx_date ;
      private bool Z79PurchaseOrderActive ;
      private bool Z138PurchaseOrderWasPaid ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A79PurchaseOrderActive ;
      private bool bGXsfl_83_Refreshing=false ;
      private bool n78PurchaseOrderTotalPaid ;
      private bool n66PurchaseOrderClosedDate ;
      private bool n53PurchaseOrderModifiedDate ;
      private bool n135PurchaseOrderConfirmatedDate ;
      private bool n136PurchaseOrderCanceledDescripti ;
      private bool n138PurchaseOrderWasPaid ;
      private bool A138PurchaseOrderWasPaid ;
      private bool n139PurchaseOrderPaidDate ;
      private bool n134PurchaseOrderDetailSuggestedPr ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private bool i79PurchaseOrderActive ;
      private string Z136PurchaseOrderCanceledDescripti ;
      private string A5SupplierName ;
      private string A136PurchaseOrderCanceledDescripti ;
      private string A16ProductName ;
      private string Z5SupplierName ;
      private string Z16ProductName ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridpurchaseorder_detailContainer ;
      private GXWebRow Gridpurchaseorder_detailRow ;
      private GXWebColumn Gridpurchaseorder_detailColumn ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkPurchaseOrderActive ;
      private IDataStoreProvider pr_default ;
      private short[] T00076_A67PurchaseOrderDetailsQuantity ;
      private int[] T00076_A96PurchaseOrderLastDetailId ;
      private string[] T00079_A5SupplierName ;
      private int[] T000711_A50PurchaseOrderId ;
      private string[] T000711_A5SupplierName ;
      private DateTime[] T000711_A52PurchaseOrderCreatedDate ;
      private decimal[] T000711_A78PurchaseOrderTotalPaid ;
      private bool[] T000711_n78PurchaseOrderTotalPaid ;
      private DateTime[] T000711_A66PurchaseOrderClosedDate ;
      private bool[] T000711_n66PurchaseOrderClosedDate ;
      private DateTime[] T000711_A53PurchaseOrderModifiedDate ;
      private bool[] T000711_n53PurchaseOrderModifiedDate ;
      private DateTime[] T000711_A135PurchaseOrderConfirmatedDate ;
      private bool[] T000711_n135PurchaseOrderConfirmatedDate ;
      private bool[] T000711_A79PurchaseOrderActive ;
      private string[] T000711_A136PurchaseOrderCanceledDescripti ;
      private bool[] T000711_n136PurchaseOrderCanceledDescripti ;
      private bool[] T000711_A138PurchaseOrderWasPaid ;
      private bool[] T000711_n138PurchaseOrderWasPaid ;
      private DateTime[] T000711_A139PurchaseOrderPaidDate ;
      private bool[] T000711_n139PurchaseOrderPaidDate ;
      private int[] T000711_A4SupplierId ;
      private short[] T000711_A67PurchaseOrderDetailsQuantity ;
      private int[] T000711_A96PurchaseOrderLastDetailId ;
      private short[] T000713_A67PurchaseOrderDetailsQuantity ;
      private int[] T000713_A96PurchaseOrderLastDetailId ;
      private string[] T000714_A5SupplierName ;
      private int[] T000715_A50PurchaseOrderId ;
      private int[] T00078_A50PurchaseOrderId ;
      private DateTime[] T00078_A52PurchaseOrderCreatedDate ;
      private decimal[] T00078_A78PurchaseOrderTotalPaid ;
      private bool[] T00078_n78PurchaseOrderTotalPaid ;
      private DateTime[] T00078_A66PurchaseOrderClosedDate ;
      private bool[] T00078_n66PurchaseOrderClosedDate ;
      private DateTime[] T00078_A53PurchaseOrderModifiedDate ;
      private bool[] T00078_n53PurchaseOrderModifiedDate ;
      private DateTime[] T00078_A135PurchaseOrderConfirmatedDate ;
      private bool[] T00078_n135PurchaseOrderConfirmatedDate ;
      private bool[] T00078_A79PurchaseOrderActive ;
      private string[] T00078_A136PurchaseOrderCanceledDescripti ;
      private bool[] T00078_n136PurchaseOrderCanceledDescripti ;
      private bool[] T00078_A138PurchaseOrderWasPaid ;
      private bool[] T00078_n138PurchaseOrderWasPaid ;
      private DateTime[] T00078_A139PurchaseOrderPaidDate ;
      private bool[] T00078_n139PurchaseOrderPaidDate ;
      private int[] T00078_A4SupplierId ;
      private int[] T000716_A50PurchaseOrderId ;
      private int[] T000717_A50PurchaseOrderId ;
      private int[] T00077_A50PurchaseOrderId ;
      private DateTime[] T00077_A52PurchaseOrderCreatedDate ;
      private decimal[] T00077_A78PurchaseOrderTotalPaid ;
      private bool[] T00077_n78PurchaseOrderTotalPaid ;
      private DateTime[] T00077_A66PurchaseOrderClosedDate ;
      private bool[] T00077_n66PurchaseOrderClosedDate ;
      private DateTime[] T00077_A53PurchaseOrderModifiedDate ;
      private bool[] T00077_n53PurchaseOrderModifiedDate ;
      private DateTime[] T00077_A135PurchaseOrderConfirmatedDate ;
      private bool[] T00077_n135PurchaseOrderConfirmatedDate ;
      private bool[] T00077_A79PurchaseOrderActive ;
      private string[] T00077_A136PurchaseOrderCanceledDescripti ;
      private bool[] T00077_n136PurchaseOrderCanceledDescripti ;
      private bool[] T00077_A138PurchaseOrderWasPaid ;
      private bool[] T00077_n138PurchaseOrderWasPaid ;
      private DateTime[] T00077_A139PurchaseOrderPaidDate ;
      private bool[] T00077_n139PurchaseOrderPaidDate ;
      private int[] T00077_A4SupplierId ;
      private int[] T000718_A50PurchaseOrderId ;
      private short[] T000722_A67PurchaseOrderDetailsQuantity ;
      private int[] T000722_A96PurchaseOrderLastDetailId ;
      private string[] T000723_A5SupplierName ;
      private int[] T000724_A50PurchaseOrderId ;
      private int[] T000725_A50PurchaseOrderId ;
      private int[] T000725_A61PurchaseOrderDetailId ;
      private string[] T000725_A16ProductName ;
      private int[] T000725_A76PurchaseOrderDetailQuantityOrd ;
      private int[] T000725_A77PurchaseOrderDetailQuantityRec ;
      private decimal[] T000725_A134PurchaseOrderDetailSuggestedPr ;
      private bool[] T000725_n134PurchaseOrderDetailSuggestedPr ;
      private int[] T000725_A15ProductId ;
      private string[] T00074_A16ProductName ;
      private string[] T000726_A16ProductName ;
      private int[] T000727_A50PurchaseOrderId ;
      private int[] T000727_A61PurchaseOrderDetailId ;
      private int[] T00073_A50PurchaseOrderId ;
      private int[] T00073_A61PurchaseOrderDetailId ;
      private int[] T00073_A76PurchaseOrderDetailQuantityOrd ;
      private int[] T00073_A77PurchaseOrderDetailQuantityRec ;
      private decimal[] T00073_A134PurchaseOrderDetailSuggestedPr ;
      private bool[] T00073_n134PurchaseOrderDetailSuggestedPr ;
      private int[] T00073_A15ProductId ;
      private int[] T00072_A50PurchaseOrderId ;
      private int[] T00072_A61PurchaseOrderDetailId ;
      private int[] T00072_A76PurchaseOrderDetailQuantityOrd ;
      private int[] T00072_A77PurchaseOrderDetailQuantityRec ;
      private decimal[] T00072_A134PurchaseOrderDetailSuggestedPr ;
      private bool[] T00072_n134PurchaseOrderDetailSuggestedPr ;
      private int[] T00072_A15ProductId ;
      private string[] T000731_A16ProductName ;
      private int[] T000732_A50PurchaseOrderId ;
      private int[] T000732_A61PurchaseOrderDetailId ;
      private GXWebForm Form ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV12TrnContextAtt ;
      private GeneXus.Programs.general.ui.SdtSDTContextSession GXt_SdtSDTContextSession1 ;
   }

   public class purchaseorder__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT000711;
          prmT000711 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmT00076;
          prmT00076 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmT00079;
          prmT00079 = new Object[] {
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          Object[] prmT000713;
          prmT000713 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmT000714;
          prmT000714 = new Object[] {
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          Object[] prmT000715;
          prmT000715 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmT00078;
          prmT00078 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmT000716;
          prmT000716 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmT000717;
          prmT000717 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmT00077;
          prmT00077 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmT000718;
          prmT000718 = new Object[] {
          new ParDef("@PurchaseOrderCreatedDate",GXType.Date,8,0) ,
          new ParDef("@PurchaseOrderTotalPaid",GXType.Decimal,18,2){Nullable=true} ,
          new ParDef("@PurchaseOrderClosedDate",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@PurchaseOrderModifiedDate",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@PurchaseOrderConfirmatedDate",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@PurchaseOrderActive",GXType.Boolean,4,0) ,
          new ParDef("@PurchaseOrderCanceledDescripti",GXType.NVarChar,200,0){Nullable=true} ,
          new ParDef("@PurchaseOrderWasPaid",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@PurchaseOrderPaidDate",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          Object[] prmT000719;
          prmT000719 = new Object[] {
          new ParDef("@PurchaseOrderCreatedDate",GXType.Date,8,0) ,
          new ParDef("@PurchaseOrderTotalPaid",GXType.Decimal,18,2){Nullable=true} ,
          new ParDef("@PurchaseOrderClosedDate",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@PurchaseOrderModifiedDate",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@PurchaseOrderConfirmatedDate",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@PurchaseOrderActive",GXType.Boolean,4,0) ,
          new ParDef("@PurchaseOrderCanceledDescripti",GXType.NVarChar,200,0){Nullable=true} ,
          new ParDef("@PurchaseOrderWasPaid",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@PurchaseOrderPaidDate",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@SupplierId",GXType.Int32,6,0) ,
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmT000720;
          prmT000720 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmT000724;
          prmT000724 = new Object[] {
          };
          Object[] prmT000725;
          prmT000725 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0) ,
          new ParDef("@PurchaseOrderDetailId",GXType.Int32,6,0)
          };
          Object[] prmT00074;
          prmT00074 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmT000726;
          prmT000726 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmT000727;
          prmT000727 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0) ,
          new ParDef("@PurchaseOrderDetailId",GXType.Int32,6,0)
          };
          Object[] prmT00073;
          prmT00073 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0) ,
          new ParDef("@PurchaseOrderDetailId",GXType.Int32,6,0)
          };
          Object[] prmT00072;
          prmT00072 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0) ,
          new ParDef("@PurchaseOrderDetailId",GXType.Int32,6,0)
          };
          Object[] prmT000728;
          prmT000728 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0) ,
          new ParDef("@PurchaseOrderDetailId",GXType.Int32,6,0) ,
          new ParDef("@PurchaseOrderDetailQuantityOrd",GXType.Int32,6,0) ,
          new ParDef("@PurchaseOrderDetailQuantityRec",GXType.Int32,6,0) ,
          new ParDef("@PurchaseOrderDetailSuggestedPr",GXType.Decimal,18,2){Nullable=true} ,
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmT000729;
          prmT000729 = new Object[] {
          new ParDef("@PurchaseOrderDetailQuantityOrd",GXType.Int32,6,0) ,
          new ParDef("@PurchaseOrderDetailQuantityRec",GXType.Int32,6,0) ,
          new ParDef("@PurchaseOrderDetailSuggestedPr",GXType.Decimal,18,2){Nullable=true} ,
          new ParDef("@ProductId",GXType.Int32,6,0) ,
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0) ,
          new ParDef("@PurchaseOrderDetailId",GXType.Int32,6,0)
          };
          Object[] prmT000730;
          prmT000730 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0) ,
          new ParDef("@PurchaseOrderDetailId",GXType.Int32,6,0)
          };
          Object[] prmT000732;
          prmT000732 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmT000722;
          prmT000722 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmT000723;
          prmT000723 = new Object[] {
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          Object[] prmT000731;
          prmT000731 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00072", "SELECT [PurchaseOrderId], [PurchaseOrderDetailId], [PurchaseOrderDetailQuantityOrd], [PurchaseOrderDetailQuantityRec], [PurchaseOrderDetailSuggestedPr], [ProductId] FROM [PurchaseOrderDetail] WITH (UPDLOCK) WHERE [PurchaseOrderId] = @PurchaseOrderId AND [PurchaseOrderDetailId] = @PurchaseOrderDetailId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00072,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00073", "SELECT [PurchaseOrderId], [PurchaseOrderDetailId], [PurchaseOrderDetailQuantityOrd], [PurchaseOrderDetailQuantityRec], [PurchaseOrderDetailSuggestedPr], [ProductId] FROM [PurchaseOrderDetail] WHERE [PurchaseOrderId] = @PurchaseOrderId AND [PurchaseOrderDetailId] = @PurchaseOrderDetailId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00073,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00074", "SELECT [ProductName] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00074,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00076", "SELECT COALESCE( T1.[PurchaseOrderDetailsQuantity], 0) AS PurchaseOrderDetailsQuantity, COALESCE( T1.[PurchaseOrderLastDetailId], 0) AS PurchaseOrderLastDetailId FROM (SELECT COUNT(*) AS PurchaseOrderDetailsQuantity, [PurchaseOrderId], MAX([PurchaseOrderDetailId]) AS PurchaseOrderLastDetailId FROM [PurchaseOrderDetail] WITH (UPDLOCK) GROUP BY [PurchaseOrderId] ) T1 WHERE T1.[PurchaseOrderId] = @PurchaseOrderId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00076,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00077", "SELECT [PurchaseOrderId], [PurchaseOrderCreatedDate], [PurchaseOrderTotalPaid], [PurchaseOrderClosedDate], [PurchaseOrderModifiedDate], [PurchaseOrderConfirmatedDate], [PurchaseOrderActive], [PurchaseOrderCanceledDescripti], [PurchaseOrderWasPaid], [PurchaseOrderPaidDate], [SupplierId] FROM [PurchaseOrder] WITH (UPDLOCK) WHERE [PurchaseOrderId] = @PurchaseOrderId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00077,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00078", "SELECT [PurchaseOrderId], [PurchaseOrderCreatedDate], [PurchaseOrderTotalPaid], [PurchaseOrderClosedDate], [PurchaseOrderModifiedDate], [PurchaseOrderConfirmatedDate], [PurchaseOrderActive], [PurchaseOrderCanceledDescripti], [PurchaseOrderWasPaid], [PurchaseOrderPaidDate], [SupplierId] FROM [PurchaseOrder] WHERE [PurchaseOrderId] = @PurchaseOrderId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00078,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00079", "SELECT [SupplierName] FROM [Supplier] WHERE [SupplierId] = @SupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00079,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000711", "SELECT TM1.[PurchaseOrderId], T3.[SupplierName], TM1.[PurchaseOrderCreatedDate], TM1.[PurchaseOrderTotalPaid], TM1.[PurchaseOrderClosedDate], TM1.[PurchaseOrderModifiedDate], TM1.[PurchaseOrderConfirmatedDate], TM1.[PurchaseOrderActive], TM1.[PurchaseOrderCanceledDescripti], TM1.[PurchaseOrderWasPaid], TM1.[PurchaseOrderPaidDate], TM1.[SupplierId], COALESCE( T2.[PurchaseOrderDetailsQuantity], 0) AS PurchaseOrderDetailsQuantity, COALESCE( T2.[PurchaseOrderLastDetailId], 0) AS PurchaseOrderLastDetailId FROM (([PurchaseOrder] TM1 LEFT JOIN (SELECT COUNT(*) AS PurchaseOrderDetailsQuantity, [PurchaseOrderId], MAX([PurchaseOrderDetailId]) AS PurchaseOrderLastDetailId FROM [PurchaseOrderDetail] GROUP BY [PurchaseOrderId] ) T2 ON T2.[PurchaseOrderId] = TM1.[PurchaseOrderId]) INNER JOIN [Supplier] T3 ON T3.[SupplierId] = TM1.[SupplierId]) WHERE TM1.[PurchaseOrderId] = @PurchaseOrderId ORDER BY TM1.[PurchaseOrderId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000711,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000713", "SELECT COALESCE( T1.[PurchaseOrderDetailsQuantity], 0) AS PurchaseOrderDetailsQuantity, COALESCE( T1.[PurchaseOrderLastDetailId], 0) AS PurchaseOrderLastDetailId FROM (SELECT COUNT(*) AS PurchaseOrderDetailsQuantity, [PurchaseOrderId], MAX([PurchaseOrderDetailId]) AS PurchaseOrderLastDetailId FROM [PurchaseOrderDetail] WITH (UPDLOCK) GROUP BY [PurchaseOrderId] ) T1 WHERE T1.[PurchaseOrderId] = @PurchaseOrderId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000713,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000714", "SELECT [SupplierName] FROM [Supplier] WHERE [SupplierId] = @SupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000714,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000715", "SELECT [PurchaseOrderId] FROM [PurchaseOrder] WHERE [PurchaseOrderId] = @PurchaseOrderId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000715,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000716", "SELECT TOP 1 [PurchaseOrderId] FROM [PurchaseOrder] WHERE ( [PurchaseOrderId] > @PurchaseOrderId) ORDER BY [PurchaseOrderId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000716,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000717", "SELECT TOP 1 [PurchaseOrderId] FROM [PurchaseOrder] WHERE ( [PurchaseOrderId] < @PurchaseOrderId) ORDER BY [PurchaseOrderId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000717,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000718", "INSERT INTO [PurchaseOrder]([PurchaseOrderCreatedDate], [PurchaseOrderTotalPaid], [PurchaseOrderClosedDate], [PurchaseOrderModifiedDate], [PurchaseOrderConfirmatedDate], [PurchaseOrderActive], [PurchaseOrderCanceledDescripti], [PurchaseOrderWasPaid], [PurchaseOrderPaidDate], [SupplierId]) VALUES(@PurchaseOrderCreatedDate, @PurchaseOrderTotalPaid, @PurchaseOrderClosedDate, @PurchaseOrderModifiedDate, @PurchaseOrderConfirmatedDate, @PurchaseOrderActive, @PurchaseOrderCanceledDescripti, @PurchaseOrderWasPaid, @PurchaseOrderPaidDate, @SupplierId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000718,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000719", "UPDATE [PurchaseOrder] SET [PurchaseOrderCreatedDate]=@PurchaseOrderCreatedDate, [PurchaseOrderTotalPaid]=@PurchaseOrderTotalPaid, [PurchaseOrderClosedDate]=@PurchaseOrderClosedDate, [PurchaseOrderModifiedDate]=@PurchaseOrderModifiedDate, [PurchaseOrderConfirmatedDate]=@PurchaseOrderConfirmatedDate, [PurchaseOrderActive]=@PurchaseOrderActive, [PurchaseOrderCanceledDescripti]=@PurchaseOrderCanceledDescripti, [PurchaseOrderWasPaid]=@PurchaseOrderWasPaid, [PurchaseOrderPaidDate]=@PurchaseOrderPaidDate, [SupplierId]=@SupplierId  WHERE [PurchaseOrderId] = @PurchaseOrderId", GxErrorMask.GX_NOMASK,prmT000719)
             ,new CursorDef("T000720", "DELETE FROM [PurchaseOrder]  WHERE [PurchaseOrderId] = @PurchaseOrderId", GxErrorMask.GX_NOMASK,prmT000720)
             ,new CursorDef("T000722", "SELECT COALESCE( T1.[PurchaseOrderDetailsQuantity], 0) AS PurchaseOrderDetailsQuantity, COALESCE( T1.[PurchaseOrderLastDetailId], 0) AS PurchaseOrderLastDetailId FROM (SELECT COUNT(*) AS PurchaseOrderDetailsQuantity, [PurchaseOrderId], MAX([PurchaseOrderDetailId]) AS PurchaseOrderLastDetailId FROM [PurchaseOrderDetail] WITH (UPDLOCK) GROUP BY [PurchaseOrderId] ) T1 WHERE T1.[PurchaseOrderId] = @PurchaseOrderId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000722,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000723", "SELECT [SupplierName] FROM [Supplier] WHERE [SupplierId] = @SupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000723,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000724", "SELECT [PurchaseOrderId] FROM [PurchaseOrder] ORDER BY [PurchaseOrderId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000724,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000725", "SELECT T1.[PurchaseOrderId], T1.[PurchaseOrderDetailId], T2.[ProductName], T1.[PurchaseOrderDetailQuantityOrd], T1.[PurchaseOrderDetailQuantityRec], T1.[PurchaseOrderDetailSuggestedPr], T1.[ProductId] FROM ([PurchaseOrderDetail] T1 INNER JOIN [Product] T2 ON T2.[ProductId] = T1.[ProductId]) WHERE T1.[PurchaseOrderId] = @PurchaseOrderId and T1.[PurchaseOrderDetailId] = @PurchaseOrderDetailId ORDER BY T1.[PurchaseOrderId], T1.[PurchaseOrderDetailId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000725,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000726", "SELECT [ProductName] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000726,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000727", "SELECT [PurchaseOrderId], [PurchaseOrderDetailId] FROM [PurchaseOrderDetail] WHERE [PurchaseOrderId] = @PurchaseOrderId AND [PurchaseOrderDetailId] = @PurchaseOrderDetailId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000727,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000728", "INSERT INTO [PurchaseOrderDetail]([PurchaseOrderId], [PurchaseOrderDetailId], [PurchaseOrderDetailQuantityOrd], [PurchaseOrderDetailQuantityRec], [PurchaseOrderDetailSuggestedPr], [ProductId]) VALUES(@PurchaseOrderId, @PurchaseOrderDetailId, @PurchaseOrderDetailQuantityOrd, @PurchaseOrderDetailQuantityRec, @PurchaseOrderDetailSuggestedPr, @ProductId)", GxErrorMask.GX_NOMASK,prmT000728)
             ,new CursorDef("T000729", "UPDATE [PurchaseOrderDetail] SET [PurchaseOrderDetailQuantityOrd]=@PurchaseOrderDetailQuantityOrd, [PurchaseOrderDetailQuantityRec]=@PurchaseOrderDetailQuantityRec, [PurchaseOrderDetailSuggestedPr]=@PurchaseOrderDetailSuggestedPr, [ProductId]=@ProductId  WHERE [PurchaseOrderId] = @PurchaseOrderId AND [PurchaseOrderDetailId] = @PurchaseOrderDetailId", GxErrorMask.GX_NOMASK,prmT000729)
             ,new CursorDef("T000730", "DELETE FROM [PurchaseOrderDetail]  WHERE [PurchaseOrderId] = @PurchaseOrderId AND [PurchaseOrderDetailId] = @PurchaseOrderDetailId", GxErrorMask.GX_NOMASK,prmT000730)
             ,new CursorDef("T000731", "SELECT [ProductName] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000731,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000732", "SELECT [PurchaseOrderId], [PurchaseOrderDetailId] FROM [PurchaseOrderDetail] WHERE [PurchaseOrderId] = @PurchaseOrderId ORDER BY [PurchaseOrderId], [PurchaseOrderDetailId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000732,11, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((bool[]) buf[10])[0] = rslt.getBool(7);
                ((string[]) buf[11])[0] = rslt.getVarchar(8);
                ((bool[]) buf[12])[0] = rslt.wasNull(8);
                ((bool[]) buf[13])[0] = rslt.getBool(9);
                ((bool[]) buf[14])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(10);
                ((bool[]) buf[16])[0] = rslt.wasNull(10);
                ((int[]) buf[17])[0] = rslt.getInt(11);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((bool[]) buf[10])[0] = rslt.getBool(7);
                ((string[]) buf[11])[0] = rslt.getVarchar(8);
                ((bool[]) buf[12])[0] = rslt.wasNull(8);
                ((bool[]) buf[13])[0] = rslt.getBool(9);
                ((bool[]) buf[14])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(10);
                ((bool[]) buf[16])[0] = rslt.wasNull(10);
                ((int[]) buf[17])[0] = rslt.getInt(11);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((bool[]) buf[11])[0] = rslt.getBool(8);
                ((string[]) buf[12])[0] = rslt.getVarchar(9);
                ((bool[]) buf[13])[0] = rslt.wasNull(9);
                ((bool[]) buf[14])[0] = rslt.getBool(10);
                ((bool[]) buf[15])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[16])[0] = rslt.getGXDate(11);
                ((bool[]) buf[17])[0] = rslt.wasNull(11);
                ((int[]) buf[18])[0] = rslt.getInt(12);
                ((short[]) buf[19])[0] = rslt.getShort(13);
                ((int[]) buf[20])[0] = rslt.getInt(14);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 17 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 18 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 19 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
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
