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
   public class historyofdircardedproducts : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_13") == 0 )
         {
            A15ProductId = (int)(Math.Round(NumberUtil.Val( GetPar( "ProductId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A15ProductId", StringUtil.LTrimStr( (decimal)(A15ProductId), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_13( A15ProductId) ;
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
               AV7HistoryOfDircardedProductsId = (int)(Math.Round(NumberUtil.Val( GetPar( "HistoryOfDircardedProductsId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7HistoryOfDircardedProductsId", StringUtil.LTrimStr( (decimal)(AV7HistoryOfDircardedProductsId), 6, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vHISTORYOFDIRCARDEDPRODUCTSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7HistoryOfDircardedProductsId), "ZZZZZ9"), context));
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
            Form.Meta.addItem("description", "History Of Dircarded Products", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtProductId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("mtaKB", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public historyofdircardedproducts( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public historyofdircardedproducts( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_HistoryOfDircardedProductsId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7HistoryOfDircardedProductsId = aP1_HistoryOfDircardedProductsId;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "History Of Dircarded Products", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_HistoryOfDircardedProducts.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_HistoryOfDircardedProducts.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_HistoryOfDircardedProducts.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_HistoryOfDircardedProducts.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_HistoryOfDircardedProducts.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_HistoryOfDircardedProducts.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtHistoryOfDircardedProductsId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHistoryOfDircardedProductsId_Internalname, "Products Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtHistoryOfDircardedProductsId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A81HistoryOfDircardedProductsId), 6, 0, ".", "")), StringUtil.LTrim( ((edtHistoryOfDircardedProductsId_Enabled!=0) ? context.localUtil.Format( (decimal)(A81HistoryOfDircardedProductsId), "ZZZZZ9") : context.localUtil.Format( (decimal)(A81HistoryOfDircardedProductsId), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHistoryOfDircardedProductsId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtHistoryOfDircardedProductsId_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_HistoryOfDircardedProducts.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProductId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A15ProductId), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductId_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_HistoryOfDircardedProducts.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_15_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_15_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_15_Internalname, sImgUrl, imgprompt_15_Link, "", "", context.GetTheme( ), imgprompt_15_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_HistoryOfDircardedProducts.htm");
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
         GxWebStd.gx_label_element( context, edtProductName_Internalname, "Product Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtProductName_Internalname, A16ProductName, StringUtil.RTrim( context.localUtil.Format( A16ProductName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductName_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Name", "left", true, "", "HLP_HistoryOfDircardedProducts.htm");
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
         GxWebStd.gx_label_element( context, edtProductStock_Internalname, "Product Stock", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtProductStock_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A17ProductStock), 6, 0, ".", "")), StringUtil.LTrim( ((edtProductStock_Enabled!=0) ? context.localUtil.Format( (decimal)(A17ProductStock), "ZZZZZ9") : context.localUtil.Format( (decimal)(A17ProductStock), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductStock_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductStock_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Stock", "right", false, "", "HLP_HistoryOfDircardedProducts.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtHistoryOfDircardedProductsDesc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHistoryOfDircardedProductsDesc_Internalname, "Products Description", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtHistoryOfDircardedProductsDesc_Internalname, A82HistoryOfDircardedProductsDesc, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", 0, 1, edtHistoryOfDircardedProductsDesc_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "GeneXusUnanimo\\Description", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_HistoryOfDircardedProducts.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtHistoryOfDircardedProductsDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHistoryOfDircardedProductsDate_Internalname, "Products Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         context.WriteHtmlText( "<div id=\""+edtHistoryOfDircardedProductsDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtHistoryOfDircardedProductsDate_Internalname, context.localUtil.Format(A83HistoryOfDircardedProductsDate, "99/99/99"), context.localUtil.Format( A83HistoryOfDircardedProductsDate, "99/99/99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHistoryOfDircardedProductsDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtHistoryOfDircardedProductsDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_HistoryOfDircardedProducts.htm");
         GxWebStd.gx_bitmap( context, edtHistoryOfDircardedProductsDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtHistoryOfDircardedProductsDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_HistoryOfDircardedProducts.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtHistoryOfDircardedProductsQuan_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHistoryOfDircardedProductsQuan_Internalname, "Products Quantity", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHistoryOfDircardedProductsQuan_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A84HistoryOfDircardedProductsQuan), 4, 0, ".", "")), StringUtil.LTrim( ((edtHistoryOfDircardedProductsQuan_Enabled!=0) ? context.localUtil.Format( (decimal)(A84HistoryOfDircardedProductsQuan), "ZZZ9") : context.localUtil.Format( (decimal)(A84HistoryOfDircardedProductsQuan), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtHistoryOfDircardedProductsQuan_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtHistoryOfDircardedProductsQuan_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_HistoryOfDircardedProducts.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_HistoryOfDircardedProducts.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_HistoryOfDircardedProducts.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_HistoryOfDircardedProducts.htm");
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
         E110B2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z81HistoryOfDircardedProductsId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z81HistoryOfDircardedProductsId"), ".", ","), 18, MidpointRounding.ToEven));
               Z82HistoryOfDircardedProductsDesc = cgiGet( "Z82HistoryOfDircardedProductsDesc");
               Z83HistoryOfDircardedProductsDate = context.localUtil.CToD( cgiGet( "Z83HistoryOfDircardedProductsDate"), 0);
               Z84HistoryOfDircardedProductsQuan = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z84HistoryOfDircardedProductsQuan"), ".", ","), 18, MidpointRounding.ToEven));
               Z15ProductId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z15ProductId"), ".", ","), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N15ProductId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N15ProductId"), ".", ","), 18, MidpointRounding.ToEven));
               AV7HistoryOfDircardedProductsId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vHISTORYOFDIRCARDEDPRODUCTSID"), ".", ","), 18, MidpointRounding.ToEven));
               AV11Insert_ProductId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_PRODUCTID"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_date = context.localUtil.CToD( cgiGet( "vTODAY"), 0);
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","), 18, MidpointRounding.ToEven));
               AV15Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A81HistoryOfDircardedProductsId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtHistoryOfDircardedProductsId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A81HistoryOfDircardedProductsId", StringUtil.LTrimStr( (decimal)(A81HistoryOfDircardedProductsId), 6, 0));
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
               A16ProductName = cgiGet( edtProductName_Internalname);
               AssignAttri("", false, "A16ProductName", A16ProductName);
               A17ProductStock = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtProductStock_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A17ProductStock", StringUtil.LTrimStr( (decimal)(A17ProductStock), 6, 0));
               A82HistoryOfDircardedProductsDesc = cgiGet( edtHistoryOfDircardedProductsDesc_Internalname);
               AssignAttri("", false, "A82HistoryOfDircardedProductsDesc", A82HistoryOfDircardedProductsDesc);
               A83HistoryOfDircardedProductsDate = context.localUtil.CToD( cgiGet( edtHistoryOfDircardedProductsDate_Internalname), 1);
               AssignAttri("", false, "A83HistoryOfDircardedProductsDate", context.localUtil.Format(A83HistoryOfDircardedProductsDate, "99/99/99"));
               if ( ( ( context.localUtil.CToN( cgiGet( edtHistoryOfDircardedProductsQuan_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtHistoryOfDircardedProductsQuan_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "HISTORYOFDIRCARDEDPRODUCTSQUAN");
                  AnyError = 1;
                  GX_FocusControl = edtHistoryOfDircardedProductsQuan_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A84HistoryOfDircardedProductsQuan = 0;
                  AssignAttri("", false, "A84HistoryOfDircardedProductsQuan", StringUtil.LTrimStr( (decimal)(A84HistoryOfDircardedProductsQuan), 4, 0));
               }
               else
               {
                  A84HistoryOfDircardedProductsQuan = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtHistoryOfDircardedProductsQuan_Internalname), ".", ","), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A84HistoryOfDircardedProductsQuan", StringUtil.LTrimStr( (decimal)(A84HistoryOfDircardedProductsQuan), 4, 0));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"HistoryOfDircardedProducts");
               A81HistoryOfDircardedProductsId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtHistoryOfDircardedProductsId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A81HistoryOfDircardedProductsId", StringUtil.LTrimStr( (decimal)(A81HistoryOfDircardedProductsId), 6, 0));
               forbiddenHiddens.Add("HistoryOfDircardedProductsId", context.localUtil.Format( (decimal)(A81HistoryOfDircardedProductsId), "ZZZZZ9"));
               A83HistoryOfDircardedProductsDate = context.localUtil.CToD( cgiGet( edtHistoryOfDircardedProductsDate_Internalname), 1);
               AssignAttri("", false, "A83HistoryOfDircardedProductsDate", context.localUtil.Format(A83HistoryOfDircardedProductsDate, "99/99/99"));
               forbiddenHiddens.Add("HistoryOfDircardedProductsDate", context.localUtil.Format(A83HistoryOfDircardedProductsDate, "99/99/99"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A81HistoryOfDircardedProductsId != Z81HistoryOfDircardedProductsId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("historyofdircardedproducts:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A81HistoryOfDircardedProductsId = (int)(Math.Round(NumberUtil.Val( GetPar( "HistoryOfDircardedProductsId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A81HistoryOfDircardedProductsId", StringUtil.LTrimStr( (decimal)(A81HistoryOfDircardedProductsId), 6, 0));
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
                     sMode15 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode15;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound15 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0B0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "HISTORYOFDIRCARDEDPRODUCTSID");
                        AnyError = 1;
                        GX_FocusControl = edtHistoryOfDircardedProductsId_Internalname;
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
                           E110B2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120B2 ();
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
            E120B2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0B15( ) ;
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
            DisableAttributes0B15( ) ;
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

      protected void CONFIRM_0B0( )
      {
         BeforeValidate0B15( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0B15( ) ;
            }
            else
            {
               CheckExtendedTable0B15( ) ;
               CloseExtendedTableCursors0B15( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0B0( )
      {
      }

      protected void E110B2( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV15Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV15Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         AV11Insert_ProductId = 0;
         AssignAttri("", false, "AV11Insert_ProductId", StringUtil.LTrimStr( (decimal)(AV11Insert_ProductId), 6, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV15Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV16GXV1 = 1;
            AssignAttri("", false, "AV16GXV1", StringUtil.LTrimStr( (decimal)(AV16GXV1), 8, 0));
            while ( AV16GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((GeneXus.Programs.general.ui.SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV16GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "ProductId") == 0 )
               {
                  AV11Insert_ProductId = (int)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_ProductId", StringUtil.LTrimStr( (decimal)(AV11Insert_ProductId), 6, 0));
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

      protected void E120B2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwhistoryofdircardedproducts.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0B15( short GX_JID )
      {
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z82HistoryOfDircardedProductsDesc = T000B3_A82HistoryOfDircardedProductsDesc[0];
               Z83HistoryOfDircardedProductsDate = T000B3_A83HistoryOfDircardedProductsDate[0];
               Z84HistoryOfDircardedProductsQuan = T000B3_A84HistoryOfDircardedProductsQuan[0];
               Z15ProductId = T000B3_A15ProductId[0];
            }
            else
            {
               Z82HistoryOfDircardedProductsDesc = A82HistoryOfDircardedProductsDesc;
               Z83HistoryOfDircardedProductsDate = A83HistoryOfDircardedProductsDate;
               Z84HistoryOfDircardedProductsQuan = A84HistoryOfDircardedProductsQuan;
               Z15ProductId = A15ProductId;
            }
         }
         if ( GX_JID == -12 )
         {
            Z81HistoryOfDircardedProductsId = A81HistoryOfDircardedProductsId;
            Z82HistoryOfDircardedProductsDesc = A82HistoryOfDircardedProductsDesc;
            Z83HistoryOfDircardedProductsDate = A83HistoryOfDircardedProductsDate;
            Z84HistoryOfDircardedProductsQuan = A84HistoryOfDircardedProductsQuan;
            Z15ProductId = A15ProductId;
            Z16ProductName = A16ProductName;
            Z17ProductStock = A17ProductStock;
         }
      }

      protected void standaloneNotModal( )
      {
         edtHistoryOfDircardedProductsId_Enabled = 0;
         AssignProp("", false, edtHistoryOfDircardedProductsId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoryOfDircardedProductsId_Enabled), 5, 0), true);
         edtHistoryOfDircardedProductsDate_Enabled = 0;
         AssignProp("", false, edtHistoryOfDircardedProductsDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoryOfDircardedProductsDate_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         Gx_date = DateTimeUtil.Today( context);
         AssignAttri("", false, "Gx_date", context.localUtil.Format(Gx_date, "99/99/99"));
         imgprompt_15_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0050.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PRODUCTID"+"'), id:'"+"PRODUCTID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtHistoryOfDircardedProductsId_Enabled = 0;
         AssignProp("", false, edtHistoryOfDircardedProductsId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoryOfDircardedProductsId_Enabled), 5, 0), true);
         edtHistoryOfDircardedProductsDate_Enabled = 0;
         AssignProp("", false, edtHistoryOfDircardedProductsDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoryOfDircardedProductsDate_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7HistoryOfDircardedProductsId) )
         {
            A81HistoryOfDircardedProductsId = AV7HistoryOfDircardedProductsId;
            AssignAttri("", false, "A81HistoryOfDircardedProductsId", StringUtil.LTrimStr( (decimal)(A81HistoryOfDircardedProductsId), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_ProductId) )
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_ProductId) )
         {
            A15ProductId = AV11Insert_ProductId;
            AssignAttri("", false, "A15ProductId", StringUtil.LTrimStr( (decimal)(A15ProductId), 6, 0));
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
         if ( IsIns( )  && (DateTime.MinValue==A83HistoryOfDircardedProductsDate) && ( Gx_BScreen == 0 ) )
         {
            A83HistoryOfDircardedProductsDate = Gx_date;
            AssignAttri("", false, "A83HistoryOfDircardedProductsDate", context.localUtil.Format(A83HistoryOfDircardedProductsDate, "99/99/99"));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV15Pgmname = "HistoryOfDircardedProducts";
            AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
            /* Using cursor T000B4 */
            pr_default.execute(2, new Object[] {A15ProductId});
            A16ProductName = T000B4_A16ProductName[0];
            AssignAttri("", false, "A16ProductName", A16ProductName);
            A17ProductStock = T000B4_A17ProductStock[0];
            AssignAttri("", false, "A17ProductStock", StringUtil.LTrimStr( (decimal)(A17ProductStock), 6, 0));
            pr_default.close(2);
         }
      }

      protected void Load0B15( )
      {
         /* Using cursor T000B5 */
         pr_default.execute(3, new Object[] {A81HistoryOfDircardedProductsId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound15 = 1;
            A16ProductName = T000B5_A16ProductName[0];
            AssignAttri("", false, "A16ProductName", A16ProductName);
            A17ProductStock = T000B5_A17ProductStock[0];
            AssignAttri("", false, "A17ProductStock", StringUtil.LTrimStr( (decimal)(A17ProductStock), 6, 0));
            A82HistoryOfDircardedProductsDesc = T000B5_A82HistoryOfDircardedProductsDesc[0];
            AssignAttri("", false, "A82HistoryOfDircardedProductsDesc", A82HistoryOfDircardedProductsDesc);
            A83HistoryOfDircardedProductsDate = T000B5_A83HistoryOfDircardedProductsDate[0];
            AssignAttri("", false, "A83HistoryOfDircardedProductsDate", context.localUtil.Format(A83HistoryOfDircardedProductsDate, "99/99/99"));
            A84HistoryOfDircardedProductsQuan = T000B5_A84HistoryOfDircardedProductsQuan[0];
            AssignAttri("", false, "A84HistoryOfDircardedProductsQuan", StringUtil.LTrimStr( (decimal)(A84HistoryOfDircardedProductsQuan), 4, 0));
            A15ProductId = T000B5_A15ProductId[0];
            AssignAttri("", false, "A15ProductId", StringUtil.LTrimStr( (decimal)(A15ProductId), 6, 0));
            ZM0B15( -12) ;
         }
         pr_default.close(3);
         OnLoadActions0B15( ) ;
      }

      protected void OnLoadActions0B15( )
      {
         AV15Pgmname = "HistoryOfDircardedProducts";
         AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
      }

      protected void CheckExtendedTable0B15( )
      {
         nIsDirty_15 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV15Pgmname = "HistoryOfDircardedProducts";
         AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
         /* Using cursor T000B4 */
         pr_default.execute(2, new Object[] {A15ProductId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'Product'.", "ForeignKeyNotFound", 1, "PRODUCTID");
            AnyError = 1;
            GX_FocusControl = edtProductId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A16ProductName = T000B4_A16ProductName[0];
         AssignAttri("", false, "A16ProductName", A16ProductName);
         A17ProductStock = T000B4_A17ProductStock[0];
         AssignAttri("", false, "A17ProductStock", StringUtil.LTrimStr( (decimal)(A17ProductStock), 6, 0));
         pr_default.close(2);
         if ( ( A84HistoryOfDircardedProductsQuan <= 0 ) || ( A84HistoryOfDircardedProductsQuan > A17ProductStock ) )
         {
            GX_msglist.addItem("Quantity Invalid", 1, "HISTORYOFDIRCARDEDPRODUCTSQUAN");
            AnyError = 1;
            GX_FocusControl = edtHistoryOfDircardedProductsQuan_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A82HistoryOfDircardedProductsDesc)) )
         {
            GX_msglist.addItem("Must be have a description", 1, "HISTORYOFDIRCARDEDPRODUCTSDESC");
            AnyError = 1;
            GX_FocusControl = edtHistoryOfDircardedProductsDesc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0B15( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_13( int A15ProductId )
      {
         /* Using cursor T000B6 */
         pr_default.execute(4, new Object[] {A15ProductId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No matching 'Product'.", "ForeignKeyNotFound", 1, "PRODUCTID");
            AnyError = 1;
            GX_FocusControl = edtProductId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A16ProductName = T000B6_A16ProductName[0];
         AssignAttri("", false, "A16ProductName", A16ProductName);
         A17ProductStock = T000B6_A17ProductStock[0];
         AssignAttri("", false, "A17ProductStock", StringUtil.LTrimStr( (decimal)(A17ProductStock), 6, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A16ProductName)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A17ProductStock), 6, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey0B15( )
      {
         /* Using cursor T000B7 */
         pr_default.execute(5, new Object[] {A81HistoryOfDircardedProductsId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound15 = 1;
         }
         else
         {
            RcdFound15 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000B3 */
         pr_default.execute(1, new Object[] {A81HistoryOfDircardedProductsId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0B15( 12) ;
            RcdFound15 = 1;
            A81HistoryOfDircardedProductsId = T000B3_A81HistoryOfDircardedProductsId[0];
            AssignAttri("", false, "A81HistoryOfDircardedProductsId", StringUtil.LTrimStr( (decimal)(A81HistoryOfDircardedProductsId), 6, 0));
            A82HistoryOfDircardedProductsDesc = T000B3_A82HistoryOfDircardedProductsDesc[0];
            AssignAttri("", false, "A82HistoryOfDircardedProductsDesc", A82HistoryOfDircardedProductsDesc);
            A83HistoryOfDircardedProductsDate = T000B3_A83HistoryOfDircardedProductsDate[0];
            AssignAttri("", false, "A83HistoryOfDircardedProductsDate", context.localUtil.Format(A83HistoryOfDircardedProductsDate, "99/99/99"));
            A84HistoryOfDircardedProductsQuan = T000B3_A84HistoryOfDircardedProductsQuan[0];
            AssignAttri("", false, "A84HistoryOfDircardedProductsQuan", StringUtil.LTrimStr( (decimal)(A84HistoryOfDircardedProductsQuan), 4, 0));
            A15ProductId = T000B3_A15ProductId[0];
            AssignAttri("", false, "A15ProductId", StringUtil.LTrimStr( (decimal)(A15ProductId), 6, 0));
            Z81HistoryOfDircardedProductsId = A81HistoryOfDircardedProductsId;
            sMode15 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0B15( ) ;
            if ( AnyError == 1 )
            {
               RcdFound15 = 0;
               InitializeNonKey0B15( ) ;
            }
            Gx_mode = sMode15;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound15 = 0;
            InitializeNonKey0B15( ) ;
            sMode15 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode15;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0B15( ) ;
         if ( RcdFound15 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound15 = 0;
         /* Using cursor T000B8 */
         pr_default.execute(6, new Object[] {A81HistoryOfDircardedProductsId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T000B8_A81HistoryOfDircardedProductsId[0] < A81HistoryOfDircardedProductsId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T000B8_A81HistoryOfDircardedProductsId[0] > A81HistoryOfDircardedProductsId ) ) )
            {
               A81HistoryOfDircardedProductsId = T000B8_A81HistoryOfDircardedProductsId[0];
               AssignAttri("", false, "A81HistoryOfDircardedProductsId", StringUtil.LTrimStr( (decimal)(A81HistoryOfDircardedProductsId), 6, 0));
               RcdFound15 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound15 = 0;
         /* Using cursor T000B9 */
         pr_default.execute(7, new Object[] {A81HistoryOfDircardedProductsId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T000B9_A81HistoryOfDircardedProductsId[0] > A81HistoryOfDircardedProductsId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T000B9_A81HistoryOfDircardedProductsId[0] < A81HistoryOfDircardedProductsId ) ) )
            {
               A81HistoryOfDircardedProductsId = T000B9_A81HistoryOfDircardedProductsId[0];
               AssignAttri("", false, "A81HistoryOfDircardedProductsId", StringUtil.LTrimStr( (decimal)(A81HistoryOfDircardedProductsId), 6, 0));
               RcdFound15 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0B15( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtProductId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0B15( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound15 == 1 )
            {
               if ( A81HistoryOfDircardedProductsId != Z81HistoryOfDircardedProductsId )
               {
                  A81HistoryOfDircardedProductsId = Z81HistoryOfDircardedProductsId;
                  AssignAttri("", false, "A81HistoryOfDircardedProductsId", StringUtil.LTrimStr( (decimal)(A81HistoryOfDircardedProductsId), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "HISTORYOFDIRCARDEDPRODUCTSID");
                  AnyError = 1;
                  GX_FocusControl = edtHistoryOfDircardedProductsId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtProductId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0B15( ) ;
                  GX_FocusControl = edtProductId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A81HistoryOfDircardedProductsId != Z81HistoryOfDircardedProductsId )
               {
                  /* Insert record */
                  GX_FocusControl = edtProductId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0B15( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "HISTORYOFDIRCARDEDPRODUCTSID");
                     AnyError = 1;
                     GX_FocusControl = edtHistoryOfDircardedProductsId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtProductId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0B15( ) ;
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
         if ( A81HistoryOfDircardedProductsId != Z81HistoryOfDircardedProductsId )
         {
            A81HistoryOfDircardedProductsId = Z81HistoryOfDircardedProductsId;
            AssignAttri("", false, "A81HistoryOfDircardedProductsId", StringUtil.LTrimStr( (decimal)(A81HistoryOfDircardedProductsId), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "HISTORYOFDIRCARDEDPRODUCTSID");
            AnyError = 1;
            GX_FocusControl = edtHistoryOfDircardedProductsId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtProductId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0B15( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000B2 */
            pr_default.execute(0, new Object[] {A81HistoryOfDircardedProductsId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"HistoryOfDircardedProducts"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z82HistoryOfDircardedProductsDesc, T000B2_A82HistoryOfDircardedProductsDesc[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z83HistoryOfDircardedProductsDate ) != DateTimeUtil.ResetTime ( T000B2_A83HistoryOfDircardedProductsDate[0] ) ) || ( Z84HistoryOfDircardedProductsQuan != T000B2_A84HistoryOfDircardedProductsQuan[0] ) || ( Z15ProductId != T000B2_A15ProductId[0] ) )
            {
               if ( StringUtil.StrCmp(Z82HistoryOfDircardedProductsDesc, T000B2_A82HistoryOfDircardedProductsDesc[0]) != 0 )
               {
                  GXUtil.WriteLog("historyofdircardedproducts:[seudo value changed for attri]"+"HistoryOfDircardedProductsDesc");
                  GXUtil.WriteLogRaw("Old: ",Z82HistoryOfDircardedProductsDesc);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A82HistoryOfDircardedProductsDesc[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z83HistoryOfDircardedProductsDate ) != DateTimeUtil.ResetTime ( T000B2_A83HistoryOfDircardedProductsDate[0] ) )
               {
                  GXUtil.WriteLog("historyofdircardedproducts:[seudo value changed for attri]"+"HistoryOfDircardedProductsDate");
                  GXUtil.WriteLogRaw("Old: ",Z83HistoryOfDircardedProductsDate);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A83HistoryOfDircardedProductsDate[0]);
               }
               if ( Z84HistoryOfDircardedProductsQuan != T000B2_A84HistoryOfDircardedProductsQuan[0] )
               {
                  GXUtil.WriteLog("historyofdircardedproducts:[seudo value changed for attri]"+"HistoryOfDircardedProductsQuan");
                  GXUtil.WriteLogRaw("Old: ",Z84HistoryOfDircardedProductsQuan);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A84HistoryOfDircardedProductsQuan[0]);
               }
               if ( Z15ProductId != T000B2_A15ProductId[0] )
               {
                  GXUtil.WriteLog("historyofdircardedproducts:[seudo value changed for attri]"+"ProductId");
                  GXUtil.WriteLogRaw("Old: ",Z15ProductId);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A15ProductId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"HistoryOfDircardedProducts"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0B15( )
      {
         BeforeValidate0B15( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B15( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0B15( 0) ;
            CheckOptimisticConcurrency0B15( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B15( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0B15( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000B10 */
                     pr_default.execute(8, new Object[] {A82HistoryOfDircardedProductsDesc, A83HistoryOfDircardedProductsDate, A84HistoryOfDircardedProductsQuan, A15ProductId});
                     A81HistoryOfDircardedProductsId = T000B10_A81HistoryOfDircardedProductsId[0];
                     AssignAttri("", false, "A81HistoryOfDircardedProductsId", StringUtil.LTrimStr( (decimal)(A81HistoryOfDircardedProductsId), 6, 0));
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("HistoryOfDircardedProducts");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0B0( ) ;
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
               Load0B15( ) ;
            }
            EndLevel0B15( ) ;
         }
         CloseExtendedTableCursors0B15( ) ;
      }

      protected void Update0B15( )
      {
         BeforeValidate0B15( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B15( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B15( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B15( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0B15( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000B11 */
                     pr_default.execute(9, new Object[] {A82HistoryOfDircardedProductsDesc, A83HistoryOfDircardedProductsDate, A84HistoryOfDircardedProductsQuan, A15ProductId, A81HistoryOfDircardedProductsId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("HistoryOfDircardedProducts");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"HistoryOfDircardedProducts"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0B15( ) ;
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
            EndLevel0B15( ) ;
         }
         CloseExtendedTableCursors0B15( ) ;
      }

      protected void DeferredUpdate0B15( )
      {
      }

      protected void delete( )
      {
         BeforeValidate0B15( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B15( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0B15( ) ;
            AfterConfirm0B15( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0B15( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000B12 */
                  pr_default.execute(10, new Object[] {A81HistoryOfDircardedProductsId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("HistoryOfDircardedProducts");
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
         sMode15 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0B15( ) ;
         Gx_mode = sMode15;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0B15( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV15Pgmname = "HistoryOfDircardedProducts";
            AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
            /* Using cursor T000B13 */
            pr_default.execute(11, new Object[] {A15ProductId});
            A16ProductName = T000B13_A16ProductName[0];
            AssignAttri("", false, "A16ProductName", A16ProductName);
            A17ProductStock = T000B13_A17ProductStock[0];
            AssignAttri("", false, "A17ProductStock", StringUtil.LTrimStr( (decimal)(A17ProductStock), 6, 0));
            pr_default.close(11);
         }
      }

      protected void EndLevel0B15( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0B15( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(11);
            context.CommitDataStores("historyofdircardedproducts",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0B0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(11);
            context.RollbackDataStores("historyofdircardedproducts",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0B15( )
      {
         /* Scan By routine */
         /* Using cursor T000B14 */
         pr_default.execute(12);
         RcdFound15 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound15 = 1;
            A81HistoryOfDircardedProductsId = T000B14_A81HistoryOfDircardedProductsId[0];
            AssignAttri("", false, "A81HistoryOfDircardedProductsId", StringUtil.LTrimStr( (decimal)(A81HistoryOfDircardedProductsId), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0B15( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound15 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound15 = 1;
            A81HistoryOfDircardedProductsId = T000B14_A81HistoryOfDircardedProductsId[0];
            AssignAttri("", false, "A81HistoryOfDircardedProductsId", StringUtil.LTrimStr( (decimal)(A81HistoryOfDircardedProductsId), 6, 0));
         }
      }

      protected void ScanEnd0B15( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm0B15( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0B15( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0B15( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0B15( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0B15( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0B15( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0B15( )
      {
         edtHistoryOfDircardedProductsId_Enabled = 0;
         AssignProp("", false, edtHistoryOfDircardedProductsId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoryOfDircardedProductsId_Enabled), 5, 0), true);
         edtProductId_Enabled = 0;
         AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), true);
         edtProductName_Enabled = 0;
         AssignProp("", false, edtProductName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductName_Enabled), 5, 0), true);
         edtProductStock_Enabled = 0;
         AssignProp("", false, edtProductStock_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductStock_Enabled), 5, 0), true);
         edtHistoryOfDircardedProductsDesc_Enabled = 0;
         AssignProp("", false, edtHistoryOfDircardedProductsDesc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoryOfDircardedProductsDesc_Enabled), 5, 0), true);
         edtHistoryOfDircardedProductsDate_Enabled = 0;
         AssignProp("", false, edtHistoryOfDircardedProductsDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoryOfDircardedProductsDate_Enabled), 5, 0), true);
         edtHistoryOfDircardedProductsQuan_Enabled = 0;
         AssignProp("", false, edtHistoryOfDircardedProductsQuan_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHistoryOfDircardedProductsQuan_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0B15( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0B0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("historyofdircardedproducts.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7HistoryOfDircardedProductsId,6,0))}, new string[] {"Gx_mode","HistoryOfDircardedProductsId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"HistoryOfDircardedProducts");
         forbiddenHiddens.Add("HistoryOfDircardedProductsId", context.localUtil.Format( (decimal)(A81HistoryOfDircardedProductsId), "ZZZZZ9"));
         forbiddenHiddens.Add("HistoryOfDircardedProductsDate", context.localUtil.Format(A83HistoryOfDircardedProductsDate, "99/99/99"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("historyofdircardedproducts:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z81HistoryOfDircardedProductsId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z81HistoryOfDircardedProductsId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z82HistoryOfDircardedProductsDesc", Z82HistoryOfDircardedProductsDesc);
         GxWebStd.gx_hidden_field( context, "Z83HistoryOfDircardedProductsDate", context.localUtil.DToC( Z83HistoryOfDircardedProductsDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z84HistoryOfDircardedProductsQuan", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z84HistoryOfDircardedProductsQuan), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z15ProductId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z15ProductId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
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
         GxWebStd.gx_hidden_field( context, "vHISTORYOFDIRCARDEDPRODUCTSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7HistoryOfDircardedProductsId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vHISTORYOFDIRCARDEDPRODUCTSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7HistoryOfDircardedProductsId), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_PRODUCTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_ProductId), 6, 0, ".", "")));
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
         return formatLink("historyofdircardedproducts.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7HistoryOfDircardedProductsId,6,0))}, new string[] {"Gx_mode","HistoryOfDircardedProductsId"})  ;
      }

      public override string GetPgmname( )
      {
         return "HistoryOfDircardedProducts" ;
      }

      public override string GetPgmdesc( )
      {
         return "History Of Dircarded Products" ;
      }

      protected void InitializeNonKey0B15( )
      {
         A15ProductId = 0;
         AssignAttri("", false, "A15ProductId", StringUtil.LTrimStr( (decimal)(A15ProductId), 6, 0));
         A16ProductName = "";
         AssignAttri("", false, "A16ProductName", A16ProductName);
         A17ProductStock = 0;
         AssignAttri("", false, "A17ProductStock", StringUtil.LTrimStr( (decimal)(A17ProductStock), 6, 0));
         A82HistoryOfDircardedProductsDesc = "";
         AssignAttri("", false, "A82HistoryOfDircardedProductsDesc", A82HistoryOfDircardedProductsDesc);
         A84HistoryOfDircardedProductsQuan = 0;
         AssignAttri("", false, "A84HistoryOfDircardedProductsQuan", StringUtil.LTrimStr( (decimal)(A84HistoryOfDircardedProductsQuan), 4, 0));
         A83HistoryOfDircardedProductsDate = Gx_date;
         AssignAttri("", false, "A83HistoryOfDircardedProductsDate", context.localUtil.Format(A83HistoryOfDircardedProductsDate, "99/99/99"));
         Z82HistoryOfDircardedProductsDesc = "";
         Z83HistoryOfDircardedProductsDate = DateTime.MinValue;
         Z84HistoryOfDircardedProductsQuan = 0;
         Z15ProductId = 0;
      }

      protected void InitAll0B15( )
      {
         A81HistoryOfDircardedProductsId = 0;
         AssignAttri("", false, "A81HistoryOfDircardedProductsId", StringUtil.LTrimStr( (decimal)(A81HistoryOfDircardedProductsId), 6, 0));
         InitializeNonKey0B15( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A83HistoryOfDircardedProductsDate = i83HistoryOfDircardedProductsDate;
         AssignAttri("", false, "A83HistoryOfDircardedProductsDate", context.localUtil.Format(A83HistoryOfDircardedProductsDate, "99/99/99"));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023121823151679", true, true);
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
         context.AddJavascriptSource("historyofdircardedproducts.js", "?2023121823151680", false, true);
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
         edtHistoryOfDircardedProductsId_Internalname = "HISTORYOFDIRCARDEDPRODUCTSID";
         edtProductId_Internalname = "PRODUCTID";
         edtProductName_Internalname = "PRODUCTNAME";
         edtProductStock_Internalname = "PRODUCTSTOCK";
         edtHistoryOfDircardedProductsDesc_Internalname = "HISTORYOFDIRCARDEDPRODUCTSDESC";
         edtHistoryOfDircardedProductsDate_Internalname = "HISTORYOFDIRCARDEDPRODUCTSDATE";
         edtHistoryOfDircardedProductsQuan_Internalname = "HISTORYOFDIRCARDEDPRODUCTSQUAN";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
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
         Form.Caption = "History Of Dircarded Products";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirm";
         bttBtn_enter_Caption = "Confirm";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtHistoryOfDircardedProductsQuan_Jsonclick = "";
         edtHistoryOfDircardedProductsQuan_Enabled = 1;
         edtHistoryOfDircardedProductsDate_Jsonclick = "";
         edtHistoryOfDircardedProductsDate_Enabled = 0;
         edtHistoryOfDircardedProductsDesc_Enabled = 1;
         edtProductStock_Jsonclick = "";
         edtProductStock_Enabled = 0;
         edtProductName_Jsonclick = "";
         edtProductName_Enabled = 0;
         imgprompt_15_Visible = 1;
         imgprompt_15_Link = "";
         edtProductId_Jsonclick = "";
         edtProductId_Enabled = 1;
         edtHistoryOfDircardedProductsId_Jsonclick = "";
         edtHistoryOfDircardedProductsId_Enabled = 0;
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

      public void Valid_Productid( )
      {
         /* Using cursor T000B13 */
         pr_default.execute(11, new Object[] {A15ProductId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No matching 'Product'.", "ForeignKeyNotFound", 1, "PRODUCTID");
            AnyError = 1;
            GX_FocusControl = edtProductId_Internalname;
         }
         A16ProductName = T000B13_A16ProductName[0];
         A17ProductStock = T000B13_A17ProductStock[0];
         pr_default.close(11);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A16ProductName", A16ProductName);
         AssignAttri("", false, "A17ProductStock", StringUtil.LTrim( StringUtil.NToC( (decimal)(A17ProductStock), 6, 0, ".", "")));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7HistoryOfDircardedProductsId',fld:'vHISTORYOFDIRCARDEDPRODUCTSID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7HistoryOfDircardedProductsId',fld:'vHISTORYOFDIRCARDEDPRODUCTSID',pic:'ZZZZZ9',hsh:true},{av:'A81HistoryOfDircardedProductsId',fld:'HISTORYOFDIRCARDEDPRODUCTSID',pic:'ZZZZZ9'},{av:'A83HistoryOfDircardedProductsDate',fld:'HISTORYOFDIRCARDEDPRODUCTSDATE',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120B2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_HISTORYOFDIRCARDEDPRODUCTSID","{handler:'Valid_Historyofdircardedproductsid',iparms:[]");
         setEventMetadata("VALID_HISTORYOFDIRCARDEDPRODUCTSID",",oparms:[]}");
         setEventMetadata("VALID_PRODUCTID","{handler:'Valid_Productid',iparms:[{av:'A15ProductId',fld:'PRODUCTID',pic:'ZZZZZ9'},{av:'A16ProductName',fld:'PRODUCTNAME',pic:''},{av:'A17ProductStock',fld:'PRODUCTSTOCK',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_PRODUCTID",",oparms:[{av:'A16ProductName',fld:'PRODUCTNAME',pic:''},{av:'A17ProductStock',fld:'PRODUCTSTOCK',pic:'ZZZZZ9'}]}");
         setEventMetadata("VALID_PRODUCTSTOCK","{handler:'Valid_Productstock',iparms:[]");
         setEventMetadata("VALID_PRODUCTSTOCK",",oparms:[]}");
         setEventMetadata("VALID_HISTORYOFDIRCARDEDPRODUCTSDESC","{handler:'Valid_Historyofdircardedproductsdesc',iparms:[]");
         setEventMetadata("VALID_HISTORYOFDIRCARDEDPRODUCTSDESC",",oparms:[]}");
         setEventMetadata("VALID_HISTORYOFDIRCARDEDPRODUCTSQUAN","{handler:'Valid_Historyofdircardedproductsquan',iparms:[]");
         setEventMetadata("VALID_HISTORYOFDIRCARDEDPRODUCTSQUAN",",oparms:[]}");
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
         Z82HistoryOfDircardedProductsDesc = "";
         Z83HistoryOfDircardedProductsDate = DateTime.MinValue;
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
         imgprompt_15_gximage = "";
         sImgUrl = "";
         A16ProductName = "";
         A82HistoryOfDircardedProductsDesc = "";
         A83HistoryOfDircardedProductsDate = DateTime.MinValue;
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_date = DateTime.MinValue;
         AV15Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode15 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV12TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         Z16ProductName = "";
         T000B4_A16ProductName = new string[] {""} ;
         T000B4_A17ProductStock = new int[1] ;
         T000B5_A81HistoryOfDircardedProductsId = new int[1] ;
         T000B5_A16ProductName = new string[] {""} ;
         T000B5_A17ProductStock = new int[1] ;
         T000B5_A82HistoryOfDircardedProductsDesc = new string[] {""} ;
         T000B5_A83HistoryOfDircardedProductsDate = new DateTime[] {DateTime.MinValue} ;
         T000B5_A84HistoryOfDircardedProductsQuan = new short[1] ;
         T000B5_A15ProductId = new int[1] ;
         T000B6_A16ProductName = new string[] {""} ;
         T000B6_A17ProductStock = new int[1] ;
         T000B7_A81HistoryOfDircardedProductsId = new int[1] ;
         T000B3_A81HistoryOfDircardedProductsId = new int[1] ;
         T000B3_A82HistoryOfDircardedProductsDesc = new string[] {""} ;
         T000B3_A83HistoryOfDircardedProductsDate = new DateTime[] {DateTime.MinValue} ;
         T000B3_A84HistoryOfDircardedProductsQuan = new short[1] ;
         T000B3_A15ProductId = new int[1] ;
         T000B8_A81HistoryOfDircardedProductsId = new int[1] ;
         T000B9_A81HistoryOfDircardedProductsId = new int[1] ;
         T000B2_A81HistoryOfDircardedProductsId = new int[1] ;
         T000B2_A82HistoryOfDircardedProductsDesc = new string[] {""} ;
         T000B2_A83HistoryOfDircardedProductsDate = new DateTime[] {DateTime.MinValue} ;
         T000B2_A84HistoryOfDircardedProductsQuan = new short[1] ;
         T000B2_A15ProductId = new int[1] ;
         T000B10_A81HistoryOfDircardedProductsId = new int[1] ;
         T000B13_A16ProductName = new string[] {""} ;
         T000B13_A17ProductStock = new int[1] ;
         T000B14_A81HistoryOfDircardedProductsId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i83HistoryOfDircardedProductsDate = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.historyofdircardedproducts__default(),
            new Object[][] {
                new Object[] {
               T000B2_A81HistoryOfDircardedProductsId, T000B2_A82HistoryOfDircardedProductsDesc, T000B2_A83HistoryOfDircardedProductsDate, T000B2_A84HistoryOfDircardedProductsQuan, T000B2_A15ProductId
               }
               , new Object[] {
               T000B3_A81HistoryOfDircardedProductsId, T000B3_A82HistoryOfDircardedProductsDesc, T000B3_A83HistoryOfDircardedProductsDate, T000B3_A84HistoryOfDircardedProductsQuan, T000B3_A15ProductId
               }
               , new Object[] {
               T000B4_A16ProductName, T000B4_A17ProductStock
               }
               , new Object[] {
               T000B5_A81HistoryOfDircardedProductsId, T000B5_A16ProductName, T000B5_A17ProductStock, T000B5_A82HistoryOfDircardedProductsDesc, T000B5_A83HistoryOfDircardedProductsDate, T000B5_A84HistoryOfDircardedProductsQuan, T000B5_A15ProductId
               }
               , new Object[] {
               T000B6_A16ProductName, T000B6_A17ProductStock
               }
               , new Object[] {
               T000B7_A81HistoryOfDircardedProductsId
               }
               , new Object[] {
               T000B8_A81HistoryOfDircardedProductsId
               }
               , new Object[] {
               T000B9_A81HistoryOfDircardedProductsId
               }
               , new Object[] {
               T000B10_A81HistoryOfDircardedProductsId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000B13_A16ProductName, T000B13_A17ProductStock
               }
               , new Object[] {
               T000B14_A81HistoryOfDircardedProductsId
               }
            }
         );
         AV15Pgmname = "HistoryOfDircardedProducts";
         Z83HistoryOfDircardedProductsDate = DateTime.MinValue;
         A83HistoryOfDircardedProductsDate = DateTime.MinValue;
         i83HistoryOfDircardedProductsDate = DateTime.MinValue;
         Gx_date = DateTimeUtil.Today( context);
      }

      private short Z84HistoryOfDircardedProductsQuan ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A84HistoryOfDircardedProductsQuan ;
      private short Gx_BScreen ;
      private short RcdFound15 ;
      private short GX_JID ;
      private short nIsDirty_15 ;
      private short gxajaxcallmode ;
      private int wcpOAV7HistoryOfDircardedProductsId ;
      private int Z81HistoryOfDircardedProductsId ;
      private int Z15ProductId ;
      private int N15ProductId ;
      private int A15ProductId ;
      private int AV7HistoryOfDircardedProductsId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A81HistoryOfDircardedProductsId ;
      private int edtHistoryOfDircardedProductsId_Enabled ;
      private int edtProductId_Enabled ;
      private int imgprompt_15_Visible ;
      private int edtProductName_Enabled ;
      private int A17ProductStock ;
      private int edtProductStock_Enabled ;
      private int edtHistoryOfDircardedProductsDesc_Enabled ;
      private int edtHistoryOfDircardedProductsDate_Enabled ;
      private int edtHistoryOfDircardedProductsQuan_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int AV11Insert_ProductId ;
      private int AV16GXV1 ;
      private int Z17ProductStock ;
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
      private string edtProductId_Internalname ;
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
      private string edtHistoryOfDircardedProductsId_Internalname ;
      private string edtHistoryOfDircardedProductsId_Jsonclick ;
      private string edtProductId_Jsonclick ;
      private string imgprompt_15_gximage ;
      private string sImgUrl ;
      private string imgprompt_15_Internalname ;
      private string imgprompt_15_Link ;
      private string edtProductName_Internalname ;
      private string edtProductName_Jsonclick ;
      private string edtProductStock_Internalname ;
      private string edtProductStock_Jsonclick ;
      private string edtHistoryOfDircardedProductsDesc_Internalname ;
      private string edtHistoryOfDircardedProductsDate_Internalname ;
      private string edtHistoryOfDircardedProductsDate_Jsonclick ;
      private string edtHistoryOfDircardedProductsQuan_Internalname ;
      private string edtHistoryOfDircardedProductsQuan_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Caption ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_enter_Tooltiptext ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV15Pgmname ;
      private string hsh ;
      private string sMode15 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z83HistoryOfDircardedProductsDate ;
      private DateTime A83HistoryOfDircardedProductsDate ;
      private DateTime Gx_date ;
      private DateTime i83HistoryOfDircardedProductsDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool returnInSub ;
      private string Z82HistoryOfDircardedProductsDesc ;
      private string A16ProductName ;
      private string A82HistoryOfDircardedProductsDesc ;
      private string Z16ProductName ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T000B4_A16ProductName ;
      private int[] T000B4_A17ProductStock ;
      private int[] T000B5_A81HistoryOfDircardedProductsId ;
      private string[] T000B5_A16ProductName ;
      private int[] T000B5_A17ProductStock ;
      private string[] T000B5_A82HistoryOfDircardedProductsDesc ;
      private DateTime[] T000B5_A83HistoryOfDircardedProductsDate ;
      private short[] T000B5_A84HistoryOfDircardedProductsQuan ;
      private int[] T000B5_A15ProductId ;
      private string[] T000B6_A16ProductName ;
      private int[] T000B6_A17ProductStock ;
      private int[] T000B7_A81HistoryOfDircardedProductsId ;
      private int[] T000B3_A81HistoryOfDircardedProductsId ;
      private string[] T000B3_A82HistoryOfDircardedProductsDesc ;
      private DateTime[] T000B3_A83HistoryOfDircardedProductsDate ;
      private short[] T000B3_A84HistoryOfDircardedProductsQuan ;
      private int[] T000B3_A15ProductId ;
      private int[] T000B8_A81HistoryOfDircardedProductsId ;
      private int[] T000B9_A81HistoryOfDircardedProductsId ;
      private int[] T000B2_A81HistoryOfDircardedProductsId ;
      private string[] T000B2_A82HistoryOfDircardedProductsDesc ;
      private DateTime[] T000B2_A83HistoryOfDircardedProductsDate ;
      private short[] T000B2_A84HistoryOfDircardedProductsQuan ;
      private int[] T000B2_A15ProductId ;
      private int[] T000B10_A81HistoryOfDircardedProductsId ;
      private string[] T000B13_A16ProductName ;
      private int[] T000B13_A17ProductStock ;
      private int[] T000B14_A81HistoryOfDircardedProductsId ;
      private GXWebForm Form ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV12TrnContextAtt ;
   }

   public class historyofdircardedproducts__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000B5;
          prmT000B5 = new Object[] {
          new ParDef("@HistoryOfDircardedProductsId",GXType.Int32,6,0)
          };
          Object[] prmT000B4;
          prmT000B4 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmT000B6;
          prmT000B6 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmT000B7;
          prmT000B7 = new Object[] {
          new ParDef("@HistoryOfDircardedProductsId",GXType.Int32,6,0)
          };
          Object[] prmT000B3;
          prmT000B3 = new Object[] {
          new ParDef("@HistoryOfDircardedProductsId",GXType.Int32,6,0)
          };
          Object[] prmT000B8;
          prmT000B8 = new Object[] {
          new ParDef("@HistoryOfDircardedProductsId",GXType.Int32,6,0)
          };
          Object[] prmT000B9;
          prmT000B9 = new Object[] {
          new ParDef("@HistoryOfDircardedProductsId",GXType.Int32,6,0)
          };
          Object[] prmT000B2;
          prmT000B2 = new Object[] {
          new ParDef("@HistoryOfDircardedProductsId",GXType.Int32,6,0)
          };
          Object[] prmT000B10;
          prmT000B10 = new Object[] {
          new ParDef("@HistoryOfDircardedProductsDesc",GXType.NVarChar,200,0) ,
          new ParDef("@HistoryOfDircardedProductsDate",GXType.Date,8,0) ,
          new ParDef("@HistoryOfDircardedProductsQuan",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmT000B11;
          prmT000B11 = new Object[] {
          new ParDef("@HistoryOfDircardedProductsDesc",GXType.NVarChar,200,0) ,
          new ParDef("@HistoryOfDircardedProductsDate",GXType.Date,8,0) ,
          new ParDef("@HistoryOfDircardedProductsQuan",GXType.Int16,4,0) ,
          new ParDef("@ProductId",GXType.Int32,6,0) ,
          new ParDef("@HistoryOfDircardedProductsId",GXType.Int32,6,0)
          };
          Object[] prmT000B12;
          prmT000B12 = new Object[] {
          new ParDef("@HistoryOfDircardedProductsId",GXType.Int32,6,0)
          };
          Object[] prmT000B14;
          prmT000B14 = new Object[] {
          };
          Object[] prmT000B13;
          prmT000B13 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("T000B2", "SELECT [HistoryOfDircardedProductsId], [HistoryOfDircardedProductsDesc], [HistoryOfDircardedProductsDate], [HistoryOfDircardedProductsQuan], [ProductId] FROM [HistoryOfDircardedProducts] WITH (UPDLOCK) WHERE [HistoryOfDircardedProductsId] = @HistoryOfDircardedProductsId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000B3", "SELECT [HistoryOfDircardedProductsId], [HistoryOfDircardedProductsDesc], [HistoryOfDircardedProductsDate], [HistoryOfDircardedProductsQuan], [ProductId] FROM [HistoryOfDircardedProducts] WHERE [HistoryOfDircardedProductsId] = @HistoryOfDircardedProductsId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000B4", "SELECT [ProductName], [ProductStock] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000B5", "SELECT TM1.[HistoryOfDircardedProductsId], T2.[ProductName], T2.[ProductStock], TM1.[HistoryOfDircardedProductsDesc], TM1.[HistoryOfDircardedProductsDate], TM1.[HistoryOfDircardedProductsQuan], TM1.[ProductId] FROM ([HistoryOfDircardedProducts] TM1 INNER JOIN [Product] T2 ON T2.[ProductId] = TM1.[ProductId]) WHERE TM1.[HistoryOfDircardedProductsId] = @HistoryOfDircardedProductsId ORDER BY TM1.[HistoryOfDircardedProductsId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000B5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000B6", "SELECT [ProductName], [ProductStock] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000B7", "SELECT [HistoryOfDircardedProductsId] FROM [HistoryOfDircardedProducts] WHERE [HistoryOfDircardedProductsId] = @HistoryOfDircardedProductsId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000B7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000B8", "SELECT TOP 1 [HistoryOfDircardedProductsId] FROM [HistoryOfDircardedProducts] WHERE ( [HistoryOfDircardedProductsId] > @HistoryOfDircardedProductsId) ORDER BY [HistoryOfDircardedProductsId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000B8,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000B9", "SELECT TOP 1 [HistoryOfDircardedProductsId] FROM [HistoryOfDircardedProducts] WHERE ( [HistoryOfDircardedProductsId] < @HistoryOfDircardedProductsId) ORDER BY [HistoryOfDircardedProductsId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000B9,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000B10", "INSERT INTO [HistoryOfDircardedProducts]([HistoryOfDircardedProductsDesc], [HistoryOfDircardedProductsDate], [HistoryOfDircardedProductsQuan], [ProductId]) VALUES(@HistoryOfDircardedProductsDesc, @HistoryOfDircardedProductsDate, @HistoryOfDircardedProductsQuan, @ProductId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000B10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000B11", "UPDATE [HistoryOfDircardedProducts] SET [HistoryOfDircardedProductsDesc]=@HistoryOfDircardedProductsDesc, [HistoryOfDircardedProductsDate]=@HistoryOfDircardedProductsDate, [HistoryOfDircardedProductsQuan]=@HistoryOfDircardedProductsQuan, [ProductId]=@ProductId  WHERE [HistoryOfDircardedProductsId] = @HistoryOfDircardedProductsId", GxErrorMask.GX_NOMASK,prmT000B11)
             ,new CursorDef("T000B12", "DELETE FROM [HistoryOfDircardedProducts]  WHERE [HistoryOfDircardedProductsId] = @HistoryOfDircardedProductsId", GxErrorMask.GX_NOMASK,prmT000B12)
             ,new CursorDef("T000B13", "SELECT [ProductName], [ProductStock] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000B14", "SELECT [HistoryOfDircardedProductsId] FROM [HistoryOfDircardedProducts] ORDER BY [HistoryOfDircardedProductsId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000B14,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
