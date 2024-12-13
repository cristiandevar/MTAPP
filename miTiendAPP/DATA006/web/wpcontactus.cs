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
   public class wpcontactus : GXDataArea
   {
      public wpcontactus( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("mtaKB", true);
      }

      public wpcontactus( IGxContext context )
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

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
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
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("general.ui.masterguest", "GeneXus.Programs.general.ui.masterguest", new Object[] {context});
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

      public override short ExecuteStartEvent( )
      {
         PA3P2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3P2( ) ;
         }
         return gxajaxcallmode ;
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
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
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
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpcontactus.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vEMAILTITLE", AV20EmailTitle);
         GxWebStd.gx_hidden_field( context, "vEMAILSUBTITLE", AV24EmailSubtitle);
         GxWebStd.gx_hidden_field( context, "vEMAILBODY", AV10EmailBody);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vURLS", AV14URLs);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vURLS", AV14URLs);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vNAMES", AV15Names);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vNAMES", AV15Names);
         }
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
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

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE3P2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3P2( ) ;
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
         return formatLink("wpcontactus.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WPContactUs" ;
      }

      public override string GetPgmdesc( )
      {
         return "WPContact Us" ;
      }

      protected void WB3P0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableform_Internalname, divTableform_Visible, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Send us an Email", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WPContactUs.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            context.WriteHtmlText( "<hr/>") ;
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
            GxWebStd.gx_div_start( context, divTable2_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavLastname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLastname_Internalname, "Last Name", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLastname_Internalname, AV5LastName, StringUtil.RTrim( context.localUtil.Format( AV5LastName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLastname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLastname_Enabled, 0, "text", "", 80, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Name", "left", true, "", "HLP_WPContactUs.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavFirstname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFirstname_Internalname, "First Name", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFirstname_Internalname, AV6FirstName, StringUtil.RTrim( context.localUtil.Format( AV6FirstName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFirstname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFirstname_Enabled, 0, "text", "", 80, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "Name", "left", true, "", "HLP_WPContactUs.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavEmail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavEmail_Internalname, "Email", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavEmail_Internalname, AV7Email, StringUtil.RTrim( context.localUtil.Format( AV7Email, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+AV7Email, "", "", "", edtavEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "left", true, "", "HLP_WPContactUs.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavPhone_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPhone_Internalname, "Phone", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            if ( context.isSmartDevice( ) )
            {
               gxphoneLink = "tel:" + StringUtil.RTrim( AV8Phone);
            }
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPhone_Internalname, StringUtil.RTrim( AV8Phone), StringUtil.RTrim( context.localUtil.Format( AV8Phone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtavPhone_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavPhone_Enabled, 0, "tel", "", 80, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "left", true, "", "HLP_WPContactUs.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavMessage_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavMessage_Internalname, "Message", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavMessage_Internalname, AV9Message, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", 0, 1, edtavMessage_Enabled, 0, 80, "chr", 15, "row", 0, StyleString, ClassString, "", "", "2000", 1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WPContactUs.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttContactus_Internalname, "", "Send", bttContactus_Jsonclick, 5, "Send", "", StyleString, ClassString, bttContactus_Visible, bttContactus_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPContactUs.htm");
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
            GxWebStd.gx_div_start( context, divTablethankyou_Internalname, divTablethankyou_Visible, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Thank you for contact us", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WPContactUs.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            context.WriteHtmlText( "<hr/>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "The message with all the details you provided was sent, we will contact you soon", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextblockLarge", 0, "", 1, 1, 0, 0, "HLP_WPContactUs.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START3P2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_2-169539", 0) ;
            }
            Form.Meta.addItem("description", "WPContact Us", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3P0( ) ;
      }

      protected void WS3P2( )
      {
         START3P2( ) ;
         EVT3P2( ) ;
      }

      protected void EVT3P2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
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
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E113P2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                    /* Execute user event: Enter */
                                    E123P2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E133P2 ();
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
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
      }

      protected void WE3P2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA3P2( )
      {
         if ( nDonePA == 0 )
         {
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
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavLastname_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF3P2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      protected void RF3P2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E133P2 ();
            WB3P0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes3P2( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3P0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E113P2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            AV5LastName = cgiGet( edtavLastname_Internalname);
            AssignAttri("", false, "AV5LastName", AV5LastName);
            AV6FirstName = cgiGet( edtavFirstname_Internalname);
            AssignAttri("", false, "AV6FirstName", AV6FirstName);
            AV7Email = cgiGet( edtavEmail_Internalname);
            AssignAttri("", false, "AV7Email", AV7Email);
            AV8Phone = cgiGet( edtavPhone_Internalname);
            AssignAttri("", false, "AV8Phone", AV8Phone);
            AV9Message = cgiGet( edtavMessage_Internalname);
            AssignAttri("", false, "AV9Message", AV9Message);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E113P2 ();
         if (returnInSub) return;
      }

      protected void E113P2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV10EmailBody = "";
         AssignAttri("", false, "AV10EmailBody", AV10EmailBody);
         AV5LastName = "";
         AssignAttri("", false, "AV5LastName", AV5LastName);
         AV6FirstName = "";
         AssignAttri("", false, "AV6FirstName", AV6FirstName);
         AV7Email = "";
         AssignAttri("", false, "AV7Email", AV7Email);
         AV8Phone = "";
         AssignAttri("", false, "AV8Phone", AV8Phone);
         AV9Message = "";
         AssignAttri("", false, "AV9Message", AV9Message);
         AV14URLs.Clear();
         AV15Names.Clear();
         divTablethankyou_Visible = 0;
         AssignProp("", false, divTablethankyou_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablethankyou_Visible), 5, 0), true);
         divTableform_Visible = 1;
         AssignProp("", false, divTableform_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableform_Visible), 5, 0), true);
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E123P2 ();
         if (returnInSub) return;
      }

      protected void E123P2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV12AllOk = true;
         bttContactus_Enabled = 0;
         AssignProp("", false, bttContactus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttContactus_Enabled), 5, 0), true);
         bttContactus_Visible = 0;
         AssignProp("", false, bttContactus_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttContactus_Visible), 5, 0), true);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV5LastName)) )
         {
            AV12AllOk = false;
            GX_msglist.addItem("Last Name is required");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV6FirstName)) && AV12AllOk )
         {
            AV12AllOk = false;
            GX_msglist.addItem("First Name is required");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV7Email)) && AV12AllOk )
         {
            AV12AllOk = false;
            GX_msglist.addItem("Email is required");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9Message)) && AV12AllOk )
         {
            AV12AllOk = false;
            GX_msglist.addItem("Messagge is required");
         }
         if ( AV12AllOk )
         {
            /* Execute user subroutine: 'BODYEMAIL' */
            S112 ();
            if (returnInSub) return;
            new sendemailprepareheader(context ).execute(  AV20EmailTitle,  AV24EmailSubtitle,  AV10EmailBody, out  AV28EmailBodyAux) ;
            AV10EmailBody = AV28EmailBodyAux;
            AssignAttri("", false, "AV10EmailBody", AV10EmailBody);
            AV16MeEmail = "mtappcontact@gmail.com";
            GXt_char1 = "Contact Us";
            new sendemail(context ).execute(  AV16MeEmail, ref  AV10EmailBody, ref  GXt_char1, ref  AV14URLs, ref  AV15Names, ref  AV12AllOk) ;
            AssignAttri("", false, "AV10EmailBody", AV10EmailBody);
            divTablethankyou_Visible = 1;
            AssignProp("", false, divTablethankyou_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablethankyou_Visible), 5, 0), true);
            divTableform_Visible = 0;
            AssignProp("", false, divTableform_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTableform_Visible), 5, 0), true);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15Names", AV15Names);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14URLs", AV14URLs);
      }

      protected void S112( )
      {
         /* 'BODYEMAIL' Routine */
         returnInSub = false;
         AV20EmailTitle = "Somebody has Contacted You";
         AssignAttri("", false, "AV20EmailTitle", AV20EmailTitle);
         AV24EmailSubtitle = "Hello! Somebody has sent you an email with the following information:";
         AssignAttri("", false, "AV24EmailSubtitle", AV24EmailSubtitle);
         AV11Date = DateTimeUtil.ServerDate( context, pr_default);
         AV10EmailBody = "                <table class=\"table table-border table-striped\">";
         AssignAttri("", false, "AV10EmailBody", AV10EmailBody);
         AV10EmailBody += "                    <tr>";
         AssignAttri("", false, "AV10EmailBody", AV10EmailBody);
         AV10EmailBody += "                        <td style=\"text-align:left;\"><strong>Email</strong></td>";
         AssignAttri("", false, "AV10EmailBody", AV10EmailBody);
         AV10EmailBody += "                        <td>" + AV7Email + "</td>";
         AssignAttri("", false, "AV10EmailBody", AV10EmailBody);
         AV10EmailBody += "                    </tr>";
         AssignAttri("", false, "AV10EmailBody", AV10EmailBody);
         AV10EmailBody += "                    <tr>";
         AssignAttri("", false, "AV10EmailBody", AV10EmailBody);
         AV10EmailBody += "                        <td style=\"text-align:left;\"><strong>Date</strong></td>";
         AssignAttri("", false, "AV10EmailBody", AV10EmailBody);
         AV10EmailBody += "                        <td>";
         AssignAttri("", false, "AV10EmailBody", AV10EmailBody);
         AV10EmailBody += context.localUtil.Format( AV11Date, "99/99/99");
         AssignAttri("", false, "AV10EmailBody", AV10EmailBody);
         AV10EmailBody += "					</td>";
         AssignAttri("", false, "AV10EmailBody", AV10EmailBody);
         AV10EmailBody += "                    </tr>";
         AssignAttri("", false, "AV10EmailBody", AV10EmailBody);
         AV10EmailBody += "                    <tr>";
         AssignAttri("", false, "AV10EmailBody", AV10EmailBody);
         AV10EmailBody += "                        <td style=\"text-align:left;\"><strong>Full Name</strong></td>";
         AssignAttri("", false, "AV10EmailBody", AV10EmailBody);
         AV10EmailBody += "                        <td>" + AV5LastName + "," + AV6FirstName + "</td>";
         AssignAttri("", false, "AV10EmailBody", AV10EmailBody);
         AV10EmailBody += "                    </tr>";
         AssignAttri("", false, "AV10EmailBody", AV10EmailBody);
         AV10EmailBody += "                    <tr>";
         AssignAttri("", false, "AV10EmailBody", AV10EmailBody);
         AV10EmailBody += "                        <td style=\"text-align:left;\"><strong>Phone</strong></td>";
         AssignAttri("", false, "AV10EmailBody", AV10EmailBody);
         AV10EmailBody += "                        <td>" + AV8Phone + "</td>";
         AssignAttri("", false, "AV10EmailBody", AV10EmailBody);
         AV10EmailBody += "                    </tr>";
         AssignAttri("", false, "AV10EmailBody", AV10EmailBody);
         AV10EmailBody += "                    <tr>";
         AssignAttri("", false, "AV10EmailBody", AV10EmailBody);
         AV10EmailBody += "                        <td style=\"text-align:left;\"><strong>Message</strong></td>";
         AssignAttri("", false, "AV10EmailBody", AV10EmailBody);
         AV10EmailBody += "                        <td>";
         AssignAttri("", false, "AV10EmailBody", AV10EmailBody);
         AV10EmailBody += "                            <p>" + AV9Message + "</p>";
         AssignAttri("", false, "AV10EmailBody", AV10EmailBody);
         AV10EmailBody += "                        </td>";
         AssignAttri("", false, "AV10EmailBody", AV10EmailBody);
         AV10EmailBody += "                    </tr>";
         AssignAttri("", false, "AV10EmailBody", AV10EmailBody);
         AV10EmailBody += "                </table>";
         AssignAttri("", false, "AV10EmailBody", AV10EmailBody);
      }

      protected void nextLoad( )
      {
      }

      protected void E133P2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA3P2( ) ;
         WS3P2( ) ;
         WE3P2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202411273125476", true, true);
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
         context.AddJavascriptSource("wpcontactus.js", "?202411273125476", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTextblock1_Internalname = "TEXTBLOCK1";
         divTable1_Internalname = "TABLE1";
         edtavLastname_Internalname = "vLASTNAME";
         edtavFirstname_Internalname = "vFIRSTNAME";
         edtavEmail_Internalname = "vEMAIL";
         edtavPhone_Internalname = "vPHONE";
         edtavMessage_Internalname = "vMESSAGE";
         divTable2_Internalname = "TABLE2";
         bttContactus_Internalname = "CONTACTUS";
         divTableform_Internalname = "TABLEFORM";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         divTablethankyou_Internalname = "TABLETHANKYOU";
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
         divTablethankyou_Visible = 1;
         bttContactus_Enabled = 1;
         bttContactus_Visible = 1;
         edtavMessage_Enabled = 1;
         edtavPhone_Jsonclick = "";
         edtavPhone_Enabled = 1;
         edtavEmail_Jsonclick = "";
         edtavEmail_Enabled = 1;
         edtavFirstname_Jsonclick = "";
         edtavFirstname_Enabled = 1;
         edtavLastname_Jsonclick = "";
         edtavLastname_Enabled = 1;
         divTableform_Visible = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "WPContact Us";
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("ENTER","{handler:'E123P2',iparms:[{av:'AV5LastName',fld:'vLASTNAME',pic:''},{av:'AV6FirstName',fld:'vFIRSTNAME',pic:''},{av:'AV7Email',fld:'vEMAIL',pic:''},{av:'AV9Message',fld:'vMESSAGE',pic:''},{av:'AV20EmailTitle',fld:'vEMAILTITLE',pic:''},{av:'AV24EmailSubtitle',fld:'vEMAILSUBTITLE',pic:''},{av:'AV10EmailBody',fld:'vEMAILBODY',pic:''},{av:'AV14URLs',fld:'vURLS',pic:''},{av:'AV15Names',fld:'vNAMES',pic:''},{av:'AV8Phone',fld:'vPHONE',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{ctrl:'CONTACTUS',prop:'Enabled'},{ctrl:'CONTACTUS',prop:'Visible'},{av:'AV10EmailBody',fld:'vEMAILBODY',pic:''},{av:'AV15Names',fld:'vNAMES',pic:''},{av:'AV14URLs',fld:'vURLS',pic:''},{av:'divTablethankyou_Visible',ctrl:'TABLETHANKYOU',prop:'Visible'},{av:'divTableform_Visible',ctrl:'TABLEFORM',prop:'Visible'},{av:'AV20EmailTitle',fld:'vEMAILTITLE',pic:''},{av:'AV24EmailSubtitle',fld:'vEMAILSUBTITLE',pic:''}]}");
         setEventMetadata("VALIDV_EMAIL","{handler:'Validv_Email',iparms:[]");
         setEventMetadata("VALIDV_EMAIL",",oparms:[]}");
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
      }

      public override void initialize( )
      {
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV20EmailTitle = "";
         AV24EmailSubtitle = "";
         AV10EmailBody = "";
         AV14URLs = new GxSimpleCollection<string>();
         AV15Names = new GxSimpleCollection<string>();
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTextblock1_Jsonclick = "";
         TempTags = "";
         AV5LastName = "";
         AV6FirstName = "";
         AV7Email = "";
         gxphoneLink = "";
         AV8Phone = "";
         ClassString = "";
         StyleString = "";
         AV9Message = "";
         bttContactus_Jsonclick = "";
         lblTextblock2_Jsonclick = "";
         lblTextblock3_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV28EmailBodyAux = "";
         AV16MeEmail = "";
         GXt_char1 = "";
         AV11Date = DateTime.MinValue;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpcontactus__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int divTableform_Visible ;
      private int edtavLastname_Enabled ;
      private int edtavFirstname_Enabled ;
      private int edtavEmail_Enabled ;
      private int edtavPhone_Enabled ;
      private int edtavMessage_Enabled ;
      private int bttContactus_Visible ;
      private int bttContactus_Enabled ;
      private int divTablethankyou_Visible ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divTableform_Internalname ;
      private string divTable1_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string divTable2_Internalname ;
      private string edtavLastname_Internalname ;
      private string TempTags ;
      private string edtavLastname_Jsonclick ;
      private string edtavFirstname_Internalname ;
      private string edtavFirstname_Jsonclick ;
      private string edtavEmail_Internalname ;
      private string edtavEmail_Jsonclick ;
      private string edtavPhone_Internalname ;
      private string gxphoneLink ;
      private string AV8Phone ;
      private string edtavPhone_Jsonclick ;
      private string edtavMessage_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string bttContactus_Internalname ;
      private string bttContactus_Jsonclick ;
      private string divTablethankyou_Internalname ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXt_char1 ;
      private DateTime AV11Date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV12AllOk ;
      private string AV20EmailTitle ;
      private string AV24EmailSubtitle ;
      private string AV10EmailBody ;
      private string AV5LastName ;
      private string AV6FirstName ;
      private string AV7Email ;
      private string AV9Message ;
      private string AV28EmailBodyAux ;
      private string AV16MeEmail ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxSimpleCollection<string> AV14URLs ;
      private GxSimpleCollection<string> AV15Names ;
      private GXWebForm Form ;
   }

   public class wpcontactus__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

 }

}
