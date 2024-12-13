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
namespace GeneXus.Programs.general {
   public class productperishable : GXDataArea
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
               AV7ProductPerishableId = (int)(Math.Round(NumberUtil.Val( GetPar( "ProductPerishableId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7ProductPerishableId", StringUtil.LTrimStr( (decimal)(AV7ProductPerishableId), 6, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vPRODUCTPERISHABLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ProductPerishableId), "ZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Product Perishable", 0) ;
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

      public productperishable( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public productperishable( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_ProductPerishableId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ProductPerishableId = aP1_ProductPerishableId;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Product Perishable", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_General\\ProductPerishable.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_General\\ProductPerishable.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_General\\ProductPerishable.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_General\\ProductPerishable.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_General\\ProductPerishable.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_General\\ProductPerishable.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductPerishableId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductPerishableId_Internalname, "Perishable Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtProductPerishableId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A70ProductPerishableId), 6, 0, ".", "")), StringUtil.LTrim( ((edtProductPerishableId_Enabled!=0) ? context.localUtil.Format( (decimal)(A70ProductPerishableId), "ZZZZZ9") : context.localUtil.Format( (decimal)(A70ProductPerishableId), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductPerishableId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductPerishableId_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_General\\ProductPerishable.htm");
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
         GxWebStd.gx_single_line_edit( context, edtProductId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A15ProductId), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A15ProductId), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductId_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_General\\ProductPerishable.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_15_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_15_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_15_Internalname, sImgUrl, imgprompt_15_Link, "", "", context.GetTheme( ), imgprompt_15_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_General\\ProductPerishable.htm");
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
         GxWebStd.gx_single_line_edit( context, edtProductName_Internalname, A16ProductName, StringUtil.RTrim( context.localUtil.Format( A16ProductName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductName_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Name", "left", true, "", "HLP_General\\ProductPerishable.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductPerishableBatchDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductPerishableBatchDate_Internalname, "Batch Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtProductPerishableBatchDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtProductPerishableBatchDate_Internalname, context.localUtil.Format(A71ProductPerishableBatchDate, "99/99/99"), context.localUtil.Format( A71ProductPerishableBatchDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductPerishableBatchDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductPerishableBatchDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_General\\ProductPerishable.htm");
         GxWebStd.gx_bitmap( context, edtProductPerishableBatchDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtProductPerishableBatchDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_General\\ProductPerishable.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductPerishableExpirationDat_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductPerishableExpirationDat_Internalname, "Expiration Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtProductPerishableExpirationDat_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtProductPerishableExpirationDat_Internalname, context.localUtil.Format(A72ProductPerishableExpirationDat, "99/99/99"), context.localUtil.Format( A72ProductPerishableExpirationDat, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductPerishableExpirationDat_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductPerishableExpirationDat_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_General\\ProductPerishable.htm");
         GxWebStd.gx_bitmap( context, edtProductPerishableExpirationDat_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtProductPerishableExpirationDat_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_General\\ProductPerishable.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductPerishableCreatedDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductPerishableCreatedDate_Internalname, "Created Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         context.WriteHtmlText( "<div id=\""+edtProductPerishableCreatedDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtProductPerishableCreatedDate_Internalname, context.localUtil.Format(A73ProductPerishableCreatedDate, "99/99/99"), context.localUtil.Format( A73ProductPerishableCreatedDate, "99/99/99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductPerishableCreatedDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductPerishableCreatedDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_General\\ProductPerishable.htm");
         GxWebStd.gx_bitmap( context, edtProductPerishableCreatedDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtProductPerishableCreatedDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_General\\ProductPerishable.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProductPerishableModifiedDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProductPerishableModifiedDate_Internalname, "Modified Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtProductPerishableModifiedDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtProductPerishableModifiedDate_Internalname, context.localUtil.Format(A74ProductPerishableModifiedDate, "99/99/99"), context.localUtil.Format( A74ProductPerishableModifiedDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProductPerishableModifiedDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProductPerishableModifiedDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_General\\ProductPerishable.htm");
         GxWebStd.gx_bitmap( context, edtProductPerishableModifiedDate_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtProductPerishableModifiedDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_General\\ProductPerishable.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_General\\ProductPerishable.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_General\\ProductPerishable.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_General\\ProductPerishable.htm");
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
         E110A2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z70ProductPerishableId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z70ProductPerishableId"), ".", ","), 18, MidpointRounding.ToEven));
               Z71ProductPerishableBatchDate = context.localUtil.CToD( cgiGet( "Z71ProductPerishableBatchDate"), 0);
               Z72ProductPerishableExpirationDat = context.localUtil.CToD( cgiGet( "Z72ProductPerishableExpirationDat"), 0);
               Z73ProductPerishableCreatedDate = context.localUtil.CToD( cgiGet( "Z73ProductPerishableCreatedDate"), 0);
               Z74ProductPerishableModifiedDate = context.localUtil.CToD( cgiGet( "Z74ProductPerishableModifiedDate"), 0);
               Z15ProductId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z15ProductId"), ".", ","), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N15ProductId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N15ProductId"), ".", ","), 18, MidpointRounding.ToEven));
               AV7ProductPerishableId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vPRODUCTPERISHABLEID"), ".", ","), 18, MidpointRounding.ToEven));
               AV11Insert_ProductId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_PRODUCTID"), ".", ","), 18, MidpointRounding.ToEven));
               Gx_date = context.localUtil.CToD( cgiGet( "vTODAY"), 0);
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","), 18, MidpointRounding.ToEven));
               AV15Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A70ProductPerishableId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtProductPerishableId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A70ProductPerishableId", StringUtil.LTrimStr( (decimal)(A70ProductPerishableId), 6, 0));
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
               if ( context.localUtil.VCDate( cgiGet( edtProductPerishableBatchDate_Internalname), 1) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Product Perishable Batch Date"}), 1, "PRODUCTPERISHABLEBATCHDATE");
                  AnyError = 1;
                  GX_FocusControl = edtProductPerishableBatchDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A71ProductPerishableBatchDate = DateTime.MinValue;
                  AssignAttri("", false, "A71ProductPerishableBatchDate", context.localUtil.Format(A71ProductPerishableBatchDate, "99/99/99"));
               }
               else
               {
                  A71ProductPerishableBatchDate = context.localUtil.CToD( cgiGet( edtProductPerishableBatchDate_Internalname), 1);
                  AssignAttri("", false, "A71ProductPerishableBatchDate", context.localUtil.Format(A71ProductPerishableBatchDate, "99/99/99"));
               }
               if ( context.localUtil.VCDate( cgiGet( edtProductPerishableExpirationDat_Internalname), 1) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Product Perishable Expiration Date"}), 1, "PRODUCTPERISHABLEEXPIRATIONDAT");
                  AnyError = 1;
                  GX_FocusControl = edtProductPerishableExpirationDat_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A72ProductPerishableExpirationDat = DateTime.MinValue;
                  AssignAttri("", false, "A72ProductPerishableExpirationDat", context.localUtil.Format(A72ProductPerishableExpirationDat, "99/99/99"));
               }
               else
               {
                  A72ProductPerishableExpirationDat = context.localUtil.CToD( cgiGet( edtProductPerishableExpirationDat_Internalname), 1);
                  AssignAttri("", false, "A72ProductPerishableExpirationDat", context.localUtil.Format(A72ProductPerishableExpirationDat, "99/99/99"));
               }
               A73ProductPerishableCreatedDate = context.localUtil.CToD( cgiGet( edtProductPerishableCreatedDate_Internalname), 1);
               AssignAttri("", false, "A73ProductPerishableCreatedDate", context.localUtil.Format(A73ProductPerishableCreatedDate, "99/99/99"));
               if ( context.localUtil.VCDate( cgiGet( edtProductPerishableModifiedDate_Internalname), 1) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Product Perishable Modified Date"}), 1, "PRODUCTPERISHABLEMODIFIEDDATE");
                  AnyError = 1;
                  GX_FocusControl = edtProductPerishableModifiedDate_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A74ProductPerishableModifiedDate = DateTime.MinValue;
                  AssignAttri("", false, "A74ProductPerishableModifiedDate", context.localUtil.Format(A74ProductPerishableModifiedDate, "99/99/99"));
               }
               else
               {
                  A74ProductPerishableModifiedDate = context.localUtil.CToD( cgiGet( edtProductPerishableModifiedDate_Internalname), 1);
                  AssignAttri("", false, "A74ProductPerishableModifiedDate", context.localUtil.Format(A74ProductPerishableModifiedDate, "99/99/99"));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"ProductPerishable");
               A70ProductPerishableId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtProductPerishableId_Internalname), ".", ","), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A70ProductPerishableId", StringUtil.LTrimStr( (decimal)(A70ProductPerishableId), 6, 0));
               forbiddenHiddens.Add("ProductPerishableId", context.localUtil.Format( (decimal)(A70ProductPerishableId), "ZZZZZ9"));
               A73ProductPerishableCreatedDate = context.localUtil.CToD( cgiGet( edtProductPerishableCreatedDate_Internalname), 1);
               AssignAttri("", false, "A73ProductPerishableCreatedDate", context.localUtil.Format(A73ProductPerishableCreatedDate, "99/99/99"));
               forbiddenHiddens.Add("ProductPerishableCreatedDate", context.localUtil.Format(A73ProductPerishableCreatedDate, "99/99/99"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A70ProductPerishableId != Z70ProductPerishableId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("general\\productperishable:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A70ProductPerishableId = (int)(Math.Round(NumberUtil.Val( GetPar( "ProductPerishableId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A70ProductPerishableId", StringUtil.LTrimStr( (decimal)(A70ProductPerishableId), 6, 0));
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
                     sMode14 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode14;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound14 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0A0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "PRODUCTPERISHABLEID");
                        AnyError = 1;
                        GX_FocusControl = edtProductPerishableId_Internalname;
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
                           E110A2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120A2 ();
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
            E120A2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0A14( ) ;
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
            DisableAttributes0A14( ) ;
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

      protected void CONFIRM_0A0( )
      {
         BeforeValidate0A14( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0A14( ) ;
            }
            else
            {
               CheckExtendedTable0A14( ) ;
               CloseExtendedTableCursors0A14( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0A0( )
      {
      }

      protected void E110A2( )
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

      protected void E120A2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwproductperishable.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0A14( short GX_JID )
      {
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z71ProductPerishableBatchDate = T000A3_A71ProductPerishableBatchDate[0];
               Z72ProductPerishableExpirationDat = T000A3_A72ProductPerishableExpirationDat[0];
               Z73ProductPerishableCreatedDate = T000A3_A73ProductPerishableCreatedDate[0];
               Z74ProductPerishableModifiedDate = T000A3_A74ProductPerishableModifiedDate[0];
               Z15ProductId = T000A3_A15ProductId[0];
            }
            else
            {
               Z71ProductPerishableBatchDate = A71ProductPerishableBatchDate;
               Z72ProductPerishableExpirationDat = A72ProductPerishableExpirationDat;
               Z73ProductPerishableCreatedDate = A73ProductPerishableCreatedDate;
               Z74ProductPerishableModifiedDate = A74ProductPerishableModifiedDate;
               Z15ProductId = A15ProductId;
            }
         }
         if ( GX_JID == -13 )
         {
            Z70ProductPerishableId = A70ProductPerishableId;
            Z71ProductPerishableBatchDate = A71ProductPerishableBatchDate;
            Z72ProductPerishableExpirationDat = A72ProductPerishableExpirationDat;
            Z73ProductPerishableCreatedDate = A73ProductPerishableCreatedDate;
            Z74ProductPerishableModifiedDate = A74ProductPerishableModifiedDate;
            Z15ProductId = A15ProductId;
            Z16ProductName = A16ProductName;
         }
      }

      protected void standaloneNotModal( )
      {
         edtProductPerishableId_Enabled = 0;
         AssignProp("", false, edtProductPerishableId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductPerishableId_Enabled), 5, 0), true);
         edtProductPerishableCreatedDate_Enabled = 0;
         AssignProp("", false, edtProductPerishableCreatedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductPerishableCreatedDate_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         Gx_date = DateTimeUtil.Today( context);
         AssignAttri("", false, "Gx_date", context.localUtil.Format(Gx_date, "99/99/99"));
         imgprompt_15_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0050.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PRODUCTID"+"'), id:'"+"PRODUCTID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtProductPerishableId_Enabled = 0;
         AssignProp("", false, edtProductPerishableId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductPerishableId_Enabled), 5, 0), true);
         edtProductPerishableCreatedDate_Enabled = 0;
         AssignProp("", false, edtProductPerishableCreatedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductPerishableCreatedDate_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7ProductPerishableId) )
         {
            A70ProductPerishableId = AV7ProductPerishableId;
            AssignAttri("", false, "A70ProductPerishableId", StringUtil.LTrimStr( (decimal)(A70ProductPerishableId), 6, 0));
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
         if ( IsIns( )  && (DateTime.MinValue==A73ProductPerishableCreatedDate) && ( Gx_BScreen == 0 ) )
         {
            A73ProductPerishableCreatedDate = Gx_date;
            AssignAttri("", false, "A73ProductPerishableCreatedDate", context.localUtil.Format(A73ProductPerishableCreatedDate, "99/99/99"));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV15Pgmname = "General.ProductPerishable";
            AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
            /* Using cursor T000A4 */
            pr_default.execute(2, new Object[] {A15ProductId});
            A16ProductName = T000A4_A16ProductName[0];
            AssignAttri("", false, "A16ProductName", A16ProductName);
            pr_default.close(2);
         }
      }

      protected void Load0A14( )
      {
         /* Using cursor T000A5 */
         pr_default.execute(3, new Object[] {A70ProductPerishableId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound14 = 1;
            A16ProductName = T000A5_A16ProductName[0];
            AssignAttri("", false, "A16ProductName", A16ProductName);
            A71ProductPerishableBatchDate = T000A5_A71ProductPerishableBatchDate[0];
            AssignAttri("", false, "A71ProductPerishableBatchDate", context.localUtil.Format(A71ProductPerishableBatchDate, "99/99/99"));
            A72ProductPerishableExpirationDat = T000A5_A72ProductPerishableExpirationDat[0];
            AssignAttri("", false, "A72ProductPerishableExpirationDat", context.localUtil.Format(A72ProductPerishableExpirationDat, "99/99/99"));
            A73ProductPerishableCreatedDate = T000A5_A73ProductPerishableCreatedDate[0];
            AssignAttri("", false, "A73ProductPerishableCreatedDate", context.localUtil.Format(A73ProductPerishableCreatedDate, "99/99/99"));
            A74ProductPerishableModifiedDate = T000A5_A74ProductPerishableModifiedDate[0];
            AssignAttri("", false, "A74ProductPerishableModifiedDate", context.localUtil.Format(A74ProductPerishableModifiedDate, "99/99/99"));
            A15ProductId = T000A5_A15ProductId[0];
            AssignAttri("", false, "A15ProductId", StringUtil.LTrimStr( (decimal)(A15ProductId), 6, 0));
            ZM0A14( -13) ;
         }
         pr_default.close(3);
         OnLoadActions0A14( ) ;
      }

      protected void OnLoadActions0A14( )
      {
         AV15Pgmname = "General.ProductPerishable";
         AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
      }

      protected void CheckExtendedTable0A14( )
      {
         nIsDirty_14 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV15Pgmname = "General.ProductPerishable";
         AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
         /* Using cursor T000A4 */
         pr_default.execute(2, new Object[] {A15ProductId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'Product'.", "ForeignKeyNotFound", 1, "PRODUCTID");
            AnyError = 1;
            GX_FocusControl = edtProductId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A16ProductName = T000A4_A16ProductName[0];
         AssignAttri("", false, "A16ProductName", A16ProductName);
         pr_default.close(2);
         if ( ! ( (DateTime.MinValue==A71ProductPerishableBatchDate) || ( DateTimeUtil.ResetTime ( A71ProductPerishableBatchDate ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Product Perishable Batch Date is out of range", "OutOfRange", 1, "PRODUCTPERISHABLEBATCHDATE");
            AnyError = 1;
            GX_FocusControl = edtProductPerishableBatchDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A72ProductPerishableExpirationDat) || ( DateTimeUtil.ResetTime ( A72ProductPerishableExpirationDat ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Product Perishable Expiration Date is out of range", "OutOfRange", 1, "PRODUCTPERISHABLEEXPIRATIONDAT");
            AnyError = 1;
            GX_FocusControl = edtProductPerishableExpirationDat_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A74ProductPerishableModifiedDate) || ( DateTimeUtil.ResetTime ( A74ProductPerishableModifiedDate ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Product Perishable Modified Date is out of range", "OutOfRange", 1, "PRODUCTPERISHABLEMODIFIEDDATE");
            AnyError = 1;
            GX_FocusControl = edtProductPerishableModifiedDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0A14( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_14( int A15ProductId )
      {
         /* Using cursor T000A6 */
         pr_default.execute(4, new Object[] {A15ProductId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No matching 'Product'.", "ForeignKeyNotFound", 1, "PRODUCTID");
            AnyError = 1;
            GX_FocusControl = edtProductId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A16ProductName = T000A6_A16ProductName[0];
         AssignAttri("", false, "A16ProductName", A16ProductName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A16ProductName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey0A14( )
      {
         /* Using cursor T000A7 */
         pr_default.execute(5, new Object[] {A70ProductPerishableId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound14 = 1;
         }
         else
         {
            RcdFound14 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000A3 */
         pr_default.execute(1, new Object[] {A70ProductPerishableId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0A14( 13) ;
            RcdFound14 = 1;
            A70ProductPerishableId = T000A3_A70ProductPerishableId[0];
            AssignAttri("", false, "A70ProductPerishableId", StringUtil.LTrimStr( (decimal)(A70ProductPerishableId), 6, 0));
            A71ProductPerishableBatchDate = T000A3_A71ProductPerishableBatchDate[0];
            AssignAttri("", false, "A71ProductPerishableBatchDate", context.localUtil.Format(A71ProductPerishableBatchDate, "99/99/99"));
            A72ProductPerishableExpirationDat = T000A3_A72ProductPerishableExpirationDat[0];
            AssignAttri("", false, "A72ProductPerishableExpirationDat", context.localUtil.Format(A72ProductPerishableExpirationDat, "99/99/99"));
            A73ProductPerishableCreatedDate = T000A3_A73ProductPerishableCreatedDate[0];
            AssignAttri("", false, "A73ProductPerishableCreatedDate", context.localUtil.Format(A73ProductPerishableCreatedDate, "99/99/99"));
            A74ProductPerishableModifiedDate = T000A3_A74ProductPerishableModifiedDate[0];
            AssignAttri("", false, "A74ProductPerishableModifiedDate", context.localUtil.Format(A74ProductPerishableModifiedDate, "99/99/99"));
            A15ProductId = T000A3_A15ProductId[0];
            AssignAttri("", false, "A15ProductId", StringUtil.LTrimStr( (decimal)(A15ProductId), 6, 0));
            Z70ProductPerishableId = A70ProductPerishableId;
            sMode14 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0A14( ) ;
            if ( AnyError == 1 )
            {
               RcdFound14 = 0;
               InitializeNonKey0A14( ) ;
            }
            Gx_mode = sMode14;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound14 = 0;
            InitializeNonKey0A14( ) ;
            sMode14 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode14;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0A14( ) ;
         if ( RcdFound14 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound14 = 0;
         /* Using cursor T000A8 */
         pr_default.execute(6, new Object[] {A70ProductPerishableId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T000A8_A70ProductPerishableId[0] < A70ProductPerishableId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T000A8_A70ProductPerishableId[0] > A70ProductPerishableId ) ) )
            {
               A70ProductPerishableId = T000A8_A70ProductPerishableId[0];
               AssignAttri("", false, "A70ProductPerishableId", StringUtil.LTrimStr( (decimal)(A70ProductPerishableId), 6, 0));
               RcdFound14 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound14 = 0;
         /* Using cursor T000A9 */
         pr_default.execute(7, new Object[] {A70ProductPerishableId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T000A9_A70ProductPerishableId[0] > A70ProductPerishableId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T000A9_A70ProductPerishableId[0] < A70ProductPerishableId ) ) )
            {
               A70ProductPerishableId = T000A9_A70ProductPerishableId[0];
               AssignAttri("", false, "A70ProductPerishableId", StringUtil.LTrimStr( (decimal)(A70ProductPerishableId), 6, 0));
               RcdFound14 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0A14( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtProductId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0A14( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound14 == 1 )
            {
               if ( A70ProductPerishableId != Z70ProductPerishableId )
               {
                  A70ProductPerishableId = Z70ProductPerishableId;
                  AssignAttri("", false, "A70ProductPerishableId", StringUtil.LTrimStr( (decimal)(A70ProductPerishableId), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PRODUCTPERISHABLEID");
                  AnyError = 1;
                  GX_FocusControl = edtProductPerishableId_Internalname;
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
                  Update0A14( ) ;
                  GX_FocusControl = edtProductId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A70ProductPerishableId != Z70ProductPerishableId )
               {
                  /* Insert record */
                  GX_FocusControl = edtProductId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0A14( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PRODUCTPERISHABLEID");
                     AnyError = 1;
                     GX_FocusControl = edtProductPerishableId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtProductId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0A14( ) ;
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
         if ( A70ProductPerishableId != Z70ProductPerishableId )
         {
            A70ProductPerishableId = Z70ProductPerishableId;
            AssignAttri("", false, "A70ProductPerishableId", StringUtil.LTrimStr( (decimal)(A70ProductPerishableId), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PRODUCTPERISHABLEID");
            AnyError = 1;
            GX_FocusControl = edtProductPerishableId_Internalname;
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

      protected void CheckOptimisticConcurrency0A14( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000A2 */
            pr_default.execute(0, new Object[] {A70ProductPerishableId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ProductPerishable"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z71ProductPerishableBatchDate ) != DateTimeUtil.ResetTime ( T000A2_A71ProductPerishableBatchDate[0] ) ) || ( DateTimeUtil.ResetTime ( Z72ProductPerishableExpirationDat ) != DateTimeUtil.ResetTime ( T000A2_A72ProductPerishableExpirationDat[0] ) ) || ( DateTimeUtil.ResetTime ( Z73ProductPerishableCreatedDate ) != DateTimeUtil.ResetTime ( T000A2_A73ProductPerishableCreatedDate[0] ) ) || ( DateTimeUtil.ResetTime ( Z74ProductPerishableModifiedDate ) != DateTimeUtil.ResetTime ( T000A2_A74ProductPerishableModifiedDate[0] ) ) || ( Z15ProductId != T000A2_A15ProductId[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z71ProductPerishableBatchDate ) != DateTimeUtil.ResetTime ( T000A2_A71ProductPerishableBatchDate[0] ) )
               {
                  GXUtil.WriteLog("general.productperishable:[seudo value changed for attri]"+"ProductPerishableBatchDate");
                  GXUtil.WriteLogRaw("Old: ",Z71ProductPerishableBatchDate);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A71ProductPerishableBatchDate[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z72ProductPerishableExpirationDat ) != DateTimeUtil.ResetTime ( T000A2_A72ProductPerishableExpirationDat[0] ) )
               {
                  GXUtil.WriteLog("general.productperishable:[seudo value changed for attri]"+"ProductPerishableExpirationDat");
                  GXUtil.WriteLogRaw("Old: ",Z72ProductPerishableExpirationDat);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A72ProductPerishableExpirationDat[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z73ProductPerishableCreatedDate ) != DateTimeUtil.ResetTime ( T000A2_A73ProductPerishableCreatedDate[0] ) )
               {
                  GXUtil.WriteLog("general.productperishable:[seudo value changed for attri]"+"ProductPerishableCreatedDate");
                  GXUtil.WriteLogRaw("Old: ",Z73ProductPerishableCreatedDate);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A73ProductPerishableCreatedDate[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z74ProductPerishableModifiedDate ) != DateTimeUtil.ResetTime ( T000A2_A74ProductPerishableModifiedDate[0] ) )
               {
                  GXUtil.WriteLog("general.productperishable:[seudo value changed for attri]"+"ProductPerishableModifiedDate");
                  GXUtil.WriteLogRaw("Old: ",Z74ProductPerishableModifiedDate);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A74ProductPerishableModifiedDate[0]);
               }
               if ( Z15ProductId != T000A2_A15ProductId[0] )
               {
                  GXUtil.WriteLog("general.productperishable:[seudo value changed for attri]"+"ProductId");
                  GXUtil.WriteLogRaw("Old: ",Z15ProductId);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A15ProductId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ProductPerishable"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0A14( )
      {
         BeforeValidate0A14( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A14( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0A14( 0) ;
            CheckOptimisticConcurrency0A14( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A14( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0A14( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000A10 */
                     pr_default.execute(8, new Object[] {A71ProductPerishableBatchDate, A72ProductPerishableExpirationDat, A73ProductPerishableCreatedDate, A74ProductPerishableModifiedDate, A15ProductId});
                     A70ProductPerishableId = T000A10_A70ProductPerishableId[0];
                     AssignAttri("", false, "A70ProductPerishableId", StringUtil.LTrimStr( (decimal)(A70ProductPerishableId), 6, 0));
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("ProductPerishable");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0A0( ) ;
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
               Load0A14( ) ;
            }
            EndLevel0A14( ) ;
         }
         CloseExtendedTableCursors0A14( ) ;
      }

      protected void Update0A14( )
      {
         BeforeValidate0A14( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A14( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A14( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A14( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0A14( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000A11 */
                     pr_default.execute(9, new Object[] {A71ProductPerishableBatchDate, A72ProductPerishableExpirationDat, A73ProductPerishableCreatedDate, A74ProductPerishableModifiedDate, A15ProductId, A70ProductPerishableId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("ProductPerishable");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ProductPerishable"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0A14( ) ;
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
            EndLevel0A14( ) ;
         }
         CloseExtendedTableCursors0A14( ) ;
      }

      protected void DeferredUpdate0A14( )
      {
      }

      protected void delete( )
      {
         BeforeValidate0A14( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A14( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0A14( ) ;
            AfterConfirm0A14( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0A14( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000A12 */
                  pr_default.execute(10, new Object[] {A70ProductPerishableId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("ProductPerishable");
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
         sMode14 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0A14( ) ;
         Gx_mode = sMode14;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0A14( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV15Pgmname = "General.ProductPerishable";
            AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
            /* Using cursor T000A13 */
            pr_default.execute(11, new Object[] {A15ProductId});
            A16ProductName = T000A13_A16ProductName[0];
            AssignAttri("", false, "A16ProductName", A16ProductName);
            pr_default.close(11);
         }
      }

      protected void EndLevel0A14( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0A14( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(11);
            context.CommitDataStores("general.productperishable",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0A0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(11);
            context.RollbackDataStores("general.productperishable",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0A14( )
      {
         /* Scan By routine */
         /* Using cursor T000A14 */
         pr_default.execute(12);
         RcdFound14 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound14 = 1;
            A70ProductPerishableId = T000A14_A70ProductPerishableId[0];
            AssignAttri("", false, "A70ProductPerishableId", StringUtil.LTrimStr( (decimal)(A70ProductPerishableId), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0A14( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound14 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound14 = 1;
            A70ProductPerishableId = T000A14_A70ProductPerishableId[0];
            AssignAttri("", false, "A70ProductPerishableId", StringUtil.LTrimStr( (decimal)(A70ProductPerishableId), 6, 0));
         }
      }

      protected void ScanEnd0A14( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm0A14( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0A14( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0A14( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0A14( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0A14( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0A14( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0A14( )
      {
         edtProductPerishableId_Enabled = 0;
         AssignProp("", false, edtProductPerishableId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductPerishableId_Enabled), 5, 0), true);
         edtProductId_Enabled = 0;
         AssignProp("", false, edtProductId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductId_Enabled), 5, 0), true);
         edtProductName_Enabled = 0;
         AssignProp("", false, edtProductName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductName_Enabled), 5, 0), true);
         edtProductPerishableBatchDate_Enabled = 0;
         AssignProp("", false, edtProductPerishableBatchDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductPerishableBatchDate_Enabled), 5, 0), true);
         edtProductPerishableExpirationDat_Enabled = 0;
         AssignProp("", false, edtProductPerishableExpirationDat_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductPerishableExpirationDat_Enabled), 5, 0), true);
         edtProductPerishableCreatedDate_Enabled = 0;
         AssignProp("", false, edtProductPerishableCreatedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductPerishableCreatedDate_Enabled), 5, 0), true);
         edtProductPerishableModifiedDate_Enabled = 0;
         AssignProp("", false, edtProductPerishableModifiedDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProductPerishableModifiedDate_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0A14( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0A0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("general.productperishable.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7ProductPerishableId,6,0))}, new string[] {"Gx_mode","ProductPerishableId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"ProductPerishable");
         forbiddenHiddens.Add("ProductPerishableId", context.localUtil.Format( (decimal)(A70ProductPerishableId), "ZZZZZ9"));
         forbiddenHiddens.Add("ProductPerishableCreatedDate", context.localUtil.Format(A73ProductPerishableCreatedDate, "99/99/99"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("general\\productperishable:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z70ProductPerishableId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z70ProductPerishableId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z71ProductPerishableBatchDate", context.localUtil.DToC( Z71ProductPerishableBatchDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z72ProductPerishableExpirationDat", context.localUtil.DToC( Z72ProductPerishableExpirationDat, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z73ProductPerishableCreatedDate", context.localUtil.DToC( Z73ProductPerishableCreatedDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z74ProductPerishableModifiedDate", context.localUtil.DToC( Z74ProductPerishableModifiedDate, 0, "/"));
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
         GxWebStd.gx_hidden_field( context, "vPRODUCTPERISHABLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ProductPerishableId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPRODUCTPERISHABLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ProductPerishableId), "ZZZZZ9"), context));
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
         return formatLink("general.productperishable.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7ProductPerishableId,6,0))}, new string[] {"Gx_mode","ProductPerishableId"})  ;
      }

      public override string GetPgmname( )
      {
         return "General.ProductPerishable" ;
      }

      public override string GetPgmdesc( )
      {
         return "Product Perishable" ;
      }

      protected void InitializeNonKey0A14( )
      {
         A15ProductId = 0;
         AssignAttri("", false, "A15ProductId", StringUtil.LTrimStr( (decimal)(A15ProductId), 6, 0));
         A16ProductName = "";
         AssignAttri("", false, "A16ProductName", A16ProductName);
         A71ProductPerishableBatchDate = DateTime.MinValue;
         AssignAttri("", false, "A71ProductPerishableBatchDate", context.localUtil.Format(A71ProductPerishableBatchDate, "99/99/99"));
         A72ProductPerishableExpirationDat = DateTime.MinValue;
         AssignAttri("", false, "A72ProductPerishableExpirationDat", context.localUtil.Format(A72ProductPerishableExpirationDat, "99/99/99"));
         A74ProductPerishableModifiedDate = DateTime.MinValue;
         AssignAttri("", false, "A74ProductPerishableModifiedDate", context.localUtil.Format(A74ProductPerishableModifiedDate, "99/99/99"));
         A73ProductPerishableCreatedDate = Gx_date;
         AssignAttri("", false, "A73ProductPerishableCreatedDate", context.localUtil.Format(A73ProductPerishableCreatedDate, "99/99/99"));
         Z71ProductPerishableBatchDate = DateTime.MinValue;
         Z72ProductPerishableExpirationDat = DateTime.MinValue;
         Z73ProductPerishableCreatedDate = DateTime.MinValue;
         Z74ProductPerishableModifiedDate = DateTime.MinValue;
         Z15ProductId = 0;
      }

      protected void InitAll0A14( )
      {
         A70ProductPerishableId = 0;
         AssignAttri("", false, "A70ProductPerishableId", StringUtil.LTrimStr( (decimal)(A70ProductPerishableId), 6, 0));
         InitializeNonKey0A14( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A73ProductPerishableCreatedDate = i73ProductPerishableCreatedDate;
         AssignAttri("", false, "A73ProductPerishableCreatedDate", context.localUtil.Format(A73ProductPerishableCreatedDate, "99/99/99"));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202311617525080", true, true);
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
         context.AddJavascriptSource("general/productperishable.js", "?202311617525081", false, true);
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
         edtProductPerishableId_Internalname = "PRODUCTPERISHABLEID";
         edtProductId_Internalname = "PRODUCTID";
         edtProductName_Internalname = "PRODUCTNAME";
         edtProductPerishableBatchDate_Internalname = "PRODUCTPERISHABLEBATCHDATE";
         edtProductPerishableExpirationDat_Internalname = "PRODUCTPERISHABLEEXPIRATIONDAT";
         edtProductPerishableCreatedDate_Internalname = "PRODUCTPERISHABLECREATEDDATE";
         edtProductPerishableModifiedDate_Internalname = "PRODUCTPERISHABLEMODIFIEDDATE";
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
         Form.Caption = "Product Perishable";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirm";
         bttBtn_enter_Caption = "Confirm";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtProductPerishableModifiedDate_Jsonclick = "";
         edtProductPerishableModifiedDate_Enabled = 1;
         edtProductPerishableCreatedDate_Jsonclick = "";
         edtProductPerishableCreatedDate_Enabled = 0;
         edtProductPerishableExpirationDat_Jsonclick = "";
         edtProductPerishableExpirationDat_Enabled = 1;
         edtProductPerishableBatchDate_Jsonclick = "";
         edtProductPerishableBatchDate_Enabled = 1;
         edtProductName_Jsonclick = "";
         edtProductName_Enabled = 0;
         imgprompt_15_Visible = 1;
         imgprompt_15_Link = "";
         edtProductId_Jsonclick = "";
         edtProductId_Enabled = 1;
         edtProductPerishableId_Jsonclick = "";
         edtProductPerishableId_Enabled = 0;
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
         /* Using cursor T000A13 */
         pr_default.execute(11, new Object[] {A15ProductId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No matching 'Product'.", "ForeignKeyNotFound", 1, "PRODUCTID");
            AnyError = 1;
            GX_FocusControl = edtProductId_Internalname;
         }
         A16ProductName = T000A13_A16ProductName[0];
         pr_default.close(11);
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7ProductPerishableId',fld:'vPRODUCTPERISHABLEID',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7ProductPerishableId',fld:'vPRODUCTPERISHABLEID',pic:'ZZZZZ9',hsh:true},{av:'A70ProductPerishableId',fld:'PRODUCTPERISHABLEID',pic:'ZZZZZ9'},{av:'A73ProductPerishableCreatedDate',fld:'PRODUCTPERISHABLECREATEDDATE',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120A2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_PRODUCTPERISHABLEID","{handler:'Valid_Productperishableid',iparms:[]");
         setEventMetadata("VALID_PRODUCTPERISHABLEID",",oparms:[]}");
         setEventMetadata("VALID_PRODUCTID","{handler:'Valid_Productid',iparms:[{av:'A15ProductId',fld:'PRODUCTID',pic:'ZZZZZ9'},{av:'A16ProductName',fld:'PRODUCTNAME',pic:''}]");
         setEventMetadata("VALID_PRODUCTID",",oparms:[{av:'A16ProductName',fld:'PRODUCTNAME',pic:''}]}");
         setEventMetadata("VALID_PRODUCTPERISHABLEBATCHDATE","{handler:'Valid_Productperishablebatchdate',iparms:[]");
         setEventMetadata("VALID_PRODUCTPERISHABLEBATCHDATE",",oparms:[]}");
         setEventMetadata("VALID_PRODUCTPERISHABLEEXPIRATIONDAT","{handler:'Valid_Productperishableexpirationdat',iparms:[]");
         setEventMetadata("VALID_PRODUCTPERISHABLEEXPIRATIONDAT",",oparms:[]}");
         setEventMetadata("VALID_PRODUCTPERISHABLEMODIFIEDDATE","{handler:'Valid_Productperishablemodifieddate',iparms:[]");
         setEventMetadata("VALID_PRODUCTPERISHABLEMODIFIEDDATE",",oparms:[]}");
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
         Z71ProductPerishableBatchDate = DateTime.MinValue;
         Z72ProductPerishableExpirationDat = DateTime.MinValue;
         Z73ProductPerishableCreatedDate = DateTime.MinValue;
         Z74ProductPerishableModifiedDate = DateTime.MinValue;
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
         A71ProductPerishableBatchDate = DateTime.MinValue;
         A72ProductPerishableExpirationDat = DateTime.MinValue;
         A73ProductPerishableCreatedDate = DateTime.MinValue;
         A74ProductPerishableModifiedDate = DateTime.MinValue;
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_date = DateTime.MinValue;
         AV15Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode14 = "";
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
         T000A4_A16ProductName = new string[] {""} ;
         T000A5_A70ProductPerishableId = new int[1] ;
         T000A5_A16ProductName = new string[] {""} ;
         T000A5_A71ProductPerishableBatchDate = new DateTime[] {DateTime.MinValue} ;
         T000A5_A72ProductPerishableExpirationDat = new DateTime[] {DateTime.MinValue} ;
         T000A5_A73ProductPerishableCreatedDate = new DateTime[] {DateTime.MinValue} ;
         T000A5_A74ProductPerishableModifiedDate = new DateTime[] {DateTime.MinValue} ;
         T000A5_A15ProductId = new int[1] ;
         T000A6_A16ProductName = new string[] {""} ;
         T000A7_A70ProductPerishableId = new int[1] ;
         T000A3_A70ProductPerishableId = new int[1] ;
         T000A3_A71ProductPerishableBatchDate = new DateTime[] {DateTime.MinValue} ;
         T000A3_A72ProductPerishableExpirationDat = new DateTime[] {DateTime.MinValue} ;
         T000A3_A73ProductPerishableCreatedDate = new DateTime[] {DateTime.MinValue} ;
         T000A3_A74ProductPerishableModifiedDate = new DateTime[] {DateTime.MinValue} ;
         T000A3_A15ProductId = new int[1] ;
         T000A8_A70ProductPerishableId = new int[1] ;
         T000A9_A70ProductPerishableId = new int[1] ;
         T000A2_A70ProductPerishableId = new int[1] ;
         T000A2_A71ProductPerishableBatchDate = new DateTime[] {DateTime.MinValue} ;
         T000A2_A72ProductPerishableExpirationDat = new DateTime[] {DateTime.MinValue} ;
         T000A2_A73ProductPerishableCreatedDate = new DateTime[] {DateTime.MinValue} ;
         T000A2_A74ProductPerishableModifiedDate = new DateTime[] {DateTime.MinValue} ;
         T000A2_A15ProductId = new int[1] ;
         T000A10_A70ProductPerishableId = new int[1] ;
         T000A13_A16ProductName = new string[] {""} ;
         T000A14_A70ProductPerishableId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i73ProductPerishableCreatedDate = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.general.productperishable__default(),
            new Object[][] {
                new Object[] {
               T000A2_A70ProductPerishableId, T000A2_A71ProductPerishableBatchDate, T000A2_A72ProductPerishableExpirationDat, T000A2_A73ProductPerishableCreatedDate, T000A2_A74ProductPerishableModifiedDate, T000A2_A15ProductId
               }
               , new Object[] {
               T000A3_A70ProductPerishableId, T000A3_A71ProductPerishableBatchDate, T000A3_A72ProductPerishableExpirationDat, T000A3_A73ProductPerishableCreatedDate, T000A3_A74ProductPerishableModifiedDate, T000A3_A15ProductId
               }
               , new Object[] {
               T000A4_A16ProductName
               }
               , new Object[] {
               T000A5_A70ProductPerishableId, T000A5_A16ProductName, T000A5_A71ProductPerishableBatchDate, T000A5_A72ProductPerishableExpirationDat, T000A5_A73ProductPerishableCreatedDate, T000A5_A74ProductPerishableModifiedDate, T000A5_A15ProductId
               }
               , new Object[] {
               T000A6_A16ProductName
               }
               , new Object[] {
               T000A7_A70ProductPerishableId
               }
               , new Object[] {
               T000A8_A70ProductPerishableId
               }
               , new Object[] {
               T000A9_A70ProductPerishableId
               }
               , new Object[] {
               T000A10_A70ProductPerishableId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000A13_A16ProductName
               }
               , new Object[] {
               T000A14_A70ProductPerishableId
               }
            }
         );
         AV15Pgmname = "General.ProductPerishable";
         Z73ProductPerishableCreatedDate = DateTime.MinValue;
         A73ProductPerishableCreatedDate = DateTime.MinValue;
         i73ProductPerishableCreatedDate = DateTime.MinValue;
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
      private short RcdFound14 ;
      private short GX_JID ;
      private short nIsDirty_14 ;
      private short gxajaxcallmode ;
      private int wcpOAV7ProductPerishableId ;
      private int Z70ProductPerishableId ;
      private int Z15ProductId ;
      private int N15ProductId ;
      private int A15ProductId ;
      private int AV7ProductPerishableId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A70ProductPerishableId ;
      private int edtProductPerishableId_Enabled ;
      private int edtProductId_Enabled ;
      private int imgprompt_15_Visible ;
      private int edtProductName_Enabled ;
      private int edtProductPerishableBatchDate_Enabled ;
      private int edtProductPerishableExpirationDat_Enabled ;
      private int edtProductPerishableCreatedDate_Enabled ;
      private int edtProductPerishableModifiedDate_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int AV11Insert_ProductId ;
      private int AV16GXV1 ;
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
      private string edtProductPerishableId_Internalname ;
      private string edtProductPerishableId_Jsonclick ;
      private string edtProductId_Jsonclick ;
      private string imgprompt_15_gximage ;
      private string sImgUrl ;
      private string imgprompt_15_Internalname ;
      private string imgprompt_15_Link ;
      private string edtProductName_Internalname ;
      private string edtProductName_Jsonclick ;
      private string edtProductPerishableBatchDate_Internalname ;
      private string edtProductPerishableBatchDate_Jsonclick ;
      private string edtProductPerishableExpirationDat_Internalname ;
      private string edtProductPerishableExpirationDat_Jsonclick ;
      private string edtProductPerishableCreatedDate_Internalname ;
      private string edtProductPerishableCreatedDate_Jsonclick ;
      private string edtProductPerishableModifiedDate_Internalname ;
      private string edtProductPerishableModifiedDate_Jsonclick ;
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
      private string sMode14 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z71ProductPerishableBatchDate ;
      private DateTime Z72ProductPerishableExpirationDat ;
      private DateTime Z73ProductPerishableCreatedDate ;
      private DateTime Z74ProductPerishableModifiedDate ;
      private DateTime A71ProductPerishableBatchDate ;
      private DateTime A72ProductPerishableExpirationDat ;
      private DateTime A73ProductPerishableCreatedDate ;
      private DateTime A74ProductPerishableModifiedDate ;
      private DateTime Gx_date ;
      private DateTime i73ProductPerishableCreatedDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool returnInSub ;
      private string A16ProductName ;
      private string Z16ProductName ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T000A4_A16ProductName ;
      private int[] T000A5_A70ProductPerishableId ;
      private string[] T000A5_A16ProductName ;
      private DateTime[] T000A5_A71ProductPerishableBatchDate ;
      private DateTime[] T000A5_A72ProductPerishableExpirationDat ;
      private DateTime[] T000A5_A73ProductPerishableCreatedDate ;
      private DateTime[] T000A5_A74ProductPerishableModifiedDate ;
      private int[] T000A5_A15ProductId ;
      private string[] T000A6_A16ProductName ;
      private int[] T000A7_A70ProductPerishableId ;
      private int[] T000A3_A70ProductPerishableId ;
      private DateTime[] T000A3_A71ProductPerishableBatchDate ;
      private DateTime[] T000A3_A72ProductPerishableExpirationDat ;
      private DateTime[] T000A3_A73ProductPerishableCreatedDate ;
      private DateTime[] T000A3_A74ProductPerishableModifiedDate ;
      private int[] T000A3_A15ProductId ;
      private int[] T000A8_A70ProductPerishableId ;
      private int[] T000A9_A70ProductPerishableId ;
      private int[] T000A2_A70ProductPerishableId ;
      private DateTime[] T000A2_A71ProductPerishableBatchDate ;
      private DateTime[] T000A2_A72ProductPerishableExpirationDat ;
      private DateTime[] T000A2_A73ProductPerishableCreatedDate ;
      private DateTime[] T000A2_A74ProductPerishableModifiedDate ;
      private int[] T000A2_A15ProductId ;
      private int[] T000A10_A70ProductPerishableId ;
      private string[] T000A13_A16ProductName ;
      private int[] T000A14_A70ProductPerishableId ;
      private GXWebForm Form ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV12TrnContextAtt ;
   }

   public class productperishable__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT000A5;
          prmT000A5 = new Object[] {
          new ParDef("@ProductPerishableId",GXType.Int32,6,0)
          };
          Object[] prmT000A4;
          prmT000A4 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmT000A6;
          prmT000A6 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmT000A7;
          prmT000A7 = new Object[] {
          new ParDef("@ProductPerishableId",GXType.Int32,6,0)
          };
          Object[] prmT000A3;
          prmT000A3 = new Object[] {
          new ParDef("@ProductPerishableId",GXType.Int32,6,0)
          };
          Object[] prmT000A8;
          prmT000A8 = new Object[] {
          new ParDef("@ProductPerishableId",GXType.Int32,6,0)
          };
          Object[] prmT000A9;
          prmT000A9 = new Object[] {
          new ParDef("@ProductPerishableId",GXType.Int32,6,0)
          };
          Object[] prmT000A2;
          prmT000A2 = new Object[] {
          new ParDef("@ProductPerishableId",GXType.Int32,6,0)
          };
          Object[] prmT000A10;
          prmT000A10 = new Object[] {
          new ParDef("@ProductPerishableBatchDate",GXType.Date,8,0) ,
          new ParDef("@ProductPerishableExpirationDat",GXType.Date,8,0) ,
          new ParDef("@ProductPerishableCreatedDate",GXType.Date,8,0) ,
          new ParDef("@ProductPerishableModifiedDate",GXType.Date,8,0) ,
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          Object[] prmT000A11;
          prmT000A11 = new Object[] {
          new ParDef("@ProductPerishableBatchDate",GXType.Date,8,0) ,
          new ParDef("@ProductPerishableExpirationDat",GXType.Date,8,0) ,
          new ParDef("@ProductPerishableCreatedDate",GXType.Date,8,0) ,
          new ParDef("@ProductPerishableModifiedDate",GXType.Date,8,0) ,
          new ParDef("@ProductId",GXType.Int32,6,0) ,
          new ParDef("@ProductPerishableId",GXType.Int32,6,0)
          };
          Object[] prmT000A12;
          prmT000A12 = new Object[] {
          new ParDef("@ProductPerishableId",GXType.Int32,6,0)
          };
          Object[] prmT000A14;
          prmT000A14 = new Object[] {
          };
          Object[] prmT000A13;
          prmT000A13 = new Object[] {
          new ParDef("@ProductId",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("T000A2", "SELECT [ProductPerishableId], [ProductPerishableBatchDate], [ProductPerishableExpirationDat], [ProductPerishableCreatedDate], [ProductPerishableModifiedDate], [ProductId] FROM [ProductPerishable] WITH (UPDLOCK) WHERE [ProductPerishableId] = @ProductPerishableId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A3", "SELECT [ProductPerishableId], [ProductPerishableBatchDate], [ProductPerishableExpirationDat], [ProductPerishableCreatedDate], [ProductPerishableModifiedDate], [ProductId] FROM [ProductPerishable] WHERE [ProductPerishableId] = @ProductPerishableId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A4", "SELECT [ProductName] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A5", "SELECT TM1.[ProductPerishableId], T2.[ProductName], TM1.[ProductPerishableBatchDate], TM1.[ProductPerishableExpirationDat], TM1.[ProductPerishableCreatedDate], TM1.[ProductPerishableModifiedDate], TM1.[ProductId] FROM ([ProductPerishable] TM1 INNER JOIN [Product] T2 ON T2.[ProductId] = TM1.[ProductId]) WHERE TM1.[ProductPerishableId] = @ProductPerishableId ORDER BY TM1.[ProductPerishableId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A6", "SELECT [ProductName] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A7", "SELECT [ProductPerishableId] FROM [ProductPerishable] WHERE [ProductPerishableId] = @ProductPerishableId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A8", "SELECT TOP 1 [ProductPerishableId] FROM [ProductPerishable] WHERE ( [ProductPerishableId] > @ProductPerishableId) ORDER BY [ProductPerishableId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A8,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000A9", "SELECT TOP 1 [ProductPerishableId] FROM [ProductPerishable] WHERE ( [ProductPerishableId] < @ProductPerishableId) ORDER BY [ProductPerishableId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A9,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000A10", "INSERT INTO [ProductPerishable]([ProductPerishableBatchDate], [ProductPerishableExpirationDat], [ProductPerishableCreatedDate], [ProductPerishableModifiedDate], [ProductId]) VALUES(@ProductPerishableBatchDate, @ProductPerishableExpirationDat, @ProductPerishableCreatedDate, @ProductPerishableModifiedDate, @ProductId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000A10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000A11", "UPDATE [ProductPerishable] SET [ProductPerishableBatchDate]=@ProductPerishableBatchDate, [ProductPerishableExpirationDat]=@ProductPerishableExpirationDat, [ProductPerishableCreatedDate]=@ProductPerishableCreatedDate, [ProductPerishableModifiedDate]=@ProductPerishableModifiedDate, [ProductId]=@ProductId  WHERE [ProductPerishableId] = @ProductPerishableId", GxErrorMask.GX_NOMASK,prmT000A11)
             ,new CursorDef("T000A12", "DELETE FROM [ProductPerishable]  WHERE [ProductPerishableId] = @ProductPerishableId", GxErrorMask.GX_NOMASK,prmT000A12)
             ,new CursorDef("T000A13", "SELECT [ProductName] FROM [Product] WHERE [ProductId] = @ProductId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A14", "SELECT [ProductPerishableId] FROM [ProductPerishable] ORDER BY [ProductPerishableId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A14,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
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
