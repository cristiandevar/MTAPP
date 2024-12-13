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
   public class invoicedetail : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_16") == 0 )
         {
            A15ProductId = (int)(Math.Round(NumberUtil.Val( GetPar( "ProductId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A15ProductId", StringUtil.LTrimStr( (decimal)(A15ProductId), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_16( A15ProductId) ;
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
               AV7InvoiceDetailId = (int)(Math.Round(NumberUtil.Val( GetPar( "InvoiceDetailId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7InvoiceDetailId", StringUtil.LTrimStr( (decimal)(AV7InvoiceDetailId), 6, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vINVOICEDETAILID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7InvoiceDetailId), "ZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Invoice Detail", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtInvoiceId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("mtaKB", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public invoicedetail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public invoicedetail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_InvoiceDetailId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7InvoiceDetailId = aP1_InvoiceDetailId;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Invoice Detail", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_InvoiceDetail.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_InvoiceDetail.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_InvoiceDetail.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_InvoiceDetail.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_InvoiceDetail.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_InvoiceDetail.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtInvoiceDetailId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtInvoiceDetailId_Internalname, "Detail Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtInvoiceDetailId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A25InvoiceDetailId), 6, 0, ".", "")), StringUtil.LTrim( ((edtInvoiceDetailId_Enabled!=0) ? context.localUtil.Format( (decimal)(A25InvoiceDetailId), "ZZZZZ9") : context.localUtil.Format( (decimal)(A25InvoiceDetailId), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtInvoiceDetailId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtInvoiceDetailId_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_InvoiceDetail.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtInvoiceId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtInvoiceId_Internalname, "Invoice Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtInvoiceId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A20InvoiceId), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A20InvoiceId), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtInvoiceId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtInvoiceId_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_InvoiceDetail.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_20_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_20_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_20_Internalname, sImgUrl, imgprompt_20_Link, "", "", context.GetTheme( ), imgprompt_20_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_InvoiceDetail.htm");
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
         GxWebStd.gx_single_line_edit( context, edtProductId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A15ProductId), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductId_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_InvoiceDetail.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_15_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_15_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_15_Internalname, sImgUrl, imgprompt_15_Link, "", "", context.GetTheme( ), imgprompt_15_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_InvoiceDetail.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtInvoiceDetailQuantity_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtInvoiceDetailQuantity_Internalname, "Detail Quantity", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtInvoiceDetailQuantity_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A26InvoiceDetailQuantity), 6, 0, ".", "")), StringUtil.LTrim( ((edtInvoiceDetailQuantity_Enabled!=0) ? context.localUtil.Format( (decimal)(A26InvoiceDetailQuantity), "ZZZZZ9") : context.localUtil.Format( (decimal)(A26InvoiceDetailQuantity), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtInvoiceDetailQuantity_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtInvoiceDetailQuantity_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_InvoiceDetail.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtInvoiceDetailHistoricalPrice_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtInvoiceDetailHistoricalPrice_Internalname, "Historical Price", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtInvoiceDetailHistoricalPrice_Internalname, StringUtil.LTrim( StringUtil.NToC( A27InvoiceDetailHistoricalPrice, 10, 2, ".", "")), StringUtil.LTrim( ((edtInvoiceDetailHistoricalPrice_Enabled!=0) ? context.localUtil.Format( A27InvoiceDetailHistoricalPrice, "ZZZZZZ9.99") : context.localUtil.Format( A27InvoiceDetailHistoricalPrice, "ZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtInvoiceDetailHistoricalPrice_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtInvoiceDetailHistoricalPrice_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "Price", "right", false, "", "HLP_InvoiceDetail.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtInvoiceDetailCreatedDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtInvoiceDetailCreatedDate_Internalname, "Created Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         context.WriteHtmlText( "<div id=\""+edtInvoiceDetailCreatedDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtInvoiceDetailCreatedDate_Internalname, context.localUtil.Format(A42InvoiceDetailCreatedDate, "99/99/99"), context.localUtil.Format( A42InvoiceDetailCreatedDate, "99/99/99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtInvoiceDetailCreatedDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtInvoiceDetailCreatedDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_InvoiceDetail.htm");
         GxWebStd.gx_bitmap( context, edtInvoiceDetailCreatedDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtInvoiceDetailCreatedDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_InvoiceDetail.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtInvoiceDetailModifiedDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtInvoiceDetailModifiedDate_Internalname, "Modified Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtInvoiceDetailModifiedDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtInvoiceDetailModifiedDate_Internalname, context.localUtil.Format(A43InvoiceDetailModifiedDate, "99/99/99"), context.localUtil.Format( A43InvoiceDetailModifiedDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtInvoiceDetailModifiedDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtInvoiceDetailModifiedDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_InvoiceDetail.htm");
         GxWebStd.gx_bitmap( context, edtInvoiceDetailModifiedDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtInvoiceDetailModifiedDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_InvoiceDetail.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_InvoiceDetail.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_InvoiceDetail.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_InvoiceDetail.htm");
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
         E11082 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z25InvoiceDetailId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z25InvoiceDetailId"), ".", ","), 18, MidpointRounding.ToEven));
               Z26InvoiceDetailQuantity = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z26InvoiceDetailQuantity"), ".", ","), 18, MidpointRounding.ToEven));
               Z27InvoiceDetailHistoricalPrice = context.localUtil.CToN( cgiGet( "Z27InvoiceDetailHistoricalPrice"), ".", ",");
               Z42InvoiceDetailCreatedDate = context.localUtil.CToD( cgiGet( "Z42InvoiceDetailCreatedDate"), 0);
               Z43InvoiceDetailModifiedDate = context.localUtil.CToD( cgiGet( "Z43InvoiceDetailModifiedDate"), 0);
               Z20InvoiceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z20InvoiceId"), ".", ","), 18, MidpointRounding.ToEven));
               Z15ProductId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z15ProductId"), ".", ","), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N20InvoiceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N20InvoiceId"), ".", ","), 18, MidpointRounding.ToEven));
               N15ProductId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N15ProductId"), ".", ","), 18, MidpointRounding.ToEven));
               AV7InvoiceDetailId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINVOICEDETAILID"), ".", ","), 18, MidpointRounding.ToEven));
               AV11Insert_InvoiceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_INVOICEID"), ".", ","), 18, MidpointRounding.ToEven));
               AV12Insert_ProductId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_PRODUCTID"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_date = context.localUtil.CToD( cgiGet( "vTODAY"), 0);
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","), 18, MidpointRounding.ToEven));
               AV16Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A25InvoiceDetailId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtInvoiceDetailId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A25InvoiceDetailId", StringUtil.LTrimStr( (decimal)(A25InvoiceDetailId), 6, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtInvoiceId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtInvoiceId_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "INVOICEID");
                  AnyError = 1;
                  GX_FocusControl = edtInvoiceId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A20InvoiceId = 0;
                  AssignAttri("", false, "A20InvoiceId", StringUtil.LTrimStr( (decimal)(A20InvoiceId), 6, 0));
               }
               else
               {
                  A20InvoiceId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtInvoiceId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A20InvoiceId", StringUtil.LTrimStr( (decimal)(A20InvoiceId), 6, 0));
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
               if ( ( ( context.localUtil.CToN( cgiGet( edtInvoiceDetailQuantity_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtInvoiceDetailQuantity_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "INVOICEDETAILQUANTITY");
                  AnyError = 1;
                  GX_FocusControl = edtInvoiceDetailQuantity_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A26InvoiceDetailQuantity = 0;
                  AssignAttri("", false, "A26InvoiceDetailQuantity", StringUtil.LTrimStr( (decimal)(A26InvoiceDetailQuantity), 6, 0));
               }
               else
               {
                  A26InvoiceDetailQuantity = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtInvoiceDetailQuantity_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A26InvoiceDetailQuantity", StringUtil.LTrimStr( (decimal)(A26InvoiceDetailQuantity), 6, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtInvoiceDetailHistoricalPrice_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtInvoiceDetailHistoricalPrice_Internalname), ".", ",") > 9999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "INVOICEDETAILHISTORICALPRICE");
                  AnyError = 1;
                  GX_FocusControl = edtInvoiceDetailHistoricalPrice_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A27InvoiceDetailHistoricalPrice = 0;
                  AssignAttri("", false, "A27InvoiceDetailHistoricalPrice", StringUtil.LTrimStr( A27InvoiceDetailHistoricalPrice, 10, 2));
               }
               else
               {
                  A27InvoiceDetailHistoricalPrice = context.localUtil.CToN( cgiGet( edtInvoiceDetailHistoricalPrice_Internalname), ".", ",");
                  AssignAttri("", false, "A27InvoiceDetailHistoricalPrice", StringUtil.LTrimStr( A27InvoiceDetailHistoricalPrice, 10, 2));
               }
               A42InvoiceDetailCreatedDate = context.localUtil.CToD( cgiGet( edtInvoiceDetailCreatedDate_Internalname), 1);
               AssignAttri("", false, "A42InvoiceDetailCreatedDate", context.localUtil.Format(A42InvoiceDetailCreatedDate, "99/99/99"));
               if ( context.localUtil.VCDate( cgiGet( edtInvoiceDetailModifiedDate_Internalname), 1) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Invoice Detail Modified Date"}), 1, "INVOICEDETAILMODIFIEDDATE");
                  AnyError = 1;
                  GX_FocusControl = edtInvoiceDetailModifiedDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A43InvoiceDetailModifiedDate = DateTime.MinValue;
                  AssignAttri("", false, "A43InvoiceDetailModifiedDate", context.localUtil.Format(A43InvoiceDetailModifiedDate, "99/99/99"));
               }
               else
               {
                  A43InvoiceDetailModifiedDate = context.localUtil.CToD( cgiGet( edtInvoiceDetailModifiedDate_Internalname), 1);
                  AssignAttri("", false, "A43InvoiceDetailModifiedDate", context.localUtil.Format(A43InvoiceDetailModifiedDate, "99/99/99"));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"InvoiceDetail");
               A25InvoiceDetailId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtInvoiceDetailId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A25InvoiceDetailId", StringUtil.LTrimStr( (decimal)(A25InvoiceDetailId), 6, 0));
               forbiddenHiddens.Add("InvoiceDetailId", context.localUtil.Format( (decimal)(A25InvoiceDetailId), "ZZZZZ9"));
               A42InvoiceDetailCreatedDate = context.localUtil.CToD( cgiGet( edtInvoiceDetailCreatedDate_Internalname), 1);
               AssignAttri("", false, "A42InvoiceDetailCreatedDate", context.localUtil.Format(A42InvoiceDetailCreatedDate, "99/99/99"));
               forbiddenHiddens.Add("InvoiceDetailCreatedDate", context.localUtil.Format(A42InvoiceDetailCreatedDate, "99/99/99"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A25InvoiceDetailId != Z25InvoiceDetailId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("invoicedetail:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A25InvoiceDetailId = (int)(Math.Round(NumberUtil.Val( GetPar( "InvoiceDetailId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A25InvoiceDetailId", StringUtil.LTrimStr( (decimal)(A25InvoiceDetailId), 6, 0));
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
                     sMode8 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode8;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound8 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_080( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "INVOICEDETAILID");
                        AnyError = 1;
                        GX_FocusControl = edtInvoiceDetailId_Internalname;
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
                           E11082 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12082 ();
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
            E12082 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll088( ) ;
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
            DisableAttributes088( ) ;
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

      protected void CONFIRM_080( )
      {
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls088( ) ;
            }
            else
            {
               CheckExtendedTable088( ) ;
               CloseExtendedTableCursors088( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption080( )
      {
      }

      protected void E11082( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV16Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV16Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         AV11Insert_InvoiceId = 0;
         AssignAttri("", false, "AV11Insert_InvoiceId", StringUtil.LTrimStr( (decimal)(AV11Insert_InvoiceId), 6, 0));
         AV12Insert_ProductId = 0;
         AssignAttri("", false, "AV12Insert_ProductId", StringUtil.LTrimStr( (decimal)(AV12Insert_ProductId), 6, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV16Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV17GXV1 = 1;
            AssignAttri("", false, "AV17GXV1", StringUtil.LTrimStr( (decimal)(AV17GXV1), 8, 0));
            while ( AV17GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((GeneXus.Programs.general.ui.SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV17GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "InvoiceId") == 0 )
               {
                  AV11Insert_InvoiceId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_InvoiceId", StringUtil.LTrimStr( (decimal)(AV11Insert_InvoiceId), 6, 0));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "ProductId") == 0 )
               {
                  AV12Insert_ProductId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV12Insert_ProductId", StringUtil.LTrimStr( (decimal)(AV12Insert_ProductId), 6, 0));
               }
               AV17GXV1 = (int)(AV17GXV1+1);
               AssignAttri("", false, "AV17GXV1", StringUtil.LTrimStr( (decimal)(AV17GXV1), 8, 0));
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

      protected void E12082( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwinvoicedetail.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM088( short GX_JID )
      {
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z26InvoiceDetailQuantity = T00083_A26InvoiceDetailQuantity[0];
               Z27InvoiceDetailHistoricalPrice = T00083_A27InvoiceDetailHistoricalPrice[0];
               Z42InvoiceDetailCreatedDate = T00083_A42InvoiceDetailCreatedDate[0];
               Z43InvoiceDetailModifiedDate = T00083_A43InvoiceDetailModifiedDate[0];
               Z20InvoiceId = T00083_A20InvoiceId[0];
               Z15ProductId = T00083_A15ProductId[0];
            }
            else
            {
               Z26InvoiceDetailQuantity = A26InvoiceDetailQuantity;
               Z27InvoiceDetailHistoricalPrice = A27InvoiceDetailHistoricalPrice;
               Z42InvoiceDetailCreatedDate = A42InvoiceDetailCreatedDate;
               Z43InvoiceDetailModifiedDate = A43InvoiceDetailModifiedDate;
               Z20InvoiceId = A20InvoiceId;
               Z15ProductId = A15ProductId;
            }
         }
         if ( GX_JID == -14 )
         {
            Z25InvoiceDetailId = A25InvoiceDetailId;
            Z26InvoiceDetailQuantity = A26InvoiceDetailQuantity;
            Z27InvoiceDetailHistoricalPrice = A27InvoiceDetailHistoricalPrice;
            Z42InvoiceDetailCreatedDate = A42InvoiceDetailCreatedDate;
            Z43InvoiceDetailModifiedDate = A43InvoiceDetailModifiedDate;
            Z20InvoiceId = A20InvoiceId;
            Z15ProductId = A15ProductId;
         }
      }

      protected void standaloneNotModal( )
      {
         edtInvoiceDetailId_Enabled = 0;
         AssignProp("", false, edtInvoiceDetailId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceDetailId_Enabled), 5, 0), true);
         edtInvoiceDetailCreatedDate_Enabled = 0;
         AssignProp("", false, edtInvoiceDetailCreatedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceDetailCreatedDate_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         Gx_date = DateTimeUtil.Today( context);
         AssignAttri("", false, "Gx_date", context.localUtil.Format(Gx_date, "99/99/99"));
         imgprompt_20_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0060.aspx"+"',["+"{Ctrl:gx.dom.el('"+"INVOICEID"+"'), id:'"+"INVOICEID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_15_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0050.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PRODUCTID"+"'), id:'"+"PRODUCTID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtInvoiceDetailId_Enabled = 0;
         AssignProp("", false, edtInvoiceDetailId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceDetailId_Enabled), 5, 0), true);
         edtInvoiceDetailCreatedDate_Enabled = 0;
         AssignProp("", false, edtInvoiceDetailCreatedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceDetailCreatedDate_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7InvoiceDetailId) )
         {
            A25InvoiceDetailId = AV7InvoiceDetailId;
            AssignAttri("", false, "A25InvoiceDetailId", StringUtil.LTrimStr( (decimal)(A25InvoiceDetailId), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_InvoiceId) )
         {
            edtInvoiceId_Enabled = 0;
            AssignProp("", false, edtInvoiceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceId_Enabled), 5, 0), true);
         }
         else
         {
            edtInvoiceId_Enabled = 1;
            AssignProp("", false, edtInvoiceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceId_Enabled), 5, 0), true);
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_InvoiceId) )
         {
            A20InvoiceId = AV11Insert_InvoiceId;
            AssignAttri("", false, "A20InvoiceId", StringUtil.LTrimStr( (decimal)(A20InvoiceId), 6, 0));
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
         if ( IsIns( )  && (DateTime.MinValue==A42InvoiceDetailCreatedDate) && ( Gx_BScreen == 0 ) )
         {
            A42InvoiceDetailCreatedDate = Gx_date;
            AssignAttri("", false, "A42InvoiceDetailCreatedDate", context.localUtil.Format(A42InvoiceDetailCreatedDate, "99/99/99"));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV16Pgmname = "InvoiceDetail";
            AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
         }
      }

      protected void Load088( )
      {
         /* Using cursor T00086 */
         pr_default.execute(4, new Object[] {A25InvoiceDetailId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound8 = 1;
            A26InvoiceDetailQuantity = T00086_A26InvoiceDetailQuantity[0];
            AssignAttri("", false, "A26InvoiceDetailQuantity", StringUtil.LTrimStr( (decimal)(A26InvoiceDetailQuantity), 6, 0));
            A27InvoiceDetailHistoricalPrice = T00086_A27InvoiceDetailHistoricalPrice[0];
            AssignAttri("", false, "A27InvoiceDetailHistoricalPrice", StringUtil.LTrimStr( A27InvoiceDetailHistoricalPrice, 10, 2));
            A42InvoiceDetailCreatedDate = T00086_A42InvoiceDetailCreatedDate[0];
            AssignAttri("", false, "A42InvoiceDetailCreatedDate", context.localUtil.Format(A42InvoiceDetailCreatedDate, "99/99/99"));
            A43InvoiceDetailModifiedDate = T00086_A43InvoiceDetailModifiedDate[0];
            AssignAttri("", false, "A43InvoiceDetailModifiedDate", context.localUtil.Format(A43InvoiceDetailModifiedDate, "99/99/99"));
            A20InvoiceId = T00086_A20InvoiceId[0];
            AssignAttri("", false, "A20InvoiceId", StringUtil.LTrimStr( (decimal)(A20InvoiceId), 6, 0));
            A15ProductId = T00086_A15ProductId[0];
            AssignAttri("", false, "A15ProductId", StringUtil.LTrimStr( (decimal)(A15ProductId), 6, 0));
            ZM088( -14) ;
         }
         pr_default.close(4);
         OnLoadActions088( ) ;
      }

      protected void OnLoadActions088( )
      {
         AV16Pgmname = "InvoiceDetail";
         AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
      }

      protected void CheckExtendedTable088( )
      {
         nIsDirty_8 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV16Pgmname = "InvoiceDetail";
         AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
         /* Using cursor T00084 */
         pr_default.execute(2, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'Invoice'.", "ForeignKeyNotFound", 1, "INVOICEID");
            AnyError = 1;
            GX_FocusControl = edtInvoiceId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T00085 */
         pr_default.execute(3, new Object[] {A15ProductId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No matching 'Product'.", "ForeignKeyNotFound", 1, "PRODUCTID");
            AnyError = 1;
            GX_FocusControl = edtProductId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         if ( ! ( (DateTime.MinValue==A43InvoiceDetailModifiedDate) || ( DateTimeUtil.ResetTime ( A43InvoiceDetailModifiedDate ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Invoice Detail Modified Date is out of range", "OutOfRange", 1, "INVOICEDETAILMODIFIEDDATE");
            AnyError = 1;
            GX_FocusControl = edtInvoiceDetailModifiedDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors088( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_15( int A20InvoiceId )
      {
         /* Using cursor T00087 */
         pr_default.execute(5, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No matching 'Invoice'.", "ForeignKeyNotFound", 1, "INVOICEID");
            AnyError = 1;
            GX_FocusControl = edtInvoiceId_Internalname;
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

      protected void gxLoad_16( int A15ProductId )
      {
         /* Using cursor T00088 */
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

      protected void GetKey088( )
      {
         /* Using cursor T00089 */
         pr_default.execute(7, new Object[] {A25InvoiceDetailId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound8 = 1;
         }
         else
         {
            RcdFound8 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00083 */
         pr_default.execute(1, new Object[] {A25InvoiceDetailId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM088( 14) ;
            RcdFound8 = 1;
            A25InvoiceDetailId = T00083_A25InvoiceDetailId[0];
            AssignAttri("", false, "A25InvoiceDetailId", StringUtil.LTrimStr( (decimal)(A25InvoiceDetailId), 6, 0));
            A26InvoiceDetailQuantity = T00083_A26InvoiceDetailQuantity[0];
            AssignAttri("", false, "A26InvoiceDetailQuantity", StringUtil.LTrimStr( (decimal)(A26InvoiceDetailQuantity), 6, 0));
            A27InvoiceDetailHistoricalPrice = T00083_A27InvoiceDetailHistoricalPrice[0];
            AssignAttri("", false, "A27InvoiceDetailHistoricalPrice", StringUtil.LTrimStr( A27InvoiceDetailHistoricalPrice, 10, 2));
            A42InvoiceDetailCreatedDate = T00083_A42InvoiceDetailCreatedDate[0];
            AssignAttri("", false, "A42InvoiceDetailCreatedDate", context.localUtil.Format(A42InvoiceDetailCreatedDate, "99/99/99"));
            A43InvoiceDetailModifiedDate = T00083_A43InvoiceDetailModifiedDate[0];
            AssignAttri("", false, "A43InvoiceDetailModifiedDate", context.localUtil.Format(A43InvoiceDetailModifiedDate, "99/99/99"));
            A20InvoiceId = T00083_A20InvoiceId[0];
            AssignAttri("", false, "A20InvoiceId", StringUtil.LTrimStr( (decimal)(A20InvoiceId), 6, 0));
            A15ProductId = T00083_A15ProductId[0];
            AssignAttri("", false, "A15ProductId", StringUtil.LTrimStr( (decimal)(A15ProductId), 6, 0));
            Z25InvoiceDetailId = A25InvoiceDetailId;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load088( ) ;
            if ( AnyError == 1 )
            {
               RcdFound8 = 0;
               InitializeNonKey088( ) ;
            }
            Gx_mode = sMode8;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound8 = 0;
            InitializeNonKey088( ) ;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode8;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey088( ) ;
         if ( RcdFound8 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound8 = 0;
         /* Using cursor T000810 */
         pr_default.execute(8, new Object[] {A25InvoiceDetailId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000810_A25InvoiceDetailId[0] < A25InvoiceDetailId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000810_A25InvoiceDetailId[0] > A25InvoiceDetailId ) ) )
            {
               A25InvoiceDetailId = T000810_A25InvoiceDetailId[0];
               AssignAttri("", false, "A25InvoiceDetailId", StringUtil.LTrimStr( (decimal)(A25InvoiceDetailId), 6, 0));
               RcdFound8 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound8 = 0;
         /* Using cursor T000811 */
         pr_default.execute(9, new Object[] {A25InvoiceDetailId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000811_A25InvoiceDetailId[0] > A25InvoiceDetailId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000811_A25InvoiceDetailId[0] < A25InvoiceDetailId ) ) )
            {
               A25InvoiceDetailId = T000811_A25InvoiceDetailId[0];
               AssignAttri("", false, "A25InvoiceDetailId", StringUtil.LTrimStr( (decimal)(A25InvoiceDetailId), 6, 0));
               RcdFound8 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey088( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtInvoiceId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert088( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound8 == 1 )
            {
               if ( A25InvoiceDetailId != Z25InvoiceDetailId )
               {
                  A25InvoiceDetailId = Z25InvoiceDetailId;
                  AssignAttri("", false, "A25InvoiceDetailId", StringUtil.LTrimStr( (decimal)(A25InvoiceDetailId), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "INVOICEDETAILID");
                  AnyError = 1;
                  GX_FocusControl = edtInvoiceDetailId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtInvoiceId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update088( ) ;
                  GX_FocusControl = edtInvoiceId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A25InvoiceDetailId != Z25InvoiceDetailId )
               {
                  /* Insert record */
                  GX_FocusControl = edtInvoiceId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert088( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "INVOICEDETAILID");
                     AnyError = 1;
                     GX_FocusControl = edtInvoiceDetailId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtInvoiceId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert088( ) ;
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
         if ( A25InvoiceDetailId != Z25InvoiceDetailId )
         {
            A25InvoiceDetailId = Z25InvoiceDetailId;
            AssignAttri("", false, "A25InvoiceDetailId", StringUtil.LTrimStr( (decimal)(A25InvoiceDetailId), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "INVOICEDETAILID");
            AnyError = 1;
            GX_FocusControl = edtInvoiceDetailId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtInvoiceId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency088( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00082 */
            pr_default.execute(0, new Object[] {A25InvoiceDetailId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"InvoiceDetail"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z26InvoiceDetailQuantity != T00082_A26InvoiceDetailQuantity[0] ) || ( Z27InvoiceDetailHistoricalPrice != T00082_A27InvoiceDetailHistoricalPrice[0] ) || ( DateTimeUtil.ResetTime ( Z42InvoiceDetailCreatedDate ) != DateTimeUtil.ResetTime ( T00082_A42InvoiceDetailCreatedDate[0] ) ) || ( DateTimeUtil.ResetTime ( Z43InvoiceDetailModifiedDate ) != DateTimeUtil.ResetTime ( T00082_A43InvoiceDetailModifiedDate[0] ) ) || ( Z20InvoiceId != T00082_A20InvoiceId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z15ProductId != T00082_A15ProductId[0] ) )
            {
               if ( Z26InvoiceDetailQuantity != T00082_A26InvoiceDetailQuantity[0] )
               {
                  GXUtil.WriteLog("invoicedetail:[seudo value changed for attri]"+"InvoiceDetailQuantity");
                  GXUtil.WriteLogRaw("Old: ",Z26InvoiceDetailQuantity);
                  GXUtil.WriteLogRaw("Current: ",T00082_A26InvoiceDetailQuantity[0]);
               }
               if ( Z27InvoiceDetailHistoricalPrice != T00082_A27InvoiceDetailHistoricalPrice[0] )
               {
                  GXUtil.WriteLog("invoicedetail:[seudo value changed for attri]"+"InvoiceDetailHistoricalPrice");
                  GXUtil.WriteLogRaw("Old: ",Z27InvoiceDetailHistoricalPrice);
                  GXUtil.WriteLogRaw("Current: ",T00082_A27InvoiceDetailHistoricalPrice[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z42InvoiceDetailCreatedDate ) != DateTimeUtil.ResetTime ( T00082_A42InvoiceDetailCreatedDate[0] ) )
               {
                  GXUtil.WriteLog("invoicedetail:[seudo value changed for attri]"+"InvoiceDetailCreatedDate");
                  GXUtil.WriteLogRaw("Old: ",Z42InvoiceDetailCreatedDate);
                  GXUtil.WriteLogRaw("Current: ",T00082_A42InvoiceDetailCreatedDate[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z43InvoiceDetailModifiedDate ) != DateTimeUtil.ResetTime ( T00082_A43InvoiceDetailModifiedDate[0] ) )
               {
                  GXUtil.WriteLog("invoicedetail:[seudo value changed for attri]"+"InvoiceDetailModifiedDate");
                  GXUtil.WriteLogRaw("Old: ",Z43InvoiceDetailModifiedDate);
                  GXUtil.WriteLogRaw("Current: ",T00082_A43InvoiceDetailModifiedDate[0]);
               }
               if ( Z20InvoiceId != T00082_A20InvoiceId[0] )
               {
                  GXUtil.WriteLog("invoicedetail:[seudo value changed for attri]"+"InvoiceId");
                  GXUtil.WriteLogRaw("Old: ",Z20InvoiceId);
                  GXUtil.WriteLogRaw("Current: ",T00082_A20InvoiceId[0]);
               }
               if ( Z15ProductId != T00082_A15ProductId[0] )
               {
                  GXUtil.WriteLog("invoicedetail:[seudo value changed for attri]"+"ProductId");
                  GXUtil.WriteLogRaw("Old: ",Z15ProductId);
                  GXUtil.WriteLogRaw("Current: ",T00082_A15ProductId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"InvoiceDetail"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert088( )
      {
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable088( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM088( 0) ;
            CheckOptimisticConcurrency088( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm088( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert088( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000812 */
                     pr_default.execute(10, new Object[] {A26InvoiceDetailQuantity, A27InvoiceDetailHistoricalPrice, A42InvoiceDetailCreatedDate, A43InvoiceDetailModifiedDate, A20InvoiceId, A15ProductId});
                     A25InvoiceDetailId = T000812_A25InvoiceDetailId[0];
                     AssignAttri("", false, "A25InvoiceDetailId", StringUtil.LTrimStr( (decimal)(A25InvoiceDetailId), 6, 0));
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("InvoiceDetail");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption080( ) ;
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
               Load088( ) ;
            }
            EndLevel088( ) ;
         }
         CloseExtendedTableCursors088( ) ;
      }

      protected void Update088( )
      {
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable088( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency088( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm088( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate088( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000813 */
                     pr_default.execute(11, new Object[] {A26InvoiceDetailQuantity, A27InvoiceDetailHistoricalPrice, A42InvoiceDetailCreatedDate, A43InvoiceDetailModifiedDate, A20InvoiceId, A15ProductId, A25InvoiceDetailId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("InvoiceDetail");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"InvoiceDetail"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate088( ) ;
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
            EndLevel088( ) ;
         }
         CloseExtendedTableCursors088( ) ;
      }

      protected void DeferredUpdate088( )
      {
      }

      protected void delete( )
      {
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency088( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls088( ) ;
            AfterConfirm088( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete088( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000814 */
                  pr_default.execute(12, new Object[] {A25InvoiceDetailId});
                  pr_default.close(12);
                  pr_default.SmartCacheProvider.SetUpdated("InvoiceDetail");
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
         sMode8 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel088( ) ;
         Gx_mode = sMode8;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls088( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV16Pgmname = "InvoiceDetail";
            AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
         }
      }

      protected void EndLevel088( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete088( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("invoicedetail",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues080( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("invoicedetail",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart088( )
      {
         /* Scan By routine */
         /* Using cursor T000815 */
         pr_default.execute(13);
         RcdFound8 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound8 = 1;
            A25InvoiceDetailId = T000815_A25InvoiceDetailId[0];
            AssignAttri("", false, "A25InvoiceDetailId", StringUtil.LTrimStr( (decimal)(A25InvoiceDetailId), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext088( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound8 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound8 = 1;
            A25InvoiceDetailId = T000815_A25InvoiceDetailId[0];
            AssignAttri("", false, "A25InvoiceDetailId", StringUtil.LTrimStr( (decimal)(A25InvoiceDetailId), 6, 0));
         }
      }

      protected void ScanEnd088( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm088( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert088( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate088( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete088( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete088( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate088( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes088( )
      {
         edtInvoiceDetailId_Enabled = 0;
         AssignProp("", false, edtInvoiceDetailId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceDetailId_Enabled), 5, 0), true);
         edtInvoiceId_Enabled = 0;
         AssignProp("", false, edtInvoiceId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceId_Enabled), 5, 0), true);
         edtProductId_Enabled = 0;
         AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), true);
         edtInvoiceDetailQuantity_Enabled = 0;
         AssignProp("", false, edtInvoiceDetailQuantity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceDetailQuantity_Enabled), 5, 0), true);
         edtInvoiceDetailHistoricalPrice_Enabled = 0;
         AssignProp("", false, edtInvoiceDetailHistoricalPrice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceDetailHistoricalPrice_Enabled), 5, 0), true);
         edtInvoiceDetailCreatedDate_Enabled = 0;
         AssignProp("", false, edtInvoiceDetailCreatedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceDetailCreatedDate_Enabled), 5, 0), true);
         edtInvoiceDetailModifiedDate_Enabled = 0;
         AssignProp("", false, edtInvoiceDetailModifiedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvoiceDetailModifiedDate_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes088( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues080( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("invoicedetail.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7InvoiceDetailId,6,0))}, new string[] {"Gx_mode","InvoiceDetailId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"InvoiceDetail");
         forbiddenHiddens.Add("InvoiceDetailId", context.localUtil.Format( (decimal)(A25InvoiceDetailId), "ZZZZZ9"));
         forbiddenHiddens.Add("InvoiceDetailCreatedDate", context.localUtil.Format(A42InvoiceDetailCreatedDate, "99/99/99"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("invoicedetail:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z25InvoiceDetailId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z25InvoiceDetailId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z26InvoiceDetailQuantity", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z26InvoiceDetailQuantity), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z27InvoiceDetailHistoricalPrice", StringUtil.LTrim( StringUtil.NToC( Z27InvoiceDetailHistoricalPrice, 10, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z42InvoiceDetailCreatedDate", context.localUtil.DToC( Z42InvoiceDetailCreatedDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z43InvoiceDetailModifiedDate", context.localUtil.DToC( Z43InvoiceDetailModifiedDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z20InvoiceId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z20InvoiceId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z15ProductId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z15ProductId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N20InvoiceId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A20InvoiceId), 6, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "vINVOICEDETAILID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7InvoiceDetailId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vINVOICEDETAILID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7InvoiceDetailId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_INVOICEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_InvoiceId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_PRODUCTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_ProductId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV16Pgmname));
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
         return formatLink("invoicedetail.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7InvoiceDetailId,6,0))}, new string[] {"Gx_mode","InvoiceDetailId"})  ;
      }

      public override string GetPgmname( )
      {
         return "InvoiceDetail" ;
      }

      public override string GetPgmdesc( )
      {
         return "Invoice Detail" ;
      }

      protected void InitializeNonKey088( )
      {
         A20InvoiceId = 0;
         AssignAttri("", false, "A20InvoiceId", StringUtil.LTrimStr( (decimal)(A20InvoiceId), 6, 0));
         A15ProductId = 0;
         AssignAttri("", false, "A15ProductId", StringUtil.LTrimStr( (decimal)(A15ProductId), 6, 0));
         A26InvoiceDetailQuantity = 0;
         AssignAttri("", false, "A26InvoiceDetailQuantity", StringUtil.LTrimStr( (decimal)(A26InvoiceDetailQuantity), 6, 0));
         A27InvoiceDetailHistoricalPrice = 0;
         AssignAttri("", false, "A27InvoiceDetailHistoricalPrice", StringUtil.LTrimStr( A27InvoiceDetailHistoricalPrice, 10, 2));
         A43InvoiceDetailModifiedDate = DateTime.MinValue;
         AssignAttri("", false, "A43InvoiceDetailModifiedDate", context.localUtil.Format(A43InvoiceDetailModifiedDate, "99/99/99"));
         A42InvoiceDetailCreatedDate = Gx_date;
         AssignAttri("", false, "A42InvoiceDetailCreatedDate", context.localUtil.Format(A42InvoiceDetailCreatedDate, "99/99/99"));
         Z26InvoiceDetailQuantity = 0;
         Z27InvoiceDetailHistoricalPrice = 0;
         Z42InvoiceDetailCreatedDate = DateTime.MinValue;
         Z43InvoiceDetailModifiedDate = DateTime.MinValue;
         Z20InvoiceId = 0;
         Z15ProductId = 0;
      }

      protected void InitAll088( )
      {
         A25InvoiceDetailId = 0;
         AssignAttri("", false, "A25InvoiceDetailId", StringUtil.LTrimStr( (decimal)(A25InvoiceDetailId), 6, 0));
         InitializeNonKey088( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A42InvoiceDetailCreatedDate = i42InvoiceDetailCreatedDate;
         AssignAttri("", false, "A42InvoiceDetailCreatedDate", context.localUtil.Format(A42InvoiceDetailCreatedDate, "99/99/99"));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20231122039277", true, true);
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
         context.AddJavascriptSource("invoicedetail.js", "?20231122039278", false, true);
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
         edtInvoiceDetailId_Internalname = "INVOICEDETAILID";
         edtInvoiceId_Internalname = "INVOICEID";
         edtProductId_Internalname = "PRODUCTID";
         edtInvoiceDetailQuantity_Internalname = "INVOICEDETAILQUANTITY";
         edtInvoiceDetailHistoricalPrice_Internalname = "INVOICEDETAILHISTORICALPRICE";
         edtInvoiceDetailCreatedDate_Internalname = "INVOICEDETAILCREATEDDATE";
         edtInvoiceDetailModifiedDate_Internalname = "INVOICEDETAILMODIFIEDDATE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_20_Internalname = "PROMPT_20";
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
         Form.Caption = "Invoice Detail";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirm";
         bttBtn_enter_Caption = "Confirm";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtInvoiceDetailModifiedDate_Jsonclick = "";
         edtInvoiceDetailModifiedDate_Enabled = 1;
         edtInvoiceDetailCreatedDate_Jsonclick = "";
         edtInvoiceDetailCreatedDate_Enabled = 0;
         edtInvoiceDetailHistoricalPrice_Jsonclick = "";
         edtInvoiceDetailHistoricalPrice_Enabled = 1;
         edtInvoiceDetailQuantity_Jsonclick = "";
         edtInvoiceDetailQuantity_Enabled = 1;
         imgprompt_15_Visible = 1;
         imgprompt_15_Link = "";
         edtProductId_Jsonclick = "";
         edtProductId_Enabled = 1;
         imgprompt_20_Visible = 1;
         imgprompt_20_Link = "";
         edtInvoiceId_Jsonclick = "";
         edtInvoiceId_Enabled = 1;
         edtInvoiceDetailId_Jsonclick = "";
         edtInvoiceDetailId_Enabled = 0;
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

      public void Valid_Invoiceid( )
      {
         /* Using cursor T000816 */
         pr_default.execute(14, new Object[] {A20InvoiceId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No matching 'Invoice'.", "ForeignKeyNotFound", 1, "INVOICEID");
            AnyError = 1;
            GX_FocusControl = edtInvoiceId_Internalname;
         }
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Productid( )
      {
         /* Using cursor T000817 */
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7InvoiceDetailId',fld:'vINVOICEDETAILID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7InvoiceDetailId',fld:'vINVOICEDETAILID',pic:'ZZZZZ9',hsh:true},{av:'A25InvoiceDetailId',fld:'INVOICEDETAILID',pic:'ZZZZZ9'},{av:'A42InvoiceDetailCreatedDate',fld:'INVOICEDETAILCREATEDDATE',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12082',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_INVOICEDETAILID","{handler:'Valid_Invoicedetailid',iparms:[]");
         setEventMetadata("VALID_INVOICEDETAILID",",oparms:[]}");
         setEventMetadata("VALID_INVOICEID","{handler:'Valid_Invoiceid',iparms:[{av:'A20InvoiceId',fld:'INVOICEID',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_INVOICEID",",oparms:[]}");
         setEventMetadata("VALID_PRODUCTID","{handler:'Valid_Productid',iparms:[{av:'A15ProductId',fld:'PRODUCTID',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_PRODUCTID",",oparms:[]}");
         setEventMetadata("VALID_INVOICEDETAILMODIFIEDDATE","{handler:'Valid_Invoicedetailmodifieddate',iparms:[]");
         setEventMetadata("VALID_INVOICEDETAILMODIFIEDDATE",",oparms:[]}");
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
         pr_default.close(14);
         pr_default.close(15);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z42InvoiceDetailCreatedDate = DateTime.MinValue;
         Z43InvoiceDetailModifiedDate = DateTime.MinValue;
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
         imgprompt_20_gximage = "";
         sImgUrl = "";
         imgprompt_15_gximage = "";
         A42InvoiceDetailCreatedDate = DateTime.MinValue;
         A43InvoiceDetailModifiedDate = DateTime.MinValue;
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_date = DateTime.MinValue;
         AV16Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode8 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV13TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         T00086_A25InvoiceDetailId = new int[1] ;
         T00086_A26InvoiceDetailQuantity = new int[1] ;
         T00086_A27InvoiceDetailHistoricalPrice = new decimal[1] ;
         T00086_A42InvoiceDetailCreatedDate = new DateTime[] {DateTime.MinValue} ;
         T00086_A43InvoiceDetailModifiedDate = new DateTime[] {DateTime.MinValue} ;
         T00086_A20InvoiceId = new int[1] ;
         T00086_A15ProductId = new int[1] ;
         T00084_A20InvoiceId = new int[1] ;
         T00085_A15ProductId = new int[1] ;
         T00087_A20InvoiceId = new int[1] ;
         T00088_A15ProductId = new int[1] ;
         T00089_A25InvoiceDetailId = new int[1] ;
         T00083_A25InvoiceDetailId = new int[1] ;
         T00083_A26InvoiceDetailQuantity = new int[1] ;
         T00083_A27InvoiceDetailHistoricalPrice = new decimal[1] ;
         T00083_A42InvoiceDetailCreatedDate = new DateTime[] {DateTime.MinValue} ;
         T00083_A43InvoiceDetailModifiedDate = new DateTime[] {DateTime.MinValue} ;
         T00083_A20InvoiceId = new int[1] ;
         T00083_A15ProductId = new int[1] ;
         T000810_A25InvoiceDetailId = new int[1] ;
         T000811_A25InvoiceDetailId = new int[1] ;
         T00082_A25InvoiceDetailId = new int[1] ;
         T00082_A26InvoiceDetailQuantity = new int[1] ;
         T00082_A27InvoiceDetailHistoricalPrice = new decimal[1] ;
         T00082_A42InvoiceDetailCreatedDate = new DateTime[] {DateTime.MinValue} ;
         T00082_A43InvoiceDetailModifiedDate = new DateTime[] {DateTime.MinValue} ;
         T00082_A20InvoiceId = new int[1] ;
         T00082_A15ProductId = new int[1] ;
         T000812_A25InvoiceDetailId = new int[1] ;
         T000815_A25InvoiceDetailId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i42InvoiceDetailCreatedDate = DateTime.MinValue;
         T000816_A20InvoiceId = new int[1] ;
         T000817_A15ProductId = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.invoicedetail__default(),
            new Object[][] {
                new Object[] {
               T00082_A25InvoiceDetailId, T00082_A26InvoiceDetailQuantity, T00082_A27InvoiceDetailHistoricalPrice, T00082_A42InvoiceDetailCreatedDate, T00082_A43InvoiceDetailModifiedDate, T00082_A20InvoiceId, T00082_A15ProductId
               }
               , new Object[] {
               T00083_A25InvoiceDetailId, T00083_A26InvoiceDetailQuantity, T00083_A27InvoiceDetailHistoricalPrice, T00083_A42InvoiceDetailCreatedDate, T00083_A43InvoiceDetailModifiedDate, T00083_A20InvoiceId, T00083_A15ProductId
               }
               , new Object[] {
               T00084_A20InvoiceId
               }
               , new Object[] {
               T00085_A15ProductId
               }
               , new Object[] {
               T00086_A25InvoiceDetailId, T00086_A26InvoiceDetailQuantity, T00086_A27InvoiceDetailHistoricalPrice, T00086_A42InvoiceDetailCreatedDate, T00086_A43InvoiceDetailModifiedDate, T00086_A20InvoiceId, T00086_A15ProductId
               }
               , new Object[] {
               T00087_A20InvoiceId
               }
               , new Object[] {
               T00088_A15ProductId
               }
               , new Object[] {
               T00089_A25InvoiceDetailId
               }
               , new Object[] {
               T000810_A25InvoiceDetailId
               }
               , new Object[] {
               T000811_A25InvoiceDetailId
               }
               , new Object[] {
               T000812_A25InvoiceDetailId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000815_A25InvoiceDetailId
               }
               , new Object[] {
               T000816_A20InvoiceId
               }
               , new Object[] {
               T000817_A15ProductId
               }
            }
         );
         AV16Pgmname = "InvoiceDetail";
         Z42InvoiceDetailCreatedDate = DateTime.MinValue;
         A42InvoiceDetailCreatedDate = DateTime.MinValue;
         i42InvoiceDetailCreatedDate = DateTime.MinValue;
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
      private short RcdFound8 ;
      private short GX_JID ;
      private short nIsDirty_8 ;
      private short gxajaxcallmode ;
      private int wcpOAV7InvoiceDetailId ;
      private int Z25InvoiceDetailId ;
      private int Z26InvoiceDetailQuantity ;
      private int Z20InvoiceId ;
      private int Z15ProductId ;
      private int N20InvoiceId ;
      private int N15ProductId ;
      private int A20InvoiceId ;
      private int A15ProductId ;
      private int AV7InvoiceDetailId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A25InvoiceDetailId ;
      private int edtInvoiceDetailId_Enabled ;
      private int edtInvoiceId_Enabled ;
      private int imgprompt_20_Visible ;
      private int edtProductId_Enabled ;
      private int imgprompt_15_Visible ;
      private int A26InvoiceDetailQuantity ;
      private int edtInvoiceDetailQuantity_Enabled ;
      private int edtInvoiceDetailHistoricalPrice_Enabled ;
      private int edtInvoiceDetailCreatedDate_Enabled ;
      private int edtInvoiceDetailModifiedDate_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int AV11Insert_InvoiceId ;
      private int AV12Insert_ProductId ;
      private int AV17GXV1 ;
      private int idxLst ;
      private decimal Z27InvoiceDetailHistoricalPrice ;
      private decimal A27InvoiceDetailHistoricalPrice ;
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
      private string edtInvoiceId_Internalname ;
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
      private string edtInvoiceDetailId_Internalname ;
      private string edtInvoiceDetailId_Jsonclick ;
      private string edtInvoiceId_Jsonclick ;
      private string imgprompt_20_gximage ;
      private string sImgUrl ;
      private string imgprompt_20_Internalname ;
      private string imgprompt_20_Link ;
      private string edtProductId_Internalname ;
      private string edtProductId_Jsonclick ;
      private string imgprompt_15_gximage ;
      private string imgprompt_15_Internalname ;
      private string imgprompt_15_Link ;
      private string edtInvoiceDetailQuantity_Internalname ;
      private string edtInvoiceDetailQuantity_Jsonclick ;
      private string edtInvoiceDetailHistoricalPrice_Internalname ;
      private string edtInvoiceDetailHistoricalPrice_Jsonclick ;
      private string edtInvoiceDetailCreatedDate_Internalname ;
      private string edtInvoiceDetailCreatedDate_Jsonclick ;
      private string edtInvoiceDetailModifiedDate_Internalname ;
      private string edtInvoiceDetailModifiedDate_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Caption ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_enter_Tooltiptext ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV16Pgmname ;
      private string hsh ;
      private string sMode8 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z42InvoiceDetailCreatedDate ;
      private DateTime Z43InvoiceDetailModifiedDate ;
      private DateTime A42InvoiceDetailCreatedDate ;
      private DateTime A43InvoiceDetailModifiedDate ;
      private DateTime Gx_date ;
      private DateTime i42InvoiceDetailCreatedDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T00086_A25InvoiceDetailId ;
      private int[] T00086_A26InvoiceDetailQuantity ;
      private decimal[] T00086_A27InvoiceDetailHistoricalPrice ;
      private DateTime[] T00086_A42InvoiceDetailCreatedDate ;
      private DateTime[] T00086_A43InvoiceDetailModifiedDate ;
      private int[] T00086_A20InvoiceId ;
      private int[] T00086_A15ProductId ;
      private int[] T00084_A20InvoiceId ;
      private int[] T00085_A15ProductId ;
      private int[] T00087_A20InvoiceId ;
      private int[] T00088_A15ProductId ;
      private int[] T00089_A25InvoiceDetailId ;
      private int[] T00083_A25InvoiceDetailId ;
      private int[] T00083_A26InvoiceDetailQuantity ;
      private decimal[] T00083_A27InvoiceDetailHistoricalPrice ;
      private DateTime[] T00083_A42InvoiceDetailCreatedDate ;
      private DateTime[] T00083_A43InvoiceDetailModifiedDate ;
      private int[] T00083_A20InvoiceId ;
      private int[] T00083_A15ProductId ;
      private int[] T000810_A25InvoiceDetailId ;
      private int[] T000811_A25InvoiceDetailId ;
      private int[] T00082_A25InvoiceDetailId ;
      private int[] T00082_A26InvoiceDetailQuantity ;
      private decimal[] T00082_A27InvoiceDetailHistoricalPrice ;
      private DateTime[] T00082_A42InvoiceDetailCreatedDate ;
      private DateTime[] T00082_A43InvoiceDetailModifiedDate ;
      private int[] T00082_A20InvoiceId ;
      private int[] T00082_A15ProductId ;
      private int[] T000812_A25InvoiceDetailId ;
      private int[] T000815_A25InvoiceDetailId ;
      private int[] T000816_A20InvoiceId ;
      private int[] T000817_A15ProductId ;
      private GXWebForm Form ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV13TrnContextAtt ;
   }

   public class invoicedetail__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT00086;
          prmT00086 = new Object[] {
          new ParDef("@InvoiceDetailId",GXType.Int32,6,0)
          };
          Object[] prmT00084;
          prmT00084 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmT00085;
          prmT00085 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmT00087;
          prmT00087 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmT00088;
          prmT00088 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmT00089;
          prmT00089 = new Object[] {
          new ParDef("@InvoiceDetailId",GXType.Int32,6,0)
          };
          Object[] prmT00083;
          prmT00083 = new Object[] {
          new ParDef("@InvoiceDetailId",GXType.Int32,6,0)
          };
          Object[] prmT000810;
          prmT000810 = new Object[] {
          new ParDef("@InvoiceDetailId",GXType.Int32,6,0)
          };
          Object[] prmT000811;
          prmT000811 = new Object[] {
          new ParDef("@InvoiceDetailId",GXType.Int32,6,0)
          };
          Object[] prmT00082;
          prmT00082 = new Object[] {
          new ParDef("@InvoiceDetailId",GXType.Int32,6,0)
          };
          Object[] prmT000812;
          prmT000812 = new Object[] {
          new ParDef("@InvoiceDetailQuantity",GXType.Int32,6,0) ,
          new ParDef("@InvoiceDetailHistoricalPrice",GXType.Decimal,10,2) ,
          new ParDef("@InvoiceDetailCreatedDate",GXType.Date,8,0) ,
          new ParDef("@InvoiceDetailModifiedDate",GXType.Date,8,0) ,
          new ParDef("@InvoiceId",GXType.Int32,6,0) ,
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmT000813;
          prmT000813 = new Object[] {
          new ParDef("@InvoiceDetailQuantity",GXType.Int32,6,0) ,
          new ParDef("@InvoiceDetailHistoricalPrice",GXType.Decimal,10,2) ,
          new ParDef("@InvoiceDetailCreatedDate",GXType.Date,8,0) ,
          new ParDef("@InvoiceDetailModifiedDate",GXType.Date,8,0) ,
          new ParDef("@InvoiceId",GXType.Int32,6,0) ,
          new ParDef("@ProductId",GXType.Int32,6,0) ,
          new ParDef("@InvoiceDetailId",GXType.Int32,6,0)
          };
          Object[] prmT000814;
          prmT000814 = new Object[] {
          new ParDef("@InvoiceDetailId",GXType.Int32,6,0)
          };
          Object[] prmT000815;
          prmT000815 = new Object[] {
          };
          Object[] prmT000816;
          prmT000816 = new Object[] {
          new ParDef("@InvoiceId",GXType.Int32,6,0)
          };
          Object[] prmT000817;
          prmT000817 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00082", "SELECT [InvoiceDetailId], [InvoiceDetailQuantity], [InvoiceDetailHistoricalPrice], [InvoiceDetailCreatedDate], [InvoiceDetailModifiedDate], [InvoiceId], [ProductId] FROM [InvoiceDetail] WITH (UPDLOCK) WHERE [InvoiceDetailId] = @InvoiceDetailId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00082,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00083", "SELECT [InvoiceDetailId], [InvoiceDetailQuantity], [InvoiceDetailHistoricalPrice], [InvoiceDetailCreatedDate], [InvoiceDetailModifiedDate], [InvoiceId], [ProductId] FROM [InvoiceDetail] WHERE [InvoiceDetailId] = @InvoiceDetailId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00083,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00084", "SELECT [InvoiceId] FROM [Invoice] WHERE [InvoiceId] = @InvoiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00084,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00085", "SELECT [ProductId] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00085,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00086", "SELECT TM1.[InvoiceDetailId], TM1.[InvoiceDetailQuantity], TM1.[InvoiceDetailHistoricalPrice], TM1.[InvoiceDetailCreatedDate], TM1.[InvoiceDetailModifiedDate], TM1.[InvoiceId], TM1.[ProductId] FROM [InvoiceDetail] TM1 WHERE TM1.[InvoiceDetailId] = @InvoiceDetailId ORDER BY TM1.[InvoiceDetailId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00086,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00087", "SELECT [InvoiceId] FROM [Invoice] WHERE [InvoiceId] = @InvoiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00087,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00088", "SELECT [ProductId] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00088,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00089", "SELECT [InvoiceDetailId] FROM [InvoiceDetail] WHERE [InvoiceDetailId] = @InvoiceDetailId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00089,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000810", "SELECT TOP 1 [InvoiceDetailId] FROM [InvoiceDetail] WHERE ( [InvoiceDetailId] > @InvoiceDetailId) ORDER BY [InvoiceDetailId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000810,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000811", "SELECT TOP 1 [InvoiceDetailId] FROM [InvoiceDetail] WHERE ( [InvoiceDetailId] < @InvoiceDetailId) ORDER BY [InvoiceDetailId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000811,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000812", "INSERT INTO [InvoiceDetail]([InvoiceDetailQuantity], [InvoiceDetailHistoricalPrice], [InvoiceDetailCreatedDate], [InvoiceDetailModifiedDate], [InvoiceId], [ProductId]) VALUES(@InvoiceDetailQuantity, @InvoiceDetailHistoricalPrice, @InvoiceDetailCreatedDate, @InvoiceDetailModifiedDate, @InvoiceId, @ProductId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000812,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000813", "UPDATE [InvoiceDetail] SET [InvoiceDetailQuantity]=@InvoiceDetailQuantity, [InvoiceDetailHistoricalPrice]=@InvoiceDetailHistoricalPrice, [InvoiceDetailCreatedDate]=@InvoiceDetailCreatedDate, [InvoiceDetailModifiedDate]=@InvoiceDetailModifiedDate, [InvoiceId]=@InvoiceId, [ProductId]=@ProductId  WHERE [InvoiceDetailId] = @InvoiceDetailId", GxErrorMask.GX_NOMASK,prmT000813)
             ,new CursorDef("T000814", "DELETE FROM [InvoiceDetail]  WHERE [InvoiceDetailId] = @InvoiceDetailId", GxErrorMask.GX_NOMASK,prmT000814)
             ,new CursorDef("T000815", "SELECT [InvoiceDetailId] FROM [InvoiceDetail] ORDER BY [InvoiceDetailId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000815,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000816", "SELECT [InvoiceId] FROM [Invoice] WHERE [InvoiceId] = @InvoiceId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000816,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000817", "SELECT [ProductId] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000817,1, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
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
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
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
