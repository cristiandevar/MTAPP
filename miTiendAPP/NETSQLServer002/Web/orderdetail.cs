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
   public class orderdetail : GXDataArea
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
            A15ProductId = (int)(Math.Round(NumberUtil.Val( GetPar( "ProductId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A15ProductId", StringUtil.LTrimStr( (decimal)(A15ProductId), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_14( A15ProductId) ;
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
               AV7OrderDetailId = (int)(Math.Round(NumberUtil.Val( GetPar( "OrderDetailId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7OrderDetailId", StringUtil.LTrimStr( (decimal)(AV7OrderDetailId), 6, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vORDERDETAILID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7OrderDetailId), "ZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Order Detail", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPurchaseOrderId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("mtaKB", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public orderdetail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public orderdetail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_OrderDetailId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7OrderDetailId = aP1_OrderDetailId;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Order Detail", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_OrderDetail.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_OrderDetail.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_OrderDetail.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_OrderDetail.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_OrderDetail.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_OrderDetail.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtOrderDetailId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOrderDetailId_Internalname, "Detail Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtOrderDetailId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A44OrderDetailId), 6, 0, ".", "")), StringUtil.LTrim( ((edtOrderDetailId_Enabled!=0) ? context.localUtil.Format( (decimal)(A44OrderDetailId), "ZZZZZ9") : context.localUtil.Format( (decimal)(A44OrderDetailId), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrderDetailId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrderDetailId_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_OrderDetail.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPurchaseOrderId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPurchaseOrderId_Internalname, "Purchase Order Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPurchaseOrderId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A50PurchaseOrderId), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A50PurchaseOrderId), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPurchaseOrderId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPurchaseOrderId_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_OrderDetail.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_50_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_50_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_50_Internalname, sImgUrl, imgprompt_50_Link, "", "", context.GetTheme( ), imgprompt_50_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_OrderDetail.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductId_Internalname, "Product Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A15ProductId), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductId_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_OrderDetail.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_15_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_15_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_15_Internalname, sImgUrl, imgprompt_15_Link, "", "", context.GetTheme( ), imgprompt_15_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_OrderDetail.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtOrderDetailQuantity_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOrderDetailQuantity_Internalname, "Detail Quantity", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrderDetailQuantity_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A45OrderDetailQuantity), 6, 0, ".", "")), StringUtil.LTrim( ((edtOrderDetailQuantity_Enabled!=0) ? context.localUtil.Format( (decimal)(A45OrderDetailQuantity), "ZZZZZ9") : context.localUtil.Format( (decimal)(A45OrderDetailQuantity), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrderDetailQuantity_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrderDetailQuantity_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_OrderDetail.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtOrderDetailCurrentPrice_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOrderDetailCurrentPrice_Internalname, "Current Price", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrderDetailCurrentPrice_Internalname, StringUtil.LTrim( StringUtil.NToC( A46OrderDetailCurrentPrice, 10, 2, ".", "")), StringUtil.LTrim( ((edtOrderDetailCurrentPrice_Enabled!=0) ? context.localUtil.Format( A46OrderDetailCurrentPrice, "ZZZZZZ9.99") : context.localUtil.Format( A46OrderDetailCurrentPrice, "ZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrderDetailCurrentPrice_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrderDetailCurrentPrice_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "Price", "right", false, "", "HLP_OrderDetail.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtOrderDetailSuggestedPrice_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOrderDetailSuggestedPrice_Internalname, "Suggested Price", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrderDetailSuggestedPrice_Internalname, StringUtil.LTrim( StringUtil.NToC( A47OrderDetailSuggestedPrice, 10, 2, ".", "")), StringUtil.LTrim( ((edtOrderDetailSuggestedPrice_Enabled!=0) ? context.localUtil.Format( A47OrderDetailSuggestedPrice, "ZZZZZZ9.99") : context.localUtil.Format( A47OrderDetailSuggestedPrice, "ZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrderDetailSuggestedPrice_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrderDetailSuggestedPrice_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "Price", "right", false, "", "HLP_OrderDetail.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtOrderDetailCreatedDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOrderDetailCreatedDate_Internalname, "Created Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtOrderDetailCreatedDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtOrderDetailCreatedDate_Internalname, context.localUtil.Format(A48OrderDetailCreatedDate, "99/99/99"), context.localUtil.Format( A48OrderDetailCreatedDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrderDetailCreatedDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrderDetailCreatedDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_OrderDetail.htm");
         GxWebStd.gx_bitmap( context, edtOrderDetailCreatedDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtOrderDetailCreatedDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_OrderDetail.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtOrderDetailModifiedDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOrderDetailModifiedDate_Internalname, "Modified Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtOrderDetailModifiedDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtOrderDetailModifiedDate_Internalname, context.localUtil.Format(A49OrderDetailModifiedDate, "99/99/99"), context.localUtil.Format( A49OrderDetailModifiedDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrderDetailModifiedDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrderDetailModifiedDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_OrderDetail.htm");
         GxWebStd.gx_bitmap( context, edtOrderDetailModifiedDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtOrderDetailModifiedDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_OrderDetail.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_OrderDetail.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_OrderDetail.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_OrderDetail.htm");
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
         E11092 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z44OrderDetailId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z44OrderDetailId"), ".", ","), 18, MidpointRounding.ToEven));
               Z45OrderDetailQuantity = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z45OrderDetailQuantity"), ".", ","), 18, MidpointRounding.ToEven));
               Z46OrderDetailCurrentPrice = context.localUtil.CToN( cgiGet( "Z46OrderDetailCurrentPrice"), ".", ",");
               Z47OrderDetailSuggestedPrice = context.localUtil.CToN( cgiGet( "Z47OrderDetailSuggestedPrice"), ".", ",");
               n47OrderDetailSuggestedPrice = ((Convert.ToDecimal(0)==A47OrderDetailSuggestedPrice) ? true : false);
               Z48OrderDetailCreatedDate = context.localUtil.CToD( cgiGet( "Z48OrderDetailCreatedDate"), 0);
               Z49OrderDetailModifiedDate = context.localUtil.CToD( cgiGet( "Z49OrderDetailModifiedDate"), 0);
               n49OrderDetailModifiedDate = ((DateTime.MinValue==A49OrderDetailModifiedDate) ? true : false);
               Z15ProductId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z15ProductId"), ".", ","), 18, MidpointRounding.ToEven));
               Z50PurchaseOrderId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z50PurchaseOrderId"), ".", ","), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N50PurchaseOrderId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N50PurchaseOrderId"), ".", ","), 18, MidpointRounding.ToEven));
               N15ProductId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N15ProductId"), ".", ","), 18, MidpointRounding.ToEven));
               AV7OrderDetailId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vORDERDETAILID"), ".", ","), 18, MidpointRounding.ToEven));
               AV11Insert_PurchaseOrderId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_PURCHASEORDERID"), ".", ","), 18, MidpointRounding.ToEven));
               AV12Insert_ProductId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_PRODUCTID"), ".", ","), 18, MidpointRounding.ToEven));
               AV14Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A44OrderDetailId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtOrderDetailId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A44OrderDetailId", StringUtil.LTrimStr( (decimal)(A44OrderDetailId), 6, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtPurchaseOrderId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPurchaseOrderId_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PURCHASEORDERID");
                  AnyError = 1;
                  GX_FocusControl = edtPurchaseOrderId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A50PurchaseOrderId = 0;
                  AssignAttri("", false, "A50PurchaseOrderId", StringUtil.LTrimStr( (decimal)(A50PurchaseOrderId), 6, 0));
               }
               else
               {
                  A50PurchaseOrderId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPurchaseOrderId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A50PurchaseOrderId", StringUtil.LTrimStr( (decimal)(A50PurchaseOrderId), 6, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtProductId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProductId_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODUCTID");
                  AnyError = 1;
                  GX_FocusControl = edtProductId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A15ProductId = 0;
                  AssignAttri("", false, "A15ProductId", StringUtil.LTrimStr( (decimal)(A15ProductId), 6, 0));
               }
               else
               {
                  A15ProductId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtProductId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A15ProductId", StringUtil.LTrimStr( (decimal)(A15ProductId), 6, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtOrderDetailQuantity_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOrderDetailQuantity_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ORDERDETAILQUANTITY");
                  AnyError = 1;
                  GX_FocusControl = edtOrderDetailQuantity_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A45OrderDetailQuantity = 0;
                  AssignAttri("", false, "A45OrderDetailQuantity", StringUtil.LTrimStr( (decimal)(A45OrderDetailQuantity), 6, 0));
               }
               else
               {
                  A45OrderDetailQuantity = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtOrderDetailQuantity_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A45OrderDetailQuantity", StringUtil.LTrimStr( (decimal)(A45OrderDetailQuantity), 6, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtOrderDetailCurrentPrice_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOrderDetailCurrentPrice_Internalname), ".", ",") > 9999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ORDERDETAILCURRENTPRICE");
                  AnyError = 1;
                  GX_FocusControl = edtOrderDetailCurrentPrice_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A46OrderDetailCurrentPrice = 0;
                  AssignAttri("", false, "A46OrderDetailCurrentPrice", StringUtil.LTrimStr( A46OrderDetailCurrentPrice, 10, 2));
               }
               else
               {
                  A46OrderDetailCurrentPrice = context.localUtil.CToN( cgiGet( edtOrderDetailCurrentPrice_Internalname), ".", ",");
                  AssignAttri("", false, "A46OrderDetailCurrentPrice", StringUtil.LTrimStr( A46OrderDetailCurrentPrice, 10, 2));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtOrderDetailSuggestedPrice_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOrderDetailSuggestedPrice_Internalname), ".", ",") > 9999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ORDERDETAILSUGGESTEDPRICE");
                  AnyError = 1;
                  GX_FocusControl = edtOrderDetailSuggestedPrice_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A47OrderDetailSuggestedPrice = 0;
                  n47OrderDetailSuggestedPrice = false;
                  AssignAttri("", false, "A47OrderDetailSuggestedPrice", StringUtil.LTrimStr( A47OrderDetailSuggestedPrice, 10, 2));
               }
               else
               {
                  A47OrderDetailSuggestedPrice = context.localUtil.CToN( cgiGet( edtOrderDetailSuggestedPrice_Internalname), ".", ",");
                  n47OrderDetailSuggestedPrice = false;
                  AssignAttri("", false, "A47OrderDetailSuggestedPrice", StringUtil.LTrimStr( A47OrderDetailSuggestedPrice, 10, 2));
               }
               n47OrderDetailSuggestedPrice = ((Convert.ToDecimal(0)==A47OrderDetailSuggestedPrice) ? true : false);
               if ( context.localUtil.VCDate( cgiGet( edtOrderDetailCreatedDate_Internalname), 1) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Order Detail Created Date"}), 1, "ORDERDETAILCREATEDDATE");
                  AnyError = 1;
                  GX_FocusControl = edtOrderDetailCreatedDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A48OrderDetailCreatedDate = DateTime.MinValue;
                  AssignAttri("", false, "A48OrderDetailCreatedDate", context.localUtil.Format(A48OrderDetailCreatedDate, "99/99/99"));
               }
               else
               {
                  A48OrderDetailCreatedDate = context.localUtil.CToD( cgiGet( edtOrderDetailCreatedDate_Internalname), 1);
                  AssignAttri("", false, "A48OrderDetailCreatedDate", context.localUtil.Format(A48OrderDetailCreatedDate, "99/99/99"));
               }
               if ( context.localUtil.VCDate( cgiGet( edtOrderDetailModifiedDate_Internalname), 1) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Order Detail Modified Date"}), 1, "ORDERDETAILMODIFIEDDATE");
                  AnyError = 1;
                  GX_FocusControl = edtOrderDetailModifiedDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A49OrderDetailModifiedDate = DateTime.MinValue;
                  n49OrderDetailModifiedDate = false;
                  AssignAttri("", false, "A49OrderDetailModifiedDate", context.localUtil.Format(A49OrderDetailModifiedDate, "99/99/99"));
               }
               else
               {
                  A49OrderDetailModifiedDate = context.localUtil.CToD( cgiGet( edtOrderDetailModifiedDate_Internalname), 1);
                  n49OrderDetailModifiedDate = false;
                  AssignAttri("", false, "A49OrderDetailModifiedDate", context.localUtil.Format(A49OrderDetailModifiedDate, "99/99/99"));
               }
               n49OrderDetailModifiedDate = ((DateTime.MinValue==A49OrderDetailModifiedDate) ? true : false);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"OrderDetail");
               A44OrderDetailId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtOrderDetailId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A44OrderDetailId", StringUtil.LTrimStr( (decimal)(A44OrderDetailId), 6, 0));
               forbiddenHiddens.Add("OrderDetailId", context.localUtil.Format( (decimal)(A44OrderDetailId), "ZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A44OrderDetailId != Z44OrderDetailId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("orderdetail:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A44OrderDetailId = (int)(Math.Round(NumberUtil.Val( GetPar( "OrderDetailId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A44OrderDetailId", StringUtil.LTrimStr( (decimal)(A44OrderDetailId), 6, 0));
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
                     sMode9 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode9;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound9 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_090( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "ORDERDETAILID");
                        AnyError = 1;
                        GX_FocusControl = edtOrderDetailId_Internalname;
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
                           E11092 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12092 ();
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
            E12092 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll099( ) ;
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
            DisableAttributes099( ) ;
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

      protected void CONFIRM_090( )
      {
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls099( ) ;
            }
            else
            {
               CheckExtendedTable099( ) ;
               CloseExtendedTableCursors099( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption090( )
      {
      }

      protected void E11092( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV14Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV14Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         AV11Insert_PurchaseOrderId = 0;
         AssignAttri("", false, "AV11Insert_PurchaseOrderId", StringUtil.LTrimStr( (decimal)(AV11Insert_PurchaseOrderId), 6, 0));
         AV12Insert_ProductId = 0;
         AssignAttri("", false, "AV12Insert_ProductId", StringUtil.LTrimStr( (decimal)(AV12Insert_ProductId), 6, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV14Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV15GXV1 = 1;
            AssignAttri("", false, "AV15GXV1", StringUtil.LTrimStr( (decimal)(AV15GXV1), 8, 0));
            while ( AV15GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((GeneXus.Programs.general.ui.SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV15GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "PurchaseOrderId") == 0 )
               {
                  AV11Insert_PurchaseOrderId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_PurchaseOrderId", StringUtil.LTrimStr( (decimal)(AV11Insert_PurchaseOrderId), 6, 0));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "ProductId") == 0 )
               {
                  AV12Insert_ProductId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV12Insert_ProductId", StringUtil.LTrimStr( (decimal)(AV12Insert_ProductId), 6, 0));
               }
               AV15GXV1 = (int)(AV15GXV1+1);
               AssignAttri("", false, "AV15GXV1", StringUtil.LTrimStr( (decimal)(AV15GXV1), 8, 0));
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

      protected void E12092( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wworderdetail.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM099( short GX_JID )
      {
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z45OrderDetailQuantity = T00093_A45OrderDetailQuantity[0];
               Z46OrderDetailCurrentPrice = T00093_A46OrderDetailCurrentPrice[0];
               Z47OrderDetailSuggestedPrice = T00093_A47OrderDetailSuggestedPrice[0];
               Z48OrderDetailCreatedDate = T00093_A48OrderDetailCreatedDate[0];
               Z49OrderDetailModifiedDate = T00093_A49OrderDetailModifiedDate[0];
               Z15ProductId = T00093_A15ProductId[0];
               Z50PurchaseOrderId = T00093_A50PurchaseOrderId[0];
            }
            else
            {
               Z45OrderDetailQuantity = A45OrderDetailQuantity;
               Z46OrderDetailCurrentPrice = A46OrderDetailCurrentPrice;
               Z47OrderDetailSuggestedPrice = A47OrderDetailSuggestedPrice;
               Z48OrderDetailCreatedDate = A48OrderDetailCreatedDate;
               Z49OrderDetailModifiedDate = A49OrderDetailModifiedDate;
               Z15ProductId = A15ProductId;
               Z50PurchaseOrderId = A50PurchaseOrderId;
            }
         }
         if ( GX_JID == -13 )
         {
            Z44OrderDetailId = A44OrderDetailId;
            Z45OrderDetailQuantity = A45OrderDetailQuantity;
            Z46OrderDetailCurrentPrice = A46OrderDetailCurrentPrice;
            Z47OrderDetailSuggestedPrice = A47OrderDetailSuggestedPrice;
            Z48OrderDetailCreatedDate = A48OrderDetailCreatedDate;
            Z49OrderDetailModifiedDate = A49OrderDetailModifiedDate;
            Z15ProductId = A15ProductId;
            Z50PurchaseOrderId = A50PurchaseOrderId;
         }
      }

      protected void standaloneNotModal( )
      {
         edtOrderDetailId_Enabled = 0;
         AssignProp("", false, edtOrderDetailId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrderDetailId_Enabled), 5, 0), true);
         imgprompt_50_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx00a0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PURCHASEORDERID"+"'), id:'"+"PURCHASEORDERID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_15_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0050.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PRODUCTID"+"'), id:'"+"PRODUCTID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtOrderDetailId_Enabled = 0;
         AssignProp("", false, edtOrderDetailId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrderDetailId_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7OrderDetailId) )
         {
            A44OrderDetailId = AV7OrderDetailId;
            AssignAttri("", false, "A44OrderDetailId", StringUtil.LTrimStr( (decimal)(A44OrderDetailId), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_PurchaseOrderId) )
         {
            edtPurchaseOrderId_Enabled = 0;
            AssignProp("", false, edtPurchaseOrderId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderId_Enabled), 5, 0), true);
         }
         else
         {
            edtPurchaseOrderId_Enabled = 1;
            AssignProp("", false, edtPurchaseOrderId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_ProductId) )
         {
            edtProductId_Enabled = 0;
            AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), true);
         }
         else
         {
            edtProductId_Enabled = 1;
            AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_ProductId) )
         {
            A15ProductId = AV12Insert_ProductId;
            AssignAttri("", false, "A15ProductId", StringUtil.LTrimStr( (decimal)(A15ProductId), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_PurchaseOrderId) )
         {
            A50PurchaseOrderId = AV11Insert_PurchaseOrderId;
            AssignAttri("", false, "A50PurchaseOrderId", StringUtil.LTrimStr( (decimal)(A50PurchaseOrderId), 6, 0));
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV14Pgmname = "OrderDetail";
            AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
         }
      }

      protected void Load099( )
      {
         /* Using cursor T00096 */
         pr_default.execute(4, new Object[] {A44OrderDetailId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound9 = 1;
            A45OrderDetailQuantity = T00096_A45OrderDetailQuantity[0];
            AssignAttri("", false, "A45OrderDetailQuantity", StringUtil.LTrimStr( (decimal)(A45OrderDetailQuantity), 6, 0));
            A46OrderDetailCurrentPrice = T00096_A46OrderDetailCurrentPrice[0];
            AssignAttri("", false, "A46OrderDetailCurrentPrice", StringUtil.LTrimStr( A46OrderDetailCurrentPrice, 10, 2));
            A47OrderDetailSuggestedPrice = T00096_A47OrderDetailSuggestedPrice[0];
            n47OrderDetailSuggestedPrice = T00096_n47OrderDetailSuggestedPrice[0];
            AssignAttri("", false, "A47OrderDetailSuggestedPrice", StringUtil.LTrimStr( A47OrderDetailSuggestedPrice, 10, 2));
            A48OrderDetailCreatedDate = T00096_A48OrderDetailCreatedDate[0];
            AssignAttri("", false, "A48OrderDetailCreatedDate", context.localUtil.Format(A48OrderDetailCreatedDate, "99/99/99"));
            A49OrderDetailModifiedDate = T00096_A49OrderDetailModifiedDate[0];
            n49OrderDetailModifiedDate = T00096_n49OrderDetailModifiedDate[0];
            AssignAttri("", false, "A49OrderDetailModifiedDate", context.localUtil.Format(A49OrderDetailModifiedDate, "99/99/99"));
            A15ProductId = T00096_A15ProductId[0];
            AssignAttri("", false, "A15ProductId", StringUtil.LTrimStr( (decimal)(A15ProductId), 6, 0));
            A50PurchaseOrderId = T00096_A50PurchaseOrderId[0];
            AssignAttri("", false, "A50PurchaseOrderId", StringUtil.LTrimStr( (decimal)(A50PurchaseOrderId), 6, 0));
            ZM099( -13) ;
         }
         pr_default.close(4);
         OnLoadActions099( ) ;
      }

      protected void OnLoadActions099( )
      {
         AV14Pgmname = "OrderDetail";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
      }

      protected void CheckExtendedTable099( )
      {
         nIsDirty_9 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV14Pgmname = "OrderDetail";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
         /* Using cursor T00095 */
         pr_default.execute(3, new Object[] {A50PurchaseOrderId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No matching 'Purchase Order'.", "ForeignKeyNotFound", 1, "PURCHASEORDERID");
            AnyError = 1;
            GX_FocusControl = edtPurchaseOrderId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         /* Using cursor T00094 */
         pr_default.execute(2, new Object[] {A15ProductId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'Product'.", "ForeignKeyNotFound", 1, "PRODUCTID");
            AnyError = 1;
            GX_FocusControl = edtProductId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         if ( ! ( (DateTime.MinValue==A48OrderDetailCreatedDate) || ( DateTimeUtil.ResetTime ( A48OrderDetailCreatedDate ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Order Detail Created Date is out of range", "OutOfRange", 1, "ORDERDETAILCREATEDDATE");
            AnyError = 1;
            GX_FocusControl = edtOrderDetailCreatedDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A49OrderDetailModifiedDate) || ( DateTimeUtil.ResetTime ( A49OrderDetailModifiedDate ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Order Detail Modified Date is out of range", "OutOfRange", 1, "ORDERDETAILMODIFIEDDATE");
            AnyError = 1;
            GX_FocusControl = edtOrderDetailModifiedDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors099( )
      {
         pr_default.close(3);
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_15( int A50PurchaseOrderId )
      {
         /* Using cursor T00097 */
         pr_default.execute(5, new Object[] {A50PurchaseOrderId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No matching 'Purchase Order'.", "ForeignKeyNotFound", 1, "PURCHASEORDERID");
            AnyError = 1;
            GX_FocusControl = edtPurchaseOrderId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_14( int A15ProductId )
      {
         /* Using cursor T00098 */
         pr_default.execute(6, new Object[] {A15ProductId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No matching 'Product'.", "ForeignKeyNotFound", 1, "PRODUCTID");
            AnyError = 1;
            GX_FocusControl = edtProductId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey099( )
      {
         /* Using cursor T00099 */
         pr_default.execute(7, new Object[] {A44OrderDetailId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound9 = 1;
         }
         else
         {
            RcdFound9 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00093 */
         pr_default.execute(1, new Object[] {A44OrderDetailId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM099( 13) ;
            RcdFound9 = 1;
            A44OrderDetailId = T00093_A44OrderDetailId[0];
            AssignAttri("", false, "A44OrderDetailId", StringUtil.LTrimStr( (decimal)(A44OrderDetailId), 6, 0));
            A45OrderDetailQuantity = T00093_A45OrderDetailQuantity[0];
            AssignAttri("", false, "A45OrderDetailQuantity", StringUtil.LTrimStr( (decimal)(A45OrderDetailQuantity), 6, 0));
            A46OrderDetailCurrentPrice = T00093_A46OrderDetailCurrentPrice[0];
            AssignAttri("", false, "A46OrderDetailCurrentPrice", StringUtil.LTrimStr( A46OrderDetailCurrentPrice, 10, 2));
            A47OrderDetailSuggestedPrice = T00093_A47OrderDetailSuggestedPrice[0];
            n47OrderDetailSuggestedPrice = T00093_n47OrderDetailSuggestedPrice[0];
            AssignAttri("", false, "A47OrderDetailSuggestedPrice", StringUtil.LTrimStr( A47OrderDetailSuggestedPrice, 10, 2));
            A48OrderDetailCreatedDate = T00093_A48OrderDetailCreatedDate[0];
            AssignAttri("", false, "A48OrderDetailCreatedDate", context.localUtil.Format(A48OrderDetailCreatedDate, "99/99/99"));
            A49OrderDetailModifiedDate = T00093_A49OrderDetailModifiedDate[0];
            n49OrderDetailModifiedDate = T00093_n49OrderDetailModifiedDate[0];
            AssignAttri("", false, "A49OrderDetailModifiedDate", context.localUtil.Format(A49OrderDetailModifiedDate, "99/99/99"));
            A15ProductId = T00093_A15ProductId[0];
            AssignAttri("", false, "A15ProductId", StringUtil.LTrimStr( (decimal)(A15ProductId), 6, 0));
            A50PurchaseOrderId = T00093_A50PurchaseOrderId[0];
            AssignAttri("", false, "A50PurchaseOrderId", StringUtil.LTrimStr( (decimal)(A50PurchaseOrderId), 6, 0));
            Z44OrderDetailId = A44OrderDetailId;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load099( ) ;
            if ( AnyError == 1 )
            {
               RcdFound9 = 0;
               InitializeNonKey099( ) ;
            }
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound9 = 0;
            InitializeNonKey099( ) ;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey099( ) ;
         if ( RcdFound9 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound9 = 0;
         /* Using cursor T000910 */
         pr_default.execute(8, new Object[] {A44OrderDetailId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000910_A44OrderDetailId[0] < A44OrderDetailId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000910_A44OrderDetailId[0] > A44OrderDetailId ) ) )
            {
               A44OrderDetailId = T000910_A44OrderDetailId[0];
               AssignAttri("", false, "A44OrderDetailId", StringUtil.LTrimStr( (decimal)(A44OrderDetailId), 6, 0));
               RcdFound9 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound9 = 0;
         /* Using cursor T000911 */
         pr_default.execute(9, new Object[] {A44OrderDetailId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000911_A44OrderDetailId[0] > A44OrderDetailId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000911_A44OrderDetailId[0] < A44OrderDetailId ) ) )
            {
               A44OrderDetailId = T000911_A44OrderDetailId[0];
               AssignAttri("", false, "A44OrderDetailId", StringUtil.LTrimStr( (decimal)(A44OrderDetailId), 6, 0));
               RcdFound9 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey099( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPurchaseOrderId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert099( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound9 == 1 )
            {
               if ( A44OrderDetailId != Z44OrderDetailId )
               {
                  A44OrderDetailId = Z44OrderDetailId;
                  AssignAttri("", false, "A44OrderDetailId", StringUtil.LTrimStr( (decimal)(A44OrderDetailId), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ORDERDETAILID");
                  AnyError = 1;
                  GX_FocusControl = edtOrderDetailId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPurchaseOrderId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update099( ) ;
                  GX_FocusControl = edtPurchaseOrderId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A44OrderDetailId != Z44OrderDetailId )
               {
                  /* Insert record */
                  GX_FocusControl = edtPurchaseOrderId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert099( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ORDERDETAILID");
                     AnyError = 1;
                     GX_FocusControl = edtOrderDetailId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtPurchaseOrderId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert099( ) ;
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
         if ( A44OrderDetailId != Z44OrderDetailId )
         {
            A44OrderDetailId = Z44OrderDetailId;
            AssignAttri("", false, "A44OrderDetailId", StringUtil.LTrimStr( (decimal)(A44OrderDetailId), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ORDERDETAILID");
            AnyError = 1;
            GX_FocusControl = edtOrderDetailId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPurchaseOrderId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency099( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00092 */
            pr_default.execute(0, new Object[] {A44OrderDetailId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"OrderDetail"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z45OrderDetailQuantity != T00092_A45OrderDetailQuantity[0] ) || ( Z46OrderDetailCurrentPrice != T00092_A46OrderDetailCurrentPrice[0] ) || ( Z47OrderDetailSuggestedPrice != T00092_A47OrderDetailSuggestedPrice[0] ) || ( DateTimeUtil.ResetTime ( Z48OrderDetailCreatedDate ) != DateTimeUtil.ResetTime ( T00092_A48OrderDetailCreatedDate[0] ) ) || ( DateTimeUtil.ResetTime ( Z49OrderDetailModifiedDate ) != DateTimeUtil.ResetTime ( T00092_A49OrderDetailModifiedDate[0] ) ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z15ProductId != T00092_A15ProductId[0] ) || ( Z50PurchaseOrderId != T00092_A50PurchaseOrderId[0] ) )
            {
               if ( Z45OrderDetailQuantity != T00092_A45OrderDetailQuantity[0] )
               {
                  GXUtil.WriteLog("orderdetail:[seudo value changed for attri]"+"OrderDetailQuantity");
                  GXUtil.WriteLogRaw("Old: ",Z45OrderDetailQuantity);
                  GXUtil.WriteLogRaw("Current: ",T00092_A45OrderDetailQuantity[0]);
               }
               if ( Z46OrderDetailCurrentPrice != T00092_A46OrderDetailCurrentPrice[0] )
               {
                  GXUtil.WriteLog("orderdetail:[seudo value changed for attri]"+"OrderDetailCurrentPrice");
                  GXUtil.WriteLogRaw("Old: ",Z46OrderDetailCurrentPrice);
                  GXUtil.WriteLogRaw("Current: ",T00092_A46OrderDetailCurrentPrice[0]);
               }
               if ( Z47OrderDetailSuggestedPrice != T00092_A47OrderDetailSuggestedPrice[0] )
               {
                  GXUtil.WriteLog("orderdetail:[seudo value changed for attri]"+"OrderDetailSuggestedPrice");
                  GXUtil.WriteLogRaw("Old: ",Z47OrderDetailSuggestedPrice);
                  GXUtil.WriteLogRaw("Current: ",T00092_A47OrderDetailSuggestedPrice[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z48OrderDetailCreatedDate ) != DateTimeUtil.ResetTime ( T00092_A48OrderDetailCreatedDate[0] ) )
               {
                  GXUtil.WriteLog("orderdetail:[seudo value changed for attri]"+"OrderDetailCreatedDate");
                  GXUtil.WriteLogRaw("Old: ",Z48OrderDetailCreatedDate);
                  GXUtil.WriteLogRaw("Current: ",T00092_A48OrderDetailCreatedDate[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z49OrderDetailModifiedDate ) != DateTimeUtil.ResetTime ( T00092_A49OrderDetailModifiedDate[0] ) )
               {
                  GXUtil.WriteLog("orderdetail:[seudo value changed for attri]"+"OrderDetailModifiedDate");
                  GXUtil.WriteLogRaw("Old: ",Z49OrderDetailModifiedDate);
                  GXUtil.WriteLogRaw("Current: ",T00092_A49OrderDetailModifiedDate[0]);
               }
               if ( Z15ProductId != T00092_A15ProductId[0] )
               {
                  GXUtil.WriteLog("orderdetail:[seudo value changed for attri]"+"ProductId");
                  GXUtil.WriteLogRaw("Old: ",Z15ProductId);
                  GXUtil.WriteLogRaw("Current: ",T00092_A15ProductId[0]);
               }
               if ( Z50PurchaseOrderId != T00092_A50PurchaseOrderId[0] )
               {
                  GXUtil.WriteLog("orderdetail:[seudo value changed for attri]"+"PurchaseOrderId");
                  GXUtil.WriteLogRaw("Old: ",Z50PurchaseOrderId);
                  GXUtil.WriteLogRaw("Current: ",T00092_A50PurchaseOrderId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"OrderDetail"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert099( )
      {
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable099( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM099( 0) ;
            CheckOptimisticConcurrency099( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm099( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert099( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000912 */
                     pr_default.execute(10, new Object[] {A45OrderDetailQuantity, A46OrderDetailCurrentPrice, n47OrderDetailSuggestedPrice, A47OrderDetailSuggestedPrice, A48OrderDetailCreatedDate, n49OrderDetailModifiedDate, A49OrderDetailModifiedDate, A15ProductId, A50PurchaseOrderId});
                     A44OrderDetailId = T000912_A44OrderDetailId[0];
                     AssignAttri("", false, "A44OrderDetailId", StringUtil.LTrimStr( (decimal)(A44OrderDetailId), 6, 0));
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("OrderDetail");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption090( ) ;
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
               Load099( ) ;
            }
            EndLevel099( ) ;
         }
         CloseExtendedTableCursors099( ) ;
      }

      protected void Update099( )
      {
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable099( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency099( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm099( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate099( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000913 */
                     pr_default.execute(11, new Object[] {A45OrderDetailQuantity, A46OrderDetailCurrentPrice, n47OrderDetailSuggestedPrice, A47OrderDetailSuggestedPrice, A48OrderDetailCreatedDate, n49OrderDetailModifiedDate, A49OrderDetailModifiedDate, A15ProductId, A50PurchaseOrderId, A44OrderDetailId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("OrderDetail");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"OrderDetail"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate099( ) ;
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
            EndLevel099( ) ;
         }
         CloseExtendedTableCursors099( ) ;
      }

      protected void DeferredUpdate099( )
      {
      }

      protected void delete( )
      {
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency099( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls099( ) ;
            AfterConfirm099( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete099( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000914 */
                  pr_default.execute(12, new Object[] {A44OrderDetailId});
                  pr_default.close(12);
                  pr_default.SmartCacheProvider.SetUpdated("OrderDetail");
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
         sMode9 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel099( ) ;
         Gx_mode = sMode9;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls099( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV14Pgmname = "OrderDetail";
            AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
         }
      }

      protected void EndLevel099( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete099( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("orderdetail",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues090( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("orderdetail",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart099( )
      {
         /* Scan By routine */
         /* Using cursor T000915 */
         pr_default.execute(13);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound9 = 1;
            A44OrderDetailId = T000915_A44OrderDetailId[0];
            AssignAttri("", false, "A44OrderDetailId", StringUtil.LTrimStr( (decimal)(A44OrderDetailId), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext099( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound9 = 1;
            A44OrderDetailId = T000915_A44OrderDetailId[0];
            AssignAttri("", false, "A44OrderDetailId", StringUtil.LTrimStr( (decimal)(A44OrderDetailId), 6, 0));
         }
      }

      protected void ScanEnd099( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm099( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert099( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate099( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete099( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete099( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate099( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes099( )
      {
         edtOrderDetailId_Enabled = 0;
         AssignProp("", false, edtOrderDetailId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrderDetailId_Enabled), 5, 0), true);
         edtPurchaseOrderId_Enabled = 0;
         AssignProp("", false, edtPurchaseOrderId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPurchaseOrderId_Enabled), 5, 0), true);
         edtProductId_Enabled = 0;
         AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), true);
         edtOrderDetailQuantity_Enabled = 0;
         AssignProp("", false, edtOrderDetailQuantity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrderDetailQuantity_Enabled), 5, 0), true);
         edtOrderDetailCurrentPrice_Enabled = 0;
         AssignProp("", false, edtOrderDetailCurrentPrice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrderDetailCurrentPrice_Enabled), 5, 0), true);
         edtOrderDetailSuggestedPrice_Enabled = 0;
         AssignProp("", false, edtOrderDetailSuggestedPrice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrderDetailSuggestedPrice_Enabled), 5, 0), true);
         edtOrderDetailCreatedDate_Enabled = 0;
         AssignProp("", false, edtOrderDetailCreatedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrderDetailCreatedDate_Enabled), 5, 0), true);
         edtOrderDetailModifiedDate_Enabled = 0;
         AssignProp("", false, edtOrderDetailModifiedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrderDetailModifiedDate_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes099( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues090( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("orderdetail.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7OrderDetailId,6,0))}, new string[] {"Gx_mode","OrderDetailId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"OrderDetail");
         forbiddenHiddens.Add("OrderDetailId", context.localUtil.Format( (decimal)(A44OrderDetailId), "ZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("orderdetail:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z44OrderDetailId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z44OrderDetailId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z45OrderDetailQuantity", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z45OrderDetailQuantity), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z46OrderDetailCurrentPrice", StringUtil.LTrim( StringUtil.NToC( Z46OrderDetailCurrentPrice, 10, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z47OrderDetailSuggestedPrice", StringUtil.LTrim( StringUtil.NToC( Z47OrderDetailSuggestedPrice, 10, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z48OrderDetailCreatedDate", context.localUtil.DToC( Z48OrderDetailCreatedDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z49OrderDetailModifiedDate", context.localUtil.DToC( Z49OrderDetailModifiedDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z15ProductId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z15ProductId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z50PurchaseOrderId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z50PurchaseOrderId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N50PurchaseOrderId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A50PurchaseOrderId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N15ProductId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "vORDERDETAILID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7OrderDetailId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vORDERDETAILID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7OrderDetailId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_PURCHASEORDERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_PurchaseOrderId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_PRODUCTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_ProductId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV14Pgmname));
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
         return formatLink("orderdetail.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7OrderDetailId,6,0))}, new string[] {"Gx_mode","OrderDetailId"})  ;
      }

      public override string GetPgmname( )
      {
         return "OrderDetail" ;
      }

      public override string GetPgmdesc( )
      {
         return "Order Detail" ;
      }

      protected void InitializeNonKey099( )
      {
         A50PurchaseOrderId = 0;
         AssignAttri("", false, "A50PurchaseOrderId", StringUtil.LTrimStr( (decimal)(A50PurchaseOrderId), 6, 0));
         A15ProductId = 0;
         AssignAttri("", false, "A15ProductId", StringUtil.LTrimStr( (decimal)(A15ProductId), 6, 0));
         A45OrderDetailQuantity = 0;
         AssignAttri("", false, "A45OrderDetailQuantity", StringUtil.LTrimStr( (decimal)(A45OrderDetailQuantity), 6, 0));
         A46OrderDetailCurrentPrice = 0;
         AssignAttri("", false, "A46OrderDetailCurrentPrice", StringUtil.LTrimStr( A46OrderDetailCurrentPrice, 10, 2));
         A47OrderDetailSuggestedPrice = 0;
         n47OrderDetailSuggestedPrice = false;
         AssignAttri("", false, "A47OrderDetailSuggestedPrice", StringUtil.LTrimStr( A47OrderDetailSuggestedPrice, 10, 2));
         n47OrderDetailSuggestedPrice = ((Convert.ToDecimal(0)==A47OrderDetailSuggestedPrice) ? true : false);
         A48OrderDetailCreatedDate = DateTime.MinValue;
         AssignAttri("", false, "A48OrderDetailCreatedDate", context.localUtil.Format(A48OrderDetailCreatedDate, "99/99/99"));
         A49OrderDetailModifiedDate = DateTime.MinValue;
         n49OrderDetailModifiedDate = false;
         AssignAttri("", false, "A49OrderDetailModifiedDate", context.localUtil.Format(A49OrderDetailModifiedDate, "99/99/99"));
         n49OrderDetailModifiedDate = ((DateTime.MinValue==A49OrderDetailModifiedDate) ? true : false);
         Z45OrderDetailQuantity = 0;
         Z46OrderDetailCurrentPrice = 0;
         Z47OrderDetailSuggestedPrice = 0;
         Z48OrderDetailCreatedDate = DateTime.MinValue;
         Z49OrderDetailModifiedDate = DateTime.MinValue;
         Z15ProductId = 0;
         Z50PurchaseOrderId = 0;
      }

      protected void InitAll099( )
      {
         A44OrderDetailId = 0;
         AssignAttri("", false, "A44OrderDetailId", StringUtil.LTrimStr( (decimal)(A44OrderDetailId), 6, 0));
         InitializeNonKey099( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023112203951", true, true);
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
         context.AddJavascriptSource("orderdetail.js", "?2023112203952", false, true);
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
         edtOrderDetailId_Internalname = "ORDERDETAILID";
         edtPurchaseOrderId_Internalname = "PURCHASEORDERID";
         edtProductId_Internalname = "PRODUCTID";
         edtOrderDetailQuantity_Internalname = "ORDERDETAILQUANTITY";
         edtOrderDetailCurrentPrice_Internalname = "ORDERDETAILCURRENTPRICE";
         edtOrderDetailSuggestedPrice_Internalname = "ORDERDETAILSUGGESTEDPRICE";
         edtOrderDetailCreatedDate_Internalname = "ORDERDETAILCREATEDDATE";
         edtOrderDetailModifiedDate_Internalname = "ORDERDETAILMODIFIEDDATE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_50_Internalname = "PROMPT_50";
         imgprompt_15_Internalname = "PROMPT_15";
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
         Form.Caption = "Order Detail";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirm";
         bttBtn_enter_Caption = "Confirm";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtOrderDetailModifiedDate_Jsonclick = "";
         edtOrderDetailModifiedDate_Enabled = 1;
         edtOrderDetailCreatedDate_Jsonclick = "";
         edtOrderDetailCreatedDate_Enabled = 1;
         edtOrderDetailSuggestedPrice_Jsonclick = "";
         edtOrderDetailSuggestedPrice_Enabled = 1;
         edtOrderDetailCurrentPrice_Jsonclick = "";
         edtOrderDetailCurrentPrice_Enabled = 1;
         edtOrderDetailQuantity_Jsonclick = "";
         edtOrderDetailQuantity_Enabled = 1;
         imgprompt_15_Visible = 1;
         imgprompt_15_Link = "";
         edtProductId_Jsonclick = "";
         edtProductId_Enabled = 1;
         imgprompt_50_Visible = 1;
         imgprompt_50_Link = "";
         edtPurchaseOrderId_Jsonclick = "";
         edtPurchaseOrderId_Enabled = 1;
         edtOrderDetailId_Jsonclick = "";
         edtOrderDetailId_Enabled = 0;
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

      public void Valid_Purchaseorderid( )
      {
         /* Using cursor T000916 */
         pr_default.execute(14, new Object[] {A50PurchaseOrderId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No matching 'Purchase Order'.", "ForeignKeyNotFound", 1, "PURCHASEORDERID");
            AnyError = 1;
            GX_FocusControl = edtPurchaseOrderId_Internalname;
         }
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Productid( )
      {
         /* Using cursor T000917 */
         pr_default.execute(15, new Object[] {A15ProductId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No matching 'Product'.", "ForeignKeyNotFound", 1, "PRODUCTID");
            AnyError = 1;
            GX_FocusControl = edtProductId_Internalname;
         }
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7OrderDetailId',fld:'vORDERDETAILID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7OrderDetailId',fld:'vORDERDETAILID',pic:'ZZZZZ9',hsh:true},{av:'A44OrderDetailId',fld:'ORDERDETAILID',pic:'ZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12092',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_ORDERDETAILID","{handler:'Valid_Orderdetailid',iparms:[]");
         setEventMetadata("VALID_ORDERDETAILID",",oparms:[]}");
         setEventMetadata("VALID_PURCHASEORDERID","{handler:'Valid_Purchaseorderid',iparms:[{av:'A50PurchaseOrderId',fld:'PURCHASEORDERID',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_PURCHASEORDERID",",oparms:[]}");
         setEventMetadata("VALID_PRODUCTID","{handler:'Valid_Productid',iparms:[{av:'A15ProductId',fld:'PRODUCTID',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_PRODUCTID",",oparms:[]}");
         setEventMetadata("VALID_ORDERDETAILCREATEDDATE","{handler:'Valid_Orderdetailcreateddate',iparms:[]");
         setEventMetadata("VALID_ORDERDETAILCREATEDDATE",",oparms:[]}");
         setEventMetadata("VALID_ORDERDETAILMODIFIEDDATE","{handler:'Valid_Orderdetailmodifieddate',iparms:[]");
         setEventMetadata("VALID_ORDERDETAILMODIFIEDDATE",",oparms:[]}");
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
         pr_default.close(14);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z48OrderDetailCreatedDate = DateTime.MinValue;
         Z49OrderDetailModifiedDate = DateTime.MinValue;
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
         imgprompt_50_gximage = "";
         sImgUrl = "";
         imgprompt_15_gximage = "";
         A48OrderDetailCreatedDate = DateTime.MinValue;
         A49OrderDetailModifiedDate = DateTime.MinValue;
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV14Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode9 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV13TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         T00096_A44OrderDetailId = new int[1] ;
         T00096_A45OrderDetailQuantity = new int[1] ;
         T00096_A46OrderDetailCurrentPrice = new decimal[1] ;
         T00096_A47OrderDetailSuggestedPrice = new decimal[1] ;
         T00096_n47OrderDetailSuggestedPrice = new bool[] {false} ;
         T00096_A48OrderDetailCreatedDate = new DateTime[] {DateTime.MinValue} ;
         T00096_A49OrderDetailModifiedDate = new DateTime[] {DateTime.MinValue} ;
         T00096_n49OrderDetailModifiedDate = new bool[] {false} ;
         T00096_A15ProductId = new int[1] ;
         T00096_A50PurchaseOrderId = new int[1] ;
         T00095_A50PurchaseOrderId = new int[1] ;
         T00094_A15ProductId = new int[1] ;
         T00097_A50PurchaseOrderId = new int[1] ;
         T00098_A15ProductId = new int[1] ;
         T00099_A44OrderDetailId = new int[1] ;
         T00093_A44OrderDetailId = new int[1] ;
         T00093_A45OrderDetailQuantity = new int[1] ;
         T00093_A46OrderDetailCurrentPrice = new decimal[1] ;
         T00093_A47OrderDetailSuggestedPrice = new decimal[1] ;
         T00093_n47OrderDetailSuggestedPrice = new bool[] {false} ;
         T00093_A48OrderDetailCreatedDate = new DateTime[] {DateTime.MinValue} ;
         T00093_A49OrderDetailModifiedDate = new DateTime[] {DateTime.MinValue} ;
         T00093_n49OrderDetailModifiedDate = new bool[] {false} ;
         T00093_A15ProductId = new int[1] ;
         T00093_A50PurchaseOrderId = new int[1] ;
         T000910_A44OrderDetailId = new int[1] ;
         T000911_A44OrderDetailId = new int[1] ;
         T00092_A44OrderDetailId = new int[1] ;
         T00092_A45OrderDetailQuantity = new int[1] ;
         T00092_A46OrderDetailCurrentPrice = new decimal[1] ;
         T00092_A47OrderDetailSuggestedPrice = new decimal[1] ;
         T00092_n47OrderDetailSuggestedPrice = new bool[] {false} ;
         T00092_A48OrderDetailCreatedDate = new DateTime[] {DateTime.MinValue} ;
         T00092_A49OrderDetailModifiedDate = new DateTime[] {DateTime.MinValue} ;
         T00092_n49OrderDetailModifiedDate = new bool[] {false} ;
         T00092_A15ProductId = new int[1] ;
         T00092_A50PurchaseOrderId = new int[1] ;
         T000912_A44OrderDetailId = new int[1] ;
         T000915_A44OrderDetailId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000916_A50PurchaseOrderId = new int[1] ;
         T000917_A15ProductId = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.orderdetail__default(),
            new Object[][] {
                new Object[] {
               T00092_A44OrderDetailId, T00092_A45OrderDetailQuantity, T00092_A46OrderDetailCurrentPrice, T00092_A47OrderDetailSuggestedPrice, T00092_n47OrderDetailSuggestedPrice, T00092_A48OrderDetailCreatedDate, T00092_A49OrderDetailModifiedDate, T00092_n49OrderDetailModifiedDate, T00092_A15ProductId, T00092_A50PurchaseOrderId
               }
               , new Object[] {
               T00093_A44OrderDetailId, T00093_A45OrderDetailQuantity, T00093_A46OrderDetailCurrentPrice, T00093_A47OrderDetailSuggestedPrice, T00093_n47OrderDetailSuggestedPrice, T00093_A48OrderDetailCreatedDate, T00093_A49OrderDetailModifiedDate, T00093_n49OrderDetailModifiedDate, T00093_A15ProductId, T00093_A50PurchaseOrderId
               }
               , new Object[] {
               T00094_A15ProductId
               }
               , new Object[] {
               T00095_A50PurchaseOrderId
               }
               , new Object[] {
               T00096_A44OrderDetailId, T00096_A45OrderDetailQuantity, T00096_A46OrderDetailCurrentPrice, T00096_A47OrderDetailSuggestedPrice, T00096_n47OrderDetailSuggestedPrice, T00096_A48OrderDetailCreatedDate, T00096_A49OrderDetailModifiedDate, T00096_n49OrderDetailModifiedDate, T00096_A15ProductId, T00096_A50PurchaseOrderId
               }
               , new Object[] {
               T00097_A50PurchaseOrderId
               }
               , new Object[] {
               T00098_A15ProductId
               }
               , new Object[] {
               T00099_A44OrderDetailId
               }
               , new Object[] {
               T000910_A44OrderDetailId
               }
               , new Object[] {
               T000911_A44OrderDetailId
               }
               , new Object[] {
               T000912_A44OrderDetailId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000915_A44OrderDetailId
               }
               , new Object[] {
               T000916_A50PurchaseOrderId
               }
               , new Object[] {
               T000917_A15ProductId
               }
            }
         );
         AV14Pgmname = "OrderDetail";
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short RcdFound9 ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short nIsDirty_9 ;
      private short gxajaxcallmode ;
      private int wcpOAV7OrderDetailId ;
      private int Z44OrderDetailId ;
      private int Z45OrderDetailQuantity ;
      private int Z15ProductId ;
      private int Z50PurchaseOrderId ;
      private int N50PurchaseOrderId ;
      private int N15ProductId ;
      private int A50PurchaseOrderId ;
      private int A15ProductId ;
      private int AV7OrderDetailId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A44OrderDetailId ;
      private int edtOrderDetailId_Enabled ;
      private int edtPurchaseOrderId_Enabled ;
      private int imgprompt_50_Visible ;
      private int edtProductId_Enabled ;
      private int imgprompt_15_Visible ;
      private int A45OrderDetailQuantity ;
      private int edtOrderDetailQuantity_Enabled ;
      private int edtOrderDetailCurrentPrice_Enabled ;
      private int edtOrderDetailSuggestedPrice_Enabled ;
      private int edtOrderDetailCreatedDate_Enabled ;
      private int edtOrderDetailModifiedDate_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int AV11Insert_PurchaseOrderId ;
      private int AV12Insert_ProductId ;
      private int AV15GXV1 ;
      private int idxLst ;
      private decimal Z46OrderDetailCurrentPrice ;
      private decimal Z47OrderDetailSuggestedPrice ;
      private decimal A46OrderDetailCurrentPrice ;
      private decimal A47OrderDetailSuggestedPrice ;
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
      private string edtPurchaseOrderId_Internalname ;
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
      private string edtOrderDetailId_Internalname ;
      private string edtOrderDetailId_Jsonclick ;
      private string edtPurchaseOrderId_Jsonclick ;
      private string imgprompt_50_gximage ;
      private string sImgUrl ;
      private string imgprompt_50_Internalname ;
      private string imgprompt_50_Link ;
      private string edtProductId_Internalname ;
      private string edtProductId_Jsonclick ;
      private string imgprompt_15_gximage ;
      private string imgprompt_15_Internalname ;
      private string imgprompt_15_Link ;
      private string edtOrderDetailQuantity_Internalname ;
      private string edtOrderDetailQuantity_Jsonclick ;
      private string edtOrderDetailCurrentPrice_Internalname ;
      private string edtOrderDetailCurrentPrice_Jsonclick ;
      private string edtOrderDetailSuggestedPrice_Internalname ;
      private string edtOrderDetailSuggestedPrice_Jsonclick ;
      private string edtOrderDetailCreatedDate_Internalname ;
      private string edtOrderDetailCreatedDate_Jsonclick ;
      private string edtOrderDetailModifiedDate_Internalname ;
      private string edtOrderDetailModifiedDate_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Caption ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_enter_Tooltiptext ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV14Pgmname ;
      private string hsh ;
      private string sMode9 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z48OrderDetailCreatedDate ;
      private DateTime Z49OrderDetailModifiedDate ;
      private DateTime A48OrderDetailCreatedDate ;
      private DateTime A49OrderDetailModifiedDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n47OrderDetailSuggestedPrice ;
      private bool n49OrderDetailModifiedDate ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T00096_A44OrderDetailId ;
      private int[] T00096_A45OrderDetailQuantity ;
      private decimal[] T00096_A46OrderDetailCurrentPrice ;
      private decimal[] T00096_A47OrderDetailSuggestedPrice ;
      private bool[] T00096_n47OrderDetailSuggestedPrice ;
      private DateTime[] T00096_A48OrderDetailCreatedDate ;
      private DateTime[] T00096_A49OrderDetailModifiedDate ;
      private bool[] T00096_n49OrderDetailModifiedDate ;
      private int[] T00096_A15ProductId ;
      private int[] T00096_A50PurchaseOrderId ;
      private int[] T00095_A50PurchaseOrderId ;
      private int[] T00094_A15ProductId ;
      private int[] T00097_A50PurchaseOrderId ;
      private int[] T00098_A15ProductId ;
      private int[] T00099_A44OrderDetailId ;
      private int[] T00093_A44OrderDetailId ;
      private int[] T00093_A45OrderDetailQuantity ;
      private decimal[] T00093_A46OrderDetailCurrentPrice ;
      private decimal[] T00093_A47OrderDetailSuggestedPrice ;
      private bool[] T00093_n47OrderDetailSuggestedPrice ;
      private DateTime[] T00093_A48OrderDetailCreatedDate ;
      private DateTime[] T00093_A49OrderDetailModifiedDate ;
      private bool[] T00093_n49OrderDetailModifiedDate ;
      private int[] T00093_A15ProductId ;
      private int[] T00093_A50PurchaseOrderId ;
      private int[] T000910_A44OrderDetailId ;
      private int[] T000911_A44OrderDetailId ;
      private int[] T00092_A44OrderDetailId ;
      private int[] T00092_A45OrderDetailQuantity ;
      private decimal[] T00092_A46OrderDetailCurrentPrice ;
      private decimal[] T00092_A47OrderDetailSuggestedPrice ;
      private bool[] T00092_n47OrderDetailSuggestedPrice ;
      private DateTime[] T00092_A48OrderDetailCreatedDate ;
      private DateTime[] T00092_A49OrderDetailModifiedDate ;
      private bool[] T00092_n49OrderDetailModifiedDate ;
      private int[] T00092_A15ProductId ;
      private int[] T00092_A50PurchaseOrderId ;
      private int[] T000912_A44OrderDetailId ;
      private int[] T000915_A44OrderDetailId ;
      private int[] T000916_A50PurchaseOrderId ;
      private int[] T000917_A15ProductId ;
      private GXWebForm Form ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV13TrnContextAtt ;
   }

   public class orderdetail__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00096;
          prmT00096 = new Object[] {
          new ParDef("@OrderDetailId",GXType.Int32,6,0)
          };
          Object[] prmT00095;
          prmT00095 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmT00094;
          prmT00094 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmT00097;
          prmT00097 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmT00098;
          prmT00098 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmT00099;
          prmT00099 = new Object[] {
          new ParDef("@OrderDetailId",GXType.Int32,6,0)
          };
          Object[] prmT00093;
          prmT00093 = new Object[] {
          new ParDef("@OrderDetailId",GXType.Int32,6,0)
          };
          Object[] prmT000910;
          prmT000910 = new Object[] {
          new ParDef("@OrderDetailId",GXType.Int32,6,0)
          };
          Object[] prmT000911;
          prmT000911 = new Object[] {
          new ParDef("@OrderDetailId",GXType.Int32,6,0)
          };
          Object[] prmT00092;
          prmT00092 = new Object[] {
          new ParDef("@OrderDetailId",GXType.Int32,6,0)
          };
          Object[] prmT000912;
          prmT000912 = new Object[] {
          new ParDef("@OrderDetailQuantity",GXType.Int32,6,0) ,
          new ParDef("@OrderDetailCurrentPrice",GXType.Decimal,10,2) ,
          new ParDef("@OrderDetailSuggestedPrice",GXType.Decimal,10,2){Nullable=true} ,
          new ParDef("@OrderDetailCreatedDate",GXType.Date,8,0) ,
          new ParDef("@OrderDetailModifiedDate",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@ProductId",GXType.Int32,6,0) ,
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmT000913;
          prmT000913 = new Object[] {
          new ParDef("@OrderDetailQuantity",GXType.Int32,6,0) ,
          new ParDef("@OrderDetailCurrentPrice",GXType.Decimal,10,2) ,
          new ParDef("@OrderDetailSuggestedPrice",GXType.Decimal,10,2){Nullable=true} ,
          new ParDef("@OrderDetailCreatedDate",GXType.Date,8,0) ,
          new ParDef("@OrderDetailModifiedDate",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@ProductId",GXType.Int32,6,0) ,
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0) ,
          new ParDef("@OrderDetailId",GXType.Int32,6,0)
          };
          Object[] prmT000914;
          prmT000914 = new Object[] {
          new ParDef("@OrderDetailId",GXType.Int32,6,0)
          };
          Object[] prmT000915;
          prmT000915 = new Object[] {
          };
          Object[] prmT000916;
          prmT000916 = new Object[] {
          new ParDef("@PurchaseOrderId",GXType.Int32,6,0)
          };
          Object[] prmT000917;
          prmT000917 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00092", "SELECT [OrderDetailId], [OrderDetailQuantity], [OrderDetailCurrentPrice], [OrderDetailSuggestedPrice], [OrderDetailCreatedDate], [OrderDetailModifiedDate], [ProductId], [PurchaseOrderId] FROM [OrderDetail] WITH (UPDLOCK) WHERE [OrderDetailId] = @OrderDetailId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00092,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00093", "SELECT [OrderDetailId], [OrderDetailQuantity], [OrderDetailCurrentPrice], [OrderDetailSuggestedPrice], [OrderDetailCreatedDate], [OrderDetailModifiedDate], [ProductId], [PurchaseOrderId] FROM [OrderDetail] WHERE [OrderDetailId] = @OrderDetailId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00093,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00094", "SELECT [ProductId] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00094,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00095", "SELECT [PurchaseOrderId] FROM [PurchaseOrder] WHERE [PurchaseOrderId] = @PurchaseOrderId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00095,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00096", "SELECT TM1.[OrderDetailId], TM1.[OrderDetailQuantity], TM1.[OrderDetailCurrentPrice], TM1.[OrderDetailSuggestedPrice], TM1.[OrderDetailCreatedDate], TM1.[OrderDetailModifiedDate], TM1.[ProductId], TM1.[PurchaseOrderId] FROM [OrderDetail] TM1 WHERE TM1.[OrderDetailId] = @OrderDetailId ORDER BY TM1.[OrderDetailId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00096,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00097", "SELECT [PurchaseOrderId] FROM [PurchaseOrder] WHERE [PurchaseOrderId] = @PurchaseOrderId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00097,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00098", "SELECT [ProductId] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00098,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00099", "SELECT [OrderDetailId] FROM [OrderDetail] WHERE [OrderDetailId] = @OrderDetailId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00099,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000910", "SELECT TOP 1 [OrderDetailId] FROM [OrderDetail] WHERE ( [OrderDetailId] > @OrderDetailId) ORDER BY [OrderDetailId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000910,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000911", "SELECT TOP 1 [OrderDetailId] FROM [OrderDetail] WHERE ( [OrderDetailId] < @OrderDetailId) ORDER BY [OrderDetailId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000911,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000912", "INSERT INTO [OrderDetail]([OrderDetailQuantity], [OrderDetailCurrentPrice], [OrderDetailSuggestedPrice], [OrderDetailCreatedDate], [OrderDetailModifiedDate], [ProductId], [PurchaseOrderId]) VALUES(@OrderDetailQuantity, @OrderDetailCurrentPrice, @OrderDetailSuggestedPrice, @OrderDetailCreatedDate, @OrderDetailModifiedDate, @ProductId, @PurchaseOrderId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000912,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000913", "UPDATE [OrderDetail] SET [OrderDetailQuantity]=@OrderDetailQuantity, [OrderDetailCurrentPrice]=@OrderDetailCurrentPrice, [OrderDetailSuggestedPrice]=@OrderDetailSuggestedPrice, [OrderDetailCreatedDate]=@OrderDetailCreatedDate, [OrderDetailModifiedDate]=@OrderDetailModifiedDate, [ProductId]=@ProductId, [PurchaseOrderId]=@PurchaseOrderId  WHERE [OrderDetailId] = @OrderDetailId", GxErrorMask.GX_NOMASK,prmT000913)
             ,new CursorDef("T000914", "DELETE FROM [OrderDetail]  WHERE [OrderDetailId] = @OrderDetailId", GxErrorMask.GX_NOMASK,prmT000914)
             ,new CursorDef("T000915", "SELECT [OrderDetailId] FROM [OrderDetail] ORDER BY [OrderDetailId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000915,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000916", "SELECT [PurchaseOrderId] FROM [PurchaseOrder] WHERE [PurchaseOrderId] = @PurchaseOrderId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000916,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000917", "SELECT [ProductId] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000917,1, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((int[]) buf[8])[0] = rslt.getInt(7);
                ((int[]) buf[9])[0] = rslt.getInt(8);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((int[]) buf[8])[0] = rslt.getInt(7);
                ((int[]) buf[9])[0] = rslt.getInt(8);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((int[]) buf[8])[0] = rslt.getInt(7);
                ((int[]) buf[9])[0] = rslt.getInt(8);
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
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 14 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 15 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
