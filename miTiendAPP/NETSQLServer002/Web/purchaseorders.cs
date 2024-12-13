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
   public class purchaseorders : GXDataArea
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
         gxfirstwebparm = GetNextPar( );
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A4SupplierId = (int)(Math.Round(NumberUtil.Val( GetPar( "SupplierId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A4SupplierId", StringUtil.LTrimStr( (decimal)(A4SupplierId), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A4SupplierId) ;
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
            gxfirstwebparm = GetNextPar( );
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetNextPar( );
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
            Form.Meta.addItem("description", "Purchase Orders", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPurchaseOrdersId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("mtaKB", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public purchaseorders( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public purchaseorders( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Purchase Orders", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_PurchaseOrders.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_PurchaseOrders.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_PurchaseOrders.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_PurchaseOrders.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_PurchaseOrders.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 4, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0070.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PURCHASEORDERSID"+"'), id:'"+"PURCHASEORDERSID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_PurchaseOrders.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPurchaseOrdersId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPurchaseOrdersId_Internalname, "Orders Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPurchaseOrdersId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A22PurchaseOrdersId), 6, 0, ".", "")), StringUtil.LTrim( ((edtPurchaseOrdersId_Enabled!=0) ? context.localUtil.Format( (decimal)(A22PurchaseOrdersId), "ZZZZZ9") : context.localUtil.Format( (decimal)(A22PurchaseOrdersId), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPurchaseOrdersId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPurchaseOrdersId_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_PurchaseOrders.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPurchaseOrdersPurchaseDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPurchaseOrdersPurchaseDate_Internalname, "Purchase Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPurchaseOrdersPurchaseDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPurchaseOrdersPurchaseDate_Internalname, context.localUtil.Format(A24PurchaseOrdersPurchaseDate, "99/99/99"), context.localUtil.Format( A24PurchaseOrdersPurchaseDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPurchaseOrdersPurchaseDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPurchaseOrdersPurchaseDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_PurchaseOrders.htm");
         GxWebStd.gx_bitmap( context, edtPurchaseOrdersPurchaseDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPurchaseOrdersPurchaseDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_PurchaseOrders.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSupplierId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSupplierId_Internalname, "Supplier Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSupplierId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A4SupplierId), 6, 0, ".", "")), StringUtil.LTrim( ((edtSupplierId_Enabled!=0) ? context.localUtil.Format( (decimal)(A4SupplierId), "ZZZZZ9") : context.localUtil.Format( (decimal)(A4SupplierId), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierId_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_PurchaseOrders.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_4_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_4_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_4_Internalname, sImgUrl, imgprompt_4_Link, "", "", context.GetTheme( ), imgprompt_4_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_PurchaseOrders.htm");
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
         GxWebStd.gx_single_line_edit( context, edtSupplierName_Internalname, A5SupplierName, StringUtil.RTrim( context.localUtil.Format( A5SupplierName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSupplierName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSupplierName_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Name", "left", true, "", "HLP_PurchaseOrders.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPurchaseOrdersCreatedDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPurchaseOrdersCreatedDate_Internalname, "Created Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPurchaseOrdersCreatedDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPurchaseOrdersCreatedDate_Internalname, context.localUtil.Format(A41PurchaseOrdersCreatedDate, "99/99/99"), context.localUtil.Format( A41PurchaseOrdersCreatedDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPurchaseOrdersCreatedDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPurchaseOrdersCreatedDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_PurchaseOrders.htm");
         GxWebStd.gx_bitmap( context, edtPurchaseOrdersCreatedDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPurchaseOrdersCreatedDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_PurchaseOrders.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPurchaseOrdersModifiedDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPurchaseOrdersModifiedDate_Internalname, "Modified Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPurchaseOrdersModifiedDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPurchaseOrdersModifiedDate_Internalname, context.localUtil.Format(A40PurchaseOrdersModifiedDate, "99/99/99"), context.localUtil.Format( A40PurchaseOrdersModifiedDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPurchaseOrdersModifiedDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPurchaseOrdersModifiedDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_PurchaseOrders.htm");
         GxWebStd.gx_bitmap( context, edtPurchaseOrdersModifiedDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPurchaseOrdersModifiedDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_PurchaseOrders.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_PurchaseOrders.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_PurchaseOrders.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_PurchaseOrders.htm");
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
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Z22PurchaseOrdersId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z22PurchaseOrdersId"), ".", ","), 18, MidpointRounding.ToEven));
            Z24PurchaseOrdersPurchaseDate = context.localUtil.CToD( cgiGet( "Z24PurchaseOrdersPurchaseDate"), 0);
            n24PurchaseOrdersPurchaseDate = ((DateTime.MinValue==A24PurchaseOrdersPurchaseDate) ? true : false);
            Z41PurchaseOrdersCreatedDate = context.localUtil.CToD( cgiGet( "Z41PurchaseOrdersCreatedDate"), 0);
            Z40PurchaseOrdersModifiedDate = context.localUtil.CToD( cgiGet( "Z40PurchaseOrdersModifiedDate"), 0);
            n40PurchaseOrdersModifiedDate = ((DateTime.MinValue==A40PurchaseOrdersModifiedDate) ? true : false);
            Z4SupplierId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z4SupplierId"), ".", ","), 18, MidpointRounding.ToEven));
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtPurchaseOrdersId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPurchaseOrdersId_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PURCHASEORDERSID");
               AnyError = 1;
               GX_FocusControl = edtPurchaseOrdersId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A22PurchaseOrdersId = 0;
               AssignAttri("", false, "A22PurchaseOrdersId", StringUtil.LTrimStr( (decimal)(A22PurchaseOrdersId), 6, 0));
            }
            else
            {
               A22PurchaseOrdersId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPurchaseOrdersId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A22PurchaseOrdersId", StringUtil.LTrimStr( (decimal)(A22PurchaseOrdersId), 6, 0));
            }
            if ( context.localUtil.VCDate( cgiGet( edtPurchaseOrdersPurchaseDate_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Purchase Orders Purchase Date"}), 1, "PURCHASEORDERSPURCHASEDATE");
               AnyError = 1;
               GX_FocusControl = edtPurchaseOrdersPurchaseDate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A24PurchaseOrdersPurchaseDate = DateTime.MinValue;
               n24PurchaseOrdersPurchaseDate = false;
               AssignAttri("", false, "A24PurchaseOrdersPurchaseDate", context.localUtil.Format(A24PurchaseOrdersPurchaseDate, "99/99/99"));
            }
            else
            {
               A24PurchaseOrdersPurchaseDate = context.localUtil.CToD( cgiGet( edtPurchaseOrdersPurchaseDate_Internalname), 1);
               n24PurchaseOrdersPurchaseDate = false;
               AssignAttri("", false, "A24PurchaseOrdersPurchaseDate", context.localUtil.Format(A24PurchaseOrdersPurchaseDate, "99/99/99"));
            }
            n24PurchaseOrdersPurchaseDate = ((DateTime.MinValue==A24PurchaseOrdersPurchaseDate) ? true : false);
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
            if ( context.localUtil.VCDate( cgiGet( edtPurchaseOrdersCreatedDate_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Purchase Orders Created Date"}), 1, "PURCHASEORDERSCREATEDDATE");
               AnyError = 1;
               GX_FocusControl = edtPurchaseOrdersCreatedDate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A41PurchaseOrdersCreatedDate = DateTime.MinValue;
               AssignAttri("", false, "A41PurchaseOrdersCreatedDate", context.localUtil.Format(A41PurchaseOrdersCreatedDate, "99/99/99"));
            }
            else
            {
               A41PurchaseOrdersCreatedDate = context.localUtil.CToD( cgiGet( edtPurchaseOrdersCreatedDate_Internalname), 1);
               AssignAttri("", false, "A41PurchaseOrdersCreatedDate", context.localUtil.Format(A41PurchaseOrdersCreatedDate, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtPurchaseOrdersModifiedDate_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Purchase Orders Modified Date"}), 1, "PURCHASEORDERSMODIFIEDDATE");
               AnyError = 1;
               GX_FocusControl = edtPurchaseOrdersModifiedDate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A40PurchaseOrdersModifiedDate = DateTime.MinValue;
               n40PurchaseOrdersModifiedDate = false;
               AssignAttri("", false, "A40PurchaseOrdersModifiedDate", context.localUtil.Format(A40PurchaseOrdersModifiedDate, "99/99/99"));
            }
            else
            {
               A40PurchaseOrdersModifiedDate = context.localUtil.CToD( cgiGet( edtPurchaseOrdersModifiedDate_Internalname), 1);
               n40PurchaseOrdersModifiedDate = false;
               AssignAttri("", false, "A40PurchaseOrdersModifiedDate", context.localUtil.Format(A40PurchaseOrdersModifiedDate, "99/99/99"));
            }
            n40PurchaseOrdersModifiedDate = ((DateTime.MinValue==A40PurchaseOrdersModifiedDate) ? true : false);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A22PurchaseOrdersId = (int)(Math.Round(NumberUtil.Val( GetPar( "PurchaseOrdersId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A22PurchaseOrdersId", StringUtil.LTrimStr( (decimal)(A22PurchaseOrdersId), 6, 0));
               getEqualNoModal( ) ;
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               disable_std_buttons_dsp( ) ;
               standaloneModal( ) ;
            }
            else
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               standaloneModal( ) ;
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
                        if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_first( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "PREVIOUS") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_previous( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_next( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_last( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "SELECT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_select( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_delete( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           AfterKeyLoadScreen( ) ;
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
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll077( ) ;
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
         if ( IsIns( ) )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
      }

      protected void disable_std_buttons_dsp( )
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
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) )
         {
            bttBtn_enter_Visible = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
         }
         DisableAttributes077( ) ;
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

      protected void ResetCaption070( )
      {
      }

      protected void ZM077( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z24PurchaseOrdersPurchaseDate = T00073_A24PurchaseOrdersPurchaseDate[0];
               Z41PurchaseOrdersCreatedDate = T00073_A41PurchaseOrdersCreatedDate[0];
               Z40PurchaseOrdersModifiedDate = T00073_A40PurchaseOrdersModifiedDate[0];
               Z4SupplierId = T00073_A4SupplierId[0];
            }
            else
            {
               Z24PurchaseOrdersPurchaseDate = A24PurchaseOrdersPurchaseDate;
               Z41PurchaseOrdersCreatedDate = A41PurchaseOrdersCreatedDate;
               Z40PurchaseOrdersModifiedDate = A40PurchaseOrdersModifiedDate;
               Z4SupplierId = A4SupplierId;
            }
         }
         if ( GX_JID == -4 )
         {
            Z22PurchaseOrdersId = A22PurchaseOrdersId;
            Z24PurchaseOrdersPurchaseDate = A24PurchaseOrdersPurchaseDate;
            Z41PurchaseOrdersCreatedDate = A41PurchaseOrdersCreatedDate;
            Z40PurchaseOrdersModifiedDate = A40PurchaseOrdersModifiedDate;
            Z4SupplierId = A4SupplierId;
            Z5SupplierName = A5SupplierName;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_4_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0020.aspx"+"',["+"{Ctrl:gx.dom.el('"+"SUPPLIERID"+"'), id:'"+"SUPPLIERID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_delete_Enabled = 1;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
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
      }

      protected void Load077( )
      {
         /* Using cursor T00075 */
         pr_default.execute(3, new Object[] {A22PurchaseOrdersId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound7 = 1;
            A24PurchaseOrdersPurchaseDate = T00075_A24PurchaseOrdersPurchaseDate[0];
            n24PurchaseOrdersPurchaseDate = T00075_n24PurchaseOrdersPurchaseDate[0];
            AssignAttri("", false, "A24PurchaseOrdersPurchaseDate", context.localUtil.Format(A24PurchaseOrdersPurchaseDate, "99/99/99"));
            A5SupplierName = T00075_A5SupplierName[0];
            AssignAttri("", false, "A5SupplierName", A5SupplierName);
            A41PurchaseOrdersCreatedDate = T00075_A41PurchaseOrdersCreatedDate[0];
            AssignAttri("", false, "A41PurchaseOrdersCreatedDate", context.localUtil.Format(A41PurchaseOrdersCreatedDate, "99/99/99"));
            A40PurchaseOrdersModifiedDate = T00075_A40PurchaseOrdersModifiedDate[0];
            n40PurchaseOrdersModifiedDate = T00075_n40PurchaseOrdersModifiedDate[0];
            AssignAttri("", false, "A40PurchaseOrdersModifiedDate", context.localUtil.Format(A40PurchaseOrdersModifiedDate, "99/99/99"));
            A4SupplierId = T00075_A4SupplierId[0];
            AssignAttri("", false, "A4SupplierId", StringUtil.LTrimStr( (decimal)(A4SupplierId), 6, 0));
            ZM077( -4) ;
         }
         pr_default.close(3);
         OnLoadActions077( ) ;
      }

      protected void OnLoadActions077( )
      {
      }

      protected void CheckExtendedTable077( )
      {
         nIsDirty_7 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A24PurchaseOrdersPurchaseDate) || ( DateTimeUtil.ResetTime ( A24PurchaseOrdersPurchaseDate ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Purchase Orders Purchase Date is out of range", "OutOfRange", 1, "PURCHASEORDERSPURCHASEDATE");
            AnyError = 1;
            GX_FocusControl = edtPurchaseOrdersPurchaseDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00074 */
         pr_default.execute(2, new Object[] {A4SupplierId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'Supplier'.", "ForeignKeyNotFound", 1, "SUPPLIERID");
            AnyError = 1;
            GX_FocusControl = edtSupplierId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A5SupplierName = T00074_A5SupplierName[0];
         AssignAttri("", false, "A5SupplierName", A5SupplierName);
         pr_default.close(2);
         if ( ! ( (DateTime.MinValue==A41PurchaseOrdersCreatedDate) || ( DateTimeUtil.ResetTime ( A41PurchaseOrdersCreatedDate ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Purchase Orders Created Date is out of range", "OutOfRange", 1, "PURCHASEORDERSCREATEDDATE");
            AnyError = 1;
            GX_FocusControl = edtPurchaseOrdersCreatedDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A40PurchaseOrdersModifiedDate) || ( DateTimeUtil.ResetTime ( A40PurchaseOrdersModifiedDate ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Purchase Orders Modified Date is out of range", "OutOfRange", 1, "PURCHASEORDERSMODIFIEDDATE");
            AnyError = 1;
            GX_FocusControl = edtPurchaseOrdersModifiedDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors077( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_5( int A4SupplierId )
      {
         /* Using cursor T00076 */
         pr_default.execute(4, new Object[] {A4SupplierId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No matching 'Supplier'.", "ForeignKeyNotFound", 1, "SUPPLIERID");
            AnyError = 1;
            GX_FocusControl = edtSupplierId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A5SupplierName = T00076_A5SupplierName[0];
         AssignAttri("", false, "A5SupplierName", A5SupplierName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A5SupplierName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey077( )
      {
         /* Using cursor T00077 */
         pr_default.execute(5, new Object[] {A22PurchaseOrdersId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound7 = 1;
         }
         else
         {
            RcdFound7 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00073 */
         pr_default.execute(1, new Object[] {A22PurchaseOrdersId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM077( 4) ;
            RcdFound7 = 1;
            A22PurchaseOrdersId = T00073_A22PurchaseOrdersId[0];
            AssignAttri("", false, "A22PurchaseOrdersId", StringUtil.LTrimStr( (decimal)(A22PurchaseOrdersId), 6, 0));
            A24PurchaseOrdersPurchaseDate = T00073_A24PurchaseOrdersPurchaseDate[0];
            n24PurchaseOrdersPurchaseDate = T00073_n24PurchaseOrdersPurchaseDate[0];
            AssignAttri("", false, "A24PurchaseOrdersPurchaseDate", context.localUtil.Format(A24PurchaseOrdersPurchaseDate, "99/99/99"));
            A41PurchaseOrdersCreatedDate = T00073_A41PurchaseOrdersCreatedDate[0];
            AssignAttri("", false, "A41PurchaseOrdersCreatedDate", context.localUtil.Format(A41PurchaseOrdersCreatedDate, "99/99/99"));
            A40PurchaseOrdersModifiedDate = T00073_A40PurchaseOrdersModifiedDate[0];
            n40PurchaseOrdersModifiedDate = T00073_n40PurchaseOrdersModifiedDate[0];
            AssignAttri("", false, "A40PurchaseOrdersModifiedDate", context.localUtil.Format(A40PurchaseOrdersModifiedDate, "99/99/99"));
            A4SupplierId = T00073_A4SupplierId[0];
            AssignAttri("", false, "A4SupplierId", StringUtil.LTrimStr( (decimal)(A4SupplierId), 6, 0));
            Z22PurchaseOrdersId = A22PurchaseOrdersId;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load077( ) ;
            if ( AnyError == 1 )
            {
               RcdFound7 = 0;
               InitializeNonKey077( ) ;
            }
            Gx_mode = sMode7;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound7 = 0;
            InitializeNonKey077( ) ;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode7;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey077( ) ;
         if ( RcdFound7 == 0 )
         {
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound7 = 0;
         /* Using cursor T00078 */
         pr_default.execute(6, new Object[] {A22PurchaseOrdersId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00078_A22PurchaseOrdersId[0] < A22PurchaseOrdersId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00078_A22PurchaseOrdersId[0] > A22PurchaseOrdersId ) ) )
            {
               A22PurchaseOrdersId = T00078_A22PurchaseOrdersId[0];
               AssignAttri("", false, "A22PurchaseOrdersId", StringUtil.LTrimStr( (decimal)(A22PurchaseOrdersId), 6, 0));
               RcdFound7 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound7 = 0;
         /* Using cursor T00079 */
         pr_default.execute(7, new Object[] {A22PurchaseOrdersId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00079_A22PurchaseOrdersId[0] > A22PurchaseOrdersId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00079_A22PurchaseOrdersId[0] < A22PurchaseOrdersId ) ) )
            {
               A22PurchaseOrdersId = T00079_A22PurchaseOrdersId[0];
               AssignAttri("", false, "A22PurchaseOrdersId", StringUtil.LTrimStr( (decimal)(A22PurchaseOrdersId), 6, 0));
               RcdFound7 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey077( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPurchaseOrdersId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert077( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound7 == 1 )
            {
               if ( A22PurchaseOrdersId != Z22PurchaseOrdersId )
               {
                  A22PurchaseOrdersId = Z22PurchaseOrdersId;
                  AssignAttri("", false, "A22PurchaseOrdersId", StringUtil.LTrimStr( (decimal)(A22PurchaseOrdersId), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PURCHASEORDERSID");
                  AnyError = 1;
                  GX_FocusControl = edtPurchaseOrdersId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPurchaseOrdersId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update077( ) ;
                  GX_FocusControl = edtPurchaseOrdersId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A22PurchaseOrdersId != Z22PurchaseOrdersId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtPurchaseOrdersId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert077( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PURCHASEORDERSID");
                     AnyError = 1;
                     GX_FocusControl = edtPurchaseOrdersId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtPurchaseOrdersId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert077( ) ;
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
      }

      protected void btn_delete( )
      {
         if ( A22PurchaseOrdersId != Z22PurchaseOrdersId )
         {
            A22PurchaseOrdersId = Z22PurchaseOrdersId;
            AssignAttri("", false, "A22PurchaseOrdersId", StringUtil.LTrimStr( (decimal)(A22PurchaseOrdersId), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PURCHASEORDERSID");
            AnyError = 1;
            GX_FocusControl = edtPurchaseOrdersId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPurchaseOrdersId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            getByPrimaryKey( ) ;
         }
         CloseOpenCursors();
      }

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound7 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PURCHASEORDERSID");
            AnyError = 1;
            GX_FocusControl = edtPurchaseOrdersId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtPurchaseOrdersPurchaseDate_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart077( ) ;
         if ( RcdFound7 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPurchaseOrdersPurchaseDate_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd077( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_previous( ) ;
         if ( RcdFound7 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPurchaseOrdersPurchaseDate_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_next( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_next( ) ;
         if ( RcdFound7 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPurchaseOrdersPurchaseDate_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart077( ) ;
         if ( RcdFound7 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound7 != 0 )
            {
               ScanNext077( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPurchaseOrdersPurchaseDate_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd077( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency077( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00072 */
            pr_default.execute(0, new Object[] {A22PurchaseOrdersId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PurchaseOrders"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z24PurchaseOrdersPurchaseDate ) != DateTimeUtil.ResetTime ( T00072_A24PurchaseOrdersPurchaseDate[0] ) ) || ( DateTimeUtil.ResetTime ( Z41PurchaseOrdersCreatedDate ) != DateTimeUtil.ResetTime ( T00072_A41PurchaseOrdersCreatedDate[0] ) ) || ( DateTimeUtil.ResetTime ( Z40PurchaseOrdersModifiedDate ) != DateTimeUtil.ResetTime ( T00072_A40PurchaseOrdersModifiedDate[0] ) ) || ( Z4SupplierId != T00072_A4SupplierId[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z24PurchaseOrdersPurchaseDate ) != DateTimeUtil.ResetTime ( T00072_A24PurchaseOrdersPurchaseDate[0] ) )
               {
                  GXUtil.WriteLog("purchaseorders:[seudo value changed for attri]"+"PurchaseOrdersPurchaseDate");
                  GXUtil.WriteLogRaw("Old: ",Z24PurchaseOrdersPurchaseDate);
                  GXUtil.WriteLogRaw("Current: ",T00072_A24PurchaseOrdersPurchaseDate[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z41PurchaseOrdersCreatedDate ) != DateTimeUtil.ResetTime ( T00072_A41PurchaseOrdersCreatedDate[0] ) )
               {
                  GXUtil.WriteLog("purchaseorders:[seudo value changed for attri]"+"PurchaseOrdersCreatedDate");
                  GXUtil.WriteLogRaw("Old: ",Z41PurchaseOrdersCreatedDate);
                  GXUtil.WriteLogRaw("Current: ",T00072_A41PurchaseOrdersCreatedDate[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z40PurchaseOrdersModifiedDate ) != DateTimeUtil.ResetTime ( T00072_A40PurchaseOrdersModifiedDate[0] ) )
               {
                  GXUtil.WriteLog("purchaseorders:[seudo value changed for attri]"+"PurchaseOrdersModifiedDate");
                  GXUtil.WriteLogRaw("Old: ",Z40PurchaseOrdersModifiedDate);
                  GXUtil.WriteLogRaw("Current: ",T00072_A40PurchaseOrdersModifiedDate[0]);
               }
               if ( Z4SupplierId != T00072_A4SupplierId[0] )
               {
                  GXUtil.WriteLog("purchaseorders:[seudo value changed for attri]"+"SupplierId");
                  GXUtil.WriteLogRaw("Old: ",Z4SupplierId);
                  GXUtil.WriteLogRaw("Current: ",T00072_A4SupplierId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"PurchaseOrders"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert077( )
      {
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable077( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM077( 0) ;
            CheckOptimisticConcurrency077( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm077( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert077( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000710 */
                     pr_default.execute(8, new Object[] {n24PurchaseOrdersPurchaseDate, A24PurchaseOrdersPurchaseDate, A41PurchaseOrdersCreatedDate, n40PurchaseOrdersModifiedDate, A40PurchaseOrdersModifiedDate, A4SupplierId});
                     A22PurchaseOrdersId = T000710_A22PurchaseOrdersId[0];
                     AssignAttri("", false, "A22PurchaseOrdersId", StringUtil.LTrimStr( (decimal)(A22PurchaseOrdersId), 6, 0));
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("PurchaseOrders");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption070( ) ;
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
               Load077( ) ;
            }
            EndLevel077( ) ;
         }
         CloseExtendedTableCursors077( ) ;
      }

      protected void Update077( )
      {
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable077( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency077( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm077( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate077( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000711 */
                     pr_default.execute(9, new Object[] {n24PurchaseOrdersPurchaseDate, A24PurchaseOrdersPurchaseDate, A41PurchaseOrdersCreatedDate, n40PurchaseOrdersModifiedDate, A40PurchaseOrdersModifiedDate, A4SupplierId, A22PurchaseOrdersId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("PurchaseOrders");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PurchaseOrders"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate077( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption070( ) ;
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
            EndLevel077( ) ;
         }
         CloseExtendedTableCursors077( ) ;
      }

      protected void DeferredUpdate077( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency077( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls077( ) ;
            AfterConfirm077( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete077( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000712 */
                  pr_default.execute(10, new Object[] {A22PurchaseOrdersId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("PurchaseOrders");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound7 == 0 )
                        {
                           InitAll077( ) ;
                           Gx_mode = "INS";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        else
                        {
                           getByPrimaryKey( ) ;
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                        ResetCaption070( ) ;
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
         sMode7 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel077( ) ;
         Gx_mode = sMode7;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls077( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000713 */
            pr_default.execute(11, new Object[] {A4SupplierId});
            A5SupplierName = T000713_A5SupplierName[0];
            AssignAttri("", false, "A5SupplierName", A5SupplierName);
            pr_default.close(11);
         }
      }

      protected void EndLevel077( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete077( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(11);
            context.CommitDataStores("purchaseorders",pr_default);
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
            pr_default.close(1);
            pr_default.close(11);
            context.RollbackDataStores("purchaseorders",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart077( )
      {
         /* Using cursor T000714 */
         pr_default.execute(12);
         RcdFound7 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound7 = 1;
            A22PurchaseOrdersId = T000714_A22PurchaseOrdersId[0];
            AssignAttri("", false, "A22PurchaseOrdersId", StringUtil.LTrimStr( (decimal)(A22PurchaseOrdersId), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext077( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound7 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound7 = 1;
            A22PurchaseOrdersId = T000714_A22PurchaseOrdersId[0];
            AssignAttri("", false, "A22PurchaseOrdersId", StringUtil.LTrimStr( (decimal)(A22PurchaseOrdersId), 6, 0));
         }
      }

      protected void ScanEnd077( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm077( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert077( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate077( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete077( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete077( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate077( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes077( )
      {
         edtPurchaseOrdersId_Enabled = 0;
         AssignProp("", false, edtPurchaseOrdersId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPurchaseOrdersId_Enabled), 5, 0), true);
         edtPurchaseOrdersPurchaseDate_Enabled = 0;
         AssignProp("", false, edtPurchaseOrdersPurchaseDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPurchaseOrdersPurchaseDate_Enabled), 5, 0), true);
         edtSupplierId_Enabled = 0;
         AssignProp("", false, edtSupplierId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierId_Enabled), 5, 0), true);
         edtSupplierName_Enabled = 0;
         AssignProp("", false, edtSupplierName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSupplierName_Enabled), 5, 0), true);
         edtPurchaseOrdersCreatedDate_Enabled = 0;
         AssignProp("", false, edtPurchaseOrdersCreatedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPurchaseOrdersCreatedDate_Enabled), 5, 0), true);
         edtPurchaseOrdersModifiedDate_Enabled = 0;
         AssignProp("", false, edtPurchaseOrdersModifiedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPurchaseOrdersModifiedDate_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes077( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues070( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("purchaseorders.aspx") +"\">") ;
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
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z22PurchaseOrdersId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z22PurchaseOrdersId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z24PurchaseOrdersPurchaseDate", context.localUtil.DToC( Z24PurchaseOrdersPurchaseDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z41PurchaseOrdersCreatedDate", context.localUtil.DToC( Z41PurchaseOrdersCreatedDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z40PurchaseOrdersModifiedDate", context.localUtil.DToC( Z40PurchaseOrdersModifiedDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z4SupplierId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z4SupplierId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
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
         return formatLink("purchaseorders.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "PurchaseOrders" ;
      }

      public override string GetPgmdesc( )
      {
         return "Purchase Orders" ;
      }

      protected void InitializeNonKey077( )
      {
         A24PurchaseOrdersPurchaseDate = DateTime.MinValue;
         n24PurchaseOrdersPurchaseDate = false;
         AssignAttri("", false, "A24PurchaseOrdersPurchaseDate", context.localUtil.Format(A24PurchaseOrdersPurchaseDate, "99/99/99"));
         n24PurchaseOrdersPurchaseDate = ((DateTime.MinValue==A24PurchaseOrdersPurchaseDate) ? true : false);
         A4SupplierId = 0;
         AssignAttri("", false, "A4SupplierId", StringUtil.LTrimStr( (decimal)(A4SupplierId), 6, 0));
         A5SupplierName = "";
         AssignAttri("", false, "A5SupplierName", A5SupplierName);
         A41PurchaseOrdersCreatedDate = DateTime.MinValue;
         AssignAttri("", false, "A41PurchaseOrdersCreatedDate", context.localUtil.Format(A41PurchaseOrdersCreatedDate, "99/99/99"));
         A40PurchaseOrdersModifiedDate = DateTime.MinValue;
         n40PurchaseOrdersModifiedDate = false;
         AssignAttri("", false, "A40PurchaseOrdersModifiedDate", context.localUtil.Format(A40PurchaseOrdersModifiedDate, "99/99/99"));
         n40PurchaseOrdersModifiedDate = ((DateTime.MinValue==A40PurchaseOrdersModifiedDate) ? true : false);
         Z24PurchaseOrdersPurchaseDate = DateTime.MinValue;
         Z41PurchaseOrdersCreatedDate = DateTime.MinValue;
         Z40PurchaseOrdersModifiedDate = DateTime.MinValue;
         Z4SupplierId = 0;
      }

      protected void InitAll077( )
      {
         A22PurchaseOrdersId = 0;
         AssignAttri("", false, "A22PurchaseOrdersId", StringUtil.LTrimStr( (decimal)(A22PurchaseOrdersId), 6, 0));
         InitializeNonKey077( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202310310311297", true, true);
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
         context.AddJavascriptSource("purchaseorders.js", "?202310310311298", false, true);
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
         edtPurchaseOrdersId_Internalname = "PURCHASEORDERSID";
         edtPurchaseOrdersPurchaseDate_Internalname = "PURCHASEORDERSPURCHASEDATE";
         edtSupplierId_Internalname = "SUPPLIERID";
         edtSupplierName_Internalname = "SUPPLIERNAME";
         edtPurchaseOrdersCreatedDate_Internalname = "PURCHASEORDERSCREATEDDATE";
         edtPurchaseOrdersModifiedDate_Internalname = "PURCHASEORDERSMODIFIEDDATE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
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
         Form.Caption = "Purchase Orders";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtPurchaseOrdersModifiedDate_Jsonclick = "";
         edtPurchaseOrdersModifiedDate_Enabled = 1;
         edtPurchaseOrdersCreatedDate_Jsonclick = "";
         edtPurchaseOrdersCreatedDate_Enabled = 1;
         edtSupplierName_Jsonclick = "";
         edtSupplierName_Enabled = 0;
         imgprompt_4_Visible = 1;
         imgprompt_4_Link = "";
         edtSupplierId_Jsonclick = "";
         edtSupplierId_Enabled = 1;
         edtPurchaseOrdersPurchaseDate_Jsonclick = "";
         edtPurchaseOrdersPurchaseDate_Enabled = 1;
         edtPurchaseOrdersId_Jsonclick = "";
         edtPurchaseOrdersId_Enabled = 1;
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

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtPurchaseOrdersPurchaseDate_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
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

      public void Valid_Purchaseordersid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A24PurchaseOrdersPurchaseDate", context.localUtil.Format(A24PurchaseOrdersPurchaseDate, "99/99/99"));
         AssignAttri("", false, "A4SupplierId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A4SupplierId), 6, 0, ".", "")));
         AssignAttri("", false, "A41PurchaseOrdersCreatedDate", context.localUtil.Format(A41PurchaseOrdersCreatedDate, "99/99/99"));
         AssignAttri("", false, "A40PurchaseOrdersModifiedDate", context.localUtil.Format(A40PurchaseOrdersModifiedDate, "99/99/99"));
         AssignAttri("", false, "A5SupplierName", A5SupplierName);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z22PurchaseOrdersId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z22PurchaseOrdersId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z24PurchaseOrdersPurchaseDate", context.localUtil.Format(Z24PurchaseOrdersPurchaseDate, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z4SupplierId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z4SupplierId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z41PurchaseOrdersCreatedDate", context.localUtil.Format(Z41PurchaseOrdersCreatedDate, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z40PurchaseOrdersModifiedDate", context.localUtil.Format(Z40PurchaseOrdersModifiedDate, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z5SupplierName", Z5SupplierName);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Supplierid( )
      {
         /* Using cursor T000713 */
         pr_default.execute(11, new Object[] {A4SupplierId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No matching 'Supplier'.", "ForeignKeyNotFound", 1, "SUPPLIERID");
            AnyError = 1;
            GX_FocusControl = edtSupplierId_Internalname;
         }
         A5SupplierName = T000713_A5SupplierName[0];
         pr_default.close(11);
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_PURCHASEORDERSID","{handler:'Valid_Purchaseordersid',iparms:[{av:'A22PurchaseOrdersId',fld:'PURCHASEORDERSID',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_PURCHASEORDERSID",",oparms:[{av:'A24PurchaseOrdersPurchaseDate',fld:'PURCHASEORDERSPURCHASEDATE',pic:''},{av:'A4SupplierId',fld:'SUPPLIERID',pic:'ZZZZZ9'},{av:'A41PurchaseOrdersCreatedDate',fld:'PURCHASEORDERSCREATEDDATE',pic:''},{av:'A40PurchaseOrdersModifiedDate',fld:'PURCHASEORDERSMODIFIEDDATE',pic:''},{av:'A5SupplierName',fld:'SUPPLIERNAME',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z22PurchaseOrdersId'},{av:'Z24PurchaseOrdersPurchaseDate'},{av:'Z4SupplierId'},{av:'Z41PurchaseOrdersCreatedDate'},{av:'Z40PurchaseOrdersModifiedDate'},{av:'Z5SupplierName'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_PURCHASEORDERSPURCHASEDATE","{handler:'Valid_Purchaseorderspurchasedate',iparms:[]");
         setEventMetadata("VALID_PURCHASEORDERSPURCHASEDATE",",oparms:[]}");
         setEventMetadata("VALID_SUPPLIERID","{handler:'Valid_Supplierid',iparms:[{av:'A4SupplierId',fld:'SUPPLIERID',pic:'ZZZZZ9'},{av:'A5SupplierName',fld:'SUPPLIERNAME',pic:''}]");
         setEventMetadata("VALID_SUPPLIERID",",oparms:[{av:'A5SupplierName',fld:'SUPPLIERNAME',pic:''}]}");
         setEventMetadata("VALID_PURCHASEORDERSCREATEDDATE","{handler:'Valid_Purchaseorderscreateddate',iparms:[]");
         setEventMetadata("VALID_PURCHASEORDERSCREATEDDATE",",oparms:[]}");
         setEventMetadata("VALID_PURCHASEORDERSMODIFIEDDATE","{handler:'Valid_Purchaseordersmodifieddate',iparms:[]");
         setEventMetadata("VALID_PURCHASEORDERSMODIFIEDDATE",",oparms:[]}");
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
         Z24PurchaseOrdersPurchaseDate = DateTime.MinValue;
         Z41PurchaseOrdersCreatedDate = DateTime.MinValue;
         Z40PurchaseOrdersModifiedDate = DateTime.MinValue;
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
         A24PurchaseOrdersPurchaseDate = DateTime.MinValue;
         imgprompt_4_gximage = "";
         sImgUrl = "";
         A5SupplierName = "";
         A41PurchaseOrdersCreatedDate = DateTime.MinValue;
         A40PurchaseOrdersModifiedDate = DateTime.MinValue;
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z5SupplierName = "";
         T00075_A22PurchaseOrdersId = new int[1] ;
         T00075_A24PurchaseOrdersPurchaseDate = new DateTime[] {DateTime.MinValue} ;
         T00075_n24PurchaseOrdersPurchaseDate = new bool[] {false} ;
         T00075_A5SupplierName = new string[] {""} ;
         T00075_A41PurchaseOrdersCreatedDate = new DateTime[] {DateTime.MinValue} ;
         T00075_A40PurchaseOrdersModifiedDate = new DateTime[] {DateTime.MinValue} ;
         T00075_n40PurchaseOrdersModifiedDate = new bool[] {false} ;
         T00075_A4SupplierId = new int[1] ;
         T00074_A5SupplierName = new string[] {""} ;
         T00076_A5SupplierName = new string[] {""} ;
         T00077_A22PurchaseOrdersId = new int[1] ;
         T00073_A22PurchaseOrdersId = new int[1] ;
         T00073_A24PurchaseOrdersPurchaseDate = new DateTime[] {DateTime.MinValue} ;
         T00073_n24PurchaseOrdersPurchaseDate = new bool[] {false} ;
         T00073_A41PurchaseOrdersCreatedDate = new DateTime[] {DateTime.MinValue} ;
         T00073_A40PurchaseOrdersModifiedDate = new DateTime[] {DateTime.MinValue} ;
         T00073_n40PurchaseOrdersModifiedDate = new bool[] {false} ;
         T00073_A4SupplierId = new int[1] ;
         sMode7 = "";
         T00078_A22PurchaseOrdersId = new int[1] ;
         T00079_A22PurchaseOrdersId = new int[1] ;
         T00072_A22PurchaseOrdersId = new int[1] ;
         T00072_A24PurchaseOrdersPurchaseDate = new DateTime[] {DateTime.MinValue} ;
         T00072_n24PurchaseOrdersPurchaseDate = new bool[] {false} ;
         T00072_A41PurchaseOrdersCreatedDate = new DateTime[] {DateTime.MinValue} ;
         T00072_A40PurchaseOrdersModifiedDate = new DateTime[] {DateTime.MinValue} ;
         T00072_n40PurchaseOrdersModifiedDate = new bool[] {false} ;
         T00072_A4SupplierId = new int[1] ;
         T000710_A22PurchaseOrdersId = new int[1] ;
         T000713_A5SupplierName = new string[] {""} ;
         T000714_A22PurchaseOrdersId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ24PurchaseOrdersPurchaseDate = DateTime.MinValue;
         ZZ41PurchaseOrdersCreatedDate = DateTime.MinValue;
         ZZ40PurchaseOrdersModifiedDate = DateTime.MinValue;
         ZZ5SupplierName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.purchaseorders__default(),
            new Object[][] {
                new Object[] {
               T00072_A22PurchaseOrdersId, T00072_A24PurchaseOrdersPurchaseDate, T00072_n24PurchaseOrdersPurchaseDate, T00072_A41PurchaseOrdersCreatedDate, T00072_A40PurchaseOrdersModifiedDate, T00072_n40PurchaseOrdersModifiedDate, T00072_A4SupplierId
               }
               , new Object[] {
               T00073_A22PurchaseOrdersId, T00073_A24PurchaseOrdersPurchaseDate, T00073_n24PurchaseOrdersPurchaseDate, T00073_A41PurchaseOrdersCreatedDate, T00073_A40PurchaseOrdersModifiedDate, T00073_n40PurchaseOrdersModifiedDate, T00073_A4SupplierId
               }
               , new Object[] {
               T00074_A5SupplierName
               }
               , new Object[] {
               T00075_A22PurchaseOrdersId, T00075_A24PurchaseOrdersPurchaseDate, T00075_n24PurchaseOrdersPurchaseDate, T00075_A5SupplierName, T00075_A41PurchaseOrdersCreatedDate, T00075_A40PurchaseOrdersModifiedDate, T00075_n40PurchaseOrdersModifiedDate, T00075_A4SupplierId
               }
               , new Object[] {
               T00076_A5SupplierName
               }
               , new Object[] {
               T00077_A22PurchaseOrdersId
               }
               , new Object[] {
               T00078_A22PurchaseOrdersId
               }
               , new Object[] {
               T00079_A22PurchaseOrdersId
               }
               , new Object[] {
               T000710_A22PurchaseOrdersId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000713_A5SupplierName
               }
               , new Object[] {
               T000714_A22PurchaseOrdersId
               }
            }
         );
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short GX_JID ;
      private short RcdFound7 ;
      private short nIsDirty_7 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z22PurchaseOrdersId ;
      private int Z4SupplierId ;
      private int A4SupplierId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A22PurchaseOrdersId ;
      private int edtPurchaseOrdersId_Enabled ;
      private int edtPurchaseOrdersPurchaseDate_Enabled ;
      private int edtSupplierId_Enabled ;
      private int imgprompt_4_Visible ;
      private int edtSupplierName_Enabled ;
      private int edtPurchaseOrdersCreatedDate_Enabled ;
      private int edtPurchaseOrdersModifiedDate_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ22PurchaseOrdersId ;
      private int ZZ4SupplierId ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPurchaseOrdersId_Internalname ;
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
      private string edtPurchaseOrdersId_Jsonclick ;
      private string edtPurchaseOrdersPurchaseDate_Internalname ;
      private string edtPurchaseOrdersPurchaseDate_Jsonclick ;
      private string edtSupplierId_Internalname ;
      private string edtSupplierId_Jsonclick ;
      private string imgprompt_4_gximage ;
      private string sImgUrl ;
      private string imgprompt_4_Internalname ;
      private string imgprompt_4_Link ;
      private string edtSupplierName_Internalname ;
      private string edtSupplierName_Jsonclick ;
      private string edtPurchaseOrdersCreatedDate_Internalname ;
      private string edtPurchaseOrdersCreatedDate_Jsonclick ;
      private string edtPurchaseOrdersModifiedDate_Internalname ;
      private string edtPurchaseOrdersModifiedDate_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string Gx_mode ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode7 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z24PurchaseOrdersPurchaseDate ;
      private DateTime Z41PurchaseOrdersCreatedDate ;
      private DateTime Z40PurchaseOrdersModifiedDate ;
      private DateTime A24PurchaseOrdersPurchaseDate ;
      private DateTime A41PurchaseOrdersCreatedDate ;
      private DateTime A40PurchaseOrdersModifiedDate ;
      private DateTime ZZ24PurchaseOrdersPurchaseDate ;
      private DateTime ZZ41PurchaseOrdersCreatedDate ;
      private DateTime ZZ40PurchaseOrdersModifiedDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n24PurchaseOrdersPurchaseDate ;
      private bool n40PurchaseOrdersModifiedDate ;
      private string A5SupplierName ;
      private string Z5SupplierName ;
      private string ZZ5SupplierName ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T00075_A22PurchaseOrdersId ;
      private DateTime[] T00075_A24PurchaseOrdersPurchaseDate ;
      private bool[] T00075_n24PurchaseOrdersPurchaseDate ;
      private string[] T00075_A5SupplierName ;
      private DateTime[] T00075_A41PurchaseOrdersCreatedDate ;
      private DateTime[] T00075_A40PurchaseOrdersModifiedDate ;
      private bool[] T00075_n40PurchaseOrdersModifiedDate ;
      private int[] T00075_A4SupplierId ;
      private string[] T00074_A5SupplierName ;
      private string[] T00076_A5SupplierName ;
      private int[] T00077_A22PurchaseOrdersId ;
      private int[] T00073_A22PurchaseOrdersId ;
      private DateTime[] T00073_A24PurchaseOrdersPurchaseDate ;
      private bool[] T00073_n24PurchaseOrdersPurchaseDate ;
      private DateTime[] T00073_A41PurchaseOrdersCreatedDate ;
      private DateTime[] T00073_A40PurchaseOrdersModifiedDate ;
      private bool[] T00073_n40PurchaseOrdersModifiedDate ;
      private int[] T00073_A4SupplierId ;
      private int[] T00078_A22PurchaseOrdersId ;
      private int[] T00079_A22PurchaseOrdersId ;
      private int[] T00072_A22PurchaseOrdersId ;
      private DateTime[] T00072_A24PurchaseOrdersPurchaseDate ;
      private bool[] T00072_n24PurchaseOrdersPurchaseDate ;
      private DateTime[] T00072_A41PurchaseOrdersCreatedDate ;
      private DateTime[] T00072_A40PurchaseOrdersModifiedDate ;
      private bool[] T00072_n40PurchaseOrdersModifiedDate ;
      private int[] T00072_A4SupplierId ;
      private int[] T000710_A22PurchaseOrdersId ;
      private string[] T000713_A5SupplierName ;
      private int[] T000714_A22PurchaseOrdersId ;
      private GXWebForm Form ;
   }

   public class purchaseorders__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT00075;
          prmT00075 = new Object[] {
          new ParDef("@PurchaseOrdersId",GXType.Int32,6,0)
          };
          Object[] prmT00074;
          prmT00074 = new Object[] {
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          Object[] prmT00076;
          prmT00076 = new Object[] {
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          Object[] prmT00077;
          prmT00077 = new Object[] {
          new ParDef("@PurchaseOrdersId",GXType.Int32,6,0)
          };
          Object[] prmT00073;
          prmT00073 = new Object[] {
          new ParDef("@PurchaseOrdersId",GXType.Int32,6,0)
          };
          Object[] prmT00078;
          prmT00078 = new Object[] {
          new ParDef("@PurchaseOrdersId",GXType.Int32,6,0)
          };
          Object[] prmT00079;
          prmT00079 = new Object[] {
          new ParDef("@PurchaseOrdersId",GXType.Int32,6,0)
          };
          Object[] prmT00072;
          prmT00072 = new Object[] {
          new ParDef("@PurchaseOrdersId",GXType.Int32,6,0)
          };
          Object[] prmT000710;
          prmT000710 = new Object[] {
          new ParDef("@PurchaseOrdersPurchaseDate",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@PurchaseOrdersCreatedDate",GXType.Date,8,0) ,
          new ParDef("@PurchaseOrdersModifiedDate",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          Object[] prmT000711;
          prmT000711 = new Object[] {
          new ParDef("@PurchaseOrdersPurchaseDate",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@PurchaseOrdersCreatedDate",GXType.Date,8,0) ,
          new ParDef("@PurchaseOrdersModifiedDate",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@SupplierId",GXType.Int32,6,0) ,
          new ParDef("@PurchaseOrdersId",GXType.Int32,6,0)
          };
          Object[] prmT000712;
          prmT000712 = new Object[] {
          new ParDef("@PurchaseOrdersId",GXType.Int32,6,0)
          };
          Object[] prmT000714;
          prmT000714 = new Object[] {
          };
          Object[] prmT000713;
          prmT000713 = new Object[] {
          new ParDef("@SupplierId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00072", "SELECT [PurchaseOrdersId], [PurchaseOrdersPurchaseDate], [PurchaseOrdersCreatedDate], [PurchaseOrdersModifiedDate], [SupplierId] FROM [PurchaseOrders] WITH (UPDLOCK) WHERE [PurchaseOrdersId] = @PurchaseOrdersId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00072,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00073", "SELECT [PurchaseOrdersId], [PurchaseOrdersPurchaseDate], [PurchaseOrdersCreatedDate], [PurchaseOrdersModifiedDate], [SupplierId] FROM [PurchaseOrders] WHERE [PurchaseOrdersId] = @PurchaseOrdersId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00073,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00074", "SELECT [SupplierName] FROM [Supplier] WHERE [SupplierId] = @SupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00074,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00075", "SELECT TM1.[PurchaseOrdersId], TM1.[PurchaseOrdersPurchaseDate], T2.[SupplierName], TM1.[PurchaseOrdersCreatedDate], TM1.[PurchaseOrdersModifiedDate], TM1.[SupplierId] FROM ([PurchaseOrders] TM1 INNER JOIN [Supplier] T2 ON T2.[SupplierId] = TM1.[SupplierId]) WHERE TM1.[PurchaseOrdersId] = @PurchaseOrdersId ORDER BY TM1.[PurchaseOrdersId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00075,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00076", "SELECT [SupplierName] FROM [Supplier] WHERE [SupplierId] = @SupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00076,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00077", "SELECT [PurchaseOrdersId] FROM [PurchaseOrders] WHERE [PurchaseOrdersId] = @PurchaseOrdersId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00077,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00078", "SELECT TOP 1 [PurchaseOrdersId] FROM [PurchaseOrders] WHERE ( [PurchaseOrdersId] > @PurchaseOrdersId) ORDER BY [PurchaseOrdersId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00078,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00079", "SELECT TOP 1 [PurchaseOrdersId] FROM [PurchaseOrders] WHERE ( [PurchaseOrdersId] < @PurchaseOrdersId) ORDER BY [PurchaseOrdersId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00079,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000710", "INSERT INTO [PurchaseOrders]([PurchaseOrdersPurchaseDate], [PurchaseOrdersCreatedDate], [PurchaseOrdersModifiedDate], [SupplierId]) VALUES(@PurchaseOrdersPurchaseDate, @PurchaseOrdersCreatedDate, @PurchaseOrdersModifiedDate, @SupplierId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000710,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000711", "UPDATE [PurchaseOrders] SET [PurchaseOrdersPurchaseDate]=@PurchaseOrdersPurchaseDate, [PurchaseOrdersCreatedDate]=@PurchaseOrdersCreatedDate, [PurchaseOrdersModifiedDate]=@PurchaseOrdersModifiedDate, [SupplierId]=@SupplierId  WHERE [PurchaseOrdersId] = @PurchaseOrdersId", GxErrorMask.GX_NOMASK,prmT000711)
             ,new CursorDef("T000712", "DELETE FROM [PurchaseOrders]  WHERE [PurchaseOrdersId] = @PurchaseOrdersId", GxErrorMask.GX_NOMASK,prmT000712)
             ,new CursorDef("T000713", "SELECT [SupplierName] FROM [Supplier] WHERE [SupplierId] = @SupplierId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000713,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000714", "SELECT [PurchaseOrdersId] FROM [PurchaseOrders] ORDER BY [PurchaseOrdersId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000714,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((int[]) buf[6])[0] = rslt.getInt(5);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((int[]) buf[6])[0] = rslt.getInt(5);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((int[]) buf[7])[0] = rslt.getInt(6);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
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
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
