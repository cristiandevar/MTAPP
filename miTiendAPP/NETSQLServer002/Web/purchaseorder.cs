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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_15") == 0 )
         {
            A50PurchaseOrderId = (int)(Math.Round(NumberUtil.Val( GetPar( "PurchaseOrderId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A50PurchaseOrderId", StringUtil.LTrimStr( (decimal)(A50PurchaseOrderId), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_15( A50PurchaseOrderId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_14") == 0 )
         {
            A4SupplierId = (int)(Math.Round(NumberUtil.Val( GetPar( "SupplierId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A4SupplierId", StringUtil.LTrimStr( (decimal)(A4SupplierId), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_14( A4SupplierId) ;
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
               AV7PurchaseOrderId = (int)(Math.Round(NumberUtil.Val( GetPar( "PurchaseOrderId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7PurchaseOrderId", StringUtil.LTrimStr( (decimal)(AV7PurchaseOrderId), 6, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vPURCHASEORDERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7PurchaseOrderId), "ZZZZZ9"), context));
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
         nRC_GXsfl_73 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_73"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_73_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_73_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_73_idx = GetPar( "sGXsfl_73_idx");
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
         this.AV7PurchaseOrderId = aP1_PurchaseOrderId;
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
         context.WriteHtmlText( "<div id=\""+edtPurchaseOrderCreatedDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPurchaseOrderCreatedDate_Internalname, context.localUtil.Format(A52PurchaseOrderCreatedDate, "99/99/99"), context.localUtil.Format( A52PurchaseOrderCreatedDate, "99/99/99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPurchaseOrderCreatedDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPurchaseOrderCreatedDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_PurchaseOrder.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPurchaseOrderClosedDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPurchaseOrderClosedDate_Internalname, "Closed Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPurchaseOrderClosedDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPurchaseOrderClosedDate_Internalname, context.localUtil.Format(A66PurchaseOrderClosedDate, "99/99/99"), context.localUtil.Format( A66PurchaseOrderClosedDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPurchaseOrderClosedDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPurchaseOrderClosedDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_PurchaseOrder.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPurchaseOrderModifiedDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPurchaseOrderModifiedDate_Internalname, context.localUtil.Format(A53PurchaseOrderModifiedDate, "99/99/99"), context.localUtil.Format( A53PurchaseOrderModifiedDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPurchaseOrderModifiedDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPurchaseOrderModifiedDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_PurchaseOrder.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_PurchaseOrder.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_PurchaseOrder.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
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
         StartGridControl73( ) ;
         nGXsfl_73_idx = 0;
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
            B67PurchaseOrderDetailsQuantity = A67PurchaseOrderDetailsQuantity;
            n67PurchaseOrderDetailsQuantity = false;
            AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
            standaloneNotModal0712( ) ;
            standaloneModal0712( ) ;
            sMode12 = Gx_mode;
            while ( nGXsfl_73_idx < nRC_GXsfl_73 )
            {
               bGXsfl_73_Refreshing = true;
               ReadRow0712( ) ;
               edtPurchaseOrderDetailId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PURCHASEORDERDETAILID_"+sGXsfl_73_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtPurchaseOrderDetailId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderDetailId_Enabled), 5, 0), !bGXsfl_73_Refreshing);
               edtPurchaseOrderDetailQuantity_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PURCHASEORDERDETAILQUANTITY_"+sGXsfl_73_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtPurchaseOrderDetailQuantity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderDetailQuantity_Enabled), 5, 0), !bGXsfl_73_Refreshing);
               edtPurchaseOrderDetailCurrentPric_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PURCHASEORDERDETAILCURRENTPRIC_"+sGXsfl_73_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtPurchaseOrderDetailCurrentPric_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderDetailCurrentPric_Enabled), 5, 0), !bGXsfl_73_Refreshing);
               edtPurchaseOrderDetailSuggestedPr_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PURCHASEORDERDETAILSUGGESTEDPR_"+sGXsfl_73_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtPurchaseOrderDetailSuggestedPr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderDetailSuggestedPr_Enabled), 5, 0), !bGXsfl_73_Refreshing);
               edtProductId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTID_"+sGXsfl_73_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), !bGXsfl_73_Refreshing);
               edtProductName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTNAME_"+sGXsfl_73_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtProductName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductName_Enabled), 5, 0), !bGXsfl_73_Refreshing);
               imgprompt_4_Link = cgiGet( "PROMPT_15_"+sGXsfl_73_idx+"Link");
               if ( ( nRcdExists_12 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0712( ) ;
               }
               SendRow0712( ) ;
               bGXsfl_73_Refreshing = false;
            }
            Gx_mode = sMode12;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A67PurchaseOrderDetailsQuantity = B67PurchaseOrderDetailsQuantity;
            n67PurchaseOrderDetailsQuantity = false;
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
                  sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_7312( ) ;
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
            sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx+1), 4, 0), 4, "0");
            SubsflControlProps_7312( ) ;
            InitAll0712( ) ;
            init_level_properties12( ) ;
            B67PurchaseOrderDetailsQuantity = A67PurchaseOrderDetailsQuantity;
            n67PurchaseOrderDetailsQuantity = false;
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
            A67PurchaseOrderDetailsQuantity = B67PurchaseOrderDetailsQuantity;
            n67PurchaseOrderDetailsQuantity = false;
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
               Z66PurchaseOrderClosedDate = context.localUtil.CToD( cgiGet( "Z66PurchaseOrderClosedDate"), 0);
               n66PurchaseOrderClosedDate = ((DateTime.MinValue==A66PurchaseOrderClosedDate) ? true : false);
               Z53PurchaseOrderModifiedDate = context.localUtil.CToD( cgiGet( "Z53PurchaseOrderModifiedDate"), 0);
               n53PurchaseOrderModifiedDate = ((DateTime.MinValue==A53PurchaseOrderModifiedDate) ? true : false);
               Z4SupplierId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z4SupplierId"), ".", ","), 18, MidpointRounding.ToEven));
               O67PurchaseOrderDetailsQuantity = (short)(Math.Round(context.localUtil.CToN( cgiGet( "O67PurchaseOrderDetailsQuantity"), ".", ","), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_73 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_73"), ".", ","), 18, MidpointRounding.ToEven));
               N4SupplierId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N4SupplierId"), ".", ","), 18, MidpointRounding.ToEven));
               AV7PurchaseOrderId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vPURCHASEORDERID"), ".", ","), 18, MidpointRounding.ToEven));
               AV11Insert_SupplierId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_SUPPLIERID"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_date = context.localUtil.CToD( cgiGet( "vTODAY"), 0);
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","), 18, MidpointRounding.ToEven));
               AV15Pgmname = cgiGet( "vPGMNAME");
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
               A52PurchaseOrderCreatedDate = context.localUtil.CToD( cgiGet( edtPurchaseOrderCreatedDate_Internalname), 1);
               AssignAttri("", false, "A52PurchaseOrderCreatedDate", context.localUtil.Format(A52PurchaseOrderCreatedDate, "99/99/99"));
               if ( context.localUtil.VCDate( cgiGet( edtPurchaseOrderClosedDate_Internalname), 1) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Purchase Order Closed Date"}), 1, "PURCHASEORDERCLOSEDDATE");
                  AnyError = 1;
                  GX_FocusControl = edtPurchaseOrderClosedDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A66PurchaseOrderClosedDate = DateTime.MinValue;
                  n66PurchaseOrderClosedDate = false;
                  AssignAttri("", false, "A66PurchaseOrderClosedDate", context.localUtil.Format(A66PurchaseOrderClosedDate, "99/99/99"));
               }
               else
               {
                  A66PurchaseOrderClosedDate = context.localUtil.CToD( cgiGet( edtPurchaseOrderClosedDate_Internalname), 1);
                  n66PurchaseOrderClosedDate = false;
                  AssignAttri("", false, "A66PurchaseOrderClosedDate", context.localUtil.Format(A66PurchaseOrderClosedDate, "99/99/99"));
               }
               n66PurchaseOrderClosedDate = ((DateTime.MinValue==A66PurchaseOrderClosedDate) ? true : false);
               if ( context.localUtil.VCDate( cgiGet( edtPurchaseOrderModifiedDate_Internalname), 1) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Purchase Order Modified Date"}), 1, "PURCHASEORDERMODIFIEDDATE");
                  AnyError = 1;
                  GX_FocusControl = edtPurchaseOrderModifiedDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A53PurchaseOrderModifiedDate = DateTime.MinValue;
                  n53PurchaseOrderModifiedDate = false;
                  AssignAttri("", false, "A53PurchaseOrderModifiedDate", context.localUtil.Format(A53PurchaseOrderModifiedDate, "99/99/99"));
               }
               else
               {
                  A53PurchaseOrderModifiedDate = context.localUtil.CToD( cgiGet( edtPurchaseOrderModifiedDate_Internalname), 1);
                  n53PurchaseOrderModifiedDate = false;
                  AssignAttri("", false, "A53PurchaseOrderModifiedDate", context.localUtil.Format(A53PurchaseOrderModifiedDate, "99/99/99"));
               }
               n53PurchaseOrderModifiedDate = ((DateTime.MinValue==A53PurchaseOrderModifiedDate) ? true : false);
               A67PurchaseOrderDetailsQuantity = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPurchaseOrderDetailsQuantity_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               n67PurchaseOrderDetailsQuantity = false;
               AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"PurchaseOrder");
               A50PurchaseOrderId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPurchaseOrderId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A50PurchaseOrderId", StringUtil.LTrimStr( (decimal)(A50PurchaseOrderId), 6, 0));
               forbiddenHiddens.Add("PurchaseOrderId", context.localUtil.Format( (decimal)(A50PurchaseOrderId), "ZZZZZ9"));
               A52PurchaseOrderCreatedDate = context.localUtil.CToD( cgiGet( edtPurchaseOrderCreatedDate_Internalname), 1);
               AssignAttri("", false, "A52PurchaseOrderCreatedDate", context.localUtil.Format(A52PurchaseOrderCreatedDate, "99/99/99"));
               forbiddenHiddens.Add("PurchaseOrderCreatedDate", context.localUtil.Format(A52PurchaseOrderCreatedDate, "99/99/99"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
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
         s67PurchaseOrderDetailsQuantity = O67PurchaseOrderDetailsQuantity;
         n67PurchaseOrderDetailsQuantity = false;
         AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
         nGXsfl_73_idx = 0;
         while ( nGXsfl_73_idx < nRC_GXsfl_73 )
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
                        O67PurchaseOrderDetailsQuantity = A67PurchaseOrderDetailsQuantity;
                        n67PurchaseOrderDetailsQuantity = false;
                        AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
                     }
                  }
                  else
                  {
                     GXCCtl = "PURCHASEORDERDETAILID_" + sGXsfl_73_idx;
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
                           O67PurchaseOrderDetailsQuantity = A67PurchaseOrderDetailsQuantity;
                           n67PurchaseOrderDetailsQuantity = false;
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
                              O67PurchaseOrderDetailsQuantity = A67PurchaseOrderDetailsQuantity;
                              n67PurchaseOrderDetailsQuantity = false;
                              AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_12 == 0 )
                     {
                        GXCCtl = "PURCHASEORDERDETAILID_" + sGXsfl_73_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtPurchaseOrderDetailId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtPurchaseOrderDetailId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A61PurchaseOrderDetailId), 6, 0, ".", ""))) ;
            ChangePostValue( edtPurchaseOrderDetailQuantity_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A62PurchaseOrderDetailQuantity), 4, 0, ".", ""))) ;
            ChangePostValue( edtPurchaseOrderDetailCurrentPric_Internalname, StringUtil.LTrim( StringUtil.NToC( A63PurchaseOrderDetailCurrentPric, 10, 2, ".", ""))) ;
            ChangePostValue( edtPurchaseOrderDetailSuggestedPr_Internalname, StringUtil.LTrim( StringUtil.NToC( A64PurchaseOrderDetailSuggestedPr, 10, 2, ".", ""))) ;
            ChangePostValue( edtProductId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", ""))) ;
            ChangePostValue( edtProductName_Internalname, A16ProductName) ;
            ChangePostValue( "ZT_"+"Z61PurchaseOrderDetailId_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z61PurchaseOrderDetailId), 6, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z62PurchaseOrderDetailQuantity_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z62PurchaseOrderDetailQuantity), 4, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z63PurchaseOrderDetailCurrentPric_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( Z63PurchaseOrderDetailCurrentPric, 10, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z64PurchaseOrderDetailSuggestedPr_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( Z64PurchaseOrderDetailSuggestedPr, 10, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z15ProductId_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z15ProductId), 6, 0, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_12_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_12), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_12_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_12), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_12_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_12), 4, 0, ".", ""))) ;
            if ( nIsMod_12 != 0 )
            {
               ChangePostValue( "PURCHASEORDERDETAILID_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPurchaseOrderDetailId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PURCHASEORDERDETAILQUANTITY_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPurchaseOrderDetailQuantity_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PURCHASEORDERDETAILCURRENTPRIC_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPurchaseOrderDetailCurrentPric_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PURCHASEORDERDETAILSUGGESTEDPR_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPurchaseOrderDetailSuggestedPr_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTID_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTNAME_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductName_Enabled), 5, 0, ".", ""))) ;
            }
         }
         O67PurchaseOrderDetailsQuantity = s67PurchaseOrderDetailsQuantity;
         n67PurchaseOrderDetailsQuantity = false;
         AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption070( )
      {
      }

      protected void E11072( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV15Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV15Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         AV11Insert_SupplierId = 0;
         AssignAttri("", false, "AV11Insert_SupplierId", StringUtil.LTrimStr( (decimal)(AV11Insert_SupplierId), 6, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV15Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV16GXV1 = 1;
            AssignAttri("", false, "AV16GXV1", StringUtil.LTrimStr( (decimal)(AV16GXV1), 8, 0));
            while ( AV16GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((GeneXus.Programs.general.ui.SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV16GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "SupplierId") == 0 )
               {
                  AV11Insert_SupplierId = (int)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_SupplierId", StringUtil.LTrimStr( (decimal)(AV11Insert_SupplierId), 6, 0));
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
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z52PurchaseOrderCreatedDate = T00076_A52PurchaseOrderCreatedDate[0];
               Z66PurchaseOrderClosedDate = T00076_A66PurchaseOrderClosedDate[0];
               Z53PurchaseOrderModifiedDate = T00076_A53PurchaseOrderModifiedDate[0];
               Z4SupplierId = T00076_A4SupplierId[0];
            }
            else
            {
               Z52PurchaseOrderCreatedDate = A52PurchaseOrderCreatedDate;
               Z66PurchaseOrderClosedDate = A66PurchaseOrderClosedDate;
               Z53PurchaseOrderModifiedDate = A53PurchaseOrderModifiedDate;
               Z4SupplierId = A4SupplierId;
            }
         }
         if ( GX_JID == -13 )
         {
            Z50PurchaseOrderId = A50PurchaseOrderId;
            Z52PurchaseOrderCreatedDate = A52PurchaseOrderCreatedDate;
            Z66PurchaseOrderClosedDate = A66PurchaseOrderClosedDate;
            Z53PurchaseOrderModifiedDate = A53PurchaseOrderModifiedDate;
            Z4SupplierId = A4SupplierId;
            Z67PurchaseOrderDetailsQuantity = A67PurchaseOrderDetailsQuantity;
            Z5SupplierName = A5SupplierName;
         }
      }

      protected void standaloneNotModal( )
      {
         edtPurchaseOrderId_Enabled = 0;
         AssignProp("", false, edtPurchaseOrderId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderId_Enabled), 5, 0), true);
         edtPurchaseOrderCreatedDate_Enabled = 0;
         AssignProp("", false, edtPurchaseOrderCreatedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderCreatedDate_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         Gx_date = DateTimeUtil.Today( context);
         AssignAttri("", false, "Gx_date", context.localUtil.Format(Gx_date, "99/99/99"));
         imgprompt_4_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0020.aspx"+"',["+"{Ctrl:gx.dom.el('"+"SUPPLIERID"+"'), id:'"+"SUPPLIERID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtPurchaseOrderId_Enabled = 0;
         AssignProp("", false, edtPurchaseOrderId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderId_Enabled), 5, 0), true);
         edtPurchaseOrderCreatedDate_Enabled = 0;
         AssignProp("", false, edtPurchaseOrderCreatedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderCreatedDate_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7PurchaseOrderId) )
         {
            A50PurchaseOrderId = AV7PurchaseOrderId;
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
         if ( IsIns( )  && (DateTime.MinValue==A52PurchaseOrderCreatedDate) && ( Gx_BScreen == 0 ) )
         {
            A52PurchaseOrderCreatedDate = Gx_date;
            AssignAttri("", false, "A52PurchaseOrderCreatedDate", context.localUtil.Format(A52PurchaseOrderCreatedDate, "99/99/99"));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T00079 */
            pr_default.execute(6, new Object[] {A50PurchaseOrderId});
            if ( (pr_default.getStatus(6) != 101) )
            {
               A67PurchaseOrderDetailsQuantity = T00079_A67PurchaseOrderDetailsQuantity[0];
               n67PurchaseOrderDetailsQuantity = T00079_n67PurchaseOrderDetailsQuantity[0];
               AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
            }
            else
            {
               A67PurchaseOrderDetailsQuantity = 0;
               n67PurchaseOrderDetailsQuantity = false;
               AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
            }
            O67PurchaseOrderDetailsQuantity = A67PurchaseOrderDetailsQuantity;
            n67PurchaseOrderDetailsQuantity = false;
            AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
            pr_default.close(6);
            AV15Pgmname = "PurchaseOrder";
            AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
            /* Using cursor T00077 */
            pr_default.execute(5, new Object[] {A4SupplierId});
            A5SupplierName = T00077_A5SupplierName[0];
            AssignAttri("", false, "A5SupplierName", A5SupplierName);
            pr_default.close(5);
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
            A66PurchaseOrderClosedDate = T000711_A66PurchaseOrderClosedDate[0];
            n66PurchaseOrderClosedDate = T000711_n66PurchaseOrderClosedDate[0];
            AssignAttri("", false, "A66PurchaseOrderClosedDate", context.localUtil.Format(A66PurchaseOrderClosedDate, "99/99/99"));
            A53PurchaseOrderModifiedDate = T000711_A53PurchaseOrderModifiedDate[0];
            n53PurchaseOrderModifiedDate = T000711_n53PurchaseOrderModifiedDate[0];
            AssignAttri("", false, "A53PurchaseOrderModifiedDate", context.localUtil.Format(A53PurchaseOrderModifiedDate, "99/99/99"));
            A4SupplierId = T000711_A4SupplierId[0];
            AssignAttri("", false, "A4SupplierId", StringUtil.LTrimStr( (decimal)(A4SupplierId), 6, 0));
            A67PurchaseOrderDetailsQuantity = T000711_A67PurchaseOrderDetailsQuantity[0];
            n67PurchaseOrderDetailsQuantity = T000711_n67PurchaseOrderDetailsQuantity[0];
            AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
            ZM0710( -13) ;
         }
         pr_default.close(7);
         OnLoadActions0710( ) ;
      }

      protected void OnLoadActions0710( )
      {
         O67PurchaseOrderDetailsQuantity = A67PurchaseOrderDetailsQuantity;
         n67PurchaseOrderDetailsQuantity = false;
         AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
         AV15Pgmname = "PurchaseOrder";
         AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
      }

      protected void CheckExtendedTable0710( )
      {
         nIsDirty_10 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV15Pgmname = "PurchaseOrder";
         AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
         /* Using cursor T00079 */
         pr_default.execute(6, new Object[] {A50PurchaseOrderId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            A67PurchaseOrderDetailsQuantity = T00079_A67PurchaseOrderDetailsQuantity[0];
            n67PurchaseOrderDetailsQuantity = T00079_n67PurchaseOrderDetailsQuantity[0];
            AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
         }
         else
         {
            nIsDirty_10 = 1;
            A67PurchaseOrderDetailsQuantity = 0;
            n67PurchaseOrderDetailsQuantity = false;
            AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
         }
         pr_default.close(6);
         /* Using cursor T00077 */
         pr_default.execute(5, new Object[] {A4SupplierId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No matching 'Supplier'.", "ForeignKeyNotFound", 1, "SUPPLIERID");
            AnyError = 1;
            GX_FocusControl = edtSupplierId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A5SupplierName = T00077_A5SupplierName[0];
         AssignAttri("", false, "A5SupplierName", A5SupplierName);
         pr_default.close(5);
         if ( ! ( (DateTime.MinValue==A66PurchaseOrderClosedDate) || ( DateTimeUtil.ResetTime ( A66PurchaseOrderClosedDate ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Purchase Order Closed Date is out of range", "OutOfRange", 1, "PURCHASEORDERCLOSEDDATE");
            AnyError = 1;
            GX_FocusControl = edtPurchaseOrderClosedDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A53PurchaseOrderModifiedDate) || ( DateTimeUtil.ResetTime ( A53PurchaseOrderModifiedDate ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Purchase Order Modified Date is out of range", "OutOfRange", 1, "PURCHASEORDERMODIFIEDDATE");
            AnyError = 1;
            GX_FocusControl = edtPurchaseOrderModifiedDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0710( )
      {
         pr_default.close(6);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_15( int A50PurchaseOrderId )
      {
         /* Using cursor T000713 */
         pr_default.execute(8, new Object[] {A50PurchaseOrderId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            A67PurchaseOrderDetailsQuantity = T000713_A67PurchaseOrderDetailsQuantity[0];
            n67PurchaseOrderDetailsQuantity = T000713_n67PurchaseOrderDetailsQuantity[0];
            AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
         }
         else
         {
            A67PurchaseOrderDetailsQuantity = 0;
            n67PurchaseOrderDetailsQuantity = false;
            AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void gxLoad_14( int A4SupplierId )
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
         /* Using cursor T00076 */
         pr_default.execute(4, new Object[] {A50PurchaseOrderId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM0710( 13) ;
            RcdFound10 = 1;
            A50PurchaseOrderId = T00076_A50PurchaseOrderId[0];
            AssignAttri("", false, "A50PurchaseOrderId", StringUtil.LTrimStr( (decimal)(A50PurchaseOrderId), 6, 0));
            A52PurchaseOrderCreatedDate = T00076_A52PurchaseOrderCreatedDate[0];
            AssignAttri("", false, "A52PurchaseOrderCreatedDate", context.localUtil.Format(A52PurchaseOrderCreatedDate, "99/99/99"));
            A66PurchaseOrderClosedDate = T00076_A66PurchaseOrderClosedDate[0];
            n66PurchaseOrderClosedDate = T00076_n66PurchaseOrderClosedDate[0];
            AssignAttri("", false, "A66PurchaseOrderClosedDate", context.localUtil.Format(A66PurchaseOrderClosedDate, "99/99/99"));
            A53PurchaseOrderModifiedDate = T00076_A53PurchaseOrderModifiedDate[0];
            n53PurchaseOrderModifiedDate = T00076_n53PurchaseOrderModifiedDate[0];
            AssignAttri("", false, "A53PurchaseOrderModifiedDate", context.localUtil.Format(A53PurchaseOrderModifiedDate, "99/99/99"));
            A4SupplierId = T00076_A4SupplierId[0];
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
         pr_default.close(4);
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
            A67PurchaseOrderDetailsQuantity = O67PurchaseOrderDetailsQuantity;
            n67PurchaseOrderDetailsQuantity = false;
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
                  A67PurchaseOrderDetailsQuantity = O67PurchaseOrderDetailsQuantity;
                  n67PurchaseOrderDetailsQuantity = false;
                  AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtSupplierId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  A67PurchaseOrderDetailsQuantity = O67PurchaseOrderDetailsQuantity;
                  n67PurchaseOrderDetailsQuantity = false;
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
                  A67PurchaseOrderDetailsQuantity = O67PurchaseOrderDetailsQuantity;
                  n67PurchaseOrderDetailsQuantity = false;
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
                     A67PurchaseOrderDetailsQuantity = O67PurchaseOrderDetailsQuantity;
                     n67PurchaseOrderDetailsQuantity = false;
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
            A67PurchaseOrderDetailsQuantity = O67PurchaseOrderDetailsQuantity;
            n67PurchaseOrderDetailsQuantity = false;
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
            /* Using cursor T00075 */
            pr_default.execute(3, new Object[] {A50PurchaseOrderId});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PurchaseOrder"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(3) == 101) || ( DateTimeUtil.ResetTime ( Z52PurchaseOrderCreatedDate ) != DateTimeUtil.ResetTime ( T00075_A52PurchaseOrderCreatedDate[0] ) ) || ( DateTimeUtil.ResetTime ( Z66PurchaseOrderClosedDate ) != DateTimeUtil.ResetTime ( T00075_A66PurchaseOrderClosedDate[0] ) ) || ( DateTimeUtil.ResetTime ( Z53PurchaseOrderModifiedDate ) != DateTimeUtil.ResetTime ( T00075_A53PurchaseOrderModifiedDate[0] ) ) || ( Z4SupplierId != T00075_A4SupplierId[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z52PurchaseOrderCreatedDate ) != DateTimeUtil.ResetTime ( T00075_A52PurchaseOrderCreatedDate[0] ) )
               {
                  GXUtil.WriteLog("purchaseorder:[seudo value changed for attri]"+"PurchaseOrderCreatedDate");
                  GXUtil.WriteLogRaw("Old: ",Z52PurchaseOrderCreatedDate);
                  GXUtil.WriteLogRaw("Current: ",T00075_A52PurchaseOrderCreatedDate[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z66PurchaseOrderClosedDate ) != DateTimeUtil.ResetTime ( T00075_A66PurchaseOrderClosedDate[0] ) )
               {
                  GXUtil.WriteLog("purchaseorder:[seudo value changed for attri]"+"PurchaseOrderClosedDate");
                  GXUtil.WriteLogRaw("Old: ",Z66PurchaseOrderClosedDate);
                  GXUtil.WriteLogRaw("Current: ",T00075_A66PurchaseOrderClosedDate[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z53PurchaseOrderModifiedDate ) != DateTimeUtil.ResetTime ( T00075_A53PurchaseOrderModifiedDate[0] ) )
               {
                  GXUtil.WriteLog("purchaseorder:[seudo value changed for attri]"+"PurchaseOrderModifiedDate");
                  GXUtil.WriteLogRaw("Old: ",Z53PurchaseOrderModifiedDate);
                  GXUtil.WriteLogRaw("Current: ",T00075_A53PurchaseOrderModifiedDate[0]);
               }
               if ( Z4SupplierId != T00075_A4SupplierId[0] )
               {
                  GXUtil.WriteLog("purchaseorder:[seudo value changed for attri]"+"SupplierId");
                  GXUtil.WriteLogRaw("Old: ",Z4SupplierId);
                  GXUtil.WriteLogRaw("Current: ",T00075_A4SupplierId[0]);
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
                     pr_default.execute(13, new Object[] {A52PurchaseOrderCreatedDate, n66PurchaseOrderClosedDate, A66PurchaseOrderClosedDate, n53PurchaseOrderModifiedDate, A53PurchaseOrderModifiedDate, A4SupplierId});
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
                     pr_default.execute(14, new Object[] {A52PurchaseOrderCreatedDate, n66PurchaseOrderClosedDate, A66PurchaseOrderClosedDate, n53PurchaseOrderModifiedDate, A53PurchaseOrderModifiedDate, A4SupplierId, A50PurchaseOrderId});
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
                  A67PurchaseOrderDetailsQuantity = O67PurchaseOrderDetailsQuantity;
                  n67PurchaseOrderDetailsQuantity = false;
                  AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
                  ScanStart0712( ) ;
                  while ( RcdFound12 != 0 )
                  {
                     getByPrimaryKey0712( ) ;
                     Delete0712( ) ;
                     ScanNext0712( ) ;
                     O67PurchaseOrderDetailsQuantity = A67PurchaseOrderDetailsQuantity;
                     n67PurchaseOrderDetailsQuantity = false;
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
            AV15Pgmname = "PurchaseOrder";
            AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
            /* Using cursor T000722 */
            pr_default.execute(16, new Object[] {A50PurchaseOrderId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               A67PurchaseOrderDetailsQuantity = T000722_A67PurchaseOrderDetailsQuantity[0];
               n67PurchaseOrderDetailsQuantity = T000722_n67PurchaseOrderDetailsQuantity[0];
               AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
            }
            else
            {
               A67PurchaseOrderDetailsQuantity = 0;
               n67PurchaseOrderDetailsQuantity = false;
               AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
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
         s67PurchaseOrderDetailsQuantity = O67PurchaseOrderDetailsQuantity;
         n67PurchaseOrderDetailsQuantity = false;
         AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
         nGXsfl_73_idx = 0;
         while ( nGXsfl_73_idx < nRC_GXsfl_73 )
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
                        GXCCtl = "PURCHASEORDERDETAILID_" + sGXsfl_73_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtPurchaseOrderDetailId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
               O67PurchaseOrderDetailsQuantity = A67PurchaseOrderDetailsQuantity;
               n67PurchaseOrderDetailsQuantity = false;
               AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
            }
            ChangePostValue( edtPurchaseOrderDetailId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A61PurchaseOrderDetailId), 6, 0, ".", ""))) ;
            ChangePostValue( edtPurchaseOrderDetailQuantity_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A62PurchaseOrderDetailQuantity), 4, 0, ".", ""))) ;
            ChangePostValue( edtPurchaseOrderDetailCurrentPric_Internalname, StringUtil.LTrim( StringUtil.NToC( A63PurchaseOrderDetailCurrentPric, 10, 2, ".", ""))) ;
            ChangePostValue( edtPurchaseOrderDetailSuggestedPr_Internalname, StringUtil.LTrim( StringUtil.NToC( A64PurchaseOrderDetailSuggestedPr, 10, 2, ".", ""))) ;
            ChangePostValue( edtProductId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", ""))) ;
            ChangePostValue( edtProductName_Internalname, A16ProductName) ;
            ChangePostValue( "ZT_"+"Z61PurchaseOrderDetailId_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z61PurchaseOrderDetailId), 6, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z62PurchaseOrderDetailQuantity_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z62PurchaseOrderDetailQuantity), 4, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z63PurchaseOrderDetailCurrentPric_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( Z63PurchaseOrderDetailCurrentPric, 10, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z64PurchaseOrderDetailSuggestedPr_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( Z64PurchaseOrderDetailSuggestedPr, 10, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z15ProductId_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z15ProductId), 6, 0, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_12_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_12), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_12_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_12), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_12_"+sGXsfl_73_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_12), 4, 0, ".", ""))) ;
            if ( nIsMod_12 != 0 )
            {
               ChangePostValue( "PURCHASEORDERDETAILID_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPurchaseOrderDetailId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PURCHASEORDERDETAILQUANTITY_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPurchaseOrderDetailQuantity_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PURCHASEORDERDETAILCURRENTPRIC_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPurchaseOrderDetailCurrentPric_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PURCHASEORDERDETAILSUGGESTEDPR_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPurchaseOrderDetailSuggestedPr_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTID_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUCTNAME_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductName_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0712( ) ;
         if ( AnyError != 0 )
         {
            O67PurchaseOrderDetailsQuantity = s67PurchaseOrderDetailsQuantity;
            n67PurchaseOrderDetailsQuantity = false;
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
            O67PurchaseOrderDetailsQuantity = s67PurchaseOrderDetailsQuantity;
            n67PurchaseOrderDetailsQuantity = false;
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
            pr_default.close(3);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0710( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(4);
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
            pr_default.close(4);
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
         edtPurchaseOrderClosedDate_Enabled = 0;
         AssignProp("", false, edtPurchaseOrderClosedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderClosedDate_Enabled), 5, 0), true);
         edtPurchaseOrderModifiedDate_Enabled = 0;
         AssignProp("", false, edtPurchaseOrderModifiedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderModifiedDate_Enabled), 5, 0), true);
         edtPurchaseOrderDetailsQuantity_Enabled = 0;
         AssignProp("", false, edtPurchaseOrderDetailsQuantity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderDetailsQuantity_Enabled), 5, 0), true);
      }

      protected void ZM0712( short GX_JID )
      {
         if ( ( GX_JID == 16 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z62PurchaseOrderDetailQuantity = T00073_A62PurchaseOrderDetailQuantity[0];
               Z63PurchaseOrderDetailCurrentPric = T00073_A63PurchaseOrderDetailCurrentPric[0];
               Z64PurchaseOrderDetailSuggestedPr = T00073_A64PurchaseOrderDetailSuggestedPr[0];
               Z15ProductId = T00073_A15ProductId[0];
            }
            else
            {
               Z62PurchaseOrderDetailQuantity = A62PurchaseOrderDetailQuantity;
               Z63PurchaseOrderDetailCurrentPric = A63PurchaseOrderDetailCurrentPric;
               Z64PurchaseOrderDetailSuggestedPr = A64PurchaseOrderDetailSuggestedPr;
               Z15ProductId = A15ProductId;
            }
         }
         if ( GX_JID == -16 )
         {
            Z50PurchaseOrderId = A50PurchaseOrderId;
            Z61PurchaseOrderDetailId = A61PurchaseOrderDetailId;
            Z62PurchaseOrderDetailQuantity = A62PurchaseOrderDetailQuantity;
            Z63PurchaseOrderDetailCurrentPric = A63PurchaseOrderDetailCurrentPric;
            Z64PurchaseOrderDetailSuggestedPr = A64PurchaseOrderDetailSuggestedPr;
            Z15ProductId = A15ProductId;
            Z16ProductName = A16ProductName;
         }
      }

      protected void standaloneNotModal0712( )
      {
      }

      protected void standaloneModal0712( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtPurchaseOrderDetailId_Enabled = 0;
            AssignProp("", false, edtPurchaseOrderDetailId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderDetailId_Enabled), 5, 0), !bGXsfl_73_Refreshing);
         }
         else
         {
            edtPurchaseOrderDetailId_Enabled = 1;
            AssignProp("", false, edtPurchaseOrderDetailId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderDetailId_Enabled), 5, 0), !bGXsfl_73_Refreshing);
         }
      }

      protected void Load0712( )
      {
         /* Using cursor T000725 */
         pr_default.execute(19, new Object[] {A50PurchaseOrderId, A61PurchaseOrderDetailId});
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound12 = 1;
            A62PurchaseOrderDetailQuantity = T000725_A62PurchaseOrderDetailQuantity[0];
            A63PurchaseOrderDetailCurrentPric = T000725_A63PurchaseOrderDetailCurrentPric[0];
            A64PurchaseOrderDetailSuggestedPr = T000725_A64PurchaseOrderDetailSuggestedPr[0];
            A16ProductName = T000725_A16ProductName[0];
            A15ProductId = T000725_A15ProductId[0];
            ZM0712( -16) ;
         }
         pr_default.close(19);
         OnLoadActions0712( ) ;
      }

      protected void OnLoadActions0712( )
      {
         if ( IsIns( )  )
         {
            A67PurchaseOrderDetailsQuantity = (short)(O67PurchaseOrderDetailsQuantity+1);
            n67PurchaseOrderDetailsQuantity = false;
            AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
         }
         else
         {
            if ( IsUpd( )  )
            {
               A67PurchaseOrderDetailsQuantity = O67PurchaseOrderDetailsQuantity;
               n67PurchaseOrderDetailsQuantity = false;
               AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
            }
            else
            {
               if ( IsDlt( )  )
               {
                  A67PurchaseOrderDetailsQuantity = (short)(O67PurchaseOrderDetailsQuantity-1);
                  n67PurchaseOrderDetailsQuantity = false;
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
            n67PurchaseOrderDetailsQuantity = false;
            AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
         }
         else
         {
            if ( IsUpd( )  )
            {
               nIsDirty_12 = 1;
               A67PurchaseOrderDetailsQuantity = O67PurchaseOrderDetailsQuantity;
               n67PurchaseOrderDetailsQuantity = false;
               AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
            }
            else
            {
               if ( IsDlt( )  )
               {
                  nIsDirty_12 = 1;
                  A67PurchaseOrderDetailsQuantity = (short)(O67PurchaseOrderDetailsQuantity-1);
                  n67PurchaseOrderDetailsQuantity = false;
                  AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
               }
            }
         }
         /* Using cursor T00074 */
         pr_default.execute(2, new Object[] {A15ProductId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "PRODUCTID_" + sGXsfl_73_idx;
            GX_msglist.addItem("No matching 'Product'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProductId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A16ProductName = T00074_A16ProductName[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0712( )
      {
         pr_default.close(2);
      }

      protected void enableDisable0712( )
      {
      }

      protected void gxLoad_17( int A15ProductId )
      {
         /* Using cursor T000726 */
         pr_default.execute(20, new Object[] {A15ProductId});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GXCCtl = "PRODUCTID_" + sGXsfl_73_idx;
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
            ZM0712( 16) ;
            RcdFound12 = 1;
            InitializeNonKey0712( ) ;
            A61PurchaseOrderDetailId = T00073_A61PurchaseOrderDetailId[0];
            A62PurchaseOrderDetailQuantity = T00073_A62PurchaseOrderDetailQuantity[0];
            A63PurchaseOrderDetailCurrentPric = T00073_A63PurchaseOrderDetailCurrentPric[0];
            A64PurchaseOrderDetailSuggestedPr = T00073_A64PurchaseOrderDetailSuggestedPr[0];
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
            if ( (pr_default.getStatus(0) == 101) || ( Z62PurchaseOrderDetailQuantity != T00072_A62PurchaseOrderDetailQuantity[0] ) || ( Z63PurchaseOrderDetailCurrentPric != T00072_A63PurchaseOrderDetailCurrentPric[0] ) || ( Z64PurchaseOrderDetailSuggestedPr != T00072_A64PurchaseOrderDetailSuggestedPr[0] ) || ( Z15ProductId != T00072_A15ProductId[0] ) )
            {
               if ( Z62PurchaseOrderDetailQuantity != T00072_A62PurchaseOrderDetailQuantity[0] )
               {
                  GXUtil.WriteLog("purchaseorder:[seudo value changed for attri]"+"PurchaseOrderDetailQuantity");
                  GXUtil.WriteLogRaw("Old: ",Z62PurchaseOrderDetailQuantity);
                  GXUtil.WriteLogRaw("Current: ",T00072_A62PurchaseOrderDetailQuantity[0]);
               }
               if ( Z63PurchaseOrderDetailCurrentPric != T00072_A63PurchaseOrderDetailCurrentPric[0] )
               {
                  GXUtil.WriteLog("purchaseorder:[seudo value changed for attri]"+"PurchaseOrderDetailCurrentPric");
                  GXUtil.WriteLogRaw("Old: ",Z63PurchaseOrderDetailCurrentPric);
                  GXUtil.WriteLogRaw("Current: ",T00072_A63PurchaseOrderDetailCurrentPric[0]);
               }
               if ( Z64PurchaseOrderDetailSuggestedPr != T00072_A64PurchaseOrderDetailSuggestedPr[0] )
               {
                  GXUtil.WriteLog("purchaseorder:[seudo value changed for attri]"+"PurchaseOrderDetailSuggestedPr");
                  GXUtil.WriteLogRaw("Old: ",Z64PurchaseOrderDetailSuggestedPr);
                  GXUtil.WriteLogRaw("Current: ",T00072_A64PurchaseOrderDetailSuggestedPr[0]);
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
                     pr_default.execute(22, new Object[] {A50PurchaseOrderId, A61PurchaseOrderDetailId, A62PurchaseOrderDetailQuantity, A63PurchaseOrderDetailCurrentPric, A64PurchaseOrderDetailSuggestedPr, A15ProductId});
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
                        pr_default.execute(23, new Object[] {A62PurchaseOrderDetailQuantity, A63PurchaseOrderDetailCurrentPric, A64PurchaseOrderDetailSuggestedPr, A15ProductId, A50PurchaseOrderId, A61PurchaseOrderDetailId});
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
               n67PurchaseOrderDetailsQuantity = false;
               AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
            }
            else
            {
               if ( IsUpd( )  )
               {
                  A67PurchaseOrderDetailsQuantity = O67PurchaseOrderDetailsQuantity;
                  n67PurchaseOrderDetailsQuantity = false;
                  AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
               }
               else
               {
                  if ( IsDlt( )  )
                  {
                     A67PurchaseOrderDetailsQuantity = (short)(O67PurchaseOrderDetailsQuantity-1);
                     n67PurchaseOrderDetailsQuantity = false;
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
         AssignProp("", false, edtPurchaseOrderDetailId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderDetailId_Enabled), 5, 0), !bGXsfl_73_Refreshing);
         edtPurchaseOrderDetailQuantity_Enabled = 0;
         AssignProp("", false, edtPurchaseOrderDetailQuantity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderDetailQuantity_Enabled), 5, 0), !bGXsfl_73_Refreshing);
         edtPurchaseOrderDetailCurrentPric_Enabled = 0;
         AssignProp("", false, edtPurchaseOrderDetailCurrentPric_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderDetailCurrentPric_Enabled), 5, 0), !bGXsfl_73_Refreshing);
         edtPurchaseOrderDetailSuggestedPr_Enabled = 0;
         AssignProp("", false, edtPurchaseOrderDetailSuggestedPr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderDetailSuggestedPr_Enabled), 5, 0), !bGXsfl_73_Refreshing);
         edtProductId_Enabled = 0;
         AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), !bGXsfl_73_Refreshing);
         edtProductName_Enabled = 0;
         AssignProp("", false, edtProductName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductName_Enabled), 5, 0), !bGXsfl_73_Refreshing);
      }

      protected void send_integrity_lvl_hashes0712( )
      {
      }

      protected void send_integrity_lvl_hashes0710( )
      {
      }

      protected void SubsflControlProps_7312( )
      {
         edtPurchaseOrderDetailId_Internalname = "PURCHASEORDERDETAILID_"+sGXsfl_73_idx;
         edtPurchaseOrderDetailQuantity_Internalname = "PURCHASEORDERDETAILQUANTITY_"+sGXsfl_73_idx;
         edtPurchaseOrderDetailCurrentPric_Internalname = "PURCHASEORDERDETAILCURRENTPRIC_"+sGXsfl_73_idx;
         edtPurchaseOrderDetailSuggestedPr_Internalname = "PURCHASEORDERDETAILSUGGESTEDPR_"+sGXsfl_73_idx;
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_73_idx;
         imgprompt_15_Internalname = "PROMPT_15_"+sGXsfl_73_idx;
         edtProductName_Internalname = "PRODUCTNAME_"+sGXsfl_73_idx;
      }

      protected void SubsflControlProps_fel_7312( )
      {
         edtPurchaseOrderDetailId_Internalname = "PURCHASEORDERDETAILID_"+sGXsfl_73_fel_idx;
         edtPurchaseOrderDetailQuantity_Internalname = "PURCHASEORDERDETAILQUANTITY_"+sGXsfl_73_fel_idx;
         edtPurchaseOrderDetailCurrentPric_Internalname = "PURCHASEORDERDETAILCURRENTPRIC_"+sGXsfl_73_fel_idx;
         edtPurchaseOrderDetailSuggestedPr_Internalname = "PURCHASEORDERDETAILSUGGESTEDPR_"+sGXsfl_73_fel_idx;
         edtProductId_Internalname = "PRODUCTID_"+sGXsfl_73_fel_idx;
         imgprompt_15_Internalname = "PROMPT_15_"+sGXsfl_73_fel_idx;
         edtProductName_Internalname = "PRODUCTNAME_"+sGXsfl_73_fel_idx;
      }

      protected void AddRow0712( )
      {
         nGXsfl_73_idx = (int)(nGXsfl_73_idx+1);
         sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx), 4, 0), 4, "0");
         SubsflControlProps_7312( ) ;
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
            if ( ((int)((nGXsfl_73_idx) % (2))) == 0 )
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
         imgprompt_15_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0050.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PRODUCTID_"+sGXsfl_73_idx+"'), id:'"+"PRODUCTID_"+sGXsfl_73_idx+"'"+",IOType:'out'}"+"],"+"gx.dom.form()."+"nIsMod_12_"+sGXsfl_73_idx+","+"'', false"+","+"false"+");");
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_12_" + sGXsfl_73_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 74,'',false,'" + sGXsfl_73_idx + "',73)\"";
         ROClassString = "Attribute";
         Gridpurchaseorder_detailRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPurchaseOrderDetailId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A61PurchaseOrderDetailId), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A61PurchaseOrderDetailId), "ZZZZZ9"))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,74);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPurchaseOrderDetailId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtPurchaseOrderDetailId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)73,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_12_" + sGXsfl_73_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 75,'',false,'" + sGXsfl_73_idx + "',73)\"";
         ROClassString = "Attribute";
         Gridpurchaseorder_detailRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPurchaseOrderDetailQuantity_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A62PurchaseOrderDetailQuantity), 4, 0, ".", "")),StringUtil.LTrim( ((edtPurchaseOrderDetailQuantity_Enabled!=0) ? context.localUtil.Format( (decimal)(A62PurchaseOrderDetailQuantity), "ZZZ9") : context.localUtil.Format( (decimal)(A62PurchaseOrderDetailQuantity), "ZZZ9")))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,75);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPurchaseOrderDetailQuantity_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtPurchaseOrderDetailQuantity_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)73,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_12_" + sGXsfl_73_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_73_idx + "',73)\"";
         ROClassString = "Attribute";
         Gridpurchaseorder_detailRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPurchaseOrderDetailCurrentPric_Internalname,StringUtil.LTrim( StringUtil.NToC( A63PurchaseOrderDetailCurrentPric, 10, 2, ".", "")),StringUtil.LTrim( ((edtPurchaseOrderDetailCurrentPric_Enabled!=0) ? context.localUtil.Format( A63PurchaseOrderDetailCurrentPric, "ZZZZZZ9.99") : context.localUtil.Format( A63PurchaseOrderDetailCurrentPric, "ZZZZZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,76);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPurchaseOrderDetailCurrentPric_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtPurchaseOrderDetailCurrentPric_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)73,(short)0,(short)-1,(short)0,(bool)true,(string)"Price",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_12_" + sGXsfl_73_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 77,'',false,'" + sGXsfl_73_idx + "',73)\"";
         ROClassString = "Attribute";
         Gridpurchaseorder_detailRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPurchaseOrderDetailSuggestedPr_Internalname,StringUtil.LTrim( StringUtil.NToC( A64PurchaseOrderDetailSuggestedPr, 10, 2, ".", "")),StringUtil.LTrim( ((edtPurchaseOrderDetailSuggestedPr_Enabled!=0) ? context.localUtil.Format( A64PurchaseOrderDetailSuggestedPr, "ZZZZZZ9.99") : context.localUtil.Format( A64PurchaseOrderDetailSuggestedPr, "ZZZZZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,77);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPurchaseOrderDetailSuggestedPr_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtPurchaseOrderDetailSuggestedPr_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)73,(short)0,(short)-1,(short)0,(bool)true,(string)"Price",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_12_" + sGXsfl_73_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 78,'',false,'" + sGXsfl_73_idx + "',73)\"";
         ROClassString = "Attribute";
         Gridpurchaseorder_detailRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", "")),StringUtil.LTrim( ((edtProductId_Enabled!=0) ? context.localUtil.Format( (decimal)(A15ProductId), "ZZZZZ9") : context.localUtil.Format( (decimal)(A15ProductId), "ZZZZZ9")))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,78);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProductId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)73,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_15_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_15_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         Gridpurchaseorder_detailRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_15_Internalname,(string)sImgUrl,(string)imgprompt_15_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_15_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridpurchaseorder_detailRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProductName_Internalname,(string)A16ProductName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProductName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProductName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)73,(short)0,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
         ajax_sending_grid_row(Gridpurchaseorder_detailRow);
         send_integrity_lvl_hashes0712( ) ;
         GXCCtl = "Z61PurchaseOrderDetailId_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z61PurchaseOrderDetailId), 6, 0, ".", "")));
         GXCCtl = "Z62PurchaseOrderDetailQuantity_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z62PurchaseOrderDetailQuantity), 4, 0, ".", "")));
         GXCCtl = "Z63PurchaseOrderDetailCurrentPric_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z63PurchaseOrderDetailCurrentPric, 10, 2, ".", "")));
         GXCCtl = "Z64PurchaseOrderDetailSuggestedPr_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z64PurchaseOrderDetailSuggestedPr, 10, 2, ".", "")));
         GXCCtl = "Z15ProductId_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z15ProductId), 6, 0, ".", "")));
         GXCCtl = "nRcdDeleted_12_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_12), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_12_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_12), 4, 0, ".", "")));
         GXCCtl = "nIsMod_12_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_12), 4, 0, ".", "")));
         GXCCtl = "vMODE_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_73_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV9TrnContext);
         }
         GXCCtl = "vPURCHASEORDERID_" + sGXsfl_73_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7PurchaseOrderId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PURCHASEORDERDETAILID_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPurchaseOrderDetailId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PURCHASEORDERDETAILQUANTITY_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPurchaseOrderDetailQuantity_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PURCHASEORDERDETAILCURRENTPRIC_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPurchaseOrderDetailCurrentPric_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PURCHASEORDERDETAILSUGGESTEDPR_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPurchaseOrderDetailSuggestedPr_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTID_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUCTNAME_"+sGXsfl_73_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProductName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_15_"+sGXsfl_73_idx+"Link", StringUtil.RTrim( imgprompt_15_Link));
         ajax_sending_grid_row(null);
         Gridpurchaseorder_detailContainer.AddRow(Gridpurchaseorder_detailRow);
      }

      protected void ReadRow0712( )
      {
         nGXsfl_73_idx = (int)(nGXsfl_73_idx+1);
         sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx), 4, 0), 4, "0");
         SubsflControlProps_7312( ) ;
         edtPurchaseOrderDetailId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PURCHASEORDERDETAILID_"+sGXsfl_73_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtPurchaseOrderDetailQuantity_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PURCHASEORDERDETAILQUANTITY_"+sGXsfl_73_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtPurchaseOrderDetailCurrentPric_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PURCHASEORDERDETAILCURRENTPRIC_"+sGXsfl_73_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtPurchaseOrderDetailSuggestedPr_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PURCHASEORDERDETAILSUGGESTEDPR_"+sGXsfl_73_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtProductId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTID_"+sGXsfl_73_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         edtProductName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRODUCTNAME_"+sGXsfl_73_idx+"Enabled"), ".", ","), 18, MidpointRounding.ToEven));
         imgprompt_4_Link = cgiGet( "PROMPT_15_"+sGXsfl_73_idx+"Link");
         if ( ( ( context.localUtil.CToN( cgiGet( edtPurchaseOrderDetailId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPurchaseOrderDetailId_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
         {
            GXCCtl = "PURCHASEORDERDETAILID_" + sGXsfl_73_idx;
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
         if ( ( ( context.localUtil.CToN( cgiGet( edtPurchaseOrderDetailQuantity_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPurchaseOrderDetailQuantity_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "PURCHASEORDERDETAILQUANTITY_" + sGXsfl_73_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtPurchaseOrderDetailQuantity_Internalname;
            wbErr = true;
            A62PurchaseOrderDetailQuantity = 0;
         }
         else
         {
            A62PurchaseOrderDetailQuantity = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPurchaseOrderDetailQuantity_Internalname), ".", ","), 18, MidpointRounding.ToEven));
         }
         if ( ( ( context.localUtil.CToN( cgiGet( edtPurchaseOrderDetailCurrentPric_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPurchaseOrderDetailCurrentPric_Internalname), ".", ",") > 9999999.99m ) ) )
         {
            GXCCtl = "PURCHASEORDERDETAILCURRENTPRIC_" + sGXsfl_73_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtPurchaseOrderDetailCurrentPric_Internalname;
            wbErr = true;
            A63PurchaseOrderDetailCurrentPric = 0;
         }
         else
         {
            A63PurchaseOrderDetailCurrentPric = context.localUtil.CToN( cgiGet( edtPurchaseOrderDetailCurrentPric_Internalname), ".", ",");
         }
         if ( ( ( context.localUtil.CToN( cgiGet( edtPurchaseOrderDetailSuggestedPr_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPurchaseOrderDetailSuggestedPr_Internalname), ".", ",") > 9999999.99m ) ) )
         {
            GXCCtl = "PURCHASEORDERDETAILSUGGESTEDPR_" + sGXsfl_73_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtPurchaseOrderDetailSuggestedPr_Internalname;
            wbErr = true;
            A64PurchaseOrderDetailSuggestedPr = 0;
         }
         else
         {
            A64PurchaseOrderDetailSuggestedPr = context.localUtil.CToN( cgiGet( edtPurchaseOrderDetailSuggestedPr_Internalname), ".", ",");
         }
         if ( ( ( context.localUtil.CToN( cgiGet( edtProductId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProductId_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
         {
            GXCCtl = "PRODUCTID_" + sGXsfl_73_idx;
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
         GXCCtl = "Z61PurchaseOrderDetailId_" + sGXsfl_73_idx;
         Z61PurchaseOrderDetailId = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "Z62PurchaseOrderDetailQuantity_" + sGXsfl_73_idx;
         Z62PurchaseOrderDetailQuantity = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "Z63PurchaseOrderDetailCurrentPric_" + sGXsfl_73_idx;
         Z63PurchaseOrderDetailCurrentPric = context.localUtil.CToN( cgiGet( GXCCtl), ".", ",");
         GXCCtl = "Z64PurchaseOrderDetailSuggestedPr_" + sGXsfl_73_idx;
         Z64PurchaseOrderDetailSuggestedPr = context.localUtil.CToN( cgiGet( GXCCtl), ".", ",");
         GXCCtl = "Z15ProductId_" + sGXsfl_73_idx;
         Z15ProductId = (int)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdDeleted_12_" + sGXsfl_73_idx;
         nRcdDeleted_12 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_12_" + sGXsfl_73_idx;
         nRcdExists_12 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_12_" + sGXsfl_73_idx;
         nIsMod_12 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtPurchaseOrderDetailId_Enabled = edtPurchaseOrderDetailId_Enabled;
      }

      protected void ConfirmValues070( )
      {
         nGXsfl_73_idx = 0;
         sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx), 4, 0), 4, "0");
         SubsflControlProps_7312( ) ;
         while ( nGXsfl_73_idx < nRC_GXsfl_73 )
         {
            nGXsfl_73_idx = (int)(nGXsfl_73_idx+1);
            sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx), 4, 0), 4, "0");
            SubsflControlProps_7312( ) ;
            ChangePostValue( "Z61PurchaseOrderDetailId_"+sGXsfl_73_idx, cgiGet( "ZT_"+"Z61PurchaseOrderDetailId_"+sGXsfl_73_idx)) ;
            DeletePostValue( "ZT_"+"Z61PurchaseOrderDetailId_"+sGXsfl_73_idx) ;
            ChangePostValue( "Z62PurchaseOrderDetailQuantity_"+sGXsfl_73_idx, cgiGet( "ZT_"+"Z62PurchaseOrderDetailQuantity_"+sGXsfl_73_idx)) ;
            DeletePostValue( "ZT_"+"Z62PurchaseOrderDetailQuantity_"+sGXsfl_73_idx) ;
            ChangePostValue( "Z63PurchaseOrderDetailCurrentPric_"+sGXsfl_73_idx, cgiGet( "ZT_"+"Z63PurchaseOrderDetailCurrentPric_"+sGXsfl_73_idx)) ;
            DeletePostValue( "ZT_"+"Z63PurchaseOrderDetailCurrentPric_"+sGXsfl_73_idx) ;
            ChangePostValue( "Z64PurchaseOrderDetailSuggestedPr_"+sGXsfl_73_idx, cgiGet( "ZT_"+"Z64PurchaseOrderDetailSuggestedPr_"+sGXsfl_73_idx)) ;
            DeletePostValue( "ZT_"+"Z64PurchaseOrderDetailSuggestedPr_"+sGXsfl_73_idx) ;
            ChangePostValue( "Z15ProductId_"+sGXsfl_73_idx, cgiGet( "ZT_"+"Z15ProductId_"+sGXsfl_73_idx)) ;
            DeletePostValue( "ZT_"+"Z15ProductId_"+sGXsfl_73_idx) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("purchaseorder.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7PurchaseOrderId,6,0))}, new string[] {"Gx_mode","PurchaseOrderId"}) +"\">") ;
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
         forbiddenHiddens.Add("PurchaseOrderCreatedDate", context.localUtil.Format(A52PurchaseOrderCreatedDate, "99/99/99"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
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
         GxWebStd.gx_hidden_field( context, "Z66PurchaseOrderClosedDate", context.localUtil.DToC( Z66PurchaseOrderClosedDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z53PurchaseOrderModifiedDate", context.localUtil.DToC( Z53PurchaseOrderModifiedDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z4SupplierId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z4SupplierId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "O67PurchaseOrderDetailsQuantity", StringUtil.LTrim( StringUtil.NToC( (decimal)(O67PurchaseOrderDetailsQuantity), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_73", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_73_idx), 8, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "vPURCHASEORDERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7PurchaseOrderId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPURCHASEORDERID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7PurchaseOrderId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_SUPPLIERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_SupplierId), 6, 0, ".", "")));
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
         return formatLink("purchaseorder.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7PurchaseOrderId,6,0))}, new string[] {"Gx_mode","PurchaseOrderId"})  ;
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
         A66PurchaseOrderClosedDate = DateTime.MinValue;
         n66PurchaseOrderClosedDate = false;
         AssignAttri("", false, "A66PurchaseOrderClosedDate", context.localUtil.Format(A66PurchaseOrderClosedDate, "99/99/99"));
         n66PurchaseOrderClosedDate = ((DateTime.MinValue==A66PurchaseOrderClosedDate) ? true : false);
         A53PurchaseOrderModifiedDate = DateTime.MinValue;
         n53PurchaseOrderModifiedDate = false;
         AssignAttri("", false, "A53PurchaseOrderModifiedDate", context.localUtil.Format(A53PurchaseOrderModifiedDate, "99/99/99"));
         n53PurchaseOrderModifiedDate = ((DateTime.MinValue==A53PurchaseOrderModifiedDate) ? true : false);
         A67PurchaseOrderDetailsQuantity = 0;
         n67PurchaseOrderDetailsQuantity = false;
         AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
         A52PurchaseOrderCreatedDate = Gx_date;
         AssignAttri("", false, "A52PurchaseOrderCreatedDate", context.localUtil.Format(A52PurchaseOrderCreatedDate, "99/99/99"));
         O67PurchaseOrderDetailsQuantity = A67PurchaseOrderDetailsQuantity;
         n67PurchaseOrderDetailsQuantity = false;
         AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrimStr( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0));
         Z52PurchaseOrderCreatedDate = DateTime.MinValue;
         Z66PurchaseOrderClosedDate = DateTime.MinValue;
         Z53PurchaseOrderModifiedDate = DateTime.MinValue;
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
         A52PurchaseOrderCreatedDate = i52PurchaseOrderCreatedDate;
         AssignAttri("", false, "A52PurchaseOrderCreatedDate", context.localUtil.Format(A52PurchaseOrderCreatedDate, "99/99/99"));
      }

      protected void InitializeNonKey0712( )
      {
         A62PurchaseOrderDetailQuantity = 0;
         A63PurchaseOrderDetailCurrentPric = 0;
         A64PurchaseOrderDetailSuggestedPr = 0;
         A15ProductId = 0;
         A16ProductName = "";
         Z62PurchaseOrderDetailQuantity = 0;
         Z63PurchaseOrderDetailCurrentPric = 0;
         Z64PurchaseOrderDetailSuggestedPr = 0;
         Z15ProductId = 0;
      }

      protected void InitAll0712( )
      {
         A61PurchaseOrderDetailId = 0;
         InitializeNonKey0712( ) ;
      }

      protected void StandaloneModalInsert0712( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202311319533122", true, true);
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
         context.AddJavascriptSource("purchaseorder.js", "?202311319533122", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties12( )
      {
         edtPurchaseOrderDetailId_Enabled = defedtPurchaseOrderDetailId_Enabled;
         AssignProp("", false, edtPurchaseOrderDetailId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderDetailId_Enabled), 5, 0), !bGXsfl_73_Refreshing);
      }

      protected void StartGridControl73( )
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
         Gridpurchaseorder_detailColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A62PurchaseOrderDetailQuantity), 4, 0, ".", ""))));
         Gridpurchaseorder_detailColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPurchaseOrderDetailQuantity_Enabled), 5, 0, ".", "")));
         Gridpurchaseorder_detailContainer.AddColumnProperties(Gridpurchaseorder_detailColumn);
         Gridpurchaseorder_detailColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridpurchaseorder_detailColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A63PurchaseOrderDetailCurrentPric, 10, 2, ".", ""))));
         Gridpurchaseorder_detailColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPurchaseOrderDetailCurrentPric_Enabled), 5, 0, ".", "")));
         Gridpurchaseorder_detailContainer.AddColumnProperties(Gridpurchaseorder_detailColumn);
         Gridpurchaseorder_detailColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridpurchaseorder_detailColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A64PurchaseOrderDetailSuggestedPr, 10, 2, ".", ""))));
         Gridpurchaseorder_detailColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPurchaseOrderDetailSuggestedPr_Enabled), 5, 0, ".", "")));
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
         edtPurchaseOrderClosedDate_Internalname = "PURCHASEORDERCLOSEDDATE";
         edtPurchaseOrderModifiedDate_Internalname = "PURCHASEORDERMODIFIEDDATE";
         edtPurchaseOrderDetailsQuantity_Internalname = "PURCHASEORDERDETAILSQUANTITY";
         lblTitledetail_Internalname = "TITLEDETAIL";
         edtPurchaseOrderDetailId_Internalname = "PURCHASEORDERDETAILID";
         edtPurchaseOrderDetailQuantity_Internalname = "PURCHASEORDERDETAILQUANTITY";
         edtPurchaseOrderDetailCurrentPric_Internalname = "PURCHASEORDERDETAILCURRENTPRIC";
         edtPurchaseOrderDetailSuggestedPr_Internalname = "PURCHASEORDERDETAILSUGGESTEDPR";
         edtProductId_Internalname = "PRODUCTID";
         edtProductName_Internalname = "PRODUCTNAME";
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
         edtProductName_Jsonclick = "";
         imgprompt_15_Visible = 1;
         imgprompt_15_Link = "";
         imgprompt_4_Visible = 1;
         edtProductId_Jsonclick = "";
         edtPurchaseOrderDetailSuggestedPr_Jsonclick = "";
         edtPurchaseOrderDetailCurrentPric_Jsonclick = "";
         edtPurchaseOrderDetailQuantity_Jsonclick = "";
         edtPurchaseOrderDetailId_Jsonclick = "";
         subGridpurchaseorder_detail_Class = "Grid";
         subGridpurchaseorder_detail_Backcolorstyle = 0;
         edtProductName_Enabled = 0;
         edtProductId_Enabled = 1;
         edtPurchaseOrderDetailSuggestedPr_Enabled = 1;
         edtPurchaseOrderDetailCurrentPric_Enabled = 1;
         edtPurchaseOrderDetailQuantity_Enabled = 1;
         edtPurchaseOrderDetailId_Enabled = 1;
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirm";
         bttBtn_enter_Caption = "Confirm";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtPurchaseOrderDetailsQuantity_Jsonclick = "";
         edtPurchaseOrderDetailsQuantity_Enabled = 0;
         edtPurchaseOrderModifiedDate_Jsonclick = "";
         edtPurchaseOrderModifiedDate_Enabled = 1;
         edtPurchaseOrderClosedDate_Jsonclick = "";
         edtPurchaseOrderClosedDate_Enabled = 1;
         edtPurchaseOrderCreatedDate_Jsonclick = "";
         edtPurchaseOrderCreatedDate_Enabled = 0;
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
         SubsflControlProps_7312( ) ;
         while ( nGXsfl_73_idx <= nRC_GXsfl_73 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0712( ) ;
            standaloneModal0712( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0712( ) ;
            nGXsfl_73_idx = (int)(nGXsfl_73_idx+1);
            sGXsfl_73_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_73_idx), 4, 0), 4, "0");
            SubsflControlProps_7312( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridpurchaseorder_detailContainer)) ;
         /* End function gxnrGridpurchaseorder_detail_newrow */
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

      public void Valid_Purchaseorderid( )
      {
         n67PurchaseOrderDetailsQuantity = false;
         /* Using cursor T000722 */
         pr_default.execute(16, new Object[] {A50PurchaseOrderId});
         if ( (pr_default.getStatus(16) != 101) )
         {
            A67PurchaseOrderDetailsQuantity = T000722_A67PurchaseOrderDetailsQuantity[0];
            n67PurchaseOrderDetailsQuantity = T000722_n67PurchaseOrderDetailsQuantity[0];
         }
         else
         {
            A67PurchaseOrderDetailsQuantity = 0;
            n67PurchaseOrderDetailsQuantity = false;
         }
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A67PurchaseOrderDetailsQuantity", StringUtil.LTrim( StringUtil.NToC( (decimal)(A67PurchaseOrderDetailsQuantity), 4, 0, ".", "")));
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7PurchaseOrderId',fld:'vPURCHASEORDERID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7PurchaseOrderId',fld:'vPURCHASEORDERID',pic:'ZZZZZ9',hsh:true},{av:'A50PurchaseOrderId',fld:'PURCHASEORDERID',pic:'ZZZZZ9'},{av:'A52PurchaseOrderCreatedDate',fld:'PURCHASEORDERCREATEDDATE',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12072',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_PURCHASEORDERID","{handler:'Valid_Purchaseorderid',iparms:[{av:'A50PurchaseOrderId',fld:'PURCHASEORDERID',pic:'ZZZZZ9'},{av:'A67PurchaseOrderDetailsQuantity',fld:'PURCHASEORDERDETAILSQUANTITY',pic:'ZZZ9'}]");
         setEventMetadata("VALID_PURCHASEORDERID",",oparms:[{av:'A67PurchaseOrderDetailsQuantity',fld:'PURCHASEORDERDETAILSQUANTITY',pic:'ZZZ9'}]}");
         setEventMetadata("VALID_SUPPLIERID","{handler:'Valid_Supplierid',iparms:[{av:'A4SupplierId',fld:'SUPPLIERID',pic:'ZZZZZ9'},{av:'A5SupplierName',fld:'SUPPLIERNAME',pic:''}]");
         setEventMetadata("VALID_SUPPLIERID",",oparms:[{av:'A5SupplierName',fld:'SUPPLIERNAME',pic:''}]}");
         setEventMetadata("VALID_PURCHASEORDERCLOSEDDATE","{handler:'Valid_Purchaseordercloseddate',iparms:[]");
         setEventMetadata("VALID_PURCHASEORDERCLOSEDDATE",",oparms:[]}");
         setEventMetadata("VALID_PURCHASEORDERMODIFIEDDATE","{handler:'Valid_Purchaseordermodifieddate',iparms:[]");
         setEventMetadata("VALID_PURCHASEORDERMODIFIEDDATE",",oparms:[]}");
         setEventMetadata("VALID_PURCHASEORDERDETAILID","{handler:'Valid_Purchaseorderdetailid',iparms:[]");
         setEventMetadata("VALID_PURCHASEORDERDETAILID",",oparms:[]}");
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
         Z52PurchaseOrderCreatedDate = DateTime.MinValue;
         Z66PurchaseOrderClosedDate = DateTime.MinValue;
         Z53PurchaseOrderModifiedDate = DateTime.MinValue;
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
         Gx_date = DateTime.MinValue;
         AV15Pgmname = "";
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
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV12TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         Z5SupplierName = "";
         T00079_A67PurchaseOrderDetailsQuantity = new short[1] ;
         T00079_n67PurchaseOrderDetailsQuantity = new bool[] {false} ;
         T00077_A5SupplierName = new string[] {""} ;
         T000711_A50PurchaseOrderId = new int[1] ;
         T000711_A5SupplierName = new string[] {""} ;
         T000711_A52PurchaseOrderCreatedDate = new DateTime[] {DateTime.MinValue} ;
         T000711_A66PurchaseOrderClosedDate = new DateTime[] {DateTime.MinValue} ;
         T000711_n66PurchaseOrderClosedDate = new bool[] {false} ;
         T000711_A53PurchaseOrderModifiedDate = new DateTime[] {DateTime.MinValue} ;
         T000711_n53PurchaseOrderModifiedDate = new bool[] {false} ;
         T000711_A4SupplierId = new int[1] ;
         T000711_A67PurchaseOrderDetailsQuantity = new short[1] ;
         T000711_n67PurchaseOrderDetailsQuantity = new bool[] {false} ;
         T000713_A67PurchaseOrderDetailsQuantity = new short[1] ;
         T000713_n67PurchaseOrderDetailsQuantity = new bool[] {false} ;
         T000714_A5SupplierName = new string[] {""} ;
         T000715_A50PurchaseOrderId = new int[1] ;
         T00076_A50PurchaseOrderId = new int[1] ;
         T00076_A52PurchaseOrderCreatedDate = new DateTime[] {DateTime.MinValue} ;
         T00076_A66PurchaseOrderClosedDate = new DateTime[] {DateTime.MinValue} ;
         T00076_n66PurchaseOrderClosedDate = new bool[] {false} ;
         T00076_A53PurchaseOrderModifiedDate = new DateTime[] {DateTime.MinValue} ;
         T00076_n53PurchaseOrderModifiedDate = new bool[] {false} ;
         T00076_A4SupplierId = new int[1] ;
         T000716_A50PurchaseOrderId = new int[1] ;
         T000717_A50PurchaseOrderId = new int[1] ;
         T00075_A50PurchaseOrderId = new int[1] ;
         T00075_A52PurchaseOrderCreatedDate = new DateTime[] {DateTime.MinValue} ;
         T00075_A66PurchaseOrderClosedDate = new DateTime[] {DateTime.MinValue} ;
         T00075_n66PurchaseOrderClosedDate = new bool[] {false} ;
         T00075_A53PurchaseOrderModifiedDate = new DateTime[] {DateTime.MinValue} ;
         T00075_n53PurchaseOrderModifiedDate = new bool[] {false} ;
         T00075_A4SupplierId = new int[1] ;
         T000718_A50PurchaseOrderId = new int[1] ;
         T000722_A67PurchaseOrderDetailsQuantity = new short[1] ;
         T000722_n67PurchaseOrderDetailsQuantity = new bool[] {false} ;
         T000723_A5SupplierName = new string[] {""} ;
         T000724_A50PurchaseOrderId = new int[1] ;
         Z16ProductName = "";
         T000725_A50PurchaseOrderId = new int[1] ;
         T000725_A61PurchaseOrderDetailId = new int[1] ;
         T000725_A62PurchaseOrderDetailQuantity = new short[1] ;
         T000725_A63PurchaseOrderDetailCurrentPric = new decimal[1] ;
         T000725_A64PurchaseOrderDetailSuggestedPr = new decimal[1] ;
         T000725_A16ProductName = new string[] {""} ;
         T000725_A15ProductId = new int[1] ;
         T00074_A16ProductName = new string[] {""} ;
         T000726_A16ProductName = new string[] {""} ;
         T000727_A50PurchaseOrderId = new int[1] ;
         T000727_A61PurchaseOrderDetailId = new int[1] ;
         T00073_A50PurchaseOrderId = new int[1] ;
         T00073_A61PurchaseOrderDetailId = new int[1] ;
         T00073_A62PurchaseOrderDetailQuantity = new short[1] ;
         T00073_A63PurchaseOrderDetailCurrentPric = new decimal[1] ;
         T00073_A64PurchaseOrderDetailSuggestedPr = new decimal[1] ;
         T00073_A15ProductId = new int[1] ;
         T00072_A50PurchaseOrderId = new int[1] ;
         T00072_A61PurchaseOrderDetailId = new int[1] ;
         T00072_A62PurchaseOrderDetailQuantity = new short[1] ;
         T00072_A63PurchaseOrderDetailCurrentPric = new decimal[1] ;
         T00072_A64PurchaseOrderDetailSuggestedPr = new decimal[1] ;
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
         i52PurchaseOrderCreatedDate = DateTime.MinValue;
         Gridpurchaseorder_detailColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.purchaseorder__default(),
            new Object[][] {
                new Object[] {
               T00072_A50PurchaseOrderId, T00072_A61PurchaseOrderDetailId, T00072_A62PurchaseOrderDetailQuantity, T00072_A63PurchaseOrderDetailCurrentPric, T00072_A64PurchaseOrderDetailSuggestedPr, T00072_A15ProductId
               }
               , new Object[] {
               T00073_A50PurchaseOrderId, T00073_A61PurchaseOrderDetailId, T00073_A62PurchaseOrderDetailQuantity, T00073_A63PurchaseOrderDetailCurrentPric, T00073_A64PurchaseOrderDetailSuggestedPr, T00073_A15ProductId
               }
               , new Object[] {
               T00074_A16ProductName
               }
               , new Object[] {
               T00075_A50PurchaseOrderId, T00075_A52PurchaseOrderCreatedDate, T00075_A66PurchaseOrderClosedDate, T00075_n66PurchaseOrderClosedDate, T00075_A53PurchaseOrderModifiedDate, T00075_n53PurchaseOrderModifiedDate, T00075_A4SupplierId
               }
               , new Object[] {
               T00076_A50PurchaseOrderId, T00076_A52PurchaseOrderCreatedDate, T00076_A66PurchaseOrderClosedDate, T00076_n66PurchaseOrderClosedDate, T00076_A53PurchaseOrderModifiedDate, T00076_n53PurchaseOrderModifiedDate, T00076_A4SupplierId
               }
               , new Object[] {
               T00077_A5SupplierName
               }
               , new Object[] {
               T00079_A67PurchaseOrderDetailsQuantity, T00079_n67PurchaseOrderDetailsQuantity
               }
               , new Object[] {
               T000711_A50PurchaseOrderId, T000711_A5SupplierName, T000711_A52PurchaseOrderCreatedDate, T000711_A66PurchaseOrderClosedDate, T000711_n66PurchaseOrderClosedDate, T000711_A53PurchaseOrderModifiedDate, T000711_n53PurchaseOrderModifiedDate, T000711_A4SupplierId, T000711_A67PurchaseOrderDetailsQuantity, T000711_n67PurchaseOrderDetailsQuantity
               }
               , new Object[] {
               T000713_A67PurchaseOrderDetailsQuantity, T000713_n67PurchaseOrderDetailsQuantity
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
               T000722_A67PurchaseOrderDetailsQuantity, T000722_n67PurchaseOrderDetailsQuantity
               }
               , new Object[] {
               T000723_A5SupplierName
               }
               , new Object[] {
               T000724_A50PurchaseOrderId
               }
               , new Object[] {
               T000725_A50PurchaseOrderId, T000725_A61PurchaseOrderDetailId, T000725_A62PurchaseOrderDetailQuantity, T000725_A63PurchaseOrderDetailCurrentPric, T000725_A64PurchaseOrderDetailSuggestedPr, T000725_A16ProductName, T000725_A15ProductId
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
         AV15Pgmname = "PurchaseOrder";
         Z52PurchaseOrderCreatedDate = DateTime.MinValue;
         A52PurchaseOrderCreatedDate = DateTime.MinValue;
         i52PurchaseOrderCreatedDate = DateTime.MinValue;
         Gx_date = DateTimeUtil.Today( context);
      }

      private short nIsMod_12 ;
      private short O67PurchaseOrderDetailsQuantity ;
      private short Z62PurchaseOrderDetailQuantity ;
      private short nRcdDeleted_12 ;
      private short nRcdExists_12 ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A67PurchaseOrderDetailsQuantity ;
      private short nBlankRcdCount12 ;
      private short RcdFound12 ;
      private short B67PurchaseOrderDetailsQuantity ;
      private short nBlankRcdUsr12 ;
      private short Gx_BScreen ;
      private short RcdFound10 ;
      private short s67PurchaseOrderDetailsQuantity ;
      private short A62PurchaseOrderDetailQuantity ;
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
      private int wcpOAV7PurchaseOrderId ;
      private int Z50PurchaseOrderId ;
      private int Z4SupplierId ;
      private int nRC_GXsfl_73 ;
      private int nGXsfl_73_idx=1 ;
      private int N4SupplierId ;
      private int Z61PurchaseOrderDetailId ;
      private int Z15ProductId ;
      private int A50PurchaseOrderId ;
      private int A4SupplierId ;
      private int A15ProductId ;
      private int AV7PurchaseOrderId ;
      private int trnEnded ;
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
      private int edtPurchaseOrderClosedDate_Enabled ;
      private int edtPurchaseOrderModifiedDate_Enabled ;
      private int edtPurchaseOrderDetailsQuantity_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtPurchaseOrderDetailId_Enabled ;
      private int edtPurchaseOrderDetailQuantity_Enabled ;
      private int edtPurchaseOrderDetailCurrentPric_Enabled ;
      private int edtPurchaseOrderDetailSuggestedPr_Enabled ;
      private int edtProductId_Enabled ;
      private int edtProductName_Enabled ;
      private int fRowAdded ;
      private int AV11Insert_SupplierId ;
      private int A61PurchaseOrderDetailId ;
      private int AV16GXV1 ;
      private int subGridpurchaseorder_detail_Backcolor ;
      private int subGridpurchaseorder_detail_Allbackcolor ;
      private int imgprompt_15_Visible ;
      private int defedtPurchaseOrderDetailId_Enabled ;
      private int idxLst ;
      private int subGridpurchaseorder_detail_Selectedindex ;
      private int subGridpurchaseorder_detail_Selectioncolor ;
      private int subGridpurchaseorder_detail_Hoveringcolor ;
      private long GRIDPURCHASEORDER_DETAIL_nFirstRecordOnPage ;
      private decimal Z63PurchaseOrderDetailCurrentPric ;
      private decimal Z64PurchaseOrderDetailSuggestedPr ;
      private decimal A63PurchaseOrderDetailCurrentPric ;
      private decimal A64PurchaseOrderDetailSuggestedPr ;
      private string sPrefix ;
      private string sGXsfl_73_idx="0001" ;
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
      private string edtPurchaseOrderClosedDate_Internalname ;
      private string edtPurchaseOrderClosedDate_Jsonclick ;
      private string edtPurchaseOrderModifiedDate_Internalname ;
      private string edtPurchaseOrderModifiedDate_Jsonclick ;
      private string edtPurchaseOrderDetailsQuantity_Internalname ;
      private string edtPurchaseOrderDetailsQuantity_Jsonclick ;
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
      private string sMode12 ;
      private string edtPurchaseOrderDetailId_Internalname ;
      private string edtPurchaseOrderDetailQuantity_Internalname ;
      private string edtPurchaseOrderDetailCurrentPric_Internalname ;
      private string edtPurchaseOrderDetailSuggestedPr_Internalname ;
      private string edtProductId_Internalname ;
      private string edtProductName_Internalname ;
      private string sStyleString ;
      private string subGridpurchaseorder_detail_Internalname ;
      private string AV15Pgmname ;
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
      private string sGXsfl_73_fel_idx="0001" ;
      private string subGridpurchaseorder_detail_Class ;
      private string subGridpurchaseorder_detail_Linesclass ;
      private string imgprompt_15_Link ;
      private string ROClassString ;
      private string edtPurchaseOrderDetailId_Jsonclick ;
      private string edtPurchaseOrderDetailQuantity_Jsonclick ;
      private string edtPurchaseOrderDetailCurrentPric_Jsonclick ;
      private string edtPurchaseOrderDetailSuggestedPr_Jsonclick ;
      private string edtProductId_Jsonclick ;
      private string imgprompt_15_gximage ;
      private string edtProductName_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridpurchaseorder_detail_Header ;
      private DateTime Z52PurchaseOrderCreatedDate ;
      private DateTime Z66PurchaseOrderClosedDate ;
      private DateTime Z53PurchaseOrderModifiedDate ;
      private DateTime A52PurchaseOrderCreatedDate ;
      private DateTime A66PurchaseOrderClosedDate ;
      private DateTime A53PurchaseOrderModifiedDate ;
      private DateTime Gx_date ;
      private DateTime i52PurchaseOrderCreatedDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n67PurchaseOrderDetailsQuantity ;
      private bool bGXsfl_73_Refreshing=false ;
      private bool n66PurchaseOrderClosedDate ;
      private bool n53PurchaseOrderModifiedDate ;
      private bool returnInSub ;
      private string A5SupplierName ;
      private string A16ProductName ;
      private string Z5SupplierName ;
      private string Z16ProductName ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridpurchaseorder_detailContainer ;
      private GXWebRow Gridpurchaseorder_detailRow ;
      private GXWebColumn Gridpurchaseorder_detailColumn ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T00079_A67PurchaseOrderDetailsQuantity ;
      private bool[] T00079_n67PurchaseOrderDetailsQuantity ;
      private string[] T00077_A5SupplierName ;
      private int[] T000711_A50PurchaseOrderId ;
      private string[] T000711_A5SupplierName ;
      private DateTime[] T000711_A52PurchaseOrderCreatedDate ;
      private DateTime[] T000711_A66PurchaseOrderClosedDate ;
      private bool[] T000711_n66PurchaseOrderClosedDate ;
      private DateTime[] T000711_A53PurchaseOrderModifiedDate ;
      private bool[] T000711_n53PurchaseOrderModifiedDate ;
      private int[] T000711_A4SupplierId ;
      private short[] T000711_A67PurchaseOrderDetailsQuantity ;
      private bool[] T000711_n67PurchaseOrderDetailsQuantity ;
      private short[] T000713_A67PurchaseOrderDetailsQuantity ;
      private bool[] T000713_n67PurchaseOrderDetailsQuantity ;
      private string[] T000714_A5SupplierName ;
      private int[] T000715_A50PurchaseOrderId ;
      private int[] T00076_A50PurchaseOrderId ;
      private DateTime[] T00076_A52PurchaseOrderCreatedDate ;
      private DateTime[] T00076_A66PurchaseOrderClosedDate ;
      private bool[] T00076_n66PurchaseOrderClosedDate ;
      private DateTime[] T00076_A53PurchaseOrderModifiedDate ;
      private bool[] T00076_n53PurchaseOrderModifiedDate ;
      private int[] T00076_A4SupplierId ;
      private int[] T000716_A50PurchaseOrderId ;
      private int[] T000717_A50PurchaseOrderId ;
      private int[] T00075_A50PurchaseOrderId ;
      private DateTime[] T00075_A52PurchaseOrderCreatedDate ;
      private DateTime[] T00075_A66PurchaseOrderClosedDate ;
      private bool[] T00075_n66PurchaseOrderClosedDate ;
      private DateTime[] T00075_A53PurchaseOrderModifiedDate ;
      private bool[] T00075_n53PurchaseOrderModifiedDate ;
      private int[] T00075_A4SupplierId ;
      private int[] T000718_A50PurchaseOrderId ;
      private short[] T000722_A67PurchaseOrderDetailsQuantity ;
      private bool[] T000722_n67PurchaseOrderDetailsQuantity ;
      private string[] T000723_A5SupplierName ;
      private int[] T000724_A50PurchaseOrderId ;
      private int[] T000725_A50PurchaseOrderId ;
      private int[] T000725_A61PurchaseOrderDetailId ;
      private short[] T000725_A62PurchaseOrderDetailQuantity ;
      private decimal[] T000725_A63PurchaseOrderDetailCurrentPric ;
      private decimal[] T000725_A64PurchaseOrderDetailSuggestedPr ;
      private string[] T000725_A16ProductName ;
      private int[] T000725_A15ProductId ;
      private string[] T00074_A16ProductName ;
      private string[] T000726_A16ProductName ;
      private int[] T000727_A50PurchaseOrderId ;
      private int[] T000727_A61PurchaseOrderDetailId ;
      private int[] T00073_A50PurchaseOrderId ;
      private int[] T00073_A61PurchaseOrderDetailId ;
      private short[] T00073_A62PurchaseOrderDetailQuantity ;
      private decimal[] T00073_A63PurchaseOrderDetailCurrentPric ;
      private decimal[] T00073_A64PurchaseOrderDetailSuggestedPr ;
      private int[] T00073_A15ProductId ;
      private int[] T00072_A50PurchaseOrderId ;
      private int[] T00072_A61PurchaseOrderDetailId ;
      private short[] T00072_A62PurchaseOrderDetailQuantity ;
      private decimal[] T00072_A63PurchaseOrderDetailCurrentPric ;
      private decimal[] T00072_A64PurchaseOrderDetailSuggestedPr ;
      private int[] T00072_A15ProductId ;
      private string[] T000731_A16ProductName ;
      private int[] T000732_A50PurchaseOrderId ;
      private int[] T000732_A61PurchaseOrderDetailId ;
      private GXWebForm Form ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV12TrnContextAtt ;
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
          Object[] prmT00079;
          prmT00079 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmT00077;
          prmT00077 = new Object[] {
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
          Object[] prmT00076;
          prmT00076 = new Object[] {
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
          Object[] prmT00075;
          prmT00075 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmT000718;
          prmT000718 = new Object[] {
          new ParDef("@PurchaseOrderCreatedDate",GXType.Date,8,0) ,
          new ParDef("@PurchaseOrderClosedDate",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@PurchaseOrderModifiedDate",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          Object[] prmT000719;
          prmT000719 = new Object[] {
          new ParDef("@PurchaseOrderCreatedDate",GXType.Date,8,0) ,
          new ParDef("@PurchaseOrderClosedDate",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@PurchaseOrderModifiedDate",GXType.Date,8,0){Nullable=true} ,
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
          new ParDef("@PurchaseOrderDetailQuantity",GXType.Int16,4,0) ,
          new ParDef("@PurchaseOrderDetailCurrentPric",GXType.Decimal,10,2) ,
          new ParDef("@PurchaseOrderDetailSuggestedPr",GXType.Decimal,10,2) ,
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmT000729;
          prmT000729 = new Object[] {
          new ParDef("@PurchaseOrderDetailQuantity",GXType.Int16,4,0) ,
          new ParDef("@PurchaseOrderDetailCurrentPric",GXType.Decimal,10,2) ,
          new ParDef("@PurchaseOrderDetailSuggestedPr",GXType.Decimal,10,2) ,
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
              new CursorDef("T00072", "SELECT [PurchaseOrderId], [PurchaseOrderDetailId], [PurchaseOrderDetailQuantity], [PurchaseOrderDetailCurrentPric], [PurchaseOrderDetailSuggestedPr], [ProductId] FROM [PurchaseOrderDetail] WITH (UPDLOCK) WHERE [PurchaseOrderId] = @PurchaseOrderId AND [PurchaseOrderDetailId] = @PurchaseOrderDetailId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00072,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00073", "SELECT [PurchaseOrderId], [PurchaseOrderDetailId], [PurchaseOrderDetailQuantity], [PurchaseOrderDetailCurrentPric], [PurchaseOrderDetailSuggestedPr], [ProductId] FROM [PurchaseOrderDetail] WHERE [PurchaseOrderId] = @PurchaseOrderId AND [PurchaseOrderDetailId] = @PurchaseOrderDetailId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00073,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00074", "SELECT [ProductName] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00074,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00075", "SELECT [PurchaseOrderId], [PurchaseOrderCreatedDate], [PurchaseOrderClosedDate], [PurchaseOrderModifiedDate], [SupplierId] FROM [PurchaseOrder] WITH (UPDLOCK) WHERE [PurchaseOrderId] = @PurchaseOrderId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00075,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00076", "SELECT [PurchaseOrderId], [PurchaseOrderCreatedDate], [PurchaseOrderClosedDate], [PurchaseOrderModifiedDate], [SupplierId] FROM [PurchaseOrder] WHERE [PurchaseOrderId] = @PurchaseOrderId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00076,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00077", "SELECT [SupplierName] FROM [Supplier] WHERE [SupplierId] = @SupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00077,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00079", "SELECT COALESCE( T1.[PurchaseOrderDetailsQuantity], 0) AS PurchaseOrderDetailsQuantity FROM (SELECT COUNT(*) AS PurchaseOrderDetailsQuantity, [PurchaseOrderId] FROM [PurchaseOrderDetail] WITH (UPDLOCK) GROUP BY [PurchaseOrderId] ) T1 WHERE T1.[PurchaseOrderId] = @PurchaseOrderId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00079,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000711", "SELECT TM1.[PurchaseOrderId], T3.[SupplierName], TM1.[PurchaseOrderCreatedDate], TM1.[PurchaseOrderClosedDate], TM1.[PurchaseOrderModifiedDate], TM1.[SupplierId], COALESCE( T2.[PurchaseOrderDetailsQuantity], 0) AS PurchaseOrderDetailsQuantity FROM (([PurchaseOrder] TM1 LEFT JOIN (SELECT COUNT(*) AS PurchaseOrderDetailsQuantity, [PurchaseOrderId] FROM [PurchaseOrderDetail] GROUP BY [PurchaseOrderId] ) T2 ON T2.[PurchaseOrderId] = TM1.[PurchaseOrderId]) INNER JOIN [Supplier] T3 ON T3.[SupplierId] = TM1.[SupplierId]) WHERE TM1.[PurchaseOrderId] = @PurchaseOrderId ORDER BY TM1.[PurchaseOrderId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000711,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000713", "SELECT COALESCE( T1.[PurchaseOrderDetailsQuantity], 0) AS PurchaseOrderDetailsQuantity FROM (SELECT COUNT(*) AS PurchaseOrderDetailsQuantity, [PurchaseOrderId] FROM [PurchaseOrderDetail] WITH (UPDLOCK) GROUP BY [PurchaseOrderId] ) T1 WHERE T1.[PurchaseOrderId] = @PurchaseOrderId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000713,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000714", "SELECT [SupplierName] FROM [Supplier] WHERE [SupplierId] = @SupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000714,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000715", "SELECT [PurchaseOrderId] FROM [PurchaseOrder] WHERE [PurchaseOrderId] = @PurchaseOrderId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000715,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000716", "SELECT TOP 1 [PurchaseOrderId] FROM [PurchaseOrder] WHERE ( [PurchaseOrderId] > @PurchaseOrderId) ORDER BY [PurchaseOrderId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000716,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000717", "SELECT TOP 1 [PurchaseOrderId] FROM [PurchaseOrder] WHERE ( [PurchaseOrderId] < @PurchaseOrderId) ORDER BY [PurchaseOrderId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000717,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000718", "INSERT INTO [PurchaseOrder]([PurchaseOrderCreatedDate], [PurchaseOrderClosedDate], [PurchaseOrderModifiedDate], [SupplierId]) VALUES(@PurchaseOrderCreatedDate, @PurchaseOrderClosedDate, @PurchaseOrderModifiedDate, @SupplierId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000718,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000719", "UPDATE [PurchaseOrder] SET [PurchaseOrderCreatedDate]=@PurchaseOrderCreatedDate, [PurchaseOrderClosedDate]=@PurchaseOrderClosedDate, [PurchaseOrderModifiedDate]=@PurchaseOrderModifiedDate, [SupplierId]=@SupplierId  WHERE [PurchaseOrderId] = @PurchaseOrderId", GxErrorMask.GX_NOMASK,prmT000719)
             ,new CursorDef("T000720", "DELETE FROM [PurchaseOrder]  WHERE [PurchaseOrderId] = @PurchaseOrderId", GxErrorMask.GX_NOMASK,prmT000720)
             ,new CursorDef("T000722", "SELECT COALESCE( T1.[PurchaseOrderDetailsQuantity], 0) AS PurchaseOrderDetailsQuantity FROM (SELECT COUNT(*) AS PurchaseOrderDetailsQuantity, [PurchaseOrderId] FROM [PurchaseOrderDetail] WITH (UPDLOCK) GROUP BY [PurchaseOrderId] ) T1 WHERE T1.[PurchaseOrderId] = @PurchaseOrderId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000722,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000723", "SELECT [SupplierName] FROM [Supplier] WHERE [SupplierId] = @SupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000723,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000724", "SELECT [PurchaseOrderId] FROM [PurchaseOrder] ORDER BY [PurchaseOrderId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000724,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000725", "SELECT T1.[PurchaseOrderId], T1.[PurchaseOrderDetailId], T1.[PurchaseOrderDetailQuantity], T1.[PurchaseOrderDetailCurrentPric], T1.[PurchaseOrderDetailSuggestedPr], T2.[ProductName], T1.[ProductId] FROM ([PurchaseOrderDetail] T1 INNER JOIN [Product] T2 ON T2.[ProductId] = T1.[ProductId]) WHERE T1.[PurchaseOrderId] = @PurchaseOrderId and T1.[PurchaseOrderDetailId] = @PurchaseOrderDetailId ORDER BY T1.[PurchaseOrderId], T1.[PurchaseOrderDetailId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000725,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000726", "SELECT [ProductName] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000726,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000727", "SELECT [PurchaseOrderId], [PurchaseOrderDetailId] FROM [PurchaseOrderDetail] WHERE [PurchaseOrderId] = @PurchaseOrderId AND [PurchaseOrderDetailId] = @PurchaseOrderDetailId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000727,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000728", "INSERT INTO [PurchaseOrderDetail]([PurchaseOrderId], [PurchaseOrderDetailId], [PurchaseOrderDetailQuantity], [PurchaseOrderDetailCurrentPric], [PurchaseOrderDetailSuggestedPr], [ProductId]) VALUES(@PurchaseOrderId, @PurchaseOrderDetailId, @PurchaseOrderDetailQuantity, @PurchaseOrderDetailCurrentPric, @PurchaseOrderDetailSuggestedPr, @ProductId)", GxErrorMask.GX_NOMASK,prmT000728)
             ,new CursorDef("T000729", "UPDATE [PurchaseOrderDetail] SET [PurchaseOrderDetailQuantity]=@PurchaseOrderDetailQuantity, [PurchaseOrderDetailCurrentPric]=@PurchaseOrderDetailCurrentPric, [PurchaseOrderDetailSuggestedPr]=@PurchaseOrderDetailSuggestedPr, [ProductId]=@ProductId  WHERE [PurchaseOrderId] = @PurchaseOrderId AND [PurchaseOrderDetailId] = @PurchaseOrderDetailId", GxErrorMask.GX_NOMASK,prmT000729)
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
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((int[]) buf[6])[0] = rslt.getInt(5);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((int[]) buf[6])[0] = rslt.getInt(5);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((int[]) buf[7])[0] = rslt.getInt(6);
                ((short[]) buf[8])[0] = rslt.getShort(7);
                ((bool[]) buf[9])[0] = rslt.wasNull(7);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
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
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
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
